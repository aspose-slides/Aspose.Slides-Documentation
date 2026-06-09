---
title: Χρήση Aspose.Slides με ReportViewer 2010 και 2012
type: docs
weight: 80
url: /el/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/
---

{{% alert color="primary" %}} 
Αυτό το άρθρο σας δείχνει πώς να εξάγετε αναφορές από το ReportViewer 2010/2012 σε παρουσίαση PowerPoint.
{{% /alert %}} 

Η κλάση RplRenderer αποδίδει το [Report Page Layout (RPL) Binary Stream Format](https://docs.microsoft.com/en-us/openspecs/sql_server_protocols/ms-rpl/9c4ff7ba-f6da-4092-9670-aa0e54e73887) σε παρουσίαση PowerPoint. 

{{% alert color="primary" %}} 
Η RplRenderer χρησιμοποιεί [soft page breaks](https://docs.microsoft.com/en-us/sql/reporting-services/report-design/rendering-behaviors-report-builder-and-ssrs) για να ελέγχει το μέγεθος της σελίδας, χρησιμοποιώντας τις ετικέτες RDL InteractiveHeight και InteractiveWidth.
{{% /alert %}} 
## **Παράδειγμα Κώδικα**
Αυτός ο κώδικας δείχνει πώς να εξάγετε μια αναφορά από το ReportViewer 2010/2012 σε PPT/PPTX χρησιμοποιώντας το RplRenderer. Εκτελέστε τη μέθοδο RenderToPpt για να αποδώσετε την τρέχουσα αναφορά σε PPT.

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

        /// Αποδίδει την τρέχουσα αναφορά σε παρουσίαση PowerPoint

        /// </summary>

        /// <param name="reportViewer">Το αντικείμενο προβολέα αναφοράς.</param>

        /// <param name="format">Η μορφή εξόδου της παρουσίασης.</param>

        /// <param name="filename">Το όνομα αρχείου εξόδου.</param>

        public static void RenderWithAsposeSlides(ReportViewer reportViewer, Aspose.Slides.ReportingServices.OutputPresentationFormat format, string filename)

        {

            //Ενεργοποίηση δυνατότητας εξαγωγής σε RPL

            EnableRplRenderExtension(reportViewer);

            //Δημιουργία αρχείου για την παρουσίασή μας

            using (FileStream pptSteam = new FileStream(filename, FileMode.Create))

            {

                Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

                //Έναρξη διαδικασίας απόδοσης

                //Εδώ επιλέγουμε εξαγωγή σε μορφή PPT και παρέχουμε το outputStream

                renderer.StartRendering(format);

                int page = 1;

                //Αυτός ο βρόχος επαναλαμβάνεται για όλες τις σελίδες της αναφοράς

                while (true)

                {

                    using (MemoryStream rplStream = CreateRplStream(reportViewer, page))

                    {

                        //Αν το rplStream είναι κενό, τότε έχουμε φτάσει στο τέλος της αναφοράς

                        if (rplStream.Length == 0)

                            break;

                        //Προσθέτει τη σελίδα της αναφοράς ως διαφάνεια στο έγγραφο

                        renderer.RenderPage(rplStream);

                    }

                    page++;

                }

                //Καλεί τη μέθοδο FinishRendering για να αποθηκεύσει τη νέα παρουσίαση στο output stream

                renderer.FinishRendering(pptSteam);

            }

        }

        /// <summary>

        /// Ενεργοποιεί την επέκταση απόδοσης RPL.

        /// Να είστε προσεκτικοί, διότι αυτή η μέθοδος τροποποιεί την εσωτερική κατάσταση της κλάσης ReportViewer και δεν υπάρχει καμία εγγύηση ότι θα λειτουργήσει με μελλοντικές εκδόσεις του ReportViewer

        /// </summary>

        /// <param name="reportViewer">Ο προβολέας αναφοράς.</param>

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

        /// Αποδίδει συγκεκριμένη σελίδα σε RPL

        /// </summary>

        /// <param name="reportViewer">Ο προβολέας αναφοράς.</param>

        /// <param name="page">Η σελίδα.</param>

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
## **Χρήση από Windows Forms**
Μπορείτε να θέλετε να προσθέσετε κουμπιά Εξαγωγής στο TollStripPanel του ReportViewer προσθέτοντας αυτόν τον κώδικα στον κατασκευαστή της Φόρμας:

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
- Το δείγμα έργου μπορεί να ληφθεί από [this link ](http://www.aspose.com/docs/download/attachments/24150112/Slides.ReportViewer2010.zip)
- Το δείγμα έργου webform μπορεί να ληφθεί από [this link](http://www.aspose.com/docs/download/attachments/24150112/Report+ Viewer+WebForm.zip)
{{% /alert %}}