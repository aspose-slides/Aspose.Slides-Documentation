---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation en C++
linktitle: Propriétés de vue
type: docs
weight: 80
url: /fr/cpp/presentation-view-properties/
keywords:
- propriétés de vue
- vue normale
- contenu du plan
- icônes du plan
- ajustement du séparateur vertical
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
description: "Découvrez les propriétés d'affichage d'Aspose.Slides pour C++ afin de personnaliser les formats PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés concernent le positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que, lors d’une réouverture, la vue soit dans le même état que lors de la dernière sauvegarde de la présentation.

La méthode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) a été ajoutée pour fournir un accès aux propriétés de la vue normale d’une présentation.

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/inormalviewrestoredproperties/) ainsi que leurs descendants, l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/splitterbarstatetype/) ont été ajoutées.

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** indique si l’application doit afficher des icônes lorsqu’elle affiche le contenu du plan dans l’une des zones de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si le séparateur vertical doit se réduire à un état minimal lorsque la zone latérale est suffisamment petite.

La propriété **PreferSingleView** indique si l’utilisateur préfère voir une région de contenu unique en plein écran plutôt que la vue normale standard avec trois régions de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des régions de contenu sur tout l’écran.

Les propriétés **VerticalBarState** et **HorizontalBarState** spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, la barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** indiquent la taille de la zone supérieure ou latérale de la diapositive en mode vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement à **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration de INormalViewProperties**

Spécifie la taille de la région de la diapositive (largeur lorsqu’elle est un enfant de RestoredTop, hauteur lorsqu’elle est un enfant de RestoredLeft) de la vue normale, lorsque la région a une taille restaurée variable (ni minimisée ni maximisée).

La propriété **DimensionSize** indique la taille de la région de la diapositive (largeur lorsqu’elle est un enfant de restoredTop, hauteur lorsqu’elle est un enfant de restoredLeft).

La propriété **AutoAdjust** indique si la taille de la zone de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.

Un exemple ci‑dessous montre comment accéder aux propriétés **ViewProperties.NormalViewProperties** d’une présentation.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Restaure les propriétés d'affichage de la présentation
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Définir la valeur de zoom par défaut**

Aspose.Slides for C++ prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation, de sorte que le zoom soit déjà appliqué lors de l’ouverture de la présentation. Cela peut être fait en réglant les [ViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/) d’une présentation. Les propriétés de la vue diapositive ainsi que [get_NotesViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/get_notesviewproperties/) peuvent être définies par programme. Dans ce sujet, nous verrons à l’aide d’un exemple comment définir les propriétés de vue d’une présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/)
2. Définir les [Properties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/) de vue de la présentation
3. Enregistrer la présentation au format PPTX

Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Définir les propriétés de vue de la présentation
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valeur du zoom en pourcentage pour la vue diapositive
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valeur du zoom en pourcentage pour la vue notes 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Définir l’espacement de la grille**

Utilisez [Presentation::get_ViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_viewproperties/) pour accéder aux paramètres de vue au niveau de la présentation. Les méthodes [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iviewproperties/get_gridspacing/) et [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iviewproperties/set_gridspacing/) lisent ou modifient l’intervalle de la grille d’édition sous‑jacente. Ce paramètre s’applique à l’ensemble de la présentation, pas à une diapositive individuelle. L’espacement de la grille est indiqué en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, comme l’exige la documentation de l’API.

L’exemple suivant ouvre un fichier `demo.pptx` existant, affiche son espacement de grille actuel, définit un intervalle d’un quart de pouce et enregistre le résultat.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

La grille est différente des [drawing guides](/slides/fr/cpp/drawing-guides/). L’espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d’alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou supprimer des guides de dessin ne modifie pas l’espacement de la grille.

La grille et les guides de dessin sont tous deux des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans les PDF, images, SVG ou présentations. Le fait d’enregistrer l’espacement de la grille ne garantit pas qu’un éditeur affichera la grille : sa visibilité dépend également des préférences du visualiseur ou de l’éditeur.

## **Afficher ou masquer les commentaires à l’ouverture d’une présentation**

Utilisez [Presentation::get_ViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_viewproperties/) pour accéder aux paramètres de vue au niveau de la présentation. Utilisez [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iviewproperties/get_showcomments/) et [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iviewproperties/set_showcomments/) pour enregistrer une préférence indiquant si les commentaires doivent être affichés lorsque la présentation s’ouvre dans PowerPoint ou un autre éditeur compatible.

Ce paramètre ne contrôle que la préférence de vue stockée. Il n’ajoute, ne supprime, ne modifie ni ne résout les commentaires. Masquer les commentaires préserve leur contenu, leurs auteurs, leurs positions, leurs réponses et leurs statuts. Consultez [Presentation Comments](/slides/fr/cpp/presentation-comments/) pour les opérations qui modifient les commentaires eux‑mêmes.

L’exemple suivant nécessite un fichier `comments.pptx` contenant des commentaires. Il affiche la configuration actuelle de visibilité, demande que les commentaires soient masqués, puis enregistre un nouveau PPTX sans supprimer aucun commentaire. Il utilise également [IViewProperties::set_LastView](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iviewproperties/set_lastview/) avec [ViewType::SlideView](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewtype/) pour configurer la vue d’édition initiale ainsi que la visibilité des commentaires.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Ce paramètre ne détermine pas si les commentaires sont inclus dans les exportations PDF, HTML, image, notes ou fiches. Configurez séparément les options spécifiques à chaque type d’exportation.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après avoir rouvert la présentation ?**

Le fichier enregistre l’espacement de la grille, mais l’éditeur contrôle son affichage. Vérifiez les paramètres de visibilité de la grille de l’éditeur.

**La suppression des guides de dessin modifie‑t‑elle l’espacement de la grille ?**

Non. Les guides de dessin et l’espacement de la grille sont des réglages indépendants. Supprimer les guides laisse l’intervalle de la grille tel qu’il est stocké.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les [view settings](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_viewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir des états de vue différents pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent prendre en compte les préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Comme les [view properties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_viewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.