---
title: كيفية تشغيل Aspose.Slides في Docker
linktitle: Aspose.Slides في Docker
type: docs
weight: 140
url: /ar/net/how-to-run-aspose-slides-in-docker/
keywords:
- أنظمة التشغيل المدعومة
- Aspose.Slides في Docker
- حاوية Docker
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- مستودع الصور
- Windows Server Core
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تشغيل Aspose.Slides في حاويات Docker: تكوين الصور، والاعتمادات، والخطوط، والترخيص لإنشاء خدمات قابلة للتوسع تقوم بمعالجة PowerPoint و OpenDocument."
---

## **أنظمة التشغيل المدعومة**
يمكن لـ Aspose.Slides العمل داخل حاويات Docker باستخدام منصة .NET Core. بشكل عام، يدعم Aspose.Slides جميع أنواع الحاويات (أنظمة التشغيل) التي يدعمها منصة .NET Core. ومع ذلك، يجب أن تكون مكتبة GDI أو [libgdiplus](https://github.com/mono/libgdiplus) متاحة ومُعدّة بشكل صحيح على الحاويات المعنية.

لاستخدام Docker، يجب أولاً تثبيته على نظامك. لتعلم كيفية تثبيت Docker على Windows أو Mac، استخدم الروابط التالية:

- [تثبيت Docker على Windows](https://docs.docker.com/docker-for-windows/install/)
- [تثبيت Docker على Mac](https://docs.docker.com/docker-for-mac/install/)

يمكنك أيضاً تشغيل Docker على Linux وWindows Server باتباع التعليمات في هذه الصفحات:

- [تثبيت وتكوين Docker على Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [تثبيت وتكوين Docker على Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [تثبيت وتكوين Docker على Windows Server Core](#install-and-configure-docker-on-windows-server-core)

التثبيت والتكوين لـ Docker على Windows Server Nano غير مدعوم. للأسف، لا يحتوي Windows Server Nano على نظام الرسوميات المدمج. فهو لا يحتوي على gdiplus.dll الذي تتطلبه مكتبة System.Drawing.Common، ولا يمكن استخدامه مع مكتبة Aspose.Slides.

على الرغم من إمكانية تشغيل حاويات Linux على Windows، نوصي بتشغيلها أصلاً على Linux (حتى لو تم تثبيت Linux يدويًا على جهاز افتراضي باستخدام VirtualBox).

## **تثبيت وتكوين Docker على Linux (apt-get libgdiplus)**
- نظام التشغيل: Ubuntu 18.04.
- ملف Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

يحتوي هذا الملف على تعليمات لإنشاء صورة حاوية مع تثبيت حزمة libgdiplus من مستودعات الحزم الرسمية لـ Ubuntu.

إليك محتويات ملف Dockerfile:
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# تثبيت libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# إنشاء نقاط التثبيت

VOLUME /slides-src

\# بناء واختبار Aspose.Slides عند البدء

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


لنستعرض ما يعنيه كل سطر من الشيفرة في ملف Dockerfile:

1. تعتمد صورة الحاوية على صورة microsoft/dotnet:2.1-sdk-bionic (الصورة التي بنيتها Microsoft ونشرتها على [Docker Hub العام](https://hub.docker.com/r/microsoft/dotnet/)). تحتوي هذه الصورة على SDK dotnet 2.1 مُثبت مسبقًا. يعني اللاحقة Bionic أن Ubuntu 18.04 (الاسم الرمزي bionic) سيُختار كنظام تشغيل الحاوية. بتغيير اللاحقة يمكن تغيير نظام التشغيل الأساسي (مثال: stretch → Debian 9، alpine → Alpine Linux). في هذه الحالة يلزم تعديل محتوى Dockerfile (مثال: تغيير 'apt-get' إلى 'yum').
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:
```


1. تحديث قاعدة بيانات الحزم المتاحة وتثبيت حزمة apt‑utils.
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


1. تثبيت حزم 'libgdiplus' و 'libc6-dev' المطلوبة من قبل مكتبة System.Drawing.Common.
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


1. تعريف مجلد /slides-src كنقطة تثبيت سنستخدمها لتوفير الوصول إلى مجلد مصادر slide‑net على الجهاز المضيف.
``` csharp

 VOLUME /slides-src

```


1. تعيين slides‑src كدليل عمل داخل الحاوية.
``` csharp

 WORKDIR /slides-src

```


1. تعريف أمر افتراضي سيُنفّذ عند بدء تشغيل الحاوية في حال عدم تحديد أمر صريح.
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


وفقًا للتعليمات في Dockerfile، ستحمل صورة الحاوية الناتجة نظام Ubuntu 18.04، وdotnet‑sdk، وحزم libgdiplus وlibc6‑dev مسبقًا. كما سيتوفر لديها نقطة تثبيت مسبقة وأمر افتراضي عند التشغيل.

لبناء صورة باستخدام هذا Dockerfile، انتقل إلى مجلد slides‑netuil docker ونفذ:
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- يحدد أي ملف Dockerfile يُستخدم.  
*-t ubuntu18_04_apt_get_libgdiplus* -- يحدد العلامة (الاسم) للصورة الناتجة.  
*'.'* -- يحدد سياق Docker. في حالتنا، السياق هو المجلد الحالي وهو فارغ—لأننا نختار توفير مصادر slides‑net كنقطة تثبيت (هذا يتيح لنا عدم إعادة بناء صورة Docker عند كل تغيير في المصادر).

نتيجة التنفيذ يجب أن تبدو هكذا:
``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


للتحقق من إضافة الصورة الجديدة إلى مستودع الصور المحلي:
``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


بمجرد جاهزية الصورة، يمكن تشغيلها بالأمر التالي:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*-it* -- يُشير إلى تشغيل الأمر تفاعليًا، مما يسمح برؤية المخرجات وإدخال البيانات.  
*-v `pwd`/../../:/slides-src* -- يحدد المجلد لنقطة التثبيت المسبقة—نظرًا لأن دليل العمل الحالي هو slides‑netuildocker، فسيشير مجلد slides‑src داخل الحاوية إلى مجلد slides‑net على المضيف. يُستخدم `pwd` لتحديد المسار النسبي.  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- يُعدّل ملف hosts داخل الحاوية لتحديد عنوان dev.slides.external.tool.server.  
*ubuntu1804aptgetlibgdiplus:latest* -- يحدد الصورة التي ستُشغّل الحاوية.

نتيجة الأمر أعلاه ستكون مخرجات netcore.linux.tests.sh (لأنها مُحددة كأمر افتراضي للحاوية):
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


من النتيجة يتضح أن ملفات السجل من اختبارات Func وRegr وُضعت في الدليل /build-out/netstandard20/test-results/main/. كما فشل حوالي 200 اختبار—وكلها تتعلق بمشكلات عرض ناتجة عن عدم وجود الخطوط المطلوبة داخل الحاوية.

لتجاوز الأمر الافتراضي للحاوية عند تشغيلها، يمكن استخدام الأمر:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


وبذلك، بدلاً من netcore.linux.tests.sh، سيتم تشغيل /bin/bash وسيُوفّر جلسة طرفية نشطة داخل الحاوية يمكن منها تشغيل (./build/netcore.linux.tests.sh). هذه الطريقة قد تكون مفيدة في سيناريوهات استكشاف الأخطاء.

## **تثبيت وتكوين Docker على Linux (make install libgdiplus)**
- نظام التشغيل: Ubuntu 18.04.
- ملف Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

حاليًا، يحتوي Ubuntu فقط على الإصدار 4.2 من libgdiplus بينما الإصدار 5.6 متوفر بالفعل على [الموقع الرسمي للمنتج](https://github.com/mono/libgdiplus/releases). لاختبار أحدث إصدار من libgdiplus، نحتاج إلى إعداد صورة مع libgdiplus مبني من المصدر.

لنستعرض محتوى Dockerfile:
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# إنشاء أحدث إصدار مستقر من libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# إنشاء نقاط تركيب

VOLUME /slides-src

\# بناء واختبار Aspose.Slides عند بدء التشغيل

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


الفرق الوحيد هو قسم *build latest stable libgdiplus*. هذا القسم يثبت جميع الأدوات اللازمة لبناء libgdiplus، ينسخ المصادر، ثم يبنيها ويثبتها في الموقع المناسب. باقي المحتويات هي نفسها كما في [Install and configure Docker on Linux (apt‑get libgdiplus)](/slides/ar/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**ملاحظة**: لا تنس استخدام علامات صورة (اسم) مختلفة للصورة الناتجة في أوامر docker build وdocker run:
``` csharp
 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .
$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest
```


## **تثبيت وتكوين Docker على Windows Server Core**
- نظام التشغيل: Ubuntu 18.04.
- ملف Dockerfile: Dockerfile*WinServerCore*

**ملاحظة**: يتطلب تشغيل حاويات Windows نظام Windows 10 Pro أو Windows Server 2016.

للأسف، لا توفر Microsoft صورة Windows Server Core مع SDK dotnet مثبتة، لذا يجب تثبيتها يدويًا:
``` csharp

 # هرب=

FROM microsoft/windowsservercore:1803 AS installer-env

# تعيين المشغل الافتراضي لـ powershell

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# هرب=

FROM microsoft/windowsservercore:1803 AS installer-env

# تعيين المشغل الافتراضي لـ powershell

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# استرجاع .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 
    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

# إرجاع cmd كمشغل افتراضي

SHELL ["cmd", "/S", "/C"]

\# لتعيين PATH للنظام يجب استخدام ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# إنشاء نقاط تركيب

VOLUME c:/slides-src

# بناء واختبار Aspose.Slides عند البدء

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```


ستُبنى الصورة الناتجة على أساس صورة microsoft/windowsservercore:1803 المتوفرة على [Docker Hub](https://hub.docker.com/r/microsoft/windowsservercore/). سيُحمَّل SDK dotnet بالإصدار المحدد ويُفك ضغطه؛ سيتحديث متغيّر PATH ليتضمن مسار تنفيذ dotnet. السطر الأخير يحدد الأمر الذي يُنفّذ اختبارات func & regr داخل الحاوية باستخدام nant.exe كإجراء افتراضي عند تشغيل الحاوية.

أمر بناء الصورة:
``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


أمر تشغيل الصورة:
``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```


**ملاحظة**: يستخدم أمر الحاوية في Windows معاملين إضافيين:

*-cpu-count 3*  
*-memory 8589934592*

يحددان عدد الأنوية والكمية المتاحة من الذاكرة للحاوية. افتراضيًا، تُتاح للـ Windows container نواة واحدة و1 GB من الذاكرة (حاويات Linux لا تفرض قيودًا افتراضية).

كما أن هناك معاملًا واحدًا مفقودًا مقارنةً بالأمر المستخدم لتشغيل حاوية Linux:

*-add-host dev.slides.external.tool.server:192.168.1.48*

لأن الحاوية على Windows لا تحتاج إلى external.tool.server.

نتيجة الأمر أعلاه يجب أن تبدو هكذا:
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
