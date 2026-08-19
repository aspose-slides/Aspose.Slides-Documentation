---
title: Appliquer des formules de feuille de calcul de graphique dans les présentations en C++
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/cpp/chart-worksheet-formulas/
keywords:
- tableur de graphique
- feuille de calcul du graphique
- formule de graphique
- formule de feuille de calcul
- formule de tableau
- cahier de donnees du graphique
- calcul de formule
- constante logique
- constante numerique
- constante chaine
- constante d'erreur
- operateur arithmetique
- operateur de comparaison
- style A1
- style R1C1
- fonction predefinie
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Appliquer des formules de type Excel dans les feuilles de calcul de graphiques Aspose.Slides pour C++, recalculer les valeurs et utiliser les resultats dans les graphiques PowerPoint."
---
## **Vue d'ensemble**

Les graphiques PowerPoint stockent généralement leurs données sources dans une feuille de calcul intégrée. Dans Aspose.Slides pour C++, vous pouvez accéder à cette feuille via le classeur de données du graphique, écrire des valeurs d’entrée, affecter des formules aux cellules, calculer les formules prises en charge et utiliser les cellules calculées comme données de graphique.

Cet article explique le flux complet des formules : créer un graphique, remplir sa feuille de calcul, affecter des formules de style A1 ou R1C1, les recalculer, lire les valeurs calculées, connecter ces cellules à une série de graphique et enregistrer la présentation. Il décrit également la syntaxe des formules prises en charge, le sous‑ensemble de fonctions intégré, les valeurs en cache, les formules non prises en charge et les erreurs spécifiques aux feuilles de calcul.

## **Feuilles de calcul et formules de graphiques**

Une feuille de calcul de graphique contient les catégories, les noms de séries et les valeurs utilisés par un graphique. Dans PowerPoint, vous pouvez inspecter la feuille en ouvrant l’éditeur de données du graphique :

![Graphique PowerPoint avec sa feuille de calcul intégrée ouverte, affichant les données de catégorie et de série](chart-worksheet-formulas_1.png)

Dans Aspose.Slides, la feuille est exposée via l’interface [IChartDataWorkbook](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdataworkbook/). Utilisez [IChartDataCell::set_Formula](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/set_formula/) pour les formules de style A1 et [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) pour les formules de style R1C1. Après avoir modifié les cellules d’entrée ou les formules, appelez [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) pour recalculer les formules prises en charge et mettre à jour les valeurs correspondantes.

Une cellule calculée expose toujours son résultat via [IChartDataCell::get_Value](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/get_value/). C’est important lorsque vous devez inspecter le résultat d’une formule dans le code ou utiliser la cellule comme point de données du graphique.

## **Créer un graphique et calculer les formules de la feuille**

L’exemple suivant montre un flux de travail complet. Il crée un graphique à colonnes groupées, efface les données d’exemple, écrit les valeurs de revenu et de dépense trimestriels, calcule le bénéfice avec des formules, lit les résultats, utilise les cellules calculées comme valeurs du graphique et enregistre la présentation.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

Les points de données du graphique font référence à `D2:D4`, de sorte que le graphique utilise les valeurs de profit calculées. Aucun appel de rafraîchissement de graphique séparé n’est nécessaire dans ce flux : recalculer d’abord le classeur, puis utiliser ou enregistrer les données du graphique qui pointent vers les cellules calculées.

## **Utiliser des formules de style A1**

La notation A1 identifie les colonnes par des lettres et les lignes par des chiffres. Affectez des expressions de style A1 via [IChartDataCell::set_Formula](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

Les formes de référence A1 courantes sont :

| Référence | Relatif | Absolu | Mixte |
|---|---|---|---|
| Cellule | `A2` | `$A$2` | `A$2`, `$A2` |
| Ligne | `2:2` | `$2:$2` | — |
| Colonne | `A:A` | `$A:$A` | — |
| Plage | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Les références relatives peuvent changer lorsqu’une formule est déplacée ou copiée par une application de feuille de calcul. Les références absolues maintiennent les deux coordonnées fixes, tandis que les références mixtes ne fixent qu’une ligne ou une colonne.

## **Utiliser des formules de style R1C1**

La notation R1C1 identifie les lignes et les colonnes numériquement. Les références relatives utilisent des décalages entre crochets. Affectez cette syntaxe via [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

Les formes de référence R1C1 courantes sont :

| Référence | Relatif | Absolu | Mixte |
|---|---|---|---|
| Cellule | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Ligne | `R[2]` | `R2` | — |
| Colonne | `C[3]` | `C3` | — |
| Plage | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Par exemple, dans la cellule `D2`, `RC[-2]` désigne la cellule de la même ligne deux colonnes à gauche (`B2`).

## **Constantes et opérateurs de formule**

L’évaluateur de formules intégré prend en charge les valeurs logiques, les littéraux numériques, les chaînes, les valeurs d’erreur de feuille de calcul, les opérateurs arithmétiques et les opérateurs de comparaison.

### **Constantes et littéraux**

| Type | Exemples | Remarques |
|---|---|---|
| Logique | `TRUE`, `FALSE` | Peut être utilisé directement dans des expressions logiques telles que `A2=TRUE`. |
| Numérique | `1`, `0.5`, `.3`, `1E-2` | La notation décimale et scientifique sont prises en charge. |
| Chaîne | `"abc"`, `"2/3/2020 12:00"` | Les littéraux texte sont entourés de guillemets doubles dans la formule. |
| Résultat d’erreur | `#DIV/0!`, `#N/A`, `#REF!` | Une formule valide peut évaluer à une valeur d’erreur de feuille de calcul plutôt qu’à un résultat normal. |

Cet exemple utilise plusieurs types de constantes :

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Faux
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **Opérateurs arithmétiques**

| Opérateur | Signification | Exemple |
|---|---|---|
| `+` | Addition ou signe plus unaire | `2+3` |
| `-` | Soustraction ou négation | `2-3`, `-3` |
| `*` | Multiplication | `2*3` |
| `/` | Division | `2/3` |
| `%` | Pourcentage | `30%` |
| `^` | Exponentiation | `2^3` |

Utilisez des parenthèses pour rendre explicite l’ordre d’évaluation, par exemple `(A2+B2)*C2`.

### **Opérateurs de comparaison**

Les expressions de comparaison renvoient des valeurs logiques.

| Opérateur | Signification | Exemple |
|---|---|---|
| `=` | Égal à | `A2=3` |
| `<>` | Différent de | `A2<>3` |
| `>` | Supérieur à | `A2>3` |
| `>=` | Supérieur ou égal à | `A2>=3` |
| `<` | Inférieur à | `A2<3` |
| `<=` | Inférieur ou égal à | `A2<=3` |

## **Fonctions prédéfinies prises en charge**

Aspose.Slides comprend un évaluateur de formules intégré pour les feuilles de calcul de graphiques, mais ce n’est pas un moteur complet de calcul Excel. L’ensemble de fonctions documenté se limite à celles-ci. Ne supposez pas qu’une fonction Excel arbitraire puisse être recalculée par [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Fonction | But ou forme prise en charge | Exemple |
|---|---|---|
| `ABS` | Valeur absolue | `ABS(A2)` |
| `AVERAGE` | Moyenne arithmétique | `AVERAGE(B2:B5)` |
| `CEILING` | Arrondir un nombre vers le haut à un multiple | `CEILING(A2,5)` |
| `CHOOSE` | Sélectionner une valeur par index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Concaténer des valeurs texte | `CONCAT(A2,B2)` |
| `CONCATENATE` | Concaténer des valeurs texte | `CONCATENATE(A2," ",B2)` |
| `DATE` | Créer une valeur date avec le système 1900 | `DATE(2026,8,19)` |
| `DAYS` | Retourner le nombre de jours entre deux dates | `DAYS(B2,A2)` |
| `FIND` | Rechercher une valeur texte dans une autre | `FIND("-",A2)` |
| `FINDB` | Recherche texte orientée octet | `FINDB("a",A2)` |
| `IF` | Résultat conditionnel | `IF(A2>0,A2,0)` |
| `INDEX` | Forme de référence | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forme vectorielle | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forme vectorielle | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valeur maximale | `MAX(B2:B5)` |
| `SUM` | Somme des valeurs | `SUM(B2:B5)` |
| `VLOOKUP` | Recherche verticale | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Les restrictions indiquées dans le tableau sont importantes : `INDEX` est documenté sous forme de référence, tandis que `LOOKUP` et `MATCH` sont documentés sous forme vectorielle. `DATE` utilise le système de date 1900. Les fonctionnalités et fonctions non listées ici doivent être considérées comme non prises en charge par l’évaluateur de formules d’Aspose.Slides, sauf indication contraire.

## **Recalcul et valeurs en cache**

Les fichiers de feuille de calcul stockent généralement à la fois une formule et sa dernière valeur calculée. Aspose.Slides peut donc lire une valeur en cache via [IChartDataCell::get_Value](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/get_value/) lorsqu’une présentation est chargée et que les données de graphique pertinentes n’ont pas été modifiées.

Après avoir modifié des cellules d’entrée ou des formules, ne vous fiez pas à un ancien résultat en cache. Appelez [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) avant de lire les valeurs calculées ou d’enregistrer les données du graphique qui en dépendent.

Pour les formules hors du sous‑ensemble pris en charge, Aspose.Slides peut être incapable d’analyser la formule ou d’établir ses dépendances. Si le classeur a été modifié, la valeur en cache précédente ne peut plus être considérée comme fiable. Dans cette situation, la lecture de la valeur d’une cellule contenant des données non prises en charge peut lever [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Si votre graphique dépend de fonctions Excel qu’Aspose.Slides n’évalue pas, calculez ces formules avec un moteur de feuille de calcul qui les supporte et écrivez les valeurs résultantes dans le classeur du graphique. Ne remplacez pas les formules non prises en charge par des valeurs supposées.

## **Gestion des erreurs de formule**

Il existe deux types de problèmes à distinguer.

Une formule peut être valide mais produire un résultat d’erreur de feuille de calcul tel que `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ou `#VALUE!`. Dans ce cas, le jeton d’erreur est un résultat de cellule et peut être renvoyé via [IChartDataCell::get_Value](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Une formule peut également échouer lors de l’analyse, de la référence, de la dépendance ou du niveau de données prises en charge. Aspose.Slides fournit des exceptions spécifiques aux feuilles de calcul pour ces cas : [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fr/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fr/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) et [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Lorsque les formules proviennent de modèles ou d’entrées utilisateur, gérez ces exceptions autour du recalcul et de l’accès aux valeurs :

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Gérer une formule invalide.
}
catch (CellInvalidReferenceException&)
{
    // Gérer une référence de cellule invalide.
}
catch (CellCircularReferenceException&)
{
    // Gérer une référence circulaire.
}
catch (CellUnsupportedDataException&)
{
    // Gérer des données de feuille de calcul non prises en charge.
}
```

## **Limitations pratiques**

La prise en charge des formules dans les feuilles de calcul de graphiques est destinée à un sous‑ensemble défini de calculs de feuille, pas à une compatibilité totale avec Excel. Gardez ces contraintes à l’esprit lors de la conception d’un flux de travail de reporting :

- Utilisez uniquement les constantes, opérateurs, références et fonctions documentés lorsque vous avez besoin qu’Aspose.Slides recalcule les formules.
- Recalculez après avoir modifié les cellules dont les résultats de formule dépendent.
- Considérez les valeurs en cache des présentations chargées comme des instantanés, pas comme un remplacement du recalcul après modification.
- Testez les formules des modèles existants avant de vous fier à leurs valeurs calculées, surtout si elles utilisent des fonctions hors de la liste documentée.
- Pour les formules qui nécessitent un moteur complet de calcul de feuille, calculez‑les à l’extérieur puis mettez à jour le classeur du graphique avec les valeurs résultantes.

## **FAQ**

**Quelle est la différence entre `set_Formula` et `set_R1C1Formula` ?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/set_formula/) stocke une expression de style A1 telle que `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) stocke une expression de style R1C1 telle que `RC[-2]-RC[-1]`. Utilisez la notation qui correspond le mieux à votre façon de générer ou de copier les formules.

**Dois‑je lire la cellule elle‑même ou sa valeur après le calcul ?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) renvoie un `IChartDataCell`. Pour obtenir le résultat calculé, lisez la valeur de cette cellule via [IChartDataCell::get_Value](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatacell/get_value/) après le recalcul.

**Quand dois‑je appeler `CalculateFormulas` ?**

Appelez [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) après avoir modifié des valeurs d’entrée ou des formules et avant de dépendre des résultats calculés. Cela met à jour les valeurs des formules que l’évaluateur intégré prend en charge.

**Aspose.Slides prend‑il en charge toutes les fonctions Excel ?**

Non. L’évaluateur intégré ne prend en charge qu’un sous‑ensemble documenté de fonctions. Les fonctions en dehors de ce sous‑ensemble ne doivent pas être supposées être recalculées correctement. Si une compatibilité totale avec les formules Excel est requise, effectuez le calcul avec un moteur de feuille approprié et écrivez les valeurs finales dans le classeur du graphique.

**Que se passe‑t‑il si une présentation chargée contient une formule non prise en charge ?**

Si les données du graphique n’ont pas changé, le classeur peut encore contenir une valeur en cache précédemment calculée. Après modification des données connexes, cette valeur en cache peut ne plus être valide. L’accès à une cellule dont la formule ne peut pas être gérée peut lever [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Les valeurs d’erreur de formule sont‑elles identiques aux exceptions C++ ?**

Non. Un résultat tel que `#DIV/0!` est une valeur de feuille de calcul produite par un calcul valide. Les exceptions telles que [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) ou [CellCircularReferenceException](https://reference.aspose.com/slides/fr/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) indiquent que la formule ne peut pas être traitée normalement.

**Un graphique se met‑il à jour automatiquement lorsqu’une cellule de formule change ?**

Une série de graphique peut référencer des cellules du classeur. Recalculez d’abord le classeur, puis enregistrez ou rendez la présentation. Si les points de données du graphique référencent les cellules calculées, le graphique utilise ces valeurs de cellule mises à jour ; aucune méthode de rafraîchissement de graphique distincte n’est requise pour ce flux.

**Les graphiques peuvent‑ils utiliser un classeur Excel externe ?**

Oui, les données du graphique peuvent être configurées pour utiliser un classeur externe via l’API de données du graphique. Cependant, le flux de calcul des formules décrit dans cet article concerne le classeur de données du graphique et le sous‑ensemble de formules évalué par Aspose.Slides. Ne supposez pas que [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) fournit un recalcul complet des formules arbitraires dans un fichier XLSX externe.

**Puis‑je utiliser des formules qui référencent une autre feuille ou un autre classeur ?**

Des références de style Excel peuvent exister dans les classeurs de graphiques, mais l’évaluation des formules est limitée par le parseur et le jeu de fonctions pris en charge. Si une référence inter‑feuille ou externe est essentielle, validez la formule exacte avec votre version cible d’Aspose.Slides. Pour les flux nécessitant une large compatibilité des références Excel, calculez le classeur à l’extérieur et écrivez les valeurs résolues dans les données du graphique.

**Les chaînes de formule doivent‑elles commencer par `=` ?**

Les exemples d’API Aspose.Slides assignent des expressions telles que `B2-C2` ou `SUM(B2:B5)` sans le signe `=` initial. Utiliser cette forme maintient les formules générées cohérentes avec les exemples d’API documentés.