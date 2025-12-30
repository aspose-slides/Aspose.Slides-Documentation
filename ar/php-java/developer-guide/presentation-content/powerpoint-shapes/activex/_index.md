---
title: "إدارة عناصر التحكم ActiveX في العروض التقديمية باستخدام PHP"
linktitle: "ActiveX"
type: docs
weight: 80
url: /ar/php-java/activex/
keywords:
  - "ActiveX"
  - "عنصر تحكم ActiveX"
  - "إدارة ActiveX"
  - "إضافة ActiveX"
  - "تعديل ActiveX"
  - "مشغل وسائط"
  - "PowerPoint"
  - "عرض تقديمي"
  - "PHP"
  - "Aspose.Slides"
description: "تعلم كيف يستخدم Aspose.Slides لـ PHP عبر Java تقنية ActiveX لأتمتة وتحسين عروض PowerPoint التقديمية، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---

{{% alert color="primary" %}} 

تُستخدم عناصر تحكم ActiveX في العروض التقديمية. يتيح Aspose.Slides for PHP عبر Java إضافة وإدارة عناصر تحكم ActiveX، لكنها أصعب قليلًا في الإدارة مقارنةً بأشكال العرض العادية. لقد نفذنا دعمًا لإضافة عنصر تحكم Media Player النشط في Aspose.Slides. لاحظ أن عناصر تحكم ActiveX ليست أشكالًا؛ فهي ليست جزءًا من عرض التقديم's [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IShapeCollection). إنها جزء من [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection) المنفصل بدلاً من ذلك. في هذا الموضوع، سنوضح لك كيفية التعامل معها.

{{% /alert %}} 

## **إضافة عنصر تحكم Media Player ActiveX إلى شريحة**
لإضافة عنصر تحكم Media Player ActiveX، اتبع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتوليد عرض تقديمي فارغ.
2. الوصول إلى الشريحة المستهدفة في فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
3. إضافة عنصر تحكم Media Player ActiveX باستخدام طريقة [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/IControlCollection#addControl-int-float-float-float-float-) التي توفرها فئة [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection).
4. الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو باستخدام خصائصه.
5. حفظ العرض التقديمي كملف PPTX.

يعرض هذا الكود النموذجي، المستند إلى الخطوات أعلاه، طريقة إضافة عنصر تحكم Media Player ActiveX إلى شريحة:
```php
  # إنشاء مثيل عرض تقديمي فارغ
  $pres = new Presentation();
  try {
    # إضافة عنصر تحكم Media Player ActiveX
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # الوصول إلى عنصر تحكم Media Player ActiveX وتعيين مسار الفيديو
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # حفظ العرض التقديمي
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعديل عنصر تحكم ActiveX**
{{% alert color="primary" %}} 

تمتلك Aspose.Slides for PHP عبر Java الإصدار 7.1.0 والإصدارات الأحدث مكونات لإدارة عناصر تحكم ActiveX. يمكنك الوصول إلى عنصر التحكم ActiveX المضاف بالفعل في عرضك التقديمي وتعديل أو حذف ذلك عبر خصائصه.

{{% /alert %}} 

لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط على شريحة، اتبع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على عناصر تحكم ActiveX.
2. الحصول على مرجع الشريحة بواسطة مؤشرها.
3. الوصول إلى عناصر تحكم ActiveX في الشريحة عبر فئة [IControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControlCollection).
4. الوصول إلى عنصر تحكم TextBox1 ActiveX باستخدام كائن [IControl](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IControl).
5. تغيير خصائص عنصر تحكم TextBox1 ActiveX التي تشمل النص، الخط، ارتفاع الخط، وموقع الإطار.
6. الوصول إلى التحكم الثاني المسمى CommandButton1.
7. تغيير عنوان الزر، الخط، والموقع.
8. تحريك موقع إطارات عناصر تحكم ActiveX.
9. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يعرض هذا الكود النموذجي، المستند إلى الخطوات أعلاه، طريقة إدارة عنصر تحكم ActiveX بسيط: 
```php
  # الوصول إلى العرض التقديمي مع عناصر تحكم ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # الوصول إلى الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # تغيير نص مربع النص
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # تغيير صورة الاستبدال. PowerPoint سيستبدل هذه الصورة أثناء تفعيل ActiveX،
      # لذلك أحيانًا لا بأس بترك الصورة دون تغيير.
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
    # تغيير عناوين الزر
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # تغيير الاستبدال
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
    # تحريك 100 نقطة إلى الأسفل
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # إزالة عناصر التحكم
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يحتفظ Aspose.Slides بعناصر تحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة Java؟**

نعم. يتعامل Aspose.Slides معها كجزء من العرض التقديمي ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ ليس من الضروري تنفيذ عناصر التحكم نفسها للحفاظ عليها.

**كيف تختلف عناصر تحكم ActiveX عن كائنات OLE في العرض التقديمي؟**

عناصر تحكم ActiveX هي عناصر تحكم تفاعلية مُدارة (أزرار، مربعات نص، مشغل وسائط)، بينما تُشير [OLE](/slides/ar/php-java/manage-ole/) إلى كائنات تطبيق مدمجة (مثلاً ورقة عمل Excel). يتم تخزينها ومعالجتها بطريقة مختلفة وتملك نماذج خصائص مختلفة.

**هل تعمل أحداث ActiveX وماكرو VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**

يحافظ Aspose.Slides على العلامات والبيانات الوصفية الموجودة؛ ومع ذلك، تُنفّذ الأحداث والماكروهات فقط داخل PowerPoint على نظام Windows عندما تسمح الأمان بذلك. المكتبة لا تُنفّذ VBA.