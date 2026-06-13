---
title: การใช้ Aspose.Slides กับ ReportViewer 2010 และ 2012
type: docs
weight: 80
url: /th/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
บทความนี้สอนวิธีส่งออกรายงานจาก ReportViewer 2010/2012 ไปยังงานนำเสนอ PowerPoint
{{% /alert %}} 

RplRenderer class renders [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) to PowerPoint presentation. 

{{% alert color="primary" %}} 
RplRenderer uses [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) to control page size use InteractiveHeight and InteractiveWidth RDL tags. 
{{% /alert %}} 

## **โค้ดตัวอย่าง**
โค้ดนี้จะแสดงวิธีส่งออกรายงานจาก ReportViewer 2010/2012 ไปยัง PPT/PPTX ด้วย RplRenderer. ให้เรียกเมธอด RenderToPpt เพื่อเรนเดอร์รายงานปัจจุบันเป็น PPT

[**C#**]()

``` xml



using System;

using System.Collections;

using System.IO;

using System.Reflection;

using Microsoft.Reporting.WinForms;


namespace Slides.ReportViewer2010

{

    class SlidesExportHelper

    {        /// <summary>
        /// ทำการเรนเดอร์รายงานปัจจุบันเป็นงานนำเสนอ Powerpoint
        /// </summary>
        /// <param name="reportViewer">อ็อบเจ็กต์ตัวดูรายงาน</param>
        /// <param name="format">รูปแบบการนำเสนอผลลัพธ์</param>
        /// <param name="filename">ชื่อไฟล์ผลลัพธ์</param>
        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //เปิดใช้งานคุณลักษณะการส่งออกเป็น RPL
            EnableRplRenderExtension(reportViewer);
            //สร้างไฟล์สำหรับงานนำเสนอของเรา
            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
                //เริ่มกระบวนการเรนเดอร์
                //ที่นี่เรากำลังเลือกส่งออกในรูปแบบ PPT และให้ outputStream
                renderer.StartRendering(format);
                int page = 1;
                //ลูปนี้ทำการวนซ้ำทุกหน้าของรายงาน
                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //ถ้า rplStream ว่างเปล่า หมายความว่าเราถึงจุดสิ้นสุดของรายงานแล้ว
                        if (rplStream.Length == 0)

                            break;
                        //เพิ่มหน้ารายงานเป็นสไลด์ในเอกสาร
                        renderer.RenderPage(rplStream);
                    }

                    page++;

                }

                //เรียกเมธอด finish เพื่อเขียนงานนำเสนอที่สร้างใหม่ลงใน output stream
                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>
        /// เปิดใช้งานส่วนขยายการเรนเดอร์ RPL.
        /// โปรดระวังว่าเมธอดนี้จะเปลี่ยนแปลงสถานะภายในของอินสแตนซ์คลาส ReportViewer
        /// และไม่มีการรับประกันว่าเมธอดนี้จะทำงานกับเวอร์ชันอนาคตของ ReportViewer
        /// </summary>
        /// <param name="reportViewer">ตัวดูรายงาน</param>
        public static void EnableRplRenderExtension(ReportViewer reportViewer)

        {

            object service = null;

            if (reportViewer.ProductVersion.StartsWith("11"))

                service = reportViewer.LocalReport.GetType().GetField("m_processingHost", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(reportViewer.LocalReport);

            else

                service = reportViewer.LocalReport.GetType().GetField("m_previewService", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(reportViewer.LocalReport);


            var extensions = service

                .GetType()

                .GetMethod("ListRenderingExtensions")

                .Invoke(service, null);

            IList RenderingExtensions = (IList)extensions;

            bool rplExportEnabled = false;

            foreach (var extension in RenderingExtensions)

            {

                var name = extension

                    .GetType()

                    .GetProperty("Name")

                    .GetValue(extension, null)

                    .ToString();

                if (name == "RPL")

                {               

                    extension

                        .GetType()

                        .GetField("m_isExposedExternally",

                    BindingFlags.NonPublic | BindingFlags.Instance)

                        .SetValue(extension, true);

                    rplExportEnabled = true;

                    break;

                }

            }

            if (!rplExportEnabled)

                throw new Exception("Can't enable RPL export. Please, make sure that you are using ReportViewer 2010 or ReportViewer 2012.");

        }



        /// <summary>
        /// ทำการเรนเดอร์หน้าที่ระบุเป็น RPL
        /// </summary>
        /// <param name="reportViewer">ตัวดูรายงาน</param>
        /// <param name="page">หน้าที่ต้องการ</param>
        static MemoryStream CreateRplStream(ReportViewer reportViewer, int page)

        {

            Warning[] warnings;

            var stream = new MemoryStream();

            reportViewer.LocalReport.Render("RPL",

                                                    String.Format(

                                                     @"<DeviceInfo>

                                                            <StartPage>{0}</StartPage>

                                                            <EndPage>{0}</EndPage>

                                                            <SecondaryStreams>Embedded</SecondaryStreams>

                                                    </DeviceInfo>", page),

                                                    (CreateStreamCallback)delegate { return stream; },

                                                    out warnings);

            return stream;

        }

    }

}
```
## **การใช้จาก Windows Forms**
คุณอาจต้องการเพิ่มปุ่ม Export ลงใน TollStripPanel ของ ReportViewer โดยเพิ่มโค้ดนี้ในคอนสตรัคเตอร์ของฟอร์ม:

[**C#**]()

``` xml



ToolStrip toolStrip = (ToolStrip) reportViewer.Controls.Find("toolStrip1", true)[0];



            ToolStripItem exportButton = toolStrip.Items.Add("Export to Pptx");

            exportButton.Click += new EventHandler((s,e) =>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                                     OutputPresentationFormat.Pptx,

                                                                                                     "SalesReport.pptx");

                                                       });



            exportButton = toolStrip.Items.Add("Export to Ppt");

            exportButton.Click += new EventHandler((s,e)=>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                              OutputPresentationFormat.Ppt,

                                                                                              "SalesReport.ppt");

                                                       });


```

{{% alert color="primary" %}} 
- ตัวอย่างโปรเจกต์สามารถดาวน์โหลดได้จาก [ลิงก์นี้](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- ตัวอย่างโปรเจกต์เว็บฟอร์มสามารถดาวน์โหลดได้จาก [ลิงก์นี้](http://www.aspose.com/docs/download/attachments/24150112/Report+ Viewer+WebForm.zip)
{{% /alert %}}