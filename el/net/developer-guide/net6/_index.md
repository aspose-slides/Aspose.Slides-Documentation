---
title: .NET 6 υποστήριξη
type: docs
weight: 235
url: /el/net/net6/
keywords:
- .NET 6 υποστήριξη
- Λύση cloud
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Ρυθμίστε το Aspose.Slides για .NET 6 ώστε να δημιουργείτε, επεξεργάζεστε και να μετατρέπετε παρουσιάσεις PowerPoint PPT, PPTX και ODP σε σύγχρονες, πολυπλατφορμικές C# εφαρμογές."
---
## **Εισαγωγή**

Ξεκινώντας από [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0), η υποστήριξη για .NET6 υλοποιήθηκε. Η ιδιαιτερότητα αυτής της υποστήριξης είναι ότι το .NET6 δεν υποστηρίζει πλέον το System.Drawing.Common για Linux ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) και το Slides υλοποιεί αυτό το γραφικό υποσύστημα ως στοιχείο C++.

Το Aspose.Slides για .NET λειτουργεί τώρα χωρίς εξαρτήσεις στο GDI/libgdiplus σε:
* Windows
* Linux

_ΜacOS_ η υποστήριξη είναι σε εξέλιξη.

## **Χρήση Slides για .NET 6 στο AWS και Azure**

.NET6 είναι η προτιμώμενη έκδοση για το Aspose.Slides που χρησιμοποιείται στο cloud (AWS, Azure ή άλλες λύσεις cloud).

Προηγουμένως, όταν το Aspose.Slides χρησιμοποιούνταν σε Linux host, έπρεπε να εγκατασταθούν πρόσθετες εξαρτήσεις (libgdiplus) και αυτό ήταν συχνά δύσκολο ή μη πρακτικό (π.χ., όταν χρησιμοποιείται [AWS Lambda](https://aws.amazon.com/lambda)). Με το Slides για .NET6, αυτές οι εξαρτήσεις δεν χρειάζονται πλέον, επομένως η ανάπτυξη είναι πολύ πιο εύκολη.

Ένα άλλο ζήτημα είναι τα προβλήματα που προέκυψαν όταν το Aspose.Slides χρησιμοποιούνταν σε λύση cloud με Windows host. Για παράδειγμα, τα [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) έχουν περιορισμούς για τη διαδικασία και προκαλούν προβλήματα κατά την εξαγωγή PDF (δείτε [αυτό](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). Η χρήση του Aspose.Slides για .NET6 λύνει αυτό το πρόβλημα.

## **Χρήση του πακέτου System.Drawing.Common και των κλάσεων Slides για .NET 6 (CS0433: Το τύπος υπάρχει και στις Slides και στο System.Drawing.Common Error)**

Μερικές φορές, και οι εξαρτήσεις System.Drawing και Slides για .NET6 πρέπει να χρησιμοποιηθούν σε ένα έργο (π.χ., όταν το έργο .NET6 εξαρτάται από άλλα πακέτα, που με τη σειρά τους εξαρτώνται από το System.Drawing). Αυτό μπορεί να προκαλέσει σφάλματα σύγκρουσης όπως τα παρακάτω:

* CS0433: Ο τύπος 'Image' υπάρχει και στα 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' και στο 'System.Drawing.Common, Version=6.0.0.0'
* CS0433: Ο τύπος 'Graphics' υπάρχει και στα 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' και στο 'System.Drawing.Common, Version=6.0.0.0'

Σε αυτήν την περίπτωση, μπορείτε να χρησιμοποιήσετε [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) για το Aspose.Slides (έκδοση μικρότερη από 24.8):
1) Επιλέξτε το assembly Aspose.Slides από τις εξαρτήσεις του έργου και κάντε κλικ στο **Properties**.
  ![Aspose Slides package properties](package_properties.png)
2) Ορίστε ένα ψευδώνυμο (π.χ., "Slides").
  ![Aspose Slides alias](set_alias.png)

Τώρα, οι τύποι από System.Drawing.Common θα χρησιμοποιηθούν εξ ορισμού. Το εξωτερικό ψευδώνυμο συναρμολόγησης πρέπει να καθοριστεί όπου απαιτούνται τύποι Aspose.Slides.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Παράδειγμα πλήρους:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

Ξεκινώντας από την έκδοση 24.8, το αποξηρυμένο δημόσιο API με εξαρτήσεις στο System.Drawing έχει αφαιρεθεί. Σχετικά με το παραπάνω παράδειγμα κώδικα, μπορείτε να λάβετε την εικόνα της διαφάνειας ως εξής.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
Το νέο API περιγράφεται με περισσότερες λεπτομέρειες στο [Σύγχρονο API](/slides/el/net/modern-api/).