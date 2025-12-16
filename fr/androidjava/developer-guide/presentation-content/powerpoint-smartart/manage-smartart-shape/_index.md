---
title: Gérer les graphiques SmartArt dans les présentations sur Android
linktitle: Graphiques SmartArt
type: docs
weight: 20
url: /fr/androidjava/manage-smartart-shape/
keywords:
- Objet SmartArt
- Graphique SmartArt
- Style SmartArt
- Couleur SmartArt
- Créer SmartArt
- Ajouter SmartArt
- Modifier SmartArt
- Changer SmartArt
- Accéder à SmartArt
- Type de mise en page SmartArt
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Automatisez la création, la modification et le style des SmartArt PowerPoint avec Aspose.Slides pour Android, en proposant des exemples de code Java concis et des conseils axés sur la performance."
---

## **Créer une forme SmartArt**
Aspose.Slides for Android via Java a fourni une API permettant de créer des formes SmartArt. Pour créer une forme SmartArt dans une diapositive, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenir la référence d’une diapositive en utilisant son index.
1. [Ajouter une forme SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en définissant son [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Enregistrer la présentation modifiée sous forme de fichier PPTX.
```java
// Instancier la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter une forme Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Enregistrement de la présentation
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure : forme SmartArt ajoutée à la diapositive**|

## **Accéder à une forme SmartArt sur une diapositive**
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de la présentation. Dans l'exemple de code, nous parcourrons chaque forme à l'intérieur de la diapositive et vérifierons s'il s'agit d'une forme [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). Si la forme est de type SmartArt, nous la convertirons en instance [**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt).
```java
// Charger la présentation souhaitée
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Vérifier si la forme est du type SmartArt
        if (shape instanceof ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Accéder à une forme SmartArt avec un type de mise en page particulier**
Le code d'exemple suivant permet d'accéder à la forme [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) avec un LayoutType particulier. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et n'est défini que lors de l'ajout de la forme [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt).

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) et charger la présentation contenant une forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifier si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) et la convertir en SmartArt si c'est le cas.
1. Vérifier la forme SmartArt avec le LayoutType particulier et effectuer les actions nécessaires par la suite.
```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Vérifier si la forme est du type SmartArt
        if (shape instanceof ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Vérifier la disposition SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier le style d'une forme SmartArt**
Dans cet exemple, nous apprendrons à modifier le style rapide d’une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) et charger la présentation contenant une forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifier si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) et la convertir en SmartArt si c'est le cas.
1. Trouver la forme SmartArt avec un style particulier.
1. Définir le nouveau style pour la forme SmartArt.
1. Enregistrer la présentation.
```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifier si la forme est du type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Vérifier le style SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Modifier le style SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Enregistrement de la présentation
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure : forme SmartArt avec style modifié**|

## **Modifier le style de couleur d'une forme SmartArt**
Dans cet exemple, nous apprendrons à modifier le style de couleur d’une forme SmartArt. Le code d'exemple suivant accédera à la forme SmartArt avec un style de couleur particulier et modifiera son style.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) et charger la présentation contenant une forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifier si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) et la convertir en SmartArt si c'est le cas.
1. Trouver la forme SmartArt avec un style de couleur particulier.
1. Définir le nouveau style de couleur pour la forme SmartArt.
1. Enregistrer la présentation.
```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Vérifier le type de couleur SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Modifier le type de couleur SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Enregistrement de la présentation
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure : forme SmartArt avec style de couleur modifié**|

## **FAQ**

**Puis-je animer le SmartArt comme un objet unique ?**

Oui. Le SmartArt est une forme, vous pouvez donc appliquer les [animations standard](/slides/fr/androidjava/powerpoint-animation/) via l'API d'animations (entrées, sorties, mises en emphase, trajectoires de mouvement) comme pour les autres formes.

**Comment puis‑je trouver un SmartArt spécifique sur une diapositive si je ne connais pas son ID interne ?**

Définissez et utilisez le texte alternatif (AltText) et recherchez la forme par cette valeur — c’est la méthode recommandée pour localiser la forme cible.

**Puis‑je grouper le SmartArt avec d’autres formes ?**

Oui. Vous pouvez grouper le SmartArt avec d’autres formes (images, tableaux, etc.) puis [manipuler le groupe](/slides/fr/androidjava/group/).

**Comment obtenir une image d’un SmartArt spécifique (par ex. pour un aperçu ou un rapport) ?**

Exportez une vignette/image de la forme ; la bibliothèque peut [rendre des formes individuelles](/slides/fr/androidjava/create-shape-thumbnails/) vers des fichiers raster (PNG/JPG/TIFF).

**L’apparence du SmartArt sera‑t‑elle préservée lors de la conversion de toute la présentation en PDF ?**

Oui. Le moteur de rendu vise une haute fidélité pour l’[export PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/), avec plusieurs options de qualité et de compatibilité.