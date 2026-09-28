---
title: Schriftarten für Aspose.Slides auf Linux und in Docker bereitstellen
linktitle: Schriftarten bereitstellen
type: docs
weight: 145
url: /de/net/deploy-fonts/
keywords:
- Schriftarten bereitstellen
- Schriftarten installieren
- Schriftarten in Docker
- Schriftarten auf Linux
- fehlende Schriftarten
- Schriftartersatz
- Microsoft Kernschriftarten
- ttf-mscorefonts-installer
- benutzerdefinierte Schriftarten
- Standardschriftart
- Server
- Container
- PDF-Konvertierung
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Schriftarten für Aspose.Slides für .NET auf Linux-Servern und in Docker-Containern bereitstellen: prüfen, welche Schriftarten ersetzt werden, Schriftpakete auf Debian, Ubuntu und Alpine installieren, eigene Schriftdateien hinzufügen und eine Standardschriftart festlegen."
---
## **Übersicht**

Aspose.Slides zeichnet Text mit den verfügbaren Schriftarten, wenn es eine Präsentation rendert, zum Beispiel beim Konvertieren von Folien zu PDF oder zu Bildern. Auf einem Windows‑Desktop sind die Schriftarten, die Präsentationen verwenden, in der Regel vorhanden. Linux‑Server und Container besitzen meist wenige oder keine Schriftarten, sodass Aspose.Slides den Text mit einer Ersatzschriftart zeichnet. Eine Ersatzschriftart hat andere Buchstabenformen und Breiten, sodass Zeilen anders umbrechen können und Text seine Form überschreiten kann; Zeichen, die der Ersatzschriftart fehlen, werden nicht korrekt dargestellt. Wird überhaupt keine Schriftart installiert, bricht die Konvertierung mit einem Fehler ab.

Dieser Artikel zeigt, wie Sie prüfen, welche Schriftarten Aspose.Slides ersetzt, wie Sie Schriftarten unter Debian, Ubuntu und Alpine Linux installieren, wie Sie eigene Schriftdateien hinzufügen und wie Sie die Schriftart festlegen, die verwendet wird, wenn eine Schriftart fehlt. Die Beispiele laufen in Docker auf den offiziellen .NET‑Images, wie in [Run Aspose.Slides for .NET in Docker](/slides/de/net/how-to-run-aspose-slides-in-docker/). Die Paketbefehle sind Dockerfile‑Anweisungen; auf einem Linux‑Server führen Sie dieselben Befehle als root aus.

Für die Schrift‑API selbst, etwa zum Einbetten von Schriftarten in eine Präsentation und zu Fallback‑ und Ersetzungsregeln, siehe [PowerPoint Fonts](/slides/de/net/powerpoint-fonts/).

## **Prüfen, welche Schriftarten ersetzt werden**

Die folgende Konsolenanwendung gibt die Schriftarten aus, die Aspose.Slides in der aktuellen Umgebung ersetzt. Erstellen Sie einen Ordner namens *FontCheck* und fügen Sie die untenstehenden Dateien hinzu.

*FontCheck.csproj* verweist auf [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), das Paket für Debian und Ubuntu. Es kopiert außerdem die Dateien eines optionalen *fonts*-Ordners in die Anwendungs‑Ausgabe; den Abschnitt [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) nutzt dies.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* fügt pro Schriftartnamen ein Textfeld zu einer Folie hinzu und weist die Schriftart über die [LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/)-Eigenschaft zu. Die Schriftartnamen werden über die Befehlszeile übergeben; ohne Argumente prüft die Anwendung Calibri, Arial und Times New Roman. Sie gibt die Ordner aus, in denen Aspose.Slides nach Schriftarten sucht ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)), rendert die Folie nach *output/fonts.pdf* und gibt die von [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) gemeldeten Ersetzungen aus. Die beiden optionalen Schritte zu Beginn, das Laden eines *fonts*-Ordners und das Auslesen einer `DEFAULT_FONT`‑Variablen, werden später in diesem Artikel erläutert.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// Die zu prüfenden Schriftarten: die Befehlszeilenargumente oder drei gängige Office-Schriftarten.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Lade die Schriftdateien aus dem fonts-Ordner neben der Anwendung, falls vorhanden.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Verwende die im Umgebungsvariable DEFAULT_FONT angegebene Schriftart, sofern gesetzt, für Text, dessen Schriftart fehlt.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* hält lokale Build‑Ergebnisse aus dem Build‑Kontext fern:

```text
bin/
obj/
output/
```

*Dockerfile* baut die Anwendung mit dem .NET‑SDK‑Image und führt sie im .NET‑Runtime‑Image aus. Die Runtime‑Stufe installiert `libfontconfig1`, das Aspose.Slides.NET6.CrossPlatform benötigt, sowie die DejaVu‑Schriften. [Run Aspose.Slides for .NET in Docker](/slides/de/net/how-to-run-aspose-slides-in-docker/) erklärt jede Anweisung.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Image bauen und die Prüfung ausführen:

```bash
docker build -t font-check .
docker run --rm font-check
```

Das Image enthält nur die DejaVu‑Schriften, sodass alle drei Schriftarten durch DejaVu Sans ersetzt werden:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Um die Schriftarten Ihrer eigenen Präsentationen zu prüfen, übergeben Sie deren Namen als Argumente, zum Beispiel `docker run --rm font-check "Segoe UI" Consolas`. Um *output/fonts.pdf* aus dem Container zu kopieren, verwenden Sie die Befehle unter [Copy the Output to Your Machine](/slides/de/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Schriftarten auf Debian und Ubuntu installieren**

### **Microsoft Core Fonts**

Das Paket `ttf-mscorefonts-installer` lädt Microsofts Kernschriftarten für das Web herunter und installiert sie, darunter Arial, Times New Roman, Courier New, Verdana, Georgia und Trebuchet MS. Die Schriftarten unterliegen der Endbenutzer‑Lizenzvereinbarung (EULA) von Microsoft, und das Paket installiert sie nur, nachdem die EULA akzeptiert wurde. Ein Docker‑Build kann die Eingabeaufforderung nicht beantworten, daher lehnt der Installer die EULA ab und installiert keine Schriftarten, während `apt-get install` dennoch Erfolg meldet. Akzeptieren Sie die EULA mit `debconf-set-selections` **vor** der Installation des Pakets.

Im *Dockerfile* ersetzen Sie die `RUN`‑Anweisung, die die Pakete in der Runtime‑Stufe installiert, durch:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Image bauen und die Prüfung erneut mit denselben beiden Befehlen ausführen. Arial und Times New Roman sind jetzt installiert:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, die Standardschriftart einer von Aspose.Slides erstellten Präsentation, gehört nicht zu den Kernschriftarten und wird weiterhin ersetzt. Siehe [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Unter Debian befindet sich das Paket im Repository‑Komponent `contrib`, den die Debian‑Images nicht aktivieren; die Standard‑.NET 8‑ und .NET 9‑Images basieren auf Debian 12. Aktivieren Sie `contrib` in derselben Anweisung:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Die auf Ubuntu basierenden .NET 10‑Images aktivieren bereits `multiverse`, die Ubuntu‑Komponente, die das Paket enthält.

### **Weitere Schriftpakete**

Debian und Ubuntu paketieren außerdem frei lizensierte Schriftarten, zum Beispiel:

| Paket | Schriftarten |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif und Mono, mit denselben Metriken wie Arial, Times New Roman und Courier New |
| `fonts-crosextra-carlito` | Carlito, mit denselben Metriken wie Calibri |
| `fonts-crosextra-caladea` | Caladea, mit denselben Metriken wie Cambria |

Installieren Sie sie mit `apt-get install` in derselben `RUN`‑Anweisung. Aspose.Slides.NET6.CrossPlatform nutzt die Font‑Aliases der Linux‑Schriftkonfiguration nicht: Bei installierten `fonts-liberation` wird Text in Arial weiterhin mit der allgemeinen Ersatzschriftart gezeichnet, nicht mit Liberation Sans. Um eine metrisch kompatible Schriftart anstelle einer fehlenden zu verwenden, setzen Sie sie als [default font](#set-a-default-font-for-missing-fonts) oder fügen Sie eine [font substitution rule](/slides/de/net/font-substitution/) hinzu.

## **Eigene Schriftdateien hinzufügen**

Schriftarten, die von den Distributionen nicht bereitgestellt werden, etwa unternehmensinterne Schriftarten oder andere, für die Sie eine Lizenz zur Nutzung auf dem Server besitzen, können als Schriftdateien hinzugefügt werden. Legen Sie die Schriftdateien, zum Beispiel *.ttf*-Dateien, in einen Ordner namens *fonts* innerhalb des *FontCheck*-Ordners. Die Beispiele unten verwenden die Dateien von Carlito, einer Schriftart mit denselben Metriken wie Calibri, die Sie von [Google Fonts](https://fonts.google.com/specimen/Carlito) herunterladen können.

### **Schriftarten in einem System‑Schriftordner installieren**

Aspose.Slides liest die Schriftarten aus den in der Zeile `Font folders` ausgegebenen Ordnern. Um Ihre Schriftarten für jede Anwendung im Image zu installieren, kopieren Sie sie nach */usr/local/share/fonts*, dem Ordner für lokal installierte Schriftarten. Fügen Sie diese Anweisung zur Runtime‑Stufe des *Dockerfile* nach der `RUN`‑Anweisung, die die Pakete installiert, hinzu:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Schriftarten aus dem Anwendungsordner laden**

Statt die Schriftarten im Image zu installieren, können Sie sie mit der Anwendung ausliefern und über [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) laden. Die Schriftarten stehen dann nur Aspose.Slides zur Verfügung und werden zusammen mit der Anwendung bereitgestellt. *FontCheck* macht das: *FontCheck.csproj* kopiert den *fonts*-Ordner in die Anwendungs‑Ausgabe, und *Program.cs* übergibt diesen Ordner an `LoadExternalFonts`, bevor die Präsentation erstellt wird. [Custom Font](/slides/de/net/custom-font/) beschreibt weitere Möglichkeiten, Schriftarten bereitzustellen, etwa das Laden aus dem Speicher.

Re‑bauen Sie das Image und prüfen Sie Calibri und Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Der Anwendungsordner erscheint nun unter den Schriftordnern und Carlito wird nicht mehr ersetzt:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Standard‑Schriftart für fehlende Schriftarten festlegen**

Fehlt eine Schriftart, verwendet Aspose.Slides eine von ihm gewählte Ersatzschriftart. Um diese selbst zu bestimmen, setzen Sie die [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/)-Eigenschaft von [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) und übergeben Sie die Optionen an den [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)-Konstruktor. *FontCheck* liest den Schriftartnamen aus der Umgebungsvariablen `DEFAULT_FONT`. Mit geladenem Carlito verwenden Sie es für fehlende Schriftarten:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri wird nun mit Carlito gezeichnet, dessen Zeichen dieselben Breiten wie Calibri haben, sodass der Text seine Zeilenumbrüche beibehält:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Die Standardschriftart ersetzt jede fehlende Schriftart. Um einzelne Schriftarten zuzuordnen, etwa Arial zu Liberation Sans und Calibri zu Carlito, verwenden Sie [font substitution rules](/slides/de/net/font-substitution/). Regeln ändern die gerenderte Ausgabe, aber `GetSubstitutions` spiegelt sie nicht wider; prüfen Sie daher die Schriftarten in der Ausgabedatei. Für asiatischen Text setzen Sie zusätzlich [DefaultAsianFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultasianfont/); siehe [Default Font](/slides/de/net/default-font/).

## **Schriftarten auf Alpine Linux installieren**

Unter Alpine Linux verwenden Sie das Aspose.Slides.NET‑Paket; [Run on Alpine Linux](/slides/de/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) listet die Änderungen am Projekt auf. Nehmen Sie dieselben Änderungen an *FontCheck* vor: ersetzen Sie den Paketverweis, fügen Sie die `SetSwitch`‑Anweisung zu *Program.cs* hinzu und verwenden Sie diese Runtime‑Stufe, die ebenfalls die Microsoft‑Core‑Fonts installiert:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` lädt dieselben Microsoft‑Core‑Fonts wie das Debian‑ und Ubuntu‑Paket herunter und installiert sie; deren EULA gilt in gleicher Weise. `fc-cache` aktualisiert den Schrift‑Cache.

Mit Aspose.Slides.NET unter Linux wählt die Schriftkonfigurations‑Bibliothek (fontconfig) den Ersatz für eine fehlende Schriftart, und `GetSubstitutions` meldet ihn nicht, sodass *FontCheck* `No font substitutions.` ausgibt. Um zu sehen, welche Schriftart für einen Schriftartnamen verwendet wird, fragen Sie fontconfig im Container ab:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Nach Installation der Microsoft‑Core‑Fonts wird Arial für Arial verwendet:

```text
Arial.ttf: "Arial" "Regular"
```

Ohne sie, wenn die `RUN`‑Anweisung nur `icu-libs libgdiplus font-dejavu` installiert, gibt derselbe Befehl aus:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**Warum sieht eine Präsentation auf einem Server nach der Konvertierung anders aus?**

Der Server verfügt nicht über die Schriftarten, die die Präsentation verwendet, sodass Aspose.Slides den Text mit einer Ersatzschriftart zeichnet, deren Buchstaben andere Breiten haben. Führen Sie *FontCheck* mit den Schriftartnamen der Präsentation aus, um zu sehen, welche Schriftarten ersetzt werden, und installieren Sie diese oder laden Sie sie aus dem Anwendungsordner.

**Das Build hat ttf-mscorefonts-installer installiert, aber Arial wird weiterhin ersetzt. Warum?**

Die EULA wurde nicht akzeptiert, bevor das Paket installiert wurde, sodass der Installer die Schriftarten übersprungen hat. Fügen Sie den `debconf-set-selections`‑Befehl vor `apt-get install` ein, wie in [Microsoft Core Fonts](#microsoft-core-fonts) gezeigt, und bauen Sie das Image neu.

**Muss der Computer, der das PDF öffnet, die Schriftarten besitzen?**

Nein. In diesen Beispielen enthält das PDF die Schriftarten, die zum Zeichnen des Textes verwendet wurden, sodass es auf jedem Computer gleich aussieht. Die Schriftarten werden nur dort benötigt, wo Aspose.Slides die Präsentation rendert.