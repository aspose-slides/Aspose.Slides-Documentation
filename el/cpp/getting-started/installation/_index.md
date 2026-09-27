---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/cpp/installation/
keywords:
- εγκατάσταση Aspose.Slides
- λήψη Aspose.Slides
- χρήση Aspose.Slides
- εγκατάσταση Aspose.Slides
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εγκαταστήστε το Aspose.Slides για C++ στα Windows από το NuGet στο Visual Studio ή στα Linux από το πακέτο ZIP με το CMake και ελέγξτε την εγκατάσταση με ένα πρώτο πρόγραμμα."
---
## **Επισκόπηση**

Το Aspose.Slides για C++ διανέμεται σε δύο μορφές:

| Μορφή | Για ποιο σκοπό | Πού να το βρείτε |
|---|---|---|
| Πακέτα NuGet: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64-bit) και [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32-bit) | Έργα Visual Studio C++ σε Windows | NuGet |
| Πακέτα ZIP για Windows, Linux και macOS | Κατασκευές χωρίς NuGet, όπως έργα CMake | Η [σελίδα λήψης](https://releases.aspose.com/slides/cpp/) |

Αυτό το άρθρο δείχνει πώς να εγκαταστήσετε το πακέτο NuGet στο Visual Studio στα Windows και πώς να χρησιμοποιήσετε το πακέτο ZIP με CMake στο Linux. Και οι δύο διαδρομές καταλήγουν στον ίδιο έλεγχο: να χτίσετε και να εκτελέσετε το πρώτο παράδειγμα στο [Create Presentations](/slides/el/cpp/create-presentation/).

## **Windows**

Στα Windows, προσθέστε το πακέτο NuGet σε ένα έργο Visual Studio C++. Το πακέτο επίσης εγκαθιστά την εξάρτησή του, CodePorting.Translator.Cs2Cpp.Framework, και αντιγράφει τα DLL που χρειάζεται το πρόγραμμά σας στο φάκελο εξόδου της κατασκευής.

Επιλέξτε το πακέτο ανάλογα με την πλατφόρμα για την οποία κατασκευάζετε: **Aspose.Slides.Cpp** για x64 και **Aspose.Slides.Cpp.x86** για Win32 (x86). Το πακέτο Aspose.Slides.Cpp δεν εφαρμόζεται σε κατασκευή Win32, επομένως ο μεταγλωττιστής δεν μπορεί να βρει τις κεφαλίδες του εκεί.

Ένα πακέτο ZIP για Windows διατίθεται επίσης από τη [σελίδα λήψης](https://releases.aspose.com/slides/cpp/).

### **Μέθοδος 1: Εγκατάσταση ή Ενημέρωση Aspose.Slides από τον Διαχειριστή Πακέτων NuGet**

1. Ανοίξτε το Microsoft Visual Studio.  
2. Δημιουργήστε ένα έργο C++ **Console App**, ή ανοίξτε ένα υπάρχον έργο.  
3. Στον **Solution Explorer**, κάντε δεξί κλικ στο έργο και επιλέξτε **Manage NuGet Packages** (ή μεταβείτε στο **Project** > **Manage NuGet Packages**).  
4. Στην καρτέλα **Browse**, αναζητήστε το *Aspose.Slides.Cpp*.  
   ![Αναζήτηση για Aspose.Slides.Cpp στον Διαχειριστή Πακέτων NuGet](installation_1.png)  
5. Κάντε κλικ στο **Aspose.Slides.Cpp** (ή **Aspose.Slides.Cpp.x86** για 32-bit κατασκευή) και έπειτα κάντε κλικ στην **Install**.  
   * Εάν έχετε ήδη εγκαταστήσει το Aspose.Slides και θέλετε να το ενημερώσετε, κάντε κλικ στο **Update**.  

Το πακέτο κατεβάζεται και προστίθεται ως αναφορά στο έργο σας.

### **Μέθοδος 2: Εγκατάσταση ή Ενημέρωση Aspose.Slides μέσω της Κονσόλας Διαχείρισης Πακέτων**

1. Ανοίξτε το Microsoft Visual Studio.  
2. Δημιουργήστε ένα έργο C++ **Console App**, ή ανοίξτε ένα υπάρχον έργο.  
3. Μεταβείτε στο **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
   ![Άνοιγμα της Κονσόλας Διαχείρισης Πακέτων](installation_2.png)  
4. Εκτελέστε αυτήν την εντολή:

   ```powershell
   Install-Package Aspose.Slides.Cpp
```

   Για 32-bit (Win32) κατασκευή, εγκαταστήστε αντί γι’ αυτό το πακέτο x86:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

   ![Εκτέλεση της εντολής Install-Package](installation_3.png)

   Όταν ολοκληρωθεί η εγκατάσταση, εμφανίζονται μηνύματα επιβεβαίωσης. Το πακέτο διανέμεται υπό την [Aspose EULA](https://about.aspose.com/legal/eula).  
   ![Μηνύματα επιβεβαίωσης εγκατάστασης](installation_4.png)

   Για να ενημερώσετε το πακέτο, εκτελέστε `Update-Package Aspose.Slides.Cpp` (ή `Update-Package Aspose.Slides.Cpp.x86`) στην Κονσόλα Διαχείρισης Πακέτων.

### **Έλεγχος της Εγκατάστασης**

1. Αντικαταστήστε το περιεχόμενο του κύριου αρχείου *.cpp* του έργου (το αρχείο που περιέχει τη `main`) με το πρώτο παράδειγμα στο [Create Presentations](/slides/el/cpp/create-presentation/).  
2. Στη γραμμή εργαλείων, επιλέξτε την πλατφόρμα **x64**, ή **x86** εάν εγκαταστήσατε το Aspose.Slides.Cpp.x86.  
3. Πατήστε **Ctrl+F5** για να χτίσετε και να εκτελέσετε το πρόγραμμα.  

Το πρόγραμμα αποθηκεύει το *hello.pptx* στον φάκελο του έργου, ο οποίος είναι ο προεπιλεγμένος κατάλογος εργασίας όταν το Visual Studio εκτελεί ένα πρόγραμμα.

## **Linux**

Στο Linux, χρησιμοποιήστε το πακέτο ZIP για Linux με CMake. Περιέχει τη βιβλιοθήκη Aspose.Slides, την εξάρτηση CodePorting.Translator.Cs2Cpp.Framework και ένα αρχείο ρυθμίσεων CMake για καθένα από αυτά. Οι βιβλιοθήκες είναι κατασκευασμένες για Linux x86_64 με glibc 2.23 ή νεότερη.

1. Εγκαταστήστε έναν μεταγλωττιστή C++, make, CMake, unzip και τη βιβλιοθήκη fontconfig, από τις οποίες εξαρτώνται οι βιβλιοθήκες Aspose.Slides. Σε Debian και Ubuntu:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Δημιουργήστε ένα φάκελο έργου και μεταβείτε σε αυτόν:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. Κατεβάστε το Linux ZIP (**Aspose.Slides for C++ Linux**) από τη [σελίδα λήψης](https://releases.aspose.com/slides/cpp/) στο φάκελο του έργου και αποσυμπιέστε το στο υποφάκελο *aspose-slides-cpp*:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Δημιουργήστε ένα αρχείο με όνομα *CMakeLists.txt* στο φάκελο του έργου με το παρακάτω περιεχόμενο:

   ```cmake
   cmake_minimum_required(VERSION 3.13)
   project(HelloSlides CXX)

   set(CMAKE_CXX_STANDARD 14)
   set(CMAKE_CXX_STANDARD_REQUIRED ON)

   set(ASPOSE_SLIDES_DIR "${CMAKE_CURRENT_SOURCE_DIR}/aspose-slides-cpp")
   find_package(CodePorting.Translator.Cs2Cpp.Framework REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)
   find_package(Aspose.Slides.Cpp REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)

   add_executable(hello main.cpp)
   target_link_libraries(hello PRIVATE Aspose.Slides.Cpp)
   ```

   Οι δύο κλήσεις `find_package` φορτώνουν τα αρχεία ρυθμίσεων CMake από το αποσυμπιεσμένο πακέτο. Το framework εντοπίζεται πρώτα επειδή το Aspose.Slides εξαρτάται από αυτό. Η σύνδεση με τον στόχο `Aspose.Slides.Cpp` προσθέτει τους φακέλους include και και τις δύο βιβλιοθήκες στην κατασκευή.

5. Αποθηκεύστε το πρώτο παράδειγμα στο [Create Presentations](/slides/el/cpp/create-presentation/) ως *main.cpp* στο φάκελο του έργου.  
6. Κατασκευάστε και εκτελέστε το πρόγραμμα:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

Το πρόγραμμα αποθηκεύει το *hello.pptx* στον τρέχον φάκελο. Το CMake καταγράφει τη θέση των βιβλιοθηκών μέσα στο πρόγραμμα, οπότε δεν χρειάζεται να ορίσετε `LD_LIBRARY_PATH` εφόσον ο φάκελος *aspose-slides-cpp* παραμένει στη θέση του.

Οι γραμματοσειρές που χρησιμοποιούνται στις παρουσιάσεις σας, ή κατάλληλοι εναλλακτικοί τύποι, πρέπει να είναι εγκατεστημένοι στο σύστημα ώστε το κείμενο να αποδίδεται σωστά όταν μετατρέπετε διαφάνειες σε PDF ή εικόνες.

## **Συχνές ερωτήσεις**

**Υπάρχει δωρεάν έκδοση ή περιορισμός δοκιμής;**

Ναι. Χωρίς άδεια, το Aspose.Slides λειτουργεί σε λειτουργία αξιολόγησης: προσθέτει υδατογράφημα αξιολόγησης σε κάθε διαφάνεια που αποθηκεύει και περικοπεί το κείμενο που διαβάζει από παρουσιάσεις. Για να αφαιρέσετε αυτούς τους περιορισμούς, εφαρμόστε μια έγκυρη [άδεια](/slides/el/cpp/licensing/).

**Γιατί ο μεταγλωττιστής αναφέρει ότι δεν μπορεί να ανοίξει το *DOM/Presentation.h*;**

Το εγκατεστημένο πακέτο δεν ταιριάζει με την πλατφόρμα που κατασκευάζετε. Το Aspose.Slides.Cpp εφαρμόζεται μόνο σε κατασκευές x64, ενώ το Aspose.Slides.Cpp.x86 μόνο σε κατασκευές Win32. Επιλέξτε τη σωστή πλατφόρμα στο Visual Studio ή εγκαταστήστε το αντίστροφο πακέτο.