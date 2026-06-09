---
title: Διαχείριση έργων VBA σε παρουσιάσεις στο Android
linktitle: Παρουσίαση μέσω VBA
type: docs
weight: 250
url: /el/androidjava/presentation-via-vba/
keywords:
- μακροεντολή
- VBA
- Μακροεντολή VBA
- Προσθήκη μακροεντολής
- Αφαίρεση μακροεντολής
- Εξαγωγή μακροεντολής
- Προσθήκη VBA
- Αφαίρεση VBA
- Εξαγωγή VBA
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργείτε και να διαχειρίζεστε παρουσιάσεις PowerPoint και OpenDocument μέσω VBA με το Aspose.Slides για Android μέσω Java για να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Aspose.Slides παρέχει κλάσεις και διεπαφές για εργασία με μακροεντολές και κώδικα VBA.

{{% alert title="Note" color="warning" %}} 

Όταν μετατρέπετε μια παρουσίαση που περιέχει μακροεντολές σε διαφορετική μορφή αρχείου (PDF, HTML κλπ.), το Aspose.Slides αγνοεί όλες τις μακροεντολές (οι μακροεντολές δεν μεταφέρονται στο παραγόμενο αρχείο).

Όταν προσθέτετε μακροεντολές σε μια παρουσίαση ή επανασSaving μια παρουσίαση που περιέχει μακροεντολές, το Aspose.Slides απλώς γράφει τα byte των μακροεντολών.

Το Aspose.Slides **ποτέ** δεν εκτελεί τις μακροεντολές σε μια παρουσίαση.

{{% /alert %}}

## **Προσθήκη VBA Μακροεντολών**

Το Aspose.Slides παρέχει την κλάση [VbaProject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/vbaproject/) για να μπορείτε να δημιουργήσετε έργα VBA (και αναφορές έργου) και να επεξεργαστείτε υπάρχοντα modules. Μπορείτε να χρησιμοποιήσετε το interface [IVbaProject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivbaproject/) για να διαχειριστείτε VBA ενσωματωμένα σε μια παρουσίαση.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Χρησιμοποιήστε τον κατασκευαστή [VbaProject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/vbaproject/#VbaProject--) για να προσθέσετε ένα νέο έργο VBA.
1. Προσθέστε ένα module στο VbaProject.
1. Ορίστε τον πηγαίο κώδικα του module.
1. Προσθέστε αναφορές στο <stdole>.
1. Προσθέστε αναφορές στο **Microsoft Office**.
1. Συνδέστε τις αναφορές με το έργο VBA.
1. Αποθηκεύστε την παρουσίαση.

```java
// Δημιουργεί ένα στιγμιότυπο της κλάσης παρουσίασης
Presentation pres = new Presentation();
try {
    // Δημιουργεί ένα νέο έργο VBA
    pres.setVbaProject(new VbaProject());
    
    // Προσθέτει ένα κενό module στο έργο VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Ορίζει τον κώδικα πηγής του module
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // Δημιουργεί μια αναφορά στο <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // Δημιουργεί μια αναφορά στο Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // Προσθέτει αναφορές στο έργο VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // Αποθηκεύει την παρουσίαση
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

Μπορεί να θέλετε να δείτε το **Aspose** [Macro Remover](https://products.aspose.app/slides/el/remove-macros), μια δωρεάν διαδικτυακή εφαρμογή για την αφαίρεση μακροεντολών από αρχεία PowerPoint, Excel και Word.

{{% /alert %}} 

## **Αφαίρεση VBA Μακροεντολών**

Χρησιμοποιώντας την ιδιότητα [VbaProject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getVbaProject--) στην κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation), μπορείτε να αφαιρέσετε μια μακροεντολή VBA.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
1. Προσπελάστε το module Macro και αφαιρέστε το.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```java
// Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
Presentation pres = new Presentation("VBA.pptm");
try {
    // Προσπελάζει το module Vba και το αφαιρεί 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Αποθηκεύει την παρουσίαση
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εξαγωγή VBA Μακροεντολών**

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει Έργο VBA.
3. Επανάλαβε όλα τα modules που περιέχονται στο Έργο VBA για να προβάλεις τις μακροεντολές.

```java
// Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Ελέγχει αν η Παρουσίαση περιέχει Έργο VBA
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Έλεγχος αν Έργο VBA είναι Προστατευμένο με Κωδικό**

Χρησιμοποιώντας τη μέθοδο [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--), μπορείτε να καθορίσετε αν οι ιδιότητες ενός έργου είναι προστατευμένες με κωδικό.

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) και φορτώστε μια παρουσίαση που περιέχει μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει [VBA project](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/vbaproject/).
3. Ελέγξτε αν το έργο VBA είναι προστατευμένο με κωδικό για να προβάλετε τις ιδιότητές του.

```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // Ελέγχει αν η παρουσίαση περιέχει έργο VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Τι γίνεται με τις μακροεντολές αν αποθηκεύσω την παρουσίαση ως PPTX;**

Οι μακροεντολές θα αφαιρεθούν επειδή το PPTX δεν υποστηρίζει VBA. Για να διατηρήσετε τις μακροεντολές, επιλέξτε PPTM, PPSM ή POTM.

**Μπορεί το Aspose.Slides να εκτελεί μακροεντολές μέσα σε μια παρουσίαση, για παράδειγμα, ώστε να ανανεώνει δεδομένα;**

Όχι. Η βιβλιοθήκη δεν εκτελεί ποτέ κώδικα VBA· η εκτέλεση είναι δυνατή μόνο μέσα στο PowerPoint με τις κατάλληλες ρυθμίσεις ασφαλείας.

**Υποστηρίζεται η εργασία με ελέγχους ActiveX συνδεδεμένους με κώδικα VBA;**

Ναι, μπορείτε να έχετε πρόσβαση σε υπάρχοντες [ActiveX controls](/slides/el/androidjava/activex/), να τροποποιήσετε τις ιδιότητές τους και να τους αφαιρέσετε. Αυτό είναι χρήσιμο όταν οι μακροεντολές αλληλεπιδρούν με ActiveX.