---
title: Appliquer les formules de feuille de travail du graphique dans les présentations en .NET
linktitle: Formules de feuille de travail
type: docs
weight: 70
url: /fr/net/chart-worksheet-formulas/
keywords:
  - feuille de calcul du graphique
  - feuille de travail du graphique
  - formule du graphique
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
  - .NET
  - C#
  - Aspose.Slides
description: Appliquer des formules de type Excel dans Aspose.Slides pour les feuilles de travail de graphiques .NET et automatiser les rapports dans les fichiers PPT et PPTX.
---

## **À propos de la formule de feuille de calcul de graphique dans une présentation**
**Feuille de calcul du graphique** (ou feuille de travail du graphique) dans une présentation est la source de données du graphique. La feuille de calcul du graphique contient les données, qui sont représentées sur le graphique de manière graphique. Lorsque vous créez un graphique dans PowerPoint, la feuille de travail associée à ce graphique est également créée automatiquement. La feuille de travail du graphique est créée pour tous les types de graphiques : graphique en courbes, graphique à barres, graphique en secteurs, graphique en anneau, etc. Pour voir la feuille de calcul du graphique dans PowerPoint, vous devez double‑cliquer sur le graphique :

![todo:image_alt_text](chart-worksheet-formulas_1.png)



La feuille de calcul du graphique contient les noms des éléments du graphique (Nom de catégorie : *Category1*, Nom de série) et un tableau avec des données numériques correspondant à ces catégories et séries. Par défaut, lorsque vous créez un nouveau graphique, les données de la feuille de calcul du graphique sont définies avec les données par défaut. Vous pouvez ensuite modifier les données du tableau manuellement dans la feuille de travail.

En général, le graphique représente des données complexes (par ex. : analystes financiers, analystes scientifiques), contenant des cellules calculées à partir des valeurs d’autres cellules ou d’autres données dynamiques. Calculer la valeur d’une cellule manuellement et la coder en dur dans la cellule rend difficile sa modification ultérieure. Si vous modifiez la valeur d’une certaine cellule, toutes les cellules qui en dépendent devront également être mises à jour. De plus, les données du tableau peuvent dépendre de données d’autres tableaux, créant un schéma de données de présentation complexe qui doit pouvoir être mis à jour de manière simple et flexible.

**La formule de feuille de calcul du graphique** dans une présentation est une expression permettant de calculer et de mettre à jour automatiquement les données de la feuille de calcul du graphique. La formule de la feuille de calcul définit la logique de calcul des données pour une cellule donnée ou un ensemble de cellules. Une formule de feuille de calcul est une formule mathématique ou logique, qui utilise : références de cellules, fonctions mathématiques, opérateurs logiques, opérateurs arithmétiques, fonctions de conversion, constantes de chaîne, etc. La définition de la formule est écrite dans une cellule, et cette cellule ne contient pas une simple valeur. La formule calcule la valeur et la renvoie, puis cette valeur est affectée à la cellule. Les formules de feuille de calcul du graphique dans les présentations sont en fait les mêmes que les formules Excel, et les mêmes fonctions, opérateurs et constantes par défaut sont pris en charge pour leur implémentation.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/net/) la feuille de calcul du graphique est représentée par la propriété 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) du type 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook). 
Une formule de feuille de calcul peut être affectée et modifiée avec la propriété 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula). 
Les fonctionnalités suivantes sont prises en charge pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d’erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellules de type A1
- Références de cellules de type R1C1
- Fonctions prédéfinies



En général, les feuilles de calcul stockent les dernières valeurs calculées des formules. Si, après le chargement de la présentation, les données du graphique n’ont pas changé, la propriété **IChartDataCell.Value** renvoie ces valeurs lors de la lecture. Mais, si les données de la feuille de calcul ont été modifiées, la lecture de la propriété **ChartDataCell.Value** lève l’exception **CellUnsupportedDataException** pour les formules non prises en charge. Cela provient du fait que, lorsque les formules sont analysées avec succès, les dépendances des cellules sont déterminées et la validité des dernières valeurs est confirmée. En revanche, si la formule ne peut pas être analysée, la validité de la valeur de la cellule ne peut pas être garantie.
## **Ajouter une formule de feuille de calcul du graphique à une présentation**
Tout d’abord, ajoutez un graphique avec des données d’exemple à la première diapositive d’une nouvelle présentation à l’aide de 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1). 
La feuille de travail du graphique est créée automatiquement et peut être accédée avec la propriété 
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
[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value) de type **Object**, ce qui signifie que vous pouvez affecter n’importe quelle valeur à la propriété :
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


*Remarque* : la propriété [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) est utilisée pour définir des références de cellules au format A1. 



Pour définir la référence de cellule [R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula), vous pouvez utiliser la propriété [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) :
``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```


Ensuite, utilisez la méthode [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) pour calculer toutes les formules du classeur et mettre à jour les valeurs des cellules correspondantes :
``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```



## **Constantes logiques**
Vous pouvez utiliser des constantes logiques telles que *FALSE* et *TRUE* dans les formules de cellules :




## **Constantes numériques**
Les nombres peuvent être utilisés en notation décimale ou scientifique pour créer une formule de feuille de calcul du graphique :




## **Constantes de chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique utilisée telle quelle et qui ne change pas. Les constantes de chaîne peuvent être : dates, textes, nombres, etc. :




## **Constantes d’erreur**
Parfois il n’est pas possible de calculer le résultat à l’aide de la formule. Dans ce cas, le code d’erreur est affiché dans la cellule à la place de sa valeur. Chaque type d’erreur possède un code spécifique :

- #DIV/0! - la formule tente de diviser par zéro.
- #GETTING_DATA - peut être affiché dans une cellule pendant que sa valeur est encore en cours de calcul.
- #N/A - l’information est manquante ou indisponible. Les raisons peuvent être : cellules utilisées dans la formule vides, espace supplémentaire, faute de frappe, etc.
- #NAME? - une certaine cellule ou un autre objet de formule n’a pas pu être trouvé par son nom.
- #NULL! - peut apparaître lorsqu’il y a une erreur dans la formule, par ex. : (,) ou un espace utilisé à la place d’un deux‑points (:).
- #NUM! - le nombre dans la formule est invalide, trop grand ou trop petit, etc.
- #REF! - référence de cellule non valide.
- #VALUE! - type de valeur inattendu. Par exemple, une valeur chaîne affectée à une cellule numérique.




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

*Remarque* : pour changer l’ordre d’évaluation, encadrez la partie de la formule à calculer en premier avec des parenthèses.


## **Opérateurs de comparaison**
Vous pouvez comparer les valeurs des cellules avec les opérateurs de comparaison. Lorsque deux valeurs sont comparées à l’aide de ces opérateurs, le résultat est une valeur logique *TRUE* ou *FALSE* :

|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|= (signe égal)|Égal à|A2 = 3|
|<> (signe différent)|Différent de|A2 <> 3|
|> (supérieur)|Supérieur à|A2 > 3|
|>= (supérieur ou égal)|Supérieur ou égal à|A2 >= 3|
|< (inférieur)|Inférieur à|A2 < 3|
|<= (inférieur ou égal)|Inférieur ou égal à|A2 <= 3|

## **Références de cellules de type A1**
Les **références de cellules de type A1** sont utilisées pour les feuilles de calcul, où la colonne possède un identifiant alphabétique (p. ex. : "*A*") et la ligne un identifiant numérique (p. ex. : "*1*"). Les références de type A1 peuvent être utilisées de la façon suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue|Relative|Mixte|
|Cellule|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Ligne|$2:$2|2:2|-|
|Colonne|$A:$A|A:A|-|
|Plage|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Voici un exemple d’utilisation d’une référence de cellule de type A1 dans une formule :




## **Références de cellules de type R1C1**
Les **références de cellules de type R1C1** sont utilisées pour les feuilles de calcul, où à la fois la ligne et la colonne possèdent un identifiant numérique. Les références de type R1C1 peuvent être utilisées de la façon suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue|Relative|Mixte|
|Cellule|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne|R2|R[2]|-|
|Colonne|C3|C[3]|-|
|Plage|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Voici un exemple d’utilisation d’une référence de cellule de type A1 dans une formule :




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

Oui. Aspose.Slides prend en charge les classeurs externes comme [source de données d’un graphique](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatasourcetype/), ce qui vous permet d’utiliser des formules provenant d’un fichier XLSX en dehors de la présentation.

**Les formules du graphique peuvent‑elles faire référence à des feuilles du même classeur par leur nom ?**

Oui. Les formules suivent le modèle de référence standard d’Excel, vous pouvez donc faire référence à d’autres feuilles du même classeur ou d’un classeur externe. Pour les références externes, incluez le chemin et le nom du classeur en utilisant la syntaxe Excel.