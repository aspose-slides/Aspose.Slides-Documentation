---
title: การรวมด้วยตนเองกับ Visual Studio 2005 หรือ 2008 Report Designer
type: docs
weight: 50
url: /th/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

บทความนี้สอนวิธีการรวม Aspose.Slides for Reporting Services ด้วยตนเองกับ Visual Studio. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** ต้องการการติดตั้ง **.NET Framework 3.5** บนเครื่องโฮสต์. 

{{% /alert %}}

## **การรวม Aspose.Slides for Reporting Services กับ Visual Studio**
เราแนะนำให้คุณใช้ตัวติดตั้ง MSI เพื่อติดตั้ง Aspose.Slides for Reporting Services เนื่องจากมันทำการติดตั้งและกระบวนการกำหนดค่าที่จำเป็นทั้งหมดโดยอัตโนมัติ อย่างไรก็ตาม หากการติดตั้งด้วยตัวติดตั้ง MSI ล้มเหลว ให้ใช้คำแนะนำนี้. 

บทความนี้ยังแสดงวิธีการติดตั้ง Aspose.Slides for Reporting Services บนคอมพิวเตอร์ที่มี Business Intelligence Development Studio ซึ่งจะทำให้คุณสามารถส่งออกรายงานเป็นรูปแบบ Microsoft PowerPoint ได้ในระหว่างการออกแบบจาก Microsoft Visual Studio 2005 หรือ 2008 Report Designer. 

1. คัดลอก Aspose.Slides.ReportingServices.dll ไปยังไดเรกทอรีของ Visual Studio.

   - เพื่อรวมกับ Visual Studio 2005 Report Designer ให้คัดลอก **Aspose.Slides.ReportingServices.dll** ไปยังไดเรกทอรี **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - เพื่อรวมกับ Visual Studio 2008 Report Designer ให้คัดลอก **Aspose.Slides.ReportingServices.dll** ไปยังไดเรกทอรี **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. ลงทะเบียน Aspose.Slides for Reporting Services เป็นส่วนขยายการแสดงผล. 

3. เปิด **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config** (โดยที่ <Version> คือ “8” สำหรับ Visual Studio 2005 หรือ “9.0” สำหรับ Visual Studio 2008) แล้วเพิ่มบรรทัดเหล่านี้ลงในองค์ประกอบ <Render>: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. ให้สิทธิ์ Aspose.Slides for Reporting Services เพื่อดำเนินการ. 
   1. เปิด **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (โดยที่ <Version> คือ “8” สำหรับ Visual Studio 2005 หรือ “9.0” สำหรับ Visual Studio 2008).
   1. เพิ่มบรรทัดนี้เป็นรายการสุดท้ายในองค์ประกอบ <CodeGroup> ชั้นที่สองจากนอก (ซึ่งควรเป็น <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) 

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

5. ตรวจสอบว่า Aspose.Slides for Reporting Services ได้รับการติดตั้งสำเร็จหรือไม่. 
6. เรียกใช้หรือรีสตาร์ท Microsoft Visual Studio 2005 หรือ 2008 Report Designer คุณควรสังเกตเห็นรูปแบบใหม่ในรายการรูปแบบการส่งออก.

**รูปแบบการส่งออกใหม่ปรากฏใน Report Designer.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)