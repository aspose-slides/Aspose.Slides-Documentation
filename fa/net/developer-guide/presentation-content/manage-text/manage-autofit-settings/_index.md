---
title: بهبود ارائه‌های خود با AutoFit در .NET
linktitle: تنظیمات Autofit
type: docs
weight: 30
url: /fa/net/manage-autofit-settings/
keywords:
- جعبه متن
- autofit
- عدم autofit
- متن مناسب
- کاهش متن
- پیچش متن
- تغییر اندازه شکل
- PowerPoint
- ارائه
- C#
- .NET
- Aspose.Slides
description: "یاد بگیرید چگونه تنظیمات AutoFit را در Aspose.Slides برای .NET مدیریت کنید تا نمایش متن در ارائه‌های PowerPoint و OpenDocument خود را بهینه‌سازی کرده و خوانایی محتوا را بهبود بخشید."
---
## **معرفی**

به‌طور پیش‌فرض، وقتی یک جعبه متن اضافه می‌کنید، Microsoft PowerPoint از تنظیم **Resize shape to fit text** برای جعبه متن استفاده می‌کند—به‌صورت خودکار اندازه جعبه متن را تغییر می‌دهد تا متن همیشه داخل آن جا بگیرد.

![یک جعبه متن در PowerPoint](textbox-in-powerpoint.png)

* وقتی متن در جعبه متن طولانی‌تر یا بزرگ‌تر می‌شود، PowerPoint به‌صورت خودکار جعبه متن را بزرگ می‌کند—ارتفاع آن را افزایش می‌دهد—تا متن بیشتری را در خود جای دهد.
* وقتی متن در جعبه متن کوتاه‌تر یا کوچک‌تر می‌شود، PowerPoint به‌صورت خودکار جعبه متن را کوچک می‌کند—ارتفاع آن را کاهش می‌دهد—تا فضای اضافی حذف شود.

در PowerPoint، این چهار پارامتر یا گزینه مهم برای کنترل رفتار Autofit یک جعبه متن هستند:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![گزینه‌های Autofit در PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET گزینه‌های مشابهی را فراهم می‌کند—ویژگی‌هایی تحت کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat)—که به شما اجازه می‌دهد رفتار Autofit را برای جعبه‌های متن در ارائه‌ها کنترل کنید.

## **تغییر اندازه شکل برای متن**

اگر می‌خواهید متن همیشه در جعبه‌اش جا بگیرد حتی پس از تغییرات متن، باید گزینه **Resize shape to fit text** را استفاده کنید. برای تعیین این تنظیم، ویژگی `AutofitType` را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat) به مقدار `Shape` تنظیم کنید.

![تغییر اندازه شکل برای متن](alwaysfit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

اگر متن طولانی‌تر یا بزرگ‌تر شود، جعبه متن به‌صورت خودکار (ارتفاع آن افزایش می‌یابد) تغییر اندازه می‌دهد تا تمام متن در آن جا بگیرد. اگر متن کوتاه‌تر شود، روند معکوس رخ می‌دهد.

## **عدم استفاده از Autofit**

اگر می‌خواهید یک جعبه متن یا شکل ابعاد خود را صرف‌نظر از تغییرات متن حفظ کند، باید گزینه **Do not Autofit** را استفاده کنید. برای تعیین این تنظیم، ویژگی `AutofitType` را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat) به مقدار `None` تنظیم کنید.

![تنظیم «Do not Autofit» در PowerPoint](donotautofit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

هنگامی که متن بیش از حد طولانی می‌شود، از جعبه بیرون می‌ریزد.

## **کاهش اندازه متن در صورت سرریز**

اگر متن بیش از حد طولانی شود، با استفاده از گزینه **Shrink text on overflow** می‌توانید تعیین کنید که اندازه و فاصله متن کاهش یابد تا در جعبه‌اش جا بگیرد. برای تعیین این تنظیم، ویژگی `AutofitType` را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat) به مقدار `Normal` تنظیم کنید.

![تنظیم «Shrink text on overflow» در PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
وقتی گزینه **Shrink text on overflow** استفاده شود، این تنظیم تنها زمانی اعمال می‌شود که متن بیش از حد طولانی شود.
{{% /alert %}}

## **پیچش متن**

اگر می‌خواهید متن داخل یک شکل وقتی از عرض شکل فراتر رود، داخل همان شکل پیچیده شود، باید از پارامتر **Wrap text in shape** استفاده کنید. برای تعیین این تنظیم، ویژگی `WrapText` را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/textframeformat) به مقدار `NullableBool.True` تنظیم کنید.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 
اگر ویژگی `WrapText` را برای یک شکل به `NullableBool.False` تنظیم کنید، زمانی که متن داخل شکل طولانی‌تر از عرض شکل شود، متن در یک خط به خارج از مرزهای شکل ادامه می‌دهد.
{{% /alert %}}

## **سوالات متداول**

**آیا حاشیه‌های داخلی فریم متن بر AutoFit اثر می‌گذارند؟**

بله. حاشیه‌های داخلی (Padding) مساحت قابل استفاده برای متن را کاهش می‌دهند، بنابراین AutoFit زودتر فعال می‌شود—فونت را کوچک‌کند یا شکل را زودتر تغییر اندازه می‌دهد. قبل از تنظیم AutoFit، حاشیه‌ها را بررسی و تنظیم کنید.

**AutoFit چگونه با شکست‌خط‌های دستی و نرم تعامل دارد؟**

شکست‌خط‌های اجباری باقی می‌مانند و AutoFit اندازه و فاصله فونت را اطراف آن‌ها تنظیم می‌کند. حذف شکست‌خط‌های غیرضروری معمولاً میزان کاهش متن توسط AutoFit را کاهش می‌دهد.

**آیا تغییر فونت تم یا جایگزینی فونت بر نتایج AutoFit تأثیر می‌گذارد؟**

بله. جایگزینی با فونتی که متریک‌های گلیف متفاوتی دارد، عرض/ارتفاع متن را تغییر می‌دهد و می‌تواند اندازه نهایی فونت و پیچش خطوط را تحت تأثیر قرار دهد. پس از هر تغییر یا جایگزینی فونت، اسلایدها را مجدداً بررسی کنید.