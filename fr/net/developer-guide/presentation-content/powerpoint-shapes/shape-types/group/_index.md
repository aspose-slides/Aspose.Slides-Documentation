---
title: Formes de groupe de présentation en .NET
linktitle: Groupe de formes
type: docs
weight: 40
url: /fr/net/group/
keywords:
- forme de groupe
- groupe de formes
- ajouter un groupe
- texte alternatif
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à regrouper et à dissocier des formes dans des présentations PowerPoint avec Aspose.Slides pour .NET - guide rapide, étape par étape, avec du code C# gratuit."
---

## **Ajouter une forme groupée**
Aspose.Slides prend en charge la manipulation des formes groupées sur les diapositives. Cette fonctionnalite aide les developpeurs a creer des presentaciones plus riches. Aspose.Slides pour .NET prend en charge l'ajout ou l'acces aux formes groupées. Il est possible d'ajouter des formes a une forme groupée ajoutee pour la remplir ou acceder a n'importe quelle propriete de la forme groupée. Pour ajouter une forme groupée a une diapositive avec Aspose.Slides pour .NET:

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir la reference d'une diapositive en utilisant son Index
1. Ajouter une forme groupée à la diapositive.
1. Ajouter les formes à la forme groupée ajoutée.
1. Enregistrer la présentation modifiee en tant que fichier PPTX.

L'exemple ci-dessous ajoute une forme groupée à une diapositive.
```c#
// Instancier la classe Presentation 
using (Presentation pres = new Presentation())
{
    // Obtenir la première diapositive 
    ISlide sld = pres.Slides[0];

    // Accéder à la collection de formes des diapositives 
    IShapeCollection slideShapes = sld.Shapes;

    // Ajouter une forme groupée à la diapositive 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Ajouter des formes à l'intérieur de la forme groupée ajoutée 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Ajouter le cadre de la forme groupée 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Écrire le fichier PPTX sur le disque 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```




## **Acceder a la propriete AltText**
Ce sujet montre des etapes simples, accompagnees d'exemples de code, pour ajouter une forme groupée et acceder a la propriete AltText des formes groupées sur les diapositives. Pour acceder a l'AltText d'une forme groupée dans une diapositive avec Aspose.Slides pour .NET:

1. Instancier la classe `Presentation` qui represente un fichier PPTX.
1. Obtenir la reference d'une diapositive en utilisant son Index.
1. Acceder a la collection de formes des diapositives.
1. Acceder a la forme groupée.
1. Acceder a la propriete AltText.

L'exemple ci-dessous accede au texte alternatif de la forme groupée.
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

**Le groupement imbrie (un groupe a l'interieur d'un groupe) est-il pris en charge?**

Oui. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) possède une propriete [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/) qui indique directement la prise en charge de la hierarchie (un groupe peut être l'enfant d'un autre groupe).

**Comment contrôler l'ordre Z du groupe par rapport aux autres objets de la diapositive?**

Utilisez la propriete [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) du [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) pour inspecter sa position dans la pile d'affichage.

**Puis-je empêcher le déplacement, l'édition ou la desagregation?**

Oui. La section de verrouillage du groupe est exposee via [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/), ce qui vous permet de restreindre les operations sur l'objet.