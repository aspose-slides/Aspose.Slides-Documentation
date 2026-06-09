---
title: "Διαχείριση Zoom της Παρουσίασης σε C++"
linktitle: "Διαχείριση Zoom"
type: docs
weight: 60
url: /el/cpp/manage-zoom/
keywords:
- ζουμ
- πλαίσιο ζουμ
- ζουμ διαφάνειας
- ζουμ ενότητας
- ζουμ περίληψης
- προσθήκη ζουμ
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Δημιουργήστε και προσαρμόστε το Zoom με το Aspose.Slides για C++ — μεταβείτε μεταξύ ενοτήτων, προσθέστε μικρογραφίες και μεταβάσεις σε παρουσιάσεις PPT, PPTX και ODP."
---
## **Εισαγωγή**

Τα Zoom στο PowerPoint σάς επιτρέπουν να μεταβαίνετε προς και από συγκεκριμένες διαφάνειες, ενότητες και τμήματα μιας παρουσίασης. Κατά τη διάρκεια μιας παρουσίασης, αυτή η δυνατότητα γρήγορης πλοήγησης στο περιεχόμενο μπορεί να αποδειχθεί πολύ χρήσιμη. 

![overview_image](Overview.png)

* Για να συνοψίσετε ολόκληρη την παρουσίαση σε μία μόνο διαφάνεια, χρησιμοποιήστε ένα [Summary Zoom](#Summary-Zoom).
* Για να εμφανίσετε μόνο τις επιλεγμένες διαφάνειες, χρησιμοποιήστε ένα [Slide Zoom](#Slide-Zoom).
* Για να εμφανίσετε μόνο μια ενότητα, χρησιμοποιήστε ένα [Section Zoom](#Section-Zoom).

## **Zoom Διαφάνειας**
Ένα zoom διαφάνειας μπορεί να κάνει την παρουσίασή σας πιο δυναμική, επιτρέποντάς σας να πλοηγηθείτε ελεύθερα μεταξύ των διαφανειών με τη σειρά που επιθυμείτε χωρίς να διακόπτετε τη ροή της παρουσίασης. Τα zoom διαφάνειας είναι ιδανικά για σύντομες παρουσιάσεις χωρίς πολλές ενότητες, αλλά μπορείτε ακόμα να τα χρησιμοποιήσετε σε διαφορετικά σενάρια παρουσίασης.

Τα zoom διαφάνειας σας βοηθούν να εμβαθύνετε σε πολλαπλά κομμάτια πληροφορίας ενώ αισθάνεστε ότι βρίσκεστε σε έναν ενιαίο καμβά. 

![overview_image](slidezoomsel.png)

Για αντικείμενα zoom διαφάνειας, το Aspose.Slides παρέχει την απαρίθμηση [ZoomImageType](https://reference.aspose.com/slides/el/cpp/aspose.slides/zoomimagetype/), τη διεπαφή [IZoomFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/izoomframe/) και μερικές μεθόδους στη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/).

### **Δημιουργία Πλαισίων Zoom**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom σε μια διαφάνεια με τον εξής τρόπο:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Δημιουργήστε νέες διαφάνειες στις οποίες σκοπεύετε να συνδέσετε τα πλαίσια zoom. 
3. Προσθέστε κείμενο ταυτοποίησης και φόντο στις δημιουργημένες διαφάνειες.
4. Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C++ δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σε μια διαφάνεια:

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Προσθέτει νέες διαφάνειες στην παρουσίαση
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Δημιουργεί φόντο για τη δεύτερη διαφάνεια
SetSlideBackground(slide2, Color::get_Cyan());

// Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Δημιουργεί φόντο για την τρίτη διαφάνεια
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Προσθέτει αντικείμενα ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Αποθηκεύει την παρουσίαση
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Δημιουργία Πλαισίων Zoom με Προσαρμοσμένες Εικόνες**
Με το Aspose.Slides για C++ μπορείτε να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα προεπισκόπησης της διαφάνειας ως εξής: 
1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Δημιουργήστε μια νέα διαφάνεια στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
3. Προσθέστε κείμενο ταυτοποίησης και φόντο στη διαφάνεια.
4. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που θα χρησιμοποιηθεί για τη γέμιση του πλαισίου.
5. Προσθέστε πλαίσια zoom (που περιέχουν την αναφορά στη δημιουργημένη διαφάνεια) στην πρώτη διαφάνεια.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C++ δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Προσθέτει μια νέα διαφάνεια στην παρουσίαση
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

//Δημιουργεί φόντο για τη δεύτερη διαφάνεια
SetSlideBackground(slide, Color::get_Cyan());

//Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Δημιουργεί μια νέα εικόνα για το αντικείμενο zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//Προσθέτει το αντικείμενο ZoomFrame
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

//Αποθηκεύει την παρουσίαση
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Μορφοποίηση Πλαισίων Zoom**
Στις προηγούμενες ενότητες, σας δείξαμε πώς να δημιουργήσετε απλά πλαίσια zoom. Για να δημιουργήσετε πιο περίπλοκα πλαίσια zoom, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν διάφορες επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο zoom. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου zoom σε μια διαφάνεια ως εξής:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Δημιουργήστε νέες διαφάνειες για σύνδεση στις οποίες σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
3. Προσθέστε κάποιο κείμενο ταυτοποίησης και φόντο στις δημιουργημένες διαφάνειες.
4. Προσθέστε πλαίσια zoom (που περιέχουν τις αναφορές στις δημιουργημένες διαφάνειες) στην πρώτη διαφάνεια.
5. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που θα χρησιμοποιηθεί για τη γέμιση του πλαισίου.
6. Ορίστε προσαρμοσμένη εικόνα για το πρώτο αντικείμενο πλαισίου zoom.
7. Αλλάξτε τη μορφή γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
8. Αφαιρέστε το φόντο από την εικόνα του δεύτερου αντικειμένου πλαισίου zoom.
5. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C++ δείχνει πώς να αλλάξετε τη μορφοποίηση ενός πλαισίου zoom σε μια διαφάνεια: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Προσθέτει νέες διαφάνειες στην παρουσίαση
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

//Δημιουργεί φόντο για τη δεύτερη διαφάνεια
SetSlideBackground(slide2, Color::get_Cyan());

//Δημιουργεί πλαίσιο κειμένου για τη δεύτερη διαφάνεια
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Δημιουργεί φόντο για την τρίτη διαφάνεια
SetSlideBackground(slide3, Color::get_DarkKhaki());

//Δημιουργεί πλαίσιο κειμένου για την τρίτη διαφάνεια
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Προσθέτει αντικείμενα ZoomFrame
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

//Δημιουργεί μια νέα εικόνα για το αντικείμενο zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
//Ορίζει προσαρμοσμένη εικόνα για το αντικείμενο zoomFrame1
zoomFrame1->set_Image(image);

//Ορίζει μορφοποίηση πλαισίου zoom για το αντικείμενο zoomFrame2
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

//Ρύθμιση για να μην εμφανίζεται φόντο στο αντικείμενο zoomFrame2
zoomFrame2->set_ShowBackground(false);

//Αποθηκεύει την παρουσίαση
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zoom Ενότητας**

Ένα zoom ενότητας είναι ένας σύνδεσμος προς μια ενότητα στην παρουσίασή σας. Μπορείτε να χρησιμοποιήσετε τα zoom ενότητας για να επιστρέψετε σε ενότητες που θέλετε να τονίσετε ιδιαίτερα. Ή μπορείτε να τα χρησιμοποιήσετε για να επισημάνετε πώς διάφορα κομμάτια της παρουσίασής σας συνδέονται. 

![overview_image](seczoomsel.png)

Για αντικείμενα zoom ενότητας, το Aspose.Slides παρέχει τη διεπαφή [ISectionZoomFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/isectionzoomframe/) και μερικές μεθόδους στη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/).

### **Δημιουργία Πλαισίων Zoom Ενότητας**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom ενότητας σε μια διαφάνεια ως εξής:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Δημιουργήστε μια νέα διαφάνεια. 
3. Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4. Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5. Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C++ δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom σε μια διαφάνεια:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Προσθέτει μια νέα διαφάνεια στην παρουσίαση
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Προσθέτει μια νέα Ενότητα στην παρουσίαση
pres->get_Sections()->AddSection(u"Section 1", slide);

// Προσθέτει ένα αντικείμενο SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Αποθηκεύει την παρουσίαση
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Δημιουργία Πλαισίων Zoom Ενότητας με Προσαρμοσμένες Εικόνες**

Χρησιμοποιώντας το Aspose.Slides για C++, μπορείτε να δημιουργήσετε ένα πλαίσιο zoom ενότητας με διαφορετική εικόνα προεπισκόπησης της διαφάνειας ως εξής: 

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Δημιουργήστε μια νέα διαφάνεια.
3. Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4. Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που θα χρησιμοποιηθεί για τη γέμιση του πλαισίου.
5. Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει μια αναφορά στην δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C++ δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom με διαφορετική εικόνα:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Προσθέτει νέα διαφάνεια στην παρουσίαση
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Προσθέτει μια νέα Ενότητα στην παρουσίαση
pres->get_Sections()->AddSection(u"Section 1", slide);

// Δημιουργεί μια νέα εικόνα για το αντικείμενο zoom
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// Προσθέτει αντικείμενο SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// Αποθηκεύει την παρουσίαση
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Μορφοποίηση Πλαισίων Zoom Ενότητας**

Για να δημιουργήσετε πιο περίπλοκα πλαίσια zoom ενότητας, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν διάφορες επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα πλαίσιο zoom ενότητας. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός πλαισίου zoom ενότητας σε μια διαφάνεια ως εξής:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Δημιουργήστε μια νέα διαφάνεια.
3. Προσθέστε φόντο ταυτοποίησης στη δημιουργημένη διαφάνεια.
4. Δημιουργήστε μια νέα ενότητα στην οποία σκοπεύετε να συνδέσετε το πλαίσιο zoom. 
5. Προσθέστε ένα πλαίσιο zoom ενότητας (που περιέχει αναφορές στη δημιουργημένη ενότητα) στην πρώτη διαφάνεια.
6. Αλλάξτε το μέγεθος και τη θέση του δημιουργημένου αντικειμένου zoom ενότητας.
7. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) προσθέτοντας μια εικόνα στη συλλογή Images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που θα χρησιμοποιηθεί για τη γέμιση του πλαισίου.
8. Ορίστε προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο πλαισίου zoom ενότητας.
9. Ορίστε τη δυνατότητα *επιστροφής στην αρχική διαφάνεια από την συνδεδεμένη ενότητα*. 
10. Αφαιρέστε το φόντο από την εικόνα του αντικειμένου πλαισίου zoom ενότητας.
11. Αλλάξτε τη μορφή γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
12. Αλλάξτε τη διάρκεια της μετάβασης.
13. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C++ δείχνει πώς να αλλάξετε τη μορφοποίηση ενός πλαισίου zoom ενότητας:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Προσθέτει μια νέα διαφάνεια στην παρουσίαση
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Προσθέτει μια νέα Ενότητα στην παρουσίαση
pres->get_Sections()->AddSection(u"Section 1", slide);

// Προσθέτει αντικείμενο SectionZoomFrame
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// Μορφοποίηση για SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// Αποθηκεύει την παρουσίαση
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zoom Περίληψης**

Ένα zoom περίληψης λειτουργεί όπως μια σελίδα προορισμού όπου όλα τα τμήματα της παρουσίασής σας εμφανίζονται ταυτόχρονα. Όταν παρουσιάζετε, μπορείτε να χρησιμοποιήσετε το zoom για να περάσετε από ένα σημείο στην παρουσίασή σας σε άλλο με οποιαδήποτε σειρά θέλετε. Μπορείτε να είστε δημιουργικοί, να παραλείψετε κατευθύνσεις ή να επιστρέψετε σε τμήματα της παρουσίασής χωρίς να διακόψετε τη ροή της.

![overview_image](sumzoomsel.png)

Για αντικείμενα zoom περίληψης, το Aspose.Slides παρέχει τις διεπαφές [ISummaryZoomFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/isummaryzoomframe/), [ISummaryZoomSection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isummaryzoomsection/), και [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isummaryzoomsectioncollection/) καθώς και μερικές μεθόδους στη διεπαφή [IShapeCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/).

### **Δημιουργία Zoom Περίληψης**

Μπορείτε να προσθέσετε ένα πλαίσιο zoom περίληψης σε μια διαφάνεια ως εξής:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3. Προσθέστε το πλαίσιο zoom περίληψης στην πρώτη διαφάνεια.
4. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C++ δείχνει πώς να δημιουργήσετε ένα πλαίσιο zoom περίληψης σε μια διαφάνεια:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Προσθέτει μια νέα διαφάνεια στην παρουσίαση
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Προσθέτει μια νέα ενότητα στην παρουσίαση
pres->get_Sections()->AddSection(u"Section 1", slide);

// Προσθέτει μια νέα διαφάνεια στην παρουσίαση
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Προσθέτει μια νέα ενότητα στην παρουσίαση
pres->get_Sections()->AddSection(u"Section 2", slide);

// Προσθέτει μια νέα διαφάνεια στην παρουσίαση
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Προσθέτει μια νέα ενότητα στην παρουσίαση
pres->get_Sections()->AddSection(u"Section 3", slide);

// Προσθέτει μια νέα διαφάνεια στην παρουσίαση
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// Προσθέτει μια νέα ενότητα στην παρουσίαση
pres->get_Sections()->AddSection(u"Section 4", slide);

// Προσθέτει ένα αντικείμενο SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Αποθηκεύει την παρουσίαση
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Προσθήκη και Αφαίρεση Ενότητας Zoom Περίληψης**

Όλες οι ενότητες σε ένα πλαίσιο zoom περίληψης αντιπροσωπεύονται από αντικείμενα [ISummaryZoomSection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isummaryzoomsection/), τα οποία αποθηκεύονται στο αντικείμενο [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isummaryzoomsectioncollection/). Μπορείτε να προσθέσετε ή να αφαιρέσετε μια ενότητα zoom περίληψης μέσω της διεπαφής [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/isummaryzoomsectioncollection/) ως εξής:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3. Προσθέστε ένα πλαίσιο zoom περίληψης στην πρώτη διαφάνεια.
4. Προσθέστε μια νέα διαφάνεια και ενότητα στην παρουσίαση.
5. Προσθέστε τη δημιουργημένη ενότητα στο πλαίσιο zoom περίληψης.
6. Αφαιρέτε την πρώτη ενότητα από το πλαίσιο zoom περίληψης.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C++ δείχνει πώς να προσθέσετε και να αφαιρέσετε ενότητες σε ένα πλαίσιο zoom περίληψης:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Προσθέτει μια νέα διαφάνεια στην παρουσίαση
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Προσθέτει μια νέα ενότητα στην παρουσίαση
pres->get_Sections()->AddSection(u"Section 1", slide);

//Προσθέτει μια νέα διαφάνεια στην παρουσίαση
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Προσθέτει μια νέα ενότητα στην παρουσίαση
pres->get_Sections()->AddSection(u"Section 2", slide);

// Προσθέτει αντικείμενο SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Προσθέτει μια νέα διαφάνεια στην παρουσίαση
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Προσθέτει μια νέα ενότητα στην παρουσίαση
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Προσθέτει μια ενότητα στο Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Αφαιρεί ενότητα από το Summary Zoom
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// Αποθηκεύει την παρουσίαση
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Μορφοποίηση Ενοτήτων Zoom Περίληψης**

Για να δημιουργήσετε πιο περίπλοκα αντικείμενα ενότητας zoom περίληψης, πρέπει να τροποποιήσετε τη μορφοποίηση ενός απλού πλαισίου. Υπάρχουν διάφορες επιλογές μορφοποίησης που μπορείτε να εφαρμόσετε σε ένα αντικείμενο ενότητας zoom περίληψης. 

Μπορείτε να ελέγξετε τη μορφοποίηση ενός αντικειμένου ενότητας zoom περίληψης σε ένα πλαίσιο zoom περίληψης ως εξής:

1. Δημιουργήστε ένα στιγμιότυπο της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Δημιουργήστε νέες διαφάνειες με φόντο ταυτοποίησης και νέες ενότητες για τις δημιουργημένες διαφάνειες.
3. Προσθέστε ένα πλαίσιο zoom περίληψης στην πρώτη διαφάνεια.
4. Αποκτήστε ένα αντικείμενο ενότητας zoom περίληψης για το πρώτο αντικείμενο από το `ISummaryZoomSectionCollection`.
7. Δημιουργήστε ένα αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) προσθέτοντας μια εικόνα στη συλλογή images που σχετίζεται με το αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) που θα χρησιμοποιηθεί για τη γέμιση του πλαισίου.
8. Ορίστε προσαρμοσμένη εικόνα για το δημιουργημένο αντικείμενο πλαισίου zoom ενότητας.
9. Ορίστε τη δυνατότητα *επιστροφής στην αρχική διαφάνεια από την συνδεδεμένη ενότητα*. 
11. Αλλάξτε τη μορφή γραμμής για το δεύτερο αντικείμενο πλαισίου zoom.
12. Αλλάξτε τη διάρκεια της μετάβασης.
13. Αποθηκεύστε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

Αυτός ο κώδικας C++ δείχνει πώς να αλλάξετε τη μορφοποίηση ενός αντικειμένου ενότητας zoom περίληψης:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Προσθέτει μια νέα διαφάνεια στην παρουσίαση
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Προσθέτει μια νέα ενότητα στην παρουσίαση
pres->get_Sections()->AddSection(u"Section 1", slide);

//Προσθέτει μια νέα διαφάνεια στην παρουσίαση
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Προσθέτει μια νέα ενότητα στην παρουσίαση
pres->get_Sections()->AddSection(u"Section 2", slide);

// Προσθέτει ένα αντικείμενο SummaryZoomFrame
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Ανακτά το πρώτο αντικείμενο SummaryZoomSection
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// Μορφοποίηση για το αντικείμενο SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// Αποθηκεύει την παρουσίαση
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Συχνές Ερωτήσεις**

**Μπορώ να ελέγξω την επιστροφή στη «γονική» διαφάνεια μετά την προβολή του στόχου;**

Ναι. Το [Zoom frame](https://reference.aspose.com/slides/el/cpp/aspose.slides/zoomframe/) ή το [section](https://reference.aspose.com/slides/el/cpp/aspose.slides/sectionzoomframe/) διαθέτει τη μέθοδο `set_ReturnToParent` που επιστρέφει τους θεατές στην αρχική διαφάνεια μετά την επίσκεψη του περιεχομένου-στόχου.

**Μπορώ να ρυθμίσω την «ταχύτητα» ή τη διάρκεια της μετάβασης Zoom;**

Ναι. Το Zoom υποστηρίζει ορισμό διάρκειας μετάβασης ώστε να ελέγχετε πόσο χρόνο διαρκεί το εφέ άλματος.

**Υπάρχουν περιορισμοί στον αριθμό των αντικειμένων Zoom που μπορεί να περιέχει μια παρουσίαση;**

Δεν υπάρχει σκληρός περιορισμός API που να τεκμηριώνεται. Οι πρακτικοί περιορισμοί εξαρτώνται από τη συνολική πολυπλοκότητα της παρουσίασης και τις επιδόσεις του θεατή. Μπορείτε να προσθέσετε πολλά πλαίσια Zoom, αλλά λάβετε υπόψη το μέγεθος του αρχείου και το χρόνο απόδοσης.