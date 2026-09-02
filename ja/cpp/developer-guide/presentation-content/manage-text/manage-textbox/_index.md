---
title: C++ を使用したプレゼンテーションでのテキスト ボックスの管理
linktitle: テキスト ボックスの管理
type: docs
weight: 20
url: /ja/cpp/manage-textbox/
keywords:
- テキスト ボックス
- テキスト フレーム
- テキストの追加
- テキストの更新
- テキスト ボックスの作成
- テキスト ボックスの確認
- テキスト 列の追加
- ハイパーリンクの追加
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ は、PowerPoint および OpenDocument ファイル内でテキスト ボックスの作成、編集、複製を簡単に行えるようにし、プレゼンテーションの自動化を強化します。"
---
## **導入**

スライド上のテキストは通常、テキスト ボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、テキスト ボックスを追加し、そのテキスト ボックス内にテキストを入れる必要があります。Aspose.Slides for C++ は、テキストを含むシェイプを追加できる [IAutoShape](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_auto_shape) インターフェイスを提供します。

{{% alert title="Info" color="info" %}}
Aspose.Slides では、スライドにシェイプを追加できる [IShape](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_shape) インターフェイスも提供しています。ただし、`IShape` インターフェイスを通じて追加されたすべてのシェイプがテキストを保持できるわけではありません。一方、[IAutoShape](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_auto_shape) インターフェイスを通じて追加されたシェイプはテキストを含むことができます。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
したがって、テキストを追加したいシェイプを扱う場合、そのシェイプが `IAutoShape` インターフェイスを介してキャストされているか確認する必要があります。`IAutoShape` のプロパティである [TextFrame](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.text_frame) を使用できるのはその場合のみです。このページの [Update Text](https://docs.aspose.com/slides/ja/cpp/manage-textbox/#update-text) セクションをご覧ください。 
{{% /alert %}}

## **スライドにテキスト ボックスを作成する**

スライドにテキスト ボックスを作成するには、次の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。 
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。 
3. [IAutoShape](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_auto_shape) オブジェクトを追加し、[ShapeType](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) を `Rectangle` に設定してスライド上の指定位置に配置し、新しく追加された `IAutoShape` オブジェクトへの参照を取得します。 
4. `IAutoShape` オブジェクトにテキストを含む `TextFrame` プロパティを追加します。以下の例では、*Aspose TextBox* というテキストを追加しました。 
5. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。 

この C++ コードは、上記の手順を実装したもので、スライドにテキストを追加する方法を示しています。

```cpp
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
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Presentation をインスタンス化します
auto pres = System::MakeObject<Presentation>();

// プレゼンテーションの最初のスライドを取得します
auto sld = pres->get_Slides()->idx_get(0);

// タイプが Rectangle に設定された AutoShape を追加します
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Rectangle に TextFrame を追加します
ashp->AddTextFrame(u" ");

// テキスト フレームにアクセスします
auto txtFrame = ashp->get_TextFrame();

// テキスト フレーム用の Paragraph オブジェクトを作成します
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Paragraph 用の Portion オブジェクトを作成します
auto portion = para->get_Portions()->idx_get(0);

// テキストを設定します
portion->set_Text(u"Aspose TextBox");

// プレゼンテーションをディスクに保存します
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **テキスト ボックス シェイプの確認**

Aspose.Slides は、[IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) インターフェイスから [get_IsTextBox](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/get_istextbox/) メソッドを提供し、シェイプを調査してテキスト ボックスかどうかを判別できるようにします。

![Text box and shape](istextbox.png)

この C++ コードは、シェイプがテキスト ボックスとして作成されたかどうかを確認する方法を示しています。 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

注意: [IShapeCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/) インターフェイスの `AddAutoShape` メソッドでオートシェイプを追加しただけの場合、そのオートシェイプの `get_IsTextBox` メソッドは `false` を返します。ですが、`AddTextFrame` メソッドまたは `set_Text` メソッドでオートシェイプにテキストを追加すると、`get_IsTextBox` メソッドは `true` を返します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() は false を返します
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() は true を返します

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() は false を返します
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() は true を返します

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() は false を返します
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() は false を返します

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() は false を返します
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() は false を返します
```

## **テキスト フレームを所有するシェイプの検索**

一般的なテキスト処理コードでは、どのプレゼンテーションオブジェクトに含まれているか分からないまま [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) を受け取ることがあります。その所有者である [IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) に戻るには、[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentshape/) を使用します。

[IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) や他のテキストを含むシェイプに属するテキスト フレームの場合、[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentshape/) は所有者シェイプを返し、[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentcell/) は `nullptr` を返します。これらのメソッドは読み取り専用のナビゲーションを提供するため、呼び出しても所有権は変更されません。シェイプにアクセスする前に、返された値が `nullptr` でないことを必ず確認してください。

シェイプやテーブルセルの所有者、さらに SmartArt ノードに関連付けられたシェイプを特定する完全な例については、[Search and Replace Text](/slides/ja/cpp/search-and-replace-text/) を参照してください。

## **テキスト ボックスに列を追加する**

Aspose.Slides は、テキスト ボックスに列を追加できる [set_ColumnCount](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) および [set_ColumnSpacing](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) メソッド（[ITextFrameFormat](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_text_frame_format) インターフェイスおよび [TextFrameFormat](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_text_frame_format) クラスから）を提供します。テキスト ボックスの列数を指定し、列間の間隔（ポイント単位）を設定できます。

この C++ コードは、上記の操作を示しています。 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// プレゼンテーションの最初のスライドを取得します
auto slide = presentation->get_Slides()->idx_get(0);

// タイプを Rectangle に設定した AutoShape を追加します
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Rectangle に TextFrame を追加します
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// TextFrame のテキスト フォーマットを取得します
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// TextFrame の列数を指定します
format->set_ColumnCount(3);

// 列間の間隔を指定します
format->set_ColumnSpacing(10);

// プレゼンテーションを保存します
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **テキスト フレームに列を追加する**

Aspose.Slides for C++ は、テキスト フレームに列を追加できる [set_ColumnCount](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) メソッド（[ITextFrameFormat](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_text_frame_format) インターフェイスから）を提供します。このメソッドを使用して、テキスト フレームの希望する列数を指定できます。

この C++ コードは、テキスト フレーム内に列を追加する方法を示しています：

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **テキストの更新**

Aspose.Slides を使用すると、テキスト ボックス内のテキストやプレゼンテーション全体に含まれるすべてのテキストを変更または更新できます。

この C++ コードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //テキストを変更します
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //書式を変更します
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//変更されたプレゼンテーションを保存します
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **ハイパーリンク付きテキスト ボックスの追加** 

テキスト ボックス内にリンクを挿入できます。テキスト ボックスがクリックされると、ユーザーはそのリンクを開くように誘導されます。

リンクを含むテキスト ボックスを追加するには、次の手順を実行します。

1. `Presentation` クラスのインスタンスを作成します。 
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。 
3. `ShapeType` を `Rectangle` に設定した `AutoShape` オブジェクトをスライド上の指定位置に追加し、新しく追加された AutoShape オブジェクトへの参照を取得します。 
4. `AutoShape` オブジェクトに `TextFrame` を追加し、デフォルト テキストとして *Aspose TextBox* を含めます。 
5. `IHyperlinkManager` クラスのインスタンスを作成します。 
6. `IHyperlinkManager` オブジェクトを、`TextFrame` の希望する部分に対応する [set_HyperlinkClick](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) メソッドに割り当てます。 
7. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。 

この C++ コードは、上記の手順を実装したもので、ハイパーリンク付きテキスト ボックスをスライドに追加する方法を示しています：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
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
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// PPTX を表す Presentation クラスのインスタンスを作成します
auto presentation = System::MakeObject<Presentation>();

// プレゼンテーションの最初のスライドを取得します
auto slide = presentation->get_Slides()->idx_get(0);

// タイプを Rectangle に設定した AutoShape オブジェクトを追加します
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// シェイプを AutoShape にキャストします
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// AutoShape に関連付けられた ITextFrame プロパティにアクセスします
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// フレームにテキストを追加します
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// 部分テキストにハイパーリンクを設定します
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// PPTX プレゼンテーションを保存します
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**マスタースライドを使用する際のテキスト ボックスとテキスト プレースホルダーの違いは何ですか？**

[placeholder](/slides/ja/cpp/manage-placeholder/) は [master](https://reference.aspose.com/slides/ja/cpp/aspose.slides/masterslide/) からスタイル/位置を継承し、[layouts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/layoutslide/) で上書き可能です。一方、通常のテキスト ボックスは特定のスライド上の独立したオブジェクトで、レイアウトを切り替えても変更されません。

**チャート、テーブル、SmartArt 内のテキストに影響を与えずに、プレゼンテーション全体で一括テキスト置換を実行するにはどうすればよいですか？**

テキスト フレームを持つオートシェイプにだけ反復処理を限定し、埋め込みオブジェクト（[charts](https://reference.aspose.com/slides/ja/cpp/aspose.slides.charts/chart/)、[tables](https://reference.aspose.com/slides/ja/cpp/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/ja/cpp/aspose.slides.smartart/smartart/)）はそれぞれのコレクションを別々に走査するか、該当オブジェクトタイプをスキップすることで除外します。