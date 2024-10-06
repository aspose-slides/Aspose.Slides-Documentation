---
title: Manipulations de Formes
type: docs
weight: 40
url: /androidjava/manipulations-de-formes/
---

## **Trouver une Forme dans une Diapositive**
Ce sujet décrira une technique simple pour faciliter la tâche des développeurs à trouver une forme spécifique sur une diapositive sans utiliser son Id interne. Il est important de savoir que les fichiers de présentation PowerPoint n'ont aucun moyen d'identifier les formes sur une diapositive excepté un Id unique interne. Il semble difficile pour les développeurs de trouver une forme en utilisant son Id unique interne. Toutes les formes ajoutées aux diapositives ont un texte alternatif. Nous suggérons aux développeurs d'utiliser le texte alternatif pour trouver une forme spécifique. Vous pouvez utiliser MS PowerPoint pour définir le texte alternatif pour les objets que vous prévoyez de modifier à l'avenir.

Après avoir défini le texte alternatif de toute forme désirée, vous pouvez ensuite ouvrir cette présentation en utilisant Aspose.Slides pour Android via Java et itérer à travers toutes les formes ajoutées à une diapositive. Lors de chaque itération, vous pouvez vérifier le texte alternatif de la forme et la forme avec le texte alternatif correspondant serait celle dont vous avez besoin. Pour démontrer cette technique de manière plus claire, nous avons créé une méthode, [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), qui permet de trouver une forme spécifique dans une diapositive et retourne simplement cette forme.

```java
// Instancier une classe de Présentation qui représente le fichier de présentation
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Texte alternatif de la forme à trouver
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Nom de la forme : " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Implémentation de la méthode pour trouver une forme dans une diapositive en utilisant son texte alternatif
public static IShape findShape(ISlide slide, String alttext)
{
    // Itération à travers toutes les formes à l'intérieur de la diapositive
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

## **Cloner une Forme**
Pour cloner une forme dans une diapositive en utilisant Aspose.Slides pour Android via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Accédez à la collection de formes de la diapositive source.
1. Ajoutez une nouvelle diapositive à la présentation.
1. Clonez les formes de la collection de formes de la diapositive source vers la nouvelle diapositive.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

L'exemple ci-dessous ajoute une forme de groupe à une diapositive.

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

    // Écrire le fichier PPTX sur le disque
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer une Forme**
Aspose.Slides pour Android via Java permet aux développeurs de supprimer n'importe quelle forme. Pour supprimer la forme d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Trouvez la forme avec un AlternativeText spécifique.
1. Supprimez la forme.
1. Enregistrez le fichier sur le disque.

```java
// Créer un objet Presentation
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une autoshape de type rectangle
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "Défini par l'utilisateur";
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

## **Masquer une Forme**
Aspose.Slides pour Android via Java permet aux développeurs de masquer n'importe quelle forme. Pour masquer la forme d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Trouvez la forme avec un AlternativeText spécifique.
1. Masquez la forme.
1. Enregistrez le fichier sur le disque.

```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une autoshape de type rectangle
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "Défini par l'utilisateur";
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

## **Changer l'Ordre des Formes**
Aspose.Slides pour Android via Java permet aux développeurs de réorganiser les formes. La réorganisation des formes spécifie quelle forme est à l'avant ou quelle forme est à l'arrière. Pour réorganiser les formes d'une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez une forme.
1. Ajoutez du texte dans le cadre de texte de la forme.
1. Ajoutez une autre forme avec les mêmes coordonnées.
1. Réorganisez les formes.
1. Enregistrez le fichier sur le disque.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Texte Filigrane Texte Filigrane Texte Filigrane");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir l'ID de Forme Interop**
Aspose.Slides pour Android via Java permet aux développeurs d'obtenir un identifiant unique de forme dans la portée de la diapositive contrairement à la méthode [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--), qui permet d'obtenir un identifiant unique dans la portée de la présentation. La méthode [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) a été ajoutée aux interfaces [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) et à la classe [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) respectivement. La valeur retournée par la méthode [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) correspond à la valeur de l'Id de l'objet Microsoft.Office.Interop.PowerPoint.Shape. Ci-dessous, un exemple de code est donné.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Obtenir l'identifiant unique de forme dans la portée de la diapositive
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir le Texte Alternatif pour une Forme**
Aspose.Slides pour Android via Java permet aux développeurs de définir l'AlternateText de n'importe quelle forme.
Les formes dans une présentation pourraient être distinguées par la méthode [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) ou [Nom de Forme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-).
Les méthodes [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) et [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) peuvent être lues ou définies en utilisant Aspose.Slides ainsi que Microsoft PowerPoint.
En utilisant cette méthode, vous pouvez étiqueter une forme et exécuter différentes opérations comme la suppression d'une forme,
le masquage d'une forme ou la réorganisation des formes sur une diapositive.
Pour définir l'AlternateText d'une forme, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez n'importe quelle forme à la diapositive.
1. Faites quelque chose avec la forme nouvellement ajoutée.
1. Parcourez les formes pour trouver une forme.
1. Définissez le Texte Alternatif.
1. Enregistrez le fichier sur le disque.

```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajouter une autoshape de type rectangle
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("Défini par l'utilisateur");
        }
    }

    // Enregistrer la présentation sur le disque
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accéder aux Formats de Mise en Page pour une Forme**
Aspose.Slides pour Android via Java fournit une API simple pour accéder aux formats de mise en page pour une forme. Cet article démontre comment vous pouvez accéder aux formats de mise en page.

Le code d'exemple ci-dessous est donné.

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

## **Rendre une Forme en tant que SVG**
Désormais, Aspose.Slides pour Android via Java prend en charge le rendu d'une forme en tant que SVG. La méthode [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (et son surcharge) a été ajoutée à la classe [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) et à l'interface [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape). Cette méthode permet de sauvegarder le contenu de la forme sous forme de fichier SVG. L'extrait de code ci-dessous montre comment exporter la forme de la diapositive vers un fichier SVG.

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

## **Alignement des Formes**
Aspose.Slides permet d'aligner les formes soit par rapport aux marges de la diapositive, soit les unes par rapport aux autres. À cet effet, la méthode surchargée [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) a été ajoutée. L'énumération [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) définit les options d'alignement possibles.

**Exemple 1**

Le code source ci-dessous aligne les formes avec les indices 1, 2 et 4 le long du bord supérieur de la diapositive.

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
```

**Exemple 2**

L'exemple ci-dessous montre comment aligner toute la collection de formes par rapport à la toute dernière forme de la collection.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```