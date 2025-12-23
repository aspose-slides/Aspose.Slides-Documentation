---
title: PPT zu PPTX in PHP konvertieren
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
description: "Konvertieren Sie alte PPT-Präsentationen schnell in moderne PPTX mit Aspose.Slides für PHP via Java - klare Anleitung, kostenlose Code-Beispiele, keine Microsoft-Office-Abhängigkeit."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPT‑Format mit PHP und einer Online‑PPT‑zu‑PPTX‑Konvertierungs‑App in das PPTX‑Format konvertiert. Das folgende Thema wird behandelt.

- PPT in PPTX konvertieren

## **PPT in PPTX mit PHP konvertieren**

Für Beispielcode in Java zum Konvertieren von PPT nach PPTX siehe den Abschnitt unten, d. h. [Convert PPT to PPTX](#convert-ppt-to-pptx). Er lädt lediglich die PPT‑Datei und speichert sie im PPTX‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPT‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [Java PPT nach PDF konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java PPT nach XPS konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java PPT nach HTML konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java PPT nach ODP konvertieren](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java PPT in Bild konvertieren](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **Über die PPT‑zu‑PPTX‑Konvertierung**
Konvertieren Sie das alte PPT‑Format mit der Aspose.Slides‑API in PPTX. Wenn Sie Tausende von PPT‑Präsentationen in das PPTX‑Format konvertieren müssen, ist die beste Lösung, dies programmgesteuert zu tun. Mit der Aspose.Slides‑API ist dies in nur wenigen Codezeilen möglich. Die API bietet volle Kompatibilität, um PPT‑Präsentationen in PPTX zu konvertieren, und ermöglicht:

- Komplexe Strukturen von Master‑Folien, Layouts und Folien konvertieren.
- Präsentationen mit Diagrammen konvertieren.
- Präsentationen mit Gruppierungen, Autoformen (wie Rechtecken und Ellipsen) und Formen mit benutzerdefinierter Geometrie konvertieren.
- Präsentationen mit Texturen und Bildfüllungen für Autoformen konvertieren.
- Präsentationen mit Platzhaltern, Textfeldern und Textbehältern konvertieren.

{{% alert color="primary" %}} 

Werfen Sie einen Blick auf die [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx)‑App:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App basiert auf der [**Aspose.Slides API**](https://products.aspose.com/slides/php-java/), sodass Sie ein funktionierendes Beispiel für grundlegende PPT‑zu‑PPTX‑Konvertierungsfunktionen sehen können. Aspose.Slides Conversion ist eine Web‑App, die es ermöglicht, eine Präsentationsdatei im PPT‑Format per Drag‑&‑Drop hochzuladen und sie anschließend als PPTX herunterzuladen.

Weitere Live‑Beispiele für [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) finden Sie.
{{% /alert %}} 

## **PPT in PPTX konvertieren**
Aspose.Slides für PHP via Java ermöglicht es Entwicklern nun, über die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasseninstanz auf PPT zuzugreifen und sie in das entsprechende [PPTX](https://docs.fileformat.com/presentation/pptx/)-Format zu konvertieren. Derzeit unterstützt sie die Teilkonvertierung von [PPT](https://docs.fileformat.com/presentation/ppt/) nach PPTX. Weitere Details zu unterstützten und nicht unterstützten Funktionen der PPT‑zu‑PPTX‑Konvertierung finden Sie in dieser Dokumentation [link](/slides/de/php-java/ppt-to-pptx-conversion/).

Aspose.Slides für PHP via Java bietet die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse, die eine **PPTX**‑Präsentationsdatei repräsentiert. Die Presentation‑Klasse kann nun auch **PPT** über Presentation zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie eine PPT‑Präsentation in eine PPTX‑Präsentation konvertiert wird.
```php
  # Instanziiere ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
  $pres = new Presentation("Aspose.ppt");
  try {
    # Speichere die PPTX-Präsentation im PPTX-Format
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Abbildung : Ausgangspräsentation PPT**|

Der obige Codeausschnitt erzeugte die folgende PPTX‑Präsentation nach der Konvertierung

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Abbildung: Generierte PPTX‑Präsentation nach der Konvertierung**|

## **FAQ**

**Was ist der Unterschied zwischen den Formaten PPT und PPTX?**

PPT ist das ältere binäre Dateiformat, das von Microsoft PowerPoint verwendet wird, während PPTX das neuere, XML‑basierte Format ist, das mit Microsoft Office 2007 eingeführt wurde. PPTX‑Dateien bieten bessere Leistung, geringere Dateigröße und verbesserte Datenwiederherstellung.

**Unterstützt Aspose.Slides die Stapelkonvertierung mehrerer PPT‑Dateien zu PPTX?**

Ja, Sie können Aspose.Slides in einer Schleife verwenden, um mehrere PPT‑Dateien programmgesteuert in PPTX zu konvertieren, was es für Stapelkonvertierungsszenarien geeignet macht.

**Werden Inhalt und Formatierung nach der Konvertierung beibehalten?**

Aspose.Slides gewährleistet eine hohe Treue bei der Konvertierung von Präsentationen. Folienlayout, Animationen, Formen, Diagramme und andere Designelemente bleiben während der PPT‑zu‑PPTX‑Konvertierung erhalten.

**Kann ich andere Formate wie PDF oder HTML aus PPT‑Dateien konvertieren?**

Ja, Aspose.Slides unterstützt die Konvertierung von PPT‑Dateien in [mehrere Formate](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/), einschließlich PDF, XPS, HTML, ODP und Bildformate wie PNG und JPEG.

**Ist es möglich, PPT nach PPTX zu konvertieren, ohne Microsoft PowerPoint installiert zu haben?**

Ja, Aspose.Slides ist eine eigenständige API und erfordert weder Microsoft PowerPoint noch andere Drittanbieter‑Software zur Durchführung der Konvertierung.

**Gibt es ein Online‑Tool für die PPT‑zu‑PPTX‑Konvertierung?**

Ja, Sie können die kostenlose [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web‑Anwendung verwenden, um die Konvertierung direkt in Ihrem Browser durchzuführen, ohne Code zu schreiben.