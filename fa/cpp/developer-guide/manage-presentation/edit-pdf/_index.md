---
title: ویرایش اسناد PDF در C++
linktitle: ویرایش PDF
type: docs
weight: 65
url: /fa/cpp/edit-pdf/
keywords:
- ویرایش PDF
- جایگزینی متن PDF
- PDF به PPTX
- PPTX به PDF
- C++
- Aspose.Slides
description: "اسناد PDF را در C++ با وارد کردن آن‌ها به Aspose.Slides، جایگزینی متن و ذخیرهٔ ارائهٔ اصلاح‌شده به‌صورت PDF ویرایش کنید."
---
## **نمای کلی**

Aspose.Slides برای C++ به شما امکان ویرایش محتوای PDF را با وارد کردن صفحات به صورت اسلاید، اصلاح ارائه و صادر کردن مجدد به PDF می‌دهد. این مقاله یک جایگزینی ساده متن را نشان می‌دهد. ارائه در حافظه باقی می‌ماند، بنابراین ذخیره‌کردن فایل PPTX میانی اختیاری است.

## **جایگزینی متن در PDF**

از [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slidecollection/addfrompdf/) برای وارد کردن صفحات، [Presentation::ReplaceText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/replacetext/) برای به‌روزرسانی متن و [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) برای صادر کردن نتیجه استفاده کنید.

مثال زیر انتظار دارد که `input.pdf` پس از وارد شدن شامل کلمه «Draft» به صورت متن قابل ویرایش باشد. این مثال آن کلمه را با «Final» جایگزین می‌کند و `edited.pdf` را می‌نویسد. پاک‌سازی اسلاید اولیه قبل از وارد کردن از ایجاد یک صفحهٔ خالی اضافی در خروجی جلوگیری می‌کند. جستجو با کلمات کامل و با همان حالت حرف مطابقت دارد؛ `nullptr` به این معنی است که نیازی به کال‌بک نتیجه نیست.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

برای گزینه‌های بیشتر، به [جستجو و جایگزینی متن](/slides/fa/cpp/search-and-replace-text/) و [تبدیل پاورپوینت به PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/) مراجعه کنید.

{{% alert color="info" title="Note" %}}
جایگزینی متن بر روی متن وارد شده کار می‌کند، نه متن داخل تصاویر اسکن‌شده. تبدیل ممکن است برچیدمان و قالب‌بندی تأثیر بگذارد، بنابراین خروجی را بررسی کنید، به‌ویژه وقتی که متن جایگزین طولانی‌تر از متن اصلی باشد.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا نیاز به ذخیره‌کردن فایل PPTX قبل از صادر کردن PDF دارم؟**

خیر. می‌توانید همان ارائه را در حافظه ویرایش و صادر کنید. فقط در صورتی که بخواهید ادامهٔ ویرایش را در پاورپوینت انجام دهید، یک نسخهٔ PPTX ذخیره کنید؛ به [Save Presentations](/slides/fa/cpp/save-presentation/) مراجعه کنید.

**چرا ممکن است برخی متن‌ها بدون تغییر بمانند؟**

این مثال کلمهٔ کامل «Draft» را با حروف دقیق مطابقت می‌دهد. متنی که به صورت تصویر وارد شده یا در چند فریم متن جداگانه تقسیم شده است لزوماً با جستجو مطابقت نخواهد کرد. محتوای وارد شده را بررسی کنید و جستجو را برای سند خود تنظیم کنید.