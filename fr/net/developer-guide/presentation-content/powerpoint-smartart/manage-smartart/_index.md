---
title: Gérer SmartArt dans les présentations PowerPoint en .NET
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/net/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de disposition
- propriété masquée
- organigramme
- organigramme d'images
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides for .NET en utilisant des exemples de code C# clairs qui accélèrent la conception de diapositives et l'automatisation."
---

## **Obtenir le texte de SmartArt**
La propriété TextFrame a maintenant été ajoutée à l'interface ISmartArtShape et à la classe SmartArtShape respectivement. Cette propriété vous permet d'obtenir tout le texte de SmartArt même s'il ne contient pas seulement le texte des nœuds. Le code d'exemple suivant vous aidera à obtenir le texte d'un nœud SmartArt.
```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
	ISlide slide = pres.Slides[0];
	ISmartArt smartArt = (ISmartArt)slide.Shapes[0];

	ISmartArtNodeCollection smartArtNodes = smartArt.AllNodes;
	foreach (ISmartArtNode smartArtNode in smartArtNodes)
	{
		foreach (ISmartArtShape nodeShape in smartArtNode.Shapes)
		{
			if (nodeShape.TextFrame != null)
				Console.WriteLine(nodeShape.TextFrame.Text);
		}
	}
}
```




## **Modifier le type de disposition de SmartArt**
Pour changer le type de disposition de SmartArt, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe `Presentation`.
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter un SmartArt BasicBlockList.
- Modifier LayoutType en BasicProcess.
- Enregistrer la présentation au format PPTX.
  Dans l'exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```c#
using (Presentation presentation = new Presentation())
{
    // Ajouter SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Modifier LayoutType en BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // Enregistrement de la présentation
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```




## **Vérifier la propriété Hidden de SmartArt**
Veuillez noter que la méthode com.aspose.slides.ISmartArtNode.isHidden() retourne true si ce nœud est masqué dans le modèle de données. Pour vérifier la propriété masquée d'un nœud SmartArt, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe `Presentation`.
- Ajouter un SmartArt RadialCycle.
- Ajouter un nœud au SmartArt.
- Vérifier la propriété isHidden.
- Enregistrer la présentation au format PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```c#
using (Presentation presentation = new Presentation())
{
    // Ajouter SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Ajouter un nœud sur SmartArt 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // Vérifier la propriété IsHidden
    bool hidden = node.IsHidden; // Retourne true

    if (hidden)
    {
        // Effectuer des actions ou notifications
    }
    // Enregistrement de la présentation
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```




## **Obtenir ou définir le type de diagramme organisationnel**
Les méthodes com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() et setOrganizationChartLayout(int) permettent d'obtenir ou de définir le type de diagramme organisationnel associé au nœud actuel. Pour obtenir ou définir le type de diagramme organisationnel, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe `Presentation`.
- Ajouter SmartArt sur la diapositive.
- Obtenir ou définir le type de diagramme organisationnel.
- Enregistrer la présentation au format PPTX.
  Dans l'exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```c#
using (Presentation presentation = new Presentation())
{
    // Ajouter SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Obtenir ou définir le type de diagramme d'organisation 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Enregistrement de la présentation
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```





## **Créer un diagramme d'organisation d'images**
Aspose.Slides for .NET fournit une API simple pour créer des graphiques PictureOrganization facilement. Pour créer un graphique sur une diapositive :

1. Créez une instance de la classe `Presentation`.
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (ChartType.PictureOrganizationChart).
4. Enregistrez la présentation modifiée au format PPTX

Le code suivant est utilisé pour créer un graphique.
```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
		pres.Save("OrganizationChart.pptx", SaveFormat.Pptx);
	}			
}
```


## **FAQ**

**Le SmartArt prend‑il en charge le miroir / l’inversion pour les langues RTL ?**

Oui. La propriété [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) change le sens du diagramme (LTR/RTL) si le type SmartArt sélectionné prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/net/shape-manipulations/) via la collection de formes ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) ou [cloner toute la diapositive](/slides/fr/net/clone-slides/) contenant cette forme. Les deux approches conservent la taille, la position et le style.

**Comment rendre le SmartArt en image raster pour un aperçu ou une exportation web ?**

[Render the slide](/slides/fr/net/convert-powerpoint-to-png/) (or the whole presentation) to PNG/JPEG through the API that converts slides/presentations to images—SmartArt will be drawn as part of the slide.

**Comment sélectionner programmatiquement un SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Une pratique courante consiste à utiliser le [texte alternatif](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt Text) ou un [Nom](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) et rechercher la forme par cet attribut dans [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), puis vérifier le type pour confirmer qu’il s’agit d’un [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/). La documentation décrit les techniques typiques pour trouver et travailler avec les formes.