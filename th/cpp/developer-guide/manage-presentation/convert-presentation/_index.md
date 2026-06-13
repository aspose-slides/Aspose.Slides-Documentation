---
title: แปลงงานนำเสนอเป็นหลายรูปแบบใน C++
linktitle: แปลงงานนำเสนอ
type: docs
weight: 70
url: /th/cpp/convert-presentation/
keywords:
- แปลงงานนำเสนอ
- ส่งออกงานนำเสนอ
- PPT เป็น PPTX
- PPTX เป็น PPT
- ODP เป็น PPTX
- PPT เป็น PDF
- PPTX เป็น PDF
- ODP เป็น PDF
- PPT เป็น HTML
- PPTX เป็น HTML
- ODP เป็น HTML
- PPT เป็น PNG
- PPTX เป็น PNG
- ODP เป็น PNG
- PPTX เป็น JPG
- ODP เป็น JPG
- PPT เป็น XPS
- PPTX เป็น XPS
- ODP เป็น XPS
- PPT เป็น TIFF
- PPTX เป็น TIFF
- ODP เป็น TIFF
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint และ OpenDocument เป็น PPTX, PDF, HTML, ภาพ, XPS, TIFF และอื่น ๆ ด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides สำหรับ C++ สามารถโหลดไฟล์งานนำเสนอ PowerPoint และ OpenDocument แล้วบันทึกหรือแปลงเป็นรูปแบบอื่น ๆ มากมายได้โดยไม่ต้องใช้ Microsoft PowerPoint, OpenOffice หรือ LibreOffice คุณสามารถแปลงไฟล์ PPT เก่าเป็น PPTX สมัยใหม่, ส่งออกงานนำเสนอเป็นเอกสารรูปแบบคงที่เช่น PDF และ XPS, เผยแพร่สไลด์เป็น HTML, หรือแปลงสไลด์เป็นไฟล์รูปภาพสำหรับพรีวิว, ภาพย่อย และการเก็บถาวรได้

การแปลงเอกสารส่วนใหญ่ใช้กระบวนการทำงานทั่วไปเดียวกัน: โหลดไฟล์ต้นฉบับ, เลือกรูปแบบผลลัพธ์ที่ต้องการ, และกำหนดค่าตัวเลือกเฉพาะรูปแบบเมื่อจำเป็น สำหรับรูปแบบภาพแต่ละสไลด์จะถูกเรนเดอร์แยกจากกันแล้วบันทึกเป็นภาพราสเตอร์หรือเวกเตอร์ บทความเฉพาะด้านที่เชื่อมโยงด้านล่างนี้ให้รายละเอียดการทำงานสำหรับแต่ละกรณี

## **เลือกสถานการณ์การแปลง**

ใช้บทความด้านล่างเป็นตัวอย่างโค้ด C++ ฉบับเต็มและตัวเลือกเฉพาะรูปแบบ

| สถานการณ์ | ใช้เมื่อคุณต้องการ | บทความ |
| --- | --- | --- |
| PPT/PPTX/ODP ไปยัง PPTX | ปรับรุ่นไฟล์ PPT เก่า, ทำให้ไฟล์ PPTX มีรูปแบบสอดคล้อง, หรือแปลงงานนำเสนอ OpenDocument ไปเป็น PowerPoint PPTX | [แปลง PPT เป็น PPTX](/slides/th/cpp/convert-ppt-to-pptx/),[แปลง ODP เป็น PPTX](/slides/th/cpp/convert-odp-to-pptx/),[บันทึกงานนำเสนอ](/slides/th/cpp/save-presentation/) |
| PPTX ไปยัง PPT | บันทึกงานนำเสนอ PowerPoint สมัยใหม่เป็นไฟล์ไบนารี PPT เก่าเพื่อความเข้ากันได้กับกระบวนการทำงานรุ่นก่อน | [แปลง PPTX เป็น PPT](/slides/th/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP ไปยัง PDF | สร้างเอกสารคงที่ที่พกพาได้, ค้นหาได้, และเหมาะกับการแชร์, พิมพ์ หรือเก็บถาวร | [แปลง PowerPoint เป็น PDF](/slides/th/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP ไปยัง PDF พร้อมโน๊ต | ส่งออกบันทึกย่อผู้พูดพร้อมเนื้อหาสไลด์ | [แปลง PowerPoint เป็น PDF พร้อมโน๊ต](/slides/th/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP ไปยัง HTML | เผยแพร่งานนำเสนอเป็นหน้า HTML และควบคุมรูปภาพ, ฟอนท์, โน๊ต, และตัวเลือกการจัดวางแบบตอบสนอง | [แปลง PowerPoint เป็น HTML](/slides/th/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP ไปยัง HTML5 | ส่งออกสไลด์เป็น HTML5 สำหรับการดูในเบราว์เซอร์พร้อมการจัดรูปแบบและการโต้ตอบที่คงอยู่ | [ส่งออกงานนำเสนอเป็น HTML5](/slides/th/cpp/export-to-html5/) |
| PPT/PPTX/ODP ไปยัง PNG | เรนเดอร์แต่ละสไลด์เป็นภาพ PNG สำหรับพรีวิว, ภาพย่อย หรือผลลัพธ์บนเว็บ | [แปลง PowerPoint เป็น PNG](/slides/th/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP ไปยัง JPG | เรนเดอร์สไลด์เป็นภาพ JPG และควบคุมขนาดภาพและคุณภาพ | [แปลง PowerPoint เป็น JPG](/slides/th/cpp/convert-powerpoint-to-jpg/) |
| สไลด์ไปยัง SVG | ส่งออกสไลด์แต่ละอันเป็นกราฟิกเวกเตอร์ขยายได้ | [เรนเดอร์สไลด์เป็น SVG](/slides/th/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP ไปยัง XPS | สร้างเอกสาร XPS แบบคงที่ | [แปลง PowerPoint เป็น XPS](/slides/th/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP ไปยัง TIFF | บันทึกงานนำเสนอเป็นไฟล์ TIFF หลายหน้าเพื่อการพิมพ์, สแกน, แฟกซ์ หรือกระบวนการเก็บถาวร | [แปลง PowerPoint เป็น TIFF](/slides/th/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP ไปยัง TIFF พร้อมโน๊ต | บันทึกสไลด์พร้อมบันทึกย่อผู้พูดเป็น TIFF | [แปลง PowerPoint เป็น TIFF พร้อมโน๊ต](/slides/th/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX ไปยัง Word | แปลงสไลด์เป็นเอกสาร Word เมื่อคุณต้องการผลลัพธ์สไตล์เอกสาร | [แปลง PowerPoint เป็น Word](/slides/th/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX ไปยัง Markdown | ดึงเนื้อหางานนำเสนอเป็น Markdown เพื่อใช้ในเอกสารและกระบวนการทำงานแบบข้อความ | [แปลง PowerPoint เป็น Markdown](/slides/th/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX ไปยัง GIF เคลื่อนไหว | สร้าง GIF เคลื่อนไหวจากสไลด์ | [แปลง PowerPoint เป็น Animated GIF](/slides/th/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX ไปยังวิดีโอ | สร้างกระบวนการส่งออกวิดีโอจากสไลด์งานนำเสนอ | [แปลง PowerPoint เป็น Video](/slides/th/cpp/convert-powerpoint-to-video/) |
| งานนำเสนอไปยัง XAML | ส่งออกสไลด์เป็น XAML สำหรับสถานการณ์ UI ของ C++ | [ส่งออกงานนำเสนอเป็น XAML](/slides/th/cpp/export-to-xaml/) |

สำหรับรายการรูปแบบไฟล์เข้าและออกที่กว้างขึ้น ดูที่ [รูปแบบไฟล์ที่สนับสนุน](/slides/th/cpp/supported-file-formats/).

## **การแปลง PowerPoint และ OpenDocument**

Aspose.Slides สำหรับ C++ รองรับการแปลงจากรูปแบบงานนำเสนอที่ใช้กันทั่วไปเช่น PPT, PPTX, PPS, PPSX, POT, POTX และ ODP API การแปลงเดียวกันใช้สำหรับไฟล์ PowerPoint และ OpenDocument ดังนั้นกระบวนการที่บันทึกไฟล์ PPTX เป็น PDF สามารถนำไปใช้กับไฟล์ ODP ได้โดยเปลี่ยนเพียงไฟล์อินพุตเท่านั้น

เมื่อแปลงไฟล์ ODP จำไว้ว่าแอปพลิเคชัน PowerPoint และ OpenDocument ไม่สนับสนุนคุณลักษณะการจัดวางและการจัดรูปแบบทุกอย่างในลักษณะเดียวกัน หากไฟล์ ODP ถูกสร้างใน LibreOffice หรือ OpenOffice Impress ให้ตรวจสอบผลลัพธ์และใช้ตัวเลือกที่อธิบายใน [แปลงงานนำเสนอ OpenDocument](/slides/th/cpp/convert-openoffice-odp/) เมื่อคุณต้องการคำแนะนำเฉพาะรูปแบบ

## **การแปลง PPT เป็น PPTX**

PPT เป็นรูปแบบไบนารีเก่าของ PowerPoint ส่วน PPTX เป็นรูปแบบ Office Open XML สมัยใหม่ Aspose.Slides สำหรับ C++ รองรับการแปลง PPT ไปเป็น PPTX ด้วยความแม่นยำสูงโดยคงโครงสร้างงานนำเสนอที่ซับซ้อน เช่น มาสเตอร์, เลย์เอาต์, สไลด์, ชาร์ต, กลุ่มรูปทรง, ตัวจัดตำแหน่ง, กรอบข้อความ, เนื้อผ้า, และการเติมภาพ

ดูรายละเอียดเพิ่มเติมที่ [แปลง PPT เป็น PPTX](/slides/th/cpp/convert-ppt-to-pptx/).

## **การส่งออกรูปแบบคงที่**

PDF, XPS, และ TIFF มีประโยชน์เมื่อผลลัพธ์ต้องแสดงผลเดียวกันบนทุกอุปกรณ์และไม่ควรแก้ไขเป็นงานนำเสนอ บทความเฉพาะ PDF, XPS, และ TIFF จะอธิบายวิธีควบคุมการปฏิบัติตามมาตรฐาน, สไลด์ที่ซ่อน, โน๊ต, คุณภาพภาพ, การบีบอัด, ฟอร์แมตพิกเซล, และขนาดผลลัพธ์

## **การส่งออก HTML และภาพ**

การส่งออก HTML และ HTML5 มีประโยชน์สำหรับการดูในเบราว์เซอร์, การเผยแพร่บนเว็บ, และการแชร์แบบเบา ๆ การส่งออกภาพมีประโยชน์เมื่อแต่ละสไลด์ต้องกลายเป็นพรีวิว, ภาพย่อย, หรือแอสเซ็ตแบบราสเตอร์ ใช้บทความ PNG, JPG, และ SVG เพื่อรับคำแนะนำการเรนเดอร์เฉพาะรูปแบบ

## **คำถามที่พบบ่อย**

**จำเป็นต้องใช้ Microsoft PowerPoint เพื่อแปลงงานนำเสนอหรือไม่?**

ไม่ใช่ Aspose.Slides สำหรับ C++ เป็นไลบรารีอิสระและไม่ต้องการ Microsoft PowerPoint หรือการทำงานอัตโนมัติของ Office

**ฉันสามารถแปลงงานนำเสนอจำนวนมากเป็นชุดได้หรือไม่?**

ได้ โหลดงานนำเสนอแต่ละไฟล์, บันทึกเป็นรูปแบบที่ต้องการ, แล้วทำลายอ็อบเจ็กต์งานนำเสนอหลังการประมวลผล หากต้องการประมวลผลแบบขนาน ให้ใช้อินสแตนซ์งานนำเสนอแยกกันและปฏิบัติตามคำแนะนำของ [การทำงานหลายเธรด](/slides/th/cpp/multithreading/)

**ฉันสามารถส่งออกเฉพาะสไลด์ที่เลือกได้หรือไม่?**

ได้ วิธีการส่งออกหลายอย่างอนุญาตให้ระบุดัชนีสไลด์หรือเรนเดอร์สไลด์เดี่ยวตามรูปแบบผลลัพธ์ที่ต้องการ ดูบทความเฉพาะสำหรับรูปแบบเป้าหมาย

**ฉันสามารถรวมสไลด์ที่ซ่อนได้เมื่อส่งออกเป็น PDF หรือ XPS หรือไม่?**

ได้ ใช้การตั้งค่าการส่งออกสไลด์ที่ซ่อนได้ที่อธิบายไว้ในบทความ [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/) และ [XPS](/slides/th/cpp/convert-powerpoint-to-xps/)

**ฉันสามารถสร้างผลลัพธ์ PDF/A ได้หรือไม่?**

ได้ มีการตั้งค่าการปฏิบัติตามมาตรฐาน PDF สำหรับการส่งออก PDF ดูรายละเอียดใน [แปลง PowerPoint เป็น PDF](/slides/th/cpp/convert-powerpoint-to-pdf/)

**ฟอนท์จะถูกจัดการอย่างไรระหว่างการแปลง?**

Aspose.Slides สามารถใช้ฟอนท์ที่ฝังไว้, ฟอนท์สำรอง, และการตั้งค่าการทดแทนฟอนท์ได้ ดูที่ [ฟอนท์ที่ฝังไว้](/slides/th/cpp/embedded-font/), [ฟอนท์สำรอง](/slides/th/cpp/fallback-font/), และ [การทดแทนฟอนท์](/slides/th/cpp/font-substitution/)