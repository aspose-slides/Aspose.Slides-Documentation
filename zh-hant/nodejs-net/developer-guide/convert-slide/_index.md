---
title: 在 Node.js via .NET 中將簡報投影片轉換為影像
linktitle: 投影片轉影像
type: docs
weight: 40
url: /zh-hant/nodejs-net/convert-slide/
keywords:
- 轉換投影片
- 投影片轉影像
- 投影片轉 PNG
- 將投影片儲存為影像
- 渲染投影片
- 投影片縮圖
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via .NET 在 JavaScript 中將 PPTX、PPT 與 ODP 簡報的投影片渲染為 PNG 影像，可依比例係數或以像素為單位的精確大小輸出。"
---
## **概觀**

Aspose.Slides for Node.js via .NET 會將 PowerPoint 與 OpenDocument 簡報渲染為影像，例如在網頁上顯示投影片預覽。本篇文章示範兩種選擇影像尺寸的方法：相對於投影片大小的比例係數，以及以像素為單位的精確大小。兩個範例皆會儲存 PNG 檔案。

這些範例需要在您於 [Installation](/slides/zh-hant/nodejs-net/installation/) 中設定的專案資料夾內放置一個名為 `sample.pptx` 的簡報。任何 PowerPoint 簡報皆可使用。將每個範例另存為 `.js` 檔案於專案資料夾，並在該資料夾中使用 `node` 執行。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET 並沒有自己的 API 參考文件。它以 camelCase 名稱鏡像 Aspose.Slides for .NET 的 API，因為本文中的 API 連結會指向 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/zh-hant/net/)。
{{% /alert %}}

將投影片轉換為影像，請遵循以下步驟：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/presentation/) 建構函式開啟簡報。
2. 透過 `get(index)` 從 [slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slides/zh-hant/) 集合取得投影片。索引值從 0 開始。
3. 使用 `getImageWithScale` 或 `getImageWithImageSize` 轉換投影片。於 .NET API 參考文件中，兩者皆為 [Slide.GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage/) 的多載。它們會回傳對應 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 的影像物件。
4. 使用其 [save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/save/) 方法與 [ImageFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imageformat/) 值儲存影像，然後呼叫 `dispose` 方法。

## **將每張投影片轉換為 PNG 影像**

`getImageWithScale` 需要水平與垂直的比例係數。比例為 1 時，投影片的一點會對應影像的一個像素。以下範例以比例 2 轉換每張投影片：

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// 比例為 1 時，每點呈現一個像素；比例為 2 時寬度與高度皆加倍。
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

此腳本會為每張投影片寫入一個檔案，`slide_1.png`、`slide_2.png` 等，編號從 1 起。對於 16:9、每張投影片尺寸為 960 × 540 點的簡報，產生的影像為 1920 × 1080 像素。隱藏的投影片也會被渲染；若要跳過它們，請檢查投影片的 [hidden](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/hidden/) 屬性。每個影像皆在各自的 `finally` 區塊中呼叫 `dispose` 釋放，以在下一張投影片渲染前釋放資源。若未取得授權，影像會顯示評估水印；請參閱 [Licensing](/slides/zh-hant/nodejs-net/licensing/)。

## **將投影片轉換為指定尺寸的影像**

`getImageWithImageSize` 接受一個包含 `width` 與 `height`（單位為像素）的物件。以下範例將第一張投影片渲染為寬度 1280 像素，並依投影片大小計算高度，使影像保持投影片的長寬比：

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

[slideSize.size](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesize/size/) 屬性會回傳投影片的寬度與高度（單位為點）。對於 16:9 的簡報，腳本會輸出 `Saved a 1280 x 720 image` 並寫入 `slide_1_1280px.png`；對於 4:3 的簡報，影像尺寸為 1280 × 960 像素。

## **常見問題**

**為何未傳入參數的 `getImage` 產生的影像如此小？**

若未傳入參數，`getImage` 會以簡報尺寸的 20% 進行渲染，因此 960 × 540 點的投影片會變成 192 × 108 像素的影像。請使用 `getImageWithScale` 或 `getImageWithImageSize` 來指定大小。

**如何儲存 JPEG 或其他影像格式？**

將其他 `ImageFormat` 值傳入影像的 `save` 方法，例如 `image.save("slide_1.jpg", ImageFormat.Jpeg)`。格式取決於 `ImageFormat` 的值，而非檔案副檔名，請確保兩者保持一致。

**為何影像中的文字在 Linux 上顯示不同？**

Aspose.Slides 只能使用執行渲染的機器上已安裝的字型。當簡報使用的字型缺失（例如在一般 Linux 伺服器上缺少 Calibri），Aspose.Slides 會改用已安裝的字型取代，導致文字外觀與換行位置不同。請安裝簡報所使用的字型，以取得與 Windows 相同的影像。

**為何 `getThumbnailWithImageSize` 產生 TypeError 錯誤？**

套件的 README 使用了 `getThumbnailWithImageSize`，但套件中並無 `getThumbnail` 方法。請改用 `getImageWithImageSize`；它接受相同的 `{ width, height }` 參數。