---
title: Groupe
type: docs
weight: 40
url: /fr/net/group/
keywords: "Forme groupée, forme PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Ajouter une forme groupée à une présentation PowerPoint en C# ou .NET"
---

## **Ajouter une forme groupée**
Aspose.Slides prend en charge la manipulation des formes groupées sur les diapositives. Cette fonctionnalité aide les développeurs à créer des présentations plus riches. Aspose.Slides for .NET prend en charge l’ajout ou l’accès aux formes groupées. Il est possible d’ajouter des formes à une forme groupée ajoutée pour la remplir ou accéder à n’importe quelle propriété de la forme groupée. Pour ajouter une forme groupée à une diapositive à l’aide d’Aspose.Slides for .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez la référence d’une diapositive en utilisant son Index.
3. Ajoutez une forme groupée à la diapositive.
4. Ajoutez les formes à la forme groupée ajoutée.
5. Enregistrez la présentation modifiée en tant que fichier PPTX.

L’exemple ci‑dessous ajoute une forme groupée à une diapositive.
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

    // Ajouter des formes dans la forme groupée ajoutée 
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


## **Accéder à la propriété AltText**
Ce sujet présente des étapes simples, accompagnées d’exemples de code, pour ajouter une forme groupée et accéder à la propriété AltText des formes groupées sur les diapositives. Pour accéder à l’AltText d’une forme groupée dans une diapositive à l’aide d’Aspose.Slides for .NET :

1. Instanciez la classe `Presentation` qui représente le fichier PPTX.
2. Obtenez la référence d’une diapositive en utilisant son Index.
3. Accédez à la collection de formes des diapositives.
4. Accédez à la forme groupée.
5. Accédez à la propriété AltText.

L’exemple ci‑dessous accède au texte alternatif de la forme groupée.
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

**Le groupement imbriqué (une forme groupée à l’intérieur d’une autre) est‑il pris en charge ?**  
Oui. [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) possède une propriété [ParentGroup](https://reference.aspose.com/slides/net/aspose.slides/shape/parentgroup/) qui indique directement la prise en charge de la hiérarchie (une forme groupée peut être l’enfant d’une autre forme groupée).

**Comment contrôler l’ordre Z du groupe par rapport aux autres objets sur la diapositive ?**  
Utilisez la propriété [ZOrderPosition](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) du [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/) pour inspecter ou modifier sa position dans la pile d’affichage.

**Puis‑je empêcher le déplacement/l’édition/le dégroupage ?**  
Oui. La section de verrouillage du groupe est exposée via [GroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/groupshape/groupshapelock/), ce qui vous permet de restreindre les opérations sur l’objet.