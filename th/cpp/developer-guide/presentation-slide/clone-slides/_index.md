---
title: "คัดลอกสไลด์การนำเสนอใน C++"
linktitle: "คัดลอกสไลด์"
type: docs
weight: 40
url: /th/cpp/clone-slides/
keywords:
- "คัดลอกสไลด์"
- "ทำสำเนาสไลด์"
- "บันทึกสไลด์"
- "PowerPoint"
- "OpenDocument"
- "การนำเสนอ"
- "C++"
- "Aspose.Slides"
description: "ทำสำเนาสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ C++. ปฏิบัติตามตัวอย่างโค้ดที่ชัดเจนของเราเพื่ออัตโนมัติการสร้าง PPT ในไม่กี่วินาทีและขจัดงานที่ทำด้วยมือ."
---
## **บทนำ**

การคัดลอก (Cloning) คือกระบวนการสร้างสำเนาที่สมบูรณ์หรือแบบจำลองที่เหมือนกันของสิ่งใดสิ่งหนึ่ง Aspose.Slides for C++ ยังทำให้สามารถสร้างสำเนาหรือคัดลอกสไลด์ใด ๆ แล้วแทรกสไลด์ที่คัดลอกนั้นเข้าไปในงานนำเสนอปัจจุบันหรือในงานนำเสนออื่นที่เปิดอยู่ได้ กระบวนการคัดลอกสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบต่อสไลด์ต้นฉบับ มีหลายวิธีในการคัดลอกสไลด์:

- คัดลอกที่ตำแหน่งสุดท้ายภายในงานนำเสนอ
- คัดลอกที่ตำแหน่งอื่นในงานนำเสนอ
- คัดลอกที่ตำแหน่งสุดท้ายในงานนำเสนออื่น
- คัดลอกที่ตำแหน่งอื่นในงานนำเสนออื่น
- คัดลอกที่ตำแหน่งเฉพาะในงานนำเสนออื่น

ใน Aspose.Slides for C++ (คอลเลกชันของ [ISlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/) objects) ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) และ [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/) เพื่อทำการคัดลอกสไลด์ตามประเภทที่กล่าวมาข้างต้น

## **คัดลอกสไลด์ที่ตำแหน่งสุดท้ายของงานนำเสนอ**
หากต้องการคัดลอกสไลด์แล้วใช้มันในไฟล์งานนำเสนอเดียวกันที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่แล้ว ให้ใช้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. อินสแตนซ์คลาส [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
3. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ที่เปิดเผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) และส่งสไลด์ที่ต้องการคัดลอกเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/)  
4. เขียนไฟล์งานนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (ที่อยู่ในตำแหน่งแรก – ดัชนีศูนย์ – ของงานนำเสนอ) ไปยังตำแหน่งสุดท้ายของงานนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **คัดลอกสไลด์ไปยังตำแหน่งอื่นในงานนำเสนอเดียวกัน**
หากต้องการคัดลอกสไลด์แล้วใช้มันในไฟล์งานนำเสนอเดียวกันแต่ที่ตำแหน่งอื่น ให้ใช้เมธอด [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/) :

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. อินสแตนซ์คลาสโดยอ้างอิงคอลเลกชัน **Slides** ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
3. เรียกเมธอด [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/) ที่เปิดเผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) และส่งสไลด์ที่ต้องการคัดลอกพร้อมด้วยดัชนีของตำแหน่งใหม่เป็นพารามิเตอร์ให้เมธอด [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/)  
4. เขียนไฟล์งานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (ที่อยู่ในดัชนีศูนย์ – ตำแหน่ง 1 – ของงานนำเสนอ) ไปยังดัชนี 1 – ตำแหน่ง 2 – ของงานนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **คัดลอกสไลด์ที่ตำแหน่งสุดท้ายของงานนำเสนออื่น**
หากต้องการคัดลอกสไลด์จากงานนำเสนอหนึ่งและใช้ในไฟล์งานนำเสนออื่นที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่บรรจุงานนำเสนอที่สไลด์จะถูกคัดลอกจากนั้น  
2. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่บรรจุงานนำเป้าหมายที่สไลด์จะถูกเพิ่มเข้าไป  
3. อินสแตนซ์คลาส [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) โดยอ้างอิงคอลเลกชัน **Slides** ที่เปิดเผยโดยอ็อบเจกต์ Presentation ของงานนำเป้าหมาย  
4. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ที่เปิดเผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) และส่งสไลด์จากงานนำเสนอแหล่งที่มาเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/)  
5. เขียนไฟล์งานนำเป้าหมายที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (จากดัชนีแรกของงานนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของงานนำเสนอเป้าหมาย

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **คัดลอกสไลด์ไปยังตำแหน่งอื่นในงานนำเสนออื่น**
หากต้องการคัดลอกสไลด์จากงานนำเสนอหนึ่งและใช้ในไฟล์งานนำเสนออื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่บรรจุงานนำเสนอแหล่งที่สไลด์จะถูกคัดลอกจากนั้น  
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่บรรจุงานนำเสนอเป้าหมายที่สไลด์จะถูกเพิ่มเข้าไป  
3. อินสแตนซ์คลาส [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) โดยอ้างอิงคอลเลกชัน Slides ของอ็อบเจกต์ Presentation ของงานนำเป้าหมาย  
4. เรียกเมธอด [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/) ที่เปิดเผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) และส่งสไลด์จากงานนำเสนอแหล่งที่มาพร้อมตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้เมธอด [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/insertclone/)  
5. เขียนไฟล์งานนำเป้าหมายที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (จากดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังดัชนี 1 (ตำแหน่ง 2) ของงานนำเสนอเป้าหมาย

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **คัดลอกสไลด์ที่ตำแหน่งเฉพาะในงานนำเสนออื่น**
หากต้องการคัดลอกสไลด์พร้อมมาสเตอร์สไลด์จากงานนำเสนอหนึ่งและใช้ในงานนำเสนออื่น คุณต้องคัดลอกมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มามาไว้ในงานนำเสนอเป้าหมายก่อน จากนั้นจึงใช้มาสเตอร์สไลด์นั้นในการคัดลอกสไลด์พร้อมมาสเตอร์สไลด์ เมธอด **AddClone(ISlide, IMasterSlide)** คาดว่าจะรับมาสเตอร์สไลด์จากงานนำเสนอเป้าหมาย ไม่ใช่จากแหล่งที่มา เพื่อคัดลอกสไลด์พร้อมมาสเตอร์สไลด์ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่บรรจุงานนำเสนอแหล่งที่สไลด์จะถูกคัดลอกจากนั้น  
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ที่บรรจุงานนำเสนอเป้าหมายที่สไลด์จะถูกคัดลอกไป  
3. เข้าถึงสไลด์ที่ต้องการคัดลอกพร้อมกับมาสเตอร์สไลด์  
4. อินสแตนซ์คลาส [IMasterSlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/) โดยอ้างอิงคอลเลกชัน Masters ของอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ของงานนำเสนอเป้าหมาย  
5. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ที่เปิดเผยโดยอ็อบเจกต์ [IMasterSlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslidecollection/) และส่งมาสเตอร์จากไฟล์ PPTX แหล่งที่มาที่ต้องการคัดลอกเป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/)  
6. อินสแตนซ์คลาส [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) โดยตั้งค่าให้อ้างอิงคอลเลกชัน Slides ของอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) ของงานนำเสนอเป้าหมาย  
7. เรียกเมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ที่เปิดเผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) และส่งสไลด์จากงานนำเสนอแหล่งที่มาที่ต้องการคัดลอกพร้อมมาสเตอร์สไลด์เป็นพารามิเตอร์ให้เมธอด [AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/)  
8. เขียนไฟล์งานนำเสนอเป้าหมายที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์พร้อมมาสเตอร์ (ที่อยู่ในดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของงานนำเสนอเป้าหมายโดยใช้มาสเตอร์จากสไลด์แหล่งที่มา

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **คัดลอกสไลด์ที่ตำแหน่งสุดท้ายของส่วนที่กำหนด**
หากต้องการคัดลอกสไลด์แล้วใช้มันในไฟล์งานนำเสนอเดียวกันแต่ในส่วนที่ต่างกัน ให้ใช้เมธอด [**AddClone()**](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/addclone/) ที่เปิดเผยโดยอินเทอร์เฟซ [**ISlideCollection**](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecollection/) Aspose.Slides for C++ ทำให้สามารถคัดลอกสไลด์จากส่วนแรกแล้วแทรกสไลด์ที่คัดลอกนั้นไปยังส่วนที่สองของงานนำเสนอเดียวกันได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีคัดลอกสไลด์และแทรกสไลด์ที่คัดลอกเข้าไปในส่วนที่กำหนด

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **คำถามที่พบบ่อย**

**บันทึกพูดและความเห็นของผู้ตรวจสอบถูกคัดลอกหรือไม่?**

ใช่. หน้าโน้ตและความเห็นของผู้ตรวจสอบจะถูกรวมอยู่ในสำเนา หากไม่ต้องการ ให้ [ลบออก](/slides/th/cpp/presentation-notes/) หลังการแทรก

**แผนภูมิและแหล่งข้อมูลของมันถูกจัดการอย่างไร?**

อ็อบเจกต์แผนภูมิ การจัดรูปแบบ และข้อมูลที่ฝังจะถูกคัดลอก หากแผนภูมิเชื่อมโยงกับแหล่งภายนอก (เช่น ไฟล์เวิร์กบุ๊กที่ฝังด้วย OLE) การเชื่อมโยงนั้นจะยังคงอยู่เป็น [อ็อบเจกต์ OLE](/slides/th/cpp/manage-ole/) หลังจากย้ายระหว่างไฟล์ ควรตรวจสอบการพร้อมใช้งานของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนของสำเนาได้หรือไม่?**

ได้ คุณสามารถแทรกสำเนาที่ดัชนีสไลด์เฉพาะและวางไว้ใน [ส่วน](/slides/th/cpp/slide-section/) ที่เลือก หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างก่อนแล้วค่อยย้ายสไลด์เข้าไปในส่วนนั้น