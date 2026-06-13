---
title: به‌صورت کارآمد ارائه‌ها را با پایتون ترکیب کنید
linktitle: ترکیب ارائه‌ها
type: docs
weight: 40
url: /fa/python-net/merge-presentation/
keywords:
- ترکیب PowerPoint
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- ترکیب PowerPoint
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- پایتون
- Aspose.Slides
description: "به راحتی ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) را با Aspose.Slides برای پایتون از طریق .NET ترکیب کنید و جریان کار خود را بهبود ببخشید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را با کلون کردن اسلایدها از یک ارائه به ارائه دیگر ترکیب کنید. این مقاله نحوه ترکیب تمام ارائه‌ها یا اسلایدهای انتخابی، استفاده از اسلاید مستر یا یک طرح خاص در طول ترکیب، مدیریت ارائه‌های با اندازه‌های اسلاید متفاوت، و افزودن اسلایدهای ترکیب‌شده به یک بخش ارائه را توضیح می‌دهد. همچنین نکات عملی مرتبط با محتوای ترکیب‌شده، از جمله یادداشت‌های سخنران، نظرات، فایل‌های منبع دارای رمز عبور، و استفاده از نخ‌ها را پوشش می‌دهد.

## **بهینه‌سازی ترکیب ارائه‌های شما**

با [Aspose.Slides for Python](https://products.aspose.com/slides/fa/python-net/)، می‌توانید ارائه‌های PowerPoint را به‌صورت یکپارچه ترکیب کنید در حالی که سبک‌ها، طرح‌ها و تمام عناصر حفظ می‌شوند. برخلاف ابزارهای دیگر، Aspose.Slides ارائه‌ها را بدون کاهش کیفیت یا از دست رفتن داده ترکیب می‌کند. کل مجموعه‌ها، اسلایدهای خاص، یا حتی فرمت‌های مختلف فایل (مثلاً PPT به PPTX) را ترکیب کنید.

### **ویژگی‌های ترکیب**

- **ترکیب کامل ارائه:** تمام اسلایدها را در یک فایل واحد ترکیب کنید.
- **ترکیب اسلایدهای خاص:** اسلایدهای انتخابی را ترکیب کنید.
- **ترکیب متقاطع فرمت‌ها:** ارائه‌های دارای فرمت‌های مختلف را ادغام کنید و یکپارچگی را حفظ کنید.

## **ترکیب ارائه**

وقتی یک ارائه را در دیگری ترکیب می‌کنید، در واقع اسلایدهای آن‌ها را در یک ارائه واحد ترکیب می‌کنید تا یک فایل تولید شود. اکثر برنامه‌های ارائه—مانند PowerPoint یا OpenOffice—قابلیت ترکیب ارائه به این شکل را ندارند.

با این حال، [Aspose.Slides for Python](https://products.aspose.com/slides/fa/python-net/) به شما امکان می‌دهد ارائه‌ها را به روش‌های مختلف ترکیب کنید. می‌توانید ارائه‌ها را به‌همراه تمام شکل‌ها، سبک‌ها، متن، قالب‌بندی، نظرات و انیمیشن‌ها ترکیب کنید بدون هیچ گونه از دست رفتن کیفیت یا داده.

**همچنین ببینید**

[Clone PowerPoint Slides in Python](/slides/fa/python-net/clone-slides/)

### **چه چیزی می‌تواند ترکیب شود**

با Aspose.Slides می‌توانید ترکیب کنید:

- ارائه‌های کامل: تمام اسلایدهای دک‌های منبع در یک ارائه ترکیب می‌شوند.
- اسلایدهای خاص: فقط اسلایدهای انتخابی در یک ارائه ترکیب می‌شوند.
- ارائه‌های با فرمت یکسان (مثلاً PPT→PPT، PPTX→PPTX) یا با فرمت‌های مختلف (مثلاً PPT→PPTX، PPTX→ODP).

### **گزینه‌های ترکیب**

می‌توانید کنترل کنید که:
- هر اسلاید در ارائه خروجی سبک اصلی خود را حفظ کند، یا
- یک سبک واحد بر تمام اسلایدهای ارائه خروجی اعمال شود.

برای ترکیب ارائه‌ها، Aspose.Slides متدهای [add_clone](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/) را در کلاس [SlideCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/) فراهم می‌کند. این بارگذاری‌های متد نحوه انجام ترکیب را تعریف می‌کنند. هر شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) یک مجموعه [slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slides/fa/) ارائه می‌دهد، بنابراین شما `add_clone` را روی مجموعه اسلایدهای ارائه مقصد فراخوانی می‌کنید.

متد `add_clone` یک `Slide` برمی‌گرداند—یک کلون از اسلاید منبع. اسلایدهای موجود در ارائه خروجی کپی‌ای از اسلایدهای اصلی هستند، بنابراین می‌توانید اسلایدهای حاصل را (مثلاً اعمال سبک، قالب‌بندی یا طرح) بدون تأثیر بر ارائه‌های منبع تغییر دهید.

## **ترکیب ارائه‌ها** 

Aspose.Slides متد [add_clone(ISlide)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) را فراهم می‌کند که به شما امکان می‌دهد اسلایدها را ترکیب کنید در حالی که طرح‌ها و سبک‌های آن‌ها حفظ می‌شود (با پارامترهای پیش‌فرض).

مثال زیر به زبان Python نشان می‌دهد چگونه ارائه‌ها را ترکیب کنید:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **ترکیب ارائه‌ها با اسلاید مستر**

Aspose.Slides متد [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) را فراهم می‌کند که به شما امکان می‌دهد اسلایدها را ترکیب کنید در حالی که اسلاید مستری از یک الگو اعمال می‌شود. به این ترتیب، در صورت نیاز می‌توانید سبک اسلایدهای ارائه خروجی را تغییر دهید.

مثال زیر به زبان Python این عملیات را نشان می‌دهد:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Note" color="warning" %}}
طرح مناسب تحت اسلاید مستر مشخص شده به‌صورت خودکار تعیین می‌شود. اگر طرح مناسبی یافت نشود و پارامتر بولی `allow_clone_missing_layout` متد `add_clone` روی `True` تنظیم شود، طرح اسلاید منبع استفاده می‌شود. در غیر این صورت، یک [PptxEditException](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

برای اعمال طرح اسلاید متفاوت به اسلایدهای ارائه خروجی، هنگام ترکیب از متد [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) استفاده کنید.

## **ترکیب اسلایدهای خاص از ارائه‌ها**

ترکیب اسلایدهای خاص از چندین ارائه برای ایجاد دک اسلایدهای سفارشی مفید است. Aspose.Slides به شما امکان می‌دهد فقط اسلایدهای مورد نیاز خود را انتخاب و وارد کنید در حالی که قالب‌بندی، طرح و طراحی اصلی اسلایدها حفظ می‌شود.

مثال زیر به زبان Python یک ارائه جدید ایجاد می‌کند، اسلایدهای عنوان را از دو ارائه دیگر اضافه می‌کند و نتیجه را در فایلی ذخیره می‌کند:

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **ترکیب ارائه‌ها با یک طرح اسلاید**

مثال زیر به زبان Python نشان می‌دهد چگونه اسلایدها را از چندین ارائه ترکیب کنید در حالی که یک طرح اسلاید خاص برای تولید یک ارائه خروجی واحد اعمال می‌شود:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **ترکیب ارائه‌ها با اندازه‌های اسلاید متفاوت**

{{% alert title="Note" color="warning" %}}
شما نمی‌توانید به‌طور مستقیم ارائه‌هایی را ترکیب کنید که اندازه اسلایدهای متفاوتی دارند.
{{% /alert %}}

برای ترکیب دو ارائه با اندازه‌های اسلاید متفاوت، ابتدا یکی از ارائه‌ها را تغییر اندازه دهید تا اندازه اسلاید آن با دیگری هم‌خوانی داشته باشد.

کد نمونه زیر این فرآیند را نشان می‌دهد:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **ترکیب اسلایدها در یک بخش ارائه**

مثال زیر به زبان Python نشان می‌دهد چگونه یک اسلاید خاص را در بخشی از یک ارائه ترکیب کنید:

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

اسلاید در انتهای بخش اضافه می‌شود. 

{{% alert title="Tip" color="primary" %}}
به دنبال یک **ابزار آنلاین رایگان** برای **ترکیب ارائه‌های PowerPoint** هستید؟ [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/fa/merger) را امتحان کنید.

- **به‌راحتی فایل‌های PowerPoint را ترکیب کنید**: چندین ارائه **PPT, PPTX, ODP** را در یک فایل ترکیب کنید.  
- **پشتیبانی از فرمت‌های مختلف**: ترکیب **PPT به PPTX**، **PPTX به ODP** و بیشتر.  
- **بدون نیاز به نصب**: مستقیماً در مرورگر شما کار می‌کند، سریع و امن.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/fa/merger)  

امروزه با **ابزار رایگان آنلاین Aspose** اسلایدهای PowerPoint خود را ترکیب کنید!  
{{% /alert %}}

{{% alert title="Tip" color="primary" %}}
Aspose یک برنامه وب **رایگان Collage** ارائه می‌دهد ([FREE Collage web app](https://products.aspose.app/slides/fa/collage)). با استفاده از این سرویس آنلاین می‌توانید [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [gridهای تصویری](https://products.aspose.app/slides/fa/collage/photo-grid) بسازید و غیره. 
{{% /alert %}}

## **سوالات متداول**

**آیا یادداشت‌های سخنران در حین ترکیب حفظ می‌شوند؟**

بله. هنگام کلون کردن اسلایدها، Aspose.Slides تمام عناصر اسلاید از جمله یادداشت‌ها، قالب‌بندی و انیمیشن‌ها را منتقل می‌کند.

**آیا نظرات و نویسندگان آن‌ها منتقل می‌شود؟**

نظرات به عنوان بخشی از محتوای اسلاید کپی می‌شوند. برچسب نویسندگان نظرات به‌عنوان اشیای نظر در ارائه حاصل حفظ می‌شود.

**اگر ارائه منبع دارای رمز عبور باشد چه می‌شود؟**

باید [با رمز عبور باز شود](/slides/fa/python-net/password-protected-presentation/) از طریق [LoadOptions.password](https://reference.aspose.com/slides/fa/python-net/aspose.slides/loadoptions/password/); پس از بارگذاری، این اسلایدها می‌توانند به‌صورت ایمن به یک فایل هدف بدون رمز یا حتی با رمز کپی شوند.

**عملیات ترکیب تا چه حد ایمن برای استفاده در چند نخ است؟**

از یک نمونه [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) در [چندین نخ](/slides/fa/python-net/multithreading/) استفاده نکنید. قانون پیشنهادی این است که "یک سند — یک نخ"؛ فایل‌های متفاوت می‌توانند به‌صورت موازی در نخ‌های جداگانه پردازش شوند.