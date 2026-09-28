---
title: Εκτέλεση Aspose.Slides για .NET σε Docker
linktitle: Docker
type: docs
weight: 140
url: /el/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Κοντέινερ Docker
- Κατασκευή πολλαπλών σταδίων
- Εικόνα κοντέινερ
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- γραμματοσειρές
- μετατροπή PDF
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και εκτελέστε μια εφαρμογή κονσόλας Aspose.Slides για .NET σε Docker: ένα Dockerfile πολλαπλών σταδίων στις επίσημες εικόνες .NET, τις βιβλιοθήκες Linux και τις γραμματοσειρές που χρειάζεται, και πώς να αντιγράψετε τα παραγόμενα αρχεία στον υπολογιστή σας."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να εκτελέσετε το Aspose.Slides για .NET σε ένα κοντέινερ Docker. Δημιουργείτε μια μικρή εφαρμογή κονσόλας που δημιουργεί μια παρουσίαση με πλαίσιο κειμένου και τη μετατρέπει σε PDF, τη συσκευάζετε με ένα πολυ‑σταδίων Dockerfile στις επίσημες εικόνες .NET της Microsoft, την εκτελείτε και αντιγράφετε τα παραγόμενα αρχεία στον υπολογιστή σας. Το άρθρο επίσης παραθέτει τις βιβλιοθήκες Linux και τις γραμματοσειρές που χρειάζεται το Aspose.Slides στο κοντέινερ και τελειώνει με μια παραλλαγή για το Alpine Linux.

Χρειάζεστε μόνο το Docker στον υπολογιστή σας. Το .NET SDK αποτελεί μέρος της εικόνας δημιουργίας, οπότε δεν χρειάζεται να το εγκαταστήσετε. Για εγκατάσταση του Docker, δείτε [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Επιλογή του Πακέτου και της Βασικής Εικόνας**

Οι προεπιλεγμένες εικόνες κοντέινερ .NET 10 βασίζονται στο Ubuntu 24.04. Σε αυτές τις εικόνες, χρησιμοποιήστε το πακέτο [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Απαιτεί τη βιβλιοθήκη `fontconfig`, και η εικόνα χρόνου εκτέλεσης .NET δεν περιέχει αυτή τη βιβλιοθήκη ούτε γραμματοσειρές, επομένως το Dockerfile σε αυτό το άρθρο εγκαθιστά και τα δύο.

Το Aspose.Slides.NET6.CrossPlatform δεν εκτελείται σε Alpine Linux. Για εικόνες βασισμένες σε Alpine, χρησιμοποιήστε το πακέτο [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) με `libgdiplus`, όπως περιγράφεται στο [Run on Alpine Linux](#run-on-alpine-linux). Η σελίδα [Installation](/slides/el/net/installation/) συγκρίνει τα δύο πακέτα.

## **Δημιουργία του Έργου**

Δημιουργήστε έναν φάκελο με όνομα *HelloSlidesDocker* και προσθέστε τα ακόλουθα τρία αρχεία σε αυτόν.

*Hello SlidesDocker.csproj* περιγράφει μια εφαρμογή κονσόλας για .NET 10, την έκδοση των εικόνων κοντέινερ που χρησιμοποιούνται παρακάτω, και αναφορά στο Aspose.Slides.NET6.CrossPlatform. Ορίστε την έκδοση του πακέτου στην πιο πρόσφατη που εμφανίζεται στο [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* δημιουργεί ένα [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/), προσθέτει ένα ορθογώνιο με κείμενο στην πρώτη του διαφάνεια, και αποθηκεύει την παρουσίαση δύο φορές με τη μέθοδο [Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/): ως PPTX και ως PDF. Και τα δύο αρχεία πηγαίνουν στο φάκελο *output* κάτω από τον τρέχοντα κατάλογο εργασίας. Η εφαρμογή στη συνέχεια παραθέτει τις γραμματοσειρές που αντικαταστάθηκαν κατά την απόδοση του PDF, χρησιμοποιώντας το [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/getsubstitutions/), ώστε να δείτε εάν το κοντέινερ διαθέτει τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* κρατά τους φακέλους *bin* και *obj* μιας τοπικής κατασκευής, καθώς και τα αποτελέσματα προηγούμενων εκτελέσεων, έξω από το πλαίσιο κατασκευής Docker, ώστε η εικόνα να δημιουργείται μόνο από τα αρχεία πηγαίου κώδικα.

```text
bin/
obj/
output/
```

## **Συγγραφή του Dockerfile**

Προσθέστε ένα αρχείο με όνομα *Dockerfile* στον ίδιο φάκελο:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

Το αρχείο έχει δύο στάδια:

- **The build stage** ξεκινά από την εικόνα .NET SDK. Αντιγράφει πρώτα το αρχείο του έργου και επαναφέρει τα πακέτα NuGet, ώστε το Docker να επαναχρησιμοποιεί αυτό το στρώμα εφόσον το αρχείο του έργου δεν αλλάζει. Στη συνέχεια αντιγράφει τον πηγαίο κώδικα και δημοσιεύει την εφαρμογή στο */app*.
- **The runtime stage** ξεκινά από τη μικρότερη εικόνα .NET runtime, η οποία δεν έχει SDK, και αντιγράφει μόνο τη δημοσιευμένη εφαρμογή. Εγκαθιστά δύο πακέτα:
  - `libfontconfig1`: το Aspose.Slides.NET6.CrossPlatform φορτώνει αυτή τη βιβλιοθήκη κατά την εκκίνησή του. Χωρίς αυτήν, η εφαρμογή σταματά με `DllNotFoundException` που αναφέρει `libfontconfig.so.1`.
  - `fonts-dejavu-core`: η εικόνα runtime δεν περιέχει γραμματοσειρές, και το Aspose.Slides χρειάζεται τουλάχιστον μία εγκατεστημένη γραμματοσειρά για να σχεδιάσει κείμενο· χωρίς καμία, η μετατροπή σταματά με `InvalidOperationException: Cannot find any fonts installed on the system.` Το κείμενο σε γραμματοσειρές που δεν είναι εγκατεστημένες σχεδιάζεται με αντικατάσταση γραμματοσειράς. Οι γραμματοσειρές DejaVu αποτελούν ένα μικρό σύνολο που επιτρέπει την απόδοση του κειμένου· για απόδοση παρουσιάσεων με τις γραμματοσειρές που σχεδιάστηκαν, δείτε [Deploy Fonts](/slides/el/net/deploy-fonts/).

`--no-install-recommends` και η αφαίρεση των λιστών πακέτων διατηρούν τη εικόνα μικρή. Οι τελευταίες γραμμές δημιουργούν το φάκελο *output*, το παρέχουν στον μη‑root χρήστη `app` που ορίζουν οι επίσημες εικόνες .NET (το αναγνωριστικό χρήστη του βρίσκεται στη μεταβλητή `APP_UID`), και εκτελούν την εφαρμογή ως αυτός ο χρήστης.

Για μια εφαρμογή ASP.NET Core, ξεκινήστε το στάδιο χρόνου εκτέλεσης από `mcr.microsoft.com/dotnet/aspnet:10.0` αντίγια. Βασίζεται στην ίδια εικόνα Ubuntu, οπότε χρειάζονται τα ίδια πακέτα.

## **Δημιουργία και Εκτέλεση του Κοντέινερ**

Ανοίξτε ένα τερματικό στον φάκελο *HelloSlidesDocker*. Δημιουργήστε την εικόνα, έπειτα εκτελέστε ένα κοντέινερ από αυτήν:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Η πρώτη δημιουργία κατεβάζει τις βασικές εικόνες και τα πακέτα NuGet, έτσι διαρκεί περισσότερο από τις επόμενες δημιουργίες. Το κοντέινερ εκτελεί την εφαρμογή και σταματά. Εκτυπώνει:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Η πρώτη γραμμή δείχνει ότι το κείμενο χρησιμοποιεί τη γραμματοσειρά Calibri, την προεπιλεγμένη γραμματοσειρά μιας νέας παρουσίασης, και ότι η Calibri δεν είναι εγκατεστημένη στην εικόνα, έτσι το Aspose.Slides σχεδίασε το κείμενο με DejaVu Sans. Το κείμενο στο PDF είναι πραγματικό, επελέξιμο κείμενο σε αυτή τη γραμματοσειρά. Χωρίς άδεια, το Aspose.Slides προσθέτει επίσης ένα υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει· δείτε [Licensing](/slides/el/net/licensing/).

## **Αντιγραφή του Αποτελέσματος στον Υπολογιστή Σας**

Τα αρχεία βρίσκονται στο φάκελο */app/output* του σταματημένου κοντέινερ. Αντιγράψτε τα σε έναν φάκελο *output* στον υπολογιστή σας, έπειτα αφαιρέστε το κοντέινερ:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Αυτές οι δύο εντολές λειτουργούν με τον ίδιο τρόπο στο Bash, PowerShell και στο Windows Command Prompt.

Σε Linux, μπορείτε αντί αυτού να προσαρτήσετε έναν φάκελο του μηχανήματός σας στο κοντέινερ, ώστε η εφαρμογή να γράφει τα αρχεία του εκεί άμεσα:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Η επιλογή `--user` εκτελεί την εφαρμογή με τα αναγνωριστικά χρήστη και ομάδας σας, ώστε να μπορεί να γράψει στον φάκελο που δημιουργήσατε και τα αρχεία να ανήκουν σε εσάς. Το `--rm` αφαιρεί το κοντέινερ όταν σταματά.

## **Εκτέλεση σε Alpine Linux**

Για να εκτελέσετε την εφαρμογή σε εικόνα βασισμένη σε Alpine, μεταβείτε στο πακέτο Aspose.Slides.NET και αλλάξτε το στάδιο χρόνου εκτέλεσης. Το στάδιο κατασκευής παραμένει το ίδιο.

1. Στο *HelloSlidesDocker.csproj*, αντικαταστήστε την αναφορά πακέτου:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

1. Στο *Program.cs*, προσθέστε αυτή τη δήλωση μετά τις οδηγίες `using`, πριν από την πρώτη κλήση του Aspose.Slides. Ενεργοποιεί την υποστήριξη System.Drawing για Linux που χρησιμοποιεί το Aspose.Slides.NET:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

1. Στο *Dockerfile*, αντικαταστήστε το στάδιο χρόνου εκτέλεσης (όλα από τη δεύτερη γραμμή `FROM`) με:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

Το στάδιο Alpine εγκαθιστά τρία πακέτα και αλλάζει μία ρύθμιση:

- `libgdiplus` είναι η βιβλιοθήκη γραφικών που χρησιμοποιεί το Aspose.Slides.NET στο Linux.
- `font-dejavu` παρέχει γραμματοσειρές. Χωρίς κάποια γραμματοσειρά, η μετατροπή σταματά με `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` και `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` παρέχουν δεδομένα πολιτισμού. Οι εικόνες .NET Alpine εκτελούνται σε κατάσταση παγκοσμιοποίησης‑αμετάβλητης κατά προεπιλογή, και σε αυτήν την κατάσταση το Aspose.Slides σταματά με `CultureNotFoundException` για `en-US`.

Δημιουργήστε, εκτελέστε και αντιγράψτε το αποτέλεσμα με τις ίδιες εντολές όπως παραπάνω. Σε αυτήν την εικόνα, η εφαρμογή εκτυπώνει μόνο τη γραμμή `Saved`: με το Aspose.Slides.NET στο Linux, το fontconfig επιλέγει την αντικατάσταση για μια ελλιπή γραμματοσειρά, και το [GetSubstitutions](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/getsubstitutions/) δεν το αναφέρει. Η σελίδα [Deploy Fonts](/slides/el/net/deploy-fonts/) δείχνει πώς να ελέγξετε ποια γραμματοσειρά χρησιμοποιείται.

## **Συχνές Ερωτήσεις**

**Η εφαρμογή σταματά με "Unable to load shared library 'libaspose.slides.drawing.capi…'". Τι λείπει;**

Σε εικόνες Ubuntu και Debian, το πακέτο `libfontconfig1`; το μήνυμα αναφέρει το `libfontconfig.so.1` ως το αρχείο που δεν μπορούσε να ανοιχθεί. Σε Alpine Linux, το μήνυμα σημαίνει ότι χρησιμοποιείται το Aspose.Slides.NET6.CrossPlatform· μεταβείτε στο Aspose.Slides.NET όπως περιγράφεται στο [Run on Alpine Linux](#run-on-alpine-linux).

**Γιατί το κείμενο στο PDF εμφανίζεται με διαφορετική γραμματοσειρά από το PowerPoint;**

Οι γραμματοσειρές που χρησιμοποιεί η παρουσίαση δεν είναι εγκατεστημένες στην εικόνα, έτσι το Aspose.Slides σχεδιάζει το κείμενο με μια εναλλακτική γραμματοσειρά. Η έξοδος της εφαρμογής αναφέρει κάθε αντικατεστημένη γραμματοσειρά. Η σελίδα [Deploy Fonts](/slides/el/net/deploy-fonts/) εξηγεί πώς να εγκαταστήσετε γραμματοσειρές στην εικόνα ή να τις φορτώσετε από το φάκελο της εφαρμογής.

**Χρειάζομαι το .NET SDK στον υπολογιστή μου;**

Όχι. Το στάδιο κατασκευής μεταγλωττίζει την εφαρμογή μέσα στην εικόνα SDK. Χρειάζεστε το SDK μόνο αν θέλετε επίσης να δημιουργήσετε και να εκτελέσετε την εφαρμογή εκτός Docker· δείτε [Installation](/slides/el/net/installation/).