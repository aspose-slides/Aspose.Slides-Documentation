---
title: Δημόσιο API και Ασυμβίβαστες Αλλαγές Πίσω Συμβατότητας στο Aspose.Slides για .NET 14.9.0
linktitle: Aspose.Slides για .NET 14.9.0
type: docs
weight: 110
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- μετάβαση
- παραδοσιακός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των αλλαγών που διακόπτουν τη συμβατότητα στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασής σας PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}}

Αυτή η σελίδα παραθέτει όλα τα [προστιθέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) ή [αφαιρέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for .NET 14.9.0 API.

{{% /alert %}}
## **Αλλαγές δημόσιου API**
#### **Προστέθηκε κληρονομικότητα από τα interfaces ICollection και Generic IEnumerable στο ISmartArtNodeCollection**
Η κλάση Aspose.Slides.SmartArt.SmartArtNodeCollection (και το σχετικό interface Aspose.Slides.SmartArt.ISmartArtNodeCollection) κληρονομούν το γενικό interface IEnumerable<ISmartArtNode> και το interface ICollection.
#### **Προστέθηκε η τιμή enum SmartArtLayoutType.Custom**
Ο τύπος διάταξης Custom SmartArt αντιπροσωπεύει ένα διάγραμμα με προσαρμοσμένο πρότυπο. Τα προσαρμοσμένα διαγράμματα μπορούν να φορτωθούν μόνο από αρχείο παρουσίασης και δεν μπορούν να δημιουργηθούν μέσω της μεθόδου ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Προστέθηκαν η κλάση SmartArtShape και το interface ISmartArtShape**
Η κλάση Aspose.Slides.SmartArt.SmartArtShape (και το interface της Aspose.Slides.SmartArt.ISmartArtShape) παρέχει πρόσβαση σε μεμονωμένα σχήματα σε διάγραμμα SmartArt. Το SmartArtShape μπορεί να χρησιμοποιηθεί για αλλαγή FillFormat, LineFormat, προσθήκη Hyperlinks και άλλων εργασιών.

{{% alert color="info" %}}

**Σημείωση**: Το SmartArtShape δεν υποστηρίζει τις ιδιότητες RawFrame, Frame, Rotation, X, Y, Width, Height του IShape και ρίχνει System.NotSupportedException όταν επιχειρείται η πρόσβαση σε αυτές.

Παράδειγμα χρήσης:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
```

{{% /alert %}}
#### **Προστέθηκαν η κλάση SmartArtShapeCollection, το interface ISmartArtShapeCollection και η ιδιότητα ISmartArtNode.Shapes**
Η κλάση Aspose.Slides.SmartArt.SmartArtShapeCollection (και το interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) προσθέτει πρόσβαση σε μεμονωμένα σχήματα σε διάγραμμα SmartArt. Η συλλογή περιέχει σχήματα που σχετίζονται με SmartArtNode. Η ιδιότητα SmartArtNode.Shapes επιστρέφει συλλογές όλων των σχημάτων που συνδέονται με τον κόμβο.

{{% alert color="info" %}}

**Σημείωση**: ανάλογα με το SmartArtLayoutType, ένα SmartArtShape μπορεί να μοιράζεται μεταξύ πολλών κόμβων.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
```

{{% /alert %}}
#### **Προστέθηκαν μέθοδοι για αποθήκευση διαφανειών με διατήρηση αριθμών σελίδων**
Οι ακόλουθες μέθοδοι προστέθηκαν:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Αυτές οι μέθοδοι επιτρέπουν στους προγραμματιστές να αποθηκεύουν συγκεκριμένες διαφάνειες παρουσίασης σε μορφές PDF, XPS, TIFF, HTML. Ο πίνακας «slides» χρησιμοποιείται για τον καθορισμό των αριθμών σελίδων, ξεκινώντας από το 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Διάταξη θέσεων διαφανειών

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
```
#### **Προστέθηκαν μέθοδοι αντικατάστασης εικόνων στα PPImage, IPPImage**
Νέες μέθοδοι προστέθηκαν:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //Πρώτη μέθοδος

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //Δεύτερη μέθοδος

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Τρίτη μέθοδος

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```