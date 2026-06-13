---
title: جلوگیری از ویرایش ارائه با قفل‌های شکل
linktitle: جلوگیری از ویرایش ارائه
type: docs
weight: 10
url: /fa/cpp/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- محافظت در برابر ویرایش
- قفل کردن شکل
- قفل موقعیت
- قفل انتخاب
- قفل اندازه
- قفل گروه‌بندی
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کشف کنید چگونه Aspose.Slides برای C++ اشکال را در فایل‌های PPT، PPTX و ODP قفل یا بازقفل می‌کند، ارائه‌ها را ایمن می‌سازد در حالی که ویرایش‌های کنترل‌شده و تحویل سریع‌تر را امکان‌پذیر می‌سازد."
---
## **پس‌زمینه**

یک استفاده رایج از Aspose.Slides ایجاد، به‌روزرسانی و ذخیرهٔ ارائه‌های Microsoft PowerPoint (PPTX) به عنوان بخشی از یک جریان کاری خودکار است. کاربران برنامه‌هایی که Aspose.Slides را به این شکل به کار می‌برند به ارائه‌های تولید شده دسترسی دارند، بنابراین محافظت از ویرایش آن‌ها یک نگرانی معمول است. مهم است که ارائه‌های به‌طور خودکار تولید شده قالب‌بندی و محتوای اولیه خود را حفظ کنند.

این مقاله توضیح می‌دهد ساختار ارائه‌ها و اسلایدها چگونه است و Aspose.Slides for C++ چگونه می‌تواند محافظت را بر روی یک ارائه اعمال کرده و سپس آن را حذف کند. این راهکار به توسعه‌دهندگان امکان می‌دهد نحوهٔ استفاده از ارائه‌هایی که برنامه‌هایشان تولید می‌کند را کنترل کنند.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزایی مانند اشکال خودکار، جدول‌ها، اشیای OLE، اشکال گروهی، فریم‌های تصویر، فریم‌های ویدئو، کانکتورها و سایر عناصر استفاده‑شده برای ساخت ارائه تشکیل شده است. در Aspose.Slides for C++، هر عنصر روی اسلاید توسط شیئی که رابط [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که از آن ارث‌برده است، نمایان می‌شود.

ساختار PPTX پیچیده است، بنابراین بر خلاف PPT که می‌توان از یک قفل عمومی برای تمام انواع اشکال استفاده کرد، انواع مختلف اشکال به قفل‌های متفاوتی نیاز دارند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseshapelock/) کلاس قفل عمومی برای PPTX است. انواع قفل‌های زیر در Aspose.Slides for C++ برای PPTX پشتیبانی می‌شوند:

- [IAutoShapeLock](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshapelock/) اشکال خودکار را قفل می‌کند.  
- [IConnectorLock](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iconnectorlock/) اشکال کانکتور را قفل می‌کند.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igraphicalobjectlock/) اشیای گرافیکی را قفل می‌کند.  
- [IGroupShapeLock](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igroupshapelock/) اشکال گروهی را قفل می‌کند.  
- [IPictureFrameLock](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframelock/) فریم‌های تصویر را قفل می‌کند.   

هر عملیاتی که بر روی تمام اشیای شکل در یک شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) انجام شود، بر کل ارائه اعمال می‌شود.

## **اعمال و حذف محافظت**

اعمال محافظت تضمین می‌کند که یک ارائه قابل ویرایش نیست. این تکنیکی مفید برای حفاظت از محتوای ارائه است.

### **اعمال محافظت بر اشکال PPTX**

Aspose.Slides for C++ رابط [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) را برای کار با اشکال روی اسلاید فراهم می‌کند.

همان‌طور که پیش‌تر اشاره شد، هر کلاس شکل یک کلاس قفل‑شکل مرتبط برای محافظت دارد. این مقاله بر قفل‌های NoSelect، NoMove و NoResize تمرکز دارد. این قفل‌ها اطمینان می‌دهند که اشکال نمی‌توانند انتخاب شوند (از طریق کلیک ماوس یا روش‌های انتخاب دیگر) و نمی‌توانند جابه‌جا یا اندازه‑شان تغییر یابد.

نمونه کد زیر محافظت را بر تمام انواع اشکال در یک ارائه اعمال می‌کند.

```cpp
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// پیمایش تمام اسلایدها در ارائه.
for (auto&& slide : presentation->get_Slides())	{

	// پیمایش تمام اشکال در اسلاید.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// تبدیل نوع شکل به یک autoshape و دریافت قفل شکل آن.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// تبدیل نوع شکل به یک group shape و دریافت قفل شکل آن.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// تبدیل نوع شکل به یک connector shape و دریافت قفل شکل آن.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// تبدیل نوع شکل به یک picture frame و دریافت قفل شکل آن.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// ذخیرهٔ فایل ارائه.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **حذف محافظت**

برای باز کردن قفل یک شکل، مقدار قفل اعمال‌شده را به `false` تنظیم کنید. نمونه کد زیر نشان می‌دهد چگونه اشکال را در یک ارائه قفل‌دار باز کنید.

```cpp
// یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// پیمایش تمام اسلایدهای موجود در ارائه.
for (auto&& slide : presentation->get_Slides())	{

	// پیمایش تمام اشکال موجود در اسلاید.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// تبدیل نوع شکل به یک autoshape و دریافت قفل شکل آن.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// تبدیل نوع شکل به یک group shape و دریافت قفل شکل آن.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// تبدیل نوع شکل به یک connector shape و دریافت قفل شکل آن.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// تبدیل نوع شکل به یک picture frame و دریافت قفل شکل آن.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// ذخیرهٔ فایل ارائه.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **نتیجه‌گیری**

Aspose.Slides گزینه‌های متعددی برای محافظت از اشکال در یک ارائه ارائه می‌دهد. می‌توانید یک شکل را به‌تنهایی قفل کنید یا به‌صورت حلقه‌ای بر تمام اشکال در یک ارائه مرور کنید و هرکدام را قفل کنید تا به‌صورت مؤثر کل فایل را امن کنید. می‌توانید با تنظیم مقدار قفل به `false` محافظت را حذف کنید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و محافظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌ها ویرایش اشیاء داخل فایل را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/cpp/password-protected-presentation/) دسترسی به باز کردن و/یا ذخیرهٔ تغییرات را کنترل می‌کند. این مکانیزم‌ها یکدیگر را تکمیل کرده و به‌صورت همزمان کار می‌کنند.

**آیا می‌توانم ویرایش را فقط بر اسلایدهای خاص محدود کنم بدون اینکه بر دیگران تأثیر بگذارد؟**

بله. قفل‌ها را بر اشکال اسلایدهای انتخاب‌شده اعمال کنید؛ اسلایدهای باقی‌مانده قابل ویرایش خواهند ماند.

**آیا قفل‌های شکل بر اشیای گروهی و کانکتورها اعمال می‌شود؟**

بله. انواع قفل اختصاصی برای گروه‌ها، کانکتورها، اشیای گرافیکی و سایر انواع اشکال پشتیبانی می‌شود.