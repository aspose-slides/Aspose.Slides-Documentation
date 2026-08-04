---
title: การปกป้องงานนำเสนอด้วยรหัสผ่านใน PHP
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/php-java/password-protected-presentation/
keywords:
- ล็อค PowerPoint
- ล็อกงานนำเสนอ
- ปลดล็อก PowerPoint
- ปลดล็อกงานนำเสนอ
- ป้องกัน PowerPoint
- ป้องกันงานนำเสนอ
- ตั้งรหัสผ่าน
- เพิ่มรหัสผ่าน
- เข้ารหัส PowerPoint
- เข้ารหัสงานนำเสนอ
- ถอดรหัส PowerPoint
- ถอดรหัสงานนำเสนอ
- การป้องกันการเขียน
- ความปลอดภัยของ PowerPoint
- ความปลอดภัยของงานนำเสนอ
- ลบรหัสผ่าน
- ลบการป้องกัน
- ลบการเข้ารหัส
- ปิดใช้งานรหัสผ่าน
- ปิดการป้องกัน
- ลบการป้องกันการเขียน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกงานนำเสนอ PowerPoint และ OpenDocument ที่ป้องกันด้วยรหัสผ่านอย่างง่ายดายด้วย Aspose.Slides สำหรับ PHP. รักษาความปลอดภัยของงานนำเสนอของคุณ."
---
## **บทนำ**

เมื่อคุณป้องกันการเข้าถึงงานนำเสนอด้วยรหัสผ่าน หมายความว่าคุณได้ตั้งรหัสผ่านที่บังคับใช้ข้อจำกัดบางอย่างในงานนำเสนอ เพื่อยกเลิกข้อจำกัดเหล่านั้น จำเป็นต้องใส่รหัสผ่าน งานนำเสนอที่ถูกป้องกันด้วยรหัสผ่านจะถือว่าเป็นงานนำเสนอที่ถูกล็อก

โดยทั่วไป คุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้ในงานนำเสนอได้:

- **Modification**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถแก้ไขงานนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการแก้ไขได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นแก้ไข เปลี่ยนแปลง หรือคัดลอกข้อมูลในงานนำเสนอของคุณ (หากไม่ได้ให้รหัสผ่าน)

  อย่างไรก็ตาม ในกรณีนี้ แม้ไม่มีรหัสผ่าน ผู้ใช้ก็ยังสามารถเข้าถึงเอกสารของคุณและเปิดมันได้ ในโหมดอ่านอย่างเดียว ผู้ใช้สามารถดูเนื้อหา หรือสิ่งต่าง ๆ เช่น ลิงก์, แอนิเมชัน, เอฟเฟ็กต์ ฯลฯ ภายในงานนำเสนอของคุณได้ แต่ไม่สามารถคัดลอกรายการหรือบันทึกงานนำเสนอได้

- **Opening**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นที่สามารถเปิดงานนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการเปิดได้ ข้อจำกัดนี้จะป้องกันไม่ให้คนอื่นแม้แต่ดูเนื้อหาของงานนำเสนอของคุณ (หากไม่ได้ให้รหัสผ่าน)

  ตามหลักการ ข้อจำกัดการเปิดยังป้องกันผู้ใช้จากการแก้ไขงานนำเสนอของคุณด้วย: เมื่อคนไม่สามารถเปิดงานนำเสนอได้ พวกเขาจะไม่สามารถทำการแก้ไขหรือเปลี่ยนแปลงใด ๆ ได้

  **Note** เมื่อคุณป้องกันงานนำเสนอด้วยรหัสผ่านเพื่อป้องกันการเปิดไฟล์ งานนำเสนอจะถูกเข้ารหัส

## **วิธีป้องกันงานนำเสนอด้วยรหัสผ่านออนไลน์**

1. ไปที่หน้า [**Aspose.Slides Lock**](https://products.aspose.app/slides/th/lock) ของเรา. 

   ![todo:image_alt_text](slides-lock.png)

2. คลิก **Drop or upload your files**.

3. เลือกไฟล์ที่คุณต้องการป้องกันด้วยรหัสผ่านบนคอมพิวเตอร์ของคุณ. 

4. ป้อนรหัสผ่านที่คุณต้องการสำหรับการป้องกันการแก้ไข; ป้อนรหัสผ่านที่คุณต้องการสำหรับการป้องกันการดู. 

5. หากคุณต้องการให้ผู้ใช้เห็นงานนำเสนอของคุณเป็นสำเนาสุดท้าย ให้ทำเครื่องหมายในช่องทำเครื่องหมาย **Mark as final**.

6. คลิก **PROTECT NOW.** 

7. คลิก **DOWNLOAD NOW.**

## **การป้องกันด้วยรหัสผ่านสำหรับงานนำเสนอใน Aspose.Slides**
**รูปแบบที่รองรับ**

Aspose.Slides รองรับการป้องกันด้วยรหัสผ่าน การเข้ารหัส และการดำเนินการที่คล้ายกันสำหรับงานนำเสนอในรูปแบบต่อไปนี้: 

- PPTX และ PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**การทำงานที่รองรับ**

Aspose.Slides ให้คุณใช้การป้องกันด้วยรหัสผ่านบนงานนำเสนอเพื่อป้องกันการแก้ไขในวิธีต่อไปนี้:

- การเข้ารหัสงานนำเสนอ
- การตั้งการป้องกันการเขียนให้กับงานนำเสนอ

**การทำงานอื่น ๆ**

Aspose.Slides ให้คุณทำงานอื่น ๆ ที่เกี่ยวข้องกับการป้องกันด้วยรหัสผ่านและการเข้ารหัสในวิธีต่อไปนี้:

- การถอดรหัสงานนำเสนอ; การเปิดงานนำเสนอที่เข้ารหัส
- การลบการเข้ารหัส; การปิดการป้องกันด้วยรหัสผ่าน
- การลบการป้องกันการเขียนจากงานนำเสนอ
- การรับคุณสมบัติของงานนำเสนอที่เข้ารหัส
- ตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่
- ตรวจสอบว่างานนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่.

## **เข้ารหัสงานนำเสนอ**

คุณสามารถเข้ารหัสงานนำเสนอโดยตั้งรหัสผ่าน จากนั้นเพื่อแก้ไขงานนำเสนอที่ถูกล็อก ผู้ใช้ต้องให้รหัสผ่าน

เพื่อเข้ารหัสหรือป้องกันงานนำเสนอด้วยรหัสผ่าน คุณต้องใช้เมธอด encrypt (จาก [ProtectionManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/)) เพื่อกำหนดรหัสผ่านให้กับงานนำเสนอ คุณส่งรหัสผ่านไปยังเมธอด encrypt แล้วใช้เมธอด save เพื่อบันทึกงานนำเสนอที่ถูกเข้ารหัสแล้ว

ตัวอย่างโค้ดนี้แสดงวิธีเข้ารหัสงานนำเสนอ:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **ตั้งการป้องกันการเขียนให้กับงานนำเสนอ**

คุณสามารถเพิ่มเครื่องหมาย “ห้ามแก้ไข” ลงในงานนำเสนอ วิธีนี้ทำให้คุณแจ้งผู้ใช้ว่าไม่ต้องการให้พวกเขาเปลี่ยนแปลงงานนำเสนอ

**Note** กระบวนการป้องกันการเขียนไม่ได้ทำให้งานนำเสนอถูกเข้ารหัส ดังนั้นผู้ใช้—หากต้องการจริง ๆ—สามารถแก้ไขงานนำเสนอได้ แต่เพื่อบันทึกการเปลี่ยนแปลง พวกเขาต้องสร้างงานนำเสนอใหม่โดยใช้ชื่ออื่น

เพื่อกำหนดการป้องกันการเขียน คุณต้องใช้เมธอด [setWriteProtection](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#setWriteProtection) ตัวอย่างโค้ดนี้แสดงวิธีตั้งการป้องกันการเขียนให้กับงานนำเสนอ:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **โหลดงานนำเสนอที่เข้ารหัส**

Aspose.Slides อนุญาตให้คุณโหลดไฟล์ที่เข้ารหัสโดยส่งรหัสผ่านของไฟล์ไปให้ เพื่อถอดรหัสงานนำเสนอ คุณต้องเรียกเมธอด [removeEncryption](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#removeEncryption) โดยไม่ต้องส่งพารามิเตอร์ใด ๆ แล้วคุณจะต้องใส่รหัสผ่านที่ถูกต้องเพื่อโหลดงานนำเสนอ

ตัวอย่างโค้ดนี้แสดงวิธีถอดรหัสงานนำเสนอ: 

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # ทำงานกับงานนำเสนอที่ถอดรหัสแล้ว
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **ลบการเข้ารหัสจากงานนำเสนอ**

คุณสามารถลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่านบนงานนำเสนอได้ วิธีนี้ทำให้ผู้ใช้สามารถเข้าถึงหรือแก้ไขงานนำเสนอได้โดยไม่มีข้อจำกัด

เพื่อลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่าน คุณต้องเรียกเมธอด [removeEncryption](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#removeEncryption) ตัวอย่างโค้ดนี้แสดงวิธีลบการเข้ารหัสจากงานนำเสนอ:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **ลบการป้องกันการเขียนจากงานนำเสนอ**

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนที่ใช้กับไฟล์งานนำเสนอ วิธีนี้ทำให้ผู้ใช้สามารถแก้ไขได้ตามต้องการและไม่แสดงคำเตือนใด ๆ เมื่อทำการดังกล่าว

คุณสามารถลบการป้องกันการเขียนจากงานนำเสนอโดยใช้เมธอด [removeWriteProtection](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#removeWriteProtection) ตัวอย่างโค้ดนี้แสดงวิธีลบการป้องกันการเขียนจากงานนำเสนอ:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **รับคุณสมบัติของงานนำเสนอที่เข้ารหัส**

โดยทั่วไป ผู้ใช้มักประสบปัญหาในการดึงคุณสมบัติของเอกสารจากงานนำเสนอที่ถูกเข้ารหัสหรือป้องกันด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่อนุญาตให้คุณป้องกันงานนำเสนอด้วยรหัสผ่านในขณะที่ยังคงให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสารได้

**หมายเหตุ:** ตามค่าเริ่มต้นเมื่อ Aspose.Slides เข้ารหัสงานนำเสนอ คุณสมบัติของเอกสารของงานนำเสนอนั้นก็จะถูกป้องกันด้วยรหัสผ่านด้วย หากคุณต้องการให้คุณสมบัติดังกล่าวสามารถเข้าถึงได้แม้หลังจากเข้ารหัส Aspose.Slides อนุญาตให้ทำได้โดยตรง

หากคุณต้องการให้ผู้ใช้ยังคงเข้าถึงคุณสมบัติของงานนำเสนอที่ถูกเข้ารหัส ให้ส่งค่า `false` ไปยังเมธอด [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ตัวอย่างโค้ดนี้แสดงวิธีเข้ารหัสงานนำเสนอพร้อมให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสาร:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **โหลดเฉพาะคุณสมบัติของเอกสารจากงานนำเสนอที่เข้ารหัส**

เพื่อสแกนข้อมูลเมตาของงานนำเสนอที่เข้ารหัสโดยไม่ต้องโหลดสไลด์หรือเนื้อหาอื่น ๆ ให้สร้างอ็อบเจกต์ [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/) แล้วส่งค่า `true` ไปยังเมธอด [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ในโหมดนี้ Aspose.Slides จะละเว้นรหัสผ่านและโหลดเฉพาะคุณสมบัติของเอกสารที่เปิดเผยต่อสาธารณะ

โค้ดตัวอย่างต่อไปนี้อ่านคุณสมบัติเอกสารแบบ built‑in และ custom ผ่านเมธอด [Presentation::getDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # อ่านคุณสมบัติเอกสารที่สร้างมาโดยอัตโนมัติ.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # อ่านคุณสมบัติเอกสารที่กำหนดเอง.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

การทำงานนี้ใช้ได้เฉพาะเมื่อคุณสมบัติของเอกสารถูกทิ้งให้เป็นสาธารณะ (ไม่เข้ารหัส) เวลาที่งานนำเสนอถูกเข้ารหัส หากคุณสมบัติถูกเข้ารหัส การส่งค่า `true` ไปยังเมธอด [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) จะทำให้เกิดข้อยกเว้น เพราะรหัสผ่านจะถูกละเว้นในโหมดนี้ เพื่อเข้าถึงคุณสมบัติที่เข้ารหัสหรือโหลดงานนำเสนอเต็มรูปแบบรวมสไลด์และเนื้อหาอื่น ๆ ให้ส่งรหัสผ่านที่ถูกต้องผ่านเมธอด [LoadOptions::setPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setPassword)

## **ตรวจสอบว่างานนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่**

ก่อนที่คุณจะโหลดงานนำเสนอ คุณอาจต้องการตรวจสอบและยืนยันว่าฝูงงานยังไม่ได้รับการป้องกันด้วยรหัสผ่าน วิธีนี้ช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่น ๆ ที่อาจเกิดขึ้นเมื่อโหลดงานนำเสนอที่ป้องกันด้วยรหัสผ่านโดยไม่มีรหัสผ่าน

โค้ด PHP นี้แสดงวิธีตรวจสอบงานนำเสนอว่ามีการป้องกันด้วยรหัสผ่านหรือไม่ (โดยไม่ต้องโหลดงานนำเสนอเอง):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **ตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides อนุญาตให้คุณตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่ เพื่อทำเช่นนี้คุณสามารถใช้เมธอด [isEncrypted](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#isEncrypted) ซึ่งจะคืนค่า `true` หากงานนำเสนอถูกเข้ารหัสหรือ `false` หากไม่ได้เข้ารหัส

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบว่างานนำเสนอถูกเข้ารหัสหรือไม่:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **ตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่**

Aspose.Slides อนุญาตให้คุณตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่ เพื่อทำเช่นนี้คุณสามารถใช้เมธอด [isWriteProtected](https://reference.aspose.com/slides/th/php-java/aspose.slides/protectionmanager/#isWriteProtected) ซึ่งจะคืนค่า `true` หากงานนำเสนอถูกป้องกันการเขียนหรือ `false` หากไม่ได้รับการป้องกัน

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบว่างานนำเสนอถูกป้องกันการเขียนหรือไม่:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **ตรวจสอบหรือยืนยันว่ามีการใช้รหัสผ่านเฉพาะหรือไม่**

คุณอาจต้องการตรวจสอบและยืนยันว่ามีการใช้รหัสผ่านเฉพาะเพื่อป้องกันเอกสารงานนำเสนอหรือไม่ Aspose.Slides มีวิธีให้คุณตรวจสอบรหัสผ่าน

ตัวอย่างโค้ดนี้แสดงวิธีตรวจสอบรหัสผ่าน:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # ตรวจสอบว่ารหัส “pass” ตรงกับ
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

มันจะคืนค่า `true` หากงานนำเสนอถูกเข้ารหัสด้วยรหัสผ่านที่ระบุ มิฉะนั้นจะคืนค่า `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/th/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับวิธีการเข้ารหัสแบบใด?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่รวมถึงอัลกอริธึมที่ใช้ AES ซึ่งให้ระดับความปลอดภัยสูงสำหรับงานนำเสนอของคุณ

**หากใส่รหัสผ่านผิดเมื่อพยายามเปิดงานนำเสนอจะเกิดอะไรขึ้น?**

ระบบจะโยนข้อยกเว้นแจ้งว่าการเข้าถึงงานนำเสนอถูกปฏิเสธ ซึ่งช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและปกป้องเนื้อหาของงานนำเสนอ

**มีผลกระทบต่อประสิทธิภาพหรือไม่เมื่อทำงานกับงานนำเสนอที่ป้องกันด้วยรหัสผ่าน?**

กระบวนการเข้ารหัสและถอดรหัสอาจทำให้มีค่าโอเวอร์เฮดเล็กน้อยระหว่างการเปิดและบันทึก ในส่วนใหญ่ผลกระทบต่อประสิทธิภาพจะไม่มากและไม่ส่งผลอย่างมีนัยสำคัญต่อระยะเวลาการประมวลผลทั้งหมดของงานนำเสนอของคุณ.