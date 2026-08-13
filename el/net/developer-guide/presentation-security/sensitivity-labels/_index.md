---
title: Διαχείριση Ετικετών Ευαισθησίας σε Παρουσιάσεις PowerPoint σε .NET
linktitle: Ετικέτες Ευαισθησίας
type: docs
weight: 50
url: /el/net/sensitivity-labels/
keywords:
- ετικέτα ευαισθησίας
- Microsoft Purview
- Microsoft Information Protection
- μεταδεδομένα MIP
- επισημάνση περιεχομένου
- προστασία πληροφοριών
- διακυβέρνηση εγγράφων
- PowerPoint
- PPTX
- ασφάλεια παρουσίασης
- .NET
- C#
- Aspose.Slides
description: "Διαβάστε, προσθέστε, ενημερώστε, αφαιρέστε και μεταφέρετε ετικέτες ευαισθησίας Microsoft Purview σε παρουσιάσεις PowerPoint PPTX με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Οι ετικέτες ευαισθησίας του Microsoft Purview βοηθούν τις οργανισμούς να ταξινομούν και να διαχειρίζονται έγγραφα. Κατά την αυτοματοποιημένη επεξεργασία παρουσιάσεων, μια εφαρμογή ενδέχεται να χρειαστεί να διατηρήσει μια υπάρχουσα ετικέτα, να εφαρμόσει μια ετικέτα που επιλέγεται από πολιτική, να ενημερώσει την κατάσταση της ή να μεταφέρει μεταδεδομένα ετικέτας που έχουν γραφτεί από μια παλαιότερη ροή εργασίας Microsoft Information Protection (MIP).

Το Aspose.Slides εκθέτει σύγχρονα μεταδεδομένα ετικετών ευαισθησίας μέσω του [Presentation.SensitivityLabels](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sensitivitylabels/). Αυτή η ιδιότητα επιστρέφει μια [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/) που μπορεί να επιθεωρηθεί και να τροποποιηθεί πριν αποθηκευτεί η παρουσίαση ως PPTX.

{{% alert color="info" title="Note" %}}
Τα αναγνωριστικά ετικετών ευαισθησίας και οι πληροφορίες πολιτικής ορίζονται από τη ρύθμιση του Microsoft Purview. Επικυρώστε τη διαθεσιμότητα των ετικετών και τις απαιτήσεις πολιτικής στο περιβάλλον σας πριν προσθέσετε ή μεταφέρετε μεταδεδομένα. Οι τιμές του [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/contentmarktypes/) περιγράφουν τις επισημάνσεις περιεχομένου που συνδέονται με μια ετικέτα· από μόνες τους δεν προσθέτουν ορατό κείμενο ή σχήματα στις διαφάνειες.
{{% /alert %}}

## **Κατανόηση Ιδιοτήτων Ετικέτας Ευαισθησίας**

Κάθε [ISensitivityLabel](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/) περιέχει τα παρακάτω μεταδεδομένα:

| Ιδιότητα | Σκοπός |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/id/) | Αναγνωρίζει την ετικέτα ευαισθησίας στην πολιτική του Purview. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/siteid/) | Αναγνωρίζει τον χώρο που συνδέεται με την πολιτική ετικέτας. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/isenabled/) | Δείχνει εάν η ετικέτα είναι ενεργοποιημένη. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/isremoved/) | Δείχνει ότι η ετικέτα έχει αφαιρεθεί. Ορίστε αυτή την ιδιότητα σε `true` όταν η κατάσταση αφαίρεσης πρέπει να διατηρηθεί στα μεταδεδομένα. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Καθορίζει εάν η ετικέτα εφαρμόστηκε αυτόματα ή μέσω απόφασης χρήστη. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Καταγράφει τους τύπους επισημάνσεων περιεχομένου που συνδέονται με την ετικέτα. |

Ο χαρακτηρισμός [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelassignmenttype/) περιγράφει πώς εκχωρήθηκε μια ετικέτα:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια προεπιλεγμένη ή αυτόματα εφαρμοσμένη ετικέτα.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelassignmenttype/) αντιπροσωπεύει μια ετικέτα που εφαρμοστέα μέσω απόφασης χρήστη, συμπεριλαμβανομένων των χειροκίνητα εφαρμοσμένων, προτεινόμενων και υποχρεωτικών ετικετών.

Ο χαρακτηρισμός [SensitivityLabelContentType](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) προσδιορίζει την επισημάνση που σχετίζεται με μια ετικέτα:

| Τιμή | Νόημα |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) | Η ετικέτα εφαρμόστηκε εξ ορισμού ή αυτόματα. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) | Η επισημάνση περιεχομένου κεφαλίδας συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) | Η επισημάνση περιεχομένου υποσέλιδου συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) | Η επισημάνση περιεχομένου υδατοποστείλιου συνδέεται με την ετικέτα. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/el/net/aspose.slides/sensitivitylabelcontenttype/) | Η προστασία κρυπτογράφησης συνδέεται με την ετικέτα. |

Πολλοί τύποι επισημάνσεων μπορούν να συνδέονται με μια ετικέτα.

## **Λίστα Υφιστάμενων Ετικετών Ευαισθησίας**

Διαβάστε τη σύγχρονη συλλογή ετικετών από το [Presentation.SensitivityLabels](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sensitivitylabels/) και επαναλάβετε την. Το παρακάτω παράδειγμα εμφανίζει κάθε ιδιότητα και επισημάνση περιεχομένου που αποθηκεύονται για κάθε ετικέτα:

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

## **Προσθήκη Ετικέτας Ευαισθησίας με Επισημάνση Περιεχομένου**

Χρησιμοποιήστε το [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/add/) με το αναγνωριστικό ετικέτας, το αναγνωριστικό χώρου, την κατάσταση ενεργοποίησης και τη μέθοδο εκχώρησης. Αφού η μέθοδος επιστρέψει τη νέα [ISensitivityLabel](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/), προσθέστε τις απαιτούμενες τιμές επισημάνσεων μέσω του [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/contentmarktypes/).

Το παρακάτω παράδειγμα προσθέτει μια χειροκίνητα επιλεγμένη ετικέτα που συνδέεται με επισημάνσεις υποσέλιδου και υδατοποστείλιου, και στη συνέχεια αποθηκεύει το αποτέλεσμα ως PPTX:

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

Οι ιδιότητες του [ISensitivityLabel](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/) είναι αναγνώσιμες/εγγράψιμες, εκτός από τη συλλογή που επιστρέφει το [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/contentmarktypes/), η οποία τροποποιείται μέσω των λειτουργιών λίστας της. Αφού εντοπίσετε την απαιτούμενη ετικέτα, μπορείτε να ενημερώσετε το αναγνωριστικό της, το αναγνωριστικό χώρου, την κατάσταση ενεργοποίησης, τη μέθοδο εκχώρησης, την κατάσταση αφαίρεσης και τους τύπους επισημάνσεων περιεχομένου. Αποθηκεύστε την παρουσίαση για να διατηρηθούν οι αλλαγές.

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

## **Σήμανση Ετικέτας Ευαισθησίας ως Αφαιρεμένης**

Για να διατηρήσετε το γεγονός ότι μια ετικέτα αφαιρέθηκε, βρείτε την ετικέτα και ορίστε το [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/isremoved/) σε `true`. Αυτό διατηρεί την εγγραφή της ετικέτας ενώ καταγράφει την κατάσταση αφαίρεσής της. Εάν θέλετε να διαγράψετε μια εγγραφή από τη σύγχρονη συλλογή, χρησιμοποιήστε το [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/removeat/); χρησιμοποιήστε το [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/clear/) για να διαγράψετε όλες τις εγγραφές.

Το παρακάτω παράδειγμα σημαδεύει μια συγκεκριμένη ετικέτα ως αφαιρεμένη και αποθηκεύει την ενημερωμένη παρουσίαση:

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

## **Ανάγνωση και Μεταφορά Παλαιών Ετικετών Ευαισθησίας MIP**

Οι παλαιότερες ροές εργασίας βάσει MIP μπορούν να αποθηκεύουν μεταδεδομένα ετικετών ευαισθησίας σε προσαρμοσμένες ιδιότητες εγγράφου αντί για τη σύγχρονη συλλογή ετικετών. Διαβάστε αυτά τα μεταδεδομένα με το [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Η μέθοδος αναλύει τις παλαιές προσαρμοσμένες ιδιότητες και επιστρέφει έναν πίνακα αντικειμένων [ISensitivityLabel](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/).

Για τη μεταφορά των μεταδεδομένων, προσθέστε κάθε ετικέτα που επιστράφηκε στη σύγχρονη [ISensitivityLabelCollection](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/) μέσω του [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/add/). Επειδή η προσθήκη ενός διπλότυπου αναγνωριστικού ετικέτας προκαλεί εξαίρεση, το παράδειγμα ελέγχει τη συλλογή προορισμού πριν αντιγράψει κάθε ετικέτα. Μπορείτε να προσθέσετε επιπλέον επικυρώσεις για να βεβαιωθείτε ότι κάθε κληρονομική ετικέτα εξακολουθεί να υπάρχει στην τρέχουσα πολιτική Purview.

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

Η μεταφορά αντιγράφει τα αναλυθέντα αντικείμενα ετικετών στη σύγχρονη συλλογή. Δεν απαιτεί εκκαθάριση όλων των προσαρμοσμένων ιδιοτήτων εγγράφου, ώστε τα άσχετα μεταδεδομένα του εγγράφου να παραμείνουν αμετάβλητα. Χρησιμοποιήστε το [IPresentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/save/) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/) για να γράψετε τα σύγχρονα μεταδεδομένα ετικετών σε αρχείο PPTX.

## **Συχνές Ερωτήσεις**

**Δημιουργεί η προσθήκη τύπου επισημάνσης περιεχομένου μια ορατή κεφαλίδα, υποσέλιδο ή υδατοπόστια στις διαφάνειες;**

Όχι. Οι τιμές που προστίθενται μέσω του [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/contentmarktypes/) περιγράφουν τις επισημάνσεις που συνδέονται με την ετικέτα ευαισθησίας. Δεν δημιουργούν ορατό κείμενο ή σχήματα στην παρουσίαση. Προσθέστε το αντίστοιχο περιεχόμενο διαφάνειας ξεχωριστά εάν η ροή εργασίας σας απαιτεί την απόδοση αυτών των επισημάνσεων.

**Ποια είναι η διαφορά μεταξύ του σήματος μιας ετικέτας ως αφαιρεμένης και της διαγραφής της από τη συλλογή;**

Ορίζοντας το [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/isremoved/) σε `true` διατηρεί την εγγραφή της ετικέτας και καταγράφει την κατάσταση αφαίρεσής της. Καλώντας το [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/removeat/) διαγράφεται η εγγραφή από τη σύγχρονη συλλογή. Επιλέξτε τη λειτουργία που ταιριάζει στις απαιτήσεις διατήρησης μεταδεδομένων της οργάνωσής σας.

**Μπορεί μια παρουσίαση να περιέχει τόσο κληρονομικά μεταδεδομένα MIP όσο και σύγχρονες ετικέτες ευαισθησίας;**

Ναι. Οι κληρονομικές ετικέτες μπορούν να παραμείνουν σε προσαρμοσμένες ιδιότητες εγγράφου, ενώ οι σύγχρονες ετικέτες είναι διαθέσιμες μέσω του [Presentation.SensitivityLabels](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sensitivitylabels/). Χρησιμοποιήστε το [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/getsensitivitylabels/) για να διαβάσετε τα κληρονομικά μεταδεδομένα και να μεταφέρετε μόνο τις έγκυρες ετικέτες που δεν υπάρχουν ήδη στη σύγχρονη συλλογή.

**Τι συμβαίνει όταν μια ετικέτα με το ίδιο αναγνωριστικό προστίθεται περισσότερες από μία φορές;**

Το [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabelcollection/add/)  πετάει ένα `ArgumentException` όταν η συλλογή περιέχει ήδη μια ετικέτα με το ίδιο αναγνωριστικό. Ελέγξτε τις υπάρχουσες τιμές του [ISensitivityLabel.Id](https://reference.aspose.com/slides/el/net/aspose.slides/isensitivitylabel/id/) πριν προσθέσετε ή μεταφέρετε ετικέτες.

**Ποια μορφή εξόδου πρέπει να χρησιμοποιηθεί για τη διατήρηση των ενημερωμένων ετικετών ευαισθησίας;**

Αποθηκεύστε την παρουσίαση ως PPTX καλώντας το [IPresentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/save/) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/), όπως φαίνεται στα παραπάνω παραδείγματα.