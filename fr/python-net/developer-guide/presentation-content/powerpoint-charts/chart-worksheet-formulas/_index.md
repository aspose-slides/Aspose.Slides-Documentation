---
title: Appliquer des formules de feuille de calcul de graphique dans les présentations avec Python
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/python-net/chart-worksheet-formulas/
keywords:
- feuille de calcul graphique
- feuille de travail du graphique
- formule du graphique
- formule de feuille de calcul
- formule de feuille de calcul
- carnet de données du graphique
- calcul de formule
- culture préférée
- formule spécifique à la culture
- DBCS
- constante logique
- constante numérique
- constante chaîne
- constante d'erreur
- opérateur arithmétique
- opérateur de comparaison
- style A1
- style R1C1
- fonction prédéfinie
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Appliquer des formules de style Excel dans les feuilles de calcul des graphiques Aspose.Slides pour Python via .NET, recalculer les valeurs et utiliser les résultats dans les graphiques PowerPoint."
---
## **Vue d'ensemble**

Les graphiques PowerPoint stockent généralement leurs données sources dans une feuille de calcul intégrée. Avec Aspose.Slides for Python via .NET, vous pouvez accéder à cette feuille via le carnet de données du graphique, écrire des valeurs d’entrée, affecter des formules aux cellules, calculer les formules prises en charge et utiliser les cellules calculées comme données du graphique.

Cet article explique le flux complet des formules : créer un graphique, remplir sa feuille de calcul, affecter des formules au format A1 ou R1C1, les recalculer, lire les valeurs calculées, connecter ces cellules à une série de graphique et enregistrer la présentation. Il décrit également la syntaxe des formules prises en charge, le sous‑ensemble de fonctions intégrées, les valeurs en cache, les formules non prises en charge et les erreurs spécifiques aux feuilles de calcul.

## **Feuilles de calcul de graphiques et formules**

Une feuille de calcul de graphique contient les catégories, les noms de séries et les valeurs utilisées par le graphique. Dans PowerPoint, vous pouvez inspecter la feuille en ouvrant l’éditeur de données du graphique :

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Dans Aspose.Slides, la feuille est exposée via le [carnet de données du graphique](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/ichartdataworkbook/). Utilisez la propriété [formula](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/ichartdatacell/formula/) pour les formules au format A1 et la propriété [r1c1_formula](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) pour les formules au format R1C1. Après avoir modifié des cellules d’entrée ou des formules, appelez [calculate_formulas](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) pour recalculer les formules prises en charge et mettre à jour les valeurs des cellules correspondantes.

Une cellule calculée expose toujours son résultat via la propriété [value](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/ichartdatacell/value/). Cela est important lorsque vous devez inspecter le résultat d’une formule dans le code ou utiliser la cellule comme point de données du graphique.

## **Créer un graphique et calculer les formules de la feuille**

L’exemple suivant montre un fonctionnement de bout en bout. Il crée un graphique à colonnes groupées, supprime les données d’exemple, écrit les valeurs de revenu et de dépense trimestriels, calcule le profit avec des formules, lit les résultats, utilise les cellules calculées comme valeurs du graphique et enregistre la présentation.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Les points de données du graphique font référence à `D2:D4`, de sorte que le graphique utilise les valeurs de profit calculées. Aucun appel séparé de rafraîchissement du graphique n’est nécessaire : recalculez d’abord le carnet, puis utilisez ou enregistrez les données du graphique qui pointent vers les cellules calculées.

## **Utiliser des formules au format A1**

La notation A1 identifie les colonnes avec des lettres et les lignes avec des chiffres. Affectez des expressions au format A1 via [IChartDataCell.formula](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Les formes de référence A1 courantes sont :

| Référence | Relative | Absolue | Mixte |
|---|---|---|---|
| Cellule | `A2` | `$A$2` | `A$2`, `$A2` |
| Ligne | `2:2` | `$2:$2` | — |
| Colonne | `A:A` | `$A:$A` | — |
| Plage | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Les références relatives peuvent changer lorsqu’une formule est déplacée ou copiée par une application de feuille de calcul. Les références absolues conservent les deux coordonnées fixes, tandis que les références mixtes fixent uniquement une ligne ou une colonne.

## **Utiliser des formules au format R1C1**

La notation R1C1 identifie les lignes et les colonnes numériquement. Les références relatives utilisent des décalages entre crochets. Affectez cette syntaxe via [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
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
| Chaîne | `"abc"`, `"2/3/2020 12:00"` | Les littéraux texte sont entourés de guillemets doubles dans la formule. |
| Résultat d’erreur | `#DIV/0!`, `#N/A`, `#REF!` | Une formule valide peut se solder par une valeur d’erreur de feuille de calcul au lieu d’un résultat normal. |

Cet exemple utilise plusieurs types de constantes :

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Faux
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Opérateurs arithmétiques**

| Opérateur | Signification | Exemple |
|---|---|---|
| `+` | Addition ou plus unaire | `2+3` |
| `-` | Soustraction ou négation | `2-3`, `-3` |
| `*` | Multiplication | `2*3` |
| `/` | Division | `2/3` |
| `%` | Pourcentage | `30%` |
| `^` | Exposant | `2^3` |

Utilisez des parenthèses pour rendre l’ordre d’évaluation explicite, par exemple `(A2+B2)*C2`.

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

Aspose.Slides comprend un évaluateur de formules intégré pour les feuilles de calcul de graphiques, mais il ne s’agit pas d’un moteur complet de calcul Excel. L’ensemble de fonctions documentées est limité aux fonctions ci‑dessous. Ne supposez pas qu’une fonction Excel quelconque puisse être recalculée par [calculate_formulas](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Fonction | Objectif ou forme prise en charge | Exemple |
|---|---|---|
| `ABS` | Valeur absolue | `ABS(A2)` |
| `AVERAGE` | Moyenne arithmétique | `AVERAGE(B2:B5)` |
| `CEILING` | Arrondir un nombre à la hausse à un multiple | `CEILING(A2,5)` |
| `CHOOSE` | Sélectionner une valeur par index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Concaténer des valeurs texte | `CONCAT(A2,B2)` |
| `CONCATENATE` | Concaténer des valeurs texte | `CONCATENATE(A2," ",B2)` |
| `DATE` | Créer une valeur de date avec le système 1900 | `DATE(2026,8,19)` |
| `DAYS` | Retourner le nombre de jours entre deux dates | `DAYS(B2,A2)` |
| `FIND` | Rechercher une chaîne dans une autre | `FIND("-",A2)` |
| `FINDB` | Recherche orientée octet | `FINDB("a",A2)` |
| `IF` | Résultat conditionnel | `IF(A2>0,A2,0)` |
| `INDEX` | Forme de référence | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forme vectorielle | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forme vectorielle | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valeur maximale | `MAX(B2:B5)` |
| `SUM` | Somme des valeurs | `SUM(B2:B5)` |
| `VLOOKUP` | Recherche verticale | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Les restrictions indiquées dans le tableau sont importantes : `INDEX` est documenté en forme de référence, tandis que `LOOKUP` et `MATCH` sont documentés sous leurs formes vectorielles. `DATE` utilise le système de date 1900. Les fonctionnalités et fonctions non répertoriées ici doivent être considérées comme non prises en charge par l’évaluateur de formules Aspose.Slides, sauf indication contraire dans une documentation séparée.

## **Calculer les formules avec une culture préférée**

Certaines fonctions du carnet de données du graphique interprètent le texte selon des règles propres à la culture. Cela est crucial pour les fonctions destinées aux langues utilisant des jeux de caractères double octet (DBCS). Pour calculer correctement ces formules, créez un [LoadOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/), définissez [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/fr/python-net/aspose.slides/spreadsheetoptions/) via [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/spreadsheet_options/), puis chargez la présentation.

L’exemple suivant sélectionne la culture japonaise, ouvre une présentation avec les options de chargement configurées et appelle [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) pour chaque carnet de données de graphique :

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

La culture préférée fait partie de la configuration de chargement de la présentation, il faut donc la spécifier avant de créer l’instance [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). Utilisez la culture attendue par les formules du carnet ; par exemple, `ja-JP` pour des formules qui doivent suivre les règles de calcul DBCS japonaises.

## **Recalcul et valeurs en cache**

Les fichiers de feuilles de calcul stockent généralement à la fois une formule et sa dernière valeur calculée. Aspose.Slides peut donc lire une valeur en cache depuis [IChartDataCell.value](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/ichartdatacell/value/) lorsqu’une présentation est chargée et que les données du graphique concernées n’ont pas été modifiées.

Après avoir modifié des cellules d’entrée ou des formules, ne vous fiez pas à un ancien résultat en cache. Appelez [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) avant de lire les valeurs calculées ou d’enregistrer les données du graphique qui en dépendent.

Pour les formules hors du sous‑ensemble pris en charge, Aspose.Slides peut être incapable d’analyser la formule ou d’établir ses dépendances. Si le carnet a été modifié, la valeur en cache précédente ne peut plus être considérée comme fiable. Dans cette situation, la lecture de la valeur d’une cellule contenant des données non prises en charge peut lever [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Si votre graphique dépend de fonctions Excel que Aspose.Slides n’évalue pas, calculez ces formules avec un moteur de feuille de calcul qui les prend en charge et écrivez les valeurs résultantes dans le carnet de données du graphique. Ne remplacez pas les formules non prises en charge par des valeurs devinées.

## **Gestion des erreurs de formule**

Il existe deux types de problèmes à distinguer.

Une formule peut être valide mais produire un résultat d’erreur de feuille de calcul tel que `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ou `#VALUE!`. Dans ce cas, le jeton d’erreur est le résultat d’une cellule et peut être renvoyé via `value`.

Une formule peut également échouer lors de l’analyse, de la référence, de la dépendance ou du niveau de données prises en charge. Aspose.Slides fournit des exceptions spécifiques aux feuilles de calcul pour ces cas : [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fr/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fr/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) et [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Lorsque les formules proviennent de modèles ou d’entrées utilisateur, gérez ces exceptions autour du recalcul et de l’accès aux valeurs :

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Limitations pratiques**

Le support des formules dans les feuilles de calcul de graphiques est destiné à un sous‑ensemble défini de calculs de feuilles, pas à une compatibilité Excel complète. Gardez ces contraintes à l’esprit lors de la conception d’un flux de production de rapports :

- N’utilisez que les constantes, opérateurs, références et fonctions documentés lorsque vous avez besoin qu’Aspose.Slides recalcule les formules.
- Recalculez après avoir modifié les cellules dont dépendent les résultats de formules.
- Considérez les valeurs en cache des présentations chargées comme des instantanés, pas comme un remplacement du recalcul après des modifications.
- Testez les formules des modèles existants avant de compter sur leurs valeurs calculées, surtout si elles utilisent des fonctions hors de la liste documentée.
- Pour les formules nécessitant un moteur de calcul complet, calculez‑les à l’extérieur puis mettez à jour le carnet de données du graphique avec les valeurs résultantes.

## **FAQ**

**Quelle est la différence entre `formula` et `r1c1_formula` ?**

[formula](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/ichartdatacell/formula/) stocke une expression au format A1 comme `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) stocke une expression au format R1C1 comme `RC[-2]-RC[-1]`. Utilisez la notation qui correspond le mieux à votre façon de générer ou copier les formules.

**Dois‑je lire la cellule elle‑-même ou sa valeur après le calcul ?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) renvoie un `IChartDataCell`. Pour obtenir le résultat calculé, lisez la propriété [value](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/ichartdatacell/value/) de cette cellule après le recalcul.

**Quand dois‑je appeler `calculate_formulas` ?**

Appelez [calculate_formulas](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) après avoir modifié des valeurs d’entrée ou des formules et avant de dépendre des résultats calculés. Cela met à jour les valeurs des formules que l’évaluateur intégré prend en charge.

**Aspose.Slides prend‑il en charge toutes les fonctions Excel ?**

Non. L’évaluateur intégré prend en charge un sous‑ensemble documenté de fonctions. Les fonctions en dehors de ce sous‑ensemble ne doivent pas être supposées être recalculées correctement. Si une compatibilité totale avec les formules Excel est requise, effectuez le calcul avec un moteur de feuille de calcul approprié et écrivez les valeurs finales dans le carnet de données du graphique.

**Que se passe‑t‑il si une présentation chargée contient une formule non prise en charge ?**

Si les données du graphique n’ont pas changé, le carnet peut encore contenir une valeur en cache précédemment calculée. Après modification des données liées, cette valeur en cache peut ne plus être valide. L’accès à une cellule dont la formule ne peut pas être gérée peut lever [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Les valeurs d’erreur de formule sont‑elles identiques aux exceptions Python ?**

Non. Un résultat tel que `#DIV/0!` est une valeur de feuille de calcul produite par un calcul valide. Les exceptions comme [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) ou [CellCircularReferenceException](https://reference.aspose.com/slides/fr/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indiquent que la formule ne peut pas être traitée normalement.

**Un graphique se met‑il à jour automatiquement lorsqu’une cellule de formule change ?**

Une série de graphique peut référencer des cellules du carnet. Recalculez d’abord le carnet, puis enregistrez ou rendez la présentation. Si les points de données du graphique référencent les cellules calculées, le graphique utilise ces valeurs mises à jour ; aucune méthode de rafraîchissement distincte n’est requise dans ce flux.

**Les graphiques peuvent‑ils utiliser un classeur Excel externe ?**

Oui, les données du graphique peuvent être configurées pour utiliser un classeur externe via l’API des données de graphique. Cependant, le flux de calcul de formules décrit dans cet article concerne le carnet de données du graphique et le sous‑ensemble de formules évaluées par Aspose.Slides. Ne supposez pas que [calculate_formulas](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) fournisse un recalcul complet de formules arbitraires dans un fichier XLSX externe.

**Puis‑je utiliser des formules qui référencent une autre feuille ou un autre classeur ?**

Des références de type Excel peuvent exister dans les classeurs de graphiques, mais l’évaluation des formules est limitée par le parseur et le jeu de fonctions pris en charge. Si une référence inter‑feuille ou externe est indispensable, validez la formule exacte avec votre version cible d’Aspose.Slides. Pour les flux nécessitant une large compatibilité des références Excel, calculez le classeur en externe et écrivez les valeurs résolues dans les données du graphique.

**Les chaînes de formule doivent‑elles commencer par `=` ?**

Les exemples d’API Aspose.Slides assignent des expressions telles que `B2-C2` ou `SUM(B2:B5)` sans le caractère `=` initial. Utiliser cette forme maintient les formules générées cohérentes avec les exemples d’API documentés.