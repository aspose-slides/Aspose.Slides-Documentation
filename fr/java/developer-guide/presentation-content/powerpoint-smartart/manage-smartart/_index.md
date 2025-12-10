---
title: Gérer SmartArt dans les présentations PowerPoint avec Java
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/java/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de mise en page
- propriété masquée
- organigramme
- organigramme d'image
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Java en utilisant des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---

## **Obtenir le texte d'un objet SmartArt**
La méthode TextFrame a maintenant été ajoutée à l'interface [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) et à la classe [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape). Cette propriété vous permet d'obtenir tout le texte de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) s'il ne contient pas seulement le texte des nœuds. Le code d'exemple suivant vous aidera à obtenir le texte d'un nœud SmartArt.
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
Afin de modifier le type de mise en page de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Suivez les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenez la référence d’une diapositive en utilisant son Index.
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Modifiez le [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) en BasicProcess.
- Enregistrez la présentation au format PPTX.
Dans l’exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.
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


## **Vérifier la propriété Hidden d'un objet SmartArt**
Veuillez noter : la méthode [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--)) renvoie true si ce nœud est masqué dans le modèle de données. Afin de vérifier la propriété hidden de tout nœud de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Suivez les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Ajoutez un nœud au SmartArt.
- Vérifiez la propriété [isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--).
- Enregistrez la présentation au format PPTX.
Dans l’exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.
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
        // Faire certaines actions ou notifications...
    }
    // Enregistrement de la présentation
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtenir ou définir le type de diagramme d'organisation**
Les méthodes [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) et [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) permettent d’obtenir ou de définir le type de diagramme d’organisation associé au nœud actuel. Afin d’obtenir ou de définir le type de diagramme d’organisation, suivez les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
- Obtenez ou [définissez le type de diagramme d'organisation](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Enregistrez la présentation au format PPTX.
Dans l’exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.
```java
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Obtenir ou définir le type de diagramme d'organisation
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Enregistrement de la présentation
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Créer un diagramme d'organisation d'image**
Aspose.Slides for Java fournit une API simple pour créer des diagrammes d'organisation d'image de manière facile. Pour créer un diagramme sur une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence d’une diapositive par son index.
1. Ajoutez un diagramme avec des données par défaut ainsi que le type souhaité (ChartType.PictureOrganizationChart).
1. Enregistrez la présentation modifiée au format PPTX.
Le code suivant est utilisé pour créer un diagramme.
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
Afin de modifier le type de mise en page de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Suivez les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Ajoutez un [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
1. [Obtenez](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) ou [définissez](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) l’état du diagramme SmartArt.
1. Enregistrez la présentation au format PPTX.
Le code suivant est utilisé pour créer un diagramme.
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

**Le SmartArt prend‑il en charge le reflet/inversion pour les langues RTL ?**

Oui. La méthode [setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/#setReversed-boolean-) bascule la direction du diagramme (LTR/RTL) si le type de SmartArt sélectionné prend en charge l’inversion.

**Comment copier le SmartArt sur la même diapositive ou dans une autre présentation tout en conservant la mise en forme ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/java/shape-manipulations/) via la collection de formes ([ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) ou [cloner la diapositive entière](/slides/fr/java/clone-slides/) contenant cette forme. Les deux approches conservent la taille, la position et le style.

**Comment rendre le SmartArt en image raster pour un aperçu ou une exportation web ?**

[Rendez la diapositive](/slides/fr/java/convert-powerpoint-to-png/) (ou la présentation entière) en PNG/JPEG via l’API qui convertit les diapositives/présentations en images — SmartArt sera rendu comme partie de la diapositive.

**Comment sélectionner programmatiquement un SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Une pratique courante consiste à utiliser le [texte alternatif](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) (Alt Text) ou un [nom](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getName--) et à rechercher la forme par cet attribut dans les [formes de la diapositive](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--), puis à vérifier le type pour confirmer qu’il s’agit d’un [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/). La documentation décrit les techniques typiques pour trouver et travailler avec les formes.