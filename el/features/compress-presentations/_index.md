---
title: Συμπίεση παρουσιάσεων
description: Μειώστε το μέγεθος της παρουσίασης με συμπίεση εικόνας και αποθηκεύστε ρυθμίσεις.
type: docs
url: /el/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: λειτουργίες
translationKey: slides-feature-συμπίεση-παρουσιάσεων
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Επισκόπηση**

Συμπιέστε εικόνες, αφαιρέστε περιοχές εικόνας που έχουν περικοπεί όταν δεν χρειάζονται πλέον, και επιλέξτε ρυθμίσεις συμπίεσης παρουσίασης πριν την αποθήκευση. Αυτό είναι χρήσιμο για παρουσιάσεις με μεγάλες φωτογραφίες ή επαναλαμβανόμενο μέσο. Το ποσό που εξοικονομείται εξαρτάται από το περιεχόμενο και τις ρυθμίσεις που επιλέγετε.

## **Παράδειγμα χρήσης**

Αυτό το παράδειγμα C# χρησιμοποιεί το Aspose.Slides for .NET. Δημιουργεί οπτικά ένα gradient PNG 1600 × 900 εικονοστοιχεία, το εισάγει σε ένα μικρό πλαίσιο εικόνας και αποθηκεύει *before.pptx*. Στη συνέχεια συμπιέζει αυτή την εικόνα σε στόχο ανάλυσης 96 DPI και αποθηκεύει *compressed.pptx*. Συγκρίνετε τα μεγέθη αρχείων και τις προεπισκοπήσεις: η εξοικονόμηση εξαρτάται από την είσοδο εικόνας και το εμφανιζόμενο μέγεθος.

Για τη ρύθμιση, δείτε [Εγκατάσταση Aspose.Slides for .NET](/slides/el/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **Συχνές Ερωτήσεις**

### **Είναι αυτό ένας μοναδικός διακόπτης βελτιστοποίησης ολόκληρου αρχείου;**

Το Aspose.Slides for .NET 26.11 προσθέτει το [Compress.CompressPresentation](/slides/el/net/low-code-presentation-operations/#compress-the-whole-presentation), το οποίο συνδυάζει την αφαίρεση αχρησιμοποίητων διάταξης/master, την υποσύνολο των ενσωματωμένων γραμματοσειρών και τη συμπίεση εικόνας στα 150 DPI. Αφαιρεί μόνιμα τις περικομμένες περιοχές εικόνας. Για επεξεργασία μόνο εικόνας, χρησιμοποιήστε το Compress.CompressImages· για πιο λεπτομερή έλεγχο, διατηρήστε τη ροή εργασίας ανά εικόνα παραπάνω. Αυτοί οι νέοι βοηθοί είναι συγκεκριμένοι για την αναφερόμενη έκδοση .NET· ελέγξτε τον αντίστοιχο οδηγό για άλλα SDK.

### **Αλλάζει η συμπίεση εικόνας το επεξεργάσιμο κείμενο ή τα διαγράμματα;**

Η συμπίεση εικόνας στοχεύει στα δεδομένα της εικόνας, όχι στο επεξεργάσιμο κείμενο ή τα δεδομένα των διαγραμμάτων. Εξετάστε τις εικόνες, επειδή η αλλαγή μεγέθους ή η επανσυμπίεση μπορεί να μειώσει τις λεπτομέρειές τους.

### **Πώς πρέπει να επιλέξω ανάλυση για τις εικόνες παρουσίασης;**

Επιλέξτε ένα στόχο βάσει του εμφανιζόμενου μεγέθους εικόνας και της προοριζόμενης χρήσης σε οθόνη ή εκτύπωση. Διατηρήστε μεγαλύτερη ανάλυση για μεγάλες οθόνες, εκτύπωση και λεπτομερή διαγράμματα, και συγκρίνετε το αποτέλεσμα πριν διαγράψετε το αρχικό.

## **Οδηγοί**

- [Βελτιστοποίηση Διαχείρισης Εικόνων σε Παρουσιάσεις στο .NET](/slides/el/net/image/)

Σχετική λειτουργία: [Αφαίρεση αχρησιμοποίητων master, layout και μέσων](/slides/el/features/remove-unused-content/).

## Εκτελέσιμα παραδείγματα .NET

- [Μείωση Μεγέθους Παρουσίασης](/slides/el/net/examples/optimization-batch/compression/)