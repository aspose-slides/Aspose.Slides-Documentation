---
title: Einbetten von Schriftarten in Präsentationen auf Android
linktitle: Schriftart einbetten
type: docs
weight: 40
url: /de/androidjava/embedded-font/
keywords:
- Schriftart hinzufügen
- Schriftart einbetten
- Schriftart-Einbettung
- eingebettete Schriftart abrufen
- eingebettete Schriftart hinzufügen
- eingebettete Schriftart entfernen
- eingebettete Schriftart komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Einbetten von TrueType-Schriftarten in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android über Java, um eine genaue Wiedergabe auf allen Plattformen sicherzustellen."
---

**Eingebettete Schriftarten in PowerPoint** sind nützlich, wenn Ihre Präsentation auf jedem System oder Gerät korrekt angezeigt werden soll. Wenn Sie eine Drittanbieter‑ oder nicht‑standardmäßige Schriftart verwendet haben, weil Sie kreativ waren, haben Sie noch mehr Gründe, Ihre Schriftart einzubetten. Andernfalls (ohne eingebettete Schriftarten) können Texte oder Zahlen in Ihren Folien, das Layout, Styling usw. sich ändern oder in verwirrende Rechtecke umgewandelt werden. 

Die Klasse [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) , die Klasse [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) , die Klasse [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)  und ihre Schnittstellen enthalten die meisten Eigenschaften und Methoden, die Sie benötigen, um mit eingebetteten Schriftarten in PowerPoint‑Präsentationen zu arbeiten.

## **Abrufen und Entfernen eingebetteter Schriftarten**

Aspose.Slides stellt die Methode [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (bereitgestellt von der Klasse [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)) zur Verfügung, mit der Sie die in einer Präsentation eingebetteten Schriftarten abrufen (oder herausfinden) können. Zum Entfernen von Schriftarten wird die Methode [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (ebenfalls von derselben Klasse) verwendet.

Dieser Java‑Code zeigt, wie man eingebettete Schriftarten aus einer Präsentation abruft und entfernt:
```java
// Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Rendert eine Folie, die einen Textframe enthält, der die eingebettete "FunSized"-Schriftart verwendet
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Speichert das Bild im JPEG-Format auf der Festplatte
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

     //Speichert das Bild im JPEG-Format auf der Festplatte
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Speichert die Präsentation ohne eingebettete "Calibri"-Schriftart auf der Festplatte
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Hinzufügen eingebetteter Schriftarten**

Mit dem Aufzählungstyp [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) und zwei Überladungen der Methode [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) können Sie die gewünschte (Einbettungs‑) Regel auswählen, um Schriftarten in einer Präsentation einzubetten. Dieser Java‑Code zeigt, wie man Schriftarten einbettet und einer Präsentation hinzufügt:
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


## **Komprimieren eingebetteter Schriftarten**

Damit Sie die in einer Präsentation eingebetteten Schriftarten komprimieren und die Dateigröße reduzieren können, stellt Aspose.Slides die Methode [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (angeboten von der Klasse [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) zur Verfügung.

Dieser Java‑Code zeigt, wie man eingebettete PowerPoint‑Schriftarten komprimiert:
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

Prüfen Sie die [substitution information](/slides/de/androidjava/font-substitution/) im Font‑Manager und die [fallback/substitution rules](/slides/de/androidjava/fallback-font/): Wenn die Schriftart nicht verfügbar oder eingeschränkt ist, wird ein Ersatz verwendet.

**Lohnt es sich, Systemschriftarten wie Arial/Calibri einzubetten?**

In der Regel nicht – sie sind fast immer verfügbar. Aber für volle Portabilität in „dünnen“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriftarten) kann das Einbetten von Systemschriftarten das Risiko unerwarteter Substitutionen beseitigen.