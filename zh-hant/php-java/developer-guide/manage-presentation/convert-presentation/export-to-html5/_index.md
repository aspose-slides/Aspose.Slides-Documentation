---
title: 在 PHP 中將簡報轉換為 HTML5
linktitle: 簡報轉換為 HTML5
type: docs
weight: 40
url: /zh-hant/php-java/export-to-html5/
keywords:
- PowerPoint 轉換為 HTML5
- OpenDocument 轉換為 HTML5
- 簡報 轉換為 HTML5
- 投影片 轉換為 HTML5
- PPT 轉換為 HTML5
- PPTX 轉換為 HTML5
- ODP 轉換為 HTML5
- 將 PPT 儲存為 HTML5
- 將 PPTX 儲存為 HTML5
- 將 ODP 儲存為 HTML5
- 匯出 PPT 為 HTML5
- 匯出 PPTX 為 HTML5
- 匯出 ODP 為 HTML5
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（透過 Java）將 PowerPoint 與 OpenDocument 簡報匯出為響應式 HTML5。保留格式、動畫與互動性。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 HTML5。內容涵蓋不含 Web 擴充功能或其他相依性的基本 HTML5 匯出，以及控制形狀動畫與投影片轉場的選項。本文亦展示標準的 PowerPoint 到 HTML 匯出流程、說明如何在投影片檢視模式下產生 HTML5 輸出，並示範如何透過設定佈局將評論包含在匯出文件中。

## **匯出 PowerPoint 為 HTML5**

以下 PHP 程式碼展示如何在不使用 Web 擴充功能和相依性的情況下將簡報匯出為 HTML5：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
在此情況下，您會得到乾淨的 HTML。 
{{% /alert %}}

您也可以這樣指定形狀動畫與投影片轉場的設定：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **匯出 PowerPoint 為 HTML**

以下 Java 程式碼示範標準的 PowerPoint 轉 HTML 流程：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

在此情況下，簡報內容會以 SVG 形式呈現，如下所示：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="Note" color="warning" %}} 

When you use this method to export PowerPoint to HTML, due to the SVG rendering, you will not be to apply styles or animate specific elements. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** allows you to convert a PowerPoint presentation to an HTML5 document in which the slides are presented in a slide view mode. In this case, when you open the resulting HTML5 file in a browser, you see the presentation in slide view mode on a web page. 

This PHP code demonstrates the PowerPoint to HTML5 Slide View export process:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convert Presentations to HTML5 Documents with Comments**

Comments in PowerPoint are a tool that allows users to leave notes or feedback on presentation slides. They are especially useful in collaborative projects, where multiple people can add their suggestions or remarks to specific slide elements without altering the main content. Each comment shows the author's name, making it easy to track who left the remark.

Let's say we have the following PowerPoint presentation saved in the "sample.pptx" file.

![Two comments on the presentation slide](two_comments_pptx.png)

When you convert a PowerPoint presentation to an HTML5 document, you can easily specify whether to include comments from the presentation in the output document. To do this, you need to specify the display parameters for comments in the `getNotesCommentsLayouting` method of the `Html5Options` class.

The following code example converts a presentation to an HTML5 document with comments displayed to the right of the slides.
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();

以下圖示顯示了「output.html」文件的畫面：

![輸出 HTML5 文件中的評論](two_comments_html5.png)

## **常見問題**

**我可以控制物件動畫與投影片轉場是否在 HTML5 中播放嗎？**

可以，HTML5 提供獨立的選項來啟用或停用 [形狀動畫](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/html5options/setanimateshapes/) 與 [投影片轉場](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/html5options/setanimatetransitions/)。

**是否支援輸出評論？它們可以相對於投影片放置在哪裡？**

可以，透過 [版面配置設定](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) 可在 HTML5 中加入評論，並將其定位（例如放在投影片右側）。

**我可以為了安全性或 CSP 考量跳過包含 JavaScript 的連結嗎？**

可以，存在一個 [設定](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 讓您在儲存時略過帶有 JavaScript 呼叫的超連結，協助符合嚴格的安全政策。