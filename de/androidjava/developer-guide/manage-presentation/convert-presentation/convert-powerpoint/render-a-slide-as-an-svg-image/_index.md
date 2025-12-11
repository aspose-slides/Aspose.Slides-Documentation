---
title: Präsentationsfolien auf Android als SVG-Bilder rendern
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint zu SVG
- Präsentation zu SVG
- Folie zu SVG
- PPT zu SVG
- PPTX zu SVG
- PPT als SVG speichern
- PPTX als SVG speichern
- PPT nach SVG exportieren
- PPTX nach SVG exportieren
- Folien rendern
- Folien konvertieren
- Folien exportieren
- Vektorbild
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Folien mit Aspose.Slides für Android als SVG‑Bilder rendern. Hochwertige Visualisierungen mit einfachen Java‑Code‑Beispielen."
---

## **SVG Format**

SVG—eine Abkürzung für Scalable Vector Graphics—ist ein standardmäßiger Grafiktyp oder ein Format, das zum Rendern zweidimensionaler Bilder verwendet wird. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder ihr Aussehen definieren. 

SVG ist eines der wenigen Bildformate, das sehr hohen Standards in Bezug auf Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und weitere entspricht. Aus diesen Gründen wird es häufig in der Webentwicklung eingesetzt. 

Sie möchten SVG‑Dateien verwenden, wenn Sie

- **Drucken Sie Ihre Präsentation in einem *sehr großen Format*.** SVG‑Bilder können auf jede Auflösung oder jedes Niveau skaliert werden. Sie können SVG‑Bilder beliebig oft in der Größe ändern, ohne die Qualität zu beeinträchtigen.
- **Verwenden Sie Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen*.** Die meisten Leser können SVG‑Dateien interpretieren. 
- **Verwenden Sie die *kleinstmöglichen Bildgrößen*.** SVG‑Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Gegenstücke in anderen Formaten, insbesondere in bitmapbasierten Formaten (JPEG oder PNG).

## **Eine Folie als SVG‑Bild rendern**

Aspose.Slides für Android via Java ermöglicht das Exportieren von Folien in Ihren Präsentationen als SVG‑Bilder. Führen Sie die folgenden Schritte aus, um SVG‑Bilder zu erzeugen:

1. Erstellen Sie eine Instanz der Klasse Presentation.  
2. Durchlaufen Sie alle Folien in der Präsentation.  
3. Schreiben Sie jede Folie mithilfe von FileOutputStream in eine eigene SVG‑Datei.  

{{% alert color="primary" %}} 

Sie können unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT‑zu‑SVG‑Konvertierungsfunktion von Aspose.Slides für Android via Java implementiert haben.

{{% /alert %}} 

Dieser Beispielcode in Java zeigt, wie Sie PPT mit Aspose.Slides in SVG konvertieren:
``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Warum kann das resultierende SVG in verschiedenen Browsern unterschiedlich aussehen?**

Die Unterstützung bestimmter SVG‑Funktionen wird von Browser‑Engines unterschiedlich implementiert. Die Parameter von [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) helfen, Inkompatibilitäten auszugleichen.

**Ist es möglich, nicht nur Folien, sondern auch einzelne Formen nach SVG zu exportieren?**

Ja. Jede [Form kann als separates SVG gespeichert werden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), was für Icons, Piktogramme und die Wiederverwendung von Grafiken praktisch ist.

**Können mehrere Folien zu einem einzigen SVG (Strip/Dokument) kombiniert werden?**

Das Standard‑Szenario ist eine Folie → ein SVG. Das Kombinieren mehrerer Folien zu einer einzigen SVG‑Leinwand ist ein Nachbearbeitungsschritt, der auf Anwendungsebene durchgeführt wird.