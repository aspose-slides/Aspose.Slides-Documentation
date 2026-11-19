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
- 3D 深度
- 3D 押し出し
- 3D グラデーション
- 3D テキスト
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint の図形とテキストに 3D エフェクトを適用およびレンダリングします。カメラ、照明、素材、押し出し、塗りつぶし、3D テキストを構成します。"
---
## **概要**

Aspose.Slides for C++ は、図形やテキストに対して PowerPoint スタイルの 3D 書式設定を作成、編集、保持、レンダリングできます。本記事では、回転、押し出し、ベベル、照明、素材、グラデーションまたは画像の塗りつぶし、3D テキストなどの 3D エフェクトについて解説します。

{{% alert color="info" title="Note" %}}
この記事は、PowerPoint の図形とテキストに対する 3D 書式設定エフェクトについてです。単独の 3D モデル ファイルの挿入や編集については扱っていません。スライドを画像、PDF、HTML にエクスポートすると、Aspose.Slides はそれらの 3D エフェクトをエクスポートされた 2D 出力にレンダリングします。
{{% /alert %}}

## **3D 書式設定の概念**

図形に 3D 書式設定を適用するには、[IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) メソッドを使用します。このメソッドは [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/) を返し、対象の図形の 3D シーンを制御します。

テキストの場合は、[ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) メソッドを使用します。これにより、図形本体ではなくテキストフレームに 3D 書式設定が適用されます。

最も重要なメソッドは次のとおりです。

| メソッド | 制御内容 | 使用タイミング |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | 視点、プリセット カメラの種類、回転、ズーム、パースペクティブ。 | 3D 空間でオブジェクトを回転させる、または PowerPoint の 3D 回転プリセットに合わせる。 |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | ライトのプリセット、方向、回転。 | ハイライトや影が 3D 表面上でどのように表示されるかを変更する。 |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | 表面素材 (フラット、マット、プラスチック、金属など)。 | 同じジオメトリを、より平坦、柔らかい、光沢のある、または金属的に見せる。 |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 図形が正面からどれだけ後方へ伸びるか。 | 平面の図形を厚みのある 3D オブジェクトに変える。 |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 押し出された側面の色。 | 深さを可視化したり、側面の色を正面の塗りと合わせたりする。 |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint の 3D 書式設定で使用される追加の 3D 深さ。 | 図形やテキストの深さを微調整する、特にベベルや素材設定と組み合わせる場合。 |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) と [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 正面と背面のエッジの盛り上げまたは丸み。 | 鋭いフラット面の代わりに、柔らかく成形されたエッジを追加する。 |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) と [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D オブジェクトの輪郭。 | レンダリング出力でオブジェクトの境界を強調する。 |

## **3D 図形の作成**

図形が納得のいく 3D に見えるまでには、通常次の 4 種類の設定が必要です。

- カメラ設定：デフォルトの正面表示では押し出しが隠れることがあるため。
- ライト設定：照明により面と側面が見やすくなるため。
- 素材設定：表面が光の当たり方に影響するため。
- 押し出しまたは深さ設定：平面の図形に厚みを持たせるため。

次の例は矩形を作成し、正面にテキストを追加して 3D 書式設定を適用します。カメラの回転値は度単位、押し出し高さは 100 ポイントです。例はスライドを PNG 画像としてデフォルトの 2 倍サイズでレンダリングし、プレゼンテーションを PPTX として保存します。

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

![正面に白い 3D テキストがある青い 3D 矩形のレンダリング画像](img_01_01.png)

## **カメラで図形を回転させる**

PowerPoint では、3-D Rotation パネルから 3D 回転を構成します。X、Y、Z の回転値はカメラ API で設定する回転に対応しています。

![PowerPoint の 3-D Rotation パネルで X、Y、Z の回転値がハイライトされている様子](img_02_01.png)

Aspose.Slides では、[IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) を介してカメラにアクセスします。この例は矩形を作成し、正投影の正面ビューを選択し、X、Y、Z の回転をそれぞれ 20、30、40 度に設定します。ファイルを保存せずにメモリ内で図形を構成します。

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

ビューアがオブジェクトを見る向きを変更したいときにカメラを使用します。スライド上の 2D 図形ジオメトリは変更されず、PowerPoint と Aspose.Slides がレンダリング時に使用する 3D 視点が変更されます。

### **テンプレート図形からカメラの向きをコピーする**

テンプレート図形のカメラ向きを合わせるには、[get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) でプリセットを取得し、[set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) で適用します。例は `template.pptx` を開き、1 枚目のスライドの最初の図形から 2 枚目のスライドの 2 番目の図形へカメラ向きをコピーします。両方の図形はすでに 3D ライティングが設定されており、2 番目の図形には明示的なカメラ回転がありません。

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) は角度を度単位で返します。インデックス `0` が緯度、`1` が経度、`2` が回転です。これらの角度を [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) に同順で渡します。ソースに明示的な回転がない場合、`GetRotation` は null ポインタを返すので、2 番目の図形の角度は設定しないでおきます。`(0, 0, 0)` の明示的な回転は 0 が 3 つ入った配列を返すのでコピーします。

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint で `camera-copy.pptx` を再度開くと、右側の矢印は左側の矩形と同じカメラプリセットと回転を持ちます。両方の図形は同じライティングと押し出し深さを使用しています。

![左側が青い 3D 矩形、右側が同一カメラ向きの右矢印で、上方右側から見た様子](camera-orientation.png)

## **押し出しと深さの追加**

押し出しは正面から裏側へ拡張することで図形を厚く見せます。PowerPoint では深さコントロールがこの可視厚さを設定し、色コントロールが側面の色を設定します。

![PowerPoint の深さコントロールが押し出し色と押し出し高さプロパティに対応している様子](img_02_02.png)

厚さには [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) を、側面の色には [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) を使用します。この例は矩形に 100 ポイントの押し出しと紫色の側面を付け、カメラを回転させて厚みを見せます。ファイルを保存せずにメモリ内で図形を構成します。

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

[IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) メソッドは 3D 図形の深さを設定します。[set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) メソッドは押し出し効果の高さを制御します（この例を参照）。

## **3D エフェクトでグラデーションまたは画像塗りを使用する**

3D 書式設定は図形の塗りとは独立しています。正面に単色、グラデーション、パターン、または画像塗りを適用しても、同じカメラ、ライト、素材、押し出し設定を使用できます。

この例は正面に青からオレンジへのグラデーションを設定し、側面に紫色の 150 ポイント押し出しを適用します。グラデーションの停止位置は 0 と 100 が開始と終了を示します。カメラ回転値は度単位です。スライドはデフォルトの 2 倍サイズで PNG 画像にレンダリングされます。

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

![青からオレンジへのグラデーション塗りとオレンジの押し出しを持つ 3D 矩形のレンダリング画像](img_02_03.png)

画像塗りを使用する場合は、画像をプレゼンテーションに追加し、図形の塗りとして割り当てます。この例は作業ディレクトリに `image.jpg` というファイルが存在することを前提としています。画像を矩形全体に伸ばし、150 ポイントの押し出しを適用し、カメラ回転を度単位で設定します。ファイルを保存またはレンダリングせずにメモリ内で図形を構成します。

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

![正面に写真塗り、側面にオレンジの押し出しを持つ 3D 矩形のレンダリング画像](img_02_04.png)

## **テキストへの 3D 書式設定の適用**

図形の 3D 書式設定は図形本体に影響し、テキストの 3D 書式設定はテキストフレームに影響します。文字自体に押し出し、素材、照明、カメラ設定が必要な WordArt のような効果に便利です。

次の例はオレンジと白の格子パターンのテキストを作成し、上向きのアーチを適用し、[ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) を通じて 3D 設定を構成します。押し出し高さと深さはポイント単位、ライト回転は度単位です。図形の塗りと輪郭は非表示にし、テキストだけが表示されるようにします。例はデフォルトスライドサイズの 2 倍で PNG 画像をレンダリングし、プレゼンテーションを PPTX として保存します。

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

![アーチ状に変形した WordArt、オレンジのパターン塗り、暗い押し出しを持つ 3D テキストのレンダリング画像](img_02_05.png)

## **3D 図形上でテキストを平坦に保つ**

図形の 3D 表現を保持しつつテキストを読みやすくするには、[ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/) 経由で [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) を呼び出します。値が `true` の場合、テキストは 3D シーンから除外されます。`false` の場合、テキストはシーンに参加し、3D 向きに従います。

この設定は図形の 3D 書式設定（カメラ、ライティング、素材、押し出し）を削除しません。これらは [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) を通じて引き続き構成されています。また、通常の回転とは異なります。[IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) はスライド平面上で図形を回転させ、[ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) はテキストのバウンディングボックス内での独自回転を制御します。テキストを 3D シーンから除外しても、これらの角度はリセットされません。

以下の自己完結型例は、テキスト付きの青い矩形を作成し、元の横にクローンします。両方の図形は同じ 3D 書式設定を持ち、テキスト設定だけが異なります：左側は `false`、右側は `true`。カメラ角度は度単位、押し出し高さは 40 ポイントです。例はプレゼンテーションを PPTX として保存し、比較スライドをデフォルトの 2 倍サイズで PNG にレンダリングします。

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

左側はテキストが 3D 向きに従い、右側は平坦で読みやすくなっています。両方の矩形は同じ可視的な押し出しと 3D 向きを保持しています。

![左側が KeepTextFlat が false、右側が true の 2 つの 3D 矩形の比較画像](keep_text_flat.png)

## **エクスポートとレンダリングの動作**

Aspose.Slides は PPTX などの PowerPoint 形式で保存する際に 3D 書式設定を保持します。固定レイアウト形式へレンダリングまたはエクスポートする場合、3D シーンはラスター化または 2D 結果として出力に描画されます。これはスライドを [PNG](/slides/ja/cpp/convert-powerpoint-to-png/) にレンダリングする場合、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/) にエクスポートする場合、[HTML](/slides/ja/cpp/convert-powerpoint-to-html/) にエクスポートする場合、または [video conversion](/slides/ja/cpp/convert-powerpoint-to-video/) 用のフレームを生成する場合に適用されます。

- エクスポートされた画像や PDF はインタラクティブではありません。エクスポート後にオブジェクトを回転させることはできません。
- 最終的な外観はカメラ、ライトリグ、素材、押し出し、塗り、スライドのスケーリングの組み合わせに依存します。
- 継承された値やテーマベースの書式設定値を確認する必要がある場合は、[有効な図形プロパティ](/slides/ja/cpp/shape-effective-properties/) を参照してください。
- 一部の出力形式は編集可能な PowerPoint 3D 書式設定を保存できません。そのような形式では、視覚的な結果がレンダリングされ、編集可能な 3D 設定として保持されません。

## **FAQ**

**Aspose.Slides はインタラクティブな 3D プレゼンテーションを作成できますか？**

Aspose.Slides は図形とテキストに対する PowerPoint の 3D エフェクトを作成およびレンダリングします。エクスポートされた画像、PDF、HTML ページをインタラクティブな 3D シーンにして、ビューアが回転できるようにすることはできません。PPTX では、対応する形式であれば 3D 書式設定は PowerPoint で編集可能なまま残ります。

**3D モデルと 3D エフェクトの違いは何ですか？**

3D モデルはプレゼンテーションに挿入する別個の 3D オブジェクトです。3D エフェクトは通常の PowerPoint 図形やテキストに対して適用する書式設定で、回転、押し出し、ベベル、照明、素材などを指します。この記事は 3D エフェクトについて解説しています。

**見える 3D 図形に必要な設定は何ですか？**

最低でもカメラ回転と押し出しまたは深さを設定します。実務では、ライトリグと素材も設定して、レンダリングされた面に明瞭なハイライトと影を付けることが推奨されます。

**図形とテキストの両方に 3D エフェクトを適用できますか？**

はい。図形本体には [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) を、テキストには [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) を使用します。

**画像、PDF、HTML、ビデオフレームにエクスポートしたときに 3D エフェクトは表示されますか？**

はい。Aspose.Slides はスライド画像、PDF 出力、HTML 出力、ビデオ変換用フレームを作成する際に 3D エフェクトをレンダリングします。エクスポートされた出力にはレンダリングされた外観が含まれますが、編集可能な 3D オブジェクトは含まれません。

**継承やテーマ設定が適用された後の最終的な 3D 値を取得できますか？**

はい。最終的なカメラ、ライトリグ、ベベル、関連する 3D 値を取得するには、[有効な図形プロパティ](/slides/ja/cpp/shape-effective-properties/) で説明されている有効な書式設定 API を使用してください。