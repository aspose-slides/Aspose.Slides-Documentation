---
title: Intégration de polices dans PowerPoint avec C#
linktitle: Intégration de polices
type: docs
weight: 40
url: /fr/net/embedded-font/
keywords:
- intégrer des polices
- PowerPoint C#
- ajouter des polices
- présentation
- Aspose.Slides for .NET
description: "Apprenez à intégrer, ajouter et gérer les polices dans les présentations PowerPoint en utilisant C# et .NET"
---

**Intégration de polices dans PowerPoint** garantit que votre présentation conserve son apparence prévue sur différents systèmes. Que vous utilisiez des polices uniques pour la créativité ou des polices standard, l’intégration de polices empêche les perturbations du texte et de la mise en page.

Si vous avez utilisé une police tierce ou non standard parce que vous avez fait preuve de créativité dans votre travail, vous avez encore plus de raisons d’intégrer votre police. Sinon (sans polices intégrées), les textes ou les chiffres de vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus. 

Utilisez les classes [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/), et [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) pour gérer les polices intégrées.

## **Obtention et suppression des polices intégrées**

Récupérez ou supprimez facilement les polices intégrées d’une présentation à l’aide des méthodes [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) et [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont).

Ce code C# vous montre comment obtenir et supprimer des polices intégrées d’une présentation :
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Rendu d'une diapositive contenant un cadre de texte qui utilise la police "FunSized" intégrée
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Trouve la police "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Supprime la police "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Rendu de la présentation ; la police "Calibri" est remplacée par une police existante
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Enregistre la présentation sans la police "Calibri" intégrée sur le disque
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```


## **Ajout de polices intégrées**

En utilisant l’énumération [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) et les deux surcharges de la méthode [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/), vous pouvez choisir la règle d’intégration qui vous convient pour intégrer les polices dans une présentation. Ce code C# montre comment intégrer et ajouter des polices à une présentation :
```c#
// Charge la présentation
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Enregistre la présentation sur le disque
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```


## **Compression des polices intégrées**

Optimisez la taille du fichier en compressant les polices intégrées à l’aide de [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Exemple de code pour la compression :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Comment savoir si une police spécifique de la présentation sera encore substituée lors du rendu malgré l’intégration ?**

Vérifiez les [informations de substitution](/slides/fr/net/font-substitution/) dans le gestionnaire de polices ainsi que les [règles de secours/substitution](/slides/fr/net/fallback-font/) : si la police est indisponible ou restreinte, une police de secours sera utilisée.

**Est‑il utile d’intégrer les polices « système » comme Arial/Calibri ?**

En général non — elles sont presque toujours disponibles. Mais pour une portabilité totale dans des environnements « minces » (Docker, un serveur Linux sans polices préinstallées), l’intégration des polices système peut éliminer le risque de substitutions inattendues.