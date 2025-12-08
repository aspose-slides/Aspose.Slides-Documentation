---
title: Convert PPT to PPTX in Python
linktitle: PPT to PPTX
type: docs
weight: 20
url: /de/python-net/convert-ppt-to-pptx/
keywords:
- PPT konvertieren
- PPT nach PPTX
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Konvertieren Sie alte PPT‑Präsentationen schnell in moderne PPTX mit Python und Aspose.Slides — klare Anleitung, kostenlose Beispielcodes, keine Abhängigkeit von Microsoft Office."
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint‑Präsentation im PPT‑Format in das PPTX‑Format konvertiert, sowohl mit Python als auch mit einer Online‑App zur PPT‑zu‑PPTX‑Konvertierung. Folgendes Thema wird behandelt:

- PPT zu PPTX in Python

## **Python PPT zu PPTX konvertieren**

Für Beispielcode in Python zum Konvertieren von PPT zu PPTX siehe bitte den Abschnitt unten, d. h. [Convert PPT to PPTX](#convert-ppt-to-pptx). Er lädt einfach die PPT‑Datei und speichert sie im PPTX‑Format. Durch Angabe verschiedener Speicherformate können Sie eine PPT‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in den folgenden Artikeln beschrieben:

- [Python PPT zu PDF konvertieren](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python PPT zu XPS konvertieren](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python PPT zu HTML konvertieren](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python PPT zu ODP konvertieren](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python PPT zu Bild konvertieren](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **Über die PPT‑zu‑PPTX‑Konvertierung**
Konvertieren Sie das alte PPT‑Format mit der Aspose.Slides API in PPTX. Wenn Sie Tausende von PPT‑Präsentationen in PPTX konvertieren müssen, ist die beste Lösung, dies programmgesteuert zu tun. Mit der Aspose.Slides API ist es möglich, dies in nur wenigen Codezeilen zu erledigen. Die API unterstützt vollständige Kompatibilität zur Konvertierung einer PPT‑Präsentation in PPTX und ermöglicht:

- Konvertierung komplexer Strukturen von Master‑Folien, Layouts und Folien.
- Konvertierung einer Präsentation mit Diagrammen.
- Konvertierung einer Präsentation mit Gruppierungen, Auto‑Shapes (wie Rechtecken und Ellipsen) und Formen mit benutzerdefinierter Geometrie.
- Konvertierung einer Präsentation mit Texturen und Bildfüllungen für Auto‑Shapes.
- Konvertierung einer Präsentation mit Platzhaltern, Textfeldern und Text‑Halterungen.

{{% alert color="primary" %}}

Werfen Sie einen Blick auf die [**Aspose.Slides PPT zu PPTX Konvertierung**](https://products.aspose.app/slides/conversion/ppt-to-pptx)‑App:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App basiert auf der **Aspose.Slides API**, sodass Sie ein Live‑Beispiel für die Grundfunktionen der PPT‑zu‑PPTX‑Konvertierung sehen können. Aspose.Slides Conversion ist eine Web‑App, mit der Sie eine Präsentationsdatei im PPT‑Format hochladen und sie als PPTX herunterladen können.

Weitere Live‑Beispiele für **Aspose.Slides Konvertierung** finden Sie unter https://products.aspose.app/slides/conversion/.
{{% /alert %}}

## **PPT zu PPTX konvertieren**
Um ein PPT in PPTX zu konvertieren, übergeben Sie einfach den Dateinamen und das Ziel‑Format an die [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Methode der [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse. Das untenstehende Python‑Beispiel konvertiert eine Präsentation von PPT nach PPTX mit den Standardeinstellungen.
```python
import aspose.slides as slides

# Instanziieren Sie ein Presentation-Objekt, das eine PPT-Datei darstellt
pres = slides.Presentation("PPTtoPPTX.ppt")

# Speichern Sie die Präsentation im PPTX-Format
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


Lesen Sie mehr über die Präsentationsformate [**PPT vs PPTX**](/slides/de/python-net/ppt-vs-pptx/) und darüber, wie [**Aspose.Slides die PPT‑zu‑PPTX‑Konvertierung unterstützt**](/slides/de/python-net/convert-ppt-to-pptx/).

## **FAQ**

**Was ist der Unterschied zwischen den Formaten PPT und PPTX?**

PPT ist das ältere binäre Dateiformat, das von Microsoft PowerPoint verwendet wird, während PPTX das neuere, auf XML basierende Format ist, das mit Microsoft Office 2007 eingeführt wurde. PPTX‑Dateien bieten bessere Leistung, geringere Dateigröße und eine verbesserte Datenwiederherstellung.

**Kann ich PPT mit Python in PPTX konvertieren?**

Ja, mit der Aspose.Slides for Python via .NET‑Bibliothek können Sie problemlos eine PPT‑Datei laden und sie mit wenigen Codezeilen im PPTX‑Format speichern.

**Unterstützt Aspose.Slides die Batch‑Konvertierung mehrerer PPT‑Dateien zu PPTX?**

Ja, Sie können Aspose.Slides in einer Schleife verwenden, um mehrere PPT‑Dateien programmgesteuert in PPTX zu konvertieren, was sich für Batch‑Szenarien eignet.

**Werden Inhalt und Formatierung nach der Konvertierung beibehalten?**

Aspose.Slides erhält eine hohe Treue bei der Konvertierung von Präsentationen. Folienlayouts, Animationen, Formen, Diagramme und andere Designelemente bleiben während der PPT‑zu‑PPTX‑Konvertierung erhalten.

**Kann ich aus PPT‑Dateien andere Formate wie PDF oder HTML konvertieren?**

Ja, Aspose.Slides unterstützt die Konvertierung von PPT‑Dateien in mehrere Formate, darunter PDF, XPS, HTML, ODP und Bildformate wie PNG und JPEG.

**Ist es möglich, PPT ohne installiertes Microsoft PowerPoint in PPTX zu konvertieren?**

Ja, Aspose.Slides for Python via .NET ist eine eigenständige API und erfordert weder Microsoft PowerPoint noch Drittanbieter‑Software für die Konvertierung.

**Gibt es ein Online‑Tool für die PPT‑zu‑PPTX‑Konvertierung?**

Ja, Sie können den kostenlosen [Aspose.Slides PPT‑zu‑PPTX‑Konverter](https://products.aspose.app/slides/conversion/ppt-to-pptx) als Web‑Anwendung nutzen, um die Konvertierung direkt im Browser durchzuführen, ohne Code zu schreiben.
