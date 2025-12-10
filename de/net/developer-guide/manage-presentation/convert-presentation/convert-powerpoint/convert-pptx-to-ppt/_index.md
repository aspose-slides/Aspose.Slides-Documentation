---
title: PPTX in PPT konvertieren in .NET
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
- PPTX zu PPT exportieren
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Konvertieren Sie PPTX mühelos zu PPT mit Aspose.Slides für .NET – gewährleisten Sie nahtlose Kompatibilität mit PowerPoint-Formaten und bewahren Sie das Layout und die Qualität Ihrer Präsentation."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint-Präsentationen im PPTX-Format in das PPT-Format konvertiert, wobei C# verwendet wird. Das folgende Thema wird behandelt.

- PPTX in PPT mit C# konvertieren

## **PPTX in PPT mit .NET konvertieren**

Für C#-Beispielcode zur Konvertierung von PPTX nach PPT siehe bitte den nachstehenden Abschnitt, nämlich [Convert PPTX to PPT](#convert-pptx-to-ppt). Er lädt lediglich die PPTX-Datei und speichert sie im PPT-Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX-Datei außerdem in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [C# PPTX nach PDF konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# PPTX nach XPS konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# PPTX nach HTML konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# PPTX nach ODP konvertieren](https://docs.aspose.com/slides/net/save-presentation/)
- [C# PPTX nach Bild konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPTX in PPT konvertieren**
Um ein PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) Methode der Klasse [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Der nachstehende C#-Code konvertiert eine Präsentation von PPTX nach PPT mit den Standardoptionen.
```c#
 // Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
 Presentation pres = new Presentation("presentation.pptx");

 // Speichern der PPTX-Präsentation im PPT-Format
 pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**Bleiben alle PPTX‑Effekte und -Funktionen beim Speichern im alten PPT‑Format (97–2003) erhalten?**

Nicht immer. Das PPT‑Format verfügt nicht über einige neuere Funktionen (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Features bei der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren, anstatt die gesamte Präsentation?**

Ein direktes Speichern richtet sich an die gesamte Präsentation. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern Sie sie als PPT; alternativ nutzen Sie einen Dienst bzw. eine API, die Parameter für die Konvertierung einzelner Folien unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und zudem die [Schutzeinstellungen/Encryption-Einstellungen konfigurieren](/slides/de/net/password-protected-presentation/) für das gespeicherte PPT konfigurieren.