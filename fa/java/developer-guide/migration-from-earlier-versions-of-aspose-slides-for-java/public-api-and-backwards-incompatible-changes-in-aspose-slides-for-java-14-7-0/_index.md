---
title: تغییرات عمومی API و ناسازگاری‌های عقب‌گرد در Aspose.Slides for Java 14.7.0
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides for Java را مرور کنید تا بتوانید راه‌حل‌های ارائه PowerPoint PPT، PPTX و ODP خود را به‌صورت روان مهاجرت کنید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیرهٔ اضافه‌شده، هر محدودیت جدید و سایر تغییرات معرفی‌شده با API Aspose.Slides for Java 14.7.0 را فهرست می‌کند.

{{% /alert %}} 
## **Public API Changes**
### **Constructors of the some TransitionValueBase subtypes have been removed and TransitionValueFactory has been removed**
سازنده‌های برخی از زیرنوع‌های TransitionValueBase (و به‌ویژه CornerDirectionTransition، EightDirectionTransition، EmptyTransition، InOutTransition، OptionalBlackTransition، OrientationTransition، SideDirectionTransition، SplitTransition، WheelTransition) در API عمومی بی‌استفاده بوده و بنابراین حذف شدند. کلاس مرتبط TransitionValueFactory و اینترفیس ITransitionValueFactory نیز به همان دلیل حذف شدند.
### **Element SoundAction has been removed from com.aspose.slides.TransitionType enumeration**
عنصر SoundAction نادرست بود و استفاده نمی‌شد. تنظیمات صدا توسط ویژگی‌های SlideShowTransition.SoundMode، .Sound، .SoundLoop، .SoundIsBuiltIn، .SoundName تعریف می‌شوند.
### **FlyThroughTransition class and IFlyThroughTransition interface have been added**
کلاس com.aspose.slides.FlyThroughTransition (و اینترفیس com.aspose.slides.IFlyThroughTransition) مربوط به نوع انتقال Flythrough است که در این نسخه پشتیبانی می‌شود.
### **GlitterTransition class, IGlitterTransition interface and TransitionPattern enumeration have been added**
کلاس com.aspose.slides.GlitterTransition (و اینترفیس com.aspose.slides.IGlitterTransition) مربوط به نوع انتقال Glitter است که در این نسخه پشتیبانی می‌شود. 
enumeration com.aspose.slides.TransitionPattern در این کلاس استفاده می‌شود و الگوی هندسی‌ای را که برای پر کردن یک ناحیه بزرگتر کنار هم قرار می‌گیرند، مشخص می‌کند.
### **LeftRightDirectionTransition class, ILeftRightDirectionTransition interface and TransitionLeftRightDirectionType enumeration have been added**
کلاس com.aspose.slides.LeftRightDirectionTransition (و اینترفیس com.aspose.slides.ILeftRightDirectionTransition) مربوط به انواع انتقال Switch، Flip، Ferris، Gallery، Conveyor است که در این نسخه پشتیبانی می‌شوند. 
enumeration com.aspose.slides.TransitionLeftRightDirectionType در این کلاس استفاده می‌شود و جهت را به مقادیر left و right محدود می‌کند.
### **New elements have been added into com.aspose.slides.TransitionType enumeration**
enumeration com.aspose.slides.TransitionType با عناصر جدید گسترش یافته است.  
عناصر جدید مرتبط با انتقال‌های PowerPoint 2010: Vortex، Switch، Flip، Ripple، Honeycomb، Cube، Box، Rotate، Orbit، Doors، Window، Ferris، Gallery، Conveyor، Pan، Glitter، Warp، Flythrough، Flash، Shred، Reveal، WheelReverse.  
عناصر جدید مرتبط با انتقال‌های PowerPoint 2013: FallOver، Drape، Curtains، Wind، Prestige، Fracture، Crush، PeelOff، PageCurlDouble، PageCurlSingle، Airplane، Origami.
### **RevealTransition class and IRevealTransition interface have been added**
کلاس com.aspose.slides.RevealTransition (و اینترفیس com.aspose.slides.IRevealTransition) مربوط به نوع انتقال Reveal است که در این نسخه پشتیبانی می‌شود.  
کلاس RippleTransition، IRippleTransition و enumeration TransitionCornerAndCenterDirectionType اضافه شده‌اند.  
کلاس com.aspose.slides.RippleTransition (و اینترفیس com.aspose.slides.IRippleTransition) مربوط به نوع انتقال Ripple است که در این نسخه پشتیبانی می‌شود.  
enumeration com.aspose.slides.TransitionCornerAndCenterDirectionType در این کلاس استفاده می‌شود و جهت را به گوشه‌ها و مرکز محدود می‌کند.
### **ShredTransition class, IShredTransition interface and TransitionShredPattern enumeration have been added**
کلاس com.aspose.slides.ShredTransition (و اینترفیس com.aspose.slides.IShredTransition) مربوط به نوع انتقال Shred است که در این نسخه پشتیبانی می‌شود.  
enumeration com.aspose.slides.TransitionShredPattern در این کلاس استفاده می‌شود و شکل هندسی‌ای را که برای پر کردن یک ناحیه بزرگتر کنار هم قرار می‌گیرد، مشخص می‌کند.