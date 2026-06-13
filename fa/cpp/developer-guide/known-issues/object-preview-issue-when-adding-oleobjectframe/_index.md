---
title: مشکل پیش‌نمایش شی هنگام افزودن OleObjectFrame
linktitle: مشکل شی OLE
type: docs
weight: 10
url: /fa/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- مشکل پیش‌نمایش
- شی توکار
- فایل توکار
- شی تغییر یافته
- پیش‌نمایش شی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "دلیل ظهور پیام EMBEDDED OLE OBJECT هنگام افزودن OleObjectFrame در Aspose.Slides برای C++ و نحوه رفع مشکلات پیش‌نمایش در ارائه‌های PPT، PPTX و ODP را بیاموزید."
---
## **مقدمه**

با استفاده از Aspose.Slides برای C++، هنگامی که یک [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) را به اسلاید اضافه می‌کنید، پیام «EMBEDDED OLE OBJECT» بر روی اسلاید خروجی نمایش داده می‌شود. این پیام عمدی بوده و خطا (bug) نیست.

برای اطلاعات بیشتر درباره کار با اشیای OLE، به بخش [مدیریت OLE](/slides/fa/cpp/manage-ole/) مراجعه کنید.

## **توضیح و راه حل**

Aspose.Slides پیام «EMBEDDED OLE OBJECT» را نمایش می‌دهد تا به شما اطلاع دهد که شی OLE تغییر کرده و تصویر پیش‌نمایش باید به‌روز شود.

به‌عنوان مثال، اگر یک نمودار Microsoft Excel را به عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) به اسلاید اضافه کنید (برای جزئیات بیشتر، مقاله «مدیریت OLE» را ببینید) و سپس ارائه را در Microsoft PowerPoint باز کنید، این تصویر را بر روی اسلاید خواهید دید:

![پیام شی OLE](OLE_object_message.png)

اگر می‌خواهید صحت افزودن شی OLE به اسلاید را بررسی و تأیید کنید، باید روی پیام «EMBEDDED OLE OBJECT» دو بار کلیک کنید، یا می‌توانید روی آن کلیک راست کنید و گزینه **Object > Edit** را انتخاب کنید.

![شی OLE > ویرایش](OLE_object_edit.png)

PowerPoint سپس شی OLE توکار را باز می‌کند.

![داده‌های شی OLE](OLE_object_data.png)

اسلاید ممکن است پیام «EMBEDDED OLE OBJECT» را حفظ کند. وقتی بر روی شی OLE کلیک کنید، پیش‌نمایش اسلاید به‌روز می‌شود و پیام «EMBEDDED OLE OBJECT» با تصویر واقعی شی OLE جایگزین می‌شود.

![پیش‌نمایش شی OLE](OLE_object_preview.png)

اکنون ممکن است بخواهید ارائه خود را ذخیره کنید تا تصویر شی OLE به درستی به‌روز شود. به این ترتیب، پس از ذخیرهٔ ارائه و باز کردن مجدد آن، دیگر پیام «EMBEDDED OLE OBJECT» را مشاهده نخواهید کرد.

## **راه حل‌های دیگر**

### **راه حل 1: جایگزینی پیام «Embedded OLE Object» با یک تصویر**

اگر نمی‌خواهید با باز کردن ارائه در PowerPoint و سپس ذخیره آن، پیام «EMBEDDED OLE OBJECT» را حذف کنید، می‌توانید این پیام را با تصویر پیش‌نمایش دلخواه خود جایگزین کنید. خطوط کد زیر این فرآیند را نشان می‌دهند:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

اسلاید حاوی `OleObjectFrame` به این صورت تغییر می‌کند:

![تصویر جدید شی OLE](OLE_object_new_image.png)

### **راه حل 2: ایجاد یک افزونه برای PowerPoint**

همچنین می‌توانید یک افزونه برای Microsoft PowerPoint ایجاد کنید که هنگام باز کردن ارائه‌ها در برنامه، تمام اشیای OLE را به‌روز کند.