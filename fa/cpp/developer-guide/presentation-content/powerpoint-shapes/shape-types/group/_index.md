---
title: اشکل گروهی ارائه در C++
linktitle: گروه شکل
type: docs
weight: 40
url: /fa/cpp/group/
keywords:
- شکل گروهی
- گروه شکل
- افزودن گروه
- متن جایگزین
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در مجموعه‌های PowerPoint با استفاده از Aspose.Slides برای C++ گروه‌بندی و جداسازی کنید — راهنمای سریع، گام‌به‌گام با کد رایگان C++."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با اشکال گروهی در Aspose.Slides کار کنید. نحوه افزودن یک شکل گروهی به اسلاید، قرار دادن اشکال داخل آن و ذخیره‌سازی ارائه به‌روز شده را نشان می‌دهد. همچنین چگونگی دسترسی به اشکال ذخیره‌شده در داخل یک گروه و خواندن مقادیر `AlternativeText` آن‌ها را نمایش می‌دهد. علاوه بر این، به‌طور مختصر به قابلیت‌های مرتبط با اشکال گروهی مانند گروه‌های تو در تو، ترتیب Z و گزینه‌های قفل‌گذاری می‌پردازد.

## **افزودن یک شکل گروهی**
Aspose.Slides از کار با اشکال گروهی در اسلایدها پشتیبانی می‌کند. این ویژگی به توسعه‌دهندگان امکان می‌دهد ارائه‌های غنی‌تری ایجاد کنند. Aspose.Slides for C++ امکان افزودن یا دسترسی به اشکال گروهی را فراهم می‌کند. می‌توانید اشکالی را به یک شکل گروهی اضافه‌شده اضافه کنید تا آن را پر کنید یا به هر ویژگی‌ای از شکل گروهی دسترسی پیدا کنید. برای افزودن یک شکل گروهی به اسلاید با استفاده از Aspose.Slides for C++:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را با استفاده از Index آن دریافت کنید.
1. یک شکل گروهی به اسلاید اضافه کنید.
1. اشکال را به شکل گروهی افزوده‌شده اضافه کنید.
1. ارائه ویرایش‌شده را به صورت فایل PPTX ذخیره کنید.

مثال زیر یک شکل گروهی را به اسلاید اضافه می‌کند.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **دسترسی به ویژگی AltText**
این بخش گام‌های ساده‌ای را همراه با مثال‌های کد برای افزودن یک شکل گروهی و دسترسی به ویژگی AltText اشکال گروهی در اسلایدها نشان می‌دهد. برای دسترسی به AltText یک شکل گروهی در اسلاید با استفاده از Aspose.Slides for C++:

1. کلاس `Presentation` را که نمایانگر یک فایل PPTX است، نمونه‌سازی کنید.
1. مرجع اسلاید را با استفاده از Index آن دریافت کنید.
1. به مجموعه اشکال اسلایدها دسترسی پیدا کنید.
1. به شکل گروهی دسترسی یابید.
1. به ویژگی AltText دسترسی پیدا کنید.

مثال زیر متن جایگزین یک شکل گروهی را می‌خواند.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **سؤالات متداول**

**آیا گروه‌بندی تو در تو (یک گروه داخل گروه) پشتیبانی می‌شود؟**

بله. [GroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/groupshape/) دارای متد [get_ParentGroup](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/get_parentgroup/) است که به‌طور مستقیم پشتیبانی از سلسله‌مراتب (یک گروه می‌تواند فرزند گروه دیگری باشد) را نشان می‌دهد.

**چگونه می‌توان ترتیب Z گروه را نسبت به سایر اشیاء روی اسلاید کنترل کرد؟**

از موقعیت [Z-Order](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/get_zorderposition/) مربوط به [GroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/groupshape/) استفاده کنید تا موقعیت آن را در پشته نمایش بررسی کنید.

**آیا می‌توان از جابه‌جایی/ویرایش/لغو گروه جلوگیری کرد؟**

بله. بخش قفل گروه از طریق متد [get_GroupShapeLock](https://reference.aspose.com/slides/fa/cpp/aspose.slides/groupshape/get_groupshapelock/) در دسترس است که به شما اجازه می‌دهد عملیات روی شیء را محدود کنید.