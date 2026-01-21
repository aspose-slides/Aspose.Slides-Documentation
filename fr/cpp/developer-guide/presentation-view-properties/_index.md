---
title: Récupérer et mettre à jour les propriétés de vue de la présentation en C++
linktitle: Propriétés de vue
type: docs
weight: 80
url: /fr/cpp/presentation-view-properties/
keywords:
- propriétés de vue
- vue normale
- contenu du plan
- icônes du plan
- accrochage du séparateur vertical
- vue unique
- état de la barre
- taille de dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez les propriétés de vue d'Aspose.Slides pour C++ afin de personnaliser les formats PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---

{{% alert color="primary" %}} 

La vue normale se compose de trois régions de contenu : la diapositive elle‑même, une région de contenu latérale et une région de contenu inférieure. Propriétés relatives au positionnement des différentes régions de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que, lors de la réouverture, la vue soit dans le même état que lors de la dernière sauvegarde de la présentation.

Méthode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation. 

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/) ainsi que leurs descendants, l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) ont été ajoutés.

{{% /alert %}} 

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** indique si l’application doit afficher les icônes lors de l’affichage du contenu du plan dans l’une des régions de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si le séparateur vertical doit se réduire à un état minimisé lorsque la région latérale est suffisamment petite.

La propriété **PreferSingleView** indique si l’utilisateur préfère voir une région de contenu plein écran plutôt que la vue normale standard avec trois régions de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des régions de contenu dans toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** indiquent l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la région de contenu située sous la diapositive, tandis qu’une barre de séparation verticale sépare la diapositive de la région de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** spécifient la taille de la région de diapositive supérieure ou latérale de la vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement aux propriétés **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration de INormalViewProperties**

Spécifie la dimension de la région de diapositive (largeur lorsqu’elle est enfant de RestoredTop, hauteur lorsqu’elle est enfant de RestoredLeft) de la vue normale, lorsque la région possède une taille restaurée variable (ni minimisée ni maximisée). 

La propriété **DimensionSize** indique la taille de la région de diapositive (largeur lorsqu’elle est enfant de restoredTop, hauteur lorsqu’elle est enfant de restoredLeft).

La propriété **AutoAdjust** indique si la taille de la région de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.

Un exemple ci‑dessous montre comment accéder aux propriétés **ViewProperties.NormalViewProperties** d’une présentation.
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Rétablir les propriétés de vue de la présentation
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **Définir la valeur de zoom par défaut**

Aspose.Slides for C++ prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation de sorte que, lorsqu’elle est ouverte, le zoom soit déjà appliqué. Cela peut être réalisé en définissant les [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) d’une présentation. Les propriétés de la vue de diapositive ainsi que [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_notesviewproperties/) peuvent être définies par programme. Dans ce sujet, nous verrons à l’aide d’un exemple comment définir les propriétés de vue d’une présentation dans Aspose.Slides.

Pour définir les propriétés de la vue, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
1. Définissez les [Properties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) de vue de la présentation
1. Enregistrez la présentation sous forme de fichier PPTX

Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Définir les propriétés de vue de la présentation
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valeur du zoom en pourcentage pour la vue diapositive
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valeur du zoom en pourcentage pour la vue notes 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les [view settings](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à tout le document lors de son ouverture.

**Puis‑je pré‑définir des états de vue différents pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent respecter les préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.

**Puis‑je préparer un modèle avec des View Properties pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Comme les [view properties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.