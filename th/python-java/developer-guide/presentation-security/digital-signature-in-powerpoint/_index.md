---
title: เพิ่มลายเซ็นดิจิทัลให้กับงานนำเสนอใน Python
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/python-java/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยการออกใบรับรอง
- ใบรับรอง PFX
- PKCS#12
- ตรวจสอบความถูกต้องของลายเซ็น
- PowerPoint
- PPTX
- ความปลอดภัยของงานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีเซ็นงานนำเสนอ PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อตรวจสอบหรือถอนลายเซ็นดิจิทัล"
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยผู้รับระบุได้ว่าใครเป็นผู้เซ็นงานนำเสนอและเนื้อหาที่เซ็นมีการเปลี่ยนแปลงหรือไม่ แนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการมีความสำคัญที่นี่:

- **ดิจิทัลเซอร์ติฟิเคท** คือข้อมูลประจำตัวอิเล็กทรอนิกส์ที่เชื่อมโยงระบุตัวตนกับคีย์สาธารณะ หน่วยการออกใบรับรองที่เชื่อถือได้ (CA) สามารถออกใบรับรองได้ หรือองค์กรอาจใช้ใบรับรองที่เซ็นด้วยตนเองสำหรับกระบวนการภายใน
- **ดิจิทัลลายเซ็น** ถูกสร้างจากเนื้อหาในงานนำเสนอและคีย์ส่วนตัวของผู้ถือใบรับรอง คีย์สาธารณะของใบรับรองสามารถใช้ตรวจสอบลายเซ็นได้ ลายเซ็นเป็นหลักฐานของต้นทางและความสมบูรณ์; ไม่ได้เข้ารหัสงานนำเสนอ
- **การป้องกันด้วยรหัสผ่าน** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขงานนำเสนอได้หรือไม่ แยกจากการเซ็นดิจิทัลและอธิบายเพิ่มเติมใน [Password‑Protected Presentations](/slides/th/python-java/password-protected-presentation/)

PowerPoint มีคำสั่ง **Add a Digital Signature** ภายใต้ **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint ที่ไฮไลท์ Add a Digital Signature](add-digital-signature-in-powerpoint.png)

เมื่อเปิดงานนำเสนอที่มีลายเซ็น PowerPoint จะสามารถแสดงการแจ้งเตือนสถานะลายเซ็น

![การแจ้งเตือนของ PowerPoint บอกว่ารายการนำเสนอมีลายเซ็นที่ถูกต้อง](digital-signature-status-in-powerpoint.png)

Aspose.Slides ทำให้สามารถเข้าถึงลายเซ็นผ่าน [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getDigitalSignatures) ซึ่งจะคืนค่าเป็น [DigitalSignatureCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/digitalsignaturecollection/) ที่ประกอบด้วยอ็อบเจกต์ประเภท [DigitalSignature](https://reference.aspose.com/slides/th/python-java/aspose.slides/digitalsignature/) งานนำเสนออาจมีลายเซ็นหลายรายการได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX หรือที่รู้จักในชื่อไฟล์ PKCS#12 โดยมักใช้ส่วนขยาย `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, คีย์ส่วนตัวของมัน, และสายใบรับรอง คีย์ส่วนตัวคือสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีคีย์ส่วนตัวที่เข้าถึงได้ไม่สามารถใช้เซ็นงานนำเสนอได้

รหัสผ่าน PFX ปกป้องแพ็คเกจใบรับรองและคีย์ส่วนตัว **ไม่ใช่** รหัสผ่านสำหรับเปิดหรือแก้ไขงานนำเสนอ อย่า commit ไฟล์ PFX หรือรหัสผ่านของมันลงใน source control ในสภาพแวดล้อม production ควรจำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ได้รับการปกป้อง ตัวอย่างด้านล่างใช้ตัวแปรสภาพแวดล้อมเพียงเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลในงานนำเสนอ**

เพื่อเซ็นกระบวนการทำงานของงานนำเสนอจริง ให้โหลดไฟล์ PPTX ที่มีอยู่แล้ว สร้าง [DigitalSignature](https://reference.aspose.com/slides/th/python-java/aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน เพิ่มลายเซ็นลงในคอลเลกชันของงานนำเและบันทึกเป็นไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

การบันทึกผลลัพธ์ด้วยชื่อใหม่ช่วยรักษาไฟล์ต้นฉบับที่ยังไม่ได้เซ็นไว้ ค่าที่ตั้งโดย [DigitalSignature.setComments](https://reference.aspose.com/slides/th/python-java/aspose.slides/digitalsignature/#setComments) บรรยายจุดประสงค์ของลายเซ็น; ไม่ใช่การควบคุมด้านความปลอดภัย

## **ตรวจสอบความถูกต้องของลายเซ็นดิจิทัล**

เมื่อคุณโหลดไฟล์ PPTX ที่เซ็นแล้ว ให้ตรวจสอบแต่ละรายการที่คืนมาจาก [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getDigitalSignatures) วิธีการ [DigitalSignature.isValid](https://reference.aspose.com/slides/th/python-java/aspose.slides/digitalsignature/#isValid) จะบ่งชี้ว่าลายเซ็นที่ฝังอยู่เป็นลายเซ็นที่ถูกต้องสำหรับเนื้อหาของงานนำเสนอในขณะนั้นหรือไม่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

ผลลัพธ์ที่ไม่ถูกต้องมักหมายความว่าเนื้อหาที่เซ็นหรือข้อมูลลายเซ็นถูกเปลี่ยนแปลงหลังการเซ็น หรือไฟล์เสีย การลบลายเซ็นทุกอันจะทำให้งานนำเสนอเป็นแบบที่ไม่ได้เซ็น ดังนั้นการตรวจสอบแค่ความถูกต้องของรายการไม่เพียงพอ: กระบวนการที่ต้องการความปลอดภัยต้องตรวจสอบด้วยว่าจำนวนลายเซ็นที่คาดหวังและตัวตนของผู้เซ็นที่คาดหวังปรากฏอยู่หรือไม่

ผลลัพธ์ความถูกต้องนี้ไม่ควรถือเป็นการตัดสินใจความเชื่อถือของใบรับรองโดยสมบูรณ์ ขึ้นอยู่กับนโยบายความปลอดภัยของคุณ แอปพลิเคชันอาจต้องสร้างและตรวจสอบสายใบรับรอง X.509, ตรวจสอบช่วงวันที่ใช้ได้และสถานะการเพิกถอน, ยืนยันหัวเรื่องหรือรหัสลายนิ้วมือที่คาดหวัง, ตรวจสอบการใช้คีย์, และประเมิน timestamp ที่เชื่อถื​อ ค่า [DigitalSignature.getSignTime](https://reference.aspose.com/slides/th/python-java/aspose.slides/digitalsignature/#getSignTime) เพียงอย่างเดียวไม่ถือเป็นหลักฐานจากหน่วยงานให้ timestamp ที่เชื่อถือได้

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นทำให้สถานะความปลอดภัยของงานนำเสนอเปลี่ยนแปลง ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่เซ็นแล้ว ลบลายเซ็นทั้งหมดด้วย [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/digitalsignaturecollection/#clear) แล้วบันทึกสำเนาที่ยังไม่ได้เซ็น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หากต้องการลบลายเซ็นเพียงอันเดียว ให้เรียก [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/th/python-java/aspose.slides/digitalsignaturecollection/#removeAt) พร้อมดัชนีที่เริ่มจากศูนย์ บันทึกเป็นไฟล์ใหม่หากไม่ต้องการเขียนทับไฟล์ต้นฉบับที่เซ็นไว้โดยตรงเป็นส่วนหนึ่งของกระบวนการของคุณ

## **การแก้ไขและข้อพิจารณาเกี่ยวกับรูปแบบ**

- ลายเซ็นไม่ได้ทำให้งานนำเสนอเป็นโหมดอ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังสามารถแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่เซ็นโดยทั่วไปจะทำให้ลายเซ็นที่มีอยู่กลายเป็นไม่ถูกต้อง
- ทำการแก้ไขทั้งหมดที่ต้องการให้เสร็จสิ้นก่อนการเซ็น หากต้องเปลี่ยนแปลงงานนำเสนอ ให้บันทึกงานนำเสนอที่แก้ไขแล้วและเซ็นเวอร์ชันนั้นอีกครั้ง
- เก็บผลลัพธ์สุดท้ายในรูปแบบ PPTX การแปลงงานนำเสนอที่เซ็นเป็นรูปแบบอื่นจะไม่ถ่ายทอดลายเซ็น PPTX ดั้งเดิมเป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ปฏิบัติคีย์ส่วนตัวของใบรับรองเป็นข้อมูลที่สำคัญ ผู้ใดที่ได้คีย์ส่วนตัวและรหัสผ่านของมันอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้นได้
- รักษาไฟล์ต้นฉบับที่ยังไม่ได้เซ็นหรือสำเนาที่ควบคุมไว้เมื่อนโยบายการเก็บรักษาเอกสารของคุณกำหนดให้ต้องทำเช่นนั้น

## **FAQ**

**ลายเซ็นดิจิทัลเข้ารหัสงานนำเสนอหรือไม่?**

ไม่. ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับต้นทางและความสมบูรณ์ แต่เนื้อหางานนำเสนอยังคงอ่านได้ยกเว้นว่าจะมีการเข้ารหัสแยกต่างหาก ใช้ [password protection](/slides/th/python-java/password-protected-presentation/) เมื่อจำเป็นต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX เป็นรหัสผ่านของงานนำเสนอหรือไม่?**

ไม่. รหัสผ่าน PFX ปลดล็อกคีย์ส่วนตัวที่เก็บอยู่ในแพ็คเกจใบรับรอง ไม่ได้ควบคุมว่าผู้ใดสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้

**ฉันสามารถใช้ใบรับรองที่เซ็นด้วยตนเองได้หรือไม่?**

ทางเทคนิคสามารถใช้ได้เมื่อติดตั้งคีย์ส่วนตัวที่เข้าถึงได้ ผู้รับจะไม่ได้รับการเชื่อถือโดยอัตโนมัติ เว้นแต่จะเพิ่มใบรับรองนั้นเข้าสู่สภาพแวดล้อมที่เชื่อถือได้ การทำงานร่วมกันระหว่างองค์กรทั่วไปมักใช้ใบรับรองจาก CA ที่เชื่อถือได้

**อะไรทำให้ลายเซ็นเป็นโมฆะ?**

การเปลี่ยนแปลงเนื้อหาที่เซ็นหรือข้อมูลลายเซ็นหลังการเซ็นทำให้ลายเซ็นโมฆะ ไฟล์เสียหายก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด งานนำเสนอจะกลายเป็นแบบที่ไม่ได้เซ็น ไม่ใช่ไฟล์ที่มีลายเซ็นไม่ถูกต้อง

**ลายเซ็นที่ถูกต้องหมายความว่าต้องเชื่อถือผู้เซ็นหรือไม่?**

ไม่โดยตัวมันเอง ความสมบูรณ์ของลายเซ็นและความเชื่อถือของผู้เซ็นเป็นการตัดสินใจแยกกัน นโยบายการตรวจสอบใน production ควรตรวจสอบสายใบรับรอง, ช่วงเวลาที่ใช้ได้, สถานะการเพิกถอน, ตัวตนที่คาดหวัง, การใช้คีย์, และข้อกำหนดของ timestamp ที่เชื่อถือได้ด้วย

**ถ้าใบรับรองหมดอายุจะเกิดอะไรขึ้น?**

การหมดอายุของใบรับรองไม่ได้เปลี่ยนแปลงบิตของงานนำเสนอ แต่ส่งผลต่อการประเมินความเชื่อถือของใบรับรอง ความยอมรับของลายเซ็นขึ้นอยู่กับนโยบายของคุณและว่ามี timestamp ที่เชื่อถือได้แสดงว่าการเซ็นเกิดขึ้นขณะใบรับรองยังมีอายุหรือไม่ อย่าพึ่งพาเวลาเซ็นที่แสดงอยู่เพียงอย่างเดียวเป็น timestamp ที่เชื่อถือได้

**งานนำเสนอที่เซ็นแล้วยังสามารถแก้ไขได้หรือไม่?**

ได้ การเซ็นไม่ได้ล็อกไฟล์ การแก้ไขเนื้อหาที่เซ็นมักทำให้ลายเซ็นที่มีอยู่เดิมไม่ถูกต้อง ดังนั้นควรทำการแก้ไขให้เสร็จสิ้นก่อนเซ็นเวอร์ชันสุดท้าย

**งานนำเสนอสามารถมีลายเซ็นมากกว่าหนึ่งอันได้หรือไม่?**

ได้ เพิ่มลายเซ็นแต่ละอันลงในคอลเลกชันที่คืนจาก [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getDigitalSignatures) ก่อนบันทึก ระหว่างการตรวจสอบให้ตรวจสอบลายเซ็นทุกอันและยืนยันว่าผู้เซ็นที่ต้องการทั้งหมดปรากฏอยู่

**รูปแบบงานนำเสนอใดบ้างที่รองรับการทำงานเหล่านี้?**

Aspose.Slides รองรับการทำงานกับลายเซ็นดิจิทัลที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX รูปแบบ PPT และ OpenDocument ไม่รองรับโดย API นี้

**ฉันสามารถลบลายเซ็นโดยไม่กระทบสไลด์ได้หรือไม่?**

ได้ คุณสามารถลบลายเซ็นหนึ่งอันหรือเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกงานนำเสนอ เนื้อหาสไลด์จะยังคงอยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานลายเซ็นที่ถูกลบแล้ว