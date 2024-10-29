---
title: Police intégrée - API PowerPoint C#
linktitle: Police intégrée
type: docs
weight: 40
url: /fr/net/embedded-font/
keywords:
- polices
- polices intégrées
- ajouter des polices
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Utilisez des polices intégrées dans les présentations PowerPoint en C# ou .NET"
---

**Les polices intégrées dans PowerPoint** sont utiles lorsque vous souhaitez que votre présentation apparaisse correctement lorsqu'elle est ouverte sur n'importe quel système ou appareil. Si vous avez utilisé une police tierce ou non standard parce que vous avez été créatif avec votre travail, alors vous avez encore plus de raisons d'intégrer votre police. Sinon (sans polices intégrées), les textes ou les chiffres de vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus.

La classe [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), la classe [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/), la classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) et leurs interfaces contiennent la plupart des propriétés et méthodes dont vous avez besoin pour travailler avec des polices intégrées dans les présentations PowerPoint.

## **Obtenir ou supprimer des polices intégrées d'une présentation**

Aspose.Slides fournit la méthode [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) (exposée par la classe [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/)) pour vous permettre d'obtenir (ou de découvrir) les polices intégrées dans une présentation. Pour supprimer les polices, la méthode [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) (exposée par la même classe) est utilisée.

Ce code C# vous montre comment obtenir et supprimer des polices intégrées d'une présentation :

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Rendu d'une diapositive contenant un cadre de texte utilisant la police intégrée "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Recherche de la police "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Suppression de la police "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Rendu de la présentation ; la police "Calibri" est remplacée par une existante
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Enregistrement de la présentation sans la police intégrée "Calibri" sur disque
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Ajouter des polices intégrées à la présentation**

En utilisant l'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) et deux surcharges de la méthode [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/), vous pouvez sélectionner votre règle (d'intégration) préférée pour intégrer les polices dans une présentation. Ce code C# vous montre comment intégrer et ajouter des polices à une présentation :

```c#
// Charge la présentation
Presentation presentation = new Presentation("Fonts.pptx");

// Charge la police source à remplacer
IFontData sourceFont = new FontData("Arial");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Enregistre la présentation sur disque
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Compresser les polices intégrées**

Pour vous permettre de compresser les polices intégrées dans une présentation et de réduire sa taille de fichier, Aspose.Slides fournit la méthode [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) (exposée par la classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)).

Ce code C# vous montre comment compresser les polices PowerPoint intégrées :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```