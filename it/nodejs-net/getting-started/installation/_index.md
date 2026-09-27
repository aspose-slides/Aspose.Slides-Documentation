---
title: Installazione
type: docs
weight: 70
url: /it/nodejs-net/installation/
keywords:
- scarica Aspose.Slides
- installa Aspose.Slides
- installazione di Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Installa Aspose.Slides per Node.js via .NET da npm su Windows o Linux: prerequisiti, l'override edge-js, un ripristino NuGet una tantum e un primo programma che crea una presentazione."
---
## **Panoramica**

Aspose.Slides for Node.js via .NET è il pacchetto npm `aspose.slides.via.net`. Esegue la libreria Aspose.Slides .NET all'interno di Node.js tramite il bridge [edge-js](https://github.com/agracio/edge-js), quindi un'installazione funzionante richiede sia Node.js sia .NET.

Questo articolo ti porta da una macchina pulita a un primo programma che crea una presentazione. Ci sono quattro passaggi: creare un progetto con un override di edge-js, installare il pacchetto da npm, ripristinare le dipendenze .NET del pacchetto una volta, ed eseguire lo script dalla cartella del progetto.

## **Prerequisiti**

- **Node.js 22 o 24 LTS**, build x64, da [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 o successivo**, da [dotnet.microsoft.com](https://dotnet.microsoft.com/download). Il runtime .NET da solo non è sufficiente: lo step di restore sotto richiede l'SDK, così come il bridge quando lo script viene eseguito. Esegui `dotnet --list-sdks` per verificare quali SDK sono installati.
- **Solo su Linux**:
  - gli strumenti di compilazione `python3`, `make` e `g++`, perché npm compila edge-js durante l'installazione su Linux;
  - la libreria fontconfig, che la libreria di disegno nativa di Aspose.Slides carica.

  Su Debian, questi sono i pacchetti `python3`, `make`, `g++` e `libfontconfig1`.

I passaggi di questo articolo sono stati testati su queste piattaforme:

| Piattaforma | Risultato |
|---|---|
| Windows x64 con Node.js 22 o 24 | Funziona. Testato con il Microsoft Visual C++ Redistributable installato. |
| Linux x64 con Node.js 22 o 24, dove OpenSSL di sistema proviene dalla stessa linea di rilascio di OpenSSL integrato in Node.js, ad esempio Debian 13 | Funziona. |
| Linux dove le due versioni di OpenSSL differiscono, ad esempio Debian 12 | Node.js si arresta con un errore di segmentazione quando viene creata una presentazione. |
| macOS | Non verificato. |

Su Linux, confronta le due versioni prima di iniziare. Il primo comando stampa la versione OpenSSL integrata in Node.js; il secondo stampa la versione di sistema. Usa un sistema in cui entrambe iniziano con gli stessi numeri major e minor, ad esempio `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Se il comando `openssl` non viene trovato, installa prima il pacchetto `openssl`.

## **Crea un Progetto**

Crea una cartella per il tuo progetto, inizializzala e aggiungi un override che indica a npm quale release di edge-js installare:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Il pacchetto richiede una versione più vecchia di edge-js i cui binari precompilati per Windows terminano con Node.js 20, quindi senza l'override il primo script su Windows si interrompe con "The edge module has not been pre-compiled for node.js version". Il comando scrive l'override nella sezione `overrides` di `package.json`; aggiungilo prima di installare il pacchetto.

## **Installa il Pacchetto**

Installa Aspose.Slides for Node.js via .NET da npm:

```sh
npm install aspose.slides.via.net
```

Durante l'installazione, il pacchetto copia le sue librerie di disegno native (i file i cui nomi contengono `aspose.slides.drawing.capi`) nella cartella del progetto, accanto a `package.json`.

Il pacchetto è anche pubblicato come archivio ZIP su [releases.aspose.com](https://releases.aspose.com/slides/it/nodejs-net/). Questo articolo tratta solo l'installazione da npm.

## **Ripristina le Dipendenze .NET**

Il pacchetto contiene gli assembly Aspose.Slides .NET, ma non i 20 pacchetti NuGet da cui quegli assembly dipendono. A runtime, .NET li cerca nella cache dei pacchetti NuGet: `%USERPROFILE%\.nuget\packages` su Windows, `~/.nuget/packages` su Linux, o la cartella impostata nella variabile d'ambiente `NUGET_PACKAGES`. Se mancano, il primo script si interrompe con "assembly specified in the dependencies manifest was not found".

Per popolare la cache, crea una cartella chiamata `deps` nella cartella del progetto e salva il file seguente al suo interno con nome `deps.csproj`. Ogni elemento `PackageDownload` scarica un pacchetto alla versione esatta indicata tra parentesi; non viene compilato nulla.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

Quindi ripristinalo dalla cartella del progetto:

```sh
dotnet restore deps/deps.csproj
```

Devi eseguire questo passaggio una volta per macchina, non una volta per progetto: i pacchetti rimangono nella cache NuGet e i progetti successivi sulla stessa macchina li utilizzano. Dopo il ripristino, puoi eliminare la cartella `deps`.

## **Esegui un Primo Programma**

Crea un file chiamato `hello.js` nella cartella del progetto con il codice seguente. Crea una presentazione, aggiunge un rettangolo con il testo "Hello, World!" alla prima diapositiva e salva il risultato come `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Una nuova presentazione contiene una diapositiva vuota.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Posizione e dimensione sono in punti (1/72 di pollice): x, y, larghezza, altezza.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Rilascia l'oggetto .NET che supporta la presentazione.
    presentation.dispose();
}
```

Eseguilo dalla cartella del progetto:

```sh
node hello.js
```

Lo script stampa `Saved hello.pptx`. Apri `hello.pptx` per vedere una diapositiva con un rettangolo riempito contenente il testo. Senza licenza, Aspose.Slides aggiunge anche una filigrana di valutazione; vedi [Evaluate Aspose.Slides](/slides/it/nodejs-net/evaluate-aspose-slides/) e [Licensing](/slides/it/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Esegui i tuoi script dalla cartella del progetto, quella che contiene `package.json`. I percorsi relativi come `hello.pptx` vengono risolti rispetto alla cartella corrente, e su alcune macchine uno script avviato da un'altra cartella non può creare una presentazione.
{{% /alert %}}

L'API JavaScript rispecchia Aspose.Slides per .NET: le classi mantengono i loro nomi .NET, le proprietà e i metodi usano camelCase (`Slides` diventa `slides`, `AddAutoShape` diventa `addAutoShape`), e gli elementi delle collezioni si leggono con `get(index)`. Non esiste un riferimento API separato per questo pacchetto, quindi usa il [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/it/net/) per dettagli su classi e membri, per esempio [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/shapecollection/addautoshape/).

## **FAQ**

**Cosa significa "The edge module has not been pre-compiled for node.js version"?**

npm ha installato la release più vecchia di edge-js che il pacchetto richiede. Aggiungi l'override da [Crea un Progetto](#crea-un-progetto) ed esegui nuovamente `npm install`.

**Cosa significa "assembly specified in the dependencies manifest was not found"?**

Le dipendenze .NET non sono nella cache NuGet. La stessa esecuzione segnala anche "edge.initializeClrFunc is not a function". Segui [Ripristina le Dipendenze .NET](#ripristina-le-dipendenze-.net) una volta, poi esegui di nuovo lo script.

**Cosa significa "The edge native module is not available" su Linux?**

edge-js non è stato compilato durante `npm install`, ad esempio perché `python3`, `make` o `g++` mancavano. npm non segnala questo come errore. Installa gli strumenti di compilazione, poi esegui `npm rebuild edge-js` nella cartella del progetto.

**Perché la creazione di una presentazione fallisce con un errore vuoto "Error"?**

Su Linux, verifica che la libreria fontconfig sia installata (`libfontconfig1` su Debian); senza di essa la libreria di disegno nativa non può caricarsi. Su qualsiasi sistema, controlla anche di eseguire lo script dalla cartella del progetto.

**Perché Node.js si arresta con un errore di segmentazione su Linux?**

OpenSSL di sistema e OpenSSL integrato in Node.js provengono da linee di rilascio diverse. Confrontali come mostrato in [Prerequisiti](#prerequisiti) e usa una distribuzione o una build di Node.js in cui corrispondono.

**Devo ripetere il ripristino NuGet per ogni progetto?**

No. Il ripristino popola la cache NuGet per il tuo account utente, e ogni progetto sulla stessa macchina utilizza la stessa cache.