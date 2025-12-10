---
title: Schriftarten in Präsentationen mit Java einbetten
linktitle: Schriftart einbetten
type: docs
weight: 40
url: /de/java/embedded-font/
keywords:
- Schriftart hinzufügen
- Schriftart einbetten
- Schriftarteinbettung
- eingebettete Schriftart abrufen
- eingebettete Schriftart hinzufügen
- eingebettete Schriftart entfernen
- eingebettete Schriftart komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "TrueType-Schriftarten in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java einbetten und so eine genaue Darstellung auf allen Plattformen gewährleisten."
---

**Eingebettete Schriftarten in PowerPoint** sind nützlich, wenn Ihre Präsentation auf jedem System oder Gerät korrekt angezeigt werden soll. Wenn Sie eine Drittanbieter‑ oder nicht standardmäßige Schriftart verwendet haben, weil Sie kreativ waren, haben Sie noch mehr Gründe, Ihre Schriftart einzubetten. Andernfalls (ohne eingebettete Schriftarten) können Texte oder Zahlen auf Ihren Folien, das Layout, das Styling usw. sich ändern oder in verwirrende Rechtecke verwandeln. 

Die Klasse [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager), die Klasse [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/), die Klasse [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) und ihre Schnittstellen enthalten die meisten Eigenschaften und Methoden, die Sie benötigen, um mit eingebetteten Schriftarten in PowerPoint‑Präsentationen zu arbeiten. 

## **Eingebettete Schriftarten abrufen und entfernen**

Aspose.Slides stellt die Methode [getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (bereitgestellt von der Klasse [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)) zur Verfügung, um die in einer Präsentation eingebetteten Schriftarten abzurufen (oder herauszufinden). Um Schriftarten zu entfernen, wird die Methode [removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (ebenfalls von derselben Klasse bereitgestellt) verwendet.

Dieser Java‑Code zeigt, wie Sie eingebettete Schriftarten aus einer Präsentation abrufen und entfernen:
```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Rendert eine Folie, die einen Textframe enthält und die eingebettete "FunSized"-Schrift verwendet
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Speichert das Bild auf der Festplatte im JPEG-Format
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

     // Speichert das Bild auf der Festplatte im JPEG-Format
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Speichert die Präsentation ohne die eingebettete Schriftart "Calibri" auf der Festplatte
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eingebettete Schriftarten hinzufügen**

Mit dem Aufzählungstyp [EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) und zwei Überladungen der Methode [addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) können Sie die gewünschte (Einbettungs‑)Regel auswählen, um Schriftarten in einer Präsentation einzubetten. Dieser Java‑Code zeigt, wie Sie Schriftarten einbetten und zu einer Präsentation hinzufügen:
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

Damit Sie die in einer Präsentation eingebetteten Schriftarten komprimieren und die Dateigröße reduzieren können, stellt Aspose.Slides die Methode [compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (bereitgestellt von der Klasse [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) zur Verfügung.

Dieser Java‑Code zeigt, wie Sie eingebettete PowerPoint‑Schriftarten komprimieren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie kann ich erkennen, dass eine bestimmte Schriftart in der Präsentation trotz Einbettung beim Rendern noch substituiert wird?**

Prüfen Sie die [Substitutionsinformationen](/slides/de/java/font-substitution/) im Font‑Manager und die [Fallback‑/Substitutionsregeln](/slides/de/java/fallback-font/): Ist die Schriftart nicht verfügbar oder eingeschränkt, wird ein Ersatz verwendet.

**Lohnt es sich, Systemschriftarten wie Arial/Calibri einzubetten?**

In der Regel nein – sie sind fast immer verfügbar. Für volle Portabilität in „dünnen“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriftarten) kann das Einbetten von Systemschriftarten jedoch das Risiko unerwarteter Substitutionen beseitigen.