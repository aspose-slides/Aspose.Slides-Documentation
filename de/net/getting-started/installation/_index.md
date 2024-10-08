---  
title: Installation  
type: docs  
weight: 70  
url: /de/net/installation/  
keywords: "Download Aspose.Slides, Install Aspose.Slides, Aspose.Slides Installation, Windows, macOS, .NET"  
description: "Installieren Sie Aspose.Slides für .NET unter Windows oder macOS"  
---  

## **Windows**  
NuGet bietet den einfachsten Weg, um Aspose APIs für .NET auf PCs herunterzuladen und zu installieren.  

### **Methode 1: Installieren oder Aktualisieren von Aspose.Slides über den NuGet-Paket-Manager**  

1. Öffnen Sie Microsoft Visual Studio.  
2. Erstellen Sie eine einfache Konsolenanwendung oder öffnen Sie ein bestehendes Projekt.  
3. Gehen Sie zu **Extras** > **NuGet-Paket-Manager**.  
4. Suchen Sie unter **Durchsuchen** im Textfeld nach *Aspose Slides*.  
{{% image img="installation_1.png" alt="Aspose.Slides Installation vom NuGet-Paket-Manager - 1" %}}  
5. Klicken Sie auf **Aspose.Slides.NET** und dann auf **Installieren**.  
   * Wenn Sie Aspose.Slides aktualisieren möchten – vorausgesetzt, Sie haben es bereits installiert – klicken Sie stattdessen auf **Aktualisieren**.  

Die ausgewählte API wird heruntergeladen und in Ihrem Projekt referenziert.  

### **Methode 2: Installieren oder Aktualisieren von Aspose.Slides über die Paket-Manager-Konsole**  

So referenzieren Sie die [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) über die Paket-Manager-Konsole:  

1. Öffnen Sie Microsoft Visual Studio.  
2. Erstellen Sie eine einfache Konsolenanwendung oder öffnen Sie ein bestehendes Projekt.  
3. Gehen Sie zu **Extras** > **Bibliotheks-Paket-Manager** > **Paket-Manager-Konsole**.  
![todo:image_alt_text](installation_2.png)  
4. Führen Sie diesen Befehl aus: `Install-Package Aspose.Slides.NET`  
![todo:image_alt_text](installation_3.png)  
Die neueste vollständige Version wird in Ihrer Anwendung installiert.  

* Alternativ können Sie das Suffix `-prerelease` zum Befehl hinzufügen, um anzugeben, dass auch die neueste Version (Hotfixes eingeschlossen) installiert werden muss.  

Der Hinweis **Installing Aspose.Slides.NET** erscheint am unteren Rand des Fensters.  
![todo:image_alt_text](installation_4.png)  

Sobald der Download abgeschlossen ist, sollten Sie einige Bestätigungsnachrichten sehen.  

Wenn Sie mit der [Aspose EULA](https://about.aspose.com/legal/eula) nicht vertraut sind, möchten Sie möglicherweise die Lizenz lesen, die in der URL referenziert wird.  
![todo:image_alt_text](installation_5.png)  

In Ihrer Anwendung sollten Sie sehen, dass Aspose.Slides erfolgreich hinzugefügt und referenziert wurde.  
![todo:image_alt_text](installation_6.png)  

In der Paket-Manager-Konsole können Sie den Befehl `Update-Package Aspose.Slides.NET` ausführen, um nach Updates für das Aspose.Slides-Paket zu suchen. Updates (falls vorhanden) werden automatisch installiert. Sie können auch das Suffix `-prerelease` verwenden, um die neueste Version zu aktualisieren.  
#### **Überlegungen bei der Ausführung in einer gemeinsam genutzten Serverumgebung**  
Wir empfehlen dringend, alle Aspose .NET-Komponenten mit dem Berechtigungssatz **Vollzugriff** auszuführen, da Aspose-Komponenten manchmal auf Registrierungseinstellungen und Dateien zugreifen müssen, die sich an anderen Orten als im virtuellen Verzeichnis befinden – beispielsweise, wenn Aspose-Komponenten Schriften lesen müssen.  

Darüber hinaus basieren die Aspose.NET-Komponenten auf den grundlegenden .NET-Systemklassen – und einige dieser Klassen erfordern ebenfalls die Berechtigung für Vollzugriff für Vorgänge in bestimmten Fällen.  

Internetdienstanbieter, die mehrere Anwendungen von verschiedenen Unternehmen hosten, erzwingen meist das Sicherheitsniveau **Medium Trust**. Im Fall von .NET 2.0 kann ein solches Sicherheitsniveau zu Einschränkungen führen, die die Vorgänge von Aspose.Slides beeinträchtigen:  

- **RegistryPermission** ist nicht verfügbar. Dies bedeutet, dass Sie nicht auf die Registrierung zugreifen können, was erforderlich ist, um installierte Schriften zu enumerieren, wenn Dokumente gerendert werden.  
- **FileIOPermission** ist eingeschränkt. Dies bedeutet, dass Sie nur auf Dateien in der virtuellen Verzeichnis-Hierarchie Ihrer Anwendung zugreifen können. Dies könnte auch bedeuten, dass Schriften während Exportoperationen nicht gelesen werden können.  

Aus den oben genannten Gründen empfehlen wir ausdrücklich, Aspose.Slides mit den Berechtigungen **Vollzugriff** auszuführen. Wenn Sie **Medium Trust** verwenden, können Sie Inkonsistenzen erleben – einige Funktionen der Bibliothek (z. B. Rendering) funktionieren möglicherweise nicht, wenn Sie bestimmte Aufgaben ausführen.  

## **macOS**  

NuGet bietet den einfachsten Weg, um Aspose.Slides für .NET auf Macs herunterzuladen und zu installieren.  

**Voraussetzung installieren**  

Der Namensraum `System.Drawing` funktioniert in macOS anders, daher müssen Sie mono-libgdiplus installieren.  

> In .NET 5 und früheren Versionen funktioniert das [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet-Paket unter Windows, Linux und macOS. Es gibt jedoch einige plattformspezifische Unterschiede. Unter Linux und macOS wird die GDI+-Funktionalität von der [libgdiplus](https://www.mono-project.com/docs/gui/libgdiplus/) Bibliothek implementiert. Diese Bibliothek ist in den meisten Linux-Distributionen standardmäßig nicht installiert und unterstützt nicht die gesamte Funktionalität von GDI+ unter Windows und macOS. Es gibt auch Plattformen, auf denen libgdiplus überhaupt nicht verfügbar ist. Um Typen aus dem `System.Drawing.Common`-Paket unter Linux und macOS zu verwenden, müssen Sie libgdiplus separat installieren. Weitere Informationen finden Sie unter [Install .NET on Linux](https://docs.microsoft.com/en-us/dotnet/core/install/linux) oder [Install .NET on macOS](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus).  

Um mono-libgdiplus separat auf Ihrem Mac zu installieren, siehe [diesen Artikel](https://docs.microsoft.com/en-us/dotnet/core/install/macos#libgdiplus) aus der .NET-Dokumentation.  

### **Aspose.Slides installieren**  

1. Öffnen Sie Visual Studio.  
2. Erstellen Sie eine einfache Konsolenanwendung oder öffnen Sie ein bestehendes Projekt.  
3. Gehen Sie zu **Projekt** > **NuGet-Pakete verwalten...**  
   ![path-to-nuget-macos](path-to-nuget-macos.png)  
4. Geben Sie *Aspose.Slides* in das Textfeld ein.  
5. Klicken Sie auf **Aspose.Slides für .NET** und dann auf **Paket hinzufügen**.  
6. Fügen Sie einen einfachen Code-Schnipsel hinzu.  
   * Sie können den Code auf [dieser Seite](/slides/de/net/create-presentation/) kopieren.  
7. Führen Sie die Anwendung aus.  
8. Öffnen Sie den *Ordner/bin/Debug/presentation_file_name* Ihres Projekts.  