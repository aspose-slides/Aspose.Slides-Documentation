---
title: Intégrer des polices dans les présentations sur Android
linktitle: Intégration de police
type: docs
weight: 40
url: /fr/androidjava/embedded-font/
keywords:
- ajouter police
- intégrer police
- intégration de police
- obtenir police intégrée
- ajouter police intégrée
- supprimer police intégrée
- compresser police intégrée
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Intégrez des polices TrueType dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Android via Java, garantissant un rendu précis sur toutes les plateformes."
---

**Polices intégrées dans PowerPoint** sont utiles lorsque vous souhaitez que votre présentation s’affiche correctement lorsqu’elle est ouverte sur n’importe quel système ou appareil. Si vous avez utilisé une police tierce ou non standard parce que vous avez fait preuve de créativité dans votre travail, vous avez encore plus de raisons d’intégrer votre police. Sinon (sans polices intégrées), les textes ou les chiffres sur vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus. 

Les classes [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) et [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) ainsi que leurs interfaces contiennent la plupart des propriétés et méthodes dont vous avez besoin pour travailler avec les polices intégrées dans les présentations PowerPoint.

## **Obtenir et supprimer des polices intégrées**

Aspose.Slides fournit la méthode [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (exposée par la classe [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager)) pour vous permettre d’obtenir (ou de découvrir) les polices intégrées dans une présentation. Pour supprimer des polices, la méthode [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (exposée par la même classe) est utilisée.

Ce code Java vous montre comment obtenir et supprimer les polices intégrées d’une présentation :
```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Rendu d'une diapositive contenant un cadre de texte qui utilise la police intégrée "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Enregistre l'image sur le disque au format JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Récupère toutes les polices intégrées
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Recherche la police "Calibri"
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

    // Rend la présentation ; la police "Calibri" est remplacée par une police existante
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Enregistre l'image sur le disque au format JPEG
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Enregistre la présentation sans la police intégrée "Calibri" sur le disque
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajouter des polices intégrées**

En utilisant l’énumération [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) et les deux surcharges de la méthode [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), vous pouvez sélectionner la règle d’intégration (embedding) qui vous convient pour intégrer les polices dans une présentation. Ce code Java vous montre comment intégrer et ajouter des polices à une présentation :
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

    // Enregistre la présentation sur le disque
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Compresser les polices intégrées**

Pour vous permettre de compresser les polices intégrées dans une présentation et de réduire sa taille de fichier, Aspose.Slides fournit la méthode [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (exposée par la classe [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)).

Ce code Java vous montre comment compresser les polices PowerPoint intégrées :
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

**Comment savoir si une police spécifique dans la présentation sera toujours substituée lors du rendu malgré son intégration ?**

Consultez les [informations de substitution](/slides/fr/androidjava/font-substitution/) dans le gestionnaire de polices et les [règles de secours/substitution](/slides/fr/androidjava/fallback-font/) : si la police est indisponible ou restreinte, une police de secours sera utilisée.

**Vale-t-il la peine d’intégrer les polices « système » comme Arial/Calibri ?**

Généralement non—elles sont presque toujours disponibles. Mais pour une portabilité totale dans des environnements « minces » (Docker, un serveur Linux sans polices préinstallées), intégrer les polices système peut éliminer le risque de substitutions inattendues.