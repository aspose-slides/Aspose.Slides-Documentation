---
title: Eingebettete Schriftarten - PowerPoint Java API
linktitle: Eingebettete Schriftarten
type: docs
weight: 40
url: /de/java/embedded-font/
keywords: "Schriftarten, eingebettete Schriftarten, Schriftarten hinzufügen, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Verwenden Sie eingebettete Schriftarten in PowerPoint-Präsentationen in Java"

---

**Eingebettete Schriftarten in PowerPoint** sind nützlich, wenn Sie möchten, dass Ihre Präsentation auf jedem System oder Gerät korrekt dargestellt wird. Wenn Sie eine Schriftart von einem Drittanbieter oder eine nicht standardisierte Schriftart verwendet haben, weil Sie bei Ihrer Arbeit kreativ waren, haben Sie noch mehr Gründe, Ihre Schriftart einzubetten. Andernfalls (ohne eingebettete Schriftarten) können sich die Texte oder Zahlen auf Ihren Folien, das Layout, das Styling usw. ändern oder in verwirrende Rechtecke verwandeln.

Die Klasse [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager), die Klasse [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) und die Klasse [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) sowie deren Schnittstellen enthalten die meisten Eigenschaften und Methoden, die Sie benötigen, um mit eingebetteten Schriftarten in PowerPoint-Präsentationen zu arbeiten.

## **Eingebettete Schriftarten aus der Präsentation abrufen oder entfernen**

Aspose.Slides bietet die Methode [getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (bereitgestellt von der Klasse [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)), um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriftarten abzurufen (oder herauszufinden). Um Schriftarten zu entfernen, wird die Methode [removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (bereitgestellt von derselben Klasse) verwendet.

Dieser Java-Code zeigt Ihnen, wie Sie eingebettete Schriftarten aus einer Präsentation abrufen und entfernen:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Rendert eine Folie mit einem Textfeld, das die eingebettete "FunSized" verwendet
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Speichert das Bild auf der Festplatte im JPEG-Format
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Ruft alle eingebetteten Schriftarten ab
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Findet die Schriftart "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Entfernt die Schriftart "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Rendert die Präsentation; die Schriftart "Calibri" wird durch eine vorhandene ersetzt
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Speichert das Bild auf der Festplatte im JPEG-Format
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Speichert die Präsentation ohne die eingebettete "Calibri"-Schriftart auf der Festplatte
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eingebettete Schriftarten zur Präsentation hinzufügen**

Mit dem Enum [EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) und zwei Überladungen der Methode [addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) können Sie Ihre bevorzugte (Einbettungs-) Regel auswählen, um die Schriftarten in einer Präsentation einzubetten. Dieser Java-Code zeigt Ihnen, wie Sie Schriftarten in eine Präsentation einbetten und hinzufügen:

```java
// Lädt die Präsentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // Speichert die Präsentation auf der Festplatte
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eingebettete Schriftarten komprimieren**

Um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriftarten zu komprimieren und die Dateigröße zu reduzieren, bietet Aspose.Slides die Methode [compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (bereitgestellt von der Klasse [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)).

Dieser Java-Code zeigt Ihnen, wie Sie eingebettete PowerPoint-Schriftarten komprimieren:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```