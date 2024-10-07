---
title: Eingebettete Schriftart - PowerPoint Java API
linktitle: Eingebettete Schriftart
type: docs
weight: 40
url: /androidjava/embedded-font/
keywords: "Schriftarten, eingebettete Schriftarten, Schriftarten hinzufügen, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Verwenden Sie eingebettete Schriftarten in PowerPoint-Präsentationen in Java"

---

**Eingebettete Schriftarten in PowerPoint** sind nützlich, wenn Sie möchten, dass Ihre Präsentation auf jedem System oder Gerät korrekt angezeigt wird. Wenn Sie eine Schriftart eines Drittanbieters oder eine nicht-standardisierte Schriftart verwendet haben, weil Sie kreativ mit Ihrer Arbeit waren, haben Sie noch mehr Gründe, Ihre Schriftart einzubetten. Andernfalls (ohne eingebettete Schriftarten) können sich die Texte oder Zahlen auf Ihren Folien, das Layout, die Gestaltung usw. ändern oder in verwirrende Rechtecke verwandeln.

Die [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) Klasse, die [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) Klasse, die [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) Klasse und ihre Schnittstellen enthalten die meisten Eigenschaften und Methoden, die Sie benötigen, um mit eingebetteten Schriftarten in PowerPoint-Präsentationen zu arbeiten.

## **Eingebettete Schriftarten aus der Präsentation abrufen oder entfernen**

Aspose.Slides stellt die [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) Methode (bereitgestellt von der [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) Klasse) zur Verfügung, um Ihnen das Abrufen (oder Herausfinden) der in einer Präsentation eingebetteten Schriftarten zu ermöglichen. Um Schriftarten zu entfernen, wird die [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) Methode (bereitgestellt von derselben Klasse) verwendet.

Dieser Java-Code zeigt Ihnen, wie Sie eingebettete Schriftarten aus einer Präsentation abrufen und entfernen:

```java
// Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Rendert eine Folie mit einem Textfeld, das die eingebettete "FunSized" Schriftart verwendet
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Speichern Sie das Bild auf der Festplatte im JPEG-Format
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Holt alle eingebetteten Schriftarten
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Sucht die "Calibri" Schriftart
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Entfernt die "Calibri" Schriftart
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Rendert die Präsentation; die "Calibri" Schriftart wird durch eine vorhandene ersetzt
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Speichern Sie das Bild auf der Festplatte im JPEG-Format
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Speichert die Präsentation ohne die eingebettete "Calibri" Schriftart auf der Festplatte
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eingebettete Schriftarten zur Präsentation hinzufügen**

Mit der [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) Enum und zwei Überladungen der [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) Methode können Sie Ihre bevorzugte (Einbettungs-) Regel auswählen, um die Schriftarten in einer Präsentation einzubetten. Dieser Java-Code zeigt Ihnen, wie Sie Schriftarten zu einer Präsentation einbetten und hinzufügen:

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

Um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriftarten zu komprimieren und deren Dateigröße zu reduzieren, bietet Aspose.Slides die [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) Methode (bereitgestellt von der [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) Klasse).

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