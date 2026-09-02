---
title: Appliquer les formules de feuille de calcul du graphique dans les présentations avec JavaScript
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/nodejs-java/chart-worksheet-formulas/
keywords:
- feuille de calcul du graphique
- feuille de travail du graphique
- formule de graphique
- formule de feuille de calcul
- formule de feuille de calcul
- cahier de données du graphique
- calcul de formule
- constante logique
- constante numérique
- constante de chaîne
- constante d’erreur
- opérateur arithmétique
- opérateur de comparaison
- style A1
- style R1C1
- fonction prédéfinie
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: Appliquer des formules de type Excel dans Aspose.Slides pour Node.js via les feuilles de calcul de graphique Java, recalculer les valeurs et utiliser les résultats dans les graphiques PowerPoint.
---
## **Aperçu**

Les graphiques PowerPoint stockent généralement leurs données sources dans une feuille de calcul intégrée. Avec Aspose.Slides for Node.js via Java, vous pouvez accéder à cette feuille via le classeur de données du graphique, écrire des valeurs d’entrée, attribuer des formules aux cellules, calculer les formules prises en charge et utiliser les cellules calculées comme données du graphique.

Cet article explique le flux complet de travail des formules : créer un graphique, remplir sa feuille de calcul, attribuer des formules de style A1 ou R1C1, les recalculer, lire les valeurs calculées, connecter ces cellules à une série de graphique et enregistrer la présentation. Il décrit également la syntaxe des formules prises en charge, le sous‑ensemble de fonctions intégré, les valeurs en cache, les formules non prises en charge et les erreurs spécifiques aux feuilles de calcul.

## **Feuilles de calcul du graphique et formules**

Une feuille de calcul de graphique contient les catégories, les noms de séries et les valeurs utilisées par un graphique. Dans PowerPoint, vous pouvez inspecter la feuille en ouvrant l’éditeur de données du graphique :

![Graphique PowerPoint avec sa feuille de calcul intégrée ouverte, affichant les catégories et les séries de données](chart-worksheet-formulas_1.png)

Dans Aspose.Slides, la feuille est exposée via la classe [ChartDataWorkbook](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/). Utilisez [ChartDataCell.setFormula](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) pour les formules de style A1 et [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) pour les formules de style R1C1. Après avoir modifié des cellules d’entrée ou des formules, appelez [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) pour recalculer les formules prises en charge et mettre à jour les valeurs correspondantes des cellules.

Une cellule calculée expose toujours son résultat via [ChartDataCell.getValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#getValue--). Cela est important lorsque vous devez inspecter le résultat d’une formule dans le code ou utiliser la cellule comme point de données du graphique.

## **Créer un graphique et calculer les formules de la feuille**

L’exemple suivant montre un flux de travail de bout en bout. Il crée un graphique à barres groupées, supprime les données d’exemple, écrit les valeurs de revenu et de dépense trimestriels, calcule le profit à l’aide de formules, lit les résultats, utilise les cellules calculées comme valeurs du graphique et enregistre la présentation.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les points de données du graphique font référence à `D2:D4`, de sorte que le graphique utilise les valeurs de profit calculées. Il n’y a pas d’appel de rafraîchissement du graphique séparé dans ce flux : recalculer d’abord le classeur, puis utiliser ou enregistrer les données du graphique qui pointent vers les cellules calculées.

## **Utiliser des formules de style A1**

La notation A1 identifie les colonnes par des lettres et les lignes par des nombres. Attribuez des expressions de style A1 via [ChartDataCell.setFormula](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
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

La notation R1C1 identifie à la fois les lignes et les colonnes numériquement. Les références relatives utilisent des décalages entre crochets. Attribuez cette syntaxe via [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
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
| Chaîne | `"abc"`, `"2/3/2020 12:00"` | Les littéraux textuels sont entourés de guillemets doubles dans la formule. |
| Résultat d’erreur | `#DIV/0!`, `#N/A`, `#REF!` | Une formule valide peut s’évaluer à une valeur d’erreur de feuille de calcul au lieu d’un résultat normal. |

Cet exemple utilise plusieurs types de constantes :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // faux
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
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
| `=` | Egal à | `A2=3` |
| `<>` | Différent de | `A2<>3` |
| `>` | Supérieur à | `A2>3` |
| `>=` | Supérieur ou égal à | `A2>=3` |
| `<` | Inférieur à | `A2<3` |
| `<=` | Inférieur ou égal à | `A2<=3` |

## **Fonctions prédéfinies prises en charge**

Aspose.Slides comprend un évaluateur de formules intégré pour les feuilles de calcul des graphiques, mais ce n’est pas un moteur de calcul complet d’Excel. Le jeu de fonctions documenté est limité aux fonctions ci‑dessous. Ne partez pas du principe qu’une fonction Excel arbitraire peut être recalculée par [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Fonction | Objectif ou forme prise en charge | Exemple |
|---|---|---|
| `ABS` | Valeur absolue | `ABS(A2)` |
| `AVERAGE` | Moyenne arithmétique | `AVERAGE(B2:B5)` |
| `CEILING` | Arrondir un nombre à la hausse jusqu’à un multiple | `CEILING(A2,5)` |
| `CHOOSE` | Sélectionner une valeur par indice | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Concaténer des valeurs texte | `CONCAT(A2,B2)` |
| `CONCATENATE` | Concaténer des valeurs texte | `CONCATENATE(A2," ",B2)` |
| `DATE` | Créer une valeur de date avec le système 1900 | `DATE(2026,8,19)` |
| `DAYS` | Retourner le nombre de jours entre deux dates | `DAYS(B2,A2)` |
| `FIND` | Rechercher une chaîne dans une autre | `FIND("-",A2)` |
| `FINDB` | Recherche de texte orientée octet | `FINDB("a",A2)` |
| `IF` | Résultat conditionnel | `IF(A2>0,A2,0)` |
| `INDEX` | Forme de référence | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forme vectorielle | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forme vectorielle | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valeur maximale | `MAX(B2:B5)` |
| `SUM` | Somme des valeurs | `SUM(B2:B5)` |
| `VLOOKUP` | Recherche verticale | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Les restrictions indiquées dans le tableau sont importantes : `INDEX` est documenté sous forme de référence, tandis que `LOOKUP` et `MATCH` sont documentés sous leurs formes vectorielles. `DATE` utilise le système de date 1900. Les fonctionnalités et fonctions non listées ici doivent être considérées comme non prises en charge par l’évaluateur de formules d’Aspose.Slides, sauf mention contraire.

## **Recalcul et valeurs en cache**

Les fichiers de feuilles de calcul stockent généralement à la fois une formule et sa dernière valeur calculée. Aspose.Slides peut donc lire une valeur en cache via [ChartDataCell.getValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#getValue--) lorsqu’une présentation est chargée et que les données du graphique concernées n’ont pas été modifiées.

Après avoir modifié des cellules d’entrée ou des formules, ne comptez pas sur un ancien résultat en cache. Appelez [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) avant de lire les valeurs calculées ou d’enregistrer des données de graphique qui en dépendent.

Pour les formules en dehors du sous‑ensemble pris en charge, Aspose.Slides peut être incapable d’analyser la formule ou d’établir ses dépendances. Si le classeur a été modifié, la valeur en cache précédente ne peut plus être considérée comme fiable. Dans cette situation, la lecture de la valeur d’une cellule contenant des données non prises en charge peut lever [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Si votre graphique dépend de fonctions Excel qu’Aspose.Slides n’évalue pas, calculez ces formules avec un moteur de feuille de calcul qui les supporte et écrivez les valeurs résultantes dans le classeur du graphique. Ne remplacez pas les formules non prises en charge par des valeurs devinées.

## **Gestion des erreurs de formule**

Il existe deux types de problèmes à distinguer.

Une formule peut être valide mais produire un résultat d’erreur de feuille de calcul tel que `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ou `#VALUE!`. Dans ce cas, le jeton d’erreur est le résultat d’une cellule et peut être renvoyé via [ChartDataCell.getValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Une formule peut également échouer au niveau de l’analyse, de la référence, de la dépendance ou des données prises en charge. Aspose.Slides fournit des exceptions spécifiques aux feuilles de calcul pour ces cas : [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/cellcircularreferenceexception/) et [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Lorsque les formules proviennent de modèles ou d’entrées utilisateur, interceptez les erreurs lors du recalcul et de l’accès aux valeurs. Les détails de l’erreur identifient le problème de feuille de calcul sous‑jacent :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **Limites pratiques**

La prise en charge des formules dans les feuilles de calcul des graphiques est destinée à un sous‑ensemble défini de calculs de feuille, et non à une compatibilité totale avec Excel. Gardez ces contraintes à l’esprit lors de la conception d’un flux de travail de reporting :

- Utilisez uniquement les constantes, opérateurs, références et fonctions documentés lorsque vous avez besoin qu’Aspose.Slides recalcule les formules.
- Recalculez après avoir modifié les cellules dont les résultats de formules dépendent.
- Considérez les valeurs en cache des présentations chargées comme des instantanés, et non comme un remplacement du recalcul après modification.
- Testez les formules des modèles existants avant de vous fier à leurs valeurs calculées, en particulier si elles utilisent des fonctions hors de la liste documentée.
- Pour les formules qui nécessitent un moteur complet de calcul de feuille, calculez‑les en externe puis mettez à jour le classeur du graphique avec les valeurs résultantes.

## **FAQ**

**Quelle est la différence entre [ChartDataCell.setFormula](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) et [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) stocke une expression de style A1 telle que `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) stocke une expression de style R1C1 telle que `RC[-2]-RC[-1]`. Utilisez la notation qui correspond le mieux à la façon dont vous générez ou copiez les formules.

**Dois‑je lire la cellule elle‑même ou sa valeur après le calcul ?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) renvoie un [ChartDataCell](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/). Pour obtenir le résultat calculé, appelez la méthode [ChartDataCell.getValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdatacell/#getValue--) de cette cellule après le recalcul.

**Quand dois‑je appeler [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)?**

Appelez [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) après avoir modifié des valeurs d’entrée ou des formules et avant de dépendre des résultats calculés. Cela met à jour les valeurs des formules supportées par l’évaluateur intégré.

**Aspose.Slides prend‑il en charge toutes les fonctions Excel ?**

Non. L’évaluateur intégré prend en charge un sous‑ensemble documenté de fonctions. Les fonctions en dehors de ce sous‑ensemble ne doivent pas être supposées se recalculer correctement. Si une compatibilité totale avec les formules Excel est requise, effectuez le calcul avec un moteur de feuille de calcul approprié et écrivez les valeurs finales dans le classeur du graphique.

**Que se passe‑t‑il si une présentation chargée contient une formule non prise en charge ?**

Si les données du graphique n’ont pas changé, le classeur peut encore contenir une valeur en cache calculée précédemment. Après modification des données associées, cette valeur en cache peut ne plus être valide. Accéder à une cellule dont la formule ne peut pas être traitée peut lever [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/cellunsupporteddataexception/).

**Les valeurs d’erreur de formule sont‑elles les mêmes que les exceptions ?**

Non. Un résultat tel que `#DIV/0!` est une valeur de feuille de calcul produite par un calcul valide. Les exceptions comme [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/cellinvalidformulaexception/) ou [CellCircularReferenceException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/cellcircularreferenceexception/) indiquent que la formule ne peut pas être traitée normalement.

**Un graphique se met‑il à jour automatiquement lorsqu’une cellule de formule change ?**

Une série de graphique peut référencer des cellules du classeur. Recalculez d’abord le classeur, puis enregistrez ou générez la présentation. Si les points de données du graphique font référence aux cellules calculées, le graphique utilise ces valeurs mises à jour ; aucune méthode de rafraîchissement du graphique séparée n’est requise pour ce flux.

**Les graphiques peuvent‑ils utiliser un classeur Excel externe ?**

Oui, les données du graphique peuvent être configurées pour utiliser un classeur externe via l’API de données du graphique. Cependant, le flux de travail de calcul de formule décrit dans cet article concerne le classeur de données du graphique et le sous‑ensemble de formules évalué par Aspose.Slides. Ne supposez pas que [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) offre un recalcul complet de formules arbitraires dans un fichier XLSX externe.

**Puis‑je utiliser des formules qui référencent une autre feuille ou un autre classeur ?**

Des références de type Excel peuvent exister dans les classeurs de graphiques, mais l’évaluation des formules est limitée par le parseur et le jeu de fonctions pris en charge. Si une référence inter‑feuille ou externe est indispensable, validez la formule exacte avec votre version cible d’Aspose.Slides. Pour les flux nécessitant une large compatibilité des références Excel, calculez le classeur en externe et écrivez les valeurs résolues dans les données du graphique.

**Les chaînes de formule doivent‑elles commencer par `=` ?**

Les exemples d’API Aspose.Slides assignent des expressions telles que `B2-C2` ou `SUM(B2:B5)` sans le `=` initial. Utiliser cette forme maintient la cohérence avec les exemples d’API documentés.