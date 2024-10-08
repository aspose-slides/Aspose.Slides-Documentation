---
title: Propriétés de la vue normale
type: docs
url: /fr/cpp/presentation-view-properties/
---

{{% alert color="primary" %}} 

La vue normale se compose de trois régions de contenu : la diapositive elle-même, une région de contenu latérale et une région de contenu inférieure. Les propriétés relatives au positionnement des différentes régions de contenu. Cette information permet à l'application de sauvegarder son état de vue dans le fichier, de sorte que lors de la réouverture, la vue soit dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

La méthode [**IViewProperties::get_NormalViewProperties()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) a été ajoutée pour fournir un accès aux propriétés de vue normale de la présentation.

Les interfaces [**INormalViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties) et [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties) et leurs descendants, l'énumération [**SplitterBarStateType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950) ont été ajoutés.

{{% /alert %}} 



## **À propos de INormalViewProperties** #

Représente les propriétés de vue normale.

La propriété **ShowOutlineIcons** spécifie si l'application doit afficher des icônes si elle affiche du contenu de plan dans l'une des régions de contenu du mode de vue normale.

La propriété **SnapVerticalSplitter** spécifie si le séparateur vertical doit s'enclencher dans un état minimisé lorsque la région latérale est suffisamment petite.

La propriété **PreferSingleView** spécifie si l'utilisateur préfère voir une région de contenu unique en pleine fenêtre plutôt que la vue normale standard avec trois régions de contenu. Si activé, l'application peut choisir d'afficher l'une des régions de contenu dans toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** spécifient l'état dans lequel la barre de séparateur horizontale ou verticale doit être affichée. Une barre de séparateur horizontale sépare la diapositive de la région de contenu en dessous de la diapositive, et une barre de séparateur verticale sépare la diapositive de la région de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored.**

Les propriétés **RestoredLeft** et **RestoredTop** spécifient la taille de la région de diapositive supérieure ou latérale de la vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée pour **VerticalBarState** et **HorizontalBarState** respectivement.



## **À propos de INormalViewRestoredProperties** #

Spécifie la taille de la région de diapositive (largeur lorsqu'elle est un enfant de RestoredTop, hauteur lorsqu'elle est un enfant de RestoredLeft) de la vue normale, lorsque la région est d'une taille restaurée variable (ni minimisée ni maximisée). 

La propriété **DimensionSize** spécifie la taille de la région de diapositive (largeur lorsqu'elle est un enfant de restoredTop, hauteur lorsqu'elle est un enfant de restoredLeft).

La propriété **AutoAdjust** spécifie si la taille de la région de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l'application.

Un exemple est donné ci-dessous montrant comment accéder aux propriétés **ViewProperties.NormalViewProperties** pour une présentation.

``` cpp
//Instancier un objet de présentation représentant un fichier de présentation
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **Définir la valeur de zoom par défaut**
Aspose.Slides pour C++ prend désormais en charge la définition de la valeur de zoom par défaut pour la présentation de sorte que lorsque la présentation est ouverte, le zoom est déjà défini. Cela peut être fait en définissant les [**ViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) d'une présentation. Les propriétés de vue de diapositive ainsi que [get_NotesViewProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) peuvent être définies par programmation. Dans ce sujet, nous allons voir avec un exemple comment définir les propriétés de vue de la présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Définir les propriétés de vue de la présentation.
1. Écrire la présentation sous forme de fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue des notes.

``` cpp
// Instancier un objet de Présentation représentant un fichier de présentation
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
// Définir les propriétés de vue de la présentation

presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// Valeur de zoom en pourcentages pour la vue de diapositive
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);
// Valeur de zoom en pourcentages pour la vue des notes 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```



## **Définir les propriétés de vue**
Pour définir les propriétés de vue, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe Presentation.
1. Définir les propriétés de vue de la présentation.
1. Écrire la présentation sous forme de fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue des notes.

``` cpp
// Instancier un objet de Présentation représentant un fichier de présentation
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Définir les propriétés de vue de la présentation
// Valeur de zoom en pourcentages pour la vue de diapositive
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// Valeur de zoom en pourcentages pour la vue des notes
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```