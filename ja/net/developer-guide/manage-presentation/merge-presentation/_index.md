---
title: C# を使用して PowerPoint プレゼンテーション (PPT, PPTX) を効率的にマージ
linktitle: プレゼンテーションのマージ
type: docs
weight: 40
url: /ja/net/merge-presentation/
keywords: "PowerPoint をマージ, PPTX, PPT, PowerPoint を結合, プレゼンテーションをマージ, プレゼンテーションを結合, C#, Csharp, .NET"
description: "C# または .NET で PowerPoint プレゼンテーションを簡単にマージまたは結合する方法を学びます。"
---

## **プレゼンテーション統合の最適化**

Aspose.Slides for .NET を使用して、スタイル、レイアウト、すべての要素を保持しながら PowerPoint プレゼンテーションをシームレスに結合できます。他のツールとは異なり、Aspose.Slides は品質を損なったりデータを失ったりすることなくプレゼンテーションを統合します。プレゼンテーション全体、特定のスライド、さらには異なるファイル形式（PPT から PPTX など）もマージできます。

### **マージ機能**

- **フルプレゼンテーションマージ**：すべてのスライドを単一ファイルにまとめます。
- **特定スライドマージ**：選択したスライドを選んで結合します。
- **クロスフォーマットマージ**：異なる形式のプレゼンテーションを統合し、整合性を維持します。

{{% alert title="Tip" color="primary" %}}  

PowerPoint プレゼンテーションを**無料のオンラインツール**で**すばやくマージ**したいですか？[**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger) を試してください。  

- **PowerPoint ファイルを簡単にマージ**：複数の **PPT、PPTX、ODP** プレゼンテーションを単一ファイルに結合します。  
- **異なる形式に対応**：**PPT から PPTX**、**PPTX から ODP** などをマージできます。  
- **インストール不要**：ブラウザ上で直接動作し、速く安全です。  

[![オンラインで PowerPoint ファイルをマージ](slides-merger.png)](https://products.aspose.app/slides/merger)  

今すぐ **Aspose の無料オンラインツール** で PowerPoint ファイルのマージを開始しましょう！  

{{% /alert %}}

## **プレゼンテーションのマージ**

プレゼンテーションを[別のプレゼンテーションにマージ](https://products.aspose.com/slides/net/merger/ppt/)すると、スライドを単一のプレゼンテーションに結合して 1 つのファイルにします。 

{{% alert title="Info" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPoint や OpenOffice）には、このようにプレゼンテーションを結合する機能がありません。  

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) は、さまざまな方法でプレゼンテーションをマージできるようにします。形状、スタイル、テキスト、書式設定、コメント、アニメーションなど、すべての要素を失うことなくプレゼンテーションをマージできます。  

**参照**  

[スライドをクローン](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **マージできるもの**

Aspose.Slides を使用すると、次のものをマージできます  

* プレゼンテーション全体。すべてのスライドが 1 つのプレゼンテーションにまとめられます  
* 特定のスライド。選択したスライドが 1 つのプレゼンテーションにまとめられます  
* 同一形式のプレゼンテーション（PPT → PPT、PPTX → PPTX 等）および異なる形式（PPT → PPTX、PPTX → ODP 等）間で相互にマージできます。  

{{% alert title="Note" color="warning" %}} 

プレゼンテーション以外にも、Aspose.Slides は次のファイルをマージできます：  

* [画像](https://products.aspose.com/slides/net/merger/image-to-image/)、例: [JPG から JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/)、[PNG から PNG](https://products.aspose.com/slides/net/merger/png-to-png/)  
* ドキュメント、例: [PDF から PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/)、[HTML から HTML](https://products.aspose.com/slides/net/merger/html-to-html/)  
* 異なるファイル同士、例: [画像から PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/)、[JPG から PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/)、[TIFF から PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/)。  

{{% /alert %}}

### **マージオプション**

以下を決定するオプションを適用できます。  

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか  
* 出力プレゼンテーションのすべてのスライドに特定のスタイルを使用するか  

プレゼンテーションをマージするには、Aspose.Slides は [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) メソッド（[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) インターフェイス）を提供します。 `AddClone` メソッドには、マージプロセスのパラメータを定義する複数の実装があります。すべての Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションを持っているので、スライドをマージしたいプレゼンテーションから `AddClone` メソッドを呼び出すことができます。  

`AddClone` メソッドは `ISlide` オブジェクトを返します。これはソーススライドのクローンです。出力プレゼンテーションのスライドは、単にソースのスライドのコピーです。したがって、元のプレゼンテーションに影響を与えることなく、結果として得られるスライドに変更（例: スタイルや書式オプション、レイアウトの適用）を加えることができます。  

## **プレゼンテーションのマージ** 

Aspose.Slides は、スライドのレイアウトとスタイルを保持したままスライドを結合できる [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) メソッドを提供します（デフォルトパラメータ）。  

以下の C# コードは、プレゼンテーションをマージする方法を示しています:  
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


## **スライドマスター付きプレゼンテーションのマージ** 

Aspose.Slides は、スライドマスターテンプレートを適用しながらスライドを結合できる [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) メソッドを提供します。必要に応じて、出力プレゼンテーションのスライドのスタイルを変更できます。  

この C# コードは上記の操作を示しています:  
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

スライドマスターのレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブールパラメータが true に設定されていれば、ソーススライドのレイアウトが使用されます。そうでなければ、[PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) がスローされます。 

{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを適用したい場合は、マージ時に [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) メソッドを使用してください。  

## **プレゼンテーションから特定スライドをマージ** 

複数のプレゼンテーションから特定のスライドをマージすることは、カスタムスライドデッキを作成するのに便利です。Aspose.Slides for .NET を使用すると、必要なスライドだけを選択してインポートできます。API は元のスライドの書式、レイアウト、デザインを保持します。  

以下の C# コードは新しいプレゼンテーションを作成し、他の 2 つのプレゼンテーションからタイトルスライドを追加し、結果をファイルに保存します:  
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


## **スライドレイアウト付きプレゼンテーションのマージ** 

この C# コードは、好みのスライドレイアウトを適用しながらプレゼンテーションからスライドを結合し、1 つの出力プレゼンテーションを作成する方法を示しています:  
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


## **異なるスライドサイズのプレゼンテーションをマージ** 

{{% alert title="Note" color="warning" %}} 

異なるスライドサイズのプレゼンテーションはマージできません。 

{{% /alert %}} 

異なるスライドサイズのプレゼンテーションを 2 つマージするには、どちらかのプレゼンテーションのサイズを調整して、もう一方のサイズに合わせる必要があります。  

このサンプルコードは上記の操作を示しています:  
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


## **スライドをプレゼンテーションのセクションにマージ** 

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

Aspose は、[無料の Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG 画像をマージしたり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。 

{{% /alert %}}

## **よくある質問** 

**マージ時にスピーカーノートは保持されますか？**  

はい。スライドをクローンする際、Aspose.Slides はノート、書式設定、アニメーションなどすべてのスライド要素を引き継ぎます。  

**コメントとその作成者は転送されますか？**  

コメントはスライドコンテンツの一部としてスライドにコピーされます。コメント作者ラベルは、結果のプレゼンテーションのコメントオブジェクトとして保持されます。  

**元のプレゼンテーションがパスワードで保護されている場合はどうなりますか？**  

パスワードで[開く](/slides/ja/net/password-protected-presentation/)必要があります。[LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) を使用して開き、ロード後にそれらのスライドを保護されていないターゲットファイル（または保護されたファイル）に安全にクローンできます。  

**マージ操作はどの程度スレッドセーフですか？**  

同じ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスを[複数スレッド](/slides/ja/net/multithreading/)から使用しないでください。推奨ルールは「1 ドキュメント ― 1 スレッド」です。別々のファイルは別スレッドで並行処理できます。