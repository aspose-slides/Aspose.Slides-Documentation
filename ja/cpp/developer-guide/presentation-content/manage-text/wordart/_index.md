---
title: C++ で WordArt エフェクトを作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/cpp/wordart/
keywords:
- WordArt
- WordArt の作成
- WordArt テンプレート
- WordArt エフェクト
- 影エフェクト
- 表示エフェクト
- 発光エフェクト
- WordArt 変形
- 3D エフェクト
- 外側影エフェクト
- 内側影エフェクト
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で WordArt エフェクトを作成およびカスタマイズします。このステップバイステップ ガイドは、開発者が C++ でプロフェッショナルなテキストを使用してプレゼンテーションを向上させるのに役立ちます。"
---
## **概要**

WordArt エフェクトを使用すると、PowerPoint プレゼンテーションに視覚的に魅力的でスタイライズされたテキストを追加できます。Aspose.Slides を使用すれば、Office をインストールせずに、Microsoft PowerPoint と同様にプログラムで WordArt を作成、カスタマイズ、管理できます。本記事では、文字変形、塗りつぶしスタイル、輪郭、影、その他の書式設定オプションを適用してプレゼンテーションのコンテンツをより表現力豊かに、魅力的にする方法を含め、WordArt の使用概要を提供します。WordArt はテキストをグラフィックオブジェクトとして扱うことができます。テキストに対して適用される効果や特別な修正により、テキストがより目立ちやすくなります。

## **シンプルなWordArtテンプレートの作成とテキストへの適用**

**Aspose.Slides の使用** 

まず、このC++コードを使用してシンプルなテキストを作成します。 

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

次に、効果をより目立たせるために、このコードでテキストのフォント高さを大きく設定します。

``` cpp 
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Microsoft PowerPoint の使用**

Microsoft PowerPoint で WordArt エフェクトメニューに移動します：

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから事前定義された WordArt エフェクトを選択できます。左側のメニューから新しい WordArt の設定を指定できます。

これらは利用可能なパラメータまたはオプションの一部です：

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides の使用**

ここでは、SmallGrid パターンカラーをテキストに適用し、幅 1 の黒いテキスト枠線をこのコードで追加します：

``` cpp 
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

結果のテキスト：

![todo:image_alt_text](image-20200930114108-4.png)

## **他のWordArtエフェクトの適用**

**Microsoft PowerPoint の使用**

プログラムのインターフェイスから、テキスト、テキストブロック、図形、または同様の要素にこれらの効果を適用できます：

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、影、反射、発光効果はテキストに適用でき、3D 書式と 3D 回転効果はテキストブロックに適用でき、ソフトエッジ プロパティは図形オブジェクトに適用できます（3D 書式プロパティが設定されていない場合でも効果があります）。

### **テキストへの影効果の適用**

ここでは、テキストにのみ関係するプロパティを設定することを目的としています。この C++ コードでテキストに影効果を適用します：

``` cpp 
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Aspose.Slides API は、OuterShadow、InnerShadow、PresetShadow の 3 種類の影をサポートしています。

PresetShadow を使用すると、事前定義された値でテキストに影を適用できます。

**Microsoft PowerPoint の使用**

PowerPoint では 1 種類の影しか使用できません。例を示します：

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides の使用**

Aspose.Slides は実際に InnerShadow と PresetShadow の 2 種類の影を同時に適用できます。

**注記:**
- OuterShadow と PresetShadow を同時に使用すると、OuterShadow のみが適用されます。 
- OuterShadow と InnerShadow を同時に使用した場合、適用される効果は PowerPoint のバージョンに依存します。たとえば、PowerPoint 2013 では効果が二重になり、PowerPoint 2007 では OuterShadow が適用されます。

### **反射効果の適用**

この C++ サンプルコードでテキストに反射を追加します：

``` cpp 
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### **発光効果の適用**

このコードを使用してテキストに発光効果を適用し、光らせたり目立たせたりします：

``` cpp 
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

操作の結果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 
影、表示、発光のパラメータを変更できます。効果のプロパティはテキストの各部分に個別に設定されます。 
{{% /alert %}} 

### **WordArtで変形の使用**

このコードでテキスト全体に対して set_Transform メソッド（固有）を使用します：

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

結果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 
Microsoft PowerPoint と Aspose.Slides for C++ の両方が、事前定義された変形タイプをいくつか提供しています。 
{{% /alert %}} 

**PowerPoint の使用**

事前定義された変形タイプにアクセスするには、**Format**->**TextEffect**->**Transform** の順に進みます。

**Aspose.Slides の使用**

変形タイプを選択するには、TextShapeType 列挙体を使用します。

### **テキストと図形への3D効果の適用**

このサンプルコードでテキスト図形に 3D 効果を設定します：

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
autoShape->get_TextFrame()->set_Text(u"Aspose.Slides");

auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

結果のテキストとその形状：

![todo:image_alt_text](image-20200930114816-9.png)

この C++ コードでテキストに 3D 効果を適用します：

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

操作の結果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 
テキストやその形状への 3D 効果の適用および効果間の相互作用は、特定のルールに基づいています。

テキストとそのテキストを含む形状のシーンを考えてみてください。3D 効果は 3D オブジェクトの表現と、オブジェクトが配置されたシーンを含みます。

- 図形とテキストの両方にシーンが設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。 
- 図形に独自のシーンがないが 3D 表現がある場合、テキストのシーンが使用されます。 
- それ以外の場合（形状自体に 3D 効果がない場合）は、形状は平面のままで、3D 効果はテキストにのみ適用されます。 

これらの説明は ThreeDFormat.getLightRig() および ThreeDFormat.getCamera() メソッドに関連しています。 
{{% /alert %}} 

## **図形への外側影効果の適用**
Aspose.Slides for C++ は、テキスト フレームが保持するテキストに影効果を適用できる [**IOuterShadow**](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.effects.i_outer_shadow) および [**IInnerShadow**](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.effects.i_inner_shadow) クラスを提供します。以下の手順に従ってください。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) class.  
2. Obtain the reference of a slide by using its index.  
3. Add an AutoShape of Rectangle type to the slide.  
4. Access the TextFrame associated with the AutoShape.  
5. Set the FillType of the AutoShape to NoFill.  
6. Instantiate OuterShadow class  
7. Set the BlurRadius of the shadow.  
8. Set the Direction of the shadow  
9. Set the Distance of the shadow.  
10. Set the RectanglelAlign to TopLeft.  
11. Set the PresetColor of the shadow to Black.  
12. Write the presentation as a PPTX file.  

この手順を実装した C++ のサンプルコードは、外側影効果をテキストに適用する方法を示しています：

``` cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
// スライドの参照を取得
auto sld = pres->get_Slides()->idx_get(0);

// 矩形タイプの AutoShape を追加
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 矩形に TextFrame を追加
ashp->AddTextFrame(u"Aspose TextBox");

// テキストの影を取得したい場合に備えて、図形の塗りつぶしを無効化
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 外側影を追加し、必要なパラメータをすべて設定
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// プレゼンテーションをディスクに保存
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **図形への内側影効果の適用**
以下の手順に従ってください。

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) class.  
2. Get a reference of the slide.  
3. Add an AutoShape of the Rectangle type.  
4. Enable InnerShadowEffect.  
5. Set all the necessary parameters.  
6. Set the ColorType as Scheme.  
7. Set the Scheme Color.  
8. Write the presentation as a [PPTX](https://docs.fileformat.com/presentation/pptx/) file.  

この手順に基づくサンプルコードは、C++ で 2 つの図形間にコネクタを追加する方法を示しています：

``` cpp
#include <DOM/ColorType.h>
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// スライドの参照を取得
auto slide = presentation->get_Slides()->idx_get(0);

// 矩形タイプの AutoShape を追加
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 矩形に TextFrame を追加
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// InnerShadowEffect を有効化    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// 必要なすべてのパラメータを設定
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// ColorType を Scheme に設定
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Scheme カラーを設定
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// プレゼンテーションを保存
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **よくある質問**

### WordArt エフェクトは異なるフォントやスクリプト（例：アラビア語、中文）で使用できますか？

はい、Aspose.Slides は Unicode をサポートしており、主要なフォントとスクリプトすべてで動作します。影、塗りつぶし、輪郭などの WordArt エフェクトは言語に関係なく適用できますが、フォントの可用性とレンダリングはシステム フォントに依存する場合があります。

### スライド マスター要素に WordArt エフェクトを適用できますか？

はい、マスタースライド上のタイトル プレースホルダー、フッター、背景テキストなどの図形に WordArt エフェクトを適用できます。マスター レイアウトに加えた変更は、関連付けられたすべてのスライドに反映されます。

### WordArt エフェクトはプレゼンテーション ファイルのサイズに影響しますか？

わずかに影響します。影、発光、グラデーション塗りつぶしなどのエフェクトは、追加の書式設定メタデータが加わるためファイル サイズが若干増加しますが、差は通常は無視できる程度です。

### プレゼンテーションを保存せずに WordArt エフェクトの結果をプレビューできますか？

はい、[IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides.ishape/) または [ISlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides.islide/) インターフェイスの `GetImage` メソッドを使用して、WordArt を含むスライドを画像（PNG、JPEG など）にレンダリングできます。これにより、プレゼンテーション全体を保存またはエクスポートする前に、メモリ内または画面上で結果をプレビューできます。