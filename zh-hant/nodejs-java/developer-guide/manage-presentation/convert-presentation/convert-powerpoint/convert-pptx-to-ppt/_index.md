---
title: 在 JavaScript 中將 PPTX 轉換為 PPT
linktitle: PPTX 轉 PPT
type: docs
weight: 21
url: /zh-hant/nodejs-java/convert-pptx-to-ppt/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPTX
- PPTX 轉 PPT
- 將 PPTX 儲存為 PPT
- 匯出 PPTX 為 PPT
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 輕鬆將 PPTX 轉換為 PPT — 確保與 PowerPoint 格式的無縫相容性，同時保留簡報的版面配置與品質。"
---
## **概述**

本文說明如何使用 JavaScript 將 PPTX 格式的 PowerPoint 簡報轉換為 PPT 格式。涵蓋以下主題。

- 在 JavaScript 中將 PPTX 轉換為 PPT

## **JavaScript 轉換 PPTX 為 PPT**

有關在 JavaScript 中將 PPTX 轉換為 PPT 的範例程式碼，請參閱以下區段，即[將 PPTX 轉換為 PPT](#convert-pptx-to-ppt)。它僅載入 PPTX 檔案並以 PPT 格式儲存。透過指定不同的儲存格式，您也可以將 PPTX 檔案儲存為許多其他格式，如 PDF、XPS、ODP、HTML 等，如這些文章所討論。

- [在 JavaScript 中將 PPTX 轉換為 PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)
- [在 JavaScript 中將 PPTX 轉換為 XPS](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xps/)
- [在 JavaScript 中將 PPTX 轉換為 HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)
- [在 JavaScript 中將 PPTX 轉換為 ODP](/slides/zh-hant/nodejs-java/save-presentation/)
- [在 JavaScript 中將 PPTX 轉換為 PNG](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/)

## **將 PPTX 轉換為 PPT**

若要將 PPTX 轉換為 PPT，只需將檔名和儲存格式傳遞給 [**Presentation**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的 **Save** 方法。以下 JavaScript 程式碼範例使用預設選項將簡報從 PPTX 轉換為 PPT。

```javascript
// 實例化一個表示 PPTX 檔案的 Presentation 物件
var presentation = new aspose.slides.Presentation("template.pptx");
// 將簡報儲存為 PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **常見問題**

**在將檔案儲存為舊版 PPT (97–2003) 格式時，所有 PPTX 的效果和功能都會保留嗎？**

不一定。PPT 格式缺乏某些較新的功能（例如特定的效果、物件與行為），因此在轉換過程中可能會將功能簡化或光柵化。

**我能只將選取的投影片轉換為 PPT，而不是整個簡報嗎？**

直接儲存會針對整個簡報。若要轉換特定投影片，請建立僅包含這些投影片的新簡報並將其儲存為 PPT；或者使用支援每張投影片轉換參數的服務／API。

**是否支援受密碼保護的簡報？**

支援。您可以偵測檔案是否受保護，使用密碼開啟，亦可[設定保護/加密設定](/slides/zh-hant/nodejs-java/password-protected-presentation/)以儲存 PPT。