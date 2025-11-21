---
title: "PPT in PPTX in JavaScript konvertieren"
linktitle: "PPT zu PPTX konvertieren"
type: docs
weight: 20
url: /de/nodejs-java/convert-ppt-to-pptx/
keywords: "Java PPT in PPTX konvertieren, PowerPoint PPT zu PPTX in JavaScript"
description: "PowerPoint PPT in JavaScript in PPTX konvertieren."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPT‑Format mithilfe von JavaScript und einer Online‑Konvertierungs‑App in das PPTX‑Format umwandelt. Dabei wird folgendes Thema behandelt.

- PPT zu PPTX in JavaScript konvertieren

## **Java PPT zu PPTX konvertieren**

Den JavaScript‑Beispielcode zum Konvertieren von PPT nach PPTX finden Sie im Abschnitt unten, nämlich [PPT zu PPTX konvertieren](#convert-ppt-to-pptx). Er lädt lediglich die PPT‑Datei und speichert sie im PPTX‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPT‑Datei zudem in zahlreiche andere Formate wie PDF, XPS, ODP, HTML usw. konvertieren, wie in den folgenden Artikeln beschrieben.

- [Java PPT zu PDF konvertieren](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java PPT zu XPS konvertieren](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java PPT zu HTML konvertieren](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java PPT zu ODP konvertieren](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java PPT zu Bild konvertieren](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **Über die PPT‑zu‑PPTX‑Konvertierung**
Altes PPT‑Format in PPTX mit der Aspose.Slides‑API konvertieren. Wenn Sie Tausende von PPT‑Präsentationen in das PPTX‑Format umwandeln müssen, ist die beste Lösung, dies programmatisch zu erledigen. Mit der Aspose.Slides‑API ist das mit nur wenigen Code‑Zeilen möglich. Die API bietet volle Kompatibilität für die Konvertierung von PPT‑Präsentationen nach PPTX und ermöglicht:

- Konvertierung komplexer Strukturen von Master‑Folien, Layouts und Folien.
- Konvertierung von Präsentationen mit Diagrammen.
- Konvertierung von Präsentationen mit Gruppierungs‑Shapes, Auto‑Shapes (wie Rechtecken und Ellipsen) sowie Shapes mit benutzerdefinierter Geometrie.
- Konvertierung von Präsentationen mit Texturen und Bild‑Füllstilen für Auto‑Shapes.
- Konvertierung von Präsentationen mit Platzhaltern, Text‑Frames und Text‑Holdern.

{{% alert color="primary" %}} 

Werfen Sie einen Blick auf die **Aspose.Slides PPT‑zu‑PPTX‑Konvertierung**‑App:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App wurde auf Basis der **Aspose.Slides‑API** entwickelt, sodass Sie ein funktionierendes Beispiel für die grundlegenden PPT‑zu‑PPTX‑Konvertierungsfähigkeiten sehen können. Aspose.Slides Conversion ist eine Web‑App, die das Hochladen einer Präsentationsdatei im PPT‑Format und das Herunterladen der konvertierten PPTX‑Datei ermöglicht.

Weitere Live‑Beispiele finden Sie unter **Aspose.Slides Conversion**:

https://products.aspose.app/slides/conversion/
{{% /alert %}} 

## **PPT zu PPTX konvertieren**
Aspose.Slides für Node.js über Java ermöglicht Entwicklern den Zugriff auf PPT über die Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) und deren Konvertierung in das entsprechende [PPTX](https://docs.fileformat.com/presentation/pptx/)-Format. Derzeit unterstützt sie die Teilkonvertierung von [PPT](https://docs.fileformat.com/presentation/ppt/) nach PPTX. Weitere Details zu unterstützten und nicht unterstützten Funktionen der PPT‑zu‑PPTX‑Konvertierung finden Sie in der Dokumentation unter diesem [Link](/slides/de/nodejs-java/ppt-to-pptx-conversion/).

Aspose.Slides für Node.js über Java stellt die Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) bereit, die eine **PPTX**‑Präsentationsdatei repräsentiert. Die Presentation‑Klasse kann nun auch **PPT** über ein Presentation‑Objekt laden, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine PPT‑Präsentation in eine PPTX‑Presentation konvertiert.
```javascript
// Instanziiere ein Presentation-Objekt, das eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Speichere die PPTX-Präsentation im PPTX-Format
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Abbildung: Quell‑PPT‑Präsentation**|

Der obige Code‑Auszug erzeugt nach der Konvertierung die folgende PPTX‑Präsentation:

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Abbildung: Generierte PPTX‑Präsentation nach der Konvertierung**|

## **FAQ**

**Was ist der Unterschied zwischen den Formaten PPT und PPTX?**

PPT ist das ältere binäre Dateiformat von Microsoft PowerPoint, während PPTX das neuere XML‑basierte Format ist, das mit Microsoft Office 2007 eingeführt wurde. PPTX‑Dateien bieten bessere Leistung, kleinere Dateigröße und eine verbesserte Datenwiederherstellung.

**Unterstützt Aspose.Slides die Stapelverarbeitung mehrerer PPT‑Dateien zu PPTX?**

Ja, Sie können Aspose.Slides in einer Schleife verwenden, um mehrere PPT‑Dateien programmgesteuert nach PPTX zu konvertieren, was sich für Stapelverarbeitungs‑Szenarien eignet.

**Werden Inhalt und Formatierung nach der Konvertierung beibehalten?**

Aspose.Slides gewährleistet eine hohe Treue bei der Konvertierung von Präsentationen. Folien‑Layouts, Animationen, Shapes, Diagramme und andere Designelemente bleiben während der PPT‑zu‑PPTX‑Konvertierung erhalten.

**Kann ich aus PPT‑Dateien andere Formate wie PDF oder HTML konvertieren?**

Ja, Aspose.Slides unterstützt die Konvertierung von PPT‑Dateien in mehrere Formate, darunter PDF, XPS, HTML, ODP sowie Bildformate wie PNG und JPEG.

**Ist es möglich, PPT nach PPTX zu konvertieren, ohne Microsoft PowerPoint installiert zu haben?**

Ja, Aspose.Slides ist eine eigenständige API und benötigt weder Microsoft PowerPoint noch andere Drittanbieter‑Software für die Konvertierung.

**Gibt es ein Online‑Tool für die PPT‑zu‑PPTX‑Konvertierung?**

Ja, Sie können den kostenlosen **Aspose.Slides PPT‑zu‑PPTX‑Konverter** [https://products.aspose.app/slides/conversion/ppt-to-pptx] web‑basiert nutzen, um die Konvertierung direkt im Browser durchzuführen, ohne Code zu schreiben.