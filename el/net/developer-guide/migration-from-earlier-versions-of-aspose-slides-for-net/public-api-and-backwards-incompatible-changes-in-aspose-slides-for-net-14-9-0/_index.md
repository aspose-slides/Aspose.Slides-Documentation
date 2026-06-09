---
title: Δημόσιο API και Μη Συμβατικές Αλλαγές στο Aspose.Slides για .NET 14.9.0
linktitle: Aspose.Slides για .NET 14.9.0
type: docs
weight: 110
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- μετανάστευση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των αλλαγών που διακόπτουν τη συμβατότητα στο Aspose.Slides για .NET, ώστε να μεταβείτε ομαλά στις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα παραθέτει όλες τις [προστέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) ή [αφαιρέθηκαν](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) κλάσεις, μεθόδους, ιδιότητες κ.ά., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides για .NET 14.9.0 API.

{{% /alert %}} 
## **Δημόσιες Αλλαγές API**
#### **Inheritance from ICollection and Generic IEnumerable Interfaces Added to ISmartArtNodeCollection**
Προστέθηκε η κληρονομικότητα από τις διεπαφές ICollection και Generic IEnumerable στο ISmartArtNodeCollection
#### **SmartArtLayoutType.Custom Enum Value Added**
Προστέθηκε η τιμή Enum SmartArtLayoutType.Custom  
Ο τύπος διάταξης Custom SmartArt αντιπροσωπεύει ένα διάγραμμα με προσαρμοσμένο πρότυπο. Τα προσαρμοσμένα διαγράμματα μπορούν να φορτωθούν μόνο από αρχείο παρουσίασης και δεν μπορούν να δημιουργηθούν μέσω της μεθόδου ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **SmartArtShape Class and ISmartArtShape Interface Added**
Προστέθηκαν η κλάση SmartArtShape και η διεπαφή ISmartArtShape  
Η κλάση Aspose.Slides.SmartArt.SmartArtShape (και η διεπαφή της Aspose.Slides.SmartArt.ISmartArtShape) παρέχει πρόσβαση σε μεμονωμένα σχήματα σε διάγραμμα SmartArt. Η SmartArtShape μπορεί να χρησιμοποιηθεί για την αλλαγή του FillFormat, LineFormat, την προσθήκη υπερσυνδέσμων και άλλες εργασίες.

{{% alert color="primary" %}} 

**Σημείωση**: Η SmartArtShape δεν υποστηρίζει τις ιδιότητες IShape RawFrame, Frame, Rotation, X, Y, Width, Height και ρίχνει System.NotSupportedException όταν γίνεται προσπάθεια πρόσβασης σε αυτές.

Example of usage:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **SmartArtShapeCollection Class, ISmartArtShapeCollection Interface and ISmartArtNode.Shapes Property Added**
Προστέθηκαν η κλάση SmartArtShapeCollection, η διεπαφή ISmartArtShapeCollection και η ιδιότητα ISmartArtNode.Shapes  
Η κλάση Aspose.Slides.SmartArt.SmartArtShapeCollection (και η διεπαφή της Aspose.Slides.SmartArt.ISmartArtShapeCollection) προσθέτει πρόσβαση σε μεμονωμένα σχήματα σε διάγραμμα SmartArt. Η συλλογή περιέχει σχήματα που σχετίζονται με SmartArtNode. Η ιδιότητα SmartArtNode.Shapes επιστρέφει συλλογές όλων των σχημάτων που σχετίζονται με τον κόμβο.

{{% alert color="primary" %}} 

**Σημείωση**: ανάλογα με το SmartArtLayoutType, ένα SmartArtShape μπορεί να μοιράζεται μεταξύ πολλών κόμβων.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Methods for Saving Slides with Page Numbers Keeping Added**
Προστέθηκαν μέθοδοι αποθήκευσης διαφανειών με διατήρηση αριθμών σελίδων  
Οι παρακάτω μέθοδοι έχουν προστεθεί:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Οι μέθοδοι αυτές επιτρέπουν στους προγραμματιστές να αποθηκεύουν συγκεκριμένες διαφάνειες παρουσίασης σε μορφές PDF, XPS, TIFF, HTML. Ο πίνακας 'slides' χρησιμοποιείται για τον καθορισμό αριθμών σελίδων, ξεκινώντας από το 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //Σειρά θέσεων διαφανειών
presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Methods for Replacing Images Added to PPImage, IPPImage**
Προστέθηκαν μέθοδοι αντικατάστασης εικόνων στο PPImage, IPPImage  
Νέες μέθοδοι που προστέθηκαν:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);
//Πρώτη μέθοδος

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);
//Δεύτερη μέθοδος

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);
//Τρίτη μέθοδος

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```