---
title: Konvertieren von PPTX nach PPT in C#
linktitle: PPTX nach PPT konvertieren
type: docs
weight: 21
url: /de/net/convert-pptx-to-ppt/
keywords: "C# PPTX nach PPT konvertieren, PowerPoint-Präsentation konvertieren, PPTX nach PPT, C#, Aspose.Slides"
description: "PowerPoint-PPTX nach PPT in C# konvertieren"
---

## **Überblick**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPTX‑Format mit C# in das PPT‑Format konvertiert. Das folgende Thema wird behandelt.

- PPTX nach PPT in C# konvertieren

## **C# PPTX nach PPT konvertieren**

Für Beispielcode in C# zum Konvertieren von PPTX nach PPT siehe den Abschnitt unten, d. h. [PPTX nach PPT konvertieren](#convert-pptx-to-ppt). Es lädt lediglich die PPTX‑Datei und speichert sie im PPT‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPTX‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben. 

- [C# PPTX nach PDF konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# PPTX nach XPS konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# PPTX nach HTML konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# PPTX nach ODP konvertieren](https://docs.aspose.com/slides/net/save-presentation/)
- [C# PPTX nach Bild konvertieren](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPTX nach PPT konvertieren**
Um ein PPTX nach PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)‑Methode der [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse. Der nachstehende C#‑Code konvertiert eine Presentation von PPTX nach PPT mit den Standardeinstellungen.
```c#
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("presentation.pptx");

// Speichern der PPTX-Präsentation im PPT-Format
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**Bleiben alle PPTX‑Effekte und -Funktionen beim Speichern im alten PPT‑Format (97–2003) erhalten?**

Nicht immer. Das PPT‑Format fehlen einige neuere Möglichkeiten (z. B. bestimmte Effekte, Objekte und Verhaltensweisen), sodass Funktionen bei der Konvertierung vereinfacht oder gerastert werden können.

**Kann ich nur ausgewählte Folien in PPT konvertieren statt der gesamten Präsentation?**

Das direkte Speichern zielt auf die gesamte Präsentation ab. Um bestimmte Folien zu konvertieren, erstellen Sie eine neue Präsentation, die nur diese Folien enthält, und speichern sie als PPT; alternativ können Sie einen Dienst/API verwenden, der Parameter für die konvertierung pro Folie unterstützt.

**Werden passwortgeschützte Präsentationen unterstützt?**

Ja. Sie können erkennen, ob eine Datei geschützt ist, sie mit einem Passwort öffnen und auch [Schutzeinstellungen/​Verschlüsselung konfigurieren](/slides/de/net/password-protected-presentation/) für die gespeicherte PPT festlegen.