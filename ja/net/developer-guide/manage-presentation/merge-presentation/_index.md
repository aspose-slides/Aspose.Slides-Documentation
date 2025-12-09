---
title: .NET でプレゼンテーションを効率的にマージ
linktitle: プレゼンテーションをマージ
type: docs
weight: 40
url: /ja/net/merge-presentation/
keywords:
- PowerPoint をマージ
- プレゼンテーションをマージ
- スライドをマージ
- PPT をマージ
- PPTX をマージ
- ODP をマージ
- PowerPoint を結合
- プレゼンテーションを結合
- スライドを結合
- PPT を結合
- PPTX を結合
- ODP を結合
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint（PPT、PPTX）および OpenDocument（ODP）プレゼンテーションを手軽にマージし、作業フローを効率化します。"
---

## **プレゼンテーションマージの最適化**

Aspose.Slides for .NET を使用すると、スタイル、レイアウト、すべての要素を保持したままPowerPointプレゼンテーションをシームレスに結合できます。他のツールとは異なり、Aspose.Slides は品質やデータを失うことなくプレゼンテーションをブレンドします。プレゼンテーション全体、特定のスライド、さらには異なるファイル形式（PPT から PPTX など）もマージできます。

### **マージ機能**

- **フルプレゼンテーションマージ:** すべてのスライドを1つのファイルにまとめます。
- **特定スライドマージ:** 選択したスライドを選び、結合します。
- **クロスフォーマットマージ:** 異なる形式のプレゼンテーションを統合し、完全性を保ちます。

{{% alert title="Tip" color="primary" %}}  
PowerPointプレゼンテーションを素早く**無料のオンラインツール**で**マージ**したいですか？[**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger)をお試しください。

- **PowerPointファイルを簡単にマージ**: 複数の**PPT、PPTX、ODP**プレゼンテーションを1つのファイルに結合します。
- **異なる形式に対応**: **PPT から PPTX**、**PPTX から ODP**などをマージします。
- **インストール不要**: ブラウザ上で直接動作し、速くて安全です。

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)

**Asposeの無料オンラインツール**で今すぐPowerPointファイルのマージを開始しましょう！  
{{% /alert %}}

## **プレゼンテーションのマージ**

1つのプレゼンテーションを別のプレゼンテーションに[マージ](https://products.aspose.com/slides/net/merger/ppt/)すると、実質的にスライドを1つのプレゼンテーションに結合して1つのファイルにします。 

{{% alert title="Info" color="info" %}}

ほとんどのプレゼンテーションプログラム（PowerPointやOpenOffice）には、プレゼンテーションをこのように結合する機能がありません。

しかし、[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) はさまざまな方法でプレゼンテーションをマージできます。形状、スタイル、テキスト、書式設定、コメント、アニメーションなど、すべての要素を品質やデータの損失を気にせずにマージできます。

**参照**

[Clone Slides](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.*  
{{% /alert %}}

### **マージできる対象**

Aspose.Slides を使用すると、次のものをマージできます

* プレゼンテーション全体。すべてのスライドが1つのプレゼンテーションにまとめられます
* 特定のスライド。選択したスライドが1つのプレゼンテーションにまとめられます
* 同一フォーマットのプレゼンテーション（PPT から PPT、PPTX から PPTX など）および異なるフォーマット（PPT から PPTX、PPTX から ODP など）同士をマージ

{{% alert title="Note" color="warning" %}}

プレゼンテーション以外にも、Aspose.Slides は以下のファイルのマージをサポートしています。

* [画像](https://products.aspose.com/slides/net/merger/image-to-image/)、例として [JPG から JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) や [PNG から PNG](https://products.aspose.com/slides/net/merger/png-to-png/)
* 文書、例として [PDF から PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) や [HTML から HTML](https://products.aspose.com/slides/net/merger/html-to-html/)
* そして、異なる種類のファイルとして [画像から PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) や [JPG から PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/)、[TIFF から PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/) があります。  
{{% /alert %}}

### **マージオプション**

以下のように、出力プレゼンテーションのスライドのスタイルに関するオプションを適用できます

* 出力プレゼンテーションの各スライドが個別のスタイルを保持するか
* 出力プレゼンテーションのすべてのスライドに特定のスタイルを適用するか

プレゼンテーションをマージするには、Aspose.Slides は[AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)メソッド（[ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) インターフェイス）を提供します。`AddClone` メソッドには、マージプロセスのパラメータを定義する複数の実装があります。各 Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) コレクションを持つため、スライドをマージしたいプレゼンテーションから `AddClone` メソッドを呼び出すことができます。

`AddClone` メソッドは `ISlide` オブジェクトを返し、これは元のスライドのクローンです。出力プレゼンテーションのスライドは単に元スライドのコピーです。したがって、元のプレゼンテーションに影響を与えることを心配せずに、結果のスライドに変更（例えば、スタイルや書式設定オプション、レイアウトの適用）を加えることができます。

## **プレゼンテーションのマージ**

Aspose.Slides は[**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone)メソッドを提供し、スライドがレイアウトとスタイル（デフォルトパラメータ）を保持したまま結合できます。

この C# コードはプレゼンテーションのマージ方法を示します:
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

Aspose.Slides は[**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2)メソッドを提供し、スライドマスターテンプレートを適用しながらスライドを結合できます。これにより、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

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

スライドマスターのスライドレイアウトは自動的に決定されます。適切なレイアウトが決定できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブールパラメータが true に設定されていれば、元スライドのレイアウトが使用されます。そうでなければ、[PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception) がスローされます。  
{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを使用したい場合は、マージ時に [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) メソッドを使用してください。

## **プレゼンテーションから特定のスライドをマージ**

複数のプレゼンテーションから特定のスライドをマージすることは、カスタムのスライドデッキを作成するのに便利です。Aspose.Slides for .NET を使用すると、必要なスライドだけを選択してインポートできます。API は元のスライドの書式、レイアウト、デザインを保持します。

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

この C# コードは、プレゼンテーションからスライドを結合し、希望のスライドレイアウトを適用して1つの出力プレゼンテーションを作成する方法を示します:
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


## **異なるスライドサイズのプレゼンテーションのマージ**

{{% alert title="Note" color="warning" %}}
異なるスライドサイズのプレゼンテーションはマージできません。
{{% /alert %}}

異なるスライドサイズの 2 つのプレゼンテーションをマージするには、どちらかのプレゼンテーションのサイズをもう一方に合わせてリサイズする必要があります。

このサンプルコードは上記の操作を実演しています:
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


## **プレゼンテーションのセクションへスライドをマージ**

この C# コードは、特定のスライドをプレゼンテーションのセクションにマージする方法を示します:
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


スライドはセクションの最後に追加されます。

{{% alert title="Tip" color="primary" %}}

Aspose は[無料の Collage Web アプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用して、[JPG から JPG](https://products.aspose.app/slides/collage/jpg)や PNG から PNG の画像をマージしたり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)を作成したりできます。  
{{% /alert %}}

## **FAQ**

**マージ時にスピーカーノートは保持されますか？**  
はい。スライドをクローンすると、Aspose.Slides はノート、書式設定、アニメーションなど、すべてのスライド要素を引き継ぎます。

**コメントとその作者は転送されますか？**  
コメントはスライドコンテンツの一部としてスライドとともにコピーされます。コメントの作者ラベルは、結果のプレゼンテーションのコメントオブジェクトとして保持されます。

**元のプレゼンテーションがパスワードで保護されている場合は？**  
[LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) を使用して[パスワードで開く](/slides/ja/net/password-protected-presentation/) 必要があります。ロード後、そのスライドは保護されていないターゲットファイル（または保護されたファイル）に安全にクローンできます。

**マージ操作はどの程度スレッドセーフですか？**  
[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスを[複数のスレッド](/slides/ja/net/multithreading/)から使用しないでください。推奨ルールは「1 ドキュメント - 1 スレッド」です。別々のファイルは個別のスレッドで並行処理できます。