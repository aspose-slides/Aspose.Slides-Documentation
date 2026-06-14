---
title: 在 .NET 中存取簡報投影片
linktitle: 存取投影片
type: docs
weight: 20
url: /zh-hant/net/access-slide-in-presentation/
keywords:
- 存取投影片
- 投影片索引
- 投影片 ID
- 投影片位置
- 變更位置
- 投影片屬性
- 投影片編號
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 於 PowerPoint 與 OpenDocument 簡報中存取與管理投影片。透過程式碼範例提升工作效率。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 存取及管理簡報中的投影片。它展示了如何從 `Slides` 集合中以零基索引取得投影片，以及如何使用 `GetSlideById` 方法依唯一 ID 存取投影片。

您還將學習如何透過設定 `SlideNumber` 屬性變更投影片的位置，並使用 `FirstSlideNumber` 屬性定義簡報的起始投影片編號。範例示範了載入簡報、取得投影片參考、更新投影片順序或編號，並儲存已修改的簡報。

## **透過索引存取投影片**

簡報中的所有投影片皆依投影片位置以數值方式排列，從 0 開始。第一張投影片可透過索引 0 存取；第二張投影片可透過索引 1 存取；以此類推。

Presentation 類別代表簡報檔案，會將所有投影片以 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection)（由 [ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/) 物件組成的集合）形式公開。以下 C# 程式碼示範如何依索引存取投影片：

```c#
// 實例化一個代表簡報檔案的 Presentation 物件
Presentation presentation = new Presentation("AccessSlides.pptx");

// 透過索引取得投影片的參考
ISlide slide = presentation.Slides[0];
```

## **透過 ID 存取投影片**

簡報中的每張投影片皆有唯一的 ID。您可以使用 [GetSlideById](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/methods/getslidebyid) 方法（由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別公開）針對該 ID。以下 C# 程式碼示範如何提供有效的投影片 ID，並透過 [GetSlideById](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/methods/getslidebyid) 方法存取該投影片：

```c#
// 實例化一個代表簡報檔案的 Presentation 物件
Presentation presentation = new Presentation("AccessSlides.pptx");

// 取得投影片 ID
uint id = presentation.Slides[0].SlideId;

// 透過 ID 存取投影片
IBaseSlide slide = presentation.GetSlideById(id);
```

## **變更投影片位置**

Aspose.Slides 允許您變更投影片的位置。例如，您可以指定將第一張投影片改為第二張。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
1. 透過索引取得要變更位置的投影片參考  
1. 使用 [SlideNumber](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/slidenumber/) 屬性設定投影片的新位置。  
1. 儲存已修改的簡報。

以下 C# 程式碼示範將位置 1 的投影片移動到位置 2 的操作：

```c#
// 實例化一個代表簡報檔案的 Presentation 物件
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // 取得將被變更位置的投影片
    ISlide sld = pres.Slides[0];

    // 設定投影片的新位置
    sld.SlideNumber = 2;

    // 儲存已修改的簡報
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

第一張投影片變成第二張；第二張投影片變成第一張。變更投影片位置時，其他投影片會自動調整。

## **設定投影片編號**

使用 [FirstSlideNumber](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/firstslidenumber/) 屬性（由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別公開），您可以為簡報的第一張投影片指定新的編號。此操作會重新計算其他投影片的編號。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。  
1. 取得投影片編號。  
1. 設定投影片編號。  
1. 儲存已修改的簡報。

以下 C# 程式碼示範將第一張投影片編號設定為 10 的操作：

```c#
// 實例化一個代表簡報檔案的 Presentation 物件
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // 取得投影片編號
    int firstSlideNumber = presentation.FirstSlideNumber;

    // 設定投影片編號
    presentation.FirstSlideNumber=10;
    
    // 儲存已修改的簡報
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

如果您想略過第一張投影片，亦可從第二張投影片開始編號（並隱藏第一張投影片的編號），如下所示：

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // 設定簡報第一張投影片的編號
    presentation.FirstSlideNumber = 0;

    // 顯示所有投影片的投影片編號
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // 隱藏第一張投影片的投影片編號
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // 儲存已修改的簡報
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **常見問答**

**使用者看到的投影片編號是否與集合的零基索引相同？**  
投影片上顯示的編號可以從任意值開始（例如 10），不一定要與索引相符；兩者的關係由簡報的 [first slide number](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/firstslidenumber/) 設定所控制。

**隱藏的投影片會影響索引嗎？**  
會。隱藏的投影片仍然存在於集合中，且在索引時會被計算；「隱藏」指的是顯示狀態，而非其在集合中的位置。

**當加入或移除其他投影片時，投影片的索引會變動嗎？**  
會。索引始終反映投影片的當前順序，並在插入、刪除或移動操作時重新計算。