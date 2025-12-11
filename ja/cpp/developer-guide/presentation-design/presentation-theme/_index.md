---
title: C++でプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/cpp/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマエフェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides でプレゼンテーションテーマをマスターし、一貫したブランディングで PowerPoint ファイルを作成、カスタマイズ、変換します。"
---

プレゼンテーション テーマはデザイン要素のプロパティを定義します。テーマを選択すると、実質的に特定のビジュアル要素とそのプロパティのセットを選んでいることになります。

PowerPoint では、テーマは色、[フォント](/slides/ja/cpp/powerpoint-fonts/)、[背景スタイル](/slides/ja/cpp/presentation-background/)、およびエフェクトで構成されます。

![theme-constituents](theme-constituents.png)

## **テーマの色を変更する**

PowerPoint のテーマはスライド上のさまざまな要素に対して特定の色セットを使用します。色が気に入らない場合は、テーマに新しい色を適用して変更できます。新しいテーマカラーを選択できるように、Aspose.Slides は [SchemeColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) 列挙体の値を提供します。

この C++ コードは、テーマのアクセントカラーを変更する方法を示しています:
```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```


次のようにして、結果のカラーの実効値を取得できます:
```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (カラー [A=255, R=128, G=100, B=162])
```


色変更操作をさらに示すために、別の要素を作成し、最初の操作で取得したアクセントカラーを割り当てます。その後、テーマの色を変更します:
```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```


新しい色は両方の要素に自動的に適用されます。

### **追加パレットからテーマカラーを設定する**

メインテーマカラー (1) に輝度変換を適用すると、追加パレット (2) から色が生成されます。これらのテーマカラーを設定および取得できます。

![additional-palette-colors](additional-palette-colors.png)

**1**‑ メインテーマカラー  

**2**‑ 追加パレットからのカラー  

この C++ コードは、メインテーマカラーから取得した追加パレットカラーをシェイプで使用する操作を示しています:
```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// アクセント 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// アクセント 4、明るさ 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// アクセント 4、明るさ 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// アクセント 4、明るさ 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// アクセント 4、暗さ 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// アクセント 4、暗さ 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```


## **テーマのフォントを変更する**

テーマやその他の目的でフォントを選択できるように、Aspose.Slides は PowerPoint で使用されるものと同様の特別な識別子を使用します。

* **+mn-lt** ‑ 本文フォント ラテン文字 (Minor Latin Font)  
* **+mj-lt** ‑ 見出しフォント ラテン文字 (Major Latin Font)  
* **+mn-ea** ‑ 本文フォント 東アジア文字 (Minor East Asian Font)  
* **+mj-ea** ‑ 本文フォント 東アジア文字 (Major East Asian Font)

この C++ コードは、ラテンフォントをテーマ要素に割り当てる方法を示しています:
```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```


この C++ コードは、プレゼンテーション テーマのフォントを変更する方法を示しています:
```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```


すべてのテキスト ボックスのフォントが更新されます。

{{% alert color="primary" title="TIP" %}}  
[PowerPoint フォント](/slides/ja/cpp/powerpoint-fonts/) を参照してください。  
{{% /alert %}}

## **テーマの背景スタイルを変更する**

既定では、PowerPoint アプリは 12 個の事前定義背景を提供しますが、典型的なプレゼンテーションに保存されるのはそのうち 3 個だけです。

![todo:image_alt_text](presentation-design_8.png)

たとえば、PowerPoint アプリでプレゼンテーションを保存した後、次の C++ コードを実行してプレゼンテーション内の事前定義背景の数を取得できます:
```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```


{{% alert color="warning" %}}  
[BackgroundFillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) プロパティを使用し、[FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) クラスから PowerPoint テーマの背景スタイルを追加または取得できます。  
{{% /alert %}}

この C++ コードは、プレゼンテーションの背景を設定する方法を示しています:
```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```


**インデックスガイド**: 0 は塗りなしを表します。インデックスは 1 から開始します。

{{% alert color="primary" title="TIP" %}}  
[PowerPoint 背景](/slides/ja/cpp/presentation-background/) を参照してください。  
{{% /alert %}}

## **テーマのエフェクトを変更する**

PowerPoint のテーマは通常、各スタイル配列に対して 3 つの値を持ちます。これらの配列は、微妙、標準、強度の 3 つのエフェクトに結合されます。たとえば、特定のシェイプにエフェクトを適用した結果は次のとおりです:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) クラスの 3 つのプロパティ ([FillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563)、[LineStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd)、[EffectStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) を使用すると、PowerPoint のオプション以上に柔軟にテーマ内の要素を変更できます。

この C++ コードは、要素の一部を変更してテーマエフェクトを変更する方法を示しています:
```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```


結果として、塗りの色、塗りの種類、影のエフェクトなどが変化します:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**スライド単体にテーマを適用し、マスタを変更せずに済む方法はありますか？**

はい。Aspose.Slides はスライドレベルのテーマ上書きをサポートしているため、マスタ テーマをそのままにして、特定のスライドにローカル テーマを適用できます（[SlideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/slidethememanager/) を使用）。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に移行する最善の方法は何ですか？**

[スライドのクローン](/slides/ja/cpp/clone-slides/) をマスタとともに対象プレゼンテーションへコピーします。これにより、元のマスタ、レイアウト、および関連するテーマが保持され、外観が一貫します。

**すべての継承と上書きの後の「実効」値を確認するにはどうすればよいですか？**

テーマ/カラー/フォント/エフェクト用の API の「実効」ビュー](/slides/ja/cpp/shape-effective-properties/) を使用します。これらは、マスタとローカル上書きを適用した後の最終的に解決されたプロパティを返します。