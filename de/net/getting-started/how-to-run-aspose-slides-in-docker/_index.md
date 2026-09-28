---
title: Aspose.Slides für .NET in Docker ausführen
linktitle: Docker
type: docs
weight: 140
url: /de/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker-Container
- Multi-Stage-Build
- Container-Image
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- Schriften
- PDF-Konvertierung
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen und führen Sie eine Aspose.Slides‑Konsolenanwendung für .NET in Docker aus: ein Multi‑Stage‑Dockerfile auf den offiziellen .NET‑Images, die benötigten Linux‑Bibliotheken und Schriften und wie Sie die erzeugten Dateien auf Ihren Rechner kopieren."
---
## **Übersicht**

Dieser Artikel zeigt, wie Aspose.Slides für .NET in einem Docker‑Container ausgeführt wird. Sie erstellen eine kleine Konsolenanwendung, die eine Präsentation mit einem Textfeld erzeugt und in PDF konvertiert, packen sie mit einem Multi‑Stage‑Dockerfile auf den offiziellen .NET‑Images von Microsoft, führen sie aus und kopieren die erzeugten Dateien auf Ihre Maschine. Der Artikel listet außerdem die Linux‑Bibliotheken und Schriften auf, die Aspose.Slides im Container benötigt, und endet mit einer Variante für Alpine Linux.

Sie benötigen lediglich Docker auf Ihrer Maschine. Das .NET‑SDK ist Teil des Build‑Images, sodass Sie es nicht installieren müssen. Zum Installieren von Docker siehe [Docker erhalten](https://docs.docker.com/get-started/get-docker/).

## **Paket und Basis‑Image wählen**

Die Standard‑.NET 10‑Container‑Images basieren auf Ubuntu 24.04. Verwenden Sie auf diesen Images das Paket [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Es benötigt die Bibliothek `fontconfig`, und das .NET‑Runtime‑Image enthält weder diese Bibliothek noch irgendwelche Schriften, sodass das Dockerfile in diesem Artikel beide installiert.

Aspose.Slides.NET6.CrossPlatform läuft nicht auf Alpine Linux. Für Alpine‑basierte Images verwenden Sie das Paket [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) mit `libgdiplus`, wie in [Auf Alpine Linux ausführen](#run-on-alpine-linux) beschrieben. [Installation](/slides/de/net/installation/) vergleicht die beiden Pakete.

## **Projekt erstellen**

Erstellen Sie einen Ordner namens *HelloSlidesDocker* und fügen Sie die folgenden drei Dateien hinzu.

*HelloSlidesDocker.csproj* beschreibt eine Konsolenanwendung für .NET 10, die Version der unten verwendeten Container‑Images und referenziert Aspose.Slides.NET6.CrossPlatform. Setzen Sie die Paketversion auf die neueste, die auf [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) aufgeführt ist.

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

*Program.cs* erstellt eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), fügt der ersten Folie ein Rechteck mit Text hinzu und speichert die Präsentation zweimal mit der [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)-Methode: als PPTX und als PDF. Beide Dateien werden im Ordner *output* unter dem Arbeitsverzeichnis abgelegt. Die Anwendung listet anschließend die Schriften auf, die während der PDF‑Erstellung ersetzt wurden, mithilfe von [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/), sodass Sie sehen können, ob der Container die in der Präsentation verwendeten Schriften enthält.

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

*.dockerignore* hält die *bin*‑ und *obj*‑Ordner eines lokalen Builds sowie die Ausgaben vorheriger Durchläufe aus dem Docker‑Build‑Kontext fern, sodass das Image nur aus den Quelldateien gebaut wird.

```text
bin/
obj/
output/
```

## **Dockerfile schreiben**

Fügen Sie eine Datei namens *Dockerfile* zum selben Ordner hinzu:

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

Die Datei hat zwei Stufen:

- **Die Build‑Stufe** startet vom .NET‑SDK‑Image. Sie kopiert zuerst die Projektdatei und stellt die NuGet‑Pakete wieder her, sodass Docker diese Ebene wiederverwendet, solange sich die Projektdatei nicht ändert. Anschließend kopiert sie den Quellcode und veröffentlicht die Anwendung nach */app*.
- **Die Runtime‑Stufe** startet vom kleineren .NET‑Runtime‑Image, das kein SDK enthält, und kopiert nur die veröffentlichte Anwendung hinein. Sie installiert zwei Pakete:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform lädt diese Bibliothek beim Start. Ohne sie bricht die Anwendung mit einer `DllNotFoundException` ab, die `libfontconfig.so.1` nennt.
  - `fonts-dejavu-core`: Das Runtime‑Image enthält keine Schriften, und Aspose.Slides benötigt mindestens eine installierte Schrift, um Text zu zeichnen; ohne Schrift bricht die Konvertierung mit `InvalidOperationException: Cannot find any fonts installed on the system.` ab. Text in nicht installierten Schriften wird mit einer Ersatzschrift gezeichnet. Die DejaVu‑Schriften sind ein kleiner Satz, der Text rendern lässt; um Präsentationen mit den originären Schriften zu rendern, siehe [Schriften bereitstellen](/slides/de/net/deploy-fonts/).

  `--no-install-recommends` und das Entfernen der Paketlisten halten das Image klein. Die letzten Zeilen erzeugen den *output*‑Ordner, geben ihn an den nicht‑root‑Benutzer `app` weiter (dessen Benutzer‑ID in der Variable `APP_UID` liegt) und führen die Anwendung als dieser Benutzer aus.

Für eine ASP.NET‑Core‑Anwendung starten Sie die Runtime‑Stufe stattdessen von `mcr.microsoft.com/dotnet/aspnet:10.0`. Dieses basiert auf demselben Ubuntu‑Image, sodass dieselben Pakete benötigt werden.

## **Container bauen und ausführen**

Öffnen Sie ein Terminal im *HelloSlidesDocker*‑Ordner. Bauen Sie das Image und führen Sie anschließend einen Container daraus aus:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Der erste Build lädt die Basis‑Images und die NuGet‑Pakete herunter, weshalb er länger dauert als nachfolgende Builds. Der Container führt die Anwendung aus und stoppt. Er gibt Folgendes aus:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Die erste Zeile zeigt, dass der Text Calibri verwendet, die Standardschrift einer neuen Präsentation, und dass Calibri im Image nicht installiert ist, sodass Aspose.Slides den Text mit DejaVu Sans gezeichnet hat. Der Text im PDF ist echter, auswählbarer Text in dieser Schrift. Ohne Lizenz fügt Aspose.Slides zudem ein Evaluations‑Watermark zu jeder gespeicherten Folie hinzu; siehe [Lizenzierung](/slides/de/net/licensing/).

## **Ausgabe auf Ihre Maschine kopieren**

Die Dateien befinden sich im */app/output*‑Ordner des gestoppten Containers. Kopieren Sie sie in einen *output*‑Ordner auf Ihrer Maschine und entfernen Sie anschließend den Container:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Diese beiden Befehle funktionieren gleich in Bash, PowerShell und der Windows Eingabeaufforderung.

Unter Linux können Sie stattdessen einen Ordner Ihrer Maschine in den Container einbinden, sodass die Anwendung ihre Dateien dort direkt schreibt:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Die Option `--user` führt die Anwendung mit Ihren Benutzer‑ und Gruppen‑IDs aus, sodass sie in den von Ihnen erstellten Ordner schreiben kann und die Dateien Ihnen gehören. `--rm` entfernt den Container, wenn er stoppt.

## **Auf Alpine Linux ausführen**

Um die Anwendung in einem Alpine‑basierten Image auszuführen, wechseln Sie zum Paket Aspose.Slides.NET und ändern Sie die Runtime‑Stufe. Die Build‑Stufe bleibt unverändert.

1. Ersetzen Sie in *HelloSlidesDocker.csproj* die Paketreferenz:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. Fügen Sie in *Program.cs* nach den `using`‑Direktiven, vor dem ersten Aspose.Slides‑Aufruf, folgende Anweisung ein. Sie aktiviert die System.Drawing‑Unterstützung für Linux, die Aspose.Slides.NET nutzt:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. Ersetzen Sie in *Dockerfile* die Runtime‑Stufe (alles ab der zweiten `FROM`‑Zeile) durch:

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

Die Alpine‑Stufe installiert drei Pakete und ändert eine Einstellung:

- `libgdiplus` ist die Grafik‑Bibliothek, die Aspose.Slides.NET unter Linux verwendet.
- `font-dejavu` stellt Schriften bereit. Ohne Schrift bricht die Konvertierung mit `System.ArgumentException: Font '?' cannot be found` ab.
- `icu-libs` und `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` liefern Kultur‑Daten. Die Alpine‑.NET‑Images laufen standardmäßig im globalisierungs‑invarianten Modus, und in diesem Modus bricht Aspose.Slides mit einer `CultureNotFoundException` für `en-US` ab.

Bauen, führen Sie aus und kopieren Sie die Ausgabe mit denselben Befehlen wie oben. Auf diesem Image gibt die Anwendung nur die `Saved`‑Zeile aus: Mit Aspose.Slides.NET unter Linux wählt fontconfig den Ersatz für eine fehlende Schrift, und [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) listet ihn nicht auf. [Schriften bereitstellen](/slides/de/net/deploy-fonts/) zeigt, wie Sie prüfen, welche Schrift verwendet wurde.

## **FAQ**

**Die Anwendung beendet sich mit “Unable to load shared library 'libaspose.slides.drawing.capi…'”. Was fehlt?**

Auf Ubuntu‑ und Debian‑Images das Paket `libfontconfig1`; die Meldung nennt `libfontconfig.so.1` als nicht zu öffnende Datei. Auf Alpine Linux bedeutet die Meldung, dass Aspose.Slides.NET6.CrossPlatform verwendet wird; wechseln Sie zu Aspose.Slides.NET wie in [Auf Alpine Linux ausführen](#run-on-alpine-linux) beschrieben.

**Warum ist die Schrift im PDF anders als in PowerPoint?**

Die in der Präsentation genutzten Schriften sind im Image nicht installiert, sodass Aspose.Slides den Text mit einer Ersatzschrift zeichnet. Die Ausgabe der Anwendung nennt jede ersetzte Schrift. [Schriften bereitstellen](/slides/de/net/deploy-fonts/) erklärt, wie Sie Schriften im Image installieren oder aus dem Anwendungsordner laden.

**Benötige ich das .NET‑SDK auf meiner Maschine?**

Nein. Die Build‑Stufe kompiliert die Anwendung innerhalb des SDK‑Images. Das SDK benötigen Sie nur, wenn Sie die Anwendung außerhalb von Docker bauen und ausführen wollen; siehe [Installation](/slides/de/net/installation/).