---
title: Πώς να εκτελέσετε το Aspose.Slides σε Docker
linktitle: Aspose.Slides σε Docker
type: docs
weight: 140
url: /el/net/how-to-run-aspose-slides-in-docker/
keywords:
- υποστηριζόμενο λειτουργικό σύστημα
- Aspose.Slides σε Docker
- κοντέινερ Docker
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- αποθετήριο εικόνων
- Windows Server Core
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Εκτελέστε το Aspose.Slides σε κοντέινερ Docker: διαμορφώστε εικόνες, εξαρτήσεις, γραμματοσειρές και άδειες χρήσης για τη δημιουργία επεκτάσιμων υπηρεσιών που επεξεργάζονται PowerPoint και OpenDocument."
---
## **Υποστηριζόμενα λειτουργικά συστήματα**
Το Aspose.Slides μπορεί να εκτελείται μέσα σε κοντέινερ Docker χρησιμοποιώντας την πλατφόρμα .NET Core. Γενικά, το Aspose.Slides υποστηρίζει όλους τους τύπους κοντέινερ (ΛΣ) που υποστηρίζει η πλατφόρμα .NET Core. Ωστόσο, το GDI ή το [libgdiplus ](https://github.com/mono/libgdiplus) πρέπει να είναι διαθέσιμο και σωστά ρυθμισμένο στα εμπλεκόμενα κοντέινερ.

Για να χρησιμοποιήσετε το Docker, πρέπει πρώτα να το εγκαταστήσετε στο σύστημά σας. Για να μάθετε πώς να εγκαταστήσετε το Docker στα Windows ή στο Mac, χρησιμοποιήστε τα παρακάτω links:

- [Εγκατάσταση Docker στα Windows](https://docs.docker.com/docker-for-windows/install/)
- [Εγκατάσταση Docker στο Mac](https://docs.docker.com/docker-for-mac/install/)

Μπορείτε επίσης να εκτελέσετε το Docker σε Linux και σε Windows Server ακολουθώντας τις οδηγίες στις παρακάτω σελίδες:

- [Εγκατάσταση και ρύθμιση Docker σε Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Εγκατάσταση και ρύθμιση Docker σε Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Εγκατάσταση και ρύθμιση Docker σε Windows Server Core](#install-and-configure-docker-on-windows-server-core)

Η εγκατάσταση και ρύθμιση του Docker σε Windows Server Nano δεν υποστηρίζεται. Δυστυχώς, το Windows Server Nano δεν περιέχει το σύστημα γραφικών. Δεν περιλαμβάνει το gdiplus.dll, το οποίο απαιτεί η βιβλιοθήκη System.Drawing.Common, και δεν μπορεί να χρησιμοποιηθεί με τη βιβλιοθήκη Aspose.Slides.

Παρόλο που είναι δυνατό να τρέξετε κοντέινερ Linux σε Windows, συνιστούμε να τα εκτελείτε εγγενώς σε Linux (ακόμα και σε Linux που έχει εγκατασταθεί χειροκίνητα σε VM με VirtualBox).

## **Εγκατάσταση και ρύθμιση Docker σε Linux (apt-get libgdiplus)**
- ΛΣ: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Αυτό το αρχείο Docker περιέχει οδηγίες για τη δημιουργία εικόνας κοντέινερ με το πακέτο libgdiplus εγκατεστημένο από τα επίσημα αποθετήρια πακέτων του Ubuntu.

Ακολουθεί το περιεχόμενο του αρχείου Docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# εγκατάσταση libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# δημιουργία σημείων προσάρτησης

VOLUME /slides-src

\# δόμηση και έλεγχος Aspose.Slides κατά την εκκίνηση

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Ας δούμε τι σημαίνει κάθε γραμμή κώδικα στο αρχείο Docker:

1. Η εικόνα του κοντέινερ βασίζεται στην εικόνα microsoft/dotnet:2.1-sdk-bionic (η εικόνα που έχει ήδη δημιουργηθεί από τη Microsoft και έχει δημοσιευθεί στο [public hub](https://hub.docker.com/r/microsoft/dotnet/)). Αυτή η εικόνα περιέχει το εγκατεστημένο dotnet 2.1 SDK. Το επίθημα Bionic σημαίνει ότι το Ubuntu 18.04 (κώδικα όνομα bionic) θα ληφθεί ως λειτουργικό σύστημα του κοντέινερ. Αλλάζοντας το επίθημα, είναι δυνατό να αλλάξει το υποκείμενο OS (π.χ. stretch – Debian 9, alpine – Alpine Linux). Σε αυτή την περίπτωση θα χρειαστεί τροποποίηση του περιεχομένου του αρχείου Docker (π.χ. αλλαγή του 'apt-get' σε 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. Ενημερώνει τη βάση δεδομένων των διαθέσιμων πακέτων και εγκαθιστά το πακέτο apt-utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. Εγκαθιστά τα πακέτα 'libgdiplus' και 'libc6-dev' που απαιτούνται από τη βιβλιοθήκη System.Drawing.Common.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. Δηλώνει τον φάκελο /slides-src ως σημείο προσάρτησης που θα χρησιμοποιηθεί για την παροχή πρόσβασης στο φάκελο πηγών slide‑net στον κεντρικό υπολογιστή.

``` csharp

 VOLUME /slides-src

```

1. Ορίζει το slides‑src ως τρέχον φάκελο εργασίας μέσα στο κοντέινερ.

``` csharp

 WORKDIR /slides-src

```

1. Ορίζει μια προεπιλεγμένη εντολή που θα εκτελείται κατά την εκκίνηση του κοντέινερ εάν δεν καθοριστεί ρητός εντολή.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Σύμφωνα με τις οδηγίες στο αρχείο Docker, η τελική εικόνα του κοντέινερ θα έχει εγκατεστημένα Ubuntu 18.04, dotnet‑sdk, libgdiplus και libc6‑dev. Επίσης, η εικόνα θα έχει προκαθορισμένο σημείο προσάρτησης και προκαθορισμένη εντολή στην εκτέλεση.

Για να δημιουργήσετε μια εικόνα χρησιμοποιώντας αυτό το αρχείο Docker, πρέπει να μεταβείτε στο φάκελο slides‑netuil docker και να εκτελέσετε:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* – η επιλογή καθορίζει ποιο αρχείο Docker θα χρησιμοποιηθεί.  
*-t ubuntu18_04_apt_get_libgdiplus* – καθορίζει την ετικέτα (όνομα) για την τελική εικόνα.  
*. * – καθορίζει το context για το Docker. Στην περίπτωση μας, το context είναι ο τρέχων φάκελος και είναι κενό—εφόσον επιλέγουμε να παρέχουμε τις πηγές slides‑net ως σημείο προσάρτησης (αυτό μας επιτρέπει να μην ξαναδημιουργούμε εικόνα Docker σε κάθε αλλαγή στις πηγές).

Το αποτέλεσμα της εκτέλεσης πρέπει να μοιάζει με το παρακάτω:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Για να βεβαιωθείτε ότι η νέα εικόνα προστέθηκε στο τοπικό αποθετήριο εικόνων:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Μόλις η εικόνα είναι έτοιμη, μπορούμε να την τρέξουμε με την εντολή:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* – υποδεικνύει ότι η εντολή πρέπει να εκτελεστεί διαδραστικά, ώστε να μπορούμε να δούμε την έξοδο και να καταγράψουμε την είσοδο.  
*-v `pwd`/../../:/slides-src* – καθορίζει το φάκελο για το προκαθορισμένο σημείο προσάρτησης—εφόσον ο τρέχων φάκελος εργασίας είναι slides‑netuildocker, τότε ο φάκελος slides‑src στο κοντέινερ θα δείχνει στο φάκελο slides‑net του κεντρικού υπολογιστή. Το `pwd` χρησιμοποιείται για τον καθορισμό σχετικής διαδρομής.  
*--add-host dev.slides.external.tool.server:192.168.1.48* – τροποποιεί το αρχείο hosts του κοντέινερ για την επίλυση του URL dev.slides.external.tool.server.  
*ubuntu1804aptgetlibgdiplus:latest* – καθορίζει την εικόνα που θα τρέξει το κοντέινερ.

Το αποτέλεσμα της παραπάνω εντολής θα είναι η έξοδος του netcore.linux.tests.sh (εφόσον έχει οριστεί ως προεπιλεγμένη εντολή για το κοντέινερ):

``` csharp

 Restoring packages for /slides-src/targets/.NETCore/tests/Aspose.Slides.FuncTests.NetCore/Aspose.Slides.FuncTests.NetCore.csproj...

Restoring packages for /slides-src/targets/.NETStandard/main/Aspose.Slides.DOM.NetStandard/Aspose.Slides.DOM.NetStandard.csproj...

Restoring packages for /slides-src/targets/.NETStandard/main/Aspose.Slides.CompoundFile.NetStandard/Aspose.Slides.CompoundFile.NetStandard.csproj...

Installing System.Text.Encoding.CodePages 4.4.0.

Installing System.Drawing.Common 4.5.0.

...

Results File: /slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.FuncTests.NetCore.trx

Total tests: Unknown. Passed: 2110. Failed: 108. Skipped: 210.

...

Results File: /slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.RegrTests.NetCore.trx

Total tests: 2124. Passed: 1550. Failed: 103. Skipped: 471.

```

Από το αποτέλεσμα φαίνεται ότι τα αρχεία καταγραφής από τα τεστ Func και Regr αποθηκεύτηκαν στον κατάλογο /build-out/netstandard20/test-results/main/. Επίσης, απέτυχαν περίπου 200 τεστ συνολικά—και όλα αυτά σχετίζονται με προβλήματα απόδοσης λόγω της έλλειψης απαιτούμενων γραμματοσειρών στο κοντέινερ.

Για να παρακάμψουμε την προεπιλεγμένη εντολή του κοντέινερ σε εκτέλεση, μπορούμε να χρησιμοποιήσουμε την εντολή:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Έτσι, αντί για το netcore.linux.tests.sh, θα εκτελεστεί το /bin/bash και θα παρέχει ενεργή συνεδρία τερματικού του κοντέινερ από την οποία μπορεί να τρέξει το (./build/netcore.linux.tests.sh). Αυτή η προσέγγιση μπορεί να είναι χρήσιμη σε σενάρια αντιμετώπισης προβλημάτων.

## **Εγκατάσταση και ρύθμιση Docker σε Linux (make install libgdiplus)**
- ΛΣ: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Προς το παρόν, το Ubuntu περιλαμβάνει μόνο την έκδοση 4.2 του libgdiplus ενώ η έκδοση 5.6 είναι ήδη διαθέσιμη στην [επίσημη ιστοσελίδα](https://github.com/mono/libgdiplus/releases). Για να δοκιμάσουμε την πιο πρόσφατη έκδοση του libgdiplus, πρέπει να προετοιμάσουμε μια εικόνα με το libgdiplus που θα χτιστεί από τις πηγές.

Ας δούμε το περιεχόμενο του αρχείου Docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# δημιουργία τελευταίας σταθερής libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# δημιουργία σημείων προσάρτησης

VOLUME /slides-src

\# δόμηση και έλεγχος Aspose.Slides κατά την εκκίνηση

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Η μόνη διαφορά είναι το τμήμα *build latest stable libgdiplus*. Αυτό το τμήμα εγκαθιστά όλα τα απαραίτητα εργαλεία για τη δημιουργία του libgdiplus, κλωνοποιεί τις πηγές και στη συνέχεια τις χτίζει και τις εγκαθιστά στη σωστή θέση. Όλα τα υπόλοιπα είναι ίδια με το [Install and configure Docker on Linux (apt-get libgdiplus)](/slides/el/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Σημείωση**: Μην ξεχάσετε να χρησιμοποιήσετε διαφορετικές ετικέτες εικόνας (ονομασίες) για την τελική εικόνα στις εντολές docker build και docker run:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Εγκατάσταση και ρύθμιση Docker σε Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Σημείωση**: Απαιτούνται Windows 10 Pro ή Windows Server 2016 για την εκτέλεση κοντέινερ Windows.

Δυστυχώς, η Microsoft δεν παρέχει εικόνα Windows Server Core με εγκατεστημένο το dotnet SDK, επομένως πρέπει να το εγκαταστήσουμε χειροκίνητα:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

# ορισμός προεπιλεγμένου εκτελεστή powershell

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

# ορισμός προεπιλεγμένου εκτελεστή powershell

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Retrieve .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 
    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

# επιστροφή cmd ως προεπιλεγμένου εκτελεστή

SHELL ["cmd", "/S", "/C"]

\# προκειμένου να οριστεί το σύστημα PATH, πρέπει να χρησιμοποιηθεί ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# δημιουργία σημείων προσάρτησης

VOLUME c:/slides-src

# δόμηση και έλεγχος Aspose.Slides κατά την εκκίνηση

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

Η τελική εικόνα θα βασίζεται στην εικόνα microsoft/windowsservercore:1803 που παρέχεται από τη Microsoft στο [docker hub](https://hub.docker.com/u/microsoft). Το dotnet‑sdk της καθορισμένης έκδοσης θα ληφθεί και θα αποσυμπιεστεί· η μεταβλητή PATH του συστήματος θα ενημερωθεί ώστε να περιλαμβάνει τη διαδρομή προς το εκτελέσιμο dotnet. Η τελευταία γραμμή ορίζει την εντολή που εκτελεί τα τεστ func & regr στο κοντέινερ χρησιμοποιώντας το nant.exe ως προεπιλεγμένη ενέργεια κατά την εκτέλεση του κοντέινερ.

Εντολή για δημιουργία της εικόνας:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Εντολή για εκτέλεση της εικόνας:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Σημείωση**: Η εντολή για το κοντέινερ Windows χρησιμοποιεί 2 επιπλέον παραμέτρους:

*-cpu-count 3*  
*-memory 8589934592*

Ορίζουν τον αριθμό πυρήνων και την ποσότητα μνήμης που διατίθενται στο κοντέινερ. Από προεπιλογή, μόνο 1 πυρήνας και 1 GB RAM είναι διαθέσιμα για το κοντέινερ Windows (τα κοντέινερ Linux δεν έχουν περιορισμούς από προεπιλογή).

Επίσης, λείπει μία παράμετρος σε σύγκριση με την εντολή που χρησιμοποιήσαμε για το κοντέινερ Linux:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Επειδή το κοντέινερ που τρέχει σε Windows δεν απαιτεί το external.tool.server.

Το αποτέλεσμα της παραπάνω εντολής πρέπει να μοιάζει με το παρακάτω:

``` csharp

 NAnt 0.92 (Build 0.92.4543.0; release; 6/9/2012)

Copyright (C) 2001-2012 Gerry Shaw

http://nant.sourceforge.net

netcore20_runtests:

   [delete] Deleting directory 'c:\slides-src\build-out\netcore20\test-results\'.

   [mkdir] Creating directory 'c:\slides-src\build-out\netcore20\test-results\'.

...

[exec] Results File: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.FuncTests.NetCore.trx

[exec] Total tests: 2338. Passed: 2115. Failed: 19. Skipped: 204.

...

[exec] Results File: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.RegrTests.NetCore.trx

[exec] Total tests: 2728. Passed: 2147. Failed: 110. Skipped: 471.

```