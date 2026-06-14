---
title: 在 PHP 中將 PPTX 轉換為 PPT
linktitle: PPTX 轉 PPT
type: docs
weight: 21
url: /zh-hant/php-java/convert-pptx-to-ppt/
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
- PHP
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides 將 PPTX 轉換為 PPT — 確保與 PowerPoint 格式的無縫相容性，同時保留簡報的版面配置與品質。"
---
## **概述**

本文說明如何使用 PHP 將 PPTX 格式的 PowerPoint 簡報轉換為 PPT 格式。涵蓋以下主題。

- 將 PPTX 轉換為 PPT

## **在 PHP 中將 PPTX 轉換為 PPT**

如需將 PPTX 轉換為 PPT 的 Java 範例程式碼，請參閱以下章節，即[Convert PPTX to PPT](#convert-pptx-to-ppt)。它僅載入 PPTX 檔案並以 PPT 格式儲存。透過指定不同的儲存格式，您亦可將 PPTX 檔案存為 PDF、XPS、ODP、HTML 等多種格式，如這些文章所討論。

- [將 PPTX 轉換為 PDF（PHP）](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)
- [將 PPTX 轉換為 XPS（PHP）](/slides/zh-hant/php-java/convert-powerpoint-to-xps/)
- [將 PPTX 轉換為 HTML（PHP）](/slides/zh-hant/php-java/convert-powerpoint-to-html/)
- [將 PPTX 轉換為 ODP（PHP）](/slides/zh-hant/php-java/save-presentation/)
- [將 PPTX 轉換為 PNG（PHP）](/slides/zh-hant/php-java/convert-powerpoint-to-png/)

## **將 PPTX 轉換為 PPT**
要將 PPTX 轉換為 PPT，只需將檔名與儲存格式傳遞給 [**Presentation**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的 **Save** 方法。以下 PHP 程式碼範例使用預設選項將 Presentation 從 PPTX 轉換為 PPT。

```php
  # 實例化一個表示 PPTX 檔案的 Presentation 物件
  $presentation = new Presentation("template.pptx");
  # 將簡報儲存為 PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **常見問題**

**所有 PPTX 的效果與功能在儲存為舊版 PPT（97–2003）格式時是否都能保留？**

不一定。PPT 格式缺少某些較新的功能（例如特定的效果、物件與行為），因此在轉換過程中可能會被簡化或轉為點陣圖。

**我可以只將選取的投影片轉換為 PPT，而不是整份簡報嗎？**

直接儲存會針對整個簡報。若要轉換特定投影片，請先建立只包含那些投影片的新簡報，然後將其儲存為 PPT；或者使用支援每張投影片轉換參數的服務/API。

**是否支援受密碼保護的簡報？**

是。您可以偵測檔案是否受保護，使用密碼開啟，並且也能為儲存的 PPT 設定[保護/加密設定](/slides/zh-hant/php-java/password-protected-presentation/)。