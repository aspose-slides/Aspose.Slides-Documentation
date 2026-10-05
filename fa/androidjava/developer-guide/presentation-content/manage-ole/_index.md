---
title: مدیریت OLE در ارائه‌ها در اندروید
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
- اندروید
- جاوا
- Aspose.Slides
description: "بهینه‌سازی مدیریت اشیاء OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای اندروید از طریق جاوا. به‌صورت یکپارچه OLE را جاسازی، به‌روز‌رسانی و صادر کنید."
---
## **مقدمه**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) یک تکنولوژی مایکروسافت است که اجازه می‌دهد داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند، از طریق لینک کردن یا جاسازی در برنامه دیگر قرار گیرند.
{{% /alert %}}

یک نمودار ایجاد شده در مایکروسافت اکسل را در نظر بگیرید. سپس این نمودار داخل یک اسلاید پاورپوینت قرار می‌گیرد. آن نمودار اکسل به عنوان یک شیء OLE در نظر گرفته می‌شود.

- یک شیء OLE ممکن است به صورت یک آیکون نمایش داده شود. در این صورت، وقتی روی آیکون دوبار کلیک می‌کنید، نمودار در برنامه مرتبط خود (Excel) باز می‌شود یا از شما خواسته می‌شود برنامه‌ای برای باز کردن یا ویرایش شیء انتخاب کنید.
- یک شیء OLE ممکن است محتویات واقعی خود را نمایش دهد، مانند محتویات یک نمودار. در این حالت، نمودار در پاورپوینت فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را داخل پاورپوینت اصلاح کنید.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) به شما اجازه می‌دهد OLE Object‌ها را به اسلایدها به عنوان فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)) وارد کنید.

## **افزودن فریم‌های شیء OLE به اسلایدها**

فرض کنید که قبلاً یک نمودار در مایکروسافت اکسل ایجاد کرده‌اید و می‌خواهید آن را به عنوان یک فریم شیء OLE در یک اسلاید با استفاده از Aspose.Slides for Android via Java جاسازی کنید، می‌توانید به این روش انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.
3. فایل اکسل را به‌عنوان یک آرایه بایت بخوانید.
4. فریم [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) را به اسلاید اضافه کنید که شامل آرایه بایت و سایر اطلاعات مربوط به شیء OLE باشد.
5. نمایش اصلاح‌شده را به‌صورت یک فایل PPTX ذخیره کنید.

در مثال زیر، یک نمودار از یک فایل اکسل را به عنوان فریم شیء OLE به یک اسلاید اضافه کردیم با استفاده از Aspose.Slides for Android via Java. **توجه** داشته باشید که سازنده [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) یک پسوند شیء قابل جاسازی را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به پاورپوینت امکان می‌دهد تا نوع فایل را به‌درستی تفسیر کند و برنامه مناسب برای باز کردن این شیء OLE را انتخاب نماید.

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

// آماده‌سازی داده‌ها برای شیء OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// اضافه‌کردن فریم شیء OLE به اسلاید.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **افزودن فریم‌های شیء OLE پیوندی**

Aspose.Slides for Android via Java به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) را بدون جاسازی داده، فقط با یک لینک به فایل اضافه کنید.

این کد جاوا نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) با یک فایل اکسل پیوندی به یک اسلاید اضافه کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// اضافه‌کردن فریم شیء OLE با یک فایل اکسل پیوندی.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE قبلاً در یک اسلاید جاسازی شده باشد، می‌توانید به‌راحتی آن را به این روش پیدا یا دسترسی پیدا کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) ایجاد کنید تا یک ارائه حاوی شیء OLE جاسازی‌شده را بارگذاری کنید.
2. مرجع اسلاید را با استفاده از اندیس آن دریافت کنید.
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ایجاد شده که فقط یک شکل در اسلاید اول دارد استفاده کردیم. سپس آن شیء را به‌عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) *cast* کردیم. این فریم شیء OLE مورد نظر برای دسترسی بود.
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.

در مثال زیر، یک فریم شیء OLE (شیء نمودار اکسل جاسازی‌شده در یک اسلاید) و داده‌های فایل آن دسترسی پیدا می‌شوند.

```java 
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

### **دسترسی به ویژگی‌های فریم شیء OLE پیوندی**

Aspose.Slides به شما امکان می‌دهد به ویژگی‌های فریم شیء OLE پیوندی دسترسی پیدا کنید.

این کد جاوا نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE پیوندی است و سپس مسیر فایل پیوندی را به‌دست آورید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // بررسی اینکه آیا شیء OLE پیوندی است.
    if (oleFrame.isObjectLink()) {
        // چاپ مسیر کامل فایل پیوندی.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // چاپ مسیر نسبی فایل پیوندی اگر موجود باشد.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را دربر داشته باشند.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **تغییر داده‌های شیء OLE**

{{% alert color="info" title="Note" %}}
در این بخش، مثال کد زیر از [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/) استفاده می‌کند.
{{% /alert %}}

اگر یک شیء OLE قبلاً در یک اسلاید جاسازی شده باشد، می‌توانید به‌راحتی به آن شیء دسترسی پیدا کنید و داده‌های آن را به این روش تغییر دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) ایجاد کنید تا یک ارائه حاوی شیء OLE جاسازی‌شده را بارگذاری کنید.
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.
3. به شکل فریم شیء OLE دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ایجاد شده که فقط یک شکل در اسلاید اول دارد استفاده کردیم. سپس آن شیء را به‌عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) *cast* کردیم. این فریم شیء OLE مورد نظر برای دسترسی بود.
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.
5. یک شیء `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.
6. `Worksheet` مورد نظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.
7. `Workbook` به‌روز شده را در یک جریان (stream) ذخیره کنید.
8. داده‌های شیء OLE را از جریان تغییر دهید.

در مثال زیر، یک فریم شیء OLE (شیء نمودار اکسل جاسازی‌شده در یک اسلاید) دسترسی پیدا می‌شود و داده‌های فایل آن اصلاح می‌شود تا داده‌های نمودار به‌روزرسانی شوند.

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

    // داده‌های شیء فریم OLE را تغییر دهید.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **جاسازی انواع فایل‌های دیگر در اسلایدها**

علاوه بر نمودارهای اکسل، Aspose.Slides for Android via Java به شما امکان می‌دهد انواع دیگر فایل‌ها را در اسلایدها جاسازی کنید. به‌عنوان مثال، می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. وقتی کاربر روی شیء وارد شده دوبار کلیک می‌کند، به‌صورت خودکار در برنامه مرتبط باز می‌شود یا از کاربر خواسته می‌شود برنامه مناسب برای باز کردن را انتخاب کند.

این کد جاوا نشان می‌دهد چگونه HTML و ZIP را در یک اسلاید جاسازی کنید:

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

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides for Android via Java به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده را تنظیم کنید، که به‌روزرسانی داده‌های فریم OLE یا پسوند آن را ممکن می‌سازد.

این کد جاوا نشان می‌دهد چگونه نوع فایل برای یک شیء OLE جاسازی‌شده را به `zip` تنظیم کنید:

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

## **تنظیم تصاویر آیکون و عناوین برای اشیاء جاسازی‌شده**

پس از جاسازی یک شیء OLE، پیش‌نمایشی شامل تصویر آیکون به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید تصویر و متن خاصی را به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید با استفاده از Aspose.Slides for Android via Java تصویر آیکون و عنوان را تنظیم کنید.

این کد جاوا نشان می‌دهد چگونه تصویر آیکون و عنوان را برای یک شیء جاسازی‌شده تنظیم کنید:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// اضافه‌کردن تصویر به منابع ارائه.
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

## **جلوگیری از تغییر اندازه و موقعیت فریم شیء OLE**

پس از افزودن یک شیء OLE پیوندی به یک اسلاید ارائه، وقتی ارائه را در پاورپوینت باز می‌کنید، ممکن است پیغامی ببینید که از شما می‌خواهد لینک‌ها را به‌روزرسانی کنید. کلیک روی دکمه «Update Links» ممکن است اندازه و موقعیت فریم شیء OLE را تغییر دهد زیرا پاورپوینت داده‌ها را از شیء OLE پیوندی به‌روزرسانی می‌کند و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از درخواست پاورپوینت برای به‌روزرسانی داده‌های شیء، متد [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) از رابط [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) را با مقدار `false` فراخوانی کنید:

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

Aspose.Slides for Android via Java به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها را به‌عنوان اشیاء OLE به این شکل استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) ایجاد کنید که شامل اشیاء OLE مورد نظر برای استخراج باشد.
2. از طریق تمام شکل‌ها در ارائه حلقه بزنید و به شکل‌های [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) دسترسی پیدا کنید.
3. داده‌های فایل‌های جاسازی‌شده را از فریم‌های شیء OLE استخراج کنید و به دیسک بنویسید.

این کد جاوا نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به‌عنوان اشیاء OLE استخراج کنید:

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

**آیا محتوای OLE هنگام استخراج اسلایدها به PDF/تصاویر رندر می‌شود؟**  
آنچه بر روی اسلاید قابل مشاهده است رندر می‌شود — آیکون/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE در هنگام رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر مورد انتظار در PDF خروجی تضمین شود.  

برای حفظ فایل جاسازی‌شده به‌عنوان یک پیوست PDF، متد [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) را با مقدار `true` فراخوانی کنید. این گزینه به‌طور پیش‌فرض غیرفعال است. برای مثال و دستورالعمل‌های بررسی پیوست، به [حفظ فایل‌های OLE جاسازی‌شده به‌صورت پیوست‌های PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) مراجعه کنید.

**چگونه می‌توانم یک شیء OLE را روی اسلاید قفل کنم تا کاربران نتوانند آن را در پاورپوینت جابه‌جا یا ویرایش کنند؟**  
قفل کردن شکل: Aspose.Slides قفل‌های سطح شکل ارائه می‌دهد. این قفل‌ها رمزنگاری نیستند، اما به‌طور مؤثری از ویرایش و جابه‌جایی تصادفی جلوگیری می‌کنند.

**چرا یک شیء اکسل پیوندی هنگام باز کردن ارائه «پرش» می‌کند یا اندازه‌اش تغییر می‌یابد؟**  
پاورپوینت ممکن است پیش‌نمایش OLE پیوندی را تازه کند. برای داشتن یک ظاهر ثابت، از روش‌های [راه‌حل عملی برای تغییر اندازه برگه کاری](/slides/fa/androidjava/working-solution-for-worksheet-resizing/) پیروی کنید — یا فریم را به بازه تنظیم کنید، یا بازه را به فریم ثابت مقیاس‌بندی کرده و تصویر جایگزین مناسب تنظیم کنید.

**آیا مسیرهای نسبی برای اشیاء OLE پیوندی در قالب PPTX حفظ می‌شوند؟**  
در PPTX، اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در قالب قدیمی PPT موجود هستند. برای قابلیت جابجایی، بهتر است از مسیرهای مطلق قابل اطمینان/URIهای قابل دسترس یا جاسازی استفاده کنید.