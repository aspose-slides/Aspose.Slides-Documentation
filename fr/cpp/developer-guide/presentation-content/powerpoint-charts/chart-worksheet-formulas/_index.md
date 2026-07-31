---
title: Appliquer les formules de feuille de calcul de graphique dans les présentations en C++
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/cpp/chart-worksheet-formulas/
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
- C++
- Aspose.Slides
description: "Appliquez des formules de type Excel dans Aspose.Slides pour les feuilles de calcul de graphiques C++ et automatisez les rapports dans les fichiers PPT et PPTX."
---
## **Vue d'ensemble**

Une feuille de calcul de graphique est la source de données derrière un graphique dans une présentation. Elle stocke les noms de catégorie et de série ainsi que les valeurs numériques affichées par le graphique. Dans Aspose.Slides, cette feuille de calcul est disponible via le classeur de données du graphique, ce qui vous permet de travailler avec les données du graphique de manière programmatique.

Cet article explique comment utiliser les formules de feuille de calcul dans les données du graphique afin que les valeurs des cellules puissent être calculées et mises à jour automatiquement au lieu d'être saisies manuellement. Il montre comment affecter des formules, utiliser à la fois les références de style A1 et de style R1C1, recalculer les formules du classeur et travailler avec les constantes, opérateurs, références de cellules et fonctions prédéfinies prises en charge pour les feuilles de calcul de graphique dans les présentations.

## **À propos des formules de feuille de calcul de graphique dans les présentations**
**Feuille de calcul de graphique** (ou feuille de calcul de graphique) dans une présentation est la source de données du graphique. La feuille de calcul de graphique contient les données, qui sont représentées dans le graphique de façon graphique. Lorsque vous créez un graphique dans PowerPoint, la feuille de calcul associée à ce graphique est automatiquement créée également. La feuille de calcul de graphique est créée pour tous les types de graphiques : graphique en courbes, graphique à barres, graphique Sunburst, graphique circulaire, etc. Pour voir la feuille de calcul de graphique dans PowerPoint, vous devez double‑cliquer sur le graphique :

![todo:image_alt_text](chart-worksheet-formulas_1.png)

La feuille de calcul de graphique contient les noms des éléments du graphique (Nom de catégorie : *Category1*, Nom de série) et un tableau de données numériques correspondant à ces catégories et séries. Par défaut, lorsque vous créez un nouveau graphique, les données de la feuille de calcul sont initialisées avec les données par défaut. Vous pouvez ensuite modifier les données du tableau dans la feuille de calcul manuellement.

En général, le graphique représente des données complexes (par ex. analystes financiers, analystes scientifiques), avec des cellules calculées à partir des valeurs d’autres cellules ou d’autres données dynamiques. Calculer manuellement la valeur d’une cellule et la coder en dur rend difficile toute modification ultérieure. Si vous modifiez la valeur d’une certaine cellule, toutes les cellules qui en dépendent devront également être mises à jour. De plus, les données du tableau peuvent dépendre des données d’autres tableaux, créant ainsi un schéma de données de présentation complexe qui doit pouvoir être mis à jour de manière simple et flexible.

**Formule de feuille de calcul de graphique** dans une présentation est une expression permettant de calculer et de mettre à jour automatiquement les données de la feuille de calcul du graphique. La formule de feuille de calcul définit la logique de calcul des données pour une cellule ou un ensemble de cellules. Une formule de feuille de calcul est une formule mathématique ou logique qui utilise : références de cellules, fonctions mathématiques, opérateurs logiques, opérateurs arithmétiques, fonctions de conversion, constantes de chaîne, etc. La définition de la formule est écrite dans une cellule, et cette cellule ne contient pas une simple valeur. La formule de feuille de calcul calcule la valeur et la renvoie, puis cette valeur est affectée à la cellule. Les formules de feuille de calcul de graphique dans les présentations sont en fait les mêmes que les formules Excel, et elles prennent en charge les mêmes fonctions, opérateurs et constantes par défaut pour leur implémentation.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/fr/cpp/) la feuille de calcul de graphique est représentée par la méthode 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) du type 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.charts.i_chart_data_workbook). 
Une formule de feuille de calcul peut être affectée et modifiée avec 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692). 
Les fonctionnalités suivantes sont prises en charge pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d’erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellules de style A1
- Références de cellules de style R1C1
- Fonctions prédéfinies



Typiquement, les feuilles de calcul conservent les dernières valeurs calculées des formules. Si, après le chargement de la présentation, les données du graphique n’ont pas été modifiées, la méthode **IChartDataCell.get_Value()** renvoie ces valeurs lors de la lecture. En revanche, si les données de la feuille de calcul ont été modifiées, la lecture avec **ChartDataCell.get_Value()** déclenche une **CellUnsupportedDataException** pour les formules non prises en charge. Cela s’explique par le fait que, lorsqu’une formule est correctement analysée, les dépendances des cellules sont déterminées et la validité des dernières valeurs est vérifiée. Si la formule ne peut pas être analysée, la validité de la valeur de la cellule ne peut pas être garantie.


## **Ajouter une formule de feuille de calcul de graphique à une présentation**
Tout d’abord, ajoutez un graphique à la première diapositive d’une nouvelle présentation avec 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
La feuille de calcul du graphique est automatiquement créée et peut être accédée avec 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) :

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Écrivons quelques valeurs dans les cellules avec la méthode 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) du type **Object**, ce qui signifie que vous pouvez transmettre n’importe quelle valeur à la méthode :

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Maintenant, pour écrire une formule dans la cellule, vous pouvez utiliser la méthode 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) :

*Remarque* : la méthode [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) sert à définir des références de cellules de style A1. 

Pour définir la référence de cellule **R1C1Formula**, vous pouvez utiliser la méthode [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) :

Ensuite, si vous lisez les valeurs des cellules B2 et C2, elles seront calculées :

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Constantes logiques**
Vous pouvez utiliser les constantes logiques telles que *FALSE* et *TRUE* dans les formules de cellules :

## **Constantes numériques**
Les nombres peuvent être utilisés en notation décimale ou scientifique pour créer une formule de feuille de calcul de graphique :

## **Constantes de chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique qui est utilisée telle quelle et ne change pas. Les constantes de chaîne peuvent être : dates, textes, nombres, etc. :

## **Constantes d’erreur**
Parfois il n’est pas possible de calculer le résultat avec la formule. Dans ce cas, le code d’erreur est affiché dans la cellule à la place de sa valeur. Chaque type d’erreur possède un code spécifique :

- #DIV/0! – la formule tente de diviser par zéro.
- #GETTING_DATA – peut être affiché dans une cellule pendant que sa valeur est encore en cours de calcul.
- #N/A – l’information est manquante ou indisponible. Parmi les raisons possibles : les cellules utilisées dans la formule sont vides, un caractère d’espace supplémentaire, une faute de frappe, etc.
- #NAME? – une certaine cellule ou un autre objet de formule ne peut pas être trouvé par son nom.
- #NULL! – peut apparaître lorsqu’il y a une erreur dans la formule, par ex. : (,) ou un caractère d’espace utilisé à la place d’un deux‑points (:).
- #NUM! – le nombre dans la formule peut être invalide, trop long ou trop petit, etc.
- #REF! – référence de cellule invalide.
- #VALUE! – type de valeur inattendu. Par exemple, une chaîne affectée à une cellule numérique.


## **Opérateurs arithmétiques**
Vous pouvez utiliser tous les opérateurs arithmétiques dans les formules de feuille de calcul du graphique :

|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|+ (signe plus)|Addition ou plus unaire|2 + 3|
|- (signe moins)|Soustraction ou négation|2 - 3<br>-3|
|* (astérisque)|Multiplication|2 * 3|
|/ (slash)|Division|2 / 3|
|% (pourcentage)|Pourcentage|30%|
|^ (accent circonflexe)|Exponentiation|2 ^ 3|

*Remarque* : pour modifier l’ordre d’évaluation, encadrez entre parenthèses la partie de la formule à calculer en premier.


## **Opérateurs de comparaison**
Vous pouvez comparer les valeurs de cellules avec les opérateurs de comparaison. Lorsque deux valeurs sont comparées avec ces opérateurs, le résultat est une valeur logique *TRUE* ou *FALSE* :

|**Opérateur**|**Signification**|**Signification**|
| :- | :- | :- |
|= (signe égal)|Égal à|A2 = 3|
|<> (signe différent)|Différent de|A2 <> 3|
|> (supérieur)|Supérieur à|A2 > 3|
|>= (supérieur ou égal)|Supérieur ou égal à|A2 >= 3|
|< (inférieur)|Inférieur à|A2 < 3|
|<= (inférieur ou égal)|Inférieur ou égal à|A2 <= 3|

## **Références de cellules de style A1**
**Les références de cellules de style A1** sont utilisées pour les feuilles de calcul, où la colonne possède un identifiant alphabétique (ex. "*A*") et la ligne un identifiant numérique (ex. "*1*"). Les références de style A1 peuvent être utilisées de la façon suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue|Relative|Mixte|
|Cellule|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Ligne|$2:$2|2:2|-|
|Colonne|$A:$A|A:A|-|
|Plage|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Voici un exemple d’utilisation d’une référence de cellule de style A1 dans une formule :

## **Références de cellules de style R1C1**
**Les références de cellules de style R1C1** sont utilisées pour les feuilles de calcul, où à la fois la ligne et la colonne possèdent un identifiant numérique. Les références de style R1C1 peuvent être utilisées de la façon suivante :

|**Référence de cellule**|**Exemple**|||
| :- | :- | :- | :- |
||Absolue|Relative|Mixte|
|Cellule|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne|R2|R[2]|-|
|Colonne|C3|C[3]|-|
|Plage|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Voici un exemple d’utilisation d’une référence de cellule de style A1 dans une formule :

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

Oui. Aspose.Slides prend en charge les classeurs externes comme [source de données du graphique](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/chartdatasourcetype/), ce qui vous permet d’utiliser des formules provenant d’un fichier XLSX situé en dehors de la présentation.

**Les formules de graphique peuvent‑elles référencer des feuilles du même classeur par leur nom ?**

Oui. Les formules suivent le modèle de référence standard d’Excel, vous pouvez donc référencer d’autres feuilles du même classeur ou d’un classeur externe. Pour les références externes, incluez le chemin et le nom du classeur en utilisant la syntaxe Excel.