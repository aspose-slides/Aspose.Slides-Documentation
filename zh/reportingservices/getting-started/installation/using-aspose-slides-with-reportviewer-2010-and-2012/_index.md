---
title: 使用 Aspose.Slides 与 ReportViewer 2010 和 2012
type: docs
weight: 80
url: /zh/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

﻿

{{% alert color="primary" %}} 

本文教您如何从 ReportViewer 2010/2012 导出报告为 PowerPoint 演示文稿﻿。

{{% /alert %}} 

RplRenderer 类将 [报告页面布局 (RPL) 二进制流格式](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) 渲染为 PowerPoint 演示文稿。 

{{% alert color="primary" %}} 

RplRenderer 使用 [软分页](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) 来控制页面大小，使用 InteractiveHeight 和 InteractiveWidth RDL 标签。 

{{% /alert %}} 
## **示例代码**
此代码将展示如何使用 RplRenderer 从 ReportViewer 2010/2012 导出报告到 PPT/PPTX。执行 RenderToPpt 方法将当前报告渲染为 PPT。

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

        /// 将当前报告渲染为 Powerpoint 演示文稿

        /// </summary>

        /// <param name="reportViewer">报告查看器对象。</param>

        /// <param name="format">输出演示文稿格式。</param>

        /// <param name="filename">输出文件名。</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //启用导出到 RPL 功能

            EnableRplRenderExtension(reportViewer);

            //为我们的演示文稿创建文件

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //开始渲染过程

                //在这里我们选择导出为 PPT 格式并提供输出流

                renderer.StartRendering(format);

                int page = 1;

                //此循环遍历报告的所有页面

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //如果 rplStream 为空则说明我们已到达报告末尾

                        if (rplStream.Length == 0)

                            break;

                        //将报告页面作为幻灯片添加到文档中

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //调用 finish 方法以将我们新创建的演示文稿刷新到输出流

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// 启用 RPL 渲染扩展。

        /// 请小心，因为此方法会改变 ReportViewer 类实例的内部状态

        /// 并且无法保证此方法在未来版本的 ReportViewer 中可用

        /// </summary>

        /// <param name="reportViewer">报告查看器。</param>

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

                throw new Exception("无法启用 RPL 导出。请确保您使用的是 ReportViewer 2010 或 ReportViewer 2012。");

        }



        /// <summary>

        /// 将特定页面渲染为 RPL

        /// </summary>

        /// <param name="reportViewer">报告查看器。</param>

        /// <param name="page">页面。</param>

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
## **从 Windows 窗体使用**
您可能希望通过将以下代码添加到窗体的构造函数中，为 ReportViewer 的 TollStripPanel 添加导出按钮：

[**C#**]()

``` xml



ToolStrip toolStrip = (ToolStrip) reportViewer.Controls.Find("toolStrip1", true)[0];




            ToolStripItem exportButton = toolStrip.Items.Add("导出为 Pptx");

            exportButton.Click += new EventHandler((s,e) =>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                                     OutputPresentationFormat.Pptx,

                                                                                                     "SalesReport.pptx");

                                                       });
 



            exportButton = toolStrip.Items.Add("导出为 Ppt");

            exportButton.Click += new EventHandler((s,e)=>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                              OutputPresentationFormat.Ppt,

                                                                                              "SalesReport.ppt");

                                                       });


```

{{% alert color="primary" %}} 

- 示例项目可从 [此链接下载](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- 示例网页项目可从 [此链接下载](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)

{{% /alert %}}