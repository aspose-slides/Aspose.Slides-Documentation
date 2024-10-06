---
title: Formules de Tableau de Bord
type: docs
weight: 70
url: /androidjava/chart-worksheet-formulas/
keywords: "équations powerpoint, formules de tableau powerpoint"
description: "Équations et Formules de Tableau PowerPoint"
---


## **À propos des Formules de Tableau de Bord dans les Présentations**
Le **tableau de bord** (ou feuille de calcul de tableau) dans une présentation est la source de données du tableau. Le tableau de bord contient des données, qui sont représentées de manière graphique sur le tableau. Lorsque vous créez un tableau dans PowerPoint, la feuille de calcul associée à ce tableau est également créée automatiquement. La feuille de calcul de tableau est créée pour tous les types de tableaux : tableau linéaire, tableau à barres, tableau en rayon, tableau circulaire, etc. Pour voir le tableau de bord dans PowerPoint, vous devez double-cliquer sur le tableau :

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Le tableau de bord contient les noms des éléments du tableau (Nom de Catégorie : *Catégorie1*, Nom de Série) et un tableau avec des données numériques appropriées à ces catégories et séries. Par défaut, lorsque vous créez un nouveau tableau, les données du tableau de bord sont définies avec les données par défaut. Vous pouvez ensuite modifier les données du tableau dans la feuille de calcul manuellement.

En général, le tableau représente des données compliquées (par exemple, des analystes financiers, des analystes scientifiques), ayant des cellules qui sont calculées à partir des valeurs dans d'autres cellules ou d'autres données dynamiques. Calculer manuellement la valeur d'une cellule et l'encoder en dur dans la cellule rend difficile son changement à l'avenir. Si vous changez la valeur d'une certaine cellule, toutes les cellules qui en dépendent devront également être mises à jour. De plus, les données de la table peuvent dépendre des données d'autres tables, créant un schéma de données de présentation complexe nécessitant d'être mis à jour de manière facile et flexible.

La **formule de tableau de bord** dans une présentation est une expression pour calculer et mettre à jour automatiquement les données du tableau de bord. La formule de tableau définit la logique de calcul des données pour une certaine cellule ou un ensemble de cellules. La formule de tableau est une formule mathématique ou une formule logique, qui utilise : des références de cellules, des fonctions mathématiques, des opérateurs logiques, des opérateurs arithmétiques, des fonctions de conversion, des constantes de chaîne, etc. La définition de la formule est écrite dans une cellule, et cette cellule ne contient pas une valeur simple. La formule de tableau calcule la valeur et la renvoie, puis cette valeur est assignée à la cellule. Les formules de tableau de bord dans les présentations sont en fait les mêmes que les formules Excel, et les mêmes fonctions, opérateurs et constantes par défaut sont supportés pour leur mise en œuvre.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/), le tableau de bord est représenté par la méthode
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) du type 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook).
La formule de tableau peut être assignée et changée avec la méthode 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-).
Les fonctionnalités suivantes sont supportées pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d'erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellules au format A1
- Références de cellules au format R1C1
- Fonctions prédéfinies

En général, les feuilles de calcul stockent les dernières valeurs calculées des formules. Si, après le chargement de la présentation, les données du tableau n'ont pas été modifiées - la méthode [**IChartDataCell.getValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getValue--) renvoie ces valeurs lors de la lecture. Mais, si les données du tableau ont été modifiées, lors de la lecture de la propriété **ChartDataCell.Value**, une exception [**CellUnsupportedDataException**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CellUnsupportedDataException) pour les formules non pris en charge est lancée. Cela est dû au fait que lorsque les formules sont analysées avec succès, les dépendances des cellules sont déterminées et la véracité des dernières valeurs est déterminée. Mais, si la formule ne peut pas être analysée, la véracité de la valeur de la cellule ne peut pas être garantie.

## **Ajouter une Formule de Tableau de Bord à la Présentation**
Tout d'abord, ajoutez un tableau à la première diapositive d'une nouvelle présentation avec 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-).
La feuille de calcul du tableau est automatiquement créée et peut être accédée avec la méthode 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Écrivons quelques valeurs dans les cellules avec la propriété 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) 
de type **Object**, ce qui signifie que vous pouvez définir n'importe quelle valeur à la propriété :

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Maintenant, pour écrire une formule dans la cellule, vous pouvez utiliser la méthode 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) :

*Remarque* : la méthode [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) est utilisée pour définir des références de cellules au format A1.

Pour définir la référence de cellule [R1C1Formula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--), vous pouvez utiliser la méthode [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) :

Ensuite, si vous essayez de lire les valeurs des cellules B2 et C2, elles seront calculées :

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Constantes Logiques**
Vous pouvez utiliser des constantes logiques telles que *FALSE* et *TRUE* dans les formules de cellules :

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // la valeur contient "false" booléen
```

## **Constantes Numériques**
Les nombres peuvent être utilisés en notations communes ou scientifiques pour créer une formule de tableau de bord :

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Constantes de Chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique qui est utilisée telle quelle et ne change pas. Les constantes de chaîne peuvent être : des dates, des textes, des nombres, etc. :

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Constantes d'Erreur**
Parfois, il n'est pas possible de calculer le résultat par la formule. Dans ce cas, le code d'erreur est affiché dans la cellule au lieu de sa valeur. Chaque type d'erreur a un code spécifique :

- #DIV/0! - la formule tente de diviser par zéro.
- #GETTING_DATA - peut être affiché sur une cellule, tandis que sa valeur est encore en cours de calcul.
- #N/A - les informations sont manquantes ou non disponibles. Certaines raisons peuvent être : les cellules utilisées dans la formule sont vides, un caractère d'espace supplémentaire, une faute d'orthographe, etc.
- #NAME? - une certaine cellule ou d'autres objets de formule ne peuvent pas être trouvés par leur nom.
- #NULL! - peut apparaître lorsqu'il y a une erreur dans la formule, comme : (,) ou un caractère d'espace utilisé à la place d'un deux-points (:).
- #NUM! - le numérique dans la formule peut être invalide, trop long ou trop petit, etc.
- #REF! - référence de cellule invalide.
- #VALUE! - type de valeur inattendu. Par exemple, une valeur de chaîne définie à une cellule numérique.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // la valeur contient la chaîne "#DIV/0!"
```

## **Opérateurs Arithmétiques**
Vous pouvez utiliser tous les opérateurs arithmétiques dans les formules de feuille de calcul de tableau :

|**Opérateur** |**Signification** |**Exemple**|
| :- | :- | :- |
|+ (signe plus) |Addition ou plus unaire|2 + 3|
|- (signe moins) |Soustraction ou négation |2 - 3<br>-3|
|* (astérisque)|Multiplication |2 * 3|
|/ (barre oblique)|Division |2 / 3|
|% (signe pourcentage) |Pourcentage |30%|
|^ (accent circonflexe) |Exponentiation |2 ^ 3|

*Remarque* : Pour changer l'ordre d'évaluation, enfermez entre parenthèses la partie de la formule à calculer en premier.

## **Opérateurs de Comparaison**
Vous pouvez comparer les valeurs des cellules avec les opérateurs de comparaison. Lorsque deux valeurs sont comparées en utilisant ces opérateurs, le résultat est une valeur logique soit *TRUE* ou FALSE :

|**Opérateur** |**Signification** |**Signification** |
| :- | :- | :- |
|= (signe égal) |Égal à |A2 = 3|
|<> (signe de non égal) |Différent de|A2 <> 3|
|> (signe supérieur) |Supérieur à|A2 > 3|
|>= (signe supérieur ou égal) |Supérieur ou égal à|A2 >= 3|
|< (signe inférieur)|Inférieur à|A2 < 3|
|<= (signe inférieur ou égal)|Inférieur ou égal à|A2 <= 3|

## **Références de Cellules au Format A1**
Les **références de cellules au format A1** sont utilisées pour les feuilles de calcul, où la colonne a un identifiant de lettre (par exemple "*A*") et la ligne a un identifiant numérique (par exemple "*1*"). Les références de cellules au format A1 peuvent être utilisées de la manière suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue |Relative |Mixte|
|Cellule |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Ligne |$2:$2 |2:2 |-|
|Colonne |$A:$A |A:A |-|
|Plage |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Voici un exemple d'utilisation de la référence de cellule au format A1 dans une formule :

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **Références de Cellules au Format R1C1**
Les **références de cellules au format R1C1** sont utilisées pour les feuilles de calcul, où une ligne et une colonne ont toutes deux un identifiant numérique. Les références de cellules au format R1C1 peuvent être utilisées de la manière suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue |Relative |Mixte|
|Cellule |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne |R2|R[2]|-|
|Colonne |C3|C[3]|-|
|Plage |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Voici un exemple d'utilisation de la référence de cellule au format A1 dans une formule :

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Fonctions Prédéfinies**
Il existe des fonctions prédéfinies qui peuvent être utilisées dans les formules pour simplifier leur mise en œuvre. Ces fonctions encapsulent les opérations les plus couramment utilisées, telles que : 

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