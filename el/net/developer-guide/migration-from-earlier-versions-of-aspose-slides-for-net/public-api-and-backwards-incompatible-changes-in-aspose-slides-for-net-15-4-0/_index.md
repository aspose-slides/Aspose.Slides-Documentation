---
title: "Δημόσιο API και Αλλαγές που δεν είναι Συμβατές με Παλαιότερες Εκδόσεις στο Aspose.Slides για .NET 15.4.0"
linktitle: "Aspose.Slides για .NET 15.4.0"
type: docs
weight: 150
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- μετεγκατάσταση
- κώδικας κληρονομίας
- σύγχρονος κώδικας
- κληρονομική προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των breaking changes στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα παραθέτει όλες τις [προστεθείσες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) ή [αφαιρεθείσες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides for .NET 15.4.0 API.

{{% /alert %}} 
## **Δημόσιες Αλλαγές API**
#### **Η Enum OrganizationChartLayoutType Προστέθηκε**
Η enum Aspose.Slides.SmartArt.OrganizationChartLayoutType αντιπροσωπεύει τον τύπο μορφοποίησης των παιδικών κόμβων σε έναν οργανωτικό διάγραμμα.
#### **Η Μέθοδος IBulletFormat.ApplyDefaultParagraphIndentsShifts Προστέθηκε**
Η μέθοδος Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts ορίζει τις προεπιλεγμένες μη‑μηδενικές μετατοπίσεις για το αποτελεσματικό παραγραφο‑Indent και MarginLeft όταν τα bullets είναι ενεργοποιημένα (όπως κάνει το PowerPoint εάν ενεργοποιηθούν τα bullets/αρίθμηση παραγράφου σε αυτό). Εάν τα bullets είναι απενεργοποιημένα, τότε απλώς επαναφέρει το Indent και το MarginLeft της παραγράφου (όπως κάνει το PowerPoint εάν απενεργοποιηθούν τα bullets/αρίθμηση παραγράφου σε αυτό).

Δείτε παραδείγματα [εδώ](/slides/el/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Η Μέθοδος IConnector.Reroute Προστέθηκε**
Η μέθοδος Aspose.Slides.IConnector.Reroute αναπροσαρμόζει τον σύνδεσμο ώστε να ακολουθεί τη συντομότερη δυνατή διαδρομή μεταξύ των σχημάτων που συνδέει. Για να το κάνει αυτό, η μέθοδος Reroute() μπορεί να αλλάξει τα StartShapeConnectionSiteIndex και EndShapeConnectionSiteIndex.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Η Μέθοδος IPresentation.GetSlideById Προστέθηκε**
Η μέθοδος Aspose.Slides.IPresentation.GetSlideById(System.UInt32) επιστρέφει ένα Slide, MasterSlide ή LayoutSlide με βάση το Id της διαφάνειας.

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **Η Ιδιότητα IShape.ConnectionSiteCount Προστέθηκε**
Η ιδιότητα Aspose.Slides.IShape.ConnectionSiteCount επιστρέφει τον αριθμό των σημείων σύνδεσης στο σχήμα.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **Η Ιδιότητα ISmartArt.IsReversed Προστέθηκε**
Η ιδιότητα Aspose.Slides.SmartArt.ISmartArt.IsReversed επιτρέπει την ανάκτηση ή ορισμό της κατάστασης του διαγράμματος SmartArt ως (αριστερά‑προς‑δεξιά) LTR ή (δεξιά‑προς‑αριστερά) RTL, εφόσον το διάγραμμα υποστηρίζει αντιστροφή.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Η Ιδιότητα ISmartArt.Nodes Προστέθηκε**
Η ιδιότητα Aspose.Slides.SmartArt.ISmartArt.Nodes επιστρέφει τη συλλογή των ριζικών κόμβων στο αντικείμενο SmartArt.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // επιλέξτε δεύτερο ριζικό κόμβο

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Η Ιδιότητα ISmartArtNode.IsHidden Προστέθηκε**
Η ιδιότητα Aspose.Slides.SmartArt.ISmartArtNode.IsHidden επιστρέφει true εάν αυτός ο κόμβος είναι κρυμμένος στο μοντέλο δεδομένων.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //επιστρέφει true

  if(hidden)

  {

    //εκτελέστε κάποιες ενέργειες ή ειδοποιήσεις

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Η Ιδιότητα ISmartArtNode.OrganizationChartLayout Προστέθηκε**
Η ιδιότητα Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout επιτρέπει την ανάκτηση ή ορισμό του τύπου του οργανωτικού διαγράμματος που συνδέεται με τον τρέχοντα κόμβο.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Η Μέθοδος Set για την Ιδιότητα ISmartArt.Layout Προστέθηκε**
Η μέθοδος set για την ιδιότητα Aspose.Slides.SmartArt.ISmartArt.Layout προστέθηκε. Επιτρέπει την αλλαγή του τύπου διάταξης ενός υπάρχοντος διαγράμματος.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Μικρές Αλλαγές API**
**Αυτή είναι η λίστα των μικρών αλλαγών API:**

|Enum Aspose.Slides.BevelColorMode |διαγράφηκε, αχρησιμοποίητο enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |διαγράφηκε, αχρησιμοποίητη ιδιότητα |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |προστέθηκε |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |διαγράφηκε |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |διαγράφηκε ως παρωχημένο |