---
title: Gérer les formes de présentation sur Android
linktitle: Manipulation de formes
type: docs
weight: 40
url: /fr/androidjava/shape-manipulations/
keywords:
- forme PowerPoint
- forme de présentation
- forme sur diapositive
- trouver une forme
- cloner une forme
- supprimer une forme
- masquer une forme
- modifier l'ordre des formes
- obtenir l'ID de forme interop
- texte alternatif de forme
- formats de mise en page de forme
- forme au format SVG
- forme en SVG
- aligner une forme
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à créer, modifier et optimiser les formes dans Aspose.Slides pour Android via Java et à fournir des présentations PowerPoint haute performance."
---

## **Trouver une forme sur une diapositive**
Ce sujet décrira une technique simple pour faciliter la recherche d’une forme spécifique sur une diapositive sans utiliser son Id interne. Il est important de savoir que les fichiers de présentation PowerPoint ne disposent d’aucun moyen d’identifier les formes sur une diapositive, sauf un Id unique interne. Il semble difficile pour les développeurs de trouver une forme en utilisant son Id unique interne. Toutes les formes ajoutées aux diapositives possèdent un texte alternatif. Nous suggérons aux développeurs d’utiliser le texte alternatif pour trouver une forme spécifique. Vous pouvez utiliser MS PowerPoint pour définir le texte alternatif des objets que vous prévoyez de modifier ultérieurement.

Après avoir défini le texte alternatif de la forme souhaitée, vous pouvez ouvrir cette présentation avec Aspose.Slides for Android via Java et parcourir toutes les formes ajoutées à une diapositive. À chaque itération, vous pouvez vérifier le texte alternatif de la forme et la forme dont le texte alternatif correspond sera celle dont vous avez besoin. Pour illustrer cette technique de manière plus claire, nous avons créé une méthode, [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) qui trouve une forme spécifique dans une diapositive et renvoie simplement cette forme.
```java
// Instancier une classe Presentation qui représente le fichier de présentation
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Texte alternatif de la forme à trouver
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// Implémentation de la méthode pour trouver une forme dans une diapositive en utilisant son texte alternatif
public static IShape findShape(ISlide slide, String alttext)
{
    // Itération sur toutes les formes de la diapositive
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Si le texte alternatif de la forme correspond à celui requis alors
        // Retourner la forme
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **Cloner une forme**
Pour cloner une forme sur une diapositive en utilisant Aspose.Slides for Android via Java :
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenir la référence d’une diapositive en utilisant son indice.
1. Accéder à la collection de formes de la diapositive source.
1. Ajouter une nouvelle diapositive à la présentation.
1. Cloner les formes de la collection de formes de la diapositive source vers la nouvelle diapositive.
1. Enregistrer la présentation modifiée au format PPTX.

L’exemple ci‑dessous ajoute une forme groupée à une diapositive.
```java
// Instancier la classe Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Enregistrer le fichier PPTX sur le disque
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Supprimer une forme**
Aspose.Slides for Android via Java permet aux développeurs de supprimer n’importe quelle forme. Pour supprimer la forme d’une diapositive, suivez les étapes ci‑dessous :
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Rechercher la forme avec un AlternativeText spécifique.
1. Supprimer la forme.
1. Enregistrer le fichier sur le disque.
```java
// Créer l'objet Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une forme auto de type rectangle
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Enregistrer la présentation sur le disque
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Masquer une forme**
Aspose.Slides for Android via Java permet aux développeurs de masquer n’importe quelle forme. Pour masquer la forme d’une diapositive, suivez les étapes ci‑dessus :
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Rechercher la forme avec un AlternativeText spécifique.
1. Masquer la forme.
1. Enregistrer le fichier sur le disque.
```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une forme auto de type rectangle
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Enregistrer la présentation sur le disque
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier l’ordre des formes**
Aspose.Slides for Android via Java permet aux développeurs de réorganiser les formes. Réorganiser les formes détermine quelle forme est au premier plan ou à l’arrière-plan. Pour réorganiser les formes d’une diapositive, suivez les étapes ci‑dessus :
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Ajouter une forme.
1. Ajouter du texte dans le cadre de texte de la forme.
1. Ajouter une autre forme aux mêmes coordonnées.
1. Réorganiser les formes.
1. Enregistrer le fichier sur le disque.
```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtenir l’ID de forme Interop**
Aspose.Slides for Android via Java permet aux développeurs d’obtenir un identifiant de forme unique au niveau de la diapositive, contrairement à la méthode [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--) qui permet d’obtenir un identifiant unique au niveau de la présentation. La méthode [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) a été ajoutée aux interfaces [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) et à la classe [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) respectivement. La valeur renvoyée par la méthode [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) correspond à la valeur de l’Id de l’objet Microsoft.Office.Interop.PowerPoint.Shape. Ci‑dessous, un exemple de code est fourni.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Obtention de l'identifiant unique de forme dans le périmètre de la diapositive
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir le texte alternatif d’une forme**
Aspose.Slides for Android via Java permet aux développeurs de définir l’AlternateText de n’importe quelle forme. Les formes d’une présentation peuvent être distinguées à l’aide de la méthode [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) ou [Shape Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-). Les méthodes [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) et [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) peuvent être lues ou définies en utilisant Aspose.Slides ainsi que Microsoft PowerPoint. En utilisant cette méthode, vous pouvez marquer une forme et effectuer différentes opérations comme la suppression d’une forme, le masquage d’une forme ou la réorganisation des formes sur une diapositive. Pour définir l’AlternateText d’une forme, suivez les étapes ci‑dessous :
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Ajouter n’importe quelle forme à la diapositive.
1. Effectuer des opérations avec la forme nouvellement ajoutée.
1. Parcourir les formes pour en trouver une.
1. Définir l’AlternativeText.
1. Enregistrer le fichier sur le disque.
```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une forme auto de type rectangle
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Enregistrer la présentation sur le disque
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Accéder aux formats de disposition d’une forme**
Aspose.Slides for Android via Java fournit une API simple pour accéder aux formats de disposition d’une forme. Cet article montre comment accéder aux formats de disposition. Le code d’exemple ci‑dessous est fourni.
```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Rendre une forme au format SVG**
Aspose.Slides for Android via Java prend désormais en charge le rendu d’une forme au format SVG. La méthode [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (et sa surcharge) a été ajoutée à la classe [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) et à l’interface [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape). Cette méthode permet d’enregistrer le contenu de la forme sous forme de fichier SVG. L’extrait de code ci‑dessous montre comment exporter la forme d’une diapositive vers un fichier SVG.
```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Aligner une forme**
Aspose.Slides permet d’aligner les formes soit par rapport aux marges de la diapositive, soit les unes par rapport aux autres. À cet effet, la méthode surchargée [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) a été ajoutée. L’enumération [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) définit les options d’alignement possibles.

**Example 1**

Le code source ci‑dessus aligne les formes aux indices 1, 2 et 4 le long du bord supérieur de la diapositive.
```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```


**Example 2**

L’exemple ci‑dessus montre comment aligner l’ensemble de la collection de formes par rapport à la forme la plus basse de la collection.
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **Propriétés de retournement**

In Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) fournit le contrôle du miroir horizontal et vertical des formes via ses propriétés `flipH` et `flipV`. Les deux propriétés sont de type `byte`, autorisant les valeurs `1` pour indiquer un retournement, `0` pour aucun retournement, ou `-1` pour le comportement par défaut. Ces valeurs sont accessibles depuis le [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) d’une forme.

Pour modifier les paramètres de retournement, une nouvelle instance de [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) est créée avec la position et la taille actuelles de la forme, les valeurs souhaitées pour `flipH` et `flipV`, et l’angle de rotation. L’affectation de cette instance au [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) de la forme et l’enregistrement de la présentation appliquent les transformations de miroir et les enregistrent dans le fichier de sortie.

Désignons un fichier sample.pptx dans lequel la première diapositive contient une seule forme avec les paramètres de retournement par défaut, comme indiqué ci‑dessous.

![The shape to be flipped](shape_to_be_flipped.png)

L’exemple de code suivant récupère les propriétés de retournement actuelles de la forme et la retourne à la fois horizontalement et verticalement.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Récupérer la propriété de retournement horizontal de la forme.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Récupérer la propriété de retournement vertical de la forme.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Retourner horizontalement.
    byte flipV = NullableBool.True; // Retourner horizontalement.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Le résultat:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Puis-je combiner des formes (union/intersection/soustraction) sur une diapositive comme dans un éditeur de bureau ?**

Il n’existe pas d’API d’opération booléenne intégrée. Vous pouvez l’approcher en construisant vous‑même le contour souhaité — par ex., en calculant la géométrie résultante (via [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)) et en créant une nouvelle forme avec ce contour, en option supprimant les formes originales.

**Comment contrôler l’ordre d’empilement (z‑order) afin qu’une forme reste toujours « au premier plan » ?**

Modifiez l’ordre d’insertion/déplacement dans la collection [shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) de la diapositive. Pour des résultats prévisibles, finalisez le z‑order après toutes les autres modifications de la diapositive.

**Puis‑je « verrouiller » une forme pour empêcher les utilisateurs de la modifier dans PowerPoint ?**

Oui. Définissez les [drapeaux de protection au niveau de la forme](/slides/fr/androidjava/applying-protection-to-presentation/) (par ex., verrouillage de la sélection, du déplacement, du redimensionnement, des modifications de texte). Si nécessaire, répliquez les restrictions sur le maître ou la disposition. Notez qu’il s’agit d’une protection au niveau de l’interface, pas d’une fonctionnalité de sécurité ; pour une protection plus forte, combinez‑la avec des restrictions au niveau du fichier comme les [recommandations en lecture seule ou mots de passe](/slides/fr/androidjava/password-protected-presentation/).