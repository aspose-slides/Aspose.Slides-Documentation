---
title: Formules de Feuille de Calcul de Graphique
type: docs
weight: 70
url: /cpp/chart-worksheet-formulas/
keywords: "équations powerpoint, formules de feuille de calcul powerpoint"
description: "Équations PowerPoint et Formules de Feuille de Calcul"
---


## **À propos des Formules de Feuille de Calcul de Graphique dans la Présentation**
**Feuille de calcul de graphique** (ou feuille de calcul de graphique) dans la présentation est la source de données du graphique. La feuille de calcul de graphique contient des données, qui sont représentées sur le graphique de manière graphique. Lorsque vous créez un graphique dans PowerPoint, la feuille de calcul associée à ce graphique est automatiquement créée également. La feuille de calcul de graphique est créée pour tous les types de graphiques : graphique linéaire, graphique à barres, graphique en soleil, graphique en secteurs, etc. Pour voir la feuille de calcul de graphique dans PowerPoint, vous devez double-cliquer sur le graphique :

![todo:image_alt_text](chart-worksheet-formulas_1.png)



La feuille de calcul de graphique contient les noms des éléments du graphique (Nom de Catégorie : *Catégorie1*, Nom de Série) et un tableau avec des données numériques appropriées pour ces catégories et séries. Par défaut, lorsque vous créez un nouveau graphique - les données de la feuille de calcul de graphique sont définies avec des données par défaut. Ensuite, vous pouvez modifier les données de la feuille de calcul dans la feuille de calcul manuellement.

Habituellement, le graphique représente des données complexes (par exemple, pour des analystes financiers, des analystes scientifiques), ayant des cellules qui sont calculées à partir des valeurs d'autres cellules ou d'autres données dynamiques. Calculer manuellement la valeur d'une cellule et la coder en dur dans la cellule rend difficile son changement à l'avenir. Si vous changez la valeur d'une certaine cellule, toutes les cellules qui en dépendent devront également être mises à jour. De plus, les données des tableaux peuvent dépendre des données d'autres tableaux, créant un schéma de données de présentation complexe nécessitant une mise à jour facile et flexible.

**Formule de feuille de calcul de graphique** dans la présentation est une expression pour calculer et mettre à jour automatiquement les données de feuille de calcul de graphique. La formule de feuille de calcul définit la logique de calcul des données pour une certaine cellule ou un ensemble de cellules. La formule de feuille de calcul est une formule mathématique ou une formule logique, qui utilise : des références de cellule, des fonctions mathématiques, des opérateurs logiques, des opérateurs arithmétiques, des fonctions de conversion, des constantes de chaîne, etc. La définition de la formule est écrite dans une cellule, et cette cellule ne contient pas une valeur simple. La formule de feuille de calcul calcule la valeur et la renvoie, puis cette valeur est attribuée à la cellule. Les formules de feuille de calcul de graphique dans les présentations sont en fait les mêmes que les formules excel, et il est supporté les mêmes fonctions, opérateurs et constantes par défaut pour leur mise en œuvre.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) la feuille de calcul de graphique est représentée par la méthode 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) du type 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook). 
La formule de feuille de calcul peut être attribuée et changée avec la méthode 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692). 
La fonctionnalité suivante est supportée pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d'erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellules de style A1
- Références de cellules de style R1C1
- Fonctions prédéfinies



En général, les feuilles de calcul stockent les dernières valeurs de formule calculées. Si après le chargement de la présentation, les données du graphique n'ont pas changé - la méthode **IChartDataCell.get_Value()** renvoie ces valeurs lors de la lecture. Mais, si les données de la feuille de calcul ont été modifiées, lors de la lecture, la méthode **ChartDataCell.get_Value()** lance l'exception **CellUnsupportedDataException** pour les formules non prises en charge. Cela est dû au fait que lorsque les formules sont correctement analysées, les dépendances des cellules sont déterminées et la justesse des dernières valeurs est déterminée. Mais, si la formule ne peut pas être analysée, la justesse de la valeur de la cellule ne peut pas être garantie.


## **Ajouter une Formule de Feuille de Calcul de Graphique à la Présentation**
Tout d'abord, ajoutez un graphique à la première diapositive d'une nouvelle présentation avec 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
La feuille de calcul du graphique est automatiquement créée et peut être accédée avec la méthode 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) :



``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```



Écrivons quelques valeurs dans les cellules avec la méthode 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) 
du type **Object**, ce qui signifie que vous pouvez passer n'importe quelle valeur à la méthode :



``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```



Maintenant, pour écrire une formule dans la cellule, vous pouvez utiliser la méthode 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) :





*Remarque* : la méthode [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) est utilisée pour définir des références de cellules de style A1. 



Pour définir la référence de cellule R1C1, vous pouvez utiliser la méthode [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) :





Ensuite, si vous essayez de lire les valeurs des cellules B2 et C2, elles seront calculées :



``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Constantes Logiques**
Vous pouvez utiliser des constantes logiques telles que *FALSE* et *TRUE* dans les formules des cellules :




## **Constantes Numériques**
Des nombres peuvent être utilisés en notations communes ou scientifiques pour créer une formule de feuille de calcul de graphique :




## **Constantes de Chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique qui est utilisée telle quelle et ne change pas. Les constantes de chaîne peuvent être : des dates, des textes, des nombres, etc. :




## **Constantes d'Erreur**
Parfois, il n'est pas possible de calculer le résultat par la formule. Dans ce cas, le code d'erreur est affiché dans la cellule au lieu de sa valeur. Chaque type d'erreur a un code spécifique :

- #DIV/0! - la formule essaie de diviser par zéro.
- #GETTING_DATA - peut être affiché dans une cellule, pendant que sa valeur est encore en cours de calcul.
- #N/A - l'information est manquante ou indisponible. Certaines raisons peuvent être : les cellules utilisées dans la formule sont vides, un caractère d'espace supplémentaire, une faute de frappe, etc.
- #NAME? - une certaine cellule ou d'autres objets de formule ne peuvent pas être trouvés par leur nom. 
- #NULL! - peut apparaître lorsqu'il y a une erreur dans la formule, comme : (,) ou un caractère d'espace utilisé à la place d'un deux-points (:).
- #NUM! - le numérique dans la formule peut être invalide, trop long ou trop petit, etc.
- #REF! - référence de cellule invalide.
- #VALUE! - type de valeur inattendu. Par exemple, une valeur de chaîne définie pour une cellule numérique.




## **Opérateurs Arithmétiques**
Vous pouvez utiliser tous les opérateurs arithmétiques dans les formules de feuille de calcul de graphique :



|**Opérateur** |**Signification** |**Exemple**|
| :- | :- | :- |
|+ (signe plus) |Addition ou plus unaire|2 + 3|
|- (signe moins) |Soustraction ou négation |2 - 3<br>-3|
|* (astérisque)|Multiplication |2 * 3|
|/ (barre oblique)|Division |2 / 3|
|% (signe pourcentage) |Pourcentage |30%|
|^ (accent circonflexe) |Exponentiation |2 ^ 3|


*Remarque* : Pour changer l'ordre d'évaluation, mettez entre parenthèses la partie de la formule à calculer en premier.


## **Opérateurs de Comparaison**
Vous pouvez comparer les valeurs des cellules avec les opérateurs de comparaison. Lorsque deux valeurs sont comparées à l'aide de ces opérateurs, le résultat est une valeur logique soit *TRUE* soit *FALSE* :



|**Opérateur** |**Signification** |**Signification** |
| :- | :- | :- |
|= (signe égal) |Égal à |A2 = 3|
|<> (signe de non égal) |Différent de|A2 <> 3|
|> (signe supérieur) |Supérieur à|A2 > 3|
|>= (signe supérieur ou égal) |Supérieur ou égal à|A2 >= 3|
|< (signe inférieur)|Inférieur à|A2 < 3|
|<= (signe inférieur ou égal)|Inférieur ou égal à|A2 <= 3|

## **Références de Cellules de Style A1**
**Références de cellules de style A1** sont utilisées pour les feuilles de calcul, où la colonne a un identifiant de lettre (par exemple "*A*") et la ligne a un identifiant numérique (par exemple "*1*"). Les références de cellules de style A1 peuvent être utilisées de la manière suivante :



|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolute |Relative |Mixte|
|Cellule |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Ligne |$2:$2 |2:2 |-|
|Colonne |$A:$A |A:A |-|
|Plage |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Voici un exemple de la façon d'utiliser la référence de cellule de style A1 dans une formule :




## **Références de Cellules de Style R1C1**
**Références de cellules de style R1C1** sont utilisées pour les feuilles de calcul, où à la fois une ligne et une colonne ont l'identifiant numérique. Les références de cellules de style R1C1 peuvent être utilisées de la manière suivante :



|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolute |Relative |Mixte|
|Cellule |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne |R2|R[2]|-|
|Colonne |C3|C[3]|-|
|Plage |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Voici un exemple de la façon d'utiliser la référence de cellule de style A1 dans une formule :




## **Fonctions Prédéfinies**
Il existe des fonctions prédéfinies, qui peuvent être utilisées dans les formules pour simplifier leur mise en œuvre. Ces fonctions encapsulent les opérations les plus couramment utilisées, telles que :

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
- INDEX (formulaire de référence)
- LOOKUP (formulaire vectoriel)
- MATCH (formulaire vectoriel)
- MAX
- SUM
- VLOOKUP