---
title: Arbeiten mit PowerPoint-Dokumenten in Qt
type: docs
description: "Aspose.Slides für C++ kann in Qt integriert werden, um PowerPoint-Dokumente in Qt-Anwendungen zu erstellen und zu manipulieren."
keywords: "ein Dokument in Qt Creator erstellen, ein Dokument in Qt Creator laden, Aspose C++ mit Qt Creator verwenden, ein Dokument von Aspose C++ laden, von Aspose.Slides C++ unterstützte Formate laden"
weight: 60
url: /cpp/work-with-powerpoint-documents-in-qt/
---

Qt ist ein auf C++ basierendes plattformübergreifendes Anwendungsentwicklungsframework, das häufig zur Entwicklung einer Vielzahl von Desktop-, Mobil- und Embedded-Systemanwendungen verwendet wird. Aspose.Slides für C++ kann in Qt integriert werden, um PowerPoint-Dokumente in Ihren Qt-Anwendungen zu erstellen und zu manipulieren.

## Verwendung von Aspose.Slides für C++ in Qt Creator

Um Aspose.Slides für C++ in Ihrer Qt-Anwendung zu verwenden, laden Sie die neueste Version der API im Abschnitt [downloads](https://downloads.aspose.com/slides/cpp) herunter. Sobald die API heruntergeladen ist, können Sie die C++-Bibliothek in Qt Creator oder Visual Studio integrieren.

Um die Aspose.Slides für C++-Bibliothek in einer in Qt Creator entwickelten Qt-Konsoleanwendung zu integrieren und zu verwenden, folgen Sie bitte den folgenden Schritten:

- Öffnen Sie Qt Creator und erstellen Sie eine neue *Qt-Konsoleanwendung*.

![qt_console_application](qt-console-application.png)

- Wählen Sie die QMake-Option aus der Dropdown-Liste *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Wählen Sie das geeignete Kit aus und schließen Sie den Wizard ab.
- Kopieren Sie den aspose-slides-cpp-21.02-Ordner aus dem extrahierten Paket von Aspose.Slides für C++ in das Stammverzeichnis des Projekts.

![lib_files](aspose.slides-lib-files.png)

- Um Pfade zu den lib- und include-Ordnern hinzuzufügen, klicken Sie mit der rechten Maustaste auf das Projekt im linken Panel und wählen Sie *Bibliothek hinzufügen*.

![qt_add_library](qt_add_library.png)

- Wählen Sie die Option Externe Bibliothek und durchsuchen Sie die Pfade, um die lib-Ordner nacheinander hinzuzufügen.

![todo:image_alt_text](qt-add-external-library.png)

- Sobald dies abgeschlossen ist, wird Ihre .pro-Projektdatei folgende Einträge enthalten:

![qt_pro_file.png](qt-pro-file.png)

- Bauen Sie die Anwendung und die Integration ist abgeschlossen.  

{{% alert color="primary" %}}

Hinweis: Siehe das [komplette Demoprojekt](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) für weitere Informationen.

{{% /alert %}}

## Verwendung von Aspose.Slides für C++ in Qt-Anwendungen unter Visual Studio

Um eine Qt-Anwendung mit Visual Studio zu entwickeln, müssen Sie [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123) installieren. Nachdem Sie die Installation haben, laden Sie die neueste Version der API im Abschnitt [downloads](https://downloads.aspose.com/slides/cpp) herunter und folgen Sie den folgenden Schritten:

- Öffnen Sie Microsoft Visual Studio und erstellen Sie eine neue *Qt-Konsoleanwendung*.

![VS_Console_Application.png](vs-console-application.png)

- Wählen Sie das geeignete Kit aus und schließen Sie den Wizard ab.
- Um die Aspose.Slides für C++-Bibliothek zu integrieren und zu verwenden, klicken Sie mit der rechten Maustaste auf das Projekt und wählen Sie *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Finden und installieren Sie das benötigte *Aspose.Slides.Cpp*-Paket.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Bauen Sie das Projekt und die Integration ist abgeschlossen.  

{{% alert color="primary" %}}

Hinweis: Siehe das [komplette Demoprojekt](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) für weitere Informationen.

{{% /alert %}}