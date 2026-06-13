---
title: ติดตั้งด้วยตนเอง
type: docs
weight: 30
url: /th/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

ทำตามขั้นตอนต่อไปนี้เฉพาะเมื่อต้องการติดตั้ง Aspose.Slides for Reporting Services ด้วยตนเอง ในกรณีนี้คุณได้ดาวน์โหลดแพคเกจ ZIP ที่มีไฟล์ assembly อยู่ 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** จำเป็นต้องติดตั้ง **.NET Framework 3.5** บนเครื่องโฮสต์ 

{{% /alert %}}

### **การติดตั้งด้วยตนเอง**
คำแนะนำเหล่านี้แสดงวิธีคัดลอกและแก้ไขไฟล์ในไดเรกทอรีที่ติดตั้ง Microsoft SQL Server Reporting Services:

1. ค้นหาไดเรกทอรีการติดตั้ง Report Server  
   ไดเรกทอรีรากของ Microsoft SQL Server ปกติจะอยู่ที่: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 and 2008**: อาจมีหลายอินสแตนซ์ของ Microsoft SQL Server ที่กำหนดค่าบนเครื่องและอาจอยู่ในไดเรกทอรีย่อย MSSQL.x ต่าง ๆ เช่น MSSQL.1, MSSQL.2 เป็นต้น คุณต้องค้นหาไดเรกทอรี ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** ที่ถูกต้องก่อนดำเนินการต่อ  
   
   {{% /alert %}} All paths used below will refer to this directory as <Instance>. 

2. คัดลอก Aspose.Slides.ReportingServices.dll ไปยังโฟลเดอร์ **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**  
   ไฟล์ดาวน์โหลด **Aspose.Slides.ReportingServices.zip** มี **Aspose.Slides.ReportingServices.dll** อยู่ {{% alert color="primary" %}} 

ในบางกรณี เมื่อคุณคัดลอก DLL ไปยังไดเรกทอรี **ReportServer\bin** มันอาจถูกคัดลอกพร้อมกับการกำหนดสิทธิ์ไฟล์ NTFS โดยตรง สิทธิ์ NTFS นี้ทำให้ Microsoft SQL Server Reporting Services ไม่สามารถเข้าถึงได้เมื่อติดตั้ง **Aspose.Slides.ReportingServices.dll** หากเกิดเช่นนี้ รูปแบบการส่งออกใหม่จะไม่พร้อมใช้งาน ตรวจสอบและยืนยันว่ามีการกำหนดสิทธิ์ NTFS ที่ถูกต้องอยู่ :

   1. คลิกขวาที่ **Aspose.Slides.ReportingServices.dll**.  
   2. คลิก **Properties** และเลือกแท็บ **Security**.  
   3. ลบสิทธิ์ NTFS ที่กำหนดโดยตรงออกและให้คงไว้เฉพาะสิทธิ์ที่สืบทอดมา  

{{% /alert %}}

3. ลงทะเบียน Aspose.Slides for Reporting Services เป็นส่วนขยายการแสดงผล:  
   1. เปิด *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.  
   1. เพิ่มบรรทัดต่อไปนี้ในองค์ประกอบ <Render>:  

**<Render>**

``` xml

   ...

  <!--เริ่มที่นี่.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--จบที่นี่.-->

</Render>



```

4. ให้สิทธิ์การดำเนินการแก่ Aspose.Slides for Reporting Services:  
   1. เปิด **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.  
   1. เพิ่มโค้ดต่อไปนี้เป็นรายการสุดท้ายในองค์ประกอบ <CodeGroup> ชั้นที่สองจากด้านนอก (ซึ่งควรเป็น <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">)  

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--เริ่มที่นี่.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="This code group grants full trust to the AS4SSRS assembly.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--จบที่นี่.-->

  </CodeGroup>

</CodeGroup>



```

5. ตรวจสอบว่า Aspose.Slides for Reporting Services ได้รับการติดตั้งอย่างสมบูรณ์แล้ว:  
   1. เปิด Report Manager และตรวจสอบรายการประเภทการส่งออกที่มีสำหรับรายงาน  

   {{% alert color="primary" %}} คุณสามารถเปิด Report Manager ได้โดยเปิดเว็บบราว์เซอร์ (Microsoft Internet Explorer 6.0 หรือใหม่กว่า) แล้วพิมพ์ URL ของ Report Manager ในแถบที่อยู่ (ค่าเริ่มต้นคือ http://< ComputerName >/Reports ).  
   {{% /alert %}}

1. เลือกรายงานบนเซิร์ฟเวอร์  
1. เปิดรายการ **Select Format**  
   คุณควรเห็นรายการรูปแบบการส่งออกที่จัดทำโดย Aspose.Slides for Reporting Services  
1. เลือก **PPT – PowerPoint Presentation via Aspose.Slides**  

**Aspose.Slides for Reporting Services ติดตั้งสำเร็จและรูปแบบการส่งออกใหม่พร้อมใช้งาน**  

![todo:image_alt_text](install-manually_1.png)




6. คลิกลิงก์ **Export**.  
   รายงานจะถูกสร้างในรูปแบบที่เลือก ส่งไปยังลูกค้า และจากนั้นเปิดในแอปพลิเคชันที่เหมาะสม ในกรณีของเรา รายงานถูกเปิดใน Microsoft PowerPoint.  

**รายงาน PPT ที่สร้างโดย Aspose.Slides for Reporting Services**  

![todo:image_alt_text](install-manually_2.png)

คุณได้ติดตั้ง Aspose.Slides for Reporting Services เสร็จสมบูรณ์และสร้างรายงานเป็นงานนำเสนอ Microsoft PowerPoint เรียบร้อยแล้ว!