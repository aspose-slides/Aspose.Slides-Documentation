---
title: Δημόσιο API και Αλλαγές που δεν είναι Συμβατές με Παλαιότερες Εκδόσεις στο Aspose.Slides για .NET 14.3.0
linktitle: Aspose.Slides για .NET 14.3.0
type: docs
weight: 50
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
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
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των κρίσιμων αλλαγών στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
## **Δημόσιο API και Αλλαγές που δεν είναι Συμβατές με Παλαιότερες Εκδόσεις**
### **Προστέθηκαν η Απαριθμητική Aspose.Slides.ShapeThumbnailBounds και οι Μέθοδοι Aspose.Slides.IShape.GetThumbnail()**
Οι μέθοδοι GetThumbnail() και GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) χρησιμοποιούνται για τη δημιουργία ενός ξεχωριστού μικρογραφία σχήματος. Η απαριθμητική ShapeThumbnailBounds ορίζει τους δυνατούς τύπους ορίων μικρογραφίας σχήματος.
### **Προστέθηκε η Ιδιότητα UniqueId στην Aspose.Slides.IShape**
Η ιδιότητα Aspose.Slides.IShape.UniqueId επιστρέφει ένα μοναδικό αναγνωριστικό σχήματος σε επίπεδο παρουσίασης. Αυτά τα μοναδικά αναγνωριστικά αποθηκεύονται σε προσαρμοσμένες ετικέτες σχήματος.
### **Αλλαγή της Υπογραφής της Μεθόδου SetGroupingItem στο IChartCategoryLevelsManager**
Η υπογραφή της μεθόδου IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

είναι πλέον παρωχημένη και αντικαταστάθηκε με τη νέα υπογραφή

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Τώρα κλήσεις όπως

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

πρέπει να μετατραπούν σε κλήσεις όπως

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Περιλάβετε τιμή όπως "Group 1" στη μέθοδο SetGroupingItem, όχι τιμή τύπου IChartDataCell. Η δημιουργία IChartDataCell με συγκεκριμένο φύλλο εργασίας, γραμμή και στήλη για τα επίπεδα κατηγοριών πρέπει να ικανοποιεί ορισμένες απαιτήσεις και έχει ενσωματωθεί στη μέθοδο SetGroupingItem(int, object).
### **Προστέθηκε η Ιδιότητα SlideId στην Διασύνδεση Aspose.Slides.IBaseSlide**
Η ιδιότητα SlideId επιστρέφει ένα μοναδικό αναγνωριστικό διαφάνειας.
### **Προστέθηκε η Ιδιότητα SoundName στο ISlideShowTransition**
Συμβολοσειρά με δυνατότητα ανάγνωσης και εγγραφής. Καθορίζει ένα ανθρώπινα αναγνώσιμο όνομα για τον ήχο της μετάβασης. Η ιδιότητα Sound πρέπει να έχει οριστεί για λήψη ή ορισμό του ονόματος ήχου. Αυτό το όνομα εμφανίζεται στη διεπαφή χρήστη του PowerPoint όταν ρυθμίζεται χειροκίνητα ο ήχος της μετάβασης. Μπορεί να προκαλέσει PptxException εάν η ιδιότητα Sound δεν έχει οριστεί.
### **Αλλαγή του Τύπου της Ιδιότητας ChartSeriesGroup.Type**
Η ιδιότητα ChartSeriesGroup.Type έχει αλλάξει από την απαριθμητική ChartType στην νέα απαριθμητική CombinableSeriesTypesGroup. Η απαριθμητική CombinableSeriesTypesGroup αντιπροσωπεύει τις ομάδες συνδυάσιμων τύπων σειράς.
### **Προστέθηκε Υποστήριξη για Δημιουργία Ατομικών Μικρογραφιών Σχήματος**
Aspose.Slides.ShapeThumbnailBounds

Νέα μέλη στην Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)