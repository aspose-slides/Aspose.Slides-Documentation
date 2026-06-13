---
title: مدیریت گره‌های شکل SmartArt در ارائه‌ها با استفاده از Python
linktitle: گره شکل SmartArt
type: docs
weight: 30
url: /fa/python-net/manage-smartart-shape-node/
keywords:
- گره SmartArt
- گره فرزند
- افزودن گره
- موقعیت گره
- دسترسی به گره
- حذف گره
- موقعیت سفارشی
- گره دستیار
- فرمت پر کردن
- رندر گره
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "مدیریت گره‌های شکل SmartArt در فایل‌های PPT، PPTX و ODP با Aspose.Slides برای Python از طریق .NET. نمونه‌های کد واضح و نکات برای بهبود ارائه‌های شما را دریافت کنید."
---
## **نمای کلی**

گرافیک‌های SmartArt در ارائه‌های پاورپوینت از طریق گره‌هایی که متن دارند و ساختار نمودار را تعریف می‌کنند، سازماندهی می‌شوند. Aspose.Slides به شما امکان می‌دهد به‌صورت برنامه‌نویسی با این گره‌های SmartArt کار کنید: گره‌ها و گره‌های فرزند جدید اضافه کنید، گره‌های فرزند را در موقعیت خاصی درج کنید، به گره‌های موجود دسترسی پیدا کنید و متن، سطح و موقعیت آن‌ها را بخوانید.

این مقاله نحوه مدیریت گره‌های اشکال SmartArt را توضیح می‌دهد. نشان می‌دهد چگونه گره‌ها را حذف کنید، با گره‌های فرزند بر اساس شاخص یا موقعیت کار کنید، یک گره دستیار را به گره معمولی تغییر دهید، موقعیت، اندازه و چرخش اشکال گره‌های SmartArt را تنظیم کنید، فرمت پر کردن گره را تعیین کنید و تصویر کوچک برای یک گره فرزند SmartArt تولید کنید.

## **افزودن گره SmartArt**
Aspose.Slides برای Python از طریق .NET ساده‌ترین API را برای مدیریت اشکال SmartArt به آسان‌ترین شکل فراهم کرده است. کد نمونه زیر به افزودن گره و گره فرزند در داخل شکل SmartArt کمک می‌کند.

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- مرجع اسلاید اول را با استفاده از Index آن به دست آورید.
- از تمام اشکال داخل اسلاید اول عبور کنید.
- بررسی کنید که آیا شکل از نوع SmartArt است و در صورت بودن، شکل انتخاب‌شده را به SmartArt تبدیل (Typecast) کنید.
- یک گره جدید در NodeCollection شکل SmartArt اضافه کنید و متن را در TextFrame تنظیم کنید.
- اکنون، یک گره فرزند در گره SmartArt تازه اضافه‌شده اضافه کنید و متن را در TextFrame تنظیم کنید.
- ارائه را ذخیره کنید.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# بارگذاری ارائه موردنظر
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # عبور از تمام اشکال داخل اسلاید اول
    for shape in pres.slides[0].shapes:

        # بررسی اینکه آیا شکل از نوع SmartArt است
        if type(shape) is art.SmartArt:
            # افزودن یک گره جدید SmartArt
            node1 = shape.all_nodes.add_node()
            # افزودن متن
            node1.text_frame.text = "Test"

            # افزودن گره فرزند جدید در گره والد. این گره در انتهای مجموعه اضافه خواهد شد
            new_node = node1.child_nodes.add_node()

            # افزودن متن
            new_node.text_frame.text = "New Node Added"

    # ذخیره‌سازی ارائه
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن گره SmartArt در موقعیت خاص**
در کد نمونه زیر توضیح دادیم که چگونه گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt را در موقعیت خاصی اضافه کنید.

- یک نمونه از کلاس `Presentation` ایجاد کنید.
- مرجع اسلاید اول را با استفاده از Index آن به دست آورید.
- یک شکل SmartArt از نوع StackedList در اسلاید دسترسی‌یافته اضافه کنید.
- به اولین گره در شکل SmartArt اضافه‌شده دسترسی پیدا کنید.
- اکنون، گره فرزند برای گره انتخاب‌شده در موقعیت ۲ اضافه کنید و متن آن را تنظیم کنید.
- ارائه را ذخیره کنید.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# ایجاد یک نمونه از ارائه
with slides.Presentation() as pres:
    # دسترسی به اسلاید ارائه
    slide = pres.slides[0]

    # افزودن یک IShape از Smart Art
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # دسترسی به گره SmartArt در شاخص 0
    node = smart.all_nodes[0]

    # افزودن گره فرزند جدید در موقعیت ۲ در گره والد
    chNode = node.child_nodes.add_node_by_position(2)

    # افزودن متن
    chNode.text_frame.text = "Sample text Added"

    # ذخیره‌سازی ارائه
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **دستیابی به گره SmartArt**
کد نمونه زیر به دسترسی به گره‌های داخل شکل SmartArt کمک می‌کند. لطفاً توجه داشته باشید که نمی‌توانید LayoutType از SmartArt را تغییر دهید زیرا فقط قابل خواندن است و تنها هنگام افزودن شکل SmartArt تنظیم می‌شود.

- یک نمونه از کلاس `Presentation` ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- مرجع اسلاید اول را با استفاده از Index آن به دست آورید.
- از تمام اشکال داخل اسلاید اول عبور کنید.
- بررسی کنید که آیا شکل از نوع SmartArt است و در صورت بودن، شکل انتخاب‌شده را به SmartArt تبدیل کنید.
- از تمام گره‌ها داخل شکل SmartArt عبور کنید.
- دسترسی پیدا کنید و اطلاعاتی مانند موقعیت گره SmartArt، سطح و متن را نمایش دهید.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# بارگذاری ارائه موردنظر
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # عبور از تمام اشکال داخل اسلاید اول
    for shape in pres.slides[0].shapes:
        # بررسی اینکه آیا شکل از نوع SmartArt است
        if type(shape) is art.SmartArt:
            # عبور از تمام گره‌ها داخل SmartArt
            for i in range(len(shape.all_nodes)):
                # دسترسی به گره SmartArt در شاخص i
                node = shape.all_nodes[i]

                # چاپ پارامترهای گره SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **دستیابی به گره فرزند SmartArt**
کد نمونه زیر به دسترسی به گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt کمک می‌کند.

- یک نمونه از کلاس PresentationEx ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- مرجع اسلاید اول را با استفاده از Index آن به دست آورید.
- از تمام اشکال داخل اسلاید اول عبور کنید.
- بررسی کنید که آیا شکل از نوع SmartArt است و در صورت بودن، شکل انتخاب‌شده را به SmartArtEx تبدیل کنید.
- از تمام گره‌ها داخل شکل SmartArt عبور کنید.
- برای هر گره انتخاب‌شده از شکل SmartArt، از تمام گره‌های فرزند داخل گره خاص عبور کنید.
- دسترسی پیدا کنید و اطلاعاتی مانند موقعیت گره فرزند، سطح و متن را نمایش دهید.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# بارگذاری ارائه موردنظر
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # عبور از تمام اشکال داخل اسلاید اول
    for shape in pres.slides[0].shapes:
        # بررسی اینکه آیا شکل از نوع SmartArt است
        if type(shape) is art.SmartArt:
            # عبور از تمام گره‌ها داخل SmartArt
            for node0 in shape.all_nodes:
                # عبور از گره‌های فرزند
                for j in range(len(node0.child_nodes)):
                    # دسترسی به گره فرزند در گره SmartArt
                    node = node0.child_nodes[j]

                    # چاپ پارامترهای گره فرزند SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```

## **دستیابی به گره فرزند SmartArt در موقعیت خاص**
در این مثال، نحوه دسترسی به گره‌های فرزند در موقعیت خاصی که به گره‌های مختلف شکل SmartArt تعلق دارند، یاد می‌گیریم.

- یک نمونه از کلاس `Presentation` ایجاد کنید.
- مرجع اسلاید اول را با استفاده از Index آن به دست آورید.
- یک شکل SmartArt از نوع StackedList اضافه کنید.
- به شکل SmartArt اضافه‌شده دسترسی پیدا کنید.
- به گره‌ای با شاخص ۰ برای شکل SmartArt دسترسی یافته دسترسی پیدا کنید.
- اکنون، گره فرزند در موقعیت ۱ برای گره SmartArt دسترسی یافته را با استفاده از متد GetNodeByPosition() دسترسی پیدا کنید.
- دسترسی پیدا کنید و اطلاعاتی مانند موقعیت گره فرزند، سطح و متن را نمایش دهید.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# ایجاد یک نمونه از ارائه
with slides.Presentation() as pres:
    # دسترسی به اولین اسلاید
    slide = pres.slides[0]
    # افزودن شکل SmartArt در اسلاید اول
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # دسترسی به گره SmartArt در شاخص 0
    node = smart.all_nodes[0]
    # دسترسی به گره فرزند در موقعیت 1 در گره والد
    position = 1
    chNode = node.child_nodes[position] 
    # چاپ پارامترهای گره فرزند SmartArt
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```

## **حذف گره SmartArt**
در این مثال، نحوه حذف گره‌های داخل شکل SmartArt را می‌آموزیم.

- یک نمونه از کلاس `Presentation` ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- مرجع اسلاید اول را با استفاده از Index آن به دست آورید.
- از تمام اشکال داخل اسلاید اول عبور کنید.
- بررسی کنید که آیا شکل از نوع SmartArt است و در صورت بودن، شکل انتخاب‌شده را به SmartArt تبدیل کنید.
- بررسی کنید که آیا SmartArt بیش از ۰ گره دارد.
- گره SmartArt که باید حذف شود را انتخاب کنید.
- اکنون، گره انتخاب‌شده را با استفاده از متد RemoveNode() حذف کنید* ارائه را ذخیره کنید.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# بارگذاری ارائه موردنظر
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # عبور از تمام اشکال داخل اسلاید اول
    for shape in pres.slides[0].shapes:
        # بررسی اینکه آیا شکل از نوع SmartArt است
        if type(shape) is art.SmartArt:
            # تبدیل نوع شکل به SmartArtEx
            if len(shape.all_nodes) > 0:
                # دسترسی به گره SmartArt در شاخص 0
                node = shape.all_nodes[0]

                # حذف گره انتخاب‌شده
                shape.all_nodes.remove_node(node)

    # ذخیره‌سازی ارائه
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **حذف گره SmartArt در موقعیت خاص**
در این مثال، نحوه حذف گره‌ها داخل شکل SmartArt در موقعیت خاصی را می‌آموزیم.

- یک نمونه از کلاس `Presentation` ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- مرجع اسلاید اول را با استفاده از Index آن به دست آورید.
- از تمام اشکال داخل اسلاید اول عبور کنید.
- بررسی کنید که آیا شکل از نوع SmartArt است و در صورت بودن، شکل انتخاب‌شده را به SmartArt تبدیل کنید.
- گره شکل SmartArt را در شاخص ۰ انتخاب کنید.
- اکنون، بررسی کنید که آیا گره SmartArt انتخاب‌شده بیش از ۲ گره فرزند دارد.
- اکنون، گره در موقعیت ۱ را با استفاده از متد RemoveNodeByPosition() حذف کنید.
- ارائه را ذخیره کنید.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# بارگذاری ارائه موردنظر
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # عبور از تمام اشکال داخل اسلاید اول
    for shape in pres.slides[0].shapes:
        # بررسی اینکه آیا شکل از نوع SmartArt است
        if type(shape) is art.SmartArt:
            # تبدیل نوع شکل به SmartArt
            if len(shape.all_nodes) > 0:
                # دسترسی به گره SmartArt در شاخص 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # حذف گره فرزند در موقعیت 1
                    node.child_nodes.remove_node(1)

    # ذخیره‌سازی ارائه
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم موقعیت سفارشی برای گره فرزند در SmartArt**
اکنون Aspose.Slides برای Python از طریق .NET از تنظیم خصوصیات X و Y شکل SmartArt پشتیبانی می‌کند. کد زیر نشان می‌دهد چگونه موقعیت، اندازه و چرخش سفارشی شکل SmartArtShape را تنظیم کنید؛ همچنین توجه داشته باشید که افزودن گره‌های جدید باعث بازمحاسبه موقعیت‌ها و اندازه‌های تمام گره‌ها می‌شود.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# بارگذاری ارائه موردنظر
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# جابجایی شکل SmartArt به موقعیت جدید
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# تغییر عرض‌های شکل SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# تغییر ارتفاع شکل SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# تغییر چرخش شکل SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **بررسی گره دستیار**
در کد نمونه زیر بررسی می‌کنیم که چگونه گره‌های Assistant را در مجموعه گره‌های SmartArt شناسایی و آن‌ها را تغییر دهیم.

- یک نمونه از کلاس PresentationEx ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
- مرجع اسلاید دوم را با استفاده از Index آن به دست آورید.
- از تمام اشکال داخل اسلاید اول عبور کنید.
- بررسی کنید که آیا شکل از نوع SmartArt است و در صورت بودن، شکل انتخاب‌شده را به SmartArtEx تبدیل کنید.
- از تمام گره‌ها داخل شکل SmartArt عبور کنید و بررسی کنید که آیا گره‌ها Assistant هستند.
- وضعیت گره Assistant را به گره عادی تغییر دهید.
- ارائه را ذخیره کنید.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# ایجاد یک نمونه از ارائه
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # عبور از تمام اشکال داخل اسلاید اول
    for shape in pres.slides[0].shapes:
        # بررسی اینکه آیا شکل از نوع SmartArt است
        if type(shape) is art.SmartArt:
            # عبور از تمام گره‌های شکل SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # بررسی اینکه آیا گره یک گره دستیار است
                if node.is_assistant:
                    # تنظیم گره دستیار به false و تبدیل آن به گره عادی
                    node.is_assistant = False
    # ذخیره‌سازی ارائه
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم فرمت پر کردن گره**
Aspose.Slides برای Python از طریق .NET امکان افزودن اشکال سفارشی SmartArt و تنظیم فرمت پر کردن آن‌ها را فراهم می‌کند. این مقاله توضیح می‌دهد چگونه اشکال SmartArt را ایجاد و دسترسی پیدا کنید و فرمت پر کردن آن‌ها را با استفاده از Aspose.Slides برای Python از طریق .NET تنظیم کنید.

لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس `Presentation` ایجاد کنید.
- مرجع یک اسلاید را با استفاده از شاخص آن به دست آورید.
- یک شکل SmartArt را با تنظیم LayoutType آن اضافه کنید.
- فرمت FillFormat را برای گره‌های شکل SmartArt تنظیم کنید.
- ارائه‌ی تغییر یافته را به‌صورت فایل PPTX بنویسید.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # دسترسی به اسلاید
    slide = presentation.slides[0]

    # افزودن شکل SmartArt و گره‌ها
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # تنظیم رنگ پر کردن گره
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # ذخیره‌سازی ارائه
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تولید تصویر کوچک از گره فرزند SmartArt**
توسعه‌دهندگان می‌توانند با دنبال کردن مراحل زیر، تصویر کوچک از گره فرزند یک SmartArt تولید کنند:

1. کلاس `Presentation` که فایل PPTX را نمایندگی می‌کند، نمونه‌سازی کنید.
1. SmartArt را اضافه کنید.
1. مرجع یک گره را با استفاده از Index آن به دست آورید
1. تصویر کوچک را دریافت کنید.
1. تصویر کوچک را در هر فرمت تصویری دلخواهی ذخیره کنید.

مثال زیر یک تصویر کوچک از گره فرزند SmartArt تولید می‌کند

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# نمونه‌ای از کلاس Presentation که فایل PPTX را نمایندگی می‌کند 
with slides.Presentation() as presentation: 
    # افزودن SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # دریافت مرجع یک گره با استفاده از Index آن  
    node = smart.nodes[1]

    # دریافت تصویر کوچک
    with node.shapes[0].get_image() as bmp:
        # ذخیره‌سازی تصویر کوچک
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **سوالات متداول**

**آیا انیمیشن SmartArt پشتیبانی می‌شود؟**

بله. SmartArt به‌عنوان یک شکل معمولی در نظر گرفته می‌شود، بنابراین می‌توانید [انیمیشن‌های استاندارد](/slides/fa/python-net/shape-animation/) (ورودی، خروجی، تأکید، مسیرهای حرکتی) را اعمال کنید و زمان‌بندی را تنظیم کنید. در صورت نیاز می‌توانید اشکال داخل گره‌های SmartArt را نیز انیمیشن کنید.

**چگونه می‌توانم یک SmartArt خاص را در یک اسلاید به‌صورت قابل اعتماد پیدا کنم اگر شناسه داخلی آن ناشناخته باشد؟**

با اختصاص و جستجو بر اساس [متن جایگزین](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/alternative_text/) می‌توانید این کار را انجام دهید. تنظیم یک AltText متمایز روی SmartArt به شما امکان می‌دهد آن را به‌صورت برنامه‌نویسی پیدا کنید بدون تکیه بر شناسه‌های داخلی.

**آیا ظاهر SmartArt هنگام تبدیل ارائه به PDF حفظ می‌شود؟**

بله. Aspose.Slides SmartArt را با دقت بصری بالا هنگام [صادرات PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/) رندر می‌کند و طراحی، رنگ‌ها و افکت‌ها را حفظ می‌کند.

**آیا می‌توانم تصویر کل SmartArt را استخراج کنم (برای پیش‌نمایش یا گزارش‌ها)؟**

بله. می‌توانید یک شکل SmartArt را به [فرمت‌های رستر](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/get_image/) یا به [SVG](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/write_as_svg/) برای خروجی بردار مقیاس‌پذیر رندر کنید، که آن را برای تصویرهای کوچک، گزارش‌ها یا استفاده در وب مناسب می‌سازد.