---
title: تبدیل ارائه‌های PowerPoint به XML در C++
linktitle: PowerPoint به XML
type: docs
weight: 145
url: /fa/cpp/convert-powerpoint-to-xml/
keywords:
- تبدیل PowerPoint به XML
- تبدیل ارائه به XML
- PPT به XML
- PPTX به XML
- ODP به XML
- ارائه PowerPoint XML
- SaveFormat::Xml
- ذخیره ارائه به عنوان XML
- صادرات ارائه به XML
- جریان XML
- C++
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به فایل‌ها یا جریان‌های PowerPoint XML در C++ با Aspose.Slides برای C++."
---
## **بررسی کلی**

Aspose.Slides برای C++ می‌تواند ارائه‌های PowerPoint را به فرمت PowerPoint XML Presentation تبدیل کند. خروجی XML هنگامی مفید است که به یک نمایشی مبتنی بر متن برای بررسی ساختار ارائه، عیب‌یابی اسناد تولید شده، مقایسه خروجی در تست‌های خودکار یا یکپارچه‌سازی با روند کاری که XML را به جای بسته ارائه مصرف می‌کند، نیاز داشته باشید.

از متد [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) با مقدار `Xml` از enumeration [SaveFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) استفاده کنید. می‌توانید نتیجه را مستقیماً در یک فایل یا به یک جریان بنویسید.

{{% alert color="info" title="نکته" %}}
`SaveFormat::Xml` یک PowerPoint XML Presentation ایجاد می‌کند. این کار بخش‌های فردی Office Open XML ذخیره‌شده در بسته PPTX را استخراج نمی‌کند. اگر به بخش‌های دقیق بسته PPTX مثل `ppt/presentation.xml` یا فایل‌های XML اسلایدهای جداگانه نیاز دارید، بسته PPTX را مستقیماً بررسی کنید.
{{% /alert %}}

## **تبدیل یک ارائه به فایل XML**

یک ارائه منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری کنید، سپس مسیر خروجی و `SaveFormat::Xml` را به [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) پاس بدهید. منبع می‌تواند هر فرمت ارائه‌ای باشد که برای بارگذاری پشتیبانی می‌شود، مانند PPT، PPTX یا ODP.

مثال زیر یک ارائه PPTX را به فایل XML تبدیل می‌کند:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **نوشتن خروجی XML به یک جریان**

از overload جریان متد [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) استفاده کنید زمانی که XML باید در حافظه بماند یا به مؤلفه دیگری مانند سرویس وب، ارائه‌دهنده ذخیره‌سازی یا خط لوله پردازش XML منتقل شود. مثال زیر نتیجه را به یک [MemoryStream](https://reference.aspose.com/slides/fa/cpp/system.io/memorystream/) می‌نویسد و برای خواندن‌های بعدی دوباره به ابتدای آن می‌برد:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// ارسال xmlStream به مؤلفه بعدی در جریان کار.
```

## **مقایسه XML با فرمت‌های ارائه و خروجی**

فرمت خروجی را بر اساس نحوه استفاده از نتیجه انتخاب کنید:

| فرمت | خروجی | استفاده معمول |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | یک ارائه PowerPoint XML | بررسی ساختار، عیب‌یابی، مقایسه خروجی تولید شده، و یکپارچه‌سازی مبتنی بر XML |
| PPT (`.ppt`) | یک فایل ارائه باینری قدیمی | سازگاری با جریان‌های کاری PowerPoint قدیمی |
| PPTX (`.pptx`) | یک بسته Office Open XML شامل چندین بخش | ویرایش معمولی PowerPoint و تبادل ارائه |
| PDF یا TIFF | صفحات با طرح ثابت یا یک تصویر چندصفحه | مشاهده، چاپ و بایگانی |
| PNG، JPEG یا SVG | نمایش رندر شده یک اسلاید منفرد | تصاویر کوچک، پیش‌نمایش‌ها و دارایی‌های تصویری |
| HTML یا HTML5 | خروجی ارائه جهت وب | مشاهده در مرورگر و انتشار وب |

بر خلاف PPT و PPTX، خروجی XML عمدتاً برای بازرسی و جریان‌های کاری مبتنی بر داده هدف‌گذاری شده است. بر خلاف PDF، TIFF، HTML و فرمت‌های تصویر اسلاید، این خروجی داده‌های ارائه را نشان می‌دهد نه رندر اسلایدها به عنوان صفحات یا دارایی‌های تصویری.

جدول [فرمت‌های فایل پشتیبانی‌شده](/slides/fa/cpp/supported-file-formats/) PowerPoint XML Presentation را به عنوان فرمت فقط ذخیره‌شده فهرست می‌کند، بنابراین وقتی یک جریان کاری نیاز به بارگذاری مجدد فایل صادر شده در Aspose.Slides برای ویرایش ادامه دارد، از آن استفاده نکنید.

## **سوالات متداول**

**آیا `SaveFormat::Xml` معادل ذخیره یک فایل PPTX است؟**  
خیر. PPTX یک بسته است که شامل چندین بخش Office Open XML می‌باشد، در حالی که `SaveFormat::Xml` یک فایل PowerPoint XML Presentation ایجاد می‌کند.

**آیا می‌توانم خروجی XML را بدون ایجاد فایل بر روی دیسک ذخیره کنم؟**  
بله. یک جریان قابل نوشتن را به [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) پاس دهید. برای مثال، برای پردازش در حافظه می‌توانید از یک [MemoryStream](https://reference.aspose.com/slides/fa/cpp/system.io/memorystream/) استفاده کنید.

**آیا Aspose.Slides می‌تواند فایل XML صادر شده را دوباره بارگذاری کند؟**  
خیر. PowerPoint XML Presentation در حال حاضر فقط برای ذخیره پشتیبانی می‌شود و برای بارگذاری پشتیبانی نمی‌شود. هنگامی که ویرایش دوطرفه لازم است، از PPTX یا فرمت ارائه پشتیبانی‌شده دیگری استفاده کنید.

**آیا تبدیل XML هر اسلاید را به یک صفحه یا تصویر رندر می‌کند؟**  
خیر. تبدیل XML داده‌های ساختار شده ارائه را می‌نویسد. برای خروجی صفحه‌محور از PDF یا TIFF استفاده کنید، یا برای تصاویر اسلایدهای منفرد از PNG، JPEG و SVG استفاده نمایید.