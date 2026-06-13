---
title: مدیریت جعبه‌های متن در ارائه‌ها با استفاده از PHP
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/php-java/manage-textbox/
keywords:
- جعبه متن
- قاب متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "Aspose.Slides برای PHP ایجاد، ویرایش و تکثیر جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را آسان می‌کند و خودکارسازی ارائه‌های شما را ارتقا می‌دهد."
---
## **مقدمه**

متن‌ها در اسلایدها معمولاً در کادرهای متن یا اشکال موجود هستند. بنابراین، برای افزودن متن به یک اسلاید، باید یک کادر متن اضافه کنید و سپس متنی داخل آن قرار دهید. Aspose.Slides برای PHP از طریق Java کلاس AutoShape را فراهم می‌کند که به شما اجازه می‌دهد یک شکل حاوی متن اضافه کنید.

{{% alert title="اطلاعات" color="info" %}}
Aspose.Slides همچنین کلاس Shape را فراهم می‌کند که به شما اجازه می‌دهد اشکالی را به اسلایدها اضافه کنید. با این حال، همه اشکالی که از طریق کلاس `Shape` اضافه می‌شوند قادر به نگهداری متن نیستند. اما اشکالی که از طریق کلاس AutoShape اضافه می‌شوند می‌توانند متن داشته باشند.
{{% /alert %}}

{{% alert title="نکته" color="warning" %}} 
به‌این‌دلایل، هنگام کار با شکلی که می‌خواهید متن به آن اضافه کنید، ممکن است بخواهید بررسی کنید و تأیید کنید که آن از طریق کلاس `AutoShape` تبدیل شده است. فقط در این صورت می‌توانید با `TextFrame` کار کنید که یک ویژگی تحت `AutoShape` است. بخش به‌روزرسانی متن را در این صفحه ببینید.
{{% /alert %}}

## **ایجاد یک کادر متن در اسلاید**

1. یک نمونه از کلاس Presentation ایجاد کنید.  
2. یک ارجاع به اولین اسلاید در ارائه تازه ایجاد شده دریافت کنید.  
3. یک شی AutoShape با نوع شکل Rectangle در موقعیتی مشخص روی اسلاید اضافه کنید و ارجاع به شی AutoShape تازه افزوده شده را دریافت کنید.  
4. یک TextFrame به شی AutoShape اضافه کنید که شامل متنی خواهد بود. در مثال زیر، این متن را افزودیم: *Aspose TextBox*  
5. در نهایت، فایل PPTX را از طریق شی Presentation بنویسید.  

این کد PHP—پیاده‌سازی مراحلی که در بالا شرح شد—نشان می‌دهد چگونه به یک اسلاید متن اضافه کنید:

```php
  # یک شی Presentation ایجاد می‌کند
  $pres = new Presentation();
  try {
    # اولین اسلاید در ارائه را دریافت می‌کند
    $sld = $pres->getSlides()->get_Item(0);
    # یک AutoShape با نوع Rectangle اضافه می‌کند
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # یک TextFrame به مستطیل اضافه می‌کند
    $ashp->addTextFrame(" ");
    # به فریم متن دسترسی پیدا می‌کند
    $txtFrame = $ashp->getTextFrame();
    # شی Paragraph را برای فریم متن ایجاد می‌کند
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # یک شی Portion برای پاراگراف ایجاد می‌کند
    $portion = $para->getPortions()->get_Item(0);
    # متن را تنظیم می‌کند
    $portion->setText("Aspose TextBox");
    # ارائه را به دیسک ذخیره می‌کند
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **بررسی وجود شکل کادر متن**

Aspose.Slides متد isTextBox را از کلاس AutoShape فراهم می‌کند که به شما امکان می‌دهد اشکال را بررسی کنید و کادرهای متن را شناسایی کنید.

![کادر متن و شکل](istextbox.png)

این کد PHP نشان می‌دهد چگونه بررسی کنید آیا یک شکل به عنوان کادر متن ایجاد شده است یا خیر:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

توجه داشته باشید که اگر به‌سادگی یک autoshape را با استفاده از متد addAutoShape از کلاس ShapeCollection اضافه کنید، متد isTextBox آن autoshape مقدار false برمی‌گرداند. اما پس از افزودن متن به autoshape با استفاده از متد addTextFrame یا متد setText، ویژگی isTextBox مقدار true برمی‌گرداند.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() مقدار false برمی‌گردد
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() مقدار true برمی‌گردد

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() مقدار false برمی‌گردد
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() مقدار true برمی‌گردد

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() مقدار false برمی‌گردد
$shape3->addTextFrame("");
// shape3->isTextBox() مقدار false برمی‌گردد

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() مقدار false برمی‌گردد
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() مقدار false برمی‌گردد
```

## **افزودن ستون‌ها به کادر متن**

Aspose.Slides متدهای setColumnCount و setColumnSpacing را از کلاس TextFrameFormat فراهم می‌کند که به شما امکان افزودن ستون‌ها به کادرهای متن را می‌دهد. می‌توانید تعداد ستون‌ها در یک کادر متن را مشخص کنید و فاصله بین ستون‌ها را برحسب نقطه تنظیم کنید.

این کد عملیات توصیف‌شده را نشان می‌دهد:

```php
  $pres = new Presentation();
  try {
    # اسلاید اول در ارائه را دریافت می‌کند
    $slide = $pres->getSlides()->get_Item(0);
    # یک AutoShape با نوع Rectangle اضافه می‌کند
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # یک TextFrame به مستطیل اضافه می‌کند
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # قالب متن TextFrame را دریافت می‌کند
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # تعداد ستون‌ها در TextFrame را مشخص می‌کند
    $format->setColumnCount(3);
    # فاصله بین ستون‌ها را مشخص می‌کند
    $format->setColumnSpacing(10);
    # ارائه را ذخیره می‌کند
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **افزودن ستون‌ها به قاب متن**

Aspose.Slides برای PHP از طریق Java متد setColumnCount را از کلاس TextFrameFormat فراهم می‌کند که به شما امکان افزودن ستون‌ها در قاب‌های متن را می‌دهد. با استفاده از این ویژگی، می‌توانید تعداد ستون‌های دلخواه خود را در یک قاب متن مشخص کنید.

این کد PHP نشان می‌دهد چگونه یک ستون داخل یک قاب متن اضافه کنید:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **به‌روزرسانی متن**

Aspose.Slides به شما اجازه می‌دهد متن موجود در یک کادر متن یا تمام متون موجود در یک ارائه را تغییر یا به‌روزرسانی کنید.

این کد PHP عملی را نشان می‌دهد که در آن تمام متون یک ارائه به‌روزرسانی یا تغییر می‌یابند:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # بررسی می‌کند که آیا شکل از فریم متن (IAutoShape) پشتیبانی می‌کند.
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # از طریق پاراگراف‌های موجود در فریم متن به مرور می‌پردازد
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # از طریق هر بخش (portion) در پاراگراف به مرور می‌پردازد
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// متن را تغییر می‌دهد

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// قالب‌بندی را تغییر می‌دهد

            }
          }
        }
      }
    }
    # ارائهٔ تغییر یافته را ذخیره می‌کند
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **افزودن یک کادر متن با پیوند**

می‌توانید یک لینک را داخل یک کادر متن وارد کنید. وقتی روی کادر متن کلیک می‌شود، کاربران به باز کردن لینک هدایت می‌شوند.

1. یک نمونه از کلاس `Presentation` ایجاد کنید.  
2. یک ارجاع به اولین اسلاید در ارائه تازه ایجاد شده دریافت کنید.  
3. یک شی `AutoShape` با `ShapeType` برابر `Rectangle` در موقعیتی مشخص روی اسلاید اضافه کنید و ارجاع به شی AutoShape تازه اضافه‌شده را دریافت کنید.  
4. یک `TextFrame` به شی `AutoShape` اضافه کنید که متن پیش‌فرض *Aspose TextBox* را داشته باشد.  
5. یک نمونه از کلاس `HyperlinkManager` ایجاد کنید.  
6. یک پیوند را با استفاده از متد setExternalHyperlinkClick به بخشی از `TextFrame` که ترجیح می‌دهید اختصاص دهید.  
7. در نهایت، فایل PPTX را از طریق شی `Presentation` بنویسید.  

این کد PHP—پیاده‌سازی مراحلی که در بالا شرح شد—نشان می‌دهد چگونه یک کادر متن با پیوند به یک اسلاید اضافه کنید:

```php
  # یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
  $pres = new Presentation();
  try {
    # اسلاید اول در ارائه را دریافت می‌کند
    $slide = $pres->getSlides()->get_Item(0);
    # یک شی AutoShape با نوع Rectangle اضافه می‌کند
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # شکل را به AutoShape تبدیل می‌کند
    $pptxAutoShape = $shape;
    # به ویژگی ITextFrame مرتبط با AutoShape دسترسی پیدا می‌کند
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # متنی به فریم اضافه می‌کند
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # پیوند (Hyperlink) برای متن بخش را تنظیم می‌کند
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # ارائه PPTX را ذخیره می‌کند
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**تفرق بین یک کادر متن و یک محل‌نگهدار متن هنگام کار با اسلایدهای اصلی چیست؟**

یک [placeholder](/slides/fa/php-java/manage-placeholder/) سبک/موقعیت را از [master](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) به ارث می‌برد و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک کادر متن معمولی یک شی مستقل بر روی اسلاید خاص است و هنگام تغییر layouts تغییری نمی‌کند.

**چگونه می‌توانم جایگزینی متنی به‌صورت گروهی در سراسر ارائه انجام دهم بدون اینکه متن داخل نمودارها، جداول و SmartArt را تحت تأثیر قرار دهم؟**

تکرار خود را فقط به auto‑shapeهایی که TextFrame دارند محدود کنید و اشیاء جاسازی‌شده ([charts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/fa/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/)) را با عبور جداگانه از مجموعه‌های آن‌ها یا کنارگذاری آن نوع اشیاء حذف کنید.