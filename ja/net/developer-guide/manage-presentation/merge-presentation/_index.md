---
title: .NET でプレゼンテーションを効率的にマージする
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
description: "Aspose.Slides for .NET を使用して、PowerPoint (PPT、PPTX) と OpenDocument (ODP) のプレゼンテーションを手軽にマージし、ワークフローを簡素化します。"
---
## **概要**

Aspose.Slides を使用すると、スライドをクローンして 1 つのプレゼンテーションから別のプレゼンテーションへマージできます。本記事では、プレゼンテーション全体または選択したスライドのマージ方法、マージ時にスライドマスターまたは特定のレイアウトを使用する方法、サイズが異なるスライドの取り扱い、マージしたスライドをセクションに追加する方法を説明します。また、マージされたコンテンツに関連する実用的な注意点（スピーカーノート、コメント、パスワード保護されたソースファイル、スレッドの使用）についても解説します。

## **プレゼンテーションのマージを最適化する**

[Aspose.Slides for .NET](https://products.aspose.com/slides/ja/net/) を使用すれば、スタイル、レイアウト、すべての要素を保持しながら PowerPoint プレゼンテーションをシームレスに結合できます。他のツールとは異なり、Aspose.Slides は品質やデータを損なうことなくプレゼンテーションをブレンドします。プレゼンテーション全体、特定のスライド、さらに異なるファイル形式（PPT から PPTX など）もマージできます。

### **マージ機能**

- **フルプレゼンテーション マージ**：すべてのスライドを 1 つのファイルにまとめます。
- **特定スライド マージ**：選択したスライドだけを組み合わせます。
- **クロスフォーマット マージ**：形式が異なるプレゼンテーションを統合し、完全性を保ちます。

{{% alert title="Tip" color="info" %}}  
PowerPoint プレゼンテーションを **無料のオンライン ツール** で手軽に **マージ** したいですか？[**Aspose PowerPoint Merger**](https://products.aspose.app/slides/ja/merger) をお試しください。  
- **PowerPoint ファイルを簡単にマージ**：複数の **PPT、PPTX、ODP** プレゼンテーションを 1 つのファイルに統合します。  
- **異なる形式に対応**：**PPT から PPTX**、**PPTX から ODP** などをマージできます。  
- **インストール不要**：ブラウザ上で直接実行、迅速かつ安全です。  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/ja/merger)  

**Aspose の無料オンライン ツール** で今すぐ PowerPoint ファイルのマージを開始しましょう！  
{{% /alert %}}

## **プレゼンテーション マージ**

[プレゼンテーションを別のプレゼンテーションにマージ](https://products.aspose.com/slides/ja/net/merger/ppt/) すると、スライドが 1 つのプレゼンテーションに統合され、単一ファイルとして取得できます。

{{% alert title="Info" color="info" %}}  
ほとんどのプレゼンテーション ソフトウェア（PowerPoint や OpenOffice）には、プレゼンテーションをこのように結合する機能がありません。  

[Aspose.Slides for .NET](https://products.aspose.com/slides/ja/net/) は、さまざまな方法でプレゼンテーションをマージできるようにします。形状、スタイル、テキスト、書式設定、コメント、アニメーションなどすべてを失うことなくマージできます。  

**関連情報**  

[Clone Slides](https://docs.aspose.com/slides/ja/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)  
{{% /alert %}}

### **マージ対象**

Aspose.Slides を使用すると、次のものをマージできます  

* **プレゼンテーション全体**：すべてのスライドが 1 つのプレゼンテーションにまとめられます  
* **特定のスライド**：選択したスライドが 1 つのプレゼンテーションにまとめられます  
* **同一形式または異なる形式**（PPT から PPT、PPTX から PPTX、または PPT から PPTX、PPTX から ODP など）を相互にマージできます  

{{% alert title="Note" color="warning" %}}  
プレゼンテーションに加えて、Aspose.Slides は次のファイルもマージできます：  

* **画像**：例として [JPG to JPG](https://products.aspose.com/slides/ja/net/merger/jpg-to-jpg/) や [PNG to PNG](https://products.aspose.com/slides/ja/net/merger/png-to-png/)  
* **ドキュメント**：例として [PDF to PDF](https://products.aspose.com/slides/ja/net/merger/pdf-to-pdf/) や [HTML to HTML](https://products.aspose.com/slides/ja/net/merger/html-to-html/)  
* **異種ファイル**：例として [image to PDF](https://products.aspose.com/slides/ja/net/merger/image-to-pdf/) や [JPG to PDF](https://products.aspose.com/slides/ja/net/merger/jpg-to-pdf/) 、[TIFF to PDF](https://products.aspose.com/slides/ja/net/merger/tiff-to-pdf/)  

{{% /alert %}}

### **マージ オプション**

次のいずれかを決定するオプションを適用できます  

* 出力プレゼンテーションの各スライドが固有のスタイルを保持するか  
* 出力プレゼンテーションのすべてのスライドに特定のスタイルを適用するか  

プレゼンテーションをマージするには、Aspose.Slides の [AddClone](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/methods/addclone) メソッド（[ISlideCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection) インターフェイス）を使用します。`AddClone` メソッドには複数の実装があり、マージ プロセスのパラメータを定義します。すべての Presentation オブジェクトは [Slides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/properties/slides) コレクションを持つため、スライドをマージしたいプレゼンテーションから `AddClone` メソッドを呼び出せます。

`AddClone` メソッドは、ソーススライドのクローンである `ISlide` オブジェクトを返します。出力プレゼンテーションのスライドはソースのスライドのコピーに過ぎません。したがって、結果のスライドに対して（スタイルや書式設定、レイアウトの適用など）変更を加えても、ソース プレゼンテーションには影響しません。

## **プレゼンテーションのマージ**  

Aspose.Slides は、スライドのレイアウトとスタイルを保持したままスライドを結合できる [**AddClone (ISlide)**](https://reference.aspose.com/slides/ja/net/aspose.slides/islidecollection/methods/addclone) メソッドを提供します（デフォルト パラメータ）。

この C# コードはプレゼンテーションのマージ方法を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides は、[**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/ja/net/aspose.slides.islidecollection/addclone/methods/2) メソッドを提供し、スライド マスター テンプレートを適用しながらスライドを結合できます。これにより、必要に応じて出力プレゼンテーションのスライドのスタイルを変更できます。

この C# コードは上記操作をデモします：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
スライド マスターのレイアウトは自動的に決定されます。適切なレイアウトが判定できない場合、`AddClone` メソッドの `allowCloneMissingLayout` ブール パラメータが true に設定されていれば、ソーススライドのレイアウトが使用されます。そうでなければ、[PptxEditException](https://reference.aspose.com/slides/ja/net/aspose.slides/pptxeditexception) がスローされます。  
{{% /alert %}}

出力プレゼンテーションのスライドに別のレイアウトを適用したい場合は、マージ時に [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ja/net/aspose.slides.islidecollection/addclone/methods/1) メソッドを使用してください。

## **プレゼンテーションから特定のスライドをマージ**  

複数のプレゼンテーションから特定のスライドをマージすると、カスタム スライド デッキの作成に便利です。Aspose.Slides for .NET は、必要なスライドだけを選択してインポートでき、元のスライドの書式、レイアウト、デザインを保持します。

以下の C# コードは新しいプレゼンテーションを作成し、別の 2 つのプレゼンテーションからタイトル スライドを追加してファイルに保存します：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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
```cs
using Aspose.Slides;

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

この C# コードは、プレゼンテーションからスライドを結合し、希望のスライド レイアウトを適用して 1 つの出力プレゼンテーションを作成する方法を示します：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
サイズが異なるスライドをマージしてもエラーは発生しませんが、マージされたスライドはターゲット プレゼンテーションのスライド サイズを採用し、シェイプは元の位置とサイズのままなので、コンテンツがずれたりスライドの境界外に出たりする可能性があります。  
{{% /alert %}}

サイズが異なる 2 つのプレゼンテーションをマージし、コンテンツを正しく配置するには、片方のプレゼンテーションのサイズをもう一方に合わせてリサイズします。

このサンプル コードは上記操作を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

この C# コードは、特定のスライドをプレゼンテーションのセクションにマージする方法を示します：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert title="Tip" color="info" %}}  
Aspose は [FREE Collage web app](https://products.aspose.app/slides/ja/collage) を提供しています。このオンライン サービスを使用して、[JPG to JPG](https://products.aspose.app/slides/ja/collage/jpg) や PNG から PNG への画像マージ、[photo grids](https://products.aspose.app/slides/ja/collage/photo-grid) の作成などが可能です。  
{{% /alert %}}

## **FAQ**

### マージ時にスピーカーノートは保持されますか？

はい。スライドをクローンすると、ノート、書式設定、アニメーションを含むすべてのスライド要素が Aspose.Slides によって引き継がれます。

### コメントとその作成者は転送されますか？

コメントはスライド コンテンツの一部としてコピーされ、コメント作成者のラベルは結果のプレゼンテーション内のコメント オブジェクトとして保持されます。

### ソース プレゼンテーションがパスワードで保護されている場合は？

[LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) を使用してパスワードで [開く](/slides/ja/net/password-protected-presentation/) 必要があります。ロード後、そのスライドは保護されていないターゲット ファイル（または保護されたファイル）へ安全にクローンできます。

### マージ操作はスレッド安全ですか？

同一の [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを [複数のスレッド](/slides/ja/net/multithreading/) から使用しないでください。推奨ルールは「1 ドキュメント＝1 スレッド」です。異なるファイルは別スレッドで並行処理できます。