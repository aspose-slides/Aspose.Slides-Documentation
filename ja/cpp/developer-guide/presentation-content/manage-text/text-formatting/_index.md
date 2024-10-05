---
title: テキストフォーマット
type: docs
weight: 50
url: /cpp/text-formatting/
keywords:
- ハイライトテキスト
- 正規表現
- テキスト段落の配置
- テキスト透明度
- 段落フォントプロパティ
- フォントファミリー
- テキスト回転
- カスタム角度回転
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ
- デフォルトテキストスタイル
- C++
- Aspose.Slides for .C++
description: "C++でテキストとテキストフレームのプロパティを管理および操作する"
---

## **ハイライトテキスト**
新しいHighlightTextメソッドがITextFrameおよびTextFrameクラスに追加されました。このメソッドは、PowerPoint 2019のテキストハイライトツールに似て、テキストサンプルを使用して背景色でテキストの一部をハイライトすることを可能にします。

以下のコードスニペットは、この機能を使用する方法を示しています：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightText-HighlightText.cpp" >}}

{{% alert color="primary" %}} 

Asposeはシンプルで、[無料のオンラインPowerPoint編集サービス](https://products.aspose.app/slides/editor)を提供しています。

{{% /alert %}} 

## **正規表現を使用したハイライトテキスト**
新しいHighlightRegexメソッドがITextFrameおよびTextFrameクラスに追加されました。このメソッドは、PowerPoint 2019のテキストハイライトツールに似て、正規表現を使用して背景色でテキストの一部をハイライトすることを可能にします。

以下のコードスニペットは、この機能を使用する方法を示しています：

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HighlightTextUsingRegx-HighlightTextUsingRegx.cpp" >}}

## **テキストの背景色を設定する**

Aspose.Slidesは、テキストの背景に対して好みの色を指定することを可能にします。

このC++コードは、全体のテキストに対して背景色を設定する方法を示しています：

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);
    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"ブラック");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" 赤 ");

    auto portion3 = System::MakeObject<Portion>(u"ブラック");
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

このC++コードは、テキストの一部にのみ背景色を設定する方法を示しています：

```c++
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IAutoShape> autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 200.0f, 100.0f);

    auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
    paragraphs->Clear();
    System::SharedPtr<Paragraph> para = System::MakeObject<Paragraph>();
    auto portion1 = System::MakeObject<Portion>(u"ブラック");
    portion1->get_PortionFormat()->set_FontBold(NullableBool::True);

    auto portion2 = System::MakeObject<Portion>(u" 赤 ");

    auto portion3 = System::MakeObject<Portion>(u"ブラック");
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
        return portion->get_Text().Contains(u"赤");
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
テキストフォーマットは、あらゆる種類の文書やプレゼンテーションを作成する際の重要な要素の1つです。Aspose.Slides for C++はスライドにテキストを追加することをサポートしていますが、このトピックでは、スライド内のテキスト段落の配置を制御する方法を見ていきます。Aspose.Slides for C++を使用してテキスト段落を配置するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内のプレースホルダーシェイプにアクセスし、AutoShapeとして型キャストします。
4. AutoShapeによって公開されたTextFrameから配置が必要な段落を取得します。
5. 段落を配置します。段落は、右、左、中央、両端揃えに配置できます。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

上記の手順の実装は以下に示されています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ParagraphsAlignment-ParagraphsAlignment.cpp" >}}

## **テキストの透明度を設定する**
この記事では、Aspose.Slidesを使用して任意のテキストシェイプに透明度プロパティを設定する方法を示します。テキストに透明度を設定するには、以下の手順に従ってください：

1. Presentationクラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. シャドウカラーを設定します。
4. プレゼンテーションをPPTXファイルとして書き込みます。

上記の手順の実装は以下に示されています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransparencyOfTextInShadow-SetTransparencyOfTextInShadow.cpp" >}}

## **テキストの文字間隔を設定する**

Aspose.Slidesでは、テキストボックス内の文字間の間隔を設定することができます。このようにして、文字間のスペースを広げたり凝縮したりすることで、行またはテキストブロックの視覚密度を調整することができます。

このC++コードは、1行のテキストの間隔を広げ、別の行の間隔を凝縮する方法を示しています：

```c++
auto presentation = System::MakeObject<Presentation>(u"in.pptx");

auto slide = presentation->get_Slides()->idx_get(0);
auto textBox1 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(0));
auto textBox2 = System::ExplicitCast<IAutoShape>(slide->get_Shapes()->idx_get(1));

textBox1->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(20.0f); // 拡大
textBox2->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(-2.0f); // 凝縮

presentation->Save(u"out.pptx", SaveFormat::Pptx);
```

## **段落のフォントプロパティを管理する**

プレゼンテーションには通常、テキストと画像の両方が含まれます。テキストは、特定のセクションや単語を強調するため、または企業スタイルに準拠するために、さまざまな方法でフォーマットできます。テキストフォーマットは、プレゼンテーションコンテンツの見た目と雰囲気を変えるのに役立ちます。この記事では、Aspose.Slides for C++を使用して、スライド上のテキスト段落のフォントプロパティを設定する方法を示します。Aspose.Slides for C++を使用して段落のフォントプロパティを管理するには：

1. `Presentation`クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内のプレースホルダーシェイプにアクセスし、AutoShapeに型キャストします。
4. AutoShapeによって公開されたTextFrameから段落を取得します。
5. 段落を両端揃えします。
6. 段落のテキストポーションにアクセスします。
7. FontDataを使用してフォントを定義し、テキストポーションのフォントをそれに応じて設定します。
   1. フォントを太字に設定します。
   2. フォントをイタリックに設定します。
8. ポーションオブジェクトによって公開されたFillFormatを使用してフォントカラーを設定します。
9. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

上記の手順の実装は以下に示されています。これにより、素朴なプレゼンテーションが取得され、そのうちの1つのスライドのフォントがフォーマットされます。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontProperties-FontProperties.cpp" >}}

## **テキストのフォントファミリーを管理する**
ポーションは、段落内の同じフォーマットスタイルを持つテキストを保持するために使用されます。この記事では、Aspose.Slides for C++を使用していくつかのテキストを持つテキストボックスを作成し、特定のフォントやフォントファミリーカテゴリーのさまざまな他のプロパティを定義する方法を示します。テキストボックスを作成し、その中のテキストのフォントプロパティを設定するには：

1. `Presentation`クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに長方形タイプのAutoShapeを追加します。
4. AutoShapeに関連付けられた塗りつぶしスタイルを削除します。
5. AutoShapeのTextFrameにアクセスします。
6. TextFrameにテキストを追加します。
7. TextFrameに関連付けられたポーションオブジェクトにアクセスします。
8. ポーションに使用するフォントを定義します。
9. ポーションオブジェクトによって公開された関連プロパティを使用して太字、イタリック、下線、色、高さなどの他のフォントプロパティを設定します。
10. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

上記の手順の実装は以下に示されています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTextFontProperties-SetTextFontProperties.cpp" >}}

## **テキストのフォントサイズを設定する**

Aspose.Slidesは、段落内の既存のテキストに対して好みのフォントサイズを選択し、後で段落に追加される可能性のある他のテキストに対しても選択することを可能にします。

このC++コードは、段落内のテキストのフォントサイズを設定する方法を示しています：

```c++
auto presentation = System::MakeObject<Presentation>(u"example.pptx");

// 最初のシェイプを取得します。
auto shape = presentation->get_Slide(0)->get_Shape(0);
if (System::ObjectExt::Is<IAutoShape>(shape))
{
    auto autoShape = System::ExplicitCast<IAutoShape>(shape);

    // 最初の段落を取得します。
    auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
    // 段落内のすべてのテキストポーションのデフォルトフォントサイズを20ptに設定します。
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20.0f);
    // 段落内の現在のテキストポーションのフォントサイズを20ptに設定します。
    for (auto&& portion : paragraph->get_Portions())
    {
        portion->get_PortionFormat()->set_FontHeight(20.0f);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **テキストの回転を設定する**

Aspose.Slides for C++は、開発者がテキストを回転させることを可能にします。テキストは、水平、垂直、270度垂直、WordArt垂直、東アジア垂直、モンゴル垂直、またはWordArt右から左に表示を指定できます。任意のTextFrameのテキストを回転させるには、以下の手順に従ってください。

1. `Presentation`クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. TextFrameにアクセスします。
5. テキストを回転させます。
6. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RotatingText-RotatingText.cpp" >}}

## **プレゼンテーションのタブとEffectiveTabs**
- EffectiveTabs.ExplicitTabCount (私たちのケースでは2)プロパティはTabs.Countに等しいです。
- EffectiveTabsコレクションには、すべてのタブ（Tabsコレクションとデフォルトタブ）が含まれます。
- EffectiveTabs.ExplicitTabCount (私たちのケースでは2)プロパティはTabs.Countに等しいです。
- EffectiveTabs.DefaultTabSize (294)プロパティは、デフォルトタブ間の距離（例では3と4）を示します。
- EffectiveTabs.GetTabByIndex(index)は、index = 0で最初の明示的なタブ(Position = 731)を返し、index = 1で2番目のタブ(Position = 1241)を返します。index = 2で次のタブを取得しようとすると、最初のデフォルトタブ(Position = 1470)が返されます。
- EffectiveTabs.GetTabAfterPosition(pos)は、テキストの後に次のタブを取得するために使用されます。たとえば、テキストが"Helloworld!"の場合。このようなテキストをレンダリングするには、"world!"を描画する開始位置を知っておく必要があります。最初に、"Hello"のピクセル単位の長さを計算し、この値でGetTabAfterPositionを呼び出します。次のタブ位置を取得して"world!"を描画します。

## **段落の行間**

Aspose.Slidesは、段落の行間を管理できる`ParagraphFormat`のプロパティを提供します：`SpaceAfter`、`SpaceBefore`、および`SpaceWithin`。これらの3つのプロパティは、次のように使用されます：

* 段落の行間をパーセントで指定するには、正の値を使用します。
* 段落の行間をポイントで指定するには、負の値を使用します。

たとえば、`SpaceBefore`プロパティを-16に設定することで、段落に16ポイントの行間を適用できます。

特定の段落の行間を指定する方法は次のとおりです：

1. いくつかのテキストを含むAutoShapeを含むプレゼンテーションをロードします。
2. インデックスを介してスライドの参照を取得します。
3. TextFrameにアクセスします。
4. 段落にアクセスします。
5. 段落のプロパティを設定します。
6. プレゼンテーションを保存します。

このC++コードは、段落の行間を指定する方法を示しています：

``` cpp
// ドキュメントディレクトリへのパス
System::String dataDir = GetDataPath();

// Presentationクラスのインスタンスを作成
auto presentation = System::MakeObject<Presentation>(dataDir + u"Fonts.pptx");

// インデックスを介してスライドの参照を取得
auto sld = presentation->get_Slides()->idx_get(0);

// TextFrameにアクセス
auto tf1 = (System::ExplicitCast<IAutoShape>(sld->get_Shapes()->idx_get(0)))->get_TextFrame();

// 段落にアクセス
auto para = tf1->get_Paragraphs()->idx_get(0);

// 段落のプロパティを設定
para->get_ParagraphFormat()->set_SpaceWithin(80.0f);
para->get_ParagraphFormat()->set_SpaceBefore(40.0f);
para->get_ParagraphFormat()->set_SpaceAfter(40.0f);

// プレゼンテーションを保存
presentation->Save(dataDir + u"LineSpacing_out.pptx", SaveFormat::Pptx);
```

## **テキストフレームのオートフィットタイププロパティを設定する**
このトピックでは、テキストフレームのさまざまなフォーマットプロパティを探ります。この記事では、テキストフレームのオートフィットタイププロパティ、テキストのアンカー、プレゼンテーション内のテキストの回転を設定する方法について説明します。Aspose.Slides for C++では、任意のテキストフレームのオートフィットタイププロパティを設定することができます。オートフィットタイプは、ノーマルまたはシェイプに設定できます。ノーマルに設定されている場合、シェイプはそのままで、テキストはシェイプが変更されることなく調整されます。しかし、オートフィットタイプがシェイプに設定されている場合、シェイプは必要なテキストのみが含まれるように変更されます。テキストフレームのオートフィットタイププロパティを設定するには、以下の手順に従ってください。

1. Presentationクラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. TextFrameにアクセスします。
5. TextFrameのオートフィットタイプを設定します。
6. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAutofitOftextframe-SetAutofitOftextframe.cpp" >}}

## **テキストフレームのアンカーを設定する**
Aspose.Slides for C++では、任意のTextFrameのアンカーを設定することができます。TextAnchorTypeは、シェイプ内でそのテキストがどこに配置されるかを指定します。TextAnchorTypeは、トップ、センター、ボトム、両端揃えまたは分配に設定できます。任意のTextFrameのアンカーを設定するには、以下の手順に従ってください：

1. `Presentation`クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意のシェイプを追加します。
4. TextFrameにアクセスします。
5. TextFrameのTextAnchorTypeを設定します。
6. ファイルをディスクに保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAnchorOfTextFrame-SetAnchorOfTextFrame.cpp" >}}

## **テキストフレームのカスタム回転角度を設定する**
Aspose.Slides for C++は、テキストフレームのカスタム回転角度の設定をサポートします。このトピックでは、Aspose.SlidesでRotationAngleプロパティを設定する方法を説明します。新しいプロパティRotationAngleは、IChartTextBlockFormatおよびITextFrameFormatインターフェイスに追加され、テキストフレームのカスタム回転角度を設定できるようになりました。RotationAngleプロパティを設定するには、以下の手順に従ってください：

1. Presentationクラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. RotationAngleプロパティを設定します。
4. プレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、RotationAngleプロパティを設定します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomRotationAngleTextframe-CustomRotationAngleTextframe.cpp" >}}

## **校正言語を設定する**

Aspose.Slidesは、PowerPoint文書に対して校正言語を設定できるようにする[LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/)プロパティを提供しています。校正言語は、PowerPointでスペルや文法がチェックされる言語です。

このC++コードは、PowerPointの校正言語を設定する方法を示します：

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
// 校正言語のIDを設定します。

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **デフォルト言語を設定する**

このC++コードは、PowerPointプレゼンテーション全体のデフォルト言語を設定する方法を示します：

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// テキストを含む新しい長方形シェイプを追加
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"新しいテキスト");

// 最初のポーションの言語をチェック
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **デフォルトテキストスタイルを設定する**

プレゼンテーションのすべてのテキスト要素に一度に同じデフォルトのテキストフォーマットを適用する必要がある場合は、[IPresentation](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/)インターフェイスから`get_DefaultTextStyle`メソッドを使用して好みのフォーマットを設定できます。以下のコード例は、新しいプレゼンテーション内のすべてのスライドのテキストに対してデフォルトの太字フォント（14pt）を設定する方法を示しています。

```c++
auto presentation = MakeObject<Presentation>();

// 最上位の段落フォーマットを取得します。
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != NULL) {
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"DefaultTextStyle.pptx", SaveFormat::Pptx);
presentation->Dispose();
```