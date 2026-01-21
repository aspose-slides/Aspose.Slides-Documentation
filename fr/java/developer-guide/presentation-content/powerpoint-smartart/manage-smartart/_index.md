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
- diagramme d'organisation d'image
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides for Java grâce à des exemples de code clairs qui accélèrent la conception et l'automatisation des diapositives."
---

## **Obtenir le texte d'un objet SmartArt**
La méthode TextFrame a maintenant été ajoutée à l'interface [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) et à la classe [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) respectivement. Cette propriété vous permet d'obtenir tout le texte de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) s'il ne se compose pas uniquement du texte des nœuds. Le code d'exemple suivant vous aidera à obtenir le texte d'un nœud SmartArt.
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
Afin de modifier le type de mise en page de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Modifiez [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) en BasicProcess.
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


## **Vérifier la propriété Visibility d'un objet SmartArt**
Veuillez noter : la méthode [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) renvoie true si ce nœud est un nœud masqué dans le modèle de données. Afin de vérifier la propriété masquée de n'importe quel nœud de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Ajoutez [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Ajoutez un nœud sur le SmartArt.
- Vérifiez la propriété [visibility](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--).
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
    boolean hidden = node.isHidden(); // Renvoie true

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


## **Obtenir ou définir le type de diagramme d'organisation**
Les méthodes [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) et [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) permettent d'obtenir ou de définir le type de diagramme d'organisation associé au nœud actuel. Afin d'obtenir ou de définir le type de diagramme d'organisation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Ajoutez [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
- Obtenez ou [définissez le type de diagramme d'organisation](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Enregistrez la présentation au format PPTX.
Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.
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
Aspose.Slides for Java fournit une API simple pour créer des graphiques PictureOrganization facilement. Pour créer un graphique sur une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
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


## **Obtenir ou définir l'état de SmartArt**
Afin de modifier le type de mise en page de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Ajoutez [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
3. [Obtenez](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) ou [définissez](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) l'état du diagramme SmartArt.
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

**SmartArt prend-il en charge le mirroring/inversion pour les langues RTL ?**  
Oui. La méthode [setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/#setReversed-boolean-) inverse la direction du diagramme (LTR/RTL) si le type SmartArt sélectionné supporte l’inversion.

**Comment puis‑je copier SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**  
Vous pouvez [cloner la forme SmartArt](/slides/fr/java/shape-manipulations/) via la collection de formes ([ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) ou [cloner la diapositive entière](/slides/fr/java/clone-slides/) contenant cette forme. Les deux approches conservent la taille, la position et le style.

**Comment rendre SmartArt en image raster pour l’aperçu ou l’exportation web ?**  
[Rendez la diapositive](/slides/fr/java/convert-powerpoint-to-png/) (ou toute la présentation) en PNG/JPEG via l’API qui convertit les diapositives/présentations en images – SmartArt sera rendu comme partie de la diapositive.

**Comment sélectionner programmatiquement un SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**  
Une pratique courante consiste à utiliser le [texte alternatif](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) (Alt Text) ou un [nom](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getName--) et à rechercher la forme avec cet attribut dans les [formes de la diapositive](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--). Ensuite, vérifiez le type pour confirmer qu’il s’agit d’un [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/). La documentation décrit les techniques typiques pour trouver et travailler avec les formes.