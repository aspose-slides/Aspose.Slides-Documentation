---
title: "Διαχείριση κειμένου παρουσίασης σε Node.js μέσω .NET"
linktitle: "Διαχείριση κειμένου"
type: docs
weight: 50
url: /el/nodejs-net/manage-text/
keywords:
- κείμενο
- πλαίσιο κειμένου
- προσθήκη κειμένου
- αλλαγή κειμένου
- μορφοποίηση κειμένου
- μέγεθος γραμματοσειράς
- έντονο κείμενο
- πλαίσιο κειμένου
- παράγραφος
- τμήμα
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Προσθέστε ένα πλαίσιο κειμένου σε μια διαφάνεια, στη συνέχεια αλλάξτε το κείμενό του, το μέγεθος γραμματοσειράς και το έντονο στυλ σε JavaScript με το Aspose.Slides για Node.js μέσω .NET."
---
## **Επισκόπηση**

Στο Aspose.Slides, το κείμενο σε μια διαφάνεια ανήκει σε ένα σχήμα. Ένα αυτόματο σχήμα, όπως ένα ορθογώνιο, διαθέτει ένα πλαίσιο κειμένου· το πλαίσιο κειμένου περιέχει παραγράφους και κάθε παράγραφος περιέχει τμήματα, τα οποία είναι τμήματα κειμένου με την ίδια μορφοποίηση. Αλλάζετε το κείμενο μέσω του πλαισίου κειμένου και τη γραμματοσειρά μέσω της μορφής ενός τμήματος.

Αυτό το άρθρο προσθέτει ένα πλαίσιο κειμένου σε μια διαφάνεια και αποθηκεύει την παρουσίαση. Στη συνέχεια, ανοίγει το αποθηκευμένο αρχείο και αλλάζει το κείμενο του πλαισίου, το μέγεθος γραμματοσειράς και το έντονο στυλ.

Τα παραδείγματα απαιτούν ένα έργο ρυθμισμένο όπως περιγράφεται στην [Εγκατάσταση](/slides/el/nodejs-net/installation/). Αποθηκεύστε κάθε παράδειγμα ως αρχείο `.js` στον φάκελο του έργου και εκτελέστε το από αυτόν το φάκελο με την εντολή `node`.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides για Node.js μέσω .NET δεν διαθέτει δική του αναφορά API. Αντιγράφει το API του Aspose.Slides για .NET με ονόματα camelCase, έτσι οι σύνδεσμοι API σε αυτό το άρθρο οδηγούν στις αντίστοιχες κλάσεις και μέλη στην [Αναφορά API του Aspose.Slides για .NET](https://reference.aspose.com/slides/el/net/).
{{% /alert %}}

## **Προσθήκη πλαισίου κειμένου**

Για να προσθέσετε ένα πλαίσιο κειμένου, προσθέστε ένα αυτόματο σχήμα σε μια διαφάνεια με τη μέθοδο [addAutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/shapecollection/addautoshape/) και δώστε του κείμενο με τη μέθοδο [addTextFrame](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/addtextframe/). Το παρακάτω παράδειγμα προσθέτει ένα ορθογώνιο στην πρώτη διαφάνεια μιας νέας παρουσίασης και αποθηκεύει την παρουσίαση ως `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Η θέση (x, y) και το μέγεθος (πλάτος, ύψος) είναι σε μονάδες σημείου.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

Η διαφάνεια στο `text-box.pptx` περιέχει ένα ορθογώνιο, 500 σημεία πλάτος και 80 σημεία ύψος, με το κείμενο "Quarterly report" στην προεπιλεγμένη γραμματοσειρά και μέγεθος. Το επόμενο παράδειγμα αλλάζει αυτό το πλαίσιο κειμένου.

## **Αλλαγή του κειμένου και της μορφοποίησής του**

Το παρακάτω παράδειγμα ανοίγει το `text-box.pptx`, το οποίο δημιούργησε το προηγούμενο παράδειγμα, και λαμβάνει το πρώτο σχήμα στην πρώτη διαφάνεια. Σχήματα όπως εικόνες και πίνακες δεν διαθέτουν πλαίσιο κειμένου, έτσι το παράδειγμα ελέγχει ότι το σχήμα είναι ένα [AutoShape](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/) πριν χρησιμοποιήσει το [textFrame](https://reference.aspose.com/slides/el/net/aspose.slides/autoshape/textframe/) του σχήματος. Στη συνέχεια, κάνει τα εξής:

1. Αντικαθιστά το κείμενο μέσω της ιδιότητας [text](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/text/) του πλαισίου κειμένου. Μετά από αυτό, το πλαίσιο κειμένου περιέχει μία παράγραφο με ένα τμήμα.
2. Αποκτά αυτό το τμήμα από τις συλλογές [paragraphs](https://reference.aspose.com/slides/el/net/aspose.slides/textframe/paragraphs/) και [portions](https://reference.aspose.com/slides/el/net/aspose.slides/paragraph/portions/) και διαβάζει το [portionFormat](https://reference.aspose.com/slides/el/net/aspose.slides/portion/portionformat/).
3. Ορίζει το [fontHeight](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/fontheight/), το μέγεθος γραμματοσειράς σε σημεία, και το [fontBold](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/fontbold/), το οποίο δέχεται μια τιμή [NullableBool](https://reference.aspose.com/slides/el/net/aspose.slides/nullablebool/).

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

Στο `text-box-updated.pptx`, το πλαίσιο κειμένου εμφανίζει το "Quarterly report: third quarter" με έντονη γραμματοσειρά 32 σημείων. Επειδή το νέο κείμενο είναι ένα μονό τμήμα, οι δύο ιδιότητες μορφοποίησης ισχύουν σε όλο του. Χωρίς άδεια, κάθε αποθήκευση προσθέτει ένα υδατογράφημα αξιολόγησης. Επειδή το `text-box.pptx` αποθηκεύτηκε ήδη σε λειτουργία αξιολόγησης, το `text-box-updated.pptx` περιέχει δύο· δείτε την ενότητα [Αξιολόγηση Aspose.Slides](/slides/el/nodejs-net/evaluate-aspose-slides/).

## **Συχνές ερωτήσεις**

**Γιατί το `fontBold` δέχεται μια τιμή `NullableBool` αντί για `true` ή `false`;**

Ένα τμήμα μπορεί να αφήσει μια ιδιότητα ακαθόριστη και να την κληρονομήσει από την παράγραφο, το σχήμα ή τη διάταξη και το master της διαφάνειας. `NullableBool.NotDefined` σημαίνει «κληρονομεί», ενώ `NullableBool.True` και `NullableBool.False` αντικαθιστούν την κληρονομημένη τιμή. Η ανάθεση `true` ή `false` προκαλεί σφάλμα. Για τον ίδιο λόγο, το `fontHeight` επιστρέφει `NaN` όταν το τμήμα κληρονομεί το μέγεθος γραμματοσειράς.

**Πώς μπορώ να αλλάξω το χρώμα του κειμένου;**

Ορίστε τη γέμιση της μορφής του τμήματος: εκχωρήστε `FillType.Solid` στο `portionFormat.fillFormat.fillType` και, στη συνέχεια, εκχωρήστε ένα χρώμα όπως `"#FF0000"` στο `portionFormat.fillFormat.solidFillColor.color`. Προσθέστε το `FillType` στα ονόματα που εισάγετε από το πακέτο.

**Πώς μορφοποιώ μόνο ένα μέρος του κειμένου;**

Η μορφοποίηση ανήκει στα τμήματα, οπότε τοποθετήστε αυτό το μέρος του κειμένου σε δικό του τμήμα. Δημιουργήστε το τμήμα με το `Portion.CreatePortionFromText`, προσθέστε το σε μια παράγραφο με τη μέθοδο `add` της συλλογής `portions` της παραγράφου, και στη συνέχεια ορίστε το `portionFormat` του νέου τμήματος. Προσθέστε το `Portion` στα ονόματα που εισάγετε από το πακέτο.

**Γιατί η ανάγνωση κειμένου επιστρέφει "... text has been truncated due to evaluation version limitation";**

Χωρίς άδεια, το Aspose.Slides επιστρέφει μόνο τους πρώτους πέντε χαρακτήρες οποιουδήποτε μεγαλύτερου κειμένου που διαβάζετε, όπως το `textFrame.text`, ακολουθούμενο από αυτήν την ειδοποίηση. Το κείμενο που γράφετε αποθηκεύεται πλήρως. Εφαρμόστε μια άδεια όπως περιγράφεται στην [Αδειοδότηση](/slides/el/nodejs-net/licensing/) για να διαβάσετε το πλήρες κείμενο.