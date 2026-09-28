---
title: "Chạy Aspose.Slides cho .NET trong Docker"
linktitle: Docker
type: docs
weight: 140
url: /vi/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Container Docker
- xây dựng đa giai đoạn
- image container
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- phông chữ
- chuyển đổi PDF
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xây dựng và chạy một ứng dụng console Aspose.Slides cho .NET trong Docker: Dockerfile đa giai đoạn trên các image .NET chính thức, các thư viện và phông chữ Linux mà nó cần, và cách sao chép các tệp được tạo ra tới máy của bạn."
---
## **Tổng quan**

Bài viết này hướng dẫn cách chạy Aspose.Slides for .NET trong một container Docker. Bạn sẽ tạo một ứng dụng console nhỏ tạo một bản trình chiếu với một hộp văn bản và chuyển đổi nó sang PDF, đóng gói nó bằng Dockerfile đa giai đoạn trên các ảnh .NET chính thức của Microsoft, chạy nó và sao chép các tệp được tạo ra tới máy của bạn. Bài viết cũng liệt kê các thư viện Linux và phông chữ mà Aspose.Slides cần trong container và kết thúc với một biến thể cho Alpine Linux.

Bạn chỉ cần Docker trên máy của mình. .NET SDK là một phần của image build, vì vậy bạn không cần cài đặt nó. Để cài đặt Docker, xem [Nhận Docker](https://docs.docker.com/get-started/get-docker/).

## **Chọn Gói và Image Cơ Sở**

Các image container .NET 10 mặc định dựa trên Ubuntu 24.04. Trên các image này, sử dụng gói [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Gói này yêu cầu thư viện `fontconfig`, và image runtime .NET không chứa thư viện đó cũng như bất kỳ phông chữ nào, vì vậy Dockerfile trong bài viết này sẽ cài đặt cả hai.

Aspose.Slides.NET6.CrossPlatform không chạy trên Alpine Linux. Đối với các image dựa trên Alpine, sử dụng gói [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) kèm `libgdiplus`, như mô tả trong [Chạy trên Alpine Linux](#run-on-alpine-linux). [Cài đặt](/slides/vi/net/installation/) so sánh hai gói.

## **Tạo Dự Án**

Tạo một thư mục có tên *HelloSlidesDocker* và thêm ba tệp sau vào nó.

*HelloSlidesDocker.csproj* mô tả một ứng dụng console cho .NET 10, phiên bản của các image container được sử dụng bên dưới, và tham chiếu đến Aspose.Slides.NET6.CrossPlatform. Đặt phiên bản gói thành phiên bản mới nhất được liệt kê trên [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* tạo một [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), thêm một hình chữ nhật chứa văn bản vào slide đầu tiên, và lưu bản trình chiếu hai lần bằng phương thức [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/): dưới dạng PPTX và PDF. Cả hai tệp đều được lưu vào thư mục *output* trong thư mục làm việc. Ứng dụng sau đó liệt kê các phông chữ đã được thay thế trong quá trình render PDF, sử dụng [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/), để bạn có thể xem container có các phông chữ mà bản trình chiếu sử dụng hay không.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* giữ lại các thư mục *bin* và *obj* của một bản build cục bộ, và đầu ra của các lần chạy trước, ra khỏi ngữ cảnh build Docker, để image chỉ được xây dựng từ các tệp nguồn.

```text
bin/
obj/
output/
```

## **Viết Dockerfile**

Thêm một tệp có tên *Dockerfile* vào cùng thư mục:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

Tệp này có hai giai đoạn:

- **The build stage** bắt đầu từ image .NET SDK. Nó sao chép tệp dự án và khôi phục các gói NuGet trước, vì vậy Docker sẽ tái sử dụng lớp này miễn là tệp dự án không thay đổi. Sau đó nó sao chép mã nguồn và xuất bản ứng dụng tới */app*.
- **The runtime stage** bắt đầu từ image .NET runtime nhỏ hơn, không có SDK, và chỉ sao chép ứng dụng đã xuất bản. Nó cài đặt hai gói:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform tải thư viện này khi khởi động. Nếu không có, ứng dụng dừng lại với `DllNotFoundException` chỉ ra `libfontconfig.so.1`.
  - `fonts-dejavu-core`: image runtime không có phông chữ nào, và Aspose.Slides cần ít nhất một phông chữ đã cài đặt để vẽ văn bản; nếu không, quá trình chuyển đổi dừng lại với `InvalidOperationException: Cannot find any fonts installed on the system.` Văn bản bằng phông chưa cài đặt sẽ được vẽ bằng phông thay thế. Các phông DejaVu là một bộ phông nhỏ giúp hiển thị văn bản; để hiển thị bản trình chiếu với các phông được thiết kế, xem [Deploy Fonts](/slides/vi/net/deploy-fonts/).

`--no-install-recommends` và việc xóa danh sách gói giúp giữ image nhỏ gọn. Các dòng cuối tạo thư mục *output*, cấp quyền cho người dùng không phải root `app` mà các image .NET chính thức định nghĩa (ID người dùng nằm trong biến `APP_UID`), và chạy ứng dụng dưới người dùng đó.

Đối với một ứng dụng ASP.NET Core, bắt đầu giai đoạn runtime từ `mcr.microsoft.com/dotnet/aspnet:10.0` thay vì. Nó dựa trên cùng một image Ubuntu, vì vậy các gói cần thiết vẫn giống.

## **Xây Dựng và Chạy Container**

Mở một terminal trong thư mục *HelloSlidesDocker*. Xây dựng image, sau đó chạy một container từ nó:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Lần build đầu tiên sẽ tải các image cơ sở và các gói NuGet, vì vậy mất thời gian hơn các lần build sau. Container chạy ứng dụng và dừng lại. Nó in ra:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Dòng đầu tiên cho thấy văn bản sử dụng phông Calibri, phông mặc định của một bản trình chiếu mới, và Calibri không được cài đặt trong image, vì vậy Aspose.Slides đã vẽ văn bản bằng DejaVu Sans. Văn bản trong PDF là văn bản thực, có thể chọn được với phông đó. Nếu không có giấy phép, Aspose.Slides cũng sẽ thêm dấu bản quyền đánh giá vào mỗi slide mà nó lưu; xem [Licensing](/slides/vi/net/licensing/).

## **Sao Chép Đầu Ra Vào Máy của Bạn**

Các tệp nằm trong thư mục */app/output* của container đã dừng. Sao chép chúng vào một thư mục *output* trên máy của bạn, sau đó xóa container:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Hai lệnh này hoạt động tương tự trong Bash, PowerShell và Windows Command Prompt.

Trên Linux, bạn có thể thay vì vậy gắn một thư mục từ máy của mình vào container, để ứng dụng ghi trực tiếp các tệp vào đó:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Tùy chọn `--user` chạy ứng dụng với ID người dùng và nhóm của bạn, vì vậy nó có thể ghi vào thư mục bạn đã tạo và các tệp thuộc về bạn. `--rm` xóa container khi nó dừng.

## **Chạy trên Alpine Linux**

Để chạy ứng dụng trong một image dựa trên Alpine, chuyển sang gói Aspose.Slides.NET và thay đổi giai đoạn runtime. Giai đoạn build vẫn giữ nguyên.

1. Trong *HelloSlidesDocker.csproj*, thay thế tham chiếu gói:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. Trong *Program.cs*, thêm câu lệnh này sau các chỉ thị `using`, trước cuộc gọi Aspose.Slides đầu tiên. Nó kích hoạt hỗ trợ System.Drawing cho Linux mà Aspose.Slides.NET sử dụng:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. Trong *Dockerfile*, thay thế giai đoạn runtime (tất cả từ dòng `FROM` thứ hai) bằng:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

Giai đoạn Alpine cài đặt ba gói và thay đổi một thiết lập:
- `libgdiplus` là thư viện đồ họa mà Aspose.Slides.NET sử dụng trên Linux.
- `font-dejavu` cung cấp các phông chữ. Nếu không có phông nào, quá trình chuyển đổi dừng lại với `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` và `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` cung cấp dữ liệu văn hoá. Các image .NET trên Alpine chạy ở chế độ không toàn cục mặc định, và trong chế độ này Aspose.Slides dừng lại với `CultureNotFoundException` cho `en-US`.

Xây dựng, chạy và sao chép đầu ra bằng các lệnh như trên. Trên image này, ứng dụng chỉ in ra dòng `Saved`: với Aspose.Slides.NET trên Linux, fontconfig chọn phông thay thế cho phông bị thiếu, và [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) không liệt kê nó. [Deploy Fonts](/slides/vi/net/deploy-fonts/) cho biết cách kiểm tra phông nào đã được sử dụng.

## **Câu Hỏi Thường Gặp**

**Ứng dụng dừng lại với lỗi "Unable to load shared library 'libaspose.slides.drawing.capi…'". Thiếu gì?**

Trên các image Ubuntu và Debian, cần gói `libfontconfig1`; thông báo liệt kê `libfontconfig.so.1` là tệp không thể mở. Trên Alpine Linux, thông báo có nghĩa là đang sử dụng Aspose.Slides.NET6.CrossPlatform; hãy chuyển sang Aspose.Slides.NET như mô tả trong [Chạy trên Alpine Linux](#run-on-alpine-linux).

**Tại sao văn bản trong PDF lại hiển thị phông chữ khác so với PowerPoint?**

Các phông chữ mà bản trình chiếu sử dụng không được cài đặt trong image, vì vậy Aspose.Slides vẽ văn bản bằng phông thay thế. Đầu ra của ứng dụng liệt kê mỗi phông đã được thay thế. [Deploy Fonts](/slides/vi/net/deploy-fonts/) giải thích cách cài đặt phông trong image hoặc tải chúng từ thư mục ứng dụng.

**Có cần .NET SDK trên máy của tôi không?**

Không. Giai đoạn build biên dịch ứng dụng bên trong image SDK. Bạn chỉ cần SDK nếu muốn xây dựng và chạy ứng dụng ngoài Docker; xem [Cài đặt](/slides/vi/net/installation/).