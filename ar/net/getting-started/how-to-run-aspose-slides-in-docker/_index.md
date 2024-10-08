---
title: كيفية تشغيل Aspose.Slides في Docker
type: docs
weight: 140
url: /ar/net/how-to-run-aspose-slides-in-docker/
keywords: "تشغيل Aspose.Slides في حاوية Docker، Aspose Docker، Aspose.Slides في Docker"
description: "تشغيل Aspose.Slides في حاوية Docker لنظام Linux، Windows Server وأي نظام تشغيل."
---

## **أنظمة التشغيل المدعومة**
يمكن تشغيل Aspose.Slides داخل حاويات Docker باستخدام منصة .NET Core. بشكل عام، تدعم Aspose.Slides جميع أنواع الحاويات (أنظمة التشغيل) التي تدعمها منصة .NET Core. ومع ذلك، يجب أن تكون GDI أو [libgdiplus](https://github.com/mono/libgdiplus) متاحة ومجهزة بشكل صحيح على الحاويات المعنية.

لاستخدام Docker، يجب عليك أولاً تثبيته على نظامك. لمعرفة كيفية تثبيت Docker على Windows أو Mac، استخدم هذه الروابط:

- [تثبيت Docker على Windows](https://docs.docker.com/docker-for-windows/install/)
- [تثبيت Docker على Mac](https://docs.docker.com/docker-for-mac/install/)

يمكنك أيضًا تشغيل Docker على Linux و Windows Server من خلال اتباع التعليمات الموجودة على هذه الصفحات:

- [تثبيت وتكوين Docker على Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [تثبيت وتكوين Docker على Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)

- [تثبيت وتكوين Docker على Windows Server Core](#install-and-configure-docker-on-windows-server-core)

لا يدعم تثبيت وتكوين Docker على Windows Server Nano. للأسف، Windows Server Nano لا يحتوي على نظام الرسوميات على اللوحة. ليس لديه gdiplus.dll، الذي تتطلبه مكتبة System.Drawing.Common، ولا يمكن استخدامه مع مكتبة Aspose.Slides.

بينما من الممكن تشغيل حاويات Linux على Windows، نوصي بتشغيلها بشكل أصلي على Linux (حتى على Linux المثبت يدويًا على جهاز افتراضي باستخدام VirtualBox).

## **تثبيت وتكوين Docker على Linux (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

يتضمن هذا الملف التعليمات لبناء صورة حاوية مع تثبيت حزمة libgdiplus المأخوذة من مستودعات الحزم الرسمية لـ Ubuntu.

إليك محتويات ملف Docker:

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

دعنا نراجع ماذا تعني كل سطر من شيفرة Docker:

1. تعتمد صورة الحاوية على صورة microsoft/dotnet:2.1-sdk-bionic (الصورة بناها Microsoft ونشرت في [المركز العام](https://hub.docker.com/r/microsoft/dotnet/)). تحتوي هذه الصورة على dotnet 2.1 SDK المثبت بالفعل. يعني اللقب Bionic أنه سيتم أخذ Ubuntu 18.04 (اسم الرموز bionic) كنظام تشغيل للحاوية. من خلال تغيير اللقب، من الممكن تغيير نظام التشغيل الأساسي (على سبيل المثال: stretch -- Debian 9، alpine -- Alpine Linux). في هذه الحالة، سيكون من الضروري تعديل محتوى ملف Docker (على سبيل المثال، تغيير 'apt-get' إلى 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. تحديث قاعدة بيانات الحزم المتاحة وتثبيت حزمة apt-utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. تثبيت حزم 'libgdiplus' و 'libc6-dev' المطلوبة من قبل مكتبة System.Drawing.Common.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. إعلان مجلد /slides-src كنقطة تثبيت سنستخدمها لتوفير الوصول إلى مجلد مصادر slide-net على جهاز الحاسوب المضيف.

``` csharp

 VOLUME /slides-src

```

1. تعيين slides-src كمجلد عمل داخل الحاوية.

``` csharp

 WORKDIR /slides-src

```

1. إعلان أمر افتراضي سيتم تشغيله عند بدء الحاوية إذا لم يتم تحديد أمر صريح.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

وفقًا للتعليمات في ملف Docker، ستكون صورة الحاوية الناتجة تحتوي على نظام تشغيل Ubuntu 18.04، و dotnet-sdk، و libgdiplus و libc6-dev بالفعل مثبتة. أيضًا، ستحتوي هذه الصورة على نقطة تثبيت محددة مسبقًا وأمر محدد مسبقًا عند التنفيذ.


لبناء صورة باستخدام هذا الملف Docker، يجب أن تذهب إلى مجلد Docker الخاص بـ slides-netuil وتنفيذ:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- الخيار الذي يحدد ملف Docker الذي يجب استخدامه.

*-t ubuntu18_04_apt_get_libgdiplus* -- يحدد الوسم (الاسم) للصورة الناتجة.

*'.'* -- يحدد السياق لـ Docker. في حالتنا، السياق هو المجلد الحالي وهو فارغ - حيث اخترنا توفير مصادر slides-net كنقطة تثبيت (وهذا يسمح لنا بعدم إعادة بناء صورة Docker في كل مرة تتغير فيها المصادر).


يجب أن يبدو نتيجة التنفيذ كما يلي:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


للتأكد من أنه تمت إضافة الصورة الجديدة إلى مستودع الصور المحلي:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


بمجرد أن تكون الصورة جاهزة، يمكننا تشغيلها باستخدام هذا الأمر:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- تحدد أن الأمر يجب أن يُنفذ بشكل تفاعلي، مما يسمح لنا برؤية الناتج والتقاط المدخلات.

*-v `pwd`/../../:/slides-src* -- تحدد المجلد للنقطة التثبيت المحددة مسبقًا - حيث أن المجلد الحالي هو slides-netuildocker فإن مجلد slides-src في الحاوية سيشير إلى مجلد slides-net على المضيف. يتم استخدام `pwd` لتحديد المسار النسبي.

*--add-host dev.slides.external.tool.server:192.168.1.48* -- يعدل ملف hosts الخاص بالحاوية لحل عنوان URL dev.slides.external.tool.server.

*ubuntu1804aptgetlibgdiplus:latest* -- يحدد الصورة لتشغيل الحاوية.


ستكون نتيجة الأمر أعلاه هي ناتج netcore.linux.tests.sh (حيث تم تحديده كأمر افتراضي للحاوية):

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


من النتائج، من الواضح أن ملفات السجل من اختبارات Func و Regr تم وضعها في دليل /build-out/netstandard20/test-results/main/. أيضًا، حوالي 200 اختبار فشلوا بشكل إجمالي - وكل هذه تتعلق بمشاكل العرض المرتبطة بغياب الخطوط المطلوبة على الحاوية.

لتجاوز الأمر الافتراضي للحاوية عند التشغيل، يمكننا استخدام هذا الأمر:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

لذلك، بدلاً من netcore.linux.tests.sh، سيتم تنفيذ /bin/bash وسيوفر لنا جلسة طرفية نشطة للحاوية يمكن من خلالها تشغيل (./build/netcore.linux.tests.sh). يمكن أن تكون هذه الطريقة مفيدة في سيناريوهات استكشاف الأخطاء وإصلاحها.
## **تثبيت وتكوين Docker على Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

في الوقت الحالي، يحتوي Ubuntu فقط على النسخة 4.2 من libgdiplus بينما النسخة 5.6 متاحة بالفعل على [الموقع الرسمي للمنتج](https://github.com/mono/libgdiplus/releases). لاختبار أحدث إصدار من libgdiplus، نحتاج إلى إعداد صورة مع libgdiplus تم بناؤها من المصادر.

دعنا نراجع محتوى ملف Docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# بناء أحدث نسخة مستقرة من libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# إنشاء نقاط التثبيت

VOLUME /slides-src

\# بناء واختبار Aspose.Slides عند البدء

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

الفرق الوحيد هو قسم *بناء أحدث نسخة مستقرة من libgdiplus*. يقوم هذا القسم بتثبيت جميع الأدوات اللازمة لبناء libgdiplus، واستنساخ المصادر، ثم بنائها وتثبيتها في المكان المناسب. كل شيء آخر هو نفسه كما في [تثبيت وتكوين Docker على Linux (apt-get libgdiplus)](/slides/ar/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**ملاحظة**: لا تنسَ استخدام علامات صور مختلفة (اسم) للصورة الناتجة في أوامر بناء Docker وتشغيلها:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **تثبيت وتكوين Docker على Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**ملاحظة**: يتطلب تشغيل حاويات Windows استخدام Windows 10 Pro أو Windows Server 2016.

للأسف، لا يوفر Microsoft صورة Windows Server Core مع تثبيت dotnet SDK، لذا يتعين علينا تثبيته يدويًا:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# استرجاع .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip;

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89';

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) {

        Write-Host 'فشل التحقق من صحة التجزئة!';

        exit 1;

    };

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#إرجاع cmd كمنفذ افتراضي

SHELL ["cmd", "/S", "/C"]

\# من أجل تعيين PATH النظام، يجب استخدام ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# إنشاء نقاط التثبيت

VOLUME c:/slides-src

# بناء واختبار Aspose.Slides عند البدء

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```


ستبنى الصورة الناتجة فوق صورة microsoft/windowsservercore:1803 التي توفرها Microsoft على [مركز docker](https://hub.docker.com/r/microsoft/windowsservercore/). سيتم تنزيل وتفريغ dotnet-sdk للإصدار المحدد؛ سيتم تحديث متغير PATH للنظام ليتضمن مسار البرنامج التنفيذي dotnet. السطر الأخير يحدد الأمر الذي يقوم بتشغيل اختبارات func و regr على الحاوية باستخدام nant.exe كإجراء افتراضي عند تشغيل الحاوية.

الأمر لبناء الصورة:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


الأمر لتشغيل الصورة:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**ملاحظة**: يستخدم الأمر لحاويات Windows إضافتين:

*-cpu-count 3*

*-memory 8589934592*

تحدد عدد النوى وكمية الذاكرة المتاحة للحاوية. بشكل افتراضي، يتوفر لواجهة Windows حبيبة واحدة فقط و 1 غيغابايت من ذاكرة الوصول العشوائي. (لا توجد أي قيود افتراضية على حاويات Linux).

أيضًا، تم فقدان حجة واحدة عند مقارنة بنفس الأمر الذي استخدمناه لتشغيل حاوية Linux:

*-add-host dev.slides.external.tool.server:192.168.1.48*

لأن الحاوية التي تعمل على Windows لا تتطلب ببساطة external.tool.server.

يجب أن يبدو نتيجة الأمر أعلاه كما يلي:

``` csharp

 NAnt 0.92 (Build 0.92.4543.0; release; 6/9/2012)

Copyright (C) 2001-2012 Gerry Shaw

http://nant.sourceforge.net

netcore20_runtests:

   [delete] حذف الدليل 'c:\slides-src\build-out\netcore20\test-results\'.

   [mkdir] إنشاء الدليل 'c:\slides-src\build-out\netcore20\test-results\'.

...

[exec] ملف النتائج: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.FuncTests.NetCore.trx

[exec] إجمالي الاختبارات: 2338. ناجح: 2115. فشل: 19. متجاوز: 204.

...

[exec] ملف النتائج: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.RegrTests.NetCore.trx

[exec] إجمالي الاختبارات: 2728. ناجح: 2147. فشل: 110. متجاوز: 471.

```