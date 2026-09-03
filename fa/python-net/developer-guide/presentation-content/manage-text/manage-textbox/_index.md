---
title: "مدیریت جعبه‌های متن در ارائه‌ها با Python"
linktitle: "مدیریت جعبه متن"
type: docs
weight: 20
url: /fa/python-net/manage-textbox/
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
  - Aspose.Slides
description: "ایجاد، شناسایی، قالب‌بندی و به‌روزرسانی جعبه‌های متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET."
---
## **مقدمه**

در Aspose.Slides برای Python از طریق .NET، متن اسلایدها در فریم‌های متنی که به اشکال تعلق دارند ذخیره می‌شود. کلاس [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) نمایانگر رایج‌ترین شکل حامل متن است و متن آن را از طریق ویژگی [AutoShape.text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/text_frame/) در دسترس قرار می‌دهد.

{{% alert color="info" title="Note" %}}
هر شکل خودکار از [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) ارث می‌برد، اما هر شکل یک شکل خودکار نیست و لزوماً فریم متنی را پشتیبانی نمی‌کند. هنگام پردازش یک ارائه موجود، برای بررسی نوع شکل قبل از دسترسی به متن آن از `isinstance(shape, slides.AutoShape)` استفاده کنید.
{{% /alert %}}

## **ایجاد جعبه متن در اسلاید**

برای ایجاد جعبه متن، یک شکل خودکار به اسلاید اضافه کنید، متن را به فریم متن آن اضافه کنید و ارائه را ذخیره کنید. مثال زیر یک جعبه متن مستطیلی ایجاد می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

مختصات و ابعادی که به [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_auto_shape/) ارسال می‌شوند بر حسب نقطه‌اند. متد [AutoShape.add_text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/add_text_frame/) فریم متن را با متنی که supplied است مقداردهی اولیه می‌کند.

## **بررسی شکل جعبه متن**

از ویژگی [AutoShape.is_text_box](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/is_text_box/) برای تعیین اینکه آیا یک شکل خودکار به عنوان جعبه متن در نظر گرفته می‌شود یا خیر استفاده کنید. این ویژگی زمانی مفید است که یک ارائه هم شامل شکل‌های خودکار حامل متن و هم شکل‌های گرافیکی باشد.

![یک جعبه متن و یک شکل](istextbox.png)

مثال زیر هر شکل خودکار موجود در یک ارائه را بررسی می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

یک شکل خودکار تازه اضافه شده تا زمانی که متن غیر خالی داشته باشد به عنوان جعبه متن محسوب نمی‌شود. می‌توانید آن متن را از طریق [AutoShape.add_text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/add_text_frame/) یا [TextFrame.text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/text/) فراهم کنید. افزودن یا اختصاص یک رشته خالی مقدار [is_text_box](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/is_text_box/) را به `False` تنظیم می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

دو فراخوانی اول `True` چاپ می‌کنند؛ دو فراخوانی آخر `False`.

## **یافتن شکلی که فریم متن را مالک است**

کدهای عمومی پردازش متن ممکن است یک [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) را بدون دانستن شیء ارائه‌ای که آن را در بر دارد دریافت کنند. از ویژگی فقط‑خواندنی [TextFrame.parent_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_shape/) برای بازگشت به شیء [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) مالک استفاده کنید.

برای فریم متنی که توسط یک شکل خودکار یا شکل دیگری حامل متن مالکیت می‌شود، [parent_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_shape/) مالک را شامل می‌شود و [TextFrame.parent_cell](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/parent_cell/) مقدار `None` است. قبل از دسترسی به مقدار بازگشتی آن را بررسی کنید. برای شناسایی هر دو مالک شکل و خانه جدول، شامل اشکالی که با گره‌های SmartArt مرتبط هستند، به بخش [Search and Replace Text](/slides/fa/python-net/search-and-replace-text/) مراجعه کنید.

## **اضافه کردن ستون‌ها به جعبه متن**

ویژگی [TextFrameFormat.column_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/column_count/) فریم متن را به ستون‌ها تقسیم می‌کند، در حالی که [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/column_spacing/) فاصله بین ستون‌ها را بر حسب نقطه تنظیم می‌کند. هر دو تنظیم متعلق به [TextFrameFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) هستند و می‌توانند از طریق فریم متن یک جعبه متن موجود تغییر یابند. متن بین ستون‌ها در همان شکل بازپخش می‌شود؛ به شکل دیگری ادامه نمی‌یابد.

مثال زیر یک جعبه متن سه‌ستونی با فاصلهٔ ۱۰ نقطه بین ستون‌ها ایجاد می‌کند، ارائه را ذخیره می‌نماید و تنظیمات ذخیره‑شده را از فایل خروجی می‌خواند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **استخراج متن از ستون‌های جداگانه**

از متد [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/split_text_by_columns/) برای دریافت متنی که به هر ستون بصری در یک فریم متن موجود اختصاص یافته، استفاده کنید. این متد برای هر ستون یک رشته برمی‌گرداند که بر اساس ترتیب خواندن ستونی مرتب شده است. یک فریم متن تک‑ستونی یک لیست با یک عنصر تولید می‌کند و یک ستون خالی توسط رشتهٔ خالی نمایان می‌شود. رشته‌ها صرفاً متن ساده را شامل می‌شوند؛ قالب‌بندی سطح‑بخش حفظ نمی‌شود.

این قابلیت زمانی مفید است که لازم داشته باشید:

- متن را استخراج کنید در حالی که ترتیب خواندن مبتنی بر ستون حفظ می‌شود.
- محتویات اسلایدهای چند‑ستونی را ایندکس یا مقایسه کنید.
- هر ستون را به فایل، فیلد پایگاه داده یا مقصد دیگری جداگانه صادر کنید.
- بررسی کنید که پس از تغییر [TextFrameFormat.column_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/column_count/)، [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/column_spacing/)، فونت یا اندازهٔ فریم متن، متن چگونه دوباره توزیع می‌شود.

این متد متن توزیع‑شده در [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) فعلی را گزارش می‌کند؛ به‌طور خودکار متن را بین اشکال یا جعبه‌های متن جداگانه جابه‌جا نمی‌کند. توزیع ستون می‌تواند به فونت‌های موجود و سایر تنظیمات چیدمان متن وابسته باشد، بنابراین هنگام نیاز به نتایج یکسان اطمینان حاصل کنید که فونت‌های مورد نیاز در دسترس باشند.

مثال زیر یک ارائه را بارگذاری می‌کند، اولین شکل خودکار چند‑ستونی با فریم متن را پیدا می‌کند، تعداد ستون‌های پیکربندی‌شده را می‌خواند و متن هر ستون را در فایلی جداگانه می‌نویسد. شکل‌هایی که فریم متن ندارند نادیده گرفته می‌شوند:

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **به‌روزرسانی متن**

برای به‌روزرسانی متن در سراسر یک ارائه، اسلایدها و اشکال را پیمایش کنید، شکل‌های خودکار را انتخاب کنید و سپس بخش‌های متنی آن‌ها را ویرایش نمایید. کار بر سطح بخش به شما امکان می‌دهد هم متن و هم قالب‌بندی کاراکتر را تغییر دهید.

مثال زیر همهٔ موارد `years` را در متن شکل‌های خودکار با `months` جایگزین می‌کند و هر بخش تأثیر گرفته را پر رنگ (Bold) می‌نماید:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

این پیمایش فقط متن را در شکل‌های خودکار به‌روز می‌کند. متنی که در جدول‌ها، نمودارها، SmartArt یا اشکال گروهی ذخیره شده است، نیاز به پیمایش مجموعه‌های خود آن اشیاء دارد.

## **اضافه کردن جعبه متن با پیوند**

یک پیوند می‌تواند به بخش خاصی از متن اختصاص یابد، به طوری که فقط آن متن به عنوان لینک کلیک‌پذیر عمل می‌کند. از [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) برای ارتباط بخش با یک URL خارجی استفاده کنید.

مثال زیر متن پیوندی ایجاد کرده و آن را در یک ارائه ذخیره می‌کند:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**تفاوت جعبه متن با متغیر نگهدار متن در اسلاید مستر یا لایوت چیست؟**

یک [متغیر نگهدار](/slides/fa/python-net/manage-placeholder/) می‌تواند موقعیت و قالب‌بندی خود را از یک [اسلاید مستر](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) یا [اسلاید لایوت](https://reference.aspose.com/slides/fa/python-net/aspose.slides/layoutslide/) به ارث ببرد. یک جعبه متن معمولی یک شکل مستقل بر روی اسلایدی است که در آن ایجاد شده و هنگام تغییر لایوت رفتار متغیر نگهدار را به‌دست نمی‌آورد.

**چگونه می‌توانم متن را جایگزین کنم بدون اینکه متن در نمودارها، جدول‌ها یا SmartArt تغییر کند؟**

پیمایش را به نمونه‌های [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) محدود کنید، همان‌طور که در مثال به‌روزرسانی متن نشان داده شده است. نمودارها، جدول‌ها و SmartArt متن خود را در مدل‌های شیء خاص خود ذخیره می‌کنند، بنابراین توسط آن حلقه تغییر نمی‌یابند.