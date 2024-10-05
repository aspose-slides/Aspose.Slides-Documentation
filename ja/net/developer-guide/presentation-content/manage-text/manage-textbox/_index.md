---
title: テキストボックスの管理
type: docs
weight: 20
url: /net/manage-textbox/
keywords: "Textbox, テキストフレーム, テキストボックスの追加, ハイパーリンク付きテキストボックス, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションにテキストボックスまたはテキストフレームを追加します"
---

スライド上のテキストは通常、テキストボックスまたは図形として存在します。したがって、スライドにテキストを追加するには、まずテキストボックスを追加し、その後テキストボックス内にテキストを入れる必要があります。

テキストを保持できる図形を追加できるようにするために、Aspose.Slides for .NETは[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)インターフェースを提供しています。

{{% alert title="注意" color="warning" %}}

Aspose.Slidesはまた、スライドに図形を追加できるようにするために[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape)インターフェースも提供しています。ただし、`IShape`インターフェースを通じて追加されたすべての図形がテキストを保持できるわけではありません。[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)インターフェースを通じて追加された図形には、通常テキストが含まれています。

したがって、テキストを追加したい既存の図形を扱う際には、それが`IAutoShape`インターフェースを介してキャストされたことを確認する必要があります。それによってのみ、`IAutoShape`のプロパティである[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe)を操作することができます。このページの[テキストの更新](https://docs.aspose.com/slides/net/manage-textbox/#update-text)セクションを参照してください。

{{% /alert %}}

## **スライドにテキストボックスを作成する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 指定された位置に`ShapeType`を`Rectangle`として設定した[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)オブジェクトを追加し、新しく追加された`IAutoShape`オブジェクトの参照を取得します。
4. テキストを含む`TextFrame`プロパティを`IAutoShape`オブジェクトに追加します。以下の例では、次のテキストを追加しました：*Aspose TextBox*
5. 最後に、`Presentation`オブジェクトを介してPPTXファイルを書き込みます。

上記のステップを実装したこのC#コードは、スライドにテキストを追加する方法を示しています：

```c#
// PresentationExをインスタンス化
using (Presentation pres = new Presentation())
{
    // プレゼンテーションの最初のスライドを取得
    ISlide sld = pres.Slides[0];

    // 自動図形を追加し、タイプをRectangleに設定
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // 矩形にTextFrameを追加
    ashp.AddTextFrame(" ");

    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.TextFrame;

    // テキストフレームのための段落オブジェクトを作成
    IParagraph para = txtFrame.Paragraphs[0];

    // 段落のためのポーションオブジェクトを作成
    IPortion portion = para.Portions[0];

    // テキストを設定
    portion.Text = "Aspose TextBox";

    // プレゼンテーションをディスクに保存
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **テキストボックス図形を確認する**

Aspose.Slidesは、テキストボックスを見分けるために[IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/)プロパティ（[AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)クラスから）を提供しています。

![テキストボックスと図形](istextbox.png)

このC#コードは、図形がテキストボックスとして作成されたかどうかを確認する方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(pres, (shape, slide, index) =>
    {
        if (shape is AutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "図形はテキストボックスです" : "図形はテキストボックスではありません");
        }
    });
}
```

## **テキストボックスに列を追加する**

Aspose.Slidesは、テキストボックスに列を追加できるようにするために、[ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount)および[ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing)プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)インターフェースおよび[TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)クラスから）を提供しています。テキストボックス内の列の数を指定し、列間のスペーシングをポイント単位で指定できます。

このC#コードは、説明した操作を示します：

```c#
using (Presentation presentation = new Presentation())
{
	// プレゼンテーションの最初のスライドを取得
	ISlide slide = presentation.Slides[0];

	// 自動図形を追加し、タイプをRectangleに設定
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// 矩形にTextFrameを追加
	aShape.AddTextFrame("これらのすべての列は単一のテキストコンテナ内に制限されています -- " +
	"テキストを追加または削除すると、新しいテキストまたは残りのテキストが自動的に調整されて " +
	"コンテナ内に流れるようになります。ただし、テキストが1つのコンテナから別のコンテナに流れることはありません -- " +
	"PowerPointのテキストオプションは制限されています！");

	// TextFrameのテキストフォーマットを取得
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// TextFrameの列数を指定
	format.ColumnCount = 3;

	// 列間のスペーシングを指定
	format.ColumnSpacing = 10;

	// プレゼンテーションを保存
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **テキストフレームに列を追加する**

Aspose.Slides for .NETは、テキストフレームに列を追加できるようにするために、[ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount)プロパティ（[ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat)インターフェースから）を提供しています。このプロパティを通じて、テキストフレーム内の列数を指定できます。

このC#コードは、テキストフレーム内に列を追加する方法を示しています：

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "これらのすべての列は単一のテキストコンテナにとどまるよう強制されています -- " +
                                "テキストを追加または削除しても、残ったテキストは自動的に調整され、 " +
                                "コンテナ内にとどまるようになります。ただし、テキストが1つのコンテナから " +
                                "他のコンテナにあふれることはありません -- PowerPointのテキストオプションは制限されています！";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **テキストの更新**

Aspose.Slidesは、テキストボックス内のテキストまたはプレゼンテーション内のすべてのテキストを変更または更新することを許可します。

このC#コードは、プレゼンテーション内のすべてのテキストが更新または変更される操作を示します：

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) // 形状がテキストフレーム（IAutoShape）をサポートしているか確認します
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) // テキストフレーム内の段落を繰り返します
               {
                   foreach (IPortion portion in paragraph.Portions) // 各部分を段落内で繰り返します
                   {
                       portion.Text = portion.Text.Replace("years", "months"); // テキストを変更します
                       portion.PortionFormat.FontBold = NullableBool.True; // 書式を変更します
                   }
               }
           }
       }
   }
  
   // 修正されたプレゼンテーションを保存します
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **ハイパーリンク付きテキストボックスの追加**

テキストボックス内にリンクを挿入できます。テキストボックスがクリックされると、ユーザーはリンクを開くように指示されます。

1. `Presentation`クラスのインスタンスを作成します。
2. インデックスを使用して最初のスライドの参照を取得します。
3. 指定された位置に`ShapeType`を`Rectangle`として設定した`AutoShape`オブジェクトを追加し、新しく追加されたAutoShapeオブジェクトの参照を取得します。
4. デフォルトのテキストとして*Aspose TextBox*を含む`TextFrame`を`AutoShape`オブジェクトに追加します。
5. `IHyperlinkManager`クラスをインスタンス化します。
6. お好きな`TextFrame`の部分に関連付けられた[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick)プロパティに`IHyperlinkManager`オブジェクトを設定します。
7. 最後に、`Presentation`オブジェクトを介してPPTXファイルを書き込みます。

上記のステップを実装したこのC#コードは、スライドにハイパーリンク付きテキストボックスを追加する方法を示しています：

```c#
// PPTXを表すPresentationクラスをインスタンス化
Presentation pptxPresentation = new Presentation();

// プレゼンテーションの最初のスライドを取得
ISlide slide = pptxPresentation.Slides[0];

// 自動図形オブジェクトを追加し、タイプをRectangleに設定
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// 形状をAutoShapeにキャスト
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// AutoShapeに関連付けられたITextFrameプロパティにアクセス
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// フレームにテキストを追加
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// ポーションテキストにハイパーリンクを設定
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// PPTXプレゼンテーションを保存
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```