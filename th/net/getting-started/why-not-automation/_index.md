---
title: ทำไมไม่ใช้อัตโนมัติ
type: docs
weight: 40
url: /th/net/why-not-automation/
keywords:
- การอัตโนมัติ
- Microsoft Office
- การเปรียบเทียบ
- ความปลอดภัย
- ความเสถียร
- ความสามารถในการขยายตัว
- คุณลักษณะ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบว่าการอัตโนมัติของ Office มีความเสี่ยงต่อเซิร์ฟเวอร์และบริการอย่างไร และดูว่า Aspose.Slides นำเสนอการประมวลผลงานนำเสนอที่ปลอดภัยและเร็วกว่า สำหรับ PowerPoint และ OpenDocument."
---
## **บทนำ**

มีหลายเหตุผลที่ส่วนประกอบของ Aspose เป็นทางเลือกที่ดีกว่าในการทำอัตโนมัติ เหตุผลสำคัญบางประการได้แก่:

- ความปลอดภัย
- ความเสถียร
- ความสามารถขยายตัว/ความเร็ว
- ราคา
- คุณลักษณะ

ต่อไปนี้เป็นคำอธิบายโดยละเอียดของแต่ละประเด็นสำคัญ

## **คำถามสำคัญ**

เรามักได้ยินคำถามสองข้อที่ Aspose:

- ผลิตภัณฑ์ของคุณต้องการให้ Microsoft Office ติดตั้งไว้เพื่อใช้งานหรือไม่?

คำตอบสั้น ๆ และง่าย ๆ คือ **ไม่**.

ส่วนประกอบของ Aspose ทำงานอย่างอิสระโดยสมบูรณ์และไม่ได้มีความเกี่ยวข้อง ถูกอนุญาต สนับสนุน หรือได้รับการอนุมัติจาก Microsoft Corporation ใด ๆ

- ทำไมเราควรใช้ผลิตภัณฑ์ของ Aspose แทนการทำอัตโนมัติด้วย Microsoft Office?

First, there are many [ประโยชน์หลายอย่างที่คุณจะได้รับเมื่อใช้ Aspose.Slides](/slides/th/net/product-overview/).

Second, Microsoft เองแนะนำอย่างหนักว่า **ไม่ควร** ใช้อัตโนมัติของ Office จากโซลูชันซอฟต์แวร์

## **ความปลอดภัย**
ต่อไปนี้คือคำพูดโดยตรงจากบทความของ Microsoft:

> Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users.

Aspose products are very **secure**. Aspose components run in the same user context as all ASP.NET applications (under the ASPNET user). Therefore, Aspose components do **not** pose a security risk. They also do not consume critical system resources. Furthermore, when an Aspose component opens a document, macros do not get to run automatically. Aspose components were built to allow developers to create, manipulate, and save Office files.

{{% alert color="primary" %}} 

ไม่มีความเสี่ยงใด ๆ ที่เกี่ยวข้องกับชุด Microsoft Office ที่นำไปใช้กับส่วนประกอบของ Aspose

{{% /alert %}} 

## **ความเสถียร**
ต่อไปนี้คือคำพูดโดยตรงจากบทความของ Microsoft:

> Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed.

Since Aspose components are packaged into a single DLL, its users never need to install additional parts or pieces for them to function. Aspose components are only utilized by .NET applications and there is no portion of the component code designed to wait for a human response.

{{% alert color="primary" %}} 

ส่วนประกอบของ Aspose ได้รับการทดสอบอย่างละเอียดและพิสูจน์ว่า มีความเสถียรสูง Aspose components are used by [บริษัท](http://www.aspose.com/Corporate/Aspose/Customerlist.html) such as **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, and many other leading organizations in several industries and fields. 

{{% /alert %}} 

## **ความสามารถขยายตัว/ความเร็ว**
ต่อไปนี้คือคำพูดโดยตรงจากบทความของ Microsoft:

> Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Aspose components are incredibly scalable and lightning fast. Office applications were not designed to be simultaneously used by 100s or 1000s of users, but Aspose components are designed for that precisely. Our components are a true .NET solution.

{{% alert color="primary" %}} 

ประสิทธิภาพของส่วนประกอบ Aspose flawless บนเซิร์ฟเวอร์เดียว (ขับเคลื่อนแอปพลิเคชันเดียว) หรือบนเว็บฟอร์มที่ทำงานแบบโหลดบาลานซ์ (ขับเคลื่อนแอปพลิเคชันระดับองค์กร)

{{% /alert %}} 

## **ราคา**
When an application utilizes Microsoft Office Automation, a copy of Microsoft Office has to be purchased for every machine that runs the app. There are many instances an application may need to create or manipulate an office file, but the process does not require Microsoft Office. 

{{% alert color="primary" %}} 

Aspose provides a very [คุ้มค่า](https://purchase.aspose.com/) and royalty-free redistribution license that allows deployment to an unlimited number of users with no licensing worries. 

{{% /alert %}} 

When creating web-based applications, it is important to remember that Microsoft Office Automation components are neither priced nor licensed for server-side solutions. Therefore, there is no good licensing solution for the deployment of web applications that utilize Microsoft Office components. Aspose, on the other hand, provides a very [คุ้มค่า](https://purchase.aspose.com/) solution for server-based applications as well.

## **คุณลักษณะ**
Aspose components provide everything needed for managing Office files and a lot more. We designed them based on our philosophy of helping developers to accomplish the greatest results possible with the least amount of effort. 

{{% alert color="primary" %}} 

Unlike Office Automation, Aspose components provide many powerful and time-saving functions. 

{{% /alert %}} 

For instance, [Aspose.Cells](https://products.aspose.com/cells/net/) gives developers the ability to import data from a **DataTable** or **DataView** directly into an Excel file. [Aspose.Words](https://products.aspose.com/words/net/) provides a similar feature that allows developers to populate a Word (that is, Mail Merge) document directly from any .NET data object. [แต่ละส่วนประกอบ](https://products.aspose.com/total/net/) in the Aspose family offers their own set of unique and powerful features. 

The best part of purchasing an Aspose component is getting access to our development teams. For example, if you use Office Automation objects and need certain features, the chances of you getting those features to be added are very, very low. However, things are different with Aspose components. 

{{% alert color="primary" %}} 

Our development teams understand that if there is a feature that your company needs, there is a good chance other firms need the same feature. While we know we cannot implement every requested feature, we strive to add as many features as possible based on feedback from our customers. 

{{% /alert %}} 

Our teams are always open-minded and flexible when providing assistance—and this is the reason Aspose components have grown to become as powerful as they are now. 

## **สรุป**
{{% alert color="primary" %}} 

While this article covered some of the key points why Aspose components are a better choice than Office Automation, you have to understand that there are many, many more benefits. We only went through some of the major advantages. 

Moreover, all Aspose products and components offer a risk-free, no-obligation [Evaluation Version](https://downloads.aspose.com/slides/th/net). We encourage you to take advantage of the evaluation to see what Aspose can do for your applications or business. 

{{% /alert %}}