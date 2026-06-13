---
title: بهینه‌سازی مدیریت تصویر در ارائه‌ها بر روی Android
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/androidjava/image/
keywords:
- افزودن تصویر
- افزودن عکس
- افزودن بیت‌مپ
- جایگزینی تصویر
- جایگزینی عکس
- از وب
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- افزودن EMF
- افزودن WMF
- افزودن TIFF
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "بهینه‌سازی مدیریت تصویر در PowerPoint و OpenDocument با Aspose.Slides برای Android از طریق Java، بهبود عملکرد و خودکارسازی جریان کار شما."
---
## **معرفی**

تصاویر ارائه‌ها را جذاب‌تر و جالب‌تر می‌کنند. در Microsoft PowerPoint می‌توانید تصاویر را از یک فایل، اینترنت یا مکان‌های دیگر به اسلایدها اضافه کنید. به‌طور مشابه، Aspose.Slides به شما امکان می‌دهد تصاویر را به اسلایدهای ارائه‌های خود از طرق مختلف اضافه کنید.

{{% alert  title="Tip" color="primary" %}} 
Aspose مبدل‌های رایگانی را فراهم می‌کند—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به افراد اجازه می‌دهد به‌سرعت از تصاویر، ارائه‌ها را ایجاد کنند. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
اگر می‌خواهید یک تصویر را به‌عنوان شیء فریم اضافه کنید—به‌ویژه اگر قصد دارید از گزینه‌های قالب‌بندی استاندارد برای تغییر اندازه، افزودن افکت‌ها و غیره استفاده کنید—به [قاب تصویر](https://docs.aspose.com/slides/fa/androidjava/picture-frame/) مراجعه کنید.
{{% /alert %}} 

Aspose.Slides عملیات با تصاویر را در این فرمت‌های محبوب پشتیبانی می‌کند: JPEG، PNG، GIF و سایرین. 

## **افزودن تصاویر ذخیره‌شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر موجود بر روی کامپیوتر خود را به یک اسلاید در یک ارائه اضافه کنید. این کد نمونه به زبان Java نشان می‌دهد چگونه یک تصویر را به اسلاید اضافه کنید:
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **افزودن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید بر روی کامپیوتر شما موجود نیست، می‌توانید تصویر را مستقیماً از وب اضافه کنید. این کد نمونه نشان می‌دهد چگونه یک تصویر را از وب به اسلایدی در Java اضافه کنید:
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **افزودن تصاویر به مستر اسلاید**

مستر اسلاید بالاترین اسلاید است که اطلاعات (قالب، چیدمان و غیره) مربوط به تمام اسلایدهای زیر آن را ذخیره و کنترل می‌کند. بنابراین وقتی یک تصویر را به مستر اسلاید اضافه کنید، آن تصویر بر روی هر اسلاید زیر آن مستر ظاهر می‌شود. این کد نمونه Java نشان می‌دهد چگونه یک تصویر را به مستر اسلاید اضافه کنید:
```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **افزودن تصاویر به‌عنوان پس‌زمینه اسلاید**

ممکن است تصمیم بگیرید از یک تصویر به‌عنوان پس‌زمینه یک اسلاید خاص یا چندین اسلاید استفاده کنید. در این صورت، باید *[تنظیم تصاویر به‌عنوان پس‌زمینه اسلایدها](https://docs.aspose.com/slides/fa/androidjava/presentation-background/#setting-images-as-background-for-slides)* را ببینید.

## **افزودن SVG به ارائه‌ها**

می‌توانید هر تصویر را به یک ارائه اضافه یا وارد کنید با استفاده از متد [addPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) که متعلق به اینترفیس [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) است. برای ایجاد یک شیء تصویر بر پایه تصویر SVG، می‌توانید این کار را به این شکل انجام دهید:

1. ایجاد شیء SvgImage برای وارد کردن به ImageShapeCollection
1. ایجاد شیء PPImage از ISvgImage
1. ایجاد شیء PictureFrame با استفاده از اینترفیس IPPImage

این کد نمونه نشان می‌دهد چگونه مراحل فوق را برای افزودن یک تصویر SVG به یک ارائه اجرا کنید:
```java
// نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **تبدیل SVG به مجموعه‌ای از شکل‌ها**

تبدیل SVG به مجموعه‌ای از شکل‌ها در Aspose.Slides مشابه عملکرد PowerPoint برای کار با تصاویر SVG است:

![منوی کشویی PowerPoint](img_01_01.png)

این عملکرد توسط یکی از overloadهای متد [addGroupShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) از اینترفیس [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) ارائه می‌شود که یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISvgImage) را به عنوان اولین آرگومان دریافت می‌کند. این کد نمونه نشان می‌دهد چگونه از روش توصیف‌شده برای تبدیل یک فایل SVG به مجموعه‌ای از شکل‌ها استفاده کنید:
```java 
// ایجاد ارائه جدید
IPresentation presentation = new Presentation();
try {
    // خواندن محتوای فایل SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // ایجاد شیء SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // دریافت اندازه اسلاید
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // تبدیل تصویر SVG به گروهی از اشکال و مقیاس‌بندی آن به اندازه اسلاید
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // ذخیره ارائه در قالب PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **افزودن تصاویر به‌صورت EMF به اسلایدها**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد تصاویر EMF را از صفحات Excel تولید کنید و با Aspose.Cells این تصاویر را به‌صورت EMF به اسلایدها اضافه کنید. این کد نمونه نشان می‌دهد چگونه این کار توصیف‌شده را انجام دهید:
```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//ذخیره کتاب کار به جریان
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **جایگزینی تصاویر در مجموعه تصاویر**

Aspose.Slides به شما اجازه می‌دهد تصاویر ذخیره‌شده در مجموعه تصاویر یک ارائه (از جمله آن‌هایی که توسط اشکال اسلاید استفاده می‌شوند) را جایگزین کنید. این بخش چند رویکرد برای به‌روزرسانی تصاویر در مجموعه را نشان می‌دهد. API روش‌های ساده‌ای برای جایگزینی تصویر با استفاده از داده‌های بایت خام، یک نمونه [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) یا تصویر دیگری که قبلاً در مجموعه وجود دارد، فراهم می‌کند.

مراحل زیر را دنبال کنید:

1. فایل ارائه حاوی تصاویر را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری کنید.
1. یک تصویر جدید را از یک فایل به آرایه بایت بارگذاری کنید.
1. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.
1. در رویکرد دوم، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.
1. در رویکرد سوم، تصویر هدف را با تصویری که پیش از این در مجموعه تصاویر ارائه وجود دارد، جایگزین کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.
```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation("sample.pptx");
try {
    // روش اول.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // روش دوم.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // روش سوم.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // ذخیره ارائه در یک فایل.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
با استفاده از مبدل رایگان Aspose [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) می‌توانید به سادگی متن‌ها را انیمیشن کنید، GIFهایی از متن‌ها ایجاد کنید و غیره. 
{{% /alert %}}

## **پرسش‌های متداول**

**آیا وضوح تصویر اصلی پس از قرار دادن حفظ می‌شود؟**

بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی به این بستگی دارد که چگونه [تصویر](/slides/fa/androidjava/picture-frame/) در اسلاید مقیاس‌بندی می‌شود و هرگونه فشرده‌سازی اعمال‌شده در هنگام ذخیره.

**بهترین راه برای جایگزینی لوگوی یکسان در ده‌ها اسلاید به‌صورت همزمان چیست؟**

لوگو را در مستر اسلاید یا یک Layout قرار دهید و آن را در مجموعه تصاویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از این منبع استفاده می‌کنند، منتقل می‌شود.

**آیا یک SVG وارد شده می‌تواند به اشکال قابل ویرایش تبدیل شود؟**

بله. می‌توانید یک SVG را به یک گروه از اشکال تبدیل کنید، که پس از آن بخش‌های جداگانه با ویژگی‌های استاندارد شکل قابل ویرایش می‌شوند.

**چگونه می‌توانم یک تصویر را به‌عنوان پس‌زمینه چندین اسلاید به‌صورت همزمان تنظیم کنم؟**

[تصویر را به‌عنوان پس‌زمینه تعیین کنید](/slides/fa/androidjava/presentation-background/) در مستر اسلاید یا لایه مربوطه—هر اسلایدی که از آن مستر/لایه استفاده می‌کند، پس‌زمینه را به ارث می‌برد.

**چگونه می‌توانم از بزرگ شدن بیش از حد اندازه ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کنم؟**

به جای استفاده از تصاویر تکراری، یک منبع تصویر واحد را دوباره استفاده کنید، وضوح‌های معقول را انتخاب کنید، در زمان ذخیره‌سازی فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر نگه دارید، جایی که مناسب است.