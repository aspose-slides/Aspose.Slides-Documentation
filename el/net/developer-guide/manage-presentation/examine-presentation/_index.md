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
description: "Εξερευνήστε διαφάνειες, δομή και μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας .NET για πιο γρήγορη απόκτηση γνώσεων και πιο έξυπνους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Aspose.Slides μπορεί να εντοπίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει πλήρες μοντέλο αντικειμένων παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να ταξινομήσετε αρχεία, να δημιουργήσετε ένα απόθεμα ή να εξετάσετε ιδιότητες πριν αποφασίσετε αν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Το άρθρο αυτό επιδεικνύει ελαφριά επιθεώρηση μέσω του [PresentationFactory](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/) και του [IPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω του [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/).

## **Έλεγχος Μορφής Παρουσίασης**

Αν έχετε ήδη μια φορτωμένη παρουσίαση, δείτε το [Determine the Original Presentation Format](/slides/el/net/detect-presentation-source-format/) για ανίχνευση μετά τη φόρτωση και τους περιορισμούς των παλαιών ροών PPT, PPS και POT.

Χρησιμοποιήστε το [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/getpresentationinfo/) για να ελέγξετε ένα αρχείο χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Η ιδιότητα [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/loadformat/) αναφέρει τη εντοπισμένη μορφή, όπως PPTX, PPT ή ODP.

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

## **Δημιουργία Ελαφρού Αποθέματος Παρουσίασης**

Όταν επεξεργάζεστε πολλαπλά αρχεία παρουσίασης, ίσως χρειάζεστε ένα συμπαγές απόθεμα για επικύρωση, ευρετηρίαση ή σύστημα διαχείρισης εγγράφων. Σε αυτό το σενάριο, χρησιμοποιήστε το [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/getpresentationinfo/) για να αποκτήσετε ένα αντικείμενο [IPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/), και στη συνέχεια καλέστε το [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/readdocumentproperties/) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) ούτε απαιτεί την περιπλοκή του πλήρους μοντέλου αντικειμένων παρουσίασης.

Οι επεκταμένες ιδιότητες που εκθέτει το [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/) παρέχουν τις παρακάτω τιμές αποθέματος:

| Ιδιότητα | Τιμή αποθέματος |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/slides/el/) | Συνολικός αριθμός διαφανειών. |
| [HiddenSlides](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/hiddenslides/) | Αριθμός κρυφών διαφανειών. |
| [Notes](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/notes/) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [Paragraphs](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/paragraphs/) | Συνολικός αριθμός παραγράφων, εφόσον είναι διαθέσιμος. |
| [Words](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/words/) | Συνολικός αριθμός λέξεων. |
| [MultimediaClips](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/multimediaclips/) | Συνολικός αριθμός ηχητικών και βίντεο κλιπ. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργήσει αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και εκτυπώνει ένα συμπαγές απόθεμα. Συνδυάζει επίσης το [HeadingPairs](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/headingpairs/) με το [TitlesOfParts](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/titlesofparts/) για να εμφανίσει ομάδες περιεχομένου όπως γραμματοσειρές, θέματα και τίτλους διαφανειών.

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

Κάθε [IHeadingPair](https://reference.aspose.com/slides/el/net/aspose.slides/iheadingpair/) παρέχει ένα όνομα ομάδας και τον αριθμό των στοιχείων σε αυτήν την ομάδα. Το [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/titlesofparts/) είναι ένας επίπεδος, διατεταγμένος πίνακας, οπότε καταναλώστε τον αριθμό διαδοχικών τίτλων που ορίζονται από κάθε ζεύγος επικεφαλίδας.

### **Αποθηκευμένα Μεταδεδομένα και Περιορισμοί Μορφής**

Οι ιδιότητες αποθέματος που επιστρέφει το [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/readdocumentproperties/) αντικατοπτρίζουν τα μεταδεδομένα που είναι διαθέσιμα στο πηγαίο έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν διασχίζει το μοντέλο αντικειμένων παρουσίασης για να επανυπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλιπείς ιδιότητες αναπαρίστανται από προεπιλεγμένες τιμές, και οι αποθηκευμένες τιμές μπορεί να είναι παλαιότερες αν η εφαρμογή που αποθήκευσε τελευταία φορά το αρχείο δεν ενημέρωσε τις ιδιότητες του εγγράφου.

- **PPTX:** Η μορφή παρέχει επεκταμένες ιδιότητες εγγράφου για αριθμούς διαφανειών, σημειώσεων, κρυφών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και ζεύγη επικεφαλίδων και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από τις ιδιότητες που έγραψε ο δημιουργός του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει τις αντίστοιχες ιδιότητες περίληψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν έχει ενημερωθεί από τον δημιουργό του εγγράφου, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή αντί να την υπολογίζει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικές στατιστικές εγγράφου, όπως αριθμούς σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε PowerPoint‑συγκεκριμένη επεκταμένη ιδιότητα. Τα μεταδεδομένα κρυφών διαφανειών, σημειώσεων, πολυμέσων, ζευγών επικεφαλίδων και τίτλων τμημάτων ενδέχεται να μην είναι διαθέσιμα, και οι ιδιότητες αποθέματος μπορεί να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρείτε μία μηδενική τιμή ή έναν κενό πίνακα ως αποδεικτικό ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για αποθέματα και προκαταρκτικούς ελέγχους. Φορτώστε την παρουσίαση και ελέγξτε το ενεργό μοντέλο αντικειμένων όταν το αποτέλεσμα πρέπει να αντανακλά αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες που επιστρέφει το [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/readdocumentproperties/) μπορούν επίσης να τροποποιηθούν χωρίς τη δημιουργία ενός αντικειμένου [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Εφαρμόστε τις αλλαγές με το [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/updatedocumentproperties/), και στη συνέχεια γράψτε την δεσμευμένη παρουσίαση με το [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/writebindedpresentation/).

Η παρακάτω εικόνα εμφανίζει τις αρχικές ιδιότητες εγγράφου.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Το παρακάτω παράδειγμα αλλάζει τον τίτλο και την ώρα τελευταίας αποθήκευσης και γράφει το αποτέλεσμα σε νέο αρχείο:

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

![Αλλαγμένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για σχετικούς ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα παρακάτω άρθρα:

- [Προστασία Παρουσιασμών με Κωδικό](/slides/el/net/password-protected-presentation/)
- [Προστασία Γραφής Παρουσιασμών](/slides/el/net/write-protected-presentation/)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation.FontsManager](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/fontsmanager/). Καλέστε το [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/getembeddedfonts/) για να αποκτήσετε τις ενσωματωμένες γραμματοσειρές και το [FontsManager.GetFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/getfonts/) για να αποκτήσετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε τις γραμματοσειρές που απαιτούνται για την απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώσω αν το αρχείο περιέχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα εγγράφου είναι επαρκή, διαβάστε το [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/hiddenslides/) μέσω του [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/getpresentationinfo/) και του [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/readdocumentproperties/). Αυτό είναι κατάλληλο για ελαφρύ απόθεμα. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα ενδέχεται να λείπουν ή να είναι παλαιά, ή χρειάζεται να επαληθεύσετε τις ενεργές τιμές, διατρέξτε τις [Presentation.Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/) και ελέγξτε την ιδιότητα [Slide.Hidden](https://reference.aspose.com/slides/el/net/aspose.slides/slide/hidden/) κάθε διαφάνειας.

**Μπορώ να εντοπίσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος και προσανατολισμός διαφάνειας και αν διαφέρουν από τις προεπιλεγμένες τιμές;**

Ναι. Φορτώστε την παρουσίαση και διαβάστε το [Presentation.SlideSize](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slidesize/). Εξετάστε τα [ISlideSize.Type](https://reference.aspose.com/slides/el/net/aspose.slides/islidesize/type/), [ISlideSize.Size](https://reference.aspose.com/slides/el/net/aspose.slides/islidesize/size/) και [ISlideSize.Orientation](https://reference.aspose.com/slides/el/net/aspose.slides/islidesize/orientation/) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με την προεπιλεγμένη διαμόρφωση και διαστάσεις.

**Υπάρχει γρήγορος τρόπος να δω αν τα διαγράμματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chart/) και ελέγξτε το [ChartData.DataSourceType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/datasourcetype/). Για ένα εξωτερικό βιβλίο εργασίας, διαβάστε το [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/externalworkbookpath/). Ο τύπος και η διαδρομή της πηγής δεδομένων προσδιορίζουν μια εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω τις 'βαριές' διαφάνειες που μπορεί να επιβραδύνουν την απόδοση ή την εξαγωγή PDF;**

Δεν υπάρχει μια ενιαία ιδιότητα πολυπλοκότητας. Διασχίστε τις [Presentation.Slides](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/slides/el/) και τη συλλογή [IBaseSlide.Shapes](https://reference.aspose.com/slides/el/net/aspose.slides/ibaseslide/shapes/) κάθε διαφάνειας. Χρησιμοποιήστε τον αριθμό των σχημάτων και την παρουσία μεγάλων εικόνων, εφέ, κινούμενων σχεδίων ή πολυμέσων ως ενδείξεις, και μετρήστε μια αντιπροσωπευτική απόδοση ή εξαγωγή πριν θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο σημάδι απόδοσης.