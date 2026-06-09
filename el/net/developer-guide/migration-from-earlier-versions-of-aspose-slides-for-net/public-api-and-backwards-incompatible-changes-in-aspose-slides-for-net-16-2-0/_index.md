---
title: Δημόσιο API και Αλλαγές που Ασυμβατότησαν στο Aspose.Slides για .NET 16.2.0
linktitle: Aspose.Slides για .NET 16.2.0
type: docs
weight: 230
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- μετανάστευση
- παλιός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των αλλαγών που διακοπίζουν τη συμβατότητα στο Aspose.Slides για .NET για ομαλή μετεγκατάσταση των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλες τις [προστιθέμενες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) ή [αφαιρεθείσες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides for .NET 16.2.0.

{{% /alert %}} 
## **Δημόσιες Αλλαγές API**
#### **Οι ιδιότητες UpdateDateTimeFields και UpdateSlideNumberFields έχουν αφαιρεθεί**
Οι ιδιότητες UpdateDateTimeFields και UpdateSlideNumberFields έχουν αφαιρεθεί από την κλάση Aspose.Slides.Presentation και από το διεπαφή Aspose.Slides.IPresentation.
Η ιδιότητα Text των κλάσεων Aspose.Slides.TextFrame, Paragraph, Portion και των διεπαφών Aspose.Slides.ITextFrame, IParagraph, IPortion επιστρέφει κείμενο με ενημερωμένα πεδία "datetime".
Επιπλέον, οι ιδιότητες Presentation.DocumentProperties.CreatedTime, LastSavedTime και LastPrinted έγιναν μόνο για ανάγνωση.
#### **Η Enum Slides.Charts.CategoryAxisType έχει γίνει δημόσια**
Χρησιμοποιείται στις ιδιότητες IAxis.CategoryAxisType και Axis.CategoryAxisType για τον καθορισμό του τύπου του άξονα κατηγορίας.
CategoryAxisType.Auto - ο τύπος άξονα κατηγορίας θα καθορίζεται αυτόματα κατά τη σειρά (αυτή η συμπεριφορά δεν έχει υλοποιηθεί ακόμη)
CategoryAxisType.Text - ο τύπος άξονα κατηγορίας είναι Text
CategoryAxisType.Date - ο τύπος άξονα κατηγορίας είναι DateTime
#### **Γρήγορη Εξαγωγή Κειμένου**
Η νέα στατική μέθοδος GetPresentationText προστέθηκε στην κλάση Presentation. Υπάρχουν δύο υπερφορτώσεις για αυτή τη μέθοδο:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Το όρισμα enum ExtractionMode υποδεικνύει τη λειτουργία οργάνωσης της εξόδου του κειμένου και μπορεί να οριστεί στις ακόλουθες τιμές:
Unarranged - Το ακατέργαστο κείμενο χωρίς σεβασμό στη θέση στη διαφάνεια
Arranged - Το κείμενο τοποθετείται στην ίδια σειρά όπως στην διαφάνεια

Η λειτουργία Unarranged μπορεί να χρησιμοποιηθεί όταν η ταχύτητα είναι κρίσιμη· είναι πιο γρήγορη από τη λειτουργία Arranged.

Το PresentationText αντιπροσωπεύει το ακατέργαστο κείμενο που εξάγεται από την παρουσίαση. Περιλαμβάνει την ιδιότητα SlidesText από το χώρο ονομάτων Aspose.Slides.Util, η οποία επιστρέφει έναν πίνακα αντικειμένων ISlideText. Κάθε αντικείμενο αντιπροσωπεύει το κείμενο στην αντίστοιχη διαφάνεια. Τα αντικείμενα ISlideText έχουν τις ακόλουθες ιδιότητες:
ISlideText.Text - Το κείμενο στα σχήματα της διαφάνειας
ISlideText.MasterText - Το κείμενο στα σχήματα της κεφαλίδας (master page) για αυτή τη διαφάνεια
ISlideText.LayoutText - Το κείμενο στα σχήματα της σελίδας διάταξης για αυτή τη διαφάνεια
ISlideText.NotesText - Το κείμενο στα σχήματα της σελίδας σημειώσεων για αυτή τη διαφάνεια

Υπάρχει επίσης η κλάση SlideText που υλοποιεί τη διεπαφή ISlideText.

Το νέο API μπορεί να χρησιμοποιηθεί ως εξής:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Προστέθηκαν η διεπαφή ILegacyDiagram και η κλάση LegacyDiagram**
Η διεπαφή Aspose.Slides.ILegacyDiagram και η κλάση Aspose.Slides.LegacyDiagram προστέθηκαν για την αναπαράσταση αντικειμένου παλαιού διαγράμματος. Το αντικείμενο legacy diagram είναι μια παλιά μορφή διαγραμμάτων από το PowerPoint 97-2003.
Η νέα κλάση παρέχει μεθόδους για τη μετατροπή του legacy diagram σε σύγχρονο επεξεργάσιμο αντικείμενο SmartArt ή σε επεξεργάσιμο GroupShape.
#### **Προστέθηκε νέο μέλος στην Enum Aspose.Slides.TextAlignment (JustifyLow)**
Προστέθηκε ένα νέο μέλος στην enum TextAlignment:
JustifyLow - Κάτω στοίχιση Kashida.
#### **Νέες Ιδιότητες για Aspose.Slides.IOleObjectFrame και OleObjectFrame**
Προστέθηκε μια νέα ιδιότητα στο διεπαφή IOleObjectFrame και στην κλάση OleObjectFrame που υλοποιεί αυτή τη διεπαφή. Αυτές οι ιδιότητες χρησιμοποιούνται για την παροχή πληροφοριών σχετικά με ένα αντικείμενο ενσωματωμένο στην παρουσίαση:
EmbeddedFileExtension - Επιστρέφει την επέκταση αρχείου για το τρέχον ενσωματωμένο αντικείμενο ή κενή συμβολοσειρά εάν το αντικείμενο δεν είναι σύνδεσμος
EmbeddedFileLabel - Επιστρέφει το όνομα αρχείου του ενσωματωμένου αντικειμένου OLE
EmbeddedFileName - Επιστρέφει τη διαδρομή του ενσωματωμένου αντικειμένου OLE
#### **Προστέθηκε η νέα ιδιότητα CategoryAxisType στις κλάσεις IAxis και Axis**
``` csharp

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
#### **Προστέθηκε η νέα ιδιότητα ShowLabelAsDataCallout στην κλάση DataLabelFormat και στη διεπαφή IDataLabelFormat**
``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **Προστέθηκε η ιδιότητα DrawSlidesFrame στις PdfOptions και XpsOptions**
Η λογική (Boolean) ιδιότητα DrawSlidesFrame προστέθηκε στις διεπαφές Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions και στις σχετικές κλάσεις Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions. Το μαύρο πλαίσιο γύρω από κάθε διαφάνεια θα σχεδιαστεί αν αυτή η ιδιότητα οριστεί σε 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```