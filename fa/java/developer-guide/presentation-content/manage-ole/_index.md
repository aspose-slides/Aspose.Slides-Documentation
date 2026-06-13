---
title: مدیریت OLE در ارائه‌ها با استفاده از Java
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/java/manage-ole/
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
- Java
- Aspose.Slides
description: "مدیریت شیء OLE را در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای Java بهینه کنید. به‌صورت یکپارچه OLE را جاسازی، به‌روزرسانی و صادر کنید."
---
## **مقدمه**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) یک تکنولوژی مایکروسافت است که امکان قرار دادن داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند، در برنامهٔ دیگری را از طریق لینک دادن یا جاسازی فراهم می‌کند. 

{{% /alert %}} 

به یک نمودار در MS Excel فکر کنید. این نمودار سپس داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel یک شیء OLE محسوب می‌شود. 

- یک شیء OLE می‌تواند به صورت یک آیکون ظاهر شود. در این حالت، وقتی روی آیکون دابل‑کلیک می‌کنید، نمودار در برنامهٔ مرتبط (Excel) باز می‌شود یا از شما خواسته می‌شود برنامه‌ای برای باز یا ویرایش شیء انتخاب کنید. 
- یک شیء OLE می‌تواند محتوای واقعی خود را نشان دهد، مانند محتویات یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را درون PowerPoint اصلاح کنید.

[Aspose.Slides for Java](https://products.aspose.com/slides/fa/java/) به شما اجازه می‌دهد تا اشیاء OLE را به اسلایدها به صورت فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleObjectFrame)) اضافه کنید.

## **افزودن فریم‌های شیء OLE به اسلایدها**

فرض کنید قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به عنوان فریم شیء OLE در اسلاید جاسازی کنید. می‌توانید به این شکل عمل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
1. فایل Excel را به صورت آرایه بایت بخوانید.  
1. فریم [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleObjectFrame) را به اسلاید اضافه کنید و آرایه بایت و سایر اطلاعات مربوط به شیء OLE را قرار دهید.  
1. ارائهٔ اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.  

در مثال زیر، یک نمودار از یک فایل Excel را به عنوان فریم شیء OLE به اسلاید اضافه کردیم.

**نکته** سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleEmbeddedDataInfo) یک پسوند شیء قابل جاسازی را به عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint اجازه می‌دهد نوع فایل را به‌درستی تشخیص داده و برنامهٔ مناسب برای باز کردن این شیء OLE را انتخاب کند.

``` java
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// داده‌های شیء OLE را آماده کنید.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// فریم شیء OLE را به اسلاید اضافه کنید.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **افزودن فریم‌های شیء OLE پیوندی**

Aspose.Slides for Java به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleObjectFrame) بدون جاسازی داده، فقط با پیوندی به فایل اضافه کنید.

این کد Java نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleObjectFrame) با فایل Excel پیوندی به اسلاید اضافه شود:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// فریم شیء OLE را با فایل Excel پیوندی اضافه کنید.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به راحتی آن را به این شکل پیدا یا دسترسی پیدا کنید:

1. یک ارائهٔ دارای شیء OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation)بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از اندیس آن دریافت کنید.  
3. شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OleObjectFrame) را دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ساخته‌شده‌ای که تنها یک شکل در اولین اسلاید دارد استفاده کردیم. سپس آن شیء را به عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IOleObjectFrame) *cast* کردیم. این همان فریم شیء OLE موردنظر بود.  
4. پس از دسترسی به فریم شیء OLE می‌توانید هر عملیاتی را روی آن انجام دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel که در اسلاید جاسازی شده) و دادهٔ فایل آن دسترسی پیدا می‌شود.

``` java
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

Aspose.Slides به شما اجازه می‌دهد ویژگی‌های فریم شیء OLE پیوندی را دسترسی پیدا کنید.

این کد Java نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE پیوندی است و سپس مسیر فایل پیوندی را به‌دست آورید:

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // بررسی کنید آیا شیء OLE پیوندی است.
    if (oleFrame.isObjectLink()) {
        // چاپ مسیر کامل به فایل پیوندی.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // چاپ مسیر نسبی به فایل پیوندی در صورت وجود.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **تغییر داده‌های شیء OLE**

{{% alert color="primary" %}} 

در این بخش، مثال کد زیر از [Aspose.Cells for Java](/cells/java/) استفاده می‌کند.

{{% /alert %}}

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به راحتی به آن دسترسی پیدا کنید و داده‌های آن را به این شکل اصلاح کنید:

1. یک ارائهٔ دارای شیء OLE جاسازی‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation)بارگذاری کنید.  
2. مرجع اسلاید را از طریق اندیس آن بگیرید.  
3. شکل فریم شیء OLE را دسترسی پیدا کنید. در مثال ما، از PPTX قبلاً ساخته‌شده‌ای که یک شکل در اولین اسلاید دارد استفاده کردیم. سپس آن شیء را به عنوان یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IOleObjectFrame) *cast* کردیم. این همان فریم شیء OLE موردنظر بود.  
4. پس از دسترسی به فریم شیء OLE می‌توانید هر عملیاتی را روی آن انجام دهید.  
5. یک شیء `Workbook` ایجاد کنید و به دادهٔ OLE دسترسی پیدا کنید.  
6. `Worksheet` موردنظر را باز کنید و داده‌ها را اصلاح کنید.  
7. `Workbook` به‌روز‌شده را در یک استریم ذخیره کنید.  
8. دادهٔ شیء OLE را از استریم تغییر دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel که در اسلاید جاسازی شده) دسترسی پیدا می‌شود و دادهٔ فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شود.

``` java
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

    // داده‌های شیء OLE frame را تغییر دهید.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **جاسازی انواع فایل‌های دیگر در اسلایدها**

علاوه بر نمودارهای Excel، Aspose.Slides for Java به شما اجازه می‌دهد انواع فایل‌های دیگر را به اسلایدها جاسازی کنید. برای مثال می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. وقتی کاربر روی شیء وارد‌شده دابل‑کلیک می‌کند، به‌صورت خودکار در برنامهٔ مربوطه باز می‌شود یا از کاربر خواست می‌شود برنامهٔ مناسب را برای باز کردن انتخاب کند.

این کد Java نشان می‌دهد چگونه HTML و ZIP را در یک اسلاید جاسازی کنید:

```java
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

هنگام کار با ارائه‌ها ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides for Java به شما اجازه می‌دهد نوع فایل برای یک شیء جاسازی‌شده تنظیم کنید و بدین‌ساز دادهٔ فریم OLE یا پسوند آن را به‌روزرسانی کنید.

این کد Java نشان می‌دهد چگونه نوع فایل برای یک شیء OLE جاسازی‌شده را به `zip` تنظیم کنید:

```java
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

## **تنظیم تصویرهای آیکون و عناوین برای اشیاء جاسازی‌شده**

پس از جاسازی یک شیء OLE، پیش‌نمایشی شامل یک تصویر آیکون به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران پیش از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متن خاصی به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکون و عنوان را با Aspose.Slides for Java تنظیم کنید.

این کد Java نشان می‌دهد چگونه تصویر آیکون و عنوان را برای یک شیء جاسازی‌شده تنظیم کنید:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// یک تصویر به منابع ارائه اضافه کنید.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// یک عنوان و تصویر را برای پیش‌نمایش OLE تنظیم کنید.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **جلوگیری از تغییر اندازه و موقعیت فریم شیء OLE**

پس از افزودن یک شیء OLE پیوندی به اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید ممکن است پیغامی مبنی بر به‌روز‌رسانی لینک‌ها مشاهده کنید. کلیک بر روی دکمه «Update Links» می‌تواند اندازه و موقعیت فریم شیء OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شیء OLE پیوندی به‌روز می‌کند و پیش‌نمایش شیء را تازه‌سازی می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روز‌رسانی دادهٔ شیء، متد `setUpdateAutomatic` رابط [IOleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ioleobjectframe/) را روی `false` تنظیم کنید:

```java
oleFrame.setUpdateAutomatic(false);
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides for Java به شما اجازه می‌دهد فایل‌هایی که به صورت شیء OLE در اسلایدها جاگذاری شده‌اند را به این شکل استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) که شامل اشیاء OLE موردنظر برای استخراج است ایجاد کنید.  
2. در تمام شکل‌های موجود در ارائه پیمایش کنید و به شکل‌های [OLEObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/oleobjectframe) دسترسی پیدا کنید.  
3. دادهٔ فایل‌های جاسازی‌شده را از فریم‌های OLE استخراج کرده و روی دیسک بنویسید.  

این کد Java نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به عنوان اشیاء OLE استخراج کنید:

```java
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

## **FAQ**

**آیا محتوای OLE هنگام استخراج اسلایدها به PDF/تصاویر رندر می‌شود؟**

آنچه روی اسلاید دیده می‌شود رندر می‌شود—آیکون/تصویر جایگزین (پیش‌نمایش). محتوای «زنده» OLE هنگام رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر موردنظر در PDF خروجی حفظ شود.

**چگونه می‌توانم یک شیء OLE را در اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint جابجا/ویرایش کنند؟**

قفل کردن شکل: Aspose.Slides [قفل‌های سطح شکل](/slides/fa/java/applying-protection-to-presentation/) را فراهم می‌کند. این قفل‌گذاری رمزنگاری نیست، اما به‌طور مؤثری از ویرایش و جابجایی ناخواسته جلوگیری می‌کند.

**چرا یک شیء Excel پیوندی «پرش» می‌کند یا هنگام باز کردن ارائه اندازه‌اش تغییر می‌یابد؟**

PowerPoint ممکن است پیش‌نمایش OLE پیوندی را تازه‌سازی کند. برای داشتن ظاهر ثابت، روش‌های [راه‌حل کاری برای تغییر اندازه شیت](/slides/fa/java/working-solution-for-worksheet-resizing/) را دنبال کنید—یا فریم را به بازهٔ داده بساختید یا بازه را به یک فریم ثابت مقیاس کنید و تصویر جایگزین مناسب تنظیم کنید.

**آیا مسیرهای نسبی برای اشیاء OLE پیوندی در فرمت PPTX حفظ می‌شوند؟**

در PPTX اطلاعات «مسیر نسبی» موجود نیست—فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در فرمت PPT قدیمی‌تر یافت می‌شوند. برای قابلیت حمل، ترجیحاً از مسیرهای مطلق قابل‌دسترس/URIهای ثابت یا جاسازی استفاده کنید.