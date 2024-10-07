---
title: PPT in PPTX mit Python konvertieren
linktitle: PPT in PPTX konvertieren
type: docs
weight: 20
url: /python-net/convert-ppt-to-pptx/
keywords: "Python PPT in PPTX konvertieren, PowerPoint-Präsentation konvertieren, PPT in PPTX, Python, Aspose.Slides"
description: "PowerPoint PPT in PPTX mit Python konvertieren"
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint-Präsentationen im PPT-Format in das PPTX-Format mit Python und einer Online-App zur Konvertierung von PPT in PPTX umwandelt. Das folgende Thema wird behandelt.

- PPT in PPTX mit Python konvertieren

## **Python PPT in PPTX konvertieren**

Für Beispielcode in Python zur Konvertierung von PPT in PPTX siehe den folgenden Abschnitt, d.h. [PPT in PPTX konvertieren](#convert-ppt-to-pptx). Es lädt einfach die PPT-Datei und speichert sie im PPTX-Format. Durch Angabe verschiedener Speicherformate kannst du die PPT-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln besprochen.

- [Python PPT in PDF konvertieren](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python PPT in XPS konvertieren](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python PPT in HTML konvertieren](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python PPT in ODP konvertieren](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python PPT in Bild konvertieren](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **Über die Konvertierung von PPT in PPTX**
Konvertiere das alte PPT-Format in PPTX mit der Aspose.Slides-API. Wenn du Tausende von PPT-Präsentationen in das PPTX-Format konvertieren musst, ist die beste Lösung, dies programmgesteuert zu tun. Mit der Aspose.Slides-API ist es möglich, dies in nur wenigen Codezeilen zu erledigen. Die API unterstützt volle Kompatibilität zur Konvertierung von PPT-Präsentationen in PPTX und es ist möglich:

- Komplizierte Strukturen von Masterfolien, Layouts und Folien zu konvertieren.
- Präsentationen mit Diagrammen zu konvertieren.
- Präsentationen mit Gruppierungen, Autoshapes (wie Rechtecke und Ellipsen), Shapes mit benutzerdefinierter Geometrie zu konvertieren.
- Präsentationen zu konvertieren, die Texturen und Bilderfüllstile für Autoshapes haben.
- Präsentationen mit Platzhaltern, Textfeldern und Textcontainern zu konvertieren.

{{% alert color="primary" %}} 

Sieh dir die [**Aspose.Slides PPT zu PPTX Konvertierung**](https://products.aspose.app/slides/conversion/ppt-to-pptx) App an:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App basiert auf der **Aspose.Slides API**, sodass du ein live Beispiel der grundlegenden PPT zu PPTX-Konvertierungsfähigkeiten sehen kannst. Die Aspose.Slides-Konvertierung ist eine Web-App, die es ermöglicht, Präsentationsdateien im PPT-Format hochzuladen und die konvertierte Version im PPTX-Format herunterzuladen.

Finde weitere Live- [**Aspose.Slides Konvertierung**](https://products.aspose.app/slides/conversion/) Beispiele.
{{% /alert %}} 

## **PPT in PPTX konvertieren**
Um eine PPT in PPTX zu konvertieren, übergib einfach den Dateinamen und das Speicherformat an die [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Methode der [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse. Der folgende Python-Code konvertiert eine Präsentation von PPT in PPTX mit den Standardoptionen.

```py
import aspose.slides as slides

# Instanziiere ein Präsentationsobjekt, das eine PPTX-Datei darstellt
pres = slides.Presentation("PPTtoPPTX.ppt")

# Speichern der PPTX-Präsentation im PPTX-Format
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

Lies mehr über die [**Unterschiede zwischen PPT und PPTX**](/slides/python-net/ppt-vs-pptx/) Präsentationsformate und wie [**Aspose.Slides PPT in PPTX konvertiert**](/slides/python-net/convert-ppt-to-pptx/).