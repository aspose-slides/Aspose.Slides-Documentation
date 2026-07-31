---
title: مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame
linktitle: مشکل شی OLE
type: docs
weight: 10
url: /fa/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
  - OLE
  - مشکل پیش‌نمایش
  - شی جاسازی‌شده
  - فایل جاسازی‌شده
  - شی تغییر یافته
  - پیش‌نمایش شی
  - PowerPoint
  - ارائه
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "یاد بگیرید چرا پیام EMBEDDED OLE OBJECT هنگام افزودن OleObjectFrame در Aspose.Slides برای Node.js ظاهر می‌شود و چگونه مشکلات پیش‌نمایش در ارائه‌های PPT، PPTX و ODP را برطرف کنید."
---
## **مقدمه**

با استفاده از Aspose.Slides برای Java، وقتی که یک [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleobjectframe/) را به یک اسلاید اضافه می‌کنید، پیام «EMBEDDED OLE OBJECT» در اسلاید خروجی نمایش داده می‌شود. این پیام عمدی است و خطا نیست.

برای دریافت اطلاعات بیشتر دربارهٔ کار با اشیای OLE، به [Manage OLE](/slides/fa/nodejs-java/manage-ole/) مراجعه کنید. 

## **توضیح و راه حل**

Aspose.Slides پیام «EMBEDDED OLE OBJECT» را نمایش می‌دهد تا به شما اطلاع دهد که شی OOLE تغییر کرده و تصویر پیش‌نمایش باید به‌روزرسانی شود. 

به‌عنوان مثال، اگر یک نمودار Microsoft Excel را به‌عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleobjectframe/) به اسلایدی اضافه کنید (برای جزئیات بیشتر، مقاله «Manage OLE» را ببینید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را روی اسلاید خواهید دید:

![OLE object message](OLE_object_message.png)

اگر می‌خواهید بررسی کنید و تأیید کنید که شی OLE شما به اسلاید اضافه شده است، باید روی پیام «EMBEDDED OLE OBJECT» دوبار کلیک کنید، یا می‌توانید روی آن کلیک راست کنید و گزینه **Object > Edit** را انتخاب کنید.

![OLE object > Edit](OLE_object_edit.png)

پس از آن PowerPoint شی OLE جاسازی‌شده را باز می‌کند.

![OLE object data](OLE_object_data.png)

ممکن است اسلاید پیام «EMBEDDED OLE OBJECT» را حفظ کند. وقتی روی شی OLE کلیک کنید، پیش‌نمایش اسلاید به‌روزرسانی می‌شود و پیام «EMBEDDED OLE OBJECT» با تصویر واقعی شی OLE جایگزین می‌شود. 

![OLE object preview](OLE_object_preview.png)

اکنون ممکن است بخواهید ارائه‌تان را ذخیره کنید تا اطمینان حاصل کنید تصویر شی OLE به‌درستی به‌روزرسانی شده است. به این ترتیب، پس از ذخیرهٔ ارائه و باز کردن دوبارهٔ آن، پیام «EMBEDDED OLE OBJECT» را نخواهید دید. 

## **راه‌حل‌های دیگر**

### **راه‌حل 1: جایگزینی پیام «Embedded OLE Object» با یک تصویر**

اگر نمی‌خواهید پیام «EMBEDDED OLE OBJECT» را با باز کردن ارائه در PowerPoint و سپس ذخیرهٔ آن حذف کنید، می‌توانید این پیام را با تصویر پیش‌نمایش دلخواه خود جایگزین کنید. خطوط کد زیر این فرآیند را نشان می‌دهند:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // افزودن یک تصویر به منابع ارائه.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // تنظیم یک عنوان و تصویر برای پیش‌نمایش شی OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

سینمایی که شامل `OleObjectFrame` است سپس به این شکل تغییر می‌کند:

![New OLE object image](OLE_object_new_image.png)

### **راه‌حل 2: ایجاد افزونه برای PowerPoint**

همچنین می‌توانید یک افزونه برای Microsoft PowerPoint ایجاد کنید که تمام اشیای OLE را هنگام باز کردن ارائه‌ها در برنامه به‌روزرسانی کند.