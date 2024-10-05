---
title: テキストボックスの管理
type: docs
weight: 20
url: /cpp/manage-textbox/
keywords: "テキストボックス, テキストフレーム, テキストボックスを追加, ハイパーリンク付きテキストボックス, C++, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションにテキストボックスまたはテキストフレームを追加します"
---

スライド上のテキストは通常、テキストボックスまたはシェイプに存在します。したがって、スライドにテキストを追加するには、テキストボックスを追加し、その中にいくつかのテキストを入れる必要があります。Aspose.Slides for C++ は、テキストを含むシェイプを追加することを可能にする [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) インターフェースを提供します。

{{% alert title="情報" color="info" %}}

Aspose.Slides はまた、スライドにシェイプを追加することを可能にする [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) インターフェースを提供します。しかし、`IShape` インターフェースを介して追加されたすべてのシェイプがテキストを保持できるわけではありません。しかし、[IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) インターフェースを介して追加されたシェイプはテキストを含むことができます。

{{% /alert %}}

{{% alert title="注意" color="warning" %}}

したがって、テキストを追加したいシェイプを扱う際には、それが `IAutoShape` インターフェースを介してキャストされたことを確認した方が良いでしょう。そうすれば、`IAutoShape` の下にあるプロパティである [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame) を使って作業ができるようになります。このページの [テキストの更新](https://docs.aspose.com/slides/cpp/manage-textbox/#update-text) セクションを参照してください。

{{% /alert %}}

## **スライドにテキストボックスを作成する**

スライドにテキストボックスを作成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. 新しく作成したプレゼンテーションの最初のスライドへの参照を取得します。
3. スライド上の指定された位置に `Rectangle` として [ShapeType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) を設定した [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) オブジェクトを追加し、新しく追加された `IAutoShape` オブジェクトへの参照を取得します。
4. テキストを含む `TextFrame` プロパティを `IAutoShape` オブジェクトに追加します。以下の例では、次のテキストを追加しました：*Aspose TextBox*
5. 最後に、`Presentation` オブジェクトを通じてPPTXファイルを書き込みます。

次のC++コードは、上記の手順の実装であり、スライドにテキストを追加する方法を示しています：

```cpp
// Presentationをインスタンス化
auto pres = System::MakeObject<Presentation>();

// プレゼンテーションの最初のスライドを取得
auto sld = pres->get_Slides()->idx_get(0);

// RectangleタイプのAutoShapeを追加
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// RectangleにTextFrameを追加
ashp->AddTextFrame(u" ");

// テキストフレームにアクセス
auto txtFrame = ashp->get_TextFrame();

// テキストフレームのための段落オブジェクトを作成
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// 段落のためのポーションオブジェクトを作成
auto portion = para->get_Portions()->idx_get(0);

// テキストを設定
portion->set_Text(u"Aspose TextBox");

// プレゼンテーションをディスクに保存
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **テキストボックスシェイプを確認する**

Aspose.Slides は、シェイプを調査し、テキストボックスを見つけるための [get_IsTextBox()](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) メソッドを提供します（[AutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/autoshape/) クラスから）。

![テキストボックスとシェイプ](istextbox.png)

次のC++コードは、シェイプがテキストボックスとして作成されたかどうかを確認する方法を示しています：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
for (auto&& slide : pres->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        auto autoShape = System::DynamicCast_noexcept<Aspose::Slides::AutoShape>(shape);
        if (autoShape != nullptr)
        {
            System::Console::WriteLine(autoShape->get_IsTextBox() ? System::String(u"シェイプはテキストボックスです") : System::String(u"シェイプはテキストボックスではありません"));
        }
    }
}
```

## **テキストボックスに列を追加する**

Aspose.Slides は、テキストボックスに列を追加することを可能にする [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) および [set_ColumnSpacing](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) メソッド（[ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) インターフェースおよび [TextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) クラスから）を提供します。このメソッドを使用して、テキストボックス内の列の数を指定し、列間の間隔をポイントで設定できます。

次のC++コードは、説明した操作を示します：

```cpp
auto presentation = System::MakeObject<Presentation>();
// プレゼンテーションの最初のスライドを取得
auto slide = presentation->get_Slides()->idx_get(0);

// RectangleタイプのAutoShapeを追加
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// RectangleにTextFrameを追加
aShape->AddTextFrame(String(u"これらのすべての列は、単一のテキストコンテナ内に制限されています -- ") 
    + u"テキストを追加または削除でき、新しいまたは残りのテキストが自動的に調整され " 
    + u"コンテナ内に流れ込みます。一つのコンテナから別のコンテナにテキストを流すことはできませんが -- PowerPointのテキストの列オプションは制限されています！");

// TextFrameのテキストフォーマットを取得
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// TextFrame内の列の数を指定
format->set_ColumnCount(3);

// 列間のスペーシングを指定
format->set_ColumnSpacing(10);

// プレゼンテーションを保存
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **テキストフレームに列を追加する**

Aspose.Slides for C++ は、テキストフレーム内に列を追加することを可能にする [set_ColumnCount](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) メソッド（[ITextFrameFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format) インターフェースから）を提供します。このメソッドを介して、テキストフレーム内の列の好ましい数を指定できます。

次のC++コードは、テキストフレーム内に列を追加する方法を示しています：

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"これらのすべての列は単一のテキストコンテナ内にとどまるよう強制されます -- ") 
    + u"テキストを追加または削除でき、新しいまたは残りのテキストが自動的に調整され " 
    + u"コンテナ内に留まるようになります。一つのコンテナから別のコンテナにテキストがこぼれることはできませんが -- PowerPointのテキストの列オプションは制限されています！");
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

## **テキストを更新する**

Aspose.Slides は、テキストボックス内のテキスト、またはプレゼンテーション内のすべてのテキストを変更または更新することを可能にします。

次のC++コードは、プレゼンテーション内のすべてのテキストが更新される操作を示しています：

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
                    // テキストを変更
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    // 書式を変更
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

// 修正されたプレゼンテーションを保存
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **ハイパーリンク付きテキストボックスを追加する**

テキストボックス内にリンクを挿入することができます。テキストボックスがクリックされると、ユーザーはリンクを開くように誘導されます。

リンクを含むテキストボックスを追加するには、次の手順を実行します：

1. `Presentation` クラスのインスタンスを作成します。
2. 新しく作成されたプレゼンテーションの最初のスライドへの参照を取得します。
3. スライド上の指定された位置に `Rectangle` として `AutoShape` オブジェクトを追加し、新しく追加されたAutoShapeオブジェクトへの参照を取得します。
4. *Aspose TextBox* をデフォルトテキストとして含む `AutoShape` オブジェクトに `TextFrame` を追加します。
5. `IHyperlinkManager` クラスをインスタンス化します。
6. `IHyperlinkManager` オブジェクトを、`TextFrame` の好ましいポーションに関連付けられた [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) メソッドに割り当てます。
7. 最後に、`Presentation` オブジェクトを通じてPPTXファイルを書き込みます。

次のC++コードは、上記の手順の実装であり、スライドにハイパーリンク付きテキストボックスを追加する方法を示しています：

```cpp
// PPTXを表すPresentationクラスをインスタンス化
auto presentation = System::MakeObject<Presentation>();

// プレゼンテーションの最初のスライドを取得
auto slide = presentation->get_Slides()->idx_get(0);

// Rectangleとしてタイプ設定されたAutoShapeオブジェクトを追加
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// シェイプをAutoShapeにキャスト
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// AutoShapeに関連付けられたITextFrameプロパティにアクセス
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// フレームにテキストを追加
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// ポーションテキストのハイパーリンクを設定
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// PPTXプレゼンテーションを保存
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```