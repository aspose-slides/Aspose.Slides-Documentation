---
title: ترکیب اسلایدها
type: docs
weight: 10
url: /fa/net/assemble-slides/
---
## **افزودن اسلاید به یک ارائه**
قبل از بحث درباره افزودن اسلایدها به فایل‌های ارائه، اجازه دهید برخی از حقایق درباره اسلایدها را بررسی کنیم. هر فایل ارائه PowerPoint شامل اسلایدهای Master / Layout و سایر اسلایدهای Normal است. این به این معنی است که یک فایل ارائه حداقل یک اسلاید یا بیشتر دارد. مهم است بدانید که فایل‌های ارائه بدون اسلاید توسط Aspose.Slides for .NET پشتیبانی نمی‌شوند. هر اسلاید دارای Id منحصر به فرد است و تمام اسلایدهای Normal به ترتیبی که توسط اندیس صفر مبنا تعیین می‌شود، مرتب می‌شوند.

Aspose.Slides for .NET به توسعه‌دهندگان اجازه می‌دهد اسلایدهای خالی را به ارائه خود اضافه کنند. برای افزودن یک اسلاید خالی به ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس **Presentation** ایجاد کنید
- کلاس **SlideCollection** را با تنظیم یک مرجع به ویژگی Slides (مجموعه‌ای از اشیاء Slide محتوا) که توسط شی Presentation منتشر می‌شود، نمونه‌سازی کنید
- یک اسلاید خالی را به انتهای مجموعه اسلایدهای محتوا در ارائه اضافه کنید با فراخوانی متدهای **AddEmptySlide** که توسط شی **SlideCollection** ارائه می‌شوند
- کاری با اسلاید خالی که به تازگی اضافه شده انجام دهید
- در نهایت، فایل ارائه را با استفاده از شی **Presentation** بنویسید

``` csharp

 PresentationEx pres = new PresentationEx;

//ایجاد یک نمونه از کلاس SlideCollection
SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//یک اسلاید خالی به مجموعه Slides اضافه کنید
	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//فایل PPTX را روی دیسک ذخیره کنید
pres.Write("EmptySlide.pptx");

``` 
## **دسترسی به اسلایدهای یک ارائه**
Aspose.Slides for .NET کلاس Presentation را فراهم می‌کند که می‌توان از آن برای پیدا کردن و دسترسی به هر اسلاید دلخواه موجود در ارائه استفاده کرد.

**استفاده از مجموعه اسلایدها**

کلاس **Presentation** نماینده یک فایل ارائه است و تمام اسلایدهای آن را به عنوان یک مجموعه **SlideCollection** (که مجموعه‌ای از اشیاء **Slide** است) در دسترس قرار می‌دهد. تمام این اسلایدها می‌توانند از این مجموعه **Slides** با استفاده از یک اندیس اسلاید دسترسی پیدا کنند.

``` csharp

 //یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//دسترسی به یک اسلاید با استفاده از اندیس اسلاید آن
SlideEx slide = pres.Slides[0];

``` 
## **حذف اسلایدها**
ما می‌دانیم که کلاس Presentation در **Aspose.Slides for .NET** نماینده یک فایل ارائه است. کلاس Presentation یک **SlideCollection** را در خود دارد که به عنوان مخزن تمام اسلایدهای جزئی از ارائه عمل می‌کند. توسعه‌دهندگان می‌توانند یک اسلاید را از این مجموعه Slides به دو روش حذف کنند:

- استفاده از مرجع اسلاید
- استفاده از اندیس اسلاید

**استفاده از مرجع اسلاید**

برای حذف یک اسلاید با استفاده از مرجع آن، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- مرجع یک اسلاید را با استفاده از Id یا Index آن به دست آورید
- اسلاید مرجع‌شده را از ارائه حذف کنید
- فایل ارائه اصلاح‌شده را بنویسید

``` csharp

 //یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//دسترسی به یک اسلاید با استفاده از اندیس آن در مجموعه اسلایدها
SlideEx slide = pres.Slides[0];

//حذف یک اسلاید با استفاده از مرجع آن
pres.Slides.Remove(slide);

//نوشتن فایل ارائه
pres.Write("modified.pptx");

``` 
## **تغییر موقعیت یک اسلاید**
تغییر موقعیت یک اسلاید در ارائه بسیار ساده است. کافی است مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- مرجع یک اسلاید را با استفاده از Index آن به دست آورید
- شماره SlideNumber اسلاید مرجع‌شده را تغییر دهید
- 파일 ارائه اصلاح‌شده را بنویسید

در مثال زیر، موقعیت یک اسلاید (که در موقعیت صفر ایندکس 1 قرار داشت) از ارائه را به ایندکس 1 (موقعیت 2) تغییر دادیم.

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//ایجاد یک نمونه از کلاس SlideCollection
ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //یک اسلاید خالی به مجموعه Slides اضافه کنید
    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//فایل PPTX را بر روی دیسک ذخیره کنید
pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه باشد
Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//دسترسی به اسلاید با استفاده از اندیس اسلاید آن
ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه باشد
Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//دسترسی به اسلاید با استفاده از اندیس آن در مجموعه اسلایدها
ISlide slide = pres.Slides[0];

//حذف یک اسلاید با استفاده از مرجع آن
pres.Slides.Remove(slide);

//نوشتن فایل ارائه
pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//کلاس Presentation را برای بارگذاری فایل ارائه منبع نمونه‌سازی کنید
Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //دریافت اسلایدی که موقعیت آن باید تغییر کند
    ISlide sld = pres.Slides[0];
    //تنظیم موقعیت جدید برای اسلاید
    sld.SlideNumber = 2;
    //نوشتن ارائه بر روی دیسک
    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **بارگیری کد نمونه**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [بیت‌باکت](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)