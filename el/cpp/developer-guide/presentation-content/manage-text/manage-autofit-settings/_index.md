---
title: "Βελτιώστε τις παρουσιάσεις σας με το AutoFit σε C++"
linktitle: "Ρυθμίσεις Autofit"
type: docs
weight: 30
url: /el/cpp/manage-autofit-settings/
keywords:
- "πλαίσιο κειμένου"
- "autofit"
- "μη αυτόματη προσαρμογή"
- "προσαρμογή κειμένου"
- "συστολή κειμένου"
- "αναδίπλωση κειμένου"
- "αλλαγή μεγέθους σχήματος"
- "PowerPoint"
- "OpenDocument"
- "παρουσίαση"
- "C++"
- "Aspose.Slides"
description: "Μάθετε πώς να διαχειρίζεστε τις ρυθμίσεις AutoFit στο Aspose.Slides για C++ ώστε να βελτιστοποιήσετε την εμφάνιση του κειμένου στις παρουσιάσεις PowerPoint και OpenDocument και να βελτιώσετε την αναγνωσιμότητα του περιεχομένου."
---
## **Εισαγωγή**

Από προεπιλογή, όταν προσθέτετε ένα πλαίσιο κειμένου, το Microsoft PowerPoint χρησιμοποιεί τη ρύθμιση **Resize shape to fix text** για το πλαίσιο κειμένου – αυτόματα αλλάζει το μέγεθος του πλαισίου κειμένου ώστε το κείμενο του να χωράει πάντα.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Όταν το κείμενο στο πλαίσιο κειμένου γίνει μεγαλύτερο ή πιο εκτενές, το PowerPoint αυτόματα επεκτείνει το πλαίσιο κειμένου—αυξάνει το ύψος του—ώστε να χωράει περισσότερο κείμενο.  
* Όταν το κείμενο στο πλαίσιο κειμένου γίνει πιο σύντομο ή μικρότερο, το PowerPoint αυτόματα μειώνει το πλαίσιο κειμένου—μειώνει το ύψος του—για να αφαιρέσει το περιττό κενό.

Στο PowerPoint, αυτά είναι τα 4 σημαντικά παραμέτρους ή επιλογές που ελέγχουν τη συμπεριφορά autofit για ένα πλαίσιο κειμένου:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Το Aspose.Slides for C++ παρέχει παρόμοιες επιλογές—μερικές μεθόδους στην κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame_format)—που σάς επιτρέπουν να ελέγχετε τη συμπεριφορά autofit για πλαίσια κειμένου σε παρουσιάσεις. 

## **Αλλαγή μεγέθους σχήματος ώστε να ταιριάζει το κείμενο**

Εάν θέλετε το κείμενο σε ένα πλαίσιο να ταιριάζει πάντα στο πλαίσιο μετά από αλλαγές, πρέπει να χρησιμοποιήσετε την επιλογή **Resize shape to fix text**. Για να καθορίσετε αυτή τη ρύθμιση, ορίστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame_format)) σε `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε ότι το κείμενο πρέπει πάντα να χωράει στο πλαίσιο του σε μια παρουσίαση PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Εάν το κείμενο γίνει μεγαλύτερο ή πιο εκτενές, το πλαίσιο κειμένου θα επεκταθεί αυτόματα (αύξηση σε ύψος) ώστε όλο το κείμενο να χωράει. Εάν το κείμενο γίνει πιο σύντομο, συμβαίνει το αντίθετο. 

## **Do Not Autofit**

Εάν θέλετε ένα πλαίσιο κειμένου ή σχήμα να διατηρεί τις διαστάσεις του ανεξάρτητα από τις αλλαγές του κειμένου, πρέπει να χρησιμοποιήσετε την επιλογή **Do not Autofit**. Για να καθορίσετε αυτή τη ρύθμιση, ορίστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame_format)) σε `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε ότι ένα πλαίσιο κειμένου πρέπει πάντα να διατηρεί τις διαστάσεις του σε μια παρουσίαση PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Όταν το κείμενο γίνει πολύ μεγάλο για το πλαίσιο του, θα υπερχειλίσει. 

## **Shrink Text on Overflow**

Εάν ένα κείμενο γίνει πολύ μεγάλο για το πλαίσιο, μέσω της επιλογής **Shrink text on overflow** μπορείτε να ορίσετε ότι το μέγεθος και οι αποστάσεις του κειμένου πρέπει να μειωθούν ώστε να ταιριάζει στο πλαίσιο. Για να καθορίσετε αυτή τη ρύθμιση, ορίστε την ιδιότητα [AutofitType](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame_format)) σε `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Αυτός ο κώδικας C++ δείχνει πώς να ορίσετε ότι το κείμενο πρέπει να μειώνεται όταν υπερχειλίζει σε μια παρουσίαση PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Πληροφορίες" color="info" %}}
Όταν χρησιμοποιείται η επιλογή **Shrink text on overflow**, η ρύθμιση εφαρμόζεται μόνο όταν το κείμενο γίνεται πολύ μεγάλο για το πλαίσιο του. 
{{% /alert %}}

## **Wrap Text**

Εάν θέλετε το κείμενο μέσα σε ένα σχήμα να αναδιπλώνεται μέσα στο σχήμα όταν το κείμενο ξεπερνά το όριο του σχήματος (μόνο το πλάτος), πρέπει να χρησιμοποιήσετε την παράμετρο **Wrap text in shape**. Για να καθορίσετε αυτή τη ρύθμιση, ορίστε την ιδιότητα [WrapText](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (από την κλάση [TextFrameFormat](https://reference.aspose.com/slides/el/cpp/class/aspose.slides.text_frame_format)) σε `true`. 

Αυτός ο κώδικας C++ δείχνει πώς να χρησιμοποιήσετε τη ρύθμιση Wrap Text σε μια παρουσίαση PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Σημείωση" color="warning" %}} 
Εάν ορίσετε την ιδιότητα `WrapText` σε `False` για ένα σχήμα, όταν το κείμενο μέσα στο σχήμα γίνει πιο μακρύ από το πλάτος του σχήματος, το κείμενο θα επεκταθεί πέρα από τα όρια του σχήματος σε μία μόνο γραμμή. 
{{% /alert %}}

## **Συχνές ερωτήσεις**

**Επηρεάζουν τα εσωτερικά περιθώρια του πλαισίου κειμένου το AutoFit;**

Ναι. Τα εσωτερικά περιθώρια (padding) μειώνουν την διαθέσιμη περιοχή για κείμενο, οπότε το AutoFit θα ενεργοποιηθεί νωρίτερα – μειώνοντας τη γραμματοσειρά ή αλλάζοντας το μέγεθος του σχήματος πιο γρήγορα. Ελέγξτε και προσαρμόστε τα περιθώρια πριν ρυθμίσετε το AutoFit.

**Πώς αλληλεπιδρά το AutoFit με χειροκίνητες και μαλακές αλλαγές γραμμής;**

Οι υποχρεωτικές αλλαγές γραμμής παραμένουν, και το AutoFit προσαρμόζει το μέγεθος γραμματοσειράς και το διάστημα γύρω τους. Η αφαίρεση περιττών αλλαγών γραμμής συχνά μειώνει το πόσο έντονα το AutoFit χρειάζεται να μειώσει το κείμενο.

**Αλλάζει η αλλαγή της γραμματοσειράς θέματος ή η αντικατάσταση γραμματοσειράς τα αποτελέσματα του AutoFit;**

Ναι. Η αντικατάσταση με γραμματοσειρά που έχει διαφορετικές μετρικές glyphs αλλάζει το πλάτος/ύψος του κειμένου, κάτι που μπορεί να αλλάξει το τελικό μέγεθος γραμματοσειράς και την αναδίπλωση γραμμών. Μετά από οποιαδήποτε αλλαγή ή αντικατάσταση γραμματοσειράς, ελέγξτε ξανά τις διαφάνειες.