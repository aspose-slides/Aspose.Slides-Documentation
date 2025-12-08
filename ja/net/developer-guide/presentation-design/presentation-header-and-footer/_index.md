---
title: プレゼンテーション ヘッダーとフッター
type: docs
weight: 140
url: /ja/net/presentation-header-and-footer/
keywords: "ヘッダー, フッター, ヘッダー設定, フッター設定, ヘッダーとフッター設定, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET での PowerPoint ヘッダーとフッター"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ja/net/) は、スライドのヘッダーおよびフッターのテキストを、実際にはスライドマスター レベルで管理する機能をサポートします。

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/ja/net/) は、プレゼンテーション スライド内のヘッダーおよびフッターを管理する機能を提供します。これらは実際にはプレゼンテーション マスター レベルで管理されます。
## **ヘッダーとフッターのテキストを管理**
特定のスライドのノートは、以下の例のように更新できます。
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





## **配布資料およびノート スライドのヘッダーとフッターを管理**
Aspose.Slides for .NET は、配布資料およびノート スライドのヘッダーとフッターをサポートします。以下の手順に従ってください：

- ビデオを含む[プレゼンテーション](https://reference.aspose.com/slides/net/aspose.slides/presentation)をロードします。
- ノートマスターとすべてのノートスライドのヘッダーとフッター設定を変更します。
- マスターノートスライドとすべての子フッタープレースホルダーを表示します。
- マスターノートスライドとすべての子日付と時刻プレースホルダーを表示します。
- 最初のノートスライドだけのヘッダーとフッター設定を変更します。
- ノートスライドのヘッダー プレースホルダーを表示します。
- ノートスライドのヘッダー プレースホルダーにテキストを設定します。
- ノートスライドの日付時刻 プレースホルダーにテキストを設定します。
- 変更されたプレゼンテーション ファイルを書き出します。

以下の例でコード スニペットが提供されています。
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

	// 最初のノートスライドのみのヘッダーとフッター設定を変更
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
			headerFooterManager.SetDateTimeVisibility(true); // このノートスライドの日付と時刻プレースホルダーを表示

		headerFooterManager.SetHeaderText("New header text"); // ノートスライドのヘッダープレースホルダーにテキストを設定
		headerFooterManager.SetFooterText("New footer text"); // ノートスライドのフッタープレースホルダーにテキストを設定
		headerFooterManager.SetDateTimeText("New date and time text"); // ノートスライドの日付と時刻プレースホルダーにテキストを設定
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **よくある質問**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では、「ヘッダー」はノートと配布資料にのみ存在し、通常のスライドではサポートされる要素はフッター、日付/時刻、スライド番号です。Aspose.Slides でも同じ制限があり、ヘッダーはノート/配布資料にのみ、スライドではフッター、日付時刻、スライド番号がサポートされます。

**レイアウトにフッター領域が含まれていない場合、可視性を「オン」にできますか？**

はい。ヘッダー/フッターマネージャで可視性を確認し、必要に応じて有効にしてください。これらの API インジケーターとメソッドは、プレースホルダーが存在しない、または非表示の場合に対応するように設計されています。

**スライド番号を 1 以外の値から開始するにはどうすればよいですか？**

プレゼンテーションの[first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/)を設定します。これ以降、すべての番号付けが再計算されます。たとえば、0 や 10 から開始でき、タイトルスライドの番号を非表示にすることもできます。

**PDF/画像/HTML にエクスポートするとき、ヘッダー/フッターはどうなりますか？**

ヘッダーとフッターは、プレゼンテーションの通常のテキスト要素として描画されます。つまり、スライドやノートページで要素が表示されていれば、出力形式でも他のコンテンツと同様に表示されます。