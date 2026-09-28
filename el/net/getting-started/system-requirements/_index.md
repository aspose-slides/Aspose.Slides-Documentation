---
title: Απαιτήσεις Συστήματος
type: docs
weight: 60
url: /el/net/system-requirements/
keywords:
- απαιτήσεις συστήματος
- υποστηριζόμενες πλατφόρμες
- πλαίσια-στόχοι
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ελέγξτε τι χρειάζεται το Aspose.Slides for .NET πριν το εγκαταστήσετε: τα πλαίσια που στοχεύει κάθε πακέτο NuGet, τα υποστηριζόμενα λειτουργικά συστήματα και επεξεργαστές, καθώς και τις βιβλιοθήκες και γραμματοσειρές που απαιτεί το Linux."
---
## **Εισαγωγή**

Το Aspose.Slides for .NET είναι μια ανεξάρτητη βιβλιοθήκη: δεν χρειάζεται το Microsoft PowerPoint ή το Microsoft Office. Δημοσιεύεται ως δύο πακέτα NuGet, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) και [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Και τα δύο παρέχουν τα ίδια ονόματα χώρου και κλάσεις του Aspose.Slides· διαφέρουν στα πλαίσια-στόχο που στοχεύουν και στον τρόπο που σχεδιάζουν τις διαφάνειες, κάτι που καθορίζει πού εκτελούνται και τι χρειάζονται.

Αυτό το άρθρο παραθέτει τις εκδόσεις .NET και τις πλατφόρμες που υποστηρίζει κάθε πακέτο, καθώς και τις βιβλιοθήκες συστήματος και τις γραμματοσειρές που χρειάζεται το Linux, και ολοκληρώνεται με ένα σύντομο πρόγραμμα που ελέγχει τη ρύθμισή σας. Για να προσθέσετε ένα πακέτο σε ένα έργο, δείτε [Installation](/slides/el/net/installation/).

## **Υποστηριζόμενες Έκδοχές .NET**

Κάθε πακέτο περιέχει μία έκδοση του Aspose.Slides για κάθε πλαίσιο-στόχο, και το NuGet επιλέγει την έκδοση που ταιριάζει με το πλαίσιο-στόχο του έργου σας.

| Πακέτο | Πλαίσια‑στόχος στο πακέτο | Το έργο σας μπορεί να στοχεύει |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 ή μεταγενέστερο· .NET 6 ή νεότερο, συμπεριλαμβανομένων των .NET 8, .NET 9 και .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 ή νεότερο, συμπεριλαμβανομένων των .NET 8, .NET 9 και .NET 10 |

Η έκδοση `netstandard2.0` επιτρέπει σε μια βιβλιοθήκη κλάσεων .NET Standard 2.0 να αναφέρεται στο Aspose.Slides.NET. Μια εφαρμογή που χρησιμοποιεί τέτοια βιβλιοθήκη εκτελεί την έκδοση που ταιριάζει με το δικό της πλαίσιο-στόχο: μια εφαρμογή .NET 8, για παράδειγμα, εκτελεί την έκδοση `net6.0`.

## **Υποστηριζόμενα Λειτουργικά Συστήματα και Επεξεργαστές**

**Aspose.Slides.NET** περιέχει μόνο κώδικα ανεξάρτητο από επεξεργαστή (AnyCPU), έτσι εκτελείται στην αρχιτεκτονική του .NET runtime που το φορτώνει. Σχεδιάζει τις διαφάνειες μέσω της βιβλιοθήκης System.Drawing.Common της Microsoft, την οποία η Microsoft υποστηρίζει [only on Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Στο Linux, το Aspose.Slides.NET απαιτεί επομένως τη βιβλιοθήκη `libgdiplus` και μια παράμετρο εκκίνησης, όπως περιγράφεται στο [Linux](#linux). Εκτελείται σε διανομές Linux που παρέχουν `libgdiplus`, όπως Debian, Ubuntu και Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** σχεδιάζει τις διαφάνειες με τη δική του μηχανή γραφικών. Η μηχανή είναι μια εγγενής βιβλιοθήκη που το πακέτο περιέχει σε μία έκδοση ανά πλατφόρμα, έτσι το πακέτο εκτελείται μόνο σε αυτές τις πλατφόρμες:

| Λειτουργικό σύστημα | Επεξεργαστές | Σημειώσεις |
|---|---|---|
| Windows | x86, x64 | Windows σε ARM64 δεν υποστηρίζεται. |
| Linux | x64, ARM64 | Απαιτεί glibc 2.23 ή νεότερο σε x64 και glibc 2.39 ή νεότερο σε ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Το Aspose.Slides.NET6.CrossPlatform δεν εκτελείται σε Alpine Linux ή σε άλλες διανομές που βασίζονται σε musl αντί για glibc, ούτε σε διανομές με παλαιότερη glibc, όπως CentOS 7. Σε αυτά τα συστήματα χρησιμοποιήστε το Aspose.Slides.NET.

Στα Windows, η εγγενής βιβλιοθήκη του Aspose.Slides.NET6.CrossPlatform χρησιμοποιεί το runtime του Microsoft Visual C++ (*MSVCP140.dll* και *VCRUNTIME140.dll*, καθώς και *VCRUNTIME140_1.dll* σε x64). Εάν αυτά τα αρχεία λείπουν από το μηχάνημα-στόχο, εγκαταστήστε το [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Και τα δύο πακέτα απαιτούν πρόσθετες βιβλιοθήκες συστήματος στο Linux. Χωρίς αυτές, το πρώτο παράδειγμα στο [Create Presentations](/slides/el/net/create-presentation/) αποτυγχάνει με εξαίρεση αντί να αποθηκεύσει το αρχείο. Οι παρακάτω εντολές αφορούν Debian και Ubuntu· σε αυτές τις διανομές, κάθε βιβλιοθήκη εγκαθιστά επίσης τις γραμματοσειρές DejaVu (`fonts-dejavu-core`), ώστε το κείμενο να αποδίδεται χωρίς περαιτέρω πακέτα γραμματοσειρών.

### **Aspose.Slides.NET6.CrossPlatform**

Η βιβλιοθήκη Linux του πακέτου απαιτεί τη βιβλιοθήκη `fontconfig`:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Χωρίς αυτήν, η δημιουργία μιας [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) αποτυγχάνει με `TypeInitializationException` του οποίου το εσωτερικό `DllNotFoundException` αναφέρει ότι το `libfontconfig.so.1` δεν μπορεί να ανοιχθεί.

Οι ελάχιστες εικόνες βάσης ενδέχεται επίσης να μην περιλαμβάνουν το `fontconfig`. Η εικόνα βάσης AWS Lambda για .NET 8, για παράδειγμα, δεν περιέχει ούτε `fontconfig` ούτε γραμματοσειρές. Σε μια εικόνα κοντέινερ που χτίζεται πάνω της, εκτελέστε `dnf install -y fontconfig`, το οποίο εγκαθιστά επίσης τις γραμματοσειρές Noto Sans.

### **Aspose.Slides.NET**

Το πακέτο απαιτεί δύο πράγματα στο Linux:

1. Τη βιβλιοθήκη `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. Την παράμετρο `System.Drawing.EnableUnixSupport`, ενεργοποιημένη στην αρχή της εφαρμογής σας πριν από οποιαδήποτε κλήση Aspose.Slides. Σε ένα *Program.cs* με δηλώσεις κορυφαίου επιπέδου, τοποθετήστε το μετά τις οδηγίες `using`:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Χωρίς το `libgdiplus`, η αποθήκευση μιας παρουσίασης αποτυγχάνει με `TypeInitializationException` του οποίου το εσωτερικό `DllNotFoundException` αναφέρει ότι το `libgdiplus` δεν μπορεί να φορτωθεί. Χωρίς την παράμετρο, η εσωτερική εξαίρεση είναι `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
Η παράμετρος λειτουργεί μόνο με System.Drawing.Common 6, την έκδοση από την οποία εξαρτάται το Aspose.Slides.NET. Η Microsoft την αφαίρεσε στη System.Drawing.Common 7. Εάν το έργο σας αναφέρει System.Drawing.Common 7 ή νεότερο, άμεσα ή μέσω άλλου πακέτου, το Aspose.Slides.NET αποτυγχάνει στο Linux με `PlatformNotSupportedException` ακόμη και με εγκατεστημένο το `libgdiplus` και ενεργοποιημένη την παράμετρο. Σε αυτήν την περίπτωση, χρησιμοποιήστε το Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

Στο Alpine Linux, χρησιμοποιήστε το Aspose.Slides.NET με την παραπάνω παράμετρο. Οι εικόνες Alpine συνήθως δεν περιέχουν γραμματοσειρές, και το μόνο `libgdiplus` δεν εγκαθιστά καμία, επομένως εγκαταστήστε το `libgdiplus` μαζί τουλάχιστον με ένα πακέτο γραμματοσειρών. Χωρίς γραμματοσειρές, η αποθήκευση μιας παρουσίασης αποτυγχάνει με το ακόλουθο σφάλμα:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Επιλογή 1: Γραμματοσειρές DejaVu**

Η προτεινόμενη επιλογή είναι το πακέτο `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Στις τρέχουσες εκδόσεις Alpine, το `ttf-dejavu` εγκαθιστά το πακέτο `font-dejavu`, που εγκαθιστά επίσης το `fontconfig` και τα εργαλεία γραμματοσειρών που εξαρτώνται.

**Επιλογή 2: Γραμματοσειρές πυρήνα Microsoft**

Εάν οι παρουσιάσεις σας χρησιμοποιούν γραμματοσειρές της Microsoft όπως Arial, Times New Roman, Courier New ή Verdana, εγκαταστήστε αντί αυτού τις βασικές γραμματοσειρές της Microsoft. Το βήμα `update-ms-fonts` κατεβάζει τις γραμματοσειρές ενώ η εικόνα χτίζεται, επομένως η κατασκευή χρειάζεται πρόσβαση στο διαδίκτυο:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Υποστήριξη Γλοβαλικοποίησης**

Και τα δύο πακέτα χρειάζονται υποστήριξη .NET globalization, που το .NET στο Linux παρέχει μέσω των βιβλιοθηκών ICU. Σε [globalization‑invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization), η δημιουργία μιας [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) αποτυγχάνει με `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Μερικές εικόνες κοντέινερ ενεργοποιούν αυτή τη λειτουργία. Οι εικόνες .NET runtime για Alpine Linux (`runtime-deps`, `runtime` και `aspnet`), για παράδειγμα, ορίζουν `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` και δεν περιλαμβάνουν ICU. Σε μια εικόνα που χτίζεται επάνω τους, εγκαταστήστε το ICU και απενεργοποιήστε τη λειτουργία:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Βεβαιωθείτε επίσης ότι το αρχείο έργου σας δεν ορίζει την ιδιότητα `InvariantGlobalization` σε `true`.

## **Έλεγχος Ρύθμισης**

Για να βεβαιωθείτε ότι ένα πακέτο και οι προαπαιτούμενες εξαρτήσεις του είναι στη θέση τους, τρέξτε ένα πρόγραμμα που αποθηκεύει μια παρουσίαση και αποδίδει μια διαφάνεια σε εικόνα. Η αποθήκευση και η απόδοση χρησιμοποιούν τη βιβλιοθήκη γραφικών και τις γραμματοσειρές, τα οποία παρέχονται από τις παραπάνω απαιτήσεις Linux.

Δημιουργήστε μια εφαρμογή κονσόλας και προσθέστε το πακέτο όπως περιγράφεται στην [Installation](/slides/el/net/installation/), αντικαταστήστε το περιεχόμενο του *Program.cs* με τον κώδικα παρακάτω και τρέξτε `dotnet run`. Εάν χρησιμοποιείτε Aspose.Slides.NET σε Linux, προσθέστε τη δήλωση παραμέτρου `System.Drawing.EnableUnixSupport` που φαίνεται στο [Linux](#linux) μετά τις οδηγίες `using`. Το πρόγραμμα χρησιμοποιεί δηλώσεις κορυφαίου επιπέδου και δηλώσεις `using`, οι οποίες απαιτούν C# 9 ή νεότερη. Τα έργα που στοχεύουν .NET 6 ή νεότερο χρησιμοποιούν προεπιλεγμένα νεότερη έκδοση C#· σε έργο που στοχεύει .NET Framework, προσθέστε `<LangVersion>latest</LangVersion>` σε ένα `PropertyGroup` στο αρχείο έργου.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

Το πρόγραμμα προσθέτει ένα ορθογώνιο με κείμενο στην πρώτη διαφάνεια και αποθηκεύει την παρουσίαση ως *hello.pptx* με τη μέθοδο [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/). Στη συνέχεια αποδίδει τη διαφάνεια με [GetImage](https://reference.aspose.com/slides/el/net/aspose.slides/slide/getimage/) και αποθηκεύει το αποτέλεσμα ως *hello.png* με [IImage.Save](https://reference.aspose.com/slides/el/net/aspose.slides/iimage/save/) στη μορφή [ImageFormat.Png](https://reference.aspose.com/slides/el/net/aspose.slides/imageformat/). Οι συντελεστές κλίμακας 1 αποδίδουν ένα pixel ανά point, έτσι η προεπιλεγμένη διαφάνεια 720 × 540 points γίνεται εικόνα 720 × 540 pixels, με το κείμενο ορατό μέσα στο ορθογώνιο. Χωρίς άδεια, και τα δύο αρχεία φέρουν υδατογράφημα αξιολόγησης· δείτε [Licensing](/slides/el/net/licensing/). Εάν λείπει κάποια απαίτηση, το πρόγραμμα σταματά με μία από τις εξαιρέσεις που περιγράφονται στο [Linux](#linux).

## **Εργαλεία Ανάπτυξης**

Μπορείτε να δημιουργήσετε εφαρμογές που χρησιμοποιούν Aspose.Slides με οποιοδήποτε εργαλείο υποστηρίζει το πλαίσιο‑στόχο του έργου σας: το .NET SDK και το CLI `dotnet` στα Windows, Linux και macOS, ή το Visual Studio στα Windows. Η [Installation](/slides/el/net/installation/) περιγράφει και τα δύο.

## **Συχνές Ερωτήσεις**

**Χρειάζεται να είναι εγκατεστημένο το Microsoft PowerPoint για μετατροπές και απόδοση;**

Όχι, το PowerPoint δεν απαιτείται. Το Aspose.Slides είναι μια ανεξάρτητη μηχανή για [δημιουργία](/slides/el/net/create-presentation/), τροποποίηση, [μετατροπή](/slides/el/net/convert-presentation/) και [απόδοση](/slides/el/net/convert-powerpoint-to-png/) παρουσιάσεων.

**Ποιο πακέτο πρέπει να χρησιμοποιήσω;**

Χρησιμοποιήστε το Aspose.Slides.NET στα Windows και το Aspose.Slides.NET6.CrossPlatform σε Linux και macOS. Σε Alpine Linux, σε Linux συστήματα με παλαιότερη glibc από τις παραπάνω εκδόσεις, και σε έργα που στοχεύουν .NET Framework, χρησιμοποιήστε το Aspose.Slides.NET. Προσθέστε μόνο ένα από τα δύο πακέτα σε ένα έργο.

**Ποιες γραμματοσειρές χρειάζονται για σωστή απόδοση;**

Οι γραμματοσειρές που χρησιμοποιούνται στην παρουσίαση, ή κατάλληλες εναλλακτικές, πρέπει να είναι διαθέσιμες στο λειτουργικό σύστημα. Σε Linux και macOS εγκαταστήστε τα πακέτα γραμματοσειρών που χρειάζονται οι παρουσιάσεις σας για συνέπεια απόδοσης. Σε Alpine Linux, εγκαταστήστε τουλάχιστον ένα πακέτο γραμματοσειρών επιπλέον του `libgdiplus`, όπως περιγράφεται στο [Alpine Linux](#alpine-linux).

**Γιατί μια προσαρμοσμένη γραμματοσειρά εμφανίζεται ως υποκατάστατη ή κείμενο που λείπει στο Linux;**

Εάν το αρχείο γραμματοσειράς έχει ασυνεπείς ή κατεστραμμένες καταχωρίσεις στον πίνακα ονομάτων, η στοίβα αντιστοίχισης γραμματοσειρών του Linux (FreeType/fontconfig) μπορεί να επιλέξει μη έγκυρη εγγραφή, με αποτέλεσμα η γραμματοσειρά να μην αναγνωρίζεται. Η χρήση μιας έκδοσης γραμματοσειράς με διορθωμένα ονόματα ή η εγκατάσταση μιας συνεπούς εναλλακτικής λύνει το πρόβλημα.