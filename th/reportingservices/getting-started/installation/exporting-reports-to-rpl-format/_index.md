---
title: การส่งออกรายงานเป็นรูปแบบ RPL
type: docs
weight: 110
url: /th/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Aspose.Slides ใช้รายงานในรูปแบบ RPL (Report Processing Language) เพื่อการแสดงผล หน้านี้แสดงวิธีการส่งออกรายงานเป็นรูปแบบ RPL.{{% /alert %}}

ในหลายสถานการณ์ ลูกค้าต้องแชร์รายงานที่มีปัญหาเพื่อการแก้ไขกับทีมงานของ Aspose เมื่อรายงานที่แชร์อยู่ในรูปแบบ RDL ชุดข้อมูลหรือสคีมาจะถูกแชร์ด้วยเพื่อให้เราสามารถจำลองปัญหาได้ บางครั้งแม้การแชร์รายงาน RDL พร้อมชุดข้อมูลก็ไม่เพียงพอที่จะแก้ปัญหาได้อย่างสมบูรณ์ ในกรณีเช่นนี้ เราแนะนำให้คุณส่งออกรายงานเป็นรูปแบบ RPL และแชร์ไฟล์ RPL ให้เรา ไฟล์ RPL จะรวมชุดข้อมูลที่ใช้ด้วย วิธีนี้ทำให้การส่งออกเป็น RPL ง่ายขึ้นและสามารถแชร์ให้เราได้ทันที

ทำตามขั้นตอนต่อไปนี้:

1. คัดลอก Aspose.ReportingServices.Debug.Rpl.dll ไปยังไดเรกทอรี bin ของ Reporting Services (โดยทั่วไปอยู่ที่ c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 
Aspose.ReportingServices.Debug.Rpl.dll มีให้ใช้งานในเวอร์ชันล่าสุดของ Aspose.Slides for Reporting Services ซึ่งสามารถดาวน์โหลดได้จากหน้า [Releases page](https://releases.aspose.com/slides/th/reportingservices/).{{% /alert %}}

2. เพิ่มส่วนขยายนี้ไปยังแท็ก **<Render>** ของไฟล์ **rsreportserver.config** (โดยทั่วไปอยู่ที่ c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//เพิ่มแท็กนี้ลงในองค์ประกอบ <Render> 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. ระบุพาธไปยังไฟล์ RPL ที่สร้างขึ้นโดยแก้ไของค์ประกอบ path.

4. ให้สิทธิ์ Aspose.ReportingServices.Debug.Rpl.dll เพื่อทำงานตามนี้: เปิดไฟล์ C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config และเพิ่มโค้ดนี้เป็นรายการสุดท้ายใน **<CodeGroup>** ชั้นที่สองจากด้านนอก (ควรเป็น **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">**) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--เริ่มที่นี่.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--จบที่นี่.-->

  </CodeGroup>

</CodeGroup>


```

5. รีสตาร์ท Reporting services คุณควรพบตัวเลือก Aspose.Rpl ในเมนู Export.

ตัวเลือก "Rpl export" ควรแสดงบนแผงการส่งออก คุณต้องส่งออกรายงานเป็น RPL และแชร์ไฟล์ RPL นั้น.