---
title: چگونه Aspose.Slides را در Docker اجرا کنیم
linktitle: Aspose.Slides در Docker
type: docs
weight: 140
url: /fa/net/how-to-run-aspose-slides-in-docker/
keywords:
- سیستم‌عامل‌های پشتیبانی‌شده
- Aspose.Slides در Docker
- کانتینر Docker
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- مخزن تصویر
- Windows Server Core
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides را در کانتینرهای Docker اجرا کنید: تصاویر، وابستگی‌ها، فونت‌ها و مجوزها را پیکربندی کنید تا سرویس‌های مقیاس‌پذیر برای پردازش PowerPoint و OpenDocument بسازید."
---
## **سیستم‌عامل‌های پشتیبانی‌شده**
Aspose.Slides می‌تواند داخل کانتینرهای Docker با استفاده از پلتفرم .NET Core اجرا شود. به طور کلی، Aspose.Slides تمام نوع‌ کانتینر (OS)هایی را که پلتفرم .NET Core پشتیبانی می‌کند، پشتیبانی می‌کند. با این حال، GDI یا [libgdiplus](https://github.com/mono/libgdiplus) باید در کانتینرهای مورد استفاده موجود و به درستی تنظیم شود.

برای استفاده از Docker، ابتدا باید آن را بر روی سیستم خود نصب کنید. برای یادگیری نحوه نصب Docker بر روی ویندوز یا مک، از این لینک‌ها استفاده کنید:

- [نصب Docker بر روی ویندوز](https://docs.docker.com/docker-for-windows/install/)
- [نصب Docker بر روی مک](https://docs.docker.com/docker-for-mac/install/)

همچنین می‌توانید Docker را بر روی لینوکس و Windows Server اجرا کنید با دنبال کردن دستورالعمل‌های موجود در این صفحات:

- [نصب و پیکربندی Docker بر روی لینوکس (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [نصب و پیکربندی Docker بر روی لینوکس (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [نصب و پیکربندی Docker بر روی Windows Server Core](#install-and-configure-docker-on-windows-server-core)

نصب و پیکربندی Docker بر روی Windows Server Nano پشتیبانی نمی‌شود. متأسفانه، Windows Server Nano سیستم گرافیکی داخلی ندارد. این سیستم فاقد gdiplus.dll است که کتابخانه System.Drawing.Common به آن نیاز دارد و نمی‌توان آن را با کتابخانه Aspose.Slides استفاده کرد.

اگرچه امکان اجرای کانتینرهای لینوکس در ویندوز وجود دارد، توصیه می‌کنیم آنها را به صورت بومی بر روی لینوکس اجرا کنید (حتی بر روی لینوکس نصب شده به صورت دستی در یک VM با استفاده از VirtualBox).

## **نصب و پیکربندی Docker بر روی لینوکس (apt-get libgdiplus)**
- سیستم‌عامل: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

این فایل Docker شامل دستورالعمل‌های ساخت یک تصویر کانتینر با بسته libgdiplus نصب‌شده از مخازن رسمی بسته‌های Ubuntu است.

در ادامه محتویات فایل Docker آورده شده است:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# نصب libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# ایجاد نقاط مانت

VOLUME /slides-src

\# ساخت و تست Aspose.Slides در زمان شروع

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

بیایید بررسی کنیم که هر خط کد در فایل Docker چه معنایی دارد:

1. تصویر کانتینر بر پایه تصویر microsoft/dotnet:2.1-sdk-bionic است (تصویری که توسط Microsoft ساخته شده و در [public hub](https://hub.docker.com/r/microsoft/dotnet/) Docker منتشر شده است). این تصویر شامل SDK dotnet 2.1 نصب‌شده می‌باشد. پسوند Bionic به این معنی است که Ubuntu 18.04 (کدنام bionic) به عنوان OS کانتینر انتخاب می‌شود. با تغییر پسوند می‌توان سیستم‌عامل پایه را تغییر داد (مثلاً: stretch → Debian 9، alpine → Alpine Linux). در این حالت نیاز به تغییر محتوای فایل Docker خواهد بود (مثلاً تغییر 'apt-get' به 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. پایگاه داده‌ی بسته‌های در دسترس را به‌روزرسانی می‌کند و بسته apt-utils را نصب می‌کند.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. بسته‌های 'libgdiplus' و 'libc6-dev' مورد نیاز کتابخانه System.Drawing.Common را نصب می‌کند.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. پوشه /slides-src را به‌عنوان نقطه‌مانت تعریف می‌کند که برای دسترسی به پوشه منبع slide-net در ماشین میزبان استفاده می‌شود.

``` csharp

 VOLUME /slides-src

```

1. slides-src را به‌عنوان دایرکتوری کاری داخل کانتینر تنظیم می‌کند.

``` csharp

 WORKDIR /slides-src

```

1. یک فرمان پیش‌فرض را تعریف می‌کند که در صورت عدم مشخص کردن فرمان صریح هنگام شروع کانتینر اجرا شود.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

براساس دستورالعمل‌های موجود در فایل Docker، تصویر نهایی کانتینر شامل OS Ubuntu 18.04، dotnet-sdk، بسته‌های libgdiplus و libc6-dev از پیش نصب‌شده خواهد بود. همچنین این تصویر دارای نقطه‌مانت پیش‌تعریف‌شده و فرمان پیش‌فرض برای اجرا خواهد بود.

برای ساخت یک تصویر با استفاده از این فایل Docker، باید به پوشه docker در slides-netuil رفته و دستور زیر را اجرا کنید:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- گزینه‌ای است که مشخص می‌کند کدام فایل Docker استفاده شود.  
*-t ubuntu18_04_apt_get_libgdiplus* -- برچسب (نام) تصویر نهایی را تعیین می‌کند.  
'.'* -- زمینه (context) برای Docker را مشخص می‌کند. در این مورد، زمینه پوشه فعلی است و خالی است — چون ما منابع slides-net را به‌عنوان نقطه‌مانت ارائه می‌دهیم (این امکان را می‌دهد تا هر بار که منابع تغییر می‌کنند، تصویر Docker را دوباره نبازیم).

نتیجه اجرا باید شبیه به این باشد:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

برای اطمینان از اینکه تصویر جدید به مخزن تصاویر محلی اضافه شده است:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

پس از آماده شدن تصویر، می‌توانیم آن را با این فرمان اجرا کنیم:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- مشخص می‌کند که فرمان به‌صورت تعاملی اجرا شود تا خروجی را ببینیم و ورودی را دریافت کنیم.  
*-v `pwd`/../../:/slides-src* -- پوشه‌ای را برای نقطه‌مانت پیش‌تعریف‌شده تعیین می‌کند — چون دایرکتوری کاری فعلی slides-netuildocker است، پوشه slides-src در کانتینر به پوشه slides-net روی میزبان اشاره می‌کند. `pwd` برای مشخص کردن مسیر نسبی استفاده می‌شود.  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- فایل hosts کانتینر را تغییر می‌دهد تا نام dev.slides.external.tool.server حل شود.  
*ubuntu1804aptgetlibgdiplus:latest* -- تصویری را که کانتینر باید اجرا کند، مشخص می‌کند.

نتیجهٔ فرمان فوق خروجی netcore.linux.tests.sh خواهد بود (چون به‌عنوان فرمان پیش‌فرض برای کانتینر تعریف شده است):

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

از نتایج واضح است که فایل‌های لاگ تست‌های Func و Regr در مسیر /build-out/netstandard20/test-results/main/ قرار گرفته‌اند. همچنین حدود ۲۰۰ تست به طور کلی شکست خورده‌اند — و تمام این‌ها به دلیل عدم وجود فونت‌های مورد نیاز در کانتینر، مشکلات رندرینگ هستند.

برای غیرفعال کردن فرمان پیش‌فرض کانتینر در هنگام اجرا، می‌توانیم از این فرمان استفاده کنیم:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

بنابراین، به‌جای netcore.linux.tests.sh، /bin/bash اجرا می‌شود و یک جلسهٔ ترمینال فعال از کانتینر فراهم می‌کند که از آن می‌توان (./build/netcore.linux.tests.sh) را اجرا کرد. این روش می‌تواند در سناریوهای عیب‌یابی مفید باشد.

## **نصب و پیکربندی Docker بر روی لینوکس (make install libgdiplus)**
- سیستم‌عامل: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

در حال حاضر، Ubuntu تنها نسخه ۴.۲ libgdiplus را دارد در حالی که نسخه ۵.۶ در [سایت رسمی](https://github.com/mono/libgdiplus/releases) محصول موجود است. برای آزمایش جدیدترین نسخه libgdiplus، نیاز به تهیه یک تصویر داریم که libgdiplus از سورس‌ها ساخته شده باشد.

بیایید محتویات فایل Docker را مرور کنیم:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# ساخت آخرین libgdiplus پایدار

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# ایجاد نقاط مانت

VOLUME /slides-src

\# ساخت و تست Aspose.Slides در زمان شروع

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

تنها تفاوت، بخش *build latest stable libgdiplus* است. این بخش تمام ابزارهای لازم برای ساخت libgdiplus را نصب می‌کند، سورس‌ها را کلون می‌کند، سپس آن‌ها را می‌سازد و در مکان مناسب نصب می‌کند. سایر موارد همانند [نصب و پیکربندی Docker بر روی لینوکس (apt-get libgdiplus)](/slides/fa/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/) است.

**توجه**: هنگام استفاده از دستورات docker build و docker run، فراموش نکنید از برچسب‌های تصویر (نام) متفاوت برای تصویر نهایی استفاده کنید:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **نصب و پیکربندی Docker بر روی Windows Server Core**
- سیستم‌عامل: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**توجه**: برای اجرای کانتینرهای ویندوز، Windows 10 Pro یا Windows Server 2016 نیاز است.

متأسفانه Microsoft تصویر Windows Server Core با SDK dotnet نصب‌شده را فراهم نمی‌کند، بنابراین باید آن را به‌صورت دستی نصب کنیم:

``` csharp

 # فرار=

FROM microsoft/windowsservercore:1803 AS installer-env

#تنظیم اجراگر پیش‌فرض پاورشل

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# فرار=

FROM microsoft/windowsservercore:1803 AS installer-env

#تنظیم اجراگر پیش‌فرض پاورشل

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# دریافت .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#برگرداندن cmd به عنوان اجراگر پیش‌فرض

SHELL ["cmd", "/S", "/C"]

\# به منظور تنظیم مسیر سیستم (PATH)، باید از ContainerAdministrator استفاده شود

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# ایجاد نقاط مانت

VOLUME c:/slides-src

#ساخت و تست Aspose.Slides هنگام شروع

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

تصویر نهایی بر پایه تصویر microsoft/windowsservercore:1803 که توسط Microsoft در [docker hub](https://hub.docker.com/u/microsoft) ارائه شده است، ساخته می‌شود. dotnet-sdk نسخه مشخص شده دانلود و استخراج می‌شود؛ متغیر PATH سیستم به مسیر فایل اجرایی dotnet به‌روزرسانی می‌شود. خط آخر فرمانی را تعریف می‌کند که تست‌های func و regr را بر روی کانتینر با استفاده از nant.exe به‌عنوان عمل پیش‌فرض در هنگام اجرای کانتینر اجرا می‌کند.

دستور برای ساخت تصویر:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

دستور برای اجرای تصویر:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**توجه**: فرمان برای کانتینر ویندوز دو آرگومان اضافه دارد:

*-cpu-count 3* -- تعداد هسته‌ها را تنظیم می‌کند.  
*-memory 8589934592* -- مقدار حافظهٔ در دسترس برای کانتینر را تنظیم می‌کند.

به‌طور پیش‌فرض، تنها ۱ هسته و ۱ GB RAM برای کانتینر ویندوز در دسترس است (کانتینرهای لینوکس به‌صورت پیش‌فرض محدودیتی ندارند).

همچنین، یک آرگومان نسبت به همان فرمانی که برای اجرای کانتینر لینوکس استفاده می‌کردیم، حذف شده است:

*-add-host dev.slides.external.tool.server:192.168.1.48* -- چون کانتینر اجرا شده بر روی ویندوز نیازی به external.tool.server ندارد.

نتیجهٔ فرمان فوق باید شبیه به این باشد:

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