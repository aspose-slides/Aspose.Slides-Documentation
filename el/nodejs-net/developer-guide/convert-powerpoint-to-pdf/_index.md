---
title: Μετατροπή PowerPoint σε PDF σε Node.js μέσω .NET
linktitle: PowerPoint σε PDF
type: docs
weight: 30
url: /el/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint σε PDF
- μετατροπή PowerPoint σε PDF
- PPTX σε PDF
- PPT σε PDF
- ODP σε PDF
- αποθήκευση παρουσίασης ως PDF
- PDF/A
- PdfOptions
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατροπή παρουσιάσεων PPTX, PPT και ODP σε PDF στη JavaScript με Aspose.Slides για Node.js μέσω .NET και δημιουργία αρχιβιακών αρχείων PDF/A με PdfOptions."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω .NET μετατρέπει παρουσιάσεις PowerPoint και OpenDocument σε PDF χωρίς το Microsoft PowerPoint. Κάθε ορατή διαφάνεια γίνεται μια σελίδα PDF του ίδιου μεγέθους με τη διαφάνεια, και το κείμενο παραμένει επιλέξιμο και αναζητήσιμο. Αυτό το άρθρο παρουσιάζει τη μετατροπή προεπιλογής και μια μετατροπή σε PDF/A με [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

Τα παραδείγματα αναμένουν μια παρουσίαση με όνομα `sample.pptx` στον φάκελο του έργου που έχετε ρυθμίσει στην [Installation](/slides/el/nodejs-net/installation/). Οποιαδήποτε παρουσίαση PowerPoint είναι αποδεκτή. Αποθηκεύστε κάθε παράδειγμα ως αρχείο `.js` στον φάκελο του έργου και εκτελέστε το από αυτόν τον φάκελο με `node`.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides για Node.js μέσω .NET δεν έχει τη δική του αναφορά API. Αντιγράφει το API του Aspose.Slides για .NET με ονόματα camelCase, έτσι οι σύνδεσμοι API σε αυτό το άρθρο οδηγούν στις αντίστοιχες κλάσεις και μέλη στην [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Μετατροπή Παρουσίασης σε PDF**

Για να μετατρέψετε μια παρουσίαση σε PDF, ακολουθήστε τα παρακάτω βήματα:

1. Ανοίξτε την παρουσίαση περνώντας τη διαδρομή της στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Η ίδια κώδικας λειτουργεί για αρχεία PPTX, PPT και ODP.  
1. Καλέστε τη μέθοδο [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) με τη διαδρομή εξόδου και `SaveFormat.Pdf`.  
1. Καλέστε το `dispose` σε ένα μπλοκ `finally` για να απελευθερώσετε τους πόρους .NET που υποστηρίζουν την παρουσίαση.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Το script γράφει το `sample.pdf` στον φάκελο του έργου. Η μετατροπή χρησιμοποιεί τις προεπιλεγμένες ρυθμίσεις: κάθε διαφάνεια που δεν είναι κρυφή γίνεται σελίδα, με τη σειρά των διαφάνειων. Χωρίς άδεια, κάθε σελίδα εμφανίζει επίσης υδατογράφημα αξιολόγησης· δείτε την [Licensing](/slides/el/nodejs-net/licensing/).

## **Μετατροπή Παρουσίασης σε PDF/A**

Για να ελέγξετε την έξοδο, περάστε ένα αντικείμενο [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) ως τρίτο όρισμα της `save`. Το παρακάτω παράδειγμα ορίζει την ιδιότητα [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) σε `PdfCompliance.PdfA2b`, η οποία παράγει ένα αρχείο PDF/A-2b. Το PDF/A είναι το πρότυπο ISO για μακροπρόθεσμη αρχειοθέτηση: μεταξύ άλλων κανόνων, απαιτεί κάθε γραμματοσειρά που χρησιμοποιεί το έγγραφο να ενσωματώνεται στο αρχείο.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Το script γράφει το `sample-pdfa.pdf` με τις ίδιες σελίδες όπως η προεπιλεγμένη μετατροπή. Για να επιβεβαιώσετε ότι ένα αρχείο συμμορφώνεται με το πρότυπο, ελέγξτε το με έναν ελεγκτή PDF/A όπως το [veraPDF](https://verapdf.org/). Άλλες τιμές του [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) επιλέγουν άλλα πρότυπα, όπως `PdfA1b`, `PdfA2a` ή `PdfUa` για προσβασιμότητα.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να συμπεριλάβω κρυφές διαφάνειες στο PDF;**

Οι κρυφές διαφάνειες παραλείπονται εξ ορισμού. Ορίστε την ιδιότητα [showHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) του `PdfOptions` σε `true` και περάστε τις επιλογές στη `save`.

**Μπορώ να προστατεύσω το PDF με κωδικό πρόσβασης;**

Ναι. Ορίστε την ιδιότητα [password](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/password/) του `PdfOptions` πριν καλέσετε τη `save`. Οι αναγνώστες PDF στη συνέχεια ζητούν αυτόν τον κωδικό πριν ανοίξουν το αρχείο.

**Μπορώ να μετατρέψω μόνο ορισμένες διαφάνειες;**

Ναι. Περάστε έναν πίνακα θέσεων διαφάνειας ως τέταρτο όρισμα της `save`. Οι θέσεις ξεκινάνε από 1, και το τρίτο όρισμα μπορεί να είναι `null` αν δεν χρειάζεστε επιλογές: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` γράφει ένα PDF με την πρώτη και την τρίτη διαφάνεια.

**Γιατί το κείμενο φαίνεται διαφορετικό όταν μετατρέπω σε Linux;**

Το Aspose.Slides μπορεί να χρησιμοποιήσει μόνο γραμματοσειρές που είναι εγκατεστημένες στο μηχάνημα που εκτελεί τη μετατροπή. Όταν μια παρουσίαση χρησιμοποιεί μια γραμματοσειρά που λείπει, όπως η Calibri σε έναν τυπικό διακομιστή Linux, το Aspose.Slides χρησιμοποιεί μια εγκατεστημένη γραμματοσειρά στη θέση της, γεγονός που μπορεί να αλλάξει την εμφάνιση του κειμένου και τη θέση των διακοπών γραμμών. Εγκαταστήστε τις γραμματοσειρές που χρησιμοποιούν οι παρουσιάσεις σας για να έχετε το ίδιο αποτέλεσμα όπως στα Windows.

**Μπορώ να λάβω το PDF ως Buffer αντί για αρχείο;**

Ναι. `presentation.saveToBuffer(SaveFormat.Pdf)` επιστρέφει το PDF ως Node.js `Buffer`, κάτι που είναι βολικό όταν στέλνετε το αποτέλεσμα σε απάντηση HTTP. Δέχεται επίσης `PdfOptions` ως δεύτερο όρισμα.