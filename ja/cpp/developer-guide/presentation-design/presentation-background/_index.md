---
title: C++でプレゼンテーションの背景を管理する
linktitle: スライド背景
type: docs
weight: 20
url: /ja/cpp/presentation-background/
keywords:
- プレゼンテーション背景
- スライド背景
- 単色
- グラデーション色
- 画像背景
- 背景の透明度
- 背景プロパティ
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument ファイルの動的な背景設定方法を学び、プレゼンテーションを強化するコードのヒントをご紹介します。"
---
## **はじめに**

単色、グラデーション、画像はスライドの背景として一般的に使用されます。**通常のスライド**（単一のスライド）または**マスタースライド**（複数のスライドに同時に適用されます）に背景を設定できます。

![PowerPoint の背景](powerpoint-background.png)

## **通常スライドの単色背景の設定**

Aspose.Slides を使用すると、プレゼンテーション内の特定のスライドの背景を単色に設定できます（プレゼンテーションがマスタースライドを使用している場合でも）。この変更は選択したスライドのみに適用されます。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/) 上の [get_SolidFillColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/get_solidfillcolor/) メソッドを使用して、単色の背景色を指定します。
5. 変更したプレゼンテーションを保存します。

以下の C++ の例は、通常スライドの背景を青い単色に設定する方法を示しています。

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Set the background color of the slide to blue.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save the presentation to disk.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **マスタースライドの単色背景の設定**

Aspose.Slides を使用すると、プレゼンテーションのマスタースライドの背景を単色に設定できます。マスタースライドはすべてのスライドの書式設定を制御するテンプレートとして機能するため、マスタースライドの背景に単色を選択すると、すべてのスライドに適用されます。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. `get_Masters` を介して取得したマスタースライドの [BackgroundType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. マスタースライドの背景の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Solid` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/) 上の [get_SolidFillColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/get_solidfillcolor/) メソッドを使用して、単色の背景色を指定します。
5. 変更したプレゼンテーションを保存します。

以下の C++ の例は、マスタースライドの背景をフォレストグリーンの単色に設定する方法を示しています。

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Set the background color for the Master slide to Forest Green.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Save the presentation to disk.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **スライドのグラデーション背景の設定**

グラデーションは、色が徐々に変化することで作られる視覚効果です。スライドの背景として使用すると、プレゼンテーションがより芸術的でプロフェッショナルに見えます。Aspose.Slides を使用すると、スライドの背景にグラデーション色を設定できます。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Gradient` に設定します。
4. [FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/) 上の [get_GradientFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/get_gradientformat/) メソッドを使用して、希望するグラデーション設定を構成します。
5. 変更したプレゼンテーションを保存します。

以下の C++ の例は、スライドの背景をグラデーション色に設定する方法を示しています。

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

## **スライドの背景に画像を設定する**

単色やグラデーションの塗りつぶしに加えて、Aspose.Slides では画像をスライドの背景として使用できます。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドの [BackgroundType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/backgroundtype/) を `OwnBackground` に設定します。
3. スライドの背景の [FillType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/filltype/) を `Picture` に設定します。
4. スライドの背景として使用したい画像を読み込みます。
5. 画像をプレゼンテーションの画像コレクションに追加します。
6. [FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/) 上の [get_PictureFillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fillformat/get_picturefillformat/) メソッドを使用して、画像を背景として割り当てます。
7. 変更したプレゼンテーションを保存します。

以下の C++ の例は、スライドの背景に画像を設定する方法を示しています。

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 背景画像のプロパティを設定します。
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// 画像をロードします。
auto image = Images::FromFile(u"Tulips.jpg");
// 画像をプレゼンテーションの画像コレクションに追加します。
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// プレゼンテーションをディスクに保存します。
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

以下のコードサンプルは、背景塗りつぶしタイプをタイル画像に設定し、タイルプロパティを変更する方法を示しています。

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

{{% alert color="info" %}}
詳しくは: [**タイル画像をテクスチャとして**](/slides/ja/cpp/shape-formatting/#tile-picture-as-texture)。
{{% /alert %}}

### **スライドの背景画像の透明度を変更する**

スライドの背景画像の透明度を調整して、スライドの内容を際立たせたい場合があります。以下の C++ コードは、スライド背景画像の透明度を変更する方法を示しています。

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // 例として。

// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// 画像変換操作のコレクションを取得します。
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// 既存の固定パーセンテージ透明度エフェクトを検索します。
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// 新しい透明度の値を設定します。
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// プレゼンテーションをディスクに保存します。
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **スライドの背景値を取得する**

Aspose.Slides は、スライドの実際の背景値を取得するための [IBackgroundEffectiveData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibackgroundeffectivedata/) インターフェイスを提供します。このインターフェイスは、有効な [FillFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) と [EffectFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) を公開します。

[BaseSlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/baseslide/) クラスの `get_Background` メソッドを使用すると、スライドの実効背景を取得できます。

以下の C++ の例は、スライドの実効背景値を取得する方法を示しています。

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// マスタ、レイアウト、テーマを考慮した実効背景を取得します。
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

## **よくある質問**

### カスタム背景をリセットして、テーマ/レイアウトの背景を復元できますか？

はい。スライドのカスタム塗りつぶしを削除すると、背景は対応する [layout](/slides/ja/cpp/slide-layout/)/[master](/slides/ja/cpp/slide-master/) スライド（つまり [theme background](/slides/ja/cpp/presentation-theme/)）から再度継承されます。

### プレゼンテーションのテーマを後で変更すると、背景はどうなりますか？

スライドに独自の塗りつぶしがある場合、変更は行われません。背景が [layout](/slides/ja/cpp/slide-layout/)/[master](/slides/ja/cpp/slide-master/) から継承されている場合は、新しいテーマに合わせて更新されます。