---
title: Appliquer les formules de la feuille de calcul du graphique dans les présentations avec PHP
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/php-java/chart-worksheet-formulas/
keywords:
- feuille de calcul du graphique
- feuille de travail du graphique
- formule de graphique
- formule de feuille de calcul
- formule de feuille de calcul
- source de données
- constante logique
- constante numérique
- constante de chaîne
- constante d'erreur
- constante arithmétique
- opérateur de comparaison
- style A1
- style R1C1
- fonction prédéfinie
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Appliquer des formules de style Excel dans Aspose.Slides pour PHP via les feuilles de calcul Java des graphiques et automatiser les rapports dans les fichiers PPT et PPTX."
---

## **À propos des formules du tableau de données du graphique dans les présentations**
**Chart spreadsheet** (ou feuille de calcul du graphique) dans une présentation est la source de données du graphique. Chart spreadsheet contient des données, qui sont représentées sur le graphique de manière graphique. Lorsque vous créez un graphique dans PowerPoint, la feuille de calcul associée à ce graphique est également créée automatiquement. La feuille de calcul du graphique est créée pour tous les types de graphiques : graphique en courbes, graphique à barres, graphique en anneau, graphique circulaire, etc. Pour voir le tableau de données du graphique dans PowerPoint, double‑cliquez sur le graphique :

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet contient les noms des éléments du graphique (Nom de catégorie : *Category1*, Nom de série) et un tableau avec des données numériques correspondant à ces catégories et séries. Par défaut, lorsque vous créez un nouveau graphique, les données du tableau de données du graphique sont initialisées avec les données par défaut. Vous pouvez ensuite modifier les données du tableau dans la feuille de calcul manuellement.

En général, le graphique représente des données complexes (par ex. analystes financiers, analystes scientifiques), contenant des cellules calculées à partir des valeurs d’autres cellules ou d’autres données dynamiques. Calculer manuellement la valeur d’une cellule et la coder en dur dans la cellule rend difficile sa modification ultérieure. Si vous modifiez la valeur d’une certaine cellule, toutes les cellules dépendantes devront également être mises à jour. De plus, les données du tableau peuvent dépendre de données provenant d’autres tableaux, créant un schéma de données de présentation complexe qui doit pouvoir être mis à jour de manière simple et flexible.

**Chart spreadsheet formula** dans une présentation est une expression qui calcule et met à jour automatiquement les données du tableau de données du graphique. Une formule de tableau de données définit la logique de calcul des données pour une cellule donnée ou un groupe de cellules. La formule de tableau de données est une formule mathématique ou logique qui utilise : des références de cellules, des fonctions mathématiques, des opérateurs logiques, des opérateurs arithmétiques, des fonctions de conversion, des constantes de chaîne, etc. La définition de la formule est écrite dans une cellule, et cette cellule ne contient pas une simple valeur. La formule de tableau de données calcule la valeur et la renvoie, puis cette valeur est assignée à la cellule. Les formules du tableau de données du graphique dans les présentations sont en fait les mêmes que les formules Excel, et les mêmes fonctions, opérateurs et constantes par défaut sont pris en charge pour leur implémentation.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) le tableau de données du graphique est représenté avec la méthode
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--) du type
[**IChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).
Une formule de tableau de données peut être assignée et modifiée avec
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) .
Les fonctionnalités suivantes sont prises en charge pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d’erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellules au format A1
- Références de cellules au format R1C1
- Fonctions prédéfinies


En général, les feuilles de calcul stockent les dernières valeurs calculées des formules. Si, après le chargement de la présentation, les données du graphique n’ont pas été modifiées, la méthode [**IChartDataCell.getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getValue--) renvoie ces valeurs lors de la lecture. Mais, si les données du tableau de calcul ont été modifiées, la lecture de la propriété **ChartDataCell.Value** déclenche l’exception [**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException) pour les formules non prises en charge. Cela s’explique par le fait que, lorsqu’une formule est analysée avec succès, les dépendances de la cellule sont déterminées et la validité des dernières valeurs est confirmée. En revanche, si la formule ne peut pas être analysée, la validité de la valeur de la cellule ne peut être garantie.

## **Ajouter une formule du tableau de données du graphique à une présentation**
Tout d’abord, ajoutez un graphique à la première diapositive d’une nouvelle présentation avec
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addChart-int-float-float-float-float-).
La feuille de calcul du graphique est créée automatiquement et peut être accédée avec la méthode
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--) :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Écrivons quelques valeurs dans les cellules avec la propriété
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setValue-java.lang.Object-) du type **Object**, ce qui signifie que vous pouvez définir n’importe quelle valeur pour la propriété :
```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```


Ensuite, pour écrire une formule dans la cellule, vous pouvez utiliser la méthode
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) :

*Note* : la méthode [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) est utilisée pour définir des références de cellules au format A1.

Pour définir la référence de cellule [R1C1Formula](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getR1C1Formula--) , vous pouvez utiliser la méthode [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) :

Ensuite, si vous essayez de lire les valeurs des cellules B2 et C2, elles seront calculées :
```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```


## **Constantes logiques**
Vous pouvez utiliser des constantes logiques telles que *FALSE* et *TRUE* dans les formules de cellules :
```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// la valeur contient le booléen "false"


```


## **Constantes numériques**
Des nombres peuvent être utilisés en notation décimale ou scientifique pour créer une formule du tableau de données du graphique :
```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```


## **Constantes de chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique utilisée telle quelle et qui ne change pas. Les constantes de chaîne peuvent être : des dates, des textes, des nombres, etc. :
```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```


## **Constantes d’erreur**
Parfois il n’est pas possible de calculer le résultat de la formule. Dans ce cas, le code d’erreur apparaît dans la cellule à la place de sa valeur. Chaque type d’erreur possède un code spécifique :

- #DIV/0! - la formule tente de diviser par zéro.
- #GETTING_DATA - peut s’afficher dans une cellule pendant que sa valeur est encore en cours de calcul.
- #N/A - l’information est manquante ou indisponible. Les raisons peuvent être : les cellules utilisées dans la formule sont vides, un caractère d’espace supplémentaire, une faute de frappe, etc.
- #NAME? - une cellule ou un autre objet de formule ne peut pas être trouvé par son nom.
- #NULL! - peut apparaître lorsqu’il y a une erreur dans la formule, par exemple : (,) ou un caractère d’espace utilisé à la place du deux‑points (:).
- #NUM! - le nombre dans la formule est invalide, trop long ou trop petit, etc.
- #REF! - référence de cellule invalide.
- #VALUE! - type de valeur inattendu. Par exemple, une chaîne affectée à une cellule numérique.
```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// la valeur contient la chaîne "#DIV/0!"
```


## **Opérateurs arithmétiques**
Vous pouvez utiliser tous les opérateurs arithmétiques dans les formules de la feuille de calcul du graphique :

|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|+ (signe plus)|Addition ou signe unaire|2 + 3|
|- (signe moins)|Soustraction ou négation|2 - 3<br>-3|
|* (astérisque)|Multiplication|2 * 3|
|/ (barre oblique)|Division|2 / 3|
|% (signe pourcentage)|Pourcentage|30%|
|^ (accent circonflexe)|Exponentiation|2 ^ 3|

*Note* : pour changer l’ordre d’évaluation, encadrez la partie de la formule à calculer en premier avec des parenthèses.

## **Opérateurs de comparaison**
Vous pouvez comparer les valeurs des cellules avec les opérateurs de comparaison. Lorsque deux valeurs sont comparées à l’aide de ces opérateurs, le résultat est une valeur logique : *TRUE* ou FALSE :

|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|= (signe égal)|Égal à|A2 = 3|
|<> (signe différent)|Différent de|A2 <> 3|
|> (signe supérieur)|Supérieur à|A2 > 3|
|>= (signe supérieur ou égal)|Supérieur ou égal à|A2 >= 3|
|< (signe inférieur)|Inférieur à|A2 < 3|
|<= (signe inférieur ou égal)|Inférieur ou égal à|A2 <= 3|

## **Références de cellules au format A1**
Les **références de cellules au format A1** sont utilisées pour les feuilles de calcul, où la colonne possède un identifiant alphabétique (par ex. "*A*") et la ligne un identifiant numérique (par ex. "*1*"). Les références au format A1 peuvent être utilisées de la manière suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue|Relative|Mixte|
|Cellule|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Ligne|$2:$2|2:2|-|
|Colonne|$A:$A|A:A|-|
|Plage|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Voici un exemple d’utilisation d’une référence de cellule au format A1 dans une formule :
```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");
```


## **Références de cellules au format R1C1**
Les **références de cellules au format R1C1** sont utilisées pour les feuilles de calcul, où la ligne et la colonne possèdent toutes deux un identifiant numérique. Les références au format R1C1 peuvent être utilisées de la manière suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue|Relative|Mixte|
|Cellule|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne|R2|R[2]|-|
|Colonne|C3|C[3]|-|
|Plage|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Voici un exemple d’utilisation d’une référence de cellule au format R1C1 dans une formule :
```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **Fonctions prédéfinies**
Il existe des fonctions prédéfinies qui peuvent être utilisées dans les formules pour simplifier leur implémentation. Ces fonctions encapsulent les opérations les plus couramment utilisées, comme :

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (système de dates 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (forme de référence)
- LOOKUP (forme vectorielle)
- MATCH (forme vectorielle)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Les fichiers Excel externes sont-ils pris en charge comme source de données pour un graphique avec des formules ?**

Oui. Aspose.Slides prend en charge les classeurs externes comme [source de données d’un graphique](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatasourcetype/), ce qui vous permet d’utiliser des formules à partir d’un XLSX situé en dehors de la présentation.

**Les formules du graphique peuvent‑elles référencer des feuilles du même classeur par leur nom ?**

Oui. Les formules suivent le modèle de référence standard d’Excel, vous pouvez donc référencer d’autres feuilles du même classeur ou d’un classeur externe. Pour les références externes, indiquez le chemin et le nom du classeur en utilisant la syntaxe Excel.