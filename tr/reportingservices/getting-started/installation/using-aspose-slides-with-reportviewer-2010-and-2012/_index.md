---
title: Aspose.Slides'ı ReportViewer 2010 ve 2012 ile Kullanma
type: docs
weight: 80
url: /tr/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
Bu makale, ReportViewer 2010/2012'den raporları PowerPoint sunumuna nasıl dışa aktaracağınızı öğretir.
{{% /alert %}} 

RplRenderer sınıfı, [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) için PowerPoint sunumu oluşturur. 

{{% alert color="primary" %}} 
RplRenderer, sayfa boyutunu kontrol etmek için InteractiveHeight ve InteractiveWidth RDL etiketlerini kullanan [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) kullanır. 
{{% /alert %}} 
## **Örnek Kod**
Bu kod, ReportViewer 2010/2012'den bir raporu RplRenderer kullanarak PPT/PPTX'ye nasıl dışa aktaracağınızı gösterir. Mevcut raporu PPT'ye render etmek için RenderToPpt yöntemini çalıştırın.

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
        /// Geçerli raporu Powerpoint sunumuna render eder
        /// </summary>
        /// <param name="reportViewer">Rapor görüntüleyici nesnesi.</param>
        /// <param name="format">Çıktı sunum formatı.</param>
        /// <param name="filename">Çıktı dosya adı.</param>
        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //RPL dışa aktarma özelliğini etkinleştir
            EnableRplRenderExtension(reportViewer);
            //Sunumumuz için dosya oluştur
            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //renderleme sürecini başlat
                //burada PPT formatında dışa aktarmayı seçiyoruz ve çıktı akışını sağlıyoruz
                renderer.StartRendering(format);

                int page = 1;

                //bu döngü raporun tüm sayfalarını iterasyon eder
                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //rplStream boşsa raporun sonuna ulaştık
                        if (rplStream.Length == 0)

                            break;

                        //rapor sayfasını belgeye slayt olarak ekle
                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //tamamla metodunu çağırarak yeni oluşturulan sunumu çıktı akışına gönder
                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>
        /// RPL render uzantısını etkinleştirir.
        /// Dikkatli olun, çünkü bu yöntem ReportViewer sınıf örneğinin dahili durumunu değiştirir
        /// ve bu yöntemin gelecekteki ReportViewer sürümleriyle çalışacağına dair bir garanti yoktur
        /// </summary>
        /// <param name="reportViewer">Rapor görüntüleyici.</param>
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
        /// Belirli sayfayı RPL'ye render eder
        /// </summary>
        /// <param name="reportViewer">Rapor görüntüleyici.</param>
        /// <param name="page">Sayfa.</param>
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
## **Windows Forms'tan Kullanım**
Formun yapıcısına bu kodu ekleyerek ReportViewer'ın TollStripPanel'ine Export düğmeleri eklemek isteyebilirsiniz:

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
- Örnek proje, [bu bağlantı](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip) üzerinden indirilebilir
- Örnek webform projesi, [bu bağlantı](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip) üzerinden indirilebilir
{{% /alert %}}