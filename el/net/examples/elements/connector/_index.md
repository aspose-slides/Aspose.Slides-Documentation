---
title: Σύνδεσμος
type: docs
weight: 190
url: /el/net/examples/elements/connector/
keywords:
- σύνδεσμος
- προσθήκη σύνδεσμου
- πρόσβαση σε σύνδεσμο
- αφαίρεση σύνδεσμου
- επανασύνδεση σχημάτων
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, να δρομολογείτε και να μορφοποιείτε συνδέσμους μεταξύ σχημάτων χρησιμοποιώντας το Aspose.Slides για .NET, με παραδείγματα C# για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να συνδέετε σχήματα με συνδέσμους και να αλλάζετε τους στόχους τους χρησιμοποιώντας **Aspose.Slides for .NET**.

## **Προσθήκη Συνδέσμου**

Εισάγετε ένα σχήμα συνδέσμου μεταξύ δύο σημείων στη διαφάνεια.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Πρόσβαση σε Συνδέσμο**

Ανακτήστε το πρώτο σχήμα συνδέσμου που προστέθηκε σε μια διαφάνεια.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Αφαίρεση Συνδέσμου**

Διαγράψτε έναν σύνδεσμο από τη διαφάνεια.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Επανασύνδεση Σχημάτων**

Συνδέστε έναν σύνδεσμο με δύο σχήματα ορίζοντας τις αρχικές και τελικές στόχους.

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```