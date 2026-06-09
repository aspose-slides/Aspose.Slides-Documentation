---
title: Δημόσιο API και Αλλαγές που Δεν Είναι Συμβατές με Παλαιότερες Εκδόσεις στο Aspose.Slides για .NET 15.4.0
linktitle: Aspose.Slides για .NET 15.4.0
type: docs
weight: 150
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- μετάβαση
- κληρονομικός κώδικας
- σύγχρονος κώδικας
- κληρονομική προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των σπασμένων αλλαγών στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλες τις [προστιθέμενες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) ή [αφαιρεθείσες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides για .NET 15.4.0.

{{% /alert %}} 
## **Δημόσιες αλλαγές API**
#### **Προστέθηκε το enum OrganizationChartLayoutType**
Το enum Aspose.Slides.SmartArt.OrganizationChartLayoutType αντιπροσωπεύει τον τύπο μορφοποίησης των θυγατρικών κόμβων σε ένα διάγραμμα οργανισμού.
#### **Προστέθηκε η μέθοδος IBulletFormat.ApplyDefaultParagraphIndentsShifts**
Η μέθοδος Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts ορίζει προεπιλεγμένες μη μηδενικές μετατοπίσεις για το ενεργό περιθώριο (Indent) και το αριστερό περιθώριο (MarginLeft) παραγράφου όταν είναι ενεργοποιημένα τα σημεία (όπως κάνει το PowerPoint όταν ενεργοποιούνται οι κουκίδες/αρίθμηση παραγράφων). Εάν τα σημεία είναι απενεργοποιημένα, η μέθοδος απλώς επαναφέρει το περιθώριο (Indent) και το MarginLeft (όπως κάνει το PowerPoint όταν απενεργοποιούνται οι κουκίδες/αρίθμηση).

Δείτε παραδείγματα [εδώ](/slides/el/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Προστέθηκε η μέθοδος IConnector.Reroute**
Η μέθοδος Aspose.Slides.IConnector.Reroute ανακατευθύνει το σύνδεσμο έτσι ώστε να ακολουθεί τη συντομότερη δυνατή διαδρομή μεταξύ των σχημάτων που συνδέει. Για τον σκοπό αυτό, η μέθοδος Reroute() ενδέχεται να αλλάξει τα πεδία StartShapeConnectionSiteIndex και EndShapeConnectionSiteIndex.

``` csharp

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
#### **Προστέθηκε η μέθοδος IPresentation.GetSlideById**
Η μέθοδος Aspose.Slides.IPresentation.GetSlideById(System.UInt32) επιστρέφει μια διαφάνεια (Slide), κύρια διαφάνεια (MasterSlide) ή διαφάνεια διάταξης (LayoutSlide) βάσει του αναγνωριστικού διαφάνειας.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Προστέθηκε η ιδιότητα IShape.ConnectionSiteCount**
Η ιδιότητα Aspose.Slides.IShape.ConnectionSiteCount επιστρέφει τον αριθμό των σημείων σύνδεσης στο σχήμα.

``` csharp

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
#### **Προστέθηκε η ιδιότητα ISmartArt.IsReversed**
Η ιδιότητα Aspose.Slides.SmartArt.ISmartArt.IsReversed επιτρέπει την ανάγνωση ή τη ρύθμιση της κατάστασης του διαγράμματος SmartArt ως (αριστερά προς δεξιά) LTR ή (δεξιά προς αριστερά) RTL, εφόσον το διάγραμμα υποστηρίζει αντιστροφή.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Προστέθηκε η ιδιότητα ISmartArt.Nodes**
Η ιδιότητα Aspose.Slides.SmartArt.ISmartArt.Nodes επιστρέφει τη συλλογή των ριζικών κόμβων στο αντικείμενο SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // επέλεξε τον δεύτερο ριζικό κόμβο

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Προστέθηκε η ιδιότητα ISmartArtNode.IsHidden**
Η ιδιότητα Aspose.Slides.SmartArt.ISmartArtNode.IsHidden επιστρέφει true εάν αυτός ο κόμβος είναι κρυφός στο μοντέλο δεδομένων.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //επιστρέφει true

  if(hidden)

  {

    //εκτελέστε κάποιες ενέργειες ή ειδοποιήσεις

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Προστέθηκε η ιδιότητα ISmartArtNode.OrganizationChartLayout**
Η ιδιότητα Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout επιτρέπει την ανάγνωση ή τη ρύθμιση του τύπου διαγράμματος οργανισμού που σχετίζεται με τον τρέχοντα κόμβο.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Προστέθηκε η set μέθοδος για την ιδιότητα ISmartArt.Layout**
Προστέθηκε η μέθοδος set για την ιδιότητα Aspose.Slides.SmartArt.ISmartArt.Layout. Επιτρέπει την αλλαγή του τύπου διάταξης ενός υπάρχοντος διαγράμματος.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Μικρές αλλαγές API**
**Αυτή είναι η λίστα των μικρών αλλαγών API:**

|Enum Aspose.Slides.BevelColorMode |διαγραμμένο, αχρησιμοποίητο enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |διαγραμμένη, αχρησιμοποίητη ιδιότητα |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |προστέθηκε |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |διαγράφηκε |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |διαγράφηκε ως παρωχημένο |