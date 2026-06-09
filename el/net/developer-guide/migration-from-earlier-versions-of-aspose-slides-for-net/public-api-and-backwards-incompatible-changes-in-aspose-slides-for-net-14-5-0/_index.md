---
title: Δημόσιο API και Ασυμβατότητες Προς Πίσω στο Aspose.Slides για .NET 14.5.0
linktitle: Aspose.Slides για .NET 14.5.0
type: docs
weight: 70
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- μετάβαση
- κληρονομημένος κώδικας
- σύγχρονος κώδικας
- κληρονομημένη προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση ενημερώσεων δημόσιου API και αλλαγών που σπάνουν στο Aspose.Slides για .NET για ομαλή μετάβαση των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα παραθέτει όλες τις [προστιθέμενες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., τυχόν νέους [περιορισμούς](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) και άλλες [αλλαγές](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) που εισήχθησαν με το Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **Δημόσιο API και Ασυμβατότητες Προς Πίσω**
### **Προστιθέμενα Διεπαφές, Κλάσεις, Ιδιότητες και Μέθοδοι**
#### **Προστέθηκε η Διεπαφή Aspose.Slides.IPresentationInfo και η Κλάση PresentationInfo**
Αναπαριστά πληροφορίες σχετικά με την παρουσίαση.

- Η ιδιότητα Boolean IsEncrypted επιστρέφει True εάν η παρουσίαση είναι κρυπτογραφημένη, διαφορετικά επιστρέφει False.
- Η ιδιότητα LoadFormat επιστρέφει τον τύπο μιας παρουσίασης.
#### **Προστέθηκε η Ιδιότητα Aspose.Slides.IShape.IsGrouped**
Η ιδιότητα Aspose.Slides.IShape.IsGrouped προσδιορίζει εάν ένα σχήμα είναι ομαδοποιημένο.
#### **Προστέθηκε η Ιδιότητα Aspose.Slides.IShape.ParentGroup**
Η ιδιότητα Aspose.Slides.IShape.ParentGroup επιστρέφει το γονικό αντικείμενο GroupShape εάν ένα σχήμα είναι ομαδοποιημένο. Διαφορετικά επιστρέφει null.
#### **Προστέθηκε η Μέθοδος Aspose.Slides.IShapeCollection.AddGroupShape()**
Η μέθοδος Aspose.Slides.IShapeCollection.AddGroupShape() δημιουργεί ένα νέο GroupShape και το προσθέτει στο τέλος της συλλογής.
Το μέγεθος και η θέση του πλαισίου GroupShape θα προσαρμοστούν στο περιεχόμενο όταν προστεθεί νέο σχήμα.
#### **Προστέθηκε η Μέθοδος Aspose.Slides.IShapeCollection.Clear()**
Η μέθοδος Aspose.Slides.IShapeCollection.Clear() αφαιρεί όλα τα σχήματα από τη συλλογή.
#### **Προστέθηκε η Μέθοδος Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Η μέθοδος Aspose.Slides.IShapeCollection.InsertGroupShape(int) δημιουργεί ένα νέο GroupShape και το εισάγει στη συλλογή στη συγκεκριμένη θέση δείκτη.
Το μέγεθος και η θέση του πλαισίου GroupShape θα προσαρμοστούν στο περιεχόμενο όταν προστεθεί νέο σχήμα.
#### **Προστέθηκαν οι Μέθοδοι IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Αυτές οι μέθοδοι επιτρέπουν τη λήψη πληροφοριών σχετικά με ένα αρχείο παρουσίασης ή ροή χωρίς πλήρη φόρτωση της παρουσίασης.
#### **Προστέθηκε η Ιδιότητα IPresentationFactory PresentationFactory.Instance**
Αυτή η ιδιότητα επιτρέπει στους προγραμματιστές να χρησιμοποιούν τη λειτουργικότητα του εργοστασίου χωρίς δημιουργία αντικειμένου.
### **Περιορισμοί**
#### **Περιορισμοί στην IShape.Frame**
Προστέθηκαν περιορισμοί για τη χρήση ακαθόριστων τιμών στην IShape.Frame. Κώδικας που προσπαθεί να εκχωρήσει μια ακαθόριστη τιμή στο IShape.Frame δεν έχει νόημα στις περισσότερες περιπτώσεις (ιδιαίτερα όταν το γονικό GroupShape είναι πολλαπλά ενσωματωμένο σε άλλα {{GroupShape}}s). Για παράδειγμα:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

ή

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Τέτοιος κώδικας μπορεί να οδηγήσει σε ασαφείς καταστάσεις. Έτσι προστέθηκαν περιορισμοί για τη χρήση ακαθόριστων τιμών στην IShape.Frame. Οι τιμές των x, y, width, height, flipH, flipV και rotationAngle πρέπει να ορίζονται (και να μην έχουν τιμή float.NaN ή NullableBool.NotDefined). Ο παραπάνω κώδικας τώρα ρίχνει εξαίρεση ArgumentException.
Αυτό ισχύει για τις ακόλουθες περιπτώσεις χρήσης:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Δεν μπορεί να είναι ακαθόριστο

IShapeCollection shapes = ...;

// Οι παράμετροι x, y, width, height δεν μπορούν να είναι float.NaN:

{
    shapes.AddAudioFrameCD(...);
    shapes.AddAudioFrameEmbedded(...);
    shapes.AddAudioFrameLinked(...);
    shapes.AddAutoShape(...);
    shapes.AddChart(...);
    shapes.AddConnector(...);
    shapes.AddOleObjectFrame(...);
    shapes.AddPictureFrame(...);
    shapes.AddSmartArt(...);
    shapes.AddTable(...);
    shapes.AddVideoFrame(...);
    shapes.InsertAudioFrameEmbedded(...);
    shapes.InsertAudioFrameLinked(...);
    shapes.InsertAutoShape(...);
    shapes.InsertChart(...);
    shapes.InsertConnector(...);
    shapes.InsertOleObjectFrame(...);
    shapes.InsertPictureFrame(...);
    shapes.InsertTable(...);
    shapes.InsertVideoFrame(...);
}
``` 

Αλλά οι ιδιότητες πλαισίου IShape.RawFrame μπορούν να είναι ακαθόριστες. Αυτό έχει νόημα όταν ένα σχήμα είναι συνδεδεμένο με έναν placeholder. Τότε οι ακαθόριστες τιμές πλαισίου του σχήματος αντικαθίστανται από το γονικό placeholder σχήμα. Εάν δεν υπάρχει γονικό placeholder σχήμα, τότε το σχήμα χρησιμοποιεί τις προεπιλεγμένες τιμές όταν υπολογίζει το αποτελεσματικό πλαίσιο βάσει του IShape.RawFrame. Οι προεπιλεγμένες τιμές είναι 0 και NullableBool.False για x, y, width, height, flipH, flipV και rotationAngle. Για παράδειγμα:

``` csharp

 IShape shape = ...; // shape είναι συνδεδεμένο με placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// τώρα το shape κληρονομεί τις τιμές x, y, height, flipH, flipV από το placeholder και παρακάμπτει το width=100 και το rotationAngle=0.

``` 
### **Αλλαγμένες Ιδιότητες**
#### **Αλλάχτηκε το Όνομα και ο Τύπος της Ιδιότητας Aspose.Slides.IShapeCollection.Parent**
- Ο τύπος της ιδιότητας Aspose.Slides.IShapeCollection.Parent άλλαξε από ISlideComponent στον νέο διεπαφή IGroupShape. Η διεπαφή IGroupShape είναι απόγονος του ISlideComponent, οπότε ο υπάρχων κώδικας δεν χρειάζεται προσαρμογές.
- Το όνομα της ιδιότητας Aspose.Slides.IShapeCollection.Parent άλλαξε από Parent σε ParentGroup.
#### **Αλλάχθηκαν οι Τύποι των Ιδιοτήτων Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Ο τύπος της ιδιότητας Aspose.Slides.IShapeFrame.FlipH άλλαξε από bool σε NullableBool.
- Η ιδιότητα IShape.Frame επιστρέφει μια αποτελεσματική παρουσίαση του IShapeFrame (όλες οι ιδιότητές του έχουν ορισμένες αποτελεσματικές τιμές).
- Η ιδιότητα IShape.RawFrame επιστρέφει μια παρουσίαση του IShapeFrame της οποίας κάθε ιδιότητα μπορεί να έχει ακαθόρισμένη τιμή (ιδιαίτερα το FlipH ή το FlipV μπορεί να έχει τιμή NullableBool.NotDefined).