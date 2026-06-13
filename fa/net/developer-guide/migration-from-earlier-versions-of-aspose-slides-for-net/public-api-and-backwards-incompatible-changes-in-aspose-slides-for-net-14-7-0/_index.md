---
title: API عمومی و تغییرات ناسازگار با نسخه قبلی در Aspose.Slides برای .NET 14.7.0
linktitle: Aspose.Slides برای .NET 14.7.0
type: docs
weight: 90
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- انتقال
- کد قدیمی
- کد مدرن
- روش قدیمی
- روش مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات خراب‌کننده در Aspose.Slides برای .NET را مرور کنید تا به‌طور روان راه‌حل‌های ارائه PowerPoint PPT، PPTX و ODP خود را انتقال دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، خصوصیات و موارد مشابه که [اضافه شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) یا [حذف شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) هستند، و سایر تغییرات معرفی شده با Aspose.Slides for .NET 14.7.0 API را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
### **سازنده‌ها و عناصر حذف شده**
#### **حذف برخی سازنده‌های زیرنوع‌های TransitionValueBase و TransitionValueFactory**
سازنده‌های برخی زیرنوع‌های TransitionValueBase (به‌خصوص CornerDirectionTransition، EightDirectionTransition، EmptyTransition، InOutTransition، OptionalBlackTransition، OrientationTransition، SideDirectionTransition، SplitTransition، WheelTransition) در API عمومی بی‌استفاده بوده و بنابراین حذف شدند. 

کلاس مرتبط TransitionValueFactory و رابط ITransitionValueFactory آن به همان دلیل حذف شدند.  
#### **حذف عنصر SoundAction از شمارش Aspose.Slides.SlideShow.TransitionType**
عنصر SoundAction نادرست بود و استفاده نمی‌شد. تنظیمات صدا توسط خصوصیات SlideShowTransition.SoundMode، .Sound، .SoundLoop، .SoundIsBuiltIn، .SoundName تعریف می‌شوند.  
### **کلاس‌ها و رابط‌های اضافه شده**
#### **اضافه شدن کلاس FlyThroughTransition و رابط IFlyThroughTransition**
کلاس Aspose.Slides.SlideShow.FlyThroughTransition (و رابط Aspose.Slides.SlideShow.IFlyThroughTransition) مربوط به نوع انتقال Flythrough است که از این نسخه پشتیبانی می‌شود.  
#### **اضافه شدن کلاس GlitterTransition، رابط IGlitterTransition و شمارش TransitionPattern**
کلاس Aspose.Slides.SlideShow.GlitterTransition (و رابط Aspose.Slides.SlideShow.IGlitterTransition) مربوط به نوع انتقال Glitter است که از این نسخه پشتیبانی می‌شود.  

شمارش Aspose.Slides.SlideShow.TransitionPattern در این کلاس استفاده می‌شود و یک الگوی هندسی را که به‌صورت موزاییکی برای پوشاندن ناحیه بزرگتر ترکیب می‌شود، مشخص می‌کند.  
#### **اضافه شدن کلاس LeftRightDirectionTransition، رابط ILeftRightDirectionTransition و شمارش TransitionLeftRightDirectionType**
کلاس Aspose.Slides.SlideShow.LeftRightDirectionTransition (و رابط Aspose.Slides.SlideShow.ILeftRightDirectionTransition) مربوط به انواع انتقال Conveyor، Ferris، Flip، Gallery و Switch است. همه این‌ها از این نسخه پشتیبانی می‌شوند.  

شمارش Aspose.Slides.SlideShow.TransitionLeftRightDirectionType در این کلاس استفاده می‌شود و جهت‌گیری را مشخص می‌کند که به مقادیر left و right محدود است.  
#### **اضافه شدن عناصر جدید به شمارش Aspose.Slides.SlideShow.TransitionType**
شمارش Aspose.Slides.SlideShow.TransitionType با عناصر جدید گسترش یافته است.

- عناصر جدید مرتبط با انتقال‌های PowerPoint 2010: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.  
- عناصر جدید مرتبط با انتقال‌های PowerPoint 2013: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.  
#### **اضافه شدن کلاس RevealTransition و رابط IRevealTransition**
کلاس Aspose.Slides.SlideShow.RevealTransition (و رابط Aspose.Slides.SlideShow.IRevealTransition) مربوط به نوع انتقال Reveal است که از این نسخه پشتیبانی می‌شود.  
#### **اضافه شدن کلاس RippleTransition، رابط IRippleTransition و شمارش TransitionCornerAndCenterDirectionType**
کلاس Aspose.Slides.SlideShow.RippleTransition (و رابط Aspose.Slides.SlideShow.IRippleTransition) مربوط به نوع انتقال Ripple است که از این نسخه پشتیبانی می‌شود.  

شمارش Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType در این کلاس استفاده می‌شود و جهت‌گیری را مشخص می‌کند که به گوشه‌ها و مرکز محدود است.