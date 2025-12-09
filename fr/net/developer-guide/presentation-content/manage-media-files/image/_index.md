---
title: Optimiser la gestion des images dans les présentations en .NET
linktitle: Gérer les images
type: docs
weight: 10
url: /fr/net/image/
keywords:
- ajouter image
- ajouter image
- ajouter bitmap
- remplacer image
- remplacer image
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

## **Images dans les diapositives des présentations**

Les images rendent les présentations plus attrayantes et interessantes. Dans Microsoft PowerPoint, vous pouvez insérer des images depuis un fichier, Internet ou d'autres emplacements sur les diapositives. De meme, Aspose.Slides vous permet d'ajouter des images aux diapositives de vos presentations via différentes methodes.

{{% alert  title="Tip" color="primary" %}} 
Aspose fournit des convertisseurs gratuits—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent de creer rapidement des presentations a partir d'images. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Si vous souhaitez ajouter une image en tant qu'objet de cadre—en particulier si vous prevoyez d'utiliser les options de mise en forme standard pour modifier sa taille, ajouter des effets, etc.—voir [Picture Frame](https://docs.aspose.com/slides/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Vous pouvez manipuler les operations d'entree/sortie impliquant des images et des presentations PowerPoint pour convertir une image d'un format a un autre. Consultez ces pages : convertir [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides prend en charge les operations avec les images dans ces formats populaires : JPEG, PNG, BMP, GIF et autres. 

## **Ajout d'images stockees localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images de votre ordinateur sur une diapositive d'une presentation. Ce code d'exemple en C# montre comment ajouter une image a une diapositive :
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Ajout d'images depuis le Web aux diapositives**

Si l'image que vous souhaitez ajouter a une diapositive n'est pas disponible sur votre ordinateur, vous pouvez l'ajouter directement depuis le Web. 
Ce code d'exemple montre comment ajouter une image depuis le Web a une diapositive en C# :
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


## **Ajout d'images aux maitres de diapositives**

Un maitre de diapositives est la diapositive principale qui stocke et controle les informations (theme, mise en page, etc.) de toutes les diapositives qui en dependent. Ainsi, lorsque vous ajoutez une image a un maitre de diapositives, cette image apparaît sur chaque diapositive qui utilise ce maitre. 
Ce code d'exemple en C# montre comment ajouter une image a un maitre de diapositives :
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


## **Ajout d'images comme arriere-plan de diapositive**

Vous pouvez decider d'utiliser une image comme arriere-plan pour une diapositive specifique ou plusieurs diapositives. Dans ce cas, consultez *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajout de SVG aux presentations**

Vous pouvez ajouter ou inserer n'importe quelle image dans une presentation en utilisant la methode [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) qui appartient a l'interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection). 
Pour creer un objet image a partir d'une image SVG, vous pouvez proceder ainsi :

1. Creer un objet SvgImage pour l'inserer dans ImageShapeCollection
2. Creer un objet PPImage a partir d'ISvgImage
3. Creer un objet PictureFrame en utilisant l'interface IPPImage

Ce code d'exemple montre comment mettre en oeuvre les etapes ci-dessus pour ajouter une image SVG a une presentation :
``` csharp 
// Le chemin du répertoire des documents
string dataDir = @"D:\Documents\";

// Nom du fichier SVG source
string svgFileName = dataDir + "sample.svg";

// Nom du fichier de présentation en sortie
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

    // Créer un nouveau PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Enregistrer la présentation au format PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Conversion de SVG en un ensemble de formes**

La conversion de SVG en un ensemble de formes d'Aspose.Slides est similaire a la fonctionnalite de PowerPoint utilisee pour travailler avec les images SVG :
![PowerPoint Popup Menu](img_01_01.png)

La fonctionnalite est fournie par l'une des surcharges de la methode [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) de l'interface [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) qui prend un objet [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) comme premier argument.

Ce code d'exemple montre comment utiliser la methode descrite pour convertir un fichier SVG en un ensemble de formes :
``` csharp 
// Le chemin du répertoire des documents
string dataDir = @"D:\Documents\";

// Nom du fichier SVG source
string svgFileName = dataDir + "sample.svg";

// Nom du fichier de présentation en sortie
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

    // Convertir l'image SVG en groupe de formes en l'adaptant à la taille de la diapositive
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Enregistrer la présentation au format PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Ajout d'images au format EMF dans les diapositives**

Aspose.Slides pour .NET vous permet de generer des images EMF a partir de feuilles Excel et d'ajouter les images au format EMF dans les diapositives avec Aspose.Cells. 
Ce code d'exemple montre comment effectuer la tache descrite :
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


## **Remplacement d'images dans la collection d'images**

Aspose.Slides vous permet de remplacer les images stockees dans la collection d'images d'une presentation (y compris celles utilisees par les formes de diapositives). Cette section montre plusieurs approches pour mettre a jour les images de la collection. L'API propose des methodes simples pour remplacer une image en utilisant des donnees brutes (byte), une instance [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) , ou une autre image deja presente dans la collection.

Suivez les etapes ci-dessous :

1. Chargez le fichier de presentation contenant des images a l'aide de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Chargez une nouvelle image depuis un fichier dans un tableau d'octets.
1. Remplacez l'image cible par la nouvelle image en utilisant le tableau d'octets.
1. Dans la deuxieme approche, chargez l'image dans un objet [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) et remplacez l'image cible par cet objet.
1. Dans la troisieme approche, remplacez l'image cible par une image deja presente dans la collection d'images de la presentation.
1. Enregistrez la presentation modifiee au format PPTX.
```cs
// Instancier la classe Presentation qui représente un fichier de présentation.
using Presentation presentation = new Presentation("sample.pptx");

// La première façon.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// La deuxième façon.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// La troisième façon.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Enregistrer la présentation dans un fichier.
presentation.Save("output.pptx", SaveFormat.Pptx);
```


{{% alert title="Info" color="info" %}}
En utilisant le convertisseur GRATUIT Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif), vous pouvez facilement animer du texte, creer des GIF a partir de texte, etc. 
{{% /alert %}}

## **FAQ**

**La resolution d'origine de l'image reste-t-elle intacte après l'insertion?**

Oui. Les pixels source sont conserves, mais l'apparence finale depend de la facon dont le [picture](/slides/fr/net/picture-frame/) est mis a l'echelle sur la diapositive et de la compression appliquee lors de l'enregistrement.

**Quelle est la meilleure facon de remplacer le meme logo sur des dizaines de diapositives en meme temps?**

Placez le logo sur la diapositive maitre ou sur une mise en page et remplacez-le dans la collection d'images de la presentation — les mises a jour se propageront a tous les elements qui utilisent cette ressource.

**Une SVG inseree peut-elle etre convertie en formes modifiables?**

Oui. Vous pouvez convertir un SVG en un groupe de formes, apres quoi chaque partie devient modifiable avec les proprietes standard des formes.

**Comment definir une image comme arriere-plan pour plusieurs diapositives en une fois?**

[Attribuez l'image comme arriere-plan](/slides/fr/net/presentation-background/) sur la diapositive maitre ou la mise en page appropriee — toutes les diapositives utilisant ce maitre/ce layout herediteront de l'arriere-plan.

**Comment empêcher la presentation d'"gonfler" en taille a cause de nombreuses images?**

Reusez une seule ressource d'image au lieu de duplicata, choisissez des resolutions raisonnables, appliquez une compression lors de l'enregistrement et conservez les graphiques repeats sur le maitre lorsque cela est approprie.