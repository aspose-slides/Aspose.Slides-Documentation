---
title: ดึงและอัปเดตข้อมูลการนำเสนอใน C++
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/cpp/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- ดึงคุณสมบัติ
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
description: "สำรวจสไลด์, โครงสร้างและเมตาดาต้าในการนำเสนอ PowerPoint และ OpenDocument ด้วย C++ เพื่อให้ได้ข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ฉลาดขึ้น."
---
## **ภาพรวม**

บทความนี้แสดงวิธีตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides โดยอธิบายวิธีกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม, อ่านคุณสมบัติของเอกสาร, และอัปเดตคุณสมบัติเหล่านั้นเมื่อจำเป็น

ตัวอย่างอ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/documentproperties/) และแสดงการดำเนินการทั่วไปสำหรับการทำงานกับเมตาดาต้าการนำเสนอ

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนออยู่ในรูปแบบใด (PPT, PPTX, ODP, และอื่น ๆ) ในขณะนี้

คุณสามารถตรวจสอบรูปแบบของการนำเสนอได้โดยไม่ต้องโหลดการนำเสนอ ดูโค้ด C++ นี้:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

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

โค้ด C++ นี้แสดงวิธีรับคุณสมบัติการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ต่อไป
```

## **อัปเดตคุณสมบัติการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) ที่ช่วยให้คุณทำการเปลี่ยนแปลงคุณสมบัติการนำเสนอได้

สมมติว่ามีการนำเสนอ PowerPoint พร้อมคุณสมบัติเอกสารที่แสดงด้านล่าง

![คุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีแก้ไขคุณสมบัติการนำเสนอบางส่วน:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

ผลลัพธ์ของการเปลี่ยนแปลงคุณสมบัติเอกสารแสดงด้านล่าง

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

เพื่อรับข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและคุณลักษณะด้านความปลอดภัย คุณอาจพบว่าลิงก์เหล่านี้เป็นประโยชน์:

- [การปกป้องการนำเสนอด้วยรหัสผ่าน](/slides/th/cpp/password-protected-presentation/)
- [การปกป้องการนำเสนอจากการเขียน](/slides/th/cpp/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรถูกฝังและเป็นแบบใดบ้าง?**

ค้นหาข้อมูล [embedded-font information](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/getembeddedfonts/) ในระดับการนำเสนอ จากนั้นเปรียบเทียบรายการเหล่านั้นกับชุดของ [fonts actually used across content](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsmanager/getfonts/) เพื่อระบุว่าแบบอักษรใดเป็นสิ่งสำคัญสำหรับการเรนเดอร์

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ซ่อนไปหรือไม่และจำนวนเท่าไร?**

วนรอบผ่าน [slide collection](https://reference.aspose.com/slides/th/cpp/aspose.slides/slidecollection/) และตรวจสอบ [visibility flag](https://reference.aspose.com/slides/th/cpp/aspose.slides/slide/get_hidden/) ของแต่ละสไลด์

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและแนวตั้งสไลด์ที่กำหนดเอง และว่ามันต่างจากค่าเริ่มต้นหรือไม่?**

ใช่. เปรียบเทียบ [slide size and orientation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slidesize/) ปัจจุบันกับการตั้งค่ามาตรฐาน; สิ่งนี้ช่วยคาดการณ์พฤติกรรมสำหรับการพิมพ์และการส่งออก

**มีวิธีรวดเร็วในการดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ใช่. ไปตาม [charts](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/) ทั้งหมด ตรวจสอบ [data source](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) ของพวกมัน และบันทึกว่าข้อมูลเป็นภายในหรือเชื่อมโยง, รวมถึงลิงก์ที่ขัดข้องใด ๆ

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออก PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์ ให้นับจำนวนวัตถุและค้นหารูปภาพขนาดใหญ่, ความโปร่งใส, เงา, การเคลื่อนไห
