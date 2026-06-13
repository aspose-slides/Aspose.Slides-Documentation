---
title: จัดการการเปลี่ยนสไลด์ในการนำเสนอด้วย C++
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 80
url: /th/cpp/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- ใช้การเปลี่ยนสไลด์
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยน Morph
- ประเภทการเปลี่ยน
- ผลกระทบการเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบวิธีปรับแต่งการเปลี่ยนสไลด์ใน Aspose.Slides สำหรับ C++ พร้อมคำแนะนำทีละขั้นตอนสำหรับงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดการการเปลี่ยนภาพสไลด์ในงานนำเสนอโดยใช้ Aspose.Slides มันแสดงวิธีการใช้ประเภทการเปลี่ยนภาพบนสไลด์, กำหนดค่าพฤติกรรมการเปลี่ยนเช่น การเพิ่มหน้าด้วยคลิกหรือหลังจากระยะเวลาที่กำหนด, ตรวจสอบและปิดการเพิ่มอัตโนมัติ, ใช้การเปลี่ยนแบบ Morph และประเภทของมัน, และตั้งค่าตัวเลือกผลกระทบการเปลี่ยนแปลง ตัวอย่างแสดงวิธีการโหลดหรือสร้างงานนำเสนอ, แก้ไขการตั้งค่าการเปลี่ยนสำหรับสไลด์ที่เลือก, และบันทึกผลลัพธ์เป็นไฟล์ PPTX บทความนี้ยังตอบคำถามทั่วไปเกี่ยวกับความเร็วการเปลี่ยน, เสียงการเปลี่ยน, การใช้การเปลี่ยนเดียวกันกับหลายสไลด์, และการตรวจสอบการเปลี่ยนที่ตั้งค่าอยู่บนสไลด์

## **เพิ่มการเปลี่ยนสไลด์**
เพื่อให้เข้าใจง่ายขึ้น เราได้แสดงการใช้ Aspose.Slides for C++ เพื่อจัดการการเปลี่ยนสไลด์แบบง่าย นักพัฒนาสามารถไม่เพียงแค่ใช้เอฟเฟกต์การเปลี่ยนสไลด์ที่แตกต่างบนสไลด์เท่านั้น แต่ยังสามารถปรับแต่งพฤติกรรมของเอฟเฟกต์เหล่านี้ได้ เพื่สร้างเอฟเฟกต์การเปลี่ยนสไลด์แบบง่าย ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)
1. ใช้ประเภทการเปลี่ยนสไลด์บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่เสนอโดย Aspose.Slides for C++ ผ่าน enum TransitionType
1. เขียนไฟล์งานนำเสนอที่แก้ไขแล้ว

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**
ในส่วนข้างต้น เราได้ใช้เอฟเฟกต์การเปลี่ยนสไลด์แบบง่ายบนสไลด์แล้ว ตอนนี้เพื่อทำให้เอฟเฟกต์การเปลี่ยนสไลด์แบบง่ายนั้นดียิ่งขึ้นและควบคุมได้ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)
1. ใช้ประเภทการเปลี่ยนสไลด์บนสไลด์จากหนึ่งในเอฟเฟกต์การเปลี่ยนที่เสนอโดย Aspose.Slides for C++
1. คุณยังสามารถตั้งค่าการเปลี่ยนให้เพิ่มเมื่อคลิก, หลังจากช่วงเวลาที่กำหนด หรือทั้งสองอย่างได้
1. หากการเปลี่ยนสไลด์ถูกเปิดใช้งานให้เพิ่มเมื่อคลิก การเปลี่ยนจะดำเนินต่อเมื่อมีการคลิกเมาส์เท่านั้น นอกจากนี้ หากตั้งค่าคุณสมบัติ Advance After Time ไว้ การเปลี่ยนจะดำเนินอัตโนมัติหลังจากเวลาที่กำหนดผ่านไป
1. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์งานนำเสนอ

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **การเปลี่ยน Morph**
Aspose.Slides for C++ ตอนนี้รองรับการเปลี่ยนแบบ Morph ซึ่งเป็นการเปลี่ยน morph ใหม่ที่นำเข้ามาใน PowerPoint 2019 การเปลี่ยน Morph ช่วยให้คุณสร้างการเคลื่อนไหวที่ราบรื่นจากสไลด์หนึ่งไปยังสไลด์ถัดไป บทความนี้อธิบายแนวคิดและวิธีการใช้การเปลี่ยน Morph เพื่อใช้การเปลี่ยน Morph อย่างมีประสิทธิภาพ คุณต้องมีสไลด์สองสไลด์ที่มีอย่างน้อยหนึ่งวัตถุร่วมกัน วิธีที่ง่ายที่สุดคือทำสำเนาสไลด์และย้ายวัตถุบนสไลด์ที่สองไปยังตำแหน่งอื่น

โค้ดส่วนต่อไปนี้แสดงวิธีการเพิ่มสำเนาของสไลด์ที่มีข้อความบางส่วนไปยังงานนำเสนอและตั้งค่าการเปลี่ยนแบบ morph ให้กับสไลด์ที่สอง

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **ประเภทการเปลี่ยน Morph**
ได้เพิ่ม enum ใหม่ Aspose.Slides.SlideShow.TransitionMorphType ซึ่งแสดงประเภทต่าง ๆ ของการเปลี่ยนสไลด์แบบ Morph

enum TransitionMorphType มีสามสมาชิก:

- ByObject: การเปลี่ยน Morph จะดำเนินการโดยพิจารณารูปร่างเป็นวัตถุที่ไม่สามารถแยกย่อยได้
- ByWord: การเปลี่ยน Morph จะทำโดยการย้ายข้อความตามคำที่เป็นไปได้
- ByChar: การเปลี่ยน Morph จะทำโดยการย้ายข้อความตามตัวอักษรที่เป็นไปได้

โค้ดส่วนต่อไปนี้แสดงวิธีตั้งค่าการเปลี่ยน Morph ให้สไลด์และเปลี่ยนประเภท morph:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **ตั้งค่าผลกระทบการเปลี่ยน**
Aspose.Slides for C++ รองรับการตั้งค่าผลกระทบการเปลี่ยน เช่น จากสีดำ, จากด้านซ้าย, จากด้านขวา ฯลฯ เพื่อกำหนดผลกระทบการเปลี่ยน โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส Presentation
- ดึงอ้างอิงของสไลด์
- ตั้งค่าผลกระทบการเปลี่ยน
- เขียนงานนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าผลกระทบการเปลี่ยนแล้ว

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ใช่ ตั้งค่าความเร็วของการเปลี่ยนโดยใช้ [speed](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/slideshowtransition/set_speed/) ผ่านการตั้งค่า [TransitionSpeed](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/transitionspeed/) (เช่น ช้า/ปานกลาง/เร็ว).

**ฉันสามารถแนบเสียงไปกับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**

ใช่ คุณสามารถฝังเสียงสำหรับการเปลี่ยนและควบคุมพฤติกรรมผ่านการตั้งค่าเช่น โหมดเสียงและการวนซ้ำ (เช่น [set_Sound](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/), [set_SoundMode](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/), [set_SoundLoop](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/), รวมถึงเมตาดาต้าเช่น [set_SoundIsBuiltIn](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) และ [set_SoundName](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/)).

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

กำหนดค่าประเภทการเปลี่ยนที่ต้องการในการตั้งค่าการเปลี่ยนของแต่ละสไลด์; การเปลี่ยนจะถูกเก็บแยกตามสไลด์ ดังนั้นการใช้ประเภทเดียวกันกับสไลด์ทั้งหมดจะให้ผลลัพธ์สอดคล้องกัน

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งค่าไว้บนสไลด์ในขณะนี้ได้อย่างไร?**

ตรวจสอบ [transition settings](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseslide/get_slideshowtransition/) ของสไลด์และอ่านค่า [transition type](https://reference.aspose.com/slides/th/cpp/aspose.slides.slideshow/slideshowtransition/get_type/) จะบอกคุณอย่างชัดเจนว่ามีเอฟเฟกต์ไหนถูกใช้