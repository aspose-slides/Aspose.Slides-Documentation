---
title: "مدیریت جعبه‌های متن در ارائه‌ها با استفاده از PHP"
linktitle: "مدیریت جعبه متن"
type: docs
weight: 20
url: /fa/php-java/manage-textbox/
keywords:
- جعبه متن
- فریم متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "Aspose.Slides برای PHP ایجاد، ویرایش و کلون کردن جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را آسان می‌کند و خودکارسازی ارائه‌های شما را ارتقا می‌دهد."
---
## **مقدمه**

متن‌ها در اسلایدها به‌طور معمول در جعبه‌های متن یا اشکال وجود دارند. بنابراین، برای افزودن متن به یک اسلاید، باید یک جعبه متن اضافه کنید و سپس متنی را داخل آن قرار دهید. Aspose.Slides برای PHP از طریق Java کلاس [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) را ارائه می‌دهد که به شما امکان افزودن شکلی حاوی متن را می‌دهد.

{{% alert title="Info" color="info" %}}
Aspose.Slides همچنین کلاس [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) را فراهم می‌کند که به شما امکان افزودن اشکال به اسلایدها را می‌دهد. با این حال، همه اشکالی که از کلاس `Shape` اضافه می‌شوند می‌توانند متن را در خود نگه دارند. اما اشکال اضافه‌شده از طریق کلاس [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) می‌توانند شامل متن باشند.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
بنابراین، زمانی که با شکیلی که می‌خواهید به آن متن اضافه کنید کار می‌کنید، ممکن است بخواهید بررسی و تأیید کنید که آن از طریق کلاس `AutoShape` تبدیل شده است. تنها پس از آن می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) کار کنید که یک ویژگی تحت `AutoShape` است. بخش [Update Text](/slides/fa/php-java/manage-textbox/#update-text) را در این صفحه مشاهده کنید.
{{% /alert %}}

## **ایجاد جعبه متن در اسلاید**

برای ایجاد یک جعبه متن روی اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. یک ارجاع به اولین اسلاید در ارائه‌ای که به‌تازگی ایجاد شده به دست آورید.  
3. یک شیء [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) با نوع شکل [Rectangle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapetype/#Rectangle) در موقعیت مشخصی روی اسلاید اضافه کنید و ارجاع به شیء `AutoShape` تازه اضافه‌شده را دریافت کنید.  
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید که متنی را در بر خواهد گرفت. در مثال زیر این متن را اضافه کردیم: *Aspose TextBox*  
5. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید.  

این کد PHP — پیاده‌سازی مراحل بالا — نشان می‌دهد چگونه به یک اسلاید متن اضافه کنید:

```php
  # یک شی Presentation ایجاد می‌کند
  $pres = new Presentation();
  try {
    # اولین اسلاید در ارائه را دریافت می‌کند
    $sld = $pres->getSlides()->get_Item(0);
    # یک AutoShape با نوع Rectangle اضافه می‌کند
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # یک TextFrame به Rectangle اضافه می‌کند
    $ashp->addTextFrame(" ");
    # به فریم متن دسترسی پیدا می‌کند
    $txtFrame = $ashp->getTextFrame();
    # شی Paragraph را برای فریم متن ایجاد می‌کند
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # شی Portion را برای پاراگراف ایجاد می‌کند
    $portion = $para->getPortions()->get_Item(0);
    # متن را تنظیم می‌کند
    $portion->setText("Aspose TextBox");
    # ارائه را روی دیسک ذخیره می‌کند
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **بررسی وجود شکل جعبه متن**

Aspose.Slides متد [isTextBox](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/istextbox/) را از کلاس [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) فراهم می‌کند که به شما امکان بررسی اشکال و شناسایی جعبه‌های متن را می‌دهد.

![Text box and shape](istextbox.png)

این کد PHP نشان می‌دهد چگونه بررسی کنید آیا یک شکل به‌عنوان جعبه متن ایجاد شده است یا نه:

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

توجه داشته باشید اگر به‌سادگی یک AutoShape را با استفاده از متد `addAutoShape` از کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) اضافه کنید، متد `isTextBox` برای آن AutoShape مقدار `false` را برمی‌گرداند. اما پس از افزودن متن به AutoShape با استفاده از متد `addTextFrame` یا متد `setText`، ویژگی `isTextBox` مقدار `true` برمی‌گرداند.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() مقدار false برمی‌گرداند
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() مقدار true برمی‌گرداند

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() مقدار false برمی‌گرداند
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() مقدار true برمی‌گرداند

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() مقدار false برمی‌گرداند
$shape3->addTextFrame("");
// shape3->isTextBox() مقدار false برمی‌گرداند

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() مقدار false برمی‌گرداند
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() مقدار false برمی‌گرداند
```

## **پیدا کردن شکلی که فریم متن را در اختیار دارد**

در کدهای عمومی پردازش متن، ممکن است یک [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) دریافت کنید بدون اینکه بدانید کدام شیء ارائه آن را شامل می‌شود. از متد [TextFrame::getParentShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParentShape) استفاده کنید تا به [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) مالک بازگردید.

برای فریم متنی که به یک [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) یا شکل دیگری حاوی متن تعلق دارد، متد [TextFrame::getParentShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParentShape) مالک را برمی‌گرداند و متد [TextFrame::getParentCell](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/#getParentCell) مقدار `null` را برمی‌گرداند. هر دو متد ناوبری فقط‑خواندنی هستند، بنابراین فراخوانی آن‌ها مالکیت را تغییر نمی‌دهد. قبل از دسترسی به شکل، همواره مقدار برگشتی را با `java_is_null` بررسی کنید.

برای مثال کامل که مالکین شکل و سلول جدول را شناسایی می‌کند، از جمله اشکالی که به گره‌های SmartArt مربوط می‌شوند، به [Search and Replace Text](/slides/fa/php-java/search-and-replace-text/) مراجعه کنید.

## **افزودن ستون‌ها به جعبه متن**

Aspose.Slides متدهای [setColumnCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/setcolumncount/) و [setColumnSpacing](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/setcolumnspacing/) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/) ارائه می‌دهد که به شما امکان افزودن ستون‌ها به جعبه‌های متن را می‌دهد. می‌توانید تعداد ستون‌ها را در یک جعبه متن مشخص کنید و فاصله بین ستون‌ها بر حسب نقطه تنظیم نمایید.

این کد عملکرد توضیح‌داده‌شده را نشان می‌دهد:

```php
  $pres = new Presentation();
  try {
    # اولین اسلاید در ارائه را دریافت می‌کند
    $slide = $pres->getSlides()->get_Item(0);
    # یک AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # یک TextFrame به Rectangle اضافه می‌کند
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

## **افزودن ستون‌ها به فریم متن**
Aspose.Slides برای PHP از طریق Java متد [setColumnCount](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/setcolumncount/) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframeformat/) فراهم می‌کند که به شما امکان افزودن ستون‌ها در فریم‌های متن را می‌دهد. از این ویژگی می‌توانید تعداد مورد نظر خود را برای ستون‌ها در فریم متن تعریف کنید.

این کد PHP نشان می‌دهد چگونه یک ستون داخل فریم متن اضافه کنید:

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

Aspose.Slides به شما امکان تغییر یا به‌روزرسانی متن موجود در جعبه متن یا تمام متون موجود در یک ارائه را می‌دهد.

این کد PHP عملی را نشان می‌دهد که در آن تمام متون یک ارائه به‌روزرسانی یا تغییر می‌یابند:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # بررسی می‌کند که آیا شکل از فریم متن (IAutoShape) پشتیبانی می‌کند.
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # مرور پاراگراف‌ها در فریم متن
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # مرور هر بخش (portion) در پاراگراف
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// متن را تغییر می‌دهد

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// قالب‌بندی را تغییر می‌دهد

            }
          }
        }
      }
    }
    # ارائه اصلاح شده را ذخیره می‌کند
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **افزودن جعبه متن با لینک هیپرلینک** 

می‌توانید یک لینک را داخل جعبه متن قرار دهید. وقتی جعبه متن کلیک شود، کاربران به باز کردن لینک هدایت می‌شوند.

برای افزودن جعبه متنی که شامل لینک باشد، این مراحل را طی کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید.  
2. یک ارجاع به اولین اسلاید در ارائه تازه ایجاد‌شده به دست آورید.  
3. یک شیء `AutoShape` با `ShapeType` تنظیم‌شده به `Rectangle` در موقعیت مشخصی روی اسلاید اضافه کنید و ارجاع به شیء AutoShape تازه اضافه‌شده را دریافت کنید.  
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید که متن پیش‌فرض *Aspose TextBox* را در خود دارد.  
5. یک نمونه از کلاس `HyperlinkManager` ایجاد کنید.  
6. با استفاده از متد [setExternalHyperlinkClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) یک هیپرلینک به قسمتی از `TextFrame` که می‌خواهید پیوند دارد، اختصاص دهید.  
7. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید.  

این کد PHP — پیاده‌سازی مراحل بالا — نشان می‌دهد چگونه یک جعبه متن با لینک هیپرلینک به اسلاید اضافه کنید:

```php
  # یک شی Presentation ایجاد می‌کند که نمایانگر یک PPTX است
  $pres = new Presentation();
  try {
    # اولین اسلاید در ارائه را دریافت می‌کند
    $slide = $pres->getSlides()->get_Item(0);
    # یک شی AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
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

## **FAQ**

**تفاوت بین جعبه متن و نگهدارنده متن هنگام کار با اسلایدهای مستر چیست؟**

یک [placeholder](/slides/fa/php-java/manage-placeholder/) سبک/موقعیت خود را از [master](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) ارث می‌برد و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن معمولی یک شیء مستقل در یک اسلاید خاص است و هنگام تعویض طرح‌بندی تغییر نمی‌کند.

**چگونه می‌توانم تعویض متن به‌صورت دسته‌ای در تمام ارائه انجام دهم بدون اینکه به متن داخل نمودارها، جدول‌ها و SmartArt دست بزنم؟**

با پیمایش فقط AutoShape‌هایی که دارای فریم متن هستند، اشیای توکار مانند [charts](https://reference.aspose.com/slides/fa/php-java/aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/fa/php-java/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) را از جمله‌گیری یا حذف کنید؛ یا مجموعه‌های آن‌ها را جداگانه پیمایش کنید.