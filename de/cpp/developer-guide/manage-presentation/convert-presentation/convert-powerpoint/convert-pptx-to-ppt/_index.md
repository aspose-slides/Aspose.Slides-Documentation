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
description: "Konvertieren Sie PPTX einfach in PPT mit Aspose.Slides für C++ – gewährleisten Sie nahtlose Kompatibilität mit PowerPoint-Formaten und erhalten dabei das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint‑Präsentation im PPTX‑Format in das PPT‑Format mit C++ konvertiert. Das folgende Thema wird behandelt.

- PPTX nach PPT in C++ konvertieren

## **PPTX nach PPT in C++ konvertieren**

Für Beispielcode in C++ zur Konvertierung von PPTX nach PPT siehe den Abschnitt unten, d. h. [Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [C++ PPTX nach PDF konvertieren](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ PPTX nach XPS konvertieren](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ PPTX nach HTML konvertieren](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ PPTX nach ODP konvertieren](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ PPTX nach Bild konvertieren](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **PPTX nach PPT konvertieren**
Um ein PPTX nach PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**‑Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). Das C++‑Codebeispiel unten konvertiert eine Presentation von PPTX nach PPT mit den Standardoptionen.
```cpp
// PPTX laden.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// In PPT-Format speichern.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Bleiben alle PPTX‑Effekte und -Funktionen beim Speichern im alten PPT‑Format (97‑2003) erhalten?**

Nicht immer. Das PPT‑Format fehlt es an einigen neueren Möglichkeiten (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Funktionen bei der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien nach PPT konvertieren statt der gesamten Präsentation?**

Direktes Speichern zielt auf die gesamte Präsentation ab. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation mit nur diesen Folien und speichern sie als PPT; alternativ können Sie einen Dienst/eine API verwenden, die Parameter für die Konvertierung pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können feststellen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und außerdem die [Schutz-/Verschlüsselungseinstellungen](/slides/de/cpp/password-protected-presentation/) für das gespeicherte PPT konfigurieren.