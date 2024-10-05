---
title: Aspose.Slides for Java 14.8.0におけるパブリックAPIと互換性のない変更
type: docs
weight: 70
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 14.8.0 APIで追加されたすべての[class](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)クラス、メソッド、プロパティなど、新しい制限やその他の[changes](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)をリストしています。

{{% /alert %}} 
## **パブリックAPIの変更**
### **Aspose.Slides.Charts.IChartSeries.getOverlap()、IChartSeriesGroup.getOverlap()、およびsetOverlap(byte)メソッドの追加**
Aspose.Slides.Charts.IChartSeries.getOverlap()は、2Dチャート上でバーやカラムがどれだけ重なるべきかを取得します（-100から100の範囲）。
このメソッドは特定のシリーズだけでなく、親系列グループのすべてのシリーズに適用されます - これは適切なグループプロパティの投影です。

- 親系列グループにアクセスするためにIChartSeries.getParentSeriesGroup()メソッドを使用してください。
- 値を管理するためにIChartSeriesGroup.getOverlap()およびsetOverlap(byte)メソッドを使用してください。

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **ShapeThumbnailBounds.Appearance列挙型値の追加**
この形状のサムネイルを作成する方法は、開発者が見た目の境界内で形状サムネイルを生成できるようにします。すべての形状効果を考慮します。生成された形状のサムネイルはスライドの境界によって制限されます。

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **VbaProjectクラスとIVbaProjectインターフェースの追加、Presentation.getVbaProject()およびsetVbaProject(VbaProject)メソッドの変更**
新しい機能により、開発者はプレゼンテーション内でVBAプロジェクトを作成および編集できるようになります。

``` java

 Presentation pres = new Presentation();

// 新しいVBAプロジェクトを作成

pres.setVbaProject(new VbaProject());

// VBAプロジェクトに空のモジュールを追加

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// モジュールのソースコードを設定

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// <stdole>への参照を作成

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Officeへの参照を作成

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBAプロジェクトに参照を追加

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```