---
title: Personnaliser les légendes de graphiques dans les présentations avec C++
linktitle: Légende de graphique
type: docs
url: /fr/cpp/chart-legend/
keywords:
- légende de graphique
- position de la légende
- taille de police
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides pour C++ afin d'optimiser les présentations PowerPoint grâce à un formatage de légende adapté."
---
## **Vue d'ensemble**

Aspose.Slides for C++ offre des options pour personnaliser les légendes de graphiques dans les présentations PowerPoint. Cet article montre comment positionner et dimensionner une légende, définir la taille de police pour l’ensemble de la légende, formater une entrée de légende individuelle, et masquer ou restaurer des entrées sélectionnées.

La FAQ couvre les comportements associés, notamment la réservation d’espace pour la légende, l’affichage d’étiquettes multilignes et l’héritage du formatage à partir du thème de la présentation.

## **Positionnement de la légende**

Utilisez les méthodes de la légende [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/) et [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) pour spécifier sa position et sa taille en fractions des dimensions du graphique.

Cet exemple crée une présentation et ajoute un graphique à colonnes groupées avec des données par défaut à la première diapositive. Diviser les décalages et dimensions souhaités de la légende par la largeur et la hauteur du graphique les convertit en valeurs relatives : la légende est décalée de 50 points depuis le coin supérieur gauche du graphique et dimensionnée à 100 × 100 points.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// Exprimez la position et la taille de la légende par rapport au graphique.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Définir la taille de police d'une légende**

Utilisez la méthode [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) de la légende pour accéder à son formatage de texte et [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) pour définir la taille de police en points.

Cet exemple crée un graphique avec des données par défaut et définit le texte de la légende à 20 points. Il désactive également les limites automatiques pour l’axe vertical et fixe sa plage de -5 à 10.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **Définir la taille de police d'une entrée de légende individuelle**

Utilisez la collection retournée par la méthode [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) de la légende pour accéder au formatage d’une entrée spécifique. Les indices des entrées sont base zéro, ainsi l’indice `1` correspond à la deuxième entrée.

Cet exemple crée un graphique à colonnes groupées dont les données par défaut comprennent au moins deux séries. Il formate la deuxième entrée de légende en gras, italique et texte bleu de 20 points.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **Masquer les entrées individuelles de la légende**

Pour exclure une série auxiliaire de la légende tout en conservant ses données visibles, appelez [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) avec `true` via [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). Cela masque uniquement l’entrée de légende sélectionnée ; cela ne supprime pas la série ni ses points de données. Appeler [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) avec `false`, en revanche, masque l’ensemble de la légende.

L’exemple ci‑dessous crée un graphique à colonnes groupées avec plusieurs séries en utilisant les données par défaut. Il masque l’entrée de légende de la seconde série (indice `1`) et enregistre la présentation. Il restaure ensuite l’entrée en appelant `set_Hide` avec `false` et enregistre une deuxième copie. Les colonnes restent visibles dans les deux fichiers.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// Restaurer la même entrée sans modifier les données du graphique.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

La comparaison ci‑après montre le même graphique avec toutes les entrées visibles et avec la deuxième entrée masquée. Les colonnes de la seconde série restent inchangées.

![Comparaison d’un graphique avec toutes les entrées de légende visibles et avec la série 2 masquée de la légende ; toutes les colonnes restent visibles.](hide-legend-entry.png)

Dans les graphiques à colonnes, barres et lignes, les entrées de légende identifient les séries. Pour les graphiques circulaires, elles identifient les points de données individuels (tranches), utilisez donc [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) sur la tranche sélectionnée. L’API documente cette méthode de point de données pour les types de graphiques `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` et `BarOfPie`. Ne supposez pas qu’elle s’applique aux graphiques en anneau, qui ne figurent pas dans cette liste.

## **FAQ**

**Puis‑je faire en sorte que le graphique réserve de l’espace pour la légende au lieu de la superposer ?**

Oui. Appelez [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) avec `false` pour réserver de l’espace pour la légende plutôt que de la laisser chevaucher la zone du tracé.

**Puis‑je créer des libellés de légende multilignes ?**

Oui. Les libellés longs peuvent se renvoyer à la ligne lorsque la largeur disponible est insuffisante. Vous pouvez également utiliser des caractères de saut de ligne dans les noms de séries pour demander des retours à la ligne.

**Comment faire en sorte que la légende suive le jeu de couleurs du thème de la présentation ?**

Laissez les couleurs, remplissages et polices de la légende non définis afin qu’elle puisse hériter du formatage du thème. Un formatage explicite surcharge les paramètres correspondants du thème.