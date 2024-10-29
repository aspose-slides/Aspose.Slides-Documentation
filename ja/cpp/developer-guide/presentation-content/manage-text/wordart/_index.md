---
title: WordArt
type: docs
weight: 110
url: /ja/cpp/wordart/
---

## **WordArtとは？**
WordArtは、テキストに効果を適用して目立たせる機能です。たとえば、WordArtを使用すると、テキストにアウトラインを追加したり、色（またはグラデーション）で塗りつぶしたり、3D効果を追加したりできます。また、テキストの形を歪めたり、曲げたり、引き伸ばしたりすることもできます。

{{% alert color="primary" %}} 

WordArtを使用すると、テキストをグラフィカルオブジェクトのように扱うことができます。一般的に、WordArtは、テキストをより魅力的または目立つようにするために加えられた効果や特別な修正の集合です。

{{% /alert %}} 

**Microsoft PowerPointにおけるWordArt**

Microsoft PowerPointでWordArtを使用するには、定義済みのWordArtテンプレートのいずれかを選択する必要があります。WordArtテンプレートは、テキストまたはその形状に適用される効果のセットです。

**Aspose.SlidesにおけるWordArt**

Aspose.Slides for C++ 20.10では、WordArtのサポートを実装し、その機能を後続のAspose.Slides for C++リリースで改善しました。

Aspose.Slides for C++を使用すると、自分自身のWordArtテンプレート（効果または効果の組み合わせ）をC++で簡単に作成し、テキストに適用できます。

## 簡単なWordArtテンプレートを作成し、テキストに適用する

**Aspose.Slidesを使用して**

最初に、このC++コードを使用して簡単なテキストを作成します：

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

次に、テキストのフォント高さを大きな値に設定して、このコードを通じて効果をより目立たせます：

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Microsoft PowerPointを使用して**

Microsoft PowerPointのWordArt効果メニューに移動します：

![todo:image_alt_text](image-20200930113926-1.png)

右側のメニューから、定義済みのWordArt効果を選択できます。左側のメニューからは、新しいWordArtの設定を指定することができます。

これらは利用可能なパラメータやオプションの一部です：

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slidesを使用して**

ここでは、SmallGridパターンカラーをテキストに適用し、幅1の黒いテキストボーダーを追加するこのコードを使用します：

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

結果のテキスト：

![todo:image_alt_text](image-20200930114108-4.png)

## 他のWordArt効果を適用する

**Microsoft PowerPointを使用して**

プログラムのインターフェースから、テキスト、テキストブロック、形状、または類似の要素にこれらの効果を適用できます：

![todo:image_alt_text](image-20200930114129-5.png)

たとえば、シャドウ、反射、グロウ効果をテキストに適用できます。また、3Dフォーマットと3D回転効果をテキストブロックに適用できます。ソフトエッジプロパティは、Shape Objectに適用できます（3Dフォーマットプロパティが設定されていなくても効果があります）。

### シャドウ効果の適用

ここでは、テキストのみに関するプロパティを設定することを意図しています。このコードをC++で使用して、テキストにシャドウ効果を適用します：

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

Aspose.Slides APIは、OuterShadow、InnerShadow、PresetShadowの3種類のシャドウをサポートしています。

PresetShadowを使用すると、テキストにシャドウを適用できます（プリセット値を使用します）。

**Microsoft PowerPointを使用して**

PowerPointでは、1種類のシャドウを使用できます。以下はその例です：

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slidesを使用して**

Aspose.Slidesでは、実際にInnerShadowとPresetShadowの2種類のシャドウを同時に適用できます。

**注意事項：**

- OuterShadowとPresetShadowを一緒に使用すると、OuterShadow効果のみが適用されます。
- OuterShadowとInnerShadowを同時に使用すると、結果または適用される効果はPowerPointのバージョンに依存します。たとえば、PowerPoint 2013では効果が重複します。しかし、PowerPoint 2007ではOuterShadow効果が適用されます。

### テキストへの表示の適用

このC++コードサンプルを使用して、テキストに表示を追加します：

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

### テキストへのグロウ効果の適用

このコードを使用して、テキストにグロウ効果を適用し、輝かせたり目立たせたりします：

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

操作の結果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

シャドウ、表示、グロウのパラメータを変更できます。効果のプロパティは、テキストの各部分に別々に設定されます。

{{% /alert %}} 

### WordArtでの変形の使用

このコードを通じて、set_Transformメソッド（テキスト全体のブロックに内在）を使用します：

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

結果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPointとAspose.Slides for C++は、特定の数の定義済み変形タイプを提供します。

{{% /alert %}} 

**PowerPointを使用して**

定義済みの変形タイプにアクセスするには、**フォーマット** -> **テキスト効果** -> **変形**を選択します。

**Aspose.Slidesを使用して**

変形タイプを選択するには、TextShapeType列挙型を使用します。

### テキストと形状への3D効果の適用

このサンプルコードを使用して、テキスト形状に3D効果を設定します：

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

結果のテキストとその形状：

![todo:image_alt_text](image-20200930114816-9.png)

このC++コードを使用して、テキストに3D効果を適用します：

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

操作の結果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

テキストやその形状への3D効果の適用および効果間の相互作用は、特定のルールに基づいています。

テキストとそのテキストを含む形状のシーンを考慮してください。3D効果は、3Dオブジェクトの表現と、そのオブジェクトが配置されたシーンを含みます。

- 形状とテキストの両方にシーンが設定されている場合、形状シーンの優先度が高く、テキストシーンは無視されます。
- 形状に独自のシーンがなくても3D表現がある場合、テキストシーンが使用されます。
- それ以外の場合（形状に元々3D効果がない場合）、形状は平坦で、3D効果はテキストのみに適用されます。

これらの説明は、ThreeDFormat.getLightRig()およびThreeDFormat.getCamera()メソッドに関連しています。

{{% /alert %}} 

## **テキストへの外側のシャドウ効果を適用する**
Aspose.Slides for C++は、テキストをTextFrameで運ぶためにシャドウ効果を適用するための[**IOuterShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_outer_shadow)および[**IInnerShadow**](https://reference.aspose.com/slides/cpp/class/aspose.slides.effects.i_inner_shadow)クラスを提供しています。これらの手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに矩形型のAutoShapeを追加します。
4. AutoShapeに関連するTextFrameにアクセスします。
5. AutoShapeのFillTypeをNoFillに設定します。
6. OuterShadowクラスをインスタンス化します。
7. シャドウのBlurRadiusを設定します。
8. シャドウのDirectionを設定します。
9. シャドウのDistanceを設定します。
10. RectanglelAlignをTopLeftに設定します。
11. シャドウのPresetColorをBlackに設定します。
12. プレゼンテーションをPPTXファイルとして書き込みます。

次のC++のサンプルコードは、上記の手順の実装であり、テキストに外側のシャドウ効果を適用する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>();
// スライドの参照を取得
auto sld = pres->get_Slides()->idx_get(0);

// 矩形型のAutoShapeを追加
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 矩形にTextFrameを追加
ashp->AddTextFrame(u"Aspose TextBox");

// テキストのシャドウを取得する場合に備えてシェイプの塗りつぶしを無効にする
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 外側のシャドウを追加し、必要なすべてのパラメータを設定
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

## **形状に内側のシャドウ効果を適用する**
これらの手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 矩形型のAutoShapeを追加します。
4. InnerShadowEffectを有効にします。
5. 必要なすべてのパラメータを設定します。
6. ColorTypeをSchemeに設定します。
7. Scheme Colorを設定します。
8. プレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き込みます。

次のサンプルコード（上記の手順に基づく）は、C++で2つの形状間にコネクタを追加する方法を示しています：

``` cpp
auto presentation = System::MakeObject<Presentation>();
// スライドの参照を取得
auto slide = presentation->get_Slides()->idx_get(0);

// 矩形型のAutoShapeを追加
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// 矩形にTextFrameを追加
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// InnerShadowEffectを有効にする    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// 必要なすべてのパラメータを設定
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// ColorTypeをSchemeとして設定
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Scheme Colorを設定
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// プレゼンテーションを保存
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```