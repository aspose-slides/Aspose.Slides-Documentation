---
title: Διαχείριση Placeholder Παρουσίασης σε C++
linktitle: Διαχείριση Placeholder
type: docs
weight: 10
url: /el/cpp/manage-placeholder/
keywords:
- σύμβολο κράτησης
- σύμβολο κράτησης κειμένου
- σύμβολο κράτησης εικόνας
- σύμβολο κράτησης διαγράμματος
- σύμβολο κράτησης περιεχομένου
- κείμενο προτροπής
- PowerPoint
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να εξετάζετε και να επεξεργάζεστε συμβόλα κράτησης κειμένου, εικόνας, διαγράμματος και περιεχομένου και να κατανοείτε την κληρονομικότητα των συμβόλων κράτησης με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Ένα placeholder είναι ένα σχήμα που διατηρεί μια θέση για ένα συγκεκριμένο είδος περιεχομένου σε ένα πρότυπο παρουσίασης. Συνηθισμένα παραδείγματα είναι placeholders τίτλου, σώματος, εικόνας, διαγράμματος και γενικού σκοπού. Σε αντίθεση με ένα συνηθισμένο σχήμα, ένα placeholder μπορεί να κληρονομήσει τη θέση, το μέγεθος, τη μορφοποίηση και άλλες ρυθμίσεις από μια διαφάνεια διάταξης ή κύρια διαφάνεια.

Aspose.Slides εκθέτει πληροφορίες placeholder μέσω της μεθόδου [IShape::get_Placeholder](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_placeholder/). Η μέθοδος επιστρέφει ένα αντικείμενο [IPlaceholder](https://reference.aspose.com/slides/el/cpp/aspose.slides/iplaceholder/) ή `nullptr` για ένα κανονικό σχήμα. Χρησιμοποιήστε το [IPlaceholder::get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/iplaceholder/get_type/) για να προσδιορίσετε τι προορίζεται να περιέχει το placeholder.

Η διεπαφή του σχήματος εξακολουθεί να είναι σημαντική αφού μάθετε τον τύπο του placeholder:

- Ένα κενό placeholder κειμένου, εικόνας, διαγράμματος ή περιεχομένου αντιπροσωπεύεται συνήθως από ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/).
- Ένα συμπληρωμένο placeholder εικόνας μπορεί να αντιπροσωπεύεται από ένα [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/).
- Ένα συμπληρωμένο placeholder διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [IChart](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/).
- Ένα placeholder περιεχομένου μπορεί να περιέχει πολλαπλούς τύπους περιεχομένου. Ελέγξτε τόσο το [IPlaceholder::get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/iplaceholder/get_type/) όσο και τη διεπαφή του σχήματος κατά χρόνο εκτέλεσης αντί να υποθέτετε ότι κάθε placeholder είναι ένα [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/iplaceholder/get_type/) περιγράφει τον ρόλο ενός placeholder· δεν εγγυάται τον τύπο του σχήματος κατά χρόνο εκτέλεσης. Πάντα να κάνετε έλεγχο τύπου πριν αποκτήσετε πρόσβαση σε μέλη κειμένου, εικόνας, διαγράμματος, πίνακα ή μέσων.
{{% /alert %}}

## **Κατανόηση Κληρονομικότητας Placeholder**

Τα placeholders σχηματίζουν μια ιεραρχία:

1. Μια κύρια διαφάνεια ορίζει επαναχρησιμοποιήσιμα στυλ και, σε ορισμένες περιπτώσεις, placeholders επιπέδου master.
2. Μια διαφάνεια διάταξης ορίζει τη διάταξη που χρησιμοποιείται από μία ή περισσότερες κανονικές διαφάνειες και μπορεί να κληρονομήσει από το master.
3. Μια κανονική διαφάνεια περιέχει τα placeholders για εκείνη τη διαφάνεια και μπορεί να κληρονομήσει από τη διάταξή της.

Καλέστε το [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/getbaseplaceholder/) για να μεταβείτε ένα επίπεδο επάνω σε αυτήν την ιεραρχία. Ένα placeholder διαφάνειας συνήθως επιστρέφει το placeholder της διάταξής του· ένα placeholder διάταξης μπορεί να επιστρέψει το placeholder του master. Η μέθοδος επιστρέφει `nullptr` όταν το σχήμα δεν έχει βασικό placeholder.

Το παρακάτω παράδειγμα παραθέτει τα placeholders στην πρώτη διαφάνεια και αναφέρει τα βασικά τους placeholders:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Η επεξεργασία ενός placeholder σε μια κανονική διαφάνεια δημιουργεί ή αλλάζει μια τοπική παράκαμψη για εκείνη τη διαφάνεια. Η επεξεργασία της σχετικής διάταξης ή του master μπορεί να επηρεάσει όλες τις διαφάνειες που εξακολουθούν να κληρονομούν αυτή τη ρύθμιση. Ένα τοπικό συνηθισμένο σχήμα δεν έχει βασικό placeholder και δεν αρχίζει να κληρονομεί απλώς επειδή καταλαμβάνει τις ίδιες συντεταγμένες.

## **Αλλαγή Κειμένου σε Placeholder**

Τα placeholders τίτλου, κεντραρισμένου τίτλου, υπότιτλου, σώματος και κειμένου υποστηρίζουν συνήθως κείμενο. Ελέγξτε για [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) πριν χρησιμοποιήσετε τη μέθοδό του [get_TextFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/get_textframe/).

Αυτό το παράδειγμα ενημερώνει το πρώτο placeholder τίτλου στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Αυτό το μοτίβο αποφεύγει το casting τους placeholders εικόνας, διαγράμματος, πίνακα ή μέσων σε [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/). Επιπλέον, αναγνωρίζει το placeholder με βάση τον σκοπό του αντί να εξαρτάται από έναν εύθραυστο δείκτη σχήματος.

## **Ορισμός Κειμένου Προτροπής σε Διάταξη**

Το κείμενο προτροπής είναι η οδηγία σχεδιασμού που εμφανίζεται σε ένα κενό placeholder, όπως *Click to add title*. Ορίστε προσαρμοσμένο κείμενο προτροπής στο placeholder της διάταξης αντί να προσπαθήσετε να το προσεγγίσετε μέσω της συλλογής σ shapes μιας κανονικής διαφάνειας. Πρόσβαση στη διάταξη μέσω του [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/el/cpp/aspose.slides/islide/get_layoutslide/) και επανάληψη πάνω στα [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/el/cpp/aspose.slides/ibaseslide/get_shapes/).

Το παρακάτω παράδειγμα αλλάζει τις προτροπές τίτλου και υπότιτλου στη διάταξη που χρησιμοποιείται από την πρώτη διαφάνεια:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

Το κείμενο προτροπής δεν είναι κανονικό περιεχόμενο διαφάνειας. Προορίζεται για κενά placeholders σε εφαρμογές επεξεργασίας όπως το PowerPoint. Μόλις ένας χρήστης ή πρόγραμμα παρέχει πραγματικό περιεχόμενο, η προτροπή δεν εμφανίζεται πλέον. Η αλλαγή μιας προτροπής επίσης δεν αντικαθιστά υπάρχον κείμενο στις διαφάνειες που χρησιμοποιούν τη διάταξη.

## **Ενημέρωση Placeholder Εικόνας**

Υπάρχουν δύο περιπτώσεις που πρέπει να διαχειριστείτε:

- Αν το placeholder εικόνας είναι ήδη συμπληρωμένο και αντιπροσωπεύεται από ένα [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/), αντικαταστήστε την εικόνα μέσω του [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipicturefillformat/get_picture/) και του [ISlidesPicture::set_Image](https://reference.aspose.com/slides/el/cpp/aspose.slides/islidespicture/set_image/).
- Αν παραμένει κενό placeholder, προσθέστε ένα πλαίσιο εικόνας στις συντεταγμένες του placeholder με το [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishapecollection/addpictureframe/) και αφαιρέστε το κενό placeholder.

Το επόμενο παράδειγμα υποστηρίζει και τις δύο περιπτώσεις και αποθηκεύει την παρουσίαση:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

Η αντικατάσταση που δημιουργείται για ένα κενό placeholder είναι ένα τοπικό πλαίσιο εικόνας, όχι ένα νέο placeholder, επειδή το [IShape::get_Placeholder](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/get_placeholder/) είναι μόνο για ανάγνωση. Διατηρεί τη δεσμευμένη θέση αλλά δεν κληρονομεί πλέον τη συμπεριφορά συγκεκριμένης placeholder. Εάν η διατήρηση της σχέσης placeholder είναι ουσιώδης, προετοιμάστε και συμπληρώστε το placeholder στο PowerPoint πρώτα, έπειτα ενημερώστε το προκύπτον [IPictureFrame](https://reference.aspose.com/slides/el/cpp/aspose.slides/ipictureframe/) με το Aspose.Slides.

Για διαφάνεια εικόνας, περικοπή και άλλα εφέ ειδικά για εικόνες, δείτε το άρθρο [Manage Picture Frames](/slides/el/cpp/picture-frame/). Αυτές οι λειτουργίες ανήκουν στο πλαίσιο εικόνας ή στο γέμισμα εικόνας, όχι στα μεταδεδομένα του placeholder.

## **Διαχείριση Συμπληρωμάτων Διαγράμματος και Περιεχομένου**

Ένα συμπληρωμένο placeholder διαγράμματος μπορεί να αντιπροσωπεύεται από ένα [IChart](https://reference.aspose.com/slides/el/cpp/aspose.slides.charts/ichart/). Το παράδειγμα αυτό βρίσκει ένα τέτοιο διάγραμμα τόσο με βάση τον τύπο του placeholder όσο και τη διεπαφή χρόνου εκτέλεσης, αλλάζει τον τίτλο του και αποθηκεύει το αρχείο:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Ένα γενικό placeholder περιεχομένου έχει συνήθως τον τύπο [PlaceholderType::Object](https://reference.aspose.com/slides/el/cpp/aspose.slides/placeholdertype/). Στο PowerPoint λειτουργεί ως εκκινητής για πολλούς τύπους περιεχομένου, όπως διαγράμματα, πίνακες, διαγράμματα ροής, εικόνες και μέσα. Αφού συμπληρωθεί, εξετάστε την πραγματική διεπαφή σχήματος για να μάθετε τι περιέχει. Εξειδικευμένες διατάξεις μπορούν επίσης να εκθέτουν [PlaceholderType::Chart](https://reference.aspose.com/slides/el/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/el/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/el/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/el/cpp/aspose.slides/placeholdertype/), ή [PlaceholderType::Diagram](https://reference.aspose.com/slides/el/cpp/aspose.slides/placeholdertype/).

Το Aspose.Slides δεν μετατρέπει ένα κενό placeholder [IAutoShape](https://reference.aspose.com/slides/el/cpp/aspose.slides/iautoshape/) σε [IChart] μόνο αλλάζοντας το [IPlaceholder::get_Type](https://reference.aspose.com/slides/el/cpp/aspose.slides/iplaceholder/get_type/); ο τύπος είναι μόνο για ανάγνωση. Για να γεμίσετε προγραμματιστικά ένα κενό διάγραμμα ή περιοχή περιεχομένου, προσθέστε το απαιτούμενο αντικείμενο στις συντεταγμένες του placeholder και στη συνέχεια αφαιρέστε το κενό placeholder. Το παρακάτω παράδειγμα το κάνει αυτό για ένα διάγραμμα:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

Το προστιθέμενο διάγραμμα είναι ένα συνηθισμένο τοπικό διάγραμμα. Καταλαμβάνει την περιοχή του placeholder αλλά δεν κληρονομεί από το placeholder της διάταξης. Χρησιμοποιήστε τα ειδικά άρθρα διαχείρισης διαγραμμάτων [chart management articles](/slides/el/cpp/powerpoint-charts/) όταν χρειάζεται να αντικαταστήσετε τις κατηγορίες, τις σειρές ή τα δεδομένα του βιβλίου εργασίας.

## **Πλήρες Παράδειγμα: Ενημέρωση Κειμένου ή Περιεχομένου Εικόνας**

Το παρακάτω ολοκληρωμένο παράδειγμα ανοίγει ένα πρότυπο, ψάχνει την πρώτη διαφάνεια για placeholder τίτλου ή εικόνας, ελέγχει τους τύπους του placeholder και του σχήματος, ενημερώνει το αντίστοιχο περιεχόμενο και αποθηκεύει το αποτέλεσμα. Το παράδειγμα αποφεύγει σκόπιμα την υπόθεση δείκτη σχήματος ή το casting όλων των placeholders στην ίδια διεπαφή.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Τι είναι ένα βασικό placeholder;**

Ένα βασικό placeholder είναι το αντίστοιχο σχήμα στη διάταξη ή στο master από το οποίο κληρονομεί ένα άλλο placeholder. Χρησιμοποιήστε το [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/el/cpp/aspose.slides/ishape/getbaseplaceholder/) για να το ανακτήσετε. Ένα συνηθισμένο τοπικό σχήμα επιστρέφει `nullptr` επειδή δεν αποτελεί μέρος της ιεραρχίας placeholder.

**Μπορώ να αλλάξω όλους τους τίτλους διαφάνειας επεξεργάζοντας ένα placeholder διάταξης;**

Μπορείτε να αλλάξετε την κληρονομική μορφοποίηση ή το κείμενο προτροπής μέσω μιας διάταξης, αλλά το υπάρχον κείμενο τίτλου αποθηκεύεται στις κανονικές διαφάνειες. Για να αντικαταστήσετε τον πραγματικό τίτλο σε όλη την παρουσίαση, επαναλάβετε τις διαφάνειες και ενημερώστε κάθε placeholder τίτλου.

**Πώς διαχειρίζομαι placeholders ημερομηνίας, αριθμού διαφάνειας, κεφαλίδας και υποσέλιδου;**

Χρησιμοποιήστε τους διαχειριστές κεφαλίδας και υποσέλιδου στην κατάλληλη κλίμακα (διαφάνεια, διάταξη, master, σημειώσεις ή φυλλάδιο). Δείτε το άρθρο [Manage Presentation Header and Footer](/slides/el/cpp/presentation-header-and-footer/) για ολοκληρωμένα παραδείγματα.