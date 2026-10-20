---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 60
url: /fr/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement de graphique
- graphique Excel
- objet OLE
- intégrer le graphique
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Corrige le redimensionnement inattendu des graphiques dans les fichiers PPTX lors de l'utilisation d'objets OLE Excel incorporés avec Aspose.Slides pour .NET. Définissez des dimensions fixes pour le graphique afin de garder la taille du graphique et du cadre OLE cohérentes."
---
## **Contexte**

Les graphiques Excel incorporés en tant qu'objets OLE dans les présentations PowerPoint à l'aide des composants Aspose peuvent changer de taille après leur première activation. Cela peut provoquer une différence notable dans l'apparence du graphique avant et après l'activation. Cet article explique pourquoi le redimensionnement se produit et montre comment l'éviter en faisant correspondre les dimensions fixes du graphique au cadre OLE.

Dans [Créer des graphiques Excel et les incorporer en tant qu'objets OLE dans les présentations](/slides/fr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells pour .NET et l'incorporer dans une présentation PowerPoint à l'aide d'Aspose.Slides pour .NET. Pour résoudre le [problème d'aperçu d'objet](/slides/fr/net/object-preview-issue-when-adding-oleobjectframe/), nous avons affecté l'image du graphique au cadre OLE du graphique. Dans la présentation générée, lorsque vous double-cliquez sur le cadre OLE affichant l'image du graphique, le graphique Excel est activé. Les utilisateurs peuvent modifier le classeur Excel incorporé, puis revenir à la diapositive en cliquant en dehors du classeur activé. La taille du cadre OLE change lorsque l'utilisateur revient à la diapositive, et le facteur de redimensionnement varie en fonction des tailles d'origine tant du cadre OLE que du classeur Excel incorporé.

## **Cause du redimensionnement**

Le classeur Excel incorporé possède ses propres dimensions de fenêtre, que Excel tente de conserver lors de la première activation de l'objet. Le cadre OLE sur la diapositive possède des dimensions définies de manière indépendante. Lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille de l'objet afin de maintenir ses proportions dans le cadre du processus d'incorporation. Les différences entre la fenêtre du classeur et le cadre OLE peuvent donc provoquer le redimensionnement de l'objet.

## **Solution fonctionnelle**

Faites correspondre la taille du graphique au cadre OLE de la diapositive et maintenez les dimensions du graphique indépendantes de la fenêtre du classeur. Cette solution fonctionne avec une nouvelle présentation ou un modèle existant.

L'exemple nécessite Aspose.Cells pour .NET et Aspose.Slides pour .NET. Il crée un simple graphique à colonnes sur une feuille de graphique active et incorpore le classeur au format XLS. Aucune image d'aperçu du graphique n'est affectée ; le graphique devient visible lorsque l'objet OLE est activé dans PowerPoint.

L'exemple crée une nouvelle présentation avec un cadre OLE de 9,5 × 4 pouces positionné à 0,5 pouce du bord gauche et à 1 pouce du haut. Les coordonnées et dimensions de la diapositive sont exprimées en points (72 points par pouce). Pour une présentation existante, consultez [Utiliser un modèle](#use-a-template).

## **Définir une taille de graphique fixe**

Définissez [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) sur false afin que les dimensions du graphique soient indépendantes de la fenêtre du classeur. Définissez les dimensions du [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) via [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) et [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), en convertissant les points en pixels avec 96 pixels par pouce : un cadre mesurant 684 × 288 points correspond à un graphique mesurant 912 × 384 pixels. Définissez [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) sur la valeur Custom de [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). L'exemple incorpore le classeur avec [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) et enregistre une présentation avec un cadre OLE de 9,5 × 4 pouces.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Les coordonnées et dimensions de la diapositive sont en points (72 points par pouce).
var width = 684f; // 9,5 pouces.
var height = 288f; // 4 pouces.

chart.SizeWithWindow = false;
// Convert points to chart pixels using 96 pixels per inch.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Utiliser un modèle**

The sizing logic is the same for an existing presentation. To adapt the example:

1. Chargez la présentation modèle au lieu de créer une présentation vide.
1. Vérifiez que la première diapositive contient au moins trois formes, puis utilisez la forme à l'index 2 comme espace réservé.
1. Prenez la largeur et la hauteur du cadre à partir de cette forme au lieu d'utiliser les valeurs fixes 684 et 288. Conservez les calculs de dimensionnement inchangés.
1. Ajoutez le cadre OLE à la position de l'espace réservé au lieu des coordonnées fixes 36 et 72.
1. Supprimez l'espace réservé avant d'enregistrer la présentation.

## **FAQ**

**Pourquoi mon graphique Excel incorporé change-t-il de taille après son activation dans PowerPoint ?**

Cela se produit parce qu'Excel tente de restaurer la taille originale de la fenêtre lors de la première activation, alors que le cadre de l'objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille pour conserver le rapport d'aspect, ce qui peut entraîner le redimensionnement.

**Comment puis‑je garder les tailles du graphique et du cadre OLE cohérentes ?**

Définissez des dimensions fixes pour le graphique qui correspondent au cadre OLE et utilisez une taille d'impression de graphique personnalisée avant d'incorporer le classeur. L'exemple ci‑dessus montre les paramètres requis et les conversions d'unités.

**Le fait d'aligner la taille de la fenêtre du classeur suffit‑il ?**

Aligner uniquement la taille de la fenêtre du classeur ne prévient pas de manière fiable le changement de taille du cadre OLE après activation. Utilisez des dimensions fixes pour le graphique comme indiqué dans l'exemple.

**Cette solution fonctionne‑t‑elle à la fois avec des présentations basées sur un modèle et avec de nouvelles présentations ?**

Oui. Pour un modèle, utilisez les dimensions et la position de l'espace réservé. Pour une nouvelle présentation, spécifiez directement les dimensions et la position du cadre.

**Puis‑je utiliser cet exemple avec des graphiques créés dans d'autres programmes de tableur ?**

L'exemple utilise un classeur Excel créé avec Aspose.Cells. Il ne montre pas le comportement d'activation pour d'autres programmes de tableur.

## **Sections connexes**

- [Créer des graphiques Excel et les incorporer en tant qu'objets OLE dans les présentations](/slides/fr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Mettre à jour automatiquement les objets OLE à l'aide d'un complément PowerPoint](/slides/fr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)