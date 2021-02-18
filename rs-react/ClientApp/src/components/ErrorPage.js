import React, { Component } from 'react';

export class ErrorPage extends Component {
  static displayName = ErrorPage.name;

  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="mt-5">
        <div className="card-deck text-center pt-5">
            <div className="card">
                <img className="card-img-top" src={`${process.env.PUBLIC_URL}/images/error-img.png`} alt="Card image"  />
                <div className="card-body">
                <a href="/" className="btn btn-success">Back To Home</a>
                </div>
            </div>
        </div>
      </div>
    );
  }
}
