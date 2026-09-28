---
title: "Ανάπτυξη γραμματοσειρών για Aspose.Slides σε Linux και σε Docker"
linktitle: "Ανάπτυξη γραμματοσειρών"
type: docs
weight: 145
url: /el/net/deploy-fonts/
keywords:
- "ανάπτυξη γραμματοσειρών"
- "εγκατάσταση γραμματοσειρών"
- "γραμματοσειρές σε Docker"
- "γραμματοσειρές σε Linux"
- "ελλείπουσες γραμματοσειρές"
- "αντικατάσταση γραμματοσειρών"
- "Βασικές γραμματοσειρές Microsoft"
- "ttf-mscorefonts-installer"
- "προσαρμοσμένες γραμματοσειρές"
- "προεπιλεγμένη γραμματοσειρά"
- "διακομιστής"
- "container"
- "μετατροπή PDF"
- "παρουσίαση"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Ανάπτυξη γραμματοσειρών για Aspose.Slides για .NET σε διακομιστές Linux και σε containers Docker: ελέγξτε ποιες γραμματοσειρές αντικαθίστανται, εγκαταστήστε πακέτα γραμματοσειρών σε Debian, Ubuntu και Alpine, προσθέστε τα δικά σας αρχεία γραμματοσειρών και ορίστε μια προεπιλεγμένη γραμματοσειρά."
---
## **Επισκόπηση**

Aspose.Slides σχεδιάζει το κείμενο με τις γραμματοσειρές που είναι διαθέσιμες όταν αποδίδει μια παρουσίαση, για παράδειγμα όταν μετατρέπει διαφάνειες σε PDF ή σε εικόνες. Ένα Windows desktop συνήθως διαθέτει τις γραμματοσειρές που χρησιμοποιούν οι παρουσιάσεις. Τα Linux servers και τα containers συνήθως έχουν λίγες ή καθόλου γραμματοσειρές, έτσι το Aspose.Slides σχεδιάζει το κείμενο με εναλλακτική γραμματοσειρά. Μία εναλλακτική γραμματοσειρά έχει διαφορετικά σχήματα και πλάτη γραμμάτων, επομένως οι γραμμές μπορεί να τυλίγονται διαφορετικά και το κείμενο μπορεί να ξεχειλώνει από το σχήμα του, ενώ οι χαρακτήρες που λείπουν από την εναλλακτική γραμματοσειρά δεν σχεδιάζονται σωστά. Εάν δεν είναι εγκατεστημένη καμία γραμματοσειρά, η μετατροπή διακόπτεται με σφάλμα.

Αυτό το άρθρο δείχνει πώς να ελέγξετε ποιες γραμματοσειρές αντικαθιστά το Aspose.Slides, πώς να εγκαταστήσετε γραμματοσειρές σε Debian, Ubuntu και Alpine Linux, πώς να προσθέσετε τα δικά σας αρχεία γραμματοσειρών και πώς να ορίσετε τη γραμματοσειρά που χρησιμοποιείται όταν λείπει μια γραμματοσειρά. Τα παραδείγματα εκτελούνται σε Docker με τις επίσημες εικόνες .NET, όπως στη [Εκτέλεση Aspose.Slides για .NET σε Docker](/slides/el/net/how-to-run-aspose-slides-in-docker/). Οι εντολές του πακέτου είναι οδηγίες Dockerfile· σε ένα Linux server, εκτελέστε τις ίδιες εντολές ως root.

Για το ίδιο το API γραμματοσειρών, όπως η ενσωμάτωση γραμματοσειρών σε παρουσίαση και οι κανόνες εναλλακτικών και αντικατάστασης, δείτε το [PowerPoint Fonts](/slides/el/net/powerpoint-fonts/).

## **Έλεγχος Ποιες Γραμματοσειρές Αντικαθίστανται**

Η παρακάτω εφαρμογή κονσόλας αναφέρει τις γραμματοσειρές που αντικαθιστά το Aspose.Slides στο τρέχον περιβάλλον. Δημιουργήστε έναν φάκελο με όνομα *FontCheck* και προσθέστε τα παρακάτω αρχεία σε αυτόν.

*FontCheck.csproj* αναφέρεται στο [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), το πακέτο για Debian και Ubuntu. Επίσης αντιγράφει τα αρχεία ενός προαιρετικού φακέλου *fonts* στην έξοδο της εφαρμογής· η ενότητα [Φόρτωση Γραμματοσειρών από τον Φάκελο Εφαρμογής](`#load-fonts-from-the-application-folder`) το χρησιμοποιεί.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* προσθέτει ένα πλαίσιο κειμένου ανά όνομα γραμματοσειράς σε μια διαφάνεια και αναθέτει τη γραμματοσειρά μέσω της ιδιότητας [LatinFont](https://reference.aspose.com/slides/el/net/aspose.slides/baseportionformat/latinfont/). Τα ονόματα γραμματοσειρών προέρχονται από τη γραμμή εντολών· χωρίς ορίσματα, η εφαρμογή ελέγχει Calibri, Arial και Times New Roman. Εκτυπώνει τους φακέλους στους οποίους το Aspose.Slides ψάχνει για γραμματοσειρές ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/getfontfolders/)), αποδίδει τη διαφάνεια στο *output/fonts.pdf* και εκτυπώνει τις αντικαταστάσεις που αναφέρει το [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/el/net/aspose.slides/ifontsmanager/getsubstitutions/). Τα δύο προαιρετικά βήματα στην αρχή, η φόρτωση ενός φακέλου *fonts* και η ανάγνωση της μεταβλητής `DEFAULT_FONT`, εξηγούνται παρακάτω σε αυτό το άρθρο.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// Οι γραμματοσειρές που θα ελεγχθούν: τα ορίσματα γραμμής εντολών ή τρεις κοινές γραμματοσειρές Office.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Φορτώστε τα αρχεία γραμματοσειρών από το φάκελο fonts δίπλα στην εφαρμογή, εάν υπάρχει.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Χρησιμοποιήστε τη γραμματοσειρά που ορίζεται στη μεταβλητή περιβάλλοντος DEFAULT_FONT, εάν έχει οριστεί, για κείμενο του οποίου λείπει η γραμματοσειρά.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* διατηρεί τα τοπικά αποτελέσματα κατασκευής εκτός του build context:

```text
bin/
obj/
output/
```

*Dockerfile* κατασκευάζει την εφαρμογή με τη εικόνα .NET SDK και την εκτελεί στην εικόνα χρόνου εκτέλεσης .NET. Η φάση χρόνου εκτέλεσης εγκαθιστά `libfontconfig1`, το οποίο απαιτεί το Aspose.Slides.NET6.CrossPlatform, και τις γραμματοσειρές DejaVu. Το [Εκτέλεση Aspose.Slides για .NET σε Docker](/slides/el/net/how-to-run-aspose-slides-in-docker/) εξηγεί κάθε οδηγία.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Κατασκευή της εικόνας και εκτέλεση του ελέγχου:

```bash
docker build -t font-check .
docker run --rm font-check
```

Η εικόνα περιέχει μόνο τις γραμματοσειρές DejaVu, έτσι και οι τρεις γραμματοσειρές αντικαθίστανται με DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Για να ελέγξετε τις γραμματοσειρές των δικών σας παρουσιάσεων, περάστε τα ονόματά τους ως ορίσματα, π.χ. `docker run --rm font-check "Segoe UI" Consolas`. Για να αντιγράψετε το *output/fonts.pdf* έξω από το container, χρησιμοποιήστε τις εντολές στο [Αντιγραφή του Αποτελέσματος στο Μηχάνημά Σας](/slides/el/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Εγκατάσταση Γραμματοσειρών σε Debian και Ubuntu**

### **Microsoft Core Fonts**

Το πακέτο `ttf-mscorefonts-installer` κατεβάζει και εγκαθιστά τις βασικές γραμματοσειρές της Microsoft για το web, μεταξύ άλλων Arial, Times New Roman, Courier New, Verdana, Georgia και Trebuchet MS. Οι γραμματοσειρές αδειάζονται υπό την άδεια λήψης του χρήστη της Microsoft (EULA), και το πακέτο τις εγκαθιστά μόνο μετά την αποδοχή της EULA. Ένα Docker build δεν μπορεί να απαντήσει στη προτροπή, έτσι ο εγκαταστάτης απορρίπτει την EULA και δεν εγκαθιστά γραμματοσειρές, ενώ το `apt-get install` εξακολουθεί να αναφέρει επιτυχία. Αποδεχθείτε την EULA με `debconf-set-selections` **πριν** την εγκατάσταση του πακέτου.

Στο *Dockerfile*, αντικαταστήστε την οδηγία `RUN` που εγκαθιστά τα πακέτα στη φάση χρόνου εκτέλεσης με:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Κατασκευάστε ξανά την εικόνα και εκτελέστε ξανά τον έλεγχο με τις ίδιες δύο εντολές. Τώρα το Arial και το Times New Roman είναι εγκατεστημένα:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Η Calibri, η προεπιλεγμένη γραμματοσειρά μιας παρουσίασης που δημιουργεί το Aspose.Slides, δεν είναι μία από τις βασικές γραμματοσειρές, έτσι αντικαθίσταται ακόμα. Δείτε το [Ορισμός Προεπιλεγμένης Γραμματοσειράς για Ελλείπουσες Γραμματοσειρές](`#set-a-default-font-for-missing-fonts`).

Σε Debian, το πακέτο βρίσκεται στο component αποθετηρίου `contrib`, το οποίο οι εικόνες Debian δεν ενεργοποιούν· οι προεπιλεγμένες εικόνες .NET 8 και .NET 9 βασίζονται στο Debian 12. Ενεργοποιήστε το `contrib` στην ίδια οδηγία:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Οι εικόνες .NET 10 βασισμένες στο Ubuntu ενεργοποιούν ήδη το `multiverse`, το component του Ubuntu που περιέχει το πακέτο.

### **Άλλα Πακέτα Γραμματοσειρών**

Debian και Ubuntu παρέχουν επίσης ελεύθερα αδειοδοτημένες γραμματοσειρές, π.χ.:

| Πακέτο | Γραμματοσειρές |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, και Mono, με τα ίδια μετρικά με Arial, Times New Roman και Courier New |
| `fonts-crosextra-carlito` | Carlito, με τα ίδια μετρικά με Calibri |
| `fonts-crosextra-caladea` | Caladea, με τα ίδια μετρικά με Cambria |

Εγκαταστήστε τα με `apt-get install` στην ίδια οδηγία `RUN`. Το Aspose.Slides.NET6.CrossPlatform δεν εφαρμόζει τα ψευδώνυμα γραμματοσειρών της ρύθμισης γραμματοσειρών του Linux: με το `fonts-liberation` εγκατεστημένο, το κείμενο σε Arial εξακολουθεί να σχεδιάζεται με τη γενική εναλλακτική γραμματοσειρά, όχι με Liberation Sans. Για να χρησιμοποιήσετε μια γραμματοσειρά συμβατή με τα μετρικά αντί μιας που λείπει, ορίστε την ως [προεπιλεγμένη γραμματοσειρά](#set-a-default-font-for-missing-fonts) ή προσθέστε έναν [κανόνα αντικατάστασης γραμματοσειράς](/slides/el/net/font-substitution/).

## **Προσθήκη Δικών Σας Αρχείων Γραμματοσειράς**

Οι γραμματοσειρές που δεν συσκευάζονται από τις διανομές, όπως οι γραμματοσειρές του οργανισμού σας ή άλλες που έχετε άδεια χρήσης στον server, μπορούν να προστεθούν ως αρχεία γραμματοσειράς. Τοποθετήστε τα αρχεία γραμματοσειράς, π.χ. αρχεία *.ttf*, σε φάκελο *fonts* μέσα στον φάκελο *FontCheck*. Τα παραδείγματα παρακάτω χρησιμοποιούν τα αρχεία του Carlito, μιας γραμματοσειράς με τα ίδια μετρικά με Calibri, τα οποία μπορείτε να κατεβάσετε από το [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Εγκατάσταση των Γραμματοσειρών σε Φάκελο Συστήματος Γραμματοσειρών**

Το Aspose.Slides διαβάζει τις γραμματοσειρές στους φακέλους που εκτυπώνονται στη γραμμή `Font folders`. Για να εγκαταστήσετε τις γραμματοσειρές σας για κάθε εφαρμογή στην εικόνα, αντιγράψτε τες στο */usr/local/share/fonts*, τον φάκελο για τοπικά εγκατεστημένες γραμματοσειρές. Προσθέστε αυτή την οδηγία στη φάση χρόνου εκτέλεσης του *Dockerfile*, μετά την οδηγία `RUN` που εγκαθιστά τα πακέτα:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Φόρτωση Γραμματοσειρών από τον Φάκελο Εφαρμογής**

Αντί να εγκαταστήσετε τις γραμματοσειρές στην εικόνα, μπορείτε να τις συμπεριλάβετε με την εφαρμογή και να τις φορτώσετε με το [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsloader/loadexternalfonts/). Οι γραμματοσειρές είναι τότε διαθέσιμες μόνο στο Aspose.Slides και αναπτύσσονται μαζί με την εφαρμογή. Το *FontCheck* το κάνει αυτό: το *FontCheck.csproj* αντιγράφει τον φάκελο *fonts* στην έξοδο της εφαρμογής, και το *Program.cs* περνά αυτόν τον φάκελο στο `LoadExternalFonts` πριν δημιουργήσει την παρουσίαση. Το [Custom Font](/slides/el/net/custom-font/) περιγράφει άλλους τρόπους παροχής γραμματοσειρών, όπως η φόρτωση από μνήμη.

Ανακατασκευάστε την εικόνα, στη συνέχεια ελέγξτε Calibri και Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Ο φάκελος εφαρμογής εμφανίζεται τώρα ανάμεσα στους φακέλους γραμματοσειρών, και το Carlito δεν αντικαθίσταται πλέον:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Ορισμός Προεπιλεγμένης Γραμματοσειράς για Ελλείπουσες Γραμματοσειρές**

Όταν λείπει μια γραμματοσειρά, το Aspose.Slides χρησιμοποιεί μια εναλλακτική που επιλέγει αυτόματα. Για να την επιλέξετε εσείς, ορίστε την ιδιότητα [DefaultRegularFont](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/defaultregularfont/) του [LoadOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/) και περάστε τις επιλογές στον κατασκευαστή του [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/). Το *FontCheck* διαβάζει το όνομα γραμματοσειράς από τη μεταβλητή περιβάλλοντος `DEFAULT_FONT`. Με το Carlito φορτωμένο, χρησιμοποιήστε το για ελλείπουσες γραμματοσειρές:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Τώρα η Calibri σχεδιάζεται με Carlito, των οποίων οι χαρακτήρες έχουν το ίδιο πλάτος με αυτούς της Calibri, έτσι το κείμενο διατηρεί τις αλλαγές γραμμής:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Η προεπιλεγμένη γραμματοσειρά αντικαθιστά κάθε ελλείπουσα γραμματοσειρά. Για χαρτογράφηση μεμονωμένων γραμματοσειρών, π.χ. Arial σε Liberation Sans και Calibri σε Carlito, χρησιμοποιήστε [κανόνες αντικατάστασης γραμματοσειράς](/slides/el/net/font-substitution/). Οι κανόνες αλλάζουν το παραγόμενο αποτέλεσμα, αλλά το `GetSubstitutions` δεν τα αντικατοπτρίζει, οπότε ελέγξτε τις γραμματοσειρές στο αρχείο εξόδου. Για ασιατικό κείμενο, ορίστε επίσης το [DefaultAsianFont](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/defaultasianfont/); δείτε το [Default Font](/slides/el/net/default-font/).

## **Εγκατάσταση Γραμματοσειρών σε Alpine Linux**

Σε Alpine Linux, χρησιμοποιήστε το πακέτο Aspose.Slides.NET· η ενότητα [Εκτέλεση σε Alpine Linux](/slides/el/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) παραθέτει τις αλλαγές στο project. Κάντε τις ίδιες αλλαγές στο *FontCheck*: αντικαταστήστε την αναφορά πακέτου, προσθέστε τη δήλωση `SetSwitch` στο *Program.cs* και χρησιμοποιήστε αυτή τη φάση χρόνου εκτέλεσης, η οποία εγκαθιστά επίσης τις Microsoft core fonts:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Το `update-ms-fonts` κατεβάζει και εγκαθιστά τις ίδιες Microsoft core fonts όπως το πακέτο Debian και Ubuntu, και η EULA τους εφαρμόζεται με τον ίδιο τρόπο. Το `fc-cache` ενημερώνει την κρυφή μνήμη γραμματοσειρών.

Με το Aspose.Slides.NET σε Linux, η βιβλιοθήκη ρύθμισης γραμματοσειρών (fontconfig) επιλέγει την εναλλακτική για μια ελλείπουσα γραμματοσειρά, και το `GetSubstitutions` δεν την αναφέρει, έτσι το *FontCheck* εκτυπώνει `No font substitutions.` Για να δείτε ποια γραμματοσειρά χρησιμοποιείται για ένα όνομα γραμματοσειράς, ρωτήστε το fontconfig στο container:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Με τις Microsoft core fonts εγκατεστημένες, το Arial χρησιμοποιείται για Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Χωρίς αυτές, όταν η οδηγία `RUN` εγκαθιστά μόνο `icu-libs libgdiplus font-dejavu`, η ίδια εντολή εκτυπώνει:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **Συχνές Ερωτήσεις**

**Γιατί μια παρουσίαση φαίνεται διαφορετική όταν μετατρέπεται σε server;**

Ο server δεν διαθέτει τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση, έτσι το Aspose.Slides σχεδιάζει το κείμενο με εναλλακτική γραμματοσειρά των οποίων τα γράμματα έχουν διαφορετικό πλάτος. Εκτελέστε το *FontCheck* με τα ονόματα γραμματοσειρών της παρουσίασης για να δείτε ποιες αντικαθιστώνται, έπειτα εγκαταστήστε τις γραμματοσειρές ή φορτώστε τες από τον φάκελο της εφαρμογής.

**Η κατασκευή εγκατέστησε ttf-mscorefonts-installer, αλλά το Arial εξακολουθεί να αντικαθίσταται. Γιατί;**

Η EULA δεν είχε αποδεχθεί πριν την εγκατάσταση του πακέτου, έτσι ο εγκαταστάτης παρέλειψε τις γραμματοσειρές. Προσθέστε την εντολή `debconf-set-selections` πριν το `apt-get install`, όπως φαίνεται στα [Microsoft Core Fonts](#microsoft-core-fonts), και ξανακατασκευάστε την εικόνα.

**Χρειάζεται ο υπολογιστής που ανοίγει το PDF να έχει τις γραμματοσειρές;**

Όχι. Σε αυτά τα παραδείγματα, το PDF περιέχει τις γραμματοσειρές που χρησιμοποιήθηκαν για το σχεδιασμό του κειμένου, επομένως εμφανίζεται το ίδιο σε οποιονδήποτε υπολογιστή. Οι γραμματοσειρές απαιτούνται μόνο όπου το Aspose.Slides αποδίδει την παρουσίαση.