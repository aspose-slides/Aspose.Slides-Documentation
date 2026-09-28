---
title: قالب‌های فایل پشتیبانی‌شده
type: docs
weight: 20
url: /fa/jasperreports/supported-file-formats/
description: "مشاهده کنید Aspose.Slides for JasperReports چه ورودی می‌گیرد و به چه قالب‌های فایل گزارش‌ها را صادر می‌کند."
---
## **ورودی**

Aspose.Slides for JasperReports گزارش‌ها را صادر می‌کند؛ اما ارائه‌های موجود را تبدیل نمی‌کند. خروجی‌کننده‌های آن یک گزارش پر شده JasperReports (`JasperPrint`) را می‌گیرند، مانند نتیجهٔ `JasperFillManager` یا گزارشی پر شده که از یک فایل *.jrprint* بارگذاری شده است.

## **قالب‌های خروجی**

جدول زیر قالب‌هایی را که Aspose.Slides for JasperReports یک گزارش را به آن‌ها صادر می‌کند، و کلاس خروجی‌کننده‌ای که هر یک را می‌نویسد، فهرست می‌کند.

|**قالب**|**توضیح**|**خروجی‌کننده**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|ارائه PowerPoint 97–2003؛ یک اسلاید برای هر صفحهٔ گزارش|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|ارائه PowerPoint (Office Open XML)؛ یک اسلاید برای هر صفحهٔ گزارش|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|قالب سند قابل حمل (PDF)؛ یک صفحه PDF برای هر صفحهٔ گزارش|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|یک فایل HTML واحد با یک تصویر SVG برای هر صفحهٔ گزارش|`ASHtmlExporter`|

هیچ خروجی‌کننده‌ای برای قالب‌های اسلاید شو PPS و PPSX وجود ندارد. اختصاص یک نام فایل *.ppsx* به خروجی PPTX همچنان یک ارائه PPTX تولید می‌کند، نه یک اسلاید شو. برای مشاهدهٔ نحوه استفاده از هر خروجی‌کننده، به [صدور PPT، PPTX، PDF و HTML](/slides/fa/jasperreports/ppt-pptx-pdf-and-html-export/) مراجعه کنید.