---
title: Διαχείριση έργων VBA σε παρουσιάσεις στο Android
linktitle: Παρουσίαση μέσω VBA
type: docs
weight: 250
url: /el/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργείτε και να διαχειρίζεστε παρουσιάσεις PowerPoint και OpenDocument μέσω VBA με το Aspose.Slides για Android μέσω Java, ώστε να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Aspose.Slides παρέχει κλάσεις και διεπαφές για εργασία με μακροεντολές και κώδικα VBA.

{{% alert title="Σημείωση" color="warning" %}} 

Όταν μετατρέπετε μια παρουσίαση που περιέχει μακροεντολές σε διαφορετική μορφή αρχείου (PDF, HTML κ.λπ.), το Aspose.Slides αγνοεί όλες τις μακροεντολές (οι μακροεντολές δεν μεταφέρονται στο προκύπτον αρχείο).

Όταν προσθέτετε μακροεντολές σε μια παρουσίαση ή αποθηκεύετε ξανά μια παρουσίαση που περιέχει μακροεντολές, το Aspose.Slides απλώς γράφει τα byte των μακροεντολών.

Το Aspose.Slides **ποτέ** δεν εκτελεί τις μακροεντολές σε μια παρουσίαση.

{{% /alert %}}

## **Προσθήκη Μακροεντολών VBA**

Το Aspose.Slides παρέχει την κλάση [VbaProject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/vbaproject/) ώστε να σας επιτρέψει να δημιουργήσετε έργα VBA (και αναφορές έργου) και να επεξεργαστείτε υπάρχουσες μονάδες. Μπορείτε να χρησιμοποιήσετε τη διεπαφή [IVbaProject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivbaproject/) για να διαχειριστείτε το ενσωματωμένο VBA σε μια παρουσίαση.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation).
1. Χρησιμοποιήστε τον κατασκευαστή [VbaProject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/vbaproject/#VbaProject--) για να προσθέσετε ένα νέο έργο VBA.
1. Προσθέστε μια μονάδα στο VbaProject.
1. Ορίστε τον πηγαίο κώδικα της μονάδας.
1. Προσθέστε αναφορές στο <stdole>.
1. Προσθέστε αναφορές στο **Microsoft Office**.
1. Συνδέστε τις αναφορές με το έργο VBA.
1. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας Java δείχνει πώς να προσθέσετε μια μακροεντολή VBA από την αρχή σε μια παρουσίαση:

```java
import com.aspose.slides.*;

// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
Presentation pres = new Presentation();
try {
    // Δημιουργεί ένα νέο έργο VBA
    pres.setVbaProject(new VbaProject());
    
    // Προσθέτει μια κενή μονάδα στο έργο VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // Ορίζει τον πηγαίο κώδικα της μονάδας
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

{{% alert color="info" %}} 

Μπορείτε να θέλετε να δοκιμάσετε το **Aspose** [Macro Remover](https://products.aspose.app/slides/el/remove-macros), μια δωρεάν διαδικτυακή εφαρμογή που χρησιμοποιείται για την αφαίρεση μακροεντολών από αρχεία PowerPoint, Excel και Word.

{{% /alert %}} 

## **Αφαίρεση Μακροεντολών VBA**

Χρησιμοποιώντας την ιδιότητα [VbaProject](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#getVbaProject--) στην κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation), μπορείτε να αφαιρέσετε μια μακροεντολή VBA.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation] και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
1. Προσπελάστε τη μονάδα Macro και αφαιρέστε την.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```java
import com.aspose.slides.*;

// Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
Presentation pres = new Presentation("VBA.pptm");
try {
    // Πρόσβαση στη μονάδα Vba και αφαίρεσή της
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // Αποθηκεύει την παρουσίαση
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Εξαγωγή Μακροεντολών VBA**

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation] και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει έργο VBA.
3. Διέλθετε όλες τις μονάδες που περιέχονται στο έργο VBA για να δείτε τις μακροεντολές.

Αυτός ο κώδικας Java δείχνει πώς να εξάγετε μακροεντολές VBA από μια παρουσίαση που περιέχει μακροεντολές:

```java
import com.aspose.slides.*;

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

## **Έλεγχος Αν Ένα Έργο VBA Είναι Προστατευμένο Με Κωδικό**

Χρησιμοποιώντας τη μέθοδο [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) μπορείτε να προσδιορίσετε εάν οι ιδιότητες ενός έργου είναι προστατευμένες με κωδικό.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Presentation] και φορτώστε μια παρουσίαση που περιέχει μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει [VBA project](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/vbaproject/).
3. Ελέγξτε αν το έργο VBA είναι προστατευμένο με κωδικό για να δείτε τις ιδιότητές του.

```java
import com.aspose.slides.*;

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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

### Τι συμβαίνει με τις μακροεντολές αν αποθηκεύσω την παρουσίαση ως PPTX;

Οι μακροεντολές θα αφαιρεθούν γιατί το PPTX δεν υποστηρίζει VBA. Για να διατηρήσετε τις μακροεντολές, επιλέξτε PPTM, PPSM ή POTM.

### Μπορεί το Aspose.Slides να εκτελεί μακροεντολές μέσα σε μια παρουσίαση, για παράδειγμα, να ανανεώνει δεδομένα;

Όχι. Η βιβλιοθήκη δεν εκτελεί ποτέ κώδικα VBA· η εκτέλεση είναι δυνατή μόνο μέσα στο PowerPoint με τις κατάλληλες ρυθμίσεις ασφαλείας.

### Υποστηρίζεται η εργασία με ελέγχους ActiveX συνδεδεμένα με κώδικα VBA;

Ναι, μπορείτε να έχετε πρόσβαση σε υπάρχοντες [ActiveX controls](/slides/el/androidjava/activex/), να τροποποιήσετε τις ιδιότητές τους και να τους αφαιρέσετε. Αυτό είναι χρήσιμο όταν οι μακροεντολές αλληλεπιδρούν με ActiveX.