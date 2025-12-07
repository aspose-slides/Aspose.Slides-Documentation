---
title: C++ で 3D プレゼンテーションを作成
linktitle: 3D プレゼンテーション
type: docs
weight: 232
url: /ja/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D プレゼンテーション
- 3D 回転
- 3D 深さ
- 3D 押し出し
- 3D グラデーション
- 3D テキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ でインタラクティブな 3D プレゼンテーションを簡単に作成します。PowerPoint および OpenDocument 形式にすばやくエクスポートでき、汎用的に利用できます。"
---

## **概要**
Aspose.Slides 20.9 以降、PowerPoint の 3D モデルを作成および変更することが可能です。これは、2D シェイプに一連の 3D エフェクトを付与することで実現できます。シェイプにカメラビューを作成することで、軸に沿って回転させることができます。シェイプに押し出しや奥行きを付与すると、2D シェイプが 3D モデルに変換されます。3D シェイプにライト効果を設定したり、マテリアルを変更したりすることで、より立体感を出すことができます。3D モデルの色を 3D グラデーションに変更したり、シェイプの輪郭を修正したり、ベベルを追加したりすると、3D モデルにボリュームが加わります。すべての 3D エフェクトは、PowerPoint の 3D モデルとテキストの両方に適用できます。

以下に、前述のすべての機能を含む 3D モデル作成の最初の例を示します：
``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Matte);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Blue());

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();

presentation->Save(u"sandbox_3d.pptx", Export::SaveFormat::Pptx);
presentation->Dispose();
```


結果として得られる PowerPoint 3D モデル：

![todo:image_alt_text](img_01_01.png)

## **3D 回転**
PowerPoint のシェイプ回転は以下から利用できます：

![todo:image_alt_text](img_02_01.png)

PowerPoint の 3D モデルを回転させるには、シェイプにカメラビューを作成する必要があります。これは[IThreeDFormat.get_Camera()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#ad2f989bd1fd64fd4136e1f17660035d4) メソッドで行います。回転メソッドはカメラ クラスから呼び出され、カメラを回転させるように動作します。実際には、シェイプに対してカメラを相対的に回転させることで、シェイプが 3D 平面上で回転します。
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
// ... 他の 3D シーン パラメータを設定

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


## **3D の深さと押し出し**
PowerPoint の 3D モデルに奥行きと押し出しを追加するには[IThreeDFormat.set_ExtrusionHeight()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#adf0bad4894b1c36d9e4b044ef4978295) メソッドを使用します。押し出しの色を変更するには[IThreeDFormat.get_ExtrusionColor()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#aa7db8859d23a9b4eb2f35f3a42025e9e) メソッドを使用します：
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Purple());
// ... 他の 3D シーン パラメータを設定

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


PowerPoint の奥行きメニュー：

![todo:image_alt_text](img_02_02.png)


## **3D グラデーション**
PowerPoint の 3D モデルに 3D グラデーションを描画するには、[Shape.get_FillFormat().get_GradientFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a1f075336cb7a0e05cd5d7a706b6f4f58) メソッドを使用します：
``` cpp
using namespace Aspose::Slides;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0, System::Drawing::Color::get_Blue());
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, System::Drawing::Color::get_Orange());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_DarkOrange());

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


3D グラデーションが適用された 3D モデル：

![todo:image_alt_text](img_02_03.png)
  
画像グラデーションを作成するには、[Shape.get_FillFormat().get_PictureFillFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#ac01c9a38197ddcd80c180aceeaf155cb) メソッドを使用します：
``` cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
// .. 3D をセットアップ: カメラ、ライトリグ、押し出し

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```



画像グラデーションが適用された 3D モデル：

![todo:image_alt_text](img_02_04.png)

## **3D テキスト (WordArt)**
テキストに回転、押し出し、光、グラデーションを適用して 3D テキスト（WordArt）にするには、[IAutoShape.get_TextFrame().get_TextFrameFormat().get_ThreeDFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5e681109403c2e57aa76a500fe508b30) メソッドにアクセスする必要があります：
``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto imageScale = 2;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(System::Drawing::Color::get_DarkOrange());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(System::Drawing::Color::get_White());
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
// "Arch Up" WordArt の変形エフェクトを設定
textFrameFormat->set_Transform(TextShapeType::ArchUp);

textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

textFrame->get_TextFrameFormat()->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text3d.png");
thumbnail->Dispose();

presentation->Save(u"text3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


3D テキスト（WordArt）の例：

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**プレゼンテーションを画像/PDF/HTML にエクスポートする際、3D エフェクトは保持されますか？**

はい。Slides の 3D エンジンは、サポートされている形式（[images](/slides/ja/cpp/convert-powerpoint-to-png/)、[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)、[HTML](/slides/ja/cpp/convert-powerpoint-to-html/)、など）へエクスポートする際に 3D エフェクトをレンダリングします。

**テーマ、継承などを考慮した「実効的」(最終) 3D パラメータ値を取得できますか？**

はい。Slides は [実効値の読み取り](/slides/ja/cpp/shape-effective-properties/) 用の API を提供しており（3D の照明、ベベルなどを含む）、最終的に適用された設定を確認できます。

**プレゼンテーションをビデオに変換する際、3D エフェクトは機能しますか？**

はい。[ビデオ用フレームを生成](/slides/ja/cpp/convert-powerpoint-to-video/)する際、3D エフェクトは [エクスポートされた画像](/slides/ja/cpp/convert-powerpoint-to-png/) と同様にレンダリングされます。