---
title: PPT zu PPTX in JavaScript konvertieren
linktitle: PPT zu PPTX
type: docs
weight: 20
url: /de/nodejs-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folien konvertieren
- PPT konvertieren
- PPT zu PPTX
- PPT als PPTX speichern
- PPT nach PPTX exportieren
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie alte PPT-Präsentationen schnell in modernes PPTX mit Aspose.Slides für Node.js - klare Anleitung, kostenlose Codebeispiele, keine Microsoft Office-Abhängigkeit."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen im PPT‑Format in das PPTX‑Format mit JavaScript und mit der Online‑PPT‑zu‑PPTX‑Konvertierungs‑App konvertiert. Das folgende Thema wird behandelt.

- PPT in JavaScript nach PPTX konvertieren

## **Java PPT zu PPTX konvertieren**

Für JavaScript‑Beispielcode zur Konvertierung von PPT zu PPTX siehe bitte den Abschnitt unten, d. h.[Convert PPT to PPTX](#convert-ppt-to-pptx). Er lädt lediglich die PPT‑Datei und speichert sie im PPTX‑Format. Durch Angabe verschiedener Speicherformate können Sie die PPT‑Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln beschrieben.

- [PPT in PDF mit JavaScript konvertieren](/slides/de/nodejs-java/convert-powerpoint-to-pdf/)
- [PPT in XPS mit JavaScript konvertieren](/slides/de/nodejs-java/convert-powerpoint-to-xps/)
- [PPT in HTML mit JavaScript konvertieren](/slides/de/nodejs-java/convert-powerpoint-to-html/)
- [PPT in ODP mit JavaScript konvertieren](/slides/de/nodejs-java/save-presentation/)
- [PPT in PNG mit JavaScript konvertieren](/slides/de/nodejs-java/convert-powerpoint-to-png/)

## **Über die PPT‑zu‑PPTX‑Konvertierung**
Konvertieren Sie das alte PPT‑Format mit der Aspose.Slides‑API in PPTX. Wenn Sie Tausende von PPT‑Präsentationen in das PPTX‑Format konvertieren müssen, ist die beste Lösung, dies programmgesteuert zu tun. Mit der Aspose.Slides‑API ist es in wenigen Codezeilen möglich. Die API unterstützt vollständige Kompatibilität zur Konvertierung von PPT‑Präsentationen in PPTX und ermöglicht Folgendes:

- Komplexe Strukturen von Masterfolien, Layouts und Folien konvertieren.
- Präsentationen mit Diagrammen konvertieren.
- Präsentationen mit Gruppierungen, Autoformen (wie Rechtecke und Ellipsen) und Formen mit benutzerdefinierter Geometrie konvertieren.
- Präsentationen mit Textur‑ und Bildfüllungen für Autoformen konvertieren.
- Präsentationen mit Platzhaltern, Textfeldern und Textträgern konvertieren.

{{% alert color="primary" %}} 

Schauen Sie sich die App [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) an:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

Diese App basiert auf der [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/), sodass Sie ein Live‑Beispiel für grundlegende PPT‑zu‑PPTX‑Konvertierungsfunktionen sehen können. Aspose.Slides Conversion ist eine Web‑App, die es ermöglicht, eine Präsentationsdatei im PPT‑Format abzulegen und sie als PPTX herunterzuladen.

Weitere Live‑Beispiele für [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) finden Sie.

{{% /alert %}} 

## **PPT zu PPTX konvertieren**
Aspose.Slides für Node.js via Java erleichtert Entwicklern den Zugriff auf PPT über die Klasseninstanz [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) und die Konvertierung in das entsprechende [PPTX](https://docs.fileformat.com/presentation/pptx/)‑Format. Derzeit unterstützt es die Teilkonvertierung von [PPT ](https://docs.fileformat.com/presentation/ppt/)to PPTX.

Aspose.Slides für Node.js via Java bietet die Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation), die eine **PPTX**‑Präsentationsdatei repräsentiert. Die Presentation‑Klasse kann nun auch **PPT** über Presentation zugreifen, wenn das Objekt instanziiert wird. Das folgende Beispiel zeigt, wie man eine PPT‑Präsentation in eine PPTX‑Präsentation konvertiert.
```javascript
// Instanziiere ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
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

Die oben gezeigte Code‑Snippet erzeugte nach der Konvertierung die folgende PPTX‑Präsentation

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Abbildung: Generierte PPTX‑Präsentation nach der Konvertierung**|

## **FAQ**

**Was ist der Unterschied zwischen den Formaten PPT und PPTX?**

PPT ist das ältere binäre Dateiformat, das von Microsoft PowerPoint verwendet wird, während PPTX das neuere, XML‑basierte Format ist, das mit Microsoft Office 2007 eingeführt wurde. PPTX‑Dateien bieten bessere Leistung, geringere Dateigröße und verbesserte Datenwiederherstellung.

**Unterstützt Aspose.Slides die Stapelkonvertierung mehrerer PPT‑Dateien zu PPTX?**

Ja, Sie können Aspose.Slides in einer Schleife verwenden, um mehrere PPT‑Dateien programmgesteuert zu PPTX zu konvertieren, wodurch es sich für Stapelkonvertierungs‑Szenarien eignet.

**Werden Inhalt und Formatierung nach der Konvertierung beibehalten?**

Aspose.Slides bewahrt eine hohe Treue bei der Konvertierung von Präsentationen. Folienlayouts, Animationen, Formen, Diagramme und andere Designelemente bleiben während der PPT‑zu‑PPTX‑Konvertierung erhalten.

**Kann ich andere Formate wie PDF oder HTML aus PPT‑Dateien konvertieren?**

Ja, Aspose.Slides unterstützt die Konvertierung von PPT‑Dateien in mehrere Formate, darunter PDF, XPS, HTML, ODP und Bildformate wie PNG und JPEG.

**Ist es möglich, PPT zu PPTX zu konvertieren, ohne Microsoft PowerPoint installiert zu haben?**

Ja, Aspose.Slides ist eine eigenständige API und benötigt weder Microsoft PowerPoint noch Drittsoftware, um die Konvertierung durchzuführen.

**Gibt es ein Online‑Tool für die PPT‑zu‑PPTX‑Konvertierung?**

Ja, Sie können die kostenlose Web‑Anwendung [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) nutzen, um die Konvertierung direkt in Ihrem Browser durchzuführen, ohne Code zu schreiben.