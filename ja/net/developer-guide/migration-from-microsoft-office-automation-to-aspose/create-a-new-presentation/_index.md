---
title: 新しいプレゼンテーションを作成する
type: docs
weight: 10
url: /net/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTOは、開発者がMicrosoft Office内で実行できるアプリケーションを構築できるように開発されました。VSTOはCOMベースですが、.NETアプリケーションで使用できるように.NETオブジェクト内にラップされています。VSTOは.NETフレームワークのサポートとMicrosoft Office CLRベースのランタイムが必要です。Microsoft Officeアドインを作成するために使用できますが、サーバーサイドコンポーネントとして使用することはほとんど不可能です。また、深刻な展開の問題もあります。

Aspose.Slides for .NETは、VSTOと同様にMicrosoft PowerPointプレゼンテーションを操作するために使用できるコンポーネントですが、いくつかの利点があります：

- Aspose.Slidesはマネージコードのみを含み、Microsoft Officeランタイムをインストールする必要がありません。
- クライアントサイドコンポーネントとして、またはサーバーサイドコンポーネントとして使用できます。
- Aspose.Slidesは単一のDLLに含まれているため、展開が簡単です。

{{% /alert %}} 
## **プレゼンテーションの作成**
以下は、同じ目的を達成するためにVSTOとAspose.Slides for .NETがどのように使用されるかを示す2つのコード例です。最初の例は[VSTO](/slides/net/create-a-new-presentation/); [2番目の例](/slides/net/create-a-new-presentation/)はAspose.Slidesを使用しています。
### **VSTOの例**
**VSTOの出力** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//注意: PowerPointは上で定義された名前空間です
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//プレゼンテーションを作成
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//タイトルスライドレイアウトを取得
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//タイトルスライドを追加する。
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//タイトルテキストを設定
slide.Shapes.Title.TextFrame.TextRange.Text = "スライドタイトルヘッディング";

//サブタイトルテキストを設定
slide.Shapes[2].TextFrame.TextRange.Text = "スライドタイトルサブヘッディング";

//出力をディスクに書き込む
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NETの例**
**Aspose.Slidesからの出力** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
//プレゼンテーションを作成
Presentation pres = new Presentation();

//タイトルスライドを追加
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//タイトルテキストを設定
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "スライドタイトルヘッディング";

//サブタイトルテキストを設定
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "スライドタイトルサブヘッディング";

//出力をディスクに書き込む
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```