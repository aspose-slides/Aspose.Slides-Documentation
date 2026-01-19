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
description: "Запустите Aspose.Slides в Docker‑контейнерах: настройте образы, зависимости, шрифты и лицензирование для создания масштабируемых сервисов, обрабатывающих PowerPoint и OpenDocument."
---

## **Поддерживаемые ОС**
Aspose.Slides может работать внутри Docker‑контейнеров, используя платформу .NET Core. Как правило, Aspose.Slides поддерживает все типы контейнеров (ОС), которые поддерживает платформа .NET Core. Однако GDI или [libgdiplus](https://github.com/mono/libgdiplus) должны быть доступны и правильно настроены в используемых контейнерах.

Чтобы использовать Docker, сначала необходимо установить его в вашей системе. Чтобы узнать, как установить Docker на Windows или Mac, используйте следующие ссылки:

- [Установить Docker на Windows](https://docs.docker.com/docker-for-windows/install/)
- [Установить Docker на Mac](https://docs.docker.com/docker-for-mac/install/)

Вы также можете запускать Docker на Linux и Windows Server, следуя инструкциям на этих страницах:

- [Установить и настроить Docker на Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Установить и настроить Docker на Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Установить и настроить Docker на Windows Server Core](#install-and-configure-docker-on-windows-server-core)

Установка и настройка Docker на Windows Server Nano не поддерживается. К сожалению, в Windows Server Nano нет графической подсистемы. В нем отсутствует gdiplus.dll, который требуется библиотеке System.Drawing.Common, и его нельзя использовать с библиотекой Aspose.Slides.

Хотя возможно запускать Linux‑контейнеры в Windows, мы рекомендуем запускать их нативно на Linux (даже на Linux, установленном вручную в виртуальной машине с использованием VirtualBox).

## **Установить и настроить Docker на Linux (apt-get libgdiplus)**
- ОС: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Этот Docker‑file содержит инструкции по созданию образа контейнера с установленным пакетом libgdiplus из официальных репозиториев пакетов Ubuntu.

Содержимое Docker‑file:
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


Разберём, что означает каждая строка кода в Docker‑file:

1. Образ контейнера основан на образе microsoft/dotnet:2.1-sdk-bionic (образ, уже построенный Microsoft и опубликованный в [public hub](https://hub.docker.com/r/microsoft/dotnet/) Docker). Этот образ содержит уже установленный dotnet 2.1 SDK. Суффикс bionic означает, что в качестве ОС контейнера будет использоваться Ubuntu 18.04 (кодовое имя bionic). Изменяя суффикс, можно сменить базовую ОС (например: stretch — Debian 9, alpine — Alpine Linux). В таком случае потребуется изменить содержимое Docker‑file (например, заменить 'apt-get' на 'yum').
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:
```


1. Обновляет базу данных доступных пакетов и устанавливает пакет apt-utils.
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```


1. Устанавливает пакеты 'libgdiplus' и 'libc6-dev', необходимые библиотеке System.Drawing.Common.
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```


1. Объявляет папку /slides-src точкой монтирования, которая будет использована для доступа к исходникам slide-net на хост‑машине.
``` csharp

 VOLUME /slides-src

```


1. Устанавливает slides-src в качестве рабочей директории внутри контейнера.
``` csharp

 WORKDIR /slides-src

```


1. Объявляет команду по умолчанию, которая будет выполнена при запуске контейнера, если явно не указана другая команда.
``` csharp

 CMD ./build/netcore.linux.tests.sh

```


Согласно инструкциям в Docker‑file, полученный образ контейнера будет содержать ОС Ubuntu 18.04, dotnet‑sdk, пакеты libgdiplus и libc6‑dev уже установленные. Кроме того, у этого образа будет предопределённая точка монтирования и команда по умолчанию при запуске.

Чтобы собрать образ с использованием этого Docker‑file, перейдите в папку slides-netuil docker и выполните:
``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```


*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* — опция указывает, какой Docker‑file использовать.  
*-t ubuntu18_04_apt_get_libgdiplus* — задаёт тег (имя) для получаемого образа.  
*'.'* — задаёт контекст для Docker. В нашем случае контекстом является текущая папка, и она пуста — поскольку мы выбираем предоставление исходников slides-net в виде точки монтирования (это позволяет не пересобирать образ Docker при каждом изменении исходников).

Результат выполнения должен выглядеть следующим образом:
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


После того как образ готов, его можно запустить с помощью следующей команды:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```


*-it* — указывает, что команда должна выполняться интерактивно, позволяя видеть вывод и вводить данные.  
*-v `pwd`/../../:/slides-src* — задаёт папку для предопределённой точки монтирования — так как текущая рабочая директория это slides-netuil/docker, папка slides-src в контейнере будет указывать на папку slides-net на хосте. `pwd` используется для указания относительного пути.  
*--add-host dev.slides.external.tool.server:192.168.1.48* — изменяет файл hosts контейнера, чтобы разрешать URL dev.slides.external.tool.server.  
*ubuntu1804aptgetlibgdiplus:latest* — указывает образ, из которого запускать контейнер.

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


Из результата ясно, что файлы журналов тестов Func и Regr были помещены в каталог /build-out/netstandard20/test-results/main/. Также в общей сложности около 200 тестов завершилось с ошибкой — все они связаны с проблемами рендеринга из‑за отсутствия требуемых шрифтов в контейнере.

Чтобы переопределить команду по умолчанию контейнера при запуске, можно использовать следующую команду:
``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```


Таким образом, вместо netcore.linux.tests.sh будет выполнен /bin/bash, предоставляющий активный терминал контейнера, из которого можно запустить (./build/netcore.linux.tests.sh). Такой подход может быть полезен при отладке.

## **Установить и настроить Docker на Linux (make install libgdiplus)**
- ОС: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

В данный момент Ubuntu содержит лишь версию 4.2 libgdiplus, тогда как версия 5.6 уже доступна на [официальном сайте](https://github.com/mono/libgdiplus/releases) продукта. Чтобы протестировать последнюю версию libgdiplus, необходимо подготовить образ с libgdiplus, построенным из исходников.

Разберём содержимое Docker‑file:
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


Единственное отличие — раздел *build latest stable libgdiplus*. Этот раздел устанавливает все необходимые инструменты для сборки libgdiplus, клонирует исходники, затем собирает их и устанавливает в нужное место. Всё остальное аналогично [Установить и настроить Docker на Linux (apt-get libgdiplus)](/slides/ru/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Примечание**: Не забудьте использовать разные теги образов (имена) для получаемого образа в командах docker build и docker run:
``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```


## **Установить и настроить Docker на Windows Server Core**
- ОС: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Примечание**: Для запуска Windows‑контейнеров требуется Windows 10 Pro или Windows Server 2016.

К сожалению, Microsoft не предоставляет образ Windows Server Core с установленным dotnet SDK, поэтому его необходимо установить вручную:
``` csharp
\# escape=

#set powershell default executor
# установить PowerShell в качестве исполнителя по умолчанию

\# escape=

#set powershell default executor
# установить PowerShell в качестве исполнителя по умолчанию

# Retrieve .NET Core SDK
# Получить .NET Core SDK

#return cmd as default executor
# вернуть cmd в качестве исполнителя по умолчанию

# In order to set system PATH, ContainerAdministrator must be used
# Чтобы установить системный PATH, необходимо использовать ContainerAdministrator

# create mount points
# создать точки монтирования

#build and test Aspose.Slides on start
# собрать и протестировать Aspose.Slides при запуске
```


Полученный образ будет построен на базе образа microsoft/windowsservercore:1803, предоставленного Microsoft на [docker hub](https://hub.docker.com/u/microsoft). Dotnet‑sdk указанной версии будет загружен и распакован; переменная PATH системы будет обновлена, чтобы включать путь к исполняемому файлу dotnet. Последняя строка определяет команду, которая запускает тесты func и regr в контейнере с использованием nant.exe в качестве действия по умолчанию при запуске контейнера.

Команда для сборки образа:
``` csharp
docker build -f Dockerfile_WinServerCore -t winservercore_slides .
```


Команда для запуска образа:
``` csharp
docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest
```


**Примечание**: Команда для Windows‑контейнера использует 2 дополнительных аргумента:
*-cpu-count 3* — задаёт количество ядер.  
*-memory 8589934592* — задаёт объём памяти.  
Эти параметры задают количество ядер и объём памяти, доступных контейнеру. По умолчанию для Windows‑контейнера доступно только 1 ядро и 1 ГБ ОЗУ (у Linux‑контейнеров ограничений по умолчанию нет).

Также в этом случае отсутствует один аргумент по сравнению с той же командой, которую мы использовали для запуска Linux‑контейнера:
*-add-host dev.slides.external.tool.server:192.168.1.48* — поскольку контейнер на Windows не требует external.tool.server.

Результат выполнения вышеуказанной команды должен выглядеть следующим образом:
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
