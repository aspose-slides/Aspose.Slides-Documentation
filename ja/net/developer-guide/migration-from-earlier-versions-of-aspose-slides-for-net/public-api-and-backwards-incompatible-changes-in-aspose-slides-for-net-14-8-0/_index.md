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
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP のプレゼンテーション ソリューションを円滑に移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.8.0 APIで導入された、追加または削除されたクラス、メソッド、プロパティなど、すべての変更とその他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
### **変更されたプロパティ**
#### **IVbaProject インターフェイスの追加、Presentation.VbaProject プロパティの変更**
Presentation クラスの VbaProject プロパティは置き換えられました。VbaProject プロパティの VBA プロジェクトの生バイト表現の代わりに、新しい IVbaProject インターフェイス実装が追加されました。

IVbaProject プロパティを使用して、プレゼンテーションに埋め込まれた VBA プロジェクトを管理できます。新しいプロジェクト参照を追加したり、既存のモジュールを編集したり、新しいモジュールを作成したりできます。

また、IVbaProject インターフェイスを実装した VbaProject クラスを使用して新しい VBA プロジェクトを作成できます。

以下の例は、1 つのモジュールを含むシンプルな VBA プロジェクトを作成し、ライブラリへの 2 つの必須参照を追加する方法を示しています。

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

この例は、既存のプレゼンテーションから新しいプレゼンテーションへ VBA プロジェクトをコピーする方法を示しています。

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **インターフェイス、プロパティ、列挙オプションの追加**
#### **Aspose.Slides.Charts.IChartSeries.Overlap プロパティの追加**
Aspose.Slides.Charts.IChartSeries.Overlap プロパティは、2D チャートで棒や列がどの程度重なるかを指定します（-100 から 100 の範囲）。

このプロパティは、この系列だけでなく、親系列グループ内のすべての系列に適用されるプロパティの投影であり、読み取り専用です。

- ParentSeriesGroup プロパティを使用して、親系列グループにアクセスします。
- ParentSeriesGroup.Overlap の読み書き可能なプロパティを使用して値を変更します。

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
#### **Aspose.Slides.Charts.IChartSeriesGroup.Overlap プロパティの追加**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap プロパティは、2D チャートで棒や列がどの程度重なるかを指定します（-100 から 100 の範囲）。

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **ShapeThumbnailBounds.Appearance 列挙値の追加**
この形状サムネイル作成メソッドを使用すると、形状の外観の境界内でサムネイルを生成できます。すべての形状効果が考慮され、生成されたサムネイルはスライドの境界で制限されます。

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```