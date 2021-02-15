import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Song1 } from './components/Song1';
import { Song2 } from './components/Song2';
import { Song3 } from './components/Song3';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/song-1' component={Song1} />
        <Route path='/song-2' component={Song2} />
        <Route path='/song-3' component={Song3} />
      </Layout>
    );
  }
}
