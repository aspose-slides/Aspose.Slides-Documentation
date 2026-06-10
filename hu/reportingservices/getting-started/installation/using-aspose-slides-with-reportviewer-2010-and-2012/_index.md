---
title: Az Aspose.Slides használata a ReportViewer 2010 és 2012 verziókhoz
type: docs
weight: 80
url: /hu/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
Ez a cikk bemutatja, hogyan lehet exportálni a jelentéseket a ReportViewer 2010/2012-ből PowerPoint bemutatóba. 
{{% /alert %}} 

Az RplRenderer osztály a [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) formátumot rendereli PowerPoint bemutatóba. 

{{% alert color="primary" %}} 
Az RplRenderer a [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) funkciót használja az oldalméret vezérléséhez az InteractiveHeight és InteractiveWidth RDL címkék segítségével. 
{{% /alert %}} 
## **Sample Code**
Ez a kód bemutatja, hogyan lehet exportálni egy jelentést a ReportViewer 2010/2012-ből PPT/PPTX formátumba az RplRenderer segítségével. A RenderToPpt metódus meghívásával a jelenlegi jelentést PPT formátumba renderelhetjük.

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

        /// Rendereli az aktuális jelentést Powerpoint bemutatóba

        /// </summary>

        /// <param name="reportViewer">A jelentésnéző objektum.</param>

        /// <param name="format">A kimeneti bemutató formátuma.</param>

        /// <param name="filename">A kimeneti fájl neve.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //RPL exportálási funkció engedélyezése

            EnableRplRenderExtension(reportViewer);

            //Fájl létrehozása a bemutatóhoz

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //Renderelési folyamat elindítása

                //Itt PPT formátumban exportálunk és megadjuk a kimeneti adatfolyamot

                renderer.StartRendering(format);

                int page = 1;

                //Ez a ciklus a jelentés összes oldalát iterálja

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //Ha az rplStream üres, akkor a jelentés vége

                        if (rplStream.Length == 0)

                            break;

                        //Jelentésoldal hozzáadása diaként a dokumentumhoz

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //A FinishRendering metódus hívása az újonnan létrehozott bemutató adatfolyamba írásához

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Engedélyezi az RPL renderelési kiterjesztést.

        /// Legyen óvatos, mert ez a metódus módosítja a ReportViewer osztály példányának belső állapotát

        /// és nincs garancia, hogy ez a metódus a jövőbeni ReportViewer verziókban is működni fog

        /// </summary>

        /// <param name="reportViewer">A jelentésnéző.</param>

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

        /// Rendereli a megadott oldalt RPL-be

        /// </summary>

        /// <param name="reportViewer">A jelentésnéző.</param>

        /// <param name="page">Az oldal.</param>

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
Elhelyezhet Export gombokat a ReportViewer TollStripPanel-jén a következő kód a form konstruktorába való elhelyezésével:

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
- A példaprojekt letölthető innen: [this link ](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- A példaként szolgáló webes űrlap projekt letölthető innen: [this link](http://www.aspose.com/docs/download/attachments/24150112/Report+ Viewer+WebForm.zip)
{{% /alert %}}