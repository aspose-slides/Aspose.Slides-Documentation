---
title: テキストボックスの管理
type: docs
weight: 20
url: /ja/net/manage-textbox/
keywords:
- テキストボックス
- テキストフレーム
- テキストの追加
- テキストの更新
- ハイパーリンク付きテキストボックス
- PowerPoint
- プレゼンテーション
- C#
- C#
- Aspose.Slides for .NET
description: "C# または .NET を使用して PowerPoint プレゼンテーション内のテキストボックスまたはテキストフレームを管理します"
---

スライド上のテキストは通常、テキストボックスまたはシェイプに存在します。そのため、スライドにテキストを追加するには、まずテキストボックスを追加し、そのテキストボックスの中にテキストを入れる必要があります。

テキストを保持できるシェイプを追加できるように、Aspose.Slides for .NET は [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) インターフェイスを提供しています。

{{% alert title="Note" color="warning" %}} 
Aspose.Slides はまた、スライドにシェイプを追加できるように [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) インターフェイスも提供しています。ただし、`IShape` インターフェイスを通じて追加されたすべてのシェイプがテキストを保持できるわけではありません。[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) インターフェイスを通じて追加されたシェイプは通常、テキストを含みます。

したがって、テキストを追加したい既存のシェイプを扱う場合、そのシェイプが `IAutoShape` インターフェイスにキャストされているか確認したいでしょう。そうして初めて、`IAutoShape` の下にあるプロパティである [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) を操作できます。このページの [Update Text](https://docs.aspose.com/slides/net/manage-textbox/#update-text) セクションをご参照ください。
{{% /alert %}}

## **スライド上にテキストボックスを作成**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。 
2. インデックスを使用して最初のスライドの参照を取得します。 
3. スライド上の指定位置に、[ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/properties/shapetype) を `Rectangle` に設定した [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) オブジェクトを追加し、新しく追加された `IAutoShape` オブジェクトの参照を取得します。 
4. `IAutoShape` オブジェクトにテキストを保持する `TextFrame` プロパティを追加します。以下の例では、*Aspose TextBox* というテキストを追加しました。 
5. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き込みます。 

以下の C# コードは、上記の手順を実装したもので、スライドにテキストを追加する方法を示しています:
```c#
 // PresentationEx をインスタンス化
 using (Presentation pres = new Presentation())
 {
 
     // プレゼンテーションの最初のスライドを取得
     ISlide sld = pres.Slides[0];
 
     // タイプを Rectangle に設定した AutoShape を追加
     IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);
 
     // Rectangle に TextFrame を追加
     ashp.AddTextFrame(" ");
 
     // テキストフレームにアクセス
     ITextFrame txtFrame = ashp.TextFrame;
 
     // テキストフレーム用の Paragraph オブジェクトを作成
     IParagraph para = txtFrame.Paragraphs[0];
 
     // 段落用の Portion オブジェクトを作成
     IPortion portion = para.Portions[0];
 
     // テキストを設定
     portion.Text = "Aspose TextBox";
 
     // プレゼンテーションをディスクに保存
     pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```


## **テキストボックスシェイプの確認**

Aspose.Slides は、[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) インターフェイスから取得できる [IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) プロパティを提供し、シェイプを調査してテキストボックスかどうかを識別できます。

![テキストボックスとシェイプ](istextbox.png)

以下の C# コードは、シェイプがテキストボックスとして作成されたかどうかを確認する方法を示しています: 
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


`AddAutoShape` メソッド（[IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/) インターフェイス）でオートシェイプを単に追加しただけでは、そのオートシェイプの `IsTextBox` プロパティは `false` を返します。しかし、`AddTextFrame` メソッドまたは `Text` プロパティを使用してオートシェイプにテキストを追加すると、`IsTextBox` プロパティは `true` を返します。
```cs
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


## **テキストボックスに列を追加**

Aspose.Slides は、テキストボックスに列を追加できるように、[ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) インターフェイスと [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) クラスから取得できる [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) と [ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/columnspacing) プロパティを提供します。テキストボックスの列数と、列間のポイント単位の間隔を指定できます。 

以下の C# コードは、上記の操作を示しています: 
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

	// TextFrame のテキスト書式を取得
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// TextFrame の列数を指定
	format.ColumnCount = 3;

	// 列間の間隔を指定
	format.ColumnSpacing = 10;

	// プレゼンテーションを保存
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```


## **テキストフレームに列を追加**

Aspose.Slides for .NET は、テキストフレームに列を追加できるように、[ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat) インターフェイスから取得できる [ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/columncount) プロパティを提供します。このプロパティを使用して、テキストフレーム内の希望する列数を指定できます。 

以下の C# コードは、テキストフレーム内に列を追加する方法を示しています:
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

以下の C# コードは、プレゼンテーション内のすべてのテキストを更新または変更する操作を示しています:
```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //shape がテキストフレーム (IAutoShape) をサポートしているか確認します。 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //テキストフレーム内の段落を繰り返し処理します
               {
                   foreach (IPortion portion in paragraph.Portions) //段落内の各ポーションを繰り返し処理します
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //テキストを変更します
                       portion.PortionFormat.FontBold = NullableBool.True; //書式を変更します
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

テキストボックス内にリンクを挿入できます。テキストボックスがクリックされると、ユーザーはリンク先を開くように誘導されます。 

1. `Presentation` クラスのインスタンスを作成します。 
2. インデックスを使用して最初のスライドの参照を取得します。  
3. スライド上の指定位置に、`ShapeType` を `Rectangle` に設定した `AutoShape` オブジェクトを追加し、新しく追加された AutoShape オブジェクトの参照を取得します。 
4. `AutoShape` オブジェクトに、デフォルトテキストとして *Aspose TextBox* を含む `TextFrame` を追加します。 
5. `IHyperlinkManager` クラスのインスタンスを作成します。 
6. `TextFrame` の目的の部分に関連付けられた [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/properties/hyperlinkclick) プロパティに `IHyperlinkManager` オブジェクトを割り当てます。 
7. 最後に、`Presentation` オブジェクトを使用して PPTX ファイルを書き込みます。 

以下の C# コードは、上記の手順を実装したもので、ハイパーリンク付きテキストボックスをスライドに追加する方法を示しています:
```c#
// PPTX を表す Presentation クラスのインスタンスを作成
Presentation pptxPresentation = new Presentation();

// プレゼンテーションの最初のスライドを取得
ISlide slide = pptxPresentation.Slides[0];

// タイプを Rectangle に設定した AutoShape オブジェクトを追加
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// シェイプを AutoShape にキャスト
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// AutoShape に関連付けられた ITextFrame プロパティにアクセス
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// フレームにテキストを追加
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// ポーションテキストにハイパーリンクを設定
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// PPTX プレゼンテーションを保存
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**テキストボックスとマスタースライドで使用するテキストプレースホルダーの違いは何ですか？**

[placeholder](/slides/ja/net/manage-placeholder/) は [master](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) からスタイルと位置を継承し、[layouts](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) で上書きできます。一方、通常のテキストボックスは特定のスライド上の独立したオブジェクトで、レイアウトを切り替えても変わりません。

**チャート、テーブル、SmartArt 内のテキストに触れずに、プレゼンテーション全体でテキストを一括置換するにはどうすればよいですか？**

テキストフレームを持つオートシェイプに対してのみ反復処理を行い、埋め込みオブジェクト（[charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)、[tables](https://reference.aspose.com/slides/net/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)）はそれぞれのコレ列を別々に走査するか、これらのオブジェクトタイプをスキップして除外してください。