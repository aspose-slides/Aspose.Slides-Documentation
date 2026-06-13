---
title: เพิ่มลายเซ็นดิจิทัลให้กับงานนำเสนอด้วย Python
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/python-net/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยรับรองใบรับรอง
- ใบรับรอง PFX
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการลงลายเซ็นดิจิทัลในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. ปกป้องสไลด์ของคุณภายในไม่กี่วินาทีด้วยตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

**ใบรับรองดิจิทัล** ถูกใช้เพื่อสร้างงานนำเสนอ PowerPoint ที่มีการป้องกันด้วยรหัสผ่าน โดยระบุว่าได้สร้างโดยองค์กรหรือบุคคลเฉพาะ ใบรับรองดิจิทัลสามารถได้รับโดยติดต่อกับองค์กรที่ได้รับอนุญาต‑หน่วยรับรองใบรับรอง หลังจากติดตั้งใบรับรองดิจิทัลลงในระบบแล้ว สามารถใช้เพื่อเพิ่มลายเซ็นดิจิทัลให้กับงานนำเสนอผ่านเมนู File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

งานนำเสนออาจมีลายเซ็นดิจิทัลมากกว่าหนึ่งรายการ หลังจากที่เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ จะมีข้อความพิเศษปรากฏใน PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

หากต้องการลงลายเซ็นงานนำเสนอหรือตรวจสอบความถูกต้องของลายเซ็นงานนำเสนอ, **Aspose.Slides API** มีคลาส [**DigitalSignature**](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/) คลาส [**DigitalSignatureCollection**](https://reference.aspose.com/slides/th/python-net/aspose.slides/DigitalSignatureCollection/) และคุณสมบัติ [**Presentation.digital_signatures**](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/digital_signatures/) ให้ใช้งาน ในปัจจุบัน ลายเซ็นดิจิทัลรองรับเฉพาะรูปแบบ PPTX เท่านั้น.

## **เพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX**

ตัวอย่างโค้ดด้านล่างจะแสดงวิธีเพิ่มลายเซ็นดิจิทัลจากใบรับรอง PFX:

1. เปิดไฟล์ PFX และส่งรหัสผ่าน PFX ไปยังอ็อบเจกต์ [**DigitalSignature**](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignature/) .
1. เพิ่มลายเซ็นที่สร้างขึ้นไปยังอ็อบเจกต์งานนำเสนอ.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # สร้างอ็อบเจกต์ DigitalSignature ด้วยไฟล์ PFX และรหัสผ่าน PFX
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # แสดงความคิดเห็นลายเซ็นดิจิทัลใหม่
    signature.comments = "Aspose.Slides digital signing test."

    # เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ
    pres.digital_signatures.add(signature)

    # บันทึกงานนำเสนอ
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

ตอนนี้สามารถตรวจสอบได้ว่างานนำเสนอถูกลงลายเซ็นดิจิทัลและไม่ได้ถูกแก้ไข:

```py
# เปิดงานนำเสนอ
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # ตรวจสอบว่าลายเซ็นดิจิทัลทั้งหมดมีความถูกต้องหรือไม่
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **คำถามที่พบบ่อย**

**ฉันสามารถลบลายเซ็นที่มีอยู่ในไฟล์ได้หรือไม่?**

ใช่. คอลเลกชันลายเซ็นดิจิทัลสนับสนุนการ [ลบรายการเดี่ยว](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignaturecollection/remove_at/) และการ [ลบทั้งหมด](https://reference.aspose.com/slides/th/python-net/aspose.slides/digitalsignaturecollection/clear/); หลังจากคุณบันทึกไฟล์ งานนำเสนอจะไม่มีลายเซ็นใด ๆ.

**ไฟล์จะกลายเป็น "อ่านอย่างเดียว" หลังจากลงลายเซ็นหรือไม่?**

ไม่. ลายเซ็นทำให้ข้อมูลคงความสมบูรณ์และแสดงความเป็นผู้เขียน แต่ไม่บล็อกการแก้ไข เพื่อจำกัดการแก้ไขให้รวมกับ ["อ่านอย่างเดียว" หรือรหัสผ่าน](/slides/th/python-net/password-protected-presentation/).

**ลายเซ็นจะแสดงผลอย่างถูกต้องในเวอร์ชันต่าง ๆ ของ PowerPoint หรือไม่?**

ลายเซ็นถูกสร้างสำหรับคอนเทนเนอร์ OOXML (PPTX) เวอร์ชัน PowerPoint สมัยใหม่ที่รองรับลายเซ็น OOXML จะแสดงสถานะของลายเซ็นเหล่านั้นอย่างถูกต้อง.