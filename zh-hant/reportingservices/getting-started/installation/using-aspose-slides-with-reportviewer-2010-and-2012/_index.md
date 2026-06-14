---
title: 使用 Aspose.Slides 搭配 ReportViewer 2010 與 2012
type: docs
weight: 80
url: /zh-hant/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---
 

{{% alert color="primary" %}} 
此文章教您如何將 ReportViewer 2010/2012 的報表匯出為 PowerPoint 簡報。
{{% /alert %}} 
RplRenderer 類別會將 [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) 轉換為 PowerPoint 簡報。 
{{% alert color="primary" %}} 
RplRenderer 使用 [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) 來控制頁面大小，使用 InteractiveHeight 與 InteractiveWidth RDL 標籤。 
{{% /alert %}} 
## **範例程式碼**
此程式碼示範如何使用 RplRenderer 從 ReportViewer 2010/2012 匯出報表為 PPT/PPTX。執行 RenderToPpt 方法即可將目前的報表渲染為 PPT。

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
        /// 將目前的報表渲染為 PowerPoint 簡報
        /// </summary>
        /// <param name="reportViewer">報表檢視器物件。</param>
        /// <param name="format">輸出簡報格式。</param>
        /// <param name="filename">輸出檔名。</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //啟用匯出至 RPL 功能
            EnableRplRenderExtension(reportViewer);
            //為簡報建立檔案
            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
                //開始渲染程序
                //此處我們選擇以 PPT 格式匯出並提供輸出串流
                renderer.StartRendering(format);
                int page = 1;
                //此迴圈遍歷報表的所有頁面
                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //如果 rplStream 為空則表示已達報表末端
                        if (rplStream.Length == 0)

                            break;
                        //將報表頁面加入為文件的投影片
                        renderer.RenderPage(rplStream);
                    }

                    page++;

                }

                //呼叫完成方法將新建立的簡報寫入輸出串流
                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>
        /// 啟用 RPL 渲染擴充功能。
        /// 請小心，此方法會更改 ReportViewer 類別實例的內部狀態，且無法保證此方法在未來版本的 ReportViewer 中仍能運作。
        /// </summary>
        /// <param name="reportViewer">報表檢視器。</param>
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
        /// 將特定頁面渲染為 RPL
        /// </summary>
        /// <param name="reportViewer">報表檢視器。</param>
        /// <param name="page">頁碼。</param>
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
## **在 Windows Forms 中使用**
您可能想在 ReportViewer 的 ToolStripPanel 中加入匯出按鈕，只需在 Form 的建構函式中加入以下程式碼：

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
- 可從 [此連結](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip) 下載範例專案。
- 可從 [此連結](http://www.aspose.com/docs/download/attachments/24150112/Report+ Viewer+WebForm.zip) 下載範例 WebForm 專案。
{{% /alert %}}