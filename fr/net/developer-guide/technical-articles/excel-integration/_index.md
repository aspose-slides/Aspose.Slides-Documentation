---
title: Intégrer des données Excel dans les présentations PowerPoint
linktitle: Intégration Excel
type: docs
weight: 330
url: /fr/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
- Excel
- classeur
- lire Excel
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

Les présentations PowerPoint sont un moyen puissant d’afficher et de communiquer des informations. Elles sont souvent utilisées en conjonction avec des classeurs Excel, où Excel constitue une excellente source de données structurées et PowerPoint excelle à visualiser ces données pour un public.

Il existe de nombreux scénarios pratiques où combiner Excel et PowerPoint est essentiel : publipostage, remplissage de tableaux de données, génération d’une diapositive par enregistrement (génération groupée de diapositives), création de supports de formation, et consolidation de plusieurs rapports Excel en une seule présentation, pour n’en citer que quelques-uns.

Jusqu’à présent, la mise en œuvre de telles fonctionnalités avec l’API Aspose.Slides nécessitait de s’appuyer sur des solutions tierces comme Aspose.Cells. Bien que ces outils soient robustes, ils peuvent être trop complexes et coûteux pour les utilisateurs qui n’ont besoin que d’une intégration basique des données.

## **Comment ça fonctionne**

Pour faciliter et rationaliser le travail avec les données Excel, Aspose.Slides a introduit de nouvelles classes permettant de lire les données des classeurs Excel et d’importer du contenu dans une présentation. Cette fonctionnalité ouvre de puissantes nouvelles possibilités aux utilisateurs de l’API qui souhaitent exploiter Excel comme source de données dans leurs flux de travail de présentation.

La nouvelle fonctionnalité est conçue pour un accès aux données à usage général et n’est pas intégrée au modèle d’objet du document de présentation (DOM). Cela signifie *qu’elle ne permet pas de modifier ou d’enregistrer les fichiers Excel* — son seul but est d’ouvrir les classeurs et de parcourir leur contenu afin de récupérer les données des cellules.

Au cœur de cette fonctionnalité se trouve la nouvelle classe [ExcelDataWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.excel/exceldataworkbook/). Cette classe vous permet de charger un classeur Excel à partir d’un fichier local ou d’un flux. Une fois chargé, elle propose plusieurs surcharges de la méthode [GetCell](https://reference.aspose.com/slides/fr/net/aspose.slides.excel/exceldataworkbook/getcell/), que vous pouvez utiliser pour récupérer des cellules spécifiques par leur position (par exemple, indices de ligne et de colonne ou plages nommées).

Chaque appel à [GetCell](https://reference.aspose.com/slides/fr/net/aspose.slides.excel/exceldataworkbook/getcell/) renvoie une instance de la classe [ExcelDataCell](https://reference.aspose.com/slides/fr/net/aspose.slides.excel/exceldatacell/). Cet objet représente une seule cellule du classeur Excel et vous donne accès à sa valeur de manière simple et intuitive.

#### **Importer un graphique Excel**

L’étape suivante pour étendre la fonctionnalité est la classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/fr/net/aspose.slides.import/excelworkbookimporter/). Cette classe utilitaire fournit des fonctionnalités d’importation de contenu depuis un classeur Excel vers une présentation. Elle contient plusieurs surcharges de la méthode [AddChartFromWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/), qui vous aident à récupérer le graphique sélectionné du classeur Excel spécifié et à l’ajouter à la fin de la collection de formes donnée aux coordonnées indiquées.

#### **Importer un tableau Excel**

La classe [ExcelWorkbookImporter](https://reference.aspose.com/slides/fr/net/aspose.slides.import/excelworkbookimporter/) propose également plusieurs surcharges de la méthode [AddTableFromWorkbook](https://reference.aspose.com/slides/fr/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/). Ces méthodes vous permettent d’importer une plage de cellules spécifiée depuis une feuille de calcul donnée et de l’ajouter en tant que tableau à la fin de la collection de formes aux coordonnées indiquées.

En bref, c’est une API légère et simple pour lire les données Excel — exactement ce dont de nombreux développeurs ont besoin sans le surcoût d’une bibliothèque complète de traitement de feuilles de calcul.

## **Passons au code**

### **Exemple de scénario de publipostage**

Dans l’exemple suivant, nous implémenterons un scénario simple de publipostage en générant plusieurs présentations à partir des données stockées dans un classeur Excel.

Pour commencer, nous avons besoin de deux éléments :
1. Un classeur Excel contenant les données

![Exemple de données Excel](example1_image0.png)

2. Modèle de présentation PowerPoint

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

    // Obtenir les paragraphes de la forme cible (suppose que l'index de forme 1 est utilisé).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Remplacer les espaces réservés par les données provenant d'Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Enregistrer la présentation personnalisée dans un fichier distinct.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Résultat](example1_image2.png)

### **Exemple de tableau Excel**

Dans le second exemple, nous copions simplement les données d’un tableau Excel et les affichons sur une diapositive PowerPoint sous un format plus attrayant visuellement.

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

D’abord, nous ajoutons un graphique circulaire au classeur Excel à partir du tableau des employés.

![Exemple de graphique Excel](example3_image0.png)

```csharp
// Créer une nouvelle présentation PowerPoint.
using Presentation presentation = new Presentation();

// Obtenir la collection de formes de la première diapositive.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importer le graphique nommé "Chart 1" depuis la première feuille du classeur et l'ajouter à la collection de formes.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Enregistrer la présentation résultante dans un fichier.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Résultat](example3_image1.png)

### **Exemple d’importation de tous les graphiques Excel**

Imaginons que vous disposiez d’un classeur Excel rempli de graphiques et que vous deviez tous les importer dans une présentation. Chaque graphique doit être placé sur une nouvelle diapositive.

Le code suivant parcourt toutes les feuilles du fichier Excel source, extrait les graphiques de chaque feuille et ajoute chaque graphique à une diapositive distincte en utilisant une disposition de diapositive vierge. Dans la présentation résultante, seules les données du graphique seront incorporées, pas le classeur complet.

```csharp
// Charger le classeur Excel contenant les données des employés.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Créer une nouvelle présentation PowerPoint.
using Presentation presentation = new Presentation();

// Récupérer la disposition de diapositive vierge.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Obtenir les noms de toutes les feuilles de calcul contenues dans le classeur Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Récupérer un dictionnaire qui associe les indices de graphiques aux noms de graphiques pour la feuille de calcul.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Ajouter une nouvelle diapositive en utilisant la disposition vierge.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importer le graphique spécifié depuis le classeur Excel dans la collection de formes de la diapositive.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Enregistrer la présentation résultante dans un fichier.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Exemple d’importation d’un tableau Excel**

Dans cet exemple, nous importons un tableau formaté depuis une feuille Excel directement dans une présentation PowerPoint.

La feuille Excel source contient un tableau formaté avec les données des employés :

![Exemple de tableau Excel](example4_image0.png)

```csharp
// Créer une nouvelle présentation PowerPoint.
using Presentation presentation = new Presentation();

// Obtenir la collection de formes de la première diapositive.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importer le tableau depuis la première feuille du classeur et l'ajouter à la collection de formes.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Enregistrer la présentation résultante dans un fichier.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![Résultat](example4_image1.png)


## **Résumé**

Ce mécanisme, disponible directement dans Aspose.Slides, combine le travail avec les données Excel et les présentations en un seul endroit. Il permet de créer des diapositives avec des graphiques visuels et des données présentées sous forme de tableaux Excel — sans bibliothèques supplémentaires ni intégrations complexes.