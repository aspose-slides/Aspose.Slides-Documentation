---
title: Rectangle
type: docs
weight: 80
url: /java/rectangle/
---

{{% alert color="primary" %}} 

Comme les sujets précédents, celui-ci traite également de l'ajout d'une forme, et cette fois, la forme dont nous allons parler est **Rectangle**. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides pour Java.

{{% /alert %}} 

## **Ajouter un Rectangle à la Diapositive**
Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Écrivez la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.

```java
// Instancier la classe Prseetation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Écrire le fichier PPTX sur le disque
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter un Rectangle Formatté à la Diapositive**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) de type Rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Définissez le [Type de Remplissage](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) du Rectangle à Solide.
- Définissez la Couleur du Rectangle en utilisant la méthode [SolidFillColor.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) exposée par l'objet [IFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) associé à l'objet [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- Définissez la Couleur des lignes du Rectangle.
- Définissez la Largeur des lignes du Rectangle.
- Écrivez la présentation modifiée sous forme de fichier PPTX.

Les étapes ci-dessus sont mises en œuvre dans l'exemple donné ci-dessous.

```java
// Instancier la classe Prseetation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Appliquer un certain formatage à la forme ellipse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Appliquer un certain formatage aux lignes de l'Ellipse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Écrire le fichier PPTX sur le disque
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```