---
title: วิธีการรัน Aspose.Slides ใน Docker
linktitle: Aspose.Slides ใน Docker
type: docs
weight: 140
url: /th/net/how-to-run-aspose-slides-in-docker/
keywords:
- ระบบปฏิบัติการที่รองรับ
- Aspose.Slides ใน Docker
- คอนเทนเนอร์ Docker
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- ที่เก็บอิมเมจ
- Windows Server Core
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียกใช้ Aspose.Slides ในคอนเทนเนอร์ Docker: กำหนดค่าอิมเมจ, ขึ้นต่อ, ฟอนต์, และการให้สิทธิ์เพื่อสร้างบริการที่สามารถขยายได้ซึ่งประมวลผล PowerPoint และ OpenDocument."
---
## **ระบบปฏิบัติการที่รองรับ**
Aspose.Slides สามารถทำงานภายในคอนเทนเนอร์ Docker โดยใช้แพลตฟอร์ม .NET Core โดยทั่วไป Aspose.Slides รองรับประเภทคอนเทนเนอร์ (OS) ทั้งหมดที่แพลตฟอร์ม .NET Core รองรับ อย่างไรก็ตาม GDI หรือ [libgdiplus](https://github.com/mono/libgdiplus) ต้องพร้อมใช้งานและตั้งค่าอย่างถูกต้องในคอนเทนเนอร์ที่เกี่ยวข้อง

ในการใช้ Docker คุณต้องติดตั้งก่อนบนระบบของคุณ หากต้องการเรียนรู้วิธีการติดตั้ง Docker บน Windows หรือ Mac ให้ใช้ลิงก์ต่อไปนี้:

- [ติดตั้ง Docker บน Windows](https://docs.docker.com/docker-for-windows/install/)
- [ติดตั้ง Docker บน Mac](https://docs.docker.com/docker-for-mac/install/)

คุณยังสามารถใช้ Docker บน Linux และ Windows Server โดยทำตามคำแนะนำในหน้าเหล่านี้:

- [ติดตั้งและกำหนดค่า Docker บน Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [ติดตั้งและกำหนดค่า Docker บน Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [ติดตั้งและกำหนดค่า Docker บน Windows Server Core](#install-and-configure-docker-on-windows-server-core)

การติดตั้งและกำหนดค่าสำหรับ Docker บน Windows Server Nano ไม่ได้รับการสนับสนุน อย่างน่าเสียดาย Windows Server Nano ไม่มีระบบย่อยกราฟิกในตัว ไม่ได้มีไฟล์ gdiplus.dll ซึ่งไลบรารี System.Drawing.Common ต้องการ และไม่สามารถใช้กับไลบรารี Aspose.Slides ได้

แม้ว่าจะสามารถรันคอนเทนเนอร์ Linux บน Windows ได้ แต่เราขอแนะนำให้คุณรันโดยตรงบน Linux (แม้จะติดตั้ง Linux ด้วยตนเองบน VM ที่ใช้ VirtualBox)

## **ติดตั้งและกำหนดค่า Docker บน Linux (apt-get libgdiplus)**
- ระบบปฏิบัติการ: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

ไฟล์ Docker นี้มีคำสั่งสำหรับสร้างอิมเมจของคอนเทนเนอร์พร้อมแพ็คเกจ libgdiplus ที่ติดตั้งจากที่เก็บแพ็กเกจอย่างเป็นทางการของ Ubuntu

นี่คือเนื้อหาไฟล์ Docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# ติดตั้ง libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# สร้างจุดเมานท์

VOLUME /slides-src

\# สร้างและทดสอบ Aspose.Slides เมื่อเริ่มต้น

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

เรามาทบทวนความหมายของแต่ละบรรทัดโค้ดในไฟล์ Docker กัน:

1. อิมเมจของคอนเทนเนอร์อิงจากภาพ microsoft/dotnet:2.1-sdk-bionic (ภาพที่ Microsoft สร้างไว้แล้วและเผยแพร่บน [public hub](https://hub.docker.com/r/microsoft/dotnet/) ของ Docker) ภาพนี้มี SDK dotnet 2.1 ที่ติดตั้งไว้แล้ว คำต่อท้าย Bionic หมายถึง Ubuntu 18.04 (ชื่อรหัส bionic) จะถูกใช้เป็น OS ของคอนเทนเนอร์ โดยการเปลี่ยนคำต่อท้ายสามารถเปลี่ยน OS พื้นฐานได้ (เช่น: stretch -- Debian 9, alpine -- Alpine Linux) ในกรณีนั้นต้องแก้ไขเนื้อหาไฟล์ Docker (เช่น เปลี่ยน 'apt-get' เป็น 'yum').

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```

อัปเดตฐานข้อมูลของแพ็กเกจที่มีอยู่และติดตั้งแพ็กเกจ apt-utils.

``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```

ติดตั้งแพ็กเกจ 'libgdiplus' และ 'libc6-dev' ที่จำเป็นสำหรับไลบรารี System.Drawing.Common.

``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```

ประกาศโฟลเดอร์ /slides-src เป็นจุดเมานท์ซึ่งเราจะใช้เพื่อให้เข้าถึงโฟลเดอร์ซอร์สของ slide-net บนเครื่องโฮสต์.

``` csharp

 VOLUME /slides-src

```

ตั้งค่า slides-src เป็นไดเรกทอรีทำงานภายในคอนเทนเนอร์.

``` csharp

 WORKDIR /slides-src

```

ประกาศคำสั่งเริ่มต้นที่จะรันเมื่อคอนเทนเนอร์เริ่มต้น หากไม่มีการระบุคำสั่งแบบเจาะจง.

``` csharp

 CMD ./build/netcore.linux.tests.sh

```

ตามคำแนะนำในไฟล์ Docker อิมเมจของคอนเทนเนอร์ที่ได้จะมี OS Ubuntu 18.04, dotnet-sdk, libgdiplus และแพ็กเกจ libc6-dev ติดตั้งแล้ว อีกทั้งอิมเมจนี้จะมีจุดเมานท์ที่กำหนดไว้ล่วงหน้าและคำสั่งเริ่มต้นที่กำหนดไว้เมื่อรัน

เพื่อสร้างอิมเมจโดยใช้ไฟล์ Docker นี้ คุณต้องไปที่โฟลเดอร์ docker ของ slides-netuil และดำเนินการ:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

*-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- ตัวเลือกระบุว่าใช้ไฟล์ Docker ไหน  
*-t ubuntu18_04_apt_get_libgdiplus* -- ระบุแท็ก (ชื่อ) สำหรับอิมเมจที่ได้  
*'.'* -- ระบุคอนเทกสต์สำหรับ Docker ในกรณีของเรา คอนเทกสต์คือโฟลเดอร์ปัจจุบันและเป็นโฟลเดอร์ว่าง—เพราะเราเลือกให้ซอร์สของ slides-net เป็นจุดเมานท์ (ซึ่งทำให้ไม่ต้องสร้างอิมเมจ Docker ใหม่ทุกครั้งที่มีการเปลี่ยนแปลงซอร์ส)

ผลลัพธ์ของการดำเนินการควรมีลักษณะดังนี้:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

เพื่อยืนยันว่าอิมเมจใหม่ได้ถูกเพิ่มไปยังคลังอิมเมจในเครื่อง:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

เมื่ออิมเมจพร้อม เราสามารถรันโดยใช้คำสั่งนี้:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

*-it* -- ระบุว่าคำสั่งควรรันแบบโต้ตอบ ทำให้เราสามารถดูผลลัพธ์และรับข้อมูลเข้าได้  
*-v `pwd`/../../:/slides-src* -- ระบุโฟลเดอร์สำหรับจุดเมานท์ที่กำหนดไว้ล่วงหน้า—เนื่องจากไดเรกทอรีทำงานปัจจุบันคือ slides-netuildocker แล้วโฟลเดอร์ slides-src ในคอนเทนเนอร์จะชี้ไปที่โฟลเดอร์ slides-net บนโฮสต์ `pwd` ใช้ระบุเส้นทางสัมพันธ์  
*--add-host dev.slides.external.tool.server:192.168.1.48* -- ปรับไฟล์ hosts ของคอนเทนเนอร์เพื่อให้สามารถ resolve URL dev.slides.external.tool.server  
*ubuntu1804aptgetlibgdiplus:latest* -- ระบุอิมเมจที่จะรันคอนเทนเนอร์

ผลลัพธ์ของคำสั่งข้างต้นจะเป็นการแสดงผลของ netcore.linux.tests.sh (เนื่องจากกำหนดเป็นคำสั่งเริ่มต้นสำหรับคอนเทนเนอร์):

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

จากผลลัพธ์ จะเห็นว่าไฟล์บันทึกจากการทดสอบ Func และ Regr ถูกเก็บไว้ที่ไดเรกทอรี /build-out/netstandard20/test-results/main/ นอกจากนี้ มีการทดสอบประมาณ 200 รายการที่ล้มเหลวทั้งหมด—ทั้งหมดเป็นปัญหาการแสดงผลที่เกี่ยวกับการไม่มีฟอนต์ที่จำเป็นในคอนเทนเนอร์

หากต้องการแทนที่คำสั่งเริ่มต้นของคอนเทนเนอร์เมื่อรัน เราสามารถใช้คำสั่งนี้:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

ดังนั้น แทนที่ netcore.linux.tests.sh จะรัน /bin/bash แทน และจะให้เซสชั่นเทอร์มินัลแบบโต้ตอบของคอนเทนเนอร์ที่สามารถรัน (./build/netcore.linux.tests.sh) วิธีนี้อาจมีประโยชน์ในสถานการณ์การแก้ไขปัญหา

## **ติดตั้งและกำหนดค่า Docker บน Linux (make install libgdiplus)**
- ระบบปฏิบัติการ: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

ในขณะนี้ Ubuntu มีเพียงเวอร์ชัน 4.2 ของ libgdiplus ขณะที่เวอร์ชัน 5.6 มีให้แล้วบน [เว็บไซต์อย่างเป็นทางการของผลิตภัณฑ์](https://github.com/mono/libgdiplus/releases). เพื่อทดสอบเวอร์ชันล่าสุดของ libgdiplus เราต้องเตรียมอิมเมจที่สร้าง libgdiplus จากซอร์ส

เรามาทบทวนเนื้อหาไฟล์ Docker กัน:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# สร้าง libgdiplus รุ่นเสถียรล่าสุด

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# สร้างจุดเมานท์

VOLUME /slides-src

\# สร้างและทดสอบ Aspose.Slides เมื่อเริ่มต้น

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

ความแตกต่างเดียวคือส่วน *build latest stable libgdiplus* ส่วนนี้จะติดตั้งเครื่องมือที่จำเป็นทั้งหมดสำหรับการสร้าง libgdiplus, โคลนซอร์ส, แล้วทำการสร้างและติดตั้งไปยังตำแหน่งที่ถูกต้อง ส่วนอื่นๆ เหมือนกับ [ติดตั้งและกำหนดค่า Docker บน Linux (apt-get libgdiplus)](/slides/th/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**หมายเหตุ**: อย่าลืมใช้แท็กอิมเมจที่แตกต่างกัน (ชื่อ) สำหรับอิมเมจที่ได้ในคำสั่ง docker build และ docker run:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **ติดตั้งและกำหนดค่า Docker บน Windows Server Core**
- ระบบปฏิบัติการ: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**หมายเหตุ**: ต้องมี Windows 10 Pro หรือ Windows Server 2016 เพื่อรันคอนเทนเนอร์ Windows

น่าเสียดายว่า Microsoft ไม่ได้ให้ภาพ Windows Server Core ที่ติดตั้ง dotnet SDK ไว้ ดังนั้นเราต้องติดตั้งด้วยตนเอง:

``` csharp

 # escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor
#set powershell default executor
#set powershell default executor
#set powershell default executor
\# escape=

FROM microsoft/windowsservercore:1803 AS installer-env

#set powershell default executor
#set powershell default executor
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

SHELL ["cmd", "/S", "/C"]
\# In order to set system PATH, ContainerAdministrator must be used
USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

User ContainerUser

\# create mount points

VOLUME c:/slides-src

#build and test Aspose.Slides on start

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

อิมเมจที่ได้จะถูกสร้างบนพื้นฐานของภาพ microsoft/windowsservercore:1803 ที่ Microsoft ให้บน [docker hub](https://hub.docker.com/u/microsoft). dotnet-sdk รุ่นที่ระบุจะถูกดาวน์โหลดและแตกไฟล์; ตัวแปร PATH ของระบบจะถูกอัปเดตให้รวมเส้นทางไปยังไฟล์ปฏิบัติการ dotnet. บรรทัดสุดท้ายกำหนดคำสั่งที่รันการทดสอบ func และ regr บนคอนเทนเนอร์โดยใช้ nant.exe เป็นการกระทำเริ่มต้นเมื่อรันคอนเทนเนอร์

คำสั่งสำหรับสร้างอิมเมจ:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

คำสั่งสำหรับรันอิมเมจ:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**หมายเหตุ**: คำสั่งสำหรับคอนเทนเนอร์ Windows ใช้พารามิเตอร์เพิ่มเติม 2 ตัว:
*-cpu-count 3* -- ตั้งค่าจำนวนคอร์  
*-memory 8589934592* -- ตั้งค่าขนาดหน่วยความจำที่ใช้ได้สำหรับคอนเทนเนอร์

พวกมันกำหนดจำนวนคอร์และปริมาณหน่วยความจำที่คอนเทนเนอร์สามารถใช้ได้ ตามค่าเริ่มต้นคอนเทนเนอร์ Windows มีเพียง 1 คอร์และ 1GB RAM ส่วนคอนเทนเนอร์ Linux ไม่จำกัดโดยค่าเริ่มต้น

นอกจากนี้ ยังขาดพารามิเตอร์ 1 ตัวเมื่อเทียบกับคำสั่งเดียวกันที่ใช้รันคอนเทนเนอร์ Linux:
*-add-host dev.slides.external.tool.server:192.168.1.48* -- เพราะคอนเทนเนอร์ที่รันบน Windows ไม่ต้องการ external.tool.server

ผลลัพธ์ของคำสั่งข้างต้นควรมีลักษณะดังนี้:

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