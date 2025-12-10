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
- 画像を追加
- 画像を追加
- C++
- Aspose.Slides
description: "スライドの画像処理を、非推奨のイメージング API を C++ モダン API に置き換えることで、PowerPoint と OpenDocument の自動化をシームレスに実現します。"
---

## **概要**

現在、Aspose.Slides for C++ ライブラリは、System::Drawing の以下のクラスに対する依存関係を公開 API に持っています。
- [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/)

バージョン 24.4 以降、この公開 API は非推奨と宣言されています。

System::Drawing への依存を公開 API から取り除くために、いわゆる「Modern API」を追加しました。System::Drawing::Image および System::Drawing::Bitmap を使用するメソッドは非推奨とされ、Modern API の対応メソッドに置き換えられます。System::Graphics を使用するメソッドも非推奨とされ、公開 API からのサポートは削除されます。

System::Drawing への依存を持つ非推奨の公開 API の削除は、リリース 24.8 で行われます。

## **Modern API**

公開 API に次のクラスと列挙型を追加しました。

- Aspose::Slides::IImage - ラスター画像またはベクタ画像を表します。
- Aspose::Slides::ImageFormat - 画像のファイル形式を表します。
- Aspose::Slides::Images - IImage インターフェイスのインスタンス化と操作用メソッドを提供します。

新しい API の典型的な使用シナリオは以下のようになります:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// ディスク上のファイルから IImage の破棄可能インスタンスを作成します。  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// IImage のインスタンスをプレゼンテーションの画像コレクションに追加して PowerPoint 画像を作成します。
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// スライド #1 に画像シェイプを追加します
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// スライド #1 を表す IImage のインスタンスを取得します。
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// 画像をディスクに保存します。
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```


## **古いコードを Modern API に置き換える**

移行を容易にするために、新しい IImage のインターフェイスは Image および Bitmap クラスの個別シグネチャを再現しています。基本的には、System::Drawing を使用した古いメソッド呼び出しを新しいものに置き換えるだけです。

### **スライドサムネイルの取得**

非推奨 API を使用したコード:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```


Modern API:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```


### **シェイプサムネイルの取得**

非推奨 API を使用したコード:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```


Modern API:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```


### **プレゼンテーションサムネイルの取得**

非推奨 API を使用したコード:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```


Modern API:
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

非推奨 API を使用したコード:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```


Modern API:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```


## **削除されるメソッド/プロパティと Modern API での置き換え**

### **Presentation クラス**
|メソッド シグネチャ|置換 メソッド シグネチャ|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|完全に削除されます|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|完全に削除されます|

### **Slide クラス**
|メソッド シグネチャ|置換 メソッド シグネチャ|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|完全に削除されます|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|完全に削除されます|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|完全に削除されます|

### **Shape クラス**
|メソッド シグネチャ|置換 メソッド シグネチャ|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection クラス**
|メソッド シグネチャ|置換 メソッド シグネチャ|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage クラス**
|メソッド シグネチャ|置換 メソッド シグネチャ|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat クラス**
|メソッド シグネチャ|置換 メソッド シグネチャ|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData クラス**
|メソッド シグネチャ|置換 メソッド シグネチャ|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **System::Drawing::Graphics の API サポートは廃止されます**

[System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/) を使用したメソッドは非推奨とされ、公開 API からのサポートは削除されます。

この API の該当部分は次のとおり削除されます:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**System::Drawing::Graphics が削除された理由は何ですか？**

`Graphics` のサポートは、レンダリングと画像の取り扱いを統一し、プラットフォーム固有の依存関係を排除し、[IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) を使用したクロスプラットフォーム アプローチに切り替えるために、公開 API から削除されます。`Graphics` に対するすべてのレンダリングメソッドは削除されます。

**IImage は Image/Bitmap と比べて実際にどんな利点がありますか？**

[IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) はラスタ画像とベクタ画像の両方を統一的に扱い、[ImageFormat](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) を介したさまざまな形式への保存を簡素化し、`System::Drawing` への依存を減らし、環境間でのコード移植性を向上させます。

**Modern API はサムネイル生成のパフォーマンスに影響しますか？**

`GetThumbnail` から `GetImage` への切り替えはシナリオを悪化させません。新しいメソッドはオプションやサイズ指定で画像を生成する同等の機能を提供し、レンダリングオプションのサポートも保持しています。具体的な性能の向上または低下はシナリオ次第ですが、機能的には同等です。