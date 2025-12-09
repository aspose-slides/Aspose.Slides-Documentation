---
title: Formes de présentation groupées en .NET
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
description: "Apprenez à regrouper et dissocier des formes dans les présentations PowerPoint avec Aspose.Slides pour .NET — guide rapide, étape par étape, avec du code C# gratuit."
---

## **Ajouter une forme de groupe**
Aspose.Slides prend en charge la manipulation des formes de groupe sur les diapositives. Cette fonctionnalite aide les developpeurs a creer des presentations plus riches. Aspose.Slides pour .NET permet d'ajouter ou d'acceder aux formes de groupe. Il est possible d'ajouter des formes a une forme de groupe ajoutee pour la remplir ou d'acceder a n'importe quelle propriete de la forme de groupe. Pour ajouter une forme de groupe a une diapositive a l'aide d'Aspose.Slides pour .NET :

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir la reference d'une diapositive en utilisant son Index
1. Ajouter une forme de groupe a la diapositive.
1. Ajouter les formes a la forme de groupe ajoutee.
1. Enregistrer la presentation modifiee sous forme de fichier PPTX.

L'exemple ci-dessous ajoute une forme de groupe a une diapositive.
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

    // Ajouter des formes à l'intérieur du groupe ajouté 
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


## **Acceder a la propriete AltText**
Ce sujet montre des etapes simples, avec des exemples de code, pour ajouter une forme de groupe et acceder a la propriete AltText des formes de groupe sur les diapositives. Pour acceder a l'AltText d'une forme de groupe dans une diapositive a l'aide d'Aspose.Slides pour .NET :

1. Instancier la classe `Presentation` qui represente le fichier PPTX.
1. Obtenir la reference d'une diapositive en utilisant son Index.
1. Acceder a la collection de formes des diapositives.
1. Acceder a la forme de groupe.
1. Acceder a la propriete AltText.

L'exemple ci-dessous accede au texte alternatif de la forme de groupe.
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
        // Accéder à la forme de groupe.
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

**Le groupement imbrine (un groupe a l'interieur d'un autre groupe) est-il pris en charge ?**

Oui. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) possede une propriete [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/) qui indique directement la prise en charge de la hierarchie (un groupe peut etre enfant d'un autre groupe).

**Comment controler l'ordre Z du groupe par rapport aux autres objets de la diapositive ?**

Utilisez la propriete [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) du [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) pour examiner sa position dans la pile d'affichage.

**Puis-je empêcher le deplacement/la modification/le degrouppage ?**

Oui. La section de verrouillage du groupe est exposee via [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/), ce qui vous permet de restreindre les operations sur l'objet.