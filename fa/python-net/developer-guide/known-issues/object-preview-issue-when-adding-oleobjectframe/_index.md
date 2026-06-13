---
title: مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame
linktitle: مشکل شی OLE
type: docs
weight: 10
url: /fa/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشکل پیش‌نمایش
- جاسازی شی
- جاسازی فایل
- شی تغییر کرده
- پیش‌نمایش شی
- ارائه
- پاورپوینت
- پایتون
- Aspose.Slides
description: "بیاموزید چرا پیام EMBEDDED OLE OBJECT هنگام افزودن OleObjectFrame در Aspose.Slides برای پایتون ظاهر می‌شود و چگونه مشکلات پیش‌نمایش را در ارائه‌های PPT، PPTX و ODP برطرف کنید."
---
## **معرفی**

با استفاده از Aspose.Slides برای Python از طریق .NET، وقتی یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) را به یک اسلاید اضافه می‌کنید، پیام «آبجکت OLE جاسازی‌شده» روی اسلاید خروجی ظاهر می‌شود. این پیام عمدی است و خطا نیست.

برای اطلاعات بیشتر درباره کار با اشیای OLE، به [مدیریت OLE](/slides/fa/python-net/manage-ole/) مراجعه کنید. 

## **توضیح و راه حل**

Aspose.Slides پیام «آبجکت OLE جاسازی‌شده» را برای اطلاع شما نمایش می‌دهد که شی OLE تغییر کرده و تصویر پیش‌نمایش باید به‌روز شود. 

به عنوان مثال، اگر یک چارت Microsoft Excel را به عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) به اسلاید اضافه کنید (برای جزئیات بیشتر، مقاله «مدیریت OLE» را ببینید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را روی اسلاید خواهید دید:

![OLE object message](OLE_object_message.png)

اگر می‌خواهید تأیید کنید که شی OLE شما به اسلاید اضافه شده است، باید دو بار روی پیام «آبجکت OLE جاسازی‌شده» کلیک کنید، یا می‌توانید روی آن کلیک راست کنید و گزینه **Object > Edit** را انتخاب کنید.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint سپس شی OLE جاسازی‌شده را باز می‌کند.

![OLE object data](OLE_object_data.png)

اسلاید ممکن است پیام «آبجکت OLE جاسازی‌شده» را نگه دارد. وقتی بر روی شی OLE کلیک کنید، پیش‌نمایش اسلاید به‌روزرسانی می‌شود و پیام «آبجکت OLE جاسازی‌شده» با تصویر واقعی شی OLE جایگزین می‌شود. 

![OLE object preview](OLE_object_preview.png)

حال ممکن است بخواهید ارائه خود را ذخیره کنید تا تصویر شی OLE به‌درستی به‌روز شود. به این ترتیب، پس از ذخیره‌سازی ارائه و باز کردن دوباره آن، پیام «آبجکت OLE جاسازی‌شده» نمایش داده نخواهد شد. 

## **راه‌حل‌های دیگر**

### **راه‌حل 1: جایگزین کردن پیام «آبجکت OLE جاسازی‌شده» با یک تصویر**

اگر نمی‌خواهید با باز کردن ارائه در PowerPoint و سپس ذخیره‌کردن، پیام «آبجکت OLE جاسازی‌شده» را حذف کنید، می‌توانید این پیام را با تصویر پیش‌نمایش دلخواه خود جایگزین کنید. این خطوط کد فرآیند را نشان می‌دهد:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # افزودن یک تصویر به منابع ارائه.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # تنظیم عنوان و تصویر برای پیش‌نمایش شی OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

سپس اسلاید حاوی `OleObjectFrame` به این شکل تغییر می‌کند:

![New OLE object image](OLE_object_new_image.png)

### **راه‌حل 2: ایجاد افزونه‌ای برای PowerPoint**

همچنین می‌توانید یک افزونه برای Microsoft PowerPoint ایجاد کنید که تمام اشیای OLE را هنگام باز کردن ارائه‌ها در برنامه به‌روز کند.