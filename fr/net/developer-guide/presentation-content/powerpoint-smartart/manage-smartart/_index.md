---
title: Gérer SmartArt dans les présentations PowerPoint en .NET
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/net/manage-smartart/
keywords:
- SmartArt
- Texte SmartArt
- type de mise en page
- propriété masquée
- organigramme
- organigramme illustré
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour .NET en utilisant des exemples de code C# clairs qui accélèrent la conception de diapositives et l'automatisation."
---
## **Vue d'ensemble**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une mise en page. Avec Aspose.Slides pour .NET, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur mise en page, examiner les nœuds masqués, configurer les mises en page d’organigramme et créer des organigrammes illustrés.

## **Obtenir le texte d'un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte visible, parcourez [ISmartArt.AllNodes](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/ismartart/allnodes/), puis lisez le [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) renvoyé par [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **Modifier le type de mise en page d'un objet SmartArt**

La mise en page SmartArt contrôle la façon dont les nœuds sont disposés et connectés. L'exemple suivant crée un objet SmartArt avec la valeur `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/smartartlayouttype/), la modifie en `BasicProcess` et enregistre la présentation.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Vérifier si un nœud SmartArt est masqué**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/ismartartnode/ishidden/) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la mise en page sélectionnée ne les affiche pas comme éléments visibles du diagramme.

L'exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/smartartlayouttype/) et vérifie l'état masqué du nœud.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Obtenir ou définir la mise en page de l'organigramme**

Pour les diagrammes SmartArt qui utilisent une mise en page d’organigramme, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) définit comment les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez faire pendre les nœuds enfants à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/organizationchartlayouttype/) sélectionné.

L'exemple suivant crée un organigramme et définit la mise en page du premier nœud sur la valeur `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/organizationchartlayouttype/).

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Créer un organigramme illustré**

Un organigramme illustré est une mise en page SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d'images. Utilisez la valeur `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/smartartlayouttype/) lors de l'ajout de l'objet SmartArt à une diapositive.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**SmartArt prend‑il en charge le miroir ou l’inversion pour les langues RTL ?**

Oui. La propriété [IsReversed](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/smartart/isreversed/) inverse la direction du diagramme de gauche à droite vers droite à gauche, ou inversement, lorsque la mise en page SmartArt sélectionnée prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou vers une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/net/shape-manipulations/) avec [ShapeCollection.AddClone](https://reference.aspose.com/slides/fr/net/aspose.slides/shapecollection/addclone/) ou [cloner toute la diapositive](/slides/fr/net/clone-slides/) contenant le SmartArt. Les deux méthodes conservent la taille, la position et le formatage.

**Comment rendre SmartArt en image matricielle pour un aperçu ou une exportation Web ?**

[Rendez la diapositive](/slides/fr/net/convert-powerpoint-to-png/) ou la présentation entière au format PNG ou JPEG. Le SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Attribuez une valeur distinctive à [AlternativeText](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/alternativetext/) ou [Name](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/name/) sur la forme SmartArt, recherchez cette valeur dans [Slide.Shapes](https://reference.aspose.com/slides/fr/net/aspose.slides/baseslide/shapes/), puis vérifiez que la forme correspondante est un [ISmartArt](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/ismartart/).