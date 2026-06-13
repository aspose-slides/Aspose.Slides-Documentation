---
title: تبدیل ارائه‌ها به HTML5 در PHP
linktitle: ارائه به HTML5
type: docs
weight: 40
url: /fa/php-java/export-to-html5/
keywords:
- PowerPoint به HTML5
- OpenDocument به HTML5
- ارائه به HTML5
- اسلاید به HTML5
- PPT به HTML5
- PPTX به HTML5
- ODP به HTML5
- ذخیره PPT به‌عنوان HTML5
- ذخیره PPTX به‌عنوان HTML5
- ذخیره ODP به‌عنوان HTML5
- صدور PPT به HTML5
- صدور PPTX به HTML5
- صدور ODP به HTML5
- PHP
- Aspose.Slides
description: "صادر کردن ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای PHP از طریق Java. حفظ قالب‌بندی، انیمیشن‌ها و تعامل."
---
## **مروری کلی**

این مقاله نحوه تبدیل ارائه‌های PowerPoint به HTML5 با استفاده از Aspose.Slides را توضیح می‌دهد. این مقاله صادرات پایه HTML5 را بدون افزونه‌های وب یا وابستگی‌های اضافه پوشش می‌دهد و همچنین گزینه‌هایی برای کنترل انیمیشن‌های شکل و انتقال‌های اسلاید ارائه می‌کند. مقاله همچنین فرآیند استاندارد صادرات PowerPoint به HTML را نشان می‌دهد، نحوه تولید خروجی HTML5 در حالت نمای اسلاید را توضیح می‌دهد و نشان می‌دهد چگونه می‌توان با پیکربندی چیدمان، نظرات را در سند صادرشده گنجاند.

## **صادرات پاورپوینت به HTML5**

این کد PHP نشان می‌دهد چگونه یک ارائه را بدون افزونه‌های وب و وابستگی‌ها به HTML5 صادر کنید:

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
در این حالت، HTML تمیز دریافت می‌کنید.
{{% /alert %}}

ممکن است بخواهید تنظیمات انیمیشن‌های شکل و انتقال‌های اسلاید را به این صورت مشخص کنید:

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

## **صادرات پاورپوینت به HTML**

این مثال Java فرآیند استاندارد صادرات PowerPoint به HTML را نشان می‌دهد:

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

در این حالت، محتویات ارائه از طریق SVG به شکل زیر رندر می‌شود:

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

سند «output.html» در تصویر زیر نشان داده شده است.

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **سوالات متداول**

**آیا می‌توانم کنترل کنم که انیمیشن‌های اشیاء و انتقال‌های اسلاید در HTML5 اجرا شوند؟**

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/fa/php-java/aspose.slides/html5options/setanimateshapes/) و [slide transitions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/html5options/setanimatetransitions/) فراهم می‌کند.

**آیا خروجی نظرات پشتیبانی می‌شود و می‌توان آنها را نسبت به اسلاید کجا قرار داد؟**

بله، می‌توان نظرات را در HTML5 اضافه کرد و از طریق [layout settings](https://reference.aspose.com/slides/fa/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) برای یادداشت‌ها و نظرات، موقعیت آنها (به‌عنوان مثال، سمت راست اسلاید) تنظیم کرد.

**آیا می‌توانم لینک‌هایی که جاوااسکریپت را فراخوانی می‌کنند برای دلایل امنیتی یا CSP حذف کنم؟**

بله، یک [setting](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) وجود دارد که اجازه می‌دهد هنگام ذخیره‌سازی، پیوندهای حاوی فراخوانی‌های JavaScript نادیده گرفته شوند. این به رعایت سیاست‌های امنیتی سخت کمک می‌کند.