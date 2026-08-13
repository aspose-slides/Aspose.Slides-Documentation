---
title: API عمومی و تغییرات ناسازگار بازگشتی در Aspose.Slides برای Java 14.7.0
linktitle: Aspose.Slides برای Java 14.7.0
type: docs
weight: 60
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای Java را بررسی کنید تا به‌صورت روان‌تری راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را منتقل کنید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره [اضافه‌شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/) را فهرست می‌کند، هر محدودیت جدید و سایر تغییرات معرفی‌شده با API Aspose.Slides for Java 14.7.0.
{{% /alert %}} 
## **تغییرات API عمومی**
### **سازنده‌های برخی از زیردسته‌های TransitionValueBase حذف شده‌اند و TransitionValueFactory نیز حذف شده است**
سازنده‌های برخی از زیردسته‌های TransitionValueBase (به‌ویژه CornerDirectionTransition، EightDirectionTransition، EmptyTransition، InOutTransition، OptionalBlackTransition، OrientationTransition، SideDirectionTransition، SplitTransition و WheelTransition) در API عمومی بی‌استفاده هستند و بنابراین حذف شدند. کلاس مربوطه TransitionValueFactory و رابط ITransitionValueFactory به همان دلیل حذف شدند.
### **عنصر SoundAction از شمارش com.aspose.slides.TransitionType حذف شده است**
عنصر SoundAction نادرست بود و استفاده نمی‌شد. تنظیمات صدا توسط ویژگی‌های SlideShowTransition.SoundMode، .Sound، .SoundLoop، .SoundIsBuiltIn، .SoundName تعریف می‌شوند.
### **کلاس FlyThroughTransition و رابط IFlyThroughTransition اضافه شده‌اند**
کلاس com.aspose.slides.FlyThroughTransition (و رابط آن com.aspose.slides.IFlyThroughTransition) به نوع گذار Flythrough مربوط می‌شود که در این نسخه پشتیبانی می‌شود.
### **کلاس GlitterTransition، رابط IGlitterTransition و شمارش TransitionPattern اضافه شده‌اند**
کلاس com.aspose.slides.GlitterTransition (و رابط آن com.aspose.slides.IGlitterTransition) به نوع گذار Glitter مربوط می‌شود که در این نسخه پشتیبانی می‌شود. شمارش com.aspose.slides.TransitionPattern در این کلاس استفاده می‌شود و یک الگوی هندسی را مشخص می‌کند که برای پر کردن یک ناحیه بزرگتر تداوم می‌یابد.
### **کلاس LeftRightDirectionTransition، رابط ILeftRightDirectionTransition و شمارش TransitionLeftRightDirectionType اضافه شده‌اند**
کلاس com.aspose.slides.LeftRightDirectionTransition (و رابط آن com.aspose.slides.ILeftRightDirectionTransition) به نوع گذارهای Switch، Flip، Ferris، Gallery و Conveyor مربوط می‌شود که در این نسخه پشتیبانی می‌شوند. شمارش com.aspose.slides.TransitionLeftRightDirectionType در این کلاس استفاده می‌شود و جهت را به مقادیر left و right محدود می‌کند.
### **عناصر جدیدی به شمارش com.aspose.slides.TransitionType اضافه شده‌اند**
شمارش com.aspose.slides.TransitionType با عناصر جدید گسترش یافته است.
عناصر جدید مربوط به گذارهای جدید PowerPoint 2010: Vortex، Switch، Flip، Ripple، Honeycomb، Cube، Box، Rotate، Orbit، Doors، Window، Ferris، Gallery، Conveyor، Pan، Glitter، Warp، Flythrough، Flash، Shred، Reveal، WheelReverse.
عناصر جدید مربوط به گذارهای جدید PowerPoint 2013: FallOver، Drape، Curtains، Wind، Prestige، Fracture، Crush، PeelOff، PageCurlDouble، PageCurlSingle، Airplane، Origami.
### **کلاس RevealTransition و رابط IRevealTransition اضافه شده‌اند**
کلاس com.aspose.slides.RevealTransition (و رابط آن com.aspose.slides.IRevealTransition) به نوع گذار Reveal مربوط می‌شود که در این نسخه پشتیبانی می‌شود.
کلاس RippleTransition، رابط IRippleTransition و شمارش TransitionCornerAndCenterDirectionType اضافه شده‌اند
کلاس com.aspose.slides.RippleTransition (و رابط آن com.aspose.slides.IRippleTransition) به نوع گذار Ripple مربوط می‌شود که در این نسخه پشتیبانی می‌شود. شمارش com.aspose.slides.TransitionCornerAndCenterDirectionType در این کلاس استفاده می‌شود و جهت را به گوشه‌ها و مرکز محدود می‌کند.
### **کلاس ShredTransition، رابط IShredTransition و شمارش TransitionShredPattern اضافه شده‌اند**
کلاس com.aspose.slides.ShredTransition (و رابط آن com.aspose.slides.IShredTransition) به نوع گذار Shred مربوط می‌شود که در این نسخه پشتیبانی می‌شود. شمارش com.aspose.slides.TransitionShredPattern در این کلاس استفاده می‌شود و یک شکل هندسی را مشخص می‌کند که برای پر کردن یک ناحیه بزرگتر تداوم می‌یابد.