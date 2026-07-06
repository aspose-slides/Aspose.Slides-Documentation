---
title: Intégrer des données Excel dans les présentations PowerPoint
linktitle: Intégration Excel
type: docs
weight: 330
url: /fr/net/excel-integration/
keywords:
- Excel
- classeur
- lecture Excel
- intégrer Excel
- source de données
- publipostage
- importer tableau
- Excel vers PowerPoint
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Lire les données des classeurs Excel dans Aspose.Slides à l’aide de l’API ExcelDataWorkbook. Charger les feuilles et les cellules et utiliser les valeurs pour générer des présentations PowerPoint basées sur les données."
---
## **Introduction**

Les présentations PowerPoint sont un moyen puissant d’afficher et de communiquer des informations. Elles sont souvent utilisées en combinaison avec des classeurs Excel, où Excel constitue une source excellente de données structurées et PowerPoint excelle à visualiser ces données pour un public.

Il existe de nombreux scénarios pratiques où la combinaison d’Excel et de PowerPoint est essentielle : publipostage, remplissage de tableaux de données, génération d’une diapositive par enregistrement (génération de diapositives en lot), création de supports de formation, et consolidation de plusieurs rapports Excel en une seule présentation, pour n’en citer que quelques‑uns.

Jusqu’à présent, la mise en œuvre de telles fonctionnalités avec l’API Aspose.Slides nécessitait de recourir à des solutions tierces comme Aspose.Cells. Si ces outils sont robustes, ils peuvent être excessivement complexes et coûteux pour les utilisateurs qui n’ont besoin que d’une fonctionnalité d’intégration de données de base.

## **Fonctionnement**

Pour simplifier l’utilisation des données Excel, Aspose.Slides a introduit de nouvelles classes permettant de lire les données d’un classeur Excel et d’importer le contenu dans une présentation. Cette fonctionnalité ouvre de puissantes nouvelles possibilités pour les utilisateurs de l’API qui souhaitent exploiter Excel comme source de données dans leurs flux de travail de présentation.

La nouvelle fonctionnalité est conçue pour un accès général aux données et n’est pas intégrée au modèle d’objet du document de présentation (DOM). Cela signifie *qu’elle ne permet pas de modifier ou d’enregistrer des fichiers Excel* — son unique but est d’ouvrir des classeurs et de parcourir leur contenu afin de récupérer les valeurs des cellules.

Au cœur de cette fonctionnalité se trouve la nouvelle classe [ExcelDataWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.excel/exceldataworkbook/). Cette classe vous permet de charger un classeur Excel depuis un fichier local ou un flux. Une fois chargé, elle propose plusieurs surcharges de la méthode [GetCell](https://reference.aspose.com/slides/fr/net/aspose.slides.excel/exceldataworkbook/getcell/), que vous pouvez utiliser pour récupérer des cellules spécifiques par leur position (par exemple, indices de ligne et de colonne ou plages nommées).

Chaque appel à [GetCell](https://reference.aspose.com/slides/fr/net/aspose.slides.excel/exceldataworkbook/getcell/) renvoie une instance de la classe [ExcelDataCell](https://reference.aspose.com/slides/fr/net/aspose.slides.excel/exceldatacell/). Cet objet représente une cellule unique du classeur Excel et vous donne accès à sa valeur de façon simple et intuitive.

#### **Importer un graphique Excel**

L’étape suivante pour étendre la fonctionnalité est la classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/fr/net/aspose.slides.import/excelworkbookimporter/). Cette classe utilitaire fournit des fonctions d’importation de contenu d’un classeur Excel vers une présentation. Elle contient plusieurs surcharges de la méthode [AddChartFromWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), qui vous aident à extraire le graphique sélectionné du classeur Excel spécifié et à l’ajouter à la fin de la collection de formes donnée aux coordonnées précisées.

#### **Importer un tableau Excel**

La classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/fr/net/aspose.slides.import/excelworkbookimporter/) propose également plusieurs surcharges de la méthode [AddTableFromWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/). Ces méthodes vous permettent d’importer une plage de cellules spécifiée d’une feuille de calcul donnée et de l’ajouter comme tableau à la fin de la collection de formes aux coordonnées indiquées.

En bref, il s’agit d’une API légère et directe pour lire les données Excel — exactement ce dont de nombreux développeurs ont besoin, sans la surcharge d’une bibliothèque complète de traitement de feuilles de calcul.

## **Passons au code**

### **Exemple de scénario de publipostage**

Dans l’exemple suivant, nous implémenterons un scénario de publipostage simple en générant plusieurs présentations à partir des données stockées dans un classeur Excel.

Pour commencer, il nous faut deux éléments :
1. Un classeur Excel contenant les données

![Exemple de données Excel](example1_image0.png)

2.  Modèle de présentation PowerPoint

![Exemple de modèle PowerPoint](example1_image1.png)

```csharp
// Charger le classeur Excel contenant les données des employés.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Charger le modèle de présentation.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Parcourir les lignes Excel (en excluant l'en-tête à la ligne 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Créer une nouvelle présentation pour chaque enregistrement d'employé.
    using Presentation employeePresentation = new Presentation();

    // Supprimer la diapositive vierge par défaut.
    employeePresentation.Slides.RemoveAt(0);

    // Cloner la diapositive modèle dans la nouvelle présentation.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Obtenir les paragraphes de la forme cible (suppose que l'indice de forme 1 est utilisé).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Remplacer les espaces réservés par les données d'Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Enregistrer la présentation personnalisée dans un fichier séparé.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Résultat](example1_image2.png)

### **Exemple de tableau Excel**

Dans le deuxième exemple, nous copions simplement les données d’un tableau Excel et les affichons sur une diapositive PowerPoint sous une forme plus attrayante visuellement.

Dans cet exemple, nous réutilisons le même classeur Excel que dans le premier exemple, qui contient un tableau simple d’employés.

```csharp
// Charger le classeur Excel contenant les données des employés.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Créer une nouvelle présentation PowerPoint.
using Presentation presentation = new Presentation();

// Ajouter une forme de tableau à la première diapositive.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Remplir le tableau PowerPoint avec les données du classeur Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Enregistrer la présentation résultante dans un fichier.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Résultat](example2_image0.png)

### **Exemple d’importation d’un graphique Excel**

Dans cet exemple, nous importons un graphique depuis la première feuille du classeur Excel utilisé dans l’exemple précédent. Le graphique sera lié au classeur externe dans la présentation résultante.

Tout d’abord, nous ajoutons un graphique circulaire au classeur Excel à partir du tableau des employés.

![Exemple de graphique Excel](example3_image0.png)

```csharp
// Créer une nouvelle présentation PowerPoint.
using Presentation presentation = new Presentation();

// Obtenir la collection de formes de la première diapositive.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importer le graphique nommé "Chart 1" de la première feuille du classeur et l'ajouter à la collection de formes.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Enregistrer la présentation résultante dans un fichier.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Résultat](example3_image1.png)

### **Exemple d’importation de tous les graphiques Excel**

Imaginons que vous disposiez d’un classeur Excel plein de graphiques et que vous deviez tous les importer dans une présentation. Chaque graphique doit être placé sur une nouvelle diapositive.

Le code suivant parcourt toutes les feuilles du fichier Excel source, extrait les graphiques de chaque feuille et ajoute chaque graphique à une diapositive distincte en utilisant une mise en page de diapositive vierge. Dans la présentation résultante, seules les données du graphique seront incorporées, pas le classeur complet.

```csharp
// Charger le classeur Excel contenant les données des employés.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Créer une nouvelle présentation PowerPoint.
using Presentation presentation = new Presentation();

// Récupérer la mise en page de diapositive vierge.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Obtenir les noms de toutes les feuilles de calcul contenues dans le classeur Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Récupérer un dictionnaire qui associe les index de graphiques aux noms de graphiques pour la feuille de calcul.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Ajouter une nouvelle diapositive en utilisant la mise en page vierge.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importer le graphique spécifié du classeur Excel dans la collection de formes de la diapositive.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Enregistrer la présentation résultante dans un fichier.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Exemple d’importation d’un tableau Excel**

Dans cet exemple, nous importons un tableau formaté depuis une feuille de calcul Excel directement dans une présentation PowerPoint.

La feuille de calcul source contient un tableau formaté avec des données d’employés :

![Exemple de tableau Excel](example4_image0.png)

```csharp
// Créer une nouvelle présentation PowerPoint.
using Presentation presentation = new Presentation();

// Obtenir la collection de formes de la première diapositive.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importer le tableau de la première feuille du classeur et l'ajouter à la collection de formes.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Enregistrer la présentation résultante dans un fichier.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![Résultat](example4_image1.png)

## **Résumé**

Ce mécanisme, disponible directement dans Aspose.Slides, combine la gestion des données Excel et des présentations en un seul endroit. Il vous permet de créer des diapositives avec des graphiques visuels et des données présentées sous forme de tableaux Excel — sans bibliothèques supplémentaires ni intégrations complexes.