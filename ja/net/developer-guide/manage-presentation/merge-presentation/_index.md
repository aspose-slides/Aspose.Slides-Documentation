---
title: .NET でプレゼンテーションを効率的にマージ
linktitle: プレゼンテーションのマージ
type: docs
weight: 40
url: /ja/net/merge-presentation/
keywords:
- PowerPoint のマージ
- プレゼンテーションのマージ
- スライドのマージ
- PPT のマージ
- PPTX のマージ
- ODP のマージ
- PowerPoint の統合
- プレゼンテーションの統合
- スライドの統合
- PPT の統合
- PPTX の統合
- ODP の統合
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint (PPT, PPTX) と OpenDocument (ODP) のプレゼンテーションを手軽にマージし、ワークフローを簡素化します。"
---

## **プレゼンテーションのマージを最適化する**

Aspose.Slides for .NET を使用して、スタイル、レイアウト、すべての要素を保持しながら PowerPoint プレゼンテーションをシームレスに結合できます。他のツールとは異なり、Aspose.Slides は品質やデータを失うことなくプレゼンテーションをブレンドします。プレゼンテーション全体、特定のスライド、さらには異なるファイル形式（PPT から PPTX など）もマージできます。

### **マージ機能**

- **フルプレゼンテーションマージ:** すべてのスライドを 1 つのファイルにまとめます。
- **特定スライドマージ:** 選択したスライドを選んで結合します。
- **クロスフォーマットマージ:** さまざまな形式のプレゼンテーションを統合し、完全性を維持します。

{{% alert title="Tip" color="primary" %}}  

手軽で**無料のオンラインツール**で**PowerPoint プレゼンテーションをマージ**したいですか？[**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger) をお試しください。  

- **PowerPoint ファイルを簡単にマージ**: 複数の **PPT, PPTX, ODP** プレゼンテーションを 1 つのファイルに結合します。  
- **異なる形式に対応**: **PPT から PPTX**、**PPTX から ODP** などをマージします。  
- **インストール不要**: ブラウザ上で直接動作し、迅速かつ安全です。  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

今すぐ **Aspose の無料オンラインツール**で PowerPoint ファイルのマージを開始しましょう！  

{{% /alert %}}

## **プレゼンテーションのマージ**

プレゼンテーションを[別のプレゼンテーションにマージ](https://products.aspose.com/slides/net/merger/ppt/)すると、スライドを 1 つのプレゼンテーションに効果的に結合して 1 つのファイルが得られます。 

{{% alert title="Info" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPoint や OpenOffice）には、このようにプレゼンテーションを結合する機能がありません。 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) は、さまざまな方法でプレゼンテーションをマージできます。形状、スタイル、テキスト、書式設定、コメント、アニメーションなど、すべての要素を失うことなくプレゼンテーションをマージできます。 

**参照**

[スライドのクローン](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **何をマージできるか**

Aspose.Slides を使用すると、次のものをマージできます  

* 完全なプレゼンテーション。すべてのプレゼンテーションのスライドが 1 つのプレゼンテーションにまとめられます  
* 特定のスライド。選択したスライドが 1 つのプレゼンテーションにまとめられます  
* 同一形式（PPT から PPT、PPTX から PPTX など）および異なる形式（PPT から PPTX、PPTX から ODP など）のプレゼンテーションを相互にマージできます。 

{{% alert title="Note" color="warning" %}} 

プレゼンテーションに加えて、Aspose.Slides は他のファイルのマージも可能です：

* [画像]、たとえば [JPG から JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) や [PNG から PNG](https://products.aspose.com/slides/net/merger/png-to-png/)  
* 文書、たとえば [PDF から PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) や [HTML から HTML](https://products.aspose.com/slides/net/merger/html-to-html/)  
* 異なる種類のファイルを組み合わせることもできます。たとえば [画像から PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) や [JPG から PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/)、[TIFF から PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/)  

{{% /alert %}}

### **マージオプション**

次のことを決定するオプションを適用できます  

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか  
* 出力プレゼンテーションのすべてのスライドに特定のスタイルを使用するか  

プレゼンテーションをマージするには、Aspose.Slides は [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) メソッド（[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) インターフェイスから）を提供します。`AddClone` メソッドにはプレゼンテーション マージ処理のパラメータを定義する複数の実装があります。すべての Presentation オブジェクトには [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションがあるため、スライドをマージしたいプレゼンテーションから `AddClone` メソッドを呼び出すことができます。  

`AddClone` メソッドは `ISlide` オブジェクトを返し、これはソーススライドのクローンです。出力プレゼンテーションのスライドは単にソースのスライドのコピーです。そのため、元のプレゼンテーションに影響を与えることなく、結果のスライドに変更（たとえばスタイルや書式設定オプション、レイアウトの適用）を加えることができます。 

## **プレゼンテーションのマージ** 

Aspose.Slides は、スライドがレイアウトとスタイルを保持したまま結合できるデフォルト パラメータの [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) メソッドを提供します。 

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


## **スライドマスターでプレゼンテーションをマージ** 

Aspose.Slides は、スライド マスター プレゼンテーション テンプレートを適用しながらスライドを結合できる [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) メソッドを提供します。この方法により、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。 

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

スライド マスターのレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブール パラメータが true に設定されていれば、ソーススライドのレイアウトが使用されます。そうでなければ、[PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) がスローされます。 

{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを使用したい場合は、マージ時に [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) メソッドを代わりに使用してください。 

## **プレゼンテーションから特定のスライドをマージ** 

複数のプレゼンテーションから特定のスライドをマージすることは、カスタム スライド デッキを作成する際に便利です。Aspose.Slides for .NET は、必要なスライドだけを選択してインポートできます。API は元のスライドの書式設定、レイアウト、デザインを保持します。 

以下の C# コードは新しいプレゼンテーションを作成し、他の 2 つのプレゼンテーションからタイトル スライドを追加して、結果をファイルに保存します:
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


## **スライドレイアウトでプレゼンテーションをマージ** 

この C# コードは、好みのスライド レイアウトを適用しながらプレゼンテーションからスライドを結合し、1 つの出力プレゼンテーションを作成する方法を示しています:
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

サイズが異なる 2 つのプレゼンテーションをマージするには、いずれかのプレゼンテーションのサイズをもう一方に合わせて変更する必要があります。 

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

Aspose は、[FREE Collage web app](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用すると、[JPG から JPG](https://products.aspose.app/slides/collage/jpg) や PNG から PNG 画像をマージしたり、[photo grids](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。 

{{% /alert %}}

## **FAQ**

**マージ中にスピーカーノートは保持されますか？**

はい。スライドをクローンすると、Aspose.Slides はノート、書式設定、アニメーションを含むすべてのスライド要素を引き継ぎます。

**コメントとその作成者は転送されますか？**

コメントはスライド内容の一部としてスライドとともにコピーされます。コメント作成者のラベルは結果のプレゼンテーション内のコメントオブジェクトとして保持されます。

**ソースのプレゼンテーションがパスワードで保護されている場合はどうなりますか？**

[パスワードで開く](/slides/ja/net/password-protected-presentation/)必要があり、[LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) を使用します。読み込んだ後、そのスライドは保護されていないターゲット ファイル（または保護されたファイル）に安全にクローンできます。

**マージ操作はどの程度スレッドセーフですか？**

同じ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスを [複数のスレッド](/slides/ja/net/multithreading/) から使用しないでください。推奨ルールは「1 ドキュメント – 1 スレッド」です。別々のファイルは別スレッドで並行処理できます。