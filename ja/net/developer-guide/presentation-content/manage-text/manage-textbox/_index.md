---
title: .NET のプレゼンテーションでテキストボックスを管理する
linktitle: テキストボックスの管理
type: docs
weight: 20
url: /ja/net/manage-textbox/
keywords:
- テキストボックス
- テキストフレーム
- テキストの追加
- テキストの更新
- テキストボックスの作成
- テキストボックスの確認
- テキスト列の追加
- ハイパーリンクの追加
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用すると、PowerPoint および OpenDocument ファイル内のテキストボックスの作成、編集、クローンが簡単になり、プレゼンテーションの自動化が向上します。"
---
## **導入**

スライド上のテキストは通常、テキストボックスまたは図形に存在します。そのため、スライドにテキストを追加するには、まずテキストボックスを追加し、その中にテキストを入力する必要があります。

テキストを保持できる図形を追加できるように、Aspose.Slides for .NET は[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape)インターフェイスを提供します。

{{% alert title="Note" color="warning" %}} 

Aspose.Slides はスライドに図形を追加できるように、[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape)インターフェイスも提供します。しかし、`IShape`インターフェイスを通じて追加されたすべての図形がテキストを保持できるわけではありません。[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape)インターフェイスを通じて追加された図形は通常テキストを含みます。

したがって、テキストを追加したい既存の図形を扱う場合、その図形が`IAutoShape`インターフェイスにキャストされていることを確認する必要があります。そうすることで初めて、`IAutoShape`のプロパティである[TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/properties/textframe)を使用できます。このページの[Update Text](https://docs.aspose.com/slides/ja/net/manage-textbox/#update-text)セクションをご参照ください。

{{% /alert %}}

## **スライドにテキストボックスを作成する**

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation)クラスのインスタンスを作成します。 
2. インデックスを使用して最初のスライドの参照を取得します。 
3. スライド上の指定位置に、[ShapeType](https://reference.aspose.com/slides/ja/net/aspose.slides/igeometryshape/properties/shapetype)を`Rectangle`に設定した[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape)オブジェクトを追加し、新しく追加された`IAutoShape`オブジェクトの参照を取得します。 
4. テキストを含む`IAutoShape`オブジェクトに`TextFrame`プロパティを追加します。以下の例では、*Aspose TextBox*というテキストを追加しました。 
5. 最後に、`Presentation`オブジェクトを使用してPPTXファイルを書き出します。 

以下の C# コードは、上記の手順を実装したもので、スライドにテキストを追加する方法を示します：

```c#
using Aspose.Slides;

// PresentationEx をインスタンス化します
using (Presentation pres = new Presentation())
{

    // プレゼンテーションの最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // タイプを Rectangle に設定した AutoShape を追加します
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle に TextFrame を追加します
    ashp.AddTextFrame(" ");

    // テキストフレームにアクセスします
    ITextFrame txtFrame = ashp.TextFrame;

    // テキストフレーム用の Paragraph オブジェクトを作成します
    IParagraph para = txtFrame.Paragraphs[0];

    // パラグラフ用の Portion オブジェクトを作成します
    IPortion portion = para.Portions[0];

    // テキストを設定します
    portion.Text = "Aspose TextBox";

    // プレゼンテーションをディスクに保存します
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **テキストボックス形状の確認**

Aspose.Slides は[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/)インターフェイスの[IsTextBox](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/istextbox/)プロパティを提供しており、図形を調べてテキストボックスかどうかを判別できます。

![テキストボックスと形状](istextbox.png)

以下の C# コードは、図形がテキストボックスとして作成されたかどうかを確認する方法を示します：

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

`AddAutoShape`メソッド（[IShapeCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/ishapecollection/)インターフェイス）で単にオートシェイプを追加した場合、オートシェイプの`IsTextBox`プロパティは`false`を返します。しかし、`AddTextFrame`メソッドまたは`Text`プロパティを使用してオートシェイプにテキストを追加すると、`IsTextBox`プロパティは`true`を返します。

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox は false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox は true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox は false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox は true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox は false
    shape3.AddTextFrame("");
    // shape3.IsTextBox は false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox は false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox は false
}
```

## **テキストフレームを所有する図形の検索**

汎用的なテキスト処理コードでは、どのプレゼンテーションオブジェクトに含まれているか分からないまま[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/)を受け取ることがあります。その場合は、[ITextFrame.ParentShape](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentshape/)プロパティを使用して所有者である[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/)に戻ります。

[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/)やその他のテキストを含む形状に属するテキストフレームの場合、[ITextFrame.ParentShape](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentshape/)が設定され、[ITextFrame.ParentCell](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/parentcell/)は`null`です。これらのプロパティは読み取り専用のナビゲーションプロパティであり、取得しても所有権は変更されません。形状にアクセスする前に、返された値が`null`でないことを必ず確認してください。

SmartArt ノードに関連付けられた形状を含む、形状およびテーブルセルの所有者を特定する完全な例については、[Search and Replace Text](/slides/ja/net/search-and-replace-text/)を参照してください。

## **テキストボックスに列を追加する**

Aspose.Slides は、テキストボックスに列を追加できるように、[ITextFrameFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat)インターフェイスおよび[TextFrameFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/textframeformat)クラスの[ColumnCount](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/properties/columncount)と[ColumnSpacing](https://reference.aspose.com/slides/ja/net/aspose.slides/textframeformat/properties/columnspacing)プロパティを提供します。テキストボックスの列数を指定し、列間の間隔（ポイント）を設定できます。

以下の C# コードは、上記の操作を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// プレゼンテーションの最初のスライドを取得します
	ISlide slide = presentation.Slides[0];

	// タイプを Rectangle に設定した AutoShape を追加します
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Rectangle に TextFrame を追加します
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// TextFrame のテキストフォーマットを取得します
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// TextFrame の列数を指定します
	format.ColumnCount = 3;

	// 列間の間隔を指定します
	format.ColumnSpacing = 10;

	// プレゼンテーションを保存します
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **テキストフレームに列を追加する**

Aspose.Slides for .NET は、テキストフレームに列を追加できるように、[ITextFrameFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat)インターフェイスの[ColumnCount](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/properties/columncount)プロパティを提供します。このプロパティを使用して、テキストフレーム内の希望する列数を指定できます。

以下の C# コードは、テキストフレーム内に列を追加する方法を示します：

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
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

Aspose.Slides を使用すると、テキストボックスに含まれるテキストやプレゼンテーション全体に含まれるテキストを変更または更新できます。

以下の C# コードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //形状がテキストフレーム (IAutoShape) をサポートしているかチェックします。
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //テキストフレーム内の段落を反復処理します
               {
                   foreach (IPortion portion in paragraph.Portions) //段落内の各ポーションを反復処理します
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //テキストを変更します
                       portion.PortionFormat.FontBold = NullableBool.True; //書式設定を変更します
                   }
               }
           }
       }
   }
  
   //変更されたプレゼンテーションを保存します
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **ハイパーリンク付きテキストボックスの追加**

テキストボックス内にリンクを挿入できます。テキストボックスがクリックされると、ユーザーはそのリンクを開きます。

1. `Presentation`クラスのインスタンスを作成します。 
2. インデックスを使用して最初のスライドの参照を取得します。  
3. スライド上の指定位置に`ShapeType`を`Rectangle`に設定した`AutoShape`オブジェクトを追加し、新しく追加されたAutoShapeオブジェクトの参照を取得します。 
4. `AutoShape`オブジェクトに`TextFrame`を追加し、デフォルトテキストとして*Aspose TextBox*を含めます。 
5. `IHyperlinkManager`クラスのインスタンスを作成します。 
6. `TextFrame`の任意の部分に関連付けられた[HyperlinkClick](https://reference.aspose.com/slides/ja/net/aspose.slides/shape/properties/hyperlinkclick)プロパティに`IHyperlinkManager`オブジェクトを割り当てます。 
7. 最後に、`Presentation`オブジェクトを使用してPPTXファイルを書き出します。 

以下の C# コードは、上記の手順を実装したもので、スライドにハイパーリンク付きテキストボックスを追加する方法を示します：

```c#
using Aspose.Slides;

// PPTX を表す Presentation クラスのインスタンスを作成します
Presentation pptxPresentation = new Presentation();

// プレゼンテーションの最初のスライドを取得します
ISlide slide = pptxPresentation.Slides[0];

// タイプを Rectangle に設定した AutoShape オブジェクトを追加します
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// 形状を AutoShape にキャストします
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// AutoShape に関連付けられた ITextFrame プロパティにアクセスします
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// フレームにテキストを追加します
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// ポーションテキストにハイパーリンクを設定します
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// PPTX プレゼンテーションを保存します
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**マスタースライドでテキストボックスとテキストプレースホルダーの違いは何ですか？**

[placeholder](/slides/ja/net/manage-placeholder/)は[master](https://reference.aspose.com/slides/ja/net/aspose.slides/masterslide/)からスタイルと位置を継承し、[layouts](https://reference.aspose.com/slides/ja/net/aspose.slides/layoutslide/)でオーバーライド可能です。一方、通常のテキストボックスは特定のスライド上の独立したオブジェクトであり、レイアウトを切り替えても変わりません。

**チャート、テーブル、SmartArt 内のテキストに影響を与えずに、プレゼンテーション全体で一括テキスト置換を実行するにはどうすればよいですか？**

テキストフレームを持つオートシェイプにのみイテレーションを限定し、埋め込みオブジェクト（[charts](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chart/)、[tables](https://reference.aspose.com/slides/ja/net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/ja/net/aspose.slides.smartart/smartart/)）は各コレクションを個別に走査するか、該当オブジェクトタイプをスキップすることで除外してください。