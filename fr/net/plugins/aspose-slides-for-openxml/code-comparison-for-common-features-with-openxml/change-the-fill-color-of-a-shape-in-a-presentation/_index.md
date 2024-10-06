---
title: Changer la couleur de remplissage d'une forme dans une présentation
type: docs
weight: 40
url: /net/change-the-fill-color-of-a-shape-in-a-presentation/
---

## **OpenXML Presentation**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Couleur de remplissage d'une forme.pptx";

SetPPTShapeColor(FileName);

// Changer la couleur de remplissage d'une forme.

// Le fichier de test doit avoir une forme remplie comme première forme de la première diapositive.

public static void SetPPTShapeColor(string docName)

{

    using (PresentationDocument ppt = PresentationDocument.Open(docName, true))

    {

        // Obtenir l'ID de relation de la première diapositive.

        PresentationPart part = ppt.PresentationPart;

        OpenXmlElementList slideIds = part.Presentation.SlideIdList.ChildElements;

        string relId = (slideIds[0] as SlideId).RelationshipId;

        // Obtenir la partie diapositive à partir de l'ID de relation.

        SlidePart slide = (SlidePart)part.GetPartById(relId);

        if (slide != null)

        {

            // Obtenir l'arbre des formes qui contient la forme à changer.

            ShapeTree tree = slide.Slide.CommonSlideData.ShapeTree;

            // Obtenir la première forme dans l'arbre des formes.

            Shape shape = tree.GetFirstChild<Shape>();

            if (shape != null)

            {

                // Obtenir le style de la forme.

                ShapeStyle style = shape.ShapeStyle;

                // Obtenir la référence de remplissage.

                Drawing.FillReference fillRef = style.FillReference;

                // Définir la couleur de remplissage sur SchemeColor Accent 6;

                fillRef.SchemeColor = new Drawing.SchemeColor();

                fillRef.SchemeColor.Val = Drawing.SchemeColorValues.Accent6;

                // Sauvegarder la diapositive modifiée.

                slide.Slide.Save();

            }

        }

    }

}

``` 
## **Aspose.Slides**
Nous devons suivre les étapes suivantes pour remplir les formes dans la présentation :

- Créer une instance de la classe Presentation.
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter une forme IShape à la diapositive.
- Définir le type de remplissage de la forme sur Solide.
- Définir la couleur de la forme.
- Écrire la présentation modifiée sous forme de fichier PPTX.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Couleur de remplissage d'une forme.pptx";

//Instancier la classe PresentationEx qui représente le PPTX 

using (Presentation pres = new Presentation())

{

    //Obtenir la première diapositive

    ISlide sld = pres.Slides[0];

    //Ajouter une forme automatique de type rectangle

    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    //Définir le type de remplissage sur Solide

    shp.FillFormat.FillType = FillType.Solid;

    //Définir la couleur du rectangle

    shp.FillFormat.SolidFillColor.Color = Color.Yellow;

    //Écrire le fichier PPTX sur le disque

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Télécharger l'exemple de code en cours d'exécution**
- [CodePlex](https://asposeopenxml.codeplex.com/releases/view/615920)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **Exemple de code**
- [CodePlex](https://asposeopenxml.codeplex.com/SourceControl/latest#Aspose.Slides VS OpenXML/Apply Theme to Presentation/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Fill%20Color%20of%20a%20Shape)