---
title: Image
type: docs
weight: 10
url: /fr/net/image/
keywords: "Ajouter une image, Ajouter une photo, Présentation PowerPoint, EMF, SVG, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter une image à une diapositive ou une présentation PowerPoint en C# ou .NET"
---

## **Images dans les Diapositives Dans les Présentations**

Les images rendent les présentations plus captivantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images à partir d'un fichier, d'internet ou d'autres emplacements sur les diapositives. De même, Aspose.Slides vous permet d'ajouter des images aux diapositives de vos présentations par le biais de différentes procédures.

{{% alert title="Astuce" color="primary" %}} 

Aspose propose des convertisseurs gratuits—[JPEG à PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG à PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent aux utilisateurs de créer rapidement des présentations à partir d'images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant qu'objet cadre—surtout si vous prévoyez d'utiliser des options de formatage standard pour en changer la taille, ajouter des effets, etc.—voir [Cadre Image](https://docs.aspose.com/slides/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Vous pouvez manipuler les opérations d'entrée/sortie impliquant des images et des présentations PowerPoint pour convertir une image d'un format à un autre. Consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les opérations avec des images dans ces formats populaires : JPEG, PNG, BMP, GIF, et d'autres. 

## **Ajouter des Images Stockées Localement aux Diapositives**

Vous pouvez ajouter une ou plusieurs images sur votre ordinateur à une diapositive dans une présentation. Ce code d'exemple en C# vous montre comment ajouter une image à une diapositive :

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Ajouter des Images du Web aux Diapositives**

Si l'image que vous souhaitez ajouter à une diapositive n'est pas disponible sur votre ordinateur, vous pouvez ajouter l'image directement depuis le web. 

Ce code d'exemple vous montre comment ajouter une image depuis le web à une diapositive en C# :

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Ajouter des Images aux Masters de Diapositives**

Un master de diapositive est la diapositive principale qui stocke et contrôle les informations (thème, mise en page, etc.) sur toutes les diapositives qui lui sont sous-jacentes. Ainsi, lorsque vous ajoutez une image à un master de diapositive, cette image apparaît sur chaque diapositive sous ce master. 

Ce code d'exemple en C# vous montre comment ajouter une image à un master de diapositive :

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Ajouter des Images Comme Arrière-Plan de Diapositive**

Vous pouvez décider d'utiliser une image comme arrière-plan pour une diapositive spécifique ou plusieurs diapositives. Dans ce cas, vous devez voir *[Définir des Images comme Arrière-Plans pour les Diapositives](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter du SVG aux Présentations**
Vous pouvez ajouter ou insérer n'importe quelle image dans une présentation en utilisant la méthode [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) qui appartient à l'interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

Pour créer un objet image basé sur une image SVG, vous pouvez procéder comme suit :

1. Créer un objet SvgImage pour l'insérer dans ImageShapeCollection
2. Créer un objet PPImage à partir de ISvgImage
3. Créer un objet PictureFrame en utilisant l'interface IPPImage

Ce code d'exemple vous montre comment mettre en œuvre les étapes ci-dessus pour ajouter une image SVG dans une présentation :
``` csharp 
// Le chemin vers le répertoire des documents
string dataDir = @"D:\Documents\";

// Nom du fichier SVG source
string svgFileName = dataDir + "sample.svg";

// Nom du fichier de présentation de sortie
string outPptxPath = dataDir + "presentation.pptx";

// Créer une nouvelle présentation
using (var p = new Presentation())
{
    // Lire le contenu du fichier SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Créer un objet SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Créer un objet PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Crée un nouveau PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Enregistrer la présentation au format PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Conversion de SVG en Ensemble de Formes**
La conversion de SVG en un ensemble de formes par Aspose.Slides est similaire à la fonctionnalité de PowerPoint utilisée pour travailler avec des images SVG :

![Menu contextuel PowerPoint](img_01_01.png)

La fonctionnalité est fournie par l'un des surcharges de la méthode [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) de l'interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) qui prend un objet [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) comme premier argument.

Ce code d'exemple vous montre comment utiliser la méthode décrite pour convertir un fichier SVG en un ensemble de formes :

``` csharp 
// Le chemin vers le répertoire des documents
string dataDir = @"D:\Documents\";

// Nom du fichier SVG source
string svgFileName = dataDir + "sample.svg";

// Nom du fichier de présentation de sortie
string outPptxPath = dataDir + "presentation.pptx";

// Créer une nouvelle présentation
using (IPresentation presentation = new Presentation())
{
    // Lire le contenu du fichier SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Créer un objet SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obtenir la taille de la diapositive
    SizeF slideSize = presentation.SlideSize.Size;

    // Convertir l'image SVG en groupe de formes en l'échelonnant à la taille de la diapositive
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Enregistrer la présentation au format PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Ajouter des Images Comme EMF dans les Diapositives**
Aspose.Slides pour .NET vous permet de générer des images EMF à partir de feuilles Excel et d'ajouter les images en tant qu'EMF dans les diapositives avec Aspose.Cells. 

Ce code d'exemple vous montre comment réaliser la tâche décrite :

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Sauvegarder le classeur dans un flux
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

{{% alert title="Info" color="info" %}}

En utilisant le convertisseur gratuit [Texte à GIF](https://products.aspose.app/slides/text-to-gif) d'Aspose, vous pouvez facilement animer des textes, créer des GIF à partir de textes, etc. 

{{% /alert %}}