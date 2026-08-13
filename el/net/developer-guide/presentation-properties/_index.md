---
title: Διαχείριση Ιδιοτήτων Παρουσίασης σε .NET
linktitle: Ιδιότητες Παρουσίασης
type: docs
weight: 70
url: /el/net/presentation-properties/
keywords:
- Ιδιότητες PowerPoint
- Ιδιότητες παρουσίασης
- Ιδιότητες εγγράφου
- Προκαθορισμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προηγμένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα ελέγχου
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Κυριαρχήστε τις ιδιότητες παρουσίασης στο Aspose.Slides for .NET και εξορθολογίστε την αναζήτηση, την επωνυμία και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides for .NET υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσπελαστούν και να διαχειριστούν μέσω του Aspose.Slides for .NET API.

Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/). Μια παρουσία της διεπαφής αυτής επιστρέφεται από την ιδιότητα [Presentation.DocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/documentproperties/). Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" %}} 

Παρακαλώ σημειώστε ότι τα πεδία **Application** και **Producer** δεν μπορούν να τροποποιηθούν, καθώς αυτά τα πεδία θα εμφανίζουν πάντα "Aspose Ltd." και "Aspose.Slides for .NET x.x.x".

{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει μια δυνατότητα προσθήκης ιδιοτήτων σε αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα αρχεία. Υπάρχουν δύο τύποι ιδιοτήτων εγγράφου:

- Ιδιότητες που ορίζονται από το σύστημα (built‑in)
- Ιδιότητες που ορίζονται από τον χρήστη (custom)

**Built-in** ιδιότητες περιλαμβάνουν γενικές πληροφορίες για το έγγραφο, όπως ο τίτλος του εγγράφου, το όνομα του δημιουργού, στατιστικά του εγγράφου κ.ά.

**Custom** ιδιότητες ορίζονται από το χρήστη ως ζεύγη **Name/Value**, όπου τόσο το όνομα όσο και η τιμή καθορίζονται από τον χρήστη.

Με τη χρήση του Aspose.Slides for .NET, οι προγραμματιστές μπορούν να έχουν πρόσβαση και να τροποποιούν και τις προκαθορισμένες και τις προσαρμοσμένες ιδιότητες.

Το Microsoft PowerPoint επιτρέπει στους χρήστες να διαχειρίζονται τις ιδιότητες εγγράφου κάνοντας κλικ στο εικονίδιο Office, έπειτα επιλέγοντας **File → Info → Properties**. Αφού επιλεγούν **Advanced Properties**, εμφανίζεται ένα παράθυρο διαλόγου όπου μπορείτε να διαχειριστείτε όλες τις ιδιότητες εγγράφου του αρχείου παρουσίασης.

Στο παράθυρο **Properties**, υπάρχουν αρκετές καρτέλες, όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Κάθε καρτέλα προσφέρει επιλογές για ρύθμιση συγκεκριμένων τύπων πληροφοριών σχετικών με το αρχείο PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση ιδιοτήτων που ορίζονται από τον χρήστη.

## **Πρόσβαση σε Προκαθορισμένες Ιδιότητες**

Αυτές οι ιδιότητες, όπως εκτίθενται από τη διεπαφή [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/), περιλαμβάνουν: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (indicates whether the document is shared between different producers), **PresentationFormat**, **Subject**, **Title**, κ.ά.

```cs
using Aspose.Slides;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
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

## **Τροποποίηση Προκαθορισμένων Ιδιοτήτων**

Η τροποποίηση των προκαθορισμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο απλή όσο η πρόσβαση σε αυτές. Απλώς μπορείτε να αναθέσετε μια τιμή συμβολοσειράς σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα ενημερωθεί. Στο παρακάτω παράδειγμα, δείχνουμε πώς να τροποποιήσετε τις προκαθορισμένες ιδιότητες εγγράφου ενός αρχείου παρουσίασης.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Λήψη αναφοράς στο αντικείμενο τύπου IDocumentProperties που σχετίζεται με την παρουσίαση.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Ορισμός των προκαθορισμένων ιδιοτήτων.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Αποθήκευση της παρουσίασης σε αρχείο.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Οι προσαρμοσμένες ιδιότητες παρουσίασης επιτρέπουν στους προγραμματιστές να αποθηκεύουν επιπλέον μεταδεδομένα ή συγκεκριμένες πληροφορίες μέσα σε ένα αρχείο παρουσίασης. Το Aspose.Slides καθιστά εύκολη τη δημιουργία και τη διαχείριση αυτών των προσαρμοσμένων ιδιοτήτων προγραμματικά. Τα παρακάτω παραδείγματα δείχνουν πώς να προσθέσετε προσαρμοσμένες ιδιότητες στις παρουσιάσεις σας.

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

Το Aspose.Slides επίσης επιτρέπει στους προγραμματιστές να έχουν πρόσβαση σε υπάρχουσες προσαρμοσμένες ιδιότητες και να τροποποιούν τις τιμές τους εύκολα. Αυτή η δυνατότητα βοηθά στη διατήρηση ακριβών μεταδεδομένων και υποστηρίζει δυναμικές ενημερώσεις βάσει εισόδου χρήστη ή επιχειρησιακής λογικής. Τα παρακάτω παραδείγματα δείχνουν πώς να ανακτήσετε και να ενημερώσετε τιμές προσαρμοσμένων ιδιοτήτων μέσα σε μια παρουσίαση.

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

Δοκιμάστε την εφαρμογή online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να δουλέψετε με ιδιότητες εγγράφου χρησιμοποιώντας το Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## ***ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

### Πώς μπορώ να αφαιρέσω μια προκαθορισμένη ιδιότητα από μια παρουσίαση;

Οι προκαθορισμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε σε κενό, εφόσον η συγκεκριμένη ιδιότητα το επιτρέπει.

### Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

### Μπορώ να έχω πρόσβαση σε ιδιότητες παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;

Ναι, μπορείτε να έχετε πρόσβαση σε ιδιότητες παρουσίασης χωρίς να φορτώσετε πλήρως την παρουσίαση χρησιμοποιώντας τη μέθοδο `GetPresentationInfo` από την κλάση [PresentationFactory](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/). Στη συνέχεια, χρησιμοποιήστε τη μέθοδο `ReadDocumentProperties` που παρέχεται από τη διεπαφή [IPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/) για να διαβάσετε τις ιδιότητες αποδοτικά, εξοικονομώντας μνήμη και βελτιώνοντας την απόδοση.