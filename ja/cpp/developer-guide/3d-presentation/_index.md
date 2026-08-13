---
title: C++ を使用したプレゼンテーションでの 3D 効果の作成
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D プレゼンテーション
- 3D 回転
- 3D 奥行き
- 3D 押し出し
- 3D グラデーション
- 3D テキスト
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ で Aspose.Slides を使用して PowerPoint の形状とテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、マテリアル、押し出し、塗りつぶし、3D テキストを構成します。"
---
## **概要**

Aspose.Slides for C++ は、形状やテキスト向けに PowerPoint スタイルの 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、マテリアル、グラデーションまたは画像の塗りつぶし、3D テキストなどの 3D 効果について説明します。

{{% alert color="info" %}}
この記事は PowerPoint の形状とテキストに対する 3D 書式設定効果についてです。単独の 3D モデル ファイルの挿入や編集については扱いません。スライドを画像、PDF、または HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果をエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

形状に 3D 書式設定を適用するには、[IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) インターフェイスの [get_ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_threedformat/) メソッドを使用します。このメソッドは [IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) を返し、対象の形状の 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/) インターフェイスの [get_ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/get_threedformat/) メソッドを使用します。これにより形状本体ではなくテキストフレームに 3D 書式設定が適用されます。

最も重要なメソッドは次のとおりです。

| メソッド | 制御対象 | 使用タイミング |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_camera/) | 視点、プリセットカメラタイプ、回転、ズーム、遠近法 | 3D 空間でオブジェクトを回転させるか、PowerPoint の 3D 回転プリセットに合わせるとき |
| [get_LightRig](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_lightrig/) | ライトのプリセット、方向、回転 | 3D 表面のハイライトと影の表示方法を変更するとき |
| [set_Material](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_material/) | フラット、マット、プラスチック、金属などの表面素材 | 同じ形状をより平坦に、柔らかく、光沢のある、または金属的に見せるとき |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 形状が前面からどれだけ後方に延びるか | 平面の形状を視覚的に厚みのある 3D オブジェクトに変えるとき |
| [get_ExtrusionColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 押し出された側面の色 | 奥行きを可視化するか、側面の色を前面の塗りつぶしと合わせるとき |
| [set_Depth](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint の 3D 書式設定で使用される追加の 3D 奥行き | 形状やテキストの奥行きを微調整します。特にベベルやマテリアル設定と併用する場合に有効です。 |
| [get_BevelTop](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_beveltop/) と [get_BevelBottom](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 前面と背面の上げられたまたは丸められたエッジ | 鋭利で平坦な面の代わりに、柔らかく成形されたエッジを追加するとき |
| [get_ContourColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_contourcolor/) と [set_ContourWidth](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D オブジェクトの輪郭線 | レンダリング結果でオブジェクトの境界を強調する際に使用します。 |

## **3D 形状の作成**

形状を説得的に 3D に見せるには通常、次の 4 種類の設定が必要です。

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れることがあります。
- ライト設定：照明により面や側面が読み取れやすくなります。
- マテリアル設定：表面素材が光の描画に影響します。
- 押し出しまたは奥行き設定：平面の形状に厚みを持たせます。

次の例は長方形を作成し、前面にテキストを追加し、3D 書式設定を適用してプレゼンテーションを PPTX として保存し、スライドを PNG 画像としてレンダリングします。

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

レンダリングされたスライド画像は、長方形が厚みのある 3D ブロックとして表示されます。

![前面に白い 3D テキストがある青い 3D 長方形のレンダリング画像](img_01_01.png)

## **カメラで形状を回転させる**

PowerPoint では、3‑D 回転ペインから 3D 回転を設定します。X、Y、Z の回転値はカメラ API で設定する回転に対応しています。

![X、Y、Z の回転値がハイライトされた PowerPoint の 3‑D 回転ペイン](img_02_01.png)

Aspose.Slides では、[IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) を介してカメラタイプと回転を設定します。

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

ビューアがオブジェクトを見る角度を変更したいときにカメラを使用します。スライド上の 2D 形状ジオメトリは変更されず、PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変わります。

## **押し出しと奥行きの追加**

押し出しは形状を前面から後方へ拡張して厚みを持たせます。PowerPoint では、奥行きコントロールがこの可視厚みを設定し、色コントロールが側面の色を設定します。

![奥行きコントロールが押し出しの色と押し出し高さプロパティにマッピングされた PowerPoint の表示](img_02_02.png)

厚みは [set_ExtrusionHeight](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_extrusionheight/) で、側面の色は [get_ExtrusionColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) で設定します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

PowerPoint の奥行き値を直接操作するか、ベベル、マテリアル、テキスト効果と組み合わせて奥行きを使用したい場合は [set_Depth](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_depth/) を使用します。多くの形状シナリオでは、可視的な押し出しを直接示す `set_ExtrusionHeight` の方が分かりやすい設定です。

## **3D 効果でグラデーションまたは画像塗りつぶしを使用する**

3D 書式設定は形状の塗りつぶしとは独立しています。前面に単色、グラデーション、パターン、または画像塗りつぶしを適用しながら、同じカメラ、ライト、マテリアル、押し出し設定を使用できます。

次の例は形状にグラデーション塗りつぶしを適用し、側面に暗めの押し出し色を設定します。

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

レンダリング結果は前面のグラデーションを保持し、押し出しは別個に描画されます。

![青からオレンジへのグラデーション塗りつぶしとオレンジの押し出しを持つ 3D 長方形のレンダリング画像](img_02_03.png)

画像塗りつぶしを使用する場合は、画像をプレゼンテーションに追加して形状の塗りつぶしに割り当てます。

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

画像は前面にレンダリングされ、押し出しは 3D 側面として描画されます。

![前面に写真塗りつぶし、側面にオレンジの押し出しを持つ 3D 長方形のレンダリング画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

形状の 3D 書式設定は形状本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、マテリアル、照明、カメラ設定が必要な WordArt のような効果に便利です。

次の例はパターン塗りつぶしのテキストを作成し、WordArt 変形を適用し、[ITextFrameFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/) に 3D 設定を構成します。

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

テキストは曲線状に押し出された 3D レタリングとしてレンダリングされます。

![アーチ状の WordArt 変形、オレンジのパターン塗りつぶし、暗い押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する場合、3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする際は、3D シーンがラスタライズまたは 2D 結果として出力に描画されます。これはスライドを [PNG](/slides/ja/cpp/convert-powerpoint-to-png/) にレンダリングする場合、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/) にエクスポートする場合、[HTML](/slides/ja/cpp/convert-powerpoint-to-html/) にエクスポートする場合、または [video conversion](/slides/ja/cpp/convert-powerpoint-to-video/) 用のフレームを生成する場合にも当てはまります。

以下の点に留意してください。

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、ライトリグ、マテリアル、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。
- 継承またはテーマベースの書式設定値を確認したい場合は、[効果的な形状プロパティ](/slides/ja/cpp/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保持できません。そのような形式では、ビジュアル結果がレンダリングされ、編集可能な 3D 設定としては保存されません。

## **よくある質問**

### Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？

Aspose.Slides は形状とテキストに対する PowerPoint の 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX では、フォーマットがサポートしている限り 3D 書式設定は PowerPoint で編集可能なまま残ります。

### 3D モデルと 3D 効果の違いは何ですか？

3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は通常の PowerPoint 形状やテキストに対して適用される書式設定で、回転、押し出し、ベベル、照明、マテリアルなどが含まれます。本稿は 3D 効果について取り上げています。

### 可視的な 3D 形状に必要な設定はどれですか？

最低でもカメラの回転と押し出しまたは奥行きを設定します。実務では、光源リグとマテリアルも設定して、レンダリングされた面に明確なハイライトとシャドウを付けることが一般的です。

### 形状とテキストの両方に 3D 効果を適用できますか？

はい。形状本体には [IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) を、テキストには [ITextFrameFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/) を使用します。

### 画像、PDF、HTML、または動画フレームにエクスポートしたときに 3D 効果は表示されますか？

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、動画変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

### 継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？

はい。最終的なカメラ、ライトリグ、ベベル、その他の 3D 値を取得するには、[効果的な形状プロパティ](/slides/ja/cpp/shape-effective-properties/) に記載された API を使用してください。