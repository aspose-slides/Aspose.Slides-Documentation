---
title: مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame
linktitle: مشکل شی OLE
type: docs
weight: 10
url: /fa/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشکل پیش‌نمایش
- شی جاسازی شده
- فایل جاسازی شده
- شی تغییر کرده
- پیش‌نمایش شی
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "بیاموزید چرا پیام EMBEDDED OLE OBJECT هنگام افزودن OleObjectFrame در Aspose.Slides برای Node.js ظاهر می‌شود و چگونه مشکلات پیش‌نمایش در ارائه‌های PPT، PPTX و ODP را برطرف کنید."
---
## **معرفی**

با استفاده از Aspose.Slides برای Java، وقتی یک [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleobjectframe/) را به یک اسلاید اضافه می‌کنید، پیام "EMBEDDED OLE OBJECT" روی اسلاید خروجی نشان داده می‌شود. این پیام عمداً نمایش داده می‌شود و NOT a bug.

برای اطلاعات بیشتر در مورد کار با اشیای OLE، به [Manage OLE](/slides/fa/nodejs-java/manage-ole/) مراجعه کنید.

## **توضیح و راه حل**

Aspose.Slides پیام "EMBEDDED OLE OBJECT" را برای اطلاع شما از اینکه شی OLE تغییر کرده و باید تصویر پیش‌نمایش به‌روزرسانی شود، نمایش می‌دهد.

به عنوان مثال، اگر یک نمودار Microsoft Excel را به عنوان [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleobjectframe/) به یک اسلاید اضافه کنید (برای جزئیات بیشتر، مقاله "Manage OLE" را ببینید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را روی اسلاید خواهید دید:

![OLE object message](OLE_object_message.png)

اگر می‌خواهید بررسی و تأیید کنید که شی OLE شما به اسلاید اضافه شده است، باید روی پیام "EMBEDDED OLE OBJECT" دوبار کلیک کنید، یا می‌توانید راست‑کلیک کنید و گزینه **Object > Edit** را انتخاب کنید.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint سپس شی OLE Embedded را باز می‌کند.

![OLE object data](OLE_object_data.png)

ممکن است اسلاید پیام "EMBEDDED OLE OBJECT" را حفظ کند. پس از کلیک روی شی OLE، پیش‌نمایش اسلاید به‌روزرسانی می‌شود و پیام "EMBEDDED OLE OBJECT" با تصویر واقعی شی OLE جایگزین می‌شود.

![OLE object preview](OLE_object_preview.png)

اکنون ممکن است بخواهید ارائه خود را ذخیره کنید تا مطمئن شوید تصویر شی OLE به‌درستی به‌روز شده است. به این ترتیب، پس از ذخیره ارائه، وقتی دوباره آن را باز می‌کنید، پیام "EMBEDDED OLE OBJECT" را نخواهید دید.

## **راه حل‌های دیگر**

### **راه حل ۱: جایگزینی پیام "Embedded OLE Object" با یک تصویر**

اگر نمی‌خواهید پیام "EMBEDDED OLE OBJECT" را با باز کردن ارائه در PowerPoint و سپس ذخیره‌سازی آن حذف کنید، می‌توانید این پیام را با تصویر پیش‌نمایش دلخواه خود جایگزین کنید. خطوط زیر از کد فرآیند را نشان می‌دهند:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // یک تصویر به منابع ارائه اضافه کنید.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // یک عنوان و تصویر برای پیش‌نمایش شی OLE تنظیم کنید.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

اسلاید حاوی `OleObjectFrame` سپس به این شکل تغییر می‌کند:

![New OLE object image](OLE_object_new_image.png)

### **راه حل ۲: ایجاد یک افزودنی برای PowerPoint**

همچنین می‌توانید یک افزودنی برای Microsoft PowerPoint ایجاد کنید که تمام اشیای OLE را هنگام باز کردن ارائه‌ها در برنامه به‌روز رسانی کند.