---
title: Διαχείριση Κεφαλίδων και Υποσέλιδων Παρουσίασης σε .NET
linktitle: Κεφαλίδα και Υποσέλιδο
type: docs
weight: 140
url: /el/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "Χρησιμοποιήστε το Aspose.Slides για .NET για να προσθέσετε και να προσαρμόσετε κεφαλίδες και υποσέλιδα σε παρουσιάσεις PowerPoint και OpenDocument για επαγγελματική εμφάνιση."
---
## **Επισκόπηση**

Το Aspose.Slides σας επιτρέπει να διαχειρίζεστε τις ρυθμίσεις κεφαλίδας και υποσέλιδου σε παρουσιάσεις PowerPoint. Οι κεφαλίδες και τα υποσέλιδα διαχειρίζονται σε επίπεδο κύριου παρουσίασης, και το API παρέχει μεθόδους για ορισμό κειμένου υποσέλιδου, αλλαγή ορατότητας υποσέλιδου και ενημέρωση κειμένου κεφαλίδας στις κύριες διαφάνειες σημειώσεων.

Μπορείτε επίσης να διαχειριστείτε κεφαλίδες και υποσέλιδα για φυλλάδια και διαφάνειες σημειώσεων. Αυτό περιλαμβάνει την αλλαγή της ορατότητας και του κειμένου των δεσμευτικών σημείων κεφαλίδας, υποσέλιδου, αριθμού διαφάνειας και ημερομηνίας‑ώρας για τον κύριο σημειώσεων, όλες τις θυγατρικές διαφάνειες σημειώσεων ή μια μεμονωμένη διαφάνεια σημειώσεων.

## **Διαχείριση Κειμένου Κεφαλίδας και Υποσέλιδου**

Οι σημειώσεις μιας συγκεκριμένης διαφάνειας μπορούν να ενημερωθούν όπως φαίνεται στο παρακάτω παράδειγμα:

```c#
// Φόρτωση Παρουσίασης
Presentation pres = new Presentation("headerTest.pptx");

// Ορισμός Υποσέλιδου
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Πρόσβαση και Ενημέρωση Κεφαλίδας
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Αποθήκευση παρουσίασης
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// Μέθοδος για ορισμό κειμένου Κεφαλίδας/Υποσέλιδου
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```




## **Διαχείριση Κεφαλίδων και Υποσέλιδων σε Φυλλάδια και Διαφάνιες Σημειώσεων**
Το Aspose.Slides για .NET υποστηρίζει Κεφαλίδα και Υποσέλιδο σε φυλλάδια και διαφάνειες σημειώσεων. Ακολουθήστε τα παρακάτω βήματα:

- Φορτώστε μια [Presentation ](https://reference.aspose.com/slides/el/net/aspose.slides/presentation)που περιέχει βίντεο.
- Αλλάξτε τις ρυθμίσεις Κεφαλίδας και Υποσέλιδου για τον κύριο σημειώσεων και όλες τις διαφάνειες σημειώσεων.
- Ορίστε ορατό το υποσέλιδο στην κύρια διαφάνεια σημειώσεων και σε όλα τα θυγατρικά δεσμευτικά σημεία υποσέλιδου.
- Ορίστε ορατό τις ημερομηνία‑ώρα στην κύρια διαφάνεια σημειώσεων και σε όλα τα θυγατρικά δεσμευτικά σημεία.
- Αλλάξτε τις ρυθμίσεις Κεφαλίδας και Υποσέλιδου μόνο για την πρώτη διαφάνεια σημειώσεων.
- Ορίστε ορατό το δεσμευτικό σημείο Κεφαλίδας στη διαφάνεια σημειώσεων.
- Ορίστε κείμενο στο δεσμευτικό σημείο Κεφαλίδας της διαφάνειας σημειώσεων.
- Ορίστε κείμενο στο δεσμευτικό σημείο Ημερομηνίας‑Ωρας της διαφάνειας σημειώσεων.
- Γράψτε το τροποποιημένο αρχείο παρουσίασης.

Το απόσπασμα κώδικα παρέχεται στο παρακάτω παράδειγμα.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Αλλαγή ρυθμίσεων Κεφαλίδας και Υποσέλιδου για τον κύριο σημειώσεων και όλες τις διαφάνειες σημειώσεων
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // κάντε τη κύρια διαφάνεια σημειώσεων και όλα τα θυγατρικά δεσμευτικά σημεία Υποσέλιδου ορατά
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // κάντε τη κύρια διαφάνεια σημειώσεων και όλα τα θυγατρικά δεσμευτικά σημεία Κεφαλίδας ορατά
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // κάντε τη κύρια διαφάνεια σημειώσεων και όλα τα θυγατρικά δεσμευτικά σημεία Αριθμού Διαφάνειας ορατά
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // κάντε τη κύρια διαφάνεια σημειώσεων και όλα τα θυγατρικά δεσμευτικά σημεία Ημερομηνίας και ώρας ορατά

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // ορίστε κείμενο στη κύρια διαφάνεια σημειώσεων και σε όλα τα θυγατρικά δεσμευτικά σημεία Κεφαλίδας
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // ορίστε κείμενο στη κύρια διαφάνεια σημειώσεων και σε όλα τα θυγατρικά δεσμευτικά σημεία Υποσέλιδου
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // ορίστε κείμενο στη κύρια διαφάνεια σημειώσεων και σε όλα τα θυγατρικά δεσμευτικά σημεία Ημερομηνίας και ώρας
	}

	// Αλλαγή ρυθμίσεων Κεφαλίδας και Υποσέλιδου μόνο για την πρώτη διαφάνεια σημειώσεων
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // κάντε αυτό το δεσμευτικό σημείο Κεφαλίδας της διαφάνειας σημειώσεων ορατό

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // κάντε αυτό το δεσμευτικό σημείο Υποσέλιδου της διαφάνειας σημειώσεων ορατό

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // κάντε αυτό το δεσμευτικό σημείο Αριθμού Διαφάνειας της διαφάνειας σημειώσεων ορατό

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // κάντε αυτό το δεσμευτικό σημείο Ημερομηνίας‑Ώρας της διαφάνειας σημειώσεων ορατό

		headerFooterManager.SetHeaderText("New header text"); // ορίστε κείμενο στο δεσμευτικό σημείο Κεφαλίδας της διαφάνειας σημειώσεων
		headerFooterManager.SetFooterText("New footer text"); // ορίστε κείμενο στο δεσμευτικό σημείο Υποσέλιδου της διαφάνειας σημειώνων
		headerFooterManager.SetDateTimeText("New date and time text"); // ορίστε κείμενο στο δεσμευτικό σημείο Ημερομηνίας‑Ώρας της διαφάνειας σημειώσεων
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **FAQ**

**Μπορώ να προσθέσω μια «κεφαλίδα» σε κανονικές διαφάνειες;**

Στο PowerPoint, η «Κεφαλίδα» υπάρχει μόνο για σημειώσεις και φυλλάδια· στις κανονικές διαφάνειες τα υποστηριζόμενα στοιχεία είναι το υποσέλιδο, η ημερομηνία/ώρα και ο αριθμός διαφάνειας. Στο Aspose.Slides αυτό αντανακλά τις ίδιες περιορισμούς: κεφαλίδα μόνο για Σημειώσεις/Φυλλάδια, και στις διαφάνειες—Υποσέλιδο/ΗμερομηνίαΏρα/ΑριθμόςΔιαφάνειας.

**Τι γίνεται αν η διάταξη δεν περιέχει περιοχή υποσέλιδου· μπορώ να «ενεργοποιήσω» την ορατότητά του;**

Ναι. Ελέγξτε την ορατότητα μέσω του διαχειριστή κεφαλίδας/υποσέλιδου και ενεργοποιήστε την αν χρειάζεται. Αυτοί οι δείκτες και οι μέθοδοι του API έχουν σχεδιαστεί για περιπτώσεις όπου το δεσμευτικό σημείο λείπει ή είναι κρυφό.

**Πώς μπορώ να κάνω τον αριθμό διαφάνειας να ξεκινά από τιμή διαφορετική από το 1;**

Ορίστε τον [πρώτο αριθμό διαφάνειας](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/firstslidenumber/) της παρουσίασης· μετά από αυτό, όλες οι αρίθμησεις επανυπολογίζονται. Για παράδειγμα, μπορείτε να ξεκινήσετε από 0 ή 10 και να κρύψετε τον αριθμό στην διαφάνεια τίτλου.

**Τι γίνεται με τις κεφαλίδες/υποσέλιδα κατά την εξαγωγή σε PDF/εικόνες/HTML;**

Αποδίδονται ως κανονικά στοιχεία κειμένου της παρουσίασης. Δηλαδή, αν τα στοιχεία είναι ορατά στις διαφάνειες/σελίδες σημειώσεων, θα εμφανιστούν επίσης στην έξοδο μαζί με το υπόλοιπο περιεχόμενο.