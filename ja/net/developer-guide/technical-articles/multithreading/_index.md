---
title: Aspose.Slidesにおけるマルチスレッディング
type: docs
weight: 310
url: /ja/net/multithreading/
keywords:
- PowerPoint
- プレゼンテーション
- マルチスレッディング
- 並列作業
- スライドの変換
- スライドを画像に
- C#
- .NET
- Aspose.Slides for .NET
---

## **はじめに**

プレゼンテーションを使った並列作業は可能であり（解析/読み込み/クローン作成を除く）、通常はうまくいくものの、ライブラリを複数のスレッドで使用する際に不正確な結果が得られる可能性があります。

マルチスレッディング環境で単一の[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)インスタンスを使用することは**推奨されません**。そうすると、検出が難しい予測不能なエラーや失敗が発生する可能性があります。

複数のスレッドで[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを読み込み、保存、またはクローンすることは**安全ではありません**。そのような操作は**サポートされていません**。そのようなタスクを実行する必要がある場合は、いくつかの単一スレッドプロセスを使用して操作を並列化する必要があります。そして、これらの各プロセスは自身のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーションスライドを並列で画像に変換する**

PowerPointプレゼンテーションのすべてのスライドをPNG画像に並列で変換したいとしましょう。複数のスレッドで単一の`Presentation`インスタンスを使用することが安全ではないため、プレゼンテーションのスライドを別々のプレゼンテーションに分割し、各プレゼンテーションを別のスレッドで使用してスライドを画像に並列で変換します。以下のコード例は、これを行う方法を示しています。

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
    // スライドiを別のプレゼンテーションに抽出します。
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // 別のタスクでスライドを画像に変換します。
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