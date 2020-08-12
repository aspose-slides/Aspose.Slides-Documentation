---
title: Using Aspose.Slides with ReportViewer 2010 and 2012
type: docs
weight: 80
url: /reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

﻿

{{% alert color="primary" %}} 

This page demonstrates how to export report from ReportViewer 2010/2012 to PowerPoint presentation﻿.

{{% /alert %}} 

RplRenderer class renders [Report Page Layout (RPL) Binary Stream Format](http://msdn.microsoft.com/en-us/library/ee301773.aspx) to PowerPoint presentation. 

{{% alert color="primary" %}} 

RplRenderer uses [soft page breaks](http://msdn.microsoft.com/en-us/library/dd255244.aspx) to control page size use InteractiveHeight and InteractiveWidth RDL tags. 

{{% /alert %}} 
#### **Sample Code**
This code will show how to export report from ReportViewer 2010/2012 to PPT/PPTX using RplRenderer. Execute RenderToPpt method to render current report to PPT.

[**C#**](/pages/createpage.action?spaceKey=slidesreportingservices&title=C&linkCreation=true&fromPageId=10289153)

```



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

            //Enable Export to RPL feature

            EnableRplRenderExtension(reportViewer);

            //create file for our presentation

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //start rendering process

                //here we are choosing to export in PPT format and providing outputStream

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

                //call finish method to flush our newly created presentation to output stream

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
#### **Using from Windows Forms**
Optionally you can add Export buttons to TollStripPanel of ReportViewer by adding next code to Form's constructor:

[**C#**](/pages/createpage.action?spaceKey=slidesreportingservices&title=C&linkCreation=true&fromPageId=10289153)

```



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

- The sample project can be downloaded from [this link ](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- The sample webform project can be downloaded from [this link](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)

{{% /alert %}}
