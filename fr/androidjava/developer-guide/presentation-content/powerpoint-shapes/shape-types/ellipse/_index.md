---
title: Ellipse
type: docs
weight: 30
url: /fr/androidjava/ellipse/
---


{{% alert color="primary" %}} 

Dans ce sujet, nous allons présenter aux développeurs comment ajouter des formes elliptiques à leurs diapositives en utilisant Aspose.Slides pour Android via Java. Aspose.Slides pour Android via Java fournit un ensemble d'API plus facile pour dessiner différents types de formes en seulement quelques lignes de code.

{{% /alert %}} 

## **Créer une Ellipse**
Pour ajouter une simple ellipse à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez un AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté une ellipse à la première diapositive.

```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ajouter un AutoShape de type ellipse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Écrire le fichier PPTX sur le disque
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Créer une Ellipse Formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez un AutoShape de type Ellipse en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Définissez le type de remplissage de l'Ellipse sur Solide.
- Définissez la couleur de l'Ellipse en utilisant la propriété SolidFillColor.Color exposée par l'objet [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) associé à l'objet [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- Définissez la couleur des lignes de l'Ellipse.
- Définissez la largeur des lignes de l'Ellipse.
- Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.

```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter un AutoShape de type ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Appliquer un certain formatage à la forme ellipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Appliquer un certain formatage à la ligne de l'Ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Écrire le fichier PPTX sur le disque
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```