---
title: Formules de Feuille de Calcul de Graphique
type: docs
weight: 70
url: /net/chart-worksheet-formulas/
keywords: "Feuille de calcul de graphique, formule de graphique, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Feuille de calcul de graphique et formule dans la présentation PowerPoint en C# ou .NET"
---


## **À propos de la Formule de Feuille de Calcul de Graphique dans la Présentation**
**Feuille de calcul de graphique** (ou feuille de calcul de graphique) dans la présentation est la source de données du graphique. La feuille de calcul de graphique contient des données, qui sont représentées sur le graphique de manière graphique. Lorsque vous créez un graphique dans PowerPoint, la feuille de travail associée à ce graphique est également créée automatiquement. La feuille de calcul de graphique est créée pour tous les types de graphiques : graphique linéaire, graphique à barres, graphique en sunburst, graphique circulaire, etc. Pour voir la feuille de calcul de graphique dans PowerPoint, vous devez double-cliquer sur le graphique :

![todo:image_alt_text](chart-worksheet-formulas_1.png)



La feuille de calcul de graphique contient les noms des éléments de graphique (Nom de catégorie : *Catégorie1*, Nom de série) et un tableau avec des données numériques appropriées à ces catégories et séries. Par défaut, lorsque vous créez un nouveau graphique - les données de la feuille de calcul de graphique sont définies avec les données par défaut. Ensuite, vous pouvez changer les données de la feuille de calcul dans la feuille de travail manuellement.

En général, le graphique représente des données compliquées (par exemple, analystes financiers, analystes scientifiques), ayant des cellules qui sont calculées à partir des valeurs d'autres cellules ou d'autres données dynamiques. Calculer manuellement la valeur d'une cellule et la coder en dur dans la cellule rend difficile son changement à l'avenir. Si vous changez la valeur d'une certaine cellule, toutes les cellules qui en dépendent devront également être mises à jour. De plus, les données du tableau peuvent dépendre des données d'autres tableaux, créant un schéma de données de présentation complexe avec un besoin d'être mis à jour de manière facile et flexible.

**La formule de feuille de calcul de graphique** dans la présentation est une expression permettant de calculer et de mettre à jour automatiquement les données de la feuille de calcul de graphique. La formule de la feuille de calcul définit la logique de calcul des données pour une certaine cellule ou un ensemble de cellules. La formule de la feuille de calcul est une formule mathématique ou une formule logique, qui utilise : des références de cellules, des fonctions mathématiques, des opérateurs logiques, des opérateurs arithmétiques, des fonctions de conversion, des constantes de chaîne, etc. La définition de la formule est écrite dans une cellule, et cette cellule ne contient pas une valeur simple. La formule de la feuille de calcul calcule la valeur et la renvoie, puis cette valeur est attribuée à la cellule. Les formules de la feuille de calcul de graphique dans les présentations sont en fait les mêmes que les formules Excel, et il existe les mêmes fonctions, opérateurs et constantes par défaut pris en charge pour leur mise en œuvre.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/net/), la feuille de calcul de graphique est représentée par la propriété 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) du type 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook). 
La formule de la feuille de calcul peut être attribuée et modifiée avec la propriété 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula). 
La fonctionnalité suivante est prise en charge pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d'erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellules au format A1
- Références de cellules au format R1C1
- Fonctions prédéfinies



En général, les feuilles de calcul stockent les dernières valeurs de formule calculées. Si, après le chargement de la présentation, les données du graphique n'ont pas été modifiées - la propriété **IChartDataCell.Value** renvoie ces valeurs lors de la lecture. Mais, si les données de la feuille de calcul ont été modifiées, lors de la lecture de la propriété **ChartDataCell.Value**, elle génère l'exception **CellUnsupportedDataException** pour les formules non prises en charge. Cela est dû au fait que lorsque les formules sont analysées avec succès, les dépendances des cellules sont déterminées et l'exactitude des dernières valeurs est déterminée. Mais, si la formule ne peut pas être analysée, l'exactitude de la valeur de la cellule ne peut pas être garantie.
## **Ajouter une Formule de Feuille de Calcul de Graphique à la Présentation**
Tout d'abord, ajoutez un graphique avec quelques données d'exemple à la première diapositive d'une nouvelle présentation avec 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1). 
La feuille de calcul du graphique est automatiquement créée et peut être accédée avec la propriété 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) :



``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```



Écrivons quelques valeurs dans les cellules avec la propriété 
[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value) de type **Object**, ce qui signifie que vous pouvez définir n'importe quelle valeur pour la propriété :



``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```



Maintenant, pour écrire une formule dans la cellule, vous pouvez utiliser la propriété 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) :

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Remarque* : la propriété [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) est utilisée pour définir les références de cellules au format A1. 



Pour définir la référence de cellule [R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula), vous pouvez utiliser la propriété [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) :

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Ensuite, utilisez la méthode [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) pour calculer toutes les formules dans le classeur et mettre à jour les valeurs des cellules correspondantes :



``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```


## **Constantes Logiques**
Vous pouvez utiliser des constantes logiques telles que *FALSE* et *TRUE* dans les formules de cellules :




## **Constantes Numériques**
Les nombres peuvent être utilisés en notations communes ou scientifiques pour créer des formules de feuille de calcul de graphique :




## **Constantes de Chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique qui est utilisée telle quelle et ne change pas. Les constantes de chaîne peuvent être : des dates, des textes, des nombres, etc. :




## **Constantes d'Erreur**
Parfois, il n'est pas possible de calculer le résultat de la formule. Dans ce cas, le code d'erreur est affiché dans la cellule au lieu de sa valeur. Chaque type d'erreur a un code spécifique :

- #DIV/0! - la formule essaie de diviser par zéro.
- #GETTING_DATA - peut être affiché dans une cellule, tandis que sa valeur est encore en cours de calcul.
- #N/A - les informations font défaut ou ne sont pas disponibles. Certaines raisons peuvent être : les cellules utilisées dans la formule sont vides, un caractère d'espace supplémentaire, une faute d'orthographe, etc.
- #NAME? - une certaine cellule ou d'autres objets de formule ne peuvent pas être trouvés par leur nom. 
- #NULL! - peut apparaître lorsqu'il y a une erreur dans la formule, comme :  (,) ou un caractère d'espace utilisé à la place d'un deux-points (:).
- #NUM! - le numérique dans la formule peut être invalide, trop long ou trop petit, etc.
- #REF! - référence de cellule invalide.
- #VALUE! - type de valeur inattendu. Par exemple, une valeur de chaîne définie sur une cellule numérique.




## **Opérateurs Arithmétiques**
Vous pouvez utiliser tous les opérateurs arithmétiques dans les formules de feuille de calcul de graphique :



|**Opérateur** |**Signification** |**Exemple**|
| :- | :- | :- |
|+ (signe plus) |Addition ou plus unaire|2 + 3|
|- (signe moins) |Soustraction ou négation |2 - 3<br>-3|
|* (astérisque)|Multiplication |2 * 3|
|/ (barre oblique)|Division |2 / 3|
|% (signe de pourcentage) |Pourcentage |30%|
|^ (accent circonflexe) |Exponentiation |2 ^ 3|


*Remarque* : Pour changer l'ordre d'évaluation, enveloppez entre parenthèses la partie de la formule à calculer en premier.


## **Opérateurs de Comparaison**
Vous pouvez comparer les valeurs des cellules avec les opérateurs de comparaison. Lorsque deux valeurs sont comparées en utilisant ces opérateurs, le résultat est une valeur logique soit *TRUE* soit FALSE :



|**Opérateur** |**Signification** |**Signification** |
| :- | :- | :- |
|= (signe égal) |Égal à |A2 = 3|
|<> (signe non égal) |Pas égal à|A2 <> 3|
|> (signe supérieur à) |Supérieur à|A2 > 3|
|>= (signe supérieur ou égal à) |Supérieur ou égal à|A2 >= 3|
|< (signe inférieur à)|Inférieur à|A2 < 3|
|<= (signe inférieur ou égal à)|Inférieur ou égal à|A2 <= 3|

## **Références de Cellules au Format A1**
**Les références de cellules au format A1** sont utilisées pour les feuilles de calcul, où la colonne a un identifiant de lettre (par exemple, "*A*") et la ligne a un identifiant numérique (par exemple, "*1*"). Les références de cellules au format A1 peuvent être utilisées de la manière suivante :



|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue |Relative |Mixte|
|Cellule |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Ligne |$2:$2 |2:2 |-|
|Colonne |$A:$A |A:A |-|
|Plage |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Voici un exemple de la façon d'utiliser la référence de cellule au format A1 dans la formule :




## **Références de Cellules au Format R1C1**
**Les références de cellules au format R1C1** sont utilisées pour les feuilles de calcul, où à la fois une ligne et une colonne ont l'identifiant numérique. Les références de cellules au format R1C1 peuvent être utilisées de la manière suivante :



|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue |Relative |Mixte|
|Cellule |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne |R2|R[2]|-|
|Colonne |C3|C[3]|-|
|Plage |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Voici un exemple de la façon d'utiliser la référence de cellule au format A1 dans la formule :




## **Fonctions Prédéfinies**
Il existe des fonctions prédéfinies qui peuvent être utilisées dans les formules pour simplifier leur mise en œuvre. Ces fonctions encapsulent les opérations les plus couramment utilisées, comme : 

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