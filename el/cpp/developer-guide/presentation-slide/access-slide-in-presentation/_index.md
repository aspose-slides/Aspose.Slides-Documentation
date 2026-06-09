---
title: Πρόσβαση στις διαφάνειες παρουσίασης σε C++
linktitle: Πρόσβαση διαφάνειας
type: docs
weight: 20
url: /el/cpp/access-slide-in-presentation/
keywords:
- πρόσβαση διαφάνειας
- ευρετήριο διαφάνειας
- ID διαφάνειας
- θέση διαφάνειας
- αλλαγή θέσης
- ιδιότητες διαφάνειας
- αριθμός διαφάνειας
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσπελάζετε και να διαχειρίζεστε διαφάνειες σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για C++. Αυξήστε την παραγωγικότητα με παραδείγματα κώδικα."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να προσπελάσετε και να διαχειριστείτε τις διαφάνειες σε μια παρουσίαση χρησιμοποιώντας το Aspose.Slides. Δείχνει πώς να ανακτήσετε διαφάνειες με βάση το μηδενικό τους ευρετήριο από τη συλλογή διαφανειών και πώς να προσπελάσετε μια διαφάνεια με το μοναδικό της ID χρησιμοποιώντας τη μέθοδο `GetSlideById`.

Θα μάθετε επίσης πώς να αλλάξετε τη θέση μιας διαφάνειας χρησιμοποιώντας τη μέθοδο `set_SlideNumber` και πώς να ορίσετε τον αριθμό εκκίνησης της πρώτης διαφάνειας για μια παρουσίαση με τη μέθοδο `set_FirstSlideNumber`. Τα παραδείγματα δείχνουν τη φόρτωση μιας παρουσίασης, την λήψη αναφορών σε διαφάνειες, την ενημέρωση της σειράς ή του αριθμού των διαφανειών και την αποθήκευση της τροποποιημένης παρουσίασης.

## **Πρόσβαση σε διαφάνεια με βάση το ευρετήριο**

Όλες οι διαφάνειες σε μια παρουσίαση ταξινομούνται αριθμητικά με βάση τη θέση τους, ξεκινώντας από το 0. Η πρώτη διαφάνεια είναι προσβάσιμη μέσω του ευρετηρίου 0· η δεύτερη διαφάνεια μέσω του ευρετηρίου 1· κ.ο.κ.

Η κλάση Presentation, η οποία αντιπροσωπεύει ένα αρχείο παρουσίασης, εκθέτει όλες τις διαφάνειες ως μια συλλογή [ISlideCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/) (συλλογή αντικειμένων [ISlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/)). Αυτός ο κώδικας C++ δείχνει πώς να προσπελάσετε μια διαφάνεια μέσω του ευρετηρίου της:

```c++
	// Η διαδρομή προς το φάκελο εγγράφων.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Δημιουργεί μια παρουσία της κλάσης Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Λαμβάνει την αναφορά μιας διαφάνειας μέσω του ευρετηρίου της
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Πρόσβαση σε διαφάνεια με βάση το ID**

Κάθε διαφάνεια σε μια παρουσίαση έχει ένα μοναδικό ID. Μπορείτε να χρησιμοποιήσετε τη μέθοδο [GetSlideById()](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/getslidebyid/) (που εκτίθενται από την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/)) για να στοχεύσετε αυτό το ID. Αυτός ο κώδικας C++ δείχνει πώς να δώσετε ένα έγκυρο slide ID και να προσπελάσετε τη διαφάνεια μέσω της μεθόδου [GetSlideById()](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/getslidebyid/):

```c++
	// Η διαδρομή προς το φάκελο εγγράφων.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Δημιουργεί μια παρουσία της κλάσης Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Λαμβάνει το ID μιας διαφάνειας
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Προσπελάζει τη διαφάνεια μέσω του ID της
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Αλλαγή θέσης διαφάνειας**

Το Aspose.Slides σας επιτρέπει να αλλάξετε τη θέση μιας διαφάνειας. Για παράδειγμα, μπορείτε να ορίσετε ότι η πρώτη διαφάνεια θα γίνει η δεύτερη διαφάνεια.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε την αναφορά της διαφάνειας (της οποίας τη θέση θέλετε να αλλάξετε) μέσω του ευρετηρίου της.
1. Ορίστε μια νέα θέση για τη διαφάνεια μέσω της ιδιότητας [set_SlideNumber()](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/set_slidenumber/).
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας C++ δείχνει μια λειτουργία όπου η διαφάνεια στη θέση 1 μετακινείται στη θέση 2:

```c++
	// Η διαδρομή προς το φάκελο εγγράφων.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Δημιουργεί μια παρουσία της κλάσης Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Λαμβάνει τη διαφάνεια της οποίας η θέση θα αλλάξει
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Ορίζει τη νέα θέση για τη διαφάνεια
	slide->set_SlideNumber(2);

	// Αποθηκεύει την τροποποιημένη παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Η πρώτη διαφάνεια έγινε η δεύτερη· η δεύτερη διαφάνεια έγινε η πρώτη. Όταν αλλάζετε τη θέση μιας διαφάνειας, οι άλλες διαφάνειες προσαρμόζονται αυτόματα.

## **Ορισμός αριθμού διαφάνειας**

Χρησιμοποιώντας την ιδιότητα [set_FirstSlideNumber()](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/set_firstslidenumber/) (που εκτίθεται από την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/)), μπορείτε να ορίσετε έναν νέο αριθμό για την πρώτη διαφάνεια σε μια παρουσίαση. Αυτή η λειτουργία προκαλεί τον επαναυπολογισμό των άλλων αριθμών διαφανειών.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Λάβετε τον αριθμό της διαφάνειας.
1. Ορίστε τον αριθμό της διαφάνειας.
1. Αποθηκεύστε την τροποποιημένη παρουσίαση.

Αυτός ο κώδικας C++ δείχνει μια λειτουργία όπου ο αριθμός της πρώτης διαφάνειας ορίζεται σε 10:

```c++
	// Η διαδρομή προς το φάκελο εγγράφων.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Δημιουργεί μια παρουσία της κλάσης Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Λαμβάνει τον αριθμό της διαφάνειας
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Ορίζει τον αριθμό της διαφάνειας
	pres->set_FirstSlideNumber(2);
	
	// Αποθηκεύει την τροποποιημένη παρουσίαση
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Αν προτιμάτε να παραλείψετε την πρώτη διαφάνεια, μπορείτε να ξεκινήσετε την αρίθμηση από τη δεύτερη διαφάνεια (και να κρύψετε την αρίθμηση για την πρώτη) με αυτόν τον τρόπο:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Συχνές ερωτήσεις**

**Ο αριθμός της διαφάνειας που βλέπει ο χρήστης ταιριάζει με το μηδενικό ευρετήριο της συλλογής;**

Ο αριθμός που εμφανίζεται σε μια διαφάνεια μπορεί να ξεκινάει από μια αυθαίρετη τιμή (π.χ., 10) και δεν χρειάζεται να ταιριάζει με το ευρετήριο· η σχέση ελέγχεται από τη ρύθμιση του [first slide number](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/set_firstslidenumber/) της παρουσίασης.

**Επηρεάζουν οι κρυμμένες διαφάνειες την αρίθμηση;**

Ναι. Μια κρυμμένη διαφάνεια παραμένει στη συλλογή και μετριέται στην αρίθμηση· το «κρυμμένο» αφορά την εμφάνιση, όχι τη θέση της στη συλλογή.

**Αλλάζει το ευρετήριο μιας διαφάνειας όταν προστίθενται ή αφαιρούνται άλλες διαφάνειες;**

Ναι. Τα ευρετήρια πάντα αντικατοπτρίζουν την τρέχουσα σειρά των διαφανειών και επαναϋπολογίζονται κατά τις ενέργειες εισαγωγής, διαγραφής και μετακίνησης.