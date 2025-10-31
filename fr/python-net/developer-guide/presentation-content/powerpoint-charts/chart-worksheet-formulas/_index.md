---
title: Appliquer des formules de feuille de calcul de graphique dans les présentations avec Python
linktitle: Formules de feuille de calcul
type: docs
weight: 70
url: /fr/python-net/chart-worksheet-formulas/
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
- constante d'erreur
- constante arithmétique
- opérateur de comparaison
- style A1
- style R1C1
- fonction prédéfinie
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: Appliquer des formules de type Excel dans Aspose.Slides pour Python via les feuilles de calcul .NET de graphiques et automatiser les rapports pour les fichiers PPT, PPTX et ODP.
---


## **À propos des formules de feuille de calcul de graphique dans la présentation**
**Feuille de calcul de graphique** (ou feuille de travail du graphique) dans une présentation est la source de données du graphique. La feuille de calcul de graphique contient des données, qui sont représentées graphiquement sur le graphique. Lorsque vous créez un graphique dans PowerPoint, la feuille de calcul associée à ce graphique est automatiquement créée également. La feuille de travail du graphique est créée pour tous les types de graphiques : graphique en courbes, graphique à barres, graphique en disque rayonné, graphique circulaire, etc. Pour voir la feuille de calcul de graphique dans PowerPoint, double‑cliquez sur le graphique :

![todo:image_alt_text](chart-worksheet-formulas_1.png)



La feuille de calcul de graphique contient les noms des éléments du graphique (Nom de catégorie : *Category1*, Nom de série) et un tableau avec des données numériques correspondant à ces catégories et séries. Par défaut, lorsqu’on crée un nouveau graphique, les données de la feuille de calcul sont définies avec les valeurs par défaut. Vous pouvez ensuite modifier les données du tableau manuellement dans la feuille de travail.

En général, le graphique représente des données complexes (par ex. analystes financiers, analystes scientifiques), contenant des cellules calculées à partir des valeurs d’autres cellules ou d’autres données dynamiques. Calculer la valeur d’une cellule manuellement et la coder en dur rend difficile toute modification ultérieure. Si vous modifiez la valeur d’une cellule donnée, toutes les cellules qui en dépendent devront également être mises à jour. De plus, les données du tableau peuvent dépendre de données provenant d’autres tableaux, créant un schéma de données de présentation complexe qui doit pouvoir être mis à jour de façon simple et flexible.

**La formule de feuille de calcul de graphique** dans une présentation est une expression permettant de calculer et de mettre à jour automatiquement les données de la feuille de calcul. La formule de feuille de calcul définit la logique de calcul des données pour une cellule ou un ensemble de cellules. Il s’agit d’une formule mathématique ou logique qui utilise : des références de cellules, des fonctions mathématiques, des opérateurs logiques, des opérateurs arithmétiques, des fonctions de conversion, des constantes de chaîne, etc. La définition de la formule est inscrite dans une cellule, qui ne contient alors pas une simple valeur. La formule calcule la valeur et la renvoie, puis cette valeur est affectée à la cellule. Les formules de feuille de calcul de graphique dans les présentations sont en fait les mêmes que les formules Excel, et les mêmes fonctions, opérateurs et constantes par défaut sont pris en charge pour leur implémentation.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) la feuille de calcul de graphique est représentée par la propriété [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) du type [**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/).  
La formule de feuille de calcul peut être assignée et modifiée via la propriété [**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/).  
Les fonctionnalités suivantes sont prises en charge pour les formules dans Aspose.Slides :

- Constantes logiques
- Constantes numériques
- Constantes de chaîne
- Constantes d’erreur
- Opérateurs arithmétiques
- Opérateurs de comparaison
- Références de cellules au style A1
- Références de cellules au style R1C1
- Fonctions prédéfinies



En général, les classeurs stockent les dernières valeurs calculées des formules. Si, après le chargement de la présentation, les données du graphique n’ont pas été modifiées, la propriété **IChartDataCell.Value** renvoie ces valeurs lors de la lecture. En revanche, si les données du classeur ont été modifiées, la lecture de la propriété **ChartDataCell.Value** lève l’exception **CellUnsupportedDataException** pour les formules non prises en charge. Cela s’explique par le fait que, lorsque les formules sont analysées avec succès, les dépendances entre cellules sont déterminées et la validité des dernières valeurs est vérifiée. Si la formule ne peut pas être analysée, la validité de la valeur de la cellule ne peut être garantie.


## **Ajouter une formule de feuille de calcul de graphique à la présentation**
Tout d’abord, ajoutez un graphique avec quelques données d’exemple à la première diapositive d’une nouvelle présentation à l’aide de [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).  
La feuille de travail du graphique est créée automatiquement et peut être accédée via la propriété [**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

Écrivons quelques valeurs dans des cellules à l’aide de la propriété [**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) du type **Object**, ce qui signifie que vous pouvez affecter n’importe quelle valeur à la propriété :

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

Pour écrire une formule dans la cellule, utilisez la propriété [**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) :

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Note*: la propriété [**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) sert à définir des références de cellules au style A1.

Pour définir une référence de cellule au style [r1c1_formula](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/), utilisez la propriété [**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) :

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Ensuite, appelez la méthode [**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) pour calculer toutes les formules du classeur et mettre à jour les valeurs des cellules correspondantes :

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```


## **Constantes logiques**
Vous pouvez utiliser des constantes logiques telles que *FALSE* et *TRUE* dans les formules de cellules.


## **Constantes numériques**
Les nombres peuvent être exprimés en notation décimale ou scientifique pour créer des formules de feuille de calcul de graphique.


## **Constantes de chaîne**
Une constante de chaîne (ou littérale) est une valeur spécifique utilisée telle quelle et qui ne change pas. Les constantes de chaîne peuvent être : des dates, du texte, des nombres, etc.


## **Constantes d’erreur**
Parfois il n’est pas possible de calculer le résultat d’une formule. Dans ce cas, le code d’erreur est affiché dans la cellule à la place de sa valeur. Chaque type d’erreur possède un code spécifique :

- #DIV/0! - la formule tente de diviser par zéro.
- #GETTING_DATA - peut être affiché dans une cellule dont la valeur est encore en cours de calcul.
- #N/A - information manquante ou indisponible. Raisons possibles : cellules utilisées dans la formule vides, espace supplémentaire, faute de frappe, etc.
- #NAME? - une certaine cellule ou un autre objet de formule est introuvable par son nom.
- #NULL! - peut apparaître lorsqu’il y a une erreur dans la formule, par ex. (,) ou un espace utilisé à la place d’un deux‑points (:).
- #NUM! - le nombre dans la formule est invalide, trop grand ou trop petit, etc.
- #REF! - référence de cellule invalide.
- #VALUE! - type de valeur inattendu. Par exemple, une chaîne affectée à une cellule numérique.


## **Opérateurs arithmétiques**
Vous pouvez utiliser tous les opérateurs arithmétiques dans les formules de feuille de travail du graphique :

|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|+ (signe plus)|Addition ou plus unaire|2 + 3|
|- (signe moins)|Soustraction ou négation|2 - 3<br>-3|
|* (astérisque)|Multiplication|2 * 3|
|/ (slash)|Division|2 / 3|
|% (pourcentage)|Pourcentage|30%|
|^ (caret)|Exponentiation|2 ^ 3|

*Note*: pour changer l’ordre d’évaluation, encadrez de parenthèses la partie de la formule à calculer en premier.


## **Opérateurs de comparaison**
Vous pouvez comparer les valeurs des cellules avec les opérateurs de comparaison. Lorsque deux valeurs sont comparées à l’aide de ces opérateurs, le résultat est une valeur logique : *TRUE* ou FALSE :

|**Opérateur**|**Signification**|**Exemple**|
| :- | :- | :- |
|= (égal)|Égal à|A2 = 3|
|<> (différent)|Différent de|A2 <> 3|
|> (supérieur)|Supérieur à|A2 > 3|
|>= (supérieur ou égal)|Supérieur ou égal à|A2 >= 3|
|< (inférieur)|Inférieur à|A2 < 3|
|<= (inférieur ou égal)|Inférieur ou égal à|A2 <= 3|

## **Références de cellules au style A1**
**Les références de cellules au style A1** sont utilisées pour les feuilles où la colonne possède un identifiant alphabétique (par ex. *A*) et la ligne un identifiant numérique (par ex. *1*). Elles peuvent être employées comme suit :

|**Référence**|**Exemple**| | |
| :- | :- | :- | :- |
| |Absolue|Relative|Mixte|
|Cellule|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Ligne|$2:$2|2:2|-|
|Colonne|$A:$A|A:A|-|
|Plage|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Voici un exemple d’utilisation d’une référence de cellule au style A1 dans une formule :


## **Références de cellules au style R1C1**
**Les références de cellules au style R1C1** sont utilisées pour les feuilles où tant la ligne que la colonne sont identifiées numériquement. Elles peuvent être employées comme suit :

|**Référence**|**Exemple**| | |
| :- | :- | :- | :- |
| |Absolue|Relative|Mixte|
|Cellule|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Ligne|R2|R[2]|-|
|Colonne|C3|C[3]|-|
|Plage|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Voici un exemple d’utilisation d’une référence de cellule au style R1C1 dans une formule :


## **Fonctions prédéfinies**
Il existe des fonctions prédéfinies qui peuvent être utilisées dans les formules pour simplifier leur implémentation. Ces fonctions encapsulent les opérations les plus couramment utilisées, telles que :

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

**Les fichiers Excel externes sont‑ils pris en charge comme source de données pour un graphique contenant des formules ?**

Oui. Aspose.Slides prend en charge les classeurs externes comme [source de données d’un graphique](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/), ce qui vous permet d’utiliser des formules provenant d’un XLSX situé en dehors de la présentation.

**Les formules de graphique peuvent‑elles référencer des feuilles du même classeur par leur nom ?**

Oui. Les formules suivent le modèle de référence standard d’Excel, vous pouvez donc référencer d’autres feuilles du même classeur ou d’un classeur externe. Pour les références externes, indiquez le chemin et le nom du classeur en utilisant la syntaxe Excel.