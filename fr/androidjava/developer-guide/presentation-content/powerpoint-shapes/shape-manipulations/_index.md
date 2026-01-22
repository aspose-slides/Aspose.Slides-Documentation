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
- changer l'ordre des formes
- obtenir l'ID de forme Interop
- texte alternatif de forme
- formats de mise en page de forme
- forme en SVG
- convertir forme en SVG
- aligner forme
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à créer, modifier et optimiser des formes dans Aspose.Slides pour Android via Java et à fournir des présentations PowerPoint haute performance."
---

## **Trouver une forme sur une diapositive**
Ce sujet décrit une technique simple pour faciliter aux développeurs la recherche d’une forme spécifique sur une diapositive sans utiliser son Id interne. Il est important de savoir que les fichiers PowerPoint Presentation ne possèdent aucun moyen d’identifier les formes sur une diapositive autre qu’un Id interne unique. Il semble difficile pour les développeurs de trouver une forme en utilisant son Id interne unique. Toutes les formes ajoutees aux diapositives possedent du texte alternatif. Nous suggérons aux developpeurs d’utiliser le texte alternatif pour rechercher une forme specifique. Vous pouvez utiliser MS PowerPoint pour definir le texte alternatif des objets que vous prevoyez de modifier a l’avenir.

Après avoir defini le texte alternatif de la forme souhaitee, vous pouvez ouvrir cette presentation avec Aspose.Slides for Android via Java et parcourir toutes les formes ajoutees a une diapositive. A chaque iteration, vous pouvez verifier le texte alternatif de la forme et la forme dont le texte alternatif correspond sera la forme requise. Pour illustrer cette technique de maniere plus claire, nous avons cree une methode, [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) qui permet de trouver une forme specifique dans une diapositive et renvoie simplement cette forme.
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
    // Parcourir toutes les formes à l'intérieur de la diapositive
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Si le texte alternatif de la diapositive correspond à celui requis alors
        // Retourner la forme
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **Cloner une forme**
Pour cloner une forme sur une diapositive en utilisant Aspose.Slides for Android via Java:
1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenir la reference d’une diapositive en utilisant son index.
1. Acceder à la collection de formes de la diapositive source.
1. Ajouter une nouvelle diapositive à la presentation.
1. Cloner les formes de la collection de formes de la diapositive source vers la nouvelle diapositive.
1. Enregistrer la presentation modifiee au format PPTX.
L’exemple ci-dessous ajoute une forme groupee a une diapositive.
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
Aspose.Slides for Android via Java permet aux developpeurs de supprimer n’importe quelle forme. Pour supprimer la forme d’une diapositive, veuillez suivre les etapes ci-dessous:
1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceder à la première diapositive.
1. Trouver la forme avec un AlternativeText specifique.
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
Aspose.Slides for Android via Java permet aux developpeurs de masquer n’importe quelle forme. Pour masquer la forme d’une diapositive, veuillez suivre les etapes ci-dessous:
1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceder à la première diapositive.
1. Trouver la forme avec un AlternativeText specifique.
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
Aspose.Slides for Android via Java permet aux developpeurs de reorganiser les formes. Reorganiser les formes indique quelle forme est au premier plan ou a l’arriere-plan. Pour reorganiser les formes d’une diapositive, veuillez suivre les etapes ci-dessous:
1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceder à la première diapositive.
1. Ajouter une forme.
1. Ajouter du texte dans le cadre de texte de la forme.
1. Ajouter une autre forme aux memes coordonnees.
1. Reorganiser les formes.
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
Aspose.Slides for Android via Java permet aux developpeurs d’obtenir un identifiant de forme unique au niveau de la diapositive, contrairement à la methode [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--) qui permet d’obtenir un identifiant unique au niveau de la presentation. La methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) a ete ajoutee aux interfaces [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) et a la classe [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape). La valeur renvoye par la methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) correspond a la valeur de l’Id de l’objet Microsoft.Office.Interop.PowerPoint.Shape. Vous trouverez ci-dessous un exemple de code.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Obtention de l'identifiant de forme unique dans la portée de la diapositive
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir le texte alternatif pour une forme**
Aspose.Slides for Android via Java permet aux developpeurs de definir l’AlternateText de n’importe quelle forme. Les formes d’une presentation peuvent etre distinguees grace a la methode [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) ou [Shape Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-). Les methodes [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) et [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) peuvent etre lues ou definies a l’aide d’Aspose.Slides ainsi que de Microsoft PowerPoint. En utilisant cette methode, vous pouvez marquer une forme et effectuer différentes operations telles que la suppression d’une forme, le masquage d’une forme ou la reorganisation des formes sur une diapositive. Pour definir l’AlternateText d’une forme, veuillez suivre les etapes ci-dessous:
1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceder à la première diapositive.
1. Ajouter n’importe quelle forme à la diapositive.
1. Effectuer des operations avec la forme ajoutee.
1. Parcourir les formes pour trouver une forme.
1. Definir l’AlternativeText.
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


## **Acceder aux formats de mise en page d’une forme**
Aspose.Slides for Android via Java fournit une API simple pour acceder aux formats de mise en page d’une forme. Cet article montre comment acceder aux formats de mise en page.
Le code d’exemple ci-dessous est fourni.
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
Aspose.Slides for Android via Java prend desormais en charge le rendu d’une forme au format svg. La methode [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (et ses surcharges) a ete ajoutee à la classe [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) et à l’interface [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape). Cette methode permet d’enregistrer le contenu de la forme dans un fichier SVG. L’extrait de code ci-dessous montre comment exporter la forme d’une diapositive vers un fichier SVG.
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
Aspose.Slides permet d’aligner les formes soit par rapport aux marges de la diapositive, soit par rapport les unes aux autres. A cet effet, la methode surchargee [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) a ete ajoutee. L’enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) definit les options d’alignement possibles.

**Exemple 1**
Le code source ci-dessous aligne les formes aux indices 1,2 et 4 le long de la bordure superieure de la diapositive.
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


**Exemple 2**
L’exemple ci-dessous montre comment aligner l’ensemble de la collection de formes par rapport a la forme la plus basse de la collection.
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **Proprietes de retournement**
Dans Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) permet de controler le retournement horizontal et vertical des formes via ses proprietes `flipH` et `flipV`. Les deux proprietes sont de type `byte`, avec la valeur `1` indiquant un retournement, `0` aucun retournement, ou `-1` pour le comportement par defaut. Ces valeurs sont accessibles depuis le [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) d’une forme.

Pour modifier les parametres de retournement, une nouvelle instance de [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) est construite avec la position et la taille actuelles de la forme, les valeurs souhaitees pour `flipH` et `flipV`, ainsi que l’angle de rotation. L’attribution de cette instance au [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) de la forme et l’enregistrement de la presentation appliquent les transformations de miroir et les enregistrent dans le fichier de sortie.

Supposons que nous ayons un fichier sample.pptx dans lequel la premiere diapositive contient une seule forme avec les parametres de retournement par defaut, comme indique ci-dessous.
![La forme a retourner](shape_to_be_flipped.png)

L’exemple de code suivant recupere les proprietes de retournement actuelles de la forme et la retourne a la fois horizontalement et verticalement.
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


![La forme retourne](flipped_shape.png)

## **FAQ**

**Puis-je combiner des formes (union/intersection/soustraction) sur une diapositive comme dans un editeur de bureau ?**
Il n’existe pas d’API d’operation booleenne integree. Vous pouvez l’approximer en construisant vous-meme le contour souhaite -- par exemple, calculer la geometrie resultante (via [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)) et creer une nouvelle forme avec ce contour, en retirant eventuellement les formes d’origine.

**Comment controler l’ordre d’empilement (z-order) afin qu’une forme reste toujours "au premier plan" ?**
Modifiez l’ordre d’insertion/deplacement au sein de la collection [shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) de la diapositive. Pour des resultats previsibles, finalisez le z-order apres toutes les autres modifications de la diapositive.

**Puis-je "verrouiller" une forme pour empêcher les utilisateurs de la modifier dans PowerPoint ?**
Oui. Definissez les indicateurs de protection au niveau de la forme (par ex., verrouiller la selection, le deplacement, le redimensionnement, les modifications de texte). Si necessaire, reproduisez les restrictions sur le masque ou la mise en page. Notez qu’il s’agit d’une protection au niveau de l’interface, pas d’une fonction de securite ; pour une protection plus forte, combinez-la avec des restrictions au niveau du fichier telles que les [recommendations en lecture seule ou les mots de passe](/slides/fr/androidjava/password-protected-presentation/).