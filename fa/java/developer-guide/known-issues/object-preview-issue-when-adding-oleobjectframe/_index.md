---
title: نماد جایگزین پیش‌نمایش شیء هنگام افزودن OleObjectFrame
linktitle: نماد پیش‌نمایش OLE
type: docs
weight: 10
url: /fa/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مسئله پیش‌نمایش
- محل‌نگهدار پیش‌نمایش
- طراحی شده
- جاسازی شیء
- جاسازی فایل
- شیء تغییر کرده
- پیش‌نمایش شیء
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "دلیل نمایش یک شی OLE که با Aspose.Slides برای Java اضافه شده است، به‌صورت نگهدارنده EMBEDDED OLE OBJECT تا زمانی که پیش‌نمایش آن به‌روز شود، و چگونگی تنظیم تصویر پیش‌نمایش خودتان."
---
## **مقدمه**

با استفاده از Aspose.Slides برای Java، زمانی که یک [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/oleobjectframe/) را به یک اسلاید اضافه می‌کنید، پیام «EMBEDDED OLE OBJECT» روی اسلاید خروجی نمایش داده می‌شود. این پیام به‌طور عمدی است و خطا نیست.

برای اطلاعات بیشتر در مورد کار با اشیاء OLE، به [Manage OLE](/slides/fa/java/manage-ole/) مراجعه کنید.

## **توضیح و راه‌حل**

Aspose.Slides پیام «EMBEDDED OLE OBJECT» را نمایش می‌دهد تا به شما اطلاع دهد که شی OLE تغییر کرده و تصویر پیش‌نمایش باید به‌روز شود.

به‌عنوان مثال، اگر یک نمودار Microsoft Excel را به‌عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/oleobjectframe/) به یک اسلاید اضافه کنید (برای جزئیات بیشتر، مقاله «Manage OLE» را ببینید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را بر روی اسلاید مشاهده خواهید کرد:

![پیام شی OLE](OLE_object_message.png)

اگر می‌خواهید بررسی کنید و تأیید کنید که شی OLE شما به اسلاید اضافه شده است، باید روی پیام «EMBEDDED OLE OBJECT» دوبار کلیک کنید، یا می‌توانید روی آن کلیک راست کنید و گزینه **Object > Edit** را انتخاب کنید.

![شی OLE > Edit](OLE_object_edit.png)

PowerPoint سپس شی OLE تعبیه‌شده را باز می‌کند.

![داده‌های شی OLE](OLE_object_data.png)

ممکن است اسلاید پیام «EMBEDDED OLE OBJECT» را حفظ کند. زمانی که روی شی OLE کلیک کنید، پیش‌نمایش اسلاید به‌روز شده و پیام «EMBEDDED OLE OBJECT» با تصویر واقعی شی OLE جایگزین می‌شود.

![پیش‌نمایش شی OLE](OLE_object_preview.png)

اکنون ممکن است بخواهید ارائه خود را ذخیره کنید تا اطمینان حاصل کنید تصویر شی OLE به‌درستی به‌روز شده است. به این ترتیب، پس از ذخیره ارائه، وقتی دوباره آن را باز کنید، پیام «EMBEDDED OLE OBJECT» را نخواهید دید.

## **راه‌حل دیگر**

اگر نمی‌خواهید با باز کردن ارائه در PowerPoint و سپس ذخیره آن، پیام «EMBEDDED OLE OBJECT» را حذف کنید، می‌توانید این پیام را با تصویر پیش‌نمایش دلخواه خود جایگزین کنید. خطوط کد زیر این فرآیند را نشان می‌دهند. فرض می‌شود اولین شکل در اولین اسلاید *embeddedOLE.pptx*، فریم شی OLE است و *myImage.png* حاوی تصویری است که می‌خواهید نمایش دهید؛ نتیجه نیز به عنوان *embeddedOLE-newImage.pptx* ذخیره می‌شود:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // یک تصویر به منابع ارائه اضافه کنید.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // تصویر پیش‌نمایش شی OLE را تنظیم کنید.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اسلاید حاوی `OleObjectFrame` سپس به این شکل تغییر می‌کند:

![تصویر جدید شی OLE](OLE_object_new_image.png)