---
title: Appliquer les formules de feuille de calcul de graphique dans les présentations sur Android
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/androidjava/chart-worksheet-formulas/
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
- constante d’erreur
- constante arithmétique
- opérateur de comparaison
- style A1
- style R1C1
- fonction prédéfinie
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Appliquer des formules de style Excel dans Aspose.Slides pour Android via les feuilles de travail de graphiques Java et automatiser les rapports dans les fichiers PPT et PPTX."
---

## **À propos des formules de feuille de calcul de graphique dans les présentations**
**Feuille de calcul du graphique** (ou feuille de travail du graphique) dans une présentation est la source de données du graphique. La feuille de calcul du graphique contient les données qui sont représentées graphiquement sur le graphique. Lorsque vous créez un graphique dans PowerPoint, la feuille de calcul associée à ce graphique est également créée automatiquement. La feuille de calcul du graphique est créée pour tous les types de graphiques : graphique en courbes, graphique à barres, graphique en anneau, graphique circulaire, etc. Pour voir la feuille de calcul du graphique dans PowerPoint, double‑cliquez sur le graphique :

![todo:image_alt_text](chart-worksheet-formulas_1.png)


La feuille de calcul du graphique contient les noms des éléments du graphique (Nom de catégorie : *Category1*, Nom de série) et un tableau avec des données numériques correspondant à ces catégories et séries. Par défaut, lorsqu’on crée un nouveau graphique, les données de la feuille de calcul du graphique sont initialisées avec les données par défaut. Vous pouvez ensuite modifier les données du tableau manuellement dans la feuille de calcul.

En général, le graphique représente des données complexes (par ex. analyses financières, analyses scientifiques), avec des cellules calculées à partir des valeurs d’autres cellules ou d’autres données dynamiques. Calculer manuellement la valeur d’une cellule et la coder en dur rend difficile toute modification ultérieure. Si vous modifiez la valeur d’une cellule donnée, toutes les cellules qui en dépendent devront également être mises à jour. De plus, les données du tableau peuvent dépendre des données d’autres tableaux, créant un schéma de données de présentation complexe qui doit pouvoir être mis à jour de façon simple et flexible.

**La formule de feuille de calcul du graphique** dans une présentation est une expression permettant de calculer et de mettre à jour automatiquement les données de la feuille de calcul du graphique. La formule de feuille de calcul définit la logique de calcul des données pour une cellule donnée ou un ensemble de cellules. Une formule de feuille de calcul est une formule mathématique ou logique qui utilise : des références de cellules, des fonctions mathématiques, des opérateurs logiques, des opérateurs arithmétiques, des fonctions de conversion, des constantes littérales, etc. La définition de la formule est écrite dans une cellule, qui ne contient donc pas une valeur simple. La formule calcule la valeur et la renvoie, puis cette valeur est affectée à la cellule. Les formules de feuille de calcul du graphique dans les présentations sont en fait les mêmes que les formules Excel, et les mêmes fonctions, opérateurs et constantes par défaut sont prises en charge pour leur implémentation.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) la feuille de calcul du graphique est représentée par la méthode
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) du type
[**IChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook).
Une formule de feuille de calcul peut être affectée et modifiée avec la méthode
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-).
Les fonctionnalités suivantes sont prises en charge pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d’erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellules au style A1
- Références de cellules au style R1C1
- Fonctions prédéfinies


Typiquement, les feuilles de calcul stockent les dernières valeurs calculées des formules. Si, après le chargement de la présentation, les données du graphique n’ont pas été modifiées, la méthode [**IChartDataCell.getValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getValue--) renvoie ces valeurs lors de la lecture. En revanche, si les données de la feuille de calcul ont été modifiées, la lecture de la propriété **ChartDataCell.Value** lève l’exception [**CellUnsupportedDataException**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CellUnsupportedDataException) pour les formules non prises en charge. Cela s’explique par le fait que, lorsque les formules sont analysées avec succès, les dépendances des cellules sont déterminées et la validité des dernières valeurs est vérifiée. En revanche, si la formule ne peut pas être analysée, la validité de la valeur de la cellule ne peut pas être garantie.

## **Ajouter une formule de feuille de calcul du graphique à une présentation**
Tout d’abord, ajoutez un graphique à la première diapositive d’une nouvelle présentation avec
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-).
La feuille de calcul du graphique est créée automatiquement et peut être accédée avec la méthode
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
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) du type **Object**, ce qui signifie que vous pouvez affecter n’importe quelle valeur à cette propriété :
```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```


Ensuite, pour écrire une formule dans la cellule, utilisez la méthode
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) :

*Note* : la méthode [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) sert à définir des références de cellules au style A1.

Pour définir la référence de cellule [R1C1Formula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--), utilisez la méthode [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) :

Ensuite, si vous essayez de lire les valeurs des cellules B2 et C2, elles seront calculées :
```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```


## **Constantes logiques**
Vous pouvez utiliser des constantes logiques telles que *FALSE* et *TRUE* dans les formules de cellules :
```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // la valeur contient le booléen "false"
```


## **Constantes numériques**
Les nombres peuvent être utilisés en notation décimale ou scientifique pour créer des formules de feuille de calcul du graphique :
```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **Constantes de chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique utilisée telle quelle et qui ne change pas. Les constantes de chaîne peuvent être : des dates, des textes, des nombres, etc. :
```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **Constantes d’erreur**
Parfois il n’est pas possible de calculer le résultat de la formule. Dans ce cas, le code d’erreur est affiché dans la cellule à la place de sa valeur. Chaque type d’erreur possède un code spécifique :

- #DIV/0! – la formule tente de diviser par zéro.
- #GETTING_DATA – peut être affiché dans une cellule pendant que sa valeur est en cours de calcul.
- #N/A – l’information est manquante ou indisponible. Parmi les raisons possibles : les cellules utilisées dans la formule sont vides, un espace supplémentaire, une faute de frappe, etc.
- #NAME? – une cellule ou un autre objet de formule ne peut pas être trouvé par son nom.
- #NULL! – peut apparaître lorsqu’il y a une erreur dans la formule, par ex. : (,) ou un espace utilisé à la place d’un deux‑points (:).
- #NUM! – le nombre dans la formule est invalide, trop grand ou trop petit, etc.
- #REF! – référence de cellule invalide.
- #VALUE! – type de valeur inattendu. Par exemple, une chaîne affectée à une cellule numérique.
```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // la valeur contient la chaîne "#DIV/0!"
```


## **Opérateurs arithmétiques**
Vous pouvez utiliser tous les opérateurs arithmétiques dans les formules de la feuille de calcul du graphique :

|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|+ (signe plus)|Addition ou signe plus unaire|2 + 3|
|- (signe moins)|Soustraction ou négation|2 - 3<br>-3|
|* (astérisque)|Multiplication|2 * 3|
|/ (barre oblique)|Division|2 / 3|
|% (pourcentage)|Pourcentage|30%|
|^ (accent circonflexe)|Exponentiation|2 ^ 3|

*Note* : pour modifier l’ordre d’évaluation, encadrez la partie de la formule à calculer en premier avec des parenthèses.

## **Opérateurs de comparaison**
Vous pouvez comparer les valeurs de cellules avec les opérateurs de comparaison. Lorsque deux valeurs sont comparées à l’aide de ces opérateurs, le résultat est une valeur logique, soit *TRUE* soit FALSE :

|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|= (égal)|Égal à|A2 = 3|
|<> (différent)|Différent de|A2 <> 3|
|> (supérieur)|Supérieur à|A2 > 3|
|>= (supérieur ou égal)|Supérieur ou égal à|A2 >= 3|
|< (inférieur)|Inférieur à|A2 < 3|
|<= (inférieur ou égal)|Inférieur ou égal à|A2 <= 3|

## **Références de cellules au style A1**
**Les références de cellules au style A1** sont utilisées pour les feuilles de calcul où la colonne possède un identifiant alphabétique (par ex. * A*) et la ligne un identifiant numérique (par ex. *1*). Les références de cellules au style A1 peuvent être employées de la façon suivante :

|**Référence de cellule**|**Exemple**| | |
| :- | :- | :- | :- |
| |Absolue|Relative|Mixte|
|Cellule|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Ligne|$2:$2|2:2|-|
|Colonne|$A:$A|A:A|-|
|Plage|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Voici un exemple d’utilisation d’une référence de cellule au style A1 dans une formule :
```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **Références de cellules au style R1C1**
**Les références de cellules au style R1C1** sont utilisées pour les feuilles de calcul où la ligne et la colonne possèdent toutes deux des identifiants numériques. Les références de cellules au style R1C1 peuvent être employées de la façon suivante :

|**Référence de cellule**|**Exemple**| | |
| :- | :- | :- | :- |
| |Absolue|Relative|Mixte|
|Cellule|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne|R2|R[2]|-|
|Colonne|C3|C[3]|-|
|Plage|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Voici un exemple d’utilisation d’une référence de cellule au style R1C1 dans une formule :
```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **Fonctions prédéfinies**
Il existe des fonctions prédéfinies qui peuvent être utilisées dans les formules pour simplifier leur implémentation. Ces fonctions encapsulent les opérations les plus couramment utilisées, telles que :

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

**Les fichiers Excel externes sont‑ils pris en charge comme source de données pour un graphique avec des formules ?**

Oui. Aspose.Slides prend en charge les classeurs externes en tant que [source de données du graphique](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdatasourcetype/), ce qui vous permet d’utiliser des formules provenant d’un fichier XLSX hors de la présentation.

**Les formules de graphique peuvent‑elles référencer des feuilles du même classeur par le nom de la feuille ?**

Oui. Les formules suivent le modèle de référence standard d’Excel, vous pouvez donc référencer d’autres feuilles du même classeur ou d’un classeur externe. Pour les références externes, incluez le chemin d’accès et le nom du classeur en utilisant la syntaxe Excel.