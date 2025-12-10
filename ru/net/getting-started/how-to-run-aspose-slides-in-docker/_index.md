---
title: Как запустить Aspose.Slides в Docker
linktitle: Aspose.Slides в Docker
type: docs
weight: 140
url: /ru/net/how-to-run-aspose-slides-in-docker/
keywords:
- поддерживаемые ОС
- Aspose.Slides в Docker
- Docker-контейнер
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- репозиторий образов
- Windows Server Core
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Запуск Aspose.Slides в Docker-контейнерах: настройка образов, зависимостей, шрифтов и лицензирования для создания масштабируемых сервисов, обрабатывающих PowerPoint и OpenDocument."
---

## **Поддерживаемые ОС**
Aspose.Slides может работать внутри docker‑контейнеров, используя платформу .NET Core. В целом, Aspose.Slides поддерживает все типы контейнеров (ОС), которые поддерживает платформа .NET Core. Однако GDI или [libgdiplus](https://github.com/mono/libgdiplus) должны быть доступны и правильно настроены в используемых контейнерах.

Чтобы использовать Docker, сначала необходимо установить его на вашу систему. Чтобы узнать, как установить Docker на Windows или Mac, используйте следующие ссылки:

- [Install Docker on Windows](https://docs.docker.com/docker-for-windows/install/)
- [Install Docker on Mac](https://docs.docker.com/docker-for-mac/install/)

Вы также можете запускать Docker на Linux и Windows Server, следуя инструкциям на этих страницах:

- [Install and configure Docker on Linux (apt-get libgdiplus) ](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [Install and configure Docker on Linux (make install libgdiplus)   ](#install-and-configure-docker-on-linux-make-install-libgdiplus) 

- [Install and configure Docker on Windows Server Core ](#install-and-configure-docker-on-windows-server-core)   

Установка и конфигурация Docker на Windows Server Nano не поддерживается. К сожалению, в Windows Server Nano нет графической подсистемы. В нём отсутствует gdiplus.dll, необходимый библиотеке System.Drawing.Common, поэтому он не может использоваться с библиотекой Aspose.Slides.

Хотя запуск Linux‑контейнеров в Windows возможен, мы рекомендуем запускать их нативно на Linux (даже на Linux, установленном вручную в виртуальной машине с помощью VirtualBox).

## **Установить и настроить Docker на Linux (apt-get libgdiplus)**
- ОС: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Этот docker‑файл содержит инструкции для создания образа контейнера с установленным пакетом libgdiplus из официальных репозиториев Ubuntu.

Вот содержимое docker‑файла:
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# установить libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# создать точки монтирования

VOLUME /slides-src

\# собрать и протестировать Aspose.Slides при запуске

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


Давайте разберём, что означает каждая строка кода в docker‑файле:

1. Образ контейнера основан на образе microsoft/dotnet:2.1-sdk-bionic (образ уже построен Microsoft и опубликован в [public hub](https://hub.docker.com/r/microsoft/dotnet/)). Этот образ содержит уже установленный dotnet 2.1 SDK. Суффикс bionic означает, что в качестве ОС контейнера будет использована Ubuntu 18.04 (кодовое имя bionic). Изменяя суффикс, можно менять базовую ОС (например: stretch — Debian 9, alpine — Alpine Linux). В этом случае потребуется модификация содержимого docker‑файла (например, замена 'apt-get' на 'yum').
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```


2. Обновляет базу данных доступных пакетов и устанавливает пакет apt-utils.
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


3. Устанавливает пакеты 'libgdiplus' и 'libc6-dev', необходимые библиотеке System.Drawing.Common.
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


4. Объявляет папку /slides-src точкой монтирования, которую будем использовать для доступа к каталогам исходных файлов slide‑net на хост‑машине.
``` csharp

 VOLUME /slides-src

```


5. Устанавливает slides-src рабочим каталогом внутри контейнера.
``` csharp

 WORKDIR /slides-src

```


6. Объявляет команду по умолчанию, которая будет выполнена при запуске контейнера, если явно не указана другая команда.
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


Согласно инструкциям в docker‑файле, полученный образ контейнера будет содержать ОС Ubuntu 18.04, dotnet‑sdk, пакеты libgdiplus и libc6‑dev уже установленные. Кроме того, в этом образе будет предопределённая точка монтирования и предопределённая команда при запуске.

Чтобы собрать образ с помощью этого docker‑файла, перейдите в папку slides‑netuil docker и выполните:
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* — параметр, указывающий, какой docker‑файл использовать.  
*-t ubuntu18_04_apt_get_libgdiplus* — задаёт тег (имя) для получаемого образа.  
*'.'* — задаёт контекст для docker. В нашем случае контекстом является текущий каталог, который пуст — поскольку мы выбираем предоставить исходники slides‑net в качестве точки монтирования (это позволяет не перестраивать образ docker при каждом изменении исходников).

Результат выполнения должен выглядеть так:
``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```


Чтобы убедиться, что новый образ добавлен в локальный репозиторий образов:
``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```


После того как образ готов, можно запустить его этой командой:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*-it* — указывает, что команда должна запускаться интерактивно, позволяя видеть вывод и вводить данные.  
*-v `pwd`/../../:/slides-src* — задаёт папку для предопределённой точки монтирования, так как текущий рабочий каталог — slides‑netuildocker, папка slides‑src в контейнере будет указывать на папку slides‑net на хосте. `pwd` используется для указания относительного пути.  
*--add-host dev.slides.external.tool.server:192.168.1.48* — изменяет файл hosts контейнера, чтобы разрешать URL dev.slides.external.tool.server.  
*ubuntu1804aptgetlibgdiplus:latest* — указывает образ, из которого будет запущен контейнер.

Результатом вышеуказанной команды будет вывод netcore.linux.tests.sh (поскольку она определена как команда по умолчанию для контейнера):
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


По результату видно, что файлы журналов тестов Func и Regr были помещены в каталог /build-out/netstandard20/test-results/main/. Кроме того, в общей сложности около 200 тестов завершились неудачно — все они связаны с проблемами рендеринга из‑за отсутствия требуемых шрифтов в контейнере.

Чтобы переопределить команду по умолчанию контейнера при запуске, можно воспользоваться этой командой:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


Таким образом, вместо netcore.linux.tests.sh будет выполнен /bin/bash, предоставляющий активную терминальную сессию контейнера, из которой можно запустить (./build/netcore.linux.tests.sh). Такой подход может быть полезен в сценариях отладки.

## **Установить и настроить Docker на Linux (make install libgdiplus)**
- ОС: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

В настоящее время Ubuntu содержит только версию 4.2 libgdiplus, тогда как версия 5.6 уже доступна на [официальном сайте](https://github.com/mono/libgdiplus/releases) продукта. Чтобы протестировать последнюю версию libgdiplus, необходимо подготовить образ с libgdiplus, собранный из исходников.

Давайте рассмотрим содержимое docker‑файла:
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# собрать последнюю стабильную libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# создать точки монтирования

VOLUME /slides-src

\# собрать и протестировать Aspose.Slides при запуске

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```


Единственное отличие — секция *build latest stable libgdiplus*. Эта секция устанавливает все необходимые инструменты для сборки libgdiplus, клонирует исходники, затем собирает их и устанавливает в нужное место. Всё остальное идентично [Install and configure Docker on Linux (apt-get libgdiplus)](/slides/ru/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Примечание**: Не забывайте использовать разные теги (имена) образов для получаемого образа в командах docker build и docker run:
``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **Установить и настроить Docker на Windows Server Core**
- ОС: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Примечание**: Для запуска Windows‑контейнеров требуется Windows 10 Pro или Windows Server 2016.

К сожалению, Microsoft не предоставляет образ Windows Server Core с предустановленным dotnet SDK, поэтому его необходимо установить вручную:
``` csharp
# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Получить .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#return cmd как исполнитель по умолчанию

SHELL ["cmd", "/S", "/C"]

\# Чтобы установить системный PATH, необходимо использовать ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# создать точки монтирования

VOLUME c:/slides-src

#build и test Aspose.Slides при запуске

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```


Полученный образ будет построен поверх образа microsoft/windowsservercore:1803, предоставленного Microsoft на [docker hub](https://hub.docker.com/r/microsoft/windowsservercore/). Dotnet‑sdk указанной версии будет загружен и распакован; переменная PATH системы будет обновлена, чтобы включать путь к исполняемому файлу dotnet. Последняя строка определяет команду, которая выполняет тесты func и regr в контейнере с использованием nant.exe в качестве действия по умолчанию при запуске контейнера.

Команда для сборки образа:
``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


Команда для запуска образа:
``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```


**Примечание**: Команда для Windows‑контейнера использует 2 дополнительных аргумента:

*-cpu-count 3*

*-memory 8589934592*

Они задают количество ядер и объём памяти, доступных контейнеру. По умолчанию для Windows‑контейнера доступно только 1 ядро и 1 ГБ ОЗУ (у Linux‑контейнеров по умолчанию нет ограничений).

Кроме того, в команде отсутствует один аргумент по сравнению с командой, используемой для Linux‑контейнера:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Поскольку контейнер, работающий в Windows, не требует external.tool.server.

Результат вышеуказанной команды должен выглядеть так:
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
