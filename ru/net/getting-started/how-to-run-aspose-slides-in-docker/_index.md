---
title: Как запустить Aspose.Slides в Docker
type: docs
weight: 140
url: /net/how-to-run-aspose-slides-in-docker/
keywords: "Запуск Aspose.Slides в контейнере Docker, Aspose Docker, Aspose.Slides в Docker"
description: "Запустите Aspose.Slides в контейнере Docker для Linux, Windows Server и любой ОС."
---

## **Поддерживаемые ОС**
Aspose.Slides может работать внутри контейнеров Docker с использованием платформы .NET Core. В общем, Aspose.Slides поддерживает все типы контейнеров (ОС), которые поддерживает платформа .NET Core. Однако GDI или [libgdiplus](https://github.com/mono/libgdiplus) должны быть доступны и правильно настроены на задействованных контейнерах.

Для использования Docker вам сначала необходимо установить его на вашей системе. Чтобы узнать, как установить Docker на Windows или Mac, используйте эти ссылки:

- [Установить Docker на Windows](https://docs.docker.com/docker-for-windows/install/)
- [Установить Docker на Mac](https://docs.docker.com/docker-for-mac/install/)

Вы также можете запускать Docker на Linux и Windows Server, следуя инструкциям на этих страницах:

- [Установить и настроить Docker на Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [Установить и настроить Docker на Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)

- [Установить и настроить Docker на Windows Server Core](#install-and-configure-docker-on-windows-server-core)

Установка и настройка Docker на Windows Server Nano не поддерживается. К сожалению, Windows Server Nano не содержит графической подсистемы на борту. Он не содержит gdiplus.dll, который требуется библиотеке System.Drawing.Common, и его нельзя использовать с библиотекой Aspose.Slides.

Хотя возможно запускать контейнеры Linux в Windows, мы рекомендуем запускать их нативно на Linux (даже на Linux, установленном вручную на виртуальной машине с помощью VirtualBox).

## **Установка и настройка Docker на Linux (apt-get libgdiplus)**
- ОС: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Этот Docker файл содержит инструкции для создания образа контейнера с установленным пакетом libgdiplus из официальных репозиториев пакетов Ubuntu.

Вот содержание docker файла:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# установите libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# создайте точки монтирования

VOLUME /slides-src

\# сборка и тестирование Aspose.Slides при старте

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Давайте рассмотрим, что означает каждая строка кода в docker файле:

1. Образ контейнера основан на образе microsoft/dotnet:2.1-sdk-bionic (образ уже собран Microsoft и опубликован на [публичном хабе Docker](https://hub.docker.com/r/microsoft/dotnet/)). Этот образ содержит уже установленный SDK dotnet 2.1. Суффикс Bionic означает, что Ubuntu 18.04 (кодовое имя bionic) будет использоваться в качестве ОС контейнера. Изменив суффикс, можно изменить базовую ОС (например: stretch -- Debian 9, alpine -- Alpine Linux). В этом случае потребуется модификация содержимого docker файла (например, изменение 'apt-get' на 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. Обновляет базу доступных пакетов и устанавливает пакет apt-utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. Устанавливает пакеты 'libgdiplus' и 'libc6-dev', необходимые для библиотеки System.Drawing.Common.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. Объявляет папку /slides-src как точку монтирования, которую мы будем использовать для обеспечения доступа к исходной папке slide-net на хост-машине.

``` csharp

 VOLUME /slides-src

```

1. Устанавливает slides-src в качестве рабочей директории внутри контейнера.

``` csharp

 WORKDIR /slides-src

```

1. Объявляет команду по умолчанию, которая будет выполнена при запуске контейнера, если явная команда не указана.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Согласно инструкциям в docker файле, у получившегося образа контейнера будет установленная ОС Ubuntu 18.04, dotnet-sdk, пакеты libgdiplus и libc6-dev. Кроме того, у этого образа будет предопределенная точка монтирования и предопределенная команда на запуск.

Чтобы собрать образ, используя этот docker файл, вам нужно перейти в папку slides-netuil docker и выполнить:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- опция, указывающая, какой docker файл использовать.

*-t ubuntu18_04_apt_get_libgdiplus* -- указывает тег (имя) для полученного образа.

*'.'* -- указывает контекст для docker. В нашем случае контекст является текущей папкой, и он пустой, так как мы выбрали предоставить исходники slides-net в качестве точки монтирования (это позволяет нам не пересобирать образ docker при каждом изменении в источниках).

Результат выполнения должен выглядеть следующим образом:

``` csharp

 Успешно построен 62dd34ddc142

Успешно помечен ubuntu18_04_apt_get_libgdiplus:latest

```

Чтобы убедиться, что новый образ был добавлен в локальный репозиторий изображений:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Как только образ готов, мы можем запустить его с помощью этой команды:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- указывает, что команда должна выполняться интерактивно, что позволяет нам видеть вывод и захватывать ввод.

*-v `pwd`/../../:/slides-src* -- указывает папку для предопределенной точки монтирования, так как текущая рабочая директория является slides-netuildocker, то папка slides-src в контейнере будет указывать на папку slides-net на хосте. `pwd` используется для указания относительного пути.

*--add-host dev.slides.external.tool.server:192.168.1.48* -- изменяет файл hosts контейнера для разрешения URL dev.slides.external.tool.server.

*ubuntu1804aptgetlibgdiplus:latest* -- указывает образ для запуска контейнера.

Результат вышеуказанной команды будет выводом netcore.linux.tests.sh (так как он был определён как команда по умолчанию для контейнера):

``` csharp

 Восстановление пакетов для /slides-src/targets/.NETCore/tests/Aspose.Slides.FuncTests.NetCore/Aspose.Slides.FuncTests.NetCore.csproj...

Восстановление пакетов для /slides-src/targets/.NETStandard/main/Aspose.Slides.DOM.NetStandard/Aspose.Slides.DOM.NetStandard.csproj...

Восстановление пакетов для /slides-src/targets/.NETStandard/main/Aspose.Slides.CompoundFile.NetStandard/Aspose.Slides.CompoundFile.NetStandard.csproj...

Установка System.Text.Encoding.CodePages 4.4.0.

Установка System.Drawing.Common 4.5.0.

...

Файл результатов: /slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.FuncTests.NetCore.trx

Всего тестов: Неизвестно. Пройдено: 2110. Не пройдено: 108. Пропущено: 210.

...

Файл результатов: /slides-src/build-out/netstandard20/test-results/main/Aspose.Slides.RegrTests.NetCore.trx

Всего тестов: 2124. Пройдено: 1550. Не пройдено: 103. Пропущено: 471.

```

Из результата видно, что журналы файлов Func и Regr тестов были помещены в директорию /build-out/netstandard20/test-results/main/. Также примерно 200 тестов не прошли, и все они связаны с проблемами рендеринга из-за отсутствия требуемых шрифтов в контейнере.

Для замены команды по умолчанию контейнера при запуске мы можем использовать эту команду:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Таким образом, вместо netcore.linux.tests.sh будет выполнен /bin/bash, который предоставит активную сессию терминала контейнера, из которой можно будет запускать (./build/netcore.linux.tests.sh). Этот подход может быть полезен в сценариях устранения неполадок.
## **Установка и настройка Docker на Linux (make install libgdiplus)**
- ОС: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

На данный момент в Ubuntu содержится только версия 4.2 libgdiplus, в то время как версия 5.6 уже доступна на [официальном сайте продукта](https://github.com/mono/libgdiplus/releases). Чтобы протестировать последнюю версию libgdiplus, нам необходимо подготовить образ с libgdiplus, собранным из исходников.

Давайте рассмотри содержимое docker файла:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# сборка последней стабильной libgdiplus

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# создайте точки монтирования

VOLUME /slides-src

\# сборка и тестирование Aspose.Slides при старте

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Единственное отличие заключается в разделе *сборка последней стабильной libgdiplus*. Этот раздел устанавливает все необходимые инструменты для сборки libgdiplus, клонирует исходники, а затем собирает и устанавливает их в нужное место. Все остальное такое же, как и [Установка и настройка Docker на Linux (apt-get libgdiplus)](/slides/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Примечание**: Не забудьте использовать разные теги образа (имя) для получившегося образа в командах docker build и docker run:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Установка и настройка Docker на Windows Server Core**
- ОС: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Примечание**: Для запуска контейнеров Windows требуется Windows 10 Pro или Windows Server 2016.

К сожалению, Microsoft не предоставляет образ Windows Server Core с установленным SDK dotnet, поэтому нам нужно установить его вручную:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Получите .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'ПРОВЕРОЧНАЯ СУММА НЕ СОВПАДАЕТ!'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#вернуть cmd как исполнителя по умолчанию

SHELL ["cmd", "/S", "/C"]

\# Чтобы установить системный PATH, необходимо использовать ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# создайте точки монтирования

VOLUME c:/slides-src

#сборка и тестирование Aspose.Slides при старте

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

Полученный образ будет создан на основе образа microsoft/windowsservercore:1803, предоставленного Microsoft на [docker hub](https://hub.docker.com/r/microsoft/windowsservercore/). SDK dotnet указанной версии будет загружен и распакован; переменная PATH системы будет обновлена, чтобы содержать путь к исполняемому файлу dotnet. Последняя строка определяет команду, которая выполняет тесты func и regr на контейнере с использованием nant.exe в качестве действия по умолчанию при запуске контейнера.

Команда для сборки образа:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Команда для запуска образа:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Примечание**: Команда для контейнера Windows использует 2 дополнительных аргумента:

*-cpu-count 3*

*-memory 8589934592*

Они задают количество ядер и объем памяти, доступные для контейнера. По умолчанию для контейнера Windows доступна только 1 ядро и 1 ГБ оперативной памяти (контейнеры Linux по умолчанию не имеют никаких ограничений).

Также 1 аргумент отсутствует в сравнении с аналогичной командой, которую мы использовали для запуска контейнера Linux:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Поскольку контейнер, работающий на Windows, просто не требует external.tool.server.

Результат вышеуказанной команды должен выглядеть следующим образом:

``` csharp

 NAnt 0.92 (Build 0.92.4543.0; release; 6/9/2012)

Copyright (C) 2001-2012 Gerry Shaw

http://nant.sourceforge.net

netcore20_runtests:

   [delete] Удаление директории 'c:\slides-src\build-out\netcore20\test-results\'.

   [mkdir] Создание директории 'c:\slides-src\build-out\netcore20\test-results\'.

...

[exec] Файл с результатами: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.FuncTests.NetCore.trx

[exec] Всего тестов: 2338. Пройдено: 2115. Не пройдено: 19. Пропущено: 204.

...

[exec] Файл с результатами: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.RegrTests.NetCore.trx

[exec] Всего тестов: 2728. Пройдено: 2147. Не пройдено: 110. Пропущено: 471.

```