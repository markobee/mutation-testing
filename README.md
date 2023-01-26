# Mutation Testing Workshop

### Agenda

This is the sample repository for the session around mutation testing. For this 
session we use the tool [Stryker](https://stryker-mutator.io) and the 
samples are written in C#.

- You can create a fork of this repo and use GitHub CodesSpaces in the browser
- You can clone the repo and open the Folder with [VSCode](https://code.visualstudio.com/)
using a DevContainer (needs docker installed)

1. **Introduction**
    - What is Mutation Testing and why do we need it?
2. **Introduction into a mutation test tool (e.g. Stryker for C#)**
    - How to install
    - How to configure
    - How to use
    - How to integrate this in your CI/CD pipeline (Pull Request)
3. **Introduction to some  mutators**
    - Arithmetic operators (from + to -, from / to *)
    - Boolean operators (from && to ||)
    - Equality operators (from == to !=)
    - Logic operators (modification of if/else statements)
    - ...
    