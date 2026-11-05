---
title: "Διαμόρφωση Σχημάτων PowerPoint σε C++"
linktitle: "Μορφοποίηση Σχήματος"
type: docs
weight: 20
url: /el/cpp/shape-formatting/
keywords:
- "μορφοποίηση σχήματος"
- "μορφοποίηση γραμμής"
- "εφέ σκίτσου"
- "σχέδιο γραμμής σχήματος"
- "μορφοποίηση στυλ σύνδεσης"
- "γέμισμα διαβάθμισης"
- "γέμισμα προτύπου"
- "γέμισμα εικόνας"
- "γέμισμα υφής"
- "συμπαγές γέμισμα χρώματος"
- "διαφάνεια σχήματος"
- "απεικόνιση σχήματος ασπρόμαυρου"
- "απεικόνιση σχήματος σε κλίμακα γκρι"
- "περιστροφή σχήματος"
- "εφέ 3Δ λοξής ακμής"
- "εφέ 3Δ περιστροφής"
- "επαναφορά μορφοποίησης"
- "PowerPoint"
- "παρουσίαση"
- "C++"
- "Aspose.Slides"
description: "Μάθετε πώς να μορφοποιείτε σχήματα PowerPoint σε C++ χρησιμοποιώντας το Aspose.Slides—ορίστε στυλ γεμίσματος, γραμμής και εφέ για αρχεία PPT και PPTX με ακρίβεια και πλήρη έλεγχο."
---
## **Εισαγωγή**

Διαμορφώστε σχήματα στο PowerPoint προσαρμόζοντας τα περιγράμματά τους, τις γεμίσεις και τα εφέ. Το Aspose.Slides for C++ σας επιτρέπει να ελέγχετε αυτές τις ρυθμίσεις προγραμματιστικά, συμπεριλαμβανομένης της διαφάνειας, της περιστροφής και της 3Δ διαμόρφωσης.

![Επιλογές μορφοποίησης σχήματος στο PowerPoint](format-shape-powerpoint.png)

Το Aspose.Slides for C++ παρέχει διεπαφές και μεθόδους που σας επιτρέπουν να μορφοποιείτε σχήματα χρησιμοποιώντας τις ίδιες επιλογές που διατίθενται στο PowerPoint.

## **Μορφοποίηση Γραμμών**

Χρησιμοποιήστε [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) για να ελέγξετε το περίγραμμα ενός σχήματος. Αυτό το παράδειγμα δημιουργεί ένα μη γεμισμένο ορθογώνιο με μπλε, διακεκομμένο περίγραμμα. Το [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/) επιλέγει μια σύνθετη γραμμή παχιά-λεπτή, ενώ το [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) ορίζει το πλάτος της σε 7 σημεία και το [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) επιλέγει το μοτίβο διακεκομμένων.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι μορφοποιημένες γραμμές στην παρουσίαση](formatted-lines.png)

### **Ορισμός Προσαρμοσμένων Μορφών Διακεκομμένων Γραμμών**

Χρησιμοποιήστε [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/) όταν τα προεπιλεγμένα στυλ γραμμής δεν παρέχουν τα μήκη και τα κενά που χρειάζεστε, π.χ. για εμπορικά περιγράμματα ή τεχνικά διαγράμματα. Η ανάθεση ενός μοτίβου αλλάζει αυτόματα το στυλ διακεκομμένων σε [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/).

Οι καταχωρίσεις του πίνακα εναλλάσσονται μεταξύ μήκους γραμμής και κενό, ξεκινώντας με γραμμή. Κάθε τιμή είναι πολλαπλάσιο του πλάτους της γραμμής: `{ 4, 2 }` με πλάτος 3 σημείων παράγει μια γραμμή 12 σημείων ακολουθούμενη από κενό 6 σημείων. Χρησιμοποιήστε ζεύγη πεπερασμένων, μη αρνητικών τιμών για να ορίσετε πλήρη τμήματα γραμμής-κενού. Το παράδειγμα χρησιμοποιεί θετικές τιμές ώστε κάθε γραμμή και κενό να είναι ορατά.

Αυτό το παράδειγμα δημιουργεί πέντε μπλε γραμμές με το ίδιο μήκος και επίπεδα άκρα. Οι πρώτες τρεις συγκρίνουν μοτίβα με πλάτος 3 σημείων. Η τέταρτη επαναλαμβάνει το πρώτο μοτίβο με διπλασιασμένο πλάτος, διπλασιάζοντας τόσο τα μήκη γραμμής όσο και τα κενά. Η πέμπτη μεταβαίνει από προσαρμοσμένο μοτίβο σε στερεή γραμμή.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(600, 300, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto patterns = std::array<ArrayPtr<float>, 5>{
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 1, 2 }),
    MakeArray<float>({ 6, 2, 1, 2 }),
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 4, 2 })
};

for (auto i = 0; i < patterns.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 50, 50 + i * 50, 500, 0);
    line->get_LineFormat()->set_Width(i == 3 ? 6 : 3);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_CapStyle(LineCapStyle::Flat);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_CustomDashPattern(patterns[i]);
}

// Επιστρέψτε την τελευταία γραμμή σε στερεό στυλ.
slide->get_Shape(4)->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);

presentation->Save(u"custom_dash_patterns.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Για να επιστρέψετε σε προεπιλεγμένο στυλ διακεκομμένων, περάστε το [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) στο [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/). Το επιλεγμένο στυλ ελέγχει την εμφάνιση της γραμμής.

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; και **Solid, 3 pt**.

![Τρία προσαρμοσμένα μοτίβα διακεκομμένων, μια ευρύτερη γραμμή που χρησιμοποιεί το πρώτο μοτίβο, και μια στερεή γραμμή στο PowerPoint](custom-dash-patterns.png)

### **Ορισμός Άκρων Γραμμής**

Χρησιμοποιήστε [ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/) για να ορίσετε τα άκρα μιας ανοιχτής γραμμής. Η απαρίθμηση [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/) παρέχει τρία σαφή στυλ άκρων:

- `Flat`: Το στίγμα σταματά στο σημείο άκρου.
- `Round`: Ένα ημικυκλικό άκρο εκτείνεται πέρα από το άκρο κατά το ήμισυ του πλάτους της γραμμής.
- `Square`: Ένα τετράγωνο άκρο εκτείνεται πέρα από το άκρο κατά το ήμισυ του πλάτους της γραμμής.

Η απαρίθμηση περιλαμβάνει επίσης το `NotDefined`, που σημαίνει ότι δεν έχει ανατεθεί ρητά στυλ άκρου.

Τα άκρα διαφέρουν από τα βέλη, τα οποία προσθέτουν σύμβολα στα άκρα της γραμμής, και τις ενώσεις, που ελέγχουν τις γωνίες μεταξύ τμημάτων γραμμής. Αυτό το παράδειγμα απενεργοποιεί τα βέλη μέσω των [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/) και [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/) ώστε να συγκριθούν μόνο τα σχήματα άκρων.

Το παρακάτω παράδειγμα δημιουργεί τρεις οριζόντιες γραμμές, 20 σημείων πλάτος, που είναι κατά τα άλλα ίδια. Από πάνω προς τα κάτω, χρησιμοποιούν επίπεδα, στρογγυλά και τετράγωνα άκρα. Τα άκρα τους έχουν τις ίδιες οριζόντιες συντεταγμένες· τα στρογγυλά και τετράγωνα άκρα εκτείνονται 10 σημεία πέρα από κάθε άκρο.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 240, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto capStyles = std::array<LineCapStyle, 3>{ LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square };

for (auto i = 0; i < capStyles.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 100, 50 + i * 70, 300, 0);
    line->get_LineFormat()->set_Width(20);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);
    line->get_LineFormat()->set_CapStyle(capStyles[i]);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
}

presentation->Save(u"line_caps.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα στο PowerPoint, από πάνω προς τα κάτω: **Flat**, **Round**, and **Square**.

![Επίπεδα, στρογγυλά και τετράγωνα άκρα σε πανομοιότυπες παχιές γραμμές στο PowerPoint](line-caps.png)

## **Εφαρμογή Σχέδιας Εφέ σε Γραμμές Σχήματος**

Ένα εφέ σκίτσου κάνει τη γραμμή ενός σχήματος να φαίνεται χειρόγραφη. Χρησιμοποιήστε [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις της γραμμής, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) για να αποκτήσετε πρόσβαση στις ρυθμίσεις σκίτσου, και [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) για να επιλέξετε μια τιμή από την απαρίθμηση [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/).

Ο παρακάτω κώδικας C++ δείχνει πώς να εφαρμόσετε το εφέ [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/), να διαβάσετε τη ρητά ανατεθειμένη τιμή και να αφαιρέσετε το εφέ με το [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();
sketchFormat->set_SketchType(LineSketchType::Curved);
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Η τιμή που επιστρέφεται από το [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) αντιπροσωπεύει τη ρύθμιση που έχει ανατεθεί άμεσα στο σχήμα. Εάν η μορφοποίηση της γραμμής μπορεί να κληρονομηθεί από ένα θέμα, μια κύρια διαφάνεια ή μια διάταξη διαφάνειας, χρησιμοποιήστε το [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), αποκτήστε πρόσβαση στο [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), και διαβάστε το [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Η αποτελεσματική τιμή αντικατοπτρίζει τη μορφοποίηση που εφαρμόζεται στην πραγματικότητα μετά την επίλυση της κληρονομικότητας. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με τουλάχιστον ένα σχήμα στην πρώτη διαφάνεια και εκτυπώνει και τις δύο τιμές:

```cpp
#include <DOM/ILineFormat.h>
#include <DOM/ILineFormatEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISketchFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto lineFormat = shape->get_LineFormat();
auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);
presentation->Dispose();
```

## **Μορφοποίηση Στυλ Συνένωσης**

Εδώ είναι οι τρεις επιλογές τύπου σύνδεσης:

* Round
* Miter
* Bevel

Το στυλ σύνδεσης ελέγχει τον τρόπο με τον οποίο δύο τμήματα περιγράμματος συναντώνται σε μια γωνία. Χρησιμοποιήστε **Round** για στρογγυλεμένες γωνίες, **Miter** για οξές γωνίες ή **Bevel** για επίπεδες γωνίες.

![Το στυλ σύνδεσης στην παρουσίαση](join-style-powerpoint.png)

Αυτό το παράδειγμα δημιουργεί τρία μαύρα ορθογώνια με μπλε περιγράμματα 15 σημείων πλάτος. Ορίζει το [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) στις τιμές μιτερ, βαθμίδα και στρογγυλό της [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/), αντίστοιχα, για να συγκρίνει πώς σχεδιάζονται οι γωνίες.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto miterShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto bevelShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto roundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

miterShape->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
bevelShape->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
roundShape->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

miterShape->get_LineFormat()->set_Width(15);
bevelShape->get_LineFormat()->set_Width(15);
roundShape->get_LineFormat()->set_Width(15);

miterShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
bevelShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
roundShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

miterShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
bevelShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
roundShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

miterShape->get_TextFrame()->set_Text(u"Miter Join Style");
bevelShape->get_TextFrame()->set_Text(u"Bevel Join Style");
roundShape->get_TextFrame()->set_Text(u"Round Join Style");

presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Περιορισμός Σημείων Μήτρας σε Κόχυνα Γωνία**

Χρησιμοποιήστε το [ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/) μαζί με το [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) ορισμένο στο [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) για να περιορίσετε πόσο μακριά μπορεί να εκτείνεται μια οξεία γωνία.

Το όριο είναι ένας λόγος της απόστασης μεταξύ των εσωτερικών και εξωτερικών γωνιών της σύνδεσης προς το πλάτος της γραμμής. Για παράδειγμα, η τιμή `8` επιτρέπει μήκος σημείου μέχρι οκτώ φορές το πλάτος της γραμμής· δεν είναι μέτρηση σε σημεία. Εάν η γωνία υπερβεί το όριο, το PowerPoint χρησιμοποιεί μια λεπίδα στην εν λόγω γωνία. Ένα μεγαλύτερο όριο επιτρέπει πιο οξείς σημεία. Η ρύθμιση επηρεάζει μόνο τις συνδέσεις με μιτερ και δεν έχει ορατή επίδραση όταν η γωνία παραμένει εντός και των δύο ορίων.

Αυτό το παράδειγμα δημιουργεί δύο όμοια, μη γεμισμένα τρίγωνα με περιγράμματα 20 σημείων πλάτος. Το αριστερό τρίγωνο χρησιμοποιεί όριο `2`, ενώ το δεξί `8`. Κάθε τρίγωνο είναι 80 σημεία πλάτος και 160 σημεία ύψος, δίνοντας στην άνω γωνία του λόγο μήκους μιτερ προς πλάτος περίπου `4.12`. Συνεπώς, το PowerPoint λεία την αριστερή κορυφή και διατηρεί τη δεξιά.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 320, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto miterLimits = std::array<float, 2>{ 2.0f, 8.0f };

for (auto i = 0; i < miterLimits.size(); i++)
{
    auto triangle = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 90 + i * 240, 110, 80, 160);
    triangle->get_FillFormat()->set_FillType(FillType::NoFill);
    triangle->get_LineFormat()->set_Width(20);
    triangle->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    triangle->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    triangle->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
    triangle->get_LineFormat()->set_MiterLimit(miterLimits[i]);
}

presentation->Save(u"miter_limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα στο PowerPoint: **Miter limit 2** στα αριστερά και **miter limit 8** στα δεξιά.

![Λεία κορυφή με όριο μιτερ 2 και αιχμηρή κορυφή με όριο μιτερ 8 στο PowerPoint](miter-limits.png)

## **Γέμισμα Διαβάθμισης**

Ένα γέμισμα διαβάθμισης αναμειγνύει χρώματα σε ένα σχήμα. Αυτό το παράδειγμα γεμίζει μια έλλειψη με γραμμική διαβάθμιση υπό γωνία 45 μοιρών από κόκκινο σε μωβ χρησιμοποιώντας το [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/). Η μέθοδος [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/) τοποθετεί τις στάσεις χρώματος στα 0 και 1, την αρχή και το τέλος της διαβάθμισης. Η εκκαθάριση των υπαρχουσών στάσεων εξασφαλίζει ότι χρησιμοποιούνται μόνο αυτά τα δύο χρώματα.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);
shape->get_FillFormat()->get_GradientFormat()->set_LinearGradientAngle(45);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Clear();
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η έλλειψη με γέμισμα διαβάθμισης](gradient-fill.png)

Εάν μια διαβάθμιση φαίνεται διαφορετική σε μια εξαγόμενη εικόνα από ό,τι στο PowerPoint, δείτε [Επιλογή Στυλ Απόδοσης Διαβάθμισης](/slides/el/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Μπορείτε να επιλέξετε στυλ απόδοσης χωρίς να αλλάξετε τη διαβάθμιση που αποθηκεύεται στην παρουσίαση.

### **Ορισμός Γωνίας Γραμμικής Διαβάθμισης**

Χρησιμοποιήστε το [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) για να ελέγξετε τον προσανατολισμό μιας γεμίσματος [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/). Η γωνία μετράται σε μοίρες και αυξάνεται δεξιόστροφα: `0` τρέχει από αριστερά προς δεξιά, `90` από πάνω προς τα κάτω, `180` από δεξιά προς αριστερά και `270` από κάτω προς πάνω. Υποστηρίζονται κλασματικές γωνίες. Οι πεπερασμένες γωνίες εκτός του `[0, 360)` κανονικοποιούνται σε μια πλήρη περιστροφή· για παράδειγμα, `-45` γίνεται `315` και `360` γίνεται `0`.

Αυτό το παράδειγμα δημιουργεί έξι ορθογώνια με τα ίδια κόκκινα, πράσινα και μπλε στάσεις στις θέσεις `0`, `0.5` και `1`. Η κλιμάκωση είναι απενεργοποιημένη ώστε η γωνία να συγκριθεί ανεξάρτητα από τις αναλογίες των ορθογωνίων. Οι γωνίες, από αριστερά προς δεξιά, είναι `0`, `45` και `90` στην πρώτη σειρά, και `135`, `180` και `270` στη δεύτερη σειρά.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto angles = std::array<float, 6>{ 0, 45, 90, 135, 180, 270 };

for (auto i = 0; i < angles.size(); i++)
{
    auto x = 30 + (i % 3) * 230;
    auto y = 30 + (i / 3) * 190;

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 200, 150);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::False);
    gradient->set_LinearGradientAngle(angles[i]);
}

presentation->Save(u"linear_gradient_angles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα στο PowerPoint:

![Γραμμικές διαβάθμιση στις 0, 45 και 90 μοίρες στην επάνω σειρά, και 135, 180 και 270 μοίρες στην κάτω σειρά](linear-gradient-angles.png)

### **Κλίμακα Γραμμικής Διαβάθμισης με το Σχήμα**

Το [IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/) δέχεται μια τιμή [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/). Ορίστε την ρητά σε `False` για να διατηρήσετε τη γεωμετρική γωνία της διαβάθμισης όταν αλλάζουν οι αναλογίες του σχήματος, ή σε `True` για να κλιμακώσετε τη διαβάθμιση με το πλάτος και το ύψος του σχήματος. Με την κλιμάκωση ενεργοποιημένη, η ορατή γωνία μπορεί να διαφέρει από την ανάθετη γωνία σε μη τετράγωνο σχήμα.

Το παρακάτω παράδειγμα χρησιμοποιεί γωνία `45` μοιρών και τις ίδιες στάσεις χρώματος όπως στην σύγκριση γωνιών. Η αριστερή στήλη χρησιμοποιεί `False`; η δεξιά `True`. Κάθε στήλη περιλαμβάνει ένα πλατύ ορθογώνιο πάνω από ένα ψηλό ορθογώνιο. Και οι δύο αρχίζουν με τις ίδιες οριζόντιες διαστάσεις· η αλλαγή του πλάτους και του ύψους του δεύτερου ορθογωνίου δείχνει πώς το γέμισμα ανταποκρίνεται στην αλλαγή μεγέθους χωρίς αλλαγή των ρυθμίσεων διαβάθμισης.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 460, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto scalingOptions = std::array<NullableBool, 2>{ NullableBool::False, NullableBool::True };

for (auto column = 0; column < scalingOptions.size(); column++)
{
    for (auto row = 0; row < 2; row++)
    {
        auto x = 30 + column * 360;
        auto y = row == 0 ? 30 : 150;

        auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 300, 90);
        shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
        shape->get_FillFormat()->set_FillType(FillType::Gradient);

        auto gradient = shape->get_FillFormat()->get_GradientFormat();
        gradient->set_GradientShape(GradientShape::Linear);
        gradient->get_GradientStops()->Clear();
        gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
        gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
        gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
        gradient->set_LinearGradientAngle(45);
        gradient->set_LinearGradientScaled(scalingOptions[column]);

        if (row == 1)
        {
            shape->set_Width(90);
            shape->set_Height(280);
        }
    }
}

presentation->Save(u"linear_gradient_scaling.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα στο PowerPoint, με κλιμάκωση απενεργοποιημένη στα αριστερά και ενεργοποιημένη στα δεξιά:

![Πλατιά και ψηλά ορθογώνια με διαβάθμιση 45 μοιρών, συγκρίνοντας LinearGradientScaled False στα αριστερά με True στα δεξιά](linear-gradient-scaling.png)

Με κλιμάκωση απενεργοποιημένη, οι διαγώνιες λωρίδες χρώματος διατηρούν τον ίδιο προσανατολισμό και στα δύο ορθογώνια. Με κλιμάκωση ενεργοποιημένη, οι λωρίδες τραβιούνται με τις αναλογίες του σχήματος. Αυτό βοηθά στην αναπαραγωγή μιας διαβάθμισης προτύπου όταν προσαρμόζεται ένα σχήμα σε διαφορετικό μέγεθος. Σε τετράγωνο σχήμα, η ενεργοποίηση της κλιμάκωσης δεν αλλάζει την εμφάνιση αυτής της διαβάθμισης 45 μοιρών.

Τanto η γωνία όσο και οι ρυθμίσεις κλιμάκωσης εφαρμόζονται σε γραμμικές διαβάθμιση. Δεν ελέγχουν γεμίσματα [GradientShape::Radial ή GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/).

### **Συνδυασμός Γωνίας με Κατεύθυνση Διαβάθμισης**

Το [IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/) επιλέγει ένα στυλ διαβάθμισης από την απαρίθμηση [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/); δεν αντικαθιστά έναν αριθμητικό γωνιακό ορισμό. Για μια γραμμική διαβάθμιση, τα στυλ γωνιών μπορούν να αλλάξουν την περιοχή όπου διανέμονται τα χρώματα χωρίς να αλλάξουν τη γωνία που έχει οριστεί μέσω του [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/). Διατηρήστε την κατεύθυνση αμετάβλητη όταν συγκρίνετε γωνίες ή κλιμάκωση.

Το παρακάτω παράδειγμα εφαρμόζει τις ίδιες ρυθμίσεις με αντίστροφη σειρά. Τα δύο ορθογώνια έχουν την ίδια εμφάνιση: η ανάθεση της κατεύθυνσης πριν ή μετά τη γωνία δεν αλλάζει το αποτέλεσμα.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30 + i * 140, 320, 100);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::True);

    if (i == 0)
    {
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
        gradient->set_LinearGradientAngle(30);
    }
    else
    {
        gradient->set_LinearGradientAngle(30);
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
    }
}

presentation->Save(u"linear_gradient_direction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Γέμισμα Προτύπου**

Ένα γέμισμα προτύπου εφαρμόζει ένα σχεδιασμό δύο χρωμάτων, όπως κουκίδες, λωρίδες ή σκαλοπάτια. Αυτό το παράδειγμα χρησιμοποιεί το [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/) για να επιλέξει ένα μοτίβο πλέγματος. Το [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) παρέχει το ανοιχτό γκρι φόντο, και το [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) παρέχει το κίτρινο χρώμα του μοτίβου.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Pattern);
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το ορθογώνιο με γέμισμα προτύπου](pattern-fill.png)

## **Γέμισμα Εικόνας**

Ένα γέμισμα εικόνας χρησιμοποιεί μια εικόνα μέσα σε ένα σχήμα. Αυτό το παράδειγμα απαιτεί μια τοπική εικόνα και χρησιμοποιεί το [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) για να τη φορτώσει στη συλλογή εικόνων της παρουσίασης. Ορίζοντας το [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) σε λειτουργία πλακιδίων (tiled) επαναλαμβάνει την εικόνα μέσα στο ορθογώνιο. Η πηγαία εικόνα που χρησιμοποιείται παρακάτω φαίνεται παρακάτω:

![Η εικόνα λωτός](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

auto image = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(image);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(presentationImage);

presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
image->Dispose();
presentation->Dispose();
```

Το αποτέλεσμα:

![Το σχήμα με γέμισμα εικόνας](picture-fill.png)

### **Ταπing Εικόνας Ως Υφή**

Εάν θέλετε να ορίσετε μια επαναλαμβανόμενη εικόνα ως υφή και να προσαρμόσετε τη συμπεριφορά ταπισεία, μπορείτε να χρησιμοποιήσετε τις παρακάτω μεθόδους της διεπαφής [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) και της κλάσης [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Ορίζει τη λειτουργία γεμίσματος εικόνας — είτε `Tile` είτε `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Καθορίζει την ευθυγράμμιση των πλακιδίων εντός του σχήματος.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Ελέγχει εάν το πλακίδιο αντιστρέφεται οριζόντια, κάθετα ή και τα δύο.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Ορίζει την οριζόντια μετατόπιση του πλακιδίου (σε σημεία) από το σημείο προέλευσης του σχήματος.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Ορίζει την κάθετη μετατόπιση του πλακιδίου (σε σημεία) από το σημείο προέλευσης του σχήματος.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Ορίζει την οριζόντια κλίμακα του πλακιδίου ως ποσοστό.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Ορίζει την κάθετη κλίμακα του πλακιδίου ως ποσοστό.

Αυτό το παράδειγμα απαιτεί μια τοπική εικόνα και ρυθμίζει το [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) ώστε να την επαναλάβει στο 50 % του αρχικού μεγέθους. Μετατοπίσεις −32 σημείων μετατοπίζουν τα πλακίδια οριζόντια και κάθετα· η ευθυγράμμιση κάτω‑δεξιά και η αναστροφή και στις δύο κατευθύνσεις καθορίζουν πώς διατάσσεται η επαναλαμβανόμενη υφή.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);

auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
shape->get_FillFormat()->set_FillType(FillType::Picture);

auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);

auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

presentation->Save(u"tile.pptx", SaveFormat::Pptx);
sourceImage->Dispose();
presentation->Dispose();
```

Το αποτέλεσμα:

![Οι επιλογές πλακιδίου](tile-options.png)

## **Γέμισμα Στερεού Χρώματος**

Ένα στερεό γέμισμα δίνει στο σχήμα ένα ενιαίο, ομοιόμορφο χρώμα. Αυτό το παράδειγμα ορίζει το [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) σε λειτουργία στερεού γέμισματος και αναθέτει κίτρινο μέσω του [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/), στη συνέχεια αποθηκεύει το ορθογώνιο σε μια παρουσίαση.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το σχήμα με στερεό χρωματικό γέμισμα](solid-color-fill.png)

### **Αντιγραφή Χρωμάτων Με Διατήρηση Αναφορών Θέματος**

Χρησιμοποιήστε το [IColorFormat::CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/copyfrom/) για να αντιγράψετε έναν ορισμό χρώματος, συμπεριλαμβανομένου του τύπου χρώματος, της αναφοράς θέματος και των μετασχηματισμών. Αυτό είναι χρήσιμο όταν μεταφέρετε ένα χρώμα γεμίσματος μεταξύ σχημάτων που πρέπει να συνεχίσουν να ακολουθούν το θέμα της παρουσίασης. Η μέθοδος αντιγράφει μόνο το χρώμα: δεν αντιγράφει τον τύπο γεμίσματος, το περίγραμμα ή άλλες μορφοποιήσεις του σχήματος. Ορίστε ρητά τον τύπο γεμίσματος προορισμού με το [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/).

Αυτό το παράδειγμα δημιουργεί τρία ορθογώνια, από αριστερά προς τα δεξιά: η πηγή, ένα αντίγραφο που σέβεται το θέμα, και ένα σταθερό RGB αντίγραφο. Η πηγή χρησιμοποιεί το [IColorFormat::set_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_schemecolor/) για να αναφερθεί στο πρώτο χρώμα έντονης απόχρωσης και προσθέτει αποχρώση μέσω του [IColorOperationCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icoloroperationcollection/add/). Το RGB αντίγραφο χρησιμοποιεί το αποτελεσματικό χρώμα γεμίσματος της πηγής ώστε και τα τρία αρχικά να φαίνονται πανομοιότυπα. Καλώντας το [IColorFormat::set_Color](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_color/) ορίζετε μια σταθερή τιμή RGB και διαγράφετε τυχόν υπάρχουσες μετασχηματίσεις χρώματος.

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(660, 220, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_RoyalBlue());

auto source = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
auto themeCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
auto rgbCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

for (auto shape : { source, themeCopy, rgbCopy })
{
    shape->get_FillFormat()->set_FillType(FillType::Solid);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
}

auto sourceColor = source->get_FillFormat()->get_SolidFillColor();
sourceColor->set_SchemeColor(SchemeColor::Accent1);
sourceColor->get_ColorTransform()->Add(ColorTransformOperation::Tint, 0.75f);

themeCopy->get_FillFormat()->get_SolidFillColor()->CopyFrom(sourceColor);
auto effectiveFill = source->get_FillFormat()->GetEffective();
rgbCopy->get_FillFormat()->get_SolidFillColor()->set_Color(effectiveFill->get_SolidFillColor());

auto before = slide->GetImage(1.0f, 1.0f);
before->Save(u"color-copy-before.png", ImageFormat::Png);
before->Dispose();

// Οι αναφορές θέματος ακολουθούν το νέο χρώμα έντονης απόχρωσης· η σταθερή τιμή RGB δεν το ακολουθεί.
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_OrangeRed());

auto after = slide->GetImage(1.0f, 1.0f);
after->Save(u"color-copy-after.png", ImageFormat::Png);
after->Dispose();
presentation->Save(u"copied_colors.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Πριν από την αλλαγή θέματος, όλα τα τρία γεμίσματα ταιριάζουν:

![Πηγή, προορισμός CopyFrom και σταθερός RGB προορισμός με πανομοιότυπες μπλε γεμίσεις](color-copy-before.png)

Μετά την αλλαγή θέματος, η πηγή και το αντίγραφο που σέβεται το θέμα ακολουθούν το νέο χρώμα έντονης απόχρωσης και διατηρούν την αποχρώση τους. Το σταθερό RGB αντίγραφο παραμένει μπλε:

![Πηγή και προορισμός CopyFrom με πορτοκαλί γεμίσεις, ενώ ο σταθερός RGB προορισμός παραμένει μπλε](color-copy-after.png)

Ο αντίγραφος ορισμός είναι ανεξάρτητος από την πηγή. Η μεταγενέστερη αλλαγή της αναφοράς θέματος της πηγής, η ανάθεση άλλου χρώματος ή η προσθήκη/αφαίρεση των μετασχηματισμών της δεν επηρεάζει τον προορισμό. Μια αλλαγή θέματος εξακολουθεί να επηρεάζει και τα δύο σχήματα επειδή κάθε ένα αναφέρεται ανεξάρτητα στο ίδιο χρώμα θέματος.

Η αποθήκευση και επαναφόρτωση του PPTX διατηρεί τον τύπο του αντιγραμμένου χρώματος, διαθέσιμο μέσω του [IColorFormat::get_ColorType](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortype/), την αναφορά θέματος και τη συλλογή μετασχηματισμών που επιστρέφει το [IColorFormat::get_ColorTransform](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortransform/); δεν μετατρέπει τον ορισμό σε RGB.

Κατά την αντιγραφή μεταξύ διαφορετικών συμφραζομένων θέματος, όπως παρουσιάσεις με διαφορετικές παλέτες έντονων χρωμάτων, η αντιγραμμένη αναφορά επιλύεται βάσει του θέματος προορισμού. Η ίδια αναφορά και οι μετασχηματισμοί μπορούν έτσι να παράγουν διαφορετικό ορατό χρώμα. Δείτε το [Θέμα Παρουσίασης](/slides/el/cpp/presentation-theme/) για περισσότερα σχετικά με τη ρύθμιση χρωμάτων θέματος.

## **Χρήση Φόντου Διαφάνειας ως Γέμισμα Σχήματος**

Χρησιμοποιήστε το [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/) όταν ένα σχήμα πρέπει να ταιριάζει με το φόντο της διαφάνειας, π.χ. σε ένα πρότυπο παρουσίασης. Ορίστε το [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) σε [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) πρώτα για να αφαιρέσετε οποιοδήποτε ρητό γέμισμα. Με αυτόν τον συνδυασμό, το σχήμα χρησιμοποιεί το φόντο της διαφάνειας αντί για το στυλ γέμισμα του. Η ενεργοποίηση της σημαίας από μόνη της δεν αφαιρεί ένα υπάρχον ρητό γέμισμα.

Αυτό διαφέρει από το [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/): το φόντο γεμίζει τα αντικείμενα πίσω από το σχήμα με την αντίστοιχη περιοχή του φόντου της διαφάνειας, ενώ το χωρίς γέμισμα αφήνει αυτά τα αντικείμενα ορατά. Μια διαβάθμιση παραμένει ευθυγραμμισμένη με τη διαφάνεια αντί να ξεκινά ξανά μέσα σε κάθε σχήμα.

Το παρακάτω παράδειγμα δημιουργεί ένα κύριο φόντο που κληρονομείται από τη διαφάνεια και τοποθετεί μια ματζέντα λουρίδα πίσω από τρία ορθογώνια. Το αριστερό ορθογώνιο χρησιμοποιεί το φόντο, το μεσαίο δεν έχει γέμισμα, και το δεξί εναλλάσσει από γέμισμα φόντου σε ρητό πορτοκαλί γέμισμα.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

// Κληρονομεί τη διαβάθμιση από το κύριο πρότυπο.
slide->get_Background()->set_Type(BackgroundType::NotDefined);
slide->get_LayoutSlide()->get_Background()->set_Type(BackgroundType::NotDefined);
auto background = slide->get_LayoutSlide()->get_MasterSlide()->get_Background();
background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Gradient);
auto gradient = background->get_FillFormat()->get_GradientFormat();
gradient->set_GradientShape(GradientShape::Linear);
gradient->set_LinearGradientAngle(0);
gradient->get_GradientStops()->Clear();
gradient->get_GradientStops()->Add(0, Color::get_DarkBlue());
gradient->get_GradientStops()->Add(1, Color::get_LightSkyBlue());

// Προσθέστε αυτό το αντικείμενο πρώτα ώστε να εμφανίζεται πίσω από τα ορθογώνια.
auto band = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Magenta());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto backgroundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
backgroundShape->get_FillFormat()->set_FillType(FillType::NotDefined);
backgroundShape->set_UseBackgroundFill(true);

auto noFillShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
noFillShape->get_FillFormat()->set_FillType(FillType::NoFill);

auto explicitShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
explicitShape->get_FillFormat()->set_FillType(FillType::NotDefined);
explicitShape->set_UseBackgroundFill(true);

// Απενεργοποιήστε τη συμπλήρωση φόντου πριν εφαρμόσετε μια ρητή συμπλήρωση.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα, από αριστερά προς τα δεξιά: **γέμισμα φόντου**, **χωρίς γέμισμα**, and **συγκεκριμένο γέμισμα**. Η λουρίδα ματζέντα κρύβεται από τα αριστερά και δεξιά ορθογώνια αλλά παραμένει ορατή μέσω του μεσαίου ορθογωνίου.

![Γέμισμα φόντου, χωρίς γέμισμα και ρητό πορτοκαλί γέμισμα πάνω από μια λουρίδα ματζέντα](background-fill.png)

Η ίδια συμπεριφορά ισχύει για φόντο που ορίζεται άμεσα στη διαφάνεια ή κληρονομείται από μια διάταξη. Το σχήμα χρησιμοποιεί το επεξεργασμένο φόντο της διαφάνειας· το παράδειγμα αφήνει τόσο το φόντο της διαφάνειας όσο και της διάταξης ακαθόριστα ώστε ο κύριος να το παρέχει.

## **Ορισμός Διαφάνειας**

Για ένα στερεό γέμισμα, το αλφα-συστατικό του χρώματος ελέγχει την αδιαφάνεια: 0 είναι πλήρως διαφανές και 255 πλήρως αδιαφανές. Αυτό το παράδειγμα χρησιμοποιεί τιμή αλφα 128 για ένα κίτρινο ορθογώνιο, κάνοντάς το περίπου 50 % διαφανές ώστε το ορθογώνιο από κάτω να παραμένει ορατό. Το χρώμα ανατίθεται μέσω του [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/).

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const int alpha = 128;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, Color::get_Yellow()));

presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το διαφανές σχήμα](shape-transparency.png)

## **Περιστροφή Σχημάτων**

Χρησιμοποιήστε το [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) για να περιστρέψετε ένα σχήμα στο επίπεδο της διαφάνειας. Η γωνία μετράται σε μοίρες· αυτό το παράδειγμα περιστρέφει ένα ορθογώνιο κατά 5 μοίρες δεξιόστροφα και αποθηκεύει την παρουσίαση.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 5

0, 150, 75);
shape->set_Rotation(5);

presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Η περιστροφή του σχήματος](shape-rotation.png)

## **Προσθήκη 3Δ Εφέ Πυραμίδας**

Χρησιμοποιήστε το [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) για να δώσετε σε ένα σχήμα βάθος και ακμές με πίεση. Αυτό το παράδειγμα δημιουργεί μια πράσινη έλλειψη με πορτοκαλί περίγραμμα, ορίζει το [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) στα 4 σημεία και εφαρμόζει μία κυκλική επάν ω πεπίδα με πλάτος και ύψος 6 σημείων μέσω του [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/). Μια προμετωπική ορθογραφική κάμερα και τριών σημείων φωτισμός καθιστούν την πεπίδα ορατή.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);
shape->get_ThreeDFormat()->set_Depth(4);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το 3D εφέ πυραμίδας](3D-bevel-effect.png)

## **Προσθήκη 3Δ Εφέ Περιστροφής**

Η 3Δ προβολή ενός σχήματος ελέγχεται από τις ρυθμίσεις της κάμερας. Αυτό το παράδειγμα χρησιμοποιεί το [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) με γωνίες πλάτους, μήκους και επανάληψης 40, 35 και 20 μοιρών αντίστοιχα. Επιλέγει μια ισομετρική κάμερα μέσω του [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) και ισορροπημένο φωτισμό μέσω του [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/), στη συνέχεια αποθηκεύει το μορφοποιημένο ορθογώνιο.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
autoShape->get_TextFrame()->set_Text(u"Hello, Aspose!");
autoShape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
autoShape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
autoShape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Το αποτέλεσμα:

![Το 3D εφέ περιστροφής](3D-rotation-effect.png)

## **Έλεγχος Ασπρόμαυρης Απόδοσης για Σχήματα**

Η μέθοδος [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) καθορίζει πώς αποδίδεται ένα μεμονωμένο σχήμα όταν μια παρουσίαση προβολίζεται ή επεξεργάζεται σε ασπρόμαυρη λειτουργία. Δεν ενεργοποιεί την ασπρόμαυρη προβολή από μόνη της και δεν αλλάζει το γέμισμα, τη γραμμή ή άλλες μορφοποιήσεις του σχήματος σε κανονική λειτουργία χρώματος.

Χρησιμοποιήστε μια τιμή από την απαρίθμηση [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) για να επιλέξετε τη ζητούμενη συμπεριφορά. Για παράδειγμα, το `Automatic` επιτρέπει στην εφαρμογή απόδοσης να επιλέξει τη μετατροπή, τα `Gray` και `LightGray` χρησιμοποιούν γκρι χρώματα, το `BlackWhite` χρησιμοποιεί μόνο μαύρο και λευκό, τα `Black` και `White` επιβάλλουν ένα μόνο χρώμα, το `Color` διατηρεί το κανονικό χρώμα, και το `Hidden` παραλείπει το σχήμα σε ασπρόμαυρη λειτουργία. Το `NotDefined` σημαίνει ότι δεν έχει οριστεί λειτουργία σε επίπεδο σχήματος.

Αυτό το παράδειγμα δημιουργεί ένα πορτοκαλί ορθογώνιο και ορίζει το [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) σε γκρι. Το αποθηκευμένο σχήμα διατηρεί το πορτοκαλί γέμισμα για κανονική προβολή χρώματος και ζητά γκρι απόχρωση από εφαρμογές που σέβονται τις ρυθμίσεις ασπρόμαυρης προβολής:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Σε κανονική λειτουργία χρώματος, το ορθογώνιο διατηρεί το πορτοκαλί γέμισμα. Σε μια ροή εργασίας ασπρόμαυρης προβολής, χρησιμοποιεί γκρι χρώμα επειδή η λειτουργία του είναι ορισμένη σε `Gray`. Αυτό σας επιτρέπει να διατηρήσετε μια πλήρους χρώματος διαφάνεια ενώ ορίζετε διαφορετική εμφάνιση για εκτύπωση, προεπισκόπηση ή άλλες ροές εργασίας που σέβονται τις ρυθμίσεις ασπρόμαυρης προβολής της παρουσίασης.

## **Επαναφορά Μορφοποίησης**

Χρησιμοποιήστε το [ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/) για να επαναφέρετε τη θέση, το μέγεθος και τη μορφοποίηση των θέσεων κράτησης διαφάνειας από τις αντίστοιχες θέσεις κράτησης διάταξης. Αυτό το παράδειγμα απαιτεί μια υπάρχουσα παρουσίαση με θέσεις κράτησης συνδεδεμένες με διάταξη και επαναφέρει κάθε διαφάνεια πριν την αποθήκευση. Τα σχήματα χωρίς αντίστοιχη θέση κράτησης διάταξης δεν επαναφέρονται.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Συχνές Ερωτήσεις**

**Επηρεάζει η μορφοποίηση σχήματος το τελικό μέγεθος του αρχείου παρουσίασης;**

Τα χρώματα, τα στυλ γραμμής και οι ρυθμίσεις εφέ προσθέτουν γενικά λίγα δεδομένα σε σύγκριση με ενσωματωμένες εικόνες και πολυμέσα. Τα γεμίσματα εικόνας μπορούν να αυξήσουν το μέγεθος του αρχείου επειδή οι εικόνες τους αποθηκεύονται στην παρουσίαση.

**Πώς μπορώ να εντοπίσω σχήματα σε μια διαφάνεια που μοιράζονται την ίδια μορφοποίηση ώστε να τα ομαδοποιήσω;**

Συγκρίνετε τις βασικές ιδιότητες μορφοποίησης κάθε σχήματος —γέμισμα, γραμμή και ρυθμίσεις εφέ. Εάν όλες οι αντίστοιχες τιμές ταιριάζουν, θεωρήστε τα στυλ τους ως πανομοιότυπα και ομαδοποιήστε λογικά αυτά τα σχήματα, κάτι που απλοποιεί τη διαχείριση στυλ αργότερα.

**Μπορώ να αποθηκεύσω ένα σύνολο προσαρμοσμένων στυλ σχήματος σε ξεχωριστό αρχείο για επαναχρησιμοποίηση σε άλλες παρουσιάσεις;**

Ναι. Αποθηκεύστε δείγματα σχημάτων με τα επιθυμητά στυλ σε ένα πρότυπο παρουσίασης ή σε αρχείο προτύπου .POTX. Όταν δημιουργείτε μια νέα παρουσίαση, ανοίξτε το πρότυπο, κλωνοποιήστε τα στυλσχημα που χρειάζεστε και επαναεφαρμόστε τη μορφοποίηση όπου απαιτείται.