---
title: Systemanforderungen
type: docs
weight: 60
url: /de/net/system-requirements/
keywords:
- Systemanforderungen
- unterstützte Plattformen
- Ziel-Frameworks
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Überprüfen Sie, was Aspose.Slides für .NET vor der Installation benötigt: die Ziel-Frameworks jedes NuGet-Pakets, die unterstützten Betriebssysteme und Prozessoren sowie die Bibliotheken und Schriftarten, die Linux erfordert."
---
## **Einführung**

Aspose.Slides for .NET ist eine eigenständige Bibliothek: sie benötigt weder Microsoft PowerPoint noch Microsoft Office. Sie wird als zwei NuGet‑Pakete veröffentlicht, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) und [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Beide stellen die gleichen Aspose.Slides‑Namensräume und Klassen bereit; sie unterscheiden sich in den Ziel‑Frameworks und in der Art, wie sie Folien zeichnen, was bestimmt, wo sie laufen und was sie benötigen.

Dieser Artikel listet die .NET‑Versionen und Plattformen, die jedes Paket unterstützt, sowie die Systembibliotheken und Schriftarten, die Linux benötigt, und endet mit einem kurzen Programm, das Ihre Umgebung prüft. Zum Hinzufügen eines Pakets zu einem Projekt siehe [Installation](/slides/de/net/installation/).

## **Unterstützte .NET‑Versionen**

Jedes Paket enthält pro Ziel‑Framework einen Build von Aspose.Slides, und NuGet wählt den Build aus, der zum Ziel‑Framework Ihres Projekts passt.

| Paket | Ziel‑Frameworks im Paket | Ihr Projekt kann zielen auf |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 oder höher; .NET 6 oder höher, einschließlich .NET 8, .NET 9 und .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 oder höher, einschließlich .NET 8, .NET 9 und .NET 10 |

Der `netstandard2.0`‑Build ermöglicht es einer .NET Standard 2.0 Klassenbibliothek, Aspose.Slides.NET zu referenzieren. Eine Anwendung, die eine solche Bibliothek verwendet, führt den Build aus, der zum eigenen Ziel‑Framework der Anwendung passt: Eine .NET 8‑Anwendung verwendet beispielsweise den `net6.0`‑Build.

## **Unterstützte Betriebssysteme und Prozessoren**

**Aspose.Slides.NET** enthält nur prozessorunabhängigen (AnyCPU) verwalteten Code, daher läuft es auf der Prozessorarchitektur der .NET‑Runtime, die es lädt. Es zeichnet Folien über die Microsoft‑Bibliothek System.Drawing.Common, die Microsoft [nur unter Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only) unterstützt. Unter Linux benötigt Aspose.Slides.NET daher die Bibliothek `libgdiplus` und einen Start‑Switch, beschrieben unter [Linux](#linux). Es läuft auf Linux‑Distributionen, die `libgdiplus` bereitstellen, wie Debian, Ubuntu und Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** zeichnet Folien mit einer eigenen Grafik‑Engine. Die Engine ist eine native Bibliothek, die das Paket in einem Build pro Plattform enthält, sodass das Paket nur auf diesen Plattformen läuft:

| Betriebssystem | Prozessoren | Anmerkungen |
|---|---|---|
| Windows | x86, x64 | Windows auf ARM64 wird nicht unterstützt. |
| Linux | x64, ARM64 | Benötigt glibc 2.23 oder neuer auf x64 und glibc 2.39 oder neuer auf ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform läuft nicht auf Alpine Linux oder anderen Distributionen, die auf musl statt glibc basieren, oder auf Distributionen mit einer älteren glibc, wie z. B. CentOS 7. Verwenden Sie in solchen Systemen Aspose.Slides.NET.

Unter Windows nutzt die native Bibliothek von Aspose.Slides.NET6.CrossPlatform die Microsoft Visual C++‑Runtime (*MSVCP140.dll* und *VCRUNTIME140.dll*, plus *VCRUNTIME140_1.dll* auf x64). Wenn diese Dateien auf dem Zielrechner fehlen, installieren Sie das [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Beide Pakete benötigen unter Linux zusätzliche Systembibliotheken. Ohne diese schlägt das erste Beispiel in [Create Presentations](/slides/de/net/create-presentation/) mit einer Ausnahme fehl, anstatt die Datei zu speichern. Die nachstehenden Befehle gelten für Debian und Ubuntu; auf diesen Distributionen bringt jede Bibliothek auch die DejaVu‑Schriftarten (`fonts-dejavu-core`) mit, sodass Text ohne weitere Schriftpakete gerendert wird.

### **Aspose.Slides.NET6.CrossPlatform**

The package's Linux library requires the `fontconfig` library:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Ohne sie schlägt das Erstellen einer [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) mit einer `TypeInitializationException` fehl, deren innere `DllNotFoundException` meldet, dass `libfontconfig.so.1` nicht geöffnet werden kann.

Minimale Basis‑Images enthalten möglicherweise ebenfalls kein `fontconfig`. Das AWS‑Lambda‑Basis‑Image für .NET 8 beispielsweise enthält weder `fontconfig` noch Schriftarten. In einem darauf aufgebauten Container‑Image führen Sie `dnf install -y fontconfig` aus, wodurch auch die Noto‑Sans‑Schriftarten installiert werden.

### **Aspose.Slides.NET**

Das Paket benötigt unter Linux zwei Dinge:

1. Die `libgdiplus`‑Bibliothek:  
   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. Den `System.Drawing.EnableUnixSupport`‑Switch, der am Anfang Ihrer Anwendung vor jedem Aufruf von Aspose.Slides aktiviert wird. In einer *Program.cs* mit Top‑Level‑Statements setzen Sie ihn nach den `using`‑Direktiven:  
   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Ohne `libgdiplus` schlägt das Speichern einer Präsentation mit einer `TypeInitializationException` fehl, deren innere `DllNotFoundException` meldet, dass `libgdiplus` nicht geladen werden kann. Ohne den Switch ist die innere Ausnahme `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
Der Switch funktioniert nur mit System.Drawing.Common 6, der Version, von der Aspose.Slides.NET abhängt. Microsoft hat ihn in System.Drawing.Common 7 entfernt. Wenn Ihr Projekt System.Drawing.Common 7 oder höher referenziert, sei es direkt oder über ein anderes Paket, schlägt Aspose.Slides.NET unter Linux mit `PlatformNotSupportedException` fehl, selbst wenn `libgdiplus` installiert und der Switch aktiviert ist. Verwenden Sie in diesem Fall Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

Unter Alpine Linux verwenden Sie Aspose.Slides.NET mit dem oben beschriebenen Switch. Alpine‑Images enthalten normalerweise keine Schriftarten, und `libgdiplus` installiert allein keine, daher installieren Sie `libgdiplus` zusammen mit mindestens einem Schriftpaket. Ohne Schriftarten schlägt das Speichern einer Präsentation mit diesem Fehler fehl:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Option 1: DejaVu‑Schriftarten**

Die empfohlene Option ist das Paket `ttf-dejavu`:  
```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

In aktuellen Alpine‑Versionen installiert `ttf-dejavu` das Paket `font-dejavu`, das ebenfalls `fontconfig` und die davon abhängigen Schriftwerkzeuge installiert.

**Option 2: Microsoft‑Core‑Schriftarten**

Wenn Ihre Präsentationen Microsoft‑Schriftarten wie Arial, Times New Roman, Courier New oder Verdana verwenden, installieren Sie stattdessen die Microsoft‑Core‑Schriftarten. Der Schritt `update-ms-fonts` lädt die Schriftarten während des Image‑Baus herunter, sodass der Build Internetzugang benötigt:  
```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Globalization‑Unterstützung**

Beide Pakete benötigen .NET‑Globalisierungssupport, den .NET unter Linux über die ICU‑Bibliotheken bereitstellt. Im [globalization-invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization) schlägt das Erstellen einer [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) mit `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode` fehl.

Einige Container‑Images aktivieren diesen Modus. Die .NET‑Runtime‑Images für Alpine Linux (`runtime-deps`, `runtime` und `aspnet`) setzen beispielsweise `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` und enthalten kein ICU. In einem darauf basierenden Image installieren Sie ICU und deaktivieren den Modus:  
```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Stellen Sie außerdem sicher, dass Ihre Projektdatei die Eigenschaft `InvariantGlobalization` nicht auf `true` setzt.

## **Überprüfen Sie Ihre Umgebung**

Um zu überprüfen, dass ein Paket und seine Voraussetzungen vorhanden sind, führen Sie ein Programm aus, das eine Präsentation speichert und eine Folie in ein Bild rendert. Das Speichern und Rendern verwenden die Grafikbibliothek und die Schriftarten, die durch die oben genannten Linux‑Voraussetzungen bereitgestellt werden.

Erstellen Sie eine Konsolenanwendung und fügen Sie das Paket wie in [Installation](/slides/de/net/installation/) beschrieben hinzu, ersetzen Sie den Inhalt von *Program.cs* durch den untenstehenden Code und führen Sie `dotnet run` aus. Wenn Sie Aspose.Slides.NET unter Linux verwenden, fügen Sie die im Abschnitt [Linux](#linux) gezeigte `System.Drawing.EnableUnixSupport`‑Switch‑Anweisung nach den `using`‑Direktiven hinzu. Das Programm verwendet Top‑Level‑Statements und `using`‑Deklarationen, die C# 9 oder neuer benötigen. Projekte, die .NET 6 oder höher anvisieren, verwenden standardmäßig eine neuere C#‑Version; in einem Projekt, das .NET Framework anvisiert, fügen Sie `<LangVersion>latest</LangVersion>` zu einer `PropertyGroup` in der Projektdatei hinzu.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

Das Programm fügt der ersten Folie ein Rechteck mit Text hinzu und speichert die Präsentation als *hello.pptx* mit der [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)-Methode. Anschließend rendert es die Folie mit [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) und speichert das Ergebnis als *hello.png* mit [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) im [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)-Format. Der Skalierungsfaktor 1 rendert einen Pixel pro Punkt, sodass die standardmäßige 720 × 540‑Punkt‑Folie zu einem 720 × 540‑Pixel‑Bild wird, wobei der Text im Rechteck sichtbar ist. Ohne Lizenz tragen beide Dateien ein Evaluations‑Wasserzeichen; siehe [Licensing](/slides/de/net/licensing/). Fehlt eine Voraussetzung, beendet das Programm mit einer der in [Linux](#linux) beschriebenen Ausnahmen.

## **Entwicklungswerkzeuge**

Sie können Anwendungen, die Aspose.Slides verwenden, mit jedem Werkzeug bauen, das das Ziel‑Framework Ihres Projekts unterstützt: das .NET‑SDK und dessen `dotnet`‑Kommandozeilen‑Interface unter Windows, Linux und macOS oder Visual Studio unter Windows. [Installation](/slides/de/net/installation/) beschreibt beides.

## **FAQ**

**Muss Microsoft PowerPoint für Konvertierungen und Rendering installiert sein?**

Nein, PowerPoint ist nicht erforderlich. Aspose.Slides ist eine eigenständige Engine zum [Erstellen](/slides/de/net/create-presentation/), Ändern, [Konvertieren](/slides/de/net/convert-presentation/) und [Rendern](/slides/de/net/convert-powerpoint-to-png/) von Präsentationen.

**Welches Paket sollte ich verwenden?**

Verwenden Sie Aspose.Slides.NET unter Windows und Aspose.Slides.NET6.CrossPlatform unter Linux und macOS. Auf Alpine Linux, auf Linux‑Systemen, deren glibc älter ist als die oben aufgeführten Versionen, und in Projekten, die .NET Framework anvisieren, verwenden Sie Aspose.Slides.NET. Fügen Sie einem Projekt nur eines der beiden Pakete hinzu.

**Welche Schriftarten werden für korrektes Rendering benötigt?**

Die in der Präsentation verwendeten Schriftarten oder geeignete Ersatzschriften müssen im Betriebssystem verfügbar sein. Unter Linux und macOS installieren Sie die Schriftpakete, die Ihre Präsentationen benötigen, um ein konsistentes Rendering zu erzielen. Unter Alpine Linux installieren Sie zusätzlich zu `libgdiplus` mindestens ein Schriftpaket, wie in [Alpine Linux](#alpine-linux) beschrieben.

**Warum wird eine benutzerdefinierte Schriftart unter Linux als Ersatzschrift oder fehlender Text dargestellt?**

Wenn die Schriftdatei inkonsistente oder beschädigte Einträge in der Namens‑Tabelle besitzt, kann der Linux‑Font‑Matching‑Stack (FreeType/fontconfig) einen ungültigen Eintrag auswählen, sodass die Schriftart nicht aufgelöst wird. Die Verwendung einer Schriftart‑Version mit korrigierten Namens‑Tabelleneinträgen oder das Installieren eines konsistenten Ersatzes behebt das Problem.