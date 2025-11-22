---
title: Installation
type: docs
weight: 70
url: /de/net/installation/
keywords: "Herunterladen Aspose.Slides, Installieren Aspose.Slides, Aspose.Slides Installation, Windows, macOS, .NET"
description: "Installieren Sie Aspose.Slides für .NET unter Windows oder macOS"
---

## **Windows**
NuGet bietet den einfachsten Weg, Aspose‑APIs für .NET auf PCs herunterzuladen und zu installieren. 

### **Methode 1: Aspose.Slides über den NuGet‑Paket‑Manager installieren oder aktualisieren**

1. Öffnen Sie Microsoft Visual Studio.  
2. Erstellen Sie eine einfache Konsolen‑App oder öffnen Sie ein vorhandenes Projekt.  
3. Gehen Sie zu **Tools** > **NuGet‑Paket‑Manager**.  
4. Unter **Browse** suchen Sie im Textfeld nach *Aspose Slides*.  
{{% image img="installation_1.png" alt="Aspose.Slides‑Installation über NuGet‑Paket‑Manager – 1" %}}
5. Klicken Sie auf **Aspose.Slides.NET** und dann auf **Install**.  
   * Wenn Sie Aspose.Slides bereits installiert haben und aktualisieren möchten, klicken Sie stattdessen auf **Update**.  

Die ausgewählte API wird heruntergeladen und in Ihrem Projekt referenziert.

### **Methode 2: Aspose.Slides über die Paket‑Manager‑Konsole installieren oder aktualisieren**

So referenzieren Sie die [Aspose.Slides‑API](https://www.nuget.org/packages/Aspose.Slides.NET/) über die Paket‑Manager‑Konsole:

1. Öffnen Sie Microsoft Visual Studio.  
2. Erstellen Sie eine einfache Konsolen‑App oder öffnen Sie ein vorhandenes Projekt.  
3. Gehen Sie zu **Tools** > **Library Package Manager** > **Package Manager Console**.  
![todo:image_alt_text](installation_2.png)
4. Führen Sie diesen Befehl aus: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)
Die neueste Vollversion wird in Ihrer Anwendung installiert.  

* Alternativ können Sie das Suffix `-prerelease` zum Befehl hinzufügen, um auch die neueste Version mit Hotfixes zu installieren.

Der Hinweis **Installing Aspose.Slides.NET** erscheint am unteren Rand des Fensters.  
![todo:image_alt_text](installation_4.png)

Sobald der Download abgeschlossen ist, sollten Sie Bestätigungsnachrichten sehen.  

Wenn Sie mit der [Aspose‑EULA](https://about.aspose.com/legal/eula) nicht vertraut sind, möchten Sie möglicherweise die Lizenz lesen, die in der URL angegeben ist.  
![todo:image_alt_text](installation_5.png)

In Ihrer Anwendung sollten Sie sehen, dass Aspose.Slides erfolgreich hinzugefügt und referenziert wurde.  
![todo:image_alt_text](installation_6.png)

In der Paket‑Manager‑Konsole können Sie den Befehl `Update-Package Aspose.Slides.NET` ausführen, um nach Updates für das Aspose.Slides‑Paket zu suchen. Updates (falls gefunden) werden automatisch installiert. Sie können ebenfalls das Suffix `-prerelease` verwenden, um die neueste Version zu aktualisieren.

#### **Überlegungen für den Betrieb in einer gemeinsam genutzten Server‑Umgebung**
Wir empfehlen dringend, alle Aspose‑.NET‑Komponenten mit dem Berechtigungssatz **Full Trust** auszuführen, weil Aspose‑Komponenten manchmal Registrierungs‑ und Dateizugriff außerhalb des virtuellen Verzeichnisses benötigen – beispielsweise zum Lesen von Schriftarten.  

Darüber hinaus basieren Aspose.NET‑Komponenten auf den Kern‑.NET‑Systemklassen, und einige dieser Klassen erfordern in bestimmten Fällen ebenfalls Full‑Trust‑Berechtigungen.  

Internet‑Service‑Provider, die mehrere Anwendungen verschiedener Unternehmen hosten, setzen meist das Sicherheitslevel **Medium Trust** durch. Im .NET‑2.0‑Fall kann ein solches Sicherheitslevel zu Einschränkungen führen, die die Funktionsweise von Aspose.Slides beeinträchtigen:

- **RegistryPermission** ist nicht verfügbar. Das bedeutet, Sie können nicht auf die Registrierung zugreifen, was zum Aufzählen installierter Schriftarten beim Rendern von Dokumenten erforderlich ist.  
- **FileIOPermission** ist eingeschränkt. Das bedeutet, Sie können nur auf Dateien in der virtuellen Verzeichnis‑Hierarchie Ihrer Anwendung zugreifen. Das kann ebenfalls dazu führen, dass Schriftarten beim Export nicht gelesen werden können.  

Aus den genannten Gründen empfehlen wir nachdrücklich, Aspose.Slides mit **Full Trust**‑Berechtigungen auszuführen. Wenn Sie **Medium Trust** verwenden, können Inkonsistenzen auftreten – einige Bibliotheks‑Features (z. B. Rendering) funktionieren möglicherweise nicht, wenn Sie bestimmte Aufgaben ausführen.  

## **macOS**

NuGet bietet den einfachsten Weg, Aspose.Slides für .NET auf Macs herunterzuladen und zu installieren. 

**Voraussetzung installieren**

Der Namespace `System.Drawing` funktioniert unter macOS anders, daher müssen Sie mono‑libgdiplus installieren.  

> In .NET 5 und früheren Versionen funktioniert das NuGet‑Paket [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) unter Windows, Linux und macOS. Es gibt jedoch plattformspezifische Unterschiede. Unter Linux und macOS wird die GDI+‑Funktionalität durch die Bibliothek [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/) bereitgestellt. Diese Bibliothek ist in den meisten Linux‑Distributionen nicht standardmäßig installiert und unterstützt nicht die gesamte GDI+‑Funktionalität von Windows und macOS. Auf einigen Plattformen ist libgdiplus überhaupt nicht verfügbar. Um Typen aus dem System.Drawing.Common‑Paket unter Linux und macOS zu verwenden, müssen Sie libgdiplus separat installieren. Weitere Informationen finden Sie unter [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) oder [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).  

Um mono‑libgdiplus separat auf Ihrem Mac zu installieren, lesen Sie den Artikel [this article](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) aus der .NET‑Dokumentation. 

### **Aspose.Slides installieren**

1. Öffnen Sie Visual Studio.  
2. Erstellen Sie eine einfache Konsolen‑App oder öffnen Sie ein vorhandenes Projekt.  
3. Gehen Sie zu **Project** > **Manage NuGet Packages...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Geben Sie *Aspose.Slides* in das Textfeld ein.  
5. Klicken Sie auf **Aspose.Slides for .NET** und dann auf **Add Package**.  
6. Fügen Sie ein einfaches Code‑Snippet hinzu.  
   * Sie können den Code von [this page](/slides/de/net/create-presentation/) kopieren.  
7. Führen Sie die App aus.  
8. Öffnen Sie den Ordner *folder/bin/Debug/presentation_file_name* Ihres Projekts.  

## **FAQ**

**Gibt es eine kostenlose Version oder Einschränkungen in der Testphase?**

Ja, standardmäßig läuft Aspose.Slides im Evaluierungsmodus, der Wasserzeichen einfügt und weitere Einschränkungen haben kann. Um Beschränkungen zu entfernen, müssen Sie eine gültige [license](/slides/de/net/licensing/) anwenden.