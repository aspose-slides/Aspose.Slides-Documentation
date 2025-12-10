---
title: "Intégrer des polices dans les présentations avec Java"
linktitle: "Intégration de police"
type: docs
weight: 40
url: /fr/java/embedded-font/
keywords:
- ajouter une police
- incorporer une police
- incorporation de police
- obtenir la police incorporée
- ajouter une police incorporée
- supprimer une police incorporée
- compresser une police incorporée
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Intégrez des polices TrueType dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Java, garantissant un rendu précis sur toutes les plateformes."
---

**Polices incorporées dans PowerPoint** sont utiles lorsque vous souhaitez que votre présentation s'affiche correctement lorsqu'elle est ouverte sur n'importe quel système ou appareil. Si vous avez utilisé une police tierce ou non standard parce que vous avez fait preuve de créativité dans votre travail, vous avez alors encore plus de raisons d'incorporer votre police. Sinon (sans polices incorporées), les textes ou les chiffres de vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus. 

La classe [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager), la classe [FontData](https://reference.aspose.com/slides/java/com.aspose.slides/fontdata/) , la classe [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) ainsi que leurs interfaces contiennent la plupart des propriétés et méthodes dont vous avez besoin pour travailler avec les polices incorporées dans les présentations PowerPoint. 

## **Obtenir et supprimer les polices incorporées**

Aspose.Slides fournit la méthode [getEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) (exposée par la classe [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager)) pour vous permettre d'obtenir (ou de découvrir) les polices incorporées dans une présentation. Pour supprimer des polices, la méthode [removeEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (exposée par la même classe) est utilisée.

Ce code Java montre comment obtenir et supprimer les polices incorporées d'une présentation :
```java
// Instancie un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Rend une diapositive contenant un cadre de texte qui utilise la police incorporée "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Enregistre l'image sur le disque au format JPEG
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Obtient toutes les polices incorporées
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

    // Enregistre la présentation sans la police "Calibri" incorporée sur le disque
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajouter des polices incorporées**

En utilisant l'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/java/com.aspose.slides/embedfontcharacters/) ainsi que les deux surcharges de la méthode [addEmbeddedFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-), vous pouvez choisir la règle d'incorporation qui vous convient pour incorporer les polices dans une présentation. Ce code Java montre comment incorporer et ajouter des polices à une présentation :
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


## **Compresser les polices incorporées**

Pour vous permettre de compresser les polices incorporées dans une présentation et réduire sa taille de fichier, Aspose.Slides fournit la méthode [compressEmbeddedFonts](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (exposée par la classe [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)).

Ce code Java montre comment compresser les polices PowerPoint incorporées :
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

**Comment savoir si une police spécifique dans la présentation sera quand même substituée lors du rendu malgré son incorporation ?**

Vérifiez les [informations de substitution](/slides/fr/java/font-substitution/) dans le gestionnaire de polices et les [règles de secours/substitution](/slides/fr/java/fallback-font/) : si la police n'est pas disponible ou est restreinte, un secours sera utilisé.

**Vale-t-il la peine d'incorporer les polices « système » telles qu'Arial/Calibri ?**

En général non — elles sont presque toujours disponibles. Mais pour une portabilité totale dans des environnements « minces » (Docker, un serveur Linux sans polices préinstallées), incorporer les polices système peut éliminer le risque de substitutions inattendues.