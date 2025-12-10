---
title: Standard-Schriftarten für Präsentationen in Java festlegen
linktitle: Standard-Schriftart
type: docs
weight: 30
url: /de/java/default-font/
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
- Java
- Aspose.Slides
description: "Standard-Schriftarten in Aspose.Slides für Java festlegen, um eine korrekte Konvertierung von PowerPoint (PPT, PPTX) und OpenDocument (ODP) zu PDF, XPS und Bildern zu gewährleisten."
---

## **Standard-Schriftarten für die Darstellung einer Präsentation**
Aspose.Slides ermöglicht es Ihnen, die Standardschriftart für die Darstellung der Präsentation als PDF, XPS oder Miniaturbilder festzulegen. Dieser Artikel zeigt, wie man DefaultRegularFont und DefaultAsianFont definiert, um sie als Standardschriftarten zu verwenden. Bitte folgen Sie den nachstehenden Schritten, um Schriftarten aus externen Verzeichnissen mit der Aspose.Slides for Java API zu laden:

1. Erstellen Sie eine Instanz von [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) auf die gewünschte Schriftart. Im folgenden Beispiel habe ich Wingdings verwendet.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) auf die gewünschte Schriftart. Ich habe Wingdings im folgenden Beispiel verwendet.
1. Laden Sie die Präsentation mit Presentation und den festgelegten Ladeoptionen.
1. Erzeugen Sie nun das Folien-Miniaturbild, PDF und XPS, um die Ergebnisse zu überprüfen.

Die Implementierung des Obigen wird unten gezeigt.
```java
// Ladeoptionen verwenden, um die Standard‑reguläre und -asiatische Schriftart festzulegen
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Präsentation laden
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Folien‑Miniaturbild erzeugen
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

**Was genau beeinflussen DefaultRegularFont und DefaultAsianFont – nur den Export oder auch Miniaturansichten, PDF, XPS, HTML und SVG?**

Sie nehmen an der Rendering-Pipeline für alle unterstützten Ausgaben teil. Dazu gehören Folien-Miniaturbilder, [PDF](/slides/de/java/convert-powerpoint-to-pdf/), [XPS](/slides/de/java/convert-powerpoint-to-xps/), [Rasterbilder](/slides/de/java/convert-powerpoint-to-png/), [HTML](/slides/de/java/convert-powerpoint-to-html/) und [SVG](/slides/de/java/render-a-slide-as-an-svg-image/), weil Aspose.Slides dieselbe Layout- und Glyph-Auflösungslogik für diese Ziele verwendet.

**Werden Standardschriftarten angewendet, wenn man eine PPTX nur liest und speichert, ohne zu rendern?**

Nein. Standardschriftarten sind relevant, wenn Text gemessen und gezeichnet werden muss. Ein einfaches Öffnen‑und‑Speichern einer Präsentation ändert weder die gespeicherten Schriftlaufinformationen noch die Dateistruktur. Standardschriftarten kommen bei Vorgängen zum Einsatz, die Text rendern oder umfließen.

**Wenn ich eigene Schriftordner hinzufüge oder Schriftarten aus dem Speicher bereitstelle, werden sie bei der Auswahl der Standardschriftarten berücksichtigt?**

Ja. [Benutzerdefinierte Schriftquellen](/slides/de/java/custom-font/) erweitert den Katalog verfügbarer Familien und Glyphen, die die Engine nutzen kann. Standardschriftarten und alle [Fallback-Regeln](/slides/de/java/fallback-font/) werden zuerst gegen diese Quellen aufgelöst, was auf Servern und in Containern zu einer zuverlässigeren Abdeckung führt.

**Beeinflussen Standardschriftarten Textmetriken (Kerning, Vorstufen) und damit Zeilenumbrüche und Textumbruch?**

Ja. Das Ändern der Schriftart ändert Glyphenmetriken und kann Zeilenumbrüche, Textumbruch und Paginierung beim Rendering verändern. Für Layout‑Stabilität [originale Schriften einbetten](/slides/de/java/embedded-font/) oder metrisch kompatible Standard‑ und Fallback‑Familien wählen.

**Gibt es einen Sinn, Standardschriftarten festzulegen, wenn alle in der Präsentation verwendeten Schriften eingebettet sind?**

Oft ist es nicht notwendig, da [eingebettete Schriften](/slides/de/java/embedded-font/) bereits ein konsistentes Erscheinungsbild gewährleisten. Standardschriftarten dienen dennoch als Sicherheitsnetz für Zeichen, die im eingebetteten Subset nicht enthalten sind, oder wenn eine Datei eingebetteten und nicht eingebetteten Text kombiniert.