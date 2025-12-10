---
title: Java でプレゼンテーションビューアを作成する
linktitle: プレゼンテーションビューア
type: docs
weight: 50
url: /ja/java/presentation-viewer/
keywords:
- プレゼンテーションを表示する
- プレゼンテーションビューア
- プレゼンテーションビューアを作成する
- PPT を表示する
- PPTX を表示する
- ODP を表示する
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java でカスタム プレゼンテーション ビューアを作成します。Microsoft PowerPoint を使用せずに PowerPoint および OpenDocument ファイルを簡単に表示できます。"
---

Aspose.Slides for Java はスライド付きのプレゼンテーション ファイルを作成するために使用されます。これらのスライドは、たとえば Microsoft PowerPoint でプレゼンテーションを開くことで表示できます。ただし、開発者が好みの画像ビューアでスライドを画像として表示したり、独自のプレゼンテーション ビューアを作成したりする必要がある場合があります。そのような場合、Aspose.Slides を使用すると、個々のスライドを画像としてエクスポートできます。本記事ではその方法を説明します。

## **スライドから SVG 画像を生成する**

Aspose.Slides を使用してプレゼンテーション スライドから SVG 画像を生成するには、以下の手順に従ってください。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラス。
2. インデックスでスライド参照を取得します。
3. ファイル ストリームを開きます。
4. スライドを SVG 画像としてファイル ストリームに保存します。
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **カスタム シェイプ ID を使用して SVG を生成する**

Aspose.Slides を使用すると、カスタム シェイプ ID を持つスライドから [SVG](https://docs.fileformat.com/page-description-language/svg/) を生成できます。そのためには、[ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/) の `setId` メソッドを使用します。`CustomSvgShapeFormattingController` を使用してシェイプ ID を設定できます。
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```


## **スライドサムネイル画像を作成する**

Aspose.Slides はスライドのサムネイル画像の生成を支援します。Aspose.Slides を使用してスライドのサムネイルを生成するには、以下の手順に従ってください。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラス。
2. インデックスでスライド参照を取得します。
3. 定義されたスケールで参照されたスライドのサムネイル画像を取得します。
4. サムネイル画像を任意の画像形式で保存します。
```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **ユーザー定義のサイズでスライドサムネイルを作成する**

ユーザー定義の寸法でスライドサムネイル画像を作成するには、以下の手順に従ってください。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラス。
2. インデックスでスライド参照を取得します。
3. 定義された寸法で参照されたスライドのサムネイル画像を取得します。
4. サムネイル画像を任意の画像形式で保存します。
```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **スピーカーノート付きスライドサムネイルを作成する**

Aspose.Slides を使用してスピーカーノート付きスライドのサムネイルを生成するには、以下の手順に従ってください。

1. [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) クラスのインスタンスを作成します。
2. `RenderingOptions.setSlidesLayoutOptions` メソッドを使用してスピーカーノートの位置を設定します。
3. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラス。
4. インデックスでスライド参照を取得します。
5. レンダリングオプションを使用して参照されたスライドのサムネイル画像を取得します。
6. サムネイル画像を任意の画像形式で保存します。
```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **ライブ例**

Aspose.Slides API で実装できることを確認するために、[**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) 無料アプリを試すことができます：

![オンライン PowerPoint ビューア](online-PowerPoint-viewer.png)

## **よくある質問**

**プレゼンテーション ビューアを Web アプリケーションに埋め込むことはできますか？**

はい。サーバー側で Aspose.Slides を使用してスライドを画像または HTML にレンダリングし、ブラウザーで表示できます。ナビゲーションやズーム機能は JavaScript で実装してインタラクティブな体験を提供できます。

**カスタム ビューア内でスライドを表示する最適な方法は何ですか？**

推奨されるアプローチは、各スライドを画像 (PNG または SVG など) としてレンダリングするか、Aspose.Slides を使用して HTML に変換し、デスクトップの場合はピクチャーボックス、Web の場合は HTML コンテナに出力を表示することです。

**多数のスライドを含む大規模なプレゼンテーションをどのように扱いますか？**

大規模なデッキの場合、スライドの遅延読み込みまたはオンデマンドレンダリングを検討してください。つまり、ユーザーがスライドに移動したときにのみそのコンテンツを生成し、メモリ使用量とロード時間を削減します。