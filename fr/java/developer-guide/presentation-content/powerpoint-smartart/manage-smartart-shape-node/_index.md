---
title: Gérer les nœuds de forme SmartArt dans les présentations avec Java
linktitle: Nœud de forme SmartArt
type: docs
weight: 30
url: /fr/java/manage-smartart-shape-node/
keywords:
- nœud SmartArt
- nœud enfant
- ajouter un nœud
- position du nœud
- accéder au nœud
- supprimer le nœud
- position personnalisée
- nœud assistant
- format de remplissage
- rendre le nœud
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Gérez les nœuds de forme SmartArt dans les fichiers PPT et PPTX avec Aspose.Slides pour Java. Obtenez des exemples de code clairs et des conseils pour optimiser vos présentations."
---

## **Ajouter un nœud SmartArt**
Aspose.Slides for Java a fourni l'API la plus simple pour gérer les formes SmartArt de la manière la plus facile. Le code d'exemple suivant vous aidera à ajouter un nœud et un nœud enfant à l'intérieur d'une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) et charger la présentation contenant une forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifier si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et la convertir en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est le cas.
1. [Ajouter un nouveau nœud](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) dans la forme SmartArt [**NodeCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#getAllNodes--) et définir le texte dans le TextFrame.
1. Maintenant, [Ajouter](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) un [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) au nœud [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) récemment ajouté et définir le texte dans le TextFrame.
1. Enregistrer la présentation.
```java
// Charger la présentation souhaitée
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof SmartArt) 
        {
            // Convertir la forme en SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Ajouter un nouveau nœud SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Ajouter du texte
            TemNode.getTextFrame().setText("Test");
    
            // Ajouter un nouveau nœud enfant dans le nœud parent. Il sera ajouté à la fin de la collection
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Ajouter du texte
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Enregistrer la présentation
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ajouter un nœud SmartArt à une position spécifique**
Dans le code d'exemple suivant, nous expliquons comment ajouter les nœuds enfants appartenant aux nœuds respectifs d'une forme SmartArt à une position particulière.

1. Créer une instance de la classe Presentation.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Ajouter une forme [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) dans la diapositive accédée.
1. Accéder au premier nœud de la forme SmartArt ajoutée.
1. Maintenant, ajouter le [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pour le [**Node**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) sélectionné à la position 2 et définir son texte.
1. Enregistrer la présentation.
```java
// Créer une instance de présentation
Presentation pres = new Presentation();
try {
    // Accéder à la diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter une IShape Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Accéder au nœud SmartArt à l'index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Ajouter un nouveau nœud enfant à la position 2 dans le nœud parent
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Ajouter du texte
    chNode.getTextFrame().setText("Sample Text Added");

    // Enregistrer la présentation
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Accéder à un nœud SmartArt**
Le code d'exemple suivant vous aidera à accéder aux nœuds à l'intérieur d'une forme SmartArt. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et est défini uniquement lors de l'ajout de la forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et charger la présentation contenant une forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifier si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et la convertir en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est le cas.
1. Parcourir tous les [**Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) à l'intérieur de la forme SmartArt.
1. Accéder et afficher des informations telles que la position du nœud SmartArt, le niveau et le texte.
```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forme en SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Parcourir tous les nœuds à l'intérieur du SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accéder au nœud SmartArt à l'index i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Afficher les paramètres du nœud SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Accéder à un nœud enfant SmartArt**
Le code d'exemple suivant vous aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs d'une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et charger la présentation contenant une forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifier si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et la convertir en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est le cas.
1. Parcourir tous les [**Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) à l'intérieur de la forme SmartArt.
1. Pour chaque [**Node**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) sélectionné, parcourir tous les [**Child Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#getChildNodes--) à l'intérieur du nœud particulier.
1. Accéder et afficher des informations telles que la position du [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) , le niveau et le texte.
```java
// Instancier la classe Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forme en SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Parcourir tous les nœuds à l'intérieur du SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accéder au nœud SmartArt à l'index i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Parcourir les nœuds enfants dans le nœud SmartArt à l'index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Accéder au nœud enfant dans le nœud SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Afficher les paramètres du nœud enfant SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Accéder à un nœud enfant SmartArt à une position spécifique**
Dans cet exemple, nous apprendrons à accéder aux nœuds enfants à une position particulière appartenant aux nœuds respectifs d'une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Ajouter une forme SmartArt de type [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList).
1. Accéder à la forme SmartArt ajoutée.
1. Accéder au nœud d'index 0 de la forme SmartArt accédée.
1. Maintenant, accéder au [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) à la position 1 du nœud SmartArt accédé en utilisant la méthode **get_Item()**.
1. Accéder et afficher des informations telles que la position du [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) , le niveau et le texte.
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
    
    // Afficher les paramètres du nœud enfant SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Supprimer un nœud SmartArt**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l'intérieur d'une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et charger la présentation contenant une forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifier si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et la convertir en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est le cas.
1. Vérifier si le [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) possède plus de 0 nœud.
1. Sélectionner le nœud SmartArt à supprimer.
1. Maintenant, supprimer le nœud sélectionné en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
1. Enregistrer la présentation.
```java
// Charger la présentation souhaitée
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forme en SmartArt
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
    
    // Enregistrer la présentation
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Supprimer un nœud SmartArt d'une position spécifique**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l'intérieur d'une forme SmartArt à une position particulière.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et charger la présentation contenant une forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifier si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et la convertir en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est le cas.
1. Sélectionner le nœud de forme SmartArt à l'index 0.
1. Maintenant, vérifier si le nœud SmartArt sélectionné possède plus de 2 nœuds enfants.
1. Maintenant, supprimer le nœud à la **Position 1** en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).
1. Enregistrer la présentation.
```java
// Charger la présentation souhaitée
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof SmartArt) 
        {
            // Convertir la forme en SmartArt
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
    
    // Enregistrer la présentation
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir une position personnalisée pour un nœud enfant dans un objet SmartArt**
Aspose.Slides for Java prend désormais en charge la définition des propriétés [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setX-float-) et [Y](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setY-float-). Le fragment de code ci‑dessous montre comment définir la position, la taille et la rotation personnalisées d'une SmartArtShape ; veuillez également noter que l'ajout de nouveaux nœuds entraîne un recalcul des positions et des tailles de tous les nœuds. Avec les réglages de position personnalisée, l'utilisateur peut positionner les nœuds selon les besoins.
```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Déplacer la forme SmartArt vers une nouvelle position
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Modifier les largeurs de la forme SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Modifier la hauteur de la forme SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Modifier la rotation de la forme SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```


## **Vérifier un nœud assistant**
{{% alert color="primary" %}} 

Dans cet article, nous examinerons davantage les fonctionnalités des formes SmartArt ajoutées aux diapositives de présentation de façon programmatique à l'aide d'Aspose.Slides for Java.

{{% /alert %}} 

Nous utiliserons la forme SmartArt source suivante pour nos investigations dans les différentes sections de cet article.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure : Forme SmartArt source dans la diapositive**|

Dans le code d'exemple suivant, nous étudierons comment identifier les **Assistant Nodes** dans la collection de nœuds SmartArt et les modifier.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et charger la présentation contenant une forme SmartArt.
1. Obtenir la référence de la deuxième diapositive en utilisant son index.
1. Parcourir chaque forme à l'intérieur de la première diapositive.
1. Vérifier si la forme est de type [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) et la convertir en [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) si c'est le cas.
1. Parcourir tous les nœuds à l'intérieur de la forme SmartArt et vérifier s'ils sont des [**Assistant Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#isAssistant--).
1. Modifier le statut du nœud Assistant en nœud normal.
1. Enregistrer la présentation.
```java
// Créer une instance de présentation
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertir la forme en SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Parcourir tous les nœuds de la forme SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Vérifier si le nœud est un nœud Assistant
                if (node.isAssistant()) 
                {
                    // Définir le nœud Assistant à false et le transformer en nœud normal
                    node.isAssistant();
                }
            }
        }
    }
    
    // Enregistrer la présentation
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure : Nœuds assistants modifiés dans la forme SmartArt de la diapositive**|

## **Définir le format de remplissage d'un nœud**
Aspose.Slides for Java permet d'ajouter des formes SmartArt personnalisées et de définir leur format de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage à l'aide d'Aspose.Slides for Java.

Veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Obtenir la référence d'une diapositive en utilisant son index.
1. Ajouter une forme [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) en définissant son [**LayoutType**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Définir le [**FillFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--) pour les nœuds de la forme SmartArt.
1. Enregistrer la présentation modifiée au format PPTX.
```java
// Instancier la présentation
Presentation pres = new Presentation();
try {
    // Accéder à la diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter la forme SmartArt et les nœuds
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
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


## **Générer une miniature d'un nœud enfant SmartArt**
Les développeurs peuvent générer une miniature d'un nœud enfant d'un SmartArt en suivant les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. [Ajouter SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Obtenir la référence d'un nœud en utilisant son index.
1. Récupérer l'image miniature.
1. Enregistrer l'image miniature dans le format d'image souhaité.
```java
// Instancier la classe Presentation qui représente le fichier PPTX
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Obtenir la référence d'un nœud en utilisant son index  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Obtenir la miniature
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Enregistrer la miniature
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**L'animation SmartArt est‑elle prise en charge ?**

Oui. Le SmartArt est traité comme une forme ordinaire, vous pouvez donc [appliquer des animations standard](/slides/fr/java/shape-animation/) (entrée, sortie, accentuation, trajectoires) et ajuster le timing. Vous pouvez également animer les formes à l'intérieur des nœuds SmartArt si nécessaire.

**Comment localiser de façon fiable un SmartArt spécifique sur une diapositive si son ID interne est inconnu ?**

Attribuez et recherchez par le [texte alternatif](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--). Définir un AltText distinctif sur le SmartArt permet de le retrouver programmatiquement sans dépendre d'identifiants internes.

**L'apparence du SmartArt sera‑t‑elle préservée lors de la conversion de la présentation en PDF ?**

Oui. Aspose.Slides rend le SmartArt avec une haute fidélité visuelle lors de l'[exportation PDF](/slides/fr/java/convert-powerpoint-to-pdf/), en conservant la disposition, les couleurs et les effets.

**Puis‑je extraire une image de l'intégralité du SmartArt (pour des aperçus ou des rapports) ?**

Oui. Vous pouvez rendre une forme SmartArt en [formats raster](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) ou en [SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) pour une sortie vectorielle évolutive, adaptée aux miniatures, rapports ou utilisations web.