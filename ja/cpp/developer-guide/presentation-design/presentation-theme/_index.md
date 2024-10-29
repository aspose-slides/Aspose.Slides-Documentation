---
title: プレゼンテーション テーマ
type: docs
weight: 10
url: /ja/cpp/presentation-theme/
keywords: "テーマ, PowerPoint テーマ, PowerPoint プレゼンテーション, CPP, C++, Aspose.Slides for C++"
description: "C++ における PowerPoint プレゼンテーションテーマ"
---

プレゼンテーションテーマは、デザイン要素のプロパティを定義します。プレゼンテーションテーマを選択すると、特定のビジュアル要素とそのプロパティのセットを選ぶことになります。

PowerPoint では、テーマは色、[フォント](/slides/ja/cpp/powerpoint-fonts/)、[背景スタイル](/slides/ja/cpp/presentation-background/)、およびエフェクトで構成されます。

![theme-constituents](theme-constituents.png)

## **テーマカラーの変更**

PowerPoint テーマは、スライド上の異なる要素に対して特定のカラーセットを使用します。色が気に入らない場合は、テーマの新しい色を適用して変更できます。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) 列挙型の下に値を提供します。

この C++ コードは、テーマのアクセントカラーを変更する方法を示しています:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

この方法で結果のカラーの実効値を確認できます:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

カラー変更操作をさらに示すために、別の要素を作成し、その要素にアクセントカラー（最初の操作からの）を割り当てます。その後、テーマの色を変更します:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定する**

主要なテーマカラー(1)に対して輝度変換を適用すると、追加パレット(2)から色が形成されます。その後、これらのテーマカラーを設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1**- 主なテーマカラー

**2** - 追加パレットからの色。

この C++ コードは、主要なテーマカラーから追加パレットの色を取得し、形状で使用する操作を示しています:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// アクセント 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// アクセント 4, 明るさ 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// アクセント 4, 明るさ 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// アクセント 4, 明るさ 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// アクセント 4, 暗さ 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// アクセント 4, 暗さ 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

## **テーマフォントの変更**

テーマやその他の目的のためにフォントを選択できるように、Aspose.Slides は次の特別な識別子を使用します（PowerPoint で使用されるものに似ています）：

* **+mn-lt** - ボディフォント ラテン (マイナー ラテン フォント)
* **+mj-lt** - ヘッディングフォント ラテン (メジャー ラテン フォント)
* **+mn-ea** - ボディフォント 東アジア (マイナー 東アジア フォント)
* **+mj-ea** - ボディフォント 東アジア (メジャー 東アジア フォント)

この C++ コードは、テーマ要素にラテンフォントを割り当てる方法を示しています:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"テーマテキストフォーマット");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

この C++ コードは、プレゼンテーションテーマフォントを変更する方法を示しています:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

すべてのテキストボックスのフォントが更新されます。

{{% alert color="primary" title="ヒント" %}} 

[PowerPoint フォント](/slides/ja/cpp/powerpoint-fonts/)をご覧になることをお勧めします。

{{% /alert %}}

## **テーマ背景スタイルの変更**

デフォルトでは、PowerPoint アプリは 12 のプリセット背景を提供していますが、その 12 の背景のうち 3 つだけが一般的なプレゼンテーションに保存されます。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPoint アプリでプレゼンテーションを保存した後、次の C++ コードを実行して、プレゼンテーション内のプリセット背景の数を確認できます:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"テーマの背景塗りつぶしスタイルの数は {0} です", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 

[FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) クラスの [BackgroundFillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) プロパティを使用して、PowerPoint テーマで背景スタイルを追加またはアクセスできます。

{{% /alert %}}

この C++ コードは、プレゼンテーションの背景を設定する方法を示しています:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**インデックスガイド**: 0 は塗りつぶしなしに使用されます。インデックスは1から始まります。

{{% alert color="primary" title="ヒント" %}} 

[PowerPoint 背景](/slides/ja/cpp/presentation-background/)をご覧になることをお勧めします。

{{% /alert %}}

## **テーマ効果の変更**

PowerPoint テーマは通常、各スタイル配列に対して 3 つの値を含みます。これらの配列は、控えめ、中程度、強烈の 3 つのエフェクトに統合されます。たとえば、特定の形状にエフェクトを適用すると、次のような結果になります:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) クラスの 3 つのプロパティ ([FillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) を使用すると、テーマ内の要素を変更できます（PowerPoint のオプションよりも柔軟に）。

この C++ コードは、要素の一部を変更してテーマエフェクトを変更する方法を示しています:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

塗りつぶしの色、塗りつぶしの種類、影の効果などの結果の変更:

![todo:image_alt_text](presentation-design_11.png)