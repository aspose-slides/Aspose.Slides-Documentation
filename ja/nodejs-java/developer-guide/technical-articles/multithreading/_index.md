---
title: Aspose.Slides におけるマルチスレッド
type: docs
weight: 310
url: /ja/nodejs-java/multithreading/
keywords:
- PowerPoint
- プレゼンテーション
- マルチスレッド
- 並列処理
- スライドの変換
- スライドから画像へ
- JavaScript
- Java を介した Node.js 用 Aspose.Slides
---

## **はじめに**

プレゼンテーションでの並列処理は（パース/ロード/クローンを除いて）可能であり、ほとんどの場合うまくいきますが、ライブラリを複数スレッドで使用すると正しくない結果が得られる可能性があります。

マルチスレッド環境で単一の[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)インスタンスを使用しないことを**強く**推奨します。これは予期しないエラーや検出しにくい失敗を引き起こす可能性があるためです。

複数スレッドで[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)クラスのインスタンスをロード、保存、またはクローンすることは**安全ではありません**。このような操作はサポートされていません。これらのタスクを実行する必要がある場合は、複数のシングルスレッドプロセスを使用して操作を並列化し、各プロセスが独自のプレゼンテーションインスタンスを使用する必要があります。

## **プレゼンテーションのスライドを並列で画像に変換**

PowerPoint プレゼンテーションのすべてのスライドを PNG 画像に並列で変換したいとします。単一の `Presentation` インスタンスを複数スレッドで使用するのは安全でないため、プレゼンテーションのスライドを別々のプレゼンテーションに分割し、各スレッドでそれぞれのプレゼンテーションを使用してスライドを画像に変換します。以下のコード例はその方法を示しています。
```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // スライド i を別のプレゼンテーションに抽出します。
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // すべてのタスクが完了するまで待ちます。
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```


## **FAQ**

**すべてのスレッドでライセンス設定を呼び出す必要がありますか？**

いいえ。スレッド開始前にプロセス/アプリドメインごとに一度実行すれば十分です。もし[license setup](/slides/ja/nodejs-java/licensing/)が同時に呼び出される可能性がある場合（例: 遅延初期化時）、その呼び出しを同期してください。ライセンス設定メソッド自体はスレッドセーフではありません。

**`Presentation` または `Slide` オブジェクトをスレッド間で渡すことはできますか？**

「ライブ」なプレゼンテーションオブジェクトをスレッド間で渡すことは推奨されません。スレッドごとに独立したインスタンスを使用するか、各スレッド用に事前に別々のプレゼンテーション/スライドコンテナを作成してください。このアプローチは、単一のプレゼンテーションインスタンスをスレッド間で共有しないという一般的な推奨事項に沿っています。

**各スレッドが独自の `Presentation` インスタンスを持つ場合、PDF、HTML、画像など異なる形式へのエクスポートを並列化しても安全ですか？**

はい。独立したインスタンスと個別の出力パスを使用すれば、通常は正しく並列化できます。プレゼンテーションオブジェクトや I/O ストリームを共有しないようにしてください。

**マルチスレッド環境でのグローバルフォント設定（フォルダー、置換など）はどう扱うべきですか？**

スレッドを開始する前にすべてのグローバルフォント設定を初期化し、並列処理中に変更しないでください。これにより、共有フォントリソースへのアクセス時の競合が防止されます。