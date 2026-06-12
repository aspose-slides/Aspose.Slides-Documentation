---
title: Aspose.Slides gebruiken met ReportViewer 2010 en 2012
type: docs
weight: 80
url: /nl/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---
 

{{% alert color="primary" %}} 
Dit artikel leert u hoe u rapporten van ReportViewer 2010/2012 kunt exporteren naar een PowerPoint‑presentatie.
{{% /alert %}} 

RplRenderer‑klasse rendert [Report Page Layout (RPL) Binaire Streamformaat](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) naar een PowerPoint‑presentatie. 

{{% alert color="primary" %}} 
RplRenderer gebruikt zachte pagina‑afbrekingen om de paginagrootte te regelen met behulp van de RDL‑tags InteractiveHeight en InteractiveWidth. 
{{% /alert %}} 
## **Voorbeeldcode**
Deze code toont hoe u een rapport van ReportViewer 2010/2012 kunt exporteren naar PPT/PPTX met RplRenderer. Roep de RenderToPpt‑methode aan om een huidig rapport naar PPT te renderen.

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

        /// Renderen van huidig rapport naar PowerPoint-presentatie

        /// </summary>

        /// <param name="reportViewer">Het rapportweergave‑object.</param>

        /// <param name="format">Het uitvoer‑presentatieformaat.</param>

        /// <param name="filename">De uit te voeren bestandsnaam.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Export‑naar‑RPL‑functionaliteit inschakelen

            EnableRplRenderExtension(reportViewer);

            //bestand aanmaken voor onze presentatie

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //renderingsproces starten

                //hier kiezen we ervoor om te exporteren in PPT‑formaat en geven we de output‑stream door

                renderer.StartRendering(format);

                int page = 1;

                //deze lus doorloopt alle pagina's van het rapport

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //als rplStream leeg is, hebben we het einde van het rapport bereikt

                        if (rplStream.Length == 0)

                            break;

                        //voeg rapportpagina toe als dia aan het document

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //roep finish‑methode aan om onze nieuw aangemaakte presentatie naar de output‑stream te schrijven

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Schakelt de RPL-rendering‑extensie in.

        /// Wees voorzichtig, want deze methode wijzigt de interne staat van de ReportViewer‑klasse‑instantie

        /// en er is geen garantie dat deze methode werkt met toekomstige versies van ReportViewer

        /// </summary>

        /// <param name="reportViewer">De rapportweergave.</param>

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

        /// Renderen van een specifieke pagina naar RPL

        /// </summary>

        /// <param name="reportViewer">De rapportweergave.</param>

        /// <param name="page">De pagina.</param>

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
## **Gebruik vanuit Windows Forms**
U wilt mogelijk exportknoppen toevoegen aan TollStripPanel van ReportViewer door deze code aan de constructor van het formulier toe te voegen:

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
- Het voorbeeldproject kan worden gedownload via [deze link](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- Het voorbeeldwebformulierproject kan worden gedownload via [deze link](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)
{{% /alert %}}