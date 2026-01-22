---
title: PPT nach PPTX in PHP konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/php-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPT zu PPTX
- PPT als PPTX speichern
- PPT nach PPTX exportieren
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Konvertieren Sie alte PPT‑Präsentationen schnell in moderne PPTX mit Aspose.Slides für PHP via Java — klare Anleitung, kostenlose Code‑Beispiele, keine Abhängigkeit von Microsoft Office."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPT‑Format mithilfe von PHP und einer Online‑PPT‑zu‑PPTX‑Konvertierungs‑App in das PPTX‑Format konvertiert. Das folgende Thema wird behandelt.

- PPT zu PPTX konvertieren

## **PPT zu PPTX in PHP**

Für Java‑Beispielcode zum Konvertieren von PPT zu PPTX siehe den Abschnitt unten, d.h. [Convert PPT to PPTX](#convert-ppt-to-pptx). Es lädt lediglich die PPT‑Datei und speichert sie im PPTX‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPT‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. konvertieren, wie in diesen Artikeln beschrieben.

- [PPT zu PDF in PHP](/slides/de/php-java/convert-powerpoint-to-pdf/)
- [PPT zu XPS in PHP](/slides/de/php-java/convert-powerpoint-to-xps/)
- [PPT zu HTML in PHP](/slides/de/php-java/convert-powerpoint-to-html/)
- [PPT zu ODP in PHP](/slides/de/php-java/save-presentation/)
- [PPT zu PNG in PHP](/slides/de/php-java/convert-powerpoint-to-png/)

## **Über die PPT zu PPTX‑Konvertierung**
Konvertieren Sie das alte PPT‑Format mit der Aspose.Slides‑API in PPTX. Wenn Sie Tausende von PPT‑Präsentationen in das PPTX‑Format umwandeln müssen, ist die beste Lösung, dies programmgesteuert zu tun. Mit der Aspose.Slides‑API ist es möglich, dies mit nur wenigen Code‑Zeilen zu erledigen. Die API bietet volle Kompatibilität für die Konvertierung von PPT‑Präsentationen zu PPTX und ermöglicht:

- Konvertierung komplexer Strukturen von Master‑Folien, Layouts und Folien.
- Konvertierung von Präsentationen mit Diagrammen.
- Konvertierung von Präsentationen mit Gruppierungen, Autoformen (wie Rechtecken und Ellipsen) und Formen mit benutzerdefinierter Geometrie.
- Konvertierung von Präsentationen mit Texturen und Bildfüllungen für Autoformen.
- Konvertierung von Präsentationen mit Platzhaltern, Textfeldern und Textträgern.

{{% alert color="primary" %}} 

Werfen Sie einen Blick auf die **Aspose.Slides PPT‑zu‑PPTX‑Konvertierung**‑App:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App basiert auf der **Aspose.Slides‑API**, sodass Sie ein funktionierendes Beispiel für die Grundfunktionen der PPT‑zu‑PPTX‑Konvertierung sehen können. Aspose.Slides Conversion ist eine Web‑App, die das Hochladen einer Präsentationsdatei im PPT‑Format ermöglicht und den konvertierten PPTX‑Download bereitstellt.

Weitere Live‑Beispiele zur **Aspose.Slides‑Conversion** finden Sie hier:
{{% /alert %}} 

## **PPT zu PPTX konvertieren**
Aspose.Slides für PHP via Java ermöglicht Entwicklern den Zugriff auf PPT über die Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) und die Konvertierung in das entsprechende [PPTX](https://docs.fileformat.com/presentation/pptx/)-Format. Derzeit unterstützt es die teilweise Konvertierung von [PPT](https://docs.fileformat.com/presentation/ppt/) zu PPTX. Weitere Details zu unterstützten und nicht unterstützten Funktionen der PPT‑zu‑PPTX‑Konvertierung finden Sie in dieser Dokumentation [link](/slides/de/php-java/ppt-to-pptx-conversion/).

Aspose.Slides für PHP via Java bietet die Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation), die eine **PPTX**‑Präsentationsdatei repräsentiert. Die Presentation‑Klasse kann jetzt auch **PPT** über ein Presentation‑Objekt laden, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie eine PPT‑Präsentation in eine PPTX‑Präsentation konvertiert wird.
```php
  # Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei darstellt
  $pres = new Presentation("Aspose.ppt");
  try {
    # Speichern der PPTX-Präsentation im PPTX-Format
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Abbildung : Ausgangs‑PPT‑Präsentation**|

Der obige Code‑Abschnitt erzeugte nach der Konvertierung die folgende PPTX‑Präsentation:

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Abbildung: Generierte PPTX‑Präsentation nach der Konvertierung**|

## **FAQ**

**Was ist der Unterschied zwischen den Formaten PPT und PPTX?**

PPT ist das ältere binäre Dateiformat von Microsoft PowerPoint, während PPTX das neuere XML‑basierte Format ist, das mit Microsoft Office 2007 eingeführt wurde. PPTX‑Dateien bieten bessere Leistung, geringere Dateigröße und verbesserte Datenwiederherstellung.

**Unterstützt Aspose.Slides die Stapelkonvertierung mehrerer PPT‑Dateien zu PPTX?**

Ja, Sie können Aspose.Slides in einer Schleife verwenden, um mehrere PPT‑Dateien programmgesteuert zu PPTX zu konvertieren, was sich für Stapelkonvertierungen eignet.

**Werden Inhalt und Formatierung nach der Konvertierung beibehalten?**

Aspose.Slides gewährleistet eine hohe Treue bei der Konvertierung von Präsentationen. Folienlayouts, Animationen, Formen, Diagramme und andere Designelemente bleiben während der PPT‑zu‑PPTX‑Konvertierung erhalten.

**Kann ich andere Formate wie PDF oder HTML aus PPT‑Dateien konvertieren?**

Ja, Aspose.Slides unterstützt die Konvertierung von PPT‑Dateien in [mehrere Formate](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/), einschließlich PDF, XPS, HTML, ODP sowie Bildformate wie PNG und JPEG.

**Ist es möglich, PPT zu PPTX zu konvertieren, ohne Microsoft PowerPoint installiert zu haben?**

Ja, Aspose.Slides ist eine eigenständige API und erfordert weder Microsoft PowerPoint noch Drittanbieter‑Software zur Durchführung der Konvertierung.

**Gibt es ein Online‑Tool für die PPT‑zu‑PPTX‑Konvertierung?**

Ja, Sie können die kostenlose **Aspose.Slides PPT‑zu‑PPTX‑Konverter**‑Webanwendung (https://products.aspose.app/slides/conversion/ppt-to-pptx) nutzen, um die Konvertierung direkt im Browser durchzuführen, ohne Code zu schreiben.