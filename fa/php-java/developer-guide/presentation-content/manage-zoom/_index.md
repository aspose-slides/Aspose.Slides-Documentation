---
title: مدیریت زوم ارائه در PHP
linktitle: مدیریت زوم
type: docs
weight: 60
url: /fa/php-java/manage-zoom/
keywords:
- زوم
- فریم زوم
- زوم اسلاید
- زوم بخش
- زوم خلاصه
- اضافه کردن زوم
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی زوم با Aspose.Slides برای PHP از طریق Java — پرش بین بخش‌ها، افزودن تصویر بندانگشتی و انتقال‌ها در ارائه‌های PPT، PPTX و ODP."
---
## **مقدمه**

Zoomها در PowerPoint به شما اجازه می‌دهند تا به اسلایدها، بخش‌ها و قسمت‌های خاصی از یک ارائه پرش کنید و از آن‌ها بازگردید. وقتی ارائه می‌دهید، این قابلیت برای ناوبری سریع در میان محتوا می‌تواند بسیار مفید باشد. 

![overview_image](overview.png)

* برای خلاصه‌سازی کل ارائه در یک اسلاید واحد، از [Summary Zoom](#Summary-Zoom) استفاده کنید.
* برای نمایش فقط اسلایدهای انتخاب شده، از [Slide Zoom](#Slide-Zoom) استفاده کنید.
* برای نمایش فقط یک بخش، از [Section Zoom](#Section-Zoom) استفاده کنید.

## **زوم اسلاید**
یک زوم اسلاید می‌تواند ارائه شما را پویا تر کند و به شما اجازه می‌دهد تا به‌صورت آزادانه بین اسلایدها به هر ترتیبی که می‌خواهید حرکت کنید بدون اینکه جریان ارائه مختلط شود. زوم‌های اسلاید برای ارائه‌های کوتاه بدون بخش‌های متعدد عالی هستند، اما می‌توانید آن‌ها را در سناریوهای مختلف ارائه نیز به کار ببرید.

زوم‌های اسلاید به شما کمک می‌کنند تا به چندین قطعه اطلاعات عمیقاً نگاه کنید درحالی‌که حس می‌کنید بر روی یک بوم واحد هستید. 

![overview_image](slidezoomsel.png)

برای اشیای زوم اسلاید، Aspose.Slides شمارش‌گر [ZoomImageType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zoomimagetype/)، کلاس [ZoomFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zoomframe/) و برخی متدها در زیر کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) را ارائه می‌دهد.

### **ایجاد فریم‌های زوم**

می‌توانید یک فریم زوم را بر روی اسلاید به این شکل اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدیدی که می‌خواهید فریم‌های زوم به آن‌ها لینک شود، ایجاد کنید. 
3. به اسلایدهای ایجاد شده متن شناسایی و پس‌زمینه اضافه کنید.
4. فریم‌های زوم (حاوی ارجاع به اسلایدهای ایجاد شده) را به اسلاید اول اضافه کنید.
5. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک فریم زوم را بر روی اسلاید ایجاد کنید:

```php
  $pres = new Presentation();
  try {
    # اسلایدهای جدید را به ارائه اضافه می‌کند
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # پس‌زمینه‌ای برای اسلاید دوم ایجاد می‌کند
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # یک جعبه متن برای اسلاید دوم ایجاد می‌کند
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # پس‌زمینه‌ای برای اسلاید سوم ایجاد می‌کند
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # یک جعبه متن برای اسلاید سوم ایجاد می‌کند
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # اشیای ZoomFrame را اضافه می‌کند
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # ارائه را ذخیره می‌کند
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **ایجاد فریم‌های زوم با تصاویر سفارشی**
با Aspose.Slides برای PHP از طریق Java، می‌توانید فریم زومی با تصویر پیش‌نمایش اسلاید متفاوت به این شکل ایجاد کنید:
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید جدید که می‌خواهید فریم زوم به آن لینک شود، ایجاد کنید. 
3. به اسلاید متن شناسایی و پس‌زمینه اضافه کنید.
4. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) با افزودن یک تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) که برای پر کردن فریم استفاده خواهد شد، ایجاد کنید.
5. فریم‌های زوم (حاوی ارجاع به اسلاید ایجاد شده) را به اسلاید اول اضافه کنید.
6. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک فریم زوم را با تصویر متفاوت ایجاد کنید:

```php
  $pres = new Presentation();
  try {
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # پس‌زمینه‌ای برای اسلاید دوم ایجاد می‌کند
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # یک جعبه متن برای اسلاید سوم ایجاد می‌کند
    $autoshape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # یک تصویر جدید برای شیء زوم ایجاد می‌کند
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # شیء ZoomFrame را اضافه می‌کند
    $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $picture);
    # ارائه را ذخیره می‌کند
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **قالب‌بندی فریم‌های زوم**
در بخش‌های قبل، به شما نشان دادیم چگونه فریم‌های زوم ساده را ایجاد کنید. برای ساخت فریم‌های زوم پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی وجود دارد که می‌توانید بر روی یک فریم زوم اعمال کنید. 

می‌توانید قالب‌بندی فریم زوم را بر روی اسلاید به این شکل کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدیدی که می‌خواهید فریم زوم به آن‌ها لینک شود، ایجاد کنید. 
3. به اسلایدهای ایجاد شده متن شناسایی و پس‌زمینه‌ای اضافه کنید.
4. فریم‌های زوم (حاوی ارجاع به اسلایدهای ایجاد شده) را به اسلاید اول اضافه کنید.
5. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) با افزودن یک تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) که برای پر کردن فریم استفاده خواهد شد، ایجاد کنید.
6. برای اولین شیء فریم زوم، تصویر سفارشی تنظیم کنید.
7. قالب خط را برای شیء فریم زوم دوم تغییر دهید.
8. پس‌زمینه تصویر شیء فریم زوم دوم را حذف کنید.
5. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه قالب‌بندی یک فریم زوم را بر روی اسلاید تغییر دهید:

```php
  $pres = new Presentation();
  try {
    # اسلایدهای جدید را به ارائه اضافه می‌کند
    $slide2 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide3 = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    # پس‌زمینه‌ای برای اسلاید دوم ایجاد می‌کند
    $slide2->getBackground()->setType(BackgroundType::OwnBackground);
    $slide2->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide2->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    # یک جعبه متن برای اسلاید دوم ایجاد می‌کند
    $autoshape = $slide2->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Second Slide");
    # پس‌زمینه‌ای برای اسلاید سوم ایجاد می‌کند
    $slide3->getBackground()->setType(BackgroundType::OwnBackground);
    $slide3->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide3->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->darkGray);
    # یک جعبه متن برای اسلاید سوم ایجاد می‌کند
    $autoshape = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $autoshape->getTextFrame()->setText("Trird Slide");
    # اشیای ZoomFrame را اضافه می‌کند
    $zoomFrame1 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(20, 20, 250, 200, $slide2);
    $zoomFrame2 = $pres->getSlides()->get_Item(0)->getShapes()->addZoomFrame(200, 250, 250, 200, $slide3);
    # یک تصویر جدید برای شیء زوم ایجاد می‌کند
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # تصویر سفارشی را برای شیء zoomFrame1 تنظیم می‌کند
    $zoomFrame1->setImage($picture);
    # قالب فریم زوم را برای شیء zoomFrame2 تنظیم می‌کند
    $zoomFrame2->getLineFormat()->setWidth(5);
    $zoomFrame2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $zoomFrame2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->pink);
    $zoomFrame2->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    # تنظیم برای عدم نمایش پس‌زمینه برای شیء zoomFrame2
    $zoomFrame2->setShowBackground(false);
    # ارائه را ذخیره می‌کند
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **زوم بخش**

یک زوم بخش لینک‌گذاری به یک بخش در ارائه شما است. می‌توانید از زوم‌های بخش برای بازگشت به بخش‌هایی که می‌خواهید به‌خوبی تأکید کنید استفاده کنید. یا می‌توانید از آن‌ها برای برجسته‌سازی نحوه ارتباط بخش‌های مختلف ارائه‌تان استفاده کنید. 

![overview_image](seczoomsel.png)

برای اشیای زوم بخش، Aspose.Slides کلاس [SectionZoomFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sectionzoomframe/) و برخی متدها در زیر کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) را ارائه می‌دهد.

### **ایجاد فریم‌های زوم بخش**

می‌توانید یک فریم زوم بخش را بر روی اسلاید به این شکل اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید. 
3. به اسلاید ایجاد شده پس‌زمینه شناسایی اضافه کنید.
4. یک بخش جدید که می‌خواهید فریم زوم به آن لینک شود، ایجاد کنید. 
5. فریم زوم بخش (حاوی ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
6. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک فریم زوم را بر روی اسلاید ایجاد کنید:

```php
  $pres = new Presentation();
  try {
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $pres->getSections()->addSection("Section 1", $slide);
    # یک شیء SectionZoomFrame اضافه می‌کند
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # ارائه را ذخیره می‌کند
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **ایجاد فریم‌های زوم بخش با تصاویر سفارشی**

با Aspose.Slides برای PHP از طریق Java، می‌توانید فریم زوم بخش با تصویر پیش‌نمایش اسلاید متفاوت به این شکل ایجاد کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید.
3. به اسلاید ایجاد شده پس‌زمینه شناسایی اضافه کنید.
4. یک بخش جدید که می‌خواهید فریم زوم به آن لینک شود، ایجاد کنید. 
5. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) با افزودن یک تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) که برای پر کردن فریم استفاده خواهد شد، ایجاد کنید.
5. فریم زوم بخش (حاوی ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
6. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک فریم زوم را با تصویر متفاوت ایجاد کنید:

```php
  $pres = new Presentation();
  try {
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $pres->getSections()->addSection("Section 1", $slide);
    # یک تصویر جدید برای شیء زوم ایجاد می‌کند
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # یک شیء SectionZoomFrame اضافه می‌کند
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1), $picture);
    # ارائه را ذخیره می‌کند
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
### **قالب‌بندی فریم‌های زوم بخش**

برای ساخت فریم‌های زوم بخش پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی وجود دارد که می‌توانید بر روی یک فریم زوم بخش اعمال کنید. 

می‌توانید قالب‌بندی فریم زوم بخش را بر روی اسلاید به این شکل کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید.
3. به اسلاید ایجاد شده پس‌زمینه شناسایی اضافه کنید.
4. یک بخش جدید که می‌خواهید فریم زوم به آن لینک شود، ایجاد کنید. 
5. فریم زوم بخش (حاوی ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
6. اندازه و موقعیت شیء زوم بخش ایجاد شده را تغییر دهید.
7. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) با افزودن یک تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) که برای پر کردن فریم استفاده خواهد شد، ایجاد کنید.
8. برای شیء فریم زوم بخش ایجاد شده، تصویر سفارشی تنظیم کنید.
9. قابلیت *بازگشت به اسلاید اصلی از بخش لینک‌شده* را فعال کنید. 
10. پس‌زمینه تصویر شیء فریم زوم بخش را حذف کنید.
11. قالب خط را برای شیء فریم زوم دوم تغییر دهید.
12. مدت زمان انتقال را تغییر دهید.
13. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه قالب‌بندی یک فریم زوم بخش را تغییر دهید:

```php
  $pres = new Presentation();
  try {
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->yellow);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $pres->getSections()->addSection("Section 1", $slide);
    # اضافه کردن شیء SectionZoomFrame
    $sectionZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $pres->getSections()->get_Item(1));
    # قالب‌بندی برای SectionZoomFrame
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $sectionZoomFrame->setImage($picture);
    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);
    $sectionZoomFrame->setTransitionDuration(1.5);
    # ارائه را ذخیره می‌کند
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **زوم خلاصه**

یک زوم خلاصه مانند صفحهٔ فرودی است که تمام قطعات ارائه‌تان به‌همین‌لحظه نمایش داده می‌شود. وقتی ارائه می‌دهید، می‌توانید با زوم از یک محل به محل دیگر در هر ترتیبی که می‌خواهید بروید. می‌توانید خلاق باشید، پیش‌روی کنید یا بخش‌های مختلف اسلایدشو را بدون قطع جریان ارائه مرور کنید.

![overview_image](sumzoomsel.png)

برای اشیای زوم خلاصه، Aspose.Slides کلاس‌های [SummaryZoomFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/summaryzoomframe/)، [SummaryZoomSection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/summaryzoomsection/)، و [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/summaryzoomsectioncollection/) و برخی متدها در زیر کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) را فراهم می‌کند.

### **ایجاد یک زوم خلاصه**

می‌توانید یک فریم زوم خلاصه را بر روی اسلاید به این شکل اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدید با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. فریم زوم خلاصه را به اسلاید اول اضافه کنید.
4. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک فریم زوم خلاصه را بر روی اسلاید ایجاد کنید:

```php
  $pres = new Presentation();
  try {
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $pres->getSections()->addSection("Section 1", $slide);
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $pres->getSections()->addSection("Section 2", $slide);
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $pres->getSections()->addSection("Section 3", $slide);
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->green);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $pres->getSections()->addSection("Section 4", $slide);
    # یک شیء SummaryZoomFrame اضافه می‌کند
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # ارائه را ذخیره می‌کند
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **افزودن و حذف یک بخش زوم خلاصه**

همهٔ بخش‌ها در یک فریم زوم خلاصه توسط اشیای [SummaryZoomSection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/summaryzoomsection/) نمایان می‌شوند که در شیء [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/summaryzoomsectioncollection/) ذخیره می‌شوند. می‌توانید یک شیء بخش زوم خلاصه را از طریق کلاس [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/summaryzoomsectioncollection/) به این شکل اضافه یا حذف کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدید با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. فریم زوم خلاصه را به اسلاید اول اضافه کنید.
4. یک اسلاید و یک بخش جدید به ارائه اضافه کنید.
5. بخش ایجاد شده را به فریم زوم خلاصه اضافه کنید.
6. بخش اول را از فریم زوم خلاصه حذف کنید.
7. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه بخش‌ها را در یک فریم زوم خلاصه اضافه و حذف کنید:

```php
  $pres = new Presentation();
  try {
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $pres->getSections()->addSection("Section 1", $slide);
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $pres->getSections()->addSection("Section 2", $slide);
    # یک شیء SummaryZoomFrame اضافه می‌کند
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->magenta);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $section3 = $pres->getSections()->addSection("Section 3", $slide);
    # یک بخش به Summary Zoom اضافه می‌کند
    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($section3);
    # بخش را از Summary Zoom حذف می‌کند
    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($pres->getSections()->get_Item(1));
    # ارائه را ذخیره می‌کند
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **قالب‌بندی بخش‌های زوم خلاصه**

برای ساخت اشیای بخش زوم خلاصه پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی وجود دارد که می‌توانید بر روی یک شیء بخش زوم خلاصه اعمال کنید. 

می‌توانید قالب‌بندی یک شیء بخش زوم خلاصه در یک فریم زوم خلاصه را به این شکل کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدید با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. فریم زوم خلاصه را به اسلاید اول اضافه کنید.
4. یک شیء بخش زوم خلاصه را از `SummaryZoomSectionCollection` برای اولین شیء دریافت کنید.
5. یک شیء [PPImage](https://reference.aspose.com/slides/fa/php-java/aspose.slides/ppimage/) با افزودن یک تصویر به مجموعه images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) که برای پر کردن فریم استفاده خواهد شد، ایجاد کنید.
6. تصویر سفارشی برای شیء فریم زوم بخش ایجاد شده تنظیم کنید.
7. قابلیت *بازگشت به اسلاید اصلی از بخش لینک‌شده* را فعال کنید. 
8. قالب خط را برای شیء فریم زوم دوم تغییر دهید.
9. مدت زمان انتقال را تغییر دهید.
10. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد PHP نشان می‌دهد چگونه قالب‌بندی یک شیء بخش زوم خلاصه را تغییر دهید:

```php
  $pres = new Presentation();
  try {
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->gray);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $pres->getSections()->addSection("Section 1", $slide);
    # یک اسلاید جدید به ارائه اضافه می‌کند
    $slide = $pres->getSlides()->addEmptySlide($pres->getSlides()->get_Item(0)->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->cyan);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    # یک بخش جدید به ارائه اضافه می‌کند
    $pres->getSections()->addSection("Section 2", $slide);
    # یک شیء SummaryZoomFrame اضافه می‌کند
    $summaryZoomFrame = $pres->getSlides()->get_Item(0)->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);
    # شیء SummaryZoomSection اول را دریافت می‌کند
    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    # قالب‌بندی برای شیء SummaryZoomSection
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $summarySection->setImage($picture);
    $summarySection->setReturnToParent(false);
    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->black);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);
    $summarySection->setTransitionDuration(1.5);
    # ارائه را ذخیره می‌کند
    $pres->save("presentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا می‌توانم بازگشت به اسلاید 'والد' پس از نمایش هدف را کنترل کنم؟**

بله. فریم [Zoom frame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/zoomframe/) یا [section](https://reference.aspose.com/slides/fa/php-java/aspose.slides/sectionzoomframe/) دارای رفتار `ReturnToParent` است که وقتی فعال باشد، پس از بازدید از محتوای هدف، بینندگان را به اسلاید مبدأ باز می‌گرداند.

**آیا می‌توانم «سرعت» یا مدت زمان انتقال زوم را تنظیم کنم؟**

بله. زوم از تنظیم `TransitionDuration` پشتیبانی می‌کند تا بتوانید مدت زمان انیمیشن پرش را کنترل کنید.

**آیا محدودیتی برای تعداد اشیای زوم در یک ارائه وجود دارد؟**

هیچ محدودیت سخت‌گیرانه‌ای در API مستند نشده است. محدودیت‌های عملی به پیچیدگی کلی ارائه و عملکرد نمایشگر بستگی دارد. می‌توانید تعداد زیادی فریم زوم اضافه کنید، اما به حجم فایل و زمان رندرینگ توجه داشته باشید.