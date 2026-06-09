---
title: Διαχείριση Ετικετών και Προσαρμοσμένων Δεδομένων σε Παρουσιάσεις σε .NET
linktitle: Ετικέτες και Προσαρμοσμένα Δεδομένα
type: docs
weight: 300
url: /el/net/managing-tags-and-custom-data/
keywords:
- ιδιότητες εγγράφου
- ετικέτα
- προσαρμοσμένα δεδομένα
- προσθήκη ετικέτας
- τιμές ζεύγους
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε, διαβάζετε, ενημερώνετε και αφαιρείτε ετικέτες & προσαρμοσμένα δεδομένα στο Aspose.Slides για .NET, με παραδείγματα για παρουσιάσεις PowerPoint και OpenDocument."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς το Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Περιγράφει εν συντομία πώς αποθηκεύονται τα δεδομένα σε αρχεία PPTX, σημειώνει ότι δεδομένα ειδικά για την παρουσίαση μπορούν να υπάρξουν ως ετικέτες και προσαρμοσμένα τμήματα XML, και περιγράφει τις ετικέτες ως ζεύγη κλειδιού‑τιμής συμβολοσειράς.

Δείχνει επίσης πώς να διαβάσετε τις τιμές των ετικετών και πώς να προσθέσετε ετικέτες σε μια παρουσίαση, σε μία μεμονωμένη διαφάνεια ή σε ένα σχήμα. Επιπλέον, το άρθρο καλύπτει κοινές εργασίες διαχείρισης ετικετών όπως ο καθαρισμός όλων των ετικετών, η αφαίρεση ετικέτας με όνομα και η ανάκτηση της λίστας των ονομάτων ετικετών.

## **Αποθήκευση Δεδομένων σε Αρχεία Παρουσίασης**

Τα αρχεία PPTX—αντικείμενα με την επέκταση .pptx—αποθηκεύονται σε μορφή PresentationML, η οποία αποτελεί μέρος της προδιαγραφής Office Open XML. Η μορφή Office Open XML ορίζει τη δομή των δεδομένων που περιέχονται στις παρουσιάσεις.

Με μια *διαφάνεια* να είναι ένα από τα στοιχεία στις παρουσιάσεις, ένα *μέρος διαφάνειας* περιέχει το περιεχόμενο μιας ενιαίας διαφάνειας. Επιτρέπεται σε ένα μέρος διαφάνειας να έχει ρητές σχέσεις με πολλά τμήματα — όπως οι User Defined Tags — που ορίζονται από το ISO/IEC 29500.

Τα προσαρμοσμένα δεδομένα (συγκεκριμένα για μια παρουσίαση) ή χρήστης μπορούν να υπάρχουν ως ετικέτες ([ITagCollection](https://reference.aspose.com/slides/el/net/aspose.slides/itagcollection)) και CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpartcollection)).

{{% alert color="primary" %}} 
Οι ετικέτες είναι ουσιαστικά ζεύγη κλειδιού‑τιμής συμβολοσειράς. 
{{% /alert %}} 

## **Λήψη Τιμών Ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στην ιδιότητα IDocumentProperties.Keywords. Αυτό το δείγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με το Aspose.Slides για .NET για [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Προσθήκη Ετικετών σε Παρουσιάσεις**

Το Aspose.Slides σας επιτρέπει να προσθέσετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας - `MyTag`
- η τιμή της προσαρμοσμένης ιδιότητας - `My Tag Value`

Εάν χρειάζεται να ταξινομήσετε κάποιες παρουσιάσεις βάσει ενός συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να επωφεληθείτε από την προσθήκη ετικετών σε αυτές τις παρουσιάσεις. Για παράδειγμα, αν θέλετε να ομαδοποιήσετε όλες τις παρουσιάσεις από τις βόρειες αμερικανικές χώρες, μπορείτε να δημιουργήσετε μια ετικέτα North American και στη συνέχεια να ορίσετε τις σχετικές χώρες (ΗΠΑ, Μεξικό, Καναδά) ως τιμές.

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε ένα [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) χρησιμοποιώντας το Aspose.Slides για .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Οι ετικέτες μπορούν επίσης να οριστούν για το [Slide](https://reference.aspose.com/slides/el/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Ή για οποιοδήποτε μεμονωμένο [Shape](https://reference.aspose.com/slides/el/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής `CustomData.Tags` αποθηκεύονται μόνο μέσα στο αρχείο PowerPoint. Δεν μεταφέρονται στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένα προσαρμοσμένο αναγνωριστικό που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Παράκαμψη**: Μπορείτε να αποθηκεύσετε ένα προσαρμοσμένο αναγνωριστικό στο **Alt Text** του αντικειμένου (π.χ., `shape.AlternativeText = "MyId"`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών PDF.

## **Συχνές Ερωτήσεις**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα με μια ενέργεια;**

Ναι. Η [tag collection](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/) υποστηρίζει λειτουργία [clear](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/clear/) που διαγράφει όλα τα ζεύγη κλειδιού‑τιμής μονομιάς.

**Πώς να διαγράψω μία ετικέτα με το όνομά της χωρίς να περιηγηθώ σε ολόκληρη τη συλλογή;**

Χρησιμοποιήστε τη λειτουργία [Remove(name)](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/remove/) στο [TagCollection](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω την πλήρη λίστα των ονομάτων ετικετών για αναλύσεις ή φιλτράρισμα;**

Χρησιμοποιήστε το [GetNamesOfTags](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/getnamesoftags/) στη [tag collection](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.