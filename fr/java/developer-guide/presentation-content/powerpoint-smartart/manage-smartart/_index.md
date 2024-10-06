---
title: Gérer SmartArt
type: docs
weight: 10
url: /java/manage-smartart/
---

## **Obtenir du texte à partir de SmartArt**
Maintenant, la méthode TextFrame a été ajoutée à l'interface [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) et à la classe [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) respectivement. Cette propriété vous permet d'obtenir tout le texte de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) s'il ne contient pas uniquement du texte de nœuds. Le code d'exemple suivant vous aidera à obtenir le texte d'un nœud SmartArt.

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

## **Changer le type de mise en page de SmartArt**
Pour changer le type de mise en page de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Changer le [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) en BasicProcess.
- Écrire la présentation sous forme de fichier PPTX.
  Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.

```java
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Changer LayoutType en BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Sauvegarder la présentation
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vérifier la propriété cachée de SmartArt**
Veuillez noter : la méthode [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--) retourne vrai si ce nœud est un nœud caché dans le modèle de données. Pour vérifier la propriété cachée de n'importe quel nœud de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Ajouter [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Ajouter un nœud sur SmartArt.
- Vérifier la propriété [isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--).
- Écrire la présentation sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.

```java
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Ajouter un nœud sur SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Vérifier la propriété isHidden
    boolean hidden = node.isHidden(); // Retourne vrai

    if (hidden)
    {
        // Faire quelques actions ou notifications
    }
    // Sauvegarder la présentation
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir ou définir le type de graphique organisationnel**
Les méthodes [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) permettent d'obtenir ou de définir le type de graphique organisationnel associé au nœud actuel. Pour obtenir ou définir le type de graphique organisationnel. Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Ajouter [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
- Obtenir ou [définir le type de graphique organisationnel](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Écrire la présentation sous forme de fichier PPTX.
  Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.

```java
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Obtenir ou définir le type de graphique organisationnel
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Sauvegarder la présentation
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Créer un graphique organisationnel d'images**
Aspose.Slides pour Java fournit une API simple pour créer des graphiques et des graphiques organisationnels d'images de manière simple. Pour créer un graphique sur une diapositive :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenir la référence d'une diapositive par son index.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (ChartType.PictureOrganizationChart).
1. Écrire la présentation modifiée dans un fichier PPTX.

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
Pour changer le type de mise en page de [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Ajouter [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
1. [Obtenir](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) ou [définir](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) l'état du diagramme SmartArt.
1. Écrire la présentation sous forme de fichier PPTX.

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
    
    // Sauvegarder la présentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```