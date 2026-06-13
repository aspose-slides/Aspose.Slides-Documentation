---
title: จัดการโครงการ VBA ในพรีเซนเทชั่นโดยใช้ PHP
linktitle: พรีเซนเทชั่นผ่าน VBA
type: docs
weight: 250
url: /th/php-java/presentation-via-vba/
keywords:
- มาโคร
- VBA
- มาโคร VBA
- เพิ่มมาโคร
- ลบมาโคร
- ดึงมาโคร
- เพิ่ม VBA
- ลบ VBA
- ดึง VBA
- PowerPoint
- OpenDocument
- พรีเซนเทชั่น
- PHP
- Aspose.Slides
description: "ค้นพบวิธีสร้างและจัดการพรีเซนเทชั่น PowerPoint และ OpenDocument ผ่าน VBA ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อปรับปรุงกระบวนการทำงานของคุณ"
---
## **บทนำ**

Aspose.Slides API มีคลาสสำหรับทำงานกับมาโครและโค้ด VBA

{{% alert title="Note" color="warning" %}} 
เมื่อคุณแปลงพรีเซนเทชั่นที่มีมาโครเป็นรูปแบบไฟล์อื่น (PDF, HTML ฯลฯ) Aspose.Slides จะละเลยมาโครทั้งหมด (มาโครจะไม่ถูกนำไปยังไฟล์ผลลัพธ์)

เมื่อคุณเพิ่มมาโครลงในพรีเซนเทชั่นหรือบันทึกพรีเซนเทชั่นที่มีมาโครใหม่ Aspose.Slides จะบันทึกไบต์ของมาโครเท่านั้น

Aspose.Slides **ไม่เคย** รันมาโครในพรีเซนเทชั่น
{{% /alert %}}

## **เพิ่ม VBA Macros**

Aspose.Slides ให้คลาส [VbaProject](https://reference.aspose.com/slides/th/php-java/aspose.slides/vbaproject/) เพื่อให้คุณสร้างโปรเจกต์ VBA (และการอ้างอิงโปรเจกต์) และแก้ไขโมดูลที่มีอยู่ คุณสามารถใช้คลาส `VbaProject` เพื่อจัดการ VBA ที่ฝังอยู่ในพรีเซนเทชั่นได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation)
1. ใช้คอนสตรัคเตอร์ของ [VbaProject](https://reference.aspose.com/slides/th/php-java/aspose.slides/vbaproject/#VbaProject) เพื่อเพิ่มโปรเจกต์ VBA ใหม่
1. เพิ่มโมดูลลงใน VbaProject
1. ตั้งค่าโค้ดต้นฉบับของโมดูล
1. เพิ่มการอ้างอิงไปยัง <stdole>
1. เพิ่มการอ้างอิงไปยัง **Microsoft Office**
1. เชื่อมโยงการอ้างอิงกับโปรเจกต์ VBA
1. บันทึกพรีเซนเทชั่น

โค้ด PHP ตัวอย่างต่อไปนี้แสดงวิธีเพิ่ม VBA macro ตั้งแต่ต้นจนถึงพรีเซนเทชั่น:

```php
  # สร้างอินสแตนซ์ของคลาสพรีเซนเทชั่น
  $pres = new Presentation();
  try {
    # สร้าง VBA Project ใหม่
    $pres->setVbaProject(new VbaProject());
    # เพิ่มโมดูลว่างลงใน VBA project
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # ตั้งค่าโค้ดต้นฉบับของโมดูล
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # สร้างการอ้างอิงไปยัง <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # สร้างการอ้างอิงไปยัง Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # เพิ่มการอ้างอิงลงใน VBA project
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # บันทึกพรีเซนเทชั่น
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
คุณอาจต้องการลองใช้ **Aspose** [Macro Remover](https://products.aspose.app/slides/th/remove-macros) ซึ่งเป็นเว็บแอปฟรีสำหรับลบมาโครจากไฟล์ PowerPoint, Excel และ Word
{{% /alert %}} 

## **ลบ VBA Macros**

โดยใช้คุณสมบัติ [VbaProject](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getVbaProject) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) คุณสามารถลบ VBA macro ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) แล้วโหลดพรีเซนเทชั่นที่มีมาโคร
1. เข้าถึงโมดูล Macro แล้วลบออก
1. บันทึกพรีเซนเทชั่นที่แก้ไขแล้ว

โค้ด PHP ตัวอย่างต่อไปนี้แสดงวิธีลบ VBA macro:

```php
  # โหลดพรีเซนเทชั่นที่มีมาโคร
  $pres = new Presentation("VBA.pptm");
  try {
    # เข้าถึงโมดูล Vba และลบออก
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # บันทึกพรีเซนเทชั่น
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ดึง VBA Macros**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) แล้วโหลดพรีเซนเทชั่นที่มีมาโคร
2. ตรวจสอบว่าพรีเซนเทชั่นมี VBA Project หรือไม่
3. วนลูปผ่านโมดูลทั้งหมดใน VBA Project เพื่อดูมาโคร

โค้ด PHP ตัวอย่างต่อไปนี้แสดงวิธีดึง VBA macros จากพรีเซนเทชั่นที่มีมาโคร:

```php
  # โหลดพรีเซนเทชั่นที่มีมาโคร
  $pres = new Presentation("VBA.pptm");
  try {
    # ตรวจสอบว่าพรีเซนเทชั่นมี VBA Project หรือไม่
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตรวจสอบว่า VBA Project ถูกป้องกันด้วยรหัสผ่านหรือไม่**

โดยใช้เมธอด [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/th/php-java/aspose.slides/vbaproject/#isPasswordProtected) คุณสามารถตรวจสอบได้ว่าโปรเจกต์มีการป้องกันด้วยรหัสผ่านหรือไม่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แล้วโหลดพรีเซนเทชั่นที่มีมาโคร
2. ตรวจสอบว่าพรีเซนเทชั่นมี [VBA project](https://reference.aspose.com/slides/th/php-java/aspose.slides/vbaproject/) หรือไม่
3. ตรวจสอบว่า VBA project ถูกป้องกันด้วยรหัสผ่านหรือไม่เพื่อดูคุณสมบัติของมัน

```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // ตรวจสอบว่าพรีเซนเทชั่นมีโปรเจกต์ VBA หรือไม่.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**เกิดอะไรขึ้นกับมาโครเมื่อฉันบันทึกพรีเซนเทชั่นเป็น PPTX?**

มาโครจะถูกลบออก เนื่องจาก PPTX ไม่รองรับ VBA หากต้องการเก็บมาโครให้เลือกใช้ PPTM, PPSM หรือ POTM

**Aspose.Slides สามารถรันมาโครในพรีเซนเทชั่นเพื่อเช่น การรีเฟรชข้อมูลได้หรือไม่?**

ไม่ได้ ไลบรารีไม่เคยดำเนินการโค้ด VBA; การทำงานนั้นทำได้เฉพาะใน PowerPoint ด้วยการตั้งค่าความปลอดภัยที่เหมาะสมเท่านั้น

**การทำงานกับ ActiveX controls ที่เชื่อมโยงกับโค้ด VBA ได้รับการสนับสนุนหรือไม่?**

ได้รับการสนับสนุน คุณสามารถเข้าถึง [ActiveX controls](/slides/th/php-java/activex/) ที่มีอยู่ ปรับเปลี่ยนคุณสมบัติของมันและลบออกได้ ซึ่งเป็นประโยชน์เมื่อมาโครโต้ตอบกับ ActiveX