---
title: Εικόνα
type: docs
weight: 50
url: /el/net/examples/elements/picture/
keywords:
- εικόνα
- πλαίσιο εικόνας
- προσθήκη εικόνας
- πρόσβαση σε εικόνα
- παράδειγμα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δουλέψτε με εικόνες στο Aspose.Slides για .NET: εισαγωγή, περικοπή, συμπίεση, επαναχρωματισμό και εξαγωγή εικόνων με παραδείγματα C# για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να εισάγετε και να αποκτήσετε πρόσβαση σε εικόνες από εικόνες στη μνήμη χρησιμοποιώντας **Aspose.Slides for .NET**. Τα παραδείγματα παρακάτω δημιουργούν μια εικόνα στη μνήμη, την τοποθετούν σε μια διαφάνεια και στη συνέχεια την ανακτούν.

## **Προσθήκη εικόνας**

Αυτός ο κώδικας δημιουργεί ένα μικρό bitmap, το μετατρέπει σε ροή και το εισάγει ως πλαίσιο εικόνας στην πρώτη διαφάνεια.

```csharp
public static void AddPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Δημιουργήστε μια απλή εικόνα στη μνήμη.
    using var bitmap = new Bitmap(width: 100, height: 100);
    
    using var graphics = Graphics.FromImage(bitmap);
    graphics.Clear(Color.LightGreen);

    // Μετατρέψτε το bitmap σε MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Προσθέστε την εικόνα στην παρουσίαση.
    var image = presentation.Images.AddImage(imageStream);

    // Εισάγετε ένα πλαίσιο εικόνας που εμφανίζει την εικόνα στην πρώτη διαφάνεια.
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle,
        x: 50, y: 50, width: bitmap.Width, height: bitmap.Height, image);

    presentation.Save("picture.pptx", SaveFormat.Pptx);
}
```

## **Πρόσβαση σε εικόνα**

Αυτό το παράδειγμα διασφαλίζει ότι μια διαφάνεια περιέχει πλαίσιο εικόνας και στη συνέχεια προσπελάζει το πρώτο που βρίσκει.

```csharp
public static void AccessPicture()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Βεβαιωθείτε ότι υπάρχει τουλάχιστον ένα πλαίσιο εικόνας για εργασία.
    using var bitmap = new Bitmap(40, 40);

    // Μετατρέψτε το bitmap σε MemoryStream.
    using var imageStream = new MemoryStream();
    bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
    imageStream.Position = 0;

    // Προσθέστε την εικόνα στην παρουσίαση.
    var image = presentation.Images.AddImage(imageStream);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image);

    // Προσπελάστε το πρώτο πλαίσιο εικόνας στη διαφάνεια.
    var pictureFrame = slide.Shapes.OfType<PictureFrame>().First();
}
```