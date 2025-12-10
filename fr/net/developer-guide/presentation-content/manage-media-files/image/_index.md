---
title: Optimiser la gestion des images dans les présentations en .NET
linktitle: Gérer les images
type: docs
weight: 10
url: /fr/net/image/
keywords:
- ajouter une image
- ajouter une illustration
- ajouter un bitmap
- remplacer une image
- remplacer une illustration
- depuis le web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour .NET, en optimisant les performances et en automatisant votre flux de travail."
---

## **Images dans les diapositives de présentation**

Les images rendent les présentations plus attrayantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images à partir d’un fichier, d’internet ou d’autres emplacements dans les diapositives. De même, Aspose.Slides vous permet d’ajouter des images aux diapositives de vos présentations via différentes procédures.

{{% alert  title="Tip" color="primary" %}} 

Aspose propose des convertisseurs gratuits—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent de créer rapidement des présentations à partir d’images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant qu’objet de cadre—en particulier si vous prévoyez d’utiliser les options de mise en forme standard pour modifier sa taille, ajouter des effets, etc.—voir [Picture Frame](https://docs.aspose.com/slides/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Vous pouvez manipuler les opérations d’entrée/sortie impliquant des images et des présentations PowerPoint pour convertir une image d’un format à un autre. Consultez ces pages : convertissez [image en JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertissez [JPG en image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertissez [JPG en PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertissez [PNG en JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertissez [PNG en SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertissez [SVG en PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les opérations avec les images dans ces formats populaires : JPEG, PNG, BMP, GIF et autres. 

## **Ajouter des images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images de votre ordinateur à une diapositive d’une présentation. Ce code d’exemple en C# montre comment ajouter une image à une diapositive :
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Ajouter des images depuis le Web aux diapositives**

Si l’image que vous souhaitez ajouter à une diapositive n’est pas disponible sur votre ordinateur, vous pouvez l’ajouter directement depuis le Web. 

Ce code d’exemple montre comment ajouter une image depuis le Web à une diapositive en C# :
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


## **Ajouter des images aux maîtres de diapositives**

Un maître de diapositive est la diapositive principale qui stocke et contrôle les informations (thème, mise en page, etc.) de toutes les diapositives qui en dépendent. Ainsi, lorsque vous ajoutez une image à un maître de diapositive, cette image apparaît sur chaque diapositive qui utilise ce maître. 

Ce code d’exemple en C# montre comment ajouter une image à un maître de diapositive :
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


## **Ajouter des images comme arrière‑plans de diapositives**

Vous pouvez choisir d’utiliser une image comme arrière‑plan d’une diapositive spécifique ou de plusieurs diapositives. Dans ce cas, consultez *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter des SVG aux présentations**

Vous pouvez ajouter ou insérer n’importe quelle image dans une présentation en utilisant la méthode [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) appartenant à l’interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection). 

Pour créer un objet image basé sur une image SVG, vous pouvez procéder ainsi :

1. Créer un objet SvgImage pour l’insérer dans ImageShapeCollection
2. Créer un objet PPImage à partir de ISvgImage
3. Créer un objet PictureFrame en utilisant l’interface IPPImage

Ce code d’exemple montre comment implémenter les étapes ci‑dessus pour ajouter une image SVG dans une présentation :
``` csharp 
// Le chemin du répertoire des documents
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

    // Créer l'objet SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Créer l'objet PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Crée un nouveau PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Enregistrer la présentation au format PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Convertir un SVG en ensemble de formes**

La conversion d’Aspose.Slides d’un SVG en ensemble de formes est similaire à la fonctionnalité PowerPoint utilisée pour travailler avec les images SVG :

![PowerPoint Popup Menu](img_01_01.png)

La fonctionnalité est fournie par l’une des surcharges de la méthode [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) de l’interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) qui prend un objet [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) en premier argument.

Ce code d’exemple montre comment utiliser la méthode décrite pour convertir un fichier SVG en ensemble de formes :
``` csharp 
// Le chemin du répertoire des documents
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

    // Créer l'objet SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obtenir la taille de la diapositive
    SizeF slideSize = presentation.SlideSize.Size;

    // Convertir l'image SVG en groupe de formes en l'ajustant à la taille de la diapositive
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Enregistrer la présentation au format PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Ajouter des images en EMF aux diapositives**

Aspose.Slides pour .NET vous permet de générer des images EMF à partir de feuilles Excel et d’ajouter ces images en EMF dans les diapositives avec Aspose.Cells. 

Ce code d’exemple montre comment réaliser la tâche décrite :
``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Enregistrer le classeur dans le flux
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


## **Remplacer des images dans la collection d’images**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d’images d’une présentation (y compris celles utilisées par les formes de diapositive). Cette section montre plusieurs approches pour mettre à jour les images de la collection. L’API propose des méthodes simples pour remplacer une image en utilisant des données brutes, une instance [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) ou une autre image déjà présente dans la collection.

1. Charger le fichier de présentation contenant des images à l’aide de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Charger une nouvelle image depuis un fichier dans un tableau d’octets.
3. Remplacer l’image cible par la nouvelle image en utilisant le tableau d’octets.
4. Dans la deuxième approche, charger l’image dans un objet [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) et remplacer l’image cible par cet objet.
5. Dans la troisième approche, remplacer l’image cible par une image déjà présente dans la collection d’images de la présentation.
6. Enregistrer la présentation modifiée au format PPTX.
```cs
// Instancier la classe Presentation qui représente un fichier de présentation.
using Presentation presentation = new Presentation("sample.pptx");

// La première méthode.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// La deuxième méthode.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// La troisième méthode.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Enregistrer la présentation dans un fichier.
presentation.Save("output.pptx", SaveFormat.Pptx);
```


{{% alert title="Info" color="info" %}}

En utilisant le convertisseur GRATUIT Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif), vous pouvez facilement animer du texte, créer des GIF à partir de textes, etc. 

{{% /alert %}}

## **FAQ**

**La résolution originale de l’image reste‑t‑elle intacte après l’insertion ?**

Oui. Les pixels d’origine sont conservés, mais l’apparence finale dépend de la façon dont l’[image](/slides/fr/net/picture-frame/) est mise à l’échelle sur la diapositive et de toute compression appliquée lors de l’enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives en une fois ?**

Placez le logo sur le maître de diapositive ou sur une mise en page et remplacez‑le dans la collection d’images de la présentation — les modifications se propageront à tous les éléments qui utilisent cette ressource.

**Un SVG inséré peut‑il être converti en formes modifiables ?**

Oui. Vous pouvez convertir un SVG en groupe de formes, après quoi chaque partie devient modifiable avec les propriétés standard des formes.

**Comment définir une image comme arrière‑plan pour plusieurs diapositives simultanément ?**

[Attribuez l’image comme arrière‑plan](/slides/fr/net/presentation-background/) sur le maître de diapositive ou la mise en page concernée—toutes les diapositives utilisant ce maître/mise en page hériteront de l’arrière‑plan.

**Comment empêcher la présentation de « gonfler » en taille à cause de nombreuses images ?**

Réutilisez une seule ressource d’image au lieu de duplicata, choisissez des résolutions raisonnables, appliquez une compression lors de l’enregistrement et conservez les graphiques répétés sur le maître lorsque cela est approprié.