---
title: Δημόσιο API και Ασυμβατότητες Πίσω σε Aspose.Slides για .NET 14.5.0
linktitle: Aspose.Slides για .NET 14.5.0
type: docs
weight: 70
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- μετανάστευση
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
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των σημαντικών αλλαγών στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασής σας PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 

Αυτή η σελίδα παραθέτει όλες τις [προστιθέμενα](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., τυχόν νέους [περιορισμούς](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) και άλλες [αλλαγές](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) που εισήχθησαν με το Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **Δημόσιο API και Ασυμβατότητες Πίσω**
### **Προστέθηκαν Διεπαφές, Κλάσεις, Ιδιότητες και Μέθοδοι**
#### **Προστέθηκε η Διεπαφή Aspose.Slides.IPresentationInfo και η Κλάση PresentationInfo**
Αναπαριστά πληροφορίες σχετικά με την παρουσίαση.

- Η Boolean ιδιότητα IsEncrypted επιστρέφει True εάν μια παρουσίαση είναι κρυπτογραφημένη, διαφορετικά επιστρέφει False.
- Η ιδιότητα LoadFormat επιστρέφει τον τύπο μιας παρουσίασης.
#### **Προστέθηκε η Ιδιότητα Aspose.Slides.IShape.IsGrouped**
Η ιδιότητα Aspose.Slides.IShape.IsGrouped καθορίζει εάν ένα σχήμα είναι ομαδοποιημένο.
#### **Προστέθηκε η Ιδιότητα Aspose.Slides.IShape.ParentGroup**
Η ιδιότητα Aspose.Slides.IShape.ParentGroup επιστρέφει το γονικό αντικείμενο GroupShape εάν ένα σχήμα είναι ομαδοποιημένο. Διαφορετικά επιστρέφει null.
#### **Προστέθηκε η Μέθοδος Aspose.Slides.IShapeCollection.AddGroupShape()**
Η μέθοδος Aspose.Slides.IShapeCollection.AddGroupShape() δημιουργεί ένα νέο GroupShape και το προσθέτει στο τέλος της συλλογής.
Το μέγεθος και η θέση του πλαισίου του GroupShape θα προσαρμοστούν στο περιεχόμενο όταν προστεθεί νέο σχήμα.
#### **Προστέθηκε η Μέθοδος Aspose.Slides.IShapeCollection.Clear()**
Η μέθοδος Aspose.Slides.IShapeCollection.Clear() αφαιρεί όλα τα σχήματα από τη συλλογή.
#### **Προστέθηκε η Μέθοδος Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Η μέθοδος Aspose.Slides.IShapeCollection.InsertGroupShape(int) δημιουργεί ένα νέο GroupShape και το εισάγει στη συλλογή στη συγκεκριμένη θέση δείκτη.
Το μέγεθος και η θέση του πλαισίου του GroupShape θα προσαρμοστούν στο περιεχόμενο όταν προστεθεί νέο σχήμα.
#### **Προστέθηκαν οι Μέθοδοι IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Αυτές οι μέθοδοι επιτρέπουν τη λήψη πληροφοριων σχετικά με ένα αρχείο ή ρεύμα παρουσίασης χωρίς πλήρη φόρτωση της παρουσίασης.
#### **Προστέθηκε η Ιδιότητα IPresentationFactory PresentationFactory.Instance**
Αυτή η ιδιότητα επιτρέπει στους προγραμματιστές να χρησιμοποιούν τη λειτουργικότητα του εργοστασίου χωρίς δημιουργία αντικειμένου.
### **Περιορισμοί**
#### **Περιορισμοί στην IShape.Frame**
Έχουν προστεθεί περιορισμοί για τη χρήση μη ορισμένων τιμών στην IShape.Frame. Κώδικας που προσπαθεί να εκχωρήσει ένα μη ορισμένο πλαίσιο στην IShape.Frame δεν έχει νόημα στις περισσότερες περιπτώσεις (ιδιαίτερα όταν το γονικό GroupShape είναι πολλαπλά ενσωματωμένο σε άλλα {{GroupShape}}). Για παράδειγμα:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Ρίχνει ArgumentException: οι τιμές του πλαισίου πρέπει να οριστούν.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

ή

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Ρίχνει ArgumentException: τα x, y, width και height πρέπει να οριστούν.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Τέτοιος κώδικας μπορεί να οδηγήσει σε ασαφείς καταστάσεις. Έτσι έχουν προστεθεί περιορισμοί για τη χρήση μη ορισμένων τιμών στην IShape.Frame. Οι τιμές των x, y, width, height, flipH, flipV και rotationAngle πρέπει να είναι ορισμένες (και να μην ορίζονται ως float.NaN ή NullableBool.NotDefined). Ο παραπάνω κώδικας δείγματος τώρα ρίχνει μια εξαίρεση ArgumentException.
Αυτό ισχύει για τις παρακάτω περιπτώσεις χρήσης:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Οι παράμετροι x, y, width και height δεν μπορούν να είναι float.NaN, και οι flipH, flipV
// δεν μπορούν να είναι NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// Ο ίδιος περιορισμός ισχύει για κάθε μέθοδο που δημιουργεί σχήμα:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Ωστόσο οι ιδιότητες πλαισίου του IShape.RawFrame μπορούν να είναι μη ορισμένες. Αυτό έχει νόημα όταν ένα σχήμα είναι συνδεδεμένο με ένα placeholder. Τότε οι μη ορισμένες τιμές πλαισίου του σχήματος αντικαθίστανται από το γονικό placeholder σχήμα. Εάν δεν υπάρχει γονικό placeholder σχήμα, τότε αυτό το σχήμα χρησιμοποιεί τις προεπιλεγμένες τιμές όταν αξιολογεί το αποτελεσματικό πλαίσιο βάσει του IShape.RawFrame. Οι προεπιλεγμένες τιμές είναι 0 και NullableBool.False για x, y, width, height, flipH, flipV και rotationAngle. Για παράδειγμα:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Το σχήμα είναι συνδεδεμένο με ένα placeholder
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // τώρα το σχήμα κληρονομεί τις τιμές x, y, height, flipH, flipV από το placeholder και αντικαθιστά width=100 και rotationAngle=0.
}
``` 
### **Αλλαγμένες Ιδιότητες**
#### **Αλλάχτηκε το Όνομα και ο Τύπος της Ιδιότητας Aspose.Slides.IShapeCollection.Parent**
- Ο τύπος της ιδιότητας Aspose.Slides.IShapeCollection.Parent έχει αλλάξει από ISlideComponent στην νέα διεπαφή IGroupShape. Η διεπαφή IGroupShape είναι απόγονος του ISlideComponent, ώστε ο υπάρχων κώδικας να μην απαιτεί προσαρμογές.
- Το όνομα της ιδιότητας Aspose.Slides.IShapeCollection.Parent έχει αλλάξει από Parent σε ParentGroup.
#### **Αλλάχτηκαν οι Τύποι των Ιδιοτήτων Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Ο τύπος της ιδιότητας Aspose.Slides.IShapeFrame.FlipH έχει αλλάξει από bool σε NullableBool.
- Η ιδιότητα IShape.Frame επιστρέφει ένα αποτελεσματικό παράδειγμα του IShapeFrame (όλες οι ιδιότητές του έχουν ορισμένες αποτελεσματικές τιμές).
- Η ιδιότητα IShape.RawFrame επιστρέφει ένα παράδειγμα του IShapeFrame του οποίου κάθε ιδιότητα μπορεί να έχει μη ορισμένη τιμή (ιδιαίτερα οι FlipH ή FlipV μπορούν να έχουν την τιμή NullableBool.NotDefined).