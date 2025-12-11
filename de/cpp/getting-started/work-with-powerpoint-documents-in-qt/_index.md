---
title: Arbeiten mit PowerPoint-Dokumenten in Qt
type: docs
weight: 60
url: /de/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt Creator
- Qt-Anwendung
- plattformübergreifend
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwenden Sie Aspose.Slides für C++ mit Qt Creator und Visual Studio, um PowerPoint- und OpenDocument-Präsentationen in plattformübergreifenden Apps zu erstellen, zu laden und zu bearbeiten."
---

Qt ist ein auf C++ basierendes plattformübergreifendes Anwendungsentwicklungs‑Framework, das häufig zur Entwicklung einer Vielzahl von Desktop‑, Mobil‑ und Embedded‑System‑Anwendungen verwendet wird. Aspose.Slides for C++ kann in Qt integriert werden, um PowerPoint‑Dokumente in Ihren Qt‑Anwendungen zu erstellen und zu manipulieren.

## **Verwenden von Aspose.Slides für C++ in Qt Creator**

Um Aspose.Slides für C++ in Ihrer Qt‑Anwendung zu verwenden, laden Sie die neueste Version der API aus dem Abschnitt [downloads](https://downloads.aspose.com/slides/cpp) herunter. Nachdem die API heruntergeladen wurde, können Sie die C++‑Bibliothek in Qt Creator oder Visual Studio integrieren.

Um die Aspose.Slides für C++‑Bibliothek in eine mit Qt Creator entwickelte Qt‑Konsolenanwendung zu integrieren und zu verwenden, folgen Sie bitte den unten angegebenen Schritten:

- Öffnen Sie Qt Creator und erstellen Sie eine neue *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Wählen Sie die QMake‑Option aus der Dropdown‑Liste *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Wählen Sie das passende Kit aus und schließen Sie den Assistenten ab.
- Kopieren Sie den Ordner aspose‑slides‑cpp‑21.02 aus dem extrahierten Paket von Aspose.Slides für C++ in das Stammverzeichnis des Projekts.

![lib_files](aspose.slides-lib-files.png)

- Um Pfade zu lib‑ und include‑Ordnern hinzuzufügen, klicken Sie mit der rechten Maustaste im linken Projekt‑Panel auf das Projekt und wählen Sie *Add Library*.

![qt_add_library](qt_add_library.png)

- Wählen Sie die Option External Library und durchsuchen Sie die Pfade zu den lib‑Ordnern einzeln.

![todo:image_alt_text](qt-add-external-library.png)

- Nach Abschluss enthält Ihre .pro‑Projektdatei die folgenden Einträge:

![qt_pro_file.png](qt-pro-file.png)

- Bauen Sie die Anwendung und die Integration ist abgeschlossen.  

{{% alert color="primary" %}}

Hinweis: Siehe das [vollständige Demoprojekt](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) für weitere Informationen.

{{% /alert %}}

## **Verwenden von Aspose.Slides für C++ in Qt‑Anwendungen mit Visual Studio**

Um eine Qt‑Anwendung mit Visual Studio zu entwickeln, müssen Sie [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123) installieren. Nachdem die Installation abgeschlossen ist, laden Sie die neueste Version der API aus dem Abschnitt [downloads](https://downloads.aspose.com/slides/cpp) herunter und befolgen Sie die unten angegebenen Schritte:

- Öffnen Sie Microsoft Visual Studio und erstellen Sie eine neue *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Wählen Sie das passende Kit aus und schließen Sie den Assistenten ab.
- Um die Aspose.Slides für C++‑Bibliothek zu integrieren und zu verwenden, klicken Sie mit der rechten Maustaste auf das Projekt und wählen Sie *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Suchen Sie das erforderliche *Aspose.Slides.Cpp*-Paket und installieren Sie es.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Bauen Sie das Projekt und die Integration ist abgeschlossen.  

{{% alert color="primary" %}}

Hinweis: Siehe das [vollständige Demoprojekt](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) für weitere Informationen.

{{% /alert %}}