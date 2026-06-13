---
title: مدیریت گره‌های شکل SmartArt در ارائه‌ها با استفاده از PHP
linktitle: گره شکل SmartArt
type: docs
weight: 30
url: /fa/php-java/manage-smartart-shape-node/
keywords:
- گره SmartArt
- گره فرزند
- افزودن گره
- موقعیت گره
- دسترسی به گره
- حذف گره
- موقعیت سفارشی
- گره دستیار
- فرمت پر کردن
- رندر گره
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت گره‌های شکل SmartArt در فایل‌های PPT و PPTX با Aspose.Slides برای PHP از طریق Java. نمونه‌های کد واضح و نکاتی برای بهینه‌سازی ارائه‌های شما دریافت کنید."
---
## **نمای کلی**

گرافیک‌های SmartArt در ارائه‌های PowerPoint از طریق گره‌هایی که حاوی متن هستند و ساختار نمودار را تعریف می‌کنند، سازماندهی می‌شوند. Aspose.Slides به شما امکان می‌دهد به‌صورت برنامه‌نویسی با این گره‌های SmartArt کار کنید: افزودن گره‌ها و گره‌های فرزند جدید، درج گره‌های فرزند در موقعیت خاص، دسترسی به گره‌های موجود و خواندن متن، سطح و موقعیت آن‌ها.

این مقاله نحوه مدیریت گره‌های اشکال SmartArt را توضیح می‌دهد. همچنین نشان می‌دهد چگونه گره‌ها را حذف کنید، با گره‌های فرزند بر اساس شاخص یا موقعیت کار کنید، یک گره دستیار را به گره عادی تبدیل کنید، موقعیت، اندازه و چرخش اشکال گره‌های SmartArt را تنظیم کنید، فرمت پر شدن گره را تعیین کنید و تصویر بندانگشتی برای یک گره فرزند SmartArt ایجاد کنید.

## **افزودن گره SmartArt**
Aspose.Slides برای PHP از طریق Java ساده‌ترین API را برای مدیریت اشکال SmartArt به راحت‌ترین شکل فراهم کرده است. کد نمونه زیر به شما کمک می‌کند گره و گره فرزند را در داخل شکل SmartArt اضافه کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از اندیس آن دریافت کنید.
3. در همه اشکال داخل اسلاید اول عبور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) است و در صورت بودن، شکل انتخاب شده را به [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) تبدیل کنید.
5. [Add a new Node](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnodecollection/#addNode) در شکل SmartArt در [**NodeCollection**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/#getAllNodes) اضافه کنید و متن را در TextFrame تنظیم کنید.
6. اکنون، [Add](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnodecollection/#addNode) یک [**Child Node**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnode/#getChildNodes) در گره SmartArt تازه اضافه شده اضافه کنید و متن را در TextFrame تنظیم کنید.
7. ارائه را ذخیره کنید.

```php
  # بارگذاری ارائه مورد نظر
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # پیمایش همه اشکال داخل اسلاید اول
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # بررسی اینکه آیا شکل از نوع SmartArt است
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تبدیل نوع شکل به SmartArt
        $smart = $shape;
        # افزودن یک گره SmartArt جدید
        $TemNode = $smart->getAllNodes()->addNode();
        # افزودن متن
        $TemNode->getTextFrame()->setText("Test");
        # افزودن گره فرزند جدید به گره والد. این گره در انتهای مجموعه اضافه خواهد شد
        $newNode = $TemNode->getChildNodes()->addNode();
        # افزودن متن
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # ذخیره‌سازی ارائه
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **افزودن گره SmartArt در موقعیت خاص**
در کد نمونه زیر توضیح داده‌ایم چگونه گره‌های فرزند متعلق به گره‌های مربوطهٔ شکل SmartArt را در موقعیت خاصی اضافه کنیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/Presentation) ایجاد کنید.
2. مرجع اسلاید اول را با استفاده از اندیس آن دریافت کنید.
3. یک شکل [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArt) از نوع [**StackedList**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArtLayoutType#StackedList) در اسلاید دسترسی شده اضافه کنید.
4. به اولین گره در شکل SmartArt اضافه شده دسترسی پیدا کنید.
5. اکنون، گره [**Child Node**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnode/#getChildNodes) را برای گره انتخاب شده در موقعیت 2 اضافه کنید و متن آن را تنظیم کنید.
6. ارائه را ذخیره کنید.

```php
  # ایجاد یک نمونه ارائه
  $pres = new Presentation();
  try {
    # دسترسی به اسلاید ارائه
    $slide = $pres->getSlides()->get_Item(0);
    # افزودن IShape Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # دسترسی به گره SmartArt در اندیس 0
    $node = $smart->getAllNodes()->get_Item(0);
    # افزودن گره فرزند جدید در موقعیت 2 در گره والد
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # افزودن متن
    $chNode->getTextFrame()->setText("Sample Text Added");
    # ذخیره‌سازی ارائه
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دسترسی به گره SmartArt**
کد نمونه زیر به شما کمک می‌کند به گره‌های داخل شکل SmartArt دسترسی پیدا کنید. لطفاً توجه داشته باشید که LayoutType گره SmartArt فقط قابل خواندن است و فقط هنگام افزودن شکل SmartArt تنظیم می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از اندیس آن دریافت کنید.
3. در همه اشکال داخل اسلاید اول عبور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) است و در صورت بودن، شکل انتخاب شده را به [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) تبدیل کنید.
5. در تمام [**Nodes**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArt#getAllNodes--) داخل شکل SmartArt عبور کنید.
6. اطلاعاتی مانند موقعیت گره SmartArt، سطح و متن را دسترسی و نمایش دهید.

```php
  # ایجاد نمونه کلاس Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # دریافت اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # پیمایش تمام اشکال داخل اولین اسلاید
    foreach($slide->getShapes() as $shape) {
      # بررسی اینکه آیا شکل از نوع SmartArt است
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تبدیل نوع شکل به SmartArt
        $smart = $shape;
        # پیمایش تمام گره‌ها داخل SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # دسترسی به گره SmartArt در اندیس i
          $node = $smart->getAllNodes()->get_Item($i);
          # چاپ پارامترهای گره SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دسترسی به گره فرزند SmartArt**
کد نمونه زیر به شما کمک می‌کند به گره‌های فرزند متعلق به گره‌های مربوطهٔ شکل SmartArt دسترسی پیدا کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از اندیس آن دریافت کنید.
3. در همه اشکال داخل اسلاید اول عبور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) است و در صورت بودن، شکل انتخاب شده را به [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) تبدیل کنید.
5. در تمام [**Nodes**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArt#getAllNodes--) داخل شکل SmartArt عبور کنید.
6. برای هر گره [**Node**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArtNode) انتخاب شده، در تمام [**Child Nodes**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArtNode#getChildNodes--) داخل گره خاص عبور کنید.
7. اطلاعاتی مانند موقعیت، سطح و متن [**Child Node**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnode/#getChildNodes) را دسترسی و نمایش دهید.

```php
  # ایجاد نمونه کلاس Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # دریافت اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # پیمایش تمام اشکال داخل اولین اسلاید
    foreach($slide->getShapes() as $shape) {
      # بررسی اینکه آیا شکل از نوع SmartArt است
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تبدیل نوع شکل به SmartArt
        $smart = $shape;
        # پیمایش تمام گره‌ها داخل SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # دسترسی به گره SmartArt در اندیس i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # پیمایش گره‌های فرزند در گره SmartArt در اندیس i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # دسترسی به گره فرزند در گره SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # چاپ پارامترهای گره فرزند SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **دسترسی به گره فرزند SmartArt در موقعیت خاص**
در این مثال می‌آموزیم چگونه گره‌های فرزند را در موقعیت‌های خاصی که متعلق به گره‌های مربوطهٔ شکل SmartArt هستند، دسترسی پیدا کنیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
2. مرجع اسلاید اول را با استفاده از اندیس آن دریافت کنید.
3. یک شکل SmartArt از نوع [**StackedList**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArtLayoutType#StackedList) اضافه کنید.
4. به شکل SmartArt اضافه شده دسترسی پیدا کنید.
5. گره‌ای با اندیس 0 برای شکل SmartArt دسترسی شده دریافت کنید.
6. اکنون، گره [**Child Node**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnode/#getChildNodes) را در موقعیت 1 برای گره SmartArt دسترسی شده با روش **get_Item()** دریافت کنید.
7. اطلاعاتی مانند موقعیت، سطح و متن [**Child Node**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnode/#getChildNodes) را دسترسی و نمایش دهید.

```php
  # نمونه‌سازی ارائه
  $pres = new Presentation();
  try {
    # دسترسی به اولین اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # افزودن شکل SmartArt در اولین اسلاید
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # دسترسی به گره SmartArt در اندیس 0
    $node = $smart->getAllNodes()->get_Item($i);
    # دسترسی به گره فرزند در موقعیت 1 در گره والد
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # چاپ پارامترهای گره فرزند SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف گره SmartArt**
در این مثال می‌آموزیم چگونه گره‌های داخل شکل SmartArt را حذف کنیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از اندیس آن دریافت کنید.
3. در همه اشکال داخل اسلاید اول عبور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) است و در صورت بودن، شکل انتخاب شده را به [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) تبدیل کنید.
5. بررسی کنید آیا SmartArt بیش از 0 گره دارد.
6. گره SmartArt مورد نظر برای حذف را انتخاب کنید.
7. اکنون، گره انتخاب شده را با استفاده از روش [**removeNode**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnodecollection/#removeNode) حذف کنید.
8. ارائه را ذخیره کنید.

```php
  # بارگذاری ارائه مورد نظر
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # پیمایش تمام اشکال داخل اسلاید اول
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # بررسی اینکه آیا شکل از نوع SmartArt است
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تبدیل نوع شکل به SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # دسترسی به گره SmartArt در اندیس 0
          $node = $smart->getAllNodes()->get_Item(0);
          # حذف گره انتخاب شده
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # ذخیره‌سازی ارائه
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف گره SmartArt از موقعیت خاص**
در این مثال می‌آموزیم چگونه گره‌های داخل شکل SmartArt را در موقعیت خاصی حذف کنیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از اندیس آن دریافت کنید.
3. در همه اشکال داخل اسلاید اول عبور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) است و در صورت بودن، شکل انتخاب شده را به [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) تبدیل کنید.
5. گره شکل SmartArt را در اندیس 0 انتخاب کنید.
6. اکنون بررسی کنید آیا گره SmartArt انتخاب شده بیش از 2 گره فرزند دارد.
7. سپس گره در **Position 1** را با استفاده از روش [**removeNode**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnodecollection/#removeNode) حذف کنید.
8. ارائه را ذخیره کنید.

```php
  # بارگذاری ارائه مورد نظر
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # پیمایش تمام اشکال داخل اسلاید اول
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # بررسی اینکه آیا شکل از نوع SmartArt است
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تبدیل نوع شکل به SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # دسترسی به گره SmartArt در اندیس 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # حذف گره فرزند در موقعیت 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # ذخیره‌سازی ارائه
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تنظیم موقعیت سفارشی برای گره فرزند در شیء SmartArt**
Aspose.Slides برای PHP از طریق Java از تنظیم ویژگی‌های [SmartArtShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArtShape) **X**(https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#setX) و **Y**(https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#setY) پشتیبانی می‌کند. قطعه کد زیر نشان می‌دهد چگونه موقعیت، اندازه و چرخش سفارشی SmartArtShape را تنظیم کنید؛ همچنین توجه داشته باشید افزودن گره‌های جدید منجر به محاسبه مجدد موقعیت‌ها و اندازه‌های همه گره‌ها می‌شود. با تنظیم موقعیت سفارشی، کاربر می‌تواند گره‌ها را بر پایهٔ نیازهای خود تنظیم کند.

```php
  # ایجاد نمونه کلاس Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # انتقال شکل SmartArt به موقعیت جدید
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # تغییر عرض‌های شکل SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # تغییر ارتفاع شکل SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # تغییر چرخش شکل SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **بررسی یک گره دستیار**
{{% alert color="primary" %}} 

در این مقاله ویژگی‌های اضافی اشکال SmartArt که به‌صورت برنامه‌نویسی در اسلایدهای ارائه اضافه می‌شوند را بررسی می‌کنیم.

{{% /alert %}} 

ما از شکل SmartArt منبع زیر برای بررسی در بخش‌های مختلف این مقاله استفاده خواهیم کرد.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**شکل: شکل SmartArt منبع در اسلاید**|

در کد نمونه زیر بررسی می‌کنیم چگونه گره‌های **Assistant** را در مجموعه گره‌های SmartArt شناسایی و تغییر دهیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید دوم را با استفاده از اندیس آن دریافت کنید.
3. در همه اشکال داخل اسلاید اول عبور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) است و در صورت بودن، شکل انتخاب شده را به [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) تبدیل کنید.
5. در تمام گره‌های داخل شکل SmartArt عبور کنید و بررسی کنید آیا آن‌ها گره‌های [**Assistant Nodes**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArtNode#isAssistant--) هستند.
6. وضعیت گره دستیار را به گره عادی تغییر دهید.
7. ارائه را ذخیره کنید.

```php
  # ایجاد یک نمونه ارائه
  $pres = new Presentation("AddNodes.pptx");
  try {
    # پیمایش تمام اشکال داخل اولین اسلاید
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # بررسی اینکه آیا شکل از نوع SmartArt است
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تبدیل نوع شکل به SmartArt
        $smart = $shape;
        # پیمایش تمام گره‌های شکل SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # بررسی اینکه آیا گره دستیار است
          if ($node->isAssistant()) {
            # تنظیم گره دستیار به false و تبدیل آن به گره عادی
            $node->isAssistant();
          }
        }
      }
    }
    # ذخیره‌سازی ارائه
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**شکل: گره‌های دستیار در شکل SmartArt داخل اسلاید تغییر یافتند**|

## **تنظیم فرمت پر کردن گره**
Aspose.Slides برای PHP از طریق Java امکان افزودن اشکال SmartArt سفارشی و تنظیم فرمت پر کردن آن‌ها را فراهم می‌کند. این مقاله توضیح می‌دهد چگونه اشکال SmartArt را ایجاد و دسترسی داشته باشید و فرمت پر کردن آن‌ها را با استفاده از Aspose.Slides برای PHP از طریق Java تنظیم کنید.

لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
2. یک اسلاید را با استفاده از اندیس آن دریافت کنید.
3. یک شکل [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) را با تنظیم [**LayoutType**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) اضافه کنید.
4. برای گره‌های شکل SmartArt، [**Fill Format**](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getFillFormat) را تنظیم کنید.
5. ارائه تغییر یافته را به صورت فایل PPTX بنویسید.

```php
  # ایجاد نمونه ارائه
  $pres = new Presentation();
  try {
    # دسترسی به اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # افزودن شکل SmartArt و گره‌ها
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # تنظیم رنگ پر کردن گره
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # ذخیره‌سازی ارائه
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تولید تصویر بندانگشتی از گره فرزند SmartArt**
توسعه‌دهندگان می‌توانند با پیروی از مراحل زیر تصویر بندانگشتی گره فرزند یک SmartArt را تولید کنند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
2. [Add SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnodecollection/#addNode) را انجام دهید.
3. مرجع یک گره را با استفاده از اندیس آن دریافت کنید.
4. تصویر بندانگشتی را دریافت کنید.
5. تصویر بندانگشتی را در هر قالب تصویری دلخواهی ذخیره کنید.

```php
  # ایجاد نمونه کلاس Presentation که فایل PPTX را نمایندگی می‌کند
  $pres = new Presentation();
  try {
    # افزودن SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # دریافت مرجع گره با استفاده از اندیس آن
    $node = $smart->getNodes()->get_Item(1);
    # دریافت تصویر بندانگشتی
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # ذخیره تصویر بندانگشتی
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**آیا انیمیشن SmartArt پشتیبانی می‌شود؟**

بله. SmartArt به‌عنوان یک شکل عادی در نظر گرفته می‌شود، بنابراین می‌توانید [انیمیشن‌های استاندارد](/slides/fa/php-java/shape-animation/) (ورودی، خروجی، تأکید، مسیرهای حرکتی) را اعمال کنید و زمان‌بندی را تنظیم کنید. در صورت نیاز می‌توانید اشکال داخل گره‌های SmartArt را نیز انیمیت کنید.

**چگونه می‌توانم یک SmartArt خاص را در اسلاید پیدا کنم اگر شناسه داخلی آن ناشناخته باشد؟**

با استفاده از [متن جایگزین](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getalternativetext/) جستجو کنید. تنظیم AltText متمایز برای SmartArt به شما امکان می‌دهد آن را به‌صورت برنامه‌نویسی بدون وابستگی به شناسه‌های داخلی پیدا کنید.

**آیا ظاهر SmartArt هنگام تبدیل ارائه به PDF حفظ می‌شود؟**

بله. Aspose.Slides هنگام [خروجی PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) SmartArt را با دقت بصری بالا رندر می‌کند و لایه‌بندی، رنگ‌ها و اثرات را حفظ می‌نماید.

**آیا می‌توانم تصویر تمام SmartArt را استخراج کنم (برای پیش‌نمایش یا گزارش‌ها)؟**

بله. می‌توانید یک شکل SmartArt را به [فرمت‌های رستری](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getImage) یا به [SVG](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/writeassvg/) رندر کنید تا خروجی وکتور مقیاس‌پذیر داشته باشید، که برای بندانگشتی‌ها، گزارش‌ها یا استفاده در وب مناسب است.