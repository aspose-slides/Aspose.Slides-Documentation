---
title: PPTX nach PPT in .NET konvertieren
linktitle: PPTX zu PPT
type: docs
weight: 21
url: /de/net/convert-pptx-to-ppt/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPTX konvertieren
- PPTX zu PPT
- PPTX als PPT speichern
- PPTX nach PPT exportieren
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PPTX problemlos zu PPT mit Aspose.Slides für .NET — stellen Sie nahtlose Kompatibilität mit PowerPoint-Formaten sicher und bewahren Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPTX‑Format mit C# in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX in PPT konvertieren in C#

## **C# PPTX in PPT konvertieren**

Für C#‑Beispielcode zum Konvertieren von PPTX in PPT siehe den Abschnitt unten, d.h. [Convert PPTX to PPT](#convert-pptx-to-ppt). Es lädt einfach die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [C# Convert PPTX to PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Convert PPTX to XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Convert PPTX to HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Convert PPTX to ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Convert PPTX to Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPTX in PPT konvertieren**
Um ein PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑Methode der [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse. Das C#‑Codebeispiel unten konvertiert eine Präsentation von PPTX nach PPT mit den Standardeinstellungen.
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("presentation.pptx");

// Speichern der PPTX-Präsentation im PPT-Format
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**Bleiben alle PPTX‑Effekte und -Funktionen erhalten, wenn in das alte PPT‑Format (97–2003) gespeichert wird?**

Nicht immer. Das PPT‑Format unterstützt einige neuere Funktionen nicht (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Features während der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren statt der gesamten Präsentation?**

Das direkte Speichern richtet sich an die gesamte Präsentation. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern Sie sie als PPT; alternativ können Sie einen Dienst/API verwenden, der per‑Folie‑Konvertierungsparameter unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und zudem die [configure protection/encryption settings](/slides/de/net/password-protected-presentation/) für das gespeicherte PPT festlegen.