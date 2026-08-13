---
title: "API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای .NET 14.7.0"
linktitle: "Aspose.Slides برای .NET 14.7.0"
type: docs
weight: 90
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- "مهاجرت"
- "کد میراثی"
- "کد مدرن"
- "رویکرد میراثی"
- "رویکرد مدرن"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته در Aspose.Slides برای .NET را بررسی کنید تا بتوانید به‌صورت روان راه‌حل‌های ارائه PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابه که [added](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) یا [removed](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) شده‌اند و سایر تغییرات معرفی‌شده در API Aspose.Slides برای .NET نسخه 14.7.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
### **سازنده‌ها و عناصر حذف‌شده**
#### **حذف برخی سازنده‌های زیرنوع‌های TransitionValueBase و TransitionValueFactory**
سازنده‌های برخی زیرنوع‌های TransitionValueBase (به‌طور خاص CornerDirectionTransition، EightDirectionTransition، EmptyTransition، InOutTransition، OptionalBlackTransition، OrientationTransition، SideDirectionTransition، SplitTransition، WheelTransition) در API عمومی کاربردی ندارند و به همین دلیل حذف شدند. 

کلاس مرتبط TransitionValueFactory و رابط ITransitionValueFactory آن نیز به همان دلیل حذف شده‌اند. 
#### **حذف عنصر SoundAction از Enumeration Aspose.Slides.SlideShow.TransitionType**
عنصر SoundAction نادرست بود و استفاده نمی‌شد. تنظیمات صدا توسط ویژگی‌های SlideShowTransition.SoundMode، .Sound، .SoundLoop، .SoundIsBuiltIn و .SoundName تعریف می‌شوند. 
### **کلاس‌ها و رابط‌های اضافه‌شده**
#### **اضافه شدن کلاس FlyThroughTransition و رابط IFlyThroughTransition**
کلاس Aspose.Slides.SlideShow.FlyThroughTransition (و رابط Aspose.Slides.SlideShow.IFlyThroughTransition) به نوع انتقال Flythrough که از این نسخه پشتیبانی می‌شود، مرتبط است. 
#### **اضافه شدن کلاس GlitterTransition، رابط IGlitterTransition و Enumeration TransitionPattern**
کلاس Aspose.Slides.SlideShow.GlitterTransition (و رابط Aspose.Slides.SlideShow.IGlitterTransition) به نوع انتقال Glitter که از این نسخه پشتیبانی می‌شود، مرتبط است. 

Enumeration Aspose.Slides.SlideShow.TransitionPattern در این کلاس استفاده می‌شود و یک الگوی هندسی را مشخص می‌کند که به‌صورت موزاییکی برای پر کردن یک ناحیه بزرگتر ترکیب می‌شوند. 
#### **اضافه شدن کلاس LeftRightDirectionTransition، رابط ILeftRightDirectionTransition و Enumeration TransitionLeftRightDirectionType**
کلاس Aspose.Slides.SlideShow.LeftRightDirectionTransition (و رابط Aspose.Slides.SlideShow.ILeftRightDirectionTransition) به انواع انتقال Conveyor، Ferris، Flip، Gallery و Switch مربوط می‌شود. تمام این‌ها از این نسخه پشتیبانی می‌شوند. 

Enumeration Aspose.Slides.SlideShow.TransitionLeftRightDirectionType در این کلاس استفاده می‌شود و جهت را مشخص می‌کند، که به مقادیر left و right محدود می‌شود. 
#### **اضافه شدن عناصر جدید به Enumeration Aspose.Slides.SlideShow.TransitionType**
Enumeration Aspose.Slides.SlideShow.TransitionType با عناصر جدید گسترش یافته است. 

- عناصر جدید مرتبط با انتقال‌های PowerPoint 2010: Box، Conveyor، Cube، Doors، Ferris، Flash، Flip، Flythrough، Gallery، Glitter، Honeycomb، Orbit، Pan، Reveal، Ripple، Rotate، Shred، Switch، Vortex، Warp، WheelReverse، Window. 
- عناصر جدید مرتبط با انتقال‌های جدید PowerPoint 2013: Airplane، Crush، Curtains، Drape، FallOver، Fracture، Origami، PageCurlDouble، PageCurlSingle، PeelOff، Prestige، Wind. 
#### **اضافه شدن کلاس RevealTransition و رابط IRevealTransition**
کلاس Aspose.Slides.SlideShow.RevealTransition (و رابط Aspose.Slides.SlideShow.IRevealTransition) به نوع انتقال Reveal که از این نسخه پشتیبانی می‌شود، مربوط است. 
#### **اضافه شدن کلاس RippleTransition، رابط IRippleTransition و Enumeration TransitionCornerAndCenterDirectionType**
کلاس Aspose.Slides.SlideShow.RippleTransition (و رابط Aspose.Slides.SlideShow.IRippleTransition) به نوع انتقال Ripple که از این نسخه پشتیبانی می‌شود، مرتبط است. 

Enumeration Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType در این کلاس استفاده می‌شود و جهت را مشخص می‌کند، که به گوشه‌ها و مرکز محدود می‌شود.