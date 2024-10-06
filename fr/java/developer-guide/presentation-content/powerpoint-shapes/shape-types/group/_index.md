---
title: Groupe
type: docs
weight: 40
url: /java/group/
---

## **Ajouter une forme de groupe**
Aspose.Slides prend en charge le travail avec des formes de groupe sur les diapositives. Cette fonctionnalité aide les développeurs à prendre en charge des présentations plus riches. Aspose.Slides pour Java prend en charge l'ajout ou l'accès à des formes de groupe. Il est possible d'ajouter des formes à une forme de groupe ajoutée pour la remplir ou d'accéder à n'importe quelle propriété de la forme de groupe. Pour ajouter une forme de groupe à une diapositive à l'aide d'Aspose.Slides pour Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une forme de groupe à la diapositive.
1. Ajoutez les formes à la forme de groupe ajoutée.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

L'exemple ci-dessous ajoute une forme de groupe à une diapositive.

```java
// Instancier la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Accéder à la collection de formes des diapositives
    IShapeCollection slideShapes = sld.getShapes();

    // Ajouter une forme de groupe à la diapositive
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Ajouter des formes à l'intérieur de la forme de groupe ajoutée
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Ajouter le cadre de la forme de groupe
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Écrire le fichier PPTX sur le disque
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accéder à la propriété AltText**
Ce sujet montre des étapes simples, complètes avec des exemples de code, pour ajouter une forme de groupe et accéder à la propriété AltText des formes de groupe sur les diapositives. Pour accéder à l'AltText d'une forme de groupe dans une diapositive à l'aide d'Aspose.Slides pour Java :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui représente le fichier PPTX.
1. Obtenir la référence d'une diapositive en utilisant son index.
1. Accéder à la collection de formes des diapositives.
1. Accéder à la forme de groupe.
1. Accéder à la propriété [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--).

L'exemple ci-dessous accède au texte alternatif de la forme de groupe.

```java
// Instancier la classe Presentation qui représente le fichier PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Accéder à la collection de formes des diapositives
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Accéder à la forme de groupe.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Accéder à la propriété AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```