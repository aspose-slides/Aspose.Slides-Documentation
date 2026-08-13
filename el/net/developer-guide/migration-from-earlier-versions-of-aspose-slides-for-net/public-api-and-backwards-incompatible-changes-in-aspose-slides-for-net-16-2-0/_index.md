---
title: Δημόσιο API και Ασυμβατότητες Πίσω σε Aspose.Slides για .NET 16.2.0
linktitle: Aspose.Slides για .NET 16.2.0
type: docs
weight: 230
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- μεταναστευση
- παλαιος κωδικας
- συχρονις κωδικας
- παλαια προσεγγιση
- συγχρονη προσεγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των ανατρεπτικών αλλαγών στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP σας."
---
{{% alert color="info" %}} 
Αυτή η σελίδα απαριθμεί όλες τις [added](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) ή [removed](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) κλάσεις, μεθόδους, ιδιότητες κλπ., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for .NET 16.2.0 API.
{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
#### **Οι ιδιότητες UpdateDateTimeFields και UpdateSlideNumberFields έχουν αφαιρεθεί**
Οι ιδιότητες UpdateDateTimeFields και UpdateSlideNumberFields έχουν αφαιρεθεί από την κλάση Aspose.Slides.Presentation και από την διεπαφή Aspose.Slides.IPresentation. Η ιδιότητα Text των κλάσεων Aspose.Slides.TextFrame, Paragraph, Portion και των διεπαφών Aspose.Slides.ITextFrame, IParagraph, IPortion επιστρέφει κείμενο με ενημερωμένα πεδία «datetime». Επίσης, οι ιδιότητες Presentation.DocumentProperties.CreatedTime, LastSavedTime και LastPrinted έχουν γίνει μόνο ανάγνωση.
#### **Η απαρίθμηση Slides.Charts.CategoryAxisType έχει γίνει δημόσια**
Χρησιμοποιείται στις ιδιότητες IAxis.CategoryAxisType και Axis.CategoryAxisType για τον καθορισμό του τύπου του άξονα κατηγορίας.  
CategoryAxisType.Auto – ο τύπος του άξονα κατηγορίας θα καθορίζεται αυτόματα κατά τη σειριοποίηση (αυτή η συμπεριφορά δεν έχει υλοποιηθεί ακόμα)  
CategoryAxisType.Text – ο τύπος του άξονα κατηγορίας είναι Text  
CategoryAxisType.Date – ο τύπος του άξονα κατηγορίας είναι DateTime
#### **Γρήγορη Εξαγωγή Κειμένου**
Η νέα στατική μέθοδος GetPresentationText προστέθηκε στην κλάση Presentation. Υπάρχουν δύο υπερφορτώσεις για αυτή τη μέθοδο:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Το όρισμα enum ExtractionMode υποδεικνύει τον τρόπο οργάνωσης του αποτελέσματος κειμένου και μπορεί να οριστεί στις ακόλουθες τιμές:  
Unarranged – το ακατέργαστο κείμενο χωρίς σεβασμό στη θέση στη διαφάνεια  
Arranged – το κείμενο τοποθετείται με την ίδια σειρά όπως στην διαφάνεια  

Η λειτουργία Unarranged μπορεί να χρησιμοποιηθεί όταν η ταχύτητα είναι κρίσιμη· είναι ταχύτερη από τη λειτουργία Arranged.

Το PresentationText αντιπροσωπεύει το ακατέργαστο κείμενο που εξήχθη από την παρουσίαση. Περιέχει μια ιδιότητα SlidesText από το namespace Aspose.Slides.Util που επιστρέφει έναν πίνακα αντικειμένων ISlideText. Κάθε αντικείμενο αντιπροσωπεύει το κείμενο της αντίστοιχης διαφάνειας. Το αντικείμενο ISlideText έχει τις παρακάτω ιδιότητες:

ISlideText.Text – Το κείμενο των σχημάτων της διαφάνειας  
ISlideText.MasterText – Το κείμενο των σχημάτων της κύριας σελίδας για αυτή τη διαφάνεια  
ISlideText.LayoutText – Το κείμενο των σχημάτων της σελίδας διάταξης για αυτή τη διαφάνεια  
ISlideText.NotesText – Το κείμενο των σχημάτων της σελίδας σημειώσεων για αυτή τη διαφάνεια  

Υπάρχει επίσης η κλάση SlideText που υλοποιεί τη διεπαφή ISlideText.

Το νέο API μπορεί να χρησιμοποιηθεί ως εξής:

``` csharp
using System;
using Aspose.Slides;

// Εξάγετε το κείμενο χωρίς να λαμβάνεται υπόψη η θέση του στη διαφάνεια (η πιο γρήγορη λειτουργία).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Εξάγετε το κείμενο τοποθετημένο στην ίδια σειρά όπως στη διαφάνεια.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **Προστέθηκε η διεπαφή ILegacyDiagram και η κλάση LegacyDiagram**
Η διεπαφή Aspose.Slides.ILegacyDiagram και η κλάση Aspose.Slides.LegacyDiagram προστέθηκαν για την αναπαράσταση αντικειμένου παλαιού διαγράμματος. Το αντικείμενο LegacyDiagram είναι μια παλαιά μορφή διαγραμμάτων από το PowerPoint 97‑2003. Η νέα κλάση παρέχει μεθόδους για τη μετατροπή του παλαιού διαγράμματος σε σύγχρονο επεξεργάσιμο αντικείμενο SmartArt ή σε επεξεργάσιμο GroupShape.
#### **Προστέθηκε νέο μέλος στην απαρίθμηση Aspose.Slides.TextAlignment (JustifyLow)**
Προστέθηκε νέο μέλος στην απαρίθμηση TextAlignment:  
JustifyLow – εξίσωση κειμένου με χαμηλό Kashida.
#### **Νέες Ιδιότητες για Aspose.Slides.IOleObjectFrame και OleObjectFrame**
Προστέθηκαν νέες ιδιότητες στη διεπαφή IOleObjectFrame και στην κλάση OleObjectFrame που την υλοποιεί. Αυτές οι ιδιότητες χρησιμοποιούνται για την παροχή πληροφοριών σχετικά με ένα αντικείμενο ενσωματωμένο στην παρουσίαση:  
EmbeddedFileExtension – Επιστρέφει την επέκταση αρχείου του τρέχοντος ενσωματωμένου αντικειμένου ή κενό string αν το αντικείμενο δεν είναι σύνδεσμος  
EmbeddedFileLabel – Επιστρέφει το όνομα αρχείου του ενσωματωμένου αντικειμένου OLE  
EmbeddedFileName – Επιστρέφει τη διαδρομή του ενσωματωμένου αντικειμένου OLE
#### **Προστέθηκε η ιδιότητα CategoryAxisType στις κλάσεις IAxis και Axis**
Η ιδιότητα CategoryAxisType προσδιορίζει τον τύπο του άξονα κατηγορίας.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

using (Presentation pres = new Presentation(sourcePptxFileName))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;

    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

    pres.Save(pptxOutPath, SaveFormat.Pptx);
}
``` 
#### **Προστέθηκε η ιδιότητα ShowLabelAsDataCallout στην κλάση DataLabelFormat και στη διεπαφή IDataLabelFormat**
Η ιδιότητα ShowLabelAsDataCallout καθορίζει εάν η ετικέτα δεδομένων του συγκεκριμένου γραφήματος θα εμφανιστεί ως κλήση δεδομένων ή ως ετικέτα δεδομένων.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

    pres.Save(pptxFileName, SaveFormat.Pptx);
}
``` 
#### **Προστέθηκε η ιδιότητα DrawSlidesFrame στις κλάσεις PdfOptions και XpsOptions**
Η λογική ιδιότητα DrawSlidesFrame προστέθηκε στις διεπαφές Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions και στις αντίστοιχες κλάσεις Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions. Το μαύρο πλαίσιο γύρω από κάθε διαφάνεια θα σχεδιάζεται εάν αυτή η ιδιότητα οριστεί σε «true».

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```