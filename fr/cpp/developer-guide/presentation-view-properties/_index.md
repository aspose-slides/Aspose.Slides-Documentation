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
- séparateur vertical à enclencher
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
description: "Utilisez Aspose.Slides pour C++ afin de configurer la disposition de la vue normale, le zoom des diapositives et des notes, l'espacement de la grille et la visibilité des commentaires dans les présentations PowerPoint."
---
## **Introduction**

Dans la vue normale de PowerPoint, la diapositive apparaît entre un volet latéral contenant les miniatures ou le plan et un volet de notes en dessous. Aspose.Slides for C++ expose les préférences d'édition enregistrées de la présentation via [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Celles‑ci comprennent la disposition des volets, les niveaux de zoom, l'espacement de la grille et la visibilité des commentaires.

## **À propos de INormalViewProperties**

Utilisez [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) pour accéder à l'interface [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) contrôle si des icônes apparaissent à côté des titres de diapositives dans le plan. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) permet au volet latéral de se réduire à son état minimisé lorsque l'utilisateur le rétrécit. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) indique une préférence pour l'affichage d'un seul volet dans la fenêtre complète.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) contrôle le séparateur entre le volet latéral et la diapositive. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) contrôle le séparateur au-dessus du volet de notes. Les deux acceptent une valeur [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` ou `Restored`.

## **À propos de la restauration d'INormalViewProperties**

Lorsque un séparateur est restauré, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) fournit la taille enregistrée du volet latéral et [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) fournit la taille enregistrée de la zone supérieure de la diapositive. Les deux exposent [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). Sa méthode [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) accepte un pourcentage de 0 à 100, et [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) contrôle si l'éditeur ajuste la taille lorsque la fenêtre est redimensionnée.

Cet exemple met à jour une présentation existante. Il restaure le séparateur horizontal, définit la taille de la zone supérieure de la diapositive exposée par [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) à 80 % avec l'ajustement automatique activé, et maximise le séparateur vertical. Il active également les icônes de plan avec [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) pour la vue plan.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Définir la valeur de zoom par défaut**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) et [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) stockent des paramètres de zoom indépendants pour l'éditeur. Ces paramètres n'affectent pas les dimensions des diapositives, la lecture du diaporama ou la résolution d'exportation des images.

Cet exemple ouvre une présentation existante et active le redimensionnement automatique avec [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) pour adapter la diapositive à la fenêtre d'édition. Pour la page de notes, il désactive le redimensionnement automatique et utilise [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) pour définir un zoom fixe de 80 %.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **Définir l'espacement de la grille**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) définit la distance entre les lignes de la grille d'édition dans l'ensemble de la présentation. Il prend une valeur positive en points, avec 72 points par pouce. Cet exemple affiche l'espacement actuel dans une présentation existante et enregistre une grille d'un quart de pouce en définissant l'intervalle à 18 points.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

La grille se répète à intervalle fixe. [Guides de dessin](/slides/fr/cpp/drawing-guides/) marquent des positions horizontales ou verticales individuelles. Les deux sont des aides à l'édition et n’apparaissent que dans les éditeurs qui les affichent. Les diaporamas et les exportations en PDF, images ou SVG les omettent.

## **Afficher ou masquer les commentaires lors de l'ouverture d'une présentation**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) enregistre une préférence que les éditeurs compatibles utilisent lors de l'ouverture de la présentation. Pour une présentation existante contenant des commentaires, cet exemple affiche le paramètre actuel et enregistre une copie avec les commentaires masqués. Il appelle également [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) avec [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) afin que la copie s'ouvre en mode diapositive.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Masquer les commentaires préserve leur texte, leurs auteurs, leurs positions, leurs réponses et leurs statuts. Pour modifier les commentaires eux‑mêmes, consultez [Commentaires de présentation](/slides/fr/cpp/presentation-comments/). Les paramètres d'exportation contrôlent si les commentaires apparaissent dans les PDF, HTML, images, notes ou supports.

## **FAQ**

**Pourquoi la grille est‑elle masquée lorsque je rouvre la présentation ?**

La présentation enregistre l'intervalle de la grille. Pour voir la grille, activez la visibilité de la grille dans l'éditeur.

**Le fait de supprimer les repères de dessin modifie‑t‑il l'espacement de la grille ?**

Non. Ajouter, déplacer ou supprimer un repère ne modifie pas l'intervalle de la grille.

**Les différentes sections d'une présentation peuvent‑elles avoir des paramètres de vue différents ?**

Non. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) s'applique à l'ensemble de la présentation.

**Puis‑je enregistrer des paramètres de vue différents pour différents utilisateurs ?**

Le fichier stocke un seul ensemble de propriétés de vue pour tous. Un éditeur peut également appliquer les préférences locales d'un utilisateur.

**Puis‑je enregistrer les paramètres de vue dans un modèle ?**

Oui. Les présentations créées à partir du modèle héritent de ses paramètres de vue enregistrés.