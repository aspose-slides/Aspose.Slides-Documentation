---
title: Police Embarquée - API Java de PowerPoint
linktitle: Police Embarquée
type: docs
weight: 40
url: /fr/java/embedded-font/
keywords: "Polices, polices embarquées, ajouter des polices, présentation PowerPoint, Java, Aspose.Slides pour Java"
description: "Utilisez des polices embarquées dans une présentation PowerPoint en Java"

---

**Les polices embarquées dans PowerPoint** sont utiles lorsque vous souhaitez que votre présentation apparaisse correctement lorsqu'elle est ouverte sur n'importe quel système ou appareil. Si vous avez utilisé une police tierce ou non standard parce que vous avez été créatif avec votre travail, vous avez encore plus de raisons d'incorporer votre police. Sinon (sans polices embarquées), les textes ou chiffres sur vos diapositives, la mise en page, le style, etc., peuvent changer ou se transformer en rectangles confus.

La classe [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager), la classe [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/), la classe [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) et leurs interfaces contiennent la plupart des propriétés et méthodes dont vous avez besoin pour travailler avec des polices embarquées dans des présentations PowerPoint.

## **Obtenir ou Supprimer des Polices Embarquées de la Présentation**

Aspose.Slides fournit la méthode [getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (exposée par la classe [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)) pour vous permettre d'obtenir (ou de découvrir) les polices embarquées dans une présentation. Pour supprimer des polices, la méthode [removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (exposée par la même classe) est utilisée.

Ce code Java vous montre comment obtenir et supprimer des polices embarquées d'une présentation :

```java
// Instancie un objet Présentation qui représente un fichier de présentation
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Rendre une diapositive contenant un cadre de texte qui utilise "FunSized" embarquée
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Enregistrer l'image sur disque au format JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Obtient toutes les polices embarquées
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Trouve la police "Calibri"
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Supprime la police "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Rend la présentation ; la police "Calibri" est remplacée par une existante
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // Enregistrer l'image sur disque au format JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Enregistre la présentation sans la police "Calibri" embarquée sur disque
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter des Polices Embarquées à la Présentation**

En utilisant l'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) et deux surcharges de la méthode [addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), vous pouvez sélectionner votre règle (d'incorporation) préférée pour incorporer les polices dans une présentation. Ce code Java vous montre comment incorporer et ajouter des polices à une présentation :

```java
// Charge la présentation
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

    // Enregistre la présentation sur disque
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Compresser les Polices Embarquées**

Pour vous permettre de compresser les polices embarquées dans une présentation et de réduire sa taille de fichier, Aspose.Slides fournit la méthode [compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (exposée par la classe [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)).

Ce code Java vous montre comment compresser les polices PowerPoint embarquées :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```