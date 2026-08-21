---
title: Appliquer les formules de feuille de calcul de diagramme dans les présentations en PHP
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/php-java/chart-worksheet-formulas/
keywords:
- feuille de calcul de diagramme
- feuille de travail du diagramme
- formule de diagramme
- formule de feuille de calcul
- formule de tableur
- cahier de données du diagramme
- calcul de formule
- culture préférée
- formule spécifique à la culture
- DBCS
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
- PHP
- Aspose.Slides
description: "Appliquer des formules de type Excel dans les feuilles de calcul de diagramme Aspose.Slides pour PHP via Java, recalculer les valeurs et utiliser les résultats dans les diagrammes PowerPoint."
---
## **Vue d'ensemble**

Les diagrammes PowerPoint stockent généralement leurs données sources dans une feuille de calcul intégrée. Dans Aspose.Slides pour PHP via Java, vous pouvez accéder à cette feuille via le classeur de données du diagramme, écrire des valeurs d’entrée, attribuer des formules aux cellules, calculer les formules prises en charge et utiliser les cellules calculées comme données du diagramme.

Cet article explique le flux complet des formules : créer un diagramme, remplir sa feuille de calcul, attribuer des formules au format A1 ou R1C1, les recalculer, lire les valeurs calculées, connecter ces cellules à une série du diagramme et enregistrer la présentation. Il décrit également la syntaxe des formules prise en charge, le sous‑ensemble de fonctions intégrées, les valeurs en cache, les formules non prises en charge et les erreurs spécifiques aux feuilles de calcul.

## **Feuilles de calcul de diagramme et formules**

Une feuille de calcul de diagramme contient les catégories, les noms de séries et les valeurs utilisés par un diagramme. Dans PowerPoint, vous pouvez inspecter la feuille en ouvrant l’éditeur de données du diagramme :

![Diagramme PowerPoint avec sa feuille de calcul intégrée ouverte, affichant les données de catégorie et de série](chart-worksheet-formulas_1.png)

Dans Aspose.Slides, la feuille est exposée via la classe [ChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/). Utilisez [ChartDataCell::setFormula](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#setFormula) pour les formules de style A1 et [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#setR1C1Formula) pour les formules de style R1C1. Après avoir modifié des cellules d’entrée ou des formules, appelez [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) pour recalculer les formules prises en charge et mettre à jour les valeurs correspondantes des cellules.

Une cellule calculée expose toujours son résultat via [ChartDataCell::getValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#getValue). C’est important lorsque vous devez inspecter le résultat d’une formule dans le code ou utiliser la cellule comme point de données du diagramme.

## **Créer un diagramme et calculer les formules de la feuille**

L’exemple suivant montre un flux de travail complet. Il crée un diagramme à colonnes groupées, efface les données d’exemple, écrit les valeurs de revenus et de dépenses trimestriels, calcule le bénéfice avec des formules, lit les résultats, utilise les cellules calculées comme valeurs du diagramme et enregistre la présentation.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Les points de données du diagramme font référence à `D2:D4`, de sorte que le diagramme utilise les valeurs de bénéfice calculées. Aucun appel séparé de rafraîchissement du diagramme n’est nécessaire dans ce flux : recalculer d’abord le classeur, puis utiliser ou enregistrer les données du diagramme qui pointent vers les cellules calculées.

## **Utiliser des formules de style A1**

La notation A1 identifie les colonnes par des lettres et les lignes par des nombres. Attribuez des expressions de style A1 via [ChartDataCell::setFormula](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Les formes de référence A1 courantes sont :

| Référence | Relative | Absolue | Mixte |
|---|---|---|---|
| Cellule | `A2` | `$A$2` | `A$2`, `$A2` |
| Ligne | `2:2` | `$2:$2` | — |
| Colonne | `A:A` | `$A:$A` | — |
| Plage | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Les références relatives peuvent changer lorsqu’une formule est déplacée ou copiée par une application de feuille de calcul. Les références absolues maintiennent les deux coordonnées fixes, tandis que les références mixtes fixent uniquement une ligne ou une colonne.

## **Utiliser des formules de style R1C1**

La notation R1C1 identifie à la fois les lignes et les colonnes numériquement. Les références relatives utilisent des décalages entre crochets. Attribuez cette syntaxe via [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
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
| Numérique | `1`, `0.5`, `.3`, `1E-2` | Les notations décimale et scientifique sont prises en charge. |
| Chaîne | `"abc"`, `"2/3/2020 12:00"` | Les littéraux textuels sont entourés de guillemets doubles dans la formule. |
| Résultat d’erreur | `#DIV/0!`, `#N/A`, `#REF!` | Une formule valide peut s’évaluer vers une valeur d’erreur de feuille de calcul au lieu d’un résultat normal. |

Cet exemple utilise plusieurs types de constantes :

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **Opérateurs arithmétiques**

| Opérateur | Signification | Exemple |
|---|---|---|
| `+` | Addition ou opérateur unaire | `2+3` |
| `-` | Soustraction ou négation | `2-3`, `-3` |
| `*` | Multiplication | `2*3` |
| `/` | Division | `2/3` |
| `%` | Pourcentage | `30%` |
| `^` | Exponentiation | `2^3` |

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

Aspose.Slides inclut un évaluateur de formules intégré pour les feuilles de calcul de diagramme, mais ce n’est pas un moteur complet de calcul Excel. L’ensemble de fonctions documentées est limité aux fonctions ci‑dessous. Ne supposez pas qu’une fonction Excel arbitraire puisse être recalculée par [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

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
| `FIND` | Trouver une chaîne dans une autre | `FIND("-",A2)` |
| `FINDB` | Recherche texte orientée octet | `FINDB("a",A2)` |
| `IF` | Résultat conditionnel | `IF(A2>0,A2,0)` |
| `INDEX` | Forme de référence | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Forme vectorielle | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Forme vectorielle | `MATCH(A2,B2:B5,0)` |
| `MAX` | Valeur maximale | `MAX(B2:B5)` |
| `SUM` | Somme des valeurs | `SUM(B2:B5)` |
| `VLOOKUP` | Recherche verticale | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Les restrictions indiquées dans le tableau sont importantes : `INDEX` est documenté sous forme de référence, tandis que `LOOKUP` et `MATCH` le sont sous forme vectorielle. `DATE` utilise le système de dates 1900. Les fonctionnalités et fonctions non listées ici doivent être considérées comme non prises en charge par l’évaluateur de formules Aspose.Slides, sauf indication contraire.

## **Calculer les formules avec une culture préférée**

Certaines fonctions du classeur de diagramme interprètent le texte selon des règles culturelles spécifiques. C’est particulièrement crucial pour les fonctions destinées aux langues utilisant des jeux de caractères à double octet (DBCS). Pour calculer correctement ces formules, créez [LoadOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/), définissez la culture préférée avec [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), affectez les options de feuille avec [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions), puis chargez la présentation.

L’exemple suivant sélectionne la culture japonaise, ouvre une présentation avec les options de chargement configurées et appelle [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) pour chaque classeur de diagramme :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

La culture préférée fait partie de la configuration de chargement de la présentation, il faut donc la spécifier avant de créer l’instance [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/). Utilisez la culture attendue par les formules du classeur ; par exemple, utilisez `ja-JP` pour des formules qui doivent suivre les règles de calcul DBCS japonaises.

## **Recalcul et valeurs en cache**

Les fichiers de feuille de calcul stockent généralement à la fois une formule et sa dernière valeur calculée. Aspose.Slides peut ainsi lire une valeur en cache via [ChartDataCell::getValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#getValue) lorsqu’une présentation est chargée et que les données du diagramme concernées n’ont pas été modifiées.

Après avoir modifié des cellules d’entrée ou des formules, ne vous fiez pas à un ancien résultat en cache. Appelez [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) avant de lire les valeurs calculées ou d’enregistrer les données du diagramme qui en dépendent.

Pour les formules en dehors du sous‑ensemble pris en charge, Aspose.Slides peut ne pas être capable d’analyser la formule ou d’établir ses dépendances. Si le classeur a été modifié, la valeur en cache précédente ne peut plus être considérée comme fiable. Dans cette situation, la lecture de la valeur d’une cellule contenant des données non prises en charge peut lever [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cellunsupporteddataexception/).

Si votre diagramme dépend de fonctions Excel que Aspose.Slides n’évalue pas, calculez ces formules avec un moteur de feuille de calcul qui les supporte et écrivez les valeurs résultantes dans le classeur du diagramme. Ne remplacez pas les formules non prises en charge par des valeurs supposées.

## **Gérer les erreurs de formule**

Il faut distinguer deux types de problèmes.

Une formule peut être valide mais produire un résultat d’erreur de feuille de calcul tel que `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ou `#VALUE!`. Dans ce cas, le jeton d’erreur est le résultat d’une cellule et peut être renvoyé via [ChartDataCell::getValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#getValue).

Une formule peut également échouer lors de l’analyse, de la référence, de la dépendance ou du niveau des données prises en charge. Aspose.Slides fournit des exceptions spécifiques aux feuilles de calcul pour ces cas : [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cellcircularreferenceexception/), et [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cellunsupporteddataexception/).

En PHP via Java, les exceptions Java sont exposées via `JavaException`. Lorsque les formules proviennent de modèles ou d’entrées utilisateur, gérez‑les autour du recalcul et de l’accès aux valeurs. L’exception Java reportée dans la trace de pile identifie l’échec de feuille de calcul spécifique :

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Limitations pratiques**

La prise en charge des formules dans les feuilles de calcul de diagramme est destinée à un sous‑ensemble défini de calculs de feuille, pas à une compatibilité Excel complète. Gardez ces contraintes à l’esprit lors de la conception d’un flux de travail de génération de rapports :

- Utilisez uniquement les constantes, opérateurs, références et fonctions documentés lorsque vous avez besoin qu’Aspose.Slides recalcule les formules.
- Recalculez après avoir modifié les cellules dont les résultats de formule dépendent.
- Considérez les valeurs en cache provenant de présentations chargées comme des instantanés, pas comme un substitut au recalcul après modifications.
- Testez les formules provenant de modèles existants avant de vous fier à leurs valeurs calculées, surtout si elles utilisent des fonctions hors de la liste documentée.
- Pour les formules nécessitant un moteur complet de calcul de feuille, calculez‑les en externe puis mettez à jour le classeur du diagramme avec les valeurs résultantes.

## **FAQ**

**Quelle est la différence entre [ChartDataCell::setFormula](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#setFormula) et [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#setR1C1Formula) ?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#setFormula) stocke une expression de style A1 telle que `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#setR1C1Formula) stocke une expression de style R1C1 telle que `RC[-2]-RC[-1]`. Utilisez la notation qui correspond le mieux à la façon dont vous générez ou copiez les formules.

**Dois‑je lire la cellule elle‑même ou sa valeur après le calcul ?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/#getCell) renvoie un [ChartDataCell](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/). Pour obtenir le résultat calculé, appelez la méthode [ChartDataCell::getValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#getValue) de cette cellule après le recalcul.

**Quand faut‑il appeler [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) ?**

Appelez [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) après avoir modifié les valeurs d’entrée ou les formules et avant de dépendre des résultats calculés. Cette opération met à jour les valeurs des formules que l’évaluateur intégré prend en charge.

**Aspose.Slides prend‑il en charge toutes les fonctions Excel ?**

Non. L’évaluateur intégré ne prend en charge qu’un sous‑ensemble documenté de fonctions. Les fonctions hors de ce sous‑ensemble ne doivent pas être supposées se recalculer correctement. Si une compatibilité totale avec les formules Excel est requise, effectuez le calcul avec un moteur de feuille de calcul approprié et écrivez les valeurs finales dans le classeur du diagramme.

**Que se passe‑t‑il si une présentation chargée contient une formule non prise en charge ?**

Si les données du diagramme n’ont pas été modifiées, le classeur peut encore contenir une valeur en cache calculée précédemment. Après modification des données associées, cette valeur en cache peut ne plus être valide. L’accès à une cellule dont la formule ne peut pas être gérée peut lever [CellUnsupportedDataException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cellunsupporteddataexception/).

**Les valeurs d’erreur de formule sont‑elles identiques aux exceptions PHP ?**

Non. Un résultat tel que `#DIV/0!` est une valeur de feuille de calcul produite par un calcul valide. Les échecs de traitement de feuille, comme [CellInvalidFormulaException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cellinvalidformulaexception/) ou [CellCircularReferenceException](https://reference.aspose.com/slides/fr/php-java/aspose.slides/cellcircularreferenceexception/), sont des exceptions Java exposées à PHP via `JavaException`.

**Un diagramme se met‑il à jour automatiquement lorsqu’une cellule de formule change ?**

Une série de diagramme peut référencer des cellules du classeur. Recalculez d’abord le classeur, puis enregistrez ou rendez la présentation. Si les points de données du diagramme font référence aux cellules calculées, le diagramme utilise ces valeurs mises à jour ; aucune méthode de rafraîchissement séparée n’est requise dans ce flux.

**Les diagrammes peuvent‑ils utiliser un classeur Excel externe ?**

Oui, les données du diagramme peuvent être configurées pour utiliser un classeur externe via l’API des données du diagramme. Cependant, le flux de calcul de formules décrit dans cet article concerne le classeur de données du diagramme et le sous‑ensemble de formules évalué par Aspose.Slides. Ne supposez pas que [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) effectue un recalcul complet de formules arbitraires dans un fichier XLSX externe.

**Puis‑je utiliser des formules qui font référence à une autre feuille ou à un autre classeur ?**

Les références de style Excel peuvent exister dans les classeurs de diagramme, mais l’évaluation des formules est limitée par le parseur et le jeu de fonctions pris en charge. Si une référence inter‑feuilles ou externe est indispensable, validez la formule exacte avec la version d’Aspose.Slides que vous utilisez. Pour les flux nécessitant une compatibilité large des références Excel, calculez le classeur en externe et écrivez les valeurs résolues dans les données du diagramme.

**Les chaînes de formule doivent‑elles commencer par `=` ?**

Les exemples d’API Aspose.Slides attribuent des expressions telles que `B2-C2` ou `SUM(B2:B5)` sans `=` initial. Utiliser cette forme maintient la cohérence avec les exemples d’API documentés.