---
title: Aspose.Slides for Java 14.6.0におけるパブリックAPIと後方互換性のない変更
type: docs
weight: 50
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 14.6.0 APIに導入されたすべての[追加された](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/)クラス、メソッド、プロパティ、その他の新しい制限および変更を一覧表示します。

{{% /alert %}} 
## **パブリックAPIの変更**
### **追加されたクラス、メソッド、インターフェースおよび列挙型**
#### **追加されたViewType列挙型、IViewPropertiesインターフェース、ViewPropertiesクラスおよびIPresentation.getViewProperties()メソッド**
IPresentation.getViewProperty()メソッドはIViewPropertiesへのアクセスを提供し、プレゼンテーションがMicrosoft PowerPointで開かれたときに、プレゼンテーションの表示タイプとノートの可視性を変更できるようにします。

``` java

 Presentation p = new Presentation();

p.getViewProperties().setLastView(ViewType.SlideMasterView);

```
#### **Aspose.Slides.IShapeCollection.addClone(...)および.insertClone(...)メソッドの追加**
メソッド

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), および
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

指定されたシェイプのコピーをコレクションに追加/挿入します。

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
#### **Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValuesインターフェースの追加**
このインターフェースは、ChartDataPoint.ErrorBarsCustomValuesプロパティリストにおける値のタイプを指定します。

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
#### **Aspose.Slides.Charts.IErrorBarsCustomValuesインターフェースの追加**
IErrorBarsFormat.ValueTypeプロパティがCustomに等しい場合、値を指定するには、系列のDataPointsコレクション内の特定のデータポイントのErrorBarCustomValuesプロパティを使用します。

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
#### **Aspose.Slides.Charts.IErrorBarsFormatインターフェースの追加**
このインターフェースは、チャート系列の誤差バーを表します。
カスタム値タイプの場合、特定の値を指定するには、系列のDataPoinsコレクション内の特定のデータポイントのErrorBarCustomValuesプロパティを使用します。

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