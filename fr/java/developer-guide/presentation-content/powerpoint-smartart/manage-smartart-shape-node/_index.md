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
- rendu du nœud
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Gérez les nœuds de forme SmartArt dans PPT et PPTX avec Aspose.Slides for Java. Obtenez des exemples de code clairs et des conseils pour optimiser vos présentations."
---
## **Vue d'ensemble**

Les graphiques SmartArt dans les présentations PowerPoint sont organisés via des nœuds contenant du texte et définissant la structure du diagramme. Aspose.Slides vous permet de travailler avec ces nœuds SmartArt de manière programmatique : ajouter de nouveaux nœuds et nœuds enfants, insérer des nœuds enfants à une position spécifique, accéder aux nœuds existants et lire leur texte, leur niveau et leur position.

Cet article explique comment gérer les nœuds de forme SmartArt. Il montre comment supprimer des nœuds, travailler avec les nœuds enfants par indice ou position, transformer un nœud assistant en nœud normal, ajuster la position, la taille et la rotation des formes de nœuds SmartArt, définir les formats de remplissage des nœuds et générer une image miniature pour un nœud enfant SmartArt.

## **Ajouter un nœud SmartArt**
Aspose.Slides for Java a fourni l’API la plus simple pour gérer les formes SmartArt de la façon la plus aisée. Le code d’exemple suivant vous aidera à ajouter un nœud et un nœud enfant à l’intérieur d’une forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) et chargez la présentation contenant la forme SmartArt.
2. Obtenez la référence de la première diapositive en utilisant son indice.
3. Parcourez chaque forme à l’intérieur de la première diapositive.
4. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) et effectuez un transtypage de la forme sélectionnée vers [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) si c’est du SmartArt.
5. [Ajoutez un nouveau nœud](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) dans la collection [**NodeCollection**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt#getAllNodes--) de la forme SmartArt et définissez le texte dans le TextFrame.
6. Maintenant, [ajoutez](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) un [**nœud enfant**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) dans le nœud SmartArt récemment ajouté et définissez le texte dans le TextFrame.
7. Enregistrez la présentation.

```java
import com.aspose.slides.*;

// Charger la présentation souhaitée
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof SmartArt) 
        {
            // Transtyper la forme en SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Ajouter un nouveau nœud SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Ajouter du texte
            TemNode.getTextFrame().setText("Test");
    
            // Ajouter un nouveau nœud enfant au nœud parent. Il sera ajouté à la fin de la collection
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
Dans l’exemple de code suivant, nous expliquons comment ajouter les nœuds enfants appartenant aux nœuds respectifs d’une forme SmartArt à une position particulière.

1. Créez une instance de la classe Presentation.
2. Obtenez la référence de la première diapositive en utilisant son indice.
3. Ajoutez une forme SmartArt de type [**StackedList**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArtLayoutType#StackedList) dans la diapositive accédée.
4. Accédez au premier nœud de la forme SmartArt ajoutée.
5. Ajoutez maintenant le [**nœud enfant**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pour le [**nœud**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArtNode) sélectionné à la position 2 et définissez son texte.
6. Enregistrez la présentation.

```java
import com.aspose.slides.*;

// Création d'une instance de présentation
Presentation pres = new Presentation();
try {
    // Accéder à la diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter un IShape Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Accéder au nœud SmartArt à l'indice 0
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
Le code d’exemple suivant vous aidera à accéder aux nœuds à l’intérieur d’une forme SmartArt. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et n’est défini que lors de l’ajout de la forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) et chargez la présentation contenant la forme SmartArt.
2. Obtenez la référence de la première diapositive en utilisant son indice.
3. Parcourez chaque forme à l’intérieur de la première diapositive.
4. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) et effectuez un transtypage de la forme sélectionnée vers [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) si c’est du SmartArt.
5. Parcourez tous les [**nœuds**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArt#getAllNodes--) à l’intérieur de la forme SmartArt.
6. Accédez et affichez des informations telles que la position du nœud SmartArt, son niveau et son texte.

```java
import com.aspose.slides.*;

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
            // Transtyper la forme en SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Parcourir tous les nœuds du SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accéder au nœud SmartArt à l'indice i
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

## **Accéder à un nœud enfant SmartArt**
Le code d’exemple suivant vous aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs d’une forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) et chargez la présentation contenant la forme SmartArt.
2. Obtenez la référence de la première diapositive en utilisant son indice.
3. Parcourez chaque forme à l’intérieur de la première diapositive.
4. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) et effectuez un transtypage de la forme sélectionnée vers [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) si c’est du SmartArt.
5. Parcourez tous les [**nœuds**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArt#getAllNodes--) à l’intérieur de la forme SmartArt.
6. Pour chaque [**nœud**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArtNode) de forme SmartArt sélectionné, parcourez tous les [**nœuds enfants**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArtNode#getChildNodes--) à l’intérieur du nœud particulier.
7. Accédez et affichez des informations telles que la position du [**nœud enfant**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) , son niveau et son texte.

```java
import com.aspose.slides.*;

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
            // Transtyper la forme en SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Parcourir tous les nœuds du SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Accéder au nœud SmartArt à l'indice i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Parcourir les nœuds enfants du nœud SmartArt à l'indice i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Accéder au nœud enfant du nœud SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Imprimer les paramètres du nœud enfant SmartArt
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
Dans cet exemple, nous apprendrons à accéder aux nœuds enfants à une position particulière appartenant aux nœuds respectifs d’une forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) .
2. Obtenez la référence de la première diapositive en utilisant son indice.
3. Ajoutez une forme SmartArt de type [**StackedList**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArtLayoutType#StackedList).
4. Accédez à la forme SmartArt ajoutée.
5. Accédez au nœud d’indice 0 de la forme SmartArt accédée.
6. Maintenant, accédez au [**nœud enfant**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) à la position 1 pour le nœud SmartArt accédé en utilisant la méthode **get_Item()**.
7. Accédez et affichez des informations telles que la position du [**nœud enfant**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNode#getChildNodes--) , son niveau et son texte.

```java
import com.aspose.slides.*;

// Instancier la présentation
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter la forme SmartArt dans la première diapositive
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Accéder au nœud SmartArt à l'indice 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Accéder au nœud enfant à la position 1 dans le nœud parent
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Imprimer les paramètres du nœud enfant SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer un nœud SmartArt**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l’intérieur d’une forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) et chargez la présentation contenant la forme SmartArt.
2. Obtenez la référence de la première diapositive en utilisant son indice.
3. Parcourez chaque forme à l’intérieur de la première diapositive.
4. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) et effectuez un transtypage de la forme sélectionnée vers [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) si c’est du SmartArt.
5. Vérifiez si le [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) possède plus de 0 nœud.
6. Sélectionnez le nœud SmartArt à supprimer.
7. Maintenant, supprimez le nœud sélectionné en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
8. Enregistrez la présentation.

```java
import com.aspose.slides.*;

// Charger la présentation souhaitée
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Transtyper la forme en SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accéder au nœud SmartArt à l'indice 0
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

## **Supprimer un nœud SmartArt à une position spécifique**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l’intérieur d’une forme SmartArt à une position particulière.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) et chargez la présentation contenant la forme SmartArt.
2. Obtenez la référence de la première diapositive en utilisant son indice.
3. Parcourez chaque forme à l’intérieur de la première diapositive.
4. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) et effectuez un transtypage de la forme sélectionnée vers [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) si c’est du SmartArt.
5. Sélectionnez le nœud de forme SmartArt d’indice 0.
6. Vérifiez maintenant si le nœud SmartArt sélectionné possède plus de 2 nœuds enfants.
7. Supprimez maintenant le nœud à la **Position 1** en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
8. Enregistrez la présentation.

```java
import com.aspose.slides.*;

// Charger la présentation souhaitée
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof SmartArt) 
        {
            // Transtyper la forme en SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Accéder au nœud SmartArt à l'indice 0
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
Aspose.Slides for Java prend désormais en charge la définition des propriétés [X](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShape#setX-float-) et [Y](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShape#setY-float-) de la [SmartArtShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArtShape). Le fragment de code ci‑dessous montre comment définir la position, la taille et la rotation personnalisées d’une SmartArtShape ; veuillez également noter que l’ajout de nouveaux nœuds entraîne un recalcul des positions et tailles de tous les nœuds. Avec les réglages de position personnalisée, l’utilisateur peut placer les nœuds selon les exigences.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Déplacer la forme SmartArt à une nouvelle position
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
{{% alert color="info" %}} 

Dans cet article, nous examinerons plus en détail les fonctionnalités des formes SmartArt ajoutées aux diapositives de présentation de manière programmatique à l’aide d’Aspose.Slides for Java.

{{% /alert %}} 

Nous utiliserons la forme SmartArt source suivante pour nos investigations dans les différentes sections de cet article.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure : forme SmartArt source dans la diapositive**|

Dans le code d’exemple suivant, nous étudierons comment identifier les **nœuds assistants** dans la collection de nœuds SmartArt et les modifier.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) et chargez la présentation contenant la forme SmartArt.
2. Obtenez la référence de la deuxième diapositive en utilisant son indice.
3. Parcourez chaque forme à l’intérieur de la première diapositive.
4. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) et effectuez un transtypage de la forme sélectionnée vers [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) si c’est du SmartArt.
5. Parcourez tous les nœuds à l’intérieur de la forme SmartArt et vérifiez s’ils sont des [**nœuds assistants**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArtNode#isAssistant--) .
6. Changez le statut du nœud assistant en nœud normal.
7. Enregistrez la présentation.

```java
import com.aspose.slides.*;

// Créer une instance de présentation
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Transtyper la forme en SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Parcourir tous les nœuds de la forme SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Vérifier si le nœud est un nœud Assistant
                if (node.isAssistant()) 
                {
                    // Définir le nœud Assistant à false et le rendre nœud normal
                    node.setAssistant(false);
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
|**Figure : nœuds assistants modifiés dans la forme SmartArt de la diapositive**|

## **Définir le format de remplissage d’un nœud**
Aspose.Slides for Java permet d’ajouter des formes SmartArt personnalisées et de définir leur format de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage à l’aide d’Aspose.Slides for Java.

Veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) .
2. Obtenez la référence d’une diapositive en utilisant son indice.
3. Ajoutez une forme [SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArt) en définissant son [**LayoutType**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) .
4. Définissez le [**FillFormat**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShape#getFillFormat--) pour les nœuds de la forme SmartArt.
5. Enregistrez la présentation modifiée au format PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Générer une vignette d’un nœud enfant SmartArt**
Les développeurs peuvent générer une vignette d’un nœud enfant d’un SmartArt en suivant les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) .
2. [Ajoutez SmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) .
3. Obtenez la référence d’un nœud en utilisant son indice.
4. Récupérez l’image de la vignette.
5. Enregistrez l’image de la vignette dans le format d’image souhaité.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation qui représente le fichier PPTX 
Presentation pres = new Presentation();
try {
    // Ajouter SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Obtenir la référence d'un nœud en utilisant son indice  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Obtenir la vignette
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Enregistrer la vignette
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

### L'animation SmartArt est-elle prise en charge ?

Oui. SmartArt est traité comme une forme ordinaire, vous pouvez donc [appliquer des animations standard](/slides/fr/java/shape-animation/) (entrée, sortie, mise en emphase, trajectoires) et ajuster le minutage. Vous pouvez également animer les formes à l’intérieur des nœuds SmartArt lorsque cela est nécessaire.

### Comment localiser de façon fiable un SmartArt spécifique sur une diapositive si son ID interne est inconnu ?

Attribuez et recherchez par [texte alternatif](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getAlternativeText--) . Définir un AltText distinctif sur le SmartArt vous permet de le trouver programmatiquement sans dépendre des identifiants internes.

### L'apparence du SmartArt sera-t-elle préservée lors de la conversion de la présentation en PDF ?

Oui. Aspose.Slides rend le SmartArt avec une haute fidélité visuelle lors de l’[export PDF](/slides/fr/java/convert-powerpoint-to-pdf/), préservant la mise en page, les couleurs et les effets.

### Puis-je extraire une image de l’ensemble du SmartArt (pour des aperçus ou des rapports) ?

Oui. Vous pouvez rendre une forme SmartArt en [formats raster](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getImage-int-float-float-) ou en [SVG](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) pour une sortie vectorielle évolutive, ce qui convient aux vignettes, aux rapports ou à une utilisation web.