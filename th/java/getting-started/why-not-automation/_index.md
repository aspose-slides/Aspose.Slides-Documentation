---
title: ทำไมไม่ใช้อัตโนมัติ
type: docs
weight: 50
url: /th/java/why-not-automation/
keywords:
- การทำงานอัตโนมัติ
- Microsoft Office
- การเปรียบเทียบ
- ความปลอดภัย
- ความเสถียร
- ความสามารถขยายตัว
- คุณลักษณะ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบเหตุผลว่าทำไมการทำงานอัตโนมัติของ Office ถึงเสี่ยงต่อเซิร์ฟเวอร์และบริการ รวมถึงดูว่า Aspose.Slides ให้การประมวลผลการนำเสนอสำหรับ PowerPoint และ OpenDocument ที่ปลอดภัยและเร็วกว่าอย่างไร"
---
## **บทนำ**

มีหลายเหตุผลที่ส่วนประกอบของ Aspose เป็นทางเลือกที่ดีกว่าในการทำอัตโนมัติ เหตุผลหลักบางประการได้แก่:

- ความปลอดภัย
- ความเสถียร
- ความสามารถขยายตัว/ความเร็ว
- ราคา
- คุณลักษณะ

ด้านล่างเป็นคำอธิบายที่ละเอียดขึ้นของแต่ละประเด็นสำคัญ

## **คำถามสำคัญ**

มีสองคำถามที่เรามักได้ยินจาก Aspose:

- ผลิตภัณฑ์ของคุณต้องการให้ติดตั้ง Microsoft Office เพื่อทำงานหรือไม่?

คำตอบสั้น ๆ ง่าย ๆ คือ **ไม่มี**.

ส่วนประกอบของ Aspose เป็นอิสระโดยสิ้นเชิงและไม่ได้เชื่อมโยงกับ, ได้รับอนุญาตจาก, ได้รับการสนับสนุนโดย, หรือได้รับการยอมรับใด ๆ จาก Microsoft Corporation

- ทำไมเราต้องใช้ผลิตภัณฑ์ของ Aspose แทน Microsoft Office Automation?

ก่อนอื่น มีหลาย [ประโยชน์ที่คุณจะได้รับเมื่อใช้ Aspose.Slides](/slides/th/java/product-overview/).

ประการที่สอง Microsoft เอง **แนะนำให้หลีกเลี่ยง** การใช้ Office Automation จากโซลูชันซอฟต์แวร์

## **ความปลอดภัย**

ดังต่อไปนี้เป็นคำพูดโดยตรงจากบทความของ Microsoft: 

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."* 


ผลิตภัณฑ์ของ Aspose มีความปลอดภัยสูง ส่วนประกอบของ Aspose ไม่เป็นความเสี่ยงต่อทรัพยากรระบบที่สำคัญ นอกจากนี้เมื่อเอกสารถูกเปิดโดยส่วนประกอบของ Aspose แมคโครจะไม่ทำงานโดยอัตโนมัติ ส่วนประกอบของ Aspose ถูกออกแบบมาเพื่อให้ผู้พัฒนาสร้าง, แก้ไขและบันทึกไฟล์ Office ได้อย่างปลอดภัย ไม่ได้มีความเสี่ยงใด ๆ ที่มาพร้อมกับชุด Microsoft Office

## **ความเสถียร**
ดังต่อไปนี้เป็นคำพูดโดยตรงจากบทความของ Microsoft: 


*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."* 


ส่วนประกอบของ Aspose ได้รับการทดสอบอย่างละเอียดและมีความเสถียรเป็นอย่างมาก ส่วนประกอบของ Aspose ถูกใช้งานโดย [บริษัท](https://about.aspose.com/customers) เช่น **IBM** , **Hilton** , **Reader's Digest** , **Bank of America** และอื่น ๆ อีกมากมาย 

## **ความสามารถขยายตัว/ความเร็ว**
ดังต่อไปนี้เป็นคำพูดโดยตรงจากบทความของ Microsoft: 


*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.* 


ส่วนประกอบของ Aspose มีความสามารถขยายตัวสูงและเร็วเป็นแสงิด ไฟล์ Office ไม่ได้ถูกออกแบบให้ผู้ใช้หลายร้อยหรือหลายพันคนใช้งานพร้อมกัน อย่างไรก็ตามส่วนประกอบของ Aspose ถูกออกแบบมาสำหรับสถานการณ์นั้นโดยเฉพาะ ส่วนประกอบของเราให้ผลลัพธ์ที่แม่นยำไม่ว่าจะทำงานบนเซิร์ฟเวอร์เครื่องเดียว, รองรับแอปพลิเคชันเดียวหรืออยู่บน Web Form ที่ทำงานแบบ load‑balanced เพื่อให้บริการแอปพลิเคชันระดับองค์กร 

## **ราคา**
เมื่อแอปพลิเคชันใช้ Microsoft Office Automation จำเป็นต้องซื้อสำเนา Microsoft Office สำหรับแต่ละเครื่องที่รันแอปพลิเคชันนั้น มีหลายกรณีที่แอปพลิเคชันอาจต้องสร้างหรือแก้ไขไฟล์ Office แต่ไม่ได้ต้องการให้ผู้ใช้มี Microsoft Office Aspose มีไลเซนส์ [Cost Effective](https://purchase.aspose.com/) ที่ไม่มีค่าลิขสิทธิ์ต่อผู้ใช้ ทำให้สามารถปรับใช้ได้ไม่จำกัดจำนวนผู้ใช้โดยไม่ต้องกังวลเรื่องไลเซนส์ 


เมื่อสร้างแอปพลิเคชันแบบเว็บ จำเป็นต้องทราบว่า Microsoft Office Automation ไม่ได้มีการตั้งราคาและไลเซนส์สำหรับโซลูชันฝั่งเซิร์ฟเวอร์ ดังนั้นจึงไม่มีวิธีลิขสิทธิ์ที่เหมาะสมสำหรับการเปิดใช้เว็บแอปที่ใช้ส่วนประกอบของ Microsoft Office Aspose มีโซลูชันที่คุ้มค่าและเหมาะกับแอปพลิเคชันฝั่งเซิร์ฟเวอร์เช่นกัน 

## **คุณลักษณะ**
ส่วนประกอบของ Aspose ให้ทุกอย่างที่จำเป็นสำหรับการจัดการไฟล์ Office และยังมากกว่านั้น พวกมันถูกออกแบบด้วยปรัชญาที่ทำให้ผู้พัฒนาบรรลุผลลัพธ์ที่ดีที่สุดด้วยความพยายามที่น้อยที่สุด ไม่เหมือน Office Automation ส่วนประกอบของ Aspose มีฟังก์ชันที่ทรงพลังและช่วยประหยัดเวลามากมาย ตัวอย่างเช่น [Aspose.Cells](https://products.aspose.com/cells/java/) ให้ผู้พัฒนานำเข้าข้อมูลจาก **DataTable** หรือ **DataView** ไปยังไฟล์ Excel โดยตรง [Aspose.Words](https://products.aspose.com/words/java/) มีฟีเจอร์คล้ายกันที่ช่วยให้ผู้พัฒนาสร้างเอกสาร Word (Mail Merge) ได้ [ทุกส่วนประกอบ](https://products.aspose.com/total/java/) ในตระกูล Aspose มีชุดคุณลักษณะเฉพาะที่ทรงพลังของตนเอง 


ส่วนที่ดีที่สุดของการซื้อส่วนประกอบของ Aspose (หรือชุดส่วนประกอบเช่น [Aspose.Total](https://products.aspose.com/total/java/)) คือการเข้าถึงทีมพัฒนาของเรา ทีมของเราตระหนักว่าหากมีคุณลักษณะที่บริษัทของคุณต้องการ มีโอกาสที่บริษัทอื่น ๆ จะต้องการเช่นกัน แม้ว่าไม่ใช่ทุกคำขอจะสามารถเพิ่มได้ ทีมของเราพยายามเปิดกว้างและยืดหยุ่นเมื่อให้ความช่วยเหลือ ความคิดนี้ทำให้ส่วนประกอบของ Aspose มีความทรงพลังเช่นนี้ หากคุณต้องการคุณลักษณะเพิ่มเติมจากวัตถุ Office Automation โอกาสที่เราจะทำการเพิ่มนั้นค่อนข้างต่ำมาก 

## **สรุป**
{{% alert color="primary" %}} 

แม้ว่าบทความนี้จะครอบคลุมประเด็นสำคัญหลายประการว่าทำไมส่วนประกอบของ Aspose จึงเป็นตัวเลือกที่ดีกว่า Office Automation แต่ยังมีอีกหลาย ๆ จุด อีกทั้งบทความนี้มุ่งเน้นที่ประเด็นสำคัญที่สุดเท่านั้น ส่วนประกอบของ Aspose ทุกตัวมาพร้อมกับรุ่น [Evaluation Version](https://downloads.aspose.com/slides/th/java) ที่ไม่มีความเสี่ยงและไม่มีข้อผูกมัด เราขอแนะนำให้คุณใช้รุ่น Evaluation นี้เพื่อดูว่า Aspose สามารถทำอะไรให้กับแอปพลิเคชันของคุณได้บ้าง 

{{% /alert %}}