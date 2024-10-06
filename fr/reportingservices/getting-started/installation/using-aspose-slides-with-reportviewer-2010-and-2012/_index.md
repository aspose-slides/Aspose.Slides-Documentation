---
title: Utilisation d'Aspose.Slides avec ReportViewer 2010 et 2012
type: docs
weight: 80
url: /reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

﻿ 

{{% alert color="primary" %}} 

Cet article vous enseigne comment exporter des rapports depuis ReportViewer 2010/2012 vers une présentation PowerPoint﻿.

{{% /alert %}} 

La classe RplRenderer rend le [Format de flux binaire de mise en page de rapport (RPL)](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) en présentation PowerPoint. 

{{% alert color="primary" %}} 

RplRenderer utilise [des sauts de page doux](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) pour contrôler la taille des pages en utilisant les balises InteractiveHeight et InteractiveWidth RDL. 

{{% /alert %}} 
## **Code Exemple**
Ce code montre comment exporter un rapport depuis ReportViewer 2010/2012 vers PPT/PPTX en utilisant RplRenderer. Exécutez la méthode RenderToPpt pour rendre un rapport actuel en PPT.

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

        /// Rends le rapport actuel en présentation PowerPoint

        /// </summary>

        /// <param name="reportViewer">L'objet viewer de rapport.</param>

        /// <param name="format">Le format de présentation de sortie.</param>

        /// <param name="filename">Le nom du fichier de sortie.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Activer la fonction d'exportation vers RPL

            EnableRplRenderExtension(reportViewer);

            //créer un fichier pour notre présentation

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //démarrer le processus de rendu

                //ici nous choisissons d'exporter au format PPT et fournissons outputStream

                renderer.StartRendering(format);

                int page = 1;

                //ce cycle itère à travers toutes les pages du rapport

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //si rplStream est vide, nous avons atteint la fin du rapport

                        if (rplStream.Length == 0)

                            break;

                        //ajouter la page de rapport en tant que diapositive au document

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //appeler la méthode finish pour vider notre nouvelle présentation dans le flux de sortie

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Active l'extension de rendu RPL.

        /// Faites attention car cette méthode modifie l'état interne de l'instance de la classe ReportViewer

        /// et il n'y a aucune garantie que cette méthode fonctionnera avec les versions futures de ReportViewer

        /// </summary>

        /// <param name="reportViewer">Le viewer de rapport.</param>

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

                throw new Exception("Impossible d'activer l'exportation RPL. Veuillez vous assurer que vous utilisez ReportViewer 2010 ou ReportViewer 2012.");

        }



        /// <summary>

        /// Rends une page spécifique en RPL

        /// </summary>

        /// <param name="reportViewer">Le viewer de rapport.</param>

        /// <param name="page">La page.</param>

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
## **Utilisation depuis Windows Forms**
Vous pourriez vouloir ajouter des boutons d'exportation au TollStripPanel de ReportViewer en ajoutant ce code au constructeur du Formulaire :

[**C#**]()

``` xml



ToolStrip toolStrip = (ToolStrip) reportViewer.Controls.Find("toolStrip1", true)[0];



            ToolStripItem exportButton = toolStrip.Items.Add("Exporter vers Pptx");

            exportButton.Click += new EventHandler((s,e) =>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                                     OutputPresentationFormat.Pptx,

                                                                                                     "SalesReport.pptx");

                                                       });



            exportButton = toolStrip.Items.Add("Exporter vers Ppt");

            exportButton.Click += new EventHandler((s,e)=>

                                                       {

                                                           SlidesExportHelper.RenderWithAsposeSlides(this.reportViewer,

                                                                                              OutputPresentationFormat.Ppt,

                                                                                              "SalesReport.ppt");

                                                       });


```

{{% alert color="primary" %}} 

- Le projet d'exemple peut être téléchargé à partir de [ce lien](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- Le projet webform d'exemple peut être téléchargé à partir de [ce lien](http://www.aspose.com/docs/download/attachments/24150112/Report+Viewer+WebForm.zip)

{{% /alert %}}