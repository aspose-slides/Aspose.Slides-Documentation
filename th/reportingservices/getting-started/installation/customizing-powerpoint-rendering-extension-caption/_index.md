---
title: ปรับแต่งคำบรรยายส่วนขยายการแสดงผล PowerPoint
type: docs
weight: 60
url: /th/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 
บทความนี้แสดงวิธีการปรับแต่งคำบรรยายของตัวเลือกการแสดงผล Aspose.Slides สำหรับ Reporting Services. 
{{% /alert %}} 
## **ตัวอย่าง**
เมื่อติดตั้ง Aspose.Slides สำหรับ Reporting Services จะมีตัวเลือกการส่งออกเพิ่มอีก 4 รายการในเมนูแบบดรอปดาวน์ของตัวเลือกการส่งออก:
![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **วิธีแก้ไขข้อความคำบรรยาย**
คำบรรยายเริ่มต้นของส่วนขยายเหล่านี้สามารถเปลี่ยนแปลงได้โดยการเขียนทับชื่อเริ่มต้น ขั้นตอนต่อไปนี้จะแสดงวิธีการเปลี่ยนคำบรรยายจาก “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” เป็น “ **PowerPoint 97 – 2003 format(PPT)** ”. 

**ขั้นตอนที่ 1:** ค้นหาไฟล์ **rsreportserver.config** ที่โดยทั่วไปอยู่ในไดเรกทอรีนี้: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**ขั้นตอน** **2:** ค้นหาเส้นเหล่านี้ในไฟล์ rsreportserver.config: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**ขั้นตอน** **3:** แทนที่พารามิเตอร์ส่วนขยายด้วยสิ่งนี้: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

ตัวเลือกการส่งออกจะปรากฏดังนี้: 
![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)