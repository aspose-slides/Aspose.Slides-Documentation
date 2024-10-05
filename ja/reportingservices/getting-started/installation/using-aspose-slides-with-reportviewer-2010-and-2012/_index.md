---
title: ReportViewer 2010および2012でAspose.Slidesを使用する
type: docs
weight: 80
url: /reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 

この記事では、ReportViewer 2010/2012からPowerPointプレゼンテーションにレポートをエクスポートする方法について説明します。

{{% /alert %}} 

RplRendererクラスは、[Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887)をPowerPointプレゼンテーションにレンダリングします。 

{{% alert color="primary" %}} 

RplRendererは、[ソフトページブレーク](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs)を使用してページサイズを制御し、InteractiveHeightおよびInteractiveWidth RDLタグを使用します。

{{% /alert %}} 
## **サンプルコード**
このコードは、RplRendererを使用してReportViewer 2010/2012からPPT/PPTXにレポートをエクスポートする方法を示します。 RenderToPptメソッドを実行して、現在のレポートをPPTにレンダリングします。

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

        /// 現在のレポートをPowerPointプレゼンテーションにレンダリングします。

        /// </summary>

        /// <param name="reportViewer">レポートビューワーオブジェクト。</param>

        /// <param name="format">出力プレゼンテーションフォーマット。</param>

        /// <param name="filename">出力ファイル名。</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //RPLエクスポート機能を有効にする

            EnableRplRenderExtension(reportViewer);

            //プレゼンテーション用のファイルを作成

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //レンダリングプロセスを開始

                //ここでPPT形式でエクスポートし、outputStreamを提供します。

                renderer.StartRendering(format);

                int page = 1;

                //このループはレポートのすべてのページを繰り返します。

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //rplStreamが空であれば、レポートの終わりに達しました。

                        if (rplStream.Length == 0)

                            break;

                        //レポートページをスライドとしてドキュメントに追加

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //新しく作成したプレゼンテーションを出力ストリームにフラッシュするためにfinishメソッドを呼び出す

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// RPLレンダリング拡張を有効にします。

        /// このメソッドはReportViewerクラスインスタンスの内部状態を変更するため注意が必要です。

        /// このメソッドが将来のバージョンのReportViewerで動作する保証はありません。

        /// </summary>

        /// <param name="reportViewer">レポートビューワー。</param>

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

                throw new Exception("RPLエクスポートを有効にできません。ReportViewer 2010またはReportViewer 2012を使用していることを確認してください。");

        }



        /// <summary>

        /// 特定のページをRPLにレンダリングします。

        /// </summary>

        /// <param name="reportViewer">レポートビューワー。</param>

        /// <param name="page">ページ。</param>

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
## **Windowsフォームからの使用**
フォームのコンストラクタにこのコードを追加して、ReportViewerのToolStripPanelにエクスポートボタンを追加することができます。

[**C#**]()

``` xml



ToolStrip toolStrip = (ToolStrip) reportViewer.Controls.Find("toolStrip1", true)[0];




            ToolStripItem exportButton = toolStrip.Items.Add("Pptxにエクスポート");

            exportButton.Click += new EventHandler((s,e) =>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                                     OutputPresentationFormat.Pptx,

                                                                                                     "SalesReport.pptx");

                                                       });




            exportButton = toolStrip.Items.Add("Pptにエクスポート");

            exportButton.Click += new EventHandler((s,e)=>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                              OutputPresentationFormat.Ppt,

                                                                                              "SalesReport.ppt");

                                                       });


```

{{% alert color="primary" %}} 

- サンプルプロジェクトは[このリンク](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)からダウンロードできます。
- サンプルWebフォームプロジェクトは[このリンク](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)からダウンロードできます。

{{% /alert %}}