---
title: 在 Java 中管理簡報的頁首與頁腳
linktitle: 頁首與頁腳
type: docs
weight: 140
url: /zh-hant/java/presentation-header-and-footer/
keywords:
- 頁首
- 頁首文字
- 頁腳
- 頁腳文字
- 設定頁首
- 設定頁腳
- 講義
- 備註
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 和 OpenDocument 簡報中新增與自訂頁首與頁腳，打造專業外觀。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中管理頁首與頁腳設定。頁首與頁腳在簡報主母片層級上處理，API 提供設定頁腳文字、變更頁腳可見性以及在主備註投影片上更新頁首文字的方法。

您也可以管理講義與備註投影片的頁首與頁腳。這包括變更備註主母片、所有子備註投影片或單一備註投影片的頁首、頁腳、投影片編號與日期時間佔位符的可見性與文字。

## **在簡報中管理頁首與頁腳**
某些特定投影片的備註可能會被移除，範例如下：

```java
// 載入簡報
Presentation pres = new Presentation("headerTest.pptx");
try {
    // 設定頁腳
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // 存取並更新頁首
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
// 設定頁首/頁腳文字的方法
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

## **在講義與備註投影片上管理頁首與頁腳**
Aspose.Slides for Java 支援在講義與備註投影片上使用頁首與頁腳。請依照以下步驟操作：

- 載入包含影片的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation)。
- 變更備註主母片與所有備註投影片的頁首與頁腳設定。
- 設定主備註投影片與所有子 Footer 佔位符為可見。
- 設定主備註投影片與所有子 Date and time 佔位符為可見。
- 僅變更第一張備註投影片的頁首與頁腳設定。
- 設定備註投影片的 Header 佔位符為可見。
- 為備註投影片的 Header 佔位符設定文字。
- 為備註投影片的 Date-time 佔位符設定文字。
- 寫入已修改的簡報檔案。

以下範例提供代碼片段。

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // 變更備註主母片與所有備註投影片的頁首與頁腳設定
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // 使主備註投影片與所有子 Footer 佔位符可見
        headerFooterManager.setFooterAndChildFootersVisibility(true); // 使主備註投影片與所有子 Header 佔位符可見
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // 使主備註投影片與所有子 SlideNumber 佔位符可見
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // 使主備註投影片與所有子 Date and time 佔位符可見

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // 設定文字至主備註投影片與所有子 Header 佔位符
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // 設定文字至主備註投影片與所有子 Footer 佔位符
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // 設定文字至主備註投影片與所有子 Date and time 佔位符
    }

    // 僅變更第一張備註投影片的頁首與頁腳設定
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // 使此備註投影片的 Header 佔位符可見

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // 使此備註投影片的 Footer 佔位符可見

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // 使此備註投影片的 SlideNumber 佔位符可見

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // 使此備註投影片的 Date-time 佔位符可見

        headerFooterManager.setHeaderText("New header text"); // 設定文字至備註投影片的 Header 佔位符
        headerFooterManager.setFooterText("New footer text"); // 設定文字至備註投影片的 Footer 佔位符
        headerFooterManager.setDateTimeText("New date and time text"); // 設定文字至備註投影片的 Date-time 佔位符
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以在普通投影片上加入「頁首」嗎？**

在 PowerPoint 中，「頁首」僅存在於備註與講義上；普通投影片僅支援頁腳、日期/時間與投影片編號。Aspose.Slides 的限制與此相同：頁首僅適用於備註/講義，投影片上則為 Footer/DateTime/SlideNumber。

**如果版面沒有頁腳區域，我可以「開啟」其可見性嗎？**

可以。透過頁首/頁腳管理器檢查可見性，必要時將其啟用。這些 API 指示與方法已針對佔位符缺失或被隱藏的情況設計。

**如何讓投影片編號從非 1 的值開始？**

設定簡報的 [first slide number](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-); 之後所有編號會重新計算。例如，可從 0 或 10 開始，並在標題投影片上隱藏編號。

**匯出為 PDF/圖像/HTML 時，頁首/頁腳會發生什麼變化？**

它們會作為簡報的普通文字元素呈現。也就是說，若這些元素在投影片/備註頁面上可見，則在輸出格式中也會隨其他內容一起顯示。