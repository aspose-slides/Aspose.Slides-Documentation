---
title: C++ を使用したプレゼンテーションでのテキスト ボックスの管理
linktitle: テキスト ボックスの管理
type: docs
weight: 20
url: /ja/cpp/manage-textbox/
keywords:
- テキストボックス
- テキストフレーム
- テキスト追加
- テキスト更新
- テキストボックス作成
- テキストボックス確認
- テキスト列追加
- ハイパーリンク追加
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションでテキスト ボックスを作成、識別、書式設定、更新します。"
---
## **はじめに**

Aspose.Slides for C++ では、スライドのテキストはシェイプに属するテキストフレームに格納されます。[IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) インターフェイスは最も一般的なテキストを保持するシェイプを表し、そのテキストを [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/get_textframe/) メソッドで取得できます。

{{% alert color="info" title="Note" %}}
すべてのオートシェイプは[IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/)を実装していますが、すべてのシェイプがオートシェイプであるわけでもテキストフレームをサポートしているわけでもありません。既存のプレゼンテーションを処理する際は、シェイプのテキストにアクセスする前に、そのシェイプが[IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/)を実装しているか確認してください。
{{% /alert %}}

## **スライド上にテキスト ボックスを作成する**

テキスト ボックスを作成するには、スライドにオートシェイプを追加し、そのテキストフレームにテキストを追加してプレゼンテーションを保存します。次の例は長方形のテキスト ボックスを作成します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

[IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/addautoshape/) に渡す座標とサイズはポイント単位で測定されます。[IAutoShape::AddTextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/addtextframe/) は指定されたテキストでテキストフレームを初期化します。

## **テキスト ボックス シェイプかどうかを確認する**

[IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/get_istextbox/) メソッドを使用して、オートシェイプがテキスト ボックスとして扱われるかどうかを判断します。プレゼンテーションにテキストを含むオートシェイプと純粋にグラフィックのみのオートシェイプの両方が含まれる場合に便利です。

![テキスト ボックスとシェイプ](istextbox.png)

次の例はプレゼンテーション内のすべてのオートシェイプを検査します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

新たに追加されたオートシェイプは、空でないテキストが含まれるまでテキスト ボックスとはみなされません。そのテキストは[IAutoShape::AddTextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/addtextframe/)または[ITextFrame::set_Text](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/set_text/)で提供できます。空文字列を追加または割り当てると、[IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/get_istextbox/)は`false`を返します：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

最初の 2 つのチェックは `true` を返し、最後の 2 つは `false` を返します。

## **テキストフレームを所有するシェイプを見つける**

汎用的なテキスト処理コードは、どのプレゼンテーションオブジェクトが所有しているか分からないまま[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/)を受け取ることがあります。[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentshape/) メソッドを使用して、所有する[IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/)に戻ってナビゲートします。

オートシェイプや他のテキストを含むシェイプが所有するテキストフレームの場合、[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentshape/)は所有者を返し、[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentcell/)は`nullptr`を返します。両メソッドは読み取り専用のナビゲーションを提供します。アクセスする前に返された値が`nullptr`でないか確認してください。シェイプとテーブルセルの所有者、SmartArt ノードに関連付けられたシェイプの両方を特定するには、[Search and Replace Text](/slides/ja/cpp/search-and-replace-text/) を参照してください。

## **テキスト ボックスに列を追加する**

[ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_columncount/) メソッドはテキストフレームを列に分割し、[ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_columnspacing/) は列間の間隔をポイントで設定します。両メソッドは[ITextFrameFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/)に属し、既存のテキスト ボックスのテキストフレームから呼び出すことができます。テキストは同一シェイプ内で列間で再流しされ、別のシェイプへは続きません。

次の例は、列間 10 ポイントの 3 列テキスト ボックスを作成し、プレゼンテーションを保存して、出力ファイルから保存された設定を読み戻します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **個々の列からテキストを抽出する**

[ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/splittextbycolumns/) を使用して、既存のテキストフレーム内の各視覚列に割り当てられたテキストを取得します。このメソッドは列ごとに 1 つの文字列を、列ベースの読み順で返します。単一列のテキストフレームは要素が 1 つの配列を生成し、空の列は空文字列で表されます。文字列はプレーンテキストのみを含み、部分レベルの書式設定は保持されません。

以下のような場合に便利です：

- 列ベースの読み順を保持しながらテキストを抽出する。
- マルチ列スライドの内容をインデックス付けまたは比較する。
- 各列を別々のファイル、データベースフィールド、または他の宛先にエクスポートする。
- [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_columncount/) や [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_columnspacing/) で列数や間隔を設定した後、またはフォントやテキストフレームのサイズを変更した後に、テキストがどのように再配分されるかを確認する。

このメソッドは現在の[ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/)内に配分されたテキストを返します。別々のシェイプやテキスト ボックス間でテキストが自動的に流れることはありません。列の配分は利用可能なフォントやその他のテキストレイアウト設定に依存する可能性があるため、一貫した結果が重要な場合は必要なフォントが利用可能であることを確認してください。

次の例はプレゼンテーションを読み込み、最初のスライドでテキストフレームを持つ最初のマルチ列オートシェイプを見つけ、その設定された列数を読み取り、各列のテキストを別々のファイルに書き出します。テキストフレームを提供しないシェイプはスキップされます。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **テキストを更新する**

プレゼンテーション全体のテキストを更新するには、スライドとシェイプを順に走査し、オートシェイプを選択してからテキスト部分を編集します。部分レベルで作業することで、テキストと文字書式の両方を変更できます。

次の例は、個々のオートシェイプのテキスト部分内で `years` のすべての出現を `months` に置換し、影響を受けた部分を太字にします。

```cpp
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
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

この走査はオートシェイプ内のテキストのみを更新します。テーブル、チャート、SmartArt、またはグループ化されたシェイプに格納されたテキストを更新するには、これらのオブジェクト固有のコレクションを走査する必要があります。

## **ハイパーリンク付きテキスト ボックスを追加する**

ハイパーリンクは特定のテキスト部分に割り当てることができ、そのテキストだけがクリック可能なリンクとして機能します。[IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) を使用して、部分を外部 URL に関連付けます。

次の例はリンク付きテキストを作成し、プレゼンテーションに保存します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **FAQ**

**テキスト ボックスとマスタまたはレイアウト スライド上のテキスト プレースホルダーの違いは何ですか？**

[placeholder](/slides/ja/cpp/manage-placeholder/) は、[master slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/masterslide/) または [layout slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/layoutslide/) から位置と書式を継承できます。通常のテキスト ボックスは作成されたスライド上の独立したシェイプであり、レイアウトが変更されたときにプレースホルダーの動作を取得しません。

**チャート、テーブル、または SmartArt のテキストを変更せずにテキストを置換するにはどうすればよいですか？**

Update Text の例に示すように、[IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を実装しているシェイプに走査を限定してください。チャート、テーブル、SmartArt はそれぞれ独自のオブジェクトモデルにテキストを保持しているため、このループでは変更されません。