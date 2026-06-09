---
title: Usando Aspose.Slides com ReportViewer 2010 e 2012
type: docs
weight: 80
url: /pt/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
Este artigo ensina como exportar relatórios do ReportViewer 2010/2012 para uma apresentação PowerPoint.
{{% /alert %}} 

A classe RplRenderer renderiza o [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) para uma apresentação PowerPoint. 

{{% alert color="primary" %}} 
O RplRenderer usa [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) para controlar o tamanho da página usando as tags RDL InteractiveHeight e InteractiveWidth. 
{{% /alert %}} 

## **Código de Exemplo**
Este código mostrará como exportar um relatório do ReportViewer 2010/2012 para PPT/PPTX usando o RplRenderer. Execute o método RenderToPpt para renderizar o relatório atual para PPT.

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

        /// Renderiza o relatório atual para uma apresentação PowerPoint

        /// </summary>

        /// <param name="reportViewer">O objeto do visualizador de relatório.</param>

        /// <param name="format">O formato de apresentação de saída.</param>

        /// <param name="filename">O nome do arquivo de saída.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Habilita o recurso de exportação para RPL

            EnableRplRenderExtension(reportViewer);

            //cria o arquivo para nossa apresentação

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //inicia o processo de renderização

                //aqui estamos escolhendo exportar no formato PPT e fornecendo outputStream

                renderer.StartRendering(format);

                int page = 1;

                //este ciclo itera por todas as páginas do relatório

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //se rplStream estiver vazio, então chegamos ao fim do relatório

                        if (rplStream.Length == 0)

                            break;

                        //adiciona a página do relatório como slide ao documento

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //chama o método finish para gravar nossa apresentação recém-criada no fluxo de saída

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Habilita a extensão de renderização RPL.

        /// Tenha cuidado porque este método altera o estado interno da instância da classe ReportViewer

        /// e não há garantia de que este método funcionará com versões futuras do ReportViewer

        /// </summary>

        /// <param name="reportViewer">O visualizador de relatório.</param>

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

        /// Renderiza uma página específica para RPL

        /// </summary>

        /// <param name="reportViewer">O visualizador de relatório.</param>

        /// <param name="page">A página.</param>

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
## **Usando em Windows Forms**
Você pode querer adicionar botões de Exportação ao TollStripPanel do ReportViewer adicionando este código ao construtor do Formulário:

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
- O projeto de exemplo pode ser baixado de [este link](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- O projeto webform de exemplo pode ser baixado de [este link](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)
{{% /alert %}}