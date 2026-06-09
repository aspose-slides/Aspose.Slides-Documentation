---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσιάσεων σε C++
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/cpp/presentation-header-and-footer/
keywords:
- κεφαλίδα
- κείμενο κεφαλίδας
- υποσέλιδο
- κείμενο υποσέλιδου
- ορισμός κεφαλίδας
- ορισμός υποσέλιδου
- φυλλάδιο
- σημειώσεις
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για C++ για να προσθέσετε και να προσαρμόσετε κεφαλίδες και υποσέλιδα σε παρουσιάσεις PowerPoint και OpenDocument, ώστε να αποκτήσετε επαγγελματική εμφάνιση."
---
## **Επισκόπηση**

Το Aspose.Slides σάς επιτρέπει να διαχειρίζεστε τις ρυθμίσεις κεφαλίδας και υποσέλιδου σε παρουσιάσεις PowerPoint. Οι κεφαλίδες και τα υποσέλιδα διαχειρίζονται σε επίπεδο κύριου πρότυπου παρουσίασης, και το API παρέχει μεθόδους για ορισμό κειμένου υποσέλιδου, αλλαγή ορατότητας υποσέλιδου και ενημέρωση κειμένου κεφαλίδας στις κύριες διαφάνειες σημειώσεων.

Μπορείτε επίσης να διαχειρίζεστε κεφαλίδες και υποσέλιδα για τις διαφάνειες σημειώσεων και φυλλαδίων. Αυτό περιλαμβάνει την αλλαγή της ορατότητας και του κειμένου των θέσεων κράτησης κεφαλίδας, υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας‑ώρας για το κύριο σημειώσεων, όλες τις θυγατρικές διαφάνειες σημειώσεων ή μια μεμονωμένη διαφάνεια σημειώσεων.

## **Διαχείριση Κειμένου Κεφαλίδας και Υποσέλιδου**

Οι σημειώσεις μιας συγκεκριμένης διαφάνειας μπορούν να ενημερωθούν όπως φαίνεται στο παρακάτω παράδειγμα:

``` cpp
// Λειτουργία για ορισμό κειμένου Κεφαλίδας/Υποσέλιδου
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Φόρτωση Παρουσίασης
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Ορισμός Υποσέλιδου
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Πρόσβαση και Ενημέρωση Κεφαλίδας
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Αποθήκευση παρουσίασης
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Διαχείριση Κεφαλίδων και Υποσέλιδων σε Φυλλάδια και Διαφάνειες Σημειώσεων**
Το Aspose.Slides για C++ υποστηρίζει Κεφαλίδα και Υποσέλιδο σε φυλλάδια και διαφάνειες σημειώσεων. Παρακαλούμε ακολουθήστε τα παρακάτω βήματα:

- Φορτώστε μια [Presentation ](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.presentation)που περιέχει βίντεο.
- Αλλάξτε τις ρυθμίσεις Κεφαλίδας και Υποσέλιδου για το κύριο σημειώσεων και όλες τις διαφάνειες σημειώσεων.
- Ορίστε το κύριο σημειώσεων και όλες τις θυγατρικές θέσεις υποσέλιδου ορατές.
- Ορίστε το κύριο σημειώσεων και όλες τις θυγατρικές θέσεις ημερομηνίας και ώρας ορατές.
- Αλλάξτε τις ρυθμίσεις Κεφαλίδας και Υποσέλιδου μόνο για την πρώτη διαφάνεια σημειώσεων.
- Ορίστε την θέση Κεφαλίδας της διαφάνειας σημειώσεων ορατή.
- Ορίστε κείμενο στην θέση Κεφαλίδας της διαφάνειας σημειώσεων.
- Ορίστε κείμενο στην θέση Ημερομηνίας‑Ώρας της διαφάνειας σημειώσεων.
- Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Το απόσπασμα κώδικα παρέχεται στο παρακάτω Παράδειγμα.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Αλλαγή ρυθμίσεων Κεφαλίδας και Υποσέλιδου για το κύριο σημειώσεων και όλες τις διαφάνειες σημειώσεων
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// Κάντε τη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις υποσέλιδου ορατές
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// Κάντε τη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις κεφαλίδας ορατές
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// Κάντε τη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις αριθμού διαφάνειας ορατές
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// Κάντε τη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις ημερομηνίας και ώρας ορατές
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// Ορίστε κείμενο στη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις κεφαλίδας
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// Ορίστε κείμενο στη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις υποσέλιδου
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// Ορίστε κείμενο στη κύρια διαφάνεια σημειώσεων και όλες τις θυγατρικές θέσεις ημερομηνίας και ώρας
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Αλλαγή ρυθμίσεων Κεφαλίδας και Υποσέλιδου μόνο για την πρώτη διαφάνεια σημειώσεων
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// Κάντε αυτή τη θέση κεφαλίδας της διαφάνειας σημειώσεων ορατή
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// Κάντε αυτή τη θέση υποσέλιδου της διαφάνειας σημειώσεων ορατή
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// Κάντε αυτή τη θέση αριθμού διαφάνειας της διαφάνειας σημειώσεων ορατή
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// Κάντε αυτή τη θέση ημερομηνίας‑ώρας της διαφάνειας σημειώσεων ορατή
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// Ορίστε κείμενο στη θέση κεφαλίδας της διαφάνειας σημειώσεων
	headerFooterManager->SetHeaderText(u"New header text");
	// Ορίστε κείμενο στη θέση υποσέλιδου της διαφάνειας σημειώσεων
	headerFooterManager->SetFooterText(u"New footer text");
	// Ορίστε κείμενο στη θέση ημερομηνίας‑ώρας της διαφάνειας σημειώσεων
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να προσθέσω μια «κεφαλίδα» σε κανονικές διαφάνειες;**

Στο PowerPoint, η «Κεφαλίδα» υπάρχει μόνο για σημειώσεις και φυλλάδια· σε κανονικές διαφάνειες τα υποστηριζόμενα στοιχεία είναι το υποσέλιδο, η ημερομηνία/ώρα και ο αριθμός διαφάνειας. Στο Aspose.Slides αυτό ανταποκρίνεται στις ίδιες περιορισμούς: κεφαλίδα μόνο για Σημειώσεις/Φυλλάδια, και σε διαφάνειες — Υποσέλιδο/ΗμερομηνίαΏρα/ΑριθμόςΔιαφάνειας.

**Τι γίνεται αν η διάταξη δεν περιέχει περιοχή υποσέλιδου—μπορώ να «ενεργοποιήσω» την ορατότητά του;**

Ναι. Ελέγξτε την ορατότητα μέσω του διαχειριστή κεφαλίδας/υποσέλιδου και ενεργοποιήστε την εάν χρειάζεται. Αυτοί οι δείκτες και μέθοδοι του API έχουν σχεδιαστεί για περιπτώσεις όπου η θέση κράτησης λείπει ή είναι κρυφή.

**Πώς μπορώ να κάνω τον αριθμό διαφάνειας να αρχίζει από τιμή διαφορετική από 1;**

Ορίστε τον [πρώτο αριθμό διαφάνειας](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/set_firstslidenumber/); μετά από αυτό, όλες οι αρίθμησεις επανυπολογίζονται. Για παράδειγμα, μπορείτε να αρχίσετε από 0 ή 10, και να κρύψετε τον αριθμό στην διαφάνεια τίτλου.

**Τι συμβαίνει με τις κεφαλίδες/υποσέλιδα κατά την εξαγωγή σε PDF/εικόνες/HTML;**

Απεικονίζονται ως κανονικά στοιχεία κειμένου της παρουσίασης. Δηλαδή, εάν τα στοιχεία είναι ορατά στις διαφάνειες/σελίδες σημειώσεων, θα εμφανιστούν επίσης στην έξοδο μορφής μαζί με το υπόλοιπο περιεχόμενο.