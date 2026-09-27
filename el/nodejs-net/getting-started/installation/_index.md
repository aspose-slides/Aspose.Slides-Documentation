---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/nodejs-net/installation/
keywords:
- λήψη Aspose.Slides
- εγκατάσταση Aspose.Slides
- Εγκατάσταση Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Εγκαταστήστε το Aspose.Slides για Node.js μέσω .NET από το npm στα Windows ή Linux: προαπαιτούμενα, η παράκαμψη edge-js, μια εφάπαξ αποκατάσταση NuGet και ένα πρώτο πρόγραμμα που δημιουργεί μια παρουσίαση."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω .NET είναι το npm πακέτο `aspose.slides.via.net`. Εκτελεί τη βιβλιοθήκη Aspose.Slides .NET μέσα στο Node.js μέσω της γέφυρας [edge-js](https://github.com/agracio/edge-js), έτσι ώστε μια λειτουργική εγκατάσταση να χρειάζεται τόσο το Node.js όσο και το .NET.

Αυτό το άρθρο σας οδηγεί από ένα καθαρό σύστημα σε ένα πρώτο πρόγραμμα που δημιουργεί μια παρουσίαση. Υπάρχουν τέσσερα βήματα: δημιουργία έργου με παράκαμψη edge-js, εγκατάσταση του πακέτου από το npm, αποκατάσταση των εξαρτήσεων .NET του πακέτου μια φορά, και εκτέλεση του script από το φάκελο του έργου.

## **Προαπαιτούμενα**

- **Node.js 22 ή 24 LTS**, έκδοση x64, από το [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 ή νεότερο**, από το [dotnet.microsoft.com](https://dotnet.microsoft.com/download). Το μόνο runtime .NET δεν αρκεί: το βήμα αποκατάστασης παρακάτω χρειάζεται το SDK, όπως επίσης και η γέφυρα όταν εκτελείται το script. Εκτελέστε `dotnet --list-sdks` για να ελέγξετε ποια SDK είναι εγκατεστημένα.
- **Μόνο σε Linux**:
  - τα εργαλεία κατασκευής `python3`, `make` και `g++`, επειδή το npm μεταγλωττίζει το edge-js κατά την εγκατάσταση σε Linux·
  - τη βιβλιοθήκη fontconfig, την οποία φορτώνει η εγγενής βιβλιοθήκη σχεδίασης του Aspose.Slides.

  Σε Debian, αυτά είναι τα πακέτα `python3`, `make`, `g++` και `libfontconfig1`.

Τα βήματα σε αυτό το άρθρο δοκιμάστηκαν στις παρακάτω πλατφόρμες:

| Πλατφόρμα | Αποτέλεσμα |
|---|---|
| Windows x64 με Node.js 22 ή 24 | Λειτουργεί. Δοκιμάστηκε με το Microsoft Visual C++ Redistributable εγκατεστημένο. |
| Linux x64 με Node.js 22 ή 24, όπου το σύστημα OpenSSL ανήκει στην ίδια σειρά έκδοσης με το OpenSSL που είναι ενσωματωμένο στο Node.js, όπως στο Debian 13 | Λειτουργεί. |
| Linux όπου οι δύο εκδόσεις OpenSSL διαφέρουν, όπως στο Debian 12 | Το Node.js καταρρέει με σφάλμα πρόσβασης μνήμης όταν δημιουργείται μια παρουσίαση. |
| macOS | Δεν έχει επαληθευτεί. |

Σε Linux, συγκρίνετε τις δύο εκδόσεις πριν ξεκινήσετε. Η πρώτη εντολή εκτυπώνει την έκδοση OpenSSL ενσωματωμένη στο Node.js· η δεύτερη εκτυπώνει την έκδοση του συστήματος. Χρησιμοποιήστε σύστημα όπου και οι δύο ξεκινούν με το ίδιο κύριο και δευτερεύον αριθμό, π.χ. `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Αν η εντολή `openssl` δεν βρεθεί, εγκαταστήστε πρώτα το πακέτο `openssl`.

## **Δημιουργία Έργου**

Δημιουργήστε ένα φάκελο για το έργο σας, αρχικοποιήστε το και προσθέστε μια παράκαμψη που λέει στο npm ποια έκδοση του edge-js πρέπει να εγκαταστήσει:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Το πακέτο ζητά μια παλαιότερη έκδοση του edge-js των οποίων τα προσυμπιεσμένα Windows binaries σταματούν στο Node.js 20, οπότε χωρίς την παράκαμψη το πρώτο script σε Windows σταματά με το μήνυμα «The edge module has not been pre-compiled for node.js version». Η εντολή γράφει την παράκαμψη στην ενότητα `overrides` του `package.json`; προσθέστε τη πριν εγκαταστήσετε το πακέτο.

## **Εγκατάσταση του Πακέτου**

Εγκαταστήστε το Aspose.Slides για Node.js μέσω .NET από το npm:

```sh
npm install aspose.slides.via.net
```

Κατά την εγκατάσταση, το πακέτο αντιγράφει τις εγγενείς βιβλιοθήκες σχεδίασης (τα αρχεία των οποίων τα ονόματα περιέχουν `aspose.slides.drawing.capi`) στον φάκελο του έργου, δίπλα στο `package.json`.

Το πακέτο δημοσιεύεται επίσης ως αρχείο ZIP στον ιστότοπο [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/). Το άρθρο αυτό καλύπτει μόνο την εγκατάσταση μέσω npm.

## **Αποκατάσταση των Εξαρτήσεων .NET**

Το πακέτο περιέχει τα .NET assemblies του Aspose.Slides, αλλά όχι τα 20 πακέτα NuGet από τα οποία εξαρτώνται αυτά τα assemblies. Κατά την εκτέλεση, το .NET τα αναζητά στην κρύπτη πακέτων NuGet: `%USERPROFILE%\.nuget\packages` στα Windows, `~/.nuget/packages` σε Linux, ή τον φάκελο που ορίζεται στη μεταβλητή περιβάλλοντος `NUGET_PACKAGES`. Εάν λείπουν, το πρώτο script σταματά με το μήνυμα «assembly specified in the dependencies manifest was not found».

Για να γεμίσετε την κρύπτη, δημιουργήστε ένα φάκελο με όνομα `deps` στον φάκελο του έργου και αποθηκεύστε το παρακάτω αρχείο σε αυτόν ως `deps.csproj`. Κάθε στοιχείο `PackageDownload` κατεβάζει ένα πακέτο στην ακριβή έκδοση που αναφέρεται σε αγκύλες· δεν γίνεται καμία κατασκευή.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

Στη συνέχεια αποκαταστήστε το από το φάκελο του έργου:

```sh
dotnet restore deps/deps.csproj
```

Αυτό το βήμα χρειάζεται μία φορά ανά μηχάνημα, όχι ανά έργο: τα πακέτα παραμένουν στην κρύπτη NuGet και τα επόμενα έργα στο ίδιο μηχάνημα τα χρησιμοποιούν. Μετά την αποκατάσταση, μπορείτε να διαγράψετε το φάκελο `deps`.

## **Εκτέλεση ενός Πρώτου Προγράμματος**

Δημιουργήστε ένα αρχείο με όνομα `hello.js` στον φάκελο του έργου με τον ακόλουθο κώδικα. Δημιουργεί μια παρουσίαση, προσθέτει ένα ορθογώνιο με το κείμενο «Hello, World!» στην πρώτη διαφάνεια και αποθηκεύει το αποτέλεσμα ως `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Μια νέα παρουσίαση περιέχει μία κενή διαφάνεια.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Η θέση και το μέγεθος είναι σε μονάδες σημείου (1/72 ίντσα): x, y, πλάτος, ύψος.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Απελευθερώστε το αντικείμενο .NET που υποστηρίζει την παρουσίαση.
    presentation.dispose();
}
```

Εκτελέστε το από τον φάκελο του έργου:

```sh
node hello.js
```

Το script εκτυπώνει `Saved hello.pptx`. Ανοίξτε το `hello.pptx` για να δείτε μία διαφάνεια με γεμάτο ορθογώνιο που περιέχει το κείμενο. Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης υδατογράφημα αξιολόγησης· δείτε το [Evaluate Aspose.Slides](/slides/el/nodejs-net/evaluate-aspose-slides/) και την [Licensing](/slides/el/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Εκτελείτε τα scripts από το φάκελο του έργου, αυτόν που περιέχει το `package.json`. Οι σχετικές διαδρομές όπως `hello.pptx` λυγίζονται σε σχέση με τον τρέχοντα φάκελο, και σε ορισμένα μηχανήματα ένα script που ξεκινά από διαφορετικό φάκελο δεν μπορεί να δημιουργήσει παρουσίαση.
{{% /alert %}}

Το JavaScript API αντικατοπτρίζει το Aspose.Slides για .NET: οι κλάσεις διατηρούν τα ονόματά τους στο .NET, οι ιδιότητες και οι μέθοδοι χρησιμοποιούν camelCase (`Slides` γίνεται `slides`, `AddAutoShape` γίνεται `addAutoShape`), και τα στοιχεία συλλογής ανακτώνται με `get(index)`. Δεν υπάρχει ξεχωριστό API reference για αυτό το πακέτο, οπότε χρησιμοποιήστε το [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) για λεπτομέρειες κλάσεων και μελών, π.χ. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) και [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/).

## **Συχνές Ερωτήσεις**

**Τι σημαίνει το μήνυμα «The edge module has not been pre-compiled for node.js version»;**

Το npm εγκατέστησε την παλαιότερη έκδοση του edge-js που ζητά το πακέτο. Προσθέστε την παράκαμψη από το [Create a Project](#create-a-project) και τρέξτε ξανά `npm install`.

**Τι σημαίνει το μήνυμα «assembly specified in the dependencies manifest was not found»;**

Οι εξαρτήσεις .NET δεν βρίσκονται στην κρύπτη NuGet. Η ίδια εκτέλεση αναφέρει επίσης «edge.initializeClrFunc is not a function». Ακολουθήστε το [Restore the .NET Dependencies](#restore-the-net-dependencies) μία φορά, έπειτα τρέξτε ξανά το script σας.

**Τι σημαίνει το «The edge native module is not available» σε Linux;**

Το edge-js δεν μεταγλωττίστηκε κατά το `npm install`, π.χ. επειδή λείπουν τα `python3`, `make` ή `g++`. Το npm δεν το αναφέρει ως σφάλμα. Εγκαταστήστε τα εργαλεία κατασκευής, μετά τρέξτε `npm rebuild edge-js` στο φάκελο του έργου.

**Γιατί η δημιουργία μιας παρουσίασης αποτυγχάνει με κενό «Error»;**

Σε Linux, ελέγξτε ότι η βιβλιοθήκη fontconfig είναι εγκατεστημένη (`libfontconfig1` στο Debian); χωρίς αυτήν, η εγγενής βιβλιοθήκη σχεδίασης δεν μπορεί να φορτωθεί. Σε οποιοδήποτε σύστημα, βεβαιωθείτε ότι τρέχετε το script από τον φάκελο του έργου.

**Γιατί το Node.js καταρρέει με σφάλμα πρόσβασης μνήμης σε Linux;**

Το σύστημα OpenSSL και το OpenSSL ενσωματωμένο στο Node.js προέρχονται από διαφορετικές σειρές εκδόσεων. Συγκρίντε τα όπως φαίνεται στις [Prerequisites](#prerequisites) και χρησιμοποιήστε διανομή ή έκδοση Node.js όπου ταιριάζουν.

**Πρέπει να επαναλαμβάνω την αποκατάσταση NuGet για κάθε έργο;**

Όχι. Η αποκατάσταση γεμίζει την κρύπτη NuGet για τον λογαριασμό χρήστη σας, και κάθε έργο στο ίδιο μηχάνημα χρησιμοποιεί την ίδια κρύπτη.