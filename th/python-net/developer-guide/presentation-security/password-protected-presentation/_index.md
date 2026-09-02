---
title: การป้องกันการนำเสนอด้วยรหัสผ่านใน Python
linktitle: การป้องกันรหัสผ่าน
type: docs
weight: 20
url: /th/python-net/password-protected-presentation/
keywords:
- การนำเสนอที่ป้องกันด้วยรหัสผ่าน
- รหัสผ่านเปิด
- เข้ารหัส PowerPoint
- ถอดรหัส PowerPoint
- ตรวจสอบความถูกต้องของรหัสผ่านการนำเสนอ
- ตรวจสอบรหัสผ่านการนำเสนอ
- เปิดการนำเสนอที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- การนำเสนอ
- Python
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบ, เปิดและถอดรหัสการนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านใน Python ด้วย Aspose.Slides."
---
## **ภาพรวม**

รหัสผ่านเปิดทำการเข้ารหัสการนำเสนอ จำเป็นต้องใช้รหัสผ่านที่ถูกต้องเพื่อโหลดและดูเนื้อหาการนำเสนอ ดังนั้นการป้องกันนี้จึงให้ความลับ.

รหัสผ่านเปิดต่างจากรหัสผ่านป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่เข้ารหัสเนื้อหา nor ไม่ป้องกันการโหลดการนำเสนอ เพื่อจัดการรหัสผ่านสำหรับการแก้ไขการนำเสนอ ดูที่ [Write-Protect Presentations](/slides/th/python-net/write-protected-presentation/).

กระบวนการทำงานด้านล่างใช้ได้กับการนำเสนอทั้งในรูปแบบ PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมตามไฟล์และตามสตรีมมีความสำคัญ.

## **เข้ารหัสการนำเสนอด้วยรหัสผ่านเปิด**

ใช้ [ProtectionManager.encrypt](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/encrypt/) เพื่อกำหนดรหัสผ่านเปิด จากนั้นใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) เพื่อบันทึกการนำเสนอที่เข้ารหัส.

ตัวอย่างต่อไปนี้ทำการเข้ารหัสการนำเสนอ PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **โหลดการนำเสนอที่เข้ารหัส**

กำหนดค่า [LoadOptions.password](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/password/) ให้เป็นรหัสผ่านเปิดและส่งตัวเลือกเหล่านั้นไปยัง [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เมื่อโหลดไฟล์ การโหลดจะล้มเหลือเมื่อจำเป็นต้องใช้รหัสผ่านเปิดแต่รหัสที่ให้มาขาดหายหรือไม่ถูกต้อง.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # ทำงานกับการนำเสนอที่ถอดรหัสแล้ว.
    pass
```

## **ลบการเข้ารหัสออกจากการนำเสนอ**

โหลดการนำเสนอพร้อมรหัสผ่านเปิด, เรียกใช้ [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/remove_encryption/), แล้วบันทึกผลลัพธ์ การนำเสนอที่บันทึกแล้วสามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจสอบรหัสผ่านเปิดก่อนการโหลด**

ใช้ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) เพื่อรับ [PresentationInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ ตรวจสอบ [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/is_password_protected/) ก่อนขอหรือยืนยันรหัสผ่าน เมื่อมีการป้องกันอยู่ ให้ตรวจสอบค่าที่ให้ด้วย [PresentationInfo.check_password](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/check_password/).

### **กระบวนการทำงานด้วยเส้นทางไฟล์**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดสำหรับไฟล์ PPTX, ส่งค่าที่ตรวจสอบแล้วไปยัง [LoadOptions.password](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/password/), จากนั้นโหลดการนำเสนอเต็มรูปแบบ:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **กระบวนการทำงานด้วยสตรีม**

การ overload ด้วยสตรีมของ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) ให้กระบวนการทำงานแบบเดียวกัน รีเซ็ตตำแหน่งของสตรีมที่สามารถค้นหาได้ก่อนโหลดการนำเสนอเต็มรูปแบบจากสตรีมนั้น.

ตัวอย่างต่อไปนี้ใช้ไฟล์ PPT:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **ค่าที่คืนจาก CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/check_password/) คืนค่า `True` เฉพาะเมื่อการนำเสนอมีรหัสผ่านเปิดและรหัสที่ให้มาถูกต้อง จะคืนค่า `False` ในกรณีต่อไปนี้:

- รหัสผ่านไม่ถูกต้อง.
- การนำเสนอไม่มีรหัสผ่านเปิด.
- รหัสผ่านที่ให้เป็น `None` หรือว่างเปล่า.

พฤติกรรมนี้เหมือนกันสำหรับการนำเสนอ PPT และ PPTX.

## **ตรวจสอบว่าการนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดการนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/is_encrypted/) เพื่อยืนยันว่าการนำเสนอแหล่งที่มาถูกเข้ารหัส เพื่อตรวจจับการป้องกันด้วยรหัสผ่านเปิดก่อนการโหลด ให้ใช้ `PresentationInfo.is_password_protected` ตามที่แสดงข้างต้น.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **คำแนะนำด้านความปลอดภัย**

{{% alert color="warning" title="Security" %}}
ห้ามบันทึกรหัสผ่านเปิดหรือใส่ไว้ในข้อความวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเพียงเท่าที่จำเป็น และใช้ผลการตรวจสอบที่สำเร็จซ้ำเมื่อโหลดการนำเสนอโดยทันที.
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock).
2. เลือกหรืออัปโหลดการนำเสนอ.
3. ป้อนรหัสผ่านสำหรับการป้องกันการดู.
4. หากต้องการ สามารถป้อนรหัสผ่านแยกต่างหากสำหรับการป้องกันการแก้ไข.
5. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้.

{{% alert color="info" title="See also" %}}
- [การป้องกันการเขียนการนำเสนอ](/slides/th/python-net/write-protected-presentation/)
- [ลายเซ็นดิจิทัลใน PowerPoint](/slides/th/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างรหัสผ่านเปิดกับรหัสผ่านป้องกันการเขียนคืออะไร?**

รหัสผ่านเปิดทำการเข้ารหัสการนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา ส่วนรหัสผ่านป้องกันการเขียนจำกัดการแก้ไขโดยไม่เข้ารหัสเนื้อหา.

**ฉันสามารถตรวจสอบรหัสผ่านเปิดโดยไม่ต้องโหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้ ใช่ ให้รับข้อมูลการนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดหรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ.

**กระบวนการตรวจสอบรหัสผ่านสนับสนุนทั้ง PPT และ PPTX หรือไม่?**

ได้เช่นกัน การตรวจจับและตรวจสอบรหัสผ่านตามเส้นทางไฟล์และตามสตรีมทำงานเหมือนกันสำหรับการนำเสนอ PPT และ PPTX.