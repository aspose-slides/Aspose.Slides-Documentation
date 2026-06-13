---
title: การติดตั้งใหม่ Aspose.Slides for Reporting Services
type: docs
weight: 40
url: /th/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

บทความนี้อธิบายวิธีแก้ปัญหาสถานการณ์ที่ Aspose.Slides for Reporting Services ถูกติดตั้งแล้ว แต่ด้วยเหตุผลใดเหตุผลหนึ่งต้องทำการติดตั้งใหม่

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** ต้องการการติดตั้ง **.NET Framework 3.5** บนเครื่องโฮสต์ 

{{% /alert %}}

## **ขั้นตอนการติดตั้งใหม่ Aspose.Slides for Reporting Services**
สิ่งสำคัญที่สุดคือการลบการติดตั้ง Aspose.Slides for Reporting Services ก่อนหน้าทิ้งอย่างสมบูรณ์ ขณะที่โปรแกรมติดตั้ง MSI สามารถดำเนินการที่จำเป็นเพื่อถอนการติดตั้งและจึงติดตั้งใหม่โดยอัตโนมัติได้สำเร็จ แต่ต้องทำตามขั้นตอนต่อไปนี้:

1. ถอนการติดตั้ง Aspose.Slides for Reporting Services ด้วยโปรแกรมติดตั้ง MSI. 

2. ค้นหาไดเรกทอรีการติดตั้ง Aspose.Slides for Reporting Services ซึ่งโดยทั่วไปอยู่ที่:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. หากโปรแกรมติดตั้ง MSI ไม่ได้ลบไดเรกทอรี “Aspose.Slides for Reporting Services” เมื่อถอนการติดตั้ง Aspose.Slides for Reporting Services ให้ลบโฟลเดอร์นั้น. 

4. ค้นหาไบนารี **Aspose.Slides.ReportingServices.dll** ในไดเรกทอรี “bin” ของแต่ละอินสแตนซ์ SQL Server Reporting Service ตัวอย่างเช่น หากมีอินสแตนซ์ Microsoft SQL Server 2008 ชื่อ “MSSQLSERVER” ไดเรกทอรี “bin” ของ Reporting Service ที่สอดคล้องกันอาจอยู่ที่: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. หากโปรแกรมติดตั้ง MSI ไม่ได้ลบไฟล์ไบนารี Aspose.Slides.ReportingServices.dll จากไดเรกทอรีข้างต้นเมื่อถอนการติดตั้ง Aspose.Slides for Reporting Services ให้ลบไฟล์นั้นทันที.

6. ค้นหาไฟล์ **rsreportserver.config** สำหรับแต่ละอินสแตนซ์ SSRS ตัวอย่างเช่น หากมีอินสแตนซ์ Reporting Service “**MSRS10.MSSQLSERVER**” ไฟล์ **rsreportserver.config** จะอยู่ในไดเรกทอรีนี้:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. เปิดไฟล์ **rsreportserver.config** ด้วยโปรแกรมแก้ไขใด ๆ แล้วค้นหาบรรทัดที่ถูกสร้างเพื่อเพิ่ม PowerPoint Format Extensions ระหว่างการติดตั้ง Aspose.Slides for Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

```

**ขั้นตอน** **8:** หากโปรแกรมติดตั้ง MSI ไม่ได้ลบบรรทัดเหล่านั้นเมื่อถอนการติดตั้ง Aspose.Slides for Reporting Services ให้ลบบรรทัดเหล่านั้นจากไฟล์ **rsreportserver.config** ทันที.

**ขั้นตอน** **9:** ค้นหาไฟล์ **rssrvpolicy.config** สำหรับแต่ละอินสแตนซ์ SSRS ตัวอย่างเช่น หากมีอินสแตนซ์ Reporting Service “MSRS10.MSSQLSERVER” ไฟล์ **rssrvpolicy.config** จะอยู่ในไดเรกทอรีนี้:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**ขั้นตอน** **10:** เปิดไฟล์ **rssrvpolicy.config** ด้วยโปรแกรมแก้ไขใด ๆ แล้วค้นหาบรรทัดที่ถูกสร้างเพื่อให้สิทธิ์การดำเนินการกับ Aspose.Slides for Reporting Services ระหว่างการติดตั้ง Aspose.Slides for Reporting Services. 

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

**ขั้นตอน** **11:** หากโปรแกรมติดตั้ง MSI ไม่ได้ลบบรรทัดข้างต้นเมื่อถอนการติดตั้งผลิตภัณฑ์ ให้ลบบรรทัดเหล่านั้นจากไฟล์ **rssrvpolicy.config** ทันที. 

**ขั้นตอน** **12:** หาก Aspose.Slides for Reporting Services ถูกติดตั้งพร้อมกับ Microsoft Visual Studio สำหรับการพัฒนา RDL report และการส่งออกเป็นรูปแบบ PowerPoint ภายในสภาพแวดล้อม Microsoft Visual Studio ไฟล์ไบนารี Aspose.Slides.ReportingServices.dll และไฟล์กำหนดค่ (**rsreportserver.config** และ **rssrvpolicy.config**) ในกรณีของ Microsoft Visual Studio 2008 จะอยู่ที่: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**ขั้นตอน** **13:** หากโปรแกรมติดตั้ง MSI ไม่ได้ลบไฟล์ไบนารี **Aspose.Slides.ReportingServices.dll** ให้ลบมันออก นอกจากนี้ หากมันไม่ได้อัปเดตไฟล์ **rsreportserver.config** และ **rssrvpolicy.config** เพื่อเอา PowerPoint Format Extensions และสิทธิ์การดำเนินโค้ดออกตามลำดับ คุณจะต้องลบไฟล์เหล่านั้นด้วยตนเองเช่นเดียวกับที่ทำในขั้นตอนก่อนหน้า. 

**ขั้นตอน** **14:** ถึงเวลาติดตั้ง Aspose.Slides for Reporting Services ใหม่ ใช้โปรแกรมติดตั้ง MSI เพื่อการติดตั้งอัตโนมัติหรือทำด้วยตนเอง.