---
title: Gérer SmartArt
type: docs
weight: 10
url: /fr/net/manage-smartart/
keywords: "SmartArt, texte de SmartArt, graphique de type organisation, graphique d'organisation avec image, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "SmartArt et graphique de type organisation dans les présentations PowerPoint en C# ou .NET"
---

## **Obtenir du texte à partir de SmartArt**
Maintenant, la propriété TextFrame a été ajoutée à l'interface ISmartArtShape et à la classe SmartArtShape respectivement. Cette propriété vous permet d'obtenir tout le texte de SmartArt s'il n'a pas seulement du texte dans les nœuds. Le code d'exemple suivant vous aidera à obtenir du texte à partir d'un nœud SmartArt.

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



## **Changer le type de mise en page de SmartArt**
Pour changer le type de mise en page de SmartArt, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe `Presentation`.
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez SmartArt BasicBlockList.
- Changez le LayoutType en BasicProcess.
- Écrivez la présentation sous forme de fichier PPTX.
  Dans l'exemple donné ci-dessous, nous avons ajouté un connecteur entre deux formes.

```c#
using (Presentation presentation = new Presentation())
{
    // Ajouter SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Changer le LayoutType en BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // Sauvegarder la présentation
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```



## **Vérifier la propriété cachée de SmartArt**
Veuillez noter que la méthode com.aspose.slides.ISmartArtNode.isHidden() renvoie true si ce nœud est un nœud caché dans le modèle de données. Pour vérifier la propriété cachée de n'importe quel nœud de SmartArt, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe `Presentation`.
- Ajoutez SmartArt RadialCycle.
- Ajoutez un nœud sur SmartArt.
- Vérifiez la propriété isHidden.
- Écrivez la présentation sous forme de fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté un connecteur entre deux formes.

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
        // Faire des actions ou notifications
    }
    // Sauvegarder la présentation
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```



## **Obtenir ou définir le type de graphique d'organisation**
Les méthodes com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) permettent d'obtenir ou de définir le type de graphique d'organisation associé au nœud actuel. Pour obtenir ou définir le type de graphique d'organisation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe `Presentation`.
- Ajoutez SmartArt sur la diapositive.
- Obtenez ou définissez le type de graphique d'organisation.
- Écrivez la présentation sous forme de fichier PPTX.
  Dans l'exemple donné ci-dessous, nous avons ajouté un connecteur entre deux formes.

```c#
using (Presentation presentation = new Presentation())
{
    // Ajouter SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Obtenir ou définir le type de graphique d'organisation 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Sauvegarder la présentation
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```




## **Créer un graphique d'organisation avec image**
Aspose.Slides pour .NET fournit une API simple pour créer des graphiques d'organisation avec image de manière simple. Pour créer un graphique sur une diapositive :

1. Créez une instance de la classe `Presentation`.
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type désiré (ChartType.PictureOrganizationChart).
1. Écrivez la présentation modifiée dans un fichier PPTX.

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