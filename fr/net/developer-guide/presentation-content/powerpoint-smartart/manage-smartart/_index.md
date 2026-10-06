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
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides for .NET en utilisant des exemples de code C# clairs qui accélèrent la conception de diapositives et l'automatisation."
---
## **Vue d'ensemble**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une disposition. Avec Aspose.Slides for .NET, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur disposition, inspecter les nœuds masqués, configurer les dispositions des organigrammes et créer des organigrammes illustrés.

## **Obtenir le texte d'un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte des formes du nœud, parcourez [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), puis lisez le [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) renvoyé par [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

L'exemple nécessite une présentation contenant au moins une diapositive et un objet SmartArt en tant que première forme sur cette diapositive. Il imprime chaque cadre de texte disponible dans la console.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Modifier le type de mise en page d'un objet SmartArt**

La disposition SmartArt contrôle la façon dont les nœuds sont disposés et connectés. L'exemple suivant crée un objet SmartArt avec la valeur `BasicBlockList` du [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/), la change en la valeur `BasicProcess` et enregistre la présentation. La position et la taille transmises à [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) sont exprimées en points. Définissez [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) pour modifier la disposition.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Vérifier si un nœud SmartArt est masqué**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la disposition sélectionnée ne les affiche pas comme des éléments visibles du diagramme.

L'exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur `RadialCycle` du [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/), puis vérifie l'état masqué du nœud ajouté. Il affiche un message si le nœud est masqué et enregistre le diagramme.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Obtenir ou définir la disposition de l'organigramme**

Pour les diagrammes SmartArt qui utilisent une disposition d'organigramme, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) définit la façon dont les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez faire pendre les nœuds enfants à gauche, à droite ou aux deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) sélectionné.

L'exemple suivant crée un organigramme et définit la disposition du premier nœud sur la valeur `LeftHanging` du [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/). L'index zéro `0` sélectionne le premier nœud de niveau supérieur ; ses nœuds enfants utilisent la disposition sélectionnée. La présentation modifiée est ensuite enregistrée.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Créer un organigramme illustré**

Un organigramme illustré est une disposition SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d'image. Utilisez la valeur `PictureOrganizationChart` du [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) lors de l'ajout de l'objet SmartArt à une diapositive. Cet exemple enregistre un diagramme avec des espaces réservés d'image ; il ne remplit pas ces espaces avec des images.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Convertir les diagrammes hérités en groupes de formes**

Lors de la modernisation d'une présentation existante, vous pouvez devoir mettre à jour un organigramme créé à l'origine dans PowerPoint 97–2003. Aspose.Slides représente ces diagrammes hérités comme des objets [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/). Utilisez [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) pour convertir un diagramme en groupe de formes afin de pouvoir éditer les éléments visuels individuels. Consultez la [Référence API LegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) pour plus de détails.

La conversion ajoute un nouveau groupe à la collection de formes sans supprimer le diagramme d'origine. Après une conversion réussie, supprimez l'original avec [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) pour éviter le contenu dupliqué. Rassemblez les diagrammes hérités dans un tableau avant de les convertir afin que l'ajout et la suppression de formes n'interrompent pas l'itération.

L'exemple suivant ouvre une présentation, parcourt chaque diapositive, convertit les diagrammes en groupes de formes et enregistre la présentation mise à jour au format PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

La présentation enregistrée contient des groupes de formes modifiables à la place des diagrammes hérités convertis, sans diagrammes d'origine restant à leurs côtés. Ouvrez le PPTX dans PowerPoint pour modifier les éléments individuels au sein de chaque groupe, comme leur texte, remplissage ou position.

## **FAQ**

**SmartArt prend‑il en charge le miroir ou l'inversion pour les langues RTL ?**

Oui. La propriété [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) bascule la direction du diagramme de gauche à droite à droite à gauche, ou inversement, lorsque la disposition SmartArt sélectionnée prend en charge l'inversion.

**Comment copier un SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/net/shape-manipulations/) avec [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) ou [cloner la diapositive entière](/slides/fr/net/clone-slides/) qui contient le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre un SmartArt en image raster pour un aperçu ou une exportation web ?**

[Render the slide](/slides/fr/net/convert-powerpoint-to-png/) ou toute la présentation en PNG ou JPEG. Le SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s'il y en a plusieurs ?**

Définissez une valeur distinctive d'[AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) ou de [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) sur la forme SmartArt, recherchez cette valeur dans [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), puis vérifiez que la forme correspondante est un [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).