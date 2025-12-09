---
title: Police incorporée - API JavaScript PowerPoint
linktitle: Police incorporée
type: docs
weight: 40
url: /fr/nodejs-java/embedded-font/
keywords: "Polices, polices incorporées, ajouter des polices, présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Utilisez des polices incorporées dans une présentation PowerPoint en JavaScript"
---

**Polices incorporées dans PowerPoint** sont utiles lorsque vous souhaitez que votre présentation s’affiche correctement sur n’importe quel système ou appareil. Si vous avez utilisé une police tierce ou non standard parce que vous avez fait preuve de créativité dans votre travail, vous avez encore plus de raisons d’incorporer votre police. Sinon (sans polices incorporées), le texte ou les nombres sur vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus. 

Les classes [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager), [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) et [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) et leurs classes contiennent la plupart des propriétés et méthodes dont vous avez besoin pour travailler avec les polices incorporées dans les présentations PowerPoint.

## **Obtenir ou supprimer les polices incorporées d’une présentation**

Aspose.Slides fournit la méthode [getEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (exposée par la classe [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager)) pour vous permettre d’obtenir (ou de découvrir) les polices incorporées dans une présentation. Pour supprimer des polices, la méthode [removeEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (exposée par la même classe) est utilisée.

Ce code JavaScript vous montre comment obtenir et supprimer les polices incorporées d’une présentation :
```javascript
// Instancie un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Rendu d’une diapositive contenant un cadre de texte qui utilise la police intégrée "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Enregistre l’image sur le disque au format JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Obtient toutes les polices intégrées
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Recherche la police "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Supprime la police "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Rendu de la présentation; "Calibri" font is replaced with an existing one
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Enregistre l’image sur le disque au format JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Enregistre la présentation sans la police intégrée "Calibri" sur le disque
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```



## **Ajouter des polices incorporées à une présentation**

En utilisant l’énumération [EmbedFontCharacters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embedfontcharacters/) ainsi que les deux surcharges de la méthode [addEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-), vous pouvez choisir la règle d’incorporation qui vous convient pour incorporer les polices dans une présentation. Ce code JavaScript vous montre comment incorporer et ajouter des polices à une présentation :
```javascript
// Charge la présentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Enregistre la présentation sur le disque
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Compresser les polices incorporées**

Pour vous permettre de compresser les polices incorporées dans une présentation et réduire sa taille de fichier, Aspose.Slides fournit la méthode [compressEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (exposée par la classe [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/)).

Ce code JavaScript vous montre comment compresser les polices PowerPoint incorporées :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Comment savoir si une police spécifique dans la présentation sera toujours substituée lors du rendu malgré l'incorporation ?**

Vérifiez les [informations de substitution](/slides/fr/nodejs-java/font-substitution/) dans le gestionnaire de polices et les [règles de secours/substitution](/slides/fr/nodejs-java/fallback-font/) : si la police est indisponible ou restreinte, un substitut sera utilisé.

**Vale-t-il la peine d’incorporer les polices « système » comme Arial/Calibri ?**

En général non — elles sont presque toujours disponibles. Mais pour une portabilité totale dans des environnements « minces » (Docker, un serveur Linux sans polices préinstallées), incorporer les polices système peut éliminer le risque de substitutions inattendues.