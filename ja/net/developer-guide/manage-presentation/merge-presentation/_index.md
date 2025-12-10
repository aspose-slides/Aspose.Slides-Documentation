---
title: ".NET でプレゼンテーションを効率的にマージ"
linktitle: "プレゼンテーションのマージ"
type: docs
weight: 40
url: /ja/net/merge-presentation/
keywords:
- "PowerPoint をマージ"
- "プレゼンテーションをマージ"
- "スライドをマージ"
- "PPT をマージ"
- "PPTX をマージ"
- "ODP をマージ"
- "PowerPoint を結合"
- "プレゼンテーションを結合"
- "スライドを結合"
- "PPT を結合"
- "PPTX を結合"
- "ODP を結合"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して、PowerPoint (PPT, PPTX) および OpenDocument (ODP) プレゼンテーションを手軽にマージし、ワークフローを効率化します。"
---

## **プレゼンテーションマージの最適化**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) を使用すると、スタイル、レイアウト、すべての要素を保持したまま PowerPoint プレゼンテーションをシームレスに結合できます。他のツールとは異なり、Aspose.Slides は品質やデータを失うことなくプレゼンテーションをブレンドします。プレゼンテーション全体、特定のスライド、さらには異なるファイル形式（PPT から PPTX など）をマージできます。

### **マージ機能**

- **フルプレゼンテーション マージ:** すべてのスライドを 1 つのファイルにまとめます。
- **特定スライド マージ:** 選択したスライドを組み合わせます。
- **クロスフォーマット マージ:** 形式が異なるプレゼンテーションを統合し、完全性を維持します。

{{% alert title="Tip" color="primary" %}}  

PowerPoint プレゼンテーションを **無料でオンライン** にマージしたいですか？[**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger) を試してください。  

- **PowerPoint ファイルを簡単にマージ**: 複数の **PPT、PPTX、ODP** プレゼンテーションを 1 つのファイルに結合できます。  
- **異なる形式に対応**: **PPT から PPTX**、**PPTX から ODP** などをマージできます。  
- **インストール不要**: ブラウザ上で直接動作し、速く安全です。  

[![オンラインでPowerPointファイルをマージ](slides-merger.png)](https://products.aspose.app/slides/merger)  

今日から **Aspose の無料オンラインツール** で PowerPoint ファイルのマージを開始しましょう！  

{{% /alert %}}

## **プレゼンテーションのマージ**

[1 つのプレゼンテーションを別のプレゼンテーションにマージする](https://products.aspose.com/slides/net/merger/ppt/) と、スライドを 1 つのプレゼンテーションに結合して 1 つのファイルにします。

{{% alert title="Info" color="info" %}}

ほとんどのプレゼンテーション ソフトウェア（PowerPoint や OpenOffice）には、プレゼンテーションをこのように結合する機能がありません。

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) は、さまざまな方法でプレゼンテーションを結合できるようにします。形状、スタイル、テキスト、書式設定、コメント、アニメーションなど、すべての要素を失うことなくマージできます。

**関連項目**

[Clone Slides](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **マージできる対象**

Aspose.Slides を使用すると、次のものをマージできます。

* プレゼンテーション全体。すべてのスライドが 1 つのプレゼンテーションにまとめられます。
* 特定のスライド。選択したスライドが 1 つのプレゼンテーションにまとめられます。
* 同一形式（PPT → PPT、PPTX → PPTX など）および異なる形式（PPT → PPTX、PPTX → ODP など）のプレゼンテーション同士を相互にマージします。

{{% alert title="Note" color="warning" %}} 

プレゼンテーションに加えて、Aspose.Slides は次のファイルもマージできます。

* [画像](https://products.aspose.com/slides/net/merger/image-to-image/)（例: [JPG から JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) や [PNG から PNG](https://products.aspose.com/slides/net/merger/png-to-png/)）
* 文書（例: [PDF から PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) や [HTML から HTML](https://products.aspose.com/slides/net/merger/html-to-html/)）
* 異なる種類のファイル（例: [画像から PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) や [JPG から PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/)、[TIFF から PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/)）

{{% /alert %}}

### **マージ オプション**

次のいずれかを決定するオプションを適用できます。

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか
* 出力プレゼンテーションのすべてのスライドに共通のスタイルを使用するか

プレゼンテーションをマージするには、Aspose.Slides は [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) メソッド（[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) インターフェイスから）を提供します。`AddClone` メソッドには、マージ プロセスのパラメーターを定義する複数の実装があります。各 Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションを持っているため、スライドをマージしたいプレゼンテーションから `AddClone` メソッドを呼び出せます。

`AddClone` メソッドは、ソース スライドのクローンである `ISlide` オブジェクトを返します。出力プレゼンテーションのスライドは、単にソースからコピーされたものです。したがって、ソース プレゼンテーションに影響を与えることなく、結果のスライド（例: スタイルや書式設定オプション、レイアウトの適用）を変更できます。

## **プレゼンテーションをマージ**

Aspose.Slides は、スライドのレイアウトとスタイルを保持したままスライドを結合できる [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) メソッドを提供します（デフォルト パラメーター）。

この C# コードはプレゼンテーションのマージ方法を示しています:
```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```


## **スライド マスターを使用したプレゼンテーションのマージ**

Aspose.Slides は、[**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) メソッドを提供し、スライド マスター テンプレートを適用してスライドを結合できます。この方法により、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

この C# コードが上記の操作を示しています:
```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Note" color="warning" %}} 

スライド マスターのスライド レイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブール パラメーターが true に設定されていれば、ソース スライドのレイアウトが使用されます。それ以外の場合は、[PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) がスローされます。 

{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを使用したい場合は、マージ時に [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) メソッドを代わりに使用してください。

## **プレゼンテーションから特定スライドをマージ**

複数のプレゼンテーションから特定スライドをマージすると、カスタム スライド デックの作成に便利です。Aspose.Slides for .NET は、必要なスライドだけを選択してインポートできます。API は元のスライドの書式設定、レイアウト、デザインを保持します。

以下の C# コードは新しいプレゼンテーションを作成し、2 つの別のプレゼンテーションからタイトル スライドを追加して、結果をファイルに保存します:
```cs
using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}
```

```cs
static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```


## **スライド レイアウトを使用したプレゼンテーションのマージ**

この C# コードは、プレゼンテーションからスライドを結合し、好みのスライド レイアウトを適用して 1 つの出力プレゼンテーションを作成する方法を示しています:
```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```


## **異なるスライド サイズのプレゼンテーションをマージ**

{{% alert title="Note" color="warning" %}} 

サイズが異なるスライドを持つプレゼンテーションはマージできません。 

{{% /alert %}}

サイズが異なる 2 つのプレゼンテーションをマージするには、どちらか一方のスライド サイズをもう一方に合わせてリサイズする必要があります。

このサンプル コードは上記の操作を示しています:
```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```


## **スライドをプレゼンテーション セクションにマージ**

この C# コードは、特定のスライドをプレゼンテーションのセクションにマージする方法を示しています:
```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```


スライドはセクションの末尾に追加されます。

{{% alert title="Tip" color="primary" %}}

Aspose は、[FREE Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG の画像をマージしたり、[フォト グリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。 

{{% /alert %}}

## **FAQ**

**マージ時にスピーカーノートは保持されますか？**

はい。スライドをクローンすると、ノート、書式設定、アニメーションを含むすべてのスライド要素が引き継がれます。

**コメントと作者情報は転送されますか？**

コメントはスライド コンテンツの一部としてコピーされます。コメントの作者ラベルは結果のプレゼンテーション内のコメント オブジェクトとして保持されます。

**元のプレゼンテーションがパスワードで保護されている場合は？**

[LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) を使用してパスワードで [開く](/slides/ja/net/password-protected-presentation/) 必要があります。ロード後、これらのスライドは保護されていないターゲット ファイル（または保護されたファイル）に安全にクローンできます。

**マージ操作はどの程度スレッドセーフですか？**

同じ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスを [複数のスレッド](/slides/ja/net/multithreading/) から使用しないでください。推奨ルールは「1 ドキュメント — 1 スレッド」です。別々のファイルは別々のスレッドで並行処理できます。