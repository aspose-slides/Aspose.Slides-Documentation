---
title: Cómo Ejecutar Aspose.Slides en Docker
type: docs
weight: 140
url: /net/how-to-run-aspose-slides-in-docker/
keywords: "Ejecutar Aspose.Slides en contenedor Docker, Aspose Docker, Aspose.Slides en Docker"
description: "Ejecutar Aspose.Slides en un contenedor Docker para Linux, Windows Server y cualquier sistema operativo."
---

## **Sistemas Operativos Soportados**
Aspose.Slides puede ejecutarse dentro de contenedores Docker utilizando la plataforma .NET Core. En general, Aspose.Slides soporta todos los tipos de contenedores (sistemas operativos) que la plataforma .NET Core soporta. Sin embargo, el GDI o [libgdiplus](https://github.com/mono/libgdiplus) debe estar disponible y configurado correctamente en los contenedores involucrados.

Para usar Docker, primero debes instalarlo en tu sistema. Para aprender cómo instalar Docker en Windows o Mac, usa estos enlaces:

- [Instalar Docker en Windows](https://docs.docker.com/docker-for-windows/install/)
- [Instalar Docker en Mac](https://docs.docker.com/docker-for-mac/install/)

También puedes ejecutar Docker en Linux y Windows Server siguiendo las instrucciones en estas páginas:

- [Instalar y configurar Docker en Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [Instalar y configurar Docker en Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)

- [Instalar y configurar Docker en Windows Server Core](#install-and-configure-docker-on-windows-server-core)

La instalación y configuración de Docker en Windows Server Nano no está soportada. Desafortunadamente, Windows Server Nano no contiene el subsistema gráfico a bordo. No contiene gdiplus.dll, que la biblioteca System.Drawing.Common requiere, y no puede ser usado con la biblioteca Aspose.Slides.

Si bien es posible ejecutar contenedores Linux en Windows, te recomendamos que los ejecutes de forma nativa en Linux (incluso en un Linux instalado manualmente en una VM usando VirtualBox).

## **Instalación y Configuración de Docker en Linux (apt-get libgdiplus)**
- SO: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Este archivo docker contiene instrucciones para construir una imagen de contenedor con el paquete libgdiplus instalado desde los repositorios de paquetes oficiales de Ubuntu.

Aquí están los contenidos del archivo docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# instalar libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# crear puntos de montaje

VOLUME /slides-src

\# construir y probar Aspose.Slides al iniciar

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Revisemos lo que cada línea de código en el archivo docker significa:

1. La imagen del contenedor se basa en la imagen microsoft/dotnet:2.1-sdk-bionic (la imagen ya construida por Microsoft y publicada en el [hub público de docker](https://hub.docker.com/r/microsoft/dotnet/)). Esta imagen contiene el SDK de dotnet 2.1 ya instalado. El sufijo bionic significa que se tomará Ubuntu 18.04 (código bionic) como sistema operativo del contenedor. Al cambiar el sufijo, es posible cambiar el sistema operativo subyacente (por ejemplo: stretch -- Debian 9, alpine -- Alpine Linux). En ese caso, se requeriría una modificación del contenido del archivo docker (por ejemplo, cambiar 'apt-get' por 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

2. Actualiza la base de datos de paquetes disponibles e instala el paquete apt-utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

3. Instala los paquetes 'libgdiplus' y 'libc6-dev' requeridos por la biblioteca System.Drawing.Common.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

4. Declara la carpeta /slides-src como un punto de montaje que usaremos para proporcionar acceso a la carpeta de fuentes de slide-net en la máquina host.

``` csharp

 VOLUME /slides-src

```

5. Establece slides-src como el directorio de trabajo dentro del contenedor.

``` csharp

 WORKDIR /slides-src

```

6. Declara un comando predeterminado que se ejecutará al iniciar el contenedor en caso de que no se especifique un comando explícito.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

De acuerdo con las instrucciones en el archivo docker, la imagen resultante del contenedor tendrá el sistema operativo Ubuntu 18.04, dotnet-sdk, y los paquetes libgdiplus y libc6-dev ya instalados. Además, esta imagen tendrá un punto de montaje predefinido y un comando predefinido al ejecutarse.

Para construir una imagen usando este archivo docker, debes ir a la carpeta docker de slides-netuil y ejecutar:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- opción que especifica qué archivo docker usar.

*-t ubuntu18_04_apt_get_libgdiplus* -- especifica la etiqueta (nombre) para la imagen resultante.

*'.'* -- especifica el contexto para docker. En nuestro caso, el contexto es la carpeta actual y está vacía, ya que elegimos proporcionar las fuentes de slides-net como punto de montaje (esto nos permite no reconstruir la imagen docker en cada cambio en las fuentes).

El resultado de la ejecución debería verse así:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Para asegurarte de que la nueva imagen fue añadida al repositorio local de imágenes:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Una vez que la imagen esté lista, podemos ejecutarla usando este comando:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- especifica que el comando debe ejecutarse de forma interactiva, permitiéndonos ver la salida y capturar la entrada.

*-v `pwd`/../../:/slides-src* -- especifica la carpeta para el punto de montaje predefinido; dado que el directorio de trabajo actual es slides-netuildocker, la carpeta slides-src en el contenedor apuntará a la carpeta slides-net en el host. `pwd` se usa para especificar la ruta relativa.

*--add-host dev.slides.external.tool.server:192.168.1.48* -- modifica el archivo hosts del contenedor para resolver la url dev.slides.external.tool.server.

*ubuntu1804aptgetlibgdiplus:latest* -- especifica la imagen para ejecutar el contenedor.

El resultado del comando anterior será la salida de netcore.linux.tests.sh (ya que se definió como un comando predeterminado para el contenedor):

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

A partir del resultado, está claro que los archivos de registro de las pruebas Func y Regr fueron colocados en el directorio /build-out/netstandard20/test-results/main/. Además, aproximadamente 200 pruebas fallaron en total, y todos estos son problemas de renderizado relacionados con la ausencia de fuentes requeridas en el contenedor.

Para anular el comando predeterminado del contenedor al ejecutarlo, podríamos usar este comando:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Entonces, en lugar de netcore.linux.tests.sh, se ejecutará /bin/bash y proporcionará una sesión terminal activa de un contenedor desde la cual se puede ejecutar (./build/netcore.linux.tests.sh). Este enfoque puede ser útil en escenarios de solución de problemas.
## **Instalación y Configuración de Docker en Linux (make install libgdiplus)**
- SO: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

En este momento, Ubuntu contiene solo la versión 4.2 de libgdiplus, mientras que la versión 5.6 ya está disponible en el [sitio oficial del producto](https://github.com/mono/libgdiplus/releases). Para probar la última versión de libgdiplus, necesitamos preparar una imagen con libgdiplus construida a partir de los fuentes.

Revisemos el contenido del archivo docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# construir la última libgdiplus estable

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# crear puntos de montaje

VOLUME /slides-src

\# construir y probar Aspose.Slides al iniciar

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

La única diferencia es la sección *construir la última libgdiplus estable*. Esta sección instala todas las herramientas necesarias para construir libgdiplus, clona las fuentes, y luego las construye e instala en la ubicación correcta. Todo lo demás es igual a [Instalar y configurar Docker en Linux (apt-get libgdiplus)](/slides/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Nota**: No olvides usar diferentes etiquetas de imagen (nombre) para la imagen resultante en los comandos docker build y docker run:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Instalar y configurar Docker en Windows Server Core**
- SO: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Nota**: Se requiere Windows 10 Pro o Windows Server 2016 para ejecutar contenedores de Windows.

Desafortunadamente, Microsoft no proporciona una imagen de Windows Server Core con el SDK de dotnet instalado, por lo que tenemos que instalarlo manualmente:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Recuperar .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip;

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89';

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) {

        Write-Host '¡FALLÓ LA VERIFICACIÓN DE SUMA DE COMPROBACIÓN!';

        exit 1;

    };

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#retornar cmd como ejecutor predeterminado

SHELL ["cmd", "/S", "/C"]

\# Para establecer el PATH del sistema, se debe usar ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# crear puntos de montaje

VOLUME c:/slides-src

# construir y probar Aspose.Slides al iniciar

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

La imagen resultante se construirá sobre la imagen microsoft/windowsservercore:1803 proporcionada por Microsoft en el [hub de docker](https://hub.docker.com/r/microsoft/windowsservercore/). El sdk de dotnet de la versión especificada será descargado y descomprimido; la variable PATH del sistema se actualizará para contener la ruta al ejecutable dotnet. La última línea define el comando que ejecuta pruebas func y regr en el contenedor utilizando nant.exe como acción predeterminada al ejecutar el contenedor.

Comando para construir la imagen:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Comando para ejecutar la imagen:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Nota**: El comando para el contenedor de Windows utiliza 2 argumentos adicionales:

*-cpu-count 3*

*-memory 8589934592*

Estos establecen el número de núcleos y la cantidad de memoria disponible para el contenedor. Por defecto, solo 1 núcleo y 1GB de RAM están disponibles para el contenedor de Windows (los contenedores de Linux no tienen ninguna limitación por defecto).

Además, 1 argumento se omite en comparación con el mismo comando que usamos para ejecutar el contenedor de Linux:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Porque el contenedor que se ejecuta en Windows simplemente no requiere external.tool.server.

El resultado del comando anterior debería verse así:

``` csharp

 NAnt 0.92 (Build 0.92.4543.0; release; 6/9/2012)

Copyright (C) 2001-2012 Gerry Shaw

http://nant.sourceforge.net

netcore20_runtests:

   [delete] Eliminando directorio 'c:\slides-src\build-out\netcore20\test-results\'. 

   [mkdir] Creando directorio 'c:\slides-src\build-out\netcore20\test-results\'. 

...

[exec] Results File: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.FuncTests.NetCore.trx

[exec] Total tests: 2338. Passed: 2115. Failed: 19. Skipped: 204.

...

[exec] Results File: C:\slides-src\/build-out/netcore20/test-results//main\Aspose.Slides.RegrTests.NetCore.trx

[exec] Total tests: 2728. Passed: 2147. Failed: 110. Skipped: 471.

```