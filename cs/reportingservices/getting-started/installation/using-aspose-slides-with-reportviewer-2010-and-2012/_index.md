---
title: Použití Aspose.Slides s ReportViewer 2010 a 2012
type: docs
weight: 80
url: /cs/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
Tento článek vás naučí, jak exportovat zprávy z ReportViewer 2010/2012 do prezentace PowerPoint.
{{% /alert %}} 

Třída RplRenderer vykresluje [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) do prezentace PowerPoint. 

{{% alert color="primary" %}} 
RplRenderer používá [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) k řízení velikosti stránky pomocí značek RDL InteractiveHeight a InteractiveWidth.
{{% /alert %}} 

## **Ukázkový kód**
Tento kód ukáže, jak exportovat zprávu z ReportViewer 2010/2012 do PPT/PPTX pomocí RplRenderer. Pro vykreslení aktuální zprávy do PPT spusťte metodu RenderToPpt.

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
        /// Vykreslí aktuální zprávu do prezentace PowerPoint
        /// </summary>
        /// <param name="reportViewer">Objekt prohlížeče zpráv.</param>
        /// <param name="format">Formát výstupní prezentace.</param>
        /// <param name="filename">Název výstupního souboru.</param>
        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Povolit funkci Export do RPL
            EnableRplRenderExtension(reportViewer);
            //vytvořit soubor pro naši prezentaci
            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
                //spustit proces vykreslování
                //zde vybíráme export do formátu PPT a poskytujeme výstupní proud
                renderer.StartRendering(format);
                int page = 1;
                //tento cyklus iteruje přes všechny stránky zprávy
                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //pokud je rplStream prázdný, pak jsme dosáhli konce zprávy
                        if (rplStream.Length == 0)

                            break;
                        //přidat stránku zprávy jako snímek do dokumentu
                        renderer.RenderPage(rplStream);
                    }

                    page++;

                }

                //volat metodu FinishRendering pro vyprázdnění naší nově vytvořené prezentace do výstupního proudu
                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>
        /// Povolí rozšíření pro vykreslování RPL.
        /// Buďte opatrní, protože tato metoda mění vnitřní stav instance třídy ReportViewer
        /// a neexistuje žádná záruka, že tato metoda bude fungovat s budoucí verzí ReportVieweru
        /// </summary>
        /// <param name="reportViewer">Prohlížeč zpráv.</param>
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
        /// Vykreslí konkrétní stránku do RPL
        /// </summary>
        /// <param name="reportViewer">Prohlížeč zpráv.</param>
        /// <param name="page">Stránka.</param>
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
## **Použití ve Windows Forms**
Můžete chtít přidat tlačítka Export do TollStripPanelu komponenty ReportViewer přidáním tohoto kódu do konstruktoru formuláře:

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
- Ukázkový projekt lze stáhnout z [tento odkaz](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- Ukázkový projekt webového formuláře lze stáhnout z [tento odkaz](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)
{{% /alert %}}