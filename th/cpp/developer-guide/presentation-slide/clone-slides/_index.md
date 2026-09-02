---
title: โคลนสไลด์การนำเสนอใน C++
linktitle: โคลนสไลด์
type: docs
weight: 40
url: /th/cpp/clone-slides/
keywords:
- โคลนสไลด์
- คัดลอกสไลด์
- บันทึกสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "คัดลอกสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides for C++ ปฏิบัติตามตัวอย่างโค้ดที่ชัดเจนของเราเพื่อทำการสร้าง PPT อัตโนมัติในไม่กี่วินาทีและขจัดงานที่ต้องทำด้วยมือ"
---
## **บทนำ**

การทำสำเนา (Cloning) คือกระบวนการสร้างสำเนาที่ตรงกันหรือจำลองสิ่งใดสิ่งหนึ่งอย่างแม่นยำ Aspose.Slides for C++ ยังทำให้สามารถสร้างสำเนาหรือโคลนของสไลด์ใด ๆ แล้วแทรกสไลด์ที่โคลนนั้นเข้าสู่การพรีเซนเทชันปัจจุบันหรือการพรีเซนเทชันอื่นที่เปิดอยู่ได้ กระบวนการโคลนสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบต่อสไลด์ต้นฉบับ มีหลายวิธีที่สามารถโคลนสไลด์ได้:

- โคลนที่ตำแหน่งสุดท้ายภายในพรีเซนเทชันเดียวกัน
- โคลนที่ตำแหน่งอื่นภายในพรีเซนเทชันเดียวกัน
- โคลนที่ตำแหน่งสุดท้ายในพรีเซนเทชันอื่น
- โคลนที่ตำแหน่งอื่นในพรีเซนเทชันอื่น
- โคลนที่ตำแหน่งที่กำหนดในพรีเซนเทชันอื่น

ใน Aspose.Slides for C++ (คอลเลกชันของอ็อบเจกต์ [ISlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) ) ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) และ [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/) เพื่อดำเนินการโคลนสไลด์ตามประเภทที่กล่าวข้างต้น

## **โคลนสไลด์ที่ตำแหน่งสุดท้ายของพรีเซนเทชัน**
หากคุณต้องการโคลนสไลด์และจากนั้นใช้ในไฟล์พรีเซนเทชันเดียวกันที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่ ให้ใช้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) .
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) .
1. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ที่เปิดเผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) และส่งสไลด์ที่ต้องการโคลนเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) .
1. เขียนไฟล์พรีเซนเทชันที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (อยู่ที่ตำแหน่งแรก – ดัชนีศูนย์ – ของพรีเซนเทชัน) ไปยังตำแหน่งสุดท้ายของพรีเซนเทชัน

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **โคลนสไลด์ไปยังตำแหน่งอื่นภายในพรีเซนเทชันเดียวกัน**
 in Presentation**
หากคุณต้องการโคลนสไลด์และจากนั้นใช้ในไฟล์พรีเซนเทชันเดียวกันแต่ตำแหน่งต่างออกไป ให้ใช้เมธอด [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/) :

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) .
1. สร้างอินสแตนซ์ของคลาสโดยอ้างอิงคอลเลกชัน **Slides** ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) .
1. เรียกเมธอด [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/) ที่เปิดเผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) และส่งสไลด์ที่ต้องการโคลนพร้อมกับดัชนีตำแหน่งใหม่เป็นพารามิเตอร์ให้เมธอด [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/) .
1. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (อยู่ที่ดัชนีศูนย์ – ตำแหน่ง 1 – ของพรีเซนเทชัน) ไปยังดัชนี 1 – ตำแหน่ง 2 – ของพรีเซนเทชัน

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **โคลนสไลด์ที่ตำแหน่งสุดท้ายของพรีเซนเทชันอื่น**
หากคุณต้องการโคลนสไลด์จากพรีเซนเทชันหนึ่งและใช้ในพรีเซนเทชันอื่นที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่ประกอบด้วยพรีเซนเทชันที่สไลด์จะถูกโคลนจาก
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่ประกอบด้วยพรีเซนเทชันปลายทางที่จะเพิ่มสไลด์เข้าไป
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) โดยอ้างอิงคอลเลกชัน **Slides** ที่เปิดเผยโดยอ็อบเจกต์ Presentation ของพรีเซนเทชันปลายทาง
1. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ที่เปิดเผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) และส่งสไลด์จากพรีเซนเทชันต้นทางเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) .
1. เขียนไฟล์พรีเซนเทชันปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (จากดัชนีแรกของพรีเซนเทชันต้นทาง) ไปยังตำแหน่งสุดท้ายของพรีเซนเทชันปลายทาง

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **โคลนสไลด์ไปยังตำแหน่งอื่นในพรีเซนเทชันอื่น**
หากคุณต้องการโคลนสไลด์จากพรีเซนเทชันหนึ่งและใช้ในพรีเซนเทชันอื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่มีพรีเซนเทชันต้นทางที่สไลด์จะถูกโคลนจาก
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่มีพรีเซนเทชันที่จะเพิ่มสไลด์เข้าไป
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจกต์ Presentation ของพรีเซนเทชันปลายทาง
1. เรียกเมธอด [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/) ที่เปิดเผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) และส่งสไลด์จากพรีเซนเทชันต้นทางพร้อมตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้เมธอด [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/) .
1. เขียนไฟล์พรีเซนเทชันปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (จากดัชนีศูนย์ของพรีเซนเทชันต้นทาง) ไปยังดัชนี 1 (ตำแหน่ง 2) ของพรีเซนเทชันปลายทาง

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **โคลนสไลด์ที่ตำแหน่งที่กำหนดในพรีเซนเทชันอื่น**
หากคุณต้องการโคลนสไลด์พร้อมมาสเตอร์สไลด์จากพรีเซนเทชันหนึ่งและใช้ในพรีเซนเทชันอื่น คุณต้องโคลนมาสเตอร์สไลด์ที่ต้องการจากพรีเซนเทชันต้นทางไปยังพรีเซนเทชันปลายทางก่อน แล้วจึงใช้มาสเตอร์สไลด์นั้นในการโคลนสไลด์พร้อมมาสเตอร์สไลด์ เมธอด **AddClone(ISlide, IMasterSlide)** คาดหวังมาสเตอร์สไลด์จากพรีเซนเทชันปลายทาง ไม่ใช่จากพรีเซนเทชันต้นทาง เพื่อโคลนสไลด์พร้อมมาสเตอร์ กรุณาตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่มีพรีเซนเทชันต้นทางที่สไลด์จะถูกโคลนจาก
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่มีพรีเซนเทชันปลายทางที่สไลด์จะถูกโคลนไป
1. เข้าถึงสไลด์ที่ต้องการโคลนพร้อมกับมาสเตอร์สไลด์
1. สร้างอินสแตนซ์ของคลาส [IMasterSlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/) โดยอ้างอิงคอลเลกชัน Masters ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ของพรีเซนเทชันปลายทาง
1. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ที่เปิดเผยโดยอ็อบเจกต์ [IMasterSlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/) และส่งมาสเตอร์จากไฟล์ PPTX ต้นทางที่จะโคลนเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) .
1. สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) โดยตั้งค่าอ้างอิงไปยังคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ของพรีเซนเทชันปลายทาง
1. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ที่เปิดเผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) และส่งสไลด์จากพรีเซนเทชันต้นทางที่ต้องการโคลนและมาสเตอร์สไลด์เป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) .
1. เขียนไฟล์พรีเซนเทชันปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์พร้อมมาสเตอร์ (อยู่ที่ดัชนีศูนย์ของพรีเซนเทชันต้นทาง) ไปยังตำแหน่งสุดท้ายของพรีเซนเทชันปลายทางโดยใช้มาสเตอร์จากสไลด์ต้นทาง

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **โคลนสไลด์ที่ตำแหน่งสุดท้ายของส่วนที่ระบุ**
หากคุณต้องการโคลนสไลด์และจากนั้นใช้ในไฟล์พรีเซนเทชันเดียวกันแต่ในส่วนที่ต่างกัน ให้ใช้เมธอด [**AddClone()**](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ที่เปิดเผยโดยอินเตอร์เฟส [**ISlideCollection**](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) Aspose.Slides for C++ ทำให้สามารถโคลนสไลด์จากส่วนแรกแล้วแทรกสไลด์ที่โคลนนั้นไปยังส่วนที่สองของพรีเซนเทชันเดียวกันได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีโคลนสไลด์และแทรกสไลด์ที่โคลนเข้าไปใน section ที่ระบุ

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **ตรวจสอบให้ขนาดสไลด์ตรงกัน**

เมื่อโคลนสไลด์ไปยังพรีเซนเทชันอื่น ให้แน่ใจว่าพรีเซนเทชันปลายทางมีขนาดสไลด์เดียวกับต้นทาง หากขนาดสไลด์แตกต่างกัน Aspose.Slides จะไม่ปรับขนาดรูปร่างที่โคลนโดยอัตโนมัติ – พิกัดและขนาดดั้งเดิมจะคงไว้ซึ่งอาจทำให้เนื้อหาแสดงออกนอกขอบสไลด์หรือจัดแนวผิดพลาด

คุณสามารถตั้งค่าขนาดสไลด์ของพรีเซนเทชันปลายทางให้ตรงกับต้นทางก่อนการโคลนมาสเตอร์และสไลด์ได้:

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

ทำเช่นนี้ก่อนการโคลนมาสเตอร์และสไลด์

## **คำถามที่พบบ่อย**

**บันทึกผู้พูดและคอมเมนต์ของผู้ตรวจสอบจะถูกโคลนด้วยหรือไม่?**

ใช่. หน้าโน้ตและคอมเมนต์การตรวจสอบจะรวมอยู่ในโคลน หากคุณไม่ต้องการมัน, [ลบออก](/slides/th/cpp/presentation-notes/) หลังจากแทรก

**แผนภูมิและแหล่งข้อมูลของมันถูกจัดการอย่างไร?**

อ็อบเจกต์แผนภูมิ การจัดรูปแบบ และข้อมูลที่ฝังจะถูกคัดลอก หากแผนภูมิเชื่อมโยงกับแหล่งข้อมูลภายนอก (เช่น ไฟล์ workbook ที่ฝังด้วย OLE) การเชื่อมต่อจะถูกเก็บไว้เป็น [OLE object](/slides/th/cpp/manage-ole/) หลังจากย้ายระหว่างไฟล์ ให้ตรวจสอบความพร้อมของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนต่าง ๆ ของโคลนได้หรือไม่?**

ใช่. คุณสามารถแทรกโคลนที่ดัชนีสไลด์ที่ระบุและวางลงใน[section](/slides/th/cpp/slide-section/)ที่เลือก หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างก่อนแล้วจึงย้ายสไลด์เข้าไป