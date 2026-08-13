---
title: ทำไมไม่ควรทำอัตโนมัติ
type: docs
weight: 50
url: /th/cpp/why-not-automation/
keywords:
- การทำอัตโนมัติ
- Microsoft Office
- การเปรียบเทียบ
- ความปลอดภัย
- ความเสถียร
- การขยายขนาด
- คุณสมบัติ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบว่าทำไมการทำอัตโนมัติของ Office มีความเสี่ยงต่อเซิร์ฟเวอร์และบริการ และดูว่า Aspose.Slides ให้การประมวลผลงานนำเสนอที่ปลอดภัยและเร็วกว่าสำหรับ PowerPoint และ OpenDocument."
---
## **บทนำ**

มีหลายเหตุผลที่ส่วนประกอบของ Aspose เป็นทางเลือกที่ดีกว่าการทำอัตโนมัติของ Office เหนือกว่าเหตุผลสำคัญบางประการได้แก่:

- ความปลอดภัย
- ความเสถียร
- ความสามารถในการขยาย/ความเร็ว
- ราคา
- คุณสมบัติ

ด้านล่างนี้เป็นการอธิบายโดยละเอียดของแต่ละประเด็นสำคัญ

## **คำถามสำคัญ**
- ทำไมส่วนประกอบของ Aspose จึงเป็นตัวเลือกที่ดีกว่า Microsoft Office Automation อย่างมาก?

เรามักจะได้รับคำถามสองข้อที่นี่ที่ Aspose :

- ผลิตภัณฑ์ของคุณต้องการให้ Microsoft Office ติดตั้งอยู่บนเครื่องเพื่อให้ทำงานได้หรือไม่?

คำตอบสั้น ๆ คือ **ไม่**  Aspose และส่วนประกอบของ Aspose ทำงานได้อย่างอิสระและไม่ได้เชื่อมโยงกับ Microsoft Corporation ไม่ได้รับอนุญาต หรือได้รับการสนับสนุนใด ๆ

- ทำไมเราควรใช้ผลิตภัณฑ์ของ Aspose แทนที่จะใช้ Microsoft Office Automation?

คำตอบสั้นที่สุดที่เราสามารถให้ได้คือ มีหลายเหตุผลโดยที่สำคัญที่สุดคือ *Microsoft เองแนะนำอย่างหนักว่าหลีกเลี่ยงการใช้ Office Automation จากโซลูชันซอฟต์แวร์: [Microsoft Article](https://learn.microsoft.com/office/troubleshoot/office-developer/office-automation-cannot-be-used-in-server-side-applications)*

## **ความปลอดภัย**
ข้อความต่อไปเป็นคำพูดโดยตรงจาก  Microsoft Article ที่อ้างอิงข้างต้น :

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

ผลิตภัณฑ์ของ Aspose มีความปลอดภัยสูง ดังนั้นส่วนประกอบของ Aspose จึงไม่เป็นความเสี่ยงต่อทรัพยากรระบบที่สำคัญ นอกจากนี้เมื่อไฟล์ถูกเปิดโดยส่วนประกอบของ Aspose แมโครจะไม่ได้ถูกรันโดยอัตโนมัติ ส่วนประกอบของ Aspose ถูกสร้างขึ้นเพื่อให้ผู้พัฒนาสร้าง ปรับแต่ง และบันทึกไฟล์ Office ได้โดยไม่มีความเสี่ยงที่มาจากชุด Microsoft Office

## **ความเสถียร**
ข้อความต่อไปเป็นคำพูดโดยตรงจาก  Microsoft Article ที่อ้างอิงข้างต้น :

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

เนื่องจากส่วนประกอบของ Aspose ถูกบรรจุไว้ในไฟล์ DLL เพียงไฟล์เดียว จึงไม่มีการต้องติดตั้งส่วนเพิ่มเติมใด ๆ อีกทั้งส่วนประกอบของ Aspose ทำงานได้เฉพาะกับแอปพลิเคชัน C++ และไม่มีโค้ดส่วนใดที่ต้องรอการตอบรับจากมนุษย์ ส่วนประกอบของ Aspose ผ่านการทดสอบอย่างเข้มข้นและมีเสถียรภาพสูง ส่วนประกอบของ Aspose ถูกใช้โดย [Companies](https://about.aspose.com/customers) เช่น **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** และอีกหลายองค์กร

## **ความสามารถในการขยาย/ความเร็ว**
ข้อความต่อไปเป็นคำพูดโดยตรงจาก  Microsoft Article ที่อ้างอิงข้างต้น :

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

ส่วนประกอบของ Aspose สามารถขยายได้สูงและทำงานเร็วมาก Office Application ไม่ได้ออกแบบมาให้หลายร้อยหรือหลายพันผู้ใช้ใช้งานพร้อมกัน ในขณะที่ส่วนประกอบของ Aspose ถูกออกแบบมาเพื่อรองรับสถานการณ์เช่นนั้น โดยเป็นโซลูชัน C++ แท้จริงและทำงานได้อย่างไม่มีข้อบกพร่อง ไม่ว่าจะบนเซิร์ฟเวอร์เดียวนั้นหรือบน Web Form ที่ทำการโหลดบาลานซ์เพื่อสนับสนุนแอปพลิเคชันระดับองค์กร

## **ราคา**
เมื่อแอปพลิเคชันใช้ Microsoft Office Automation จำเป็นต้องซื้อลิขสิทธิ์ Microsoft Office แยกตามเครื่องที่รันแอปพลิเคชันนั้น มีหลายกรณีที่แอปต้องสร้างหรือปรับแต่งไฟล์ Office โดยไม่จำเป็นต้องให้ผู้ใช้มี Microsoft Office เอง Aspose มีลิขสิทธิ์ [Cost Effective](https://purchase.aspose.com/) ที่ไม่มีค่า royalties ซึ่งอนุญาตให้ติดตั้งได้ไม่จำกัดจำนวนผู้ใช้โดยไม่มีปัญหาเรื่องลิขสิทธิ์ เมื่อพัฒนาแอปเว็บ ควรทราบว่าคอมโพเนนต์การทำ Automation ของ Microsoft Office ไม่ได้ถูกกำหนดราคาและไม่มีใบอนุญาตสำหรับการใช้งานบนเซิร์ฟเวอร์ ดังนั้นจึงไม่มีโซลูชันลิขสิทธิ์ที่เหมาะสมสำหรับการเปิดให้บริการเว็บที่ใช้คอมโพเนนต์ Microsoft Office Aspose มีโซลูชัน [Cost Effective](https://purchase.aspose.com/) สำหรับแอปพลิเคชันฝั่งเซิร์ฟเวอร์เช่นกัน

## **คุณสมบัติ**
ส่วนประกอบของ Aspose มีทุกสิ่งที่ต้องการสำหรับการจัดการไฟล์ Office และยังมีมากกว่านั้น พวกเขาถูกออกแบบโดยคำนึงถึงการให้ผู้พัฒนาบรรลุผลลัพธ์สูงสุดด้วยความพยายามน้อยที่สุด ไม่เหมือนกับ Office Automation ที่ส่วนประกอบของ Aspose มีฟังก์ชันที่ทรงพลังและประหยัดเวลา ตัวอย่างเช่น [Aspose.Cells](https://products.aspose.com/cells/cpp/) ให้ผู้พัฒนานำเข้าข้อมูลจาก **DataTable** หรือ **DataView** โดยตรงสู่ไฟล์ Excel [Aspose.Words](https://products.aspose.com/words/net/) มีฟีเจอร์คล้ายกันที่ให้ผู้พัฒนาผสานข้อมูลลงในเอกสาร Word (Mail Merge) จากอ็อบเจกต์ C++ ใด ๆ  [Every Component](https://products.aspose.com/total/cpp/) ในตระกูล Aspose มีชุดฟีเจอร์ที่เป็นเอกลักษณ์และทรงพลังที่สุด ส่วนที่ดีที่สุดของการซื้อส่วนประกอบ Aspose คือการเข้าถึงทีมพัฒนา ทีมของเราเข้าใจว่าถ้ามีฟีเจอร์ที่บริษัทของคุณต้องการ โอกาสสูงที่บริษัทอื่น ๆ จะต้องการเช่นกัน แม้ว่าเราอาจไม่สามารถเพิ่มทุกคำขอได้ ทีมของเราพยายามเปิดกว้างและยืดหยุ่นเมื่อต้องให้ความช่วยเหลือ นั่นคือแนวคิดที่ทำให้ส่วนประกอบของ Aspose แข็งแรงและทรงพลัง หากคุณต้องการฟีเจอร์เพิ่มเติมจากวัตถุ Office Automation โอกาสที่จะได้รับการเพิ่มเข้ามาจะต่ำมาก

## **บทสรุป**
{{% alert color="info" %}} 

แม้บทความนี้จะครอบคลุมหลายประเด็นสำคัญว่าทำไมส่วนประกอบของ Aspose จึงเป็นตัวเลือกที่ดีกว่า Office Automation ยังมีอีกมากมาย บทความนี้โฟกัสที่จุดสำคัญที่สุดเท่านั้น ทุกส่วนประกอบของ Aspose ให้ทดลองใช้ฟรีแบบไร้ความเสี่ยงและไม่มีข้อผูกมัด [Evaluation Version](https://downloads.aspose.com/slides/th/cpp) เราขอแนะนำให้คุณใช้โอกาสนี้เพื่อดูว่ามีอะไรบ้างที่ Aspose ทำให้แอปของคุณดีขึ้น
{{% /alert %}}