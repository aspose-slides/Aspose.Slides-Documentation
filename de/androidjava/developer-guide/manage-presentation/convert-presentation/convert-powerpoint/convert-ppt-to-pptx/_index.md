---
title: PPT in PPTX auf Android konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Konvertieren Sie alte PPT-Präsentationen schnell in modernes PPTX in Java mit Aspose.Slides für Android - klare Anleitung, kostenlose Code-Beispiele, keine Abhängigkeit von Microsoft Office."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint-Präsentationen im PPT-Format mit Java und einer Online-PPT-zu-PPTX-Konvertierungs-App in das PPTX-Format konvertiert. Das folgende Thema wird behandelt.

- PPT in PPTX mit Java konvertieren

## **PPT in PPTX unter Android konvertieren**

Für Beispielcode in Java zum Konvertieren von PPT zu PPTX siehe bitte den untenstehenden Abschnitt, d. h. [Convert PPT to PPTX](#convert-ppt-to-pptx). Er lädt einfach die PPT-Datei und speichert sie im PPTX-Format. Durch Angabe verschiedener Speicherformate können Sie die PPT-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [Java PPT in PDF konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java PPT in XPS konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java PPT in HTML konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java PPT in ODP konvertieren](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java PPT in Bild konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **Über die PPT-zu-PPTX-Konvertierung**

Konvertieren Sie alte PPT-Formate mit der Aspose.Slides-API in PPTX. Wenn Sie Tausende von PPT-Präsentationen in das PPTX-Format konvertieren müssen, ist die beste Lösung, dies programmgesteuert zu tun. Mit der Aspose.Slides-API ist es möglich, dies mit wenigen Codezeilen zu erledigen. Die API unterstützt volle Kompatibilität zum Konvertieren von PPT-Präsentationen in PPTX und ermöglicht Folgendes:

- Komplexe Strukturen von Masterfolien, Layouts und Folien konvertieren.
- Präsentationen mit Diagrammen konvertieren.
- Präsentationen mit Gruppierungen, Autoformen (wie Rechtecken und Ellipsen) und Formen mit benutzerdefinierter Geometrie konvertieren.
- Präsentationen, die Texturen und Bildfüllungen für Autoformen enthalten, konvertieren.
- Präsentationen mit Platzhaltern, Textfeldern und Textbausteinen konvertieren.

{{% alert color="primary" %}} 

Werfen Sie einen Blick auf die [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx)-App:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App wurde auf der Grundlage der [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/) erstellt, sodass Sie ein Live‑Beispiel für grundlegende PPT‑zu‑PPTX‑Konvertierungsfunktionen sehen können. Aspose.Slides Conversion ist eine Web‑App, die es ermöglicht, eine Präsentationsdatei im PPT‑Format per Drag‑&‑Drop hochzuladen und die konvertierte PPTX‑Datei herunterzuladen.

Weitere Live‑Beispiele für [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) finden Sie.
{{% /alert %}} 

## **PPT in PPTX konvertieren**

Aspose.Slides für Android via Java ermöglicht es Entwicklern nun, über die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) auf PPT zuzugreifen und diese in das entsprechende [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Format zu konvertieren. Derzeit wird eine teilweise Konvertierung von [PPT](https://docs.fileformat.com/presentation/ppt/) nach PPTX unterstützt. Weitere Details zu unterstützten und nicht unterstützten Funktionen bei der PPT‑zu‑PPTX‑Konvertierung finden Sie in dieser Dokumentation [link](/slides/de/androidjava/ppt-to-pptx-conversion/).

Aspose.Slides für Android via Java bietet die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation), die eine **PPTX**‑Präsentationsdatei darstellt. Die Presentation‑Klasse kann nun auch **PPT** über Presentation zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine PPT‑Präsentation in eine PPTX‑Präsentation konvertiert.
```java
// Instanziieren Sie ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
Presentation pres = new Presentation("Aspose.ppt");
try {
// Speichern der PPTX-Präsentation im PPTX-Format
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Abbildung: Quell‑PPT‑Präsentation**|

Der obige Codeabschnitt erzeugte die folgende PPTX‑Präsentation nach der Konvertierung

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Abbildung: Generierte PPTX‑Präsentation nach der Konvertierung**|

## **FAQ**

**Was ist der Unterschied zwischen den Formaten PPT und PPTX?**

PPT ist das ältere binäre Dateiformat, das von Microsoft PowerPoint verwendet wird, während PPTX das neuere XML‑basierte Format ist, das mit Microsoft Office 2007 eingeführt wurde. PPTX‑Dateien bieten bessere Leistung, geringere Dateigröße und verbesserte Datenwiederherstellung.

**Unterstützt Aspose.Slides die Stapelkonvertierung mehrerer PPT‑Dateien zu PPTX?**

Ja, Sie können Aspose.Slides in einer Schleife verwenden, um mehrere PPT‑Dateien programmgesteuert zu PPTX zu konvertieren, was es für Stapelkonvertierungsszenarien geeignet macht.

**Werden Inhalt und Formatierung nach der Konvertierung beibehalten?**

Aspose.Slides gewährleistet eine hohe Treue bei der Konvertierung von Präsentationen. Folienlayouts, Animationen, Formen, Diagramme und andere Designelemente bleiben bei der PPT‑zu‑PPTX‑Konvertierung erhalten.

**Kann ich andere Formate wie PDF oder HTML aus PPT‑Dateien konvertieren?**

Ja, Aspose.Slides unterstützt die Konvertierung von PPT‑Dateien in [multiple formats](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/), einschließlich PDF, XPS, HTML, ODP und Bildformate wie PNG und JPEG.

**Ist es möglich, PPT nach PPTX zu konvertieren, ohne Microsoft PowerPoint installiert zu haben?**

Ja, Aspose.Slides ist eine eigenständige API und erfordert weder Microsoft PowerPoint noch irgendeine Drittanbieter‑Software für die Durchführung der Konvertierung.

**Gibt es ein Online‑Werkzeug für die PPT‑zu‑PPTX‑Konvertierung?**

Ja, Sie können die kostenlose [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web‑Anwendung nutzen, um die Konvertierung direkt in Ihrem Browser durchzuführen, ohne Code zu schreiben.