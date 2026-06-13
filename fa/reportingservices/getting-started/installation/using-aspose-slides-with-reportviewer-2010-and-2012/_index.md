---
title: استفاده از Aspose.Slides با ReportViewer 2010 و 2012
type: docs
weight: 80
url: /fa/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
این مقاله به شما آموزش می‌دهد چگونه گزارش‌ها را از ReportViewer 2010/2012 به یک ارائه PowerPoint صادر کنید.
{{% /alert %}} 

کلاس RplRenderer فرمت باینری [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) را به ارائه PowerPoint رندر می‌کند. 

{{% alert color="primary" %}} 
RplRenderer از [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) برای کنترل اندازه صفحه با استفاده از تگ‌های RDL InteractiveHeight و InteractiveWidth استفاده می‌کند. 
{{% /alert %}} 

## **نمونه کد**
این کد نشان می‌دهد چگونه یک گزارش را از ReportViewer 2010/2012 به PPT/PPTX با استفاده از RplRenderer صادر کنید. برای رندر گزارش فعلی به PPT، متد RenderToPpt را اجرا کنید.

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

        /// Renders current report to Powerpoint presentation

        /// </summary>

        /// <param name="reportViewer">The report viewer object.</param>

        /// <param name="format">The output presentation format.</param>

        /// <param name="filename">The output filename.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //فعال‌سازی ویژگی Export به RPL

            EnableRplRenderExtension(reportViewer);

            //ایجاد فایل برای ارائه

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //شروع فرآیند رندر

                //در اینجا فرمت PPT برای صادرات انتخاب می‌شود و خروجی استریم فراهم می‌شود

                renderer.StartRendering(format);

                int page = 1;

                //این حلقه تمام صفحات گزارش را پیمایش می‌کند

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //اگر rplStream خالی باشد، به انتهای گزارش رسیده‌ایم

                        if (rplStream.Length == 0)

                            break;

                        //صفحه گزارش را به‌عنوان اسلاید به سند اضافه کنید

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //متد Finish را فراخوانی کنید تا ارائه جدید ایجاد شده به خروجی استریم تخلیه شود

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Enables the RPL rendering extension.

        /// Be careful because this method alters internal state of ReportViewer class instance

        /// and there is no guarantee that this method will work with future version of ReportViewer

        /// </summary>

        /// <param name="reportViewer">The report viewer.</param>

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

        /// Renders specific page to RPL

        /// </summary>

        /// <param name="reportViewer">The report viewer.</param>

        /// <param name="page">The page.</param>

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
## **استفاده از Windows Forms**
ممکن است بخواهید دکمه‌های Export را به TollStripPanel گزارش‌نمایی ReportViewer اضافه کنید با افزودن این کد به سازنده Form:

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
- پروژه نمونه می‌تواند از [این لینک](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip) دانلود شود.
- پروژه نمونه وب‌فرم می‌تواند از [این لینک](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip) دانلود شود.
{{% /alert %}}