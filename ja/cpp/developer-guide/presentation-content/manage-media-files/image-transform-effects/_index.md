---
title: C++ でプレゼンテーションの画像変換効果を管理する
linktitle: 画像変換効果
type: docs
weight: 11
url: /ja/cpp/image-transform-effects/
keywords:
- 画像変換
- 画像効果
- 明るさ
- コントラスト
- グレイスケール
- デュートーン
- ティント
- HSL
- カラー置換
- ぼかし
- 透明度
- アルファ効果
- エフェクトチェーン
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、画像フレームの画像変換効果を適用、チェーン、検査、削除、検証します。"
---
## **概要**

Aspose.Slides は画像調整を画像変換操作の順序付きコレクションとして表します。画像フレームの場合、フレームの [ISlidesPicture](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidespicture/) を取得し、[ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidespicture/get_imagetransform/) にアクセスします。返される [IImageTransformOperationCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/) を使用すると、元の画像バイト列を書き換えることなく、効果を追加、列挙、検査、削除、クリアできます。

本記事では、明るさとコントラスト、カラー変換、ぼかし、透明度、順序付きエフェクトチェーン、実効値、削除、PPTX の往復検証の完全なワークフローを示します。

## **エフェクトの所有権と画像の再利用の理解**

画像リソースとそれを表示する画像は別々のオブジェクトです。

- [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) はプレゼンテーションが所有するソース画像データを格納または参照します。
- [ISlidesPicture](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidespicture/) は画像フィルの一部であり、画像リソースを参照しながら画像変換コレクションを保持します。
- [IPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipictureframe/) はスライド上のシェイプで、関連する画像フィル、ジオメトリ、トリミング設定、その他のフレームレベルの書式設定を所有します。

したがって、画像変換操作は [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) のバイト列を変更しません。同じ `IPPImage` を [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/addpictureframe/) に複数回渡すと、各新しい画像フレームは独自の `ISlidesPicture` と独自の変換コレクションを取得します。あるフレームに対してグレースケールを適用しても、他のフレームがグレースケールになることはありません。すべてのフレームが同じ埋め込み画像リソースを再利用しているからです。

同じ `ISlidesPicture::get_ImageTransform` モデルは、シェイプやスライド背景など他の画像フィルでも使用されます。以下の例は画像フレームに焦点を当てています。

## **有効なパラメーター範囲と単位の使用**

以下のメソッドは次の意味的範囲と単位を使用します。特定のライブラリバージョンがすべての範囲外値を即座に拒否しなくても、これらの範囲内に値を保ってください。ターゲットのプレゼンテーション形式は保存時または PowerPoint がファイルを開く際に正規化、除外、または無効データを拒否する可能性があります。

| 操作 | パラメーター | 有効範囲と単位 |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` から `100`（パーセント）。`0` はコンポーネントを変更しません。 |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | なし | 数値パラメーターはありません。アルファは変更されません。 |
| [AddDuotoneEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 暗部と明部のピクセル用の 2 色。`System::Drawing::Color` の RGB とアルファは `0` から `255`。 |
| [AddTintEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相は `0`（含む）から `360`（除く）度。`amount` は `-100` から `100`（パーセント）。 |
| [AddHSLEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相は `0`（含む）から `360`（除く）度。彩度と輝度は `-100` から `100`（パーセント）。 |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 置換色はチャンネル値が `0` から `255`。既存のアルファは変更されません。 |
| [AddBlurEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半径は非負でポイント単位。`grow` はぼかし領域が元の境界を超えるかを制御します。 |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非負パーセント。通常の不透明度スケーリングは `0` から `100`：`0` は完全に透明、`100` は既存のアルファを保持。 |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` から `100`（パーセント）不透明度。 |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` から `100`（パーセント）アルファ閾値。閾値未満は透明、以上は不透明になります。 |

固定アルファ変調の場合、透明度と不透明度は補完関係にあります。たとえば、35% の透明度はアルファ変調量 65% に相当します。

## **明るさとコントラストの適用**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) は [IBrightnessContrast](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/ibrightnesscontrast/) 操作を返します。スカラー設定は操作作成時に供給されます。`IBrightnessContrast::GetEffective` メソッドは計算された読み取り専用値を返し、検査またはログに記録できます。

以下の例は明るさを 15%、コントラストを 20% 増加させ、埋め込み画像を変更せずにプレビューをレンダリングします。

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/brightnesscontrast/) は Office 2010 の画像効果拡張で、標準 DrawingML の輝度効果ほど汎用性がありません。明るさとコントラストを PPTX の往復後も編集可能にしたい場合は、[IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) を使用し、ファイル再オープン後に結果を検証してください。形式の制限セクションでこの違いを詳しく説明します。

## **カラー変換の適用**

カラー効果は、同一画像リソースを再利用する複数の画像フレームに対して個別に適用できます。以下の例は 5 つのフレームを作成し、グレースケール、デュートーン、ティント、HSL 調整、カラー置換を適用します。

[IDuotone](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iduotone/) には 2 つの独立に編集可能なカラー パラメーターがあります：`get_Color1` が暗部ピクセル、`get_Color2` が明部ピクセルに対応します。これは単一スカラー値よりも複雑な設定を持つ効果の有用な例です。

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) はすべてのピクセルの色を固定色に置換し、アルファは保持します。これは、ソース色を別の色にマッピングし、両方の色形式を公開する [AddColorChangeEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) とは異なります。

## **ぼかし、透明度、アルファ効果の追加**

[AddBlurEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) はすべてのカラー チャネル（アルファ含む）に影響します。ぼかしエッジが元画像の境界を超える可能性がある場合は `grow` を `true` に設定してください。

均一な透明度には [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) を使用します。既存のすべてのアルファ値に乗算するため、半透明ピクセルは比例的に異なるまま残ります。[AddAlphaReplaceEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) はすべてのピクセルに同一のアルファ値を割り当てます。[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) は閾値に基づいてアルファを 2 レベルに変換します。

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

パラメーター不要のその他のアルファ操作には、すべての非ゼロアルファを完全に不透明にする [AddAlphaCeilingEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)、100% 未満のアルファを完全に透明にする [AddAlphaFloorEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)、および `100% - alpha` に変換する [AddAlphaInverseEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) があります。

## **順序付きエフェクトチェーンの構築**

すべての `Add...Effect` メソッドは新しい操作をコレクションの末端に追加します。レンダラはコレクションを順序付きパイプラインとして使用し、操作 0 の出力が操作 1 の入力となります。したがって、同じ操作でも順序を変えると異なる画像が生成されます。

例として、グレースケール → ティント の順序は色相情報を削除してから輝度結果を再着色します。ティント → グレースケール はティントを再び除去します。同様に、アルファ置換は以前の操作で計算されたアルファ値を上書きできますが、アルファ変調は相対的な差を保持します。

以下の例は 4 操作のチェーンを構築し、PPTX として保存、プレゼンテーションを再オープンし、操作タイプと順序の両方を確認し、再オープンされた結果をレンダリングします。

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

コレクションはカラー、アルファ、ぼかし操作を別々のチェーンに制限する互換性マトリックスを課しません。組み合わせて使用できますが、常に有用とは限りません。固定カラー置換は以前のカラー効果で生成された RGB の変化を除去し、デュートーンの後にグレースケールを適用すると 2 色が消えます。アルファの天井、床、置換、または二段階操作は以前に作成されたアルファの詳細を破棄する可能性があります。アイテムを無秩序なフラグとしてではなく、目的とするピクセル処理シーケンスに従ってチェーンを構築してください。

## **編集可能値と実効値の検査**

編集可能な操作は `ISlidesPicture::get_ImageTransform` に格納されているオブジェクトです。エフェクトによっては書き込み可能メンバーを直接公開します。例として、[IBlur](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iblur/) は `set_Radius` と `set_Grow` を、[IAlphaModulateFixed](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/ialphamodulatefixed/) は `set_Amount` を、[IAlphaBiLevel](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/ialphabilevel/) は `set_Threshold` を公開します。 [IDuotone](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iduotone/) のようなカラー効果は可変の [IColorFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icolorformat/) オブジェクトを公開します。

[IBrightnessContrast](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/ihsl/)、[ITint](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/itint/)、[IAlphaReplace](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/ialphareplace/) などのインターフェイスは、作成時のスカラー値を書き込み可能プロパティとして公開しません。設定を変更するには、対象の操作を削除し、必要な位置に置き換える操作を追加してください。

`GetEffective()` が返す実効データは計算済みの読み取り専用オブジェクトです。テーマ依存のカラー解決や、レンダラが使用する正規化値の取得に有用ですが、別の編集インターフェイスではありません。以下の例はチェーンを列挙し、いくつかの一般的な操作の実効値を検査します。

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

グレースケール、アルファ天井、アルファ逆変換などパラメーター不要の効果でも実効データオブジェクトは存在しますが、印刷すべきスカラー設定はありません。コレクション内での存在と位置が重要な情報です。

## **画像変換の削除またはクリア**

[IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) を使用してインデックスで 1 つの操作を削除します。削除後はインデックスがシフトするため、最初に対象を検索し、列挙後に削除してください。`Clear()` でチェーン全体を削除できます。

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

変換を削除またはクリアしても、画像の書式設定のみが変更されます。再利用されている [IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) リソースは削除、再圧縮、または変更されません。

## **プレゼンテーション形式とエクスポート先の考慮**

画像変換は DrawingML から派生しているため、エフェクトチェーンの編集可能な形式としては PPTX が推奨されます。PPTX でもすべての操作が同等の移植性を持つわけではありません。

- 標準 DrawingML 操作（輝度、グレースケール、デュートーン、ティント、HSL、ぼかし、一般的なアルファ操作）は PPTX の往復で最も生存率が高いです。保存後に必ずファイルを再オープンし、コレクションを検査してください。
- [BrightnessContrast](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/brightnesscontrast/) は Office 2010 の拡張で、標準 DrawingML 輝度操作ではありません。インメモリレンダリングには利用可能ですが、保存後に再オープンした際に編集可能な [IBrightnessContrast](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/ibrightnesscontrast/) が残る保証はありません。永続的な明るさ・コントラスト調整には [AddLuminanceEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) を使用してください。
- バイナリ PPT 形式は完全な DrawingML 効果モデルが導入される前のものです。PPT に保存すると未サポートの操作が除外されたり、チェーンがサポートサブセットに縮小されたり、外観が近似されることがあります。複雑な編集可能チェーンの検証形式として PPT を使用しないでください。
- PNG、JPEG、TIFF、PDF、SVG、HTML などのビジュアル出力は、サポートされたチェーンをレンダリング結果に適用します。これらの出力には編集可能な `IImageTransformOperationCollection` が含まれず、ラスタ形式は結果をピクセルにフラット化し、文書やベクターエクスポートは独自のレンダリング表現を保存します。
- エフェクトはリンク画像を自己完結型にしません。リンク画像のレンダリングは、プレゼンテーション読み込み時にリンクリソースが利用可能であることに依存します。

異なるプレゼンテーションビューアは、特に複数のアルファまたはカラー量子化操作が組み合わされた場合にエッジケースの描画が異なることがあります。重要な出力では、実稼働環境で使用している同じ Aspose.Slides バージョンで編集可能な往復と最終エクスポート形式の両方をテストしてください。

## **FAQ**

**画像変換エフェクトは埋め込み画像データを変更しますか？**

いいえ。操作は画像フィルで使用される `ISlidesPicture` に属します。基礎となる `IPPImage` バイトは変更されません。

**同じ画像を再利用する 2 つの画像フレームはエフェクトを共有しますか？**

いいえ。`IPPImage` の再利用は画像データの重複を防ぎますが、各画像フレームは通常別個の `ISlidesPicture` と画像変換コレクションを持ちます。

**カラー、ぼかし、アルファエフェクトは組み合わせられますか？**

はい。コレクションは 1 つの順序付きチェーンで受け入れます。各操作が前の出力に与える影響（置換や閾値操作が早期のカラーやアルファ詳細を破棄する可能性がある）を考慮してください。

**実効値が読み取り専用なのはなぜですか？**

実効データはレンダリングで使用される計算済み値（解決されたカラーを含む）を表します。書き込み可能なメンバーが存在する場合は変換コレクションに格納された操作を編集し、存在しない場合は削除して新しい作成パラメーターで置換してください。

**どの形式を使用すれば変換チェーンを保持できますか？**

PPTX を使用し、再オープンしてファイルを検証してください。レガシー PPT は完全な DrawingML 効果モデルを表現できず、レンダリング出力形式は外観を保持しますが編集可能な変換操作は保持しません。