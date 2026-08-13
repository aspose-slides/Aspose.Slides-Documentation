---
title: مدیریت OLE در ارائه‌ها بر روی Android
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/androidjava/manage-ole/
keywords:
- شیء OLE
- پیوند و جاسازی شیء
- افزودن OLE
- جاسازی OLE
- افزودن شیء
- جاسازی شیء
- افزودن فایل
- جاسازی فایل
- شیء پیوندی
- فایل پیوندی
- تغییر OLE
- آیکون OLE
- عنوان OLE
- استخراج OLE
- استخراج شیء
- استخراج فایل
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "بهینه‌سازی مدیریت شیء OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای Android از طریق Java. جاسازی، به‌روزرسانی و صادرات محتوای OLE به‌صورت یکپارچه."
---
## **مقدمه**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که اجازه می‌دهد داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند، از طریق لینک یا جاسازی در برنامه دیگری قرار گیرند. 

{{% /alert %}} 

تصور کنید نموداری در MS Excel ایجاد شده است. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به عنوان یک شیء OLE محسوب می‌شود. 

- یک شیء OLE می‌تواند به صورت یک آیکون نمایش داده شود. در این حالت، وقتی بر روی آیکون دوبار کلیک می‌کنید، نمودار در برنامه مرتبط (Excel) باز می‌شود یا از شما درخواست می‌شود تا برنامه‌ای برای باز کردن یا ویرایش شیء انتخاب کنید. 
- یک شیء OLE می‌تواند محتوای واقعی خود، مانند محتوای یک نمودار، را نمایش دهد. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را داخل PowerPoint اصلاح کنید.

[Aspose.Slides برای Android از طریق Java](https://products.aspose.com/slides/fa/androidjava/) به شما امکان می‌دهد شیءهای OLE را به عنوان فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleObjectFrame)) به اسلایدها اضافه کنید.

## **افزودن فریم‌های شیء OLE به اسلایدها**

فرض کنید که یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به عنوان فریم شیء OLE در یک اسلاید جاسازی کنید با استفاده از Aspose.Slides برای Android از طریق Java؛ می‌توانید به این شکل عمل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
1. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
1. فایل Excel را به صورت یک آرایه بایت بخوانید.  
1. فریم [OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleObjectFrame) را به اسلاید اضافه کنید و آرایه بایت و سایر اطلاعات مربوط به شیء OLE را تنظیم کنید.  
1. ارائه اصلاح‌شده را به صورت یک فایل PPTX ذخیره کنید.  

در مثال زیر، ما یک نمودار از یک فایل Excel را به عنوان فریم شیء OLE به اسلاید اضافه کرده‌ایم با استفاده از Aspose.Slides برای Android از طریق Java.  
**توجه** که سازنده‌ی [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleEmbeddedDataInfo) یک پسوند شیء قابل جاسازی را به عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint امکان می‌دهد تا نوع فایل را به‌درستی تشخیص داده و برنامه مناسب برای باز کردن این شیء OLE را انتخاب کند.

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **افزودن فریم‌های شیء OLE پیوندی**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleObjectFrame) بدون جاسازی داده‌ها، فقط با یک لینک به فایل اضافه کنید.

این کد Java نشان می‌دهد که چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleObjectFrame) با یک فایل Excel پیوندی به یک اسلاید اضافه کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// یک فریم شیء OLE با فایل اکسل پیوندی اضافه کنید.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE قبلاً در یک اسلاید جاسازی شده باشد، می‌توانید به راحتی آن را پیدا یا دسترسی پیدا کنید:

1. ارائه‌ای که شامل شیء OLE جاسازی‌شده است را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از شاخص آن به‌دست آورید.  
3. شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleObjectFrame) را دسترسی پیدا کنید.  
   در مثال ما، PPTX قبلاً ساخته‌شده که تنها یک شکل روی اولین اسلاید دارد استفاده شد. سپس آن شیء را به عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/) تبدیل (cast) کردیم. این فریم شیء OLE مورد نظر برای دسترسی بود.  
4. هنگامی که فریم شیء OLE دسترسی یافت، می‌توانید هر عملیاتی را روی آن انجام دهید.  

در مثال زیر، فریم شیء OLE (یک شیء نمودار Excel که در یک اسلاید جاسازی شده) و داده‌های فایل آن دسترسی پیدا می‌شوند.

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // داده‌های فایل جاسازی‌شده را دریافت کنید.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // پسوند فایل جاسازی‌شده را دریافت کنید.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **دسترسی به ویژگی‌های فریم شیء OLE پیوندی**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های فریم شیء OLE پیوندی را دسترسی پیدا کنید.

این کد Java نشان می‌دهد که چگونه بررسی کنید آیا یک شیء OLE پیوندی است و سپس مسیر فایل پیوندی را دریافت کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // بررسی کنید آیا شیء OLE پیوندی است.
    if (oleFrame.isObjectLink()) {
        // مسیر کامل فایل پیوندی را چاپ کنید.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // اگر موجود باشد، مسیر نسبی فایل پیوندی را چاپ کنید.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **تغییر داده‌های شیء OLE**

{{% alert color="info" %}} 

در این بخش، مثال کد زیر از [Aspose.Cells برای Android از طریق Java](/cells/androidjava/) استفاده می‌کند.

{{% /alert %}}

اگر یک شیء OLE قبلاً در یک اسلاید جاسازی شده باشد، می‌توانید به راحتی آن شیء را دسترسی پیدا کنید و داده‌های آن را به این شکل اصلاح کنید:

1. ارائه‌ای که شامل شیء OLE جاسازی‌شده است را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. شکل فریم شیء OLE را دسترسی پیدا کنید.  
   در مثال ما، PPTX قبلاً ساخته‌شده که یک شکل روی اولین اسلاید دارد استفاده شد. سپس آن شیء را به عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/) تبدیل (cast) کردیم. این فریم شیء OLE مورد نظر برای دسترسی بود.  
4. هنگامی که فریم شیء OLE دسترسی یافت، می‌توانید هر عملیاتی را روی آن انجام دهید.  
5. یک شیء `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.  
6. `Worksheet` مورد نظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.  
7. `Workbook` به‌روزشده را در یک جریان (stream) ذخیره کنید.  
8. داده‌های شیء OLE را از جریان تغییر دهید.  

در مثال زیر، فریم شیء OLE (یک شیء نمودار Excel که در یک اسلاید جاسازی شده) دسترسی پیدا می‌شود و داده‌های فایل آن برای به‌روزرسانی داده‌های نمودار تغییر می‌یابد.

```java 
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

    // داده‌های Workbook را اصلاح کنید.
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

## **جاسازی انواع فایل‌های دیگر در اسلایدها**

به‌جز نمودارهای Excel، Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد انواع دیگری از فایل‌ها را به اسلایدها جاسازی کنید. برای مثال، می‌توانید فایل‌های HTML، PDF و ZIP را به عنوان اشیاء وارد کنید. وقتی کاربر بر روی شیء درج‌شده دوبار کلیک می‌کند، به‌صورت خودکار در برنامه مربوطه باز می‌شود یا از کاربر خواسته می‌شود تا برنامه مناسب برای باز کردن آن را انتخاب کند.

این کد Java نشان می‌دهد که چگونه HTML و ZIP را به یک اسلاید جاسازی کنید:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **تنظیم نوع فایل برای اشیاء جاسازی‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید تا اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده را تنظیم کنید، به‌طوری که بتوانید داده‌های فریم OLE یا پسوند آن را به‌روز کنید.

این کد Java نشان می‌دهد که چگونه نوع فایل برای یک شیء OLE جاسازی‌شده به `zip` تنظیم شود:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// نوع فایل را به ZIP تغییر دهید.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **تنظیم تصاویر آیکون و عناوین برای اشیاء جاسازی‌شده**

پس از جاسازی یک شیء OLE، پیش‌نمایشی متشکل از یک تصویر آیکون به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متنی خاص به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکون و عنوان را با استفاده از Aspose.Slides برای Android از طریق Java تنظیم کنید.

این کد Java نشان می‌دهد که چگونه تصویر آیکون و عنوان برای یک شیء جاسازی‌شده تنظیم شود:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// یک تصویر به منابع ارائه اضافه کنید.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **جلوگیری از تغییر اندازه و جابه‌جایی فریم شیء OLE**

بعد از افزودن یک شیء OLE پیوندی به اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید ممکن است پیامی ببینید که از شما می‌خواهد لینک‌ها را به‌روز کنید. کلیک بر روی دکمه «Update Links» ممکن است اندازه و موقعیت فریم شیء OLE را تغییر دهد چون PowerPoint داده‌ها را از شیء OLE پیوندی به‌روز کرده و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی داده‌های شیء، متد `setUpdateAutomatic` رابط [IOleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/) را روی `false` تنظیم کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها به‌عنوان اشیاء OLE را به این شکل استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید که شامل اشیاء OLE مورد نظر برای استخراج است.  
2. تمام شکل‌ها در ارائه را پیمایش کنید و به شکل‌های [OLEObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/oleobjectframe) دسترسی پیدا کنید.  
3. داده‌های فایل‌های جاسازی‌شده را از فریم‌های شیء OLE استخراج کنید و روی دیسک بنویسید.  

این کد Java نشان می‌دهد که چگونه فایل‌های جاسازی‌شده در یک اسلاید را به عنوان اشیاء OLE استخراج کنید:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **سوالات متداول**

### آیا محتوای OLE هنگام خروجی گرفتن اسلایدها به PDF/تصاویر رندر می‌شود؟

آنچه روی اسلاید دیده می‌شود رندر می‌شود — آیکون/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE در حین رندر اجرا نمی‌شود. در صورت نیاز، پیش‌نمایش خود را تنظیم کنید تا ظاهر مورد انتظار در PDF خروجی حفظ شود.

### چگونه می‌توان یک شیء OLE را روی اسلاید قفل کرد تا کاربران نتوانند آن را در PowerPoint جابه‌جا یا ویرایش کنند؟

شکل را قفل کنید: Aspose.Slides قفل‌های سطح شکل را فراهم می‌کند. این قفل‌گذاری رمزگذاری نیست، اما به‌صورت مؤثر از ویرایش یا جابه‌جایی تصادفی جلوگیری می‌کند.

### چرا یک شیء Excel پیوندی «پرش» می‌کند یا اندازه‌اش تغییر می‌یابد وقتی ارائه را باز می‌کنم؟

PowerPoint ممکن است پیش‌نمایش OLE پیوندی را تازه کند. برای داشتن ظاهر ثابت، اصول [راه‌حل کار برای تغییر اندازه کاربرگ](/slides/fa/androidjava/working-solution-for-worksheet-resizing/) را دنبال کنید — یا فریم را به محدوده بسازید، یا محدوده را به فریم ثابت مقیاس کنید و تصویر جایگزین مناسب تنظیم کنید.

### آیا مسیرهای نسبی برای اشیاء OLE پیوندی در قالب PPTX حفظ می‌شوند؟

در PPTX اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در قالب قدیمی PPT یافت می‌شوند. برای قابلیت حمل، بهتر است از مسیرهای مطلق قابل اعتماد/URIهای قابل دسترس یا جاسازی استفاده کنید.