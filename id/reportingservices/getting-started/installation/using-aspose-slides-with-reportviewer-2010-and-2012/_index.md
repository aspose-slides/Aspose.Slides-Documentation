---
title: Menggunakan Aspose.Slides dengan ReportViewer 2010 dan 2012
type: docs
weight: 80
url: /id/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
Artikel ini mengajarkan cara mengekspor laporan dari ReportViewer 2010/2012 ke presentasi PowerPoint.
{{% /alert %}} 

Kelas RplRenderer merender [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) ke presentasi PowerPoint. 

{{% alert color="primary" %}} 
RplRenderer menggunakan soft page breaks untuk mengontrol ukuran halaman dengan memakai tag RDL InteractiveHeight dan InteractiveWidth. 
{{% /alert %}} 

## **Contoh Kode**
Kode ini akan menunjukkan cara mengekspor laporan dari ReportViewer 2010/2012 ke PPT/PPTX menggunakan RplRenderer. Jalankan metode RenderToPpt untuk merender laporan saat ini ke PPT.

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

        /// Merender laporan saat ini ke presentasi Powerpoint

        /// </summary>

        /// <param name="reportViewer">Objek penampil laporan.</param>

        /// <param name="format">Format presentasi output.</param>

        /// <param name="filename">Nama file output.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Aktifkan fitur Ekspor ke RPL

            EnableRplRenderExtension(reportViewer);

            //buat file untuk presentasi kami

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //mulai proses rendering

                //di sini kami memilih untuk mengekspor dalam format PPT dan menyediakan outputStream

                renderer.StartRendering(format);

                int page = 1;

                //siklus ini mengiterasi semua halaman laporan

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //jika rplStream kosong maka kami telah mencapai akhir laporan

                        if (rplStream.Length == 0)

                            break;

                        //tambahkan halaman laporan sebagai slide ke dokumen

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //panggil metode finish untuk mengirim presentasi yang baru dibuat ke output stream

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Mengaktifkan ekstensi rendering RPL.

        /// Harap berhati-hati karena metode ini mengubah status internal instance kelas ReportViewer

        /// dan tidak ada jaminan bahwa metode ini akan berfungsi pada versi ReportViewer di masa mendatang

        /// </summary>

        /// <param name="reportViewer">Penampil laporan.</param>

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

        /// Merender halaman tertentu ke RPL

        /// </summary>

        /// <param name="reportViewer">Penampil laporan.</param>

        /// <param name="page">Halaman.</param>

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
## **Menggunakan dari Windows Forms**
Anda mungkin ingin menambahkan tombol Export ke TollStripPanel ReportViewer dengan menambahkan kode ini ke konstruktor Form:

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
- Proyek contoh dapat diunduh dari [tautan ini](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- Proyek webform contoh dapat diunduh dari [tautan ini](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)
{{% /alert %}}