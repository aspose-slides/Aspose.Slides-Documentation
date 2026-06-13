---
title: ReportViewer 2010 및 2012와 Aspose.Slides 사용
type: docs
weight: 80
url: /ko/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}}
이 문서는 ReportViewer 2010/2012에서 보고서를 PowerPoint 프레젠테이션으로 내보내는 방법을 알려줍니다.
{{% /alert %}}

RplRenderer 클래스는 [보고서 페이지 레이아웃(RPL) 이진 스트림 형식](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887)을 PowerPoint 프레젠테이션으로 렌더링합니다.

{{% alert color="primary" %}}
RplRenderer는 [소프트 페이지 구분](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs)를 사용하여 페이지 크기를 제어하기 위해 InteractiveHeight 및 InteractiveWidth RDL 태그를 사용합니다.
{{% /alert %}}

## **샘플 코드**
이 코드는 RplRenderer를 사용하여 ReportViewer 2010/2012에서 보고서를 PPT/PPTX로 내보내는 방법을 보여줍니다. RenderToPpt 메서드를 실행하여 현재 보고서를 PPT로 렌더링합니다.

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

        /// 현재 보고서를 PowerPoint 프레젠테이션으로 렌더링합니다

        /// </summary>

        /// <param name="reportViewer">보고서 뷰어 객체.</param>

        /// <param name="format">출력 프레젠테이션 형식.</param>

        /// <param name="filename">출력 파일 이름.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //RPL 기능 내보내기 활성화

            EnableRplRenderExtension(reportViewer);

            //프레젠테이션 파일 생성

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //렌더링 프로세스 시작

                //여기서 PPT 형식으로 내보내고 outputStream을 제공합니다

                renderer.StartRendering(format);

                int page = 1;

                //이 반복은 보고서의 모든 페이지를 순회합니다

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //rplStream이 비어 있으면 보고서의 끝에 도달한 것입니다

                        if (rplStream.Length == 0)

                            break;

                        //보고서 페이지를 슬라이드로 문서에 추가합니다

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //finish 메서드를 호출하여 새로 만든 프레젠테이션을 출력 스트림에 플러시합니다

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// RPL 렌더링 확장을 활성화합니다.

        /// 주의: 이 메서드는 ReportViewer 클래스 인스턴스의 내부 상태를 변경합니다

        /// 그리고 이 메서드가 향후 버전의 ReportViewer와 작동한다는 보장은 없습니다

        /// </summary>

        /// <param name="reportViewer">보고서 뷰어.</param>

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

        /// 특정 페이지를 RPL로 렌더링합니다

        /// </summary>

        /// <param name="reportViewer">보고서 뷰어.</param>

        /// <param name="page">페이지 번호.</param>

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
## **Windows Forms에서 사용**
ReportViewer의 ToolStripPanel에 Export 버튼을 추가하려면 Form 생성자에 다음 코드를 추가하십시오:

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
- 샘플 프로젝트는 [이 링크](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)에서 다운로드할 수 있습니다.
- 샘플 웹폼 프로젝트는 [이 링크](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)에서 다운로드할 수 있습니다.
{{% /alert %}}