---
title: مدیریت OLE در ارائه‌ها بر روی اندروید
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/androidjava/manage-ole/
keywords:
- شیء OLE
- پیوند و جاسازی اشیاء
- افزودن OLE
- جاسازی OLE
- افزودن شیء
- جاسازی شیء
- افزودن فایل
- جاسازی فایل
- شیء لینک‌شده
- فایل لینک‌شده
- تغییر OLE
- آیکون OLE
- عنوان OLE
- استخراج OLE
- استخراج شیء
- استخراج فایل
- PowerPoint
- ارائه
- اندروید
- Java
- Aspose.Slides
description: "بهینه‌سازی مدیریت اشیای OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای اندروید از طریق Java. به‌صورت یکپارچه OLE را جاسازی، به‌روزرسانی و صادر کنید."
---
## **مقدمه**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که اجازه می‌دهد داده‌ها و اشیائی که در یک برنامه ساخته شده‌اند، از طریق لینک یا جاسازی در برنامه دیگری قرار گیرند. 

{{% /alert %}} 

تصور کنید یک نمودار در MS Excel ایجاد شده است. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به عنوان یک شیء OLE درنظر گرفته می‌شود. 

- یک شیء OLE ممکن است به شکل یک آیکون ظاهر شود. در این حالت، وقتی روی آیکون دوبار کلیک می‌کنید، نمودار در برنامه مربوطه (Excel) باز می‌شود یا از شما خواسته می‌شود برنامه‌ای برای باز کردن یا ویرایش شیء انتخاب کنید. 
- یک شیء OLE می‌تواند محتوای واقعی خود را نشان دهد، مانند محتوای یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگیری می‌شود و می‌توانید داده‌های نمودار را در داخل PowerPoint اصلاح کنید. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/fa/androidjava/) به شما امکان می‌دهد اشیاء OLE را به اسلایدها به صورت فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleObjectFrame)) وارد کنید. 

## **افزودن فریم‌های شیء OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ساخته‌اید و می‌خواهید آن را به عنوان یک فریم شیء OLE در اسلایدی جاسازی کنید با استفاده از Aspose.Slides for Android via Java. می‌توانید به این شکل انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
1. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. فایل Excel را به عنوان یک آرایه بایت بخوانید.  
1. فریم [OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleObjectFrame) را به اسلاید اضافه کنید و آرایه بایت و سایر اطلاعات مربوط به شیء OLE را قرار دهید.  
1. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.  

در مثال زیر، یک نمودار از فایل Excel به اسلاید به عنوان فریم شیء OLE اضافه کردیم با استفاده از Aspose.Slides for Android via Java.  
**توجه** داشته باشید که سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleEmbeddedDataInfo) یک پسوند شیء قابل جاسازی را به عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint امکان می‌دهد نوع فایل را به‌درستی تفسیر کند و برنامه مناسب برای باز کردن این شیء OLE را انتخاب نماید.  

```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// داده‌ها را برای شیء OLE آماده کنید.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// افزودن فریم شیء OLE به اسلاید.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **افزودن فریم‌های شیء OLE لینک‌شده**

Aspose.Slides for Android via Java به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleObjectFrame) را بدون جاسازی داده، تنها با یک لینک به فایل اضافه کنید.  

کد Java زیر نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleObjectFrame) را با یک فایل Excel لینک‌شده به اسلاید اضافه کنید:  

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// افزودن فریم شیء OLE با یک فایل Excel لینک‌شده.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE از پیش در یک اسلاید جاسازی شده باشد، می‌توانید به راحتی آن را پیدا یا دسترسی پیدا کنید به این شکل:

1. یک ارائه حاوی شیء OLE جاسازی شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OleObjectFrame) را دسترسی پیدا کنید.  
   در مثال ما، از PPTX قبلاً ساخته شده‌ای استفاده کردیم که تنها یک شکل بر روی اولین اسلاید دارد. سپس آن شیء را به‌عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/) *cast* کردیم. این فریم شیء OLE مورد نظر برای دسترسی بود.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel جاسازی‌شده در اسلاید) و دادهٔ فایل آن دسترسی پیدا می‌شود.  

```java 
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

### **دسترسی به ویژگی‌های فریم شیء OLE لینک‌شده**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های فریم شیء OLE لینک‌شده را دسترسی پیدا کنید.  

کد Java زیر نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE لینک‌شده است و سپس مسیر فایل لینک‌شده را دریافت کنید:  

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // بررسی کنید آیا شیء OLE لینک‌شده است.
    if (oleFrame.isObjectLink()) {
        // مسیر کامل فایل لینک‌شده را چاپ کنید.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // اگر موجود باشد، مسیر نسبی فایل لینک‌شده را چاپ کنید.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **تغییر دادهٔ شیء OLE**

{{% alert color="primary" %}} 

در این بخش، مثال کد زیر از [Aspose.Cells for Android via Java](/cells/androidjava/) استفاده می‌کند.  

{{% /alert %}} 

اگر یک شیء OLE از پیش در اسلاید جاسازی شده باشد، می‌توانید به راحتی به آن دسترسی پیدا کرده و داده‌های آن را به این شکل تغییر دهید:

1. یک ارائه حاوی شیء OLE جاسازی شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) بارگذاری کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. شکل فریم شیء OLE را دسترسی پیدا کنید.  
   در مثال ما، از PPTX قبلاً ساخته شده‌ای استفاده کردیم که یک شکل بر روی اولین اسلاید دارد. سپس آن شیء را به‌عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/) *cast* کردیم. این فریم شیء OLE مورد نظر برای دسترسی بود.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  
5. یک شیء `Workbook` ایجاد کنید و دادهٔ OLE را دسترسی پیدا کنید.  
6. `Worksheet` مورد نظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.  
7. `Workbook` بروز شده را در یک جریان ذخیره کنید.  
8. دادهٔ شیء OLE را از جریان تغییر دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel جاسازی‌شده در اسلاید) دسترسی پیدا می‌شود و دادهٔ فایل آن اصلاح می‌شود تا داده‌های نمودار به‌روز شود.  

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // داده‌های شیء OLE را به‌عنوان یک شیء Workbook بخوانید.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // داده‌های کتاب‌کاری (Workbook) را اصلاح کنید.
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

## **جاسازی انواع دیگر فایل‌ها در اسلایدها**

به‌جز نمودارهای Excel، Aspose.Slides for Android via Java به شما امکان می‌دهد انواع دیگر فایل‌ها را به اسلایدها جاسازی کنید. به عنوان مثال، می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. وقتی کاربر روی شیء وارد شده دوبار کلیک می‌کند، به‌صورت خودکار در برنامه مرتبط باز می‌شود یا از کاربر درخواست می‌شود برنامهٔ مناسب برای باز کردن آن را انتخاب کند.  

کد Java زیر نشان می‌دهد چگونه HTML و ZIP را به یک اسلاید جاسازی کنید:  

```java
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

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده تعویض کنید. Aspose.Slides for Android via Java به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده را تنظیم کنید، به‌طوری که بتوانید دادهٔ فریم OLE یا پسوند آن را بروز کنید.  

کد Java زیر نشان می‌دهد چگونه نوع فایل برای یک شیء OLE جاسازی‌شده را به `zip` تنظیم کنید:  

```java
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

## **تنظیم تصویر آیکون و عنوان برای اشیاء جاسازی‌شده**

پس از جاسازی یک شیء OLE، یک پیش‌نمایش شامل تصویر آیکون به‌طور خودکار اضافه می‌شود. این پیش‌نمایش آن چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متن خاصی به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکون و عنوان را با Aspose.Slides for Android via Java تنظیم کنید.  

کد Java زیر نشان می‌دهد چگونه تصویر آیکون و عنوان را برای یک شیء جاسازی‌شده تنظیم کنید:  

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// یک تصویر را به منابع ارائه اضافه کنید.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// عنوان و تصویر را برای پیش‌نمایش OLE تنظیم کنید.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **جلوگیری از تغییر اندازه و موقعیت فریم شیء OLE**

پس از افزودن یک شیء OLE لینک‌شده به یک اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید ممکن است پیغامی مبنی بر «به‌روزرسانی لینک‌ها» ببینید. کلیک بر روی دکمه «Update Links» ممکن است اندازه و موقعیت فریم شیء OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شیء OLE لینک‌شده به‌روز کرده و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی داده‌های شیء، روش `setUpdateAutomatic` رابط [IOleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/) را به `false` تنظیم کنید:  

```java
oleFrame.setUpdateAutomatic(false);
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides for Android via Java به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها به‌عنوان اشیاء OLE را به این شکل استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید که شامل اشیاء OLE مورد نظر برای استخراج باشد.  
2. تمام اشکال موجود در ارائه را حلقه بزنید و به اشکال [OLEObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/oleobjectframe) دسترسی پیدا کنید.  
3. دادهٔ فایل‌های جاسازی‌شده را از فریم‌های OLEObject استخراج کرده و به دیسک بنویسید.  

کد Java زیر نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به‌عنوان اشیاء OLE استخراج کنید:  

```java
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

**آیا محتوای OLE هنگام خروجی گرفتن اسلایدها به PDF/تصاویر رندر می‌شود؟**  

آنچه روی اسلاید دیده می‌شود رندر می‌شود — آیکون/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE هنگام رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خودتان را تنظیم کنید تا ظاهر مورد انتظار در PDF استخراج‌شده حفظ شود.  

**چگونه می‌توانم یک شیء OLE را در اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint حرکت یا ویرایش دهند؟**  

قفل کردن شکل: Aspose.Slides قفل‌های سطح شکل را فراهم می‌کند. این قفل‌گذاری رمزگذاری نیست، اما به‌صورت مؤثر از ویرایش‌ها و جابه‌جایی‌های ناخواسته جلوگیری می‌کند.  

**چرا یک شیء Excel لینک‌شده «پرش» می‌کند یا هنگام باز کردن ارائه اندازه‌اش تغییر می­کند؟**  

PowerPoint ممکن است پیش‌نمایش OLE لینک‌شده را تازه کند. برای داشتن ظاهر ثابت، از روش‌های موجود در [Working Solution for Worksheet Resizing](/slides/fa/androidjava/working-solution-for-worksheet-resizing/) پیروی کنید — یا فریم را به محدوده مطابقت دهید یا محدوده را به فریم ثابت مقیاس کنید و تصویر جایگزین مناسب تنظیم کنید.  

**آیا مسیرهای نسبی برای اشیاء OLE لینک‌شده در قالب PPTX حفظ می‌شوند؟**  

در PPTX اطلاعات «مسیر نسبی» موجود نیست — تنها مسیر کامل ذخیره می‌شود. مسیرهای نسبی در قالب قدیمی PPT یافت می‌شوند. برای جابجایی آسان، مسیرهای مطلق قابل اعتماد/URIهای قابل دسترس یا جاسازی را ترجیح دهید.  