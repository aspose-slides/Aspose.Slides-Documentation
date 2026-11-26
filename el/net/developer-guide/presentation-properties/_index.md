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
- Γλώσσα διόρθωσης
- Προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Διαχειριστείτε τις κύριες ιδιότητες παρουσίασης στο Aspose.Slides για .NET και βελτιστοποιήστε την αναζήτηση, την επωνυμία και τη ροή εργασίας στα αρχεία PowerPoint και OpenDocument σας."
---
## **Εισαγωγή**

Το Aspose.Slides για .NET υποστηρίζει **ενσωματωμένες** και **προσαρμοσμένες** ιδιότητες εγγράφου. Χρησιμοποιήστε αυτές τις ιδιότητες για να διαβάσετε και να ενημερώσετε τα μεταδεδομένα της παρουσίασης, όπως ο συγγραφέας, ο τίτλος και οι τιμές που ορίζονται από τον χρήστη.

Το Aspose.Slides σας επιτρέπει να εργαστείτε με τις ιδιότητες εγγράφου παρουσίασης μέσω της διεπαφής [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/). Μια παρουσία της διεπαφής αυτής επιστρέφεται από το [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Τα ακόλουθα παραδείγματα δείχνουν πώς να διαβάσετε, να τροποποιήσετε και να διαχειριστείτε αυτές τις ιδιότητες.

{{% alert color="info" title="Note" %}}
Το Aspose.Slides διαχειρίζεται τα μεταδεδομένα της εφαρμογής και του δημιουργού κατά την αποθήκευση παρουσιάσεων· αυτά τα πεδία αναγνωρίζουν το λογισμικό που δημιούργησε το αποτέλεσμα.
{{% /alert %}}

## **Διαχείριση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες εγγράφου αποθηκεύουν περιγραφικές πληροφορίες παράλληλα με το περιεχόμενο της παρουσίασης. Κατατάσσονται σε δύο κατηγορίες:

- **Ενσωματωμένες ιδιότητες** περιέχουν τυπικά μεταδεδομένα, όπως ο τίτλος, ο συγγραφέας και τα στατιστικά του εγγράφου.
- **Προσαρμοσμένες ιδιότητες** αποθηκεύουν ζεύγη ονομασίας/τιμής που ορίζονται από τον χρήστη.

Το Aspose.Slides για .NET παρέχει πρόσβαση και στις δύο κατηγορίες. Στο PowerPoint, επιλέξτε **File → Info → Properties → Advanced Properties** για να ελέγξετε τα μεταδεδομένα του εγγράφου. Ο διάλογος ομαδοποιεί τις πληροφορίες σε καρτέλες όπως **Summary**, **Statistics**, **Contents** και **Custom**. Χρησιμοποιήστε την καρτέλα **Custom** για να διαχειριστείτε τις ιδιότητες που ορίζονται από τον χρήστη.

## **Ανάγνωση Δημόσιων Ιδιοτήτων από Κρυπτογραφημένη Παρουσίαση**

Ένας κωδικός πρόσβασης άνοιγμα προστατεύει συνήθως τόσο το περιεχόμενο της παρουσίασης όσο και τις ιδιότητες εγγράφου. Όταν μια παρουσίαση κρυπτογραφείται με την μέθοδο [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) ορισμένη σε `false`, οι ιδιότητές της παραμένουν δημόσιες. Μία εφαρμογή μπορεί τότε να ορίσει το [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) σε `true` και να διαβάσει τα δημόσια μεταδεδομένα χωρίς να παρέχει τον κωδικό άνοιγμα.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ελέγχει τι φορτώνει το Aspose.Slides· δεν αποκρυπτογραφεί τίποτα. Αν οι ιδιότητες περιλαμβάνονταν στην κρυπτογράφηση, η φόρτωση χωρίς κωδικό αποτυγχάνει. Εάν η παρουσίαση δεν είναι κρυπτογραφημένη, η επιλογή αγνοείται και φορτώνεται ολόκληρη η παρουσίαση.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση της οποίας οι ιδιότητες εγγράφου έχουν μείνει δημόσιες. Επαληθεύει τη λειτουργία φόρτωσης μέσω του [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) και στη συνέχεια διαβάζει τις ενσωματωμένες ιδιότητες μέσω του [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/):
```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

Σε αυτή τη λειτουργία, το περιεχόμενο των διαφάνειων δεν φορτώνεται. Οι διαφάνειες, τα master, τα layouts, τα σχήματα, τα πολυμέσα και άλλα αντικείμενα παρουσίασης δεν είναι διαθέσιμα. Οι εφαρμογές πρέπει πάντα να ελέγχουν το [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) πριν εκτελέσουν ενέργεια που απαιτεί το πλήρες μοντέλο αντικειμένων της παρουσίασης.

{{% alert color="warning" title="Security" %}}
Τα δημόσια μεταδεδομένα ενδέχεται να εκθέτουν ονόματα συγγραφέα, τίτλους, θέματα, λέξεις-κλειδιά, πληροφορίες εταιρείας, σχόλια και προσαρμοσμένες τιμές. Κρυπτογραφήστε τις ευαίσθητες ιδιότητες μαζί με την παρουσίαση. Κρατήστε τις δημόσιες μόνο όταν η ευρετηρίαση, η ταξινόμηση, η αναζήτηση ή τα συστήματα διαχείρισης εγγράφων έχουν συγκεκριμένη ανάγκη πρόσβασης χωρίς κωδικό.
{{% /alert %}}

## **Ενημέρωση Ιδιοτήτων Κρυπτογραφημένης Παρουσίασης**

Για ένα κρυπτογραφημένο αρχείο PPTX, μια παρουσίαση που φορτώνεται με το [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) προορίζεται για ανάγνωση δημόσιων μεταδεδομένων. Το Aspose.Slides δεν μπορεί να αποθηκεύσει τις αλλαγμένες ιδιότητες από αυτό το αντικείμενο μόνο-με-μεταδεδομένα, επειδή οι δημόσιες ιδιότητες πρέπει να παραμείνουν σύμφωνες με τα αντίστοιχα δεδομένα μέσα στην κρυπτογραφημένη παρουσίαση. Η ενημέρωσή τους απαιτεί επομένως το σωστό κωδικό πρόσβασης ανοίγματος και πλήρη φόρτωση.

Το παράδειγμα απαιτεί μια κρυπτογραφημένη παρουσίαση PPTX με δημόσιες ιδιότητες εγγράφου και γνωστό κωδικό ανοίγματος. Ανοίγει τη πλήρη παρουσίαση με το [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/), ενημερώνει τις δημόσιες ενσωματωμένες ιδιότητες και αποθηκεύει το αποτέλεσμα. Στη συνέχεια χρησιμοποιεί το [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) για να επαληθεύσει ότι η κρυπτογράφηση διατηρείται και ξαναανοίγει τα δημόσια μεταδεδομένα χωρίς κωδικό για να ελέγξει τις νέες τιμές:
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

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

Εάν μια εφαρμογή δεν επιτρέπεται να αποκρυπτογραφήσει ή να φορτώσει το περιεχόμενο της παρουσίασης, πρέπει να αντιμετωπίζει τις δημόσιες ιδιότητες ενός κρυπτογραφημένου αρχείου PPTX ως μόνο για ανάγνωση.

## **Πρόσβαση σε Ενσωματωμένες Ιδιότητες**

Η διεπαφή [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) εκθέτει ενσωματωμένα μεταδεδομένα μέσω τυποποιημένων ιδιοτήτων, όπως [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), και [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/). Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση και εκτυπώνει τα αποθηκευμένα μεταδεδομένα της στην κονσόλα. Οι τιμές εξαρτώνται από την εισερχόμενη παρουσίαση· ορισμένα πεδία μπορεί να είναι κενά.
```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

### **Αναφορά Αριθμού Αναθεώρησης και Χρόνου Επεξεργασίας**

Για να αναφέρουμε μια γραμμή για κάθε αρχείο PPTX στον φάκελο `presentations`, καλέστε το [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) για να ανακτήσετε τις [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) του χωρίς να φορτώσετε τις διαφάνειες για επεξεργασία. Η τυπική μορφή `c` για το `TimeSpan` περιλαμβάνει τον αριθμό ημερών όταν η διάρκεια φθάνει τις 24 ώρες.
```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

Δείγμα εξόδου για μια παρουσίαση με 1 ημέρα, 2 ώρες και 5 λεπτά καταγεγραμμένου χρόνου επεξεργασίας:
```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) είναι μεταδεδομένα εγγραφής. Η τιμή του από μόνη της δεν μπορεί να προσδιορίσει πόσες φορές αποθηκεύτηκε η παρουσίαση ή να ανακατασκευάσει το ιστορικό εκδόσεων.

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) είναι η διάρκεια επεξεργασίας που καταγράφεται στο αρχείο. Μια τιμή `00:00:00` σημαίνει ότι η αποθηκευμένη διάρκεια είναι μηδέν. Αυτό δεν αποδεικνύει ότι κανείς δεν επεξεργάστηκε την παρουσίαση.

## **Τροποποίηση Ενσωματωμένων Ιδιοτήτων**

Για να ενημερώσετε τα ενσωματωμένα μεταδεδομένα, αναθέστε τιμές στις εγγράψιμες ιδιότητες που εκτίθενται από το [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/). Αυτό το παράδειγμα ανοίγει μια υπάρχουσα παρουσίαση, ορίζει τα [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), και [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/), στη συνέχεια αποθηκεύει την ενημερωμένη παρουσίαση με το [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Το αποθηκευμένο PPTX περιέχει τα νέα μεταδεδομένα.
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Διαχείριση Βάσης Υπερσυνδέσμου**

Το [IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) αποθηκεύει τη βάση επιπέδου εγγράφου για σχετικούς υπερσυνδέσμους. Αυτό είναι χρήσιμο όταν μετακινείτε μια παρουσίαση και τα συνδεδεμένα αρχεία της σε άλλη θέση. Είναι ξεχωριστό από το [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) ενός μεμονωμένου υπερσυνδέσμου: η αλλαγή της βάσης δεν ξαναγράφει τις αποθηκευμένες διευθύνσεις των συνδέσμων ή δεν αλλάζει τις απόλυτες προορισμούς.

Το παράδειγμα απαιτεί μια παρουσίαση που περιέχει τόσο έναν σχετικό σύνδεσμο, όπως `target.html`, όσο και έναν απόλυτο σύνδεσμο, όπως `https://example.org/absolute.html`. Διαβάζει τη υπάρχουσα βάση, ορίζει μια νέα διεύθυνση βάσης, και αποθηκεύει και ξαναανοίγει την παρουσίαση για να ελέγξει την τιμή. Στη συνέχεια καθαρίζει τη βάση με `string.Empty` και επαληθεύει την κενή τιμή σε ξεχωριστό αποθηκευμένο αρχείο. Αντικαταστήστε τη δοκιμαστική διεύθυνση βάσης με τη θέση των συνδεδεμένων αρχείων σας.
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

Τα δύο μηνύματα επαλήθευσης πρέπει να εκτυπώσουν `True`. Η εκκαθάριση της βάσης αφήνει αμετάβλητες τις διευθύνσεις των μεμονωμένων υπερσυνδέσμων.

Ένας σχετικός σύνδεσμος προς `target.pptx` άνοιγε το `old/target.pptx` όταν η βάση έδειχνε στο φάκελο `old`. Μετά την αλλαγή της βάσης στον φάκελο `new`, αποθήκευση και ξαναάνοιγμα της παρουσίασης, ο ίδιος σύνδεσμος άνοιγε το `new/target.pptx`. Ένας απόλυτος σύνδεσμος συνέχισε να ανοίγει το ίδιο αρχείο. Δοκιμάστε τους σχετικούς συνδέσμους σας στο PowerPoint πριν και μετά τη μετακίνηση της παρουσίασης ή την αλλαγή της βάσης.

## **Προσθήκη Προσαρμοσμένων Ιδιοτήτων Παρουσίασης**

Οι προσαρμοσμένες ιδιότητες αποθηκεύουν μεταδεδομένα που δεν έχουν αντίστοιχο ενσωματωμένο πεδίο. Ο δείκτης [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) σας επιτρέπει να ορίσετε μια τιμή με βάση το όνομα της ιδιότητας. Αυτό το παράδειγμα δημιουργεί μια παρουσίαση, προσθέτει δύο κειμενικές τιμές και μια ακέραια τιμή έκδοσης, και αποθηκεύει την παρουσίαση με το [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Η ανάθεση τιμής σε υπάρχον όνομα αντικαθιστά την τιμή της ιδιότητας.
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Πρόσβαση και Τροποποίηση Προσαρμοσμένων Ιδιοτήτων**

Αυτό το παράδειγμα ανοίγει μια παρουσίαση που περιέχει προσαρμοσμένες ιδιότητες και χρησιμοποιεί το [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) για να τις επαναλάβει. Το [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) δέχεται δείκτη μηδενικής βάσης και επιστρέφει το όνομα που χρησιμοποιείται από τον [IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/). Το παράδειγμα εκτυπώνει κάθε αρχικό όνομα και τιμή, αντικαθιστά κάθε τιμή με μια αλφαριθμητική αρίθμηση ανεξάρτητα από τον αρχικό τύπο, και αποθηκεύει τις αλλαγές. Εάν δεν υπάρχουν προσαρμοσμένες ιδιότητες, ο βρόχος δεν κάνει αλλαγές.
```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Ζωντανό Παράδειγμα**

Δοκιμάστε την εφαρμογή online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) για να δείτε πώς να εργάζεστε με τις ιδιότητες εγγράφου χρησιμοποιώντας το API του Aspose.Slides:

[![Προβολή & Επεξεργασία Μεταδεδομένων PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αφαιρέσω μια ενσωματωμένη ιδιότητα από μια παρουσίαση;**

Οι ενσωματωμένες ιδιότητες αποτελούν αναπόσπαστο μέρος της παρουσίασης και δεν μπορούν να αφαιρεθούν εντελώς. Ωστόσο, μπορείτε είτε να αλλάξετε τις τιμές τους είτε να τις θέσετε κενές εφόσον το επιτρέπει η συγκεκριμένη ιδιότητα.

**Τι συμβαίνει αν προσθέσω μια προσαρμοσμένη ιδιότητα που ήδη υπάρχει;**

Αν προσθέσετε μια προσαρμοσμένη ιδιότητα που ήδη υπάρχει, η υπάρχουσα τιμή της θα αντικατασταθεί με τη νέα. Δεν χρειάζεται να αφαιρέσετε ή να ελέγξετε την ιδιότητα εκ των προτέρων, καθώς το Aspose.Slides ενημερώνει αυτόματα την τιμή της ιδιότητας.

**Μπορώ να έχω πρόσβαση στις ιδιότητες της παρουσίασης χωρίς να φορτώσω πλήρως την παρουσίαση;**

Ναι. Χρησιμοποιήστε το [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) και στη συνέχεια το [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) για να διαβάσετε τα αποθηκευμένα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσετε μια παρουσίαση [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) . Δείτε το άρθρο [Δημιουργία Ελαφριάς Απογραφής Παρουσιάσεων](/slides/el/net/examine-presentation/) για ένα πλήρες παράδειγμα αναφοράς και περιορισμούς ανά μορφή.

**Μπορώ να διαβάσω δημόσιες ιδιότητες κρυπτογραφημένης παρουσίασης χωρίς τον κωδικό ανοίγματος της;**

Ναι. Η παρουσίαση πρέπει να έχει κρυπτογραφηθεί με το [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) ορισμένο σε `false`, και πρέπει να φορτωθεί με το [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) ορισμένο σε `true`.

**Μπορώ να ενημερώσω ένα κρυπτογραφημένο αρχείο PPTX σε λειτουργία μόνο-ιδιότητες-εγγράφου;**

Όχι. Τα δημόσια και κρυπτογραφημένα δεδομένα ιδιοτήτων πρέπει να παραμένουν συνεπή, έτσι η ενημέρωση ενός κρυπτογραφημένου αρχείου PPTX απαιτεί τη φόρτωση της πλήρους παρουσίασης με τον σωστό κωδικό ανοίγματος.