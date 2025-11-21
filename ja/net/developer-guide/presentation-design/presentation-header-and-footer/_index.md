---
title: .NET でプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/net/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダーテキスト
- フッター
- フッターテキスト
- ヘッダーを設定
- フッターを設定
- ハンドアウト
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "プロフェッショナルな外観を実現するために、PowerPoint と OpenDocument のプレゼンテーションにヘッダーとフッターを追加およびカスタマイズするために Aspose.Slides for .NET を使用します。"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ja/net/) は、スライドのヘッダーおよびフッターテキストを操作するサポートを提供し、実際にはスライドマスター レベルで管理されます。

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/ja/net/) は、プレゼンテーション スライド内のヘッダーとフッターを管理する機能を提供します。これらは実際にプレゼンテーション マスター レベルで管理されます。
## **ヘッダー と フッターテキストの管理**
特定のスライドのノートは、以下の例のように更新できます。
```c#
// プレゼンテーションを読み込む
Presentation pres = new Presentation("headerTest.pptx");

// フッターの設定
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// ヘッダーのアクセスと更新
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
    UpdateHeaderFooterText(masterNotesSlide);
}

// プレゼンテーションを保存
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```

```c#
// ヘッダー/フッターのテキストを設定するメソッド
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```





## **配布資料およびノートスライドでのヘッダーとフッターの管理**
Aspose.Slides for .NET は、配布資料およびノートスライドでヘッダーとフッターをサポートします。以下の手順に従ってください：

- ビデオを含む[Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)をロードします。
- ノート マスターとすべてのノート スライドのヘッダーとフッター設定を変更します。
- マスター ノート スライドとすべての子フッター プレースホルダーを表示可能に設定します。
- マスター ノート スライドとすべての子 日付と時刻 プレースホルダーを表示可能に設定します。
- 最初のノート スライドのみのヘッダーとフッター設定を変更します。
- ノート スライドのヘッダー プレースホルダーを表示可能に設定します。
- ノート スライドのヘッダー プレースホルダーにテキストを設定します。
- ノート スライドの日付/時刻 プレースホルダーにテキストを設定します。
- 変更されたプレゼンテーション ファイルを書き込みます。

以下の例でコード スニペットが提供されています。
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// ノートマスターとすべてのノートスライドのヘッダーとフッター設定を変更
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // マスターノートスライドとすべての子フッタープレースホルダーを表示可能にする
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // マスターノートスライドとすべての子ヘッダープレースホルダーを表示可能にする
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // マスターノートスライドとすべての子スライド番号プレースホルダーを表示可能にする
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // マスターノートスライドとすべての子日付と時刻プレースホルダーを表示可能にする

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // マスターノートスライドとすべての子ヘッダープレースホルダーにテキストを設定
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // マスターノートスライドとすべての子フッタープレースホルダーにテキストを設定
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // マスターノートスライドとすべての子日付と時刻プレースホルダーにテキストを設定
	}

	// 最初のノートスライドのみのヘッダーとフッター設定を変更
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // このノートスライドのヘッダープレースホルダーを表示可能にする

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // このノートスライドのフッタープレースホルダーを表示可能にする

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // このノートスライドのスライド番号プレースホルダーを表示可能にする

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // このノートスライドの日付-時刻プレースホルダーを表示可能にする

		headerFooterManager.SetHeaderText("New header text"); // ノートスライドのヘッダープレースホルダーにテキストを設定
		headerFooterManager.SetFooterText("New footer text"); // ノートスライドのフッタープレースホルダーにテキストを設定
		headerFooterManager.SetDateTimeText("New date and time text"); // ノートスライドの日付-時刻プレースホルダーにテキストを設定
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **FAQ**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では、ヘッダーはノートとハンドアウトにのみ存在し、通常のスライドではサポートされる要素はフッター、日付/時刻、スライド番号です。Aspose.Slides でも同様の制限があり、ヘッダーはノート/ハンドアウトにのみ、スライド上ではフッター、日付時刻、スライド番号が使用可能です。

**レイアウトにフッター領域が含まれていない場合、その表示を「オン」にできますか？**

はい。ヘッダー/フッターマネージャーで可視性を確認し、必要に応じて有効にします。これらの API インジケータとメソッドは、プレースホルダーが存在しない場合や非表示の場合に対応するよう設計されています。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの[first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) を設定します。その後、すべての番号付けが再計算されます。たとえば、0 や 10 から開始し、タイトル スライドの番号を非表示にすることができます。

**PDF/画像/HTML にエクスポートしたとき、ヘッダー/フッターはどうなりますか？**

ヘッダーとフッターはプレゼンテーションの通常のテキスト要素としてレンダリングされます。つまり、スライドやノートページで要素が表示されていれば、出力形式でも他のコンテンツと同様に表示されます。