---
title: Incorporer des polices dans les présentations en .NET
linktitle: Incorporation de police
type: docs
weight: 40
url: /fr/net/embedded-font/
keywords:
- ajouter une police
- incorporer une police
- incorporation de police
- obtenir une police incorporée
- ajouter une police incorporée
- supprimer une police incorporée
- compresser une police incorporée
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Incorporez des polices TrueType dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour .NET, garantissant un rendu précis sur toutes les plateformes."
---

**Incorporation des polices dans PowerPoint** garantit que votre présentation conserve son apparence prévue sur différents systèmes. Que vous utilisiez des polices uniques pour la créativité ou des polices standard, l’incorporation des polices empêche les perturbations de texte et de mise en page.

Si vous avez utilisé une police tierce ou non standard parce que vous avez fait preuve de créativité dans votre travail, vous avez alors encore plus de raisons d’incorporer votre police. Sinon (sans polices incorporées), le texte ou les chiffres sur vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus.

Utilisez les classes [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/), et [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) pour gérer les polices incorporées.

## **Obtenir et supprimer les polices incorporées**

Récupérez ou supprimez les polices incorporées d’une présentation sans effort avec les méthodes [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) et [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont).

Ce code C# vous montre comment obtenir et supprimer les polices incorporées d’une présentation :
```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Rend une diapositive contenant un cadre de texte qui utilise la police incorporée "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Recherche la police "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Supprime la police "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Rend la présentation; la police "Calibri" est remplacée par une police existante
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Enregistre la présentation sans la police "Calibri" incorporée sur le disque
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```



## **Ajouter des polices incorporées**

En utilisant l’énumération [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) et les deux surcharges de la méthode [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/), vous pouvez choisir la règle d’incorporation qui vous convient pour incorporer les polices dans une présentation. Ce code C# vous montre comment incorporer et ajouter des polices à une présentation :
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


## **Compresser les polices incorporées**

Optimisez la taille du fichier en compressant les polices incorporées à l’aide de [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Exemple de code pour la compression :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Comment savoir si une police spécifique dans la présentation sera encore substituée lors du rendu malgré l’incorporation ?**

Vérifiez les [informations de substitution](/slides/fr/net/font-substitution/) dans le gestionnaire de polices et les [règles de secours/substitution](/slides/fr/net/fallback-font/) : si la police est indisponible ou restreinte, un secours sera utilisé.

**Cela vaut-il la peine d’incorporer les polices « système » comme Arial/Calibri ?**

Habituellement non — elles sont presque toujours disponibles. Mais pour une portabilité totale dans des environnements « minces » (Docker, un serveur Linux sans polices préinstallées), incorporer les polices système peut éliminer le risque de substitutions inattendues.