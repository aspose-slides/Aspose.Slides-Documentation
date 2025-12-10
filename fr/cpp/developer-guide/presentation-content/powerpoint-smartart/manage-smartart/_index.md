---
title: "Gérer SmartArt dans les présentations PowerPoint avec C++"
linktitle: "Gérer SmartArt"
type: docs
weight: 10
url: /fr/cpp/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de mise en page
- propriété masquée
- organigramme
- organigramme d'image
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour C++ grâce à des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---

## **Obtenir le texte d'un objet SmartArt**
La propriété TextFrame a maintenant été ajoutée à l'interface ISmartArtShape et à la classe SmartArtShape respectivement. Cette propriété vous permet d’obtenir tout le texte d’un SmartArt, même si ce n’est pas uniquement le texte des nœuds. Le code d’exemple suivant vous aidera à récupérer le texte d’un nœud SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **Modifier le type de mise en page d'un objet SmartArt**
Afin de modifier le type de mise en page d’un SmartArt, suivez les étapes ci‑dessous :

- Créez une instance de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Obtenez la référence d’une diapositive en utilisant son Index.
- Ajoutez un SmartArt BasicBlockList.
- Modifiez LayoutType en BasicProcess.
- Enregistrez la présentation au format PPTX.  
Dans l’exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Vérifier la propriété Hidden d'un objet SmartArt**
Veuillez noter que la méthode com.aspose.slides.ISmartArtNode.isHidden() renvoie true si ce nœud est masqué dans le modèle de données. Pour vérifier la propriété hidden d’un nœud SmartArt, suivez les étapes ci‑dessous :

- Créez une instance de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Ajoutez un SmartArt RadialCycle.
- Ajoutez un nœud au SmartArt.
- Vérifiez la propriété isHidden.
- Enregistrez la présentation au format PPTX.  

Dans l’exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **Obtenir ou définir le type d’organigramme**
Les méthodes com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() et setOrganizationChartLayout(int) permettent d’obtenir ou de définir le type d’organigramme associé au nœud actuel. Pour obtenir ou définir ce type, suivez les étapes ci‑dessous :

- Créez une instance de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Ajoutez un SmartArt à la diapositive.
- Obtenez ou définissez le type d’organigramme.
- Enregistrez la présentation au format PPTX.  
Dans l’exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **Obtenir ou définir l’état d’un SmartArt**
Certains diagrammes SmartArt ne supportent pas l’inversion, par exemple : Vertical bullet list, Vertical Process, Descending Process, Funnel, Gear, Balance, Circle Relationship, Hexagon Cluster, Reverse List, Stacked Venn. Pour changer l’orientation d’un SmartArt, suivez les étapes ci‑dessous :

- Créez une instance de [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
- Ajoutez un SmartArt à la diapositive.
- Obtenez ou définissez l’état du diagramme SmartArt.
- Enregistrez la présentation au format PPTX.  
Dans l’exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Créer un organigramme d’image**
Aspose.Slides for C++ fournit une API simple pour créer des diagrammes PictureOrganization de façon aisée. Pour créer un diagramme sur une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez la référence d’une diapositive par son index.
1. Ajoutez un diagramme avec des données par défaut ainsi que le type souhaité (ChartType.PictureOrganizationChart).
1. Enregistrez la présentation modifiée au format PPTX.

Le code suivant permet de créer un diagramme.
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Le SmartArt prend‑il en charge le miroir/l’inversion pour les langues RTL ?**

Oui. La méthode [set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) inverse la direction du diagramme (LTR/RTL) si le type de SmartArt sélectionné prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/cpp/shape-manipulations/) via la collection de formes ([ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/)) ou [cloner la diapositive entière](/slides/fr/cpp/clone-slides/) contenant cette forme. Les deux approches conservent la taille, la position et le style.

**Comment rendre un SmartArt en image raster pour l’aperçu ou l’exportation Web ?**

[Rendez la diapositive](/slides/fr/cpp/convert-powerpoint-to-png/) (ou la présentation entière) au format PNG/JPEG grâce à l’API qui convertit les diapositives ou les présentations en images — le SmartArt sera dessiné comme partie de la diapositive.

**Comment sélectionner programmatique un SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Une pratique courante consiste à utiliser le [texte alternatif](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) (Alt Text) ou un [nom](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) et à rechercher la forme par cet attribut dans les [formes de la diapositive](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/), puis à vérifier le type pour confirmer qu’il s’agit bien d’un [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/). La documentation décrit les techniques typiques pour trouver et travailler avec les formes.