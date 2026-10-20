---
title: Créer des graphiques Excel et les incorporer dans des présentations en tant qu'objets OLE
type: docs
weight: 50
url: /fr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- graphique Excel
- incorporer le graphique
- objet OLE
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer un graphique Excel avec Aspose.Cells for .NET et incorporer le classeur dans une présentation PowerPoint avec Aspose.Slides, incluant un aperçu du graphique."
---
## **Vue d'ensemble**

Cet article montre comment créer un graphique à colonnes Excel avec Aspose.Cells for .NET et incorporer son classeur dans une présentation PowerPoint avec Aspose.Slides for .NET. Le classeur incorporé contient à la fois les données source et le graphique. Un aperçu PNG séparé affiche le graphique sur la diapositive avant que l'objet OLE ne soit activé.

Le résultat est un objet Excel incorporé, et non un graphique PowerPoint natif. Modifier le classeur via OLE nécessite une application de bureau qui prend en charge l'activation OLE et une installation d'Excel compatible.

## **Pré-requis**

Ajoutez les références à Aspose.Cells for .NET et Aspose.Slides for .NET dans votre projet C#. L'exemple utilise des instructions de niveau supérieur et nécessite C# 9 ou ultérieur. Microsoft Office n'est pas requis pour générer la présentation avec ces bibliothèques.

Aucun fichier d'entrée n'est nécessaire : l'exemple crée les données et le graphique en mémoire, puis écrit `OutputChart.pptx` dans le répertoire de travail actuel. Appliquez les licences pour les deux produits lors de l'exécution hors du mode d'évaluation.

## **Comment fonctionne l'incorporation**

1. Créez un classeur avec une feuille de données et une feuille de graphique.  
1. Rendez la feuille de graphique active afin que le classeur s'ouvre sur le graphique.  
1. Définissez la plage d'affichage OLE du classeur et rendez le graphique au format PNG.  
1. Enregistrez le classeur au format XLSX en mémoire et incorporez ces octets dans une diapositive.  
1. Attribuez le PNG comme aperçu de l'objet OLE et enregistrez la présentation au format PPTX.

La plage d'affichage du classeur et le cadre sur la diapositive ont des rôles différents. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) prend des indices de ligne et de colonne de début/fin basés à zéro. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) prend quant à lui la ligne supérieure, la colonne de gauche, la ligne inférieure et la colonne droite. L'exemple utilise l'indice de ligne 55 et l'indice de colonne 25 comme limites inférieure droite ; ces valeurs sont des choix de mise en page, pas le nombre de lignes ou de colonnes de données.

Le cadre de la diapositive utilise des points. L'exemple l'ajuste à l'intérieur de la diapositive et le centre tout en préservant le ratio d'aspect du PNG, plutôt que d'étirer l'aperçu pour remplir la diapositive.

## **Créer et incorporer le graphique**

L'exemple complet suivant remplit `DataSheet` avec quatre lignes et cinq colonnes de valeurs. Chaque ligne devient une série de graphique. `ChartSheet` est sélectionnée comme feuille active avant l'enregistrement du classeur.

Le classeur est explicitement enregistré au format XLSX, correspondant à l'extension `xlsx` transmise à [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). Le PNG est chargé directement depuis son flux sans conversion bitmap intermédiaire. L'assigner via [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) remplace l'espace réservé OLE par défaut.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Rendre l'aperçu du graphique et sérialiser le classeur modifiable séparément.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Résultat attendu**

`OutputChart.pptx` contient une diapositive avec un classeur Excel incorporé et un aperçu du graphique. Le classeur contient les données d'origine et un graphique à colonnes avec quatre séries. L'aperçu est centré sur la diapositive et conserve ses proportions.

![Graphique à colonnes Excel affiché comme aperçu d'un classeur incorporé](excel-chart-ole-preview.png)

Dans un environnement PowerPoint de bureau compatible avec Excel disponible, double-cliquez sur l'objet pour activer et modifier le classeur incorporé. L'activation et la modification dépendent de la prise en charge OLE de l'application hôte et des paramètres de sécurité.

## **FAQ**

**Pourquoi une image d'aperçu est‑elle nécessaire ?**  
Le classeur incorporé et son aperçu de diapositive sont des contenus distincts. Fournissez une image de graphique afin que la diapositive affiche le graphique au lieu de l'espace réservé « EMBEDDED OLE OBJECT ». Voir [Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame](/slides/fr/net/object-preview-issue-when-adding-oleobjectframe/).

**L'aperçu se met‑il à jour automatiquement lorsque je modifie le classeur dans le code ?**  
Considérez l'aperçu comme un instantané. Lors de la mise à jour des données du classeur par programme, régénérez l'image du graphique et remplacez à la fois l'aperçu et les données du classeur incorporé.

**Puis‑je utiliser XLS au lieu de XLSX ?**  
Oui. Enregistrez le classeur au format XLS et utilisez `xls` comme extension de données incorporées. L'extension doit correspondre au format réel du classeur ; changer uniquement l'extension ne convertit pas les données.

**Pourquoi l'objet peut‑il changer de taille après activation ?**  
L'application hôte peut mettre à jour la présentation de l'objet OLE lorsqu'elle active le classeur. La plage d'affichage OLE du classeur et les dimensions du cadre de la diapositive sont toutes deux importantes. Voir [Solution fonctionnelle pour le redimensionnement de graphiques dans PPTX](/slides/fr/net/working-solution-for-chart-resizing-in-pptx/).

## **Sections associées**

- [Solution fonctionnelle pour le redimensionnement de graphiques dans PPTX](/slides/fr/net/working-solution-for-chart-resizing-in-pptx/)
- [Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame](/slides/fr/net/object-preview-issue-when-adding-oleobjectframe/)
- [Mettre à jour automatiquement les objets OLE à l'aide d'un module complémentaire PowerPoint](/slides/fr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)