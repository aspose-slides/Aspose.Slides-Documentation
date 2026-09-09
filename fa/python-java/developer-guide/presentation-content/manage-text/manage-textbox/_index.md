---
title: مدیریت جعبه‌های متن در ارائه‌ها با استفاده از Python از طریق Java
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/python-java/manage-textbox/
keywords:
- جعبه متن
- فریم متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "ایجاد، شناسایی، قالب‌بندی و به‌روزرسانی جعبه‌های متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق Java."
---
## **مقدمه**

در Aspose.Slides برای Python از طریق Java، متن اسلاید در فریم‌های متنی ذخیره می‌شود که به اشکال تعلق دارند. کلاس [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) نمایانگر رایج‌ترین شکل حاوی متن است و متن آن را از طریق متد [AutoShape.getTextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/#getTextFrame) در دسترس می‌گذارد.

{{% alert color="info" title="Note" %}}

هر شکل خودکار از [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) ارث می‌برد، اما هر شکل یک شکل خودکار نیست یا از فریم متن پشتیبانی نمی‌کند. هنگام پردازش یک ارائه موجود، قبل از دسترسی به متن، بررسی کنید که شکل نمونه‌ای از [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) باشد.

{{% /alert %}}

## **ایجاد یک جعبه متن در اسلاید**

برای ایجاد یک جعبه متن، یک شکل خودکار را به اسلاید اضافه کنید، متن را به فریم متنی آن اضافه کنید و ارائه را ذخیره کنید. مثال زیر یک جعبه متن مستطیلی ایجاد می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

مختصات و ابعاد ارسال‌شده به [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addAutoShape) بر حسب نقطه (points) اندازه‌گیری می‌شوند. [AutoShape.addTextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/#addTextFrame) فریم متن را با متن ارائه‌شده مقداردهی اولیه می‌کند.

## **بررسی وجود شکل جعبه متن**

از متد [AutoShape.isTextBox](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/#isTextBox) استفاده کنید تا تعیین کنید آیا یک شکل خودکار به عنوان جعبه متن در نظر گرفته می‌شود یا خیر. این در زمانی مفید است که ارائه حاوی هر دو شکل خودکار متن‌دار و صرفاً گرافیکی باشد.

![یک جعبه متن و یک شکل](istextbox.png)

مثال زیر هر شکل خودکار در یک ارائه را بررسی می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

یک شکل خودکار تازه اضافه‌شده تا زمانی که متن غیرخالی داشته باشد، به عنوان جعبه متن در نظر گرفته نمی‌شود. می‌توانید متن موردنظر را از طریق [AutoShape.addTextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/#addTextFrame) یا [TextFrame.setText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#setText) فراهم کنید. افزودن یا اختصاص یک رشته خالی باعث می‌شود که [AutoShape.isTextBox](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/#isTextBox) مقدار `False` برگرداند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

دو فراخوانی اول `True` چاپ می‌کنند؛ دو فراخوانی آخر `False` چاپ می‌کنند.

## **یافتن شکلی که فریم متن را دارد**

کد عمومی پردازش متن ممکن است یک [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) دریافت کند بدون اینکه بداند کدام شی ارائه آن را شامل می‌شود. از متد فقط‑خواندنی [TextFrame.getParentShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getParentShape) برای بازگشت به [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) صاحب آن استفاده کنید.

برای فریم متنی که متعلق به یک شکل خودکار یا شکل دیگری متن‌دار است، [TextFrame.getParentShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getParentShape) صاحب را برمی‌گرداند و [TextFrame.getParentCell](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#getParentCell) مقدار `None` می‌دهد. پیش از دسترسی به مقدار برگردانده‌شده آن را بررسی کنید. برای شناسایی هر دو مالک شکل و سلول جدول، از جمله اشکالی که با گره‌های SmartArt مرتبط هستند، به [Search and Replace Text](/slides/fa/python-java/search-and-replace-text/) مراجعه کنید.

## **افزودن ستون‌ها به یک جعبه متن**

متد [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setColumnCount) فریم متن را به ستون‌ها تقسیم می‌کند، در حالی که [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setColumnSpacing) فاصله بین ستون‌ها را برحسب نقطه تنظیم می‌نماید. هر دو تنظیم مربوط به [TextFrameFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/) هستند و می‌توانند از طریق فریم متن یک جعبه متن موجود تغییر یابند. متن بین ستون‌ها در همان شکل دوباره‌پخش می‌شود؛ به شکل دیگری جریان نمی‌یابد.

مثال زیر یک جعبه متن سه‌ستونه با 10 نقطه فاصله بین ستون‌ها ایجاد می‌کند، ارائه را ذخیره می‌نماید و تنظیمات ذخیره‌شده را از فایل خروجی می‌خواند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **استخراج متن از ستون‌های منفرد**

از متد [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/#splitTextByColumns) برای دریافت متنی که به هر ستون بصری اختصاص یافته در یک فریم متن موجود اختصاص داده شده است، استفاده کنید. این متد برای هر ستون یک رشته برمی‌گرداند، به ترتیب خواندن مبتنی بر ستون. یک فریم متن تک‌ستونه آرایه‌ای با یک عنصر تولید می‌کند و یک ستون خالی با رشته خالی نمایان می‌شود. رشته‌ها فقط شامل متن ساده هستند؛ قالب‌بندی سطح بخش حفظ نمی‌شود.

این کار زمانی مفید است که نیاز داشته باشید:

- متن را استخراج کنید در حالی که ترتیب خواندن مبتنی بر ستون حفظ می‌شود.
- محتوای اسلایدهای چندستونه را نمایه یا مقایسه کنید.
- هر ستون را به فایل، فیلد پایگاه داده یا مقصد دیگری جداگانه صادر کنید.
- بررسی کنید که پس از تغییر تعداد ستون‌ها با [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setColumnCount)، فاصله با [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setColumnSpacing)، قلم یا اندازه فریم متن، متن چگونه توزیع می‌شود.

این متد متن توزیع‌شده در [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) فعلی را گزارش می‌دهد؛ به‌صورت خودکار متن را بین شکل‌ها یا جعبه‌های متن جداگانه جریان نمی‌دهد. توزیع ستون می‌تواند به قلم‌های موجود و سایر تنظیمات طرح‌بندی متن وابسته باشد، بنابراین هنگام نیاز به نتایج ثابت، اطمینان حاصل کنید که قلم‌های موردنیاز در دسترس هستند.

مثال زیر یک ارائه را بارگذاری می‌کند، اولین شکل خودکار چندستونه با فریم متن را پیدا می‌کند، تعداد ستون‌های پیکربندی‌شده آن را می‌خواند و متن هر ستون را به فایل جداگانه‌ای می‌نویسد. اشکالی که فریم متنی ندارند، نادیده گرفته می‌شوند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **به‌روزرسانی متن**

برای به‌روزرسانی متن در سراسر یک ارائه، اسلایدها و اشکال را پیمایش کنید، شکلی‌های خودکار را انتخاب کنید و سپس بخش‌های متنی آن‌ها را ویرایش کنید. کار در سطح بخش به شما امکان تغییر هم متن و هم قالب‌بندی کاراکتر را می‌دهد.

مثال زیر هر رخداد `years` را با `months` در متن شکل‌های خودکار جایگزین می‌کند و هر بخش تحت‌تأثیر را بولد می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

این پیمایش فقط متن در شکل‌های خودکار را به‌روزرسانی می‌کند. متنی که در جدول‌ها، نمودارها، SmartArt یا شکل‌های گروهی ذخیره شده، نیاز به پیمایش مجموعه‌های خود آن اشیاء دارد.

## **افزودن جعبه متن با پیوند**

می‌توانید یک پیوند را به بخش متن خاصی اختصاص دهید، بنابراین تنها آن متن به عنوان لینک کلیک‌شدنی عمل می‌کند. از [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) برای مرتبط‌سازی بخش با یک URL خارجی استفاده کنید.

مثال زیر متن پیوندی ایجاد می‌کند و آن را در یک ارائه ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**تفاوت جعبه متن و جای‌دار متن (placeholder) در یک اسلاید مستر یا لایه‌بندی چیست؟**

یک [placeholder](/slides/fa/python-java/manage-placeholder/) می‌تواند موقعیت و قالب‌بندی خود را از یک [master slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/) یا [layout slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/) به ارث ببرد. یک جعبه متن عادی یک شکل مستقل بر روی اسلایدی است که در آن ایجاد شده و هنگام تغییر لایه، رفتار جای‌دار را به‌دست نمی‌آورد.

**چگونه می‌توانم متن را جایگزین کنم بدون اینکه متن در نمودارها، جدول‌ها یا SmartArt تغییر یابد؟**

پیمایش را تنها به اشکالی که نمونه‌ای از [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) هستند محدود کنید، همان‌گونه که در مثال «به‌روزرسانی متن» نشان داده شد. نمودارها، جدول‌ها و SmartArt متن خود را در مدل‌های شیء مستقل خود ذخیره می‌کنند، بنابراین توسط آن حلقه تغییر نمی‌یابند.