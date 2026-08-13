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
- σχήμα με λοξότμηση
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να χρησιμοποιείτε το Aspose.Slides για C++ ώστε να διακρίνετε την τοπική, κληρονομική και αποτελεσματική μορφοποίηση σχήματος σε παρουσιάσεις PowerPoint."
---
## **Κατανόηση Τοπικών, Κληρονομικών και Αποτελεσματικών Ιδιοτήτων**

Η μορφοποίηση του PowerPoint μπορεί να προέρχεται από πολλές πηγές. Η τιμή που αποθηκεύεται απευθείας σε ένα αντικείμενο είναι η **τοπική τιμή**. Αν αυτή η τιμή δεν είναι ορισμένη, το PowerPoint ελέγχει τις γονικές πηγές μορφοποίησης, όπως το προεπιλεγμένο παράγραφο, ένα στυλ κειμένου, μια διάταξη ή κύρια διαφάνεια, ένα θέμα ή τις προεπιλογές επιπέδου παρουσίασης. Αυτές οι τιμές είναι **κληρονομικές τιμές**. Η τιμή που απομένει μετά την επίλυση ολόκληρης της ιεραρχίας είναι η **αποτελεσματική τιμή**—η τιμή που χρησιμοποιείται για την απόδοση του αντικειμένου.

Για παράδειγμα, ένα τμήμα κειμένου μπορεί να μην καθορίζει το δικό του ύψος γραμματοσειράς. Το τοπικό του [font height](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseportionformat/) είναι τότε `std::numeric_limits<float>::quiet_NaN()`, που σημαίνει «δεν ορίστηκε εδώ». Το τμήμα μπορεί να κληρονομήσει ένα ύψος από την παράγραφο, το προεπιλεγμένο στυλ κειμένου της παρουσίασης ή άλλη εφαρμόσιμη πηγή. Καλώντας [GetEffective](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/) στο μορφοποίηση του τμήματος, επιστρέφεται το τελικό επιλυμένο ύψος.

Χρησιμοποιήστε τα δύο είδη δεδομένων μορφοποίησης για διαφορετικούς σκοπούς:

- Διαβάστε ή τροποποιήστε ένα τοπικό αντικείμενο μορφοποίησης, όπως το [IPortionFormat](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/), όταν χρειάζεστε έλεγχο του πού ορίζεται μια τιμή.
- Διαβάστε ένα αντικείμενο αποτελεσματικών δεδομένων, όπως το [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformateffectivedata/), όταν χρειάζεστε το τελικό, αποδιδόμενο αποτέλεσμα. Τα αποτελεσματικά δεδομένα είναι μόνο για ανάγνωση.

## **Σύγκριση Τοπικών, Κληρονομικών και Αποτελεσματικών Τιμών**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα σχήμα και εφαρμόζει ύψη γραμματοσειράς στο επίπεδο παρουσίασης, παραγράφου και τμήματος. Κάθε βήμα εκτυπώνει τις τιμές που ορίζονται σε αυτά τα επίπεδα και την προκύπτουσα αποτελεσματική τιμή για το ίδιο τμήμα κειμένου. Επίσης, επιδεικνύει γιατί τα αποτελεσματικά δεδομένα πρέπει να διαβαστούν ξανά μετά από αλλαγές μορφοποίησης.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Ορισμός κληρονομικών τιμών σε δύο διαφορετικά επίπεδα.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Ανάγνωση αποτελεσματικών δεδομένων μετά τις προηγούμενες αλλαγές.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Μια τοπική τιμή στο τμήμα παρακάμπτει και τις δύο κληρονομικές τιμές.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Η αλλαγή μιας κληρονομικής τιμής δεν παρακάμπτει μια υπάρχουσα τοπική τιμή.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Καθαρισμός της τοπικής τιμής. Το τμήμα κληρονομεί ξανά από την παράγραφο.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Καθαρισμός της τιμής παραγράφου. Η προεπιλογή παρουσίασης παρέχει τώρα το αποτέλεσμα.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Η προτεραιότητα σε αυτό το παράδειγμα είναι η τοπική μορφοποίηση του τμήματος, έπειτα η μορφοποίηση της παραγράφου και τέλος η προεπιλογή της παρουσίασης. Άλλα αντικείμενα μπορούν να έχουν διαφορετική αλυσίδα κληρονομικότητας, αλλά η αρχή είναι η ίδια: μια πιο συγκεκριμένη ρητή τιμή κερδίζει, και το [GetEffective](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/) επιστρέφει το τελικό αποτέλεσμα.

## **Λήψη Αποτελεσματικών Ιδιοτήτων Κειμένου**

Η μορφοποίηση κειμένου διασπάται σε αρκετά αντικείμενα:

- Το [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextframeformat/) επιλύει ιδιότητες πλαισίου κειμένου όπως περιθώρια, αγκύρωση, αυτόματο προσαρμογή και κατακόρυφη κατεύθυνση κειμένου.
- Το [ITextStyle::GetEffective](https://reference.aspose.com/slides/el/cpp/aspose.slides/itextstyle/) επιλύει τη μορφοποίηση παραγράφου για κάθε επίπεδο στυλ κειμένου.
- Το [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/el/cpp/aspose.slides/iparagraphformat/) επιλύει ιδιότητες παραγράφου όπως στοίχιση, εσοχή και κουκίδες.
- Το [IPortionFormat::GetEffective](https://reference.aspose.com/slides/el/cpp/aspose.slides/iportionformat/) επιλύει ιδιότητες χαρακτήρων όπως ύψος γραμματοσειράς, τύπο γραμματοσειράς, χρώμα, έντονη και πλάγια γραφή.

Για το επόμενο παράδειγμα, το `text-formatting.pptx` πρέπει να περιέχει τουλάχιστον μία διαφάνεια και ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) με μη κενό πλαίσιο κειμένου. Το IAutoShape μπορεί να εμφανίζεται σε οποιαδήποτε θέση στη συλλογή σχημάτων· ο κώδικας αναζητά ένα κατάλληλο αντικείμενο και το επικυρώνει πριν τη χρήση.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Λήψη Αποτελεσματικών Ιδιοτήτων 3D**

Το [IThreeDFormat::GetEffective](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformat/) επιστρέφει ένα αντικείμενο [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/cpp/aspose.slides/ithreedformateffectivedata/) που ομαδοποιεί όλες τις επιλυμένες ρυθμίσεις 3D. Τα δεδομένα της [camera](https://reference.aspose.com/slides/el/cpp/aspose.slides/icameraeffectivedata/), του [light rig](https://reference.aspose.com/slides/el/cpp/aspose.slides/ilightrigeffectivedata/), του [top bevel](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapebeveleffectivedata/) και του [bottom bevel](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapebeveleffectivedata/) εκθέτουν τις αντίστοιχες αποτελεσματικές ρυθμίσεις. Η ανάγνωση αυτών των σχετικών ρυθμίσεων μαζί κάνει ευκολότερη την κατανόηση της τελικής 3D εμφάνισης ενός σχήματος.

Για αυτό το παράδειγμα, το `shape-3d.pptx` πρέπει να περιέχει τουλάχιστον ένα σχήμα στην πρώτη του διαφάνεια. Εφαρμόστε 3D κάμερα, φωτισμό ή ρυθμίσεις κλίμακας σε εκείνο το σχήμα αν θέλετε το αποτέλεσμα να περιέχει τιμές διαφορετικές από τις προεπιλογές.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Λήψη Αποτελεσματικής Μορφοποίησης Πίνακα**

Η μορφοποίηση πίνακα μπορεί να προέρχεται από το στυλ πίνακα και από μορφοποιήσεις που εφαρμόζονται σε ολόκληρο τον πίνακα, στήλη, σειρά ή μεμονωμένο κελί. Για συγκρούσεις μεταξύ ρητά ορισμένων γεμισμάτων, η προτεραιότητα είναι κελί, σειρά, στήλη και τέλος ολόκληρος ο πίνακας. Η αποτελεσματική μορφοποίηση ενός κελιού είναι η τελική μορφοποίηση που χρησιμοποιείται για την σχεδίαση του κελιού.

Για αυτό το παράδειγμα, το `table-formatting.pptx` πρέπει να περιέχει τουλάχιστον έναν πίνακα στην πρώτη του διαφάνεια. Ο πίνακας πρέπει να έχει τουλάχιστον μία σειρά και μία στήλη. Ο κώδικας αναζητά ένα [ITable](https://reference.aspose.com/slides/el/cpp/aspose.slides/itable/) αντί να υποθέτει ότι το πρώτο σχήμα είναι πίνακας.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Αν χρειάζεστε το χρώμα αντί μόνο του τύπου γεμίσματος, ελέγξτε πρώτα το αποτελεσματικό [FillType](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifillformateffectivedata/), και μετά διαβάστε την ιδιότητα που εφαρμόζεται σε αυτόν τον τύπο—π.χ., το [SolidFillColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/ifillformateffectivedata/) για ένα συμπαγές γέμισμα.

## **Επανάγνωση Αποτελεσματικών Δεδομένων Μετά από Αλλαγές**

Τα αποτελεσματικά δεδομένα περιγράφουν την ιεραρχία μορφοποίησης τη στιγμή που επιλύεται. Καλέστε ξανά το `GetEffective` μετά την αλλαγή οτιδήποτε μπορεί να συμμετέχει σε αυτήν την ιεραρχία, συμπεριλαμβανομένων:

- της τοπικής μορφοποίησης του αντικειμένου·
- των προεπιλογών παραγράφου ή πλαισίου κειμένου·
- ενός στυλ πίνακα, πίνακα, στήλης, σειράς ή μορφοποίησης κελιού·
- της μορφοποίησης διάταξης ή κύριας διαφάνειας·
- των δεδομένων θέματος ή προεπιλογών επιπέδου παρουσίασης·
- της διάταξης ή κύριας που έχει εκχωρηθεί σε μια διαφάνεια.

Μην διατηρείτε ένα αντικείμενο αποτελεσματικών δεδομένων ως μόνιμη στιγμιότυπο. Το Aspose.Slides μπορεί να αποθηκεύει προσωρινά κάποια αποτελεσματικά δεδομένα εσωτερικά, και μια μεταγενέστερη κλήση `GetEffective` μπορεί να τα ενημερώσει. Αν χρειάζεται να συγκρίνετε τιμές πριν και μετά από αλλαγή, αντιγράψτε τις βαθμωτές τιμές που χρειάζεστε—όπως ύψος γραμματοσειράς, χρώμα, στοίχιση ή πλάτος κλίμακας—σε δικές σας μεταβλητές πριν κάνετε την αλλαγή.

Για να αλλάξετε μια τιμή, ενημερώστε το κατάλληλο τοπικό αντικείμενο μορφοποίησης και στη συνέχεια καλέστε `GetEffective` για να επαληθεύσετε το αποτέλεσμα. Τα αντικείμενα αποτελεσματικών δεδομένων είναι μόνο για ανάγνωση.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω ποιο επίπεδο παρείχε μια αποτελεσματική τιμή;**

Τα αποτελεσματικά δεδομένα περιέχουν τη τελική τιμή, όχι την πηγή της. Εξετάστε τα εφαρμόσιμα τοπικά αντικείμενα ξεκινώντας από το πιο συγκεκριμένο επίπεδο προς τα έξω. Για κείμενο, αυτό μπορεί να περιλαμβάνει το τμήμα, την παράγραφο, το πλαίσιο κειμένου, τη διάταξη, το κύριο, το θέμα και τις προεπιλογές παρουσίασης. Μη ορισμένες τιμές όπως `std::numeric_limits<float>::quiet_NaN()` ή `nullptr` υποδεικνύουν ότι η αναζήτηση συνεχίζεται σε άλλο επίπεδο.

**Τι συμβαίνει όταν κανένα επίπεδο δεν ορίζει μια ιδιότητα;**

Το Aspose.Slides επιλύει τη σχετική προεπιλογή του PowerPoint ή της βιβλιοθήκης. Η επιλυμένη τιμή εμφανίζεται στα αποτελεσματικά δεδομένα παρόλο που κανένα τοπικό αντικείμενο δεν την ορίζει ρητά.

**Γιατί μια αποτελεσματική τιμή μερικές φορές ισούται με την τοπική τιμή;**

Η τοπική τιμή κατέκτησε τον υπολογισμό κληρονομικότητας. Αυτό είναι αναμενόμενο όταν η ιδιότητα έχει οριστεί ρητά στο αντικείμενο και κανένας πιο συγκεκριμένος κανόνας δεν την παρακάμπτει.

**Πότε πρέπει να χρησιμοποιώ τοπικά δεδομένα αντί για αποτελεσματικά δεδομένα;**

Χρησιμοποιήστε τοπικά δεδομένα για να εξετάσετε ή να επεξεργαστείτε ένα συγκεκριμένο επίπεδο μορφοποίησης. Χρησιμοποιήστε αποτελεσματικά δεδομένα όταν χρειάζεστε την τελική εμφάνιση μετά την κληρονομικότητα, τους κανόνες θέματος και τα εφαρμοστέα στυλ. Το [complete comparison example](#compare-local-inherited-and-effective-values) επιδεικνύει και τα δύο στην ίδια ροή εργασίας.