---
title: Używanie Aspose.Slides z ReportViewer 2010 i 2012
type: docs
weight: 80
url: /pl/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
Ten artykuł wyjaśnia, jak eksportować raporty z ReportViewer 2010/2012 do prezentacji PowerPoint.
{{% /alert %}} 

Klasa RplRenderer renderuje [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) do prezentacji PowerPoint. 

{{% alert color="primary" %}} 
RplRenderer używa [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) do kontrolowania rozmiaru strony przy użyciu znaczników RDL InteractiveHeight i InteractiveWidth. 
{{% /alert %}} 
## **Przykładowy kod**
Ten kod pokaże, jak wyeksportować raport z ReportViewer 2010/2012 do PPT/PPTX przy użyciu RplRenderer. Wywołaj metodę RenderToPpt, aby wyrenderować bieżący raport do PPT.

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
        /// Renderuje bieżący raport do prezentacji PowerPoint
        /// </summary>
        /// <param name="reportViewer">Obiekt przeglądarki raportów.</param>
        /// <param name="format">Format wyjściowej prezentacji.</param>
        /// <param name="filename">Nazwa pliku wyjściowego.</param>
        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)
        {
            //Włącz funkcję eksportu do RPL
            EnableRplRenderExtension(reportViewer);
            //utwórz plik dla naszej prezentacji
            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))
            {
                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();
                //rozpocznij proces renderowania
                //tutaj wybieramy eksport w formacie PPT i podajemy wyjściowy strumień
                renderer.StartRendering(format);
                int page = 1;
                //ta pętla iteruje po wszystkich stronach raportu
                while (true)
                {
                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))
                    {
                        //jeśli rplStream jest pusty, osiągnięto koniec raportu
                        if (rplStream.Length == 0)
                            break;
                        //dodaj stronę raportu jako slajd do dokumentu
                        renderer.RenderPage(rplStream);
                    }
                    page++;
                }
                //wywołaj metodę zakończenia, aby zapisać nowo utworzoną prezentację do strumienia wyjściowego
                renderer.FinishRendering(pptSteam);
            }
        }
        /// <summary>
        /// Włącza rozszerzenie renderowania RPL.
        /// Bądź ostrożny, ponieważ ta metoda zmienia wewnętrzny stan instancji klasy ReportViewer
        /// i nie ma gwarancji, że będzie działać w przyszłych wersjach ReportViewer
        /// </summary>
        /// <param name="reportViewer">Przeglądarka raportów.</param>
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
        /// Renderuje określoną stronę do RPL
        /// </summary>
        /// <param name="reportViewer">Przeglądarka raportów.</param>
        /// <param name="page">Numer strony.</param>
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
## **Użycie w Windows Forms**
Możesz chcieć dodać przyciski Export do TollStripPanel w ReportViewer, dodając ten kod do konstruktora formularza:

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
- Przykładowy projekt można pobrać z [tego linku](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- Przykładowy projekt webform można pobrać z [tego linku](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)
{{% /alert %}}