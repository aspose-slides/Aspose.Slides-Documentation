---
title: 套用或變更 C++ 投影片佈局
linktitle: 投影片佈局
type: docs
weight: 60
url: /zh-hant/cpp/slide-layout/
keywords:
- 投影片佈局
- 內容佈局
- 佔位元件
- 簡報設計
- 投影片設計
- 未使用佈局
- 頁腳可見性
- 標題投影片
- 標題與內容
- 區段標題
- 兩欄內容
- 比較
- 只有標題
- 空白佈局
- 內容加說明文字
- 圖片加說明文字
- 標題與垂直文字
- 垂直標題與文字
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中管理與自訂投影片佈局。透過 C++ 程式碼範例探索佈局類型、佔位元件控制與頁腳可見性。"
---
## **簡介**

投影片佈局定義了投影片上佔位盒的排列方式與內容格式。它控制哪些佔位元件可用以及它們出現的位置。投影片佈局可協助您快速且一致地設計簡報——無論是建立簡單或較複雜的內容。PowerPoint 中最常見的投影片佈局包括：

**標題投影片佈局** – 包含兩個文字佔位元件：一個用於標題，另一個用於副標題。

**標題與內容佈局** – 在上方有較小的標題佔位元件，下方則有較大的主內容佔位元件（如文字、項目符號、圖表、影像等）。

**空白佈局** – 不含任何佔位元件，讓您可以從頭開始設計投影片。

投影片佈局是投影片母片的一部分，母片是定義簡報佈局樣式的最高層投影片。您可以透過母片存取並修改佈局投影片——可依類型、名稱或唯一 ID 取得。或者，也可以直接在簡報內編輯特定的佈局投影片。

在 Aspose.Slides for Android 中使用投影片佈局，您可以使用：

- 方法，例如 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別下的 [get_LayoutSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_layoutslides/) 與 [get_Masters](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_masters/)  
- 類型，如 [ILayoutSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/)、[IMasterLayoutSlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterlayoutslidecollection/)、[ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/)，以及 [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
欲了解更多關於使用母片的資訊，請參閱 [Slide Master](/slides/zh-hant/cpp/slide-master/) 文章。
{{% /alert %}}

## **將投影片佈局新增至簡報**

若要自訂投影片的外觀與結構，您可能需要在簡報中新增版面配置投影片。Aspose.Slides for Android 可讓您檢查特定佈局是否已存在，必要時新增，並以之插入使用該佈局的投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 存取 [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterlayoutslidecollection/)。  
3. 檢查所需的佈局投影片是否已存在於集合中。若不存在，則加入所需的佈局投影片。  
4. 根據新佈局投影片新增一張空白投影片。  
5. 儲存簡報。

以下 C++ 程式碼示範如何將投影片佈局新增至 PowerPoint 簡報：

```cpp
// 建立代表 PowerPoint 檔案的 Presentation 類別實例。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// 逐一檢查版面投影片類型以選取佈局投影片。
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // 簡報未包含所有佈局類型的情況。
    // 簡報檔案僅包含空白與自訂佈局類型。
    // 但是，自訂類型的佈局投影片可能具有可辨識的名稱，
    // 例如「Title」、「Title and Content」等，可用於選取佈局投影片。
    // 也可以依賴一組佔位形狀類型。
    // 例如，標題投影片應僅有 Title 佔位元件類型，依此類推。
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Add an empty slide using the added layout slide.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Save the presentation to disk.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **移除未使用的佈局投影片**

Aspose.Slides 於 [Compress](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/) 類別提供了 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法，可讓您刪除不需要且未使用的佈局投影片。

以下 C++ 程式碼示範如何從 PowerPoint 簡報中移除佈局投影片：

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **在投影片佈局中新增佔位元件**

Aspose.Slides 提供了 [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) 方法，允許您在佈局投影片中新增佔位元件。

此管理器包含以下佔位元件類型的方法：

| PowerPoint 佔位元件 | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutplaceholdermanager/) 方法 |
| ------------------- | ------------------------------------------------------------ |
| ![內容](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![內容（垂直）](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![文字](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![文字（垂直）](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![圖片](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![圖表](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![表格](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![媒體](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![線上影像](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

以下 C++ 程式碼示範如何在 Blank 佈局投影片中新增佔位形狀：

```cpp
auto presentation = MakeObject<Presentation>();

// 取得空白版面投影片。
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// 取得版面投影片的佔位元件管理器。
auto placeholderManager = layout->get_PlaceholderManager();

// 在空白版面投影片上新增不同的佔位元件。
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Add a new slide with the Blank layout.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![版面投影片上的佔位元件](add_placeholders.png)

## **設定佈局投影片的頁腳可見性**

在 PowerPoint 簡報中，頁腳元素（如日期、投影片編號與自訂文字）可依投影片佈局顯示或隱藏。Aspose.Slides for Android 允許您控制這些頁腳佔位元件的可見性。當您希望特定佈局顯示頁腳資訊，而其他佈局保持簡潔時，這非常有用。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得佈局投影片的參考。  
3. 將投影片頁腳佔位元件設為可見。  
4. 將投影片編號佔位元件設為可見。  
5. 將日期時間佔位元件設為可見。  
6. 儲存簡報。

以下 C++ 程式碼示範如何設定投影片頁腳的可見性以及相關操作：

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **設定子投影片的頁腳可見性**

在 PowerPoint 簡報中，日期、投影片編號與自訂文字等頁腳元素可在母片層級進行控制，以確保所有佈局投影片的一致性。Aspose.Slides for Android 允許您在母片上設定這些頁腳佔位元件的可見性與內容，並將此設定傳遞至所有子佈局投影片。此方式可確保整個簡報的頁腳資訊一致。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 依索引取得母片的參考。  
3. 將母片及所有子投影片的頁腳佔位元件設為可見。  
4. 將母片及所有子投影片的投影片編號佔位元件設為可見。  
5. 將母片及所有子投影片的日期時間佔位元件設為可見。  
6. 儲存簡報。

以下 C++ 程式碼示範此操作：

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問題**

**母片與佈局投影片有何不同？**

母片定義整體主題與預設格式，而佈局投影片則定義針對不同類型內容的特定佔位元件排列方式。

**我可以將佈局投影片從一個簡報複製到另一個嗎？**

可以，您可以透過 [get_LayoutSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_layoutslides/) 方法取得的佈局投影片集合，將佈局投影片克隆，然後使用 `AddClone` 方法將其插入另一個簡報。

**如果刪除仍被投影片使用的佈局投影片會發生什麼情況？**

如果嘗試刪除仍被簡報中至少一張投影片參照的佈局投影片，Aspose.Slides 會拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxeditexception/)。為避免此情況，請使用 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)，它僅安全地移除未被使用的佈局投影片。