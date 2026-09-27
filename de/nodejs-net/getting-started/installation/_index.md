---
title: Installation
type: docs
weight: 70
url: /de/nodejs-net/installation/
keywords:
- Aspose.Slides herunterladen
- Aspose.Slides installieren
- Aspose.Slides-Installation
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Installieren Sie Aspose.Slides für Node.js via .NET aus npm unter Windows oder Linux: Voraussetzungen, die edge-js-Überschreibung, eine einmalige NuGet-Wiederherstellung und ein erstes Programm, das eine Präsentation erstellt."
---
## **Übersicht**

Aspose.Slides for Node.js via .NET ist das npm‑Paket `aspose.slides.via.net`. Es führt die Aspose.Slides .NET‑Bibliothek innerhalb von Node.js über die [edge-js](https://github.com/agracio/edge-js)‑Brücke aus, sodass eine funktionierende Installation sowohl Node.js als auch .NET erfordert.

Dieser Artikel führt Sie von einer frischen Maschine zu einem ersten Programm, das eine Präsentation erstellt. Es gibt vier Schritte: Erstellen eines Projekts mit einer edge‑js‑Überschreibung, Installieren des Pakets aus npm, Wiederherstellen der .NET‑Abhängigkeiten des Pakets einmalig und Ausführen Ihres Skripts aus dem Projektordner.

## **Voraussetzungen**

- **Node.js 22 oder 24 LTS**, x64‑Build, von [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 oder neuer**, von [dotnet.microsoft.com](https://dotnet.microsoft.com/download). Die reine .NET‑Runtime reicht nicht aus: Der Wiederherstellungsschritt unten benötigt das SDK, ebenso die Brücke, wenn Ihr Skript läuft. Führen Sie `dotnet --list-sdks` aus, um zu prüfen, welche SDKs installiert sind.
- **Nur unter Linux**:
  - die Build‑Tools `python3`, `make` und `g++`, weil npm edge‑js während der Installation unter Linux kompiliert;
  - die Bibliothek **fontconfig**, die die native Zeichenbibliothek von Aspose.Slides lädt.

  Auf Debian sind das die Pakete `python3`, `make`, `g++` und `libfontconfig1`.

Die Schritte in diesem Artikel wurden auf folgenden Plattformen geprüft:

| Plattform | Ergebnis |
|---|---|
| Windows x64 mit Node.js 22 oder 24 | Funktioniert. Getestet mit installiertem Microsoft Visual C++ Redistributable. |
| Linux x64 mit Node.js 22 oder 24, bei dem das System‑OpenSSL aus derselben Release‑Serie stammt wie das in Node.js integrierte OpenSSL, z. B. Debian 13 | Funktioniert. |
| Linux, bei dem die beiden OpenSSL‑Versionen unterschiedlich sind, z. B. Debian 12 | Node.js stürzt mit einem Segmentation Fault ab, wenn eine Präsentation erstellt wird. |
| macOS | Nicht verifiziert. |

Unter Linux vergleichen Sie die beiden Versionen, bevor Sie starten. Der erste Befehl gibt die in Node.js integrierte OpenSSL‑Version aus; der zweite die System‑Version. Verwenden Sie ein System, bei dem beide mit denselben Haupt‑ und Nebenzahlen beginnen, z. B. `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Falls der Befehl `openssl` nicht gefunden wird, installieren Sie zuerst das Paket `openssl`.

## **Projekt erstellen**

Erstellen Sie einen Ordner für Ihr Projekt, initialisieren Sie ihn und fügen Sie eine Überschreibung hinzu, die npm mitteilt, welche edge‑js‑Version installiert werden soll:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Das Paket verlangt eine ältere edge‑js‑Version, deren vorgefertigte Windows‑Binärdateien nur bis Node.js 20 reichen. Ohne die Überschreibung schlägt das erste Skript unter Windows mit der Meldung „The edge module has not been pre-compiled for node.js version“ fehl. Der Befehl schreibt die Überschreibung in den Abschnitt `overrides` von `package.json`; fügen Sie sie hinzu, bevor Sie das Paket installieren.

## **Paket installieren**

Installieren Sie Aspose.Slides for Node.js via .NET aus npm:

```sh
npm install aspose.slides.via.net
```

Während der Installation kopiert das Paket seine nativen Zeichenbibliotheken (die Dateien, deren Namen `aspose.slides.drawing.capi` enthalten) in den Projektordner, neben `package.json`.

Das Paket wird außerdem als ZIP‑Archiv auf [releases.aspose.com](https://releases.aspose.com/slides/de/nodejs-net/) veröffentlicht. Dieser Artikel behandelt ausschließlich die Installation aus npm.

## **.NET‑Abhängigkeiten wiederherstellen**

Das Paket enthält die Aspose.Slides‑.NET‑Assemblies, jedoch nicht die 20 NuGet‑Pakete, von denen diese Assemblies abhängen. Zur Laufzeit sucht .NET sie im NuGet‑Paketcache: `%USERPROFILE%\.nuget\packages` unter Windows, `~/.nuget/packages` unter Linux oder im Ordner, der in der Umgebungsvariable `NUGET_PACKAGES` festgelegt ist. Fehlen sie, bricht das erste Skript mit „assembly specified in the dependencies manifest was not found“ ab.

Um den Cache zu füllen, erstellen Sie im Projektordner einen Ordner namens `deps` und speichern dort die folgende Datei als `deps.csproj`. Jeder `PackageDownload`‑Eintrag lädt ein Paket in der exakt angegebenen Version; es wird nichts gebaut.

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

Stellen Sie es dann aus dem Projektordner wieder her:

```sh
dotnet restore deps/deps.csproj
```

Sie benötigen diesen Schritt einmal pro Maschine, nicht einmal pro Projekt: Die Pakete bleiben im NuGet‑Cache, und spätere Projekte auf derselben Maschine nutzen sie. Nach der Wiederherstellung können Sie den Ordner `deps` löschen.

## **Erstes Programm ausführen**

Erstellen Sie im Projektordner eine Datei namens `hello.js` mit dem folgenden Code. Sie erstellt eine Präsentation, fügt dem ersten Folienbereich ein Rechteck mit dem Text „Hello, World!“ hinzu und speichert das Ergebnis als `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Eine neue Präsentation enthält eine leere Folie.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Position und Größe sind in Punkten (1/72 Zoll): x, y, Breite, Höhe.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Geben Sie das .NET-Objekt frei, das der Präsentation zugrunde liegt.
    presentation.dispose();
}
```

Führen Sie es aus dem Projektordner aus:

```sh
node hello.js
```

Das Skript gibt `Saved hello.pptx` aus. Öffnen Sie `hello.pptx`, um eine Folie mit einem gefüllten Rechteck zu sehen, das den Text enthält. Ohne Lizenz fügt Aspose.Slides zudem ein Evaluations‑Wasserzeichen hinzu; siehe [Evaluate Aspose.Slides](/slides/de/nodejs-net/evaluate-aspose-slides/) und [Licensing](/slides/de/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Führen Sie Ihre Skripte aus dem Projektordner aus, also jenem, der `package.json` enthält. Relative Pfade wie `hello.pptx` werden relativ zum aktuellen Ordner aufgelöst, und auf manchen Maschinen kann ein Skript, das aus einem anderen Ordner gestartet wird, keine Präsentation erstellen.
{{% /alert %}}

Die JavaScript‑API spiegelt Aspose.Slides für .NET wider: Klassen behalten ihre .NET‑Namen, Eigenschaften und Methoden verwenden camelCase (`Slides` wird zu `slides`, `AddAutoShape` zu `addAutoShape`), und Sammlungs­elemente werden mit `get(index)` gelesen. Es gibt keine separate API‑Referenz für dieses Paket, daher verwenden Sie die [Aspose.Slides für .NET API‑Referenz](https://reference.aspose.com/slides/de/net/) für Klassen‑ und Member‑Details, z. B. [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/) und [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/shapecollection/addautoshape/).

## **FAQ**

**Was bedeutet „The edge module has not been pre-compiled for node.js version“?**

npm hat die ältere edge‑js‑Version installiert, die das Paket verlangt. Fügen Sie die Überschreibung aus [Projekt erstellen](#projekt-erstellen) hinzu und führen Sie `npm install` erneut aus.

**Was bedeutet „assembly specified in the dependencies manifest was not found“?**

Die .NET‑Abhängigkeiten befinden sich nicht im NuGet‑Cache. Der gleiche Lauf meldet zudem „edge.initializeClrFunc is not a function“. Folgen Sie [.NET‑Abhängigkeiten wiederherstellen](#net-abhängigkeiten-wiederherstellen) einmal, dann führen Sie Ihr Skript erneut aus.

**Was bedeutet „The edge native module is not available“ unter Linux?**

edge‑js wurde während `npm install` nicht kompiliert, weil z. B. `python3`, `make` oder `g++` fehlten. npm meldet das nicht als Fehler. Installieren Sie die Build‑Tools und führen Sie anschließend `npm rebuild edge-js` im Projektordner aus.

**Warum schlägt das Erstellen einer Präsentation mit einer leeren „Error“‑Meldung fehl?**

Unter Linux prüfen Sie, ob die Bibliothek **fontconfig** installiert ist (`libfontconfig1` auf Debian); ohne sie kann die native Zeichenbibliothek nicht geladen werden. Auf jedem System prüfen Sie außerdem, dass Sie das Skript aus dem Projektordner starten.

**Warum stürzt Node.js unter Linux mit einem Segmentation Fault?**

System‑OpenSSL und das in Node.js integrierte OpenSSL stammen aus unterschiedlichen Release‑Linien. Vergleichen Sie sie wie in [Voraussetzungen](#voraussetzungen) gezeigt und verwenden Sie eine Distribution oder einen Node.js‑Build, bei dem sie übereinstimmen.

**Muss ich die NuGet‑Wiederherstellung für jedes Projekt wiederholen?**

Nein. Die Wiederherstellung füllt den NuGet‑Cache für Ihr Benutzerkonto, und jedes Projekt auf dieser Maschine verwendet denselben Cache.