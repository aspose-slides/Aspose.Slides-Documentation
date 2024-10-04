---
title: Usando Aspose.Slides con ReportViewer 2010 y 2012
type: docs
weight: 80
url: /reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

﻿

{{% alert color="primary" %}} 

Este artículo te enseña cómo exportar informes desde ReportViewer 2010/2012 a una presentación de PowerPoint﻿.

{{% /alert %}} 

La clase RplRenderer renderiza [Formato de transmisión binaria de diseño de página de informes (RPL)](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) a una presentación de PowerPoint.

{{% alert color="primary" %}} 

RplRenderer utiliza [saltos de página suaves](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) para controlar el tamaño de la página utilizando etiquetas RDL de InteractiveHeight e InteractiveWidth.

{{% /alert %}} 
## **Código de ejemplo**
Este código mostrará cómo exportar un informe desde ReportViewer 2010/2012 a PPT/PPTX usando RplRenderer. Ejecuta el método RenderToPpt para renderizar un informe actual en PPT.

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

        /// Renderiza el informe actual a una presentación de PowerPoint

        /// </summary>

        /// <param name="reportViewer">El objeto del visor de informes.</param>

        /// <param name="format">El formato de presentación de salida.</param>

        /// <param name="filename">El nombre del archivo de salida.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Habilitar la función de exportación a RPL

            EnableRplRenderExtension(reportViewer);

            //crear archivo para nuestra presentación

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //iniciar proceso de renderizado

                //aquí estamos eligiendo exportar en formato PPT y proporcionando outputStream

                renderer.StartRendering(format);

                int page = 1;

                //este ciclo itera a través de todas las páginas del informe

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //si rplStream está vacío entonces hemos llegado al final del informe

                        if (rplStream.Length == 0)

                            break;

                        //agregar página del informe como diapositiva al documento

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //llamar al método finish para vaciar nuestra presentación recién creada al flujo de salida

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Habilita la extensión de renderizado RPL.

        /// Ten cuidado porque este método altera el estado interno de la instancia de la clase ReportViewer

        /// y no hay garantía de que este método funcione con futuras versiones de ReportViewer

        /// </summary>

        /// <param name="reportViewer">El visor de informes.</param>

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

                throw new Exception("No se puede habilitar la exportación RPL. Por favor, asegúrate de que estás usando ReportViewer 2010 o ReportViewer 2012.");

        }



        /// <summary>

        /// Renderiza una página específica a RPL

        /// </summary>

        /// <param name="reportViewer">El visor de informes.</param>

        /// <param name="page">La página.</param>

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
## **Uso desde Windows Forms**
Es posible que desees agregar botones de Exportar al TollStripPanel de ReportViewer agregando este código al constructor del Formulario:

[**C#**]()

``` xml



ToolStrip toolStrip = (ToolStrip) reportViewer.Controls.Find("toolStrip1", true)[0];




            ToolStripItem exportButton = toolStrip.Items.Add("Exportar a Pptx");

            exportButton.Click += new EventHandler((s,e) =>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                                     OutputPresentationFormat.Pptx,

                                                                                                     "SalesReport.pptx");

                                                       });



            exportButton = toolStrip.Items.Add("Exportar a Ppt");

            exportButton.Click += new EventHandler((s,e)=>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                              OutputPresentationFormat.Ppt,

                                                                                              "SalesReport.ppt");

                                                       });


```

{{% alert color="primary" %}} 

- El proyecto de muestra se puede descargar desde [este enlace](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- El proyecto de formulario web de muestra se puede descargar desde [este enlace](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)

{{% /alert %}}