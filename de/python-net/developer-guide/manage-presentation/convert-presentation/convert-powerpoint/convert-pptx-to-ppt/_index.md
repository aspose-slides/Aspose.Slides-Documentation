---
title: Konvertieren von PPTX zu PPT in Python
linktitle: Konvertieren von PPTX zu PPT
type: docs
weight: 21
url: /de/python-net/convert-pptx-to-ppt/
keywords: "Python Konvertieren PPTX zu PPT, Konvertieren PowerPoint-Präsentation, PPTX zu PPT, Python, Aspose.Slides"
description: "Konvertieren von PowerPoint PPTX zu PPT in Python"
---

## **Überblick**

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation im PPTX-Format in das PPT-Format mit Python konvertiert. Das folgende Thema wird behandelt.

- Konvertieren von PPTX zu PPT in Python

## **Python Konvertieren PPTX zu PPT**

Für den Python-Beispielcode zur Konvertierung von PPTX zu PPT siehe den untenstehenden Abschnitt d.h. [Konvertieren von PPTX zu PPT](#convert-pptx-to-ppt). Es lädt einfach die PPTX-Datei und speichert sie im PPT-Format. Durch die Angabe unterschiedlicher Speicherformate können Sie die PPTX-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln besprochen.

- [Python Konvertieren PPTX zu PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Konvertieren PPTX zu XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Konvertieren PPTX zu HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Konvertieren PPTX zu ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Konvertieren PPTX zu Bild](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **Konvertieren von PPTX zu PPT**
Um eine PPTX in PPT zu konvertieren, übergeben Sie einfach den Dateinamen und das Speicherformat an die [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode der [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse. Der folgende Python-Codebeispiel konvertiert eine Präsentation von PPTX zu PPT unter Verwendung der Standardoptionen.

```py
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
pres = slides.Presentation("presentation.pptx")

# Speichern der PPTX-Präsentation im PPT-Format
pres.save("presentation.ppt", slides.export.SaveFormat.PPT)
```