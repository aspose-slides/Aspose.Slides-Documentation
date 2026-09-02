---
title: Διαχείριση ετικετών ευαισθησίας σε παρουσιάσεις PowerPoint στο .NET
linktitle: Ετικέτες ευαισθησίας
type: docs
weight: 50
url: /el/net/sensitivity-labels/
keywords:
- ετικέτα ευαισθησίας
- Microsoft Purview
- Microsoft Information Protection
- μεταδεδομένα MIP
- σημάνση περιεχομένου
- προστασία πληροφοριών
- διαχείριση εγγράφων
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- .NET
- C#
- Aspose.Slides
description: "Διαβάστε, προσθέστε, ενημερώστε, αφαιρέστε και μεταφέρετε τις ετικέτες ευαισθησίας Microsoft Purview σε παρουσιάσεις PowerPoint PPTX με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Οι ετικέτες ευαισθησίας Microsoft Purview βοηθούν οργανισμούς να ταξινομούν και να διαχειρίζονται έγγραφα. Κατά την αυτόματη επεξεργασία παρουσίασης, μια εφαρμογή ενδέχεται να χρειαστεί να διατηρήσει μια υπάρχουσα ετικέτα, να εφαρμόσει μια ετικέτα που επιλέχθηκε από πολιτική, να ενημερώσει την κατάσταση της ή να μεταφέρει μεταδεδομένα ετικέτας που γράφτηκε από παλαιότερη ροή εργασίας Microsoft Information Protection (MIP).

Το Aspose.Slides εκθέτει σύγχρονα μεταδεδομένα ετικέτας ευαισθησίας μέσω [Presentation.SensitivityLabels](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sensitivitylabels/). Αυτή η ιδιότητα επιστρέφει ένα [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/) που μπορεί να εξεταστεί και να τροποποιηθεί πριν αποθηκευτεί η παρουσίαση ως PPTX.

{{% alert color="primary" title="Σημείωση" %}}
Οι ταυτοποιητές ετικετών ευαισθησίας και οι πληροφορίες πολιτικής ορίζονται από τη διαμόρφωση του Microsoft Purview. Επαληθεύστε τη διαθεσιμότητα των ετικετών και τις απαιτήσεις πολιτικής στο περιβάλλον σας πριν προσθέσετε ή μεταφέρετε μεταδεδομένα. Οι τιμές του [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/contentmarktypes/) περιγράφουν τις σημάνσεις περιεχομένου που σχετίζονται με μια ετικέτα· από μόνες τους δεν προσθέτουν ορατό κείμενο ή σχήματα στις διαφάνειες.
{{% /alert %}}

## **Κατανόηση Ιδιοτήτων Ετικέτας Ευαισθησίας**

Κάθε [ISensitivityLabel](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/) περιέχει τα παρακάτω μεταδεδομένα:

| Ιδιότητα | Σκοπός |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/id/) | Ταυτοποιεί την ετικέτα ευαισθησίας στην πολιτική Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/siteid/) | Ταυτοποιεί τον ιστότοπο που συσχετίζεται με την πολιτική ετικέτας. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/isenabled/) | Δείχνει εάν η ετικέτα είναι ενεργοποιημένη. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/isremoved/) | Δείχνει ότι η ετικέτα έχει αφαιρεθεί. Ορίστε αυτήν την ιδιότητα σε `true` όταν η κατάσταση αφαίρεσης πρέπει να διατηρηθεί στα μεταδεδομένα. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Καθορίζει εάν η ετικέτα εφαρμόστηκε αυτόματα ή μέσω απόφασης χρήστη. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Καταγράφει τους τύπους σημάνσεων περιεχομένου που σχετίζονται με την ετικέτα. |

Η απαρίθμηση [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelassignmenttype/) περιγράφει πώς έχει εκχωρηθεί μια ετικέτα:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει προεπιλεγμένη ή αυτόματα εφαρμοσμένη ετικέτα.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει ετικέτα που εφαρμόστηκε μέσω απόφασης χρήστη, συμπεριλαμβανομένων των χειροκίνητων, προτεινόμενων και υποχρεωτικών ετικετών.

Η απαρίθμηση [SensitivityLabelContentType](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) προσδιορίζει τη σημάνση που σχετίζεται με μια ετικέτα:

| Τιμή | Σημασία |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε προεπιλογή ή αυτόματα. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) | Η σημάνση περιεχομένου κεφαλίδας σχετίζεται με την ετικέτα. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) | Η σημάνση περιεχομένου υποσέλιδου σχετίζεται με την ετικέτα. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) | Η σημάνση υδατογράφησης σχετίζεται με την ετικέτα. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) | Η κρυπτογραφική προστασία σχετίζεται με την ετικέτα. |

Πολλοί τύποι σημάνσεων μπορούν να συσχετισθούν με μία ετικέτα.

## **Λίστα Υπαρχουσών Ετικετών Ευαισθησίας**

Διαβάστε τη σύγχρονη συλλογή ετικετών από [Presentation.SensitivityLabels](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sensitivitylabels/) και κάντε την επανάληψη. Το παρακάτω παράδειγμα καταχωρεί κάθε ιδιότητα και σημάνση περιεχομένου που αποθηκεύεται για κάθε ετικέτα:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Προσθήκη Ετικέτας Ευαισθησίας με Σημάνση Περιεχομένου**

Χρησιμοποιήστε [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/add/) με τον ταυτοποιητή ετικέτας, τον ταυτοποιητή ιστότοπου, την κατάσταση ενεργοποίησης και τη μέθοδο εκχώρησης. Αφού η μέθοδος επιστρέψει το νέο [ISensitivityLabel](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/), προσθέστε τις απαιτούμενες τιμές σημάνσεων μέσω [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/contentmarktypes/).

Το παρακάτω παράδειγμα προσθέτει χειροκίνητα επιλεγμένη ετικέτα που σχετίζεται με σημάνσεις υποσέλιδου και υδατογραφήματος και, στη συνέχεια, αποθηκεύει το αποτέλεσμα ως PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Ενημέρωση Ετικέτας Ευαισθησίας**

Οι ιδιότητες του [ISensitivityLabel](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/) είναι αναγνώσιμες/εγγράψιμες, εκτός από τη συλλογή που επιστρέφεται από [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/contentmarktypes/) η οποία τροποποιείται μέσω των λειτουργιών λίστας της. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε τον ταυτοποιητή, τον ταυτοποιητή ιστότοπου, την κατάσταση ενεργοποίησης, τη μέθοδο εκχώρησης, την κατάσταση αφαίρεσης και τους τύπους σημάνσεων περιεχομένου. Αποθηκεύστε την παρουσίαση για να διατηρήσετε τις αλλαγές.

Το παρακάτω παράδειγμα ενημερώνει την κατάσταση ενεργοποίησης και τη μέθοδο εκχώρησης της πρώτης ετικέτας:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Σήμανση Ετικέτας Ευαισθησίας Ως Αφαιρεμένη**

Για να διατηρήσετε το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και ορίστε το [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/isremoved/) σε `true`. Αυτό διατηρεί την καταχώρηση ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσης. Εάν αντίθετα χρειάζεται να διαγράψετε μια καταχώρηση από τη σύγχρονη συλλογή, χρησιμοποιήστε [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/removeat/); χρησιμοποιήστε [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/clear/) για να διαγράψετε όλες τις καταχωρήσεις.

Το παρακάτω παράδειγμα σηματοδοτεί μια συγκεκριμένη ετικέτα ως αφαιρεμένη και αποθηκεύει την ενημερωμένη παρουσίαση:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Ανάγνωση και Μεταφορά Παλαιών Ετικετών MIP Ευαισθησίας**

Οι παλαιότερες ροές εργασίας βασισμένες σε MIP μπορούν να αποθηκεύουν μεταδεδομένα ετικέτας ευαισθησίας σε προσαρμοσμένες ιδιότητες εγγράφου αντί για τη σύγχρονη συλλογή ετικετών. Διαβάστε αυτά τα μεταδεδομένα με το [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Η μέθοδος αναλύει τις κληροδοτημένες προσαρμοσμένες ιδιότητες και επιστρέφει έναν πίνακα αντικειμένων [ISensitivityLabel](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/).

Για να μεταφέρετε τα μεταδεδομένα, προσθέστε κάθε επιστρεφόμενη ετικέτα στη σύγχρονη [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/) μέσω του [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/add/). Δεδομένου ότι η προσθήκη διπλότυπου ταυτοποιητή ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε περαιτέρω επικύρωση για να επιβεβαιώσετε ότι κάθε κληροδοτημένη ετικέτα εξακολουθεί να υπάρχει στην τρέχουσα πολιτική Purview.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

Η μεταφορά αντιγράφει τα αναλυθέντα αντικείμενα ετικετών στη σύγχρονη συλλογή. Δεν απαιτεί εκκαθάριση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, ώστε τα μη σχετιζόμενα μεταδεδομένα του εγγράφου να παραμείνουν άθικτα. Χρησιμοποιήστε το [IPresentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/save/) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικετών σε αρχείο PPTX.

## **Συχνές Ερωτήσεις**

**Δημιουργεί η προσθήκη τύπου σημάνσης περιεχομένου ορατή κεφαλίδα, υποσέλιδο ή υδατογράφημα στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω του [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/contentmarktypes/) περιγράφουν τις σημάνσεις που σχετίζονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο διαφάνειας ξεχωριστά εάν η ροή εργασίας σας πρέπει να αποτυπώσει αυτές τις σημάνσεις.

**Ποια είναι η διαφορά μεταξύ σήμανσης μιας ετικέτας ως αφαιρεμένης και διαγραφής της από τη συλλογή;**

Ο ορισμός του [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/isremoved/) σε `true` διατηρεί την καταχώρηση ετικέτας και καταγράφει την κατάσταση αφαίρεσης. Η κλήση του [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/removeat/) διαγράφει την καταχώρηση από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει στις απαιτήσεις διατήρησης μεταδεδομένων του οργανισμού σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο κληροδοτημένα μεταδεδομένα MIP όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι κληροδοτημένες ετικέτες μπορούν να παραμείνουν σε προσαρμοσμένες ιδιότητες εγγράφου, ενώ οι σύγχρονες ετικέτες διατίθενται μέσω του [Presentation.SensitivityLabels](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sensitivitylabels/). Χρησιμοποιήστε το [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/getsensitivitylabels/) για να διαβάσετε τα κληροδοτημένα μεταδεδομένα και να μεταφέρετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν μια ετικέτα με τον ίδιο ταυτοποιητή προστίθεται περισσότερες από μία φορές;**

Το [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/add/) πετάει `ArgumentException` όταν η συλλογή περιέχει ήδη ετικέτα με τον ίδιο ταυτοποιητή. Ελέγξτε τις υπάρχουσες τιμές του [ISensitivityLabel.Id](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/id/) πριν προσθέσετε ή μεταφέρετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για τη διατήρηση των ενημερωμένων ετικετών ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας το [IPresentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/save/) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/), όπως φαίνεται στα παραπάνω παραδείγματα.