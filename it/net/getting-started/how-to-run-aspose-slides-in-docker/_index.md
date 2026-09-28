---
title: Eseguire Aspose.Slides per .NET in Docker
linktitle: Docker
type: docs
weight: 140
url: /it/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Contenitore Docker
- compilazione multi-stage
- immagine contenitore
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- font
- conversione PDF
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Compila ed esegui un'applicazione console Aspose.Slides per .NET in Docker: un Dockerfile multi-stage basato sulle immagini .NET ufficiali, le librerie Linux e i font necessari, e come copiare i file generati sul tuo computer."
---
## **Panoramica**

Questo articolo mostra come eseguire Aspose.Slides per .NET in un contenitore Docker. Crei una piccola applicazione console che genera una presentazione con una casella di testo e la converte in PDF, la impacchetti con un Dockerfile multi‑stage sulle immagini .NET ufficiali di Microsoft, la esegui e copi i file generati sulla tua macchina. L’articolo elenca anche le librerie Linux e i font necessari ad Aspose.Slides nel contenitore e termina con una variante per Alpine Linux.

Hai solo bisogno di Docker sulla tua macchina. L’Sdk .NET fa parte dell’immagine di build, quindi non devi installarlo. Per installare Docker, vedi [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Scegliere il Pacchetto e l'Immagine Base**

Le immagini di contenitore predefinite .NET 10 sono basate su Ubuntu 24.04. Su queste immagini, usa il pacchetto [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Richiede la libreria `fontconfig`, e l’immagine runtime .NET non contiene né quella libreria né alcun font, quindi il Dockerfile in questo articolo installa entrambi.

Aspose.Slides.NET6.CrossPlatform non funziona su Alpine Linux. Per immagini basate su Alpine, usa il pacchetto [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) con `libgdiplus`, come descritto in [Run on Alpine Linux](#run-on-alpine-linux). [Installation](/slides/it/net/installation/) confronta i due pacchetti.

## **Creare il Progetto**

Crea una cartella denominata *HelloSlidesDocker* e aggiungi i tre file seguenti.

*HelloSlidesDocker.csproj* descrive un’applicazione console per .NET 10, la versione delle immagini di contenitore usate sotto, e fa riferimento ad Aspose.Slides.NET6.CrossPlatform. Imposta la versione del pacchetto all’ultima elencata su [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* crea una [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/), aggiunge un rettangolo con testo alla prima diapositiva e salva la presentazione due volte con il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/): come PPTX e come PDF. Entrambi i file vanno nella cartella *output* nella directory di lavoro. L’applicazione elenca poi i font che sono stati sostituiti durante il rendering del PDF, usando [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/getsubstitutions/), così puoi verificare se il contenitore possiede i font usati dalla presentazione.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* esclude le cartelle *bin* e *obj* di una build locale, e l’output di esecuzioni precedenti, dal contesto di build Docker, in modo che l’immagine venga costruita solo dai file sorgente.

```text
bin/
obj/
output/
```

## **Scrivere il Dockerfile**

Aggiungi un file denominato *Dockerfile* nella stessa cartella:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

Il file ha due fasi:

- **La fase di build** parte dall’immagine .NET SDK. Copia il file di progetto e ripristina i pacchetti NuGet per primi, così Docker riutilizza quel layer finché il file di progetto non cambia. Poi copia il codice sorgente e pubblica l’applicazione in */app*.
- **La fase runtime** parte dall’immagine runtime .NET più piccola, che non contiene SDK, e copia solo l’applicazione pubblicata. Installa due pacchetti:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform carica questa libreria all’avvio. Senza di essa, l’applicazione termina con una `DllNotFoundException` che segnala `libfontconfig.so.1`.
  - `fonts-dejavu-core`: l’immagine runtime non contiene font, e Aspose.Slides necessita di almeno un font installato per disegnare il testo; senza alcuno, la conversione si blocca con `InvalidOperationException: Cannot find any fonts installed on the system.` Il testo in font non installati viene disegnato con un font sostitutivo. I font DejaVu sono un piccolo set che permette di rendere il testo; per rendere le presentazioni con i font per cui sono stati progettati, vedi [Deploy Fonts](/slides/it/net/deploy-fonts/).

  `--no-install-recommends` e la rimozione delle liste di pacchetti mantengono piccola l’immagine. Le ultime righe creano la cartella *output*, la assegnano all’utente non root `app` definito dalle immagini .NET ufficiali (il suo ID utente è nella variabile `APP_UID`), e avviano l’applicazione come quell’utente.

Per un’applicazione ASP.NET Core, avvia la fase runtime da `mcr.microsoft.com/dotnet/aspnet:10.0` invece. È basata sulla stessa immagine Ubuntu, quindi sono necessari gli stessi pacchetti.

## **Compilare ed Eseguire il Container**

Apri un terminale nella cartella *HelloSlidesDocker*. Compila l’immagine, quindi esegui un contenitore da essa:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

La prima compilazione scarica le immagini base e i pacchetti NuGet, quindi richiede più tempo rispetto alle compilazioni successive. Il contenitore esegue l’applicazione e si arresta. Stampa:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

La prima riga mostra che il testo utilizza Calibri, il font predefinito di una nuova presentazione, e che Calibri non è installato nell’immagine, perciò Aspose.Slides ha disegnato il testo con DejaVu Sans. Il testo nel PDF è reale, selezionabile, in quel font. Senza licenza, Aspose.Slides aggiunge anche una filigrana di valutazione a ogni diapositiva salvata; vedi [Licensing](/slides/it/net/licensing/).

## **Copiare l'Uscita sul Proprio Computer**

I file si trovano nella cartella */app/output* del contenitore fermo. Copiali in una cartella *output* sulla tua macchina, quindi rimuovi il contenitore:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Questi due comandi funzionano allo stesso modo in Bash, PowerShell e nel Prompt dei comandi di Windows.

Su Linux, puoi invece montare una cartella della tua macchina nel contenitore, così l’applicazione scrive direttamente i file lì:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

L’opzione `--user` avvia l’applicazione con i tuoi ID utente e gruppo, così può scrivere nella cartella che hai creato e i file ti appartengono. `--rm` rimuove il contenitore quando si arresta.

## **Eseguire su Alpine Linux**

Per eseguire l’applicazione in un’immagine basata su Alpine, passa al pacchetto Aspose.Slides.NET e modifica la fase runtime. La fase di build rimane invariata.

1. In *HelloSlidesDocker.csproj*, sostituisci il riferimento al pacchetto:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

1. In *Program.cs*, aggiungi questa istruzione dopo le direttive `using`, prima della prima chiamata a Aspose.Slides. Abilita il supporto System.Drawing per Linux che Aspose.Slides.NET utilizza:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

1. In *Dockerfile*, sostituisci la fase runtime (tutto dal secondo `FROM` in poi) con:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

La fase Alpine installa tre pacchetti e modifica un’impostazione:

- `libgdiplus` è la libreria grafica che Aspose.Slides.NET usa su Linux.
- `font-dejavu` fornisce i font. Senza alcun font, la conversione si blocca con `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` e `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` forniscono dati culturali. Le immagini .NET Alpine girano in modalità globalizzazione‑invariata per impostazione predefinita; in tale modalità Aspose.Slides si arresta con una `CultureNotFoundException` per `en-US`.

Compila, esegui e copia l’output con gli stessi comandi di prima. Su questa immagine, l’applicazione stampa solo la riga `Saved`: con Aspose.Slides.NET su Linux, fontconfig sceglie il sostituto per un font mancante, e [GetSubstitutions](https://reference.aspose.com/slides/it/net/aspose.slides/ifontsmanager/getsubstitutions/) non lo elenca. [Deploy Fonts](/slides/it/net/deploy-fonts/) mostra come verificare quale font è stato usato.

## **FAQ**

**L’applicazione si arresta con "Unable to load shared library 'libaspose.slides.drawing.capi…'". Cosa manca?**

Su immagini Ubuntu e Debian, il pacchetto `libfontconfig1`; il messaggio elenca `libfontconfig.so.1` come il file che non è stato possibile aprire. Su Alpine Linux, il messaggio indica che è in uso Aspose.Slides.NET6.CrossPlatform; passa a Aspose.Slides.NET come descritto in [Run on Alpine Linux](#run-on-alpine-linux).

**Perché il testo nel PDF è in un font diverso rispetto a PowerPoint?**

I font usati dalla presentazione non sono installati nell’immagine, quindi Aspose.Slides disegna il testo con un font sostitutivo. L’output dell’applicazione indica ciascun font sostituito. [Deploy Fonts](/slides/it/net/deploy-fonts/) spiega come installare i font nell’immagine o caricarli dalla cartella dell’applicazione.

**È necessario avere l’Sdk .NET sulla mia macchina?**

No. La fase di build compila l’applicazione all’interno dell’immagine SDK. Hai bisogno dell’Sdk solo se vuoi anche compilare ed eseguire l’applicazione al di fuori di Docker; vedi [Installation](/slides/it/net/installation/).