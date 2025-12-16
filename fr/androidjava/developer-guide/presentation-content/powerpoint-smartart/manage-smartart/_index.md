---
title: Gérer SmartArt dans les présentations PowerPoint sur Android
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/androidjava/manage-smartart/
keywords:
- SmartArt
- Texte SmartArt
- type de mise en page
- propriété cachée
- organigramme
- organigramme d'image
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Android en utilisant des exemples de code Java clairs qui accélèrent la conception de diapositives et l'automatisation."
---

## **Obtenir le texte d'un objet SmartArt**
La méthode TextFrame a maintenant été ajoutée à l'interface [ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape) et à la classe [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) respectivement. Cette propriété vous permet d'obtenir tout le texte de [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) même s'il ne contient pas seulement le texte des nœuds. Le code d'exemple ci-dessous vous aidera à récupérer le texte d'un nœud SmartArt.
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
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtenir la référence d’une diapositive en utilisant son index.
- Ajouter [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Modifier [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) en BasicProcess.
- Enregistrer la présentation au format PPTX.
Dans l’exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```java
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Modifier le LayoutType en BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Enregistrement de la présentation
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Vérifier la propriété Hidden d'un objet SmartArt**
Veuillez noter : la méthode [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--)) renvoie true si ce nœud est masqué dans le modèle de données. Pour vérifier la propriété cachée de n’importe quel nœud de [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), suivez les étapes ci‑dessous :
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Ajouter [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Ajouter un nœud au SmartArt.
- Vérifier la propriété [isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--) .
- Enregistrer la présentation au format PPTX.
Dans l’exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```java
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Ajouter un nœud au SmartArt 
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
Les méthodes [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) et [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) permettent d’obtenir ou de définir le type d’organigramme associé au nœud actuel. Pour obtenir ou définir le type d’organigramme, suivez les étapes ci‑dessus :
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Ajouter [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
- Obtenir ou [définir le type d’organigramme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Enregistrer la présentation au format PPTX.
Dans l’exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
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


## **Créer un organigramme d’image**
Aspose.Slides for Android via Java fournit une API simple pour créer des graphiques PictureOrganization facilement. Pour créer un graphique sur une diapositive :
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenir la référence d’une diapositive par son index.
3. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (ChartType.PictureOrganizationChart).
4. Enregistrer la présentation modifiée dans un fichier PPTX.
Le code suivant est utilisé pour créer le graphique.
```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtenir ou définir l’état du SmartArt**
Pour modifier le type de mise en page de [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), suivez les étapes ci‑dessus :
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Ajouter [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
3. [Get](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) ou [Set](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) l’état du diagramme SmartArt.
4. Enregistrer la présentation au format PPTX.
Le code suivant est utilisé pour créer le graphique.
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

**SmartArt prend‑il en charge le mirroring / l’inversion pour les langues RTL ?**

Oui. La méthode [setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/#setReversed-boolean-) change le sens du diagramme (LTR/RTL) si le type de SmartArt sélectionné prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/androidjava/shape-manipulations/) via la collection de formes ([ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) ou [cloner la diapositive entière](/slides/fr/androidjava/clone-slides/) contenant cette forme. Les deux approches conservent la taille, la position et le style.

**Comment rendre un SmartArt en image raster pour un aperçu ou une exportation web ?**

[Rendre la diapositive](/slides/fr/androidjava/convert-powerpoint-to-png/) (ou la présentation entière) en PNG/JPEG via l’API qui convertit les diapositives/présentations en images — le SmartArt sera dessiné comme partie de la diapositive.

**Comment sélectionner programmétiquement un SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Une pratique courante consiste à utiliser le [texte alternatif](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--) (Alt Text) ou un [nom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getName--) et à rechercher la forme par cet attribut dans les [formes de la diapositive](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--), puis à vérifier le type pour confirmer qu’il s’agit d’un [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/). La documentation décrit les techniques typiques pour trouver et travailler avec les formes.