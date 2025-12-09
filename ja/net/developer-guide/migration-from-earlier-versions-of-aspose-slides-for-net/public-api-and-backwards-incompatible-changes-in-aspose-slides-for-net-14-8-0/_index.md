---
title: Aspose.Slides for .NET 14.8.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API 更新と重大な変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーションソリューションをスムーズに移行できます。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.8.0 APIで導入された、追加または削除されたクラス、メソッド、プロパティ等、およびその他の変更をすべて一覧で示します。

{{% /alert %}} 
## **Public API Changes**
### **Changed Properties**
#### **Added the IVbaProject Interface, Changed the Presentation.VbaProject Property**
Presentation クラスの VbaProject プロパティが置き換えられました。VbaProject プロパティの VBA プロジェクトの生バイト表現の代わりに、新しい IVbaProject インターフェイス実装が追加されました。

IVbaProject プロパティを使用して、プレゼンテーションに埋め込まれた VBA プロジェクトを管理できます。新しいプロジェクト参照を追加したり、既存のモジュールを編集したり、新規に作成したりできます。

また、IVbaProject インターフェイスを実装した VbaProject クラスを使用して新しい VBA プロジェクトを作成することもできます。

以下の例は、1 つのモジュールを含むシンプルな VBA プロジェクトを作成し、2 つの必須ライブラリへの参照を追加する方法を示しています。

``` csharp

 using (Presentation pres = new Presentation())

{

    // Create new VBA Project

    pres.VbaProject = new VbaProject();

    // Add empty module to the VBA project

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Set module source code

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Create reference to <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Create reference to Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Add references to the VBA project

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

この例は、既存のプレゼンテーションから VBA プロジェクトをコピーして新しいプレゼンテーションに設定する方法を示しています。

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **Added Interfaces, Properties and Enumeration Options**
#### **Added the Aspose.Slides.Charts.IChartSeries.Overlap Property**
Aspose.Slides.Charts.IChartSeries.Overlap プロパティは、2D チャートの棒や列がどの程度重なるか（-100 から 100 の範囲）を指定します。

このプロパティはこのシリーズだけでなく、親シリーズ グループ内のすべてのシリーズに対する投射であり、読み取り専用です。

- 親シリーズ グループにアクセスするには ParentSeriesGroup プロパティを使用します。
- 値を変更するには ParentSeriesGroup.Overlap の読み書きプロパティを使用します。

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}

``` 
#### **Added the Aspose.Slides.Charts.IChartSeriesGroup.Overlap Property**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap プロパティは、2D チャートで棒や列がどの程度重なるか（-100 から 100 の範囲）を指定します。

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Added the ShapeThumbnailBounds.Appearance Enum Value**
この形状サムネイル作成メソッドは、形状の外観領域内でサムネイルを生成します。すべての形状エフェクトを考慮し、生成されたサムネイルはスライドの境界で制限されます。

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```