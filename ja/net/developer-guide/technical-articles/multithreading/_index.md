---
title: Aspose.Slides のマルチスレッド処理
type: docs
weight: 310
url: /ja/net/multithreading/
keywords:
- PowerPoint
- プレゼンテーション
- マルチスレッド
- 並列処理
- スライドの変換
- スライドから画像へ
- C#
- .NET
- Aspose.Slides for .NET
---

## **イントロダクション**

プレゼンテーションでの並列作業は（解析/ロード/クローンを除き）可能で、ほとんどの場合問題なく動作しますが、ライブラリを複数のスレッドで使用すると、結果が正しくない場合がわずかにあります。

マルチスレッド環境で単一の[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)インスタンスを使用しないことを強く推奨します。予測できないエラーや検出が難しい障害が発生する可能性があるためです。

複数のスレッドで[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスをロード、保存、またはクローンすることは安全ではありません。これらの操作は**サポートされていません**。これらのタスクを実行する必要がある場合は、複数のシングルスレッドプロセスを使用して並列化し、各プロセスが独自のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーション スライドを並列で画像に変換**

PowerPoint プレゼンテーションのすべてのスライドを PNG 画像に並列で変換したいとします。`Presentation` インスタンスを複数のスレッドで使用するのは安全でないため、プレゼンテーションのスライドを別々のプレゼンテーションに分割し、各スレッドでそれぞれのプレゼンテーションを使用してスライドを画像に並列変換します。以下のコード例がその方法を示しています。
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
    // スライド i を別個のプレゼンテーションに抽出します。
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


## **FAQ**

**スレッドごとにライセンス設定を呼び出す必要がありますか？**

いいえ。スレッドが開始する前にプロセス/アプリドメインごとに一度行えば十分です。[license setup](/slides/ja/net/licensing/) が同時に呼び出される可能性がある場合（例：遅延初期化中）、その呼び出しを同期してください。license setup メソッド自体はスレッドセーフではありません。

**スレッド間で `Presentation` または `Slide` オブジェクトを渡すことはできますか？**

「ライブ」なプレゼンテーションオブジェクトをスレッド間で渡すことは推奨されません。スレッドごとに独立したインスタンスを使用するか、各スレッド用に別々のプレゼンテーション/スライドコンテナを事前に作成してください。このアプローチは、単一のプレゼンテーションインスタンスをスレッド間で共有しないという一般的な推奨に沿ったものです。

**各スレッドが独自の `Presentation` インスタンスを持つ場合、PDF、HTML、画像など異なるフォーマットへのエクスポートを並列化しても安全ですか？**

はい。独立したインスタンスと個別の出力パスを使用すれば、通常これらのタスクは正しく並列化できます。プレゼンテーションオブジェクトや I/O ストリームを共有しないようにしてください。

**マルチスレッド環境でグローバルフォント設定（フォルダー、置換など）をどう扱うべきですか？**

スレッドを開始する前にすべてのグローバルフォント設定を初期化し、並列処理中に変更しないでください。これにより、共有フォントリソースへのアクセス競合が防止されます。