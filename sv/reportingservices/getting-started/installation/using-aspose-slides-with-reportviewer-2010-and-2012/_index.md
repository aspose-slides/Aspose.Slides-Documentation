---
title: Använda Aspose.Slides med ReportViewer 2010 och 2012
type: docs
weight: 80
url: /sv/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
Den här artikeln visar hur du exporterar rapporter från ReportViewer 2010/2012 till en PowerPoint‑presentation.
{{% /alert %}} 

Klassen RplRenderer renderar [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) till en PowerPoint‑presentation. 

{{% alert color="primary" %}} 
RplRenderer använder mjuka sidbrytningar för att kontrollera sidstorlek genom att använda RDL‑taggarna InteractiveHeight och InteractiveWidth.
{{% /alert %}} 
## **Sample Code**
Den här koden visar hur du exporterar en rapport från ReportViewer 2010/2012 till PPT/PPTX med RplRenderer. Anropa metoden RenderToPpt för att rendera en aktuell rapport till PPT.

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

        /// Renderar den aktuella rapporten till en PowerPoint-presentation

        /// </summary>

        /// <param name="reportViewer">Rapportvisarobjektet.</param>

        /// <param name="format">Utdataformatet för presentationen.</param>

        /// <param name="filename">Utdatafilnamnet.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Aktivera export till RPL-funktionen

            EnableRplRenderExtension(reportViewer);

            //Skapa fil för vår presentation

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //Starta renderingsprocessen

                //Här väljer vi att exportera i PPT-format och tillhandahåller outputStream

                renderer.StartRendering(format);

                int page = 1;

                //Denna loop itererar genom alla sidor i rapporten

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //Om rplStream är tomt har vi nått rapportens slut

                        if (rplStream.Length == 0)

                            break;

                        //Lägg till rapportsidan som en bild till dokumentet

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //Anropa finish‑metoden för att spola vår nyskapade presentation till output‑strömmen

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Aktiverar RPL-renderingstillägget.

        /// Var försiktig eftersom denna metod ändrar intern status för ReportViewer‑klassinstansen

        /// och det finns ingen garanti för att metoden fungerar med framtida versioner av ReportViewer

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

        /// Renderar specifik sida till RPL

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
## **Using from Windows Forms**
Du kanske vill lägga till Export‑knappar i ReportViewers TollStripPanel genom att lägga till den här koden i formulärets konstruktor:

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
- Exempelprojektet kan hämtas från [den här länken ](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- Exempel‑webbformulärprojektet kan hämtas från [den här länken](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)
{{% /alert %}}