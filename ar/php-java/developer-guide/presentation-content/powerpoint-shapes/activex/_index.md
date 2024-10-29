---
title: ActiveX
type: docs
weight: 80
url: /ar/php-java/activex/
---


{{% alert color="primary" %}} 

تُستخدم عناصر التحكم ActiveX في العروض التقديمية. تسمح لك Aspose.Slides لـ PHP عبر Java بإضافة وإدارة عناصر التحكم ActiveX، ولكن من الصعب إدارتها قليلاً مقارنةً بأشكال العرض التقديمي العادية. لقد قمنا بتنفيذ الدعم لإضافة عنصر التحكم النشط لمشغّل الوسائط في Aspose.Slides. لاحظ أن عناصر التحكم ActiveX ليست أشكالاً؛ فهي ليست جزءاً من [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IShapeCollection) الخاصة بالعروض التقديمية. بل هي جزء من [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection) بدلاً من ذلك. في هذا الموضوع، سنعرض لك كيفية العمل معهم.

{{% /alert %}} 

## **إضافة عنصر التحكم ActiveX لمشغّل الوسائط إلى الشريحة**
لإضافة عنصر التحكم ActiveX لمشغّل الوسائط، اتبع الخطوات التالية:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وأنشئ مثيل عرض تقديمي فارغ.
1. الوصول إلى الشريحة المستهدفة في [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. إضافة عنصر التحكم ActiveX لمشغّل الوسائط باستخدام الطريقة [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/IControlCollection#addControl-int-float-float-float-float-) المتاحة في [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection).
1. الوصول إلى عنصر التحكم ActiveX لمشغّل الوسائط وضبط مسار الفيديو من خلال خصائصه.
1. احفظ العرض التقديمي كملف PPTX.

يوضح كود العينة هذا، بناءً على الخطوات أعلاه، كيفية إضافة عنصر التحكم ActiveX لمشغّل الوسائط إلى شريحة:

```php
  # إنشاء مثيل عرض تقديمي فارغ
  $pres = new Presentation();
  try {
    # إضافة عنصر التحكم ActiveX لمشغّل الوسائط
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # الوصول إلى عنصر التحكم ActiveX لمشغّل الوسائط وضبط مسار الفيديو
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # حفظ العرض التقديمي
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعديل عنصر التحكم ActiveX**
{{% alert color="primary" %}} 

تحتوي Aspose.Slides لـ PHP عبر Java 7.1.0 والإصدارات الأحدث على مكونات لإدارة عناصر التحكم ActiveX. يمكنك الوصول إلى عنصر التحكم ActiveX المضاف بالفعل في العرض التقديمي الخاص بك وتعديله أو حذفه من خلال خصائصه.

{{% /alert %}} 

لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة، اتبع الخطوات التالية:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وقم بتحميل العرض التقديمي الذي يحتوي على عناصر التحكم ActiveX.
1. احصل على مرجع الشريحة من خلال فهرسها.
1. الوصول إلى عناصر التحكم ActiveX في الشريحة من خلال الوصول إلى [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection).
1. الوصول إلى عنصر التحكم ActiveX TextBox1 باستخدام كائن [IControl](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControl).
1. تغيير خصائص عنصر التحكم ActiveX TextBox1 التي تتضمن النص، الخط، ارتفاع الخط، وموقع الإطار.
1. الوصول إلى عنصر التحكم الثاني الذي يسمى CommandButton1.
1. تغيير عنوان الزر، الخط، والموقع.
1. نقل مواقع إطارات عناصر التحكم ActiveX.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يوضح كود العينة هذا، بناءً على الخطوات أعلاه، كيفية إدارة عنصر تحكم ActiveX بسيط:

```php
  # الوصول إلى العرض التقديمي بعناصر التحكم ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # الوصول إلى الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # تغيير نص TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "النص المعدل";
      $control->getProperties()->set_Item("Value", $newText);
      # تغيير صورة البديل. سيقوم PowerPoint باستبدال هذه الصورة أثناء تفعيل ActiveX،
      # لذا في بعض الأحيان يكون من الجيد ترك الصورة دون تغيير.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # تغيير عنوان الزر
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "عرض مربع الرسالة";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # تغيير البديل
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # التحريك 100 نقطة للأسفل
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # إزالة العناصر
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```