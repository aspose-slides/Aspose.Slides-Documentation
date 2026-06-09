---
title: Μετατροπή παρουσιάσεων PowerPoint σε Markdown σε C++
linktitle: PowerPoint σε Markdown
type: docs
weight: 140
url: /el/cpp/convert-powerpoint-to-markdown/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- μετατροπή PPTX
- PowerPoint σε MD
- παρουσίαση σε MD
- διαφάνεια σε MD
- PPT σε MD
- PPTX σε MD
- αποθήκευση PowerPoint ως Markdown
- αποθήκευση παρουσίασης ως Markdown
- αποθήκευση διαφάνειας ως Markdown
- αποθήκευση PPT ως MD
- αποθήκευση PPTX ως MD
- εξαγωγή PPT σε MD
- εξαγωγή PPTX σε MD
- PowerPoint
- παρουσίαση
- Markdown
- C++
- Aspose.Slides
description: "Μετατρέψτε τις διαφάνειες PowerPoint—PPT, PPTX—σε καθαρό Markdown με Aspose.Slides για C++, αυτοματοποιήστε την τεκμηρίωση και διατηρήστε τη μορφοποίηση."
---
## **Εισαγωγή**

Το Aspose.Slides σας επιτρέπει να μετατρέπετε παρουσιάσεις PowerPoint σε Markdown, κάτι που μπορεί να είναι χρήσιμο για τις ροές εργασίας τεκμηρίωσης, τη δημιουργία στατικών ιστότοπων, τη μεταφορά περιεχομένου και τη δημοσίευση κειμένου με έλεγχο εκδόσεων. Το API υποστηρίζει απευθείας εξαγωγή από παρουσιάσεις PPT και PPTX σε αρχεία MD και παρέχει επιπλέον επιλογές για τον έλεγχο του τρόπου με τον οποίο το περιεχόμενο των διαφανειών αναπαρίσταται στο τελικό έγγραφο Markdown.

Μπορείτε να εξάγετε τις παρουσιάσεις ως απλό Markdown, να επιλέξετε από πολλαπλές γεύσεις Markdown όπως CommonMark και GitHub Flavored Markdown, και να ρυθμίσετε τον τρόπο διαχείρισης των εικόνων κατά την εξαγωγή. Για παρουσιάσεις που περιέχουν οπτικό περιεχόμενο, το Aspose.Slides σας επιτρέπει επίσης να αποθηκεύετε τις εικόνες σε ξεχωριστό φάκελο και να τις αναφέρετε από το παραγόμενο αρχείο Markdown.

{{% alert color="warning" %}} 

Η εξαγωγή PowerPoint σε markdown είναι **χωρίς εικόνες** από προεπιλογή. Αν θέλετε να εξάγετε ένα έγγραφο PowerPoint που περιέχει εικόνες, πρέπει να ορίσετε `SaveOptions::MarkdownExportType::Visual)` και επίσης να ορίσετε το `BasePath` όπου θα αποθηκευτούν οι εικόνες που αναφέρονται στο έγγραφο markdown.

{{% /alert %}} 

## **Μετατροπή PowerPoint σε Markdown**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) για να αντιπροσωπεύει ένα αντικείμενο παρουσίασης.
2. Χρησιμοποιήστε τη μέθοδο [Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) για να αποθηκεύσετε το αντικείμενο ως αρχείο markdown.

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **Μετατροπή PowerPoint σε Γεύση Markdown**

Το Aspose.Slides σας επιτρέπει να μετατρέψετε το PowerPoint σε markdown (με βασική σύνταξη), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab και άλλες 17 γεύσεις markdown.

Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε το PowerPoint σε CommonMark: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

Οι 23 υποστηριζόμενες γεύσεις markdown είναι [απαριθμούνται στην απαρίθμηση Flavor](https://reference.aspose.com/slides/el/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) από την κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Μετατροπή Παρουσίασης που Περιέχει Εικόνες σε Markdown**

Η κλάση [MarkdownSaveOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) παρέχει ιδιότητες και απαριθμήσεις που σας επιτρέπουν να χρησιμοποιήσετε συγκεκριμένες επιλογές ή ρυθμίσεις για το παραγόμενο αρχείο markdown. Η απαρίθμηση [MarkdownExportType](https://reference.aspose.com/slides/el/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/), για παράδειγμα, μπορεί να οριστεί σε τιμές που καθορίζουν πώς θα αποτυπώνονται ή θα διαχειρίζονται οι εικόνες: `Sequential`, `TextOnly`, `Visual`.

### **Μετατροπή Εικόνων Σειριακά**

Αν θέλετε οι εικόνες να εμφανίζονται μεμονωμένα η μία μετά την άλλη στο παραγόμενο markdown, πρέπει να επιλέξετε τη σειριακή επιλογή. Αυτός ο κώδικας C++ δείχνει πώς να μετατρέψετε μια παρουσίαση που περιέχει εικόνες σε markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **Μετατροπή Εικόνων Οπτικά**

Αν θέλετε οι εικόνες να εμφανίζονται μαζί στο παραγόμενο markdown, πρέπει να επιλέξετε την οπτική επιλογή. Σε αυτήν την περίπτωση, οι εικόνες θα αποθηκευτούν στον τρέχοντα φάκελο της εφαρμογής (και θα δημιουργηθεί σχετικό μονοπάτι για αυτές στο έγγραφο markdown), ή μπορείτε να ορίσετε το προτιμώμενο μονοπάτι και όνομα φακέλου.

Αυτός ο κώδικας C++ επιδεικνύει τη λειτουργία: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **Συχνές Ερωτήσεις**

**Παραμένουν οι υπερσυνδέσμοι μετά την εξαγωγή σε Markdown;**

Ναι. Τα κείμενα [hyperlinks](/slides/el/cpp/manage-hyperlinks/) διατηρούνται ως τυπικοί σύνδεσμοι Markdown. Οι [transitions](/slides/el/cpp/slide-transition/) διαφάνειας και τα [animations](/slides/el/cpp/powerpoint-animation/) δεν μετατρέπονται.

**Μπορώ να επιταχύνω τη μετατροπή τρέχοντάς την σε πολλαπλά νήματα;**

Μπορείτε να παράλληλοποιήσετε ανά αρχείο, αλλά [μην μοιράζεστε](/slides/el/cpp/multithreading/) την ίδια παρουσία [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) μεταξύ νημάτων. Χρησιμοποιήστε ξεχωριστές παρουσίες/διεργασίες ανά αρχείο για να αποφύγετε συγκρούσεις.

**Τι συμβαίνει με τις εικόνες—πού αποθηκεύονται και είναι οι διαδρομές σχετικές;**

Οι [Images](/slides/el/cpp/image/) εξάγονται σε έναν αφιερωμένο φάκελο, και το αρχείο Markdown τις αναφέρει με σχετικές διαδρομές από προεπιλογή. Μπορείτε να διαμορφώσετε τη βασική διαδρομή εξόδου και το όνομα φακέλου πόρων για να διατηρήσετε μια προβλέψιμη δομή αποθετηρίου.