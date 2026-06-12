---
title: Utilizzo di Aspose.Slides con ReportViewer 2010 e 2012
type: docs
weight: 80
url: /it/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
Questo articolo ti insegna come esportare i report da ReportViewer 2010/2012 in una presentazione PowerPoint.
{{% /alert %}} 

La classe RplRenderer rende [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) in una presentazione PowerPoint. 

{{% alert color="primary" %}} 
RplRenderer utilizza [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) per controllare la dimensione della pagina usando i tag RDL InteractiveHeight e InteractiveWidth.
{{% /alert %}} 
## **Esempio di Codice**
Questo codice mostrerà come esportare un report da ReportViewer 2010/2012 in PPT/PPTX usando RplRenderer. Esegui il metodo RenderToPpt per rendere un report corrente in PPT.

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

        /// Rende il report corrente in una presentazione PowerPoint

        /// </summary>

        /// <param name="reportViewer">L'oggetto visualizzatore del report.</param>

        /// <param name="format">Il formato della presentazione di output.</param>

        /// <param name="filename">Il nome file di output.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Abilita la funzionalità di esportazione in RPL

            EnableRplRenderExtension(reportViewer);

            //Crea il file per la nostra presentazione

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //Avvia il processo di rendering

                //Qui scegliamo di esportare in formato PPT e forniamo l'outputStream

                renderer.StartRendering(format);

                int page = 1;

                //Questo ciclo itera attraverso tutte le pagine del report

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //Se rplStream è vuoto, abbiamo raggiunto la fine del report

                        if (rplStream.Length == 0)

                            break;

                        //Aggiunge la pagina del report come diapositiva al documento

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //Chiama il metodo Finish per scrivere la presentazione appena creata nello stream di output

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Abilita l'estensione di rendering RPL.

        /// Attenzione, poiché questo metodo modifica lo stato interno dell'istanza della classe ReportViewer

        /// e non vi è alcuna garanzia che questo metodo funzioni con versioni future di ReportViewer

        /// </summary>

        /// <param name="reportViewer">Il visualizzatore del report.</param>

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

        /// Rende una pagina specifica in RPL

        /// </summary>

        /// <param name="reportViewer">Il visualizzatore del report.</param>

        /// <param name="page">La pagina.</param>

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
## **Utilizzo con Windows Forms**
Potresti voler aggiungere pulsanti di esportazione al TollStripPanel di ReportViewer aggiungendo questo codice al costruttore del Form:

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
- Il progetto di esempio può essere scaricato da [questo link](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- Il progetto webform di esempio può essere scaricato da [questo link](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)
{{% /alert %}}