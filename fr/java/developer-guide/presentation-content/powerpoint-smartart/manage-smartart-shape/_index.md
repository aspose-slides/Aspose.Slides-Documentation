---
title: Gérer les graphiques SmartArt dans les présentations avec Java
linktitle: Graphiques SmartArt
type: docs
weight: 20
url: /fr/java/manage-smartart-shape/
keywords:
- Objet SmartArt
- Graphique SmartArt
- Style SmartArt
- Couleur SmartArt
- créer SmartArt
- ajouter SmartArt
- modifier SmartArt
- changer SmartArt
- accéder SmartArt
- Type de mise en page SmartArt
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Automatisez la création, la modification et le style des SmartArt PowerPoint en Java avec Aspose.Slides, en proposant des exemples de code concis et des conseils axés sur les performances."
---

## **Créer une forme SmartArt**
Aspose.Slides for Java a fourni une API pour créer des formes SmartArt. Pour créer une forme SmartArt dans une diapositive, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenir la référence d’une diapositive en utilisant son Index.
3. Ajouter une forme SmartArt en définissant son LayoutType.
4. Enregistrer la présentation modifiée sous forme de fichier PPTX.
```java
// Instancier la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter une forme SmartArt
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Enregistrer la présentation
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: Forme SmartArt ajoutée à la diapositive**|

## **Accéder à une forme SmartArt sur une diapositive**
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de la présentation. Dans l’exemple, nous parcourrons chaque forme à l’intérieur de la diapositive et vérifierons s’il s’agit d’une forme [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Si la forme est de type SmartArt, nous la convertirons en instance [**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).
```java
// Charger la présentation souhaitée
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt)
        {
            // Convertir le type de la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Accéder à une forme SmartArt avec un type de mise en page particulier**
Le code d’exemple suivant vous aidera à accéder à la forme [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) avec un LayoutType particulier. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et n’est défini que lors de l’ajout de la forme [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) et charger la présentation contenant une forme SmartArt.
2. Obtenir la référence de la première diapositive en utilisant son Index.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) et la convertir en SmartArt si c’est le cas.
5. Vérifier la forme SmartArt avec le LayoutType particulier et effectuer les actions requises par la suite.
```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt)
        {
            // Caster la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Vérifier le layout SmartArt
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


## **Modifier le style d’une forme SmartArt**
Dans cet exemple, nous apprendrons à modifier le style rapide d’une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) et charger la présentation contenant une forme SmartArt.
2. Obtenir la référence de la première diapositive en utilisant son Index.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) et la convertir en SmartArt si c’est le cas.
5. Trouver la forme SmartArt avec le style particulier.
6. Définir le nouveau style pour la forme SmartArt.
7. Enregistrer la présentation.
```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Caster la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Vérifier le style SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Modifier le style SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Enregistrer la présentation
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: Forme SmartArt avec style modifié**|

## **Modifier le style de couleur d’une forme SmartArt**
Dans cet exemple, nous apprendrons à modifier le style de couleur d’une forme SmartArt. Le code d’exemple suivant accèdera à la forme SmartArt avec un style de couleur particulier et changera son style.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) et charger la présentation contenant une forme SmartArt.
2. Obtenir la référence de la première diapositive en utilisant son Index.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) et la convertir en SmartArt si c’est le cas.
5. Trouver la forme SmartArt avec le style de couleur particulier.
6. Définir le nouveau style de couleur pour la forme SmartArt.
7. Enregistrer la présentation.
```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme de la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Caster la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Vérifier le type de couleur SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Modifier le type de couleur SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Enregistrer la présentation
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: Forme SmartArt avec style de couleur modifié**|

## **FAQ**

**Puis‑je animer SmartArt comme un seul objet ?**

Oui. SmartArt est une forme, vous pouvez donc appliquer les [standard animations](/slides/fr/java/powerpoint-animation/) via l’API d’animations (entrée, sortie, mise en emphase, trajectoires) comme pour les autres formes.

**Comment puis‑je trouver un SmartArt spécifique sur une diapositive si je ne connais pas son ID interne ?**

Définissez et utilisez le texte alternatif (AltText) et recherchez la forme par cette valeur — c’est la méthode recommandée pour localiser la forme cible.

**Puis‑je regrouper SmartArt avec d’autres formes ?**

Oui. Vous pouvez regrouper SmartArt avec d’autres formes (images, tableaux, etc.) puis [manipulate the group](/slides/fr/java/group/).

**Comment obtenir une image d’un SmartArt spécifique (par exemple, pour un aperçu ou un rapport) ?**

Exportez une vignette/image de la forme ; la bibliothèque peut [render individual shapes](/slides/fr/java/create-shape-thumbnails/) vers des fichiers raster (PNG/JPG/TIFF).

**L’apparence du SmartArt sera‑t‑elle conservée lors de la conversion de la présentation entière en PDF ?**

Oui. Le moteur de rendu vise une haute fidélité pour l’[PDF export](/slides/fr/java/convert-powerpoint-to-pdf/), avec une gamme d’options de qualité et de compatibilité.