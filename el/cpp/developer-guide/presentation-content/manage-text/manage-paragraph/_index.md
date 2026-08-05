---
title: Διαχείριση παραγράφων κειμένου PowerPoint σε C++
linktitle: Διαχείριση παραγράφου
type: docs
weight: 40
url: /el/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- προσθήκη κειμένου
- προσθήκη παραγράφου
- διαχείριση κειμένου
- διαχείριση παραγράφου
- διαχείριση κουκίδας
- εσοχή παραγράφου
- αναρτημένη εσοχή
- κουκίδα παραγράφου
- αριθμημένη λίστα
- λίστα με κουκίδες
- ιδιότητες παραγράφου
- εισαγωγή HTML
- κείμενο σε HTML
- παράγραφος σε HTML
- παράγραφος σε εικόνα
- κείμενο σε εικόνα
- εξαγωγή παραγράφου
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Κατακτήστε τη μορφοποίηση παραγράφων με το Aspose.Slides για C++ — βελτιστοποιήστε την στοίχιση, το διάστημα & το στυλ σε παρουσιάσεις PPT, PPTX και ODP σε C++."
---
## **Εισαγωγή**

Το Aspose.Slides παρέχει όλες τις διεπαφές και τις κλάσεις που χρειάζεστε για να εργάζεστε με κείμενα PowerPoint, παραγράφους και τμήματα σε C++.

* Το Aspose.Slides παρέχει τη διεπαφή [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) για να επιτρέψει την προσθήκη αντικειμένων που αντιπροσωπεύουν μια παράγραφο. Ένα αντικείμενο `ITextFame` μπορεί να έχει μία ή πολλαπλές παραγράφους (κάθε παράγραφος δημιουργείται μέσω αλλαγής γραμμής).
* Το Aspose.Slides παρέχει τη διεπαφή [IParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/) για να προσθέτει αντικείμενα που αντιπροσωπεύουν τμήματα. Ένα αντικείμενο `IParagraph` μπορεί να έχει ένα ή πολλά τμήματα (συλλογή αντικειμένων iPortions).
* Το Aspose.Slides παρέχει τη διεπαφή [IPortion](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/) για να προσθέσει αντικείμενα που αντιπροσωπεύουν κείμενα και τις ιδιότητες μορφοποίησής τους.

Ένα αντικείμενο `IParagraph` είναι ικανό να διαχειρίζεται κείμενα με διαφορετικές ιδιότητες μορφοποίησης μέσω των υποκείμενων αντικειμένων `IPortion`.

## **Προσθήκη Πολλαπλών Παραγράφων που Περιέχουν Πολλαπλά Τμήματα**

Αυτά τα βήματα δείχνουν πώς να προσθέσετε ένα πλαίσιο κειμένου που περιέχει 3 παραγράφους και κάθε παράγραφος να περιέχει 3 τμήματα:

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Προσπελάστε την αντίστοιχη αναφορά της διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα ορθογώνιο [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
4. Αποκτήστε το ITextFrame που σχετίζεται με το [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/).
5. Δημιουργήστε δύο αντικείμενα [IParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/) και προσθέστε τα στη συλλογή `IParagraphs` του [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/).
6. Δημιουργήστε τρία αντικείμενα [IPortion](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportion/) για κάθε νέο `IParagraph` (δύο αντικείμενα Portion για την προεπιλεγμένη Παράγραφο) και προσθέστε κάθε αντικείμενο `IPortion` στη συλλογή IPortion του κάθε `IParagraph`.
7. Ορίστε κάποιο κείμενο για κάθε τμήμα.
8. Εφαρμόστε τις προτιμώμενες ιδιότητες μορφοποίησης σε κάθε τμήμα χρησιμοποιώντας τις ιδιότητες μορφοποίησης που εκτίθενται από το αντικείμενο `IPortion`.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c++
// Η διαδρομή προς το φάκελο εγγράφων.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Φόρτωση της επιθυμητής παρουσίασης
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Προσθήκη AutoShape τύπου Ορθογώνιο
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Προσθήκη TextFrame στο Ορθογώνιο
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Πρόσβαση στην πρώτη Παράγραφο
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Προσθήκη δεύτερης Παραγράφου
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Προσθήκη τρίτης Παραγράφου
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// Αποθήκευση PPTX στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Διαχείριση Κουκίδων Παραγράφων**

Οι λίστες με κουκίδες βοηθούν στην οργάνωση και παρουσίαση των πληροφοριών γρήγορα και αποτελεσματικά. Οι παράγραφοι με κουκίδες είναι πάντα πιο εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Προσπελάστε την αντίστοιχη αναφορά της διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στην επιλεγμένη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) του autoshape. 
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraph/).
7. Ορίστε το `Type` της κουκίδας για την παράγραφο σε `Symbol` και ορίστε το χαρακτήρα της κουκίδας.
8. Ορίστε το `Text` της παραγράφου.
9. Ορίστε το `Indent` της παραγράφου για την κουκίδα.
10. Ορίστε χρώμα για την κουκίδα.
11. Ορίστε ύψος για την κουκίδα.
12. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
13. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία που περιγράφεται στα βήματα 7 έως 13.
14. Αποθηκεύστε την παρουσίαση.

```c++
// Η διαδρομή προς το φάκελο εγγράφων.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Φόρτωση της επιθυμητής παρουσίασης
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Προσθήκη AutoShape τύπου Ορθογώνιο
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Προσθήκη TextFrame στο Ορθογώνιο
ashp->AddTextFrame(u"");

// Πρόσβαση στο πλαίσιο κειμένου
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Δημιουργία αντικειμένου Paragraph για το πλαίσιο κειμένου
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Ορισμός κειμένου
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Ορισμός εσοχής κουκίδας
paragraph->get_ParagraphFormat()->set_Indent (25);

// Ορισμός χρώματος κουκίδας
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// ορίστε IsBulletHardColor σε true για χρήση δικού χρώματος κουκίδας
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Ορισμός Ύψους κουκίδας
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Προσθήκη Paragraph στο πλαίσιο κειμένου
txtFrame->get_Paragraphs()->Add(paragraph);

// Δημιουργία δεύτερης παραγράφου
// Δημιουργία αντικειμένου Paragraph για το πλαίσιο κειμένου
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// Ορισμός κειμένου
paragraph2->set_Text(u"This is numbered bullet");

// Ορισμός τύπου και στυλ κουκίδας παραγράφου
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Ορισμός εσοχής κουκίδας
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Ορισμός χρώματος κουκίδας
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// ορίστε IsBulletHardColor σε true για χρήση δικού χρώματος κουκίδας
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Ορισμός Ύψους κουκίδας
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Προσθήκη Paragraph στο πλαίσιο κειμένου
txtFrame->get_Paragraphs()->Add(paragraph2);


// Αποθήκευση PPTX στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Διαχείριση Κουκίδων Εικόνας**

Οι λίστες με κουκίδες βοηθούν στην οργάνωση και παρουσίαση των πληροφοριών γρήγορα και αποτελεσματικά. Οι παράγραφοι με εικόνα είναι εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Προσπελάστε την αντίστοιχη αναφορά της διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) του autoshape. 
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου χρησιμοποιώντας την κλάση [Paragraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraph/).
7. Φορτώστε την εικόνα στο [IPPImage](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/).
8. Ορίστε το τύπο κουκίδας σε [Picture](https://reference.aspose.com/slides/el/cpp/aspose.slides/ippimage/) και ορίστε την εικόνα.
9. Ορίστε το `Text` της Paragraph.
10. Ορίστε το `Indent` της Paragraph για την κουκίδα.
11. Ορίστε χρώμα για την κουκίδα.
12. Ορίστε ύψος για την κουκίδα.
13. Προσθέστε τη νέα παράγραφο στη συλλογή παραγράφων του `TextFrame`.
14. Προσθέστε τη δεύτερη παράγραφο και επαναλάβετε τη διαδικασία βάσει των προηγούμενων βημάτων.
15. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c++
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Προσπελάζει την πρώτη διαφάνεια
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Δημιουργεί την εικόνα για τις κουκίδες
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Προσθέτει και προσπελαύνει το Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Προσπελαίνει το πλαίσιο κειμένου του autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Αφαιρεί την προεπιλεγμένη παράγραφο
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Δημιουργεί μια νέα παράγραφο
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Ορίζει το στυλ και την εικόνα της κουκίδας παραγράφου
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Ορίζει το ύψος της κουκίδας
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Προσθέτει την παράγραφο στο πλαίσιο κειμένου
paragraphs->Add(paragraph);

// Αποθηκεύει την παρουσίαση ως αρχείο PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Αποθηκεύει την παρουσίαση ως αρχείο PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Διαχείριση Πολυεπίπεδων Κουκίδων**

Οι λίστες με κουκίδες βοηθούν στην οργάνωση και παρουσίαση των πληροφοριών γρήγορα και αποτελεσματικά. Οι πολυεπίπεδες κουκίδες είναι εύκολες στην ανάγνωση και κατανόηση.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Προσπελάστε την αντίστοιχη αναφορά της διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη νέα διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) του autoshape. 
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraph/) και ορίστε το βάθος σε 0.
7. Δημιουργήστε το δεύτερο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 1.
8. Δημιουργήστε το τρίτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 2.
9. Δημιουργήστε το τέταρτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το βάθος σε 3.
10. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
11. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c++
// Δημιουργεί μια κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Προσπελάζει την πρώτη διαφάνεια
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Προσθέτει και προσπελαύνει το Autoshape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Προσπελαίνει το πλαίσιο κειμένου του δημιουργημένου autoshape
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Καθαρίζει την προεπιλεγμένη παράγραφο
text->get_Paragraphs()->Clear();

// Προσθέτει την πρώτη παράγραφο
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ορίζει το επίπεδο κουκίδας
para1Format->set_Depth(0);

// Προσθέτει τη δεύτερη παράγραφο
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ορίζει το επίπεδο κουκίδας
para2Format->set_Depth(1);

// Προσθέτει την τρίτη παράγραφο
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ορίζει το επίπεδο κουκίδας
para3Format->set_Depth(2);

// Προσθέτει την τέταρτη παράγραφο
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ορίζει το επίπεδο κουκίδας
para4Format->set_Depth(3);

// Προσθέτει τις παραγράφους στη συλλογή
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Αποθηκεύει την παρουσίαση ως αρχείο PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Διαχείριση Παραγράφου με Προσαρμοσμένη Αριθμητική Λίστα**

Η διεπαφή [IBulletFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/) παρέχει την ιδιότητα [NumberedBulletStartWith](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) και άλλες που σας επιτρέπουν να διαχειρίζεστε παραγράφους με προσαρμοσμένη αρίθμηση ή μορφοποίηση. 

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Προσπελάστε τη διαφάνεια που περιέχει την παράγραφο.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) του autoshape. 
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `TextFrame`.
6. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraph/) και ορίστε το [NumberedBulletStartWith](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) σε 2.
7. Δημιουργήστε το δεύτερο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 3.
8. Δημιουργήστε το τρίτο αντικείμενο παραγράφου μέσω της κλάσης `Paragraph` και ορίστε το `NumberedBulletStartWith` σε 7.
9. Προσθέστε τις νέες παραγράφους στη συλλογή παραγράφων του `TextFrame`.
10. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Προσπελάζει το πλαίσιο κειμένου του δημιουργημένου autoshape
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Αφαιρεί την προεπιλεγμένη υπάρχουσα παράγραφο
textFrame->get_Paragraphs()->RemoveAt(0);

// Πρώτη λίστα
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **Ορισμός Εσοχής Πρώτης Γραμμής για Παράγραφο**

Χρησιμοποιήστε τη μέθοδο [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_indent/) για να ελέγξετε την εσοχή της πρώτης γραμμής μιας παραγράφου. Αυτή η μέθοδος μετακινεί μόνο την πρώτη γραμμή σε σχέση με το αριστερό περιθώριο της παραγράφου. Μια θετική τιμή μετατοπίζει την πρώτη γραμμή προς τα δεξιά, ενώ οι υπόλοιπες γραμμές παραμένουν ευθυγραμμισμένες με το σώμα της παραγράφου.

Χρησιμοποιήστε το [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_marginleft/) όταν χρειάζεται να μετακινήσετε ολόκληρη την παράγραφο. Χρησιμοποιήστε το [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_indent/) όταν χρειάζεται να μετακινήσετε μόνο την πρώτη γραμμή.

Το παρακάτω παράδειγμα δημιουργεί πολλές παραγράφους και εφαρμόζει διαφορετικές τιμές `Indent` για να δείξει πώς η εσοχή της πρώτης γραμμής επηρεάζει τη διάταξη της παραγράφου.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Προσπελάστε τη στοχευόμενη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε πολλές παραγράφους και ορίστε διαφορετικές τιμές [Indent](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_indent/) για αυτές.
6. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
7. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η εσοχή της πρώτης γραμμής των παραγράφων](first_line_indent.png)

## **Ορισμός Ανεστραμμένης Εσοχής για Παράγραφο**

Η ανεστραμμένη εσοχή είναι μια διάταξη παραγράφου όπου η πρώτη γραμμή ξεκινά αριστερά από τις υπόλοιπες γραμμές. Στο Aspose.Slides, δημιουργείτε αυτό το εφέ με τη μέθοδο [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_indent/). Ορίστε την εσοχή σε αρνητική τιμή για να μετακινήσετε την πρώτη γραμμή προς τα αριστερά σε σχέση με το σώμα της παραγράφου.

Στην πράξη, το [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_marginleft/) ορίζει τη θέση αριστερά του σώματος της παραγράφου, και το [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_indent/) ορίζει τη θέση της πρώτης γραμμής σε σχέση με αυτό το περιθώριο. Για να δημιουργήσετε μια ανεστραμμένη εσοχή, ορίστε μια θετική τιμή `MarginLeft` και μια αρνητική τιμή `Indent`.

Αυτή η μορφοποίηση είναι χρήσιμη για βιβλιογραφίες, παραπομπές, εγγραφές γλωσσολογίου και άλλες παραγράφους όπου οι γραμμές που αναδιπλώνονται πρέπει να ευθυγραμμίζονται κάτω από το σώμα της παραγράφου παρά κάτω από τον πρώτο χαρακτήρα της πρώτης γραμμής.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Προσπελάστε τη στοχευόμενη διαφάνεια.
3. Προσθέστε ένα ορθογώνιο [AutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/autoshape/) στη διαφάνεια.
4. Προσθέστε ένα κενό [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframe/) στο σχήμα και αφαιρέστε την προεπιλεγμένη παράγραφο.
5. Δημιουργήστε παραγράφους και ορίστε μια θετική τιμή [MarginLeft](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_marginleft/) για κάθε παράγραφο.
6. Ορίστε μια αρνητική τιμή [Indent](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/set_indent/) για να δημιουργήσετε το εφέ της ανεστραμμένης εσοχής.
7. Προσθέστε τις παραγράφους στο πλαίσιο κειμένου.
8. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η ανεστραμμένη εσοχή των παραγράφων](hanging_indent.png)

## **Διαχείριση Ιδιοτήτων Τέλους Παραγράφου**

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
1. Πάρτε την αναφορά για τη διαφάνεια που περιέχει την παράγραφο μέσω της θέσης της.
1. Προσθέστε ένα ορθογώνιο [autoshape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
1. Προσθέστε ένα [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) με δύο παραγράφους στο Rectangle.
1. Ορίστε το `FontHeight` και το τύπο γραμματοσειράς για τις παραγράφους.
1. Ορίστε τις ιδιότητες End για τις παραγράφους.
1. Γράψτε την τροποποιημένη παρουσίαση ως αρχείο PPTX.

```c++
// Η διαδρομή προς το φάκελο εγγράφων.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Φόρτωση της επιθυμητής παρουσίασης
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Προσθήκη AutoShape τύπου Ορθογώνιο
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Προσθήκη TextFrame στο Ορθογώνιο
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Προσθήκη της πρώτης Παραγράφου
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Προσθήκη της δεύτερης Παραγράφου
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Αποθήκευση PPTX στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Εισαγωγή Κειμένου HTML σε Παραγράφους**

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για την εισαγωγή κειμένου HTML σε παραγράφους.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/).
2. Προσπελάστε την αντίστοιχη αναφορά της διαφάνειας μέσω του δείκτη της.
3. Προσθέστε ένα [autoshape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) στη διαφάνεια.
4. Προσθέστε και προσπελάστε το [ITextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) του autoshape 
5. Αφαιρέστε την προεπιλεγμένη παράγραφο στο `ITextFrame`.
6. Διαβάστε το πηγαίο αρχείο HTML σε έναν TextReader.
7. Δημιουργήστε το πρώτο αντικείμενο παραγράφου μέσω της κλάσης [Paragraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraph/).
8. Προσθέστε το περιεχόμενο του αρχείου HTML που διαβάστηκε από το TextReader στη [ParagraphCollection](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraphcollection/) του TextFrame.
9. Αποθηκεύστε την τροποποιημένη παρουσίαση.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Η διαδρομή προς το φάκελο εγγράφων.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Φόρτωση της επιθυμητής παρουσίασης
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Πρόσβαση στην πρώτη διαφάνεια
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Προσθήκη AutoShape τύπου Ορθογώνιο
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Επαναφορά του προεπιλεγμένου χρώματος γεμίσματος
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Προσθήκη TextFrame στο Ορθογώνιο
ashp->AddTextFrame(u" ");

// Πρόσβαση στο πλαίσιο κειμένου
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//Λήψη συλλογής Paragraphs
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Καθαρισμός όλων των παραγράφων στο προστεθέν πλαίσιο κειμένου
ParaCollection->Clear();

// Φόρτωση του αρχείου HTML χρησιμοποιώντας stream reader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Προσθήκη κειμένου από το HTML stream reader στο πλαίσιο κειμένου
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Δημιουργία του αντικειμένου Paragraph για το πλαίσιο κειμένου
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Δημιουργία αντικειμένου Portion για την παράγραφο
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Λήψη μορφοποίησης του portion
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Ορισμός γραμματοσειράς για το Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Ορισμός ιδιότητας Bold στη γραμματοσειρά
pf->set_FontBold(NullableBool::True);

// Ορισμός ιδιότητας Italic στη γραμματοσειρά
pf->set_FontItalic(NullableBool::True);

// Ορισμός ιδιότητας Underline στη γραμματοσειρά
pf->set_FontUnderline(TextUnderlineType::Single);

// Ορισμός ύψους της γραμματοσειράς
pf->set_FontHeight(25);

// Ορισμός χρώματος της γραμματοσειράς
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Αποθήκευση PPTX στο δίσκο
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **Εξαγωγή Κειμένου Παραγράφου σε HTML**

Το Aspose.Slides παρέχει βελτιωμένη υποστήριξη για την εξαγωγή κειμένων (που περιέχονται σε παραγράφους) σε HTML.

1. Δημιουργήστε μια παρουσία της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) και φορτώστε την επιθυμητή παρουσίαση.
2. Προσπελάστε την αντίστοιχη αναφορά της διαφάνειας μέσω του δείκτη της.
3. Προσπελάστε το σχήμα που περιέχει το κείμενο που θα εξαχθεί σε HTML.
4. Προσπελάστε το [TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframe/) του σχήματος.
5. Δημιουργήστε μια παρουσία του `StreamWriter` και προσθέστε το νέο αρχείο HTML.
6. Ορίστε έναν αρχικό δείκτη στο StreamWriter και εξάγετε τις επιθυμητές παραγράφους.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Η διαδρομή προς το φάκελο εγγράφων.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Φόρτωση της επιθυμητής παρουσίασης
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Πρόσβαση στην προεπιλεγμένη πρώτη διαφάνεια της παρουσίασης
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Απαιτούμενος δείκτης
int index = 0;

// Πρόσβαση στο προστεθέν σχήμα
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Εξαγωγή της πρώτης παραγράφου ως HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

//Γραφή δεδομένων παραγράφων σε HTML παρέχοντας τον αρχικό δείκτη παραγράφου, το συνολικό αριθμό παραγράφων που θα αντιγραφούν
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **Αποθήκευση Παραγράφου ως Εικόνα**

Σε αυτήν την ενότητα, θα εξερευνήσουμε δύο παραδείγματα που δείχνουν πώς να αποθηκεύσετε μια παράγραφο κειμένου, που αναπαρίσταται από τη διεπαφή [IParagraph](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraph/), ως εικόνα. Και τα δύο παραδείγματα περιλαμβάνουν τη λήψη της εικόνας ενός σχήματος που περιέχει την παράγραφο χρησιμοποιώντας τις μεθόδους `GetImage` από τη διεπαφή [IShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/), τον υπολογισμό των ορίων της παραγράφου εντός του σχήματος και την εξαγωγή της ως εικόνα bitmap. Αυτές οι προσεγγίσεις σας επιτρέπουν να εξάγετε συγκεκριμένα τμήματα του κειμένου από παρουσιάσεις PowerPoint και να τα αποθηκεύσετε ως ξεχωριστές εικόνες, κάτι που μπορεί να είναι χρήσιμο για περαιτέρω χρήση σε διάφορα σενάρια.

Ας υποθέσουμε ότι έχουμε ένα αρχείο παρουσίασης με όνομα sample.pptx με μία διαφάνεια, όπου το πρώτο σχήμα είναι ένα πλαίσιο κειμένου που περιέχει τρεις παραγράφους.

![Το πλαίσιο κειμένου με τρεις παραγράφους](paragraph_to_image_input.png)

**Example 1**

Σε αυτό το παράδειγμα, εξάγουμε τη δεύτερη παράγραφο ως εικόνα. Για να το κάνουμε αυτό, εξάγουμε την εικόνα του σχήματος από την πρώτη διαφάνεια της παρουσίασης και στη συνέχεια υπολογίζουμε τα όρια της δεύτερης παραγράφου στο πλαίσιο κειμένου του σχήματος. Η παράγραφος στη συνέχεια επανέλθει σε μια νέα εικόνα bitmap, η οποία αποθηκεύεται σε μορφή PNG. Αυτή η μέθοδος είναι ιδιαίτερα χρήσιμη όταν χρειάζεται να αποθηκεύσετε μια συγκεκριμένη παράγραφο ως ξεχωριστή εικόνα διατηρώντας τις ακριβείς διαστάσεις και τη μορφοποίηση του κειμένου.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

Το αποτέλεσμα:

![Η εικόνα της παραγράφου](paragraph_to_image_output.png)

**Example 2**

Σε αυτό το παράδειγμα, επεκτείνουμε την προηγούμενη προσέγγιση προσθέτοντας παράγοντες κλιμάκωσης στην εικόνα της παραγράφου. Το σχήμα εξάγεται από την παρουσίαση και αποθηκεύεται ως εικόνα με παράγοντα κλιμάκωσης `2`. Αυτό επιτρέπει ένα υψηλότερη ανάλυση εξόδου κατά την εξαγωγή της παραγράφου. Τα όρια της παραγράφου υπολογίζονται έπειτα λαμβάνοντας υπόψη την κλίμακα. Η κλιμάκωση μπορεί να είναι ιδιαίτερα χρήσιμη όταν απαιτείται πιο λεπτομερής εικόνα, για παράδειγμα για χρήση σε υψηλής ποιότητας έντυπο υλικό.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Αποθήκευση του σχήματος στη μνήμη ως bitmap με κλιμάκωση.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **FAQ**

**Μπορώ να απενεργοποιήσω εντελώς τη διακίνηση γραμμών μέσα σε ένα πλαίσιο κειμένου;**

Ναι. Χρησιμοποιήστε τη μέθοδο περιτύλιξης του πλαισίου κειμένου ([set_WrapText](https://reference.aspose.com/slides/el/cpp/aspose.slides/textframeformat/set_wraptext/)) για απενεργοποίηση της περιτύλιξης ώστε οι γραμμές να μην κόβονται στα άκρα του πλαισίου.

**Πώς μπορώ να λάβω τα ακριβή όρια σε διαφάνεια μιας συγκεκριμένης παραγράφου;**

Μπορείτε να ανακτήσετε το ορθογώνιο περιορισμού της παραγράφου (και ακόμη ενός μεμονωμένου τμήματος) για να γνωρίζετε τη ακριβή θέση και μέγεθός της στη διαφάνεια.

**Πού ελέγχεται η στοίχιση παραγράφου (αριστερά/δεξιά/κεντρά/ίση) ;**

Η [Alignment](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraphformat/set_alignment/) είναι ρύθμιση επιπέδου παραγράφου στο [ParagraphFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/paragraphformat/); εφαρμόζεται σε ολόκληρη την παράγραφο ανεξαρτήτως μορφοποίησης επιμέρους τμημάτων.

**Μπορώ να ορίσω γλώσσα ορθογραφικού ελέγχου μόνο για μέρος μιας παραγράφου (π.χ. μία λέξη);**

Ναι. Η γλώσσα ορίζεται σε επίπεδο τμήματος χρησιμοποιώντας ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/el/cpp/aspose.slides/baseportionformat/set_languageid/)), έτσι ώστε πολλές γλώσσες να μπορούν να συνυπάρχουν μέσα στην ίδια παράγραφο.