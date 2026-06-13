---
title: مشکل پیش‌نمایش شیء هنگام افزودن OleObjectFrame
linktitle: مشکل شیء OLE
type: docs
weight: 10
url: /fa/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشکل پیش‌نمایش
- شی توکار
- فایل توکار
- شی تغییر کرده
- پیش‌نمایش شیء
- ارائه
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "دلیل نمایش پیام EMBEDDED OLE OBJECT هنگام افزودن OleObjectFrame در Aspose.Slides برای .NET و روش رفع مشکلات پیش‌نمایش در ارائه‌های PPT، PPTX و ODP را بیاموزید."
---
## **مقدمه**

با استفاده از Aspose.Slides برای .NET، وقتی یک [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) را به یک اسلاید اضافه می‌کنید، پیام «EMBEDDED OLE OBJECT» بر روی اسلاید خروجی نشان داده می‌شود. این پیام عمدی است و بخشی از اشتباه نیست.

برای اطلاعات بیشتر در مورد کار با اشیای OLE، به صفحهٔ [مدیریت OLE](/slides/fa/net/manage-ole/) مراجعه کنید.

## **توضیح و راه‌حل**

Aspose.Slides پیام «EMBEDDED OLE OBJECT» را نمایش می‌دهد تا به شما اطلاع دهد که شی OLE تغییر کرده و تصویر پیش‌نمایش باید به‌روزرسانی شود.

به عنوان مثال، اگر یک نمودار مایکروسافت اکسل را به عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/oleobjectframe) به اسلاید اضافه کنید (برای جزئیات بیشتر، مقالهٔ «مدیریت OLE» را ببینید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را بر روی اسلاید خواهید دید:

![پیام شی OLE](OLE_object_message.png)

اگر می‌خواهید اطمینان حاصل کنید که شی OLE شما به اسلاید اضافه شده است، باید روی پیام «EMBEDDED OLE OBJECT» دو بار کلیک کنید، یا می‌توانید روی آن کلیک راست کنید و گزینه **Object > Edit** را انتخاب کنید.

![شی OLE > Edit](OLE_object_edit.png)

PowerPoint سپس شی OLE توکار را باز می‌کند.

![داده‌های شی OLE](OLE_object_data.png)

ممکن است اسلاید همچنان پیام «EMBEDDED OLE OBJECT» را نگه دارد. هنگامی که روی شی OLE کلیک کنید، پیش‌نمایش اسلاید به‌روزرسانی می‌شود و پیام «EMBEDDED OLE OBJECT» با تصویر واقعی شی OLE جایگزین می‌شود.

![پیش‌نمایش شی OLE](OLE_object_preview.png)

حال ممکن است بخواهید ارائه خود را ذخیره کنید تا تصویر شی OLE به‌درستی به‌روزرسانی شود. به این ترتیب، پس از ذخیرهٔ ارائه، وقتی دوباره آن را باز می‌کنید، پیام «EMBEDDED OLE OBJECT» نمایش داده نمی‌شود.

## **راه‌حل‌های دیگر**

### **راه‌حل 1: جایگزینی پیام «Embedded OLE Object» با یک تصویر**

اگر نمی‌خواهید پیام «EMBEDDED OLE OBJECT» را با باز کردن ارائه در PowerPoint و سپس ذخیرهٔ آن حذف کنید، می‌توانید پیام را با تصویر پیش‌نمایش دلخواه خود جایگزین کنید. این خطوط کد فرایند را نشان می‌دهند:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

اسلاید حاوی `OleObjectFrame` سپس به این شکل تغییر می‌کند:

![تصویر جدید شی OLE](OLE_object_new_image.png)

### **راه‌حل 2: ایجاد یک افزونه برای PowerPoint**

همچنین می‌توانید یک افزونه برای Microsoft PowerPoint ایجاد کنید که تمام اشیای OLE را هنگام باز کردن ارائه‌ها در برنامه به‌روزرسانی کند.