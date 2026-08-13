---
title: ทำไมไม่ใช้การทำอัตโนมัติ
type: docs
weight: 50
url: /th/java/why-not-automation/
keywords:
- การทำอัตโนมัติ
- Microsoft Office
- การเปรียบเทียบ
- ความปลอดภัย
- ความเสถียร
- ความสามารถในการขยาย
- คุณลักษณะ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบว่าทำไมการทำอัตโนมัติของ Office จึงเสี่ยงต่อเซิร์ฟเวอร์และบริการ, และดูว่า Aspose.Slides ให้การประมวลผลนำเสนอที่ปลอดภัยและเร็วกว่า สำหรับ PowerPoint และ OpenDocument."
---
## **บทนำ**

มีหลายเหตุผลที่ส่วนประกอบของ Aspose เป็นทางเลือกที่ดีกว่าการทำอัตโนมัติของ Microsoft Office เหตุผลสำคัญบางประการได้แก่:

- ความปลอดภัย
- ความเสถียร
- ความสามารถในการขยาย/ความเร็ว
- ราคา
- ฟีเจอร์

ด้านล่างเป็นคำอธิบายโดยละเอียดของแต่ละจุดสำคัญ

## **คำถามสำคัญ**

มีสองคำถามที่เรามักได้ยินบ่อยที่ Aspose:

- ผลิตภัณฑ์ของคุณต้องการให้ Microsoft Office ถูกติดตั้งไว้ก่อนจึงจะทำงานได้หรือไม่?

คำตอบสั้น ๆ ที่ง่ายคือ **NO**.

ส่วนประกอบของ Aspose ทำงานอย่างอิสระโดยสมบูรณ์และไม่ได้มีความสัมพันธ์กับ, ได้รับอิทธิเสนอโดย, หรือได้รับการอนุมัติจาก Microsoft Corporation หากไรก็ตาม

- ทำไมเราต้องใช้ผลิตภัณฑ์ของ Aspose แทนการใช้ Microsoft Office Automation?

แรกสุด มีหลาย[ประโยชน์ที่คุณได้รับเมื่อใช้ Aspose.Slides](/slides/th/java/product-overview/)

ต่อม่า Microsoft เองได้ **แนะนำอย่างแรงกล้าให้หลีกเลี่ยง** การใช้ Office Automation จากโซลูชันซอฟต์แวร์

## **ความปลอดภัย**

ข้อความต่อไปเป็นการอ้างอิงโดยตรงจากบทความของ Microsoft:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."* 

ผลิตภัณฑ์ของ Aspose มีความปลอดภัยสูง ส่วนประกอบของ Aspose ไม่ก่อให้เกิดความเสี่ยงต่อทรัพยากรระบบที่สำคัญ นอกจากนี้เมื่อไฟล์ถูกเปิดโดยส่วนประกอบของ Aspose แมโครจะไม่ถูกรันโดยอัตโนมัติ ส่วนประกอบของ Aspose ถูกสร้างขึ้นโดยมุ่งหมายให้ผู้พัฒนาสามารถสร้าง, ปรับเปลี่ยนและบันทึกไฟล์ Office ได้อย่างปลอดภัย ความเสี่ยงใด ๆ ที่เกี่ยวข้องกับชุด Microsoft Office ไม่ได้ถูกนำมาผสมอยู่ในส่วนประกอบของ Aspose

## **ความเสถียร**
ข้อความต่อไปเป็นการอ้างอิงโดยตรงจากบทความของ Microsoft:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."* 

ส่วนประกอบของ Aspose ได้รับการทดสอบอย่างละเอียดและมีความเสถียรสูง ส่วนประกอบของ Aspose ถูกใช้โดย[Companies](https://about.aspose.com/customers)เช่น: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** และอีกหลายบริษัท

## **ความสามารถในการขยาย/ความเร็ว**
ข้อความต่อไปเป็นการอ้างอิงโดยตรงจากบทความของ Microsoft:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.* 

ส่วนประกอบของ Aspose มีความสามารถขยายได้สูงและทำงานเร็วเป็นแสง ส่วนนของ Office ไม่ได้ออกแบบมาสำหรับการใช้พร้อมกันโดยผู้ใช้หลายร้อยหรือหลายพันคน อย่างไรก็ตามส่วนประกอบของ Aspose ถูกออกแบบมาเพื่อรองรับสถานการณ์นั้นโดยเฉพาะ ส่วนประกอบของเราสามารถทำงานได้อย่างราบรื่นทั้งบนเซิร์ฟเวอร์เดียวที่ให้บริการแอปพลิเคชันเดียวหรือบนเว็บฟอร์มที่ทำงานแบบโหลดบาลานซ์เพื่อรองรับแอปพลิเคชันระดับองค์กร

## **ราคา**
เมื่อแอปพลิเคชันใช้ Microsoft Office Automation จำเป็นต้องซื้อสำเนา Microsoft Office สำหรับแต่ละเครื่องที่รันแอปพลิเคชันนั้น หลายกรณีที่แอปพลิเคชันต้องสร้างหรือแก้ไขไฟล์ Office แต่ไม่ได้ต้องการให้ผู้ใช้มี Microsoft Office อยู่ด้วย Aspose นำเสนอ[Cost Effective](https://purchase.aspose.com/)และใบอนุญาตการแจกจ่ายแบบ royalty‑free ที่อนุญาตให้ปรับใช้ได้ไม่จำกัดจำนวนผู้ใช้โดยไม่ต้องกังวลเรื่องลิขสิทธิ์

เมื่อสร้างแอปพลิเคชันบนเว็บ สิ่งสำคัญคือต้องทราบว่า Microsoft Office Automation ไม่ได้มีการกำหนดราคาและไม่มีใบอนุญาตสำหรับโซลูชันด้านเซิร์ฟเวอร์; ดังนั้นจึงไม่มีทางเลือกด้านลิขสิทธิ์ที่ดีสำหรับการปรับใช้เว็บแอปที่ใช้ส่วนประกอบของ Microsoft Office Aspose นำเสนอ​โซลูชันที่คุ้มค่าสำหรับแอปพลิเคชันบนเซิร์ฟเวอร์เช่นกัน

## **ฟีเจอร์**
ส่วนประกอบของ Aspose มีทุกสิ่งที่จำเป็นสำหรับการจัดการไฟล์ Office และยังมีฟีเจอร์มากกว่านั้น พวกเขาถูกออกแบบโดยมีปรัชญาว่าให้ผู้พัฒนาบรรลุผลลัพธ์ที่ดีที่สุดด้วยการทำงานขั้นต่ำ แตกต่างจาก Office Automation ส่วนประกอบของ Aspose มีฟังก์ชันที่ทรงพลังและช่วยประหยัดเวลา ตัวอย่างเช่น [Aspose.Cells](https://products.aspose.com/cells/java/) ให้ผู้พัฒนานำเข้าข้อมูลจาก **DataTable** หรือ **DataView** โดยตรงสู่ไฟล์ Excel [Aspose.Words](https://products.aspose.com/words/java/) มีฟีเจอร์คล้ายกันที่ช่วยให้ผู้พัฒนาสร้างเอกสาร Word (เช่น Mail Merge) ได้ [Every Component](https://products.aspose.com/total/java/) ในครอบครัว Aspose ต่างล้วนมีชุดฟีเจอร์ที่เป็นเอกลักษณ์และทรงพลังของตนเอง

ส่วนที่ดีที่สุดของการซื้อส่วนประกอบของ Aspose (หรือชุดส่วนประกอบเช่น [Aspose.Total](https://products.aspose.com/total/java/)) คือการเข้าถึงทีมพัฒนาของเรา ทีมของเราตระหนักว่าถ้ามีฟีเจอร์ที่บริษัทของคุณต้องการ มีความเป็นไปได้ว่า บริษัทอื่น ๆ จะต้องการเช่นกัน แม้ว่าจะไม่สามารถเพิ่มทุกคำขอฟีเจอร์ได้ ทีมของเราพยายามเปิดใจและยืดหยุ่นอย่างมากเมื่อตอบสนองการช่วยเหลือ นั่นคือแนวคิดที่ทำให้ส่วนประกอบของ Aspose มีความทรงพลังเช่นนี้ หากมีฟีเจอร์เพิ่มเติมที่คุณต้องการจากวัตถุ Office Automation โอกาสที่มันจะถูกเพิ่มเข้าไปนั้นค่อนข้างต่ำมาก

## **สรุป**
{{% alert color="info" %}} 

แม้ว่าบทความนี้จะครอบคลุมจุดหลักหลายประการว่าทำไมส่วนประกอบของ Aspose จึงเป็นตัวเลือกที่ดีกว่าการใช้ Office Automation ยังมีอีกมากมาย บทความนี้มุ่งเน้นเพียงจุดสำคัญที่สุดเท่านั้น ส่วนประกอบต่าง ๆ ของ Aspose ทั้งหมดให้การทดลองใช้แบบไม่มีความเสี่ยงและไม่มีภาระผูกพัน[Evaluation Version](https://downloads.aspose.com/slides/th/java)  เราแนะนำให้คุณใช้ประโยชน์จากการทดลองนี้เพื่อดูว่า Aspose สามารถทำอะไรให้กับแอปพลิเคชันของคุณได้บ้าง 

{{% /alert %}}