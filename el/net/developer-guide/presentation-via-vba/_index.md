---
title: Διαχείριση έργων VBA σε παρουσιάσεις σε .NET
linktitle: Παρουσίαση μέσω VBA
type: docs
weight: 250
url: /el/net/presentation-via-vba/
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
  - .NET
  - C#
  - Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργείτε και να επεξεργάζεστε παρουσιάσεις PowerPoint και OpenDocument μέσω VBA με το Aspose.Slides για .NET ώστε να βελτιώσετε τη ροή εργασιών σας."
---
## **Εισαγωγή**

Ο χώρος ονομάτων [Aspose.Slides.Vba](https://reference.aspose.com/slides/el/net/aspose.slides.vba/) περιέχει κλάσεις και διεπαφές για εργασία με μακροεντολές και κώδικα VBA.

{{% alert title="Note" color="warning" %}} 

Κατά τη μετατροπή μιας παρουσίασης που περιέχει μακροεντολές σε διαφορετική μορφή αρχείου (PDF, HTML κ.λπ.), το Aspose.Slides αγνοεί όλες τις μακροεντολές (οι μακροεντολές δεν μεταφέρονται στο τελικό αρχείο).

Όταν προσθέτετε μακροεντολές σε μια παρουσίαση ή επαναποθηκεύετε μια παρουσίαση που περιέχει μακροεντολές, το Aspose.Slides απλώς γράφει τα bytes των μακροεντολών.

Το Aspose.Slides **ποτέ** δεν εκτελεί τις μακροεντολές σε μια παρουσίαση.

{{% /alert %}}

## **Προσθήκη μακροεντολών VBA**

Το Aspose.Slides παρέχει την κλάση [VbaProject](https://reference.aspose.com/slides/el/net/aspose.slides.vba/vbaproject/) για να δημιουργήσετε έργα VBA (και αναφορές έργων) και να επεξεργαστείτε υπάρχοντα modules. Μπορείτε να χρησιμοποιήσετε τη διεπαφή [IVbaProject](https://reference.aspose.com/slides/el/net/aspose.slides.vba/ivbaproject/) για να διαχειριστείτε το VBA που είναι ενσωματωμένο σε μια παρουσίαση.

1. Δημιουργήστε μια παρουσία του κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Χρησιμοποιήστε τον κατασκευαστή [VbaProject](https://reference.aspose.com/slides/el/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) για να προσθέσετε ένα νέο έργο VBA.
1. Προσθέστε ένα module στο VbaProject.
1. Ορίστε τον κώδικα πηγής του module.
1. Προσθέστε αναφορές στο <stdole>.
1. Προσθέστε αναφορές στο **Microsoft Office**.
1. Συσχετίστε τις αναφορές με το VBA project.
1. Αποθηκεύστε την παρουσίαση.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// Δημιουργεί μια παρουσία της κλάσης παρουσίασης
using (Presentation presentation = new Presentation())
{
    // Δημιουργεί ένα νέο έργο VBA
    presentation.VbaProject = new VbaProject();

    // Προσθέτει ένα κενό module στο έργο VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // Ορίζει τον κώδικα πηγής του module
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Δημιουργεί μια αναφορά στο <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Δημιουργεί μια αναφορά στο Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Προσθέτει αναφορές στο έργο VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // Αποθηκεύει την παρουσίαση
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

Μπορεί να θέλετε να εξετάσετε το **Aspose** [Macro Remover](https://products.aspose.app/slides/el/remove-macros), μια δωρεάν διαδικτυακή εφαρμογή που χρησιμοποιείται για την αφαίρεση μακροεντολών από αρχεία PowerPoint, Excel και Word.

{{% /alert %}} 

## **Αφαίρεση μακροεντολών VBA**
Χρησιμοποιώντας την ιδιότητα [VbaProject](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/vbaproject/) της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/), μπορείτε να αφαιρέσετε μια μακροεντολή VBA.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
1. Προσεγγίστε το module Macro και αφαιρέστε το.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Προσπελαύνει το module Vba και το αφαιρεί
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Αποθηκεύει την παρουσίαση
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **Εξαγωγή μακροεντολών VBA**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει ένα VBA Project.
3. Επανάληψη σε όλα τα modules που περιέχονται στο VBA Project για προβολή των μακροεντολών.

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Ελέγχει αν η παρουσίαση περιέχει ένα έργο VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Έλεγχος εάν ένα VBA Project είναι προστατευμένο με κωδικό**

Χρησιμοποιώντας την ιδιότητα [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/el/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), μπορείτε να προσδιορίσετε εάν οι ιδιότητες ενός έργου είναι προστατευμένες με κωδικό.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και φορτώστε μια παρουσίαση που περιέχει μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει ένα [VBA project](https://reference.aspose.com/slides/el/net/aspose.slides.vba/vbaproject/).
3. Ελέγξτε αν το VBA project είναι προστατευμένο με κωδικό για προβολή των ιδιοτήτων του.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Έλεγχος αν η παρουσίαση περιέχει ένα έργο VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

### Τι συμβαίνει με τις μακροεντολές αν αποθηκεύσω την παρουσίαση ως PPTX;

Οι μακροεντολές θα αφαιρεθούν επειδή το PPTX δεν υποστηρίζει VBA. Για να διατηρήσετε τις μακροεντολές, επιλέξτε PPTM, PPSM ή POTM.

### Μπορεί το Aspose.Slides να εκτελεί μακροεντολές μέσα σε μια παρουσίαση, για παράδειγμα, για ανανέωση δεδομένων;

Όχι. Η βιβλιοθήκη δεν εκτελεί ποτέ κώδικα VBA· η εκτέλεση είναι δυνατή μόνο στο PowerPoint με τις κατάλληλες ρυθμίσεις ασφαλείας.

### Υποστηρίζεται η εργασία με στοιχεία ActiveX που συνδέονται με κώδικα VBA;

Ναι, μπορείτε να προσπελάσετε υπάρχοντα [ελεγκτές ActiveX](/slides/el/net/activex/), να τροποποιήσετε τις ιδιότητές τους και να τα αφαιρέσετε. Αυτό είναι χρήσιμο όταν οι μακροεντολές αλληλεπιδρούν με ActiveX.