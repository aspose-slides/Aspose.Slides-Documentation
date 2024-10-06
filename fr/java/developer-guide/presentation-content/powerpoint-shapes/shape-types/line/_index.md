---
title: Ligne
type: docs
weight: 50
url: /java/Ligne/
---


{{% alert color="primary" %}} 

Aspose.Slides pour Java prend en charge l'ajout de différents types de formes aux diapositives. Dans ce sujet, nous allons commencer à travailler avec des formes en ajoutant des lignes aux diapositives. En utilisant Aspose.Slides pour Java, les développeurs peuvent non seulement créer des lignes simples, mais des lignes plus élaborées peuvent également être tracées sur les diapositives.

{{% /alert %}} 

## **Créer une Ligne Simple**

Pour ajouter une simple ligne aux diapositives sélectionnées de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

```java
// Instancier la classe PresentationEx qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ajouter une AutoShape de type ligne
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Écrire le PPTX sur le disque
    pres.save("LigneShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Créer une Ligne en Forme de Flèche**

Aspose.Slides pour Java permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés d'une ligne pour qu'elle ressemble à une flèche. Veuillez suivre les étapes ci-dessous pour le faire :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- Définissez le [Style de Ligne](https://reference.aspose.com/slides/java/com.aspose.slides/LineStyle) sur l'un des styles offerts par Aspose.Slides pour Java.
- Définissez la Largeur de la ligne.
- Définissez le [Style de Tiret](https://reference.aspose.com/slides/java/com.aspose.slides/LineDashStyle) de la ligne sur l'un des styles offerts par Aspose.Slides pour Java.
- Définissez le [Style de Pointe de Flèche](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) et la [Longueur](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) du point de départ de la ligne.
- Définissez le [Style de Pointe de Flèche](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadStyle) et la [Longueur](https://reference.aspose.com/slides/java/com.aspose.slides/LineArrowheadLength) du point d'arrivée de la ligne.
- Écrivez la présentation modifiée en tant que fichier PPTX.

```java
// Instancier la classe PresentationEx qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type ligne
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Appliquer un certain formatage à la ligne
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Écrire le PPTX sur le disque
    pres.save("LigneShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```