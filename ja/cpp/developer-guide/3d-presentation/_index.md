---
title: C++ を使用したプレゼンテーションでの 3D エフェクトの作成
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
description: "Aspose.Slides を使用して C++ で PowerPoint の図形とテキストに 3D 効果を適用およびレンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、3D テキストを構成します。"
---
## **概要**

Aspose.Slides for C++ は、図形やテキストに対して PowerPoint 形式の 3D 書式設定を作成、編集、保持、レンダリングできます。この記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像の塗りつぶし、3D テキストといった 3D 効果について説明します。

{{% alert color="info" title="注" %}}
この記事は PowerPoint 図形とテキストの 3D 書式設定効果について説明しています。個別の 3D モデルファイルの挿入や編集については対象外です。スライドを画像、PDF、HTML にエクスポートすると、Aspose.Slides はそれらの 3D 効果を 2D の出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

[IShape::get_ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_threedformat/) メソッドを使用して、図形に 3D 書式設定を適用します。このメソッドは [IThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/) を返し、図形の 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/get_threedformat/) メソッドを使用します。これにより、図形本体ではなくテキストフレームに 3D 書式設定が適用されます。

最も重要なメソッドは次のとおりです。

| メソッド | 制御対象 | 使用時期 |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_camera/) | 視点、プリセット カメラ タイプ、回転、ズーム、遠近感。 | オブジェクトを 3D 空間で回転させるか、PowerPoint の 3D 回転プリセットに合わせる時に使用します。 |
| [get_LightRig](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_lightrig/) | ライトのプリセット、方向、ライト回転。 | 3D 表面のハイライトや影の見え方を変更したい時に使用します。 |
| [set_Material](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_material/) | フラット、マット、プラスチック、金属などの表面素材。 | 同じ形状を平坦、柔らかい、光沢のある、金属的に見せたい時に使用します。 |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 前面から後方にどれだけ形状が伸びるか。 | 平面の形状を目に見える厚みのある 3D オブジェクトに変える時に使用します。 |
| [get_ExtrusionColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 押し出し側面の色。 | 奥行きを見せたり、前面の塗りつぶしと側面の色を合わせたい時に使用します。 |
| [set_Depth](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint の 3D 書式設定で使用される追加の奥行き。 | ベベルや素材設定と組み合わせて、形状やテキストの奥行きを微調整したい時に使用します。 |
| [get_BevelTop](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_beveltop/) と [get_BevelBottom](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 前面と背面のエッジの隆起または丸み。 | 鋭利な平面ではなく、丸みを帯びたエッジや成形されたエッジを追加したい時に使用します。 |
| [get_ContourColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_contourcolor/) と [set_ContourWidth](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D オブジェクトの輪郭線。 | レンダリング結果でオブジェクトの境界を強調したい時に使用します。 |

## **3D 図形の作成**

図形が説得力のある 3D 表示になるには、通常以下の 4 種類の設定が必要です。

- カメラ設定：デフォルトの正面ビューでは押し出しが隠れる可能性があるため。  
- ライト設定：照明により面や側面が見やすくなるため。  
- 素材設定：表面素材が光の当たり方に影響するため。  
- 押し出しまたは奥行き設定：平面の形状に厚みを持たせるため。

以下の例は矩形を作成し、前面にテキストを追加し、3D 書式設定を適用します。カメラ回転値は度単位で、押し出し高さは 100 ポイントです。例はスライドを PNG 画像に 2 倍のデフォルトサイズでレンダリングし、プレゼンテーションを PPTX として保存します。

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

レンダリングされたスライド画像は、矩形が厚みのある 3D ブロックとして表示されます。

![前面に白い 3D テキストがある青い 3D 矩形のレンダリング結果](img_01_01.png)

## **カメラで図形を回転させる**

PowerPoint では、3D 回転は「3-D 回転」ペインで設定します。X、Y、Z の回転値はカメラ API で設定する回転に対応します。

![X、Y、Z 回転値がハイライトされた PowerPoint の 3-D 回転ペイン](img_02_01.png)

Aspose.Slides では、[IThreeDFormat::get_Camera](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_camera/) を介してカメラにアクセスします。この例は矩形を作成し、正射投影の正面ビューを選択し、X/Y/Z 回転をそれぞれ 20、30、40 度に設定します。ファイルを保存せずにメモリ上で図形を構成します。

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

presentation->Dispose();
```

ビューアがオブジェクトを見る角度を変更したいときにカメラを使用します。スライド上の 2D 図形ジオメトリは変更されず、PowerPoint および Aspose.Slides がレンダリング時に使用する 3D ビューポイントが変更されます。

## **押し出しと奥行きの追加**

押し出しは前面から後方へ形状を伸ばすことで厚みを表現します。PowerPoint では、奥行きコントロールがこの可視厚みを設定し、カラーコントロールが側面の色を決めます。

![奥行きコントロールが押し出しの色と高さプロパティにマッピングされた PowerPoint のスクリーンショット](img_02_02.png)

厚みは [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_extrusionheight/) で、側面の色は [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) で設定します。この例は矩形に 100 ポイントの押し出しと紫色の側面を設定し、カメラを回転させて厚みを見せます。ファイルを保存せずにメモリ上で構成します。

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

[IThreeDFormat::set_Depth](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_depth/) メソッドは 3D 図形の奥行きを設定します。[set_ExtrusionHeight](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ithreedformat/set_extrusionheight/) メソッドは押し出し効果の高さを制御します（この例を参照）。

## **3D 効果とともにグラデーションまたは画像塗りを使用する**

3D 書式設定は図形の塗りとは独立しています。前面に単色、グラデーション、パターン、画像のいずれかを適用しつつ、同じカメラ、ライト、素材、押し出し設定を使用できます。

この例は前面に青からオレンジへのグラデーションを、150 ポイントの押し出しには濃いオレンジ色を適用します。グラデーションの停止位置は 0 と 100 が開始と終了を示します。カメラ回転値は度単位です。スライドは PNG に 2 倍のデフォルトサイズでレンダリングされます。

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

![青からオレンジへのグラデーション塗りとオレンジの押し出しを持つ 3D 矩形のレンダリング結果](img_02_03.png)

画像塗りを使用する場合は、プレゼンテーションに画像を追加し、図形の塗りに割り当てます。この例は作業ディレクトリに "image.jpg" という名前のファイルが存在すると想定しています。画像を矩形全体に伸ばし、150 ポイントの押し出しを適用し、カメラ回転を度単位で設定します。ファイルを保存またはレンダリングせずにメモリ上で構成します。

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

画像は前面に描画され、押し出しは 3D 側面として描画されます。

![前面に写真塗り、側面にオレンジの押し出しを持つ 3D 矩形のレンダリング結果](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

図形の 3D 書式設定は図形本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

以下の例はオレンジと白の格子パターンのテキストを作成し、上向きのアーチを適用し、[ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/get_threedformat/) を介して 3D 設定を構成します。押し出し高さと奥行きはポイント単位、ライト回転は度単位です。図形の塗りと輪郭は非表示にし、テキストのみが見えるようにします。例は PNG に 2 倍のデフォルトサイズでレンダリングし、プレゼンテーションを PPTX として保存します。

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

テキストは曲線状に押し出された 3D 文字としてレンダリングされます。

![アーチ状に変形した WordArt、オレンジの格子塗り、暗い押し出しを持つ 3D テキストのレンダリング結果](img_02_05.png)

## **3D 図形上でテキストを平坦に保つ**

テキストを読みやすく保ちつつ図形の 3D 外観を維持するには、[ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_textframeformat/) 経由で [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_keeptextflat/) を呼び出します。値が `true` の場合、テキストは 3D シーンから除外されます。`false` の場合、テキストはシーンに参加し、3D の向きに従います。

この設定は図形の 3D 書式設定（カメラ、照明、素材、押し出し）を削除しません。また、通常の回転とは異なります。[IShape::set_Rotation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/set_rotation/) はスライド平面上で図形を回転させ、[ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_rotationangle/) はテキストのバウンディングボックス内でのカスタム回転を制御します。テキストを 3D シーンから除外しても、これらの角度はリセットされません。

以下の自己完結型例は、青い矩形にテキストを付け、元の横に複製します。両方の図形は同一の 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `false`、右側は `true`。カメラ角度は度単位、押し出し高さは 40 ポイントです。例はプレゼンテーションを PPTX として保存し、比較スライドを PNG に 2 倍のデフォルトサイズでレンダリングします。

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

左側はテキストが 3D 向きに従い、右側は平坦で読みやすくなります。両方の矩形は同じ可視押し出しと 3D 向きを保持しています。

![左側は KeepTextFlat が false、右側は true の 3D 矩形の比較画像](keep_text_flat.png)

## **エクスポートとレンダリングの挙動**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスタライズまたは 2D 結果として出力に描画されます。これはスライドを [PNG](/slides/ja/cpp/convert-powerpoint-to-png/) にレンダリングする場合、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/) にエクスポートする場合、[HTML](/slides/ja/cpp/convert-powerpoint-to-html/) にエクスポートする場合、または [ビデオ変換](/slides/ja/cpp/convert-powerpoint-to-video/) 用のフレームを生成する場合に当てはまります。

留意すべき点：

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にビューアがオブジェクトを回転させることはできません。  
- 最終的な外観はカメラ、ライトリグ、素材、押し出し、塗りつぶし、スライドのスケーリングの組み合わせに依存します。  
- 継承またはテーマベースの書式設定値を確認したい場合は、[有効な図形プロパティ](/slides/ja/cpp/shape-effective-properties/) を使用してください。  
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保存できません。その場合、視覚的結果は編集可能な 3D 設定としてではなく、レンダリングされた画像として保存されます。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**  
Aspose.Slides は図形とテキストの PowerPoint 3D 効果を作成およびレンダリングしますが、エクスポートされた画像、PDF、HTML ページをビューアが回転できるインタラクティブな 3D シーンにすることはできません。PPTX では、フォーマットがサポートしている限り 3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D 効果の違いは何ですか？**  
3D モデルはプレゼンテーションに挿入される別個の 3D オブジェクトです。3D 効果は通常の PowerPoint 図形やテキストに対して適用される書式設定で、回転、押し出し、ベベル、照明、素材などを指します。本稿は 3D 効果について取り上げています。

**可視的な 3D 図形に必要な設定はどれですか？**  
最低でもカメラ回転と押し出しまたは奥行きを設定する必要があります。実際には、レンダリングされた面にハイライトと影をはっきりさせるためにライトリグと素材も設定するのが一般的です。

**図形とテキストの両方に 3D 効果を適用できますか？**  
はい。図形本体には [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/get_threedformat/) を、テキストには [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/get_threedformat/) を使用します。

**画像、PDF、HTML、ビデオフレームにエクスポートしたときに 3D 効果は表示されますか？**  
はい。Aspose.Slides はスライド画像、PDF、HTML、ビデオ変換用フレームを生成する際に 3D 効果をレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれ、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**  
はい。最終的なカメラ、ライトリグ、ベベル、関連 3D 値を取得するには、[Shape Effective Properties](/slides/ja/cpp/shape-effective-properties/) に記載されている有効な書式設定 API を使用してください。