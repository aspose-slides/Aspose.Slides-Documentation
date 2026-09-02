---
title: Διαχείριση Ιδιοτήτων Παρουσίασης στο .NET
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/net/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- Ιδιότητες παρουσίασης
- Ιδιότητες εγγράφου
- Ενσωματωμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προηγμένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα επιμέλειας
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Κατακτήστε τις ιδιότητες παρουσίασης στο Aspose.Slides για .NET και βελτιστοποιήστε την αναζήτηση, το branding και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides for .NET υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσεγγιστούν και να διαχειριστούν χρησιμοποιώντας το API του Aspose.Slides for .NET.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/). Μια παρουσία της διεπαφής αυτής επιστρέφεται από την ιδιότητα [Presentation.DocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/documentproperties/). Τα ακόλουθα παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Σημείωση" %}}
Παρακαλούμε σημειώστε ότι τα πεδία **Application** και **Producer** δεν μπορούν να τροποποιηθούν, καθώς αυτά τα πεδία θα εμφανίζουν πάντα "Aspose Ltd." και "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει μια λειτουργία για την προσθήκη ιδιοτήτων σε αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα αρχεία. Υπάρχουν δύο τύποι ιδιοτήτων εγγράφου:

- Ιδιότητες ορισμένες από το σύστημα (built-in)
- Ιδιότητες ορισμένες από τον χρήστη (custom)

Οι **Built-in** ιδιότητες περιέχουν γενικές πληροφορίες για το έγγραφο, όπως ο τίτλος του εγγράφου, το όνομα του συγγραφέα, στατιστικά του εγγράφου κ.λπ.

Οι **Custom** ιδιότητες ορίζονται από τους χρήστες ως ζεύγη **Name/Value**, όπου τόσο το όνομα όσο και η τιμή καθορίζονται από τον χρήστη.

Χρησιμοποιώντας το Aspose.Slides for .NET, οι προγραμματιστές μπορούν να προσπελάσουν και να τροποποιήσουν τόσο τις ενσωματωμένες όσο και τις προσαρμοσμένες ιδιότητες.

Το Microsoft PowerPoint επιτρέπει στους χρήστες να διαχειρίζονται τις ιδιότητες εγγράφου κάνοντας κλικ στο εικονίδιο του Office, έπειτα επιλέγοντας **File → Info → Properties**. Αφού επιλέξετε **Advanced Properties**, εμφανίζεται ένας διάλογος όπου μπορείτε να διαχειριστείτε όλες τις ιδιότητες εγγράφου του αρχείου παρουσίασης.

Στον διάλογο **Properties**, υπάρχουν αρκετές καρτέλες, όπως **General**, **Summary**, **Statistics**, **Contents**, και **Custom**. Κάθε καρτέλα παρέχει επιλογές για τη διαμόρφωση συγκεκριμένων τύπων πληροφοριών που σχετίζονται με το αρχείο PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση ιδιοτήτων ορισμένων από τον χρήστη.

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**

Αυτές οι ιδιότητες, όπως εκτίθενται από τη διεπαφή [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/), περιλαμβάνουν: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (δείχνει εάν το έγγραφο μοιράζεται μεταξύ διαφορετικών παραγωγών), **PresentationFormat**, **Subject**, **Title** και άλλα.

```cs
using Aspose.Slides;

// Δημιουργία μιας παρουσίας της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Λήψη αναφοράς στο αντικείμενο τύπου IDocumentProperties που σχετίζεται με την παρουσίαση.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Εμφάνιση των ενσωματωμένων ιδιοτήτων.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων αρχείων παρουσίασης είναι εξίσου εύκολη με την πρόσβασή τους. Απλώς εκχωρείτε μια τιμή συμβολοσειράς σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα ενημερωθεί. Στο παρακάτω παράδειγμα, δείχνουμε πώς να τροποποιήσετε τις ενσωματωμένες ιδιότητες εγγράφου ενός αρχείου παρουσίασης.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Λήψη αναφοράς στο αντικείμενο τύπου IDocumentProperties που σχετίζεται με την παρουσίαση.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Ορισμός των ενσωματωμένων ιδιοτήτων.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Αποθήκευση της παρουσίασης σε αρχείο.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Οι προσαρμοσμένες ιδιότητες παρουσίασης επιτρέπουν στους προγραμματιστές να αποθηκεύουν πρόσθετα μεταδεδομένα ή συγκεκριμένες πληροφορίες μέσα σε ένα αρχείο παρουσίασης. Το Aspose.Slides κάνει εύκολη τη δημιουργία και τη διαχείριση αυτών των προσαρμοσμένων ιδιοτήτων προγραμματιστικά. Τα ακόλουθα παραδείγματα δείχνουν πώς να προσθέσετε προσαρμοσμένες ιδιότητες στις παρουσιάσεις σας.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation.
using Presentation presentation = new Presentation();

// Λήψη αναφοράς στο αντικείμενο τύπου IDocumentProperties που σχετίζεται με την παρουσίαση.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Προσθήκη προσαρμοσμένων ιδιοτήτων.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Αποθήκευση της παρουσίασης σε αρχείο.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides επιτρέπει επίσης στους προγραμματιστές να προσπελάσουν υπάρχουσες προσαρμοσμένες ιδιότητες και να τροποποιήσουν τις τιμές τους εύκολα. Αυτή η λειτουργικότητα βοηθά στη διατήρηση ακριβών μεταδεδομένων και υποστηρίζει δυναμικές ενημερώσεις βάσει εισόδου χρήστη ή επιχειρηματικής λογικής. Τα παρακάτω παραδείγματα απεικονίζουν πώς να ανακτήσετε και να ενημερώσετε τις τιμές προσαρμοσμένων ιδιοτήτων μέσα σε μια παρουσίαση.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Λήψη αναφοράς στο αντικείμενο τύπου IDocumentProperties που σχετίζεται με την παρουσίαση.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Πρόσβαση και τροποποίηση των προσαρμοσμένων ιδιοτήτων.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Εμφάνιση του ονόματος και της τιμής της προσαρμοσμένης ιδιότητας.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Τροποποίηση της τιμής της προσαρμοσμένης ιδιότητας.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Αποθήκευση της παρουσίασης σε αρχείο.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την εφαρμογή online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου χρησιμοποιώντας το API του Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **FAQ**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε κενές εφόσον η συγκεκριμένη ιδιότητα το επιτρέπει.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/getpresentationinfo/) και στη συνέχεια [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/readdocumentproperties/) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε μια παρουσία [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Δείτε το [Build a Lightweight Presentation Inventory](/slides/el/net/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμών ανά μορφή.