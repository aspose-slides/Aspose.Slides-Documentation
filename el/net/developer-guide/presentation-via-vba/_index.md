---
title: Διαχείριση έργων VBA σε παρουσιάσεις σε .NET
linktitle: Παρουσίαση μέσω VBA
type: docs
weight: 250
url: /el/net/presentation-via-vba/
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
- .NET
- C#
- Aspose.Slides
description: "Ανακαλύψτε πώς να δημιουργείτε και να επεξεργάζεστε παρουσιάσεις PowerPoint και OpenDocument μέσω VBA με το Aspose.Slides για .NET, ώστε να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Ο χώρος ονομάτων [Aspose.Slides.Vba](https://reference.aspose.com/slides/el/net/aspose.slides.vba/) περιέχει κλάσεις και διεπαφές για εργασία με μακροεντολές και κώδικα VBA.

{{% alert title="Note" color="warning" %}} 

Όταν μετατρέπετε μια παρουσίαση που περιέχει μακροεντολές σε διαφορετική μορφή αρχείου (PDF, HTML κ.λπ.), το Aspose.Slides αγνοεί όλες τις μακροεντολές (οι μακροεντολές δεν μεταφέρονται στο προκύπτον αρχείο).

Όταν προσθέτετε μακροεντολές σε μια παρουσίαση ή αποθηκεύετε εκ νέου μια παρουσίαση που περιέχει μακροεντολές, το Aspose.Slides απλώς γράφει τα byte των μακροεντολών.

Το Aspose.Slides **ποτέ** δεν εκτελεί τις μακροεντολές σε μια παρουσίαση.

{{% /alert %}}

## **Προσθήκη Μακροεντολών VBA**

Το Aspose.Slides παρέχει την κλάση [VbaProject](https://reference.aspose.com/slides/el/net/aspose.slides.vba/vbaproject/) ώστε να μπορείτε να δημιουργείτε έργα VBA (και αναφορές έργων) και να επεξεργάζεστε υπάρχουσες μονάδες. Μπορείτε να χρησιμοποιήσετε τη διεπαφή [IVbaProject](https://reference.aspose.com/slides/el/net/aspose.slides.vba/ivbaproject/) για να διαχειρίζεστε το ενσωματωμένο VBA σε μια παρουσίαση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
2. Χρησιμοποιήστε τον κατασκευαστή [VbaProject](https://reference.aspose.com/slides/el/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) για να προσθέσετε ένα νέο έργο VBA.
3. Προσθέστε μια μονάδα στο VbaProject.
4. Ορίστε τον πηγαίο κώδικα της μονάδας.
5. Προσθέστε αναφορές στο <stdole>.
6. Προσθέστε αναφορές στο **Microsoft Office**.
7. Συσχετίστε τις αναφορές με το VBA project.
8. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας C# δείχνει πώς να προσθέσετε μια μακροεντολή VBA από την αρχή σε μια παρουσίαση:

```c#
    // Δημιουργεί μια παρουσία της κλάσης παρουσίασης
using (Presentation presentation = new Presentation())
{
    // Δημιουργεί ένα νέο έργο VBA
    presentation.VbaProject = new VbaProject();

    // Προσθέτει μια κενή μονάδα στο έργο VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Ορίζει τον πηγαίο κώδικα της μονάδας
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
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

Ίσως θελήσετε να ρίξετε μια ματιά στο **Aspose** [Macro Remover](https://products.aspose.app/slides/el/remove-macros), μια δωρεάν διαδικτυακή εφαρμογή που χρησιμοποιείται για την αφαίρεση μακροεντολών από έγγραφα PowerPoint, Excel και Word.

{{% /alert %}} 

## **Αφαίρεση Μακροεντολών VBA**
Χρησιμοποιώντας την ιδιότητα [VbaProject](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/vbaproject/) της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/), μπορείτε να αφαιρέσετε μια μακροεντολή VBA.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
2. Πρόσβαση στη μονάδα Macro και αφαίρεση της.
3. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας C# δείχνει πώς να αφαιρέσετε μια μακροεντολή VBA:

```c#
    // Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Πρόσβαση στη μονάδα Vba και αφαίρεση της
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Αποθηκεύει την παρουσίαση
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **Εξαγωγή Μακροεντολών VBA**
1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει ένα VBA Project.
3. Περιηγηθείτε σε όλες τις μονάδες που περιέχονται στο VBA Project για να δείτε τις μακροεντολές.

Αυτός ο κώδικας C# δείχνει πώς να εξαγάγετε μακροεντολές VBA από μια παρουσίαση που περιέχει μακροεντολές:

```c#
    // Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Ελέγχει εάν η Παρουσίαση περιέχει Έργο VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Έλεγχος Εάν Ένα VBA Project Είναι Προστατευμένο με Κωδικό**
Χρησιμοποιώντας την ιδιότητα [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/el/net/aspose.slides.vba/ivbaproject/ispasswordprotected/), μπορείτε να καθορίσετε αν οι ιδιότητες ενός έργου είναι προστατευμένες με κωδικό.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) και φορτώστε μια παρουσίαση που περιέχει μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει ένα [VBA project](https://reference.aspose.com/slides/el/net/aspose.slides.vba/vbaproject/).
3. Ελέγξτε αν το VBA project είναι προστατευμένο με κωδικό για να δείτε τις ιδιότητές του.

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Ελέγχει εάν η παρουσίαση περιέχει έργο VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **ΣΥΝΗΘΕΣΤΕΣ ΕΡΩΤΗΣΕΙΣ**

**Τι συμβαίνει με τις μακροεντολές αν αποθηκεύσω την παρουσίαση ως PPTX;**

Οι μακροεντολές θα αφαιρεθούν επειδή το PPTX δεν υποστηρίζει VBA. Για να διατηρήσετε τις μακροεντολές, επιλέξτε PPTM, PPSM ή POTM.

**Μπορεί το Aspose.Slides να εκτελέσει μακροεντολές μέσα σε μια παρουσίαση, για παράδειγμα για ανανέωση δεδομένων;**

Όχι. Η βιβλιοθήκη ποτέ δεν εκτελεί κώδικα VBA· η εκτέλεση είναι δυνατή μόνο μέσα στο PowerPoint με τις κατάλληλες ρυθμίσεις ασφαλείας.

**Υποστηρίζεται η εργασία με ελέγχους ActiveX που συνδέονται με κώδικα VBA;**

Ναι, μπορείτε να αποκτήσετε πρόσβαση σε υπάρχοντες [ελέγχους ActiveX](/slides/el/net/activex/), να τροποποιήσετε τις ιδιότητές τους και να τους αφαιρέσετε. Αυτό είναι χρήσιμο όταν οι μακροεντολές αλληλεπιδρούν με ActiveX.