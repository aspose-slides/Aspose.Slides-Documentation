---
title: كيف تشغل Aspose.Slides في Docker
linktitle: Aspose.Slides في Docker
type: docs
weight: 140
url: /ar/net/how-to-run-aspose-slides-in-docker/
keywords:
- أنظمة تشغيل مدعومة
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
description: "تشغيل Aspose.Slides في حاويات Docker: تكوين الصور، الاعتماديات، الخطوط، والترخيص لبناء خدمات قابلة للتوسع تعالج PowerPoint و OpenDocument."
---

## **أنظمة التشغيل المدعومة**
يمكن لـ Aspose.Slides التشغيل داخل حاويات Docker باستخدام منصة .NET Core. بشكل عام، يدعم Aspose.Slides جميع أنواع الحاويات (أنظمة التشغيل) التي تدعمها منصة .NET Core. ومع ذلك، يجب أن تكون GDI أو [libgdiplus](https://github.com/mono/libgdiplus) متاحة ومُعدة بشكل صحيح على الحاويات المعنية.

لاستخدام Docker، يجب أولاً تثبيته على نظامك. لتعلم كيفية تثبيت Docker على Windows أو Mac، استخدم هذه الروابط:
- [تثبيت Docker على Windows](https://docs.docker.com/docker-for-windows/install/)
- [تثبيت Docker على Mac](https://docs.docker.com/docker-for-mac/install/)

يمكنك أيضًا تشغيل Docker على Linux و Windows Server باتباع التعليمات في هذه الصفحات:
- [تثبيت وتكوين Docker على Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [تثبيت وتكوين Docker على Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [تثبيت وتكوين Docker على Windows Server Core](#install-and-configure-docker-on-windows-server-core)

التثبيت والتكوين لـ Docker على Windows Server Nano غير مدعوم. للأسف، لا يحتوي Windows Server Nano على نظام الرسوميات المدمج. لا يحتوي على gdiplus.dll، الذي يتطلبه مكتبة System.Drawing.Common، ولا يمكن استخدامه مع مكتبة Aspose.Slides.

في حين أنه من الممكن تشغيل حاويات Linux على Windows، نوصي بتشغيلها أصلاً على Linux (حتى على Linux مثبت يدويًا على جهاز افتراضي باستخدام VirtualBox).

## **تثبيت وتكوين Docker على Linux (apt-get libgdiplus)**
- نظام التشغيل: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

يحتوي ملف Docker هذا على تعليمات لإنشاء صورة حاوية مع حزمة libgdiplus مثبتة من مستودعات الحزم الرسمية لـ Ubuntu.

إليك محتويات ملف Docker:
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# تثبيت libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# إنشاء نقاط التركيب

VOLUME /slides-src

\# بناء واختبار Aspose.Slides عند البدء

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


لنستعرض ما يعنيه كل سطر من الشيفرة في ملف Docker:
1. صورة الحاوية مبنية على صورة microsoft/dotnet:2.1-sdk-bionic (الصورة التي تم بناؤها مسبقًا من قبل Microsoft ونشرتها Docker في [public hub](https://hub.docker.com/r/microsoft/dotnet/)). تحتوي هذه الصورة على SDK dotnet 2.1 المثبت مسبقًا. لاحقة Bionic تعني أن Ubuntu 18.04 (الاسم الرمزي bionic) ستُستخدم كنظام تشغيل الحاوية. بتغيير اللاحقة، يمكن تغيير نظام التشغيل الأساسي (على سبيل المثال: stretch -- Debian 9، alpine -- Alpine Linux). في هذه الحالة، سيتطلب تعديل محتوى ملف Docker (على سبيل المثال، تغيير 'apt-get' إلى 'yum').
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. يحدث قاعدة بيانات الحزم المتاحة ويثبت حزمة apt-utils.
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. يثبت الحزم 'libgdiplus' و 'libc6-dev' المطلوبة من قبل مكتبة System.Drawing.Common.
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. يعلن عن مجلد /slides-src كنقطة تركيب سنستخدمها لتوفير الوصول إلى مجلد مصادر slide-net على الجهاز المضيف.
``` csharp

 VOLUME /slides-src

```

1. يضبط slides-src كدليل عمل داخل الحاوية.
``` csharp

 WORKDIR /slides-src

```

1. يعلن عن أمر افتراضي سيُنفّذ عند بدء الحاوية في حال عدم تحديد أمر صريح.
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


وفقًا للتعليمات في ملف Docker، ستحمل صورة الحاوية الناتجة نظام Ubuntu 18.04، dotnet-sdk، وحزم libgdiplus و libc6-dev مثبتة مسبقًا. بالإضافة إلى ذلك، سيتضمن هذا الصورة نقطة تركيب مسبقة التعريف وأمرًا افتراضيًا عند التشغيل.

لبناء صورة باستخدام هذا ملف Docker، يجب الانتقال إلى مجلد slides-netuil docker وتنفيذ:
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- خيار يحدد أي ملف Docker سيُستخدم.  
*-t ubuntu18_04_apt_get_libgdiplus* -- يحدد علامة (اسم) للصورة الناتجة.  
*'.'* -- يحدد السياق لـ Docker. في حالتنا، السياق هو المجلد الحالي وهو فارغ—لأننا اخترنا توفير مصادر slides-net كنقطة تركيب (هذا يسمح لنا بعدم إعادة بناء صورة Docker عند كل تغيير في المصادر).

يجب أن يبدو ناتج التنفيذ كما يلي:
``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


للتأكد من إضافة الصورة الجديدة إلى مستودع الصور المحلي:
``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


بمجرد أن تكون الصورة جاهزة، يمكن تشغيلها باستخدام هذا الأمر:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*-it* -- يحدد أن الأمر يجب أن يُنفّذ تفاعليًا، مما يسمح لنا برؤية الخرج وإدخال البيانات.  
*-v `pwd`/../../:/slides-src* -- يحدد المجلد لنقطة التركيب المسبقة — لأن دليل العمل الحالي هو slides-netuil/docker، فإن مجلد slides-src داخل الحاوية سيشير إلى مجلد slides-net على الجهاز المضيف. يُستخدم `pwd` لتحديد المسار النسبي.  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- لتعديل ملف hosts الخاص بالحاوية لحل عنوان URL dev.slides.external.tool.server.  
*ubuntu1804aptgetlibgdiplus:latest* -- يحدد الصورة لتشغيل الحاوية.

سوف يكون ناتج الأمر أعلاه مخرجات سكريبت netcore.linux.tests.sh ( لأنه تم تعريفه كأمر افتراضي للحاوية):
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


من النتيجة، يتضح أن ملفات السجل من اختبارات Func و Regr وُضعت في الدليل /build-out/netstandard20/test-results/main/. كما فشل حوالي 200 اختبار إجمالاً— وجميعها مشاكل عرض تتعلق بغياب الخطوط المطلوبة في الحاوية.

لتجاوز الأمر الافتراضي للحاوية عند التشغيل، يمكننا استخدام هذا الأمر:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


بالتالي، بدلاً من netcore.linux.tests.sh، سيتم تشغيل /bin/bash وسيوفر جلسة طرفية نشطة داخل الحاوية يمكن من خلالها تشغيل (./build/netcore.linux.tests.sh). يمكن أن يكون هذا الأسلوب مفيدًا في سيناريوهات استكشاف الأخطاء.

## **تثبيت وتكوين Docker على Linux (make install libgdiplus)**
- نظام التشغيل: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

في الوقت الحالي، يحتوي Ubuntu فقط على الإصدار 4.2 من libgdiplus بينما الإصدار 5.6 متاح بالفعل على [الموقع الرسمي](https://github.com/mono/libgdiplus/releases) للمنتج. لاختبار أحدث نسخة من libgdiplus، نحتاج إلى إعداد صورة مع libgdiplus مبني من المصدر.

لنستعرض محتوى ملف Docker:
``` csharp
 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# بناء أحدث libgdiplus ثابت

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# إنشاء نقاط التركيب

VOLUME /slides-src

\# بناء واختبار Aspose.Slides عند بدء التشغيل

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh
```


الفرق الوحيد هو قسم *build latest stable libgdiplus*. هذا القسم يثبّت جميع الأدوات اللازمة لبناء libgdiplus، ينسخ المصادر، ثم يبنيها ويثبتها في الموقع المناسب. كل شيء آخر هو نفسه كما في [تثبيت وتكوين Docker على Linux (apt-get libgdiplus)](/slides/ar/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**ملاحظة**: لا تنسَ استخدام علامات صورة (اسم) مختلفة للصورة الناتجة في أوامر docker build و docker run:
``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **تثبيت وتكوين Docker على Windows Server Core**
- نظام التشغيل: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**ملاحظة**: يتطلب تشغيل حاويات Windows نظام Windows 10 Pro أو Windows Server 2016.

للأسف، لا توفر Microsoft صورة Windows Server Core مع SDK الخاص بـ dotnet مثبت، لذلك علينا تثبيتها يدويًا:
``` csharp
# escape=
FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell المُنفذ الافتراضي

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=
\# set powershell المُنفذ الافتراضي

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

#return cmd كمُنفّذ افتراضي

SHELL ["cmd", "/S", "/C"]

\# لتعيين PATH النظام، يجب استخدام ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# إنشاء نقاط التركيب

VOLUME c:/slides-src

#build واختبار Aspose.Slides عند البدء

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```


ستُبنى الصورة الناتجة فوق صورة microsoft/windowsservercore:1803 التي توفرها Microsoft على [docker hub](https://hub.docker.com/r/microsoft/windowsservercore/). سيتم تنزيل SDK الخاص بـ dotnet بالإصدار المحدد وفك ضغطه؛ سيتم تحديث متغير PATH للنظام ليحتوي على مسار تنفيذ dotnet. السطر الأخير يحدد الأمر الذي ينفّذ اختبارات func و regr على الحاوية باستخدام nant.exe كإجراء افتراضي عند تشغيل الحاوية.

أمر بناء الصورة:
``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


أمر تشغيل الصورة:
``` csharp
docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest
```


**ملاحظة**: يستخدم الأمر لحاوية Windows معاملين إضافيين:
*-cpu-count 3* -- يحدد عدد الأنوية.  
*-memory 8589934592* -- يحدد مقدار الذاكرة المتاحة للحاوية.

إنهما يحددان عدد الأنوية وكمية الذاكرة المتاحة للحاوية. بشكل افتراضي، يتوفر لنظام Windows حاوية نواة واحدة و1 جيجابايت من الذاكرة (حاويات Linux لا تمتلك أي قيود افتراضية).

أيضًا، يفتقد أمر واحد بالمقارنة مع الأمر نفسه الذي استخدمناه لتشغيل الحاوية Linux:
*-add-host dev.slides.external.tool.server:192.168.1.48* -- لأن الحاوية التي تعمل على Windows لا تحتاج إلى external.tool.server.

يجب أن يبدو ناتج الأمر أعلاه كما يلي:
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
