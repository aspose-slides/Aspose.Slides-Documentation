---
title: Διαχειριστείτε τα Θέματα Παρουσίασης σε C++
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
- Χρώμα θέματος
- Επιπρόσθετη παλέτα
- Γραμματοσειρά θέματος
- Στυλ θέματος
- Εφέ θέματος
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Κύρια θέματα παρουσίασης στο Aspose.Slides για C++ για δημιουργία, προσαρμογή και μετατροπή αρχείων PowerPoint με συνεπή επωνυμία."
---
## **Εισαγωγή**

Ένα θέμα παρουσίασης ορίζει ένα συντονισμένο σύνολο χρωμάτων, γραμματοσειρών, στυλ φόντου, γεμίσματος, γραμμών και εφέ. Τα αντικείμενα που λαμβάνουν υπόψη το θέμα αναφέρονται σε αυτές τις κοινές ορισμούς αντί να αποθηκεύουν κάθε οπτική ιδιότητα ως στατική τιμή, ώστε μια αλλαγή θέματος να μπορεί να ενημερώσει πολλά αντικείμενα ταυτόχρονα.

Στο Aspose.Slides, το θέμα σε επίπεδο παρουσίασης είναι διαθέσιμο μέσω [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_mastertheme/). Μία παρουσίαση μπορεί επίσης να περιέχει παρακάμψεις θέματος σε χαμηλότερα επίπεδα. Ένας master μπορεί να παρακάμψει το θέμα της παρουσίασης μέσω [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), ενώ ένα διάταξη ή μια μεμονωμένη διαφάνεια μπορεί να χρησιμοποιήσει [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). Στην πράξη, το αποτελεσματικό θέμα για μια διαφάνεια επιλύεται μέσω αυτής της αλυσίδας κληρονομικότητας: θέμα παρουσίασης, παράκαμψη master, παράκαμψη διάταξης και παράκαμψη διαφάνειας.

![Στοιχεία θέματος: χρώματα, γραμματοσειρές, στυλ φόντου και εφέ](theme-constituents.png)

Οι παρακάτω ενότητες παρουσιάζουν τις πιο συνηθισμένες ροές εργασίας με θέματα: επιθεώρηση ενός θέματος, αλλαγή χρωμάτων και γραμματοσειρών, αντιγραφή ή εφαρμογή θέματος, ενημέρωση στυλ φόντου και εφέ, και ανάγνωση αποτελεσματικών τιμών μετά την επίλυση κληρονομιάς και παρακάμψεων.

## **Επιθεώρηση Θέματος**

Το αντικείμενο [MasterTheme](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/mastertheme/) εκθέτει τις μεθόδους [get_ColorScheme()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) και [get_FormatScheme()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Η επιθεώρηση αυτών των συλλογών πριν τις αλλάξετε είναι ιδιαίτερα χρήσιμη όταν η παρουσίαση προέρχεται από εξωτερική πηγή, επειδή ο αριθμός και το περιεχόμενο των εγγραφών στυλ μπορεί να διαφέρει.

Το παρακάτω παράδειγμα διαβάζει τις κύριες ιδιότητες του θέματος και αναφέρει πόσες στυλ φόντου, γεμίσματος, γραμμής και εφέ είναι αποθηκευμένες στο θέμα:

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

Αν ένα αρχείο χρησιμοποιεί πολλούς masters, μην υποθέτετε ότι κάθε διαφάνεια έχει το ίδιο αποτελεσματικό θέμα. Επιθεωρήστε τον master που σχετίζεται με τη διαφάνεια και χρησιμοποιήστε τη ροή εργασίας αποτελεσματικού θέματος που φαίνεται αργότερα σε αυτό το άρθρο όταν μπορεί να υπάρξουν παρακάμψεις διάταξης ή διαφάνειας.

## **Αλλαγή Χρωμάτων Θέματος**

Τα γεμίσματα, οι γραμμές και το κείμενο που λαμβάνουν υπόψη το θέμα μπορούν να αναφέρονται σε ένα λογικό χρώμα από την απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/schemecolor/). Όταν αλλάζετε την αντίστοιχη καταχώριση στο [IColorScheme](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/icolorscheme/) του θέματος, όλα τα αντικείμενα που εξακολουθούν να αναφέρονται σε αυτό το χρώμα θέματος επιλύονται με τη νέα τιμή. Τα αντικείμενα που χρησιμοποιούν άμεσο χρώμα RGB δεν αλλάζουν με μια ενημέρωση χρώματος θέματος.

Το παρακάτω παράδειγμα from‑to‑end δημιουργεί ένα σχήμα που χρησιμοποιεί `Accent4`, αλλάζει το χρώμα `Accent4` του θέματος σε κόκκινο, αποθηκεύει την παρουσίαση, την ανοίγει ξανά και εκτυπώνει το αποτελεσματικό χρώμα γεμίσματος:

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

Επειδή το ορθογώνιο παραμένει συνδεδεμένο με το `Accent4`, το ορατό του χρώμα γίνεται κόκκινο μετά την αλλαγή του θέματος. Αν αντικαταστήσετε το χρώμα σχήματος με άμεσο χρώμα, οι μετέπειτα αλλαγές στο `Accent4` δεν θα επηρεάσουν πλέον αυτό το γέμισμα.

### **Χρήση Χρωμάτων από το Επιπρόσθετο Παλέτα**

Το PowerPoint παράγει πιο ανοιχτές και πιο σκούρες παραλλαγές από ένα χρώμα θέματος εφαρμόζοντας μετασχηματισμούς χρώματος. Το Aspose.Slides εκθέτει αυτούς τους μετασχηματισμούς μέσω του [ColorTransformOperation](https://reference.aspose.com/slides/el/cpp/aspose.slides/colortransformoperation/).

![Κύρια χρώματα θέματος και φωτεινότερα/σκοτεινότερα χρώματα που δημιουργούνται από το επιπρόσθετο παλέτα](additional-palette-colors.png)

**1** – Κύρια χρώματα θέματος.

**2** – Φωτεινότερες και σκοτεινότερες παραλλαγές που προέρχονται από τα κύρια χρώματα θέματος.

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

Αυτές οι παραλλαγές παραμένουν βασισμένες στο χρώμα θέματος. Αν το `Accent4` αλλάξει αργότερα, τα μετασχηματισμένα χρώματα επαναϋπολογίζονται από τη νέα τιμή του `Accent4`.

### **Χαρτογράφηση Τιμών `SchemeColor` σε Θέσεις `IColorScheme`**

Η απαρίθμηση [SchemeColor](https://reference.aspose.com/slides/el/cpp/aspose.slides/schemecolor/) χρησιμοποιεί τα `Text1`, `Background1`, `Text2` και `Background2`, ενώ το [IColorScheme](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/icolorscheme/) εκθέτει τις ίδιες θέσεις θέματος ως `Dark1`, `Light1`, `Dark2` και `Light2`. Η αντιστοίχιση είναι σταθερή:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Αυτά είναι εναλλακτικά ονόματα για τις ίδιες θέσεις θέματος· δεν είναι τιμές που μετατρέπονται δυναμικά από τη μία μορφή στην άλλη.

## **Αλλαγή Γραμματοσειρών Θέματος**

Ένα σχήμα γραμματοσειρών θέματος περιλαμβάνει ένα σύνολο κύριων γραμματοσειρών για τίτλους και ένα σύνολο δευτερευουσών γραμματοσειρών για κυρίως κείμενο. Οι μέθοδοι [FontScheme::get_Major()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/fontscheme/get_major/) και [FontScheme::get_Minor()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/fontscheme/get_minor/) εκθέτουν αυτά τα σύνολα.

Οι αναγνωριστικοί γραμματοσειρών συμβατοί με PowerPoint μπορούν να χρησιμοποιηθούν σε μορφοποίηση κειμένου:

* `+mn-lt` – Σώμα Γραμματοσειράς Λατινική (Minor Latin Font)
* `+mj-lt` – Γραμματοσειρά Τίτλου Λατινική (Major Latin Font)
* `+mn-ea` – Σώμα Γραμματοσειράς Ανατολική Ασία (Minor East Asian Font)
* `+mj-ea` – Γραμματοσειρά Τίτλου Ανατολική Ασία (Major East Asian Font)

Το παρακάτω παράδειγμα δημιουργεί έναν τίτλο που χρησιμοποιεί τη μεγάλη λατινική γραμματοσειρά θέματος και μια γραμμή σώματος που χρησιμοποιεί τη μικρή λατινική γραμματοσειρά θέματος. Στη συνέχεια αλλάζει τις γραμματοσειρές θέματος και αποθηκεύει το αποτέλεσμα:

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

Ο τίτλος ακολουθεί τη μεγάλη γραμματοσειρά και το κυρίως κείμενο ακολουθεί τη μικρή γραμματοσειρά. Το κείμενο που έχει ρητό όνομα γραμματοσειράς αντί για αναγνωριστικό θέματος δεν θα αλλάξει αυτόματα όταν αλλάξει το σχήμα γραμματοσειρών θέματος.

Οι συλλογές μεγάλης και μικρής γραμματοσειράς μπορούν επίσης να περιέχουν αντιστοιχίσεις γραμματοσειρών για μεμονωμένα συστήματα γραφής, όπως Κυριλλικό, Αραβικό, Ιαπωνικό, Γεωργιανό και Θάνα. Για να επιθεωρήσετε, προσθέσετε, αντικαταστήσετε ή αφαιρέσετε αυτές τις αντιστοιχίσεις, δείτε την ενότητα [Script-Specific Theme Fonts](/slides/el/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Για περισσότερες πληροφορίες σχετικά με τις γραμματοσειρές παρουσίασης, δείτε [Γραμματοσειρές PowerPoint](/slides/el/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Αντιγραφή ή Εφαρμογή Θέματος**

Υπάρχουν δύο κοινές ροές εργασίας, και λύνουν διαφορετικά προβλήματα.

### **Διατήρηση Πρωτότυπου Θέματος Κατά τη Μετακίνηση Διαφανειών**

Αν θέλετε να μετακινήσετε μια διαφάνεια σε άλλη παρουσίαση και να διατηρήσετε το αρχικό της σχεδιασμό, κλωνοποιήστε τον πηγαίο master στην προορισμιακή παρουσίαση με [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslidecollection/addclone/), στη συνέχεια κλωνοποιήστε τη διαφάνεια με [ISlideCollection::AddClone()](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/) και τον κλωνοποιημένο master. Αυτό μεταφέρει μαζί του τον master, τις διατάξεις του και το σχετικό θέμα.

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

Αυτή είναι η προτιμώμενη ροή εργασίας όταν η πηγαία διαφάνεια πρέπει να φαίνεται ίδια στον προορισμό. Η απλή κλωνοποίηση περιεχομένου σε έναν ανεξάρτητο master προορισμού μπορεί να αλλάξει χρώματα, γραμματοσειρές, φόντους και εφέ που καθορίζονται από το θέμα.

### **Εφαρμογή Τιμών Θέματος σε Υπάρχουσα Διαφάνεια**

Αν η διαφάνεια-στόχος πρέπει να παραμείνει στον τρέχον master και διάταξη, αρχικοποιήστε μια παράκαμψη επιπέδου διαφάνειας από το πηγαίο θέμα. Οι μέθοδοι [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) και [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) αντιγράφουν τα τρία κύρια στοιχεία του θέματος στην παράκαμψη.

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

Αυτό αλλάζει το θέμα που χρησιμοποιείται από εκείνη τη διαφάνεια χωρίς να αλλάξει το θέμα που κληρονομείται από τις άλλες διαφάνειες. Για να αφαιρέσετε την τοπική παράκαμψη και να επιστρέψετε στις κληρονομημένες τιμές, καλέστε [OverrideTheme::Clear()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/overridetheme/clear/).

### **Εφαρμογή Παράκαμψης Θέματος σε Διάταξη**

Μια παράκαμψη επιπέδου διάταξης εφαρμόζεται στις διαφάνειες που χρησιμοποιούν εκείνη τη διάταξη, εκτός εάν μια συγκεκριμένη διαφάνεια έχει τη δική της παράκαμψη. Οι ίδιες μέθοδοι αρχικοποίησης μπορούν να χρησιμοποιηθούν μέσω του [IOverrideThemeManager](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/ioverridethememanager/) της διάταξης:

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

Χρησιμοποιήστε ένα θέμα σε επίπεδο master ή παρουσίασης όταν πολλές διατάξεις και διαφάνειες πρέπει να μοιράζονται τον ίδιο βασικό σχεδιασμό, μια παράκαμψη διάταξης όταν μια οικογένεια διατάξεων χρειάζεται διαφορετικό στυλ, και μια παράκαμψη διαφάνειας μόνο για πραγματικές εξαιρέσεις. Πάρα πολλές παρακάμψεις επιπέδου διαφάνειας κάνουν τις μεταγενέστερες παγκόσμιες αλλαγές θέματος πιο δύσκολο να προβλεφθούν.

## **Ενημέρωση Στυλ Φόντου Θέματος**

Τα γέμισματα φόντου του θέματος αποθηκεύονται στο [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). Το PowerPoint μπορεί να παρουσιάσει περισσότερες επιλογές φόντου στη διεπαφή του από τον αριθμό των ορισμών γεμίσματος που αποθηκεύονται στην συλλογή, επειδή η διεπαφή μπορεί να συνδυάσει γεμίσματα θέματος με χρώματα θέματος και άλλες αναφορές στυλ.

![Συλλογή στυλ φόντου PowerPoint για ένα θέμα παρουσίασης](presentation-design_8.png)

Πριν χρησιμοποιήσετε ένα στυλ φόντου, επιθεωρήστε τη αποθηκευμένη συλλογή και την τρέχουσα [Background::get_StyleIndex()](https://reference.aspose.com/slides/el/cpp/aspose.slides/background/get_styleindex/). Το `StyleIndex` χρησιμοποιεί το `0` για καμία θεματική γέμιση· θετικές τιμές είναι αναφορές σε στυλ φόντου θέματος. Αυτό διαφέρει από το δείκτη μιας C++ συλλογής με `idx_get(0)`, όπου το `0` σημαίνει το πρώτο αποθηκευμένο στοιχείο. Μην υποθέτετε ότι κάθε παρουσίαση περιέχει τον ίδιο αριθμό στυλ φόντου.

Το παρακάτω παράδειγμα αναφέρει τον διαθέσιμο αριθμό γεμισμάτων φόντου, εκχωρεί μια θεματική αναφορά φόντου στον πρώτο master και αποθηκεύει την παρουσίαση:

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

Το ορατό αποτέλεσμα εξαρτάται από την καταχώριση θέματος που αναφέρεται ο master και από τυχόν παρακάμψεις φόντου στη διάταξη ή τη διαφάνεια. Αν μια διαφάνεια χρησιμοποιεί το δικό της φόντο, η αλλαγή μόνο του φόντου του master μπορεί να μην αλλάξει εκείνη τη διαφάνεια. Χρησιμοποιήστε το [Background::GetEffective()](https://reference.aspose.com/slides/el/cpp/aspose.slides/background/geteffective/) όταν χρειάζεστε το τελικό φόντο μετά την εφαρμογή κληρονομιάς.

{{% alert color="warning" title="Warning" %}}
Μην αντιμετωπίζετε το `StyleIndex` ως δείκτη συλλογής με βάση το μηδέν. Επίσης, αποφύγετε την σκληρή κωδικοποίηση ενός αριθμού στυλ από ένα αρχείο και την υπόθεση ότι θα έχει την ίδια εμφάνιση σε άλλο αρχείο· οι ορισμοί στυλ θέματος είναι ειδικοί για κάθε παρουσίαση.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Για άμεση μορφοποίηση φόντου και κληρονομιά φόντου, δείτε την ενότητα [Presentation Background](/slides/el/cpp/presentation-background/).
{{% /alert %}}

## **Ενημέρωση Εφέ Θέματος**

Ένα σχήμα μορφοποίησης θέματος περιλαμβάνει ξεχωριστές συλλογές [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/formatscheme/get_linestyles/) και [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Τα τυπικά θέματα Office συχνά περιέχουν τρία κύρια στοιχεία στυλ που αντιστοιχούν οπτικά σε λεπτό, μέτριο και έντονο μορφοποίηση, αλλά ο κώδικας πρέπει να επιθεωρεί κάθε συλλογή αντί να υποθέτει σταθερό αριθμό.

![Λεπτά, μέτρια και έντονα εφέ θέματος που εφαρμόζονται στο ίδιο σχήμα](presentation-design_10.png)

Όταν προσπελάζετε αυτές τις συλλογές σε C++, ο δείκτης της συλλογής είναι μηδενικής βάσης: `idx_get(0)` είναι το πρώτο αποθηκευμένο στυλ και `idx_get(2)` είναι το τρίτο. Οι δείκτες αναφοράς στυλ ενός σχήματος είναι ξεχωριστή έννοια, εκτεθειμένη μέσω του [IShapeStyle](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapestyle/). Η τροποποίηση ενός στυλ θέματος επηρεάζει τα σχήματα που αναφέρονται σε αυτό το στυλ θέματος· τα σχήματα με άμεση μορφοποίηση μπορεί να παραμείνουν αμετάβλητα.

Το παρακάτω παράδειγμα ελέγχει αν υπάρχουν τα απαιτούμενα στοιχεία στυλ, αλλάζει το πρώτο στυλ γραμμής, το τρίτο στυλ γεμίσματος, ενεργοποιεί μια εξωτερική σκιά στο τρίτο στυλ εφέ και αποθηκεύει το αποτέλεσμα:

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

Για σχήματα που αναφέρονται σε αυτές τις θέσεις, το πρώτο στυλ γραμμής θέματος γίνεται κόκκινο, το τρίτο στυλ γεμίσματος γίνεται στερεό δάστικο πράσινο, και το τρίτο στυλ εφέ αποκτά εξωτερική σκιά με απόσταση 10 σημείων. Το ακριβές οπτικό αποτέλεσμα εξακολουθεί να εξαρτάται από τις θέσεις στυλ που αναφέρονται τα σχήματα και αν η άμεση μορφοποίηση παρακάμπτει το θέμα.

![Στυλ εφέ θέματος μετά την αλλαγή ρυθμίσεων γραμμής, γεμίσματος και σκιάς](presentation-design_11.png)

## **Ανάγνωση Αποτελεσματικών Τιμών Θέματος**

Τα ακατέργαστα αντικείμενα θέματος σας λένε τι ορίζεται σε ένα συγκεκριμένο επίπεδο. Οι αποτελεσματικές τιμές σας λένε τι χρησιμοποιεί μια διαφάνεια ή ένα σχήμα μετά την κληρονομιά και τις τοπικές παρακάμψεις. Για μια διαφάνεια, καλέστε το [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Για φόντο, χρησιμοποιήστε το [Background::GetEffective()](https://reference.aspose.com/slides/el/cpp/aspose.slides/background/geteffective/), και για γέμισμα, το [FillFormat::GetEffective()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/geteffective/).

Το παρακάτω παράδειγμα διαβάζει το αποτελεσματικό θέμα, το φόντο και το πρώτο γέμισμα σχήματος από μια διαφάνεια:

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

Χρησιμοποιήστε τα αποτελεσματικά δεδομένα για διαγνωστικά rendering, επικύρωση και συγκρίσεις. Αν επιθεωρήσετε μόνο το [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/get_mastertheme/), μπορεί να χάσετε μια παράκαμψη master, διάταξης, διαφάνειας ή σχήματος που αλλάζει την τελική εμφάνιση.

## **ΣΥΝΕΧΕΙΑ ΣΥΝΑΡΤΗΣΕΩΝ (FAQ)**

**Μπορώ να εφαρμόσω ένα θέμα σε μία μόνο διαφάνεια χωρίς να αλλάξω τον master;**

Ναι. Χρησιμοποιήστε το [IOverrideThemeManager](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/ioverridethememanager/) της διαφάνειας και αρχικοποιήστε το θέμα παράκαμψης. Η αλλαγή παραμένει τοπική σε αυτή τη διαφάνεια· οι άλλες διαφάνειες συνεχίζουν να κληρονομούν τα υπάρχοντα θέματα.

**Ποιος είναι ο πιο ασφαλής τρόπος για να μεταφέρω ένα θέμα από μια παρουσίαση σε άλλη;**

Όταν μετακινείτε μια διαφάνεια και διατηρείτε την αρχική της εμφάνιση, κλωνοποιήστε τον πηγαίο master στον προορισμό και κλωνοποιήστε τη διαφάνεια με αυτόν τον master χρησιμοποιώντας τα [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/el/cpp/aspose.slides/imasterslidecollection/addclone/) και [ISlideCollection::AddClone()](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidecollection/addclone/). Αυτό κρατάει τον master, τις διατάξεις και το θέμα μαζί.

**Πώς μπορώ να δω τις αποτελεσματικές τιμές μετά την κληρονομιά και τις παρακάμψεις;**

Χρησιμοποιήστε το [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/el/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) για μια διαφάνεια ή θέμα διάταξης και τις αντίστοιχες μεθόδους αποτελεσματικών δεδομένων για αντικείμενα μορφοποίησης όπως το [Background::GetEffective()](https://reference.aspose.com/slides/el/cpp/aspose.slides/background/geteffective/) και το [FillFormat::GetEffective()](https://reference.aspose.com/slides/el/cpp/aspose.slides/fillformat/geteffective/). Αυτά τα API επιστρέφουν τις επιλυμένες τιμές μετά την εφαρμογή κληρονομιάς και παρακάμψεων.