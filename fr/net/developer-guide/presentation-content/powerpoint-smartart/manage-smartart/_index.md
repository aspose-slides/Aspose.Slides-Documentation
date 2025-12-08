---
title: Gérer SmartArt
type: docs
weight: 10
url: /fr/net/manage-smartart/
keywords: "SmartArt, texte de SmartArt, diagramme de type organisation, diagramme d'organisation d'image, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "SmartArt et diagramme de type organisation dans les présentations PowerPoint en C# ou .NET"
---

## **Obtenir le texte depuis SmartArt**
La propriété TextFrame a maintenant été ajoutée à l'interface ISmartArtShape et à la classe SmartArtShape respectivement. Cette propriété vous permet d'obtenir tout le texte d'un SmartArt même s'il ne contient pas uniquement le texte des nœuds. Le code d'exemple suivant vous aidera à obtenir le texte d'un nœud SmartArt.
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


## **Modifier le type de mise en page de SmartArt**
Pour changer le type de mise en page du SmartArt, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe `Presentation`.
- Obtenez la référence d'une diapositive en utilisant son Index.
- Ajoutez un SmartArt BasicBlockList.
- Modifiez la propriété LayoutType en BasicProcess.
- Enregistrez la présentation en tant que fichier PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```c#
using (Presentation presentation = new Presentation())
{
    // Ajouter SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Modifier le LayoutType en BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // Enregistrement de la présentation
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```


## **Vérifier la propriété Hidden du SmartArt**
Veuillez noter que la méthode com.aspose.slides.ISmartArtNode.isHidden() renvoie true si ce nœud est un nœud masqué dans le modèle de données. Pour vérifier la propriété hidden de n'importe quel nœud du SmartArt, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe `Presentation`.
- Ajoutez un SmartArt RadialCycle.
- Ajoutez un nœud au SmartArt.
- Vérifiez la propriété isHidden.
- Enregistrez la présentation en tant que fichier PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```c#
using (Presentation presentation = new Presentation())
{
    // Ajouter SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Ajouter un nœud sur SmartArt 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // Vérifier la propriété isHidden
    bool hidden = node.IsHidden; // Renvoie true

    if (hidden)
    {
        // Effectuer certaines actions ou notifications
    }
    // Enregistrement de la présentation
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```


## **Obtenir ou définir le type de diagramme organisationnel**
Les méthodes com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() et setOrganizationChartLayout(int) permettent d'obtenir ou de définir le type de diagramme organisationnel associé au nœud actuel. Pour obtenir ou définir le type de diagramme organisationnel, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe `Presentation`.
- Ajoutez un SmartArt sur la diapositive.
- Obtenez ou définissez le type de diagramme organisationnel.
- Enregistrez la présentation en tant que fichier PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```c#
using (Presentation presentation = new Presentation())
{
    // Ajouter SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Obtenir ou définir le type de diagramme organisationnel 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Enregistrement de la présentation
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```


## **Créer un diagramme d'organisation d'images**
Aspose.Slides pour .NET fournit une API simple pour créer des graphiques PictureOrganization facilement. Pour créer un graphique sur une diapositive :

1. Créez une instance de la classe `Presentation`.
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.PictureOrganizationChart).
4. Enregistrez la présentation modifiée dans un fichier PPTX

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

**Le SmartArt prend‑il en charge le miroir/l’inversion pour les langues RTL ?**

Oui. La propriété [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) inverse la direction du diagramme (LTR/RTL) si le type de SmartArt sélectionné prend en charge l’inversion.

**Comment copier le SmartArt sur la même diapositive ou vers une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/net/shape-manipulations/) via la collection de formes ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) ou [cloner la diapositive entière](/slides/fr/net/clone-slides/) contenant cette forme. Les deux approches conservent la taille, la position et le style.

**Comment rendre le SmartArt en image raster pour un aperçu ou une exportation web ?**

[Rendez la diapositive](/slides/fr/net/convert-powerpoint-to-png/) (ou l’ensemble de la présentation) en PNG/JPEG via l’API qui convertit les diapositives/présentations en images — le SmartArt sera rendu comme partie de la diapositive.

**Comment sélectionner programmatiquement un SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Une pratique courante consiste à utiliser le [texte alternatif](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt Text) ou un [Nom](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) et à rechercher la forme par cet attribut dans [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), puis à vérifier le type pour confirmer qu’il s’agit d’un [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/). La documentation décrit les techniques typiques pour trouver et travailler avec les formes.