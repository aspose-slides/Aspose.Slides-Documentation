---
title: PowerPoint‑Folien als SVG‑Bilder auf Android rendern
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
- PPT speichern als SVG
- PPTX speichern als SVG
- PPT exportieren nach SVG
- PPTX exportieren nach SVG
- Folie rendern
- Folie konvertieren
- Folie exportieren
- Vektorbild
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Folien mit Aspose.Slides für Android als SVG‑Bilder rendern. Hochwertige Visualisierungen mit einfachen Java‑Code‑Beispielen."
---

## **SVG-Format**

SVG — eine Abkürzung für Scalable Vector Graphics — ist ein Standardgrafiktyp oder -format, das zum Rendern zweidimensionaler Bilder verwendet wird. SVG speichert Bilder als Vektoren in XML mit Details, die ihr Verhalten oder Aussehen definieren.

SVG ist eines der wenigen Bildformate, das in diesen Punkten sehr hohen Standards entspricht: Skalierbarkeit, Interaktivität, Leistung, Barrierefreiheit, Programmierbarkeit und weitere. Aus diesen Gründen wird es häufig in der Webentwicklung eingesetzt.

Sie möchten SVG-Dateien verwenden, wenn Sie

- **Ihre Präsentation in einem *sehr großen Format* drucken.** SVG‑Bilder können auf jede Auflösung oder jedes Niveau skaliert werden. Sie können SVG‑Bilder beliebig oft in der Größe ändern, ohne die Qualität zu beeinträchtigen.
- **Diagramme und Grafiken aus Ihren Folien in *verschiedenen Medien oder Plattformen* verwenden.** Die meisten Programme können SVG‑Dateien interpretieren.
- **die *kleinstmöglichen Bildgrößen* verwenden.** SVG‑Dateien sind im Allgemeinen kleiner als ihre hochauflösenden Gegenstücke in anderen Formaten, insbesondere bei bitmapbasierten Formaten (JPEG oder PNG).

## **Eine Folie als SVG‑Bild rendern**

Aspose.Slides für Android via Java ermöglicht das Exportieren von Folien aus Ihren Präsentationen als SVG‑Bilder. Befolgen Sie diese Schritte, um SVG‑Bilder zu erzeugen:

1. Erstellen Sie eine Instanz der Klasse Presentation.
2. Iterieren Sie über alle Folien in der Präsentation.
3. Schreiben Sie jede Folie mit FileOutputStream in eine eigene SVG‑Datei.

{{% alert color="primary" %}} 
Sie können unsere [kostenlose Webanwendung](https://products.aspose.app/slides/conversion/ppt-to-svg) ausprobieren, in der wir die PPT‑zu‑SVG‑Konvertierungsfunktion von Aspose.Slides für Android via Java implementiert haben.
{{% /alert %}} 

Dieser Beispielcode in Java zeigt Ihnen, wie Sie PPT mit Aspose.Slides in SVG konvertieren:
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

Die Unterstützung bestimmter SVG‑Funktionen ist in den Browser‑Engines unterschiedlich implementiert. Die Parameter von [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) helfen, Inkompatibilitäten auszugleichen.

**Ist es möglich, nicht nur Folien, sondern auch einzelne Formen als SVG zu exportieren?**

Ja. Jede [Form kann als separates SVG gespeichert werden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), was für Icons, Piktogramme und die Wiederverwendung von Grafiken praktisch ist.

**Können mehrere Folien zu einem einzigen SVG (Strip/Dokument) kombiniert werden?**

Das Standard‑Szenario ist Folie → SVG. Das Kombinieren mehrerer Folien zu einer einzigen SVG‑Leinwand ist ein nachgelagerter Verarbeitungsschritt, der auf Anwendungsebene durchgeführt wird.