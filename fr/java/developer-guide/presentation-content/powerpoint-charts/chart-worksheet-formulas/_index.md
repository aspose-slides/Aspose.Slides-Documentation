---
title: Appliquer les formules de feuille de calcul de graphique dans les présentations avec Java
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/java/chart-worksheet-formulas/
keywords:
- feuille de calcul du graphique
- feuille de travail du graphique
- formule de graphique
- formule de feuille de travail
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
- Java
- Aspose.Slides
description: "Appliquer des formules de type Excel dans les feuilles de calcul de graphiques Aspose.Slides pour Java et automatiser les rapports dans les fichiers PPT et PPTX."
---

## **À propos de la formule de feuille de calcul du graphique dans la présentation**
**Feuille de calcul du graphique** (ou feuille de travail du graphique) dans une présentation est la source de données du graphique. La feuille de calcul du graphique contient les données, qui sont représentées graphiquement dans le graphique. Lorsque vous créez un graphique dans PowerPoint, la feuille de travail associée à ce graphique est également créée automatiquement. La feuille de travail du graphique est créée pour tous les types de graphiques : graphique en courbes, graphique en barres, graphique en anneau, graphique circulaire, etc. Pour afficher la feuille de calcul du graphique dans PowerPoint, vous devez double‑cliquer sur le graphique :

![todo:image_alt_text](chart-worksheet-formulas_1.png)

La feuille de calcul du graphique contient les noms des éléments du graphique (Nom de catégorie : *Category1*, Nom de série) et un tableau avec des données numériques correspondant à ces catégories et séries. Par défaut, lorsqu’un nouveau graphique est créé, les données de la feuille de calcul du graphique sont initialisées avec les données par défaut. Vous pouvez ensuite modifier manuellement les données du tableau dans la feuille de travail.

En général, le graphique représente des données complexes (par ex. analystes financiers, scientifiques), avec des cellules calculées à partir des valeurs d’autres cellules ou d’autres données dynamiques. Calculer manuellement la valeur d’une cellule et la saisir en dur rend difficile sa modification ultérieure. Si vous modifiez la valeur d’une cellule donnée, toutes les cellules qui en dépendent devront également être mises à jour. De plus, les données du tableau peuvent dépendre des données d’autres tableaux, créant un schéma de données de présentation complexe qui doit pouvoir être mis à jour de façon simple et flexible.

**La formule de feuille de calcul du graphique** dans une présentation est une expression qui calcule et met à jour automatiquement les données de la feuille de calcul du graphique. La formule de feuille de calcul définit la logique de calcul des données pour une cellule ou un ensemble de cellules. Il s’agit d’une formule mathématique ou logique utilisant : références de cellules, fonctions mathématiques, opérateurs logiques, opérateurs arithmétiques, fonctions de conversion, constantes de chaîne, etc. La définition de la formule est écrite dans une cellule, et cette cellule ne contient pas une simple valeur. La formule calcule la valeur et la renvoie, puis cette valeur est affectée à la cellule. Les formules de feuille de calcul du graphique dans les présentations sont en fait les mêmes que les formules Excel, et les mêmes fonctions, opérateurs et constantes par défaut sont pris en charge pour leur implémentation.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/java/) la feuille de calcul du graphique est représentée par la méthode
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) du type
[**IChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
Une formule de feuille de calcul peut être affectée ou modifiée avec la méthode
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-).
Les fonctionnalités suivantes sont prises en charge pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d’erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellule au format A1
- Références de cellule au format R1C1
- Fonctions prédéfinies

En général, les classeurs stockent les valeurs des formules calculées en dernier. Si, après le chargement de la présentation, les données du graphique n’ont pas été modifiées, la méthode [**IChartDataCell.getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getValue--) renvoie ces valeurs lors de la lecture. En revanche, si les données de la feuille de calcul ont été modifiées, la lecture de la propriété **ChartDataCell.Value** génère l’exception [**CellUnsupportedDataException**](https://reference.aspose.com/slides/java/com.aspose.slides/CellUnsupportedDataException) pour les formules non prises en charge. En effet, lorsqu’une formule est correctement analysée, les dépendances de la cellule sont déterminées et la validité des dernières valeurs est vérifiée. Mais si la formule ne peut pas être analysée, la validité de la valeur de la cellule ne peut être garantie.

## **Ajout d’une formule de feuille de calcul du graphique à la présentation**
Tout d’abord, ajoutez un graphique à la première diapositive d’une nouvelle présentation avec
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-).
La feuille de travail du graphique est créée automatiquement et peut être obtenue avec la méthode
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) :
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


Écrivons quelques valeurs dans des cellules avec la propriété
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) de type **Object**, ce qui signifie que vous pouvez affecter n’importe quelle valeur à cette propriété :
```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```


Pour écrire une formule dans la cellule, utilisez la méthode
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) :

*Remarque* : la méthode [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) sert à définir des références de cellules au format A1.

Pour définir la référence de cellule [R1C1Formula](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getR1C1Formula--), utilisez la méthode
[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) :

Ensuite, si vous lisez les valeurs des cellules B2 et C2, elles seront calculées :
```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```


## **Constantes logiques**
Vous pouvez utiliser les constantes logiques telles que *FALSE* et *TRUE* dans les formules de cellules :
```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // la valeur contient le booléen "false"
```


## **Constantes numériques**
Les nombres peuvent être utilisés en notation décimale ou scientifique pour créer une formule de feuille de calcul du graphique :
```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **Constantes de chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique utilisée telle quelle et qui ne change pas. Les constantes de chaîne peuvent être : dates, textes, nombres, etc. :
```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **Constantes d’erreur**
Parfois il n’est pas possible de calculer le résultat d’une formule. Dans ce cas, le code d’erreur est affiché dans la cellule à la place de sa valeur. Chaque type d’erreur possède un code spécifique :

- #DIV/0! - la formule tente de diviser par zéro.
- #GETTING_DATA - peut être affiché dans une cellule pendant que sa valeur est encore en cours de calcul.
- #N/A - l’information est manquante ou indisponible. Les raisons possibles : cellules utilisées vides, espace supplémentaire, faute de frappe, etc.
- #NAME? - une cellule ou un autre objet de formule ne peut pas être trouvé par son nom.
- #NULL! - peut apparaître lorsqu’il y a une erreur dans la formule, par ex. : (,) ou un caractère espace utilisé à la place d’un deux‑points (:).
- #NUM! - le nombre dans la formule est invalide, trop grand ou trop petit, etc.
- #REF! - référence de cellule invalide.
- #VALUE! - type de valeur inattendu. Par exemple, une chaîne assignée à une cellule numérique.
```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // la valeur contient la chaîne "#DIV/0!"
```


## **Opérateurs arithmétiques**
Vous pouvez utiliser tous les opérateurs arithmétiques dans les formules de feuille de travail du graphique :

|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|+ (signe plus)|Addition ou plus unaire|2 + 3|
|- (signe moins)|Soustraction ou négation|2 - 3<br>-3|
|* (astérisque)|Multiplication|2 * 3|
|/ (slash)|Division|2 / 3|
|% (pourcentage)|Pourcentage|30%|
|^ (caret)|Exponentiation|2 ^ 3|

*Remarque* : pour modifier l’ordre d’évaluation, encadrez la partie de la formule à calculer en premier avec des parenthèses.

## **Opérateurs de comparaison**
Vous pouvez comparer les valeurs des cellules avec les opérateurs de comparaison. Lorsque deux valeurs sont comparées à l’aide de ces opérateurs, le résultat est une valeur logique : *TRUE* ou *FALSE* :

|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|= (égal)|Égal à|A2 = 3|
|<> (différent)|Différent de|A2 <> 3|
|> (supérieur)|Supérieur à|A2 > 3|
|>= (supérieur ou égal)|Supérieur ou égal à|A2 >= 3|
|< (inférieur)|Inférieur à|A2 < 3|
|<= (inférieur ou égal)|Inférieur ou égal à|A2 <= 3|

## **Références de cellules au format A1**
**Les références de cellules au format A1** sont utilisées pour les feuilles de calcul où la colonne possède un identifiant alphabétique (par ex. * A *) et la ligne un identifiant numérique (par ex. * 1 *). Elles peuvent être utilisées de la façon suivante :

|**Référence**|**Exemple**| | |
| :- | :- | :- | :- |
| |Absolue|Relative|Mixte|
|Cellule|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Ligne|$2:$2|2:2|-|
|Colonne|$A:$A|A:A|-|
|Plage|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Voici un exemple d’utilisation d’une référence de cellule au format A1 dans une formule :
```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **Références de cellules au format R1C1**
**Les références de cellules au format R1C1** sont utilisées pour les feuilles de calcul où à la fois les lignes et les colonnes ont un identifiant numérique. Elles peuvent être utilisées de la façon suivante :

|**Référence**|**Exemple**| | |
| :- | :- | :- | :- |
| |Absolue|Relative|Mixte|
|Cellule|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne|R2|R[2]|-|
|Colonne|C3|C[3]|-|
|Plage|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Voici un exemple d’utilisation d’une référence de cellule au format R1C1 dans une formule :
```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **Fonctions prédéfinies**
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

## **FAQ**

**Les fichiers Excel externes sont-ils pris en charge comme source de données pour un graphique avec des formules ?**

Oui. Aspose.Slides prend en charge les classeurs externes comme [source de données d’un graphique](https://reference.aspose.com/slides/java/com.aspose.slides/chartdatasourcetype/), ce qui vous permet d’utiliser des formules provenant d’un fichier XLSX hors de la présentation.

**Les formules de graphique peuvent‑elles référencer des feuilles du même classeur par leur nom ?**

Oui. Les formules suivent le modèle de référence Excel standard, vous pouvez donc référencer d’autres feuilles du même classeur ou d’un classeur externe. Pour les références externes, incluez le chemin et le nom du classeur en utilisant la syntaxe Excel.