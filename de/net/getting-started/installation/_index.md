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
description: "Erfahren Sie, wie Sie Aspose.Slides für .NET schnell installieren. Schritt-für-Schritt-Anleitung, Systemanforderungen und Code-Beispiele — beginnen Sie noch heute mit der Arbeit an PowerPoint-Präsentationen!"
---

## **Windows**
NuGet bietet den einfachsten Weg, Aspose‑APIs für .NET auf PCs herunterzuladen und zu installieren. 

### **Methode 1: Aspose.Slides über den NuGet-Paket-Manager installieren oder aktualisieren**

1. Öffnen Sie Microsoft Visual Studio. 
2. Erstellen Sie eine einfache Konsolenanwendung oder öffnen Sie ein vorhandenes Projekt. 
3. Gehen Sie zu **Tools** > **NuGet package manager**.
4. Unter **Browse** suchen Sie im Textfeld nach *Aspose Slides*. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Klicken Sie auf **Aspose.Slides.NET** und dann auf **Install**. 
   * Wenn Sie Aspose.Slides aktualisieren möchten – vorausgesetzt, es ist bereits installiert – klicken Sie stattdessen auf **Update**. 

Die ausgewählte API wird heruntergeladen und Ihrem Projekt hinzugefügt.

### **Methode 2: Aspose.Slides über die Package Manager Console installieren oder aktualisieren**

So referenzieren Sie die [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) über die Package Manager Console:

1. Öffnen Sie Microsoft Visual Studio. 
2. Erstellen Sie eine einfache Konsolenanwendung oder öffnen Sie ein vorhandenes Projekt. 
3. Gehen Sie zu **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Führen Sie diesen Befehl aus: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
Die neueste Vollversion wird in Ihrer Anwendung installiert. 

* Alternativ können Sie dem Befehl das Suffix `-prerelease` hinzufügen, um anzugeben, dass auch die neueste Version (inklusive Hotfixes) installiert werden soll.

Der Hinweis **Installing Aspose.Slides.NET** erscheint am unteren Rand des Fensters. 
![todo:image_alt_text](installation_4.png)

Sobald der Download abgeschlossen ist, sollten Sie einige Bestätigungsnachrichten sehen. 

Wenn Ihnen die [Aspose EULA](https://about.aspose.com/legal/eula) nicht bekannt ist, sollten Sie die in der URL referenzierte Lizenz lesen. 
![todo:image_alt_text](installation_5.png)

In Ihrer Anwendung sollten Sie sehen, dass Aspose.Slides erfolgreich hinzugefügt und referenziert wurde. 
![todo:image_alt_text](installation_6.png)

In der Package Manager Console können Sie den Befehl `Update-Package Aspose.Slides.NET` ausführen, um nach Updates für das Aspose.Slides‑Paket zu suchen. Gefundene Updates werden automatisch installiert. Sie können ebenfalls das Suffix `-prerelease` verwenden, um die neueste Version zu aktualisieren.
#### **Überlegungen beim Betrieb in einer gemeinsam genutzten Serverumgebung**
Wir empfehlen dringend, alle Aspose‑.NET‑Komponenten mit dem Berechtigungssatz **Full Trust** auszuführen, da Aspose‑Komponenten manchmal auf Registrierungseinstellungen und Dateien außerhalb des virtuellen Verzeichnisses zugreifen müssen – beispielsweise wenn Schriftarten gelesen werden müssen. 

Darüber hinaus basieren Aspose.NET‑Komponenten auf den Kernklassen des .NET‑Systems – und einige dieser Klassen erfordern in bestimmten Fällen ebenfalls Full‑Trust‑Berechtigungen. 

Internet‑Service‑Provider, die mehrere Anwendungen verschiedener Unternehmen hosten, setzen meist das Sicherheitsniveau Medium Trust durch. Im Fall von .NET 2.0 kann ein solches Sicherheitsniveau zu Einschränkungen führen, die die Vorgänge von Aspose.Slides beeinträchtigen:

- **RegistryPermission** ist nicht verfügbar. Das bedeutet, dass Sie nicht auf die Registrierung zugreifen können, was zum Auflisten installierter Schriftarten beim Rendern von Dokumenten erforderlich ist. 
- **FileIOPermission** ist eingeschränkt. Das bedeutet, dass Sie nur auf Dateien im virtuellen Verzeichnis Ihrer Anwendung zugreifen können. Dies kann ebenfalls bedeuten, dass Schriftarten während Exportvorgängen nicht gelesen werden können. 

Aus den genannten Gründen empfehlen wir dringend, Aspose.Slides mit **Full Trust**‑Berechtigungen auszuführen. Wenn Sie **Medium Trust** verwenden, können Inkonsistenzen auftreten – einige Bibliotheksfunktionen (z. B. Rendering) funktionieren möglicherweise nicht bei bestimmten Aufgaben. 

## **macOS**

NuGet bietet den einfachsten Weg, Aspose.Slides für .NET auf Macs herunterzuladen und zu installieren. 

**Voraussetzungen installieren**

Der Namensraum `System.Drawing` funktioniert unter macOS anders, daher müssen Sie mono-libgdiplus installieren. 

> In .NET 5 und früheren Versionen funktioniert das NuGet‑Paket [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) unter Windows, Linux und macOS. Es gibt jedoch einige plattformspezifische Unterschiede. Auf Linux und macOS wird die GDI+‑Funktionalität durch die Bibliothek [libgdiplus)](https://www.mono-project.com/docs/gui/libgdiplus/) bereitgestellt. Diese Bibliothek ist in den meisten Linux‑Distributionen nicht standardmäßig installiert und unterstützt nicht die gesamte GDI+‑Funktionalität von Windows und macOS. Es gibt zudem Plattformen, auf denen libgdiplus überhaupt nicht verfügbar ist. Um Typen aus dem System.Drawing.Common‑Paket unter Linux und macOS zu verwenden, müssen Sie libgdiplus separat installieren. Weitere Informationen finden Sie unter [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) oder [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).s

Um mono-libgdiplus separat auf Ihrem Mac zu installieren, lesen Sie [diesen Artikel](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) aus der .NET‑Dokumentation. 

### **Aspose.Slides installieren**

1. Öffnen Sie Visual Studio. 
2. Erstellen Sie eine einfache Konsolenanwendung oder öffnen Sie ein vorhandenes Projekt.
3. Gehen Sie zu **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Geben Sie *Aspose.Slides* in das Textfeld ein. 
5. Klicken Sie auf **Aspose.Slides for .NET** und dann auf **Add Package.** 
6. Fügen Sie einen einfachen Code‑Snippet hinzu.
   * Sie können den Code auf [dieser Seite](/slides/de/net/create-presentation/) kopieren.
7. Führen Sie die Anwendung aus.
8. Öffnen Sie den Pfad *folder/bin/Debug/presentation_file_name* Ihres Projekts.

## **FAQ**

**Gibt es eine kostenlose Version oder Einschränkungen in der Testphase?**

Ja, standardmäßig läuft Aspose.Slides im Evaluierungsmodus, der Wasserzeichen einfügt und weitere Einschränkungen haben kann. Um Beschränkungen zu entfernen, müssen Sie eine gültige [Lizenz](/slides/de/net/licensing/) anwenden.