---
title: Appliquer les formules de feuille de calcul de graphique dans les présentations en .NET
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/net/chart-worksheet-formulas/
keywords:
- feuille de calcul de graphique
- feuille de calcul du graphique
- formule de graphique
- formule de feuille de calcul
- formule de feuille de calcul
- classeur de données du graphique
- calcul de formule
- culture préférée
- formule spécifique à la culture
- DBCS
- constante logique
- constante numérique
- constante de chaîne
- constante d'erreur
- opérateur arithmétique
- opérateur de comparaison
- style A1
- style R1C1
- fonction prédéfinie
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Appliquer des formules de style Excel dans les feuilles de calcul de graphiques Aspose.Slides pour .NET, recalculer les valeurs et utiliser les résultats dans les graphiques PowerPoint."
---
## **Vue d'ensemble**

Les graphiques PowerPoint stockent généralement leurs données source dans une feuille de calcul intégrée. Dans Aspose.Slides for .NET, vous pouvez accéder à cette feuille via le classeur de données du graphique, écrire des valeurs d’entrée, assigner des formules aux cellules, calculer les formules prises en charge et utiliser les cellules calculées comme données du graphique.

Cet article explique le flux complet des formules : créer un graphique, remplir sa feuille de calcul, assigner des formules au format A1 ou R1C1, les recalculer, lire les valeurs calculées, connecter ces cellules à une série de graphique et enregistrer la présentation. Il décrit également la syntaxe des formules prises en charge, le sous‑ensemble de fonctions intégrées, les valeurs en cache, les formules non prises en charge et les erreurs spécifiques aux feuilles de calcul.

## **Feuilles de calcul de graphiques et formules**

Une feuille de calcul de graphique contient les catégories, les noms de séries et les valeurs utilisées par un graphique. Dans PowerPoint, vous pouvez inspecter la feuille en ouvrant l’éditeur de données du graphique :

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Dans Aspose.Slides, la feuille est exposée via le [chart data workbook](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/). Utilisez la propriété [Formula](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatacell/formula/) pour les formules au format A1 et la propriété [R1C1Formula](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatacell/r1c1formula/) pour les formules au format R1C1. Après avoir modifié des cellules d’entrée ou des formules, appelez [CalculateFormulas](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) pour recalculer les formules prises en charge et mettre à jour les valeurs correspondantes.

Une cellule calculée expose toujours son résultat via la propriété [Value](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatacell/value/). C’est important lorsque vous devez inspecter le résultat d’une formule dans le code ou utiliser la cellule comme point de donnée du graphique.

## **Créer un graphique et calculer les formules de la feuille**

L’exemple suivant montre un flux de travail complet. Il crée un graphique à colonnes groupées, efface les données d’exemple, écrit les valeurs de revenus et de dépenses trimestrielles, calcule le profit avec des formules, lit les résultats, utilise les cellules calculées comme valeurs du graphique et enregistre la présentation.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

Les points de données du graphique font référence à `D2:D4`, de sorte que le graphique utilise les valeurs de profit calculées. Il n’y a pas d’appel de rafraîchissement du graphique séparé dans ce flux : recalculez d’abord le classeur, puis utilisez ou enregistrez les données du graphique qui pointent vers les cellules calculées.

## **Utiliser des formules au format A1**

La notation A1 identifie les colonnes par des lettres et les lignes par des chiffres. Assignez des expressions au format A1 via [IChartDataCell.Formula](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatacell/formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

Les formes de référence A1 courantes sont :

| Référence | Relative | Absolue | Mixte |
|---|---|---|---|
| Cellule | `A2` | `$A$2` | `A$2`, `$A2` |
| Ligne | `2:2` | `$2:$2` | — |
| Colonne | `A:A` | `$A:$A` | — |
| Plage | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Les références relatives peuvent changer lorsqu’une formule est déplacée ou copiée par une application de feuille de calcul. Les références absolues maintiennent les deux coordonnées fixes, tandis que les références mixtes ne fixent qu’une ligne ou une colonne.

## **Utiliser des formules au format R1C1**

La notation R1C1 identifie à la fois les lignes et les colonnes numériquement. Les références relatives utilisent des décalages entre crochets. Assignez cette syntaxe via [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

Les formes de référence R1C1 courantes sont :

| Référence | Relative | Absolue | Mixte |
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
| Logique | `TRUE`, `FALSE` | Peut être utilisé directement dans des expressions logiques comme `A2=TRUE`. |
| Numérique | `1`, `0.5`, `.3`, `1E-2` | La notation décimale et scientifique sont prises en charge. |
| Chaîne | `"abc"`, `"2/3/2020 12:00"` | Les littéraux de texte sont entourés de guillemets doubles dans la formule. |
| Résultat d’erreur | `#DIV/0!`, `#N/A`, `#REF!` | Une formule valide peut s’évaluer à une valeur d’erreur de feuille de calcul au lieu d’un résultat normal. |

Cet exemple utilise plusieurs types de constantes :

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // Faux
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Opérateurs arithmétiques**

| Opérateur | Signification | Exemple |
|---|---|---|
| `+` | Addition ou plus unaire | `2+3` |
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
| `=` | Egal à | `A2=3` |
| `<>` | Différent de | `A2<>3` |
| `>` | Supérieur à | `A2>3` |
| `>=` | Supérieur ou égal à | `A2>=3` |
| `<` | Inférieur à | `A2<3` |
| `<=` | Inférieur ou égal à | `A2<=3` |

## **Fonctions prédéfinies prises en charge**

Aspose.Slides inclut un évaluateur de formules intégré pour les feuilles de calcul de graphiques, mais ce n’est pas un moteur complet de calcul Excel. L’ensemble de fonctions documenté est limité aux fonctions ci‑dessous. Ne supposez pas qu’une fonction Excel quelconque puisse être recalculée par [CalculateFormulas](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Fonction | Objectif ou forme prise en charge | Exemple |
|---|---|---|
| `ABS` | Valeur absolue | `ABS(A2)` |
| `AVERAGE` | Moyenne arithmétique | `AVERAGE(B2:B5)` |
| `CEILING` | Arrondir un nombre à la hausse à un multiple | `CEILING(A2,5)` |
| `CHOOSE` | Sélectionner une valeur par indice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Concaténer des valeurs texte | `CONCAT(A2,B2)` |
| `CONCATENATE` | Concaténer des valeurs texte | `CONCATENATE(A2," ",B2)` |
| `DATE` | Créer une valeur date avec le système de dates 1900 | `DATE(2026,8,19)` |
| `DAYS` | Retourner le nombre de jours entre deux dates | `DAYS(B2,A2)` |
| `FIND` | Rechercher une chaîne dans une autre | `FIND("-",A2)` |
| `FINDB` | Recherche de texte orientée octet | `FINDB("a",A2)` |
| `IF` | Résultat conditionnel | `IF(A2>0,A2,0)` |
| `INDEX` | Forme de référence | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forme vecteur | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forme vecteur | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valeur maximale | `MAX(B2:B5)` |
| `SUM` | Somme des valeurs | `SUM(B2:B5)` |
| `VLOOKUP` | Recherche verticale | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Les restrictions indiquées dans le tableau sont importantes : `INDEX` est documenté sous forme de référence, tandis que `LOOKUP` et `MATCH` le sont sous forme vecteur. `DATE` utilise le système de dates 1900. Les fonctionnalités et fonctions non listées ici doivent être considérées comme non prises en charge par l’évaluateur de formules Aspose.Slides, sauf indication contraire.

## **Calculer les formules avec une culture préférée**

Certaines fonctions du classeur de graphique interprètent le texte selon des règles spécifiques à la culture. Cela est particulièrement important pour les fonctions destinées aux langues utilisant des jeux de caractères à double octet (DBCS). Pour calculer correctement ces formules, créez un [LoadOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/), définissez [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/fr/net/aspose.slides/ispreadsheetoptions/preferredculture/) via [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/spreadsheetoptions/), puis chargez la présentation.

L’exemple suivant sélectionne la culture japonaise, ouvre une présentation avec les options de chargement configurées et appelle [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) pour chaque classeur de graphique :

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

La culture préférée fait partie de la configuration de chargement de la présentation, il faut donc la spécifier avant de créer l’instance de [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). Utilisez la culture attendue par les formules du classeur ; par exemple, utilisez `ja-JP` pour les formules qui doivent suivre les règles de calcul DBCS japonaises.

## **Recalcul et valeurs en cache**

Les fichiers de feuille de calcul stockent généralement à la fois une formule et sa dernière valeur calculée. Aspose.Slides peut donc lire une valeur en cache depuis [IChartDataCell.Value](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatacell/value/) lorsqu’une présentation est chargée et que les données du graphique concernées n’ont pas été modifiées.

Après avoir modifié des cellules d’entrée ou des formules, ne comptez pas sur un résultat en cache ancien. Appelez [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) avant de lire les valeurs calculées ou d’enregistrer des données de graphique qui en dépendent.

Pour les formules hors du sous‑ensemble pris en charge, Aspose.Slides peut être incapable d’analyser la formule ou d’établir ses dépendances. Si le classeur a été modifié, la valeur en cache précédente ne peut plus être considérée fiable. Dans ce cas, la lecture de la valeur d’une cellule contenant des données non prises en charge peut lever [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Si votre graphique dépend de fonctions Excel que Aspose.Slides n’évalue pas, calculez ces formules avec un moteur de feuille de calcul qui les prend en charge et écrivez les valeurs résultantes dans le classeur du graphique. Ne remplacez pas les formules non prises en charge par des valeurs devinées.

## **Gérer les erreurs de formule**

Il existe deux types de problèmes différents à distinguer.

Une formule peut être valide mais produire un résultat d’erreur de feuille de calcul tel que `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ou `#VALUE!`. Dans ce cas, le jeton d’erreur est le résultat d’une cellule et peut être renvoyé via `Value`.

Une formule peut également échouer au niveau de l’analyse, de la référence, de la dépendance ou des données prises en charge. Aspose.Slides fournit des exceptions spécifiques aux feuilles de calcul pour ces cas : [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fr/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fr/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), et [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Lorsque les formules proviennent de modèles ou d’entrées utilisateur, gérez ces exceptions autour du recalcul et de l’accès aux valeurs :

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Limites pratiques**

Le support des formules dans les feuilles de calcul de graphiques est destiné à un sous‑ensemble défini de calculs de feuille, pas à une compatibilité Excel complète. Gardez ces contraintes à l’esprit lors de la conception d’un flux de travail de reporting :

- Utilisez uniquement les constantes, opérateurs, références et fonctions documentés lorsque vous avez besoin qu’Aspose.Slides recalcule les formules.
- Recalculez après avoir modifié les cellules dont les résultats de formules dépendent.
- Considérez les valeurs en cache provenant de présentations chargées comme des instantanés, pas comme un remplacement du recalcul après modification.
- Testez les formules provenant de modèles existants avant de vous fier à leurs valeurs calculées, surtout si elles utilisent des fonctions hors de la liste documentée.
- Pour les formules nécessitant un moteur complet de calcul de feuille, calculez‑les en externe puis mettez à jour le classeur du graphique avec les valeurs résultantes.

## **FAQ**

**Quelle est la différence entre `Formula` et `R1C1Formula` ?**

[Formula](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatacell/formula/) stocke une expression au format A1 telle que `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatacell/r1c1formula/) stocke une expression au format R1C1 telle que `RC[-2]-RC[-1]`. Utilisez la notation qui correspond le mieux à la façon dont vous générez ou copiez les formules.

**Dois‑je lire la cellule elle‑même ou sa valeur après le calcul ?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/getcell/) renvoie un `IChartDataCell`. Pour obtenir le résultat calculé, lisez la propriété [Value](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdatacell/value/) de cette cellule après le recalcul.

**Quand devrais‑je appeler `CalculateFormulas` ?**

Appelez [CalculateFormulas](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) après avoir modifié des valeurs d’entrée ou des formules et avant de dépendre des résultats calculés. Cela met à jour les valeurs des formules prises en charge par l’évaluateur intégré.

**Aspose.Slides prend‑il en charge toutes les fonctions Excel ?**

Non. L’évaluateur intégré prend en charge un sous‑ensemble documenté de fonctions. Les fonctions en dehors de ce sous‑ensemble ne doivent pas être supposées se recalculer correctement. Si une compatibilité totale des formules Excel est requise, effectuez le calcul avec un moteur de feuille de calcul approprié et écrivez les valeurs finales dans le classeur du graphique.

**Que se passe‑t‑il si une présentation chargée contient une formule non prise en charge ?**

Si les données du graphique n’ont pas changé, le classeur peut encore contenir une valeur en cache précédemment calculée. Après modification des données associées, cette valeur en cache peut ne plus être valide. L’accès à une cellule dont la formule ne peut pas être traitée peut lever [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Les valeurs d’erreur de formule sont‑elles identiques aux exceptions .NET ?**

Non. Un résultat tel que `#DIV/0!` est une valeur de feuille de calcul produite par un calcul valide. Les exceptions comme [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) ou [CellCircularReferenceException](https://reference.aspose.com/slides/fr/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indiquent que la formule ne peut pas être traitée normalement.

**Un graphique se met‑il à jour automatiquement lorsqu’une cellule de formule change ?**

Une série de graphique peut référencer des cellules de classeur. Recalculez d’abord le classeur, puis enregistrez ou rendez la présentation. Si les points de données du graphique référencent les cellules calculées, le graphique utilise ces valeurs mises à jour ; aucune méthode de rafraîchissement du graphique séparée n’est requise pour ce flux.

**Les graphiques peuvent‑ils utiliser un classeur Excel externe ?**

Oui, les données du graphique peuvent être configurées pour utiliser un classeur externe via l’API de données du graphique. Cependant, le flux de calcul de formules décrit dans cet article concerne le classeur de données du graphique et le sous‑ensemble de formules évalué par Aspose.Slides. Ne supposez pas que [CalculateFormulas](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) effectue un recalcul complet de formules arbitraires dans un fichier XLSX externe.

**Puis‑je utiliser des formules qui référencent une autre feuille ou un autre classeur ?**

Des références de style Excel peuvent exister dans les classeurs de graphiques, mais l’évaluation des formules est limitée par le parseur et le jeu de fonctions pris en charge. Si une référence inter‑feuille ou externe est essentielle, validez cette formule exacte avec votre version cible d’Aspose.Slides. Pour les flux nécessitant une large compatibilité des références Excel, calculez le classeur en externe puis écrivez les valeurs résolues dans les données du graphique.

**Les chaînes de formule doivent‑elles commencer par `=` ?**

Les exemples d’API Aspose.Slides affectent des expressions telles que `B2-C2` ou `SUM(B2:B5)` sans le `=` initial. Utiliser cette forme maintient la cohérence avec les exemples de l’API documentée.