---
title: Groupe
type: docs
weight: 40
url: /fr/net/group/
keywords: "Forme de groupe, forme PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Ajouter une forme de groupe à une présentation PowerPoint en C# ou .NET"
---

## **Ajouter une forme de groupe**
Aspose.Slides prend en charge la manipulation des formes de groupe sur les diapositives. Cette fonctionnalité aide les développeurs à créer des présentations plus riches. Aspose.Slides pour .NET prend en charge l’ajout ou l’accès aux formes de groupe. Il est possible d’ajouter des formes à une forme de groupe ajoutée pour la remplir ou d’accéder à n’importe quelle propriété de la forme de groupe. Pour ajouter une forme de groupe à une diapositive à l’aide d’Aspose.Slides pour .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence d’une diapositive en utilisant son index.
1. Ajoutez une forme de groupe à la diapositive.
1. Ajoutez les formes à la forme de groupe ajoutée.
1. Enregistrez la présentation modifiée au format PPTX.

L’exemple ci‑dessous ajoute une forme de groupe à une diapositive.
```c#
// Instancier la classe Presentation
using (Presentation pres = new Presentation())
{
    // Obtenir la première diapositive
    ISlide sld = pres.Slides[0];

    // Accéder à la collection de formes des diapositives
    IShapeCollection slideShapes = sld.Shapes;

    // Ajouter une forme de groupe à la diapositive
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Ajouter des formes à l'intérieur de la forme de groupe ajoutée
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Ajouter le cadre de la forme de groupe
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Écrire le fichier PPTX sur le disque
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```




## **Accéder à la propriété AltText**
Cet article montre les étapes simples, avec des exemples de code, pour ajouter une forme de groupe et accéder à la propriété AltText des formes de groupe sur les diapositives. Pour accéder à l’AltText d’une forme de groupe dans une diapositive à l’aide d’Aspose.Slides pour .NET :

1. Instanciez la classe `Presentation` qui représente le fichier PPTX.
1. Obtenez la référence d’une diapositive en utilisant son index.
1. Accédez à la collection de formes des diapositives.
1. Accédez à la forme de groupe.
1. Accédez à la propriété AltText.

L’exemple ci‑dessous accède au texte alternatif de la forme de groupe.
```c#
 // Instancier la classe Presentation qui représente le fichier PPTX
Presentation pres = new Presentation("AltText.pptx");

// Obtenir la première diapositive
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Accéder à la collection de formes des diapositives
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Accéder à la forme groupée.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Accéder à la propriété AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```


## **FAQ**

**Le groupement imbriqué (un groupe à l’intérieur d’un groupe) est‑il pris en charge ?**

Oui. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) possède une propriété [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/) qui indique directement la prise en charge de la hiérarchie (un groupe peut être enfant d’un autre groupe).

**Comment contrôler l’ordre Z du groupe par rapport aux autres objets de la diapositive ?**

Utilisez la propriété [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) de [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) pour inspecter sa position dans la pile d’affichage.

**Puis‑je empêcher le déplacement/la modification/le dégroupage ?**

Oui. La section de verrouillage du groupe est exposée via [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/), qui vous permet de restreindre les opérations sur l’objet.
