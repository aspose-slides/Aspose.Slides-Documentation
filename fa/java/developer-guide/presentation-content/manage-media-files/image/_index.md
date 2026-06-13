---
title: بهینه‌سازی مدیریت تصاویر در ارائه‌ها با استفاده از جاوا
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/java/image/
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
- EMF
- SVG
- Java
- Aspose.Slides
description: "مدیریت تصاویر در PowerPoint و OpenDocument را با Aspose.Slides برای Java ساده کنید، عملکرد را بهینه‌سازی کنید و جریان کاری خود را خودکار کنید."
---
## **مقدمه**

تصاویر ارائه‌ها را جذاب‌تر و جالب‌تر می‌کنند. در Microsoft PowerPoint می‌توانید عکس‌ها را از یک فایل، اینترنت یا مکان‌های دیگر به اسلایدها اضافه کنید. به طور مشابه Aspose.Slides به شما اجازه می‌دهد تصاویر را به اسلایدهای ارائه‌تان از طریق روش‌های مختلف اضافه کنید.

{{% alert title="نکته" color="primary" %}} 
Aspose مبدل‌های رایگانی ارائه می‌دهد—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به افراد امکان می‌دهد به سرعت از تصاویر ارائه‌ها را ایجاد کنند. 
{{% /alert %}} 

{{% alert title="اطلاعات" color="info" %}}
اگر می‌خواهید تصویری را به عنوان یک شیء قاب اضافه کنید—به‌ویژه اگر قصد دارید از گزینه‌های قالب‌بندی استاندارد برای تغییر اندازه، افزودن اثرات و غیره استفاده کنید—به [قاب تصویر](https://docs.aspose.com/slides/fa/java/picture-frame/) مراجعه کنید. 
{{% /alert %}} 

{{% alert title="نکته" color="warning" %}}
می‌توانید عملیات ورودی/خروجی مرتبط با تصاویر و ارائه‌های PowerPoint را برای تبدیل یک تصویر از یک قالب به قالب دیگر دستکاری کنید. این صفحات را ببینید: تبدیل [image به JPG](https://products.aspose.com/slides/fa/java/conversion/image-to-jpg/)؛ تبدیل [JPG به image](https://products.aspose.com/slides/fa/java/conversion/jpg-to-image/)؛ تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/java/conversion/jpg-to-png/)، تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/java/conversion/png-to-jpg/)؛ تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/java/conversion/png-to-svg/)، تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides از عملیات با تصاویر در این قالب‌های محبوب پشتیبانی می‌کند: JPEG، PNG، GIF و سایرین. 

## **اضافه کردن تصاویر ذخیره شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر موجود در کامپیوتر خود را به یک اسلاید در ارائه اضافه کنید. این کد نمونه در Java نشان می‌دهد چگونه یک تصویر را به اسلاید اضافه کنید:
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

## **اضافه کردن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید بر روی کامپیوتر شما موجود نیست، می‌توانید تصویر را مستقیماً از وب اضافه کنید. 

این کد نمونه نشان می‌دهد چگونه یک تصویر را از وب به اسلاید در Java اضافه کنید:
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

## **اضافه کردن تصاویر به اسلاید مسترها**

اسلاید مستر بالاترین اسلاید است که اطلاعات (تم، قالب و غیره) درباره تمام اسلایدهای زیرین را ذخیره و کنترل می‌کند. بنابراین وقتی تصویری را به اسلاید مستر اضافه می‌کنید، آن تصویر در هر اسلاید زیر آن مستر ظاهر می‌شود. 

این کد نمونه Java نشان می‌دهد چگونه یک تصویر را به اسلاید مستر اضافه کنید:
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

## **اضافه کردن تصاویر به‌عنوان پس‌زمینه اسلایدها**

ممکن است تصمیم بگیرید از یک تصویر به‌عنوان پس‌زمینه برای یک اسلاید خاص یا چند اسلاید استفاده کنید. در این حالت باید *[تنظیم تصاویر به‌عنوان پس‌زمینه برای اسلایدها](https://docs.aspose.com/slides/fa/java/presentation-background/#setting-images-as-background-for-slides)* را ببینید.

## **اضافه کردن SVG به ارائه‌ها**
می‌توانید هر تصویری را با استفاده از متد [addPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) که متعلق به رابط [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) است، به یک ارائه اضافه یا وارد کنید.

برای ایجاد یک شیء تصویر بر پایه تصویر SVG می‌توانید به این شکل عمل کنید:

1. ایجاد شیء SvgImage برای افزودن به ImageShapeCollection  
2. ایجاد شیء PPImage از ISvgImage  
3. ایجاد شیء PictureFrame با استفاده از رابط IPPImage  

این کد نمونه نشان می‌دهد چگونه مراحل بالا را برای افزودن یک تصویر SVG به یک ارائه پیاده‌سازی کنید:
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

## **تبدیل SVG به مجموعه‌ای از اشکال**
تبدیل SVG به مجموعه‌ای از اشکال در Aspose.Slides شبیه به عملکرد PowerPoint است که برای کار با تصاویر SVG استفاده می‌شود:

![PowerPoint Popup Menu](img_01_01.png)

این عملکرد توسط یکی از overloadهای متد [addGroupShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) رابط [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) که شیء [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISvgImage) را به‌عنوان اولین آرگومان می‌گیرد، فراهم می‌شود.

این کد نمونه نشان می‌دهد چگونه از متد توصیف‌شده برای تبدیل یک فایل SVG به مجموعه‌ای از اشکال استفاده کنید:
```java 
// ایجاد یک ارائه جدید
IPresentation presentation = new Presentation();
try {
    // خواندن محتوای فایل SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // ایجاد شیء SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // دریافت اندازه اسلاید
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // تبدیل تصویر SVG به گروهی از اشکال و مقیاس دادن آن به اندازه اسلاید
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // ذخیره ارائه در قالب PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **اضافه کردن تصاویر به‌صورت EMF به اسلایدها**
Aspose.Slides برای Java به شما امکان می‌دهد تصاویر EMF را از شیت‌های Excel تولید کنید و این تصاویر را به‌صورت EMF در اسلایدها با Aspose.Cells اضافه کنید.  

این کد نمونه نشان می‌دهد چگونه کار توصیف‌شده را انجام دهید:
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
Aspose.Slides به شما اجازه می‌دهد تصاویر ذخیره‌شده در مجموعه تصاویر یک ارائه (از جمله آن‌هایی که توسط اشکال اسلاید استفاده می‌شوند) را جایگزین کنید. این بخش چندین روش برای به‌روزرسانی تصاویر در مجموعه را نشان می‌دهد. API روش‌های ساده‌ای برای جایگزینی یک تصویر با استفاده از داده‌های بایتی خام، یک نمونه [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) یا تصویر دیگری که قبلاً در مجموعه وجود دارد، فراهم می‌کند.

مراحل زیر را دنبال کنید:

1. فایل ارائه حاوی تصاویر را با کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید.  
2. تصویر جدید را از یک فایل به یک آرایه بایت بارگذاری کنید.  
3. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.  
4. در روش دوم، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) تبدیل کنید و تصویر هدف را با آن شیء جایگزین کنید.  
5. در روش سوم، تصویر هدف را با تصویری که قبلاً در مجموعه تصاویر ارائه وجود دارد، جایگزین کنید.  
6. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation("sample.pptx");
try {
    // روش اول.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
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

{{% alert title="اطلاعات" color="info" %}}
با استفاده از مبدل رایگان Aspose [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) می‌توانید به‌راحتی متن‌ها را انیمیشن دهید، GIFهایی از متن‌ها ایجاد کنید و غیره. 
{{% /alert %}}

## **FAQ**

**آیا وضوح اصلی تصویر پس از درج حفظ می‌شود؟**  
بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی بستگی به این دارد که [picture](/slides/fa/java/picture-frame/) چگونه در اسلاید مقیاس‌بندی شود و آیا فشرده‌سازی هنگام ذخیره اعمال شده باشد یا نه.

**بهترین روش برای جایگزینی یک لوگو به‌صورت همزمان در ده‌ها اسلاید چیست؟**  
لوگو را بر روی اسلاید مستر یا یک قالب قرار دهید و آن را در مجموعه تصاویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از آن منبع استفاده می‌کنند، منتقل می‌شود.

**آیا می‌توان یک SVG درج‌شده را به اشکال قابل ویرایش تبدیل کرد؟**  
بله. می‌توانید SVG را به یک گروه از اشکال تبدیل کنید، پس از آن بخش‌های جداگانه با خصوصیات استاندارد اشکال قابل ویرایش می‌شوند.

**چگونه می‌توان یک تصویر را به‌عنوان پس‌زمینه برای چند اسلاید همزمان تنظیم کرد؟**  
[تصویر را به‌عنوان پس‌زمینه](/slides/fa/java/presentation-background/) در اسلاید مستر یا قالب مربوطه اختصاص دهید—هر اسلایدی که از آن مستر/قالب استفاده می‌کند، پس‌زمینه را ارث‌بری می‌کند.

**چگونه می‌توان از افزایش حجم ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کرد؟**  
به‌جای استفاده از تصویرهای تکراری، یک منبع تصویر واحد را مجدداً استفاده کنید، وضوح‌های معقول انتخاب کنید، هنگام ذخیره فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر قرار دهید که مناسب است.