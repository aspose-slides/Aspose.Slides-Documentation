---
title: "จัดการคอนโทรล ActiveX ในการนำเสนอด้วย PHP"
linktitle: "ActiveX"
type: docs
weight: 80
url: /th/php-java/activex/
keywords:
- "ActiveX"
- "คอนโทรล ActiveX"
- "จัดการ ActiveX"
- "เพิ่ม ActiveX"
- "แก้ไข ActiveX"
- "สื่อเล่น"
- "PowerPoint"
- "การนำเสนอ"
- "PHP"
- "Aspose.Slides"
description: "เรียนรู้ว่าคุณสามารถใช้ Aspose.Slides for PHP via Java กับ ActiveX เพื่อทำงานอัตโนมัติและปรับปรุงการนำเสนอ PowerPoint อย่างไร ให้ผู้พัฒนามีการควบคุมสไลด์อย่างเต็มที่"
---
## **บทนำ**

คอนโทรล ActiveX ถูกใช้ในงานนำเสนอ Aspose.Slides for PHP via Java ช่วยให้คุณสามารถเพิ่มและจัดการคอนโทรล ActiveX ได้ แต่การจัดการคอนโทรลเหล่านี้ค่อนข้างซับซ้อนเมื่อเทียบกับรูปร่างทั่วไปในงานนำเสนอ เราได้เพิ่มการสนับสนุนการเพิ่ม Media Player Active control ใน Aspose.Slides โปรดทราบว่าคอนโทรล ActiveX ไม่ใช่รูปร่าง; พวกมันไม่ได้เป็นส่วนหนึ่งของ [ShapeCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/) ของงานนำเสนอ แต่เป็นส่วนหนึ่งของ [ControlCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/controlcollection/) แยกออกมา ในหัวข้อนี้ เราจะสาธิตวิธีการทำงานกับคอนโทรลเหล่านี้

## **เพิ่ม Media Player ActiveX Control ไปยังสไลด์**
เพื่อเพิ่มคอนโทรล Media Player ActiveX ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) และสร้างงานนำเสนอเปล่า
2. เข้าถึงสไลด์เป้าหมายใน [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)
3. ใช้เมธอด [addControl](https://reference.aspose.com/slides/th/php-java/aspose.slides/controlcollection/addcontrol/) ของ [ControlCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/controlcollection/) เพื่อเพิ่ม Media Player ActiveX control
4. เข้าถึง Media Player ActiveX control แล้วตั้งค่าพาธของวิดีโอผ่านคุณสมบัติของมัน
5. บันทึกงานนำเสนอเป็นไฟล์ PPTX

โค้ดตัวอย่างต่อไปนี้ซึ่งทำตามขั้นตอนข้างบนแสดงวิธีเพิ่ม Media Player ActiveX Control ไปยังสไลด์:

```php
  # สร้างอินสแตนซ์ของงานนำเสนอเปล่า
  $pres = new Presentation();
  try {
    # เพิ่ม Media Player ActiveX control
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # เข้าถึง Media Player ActiveX control และตั้งค่าพาธของวิดีโอ
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # บันทึกงานนำเสนอ
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **แก้ไข ActiveX Control**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java ตั้งแต่เวอร์ชัน 7.1.0 เป็นต้นไป มีคอมโพเนนต์สำหรับจัดการคอนโทรล ActiveX คุณสามารถเข้าถึงคอนโทรล ActiveX ที่ได้เพิ่มไว้ในงานนำเสนอและแก้ไขหรือทำการลบผ่านคุณสมบัติต่าง ๆ ได้

{{% /alert %}} 

เพื่อจัดการคอนโทรล ActiveX อย่างง่าย เช่น กล่องข้อความและปุ่มคำสั่งบนสไลด์ ให้ทำดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) และโหลดงานนำเสนอที่มีคอนโทรล ActiveX อยู่แล้ว
2. รับอ้างอิงสไลด์ตามตำแหน่งดัชนี
3. เข้าถึงคอนโทรล ActiveX ในสไลด์โดยการเข้าถึง [ControlCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/controlcollection/)
4. เข้าถึงคอนโทรล TextBox1 ActiveX ผ่านออบเจ็กต์ [Control](https://reference.aspose.com/slides/th/php-java/aspose.slides/control/)
5. เปลี่ยนคุณสมบัติของ TextBox1 ActiveX control ซึ่งรวมถึงข้อความ, ฟอนต์, ความสูงของฟอนต์, และตำแหน่งกรอบ
6. เข้าถึงคอนโทรลที่สองที่ชื่อ CommandButton1
7. เปลี่ยนข้อความของปุ่ม, ฟอนต์, และตำแหน่ง
8. ย้ายตำแหน่งของกรอบคอนโทรล ActiveX
9. เขียนงานนำเสนอที่แก้ไขแล้วลงไฟล์ PPTX

โค้ดตัวอย่างต่อไปนี้ซึ่งทำตามขั้นตอนข้างบนแสดงวิธีจัดการคอนโทรล ActiveX อย่างง่าย:

```php
  # เข้าถึงงานนำเสนอที่มีคอนโทรล ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # เข้าถึงสไลด์แรกในงานนำเสนอ
    $slide = $pres->getSlides()->get_Item(0);
    # เปลี่ยนข้อความของ TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # เปลี่ยนรูปภาพทดแทน PowerPoint จะเปลี่ยนรูปนี้ในระหว่างการเปิดใช้งาน ActiveX,
      # ดังนั้นบางครั้งจึงสามารถปล่อยให้รูปภาพไม่มีการเปลี่ยนแปลงได้.
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
    # เปลี่ยนข้อความปุ่ม
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # เปลี่ยนรูปภาพทดแทน
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
    # ย้ายลง 100 จุด
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # ลบคอนโทรล
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**Aspose.Slides จะรักษาคอนโทรล ActiveX ไว้เมื่ออ่านและบันทึกใหม่หรือไม่ หากไม่สามารถดำเนินการคอนโทรลเหล่านั้นใน runtime ของ Java ได้?**

ใช่ Aspose.Slides ถือคอนโทรลเหล่านี้เป็นส่วนหนึ่งของงานนำเสนอและสามารถอ่าน/แก้ไขคุณสมบัติและกรอบของพวกมันได้; ไม่จำเป็นต้องดำเนินการคอนโทรลเองเพื่อรักษาไว้

**คอนโทรล ActiveX แตกต่างจากวัตถุ OLE ในงานนำเสนออย่างไร?**

คอนโทรล ActiveX เป็นคอนโทรลที่โต้ตอบและจัดการได้ (เช่น ปุ่ม, กล่องข้อความ, Media Player) ในขณะที่ [OLE](/slides/th/php-java/manage-ole/) หมายถึงวัตถุแอปพลิเคชันที่ฝังอยู่ (เช่น Worksheet ของ Excel) ทั้งสองถูกจัดเก็บและจัดการด้วยวิธีที่แตกต่างกันและมีโมเดลคุณสมบัติที่ต่างกัน

**เหตุการณ์ ActiveX และแมโคร VBA ทำงานได้หรือไม่ หากไฟล์ถูกแก้ไขโดย Aspose.Slides?**

Aspose.Slides จะรักษา markup และเมตาดาต้าที่มีอยู่เดิมไว้; อย่างไรก็ตามเหตุการณ์และแมโครจะทำงานเฉพาะใน PowerPoint บน Windows เมื่อความปลอดภัยอนุญาต ไม่ได้มีการรัน VBA โดยไลบรารีนี้