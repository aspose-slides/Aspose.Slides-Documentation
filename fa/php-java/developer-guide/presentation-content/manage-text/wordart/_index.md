---
title: ایجاد و اعمال اثرات WordArt در PHP
linktitle: WordArt
type: docs
weight: 110
url: /fa/php-java/wordart/
keywords:
- WordArt
- ایجاد WordArt
- قالب WordArt
- اثر WordArt
- اثر سایه
- اثر نمایش
- اثر درخشندگی
- تبدیل WordArt
- اثر 3D
- اثر سایه خارجی
- اثر سایه داخلی
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اثرات WordArt در Aspose.Slides برای PHP از طریق Java. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متنی حرفه‌ای بهبود بخشند."
---
## **بازنگری**

اثرات WordArt به شما امکان می‌دهند متن‌های زیبا و استایل‌دار را به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides، توسعه‌دهندگان می‌توانند به‌صورت برنامه‌نویسی WordArt را ایجاد، سفارشی‌سازی و مدیریت کنند، دقیقاً مانند Microsoft PowerPoint—بدون نیاز به نصب Office. این مقاله نگاهی کلی به کار با WordArt ارائه می‌دهد، شامل نحوه اعمال تبدیل‌های متنی، سبک‌های پر، خطوط پیرامون، سایه‌ها و سایر گزینه‌های قالب‌بندی برای جذاب‌تر و بیانگرتر شدن محتوای ارائه شما. WordArt به شما اجازه می‌دهد متن را به‌عنوان یک شی گرافیکی در نظر بگیرید. این اثرها یا تغییرات ویژه‌ای هستند که بر متن اعمال می‌شوند تا جذاب‌تر یا قابل‌توجه‌تر شود.

## **ایجاد یک الگوی ساده WordArt و اعمال آن بر متن**

**با استفاده از Aspose.Slides** 

در ابتدا، با این کد PHP یک متن ساده می‌سازیم:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
حالا، ارتفاع فونت متن را به مقادیر بزرگتر تنظیم می‌کنیم تا اثر واضح‌تر باشد:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**با استفاده از Microsoft PowerPoint**

به منوی اثرات WordArt در Microsoft PowerPoint بروید:

![todo:image_alt_text](image-20200930113926-1.png)

از منوی سمت راست می‌توانید یک اثر WordArt پیش‌تعریف‌شده را انتخاب کنید. از منوی سمت چپ می‌توانید تنظیمات یک WordArt جدید را مشخص کنید.

برخی از پارامترها یا گزینه‌های موجود:

![todo:image_alt_text](image-20200930114015-3.png)

**با استفاده از Aspose.Slides**

در اینجا، الگوی رنگی [SmallGrid](https://reference.aspose.com/slides/fa/php-java/aspose.slides/patternstyle/#SmallGrid) را به متن اعمال می‌کنیم و با این کد یک حاشیهٔ متن سیاه با عرض 1 اضافه می‌کنیم:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

متن حاصل:

![todo:image_alt_text](image-20200930114108-4.png)

## **اعمال دیگر اثرات WordArt**

**با استفاده از Microsoft PowerPoint**

از رابط برنامه می‌توانید این اثرات را بر متن، بلوک متن، شکل یا عنصر مشابهی اعمال کنید:

![todo:image_alt_text](image-20200930114129-5.png)

به عنوان مثال، اثرات Shadow، Reflection و Glow می‌توانند بر متن اعمال شوند؛ اثرات 3D Format و 3D Rotation می‌توانند بر بلوک متن اعمال شوند؛ ویژگی Soft Edges می‌تواند بر یک Shape Object اعمال شود (یک اثر حتی زمانی که خاصیت 3D Format تنظیم نشده باشد، دارد).

### **اعمال اثرات سایه**

در اینجا قصد داریم خصوصیات مربوط به فقط متن را تنظیم کنیم. اثر سایه را با این کد بر متن اعمال می‌کنیم:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);

```

API Aspose.Slides از سه نوع سایه پشتیبانی می‌کند: OuterShadow، InnerShadow و PresetShadow.

با PresetShadow می‌توانید سایه‌ای برای متن اعمال کنید (با استفاده از مقادیر پیش‌تعریف‌شده).

**با استفاده از Microsoft PowerPoint**

در PowerPoint می‌توانید از یک نوع سایه استفاده کنید. نمونه‌ای در زیر آمده است:

![todo:image_alt_text](image-20200930114225-6.png)

**با استفاده از Aspose.Slides**

Aspose.Slides در واقع به شما اجازه می‌دهد دو نوع سایه را همزمان اعمال کنید: InnerShadow و PresetShadow.

**نکات:**

- وقتی OuterShadow و PresetShadow با هم استفاده شوند، فقط اثر OuterShadow اعمال می‌شود. 
- اگر OuterShadow و InnerShadow همزمان استفاده شوند، اثر نهایی یا اعمال‌شده به نسخهٔ PowerPoint بستگی دارد. به عنوان مثال، در PowerPoint 2013 اثر دو برابر می‌شود؛ اما در PowerPoint 2007، اثر OuterShadow اعمال می‌شود.

### **اعمال اثرات بازتاب بر متن**

با این نمونه کد نمایش را به متن اضافه می‌کنیم:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```

### **اعمال اثرات درخشندگی (Glow) بر متن**

با این کد اثر درخشندگی را بر متن اعمال می‌کنیم تا بدرخشد یا متمایز شود:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

نتیجه عملیات:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

می‌توانید پارامترهای سایه، نمایش و درخشندگی را تغییر دهید. خصوصیات اثرها به‌صورت جداگانه بر هر بخش از متن تنظیم می‌شود. 

{{% /alert %}} 

### **استفاده از تبدیلات در WordArt**

با این کد از خصوصیت Transform (که به کل بلوک متن اعمال می‌شود) استفاده می‌کنیم:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);

```

نتیجه:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

هر دو Microsoft PowerPoint و Aspose.Slides برای PHP via Java تعداد معینی از انواع تبدیلات پیش‌تعریف‌شده را ارائه می‌دهند.

{{% /alert %}} 

**با استفاده از PowerPoint**

برای دسترسی به انواع تبدیلات پیش‌تعریف‌شده، از مسیر زیر استفاده کنید: **Format** -> **TextEffect** -> **Transform**

**با استفاده از Aspose.Slides**

برای انتخاب نوع تبدیلات، از enum `TextShapeType` استفاده کنید.

### **اعمال اثرات 3D بر متن و اشکال**

با این نمونه کد یک اثر 3D بر شکل متن اعمال می‌کنیم:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

نتیجهٔ متن و شکل آن:

![todo:image_alt_text](image-20200930114816-9.png)

اثر 3D را بر متن با این کد PHP اعمال می‌کنیم:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

نتیجهٔ عملیات:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

اعمال اثرات 3D بر متن یا شکل‌های آن و تعامل بین اثرات بر اساس قواعد خاصی انجام می‌شود.

یک صحنه برای متن و شکلی که آن متن را دربرمی‌گیرد در نظر بگیرید. اثر 3D شامل نمایش شی 3D و صحنه‌ای است که شی در آن قرار می‌گیرد.

- وقتی صحنه برای هر دو شکل و متن تنظیم شده باشد، اولویت به صحنهٔ شکل می‌رسد—صحنهٔ متن نادیده گرفته می‌شود. 
- وقتی شکل صحنهٔ خود را ندارد اما نمایش 3D دارد، صحنهٔ متن استفاده می‌شود. 
- در غیر این صورت—وقتی شکل در ابتدا هیچ اثر 3D ندارد—شکل مسطح است و اثر 3D فقط بر متن اعمال می‌شود. 

این توضیحات به متدهای `ThreeDFormat.getLightRig()` و `ThreeDFormat.getCamera()` مرتبط هستند.

{{% /alert %}} 

## **اعمال اثر Outer Shadow بر متن**
Aspose.Slides برای PHP via Java کلاس‌های [OuterShadow](https://reference.aspose.com/slides/fa/php-java/aspose.slides/outershadow/) و [InnerShadow](https://reference.aspose.com/slides/fa/php-java/aspose.slides/innershadow/) را فراهم می‌کند که به شما اجازه می‌دهند اثرات سایه را بر متنی که توسط [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) حمل می‌شود، اعمال کنید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را با استفاده از اندیس آن دریافت کنید.  
3. یک AutoShape از نوع Rectangle به اسلاید اضافه کنید.  
4. به TextFrame مرتبط با AutoShape دسترسی پیدا کنید.  
5. FillType خودکارشکل را به NoFill تنظیم کنید.  
6. کلاس OuterShadow را نمونه‌سازی کنید.  
7. BlurRadius سایه را تنظیم کنید.  
8. Direction سایه را تنظیم کنید.  
9. Distance سایه را تنظیم کنید.  
10. RectanglelAlign را به TopLeft تنظیم کنید.  
11. PresetColor سایه را به Black تنظیم کنید.  
12. ارائه را به عنوان یک فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) نوشتن کنید.

این کد نمونه —پیاده‌سازی مراحل فوق— نشان می‌دهد چگونه اثر Outer Shadow را به متن اعمال کنید:

```php
  $pres = new Presentation();
  try {
    # دریافت ارجاع اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # اضافه کردن AutoShape از نوع Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # افزودن TextFrame به Rectangle
    $ashp->addTextFrame("Aspose TextBox");
    # غیرفعال کردن پر کردن شکل در صورتی که می‌خواهیم سایه متن را دریافت کنیم
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # اضافه کردن سایه بیرونی و تنظیم تمام پارامترهای لازم
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # نوشتن ارائه به دیسک
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **اعمال اثر Inner Shadow بر اشکال**
مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع اسلاید را دریافت کنید.  
3. یک AutoShape از نوع Rectangle اضافه کنید.  
4. InnerShadowEffect را فعال کنید.  
5. تمام پارامترهای لازم را تنظیم کنید.  
6. ColorType را به Scheme تنظیم کنید.  
7. رنگ Scheme را تنظیم کنید.  
8. ارائه را به‌صورت یک فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) نوشتن کنید.

این کد نمونه (بر پایهٔ مراحل بالا) نشان می‌دهد چگونه یک connector بین دو شکل اضافه کنید:

```php
  $pres = new Presentation();
  try {
    # دریافت ارجاع اسلاید
    $slide = $pres->getSlides()->get_Item(0);
    # اضافه کردن AutoShape از نوع Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # افزودن TextFrame به Rectangle
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # فعال‌سازی InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # تنظیم تمام پارامترهای لازم
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # تنظیم ColorType به عنوان Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # تنظیم Scheme Color
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # ذخیره ارائه
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سؤالات متداول**

**آیا می‌توانم اثرات WordArt را با فونت‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides از یونیکد پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. اثرات WordArt مانند سایه، پر و خط بیرونی می‌توانند بدون توجه به زبان اعمال شوند، اگرچه در دسترس بودن فونت و رندرینگ ممکن است به فونت‌های سیستم وابسته باشد.

**آیا می‌توانم اثرات WordArt را بر عناصر اسلاید مستر اعمال کنم؟**

بله، می‌توانید اثرات WordArt را بر اشکال موجود در اسلایدهای مستر، شامل فضاهای نگه‌دارندهٔ عنوان، فوترها یا متن پس‌زمینه اعمال کنید. تغییرات اعمال‌شده بر طرح مستر در تمام اسلایدهای مرتبط بازتاب خواهد یافت.

**آیا اثرات WordArt بر حجم فایل ارائه تاثیر می‌گذارند؟**

به‌صورت جزئی. اثراتی مانند سایه، درخشندگی و پرهای گرادیان ممکن است به‌دلیل اضافه شدن متادیتای قالب‌بندی، حجم فایل را کمی افزایش دهند، اما تفاوت معمولاً ناچیز است.

**آیا می‌توانم نتیجهٔ اثرات WordArt را بدون ذخیره‌سازی ارائه پیش‌نمایش کنم؟**

بله، می‌توانید اسلایدهای شامل WordArt را به تصاویر (مثلاً PNG، JPEG) رندر کنید با استفاده از متد `getImage` از کلاس‌های [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) یا [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/). این کار به شما امکان می‌دهد نتیجه را در‑حافظه یا روی صفحه قبل از ذخیره یا خروجی‌گیری از کل ارائه پیش‌نمایش کنید.