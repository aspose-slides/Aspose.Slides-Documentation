---
title: Cách chạy Aspose.Slides trong Docker
linktitle: Aspose.Slides trong Docker
type: docs
weight: 140
url: /vi/net/how-to-run-aspose-slides-in-docker/
keywords:
- hệ điều hành được hỗ trợ
- Aspose.Slides trong Docker
- container Docker
- Aspose Docker
- GDI
- libgdiplus
- System.Drawing.Common
- Linux
- kho lưu trữ hình ảnh
- Windows Server Core
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Chạy Aspose.Slides trong các container Docker: cấu hình image, các phụ thuộc, font và giấy phép để xây dựng các dịch vụ có khả năng mở rộng xử lý PowerPoint và OpenDocument."
---
## **Hệ điều hành được hỗ trợ**
Aspose.Slides có thể chạy trong các container Docker sử dụng nền tảng .NET Core. Nói chung, Aspose.Slides hỗ trợ tất cả các loại container (hệ điều hành) mà nền tảng .NET Core hỗ trợ. Tuy nhiên, GDI hoặc [libgdiplus](https://github.com/mono/libgdiplus) phải có sẵn và được thiết lập đúng cách trên các container liên quan.

Để sử dụng Docker, bạn cần cài đặt nó trên hệ thống của mình trước. Để tìm hiểu cách cài đặt Docker trên Windows hoặc Mac, hãy sử dụng các liên kết sau:

- [Cài đặt Docker trên Windows](https://docs.docker.com/docker-for-windows/install/)
- [Cài đặt Docker trên Mac](https://docs.docker.com/docker-for-mac/install/)

Bạn cũng có thể chạy Docker trên Linux và Windows Server bằng cách làm theo hướng dẫn trên các trang sau:

- [Cài đặt và cấu hình Docker trên Linux (apt-get libgdiplus)](#install-and-configure-docker-on-linux-apt-get-libgdiplus)
- [Cài đặt và cấu hình Docker trên Linux (make install libgdiplus)](#install-and-configure-docker-on-linux-make-install-libgdiplus)
- [Cài đặt và cấu hình Docker trên Windows Server Core](#install-and-configure-docker-on-windows-server-core)

Việc cài đặt và cấu hình Docker trên Windows Server Nano không được hỗ trợ. Thật không may, Windows Server Nano không có hệ thống đồ họa bên trong. Nó không chứa gdiplus.dll, mà thư viện System.Drawing.Common yêu cầu, và không thể được sử dụng với thư viện Aspose.Slides.

Mặc dù có thể chạy các container Linux trên Windows, chúng tôi khuyên bạn nên chạy chúng trực tiếp trên Linux (ngay cả khi Linux được cài đặt thủ công trên một máy ảo bằng VirtualBox).

## **Cài đặt và cấu hình Docker trên Linux (apt-get libgdiplus)**
- Hệ điều hành: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_apt_get_libgdiplus

Tệp Docker này chứa các hướng dẫn để xây dựng một hình ảnh container với gói libgdiplus được cài đặt từ kho gói chính thức của Ubuntu.

Dưới đây là nội dung của tệp Docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# cài đặt libgdiplus

RUN apt-get update -y && apt-get install -y apt-utils

RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

\# tạo điểm gắn kết

VOLUME /slides-src

\# xây dựng và kiểm tra Aspose.Slides khi khởi động

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Hãy xem xét ý nghĩa của từng dòng mã trong tệp Docker:

1. Hình ảnh container dựa trên image microsoft/dotnet:2.1-sdk-bionic (image đã được Microsoft xây dựng và đăng trên [public hub](https://hub.docker.com/r/microsoft/dotnet/)). Image này đã chứa SDK dotnet 2.1 đã được cài đặt sẵn. Tiền tố Bionic có nghĩa là Ubuntu 18.04 (tên mã bionic) sẽ được dùng làm hệ điều hành cho container. Bằng cách thay đổi tiền tố, có thể thay đổi hệ điều hành nền (ví dụ: stretch -- Debian 9, alpine -- Alpine Linux). Trong trường hợp đó, sẽ cần chỉnh sửa nội dung tệp Docker (ví dụ, đổi 'apt-get' thành 'yum').
``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build:

```
2. Cập nhật cơ sở dữ liệu các gói có sẵn và cài đặt gói apt-utils.
``` csharp

 RUN apt-get update -y && apt-get install -y apt-utils

```
3. Cài đặt các gói 'libgdiplus' và 'libc6-dev' mà thư viện System.Drawing.Common yêu cầu.
``` csharp

 RUN apt-get install -y libgdiplus && apt-get install -y libc6-dev

```
4. Khai báo thư mục /slides-src làm điểm gắn kết, chúng ta sẽ sử dụng để cung cấp quyền truy cập vào thư mục nguồn slide-net trên máy chủ.
``` csharp

 VOLUME /slides-src

```
5. Đặt slides-src làm thư mục làm việc bên trong container.
``` csharp

 WORKDIR /slides-src

```
6. Khai báo một lệnh mặc định sẽ được chạy khi container khởi động nếu không có lệnh cụ thể được chỉ định.
``` csharp

 CMD ./build/netcore.linux.tests.sh

```

Theo các hướng dẫn trong tệp Docker, hình ảnh container kết quả sẽ có OS Ubuntu 18.04, dotnet-sdk, các gói libgdiplus và libc6-dev đã được cài đặt sẵn. Ngoài ra, image này sẽ có một điểm gắn kết và một lệnh mặc định được định sẵn khi chạy.

Để xây dựng một image bằng tệp Docker này, bạn cần vào thư mục docker slides-netuil và thực thi:

``` csharp

 $ docker build -f Dockerfile-Ubuntu18_04_apt_get_libgdiplus -t ubuntu18_04_apt_get_libgdiplus .

```

- *-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus* -- tùy chọn chỉ định tệp Docker sẽ sử dụng.
- *-t ubuntu18_04_apt_get_libgdiplus* -- chỉ định thẻ (tên) cho image kết quả.
- *'.'* -- chỉ định ngữ cảnh cho Docker. Trong trường hợp của chúng tôi, ngữ cảnh là thư mục hiện tại và nó trống — vì chúng tôi chọn cung cấp nguồn slides-net làm điểm gắn kết (điều này cho phép chúng tôi không phải xây dựng lại image Docker mỗi khi có thay đổi trong nguồn).

Kết quả thực thi sẽ trông như sau:

``` csharp

 Successfully built 62dd34ddc142

Successfully tagged ubuntu18_04_apt_get_libgdiplus:latest

```

Để chắc chắn rằng image mới đã được thêm vào kho lưu trữ image cục bộ:

``` csharp

 $ docker images

\----

REPOSITORY                      TAG                 IMAGE ID            CREATED             SIZE

ubuntu18_04_apt_get_libgdiplus   latest              62dd34ddc142        2 minutes ago         1.78GB

```

Khi image đã sẵn sàng, chúng ta có thể chạy nó bằng lệnh sau:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest

```

- *-it* -- chỉ định lệnh sẽ chạy ở chế độ tương tác, cho phép chúng ta xem đầu ra và nhập dữ liệu.
- *-v `pwd`/../../:/slides-src* -- chỉ định thư mục cho điểm gắn kết đã định sẵn — vì thư mục làm việc hiện tại là slides-netuildocker thì thư mục slides-src trong container sẽ trỏ tới thư mục slides-net trên máy chủ. `pwd` được dùng để chỉ định đường dẫn tương đối.
- *--add-host dev.slides.external.tool.server:192.168.1.48* -- sửa đổi file hosts của container để phân giải URL dev.slides.external.tool.server.
- *ubuntu1804aptgetlibgdiplus:latest* -- chỉ định image sẽ chạy container.

Kết quả của lệnh trên sẽ là đầu ra của netcore.linux.tests.sh (vì nó đã được định nghĩa là lệnh mặc định cho container):

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

Từ kết quả, có thể thấy các tệp log từ các bài kiểm tra Func và Regr đã được đặt vào thư mục /build-out/netstandard20/test-results/main/. Ngoài ra, có khoảng 200 bài kiểm tra thất bại tổng cộng — tất cả đều là các vấn đề hiển thị liên quan đến việc thiếu font cần thiết trên container.

Để ghi đè lệnh mặc định của container khi chạy, chúng ta có thể sử dụng lệnh sau:

``` csharp

 $ docker run -it -v pwd/../../:/slides-src --add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_apt_get_libgdiplus:latest /bin/bash

```

Vì vậy, thay vì netcore.linux.tests.sh, sẽ thực thi /bin/bash và cung cấp một phiên terminal hoạt động của container từ đó có thể chạy (./build/netcore.linux.tests.sh). Cách tiếp cận này có thể hữu ích trong các kịch bản khắc phục sự cố.

## **Cài đặt và cấu hình Docker trên Linux (make install libgdiplus)**
- Hệ điều hành: Ubuntu 18.04.
- Dockerfile: Dockerfile-Ubuntu18_04_make_libgdiplus

Hiện tại, Ubuntu chỉ chứa phiên bản 4.2 của libgdiplus trong khi phiên bản 5.6 đã có trên [trang chính thức của sản phẩm](https://github.com/mono/libgdiplus/releases). Để thử nghiệm phiên bản mới nhất của libgdiplus, chúng ta cần chuẩn bị một image với libgdiplus được biên dịch từ mã nguồn.

Hãy xem lại nội dung tệp Docker:

``` csharp

 FROM microsoft/dotnet:2.1-sdk-bionic AS build

\# xây dựng libgdiplus ổn định mới nhất

RUN apt-get update -y

RUN apt-get install -y libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev

RUN git clone -b 5.6 https://github.com/mono/libgdiplus

WORKDIR /libgdiplus

RUN ./autogen.sh

RUN make

RUN make install

RUN ln -s /usr/local/lib/libgdiplus.so /usr/lib/libgdiplus.so

\# tạo điểm gắn kết

VOLUME /slides-src

\# xây dựng và kiểm tra Aspose.Slides khi khởi động

WORKDIR /slides-src

CMD ./build/netcore.linux.tests.sh

```

Sự khác biệt duy nhất là phần *build latest stable libgdiplus*. Phần này cài đặt tất cả các công cụ cần thiết để biên dịch libgdiplus, sao chép mã nguồn, sau đó biên dịch và cài đặt chúng vào vị trí đúng. Các phần còn lại giống hệt như [Cài đặt và cấu hình Docker trên Linux (apt-get libgdiplus)](/slides/vi/net/how-to-run-aspose-slides-in-docker/#install-and-configure-docker-on-linux-apt-get-libgdiplus/).

**Lưu ý**: Đừng quên sử dụng các thẻ image (tên) khác nhau cho image kết quả trong các lệnh docker build và docker run:

``` csharp

 $ docker build \-f Dockerfile-Ubuntu18_04_apt_get_libgdiplus \-t ubuntu18_04_make_libgdiplus .

$ docker run \-it \-v pwd/../../:/slides-src \--add-host dev.slides.external.tool.server:192.168.1.48 ubuntu18_04_make_libgdiplus:latest

```

## **Cài đặt và cấu hình Docker trên Windows Server Core**
- Hệ điều hành: Ubuntu 18.04.
- Dockerfile: Dockerfile*WinServerCore*

**Lưu ý**: Cần Windows 10 Pro hoặc Windows Server 2016 để chạy các container Windows.

Thật không may, Microsoft không cung cấp image Windows Server Core có dotnet SDK đã được cài đặt, vì vậy chúng ta phải cài đặt nó bằng tay:

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
\# Lấy .NET Core SDK

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
# trả về cmd làm trình thực thi mặc định

SHELL ["cmd", "/S", "/C"]

\# In order to set system PATH, ContainerAdministrator must be used
\# Để thiết lập PATH hệ thống, cần sử dụng ContainerAdministrator

USER ContainerAdministrator

RUN setx /M PATH "%PATH%;c:/Program Files/dotnet"

USER ContainerUser

\# create mount points
\# tạo điểm gắn kết

VOLUME c:/slides-src

#build and test Aspose.Slides on start
# xây dựng và kiểm tra Aspose.Slides khi khởi động

WORKDIR c:/slides-src

CMD .\external\buildtools\nant\nant.exe -buildfile:.\build\netcore.tests.build -D:obfuscate_eaz_use_mock=true -D:slidesnet.run.func.tests=true -D:slidesnet.run.regr.tests=true

```

Image kết quả sẽ được xây dựng dựa trên image microsoft/windowsservercore:1803 được Microsoft cung cấp trên [docker hub](https://hub.docker.com/u/microsoft). Dotnet-sdk của phiên bản được chỉ định sẽ được tải xuống và giải nén; biến môi trường PATH của hệ thống sẽ được cập nhật để chứa đường dẫn đến thực thi dotnet. Dòng cuối cùng định nghĩa lệnh thực thi các bài kiểm tra func & regr trên container bằng nant.exe như hành động mặc định khi chạy container.

Lệnh để xây dựng image:

``` csharp

 docker build -f Dockerfile_WinServerCore -t winservercore_slides .

```

Lệnh để chạy image:

``` csharp

 docker run -it --cpu-count 3 --memory 8589934592 -v e:\Project\Aspose\slides-net:c:\slides-src winservercore_slides:latest

```

**Lưu ý**: Lệnh cho container Windows sử dụng 2 tham số bổ sung:

- *-cpu-count 3*
- *-memory 8589934592*

Chúng thiết lập số lõi CPU và lượng bộ nhớ có sẵn cho container. Mặc định, chỉ có 1 lõi CPU và 1 GB RAM khả dụng cho container Windows (các container Linux không có bất kỳ giới hạn nào mặc định).

Thêm vào đó, thiếu một tham số so với lệnh tương tự chúng ta dùng để chạy container Linux:

- *-add-host dev.slides.external.tool.server:192.168.1.48*

Vì container chạy trên Windows không cần external.tool.server.

Kết quả của lệnh trên sẽ trông như sau:

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