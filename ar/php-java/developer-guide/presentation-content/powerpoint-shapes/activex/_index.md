---
title: إدارة عناصر التحكم ActiveX في العروض التقديمية باستخدام PHP
linktitle: ActiveX
type: docs
weight: 80
url: /ar/php-java/activex/
keywords:
- ActiveX
- تحكم ActiveX
- إدارة ActiveX
- إضافة ActiveX
- تعديل ActiveX
- مشغل وسائط
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرف على كيفية استفادة Aspose.Slides لـ PHP عبر Java من ActiveX لأتمتة وتحسين عروض PowerPoint التقديمية، مما يمنح المطورين تحكمًا قويًا في الشرائح."
---

{{% alert color="primary" %}} 

تُستخدم عناصر التحكم ActiveX في العروض التقديمية. يتيح لك Aspose.Slides لـ PHP عبر Java إضافة وإدارة عناصر التحكم ActiveX، لكنها أصعب قليلاً في الإدارة مقارنةً بأشكال العرض العادية. لقد نفّذنا دعمًا لإضافة عنصر تحكم Media Player Active في Aspose.Slides. لاحظ أن عناصر التحكم ActiveX ليست أشكالًا؛ فهي ليست جزءًا من [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/). بل هي جزء من [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/) بدلاً من ذلك. في هذا الموضوع، سنُظهر لك كيفية العمل معها.

{{% /alert %}} 

## **إضافة عنصر تحكم Media Player ActiveX إلى شريحة**
لإضافة عنصر تحكم Media Player ActiveX، اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وأنشئ عرضًا تقديميًا فارغًا.  
2. الوصول إلى الشريحة المستهدفة في [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
3. أضف عنصر تحكم Media Player ActiveX باستخدام الطريقة [addControl](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/addcontrol/) المعروضة من قبل [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/).  
4. الوصول إلى عنصر تحكم Media Player ActiveX وتحديد مسار الفيديو باستخدام خصائصه.  
5. احفظ العرض التقديمي كملف PPTX.  

يُظهر رمز العينة هذا، بناءً على الخطوات السابقة، كيفية إضافة عنصر تحكم Media Player ActiveX إلى شريحة:
```php
  # إنشاء مثيل عرض تقديمي فارغ
  $pres = new Presentation();
  try {
    # إضافة عنصر تحكم Media Player ActiveX
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # الوصول إلى عنصر تحكم Media Player ActiveX وتحديد مسار الفيديو
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

يتم تزويد Aspose.Slides لـ PHP عبر Java الإصدار 7.1.0 والإصدارات الأ newer بمكونات لإدارة عناصر التحكم ActiveX. يمكنك الوصول إلى عنصر التحكم ActiveX المضاف مسبقًا في عرضك التقديمي وتعديل أو حذف ذلك عبر خصائصه.

{{% /alert %}} 

لإدارة عنصر تحكم ActiveX بسيط مثل مربع نص وزر أمر بسيط في شريحة، اتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وحمّل العرض التقديمي الذي يحتوي على عناصر التحكم ActiveX.  
2. احصل على مرجع الشريحة باستخدام الفهرس الخاص بها.  
3. الوصول إلى عناصر التحكم ActiveX في الشريحة عبر الوصول إلى [ControlCollection](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/).  
4. الوصول إلى عنصر التحكم TextBox1 ActiveX باستخدام كائن [Control](https://reference.aspose.com/slides/php-java/aspose.slides/control/).  
5. تغيير خصائص عنصر التحكم TextBox1 ActiveX التي تشمل النص، الخط، ارتفاع الخط، وموقع الإطار.  
6. الوصول إلى عنصر التحكم الثاني المسمى CommandButton1.  
7. تغيير تسمية الزر، الخط، والموقع.  
8. تحريك موضع إطارات عناصر التحكم ActiveX.  
9. اكتب العرض التقديمي المعدل إلى ملف PPTX.  

يُظهر رمز العينة هذا، بناءً على الخطوات السابقة، كيفية إدارة عنصر تحكم ActiveX بسيط: 
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
      # تغيير صورة البديل. سيستبدل PowerPoint هذه الصورة أثناء تنشيط ActiveX،
      # لذلك في بعض الأحيان يمكن ترك الصورة دون تعديل.
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
    # تغيير تسمية الزر
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
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

**هل يحتفظ Aspose.Slides بعناصر التحكم ActiveX عند القراءة وإعادة الحفظ إذا لم يمكن تنفيذها في بيئة تشغيل Java؟**  
نعم. يتعامل Aspose.Slides معها كجزء من العرض التقديمي ويمكنه قراءة/تعديل خصائصها وإطاراتها؛ لا يلزم تنفيذ العناصر نفسها لحفظها.

**كيف تختلف عناصر التحكم ActiveX عن كائنات OLE في العرض التقديمي؟**  
عناصر التحكم ActiveX هي عناصر تحكم تفاعلية مُدارة (أزرار، مربعات نص، مشغل وسائط)، بينما تشير [OLE](/slides/ar/php-java/manage-ole/) إلى كائنات تطبيق مدمجة (مثل ورقة عمل Excel). تُخزن وتُدار بشكل مختلف وتملك نماذج خصائص مختلفة.

**هل تعمل أحداث ActiveX والماكروهات VBA إذا تم تعديل الملف بواسطة Aspose.Slides؟**  
يحافظ Aspose.Slides على العلامات الوصفية والبيانات الوصفية الحالية؛ ومع ذلك، تُنفّذ الأحداث والماكروهات فقط داخل PowerPoint على Windows عندما تسمح الأمان بذلك. المكتبة لا تقوم بتنفيذ VBA.