---
title: Verwendung von Aspose.Slides mit ReportViewer 2010 und 2012
type: docs
weight: 80
url: /reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 

Dieser Artikel zeigt Ihnen, wie Sie Berichte von ReportViewer 2010/2012 in eine PowerPoint-Präsentation exportieren.

{{% /alert %}} 

Die RplRenderer-Klasse rendert [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) in eine PowerPoint-Präsentation.

{{% alert color="primary" %}} 

Der RplRenderer verwendet [weichere Seitenumbrüche](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs), um die Seitengröße mithilfe der RDL-Tags InteractiveHeight und InteractiveWidth zu steuern.

{{% /alert %}} 
## **Beispiellcode**
Dieser Code zeigt, wie ein Bericht von ReportViewer 2010/2012 in PPT/PPTX unter Verwendung von RplRenderer exportiert wird. Führen Sie die RenderToPpt-Methode aus, um einen aktuellen Bericht in PPT zu rendern.

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

        /// Rendert den aktuellen Bericht in eine PowerPoint-Präsentation

        /// </summary>

        /// <param name="reportViewer">Das Berichtsanzeigefenster-Objekt.</param>

        /// <param name="format">Das Ausgabepräsentationsformat.</param>

        /// <param name="filename">Der Ausgabedateiname.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Export zu RPL aktivieren

            EnableRplRenderExtension(reportViewer);

            //Datei für unsere Präsentation erstellen

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //Rendering-Prozess starten

                //hier wählen wir, das im PPT-Format exportiert wird und stream bereitgestellt wird

                renderer.StartRendering(format);

                int page = 1;

                //diese Schleife iteriert durch alle Seiten des Berichts

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //wenn rplStream leer ist, haben wir das Ende des Berichts erreicht

                        if (rplStream.Length == 0)

                            break;

                        //Berichtsseite als Folie zum Dokument hinzufügen

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //finish-Methode aufrufen, um unsere neu erstellte Präsentation in den Ausgabestrom zu spülen

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Aktiviert die RPL-Rendererweiterung.

        /// Seien Sie vorsichtig, da diese Methode den internen Zustand der Instanz der ReportViewer-Klasse ändert

        /// und es gibt keine Garantie, dass diese Methode mit zukünftigen Versionen von ReportViewer funktioniert

        /// </summary>

        /// <param name="reportViewer">Das Berichtsanzeigefenster.</param>

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

                throw new Exception("RPL-Export kann nicht aktiviert werden. Bitte stellen Sie sicher, dass Sie ReportViewer 2010 oder ReportViewer 2012 verwenden.");

        }



        /// <summary>

        /// Rendert eine bestimmte Seite in RPL

        /// </summary>

        /// <param name="reportViewer">Das Berichtsanzeigefenster.</param>

        /// <param name="page">Die Seite.</param>

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
## **Verwendung aus Windows Forms**
Sie möchten möglicherweise Export-Schaltflächen zur TollStripPanel von ReportViewer hinzufügen, indem Sie diesen Code zum Konstruktor des Formulars hinzufügen:

[**C#**]()

``` xml

ToolStrip toolStrip = (ToolStrip) reportViewer.Controls.Find("toolStrip1", true)[0];

            ToolStripItem exportButton = toolStrip.Items.Add("Exportieren nach Pptx");

            exportButton.Click += new EventHandler((s,e) =>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                                     OutputPresentationFormat.Pptx,

                                                                                                     "SalesReport.pptx");

                                                       });

            exportButton = toolStrip.Items.Add("Exportieren nach Ppt");

            exportButton.Click += new EventHandler((s,e)=>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                              OutputPresentationFormat.Ppt,

                                                                                              "SalesReport.ppt");

                                                       });

```

{{% alert color="primary" %}} 

- Das Musterprojekt kann von [diesem Link ](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip) heruntergeladen werden.
- Das Muster-Webformularprojekt kann von [diesem Link](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip) heruntergeladen werden.

{{% /alert %}}