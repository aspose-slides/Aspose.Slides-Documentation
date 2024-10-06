---
title: Créer ou gérer un nœud de forme SmartArt PowerPoint en Java
linktitle: Gérer le nœud de forme SmartArt
type: docs
weight: 30
url: /androidjava/manage-smartart-shape-node/
keywords: smartart powerpoint, nœuds smartart, position smartart, supprimer smartart, ajouter nœuds smartart, présentation powerpoint, powerpoint java, api java powerpoint
description: Gérer le nœud smart art et le nœud enfant dans les présentations PowerPoint en Java
---

## **Ajouter un nœud SmartArt dans une présentation PowerPoint en utilisant Java**
Aspose.Slides pour Android via Java a fourni la plus simple API pour gérer les formes SmartArt de la manière la plus facile. Le code exemple suivant aidera à ajouter un nœud et un nœud enfant à l'intérieur de la forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourez chaque forme dans la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) et convertissez la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si c'est un SmartArt.
1. [Ajoutez un nouveau nœud](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) dans la forme SmartArt [**NodeCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) et définissez le texte dans TextFrame.
1. Maintenant, [ajoutez](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) un [**nœud enfant**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) dans le nœud [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) nouvellement ajouté et définissez le texte dans TextFrame.
1. Enregistrez la présentation.

```java
// Charger la présentation souhaitée
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Parcourez chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof SmartArt) 
        {
            // Convertissez la forme en SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Ajouter un nouveau nœud SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Ajouter du texte
            TemNode.getTextFrame().setText("Test");
    
            // Ajouter un nouveau nœud enfant dans le nœud parent. Il sera ajouté à la fin de la collection
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Ajouter du texte
            newNode.getTextFrame().setText("Nouveau nœud ajouté");
        }
    }
    
    // Enregistrer la présentation
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter un nœud SmartArt à une position spécifique**
Dans le code exemple suivant, nous avons expliqué comment ajouter les nœuds enfants appartenant aux nœuds respectifs de la forme SmartArt à une position particulière.

1. Créez une instance de la classe Presentation.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Ajoutez une forme SmartArt de type [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) dans la diapositive accédée.
1. Accédez au premier nœud de la forme SmartArt ajoutée.
1. Maintenant, ajoutez le [**nœud enfant**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) pour le [**nœud**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode) sélectionné à la position 2 et définissez son texte.
1. Enregistrez la présentation.

```java
// Création d'une instance de présentation
Presentation pres = new Presentation();
try {
    // Accédez à la diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoutez Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Accédez au nœud SmartArt à l'index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Ajouter un nouveau nœud enfant à la position 2 dans le nœud parent
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Ajouter du texte
    chNode.getTextFrame().setText("Texte d'exemple ajouté");

    // Enregistrer la présentation
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accéder au nœud SmartArt dans une présentation PowerPoint en utilisant Java**
Le code exemple suivant aidera à accéder aux nœuds à l'intérieur de la forme SmartArt. Veuillez noter que vous ne pouvez pas changer le LayoutType du SmartArt car il est en lecture seule et est défini uniquement lorsque la forme SmartArt est ajoutée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourez chaque forme dans la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) et convertissez la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si c'est un SmartArt.
1. Parcourez tous les [**nœuds**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) à l'intérieur de la forme SmartArt.
1. Accédez et affichez des informations telles que la position du nœud SmartArt, le niveau et le texte.

```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Obtenez la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourez chaque forme dans la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertissez la forme en SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Parcourez tous les nœuds à l'intérieur de SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accédez au nœud SmartArt à l'index i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Impression des paramètres du nœud SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accéder au nœud enfant SmartArt**
Le code exemple suivant aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs de la forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourez chaque forme dans la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) et convertissez la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si c'est un SmartArt.
1. Parcourez tous les [**nœuds**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) à l'intérieur de la forme SmartArt.
1. Pour chaque nœud SmartArt sélectionné [**Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode), parcourez tous les [**nœuds enfants**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) à l'intérieur du nœud particulier.
1. Accédez et affichez des informations telles que la position, le niveau et le texte du [**nœud enfant**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Instancier la classe Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Obtenez la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourez chaque forme dans la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertissez la forme en SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Parcourez tous les nœuds à l'intérieur de SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accédez au nœud SmartArt à l'index i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Parcourez les nœuds enfants dans le nœud SmartArt à l'index i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Accédez au nœud enfant dans le nœud SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Imprimez les paramètres du nœud enfant SmartArt
                    System.out.print("j = " + j + ", Texte = " + node.getTextFrame().getText() + ",  Niveau = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accéder au nœud enfant SmartArt à une position spécifique**
Dans cet exemple, nous allons apprendre à accéder aux nœuds enfants à une position partielle appartenant aux nœuds respectifs de la forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Ajoutez une forme SmartArt de type [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).
1. Accédez à la forme SmartArt ajoutée.
1. Accédez au nœud à l'index 0 pour la forme SmartArt accédée.
1. Maintenant, accédez au [**nœud enfant**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) à la position 1 pour le nœud SmartArt accédé en utilisant la méthode **get_Item()**.
1. Accédez et affichez des informations telles que la position, le niveau et le texte du [**nœud enfant**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Instancier la présentation
Presentation pres = new Presentation();
try {
    // Accédez à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajoutez la forme SmartArt dans la première diapositive
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Accédez au nœud SmartArt à l'index 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Accédez au nœud enfant à la position 1 dans le nœud parent
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Imprimez les paramètres du nœud enfant SmartArt
    System.out.print("Texte = " + chNode.getTextFrame().getText() + ",  Niveau = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer un nœud SmartArt dans une présentation PowerPoint utilisant Java**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourez chaque forme dans la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) et convertissez la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si c'est un SmartArt.
1. Vérifiez si le [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) a plus de 0 nœuds.
1. Sélectionnez le nœud SmartArt à supprimer.
1. Maintenant, supprimez le nœud sélectionné en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
1. Enregistrez la présentation.

```java
// Charger la présentation souhaitée
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Parcourez chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertissez la forme en SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accédez au nœud SmartArt à l'index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Supprimer le nœud sélectionné
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Enregistrez la présentation
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer un nœud SmartArt à une position spécifique**
Dans cet exemple, nous allons apprendre à supprimer les nœuds à l'intérieur de la forme SmartArt à une position particulière.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son index.
1. Parcourez chaque forme dans la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) et convertissez la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si c'est un SmartArt.
1. Sélectionnez le nœud de forme SmartArt à l'index 0.
1. Maintenant, vérifiez si le nœud SmartArt sélectionné a plus de 2 nœuds enfants.
1. Maintenant, supprimez le nœud à **la position 1** en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).
1. Enregistrez la présentation.

```java
// Charger la présentation souhaitée
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Parcourez chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof SmartArt) 
        {
            // Convertissez la forme en SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accédez au nœud SmartArt à l'index 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Supprimer le nœud enfant à la position 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Enregistrez la présentation
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir une position personnalisée pour le nœud enfant dans SmartArt**
Maintenant, Aspose.Slides pour Android via Java prend en charge la définition des propriétés [X](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setX-float-) et [Y](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setY-float-) de [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape). Le snippet de code ci-dessous montre comment définir la position, la taille et la rotation personnalisées pour SmartArtShape. Veuillez noter que l'ajout de nouveaux nœuds entraîne un recalcul des positions et des tailles de tous les nœuds. Également avec les paramètres de position personnalisés, l'utilisateur peut définir les nœuds selon les exigences.

```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Déplacer la forme SmartArt vers une nouvelle position
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Changer les largeurs des formes SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Changer la hauteur des formes SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Changer la rotation des formes SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Vérifiez le nœud Assistant**
{{% alert color="primary" %}} 

Dans cet article, nous examinerons plus en détail les fonctionnalités des formes SmartArt ajoutées dans les diapositives de présentation de façon programmatique en utilisant Aspose.Slides pour Android via Java.

{{% /alert %}} 

Nous utiliserons la forme SmartArt source suivante pour notre investigation dans les différentes sections de cet article.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure : Forme SmartArt source dans la diapositive**|

Dans le code exemple suivant, nous allons examiner comment identifier les **nœuds assistants** dans la collection de nœuds SmartArt et les modifier.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la deuxième diapositive en utilisant son index.
1. Parcourez chaque forme dans la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) et convertissez la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) si c'est un SmartArt.
1. Parcourez tous les nœuds à l'intérieur de la forme SmartArt et vérifiez s'ils sont [**nœuds assistants**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).
1. Changez le statut du nœud assistant en nœud normal.
1. Enregistrez la présentation.

```java
// Création d'une instance de présentation
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Parcourez chaque forma dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifiez si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Convertissez la forme en SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Parcourez tous les nœuds de la forme SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Vérifiez si le nœud est un nœud assistant
                if (node.isAssistant()) 
                {
                    // Définit le nœud assistant sur false et le transforme en nœud normal
                    node.isAssistant();
                }
            }
        }
    }
    
    // Enregistrez la présentation
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure : Nœuds assistants changés dans la forme SmartArt à l'intérieur de la diapositive**|

## **Définir le format de remplissage du nœud**
Aspose.Slides pour Android via Java permet d'ajouter des formes SmartArt personnalisées et de définir leur format de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage en utilisant Aspose.Slides pour Android via Java.

Veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une forme [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) en définissant son [**LayoutType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Définissez le [**FillFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getFillFormat--) pour les nœuds de forme SmartArt.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

```java
// Instancier la présentation
Presentation pres = new Presentation();
try {
    // Accéder à la diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter la forme SmartArt et les nœuds
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Un peu de texte");
    
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

## **Générer une miniature du nœud enfant de SmartArt**
Les développeurs peuvent générer une miniature du nœud enfant d'un SmartArt en suivant les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. [Ajoutez SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Obtenez la référence d'un nœud en utilisant son index.
1. Obtenez l'image miniature.
1. Enregistrez l'image miniature dans n'importe quel format d'image souhaité.

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