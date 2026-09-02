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
description: "Erfahren Sie, wie Sie Aspose.Slides für .NET schnell installieren. Schritt-für-Schritt-Anleitung, Systemanforderungen und Code-Beispiele - beginnen Sie noch heute mit der Arbeit an PowerPoint-Präsentationen!"
---
## **Übersicht**

Dieser Artikel erklärt, wie man Aspose.Slides für .NET unter Windows, Linux und macOS installiert. Er konzentriert sich auf die NuGet-basierte Installation und zeigt, wie die Bibliothek über den NuGet-Paket-Manager oder die Package Manager Console unter Windows, zu einem .NET‑Projekt unter Linux und zu einem Visual Studio‑Projekt unter macOS hinzugefügt wird. Außerdem wird beschrieben, wie das Paket aktualisiert und bei Bedarf Vorabversionen installiert werden.

Vor der Installation prüfen Sie bitte die unterstützten Betriebssysteme, .NET‑Implementierungen und zusätzlichen Abhängigkeiten in [Systemanforderungen](/slides/de/net/system-requirements/).

## **Windows**
NuGet bietet den einfachsten Weg, Aspose‑APIs für .NET auf PCs herunterzuladen und zu installieren. 

### **Methode 1: Aspose.Slides über den NuGet-Paket-Manager installieren oder aktualisieren**

1. Microsoft Visual Studio öffnen. 
2. Eine einfache Konsolenanwendung erstellen oder ein bestehendes Projekt öffnen. 
3. Navigieren Sie zu **Tools** > **NuGet package manager**. 
4. Unter **Browse** nach *Aspose Slides* im Textfeld suchen. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Klicken Sie auf **Aspose.Slides.NET** und dann auf **Install**. 
   * Wenn Sie Aspose.Slides aktualisieren möchten – vorausgesetzt, Sie haben es bereits installiert – klicken Sie stattdessen auf **Update**. 

Die ausgewählte API wird heruntergeladen und in Ihrem Projekt referenziert.

### **Methode 2: Aspose.Slides über die Package Manager Console installieren oder aktualisieren**

So referenzieren Sie die [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) über die Package Manager Console:

1. Microsoft Visual Studio öffnen. 
2. Eine einfache Konsolenanwendung erstellen oder ein bestehendes Projekt öffnen. 
3. Navigieren Sie zu **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Führen Sie diesen Befehl aus: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
Das neueste vollständige Release wird in Ihrer Anwendung installiert. 

* Alternativ können Sie dem Befehl das Suffix `-prerelease` hinzufügen, um anzugeben, dass das neueste Release (einschließlich Hotfixes) ebenfalls installiert werden soll.

Der Hinweis **Installing Aspose.Slides.NET** erscheint etwa am unteren Rand des Fensters. 
![todo:image_alt_text](installation_4.png)

Sobald der Download abgeschlossen ist, sollten Sie einige Bestätigungsnachrichten sehen. 

Wenn Sie mit der [Aspose EULA](https://about.aspose.com/legal/eula) nicht vertraut sind, sollten Sie die in der URL referenzierte Lizenz lesen. 
![todo:image_alt_text](installation_5.png)

In Ihrer Anwendung sollten Sie sehen, dass Aspose.Slides erfolgreich hinzugefügt und referenziert wurde. 
![todo:image_alt_text](installation_6.png)

In der Package Manager Console können Sie den Befehl `Update-Package Aspose.Slides.NET` ausführen, um nach Updates für das Aspose.Slides‑Paket zu suchen. Updates (falls gefunden) werden automatisch installiert. Sie können ebenfalls das Suffix `-prerelease` verwenden, um das neueste Release zu aktualisieren.

#### **Überlegungen beim Betrieb in einer gemeinsam genutzten Serverumgebung**
Wir empfehlen dringend, alle Aspose .NET‑Komponenten mit dem Berechtigungssatz **Full Trust** auszuführen, da Aspose‑Komponenten manchmal auf Registrierungseinstellungen und Dateien außerhalb des virtuellen Verzeichnisses zugreifen müssen – beispielsweise wenn Schriftarten gelesen werden müssen. 

Darüber hinaus basieren Aspose.NET‑Komponenten auf den Kern‑.NET‑Systemklassen – und einige dieser Klassen erfordern in bestimmten Fällen ebenfalls **Full Trust**‑Berechtigungen.

Internetdienstanbieter, die mehrere Anwendungen verschiedener Unternehmen hosten, setzen meist das Sicherheitsniveau **Medium Trust** durch. Im .NET 2.0‑Fall kann ein solches Sicherheitsniveau zu Einschränkungen führen, die die Funktionsweise von Aspose.Slides beeinträchtigen:

- **RegistryPermission** ist nicht verfügbar. Das bedeutet, Sie können nicht auf die Registrierung zugreifen, was zum Auflisten installierter Schriftarten beim Rendern von Dokumenten erforderlich ist.
- **FileIOPermission** ist eingeschränkt. Das bedeutet, Sie können nur auf Dateien innerhalb der virtuellen Verzeichnisstruktur Ihrer Anwendung zugreifen. Dies kann ebenfalls dazu führen, dass Schriftarten während Exportvorgängen nicht gelesen werden können. 

Aus den genannten Gründen empfehlen wir dringend, Aspose.Slides mit **Full Trust**‑Berechtigungen auszuführen. Wenn Sie **Medium Trust** verwenden, können Inkonsistenzen auftreten – einige Bibliotheksfunktionen (z. B. das Rendering) funktionieren möglicherweise nicht bei bestimmten Vorgängen. 

## **Linux**

NuGet bietet den einfachsten Weg, Aspose.Slides für .NET unter Linux herunterzuladen und zu installieren. Fügen Sie das [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)‑Paket zu Ihrem .NET‑Projekt hinzu.

## **macOS**

NuGet bietet den einfachsten Weg, Aspose.Slides für .NET auf Macs herunterzuladen und zu installieren.

### **Aspose.Slides installieren**

1. Visual Studio öffnen. 
2. Eine einfache Konsolenanwendung erstellen oder ein bestehendes Projekt öffnen.
3. Navigieren Sie zu **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Geben Sie *Aspose.Slides* in das Textfeld ein. 
5. Klicken Sie auf **Aspose.Slides for .NET** und dann auf **Add Package.** 
6. Fügen Sie einen einfachen Code‑Snippet hinzu.
   * Sie können den Code auf [dieser Seite](/slides/de/net/create-presentation/) kopieren.
7. Führen Sie die Anwendung aus.
8. Öffnen Sie den *folder/bin/Debug/presentation_file_name* Ihres Projekts.

## **FAQ**

**Gibt es eine kostenlose Version oder Einschränkungen in der Testphase?**

Ja, standardmäßig läuft Aspose.Slides im Evaluierungsmodus, der Wasserzeichen einfügt und weitere Einschränkungen haben kann. Um die Beschränkungen zu entfernen, müssen Sie eine gültige [license](/slides/de/net/licensing/) anwenden.