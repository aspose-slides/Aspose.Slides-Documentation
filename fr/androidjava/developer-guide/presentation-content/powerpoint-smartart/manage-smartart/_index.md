---
title: Gérer SmartArt dans les présentations PowerPoint sur Android
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/androidjava/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de mise en page
- propriété masquée
- organigramme
- organigramme d'images
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Android à l'aide d'exemples de code Java clairs qui accélèrent la conception de diapositives et l'automatisation."
---

## **Obtenir le texte d'un objet SmartArt**
La méthode TextFrame a maintenant été ajoutée à l'interface [ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape) et à la classe [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) respectivement. Cette propriété vous permet d'obtenir tout le texte de [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) s'il ne contient pas seulement le texte des nœuds. Le code d'exemple suivant vous aidera à obtenir le texte d'un nœud SmartArt.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    ISmartArt smartArt = (ISmartArt)slide.getShapes().get_Item(0);

    ISmartArtNodeCollection smartArtNodes = smartArt.getAllNodes();
    for (ISmartArtNode smartArtNode : smartArtNodes)
    {
        for (ISmartArtShape nodeShape : smartArtNode.getShapes())
        {
            if (nodeShape.getTextFrame() != null)
                System.out.println(nodeShape.getTextFrame().getText());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier le type de mise en page d'un objet SmartArt**
Pour modifier le type de mise en page de [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), suivez les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Modifiez [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) en BasicProcess.
- Enregistrez la présentation au format PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.
```java
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Modifier LayoutType en BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Enregistrement de la présentation
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Vérifier la propriété de visibilité d'un objet SmartArt**
Veuillez noter : la méthode [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden) renvoie true si ce nœud est masqué dans le modèle de données. Pour vérifier la propriété masquée de n'importe quel nœud de [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), suivez les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Ajoutez [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Ajoutez un nœud à SmartArt.
- Vérifiez la propriété de [visibility](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden).
- Enregistrez la présentation au format PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.
```java
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Ajouter un nœud sur SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Vérifier la propriété isHidden
    boolean hidden = node.isHidden(); // Retourne true

    if (hidden)
    {
        // Effectuer des actions ou des notifications
    }
    // Enregistrement de la présentation
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtenir ou définir le type d'organigramme**
Les méthodes [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) et [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) permettent d'obtenir ou de définir le type d'organigramme associé au nœud actuel. Pour obtenir ou définir le type d'organigramme, suivez les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Ajoutez [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
- Obtenez ou [set the organization chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Enregistrez la présentation au format PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.
```java
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Obtenir ou définir le type d'organigramme
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Enregistrement de la présentation
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Créer un organigramme d'images**
Aspose.Slides for Android via Java propose une API simple pour créer des graphiques PictureOrganization de manière facile. Pour créer un graphique sur une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.PictureOrganizationChart).
4. Enregistrez la présentation modifiée au format PPTX.

Le code suivant est utilisé pour créer un graphique.
```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtenir ou définir l'état du SmartArt**
Pour changer le type de mise en page de [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), suivez les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Ajoutez [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
3. [Get](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) ou [Set](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) l'état du diagramme SmartArt.
4. Enregistrez la présentation au format PPTX.

Le code suivant est utilisé pour créer un graphique.
```java
// Instancier la classe Presentation qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // Obtenir ou définir l'état du diagramme SmartArt
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // Enregistrement de la présentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Le SmartArt prend-il en charge le miroir/inversion pour les langues RTL ?**

Oui. La méthode [setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/#setReversed-boolean-) change la direction du diagramme (LTR/RTL) si le type de SmartArt sélectionné prend en charge l'inversion.

**Comment copier le SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [clone the SmartArt shape](/slides/fr/androidjava/shape-manipulations/) via la collection de formes ([ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) ou [clone the entire slide](/slides/fr/androidjava/clone-slides/) contenant cette forme. Les deux approches conservent la taille, la position et le style.

**Comment rendre le SmartArt en image raster pour un aperçu ou une exportation Web ?**

[Render the slide](/slides/fr/androidjava/convert-powerpoint-to-png/) (ou l'intégralité de la présentation) en PNG/JPEG via l'API qui convertit les diapositives/pré­sentations en images — SmartArt sera dessiné comme partie de la diapositive.

**Comment sélectionner programmétiquement un SmartArt spécifique sur une diapositive s'il y en a plusieurs ?**

Une pratique courante consiste à utiliser le [alternative text](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--) (texte alternatif) ou un [name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getName--) et à rechercher la forme par cet attribut dans les [slide shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--), puis à vérifier le type pour confirmer qu’il s’agit d’un [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/). La documentation décrit les techniques typiques pour trouver et travailler avec les formes.