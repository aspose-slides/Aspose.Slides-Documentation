---
title: Δημόσιο API και Μη Συμβατές με Παλαιότερες Εκδόσεις Αλλαγές στο Aspose.Slides για .NET 14.6.0
linktitle: Aspose.Slides για .NET 14.6.0
type: docs
weight: 80
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/
keywords:
- μεταφορά
- κληρονομικός κώδικας
- σύγχρονος κώδικας
- κληρονομική προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των διασπαστικών αλλαγών στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασής σας PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλες τις [προστιθέμενες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) κλάσεις, μεθόδους, ιδιότητες κ.ά., τυχόν νέους [περιορισμούς](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) και άλλες [αλλαγές](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) που εισήχθησαν με το API του Aspose.Slides for .NET 14.6.0.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Προστιθέμενα Διεπαφές, Μέθοδοι και Ιδιότητες**
#### **Προστέθηκε η διεπαφή Aspose.Slides.Charts.IErrorBarsFormat**
Αυτό αντιπροσωπεύει τις γραμμές σφάλματος των σειρών γραφήματος.

Στην περίπτωση προσαρμοσμένου τύπου τιμής, για να καθορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα ErrorBarCustomValues του συγκεκριμένου σημείου δεδομένων στη συλλογή DataPoints της σειράς.

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;

    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;

    errBarX.IsVisible = true;

    errBarY.IsVisible = true;

    errBarX.ValueType = ErrorBarValueType.Fixed;

    errBarX.Value = 0.1f;

    errBarY.ValueType = ErrorBarValueType.Percentage;

    errBarY.Value = 5;

    errBarX.Type = ErrorBarType.Plus;

    errBarY.Format.Line.Width = 2;

    errBarX.HasEndCap = true;

    pres.Save("ErrorBars.pptx", SaveFormat.Pptx);

}

``` 
#### **Προστέθηκε η διεπαφή Aspose.Slides.Charts.IErrorBarsCustomValues**
Όταν η ιδιότητα IErrorBarsFormat.ValueType είναι ίση με Custom, για να καθορίσετε μια τιμή, χρησιμοποιήστε την ιδιότητα ErrorBarCustomValues του συγκεκριμένου σημείου δεδομένων στη συλλογή DataPoints.

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    IChartSeries series = chart.ChartData.Series[0];

    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;

    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

    errBarX.IsVisible = true;

    errBarY.IsVisible = true;

    errBarX.ValueType = ErrorBarValueType.Custom;

    errBarY.ValueType = ErrorBarValueType.Custom;

    IChartDataPointCollection points = series.DataPoints;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    for (int i = 0; i < points.Count; i++)

    {

        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;

    }

    pres.Save("ErrorBarsCustomValues", SaveFormat.Pptx);

}

``` 
#### **Προστέθηκε η διεπαφή Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
Καθορίζει τους τύπους τιμών στη λίστα ιδιοτήτων ChartDataPoint.ErrorBarsCustomValues.

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    IChartSeries series = chart.ChartData.Series[0];

    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;

    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

    errBarX.IsVisible = true;

    errBarY.IsVisible = true;

    errBarX.ValueType = ErrorBarValueType.Custom;

    errBarY.ValueType = ErrorBarValueType.Custom;

    IChartDataPointCollection points = series.DataPoints;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    for (int i = 0; i < points.Count; i++)

    {

        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;

    }

    pres.Save("ErrorBarsCustomValues", SaveFormat.Pptx);

}

``` 
#### **Προστέθηκαν οι μέθοδοι Aspose.Slides.IShapeCollection.AddClone(...), και .InsertClone(...)**
Οι παρακάτω μέθοδοι προσθέτουν/εισαγωγούν ένα αντίγραφο ενός συγκεκριμένου σχήματος στη συλλογή. 

- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape)
- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape, float x, float y)
- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape, float x, float y, float width, float height)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape, float x, float y)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape, float x, float y, float width, float height)

``` csharp

 using (Presentation srcPres = new Presentation(dataPath_ShapeCloning + "Source Frame.pptx"))

{

    IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;

    ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);

    ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);

    IShapeCollection destShapes = destSlide.Shapes;

    destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);

    destShapes.AddClone(sourceShapes[2]);

    destShapes.AddClone(sourceShapes[3], 50, 200, 50, 50);

    destShapes.AddClone(sourceShapes[4]);

    destShapes.AddClone(sourceShapes[5], 300, 300, 50, 200);

    destShapes.InsertClone(0, sourceShapes[0], 50, 150);

}

``` 
#### **Προστέθηκαν το Enum ViewType, η διεπαφή IViewProperties, η κλάση ViewProperties και οι ιδιότητες IPresentation.ViewProperties**
Η IPresentation.ViewProperty επιτρέπει στους προγραμματιστές να αλλάξουν τον τύπο προβολής της παρουσίασης και την ορατότητα των σημειώσεων όταν μια παρουσίαση ανοίγει στο PowerPoint.

``` csharp

 using(Presentation p = new Presentation())

{

    p.ViewProperties.LastView = ViewType.SlideMasterView;

}

```