---
title: Δ

public API και Μη Συμβατές Προς Πίσω Αλλαγές στο Aspose.Slides για .NET 14.8.0
linktitle: Aspose.Slides για .NET 14.8.0
type: docs
weight: 100
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- μετάβαση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εξετάστε τις ενημερώσεις του δημόσιου API και τις μη συμβατές αλλαγές στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασής σας PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα καταγράφει όλες τις [added](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) ή [removed](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides for .NET 14.8.0.

{{% /alert %}} 
## **Public API Changes**
### **Changed Properties**
#### **Added the IVbaProject Interface, Changed the Presentation.VbaProject Property**
Η ιδιότητα VbaProject της κλάσης Presentation αντικαταστάθηκε. Αντί για h3. Added Interfaces, Properties and Enumeration Options η ακατέργαστη αναπαράσταση byte του έργου VBA, η νέα υλοποίηση της διεπαφής IVbaProject προστέθηκε.

Χρησιμοποιήστε την ιδιότητα IVbaProject για τη διαχείριση των έργων VBA που είναι ενσωματωμένα σε μια παρουσίαση. Μπορείτε να προσθέσετε νέες αναφορές έργου, να επεξεργαστείτε υπάρχουσες μονάδες και να δημιουργήσετε νέες.

Επίσης, μπορείτε να δημιουργήσετε ένα νέο έργο VBA χρησιμοποιώντας την κλάση VbaProject που υλοποιεί τη διεπαφή IVbaProject.

Το παρακάτω παράδειγμα δείχνει τη δημιουργία ενός απλού έργου VBA που περιέχει μία μονάδα και προσθέτει δύο απαιτούμενες αναφορές στις βιβλιοθήκες.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // Δημιουργία νέου έργου VBA

    pres.VbaProject = new VbaProject();

    // Προσθήκη κενής μονάδας στο έργο VBA

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Ορισμός κώδικα πηγής μονάδας

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

Αυτό το παράδειγμα δείχνει πώς να αντιγράψετε ένα έργο VBA από υπάρχουσα παρουσίαση σε νέα.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Added Interfaces, Properties and Enumeration Options**
#### **Added the Aspose.Slides.Charts.IChartSeries.Overlap Property**
Η ιδιότητα Aspose.Slides.Charts.IChartSeries.Overlap καθορίζει το πόσο θα επικαλύπτονται οι ράβδοι και οι στήλες σε 2D διαγράμματα (από -100 έως 100).

Αυτή η ιδιότητα δεν αφορά μόνο αυτή τη σειρά, αλλά και όλες τις σειρές στην ομάδα γονέα – είναι μια προβολή της αντίστοιχης ιδιότητας της ομάδας. Συνεπώς η ιδιότητα αυτή είναι μόνο για ανάγνωση.

- Χρησιμοποιήστε την ιδιότητα ParentSeriesGroup για πρόσβαση στην ομάδα γονέα.
- Χρησιμοποιήστε την ιδιότητα ParentSeriesGroup.Overlap για ανάγνωση/εγγραφή και αλλαγή της τιμής.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


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
#### **Added the Aspose.Slides.Charts.IChartSeriesGroup.Overlap Property**
Η ιδιότητα Aspose.Slides.Charts.IChartSeriesGroup.Overlap καθορίζει το πόσο θα επικαλύπτονται οι ράβδοι και οι στήλες σε 2D διαγράμματα (από -100 έως 100).

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
   IChartSeriesCollection series = chart.ChartData.Series;
   series[0].ParentSeriesGroup.Overlap = -30;
}
``` 
#### **Added the ShapeThumbnailBounds.Appearance Enum Value**
Αυτή η μέθοδος δημιουργίας μικρογραφίας σχήματος σας επιτρέπει να παράγετε μια μικρογραφία σχήματος εντός των ορίων της εμφάνισής του. Λαμβάνει υπόψη όλα τα εφέ του σχήματος. Η παραγόμενη μικρογραφία σχήματος περιορίζεται από τα όρια της διαφάνειας.

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```