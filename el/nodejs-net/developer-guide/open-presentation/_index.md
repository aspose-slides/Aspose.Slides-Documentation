---
title: Άνοιγμα Παρουσιάσεων σε Node.js μέσω .NET
linktitle: Άνοιγμα Παρουσίασης
type: docs
weight: 20
url: /el/nodejs-net/open-presentation/
keywords:
- άνοιγμα παρουσίασης
- άνοιγμα PowerPoint
- άνοιγμα PPTX
- άνοιγμα PPT
- άνοιγμα ODP
- φόρτωση παρουσίασης
- παρουσίαση από buffer
- αριθμός διαφανειών
- μετατροπή παρουσίασης
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Ανοίξτε παρουσιάσεις PPTX, PPT και ODP σε JavaScript με Aspose.Slides για Node.js μέσω .NET: φόρτωση από διαδρομή αρχείου ή Buffer, ανάγνωση του αριθμού διαφανειών και αποθήκευση σε άλλη μορφή."
---
## **Επισκόπηση**

Aspose.Slides for Node.js via .NET ανοίγει παρουσιάσεις PowerPoint και OpenDocument, όπως αρχεία PPTX, PPT και ODP, από διαδρομή αρχείου ή από ένα Node.js `Buffer`. Αυτό το άρθρο δείχνει και τις δύο μεθόδους, διαβάζει τον αριθμό των διαφανειών και αποθηκεύει μια ανοιχτή παρουσίαση σε άλλη μορφή.

Τα παραδείγματα προϋποθέτουν μια παρουσίαση με όνομα `sample.pptx` στο φάκελο του έργου που έχετε ρυθμίσει στην [Εγκατάσταση](/slides/el/nodejs-net/installation/). Οποιαδήποτε παρουσίαση PowerPoint αρκεί. Αποθηκεύστε κάθε παράδειγμα ως αρχείο `.js` στο φάκελο του έργου και τρέξτε το από εκεί με `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET δεν διαθέτει ξεχωριστή τεκμηρίωση API. Αντιγράφει το API του Aspose.Slides for .NET με ονόματα camelCase, οπότε οι σύνδεσμοι API σε αυτό το άρθρο οδηγούν στις αντίστοιχες κλάσεις και μέλη στην [αναφορά API Aspose.Slides για .NET](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Άνοιγμα Παρουσίασης από Αρχείο**

Για να ανοίξετε μια παρουσίαση, περάστε τη διαδρομή της στο κατασκευαστή [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Το Aspose.Slides εντοπίζει τη μορφή από το περιεχόμενο του αρχείου αντί από την επέκταση, έτσι ο ίδιος κώδικας ανοίγει αρχεία PPTX, PPT και ODP. Μια σχετική διαδρομή λύνεται σε σχέση με τον τρέχοντα φάκελο εργασίας, που είναι ο φάκελος του έργου όταν εκτελείτε το σενάριο από εκεί.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Το σενάριο εκτυπώνει τον αριθμό των διαφανειών στο `sample.pptx`, για παράδειγμα `Slide count: 9`. Η ιδιότητα `count` της συλλογής των [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) περιλαμβάνει κρυμμένες διαφάνειες. Καλέστε `dispose` σε ένα μπλοκ `finally`, όπως φαίνεται, ώστε οι πόροι .NET που βρίσκονται πίσω από την παρουσίαση να απελευθερωθούν ακόμη και αν ο κώδικάς σας αποτύχει.

## **Άνοιγμα Παρουσίασης από Buffer**

Όταν μια παρουσίαση προέρχεται από βάση δεδομένων, μια μεταφόρτωση HTTP ή άλλη πηγή που σας δίνει bytes αντί για διαδρομή αρχείου, περάστε ένα Node.js `Buffer` ως το δεύτερο όρισμα του κατασκευαστή και `null` ως το πρώτο. Το παρακάτω παράδειγμα διαβάζει το `sample.pptx` σε ένα buffer για να προσομοιώσει τέτοια πηγή:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Το σενάριο εκτυπώνει τον ίδιο αριθμό διαφανειών με το προηγούμενο παράδειγμα. Το δεύτερο όρισμα πρέπει να είναι ένα `Buffer`. Για οποιονδήποτε άλλο τύπο, όπως ένα `Uint8Array`, ο κατασκευαστής δεν αναφέρει σφάλμα· δημιουργεί μια νέα παρουσίαση με μία κενή διαφάνεια. Μετατρέψτε άλλους δυαδικούς τύπους πρώτα με `Buffer.from`.

## **Αποθήκευση Παρουσίασης σε Άλλη Μορφή**

Για να μετατρέψετε μια παρουσίαση σε άλλη μορφή παρουσίασης, ανοίξτε την και αποθηκεύστε τη με διαφορετική τιμή του [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Το παρακάτω παράδειγμα εκτυπώνει τη μορφή που ανίχνευσε το Aspose.Slides, η οποία επιστρέφεται από την ιδιότητα [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/), και αποθηκεύει την παρουσίαση ως παρουσίαση OpenDocument:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Το σενάριο εκτυπώνει `Source format: Pptx` και γράφει το `sample.odp`, που περιέχει τις ίδιες διαφάνειες. Η `sourceFormat` επιστρέφει `Ppt`, `Pptx` ή `Odp`. Για αποθήκευση ως PDF ή ως εικόνες, δείτε [Convert PowerPoint to PDF](/slides/el/nodejs-net/convert-powerpoint-to-pdf/) και [Convert Slides to Images](/slides/el/nodejs-net/convert-slide/).

## **Συχνές Ερωτήσεις**

**Πώς ανοίγω μια παρουσίαση με προστασία κωδικού πρόσβασης;**

Δημιουργήστε ένα αντικείμενο [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), ορίστε την ιδιότητα [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) του, και περάστε το αντικείμενο ως τρίτο όρισμα του κατασκευαστή: `new Presentation("protected.pptx", null, loadOptions)`. Χωρίς τον σωστό κωδικό, ο κατασκευαστής ρίχνει σφάλμα.

**Γιατί ο κατασκευαστής ρίχνει ένα `Error` με κενό μήνυμα;**

Όταν ο κατασκευαστής `Presentation` αποτυγχάνει σε .NET, για παράδειγμα επειδή λείπει το αρχείο, δεν είναι παρουσίαση ή απαιτεί διαφορετικό κωδικό πρόσβασης, η JavaScript λαμβάνει ένα `Error` του οποίου το μήνυμα είναι κενό. Πριν ανοίξετε ένα αρχείο, ελέγξτε ότι υπάρχει σχετικό προς τον τρέχοντα φάκελο εργασίας, για παράδειγμα με `fs.existsSync`.

**Ποιες μορφές μπορώ να ανοίξω;**

Μορφές παρουσίασης PowerPoint και OpenDocument, συμπεριλαμβανομένων των PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP και FODP.