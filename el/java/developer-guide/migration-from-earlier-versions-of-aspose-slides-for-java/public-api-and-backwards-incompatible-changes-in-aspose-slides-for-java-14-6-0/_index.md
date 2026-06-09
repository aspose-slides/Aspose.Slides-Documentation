---
title: Δημόσιο API και Αλλαγές Πίσω Μη Συμβατές στο Aspose.Slides for Java 14.6.0
linktitle: Aspose.Slides for Java 14.6.0
type: docs
weight: 50
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
keywords:
- μετεγκατάσταση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση ενημερώσεων του δημόσιου API και διακοπτικών αλλαγών στο Aspose.Slides for Java για ομαλή μετάβαση των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα παραθέτει όλες τις [added](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/) κλάσεις, μεθόδους, ιδιότητες κ.ά., τυχόν νέους περιορισμούς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides for Java 14.6.0.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Προστιθέμενες Κλάσεις, Μέθοδοι, Διεπαφές και Απαριθμήσεις**
#### **Προστέθηκε η Απαρίθμηση ViewType, η Διεπαφή IViewProperties, η Κλάση ViewProperties και η Μέθοδος IPresentation.getViewProperties()**
Η μέθοδος IPresentation.getViewProperty() παρέχει πρόσβαση στο IViewProperties και επιτρέπει την αλλαγή του τύπου προβολής της παρουσίασης και της ορατότητας των σημειώσεων όταν η παρουσίαση ανοίγει στο Microsoft PowerPoint.

``` java

 Presentation p = new Presentation();

p.getViewProperties().setLastView(ViewType.SlideMasterView);

```
#### **Προστέθηκαν οι μέθοδοι Aspose.Slides.IShapeCollection.addClone(...) και .insertClone(...)**
Οι μέθοδοι

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), and
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

προσθέτουν/εισάγουν ένα αντίγραφο του καθορισμένου σχήματος στη συλλογή. 

``` java

 Presentation srcPres = new Presentation("data/Source Frame.pptx");

IShapeCollection sourceShapes = srcPres.getSlides().get_Item(0).getShapes();

ILayoutSlide blankLayout = srcPres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);

ISlide destSlide = srcPres.getSlides().addEmptySlide(blankLayout);

IShapeCollection destShapes = destSlide.getShapes();

destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());

destShapes.addClone(sourceShapes.get_Item(2));

destShapes.addClone(sourceShapes.get_Item(3), 50, 200, 50, 50);

destShapes.addClone(sourceShapes.get_Item(4));

destShapes.addClone(sourceShapes.get_Item(5), 300, 300, 50, 200);

destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

```
#### **Προστέθηκε η διεπαφή Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
Αυτή η διεπαφή καθορίζει τους τύπους τιμών στη λίστα ιδιοτήτων ChartDataPoint.ErrorBarsCustomValues. 

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

IErrorBarsFormat errBarX = series.getErrorBarsXFormat();

IErrorBarsFormat errBarY = series.getErrorBarsYFormat();

errBarX.setVisible(true);

errBarY.setVisible(true);

errBarX.setValueType(ErrorBarValueType.Custom);

errBarY.setValueType(ErrorBarValueType.Custom);

IChartDataPointCollection points = series.getDataPoints();

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(DataSourceType.DoubleLiterals);

for (int i = 0; i < points.size(); i++)

{

    points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);

}

pres.save("data/ErrorBarsCustomValues.pptx", SaveFormat.Pptx);

```
#### **Προστέθηκε η διεπαφή Aspose.Slides.Charts.IErrorBarsCustomValues**
Όταν η ιδιότητα IErrorBarsFormat.ValueType είναι ίση με Custom, για να καθορίσετε την τιμή χρησιμοποιήστε την ιδιότητα ErrorBarCustomValues του συγκεκριμένου σημείου δεδομένων στη συλλογή DataPoints της σειράς. 

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

IErrorBarsFormat errBarX = series.getErrorBarsXFormat();

IErrorBarsFormat errBarY = series.getErrorBarsYFormat();

errBarX.setVisible(true);

errBarY.setVisible(true);

errBarX.setValueType(ErrorBarValueType.Custom);

errBarY.setValueType(ErrorBarValueType.Custom);

IChartDataPointCollection points = series.getDataPoints();

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(DataSourceType.DoubleLiterals);

for (int i = 0; i < points.size(); i++)

{

    points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);

}

pres.save("data/ErrorBarsCustomValues.pptx", SaveFormat.Pptx);

```
#### **Προστέθηκε η διεπαφή Aspose.Slides.Charts.IErrorBarsFormat**
Αυτή η διεπαφή αντιπροσωπεύει τις γραμμές σφάλματος των σειρών διαγραμμάτων. 
Σε περίπτωση προσαρμοσμένου τύπου τιμής, για να καθορίσετε την τιμή χρησιμοποιήστε την ιδιότητα ErrorBarCustomValues ενός συγκεκριμένου σημείου δεδομένων στη συλλογή DataPoins της σειράς. 

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();

IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

errBarX.setVisible(true);

errBarY.setVisible(true);

errBarX.setValueType(ErrorBarValueType.Fixed);

errBarX.setValue(0.1f);

errBarY.setValueType(ErrorBarValueType.Percentage);

errBarY.setValue(5);

errBarX.setType(ErrorBarType.Plus);

errBarY.getFormat().getLine().setWidth(2);

errBarX.setEndCap(true);

pres.save("data/ErrorBars.pptx", SaveFormat.Pptx);

```