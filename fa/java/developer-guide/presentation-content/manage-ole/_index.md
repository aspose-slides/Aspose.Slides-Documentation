---
title: مدیریت OLE در ارائه‌ها با استفاده از Java
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/java/manage-ole/
keywords:
- شیء OLE
- پیوند و تعبیهٔ شیء
- افزودن OLE
- تعبیه OLE
- افزودن شیء
- تعبیه شیء
- افزودن فایل
- تعبیه فایل
- شیء لینک‌دار
- فایل لینک‌دار
- تغییر OLE
- نماد OLE
- عنوان OLE
- استخراج OLE
- استخراج شیء
- استخراج فایل
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "بهینه‌سازی مدیریت اشیای OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای Java. تعبیه، به‌روزرسانی و استخراج محتوای OLE را به‌صورت یکپارچه انجام دهید."
---
## **مقدمه**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که اجازه می‌دهد داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند، از طریق لینک یا تعبیه در برنامه دیگری قرار گیرند. 

{{% /alert %}} 

یک نمودار ایجاد شده در MS Excel را در نظر بگیرید. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به عنوان یک شیء OLE در نظر گرفته می‌شود. 

- یک شیء OLE می‌تواند به صورت یک نماد ظاهر شود. در این صورت، وقتی روی نماد دوبار کلیک می‌کنید، نمودار در برنامه مرتبط خود (Excel) باز می‌شود یا از شما خواسته می‌شود برنامه‌ای را برای باز یا ویرایش شیء انتخاب کنید.
- یک شیء OLE می‌تواند محتوای واقعی خود را نشان دهد، مانند محتوای یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های آن را درون PowerPoint اصلاح کنید.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) امکان درج اشیاء OLE را به صورت فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)) در اسلایدها فراهم می‌کند.

## **اضافه کردن فریم‌های شیء OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به صورت فریم شیء OLE در اسلایدی تعبیه کنید با استفاده از Aspose.Slides for Java. می‌توانید به این شکل انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) بسازید.  
1. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
1. فایل Excel را به‌صورت آرایه بایت بخوانید.  
1. فریم [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) را به اسلاید اضافه کنید به همراه آرایه بایت و سایر اطلاعات مربوط به شیء OLE.  
1. ارائه‌ی اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

در مثال زیر، ما یک نمودار از فایل Excel را به عنوان فریم شیء OLE به اسلاید اضافه کرده‌ایم با استفاده از Aspose.Slides for Java.  
**Note** اینکه سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) یک پسوند شیء قابل تعبیه را به‌عنوان پارامتر دوم می‌پذیرد. این پسوند به PowerPoint اجازه می‌دهد نوع فایل را به‌درستی تفسیر کند و برنامه مناسب برای باز کردن این شیء OLE را انتخاب کند.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// آماده‌سازی داده‌ها برای شیء OLE.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// افزودن فریم شیء OLE به اسلاید.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **اضافه کردن فریم‌های شیء OLE لینک‌دار**

Aspose.Slides for Java به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) را بدون تعبیهٔ داده، فقط با لینک به فایل اضافه کنید.

این کد Java نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) با فایل Excel لینک‌دار به یک اسلاید اضافه کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// افزودن فریم شیء OLE با یک فایل Excel لینک‌دار.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE از پیش در یک اسلاید تعبیه شده باشد، می‌توانید به سادگی به آن دسترسی پیدا کنید:

1. ارائه‌ای که شامل شیء OLE تعبیه شده است را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از اندیس آن دریافت کنید.  
3. شکل [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) را دسترسی پیدا کنید.  
   در مثال ما، PPTX ساخته‌شده قبلی که فقط یک شکل در اولین اسلاید دارد، استفاده شد. سپس آن شیء را به‌عنوان [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) *cast* کردیم. این همان فریم شیء OLE موردنظر برای دسترسی بود.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel تعبیه‌شده در اسلاید) و داده‌های فایل آن دسترسی پیدا می‌شوند.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // دریافت داده‌های فایل تعبیه‌شده.
    // دریافت پسوند فایل تعبیه‌شده.
    // ...
}
```

### **دسترسی به ویژگی‌های فریم شیء OLE لینک‌دار**

Aspose.Slides به شما امکان دسترسی به ویژگی‌های فریم شیء OLE لینک‌دار را می‌دهد.

این کد Java نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE لینک‌دار است و سپس مسیر فایل لینک‌دار را دریافت کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // بررسی اینکه آیا شیء OLE لینک‌دار است.
    if (oleFrame.isObjectLink()) {
        // چاپ مسیر کامل فایل لینک‌دار.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // چاپ مسیر نسبی فایل لینک‌دار در صورت وجود.
        // تنها ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **تغییر داده‌های شیء OLE**

{{% alert color="info" title="Note" %}}

در این بخش، مثال کد زیر از [Aspose.Cells for Java](https://docs.aspose.com/cells/java/) استفاده می‌کند.

{{% /alert %}}

اگر یک شیء OLE از پیش در اسلاید تعبیه شده باشد، می‌توانید به راحتی به آن شیء دسترسی پیدا کنید و داده‌های آن را به این شکل تغییر دهید:

1. ارائه‌ای که شامل شیء OLE تعبیه شده است را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. شکل فریم شیء OLE را دسترسی پیدا کنید.  
   در مثال ما، PPTX ساخته‌شده قبلی که یک شکل در اولین اسلاید دارد استفاده شد. سپس آن شیء را به‌عنوان [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) *cast* کردیم. این همان فریم شیء OLE موردنظر برای دسترسی بود.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  
5. یک شیء `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.  
6. `Worksheet` موردنظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.  
7. `Workbook` به‌روزشده را در یک استریم ذخیره کنید.  
8. داده‌های شیء OLE را از استریم تغییر دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel تعبیه‌شده در اسلاید) دسترسی پیدا می‌شود و داده‌های فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شود.

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

    // داده‌های شیء OLE را به عنوان یک شیء Workbook بخوانید.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // داده‌های workbook را اصلاح کنید.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // داده‌های شیء فریم OLE را تغییر دهید.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **تعبیهٔ انواع فایل دیگر در اسلایدها**

به‌جز نمودارهای Excel، Aspose.Slides for Java به شما امکان تعبیهٔ انواع دیگر فایل‌ها در اسلایدها را می‌دهد. به‌عنوان مثال می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. هنگامی که کاربر روی شیء وارد‌شده دوبار کلیک می‌کند، به‌صورت خودکار در برنامه مربوطه باز می‌شود یا از او خواسته می‌شود برنامهٔ مناسبی برای باز کردن آن انتخاب کند.

این کد Java نشان می‌دهد چگونه HTML و ZIP را در یک اسلاید تعبیه کنید:

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

## **تنظیم نوع فایل برای اشیاء تعبیه‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides for Java به شما امکان تنظیم نوع فایل برای یک شیء تعبیه‌شده را می‌دهد تا بتوانید داده‌های فریم OLE یا پسوند آن را به‌روزرسانی کنید.

این کد Java نشان می‌دهد چگونه نوع فایل برای یک شیء OLE تعبیه‌شده به `zip` تنظیم شود:

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

## **تنظیم تصویر نماد و عنوان برای اشیاء تعبیه‌شده**

پس از تعبیهٔ یک شیء OLE، پیش‌نمایشی شامل یک تصویر نماد به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر بخواهید از تصویر و متن خاصی به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر نماد و عنوان را با استفاده از Aspose.Slides for Java تنظیم کنید.

این کد Java نشان می‌دهد چگونه تصویر نماد و عنوان برای یک شیء تعبیه‌شده تنظیم شود:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// تصویر را به منابع ارائه اضافه کنید.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// عنوان و تصویر پیش‌نمایش OLE را تنظیم کنید.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **جلوگیری از تغییر اندازه و موقعیت فریم شیء OLE**

پس از اضافه کردن یک شیء OLE لینک‌دار به اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید، ممکن است پیامی مبنی بر به‌روزرسانی لینک‌ها ببینید. کلیک روی دکمه «Update Links» ممکن است اندازه و موقعیت فریم شیء OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شیء OLE لینک‌دار به‌روزرسانی می‌کند و پیش‌نمایش شیء را تازه می‌سازد. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی داده‌های شیء، متد [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) رابط [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) را با مقدار `false` فراخوانی کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **استخراج فایل‌های تعبیه‌شده**

Aspose.Slides for Java به شما امکان می‌دهد فایل‌های تعبیه‌شده در اسلایدها را به‌عنوان اشیاء OLE به این شکل استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) که شامل اشیاء OLE موردنظر برای استخراج است، بسازید.  
2. در تمام اشکال ارائه حلقه بزنید و شکل‌های [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) را دسترسی پیدا کنید.  
3. داده‌های فایل‌های تعبیه‌شده را از فریم‌های OLE استخراج کرده و بر روی دیسک بنویسید.  

این کد Java نشان می‌دهد چگونه فایل‌های تعبیه‌شده در یک اسلاید را به‌عنوان اشیاء OLE استخراج کنید:

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

**آیا محتوای OLE هنگام خروجی گرفتن اسلایدها به PDF/تصاویر رندر می‌شود؟**

آنچه در اسلاید قابل مشاهده است رندر می‌شود — نماد/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE در هنگام رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر موردنظر در PDF خروجی تضمین شود.

برای حفظ فایل تعبیه‌شده به‌عنوان پیوست PDF، متد [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) را با `true` فراخوانی کنید. این گزینه به‌صورت پیش‌فرض غیرفعال است. برای مثال و دستورالعمل بررسی پیوست، به [Preserve Embedded OLE Files as PDF Attachments](/slides/fa/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) مراجعه کنید.

**چگونه می‌توان یک شیء OLE را در اسلاید قفل کرد تا کاربران نتوانند آن را در PowerPoint جابه‌جا/ویرایش کنند؟**

شکل را قفل کنید: Aspose.Slides [قفل‌های سطح شکل](/slides/fa/java/applying-protection-to-presentation/) را فراهم می‌کند. این رمزگذاری نیست، اما به‌طور مؤثر از ویرایش و جابهجایی تصادفی جلوگیری می‌کند.

**چرا یک شیء Excel لینک‌دار «پرش» می‌کند یا هنگام باز کردن ارائه اندازه‌اش تغییر می‌کند؟**

PowerPoint ممکن است پیش‌نمایش OLE لینک‌دار را تازه کند. برای ظاهر ثابت، روش‌های [Working Solution for Worksheet Resizing](/slides/fa/java/working-solution-for-worksheet-resizing/) را دنبال کنید — یا فریم را به بازهٔ داده‌ای متناسب کنید، یا بازه را به فریم ثابت مقیاس دهید و تصویر جایگزین مناسب تنظیم کنید.

**آیا مسیرهای نسبی برای اشیاء OLE لینک‌دار در قالب PPTX حفظ می‌شوند؟**

در PPTX، اطلاعات «مسیر نسبی» موجود نیست — تنها مسیر کامل ذخیره می‌شود. مسیرهای نسبی در قالب قدیمی‌تر PPT یافت می‌شوند. برای قابلیت حمل، بهتر است از مسیرهای مطلق قابل اعتماد/URIهای قابل دسترس یا تعبیه استفاده کنید.