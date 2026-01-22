---
title: PPTX in PPT mit C++ konvertieren
linktitle: PPTX zu PPT
type: docs
weight: 21
url: /de/cpp/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPTX konvertieren
- PPTX zu PPT
- PPTX als PPT speichern
- PPTX zu PPT exportieren
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Konvertieren Sie PPTX ganz einfach zu PPT mit Aspose.Slides für C++ — stellen Sie nahtlose Kompatibilität mit PowerPoint-Formaten sicher und bewahren Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation im PPTX-Format mit C++ in das PPT-Format konvertiert. Das folgende Thema wird behandelt.

- PPTX nach PPT in C++ konvertieren

## **PPTX nach PPT in C++ konvertieren**

Für C++-Beispielcode zum Konvertieren von PPTX nach PPT siehe den Abschnitt unten, d.h. [Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt lediglich die PPTX-Datei und speichert sie im PPT-Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX-Datei außerdem in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben. 

- [Convert PPTX to PDF in C++](/slides/de/cpp/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in C++](/slides/de/cpp/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in C++](/slides/de/cpp/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in C++](/slides/de/cpp/save-presentation/)
- [Convert PPTX to PNG in C++](/slides/de/cpp/convert-powerpoint-to-png/)

## **PPTX nach PPT konvertieren**
Um ein PPTX nach PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**-Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). Das C++-Codebeispiel unten konvertiert eine Präsentation von PPTX nach PPT mit den Standardoptionen.
```cpp
// Lade die PPTX.
// Im PPT-Format speichern.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Save in PPT format.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Überleben alle PPTX-Effekte und -Funktionen beim Speichern im klassischen PPT (97–2003)-Format?**

Nicht immer. Das PPT-Format weist einige neuere Funktionen nicht auf (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Features während der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren, anstatt die gesamte Präsentation?**

Direktes Speichern richtet sich an die gesamte Präsentation. Um einzelne Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern sie als PPT; alternativ können Sie einen Dienst/eine API verwenden, der/die per‑Folien‑Konvertierungsparameter unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und zudem die [configure protection/encryption settings](/slides/de/cpp/password-protected-presentation/) für das gespeicherte PPT festlegen.