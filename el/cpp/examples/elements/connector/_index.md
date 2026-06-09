---
title: Σύνδεσμος
type: docs
weight: 190
url: /el/cpp/examples/elements/connector/
keywords:
- παράδειγμα κώδικα
- Σύνδεσμος
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να δρομολογείτε και να μορφοποιείτε συνδέσμους μεταξύ σχημάτων χρησιμοποιώντας Aspose.Slides για C++, με παραδείγματα για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να συνδέετε σχήματα με συνδέσμους και να αλλάζετε τους προορισμούς τους χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη Συνδέσμου**

Εισάγετε ένα σχήμα συνδέσμου μεταξύ δύο σημείων στη διαφάνεια.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Πρόσβαση σε Σύνδεσμο**

Ανακτήστε το πρώτο σχήμα συνδέσμου που προστέθηκε σε μια διαφάνεια.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Πρόσβαση στον πρώτο σύνδεσμο στη διαφάνεια.
    auto connector = SharedPtr<IConnector>();
    for (auto&& shape :  slide->get_Shapes())
    {
        if (ObjectExt::Is<IConnector>(shape))
        {
            connector = ExplicitCast<IConnector>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Κατάργηση Συνδέσμου**

Διαγράψτε έναν σύνδεσμο από τη διαφάνεια.

```cpp
static void RemoveConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    slide->get_Shapes()->Remove(connector);

    presentation->Dispose();
}
```

## **Επανασύνδεση Σχημάτων**

Συνδέστε έναν σύνδεσμο με δύο σχήματα αντιστοιχίζοντας τους αρχικούς και τελικούς προορισμούς.

```cpp
static void ReconnectShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    connector->set_StartShapeConnectedTo(shape1);
    connector->set_EndShapeConnectedTo(shape2);

    presentation->Dispose();
}
```