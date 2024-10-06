---
title: Création de graphiques Excel et intégration dans la présentation en tant qu'objet OLE
type: docs
weight: 50
url: /net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

Dans les diapositives PowerPoint, l'utilisation de graphiques éditables pour l'affichage graphique des données est une activité courante. Aspose permet de créer des graphiques Excel avec Aspose.Cells pour .NET et ces graphiques peuvent ensuite être intégrés en tant qu'objet OLE dans la diapositive PowerPoint grâce à Aspose.Slides pour .NET. Cet article couvre les étapes requises ainsi que l'implémentation en C# et VB.NET pour créer et intégrer un graphique MS Excel en tant qu'objet OLE dans la présentation PowerPoint en utilisant Aspose.Cells pour .NET et Aspose.Slides pour .NET.

{{% /alert %}} 
## **Étapes requises**
La séquence suivante d'étapes est nécessaire pour créer et intégrer un graphique Excel en tant qu'objet OLE dans la diapositive PowerPoint :

1. Créer un graphique Excel en utilisant Aspose.Cells pour .NET.
2. Définir la taille OLE du graphique Excel en utilisant Aspose.Cells pour .NET.
3. Obtenir l'image du graphique Excel avec Aspose.Cells pour .NET.
4. Intégrer le graphique Excel en tant qu'objet OLE dans la présentation PPTX en utilisant Aspose.Slides pour .NET.
5. Remplacer l'image de l'objet modifié par l'image obtenue à l'étape 3 pour résoudre le problème d'objet modifié.
6. Écrire la présentation de sortie sur le disque au format PPTX.

## **Implémentation des étapes requises**
L’implémentation des étapes ci-dessus en C# et Visual Basic est la suivante :

```c#
//Étape - 1 : Créer un graphique Excel en utilisant Aspose.Cells
//--------------------------------------------------
//Créer un classeur
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Ajouter un graphique Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Étape - 2 : Définir la taille OLE du graphique. en utilisant Aspose.Cells
//----------------------------------------------------------- 
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Étape - 3 : Obtenir l'image du graphique avec Aspose.Cells
//----------------------------------------------------------- 
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Enregistrer le classeur dans un flux
MemoryStream wbStream = wb.SaveToStream();
//Étape - 4 ET 5
//-----------------------------------------------------------
//Étape - 4 : Intégrer le graphique en tant qu'objet OLE à l'intérieur de la présentation .ppt en utilisant Aspose.Slides
//-----------------------------------------------------------
//Étape - 5 : Remplacer l'image de l'objet modifié par l'image obtenue à l'étape 3 pour résoudre le problème d'objet modifié
//-----------------------------------------------------------
//Créer une présentation
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Ajouter le classeur sur la diapositive
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Étape - 6 : Écrire la présentation de sortie sur le disque
//----------------------------------------------------------- 
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Tableau des noms de cellules
    string[] cellsName = new string[] 
    {
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4"
    };

    //Tableau des données des cellules
    int[] cellsValue = new int[] 
    {
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25
    };
    
    //Ajouter une nouvelle feuille de calcul pour peupler les cellules avec des données
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    
    //Peupler la DataSheet avec des données
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    
    //Ajouter une feuille de graphique
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    
    //Ajouter un graphique dans la ChartSheet avec les séries de données de la DataSheet
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    
    //Définir la ChartSheet comme feuille active
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```

```c#
static void AddExcelChartInPresentation(Presentation pres, ISlide sld, Stream wbStream, Bitmap imgChart)
{
    float oleWidth = pres.SlideSize.Size.Width;
    float oleHeight = pres.SlideSize.Size.Height;

    byte[] chartOleData = new byte[wbStream.Length];
    wbStream.Position = 0;
    wbStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oof = sld.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        imgChart.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

        imageStream.Position = 0;
        IPPImage ppImage = pres.Images.AddImage(imageStream);

        oof.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

{{% alert color="primary" %}} 

La présentation créée par la méthode ci-dessus comportera le graphique Excel en tant qu'objet OLE qui peut être activé en double-cliquant sur le cadre de l'objet OLE.

{{% /alert %}} 
## **Conclusion**
{{% alert color="primary" %}} 

En utilisant Aspose.Cells pour .NET ainsi qu'Aspose.Slides pour .NET, nous pouvons créer n'importe lequel des graphiques Excel supportés par Aspose.Cells pour .NET et intégrer le graphique créé en tant qu'objet OLE dans une diapositive PowerPoint. La taille OLE du graphique Excel peut également être définie. Les utilisateurs finaux peuvent de plus éditer le graphique Excel comme tout autre objet OLE.

{{% /alert %}} 
## **Sections Connexes**
[Solution Fonctionnelle pour le Redimensionnement des Graphiques](/slides/net/working-solution-for-chart-resizing-in-pptx/)[Problème d'Objet Modifié](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)