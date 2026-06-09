---
title: Διαχείριση έργων VBA σε παρουσιάσεις χρησιμοποιώντας JavaScript
linktitle: Παρουσίαση μέσω VBA
type: docs
weight: 250
url: /el/nodejs-java/presentation-via-vba/
keywords:
- μακροεντολή
- VBA
- μακροεντολή VBA
- προσθήκη μακροεντολής
- κατάργηση μακροεντολής
- εξαγωγή μακροεντολής
- προσθήκη VBA
- κατάργηση VBA
- εξαγωγή VBA
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε και επεξεργαστείτε παρουσιάσεις PowerPoint και OpenDocument μέσω VBA σε JavaScript με το Aspose.Slides για Node.js μέσω Java, ώστε να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Aspose.Slides παρέχει κλάσεις για εργασία με μακροεντολές και κώδικα VBA.

{{% alert title="Note" color="warning" %}} 

Όταν μετατρέπετε μια παρουσίαση που περιέχει μακροεντολές σε διαφορετική μορφή αρχείου (PDF, HTML κ.λπ.), το Aspose.Slides αγνοεί όλες τις μακροεντολές (οι μακροεντολές δεν μεταφέρονται στο παραγόμενο αρχείο).

Όταν προσθέτετε μακροεντολές σε μια παρουσίαση ή αποθηκεύετε ξανά μια παρουσίαση που περιέχει μακροεντολές, το Aspose.Slides απλώς γράφει τα byte των μακροεντολών.

Το Aspose.Slides **ποτέ** δεν εκτελεί τις μακροεντολές σε μια παρουσίαση.

{{% /alert %}}

## **Προσθήκη VBA Μακροεντολών**

Το Aspose.Slides παρέχει την κλάση [VbaProject](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/vbaproject/) για να σας επιτρέψει να δημιουργήσετε έργα VBA (και αναφορές έργου) και να επεξεργαστείτε υπάρχουσες μονάδες. Μπορείτε να χρησιμοποιήσετε την κλάση [VbaProject](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/vbaproject/) για να διαχειριστείτε το VBA ενσωματωμένο σε μια παρουσίαση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation).
1. Χρησιμοποιήστε τον κατασκευαστή [VbaProject](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/vbaproject/#VbaProject--) για να προσθέσετε ένα νέο έργο VBA.
1. Προσθέστε μια μονάδα στο VbaProject.
1. Ορίστε τον πηγαίο κώδικα της μονάδας.
1. Προσθέστε αναφορές στο <stdole>.
1. Προσθέστε αναφορές στο **Microsoft Office**.
1. Συσχετίστε τις αναφορές με το έργο VBA.
1. Αποθηκεύστε την παρουσίαση.

```javascript
// Δημιουργεί ένα στιγμιότυπο της κλάσης παρουσίασης
let pres = new aspose.slides.Presentation();
try {
    // Δημιουργεί ένα νέο έργο VBA
    pres.setVbaProject(new aspose.slides.VbaProject());
    // Προσθέτει μια κενή μονάδα στο έργο VBA
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // Ορίζει τον πηγαίο κώδικα της μονάδας
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // Δημιουργεί μια αναφορά στο <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Δημιουργεί μια αναφορά στο Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // Προσθέτει αναφορές στο έργο VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // Αποθηκεύει την παρουσίαση
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

Ίσως θελήσετε να δείτε το **Aspose** [Macro Remover](https://products.aspose.app/slides/el/remove-macros), μια δωρεάν διαδικτυακή εφαρμογή που χρησιμοποιείται για την αφαίρεση μακροεντολών από έγγραφα PowerPoint, Excel και Word.

{{% /alert %}} 

## **Κατάργηση VBA Μακροεντολών**

Χρησιμοποιώντας την ιδιότητα [VbaProject](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getVbaProject--) της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation), μπορείτε να καταργήσετε μια μακροεντολή VBA.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
1. Πρόσβαση στη μονάδα Macro και κατάργησή της.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```javascript
// Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Πρόσβαση στη μονάδα Vba και κατάργησή της
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // Αποθηκεύει την παρουσίαση
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Εξαγωγή VBA Μακροεντολών**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει ένα έργο VBA.
3. Περιηγηθείτε σε όλες τις μονάδες που περιέχονται στο έργο VBA για να δείτε τις μακροεντολές.

```javascript
// Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Ελέγχει αν η παρουσίαση περιέχει έργο VBA
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Έλεγχος αν ένα έργο VBA είναι προστατευμένο με κωδικό**

Χρησιμοποιώντας τη μέθοδο [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected), μπορείτε να προσδιορίσετε εάν οι ιδιότητες ενός έργου είναι προστατευμένες με κωδικό.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και φορτώστε μια παρουσίαση που περιέχει μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει ένα [VBA project](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/vbaproject/).
3. Ελέγξτε αν το έργο VBA είναι προστατευμένο με κωδικό για να δείτε τις ιδιότητές του.

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Ελέγχει αν η παρουσίαση περιέχει έργο VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Συχνές ερωτήσεις**

**Τι συμβαίνει με τις μακροεντολές αν αποθηκεύσω την παρουσίαση ως PPTX;**

Οι μακροεντολές θα αφαιρεθούν επειδή το PPTX δεν υποστηρίζει VBA. Για να διατηρήσετε τις μακροεντολές, επιλέξτε PPTM, PPSM ή POTM.

**Μπορεί το Aspose.Slides να εκτελεί μακροεντολές μέσα σε μια παρουσίαση, για παράδειγμα, να ανανεώνει δεδομένα;**

Όχι. Η βιβλιοθήκη ποτέ δεν εκτελεί κώδικα VBA· η εκτέλεση είναι δυνατή μόνο μέσα στο PowerPoint με τις κατάλληλες ρυθμίσεις ασφαλείας.

**Υποστηρίζεται η εργασία με ελέγχους ActiveX που συνδέονται με κώδικα VBA;**

Ναι, μπορείτε να αποκτήσετε πρόσβαση σε υπάρχοντες [ActiveX controls](/slides/el/nodejs-java/activex/), να τροποποιήσετε τις ιδιότητές τους και να τους αφαιρέσετε. Αυτό είναι χρήσιμο όταν οι μακροεντολές αλληλεπιδρούν με το ActiveX.