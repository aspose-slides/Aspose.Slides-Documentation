---
title: 在 .NET 中管理簡報的標頭與頁腳
linktitle: 標頭與頁腳
type: docs
weight: 140
url: /zh-hant/net/presentation-header-and-footer/
keywords:
- 標頭
- 標頭文字
- 頁腳
- 頁腳文字
- 設定標頭
- 設定頁腳
- 講義
- 備註
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中新增並自訂標頭與頁腳，以獲得專業外觀。"
---
## **概覽**

Aspose.Slides 讓您可以在 PowerPoint 簡報中管理標頭與頁腳設定。標頭與頁腳在簡報母版層級處理，API 提供設定頁腳文字、變更頁腳可見性以及在母片備註投影片上更新標頭文字的方法。

您也可以管理講義和備註投影片的標頭與頁腳。這包括變更備註母片、所有子備註投影片或單一備註投影片的標頭、頁腳、投影片編號與日期時間佔位符的可見性和文字。

## **管理標頭與頁腳文字**

某些特定投影片的備註可以如以下範例所示進行更新：

```c#
// 載入簡報
Presentation pres = new Presentation("headerTest.pptx");

// 設定頁腳
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// 存取並更新標頭
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// 儲存簡報
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// 設定標頭/頁腳文字的方法
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




## **在講義與備註投影片上管理標頭與頁腳**
Aspose.Slides for .NET 在講義與備註投影片上支援標頭與頁腳。請依照以下步驟操作：

- 載入包含影片的[Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)。
- 變更備註母片與所有備註投影片的標頭與頁腳設定。
- 設定母片備註投影片與所有子投影片的頁腳佔位符可見。
- 設定母片備註投影片與所有子投影片的日期與時間佔位符可見。
- 僅變更第一張備註投影片的標頭與頁腳設定。
- 設定備註投影片的標頭佔位符可見。
- 為備註投影片的標頭佔位符設定文字。
- 為備註投影片的日期時間佔位符設定文字。
- 寫入已修改的簡報檔案。

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// 更改備註母片與所有備註投影片的標頭與頁腳設定
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // 使母片備註投影片與所有子頁腳佔位符可見
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // 使母片備註投影片與所有子標頭佔位符可見
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // 使母片備註投影片與所有子投影片編號佔位符可見
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // 使母片備註投影片與所有子日期與時間佔位符可見

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // 設定文字至母片備註投影片與所有子標頭佔位符
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // 設定文字至母片備註投影片與所有子頁腳佔位符
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // 設定文字至母片備註投影片與所有子日期與時間佔位符
	}

	// 僅更改第一張備註投影片的標頭與頁腳設定
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // 使此備註投影片的標頭佔位符可見

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // 使此備註投影片的頁腳佔位符可見

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // 使此備註投影片的投影片編號佔位符可見

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // 使此備註投影片的日期時間佔位符可見

		headerFooterManager.SetHeaderText("New header text"); // 設定文字至備註投影片的標頭佔位符
		headerFooterManager.SetFooterText("New footer text"); // 設定文字至備註投影片的頁腳佔位符
		headerFooterManager.SetDateTimeText("New date and time text"); // 設定文字至備註投影片的日期時間佔位符
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **常見問答**

**我可以在一般投影片上添加「標頭」嗎？**

在 PowerPoint 中，「標頭」僅存在於備註與講義；在普通投影片上支援的元素只有頁腳、日期/時間以及投影片編號。Aspose.Slides 的限制與此相同：標頭僅限於備註/講義，投影片則只能使用頁腳、日期時間或投影片編號。

**如果版面配置不包含頁腳區域，我可以「開啟」其可見性嗎？**

可以。透過標頭/頁腳管理器檢查可見性，必要時將其啟用。這些 API 指標與方法專為佔位符缺失或被隱藏的情況設計。

**如何讓投影片編號從非 1 的數值開始？**

設定簡報的[first slide number](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/firstslidenumber/)；之後所有編號會重新計算。例如可以從 0 或 10 開始，並在標題投影片上隱藏編號。

**匯出為 PDF、圖像或 HTML 時，標頭/頁腳會發生什麼情況？**

它們會作為簡報的普通文字元素呈現。也就是說，只要這些元素在投影片或備註頁面上是可見的，輸出為 PDF、圖像或 HTML 時也會一併顯示。