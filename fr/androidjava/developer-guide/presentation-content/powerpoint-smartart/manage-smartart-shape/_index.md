---
title: Gérer la forme SmartArt
type: docs
weight: 20
url: /androidjava/manage-smartart-shape/
---

## **Créer une forme SmartArt**
Aspose.Slides pour Android via Java a fourni une API pour créer des formes SmartArt. Pour créer une forme SmartArt dans une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. [Ajoutez une forme SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en définissant son [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

```java
// Instancier la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenez la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter une forme Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Sauvegarder la présentation
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure : Forme SmartArt ajoutée à la diapositive**|

## **Accéder à la forme SmartArt dans la diapositive**
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de présentation. Dans le code d'exemple, nous allons parcourir chaque forme à l'intérieur de la diapositive et vérifier si elle est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). Si la forme est de type SmartArt, nous allons la typcast en instance de [**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt).

```java
// Charger la présentation désirée
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt)
        {
            // Typcast la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Nom de la forme :" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accéder à la forme SmartArt avec un type de mise en page particulier**
Le code d'exemple suivant vous aidera à accéder à la forme [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) avec un certain LayoutType. Veuillez noter que vous ne pouvez pas changer le LayoutType du SmartArt car il est en lecture seule et est défini uniquement lorsque la forme [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) est ajoutée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son Index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) et typcast la forme sélectionnée en SmartArt si elle est SmartArt.
1. Vérifiez la forme SmartArt avec un LayoutType particulier et effectuez ce qui est nécessaire ensuite.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt)
        {
            // Typcast la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Vérification de la mise en page SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Faire quelque chose ici....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Changer le style de forme SmartArt**
Dans cet exemple, nous allons apprendre à changer le style rapide pour toute forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son Index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) et typcast la forme sélectionnée en SmartArt si elle est SmartArt.
1. Trouvez la forme SmartArt avec un style particulier.
1. Définissez le nouveau style pour la forme SmartArt.
1. Enregistrez la présentation.

```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtenez la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Typcast la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Vérification du style SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Changer le style SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Sauvegarder la présentation
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure : Forme SmartArt avec style changé**|

## **Changer le style de couleur de forme SmartArt**
Dans cet exemple, nous allons apprendre à changer le style de couleur pour toute forme SmartArt. Dans le code d'exemple suivant, nous allons accéder à la forme SmartArt avec un style de couleur particulier et changer son style.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son Index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) et typcast la forme sélectionnée en SmartArt si elle est SmartArt.
1. Trouvez la forme SmartArt avec un style de couleur particulier.
1. Définissez le nouveau style de couleur pour la forme SmartArt.
1. Enregistrez la présentation.

```java
// Instancier la classe Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Obtenez la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (IShape shape : slide.getShapes()) 
    {
        // Vérifier si la forme est de type SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Typcast la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Vérification du type de couleur SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Changer le type de couleur SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Sauvegarder la présentation
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure : Forme SmartArt avec style de couleur changé**|