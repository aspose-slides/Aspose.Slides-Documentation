---
title: Gérer SmartArt
type: docs
weight: 10
url: /fr/cpp/manage-smartart/
---

## **Obtenir du texte à partir de SmartArt**
Maintenant, la propriété TextFrame a été ajoutée à l'interface ISmartArtShape et à la classe SmartArtShape respectivement. Cette propriété vous permet d'obtenir tout le texte à partir de SmartArt s'il n'a pas seulement du texte dans les nœuds. Le code d'exemple suivant vous aidera à obtenir du texte à partir d'un nœud SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **Changer le type de mise en page de tout SmartArt**
Pour changer le type de mise en page de SmartArt. Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter SmartArt BasicBlockList.
- Changer le LayoutType en BasicProcess.
- Écrire la présentation sous forme de fichier PPTX.
  Dans l'exemple donné ci-dessous, nous avons ajouté un connecteur entre deux formes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Vérifier la propriété cachée de SmartArt**
Veuillez noter que la méthode com.aspose.slides.ISmartArtNode.isHidden() retourne true si ce nœud est un nœud caché dans le modèle de données. Pour vérifier la propriété cachée de n'importe quel nœud de SmartArt. Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Ajouter SmartArt RadialCycle.
- Ajouter un nœud sur SmartArt.
- Vérifier la propriété isHidden.
- Écrire la présentation sous forme de fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté un connecteur entre deux formes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **Obtenir ou définir le type de diagramme organisationnel**
Les méthodes com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) permettent d'obtenir ou de définir le type de diagramme organisationnel associé au nœud actuel. Pour obtenir ou définir le type de diagramme organisationnel. Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Ajouter SmartArt sur la diapositive.
- Obtenir ou définir le type de diagramme organisationnel.
- Écrire la présentation sous forme de fichier PPTX.
  Dans l'exemple donné ci-dessous, nous avons ajouté un connecteur entre deux formes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **Obtenir ou définir l'état de SmartArt**
Certains diagrammes SmartArt ne prennent pas en charge l'inversion, par exemple ; liste à puces verticale, Processus vertical, Processus descendant, Entonnoir, Engrenage, Équilibre, Relation circulaire, Regroupement hexagonal, Liste inversée, Venn empilé. Pour changer l'orientation de SmartArt. Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
- Ajouter SmartArt sur la diapositive.
- Obtenir ou définir l'état du diagramme SmartArt.
- Écrire la présentation sous forme de fichier PPTX.
  Dans l'exemple donné ci-dessous, nous avons ajouté un connecteur entre deux formes.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **Créer un diagramme organisationnel d'image**
Aspose.Slides pour C++ fournit une API simple pour créer des diagrammes PictureOrganization de manière simple. Pour créer un diagramme sur une diapositive :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenir la référence d'une diapositive par son index.
1. Ajouter un diagramme avec des données par défaut ainsi que le type souhaité (ChartType.PictureOrganizationChart).
1. Écrire la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un diagramme.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```