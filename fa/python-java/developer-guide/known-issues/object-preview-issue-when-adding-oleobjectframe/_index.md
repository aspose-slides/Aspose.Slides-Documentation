---
title: مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame
linktitle: مشکل شی OLE
type: docs
weight: 10
url: /fa/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشکل پیش‌نمایش
- جاسازی شیء
- جاسازی فایل
- شی تغییر کرده
- پیش‌نمایش شیء
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "دلیل نمایش پیام EMBEDDED OLE OBJECT هنگام افزودن OleObjectFrame در Aspose.Slides برای Python از طریق Java و نحوه رفع مشکلات پیش‌نمایش در ارائه‌های PPT، PPTX و ODP را بیاموزید."
---
## **مقدمه**

هنگامی که از Aspose.Slides برای Python از طریق Java استفاده می‌کنید تا یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) به اسلاید اضافه کنید، پیام «EMBEDDED OLE OBJECT» روی اسلاید خروجی نمایش داده می‌شود. این پیام عمدی است و نقصی نیست.

برای اطلاعات بیشتر درباره کار با اشیای OLE، به [مدیریت OLE](/slides/fa/python-java/manage-ole/) مراجعه کنید.

## **توضیح و راه حل**

Aspose.Slides پیام «EMBEDDED OLE OBJECT» را برای اطلاع‌رسانی اینکه شی OLE تغییر کرده و تصویر پیش‌نمایش باید به‌روزرسانی شود، نمایش می‌دهد.

به عنوان مثال، اگر یک نمودار Microsoft Excel را به عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) به اسلاید اضافه کنید (برای جزئیات بیشتر، مقاله «مدیریت OLE» را ببینید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را روی اسلاید خواهید دید:

![پیام شی OLE](OLE_object_message.png)

برای تأیید اینکه شی OLE به اسلاید اضافه شده است، روی پیام «EMBEDDED OLE OBJECT» دو بار کلیک کنید یا روی آن کلیک راست کرده و **Object > Edit** را انتخاب کنید.

![شی OLE > ویرایش](OLE_object_edit.png)

PowerPoint سپس شی OLE جاسازی‌شده را باز می‌کند.

![داده‌های شی OLE](OLE_object_data.png)

ممکن است اسلاید پیام «EMBEDDED OLE OBJECT» را نگه دارد. هنگامی که روی شی OLE کلیک کنید، پیش‌نمایش اسلاید به‌روزرسانی می‌شود و پیام «EMBEDDED OLE OBJECT» با تصویر واقعی شی OLE جایگزین می‌شود.

![پیش‌نمایش شی OLE](OLE_object_preview.png)

پیشنهاد می‌شود ارائه خود را ذخیره کنید تا تصویر پیش‌نمایش به‌روزرسانی‌شده شی OLE حفظ شود. هنگام باز کردن مجدد ارائه، دیگر پیام «EMBEDDED OLE OBJECT» را نخواهید دید.

## **راه حل دیگر**

اگر نمی‌خواهید برای حذف پیام «EMBEDDED OLE OBJECT» ارائه را در PowerPoint باز کنید و سپس ذخیره کنید، می‌توانید پیام را با تصویر پیش‌نمایش مورد نظر خود جایگزین کنید. کد زیر این فرایند را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # یک تصویر به منابع ارائه اضافه کنید.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # یک عنوان و تصویر برای پیش‌نمایش شی OLE تنظیم کنید.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اسلاید حاوی [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) سپس به این شکل تغییر می‌کند:

![تصویر جدید شی OLE](OLE_object_new_image.png)

## **سوالات متداول**

**چرا پیام «EMBEDDED OLE OBJECT» نمایش داده می‌شود؟**

این پیام نشان می‌دهد که شی OLE تغییر کرده و تصویر پیش‌نمایش آن نیاز به به‌روزرسانی دارد. این رفتار عمدی است.

**چگونه می‌توان پیش‌نمایش را در PowerPoint به‌روزرسانی کرد؟**

روی پیام دو بار کلیک کنید یا **Object > Edit** را انتخاب کنید تا شی OLE جاسازی‌شده باز شود. سپس روی شی OLE کلیک کنید تا پیش‌نمایش به‌روز شود و پس از آن ارائه را ذخیره کنید.

**آیا می‌توان بدون باز کردن ارائه در PowerPoint، پیام را جایگزین کرد؟**

بله. می‌توانید همان‌طور که در مثال کد بالا نشان داده شد، یک تصویر پیش‌نمایش دلخواه را به شی OLE اختصاص دهید.