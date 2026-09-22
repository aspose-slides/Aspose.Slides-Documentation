---
title: Καθορίστε το αρχικό μορφότυπο παρουσίασης στο .NET
linktitle: Μορφότυπος Πηγής
type: docs
weight: 35
url: /el/net/detect-presentation-source-format/
keywords:
- μορφότυπο πηγής
- ανίχνευση μορφώτυπου παρουσίασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Διαβάστε το αρχικό μορφότυπο μιας φορτωμένης παρουσίασης σε C# με Aspose.Slides για .NET, συγκρίνετε τα API ανίχνευσης και χειριστείτε αρχεία, ροές και παλαιές μορφές."
---
## **Επισκόπηση**

Μετά τη φόρτωση μιας παρουσίασης, διαβάστε την ιδιότητα μόνο για ανάγνωση [Presentation.SourceFormat](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sourceformat/) για να προσδιορίσετε το αρχικό της μορφότυπο. Η ιδιότητα είναι επίσης διαθέσιμη μέσω [IPresentation.SourceFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/sourceformat/). Χρησιμοποιήστε την όταν η επόμενη επεξεργασία εξαρτάται από τη μορφή από την οποία φορτώθηκε η τρέχουσα παρουσίαση.

Η μορφή προέλευσης διαφέρει από το [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/) που επιλέγεται για ένα αρχείο εξόδου. Η αποθήκευση σε διαφορετική μορφή δεν αλλάζει τη μορφή προέλευσης της υπάρχουσας παρουσίασης.

## **Ανάγνωση της μορφής προέλευσης ενός αρχείου**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pptx`. Φορτώνει το αρχείο και επιλέγει μια πολιτική επεξεργασίας της εφαρμογής χρησιμοποιώντας [Presentation.SourceFormat](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sourceformat/), αντί του ονόματος αρχείου. Αλλάξτε τη διαδρομή εισόδου για να δοκιμάσετε άλλες μορφές. Το παράδειγμα εκτυπώνει την επιλεγμένη πολιτική· αντικαταστήστε τα μηνύματα με τη λογική της εφαρμογής σας.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **Αναγνώριση των υποστηριζόμενων τιμών**

Η απαρίθμηση [SourceFormat](https://reference.aspose.com/slides/el/net/aspose.slides/sourceformat/) διακρίνει τις παρακάτω μορφές παρουσίασης. Οι παρακάτω καταλήξεις είναι συμβατικές, όχι ανακατασκευή του αρχικού ονόματος αρχείου.

| Τιμή SourceFormat | Κατάληξη | Μορφή |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 παρουσίαση |
| `Pptx` | `.pptx` | Παρουσίαση Office Open XML |
| `Pptm` | `.pptm` | Παρουσίαση Office Open XML με μακροεντολή |
| `Pps` | `.pps` | Παρουσίαση διαφανειών PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Παρουσίαση διαφανειών Office Open XML |
| `Ppsm` | `.ppsm` | Παρουσίαση διαφανειών Office Open XML με μακροεντολή |
| `Pot` | `.pot` | Πρότυπο PowerPoint 97–2003 |
| `Potx` | `.potx` | Πρότυπο Office Open XML |
| `Potm` | `.potm` | Πρότυπο Office Open XML με μακροεντολή |
| `Odp` | `.odp` | Παρουσίαση OpenDocument |
| `Otp` | `.otp` | Πρότυπο παρουσίασης OpenDocument |
| `Fodp` | `.fodp` | Παρουσίαση Flat XML ODF |
| `Xml` | `.xml` | Παρουσίαση PowerPoint XML |

## **Ανάγνωση της μορφής προέλευσης από ροή**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pps`. Η ανάγνωση των bytes του σε μνήμη‑ροή προσομοιώνει είσοδο που λαμβάνεται χωρίς όνομα αρχείου, όπως τιμή βάσης δεδομένων ή ανεβασμένο πίνακα byte. Ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) λαμβάνει μόνο τη ροή.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

Τα PPT, PPS και POT χρησιμοποιούν την ίδια υποκείμενη δυαδική μορφή. Κατά τη φόρτωση με διαδρομή αρχείου, η κατάληξη μπορεί να βοηθήσει στη διάκριση παρουσίασης διαφανειών ή προτύπου. Χωρίς όνομα αρχείου, το παλιό περιεχόμενο PPS και POT μπορεί να αναφερθεί ως `SourceFormat.Ppt`; το παράδειγμα PPS παραπάνω αναφέρει `Ppt`.

Εάν η εφαρμογή σας πρέπει να διατηρήσει τη διάκριση, κρατήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα υποτύπου ξεχωριστά. Μια κατάληξη είναι χρήσια υπόδειξη για αυτά τα παλιά υποτύπους, αλλά δεν πρέπει να είναι η μόνη βάση για την ταυτοποίηση τυχαίου περιεχομένου παρουσίασης.

## **Σύγκριση ανίχνευσης πριν και μετά τη φόρτωση**

Χρησιμοποιήστε το [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/getpresentationinfo/) και το [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/loadformat/) όταν χρειάζεται να ελέγξετε ένα αρχείο πριν τη φόρτωση του πλήρους μοντέλου αντικειμένων παρουσίασης. Χρησιμοποιήστε το [Presentation.SourceFormat](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sourceformat/) όταν η παρουσίαση υπάρχει ήδη.

Αυτό το παράδειγμα απαιτεί `sample.pptx` και εκτυπώνει `Pptx` για και τις δύο ελέγχους. Σε παραγωγή, επιλέξτε το κατάλληλο API για το στάδιο επεξεργασίας· μια ήδη φορτωμένη παρουσίαση δεν χρειάζεται δεύτερο έλεγχο μόνο για να λάβει τη μορφή προέλευσής της.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Τα αποτελέσματα έχουν διαφορετικούς τύπους απαρίθμησης: [LoadFormat](https://reference.aspose.com/slides/el/net/aspose.slides/loadformat/) και [SourceFormat](https://reference.aspose.com/slides/el/net/aspose.slides/sourceformat/). Μην τα συγκρίνετε μετατρέποντάς τα σε αριθμητικές τιμές ή υποθέστε ότι κάθε μορφή έχει τα ίδια αποτελέσματα ανίχνευσης. Στο έλεγχο αποθήκευσης‑επανάγνωσης που περιγράφεται παρακάτω, το PowerPoint XML αναφέρθηκε ως `LoadFormat.Unknown` πριν από τη φόρτωση και ως `SourceFormat.Xml` μετά τη φόρτωση.

## **Διατήρηση ξεχωριστών μορφών προέλευσης και εξόδου**

Αυτό το παράδειγμα απαιτεί `sample.pptx` και γράφει `converted.odp`. Εκτυπώνει `Pptx` πριν και μετά την αποθήκευση της αρχικής παρουσίασης. Μόνο η νέα παρουσίαση που φορτώνεται από την έξοδο ODP αναφέρει `Odp`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

Μια παρουσίαση που δημιουργείται από το μηδέν με `new Presentation()` αναφέρει `SourceFormat.Pptx`. Δεν έχει αρχείο εισόδου: αυτή είναι η προεπιλεγμένη τιμή για νέα παρουσίαση, όχι ένδειξη ότι φορτώθηκε αρχείο PPTX. Καταγράψτε αν η εφαρμογή δημιούργησε ή φόρτωσε την παρουσίαση ξεχωριστά εάν η διάκριση αυτή έχει σημασία.

## **Αντιστοίχιση μορφής προέλευσης σε κατάληξη**

Το παρακάτω παράδειγμα απαιτεί `sample.pptx`. Αντιστοιχίζει κάθε τρέχουσες υποστηριζόμενη τιμή [SourceFormat](https://reference.aspose.com/slides/el/net/aspose.slides/sourceformat/) σε συμβατική κατάληξη, χωρίς να αναλύσει το όνομα αρχείου εισόδου. Η εναλλακτική αποτρέπει την άπρακτη ανάθεση κατάληξης σε μη αναγνωρισμένη τιμή.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

Αυτή η αντιστοίχηση δεν μετατρέπει αρχείο ή δεν επανακτά παλαιό υποτύπο PPS/POT που χάθηκε κατά τη φόρτωση ροής. Για πραγματική αποθήκευση, επιλέξτε ρητά ένα [SaveFormat](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveformat/), ή χρησιμοποιήστε τη μετατροπή που φαίνεται στο [Save Presentations in Their Original Format](/slides/el/net/save-presentation/#save-presentations-in-their-original-format).

## **Επαλήθευση μορφών με αποθήκευση και επανάνοιγμα**

Αυτό το αυτόνομο παράδειγμα δημιουργεί μια παρουσίαση και γράφει τρία αρχεία στον τρέχοντα φάκελο, αντικαθιστώντας αρχεία με τα ίδια ονόματα. Ξαναφορτώνει κάθε έξοδο είτε με διαδρομή είτε μέσω μνήμης‑ροής. Για PPTX και ODP, και οι δύο διαδρομές αναφέρουν τη μορφή αποθηκευμένου αρχείου. Για PPS, η φόρτωση με διαδρομή αναφέρει `Pps`, ενώ η φόρτωση των ίδιων bytes χωρίς όνομα αρχείου αναφέρει `Ppt`.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

Ο ίδιος έλεγχος με όλες τις παραπάνω μορφές παρήγαγε τα παρακάτω αποτελέσματα για παρουσιάσεις που δημιουργήθηκαν με τις αντίστοιχες καταλήξεις:

| Αποθηκευμένη μορφή | SourceFormat από διαδρομή αρχείου | SourceFormat από ροή χωρίς όνομα |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| ODP, OTP | `Odp`, `Otp` αντίστοιχα | Ίδιο με τη διαδρομή αρχείου |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Σε αυτούς τους ελέγχους, η μοναδική κανονικοποίηση μορφής προέλευσης ήταν το PPS/POT σε `Ppt` για ροές χωρίς όνομα. Ο πίνακας περιγράφει την ταυτοποίηση μορφής, όχι τη διατήρηση όλων των χαρακτηριστικών της παρουσίασης κατά τη μετατροπή.

## **Συχνές ερωτήσεις**

**Αλλάζει η αποθήκευση σε ODP τη μορφή προέλευσης μιας παρουσίασης που φορτώθηκε από PPTX;**

Όχι. Η υπάρχουσα παρουσίαση εξακολουθεί να αναφέρει `Pptx`. Μια παρουσίαση που φορτώνεται από το αποθηκευμένο αρχείο ODP αναφέρει `Odp`.

**Μπορεί μια ροή πάντα να διακρίνει μια παλιά παρουσίαση, διαφάνεια και πρότυπο;**

Όχι. Τα PPT, PPS και POT μοιράζονται την δυαδική μορφή. Κρατήστε το όνομα αρχείου ή τα μεταδεδομένα υποτύπου ξεχωριστά όταν απαιτείται αυτή η διάκριση.

**Ποιο API πρέπει να χρησιμοποιήσω εάν η παρουσίαση είναι ήδη φορτωμένη;**

Διαβάστε το [Presentation.SourceFormat](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sourceformat/). Χρησιμοποιήστε το [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/getpresentationinfo/) για έλεγχο πριν τη φόρτωση.