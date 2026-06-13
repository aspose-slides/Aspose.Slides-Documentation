---
title: Docker में Aspose.Slides चलाने का तरीका
linktitle: Docker में Aspose.Slides
type: docs
weight: 140
url: /hi/net/how-to-run-aspose-slides-in-docker/
keywords:
- समर्थित OS
- Docker में Aspose.Slides
- Docker कंटेनर
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- इमेज रिपॉज़िटरी
- Windows Server Core
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Docker कंटेनरों में Aspose.Slides चलाएँ: इमेज, निर्भरताएँ, फ़ॉन्ट और लाइसेंसिंग को कॉन्फ़िगर करें ताकि PowerPoint और OpenDocument को प्रोसेस करने वाली स्केलेबल सेवाएँ बनाई जा सकें।"
---
## **समर्थित OS**
Aspose.Slides .NET Core प्लेटफ़ॉर्म का उपयोग करके डॉकर कंटेनर के भीतर चल सकता है। सामान्यतः, Aspose.Slides उन सभी कंटेनर (OS) प्रकारों को समर्थन देता है जो .NET Core प्लेटफ़ॉर्म समर्थन करता है। हालांकि, GDI या [libgdiplus](https://github.com/mono/libgdiplus) कंटेनरों में उपलब्ध और सही ढंग से सेटअप होना आवश्यक है।

Docker का उपयोग करने के लिए, आपको पहले इसे अपनी प्रणाली पर स्थापित करना होगा। Windows या Mac पर Docker स्थापित करने के तरीके जानने के लिए, इन लिंक का उपयोग करें:

- [Windows पर Docker स्थापित करें](https://docs.docker.com/docker-for-windows/install/)
- [Mac पर Docker स्थापित करें](https://docs.docker.com/docker-for-mac/install/)

आप इन पृष्ठों पर दिए गए निर्देशों का पालन करके Linux और Windows Server पर भी Docker चला सकते हैं:

- [Linux पर Docker स्थापित और कॉन्फ़िगर करें (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Linux पर Docker स्थापित और कॉन्फ़िगर करें (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Windows Server Core पर Docker स्थापित और कॉन्फ़िगर करें](#install-and-configure-docker-on-windows-server-core)

Windows Server Nano पर Docker की स्थापना और कॉन्फ़िगरेशन समर्थित नहीं है। दुर्भाग्यवश, Windows Server Nano में ग्राफ़िक सब‑सिस्टम मौजूद नहीं है। इसमें gdiplus.dll नहीं है, जो System.Drawing.Common लाइब्रेरी को आवश्यक है, और इसे Aspose.Slides लाइब्रेरी के साथ उपयोग नहीं किया जा सकता।

हालाँकि Windows पर Linux कंटेनर चलाना संभव है, हम सलाह देते हैं कि उन्हें Linux पर मूल रूप से चलाएँ (भले ही VirtualBox का उपयोग करके VM पर मैन्युअली स्थापित Linux हो)।

## **Linux पर Docker स्थापित और कॉन्फ़िगर करें (apt-get libgdiplus)**
- ऑपरेटिंग सिस्टम: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

यह Docker फ़ाइल Ubuntu के आधिकारिक पैकेज रिपॉज़िटरी से libgdiplus पैकेज स्थापित करके कंटेनर इमेज बनाने के निर्देश देता है।

यहाँ Docker फ़ाइल की सामग्री है:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# libgdiplus स्थापित करें

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# माउंट पॉइंट बनाएं

VOLUME /slides-src

\# शुरू होने पर Aspose.Slides बनाएं और परीक्षण करें

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

आइए देखें कि Docker फ़ाइल की प्रत्येक पंक्ति का क्या अर्थ है:

1. कंटेनर की इमेज microsoft/dotnet:2.1-sdk-bionic इमेज पर आधारित है (यह इमेज Microsoft द्वारा पहले से बनाई गयी और Docker के [सार्वजनिक हब](https://hub.docker.com/r/microsoft/dotnet/) पर प्रकाशित है)। इस इमेज में पहले से स्थापित dotnet 2.1 SDK शामिल है। Bionic उपसर्ग का अर्थ है कि Ubuntu 18.04 (कोडनेम bionic) को कंटेनर के OS के रूप में लिया जाएगा। उपसर्ग बदलने पर अंतर्निहित OS बदलना संभव है (उदाहरण: stretch — Debian 9, alpine — Alpine Linux)। ऐसे में Docker फ़ाइल की सामग्री संशोधित करनी होगी (उदाहरण: 'apt-get' को 'yum' में बदलना)।

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

2. उपलब्ध पैकेजों के डेटाबेस को अपडेट करता है और apt-utils पैकेज स्थापित करता है।

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

3. 'System.Drawing.Common' लाइब्रेरी द्वारा आवश्यक 'libgdiplus' और 'libc6-dev' पैकेज स्थापित करता है।

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

4. /slides-src फ़ोल्डर को एक माउंटिंग पॉइंट के रूप में घोषित करता है जिसका उपयोग होस्ट मशीन पर slide-net स्रोत फ़ोल्डर तक पहुंच प्रदान करने के लिए किया जाएगा।

``` csharp

 VOLUME /slides-src

```

5. container के भीतर slides-src को कार्यशील निर्देशिका के रूप में सेट करता है।

``` csharp

 WORKDIR /slides-src

```

6. एक डिफ़ॉल्ट कमांड घोषित करता है जो कंटेनर के शुरू होने पर चलाया जाएगा यदि स्पष्ट कमांड निर्दिष्ट न किया गया हो।

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Docker फ़ाइल के निर्देशों के अनुसार, परिणामी कंटेनर इमेज में Ubuntu 18.04 OS, dotnet-sdk, libgdiplus और libc6-dev पैकेज पहले से स्थापित होंगे। साथ ही, इस इमेज में एक पूर्वनिर्धारित माउंट पॉइंट और रन के समय पूर्वनिर्धारित कमांड होगा।

इस Docker फ़ाइल का उपयोग करके इमेज बनाने के लिए, आपको slides-netuil Docker फ़ोल्डर में जाकर निम्न कमांड चलाना होगा:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

- f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -- विकल्प दर्शाता है कि कौन सी Docker फ़ाइल उपयोग करनी है।

- t ubuntu18_04_apt_get_libgdiplus -- परिणामी इमेज के टैग (नाम) को निर्दिष्ट करता है।

'.' -- Docker के लिए संदर्भ (context) निर्दिष्ट करता है। हमारे मामले में, संदर्भ वर्तमान फ़ोल्डर है और यह खाली है—क्योंकि हमने slides-net स्रोतों को माउंटिंग पॉइंट के रूप में प्रदान किया है (इससे स्रोतों में प्रत्येक परिवर्तन पर Docker इमेज को पुनः बनाने की जरूरत नहीं पड़ती)।

निष्पादन का परिणाम इस प्रकार दिखना चाहिए:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

यह सुनिश्चित करने के लिए कि नई इमेज स्थानीय इमेज रिपॉज़िटरी में जोड़ दी गई है:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

एक बार इमेज तैयार हो जाने पर, हम इसे निम्न कमांड से चला सकते हैं:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

- it -- यह दर्शाता है कि कमांड इंटरऐक्टिव रूप से चलाया जाएगा, जिससे हम आउटपुट देख सकें और इनपुट कैप्चर कर सकें।

- v `pwd`/../../:/slides-src -- पूर्वनिर्धारित माउंट पॉइंट के लिए फ़ोल्डर निर्दिष्ट करता है—क्योंकि वर्तमान कार्यशील डायरेक्टरी slides-netuildocker है, इसलिए कंटेनर में slides-src फ़ोल्डर होस्ट पर slides-net फ़ोल्डर की ओर इशारा करेगा। `pwd` का उपयोग सापेक्ष पथ निर्दिष्ट करने के लिए किया जाता है।

--add-host dev.slides.external.tool.server:192.168.1.48 -- कंटेनर की hosts फ़ाइल को संशोधित करके dev.slides.external.tool.server URL को रिज़ॉल्व करता है।

ubuntu1804aptgetlibgdiplus:latest -- कंटेनर चलाने के लिए इमेज निर्दिष्ट करता है।

उपरोक्त कमांड का परिणाम netcore.linux.tests.sh का आउटपुट होगा (क्योंकि इसे कंटेनर के लिए डिफ़ॉल्ट कमांड के रूप में परिभाषित किया गया था):

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

परिणाम से स्पष्ट है कि Func और Regr परीक्षणों की लॉग फ़ाइलें /build-out/netstandard20/test-results/main/ डायरेक्टरी में रखी गई थीं। साथ ही, कुल मिलाकर लगभग 200 परीक्षण विफल हुए—और ये सभी रेंडरिंग समस्याएँ आवश्यक फ़ॉन्ट्स की अनुपस्थिति के कारण कंटेनर में थीं।

कंटेनर के डिफ़ॉल्ट कमांड को ओवरराइड करने के लिए, हम इस कमांड का उपयोग कर सकते हैं:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

इसलिए, netcore.linux.tests.sh के बजाय /bin/bash निष्पादित होगा और यह कंटेनर की एक सक्रिय टर्मिनल सत्र प्रदान करेगा जिससे इसे (./build/netcore.linux.tests.sh) चलाया जा सकता है। यह तरीका समस्या निवारण स्थितियों में उपयोगी हो सकता है।

## **Linux पर Docker स्थापित और कॉन्फ़िगर करें (make install libgdiplus)**
- ऑपरेटिंग सिस्टम: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

वर्तमान में, Ubuntu में केवल libgdiplus का संस्करण 4.2 उपलब्ध है जबकि संस्करण 5.6 उत्पाद की [अधिकृत साइट](https://github.com/mono/libgdiplus/releases) पर पहले से उपलब्ध है। नवीनतम संस्करण का परीक्षण करने के लिए, हमें स्रोत से निर्मित libgdiplus के साथ एक इमेज तैयार करनी होगी।

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# नवीनतम स्थिर libgdiplus बनाएं

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# माउंट पॉइंट बनाएं

VOLUME /slides-src

\# शुरू होने पर Aspose.Slides बनाएं और परीक्षण करें

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

एकमात्र अंतर *build latest stable libgdiplus* सेक्शन में है। यह सेक्शन libgdiplus को बनाने के लिए आवश्यक सभी उपकरण स्थापित करता है, स्रोत को क्लोन करता है, फिर उन्हें बनाता है और सही स्थान पर स्थापित करता है। बाकी सब [Linux (apt-get libgdiplus) पर Docker स्थापित और कॉन्फ़िगर करें](/slides/hi/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/) जैसा ही है।

**नोट**: Docker build और Docker run कमांडों पर परिणामी इमेज के लिए विभिन्न इमेज टैग (नाम) का उपयोग करना न भूलें:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Windows Server Core पर Docker स्थापित और कॉन्फ़िगर करें**
- ऑपरेटिंग सिस्टम: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**नोट**: Windows कंटेनरों को चलाने के लिए Windows 10 Pro या Windows Server 2016 आवश्यक है।

दुर्भाग्य से, Microsoft Windows Server Core इमेज में dotnet SDK स्थापित नहीं देता, इसलिए हमें इसे मैन्युअल रूप से स्थापित करना होगा:

``` csharp

 # एस्केप=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell डिफ़ॉल्ट कार्यकर्ता

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell डिफ़ॉल्ट कार्यकर्ता

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

# .NET Core SDK प्राप्त करें

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 
    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

# cmd को डिफ़ॉल्ट कार्यकर्ता के रूप में लौटाएँ

SHELL ["cmd", "/S", "/C"]

# सिस्टम PATH सेट करने के लिए, ContainerAdministrator का उपयोग करना आवश्यक है

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

# माउंट पॉइंट बनाएं

VOLUME c:/slides-src

# शुरू होने पर Aspose.Slides बनाएं और परीक्षण करें

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```

परिणामी इमेज microsoft/windowsservercore:1803 इमेज पर आधारित होगी, जिसे Microsoft ने [docker hub](https://hub.docker.com/u/microsoft) पर प्रदान किया है। निर्दिष्ट संस्करण का dotnet-sdk डाउनलोड और अनज़िप किया जाएगा; सिस्टम की PATH वैरिएबल को dotnet निष्पादन योग्य के पथ को शामिल करने के लिए अपडेट किया जाएगा। अंतिम पंक्ति वह कमांड परिभाषित करती है जो कंटेनर पर nant.exe का उपयोग करके func और regr परीक्षण चलाती है, इसे कंटेनर रन पर डिफ़ॉल्ट कार्रवाई के रूप में सेट किया गया है।

इमेज बनाने का कमांड:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

इमेज चलाने का कमांड:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**नोट**: Windows कंटेनर के कमांड में 2 अतिरिक्त तर्क उपयोग होते हैं:
- cpu-count 3 -- कंटेनर के लिए कोर की संख्या को 3 सेट करता है।
- memory 8589934592 -- कंटेनर के लिए उपलब्ध मेमोरी को 8589934592 बाइट (8 GB) सेट करता है।

ये कंटेनर के लिए उपलब्ध कोरों की संख्या और मेमोरी की मात्रा निर्धारित करते हैं। डिफ़ॉल्ट रूप से, Windows कंटेनर में केवल 1 कोर और 1 GB RAM उपलब्ध होता है (Linux कंटेनरों में डिफ़ॉल्ट रूप से कोई सीमाएँ नहीं होती)।

साथ ही, Linux कंटेनर चलाने के लिए उपयोग किए गए समान कमांड की तुलना में 1 तर्क अनुपस्थित है:
- add-host dev.slides.external.tool.server:192.168.1.48 -- यह तर्क Windows कंटेनर के लिए आवश्यक नहीं है।

क्योंकि Windows पर चलने वाला कंटेनर external.tool.server की आवश्यकता नहीं रखता।

उपरोक्त कमांड का परिणाम इस प्रकार दिखना चाहिए:

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