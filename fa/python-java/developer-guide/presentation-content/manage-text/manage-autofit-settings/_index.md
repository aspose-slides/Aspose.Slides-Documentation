---
title: بهبود ارائه‌های شما با AutoFit در Python
linktitle: تنظیمات Autofit
type: docs
weight: 30
url: /fa/python-java/manage-autofit-settings/
keywords:
- جعبه متن
- autofit
- عدم autofit
- متن متناسب
- کاهش متن
- بسته‌بندی متن
- تغییر اندازه شکل
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "نحوه مدیریت تنظیمات AutoFit در Aspose.Slides برای Python via Java را یاد بگیرید تا نمایش متن را در ارائه‌های PowerPoint و OpenDocument بهینه‌سازی کنید و قابلیت خوانایی محتوا را ارتقا دهید."
---
## **مقدمه**

به طور پیش‌فرض، هنگامی که یک جعبه متن اضافه می‌کنید، Microsoft PowerPoint تنظیم **Resize shape to fit text** را برای جعبه متن بکار می‌گیرد—به‌طور خودکار اندازه جعبه متن را تغییر می‌دهد تا متن همواره داخل آن قرار گیرد.

![جعبه متن در PowerPoint](textbox-in-powerpoint.png)

* زمانی که متن در جعبه طولانی یا بزرگ‌تر می‌شود، PowerPoint به‌صورت خودکار جعبه متن را بزرگ می‌کند—ارتفاع آن را افزایش می‌دهد—تا متن بیشتری را در خود جای دهد.
* زمانی که متن در جعبه کوتاه یا کوچک‌تر می‌شود، PowerPoint به‌صورت خودکار جعبه متن را کوچک می‌کند—ارتفاع آن را کاهش می‌دهد—تا فضای اضافی حذف شود.

در PowerPoint، این‌ها چهار پارامتر یا گزینه مهم هستند که رفتار autofit را برای جعبه متن کنترل می‌کنند:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java گزینه‌های مشابهی را فراهم می‌کند—برخی از ویژگی‌ها تحت کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/)—که به شما امکان می‌دهد رفتار autofit را برای جعبه‌های متن در ارائه‌ها کنترل کنید.

## **Resize a Shape to Fit Text**

اگر می‌خواهید متن همیشه در داخل جعبه‌اش قرار بگیرد، باید گزینه **Resize shape to fit text** را استفاده کنید. برای مشخص کردن این تنظیم، از متد [setAutofitType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setAutofitType) (از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/)) با مقدار [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textautofittype/#Shape) استفاده کنید.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

این کد Python نشان می‌دهد چگونه مشخص کنید که متن همیشه در جعبه خود در یک ارائه PowerPoint جا بگیرد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اگر متن طولانی یا بزرگ‌تر شود، جعبه متن به‌صورت خودکار تغییر اندازه می‌دهد (ارتفاع افزایش می‌یابد) تا تمام متن در آن جای بگیرد. اگر متن کوتاه‌تر شود، برعکس اتفاق می‌افتد.

## **Do Not Autofit**

اگر می‌خواهید یک جعبه متن یا شکل ابعاد خود را بدون توجه به تغییرات متن داخل آن حفظ کند، باید گزینه **Do not Autofit** را استفاده کنید. برای مشخص کردن این تنظیم، از متد [setAutofitType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setAutofitType) (از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/)) با مقدار [None](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textautofittype/#None) استفاده کنید.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

این کد Python نشان می‌دهد چگونه مشخص کنید که یک جعبه متن همیشه ابعاد خود را در یک ارائه PowerPoint حفظ کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

زمانی که متن برای جعبه‌اش بیش از حد طولانی شود، خارج می‌شود.

## **Shrink Text on Overflow**

اگر متن برای جعبه‌اش بیش از حد طولانی شود، می‌توانید از گزینه **Shrink text on overflow** استفاده کنید تا اندازه و فاصله‌گذاری متن کاهش یابد و داخل جعبه جا بگیرد. برای مشخص کردن این تنظیم، از متد [setAutofitType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setAutofitType) (از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/)) با مقدار [Normal](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textautofittype/#Normal) استفاده کنید.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

این کد Python نشان می‌دهد چگونه مشخص کنید که متن در سرریز کوچک شود در یک ارائه PowerPoint:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
زمانی که گزینه **Shrink text on overflow** استفاده می‌شود، تنظیم فقط زمانی اعمال می‌شود که متن برای جعبه‌اش بیش از حد طولانی شود. 
{{% /alert %}}

## **Wrap Text**

اگر می‌خواهید متن درون یک شکل هنگام عبور از مرزهای شکل (فقط عرض) درون همان شکل بسته‌بندی (wrap) شود، باید پارامتر **Wrap text in shape** را استفاده کنید. برای مشخص کردن این تنظیم، باید از متد [setWrapText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setWrapText) (از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/)) با مقدار [NullableBool.True_](https://reference.aspose.com/slides/fa/python-java/aspose.slides/nullablebool/#True) استفاده کنید.

این کد Python نشان می‌دهد چگونه تنظیم Wrap Text را در یک ارائه PowerPoint به کار ببرید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
اگر متد [setWrapText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframeformat/#setWrapText) را با مقدار [NullableBool.False](https://reference.aspose.com/slides/fa/python-java/aspose.slides/nullablebool/#False) برای یک شکل استفاده کنید، وقتی متن داخل شکل از عرض شکل بیشتر شود، متن در یک خط ادامه پیدا می‌کند و از مرزهای شکل فراتر می‌رود. 
{{% /alert %}}

## **FAQ**

**آیا حاشیه‌های داخلی فریم متن بر AutoFit تأثیر می‌گذارد؟**

بله. Padding (حاشیه‌های داخلی) فضای قابل استفاده برای متن را کاهش می‌دهد، بنابراین AutoFit زودتر فعال می‌شود—فونت را کوچک‌تر یا شکل را زودتر تغییر اندازه می‌دهد. قبل از تنظیم AutoFit حاشیه‌ها را بررسی و تنظیم کنید.

**AutoFit چگونه با شکست‌های خط دستی و نرم تعامل دارد؟**

شکست‌های خط مجبور‌کننده همان‌جا می‌مانند و AutoFit اندازه فونت و فواصل را پیرامون آن‌ها تنظیم می‌کند. حذف شکست‌های غیرضروری اغلب میزان فشرده‌سازی متن توسط AutoFit را کاهش می‌دهد.

**آیا تغییر فونت تم یا اعمال جایگزینی فونت بر نتایج AutoFit تأثیر می‌گذارد؟**

بله. جایگزینی یک فونت با متریک‌های گلیف متفاوت، عرض/ارتفاع متن را تغییر می‌دهد که می‌تواند اندازه نهایی فونت و بسته‌بندی خطوط را تحت تأثیر قرار دهد. پس از هر تغییر یا جایگزینی فونت، اسلایدها را مجدداً بررسی کنید.