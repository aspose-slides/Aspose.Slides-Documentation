---
title: PPTX nach PPT in C++ konvertieren
linktitle: PPTX nach PPT
type: docs
weight: 21
url: /de/cpp/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPTX konvertieren
- PPTX nach PPT
- PPTX als PPT speichern
- PPTX nach PPT exportieren
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Konvertieren Sie PPTX mühelos nach PPT mit Aspose.Slides für C++ – stellen Sie nahtlose Kompatibilität mit PowerPoint-Formaten sicher und bewahren Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPTX‑Format mit C++ in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX nach PPT in C++ konvertieren

## **PPTX nach PPT in C++ konvertieren**

Für C++‑Beispielcode zum Konvertieren von PPTX nach PPT siehe bitte den Abschnitt unten, also [Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt lediglich die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln erläutert. 

- [C++ Convert PPTX zu PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Convert PPTX zu XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Convert PPTX zu HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Convert PPTX zu ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Convert PPTX zu Bild](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **PPTX nach PPT**

Um ein PPTX nach PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**‑Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) . Das C++‑Codebeispiel unten konvertiert eine Presentation von PPTX nach PPT mit den Standardoptionen.
```cpp
// PPTX laden.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Im PPT-Format speichern.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Überleben alle PPTX‑Effekte und‑Funktionen beim Speichern im alten PPT (97–2003)-Format?**

Nicht immer. Das PPT‑Format fehlt es an einigen neueren Funktionen (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Features bei der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren statt der gesamten Präsentation?**

Direktes Speichern richtet sich an die gesamte Präsentation. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern Sie sie als PPT; alternativ können Sie einen Dienst/eine API verwenden, die per‑Folien‑Konvertierungsparameter unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und zudem [Schutz-/Verschlüsselungseinstellungen](/slides/de/cpp/password-protected-presentation/) für das gespeicherte PPT konfigurieren.