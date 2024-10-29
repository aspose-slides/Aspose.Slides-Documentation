---
title: Aspose.Slides for .NET 14.8.0におけるパブリックAPIと後方互換性のない変更
type: docs
weight: 100
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.8.0 APIで追加されたまたは削除されたすべての[追加された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)クラス、メソッド、プロパティなど、及び他の変更をリストします。

{{% /alert %}} 
## **パブリックAPIの変更**
### **変更されたプロパティ**
#### **IVbaProjectインターフェイスを追加し、Presentation.VbaProjectプロパティを変更**
PresentationクラスのVbaProjectプロパティは置き換えられました。VBAプロジェクトの生のバイト表現の代わりに、新しいIVbaProjectインターフェイスの実装が追加されました。

IVbaProjectプロパティを使用して、プレゼンテーションに埋め込まれたVBAプロジェクトを管理します。新しいプロジェクト参照を追加したり、既存のモジュールを編集したり、新しいモジュールを作成したりできます。

また、IVbaProjectインターフェイスを実装したVbaProjectクラスを使用して新しいVBAプロジェクトを作成することもできます。

次の例は、1つのモジュールを含むシンプルなVBAプロジェクトを作成し、ライブラリに必要な2つの参照を追加する方法を示しています。

``` csharp

 using (Presentation pres = new Presentation())

{

    // 新しいVBAプロジェクトを作成

    pres.VbaProject = new VbaProject();

    // VBAプロジェクトに空のモジュールを追加

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // モジュールのソースコードを設定

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // <stdole>への参照を作成

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Officeへの参照を作成

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBAプロジェクトに参照を追加

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

この例は、既存のプレゼンテーションから新しいプレゼンテーションにVBAプロジェクトをコピーする方法を示しています。

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **追加されたインターフェイス、プロパティおよび列挙オプション**
#### **Aspose.Slides.Charts.IChartSeries.Overlapプロパティを追加**
Aspose.Slides.Charts.IChartSeries.Overlapプロパティは、2Dチャート上でのバーとコラムの重なり具合を指定します（-100から100までの範囲）。

これはこの系列だけでなく親系列グループ内のすべての系列のプロパティです - これは該当するグループプロパティの投影です。このため、このプロパティは読み取り専用です。

- ParentSeriesGroupプロパティを使用して親系列グループにアクセスします。
- ParentSeriesGroup.Overlapの読み書き可能なプロパティを使用して値を変更します。

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
#### **Aspose.Slides.Charts.IChartSeriesGroup.Overlapプロパティを追加**
Aspose.Slides.Charts.IChartSeriesGroup.Overlapプロパティは、2Dチャート上でのバーとコラムの重なり具合を指定します（-100から100まで）。

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **ShapeThumbnailBounds.Appearance列挙値を追加**
この形状サムネイル作成の方法では、形状の外観の範囲内で形状サムネイルを生成できます。すべての形状効果を考慮に入れます。生成された形状サムネイルはスライドの範囲に制限されます。

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```