---
title: Διαχείριση λιστών με κουκίδες και αριθμούς σε παρουσιάσεις σε C++
linktitle: Διαχείριση λιστών
type: docs
weight: 70
url: /el/cpp/manage-lists/
keywords:
- κουκίδα
- λίστα με κουκίδες
- αριθμημένη λίστα
- σύμβολο κουκίδας
- κουκίδα εικόνας
- προσαρμοσμένη κουκίδα
- πολυεπίπεδη λίστα
- δημιουργία κουκίδας
- προσθήκη κουκίδας
- προσθήκη λίστας
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε και να μορφοποιείτε λίστες με κουκίδες, εικόνες, πολυεπίπεδες και αριθμημένες σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για C++."
---
## **Επισκόπηση**

Το Aspose.Slides για C++ σάς επιτρέπει να δημιουργείτε και να μορφοποιείτε λίστες με κουκίδες και αριθμημένες λίστες σε παρουσιάσεις PowerPoint και OpenDocument. Ένα στοιχείο λίστας είναι μια παράγραφος της οποίας οι ρυθμίσεις της κουκίδας ελέγχονται μέσω της μορφοποίησης της παραγράφου.

Χρησιμοποιήστε τη μέθοδο [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/get_paragraphformat/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις λίστας σε επίπεδο παραγράφου. Το κύριο σημείο εισόδου είναι [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/get_bullet/), που επιστρέφει ένα αντικείμενο τύπου [IBulletFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/). Με αυτό το αντικείμενο, μπορείτε να ορίσετε τον τύπο της κουκίδας, το σύμβολο, την εικόνα, το χρώμα, το μέγεθος, το στυλ αρίθμησης και τον αρχικό αριθμό.

Αυτό το άρθρο δείχνει πώς να:

- δημιουργήσετε μια λίστα με κουκίδες με προσαρμοσμένο σύμβολο
- δημιουργήσετε μια κουκίδα εικόνας
- δημιουργήσετε μια πολυεπίπεδη λίστα ορίζοντας το βάθος της παραγράφου
- δημιουργήσετε μια αριθμημένη λίστα
- επιθεωρήσετε και αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση

## **Δημιουργία λίστας με κουκίδες**

Για να δημιουργήσετε μια λίστα με κουκίδες, προσθέστε αντικείμενα [Paragraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraph/) σε ένα [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) και ορίστε το [IBulletFormat::set_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/set_type/) σε [BulletType::Symbol](https://reference.aspose.com/slides/el/cpp/aspose.slides/bullettype/). Στη συνέχεια, μπορείτε να ορίσετε το [IBulletFormat::set_Char](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/set_char/), το [IBulletFormat::get_Color](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/get_color/) και το [IBulletFormat::set_Height](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/set_height/) για να ελέγξετε την εμφάνιση της κουκίδας.

Ο παρακάτω κώδικας C++ δείχνει πώς να δημιουργήσετε μια λίστα με κουκίδες σε μια διαφάνεια:

```cpp
auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι σύμβολα των κουκίδων](symbol_bullets.png)

## **Δημιουργία αριθμημένης λίστας**

Χρησιμοποιήστε αριθμημένες λίστες όταν η σειρά των στοιχείων έχει σημασία. Ορίστε το [IBulletFormat::set_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/set_type/) σε [BulletType::Numbered](https://reference.aspose.com/slides/el/cpp/aspose.slides/bullettype/). Μπορείτε επίσης να επιλέξετε μορφή αρίθμησης με το [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) ή να ορίσετε το [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) όταν η λίστα πρέπει να ξεκινήσει από τιμή διαφορετική του 1.

Ο παρακάτω κώδικας C++ δείχνει πώς να δημιουργήσετε μια αριθμημένη λίστα σε μια διαφάνεια:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι αριθμημένες κουκίδες](numbered_bullets.png)

## **Δημιουργία κουκίδας εικόνας**

Το Aspose.Slides σας επιτρέπει να αντικαταστήσετε το κανονικό σύμβολο της κουκίδας με μια εικόνα. Οι κουκίδες εικόνας λειτουργούν καλύτερα με απλές εικόνες που παραμένουν αναγνώσιμες σε μικρό μέγεθος, όπως εικονίδια ή μικρά διαφαίνοντα αρχεία PNG.

{{% alert color="primary" %}}
Ιδανικά, εάν σκοπεύετε να αντικαταστήσετε το κανονικό σύμβολο της κουκίδας με μια εικόνα, είναι καλύτερο να επιλέξετε ένα απλό γραφικό με διαφανές φόντο. Τέτοιες εικόνες λειτουργούν καλά ως προσαρμοσμένα σύμβολα κουκίδας.
{{% /alert %}}

Για να δημιουργήσετε μια κουκίδα εικόνας, προσθέστε μια εικόνα στο [IPresentation::get_Images](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipresentation/get_images/) και αντιστοιχίστε το επιστρεφόμενο αντικείμενο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) στο [IBulletFormat::get_Picture](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/get_picture/). Ορίστε το [IBulletFormat::set_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/set_type/) σε [BulletType::Picture](https://reference.aspose.com/slides/el/cpp/aspose.slides/bullettype/) πριν αντιστοιχίσετε την εικόνα.

Ας υποθέσουμε ότι έχουμε το "image.png":

![Μια εικόνα για τις κουκίδες](picture_for_bullets.png)

Ο παρακάτω κώδικας C++ δείχνει πώς να δημιουργήσετε κουκίδες εικόνας σε μια διαφάνεια:

```cpp
auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι κουκίδες με εικόνα](picture_bullets.png)

## **Δημιουργία πολυεπίπεδης λίστας**

Χρησιμοποιήστε το [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_depth/) για να τοποθετήσετε στοιχεία λίστας σε διαφορετικά επίπεδα. Το επίπεδο 0 είναι το κορυφαίο επίπεδο, το επίπεδο 1 είναι ένθετο κάτω από αυτό, κ.λπ.

Ο παρακάτω κώδικας C++ δείχνει πώς να δημιουργήσετε μια πολυεπίπεδη λίστα με κουκίδες:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η πολυεπίπεδη λίστα](multilevel_list.png)

## **Αλλαγή υπάρχουσας λίστας**

Για να αλλάξετε τη μορφοποίηση λίστας σε υπάρχουσα παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο και ενημερώστε τις ρυθμίσεις του [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/get_bullet/). Οι ίδιες ιδιότητες που χρησιμοποιούνται για τη δημιουργία λιστών μπορούν να χρησιμοποιηθούν για την επιθεώρηση ή την τροποποίηση λιστών που έχουν φορτωθεί από αρχείο PPT, PPTX ή ODP.

Ο παρακάτω κώδικας C++ αλλάζει την πρώτη παράγραφο σε ένα πλαίσιο κειμένου ώστε να χρησιμοποιεί στυλ αριθμημένης λίστας:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συχνές ερωτήσεις**

**Μπορούν οι λίστες με κουκίδες και αριθμημένες λίστες να εξαχθούν σε PDF ή εικόνες;**

Ναι. Το Aspose.Slides διατηρεί τη μορφοποίηση της λίστας όταν η μορφή προορισμού υποστηρίζει την αντίστοιχη διάταξη κειμένου και τις δυνατότητες κουκίδας.

**Μπορώ να επεξεργαστώ λίστες σε υπάρχουσες παρουσιάσεις;**

Ναι. Φορτώστε την παρουσίαση, αποκτήστε πρόσβαση στην επιθυμητή παράγραφο, επιθεωρήστε ή ενημερώστε τις ρυθμίσεις του [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/get_bullet/) και αποθηκεύστε την παρουσίαση.

**Μπορούν οι λίστες να περιέχουν μη λατινικό κείμενο;**

Ναι. Το κείμενο των στοιχείων λίστας μπορεί να περιέχει χαρακτήρες Unicode, ώστε να μπορείτε να δημιουργείτε λίστες σε πολυγλωσσικές παρουσιάσεις. Βεβαιωθείτε ότι οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση υποστηρίζουν τους χαρακτήρες που χρειάζεστε.