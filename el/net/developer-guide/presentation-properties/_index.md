---
title: "Διαχείριση Ιδιοτήτων Παρουσίασης σε .NET"
linktitle: "Ιδιότητες Παρουσίασης"
type: docs
weight: 70
url: /el/net/presentation-properties/
keywords:
  - "Ιδιότητες PowerPoint"
  - "Ιδιότητες παρουσίασης"
  - "Ιδιότητες εγγράφου"
  - "Ενσωματωμένες ιδιότητες"
  - "Προσαρμοσμένες ιδιότητες"
  - "Προηγμένες ιδιότητες"
  - "Διαχείριση ιδιοτήτων"
  - "Τροποποίηση ιδιοτήτων"
  - "Μεταδεδομένα εγγράφου"
  - "Επεξεργασία μεταδεδομένων"
  - "Γλώσσα επιμέλειας"
  - "Προεπιλεγμένη γλώσσα"
  - "PowerPoint"
  - "OpenDocument"
  - "παρουσίαση"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "Διαχειριστείτε τις ιδιότητες παρουσίασης στο Aspose.Slides για .NET και βελτιστοποιήστε την αναζήτηση, την επωνυμία και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides for .NET υποστηρίζει δύο τύπους ιδιοτήτων εγγράφου: **Ενσωματωμένες** και **Προσαρμοσμένες**. Και οι δύο τύποι ιδιοτήτων μπορούν εύκολα να προσπελαστούν και να διαχειριστούν μέσω του API του Aspose.Slides for .NET.

Το Aspose.Slides σας επιτρέπει να εργάζεστε με τις ιδιότητες του εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/). Μία παρουσία αυτής της διεπαφής επιστρέφεται από το [IPresentation.DocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/documentproperties/). Τα παρακάτω παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Σημείωση" %}}

Παρακαλούμε σημειώστε ότι τα πεδία **Application** και **Producer** δεν μπορούν να τροποποιηθούν, καθώς αυτά τα πεδία εμφανίζουν πάντα "Aspose Ltd." και "Aspose.Slides for .NET x.x.x".

{{% /alert %}} 

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Το Microsoft PowerPoint παρέχει μια δυνατότητα προσθήκης ιδιοτήτων σε αρχεία παρουσίασης. Αυτές οι ιδιότητες εγγράφου επιτρέπουν την αποθήκευση χρήσιμων πληροφοριών μαζί με τα αρχεία. Υπάρχουν δύο τύποι ιδιοτήτων εγγράφου:

- Ιδιότητες ορισμένες από το σύστημα (ενσωματωμένες)
- Ιδιότητες ορισμένες από τον χρήστη (προσαρμοσμένες)

Οι **ενσωματωμένες** ιδιότητες περιέχουν γενικές πληροφορίες για το έγγραφο, όπως ο τίτλος του εγγράφου, το όνομα του δημιουργού, στατιστικά του εγγράφου και άλλα.

Οι **προσαρμοσμένες** ιδιότητες ορίζονται από τους χρήστες ως ζεύγη **Όνομα/Τιμή**, όπου τόσο το όνομα όσο και η τιμή καθορίζονται από τον χρήστη.

Με το Aspose.Slides for .NET, οι προγραμματιστές μπορούν να έχουν πρόσβαση και να τροποποιούν τόσο ενσωματωμένες όσο και προσαρμοσμένες ιδιότητες.

Το Microsoft PowerPoint επιτρέπει στους χρήστες να διαχειρίζονται τις ιδιότητες εγγράφου κάνοντας κλικ στο εικονίδιο Office, στη συνέχεια επιλέγοντας **File → Info → Properties**. Αφού επιλέξετε **Advanced Properties**, εμφανίζεται ένας διάλογος όπου μπορείτε να διαχειριστείτε όλες τις ιδιότητες εγγράφου του αρχείου παρουσίασης.

Στον διάλογο **Properties**, υπάρχουν αρκετές καρτέλες, όπως **General**, **Summary**, **Statistics**, **Contents** και **Custom**. Κάθε καρτέλα παρέχει επιλογές για τη ρύθμιση συγκεκριμένων τύπων πληροφοριών που σχετίζονται με το αρχείο PowerPoint. Η καρτέλα **Custom** χρησιμοποιείται για τη διαχείριση ιδιοτήτων που ορίζονται από τον χρήστη.

## **Ανάγνωση Δημόσιων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός ανοίγματος προστατεύει κανονικά τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες εγγράφου. Όταν η παρουσίαση κρυπτογραφείται με το [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) ορισμένο σε `false`, οι ιδιότητες εγγράφου παραμένουν δημόσιες. Μία εφαρμογή μπορεί τότε να ορίσει το [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) σε `true` και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να δώσει τον κωδικό ανοίγματος.

`OnlyLoadDocumentProperties` ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Εάν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφηση, η φόρτωση τους χωρίς κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται η πλήρη παρουσίαση.

Το παρακάτω παράδειγμα ελέγχει τη λειτουργία φόρτωσης μέσω του [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/el/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) και στη συνέχεια διαβάζει ενσωματωμένες ιδιότητες μέσω του [IPresentation.DocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentation/documentproperties/):

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφανειών δεν φορτώνεται. Διευθύνσεις διαφανειών, master, layout, σχήματα, πολυμέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές θα πρέπει πάντα να ελέγχουν το `IsOnlyDocumentPropertiesLoaded` πριν πραγματοποιήσουν ενέργεια που απαιτεί το πλήρες μοντέλο αντικειμένων παρουσίασης.

{{% alert color="warning" title="Ασφάλεια" %}}
Τα δημόσια μεταδεδομένα μπορεί να αποκαλύψουν ονόματα δημιουργών, τίτλους, θέματα, λέξεις‑κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Διατηρήστε τις δημόσιες μόνο όταν συστήματα ευρετηρίασης, ταξινόμησης, αναζήτησης ή διαχείρισης εγγράφων έχουν συγκεκριμένη απαίτηση πρόσβασης χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίασης**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται με `OnlyLoadDocumentProperties` προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο‑με‑μεταδεδομένα, επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν συνεπείς με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί επομένως τον σωστό κωδικό ανοίγματος και πλήρη φόρτωση.

Το παρακάτω παράδειγμα ανοίγει την παρουσίαση με το [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί το [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/isencrypted/) για να επαληθεύσει ότι η κρυπτογράφηση διατηρήθηκε και ανοίγει ξανά τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Εάν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο‑ανάγνωση.

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**

Αυτές οι ιδιότητες, όπως εκτίθενται από τη διεπαφή [IDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/idocumentproperties/), περιλαμβάνουν: **Creator** (Συγγραφέας), **Description**, **Keywords**, **Created** (Ημερομηνία Δημιουργίας), **Modified** (Ημερομηνία Τροποποίησης), **Printed** (Τελευταία Εκτύπωση), **LastModifiedBy**, **SharedDoc** (δείχνει εάν το έγγραφο είναι κοινόχρηστο μεταξύ διαφορετικών παραγωγών), **PresentationFormat**, **Subject**, **Title** και άλλα.

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

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Η τροποποίηση των ενσωματωμένων ιδιοτήτων αρχείων παρουσίασης είναι εξίσου εύκολη με την πρόσβαση σε αυτές. Απλώς αναθέστε μια τιμή συμβολοσειράς σε οποιαδήποτε επιθυμητή ιδιότητα και η τιμή της ιδιότητας θα ενημερωθεί. Στο παρακάτω παράδειγμα δείχνουμε πώς να τροποποιήσετε τις ενσωματωμένες ιδιότητες εγγράφου μιας παρουσίασης.

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

Οι προσαρμοσμένες ιδιότητες παρουσίασης επιτρέπουν στους προγραμματιστές να αποθηκεύουν επιπλέον μεταδεδομένα ή συγκεκριμένες πληροφορίες μέσα σε ένα αρχείο παρουσίασης. Το Aspose.Slides κάνει εύκολη τη δημιουργία και διαχείριση αυτών των προσαρμοσμένων ιδιοτήτων προγραμματιστικά. Τα παρακάτω παραδείγματα δείχνουν πώς να προσθέσετε προσαρμοσμένες ιδιότητες στις παρουσιάσεις σας.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation.
using Presentation presentation = new Presentation();

// Λήξη αναφοράς στο αντικείμενο τύπου IDocumentProperties που σχετίζεται με την παρουσίαση.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Προσθήκη προσαρμοσμένων ιδιοτήτων.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Αποθήκευση της παρουσίασης σε αρχείο.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Το Aspose.Slides επιτρέπει επίσης στους προγραμματιστές να έχουν πρόσβαση σε υπάρχουσες προσαρμοσμένες ιδιότητες και να τροποποιούν τις τιμές τους εύκολα. Αυτή η λειτουργικότητα βοηθά στη διατήρηση ακριβών μεταδεδομένων και υποστηρίζει δυναμικές ενημερώσεις βάσει εισόδου χρήστη ή επιχειρηματικής λογικής. Τα παραδείγματα παρακάτω απεικονίζουν πώς να ανακτήσετε και να ενημερώσετε τις τιμές προσαρμοσμένων ιδιοτήτων μέσα σε μια παρουσίαση.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Δημιουργία της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο PPTX.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Λήψη αναφοράς στο αντικείμενο τύπου IDocumentProperties που σχετίζεται με την παρουσίαση.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Πρόσβαση και τροποποίηση προσαρμοσμένων ιδιοτήτων.
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

Δοκιμάστε την online εφαρμογή [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/el/metadata) για να δείτε πώς λειτουργούν οι ιδιότητες εγγράφου με το API του Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/el/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες είναι ενσωματωμένο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν πλήρως. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις θέσετε σε κενό εάν το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω προσαρμοσμένη ιδιότητα που υπάρχει ήδη;**

Αν προσθέσετε προσαρμοσμένη ιδιότητα που υπάρχει ήδη, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να έχω πρόσβαση στις ιδιότητες της παρουσίασης χωρίς να φορτώνω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε το [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/el/net/aspose.slides/presentationfactory/getpresentationinfo/) και στη συνέχεια το [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/el/net/aspose.slides/ipresentationinfo/readdocumentproperties/) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα εγγράφου χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Δείτε το [Build a Lightweight Presentation Inventory](/slides/el/net/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμούς ανά μορφή.

**Μπορώ να διαβάσω δημόσιες ιδιότητες κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος;**

Ναι. Η παρουσίαση πρέπει να έχει κρυπτογραφηθεί με `EncryptDocumentProperties` ορισμένο σε `false` και να φορτωθεί με `OnlyLoadDocumentProperties` ορισμένο σε `true`.

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX στη λειτουργία μόνο‑ιδιότητες‑εγγράφου;**

Όχι. Τα δημόσια και κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμένουν συνεπή, επομένως η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί τη φόρτωση της πλήρους παρουσίασης με τον σωστό κωδικό ανοίγματος.