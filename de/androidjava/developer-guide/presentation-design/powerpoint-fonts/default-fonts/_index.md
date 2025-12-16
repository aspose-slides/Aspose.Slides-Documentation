---
title: Standard-Präsentationsschriftarten unter Android festlegen
linktitle: Standard-Schriftart
type: docs
weight: 30
url: /de/androidjava/default-font/
keywords:
- Standard-Schriftart
- Reguläre Schriftart
- Normale Schriftart
- Asiatische Schriftart
- PDF-Export
- XPS-Export
- Bild-Export
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Legen Sie Standard-Schriftarten in Aspose.Slides für Android über Java fest, um eine korrekte Konvertierung von PowerPoint (PPT, PPTX) und OpenDocument (ODP) nach PDF, XPS und Bilddateien zu gewährleisten."
---

## **Standard‑Schriftarten für das Rendern einer Präsentation**
Aspose.Slides ermöglicht das Festlegen der Standardschriftart für das Rendern der Präsentation zu PDF, XPS oder Thumbnails. Dieser Artikel zeigt, wie DefaultRegularFont und DefaultAsianFont als Standardschriftarten definiert werden. Bitte folgen Sie den nachstehenden Schritten, um Schriftarten aus externen Verzeichnissen mit Aspose.Slides für Android über die Java‑API zu laden:

1. Erstellen Sie eine Instanz von [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions).
2. Verwenden Sie [Set the DefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-), um Ihre gewünschte Schriftart festzulegen. Im folgenden Beispiel habe ich Wingdings verwendet.
3. Verwenden Sie [Set the DefaultAsianFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-), um Ihre gewünschte Schriftart festzulegen. Ich habe Wingdings im folgenden Beispiel verwendet.
4. Laden Sie die Präsentation mit Presentation und den festgelegten Ladeoptionen.
5. Erzeugen Sie nun das Folien‑Thumbnail, PDF und XPS, um die Ergebnisse zu überprüfen.

```java
// Ladeoptionen verwenden, um die Standard‑Schriftarten für reguläre und asiatische Zeichen festzulegen
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Präsentation laden
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Folien‑Thumbnail erzeugen
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // Bild auf der Festplatte speichern.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // PDF erzeugen
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // XPS erzeugen
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Was genau beeinflussen DefaultRegularFont und DefaultAsianFont – nur den Export oder auch Thumbnails, PDF, XPS, HTML und SVG?**

Sie nehmen an der Rendering‑Pipeline für alle unterstützten Ausgaben teil. Dazu gehören Folien‑Thumbnails, [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/de/androidjava/convert-powerpoint-to-xps/), [raster images](/slides/de/androidjava/convert-powerpoint-to-png/), [HTML](/slides/de/androidjava/convert-powerpoint-to-html/), und [SVG](/slides/de/androidjava/render-a-slide-as-an-svg-image/), da Aspose.Slides dieselbe Layout‑ und Glyph‑Auflösungslogik für diese Ziele verwendet.

**Werden Standardschriftarten angewendet, wenn man einfach ein PPTX liest und speichert, ohne zu rendern?**

Nein. Standardschriftarten spielen nur eine Rolle, wenn Text gemessen und gezeichnet werden muss. Ein reines Öffnen‑und‑Speichern einer Präsentation ändert weder die gespeicherten Schriftlauf‑Informationen noch die Dateistruktur. Standardschriftarten kommen bei Vorgängen zum Einsatz, die Rendern oder Textumfluss erfordern.

**Wenn ich eigene Schriftordner hinzufüge oder Schriftarten aus dem Speicher bereitstelle, werden sie bei der Auswahl der Standardschriftarten berücksichtigt?**

Ja. [Custom font sources](/slides/de/androidjava/custom-font/) erweitern den Katalog verfügbarer Familien und Glyphen, die die Engine nutzen kann. Standardschriftarten und alle [fallback rules](/slides/de/androidjava/fallback-font/) prüfen zuerst diese Quellen, was eine zuverlässigere Abdeckung auf Servern und in Containern ermöglicht.

**Beeinflussen Standardschriftarten Textmetriken (Kerning, Advances) und damit Zeilenumbrüche und Textumbruch?**

Ja. Das Ändern der Schriftart ändert die Glyph‑Metriken und kann Zeilenumbrüche, Textumbruch und Paginierung beim Rendern beeinflussen. Für Layout‑Stabilität sollten Sie die Originalschriftarten [embed the original fonts](/slides/de/androidjava/embedded-font/) oder metrisch kompatible Standard‑ und Fallback‑Familien auswählen.

**Gibt es einen Grund, Standardschriftarten zu setzen, wenn alle in der Präsentation verwendeten Schriftarten eingebettet sind?**

Oft ist das nicht nötig, weil [embedded fonts](/slides/de/androidjava/embedded-font/) bereits ein konsistentes Erscheinungsbild gewährleisten. Standardschriftarten können jedoch als Sicherheitsnetz für Zeichen dienen, die nicht durch das eingebettete Subset abgedeckt sind, oder wenn eine Datei sowohl eingebetteten als auch nicht eingebetteten Text enthält.