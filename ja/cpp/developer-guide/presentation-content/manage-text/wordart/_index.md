---
title: C++ で WordArt 効果を作成および適用する
linktitle: WordArt
type: docs
weight: 110
url: /ja/cpp/wordart/
keywords:
- WordArt
- WordArt を作成
- WordArt テンプレート
- WordArt 効果
- 影効果
- 表示効果
- 発光効果
- WordArt 変形
- 3D 効果
- 外部影効果
- 内部影効果
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で WordArt 効果を作成およびカスタマイズします。このステップバイステップ ガイドは、開発者が C++ でプロフェッショナルなテキストを使用してプレゼンテーションを強化するのに役立ちます。"
---

## **WordArt とは?**
WordArt（または Word Art）は、テキストに効果を適用して目立たせることができる機能です。たとえば WordArt を使用すると、テキストに輪郭線を付けたり、カラー（またはグラデーション）で塗りつぶしたり、3D 効果を追加したりできます。また、テキストの形状を傾けたり、曲げたり、伸ばしたりすることもできます。

{{% alert color="primary" %}} 
WordArt は、テキストをグラフィック オブジェクトのように扱うことができます。一般的に、WordArt はテキストをより魅力的または目立たせるために加える効果や特殊な変更から構成されています。 
{{% /alert %}} 

**Microsoft PowerPoint の WordArt**

Microsoft PowerPoint で WordArt を使用するには、あらかじめ定義された WordArt テンプレートのいずれかを選択する必要があります。WordArt テンプレートは、テキストまたはその形状に適用される効果のセットです。

**Aspose.Slides の WordArt**

Aspose.Slides for C++ 20.10 では WordArt のサポートを実装し、以降の Aspose.Slides for C++ リリースで機能の改善を行いました。

Aspose.Slides for C++ を使用すると、C++ で独自の WordArt テンプレート（単一の効果または複数効果の組み合わせ）を簡単に作成し、テキストに適用できます。

## **シンプルな WordArt テンプレートを作成しテキストに適用する**

**Aspose.Slides の使用** 

まず、以下の C++ コードを使用してシンプルなテキストを作成します： 
``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```


次に、以下のコードでテキストのフォント高さを大きく設定し、効果を目立たせます： 
``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```


**Microsoft PowerPoint の使用**

Microsoft PowerPoint の WordArt 効果メニューを開きます： 

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから、あらかじめ定義された WordArt 効果を選択できます。左側のメニューから、新しい WordArt の設定を指定できます。 

これらは利用可能なパラメータまたはオプションの一例です： 

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides の使用**

ここでは、SmallGrid パターンの色をテキストに適用し、幅 1 の黒いテキスト枠線を以下のコードで追加します： 
``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```


結果のテキストは次のとおりです： 

![todo:image_alt_text](image-20200930114108-4.png)

## **その他の WordArt 効果を適用する**

**Microsoft PowerPoint の使用**

プログラムのインターフェイスから、テキスト、テキストブロック、シェイプ、または類似の要素にこれらの効果を適用できます： 

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、影、反射、発光効果はテキストに適用でき、3D フォーマットと 3D 回転効果はテキストブロックに適用できます。Soft Edges プロパティはシェイプ オブジェクトに適用でき（3D フォーマット プロパティが設定されていなくても効果があります）。

### **テキストに影効果を適用する**

ここでは、テキストにのみ関係するプロパティを設定することを意図しています。以下の C++ コードでテキストに影効果を適用します： 
``` cpp 
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

PresetShadow を使用すると、テキストに事前設定された値で影を適用できます。  

**Microsoft PowerPoint の使用**

PowerPoint では 1 種類の影を使用できます。以下に例を示します： 

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides の使用**

Aspose.Slides では、InnerShadow と PresetShadow の 2 種類の影を同時に適用できます。  

注記: 
- OuterShadow と PresetShadow を同時に使用すると、OuterShadow の効果のみが適用されます。 
- OuterShadow と InnerShadow を同時に使用した場合、適用される効果は PowerPoint のバージョンに依存します。たとえば PowerPoint 2013 では効果が二倍になり、PowerPoint 2007 では OuterShadow の効果が適用されます。 

### **反射効果を適用する**

以下の C++ サンプルコードでテキストに反射効果を追加します： 
``` cpp 
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


### **発光効果を適用する**

以下のコードでテキストに発光効果を適用し、光らせます： 
``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```


操作の結果は次のとおりです： 

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
影、表示、発光のパラメータを変更できます。効果のプロパティはテキストの各部分に個別に設定されます。 
{{% /alert %}} 

### **WordArt で変形を使用する**

以下のコードで set_Transform メソッド（テキスト全体に適用される）を使用します： 
``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```


結果は次のとおりです： 

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint と Aspose.Slides for C++ の両方が、あらかじめ定義された変形タイプをいくつか提供しています。 
{{% /alert %}} 

**PowerPoint の使用** 

定義済みの変形タイプにアクセスするには、**書式** → **テキスト効果** → **変形** の順に操作します。 

**Aspose.Slides の使用** 

変形タイプを選択するには、TextShapeType 列挙体を使用します。 

### **テキストとシェイプに 3D 効果を適用する**

以下のサンプルコードでテキストシェイプに 3D 効果を設定します： 
``` cpp 
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


結果のテキストとその形状は次のとおりです： 

![todo:image_alt_text](image-20200930114816-9.png)

以下の C++ コードでテキストに 3D 効果を適用します： 
``` cpp 
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


操作の結果は次のとおりです： 

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
テキストやそのシェイプに 3D 効果を適用する際、および効果同士の相互作用は、特定のルールに基づきます。  

テキストと、そのテキストを含むシェイプのシーンを考えます。3D 効果は 3D オブジェクトの表現と、オブジェクトが配置されるシーンを含みます。  

- 図形とテキストの両方にシーンが設定されている場合、図形のシーンが優先され、テキストのシーンは無視されます。  
- 図形に独自のシーンがなく 3D 表現だけがある場合、テキストのシーンが使用されます。  
- それ以外の場合（シェイプ元々に 3D 効果が無い場合）は、シェイプは平面のままで、3D 効果はテキストのみに適用されます。  

これらの説明は ThreeDFormat.getLightRig() および ThreeDFormat.getCamera() メソッドに関連しています。 
{{% /alert %}} 

## **シェイプに外部影効果を適用する**
Aspose.Slides for C++ は、テキストフレームに含まれるテキストに影効果を適用できる [**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow) および [**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow) クラスを提供します。以下の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに矩形タイプの AutoShape を追加します。  
4. AutoShape に関連付けられた TextFrame にアクセスします。  
5. AutoShape の FillType を NoFill に設定します。  
6. OuterShadow クラスのインスタンスを作成します。  
7. 影の BlurRadius を設定します。  
8. 影の Direction を設定します。  
9. 影の Distance を設定します。  
10. RectanglelAlign を TopLeft に設定します。  
11. 影の PresetColor を Black に設定します。  
12. プレゼンテーションを PPTX ファイルとして書き出します。  

上記手順を実装した C++ のサンプルコードは、テキストに外部影効果を適用する方法を示しています： 
``` cpp
auto pres = System::MakeObject<Presentation>();
// スライドの参照を取得する
auto sld = pres->get_Slides()->idx_get(0);

// 矩形タイプの AutoShape を追加する
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 矩形に TextFrame を追加する
ashp->AddTextFrame(u"Aspose TextBox");

// テキストの影を取得できるようにシェイプの塗りつぶしを無効にする
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 外部影を追加し、すべての必要なパラメータを設定する
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// プレゼンテーションをディスクに保存する
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```


## **シェイプに内部影効果を適用する**
以下の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
2. スライドの参照を取得します。  
3. 矩形タイプの AutoShape を追加します。  
4. InnerShadowEffect を有効にします。  
5. 必要なすべてのパラメータを設定します。  
6. ColorType を Scheme に設定します。  
7. Scheme Color を設定します。  
8. プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き出します。  

上記手順に基づくサンプルコードは、C++ で 2 つのシェイプ間にコネクタを追加する方法を示しています： 
``` cpp
auto presentation = System::MakeObject<Presentation>();
// スライドの参照を取得する
auto slide = presentation->get_Slides()->idx_get(0);

// 矩形タイプの AutoShape を追加する
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 矩形に TextFrame を追加する
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// 内部影効果を有効にする    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// すべての必要なパラメータを設定する
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// ColorType を Scheme に設定する
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Scheme Color を設定する
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// プレゼンテーションを保存する
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**異なるフォントやスクリプト（例: アラビア語、中国語）で WordArt 効果を使用できますか？**  
はい、Aspose.Slides は Unicode をサポートしており、主要なフォントとスクリプトすべてで動作します。影、塗りつぶし、輪郭線などの WordArt 効果は言語に関係なく適用可能ですが、フォントの可用性や描画はシステムフォントに依存する場合があります。

**スライドマスタの要素に WordArt 効果を適用できますか？**  
はい、タイトルプレースホルダー、フッター、背景テキストなど、マスタースライド上のシェイプに WordArt 効果を適用できます。マスターのレイアウトを変更すると、関連するすべてのスライドに反映されます。

**WordArt 効果はプレゼンテーションのファイルサイズに影響しますか？**  
わずかに。影、発光、グラデーション塗りつぶしなどの WordArt 効果は、追加の書式メタデータによりファイルサイズが若干増加する可能性がありますが、差は通常ほとんど無視できる程度です。

**プレゼンテーションを保存せずに WordArt 効果の結果をプレビューできますか？**  
はい、[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) または [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) インターフェイスの `GetImage` メソッドを使用して、WordArt を含むスライドを画像（PNG、JPEG など）にレンダリングできます。これにより、プレゼンテーション全体を保存またはエクスポートする前に、メモリ上または画面上で結果をプレビューできます。