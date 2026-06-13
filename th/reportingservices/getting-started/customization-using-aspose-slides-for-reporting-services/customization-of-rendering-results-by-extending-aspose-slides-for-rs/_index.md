---
title: การปรับแต่งผลลัพธ์การแสดงผลโดยการขยาย Aspose.Slides for RS
type: docs
weight: 10
url: /th/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 

หน้านี้อธิบายวิธีสร้างส่วนขยายสำหรับ Aspose.Slides for RS.

- [สร้าง Assembly ส่วนขยาย](/slides/th/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [การรวมส่วนขยาย](/slides/th/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

คุณสมบัติ Custom Extension ให้คุณเพิ่มองค์ประกอบเพิ่มเติมหรืออัปเดตองค์ประกอบที่มีอยู่ระหว่างการส่งออกรายงาน.

## **วิธีสร้าง Assembly ส่วนขยาย**
1. สร้างโครงการ .NET แล้วเพิ่มการอ้างอิงไปยัง Aspose.Slides.ReportingServices.dll.
1. เพิ่มคลาสและสืบทอดจาก Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. เขียนทับเมธอดเสมือนของคลาสตเพื่อเพิ่มฟังก์ชันการทำงานแบบกำหนดเอง.
### **ตัวอย่าง**
สมมติว่าเราต้องการเพิ่มโน้ตที่มีข้อความบางส่วน, โลโก้และอัปเดตชื่อบริษัทสำหรับทุกรายงานที่ส่งออกด้วย Aspose.Slides for RS.

เพื่อวัตถุนั้นเราจะเพิ่มคลาสต่อไปนี้:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//เพิ่มโน้ตในสไลด์แรก

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//แสดงโลโก้บนสไลด์ทุกสไลด์ที่มุมล่างขวา

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//เพิ่ม (TM) ให้กับการอ้างถึงชื่อบริษัทใด ๆ ในรายงาน

string companyName = "Adventure Works";

if (textBox.Text.Contains(companyName))

{

textBox.Text = textBox.Text.Replace(companyName, companyName + "™");

}

base.PostProcessTextBox(textBox);

}

}

```

{{% alert color="primary" %}} 

ทำการคอมไพล์และคุณจะได้ Assembly ส่วนขยาย เราพร้อมที่จะรวมส่วนขยายแล้ว.

{{% /alert %}} 

[โครงการ Visual Studio ของ RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **การรวมส่วนขยาย**
สมมติว่า Assembly ของคุณชื่อ **TestSlidesRenderingExtension.dll**:

- คัดลอก Assembly ไปยังไดเรกทอรี **bin** ของ ReportingService ถัดจาก Aspose.Slides.ReportingServices.dll (เช่น: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- ให้สิทธิ์ FullTrust แก่ Assembly ของคุณโดยเพิ่ม CodeGroup ต่อไปนี้ไปยัง **rssrvpolicy.config**:

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" />

...

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" />

...

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="This code group grants full trust to the Aspose.Slides for Reporting Services Rendering extension.">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

อัปเดตส่วนกำหนดค่า rendering extension ของ Aspose.Slides ใน **rsreportserver.config** เพื่อรวมส่วนขยายของคุณ.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">
<Configuration>
<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>
</Configuration>
</Extension>

```

หากคุณต้องการใช้ส่วนขยายสำหรับทุกประเภทของเอาต์พุตที่ Aspose.Slides รองรับ ให้เพิ่มการกำหนดค่าเดียวกันไปยัง extensions ที่มีชื่อ ASPPTX, ASPPT, ASPPS, ASPPSX.

เนื้อหาของแท็ก Extension เป็นชื่อที่ระบุ Assembly-qualified ของประเภท (ดูที่ <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

จากนั้นรีสตาร์ท Reporting Services และส่งออกรายงาน คุณจะได้สิ่งที่คล้ายกับ [การนำเสนอนี้](attachments/10289195/10452997.pptx) จากรายงาน Company Sales SQL2008R2 ของตัวอย่าง Adventureworks.