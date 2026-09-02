---
title: Απόδοση διαφανειών παρουσίασης ως εικόνες SVG σε C++
linktitle: Διαφάνεια σε SVG
type: docs
weight: 50
url: /el/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint σε SVG
- παρουσίαση σε SVG
- διαφάνεια σε SVG
- PPT σε SVG
- PPTX σε SVG
- επιλογές εξαγωγής SVG
- διαδραστικό SVG
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Εξαγωγή διαφανειών PowerPoint ως εικόνες SVG σε C++ και έλεγχος γραμματοσειρών, κειμένου, εικόνων, αναγνωριστικών και συμβάντων με το Aspose.Slides."
---
## **Επισκόπηση**

Το SVG είναι μια κλιμακώσιμη μορφή εικόνας βασισμένη σε XML που λειτουργεί καλά για δημοσίευση στο web, προβολείς διαφανειών, διαδικασίες προσβασιμότητας και αυτοματοποιημένη μετα-επεξεργασία. Το Aspose.Slides for C++ εξάγει κάθε διαφάνεια σε ξεχωριστό αρχείο SVG και σας επιτρέπει να ελέγξετε πώς γράφονται το κείμενο, οι γραμματοσειρές, οι εικόνες και τα στοιχεία SVG.

Χρησιμοποιήστε το [SVGOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/) όταν το εξαγόμενο SVG πρέπει να είναι συμπαγές, προβλέψιμο σε διαφορετικά προγράμματα περιήγησης ή έτοιμο για διαδραστική χρήση.

## **Εξαγωγή μιας διαφάνειας ως SVG**

Δημιουργήστε ένα [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/), επιλέξτε μια διαφάνεια και γράψτε την σε ένα stream. Το παρακάτω παράδειγμα εξάγει κάθε διαφάνεια μιας παρουσίασης σε ξεχωριστό αρχείο SVG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

Το όνομα αρχείου χρησιμοποιεί το [ISlide::get_SlideNumber](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/get_slidenumber/) αντί για τον δείκτη του βρόχου. Μπορείτε επίσης να εξάγετε ένα μεμονωμένο σχήμα με το [IShape::WriteAsSvg](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/writeassvg/) όταν ένας προβολέας διαφανειών ή μια ιστοσελίδα χρειάζονται μόνο αυτό το σχήμα.

## **Διαμόρφωση εξόδου SVG**

Το [SVGOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/) ελέγχει την απόδοση του SVG. Για πλαίσια κειμένου, το [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/set_useframesize/) περιλαμβάνει το πλαίσιο κειμένου στην περιοχή απόδοσης, και το [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/set_useframerotation/) καθορίζει αν εφαρμόζεται η περιστροφή του πλαισίου. Ορίστε το [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) σε `true` όταν το κείμενο πρέπει να αποδοθεί χωρίς συνδέσμους γραμμάτων.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Έλεγχος κειμένου και γραμματοσειρών**

### **Διάνυσμα όλου του κειμένου**

Ορίστε το [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) σε `true` για να γράψετε όλο το κείμενο της διαφάνειας ως διανυσματικά γραφικά. Αυτό αφαιρεί τις εξαρτήσεις από τις γραμματοσειρές και κάνει το οπτικό αποτέλεσμα πιο συνεπές μεταξύ των προγραμμάτων περιήγησης, αλλά το κείμενο δεν είναι πλέον επιλέξιμο ή αναζητήσιμο ως κείμενο SVG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **Επιλέξτε πώς θα διαχειρίζονται οι εξωτερικές γραμματοσειρές**

Το [SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) χρησιμοποιεί μια τιμή του [SvgExternalFontsHandling](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgexternalfontshandling/) για τις γραμματοσειρές που φορτώνονται εξωτερικά. Επιλέξτε `AddLinksToFontFiles` για να αναφέρετε ξεχωριστά αρχεία γραμματοσειρών, `Embed` για να ενσωματώσετε τα δεδομένα της γραμματοσειράς στο SVG, ή `Vectorize` για να αποδώσετε μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές ως γραφικά. Επαληθεύστε την άδεια χρήσης της γραμματοσειράς πριν την ενσωμάτωση.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **Μείωση μεγέθους ενσωματωμένων εικόνων**

Χρησιμοποιήστε το [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/set_picturescompression/) για να μειώσετε την ανάλυση των ενσωματωμένων εικόνων, το [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) για να παραλείψετε τα περικομμένα τμήματα προέλευσης, και το [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/set_jpegquality/) για να ελέγξετε την ποιότητα κωδικοποίησης JPEG. Αυτές οι ρυθμίσεις μειώνουν το μέγεθος του αρχείου με κόστος στην πιστότητα της εικόνας ή στα διατηρημένα δεδομένα εικόνας.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Ανάθεση σταθερών αναγνωριστικών σε σχήματα και κείμενο**

Χρησιμοποιήστε το [ISvgShapeFormattingController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/isvgshapeformattingcontroller/) για να ορίσετε το [ISvgShape::set_Id](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/isvgshape/set_id/) για κάθε σχήμα SVG. Για να ορίσετε τιμές [ISvgTSpan::set_Id](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/isvgtspan/set_id/) στα στοιχεία `tspan` του κειμένου, υλοποιήστε το [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Αναθέστε κάποιον από τους ελεγκτές με το [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Ο παρακάτω ελεγκτής χρησιμοποιεί το [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_officeinteropshapeid/), το οποίο είναι σταθερό κατά τη διάρκεια ζωής του σχήματος, και έναν επαναλαμβανόμενο μετρητή για τα τμήματα κειμένου του. Αυτό καθιστά τα παραγόμενα αναγνωριστικά κατάλληλα για μετα-επεξεργασία μιας αμετάβλητης παρουσίασης.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Προσθήκη χειριστών συμβάντων SVG**

Σε ένα [ISvgShapeFormattingController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/isvgshapeformattingcontroller/), καλέστε το [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/isvgshape/seteventhandler/) με μία τιμή [SvgEvent](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgevent/) για να προσθέσετε έναν χειριστή συμβάντος JavaScript σε ένα εξαχθέν σχήμα. Αναθέστε τον ελεγκτή με το [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) και ορίστε τη λειτουργία JavaScript στη σελίδα ή το έγγραφο SVG που φιλοξενεί το αποτέλεσμα.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

Η σελίδα φιλοξενίας μπορεί να ορίσει τη λειτουργία JavaScript που αναφέρεται από το χειριστή. Η ανάθεση αναγνωριστικών και χειριστών συμβάντων ενεργοποιεί τους προβολείς διαφανειών, βελτιώσεις προσβασιμότητας και άλλες διαδραστικές ροές εργασίας SVG.

## **Συχνές ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το SVGOptions::set_VectorizeText αντί για το SvgExternalFontsHandling::Vectorize;**

Χρησιμοποιήστε το SVGOptions::set_VectorizeText όταν όλο το κείμενο πρέπει να είναι ανεξάρτητο από τις γραμματοσειρές. Χρησιμοποιήστε το SvgExternalFontsHandling::Vectorize όταν μόνο το κείμενο που χρησιμοποιεί εξωτερικές γραμματοσειρές πρέπει να μετατραπεί σε γραφικά.

**Ποιος είναι ο καλύτερος τρόπος για να μικρύνετε ένα SVG;**

Ξεκινήστε με τη συμπίεση των ενσωματωμένων εικόνων, τη διαγραφή των περικομμένων τμημάτων εικόνας και την επιλογή συνδεδεμένων αρχείων γραμματοσειρών όταν το περιβάλλον‑στόχος μπορεί να τα εξυπηρετήσει. Δοκιμάστε το αποτέλεσμα, επειδή η χαμηλότερη ανάλυση εικόνας, η χαμηλότερη ποιότητα JPEG και το διάνυσμα κειμένου έχουν διαφορετικές ανταλλαγές ποιότητας και μεγέθους.

**Μπορώ να τροποποιήσω τα εξαγόμενα στοιχεία SVG μετά την εξαγωγή;**

Ναι. Αναθέστε αναγνωριστικά μέσω ενός ελεγκτή μορφοποίησης, έπειτα επιλέξτε τα αντίστοιχα στοιχεία SVG στο εργαλείο μετα‑επεξεργασίας ή στο σκριπτ του προγράμματος περιήγησης.