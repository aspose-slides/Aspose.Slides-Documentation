---
title: راه حل عملی برای تغییر اندازه نمودار در PPTX
type: docs
weight: 40
url: /fa/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغییر اندازه نمودار
- نمودار Excel
- شیء OLE
- جاسازی نمودار
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "رفع تغییر اندازه ناخواسته نمودار در PPTX هنگام استفاده از اشیای Excel OLE جاسازی‌شده با Aspose.Slides برای Java. دو روش همراه با کد برای حفظ سازگاری اندازه‌ها را بیاموزید."
---
## **پس‌زمینه**

مشاهده شده است که نمودارهای Excel که به‌عنوان شیء OLE در ارائه PowerPoint از طریق مؤلفه‌های Aspose جایگذاری می‌شوند، پس از اولین فعال‌سازی به مقیاسی نامشخص تغییر اندازه می‌دهند. این رفتار باعث تفاوت بصری قابل‌توجهی بین حالت‌های قبل و بعد از فعال‌سازی نمودار در ارائه می‌شود. تیم Aspose این مسئله را به‌طور دقیق بررسی کرده و راه‌حلی یافته است. این مقاله علل مشکل و اصلاح مربوطه را شرح می‌دهد.

در [مقاله قبلی](/slides/fa/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) توضیح دادیم چگونه یک نمودار Excel با Aspose.Cells for Java ایجاد و آن را به عنوان شیء OLE در ارائه PowerPoint با Aspose.Slides for Java جایگذاری کنیم. برای رفع [مشکل پیش‌نمایش شی](/slides/fa/java/object-preview-issue-when-adding-oleobjectframe/) تصویر نمودار را به قاب شیء OLE اختصاص دادیم. در ارائه خروجی، زمانی که بر روی قاب شیء OLE که تصویر نمودار را نشان می‌دهد دوبار کلیک می‌کنید، نمودار Excel فعال می‌شود. کاربران می‌توانند تغییرات دلخواه را در کتاب‌کار Excel زیرین انجام دهند و سپس با کلیک خارج از کتاب‌کار فعال شده به اسلاید مربوطه بازگردند. اندازه قاب شیء OLE هنگام بازگشت کاربر به اسلاید تغییر می‌کند و عامل تغییر اندازه بسته به اندازه اولیهٔ هر دو قاب شیء OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

از آنجا که کتاب‌کار Excel دارای اندازهٔ پنجرهٔ خود است، در اولین فعال‌سازی سعی می‌کند اندازهٔ اصلی خود را حفظ کند. اما قاب شیء OLE نیز اندازهٔ خاص خود را دارد. بر اساس مطالعات مایکروسافت، زمانی که کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint دربارهٔ اندازه مذاکره می‌کنند و نسبت‌ها را به‌درستی حفظ می‌نمایند؛ در نتیجه بسته به تفاوت بین اندازهٔ پنجرهٔ Excel و اندازه یا موقعیت قاب شیء OLE، تغییر اندازه رخ می‌دهد.

## **راه‌حل عملی**

دو سناریو برای ایجاد ارائه‌های PowerPoint با Aspose.Slides for Java وجود دارد.

**سناریو 1:** ایجاد ارائه بر پایه یک الگوی موجود.

**سناریو ۲:** ایجاد ارائه از صفر.

راه‌حلی که در اینجا ارائه می‌دهیم به هر دو سناریو اعمال می‌شود. اصل تمام روش‌های راه‌حل یکسان است: **اندازهٔ پنجرهٔ شیء OLE جاسازی‌شده باید با اندازهٔ قاب شیء OLE در اسلاید PowerPoint مطابقت داشته باشد**. در ادامه دو روش برای این راه‌حل را بررسی می‌کنیم.

## **رویکرد اول**

در این روش، می‌آموزیم چگونه اندازهٔ پنجرهٔ کتاب‌کار Excel جاسازی‌شده را تنظیم کنیم تا با اندازهٔ قاب شیء OLE در اسلاید PowerPoint مطابقت داشته باشد.

**سناریو 1**

فرض کنید یک الگو تعریف کرده‌ایم و می‌خواهیم ارائه‌ها را بر پایهٔ آن ایجاد کنیم. در الگو یک شکل در شاخص 2 وجود دارد که می‌خواهیم یک قاب OLE حاوی کتاب‌کار Excel جاسازی‌شده در آن قرار دهیم. در این سناریو، اندازهٔ قاب شیء OLE از پیش تعریف شده است—با اندازهٔ شکل در شاخص 2 در الگو برابر است. تنها کاری که باید انجام دهیم این است که اندازهٔ پنجرهٔ کتاب‌کار را برابر با اندازهٔ آن شکل تنظیم کنیم. قطعه کد زیر این هدف را برآورده می‌کند:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// عرض پنجرهٔ کتاب‌کار را به اینچ تنظیم کنید (تقسیم بر ۷۲ چون PowerPoint هر اینچ را ۷۲ نقطه در نظر می‌گیرد).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// ارتفاع پنجرهٔ کتاب‌کار را به اینچ تنظیم کنید.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// کتاب‌کار را در یک جریان حافظه (memory stream) ذخیره کنید.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// یک قاب شیء OLE با دادهٔ Excel جاسازی‌شده ایجاد کنید.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**سناریو ۲**

فرض کنید می‌خواهیم یک ارائه از صفر ایجاد کنیم و یک قاب شیء OLE با هر اندازه‌ای که داشته باشد شامل کتاب‌کار Excel جاسازی‌شده اضافه کنیم. در قطعه کد زیر یک قاب OLE به ارتفاع 4 اینچ و عرض 9.5 اینچ در مختصات x = 0.5 اینچ و y = 1 اینچ بر روی اسلاید ایجاد می‌کنیم. سپس پنجرهٔ کتاب‌کار Excel را به همان اندازه—ارتفاع 4 اینچ و عرض 9.5 اینچ—تنظیم می‌کنیم.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// ارتفاع مطلوب ما.
int desiredHeight = 288; // 4 اینچ (4 * 72)
 
// عرض مطلوب ما.
int desiredWidth = 684; // 9.5 اینچ (9.5 * 72)
 
// اندازهٔ نمودار را با یک پنجره تعریف کنید.
chart.setSizeWithWindow(true);
 
// عرض پنجرهٔ کتاب‌کار را به اینچ تنظیم کنید (تقسیم بر ۷۲ چون PowerPoint هر اینچ را ۷۲ نقطه در نظر می‌گیرد).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// ارتفاع پنجرهٔ کتاب‌کار را به اینچ تنظیم کنید.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// کتاب‌کار را در یک جریان حافظه ذخیره کنید.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// یک قاب شیء OLE با دادهٔ Excel جاسازی‌شده ایجاد کنید.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 اینچ (0.5 * 72)
    72,  // y = 1 اینچ (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **رویکرد دوم**

در این روش، می‌آموزیم چگونه اندازهٔ نمودار موجود در کتاب‌کار Excel جاسازی‌شده را تنظیم کنیم تا با اندازهٔ قاب شیء OLE در اسلاید PowerPoint مطابقت داشته باشد. این روش زمانی مفید است که اندازهٔ نمودار از پیش شناخته شده باشد و هرگز تغییر نکند.

**سناریو 1**

فرض کنید یک الگو تعریف کرده‌ایم و می‌خواهیم ارائه‌ها را بر پایهٔ آن ایجاد کنیم. در الگو یک شکل در شاخص 2 وجود دارد که قصد داریم یک قاب OLE حاوی کتاب‌کار Excel جاسازی‌شده در آن قرار دهیم. در این سناریو، اندازهٔ قاب OLE از پیش تعریف شده است—با اندازهٔ شکل در شاخص 2 در الگو برابر است. تنها کاری که باید انجام دهیم این است که اندازهٔ نمودار را در کتاب‌کار برابر با اندازهٔ آن شکل تنظیم کنیم. قطعه کد زیر این هدف را برآورده می‌کند:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// اندازهٔ نمودار را بدون پنجره تعریف کنید.
chart.setSizeWithWindow(false);
 
// عرض نمودار را بر حسب پیکسل تنظیم کنید (ضرب در ۹۶ چون Excel هر اینچ را ۹۶ پیکسل در نظر می‌گیرد).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// ارتفاع نمودار را بر حسب پیکسل تنظیم کنید.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// اندازهٔ چاپ نمودار را تعریف کنید.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// کتاب‌کار را در یک جریان حافظه ذخیره کنید.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// یک قاب شیء OLE با دادهٔ Excel جاسازی‌شده ایجاد کنید.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**سناریو ۲**:

فرض کنید می‌خواهیم یک ارائه از صفر ایجاد کنیم و یک قاب شیء OLE با هر اندازه‌ای شامل کتاب‌کار Excel جاسازی‌شده اضافه کنیم. در قطعه کد زیر یک قاب OLE با ارتفاع 4 اینچ و عرض 9.5 اینچ بر روی اسلاید در مختصات x = 0.5 اینچ و y = 1 اینچ ایجاد می‌کنیم. همچنین اندازهٔ نمودار متناظر را به همان ابعاد تنظیم می‌کنیم: ارتفاع 4 اینچ و عرض 9.5 اینچ.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// ارتفاع مورد نظر ما.
int desiredHeight = 288; // 4 اینچ (4 * 72)
 
// عرض مورد نظر ما.
int desiredWidth = 684; // 9.5 اینچ (9.5 * 72)
 
// اندازهٔ نمودار را بدون پنجره تعریف کنید.
chart.setSizeWithWindow(false);
 
// عرض نمودار را بر حسب پیکسل تنظیم کنید (تقسیم بر ۷۲ برای به دست آوردن اینچ، سپس ضرب در ۹۶ چون Excel هر اینچ را ۹۶ پیکسل می‌پندارد).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// ارتفاع نمودار را بر حسب پیکسل تنظیم کنید.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// کتاب‌کار را در یک جریان حافظه ذخیره کنید.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// یک قاب شیء OLE با دادهٔ Excel جاسازی‌شده ایجاد کنید.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 اینچ (0.5 * 72)
    72,  // y = 1 اینچ (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **نتیجه‌گیری**

دو روش برای رفع مشکل تغییر اندازهٔ نمودار وجود دارد. انتخاب روش بستگی به نیازها و مورد استفاده دارد. هر دو روش به‌صورت یکسان برای ارائه‌های پایه‌گذاری شده بر الگو یا ایجاد شده از صفر کار می‌کنند. همچنین در این راه‌حل هیچ محدودیتی برای اندازهٔ قاب OLE وجود ندارد.

## **پرسش‌های متداول**

### چرا پس از فعال‌سازی نمودار Excel جاسازی‌شده در PowerPoint اندازهٔ آن تغییر می‌کند؟

این به این دلیل است که Excel سعی می‌کند اندازهٔ پنجرهٔ اصلی خود را هنگام اولین فعال‌سازی بازیابی کند، در حالی که قاب شیء OLE در PowerPoint ابعاد خاص خود را دارد. PowerPoint و Excel برای حفظ نسبت عرض به ارتفاع مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

### آیا می‌توان این مشکل تغییر اندازه را کاملاً جلوگیری کرد؟

بله. با تنظیم اندازهٔ پنجرهٔ کتاب‌کار Excel یا اندازهٔ نمودار برابر با اندازهٔ قاب شیء OLE قبل از جاسازی، می‌توانید اندازه‌های نمودار را ثابت نگه دارید.

### کدام روش را باید انتخاب کنم، تنظیم اندازهٔ پنجرهٔ کتاب‌کار یا تنظیم اندازهٔ نمودار؟

از **رویکرد 1 (اندازهٔ پنجره)** استفاده کنید اگر می‌خواهید نسبت ابعاد کتاب‌کار حفظ شود و امکان تغییر اندازه بعدی وجود داشته باشد.  
از **رویکرد 2 (اندازهٔ نمودار)** استفاده کنید اگر ابعاد نمودار ثابت هستند و پس از جاسازی تغییر نخواهند کرد.

### آیا این روش‌ها برای هر دو نوع ارائه (بر پایه الگو و از صفر) کار می‌کنند؟

بله. هر دو روش برای ارائه‌های ایجاد شده بر پایه الگو و همچنین ارائه‌های ساخته‌شده از صفر به‌یک‌سان عمل می‌کنند.

### آیا محدودیتی برای اندازهٔ قاب شیء OLE وجود دارد؟

خیر. می‌توانید قاب OLE را به هر اندازه‌ای تنظیم کنید به شرط آنکه به‌صورت مناسب به اندازهٔ کتاب‌کار یا نمودار مقیاس‌بندی شود.

### آیا می‌توان این روش‌ها را با نمودارهای ایجاد‌شده در برنامه‌های صفحه‌گستردهٔ دیگر استفاده کرد؟

مثال‌ها برای نمودارهای Excel ساخته‌شده با Aspose.Cells طراحی شده‌اند، اما اصول برای برنامه‌های صفحه‌گستردهٔ سازگار با OLE دیگر نیز اعمال می‌شود، مشروط بر اینکه گزینه‌های مشابهی برای تنظیم اندازه در اختیار داشته باشند.

## **بخش‌های مرتبط**

- [ایجاد نمودارهای Excel و جاسازی آن‌ها به‌عنوان شیء OLE در ارائه‌ها](/slides/fa/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)