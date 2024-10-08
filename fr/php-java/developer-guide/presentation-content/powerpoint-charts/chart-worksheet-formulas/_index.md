---
title: Formules de Feuille de Calcul de Graphique
type: docs
weight: 70
url: /fr/php-java/chart-worksheet-formulas/
keywords: "équations powerpoint, formules feuille de calcul powerpoint"
description: "Équations PowerPoint et Formules de Feuille de Calcul"
---


## **À propos de la Formule de Feuille de Calcul de Graphique dans la Présentation**
La **feuille de calcul de graphique** (ou feuille de graphique) dans la présentation est la source de données du graphique. La feuille de calcul de graphique contient des données, qui sont représentées sur le graphique de manière graphique. Lorsque vous créez un graphique dans PowerPoint, la feuille de calcul associée à ce graphique est également automatiquement créée. La feuille de calcul de graphique est créée pour tous les types de graphiques : graphique linéaire, graphique à barres, graphique en soleil, graphique à secteurs, etc. Pour voir la feuille de calcul de graphique dans PowerPoint, vous devez double-cliquer sur le graphique :

![todo:image_alt_text](chart-worksheet-formulas_1.png)


La feuille de calcul de graphique contient les noms des éléments de graphique (Nom de Catégorie : *Catégorie1*, Nom de Série) et un tableau avec des données numériques appropriées à ces catégories et séries. Par défaut, lorsque vous créez un nouveau graphique - les données de la feuille de calcul du graphique sont définies avec les données par défaut. Ensuite, vous pouvez modifier les données de la feuille de calcul dans la feuille manuellement.

En général, le graphique représente des données compliquées (par exemple, des analystes financiers, des analystes scientifiques), ayant des cellules qui sont calculées à partir des valeurs des autres cellules ou d'autres données dynamiques. Calculer manuellement la valeur d'une cellule et l'encoder en dur dans la cellule rend difficile de la modifier à l'avenir. Si vous changez la valeur d'une certaine cellule, toutes les cellules qui en dépendent devront également être mises à jour. De plus, les données du tableau peuvent dépendre des données d'autres tableaux, créant un schéma de données de présentation complexe qui nécessite d'être mis à jour de manière facile et flexible.

La **formule de la feuille de calcul de graphique** dans la présentation est une expression pour calculer et mettre à jour automatiquement les données de la feuille de calcul de graphique. La formule de la feuille de calcul définit la logique de calcul des données pour une certaine cellule ou un ensemble de cellules. La formule de la feuille de calcul est une formule mathématique ou logique, qui utilise : des références de cellule, des fonctions mathématiques, des opérateurs logiques, des opérateurs arithmétiques, des fonctions de conversion, des constantes de chaîne, etc. La définition de la formule est écrite dans une cellule, et cette cellule ne contient pas une valeur simple. La formule de la feuille de calcul calcule la valeur et la renvoie, puis cette valeur est assignée à la cellule. Les formules de feuille de calcul de graphique dans les présentations sont en fait les mêmes que les formules Excel, et les mêmes fonctions, opérateurs et constantes par défaut sont prises en charge pour leur implémentation.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) la feuille de calcul de graphique est représentée par la méthode 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--) du type 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).
La formule de feuille de calcul peut être assignée et modifiée avec la méthode 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-).
La fonctionnalité suivante est prise en charge pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d'erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellule au style A1
- Références de cellule au style R1C1
- Fonctions prédéfinies


En général, les feuilles de calcul stockent les dernières valeurs de formule calculées. Si, après le chargement de la présentation, les données du graphique n'ont pas été modifiées - la méthode [**IChartDataCell.getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getValue--) retourne ces valeurs lors de la lecture. Cependant, si les données de la feuille de calcul ont été modifiées, lors de la lecture de la propriété **ChartDataCell.Value**, elle déclenche l'exception [**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException) pour les formules non supportées. Cela est dû au fait que lorsque les formules sont analysées avec succès, les dépendances des cellules sont déterminées et la justesse des dernières valeurs est déterminée. Mais, si la formule ne peut pas être analysée, la justesse de la valeur de la cellule ne peut pas être garantie.

## **Ajouter une Formule de Feuille de Calcul de Graphique à la Présentation**
Tout d'abord, ajoutez un graphique à la première diapositive d'une nouvelle présentation avec 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addChart-int-float-float-float-float-).
La feuille de calcul du graphique est automatiquement créée et peut être accédée avec la méthode 
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

Écrivons quelques valeurs dans des cellules avec la propriété [**IChartDataCell.setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setValue-java.lang.Object-) de type **Object**, ce qui signifie que vous pouvez définir n'importe quelle valeur à la propriété :

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

Maintenant, pour écrire une formule dans la cellule, vous pouvez utiliser la méthode 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) :

*Remarque* : la méthode [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) est utilisée pour définir les références de cellule au style A1. 

Pour définir la référence de cellule [R1C1Formula](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getR1C1Formula--), vous pouvez utiliser la méthode [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) :

Ensuite, si vous essayez de lire les valeurs des cellules B2 et C2, elles seront calculées :

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **Constantes Logiques**
Vous pouvez utiliser des constantes logiques telles que *FALSE* et *TRUE* dans les formules de cellules :

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// la valeur contient "false" booléen


```

## **Constantes Numériques**
Les nombres peuvent être utilisés en notations courantes ou scientifiques pour créer des formules de feuilles de calcul de graphique :

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Constantes de Chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique qui est utilisée telle quelle et ne change pas. Les constantes de chaîne peuvent être : des dates, des textes, des nombres, etc. :

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Constantes d'Erreur**
Parfois, il n'est pas possible de calculer le résultat par la formule. Dans ce cas, le code d'erreur est affiché dans la cellule au lieu de sa valeur. Chaque type d'erreur a un code spécifique :

- #DIV/0! - la formule essaie de diviser par zéro.
- #GETTING_DATA - peut être affiché dans une cellule, tandis que sa valeur est encore en cours de calcul.
- #N/A - l'information est manquante ou non disponible. Certaines raisons peuvent être : les cellules utilisées dans la formule sont vides, un espace supplémentaire, une faute de frappe, etc.
- #NAME? - une certaine cellule ou d'autres objets de formule ne peuvent pas être trouvés par leur nom. 
- #NULL! - peut apparaître lorsqu'il y a une erreur dans la formule, comme :  (,) ou un espace utilisé à la place d'un deux-points (:).
- #NUM! - le numérique dans la formule peut être invalide, trop long ou trop court, etc.
- #REF! - référence de cellule invalide.
- #VALUE! - type de valeur inattendu. Par exemple, une valeur de chaîne définie pour une cellule numérique.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// la valeur contient la chaîne "#DIV/0!"


```

## **Opérateurs Arithmétiques**
Vous pouvez utiliser tous les opérateurs arithmétiques dans les formules de feuille de calcul de graphique :

|**Opérateur** |**Sens** |**Exemple**|
| :- | :- | :- |
|+ (signe plus) |Addition ou plus unaire|2 + 3|
|- (signe moins) |Soustraction ou négation |2 - 3<br>-3|
|* (astérisque)|Multiplication |2 * 3|
|/ (barre oblique)|Division |2 / 3|
|% (signe pourcentage) |Pourcentage |30%|
|^ (accent circonflexe) |Élévation à la puissance |2 ^ 3|

*Remarque* : Pour changer l'ordre d'évaluation, enfermez entre parenthèses la partie de la formule à calculer en premier.

## **Opérateurs de Comparaison**
Vous pouvez comparer les valeurs des cellules avec les opérateurs de comparaison. Lorsque deux valeurs sont comparées à l'aide de ces opérateurs, le résultat est une valeur logique soit *TRUE* ou FALSE :

|**Opérateur** |**Sens** |**Sens** |
| :- | :- | :- |
|= (signe égal) |Égal à |A2 = 3|
|<> (signe de non égalité) |Non égal à|A2 <> 3|
|> (signe supérieur) |Supérieur à|A2 > 3|
|>= (signe supérieur ou égal) |Supérieur ou égal à|A2 >= 3|
|< (signe inférieur)|Inférieur à|A2 < 3|
|<= (signe inférieur ou égal)|Inférieur ou égal à|A2 <= 3|

## **Références de Cellule au Style A1**
Les **références de cellule au style A1** sont utilisées pour les feuilles de calcul, où la colonne a un identifiant de lettre (par exemple, "*A*") et la ligne a un identifiant numérique (par exemple, "*1*"). Les références de cellule au style A1 peuvent être utilisées de la manière suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue |Relative |Mixte|
|Cellule |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Ligne |$2:$2 |2:2 |-|
|Colonne |$A:$A |A:A |-|
|Plage |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Voici un exemple de la manière d'utiliser la référence de cellule au style A1 dans une formule :

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **Références de Cellule au Style R1C1**
Les **références de cellule au style R1C1** sont utilisées pour les feuilles de calcul, où une ligne et une colonne ont toutes deux un identifiant numérique. Les références de cellule au style R1C1 peuvent être utilisées de la manière suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue |Relative |Mixte|
|Cellule |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne |R2|R[2]|-|
|Colonne |C3|C[3]|-|
|Plage |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Voici un exemple de la manière d'utiliser la référence de cellule au style A1 dans une formule :

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **Fonctions Prédéfinies**
Il existe des fonctions prédéfinies qui peuvent être utilisées dans les formules pour simplifier leur implémentation. Ces fonctions encapsulent les opérations les plus couramment utilisées, comme : 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (système de date 1900)
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