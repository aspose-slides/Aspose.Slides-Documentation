---
title: Androidでプレゼンテーションビューアを作成する
linktitle: プレゼンテーションビューア
type: docs
weight: 50
url: /ja/androidjava/presentation-viewer/
keywords:
- プレゼンテーションを表示
- プレゼンテーションビューア
- プレゼンテーションビューアを作成
- PPTを表示
- PPTXを表示
- ODPを表示
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android用のAspose.Slidesを使用してJavaでカスタムプレゼンテーションビューアを作成します。Microsoft PowerPointなしでPowerPointおよびOpenDocumentファイルを簡単に表示できます。"
---

Aspose.Slides for Android via Java は、スライド付きのプレゼンテーション ファイルを作成するために使用されます。これらのスライドは、たとえば Microsoft PowerPoint でプレゼンテーションを開くことで表示できます。ただし、開発者がスライドを好みの画像ビューアで画像として表示したり、独自のプレゼンテーション ビューアを作成したりする必要がある場合があります。そのような場合、Aspose.Slides を使用すると、個々のスライドを画像としてエクスポートできます。本記事ではその手順を説明します。

## **スライドから SVG 画像を生成する**

Aspose.Slides を使用してプレゼンテーション スライドから SVG 画像を生成するには、以下の手順に従ってください。

1. [プレゼンテーション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. ファイル ストリームを開きます。
1. スライドを SVG 画像としてファイル ストリームに保存します。
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **カスタムシェイプ ID で SVG を生成する**

Aspose.Slides を使用して、カスタム シェイプ ID を持つスライドから [SVG](https://docs.fileformat.com/page-description-language/svg/) を生成できます。このためには、[ISvgShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/) の `setId` メソッドを使用します。`CustomSvgShapeFormattingController` を使用してシェイプ ID を設定できます。
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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```


## **スライドのサムネイル画像を作成する**

Aspose.Slides はスライドのサムネイル画像の生成を支援します。Aspose.Slides を使用してスライドのサムネイルを生成するには、以下の手順に従ってください。

1. [プレゼンテーション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. 参照スライドのサムネイル画像を定義されたスケールで取得します。
1. サムネイル画像を任意の画像形式で保存します。
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


## **ユーザー定義サイズでスライドのサムネイルを作成する**

ユーザー定義サイズでスライドのサムネイル画像を作成するには、以下の手順に従ってください。

1. [プレゼンテーション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. 定義された寸法で参照スライドのサムネイル画像を取得します。
1. サムネイル画像を任意の画像形式で保存します。
```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **スピーカーノート付きスライドのサムネイルを作成する**

Aspose.Slides を使用してスピーカーノート付きスライドのサムネイルを生成するには、以下の手順に従ってください。

1. [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) クラスのインスタンスを作成します。
1. `RenderingOptions.setSlidesLayoutOptions` メソッドを使用してスピーカーノートの位置を設定します。
1. [プレゼンテーション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. レンダリング オプションを使用して参照スライドのサムネイル画像を取得します。
1. サムネイル画像を任意の画像形式で保存します。
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

Aspose.Slides APIで実装できることを確認するために、無料アプリの [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) を試すことができます：

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Web アプリケーションにプレゼンテーション ビューアを埋め込むことはできますか？**

はい。サーバー側で Aspose.Slides を使用してスライドを画像または HTML としてレンダリングし、ブラウザーに表示できます。ナビゲーションやズーム機能は JavaScript で実装でき、インタラクティブな体験を提供します。

**カスタムビューア内でスライドを表示する最適な方法は何ですか？**

推奨されるアプローチは、各スライドを画像（例: PNG または SVG）としてレンダリングするか、Aspose.Slides を使用して HTML に変換し、デスクトップの場合はピクチャーボックス、Web の場合は HTML コンテナ内に表示することです。

**多数のスライドがある大規模なプレゼンテーションをどのように扱いますか？**

大規模なデッキの場合、スライドの遅延ロードまたはオンデマンドレンダリングを検討してください。これは、ユーザーがスライドに移動したときにのみそのコンテンツを生成し、メモリ使用量と読み込み時間を削減することを意味します。