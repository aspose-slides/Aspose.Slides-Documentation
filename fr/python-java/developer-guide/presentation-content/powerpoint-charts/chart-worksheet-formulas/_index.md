---
title: Appliquer les formules de feuille de calcul du graphique dans les présentations en Python via Java
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/python-java/chart-worksheet-formulas/
keywords:
- feuille de calcul de graphique
- feuille de travail du graphique
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
- Java
- Aspose.Slides
description: "Appliquer les formules de type Excel dans les feuilles de calcul de graphiques Aspose.Slides pour Python via Java, recalculer les valeurs et utiliser les résultats dans les graphiques PowerPoint."
---
## **Vue d'ensemble**

Les graphiques PowerPoint stockent généralement leurs données source dans une feuille de calcul intégrée. Dans Aspose.Slides for Python via Java, vous pouvez accéder à cette feuille via le classeur de données du graphique, écrire des valeurs d’entrée, affecter des formules aux cellules, calculer les formules prises en charge et utiliser les cellules calculées comme données du graphique.

Cet article explique le flux complet des formules : créer un graphique, remplir sa feuille de calcul, affecter des formules de style A1 ou R1C1, les recalculer, lire les valeurs calculées, connecter ces cellules à une série de graphique et enregistrer la présentation. Il décrit également la syntaxe des formules prises en charge, le sous‑ensemble de fonctions intégrées, les valeurs en cache, les formules non prises en charge et les erreurs spécifiques aux feuilles de calcul.

## **Feuilles de calcul et formules des graphiques**

Une feuille de calcul de graphique contient les catégories, les noms de séries et les valeurs utilisées par un graphique. Dans PowerPoint, vous pouvez inspecter la feuille en ouvrant l’éditeur de données du graphique :

![Graphique PowerPoint avec sa feuille de calcul intégrée ouverte, affichant les données de catégorie et de séries](chart-worksheet-formulas_1.png)

Dans Aspose.Slides, la feuille est exposée via la classe [ChartDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/). Utilisez [ChartDataCell.setFormula](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#setFormula) pour les formules de style A1 et [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#setR1C1Formula) pour les formules de style R1C1. Après avoir modifié les cellules d’entrée ou les formules, appelez [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) pour recalculer les formules prises en charge et mettre à jour les valeurs correspondantes.

Une cellule calculée expose toujours son résultat via [ChartDataCell.getValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#getValue). C’est important lorsque vous devez inspecter le résultat d’une formule dans le code ou utiliser la cellule comme point de données du graphique.

## **Créer un graphique et calculer les formules de la feuille de calcul**

L’exemple suivant montre un flux de travail complet. Il crée un graphique à colonnes groupées, supprime les données d’exemple, écrit les valeurs de revenu et de dépenses trimestriels, calcule le profit avec des formules, lit les résultats, utilise les cellules calculées comme valeurs du graphique et enregistre la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Les points de données du graphique font référence à `D2:D4`, de sorte que le graphique utilise les valeurs de profit calculées. Aucun appel distinct de rafraîchissement du graphique n’est nécessaire dans ce flux : recalculez d’abord le classeur, puis utilisez ou enregistrez les données du graphique qui pointent vers les cellules calculées.

## **Utiliser des formules de style A1**

La notation A1 identifie les colonnes par des lettres et les lignes par des nombres. Affectez des expressions de style A1 via [ChartDataCell.setFormula](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#setFormula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Les formes de référence A1 courantes sont :

| Référence | Relative | Absolue | Mixte |
|---|---|---|---|
| Cellule | `A2` | `$A$2` | `A$2`, `$A2` |
| Ligne | `2:2` | `$2:$2` | — |
| Colonne | `A:A` | `$A:$A` | — |
| Plage | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Les références relatives peuvent changer lorsqu’une formule est déplacée ou copiée par une application de feuille de calcul. Les références absolues maintiennent les deux coordonnées fixes, tandis que les références mixtes ne fixent qu’une ligne ou une colonne.

## **Utiliser des formules de style R1C1**

La notation R1C1 identifie à la fois les lignes et les colonnes numériquement. Les références relatives utilisent des décalages entre crochets. Affectez cette syntaxe via [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#setR1C1Formula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
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
| Logique | `TRUE`, `FALSE` | Peut être utilisé directement dans des expressions logiques telles que `A2=TRUE`. |
| Numérique | `1`, `0.5`, `.3`, `1E-2` | La notation décimale et scientifique sont prises en charge. |
| Chaîne | `"abc"`, `"2/3/2020 12:00"` | Les littéraux texte sont entourés de guillemets doubles dans la formule. |
| Résultat d’erreur | `#DIV/0!`, `#N/A`, `#REF!` | Une formule valide peut s’évaluer à une valeur d’erreur de feuille de calcul au lieu d’un résultat normal. |

Cet exemple utilise plusieurs types de constantes :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # Faux
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
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
| `=` | Égal à | `A2=3` |
| `<>` | Différent de | `A2<>3` |
| `>` | Supérieur à | `A2>3` |
| `>=` | Supérieur ou égal à | `A2>=3` |
| `<` | Inférieur à | `A2<3` |
| `<=` | Inférieur ou égal à | `A2<=3` |

## **Fonctions prédéfinies prises en charge**

Aspose.Slides comprend un évaluateur de formules intégré pour les feuilles de calcul de graphiques, mais ce n’est pas un moteur complet de calcul Excel. L’ensemble de fonctions documenté se limite à celles ci‑dessous. Ne supposez pas qu’une fonction Excel arbitraire puisse être recalculée par [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Fonction | But ou forme prise en charge | Exemple |
|---|---|---|
| `ABS` | Valeur absolue | `ABS(A2)` |
| `AVERAGE` | Moyenne arithmétique | `AVERAGE(B2:B5)` |
| `CEILING` | Arrondir au multiple supérieur | `CEILING(A2,5)` |
| `CHOOSE` | Sélectionner une valeur par indice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Concaténer des valeurs texte | `CONCAT(A2,B2)` |
| `CONCATENATE` | Concaténer des valeurs texte | `CONCATENATE(A2," ",B2)` |
| `DATE` | Créer une valeur date avec le système 1900 | `DATE(2026,8,19)` |
| `DAYS` | Retourner le nombre de jours entre deux dates | `DAYS(B2,A2)` |
| `FIND` | Rechercher une chaîne dans une autre | `FIND("-",A2)` |
| `FINDB` | Recherche texte orientée octet | `FINDB("a",A2)` |
| `IF` | Résultat conditionnel | `IF(A2>0,A2,0)` |
| `INDEX` | Forme de référence | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forme vectorielle | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forme vectorielle | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valeur maximale | `MAX(B2:B5)` |
| `SUM` | Somme des valeurs | `SUM(B2:B5)` |
| `VLOOKUP` | Recherche verticale | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Les restrictions indiquées dans le tableau sont importantes : `INDEX` est documenté sous forme de référence, tandis que `LOOKUP` et `MATCH` sont documentés sous leurs formes vectorielles. `DATE` utilise le système de dates 1900. Les fonctionnalités et fonctions non répertoriées ici doivent être considérées comme non prises en charge par l’évaluateur de formules d’Aspose.Slides, sauf indication contraire dans une documentation séparée.

## **Calculer les formules avec une culture préférée**

Certaines fonctions du classeur de graphique interprètent le texte selon les règles spécifiques d’une culture. Cela est particulièrement important pour les fonctions destinées aux langues utilisant des jeux de caractères multioctets (DBCS). Pour calculer correctement ces formules, créez un [LoadOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/), définissez la culture préférée avec [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), affectez les options de feuille de calcul via [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) puis chargez la présentation.

L’exemple suivant sélectionne la culture japonaise, ouvre une présentation avec les options de chargement configurées et appelle [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) pour chaque classeur de graphique :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

La culture préférée fait partie de la configuration du chargement de la présentation, il faut donc la spécifier avant de créer l’instance [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/). Utilisez la culture attendue par les formules du classeur ; par exemple, `ja-JP` pour les formules qui doivent suivre les règles de calcul DBCS japonaises.

## **Recalcul et valeurs en cache**

Les fichiers de feuilles de calcul stockent généralement à la fois une formule et sa dernière valeur calculée. Aspose.Slides peut donc lire une valeur en cache via [ChartDataCell.getValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#getValue) lorsqu’une présentation est chargée et que les données du graphique concernées n’ont pas été modifiées.

Après avoir modifié des cellules d’entrée ou des formules, ne vous fiez pas à un ancien résultat en cache. Appelez [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) avant de lire les valeurs calculées ou d’enregistrer les données du graphique qui en dépendent.

Pour les formules en dehors du sous‑ensemble pris en charge, Aspose.Slides peut être incapable d’analyser la formule ou d’établir ses dépendances. Si le classeur a été modifié, la valeur en cache précédente ne peut plus être considérée comme fiable. Dans ce cas, la lecture de la valeur d’une cellule contenant des données non prises en charge peut déclencher une [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellunsupporteddataexception/).

Si votre graphique dépend de fonctions Excel qu’Aspose.Slides n’évalue pas, calculez ces formules avec un moteur de feuille de calcul qui les prend en charge et écrivez les valeurs résultantes dans le classeur du graphique. Ne remplacez pas les formules non prises en charge par des valeurs supposées.

## **Gérer les erreurs de formule**

Il existe deux types différents de problèmes à distinguer.

Une formule peut être valide mais produire un résultat d’erreur de feuille de calcul tel que `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ou `#VALUE!`. Dans ce cas, le jeton d’erreur est le résultat d’une cellule et peut être renvoyé via [ChartDataCell.getValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#getValue).

Une formule peut également échouer lors de l’analyse, de la référence, de la dépendance ou du niveau des données prises en charge. Aspose.Slides fournit des exceptions spécifiques aux feuilles de calcul pour ces cas : [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellcircularreferenceexception/) et [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellunsupporteddataexception/).

Lorsque les formules proviennent de modèles ou d’entrées utilisateur, gérez ces exceptions autour du recalcul et de l’accès aux valeurs :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Limitations pratiques**

La prise en charge des formules dans les feuilles de calcul de graphiques vise un sous‑ensemble défini de calculs de feuille de calcul, pas une compatibilité Excel complète. Gardez ces contraintes à l’esprit lors de la conception d’un flux de travail de reporting :

- Utilisez uniquement les constantes, opérateurs, références et fonctions documentés lorsque vous avez besoin qu’Aspose.Slides recalcule les formules.
- Recalculez après avoir modifié les cellules dont les résultats de formule dépendent.
- Considérez les valeurs en cache provenant de présentations chargées comme des instantanés, non comme un remplacement du recalcul après modification.
- Testez les formules provenant de modèles existants avant de vous fier à leurs valeurs calculées, en particulier lorsqu’elles utilisent des fonctions hors de la liste documentée.
- Pour les formules nécessitant un moteur complet de calcul de feuille de calcul, calculez‑les externement puis mettez à jour le classeur du graphique avec les valeurs résultantes.

## **FAQ**

**Quelle est la différence entre [ChartDataCell.setFormula](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#setFormula) et [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#setR1C1Formula) ?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#setFormula) stocke une expression de style A1 telle que `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#setR1C1Formula) stocke une expression de style R1C1 telle que `RC[-2]-RC[-1]`. Utilisez la notation qui correspond le mieux à votre façon de générer ou copier les formules.

**Dois‑je lire la cellule elle‑même ou sa valeur après le calcul ?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/#getCell) renvoie un [ChartDataCell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/). Pour obtenir le résultat calculé, appelez la méthode [ChartDataCell.getValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#getValue) de cette cellule après le recalcul.

**Quand dois‑je appeler [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) ?**

Appelez [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) après avoir modifié des valeurs d’entrée ou des formules et avant de dépendre des résultats calculés. Cela met à jour les valeurs des formules que l’évaluateur intégré prend en charge.

**Aspose.Slides prend‑t‑il en charge toutes les fonctions Excel ?**

Non. L’évaluateur intégré ne prend en charge qu’un sous‑ensemble documenté de fonctions. Les fonctions en dehors de ce sous‑ensemble ne doivent pas être supposées se recalculer correctement. Si une compatibilité totale avec les formules Excel est requise, effectuez le calcul avec un moteur de feuille de calcul approprié et écrivez les valeurs finales dans le classeur du graphique.

**Que se passe‑t‑il si une présentation chargée contient une formule non prise en charge ?**

Si les données du graphique n’ont pas été modifiées, le classeur peut encore contenir une valeur en cache précédemment calculée. Après modification des données associées, cette valeur en cache peut ne plus être valable. L’accès à une cellule dont la formule ne peut être gérée peut déclencher une [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellunsupporteddataexception/).

**Les valeurs d’erreur de formule sont‑elles identiques aux exceptions ?**

Non. Un résultat tel que `#DIV/0!` est une valeur de feuille de calcul produite par un calcul valide. Les exceptions comme [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellinvalidformulaexception/) ou [CellCircularReferenceException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellcircularreferenceexception/) indiquent que la formule ne peut pas être traitée normalement.

**Un graphique se met‑il à jour automatiquement lorsqu’une cellule de formule change ?**

Une série de graphique peut référencer des cellules du classeur. Recalculez d’abord le classeur, puis enregistrez ou rendez la présentation. Si les points de données du graphique référencent les cellules calculées, le graphique utilise ces valeurs mises à jour ; aucune méthode de rafraîchissement du graphique distincte n’est requise pour ce flux.

**Les graphiques peuvent‑ils utiliser un classeur Excel externe ?**

Oui, les données du graphique peuvent être configurées pour utiliser un classeur externe via l’API des données de graphique. Toutefois, le flux de calcul des formules décrit dans cet article concerne le classeur de données du graphique et le sous‑ensemble de formules évalué par Aspose.Slides. Ne supposez pas que [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) offre un recalcul complet de formules arbitraires dans un fichier XLSX externe.

**Puis‑je utiliser des formules qui font référence à une autre feuille ou à un autre classeur ?**

Des références de style Excel peuvent exister dans les classeurs de graphiques, mais l’évaluation des formules est limitée par l’analyseur et le jeu de fonctions pris en charge. Si une référence inter‑feuille ou externe est indispensable, validez cette formule exacte avec la version d’Aspose.Slides ciblée. Pour les flux nécessitant une large compatibilité des références Excel, calculez le classeur à l’extérieur et écrivez les valeurs résolues dans les données du graphique.

**Les chaînes de formule doivent‑elles commencer par `=` ?**

Les exemples de l’API Aspose.Slides assignent des expressions telles que `B2-C2` ou `SUM(B2:B5)` sans le `=` initial. Utiliser cette forme maintient la cohérence des formules générées avec les exemples documentés de l’API.