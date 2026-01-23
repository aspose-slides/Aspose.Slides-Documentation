---
title: Appliquer les formules de feuille de calcul de graphique dans les présentations avec PHP
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/php-java/chart-worksheet-formulas/
keywords:
- feuille de calcul de graphique
- feuille de travail du graphique
- formule de graphique
- formule de feuille de calcul
- formule de feuille de calcul
- source de données
- constante logique
- constante numérique
- constante de chaîne
- constante d’erreur
- constante arithmétique
- opérateur de comparaison
- style A1
- style R1C1
- fonction prédéfinie
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Appliquer des formules de type Excel dans Aspose.Slides pour PHP via les feuilles de calcul de graphiques Java et automatiser les rapports dans les fichiers PPT et PPTX."
---

## **À propos des formules de feuille de calcul de graphique dans les présentations**
**Feuille de calcul du graphique** (ou feuille de calcul du graphique) dans la présentation est la source de données du graphique. La feuille de calcul du graphique contient des données, qui sont représentées sur le graphique de manière graphique. Lorsque vous créez un graphique dans PowerPoint, la feuille de calcul associée à ce graphique est également créée automatiquement. La feuille de calcul du graphique est créée pour tous les types de graphiques : graphique en courbes, graphique à barres, graphique en rayons, graphique circulaire, etc. Pour voir la feuille de calcul du graphique dans PowerPoint, vous devez double‑cliquer sur le graphique :

![todo:image_alt_text](chart-worksheet-formulas_1.png)

La feuille de calcul du graphique contient les noms des éléments du graphique (Nom de catégorie : *Category1*, Nom de série) et un tableau avec des données numériques appropriées à ces catégories et séries. Par défaut, lorsque vous créez un nouveau graphique, les données de la feuille de calcul du graphique sont définies avec les données par défaut. Vous pouvez ensuite modifier les données de la feuille de calcul dans la feuille manuellement.

Habituellement, le graphique représente des données complexes (par exemple des analystes financiers, des analystes scientifiques), comportant des cellules calculées à partir des valeurs d'autres cellules ou d'autres données dynamiques. Calculer manuellement la valeur d'une cellule et la coder en dur dans la cellule rend difficile sa modification ultérieure. Si vous modifiez la valeur d'une certaine cellule, toutes les cellules qui en dépendent devront également être mises à jour. De plus, les données du tableau peuvent dépendre des données d'autres tableaux, créant un schéma de données de présentation complexe qui doit être mis à jour de manière facile et flexible.

**Formule de feuille de calcul du graphique** dans la présentation est une expression permettant de calculer et de mettre à jour automatiquement les données de la feuille de calcul du graphique. La formule de la feuille de calcul définit la logique de calcul des données pour une cellule donnée ou un ensemble de cellules. Une formule de feuille de calcul est une formule mathématique ou logique, qui utilise : des références de cellules, des fonctions mathématiques, des opérateurs logiques, des opérateurs arithmétiques, des fonctions de conversion, des constantes de chaîne, etc. La définition de la formule est écrite dans une cellule, et cette cellule ne contient pas une simple valeur. La formule de la feuille de calcul calcule la valeur et la renvoie, puis cette valeur est assignée à la cellule. Les formules de feuille de calcul du graphique dans les présentations sont en fait les mêmes que les formules Excel, et les mêmes fonctions, opérateurs et constantes par défaut sont prises en charge pour leur implémentation.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) la feuille de calcul du graphique est représentée par la méthode [**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getChartDataWorkbook) du type [**ChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Une formule de feuille de calcul peut être affectée et modifiée avec la méthode [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula). Les fonctionnalités suivantes sont prises en charge pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d’erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellules de style A1
- Références de cellules de style R1C1
- Fonctions prédéfinies

Typiquement, les feuilles de calcul stockent les dernières valeurs calculées des formules. Si, après le chargement de la présentation, les données du graphique n'ont pas été modifiées, la méthode [**ChartDataCell::getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#getValue) renvoie ces valeurs lors de la lecture. En revanche, si les données de la feuille de calcul ont été modifiées, lors de la lecture de la valeur, elle génère l'exception [**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException) pour les formules non prises en charge. En effet, lorsque les formules sont correctement analysées, les dépendances des cellules sont déterminées et la validité des dernières valeurs est vérifiée. Mais, si la formule ne peut pas être analysée, la validité de la valeur de la cellule ne peut pas être garantie.

## **Ajouter une formule de feuille de calcul de graphique à une présentation**
Tout d'abord, ajoutez un graphique à la première diapositive d'une nouvelle présentation avec [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart).  
La feuille de calcul du graphique est créée automatiquement et peut être accédée avec la méthode [**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getChartDataWorkbook) :
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


Écrivons quelques valeurs dans les cellules avec la méthode [**ChartDataCell::setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) du type **Object**, ce qui signifie que vous pouvez définir n'importe quelle valeur :
```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```


Ensuite, pour écrire une formule dans la cellule, vous pouvez utiliser la méthode [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula).

*Note* : la méthode [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula) est utilisée pour définir des références de cellules de style A1.

Pour définir une formule en style R1C1, vous pouvez utiliser la méthode [**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

Ensuite, si vous essayez de lire les valeurs des cellules B2 et C2, elles seront calculées :
```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```


## **Constantes logiques**
Vous pouvez utiliser des constantes logiques telles que *FALSE* et *TRUE* dans les formules des cellules :
```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// la valeur contient le booléen "false"
```


## **Constantes numériques**
Les nombres peuvent être utilisés en notation décimale ou scientifique pour créer une formule de feuille de calcul du graphique :
```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");
```


## **Constantes de chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique utilisée telle quelle et qui ne change pas. Les constantes de chaîne peuvent être : dates, textes, nombres, etc. :
```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```


## **Constantes d’erreur**
Parfois il n'est pas possible de calculer le résultat avec la formule. Dans ce cas, le code d’erreur est affiché dans la cellule à la place de sa valeur. Chaque type d’erreur possède un code spécifique :

- #DIV/0! - la formule tente de diviser par zéro.
- #GETTING_DATA - peut être affiché dans une cellule, pendant que sa valeur est encore en cours de calcul.
- #N/A - l'information est manquante ou indisponible. Certaines raisons peuvent être : les cellules utilisées dans la formule sont vides, un caractère d'espace supplémentaire, une faute de frappe, etc.
- #NAME? - une certaine cellule ou d'autres objets de formule ne peuvent pas être trouvés par leur nom.
- #NULL! - peut apparaître lorsqu'il y a une erreur dans la formule, comme : (,) ou un caractère d'espace utilisé à la place d'un deux‑points (:).
- #NUM! - le nombre dans la formule peut être invalide, trop grand ou trop petit, etc.
- #REF! - référence de cellule invalide.
- #VALUE! - type de valeur inattendu. Par exemple, une valeur chaîne assignée à une cellule numérique.
```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// la valeur contient la chaîne "#DIV/0!"


```


## **Opérateurs arithmétiques**
|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|+ (signe plus)|Addition ou plus unaire|2 + 3|
|- (signe moins)|Soustraction ou négation|2 - 3<br>-3|
|* (astérisque)|Multiplication|2 * 3|
|/ (slash)|Division|2 / 3|
|% (signe pourcentage)|Pourcentage|30%|
|^ (caret)|Exponentiation|2 ^ 3|

*Note* : pour modifier l’ordre d’évaluation, encadrez la partie de la formule à calculer en premier avec des parenthèses.

## **Opérateurs de comparaison**
|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|= (signe égal)|Égal à|A2 = 3|
|<> (signe différent)|Différent de|A2 <> 3|
|> (signe plus grand)|Supérieur à|A2 > 3|
|>= (signe supérieur ou égal)|Supérieur ou égal à|A2 >= 3|
|< (signe inférieur)|Inférieur à|A2 < 3|
|<= (signe inférieur ou égal)|Inférieur ou égal à|A2 <= 3|

## **Références de cellules de style A1**
Les **références de cellules de style A1** sont utilisées pour les feuilles de calcul, où la colonne possède un identifiant lettre (par ex. "*A*") et la ligne un identifiant numérique (par ex. "*1*"). Les références de cellules de style A1 peuvent être utilisées de la manière suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue|Relative|Mixte|
|Cellule|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Ligne|$2:$2|2:2|-|
|Colonne|$A:$A|A:A|-|
|Plage|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Voici un exemple d’utilisation d’une référence de cellule de style A1 dans une formule :
```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```


## **Références de cellules de style R1C1**
Les **références de cellules de style R1C1** sont utilisées pour les feuilles de calcul, où à la fois la ligne et la colonne possèdent un identifiant numérique. Les références de cellules de style R1C1 peuvent être utilisées de la manière suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue|Relative|Mixte|
|Cellule|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne|R2|R[2]|-|
|Colonne|C3|C[3]|-|
|Plage|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Voici un exemple d’utilisation d’une référence de cellule de style R1C1 dans une formule :
```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **Fonctions prédéfinies**
Il existe des fonctions prédéfinies qui peuvent être utilisées dans les formules pour simplifier leur implémentation. Ces fonctions regroupent les opérations les plus couramment utilisées, telles que :

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Les fichiers Excel externes sont-ils pris en charge comme source de données pour un graphique avec des formules ?**

Oui. Aspose.Slides prend en charge les classeurs externes comme [source de données du graphique](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatasourcetype/), ce qui vous permet d’utiliser des formules à partir d’un fichier XLSX hors de la présentation.

**Les formules de graphique peuvent-elles référencer des feuilles au sein du même classeur par leur nom ?**

Oui. Les formules suivent le modèle de référence standard d’Excel, de sorte que vous pouvez référencer d’autres feuilles du même classeur ou d’un classeur externe. Pour les références externes, incluez le chemin et le nom du classeur en utilisant la syntaxe Excel.