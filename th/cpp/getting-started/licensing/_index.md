---
title: การให้ใบอนุญาต
type: docs
weight: 120
url: /th/cpp/licensing/
keywords:
- ใบอนุญาต
- ใบอนุญาตชั่วคราว
- ตั้งค่าใบอนุญาต
- ใช้ใบอนุญาต
- ตรวจสอบใบอนุญาต
- ไฟล์ใบอนุญาต
- เวอร์ชันประเมิน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ใช้, จัดการและแก้ไขปัญหาใบอนุญาตใน Aspose.Slides สำหรับ C++. รับประกันการเข้าถึงคุณสมบัติทั้งหมดโดยไม่มีการหยุดชะงักด้วยคู่มือการให้ใบอนุญาตแบบขั้นตอนต่อขั้นตอนของเรา."
---
## **ภาพรวม**

Aspose.Slides สามารถใช้ในโหมดประเมินหรือด้วยใบอนุญาตที่ถูกต้อง เวอร์ชันประเมินให้ฟังก์ชันการทำงานเดียวกับเวอร์ชันที่มีใบอนุญาต แต่จะเพิ่มลายน้ำประเมินในแต่ละสไลด์ของทุกงานนำเสนอที่บันทึกและตัดข้อความที่โค้ดของคุณอ่านจากงานนำเสนอ

บทความนี้อธิบายว่าการให้ใบอนุญาตทำงานอย่างไรใน Aspose.Slides และวิธีการใช้ใบอนญาติก่อนใช้ไลบรารี ใบอนุญาตสามารถโหลดจากไฟล์หรือสตรีมโดยใช้คลาส `License` บทความยังแสดงวิธีตรวจสอบว่าใบอนุญาตได้ถูกนำไปใช้อย่างถูกต้องหรือไม่

## **ประเมิน Aspose.Slides**

{{% alert color="info" title="Note" %}}
คุณสามารถดาวน์โหลดเวอร์ชันประเมินของ **Aspose.Slides for C++** จาก [หน้าดาวน์โหลด NuGet ของมัน](https://www.nuget.org/packages/Aspose.Slides.Cpp/) หรือเป็นแพกเกจ ZIP จาก [หน้าดาวน์โหลด](https://releases.aspose.com/slides/th/cpp/) เวอร์ชันประเมินให้ฟังก์ชันการทำงานเดียวกับผลิตภัณฑ์ที่มีใบอนุญาต จริง ๆ แล้วแพกเกจประเมินเหมือนกับที่ซื้อ—เพียงแค่เพิ่มโค้ดไม่กี่บรรทัดเพื่อใช้ใบอนุญาตก็จะเป็นเวอร์ชันที่มีใบอนุญาตแล้ว
  
เมื่อคุณพอใจกับการประเมิน **Aspose.Slides** แล้ว คุณสามารถ [ซื้อใบอนุญาต](https://purchase.aspose.com/pricing/slides/th/cpp/) เราแนะนำให้ทบทวนประเภทการสมัครสมาชิกที่มี หากมีคำถามใด ๆ โปรดติดต่อทีมขายของ Aspose  

ใบอนุญาตทุกใบของ Aspose จะรวมการสมัครสมาชิกหนึ่งปีสำหรับการอัปเกรดฟรี รวมถึงเวอร์ชันใหม่และการแก้ไขบั๊กที่ปล่อยในช่วงเวลานั้น ไม่ว่าคุณจะใช้เวอร์ชันที่มีใบอนุญาตหรือเวอร์ชันประเมิน คุณจะได้รับการสนับสนุนด้านเทคนิคฟรีและไม่จำกัดจำนวน
{{% /alert %}} 

**ข้อจำกัดของเวอร์ชันประเมิน**

* เวอร์ชันประเมิน (โดยไม่ได้ระบุใบอนุญาต) ให้ฟังก์ชันการทำงานเต็มรูปแบบของผลิตภัณฑ์ แต่จะเพิ่มกล่องข้อความลายน้ำประเมินในแต่ละสไลด์ของทุกงานนำเสนอที่บันทึก
* ข้อความที่โค้ดของคุณอ่านจากงานนำเสนอจะถูกตัดให้เหลือไม่กี่ตัวอักษรแรก แล้วตามด้วยข้อความแจ้งข้อจำกัดของการประเมิน ข้อความที่โค้ดของคุณเขียนจะถูกบันทึกเต็มรูปแบบ

{{% alert color="info" title="Note" %}}
เพื่อทดสอบ Aspose.Slides โดยไม่มีข้อจำกัด คุณสามารถขอ **ใบอนุญาตชั่วคราว 30 วัน** สำหรับข้อมูลเพิ่มเติม ดูหน้า [How to Get a Temporary License](https://purchase.aspose.com/temporary-license)
{{% /alert %}}

## **การให้ใบอนุญาตใน Aspose.Slides**

* เวอร์ชันประเมินจะกลายเป็นเวอร์ชันที่มีใบอนุญาตหลังจากคุณซื้อใบอนุญาตและนำไปใช้โดยเพิ่มเพียงไม่กี่บรรทัดของโค้ด
* ใบอนุญาตเป็นไฟล์ XML แบบข้อความธรรมดาที่บรรจุรายละเอียดเช่น ชื่อผลิตภัณฑ์ จำนวนผู้พัฒนาที่ได้รับอนุญาต วันที่หมดอายุการสมัครสมาชิก ฯลฯ
* ไฟล์ใบอนุญาตมีลายเซ็นดิจิทัล ดังนั้นจึงต้องไม่ถูกแก้ไข แม้การเปลี่ยนแปลงโดยบังเอิญ—เช่นการเพิ่มบรรทัดใหม่—จะทำให้ไฟล์ไม่เป็นที่ยอมรับ
* เมื่อคุณส่งชื่อไฟล์โดยไม่มีโฟลเดอร์ Aspose.Slides for C++ จะค้นหาไฟล์ใบอนุญาตในไดเรกทอรีทำงานปัจจุบันเท่านั้น จะไม่ค้นหาในโฟลเดอร์ของไฟล์ executables หรือของไลบรารี Aspose.Slides ดังนั้นให้ส่งพาธเต็มเมื่อไฟล์ใบอนุญาตเก็บไว้ที่อื่น
* เพื่อลดข้อจำกัดของเวอร์ชันประเมิน คุณต้องตั้งค่าใบอนุญาตก่อนใช้ Aspose.Slides ใบอนุญาตต้องตั้งค่าเพียงครั้งเดียวต่อแอปพลิเคชันหรือกระบวนการ

## **การใช้ใบอนุญาต**

ใบอนุญาตสามารถโหลดจาก **ไฟล์** หรือ **สตรีม**  

{{% alert color="info" title="Note" %}}
Aspose.Slides มีคลาส [License](https://reference.aspose.com/slides/th/cpp/aspose.slides/license/) สำหรับการดำเนินการเกี่ยวกับใบอนุญาต
{{% /alert %}}  

{{% alert color="warning" title="Warning" %}}
ใบอนุญาตใหม่สามารถเปิดใช้งาน Aspose.Slides ได้เฉพาะกับเวอร์ชัน 21.4 หรือใหม่กว่า เวอร์ชันก่อนหน้าใช้ระบบการให้ใบอนุญาตที่ต่างกันและจะไม่รับรู้ใบอนุญาตเหล่านี้
{{% /alert %}}

### **ไฟล์**

วิธีที่ง่ายที่สุดในการตั้งค่าใบอนุญาตคือวางไฟล์ใบอนุญาตไว้ในไดเรกทอรีทำงานของโปรแกรมและระบุเฉพาะชื่อไฟล์โดยไม่มีพาธ หากต้องการระบุตำแหน่งเต็ม ให้ใส่พาธเต็มของไฟล์  

โค้ด C++ ต่อไปนี้ใช้ไฟล์ใบอนุญาต *Aspose.Slides.lic* จากไดเรกทอรีทำงานของโปรแกรม:

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

หากใบอนุญาตถูกต้อง [License::SetLicense](https://reference.aspose.com/slides/th/cpp/aspose.slides/license/setlicense/) จะคืนค่าและโปรแกรมจบโดยไม่มีผลลัพธ์ จากนั้น Aspose.Slides จะทำงานโดยไม่มีข้อจำกัดของการประเมิน หากไฟล์ไม่อยู่ในไดเรกทอรีทำงาน วิธีนี้จะโยงข้อยกเว้น [FileNotFoundException](https://reference.aspose.com/slides/th/cpp/system.io/filenotfoundexception/) พร้อมข้อความ *License "Aspose.Slides.lic" doesn't exist or access is restricted* ตัวอย่างไม่ได้จัดการข้อยกเว้น ดังนั้นโปรแกรมจะหยุดทำงาน  

{{% alert color="warning" title="Warning" %}}
หากคุณวางไฟล์ใบอนุญาตในไดเรกทอรีอื่น เมื่อเรียกใช้เมธอด [License::SetLicense](https://reference.aspose.com/slides/th/cpp/aspose.slides/license/setlicense/) ชื่อไฟล์ที่อยู่ท้ายพาธต้องตรงกับชื่อไฟล์ใบอนุญาตของคุณอย่างสมบูรณ์  

ตัวอย่างเช่น หากคุณเปลี่ยนชื่อไฟล์ใบอนุญาตเป็น *Aspose.Slides.lic.xml* คุณต้องส่งพาธเต็มที่ลงท้ายด้วย *Aspose.Slides.lic.xml* ไปยังเมธอด [License::SetLicense](https://reference.aspose.com/slides/th/cpp/aspose.slides/license/setlicense/) ในโค้ดของคุณ
{{% /alert %}}

### **สตรีม**

โหลดใบอนุญาตจากสตรีมเมื่อโปรแกรมของคุณไม่ได้เก็บใบอนุญาตเป็นไฟล์ที่สามารถระบุชื่อได้ เช่น เมื่ออ่านใบอนุญาตจากฐานข้อมูล [License::SetLicense](https://reference.aspose.com/slides/th/cpp/aspose.slides/license/setlicense/) รับสตรีมใด ๆ [Stream](https://reference.aspose.com/slides/th/cpp/system.io/stream/) ที่บรรจุใบอนุญาต เพื่อให้ตัวอย่างสั้นลง โค้ด C++ ต่อไปนี้เปิด *Aspose.Slides.lic* ในไดเรกทอรีทำงานด้วย [File::OpenRead](https://reference.aspose.com/slides/th/cpp/system.io/file/openread/) แล้วใช้ใบอนุญาตจากสตรีมนั้น:

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

ใบอนุญาตที่ถูกต้องให้ผลเช่นเดียวกับตัวอย่างไฟล์ หากไฟล์不存在 [File::OpenRead](https://reference.aspose.com/slides/th/cpp/system.io/file/openread/) จะโยงข้อยกเว้น [FileNotFoundException](https://reference.aspose.com/slides/th/cpp/system.io/filenotfoundexception/) ก่อนที่ใบอนุญาตจะถูกนำไปใช้และโปรแกรมจะหยุดทำงาน

## **ตรวจสอบใบอนุญาต**

เพื่อเช็คว่าใบอนุญาตได้ตั้งค่าอย่างถูกต้องหรือไม่ ให้เรียก [License::IsLicensed](https://reference.aspose.com/slides/th/cpp/aspose.slides/license/islicensed/) มันจะคืนค่า `true` เท่านั้นหลังจากใบอนุญาตที่ถูกต้องได้ถูกนำไปใช้ และคืนค่า `false` ก่อนหน้านั้น โค้ด C++ ต่อไปนี้ใช้ไฟล์ใบอนุญาตจากไดเรกทอรีทำงานแล้วตรวจสอบ:

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

เมื่อใบอนุญาตถูกต้อง โปรแกรมจะพิมพ์ *License is good!* หากไฟล์หายหรือไม่ได้เป็นไฟล์ใบอนุญาต [License::SetLicense](https://reference.aspose.com/slides/th/cpp/aspose.slides/license/setlicense/) จะโยงข้อยกเว้นก่อนการตรวจสอบและโปรแกรมจะหยุดโดยไม่พิมพ์อะไร หากไฟล์เป็นใบอนุญาตที่ลายเซ็นไม่ตรง เช่น ถูกแก้ไข SetLicense จะคืนค่าโดยไม่มีข้อผิดพลาดแต่ `IsLicensed` จะคืนค่า `false` ดังนั้นไม่มีการพิมพ์ใด ๆ และ Aspose.Slides จะอยู่ในโหมดประเมินต่อไป

## **ความปลอดภัยของเธรด**

{{% alert color="warning" title="Warning" %}}
เมธอด [License::SetLicense](https://reference.aspose.com/slides/th/cpp/aspose.slides/license/setlicense/) **ไม่ปลอดภัยต่อเธรด** หากคุณต้องการเรียกเมธอดนี้จากหลายเธรดพร้อมกัน แนะนำให้ใช้ primitive การซิงโครไนซ์ (เช่น lock) เพื่อป้องกันปัญหาที่อาจเกิดขึ้น
{{% /alert %}}

## **FAQ**

### Can I apply the license in a completely offline environment (no internet access)?

ใช่ การตรวจสอบใบอนุญาตทำงานแบบออฟไลน์โดยใช้ไฟล์ใบอนุญาต; ไม่จำเป็นต้องเชื่อมต่ออินเทอร์เน็ต

### What happens after the one-year subscription expires? Will the library stop working?

ไม่ ใบอนุญาตเป็นแบบถาวร: คุณสามารถใช้เวอร์ชันที่ออกก่อนวันที่หมดอายุการสมัครต่อไป; เพียงคุณจะไม่สามารถใช้เวอร์ชันใหม่ที่ออกหลังจากนั้นได้หากไม่ได้ต่ออายุ.