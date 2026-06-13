---
title: ดึงข้อมูลและอัปเดตข้อมูลการนำเสนอใน C++
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/cpp/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- รับคุณสมบัติ
- อ่านคุณสมบัติ
- เปลี่ยนคุณสมบัติ
- แก้ไขคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "สำรวจสไลด์, โครงสร้างและเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย C++ เพื่อให้ได้ข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides คำอธิบายวิธีกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม, อ่านคุณสมบัติเอกสาร, และอัปเดตคุณสมบัตินั้นเมื่อจำเป็น

ตัวอย่างอ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/documentproperties/) และแสดงการดำเนินการทั่วไปสำหรับการทำงานกับเมทาเดต้าของการนำเสนอ

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนที่จะทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนออยู่ในรูปแบบใด (PPT, PPTX, ODP และอื่น ๆ) ในขณะนั้น

คุณสามารถตรวจสอบรูปแบบของการนำเสนอได้โดยไม่ต้องโหลดการนำเสนอ ดูโค้ด C++ นี้:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **รับคุณสมบัติการนำเสนอ**

โค้ด C++ นี้แสดงวิธีการรับคุณสมบัติการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```

## **อัปเดตคุณสมบัติการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) ที่ช่วยให้คุณสามารถทำการเปลี่ยนแปลงคุณสมบัติของการนำเสนอได้

สมมติว่าเรามีไฟล์ PowerPoint ที่มีคุณสมบัติเอกสารดังแสดงต่อไปนี้

![คุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีการแก้ไขคุณสมบัติบางส่วนของการนำเสนอ:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

ผลลัพธ์ของการเปลี่ยนแปลงคุณสมบัติเอกสารแสดงต่อไปนี้

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

หากต้องการข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและคุณลักษณะด้านความปลอดภัย คุณอาจพบว่าลิงก์ต่อไปนี้เป็นประโยชน์:

- [ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่](https://docs.aspose.com/slides/th/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียน (อ่านอย่างเดียว) หรือไม่](https://docs.aspose.com/slides/th/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [ตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านก่อนโหลดหรือไม่](https://docs.aspose.com/slides/th/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [ยืนยันรหัสผ่านที่ใช้ป้องกันการนำเสนอ](https://docs.aspose.com/slides/th/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบว่าแบบอักษรถูกฝังหรือไม่และเป็นแบบใดบ้าง?**

ค้นหาข้อมูล [embedded-font information](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/getembeddedfonts/) ระดับการนำเสนอ จากนั้นเปรียบเทียบรายการนั้นกับชุด [fonts actually used across content](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/getfonts/) เพื่อระบุว่าแบบอักษรใดสำคัญต่อการเรนเดอร์

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไหร่?**

วนลูปผ่าน [slide collection](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidecollection/) และตรวจสอบ [visibility flag](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/get_hidden/) ของแต่ละสไลด์

**ฉันสามารถตรวจจับว่ามีการใช้ขนาดและแนวทางสไลด์ที่กำหนดเองหรือไม่ และว่าต่างจากค่าเริ่มต้นหรือไม่?**

ใช่. เปรียบเทียบ [slide size and orientation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slidesize/) ปัจจุบันกับค่ากำหนดมาตรฐาน; นี้ช่วยคาดการณ์พฤติกรรมสำหรับการพิมพ์และการส่งออก

**มีวิธีรวดเร็วในการดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ใช่. ตรวจสอบทุก [charts](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/) ตรวจสอบ [data source](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) ของพวกมันและบันทึกว่าข้อมูลเป็นภายในหรืออ้างอิงลิงก์ รวมถึงลิงก์ที่เสียหาย

**ฉันจะประเมินสไลด์ที่ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออก PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์ ให้นับจำนวนออบเจ็กต์และมองหารูปภาพขนาดใหญ่, ความโปร่งใส, เงา, แอนิเมชัน, และมัลติมีเดีย; กำหนดคะแนนความซับซ้อนโดยประมาณเพื่อระบุจุดร้อนของประสิทธิภาพที่อาจเกิดขึ้น