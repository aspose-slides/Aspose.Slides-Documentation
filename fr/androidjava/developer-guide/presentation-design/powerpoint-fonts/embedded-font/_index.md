---
title: Police intégrée - API Java PowerPoint
linktitle: Police intégrée
type: docs
weight: 40
url: /androidjava/embedded-font/
keywords: "Polices, polices intégrées, ajouter des polices, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Utilisez des polices intégrées dans une présentation PowerPoint en Java"

---

**Les polices intégrées dans PowerPoint** sont utiles lorsque vous souhaitez que votre présentation apparaisse correctement lorsqu'elle est ouverte sur n'importe quel système ou appareil. Si vous avez utilisé une police tierce ou non standard parce que vous avez fait preuve de créativité dans votre travail, alors vous avez encore plus de raisons d'intégrer votre police. Sinon (sans polices intégrées), les textes ou les chiffres sur vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus.

La classe [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager), la classe [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/), la classe [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) et leurs interfaces contiennent la plupart des propriétés et des méthodes dont vous avez besoin pour travailler avec des polices intégrées dans des présentations PowerPoint.

## **Obtenir ou supprimer des polices intégrées de la présentation**

Aspose.Slides fournit la méthode [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (exposée par la classe [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)) pour vous permettre d'obtenir (ou de découvrir) les polices intégrées dans une présentation. Pour supprimer des polices, la méthode [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (exposée par la même classe) est utilisée.

Ce code Java vous montre comment obtenir et supprimer des polices intégrées d'une présentation :

```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Rendu d'une diapositive contenant un cadre de texte qui utilise la police intégrée "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    // Sauvegarde l'image sur le disque au format JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Obtient toutes les polices intégrées
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

    // Rendu de la présentation ; la police "Calibri" est remplacée par une existante
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     // Sauvegarde l'image sur le disque au format JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Sauvegarde la présentation sans la police intégrée "Calibri" sur le disque
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter des polices intégrées à la présentation**

En utilisant l'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) et deux surcharges de la méthode [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), vous pouvez sélectionner votre règle (d'intégration) préférée pour intégrer les polices dans une présentation. Ce code Java vous montre comment intégrer et ajouter des polices à une présentation :

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

    // Sauvegarde la présentation sur le disque
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Compresser les polices intégrées**

Pour vous permettre de compresser les polices intégrées dans une présentation et de réduire sa taille de fichier, Aspose.Slides fournit la méthode [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (exposée par la classe [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)).

Ce code Java vous montre comment compresser les polices intégrées de PowerPoint :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```