---
title: .NET 用 Aspose.Slides におけるマルチスレッド化
linktitle: マルチスレッド化
type: docs
weight: 310
url: /ja/net/multithreading/
keywords:
- マルチスレッディング
- 複数スレッド
- 並列作業
- スライドの変換
- スライドから画像へ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のマルチスレッド化は PowerPoint と OpenDocument の処理を高速化します。効率的なプレゼンテーション ワークフローのベストプラクティスをご確認ください。"
---

## **はじめに**

プレゼンテーションの並列処理は（解析/ロード/クローン以外でも）可能で、ほとんどの場合問題なく動作しますが、複数スレッドでライブラリを使用すると、結果が正しくならない可能性がわずかにあります。

マルチスレッド環境で単一の[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)インスタンスを使用しないことを強く推奨します。予測できないエラーや検出が困難な障害が発生する可能性があります。

複数スレッドで[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスをロード、保存、またはクローンすることは安全ではありません。このような操作はサポートされていません。これらのタスクを実行する必要がある場合は、複数のシングルスレッドプロセスを使用して並列化し、各プロセスが独自のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーションスライドを並列で画像に変換**

たとえば、PowerPoint プレゼンテーションのすべてのスライドを PNG 画像に並列で変換したいとします。複数スレッドで単一の`Presentation`インスタンスを使用するのは安全でないため、プレゼンテーションのスライドを別々のプレゼンテーションに分割し、各スレッドで個別のプレゼンテーションを使用してスライドを画像に並列変換します。以下のコード例はその方法を示しています。
```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // スライド i を別のプレゼンテーションに抽出します。
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // スライドを別のタスクで画像に変換します。
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```


## **よくある質問**

**ライセンス設定を各スレッドで呼び出す必要がありますか？**

いいえ。スレッド開始前にプロセス/アプリドメインごとに一度実行すれば十分です。もし[license setup](/slides/ja/net/licensing/) が同時に呼び出される可能性がある場合（例えば遅延初期化時）、その呼び出しを同期させてください。ライセンス設定メソッド自体はスレッドセーフではありません。

**`Presentation` または `Slide` オブジェクトをスレッド間で渡すことはできますか？**

「ライブ」なプレゼンテーションオブジェクトをスレッド間で渡すことは推奨されません。スレッドごとに独立したインスタンスを使用するか、各スレッド用に別々のプレゼンテーション/スライドコンテナを事前に作成してください。この方法は、単一のプレゼンテーションインスタンスをスレッド間で共有しないという一般的な推奨に従ったものです。

**各スレッドが独自の `Presentation` インスタンスを持つ場合、PDF、HTML、画像などの異なる形式へのエクスポートを並列化しても安全ですか？**

はい。独立したインスタンスと個別の出力パスを使用すれば、このようなタスクは通常正しく並列化できます。共有のプレゼンテーションオブジェクトや共有 I/O ストリームは使用しないでください。

**マルチスレッド環境でグローバルフォント設定（フォルダー、置換など）をどう扱うべきですか？**

スレッド開始前にすべてのグローバルフォント設定を初期化し、並列作業中に変更しないでください。これにより、共有フォントリソースへのアクセス時の競合が防止されます。