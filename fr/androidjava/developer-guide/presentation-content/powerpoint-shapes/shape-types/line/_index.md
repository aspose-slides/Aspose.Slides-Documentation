---
title: Ligne
type: docs
weight: 50
url: /fr/androidjava/Ligne/
---


{{% alert color="primary" %}} 

Aspose.Slides pour Android via Java prend en charge l'ajout de différents types de formes aux diapositives. Dans ce sujet, nous allons commencer à travailler avec les formes en ajoutant des lignes aux diapositives. En utilisant Aspose.Slides pour Android via Java, les développeurs peuvent non seulement créer des lignes simples, mais aussi dessiner des lignes plus élaborées sur les diapositives.

{{% /alert %}} 

## **Créer une ligne simple**

Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
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
    pres.save("LigneForme.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Créer une ligne en forme de flèche**

Aspose.Slides pour Android via Java permet également aux développeurs de configurer certaines propriétés de la ligne pour la rendre plus attrayante. Essayons de configurer quelques propriétés d'une ligne pour lui donner l'apparence d'une flèche. Veuillez suivre les étapes ci-dessous pour ce faire :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez une AutoShape de type Ligne en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposée par l'objet [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- Définissez le [Style de ligne](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineStyle) sur l'un des styles proposés par Aspose.Slides pour Android via Java.
- Définissez la largeur de la ligne.
- Définissez le [Style de dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineDashStyle) de la ligne sur l'un des styles proposés par Aspose.Slides pour Android via Java.
- Définissez le [Style de tête de flèche](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) et la [Longueur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) du point de départ de la ligne.
- Définissez le [Style de tête de flèche](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadStyle) et la [Longueur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LineArrowheadLength) du point d'arrivée de la ligne.
- Écrivez la présentation modifiée en tant que fichier PPTX.

```java
// Instancier la classe PresentationEx qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type ligne
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Appliquer un formatage sur la ligne
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
    pres.save("LigneForme.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```