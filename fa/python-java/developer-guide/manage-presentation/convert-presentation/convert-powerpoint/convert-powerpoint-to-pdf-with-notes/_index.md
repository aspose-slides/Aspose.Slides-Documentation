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
- صدور PPT به PDF
- صدور PPTX به PDF
- یادداشت‌های سخنران
- PDF با یادداشت‌ها
- Python
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PPT و PPTX به PDF با یادداشت‌های سخنران با استفاده از Aspose.Slides برای Python از طریق Java. مکان‌گذاری یادداشت‌ها را پیکربندی کنید و یادداشت‌های طولانی را حفظ کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را به PDF با یادداشت‌های سخنران تبدیل کنید با استفاده از Aspose.Slides برای Python از طریق Java. می‌توانید یادداشت‌ها را زیر هر اسلاید اضافه کنید و اجازه دهید یادداشت‌های طولانی به صفحات اضافی ادامه یابند. برای سایر تنظیمات خروجی PDF، به [تبدیل PowerPoint به PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) مراجعه کنید.

برای تنظیم ابعاد و جهت صفحه یادداشت‌ها قبل از خروجی، به [اندازه صفحه یادداشت‌ها](/slides/fa/python-java/notes-size/) مراجعه کنید.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

از متد [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) برای خروجی گرفتن یک ارائه PPT یا PPTX به PDF استفاده کنید. برای شامل شدن یادداشت‌های سخنران، یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/) ایجاد کنید و مکان‌یابی یادداشت‌ها را با متد [setNotesPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) آن پیکربندی کنید. این طرح‌بندی را به [PdfOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/) با استفاده از [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) اختصاص دهید.

مثال زیر فایل `sample.pptx` را بارگیری کرده و آن را به `output.pdf` با یادداشت‌های سخنران زیر اسلایدها خروجی می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # پیکربندی گزینه‌های PDF برای نمایش یادداشت‌های سخنران.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # ذخیره ارائه به PDF با یادداشت‌های سخنران.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
همچنین می‌توانید [مبدل آنلاین PowerPoint به PDF](https://products.aspose.app/slides/fa/conversion) را امتحان کنید.
{{% /alert %}}

## **سوالات متداول**

**چگونه می‌توانم از برش شدن یادداشت‌های طولانی جلوگیری کنم؟**

از [NotesPositions.BottomFull](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notespositions/#BottomFull) همان‌طور که در مثال بالا نشان داده شده استفاده کنید. این تنظیم تمام یادداشت‌ها را نمایش می‌دهد و در صورت نیاز از صفحات اضافی استفاده می‌کند.

**آیا می‌توانم هر اسلاید و یادداشت‌های آن را در یک صفحه نگه دارم؟**

از [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notespositions/#BottomTruncated) استفاده کنید. این تنظیم یادداشت‌ها را به یک صفحه محدود می‌کند، بنابراین یادداشت‌های بیش از حد ممکن است کوتاه شوند.

**چگونه اسلایدها را بدون یادداشت‌های سخنران خروجی بگیرم؟**

پیکربندی طرح‌بندی یادداشت‌ها را حذف کنید و از خروجی PDF استاندارد که در [تبدیل PowerPoint به PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) توضیح داده شده استفاده کنید.