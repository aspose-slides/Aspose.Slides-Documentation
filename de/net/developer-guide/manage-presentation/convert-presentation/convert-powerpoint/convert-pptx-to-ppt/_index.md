---
title: Konvertieren von PPTX in PPT in C#
linktitle: Konvertieren von PPTX in PPT
type: docs
weight: 21
url: /de/net/convert-pptx-to-ppt/
keywords: "C# Konvertieren von PPTX in PPT, PowerPoint-Präsentation konvertieren, PPTX in PPT, C#, Aspose.Slides"
description: "Konvertieren Sie PowerPoint PPTX in PPT in C#"
---

## **Überblick**

In diesem Artikel wird erklärt, wie man eine PowerPoint-Präsentation im PPTX-Format in das PPT-Format mit C# konvertiert. Das folgende Thema wird behandelt.

- Konvertieren von PPTX in PPT in C#

## **C# Konvertieren von PPTX in PPT**

Für Beispielcode in C#, um PPTX in PPT zu konvertieren, siehe bitte den folgenden Abschnitt, d.h. [Konvertieren von PPTX in PPT](#convert-pptx-to-ppt). Es wird einfach die PPTX-Datei geladen und im PPT-Format gespeichert. Durch Angabe verschiedener Speicherformate können Sie die PPTX-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln besprochen.

- [C# Konvertieren von PPTX in PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# Konvertieren von PPTX in XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# Konvertieren von PPTX in HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# Konvertieren von PPTX in ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# Konvertieren von PPTX in Bild](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **Konvertieren von PPTX in PPT**
Um eine PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) Methode der [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse. Der folgende C#-Code konvertiert eine Präsentation von PPTX in PPT unter Verwendung der Standardoptionen.

```c#
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("presentation.pptx");

// Speichern der PPTX-Präsentation im PPT-Format
pres.Save("presentation.ppt", SaveFormat.Ppt);
```