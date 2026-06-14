---
title: 在 Android 上管理簡報的頁首與頁尾
linktitle: 頁首與頁尾
type: docs
weight: 140
url: /zh-hant/androidjava/presentation-header-and-footer/
keywords:
- 頁首
- 頁首文字
- 頁尾
- 頁尾文字
- 設定頁首
- 設定頁尾
- 講義
- 註解
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 為 PowerPoint 與 OpenDocument 簡報新增並自訂頁首與頁尾，以呈現專業外觀。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中管理頁首與頁尾設定。頁首與頁尾在簡報母片層級處理，API 提供設定頁尾文字、變更頁尾可見性，以及在母片註解投影片上更新頁首文字的方法。

您也可以管理講義與註解投影片的頁首與頁尾。這包括變更註解母片、所有子註解投影片或單一註解投影片之頁首、頁尾、投影片編號與日期時間佔位符的可見性與文字。

## **管理簡報中的頁首與頁尾**
某些特定投影片的註解可能會被移除，如下例所示：

```java
// 載入簡報
Presentation pres = new Presentation("headerTest.pptx");
try {
    // 設定頁尾
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // 取得並更新頁首
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // 儲存簡報
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// 設定頁首/頁尾文字的方法
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **管理講義與註解投影片的頁首與頁尾**
Aspose.Slides for Android via Java 支援講義與註解投影片的頁首與頁尾。請依照以下步驟操作：

- 載入包含影片的[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation)。
- 變更註解母片與所有註解投影片的頁首與頁尾設定。
- 設定母片註解投影片與所有子頁尾佔位符可見。
- 設定母片註解投影片與所有子日期與時間佔位符可見。
- 僅變更第一張註解投影片的頁首與頁尾設定。
- 設定註解投影片的頁首佔位符可見。
- 為註解投影片的頁首佔位符設定文字。
- 為註解投影片的日期時間佔位符設定文字。
- 寫入已修改的簡報檔案。

範例中提供了程式碼片段。

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // 更改註解母片與所有註解投影片的頁首與頁尾設定
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // 使母片註解投影片及所有子頁腳佔位符可見
        headerFooterManager.setFooterAndChildFootersVisibility(true); // 使母片註解投影片及所有子頁首佔位符可見
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // 使母片註解投影片及所有子投影片編號佔位符可見
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // 使母片註解投影片及所有子日期與時間佔位符可見

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // 為母片註解投影片及所有子頁首佔位符設定文字
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // 為母片註解投影片及所有子頁腳佔位符設定文字
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // 為母片註解投影片及所有子日期與時間佔位符設定文字
    }

    // 僅更改第一張註解投影片的頁首與頁尾設定
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // 使此註解投影片的頁首佔位符可見

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // 使此註解投影片的頁腳佔位符可見

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // 使此註解投影片的投影片編號佔位符可見

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // 使此註解投影片的日期時間佔位符可見

        headerFooterManager.setHeaderText("New header text"); // 為註解投影片的頁首佔位符設定文字
        headerFooterManager.setFooterText("New footer text"); // 為註解投影片的頁腳佔位符設定文字
        headerFooterManager.setDateTimeText("New date and time text"); // 為註解投影片的日期時間佔位符設定文字
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問答**

**我可以在一般投影片加入「頁首」嗎？**

在 PowerPoint 中，「頁首」僅存在於註解與講義；在一般投影片上，支援的元素只有頁尾、日期/時間與投影片編號。Aspose.Slides 亦遵循相同限制：頁首僅適用於註解/講義，而在投影片上則為頁尾/日期時間/投影片編號。

**如果版面配置沒有頁尾區域，我能「開啟」其可見性嗎？**

可以。透過頁首/頁尾管理器檢查其可見性，必要時將其啟用。這些 API 指標與方法是為佔位符缺失或隱藏的情況所設計。

**我要如何讓投影片編號從非 1 的值開始？**

設定簡報的[first slide number](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-); 之後所有編號會重新計算。例如，您可以從 0 或 10 開始，並在標題投影片上隱藏編號。

**匯出為 PDF/圖像/HTML 時，頁首/頁尾會怎樣？**

它們會被渲染為簡報的普通文字元素。也就是說，只要這些元素在投影片或註解頁面上可見，於輸出格式中也會與其他內容一起顯示。