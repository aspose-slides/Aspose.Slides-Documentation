---
title: مشکل پیش‌نمایش شیء هنگام افزودن OleObjectFrame
linktitle: مشکل شیء OLE
type: docs
weight: 10
url: /fa/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشکل پیش‌نمایش
- شیء جاسازی شده
- فایل جاسازی شده
- شی تغییر کرده
- پیش‌نمایش شیء
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "دلیل نمایش پیام EMBEDDED OLE OBJECT هنگام افزودن OleObjectFrame در Aspose.Slides برای PHP و نحوه رفع مشکلات پیش‌نمایش در ارائه‌های PPT، PPTX و ODP را بیاموزید."
---
## **مقدمه**

با استفاده از Aspose.Slides برای PHP از طریق Java، وقتی یک [OleObjectFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleobjectframe/) را به یک اسلاید اضافه می‌کنید، پیام «EMBEDDED OLE OBJECT» روی اسلاید خروجی نمایش داده می‌شود. این پیام عمدی است و خطایی نیست.

برای اطلاعات بیشتر درباره کار با اشیاء OLE، به [Manage OLE](/slides/fa/php-java/manage-ole/) مراجعه کنید. 

## **توضیح و راه‌حل**

Aspose.Slides پیام «EMBEDDED OLE OBJECT» را برای اطلاع‌رسانی اینکه شیء OLE تغییر کرده و تصویر پیش‌نمایش باید به‌روزرسانی شود، نشان می‌دهد. 

به عنوان مثال، اگر یک نمودار Microsoft Excel را به عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/oleobjectframe/) به اسلاید اضافه کنید (برای جزئیات بیشتر به مقاله «Manage OLE» مراجعه کنید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را روی اسلاید می‌بینید:

![پیام شیء OLE](OLE_object_message.png)

اگر می‌خواهید تأیید کنید که شیء OLE شما به اسلاید اضافه شده است، باید روی پیام «EMBEDDED OLE OBJECT» دوبار کلیک کنید، یا می‌توانید روی آن کلیک راست کنید و گزینه **Object > Edit** را انتخاب کنید.

![شیء OLE > ویرایش](OLE_object_edit.png)

PowerPoint سپس شیء OLE توکار را باز می‌کند.

![داده‌های شیء OLE](OLE_object_data.png)

اسلاید ممکن است پیام «EMBEDDED OLE OBJECT» را نگه دارد. پس از کلیک روی شیء OLE، پیش‌نمایش اسلاید به‌روزرسانی می‌شود و پیام «EMBEDDED OLE OBJECT» با تصویر واقعی شیء OLE جایگزین می‌شود. 

![پیش‌نمایش شیء OLE](OLE_object_preview.png)

حالا ممکن است بخواهید ارائه خود را ذخیره کنید تا تصویر شیء OLE به‌درستی به‌روزرسانی شود. به این ترتیب، پس از ذخیرهٔ ارائه و باز کردن مجدد آن، پیام «EMBEDDED OLE OBJECT» را مشاهده نخواهید کرد. 

## **راه‌حل‌های دیگر**

### **راه‌حل ۱: جایگزینی پیام "Embedded OLE Object" با یک تصویر**

اگر نمی‌خواهید با باز کردن ارائه در PowerPoint و سپس ذخیرهٔ آن، پیام «EMBEDDED OLE OBJECT» را حذف کنید، می‌توانید پیام را با تصویر پیش‌نمایش دلخواه خود جایگزین کنید. این خطوط کد فرآیند را نشان می‌دهند:

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // یک تصویر به منابع ارائه اضافه کنید.
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // عنوان و تصویر پیش‌نمایش شیء OLE را تنظیم کنید.
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

اسلاید حاوی `OleObjectFrame` سپس به این شکل تغییر می‌کند:

![تصویر جدید شیء OLE](OLE_object_new_image.png)

### **راه‌حل ۲: ایجاد افزونه‌ای برای PowerPoint**

همچنین می‌توانید یک افزونه برای Microsoft PowerPoint ایجاد کنید که تمام اشیاء OLE را هنگام باز کردن ارائه‌ها در برنامه به‌روزرسانی کند.