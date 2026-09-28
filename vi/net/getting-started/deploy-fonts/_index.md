---
title: Triển khai phông chữ cho Aspose.Slides trên Linux và trong Docker
linktitle: Triển khai phông chữ
type: docs
weight: 145
url: /vi/net/deploy-fonts/
keywords:
- triển khai phông chữ
- cài đặt phông chữ
- phông chữ trong Docker
- phông chữ trên Linux
- phông chữ thiếu
- thay thế phông chữ
- phông chữ lõi Microsoft
- ttf-mscorefonts-installer
- phông chữ tùy chỉnh
- phông chữ mặc định
- máy chủ
- container
- chuyển đổi PDF
- bản thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Triển khai phông chữ cho Aspose.Slides cho .NET trên máy chủ Linux và trong các container Docker: kiểm tra phông chữ nào bị thay thế, cài đặt các gói phông trên Debian, Ubuntu và Alpine, thêm các tệp phông của bạn, và đặt một phông chữ mặc định."
---
## **Tổng quan**

Aspose.Slides vẽ văn bản bằng các phông chữ có sẵn khi nó render bản thuyết trình, ví dụ khi chuyển đổi các trang slide sang PDF hoặc hình ảnh. Máy tính để bàn Windows thường có các phông chữ mà bản thuyết trình sử dụng. Các máy chủ và container Linux thường có ít phông chữ hoặc không có, vì vậy Aspose.Slides vẽ văn bản bằng một phông thay thế. Phông thay thế có hình dạng và độ rộng ký tự khác nhau, do đó các dòng có thể được ngắt khác nhau và văn bản có thể tràn ra khỏi hình dạng, và những ký tự mà phông thay thế thiếu sẽ không được vẽ đúng. Nếu không có phông nào được cài đặt, quá trình chuyển đổi sẽ dừng lại với lỗi.

Bài viết này chỉ ra cách kiểm tra các phông chữ mà Aspose.Slides thay thế, cách cài đặt phông chữ trên Debian, Ubuntu và Alpine Linux, cách thêm các tệp phông chữ của riêng bạn, và cách đặt phông chữ sẽ được sử dụng khi thiếu phông. Các ví dụ chạy trong Docker trên các hình ảnh .NET chính thức, giống như trong [Run Aspose.Slides for .NET in Docker](/slides/vi/net/how-to-run-aspose-slides-in-docker/). Các lệnh gói là các chỉ thị Dockerfile; trên máy chủ Linux, chạy các lệnh tương tự với quyền root.

Đối với API phông chữ, chẳng hạn như nhúng phông chữ vào bản thuyết trình và các quy tắc dự phòng và thay thế, xem [PowerPoint Fonts](/slides/vi/net/powerpoint-fonts/).

## **Kiểm tra các phông chữ bị thay thế**

Ứng dụng console dưới đây báo cáo các phông chữ mà Aspose.Slides thay thế trong môi trường hiện tại. Tạo một thư mục có tên *FontCheck* và thêm các tệp dưới đây vào đó.

*FontCheck.csproj* tham chiếu tới [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/), gói cho Debian và Ubuntu. Nó cũng sao chép các tệp của thư mục *fonts* tùy chọn vào đầu ra của ứng dụng; phần [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) sử dụng nó.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* thêm một hộp văn bản cho mỗi tên phông vào một slide và gán phông qua thuộc tính [LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/). Các tên phông lấy từ dòng lệnh; nếu không có đối số, ứng dụng sẽ kiểm tra Calibri, Arial và Times New Roman. Nó in ra các thư mục mà Aspose.Slides tìm kiếm phông ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)), render slide thành *output/fonts.pdf*, và in ra các thay thế được báo cáo bởi [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/). Hai bước tùy chọn ở đầu, tải thư mục *fonts* và đọc biến môi trường `DEFAULT_FONT`, được giải thích ở phần sau của bài viết.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// Các phông chữ cần kiểm tra: các đối số dòng lệnh, hoặc ba phông chữ Office phổ biến.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// Tải các tệp phông chữ từ thư mục fonts bên cạnh ứng dụng, nếu có.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// Sử dụng phông chữ được đặt trong biến môi trường DEFAULT_FONT, nếu được thiết lập, cho văn bản thiếu phông chữ.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* giữ các kết quả build cục bộ ra ngoài ngữ cảnh build:

```text
bin/
obj/
output/
```

*Dockerfile* xây dựng ứng dụng bằng hình ảnh .NET SDK và chạy nó trên hình ảnh .NET runtime. Giai đoạn runtime cài đặt `libfontconfig1`, mà Aspose.Slides.NET6.CrossPlatform yêu cầu, và các phông DejaVu. [Run Aspose.Slides for .NET in Docker](/slides/vi/net/how-to-run-aspose-slides-in-docker/) giải thích từng chỉ thị.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

Xây dựng hình ảnh và chạy kiểm tra:

```bash
docker build -t font-check .
docker run --rm font-check
```

Hình ảnh chỉ có các phông DejaVu, vì vậy cả ba phông đều được thay thế bằng DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Để kiểm tra các phông của bản thuyết trình riêng của bạn, truyền tên phông chúng làm đối số, ví dụ `docker run --rm font-check "Segoe UI" Consolas`. Để sao chép *output/fonts.pdf* ra khỏi container, sử dụng các lệnh trong [Copy the Output to Your Machine](/slides/vi/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Cài đặt phông chữ trên Debian và Ubuntu**

### **Microsoft Core Fonts**

Gói `ttf-mscorefonts-installer` tải xuống và cài đặt các phông chữ lõi của Microsoft cho web, bao gồm Arial, Times New Roman, Courier New, Verdana, Georgia và Trebuchet MS. Các phông chữ này được cấp phép theo thỏa thuận giấy phép người dùng cuối (EULA) của Microsoft, và gói chỉ cài đặt chúng sau khi EULA được chấp nhận. Một bản build Docker không thể trả lời lời nhắc, vì vậy trình cài đặt sẽ từ chối EULA và không cài đặt phông, trong khi `apt-get install` vẫn báo thành công. Chấp nhận EULA bằng `debconf-set-selections` **trước** khi gói được cài đặt.

Trong *Dockerfile*, thay thế chỉ thị `RUN` cài các gói trong giai đoạn runtime bằng:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Xây dựng lại hình ảnh và chạy lại kiểm tra với cùng hai lệnh. Arial và Times New Roman bây giờ đã được cài đặt:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, phông mặc định của một bản thuyết trình mà Aspose.Slides tạo, không phải là một trong các phông lõi, vì vậy nó vẫn bị thay thế. Xem [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Trên Debian, gói nằm trong thành phần kho `contrib`, mà các hình ảnh Debian không bật; các hình ảnh .NET 8 và .NET 9 mặc định dựa trên Debian 12. Bật `contrib` trong cùng một chỉ thị:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Các hình ảnh .NET 10 dựa trên Ubuntu đã bật `multiverse`, thành phần Ubuntu chứa gói này.

### **Các gói phông chữ khác**

Debian và Ubuntu cũng đóng gói các phông chữ có giấy phép tự do, ví dụ:

| Gói | Phông chữ |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif và Mono, với các chỉ số giống Arial, Times New Roman và Courier New |
| `fonts-crosextra-carlito` | Carlito, với các chỉ số giống Calibri |
| `fonts-crosextra-caladea` | Caladea, với các chỉ số giống Cambria |

Cài đặt chúng bằng `apt-get install` trong cùng một chỉ thị `RUN`. Aspose.Slides.NET6.CrossPlatform không áp dụng các bí danh phông của cấu hình phông Linux: khi `fonts-liberation` được cài, văn bản trong Arial vẫn được vẽ bằng phông thay thế chung, không phải Liberation Sans. Để sử dụng một phông tương thích chỉ số thay cho phông thiếu, đặt nó làm [phông mặc định](#set-a-default-font-for-missing-fonts) hoặc thêm một [quy tắc thay thế phông](/slides/vi/net/font-substitution/).

## **Thêm các tệp phông chữ của riêng bạn**

Các phông chữ mà các bản phân phối không đóng gói, chẳng hạn như phông của tổ chức bạn hoặc các phông khác mà bạn có giấy phép sử dụng trên máy chủ, có thể được thêm dưới dạng tệp phông. Đặt các tệp phông, ví dụ các tệp *.ttf*, trong một thư mục có tên *fonts* bên trong thư mục *FontCheck*. Các ví dụ dưới đây sử dụng các tệp của Carlito, một phông có cùng chỉ số với Calibri, bạn có thể tải xuống từ [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Cài đặt phông vào thư mục phông hệ thống**

Aspose.Slides đọc các phông trong các thư mục được in trên dòng `Font folders`. Để cài phông của bạn cho mọi ứng dụng trong hình ảnh, sao chép chúng vào */usr/local/share/fonts*, thư mục cho các phông được cài đặt cục bộ. Thêm chỉ thị này vào giai đoạn runtime của *Dockerfile*, sau chỉ thị `RUN` cài các gói:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **Tải phông từ thư mục ứng dụng**

Thay vì cài phông trong hình ảnh, bạn có thể đóng gói chúng cùng với ứng dụng và tải chúng bằng [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/). Khi đó các phông chỉ có sẵn cho Aspose.Slides và được triển khai cùng với ứng dụng. *FontCheck* làm như vậy: *FontCheck.csproj* sao chép thư mục *fonts* vào đầu ra của ứng dụng, và *Program.cs* truyền thư mục đó cho `LoadExternalFonts` trước khi tạo bản thuyết trình. [Custom Font](/slides/vi/net/custom-font/) mô tả các cách khác để cung cấp phông, chẳng hạn như tải chúng từ bộ nhớ.

Xây dựng lại hình ảnh, sau đó kiểm tra Calibri và Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Thư mục ứng dụng bây giờ xuất hiện trong các thư mục phông, và Carlito không còn bị thay thế nữa:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Đặt phông mặc định cho các phông chữ thiếu**

Khi một phông chữ thiếu, Aspose.Slides sẽ sử dụng một phông thay thế do nó tự chọn. Để tự chọn, đặt thuộc tính [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/) của [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) và truyền các tùy chọn này vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). *FontCheck* đọc tên phông từ biến môi trường `DEFAULT_FONT`. Với Carlito đã được tải, sử dụng nó cho các phông thiếu:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri giờ được vẽ bằng Carlito, các ký tự của nó có cùng độ rộng như Calibri, vì vậy văn bản giữ nguyên các ngắt dòng:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

Phông mặc định thay thế mọi phông thiếu. Để ánh xạ các phông riêng lẻ, chẳng hạn Arial sang Liberation Sans và Calibri sang Carlito, sử dụng [quy tắc thay thế phông](/slides/vi/net/font-substitution/). Các quy tắc thay đổi đầu ra được render, nhưng `GetSubstitutions` không phản ánh chúng, vì vậy hãy kiểm tra các phông trong tệp đầu ra thay vì. Đối với văn bản Châu Á, cũng đặt [DefaultAsianFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultasianfont/); xem [Default Font](/slides/vi/net/default-font/).

## **Cài đặt phông trên Alpine Linux**

Trên Alpine Linux, sử dụng gói Aspose.Slides.NET; [Run on Alpine Linux](/slides/vi/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) liệt kê các thay đổi cho dự án. Thực hiện các thay đổi tương tự cho *FontCheck*: thay thế tham chiếu gói, thêm câu lệnh `SetSwitch` vào *Program.cs*, và sử dụng giai đoạn runtime này, cũng cài đặt các phông Microsoft core:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` tải xuống và cài đặt các phông Microsoft core giống như gói Debian và Ubuntu, và EULA của chúng áp dụng theo cùng cách. `fc-cache` cập nhật bộ nhớ cache phông.

Với Aspose.Slides.NET trên Linux, thư viện cấu hình phông (fontconfig) chọn phông thay thế cho phông thiếu, và `GetSubstitutions` không báo cáo nó, vì vậy *FontCheck* in ra `No font substitutions.` Để biết phông nào được dùng cho một tên phông, hỏi fontconfig trong container:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Với các phông Microsoft core đã được cài, Arial được dùng cho Arial:

```text
Arial.ttf: "Arial" "Regular"
```

Nếu không có chúng, khi chỉ thị `RUN` chỉ cài `icu-libs libgdiplus font-dejavu`, cùng một lệnh sẽ in:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **Câu hỏi thường gặp**

**Tại sao bản thuyết trình trông khác khi được chuyển đổi trên máy chủ?**

Máy chủ không có các phông chữ mà bản thuyết trình sử dụng, vì vậy Aspose.Slides vẽ văn bản bằng một phông thay thế có độ rộng ký tự khác. Chạy *FontCheck* với các tên phông của bản thuyết trình để xem phông nào bị thay thế, sau đó cài đặt các phông đó hoặc tải chúng từ thư mục ứng dụng.

**Bản build đã cài đặt ttf-mscorefonts-installer, nhưng Arial vẫn bị thay thế. Tại sao?**

EULA chưa được chấp nhận trước khi gói được cài, vì vậy trình cài bỏ qua các phông. Thêm lệnh `debconf-set-selections` trước `apt-get install`, như shown trong [Microsoft Core Fonts](#microsoft-core-fonts), và xây dựng lại hình ảnh.

**Máy tính mở PDF có cần các phông chữ không?**

Không. Trong các ví dụ này, PDF chứa các phông đã được dùng để vẽ văn bản, vì vậy nó trông giống nhau trên bất kỳ máy tính nào. Các phông chỉ cần có ở nơi Aspose.Slides render bản thuyết trình.