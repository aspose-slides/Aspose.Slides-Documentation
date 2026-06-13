---
title: การป้องกันรหัสผ่านสำหรับการนำเสนอที่ส่งออก
type: docs
weight: 90
url: /th/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

การป้องกันรหัสผ่านสำหรับการนำเสนอช่วยป้องกันการใช้งานและการเข้าถึงโดยไม่ได้รับอนุญาต การป้องกันด้วยรหัสผ่านเป็นประโยชน์หากคุณกำลังสร้างรายงานที่มีข้อมูลที่ละเอียดอ่อนหรือรายละเอียดที่ควรให้เฉพาะบางคนในองค์กรของคุณเท่านั้นเห็น.

บทความนี้แสดงวิธีการอัปเดตสภาพแวดล้อม Reporting Services หรือ Visual Studio ของคุณเพื่อให้คุณสามารถบันทึกการนำเสนอพร้อมการป้องกันด้วยรหัสผ่านได้.

{{% /alert %}} 
## **การเพิ่มการป้องกันด้วยรหัสผ่านสำหรับการนำเสนอที่ส่งออกในสภาพแวดล้อม Reporting Services**
เพื่อใช้การเปลี่ยนแปลงเหล่านี้ คุณต้องแก้ไขไฟล์ในไดเรกทอรีที่ติดตั้ง Microsoft SQL Server Reporting Services
### **ขั้นตอนที่ 1. ค้นหาไดเรกทอรีการติดตั้ง Reporting Server.**
ไดเรกทอรีรากของ Microsoft SQL Server ปกติจะอยู่ที่ C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

สำหรับระบบ 64 บิต ตัวอย่าง x86 ของ SQL Server จะติดตั้งที่ C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 และ 2008: อาจมีหลายอินสแตนซ์ของ Microsoft SQL Server ที่กำหนดค่าไว้บนเครื่อง แต่ละอินสแตนซ์จะอยู่ในซับไดเรกทอรี MSSQL.x ที่แตกต่างกัน เช่น MSSQL.1, MSSQL.2 เป็นต้น ให้ค้นหาไดเรกทอรี C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer ที่ถูกต้องก่อนดำเนินการขั้นตอนต่อไป

ทุกเส้นทางที่ใช้ด้านล่างนี้อ้างอิงถึงไดเรกทอรีการติดตั้ง Microsoft SQL Server Reporting Services เป็น <Instance>.
### **ขั้นตอนที่ 2. เพิ่มโค้ดสำหรับการเพิ่มรหัสผ่านให้กับการนำเสนอที่ส่งออก**
แทนที่ส่วนขยายการเรนเดอร์ Aspose.Slides for Reporting Services ที่มีอยู่ในไฟล์ **rsreportserver.config** ให้เปิดไฟล์ C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config

ค้นหาตัวเลือกการเรนเดอร์ที่ระบุไว้ต่อไปนี้และแทนที่ด้วยโค้ดในส่วนที่ตามมาภายหลัง
#### **ค้นหาตัวเลือกการเรนเดอร์ Aspose.Slides for Reporting Service**
**<Render>**

``` xml

   ...

  <!--เริ่มต้นที่นี่.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--จบที่นี่.-->


</Render>



```
#### **โค้ดทดแทน**
**<Render>**

``` xml

   ...

  <!--เริ่มต้นที่นี่.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--จบที่นี่.-->


</Render>



```
### **การเพิ่มการป้องกันด้วยรหัสผ่านสำหรับการนำเสนอที่ส่งออกใน Visual Studio**
เพื่อใช้การเปลี่ยนแปลงเหล่านี้ คุณต้องแก้ไขไฟล์ที่ติดตั้ง Microsoft Visual Studio Report Designer
### **ขั้นตอนที่ 1. เปิดไดเรกทอรี Visual Studio.**
- เพื่อติดตั้งกับ Visual Studio 2005 Report Designer ให้เปิดไดเรกทอรี C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies
- เพื่อติดตั้งกับ Visual Studio 2008 Report Designer ให้เปิดไดเรกทอรี C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies
### **ขั้นตอนที่ 2. เพิ่มโค้ดสำหรับการเพิ่มรหัสผ่านให้กับการนำเสนอที่ส่งออก.**
แทนที่ส่วนขยายการเรนเดอร์ Aspose.Slides for Reporting Services ที่มีอยู่ในไฟล์ **rsreportserver.config** ให้เปิดไฟล์ C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config (โดยที่ **<Version>** คือ “8” สำหรับ Visual Studio 2005 หรือ “9.0” สำหรับ Visual Studio 2008) แล้วเพิ่มบรรทัดเหล่านี้ในองค์ประกอบ **<Render>** จากนั้นแทนที่ด้วยโค้ดในส่วนต่อไปของโค้ด
#### **ค้นหาตัวเลือกการเรนเดอร์ Aspose.Slides for Reporting Service**
**<Render>**

``` xml

   ...

  <!--เริ่มต้นที่นี่.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--จบที่นี่.-->


</Render>



```
#### **โค้ดทดแทน**
**<Render>**

``` xml

   ...

  <!--เริ่มต้นที่นี่.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 			


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 			


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 			


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 			


	<Password>111</Password>

  </Configuration>			


 </Extension>

  <!--จบที่นี่.-->


</Render>



```