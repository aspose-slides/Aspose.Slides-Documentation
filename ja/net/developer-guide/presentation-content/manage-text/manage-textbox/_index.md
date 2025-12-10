---
title: .NET でプレゼンテーションのテキストボックスを管理する
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
description: "Aspose.Slides for .NET を使用すれば、PowerPoint および OpenDocument ファイル内のテキストボックスを簡単に作成、編集、クローンでき、プレゼンテーションの自動化を強化します。"
---

スライド上のテキストは通常、テキストボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、まずテキストボックスを追加し、そのテキストボックスの中にテキストを入力する必要があります。

テキストを保持できるシェイプを追加できるように、Aspose.Slides for .NET は [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) インターフェイスを提供します。

{{% alert title="注" color="warning" %}} 

Aspose.Slides はさらに [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) インターフェイスを提供しており、スライドにシェイプを追加できます。ただし、`IShape` インターフェイスを介して追加されたすべてのシェイプがテキストを保持できるわけではありません。[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) インターフェイスを介して追加されたシェイプは通常、テキストを含みます。

したがって、テキストを追加したい既存のシェイプを扱う場合は、そのシェイプが `IAutoShape` インターフェイスにキャストされていることを確認した方がよいでしょう。初めて `IAutoShape` の下にあるプロパティである [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) を操作できるようになります。このページの [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) セクションをご参照ください。

{{% /alert %}}

## **スライドにテキストボックスを作成する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. スライド上の指定位置に `Rectangle` に設定された [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) を持つ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) オブジェクトを追加し、新しく追加された `IAutoShape` オブジェクトの参照を取得します。  
4. テキストを含む `TextFrame` プロパティを `IAutoShape` オブジェクトに追加します。以下の例では、*Aspose TextBox* というテキストを追加しました。  
5. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き込みます。  

以下の C# コードは、上記の手順を実装したもので、スライドにテキストを追加する方法を示しています。
```c#
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

    // Paragraph 用の Portion オブジェクトを作成します
    IPortion portion = para.Portions[0];

    // テキストを設定します
    portion.Text = "Aspose TextBox";

    // プレゼンテーションをディスクに保存します
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **テキストボックス シェイプかどうかを確認する**

Aspose.Slides は、[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) インターフェイスの [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) プロパティを提供しており、シェイプを調べてテキストボックスかどうかを判別できます。

![Text box and shape](istextbox.png)

以下の C# コードは、シェイプがテキストボックスとして作成されたかどうかを確認する方法を示しています。  
```c#
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


`AddAutoShape` メソッドを使用して [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) インターフェイスから単にオートシェイプを追加した場合、オートシェイプの `IsTextBox` プロパティは `false` を返します。ただし、`AddTextFrame` メソッドまたは `Text` プロパティを使用してオートシェイプにテキストを追加すると、`IsTextBox` プロパティは `true` を返します。
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox は false です
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox は true です

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox は false です
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox は true です

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox は false です
    shape3.AddTextFrame("");
    // shape3.IsTextBox は false です

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox は false です
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox は false です
}
```


## **テキストボックスに列を追加する**

Aspose.Slides は、[ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) インターフェイスおよび [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) と [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) プロパティを提供しており、テキストボックスに列を追加できます。テキストボックス内の列数と、列間のポイント単位の間隔を指定できます。

以下の C# コードは、上記の操作を示しています。  
```c#
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

	// TextFrame のテキスト形式を取得します
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

Aspose.Slides for .NET は、[ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) インターフェイスの [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) プロパティを提供しており、テキストフレーム内に列を追加できます。このプロパティを使用して、テキストフレーム内の希望する列数を指定できます。

以下の C# コードは、テキストフレーム内に列を追加する方法を示しています。  
```c#
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

Aspose.Slides を使用すると、テキストボックス内のテキストやプレゼンテーション全体に含まれるテキストを変更または更新できます。

以下の C# コードは、プレゼンテーション内のすべてのテキストを更新（変更）する操作を示しています。  
```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //形状がテキストフレーム（IAutoShape）をサポートしているか確認します。 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //テキストフレーム内の段落を反復処理します。 
               {
                   foreach (IPortion portion in paragraph.Portions) //段落内の各ポーションを反復処理します。 
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //テキストを変更します。 
                       portion.PortionFormat.FontBold = NullableBool.True; //書式設定を変更します。 
                   }
               }
           }
       }
   }
  
   //変更されたプレゼンテーションを保存します。 
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```


## **ハイパーリンク付きテキストボックスの追加**

テキストボックス内にリンクを挿入できます。テキストボックスがクリックされると、ユーザーはリンク先を開きます。

1. `Presentation` クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. スライド上の指定位置に `Rectangle` に設定された `ShapeType` を持つ `AutoShape` オブジェクトを追加し、新しく追加された AutoShape オブジェクトの参照を取得します。  
4. デフォルトテキストとして *Aspose TextBox* を含む `TextFrame` を `AutoShape` オブジェクトに追加します。  
5. `IHyperlinkManager` クラスのインスタンスを作成します。  
6. 好みの `TextFrame` の一部に関連付けられた [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) プロパティに `IHyperlinkManager` オブジェクトを割り当てます。  
7. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き込みます。  

以下の C# コードは、上記の手順を実装したもので、ハイパーリンク付きテキストボックスをスライドに追加する方法を示しています。  
```c#
// PPTX を表す Presentation クラスのインスタンスを作成します
Presentation pptxPresentation = new Presentation();

// プレゼンテーションの最初のスライドを取得します
ISlide slide = pptxPresentation.Slides[0];

// タイプを Rectangle に設定した AutoShape オブジェクトを追加します
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// シェイプを AutoShape にキャストします
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

**マスタースライドでテキストボックスとテキスト プレースホルダーの違いは何ですか？**

[プレースホルダー](/slides/ja/net/manage-placeholder/) は [マスター](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) からスタイルと位置を継承し、[レイアウト](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) で上書きできます。一方、通常のテキストボックスは特定のスライド上の独立したオブジェクトであり、レイアウトを切り替えても変わりません。

**チャート、テーブル、SmartArt の内部テキストを除外して、プレゼンテーション全体でテキストを一括置換するにはどうすればよいですか？**

テキストフレームを持つオートシェイプのみを対象にイテレーションし、埋め込みオブジェクト（[チャート](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)、[テーブル](https://reference.aspose.com/slides/net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)）はそれぞれのコレクションを別途走査するか、対象オブジェクトタイプをスキップして除外してください。