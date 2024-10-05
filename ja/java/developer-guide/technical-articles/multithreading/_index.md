---
title: Aspose.Slidesにおけるマルチスレッド
type: docs
weight: 310
url: /java/multithreading/
keywords:
- PowerPoint
- プレゼンテーション
- マルチスレッド
- 並行作業
- スライドを変換
- スライドを画像に
- Java
- Aspose.Slides for Java
---

## **はじめに**

プレゼンテーションとの並行作業は可能であり（解析/ロード/クローン処理を除く）、ほとんどの場合は問題なく処理されますが、ライブラリを複数のスレッドで使用する場合には、正しくない結果が得られる可能性がわずかにあります。

マルチスレッド環境で単一の[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)インスタンスを使用しないことを強くお勧めします。これは、予測できないエラーや簡単には検出できない失敗を引き起こす可能性があります。

複数のスレッドで[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスをロード、保存、および/またはクローンすることは**安全ではありません**。そのような操作は**サポートされていません**。そのような作業を実行する必要がある場合は、複数の単一スレッドプロセスを使用して操作を並行化する必要があり、それぞれのプロセスは独自のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーションのスライドを画像に並行して変換する**

PowerPointプレゼンテーションのすべてのスライドをPNG画像に並行して変換したいとしましょう。複数のスレッドで単一の`Presentation`インスタンスを使用するのは安全ではないため、プレゼンテーションのスライドを個別のプレゼンテーションに分割し、各プレゼンテーションを別々のスレッドで使用してスライドを画像に並行して変換します。以下のコード例は、これを行う方法を示しています。

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // スライドiを別のプレゼンテーションに抽出します。
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // 別のタスクでスライドを画像に変換します。
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// すべてのタスクが完了するのを待ちます。
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```