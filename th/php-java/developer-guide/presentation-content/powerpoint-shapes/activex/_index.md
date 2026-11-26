---
title: จัดการคอนโทรล ActiveX ในงานนำเสนอโดยใช้ PHP
linktitle: ActiveX
type: docs
weight: 80
url: /th/php-java/activex/
keywords:
- ActiveX
- คอนโทรล ActiveX
- จัดการ ActiveX
- เพิ่ม ActiveX
- แก้ไข ActiveX
- ตัวเล่นสื่อ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "แก้ไขกล่องข้อความและปุ่ม ActiveX, อัปเดตภาพตัวอย่างคอนโทรล, และใช้คอนโทรล Windows Media Player ซ้ำในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **Introduction**

คอนโทรล ActiveX ให้สไลด์ PowerPoint มีองค์ประกอบเชิงโต้ตอบ เช่น กล่องข้อความ ปุ่มคำสั่ง และเครื่องเล่นสื่อ Aspose.Slides สำหรับ PHP ผ่าน Java เปิดเผยคอนโทรลของสไลด์ผ่าน [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls) ใช้คอลเลคชันนี้เพื่อแก้ไขคอนโทรล ย้ายบนสไลด์ หรือเอาออก

## **List ActiveX Controls and Their Stored Properties**

เพื่อตรวจสอบเทมพลีตที่ไม่คุ้นเคย ให้เปิดเพื่ออ่านและวนลูปผ่านคอนโทรลบนแต่ละสไลด์ ตัวอย่างจะรายงานหมายเลขสไลด์ ชื่อคอนโทรล [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId) และแต่ละคู่คีย์‑ค่าใน [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) จะอ่านงานนำเสนอโดยไม่ทำให้คอนโทรลทำงาน เรียกเหตุการณ์หรือมาโคร เปลี่ยนค่า หรือบันทึกไฟล์

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์ที่เลือกจาก `ActiveX.pptm` แสดงกล่องข้อความและปุ่มคำสั่ง

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

คอลเลคชันคุณสมบัติว่างจะแสดงเป็น `[]` สำหรับคอนโทรลที่ใช้การจัดเก็บแบบไบนารี [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) สามารถคืนค่า `null` ซึ่งแสดงเป็น `Properties unavailable` หากคุณต้องการเพียงชื่อ ให้ใช้ [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) หลังตรวจสอบค่า null รายงานจะแสดงคุณสมบัติที่มีอยู่จากงานนำเสนอ คอนโทรลอาจสนับสนุนคุณสมบัติเพิ่มเติมขณะทำงาน

## **Modify ActiveX Controls**

ตัวอย่างคาดว่างานนำเสนอที่เปิดใช้งานมาโครมีกล่องข้อความชื่อ `TextBox1` และปุ่มคำสั่งชื่อ `CommandButton1` บนสไลด์แรก ใช้ [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) เพื่อเปลี่ยนค่ากล่องข้อความและคำบรรยายปุ่ม ทุกคอนโทรลยังมีภาพตัวอย่างคงที่ที่ PowerPoint สามารถแสดงก่อนทำงาน ให้จัดหา PNG สำหรับแต่ละคอนโทรลที่แสดงข้อความและลักษณะที่อัปเดต ตัวอย่างกำหนดภาพเหล่านี้ผ่าน [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat)

ตัวอย่างย้ายคอนโทรลทั้งหมดบนสไลด์แรกลง 100 จุดโดยกำหนดกรอบด้วย [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame) จากนั้นบันทึกงานนำเสนอที่แก้ไขในรูปแบบ PPTM แล้วใช้ [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) เพื่อบันทึกสำเนาที่สองโดยลบคอนโทรล ActiveX ทั้งหมดออกจากสไลด์นั้น

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```

## **Add an ActiveX Media Player Control**

เพื่อใช้คอนโทรล Windows Media Player ที่กำหนดค่าไว้แล้ว ให้เริ่มด้วยเทมพลีตที่สไลด์แรกมีผู้เล่นชื่อ `WindowsMediaPlayer1` [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) จะคัดลอกสไลด์ทั้งหมดไปยังงานนำเสนอใหม่ ตัวอย่างตั้งค่า `URL` ของผู้เล่นใน [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) และบันทึกสไลด์ที่คัดลอกเป็นสไลด์เดียวในผลลัพธ์ วิดีโอจะอยู่ภายนอก ดังนั้นให้เลือกเส้นทางที่ผู้เล่นสามารถเข้าถึงได้ขณะเล่น

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```

## **FAQ**

**Can Aspose.Slides preserve ActiveX controls without running them?**

ใช่ Aspose.Slides สามารถอ่านและบันทึกคอนโทรล รวมถึงคุณสมบัติและตำแหน่งได้โดยไม่ทำให้คอนโทรลทำงาน

**How do ActiveX controls differ from OLE objects?**

คอนโทรล ActiveX ให้ผู้ใช้โต้ตอบกับสไลด์ เช่น ป้อนข้อความหรือคลิกปุ่ม ส่วน [OLE object](/slides/th/php-java/manage-ole/) ให้สไลด์มีหรือเชื่อมโยงเนื้อหาที่จัดการโดยแอปพลิเคชันอื่น เช่น แผ่นงาน Excel

**Will ActiveX events still trigger VBA macros after I save a presentation with Aspose.Slides?**

บันทึกงานนำเสนอในรูปแบบที่เปิดใช้งานมาโครเช่น PPTM เพื่อรักษาโครงการ VBA ของคุณ PowerPoint สำหรับ Windows สามารถทำงานตัวจัดการเหตุการณ์ที่มีอยู่ได้เมื่อการตั้งค่าความปลอดภัยอนุญาตให้ใช้คอนโทรล ActiveX และมาโครพร้อมกัน