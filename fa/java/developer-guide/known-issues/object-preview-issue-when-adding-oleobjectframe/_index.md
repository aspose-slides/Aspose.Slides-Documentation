---
title: مسئله پیش‌نمایش شیء هنگام افزودن OleObjectFrame
linktitle: مشکل شی OLE
type: docs
weight: 10
url: /fa/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشکل پیش‌نمایش
- شی تعبیه‌شده
- فایل تعبیه‌شده
- شی تغییر کرده
- پیش‌نمایش شیء
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "درک کنید چرا هنگام افزودن OleObjectFrame در Aspose.Slides برای Java پیام EMBEDDED OLE OBJECT ظاهر می‌شود و چگونه مشکلات پیش‌نمایش را در ارائه‌های PPT، PPTX و ODP برطرف کنید."
---
## **مقدمه**

با استفاده از Aspose.Slides برای Java، هنگامی که یک [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/oleobjectframe/) را به یک اسلاید اضافه می‌کنید، پیام «EMBEDDED OLE OBJECT» بر روی اسلاید خروجی نمایش داده می‌شود. این پیام عمدی است و باگی نیست.

برای اطلاعات بیشتر درباره کار با اشیاء OLE، به بخش [مدیریت OLE](/slides/fa/java/manage-ole/) مراجعه کنید. 

## **توضیح و راه حل**

Aspose.Slides پیام «EMBEDDED OLE OBJECT» را برای اطلاع رسانی این که شی OLE تغییر کرده و تصویر پیش‌نمایش باید به‌روز شود، نمایش می‌دهد. 

به عنوان مثال، اگر یک نمودار Microsoft Excel را به عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/oleobjectframe/) به اسلاید اضافه کنید (برای جزئیات بیشتر، مقاله «مدیریت OLE» را ببینید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را در اسلاید مشاهده خواهید کرد:

![پیام شی OLE](OLE_object_message.png)

اگر می‌خواهید تأیید کنید که شی OLE به اسلاید اضافه شده است، باید روی پیام «EMBEDDED OLE OBJECT» دوبار کلیک کنید، یا می‌توانید روی آن کلیک راست کرده و گزینه **Object > Edit** را انتخاب کنید.

![شی OLE > Edit](OLE_object_edit.png)

PowerPoint سپس شی OLE تعبیه‌شده را باز می‌کند.

![داده‌های شی OLE](OLE_object_data.png)

ممکن است اسلاید پیام «EMBEDDED OLE OBJECT» را حفظ کند. پس از کلیک بر روی شی OLE، پیش‌نمایش اسلاید به‌روز می‌شود و پیام «EMBEDDED OLE OBJECT» با تصویر واقعی شی OLE جایگزین می‌شود. 

![پیش‌نمایش شی OLE](OLE_object_preview.png)

حالا ممکن است بخواهید ارائه خود را ذخیره کنید تا اطمینان حاصل کنید تصویر شی OLE به‌درستی به‌روز شده است. به این ترتیب، پس از ذخیره‌سازی ارائه و باز کردن مجدد آن، دیگر پیام «EMBEDDED OLE OBJECT» را نخواهید دید. 

## **سایر راه حل‌ها**

### **راه حل 1: جایگزینی پیام «Embedded OLE Object» با یک تصویر**

اگر نمی‌خواهید با باز کردن ارائه در PowerPoint و سپس ذخیره آن، پیام «EMBEDDED OLE OBJECT» را حذف کنید، می‌توانید پیام را با تصویر پیش‌نمایش دلخواه خود جایگزین کنید. این خطوط کد روند را نشان می‌دهند:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // یک تصویر به منابع ارائه اضافه کنید.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // یک عنوان و تصویر برای پیش‌نمایش شی OLE تنظیم کنید.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

اسلاید حاوی `OleObjectFrame` سپس به این صورت تغییر می‌کند:

![تصویر جدید شی OLE](OLE_object_new_image.png)

### **راه حل 2: ایجاد افزونه‌ای برای PowerPoint**

همچنین می‌توانید یک افزونه برای Microsoft PowerPoint ایجاد کنید که تمام اشیاء OLE را هنگام باز کردن ارائه‌ها در برنامه به‌روز می‌کند.