---
title: Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε .NET
linktitle: Πληροφορίες Παρουσίασης
type: docs
weight: 30
url: /el/net/examine-presentation/
keywords:
- μορφή παρουσίασης
- ιδιότητες παρουσίασης
- ιδιότητες εγγράφου
- λήψη ιδιοτήτων
- ανάγνωση ιδιοτήτων
- αλλαγή ιδιοτήτων
- τροποποίηση ιδιοτήτων
- ενημέρωση ιδιοτήτων
- εξέταση PPTX
- εξέταση PPT
- εξέταση ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εξερευνήστε τις διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας .NET για γρηγορότερη αντίληψη και πιο έξυπνους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να αναγνωρίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει πλήρες μοντέλο αντικειμένων παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να ταξινομήσετε αρχεία, να δημιουργήσετε απογραφή ή να ελέγξετε ιδιότητες πριν αποφασίσετε εάν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Αυτό το άρθρο επιδεικνύει ελαφριά επιθεώρηση μέσω [PresentationFactory](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/) και [IPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/).

## **Έλεγχος μορφής παρουσίασης**

Χρησιμοποιήστε [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/getpresentationinfo/) για να επιθεωρήσετε ένα αρχείο χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) . Η ιδιότητα [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/loadformat/) αναφέρει τη ανιχνευμένη μορφή, όπως PPTX, PPT ή ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **Δημιουργία ελαφριάς απογραφής παρουσιάσεων**

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, ίσως χρειάζεστε μια συμπαγή απογραφή για έλεγχο, ευρετηρία ή σύστημα διαχείρισης εγγράφων. Σε αυτό το σενάριο, χρησιμοποιήστε [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/getpresentationinfo/) για να αποκτήσετε ένα αντικείμενο [IPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/) , και στη συνέχεια καλέστε [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/readdocumentproperties/) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) , ούτε απαιτεί να διασχίσετε το πλήρες μοντέλο αντικειμένων παρουσίασης.

Οι εκτεταμένες ιδιότητες που εκτίθενται από το [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/) παρέχουν τις παρακάτω τιμές απογραφής:

| Ιδιότητα | Τιμή απογραφής |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/slides/el/) | Συνολικός αριθμός διαφαινέων. |
| [HiddenSlides](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/hiddenslides/) | Αριθμός κρυφών διαφαινέων. |
| [Notes](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/notes/) | Αριθμός διαφαινέων που περιέχουν σημειώσεις. |
| [Paragraphs](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/paragraphs/) | Συνολικός αριθμός παραγράφων, όταν είναι διαθέσιμο. |
| [Words](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/words/) | Συνολικός αριθμός λέξεων. |
| [MultimediaClips](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/multimediaclips/) | Συνολικός αριθμός ηχητικών και βίντεο κλιπ. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργήσει ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και εκτυπώνει μια συμπαγή απογραφή. Συνδυάζει επίσης τα [HeadingPairs](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/headingpairs/) με τα [TitlesOfParts](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/titlesofparts/) για να εμφανίσει ομάδες περιεχομένου όπως γραμματοσειρές, θέματα και τίτλους διαφανειών.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

Κάθε [IHeadingPair](https://reference.aspose.com/slides/el/net/aspose.slides/iheadingpair/) παρέχει ένα όνομα ομάδας και τον αριθμό των αντικειμένων σε αυτήν την ομάδα. Το [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/titlesofparts/) είναι ένας επίπεδος, διατεταγμένος πίνακας, επομένως καταναλώνετε τον αριθμό των διαδοχικών τίτλων που καθορίζονται από κάθε ζεύγος τίτλου.

### **Αποθηκευμένα μεταδεδομένα και περιορισμοί μορφής**

Οι ιδιότητες απογραφής που επιστρέφει η μέθοδος [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/readdocumentproperties/) αντικατοπτρίζουν τα μεταδεδομένα που είναι διαθέσιμα στο πρωτότυπο έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν διασχίζει το μοντέλο αντικειμένων παρουσίασης για να επανυπολογίσει αυτές τις τιμές σε αυτήν την κλήση. Οι ελλιπείς ιδιότητες αναπαριστώνται από προεπιλεγμένες τιμές, και οι αποθηκευμένες τιμές μπορεί να είναι παρωχημένες εάν η εφαρμογή που έσωσε τελευταία φορά το αρχείο δεν ενημέρωσε τις ιδιότητες του εγγράφου.

- **PPTX:** Η μορφή παρέχει εκτεταμένες ιδιότητες εγγράφου για καταμετρήσεις διαφανειών, σημειώσεων, κρυφών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και ζεύγη τίτλων και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από τις ιδιότητες που έγραψε ο δημιουργός του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει αντίστοιχες ιδιότητες σύνοψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν ενημερώθηκε από τον δημιουργό του εγγράφου, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή της αντί να την υπολογίσει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικά στατιστικά εγγράφου, όπως αριθμός σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε ειδική εκτεταμένη ιδιότητα του PowerPoint. Τα μεταδεδομένα κρυφών διαφανειών, διαφανειών με σημειώσεις, πολυμέσων, ζεύγων τίτλων και τίτλων τμημάτων μπορεί να μην είναι διαθέσιμα, και οι ιδιότητες απογραφής μπορεί να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρείτε τη μηδενική τιμή ή έναν άδειο πίνακα ως αποδεικτικό ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για απογραφές και προκαταρκτικούς ελέγχους. Φορτώστε την παρουσίαση και ελέγξτε το ενεργό μοντέλο αντικειμένων όταν το αποτέλεσμα πρέπει να αντανακλά αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση ιδιοτήτων παρουσίασης**

Οι ιδιότητες που επιστρέφει η μέθοδος [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/readdocumentproperties/) μπορούν επίσης να τροποποιηθούν χωρίς τη δημιουργία ενός αντικειμένου [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) . Εφαρμόστε τις αλλαγές με την [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) , και έπειτα γράψτε την δεσμευμένη παρουσίαση με την [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/writebindedpresentation/) .

Η ακόλουθη εικόνα δείχνει τις αρχικές ιδιότητες του εγγράφου.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Το παρακάτω παράδειγμα αλλάζει τον τίτλο και την ημερομηνία τελευταίας αποθήκευσης και γράφει το αποτέλεσμα σε νέο αρχείο:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

Η ακόλουθη εικόνα δείχνει τις αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint.

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για σχετικούς ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα παρακάτω άρθρα:

- [Παρουσιάσεις με Προστασία Κωδικού](/slides/el/net/password-protected-presentation/)
- [Παρουσιάσεις με Προστασία Εγγραφής](/slides/el/net/write-protected-presentation/)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε [Presentation.FontsManager](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/fontsmanager/) . Καλέστε [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/getembeddedfonts/) για να αποκτήσετε τις ενσωματωμένες γραμματοσειρές και [FontsManager.GetFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/getfonts/) για να αποκτήσετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε τις γραμματοσειρές που απαιτούνται για απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώ αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα του εγγράφου είναι επαρκή, διαβάστε το [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/hiddenslides/) μέσω του [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/getpresentationinfo/) και του [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/readdocumentproperties/) . Αυτό είναι κατάλληλο για ελαφριά απογραφή. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι παλιά, ή αν χρειάζεται να επαληθεύσετε τις ζωντανές τιμές, επαναλάβετε τα [Presentation.Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/) και ελέγξτε την ιδιότητα [Slide.Hidden](https://reference.aspose.com/slides/el/net/aspose.slides/slide/hidden/) κάθε διαφάνειας.

**Μπορώ να εντοπίσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και διαβάστε το [Presentation.SlideSize](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slidesize/) . Εξετάστε το [ISlideSize.Type](https://reference.aspose.com/slides/el/net/aspose.slides/islidesize/type/) , το [ISlideSize.Size](https://reference.aspose.com/slides/el/net/aspose.slides/islidesize/size/) , και το [ISlideSize.Orientation](https://reference.aspose.com/slides/el/net/aspose.slides/islidesize/orientation/) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με τις προεπιλεγμένες διαστάσεις και προσανατολισμό.

**Υπάρχει γρήγορος τρόπος να διαπιστώ αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chart/) και ελέγξτε το [ChartData.DataSourceType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/datasourcetype/) . Για εξωτερικό φύλλο εργασίας, διαβάστε το [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/externalworkbookpath/) . Ο τύπος πηγής δεδομένων και η διαδρομή αναγγέλλουν εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω τις 'βαριές' διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή σε PDF;**

Δεν υπάρχει μία ενιαία ιδιότητα πολυπλοκότητας. Διασχίστε τα [Presentation.Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/) και τη συλλογή [IBaseSlide.Shapes](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/shapes/) κάθε διαφάνειας. Χρησιμοποιήστε τους μετρητές σχήματος και την παρουσία μεγάλων εικόνων, εφέ, κινήσεων ή πολυμέσων ως δείκτες, και πραγματοποιήστε μια αντιπροσωπευτική απόπειρα απόδοσης ή εξαγωγής πριν θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο σημείο συμφόρησης.