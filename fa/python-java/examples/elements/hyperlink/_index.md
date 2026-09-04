---
title: هایپرلینک
type: docs
weight: 130
url: /fa/python-java/examples/elements/hyperlink/
keywords:
- مثال کد
- هایپرلینک
- افزودن هایپرلینک
- دسترس به هایپرلینک
- حذف هایپرلینک
- به‌روزرسانی هایپرلینک
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "افزودن و مدیریت هایپرلینک‌ها در Aspose.Slides برای پایتون از طریق جاوا: ایجاد، دسترسی، حذف و به‌روزرسانی پیوندها در ارائه‌های PPT، PPTX و ODP."
---
این مقاله افزودن، دسترسی، حذف و به‌روزرسانی پیوندها بر روی اشکال را با استفاده از **Aspose.Slides برای Python از طریق Java** نشان می‌دهد.

پکیج را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده نصب کنید. هر مثال قبل از راه‌اندازی JVM، `asposeslides` را وارد می‌کند و پس از راه‌اندازی JVM، API را وارد می‌نماید.

## **افزودن پیوند**

یک شکل مستطیلی با پیوندی که به یک وب‌سایت خارجی اشاره می‌کند ایجاد کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **دسترسی به پیوند**

اطلاعات پیوند را از بخش متنی یک شکل بخوانید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **حذف پیوند**

پیوند را از متن یک شکل پاک کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **به‌روزرسانی پیوند**

هدف یک پیوند موجود را تغییر دهید. برای اصلاح متنی که پیش از این شامل پیوند است از [HyperlinkManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/hyperlinkmanager/) استفاده کنید؛ که شبیه‌سازی می‌کند که PowerPoint پیوندها را به‌صورت ایمن به‌روز می‌کند.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # تغییر یک پیوند درون متن موجود باید از طریق
    # HyperlinkManager به جای تنظیم مستقیم ویژگی انجام شود.
    # این شبیه‌سازی می‌کند که PowerPoint پیوندها را به‌صورت ایمن به‌روزرسانی می‌کند.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```