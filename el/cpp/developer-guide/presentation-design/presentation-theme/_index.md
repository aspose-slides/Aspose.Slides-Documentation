---
title: Διαχείριση Θεμάτων Παρουσίασης σε C++
linktitle: Θέμα Παρουσίασης
type: docs
weight: 10
url: /el/cpp/presentation-theme/
keywords:
- Θέμα PowerPoint
- Θέμα παρουσίασης
- Θέμα διαφάνειας
- Ορισμός θέματος
- Αλλαγή θέματος
- Διαχείριση θέματος
- Εξωτερικό θέμα
- THMX
- Χρώμα θέματος
- Επιπλέον παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- Παρουσίαση
- C++
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για C++ για τη δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ υποβάθρου, γεμισμάτων, γραμμών και εφέ. Τα αντικείμενα που είναι ευαίσθητα στο θέμα αναφέρονται σε αυτούς τους κοινόχρηστους ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως σταθερή τιμή, ώστε μια αλλαγή θέματος να μπορεί να ενημερώνει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/). Μια παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα παρουσίασης μέσω [MasterThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), ενώ ένα διάταξη ή μια μεμονωμένη διαφάνεια μπορεί να χρησιμοποιήσει [IOverrideThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παρακάμμιση master, παρακάμμιση διάταξης και παρακάμμιση διαφάνειας.

![Στοιχεία θέματος: χρώματα, γραμματοσειρές, στυλ υποβάθρου και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες δείχνουν τις πιο συνηθισμένες ροές εργασίας με το θέμα: έλεγχος ενός θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ υποβάθρου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την κληρονομικότητα και τις παρακάμψεις.

## **Έλεγχος Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/) εκθέτει τις μεθόδους του θέματος [get_ColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) και [get_FormatScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Η εξέταση αυτών των συλλογών πριν από τις αλλαγές είναι ιδιαίτερα χρήσιμη όταν η παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των καταχωρίσεων στυλ μπορεί να διαφέρουν.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ υποβάθρου, γεμίσματος, γραμμής και εφέ είναι αποθηκευμένα στο θέμα:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Αν ένα αρχείο χρησιμοποιεί πολλαπλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Ελέγξτε το master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που εμφανίζεται αργότερα σε αυτό το άρθρο όταν μπορεί να υπάρξουν παρακάμψεις διάταξης ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που είναι ευαίσθητα στο θέμα μπορούν να αναφέρονται σε ένα λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώρηση στην [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) του θέματος, όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε εκείνο το χρώμα θέματος επιλύονται με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζονται από την ενημέρωση του χρώματος θέματος.

Το παρακάτω παράδειγμα ολοκληρωμένου κύκλου δημιουργεί ένα σχήμα που χρησιμοποιεί `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα στο σχήμα, οι μετέπειτα αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από το Επιπλέον Παλέτο**

Το PowerPoint παράγει ελαφρύτερες και σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και ελαφρύτερα και σκούρα χρώματα που δημιουργούνται από το επιπλέον παλέτο](additional-palette-colors.png)

**1** - Κύρια χρώματα θέματος.

**2** - Ελαφρύτερες και σκούρες παραλλαγές που παράγονται από τα κύρια χρώματα θέματος.

Το παρακάτω παράδειγμα δημιουργεί έξι ορθογώνια βασισμένα στο `Accent4`, εφαρμόζει μετασχηματισμούς φωτεινότητας σε πέντε από αυτά και αποθηκεύει το αποτέλεσμα:

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Αν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επανυπολογίζονται από τη νέα τιμή του `Accent4`.

### **Χαρτογράφηση Τιμών `SchemeColor` σε Θέσεις `IColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) χρησιμοποιεί `Text1`, `Background1`, `Text2` και `Background2`, ενώ η [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχηση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτές είναι εναλλακτικές ονομασίες για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από τη μια μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σύνολο γραμματοσειρών θέματος περιλαμβάνει ένα κύριο σύνολο γραμματοσειρών για επικεφαλίδες και ένα δευτερεύον σύνολο για το κυρίως κείμενο. Οι μέθοδοι [FontScheme::get_Major](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) και [FontScheme::get_Minor](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) εκθέτουν αυτά τα σύνολα.

Οι αναγνωριστές γραμματοσειρών θέματος συμβατοί με το PowerPoint μπορούν να χρησιμοποιηθούν στη μορφοποίηση κειμένου:

* `+mn-lt` - Γραμματοσειρά Σώματος Λατινική (Minor Latin Font)
* `+mj-lt` - Γραμματοσειρά Επικεφαλίδας Λατινική (Major Latin Font)
* `+mn-ea` - Γραμματοσειρά Σώματος Ανατολικής Ασίας (Minor East Asian Font)
* `+mj-ea` - Γραμματοσειρά Επικεφαλίδας Ανατολικής Ασίας (Major East Asian Font)
* `+mn-cs` - Γραμματοσειρά Σώματος Πολύπλοκου Σεναρίου (Minor Complex Script Font)
* `+mj-cs` - Γραμματοσειρά Επικεφαλίδας Πολύπλοκου Σεναρίου (Major Complex Script Font)

Το παρακάτω παράδειγμα δημιουργεί μια επικεφαλίδα που χρησιμοποιεί τη κύρια λατινική γραμματοσειρά θέματος και μια γραμμή σώματος που χρησιμοποιεί τη δευτερεύουσα λατινική γραμματοσειρά θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές του θέματος και αποθηκεύει το αποτέλεσμα:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

Η επικεφαλίδα ακολουθεί τη κύρια γραμματοσειρά και το κυρίως κείμενο ακολουθεί τη δευτερεύουσα γραμματοσειρά. Κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για αναγνωριστικό θέματος δεν θα αλλάξει αυτόματα όταν η γραμματοσειρά θέματος αλλάξει.

Οι κύριες και δευτερεύουσες συλλογές γραμματοσειρών μπορούν επίσης να περιέχουν αντιστοιχίες γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως κυριλλικά, αραβικά, ιαπωνικά, γεωργιανά και θανα. Για να ελέγξετε, προσθέσετε, αντικαταστήσετε ή αφαιρέσετε αυτές τις αντιστοιχίες, δείτε [Script-Specific Theme Fonts](/slides/el/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε [PowerPoint Fonts](/slides/el/cpp/powerpoint-fonts/).

{{% /alert %}}

### **Επίλυση Αναφορών Γραμματοσειρών Θέματος**

Κατά τον έλεγχο κειμένου, η μέθοδος [IFontData::get_FontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/get_fontname/) μπορεί να περιέχει αναφορά θέματος όπως `+mn-lt` αντί για όνομα οικογένειας γραμματοσειράς. Καλέστε την [IFontData::GetFontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/getfontname/) με το κατάλληλο [IThemeEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeeffectivedata/) για να επιλύσετε αυτήν την αναφορά. Τα πρόθεμα `+mj` και `+mn` επιλέγουν τα κύρια και δευτερεύοντα σύνολα γραμματοσειρών· τα επίθημα `-lt`, `-ea` και `-cs` επιλέγουν τις λατινικές, Ανατολικής Ασίας και Πολύπλοκης Σεναρίου γραμματοσειρές αντίστοιχα.

Αποκτήστε το αποτελεσματικό θέμα μέσω της [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) στο αντικείμενο του οποίου εφαρμόζεται το θέμα στο ελεγόμενο κείμενο. Για κοινό κείμενο σε διαφάνεια, χρησιμοποιήστε `slide->CreateThemeEffective()` ώστε το πλαίσιο να περιλαμβάνει το κληρονομημένο θέμα της διαφάνειας και τις τοπικές παρακάμψεις. Κατά τον έλεγχο διάταξης ή του master, χρησιμοποιήστε το δικό του αποτελεσματικό θέμα. Μην υποθέτετε ότι το θέμα του πρώτου master εφαρμόζεται σε κάθε διαφάνεια.

Το παρακάτω παράδειγμα δημιουργεί ένα τμήμα κειμένου που αναφέρει ρητά τη δευτερεύουσα λατινική γραμματοσειρά. Αρχικοποιεί το σχήμα γραμματοσειράς διαφάνειας μέσω της [IOverrideTheme::InitFontSchemeFromInherited](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) και ορίζει τις κυρίως και δευτερεύουσες λατινικές οικογένειες σε `Arial` και `Calibri`, κάνοντας το αποτέλεσμα επαναλήψιμο χωρίς αρχείο εισόδου.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto theme = slide->get_ThemeManager()->get_OverrideTheme();
theme->InitFontSchemeFromInherited();
theme->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Arial"));
theme->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Calibri"));

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 60.0f);
shape->get_TextFrame()->set_Text(u"Text using the minor theme font");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

auto font = portion->get_PortionFormat()->get_LatinFont();
auto effectiveTheme = slide->CreateThemeEffective();
auto resolvedFontName = font->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", font->get_FontName(), resolvedFontName);

auto explicitFont = MakeObject<FontData>(u"Verdana");
auto explicitFontName = explicitFont->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", explicitFont->get_FontName(), explicitFontName);
```

Η έξοδος είναι `+mn-lt -> Calibri` ακολουθούμενη από `Verdana -> Verdana`. Η αποθηκευμένη αναφορά παραμένει αμετάβλητη, ενώ ένα ρητό όνομα οικογένειας επιστρέφεται όπως είναι. Αν το τμήμα χρησιμοποίησε `+mj-lt`, θα επιλύεται σε `Arial` σε αυτό το θέμα.

Η επίλυση μιας αναφοράς θέματος προσδιορίζει την οικογένεια γραμματοσειράς που καθορίζεται από το θέμα. Δεν ελέγχει τη διαθεσιμότητα της γραμματοσειράς ή το αρχείο γραμματοσειράς που εντέλει χρησιμοποιείται μετά την αντικατάσταση ή fallback κατά την απόδοση. Δείτε τη [Font Selection Sequence](/slides/el/cpp/font-selection-sequence/) και την [Font Substitution](/slides/el/cpp/font-substitution/) για αυτά τα ξεχωριστά βήματα.

## **Αντιγραφή ή Εφαρμογή Θέματος**

Οι παρακάτω ροές εργασίας λύνουν διαφορετικά προβλήματα σχετιζόμενα με το θέμα.

### **Εφαρμογή Εξωτερικού Θέματος σε Διαφάνειες Εξαρτημένες από Master**

Χρησιμοποιήστε την [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) όταν έχετε αρχείο θέματος PowerPoint (`.thmx`) και θέλετε να επανασχεδιάσετε κάθε διαφάνεια που εξαρτάται από έναν συγκεκριμένο master. Επιλέξτε το master από τη συλλογή [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/), η οποία υλοποιεί την [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/), και περάστε τη διαδρομή του αρχείου θέματος στη μέθοδο.

Η μέθοδος εκτελεί τις ακόλουθες λειτουργίες:

1. Δημιουργεί μια νέα διαφάνεια master με βάση το επιλεγμένο master.  
2. Εφαρμόζει το εξωτερικό θέμα στη νέα master.  
3. Αναθέτει τη νέα master σε όλες τις διαφάνειες που παλαιότερα εξαρτώνταν από το επιλεγμένο master.  
4. Επιστρέφει το νεοδημιουργημένο [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/).

Το παρακάτω παράδειγμα εφαρμόζει ένα εξωτερικό θέμα στις διαφάνειες που εξαρτώνται από τον πρώτο master και αποθηκεύει την παρουσίαση:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);

auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");
Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());

presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Ένα μη έγκυρο, κατεστραμμένο ή μη υποστηριζόμενο θέμα μπορεί να προκαλέσει [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) ή κάποια από τις υποκατηγορίες του σχετικές με μορφή. Επικυρώστε τις διαδρομές που παρέχουν οι χρήστες, διαχειριστείτε αποτυχίες πρόσβασης στο σύστημα αρχείων και αποθηκεύστε την παρουσίαση μόνο μετά την επιτυχή εφαρμογή του θέματος.

Μόνο οι διαφάνειες που εξαρτώνταν από τον επιλεγμένο master επανεκχωρούνται. Οι διαφάνειες που σχετίζονται με άλλους masters διατηρούν τα υπάρχοντα masters και θέματα τους. Τα χρώματα, οι γραμματοσειρές, τα γεμίσματα, οι γραμμές, τα υποβάθρα και τα εφέ που είναι ευαίσθητα στο θέμα επιλύονται έναντι του εξωτερικού θέματος. Τα άμεσα εκχωρημένα χρώματα, γραμματοσειρές, γεμίσματα και άλλες ρητές μορφοποιήσεις μπορεί να παραμείνουν αμετάβλητα. Οι παρακάμψεις σε επίπεδο διάταξης και διαφάνειας μπορούν επίσης να προτεραιοποιηθούν έναντι των τιμών που κληρονομούνται από το νέο master.

Το θέμα μπορεί να αναφέρει γραμματοσειρές που δεν είναι διαθέσιμες στο περιβάλλον εκτέλεσης. Για συνεπή απόδοση και εξαγωγή, εγκαταστήστε τις απαιτούμενες γραμματοσειρές, παρέχετε τις μέσω [custom font sources](/slides/el/cpp/custom-font/), ή ρυθμίστε την [font substitution](/slides/el/cpp/font-substitution/).

Αυτή είναι μια άμεση ροή εργασίας επιπέδου master: η μέθοδος δέχεται διαδρομή αρχείου `.thmx` και δεν απαιτεί τη δημιουργία παρακάμπσεων σε επίπεδο διαφάνειας ή διάταξης με το χέρι.

### **Εφαρμογή Διαφορετικών Εξωτερικών Θεμάτων σε Παρουσίαση με Πολλαπλούς Masters**

Όταν ο σχετικός master δεν είναι γνωστός εκ των προτέρων, αποκτήστε τον από μια αντιπροσωπευτική διαφάνεια μέσω των [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) και [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/). Αποθηκεύστε τις αρχικές αναφορές master πριν εφαρμόσετε οποιαδήποτε θέματα, επειδή κάθε κλήση δημιουργεί έναν νέο master στην παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί διαφάνειες από δύο ενότητες για να εντοπίσει τους masters τους και εφαρμόζει διαφορετικό εξωτερικό θέμα σε κάθε ομάδα:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());

        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

Η πρώτη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνταν από το `firstGroupMaster`, και η δεύτερη κλήση επηρεάζει μόνο τις διαφάνειες που εξαρτώνταν από το `secondGroupMaster`. Οι διαφάνειες που ανήκουν σε οποιονδήποτε άλλο master δεν επανασχεδιάζονται.

### **Διατήρηση Πρώτου Θέματος κατά τη Μετακίνηση Διαφανειών**

Αν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχέδιο, κλωνοποιήστε το master προέλευσης στην παρουσίαση προορισμού με την [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/), στη συνέχεια κλωνοποιήστε τη διαφάνεια με την [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) και το κλωνοποιημένο master. Αυτό μεταφέρει το master, τις διατάξεις του και το σχετικό θέμα μαζί.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");

auto sourceSlide = source->get_Slide(0);

auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);

target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η διαφάνεια προέλευσης πρέπει να φαίνεται ίδια στον προορισμό. Η απλή κλωνοποίηση περιεχομένου πάνω σε έναν άσχετο master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, υπόβαθρα και εφέ που καθορίζονται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υφιστάμενη Διαφάνεια**

Αν η διαφάνεια-στόχος πρέπει να παραμείνει στον τρέχον master και διάταξή της, αρχικοποιήστε μια παρακάμψη επιπέδου διαφάνειας από το αρχικό θέμα. Οι μέθοδοι [OverrideTheme::InitColorSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) και [OverrideTheme::InitFormatSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) αντιγράφουν τα τρία κύρια συστατικά του θέματος στην παρακάμπτηση.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);

auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());

target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Αυτό αλλάζει το θέμα που χρησιμοποιείται από εκείνη τη διαφάνεια χωρίς να αλλάζει το θέμα που κληρονομείται από άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παρακάμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε το [OverrideTheme::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/).

### **Εφαρμογή Παρακαμπτήματος Θέματος σε Διάταξη**

Μια παρακάμψη επιπέδου διάταξης εφαρμόζεται στις διαφάνειες που χρησιμοποιούν εκείνη τη διάταξη, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παρακάμψη. Οι ίδιοι μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) της διάταξης:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);

auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());

target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Χρησιμοποιήστε ένα θέμα σε επίπεδο master ή παρουσίασης όταν πολλές διατάξεις και διαφάνειες πρέπει να μοιράζονται το ίδιο βασικό σχέδιο, μια παρακάμπτηση διάταξης όταν μια οικογένεια διατάξεων χρειάζεται διαφορετική εμφάνιση, και μια παρακάμπτηση διαφάνειας μόνο για πραγματικές εξαιρέσεις. Πάρα πολλές παρακάμπψεις επιπέδου διαφάνειας καθιστούν τις μετέπειτα παγκόσμιες αλλαγές θέματος πιο δύσκολες στην πρόβλεψη.

## **Ενημέρωση Στυλ Υποβάθρου Θέματος**

Τα γεμίσματα υποβάθρου του θέματος αποθηκεύονται στην [FormatScheme::get_BackgroundFillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές υποβάθρου στη διεπαφή του από ό,τι αριθμό γεμισμάτων αποθηκεύονται καθοριστικά σε αυτή τη συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Γκαλερί στυλ υποβάθρου PowerPoint για θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ υποβάθρου, ελέγξτε τη συλλογή που αποθηκεύεται και το τρέχον [Background::get_StyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/). Το `StyleIndex` χρησιμοποιεί το `0` για κανένα θεματικό γέμισμα· οι θετικές τιμές είναι παραπομπές σε στυλ υποβάθρου θέματος. Αυτό διαφέρει από την απευθείας δεικτοδότηση μιας C++ συλλογής με `idx_get(0)`, όπου το `0` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ υποβάθρου.

Το παρακάτω παράδειγμα αναφέρει το διαθέσιμο πλήθος γεμισμάτων υποβάθρου, αναθέτει μια θεματική παραπομπή υποβάθρου στον πρώτο master και αποθηκεύει την παρουσίαση:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);

    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

Το ορατό αποτέλεσμα εξαρτάται από την καταχώρηση θέματος που παραπέμπει ο master και από τυχόν παρακάμψεις υποβάθρου στη διάταξη ή στο επίπεδο διαφάνειας. Αν μια διαφάνεια χρησιμοποιεί το δικό της υπόβαθρο, η αλλαγή μόνο του υποβάθρου του master μπορεί να μην αλλάξει εκείνη τη διαφάνεια. Χρησιμοποιήστε το [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) όταν χρειάζεται να γνωρίζετε το τελικό υπόβαθρο μετά την εφαρμογή κληρονομικότητας.

{{% alert color="warning" title="Warning" %}}

Μην αντιμετωπίζετε το `StyleIndex` ως δείκτη μηδενικής βάσης. Αποφύγετε επίσης την κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι θα έχει την ίδια εμφάνιση σε ένα άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Για άμεση μορφοποίηση υποβάθρου και κληρονομικότητα υποβάθρου, δείτε το [Presentation Background](/slides/el/cpp/presentation-background/).

{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιέχει ξεχωριστές συλλογές [FormatScheme::get_FillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/) και [FormatScheme::get_EffectStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Τα τυπικά Office θέματα συχνά περιέχουν τρεις κύριες καταχωρίσεις στυλ που αντιστοιχούν οπτικά σε διακριτό, μέτριο και έντονο φορμάρισμα, αλλά ο κώδικας θα πρέπει να ελέγχει κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Διακριτά, μετρία και έντονα εφέ θέματος εφαρμοσμένα στο ίδιο σχήμα](presentation-design_10.png)

Όταν έχετε πρόσβαση σε αυτές τις συλλογές σε C++, ο δείκτης της συλλογής είναι μηδενικής βάσης: `idx_get(0)` είναι το πρώτο αποθηκευμένο στυλ και `idx_get(2)` το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, εκτεθειμένη μέσω του [IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει σχήματα που αναφέρονται σε αυτό το στυλ θέματος· σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει αν υπάρχουν οι απαιτούμενες καταχωρίσεις στυλ, αλλάζει το πρώτο στυλ γραμμής, αλλάζει το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ, και αποθηκεύει το αποτέλεσμα:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής του θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος του θέματος γίνεται αδιάσπαστο δάσος πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 σημείων. Το ακριβές οπτικό αποτέλεσμα εξαρτάται ακόμη από το ποια θέσεις στυλ κάθε σχήμα αναφέρει και αν η άμεση μορφοποίηση υπερκαλύπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή γραμμής, γεμίσματος και ρύθμισης σκιάς](presentation-design_11.png)

## **Επιλογή Γεμίσματος και Στυλ Γραμμής Θέματος για Σχήμα**

Ένα σχήμα μπορεί να επιλέξει το γέμισμα και το περίγραμμα του ανεξάρτητα μέσω των [IShapeStyle::set_FillStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_fillstyleindex/) και [IShapeStyle::set_LineStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_linestyleindex/). Και για τις δύο μεθόδους, ο δείκτης `1` επιλέγει την πρώτη καταχώρηση στην αντίστοιχη συλλογή θέματος (`idx_get(0)`), και ο δείκτης `2` επιλέγει τη δεύτερη.

Το παρακάτω παράδειγμα δημιουργεί δύο στυλ γεμίσματος (χρυσό και γαλάζιο) και δύο στυλ γραμμής (σκούρο μπλε στα 6 pt και σκούρο κόκκινο στα 12 pt) στο προεπιλεγμένο θέμα μιας νέας παρουσίασης. Αποθηκεύει τη διαφάνεια σε τρία στάδια ώστε να μπορείτε να συγκρίνετε τα αποτελέσματα στο PowerPoint.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeStyle.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto styles = presentation->get_MasterTheme()->get_FormatScheme();

auto goldFill = styles->get_FillStyles()->idx_get(0);
goldFill->set_FillType(FillType::Solid);
goldFill->get_SolidFillColor()->set_Color(Color::get_Gold());
auto blueFill = styles->get_FillStyles()->idx_get(1);
blueFill->set_FillType(FillType::Solid);
blueFill->get_SolidFillColor()->set_Color(Color::get_SkyBlue());

auto thinLine = styles->get_LineStyles()->idx_get(0);
thinLine->get_FillFormat()->set_FillType(FillType::Solid);
thinLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
thinLine->set_Width(6.0);
auto thickLine = styles->get_LineStyles()->idx_get(1);
thickLine->get_FillFormat()->set_FillType(FillType::Solid);
thickLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkRed());
thickLine->set_Width(12.0);

auto shapes = presentation->get_Slide(0)->get_Shapes();
auto left = shapes->AddAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
auto right = shapes->AddAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
auto leftStyle = left->get_ShapeStyle();
auto rightStyle = right->get_ShapeStyle();
leftStyle->set_FillStyleIndex(1);
rightStyle->set_FillStyleIndex(2);
leftStyle->set_LineStyleIndex(1);
rightStyle->set_LineStyleIndex(1);
presentation->Save(u"01-initial.pptx", SaveFormat::Pptx);

rightStyle->set_LineStyleIndex(2);
presentation->Save(u"02-line-changed.pptx", SaveFormat::Pptx);

goldFill->get_SolidFillColor()->set_Color(Color::get_SeaGreen());
presentation->Save(u"03-theme-changed.pptx", SaveFormat::Pptx);
```

| Αρχικά στυλ | Αλλαγή του δεξιού περιγράμματος | Επεξεργασία του πρώτου γεμίσματος θέματος |
|:---:|:---:|:---:|
| ![Χρυσά και γαλάζια ορθογώνια με αντίστοιχα λεπτά σκούρα μπλε περιγράμματα](theme-style-initial.png) | ![Το γαλάζιο ορθογώνιο τώρα έχει παχύ σκούρο κόκκινο περίγραμμα](theme-style-line-changed.png) | ![Το αριστερό ορθογώνιο γίνεται πράσινο και και τα δύο περιγράμματα παραμένουν αμετάβλητα](theme-style-fill-changed.png) |

Η επιλογή διαφορετικού στυλ γραμμής αλλάζει μόνο το περίγραμμα του δεξιού ορθογωνίου. Η επεξεργασία του πρώτου γεμίσματος θέματος ενημερώνει κάθε σχήμα που το χρησιμοποιεί. Σε αυτό το παράδειγμα μόνο το αριστερό ορθογώνιο γίνεται πράσινο.

Σε ένα υπάρχον σχήμα, ένα τοπικό χρώμα γεμίσματος, χρώμα γραμμής ή πάχος γραμμής μπορεί να παρακάμψει εκείνο το μέρος του στυλ θέματος. Αν η αλλαγή του δείκτη στυλ δεν έχει ορατό αποτέλεσμα, ελέγξτε τη [direct formatting](/slides/el/cpp/shape-formatting/).

## **Καθορισμός Εάν ένα Αποτελεσματικό Στερεό Γέμισμα Χρησιμοποιεί Χρώμα Θέματος**

Ένα γέμισμα μπορεί να είναι αποθηκευμένο άμεσα σε ένα αντικείμενο ή να κληρονομείται από παράγραφο, διάταξη, master, στυλ θέματος ή άλλο επίπεδο μορφοποίησης. Καλέστε την [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) για να επιλύσετε αυτήν την ιεραρχία σε αμετάβλητα [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/). Πρώτα ελέγξτε το [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Μόνο όταν είναι `FillType::Solid` πρέπει να διαβάσετε τις ιδιότητες στερεού γεμίσματος.

Για στερεό γέμισμα, η μέθοδος [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) επιστρέφει την τελική απόδοση τιμής RGB μετά από κληρονομικότητα, αναζήτηση θέματος και εφαρμογή μετασχηματισμών χρώματος. Η [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) επιστρέφει την αντίστοιχη λογική θέση [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) όπως `Text1` ή `Accent6`. Μια τιμή `SchemeColor::NotDefined` σημαίνει ότι το αποτελεσματικό στερεό γέμισμα δεν βασίζεται σε θέση σχήματος. Σε μια ροή εργασίας όπου τα γεμίσματα είναι είτε χρώματα θέματος είτε άμεσες τιμές RGB, αυτή η τιμή ενδεικνύει άμεσο RGB γέμισμα.

Μην χρησιμοποιείτε μόνο την τοπική τιμή [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_schemecolor/) για να ταξινομήσετε ένα γέμισμα. Για παράδειγμα, ένα τμήμα κειμένου μπορεί να μην έχει τοπικά ορισμένο χρώμα σχήματος, οπότε η τοπική του τιμή είναι `NotDefined`, ενώ το αποτελεσματικό του γέμισμα κληρονομεί χρώμα θέματος και επιλύεται σε `Text1` ή `Accent6`. Αντίστροφα, το `get_SolidFillSchemeColor` σας λέει ποια λογική θέση θέματος παρήγαγε το αποτελεσματικό χρώμα, αλλά δεν δείχνει από ποιο επίπεδο (αντικείμενο, παράγραφος, διάταξη, master κλπ.) προέρχεται.

Το παρακάτω παράδειγμα φορτώνει μια παρουσίαση, ελέγχει τα γεμίσματα σχήματος και τα γεμίσματα τμημάτων κειμένου, εκτυπώνει κάθε τελική τιμή RGB και την αντίστοιχη θέση σχήματος, και σημαδέψει στερεά γεμίσματα που δεν θα παρακολουθούν αλλαγές σε θέματα χρώματος:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

Το κλαδί `NotDefined` παρέχει μια λίστα ελέγχου στερεών γεμισμάτων που δεν θα αντιδράσουν σε αλλαγές στις θέσεις χρώματος θέματος. Εξετάστε αυτά τα αντικείμενα όταν μια παρουσίαση πρέπει να ακολουθήσει μια νέα παλέτα εμπορικού σήματος. Η αναφερόμενη τιμή RGB δείχνει ακόμη την τρέχουσα εμφάνιση, ενώ η τιμή σχήματος εξηγεί αν αυτή η εμφάνιση είναι συνδεδεμένη με το θέμα.

Τα αντικείμενα αποτελεσματικής μορφοποίησης είναι στιγμιότυπα. Μετά την αλλαγή του θέματος παρουσίασης, μιας παρακάμψης θέματος ή οποιασδήποτε κληρονομημένης μορφοποίησης, καλέστε ξανά το `GetEffective` και διαβάστε ένα νέο αντικείμενο `IFillFormatEffectiveData` πριν κάνετε συγκρίσεις ή αναφορές χρωμάτων.

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι ορίζεται σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί πραγματικά μια διαφάνεια ή ένα σχήμα μετά την κληρονομικότητα και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Για ένα υπόβαθρο, χρησιμοποιήστε το [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/), και για ένα γέμισμα, χρησιμοποιήστε το [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το υπόβαθρο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστικά απόδοσης, επικυρώσεις και συγκρίσεις. Αν ελέγχετε μόνο το [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/), μπορεί να χάσετε μια παρακάμψη master, διάταξης, διαφάνειας ή σχήματος που αλλάζει τη τελική εμφάνιση.

## **Συχνές Ερωτήσεις**

**Επηρεάζει η εφαρμογή ενός εξωτερικού θέματος κάθε διαφάνεια στην παρουσίαση;**

Όχι. Η [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) επανακατευθύνει μόνο τις διαφάνειες που εξαρτώνται από τον επιλεγμένο master. Οι διαφάνειες που χρησιμοποιούν άλλους masters διατηρούν τα υπάρχοντα θέματα τους.

**Μπορώ να εφαρμόσω θέμα σε μια μόνο διαφάνεια χωρίς να αλλάξω το master;**

Ναι. Χρησιμοποιήστε το [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) της διαφάνειας και αρχικοποιήστε το παρακάμπσιμο θέμα της. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα τους.

**Ποιος είναι ο ασφαλέστερος τρόπος για να μεταφέρετε ένα θέμα από μια παρουσίαση σε άλλη;**

Κατά τη μετακίνηση μιας διαφάνειας και τη διατήρηση της αρχικής της εμφάνισης, κλωνοποιήστε το master προέλευσης στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτό το master χρησιμοποιώντας τις [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) και [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/). Αυτό διατηρεί το master, τις διατάξεις και το θέμα μαζί.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομικότητα και τις παρακάμψεις;**

Χρησιμοποιήστε το [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) για ένα θέμα διαφάνειας ή διάταξης και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) και το [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την εφαρμογή κληρονομικότητας και παρακάμψεων.