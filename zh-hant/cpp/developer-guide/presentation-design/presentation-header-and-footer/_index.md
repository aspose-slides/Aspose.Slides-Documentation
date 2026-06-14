---
title: 管理 C++ 簡報的頁首與頁尾
linktitle: 頁首與頁尾
type: docs
weight: 140
url: /zh-hant/cpp/presentation-header-and-footer/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 為 PowerPoint 與 OpenDocument 簡報新增並自訂頁首與頁尾，以達到專業外觀。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中管理頁首和頁尾設定。頁首與頁尾在簡報母片層級上處理，且 API 提供設定頁尾文字、變更頁尾可見性，以及在主註解投影片上更新頁首文字的方法。

您亦可管理講義與註解投影片的頁首與頁尾。這包括變更註解母片、所有子註解投影片，或單一註解投影片之頁首、頁尾、投影片編號與日期時間佔位符的可見性與文字。

## **管理頁首與頁尾文字**

以下範例顯示如何更新某些特定投影片的註解：

``` cpp
// 設定頁首/頁尾文字的函式
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// 載入簡報
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// 設定頁尾
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// 存取並更新頁首
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// 儲存簡報
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **在講義與註解投影片上管理頁首與頁尾**
Aspose.Slides for C++ 支援在講義與註解投影片上的頁首與頁尾。請依照以下步驟操作：

- 載入包含影片的 [Presentation ](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation)。
- 變更註解母片及所有註解投影片的頁首與頁尾設定。
- 將母片註解投影片與所有子投影片的頁尾佔位符設為可見。
- 將母片註解投影片與所有子投影片的日期與時間佔位符設為可見。
- 僅變更第一張註解投影片的頁首與頁尾設定。
- 設定註解投影片的頁首佔位符可見。
- 設定註解投影片頁首佔位符的文字。
- 設定註解投影片日期時間佔位符的文字。
- 寫入已修改的簡報檔案。

以下範例中提供了程式碼片段。

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// 更改註解母片與所有註解投影片的頁首與頁尾設定
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    // 使母片註解投影片及所有子頁腳佔位符可見
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
    // 使母片註解投影片及所有子頁首佔位符可見
    headerFooterManager->SetFooterAndChildFootersVisibility(true);
    // 使母片註解投影片及所有子投影片編號佔位符可見
    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
    // 使母片註解投影片及所有子日期與時間佔位符可見
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    // 設定母片註解投影片及所有子頁首佔位符的文字
    headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
    // 設定母片註解投影片及所有子頁腳佔位符的文字
    headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
    // 設定母片註解投影片及所有子日期與時間佔位符的文字
    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// 僅更改第一張註解投影片的頁首與頁尾設定
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
    auto headerFooterManager = notesSlide->get_HeaderFooterManager();
    if (!headerFooterManager->get_IsHeaderVisible())
    {
        // 使此註解投影片的頁首佔位符可見
        headerFooterManager->SetHeaderVisibility(true);
    }

    if (!headerFooterManager->get_IsFooterVisible())
    {
        // 使此註解投影片的頁腳佔位符可見
        headerFooterManager->SetFooterVisibility(true);
    }

    if (!headerFooterManager->get_IsSlideNumberVisible())
    {
        // 使此註解投影片的投影片編號佔位符可見
        headerFooterManager->SetSlideNumberVisibility(true);
    }
    
    if (!headerFooterManager->get_IsDateTimeVisible())
    {
        // 使此註解投影片的日期時間佔位符可見
        headerFooterManager->SetDateTimeVisibility(true);
    }
    
    // 設定註解投影片的頁首佔位符文字
    headerFooterManager->SetHeaderText(u"New header text");
    // 設定註解投影片的頁腳佔位符文字
    headerFooterManager->SetFooterText(u"New footer text");
    // 設定註解投影片的日期時間佔位符文字
    headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **常見問題**

**我可以在一般投影片上加入「頁首」嗎？**

在 PowerPoint 中，「頁首」僅存在於註解與講義；在一般投影片上，支援的元素只有頁尾、日期/時間以及投影片編號。Aspose.Slides 亦遵循相同的限制：頁首僅適用於註解/講義，而投影片則支援頁尾/日期時間/投影片編號。

**如果版面配置沒有頁尾區域，我可以「開啟」其可見性嗎？**

可以。可透過頁首/頁尾管理器檢查其可見性，必要時將其啟用。這些 API 標示與方法是針對佔位符缺失或被隱藏的情況所設計的。

**如何讓投影片編號從非 1 的值開始？**

設定簡報的 [first slide number](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/set_firstslidenumber/)；之後所有編號會重新計算。例如，可從 0 或 10 開始，並在標題投影片上隱藏編號。

**匯出為 PDF/影像/HTML 時，頁首/頁尾會怎樣？**

它們會作為簡報的普通文字元素呈現。也就是說，只要這些元素在投影片或註解頁面上可見，匯出後的檔案中也會與其他內容一同顯示。