---
title: مدیریت OLE در ارائه‌ها با استفاده از Java
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/java/manage-ole/
keywords:
- شیء OLE
- پیوند و جاسازی اشیاء
- افزودن OLE
- جاسازی OLE
- افزودن شیء
- جاسازی شیء
- افزودن فایل
- جاسازی فایل
- شیء پیوندی
- فایل پیوندی
- تغییر OLE
- آیکن OLE
- عنوان OLE
- استخراج OLE
- استخراج شیء
- استخراج فایل
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "مدیریت اشیاء OLE را در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای Java بهینه کنید. محتویات OLE را به‌صورت یکپارچه جاسازی، به‌روزرسانی و استخراج کنید."
---
## **معرفی**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که امکان قرار دادن داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند، در برنامهٔ دیگری از طریق لینک یا جاسازی را فراهم می‌کند. 

{{% /alert %}} 

تصور کنید یک نمودار در MS Excel ساخته شود. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به عنوان یک شیء OLE در نظر گرفته می‌شود. 

- یک شیء OLE ممکن است به شکل یک نماد (آیکن) ظاهر شود. در این صورت، وقتی روی نماد دوبار کلیک می‌کنید، نمودار در برنامهٔ مرتبط (Excel) باز می‌شود یا از شما خواسته می‌شود برنامه‌ای برای باز کردن یا ویرایش شیء انتخاب کنید. 
- یک شیء OLE ممکن است محتویات واقعی خود را نمایش دهد، مانند محتویات یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگیری می‌شود و می‌توانید داده‌های نمودار را در داخل PowerPoint تغییر دهید.

[Aspose.Slides برای Java](https://products.aspose.com/slides/fa/java/) به شما امکان می‌دهد اشیاء OLE را به اسلایدها به صورت قاب‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleObjectFrame)) اضافه کنید.

## **افزودن قاب‌های شیء OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ساخته‌اید و می‌خواهید آن را به عنوان یک قاب شیء OLE در اسلایدی جاسازی کنید با استفاده از Aspose.Slides برای Java، می‌توانید به این روش عمل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق شاخص آن بدست آورید.  
1. فایل Excel را به صورت آرایه‌ای از بایت‌ها بخوانید.  
1. [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleObjectFrame) را به اسلاید اضافه کنید به‌همراه آرایهٔ بایت‌ها و سایر اطلاعات مربوط به شیء OLE.  
1. ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.  

در مثال زیر، ما یک نمودار از یک فایل Excel را به عنوان یک قاب شیء OLE به اسلاید اضافه کردیم با استفاده از Aspose.Slides برای Java.  
**توجه** داشته باشید که سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleEmbeddedDataInfo) یک پسوند شیء قابل جاسازی را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint امکان می‌دهد تا نوع فایل را به‌درستی تفسیر کرده و برنامهٔ مناسب برای باز کردن این شیء OLE را انتخاب کند.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **افزودن قاب‌های شیء OLE پیوندی**

Aspose.Slides برای Java به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleObjectFrame) بدون جاسازی داده اضافه کنید، فقط با یک لینک به فایل.

این کد Java نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleObjectFrame) با یک فایل Excel پیوندی به اسلاید اضافه کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// یک قاب شیء OLE با فایل Excel پیوندی اضافه کنید.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **دسترسی به قاب‌های شیء OLE**

اگر یک شیء OLE از پیش در اسلاید جاسازی شده باشد، می‌توانید به سادگی آن را این‌گونه پیدا یا دسترسی پیدا کنید:

1. یک ارائه حاوی شیء OLE جاسازی‌شده را با ایجاد یک نمونهٔ کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از شاخص آن بدست آورید.  
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleObjectFrame) دسترسی پیدا کنید.  
   در مثال ما، از PPTX که قبلاً ساخته شده و تنها یک شکل در اولین اسلاید دارد استفاده کردیم. سپس آن شیء را به‌عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IOleObjectFrame) *cast* کردیم. این همان قاب شیء OLE موردنظر برای دسترسی بود.  
4. پس از دسترسی به قاب شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  

در مثال زیر، یک قاب شیء OLE (یک شیء نمودار Excel جاسازی‌شده در اسلاید) و دادهٔ فایل مربوطه دسترسی پیدا می‌شوند.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // دریافت داده‌های فایل جاسازی‌شده.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // دریافت پسوند فایل جاسازی‌شده.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **دسترسی به ویژگی‌های قاب شیء OLE پیوندی**

Aspose.Slides به شما امکان می‌دهد به ویژگی‌های قاب شیء OLE پیوندی دسترسی پیدا کنید.

این کد Java نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE پیوندی است و سپس مسیر فایل پیوندی را دریافت کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // بررسی کنید که آیا شیء OLE پیوندی است.
    if (oleFrame.isObjectLink()) {
        // مسیر کامل فایل پیوندی را چاپ کنید.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // مسیر نسبی فایل پیوندی را در صورت وجود چاپ کنید.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را شامل شوند.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **تغییر دادهٔ شیء OLE**

{{% alert color="info" %}} 

در این بخش، مثال کد زیر از [Aspose.Cells برای Java](/cells/java/) استفاده می‌کند. 

{{% /alert %}}

اگر یک شیء OLE از پیش در اسلاید جاسازی شده باشد، می‌توانید به سادگی به آن شیء دسترسی پیدا کنید و داده‌های آن را این‌گونه تغییر دهید:

1. یک ارائه حاوی شیء OLE جاسازی‌شده را با ایجاد یک نمونهٔ کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را از طریق شاخص آن بدست آورید.  
3. به شکل قاب شیء OLE دسترسی پیدا کنید.  
   در مثال ما، از PPTX که قبلاً ساخته شده و یک شکل در اولین اسلاید دارد استفاده کردیم. سپس آن شیء را به‌عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IOleObjectFrame) *cast* کردیم. این همان قاب شیء OLE موردنظر برای دسترسی بود.  
4. پس از دسترسی به قاب شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  
5. یک شیء `Workbook` ایجاد کنید و به دادهٔ OLE دسترسی پیدا کنید.  
6. برگهٔ کاری (`Worksheet`) موردنظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.  
7. `Workbook` به‌روزشده را در یک جریان (stream) ذخیره کنید.  
8. دادهٔ شیء OLE را از جریان تغییر دهید.  

در مثال زیر، یک قاب شیء OLE (یک شیء نمودار Excel جاسازی‌شده در اسلاید) دسترسی پیدا می‌شود و دادهٔ فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شود.

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // داده‌های شیء OLE را به‌عنوان یک شیء Workbook بخوانید.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // داده‌های Workbook را اصلاح کنید.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // داده‌های شیء قاب OLE را تغییر دهید.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **جاسازی انواع دیگر فایل‌ها در اسلایدها**

علاوه بر نمودارهای Excel، Aspose.Slides برای Java به شما امکان می‌دهد انواع دیگر فایل‌ها را در اسلایدها جاسازی کنید. برای مثال، می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. زمانی که کاربر روی شیء واردشده دوبار کلیک می‌کند، به‌صورت خودکار در برنامهٔ مربوطه باز می‌شود یا از کاربر درخواست می‌شود برنامهٔ مناسبی برای باز کردن انتخاب کند.

این کد Java نشان می‌دهد چگونه HTML و ZIP را به یک اسلاید جاسازی کنید:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **تنظیم نوع فایل برای اشیاء جاسازی‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides برای Java به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده تنظیم کنید، به‌طوری که بتوانید دادهٔ قاب OLE یا پسوند آن را به‌روزرسانی کنید.

این کد Java نشان می‌دهد چگونه نوع فایل برای یک شیء OLE جاسازی‌شده به `zip` تنظیم کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **تنظیم تصاویر نماد و عناوین برای اشیاء جاسازی‌شده**

پس از جاسازی یک شیء OLE، پیش‌نمایشی شامل یک تصویر نماد به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر مایل باشید تصویر و متن خاصی را به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر نماد و عنوان را با استفاده از Aspose.Slides برای Java تنظیم کنید.

این کد Java نشان می‌دهد چگونه تصویر نماد و عنوان را برای یک شیء جاسازی‌شده تنظیم کنید:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// یک تصویر به منابع ارائه اضافه کنید.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **جلوگیری از تغییر اندازه و موقعیت قاب شیء OLE**

پس از افزودن یک شیء OLE پیوندی به اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید، ممکن است پیامی مبنی بر به‌روزرسانی لینک‌ها مشاهده کنید. کلیک بر دکمهٔ «Update Links» ممکن است باعث تغییر اندازه و موقعیت قاب شیء OLE شود زیرا PowerPoint داده‌ها را از شیء OLE پیوندی به‌روزرسانی می‌کند و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی دادهٔ شیء، متد `setUpdateAutomatic` از اینترفیس [IOleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ioleobjectframe/) را به `false` تنظیم کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides برای Java به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها به‌عنوان اشیاء OLE را به این‌صورت استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) که شامل اشیاء OLE موردنظر برای استخراج است، ایجاد کنید.  
2. در تمام شکل‌های موجود در ارائه حلقه بزنید و به شکل‌های [OLEObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/oleobjectframe) دسترسی پیدا کنید.  
3. دادهٔ فایل‌های جاسازی‌شده را از قاب‌های شیء OLE استخراج کرده و بر روی دیسک ذخیره کنید.  

این کد Java نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید به‌عنوان اشیاء OLE استخراج شوند:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **سوالات متداول**

### آیا محتوای OLE هنگام خروجی گرفتن اسلایدها به PDF/تصاویر رندر می‌شود؟

آنچه در اسلاید قابل مشاهده است رندر می‌شود — نماد/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE در زمان رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر مورد انتظار در PDF خروجی حفظ شود.

### چگونه می‌توان یک شیء OLE را در اسلاید قفل کرد تا کاربران نتوانند آن را در PowerPoint جابجا/ویرایش کنند؟

شکل را قفل کنید: Aspose.Slides قابلیت‌های [قفل‌های سطح شکل](/slides/fa/java/applying-protection-to-presentation/) را فراهم می‌کند. این قفل‌گذاری رمزگذاری نیست، اما به‌طور مؤثر از ویرایش و جابه‌جایی ناخواسته جلوگیری می‌کند.

### چرا یک شیء Excel پیوندی «پرش» می‌کند یا هنگام باز کردن ارائه اندازه‌اش تغییر می‌یابد؟

PowerPoint ممکن است پیش‌نمایش OLE پیوندی را تازه کند. برای داشتن ظاهری ثابت، راه‌حل [کارآمد برای تغییر اندازه شیت‌کاری](/slides/fa/java/working-solution-for-worksheet-resizing/) را دنبال کنید — یا قاب را به محدوده متناسب کنید، یا محدوده را به یک قاب ثابت مقیاس‌بندی کنید و تصویر جایگزین مناسب تنظیم کنید.

### آیا مسیرهای نسبی برای اشیاء OLE پیوندی در فرمت PPTX حفظ می‌شوند؟

در PPTX اطلاعات «مسیر نسبی» وجود ندارد — تنها مسیر کامل ذخیره می‌شود. مسیرهای نسبی در فرمت قدیمی PPT موجود است. برای قابلیت حمل، مسیرهای مطلق قابل اطمینان/URIهای دسترس‌پذیر یا جاسازی را ترجیح دهید.