---
title: C++ を使用したプレゼンテーションでのテキスト ボックスの管理
linktitle: テキスト ボックスの管理
type: docs
weight: 20
url: /ja/cpp/manage-textbox/
keywords:
- テキスト ボックス
- テキスト フレーム
- テキストを追加
- テキストを更新
- テキスト ボックスを作成
- テキスト ボックスを確認
- テキスト列を追加
- ハイパーリンクを追加
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ は、PowerPoint および OpenDocument ファイル内のテキスト ボックスを簡単に作成、編集、クローンでき、プレゼンテーションの自動化を強化します。"
---

スライド上のテキストは通常、テキスト ボックスまたは図形に存在します。そのため、スライドにテキストを追加するには、まずテキスト ボックスを追加し、そのテキスト ボックスにテキストを入力する必要があります。Aspose.Slides for C++ は、テキストを含む図形を追加できる [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) インターフェイスを提供します。

{{% alert title="Info" color="info" %}}
Aspose.Slides は、スライドに図形を追加できる [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) インターフェイスも提供します。ただし、`IShape` インターフェイスから追加されたすべての図形がテキストを保持できるわけではありません。テキストを含めることができるのは、[IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) インターフェイスから追加された図形だけです。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
したがって、テキストを追加したい図形を扱う場合は、`IAutoShape` インターフェイスにキャストされていることを確認する必要があります。`IAutoShape` であることが確認できて初めて、`IAutoShape` のプロパティである [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame) を操作できます。このページの [Update Text](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) セクションをご参照ください。 
{{% /alert %}}

## **スライドにテキスト ボックスを作成する**

テキスト ボックスをスライドに作成する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に `ShapeType` を `Rectangle` に設定した [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) オブジェクトを追加し、追加された `IAutoShape` オブジェクトへの参照を取得します。  
4. `IAutoShape` オブジェクトにテキストを含む `TextFrame` プロパティを追加します。以下の例では、*Aspose TextBox* というテキストを追加しています。  
5. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。  

以下の C++ コードは、上記手順を実装したもので、スライドにテキストを追加する方法を示しています。
```cpp
// プレゼンテーションのインスタンス化
auto pres = System::MakeObject<Presentation>();

// プレゼンテーションの最初のスライドを取得
auto sld = pres->get_Slides()->idx_get(0);

// タイプを Rectangle に設定した AutoShape を追加
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Rectangle に TextFrame を追加
ashp->AddTextFrame(u" ");

// テキストフレームにアクセス
auto txtFrame = ashp->get_TextFrame();

// テキストフレーム用の Paragraph オブジェクトを作成
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Paragraph 用の Portion オブジェクトを作成
auto portion = para->get_Portions()->idx_get(0);

// テキストを設定
portion->set_Text(u"Aspose TextBox");

// プレゼンテーションをディスクに保存
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```


## **テキスト ボックス形状かどうかを確認する**

Aspose.Slides は、[IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) インターフェイスの [get_IsTextBox](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_istextbox/) メソッドを提供しており、図形を調べてテキスト ボックスかどうかを判別できます。

![Text box and shape](istextbox.png)

以下の C++ コードは、図形がテキスト ボックスとして作成されたかどうかを確認する方法を示しています。 
```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
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


`IShapeCollection` インターフェイスの `AddAutoShape` メソッドで自動図形を追加しただけの場合、`get_IsTextBox` メソッドは `false` を返します。ただし、`AddTextFrame` メソッドまたは `set_Text` メソッドで自動図形にテキストを追加した後は、`get_IsTextBox` メソッドは `true` を返します。
```cpp
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


## **テキスト ボックスに列を追加する**

Aspose.Slides は、[ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) インターフェイスおよび [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) クラスの [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) および [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) メソッドを提供しています。これらを使用して、テキスト ボックスに列数と列間のポイント単位の間隔を指定できます。

以下の C++ コードは、上述の操作を実演しています。 
```cpp
auto presentation = System::MakeObject<Presentation>();
// プレゼンテーションの最初のスライドを取得
auto slide = presentation->get_Slides()->idx_get(0);

// タイプを Rectangle に設定した AutoShape を追加
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Rectangle に TextFrame を追加
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// TextFrame のテキスト形式を取得
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// TextFrame の列数を指定
format->set_ColumnCount(3);

// 列間の間隔を指定
format->set_ColumnSpacing(10);

// プレゼンテーションを保存
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```


## **テキスト フレームに列を追加する**
Aspose.Slides for C++ は、[ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) インターフェイスの [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) メソッドを提供しており、テキスト フレーム内に列を追加できます。このメソッドを使用して、テキスト フレームに希望する列数を指定できます。

以下の C++ コードは、テキスト フレーム内に列を追加する方法を示しています。
```cpp
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

以下の C++ コードは、プレゼンテーション内のすべてのテキストを更新（変更）する操作を示しています。
```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //テキストを変更
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //書式を変更
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//変更されたプレゼンテーションを保存
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```


## **ハイパーリンク付きテキスト ボックスの追加** 

テキスト ボックス内にリンクを挿入できます。テキスト ボックスをクリックすると、ユーザーはそのリンク先を開きます。

ハイパーリンクを含むテキスト ボックスを追加する手順は次のとおりです。

1. `Presentation` クラスのインスタンスを作成します。  
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。  
3. スライド上の指定位置に `ShapeType` を `Rectangle` に設定した `AutoShape` オブジェクトを追加し、追加された AutoShape オブジェクトへの参照を取得します。  
4. `AutoShape` オブジェクトに、デフォルト テキストとして *Aspose TextBox* を含む `TextFrame` を追加します。  
5. `IHyperlinkManager` クラスのインスタンスを作成します。  
6. `TextFrame` の希望する部分に対して、`set_HyperlinkClick` メソッド（[set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c)）を使用して `IHyperlinkManager` オブジェクトを割り当てます。  
7. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き出します。  

以下の C++ コードは、上記手順を実装したもので、ハイパーリンク付きテキスト ボックスをスライドに追加する方法を示しています。
```cpp
// PPTX を表す Presentation クラスのインスタンス化
auto presentation = System::MakeObject<Presentation>();

// プレゼンテーションの最初のスライドを取得
auto slide = presentation->get_Slides()->idx_get(0);

// タイプを Rectangle に設定した AutoShape オブジェクトを追加
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// シェイプを AutoShape にキャスト
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// AutoShape に関連付けられた ITextFrame プロパティにアクセス
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// フレームにテキストを追加
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// 部分テキストにハイパーリンクを設定
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// PPTX プレゼンテーションを保存
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**マスタースライドでテキスト ボックスとテキスト プレースホルダーの違いは何ですか？**

テキスト プレースホルダー（[placeholder](/slides/ja/cpp/manage-placeholder/)）は、[マスタ] (https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) からスタイルと位置を継承し、[レイアウト] (https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) で上書きできます。一方、通常のテキスト ボックスは特定のスライド上の独立したオブジェクトであり、レイアウトを切り替えても変更されません。

**チャート、表、SmartArt 内のテキストを除外して、プレゼンテーション全体で一括置換を行うにはどうすればよいですか？**

テキスト フレームを持つ自動図形のみを対象にイテレーションし、埋め込みオブジェクト（[チャート] (https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/)、[表] (https://reference.aspose.com/slides/cpp/aspose.slides/table/)、[SmartArt] (https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)）は別個にコレクションを走査するか、これらのオブジェクトタイプをスキップしてください。