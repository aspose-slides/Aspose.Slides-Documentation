---
title: ทำไมไม่ใช้การทำอัตโนมัติ
type: docs
weight: 50
url: /th/cpp/why-not-automation/
keywords:
- การทำอัตโนมัติ
- Microsoft Office
- การเปรียบเทียบ
- ความปลอดภัย
- ความเสถียร
- ความสามารถขยาย
- คุณลักษณะ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบเหตุผลที่การทำอัตโนมัติของ Office มีความเสี่ยงต่อเซิร์ฟเวอร์และบริการ, และดูว่า Aspose.Slides ให้การประมวลผลงานนำเสนอที่ปลอดภัยและเร็วขึ้นสำหรับ PowerPoint และ OpenDocument อย่างไร"
---
## **คำนำ**

มีหลายเหตุผลที่ทำให้ส่วนประกอบของ Aspose เป็นทางเลือกที่ดีกว่าในการทำอัตโนมัติ เหตุผลสำคัญบางประการ ได้แก่

- ความปลอดภัย
- ความเสถียร
- ความสามารถขยาย/ความเร็ว
- ราคา
- คุณลักษณะ

ด้านล่างเป็นคำอธิบายโดยละเอียดของแต่ละประเด็นสำคัญ

## **คำถามสำคัญ**
- ทำไมส่วนประกอบของ Aspose จึงเป็นตัวเลือกที่ดีกว่า Microsoft Office Automation อย่างมาก?

มีสองคำถามที่เรามักได้ยินบ่อยที่สุดที่ Aspose :

- ผลิตภัณฑ์ของคุณต้องการให้ Microsoft Office ถูกติดตั้งไว้เพื่อให้ทำงานได้หรือไม่?

คำตอบสั้นๆ ที่ง่ายคือ **ไม่** Aspose และส่วนประกอบของ Aspose ทำงานอย่างอิสระโดยสิ้นเชิงและไม่ได้เชื่อมโยงกับ Microsoft Corporation ไม่ได้รับการอนุมัติ หรือสนับสนุนใดๆ

- ทำไมเราถึงควรใช้ผลิตภัณฑ์ของ Aspose แทนการใช้ Microsoft Office Automation?

คำตอบสั้นที่สุดที่เราสามารถให้ได้คือ มีหลายเหตุผล โดยเหตุผลหลักคือ *Microsoft เองแนะนำอย่างยิ่งให้หลีกเลี่ยง Office Automation จากโซลูชันซอฟต์แวร์: [Microsoft Article*

## **ความปลอดภัย**
ข้อความต่อไปนี้เป็นคำอ้างอิงโดยตรงจาก Microsoft Article ที่อ้างถึงข้างต้น :

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

ผลิตภัณฑ์ของ Aspose มีความปลอดภัยสูง ดังนั้นส่วนประกอบของ Aspose จึงไม่ก่อให้เกิดความเสี่ยงต่อทรัพยากรระบบสำคัญ อีกทั้งเมื่อเอกสารถูกเปิดโดยส่วนประกอบของ Aspose แมโครจะไม่ถูกรันโดยอัตโนมัติ ส่วนประกอบของ Aspose ถูกออกแบบมาเพื่อให้ผู้พัฒนาสร้าง ปรับเปลี่ยน และบันทึกไฟล์ Office ได้อย่างปลอดภัย โดยไม่มีความเสี่ยงที่เกี่ยวข้องกับชุด Microsoft Office

## **ความเสถียร**
ข้อความต่อไปนี้เป็นคำอ้างอิงโดยตรงจาก Microsoft Article ที่อ้างถึงข้างต้น :

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of \"install on first use\", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

เนื่องจากส่วนประกอบของ Aspose ถูกบรรจุเป็นไฟล์ DLL เดียว จึงไม่มีความจำเป็นต้องติดตั้งส่วนเพิ่มเติมใดๆ Aspose ใช้ได้เฉพาะกับแอปพลิเคชัน C++ เท่านั้นและไม่มีโค้ดส่วนใดที่รอการตอบสนองจากมนุษย์ ส่วนประกอบของ Aspose ผ่านการทดสอบอย่างละเอียดและมีความเสถียรสูง ส่วนประกอบของ Aspose ถูกใช้งานโดย [Companies](https://about.aspose.com/customers) เช่น **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** และหลายองค์กรอื่นอีกมาก

## **ความสามารถขยาย/ความเร็ว**
ข้อความต่อไปนี้เป็นคำอ้างอิงโดยตรงจาก Microsoft Article ที่อ้างถึงข้างต้น :

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

ส่วนประกอบของ Aspose มีความสามารถขยายสูงและทำงานเร็วมาก แอปพลิเคชัน Office ไม่ได้ถูกออกแบบให้ใช้พร้อมกันโดยผู้ใช้หลายร้อยหรือหลายพันคน อย่างไรก็ตาม Aspose ถูกออกแบบมาสำหรับสถานการณ์เช่นนี้โดยเฉพาะ ส่วนประกอบของเราคือโซลูชัน C++ แท้จริงและทำงานได้อย่างราบรื่นไม่ว่าจะบนเซิร์ฟเวอร์เดียวที่ให้บริการแอปพลิเคชันเดียวหรือบน Web Form ที่ทำงานแบบโหลดบาลานซ์เพื่อสนับสนุนแอปพลิเคชันระดับองค์กร

## **ราคา**
เมื่อแอปพลิเคชันใช้ Microsoft Office Automation จำเป็นต้องซื้อสำเนา Microsoft Office สำหรับแต่ละเครื่องที่รันแอปพลิเคชันนั้น มีหลายกรณีที่แอปต้องสร้างหรือแก้ไขไฟล์ Office แต่ไม่จำเป็นต้องให้ผู้ใช้มี Microsoft Office Aspose มีลิขสิทธิ์ **Cost Effective** (https://purchase.aspose.com/) ที่ไม่มีค่า royalty ซึ่งช่วยให้สามารถปรับใช้ได้ไม่จำกัดจำนวนผู้ใช้โดยไม่มีความกังวลเรื่องลิขสิทธิ์ เมื่อสร้างแอปบนเว็บ ควรทราบว่า Microsoft Office Automation ไม่ได้มีการกำหนดราคา หรือให้สิทธิ์ในการใช้งานบนเซิร์ฟเวอร์ ดังนั้นจึงไม่มีวิธีลิขสิทธิ์ที่เหมาะสมสำหรับการปรับใช้แอปเว็บที่ใช้ส่วนประกอบของ Microsoft Office Aspose มีโซลูชัน **Cost Effective** (https://purchase.aspose.com/) สำหรับแอปพลิเคชันบนเซิร์ฟเวอร์เช่นกัน

## **คุณลักษณะ**
ส่วนประกอบของ Aspose มีทุกอย่างที่จำเป็นสำหรับการจัดการไฟล์ Office และมากกว่านั้น พวกมันถูกออกแบบด้วยปรัชญาที่ทำให้ผู้พัฒนาสามารถบรรลุผลลัพธ์ที่ดีที่สุดด้วยความพยายามน้อยที่สุด แตกต่างจาก Office Automation ส่วนประกอบของ Aspose มีฟังก์ชันอันทรงพลังและประหยัดเวลามากมาย ตัวอย่างเช่น [Aspose.Cells](https://products.aspose.com/cells/cpp/) ให้ผู้พัฒนานำเข้าข้อมูลจาก **DataTable** หรือ **DataView** ไปยังไฟล์ Excel ได้โดยตรง [Aspose.Words](https://products.aspose.com/words/net/) มีคุณลักษณะคล้ายกันที่ช่วยให้ผู้พัฒนาสร้างเอกสาร Word (Mail Merge) จากอ็อบเจ็กต์ข้อมูล C++ ใด ๆ ก็ได้ [Every Component](https://products.aspose.com/total/cpp/) ในตระกูล Aspose มีคุณลักษณะเฉพาะและทรงพลังของตนเอง ส่วนที่ดีที่สุดของการซื้อส่วนประกอบของ Aspose คือการเข้าถึงทีมพัฒนาของเรา ทีมของเราตระหนักว่าถ้ามีคุณลักษณะที่บริษัทของคุณต้องการ โอกาสที่บริษัทอื่น ๆ จะต้องการก็สูงมาก แม้ว่าจะไม่สามารถเพิ่มคำขอคุณลักษณะทุกอย่างได้ ทีมของเราพยายามเปิดกว้างและยืดหยุ่นในการให้ความช่วยเหลือ ทัศนคตินี้ทำให้ส่วนประกอบของ Aspose กลายเป็นเครื่องมือที่ทรงพลัง หากคุณต้องการคุณลักษณะเพิ่มเติมจากวัตถุ Office Automation โอกาสที่จะได้เพิ่มเข้ามาจะต่ำมาก

## **สรุป**
{{% alert color="primary" %}} 

แม้บทความนี้จะครอบคลุมหลายประเด็นสำคัญที่ทำให้ส่วนประกอบของ Aspose เป็นตัวเลือกที่ดีกว่า Office Automation ยังมีอีกหลายประเด็นที่ไม่ได้กล่าวถึง บทความนี้เน้นเฉพาะประเด็นหลักเท่านั้น ทุกส่วนประกอบของ Aspose มีเวอร์ชันประเมินผล **ไม่มีความเสี่ยง** และ **ไม่มีข้อผูกมัด** [Evaluation Version](https://downloads.aspose.com/slides/th/cpp) เราขอแนะนำให้คุณลองใช้ [Evaluation](https://downloads.aspose.com/slides/th/cpp) เพื่อตรวจสอบว่าผลิตภัณฑ์ของ Aspose สามารถทำอะไรให้แอปพลิเคชันของคุณได้บ้าง
{{% /alert %}}