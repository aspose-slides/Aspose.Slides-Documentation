---
title: .NET でプレゼンテーションのテキストボックスを管理する
linktitle: テキストボックスの管理
type: docs
weight: 20
url: /ja/net/manage-textbox/
keywords:
- テキストボックス
- テキストフレーム
- テキストを追加
- テキストを更新
- テキストボックスを作成
- テキストボックスを確認
- テキスト列を追加
- ハイパーリンクを追加
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用すると、PowerPoint や OpenDocument ファイル内のテキストボックスを簡単に作成、編集、複製でき、プレゼンテーションの自動化を強化します。"
---

スライド上のテキストは通常、テキストボックスや図形に配置されます。そのため、スライドにテキストを追加するには、まずテキストボックスを作成し、その中にテキストを入力する必要があります。

テキストを保持できる図形を追加できるように、Aspose.Slides for .NET は [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) インターフェイスを提供しています。

{{% alert title="Note" color="warning" %}} 
Aspose.Slides はさらに [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) インターフェイスを提供し、スライドに図形を追加できます。ただし、`IShape` インターフェイスで追加したすべての図形がテキストを保持できるわけではありません。`IShape` ではなく [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) インターフェイスで追加した図形は通常、テキストを含みます。

したがって、既存の図形にテキストを追加したい場合は、まずその図形が `IAutoShape` インターフェイスにキャストできるか確認してください。`IAutoShape` にキャストできたときだけ、`IAutoShape` のプロパティである [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) を操作できます。詳しくはこのページの [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) セクションを参照してください。
{{% /alert %}}

## **Create Text Box on Slide**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. スライド上の指定位置に `Rectangle` に設定した [ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) を持つ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) オブジェクトを追加し、新しく追加された `IAutoShape` オブジェクトの参照を取得します。  
4. `IAutoShape` オブジェクトに `TextFrame` プロパティを追加し、テキストを格納します。以下の例では *Aspose TextBox* というテキストを追加しています。  
5. 最後に `Presentation` オブジェクトを使用して PPTX ファイルを書き出します。  

以下の C# コードは上記手順の実装例で、スライドにテキストを追加する方法を示しています:
```c#
// PresentationEx をインスタンス化します
using (Presentation pres = new Presentation())
{

    // プレゼンテーションの最初のスライドを取得します
    ISlide sld = pres.Slides[0];

    // タイプが Rectangle に設定された AutoShape を追加します
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle に TextFrame を追加します
    ashp.AddTextFrame(" ");

    // テキストフレームにアクセスします
    ITextFrame txtFrame = ashp.TextFrame;

    // テキストフレーム用の Paragraph オブジェクトを作成します
    IParagraph para = txtFrame.Paragraphs[0];

    // 段落用の Portion オブジェクトを作成します
    IPortion portion = para.Portions[0];

    // テキストを設定します
    portion.Text = "Aspose TextBox";

    // プレゼンテーションをディスクに保存します
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Check for Text Box Shape**

Aspose.Slides は [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) インターフェイスの [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) プロパティを提供し、図形がテキストボックスかどうかを判定できます。

![Text box and shape](istextbox.png)

以下の C# コードは図形がテキストボックスとして作成されたかどうかを確認する方法を示しています: 
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


注意: `AddAutoShape` メソッド（[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) インターフェイス）で単に自動図形を追加した場合、その自動図形の `IsTextBox` プロパティは `false` を返します。ただし、`AddTextFrame` メソッドまたは `Text` プロパティで自動図形にテキストを追加すると、`IsTextBox` プロパティは `true` を返します。
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


## **Add Column in Text Box**

Aspose.Slides は [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) インターフェイスと [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスの [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) および [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) プロパティを提供し、テキストボックスに列を追加できます。列数と列間のポイント単位の間隔を指定できます。

以下の C# コードはこの操作を示しています: 
```c#
using (Presentation presentation = new Presentation())
{
	// プレゼンテーションの最初のスライドを取得
	ISlide slide = presentation.Slides[0];

	// タイプを Rectangle に設定した AutoShape を追加
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Rectangle に TextFrame を追加
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// TextFrame のテキスト形式を取得
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// TextFrame の列数を指定
	format.ColumnCount = 3;

	// 列間のスペースを指定
	format.ColumnSpacing = 10;

	// プレゼンテーションを保存
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **Add Column in Text Frame**

Aspose.Slides for .NET は [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) インターフェイスの [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) プロパティを提供し、テキストフレーム内に列を追加できます。このプロパティを使用して、希望する列数を指定してください。

以下の C# コードはテキストフレーム内に列を追加する方法を示しています:
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


## **Update Text**

Aspose.Slides を使用すると、テキストボックス内のテキストやプレゼンテーション全体に含まれるテキストを変更または更新できます。

以下の C# コードは、プレゼンテーション内のすべてのテキストを更新（置換）する例です:
```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //シェイプがテキストフレーム（IAutoShape）をサポートしているか確認します。 
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


## **Add Text Box with Hyperlink** 

テキストボックス内にリンクを挿入できます。テキストボックスがクリックされると、ユーザーはそのリンク先へ移動します。

1. `Presentation` クラスのインスタンスを作成します。  
2. インデックスを使用して最初のスライドの参照を取得します。  
3. スライド上の指定位置に `Rectangle` に設定した `ShapeType` を持つ `AutoShape` オブジェクトを追加し、新しく追加された AutoShape オブジェクトの参照を取得します。  
4. `AutoShape` オブジェクトに `TextFrame` を追加し、デフォルトテキストとして *Aspose TextBox* を設定します。  
5. `IHyperlinkManager` クラスのインスタンスを作成します。  
6. 任意の `TextFrame` 部分に対して、`HyperlinkClick` プロパティ（[HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick)）に `IHyperlinkManager` オブジェクトを割り当てます。  
7. 最後に `Presentation` オブジェクトを使用して PPTX ファイルを書き出します。  

以下の C# コードは上記手順の実装例で、ハイパーリンク付きテキストボックスをスライドに追加する方法を示しています:
```c#
// PPTX を表す Presentation クラスのインスタンスを生成します
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

**マスタースライドでテキストボックスとテキストプレースホルダーの違いは何ですか？**

プレースホルダー [/slides/net/manage-placeholder/](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) は [マスター](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) からスタイルと位置を継承し、[レイアウト](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) で上書き可能ですが、通常のテキストボックスは特定のスライド上に独立したオブジェクトとして存在し、レイアウトを切り替えても変化しません。

**チャート、テーブル、SmartArt 内のテキストを除外して、プレゼンテーション全体でテキストを一括置換するにはどうすればよいですか？**

テキストフレームを持つ自動図形だけを対象に反復処理し、埋め込みオブジェクト（[チャート](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)、[テーブル](https://reference.aspose.com/slides/net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)）はそれぞれ別のコレクションを走査するか、対象オブジェクトタイプを除外してください。