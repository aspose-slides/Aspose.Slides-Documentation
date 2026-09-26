---
title: Installation
type: docs
weight: 70
url: /de/net/installation/
keywords:
- Aspose.Slides installieren
- Aspose.Slides herunterladen
- Aspose.Slides verwenden
- Aspose.Slides-Installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Installieren Sie Aspose.Slides für .NET über NuGet unter Windows, Linux und macOS: Wählen Sie eines der beiden Pakete, fügen Sie es mit der .NET-CLI oder Visual Studio hinzu und installieren Sie die Linux-Voraussetzungen."
---
## **Überblick**

Dieser Artikel erklärt, wie Aspose.Slides für .NET zu einem Projekt unter Windows, Linux und macOS hinzugefügt wird. Aspose.Slides wird über NuGet bereitgestellt. Sie können es mit der .NET‑CLI auf jedem Betriebssystem hinzufügen oder mit dem NuGet Package Manager bzw. der Package Manager Console in Visual Studio unter Windows. Der Artikel erläutert außerdem, welches der beiden NuGet‑Pakete zu wählen ist und welche zusätzlichen Anforderungen Linux hat.

Vor der Installation sollten Sie die unterstützten Betriebssysteme, .NET‑Implementierungen und zusätzlichen Abhängigkeiten in [Systemanforderungen](/slides/de/net/system-requirements/) überprüfen.

## **Paket auswählen**

Aspose.Slides für .NET wird als zwei NuGet‑Pakete veröffentlicht. Beide stellen dieselben Aspose.Slides‑Namespaces und -Klassen bereit, sodass sich Ihr Code beim Wechsel zwischen ihnen nicht ändert; lediglich die Paketreferenz und die Plattformanforderungen unterscheiden sich.

| Paket | Verwendung für | Zusätzliche Anforderungen |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | Windows und .NET Framework‑Anwendungen | Unter Linux und macOS: die Bibliothek `libgdiplus` und der Schalter `System.Drawing.EnableUnixSupport`, der beim Anwendungsstart aktiviert wird |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 oder neuer unter Windows, Linux und macOS | Unter Linux: die Bibliothek `fontconfig`, falls sie nicht bereits installiert ist |

Wenn Sie unsicher sind, verwenden Sie Aspose.Slides.NET unter Windows und Aspose.Slides.NET6.CrossPlatform unter Linux und macOS. Auf Alpine Linux und auf Linux‑Systemen, deren glibc älter als 2.23 (x64) oder 2.39 (ARM64) ist, verwenden Sie stattdessen Aspose.Slides.NET. [Systemanforderungen](/slides/de/net/system-requirements/) listet die unterstützten Plattformen jedes Pakets auf.

## **Installation mit der .NET‑CLI**

Diese Schritte funktionieren unter Windows, Linux und macOS mit dem .NET‑SDK 6 oder höher. Erstellen Sie eine Konsolenanwendung:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Fügen Sie dann das Paket für Ihre Plattform hinzu. Fügen Sie nur eines der beiden Pakete zu einem Projekt hinzu.

- Unter Windows: `dotnet add package Aspose.Slides.NET`
- Unter Linux und macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (unter Linux installieren Sie zuerst die Voraussetzung; siehe [Linux](#linux))

Um zu überprüfen, dass das Paket funktioniert, ersetzen Sie den Inhalt von *Program.cs* durch das erste Beispiel in [Create Presentations](/slides/de/net/create-presentation/) und führen Sie `dotnet run` aus. Es speichert *hello.pptx* im Projektordner.

## **Windows**

### **Methode 1: Aspose.Slides über den NuGet Package Manager installieren oder aktualisieren**

1. Öffnen Sie Microsoft Visual Studio.
2. Erstellen Sie eine Konsolenanwendung oder öffnen Sie ein vorhandenes Projekt.
3. Klicken Sie im **Solution Explorer** mit der rechten Maustaste auf das Projekt und wählen Sie **Manage NuGet Packages** (oder gehen Sie zu **Project** > **Manage NuGet Packages**).
4. Suchen Sie unter **Browse** nach *Aspose.Slides*.
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Klicken Sie auf **Aspose.Slides.NET** und dann auf **Install**.  
   * Wenn Sie Aspose.Slides bereits installiert haben und es aktualisieren möchten, klicken Sie stattdessen auf **Update**.

Das Paket wird heruntergeladen und in Ihrem Projekt referenziert.

### **Methode 2: Aspose.Slides über die Package Manager Console installieren oder aktualisieren**

So referenzieren Sie das Paket [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) über die Package Manager Console:

1. Öffnen Sie Microsoft Visual Studio.
2. Erstellen Sie eine Konsolenanwendung oder öffnen Sie ein vorhandenes Projekt.
3. Gehen Sie zu **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![Opening the Package Manager Console](installation_2.png)
4. Führen Sie diesen Befehl aus: `Install-Package Aspose.Slides.NET`
![Running the Install-Package command](installation_3.png)
Die neueste Version wird in Ihrem Projekt installiert.

Die Meldung **Installing Aspose.Slides.NET** erscheint am unteren Rand des Fensters.
![Installation progress in the Package Manager Console](installation_4.png)

Wenn der Download abgeschlossen ist, erscheinen Bestätigungsnachrichten. Das Paket wird unter der [Aspose EULA](https://about.aspose.com/legal/eula) bereitgestellt.
![Installation confirmation messages](installation_5.png)

Aspose.Slides ist nun zu Ihrem Projekt hinzugefügt und referenziert.
![Aspose.Slides referenced in the project](installation_6.png)

Um das Paket zu aktualisieren, führen Sie `Update-Package Aspose.Slides.NET` in der Package Manager Console aus.

## **Linux**

Verwenden Sie die oben genannten .NET‑CLI‑Schritte. Wählen Sie das Paket und installieren Sie die Voraussetzung mit dem Paketmanager Ihrer Distribution. Auf Debian und Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: install `fontconfig`.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
```

- **Aspose.Slides.NET**: installieren Sie `libgdiplus` und aktivieren Sie die Unix‑Unterstützung für System.Drawing, bevor Ihre Anwendung Aspose.Slides verwendet.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
```

Fügen Sie diese Anweisung am Anfang Ihrer Anwendung hinzu, bevor ein Aufruf von Aspose.Slides erfolgt. In einer *Program.cs* mit Top‑Level‑Anweisungen platzieren Sie sie nach den `using`‑Direktiven:

```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```

Verwenden Sie dieses Paket auf Alpine Linux und auf Systemen, deren glibc zu alt für Aspose.Slides.NET6.CrossPlatform ist.

Die in Ihren Präsentationen verwendeten Schriften bzw. geeignete Ersatzschriften müssen auf dem System installiert sein, damit Text korrekt gerendert wird. [Systemanforderungen](/slides/de/net/system-requirements/) beschreibt die Pakete, die Aspose.Slides.NET auf Alpine Linux benötigt, einschließlich Schriften.

## **macOS**

Verwenden Sie die oben genannten .NET‑CLI‑Schritte mit dem Paket **Aspose.Slides.NET6.CrossPlatform**, das sowohl Intel (x86_64) als auch Apple‑Silicon (ARM64) Macs unterstützt:

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **FAQ**

**Gibt es eine kostenlose Version oder Einschränkungen in der Testversion?**

Ja. Ohne Lizenz läuft Aspose.Slides im Evaluierungsmodus: Es fügt jedem gespeicherten Folie ein Evaluations‑Wasserzeichen hinzu und kürzt den aus Präsentationen gelesenen Text. Um diese Einschränkungen zu entfernen, wenden Sie eine gültige [license](/slides/de/net/licensing/) an.