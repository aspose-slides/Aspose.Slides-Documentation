---
title: تبدیل ارائه‌های PowerPoint به PDF با یادداشت‌ها در Python
linktitle: PowerPoint به PDF با یادداشت‌ها
type: docs
weight: 50
url: /fa/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به PDF
- ارائه به PDF
- PPT به PDF
- PPTX به PDF
- ذخیره ارائه به عنوان PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- یادداشت‌های سخنران
- PDF با یادداشت‌ها
- Python
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PPT و PPTX به PDF با یادداشت‌های سخنران با استفاده از Aspose.Slides برای Python از طریق Java. مکان‌گذاری یادداشت را پیکربندی کنید و یادداشت‌های طولانی را حفظ نمایید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان ارائه‌های PowerPoint را به PDF همراه با یادداشت‌های سخنران تبدیل کرد با استفاده از Aspose.Slides برای Python از طریق Java. می‌توانید یادداشت‌ها را زیر هر اسلاید قرار داده و اجازه دهید یادداشت‌های طولانی به صفحات اضافی ادامه یابد. برای سایر تنظیمات خروجی PDF، به [Convert PowerPoint to PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) مراجعه کنید.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

از متد [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) برای خروجی گرفتن یک ارائه PPT یا PPTX به PDF استفاده کنید. برای گنجاندن یادداشت‌های سخنران، یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/) ایجاد کرده و متد [setNotesPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) آن را پیکربندی کنید. این طرح چیدمان را با استفاده از [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) به [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) اختصاص دهید.

مثال زیر فایل `sample.pptx` را بارگیری کرده و آن را به `output.pdf` صادر می‌کند به‌طوری که یادداشت‌های سخنران زیر اسلایدها قرار می‌گیرند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # پیکربندی گزینه‌های PDF برای رندر یادداشت‌های سخنران.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # ذخیره ارائه به صورت PDF با یادداشت‌های سخنران.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="یادداشت" %}}
همچنین می‌توانید از [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion) استفاده کنید.
{{% /alert %}}

## **پرسش‌های متداول**

**چگونه می‌توانم مانع قطع شدن یادداشت‌های بلند سخنران شوم؟**

از [NotesPositions.BottomFull](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notespositions/#BottomFull) استفاده کنید، همانطور که در مثال بالا نشان داده شده است. این تنظیم تمام یادداشت‌ها را نمایش می‌دهد و در صورت نیاز از صفحات اضافی استفاده می‌کند.

**آیا می‌توانم هر اسلاید و یادداشت‌های آن را در یک صفحه نگه دارم؟**

از [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notespositions/#BottomTruncated) استفاده کنید. این تنظیم یادداشت‌ها را به یک صفحه محدود می‌کند، بنابراین بخشی از یادداشت‌ها که جا نمی‌گیرد ممکن است قطع شود.

**چگونه اسلایدها را بدون یادداشت‌های سخنران صادر کنم؟**

پیکربندی طرح چیدمان یادداشت‌ها را حذف کنید و از خروجی PDF استاندارد توصیف‌شده در [Convert PowerPoint to PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) استفاده کنید.