---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation en C++
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/cpp/presentation-view-properties/
keywords:
- propriétés d'affichage
- vue normale
- contenu du plan
- icônes du plan
- accrochage du séparateur vertical
- vue unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Découvrez les propriétés d'affichage d'Aspose.Slides pour C++ pour personnaliser les formats PPT, PPTX et ODP — ajustez la disposition, le niveau de zoom et les paramètres d'affichage."
---

{{% alert color="primary" %}} 

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Propriétés relatives au positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer son état de vue dans le fichier, de sorte que lors de la réouverture la vue soit dans le même état que lors de la dernière sauvegarde de la présentation.

La méthode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) a été ajoutée pour fournir l’accès aux propriétés de la vue normale de la présentation.  

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties) et leurs descendants, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950) ont été ajoutés.

{{% /alert %}} 

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** indique si l’application doit afficher des icônes lorsqu’elle présente le contenu du plan dans l’une des zones de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si le séparateur vertical doit se réduire à un état minimisé lorsque la zone latérale est suffisamment petite.

La propriété **PreferSingleView** indique si l’utilisateur préfère voir une zone de contenu unique en plein écran plutôt que la vue normale standard avec trois zones de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des zones de contenu dans toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** définissent l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, une barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** spécifient la dimension de la zone supérieure ou latérale de la diapositive en vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement à **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration d’INormalViewProperties**

Spécifie la dimension de la zone de la diapositive (largeur lorsqu’elle est un enfant de RestoredTop, hauteur lorsqu’elle est un enfant de RestoredLeft) de la vue normale, lorsque la zone a une taille restaurée variable (ni minimisée ni maximisée).  

La propriété **DimensionSize** indique la taille de la zone de la diapositive (largeur lorsqu’elle est un enfant de RestoredTop, hauteur lorsqu’elle est un enfant de RestoredLeft).  

La propriété **AutoAdjust** indique si la taille de la zone de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple ci‑dessous montre comment accéder aux propriétés **ViewProperties.NormalViewProperties** d’une présentation.  
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Restaurer les propriétés de vue de la présentation
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **Définir la valeur de zoom par défaut**

Aspose.Slides for C++ prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation afin que, lors de l’ouverture de la présentation, le zoom soit déjà appliqué. Cela peut être réalisé en définissant les [ViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) d’une présentation. Les propriétés de la vue de diapositive ainsi que [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) peuvent être définies par programme. Dans ce sujet, nous verrons, à l’aide d’un exemple, comment définir les propriétés de vue d’une présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)
2. Définissez les [Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) de vue de la présentation
3. Enregistrez la présentation en tant que fichier PPTX

Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue des notes.  
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Définition des propriétés de vue de la présentation
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valeur du zoom en pourcentage pour la vue diapositive
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valeur du zoom en pourcentage pour la vue notes 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les [paramètres de vue](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir des états de vue différents pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s’ouvrent de la même manière ?**

Oui. Parce que les [view properties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) sont stockées au niveau de la présentation, vous pouvez les incorporer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.