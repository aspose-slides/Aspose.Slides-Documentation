---
title: Como Executar Aspose.Slides no Docker
linktitle: Aspose.Slides no Docker
type: docs
weight: 140
url: /pt/net/how-to-run-aspose-slides-in-docker/
keywords:
- SO suportado
- Aspose.Slides no Docker
- Contêiner Docker
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- repositório de imagens
- Windows Server Core
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Execute Aspose.Slides em contêineres Docker: configure imagens, dependências, fontes e licenciamento para criar serviços escaláveis que processam PowerPoint e OpenDocument."
---
## **Sistemas Operacionais Compatíveis**
Aspose.Slides pode ser executado dentro de contêineres Docker usando a plataforma .NET Core. Em geral, Aspose.Slides oferece suporte a todos os tipos de contêineres (SO) que a plataforma .NET Core suporta. No entanto, o GDI ou [libgdiplus](https://github.com/mono/libgdiplus) precisam estar disponíveis e configurados corretamente nos contêineres envolvidos.

Para usar o Docker, você deve primeiro instalá‑lo no seu sistema. Para aprender como instalar o Docker no Windows ou no Mac, use estes links:

- [Instalar Docker no Windows](https://docs.docker.com/docker-for-windows/install/)
- [Instalar Docker no Mac](https://docs.docker.com/docker-for-mac/install/)

Você também pode executar o Docker no Linux e no Windows Server seguindo as instruções nestas páginas:

- [Instalar e configurar Docker no Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)

- [Instalar e configurar Docker no Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)

- [Instalar e configurar Docker no Windows Server Core](#install-and-configure-docker-on-windows-server-core)

A instalação e configuração do Docker no Windows Server Nano não é suportada. Infelizmente, o Windows Server Nano não contém o subsistema gráfico integrado. Ele não contém o gdiplus.dll, que a biblioteca System.Drawing.Common requer, e não pode ser usado com a biblioteca Aspose.Slides.

Embora seja possível executar contêineres Linux no Windows, recomendamos que você os execute nativamente no Linux (mesmo em um Linux instalado manualmente em uma VM usando VirtualBox).

## **Instalar e Configurar Docker no Linux (apt-get libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Este Dockerfile contém instruções para construir uma imagem de contêiner com o pacote libgdiplus instalado a partir dos repositórios oficiais de pacotes do Ubuntu.

Segue o conteúdo do Dockerfile:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# instalar libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# criar pontos de montagem

VOLUME /slides-src

\# compilar e testar Aspose.Slides ao iniciar

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Vamos analisar o que cada linha de código no Dockerfile significa:

1. A imagem do contêiner é baseada na imagem microsoft/dotnet:2.1-sdk-bionic (imagem já construída pela Microsoft e publicada no [public hub](https://hub.docker.com/r/microsoft/dotnet/) do Docker). Essa imagem contém o SDK dotnet 2.1 já instalado. O sufixo *bionic* significa que o Ubuntu 18.04 (codinome bionic) será usado como SO do contêiner. Alterando o sufixo, é possível mudar o SO subjacente (por exemplo: *stretch* – Debian 9, *alpine* – Alpine Linux). Nesse caso, será necessária a modificação do conteúdo do Dockerfile (por exemplo, mudar “apt-get” para “yum”).

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

1. Atualiza o banco de dados de pacotes disponíveis e instala o pacote apt-utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

1. Instala os pacotes **libgdiplus** e **libc6-dev**, exigidos pela biblioteca System.Drawing.Common.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

1. Declara a pasta **/slides-src** como ponto de montagem que será usado para fornecer acesso à pasta de fontes slide-net na máquina host.

``` csharp

 VOLUME /slides-src

```

1. Define **slides-src** como diretório de trabalho dentro do contêiner.

``` csharp

 WORKDIR /slides-src

```

1. Declara um comando padrão que será executado ao iniciar o contêiner caso nenhum comando explícito seja especificado.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

De acordo com as instruções no Dockerfile, a imagem resultante do contêiner terá o SO Ubuntu 18.04, o dotnet‑sdk, os pacotes libgdiplus e libc6-dev já instalados. Além disso, esta imagem possuirá um ponto de montagem pré‑definido e um comando padrão pré‑definido ao ser iniciada.

Para construir uma imagem usando este Dockerfile, você deve ir para a pasta **slides-netuil/docker** e executar:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* — especifica qual Dockerfile será usado.  
*-t ubuntu18_04_apt_get_libgdiplus* — define a tag (nome) da imagem resultante.  
*'.'* — define o contexto para o Docker. No nosso caso, o contexto é a pasta atual e está vazia — pois escolhemos fornecer as fontes slide‑net como ponto de montagem (isso nos permite não reconstruir a imagem Docker a cada alteração nas fontes).

O resultado da execução deve ser semelhante a este:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Para garantir que a nova imagem foi adicionada ao repositório local de imagens:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Uma vez que a imagem esteja pronta, podemos executá‑la com o comando:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* — indica que o comando deve ser executado de forma interativa, permitindo ver a saída e capturar a entrada.  
*-v `pwd`/../../:/slides-src* — especifica a pasta para o ponto de montagem pré‑definido — como o diretório de trabalho atual é **slides-netuil/docker**, a pasta **slides-src** no contêiner apontará para a pasta **slides-net** no host. `pwd` é usado para especificar o caminho relativo.  
*--add-host dev.slides.external.tool.server:192.168.1.48* — modifica o arquivo **hosts** do contêiner para resolver a URL **dev.slides.external.tool.server**.  
*ubuntu1804aptgetlibgdiplus:latest* — especifica a imagem a ser usada para iniciar o contêiner.

O resultado do comando acima será a execução de **netcore.linux.tests.sh** (pois ele foi definido como comando padrão do contêiner):

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

A partir do resultado, fica claro que arquivos de log dos testes Func e Regr foram gravados no diretório **/build-out/netstandard20/test-results/main/**. Além disso, cerca de 200 testes falharam no total — todos relacionados a problemas de renderização por ausência de fontes necessárias no contêiner.

Para sobrescrever o comando padrão do contêiner em uma execução, podemos usar este comando:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Assim, em vez de **netcore.linux.tests.sh**, o **/bin/bash** será executado e fornecerá uma sessão terminal ativa do contêiner a partir da qual o script (**./build/netcore.linux.tests.sh**) pode ser executado. Essa abordagem pode ser útil em cenários de solução de problemas.

## **Instalar e Configurar Docker no Linux (make install libgdiplus)**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

No momento, o Ubuntu contém apenas a versão 4.2 do libgdiplus, enquanto a versão 5.6 já está disponível no [site oficial](https://github.com/mono/libgdiplus/releases) do produto. Para testar a versão mais recente do libgdiplus, precisamos preparar uma imagem com o libgdiplus compilado a partir das fontes.

Vamos revisar o conteúdo do Dockerfile:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# construir libgdiplus estável mais recente

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# criar pontos de montagem

VOLUME /slides-src

\# compilar e testar Aspose.Slides ao iniciar

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

A única diferença está na seção **build latest stable libgdiplus**. Essa seção instala todas as ferramentas necessárias para compilar o libgdiplus, clona as fontes, compila‑as e as instala no local correto. Todo o restante é idêntico ao descrito em [Instalar e configurar Docker no Linux (apt-get libgdiplus)](/slides/pt/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Observação**: Não esqueça de usar tags (nomes) diferentes para a imagem resultante nos comandos **docker build** e **docker run**:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Instalar e Configurar Docker no Windows Server Core**
- OS: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Observação**: Windows 10 Pro ou Windows Server 2016 são necessários para executar contêineres Windows.

Infelizmente, a Microsoft não fornece uma imagem Windows Server Core com o SDK do dotnet instalado, portanto devemos instalá‑lo manualmente:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#definir o executor padrão do powershell

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#definir o executor padrão do powershell

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

\# Recuperar .NET Core SDK

ENV DOTNET_SDK_VERSION 2.1.301

ENV DOTNET_PATH "c:/Program Files/dotnet"

RUN Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$Env:DOTNET_SDK_VERSION/dotnet-sdk-$Env:DOTNET_SDK_VERSION-win-x64.zip; 

    $dotnet_sha512 = 'f2f6cc020f89dc4d4f8064cc914cffabde0ce422715138778a6bcbbb6803ca66d6fd967097a0209c47c89b85dd9e93db48486ac86999bd3a533e45b789fcea89'; 

    if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { 

        Write-Host 'CHECKSUM VERIFICATION FAILED!'; 

        exit 1; 

    }; 

    

    Expand-Archive dotnet.zip -DestinationPath $Env:DOTNET_PATH;

#retornar cmd como executor padrão

SHELL ["cmd", "/S", "/C"]

\# Para definir o PATH do sistema, ContainerAdministrator deve ser usado

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# criar pontos de montagem

VOLUME c:/slides-src

#compilar e testar Aspose.Slides ao iniciar

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

A imagem resultante será construída sobre a imagem **microsoft/windowsservercore:1803** disponibilizada pela Microsoft no [docker hub](https://hub.docker.com/u/microsoft). O dotnet‑sdk da versão especificada será baixado e descompactado; a variável de ambiente **PATH** do sistema será atualizada para conter o caminho para o executável dotnet. A última linha define o comando que executa os testes func & regr no contêiner usando **nant.exe** como ação padrão na execução do contêiner.

Comando para construir a imagem:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Comando para executar a imagem:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Observação**: O comando para contêiner Windows usa 2 argumentos extras:

*-cpu-count 3*  
*-memory 8589934592*

Eles definem, respectivamente, o número de núcleos e a quantidade de memória disponível para o contêiner. Por padrão, apenas 1 núcleo e 1 GB de RAM estão disponíveis para o contêiner Windows (contêineres Linux não possuem limitações por padrão).

Além disso, falta 1 argumento em comparação ao mesmo comando usado para executar o contêiner Linux:

*-add-host dev.slides.external.tool.server:192.168.1.48*

Porque o contêiner em Windows simplesmente não necessita do **external.tool.server**.

O resultado do comando acima deverá ser parecido com este:

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