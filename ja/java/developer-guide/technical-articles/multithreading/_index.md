---
title: Java 用 Aspose.Slides のマルチスレッド化
linktitle: マルチスレッド
type: docs
weight: 310
url: /ja/java/multithreading/
keywords:
- マルチスレッディング
- 複数スレッド
- 並列処理
- スライド変換
- スライドから画像へ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のマルチスレッド化は PowerPoint と OpenDocument の処理を高速化します。効率的なプレゼンテーションワークフローのベストプラクティスをご紹介します。"
---

## **イントロダクション**

プレゼンテーションの並列処理は（解析/ロード/クローンを除き）可能で、ほとんどの場合問題なく動作しますが、ライブラリを複数のスレッドで使用すると結果が正しくないことが稀にあります。

マルチスレッド環境で単一の[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)インスタンスを使用しないことを強く推奨します。予測できないエラーや検出が難しい障害が発生する可能性があります。

複数のスレッドで[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスをロード、保存、またはクローンすることは安全ではありません。このような操作はサポートされていません。該当タスクが必要な場合は、複数の単一スレッドプロセスに分割して並列実行し、各プロセスが独自のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーションスライドを並列で画像に変換する**

PowerPointプレゼンテーションのすべてのスライドをPNG画像に並列変換したいとします。複数スレッドで単一の`Presentation`インスタンスを使用するのは安全でないため、スライドを別々のプレゼンテーションに分割し、各スレッドで個別のプレゼンテーションを使用して画像に変換します。以下のコード例に手順が示されています。
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
    // スライド i を別のプレゼンテーションに抽出します。
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // スライドを別のタスクで画像に変換します。
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

// すべてのタスクが完了するまで待機します。
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```


## **よくある質問**

**すべてのスレッドでライセンス設定を呼び出す必要がありますか？**

No. スレッド開始前にプロセス/アプリドメインごとに一度実行すれば十分です。[ライセンス設定](/slides/ja/java/licensing/)が同時に呼び出される可能性がある場合（例：遅延初期化時）、その呼び出しを同期してください。ライセンス設定メソッド自体はスレッドセーフではありません。

**`Presentation`または`Slide`オブジェクトをスレッド間で渡すことはできますか？**

「ライブ」なプレゼンテーションオブジェクトをスレッド間で渡すことは推奨されません。スレッドごとに独立したインスタンスを使用するか、各スレッド用に事前に別々のプレゼンテーション/スライドコンテナを作成してください。この方法は、単一のプレゼンテーションインスタンスをスレッド間で共有しないという一般的な推奨事項に沿っています。

**各スレッドが独自の`Presentation`インスタンスを持つ場合、PDF、HTML、画像など異なるフォーマットへのエクスポートを並列化しても安全ですか？**

はい。独立したインスタンスと個別の出力パスを使用すれば、通常は正しく並列化できます。プレゼンテーションオブジェクトやI/Oストリームを共有しないようにしてください。

**マルチスレッド環境でのグローバルフォント設定（フォルダー、代替設定）はどう扱うべきですか？**

スレッド開始前にすべてのグローバル[フォント設定](/slides/ja/java/powerpoint-fonts/)を初期化し、並列処理中に変更しないでください。これにより、共有フォントリソースへの競合が防止されます。