import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = { song: [], loading: true };
  }
  
  componentDidMount() {
    this.populateSongsData();
  }

  static renderSongs(songs) {
    return (
      <div className="card-deck text-center pt-5">
        {songs.map(song =>
          <div className="card">
            <img className="card-img-top" src={`${process.env.PUBLIC_URL}/images/${song.imageUrl}`} alt="Card image"  />
            <div className="card-body">
              <h4 className="card-title text-primary">{song.name}</h4>
              <a href={`/song-${song.id}`} className="btn btn-success">See Lyrics</a>
            </div>
          </div>
      )}
      </div>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Home.renderSongs(this.state.songs);

    return (
      <div className="mt-5">
        {contents}
      </div>
    );
  }

  async populateSongsData() {
    const response = await fetch('song/all');
    const data = await response.json();
    this.setState({ songs: data, loading: false });
  }
}
