---
title: 使用 .NET 的 Node.js 建立簡報
linktitle: 建立簡報
type: docs
weight: 10
url: /zh-hant/nodejs-net/create-presentation/
keywords:
- 建立簡報
- 新簡報
- 建立 PowerPoint
- 建立 PPTX
- 新增文字方塊
- 新增投影片
- 投影片大小
- 寬螢幕
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via .NET 在 JavaScript 中建立 PowerPoint 簡報：新增文字方塊和投影片，設定 16:9 投影片大小，並將結果儲存為 PPTX。"
---
## **概覽**

本文章說明如何使用 Aspose.Slides for Node.js via .NET 建立簡報、在第一張投影片上新增文字方塊，並將結果另存為 PPTX 檔案。同時說明如何新增投影片以及如何將簡報切換為寬螢幕 (16:9) 投影片。

這些範例需要依照[安裝](/slides/zh-hant/nodejs-net/installation/)中描述的方式建立專案。將每個範例儲存為 `.js` 檔案於專案資料夾中，並使用 `node` 從該資料夾執行，例如 `node create-presentation.js`。

{{% alert color="info" title="注意" %}}
Aspose.Slides for Node.js via .NET 本身沒有 API 參考文件。它以 camelCase 名稱鏡像 Aspose.Slides for .NET API，因此本文中的 API 連結會指向 [Aspose.Slides for .NET API 參考文件](https://reference.aspose.com/slides/net/)。
{{% /alert %}}

## **建立包含文字方塊的簡報**

若要建立簡報並在第一張投影片上放置文字方塊，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 類別的實例。新簡報已預先包含一張空白投影片。
2. 從 [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 集合取得該投影片。此套件中的集合以 `get(index)` 讀取，且索引值從 0 開始。
3. 使用 [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) 方法加入矩形，並設定其 [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) 的 [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/)。
4. 使用 [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法，搭配 `SaveFormat.Pptx` 值，將簡報儲存。
5. 在 `finally` 區塊中呼叫 `dispose`，以釋放支援簡報的 .NET 資源。

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 位置 (x, y) 與大小 (寬度, 高度) 以點為單位。
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

此腳本會將 `new-presentation.pptx` 寫入專案資料夾。該檔案包含一張投影片，內有一個已填色的矩形，其左上角距投影片左邊與上邊各 50 點。矩形寬 400 點、高 100 點，文字置中。1 點等於 1/72 吋。若未使用授權，Aspose.Slides 亦會在投影片上加入評估水印；請參閱[授權](/slides/zh-hant/nodejs-net/licensing/)。

## **新增投影片**

新簡報僅含一張投影片。若要新增投影片，請將版面配置投影片傳遞給 `slides` 集合的 [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) 方法。[layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) 集合的 [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) 方法會回傳指定 [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/) 的第一個版面配置。

以下範例使用 Blank 版面配置新增兩張投影片：

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此腳本會輸出 `Slide count: 3` 並產生 `three-slides.pptx`。新投影片會被加入在第一張之後，且不包含任何圖形。新簡報始終具有 Blank 版面配置，但從檔案開啟的簡報可能沒有請求類型的版面配置；在此情況下 `getByType` 會回傳 `null`，因此在傳遞之前請先檢查結果。

## **設定投影片大小**

新簡報使用 4:3 投影片，尺寸為 720 × 540 點（10 × 7.5 吋）。若要改為寬螢幕投影片，請以 [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) 以及 [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) 的值，呼叫簡報的 [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) 的 [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) 方法。比例類型告訴 Aspose.Slides 該如何處理已存在於投影片上的圖形；`DoNotScale` 會保持原樣，這是尚未有內容的簡報的正確選擇。

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此腳本會輸出 `Slide size: 960 x 540 points`，即 13.33 × 7.5 吋，並產生 `widescreen.pptx`。`SlideSizeType.OnScreen16x9` 具有相同的 16:9 長寬比，但尺寸較小：720 × 405 點。

## **常見問題**

**位置和大小以何種單位測量？**

使用點（point）為單位。1 吋等於 72 點，因此預設的 4:3 投影片為 720 × 540 點，16:9 寬螢幕投影片則為 960 × 540 點。

**我可以將新簡報儲存為哪些格式？**

使用 [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) 列舉中的任意值，例如 `SaveFormat.Ppt`（PowerPoint 97–2003）、`SaveFormat.Odp`（OpenDocument）或 `SaveFormat.Pdf`。若需輸出 PDF，請參閱[將 PowerPoint 轉換為 PDF](/slides/zh-hant/nodejs-net/convert-powerpoint-to-pdf/)。

**為何已儲存的簡報會包含「Evaluation only」文字？**

未取得授權時，Aspose.Slides 會在其儲存的投影片上加入評估水印。依照[授權](/slides/zh-hant/nodejs-net/licensing/)的說明套用授權，即可移除該水印。

**為何需要呼叫 `dispose`？**

`Presentation` 物件由一個 .NET 物件提供支援，該物件佔用記憶體與其他資源。呼叫 `dispose` 可在不再需要簡報時釋放這些資源，且在 `finally` 區塊中呼叫可確保即使發生錯誤也能釋放。