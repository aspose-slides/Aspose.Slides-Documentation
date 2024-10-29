---
title: プレゼンテーションのヘッダーとフッター
type: docs
weight: 140
url: /ja/net/presentation-header-and-footer/
keywords: "ヘッダー、フッター、ヘッダーを設定、フッターを設定、ヘッダーとフッターを設定、PowerPointプレゼンテーション、C#、Csharp、Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointのヘッダーとフッター"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ja/net/)は、スライドマスターレベルで実際に管理されているスライドのヘッダーとフッターテキストを操作するためのサポートを提供します。

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/ja/net/)は、プレゼンテーションスライド内でヘッダーとフッターを管理する機能を提供します。これらは実際にはプレゼンテーションマスターのレベルで管理されています。
## **ヘッダーとフッターテキストの管理**
特定のスライドのノートは、以下の例のように更新することができます：

```c#
// プレゼンテーションをロード
Presentation pres = new Presentation("headerTest.pptx");

// フッターの設定
pres.HeaderFooterManager.SetAllFootersText("私のフッターのテキスト");
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
                ((IAutoShape)shape).TextFrame.Text = "こんにちは、新しいヘッダー";
            }
        }
    }
}
```




## **ハンドアウトおよびノートスライドのヘッダーとフッターの管理**
Aspose.Slides for .NETは、ハンドアウトおよびノートスライド内のヘッダーとフッターをサポートしています。次の手順に従ってください:

- ビデオを含む[プレゼンテーション](https://reference.aspose.com/slides/net/aspose.slides/presentation)をロードします。
- ノートマスターおよびすべてのノートスライドのヘッダーとフッター設定を変更します。
- マスターノートスライドとすべての子フッタープレースホルダーを表示可能にします。
- マスターノートスライドとすべての子日付および時刻プレースホルダーを表示可能にします。
- 最初のノートスライドのみのヘッダーとフッター設定を変更します。
- ノートスライドのヘッダープレースホルダーを表示可能にします。
- ノートスライドのヘッダープレースホルダーにテキストを設定します。
- ノートスライドの日付時刻プレースホルダーにテキストを設定します。
- 修正したプレゼンテーションファイルを書き込みます。

以下の例に提供されたコードスニペット。

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// ノートマスターおよびすべてのノートスライドのヘッダーとフッター設定を変更します
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // マスターノートスライドとすべての子フッタープレースホルダーを表示可能にします
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // マスターノートスライドとすべての子ヘッダープレースホルダーを表示可能にします
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // マスターノートスライドとすべての子スライド番号プレースホルダーを表示可能にします
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // マスターノートスライドとすべての子日付および時刻プレースホルダーを表示可能にします

		headerFooterManager.SetHeaderAndChildHeadersText("ヘッダーテキスト"); // マスターノートスライドとすべての子ヘッダープレースホルダーにテキストを設定します
		headerFooterManager.SetFooterAndChildFootersText("フッターテキスト"); // マスターノートスライドとすべての子フッタープレースホルダーにテキストを設定します
		headerFooterManager.SetDateTimeAndChildDateTimesText("日付と時刻のテキスト"); // マスターノートスライドとすべての子日付および時刻プレースホルダーにテキストを設定します
	}

	// 最初のノートスライドのみのヘッダーとフッター設定を変更します
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // このノートスライドのヘッダープレースホルダーを表示可能にします

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // このノートスライドのフッタープレースホルダーを表示可能にします

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // このノートスライドのスライド番号プレースホルダーを表示可能にします

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // このノートスライドの日付時刻プレースホルダーを表示可能にします

		headerFooterManager.SetHeaderText("新しいヘッダーテキスト"); // ノートスライドのヘッダープレースホルダーにテキストを設定します
		headerFooterManager.SetFooterText("新しいフッターテキスト"); // ノートスライドのフッタープレースホルダーにテキストを設定します
		headerFooterManager.SetDateTimeText("新しい日付と時刻のテキスト"); // ノートスライドの日付時刻プレースホルダーにテキストを設定します
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```