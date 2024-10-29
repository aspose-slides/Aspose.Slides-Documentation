---
title: Aspose.Slides for Java 14.8.0 における公開 API と後方互換性のない変更
type: docs
weight: 70
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 14.8.0 APIに導入されたすべての [追加された](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) クラス、メソッド、プロパティなど、任意の新しい制限やその他の [変更](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) を一覧表示します。

{{% /alert %}} 
## **公開 API の変更**
### **Aspose.Slides.Charts.IChartSeries.getOverlap()、IChartSeriesGroup.getOverlap()、および setOverlap(byte) メソッドを追加**
Aspose.Slides.Charts.IChartSeries.getOverlap() は、2D チャートでの棒と列の重なり具合を取得します（範囲は -100 から 100）。
このメソッドは特定の系列だけでなく、親系列グループのすべての系列に対しても適用されます - これは適切なグループプロパティの投影です。

- 親系列グループにアクセスするには IChartSeries.getParentSeriesGroup() メソッドを使用します。
- 値を管理するには IChartSeriesGroup.getOverlap() および setOverlap(byte) メソッドを使用します。

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **ShapeThumbnailBounds.Appearance 列挙値を追加**
この形状サムネイルを作成するメソッドにより、開発者は形状の外観の境界内に形状サムネイルを生成できます。すべての形状効果を考慮に入れます。生成された形状サムネイルはスライドの境界によって制限されます。

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **VbaProject クラスおよび IVbaProject インターフェースを追加、Presentation.getVbaProject() および setVbaProject(VbaProject) メソッドを変更**
新しい機能により、開発者はプレゼンテーション内で VBA プロジェクトを作成および編集できるようになりました。

``` java

 Presentation pres = new Presentation();

// 新しい VBA プロジェクトを作成

pres.setVbaProject(new VbaProject());

// VBA プロジェクトに空のモジュールを追加

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// モジュールのソースコードを設定

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// <stdole> への参照を作成

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Office への参照を作成

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBA プロジェクトに参照を追加

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```