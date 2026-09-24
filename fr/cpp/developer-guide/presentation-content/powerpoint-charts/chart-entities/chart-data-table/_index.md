---
title: Personnaliser les tableaux de données des graphiques dans les présentations avec C++
linktitle: Tableau de données
type: docs
url: /fr/cpp/chart-data-table/
keywords:
- données de graphique
- tableau de données
- propriétés de police
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Personnalisez les polices, les bordures et les clés de légende du tableau de données d'un graphique dans les présentations PowerPoint à l’aide d'Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Aspose.Slides for C++ vous permet d'afficher le tableau de données d'un graphique et de personnaliser le format du texte, les bordures et les clés de légende. Cet article explique comment activer le tableau, formater son texte, contrôler chaque type de bordure et afficher ou masquer les clés de légende. Les exemples enregistrent les graphiques configurés dans des fichiers PPTX.

## **Définir les propriétés de police**

Pour afficher le tableau de données d'un graphique, passez `true` à [IChart::set_HasDataTable](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Utilisez [IChart::get_ChartDataTable](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/get_chartdatatable/) pour accéder au tableau et configurer le format du texte.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
1. Ajoutez un graphique à colonnes groupées à la première diapositive.
1. Activez le tableau de données du graphique.
1. Activez le texte en gras avec [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseportionformat/set_fontbold/) et passez `20` à [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseportionformat/set_fontheight/) pour un texte de 20 points.
1. Enregistrez la présentation modifiée.

L'exemple suivant nécessite `test.pptx` dans le répertoire de travail avec au moins une diapositive. Il ajoute un graphique avec des données par défaut à la position (50, 50), avec une largeur de 600 points et une hauteur de 400 points. Le fichier `output.pptx` enregistré contient le graphique avec son tableau de données activé et les paramètres de police spécifiés appliqués.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Personnaliser les bordures du tableau de données**

Activez le tableau avec [IChart::set_HasDataTable](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/set_hasdatatable/) et accédez‑y via [IChart::get_ChartDataTable](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/get_chartdatatable/). Vous pouvez contrôler trois types de bordures indépendamment :

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) contrôle les bordures horizontales des cellules.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) contrôle les bordures verticales des cellules.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) contrôle la bordure extérieure du tableau.

Passez `true` à chaque mutateur pour afficher ses bordures ou `false` pour les masquer. L'exemple suivant crée un graphique à colonnes groupées avec des données par défaut, affiche les bordures horizontales et la bordure extérieure, et masque les bordures verticales. Aucun fichier d’entrée n’est requis. La position et la taille du graphique sont spécifiées en points.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

La comparaison ci‑dessous utilise les mêmes données de graphique et le même réglage de clé de légende dans les quatre cas. En partant de toutes les bordures activées, chaque variante restante désactive une seule configuration de bordure. La variante en bas à gauche correspond aux réglages de bordure de l’exemple.

![Tableaux de données du graphique avec toutes les bordures activées, sans bordures horizontales, sans bordures verticales et sans bordure extérieure](data-table-borders.png)

## **Afficher ou masquer les clés de légende**

Les clés de légende sont de petits marqueurs colorés à côté des noms de séries dans le tableau de données. Elles aident les lecteurs à associer chaque ligne du tableau à une série du graphique. Passez `true` à [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) pour afficher ces marqueurs ou `false` pour les masquer.

La légende distincte du graphique est contrôlée par [IChart::set_HasLegend](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/set_haslegend/). Ces réglages sont indépendants : masquer la légende distincte ne masque pas les clés à l’intérieur du tableau de données, et masquer les clés du tableau ne masque pas la légende distincte.

L'exemple suivant crée un graphique avec des données par défaut, active son tableau de données et affiche les clés de légende à l’intérieur tout en masquant la légende distincte. Toutes les bordures du tableau sont explicitement activées. Aucune présentation d’entrée n’est requise. Pour masquer uniquement les clés du tableau, passez `false` à [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

La comparaison ci‑dessous montre le même tableau avec les clés de légende affichées et masquées. Toutes les bordures restent activées, et la légende distincte du graphique est masquée dans les deux cas.

![Tableaux de données du graphique avec les clés de légende affichées à gauche et masquées à droite](data-table-legend-keys.png)

## **FAQ**

**Puis-je afficher les clés de légende dans le tableau de données d'un graphique ?**

Oui. Passez `true` à [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) pour afficher les clés de légende ou `false` pour les masquer.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation vers PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique et son tableau de données affiché comme partie de la diapositive lors de l'exportation vers [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/fr/cpp/convert-powerpoint-to-html/) ou [images](/slides/fr/cpp/convert-powerpoint-to-png/).

**Puis-je travailler avec les tableaux de données dans les graphiques chargés à partir d'un modèle ?**

Oui. Pour un graphique chargé depuis une présentation ou un modèle existant, utilisez [IChart::get_HasDataTable](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/get_hasdatatable/) pour vérifier si son tableau de données est affiché et [IChart::set_HasDataTable](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/set_hasdatatable/) pour modifier sa visibilité.

**Comment puis‑je trouver les graphiques qui ont le tableau de données activé ?**

Parcourez les formes de chaque diapositive, identifiez les graphiques et vérifiez le résultat de [IChart::get_HasDataTable](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichart/get_hasdatatable/). Une valeur de `true` indique que le tableau de données est activé.