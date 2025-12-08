---
title: Gérer la forme SmartArt
type: docs
weight: 20
url: /fr/net/manage-smartart-shape/
keywords: "forme SmartArt, style de forme SmartArt, style de couleur de forme SmartArt, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Gérer les SmartArt dans les présentations PowerPoint en C# ou .NET"
---

## **Créer une forme SmartArt**
Aspose.Slides for .NET permet désormais d’ajouter des formes SmartArt personnalisées dans leurs diapositives à partir de zéro. Aspose.Slides for .NET fournit l’API la plus simple pour créer des formes SmartArt de la manière la plus facile. Pour créer une forme SmartArt dans une diapositive, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenir la référence d’une diapositive en utilisant son indice.
- Ajouter une forme SmartArt en définissant son LayoutType.
- Enregistrer la présentation modifiée en fichier PPTX.
```c#
 // Instancier la présentation
 using (Presentation pres = new Presentation())
 {

     // Accéder à la diapositive de la présentation
     ISlide slide = pres.Slides[0];

     // Ajouter une forme SmartArt
     ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

     // Enregistrement de la présentation
     pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```


## **Accéder à la forme SmartArt dans la diapositive**
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de la présentation. Dans l’exemple de code, nous parcourrons chaque forme de la diapositive et vérifierons s’il s’agit d’une forme SmartArt. Si la forme est de type SmartArt, nous la convertirons en instance SmartArt.
```c#
 // Charge la présentation souhaitée
 using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
 {
 
     // Parcourez chaque forme dans la première diapositive
     foreach (IShape shape in pres.Slides[0].Shapes)
     {
         // Vérifiez si la forme est de type SmartArt
         if (shape is ISmartArt)
         {
             // Convertissez la forme en SmartArt
             ISmartArt smart = (ISmartArt)shape;
             System.Console.WriteLine("Shape Name:" + smart.Name);
 
         }
     }
 }
```


## **Accéder à la forme SmartArt avec un type de mise en page particulier**
Le code d’exemple suivant aidera à accéder à la forme SmartArt avec un LayoutType particulier. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et ne peut être défini que lors de l’ajout de la forme SmartArt.

- Créer une instance de la classe `Presentation` et charger la présentation contenant une forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son indice.
- Parcourir chaque forme de la première diapositive.
- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArt si c’est le cas.
- Vérifier la forme SmartArt avec le LayoutType particulier et effectuer les actions requises par la suite.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir chaque forme dans la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Vérifier la disposition SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```


## **Modifier le style de la forme SmartArt**
Le code d’exemple suivant aidera à accéder à la forme SmartArt avec un LayoutType particulier.

- Créer une instance de la classe `Presentation` et charger la présentation contenant une forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son indice.
- Parcourir chaque forme de la première diapositive.
- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArt si c’est le cas.
- Trouver la forme SmartArt avec un style particulier.
- Définir le nouveau style pour la forme SmartArt.
- Enregistrer la présentation.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir chaque forme dans la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Vérifier le style SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Modifier le style SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Enregistrement de la présentation
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```


## **Modifier le style de couleur de la forme SmartArt**
Dans cet exemple, nous apprendrons à changer le style de couleur d’une forme SmartArt. Le code d’exemple suivant accédera à la forme SmartArt avec un style de couleur particulier et modifiera son style.

- Créer une instance de la classe `Presentation` et charger la présentation contenant une forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son indice.
- Parcourir chaque forme de la première diapositive.
- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArt si c’est le cas.
- Trouver la forme SmartArt avec un style de couleur particulier.
- Définir le nouveau style de couleur pour la forme SmartArt.
- Enregistrer la présentation.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir chaque forme dans la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Vérifier le type de couleur SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Modifier le type de couleur SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Enregistrement de la présentation
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis-je animer le SmartArt comme un objet unique ?**

Oui. SmartArt est une forme, vous pouvez donc appliquer les [animations standard](/slides/fr/net/powerpoint-animation/) via l’API d’animations (entrée, sortie, mise en valeur, chemins de mouvement) comme pour les autres formes.

**Comment trouver un SmartArt spécifique sur une diapositive si je ne connais pas son ID interne ?**

Définissez et utilisez le texte alternatif (AltText) et recherchez la forme à l’aide de cette valeur — c’est la méthode recommandée pour localiser la forme cible.

**Puis-je regrouper le SmartArt avec d’autres formes ?**

Oui. Vous pouvez regrouper le SmartArt avec d’autres formes (images, tableaux, etc.) puis [manipuler le groupe](/slides/fr/net/group/).

**Comment obtenir une image d’un SmartArt spécifique (par exemple, pour un aperçu ou un rapport) ?**

Exportez une vignette/image de la forme ; la bibliothèque peut [rendre des formes individuelles](/slides/fr/net/create-shape-thumbnails/) en fichiers raster (PNG/JPG/TIFF).

**L’apparence du SmartArt sera‑t‑elle conservée lors de la conversion de toute la présentation en PDF ?**

Oui. Le moteur de rendu vise une haute fidélité pour l’[export PDF](/slides/fr/net/convert-powerpoint-to-pdf/), avec une gamme d’options de qualité et de compatibilité.