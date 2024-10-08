---
title: Créer ou Gérer un Nœud de Forme SmartArt PowerPoint en Java
linktitle: Gérer le Nœud de Forme SmartArt
type: docs
weight: 30
url: /fr/java/manage-smartart-shape-node/
keywords: smartart powerpoint, nœuds smartart, position smartart, retirer smartart, ajouter nœuds smartart, présentation powerpoint, powerpoint java, api java powerpoint
description: Gérer le nœud smart art et le nœud enfant dans les présentations PowerPoint en Java
---

## **Ajouter un Nœud SmartArt dans la Présentation PowerPoint en utilisant Java**
Aspose.Slides pour Java a fourni la plus simple API pour gérer les formes SmartArt de la manière la plus facile. Le code sample suivant aidera à ajouter un nœud et un nœud enfant à l'intérieur de la forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) et charger la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et faites un cast de la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est SmartArt.
1. [Ajouter un nouveau Nœud](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) dans la forme SmartArt [**NodeCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#getAllNodes--) et définir le texte dans le TextFrame.
1. Maintenant, [Ajouter](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) un [**Nœud Enfant**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) dans le [Nœud SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) nouvellement ajouté et définir le texte dans le TextFrame.
1. Enregistrez la Présentation.

```java
// Charger la présentation souhaitée
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof SmartArt) 
        {
            // Faire un cast de la forme en SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Ajout d'un nouveau nœud SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Ajouter du texte
            TemNode.getTextFrame().setText("Test");
    
            // Ajout d'un nouveau nœud enfant dans le nœud parent. Il sera ajouté à la fin de la collection
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Ajouter du texte
            newNode.getTextFrame().setText("Nouveau Nœud Ajouté");
        }
    }
    
    // Enregistrer la Présentation
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter un Nœud SmartArt à une Position Spécifique**
Dans le code sample suivant, nous expliquons comment ajouter les nœuds enfants appartenant aux nœuds respectifs de la forme SmartArt à une position particulière.

1. Créer une instance de la classe Presentation.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Ajouter une forme [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) dans la diapositive accessible.
1. Accéder au premier nœud dans la forme SmartArt ajoutée.
1. Maintenant, ajoutez le [**Nœud Enfant**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pour le [**Nœud**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) sélectionné à la position 2 et définissez son texte.
1. Enregistrez la Présentation.

```java
// Créer une instance de présentation
Presentation pres = new Presentation();
try {
    // Accéder à la diapositive de présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Accéder au nœud SmartArt à l'index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Ajouter un nouveau nœud enfant à la position 2 dans le nœud parent 
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Ajouter du texte
    chNode.getTextFrame().setText("Texte Exemple Ajouté");

    // Enregistrer la Présentation
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accéder au Nœud SmartArt dans la Présentation PowerPoint en utilisant Java**
Le code sample suivant vous aidera à accéder aux nœuds à l'intérieur de la forme SmartArt. Veuillez noter que vous ne pouvez pas changer le LayoutType du SmartArt car il est en lecture seule et est défini uniquement lorsque la forme SmartArt est ajoutée.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et charger la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et faites un cast de la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est SmartArt.
1. Parcourir tous les [**Nœuds**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) à l'intérieur de la forme SmartArt.
1. Accédez et affichez des informations telles que la position du nœud SmartArt, le niveau et le texte.

```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Faire un cast de la forme en SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Parcourir tous les nœuds à l'intérieur de SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accéder au nœud SmartArt à l'index i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Imprimer les paramètres du nœud SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Accéder au Nœud Enfant SmartArt**
Le code sample suivant vous aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs de la forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et charger la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et faites un cast de la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est SmartArt.
1. Parcourir tous les [**Nœuds**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) à l'intérieur de la forme SmartArt.
1. Pour chaque [**Nœud**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) SmartArt sélectionné, parcourez tous les [**Nœuds Enfants**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#getChildNodes--) à l'intérieur du nœud particulier.
1. Accédez et affichez des informations telles que la position, le niveau et le texte du [**Nœud Enfant**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Instancier la classe Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Faire un cast de la forme en SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Parcourir tous les nœuds à l'intérieur de SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accéder au nœud SmartArt à l'index i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Parcourir les nœuds enfants dans le nœud SmartArt à l'index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Accéder au nœud enfant dans le nœud SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Imprimer les paramètres du nœud enfant SmartArt
                    System.out.print("j = " + j + ", Texte = " + node.getTextFrame().getText() + ",  Niveau = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accéder au Nœud Enfant SmartArt à une Position Spécifique**
Dans cet exemple, nous allons apprendre à accéder aux nœuds enfants à une certaine position appartenant aux nœuds respectifs de la forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Ajouter une forme de type [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList).
1. Accéder à la forme SmartArt ajoutée.
1. Accéder au nœud à l'index 0 pour la forme SmartArt accessible.
1. Maintenant, accédez au [**Nœud Enfant**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) à la position 1 pour le nœud SmartArt accessible en utilisant la méthode **get_Item()**.
1. Accédez et affichez des informations telles que la position, le niveau et le texte du [**Nœud Enfant**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Instancier la présentation
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter la forme SmartArt dans la première diapositive
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Accéder au nœud SmartArt à l'index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Accéder au nœud enfant à la position 1 dans le nœud parent
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Imprimer les paramètres du nœud enfant SmartArt
    System.out.print("Texte = " + chNode.getTextFrame().getText() + ",  Niveau = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer un Nœud SmartArt dans la Présentation PowerPoint en utilisant Java**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et charger la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et faites un cast de la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est SmartArt.
1. Vérifiez si le [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) a plus de 0 nœuds.
1. Sélectionnez le nœud SmartArt à supprimer.
1. Maintenant, supprimez le nœud sélectionné en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
1. Enregistrez la Présentation.

```java
// Charger la présentation souhaitée
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Faire un cast de la forme en SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accéder au nœud SmartArt à l'index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Supprimer le nœud sélectionné
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Enregistrer la Présentation
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer un Nœud SmartArt à une Position Spécifique**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt à une position particulière.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et charger la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et faites un cast de la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est SmartArt.
1. Sélectionnez le nœud de forme SmartArt à l'index 0.
1. Maintenant, vérifiez si le nœud SmartArt sélectionné a plus de 2 nœuds enfants.
1. Maintenant, supprimez le nœud à la **Position 1** en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).
1. Enregistrez la Présentation.

```java
// Charger la présentation souhaitée
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof SmartArt) 
        {
            // Faire un cast de la forme en SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accéder au nœud SmartArt à l'index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Supprimer le nœud enfant à la position 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Enregistrer la Présentation
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la Position Personnalisée pour le Nœud Enfant dans SmartArt**
Maintenant Aspose.Slides pour Java supporte la définition des propriétés [X](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setX-float-) et [Y](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setY-float-) de [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape). Le code snippet ci-dessous montre comment définir la position, la taille et la rotation personnalisées de SmartArtShape, veuillez également noter que l'ajout de nouveaux nœuds entraîne un recalcul des positions et des tailles de tous les nœuds. De plus, avec les paramètres de position personnalisés, l'utilisateur peut définir les nœuds selon ses besoins.

```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Déplacez la forme SmartArt à une nouvelle position
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Changez les largeurs de la forme SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Changez la hauteur de la forme SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Changez la rotation de la forme SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Vérifier le Nœud Assistant**
{{% alert color="primary" %}} 

Dans cet article, nous allons approfondir les fonctionnalités des formes SmartArt ajoutées dans des diapositives de présentation par programmation en utilisant Aspose.Slides pour Java.

{{% /alert %}} 

Nous utiliserons la forme SmartArt source suivante pour notre enquête dans différentes sections de cet article.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure : Forme SmartArt source dans la diapositive**|

Dans le code sample suivant, nous allons enquêter sur la manière d'identifier les **Nœuds Assistant** dans la collection de nœuds SmartArt et d'y apporter des modifications.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et charger la présentation avec la forme SmartArt.
1. Obtenez la référence de la deuxième diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et faites un cast de la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est SmartArt.
1. Parcourir tous les nœuds à l'intérieur de la forme SmartArt et vérifier s'ils sont des [**Nœuds Assistant**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#isAssistant--).
1. Changez le statut du nœud assistant en nœud normal.
1. Enregistrez la Présentation.

```java
// Créer une instance de présentation
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Faire un cast de la forme en SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Parcourir tous les nœuds de la forme SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Vérifiez si le nœud est un nœud assistant
                if (node.isAssistant()) 
                {
                    // Définir le nœud assistant sur false et le rendre un nœud normal
                    node.isAssistant();
                }
            }
        }
    }
    
    // Enregistrer la Présentation
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure : Nœuds Assistant Modifiés dans la forme SmartArt à l'intérieur de la diapositive**|

## **Définir le Format de Remplissage du Nœud**
Aspose.Slides pour Java permet d'ajouter des formes SmartArt personnalisées et de définir leur format de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage en utilisant Aspose.Slides pour Java.

Veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajouter une forme [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) en définissant son [**LayoutType**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Définir le [**Format de Remplissage**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--) pour les nœuds de forme SmartArt.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

```java
// Instancier la présentation
Presentation pres = new Presentation();
try {
    // Accéder à la diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter une forme SmartArt et des nœuds
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Du texte ici");
    
    // Définir la couleur de remplissage du nœud
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Enregistrer la présentation
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Générer une Miniature du Nœud Enfant SmartArt**
Les développeurs peuvent générer une miniature du Nœud enfant d'un SmartArt en suivant les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. [Ajouter SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Obtenez la référence d'un nœud en utilisant son index.
1. Obtenez l'image de la miniature.
1. Enregistrez l'image miniature dans le format d'image souhaité.

```java
// Instancier la classe Presentation qui représente le fichier PPTX 
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Obtenez la référence d'un nœud en utilisant son index  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Obtenez la miniature
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Enregistrez la miniature
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```