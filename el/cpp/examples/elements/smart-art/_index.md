---
title: SmartArt
type: docs
weight: 140
url: /el/cpp/examples/elements/smart-art/
keywords:
- παράδειγμα κώδικα
- SmartArt
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εργαστείτε με SmartArt στο Aspose.Slides για C++: δημιουργήστε, επεξεργαστείτε, μετατρέψτε και μορφοποιήστε διαγράμματα με C++ για παρουσιάσεις PowerPoint και OpenDocument."
---
Αυτό το άρθρο δείχνει πώς να προσθέσετε γραφικά SmartArt, να τα προσπελάσετε, να τα αφαιρέσετε και να αλλάξετε διατάξεις χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη SmartArt**

Εισάγετε ένα γράφημα SmartArt χρησιμοποιώντας μία από τις ενσωματωμένες διατάξεις.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Πρόσβαση SmartArt**

Ανακτήστε το πρώτο αντικείμενο SmartArt σε μια διαφάνεια.

```cpp
static void AccessSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    auto firstSmartArt = SharedPtr<ISmartArt>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ISmartArt>(shape))
        {
            firstSmartArt = ExplicitCast<ISmartArt>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Αφαίρεση SmartArt**

Διαγράψτε ένα σχήμα SmartArt από τη διαφάνεια.

```cpp
static void RemoveSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    slide->get_Shapes()->Remove(smartArt);

    presentation->Dispose();
}
```

## **Αλλαγή διάταξης SmartArt**

Ενημερώστε τον τύπο διάταξης ενός υπάρχοντος γραφήματος SmartArt.

```cpp
static void ChangeSmartArtLayout()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicBlockList);
    smartArt->set_Layout(SmartArtLayoutType::VerticalPictureList);

    presentation->Dispose();
}
```