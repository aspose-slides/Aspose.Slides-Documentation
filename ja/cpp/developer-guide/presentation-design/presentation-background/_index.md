---
title: C++でプレゼンテーションの背景を管理する
linktitle: スライド背景
type: docs
weight: 20
url: /ja/cpp/presentation-background/
keywords:
- プレゼンテーションの背景
- スライドの背景
- 単色
- グラデーションカラー
- 画像背景
- 背景の透明度
- 背景プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument ファイルで動的な背景を設定する方法を学び、プレゼンテーションを強化するコードのヒントを提供します。"
---

## **概要**

単色、グラデーション、画像はスライドの背景として一般的に使用されます。**標準スライド**（単一のスライド）または**マスタースライド**（複数のスライドに同時に適用）に対して背景を設定できます。

![PowerPoint 背景](powerpoint-background.png)

## **標準スライドの単色背景の設定**

Aspose.Slides を使用すると、プレゼンテーション内の特定のスライドの背景を単色に設定できます（プレゼンテーションがマスタースライドを使用していても）。この変更は選択されたスライドのみに適用されます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) の [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) メソッドを使用して、単色の背景色を指定します。
5. 変更したプレゼンテーションを保存します。

以下の C++ の例は、標準スライドの背景に青色の単色を設定する方法を示しています。
```cpp
// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// スライドの背景色を青に設定します。
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// プレゼンテーションをディスクに保存します。
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **マスタースライドの単色背景の設定**

Aspose.Slides を使用すると、プレゼンテーションのマスタースライドの背景を単色に設定できます。マスタースライドはすべてのスライドの書式を制御するテンプレートとして機能するため、マスタースライドの背景に単色を選択すると、すべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. `get_Masters` を介して取得したマスタースライドの [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. マスタースライドの背景の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) の [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) メソッドを使用して、単色の背景色を指定します。
5. 変更したプレゼンテーションを保存します。

以下の C++ の例は、マスタースライドの背景にフォレストグリーンの単色を設定する方法を示しています。
```cpp
// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// マスタースライドの背景色をフォレストグリーンに設定します。
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// プレゼンテーションをディスクに保存します。
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **スライドのグラデーション背景の設定**

グラデーションは、色が徐々に変化することで作られるグラフィック効果です。スライドの背景として使用すると、プレゼンテーションがより芸術的でプロフェッショナルに見えます。Aspose.Slides を使用すると、スライドの背景にグラデーションカラーを設定できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Gradient` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) の [get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_gradientformat/) メソッドを使用して、希望するグラデーション設定を構成します。
5. 変更したプレゼンテーションを保存します。

以下の C++ の例は、スライドの背景にグラデーションカラーを設定する方法を示しています。
```cpp
// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 背景にグラデーション効果を適用します。
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// プレゼンテーションをディスクに保存します。
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **スライド背景に画像を設定する**

単色およびグラデーションの塗りつぶしに加えて、Aspose.Slides を使用すると画像をスライドの背景として使用できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を `Picture` に設定します。
4. スライド背景として使用したい画像を読み込みます。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) の [get_PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_picturefillformat/) メソッドを使用して、画像を背景として割り当てます。
7. 変更したプレゼンテーションを保存します。

以下の C++ の例は、スライドの背景に画像を設定する方法を示しています。
```cpp
// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 背景画像のプロパティを設定します。
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// 画像を読み込みます。
auto image = Images::FromFile(u"Tulips.jpg");
// 画像をプレゼンテーションの画像コレクションに追加します。
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// プレゼンテーションをディスクに保存します。
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


以下のコードサンプルは、背景塗りつぶしタイプをタイル画像に設定し、タイルのプロパティを変更する方法を示しています。
```cpp
auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert color="primary" %}}
詳しく読む: [**テクスチャとしてタイル画像**](/slides/ja/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **背景画像の透明度の変更**

スライドの背景画像の透明度を調整して、スライドのコンテンツを際立たせたい場合があります。以下の C++ コードは、スライド背景画像の透明度を変更する方法を示しています。
```cpp
auto transparencyValue = 30; // 例として。

// Get the collection of picture transform operations.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Find an existing fixed-percentage transparency effect.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```


## **スライド背景値の取得**

Aspose.Slides は、スライドの有効な背景値を取得するための [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/) インターフェイスを提供します。このインターフェイスは、有効な [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) と [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) を公開します。

[BaseSlide](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/) クラスの `get_Background` メソッドを使用すると、スライドの有効な背景を取得できます。

以下の C++ の例は、スライドの有効な背景値を取得する方法を示しています。
```cpp
// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// マスタ、レイアウト、テーマを考慮した有効な背景を取得します。
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```


## **FAQ**

**カスタム背景をリセットしてテーマ/レイアウトの背景を復元できますか？**

はい。スライドのカスタム塗りつぶしを削除すると、背景は対応する [layout](/slides/ja/cpp/slide-layout/)/[master](/slides/ja/cpp/slide-master/) スライド（すなわち [theme background](/slides/ja/cpp/presentation-theme/)）から再び継承されます。

**後でプレゼンテーションのテーマを変更した場合、背景はどうなりますか？**

スライドが独自の塗りつぶしを持っている場合、その背景は変更されません。背景が [layout](/slides/ja/cpp/slide-layout/)/[master](/slides/ja/cpp/slide-master/) から継承されている場合は、[new theme](/slides/ja/cpp/presentation-theme/) に合わせて更新されます。