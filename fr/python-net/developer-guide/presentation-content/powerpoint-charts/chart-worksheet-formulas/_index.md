---
title: Formules de Feuille de Calcul de Diagramme
type: docs
weight: 70
url: /python-net/chart-worksheet-formulas/
keywords: "Feuille de calcul de diagramme, formule de diagramme, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Feuille de calcul de diagramme et formule dans une présentation PowerPoint en Python"
---


## **À propos de la Formule de Feuille de Calcul de Diagramme dans une Présentation**
**Feuille de calcul de diagramme** (ou feuille de calcul de diagramme) dans une présentation est la source de données du diagramme. La feuille de calcul de diagramme contient des données, qui sont représentées sur le diagramme de manière graphique. Lorsque vous créez un diagramme dans PowerPoint, la feuille de calcul associée à ce diagramme est automatiquement créée également. La feuille de calcul de diagramme est créée pour tous les types de diagrammes : diagramme linéaire, diagramme à barres, diagramme en éventail, diagramme circulaire, etc. Pour voir la feuille de calcul de diagramme dans PowerPoint, vous devez double-cliquer sur le diagramme :

![todo:image_alt_text](chart-worksheet-formulas_1.png)



La feuille de calcul de diagramme contient les noms des éléments du diagramme (Nom de catégorie : *Catégorie1*, Nom de série) et un tableau avec des données numériques appropriées à ces catégories et séries. Par défaut, lorsque vous créez un nouveau diagramme - les données de la feuille de calcul de diagramme sont définies avec les données par défaut. Ensuite, vous pouvez changer les données de la feuille de calcul dans la feuille de calcul manuellement.

En général, le diagramme représente des données compliquées (par exemple, des analystes financiers, des analystes scientifiques), ayant des cellules qui sont calculées à partir des valeurs dans d'autres cellules ou à partir d'autres données dynamiques. Calculer manuellement la valeur d'une cellule et la coder en dur dans la cellule rend difficile son changement à l'avenir. Si vous changez la valeur d'une certaine cellule, toutes les cellules qui en dépendent devront également être mises à jour. De plus, les données du tableau peuvent dépendre des données d'autres tableaux, créant un schéma de données de présentation complexe ayant besoin d'être mis à jour de manière simple et flexible.

**La formule de la feuille de calcul de diagramme** dans une présentation est une expression pour calculer et mettre à jour automatiquement les données de la feuille de calcul de diagramme. La formule de la feuille de calcul définit la logique de calcul des données pour une certaine cellule ou un ensemble de cellules. La formule de la feuille de calcul est une formule mathématique ou une formule logique, qui utilise : références de cellules, fonctions mathématiques, opérateurs logiques, opérateurs arithmétiques, fonctions de conversion, constantes de chaîne, etc. La définition de la formule est écrite dans une cellule, et cette cellule ne contient pas une valeur simple. La formule de la feuille de calcul calcule la valeur et la renvoie, puis cette valeur est affectée à la cellule. Les formules des feuilles de calcul de diagramme dans les présentations sont en réalité les mêmes que les formules Excel, et les mêmes fonctions par défaut, opérateurs et constantes sont prises en charge pour leur mise en œuvre.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) la feuille de calcul de diagramme est représentée avec 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) propriété du type 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/). 
La formule de la feuille de calcul peut être affectée et modifiée avec la 
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) propriété. 
La fonctionnalité suivante est prise en charge pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d'erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellules de style A1
- Références de cellules de style R1C1
- Fonctions prédéfinies



En général, les feuilles de calcul conservent les dernières valeurs de formule calculées. Si après le chargement de la présentation, les données du diagramme n'ont pas été changées - la propriété **IChartDataCell.Value** retourne ces valeurs lors de la lecture. Mais, si les données de la feuille de calcul avaient été modifiées, lors de la lecture de la propriété **ChartDataCell.Value**, cela lance l'**CellUnsupportedDataException** pour les formules non prises en charge. Cela est dû au fait que lorsque les formules sont correctement analysées, les dépendances de cellules sont déterminées et la validité des dernières valeurs est déterminée. Mais, si la formule ne peut pas être analysée, la validité de la valeur de la cellule ne peut pas être garantie.
## **Ajouter une Formule de Feuille de Calcul de Diagramme à une Présentation**
Tout d'abord, ajoutez un diagramme avec quelques données d'exemple à la première diapositive d'une nouvelle présentation avec 
[add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/). 
La feuille de calcul du diagramme est automatiquement créée et peut être accessible avec la propriété 
[**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) :



```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```



Écrivons quelques valeurs dans les cellules avec la propriété 
[**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 
de type **Object**, ce qui signifie que vous pouvez définir n'importe quelle valeur à la propriété :



```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```



Maintenant pour écrire une formule dans la cellule, vous pouvez utiliser la propriété 
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) :

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Remarque* : la propriété [**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) est utilisée pour définir des références de cellules de style A1. 



Pour définir la référence de cellule [r1c1_formula](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/), vous pouvez utiliser la propriété [**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) :

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Ensuite, utilisez la méthode [**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) pour calculer toutes les formules dans le classeur et mettre à jour les valeurs des cellules correspondantes :



```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```


## **Constantes Logiques**
Vous pouvez utiliser des constantes logiques telles que *FALSE* et *TRUE* dans les formules de cellules :




## **Constantes Numériques**
Les nombres peuvent être utilisés en notations communes ou scientifiques pour créer des formules de feuille de calcul de diagramme :




## **Constantes de Chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique utilisée telle quelle et qui ne change pas. Les constantes de chaîne peuvent être : dates, textes, nombres, etc.：




## **Constantes d'Erreur**
Parfois, il n'est pas possible de calculer le résultat par la formule. Dans ce cas, le code d'erreur est affiché dans la cellule au lieu de sa valeur. Chaque type d'erreur a un code spécifique :

- #DIV/0! - la formule essaie de diviser par zéro.
- #GETTING_DATA - peut être affiché dans une cellule, tandis que sa valeur est encore en cours de calcul.
- #N/A - des informations sont manquantes ou non disponibles. Certaines raisons peuvent être : les cellules utilisées dans la formule sont vides, un caractère espace supplémentaire, une faute de frappe, etc.
- #NAME? - une certaine cellule ou d'autres objets de formule ne peuvent pas être trouvés par leur nom. 
- #NULL! - peut apparaître lorsqu'il y a une erreur dans la formule, comme :  (,) ou un espace utilisé à la place d'un deux-points (:).
- #NUM! - le numérique dans la formule peut être invalide, trop long ou trop petit, etc.
- #REF! - référence de cellule invalide.
- #VALUE! - type de valeur inattendu. Par exemple, une valeur de chaîne affectée à une cellule numérique.




## **Opérateurs Arithmétiques**
Vous pouvez utiliser tous les opérateurs arithmétiques dans les formules de feuille de calcul de diagramme :



|**Opérateur** |**Signification** |**Exemple**|
| :- | :- | :- |
|+ (signe plus) |Addition ou plus unitaire|2 + 3|
|- (signe moins) |Soustraction ou négation |2 - 3<br>-3|
|* (astérisque)|Multiplication |2 * 3|
|/ (barre oblique)|Division |2 / 3|
|% (signe de pourcentage) |Pourcentage |30%|
|^ (accent circonflexe) |Exponentiation |2 ^ 3|


*Remarque* : Pour changer l'ordre d'évaluation, placez entre parenthèses la partie de la formule à calculer en premier.


## **Opérateurs de Comparaison**
Vous pouvez comparer les valeurs des cellules avec les opérateurs de comparaison. Lorsque deux valeurs sont comparées à l'aide de ces opérateurs, le résultat est une valeur logique soit *TRUE* soit FALSE :



|**Opérateur** |**Signification** |**Signification** |
| :- | :- | :- |
|= (signe égal) |Égal à |A2 = 3|
|<> (signe de différent) |Pas égal à|A2 <> 3|
|> (signe supérieur) |Supérieur à|A2 > 3|
|>= (signe supérieur ou égal) |Supérieur ou égal à|A2 >= 3|
|< (signe inférieur)|Inférieur à|A2 < 3|
|<= (signe inférieur ou égal)|Inférieur ou égal à|A2 <= 3|

## **Références de Cellule de Style A1**
**Les références de cellules de style A1** sont utilisées pour les feuilles de calcul, où la colonne a un identifiant de lettre (par exemple "*A*") et la ligne a un identifiant numérique (par exemple "*1*"). Les références de cellules de style A1 peuvent être utilisées de la manière suivante :



|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue |Relative |Mixte|
|Cellule |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Ligne |$2:$2 |2:2 |-|
|Colonne |$A:$A |A:A |-|
|Plage |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Voici un exemple de la manière d'utiliser la référence de cellule de style A1 dans une formule :




## **Références de Cellule de Style R1C1**
**Les références de cellules de style R1C1** sont utilisées pour les feuilles de calcul, où à la fois une ligne et une colonne ont l'identifiant numérique. Les références de cellules de style R1C1 peuvent être utilisées de la manière suivante :



|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue |Relative |Mixte|
|Cellule |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne |R2|R[2]|-|
|Colonne |C3|C[3]|-|
|Plage |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Voici un exemple de la manière d'utiliser la référence de cellule de style A1 dans une formule :




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