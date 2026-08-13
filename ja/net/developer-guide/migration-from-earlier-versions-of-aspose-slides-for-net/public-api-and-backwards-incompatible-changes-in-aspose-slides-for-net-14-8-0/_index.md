---
title: Aspose.Slides for .NET 14.8.0 のパブリック API と後方互換性がない変更
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}}

このページでは、Aspose.Slides for .NET 14.8.0 APIで導入された、すべての[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)または[削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)されたクラス、メソッド、プロパティ等、及びその他の変更を一覧表示します。

{{% /alert %}} 
## **パブリックAPIの変更**
### **変更されたプロパティ**
#### **IVbaProject インターフェイスの追加、Presentation.VbaProject プロパティの変更**
Presentation クラスの VbaProject プロパティは置き換えられました。VbaProject プロパティの VBA プロジェクトの生バイト表現の代わりに、新しい IVbaProject インターフェイス実装が追加されました。

IVbaProject プロパティを使用して、プレゼンテーションに埋め込まれた VBA プロジェクトを管理します。新しいプロジェクト参照を追加したり、既存のモジュールを編集したり、新規に作成したりできます。

また、IVbaProject インターフェイスを実装する VbaProject クラスを使用して新しい VBA プロジェクトを作成できます。

次の例は、1 つのモジュールを含むシンプルな VBA プロジェクトを作成し、ライブラリへの 2 つの必須参照を追加する方法を示しています。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // 新しい VBA プロジェクトを作成

    pres.VbaProject = new VbaProject();

    // VBA プロジェクトに空のモジュールを追加

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // モジュールのソースコードを設定

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // <stdole> への参照を作成

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Office への参照を作成

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBA プロジェクトに参照を追加

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

この例は、既存のプレゼンテーションから新しいプレゼンテーションへ VBA プロジェクトをコピーする方法を示しています。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **追加されたインターフェイス、プロパティ、列挙オプション**
#### **Aspose.Slides.Charts.IChartSeries.Overlap プロパティの追加**
Aspose.Slides.Charts.IChartSeries.Overlap プロパティは、2D チャートにおける棒や列の重なり具合を指定します（-100 から 100 の範囲）。

このプロパティは、この系列だけでなく、親系列グループ内のすべての系列に対して適用される、該当グループプロパティの投影です。そのため、読み取り専用プロパティです。

- ParentSeriesGroup プロパティを使用して、親系列グループにアクセスします。
- ParentSeriesGroup.Overlap の読み書きプロパティを使用して、値を変更します。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


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
Aspose.Slides.Charts.IChartSeriesGroup.Overlap プロパティは、2D チャートにおける棒や列の重なり具合を指定します（-100 から 100 の範囲）。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **ShapeThumbnailBounds.Appearance 列挙体値の追加**
この形状サムネイル作成メソッドにより、形状の外観の範囲内でサムネイルを生成できます。すべての形状効果を考慮し、生成されたサムネイルはスライドの境界に制限されます。

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```