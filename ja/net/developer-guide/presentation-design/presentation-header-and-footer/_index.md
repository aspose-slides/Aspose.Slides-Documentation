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
- 配布資料
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "プロフェッショナルな外観を実現するために、Aspose.Slides for .NET を使用して PowerPoint および OpenDocument のプレゼンテーションにヘッダーとフッターを追加およびカスタマイズします。"
---

{{% alert color="primary" %}} 
[Aspose.Slides](/slides/ja/net/) は、スライドのヘッダーおよびフッターテキストを操作するサポートを提供します。これらは実際にスライドマスターレベルで管理されています。
{{% /alert %}} 
[Aspose.Slides for .NET](/slides/ja/net/) は、プレゼンテーションスライド内のヘッダーとフッターを管理する機能を提供します。これらは実際にプレゼンテーションマスターレベルで管理されています。
## **ヘッダーおよびフッターテキストの管理**
特定のスライドのノートは以下の例のように更新できます:
```c#
// プレゼンテーションをロード
Presentation pres = new Presentation("headerTest.pptx");

// フッターを設定
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// ヘッダーにアクセスして更新
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// プレゼンテーションを保存
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```

```c#
// ヘッダー/フッターテキストを設定するメソッド
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





## **配布資料およびノートスライドのヘッダーとフッターの管理**
Aspose.Slides for .NET は配布資料とノートスライドのヘッダーとフッターをサポートしています。以下の手順に従ってください:

- ビデオを含む[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)を読み込みます。
- ノートマスターとすべてのノートスライドのヘッダーとフッター設定を変更します。
- マスターノートスライドとすべての子フッタープレースホルダーを表示状態に設定します。
- マスターノートスライドとすべての子日付と時刻のプレースホルダーを表示状態に設定します。
- 最初のノートスライドのみのヘッダーとフッター設定を変更します。
- ノートスライドのヘッダープレースホルダーを表示に設定します。
- ノートスライドのヘッダープレースホルダーにテキストを設定します。
- ノートスライドの日付・時刻プレースホルダーにテキストを設定します。
- 変更されたプレゼンテーションファイルを書き込みます。

以下の例でコードスニペットが提供されています。
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// ノートマスターとすべてのノートスライドのヘッダーとフッター設定を変更
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // マスターノートスライドとすべての子フッタープレースホルダーを表示
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // マスターノートスライドとすべての子ヘッダープレースホルダーを表示
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // マスターノートスライドとすべての子スライド番号プレースホルダーを表示
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // マスターノートスライドとすべての子日付と時刻プレースホルダーを表示

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // マスターノートスライドとすべての子ヘッダープレースホルダーにテキストを設定
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // マスターノートスライドとすべての子フッタープレースホルダーにテキストを設定
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // マスターノートスライドとすべての子日付と時刻プレースホルダーにテキストを設定
	}

	// 最初のノートスライドだけのヘッダーとフッター設定を変更
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // このノートスライドのヘッダープレースホルダーを表示

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // このノートスライドのフッタープレースホルダーを表示

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // このノートスライドのスライド番号プレースホルダーを表示

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // このノートスライドの日付時刻プレースホルダーを表示

		headerFooterManager.SetHeaderText("New header text"); // ノートスライドのヘッダープレースホルダーにテキストを設定
		headerFooterManager.SetFooterText("New footer text"); // ノートスライドのフッタープレースホルダーにテキストを設定
		headerFooterManager.SetDateTimeText("New date and time text"); // ノートスライドの日付時刻プレースホルダーにテキストを設定
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **FAQ**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では「ヘッダー」はノートと配布資料にのみ存在し、通常のスライドではサポートされている要素はフッター、日付/時刻、スライド番号です。Aspose.Slides でも同様の制限があり、ヘッダーはノート/配布資料にのみ使用でき、スライド上ではフッター、日付/時刻、スライド番号が使用できます。

**レイアウトにフッター領域が含まれていない場合、表示を「オン」にできますか？**

はい。ヘッダー/フッターマネージャーで表示状態を確認し、必要に応じて有効にしてください。これらの API 指標とメソッドは、プレースホルダーが欠落しているか非表示の場合に対応するよう設計されています。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの[first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/)を設定します。その後、すべての番号付けが再計算されます。たとえば、0 や 10 から開始でき、タイトルスライドの番号を非表示にすることも可能です。

**PDF/画像/HTML にエクスポートするとき、ヘッダー/フッターはどうなりますか？**

ヘッダー/フッターはプレゼンテーションの通常のテキスト要素としてレンダリングされます。つまり、スライドやノートページで要素が表示されていれば、出力形式でも他のコンテンツと同様に表示されます。