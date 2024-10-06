---
title: Rectangle
type: docs
weight: 80
url: /androidjava/rectangle/
---

{{% alert color="primary" %}} 

Comme les sujets précédents, celui-ci concerne également l'ajout d'une forme et cette fois la forme dont nous allons parler est **Rectangle**. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives à l'aide d'Aspose.Slides pour Android via Java.

{{% /alert %}} 

## **Ajouter un Rectangle à la Diapositive**
Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de type Rectangle à l'aide de la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.

```java
// Instantiate Prseetation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add AutoShape of ellipse type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Write the PPTX file to disk
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter un Rectangle Formaté à la Diapositive**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) de type Rectangle à l'aide de la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Définissez le [Type de Remplissage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) du Rectangle sur Solide.
- Définissez la Couleur du Rectangle en utilisant la méthode [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) exposée par l'objet [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) associé à l'objet [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- Définissez la Couleur des lignes du Rectangle.
- Définissez la Largeur des lignes du Rectangle.
- Écrivez la présentation modifiée en tant que fichier PPTX.

Les étapes ci-dessus sont implémentées dans l'exemple ci-dessous.

```java
// Instantiate Prseetation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add AutoShape of ellipse type
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Apply some formatting to ellipse shape
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Apply some formatting to the line of Ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Write the PPTX file to disk
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```