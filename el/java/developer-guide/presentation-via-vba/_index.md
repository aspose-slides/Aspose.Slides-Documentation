---
title: Διαχείριση έργων VBA σε παρουσιάσεις χρησιμοποιώντας Java
linktitle: Παρουσίαση μέσω VBA
type: docs
weight: 250
url: /el/java/presentation-via-vba/
keywords:
- μακροεντολή
- VBA
- μακροεντολή VBA
- προσθήκη μακροεντολής
- αφαίρεση μακροεντολής
- εξαγωγή μακροεντολής
- προσθήκη VBA
- αφαίρεση VBA
- εξαγωγή VBA
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργήσετε και να διαχειριστείτε παρουσιάσεις PowerPoint και OpenDocument μέσω VBA με το Aspose.Slides για Java, ώστε να βελτιώσετε τη ροή εργασιών σας."
---
## **Εισαγωγή**

Aspose.Slides παρέχει κλάσεις και διεπαφές για εργασία με μακροεντολές και κώδικα VBA.

{{% alert title="Note" color="warning" %}} 

Όταν μετατρέπετε μια παρουσίαση που περιέχει μακροεντολές σε διαφορετική μορφή αρχείου (PDF, HTML κ.λπ.), το Aspose.Slides αγνοεί όλες τις μακροεντολές (οι μακροεντολές δεν μεταφέρονται στο παραγόμενο αρχείο).

Όταν προσθέτετε μακροεντολές σε μια παρουσίαση ή επανασώζετε μια παρουσίαση που περιέχει μακροεντολές, το Aspose.Slides απλώς γράφει τα byte των μακροεντολών.

Το Aspose.Slides **ποτέ** δεν εκτελεί τις μακροεντολές σε μια παρουσίαση.

{{% /alert %}}

## **Προσθήκη Μακροεντολών VBA**

Το Aspose.Slides παρέχει την κλάση [VbaProject](https://reference.aspose.com/slides/el/java/com.aspose.slides/vbaproject/) ώστε να δημιουργήσετε έργα VBA (και αναφορές έργου) και να επεξεργαστείτε υπάρχοντα modules. Μπορείτε να χρησιμοποιήσετε τη διεπαφή [IVbaProject](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivbaproject/) για να διαχειριστείτε το VBA που είναι ενσωματωμένο σε μια παρουσίαση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation).
1. Χρησιμοποιήστε τον κατασκευαστή [VbaProject](https://reference.aspose.com/slides/el/java/com.aspose.slides/vbaproject/#VbaProject--) για να προσθέσετε ένα νέο έργο VBA.
1. Προσθέστε ένα module στο VbaProject.
1. Ορίστε τον πηγαίο κώδικα του module.
1. Προσθέστε αναφορές στο <stdole>.
1. Προσθέστε αναφορές στο **Microsoft Office**.
1. Συσχετίστε τις αναφορές με το έργο VBA.
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε μια μακροεντολή VBA από το μηδέν σε μια παρουσίαση:

```java
// Δημιουργεί μια παρουσία της κλάσης παρουσίασης
Presentation pres = new Presentation();
try {
    // Δημιουργεί ένα νέο έργο VBA
    pres.setVbaProject(new VbaProject());
    
    // Προσθέτει ένα κενό module στο έργο VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Ορίζει τον πηγαίο κώδικα του module
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

Μπορείτε να θέλετε να δοκιμάσετε το **Aspose** [Macro Remover](https://products.aspose.app/slides/el/remove-macros), μια δωρεάν διαδικτυακή εφαρμογή που χρησιμοποιείται για την αφαίρεση μακροεντολών από αρχεία PowerPoint, Excel και Word. 

{{% /alert %}} 

## **Αφαίρεση Μακροεντολών VBA**

Χρησιμοποιώντας την ιδιότητα [VbaProject](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#getVbaProject--) της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation), μπορείτε να αφαιρέσετε μια μακροεντολή VBA.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
1. Αποκτήστε πρόσβαση στο module Macro και αφαιρέστε το.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να αφαιρέσετε μια μακροεντολή VBA:

```java
// Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
// Πρόσβαση στο module Vba και αφαίρεσή του 
// Αποθηκεύει την παρουσίαση
Presentation pres = new Presentation("VBA.pptm");
try {
    // Accesses the Vba module and removes it 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Saves the Presentation
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εξαγωγή Μακροεντολών VBA**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει έργο VBA.
3. Περιηγηθείτε σε όλα τα modules που περιέχονται στο έργο VBA για να προβάλετε τις μακροεντολές.

Αυτός ο κώδικας Java δείχνει πώς να εξαγάγετε μακροεντολές VBA από μια παρουσίαση που περιέχει μακροεντολές:

```java
// Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // Ελέγχει αν η παρουσίαση περιέχει έργο VBA
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

## **Έλεγχος αν ένα Έργο VBA είναι Προστατευμένο με Κωδικό**

Χρησιμοποιώντας τη μέθοδο [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/el/java/com.aspose.slides/ivbaproject/#isPasswordProtected--) μπορείτε να προσδιορίσετε αν οι ιδιότητες ενός έργου είναι προστατευμένες με κωδικό.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) και φορτώστε μια παρουσίαση που περιέχει μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει [VBA project](https://reference.aspose.com/slides/el/java/com.aspose.slides/vbaproject/).
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

**Τι συμβαίνει με τις μακροεντολές όταν αποθηκεύω την παρουσίαση ως PPTX;**

Οι μακροεντολές θα αφαιρεθούν επειδή το PPTX δεν υποστηρίζει VBA. Για να διατηρήσετε τις μακροεντολές, επιλέξτε PPTM, PPSM ή POTM.

**Μπορεί το Aspose.Slides να εκτελεί μακροεντολές μέσα σε μια παρουσίαση, π.χ., για να ανανεώσει δεδομένα;**

Όχι. Η βιβλιοθήκη δεν εκτελεί ποτέ κώδικα VBA· η εκτέλεση είναι δυνατή μόνο μέσα στο PowerPoint με τις κατάλληλες ρυθμίσεις ασφαλείας.

**Υποστηρίζεται η εργασία με ελέγχους ActiveX που συνδέονται με κώδικα VBA;**

Ναι, μπορείτε να προσπελάσετε υπάρχοντες [ActiveX controls](/slides/el/java/activex/), να τροποποιήσετε τις ιδιότητές τους και να τους αφαιρέσετε. Αυτό είναι χρήσιμο όταν οι μακροεντολές αλληλεπιδρούν με το ActiveX.