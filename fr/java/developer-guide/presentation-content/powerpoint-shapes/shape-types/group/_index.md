---
title: Formes de groupe de présentation en Java
linktitle: Groupe de formes
type: docs
weight: 40
url: /fr/java/group/
keywords:
- forme groupée
- groupe de formes
- ajouter un groupe
- texte alternatif
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à regrouper et dégrouper des formes dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Java — guide rapide, étape par étape, avec du code Java gratuit."
---

## **Ajouter une forme groupée**
Aspose.Slides prend en charge le travail avec des formes groupées sur les diapositives. Cette fonctionnalité aide les développeurs à créer des présentations plus riches. Aspose.Slides for Java prend en charge l’ajout ou l’accès aux formes groupées. Il est possible d’ajouter des formes à une forme groupée ajoutée pour la remplir ou accéder à n’importe quelle propriété de la forme groupée. Pour ajouter une forme groupée à une diapositive à l’aide d’Aspose.Slides for Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence d’une diapositive en utilisant son Index
1. Ajoutez une forme groupée à la diapositive.
1. Ajoutez les formes à la forme groupée ajoutée.
1. Enregistrez la présentation modifiée au format PPTX.

L'exemple ci-dessous ajoute une forme groupée à une diapositive.
```java
// Instancier la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Accéder à la collection de formes des diapositives
    IShapeCollection slideShapes = sld.getShapes();

    // Ajouter une forme groupée à la diapositive
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Ajouter des formes à l'intérieur de la forme groupée ajoutée
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Ajouter le cadre de la forme groupée
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Écrire le fichier PPTX sur le disque
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Accéder à la propriété AltText**
Ce sujet présente des étapes simples, illustrées par des exemples de code, pour ajouter une forme groupée et accéder à la propriété AltText des formes groupées sur les diapositives. Pour accéder à l'AltText d’une forme groupée dans une diapositive à l’aide d’Aspose.Slides for Java :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui représente le fichier PPTX.
1. Obtenez la référence d’une diapositive en utilisant son Index.
1. Accédez à la collection de formes des diapositives.
1. Accédez à la forme groupée.
1. Accédez à la propriété [AlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getAlternativeText--).

L'exemple ci-dessous accède au texte alternatif de la forme groupée.
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
            // Accéder à la forme groupée.
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


## **FAQ**

**Le groupement imbriqué (un groupe à l'intérieur d'un groupe) est‑il pris en charge ?**

Oui. [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/) possède une méthode [getParentGroup](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getParentGroup--) qui indique directement la prise en charge de la hiérarchie (un groupe peut être l'enfant d'un autre groupe).

**Comment contrôler l'ordre Z du groupe par rapport aux autres objets de la diapositive ?**

Utilisez la méthode [getZOrderPosition](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) du [GroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/) pour inspecter sa position dans la pile d'affichage.

**Puis‑je empêcher le déplacement/édition/dégrouper ?**

Oui. La section de verrouillage du groupe est exposée via [GroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/groupshape/#getGroupShapeLock--) qui vous permet de restreindre les opérations sur l'objet.