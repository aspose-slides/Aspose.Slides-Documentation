---
title: Sử dụng Aspose.Slides với ReportViewer 2010 và 2012
type: docs
weight: 80
url: /vi/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}}
Bài viết này hướng dẫn cách xuất báo cáo từ ReportViewer 2010/2012 sang trình chiếu PowerPoint.
{{% /alert %}}

Lớp RplRenderer chuyển đổi [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) sang trình chiếu PowerPoint.

{{% alert color="primary" %}}
RplRenderer sử dụng [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) để kiểm soát kích thước trang bằng cách sử dụng các thẻ RDL InteractiveHeight và InteractiveWidth.
{{% /alert %}}

## **Mã mẫu**
Đoạn mã này sẽ minh họa cách xuất báo cáo từ ReportViewer 2010/2012 sang PPT/PPTX bằng RplRenderer. Gọi phương thức RenderToPpt để chuyển đổi báo cáo hiện tại sang PPT.

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

        /// Kết xuất báo cáo hiện tại thành bản trình chiếu Powerpoint

        /// </summary>

        /// <param name="reportViewer">Đối tượng trình xem báo cáo.</param>

        /// <param name="format">Định dạng bản trình chiếu đầu ra.</param>

        /// <param name="filename">Tên tệp đầu ra.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Kích hoạt tính năng Xuất sang RPL

            EnableRplRenderExtension(reportViewer);

            //tạo tệp cho bản trình chiếu của chúng ta

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //bắt đầu quá trình render

                //ở đây chúng ta chọn xuất ở định dạng PPT và cung cấp outputStream

                renderer.StartRendering(format);

                int page = 1;

                //this cycle iterates through all pages of report

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //if rplStream is empty then we reached end of report

                        if (rplStream.Length == 0)

                            break;

                        //add report page as slide to the document

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //gọi phương thức finish để đẩy bản trình chiếu mới tạo vào output stream

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Kích hoạt tiện ích mở rộng render RPL.

        /// Cẩn thận vì phương pháp này thay đổi trạng thái nội bộ của đối tượng ReportViewer.

        /// và không có gì đảm bảo rằng phương pháp này sẽ hoạt động với các phiên bản tương lai của ReportViewer

        /// </summary>

        /// <param name="reportViewer">Trình xem báo cáo.</param>

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

        /// Kết xuất trang cụ thể sang RPL

        /// </summary>

        /// <param name="reportViewer">Trình xem báo cáo.</param>

        /// <param name="page">Trang.</param>

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
## **Sử dụng trong Windows Forms**
Bạn có thể muốn thêm các nút Export vào TollStripPanel của ReportViewer bằng cách chèn đoạn mã này vào hàm khởi tạo của Form:

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
- Có thể tải dự án mẫu từ [liên kết này](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- Có thể tải dự án webform mẫu từ [liên kết này](http://www.aspose.com/docs/download/attachments/24150112/Report+ Viewer+WebForm.zip)
{{% /alert %}}