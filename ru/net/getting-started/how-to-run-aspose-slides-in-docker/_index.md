---
title: Как запустить Aspose.Slides в Docker
linktitle: Aspose.Slides в Docker
type: docs
weight: 140
url: /ru/net/how-to-run-aspose-slides-in-docker/
keywords:
- поддерживаемые ОС
- Aspose.Slides в Docker
- Docker‑контейнер
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
description: "Запуск Aspose.Slides в Docker‑контейнерах: настройка образов, зависимостей, шрифтов и лицензирования для создания масштабируемых сервисов обработки PowerPoint и OpenDocument."
---

## **Поддерживаемые ОС**
Aspose.Slides может работать внутри контейнеров Docker, используя платформу .NET Core. Как правило, Aspose.Slides поддерживает все типы контейнеров (ОС), поддерживаемые платформой .NET Core. Однако GDI или [libgdiplus](https://github.com/mono/libgdiplus) должны быть доступны и правильно настроены в используемых контейнерах.

Чтобы использовать Docker, сначала необходимо установить его на вашей системе. Чтобы узнать, как установить Docker на Windows или Mac, используйте следующие ссылки:

- [Установить Docker на Windows](https://docs.docker.com/docker-for-windows/install/)
- [Установить Docker на Mac](https://docs.docker.com/docker-for-mac/install/)

Вы также можете запустить Docker на Linux и Windows Server, следуя инструкциям на этих страницах:

- [Установить и настроить Docker в Linux (apt‑get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Установить и настроить Docker в Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Установить и настроить Docker в Windows Server Core](#install-and-configure-docker-on-windows-server-core)

Установка и настройка Docker для Windows Server Nano не поддерживается. К сожалению, в Windows Server Nano отсутствует графическая подсистема. В нём нет gdiplus.dll, который требуется библиотеке System.Drawing.Common, и он не может быть использован с библиотекой Aspose.Slides.

Хотя запуск контейнеров Linux в Windows возможен, мы рекомендуем запускать их нативно на Linux (даже на Linux, установленном вручную в виртуальной машине с VirtualBox).

## **Установка и настройка Docker в Linux (apt‑get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Этот Dockerfile содержит инструкции по построению образа контейнера с установленным пакетом libgdiplus из официальных репозиториев Ubuntu.

Содержимое Dockerfile:
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


Разберём, что означает каждая строка кода в Dockerfile:

1. Образ контейнера основан на образе microsoft/dotnet:2.1-sdk-bionic (образ, уже собранный Microsoft и опубликованный в публичном Docker Hub). В этом образе уже установлен dotnet 2.1 SDK. Суффикс *bionic* означает, что в качестве ОС контейнера будет использоваться Ubuntu 18.04 (кодовое имя bionic). Изменив суффикс, можно изменить базовую ОС (например: stretch — Debian 9, alpine — Alpine Linux). В этом случае потребуется изменить содержание Dockerfile (например, заменить `apt-get` на `yum`).
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:
```


1. Обновляет базу данных доступных пакетов и устанавливает пакет apt-utils.
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


1. Устанавливает пакеты `libgdiplus` и `libc6-dev`, требуемые библиотекой System.Drawing.Common.
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


1. Объявляет папку /slides-src точкой монтирования, которую мы будем использовать для доступа к исходникам slide‑net на хост‑машине.
``` csharp

 VOLUME /slides-src

```


1. Делает /slides-src рабочей директорией внутри контейнера.
``` csharp

 WORKDIR /slides-src

```


1. Объявляет команду по умолчанию, которая будет выполнена при старте контейнера, если явно не указана другая команда.
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


Согласно инструкциям в Dockerfile, полученный образ контейнера будет содержать Ubuntu 18.04, dotnet‑sdk, пакеты libgdiplus и libc6-dev, а также предопределённую точку монтирования и команду запуска.

Чтобы собрать образ с помощью этого Dockerfile, перейдите в папку slides‑netuil docker и выполните:
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* — опция, указывающая, какой Dockerfile использовать.  
*-t ubuntu18_04_apt_get_libgdiplus* — задаёт тег (имя) для получаемого образа.  
*'.'* — задаёт контекст для Docker. В нашем случае контекстом является текущая папка, которая пуста, поскольку мы используем исходники slide‑net как точку монтирования (это позволяет не пересобирать образ при каждом изменении исходного кода).

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


После того как образ готов, его можно запустить следующей командой:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*-it* — запускает команду в интерактивном режиме, позволяя видеть вывод и передавать ввод.  
*-v `pwd`/../../:/slides-src* — указывает папку для предопределённой точки монтирования; текущий рабочий каталог — slides‑netuildocker, поэтому папка slides‑src в контейнере будет указывать на папку slide‑net на хосте. `pwd` используется для указания относительного пути.  
*--add-host dev.slides.external.tool.server:192.168.1.48* — модифицирует файл hosts контейнера, добавляя разрешение имени dev.slides.external.tool.server.  
*ubuntu1804aptgetlibgdiplus:latest* — указывает образ, из которого будет запущен контейнер.

Результатом вышеуказанной команды будет вывод скрипта netcore.linux.tests.sh (поскольку он задан как команда по умолчанию для контейнера):
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


Из результата видно, что файлы журнала тестов Func и Regr были помещены в каталог /build-out/netstandard20/test-results/main/. Кроме того, в общей сложности около 200 тестов завершились с ошибкой — все они связаны с отсутствием необходимых шрифтов в контейнере.

Чтобы переопределить команду по умолчанию при запуске контейнера, можно использовать следующую команду:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


Таким образом, вместо netcore.linux.tests.sh будет выполнен /bin/bash, предоставив активный терминал контейнера, из которого можно запустить (./build/netcore.linux.tests.sh). Этот подход удобен для отладки.

## **Установка и настройка Docker в Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

В данный момент в Ubuntu доступна только версия 4.2 libgdiplus, тогда как версия 5.6 уже присутствует на [официальном сайте продукта](https://github.com/mono/libgdiplus/releases). Чтобы протестировать последнюю версию libgdiplus, необходимо собрать образ с libgdiplus, построенным из исходников.

Содержимое Dockerfile:
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


Единственное различие — секция *build latest stable libgdiplus*. В этой секции устанавливаются все необходимые инструменты для сборки libgdiplus, клонируются исходники, после чего они компилируются и устанавливаются в нужное место. Всё остальное идентично инструкции [Install and configure Docker on Linux (apt‑get libgdiplus)](/slides/ru/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Примечание**: Не забудьте использовать разные теги (имена) образа для команд `docker build` и `docker run`:
``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **Установка и настройка Docker в Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Примечание**: Для работы Windows‑контейнеров требуется Windows 10 Pro или Windows Server 2016.

К сожалению, Microsoft не предоставляет образ Windows Server Core с предустановленным dotnet SDK, поэтому его необходимо установить вручную:
``` csharp
 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor
#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor
#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Retrieve .NET Core SDK
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

#return cmd as default executor
#return cmd as default executor

SHELL ["cmd", "/S", "/C"]

\# In order to set system PATH, ContainerAdministrator must be used
\# In order to set system PATH, ContainerAdministrator must be used

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# create mount points
\# create mount points

VOLUME c:/slides-src

#build and test Aspose.Slides on start
#build and test Aspose.Slides on start

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true
```


Полученный образ будет построен на основе образа microsoft/windowsservercore:1803, предоставленного Microsoft в [Docker Hub](https://hub.docker.com/r/microsoft/windowsservercore/). В него будет загружен и распакован dotnet‑SDK требуемой версии; переменная среды PATH будет дополнена путем к исполняемому файлу dotnet. Последняя строка определяет команду, которая запускает тесты func & regr в контейнере с помощью nant.exe как действие по умолчанию при запуске контейнера.

Команда для сборки образа:
``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```


Команда для запуска образа:
``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```


**Примечание**: Команда для Windows‑контейнера использует два дополнительных аргумента:

*-cpu-count 3*  
*-memory 8589934592*

Они задают количество ядер процессора и объём памяти, доступных контейнеру. По умолчанию для Windows‑контейнера доступно только 1 ядро и 1 ГБ ОЗУ (у Linux‑контейнеров ограничений по умолчанию нет).

Кроме того, в команде отсутствует параметр, присутствующий в команде для Linux‑контейнера:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Поскольку Windows‑контейнеру не требуется внешний tool‑server, этот параметр опущен.

Результат выполнения команды должен выглядеть так:
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
