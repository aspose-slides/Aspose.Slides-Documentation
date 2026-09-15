---
title: Intégrer des données Excel dans les présentations PowerPoint
linktitle: Intégration Excel
type: docs
weight: 330
url: /fr/python-java/excel-integration/
keywords:
- Excel
- classeur
- lire Excel
- intégrer Excel
- source de données
- publipostage
- importer tableau
- Excel dans PowerPoint
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Lire les données des classeurs Excel dans Aspose.Slides pour Python via Java en utilisant l'API ExcelDataWorkbook. Charger les feuilles et les cellules et utiliser les valeurs pour générer des présentations PowerPoint basées sur les données."
---
## **Introduction**

Les présentations PowerPoint sont un moyen puissant d'afficher et de communiquer des informations. Elles sont souvent utilisées en conjonction avec les classeurs Excel, où Excel constitue une excellente source de données structurées et PowerPoint excelle à visualiser ces données pour un public.

Il existe de nombreux scénarios pratiques où combiner Excel et PowerPoint est essentiel : les publipostages, le remplissage de tableaux de données, la génération d’une diapositive par enregistrement de données (génération de diapositives par lot), la création de supports de formation et la consolidation de plusieurs rapports Excel en une seule présentation, pour n’en citer que quelques-uns.

Jusqu’à présent, la mise en œuvre de ces fonctionnalités avec l’API Aspose.Slides nécessitait de recourir à des solutions tierces comme Aspose.Cells. Bien que ces outils soient robustes, ils peuvent être excessivement complexes et coûteux pour les utilisateurs qui n’ont besoin que d’une fonctionnalité d’intégration de données de base.

## **Comment ça fonctionne**

Pour faciliter et rationaliser le travail avec les données Excel, Aspose.Slides a introduit de nouvelles classes permettant de lire les données des classeurs Excel et d’importer du contenu dans une présentation. Cette fonctionnalité ouvre de puissantes nouvelles possibilités aux utilisateurs de l’API qui souhaitent exploiter Excel comme source de données dans leurs flux de travail de présentation.

La nouvelle fonctionnalité est conçue pour un accès aux données à usage général et n’est pas intégrée au modèle d’objet du document de présentation (DOM). Cela signifie *qu’elle ne permet pas de modifier ou d’enregistrer des fichiers Excel* — son seul but est d’ouvrir des classeurs et de parcourir leur contenu afin de récupérer les données des cellules.

Au cœur de cette fonctionnalité se trouve la nouvelle classe [ExcelDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/exceldataworkbook/). Cette classe vous permet de charger un classeur Excel à partir d’un fichier local ou d’un flux. Une fois chargé, elle propose plusieurs surcharges de la méthode [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/exceldataworkbook/#getCell), que vous pouvez utiliser pour récupérer des cellules spécifiques par leur position (par ex., indices de ligne et de colonne ou plages nommées).

Chaque appel à [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/exceldataworkbook/#getCell) renvoie un objet [ExcelDataCell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/exceldatacell/). Cet objet représente une seule cellule du classeur Excel et vous donne accès à sa valeur de manière simple et intuitive.

#### **Importer un graphique Excel**

La prochaine étape pour étendre la fonctionnalité est la classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/excelworkbookimporter/). Cette classe utilitaire fournit des fonctionnalités d’importation de contenu d’un classeur Excel vers une présentation. Elle comporte plusieurs surcharges de la méthode [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook), qui vous aident à récupérer le graphique sélectionné du classeur Excel spécifié et à l’ajouter à la fin de la collection de formes fournie aux coordonnées indiquées.

#### **Importer un tableau Excel**

La classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/excelworkbookimporter/) contient également plusieurs surcharges de la méthode [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook). Ces méthodes vous permettent d’importer une plage de cellules spécifiée d’une feuille de calcul donnée et de l’ajouter sous forme de tableau à la fin de la collection de formes fournie aux coordonnées indiquées.

En résumé, il s’agit d’une API légère et simple pour lire les données Excel — exactement ce dont de nombreux développeurs ont besoin sans la surcharge d’une bibliothèque complète de traitement de feuilles de calcul.

## **Passons au code**

### **Exemple de scénario de publipostage**

Dans l’exemple suivant, nous implémenterons un scénario de publipostage simple en générant plusieurs présentations à partir de données stockées dans un classeur Excel.

Pour commencer, nous avons besoin de deux éléments :

1. Un classeur Excel contenant les données

![Exemple de données Excel](example1_image0.png)

2. Un modèle de présentation PowerPoint

![Exemple de modèle PowerPoint](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Charger le classeur Excel contenant les données des employés.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Charger le modèle de présentation.
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Parcourir les lignes Excel (en excluant l’en-tête à la ligne 0).
    for row_index in range(1, 5):

        # Créer une présentation pour chaque enregistrement d'employé.
        employee_presentation = Presentation()

        try:
            # Supprimer la diapositive vierge par défaut.
            employee_presentation.getSlides().removeAt(0)

            # Cloner la diapositive modèle dans la présentation.
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # Obtenir les paragraphes de la forme cible (en supposant que l’indice de forme 1 est utilisé).
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # Remplacer les espaces réservés par les données provenant d’Excel.
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # Enregistrer la présentation personnalisée dans un fichier séparé.
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Résultat](example1_image2.png)

### **Exemple de tableau Excel**

Dans le deuxième exemple, nous copions simplement des données d’un tableau Excel et les affichons sur une diapositive PowerPoint dans un format plus attrayant visuellement.

Dans cet exemple, nous réutilisons le même classeur Excel que dans le premier exemple, qui contient un tableau simple d’employés.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# Charger le classeur Excel contenant les données des employés.
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# Créer une présentation PowerPoint.
presentation = Presentation()

try:
    # Ajouter une forme de tableau à la première diapositive.
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Remplir le tableau PowerPoint avec les données du classeur Excel.
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # Enregistrer la présentation résultante dans un fichier.
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Résultat](example2_image0.png)

### **Exemple d’importation d’un graphique Excel**

Dans cet exemple, nous importons un graphique depuis la première feuille du classeur Excel utilisé dans l’exemple précédent. Le graphique sera lié au classeur externe dans la présentation résultante.

Tout d’abord, nous ajoutons un diagramme circulaire au classeur Excel à partir du tableau des employés.

![Exemple de graphique Excel](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Créer une présentation PowerPoint.
presentation = Presentation()
try:
    # Obtenir la collection de formes de la première diapositive.
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # Importer le graphique nommé "Chart 1" depuis la première feuille du classeur et l'ajouter à la collection de formes.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # Enregistrer la présentation résultante dans un fichier.
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Résultat](example3_image1.png)

### **Exemple d’importation de tous les graphiques Excel**

Imaginons que vous disposiez d’un classeur Excel rempli de graphiques et que vous deviez tous les importer dans une présentation. Chaque graphique doit être placé sur une nouvelle diapositive.

Le code suivant parcourt toutes les feuilles du fichier Excel source, extrait les graphiques de chaque feuille et ajoute chaque graphique à une diapositive distincte en utilisant une mise en page de diapositive vierge. Dans la présentation résultante, seules les données du graphique seront incorporées, pas le classeur complet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# Charger le classeur Excel contenant les données des employés.
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# Créer une présentation PowerPoint.
presentation = Presentation()
try:
    # Récupérer la mise en page vierge.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # Supprimer la diapositive par défaut afin que le résultat contienne une diapositive par graphique.
    presentation.getSlides().removeAt(0)

    # Obtenir les noms de toutes les feuilles de calcul contenues dans le classeur Excel.
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # Récupérer une map qui associe les index des graphiques à leurs noms pour la feuille.
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # Ajouter une diapositive en utilisant la mise en page vierge.
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # Importer le graphique spécifié du classeur Excel dans la collection de formes de la diapositive.
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # Enregistrer la présentation résultante dans un fichier.
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Exemple d’importation d’un tableau Excel**

Dans cet exemple, nous importons un tableau formaté depuis une feuille Excel directement dans une présentation PowerPoint.

La feuille Excel source contient un tableau formaté avec les données des employés :

![Exemple de tableau Excel](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# Créer une présentation PowerPoint.
presentation = Presentation()
try:
    # Obtenir la première diapositive et sa collection de formes.
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # Importer le tableau depuis la première feuille du classeur et l'ajouter à la collection de formes.
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # Enregistrer la présentation résultante dans un fichier.
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Résultat](example4_image1.png)

## **Résumé**

Ce mécanisme, disponible directement dans Aspose.Slides, combine la gestion des données Excel et des présentations en un seul endroit. Il vous permet de créer des diapositives avec des graphiques visuels et des données présentées sous forme de tableaux Excel — sans bibliothèques supplémentaires ni intégrations complexes.