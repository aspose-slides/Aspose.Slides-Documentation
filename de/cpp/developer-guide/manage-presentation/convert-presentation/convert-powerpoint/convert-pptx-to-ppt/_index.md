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
description: "PPTX mühelos mit Aspose.Slides für C++ nach PPT konvertieren — sorgen Sie für nahtlose Kompatibilität mit PowerPoint-Formaten und bewahren Sie Layout und Qualität Ihrer Präsentation."
---

## **Überblick**

Dieser Artikel erklärt, wie man eine PowerPoint‑Präsentation im PPTX‑Format mit C++ in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX nach PPT in C++

## **PPTX nach PPT in C++**

Für C++‑Beispielcode zur Konvertierung von PPTX nach PPT siehe den Abschnitt unten, also [PPTX nach PPT](#convert-pptx-to-ppt). Er lädt lediglich die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX‑Datei außerdem in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [C++ PPTX nach PDF konvertieren](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ PPTX nach XPS konvertieren](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ PPTX nach HTML konvertieren](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ PPTX nach ODP konvertieren](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ PPTX nach Bild konvertieren](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **PPTX nach PPT**
Um eine PPTX‑Datei in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**‑Methode der [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)‑Klasse. Der nachstehende C++‑Code‑Beispiel konvertiert eine Präsentation von PPTX nach PPT mit den Standardoptionen.
```cpp
// PPTX laden.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Im PPT-Format speichern.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **FAQ**

**Bleiben alle PPTX‑Effekte und -Funktionen erhalten, wenn sie im alten PPT‑Format (97–2003) gespeichert werden?**

Nicht immer. Das PPT‑Format verfügt nicht über einige neuere Möglichkeiten (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Funktionen bei der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren, anstatt die gesamte Präsentation?**

Das direkte Speichern zielt auf die gesamte Präsentation. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern Sie sie als PPT; alternativ verwenden Sie einen Service/eine API, die konvertierungsparameter pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und zudem die [Schutz‑/Verschlüsselungseinstellungen](/slides/de/cpp/password-protected-presentation/) für die gespeicherte PPT festlegen.