---
title: Aspose.Slides को ReportViewer 2010 और 2012 के साथ उपयोग करना
type: docs
weight: 80
url: /hi/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
यह लेख आपको सिखाता है कि कैसे ReportViewer 2010/2012 से रिपोर्ट को PowerPoint प्रस्तुति में निर्यात किया जाए।
{{% /alert %}} 

RplRenderer क्लास [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) को PowerPoint प्रस्तुति में रेंडर करती है। 

{{% alert color="primary" %}} 
RplRenderer पृष्ठ आकार को नियंत्रित करने के लिए InteractiveHeight और InteractiveWidth RDL टैग्स का उपयोग [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) के साथ करता है। 
{{% /alert %}} 
## **उदाहरण कोड**
यह कोड दिखाएगा कि कैसे ReportViewer 2010/2012 से रिपोर्ट को RplRenderer का उपयोग करके PPT/PPTX में निर्यात किया जाए। वर्तमान रिपोर्ट को PPT में रेंडर करने के लिए RenderToPpt मेथड चलाएँ।

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
        /// वर्तमान रिपोर्ट को PowerPoint प्रस्तुति में रेंडर करता है
        /// </summary>
        /// <param name="reportViewer">रिपोर्ट व्यूअर ऑब्जेक्ट.</param>
        /// <param name="format">आउटपुट प्रस्तुति फ़ॉर्मेट.</param>
        /// <param name="filename">आउटपुट फ़ाइलनाम.</param>
        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //RPL एक्सपोर्ट सुविधा को सक्षम करें
            EnableRplRenderExtension(reportViewer);
            //हमारी प्रस्तुति के लिए फ़ाइल बनाएं
            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
                //रेंडरिंग प्रक्रिया शुरू करें
                //यहां हम PPT फ़ॉर्मेट में निर्यात चुन रहे हैं और आउटपुट स्ट्रीम प्रदान कर रहे हैं
                renderer.StartRendering(format);
                int page = 1;
                //यह लूप रिपोर्ट के सभी पृष्ठों पर इटररेट करता है
                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //यदि rplStream खाली है तो हमने रिपोर्ट का अंत पहुँचा है
                        if (rplStream.Length == 0)

                            break;
                        //रिपोर्ट पृष्ठ को स्लाइड के रूप में दस्तावेज़ में जोड़ें
                        renderer.RenderPage(rplStream);
                    }

                    page++;

                }

                //नव निर्मित प्रस्तुति को आउटपुट स्ट्रीम में फ्लश करने के लिए फिनिश मेथड को कॉल करें
                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>
        /// RPL रेंडरिंग एक्सटेंशन को सक्षम करता है।
        /// सावधान रहें क्योंकि यह मेथड ReportViewer क्लास इंस्टेंस की आंतरिक स्थिति को बदलता है
        /// और इस बात की कोई गारंटी नहीं है कि यह मेथड भविष्य के ReportViewer संस्करण में काम करेगा
        /// </summary>
        /// <param name="reportViewer">रिपोर्ट व्यूअर.</param>
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
        /// निर्दिष्ट पृष्ठ को RPL में रेंडर करता है
        /// </summary>
        /// <param name="reportViewer">रिपोर्ट व्यूअर.</param>
        /// <param name="page">पृष्ठ.</param>
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
## **Windows Forms से उपयोग**
आप ReportViewer के TollStripPanel में Export बटन जोड़ना चाह सकते हैं, इसके लिए इस कोड को फ़ॉर्म के कंस्ट्रक्टर में जोड़ें:

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
- नमूना प्रोजेक्ट डाउनलोड किया जा सकता है [यह लिंक ](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- नमूना वेबफ़ॉर्म प्रोजेक्ट डाउनलोड किया जा सकता है [यह लिंक](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)
{{% /alert %}}