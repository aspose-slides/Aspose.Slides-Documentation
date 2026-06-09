---
title: Δημόσιο API και Ασυμβατές Πίσω Αλλαγές σε Aspose.Slides για .NET 14.8.0
linktitle: Aspose.Slides για .NET 14.8.0
type: docs
weight: 100
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- μετανάστευση
- παραδοσιακός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των διασπαστικών αλλαγών στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP σας."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλες τις [προστέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) ή [αφαιρέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for .NET 14.8.0 API.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
### **Αλλαγμένες Ιδιότητες**
#### **Προστέθηκε η Διασύνδεση IVbaProject, Αλλαγή της Ιδιότητας Presentation.VbaProject**
Η ιδιότητα VbaProject της κλάσης Presentation έχει αντικατασταθεί. Αντί για την ακατέργαστη αναπαράσταση byte του έργου VBA, έχει προστεθεί η νέα υλοποίηση διασύνδεσης IVbaProject.

Χρησιμοποιήστε την ιδιότητα IVbaProject για τη διαχείριση των ενσωματωμένων έργων VBA σε μια παρουσίαση. Μπορείτε να προσθέσετε νέες αναφορές έργου, να επεξεργαστείτε υπάρχοντα αρχεία μονάδας και να δημιουργήσετε νέα.

Επίσης, μπορείτε να δημιουργήσετε ένα νέο έργο VBA χρησιμοποιώντας την κλάση VbaProject που υλοποιεί τη διασύνδεση IVbaProject.

Το παρακάτω παράδειγμα δείχνει τη δημιουργία ενός απλού έργου VBA που περιλαμβάνει μία μονάδα και προσθέτει δύο απαιτούμενες αναφορές στις βιβλιοθήκες.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Δημιουργία νέου έργου VBA
    pres.VbaProject = new VbaProject();

    // Προσθήκη κενής μονάδας στο έργο VBA
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Ορισμός κώδικα πηγής της μονάδας
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Δημιουργία αναφοράς στο <stdole>
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Δημιουργία αναφοράς στο Office
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Προσθήκη αναφορών στο έργο VBA
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);
}
``` 

Αυτό το παράδειγμα δείχνει πώς να αντιγράψετε ένα έργο VBA από μια υπάρχουσα παρουσίαση σε μια νέα.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Προστέθηκαν Διασυνδέσεις, Ιδιότητες και Επιλογές Αρίθμησης**
#### **Προστέθηκε η Ιδιότητα Aspose.Slides.Charts.IChartSeries.Overlap**
Η ιδιότητα Aspose.Slides.Charts.IChartSeries.Overlap καθορίζει το πόσο θα επικαλύπτονται οι ράβδοι και οι στήλες σε 2D γραφήματα (βάθμιση από -100 έως 100).

Αυτή είναι η ιδιότητα όχι μόνο αυτής της σειράς αλλά και όλων των σειρών στην γονική ομάδα σειρών· πρόκειται για προβολή της αντίστοιχης ιδιότητας της ομάδας. Συνεπώς, αυτή η ιδιότητα είναι μόνο για ανάγνωση.

- Χρησιμοποιήστε την ιδιότητα ParentSeriesGroup για να αποκτήσετε πρόσβαση στην γονική ομάδα σειρών.
- Χρησιμοποιήστε την ιδιότητα ParentSeriesGroup.Overlap για ανάγνωση/εγγραφή προκειμένου να αλλάξετε την τιμή.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}

``` 
#### **Προστέθηκε η Ιδιότητα Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
Η ιδιότητα Aspose.Slides.Charts.IChartSeriesGroup.Overlap καθορίζει το πόσο θα επικαλύπτονται οι ράβδοι και οι στήλες σε 2D γραφήματα (από -100 έως 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **Προστέθηκε η Τιμή Enum ShapeThumbnailBounds.Appearance**
Αυτή η μέθοδος δημιουργίας μικρογραφίας σχήματος σας επιτρέπει να δημιουργήσετε μια μικρογραφία σχήματος εντός των ορίων της εμφάνισής του. Λαμβάνει υπόψη όλα τα εφέ του σχήματος. Η δημιουργημένη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}
```