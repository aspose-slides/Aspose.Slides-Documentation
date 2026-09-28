---
title: نگهدارنده پیش‌نمایش شیء هنگام افزودن OleObjectFrame
linktitle: نگهدارنده پیش‌نمایش OLE
type: docs
weight: 10
url: /fa/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشکل پیش‌نمایش
- نگهدارنده پیش‌نمایش
- طراحی شده
- شیء جاسازی شده
- فایل جاسازی شده
- شیء تغییر کرده
- پیش‌نمایش شیء
- ارائه
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "دلیل نمایش نگهدارنده EMBEDDED OLE OBJECT برای شیء OLE که با Aspose.Slides برای .NET اضافه شده است تا زمانی که پیش‌نمایش آن به‌روزرسانی شود، و نحوه تنظیم تصویر پیش‌نمایش خودتان."
---
## **مقدمه**

با استفاده از Aspose.Slides برای .NET، هنگامی که یک [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe/) را به اسلاید اضافه می‌کنید، پیام «EMBEDDED OLE OBJECT» بر روی اسلاید خروجی نمایش داده می‌شود. این پیام عمدی است و یک اشکال نیست.

برای اطلاعات بیشتر درباره کار با اشیاء OLE، به [Manage OLE](/slides/fa/net/manage-ole/) مراجعه کنید.

## **توضیح و راه‌حل**

Aspose.Slides پیام «EMBEDDED OLE OBJECT» را نمایش می‌دهد تا به شما اطلاع دهد که شیء OLE تغییر کرده و تصویر پیش‌نمایش باید به‌روزرسانی شود.

به عنوان مثال، اگر یک نمودار Microsoft Excel را به‌عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe/) به اسلاید اضافه کنید (برای جزئیات بیشتر، مقاله «Manage OLE» را ببینید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را روی اسلاید خواهید دید:

![پیام شیء OLE](OLE_object_message.png)

اگر می‌خواهید بررسی و تأیید کنید که شیء OLE شما به اسلاید اضافه شده است، باید روی پیام «EMBEDDED OLE OBJECT» دوبار کلیک کنید، یا می‌توانید کلیک راست کنید و گزینه **Object > Edit** را انتخاب کنید.

![شیء OLE > ویرایش](OLE_object_edit.png)

PowerPoint سپس شیء OLE توکار را باز می‌کند.

![داده‌های شیء OLE](OLE_object_data.png)

ممکن است اسلاید پیام «EMBEDDED OLE OBJECT» را نگه دارد. هنگامی که روی شیء OLE کلیک کنید، پیش‌نمایش اسلاید به‌روزرسانی می‌شود و پیام «EMBEDDED OLE OBJECT» با تصویر واقعی شیء OLE جایگزین می‌شود.

![پیش‌نمایش شیء OLE](OLE_object_preview.png)

اکنون ممکن است بخواهید ارائه خود را ذخیره کنید تا اطمینان حاصل کنید تصویر شیء OLE به‌درستی به‌روزرسانی می‌شود. به این ترتیب، پس از ذخیرهٔ ارائه، وقتی آن را دوباره باز می‌کنید، پیام «EMBEDDED OLE OBJECT» را نخواهید دید.

## **راه‌حل‌های دیگر**

### **راه‌حل 1: جایگزینی پیام «Embedded OLE Object» با یک تصویر**

اگر نمی‌خواهید پیام «EMBEDDED OLE OBJECT» را با باز کردن ارائه در PowerPoint و سپس ذخیرهٔ آن حذف کنید، می‌توانید پیام را با تصویر پیش‌نمایش دلخواه خود جایگزین کنید. این خطوط کد فرآیند را نشان می‌دهند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

سپس اسلاید حاوی `OleObjectFrame` به این شکل تغییر می‌کند:

![تصویر جدید شیء OLE](OLE_object_new_image.png)

### **راه‌حل 2: ایجاد افزودنی برای PowerPoint**

همچنین می‌توانید یک افزونه برای Microsoft PowerPoint ایجاد کنید که تمام اشیاء OLE را هنگام باز کردن ارائه‌ها در این برنامه به‌روزرسانی کند.