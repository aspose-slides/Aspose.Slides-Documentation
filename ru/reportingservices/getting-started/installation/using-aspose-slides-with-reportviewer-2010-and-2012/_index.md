---
title: Использование Aspose.Slides с ReportViewer 2010 и 2012
type: docs
weight: 80
url: /ru/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 

Эта статья научит вас, как экспортировать отчеты из ReportViewer 2010/2012 в презентацию PowerPoint﻿.

{{% /alert %}} 

Класс RplRenderer отображает [файл двоичного потока макета страницы отчета (RPL)](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) в презентацию PowerPoint.

{{% alert color="primary" %}} 

RplRenderer использует [мягкие разрывы страниц](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) для управления размером страницы, используя теги RDL InteractiveHeight и InteractiveWidth.

{{% /alert %}} 
## **Пример кода**
Этот код покажет, как экспортировать отчет из ReportViewer 2010/2012 в PPT/PPTX с использованием RplRenderer. Выполните метод RenderToPpt, чтобы отобразить текущий отчет в PPT.

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

        /// Отображает текущий отчет в презентации Powerpoint

        /// </summary>

        /// <param name="reportViewer">Объект просмотра отчетов.</param>

        /// <param name="format">Формат выходной презентации.</param>

        /// <param name="filename">Имя выходного файла.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Включить функцию экспорта в RPL

            EnableRplRenderExtension(reportViewer);

            //создать файл для нашей презентации

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //начать процесс рендеринга

                //здесь мы выбираем экспорт в формате PPT и предоставляем outputStream

                renderer.StartRendering(format);

                int page = 1;

                //этот цикл проходит через все страницы отчета

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //если rplStream пуст, значит, мы достигли конца отчета

                        if (rplStream.Length == 0)

                            break;

                        //добавить страницу отчета как слайд в документ

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //вызовите метод finish, чтобы сбросить нашу новую презентацию в выходной поток

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Включает расширение рендеринга RPL.

        /// Будьте осторожны, потому что этот метод изменяет внутреннее состояние экземпляра класса ReportViewer

        /// и нет гарантии, что этот метод будет работать с будущими версиями ReportViewer

        /// </summary>

        /// <param name="reportViewer">Просмотр отчетов.</param>

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

                throw new Exception("Не удается включить экспорт RPL. Убедитесь, что вы используете ReportViewer 2010 или ReportViewer 2012.");

        }



        /// <summary>

        /// Отображает конкретную страницу в RPL

        /// </summary>

        /// <param name="reportViewer">Просмотр отчетов.</param>

        /// <param name="page">Страница.</param>

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
## **Использование в Windows Forms**
Вы можете добавить кнопки экспорта на панель инструментов ReportViewer, добавив этот код в конструктор формы:

[**C#**]()

``` xml



ToolStrip toolStrip = (ToolStrip) reportViewer.Controls.Find("toolStrip1", true)[0];



            ToolStripItem exportButton = toolStrip.Items.Add("Экспорт в Pptx");

            exportButton.Click += new EventHandler((s,e) =>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                                     OutputPresentationFormat.Pptx,

                                                                                                     "SalesReport.pptx");

                                                       });



            exportButton = toolStrip.Items.Add("Экспорт в Ppt");

            exportButton.Click += new EventHandler((s,e)=>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                              OutputPresentationFormat.Ppt,

                                                                                              "SalesReport.ppt");

                                                       });


```

{{% alert color="primary" %}} 

- Пример проекта можно скачать по [этой ссылке ](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- Пример проекта веб-форм можно скачать по [этой ссылке](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)

{{% /alert %}}