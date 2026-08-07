---
title: Διαχείριση ετικετών και προσαρμοσμένων δεδομένων σε παρουσιάσεις στο .NET
linktitle: Ετικέτες και προσαρμοσμένα δεδομένα
type: docs
weight: 300
url: /el/net/managing-tags-and-custom-data/
keywords:
- ιδιότητες εγγράφου
- ετικέτα
- προσαρμοσμένα δεδομένα
- προσαρμοσμένο XML
- τμήμα προσαρμοσμένου XML
- μεταδεδομένα XML
- ItemId
- προσθήκη ετικέτας
- ζεύγη τιμών
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε ετικέτες και προσαρμοσμένα δεδομένα XML σε παρουσιάσεις PowerPoint με το Aspose.Slides για .NET, συμπεριλαμβανομένης της προσθήκης, ανάγνωσης, ενημέρωσης, ελέγχου και αφαίρεσης τμημάτων προσαρμοσμένου XML."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς η Aspose.Slides λειτουργεί με ετικέτες και προσαρμοσμένα δεδομένα σε παρουσιάσεις PowerPoint. Τα δεδομένα που αφορούν συγκεκριμένη παρουσίαση μπορούν να αποθηκευτούν ως ετικέτες ή προσαρμοσμένα τμήματα XML. Οι ετικέτες είναι απλά ζεύγη κλειδιού‑τιμής τύπου συμβολοσειράς, ενώ τα προσαρμοσμένα τμήματα XML μπορούν να αποθηκεύσουν δομημένα μεταδεδομένα και XML φορτία ειδικά για την εφαρμογή.

Aspose.Slides παρέχει API για προσθήκη, ανάγνωση, ενημέρωση, έλεγχο και διαγραφή προσαρμοσμένων τμημάτων XML στα επίπεδα παρουσίασης, διαφάνειας και σχήματος. Τα προσαρμοσμένα τμήματα XML είναι χρήσιμα για ενσωματώσεις που αποθηκεύουν πληροφορίες όπως αναγνωριστικά διαχείρισης εγγράφων, κατάσταση ροής εργασίας, μεταδεδομένα συμμόρφωσης, δεδομένα σύνδεσης προτύπου ή άλλα δομημένα δεδομένα εφαρμογής μέσα σε μια παρουσίαση.

## **Αποθήκευση δεδομένων σε αρχεία παρουσίασης**

Τα αρχεία PPTX — αρχεία με την επέκταση `.pptx` — αποθηκεύονται σε μορφή PresentationML, η οποία αποτελεί μέρος της προδιαγραφής Office Open XML. Το Office Open XML ορίζει τη δομή πακέτου και τις σχέσεις που χρησιμοποιούνται για την αποθήκευση περιεχομένου παρουσίασης και σχετικών δεδομένων.

Μια παρουσίαση περιέχει πολλά τμήματα συνδεδεμένα μέσω σχέσεων. Για παράδειγμα, ένα τμήμα διαφάνειας περιέχει το περιεχόμενο μιας μόνο διαφάνειας και μπορεί να έχει ρητές σχέσεις με άλλα τμήματα που ορίζονται από το ISO/IEC 29500.

Προσαρμοσμένα δεδομένα μπορούν να αποθηκευτούν ως ετικέτες ([ITagCollection](https://reference.aspose.com/slides/el/net/aspose.slides/itagcollection)) ή προσαρμοσμένα τμήματα XML ([ICustomXmlPartCollection](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpartcollection)). Και τα δύο είναι διαθέσιμα μέσω της διεπαφής [`ICustomData`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomdata/) .

{{% alert color="primary" %}}
Οι ετικέτες αποθηκεύουν απλά ζεύγη κλειδιού‑τιμής τύπου συμβολοσειράς. Τα προσαρμοσμένα τμήματα XML αποθηκεύουν δομημένα δεδομένα XML και μπορούν να συσχετιστούν με μια παρουσίαση, διαφάνεια ή σχήμα.
{{% /alert %}}

## **Δουλειά με προσαρμοσμένα τμήματα XML**

Η ιδιότητα [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomdata/customxmlparts/) επιστρέφει τη συλλογή των προσαρμοσμένων τμημάτων XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο παρουσίασης. Για παράδειγμα:

- `presentation.CustomData.CustomXmlParts` περιέχει προσαρμοσμένα τμήματα XML που σχετίζονται με την ίδια την παρουσίαση.
- `slide.CustomData.CustomXmlParts` περιέχει προσαρμοσμένα τμήματα XML που σχετίζονται με μια συγκεκριμένη διαφάνεια.
- `shape.CustomData.CustomXmlParts` περιέχει προσαρμοσμένα τμήματα XML που σχετίζονται με ένα συγκεκριμένο σχήμα.

Χρησιμοποιήστε [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/allcustomxmlparts/) όταν χρειάζεται να εξετάσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση ανεξάρτητα από το πού είναι συνδεδεμένα.

### **Προσθήκη προσαρμοσμένου τμήματος XML σε παρουσίαση**

Χρησιμοποιήστε [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpartcollection/add/) για να προσθέσετε δεδομένα XML σε μια συλλογή προσαρμοσμένων τμημάτων XML. Το XML πρέπει να είναι έγκυρο και μη κενό.

Το παρακάτω παράδειγμα προσθέτει δομημένα μεταδεδομένα στη συλλογή προσαρμοσμένων δεδομένων επιπέδου παρουσίασης:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Η προσθήκη εκχωρεί ένα αναγνωριστικό αυτόματα. Ορίστε ένα συγκεκριμένο GUID μόνο όταν απαιτείται.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Η μέθοδος `Add` μπορεί επίσης να δεχθεί XML ως πίνακα byte ή ροή, κάτι χρήσιμο όταν το περιεχόμενο XML είναι ήδη διαθέσιμο σε δυαδική μορφή.

### **Προσθήκη προσαρμοσμένου τμήματος XML σε διαφάνεια ή σχήμα**

Τα προσαρμοσμένα δεδομένα XML μπορούν να συσχετιστούν με μια συγκεκριμένη διαφάνεια ή σχήμα αντί για ολόκληρη την παρουσίαση. Αυτό είναι χρήσιμο όταν τα μεταδεδομένα περιγράφουν μόνο ένα αντικείμενο, όπως κλειδί προτύπου, εξωτερικό αναγνωριστικό εγγραφής ή πληροφορίες σύνδεσης.

Το παρακάτω παράδειγμα προσθέτει ένα προσαρμοσμένο τμήμα XML σε μια διαφάνεια και ένα άλλο σε ένα σχήμα:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Το επίπεδο στο οποίο προστίθεται ένα τμήμα καθορίζει ποια συλλογή `CustomData.CustomXmlParts` του αντικειμένου περιέχει τη σχέση προς το τμήμα. Τα δεδομένα επιπέδου παρουσίασης είναι κατάλληλα για μεταδεδομένα σε όλο το έγγραφο, τα δεδομένα επιπέδου διαφάνειας για πληροφορίες που ανήκουν σε συγκεκριμένη διαφάνεια, και τα δεδομένα επιπέδου σχήματος για μεταδεδομένα που συνδέονται με μεμονωμένο σχήμα.

### **Λίστα και έλεγχος όλων των προσαρμοσμένων τμημάτων XML**

Χρησιμοποιήστε [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/allcustomxmlparts/) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML από μια παρουσίαση. Κάθε [`ICustomXmlPart`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpart/) εκθέτει το αναγνωριστικό του, το περιεχόμενο XML και τα συσχετισμένα σχήματα ονοματοχώρων.

Το παρακάτω παράδειγμα απαριθμεί όλα τα προσαρμοσμένα τμήματα XML και τα σχήματα ονοματοχώρων τους:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

Η ιδιότητα [`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpart/namespaceschemas/) επιστρέφει τα σχήματα XML που σχετίζονται με το προσαρμοσμένο τμήμα XML. Αυτή η πληροφορία μπορεί να είναι χρήσιμη κατά τον έλεγχο παρουσιάσεων που περιέχουν XML παραγόμενο από εξωτερικά συστήματα.

### **Ανάγνωση και ενημέρωση περιεχομένου XML και ItemId**

Χρησιμοποιήστε [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpart/xmlasstring/) για εργασία με XML ως συμβολοσειρά UTF‑8, ή [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpart/xmldata/) για εργασία με τα ακατέργαστα bytes XML. Και οι δύο ιδιότητες μπορούν να διαβαστούν και να ενημερωθούν.

Η ιδιότητα [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpart/itemid/) περιέχει το GUID που αναγνωρίζει το προσαρμοσμένο τμήμα XML στο έγγραφο Office Open XML. Μπορεί επίσης να αλλάξει όταν μια ενσωμάτωση απαιτεί νέο αναγνωριστικό.

Το παρακάτω παράδειγμα ενημερώνει το περιεχόμενο XML και το αναγνωριστικό:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Διαβάστε το τρέχον XML ως κείμενο.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Ενημερώστε το XML ως συμβολοσειρά UTF-8.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// Το XmlData παρέχει το ίδιο περιεχόμενο XML ως ακατέργαστα byte.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Αντικαταστήστε το αναγνωριστικό όταν απαιτείται από την ενσωμάτωση.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Κατά την εκχώρηση `XmlAsString` ή `XmlData`, παρέχετε έγκυρο, μη κενό XML. Χρησιμοποιήστε την μία ή την άλλη αναπαράσταση ανάλογα με το αν η εφαρμογή λειτουργεί κυρίως με συμβολοσειρές ή με δεδομένα bytes.

### **Αφαίρεση προσαρμοσμένου τμήματος XML**

Η Aspose.Slides παρέχει πολλούς τρόπους για αφαίρεση προσαρμοσμένων δεδομένων XML:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpart/remove/) αφαιρεί το προσαρμοσμένο τμήμα XML από την παρουσίαση.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpartcollection/remove/) αφαιρεί ένα συγκεκριμένο τμήμα από μια συλλογή προσαρμοσμένων τμημάτων XML.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpartcollection/removeat/) αφαιρεί το τμήμα σε συγκεκριμένη θέση της συλλογής.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/el/net/aspose.slides/icustomxmlpartcollection/clear/) αφαιρεί όλα τα τμήματα από μια συγκεκριμένη συλλογή.

Το παρακάτω παράδειγμα αφαιρεί ένα προσαρμοσμένο τμήμα XML επιπέδου παρουσίασης με αναφορά:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Εάν έχετε ήδη ένα `ICustomXmlPart` και θέλετε να αφαιρέσετε αυτό το τμήμα από την παρουσίαση αντί να απευθυνθείτε σε συγκεκριμένη συλλογή, καλέστε `customXmlPart.Remove()`.

Μπορείτε επίσης να αφαιρέσετε ένα στοιχείο με βάση το δείκτη:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Απαλοιφή όλων των προσαρμοσμένων τμημάτων XML από μια συλλογή**

Χρησιμοποιήστε `Clear` όταν πρέπει να αφαιρεθούν όλα τα προσαρμοσμένα τμήματα XML που σχετίζονται με ένα συγκεκριμένο αντικείμενο της παρουσίασης.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

Το `Clear` επηρεάζει μόνο τη συγκεκριμένη συλλογή. Για παράδειγμα, η απαλοιφή της συλλογής μιας διαφάνειας δεν καθαρίζει τις συλλογές επιπέδου παρουσίασης ή σχήματος.

Για να αφαιρεθεί κάθε προσαρμοσμένο τμήμα XML στην παρουσίαση, διατρέξτε το `AllCustomXmlParts` και αφαιρέστε κάθε τμήμα:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Διαχείριση δεσμευμένων ή κοινόχρηστων προσαρμοσμένων τμημάτων XML**

Σε μια παρουσίαση Office Open XML, το ίδιο προσαρμοσμένο τμήμα XML μπορεί να αναφέρεται από περισσότερα από ένα αντικείμενα παρουσίασης. Για παράδειγμα, ένα υπάρχον αρχείο μπορεί να περιέχει σχέσεις από πολλαπλές διαφάνειες ή σχήματα προς το ίδιο υποκείμενο προσαρμοσμένο τμήμα XML.

Ένα κοινόχρηστο τμήμα πρέπει να αντιμετωπίζεται ως ένα αντικείμενο δεδομένων με πολλαπλές αναφορές:

- Η ενημέρωση του `XmlAsString`, `XmlData` ή `ItemId` αλλάζει το υποκείμενο προσαρμοσμένο τμήμα XML, έτσι η αλλαγή ισχύει όπου και αν αναφέρεται το τμήμα.
- Το `ItemId` μπορεί να χρησιμοποιηθεί για την ταυτοποίηση του ίδιου προσαρμοσμένου τμήματος XML κατά τον έλεγχο συλλογών σε επίπεδο αντικειμένου.
- Η αφαίρεση ενός τμήματος από μια συγκεκριμένη συλλογή `CustomXmlParts` το αφαιρεί μόνο από αυτή τη συλλογή. Χρησιμοποιήστε `ICustomXmlPart.Remove()` όταν το τμήμα πρέπει να αφαιρεθεί από την παρουσίαση.
- Πριν διαγράψετε ή αντικαταστήσετε ένα κοινόχρηστο τμήμα, ελέγξτε τις συλλογές σε επίπεδο αντικειμένου για να διαπιστώσετε αν άλλες διαφάνειες ή σχήματα το αναφέρουν ακόμα.

Οι υπερφορτώσεις `Add` δημιουργούν νέο προσαρμοσμένο τμήμα XML από περιεχόμενο XML· δεν δέχονται υπάρχον `ICustomXmlPart`. Συνεπώς, οι κοινές σχέσεις συναντώνται κυρίως κατά τη φόρτωση παρουσιάσεων που τα περιέχουν ήδη.

Το παρακάτω παράδειγμα ελέγχει τις συλλογές σε επίπεδο παρουσίασης, διαφάνειας και σχήματος με βάση το `ItemId` και αναφέρει τμήματα που αναφέρονται από περισσότερα από ένα σημεία:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Αυτός ο τύπος ελέγχου είναι χρήσιμος πριν την τροποποίηση ή διαγραφή προσαρμοσμένων δεδομένων XML σε παρουσιάσεις που δημιουργήθηκαν από εξωτερικά συστήματα, επειδή το ίδιο τμήμα μεταδεδομένων μπορεί να συμμετέχει σε περισσότερες από μία σχέσεις.

## **Λήψη τιμών ετικετών**

Στις διαφάνειες, μια ετικέτα αντιστοιχεί στην ιδιότητα `IDocumentProperties.Keywords`. Αυτό το δείγμα κώδικα δείχνει πώς να λάβετε την τιμή μιας ετικέτας με Aspose.Slides for .NET για [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation):

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Προσθήκη ετικετών σε παρουσιάσεις**

Η Aspose.Slides σας επιτρέπει να προσθέτετε ετικέτες σε παρουσιάσεις. Μια ετικέτα συνήθως αποτελείται από δύο στοιχεία:

- το όνομα μιας προσαρμοσμένης ιδιότητας, π.χ. `MyTag`;
- την τιμή της προσαρμοσμένης ιδιότητας, π.χ. `My Tag Value`.

Αν χρειάζεται να ταξινομήσετε παρουσιάσεις βάσει συγκεκριμένου κανόνα ή ιδιότητας, μπορείτε να προσθέσετε ετικέτες για αυτόν τον σκοπό. Για παράδειγμα, εάν θέλετε να κατηγοριοποιήσετε παρουσιάσεις από χώρες της Βόρειας Αμερικής, μπορείτε να δημιουργήσετε μια ετικέτα «North American» και να ορίσετε τη σχετική χώρα ως τιμή της.

Αυτό το δείγμα κώδικα δείχνει πώς να προσθέσετε μια ετικέτα σε μια [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) χρησιμοποιώντας Aspose.Slides for .NET:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Μπορούν επίσης να οριστούν ετικέτες για μια [Slide](https://reference.aspose.com/slides/el/net/aspose.slides/slide):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Ή για ένα μεμονωμένο [Shape](https://reference.aspose.com/slides/el/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Περιορισμοί**

Οι ετικέτες που προστίθενται μέσω της συλλογής `CustomData.Tags` αποθηκεύονται μόνο στο αρχείο PowerPoint. Δεν **μεταφέρονται** στη δομή ετικετών PDF όταν η παρουσίαση εξάγεται σε PDF. Συνεπώς, ένα προσαρμοσμένο αναγνωριστικό που έχει οριστεί ως ετικέτα δεν μπορεί να ανακτηθεί από το PDF με ετικέτες.

**Λύση παρακάμψης**: Μπορείτε να αποθηκεύσετε ένα προσαρμοσμένο αναγνωριστικό στο **Alt Text** του αντικειμένου (π.χ., `shape.AlternativeText = "MyId"`). Μετά την εξαγωγή σε PDF, το Alt Text μπορεί να εμφανιστεί στη δομή ετικετών PDF.

## **Συχνές ερωτήσεις**

**Μπορώ να αφαιρέσω όλες τις ετικέτες από μια παρουσίαση, διαφάνεια ή σχήμα σε μία ενέργεια;**

Ναι. Η [tag collection](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/) υποστηρίζει μια λειτουργία [Clear](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/clear/) που διαγράφει όλα τα ζεύγη κλειδιού‑τιμής ταυτόχρονα.

**Πώς διαγράφω μια μόνο ετικέτα βάσει του ονόματος της χωρίς να διατρέξω ολόκληρη τη συλλογή;**

Χρησιμοποιήστε [Remove(name)](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/remove/) στη [TagCollection](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/) για να διαγράψετε την ετικέτα με το κλειδί της.

**Πώς μπορώ να ανακτήσω την πλήρη λίστα ονομάτων ετικετών για αναλύσεις ή φιλτράρισμα;**

Χρησιμοποιήστε [GetNamesOfTags](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/getnamesoftags/) στη [tag collection](https://reference.aspose.com/slides/el/net/aspose.slides/tagcollection/); επιστρέφει έναν πίνακα με όλα τα ονόματα ετικετών.

**Πώς μπορώ να βρω όλα τα προσαρμοσμένα τμήματα XML ανεξάρτητα από το πού αποθηκεύονται;**

Χρησιμοποιήστε [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/allcustomxmlparts/) για να ανακτήσετε όλα τα προσαρμοσμένα τμήματα XML στην παρουσίαση.

**Θα πρέπει να χρησιμοποιήσω `XmlAsString` ή `XmlData` για την ενημέρωση ενός προσαρμοσμένου τμήματος XML;**

Χρησιμοποιήστε `XmlAsString` όταν η εφαρμογή εργάζεται με κείμενο XML UTF‑8. Χρησιμοποιήστε `XmlData` όταν το XML είναι ήδη διαθέσιμο ως πίνακας byte ή όταν η επεξεργασία σε δυαδική μορφή είναι πιο βολική. Και οι δύο ιδιότητες αντιπροσωπεύουν το ίδιο περιεχόμενο XML του προσαρμοσμένου τμήματος.