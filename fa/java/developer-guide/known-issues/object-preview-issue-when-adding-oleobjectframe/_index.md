---
title: مشکل پیش‌نمایش شیء هنگام افزودن OleObjectFrame
linktitle: مشکل شیء OLE
type: docs
weight: 10
url: /fa/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشکل پیش‌نمایش
- شیء جاسازی‌شده
- فایل جاسازی‌شده
- شیء تغییر یافته
- پیش‌نمایش شیء
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "دلیل ظاهر شدن پیام EMBEDDED OLE OBJECT هنگام افزودن OleObjectFrame در Aspose.Slides برای Java و نحوه رفع مشکلات پیش‌نمایش در ارائه‌های PPT، PPTX و ODP را بیاموزید."
---
## **مقدمه**

با استفاده از Aspose.Slides برای Java، وقتی یک [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/oleobjectframe/) را به یک اسلاید اضافه می‌کنید، پیام «EMBEDDED OLE OBJECT» بر روی اسلاید خروجی نمایش داده می‌شود. این پیام عمداً نمایش داده می‌شود و خطایی نیست.

برای اطلاعات بیشتر در مورد کار با اشیاء OLE، به [Manage OLE](/slides/fa/java/manage-ole/) مراجعه کنید. 

## **توضیح و راه‌حل**

Aspose.Slides پیام «EMBEDDED OLE OBJECT» را برای این که به شما اطلاع دهد شیء OLE تغییر کرده و تصویر پیش‌نمایش باید به‌روز شود، نمایش می‌دهد. 

به عنوان مثال، اگر یک نمودار Microsoft Excel را به عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/oleobjectframe/) به اسلاید اضافه کنید (برای جزئیات بیشتر مقاله «Manage OLE» را ببینید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را در اسلاید خواهید دید:

![OLE object message](OLE_object_message.png)

اگر می‌خواهید بررسی و تأیید کنید که شیء OLE شما به اسلاید اضافه شده است، باید روی پیام «EMBEDDED OLE OBJECT» دوبار کلیک کنید، یا می‌توانید روی آن کلیک راست کنید و گزینه **Object > Edit** را انتخاب کنید.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint سپس شیء OLE تعبیه‌شده را باز می‌کند.

![OLE object data](OLE_object_data.png)

ممکن است اسلاید پیام «EMBEDDED OLE OBJECT» را نگه دارد. وقتی روی شیء OLE کلیک می‌کنید، پیش‌نمایش اسلاید به‌روز می‌شود و پیام «EMBEDDED OLE OBJECT» با تصویر واقعی شیء OLE جایگزین می‌شود. 

![OLE object preview](OLE_object_preview.png)

حالا ممکن است بخواهید ارائه خود را ذخیره کنید تا اطمینان حاصل شود تصویر شیء OLE به‌درستی به‌روز شده است. به این ترتیب، پس از ذخیره‌سازی ارائه، وقتی دوباره آن را باز می‌کنید، پیام «EMBEDDED OLE OBJECT» را نخواهید دید. 

## **راه‌حل دیگر**

اگر نمی‌خواهید با باز کردن ارائه در PowerPoint و سپس ذخیره‌سازی، پیام «EMBEDDED OLE OBJECT» را حذف کنید، می‌توانید این پیام را با تصویر پیش‌نمایش دلخواه خود جایگزین کنید. خطوط کد زیر این فرآیند را نشان می‌دهند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // یک تصویر به منابع ارائه اضافه کنید.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // یک عنوان و تصویر برای پیش‌نمایش شیء OLE تنظیم کنید.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

اسلاید حاوی `OleObjectFrame` سپس به این شکل تغییر می‌کند:

![New OLE object image](OLE_object_new_image.png)