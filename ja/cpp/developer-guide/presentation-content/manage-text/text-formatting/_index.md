---
title: C++ で PowerPoint テキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/cpp/text-formatting/
keywords:
- ハイライトテキスト
- 正規表現
- 段落配置
- テキストスタイル
- テキスト背景
- テキスト透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- 自動調整プロパティ
- テキストフレームアンカー
- テキストタブ
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションでテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---

## **ハイライトテキスト**
新しい HighlightText メソッドが ITextFrame と TextFrame クラスに追加されました。このメソッドは、テキストサンプルを使用して背景色でテキストの一部をハイライトでき、PowerPoint 2019 のテキストハイライトカラー ツールと同様です。

以下のコードスニペットは、この機能の使用方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 
Aspose はシンプルな、[無料のオンライン PowerPoint 編集サービス](https://products.aspose.app/slides/editor) を提供しています
{{% /alert %}} 

## **正規表現を使用したハイライトテキスト**
新しい HighlightRegex メソッドが ITextFrame と TextFrame クラスに追加されました。このメソッドは、正規表現を使用して背景色でテキストの一部をハイライトでき、PowerPoint 2019 のテキストハイライトカラー ツールと同様です。

以下のコードスニペットは、この機能の使用方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **テキストの背景色を設定する**
Aspose.Slides では、テキストの背景色を好きな色に指定できます。

この C++ コードは、テキスト全体の背景色を設定する方法を示しています:
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));
    auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    for (auto&& portion : portions)
    {
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Blue());
    }
    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```


この C++ コードは、テキストの一部だけの背景色を設定する方法を示しています:
```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"Black");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" Red ");

    auto portion3 = System::MakeObject<Portion>(u"Black");
    portion3->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto paragraphPortions = para->get_Portions();
    paragraphPortions->Add(portion1);
    paragraphPortions->Add(portion2);
    paragraphPortions->Add(portion3);
    paragraphs->Add(para);

    pres->Save(u"text.pptx", SaveFormat::Pptx);
}

{
    auto pres = System::MakeObject<Presentation>(u"text.pptx");
    auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slide(0)->get_Shape(0));

	auto predicate = [](System::SharedPtr<IPortion> portion) -> bool {
        return portion->get_Text().Contains(u"Red");
	};

	auto portions = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portions();
    System::SharedPtr<IPortion> redPortion;
	for (auto&& portion : portions)
        if (predicate(portion))
            redPortion = portion;

    redPortion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_Red());

    pres->Save(u"text-red.pptx", SaveFormat::Pptx);
}
```


## **テキスト段落の配置**
テキストの書式設定は、文書やプレゼンテーションを作成する際の重要な要素です。Aspose.Slides for C++ がスライドにテキストを追加できることは既にご存知かと思いますが、本トピックではスライド内のテキスト段落の配置方法をご紹介します。以下の手順に従って Aspose.Slides for C++ でテキスト段落を配置してください。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライド内のプレースホルダー シェイプにアクセスし、AutoShape に型変換します。  
4. AutoShape が公開する TextFrame から、配置したい Paragraph を取得します。  
5. Paragraph を右揃え、左揃え、中央揃え、または両端揃えに設定します。  
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下です。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **テキストの透明度を設定する**
本記事では、Aspose.Slides を使用してテキスト シェイプの透明度プロパティを設定する方法を示します。テキストに透明度を設定するには、以下の手順に従ってください。

1. Presentation クラスのインスタンスを作成します。  
2. スライドの参照を取得します。  
3. 影の色を設定します。  
4. プレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下です。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **テキストの文字間隔を設定する**
Aspose.Slides を使用すると、テキスト ボックス内の文字間隔を設定できます。これにより、文字間のスペースを拡大または縮小して、行やブロックの視覚的密度を調整できます。

この C++ コードは、1 行目の文字間隔を拡大し、別の行の文字間隔を縮小する方法を示しています:
```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // 拡張
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // 縮小

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```


## **テキストフォントプロパティの管理**
プレゼンテーションは通常、テキストと画像の両方を含みます。テキストは、特定のセクションや単語を強調したり、企業スタイルに合わせたりするためにさまざまに書式設定できます。テキストの書式設定は、プレゼンテーション コンテンツの外観や感触を変えるのに役立ちます。本記事では、Aspose.Slides for C++ を使用してスライド上の段落テキストのフォントプロパティを構成する方法を示します。段落のフォントプロパティを管理する手順は以下の通りです。

1. `Presentation` クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライド内のプレースホルダー シェイプにアクセスし、AutoShape に型変換します。  
4. AutoShape が公開する TextFrame から Paragraph を取得します。  
5. Paragraph を両端揃えにします。  
6. Paragraph のテキスト Portion にアクセスします。  
7. FontData を使用してフォントを定義し、Portion のフォントに設定します。  
   - フォントを太字に設定します。  
   - フォントを斜体に設定します。  
8. Portion オブジェクトが公開する FillFormat を使用してフォントの色を設定します。  
9. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下です。未装飾のプレゼンテーションを取得し、1 つのスライドのフォントをフォーマットします。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}

## **テキストのフォント ファミリの管理**
Portion は、段落内で同じ書式スタイルを持つテキストを保持するために使用されます。本記事では、Aspose.Slides for C++ を使用してテキスト ボックスを作成し、特定のフォントおよびフォントファミリ カテゴリのさまざまなプロパティを定義する方法を示します。テキスト ボックスを作成し、その中のテキストにフォントプロパティを設定する手順は以下の通りです。

1. `Presentation` クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに Rectangle 形状の AutoShape を追加します。  
4. AutoShape に関連付けられた塗りつぶしスタイルを削除します。  
5. AutoShape の TextFrame にアクセスします。  
6. TextFrame にテキストを追加します。  
7. TextFrame に関連付けられた Portion オブジェクトにアクセスします。  
8. Portion に使用するフォントを定義します。  
9. Portion が公開するプロパティを使用して、太字、斜体、下線、色、高さなどのその他のフォントプロパティを設定します。  
10. 変更したプレゼンテーションを PPTX ファイルとして保存します。

上記手順の実装例は以下です。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **テキストのフォントサイズを設定する**
Aspose.Slides では、段落内の既存テキストや、後から段落に追加されるテキストに対して、好みのフォントサイズを選択できます。

この C++ コードは、段落に含まれるテキストのフォントサイズを設定する方法を示しています:
```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// 例として最初のシェイプを取得します。
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // 例として最初の段落を取得します。
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // 段落内のすべてのテキスト部分のデフォルトフォントサイズを20ptに設定します。
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // 段落内の現在のテキスト部分のフォントサイズを20ptに設定します。
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **テキストの回転を設定する**
Aspose.Slides for C++ では、開発者がテキストを回転させることができます。テキストは Horizontal、Vertical、Vertical270、WordArtVertical、EastAsianVertical、MongolianVertical、または WordArtVerticalRightToLeft に設定可能です。任意の TextFrame のテキストを回転させる手順は以下の通りです。

1. `Presentation` クラスのインスタンスを作成します。  
2. 最初のスライドにアクセスします。  
3. 任意の Shape をスライドに追加します。  
4. TextFrame にアクセスします。  
5. テキストを回転させます。  
6. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}

## **プレゼンテーション内のタブと EffectiveTabs**
- EffectiveTabs.ExplicitTabCount (本例では 2) プロパティは Tabs.Count と等しいです。  
- EffectiveTabs コレクションには、Tabs コレクションとデフォルトタブのすべてが含まれます。  
- EffectiveTabs.DefaultTabSize (294) プロパティはデフォルトタブ間の距離を示します（本例では 3 と 4 の間）。  
- EffectiveTabs.GetTabByIndex(index) で index=0 は最初の明示タブ (Position = 731)、index=1 は二番目のタブ (Position = 1241) を返します。index=2 以降は最初のデフォルトタブ (Position = 1470) などが返ります。  
- EffectiveTabs.GetTabAfterPosition(pos) は、特定のテキストの後にある次のタブ位置を取得します。例としてテキスト "Helloworld!" がある場合、"world!" を描画開始する位置を求めるには、最初に "Hello" のピクセル長さを算出し、その値で GetTabAfterPosition を呼び出します。次のタブ位置が取得でき、"world!" を描画できます。

## **段落の行間**
Aspose.Slides は `ParagraphFormat` の下にある `SpaceAfter`、`SpaceBefore`、`SpaceWithin` プロパティで段落の行間を管理できます。これらのプロパティは次のように使用します。

* パーセンテージで行間を指定する場合は正の値を使用します。  
* ポイントで行間を指定する場合は負の値を使用します。

例として、`SpaceBefore` プロパティを -16 に設定すると、段落の行間が 16pt になります。

特定の段落の行間を設定する手順は以下の通りです。

1. テキストを含む AutoShape があるプレゼンテーションをロードします。  
2. インデックスでスライドの参照を取得します。  
3. TextFrame にアクセスします。  
4. Paragraph にアクセスします。  
5. Paragraph のプロパティを設定します。  
6. プレゼンテーションを保存します。

この C++ コードは、段落の行間を指定する方法を示しています:
```cpp
// ドキュメントディレクトリへのパス。
System::String dataDir = GetDataPath();

// Presentation クラスのインスタンスを作成
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// インデックスでスライドの参照を取得
auto sld = presentation->get_Slides()->idx_get(0);

// TextFrame にアクセス
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// Paragraph にアクセス
auto para = tf1->get_Paragraphs()->idx_get(0);

// Paragraph のプロパティを設定
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// プレゼンテーションを保存
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```


## **TextFrame の AutofitType プロパティを設定する**
本トピックでは、テキスト フレームのさまざまな書式設定プロパティを検討します。この記事では、テキスト フレームの AutofitType プロパティ、テキストのアンカー、およびプレゼンテーション内のテキスト回転の設定方法を取り上げます。Aspose.Slides for C++ は任意のテキスト フレームの AutofitType プロパティを設定でき、Normal または Shape に設定できます。Normal に設定するとシェイプは変わらずテキストだけが調整され、Shape に設定するとシェイプがテキストに合わせてサイズ変更されます。AutofitType プロパティを設定する手順は以下の通りです。

1. Presentation クラスのインスタンスを作成します。  
2. 最初のスライドにアクセスします。  
3. 任意のシェイプをスライドに追加します。  
4. TextFrame にアクセスします。  
5. TextFrame の AutofitType を設定します。  
6. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}

## **TextFrame のアンカーを設定する**
Aspose.Slides for C++ は任意の TextFrame のアンカー設定をサポートします。TextAnchorType はテキストがシェイプ内で配置される位置を示し、Top、Center、Bottom、Justified、Distributed のいずれかに設定できます。TextFrame のアンカーを設定する手順は以下の通りです。

1. `Presentation` クラスのインスタンスを作成します。  
2. 最初のスライドにアクセスします。  
3. 任意のシェイプをスライドに追加します。  
4. TextFrame にアクセスします。  
5. TextFrame の TextAnchorType を設定します。  
6. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}

## **TextFrame のカスタム回転角度を設定する**
Aspose.Slides for C++ は現在、テキストフレームのカスタム回転角度設定をサポートしています。本トピックでは、例を交えて RotationAngle プロパティの設定方法を紹介します。新しい RotationAngle プロパティは IChartTextBlockFormat と ITextFrameFormat インターフェイスに追加され、テキストフレームのカスタム回転角度を設定できます。RotationAngle プロパティを設定する手順は以下の通りです。

1. Presentation クラスのインスタンスを作成します。  
2. スライドにチャートを追加します。  
3. RotationAngle プロパティを設定します。  
4. プレゼンテーションを PPTX ファイルとして書き出します。

以下の例では RotationAngle プロパティを設定しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **校正言語を設定する**
Aspose.Slides は [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) クラスが公開する [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) プロパティを提供し、PowerPoint 文書の校正言語を設定できます。校正言語は、スペルや文法チェックが行われる言語です。

この C++ コードは、PowerPoint の校正言語を設定する方法を示しています:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```


## **既定言語を設定する**
この C++ コードは、PowerPoint プレゼンテーション全体の既定言語を設定する方法を示しています:
```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// 新しい矩形シェイプをテキスト付きで追加
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// 最初のポーションの言語をチェック
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **既定テキストスタイルを設定する**
プレゼンテーション内のすべてのテキスト要素に同じ既定テキスト書式を一括で適用したい場合は、[IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/) インターフェイスの `get_DefaultTextStyle` メソッドを使用し、好みの書式を設定できます。以下のコード例は、新規プレゼンテーションのすべてのスライドのテキストに、デフォルトで太字 (14 pt) を設定する方法を示しています。
```c++
auto presentation = MakeObject<Presentation>();

// トップレベルの段落フォーマットを取得します。
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **全大文字効果でテキストを抽出する**
PowerPoint では、**All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上で大文字で表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、入力時の文字列がそのまま返されます。対処方法として、[TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) が `All` を示す場合は、返された文字列を大文字に変換して、スライド上の表示と一致させます。

例として、sample2.pptx の最初のスライドに次のテキスト ボックスがあるとします。

![The All Caps effect](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示しています:
```cpp
auto presentation = MakeObject<Presentation>(u"sample2.pptx");
auto autoShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```


出力:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**スライド上のテーブルのテキストを変更する方法は？**

テーブル上のテキストを変更するには、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) オブジェクトを使用します。テーブル内のすべてのセルを反復処理し、各セルのテキスト フレームと段落書式プロパティにアクセスしてテキストを変更できます。

**PowerPoint スライドのテキストにグラデーションカラーを適用する方法は？**

テキストにグラデーションカラーを適用するには、[PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) の `get_FillFormat` メソッドを使用します。`Gradient` に設定し、開始色と終了色、方向、透明度などのプロパティを定義してテキストにグラデーション効果を作成します。