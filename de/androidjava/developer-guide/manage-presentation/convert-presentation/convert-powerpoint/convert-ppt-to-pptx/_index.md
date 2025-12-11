---
title: PPT nach PPTX auf Android konvertieren
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
description: "Konvertieren Sie veraltete PPT‑Präsentationen schnell in modernes PPTX mit Java und Aspose.Slides für Android — klare Anleitung, kostenlose Code‑Beispiele, keine Abhängigkeit von Microsoft Office."
---

## **Overview**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPT‑Format in das PPTX‑Format mit Java und mit einer Online‑PPT‑zu‑PPTX‑Konvertierungs‑App umwandelt. Das folgende Thema wird behandelt.

- PPT in Java in PPTX konvertieren

## **Convert PPT to PPTX on Android**

Den Java‑Beispielcode zur Konvertierung von PPT nach PPTX finden Sie im folgenden Abschnitt, d.h.[Convert PPT to PPTX](#convert-ppt-to-pptx). Er lädt einfach die PPT‑Datei und speichert sie im PPTX‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPT‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [Java PPT nach PDF konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java PPT nach XPS konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java PPT nach HTML konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java PPT nach ODP konvertieren](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java PPT nach Bild konvertieren](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **About PPT to PPTX Conversion**

Konvertieren Sie das alte PPT‑Format mit der Aspose.Slides API in PPTX. Wenn Sie Tausende von PPT‑Präsentationen in das PPTX‑Format konvertieren müssen, ist die beste Lösung, dies programmgesteuert zu tun. Mit der Aspose.Slides API ist es möglich, dies in nur wenigen Codezeilen zu erledigen. Die API unterstützt die vollständige Kompatibilität zur Konvertierung von PPT‑Präsentationen nach PPTX und ermöglicht:

- Komplexe Strukturen von Masterfolien, Layouts und Folien konvertieren.
- Präsentationen mit Diagrammen konvertieren.
- Präsentationen mit Gruppierungen, Autoformen (wie Rechtecken und Ellipsen) und Formen mit benutzerdefinierter Geometrie konvertieren.
- Präsentationen mit Textur‑ und Bildfüllungen für Autoformen konvertieren.
- Präsentationen mit Platzhaltern, Textfeldern und Textbehältern konvertieren.

{{% alert color="primary" %}} 

Werfen Sie einen Blick auf die [**Aspose.Slides PPT zu PPTX‑Konvertierung**](https://products.aspose.app/slides/conversion/ppt-to-pptx)‑App:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App basiert auf der [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/), sodass Sie ein konkretes Beispiel für grundlegende PPT‑zu‑PPTX‑Konvertierungsfunktionen sehen können. Aspose.Slides Conversion ist eine Web‑App, mit der Sie eine Präsentationsdatei im PPT‑Format hochladen und sie nach der Konvertierung als PPTX herunterladen können.

Weitere Live‑Beispiele für [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) finden Sie.
{{% /alert %}} 

## **Convert PPT to PPTX**

Aspose.Slides für Android via Java ermöglicht es Entwicklern nun, über die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) auf die PPT zuzugreifen und sie in das entsprechende [PPTX](https://docs.fileformat.com/presentation/pptx/)-Format zu konvertieren. Derzeit unterstützt sie die Teilkonvertierung von [PPT](https://docs.fileformat.com/presentation/ppt/) nach PPTX. Weitere Details zu unterstützten und nicht unterstützten Funktionen der PPT‑zu‑PPTX‑Konvertierung finden Sie in dieser Dokumentation [link](/slides/de/androidjava/ppt-to-pptx-conversion/).

Aspose.Slides für Android via Java bietet die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation), die eine **PPTX**‑Präsentationsdatei repräsentiert. Die Presentation‑Klasse kann nun auch über ein instanziiertes Objekt auf **PPT** zugreifen. Das folgende Beispiel zeigt, wie man eine PPT‑Präsentation in eine PPTX‑Präsentation konvertiert.
```java
// Instanziiert ein Presentation-Objekt, das eine PPTX-Datei darstellt
Presentation pres = new Presentation("Aspose.ppt");
try {
// Speichert die PPTX-Präsentation im PPTX-Format
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Abbildung: Quell‑PPT‑Präsentation**|

Der obige Code‑Auszug erzeugte nach der Konvertierung die folgende PPTX‑Präsentation

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Abbildung: Generierte PPTX‑Präsentation nach der Konvertierung**|

## **FAQ**

**Was ist der Unterschied zwischen den Formaten PPT und PPTX?**

PPT ist das ältere binäre Dateiformat, das von Microsoft PowerPoint verwendet wird, während PPTX das neuere, auf XML basierende Format ist, das mit Microsoft Office 2007 eingeführt wurde. PPTX‑Dateien bieten bessere Leistung, geringere Dateigröße und verbesserte Datenwiederherstellung.

**Unterstützt Aspose.Slides die Batch‑Konvertierung mehrerer PPT‑Dateien zu PPTX?**

Ja, Sie können Aspose.Slides in einer Schleife verwenden, um mehrere PPT‑Dateien programmgesteuert zu PPTX zu konvertieren, sodass es für Batch‑Konvertierungen geeignet ist.

**Werden Inhalt und Formatierung nach der Konvertierung beibehalten?**

Aspose.Slides gewährleistet eine hohe Treue bei der Konvertierung von Präsentationen. Folienlayouts, Animationen, Formen, Diagramme und andere Designelemente bleiben während der PPT‑zu‑PPTX‑Konvertierung erhalten.

**Kann ich andere Formate wie PDF oder HTML aus PPT‑Dateien konvertieren?**

Ja, Aspose.Slides unterstützt die Konvertierung von PPT‑Dateien in [multiple formats](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/), einschließlich PDF, XPS, HTML, ODP und Bildformate wie PNG und JPEG.

**Ist es möglich, PPT nach PPTX zu konvertieren, ohne Microsoft PowerPoint installiert zu haben?**

Ja, Aspose.Slides ist eine eigenständige API und erfordert weder Microsoft PowerPoint noch Drittanbieter‑Software, um die Konvertierung durchzuführen.

**Gibt es ein Online‑Tool für die PPT‑zu‑PPTX‑Konvertierung?**

Ja, Sie können die kostenlose [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web‑Anwendung nutzen, um die Konvertierung direkt in Ihrem Browser durchzuführen, ohne Code schreiben zu müssen.