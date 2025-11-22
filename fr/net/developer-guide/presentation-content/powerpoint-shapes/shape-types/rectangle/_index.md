---
title: Rectangle
type: docs
weight: 80
url: /fr/net/rectangle/
keywords: "Créer un rectangle, forme PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Créer un rectangle dans une présentation PowerPoint en C# ou .NET"
---

## **Créer un rectangle simple**
Comme les sujets précédents, celui‑ci porte également sur l'ajout d'une forme et cette fois la forme que nous allons aborder est le Rectangle. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides pour .NET. Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. Ajoutez un IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple indiqué ci‑bas, nous avons ajouté un rectangle simple à la première diapositive de la présentation.
```c#
// Instancie la classe Presentation qui représente le PPTX
using (Presentation pres = new Presentation())
{

    // Obtient la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajoute une forme automatique de type rectangle
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Enregistre le fichier PPTX sur le disque
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```



## **Créer un rectangle formaté**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. Ajoutez un IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Définissez le type de remplissage du Rectangle sur Solid.
1. Définissez la couleur du Rectangle en utilisant la propriété SolidFillColor.Color exposée par l'objet FillFormat associé à l'objet IShape.
1. Définissez la couleur des lignes du Rectangle.
1. Définissez la largeur des lignes du Rectangle.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.
   Les étapes ci‑dessus sont implémentées dans l'exemple présenté ci‑bas.
```c#
// Instancier la classe Presentation qui représente le PPTX
using (Presentation pres = new Presentation())
{

    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une forme automatique de type rectangle
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Appliquer un formatage à la forme rectangle
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Appliquer un formatage à la ligne du rectangle
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Enregistrer le fichier PPTX sur le disque
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Comment ajouter un rectangle avec des coins arrondis ?**

Utilisez le [type de forme](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) à coins arrondis et ajustez le rayon des coins dans les propriétés de la forme ; l'arrondi peut également être appliqué séparément à chaque coin via des ajustements géométriques.

**Comment remplir un rectangle avec une image (texture) ?**

Sélectionnez le [type de remplissage](https://reference.aspose.com/slides/net/aspose.slides/filltype/), fournissez la source de l'image et configurez les [modes d'étirement/tuile](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/).

**Un rectangle peut‑il avoir une ombre et une lueur ?**

Oui. Les [ombres externes/intérieures, lueur et bords doux](/slides/fr/net/shape-effect/) sont disponibles avec des paramètres réglables.

**Puis‑je transformer un rectangle en bouton avec un hyperlien ?**

Oui. [Attribuez un hyperlien](/slides/fr/net/manage-hyperlinks/) au clic sur la forme (vers une diapositive, un fichier, une adresse web ou un e‑mail).

**Comment protéger un rectangle contre le déplacement et les modifications ?**

[Utilisez les verrous de forme](/slides/fr/net/applying-protection-to-presentation/) : vous pouvez interdire le déplacement, le redimensionnement, la sélection ou la modification du texte afin de préserver la mise en page.

**Puis‑je convertir un rectangle en image matricielle ou SVG ?**

Oui. Vous pouvez [rendre la forme](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) en image avec une taille/échelle spécifiée ou [l'exporter en SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) pour une utilisation vectorielle.

**Comment obtenir rapidement les propriétés réelles (effectives) d'un rectangle en tenant compte du thème et de l'héritage ?**

[Utilisez les propriétés effectives de la forme](/slides/fr/net/shape-effective-properties/) : l'API renvoie des valeurs calculées qui tiennent compte des styles de thème, de la mise en page et des paramètres locaux, simplifiant l'analyse du formatage.