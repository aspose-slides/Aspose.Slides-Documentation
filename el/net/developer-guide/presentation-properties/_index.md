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
- Ενσωματωμένες ιδιότητες
- Προσαρμοσμένες ιδιότητες
- Προχωρημένες ιδιότητες
- Διαχείριση ιδιοτήτων
- Τροποποίηση ιδιοτήτων
- Μεταδεδομένα εγγράφου
- Επεξεργασία μεταδεδομένων
- Γλώσσα επαλήθευσης
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- Παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Κατακτήστε τις ιδιότητες παρουσίασης στο Aspose.Slides για .NET και βελτιώστε την αναζήτηση, την εμπορευματοποίηση και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides for .NET υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Built-in** και **Custom**. Και οι δύο αυτές τύποι ιδιοτήτων μπορούν εύκολα να προσεγγιστούν και να διαχειριστούν χρησιμοποιώντας το API του Aspose.Slides for .NET.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/). Μια παρουσίαση αυτής της διεπαφής επιστρέφεται από την ιδιότητα [Presentation.DocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/documentproperties/). Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="primary" %}} 
Παρακαλούμε σημειώστε ότι τα πεδία **Application** και **Producer** δεν μπορούν να τροποποιηθούν, καθώς αυτά τα πεδία θα εμφανίζουν πάντα "Aspose Ltd." και "Aspose.Slides for .NET x.x.x".
{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει μια λειτουργία για την προσθήκη ιδιοτήτων σε αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα αρχεία. Υπάρχουν δύο τύποι ιδιοτήτων εγγράφου:

- Ιδιότητες που ορίζονται από το σύστημα (built-in)
- Ιδιότητες που ορίζονται από τον χρήστη (custom)

**Built-in** ιδιότητες περιέχουν γενικές πληροφορίες για το έγγραφο, όπως ο τίτλος του εγγράφου, το όνομα του συγγραφέα, στατιστικά του εγγράφου και άλλα.

**Custom** ιδιότητες ορίζονται από τους χρήστες ως ζεύγη **Name/Value**, όπου τόσο το όνομα όσο και η τιμή καθορίζονται από τον χρήστη.

Χρησιμοποιώντας το Aspose.Slides for .NET, οι προγραμματιστές μπορούν να προσπελάσουν και να τροποποιήσουν τόσο τις ενσωματωμένες όσο και τις προσαρμοσμένες ιδιότητες.

Το Microsoft PowerPoint επιτρέπει στους χρήστες να διαχειρίζονται τις ιδιότητες εγγράφου κάνοντας κλικ στο εικονίδιο Office, στη συνέχεια επιλέγοντας **File → Info → Properties**. Αφού επιλέξετε **Advanced Properties**, εμφανίζεται ένας διάλογος όπου μπορείτε να διαχειριστείτε όλες τις ιδιότητες εγγράφου του αρχείου παρουσίασης.

Στον διάλογο **Properties**, υπάρχουν πολλαπλές καρτέλες, όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Κάθε καρτέλα παρέχει επιλογές για τη διαμόρφωση συγκεκριμένων τύπων πληροφοριών που σχετίζονται με το αρχείο PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση ιδιοτήτων που ορίζονται από τον χρήστη.

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**

Αυτές οι ιδιότητες, όπως αποκαλύπτονται από τη διεπαφή [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/), περιλαμβάνουν: **Creator** (Συγγραφέας), **Description**, **Keywords**, **Created** (Ημερομηνία Δημιουργίας), **Modified** (Ημερομηνία Τροποποίησης), **Printed** (Ημερομηνία Τελευταίας Εκτύπωσης), **LastModifiedBy**, **SharedDoc** (σημαίνει εάν το έγγραφο είναι κοινόχρηστο μεταξύ διαφορετικών παραγωγών), **PresentationFormat**, **Subject**, **Title**, και άλλα.

```cs
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
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

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων των αρχείων παρουσίασης είναι τόσο εύκολη όσο η πρόσβαση σε αυτές. Μπορείτε απλώς να αντιστοιχίσετε μια τιμή κειμένου σε οποιαδήποτε επιθυμητή ιδιότητα, και η τιμή της ιδιότητας θα ενημερωθεί. Στο παρακάτω παράδειγμα, δείχνουμε πώς να τροποποιήσετε τις ενσωματωμένες ιδιότητες εγγράφου ενός αρχείου παρουσίασης.

```cs
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Λάβετε μια αναφορά στο αντικείμενο τύπου IDocumentProperties που σχετίζεται με την παρουσίαση.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Ορίστε τις ενσωματωμένες ιδιότητες.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Αποθηκεύστε την παρουσίαση σε ένα αρχείο.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Οι προσαρμοσμένες ιδιότητες παρουσίασης επιτρέπουν στους προγραμματιστές να αποθηκεύουν πρόσθετα μεταδεδομένα ή συγκεκριμένες πληροφορίες μέσα σε ένα αρχείο παρουσίασης. Το Aspose.Slides διευκολύνει τη δημιουργία και τη διαχείριση αυτών των προσαρμοσμένων ιδιοτήτων προγραμματιστικά. Τα παρακάτω παραδείγματα δείχνουν πώς να προσθέσετε προσαρμοσμένες ιδιότητες στις παρουσιάσεις σας.

```cs
// Δημιουργήστε την κλάση Presentation.
using Presentation presentation = new Presentation();

// Λάβετε μια αναφορά στο αντικείμενο τύπου IDocumentProperties που σχετίζεται με την παρουσίαση.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Προσθέστε προσαρμοσμένες ιδιότητες.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Αποθηκεύστε την παρουσίαση σε ένα αρχείο.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides επιτρέπει επίσης στους προγραμματιστές να προσπελάσουν υπάρχουσες προσαρμοσμένες ιδιότητες και να τροποποιήσουν εύκολα τις τιμές τους. Αυτή η λειτουργικότητα βοηθά στη διατήρηση ακριβών μεταδεδομένων και υποστηρίζει δυναμικές ενημερώσεις βάσει εισαγωγών χρήστη ή επιχειρηματικής λογικής. Τα παρακάτω παραδείγματα δείχνουν πώς να ανακτήσετε και να ενημερώσετε τις τιμές προσαρμοσμένων ιδιοτήτων εντός μιας παρουσίασης.

```cs
// Δημιουργήστε την κλάση Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Λάβετε μια αναφορά στο αντικείμενο τύπου IDocumentProperties που σχετίζεται με την παρουσίαση.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Πρόσβαση και τροποποίηση των προσαρμοσμένων ιδιοτήτων.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Εμφανίστε το όνομα και την τιμή της προσαρμοσμένης ιδιότητας.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Τροποποιήστε την τιμή της προσαρμοσμένης ιδιότητας.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Αποθηκεύστε την παρουσίαση σε ένα αρχείο.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την online εφαρμογή [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου χρησιμοποιώντας το Aspose.Slides API:

[![Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## ***Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν ουσιώδες μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις ορίσετε κενές εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Εάν προσθέσετε μια προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να προσπελάσω τις ιδιότητες παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι, μπορείτε να προσπελάσετε τις ιδιότητες παρουσίασης χωρίς να φορτώσετε πλήρως την παρουσίαση χρησιμοποιώντας τη μέθοδο `GetPresentationInfo` από την κλάση [PresentationFactory](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/). Στη συνέχεια, χρησιμοποιήστε τη μέθοδο `ReadDocumentProperties` που παρέχεται από τη διεπαφή [IPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/) για να διαβάσετε τις ιδιότητες αποδοτικά, εξοικονομώντας μνήμη και βελτιώνοντας την απόδοση.