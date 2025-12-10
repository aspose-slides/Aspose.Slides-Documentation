---
title: Ajouter des rectangles aux présentations en .NET
linktitle: Rectangle
type: docs
weight: 80
url: /fr/net/rectangle/
keywords:
- ajouter un rectangle
- créer un rectangle
- forme de rectangle
- rectangle simple
- rectangle formaté
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Améliorez vos présentations PowerPoint en ajoutant des rectangles avec Aspose.Slides for .NET—concevez et modifiez facilement des formes par programmation."
---

## **Créer un rectangle simple**
Comme les sujets précédents, celui‑ci porte également sur l’ajout d’une forme et, cette fois, nous allons parler du rectangle. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides for .NET. Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, suivez les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir la référence d’une diapositive en utilisant son Index.
1. Ajouter un IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l’objet IShapes.
1. Enregistrer la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.
```c#
 // Instancier la classe Presentation qui représente le PPTX
using (Presentation pres = new Presentation())
{

    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une forme auto de type rectangle
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Écrire le fichier PPTX sur le disque
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```



## **Créer un rectangle formaté**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir la référence d’une diapositive en utilisant son Index.
1. Ajouter un IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l’objet IShapes.
1. Définir le type de remplissage du rectangle sur Solid.
1. Définir la couleur du rectangle en utilisant la propriété SolidFillColor.Color exposée par l’objet FillFormat associé à l’objet IShape.
1. Définir la couleur des lignes du rectangle.
1. Définir la largeur des lignes du rectangle.
1. Enregistrer la présentation modifiée au format PPTX.

Les étapes ci‑dessus sont implémentées dans l’exemple ci‑dessous.
```c#
 // Instancier la classe Presentation qui représente le PPTX
using (Presentation pres = new Presentation())
{

    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Ajouter une forme auto de type rectangle
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Appliquer un formatage à la forme rectangle
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Appliquer un formatage à la ligne du rectangle
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Écrire le fichier PPTX sur le disque
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Comment ajouter un rectangle avec des coins arrondis ?**  
Utilisez le type de forme à coins arrondis [shape type](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) et ajustez le rayon des coins dans les propriétés de la forme ; l’arrondissement peut également être appliqué coin par coin via des ajustements géométriques.

**Comment remplir un rectangle avec une image (texture) ?**  
Sélectionnez le type de remplissage d’image [fill type](https://reference.aspose.com/slides/net/aspose.slides/filltype/), fournissez la source de l’image et configurez les [modes d’étirement/tuile](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/).

**Un rectangle peut‑il avoir une ombre et une lueur ?**  
Oui. Les [ombres externes/intérieures, lueur et bords doux](/slides/fr/net/shape-effect/) sont disponibles avec des paramètres réglables.

**Puis‑je transformer un rectangle en bouton avec un hyperlien ?**  
Oui. [Attribuez un hyperlien](/slides/fr/net/manage-hyperlinks/) au clic de la forme (aller à une diapositive, fichier, adresse web ou e‑mail).

**Comment protéger un rectangle contre le déplacement et les modifications ?**  
[Utilisez le verrouillage des formes](/slides/fr/net/applying-protection-to-presentation/) : vous pouvez interdire le déplacement, le redimensionnement, la sélection ou la modification du texte afin de préserver la mise en page.

**Puis‑je convertir un rectangle en image raster ou SVG ?**  
Oui. Vous pouvez [rendre la forme](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) en une image avec une taille/échelle spécifiée ou [l’exporter au format SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) pour une utilisation vectorielle.

**Comment obtenir rapidement les propriétés réelles (effectives) d’un rectangle en tenant compte du thème et de l’héritage ?**  
[Utilisez les propriétés effectives de la forme](/slides/fr/net/shape-effective-properties/) : l’API renvoie des valeurs calculées qui tiennent compte des styles de thème, de la disposition et des paramètres locaux, simplifiant l’analyse du formatage.