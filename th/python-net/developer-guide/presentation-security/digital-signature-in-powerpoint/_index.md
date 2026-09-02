---
title: เพิ่มลายเซ็นดิจิทัลให้กับงานนำเสนอใน Python
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/python-net/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยรับรอง
- ใบรับรอง PFX
- PKCS#12
- ตรวจสอบลายเซ็น
- PowerPoint
- PPTX
- ความปลอดภัยของการนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการเซ็นงานนำเสนอ PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อตรวจสอบหรือเอาลายเซ็นดิจิทัลออก"
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยผู้รับระบุว่าใครเป็นผู้เซ็นงานนำเสนอและเนื้อหาที่เซ็นเปลี่ยนแปลงหรือไม่ แนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามประการสำคัญคือ:

- **ใบรับรองดิจิทัล** คือข้อมูลยืนยันอิเล็กทรอนิกส์ที่เชื่อมโยงตัวตนกับคีย์สาธารณะ หน่วยรับรองที่เชื่อถือได้ (CA) สามารถออกใบรับรองได้ หรือองค์กรอาจใช้ใบรับรองที่เซ็นด้วยตนเองสำหรับกระบวนการภายใน
- **ลายเซ็นดิจิทัล** สร้างจากเนื้อหาการนำเสนอและคีย์ส่วนตัวของผู้ถือใบรับรอง แล้วคีย์สาธารณะของใบรับรองจะใช้ตรวจสอบลายเซ็น ลายเซ็นให้หลักฐานของแหล่งที่มาและความสมบูรณ์; ไม่ได้เข้ารหัสการนำเสนอ
- **การป้องกันด้วยรหัสผ่าน** ควบคุมว่าผู้ใช้สามารถเปิดหรือแก้ไขการนำเสนอได้หรือไม่ แยกจากการเซ็นดิจิทัลและอธิบายอยู่ใน [การนำเสนอที่ป้องกันด้วยรหัสผ่าน](/slides/th/python-net/password-protected-presentation/)

PowerPoint มีคำสั่ง **Add a Digital Signature** ภายใต้ **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint พร้อมไฮไลท์ Add a Digital Signature](add-digital-signature-in-powerpoint.png)

เมื่อเปิดการนำเสนอที่มีลายเซ็น PowerPoint สามารถแสดงแจ้งเตือนสถานะลายเซ็นได้

![แจ้งเตือนของ PowerPoint ระบุว่าการนำเสนอมีลายเซ็นที่ถูกต้อง](digital-signature-status-in-powerpoint.png)

Aspose.Slides เปิดเผยลายเซ็นผ่าน [Presentation.digital_signatures](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/digital_signatures/), ซึ่งเป็น [DigitalSignatureCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignaturecollection/) ที่มีรายการเป็นวัตถุ [DigitalSignature](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/) สามารถมีลายเซ็นหลายรายการในงานนำเสนอหนึ่งไฟล์ได้

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

ไฟล์ PFX (หรือที่เรียกว่าไฟล์ PKCS#12) โดยทั่วไปมีส่วนขยาย `.pfx` หรือ `.p12` สามารถบรรจุใบรับรอง X.509, คีย์ส่วนตัว, และห่วงโซ่ใบรับรอง คีย์ส่วนตัวคือสิ่งที่ทำให้ผู้ถือสามารถสร้างลายเซ็นได้ ใบรับรองที่ไม่มีคีย์ส่วนตัวที่เข้าถึงได้ไม่สามารถใช้เซ็นงานนำเสนอได้

รหัสผ่าน PFX ปกป้องแพ็คเกจใบรับรองและคีย์ส่วนตัว **ไม่ได้** เป็นรหัสผ่านสำหรับเปิดหรือแก้ไขการนำเสนอ อย่า commit ไฟล์ PFX หรือรหัสผ่านของมันไปที่ source control ในการผลิตให้จำกัดการเข้าถึงไฟล์ใบรับรองและดึงรหัสผ่านจากที่เก็บความลับหรือแหล่งกำหนดค่าที่ปลอดภัย ตัวอย่างด้านล่างใช้ตัวแปรสภาพแวดล้อมเพื่อหลีกเลี่ยงการฝังรหัสผ่านในโค้ด

## **เพิ่มลายเซ็นดิจิทัลให้กับการนำเสนอ**

เพื่อทำงานเซ็นการนำเสนอจริง โหลดไฟล์ PPTX ที่มีอยู่, สร้าง [DigitalSignature](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/) จากใบรับรอง PFX และรหัสผ่านของมัน, เพิ่มลายเซ็นเข้าไปในคอลเลกชันของการนำเสนอ, แล้วบันทึกเป็นไฟล์ PPTX

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

การบันทึกผลลัพธ์ภายใต้ชื่อใหม่ช่วยรักษาไฟล์ต้นฉบับที่ไม่ได้เซ็นไว้ ค่าของ [DigitalSignature.comments](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/comments/) บรรยายวัตถุประสงค์ของลายเซ็น; ไม่ได้เป็นการควบคุมด้านความปลอดภัย

## **ตรวจสอบลายเซ็นดิจิทัล**

เมื่อโหลดไฟล์ PPTX ที่เซ็นแล้ว ให้ตรวจสอบทุกรายการใน [Presentation.digital_signatures](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/digital_signatures/) คุณสมบัติ [DigitalSignature.is_valid](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/is_valid/) ระบุว่าลายเซ็นที่ฝังอยู่ยังคงถูกต้องสำหรับเนื้อหาการนำเสนอในปัจจุบันหรือไม่

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

ผลลัพธ์ที่ไม่ถูกต้องมักหมายความว่าเนื้อหาที่เซ็นหรือข้อมูลลายเซ็นเปลี่ยนแปลงหลังจากเซ็น, หรือไฟล์เสีย การลบลายเซ็นทั้งหมดทำให้การนำเสนอเป็นเวอร์ชันที่ไม่ได้เซ็น ดังนั้นการตรวจสอบความถูกต้องของรายการเพียงอย่างเดียวไม่พอ: กระบวนการที่ต้องการความปลอดภัยควรตรวจสอบจำนวนลายเซ็นที่คาดหวังและตัวตนของผู้เซ็นด้วย

คุณสมบัติ [DigitalSignature.certificate](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/certificate/) ให้ข้อมูลใบรับรองเป็นอาเรย์ไบต์ ตัวอย่างคำนวนลายนิ้วมือ SHA‑256 เพื่อให้แอปเปรียบเทียบกับลายนิ้วมือของใบรับรองผู้เซ็นที่คาดหวัง

ผลลัพธ์ความถูกต้องนี้ไม่ควรถือเป็นการตัดสินใจไว้วางใจใบรับรองโดยสมบูรณ์ ตามนโยบายความปลอดภัยของคุณอาจต้องสร้างและตรวจสอบห่วงโซ่ใบรับรอง X.509, ตรวจสอบช่วงวันใช้งานและสถานะการเพิกถอน, ยืนยันเรื่อง subject หรือ thumbprint ที่คาดหวัง, ตรวจสอบการใช้คีย์, และประเมิน timestamp ที่เชื่อถือได้ ค่า [DigitalSignature.sign_time](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/sign_time/) เองไม่ได้เป็นหลักฐานจากผู้ให้บริการ timestamp ที่เชื่อถือได้

## **ลบลายเซ็นดิจิทัล**

การลบลายเซ็นทำให้สถานะความปลอดภัยของการนำเปลี่ยนแปลง ตัวอย่างต่อไปนี้โหลดไฟล์ PPTX ที่เซ็นแล้ว, ลบลายเซ็นทั้งหมดด้วย [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignaturecollection/clear/), แล้วบันทึกสำเนาที่ไม่ได้เซ็น

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

หากต้องการลบเฉพาะลายเซ็นหนึ่งรายการ ให้เรียก [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignaturecollection/remove_at/) พร้อมดัชนีเริ่มจากศูนย์ บันทึกเป็นไฟล์ใหม่หากไม่ต้องการเขียนทับไฟล์ต้นฉบับที่เซ็นไว้โดยเจตนา

## **การแก้ไขและข้อควรพิจารณาเรื่องรูปแบบ**

- ลายเซ็นไม่ได้ทำให้การนำเสนอเป็นแบบอ่านอย่างเดียว ผู้ใช้และแอปพลิเคชันยังสามารถแก้ไขไฟล์ได้ แต่การเปลี่ยนแปลงเนื้อหาที่เซ็นมักทำให้ลายเซ็นเดิมไม่ถูกต้อง
- ทำการแก้ไขทั้งหมดก่อนเซ็น หากต้องการเปลี่ยนแปลงการนำเสนอ ให้บันทึกเวอร์ชันที่แก้ไขแล้วและเซ็นซ้ำอีกครั้ง
- เก็บผลลัพธ์สุดท้ายในรูปแบบ PPTX การแปลงการนำเสนอที่เซ็นเป็นรูปแบบอื่นจะไม่ถ่ายโอนลายเซ็น PPTX ดั้งเดิมเป็นลายเซ็นที่ถูกต้องสำหรับไฟล์ที่แปลงแล้ว
- ถือคีย์ส่วนตัวของใบรับรองว่าเป็นข้อมูลสำคัญ ใครที่ได้คีย์ส่วนตัวและรหัสผ่านอาจสร้างลายเซ็นที่ดูเหมือนมาจากผู้ถือใบรับรองนั้นได้
- เก็บไฟล์ต้นฉบับที่ไม่ได้เซ็นหรือสำเนาที่ควบคุมไว้เมื่อแนวนโยบายการเก็บเอกสารของคุณกำหนดให้ต้องทำเช่นนั้น

## **คำถามที่พบบ่อย**

**ลายเซ็นดิจิทัลเข้ารหัสการนำเสนอหรือไม่?**

ไม่มี ลายเซ็นดิจิทัลให้หลักฐานเกี่ยวกับแหล่งที่มาและความสมบูรณ์, แต่เนื้อหาการนำเสนอยังคงอ่านได้หากไม่ได้ใช้การเข้ารหัสแยกต่างหาก ใช้ [การป้องกันด้วยรหัสผ่าน](/slides/th/python-net/password-protected-presentation/) เมื่อจำเป็นต้องจำกัดการเข้าถึงเนื้อหา

**รหัสผ่าน PFX คือรหัสผ่านของการนำเสนอเช่นเดียวกันหรือไม่?**

ไม่ รหัสผ่าน PFX ใช้ปลดล็อกคีย์ส่วนตัวที่เก็บอยู่ในแพ็คเกจใบรับรอง ไม่ได้ควบคุมว่าใครเปิดหรือแก้ไขไฟล์ PPTX ได้

**สามารถใช้ใบรับรองที่เซ็นด้วยตนเองได้หรือไม่?**

เทคนิคแล้วสามารถใช้ได้หากมีคีย์ส่วนตัวที่เข้าถึงได้ ผู้รับจะไม่เชื่อถือโดยอัตโนมัติ เว้นแต่ใบรับรองนั้นถูกเพิ่มอย่างชัดเจนในสภาพแวดล้อมที่เชื่อถือได้ งานที่ทำข้ามองค์กรหรือสาธารณะมักใช้ใบรับรองที่ออกโดย CA ที่เชื่อถือได้

**อะไรทำให้ลายเซ็นไม่ถูกต้อง?**

การเปลี่ยนแปลงเนื้อหาที่เซ็นหรือข้อมูลลายเซ็นหลังจากเซ็นทำให้ลายเซ็นไม่ถูกต้อง การเสียหายของไฟล์ก็อาจทำให้การตรวจสอบล้มเหลว หากลบลายเซ็นทั้งหมด การนำเสนอจะเป็นเวอร์ชันที่ไม่ได้เซ็น ไม่ใช่ไฟล์ที่มีลายเซ็นไม่ถูกต้อง

**ลายเซ็นที่ถูกต้องหมายความว่าต้องเชื่อถือผู้เซ็นหรือไม่?**

ไม่โดยตัวมันเอง ความสมบูรณ์ของลายเซ็นและความเชื่อถือผู้เซ็นเป็นการตัดสินใจแยกกัน นโยบายการตรวจสอบในระบบผลิตควรตรวจสอบห่วงโซ่ใบรับรอง, ช่วงวันใช้งาน, สถานะการเพิกถอน, ตัวตนที่คาดหวัง, การใช้คีย์, และข้อกำหนดของ timestamp ที่เชื่อถือได้

**เกิดอะไรขึ้นเมื่อใบรับรองหมดอายุ?**

การหมดอายุของใบรับรองไม่ได้เปลี่ยนไบต์ของการนำเสนอ แต่ส่งผลต่อการประเมินความเชื่อถือของใบรับรอง ความเป็นที่ยอมรับของลายเซ็นขึ้นกับนโยบายของคุณและว่าจะมี timestamp ที่เชื่อถือได้แสดงว่าการเซ็นเกิดขึ้นขณะใบรับรองยังใช้งานได้หรือไม่ อย่าพึ่งพาเวลาเซ็นที่แสดงเพียงอย่างเดียวเป็น timestamp ที่เชื่อถือได้

**การนำเสนอที่เซ็นแล้วยังสามารถแก้ไขได้หรือไม่?**

ได้ การเซ็นไม่ได้ล็อกไฟล์ การแก้ไขเนื้อหาที่เซ็นโดยทั่วไปทำให้ลายเซ็นเดิมไม่ถูกต้อง ดังนั้นควรทำการแก้ไขให้เสร็จก่อนแล้วจึงเซ็นเวอร์ชันสุดท้าย

**การนำเสนอสามารถมีลายเซ็นมากกว่าหนึ่งรายการได้หรือไม่?**

ได้ เพิ่มลายเซ็นแต่ละอันเข้าไปใน [Presentation.digital_signatures](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/digital_signatures/) ก่อนบันทึก ในขั้นตอนตรวจสอบให้ตรวจดูทุกลายเซ็นและยืนยันว่ามีผู้เซ็นที่ต้องการครบถ้วน

**รูปแบบการนำเสนอใดบ้างที่สนับสนุนการดำเนินการเหล่านี้?**

Aspose.Slides สนับสนุนการดำเนินการลายเซ็นดิจิทัลที่อธิบายไว้ที่นี่เฉพาะสำหรับ PPTX รูปแบบ PPT และ OpenDocument ไม่ได้รับการสนับสนุนโดย API นี้

**สามารถลบลายเซ็นโดยไม่กระทบสไลด์ได้หรือไม่?**

ได้ สามารถลบลายเซ็นหนึ่งรายการหรือเคลียร์คอลเลกชันทั้งหมดแล้วบันทึกการนำเสนอ ส่วนเนื้อหาในสไลด์ยังคงอยู่ แต่ไฟล์ที่บันทึกแล้วจะไม่มีหลักฐานลายเซ็นที่ถูกลบแล้ว