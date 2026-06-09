---
title: Απόκτηση αποτελεσματικών ιδιοτήτων σχήματος από παρουσιάσεις σε C++
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/cpp/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- σύστημα φωτισμού
- σχήμα λοξότμησης
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Ανακαλύψτε πώς το Aspose.Slides για C++ υπολογίζει και εφαρμόζει τις αποτελεσματικές ιδιότητες σχήματος για ακριβή απόδοση PowerPoint."
---
## **Επισκόπηση**

Αυτό το θέμα εξηγεί τη διαφορά μεταξύ ιδιοτήτων **local** και **effective**. Οι τοπικές τιμές είναι τιμές που ορίζονται άμεσα σε ένα συγκεκριμένο επίπεδο μορφοποίησης, όπως:

1. Ιδιότητες τμήματος σε μια διαφάνεια.
1. Τεχνοτροπίες κειμένου προτύπου σχήματος σε διάταξη ή κυριότερη διαφάνεια, όταν το σχήμα πλαισίου κειμένου του τμήματος διαθέτει μία.
1. Γενικές ρυθμίσεις κειμένου σε μια παρουσίαση.

Οι τοπικές τιμές μπορούν να οριστούν ή να παραλειφθούν σε οποιοδήποτε επίπεδο. Όταν το Aspose.Slides χρειάζεται τη τελική μορφοποίηση "as rendered", επιλύει την αλυσίδα κληρονομικότητας και επιστρέφει τιμές **effective**. Μπορείτε να τις λάβετε καλώντας τη μέθοδο `GetEffective` στο αντικείμενο τοπικής μορφής.

Το παρακάτω παράδειγμα δείχνει πώς να λάβετε τις αποτελεσματικές τιμές. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) με πλαίσιο κειμένου και τουλάχιστον ένα τμήμα.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
Τα δεδομένα αποτελεσματικής μορφοποίησης αντιπροσωπεύουν την τρέχουσα υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας. Στην τρέχουσα υλοποίηση, ορισμένα αντικείμενα αποτελεσματικών δεδομένων, όπως το [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformateffectivedata/), μπορεί να αποθηκεύονται στην κρυφή μνήμη. Η επανάκληση του `GetEffective` μετά την αλλαγή της γονικής ή κληρονομικής μορφοποίησης μπορεί να ανανεώσει τα αποθηκευμένα δεδομένα, και ένα αντικείμενο που είχε ληφθεί προηγουμένως μπορεί να μην αντιπροσωπεύει πλέον την προηγούμενη κατάσταση. Εάν χρειάζεται να διατηρήσετε τις αποτελεσματικές τιμές για μετέπειτα χρήση, αντιγράψτε τις απαιτούμενες ιδιότητες, όπως το ύψος γραμματοσειράς, το χρώμα γεμίσματος, το στυλ γραμματοσειράς ή την ευθυγράμμιση, στο δικό σας αντικείμενο δεδομένων.
{{% /alert %}}

## **Λήψη αποτελεσματικών ιδιοτήτων κάμερας**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες μιας κάμερας. Η διεπαφή [ICameraEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/icameraeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει τις αποτελεσματικές ιδιότητες της κάμερας. Μια παρουσία του [ICameraEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/icameraeffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει τις αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για την κάμερα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Λήψη αποτελεσματικών ιδιοτήτων Light Rig**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες Light Rig. Η διεπαφή [ILightRigEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilightrigeffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει τις αποτελεσματικές ιδιότητες του φωτιστικού Rig. Μια παρουσία του [ILightRigEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilightrigeffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει τις αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για το φωτιστικό Rig. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Λήψη αποτελεσματικών ιδιοτήτων Bevel Shape**

Το Aspose.Slides σας επιτρέπει να λάβετε τις αποτελεσματικές ιδιότητες Bevel Shape. Η διεπαφή [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapebeveleffectivedata/) αντιπροσωπεύει ένα αμετάβλητο αντικείμενο που περιέχει τις αποτελεσματικές ιδιότητες ανάπλασης ενός σχήματος. Μια παρουσία του [IShapeBevelEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapebeveleffectivedata/) εκτίθεται μέσω του [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformateffectivedata/), το οποίο παρέχει τις αποτελεσματικές τιμές για το [IThreeDFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/).

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες για το άνω bevel ενός σχήματος. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια έχει 3D μορφοποίηση.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Λήψη αποτελεσματικών ιδιοτήτων Text Frame**

Με χρήση του Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός πλαισίου κειμένου. Η διεπαφή [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformateffectivedata/) περιέχει τις αποτελεσματικές ιδιότητες μορφοποίησης του πλαισίου κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες μορφοποίησης πλαισίου κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) με πλαίσιο κειμένου.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Λήψη αποτελεσματικών ιδιοτήτων Text Style**

Με χρήση του Aspose.Slides, μπορείτε να λάβετε τις αποτελεσματικές ιδιότητες ενός στυλ κειμένου. Η διεπαφή [ITextStyleEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextstyleeffectivedata/) περιέχει τις αποτελεσματικές ιδιότητες στυλ κειμένου.

Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε τις αποτελεσματικές ιδιότητες στυλ κειμένου. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) με πλαίσιο κειμένου.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **Λήψη της αποτελεσματικής τιμής ύψους γραμματοσειράς**

Με χρήση του Aspose.Slides, μπορείτε να λάβετε το αποτελεσματικό ύψος γραμματοσειράς. Το παρακάτω παράδειγμα δείχνει πώς το αποτελεσματικό ύψος γραμματοσειράς ενός τμήματος αλλάζει μετά τον ορισμό τοπικών τιμών ύψους σε διαφορετικά επίπεδα δομής παρουσίασης.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Λήψη της αποτελεσματικής μορφής γεμίσματος για πίνακα**

Με χρήση του Aspose.Slides, μπορείτε να λάβετε αποτελεσματική μορφή γεμίσματος για διαφορετικά τμήματα πίνακα. Η διεπαφή [IFillFormatEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifillformateffectivedata/) περιέχει τις αποτελεσματικές ιδιότητες μορφοποίησης γεμίσματος. Η μορφοποίηση κελιού έχει υψηλότερη προτεραιότητα από τη μορφοποίηση γραμμής, η μορφοποίηση γραμμής έχει υψηλότερη προτεραιότητα από τη μορφοποίηση στήλης, και η μορφοποίηση στήλης έχει υψηλότερη προτεραιότητα από τη μορφοποίηση ολόκληρου του πίνακα.

Ως αποτέλεσμα, οι ιδιότητες [ICellFormatEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/icellformateffectivedata/) χρησιμοποιούνται για τη σχεδίαση του κελιού του πίνακα. Το παρακάτω δείγμα κώδικα δείχνει πώς να λάβετε αποτελεσματική μορφή γεμίσματος για διαφορετικά τμήματα πίνακα. Υποθέτει ότι το πρώτο σχήμα στην πρώτη διαφάνεια είναι ένα [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Επιστρέφει η `GetEffective` μια στιγμιότυπη εικόνα;**

Όχι πάντα. Τα αποτελεσματικά δεδομένα αντιπροσωπεύουν τη υπολογισμένη μορφοποίηση μετά την εφαρμογή της κληρονομικότητας, αλλά ορισμένα αντικείμενα αποτελεσματικών δεδομένων μπορεί να αποθηκεύονται στην κρυφή μνήμη. Μια επόμενη κλήση του `GetEffective` μπορεί να επαναϋπολογίσει τη μορφοποίηση και να ανανεώσει τα αποθηκευμένα δεδομένα, έτσι ένα αντικείμενο που είχε ληφθεί προηγουμένως δεν πρέπει να θεωρείται μόνιμη στιγμιότυπη εικόνα.

**Πότε πρέπει να διαβάζω ξανά τις αποτελεσματικές ιδιότητες;**

Κλήστε ξανά το `GetEffective` μετά την αλλαγή της τοπικής μορφοποίησης, των γονικών στυλ, της μορφοποίησης διάταξης, της μορφοποίησης master ή των προεπιλογών επιπέδου παρουσίασης. Η επόμενη κλήση επανεξετάζει τη ιεραρχία μορφοποίησης και επιστρέφει το τρέχον αποτελεσματικό αποτέλεσμα.

**Επηρεάζει η αλλαγή ή η αφαίρεση μιας διαφάνειας διάταξης/master τις αποτελεσματικές ιδιότητες που έχουν ήδη ανακτηθεί;**

Ναι, αλλά η αλλαγή αντικατοπτρίζεται στην επόμενη κλήση του `GetEffective`. Εάν μια γονική πηγή μορφοποίησης αλλάξει ή αφαιρεθεί, τα προηγουμένως ληφθέντα αποτελεσματικά δεδομένα μπορεί να είναι ξεπερασμένα. Μόλις κληθεί ξανά το `GetEffective`, το Aspose.Slides επανεξετάζει το δέντρο μορφοποίησης και οι προκύπτοντες γραμματοσειρές, χρώματα, μεγέθη ή άλλες τιμές μπορεί να αλλάξουν.

**Μπορώ να τροποποιήσω τιμές μέσω των αντικειμένων αποτελεσματικών δεδομένων;**

Όχι. Τα αντικείμενα αποτελεσματικών δεδομένων εκθέτουν υπολογισμένες τιμές. Κάντε αλλαγές στα τοπικά αντικείμενα μορφοποίησης και, στη συνέχεια, λάβετε ξανά τις αποτελεσματικές τιμές.

**Τι συμβαίνει αν μια ιδιότητα δεν οριστεί στο επίπεδο του σχήματος, ούτε στη διάταξη/master, ούτε στις καθολικές ρυθμίσεις;**

Η αποτελεσματική τιμή καθορίζεται από τον προεπιλεγμένο μηχανισμό, που περιλαμβάνει τις προεπιλογές του PowerPoint και του Aspose.Slides. Η επιλυμένη τιμή γίνεται μέρος των τρεχουσών αποτελεσματικών δεδομένων.

**Από μια αποτελεσματική τιμή γραμματοσειράς, μπορώ να καταλάβω ποιο επίπεδο παρείχε το μέγεθος ή το τύπο γραμματοσειράς;**

Όχι άμεσα. Τα αποτελεσματικά δεδομένα επιστρέφουν την τελική τιμή. Για να βρείτε την πηγή, ελέγξτε τις τοπικές τιμές στο τμήμα, την παράγραφο, το πλαίσιο κειμένου και τα στυλ κειμένου στη διάταξη, το master και το επίπεδο παρουσίασης ώστε να δείτε πού εμφανίζεται η πρώτη ρητή ορισμός.

**Γιατί οι αποτελεσματικές τιμές μερικές φορές φαίνονται ταυτόσημες με τις τοπικές;**

Επειδή η τοπική τιμή κατέληξε να είναι η τελική (δεν απαιτήθηκε κληρονομική τιμή από υψηλότερο επίπεδο). Σε τέτοιες περιπτώσεις, η αποτελεσματική τιμή ταιριάζει με την τοπική.

**Πότε πρέπει να χρησιμοποιώ αποτελεσματικές ιδιότητες και πότε να εργάζομαι μόνο με τοπικές;**

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα όταν χρειάζεστε το αποτέλεσμα «as rendered» μετά την πλήρη εφαρμογή της κληρονομικότητας, π.χ. για ευθυγράμμιση χρωμάτων, εσοχών ή μεγεθών. Εάν χρειάζεται να διατηρήσετε αυτές τις τιμές ανεξάρτητα από μελλοντικές αλλαγές μορφοποίησης, αντιγράψτε τις απαιτούμενες ιδιότητες σε δικό σας αντικείμενο. Εάν θέλετε να αλλάξετε τη μορφοποίηση σε συγκεκριμένο επίπεδο, τροποποιήστε τις τοπικές ιδιότητες και, εάν είναι απαραίτητο, διαβάστε ξανά τα αποτελεσματικά δεδομένα για να επαληθεύσετε το αποτέλεσμα.