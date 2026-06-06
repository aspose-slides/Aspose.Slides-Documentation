---
title: モダン API で画像処理を強化
linktitle: モダン API
type: docs
weight: 280
url: /ja/cpp/modern-api/
keywords:
- System.Drawing
- モダン API
- 描画
- スライドサムネイル
- スライドから画像へ
- シェイプサムネイル
- シェイプから画像へ
- プレゼンテーションサムネイル
- プレゼンテーションから画像へ
- 画像の追加
- ピクチャの追加
- C++
- Aspose.Slides
description: "廃止予定の画像 API を C++ モダン API に置き換えて、スライド画像処理を最新化し、PowerPoint および OpenDocument の自動化をシームレスに実現します。"
---
## **導入**

現在、Aspose.Slides for C++ ライブラリは、パブリック API において System::Drawing の次のクラスに依存しています。
- [System::Drawing::Graphics](https://reference.aspose.com/slides/ja/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/ja/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/ja/cpp/system.drawing/bitmap/)

バージョン 24.4 以降、このパブリック API は非推奨として宣言されています。

System::Drawing への依存を排除するために、いわゆる「モダン API」を追加しました。[System::Drawing::Image](https://reference.aspose.com/slides/ja/cpp/system.drawing/image/) および [System::Drawing::Bitmap](https://reference.aspose.com/slides/ja/cpp/system.drawing/bitmap/) を使用するメソッドは非推奨となり、モダン API の対応メソッドに置き換える必要があります。[System::Drawing::Graphics](https://reference.aspose.com/slides/ja/cpp/system.drawing/graphics/) を使用するメソッドも非推奨で、直接的なモダン API の置き換えはありません。

現在のバージョンでは、System::Drawing 型に依存するパブリック API をレガシー／非推奨として扱い、新規コードや既存の画像処理ワークフローの移行時にはモダン API を使用してください。

## **モダン API**

パブリック API に以下のクラスと列挙型を追加しました。

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) - ラスタ画像またはベクタ画像を表します。
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imageformat/) - 画像のファイル形式を表します。
- [Aspose::Slides::Images](https://reference.aspose.com/slides/ja/cpp/aspose.slides/images/) - [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) インターフェイスを生成・操作するメソッドを提供します。

`GetImage` を使用して単一のスライドまたはシェイプをレンダリングします。`GetImages` を使用して複数のプレゼンテーションスライドをレンダリングします。[Images](https://reference.aspose.com/slides/ja/cpp/aspose.slides/images/) メソッドで画像を読み込み、`AddImage` で [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) をプレゼンテーションに追加し、`ReplaceImage` で既存のプレゼンテーション画像を更新します。

新しい API の典型的な使用シナリオは次のようになります。

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// ディスク上のファイルから IImage の破棄可能なインスタンスを作成します。  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// プレゼンテーションの画像コレクションに IImage のインスタンスを追加して PowerPoint 画像を作成します。
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// スライド #1 に画像シェイプを追加します
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// スライド #1 を表す IImage のインスタンスを取得します。
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// 画像をディスクに保存します。
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **古いコードをモダン API に置き換える**

移行を容易にするために、新しい [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) のインターフェイスは、[System::Drawing::Image](https://reference.aspose.com/slides/ja/cpp/system.drawing/image/) と [System::Drawing::Bitmap](https://reference.aspose.com/slides/ja/cpp/system.drawing/bitmap/) の個別シグネチャをそのまま繰り返しています。基本的には、System::Drawing を使用した古いメソッド呼び出しを新しいものに置き換えるだけです。

### **スライドサムネイルの取得**

レガシー／非推奨 API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

モダン API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **シェイプサムネイルの取得**

レガシー／非推奨 API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

モダン API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **プレゼンテーションサムネイルの取得**

レガシー／非推奨 API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

モダン API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **プレゼンテーションへの画像追加**

レガシー／非推奨 API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

モダン API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **非推奨メソッド／プロパティとモダン API における置換**

### **Presentation クラス**
| メソッド署名 | 置換メソッド署名 |
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Slide クラス**
| メソッド署名 | 置換メソッド署名 |
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Shape クラス**
| メソッド署名 | 置換メソッド署名 |
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection クラス**
| メソッド署名 | 置換メソッド署名 |
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage クラス**
| メソッド署名 | 置換メソッド署名 |
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat クラス**
| メソッド署名 | 置換メソッド署名 |
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData クラス**
| メソッド署名 | 置換メソッド署名 |
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **System::Drawing::Graphics の API サポート**

[System::Drawing::Graphics](https://reference.aspose.com/slides/ja/cpp/system.drawing/graphics/) を使用するメソッドは非推奨で、直接的なモダン API の置き換えはありません。

代わりにモダン API の画像レンダリングメソッドを使用してください。
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**なぜ [System::Drawing::Graphics](https://reference.aspose.com/slides/ja/cpp/system.drawing/graphics/) が削除されたのですか？**

[System::Drawing::Graphics](https://reference.aspose.com/slides/ja/cpp/system.drawing/graphics/) のサポートは、レンダリングと画像処理を統一し、プラットフォーム固有の依存関係を排除して、[IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) によるクロスプラットフォーム アプローチに切り替えるために非推奨となりました。`GetImage` または `GetImages` を使用し、[System::Drawing::Graphics](https://reference.aspose.com/slides/ja/cpp/system.drawing/graphics/) への描画は行わないでください。

**[IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) は [System::Drawing::Image](https://reference.aspose.com/slides/ja/cpp/system.drawing/image/) / [System::Drawing::Bitmap](https://reference.aspose.com/slides/ja/cpp/system.drawing/bitmap/) と比べて実用的なメリットがありますか？**

[IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) はラスタ画像とベクタ画像の両方を統一的に扱い、[ImageFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imageformat/) を介したさまざまな形式への保存を容易にし、`System::Drawing` への依存を減らすことで、環境間の移植性が向上します。

**モダン API に切り替えるとサムネイル生成のパフォーマンスに影響しますか？**

`GetThumbnail` から `GetImage` への切り替えで性能が低下することはありません。新しいメソッドはオプションやサイズ指定を伴う画像生成機能を同等に提供し、シナリオによっては最適化が期待でき、機能的には置換は等価です。