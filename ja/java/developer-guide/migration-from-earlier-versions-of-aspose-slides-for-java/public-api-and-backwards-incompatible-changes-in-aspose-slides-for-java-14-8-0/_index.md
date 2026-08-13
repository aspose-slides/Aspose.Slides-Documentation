---
title: Aspose.Slides for Java 14.8.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for Java 14.8.0
type: docs
weight: 70
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できます。"
---
{{% alert color="info" %}} 
このページでは、Aspose.Slides for Java 14.8.0 APIで導入された、すべての[added](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) クラス、メソッド、プロパティなど、新しい制限やその他の[changes](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) を一覧表示しています。
{{% /alert %}} 
## **Public API Changes**
### **Aspose.Slides.Charts.IChartSeries.getOverlap()、IChartSeriesGroup.getOverlap()、および setOverlap(byte) メソッドを追加**
Aspose.Slides.Charts.IChartSeries.getOverlap() は、2D チャートにおける棒や列の重なり度合いを取得します（範囲は -100 から 100）。
このメソッドは特定のシリーズだけでなく、親シリーズ グループのすべてのシリーズに適用されます。これは該当するグループ プロパティの投影です。

- 親シリーズ グループにアクセスするには IChartSeries.getParentSeriesGroup() メソッドを使用します。
- 値を管理するには IChartSeriesGroup.getOverlap() および setOverlap(byte) メソッドを使用します。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **ShapeThumbnailBounds.Appearance 列挙体の値を追加**
この形状サムネイル作成メソッドにより、開発者は外観の境界内で形状サムネイルを生成できます。すべての形状エフェクトを考慮し、生成されたサムネイルはスライドの境界で制限されます。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **VbaProject クラスと IVbaProject インターフェイスを追加、Presentation.getVbaProject() および setVbaProject(VbaProject) メソッドを変更**
新機能により、開発者はプレゼンテーション内で VBA プロジェクトを作成および編集できるようになりました。

``` java
import com.aspose.slides.*;


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

pres.save("test.pptm", SaveFormat.Pptm);

```