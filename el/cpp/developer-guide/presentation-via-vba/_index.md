---
title: "Διαχείριση έργων VBA σε παρουσιάσεις με C++"
linktitle: "Παρουσίαση μέσω VBA"
type: docs
weight: 250
url: /el/cpp/presentation-via-vba/
keywords:
- "μακροεντολή"
- "VBA"
- "μακροεντολή VBA"
- "προσθήκη μακροεντολής"
- "αφαίρεση μακροεντολής"
- "εξαγωγή μακροεντολής"
- "προσθήκη VBA"
- "αφαίρεση VBA"
- "εξαγωγή VBA"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "C++"
- "Aspose.Slides"
description: "Ανακαλύψτε πώς να δημιουργείτε και να διαχειρίζεστε παρουσιάσεις PowerPoint και OpenDocument μέσω VBA με το Aspose.Slides για C++ ώστε να βελτιώσετε τη ροή εργασίας σας."
---
## **Εισαγωγή**

Ο χώρος ονομάτων [Aspose.Slides.Vba](https://reference.aspose.com/slides/el/cpp/namespace/aspose.slides.vba/) περιλαμβάνει κλάσεις και διεπαφές για εργασία με μακροεντολές και κώδικα VBA.

{{% alert title="Note" color="warning" %}} 

Όταν μετατρέπετε μια παρουσίαση που περιέχει μακροεντολές σε διαφορετική μορφή αρχείου (PDF, HTML, κ.λπ.), το Aspose.Slides αγνοεί όλες τις μακροεντολές (οι μακροεντολές δεν μεταφέρονται στο παραγόμενο αρχείο).

Όταν προσθέτετε μακροεντολές σε μια παρουσίαση ή αποθηκεύετε ξανά μια παρουσίαση που περιέχει μακροεντολές, το Aspose.Slides απλώς γράφει τα bytes των μακροεντολών.

Το Aspose.Slides **ποτέ** δεν εκτελεί τις μακροεντολές σε μια παρουσίαση.

{{% /alert %}}

## **Προσθήκη Μακροεντολών VBA**

Το Aspose.Slides παρέχει την κλάση [VbaProject](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.vba.vba_project) για να δημιουργήσετε έργα VBA (και αναφορές έργου) και να επεξεργαστείτε υπάρχουσες μονάδες. Μπορείτε να χρησιμοποιήσετε τη διεπαφή [IVbaProject](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.vba.i_vba_project/) για να διαχειριστείτε το VBA ενσωματωμένο σε μια παρουσίαση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation).
2. Χρησιμοποιήστε τον κατασκευαστή [VbaProject](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) για να προσθέσετε ένα νέο έργο VBA.
3. Προσθέστε μια μονάδα στο VbaProject.
4. Ορίστε τον πηγαίο κώδικα της μονάδας.
5. Προσθέστε αναφορές στο <stdole>.
6. Προσθέστε αναφορές στο **Microsoft Office**.
7. Συσχετίστε τις αναφορές με το έργο VBA.
8. Αποθηκεύστε την παρουσίαση.

Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε μια μακροεντολή VBA από την αρχή σε μια παρουσίαση:

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaReferenceCollection.h>
#include <DOM/Vba/VbaProject.h>
#include <DOM/Vba/VbaReferenceOleTypeLib.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Vba;
using namespace System;

// Η διαδρομή προς τον φάκελο εγγράφων.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Δημιουργεί μια παρουσία της κλάσης παρουσίασης
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// Δημιουργεί ένα νέο έργο VBA
presentation->set_VbaProject(MakeObject<VbaProject>());

// Προσθέτει μια κενή μονάδα στο έργο VBA
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// Ορίζει τον πηγαίο κώδικα της μονάδας
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// Δημιουργεί μια αναφορά στο <stdole>
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Δημιουργεί μια αναφορά στο Office
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// Προσθέτει αναφορές στο έργο VBA
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// Αποθηκεύει την παρουσίαση
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="info" %}} 

Μπορεί να θέλετε να δοκιμάσετε το **Aspose** [Macro Remover](https://products.aspose.app/slides/el/remove-macros), μια δωρεάν διαδικτυακή εφαρμογή που χρησιμοποιείται για την αφαίρεση μακροεντολών από έγγραφα PowerPoint, Excel και Word. 

{{% /alert %}} 

## **Αφαίρεση Μακροεντολών VBA**

Χρησιμοποιώντας την ιδιότητα [VbaProject](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) στην κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation), μπορείτε να αφαιρέσετε μια μακροεντολή VBA.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
2. Πρόσβαση στη μονάδα Macro και αφαίρεσή της.
3. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας C++ δείχνει πώς να αφαιρέσετε μια μακροεντολή VBA:

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

// Η διαδρομή προς τον φάκελο εγγράφων.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Πρόσβαση στη μονάδα Vba και αφαίρεσή της
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// Αποθηκεύει την Παρουσίαση
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **Εξαγωγή Μακροεντολών VBA**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation) και φορτώστε την παρουσίαση που περιέχει τη μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει Έργο VBA.
3. Διατρέξτε όλες τις μονάδες που περιέχονται στο Έργο VBA για να προβάλετε τις μακροεντολές.

Αυτός ο κώδικας C++ δείχνει πώς να εξαγάγετε μακροεντολές VBA από μια παρουσίαση που περιέχει μακροεντολές:

```c++
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaModule.h>
#include <DOM/Vba/IVbaModuleCollection.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

	// Η διαδρομή προς τον φάκελο εγγράφων.
	const String templatePath = u"../templates/VBA.pptm";

	// Φορτώνει την παρουσίαση που περιέχει τη μακροεντολή
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // Ελέγχει αν η Παρουσίαση περιέχει Έργο VBA
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```

## **Έλεγχος αν ένα Έργο VBA είναι προστατευμένο με κωδικό**

Χρησιμοποιώντας την ιδιότητα [IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/el/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/), μπορείτε να καθορίσετε αν οι ιδιότητες ενός έργου είναι προστατευμένες με κωδικό.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) και φορτώστε μια παρουσίαση που περιέχει μακροεντολή.
2. Ελέγξτε αν η παρουσίαση περιέχει ένα [VBA project](https://reference.aspose.com/slides/el/cpp/aspose.slides.vba/vbaproject/).
3. Ελέγξτε αν το έργο VBA είναι προστατευμένο με κωδικό για να δείτε τις ιδιότητές του.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Vba/IVbaProject.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Vba;
using namespace System;

auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // Ελέγχει αν η παρουσίαση περιέχει έργο VBA.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

### Τι συμβαίνει με τις μακροεντολές αν αποθηκεύσω την παρουσίαση ως PPTX;

Οι μακροεντολές θα αφαιρεθούν επειδή το PPTX δεν υποστηρίζει VBA. Για να διατηρήσετε τις μακροεντολές, επιλέξτε PPTM, PPSM ή POTM.

### Μπορεί το Aspose.Slides να εκτελέσει μακροεντολές μέσα σε μια παρουσίαση για, παράδειγμα, ανανέωση δεδομένων;

Όχι. Η βιβλιοθήκη ποτέ δεν εκτελεί κώδικα VBA· η εκτέλεση είναι εφικτή μόνο μέσα στο PowerPoint με τις κατάλληλες ρυθμίσεις ασφαλείας.

### Υποστηρίζεται η εργασία με στοιχεία ActiveX που συνδέονται με κώδικα VBA;

Ναι, μπορείτε να προσπελάσετε υπάρχοντα [ActiveX controls](/slides/el/cpp/activex/), να τροποποιήσετε τις ιδιότητές τους και να τα αφαιρέσετε. Αυτό είναι χρήσιμο όταν οι μακροεντολές αλληλεπιδρούν με ActiveX.