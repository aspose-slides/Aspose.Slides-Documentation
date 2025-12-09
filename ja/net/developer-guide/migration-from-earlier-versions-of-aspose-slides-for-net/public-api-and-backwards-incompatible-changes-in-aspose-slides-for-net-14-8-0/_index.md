---
title: Aspose.Slides for .NET 14.8.0 の公開 API と下位互換性のない変更
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
description: "Aspose.Slides for .NET の公開 API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーションソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページは、Aspose.Slides for .NET 14.8.0 APIで導入された[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)または[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)されたクラス、メソッド、プロパティなど、その他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
### **変更されたプロパティ**
#### **IVbaProject インターフェイスの追加、Presentation.VbaProject プロパティの変更**
Presentation クラスの VbaProject プロパティは置き換えられました。VbaProject プロパティの VBA プロジェクトの生バイト表現の代わりに、新しい IVbaProject インターフェイス実装が追加されました。

IVbaProject プロパティを使用して、プレゼンテーションに埋め込まれた VBA プロジェクトを管理できます。新しいプロジェクト参照の追加、既存モジュールの編集、新規モジュールの作成が可能です。

また、IVbaProject インターフェイスを実装する VbaProject クラスを使用して新しい VBA プロジェクトを作成できます。

以下の例は、1 つのモジュールを含むシンプルな VBA プロジェクトを作成し、必要な 2 つのライブラリ参照を追加する方法を示しています。

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
Aspose.Slides.Charts.IChartSeries.Overlap プロパティは、2D チャート上で棒や列がどれだけ重なるかを指定します（範囲は -100 から 100）。

このプロパティは、この系列だけでなく親系列グループ内のすべての系列に適用されるもので、対応するグループプロパティの投影です。そのため、このプロパティは読み取り専用です。

- 親系列グループにアクセスするには ParentSeriesGroup プロパティを使用します。
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
#### **Aspose.Slides.Charts.IChartSeriesGroup.Overlap プロパティの追加**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap プロパティは、2D チャート上で棒や列がどれだけ重なるかを指定します（範囲は -100 から 100）。

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **ShapeThumbnailBounds.Appearance 列挙体値の追加**
この形状サムネイル作成メソッドは、形状の外観境界内でサムネイルを生成できます。すべての形状効果を考慮し、生成されたサムネイルはスライドの境界で制限されます。

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```