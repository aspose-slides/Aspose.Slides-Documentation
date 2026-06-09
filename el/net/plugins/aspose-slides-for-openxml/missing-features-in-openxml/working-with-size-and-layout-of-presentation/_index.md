---
title: Εργασία με το Μέγεθος και τη Διάταξη της Παρουσίασης
type: docs
weight: 90
url: /el/net/working-with-size-and-layout-of-presentation/
---
**SlideSize.Type** and **SlideSize.Size** είναι οι ιδιότητες της κλάσης presentation που μπορούν να οριστούν ή να ληφθούν όπως φαίνεται παρακάτω στο παράδειγμα.
## **Παράδειγμα**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Δημιουργία αντικειμένου Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Ορίστε το μέγεθος διαφάνειας των παραγόμενων παρουσιάσεων στο μέγεθος της πηγής

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Αποθήκευση παρουσίασης στο δίσκο

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Κατεβάστε Δειγματικό Κώδικα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Κατεβάστε Εκτελέσιμο Παράδειγμα**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 

Για περισσότερες λεπτομέρειες, επισκεφθείτε [Αλλαγή του Μεγέθους Διαφάνειας Παρουσίασης στο .NET](/slides/el/net/slide-size/).

{{% /alert %}}