---
title: Gérer les nœuds de forme SmartArt dans les présentations sur Android
linktitle: Nœud de forme SmartArt
type: docs
weight: 30
url: /fr/androidjava/manage-smartart-shape-node/
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
- Android
- Java
- Aspose.Slides
description: "Gérez les nœuds de forme SmartArt dans les fichiers PPT et PPTX avec Aspose.Slides pour Android. Obtenez des exemples de code Java clairs et des conseils pour optimiser vos présentations."
---
## **Vue d'ensemble**

Les graphiques SmartArt dans les présentations PowerPoint sont organisés à travers des nœuds contenant du texte et définissant la structure du diagramme. Aspose.Slides vous permet de travailler avec ces nœuds SmartArt de façon programmatique : ajouter de nouveaux nœuds et nœuds enfants, insérer des nœuds enfants à une position spécifique, accéder aux nœuds existants et lire leur texte, niveau et position.

Cet article explique comment gérer les nœuds de forme SmartArt. Il montre comment supprimer des nœuds, travailler avec les nœuds enfants par indice ou position, transformer un nœud assistant en nœud normal, ajuster la position, la taille et la rotation des formes de nœuds SmartArt, définir les formats de remplissage des nœuds et générer une image miniature pour un nœud SmartArt.

## **Ajouter un nœud SmartArt**
Aspose.Slides for Android via Java propose l’API la plus simple pour gérer les formes SmartArt de la manière la plus facile. Le code d’exemple suivant vous aidera à ajouter un nœud et un nœud enfant à l’intérieur d’une forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation) et chargez la présentation contenant la forme SmartArt.  
2. Obtenez la référence de la première diapositive en utilisant son index.  
3. Parcourez chaque forme de la première diapositive.  
4. Vérifiez si la forme est du type [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) et effectuez un transtypage de la forme sélectionnée vers [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) si c’est le cas.  
5. [Ajoutez un nouveau Node](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) dans la forme SmartArt **NodeCollection** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) et définissez le texte dans TextFrame.  
6. Maintenant, [Ajoutez](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) un **Child Node** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) au nœud SmartArt nouvellement ajouté et définissez le texte dans TextFrame.  
7. Enregistrez la présentation.

```java
import com.aspose.slides.*;

// Charger la présentation désirée
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Parcourir chaque forme de la première diapositive
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
    
            // Ajouter un nouveau nœud enfant au nœud parent. Il sera ajouté à la fin de la collection
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Ajouter du texte
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Enregistrement de la présentation
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ajouter un nœud SmartArt à une position spécifique**
Dans le code d’exemple suivant, nous expliquons comment ajouter les nœuds enfants appartenant aux nœuds respectifs d’une forme SmartArt à une position particulière.

1. Créez une instance de la classe Presentation.  
2. Obtenez la référence de la première diapositive en utilisant son index.  
3. Ajoutez une forme SmartArt de type **StackedList** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) dans la diapositive accédée.  
4. Accédez au premier nœud de la forme SmartArt ajoutée.  
5. Ajoutez maintenant le **Child Node** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) pour le **Node** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArtNode) sélectionné à la position 2 et définissez son texte.  
6. Enregistrez la présentation.

```java
import com.aspose.slides.*;

// Créer une instance de présentation
Presentation pres = new Presentation();
try {
    // Accéder à la diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter un IShape SmartArt
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
Le code d’exemple suivant vous aidera à accéder aux nœuds à l’intérieur d’une forme SmartArt. Veuillez noter que le LayoutType du SmartArt est choisi lors de l’ajout de la forme ; le modifier plus tard avec **setLayout** reconstruit tout le diagramme, de sorte que les positions et tailles des nœuds que vous avez éventuellement définies sont recalculées.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation) et chargez la présentation contenant la forme SmartArt.  
2. Obtenez la référence de la première diapositive en utilisant son index.  
3. Parcourez chaque forme de la première diapositive.  
4. Vérifiez si la forme est du type [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) et transtypiez‑la en [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) si c’est le cas.  
5. Parcourez tous les **Nodes** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArt#getAllNodes--) à l’intérieur de la forme SmartArt.  
6. Accédez et affichez les informations telles que la position du nœud SmartArt, son niveau et son texte.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme de la première diapositive
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

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation) et chargez la présentation contenant la forme SmartArt.  
2. Obtenez la référence de la première diapositive en utilisant son index.  
3. Parcourez chaque forme de la première diapositive.  
4. Vérifiez si la forme est du type [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) et transtypiez‑la en [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) si c’est le cas.  
5. Parcourez tous les **Nodes** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArt#getAllNodes--) à l’intérieur de la forme SmartArt.  
6. Pour chaque **Node** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArtNode) de forme SmartArt sélectionnée, parcourez tous les **Child Nodes** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) à l’intérieur du nœud particulier.  
7. Accédez et affichez les informations telles que la position du **Child Node** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) , son niveau et son texte.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme de la première diapositive
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
                
                // Parcourir les nœuds enfants du nœud SmartArt à l'index i
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

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation).  
2. Obtenez la référence de la première diapositive en utilisant son index.  
3. Ajoutez une forme SmartArt de type **StackedList** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).  
4. Accédez à la forme SmartArt ajoutée.  
5. Accédez au nœud d’indice 0 de la forme SmartArt accédée.  
6. Maintenant, accédez au **Child Node** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) à la position 1 du nœud SmartArt accédé en utilisant la méthode **get_Item()**.  
7. Accédez et affichez les informations telles que la position du **Child Node**, son niveau et son texte.

```java
import com.aspose.slides.*;

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
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer un nœud SmartArt**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l’intérieur d’une forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation) et chargez la présentation contenant la forme SmartArt.  
2. Obtenez la référence de la première diapositive en utilisant son index.  
3. Parcourez chaque forme de la première diapositive.  
4. Vérifiez si la forme est du type [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) et transtypiez‑la en [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) si c’est le cas.  
5. Vérifiez si le [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) possède plus de 0 nœud.  
6. Sélectionnez le nœud SmartArt à supprimer.  
7. Supprimez maintenant le nœud sélectionné en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Enregistrez la présentation.

```java
import com.aspose.slides.*;

// Charger la présentation souhaitée
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Parcourir chaque forme de la première diapositive
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

## **Supprimer un nœud SmartArt à une position spécifique**
Dans cet exemple, nous apprendrons à supprimer les nœuds à l’intérieur d’une forme SmartArt à une position particulière.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation) et chargez la présentation contenant la forme SmartArt.  
2. Obtenez la référence de la première diapositive en utilisant son index.  
3. Parcourez chaque forme de la première diapositive.  
4. Vérifiez si la forme est du type [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) et transtypiez‑la en [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) si c’est le cas.  
5. Sélectionnez le nœud de forme SmartArt d’indice 0.  
6. Vérifiez maintenant si le nœud SmartArt sélectionné possède plus de 2 nœuds enfants.  
7. Supprimez maintenant le nœud à la **Position 1** en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
8. Enregistrez la présentation.

```java
import com.aspose.slides.*;

// Charger la présentation souhaitée
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Parcourir chaque forme de la première diapositive
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
Aspose.Slides for Android via Java prend désormais en charge la définition des propriétés [SmartArtShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArtShape) **X** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShape#setX-float-) et **Y** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShape#setY-float-). Le fragment de code ci‑dessous montre comment définir la position, la taille et la rotation personnalisées d’une SmartArtShape ; veuillez également noter que l’ajout de nouveaux nœuds entraîne un recalcul des positions et tailles de tous les nœuds. Avec des réglages de position personnalisés, l’utilisateur peut placer les nœuds selon ses besoins.

```java
import com.aspose.slides.*;

// Instancier la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Déplacer la forme SmartArt vers une nouvelle position
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Modifier la largeur de la forme SmartArt
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

Dans cet article, nous explorerons davantage les fonctionnalités des formes SmartArt ajoutées aux diapositives de présentation de façon programmatique à l’aide d’Aspose.Slides for Android via Java.

{{% /alert %}} 

Nous utiliserons la forme SmartArt source suivante pour nos investigations dans les différentes sections de cet article.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure : Forme SmartArt source dans la diapositive**|

Dans le code d’exemple suivant, nous étudierons comment identifier les **Assistant Nodes** dans la collection de nœuds SmartArt et les modifier.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation) et chargez la présentation contenant la forme SmartArt.  
2. Obtenez la référence de la première diapositive en utilisant son index.  
3. Parcourez chaque forme de la première diapositive.  
4. Vérifiez si la forme est du type [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) et transtypiez‑la en [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) si c’est le cas.  
5. Parcourez tous les nœuds à l’intérieur de la forme SmartArt et vérifiez s’ils sont des **Assistant Nodes** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
6. Changez le statut du nœud assistant en nœud normal.  
7. Enregistrez la présentation.

```java
import com.aspose.slides.*;

// Créer une instance de présentation
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Parcourir chaque forme de la première diapositive
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
                    // Définir le nœud Assistant sur false et le transformer en nœud normal
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
|**Figure : Nœuds assistants modifiés dans la forme SmartArt de la diapositive**|

## **Définir le format de remplissage d’un nœud**
Aspose.Slides for Android via Java permet d’ajouter des formes SmartArt personnalisées et de définir leur format de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage à l’aide d’Aspose.Slides for Android via Java.

Veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation).  
2. Obtenez la référence d’une diapositive en utilisant son index.  
3. Ajoutez une forme [SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArt) en définissant son **LayoutType** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Définissez le **FillFormat** ( https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IShape#getFillFormat--) pour les nœuds de la forme SmartArt.  
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

## **Générer une miniature d’un nœud SmartArt**
Les développeurs peuvent générer une miniature d’un nœud d’un SmartArt en suivant les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation).  
2. [Ajoutez SmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Obtenez la référence d’un nœud en utilisant son index.  
4. Récupérez l’image miniature.  
5. Enregistrez l’image miniature dans le format d’image souhaité.

```java
import com.aspose.slides.*;

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

### L’animation SmartArt est‑elle prise en charge ?

Oui. SmartArt est traité comme une forme ordinaire, vous pouvez donc [appliquer des animations standard](/slides/fr/androidjava/shape-animation/) (entrée, sortie, mise en valeur, trajectoires) et ajuster le timing. Vous pouvez également animer les formes à l’intérieur des nœuds SmartArt si nécessaire.

### Comment localiser de façon fiable un SmartArt spécifique sur une diapositive si son ID interne est inconnu ?

Attribuez et recherchez par [texte alternatif](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#getAlternativeText--). Définir un AltText distinctif sur le SmartArt vous permet de le trouver programmatiquement sans dépendre des identifiants internes.

### L’apparence du SmartArt sera‑t‑elle conservée lors de la conversion de la présentation en PDF ?

Oui. Aspose.Slides rend le SmartArt avec une haute fidélité visuelle lors de l’[export PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/), préservant la mise en page, les couleurs et les effets.

### Puis‑je extraire une image de l’intégralité du SmartArt (pour des aperçus ou des rapports) ?

Oui. Vous pouvez rendre une forme SmartArt vers des [formats raster](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) ou vers [SVG](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) pour une sortie vectorielle évolutive, ce qui la rend adaptée aux miniatures, aux rapports ou à l’usage web.