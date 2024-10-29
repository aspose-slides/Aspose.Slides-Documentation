---
title: Gérer SmartArt
type: docs
weight: 10
url: /fr/python-net/manage-smartart/
keywords: "SmartArt, texte de SmartArt, graphique de type organisation, graphique organisationnel d'images, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "SmartArt et graphique de type organisation dans les présentations PowerPoint en Python"
---

## **Obtenir du texte à partir de SmartArt**
Maintenant, la propriété TextFrame a été ajoutée à l'interface ISmartArtShape et à la classe SmartArtShape respectivement. Cette propriété vous permet d'obtenir tout le texte à partir de SmartArt s'il n'a pas seulement du texte de nœuds. Le code d'exemple suivant vous aidera à obtenir le texte d'un nœud SmartArt.

```py
import aspose.slides as slides

with slides.Presentation(path + "SmartArt.pptx") as pres:
    slide = pres.slides[0]
    smartArt = slide.shapes[0]

    for smartArtNode in smartArt.all_nodes:
        for nodeShape in smartArtNode.shapes:
            if nodeShape.text_frame != None:
                print(nodeShape.text_frame.text)
```



## **Changer le type de mise en page de SmartArt**
Pour changer le type de mise en page de SmartArt. Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe `Presentation`.
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez SmartArt BasicBlockList.
- Changez LayoutType en BasicProcess.
- Enregistrez la présentation en tant que fichier PPTX.
  Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Ajoutez SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Changez LayoutType en BasicProcess
    smart.layout = art.SmartArtLayoutType.BASIC_PROCESS
    # Enregistrement de la présentation
    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Vérifier la propriété cachée de SmartArt**
Veuillez noter que la méthode com.aspose.slides.ISmartArtNode.isHidden() renvoie vrai si ce nœud est un nœud caché dans le modèle de données. Pour vérifier la propriété cachée de n'importe quel nœud de SmartArt. Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe `Presentation`.
- Ajoutez SmartArt RadialCycle.
- Ajoutez un nœud sur SmartArt.
- Vérifiez la propriété isHidden.
- Enregistrez la présentation en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Ajoutez SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.RADIAL_CYCLE)
    # Ajoutez un nœud sur SmartArt 
    node = smart.all_nodes.add_node()
    # Vérifiez la propriété isHidden
    if node.is_hidden:
        print("caché")
        # Faites des actions ou des notifications
    # Enregistrement de la présentation
    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Obtenir ou définir le type de graphique organisationnel**
Les méthodes com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) permettent d'obtenir ou de définir le type de graphique organisationnel associé au nœud actuel. Pour obtenir ou définir le type de graphique organisationnel. Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe `Presentation`.
- Ajoutez SmartArt sur la diapositive.
- Obtenez ou définissez le type de graphique organisationnel.
- Enregistrez la présentation en tant que fichier PPTX.
  Dans l'exemple ci-dessous, nous avons ajouté un connecteur entre deux formes.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # Ajoutez SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.ORGANIZATION_CHART)
    # Obtenez ou définissez le type de graphique organisationnel 
    smart.nodes[0].organization_chart_layout = art.OrganizationChartLayoutType.LEFT_HANGING
    # Enregistrement de la présentation
    presentation.save("OrganizeChartLayoutType_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Créer un graphique organisationnel d'images**
Aspose.Slides pour Python via .NET fournit une API simple pour créer des graphiques et des graphesOrganisation d'images de manière facile. Pour créer un graphique sur une diapositive :

1. Créez une instance de la classe `Presentation`.
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.PictureOrganizationChart).
1. Écrivez la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as pres:
    smartArt = pres.slides[0].shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    pres.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```