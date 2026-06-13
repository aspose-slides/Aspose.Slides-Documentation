---
title: ارتقا ارائه‌های خود با AutoFit در Python
linktitle: تنظیمات Autofit
type: docs
weight: 30
url: /fa/python-net/manage-autofit-settings/
keywords:
- جعبه‌متن
- تنظیم خودکار
- عدم تنظیم خودکار
- تناسب متن
- کوچک‌کردن متن
- پیچش متن
- تغییر اندازه شکل
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه تنظیمات AutoFit را در Aspose.Slides برای Python از طریق .NET مدیریت کنید تا نمایش متن در ارائه‌های PowerPoint و OpenDocument شما بهینه شود و خوانایی محتوا بهبود یابد."
---
## **معرفی**

به‌طور پیش‌فرض، وقتی یک جعبه متن اضافه می‌کنید، Microsoft PowerPoint از تنظیم **Resize shape to fix text** برای جعبه متن استفاده می‌کند—به‌صورت خودکار اندازه جعبه متن را تغییر می‌دهد تا مطمئن شود متن آن همیشه درون آن جا می‌شود. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* وقتی متن در جعبه متن طولانی‌تر یا بزرگ‌تر می‌شود، PowerPoint به‌طور خودکار جعبه متن را بزرگ‌تر می‌کند—ارتفاع آن را افزایش می‌دهد—تا متن بیشتری را در خود جای دهد.  
* وقتی متن در جعبه متن کوتاه‌تر یا کوچک‌تر می‌شود، PowerPoint به‌طور خودکار جعبه متن را کوچک‌تر می‌کند—ارتفاع آن را کاهش می‌دهد—تا فضای اضافی را حذف کند.  

در PowerPoint، چهار پارامتر یا گزینه مهم که رفتار AutoFit برای یک جعبه متن را کنترل می‌کنند عبارتند از:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET گزینه‌های مشابهی فراهم می‌کند—برخی ویژگی‌ها تحت کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/)—که به شما اجازه می‌دهد رفتار AutoFit برای جعبه متن‌ها در ارائه‌ها را کنترل کنید. 

## **تغییر اندازه اشکال برای متناسب شدن با متن**

اگر می‌خواهید متن در یک جعبه همیشه پس از تغییرات در متن، در همان جعبه جا بگیرد، باید از گزینه **Resize shape to fix text** استفاده کنید. برای تعیین این تنظیم، ویژگی [autofit_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) به `SHAPE` تنظیم کنید. 

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

این کد پایتون نشان می‌دهد که چگونه تعیین کنید متن همیشه در جعبه خود در یک ارائه PowerPoint جا بگیرد:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

اگر متن طولانی‌تر یا بزرگ‌تر شود، جعبه متن به‌صورت خودکار (ارتفاع آن افزایش می‌یابد) تغییر اندازه می‌دهد تا تمام متن درون آن جا بگیرد. اگر متن کوتاه‌تر شود، برعکس خواهد شد. 

## **عدم AutoFit**

اگر می‌خواهید یک جعبه متن یا شکل ابعاد خود را صرف‌نظر از تغییرات متن درون آن حفظ کند، باید از گزینه **Do not Autofit** استفاده کنید. برای تعیین این تنظیم، ویژگی [autofit_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) به `NONE` تنظیم کنید. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

این کد پایتون نشان می‌دهد که چگونه تعیین کنید یک جعبه متن همیشه ابعاد خود را در یک ارائه PowerPoint حفظ کند:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

وقتی متن بیش از حد برای جعبه‌اش طولانی شود، از جعبه بیرون می‌ریزد. 

## **کوچک کردن متن در صورت سرریز**

اگر متنی برای جعبه‌اش بیش از حد طولانی شود، می‌توانید با گزینه **Shrink text on overflow** تعیین کنید که اندازه و فاصله متن کاهش یابد تا در جعبه جا بگیرد. برای تعیین این تنظیم، ویژگی [autofit_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) به `NORMAL` تنظیم کنید. 

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

این کد پایتون نشان می‌دهد که چگونه تعیین کنید متن در صورت سرریز کوچک شود در یک ارائه PowerPoint:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="اطلاعات" color="info" %}}
هنگامی که از گزینه **Shrink text on overflow** استفاده می‌شود، این تنظیم فقط زمانی اعمال می‌گردد که متن برای جعبه‌اش بیش از حد طولانی شود. 
{{% /alert %}}

## **پیچش متن**

اگر می‌خواهید متن داخل یک شکل هنگام عبور از مرزهای عرضی شکل (فقط عرض) به داخل همان شکل پیچیده شود، باید از پارامتر **Wrap text in shape** استفاده کنید. برای تعیین این تنظیم، باید ویژگی [wrap_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframeformat/) به `NullableBool.TRUE` تنظیم کنید. 

این کد پایتون نشان می‌دهد که چگونه تنظیم Wrap Text را در یک ارائه PowerPoint به کار ببرید:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="نکته" color="warning" %}} 
اگر ویژگی `wrap_text` را برای یک شکل به `NullableBool.FALSE` تنظیم کنید، وقتی متن داخل شکل بیشتر از عرض شکل شود، متن در یک خط به‌صورت مستقیم از مرزهای شکل فراتر می‌رود. 
{{% /alert %}}

## **سوالات متداول**

**آیا حاشیه‌های داخلی فریم متن بر AutoFit تأثیر می‌گذارد؟**  
بله. Padding (حاشیه‌های داخلی) مساحت قابل استفاده برای متن را کاهش می‌دهد، بنابراین AutoFit زودتر فعال می‌شود—فونت را کوچک‌تر یا شکل را زودتر تغییر اندازه می‌دهد. پیش از تنظیم AutoFit حاشیه‌ها را بررسی و تنظیم کنید.  

**AutoFit چگونه با شکست خط دستی و نرم تعامل دارد؟**  
خط‌های شکسته شده به‌صورت ثابت باقی می‌مانند و AutoFit اندازه فونت و فاصله‌ها را دور آن‌ها تنظیم می‌کند. حذف شکست‌های غیرضروری معمولاً نیاز AutoFit به کوچک کردن متن را کاهش می‌دهد.  

**آیا تغییر فونت تم یا اعمال جایگزینی فونت بر نتایج AutoFit تأثیر دارد؟**  
بله. جایگزینی با فونتی که اندازه‌های گلیف متفاوتی دارد، عرض/ارتفاع متن را تغییر می‌دهد و می‌تواند اندازه نهایی فونت و پیچش خط را تحت تأثیر قرار دهد. پس از هر تغییر یا جایگزینی فونت، اسلایدها را مجدداً بررسی کنید.