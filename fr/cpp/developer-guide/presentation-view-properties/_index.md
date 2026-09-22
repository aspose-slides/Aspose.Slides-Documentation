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
description: "Découvrez les propriétés de vue d'Aspose.Slides pour C++ afin de personnaliser les formats PPT, PPTX et ODP — ajustez les dispositions, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Propriétés relatives au positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que, à la réouverture, la vue soit dans le même état que lors du dernier enregistrement de la présentation.

La méthode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) a été ajoutée pour fournir l’accès aux propriétés de vue normale d’une présentation. 

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/inormalviewrestoredproperties/) et leurs descendants, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/splitterbarstatetype/) ont été ajoutés.

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** indique si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si la barre de séparation verticale doit se réduire à un état minimisé lorsque la zone latérale devient suffisamment petite.

La propriété **PreferSingleView** indique si l’utilisateur préfère voir une fenêtre unique contenant tout le contenu plutôt que la vue normale standard avec trois zones de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des zones de contenu dans toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** indiquent l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, une barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** indiquent la taille de la zone supérieure ou latérale de la diapositive en vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement à **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration de INormalViewProperties**

Indique la taille de la zone de diapositive (largeur lorsqu’elle est enfant de RestoredTop, hauteur lorsqu’elle est enfant de RestoredLeft) de la vue normale, lorsque la zone possède une taille restaurée variable (ni minimisée ni maximisée). 

La propriété **DimensionSize** indique la taille de la zone de diapositive (largeur lorsqu’elle est enfant de restoredTop, hauteur lorsqu’elle est enfant de restoredLeft).

La propriété **AutoAdjust** indique si la taille de la zone de contenu latérale doit se compenser lorsque la fenêtre contenant la vue est redimensionnée dans l’application.

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

// Restaurer les propriétés de vue de la présentation
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Définir la valeur de zoom par défaut**

Aspose.Slides for C++ prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation afin que, lors de l’ouverture de la présentation, le zoom soit déjà appliqué. Cela peut être réalisé en définissant les [ViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/) d’une présentation. Les propriétés de la vue de diapositive ainsi que [get_NotesViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/get_notesviewproperties/) peuvent être définies par programme. Dans ce sujet, nous verrons avec un exemple comment définir les propriétés de vue d’une présentation dans Aspose.Slides.

Pour définir les propriétés de vue, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/)
1. Définissez les [Properties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/) de vue de la présentation
1. Enregistrez la présentation sous forme de fichier PPTX

Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue des notes.

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
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valeur du zoom en pourcentage pour la vue des notes 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Définir l’espacement de la grille**

Utilisez [Presentation::get_ViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_viewproperties/) pour accéder aux paramètres de vue de l’ensemble de la présentation. Les méthodes [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iviewproperties/get_gridspacing/) et [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iviewproperties/set_gridspacing/) lisent ou modifient l’intervalle de la grille d’édition sous‑jacente. Ce paramètre s’applique à toute la présentation, pas à une diapositive individuelle. L’espacement de la grille est exprimé en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, comme l’exige la documentation de l’API.

L’exemple suivant ouvre un `demo.pptx` existant, affiche l’espacement actuel de la grille, définit un intervalle d’un quart de pouce, puis enregistre le résultat.

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

La grille diffère des [drawing guides](/slides/fr/cpp/drawing-guides/). L’espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d’alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou supprimer des guides de dessin ne modifie pas l’espacement de la grille.

La grille et les guides de dessin sont des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans les PDF, images, SVG ou diaporamas. Le stockage de l’espacement de la grille ne garantit pas qu’un éditeur affichera la grille : sa visibilité dépend également des préférences du visualiseur ou de l’éditeur.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après avoir rouvert la présentation ?**

Le fichier enregistre l’espacement de la grille, mais l’éditeur contrôle son affichage. Vérifiez les paramètres de visibilité de la grille dans l’éditeur.

**La suppression des guides de dessin modifie‑t‑elle l’espacement de la grille ?**

Non. Les guides de dessin et l’espacement de la grille sont des paramètres indépendants. La suppression des guides laisse l’intervalle de grille stocké inchangé.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les [paramètres de vue](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_viewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à tout le document à l’ouverture.

**Puis‑je pré‑définir différents états de vue pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Parce que les [view properties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_viewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.