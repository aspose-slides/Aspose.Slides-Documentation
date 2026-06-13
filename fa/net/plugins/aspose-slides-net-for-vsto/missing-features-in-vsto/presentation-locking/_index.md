---
title: قفل‌گذاری ارائه
type: docs
weight: 110
url: /fa/net/presentation-locking/
---
## **قفل‌گذاری ارائه**
یک استفاده رایج از **Aspose.Slides** ایجاد، به‌روزرسانی و ذخیرهٔ ارائه‌های Microsoft PowerPoint 2007 (PPTX) به عنوان بخشی از یک جریان کاری خودکار است. کاربران برنامه‌ای که این‌گونه از Aspose.Slides استفاده می‌کند به ارائه‌های خروجی دسترسی پیدا می‌کنند. حفاظت از ویرایش آن‌ها یک نگرانی رایج است. مهم است که ارائه‌های خودکارساخت حفظ قالب‌بندی و محتوای اصلی خود را داشته باشند.

این مطلب توضیح می‌دهد که چگونه ارائه‌ها و اسلایدها ساخته می‌شوند و چگونه Aspose.Slides for .NET می‌تواند حفاظت را بر یک ارائه اعمال کرده و سپس آن را حذف کند. این ویژگی منحصراً به Aspose.Slides اختصاص دارد و در زمان نگارش این متن در Microsoft PowerPoint موجود نیست. این امکان را به توسعه‌دهندگان می‌دهد تا نحوهٔ استفاده از ارائه‌های ساخته‌شده توسط برنامه‌های خود را کنترل کنند.
## **ترکیب یک اسلاید**
یک اسلاید PPTX از مجموعه‌ای از مؤلفه‌ها مانند اشکال خودکار، جدول‌ها، اشیای OLE، اشکال گروهی، فریم‌های تصویر، فریم‌های ویدئو، اتصال‌دهنده‌ها و سایر عناصر موجود برای ساخت یک ارائه تشکیل شده است.

در Aspose.Slides for .NET، هر عنصر بر روی اسلاید به یک شیء Shape تبدیل می‌شود. به عبارت دیگر، هر عنصر بر روی اسلاید یا یک شیء Shape است یا شیئی که از شیء Shape ارث‌بری می‌کند.

ساختار PPTX پیچیده است، بنابراین برخلاف PPT که در آن می‌توان یک قفل کلی برای تمام انواع اشکال استفاده کرد، برای انواع مختلف اشکال قفل‌های متفاوتی وجود دارد. کلاس BaseShapeLock کلاس قفل‌گذاری کلی برای PPTX است. انواع قفل‌های زیر در Aspose.Slides for .NET برای PPTX پشتیبانی می‌شوند.

- AutoShapeLock اشکال خودکار را قفل می‌کند.
- ConnectorLock اشکال متصل‌کننده را قفل می‌کند.
- GraphicalObjectLock اشیای گرافیکی را قفل می‌کند.
- GroupshapeLock اشکال گروهی را قفل می‌کند.
- PictureFrameLock فریم‌های تصویر را قفل می‌کند.

هر اقدام انجام‌شده بر روی تمام اشیاء Shape در یک شیء Presentation بر کل ارائه اعمال می‌شود.
## **اعمال و حذف محافظت**
اعمال محافظت اطمینان می‌دهد که یک ارائه قابل ویرایش نیست. این تکنیکی مفید برای حفاظت از محتوای یک ارائه است.

**اعمال محافظت بر اشکال PPTX**
Aspose.Slides for .NET کلاس Shape را برای کار با یک شکل در اسلاید فراهم می‌کند.

همان‌طور که در بخش قبل اشاره شد، هر کلاس شکل دارای یک کلاس قفل شکل مرتبط برای محافظت است. این مقاله بر قفل‌های NoSelect، NoMove و NoResize تمرکز دارد. این قفل‌ها اطمینان می‌دهند که اشکال نمی‌توانند انتخاب شوند (از طریق کلیک ماوس یا روش‌های دیگر)، و نمی‌توانند جابه‌جا یا تغییر اندازه یابند.

نمونه‌های کد زیر محافظت را بر تمام انواع اشکال در یک ارائه اعمال می‌کنند.

``` csharp

 //نمونه‌سازی کلاس Presentation که فایل PPTX را نشان می‌دهد
PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//نمونه‌سازی کلاس Presentation که فایل PPTX را نشان می‌دهد


//شیء ISlide برای دسترسی به اسلایدهای ارائه
SlideEx slide = pTemplate.Slides[0];

//شیء IShape برای نگهداری اشکال موقت
ShapeEx shape;

//پیمایش تمام اسلایدهای ارائه
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	//پیمایش تمام اشکال در اسلایدها
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//اگر شکل یک AutoShape است
		if (shape is AutoShapeEx)
		{
			//تبدیل نوع به Auto shape و دریافت قفل Auto shape
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//اعمال قفل‌های اشکال
			AutoShapeLock.PositionLocked = true;
			AutoShapeLock.SelectLocked = true;
			AutoShapeLock.SizeLocked = true;
		}
		//اگر شکل یک Group shape است
		else if (shape is GroupShapeEx)
		{
			//تبدیل نوع به Group shape و دریافت قفل Group shape
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//اعمال قفل‌های اشکال
			groupShapeLock.GroupingLocked = true;
			groupShapeLock.PositionLocked = true;
			groupShapeLock.SelectLocked = true;
			groupShapeLock.SizeLocked = true;
		}
		//اگر شکل یک Connector است
		else if (shape is ConnectorEx)
		{
			//تبدیل نوع به Connector shape و دریافت قفل Connector shape
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//اعمال قفل‌های اشکال
			ConnLock.PositionMove = true;
			ConnLock.SelectLocked = true;
			ConnLock.SizeLocked = true;
		}
		//اگر شکل یک PictureFrame است
		else if (shape is PictureFrameEx)
		{
			//تبدیل نوع به PictureFrame shape و دریافت قفل PictureFrame shape
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//اعمال قفل‌های اشکال
			PicLock.PositionLocked = true;
			PicLock.SelectLocked = true;
			PicLock.SizeLocked = true;
		}
	}
}

//ذخیره‌سازی فایل ارائه
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 

**حذف محافظت**
محافظتی که با استفاده از Aspose.Slides for .NET اعمال شده است فقط می‌تواند با Aspose.Slides for .NET حذف شود. برای باز کردن قفل یک شکل، مقدار قفل اعمال‌شده را به false تنظیم کنید. نمونه کد زیر نشان می‌دهد چگونه اشکال در یک ارائه قفل‌دار را باز کنید.

``` csharp

 //باز کردن ارائهٔ موردنظر
PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//شیء ISlide برای دسترسی به اسلایدهای ارائه
SlideEx slide = pTemplate.Slides[0];

//شیء IShape برای نگهداری اشکال موقت
ShapeEx shape;

//پیمایش تمام اسلایدهای ارائه
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
	slide = pTemplate.Slides[slideCount];
	//پیمایش تمام اشکال در اسلایدها
	for (int count = 0; count < slide.Shapes.Count; count++)
	{
		shape = slide.Shapes[count];
		//اگر شکل یک autoshape است
		if (shape is AutoShapeEx)
		{
			//تبدیل نوع به Auto shape و دریافت قفل auto shape
			AutoShapeEx Ashp = shape as AutoShapeEx;
			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;
			//اعمال قفل‌های اشکال
			AutoShapeLock.PositionLocked = false;
			AutoShapeLock.SelectLocked = false;
			AutoShapeLock.SizeLocked = false;
		}
		//اگر شکل یک group shape است
		else if (shape is GroupShapeEx)
		{
			//تبدیل نوع به group shape و دریافت قفل group shape
			GroupShapeEx Group = shape as GroupShapeEx;
			GroupShapeLockEx groupShapeLock = Group.ShapeLock;
			//اعمال قفل‌های اشکال
			groupShapeLock.GroupingLocked = false;
			groupShapeLock.PositionLocked = false;
			groupShapeLock.SelectLocked = false;
			groupShapeLock.SizeLocked = false;
		}
		//اگر شکل یک Connector است
		else if (shape is ConnectorEx)
		{
			//تبدیل نوع به connector shape و دریافت قفل connector shape
			ConnectorEx Conn = shape as ConnectorEx;
			ConnectorLockEx ConnLock = Conn.ShapeLock;
			//اعمال قفل‌های اشکال
			ConnLock.PositionMove = false;
			ConnLock.SelectLocked = false;
			ConnLock.SizeLocked = false;
		}
		//اگر شکل یک picture frame است
		else if (shape is PictureFrameEx)
		{
			//تبدیل نوع به picture frame shape و دریافت قفل picture frame shape
			PictureFrameEx Pic = shape as PictureFrameEx;
			PictureFrameLockEx PicLock = Pic.ShapeLock;
			//اعمال قفل‌های اشکال
			PicLock.PositionLocked = false;
			PicLock.SelectLocked = false;
			PicLock.SizeLocked = false;
		}
	}
}

//ذخیره‌سازی فایل ارائه
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
``` 
## **بارگیری کد نمونه**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)