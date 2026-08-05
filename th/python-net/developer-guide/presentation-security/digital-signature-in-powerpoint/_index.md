---
title: เพิ่มลายเซ็นดิจิทัลในงานนำเสนอด้วย Python
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/python-net/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยงานออกใบรับรอง
- ใบรับรอง PFX
- PKCS#12
- ตรวจสอบลายเซ็น
- PowerPoint
- PPTX
- ความปลอดภัยของงานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการลงลายเซ็นในงานนำเสนอ PPTX ที่มีอยู่โดยใช้ใบรับรอง PFX และใช้ Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อทำการตรวจสอบหรือเอาลายเซ็นดิจิทัลออก"
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยผู้รับกำหนดว่าใครเป็นผู้ลงลายเซ็นในงานนำเสนอและเนื้อหาที่ลงลายเซ็นมีการเปลี่ยนแปลงหรือไม่ มีแนวคิดความปลอดภัยที่เกี่ยวข้องสามประการที่สำคัญในที่นี้:

- **digital certificate** คือข้อมูลประจำตัวอิเล็กทรอนิกส์ที่เชื่อมโยงอัตลักษณ์กับคีย์สาธารณะ หน่วยงานออกใบรับรองที่เชื่อถือได้ (CA) สามารถออกใบรับรองได้ หรือองค์กรอาจใช้ใบรับรองที่ลงนามด้วยตนเองสำหรับกระบวนการทำงานภายใน
- **digital signature** ถูกสร้างจากเนื้อหาของงานนำเสนอและคีย์ส่วนตัวของผู้ถือใบรับรอง จากนั้นคีย์สาธารณะของใบรับรองสามารถใช้ตรวจสอบลายเซ็นได้ ลายเซ็นให้หลักฐานของต้นทางและความสมบูรณ์; มันไม่ได้เข้ารหัสงานนำเสนอ
- **Password protection** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขงานนำเสนอได้หรือไม่ มันแยกจากการลงลายเซ็นดิจิทัลและอธิบายไว้ใน [การปกป้องด้วยรหัสผ่าน](/python-net/password-protected-presentation/)

PowerPoint มีคำสั่ง **Add a Digital Signature** อยู่ภายใต้ **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint พร้อมเน้น Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

หลังจากเปิดงานนำเสนอที่ลงลายเซ็นแล้ว PowerPoint สามารถแสดงการแจ้งสถานะลายเซ็นได้

![การแจ้งของ PowerPoint ระบุว่างานนำเสนอมีลายเซ็นที่ถูกต้อง](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน [Presentation.digital_signatures](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/digital_signatures/), ซึ่งเป็น [DigitalSignatureCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignaturecollection/) ที่มีรายการเป็นอ็อบเจ็กต์ [DigitalSignature](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/) งานนำเสนอสามารถมีลายเซ็นหลายรายการได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX ซึ่งรู้จักกันในชื่อไฟล์ PKCS#12 และมักมีนามสกุล `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, คีย์ส่วนตัวของมัน, และห่วงโซ่ใบรับรอง คีย์ส่วนตัวคือสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีคีย์ส่วนตัวที่เข้าถึงได้ไม่สามารถใช้ลงลายเซ็นในงานนำเสนอได้

รหัสผ่าน PFX ปกป้องแพ็คเกจใบรับรองและคีย์ส่วนตัว มัน **ไม่** เป็นรหัสผ่านสำหรับเปิดหรือแก้ไขงานนำเสนอ อย่า commit ไฟล์ PFX หรือรหัสผ่านของมันลงในระบบควบคุมเวอร์ชัน ในการใช้งานจริง ควรจำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ปลอดภัย ตัวอย่างด้านล่างใช้ตัวแปรสภาพแวดล้อมเพียงเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ**

เพื่อทำกระบวนการลงลายเซ็นในงานนำเสนอจริง โหลดไฟล์ PPTX ที่มีอยู่แล้ว, สร้าง [DigitalSignature](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน, เพิ่มลายเซ็นเข้าไปในคอลเลกชันของงานนำเสนอ, แล้วบันทึกเป็นไฟล์ PPTX

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

การบันทึกผลลัพธ์ด้วยชื่อใหม่จะทำให้ไฟล์ต้นฉบับที่ยังไม่ได้ลงลายเซ็นคงอยู่ ค่า [DigitalSignature.comments](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/comments/) อธิบายวัตถุประสงค์ของลายเซ็น; มันไม่ใช่การควบคุมความปลอดภัย

## **ตรวจสอบความถูกต้องของลายเซ็นดิจิทัล**

เมื่อคุณโหลดไฟล์ PPTX ที่ลงลายเซ็นแล้ว ตรวจสอบแต่ละรายการใน [Presentation.digital_signatures](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/digital_signatures/) คุณสมบัติ [DigitalSignature.is_valid](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/is_valid/) แสดงว่าลายเซ็นที่ฝังอยู่ยังคงถูกต้องสำหรับเนื้อหาปัจจุบันของงานนำเสนอหรือไม่

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

ผลลัพธ์ที่ไม่ถูกต้องมักหมายถึงเนื้อหาที่ลงลายเซ็นหรือข้อมูลลายเซ็นถูกเปลี่ยนแปลงหลังจากการลงลายเซ็น, หรือไฟล์เสีย การลบลายเซ็นทุกรายการจะทำให้งานนำเสนอไม่มีลายเซ็น, ดังนั้นการตรวจสอบเพียงความถูกต้องของรายการไม่เพียงพอ: กระบวนการที่ต้องคำนึงถึงความปลอดภัยจะต้องตรวจสอบจำนวนลายเซ็นที่คาดไว้และอัตลักษณ์ของผู้ลงลายเซ็นที่คาดหวังด้วย

คุณสมบัติ [DigitalSignature.certificate](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/certificate/) ให้ข้อมูลใบรับรองเป็นอาร์เรย์ของไบต์ ตัวอย่างคำนวณลายนิ้วมือ SHA-256 ของมันเพื่อให้แอปพลิเคชันเปรียบเทียบกับลายนิ้วมือของใบรับรองผู้ลงลายเซ็นที่คาดหวัง

ผลลัพธ์การตรวจสอบนี้ไม่ควรถือเป็นการตัดสินใจเชื่อถือใบรับรองทั้งหมด ขึ้นอยู่กับนโยบายความปลอดภัยของคุณ แอปพลิเคชันอาจต้องสร้างและตรวจสอบห่วงโซ่ใบรับรอง X.509, ตรวจสอบวันที่หมดอายุและสถานะการเพิกถอน, ยืนยันหัวข้อหรือรหัสthumbprint ที่คาดไว้, ตรวจสอบการใช้คีย์, และประเมินตราประทับเวลาที่เชื่อถือได้ ค่า [DigitalSignature.sign_time](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/sign_time/) เองไม่ถือเป็นหลักฐานจากหน่วยงานตราประทับเวลาที่เชื่อถือได้

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นจะเปลี่ยนสถานะความปลอดภัยของงานนำเสนอ ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่ลงลายเซ็น, ลบลายเซ็นทั้งหมดด้วย [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignaturecollection/clear/), แล้วบันทึกเป็นสำเนาที่ไม่มีลายเซ็น

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

หากต้องการลบลายเซ็นเพียงหนึ่งรายการ ให้เรียก [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignaturecollection/remove_at/) พร้อมดัชนีที่เริ่มจากศูนย์ บันทึกเป็นไฟล์ใหม่หากไม่ต้องการเขียนทับไฟล์ต้นฉบับที่ลงลายเซ็นโดยตรงเป็นส่วนหนึ่งของกระบวนการทำงานของคุณ

## **ข้อควรพิจารณาการแก้ไขและรูปแบบ**

- ลายเซ็นไม่ได้ทำให้งานนำเสนอเป็นโหมดอ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังสามารถแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่ลงลายเซ็นมักทำให้ลายเซ็นที่มีอยู่เดิมไม่ถูกต้อง
- ทำการแก้ไขทั้งหมดก่อนลงลายเซ็น หากงานนำเสนอจำเป็นต้องเปลี่ยนแปลง ให้บันทึกงานนำเสนอที่แก้ไขแล้วและลงลายเซ็นในฉบับนั้นอีกครั้ง
- รักษาเอาต์พุตขั้นสุดท้ายในรูปแบบ PPTX การแปลงงานนำเสนอที่ลงลายเซ็นเป็นรูปแบบอื่นจะไม่ถ่ายทอดลายเซ็น PPTX ดั้งเดิมเป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ถือคีย์ส่วนตัวของใบรับรองว่าเป็นข้อมูลที่ละเอียดอ่อน ผู้ที่ได้คีย์ส่วนตัวและรหัสผ่านของมันอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้นได้
- เก็บไฟล์ต้นฉบับที่ยังไม่ได้ลงลายเซ็นหรือสำเนาที่ควบคุมไว้เมื่อโครงการเก็บรักษาเอกสารของคุณต้องการ

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลทำให้การนำเสนอถูกเข้ารหัสหรือไม่?**

ไม่ ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับต้นทางและความสมบูรณ์ของเนื้อหา, แต่เนื้อหางานนำเสนอยังคงอ่านได้ เว้นแต่จะมีการเข้ารหัสแยกต่างหาก ใช้ [การปกป้องด้วยรหัสผ่าน](/python-net/password-protected-presentation/) เมื่อจำเป็นต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX เป็นรหัสผ่านเดียวกับรหัสผ่านของงานนำเสนอหรือไม่?**

ไม่ รหัสผ่าน PFX ปลดล็อกคีย์ส่วนตัวที่เก็บอยู่ในแพ็คเกจใบรับรอง มันไม่ได้ควบคุมว่าใครสามารถเปิดหรือแก้ไขไฟล์ PPTX ได้

**สามารถใช้ใบรับรองที่ลงนามด้วยตนเองได้หรือไม่?**

โดยเทคนิคแล้ว สามารถใช้ใบรับรองที่ลงนามด้วยตนเองได้เมื่อมีคีย์ส่วนตัวที่เข้าถึงได้ ผู้รับจะไม่เชื่อถือโดยอัตโนมัติ เว้นแต่ใบรับรองนั้นจะถูกเพิ่มอย่างชัดเจนในสภาพแวดล้อมที่เชื่อถือได้ งานที่ทำข้ามองค์กรหรือข้ามองค์กรทั่วไปมักใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้

**อะไรทำให้ลายเซ็นเป็นสิ่งที่ไม่ถูกต้อง?**

การเปลี่ยนแปลงเนื้อหาที่ลงลายเซ็นหรือข้อมูลลายเซ็นหลังจากการลงลายเซ็นสามารถทำให้ลายเซ็นไม่ถูกต้องได้ การเสียหายของไฟล์ก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด งานนำเสนอจะกลายเป็นไม่มีลายเซ็น ไม่ใช่ไฟล์ที่มีลายเซ็นที่ไม่ถูกต้อง

**ลายเซ็นที่ถูกต้องหมายความว่าต้องเชื่อถือผู้ลงลายเซ็นหรือไม่?**

ไม่โดยตัวมันเอง ความสมบูรณ์ของลายเซ็นและความเชื่อถือของผู้ลงลายเซ็นเป็นการตัดสินใจที่แยกกัน นโยบายการตรวจสอบในการผลิตควรตรวจสอบห่วงโซ่ใบรับรอง, ระยะเวลาที่มีผล, สถานะการเพิกถอน, อัตลักษณ์ที่คาดหวัง, การใช้คีย์, และข้อกำหนดของตราประทับเวลาที่เชื่อถือได้ด้วย

**จะเกิดอะไรขึ้นเมื่อใบรับรองหมดอายุ?**

การหมดอายุของใบรับรองไม่ทำให้ไบต์ของงานนำเปลี่ยนแปลง, แต่จะส่งผลต่อการประเมินความเชื่อถือของใบรับรองว่าลายเซ็นยังคงยอมรับได้หรือไม่ ขึ้นกับนโยบายของคุณและว่ามีตราประทับเวลาที่เชื่อถือได้แสดงว่าการลงลายเซ็นทำขณะใบรับรองยังมีผลหรือไม่ อย่าพึ่งพาเวลาแสดงบนลายเซ็นอย่างเดียวเป็นตราประทับเวลาที่เชื่อถือได้

**งานนำเสนอที่ลงลายเซ็นสามารถแก้ไขได้หรือไม่?**

ได้ การลงลายเซ็นไม่ได้ล็อกไฟล์ การแก้ไขเนื้อหาที่ลงลายเซ็นมักทำให้ลายเซ็นเดิมไม่ถูกต้อง ดังนั้นควรทำงานนำเสนอให้เสร็จก่อนและลงลายเซ็นเวอร์ชันสุดท้าย

**งานนำเสนอสามารถมีลายเซ็นมากกว่าหนึ่งรายการได้หรือไม่?**

ได้ เพิ่มลายเซ็นแต่ละรายการลงใน [Presentation.digital_signatures](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/digital_signatures/) ก่อนบันทึก ในระหว่างการตรวจสอบ ตรวจสอบทุกลายเซ็นและยืนยันว่าผู้ลงลายเซ็นที่ต้องการทั้งหมดปรากฏอยู่

**รูปแบบไฟล์งานนำเสนอใดรองรับการดำเนินการเหล่านี้?**

Aspose.Slides รองรับการดำเนินการลายเซ็นดิจิทัลที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX เท่านั้น รูปแบบ PPT และ OpenDocument ไม่ได้รับการสนับสนุนโดย API นี้

**สามารถลบลายเซ็นโดยไม่กระทบต่อสไลด์ได้หรือไม่?**

ได้ คุณสามารถลบลายเซ็นหนึ่งรายการหรือเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกงานนำเสนอ เนื้อหาสไลด์จะยังคงอยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานลายเซ็นที่ถูกลบแล้ว