---
title: C++でプレゼンテーションビューアを作成する
linktitle: プレゼンテーションビューア
type: docs
weight: 50
url: /ja/cpp/presentation-viewer/
keywords:
- プレゼンテーションを表示
- プレゼンテーションビューア
- プレゼンテーションビューアを作成
- PPT を表示
- PPTX を表示
- ODP を表示
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ でカスタム プレゼンテーションビューアを作成します。Microsoft PowerPoint がなくても、PowerPoint および OpenDocument ファイルを簡単に表示できます。"
---

Aspose.Slides for C++ はスライドを含むプレゼンテーションファイルの作成に使用されます。これらのスライドは、たとえば Microsoft PowerPoint でプレゼンテーションを開くことで表示できます。ただし、開発者が好みの画像ビューアでスライドを画像として表示したり、独自のプレゼンテーションビューアを作成したりする必要がある場合があります。そのような場合、Aspose.Slides を使用すると、個々のスライドを画像としてエクスポートできます。本記事ではその手順を説明します。

## **スライドから SVG 画像を生成する**

Aspose.Slides を使用してプレゼンテーションスライドから SVG 画像を生成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. ファイルストリームを開きます。
1. スライドを SVG 画像としてファイルストリームに保存します。
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```


## **カスタム シェイプ ID で SVG を生成する**

Aspose.Slides を使用して、カスタム シェイプ ID を持つスライドから [SVG](https://docs.fileformat.com/page-description-language/svg/) を生成できます。これを行うには、[ISvgShape](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/) の `set_Id` メソッドを使用します。`CustomSvgShapeFormattingController` を使用してシェイプ ID を設定できます。
```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```


## **スライドのサムネイル画像を作成する**

Aspose.Slides はスライドのサムネイル画像生成を支援します。Aspose.Slides を使用してスライドのサムネイルを生成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. 定義されたスケールで参照スライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。
```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **ユーザー定義サイズでスライドのサムネイルを作成する**

ユーザー定義のサイズでスライドのサムネイル画像を作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. 定義されたサイズで参照スライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。
```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **スピーカーノート付きスライドのサムネイルを作成する**

Aspose.Slides を使用してスピーカーノート付きスライドのサムネイルを生成するには、以下の手順に従ってください。

1. [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) クラスのインスタンスを作成します。
1. `RenderingOptions.set_SlidesLayoutOptions` メソッドを使用してスピーカーノートの位置を設定します。
1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスでスライド参照を取得します。
1. レンダリングオプションを使用して参照スライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。
```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **ライブ例**

[**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) 無料アプリを試して、Aspose.Slides API で実装できることをご確認ください：

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Web アプリケーションにプレゼンテーションビューアを埋め込むことはできますか？**

はい。サーバー側で Aspose.Slides を使用してスライドを画像または HTML にレンダリングし、ブラウザーに表示できます。ナビゲーションやズーム機能は JavaScript で実装でき、インタラクティブな体験を提供します。

**カスタムビューア内でスライドを表示する最適な方法は何ですか？**

推奨される方法は、Aspose.Slides を使用して各スライドを画像（例: PNG または SVG）としてレンダリングするか HTML に変換し、デスクトップの場合はピクチャーボックス、Web の場合は HTML コンテナに出力を表示することです。

**多数のスライドを含む大規模なプレゼンテーションはどのように処理すればよいですか？**

大規模なデッキの場合、スライドの遅延読み込みまたはオンデマンドレンダリングを検討してください。これは、ユーザーがスライドに移動したときにのみその内容を生成し、メモリ使用量と読み込み時間を削減することを意味します。