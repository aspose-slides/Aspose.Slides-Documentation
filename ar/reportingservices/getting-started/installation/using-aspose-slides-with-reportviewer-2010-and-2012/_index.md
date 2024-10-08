---
title: استخدام Aspose.Slides مع ReportViewer 2010 و 2012
type: docs
weight: 80
url: /ar/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

﻿

{{% alert color="primary" %}} 

تعلّمك هذه المقالة كيفية تصدير التقارير من ReportViewer 2010/2012 إلى عرض تقديمي PowerPoint﻿.

{{% /alert %}} 

صفِّة RplRenderer تقوم برسم [تخطيط صفحة التقرير (RPL) تنسيق تيار ثنائي](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) إلى عرض تقديمي PowerPoint.

{{% alert color="primary" %}} 

تستخدم RplRenderer [فواصل الصفحات الناعمة](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) للتحكم في حجم الصفحة باستخدام علامات RDL InteractiveHeight و InteractiveWidth.

{{% /alert %}} 
## **عينة من الكود**
سيظهر هذا الكود كيفية تصدير تقرير من ReportViewer 2010/2012 إلى PPT/PPTX باستخدام RplRenderer. نفّذ أسلوب RenderToPpt لرسم تقرير حالي إلى PPT.

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

        /// يرسم التقرير الحالي إلى عرض تقديمي PowerPoint

        /// </summary>

        /// <param name="reportViewer">كائن عارض التقرير.</param>

        /// <param name="format">تنسيق العرض التقديمي الناتج.</param>

        /// <param name="filename">اسم الملف الناتج.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //تمكين ميزة التصدير إلى RPL

            EnableRplRenderExtension(reportViewer);

            //إنشاء ملف لعرضنا التقديمي

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //بدء عملية الرسم

                //هنا نختار تصدير بتنسيق PPT وتوفير outputStream

                renderer.StartRendering(format);

                int page = 1;

                //تكرار هذه الدورة عبر جميع صفحات التقرير

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //إذا كان rplStream فارغًا فنحن قد وصلنا إلى نهاية التقرير

                        if (rplStream.Length == 0)

                            break;

                        //إضافة صفحة التقرير كشريحة إلى الوثيقة

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //استدعاء أسلوب الانتهاء لضخ عرضنا التقديمي الجديد إلى تيار الإخراج

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// يمكّن امتداد رسم RPL.

        /// كن حذرًا لأن هذه الطريقة تلحق الضرر بالحالة الداخلية لنسخة كائن ReportViewer

        /// وليس هناك ضمان أن هذه الطريقة ستعمل مع الإصدارات المستقبلية من ReportViewer

        /// </summary>

        /// <param name="reportViewer">عارض التقرير.</param>

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

                throw new Exception("لا يمكن تمكين تصدير RPL. يرجى التأكد من أنك تستخدم ReportViewer 2010 أو ReportViewer 2012.");

        }



        /// <summary>

        /// يرسم صفحة معينة إلى RPL

        /// </summary>

        /// <param name="reportViewer">عارض التقرير.</param>

        /// <param name="page">الصفحة.</param>

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
## **الاستخدام من نوافذ النماذج**
قد ترغب في إضافة أزرار تصدير إلى TollStripPanel الخاص بـ ReportViewer عن طريق إضافة هذا الكود إلى مُنشئ الـ Form:

[**C#**]()

``` xml



ToolStrip toolStrip = (ToolStrip) reportViewer.Controls.Find("toolStrip1", true)[0];



            ToolStripItem exportButton = toolStrip.Items.Add("تصدير إلى Pptx");

            exportButton.Click += new EventHandler((s,e) =>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                                     OutputPresentationFormat.Pptx,

                                                                                                     "SalesReport.pptx");

                                                       });
 


            exportButton = toolStrip.Items.Add("تصدير إلى Ppt");

            exportButton.Click += new EventHandler((s,e)=>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                              OutputPresentationFormat.Ppt,

                                                                                              "SalesReport.ppt");

                                                       });


```

{{% alert color="primary" %}} 

- يمكن تنزيل مشروع العينة من [هذا الرابط](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- يمكن تنزيل مشروع نموذج الويب من [هذا الرابط](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)

{{% /alert %}}