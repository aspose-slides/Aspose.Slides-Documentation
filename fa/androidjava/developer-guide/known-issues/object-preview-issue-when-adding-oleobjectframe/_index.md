---
title: مشکل پیش‌نمایش شیء هنگام افزودن OleObjectFrame
linktitle: مشکل شی OLE
type: docs
weight: 10
url: /fa/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشکل پیش‌نمایش
- جاسازی شیء
- جاسازی فایل
- تغییر شیء
- پیش‌نمایش شیء
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "بیاموزید چرا پیام EMBEDDED OLE OBJECT هنگام افزودن OleObjectFrame در Aspose.Slides برای Android از طریق Java ظاهر می‌شود و چگونه مشکلات پیش‌نمایش در ارائه‌های PPT، PPTX و ODP را رفع کنید."
---
## **مقدمه**

با استفاده از Aspose.Slides برای Android از طریق Java، هنگامی که یک [OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/oleobjectframe/) را به یک اسلاید اضافه می‌کنید، پیام "EMBEDDED OLE OBJECT" در اسلاید خروجی نمایش داده می‌شود. این پیام عمدی است و خطایی نیست.

برای اطلاعات بیشتر درباره کار با اشیاء OLE، به [مدیریت OLE](/slides/fa/androidjava/manage-ole/) مراجعه کنید.

## **توضیح و راه حل**

Aspose.Slides پیام "EMBEDDED OLE OBJECT" را برای اطلاع‌رسانی اینکه شی OLE تغییر کرده و تصویر پیش‌نمایش باید به‌روز شود، نمایش می‌دهد.

برای مثال، اگر یک Microsoft Excel сhart را به عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/oleobjectframe/) به اسلایدی اضافه کنید (برای جزئیات بیشتر، مقاله "Manage OLE" را ببینید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را روی اسلاید خواهید دید:

![پیام شی OLE](OLE_object_message.png)

اگر می‌خواهید بررسی و تأیید کنید که شی OLE شما به اسلاید اضافه شده است، باید روی پیام "EMBEDDED OLE OBJECT" دوبار کلیک کنید، یا می‌توانید راست کلیک کنید و گزینه **Object > Edit** را انتخاب کنید.

![شی OLE > Edit](OLE_object_edit.png)

پس از آن PowerPoint شی OLE توکار را باز می‌کند.

![داده‌های شی OLE](OLE_object_data.png)

اسلاید ممکن است پیام "EMBEDDED OLE OBJECT" را نگه دارد. هنگامی که روی شی OLE کلیک کنید، پیش‌نمایش اسلاید به‌روزرسانی می‌شود و پیام "EMBEDDED OLE OBJECT" با تصویر واقعی شی OLE جایگزین می‌شود.

![پیشنمایش شی OLE](OLE_object_preview.png)

حال ممکن است بخواهید ارائه خود را ذخیره کنید تا مطمئن شوید تصویر شی OLE به‌درستی به‌روز می‌شود. به این ترتیب، پس از ذخیرهٔ ارائه، وقتی دوباره آن را باز می‌کنید، پیام "EMBEDDED OLE OBJECT" را نخواهید دید.

## **راه حل‌های دیگر**

### **راه حل ۱: جایگزینی پیام "Embedded OLE Object" با یک تصویر**

اگر نمی‌خواهید پیام "EMBEDDED OLE OBJECT" را با باز کردن ارائه در PowerPoint و سپس ذخیره‌کردن آن حذف کنید، می‌توانید این پیام را با تصویر پیش‌نمایش دلخواه خود جایگزین کنید. این خطوط کد فرآیند را نشان می‌دهند:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // یک تصویر به منابع ارائه اضافه کنید.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // عنوان و تصویر پیش‌نمایش شی OLE را تنظیم کنید.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

اسلایدی که شامل `OleObjectFrame` است سپس به این تغییر می‌یابد:

![تصویر جدید شی OLE](OLE_object_new_image.png)

### **راه حل ۲: ایجاد یک افزونه برای PowerPoint**

شما همچنین می‌توانید یک افزونه برای Microsoft PowerPoint ایجاد کنید که تمام اشیاء OLE را هنگام باز کردن ارائه‌ها در برنامه به‌روز کند.