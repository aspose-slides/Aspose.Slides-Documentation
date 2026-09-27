---
title: Cài đặt
type: docs
weight: 70
url: /vi/nodejs-net/installation/
keywords:
  - tải xuống Aspose.Slides
  - cài đặt Aspose.Slides
  - cài đặt Aspose.Slides
  - Windows
  - macOS
  - Linux
  - JavaScript
  - Node.js
description: "Cài đặt Aspose.Slides cho Node.js qua .NET từ npm trên Windows hoặc Linux: các yêu cầu trước, việc ghi đè edge-js, một lần khôi phục NuGet, và một chương trình đầu tiên tạo bản thuyết trình."
---
## **Tổng quan**

Aspose.Slides for Node.js via .NET là gói npm `aspose.slides.via.net`. Nó chạy thư viện Aspose.Slides .NET trong Node.js thông qua cầu nối [edge-js](https://github.com/agracio/edge-js), vì vậy một cài đặt hoạt động cần cả Node.js và .NET.

Bài viết này đưa bạn từ một máy sạch tới một chương trình đầu tiên tạo một bản thuyết trình. Có bốn bước: tạo dự án với một override cho edge-js, cài đặt gói từ npm, khôi phục các phụ thuộc .NET của gói một lần, và chạy script của bạn từ thư mục dự án.

## **Yêu cầu trước**

- **Node.js 22 hoặc 24 LTS**, bản xây dựng x64, từ [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 trở lên**, từ [dotnet.microsoft.com](https://dotnet.microsoft.com/download). Chỉ có runtime .NET không đủ: bước khôi phục phía dưới cần SDK, và cầu nối cũng cần khi script của bạn chạy. Chạy `dotnet --list-sdks` để kiểm tra các SDK đã được cài đặt.
- **Chỉ trên Linux**:
  - các công cụ biên dịch `python3`, `make` và `g++`, vì npm biên dịch edge-js trong quá trình cài đặt trên Linux;
  - thư viện fontconfig, mà thư viện vẽ gốc của Aspose.Slides tải lên.

  Trên Debian, các gói này là `python3`, `make`, `g++` và `libfontconfig1`.

Các bước trong bài viết này đã được kiểm tra trên các nền tảng sau:

| Nền tảng | Kết quả |
|---|---|
| Windows x64 với Node.js 22 hoặc 24 | Hoạt động. Được kiểm tra với Microsoft Visual C++ Redistributable đã được cài đặt. |
| Linux x64 với Node.js 22 hoặc 24, nơi OpenSSL hệ thống thuộc cùng dòng phát hành với OpenSSL được tích hợp trong Node.js, chẳng hạn Debian 13 | Hoạt động. |
| Linux nơi hai phiên bản OpenSSL khác nhau, chẳng hạn Debian 12 | Node.js bị sập với lỗi segmentation fault khi tạo bản thuyết trình. |
| macOS | Chưa được xác minh. |

Trên Linux, hãy so sánh hai phiên bản trước khi bắt đầu. Lệnh đầu tiên in ra phiên bản OpenSSL được tích hợp trong Node.js; lệnh thứ hai in ra phiên bản hệ thống. Sử dụng hệ thống mà cả hai đều bắt đầu bằng cùng một số major và minor, ví dụ `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

Nếu lệnh `openssl` không được tìm thấy, hãy cài đặt gói `openssl` trước.

## **Tạo một dự án**

Tạo một thư mục cho dự án của bạn, khởi tạo nó, và thêm một override cho npm biết nên cài đặt bản phát hành edge-js nào:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

Gói yêu cầu một bản edge-js cũ hơn mà các binary Windows dựng sẵn chỉ hỗ trợ tới Node.js 20, vì vậy nếu không có override, script đầu tiên trên Windows sẽ dừng với thông báo “The edge module has not been pre-compiled for node.js version”. Lệnh này ghi override vào phần `overrides` của `package.json`; hãy thêm nó trước khi cài đặt gói.

## **Cài đặt gói**

Cài đặt Aspose.Slides for Node.js via .NET từ npm:

```sh
npm install aspose.slides.via.net
```

Trong quá trình cài đặt, gói sao chép các thư viện vẽ gốc (các tệp có tên chứa `aspose.slides.drawing.capi`) vào thư mục dự án, cạnh `package.json`.

Gói cũng được phát hành dưới dạng file ZIP trên [releases.aspose.com](https://releases.aspose.com/slides/vi/nodejs-net/). Bài viết này chỉ đề cập tới cài đặt từ npm.

## **Khôi phục các phụ thuộc .NET**

Gói chứa các assembly Aspose.Slides .NET, nhưng không có 20 gói NuGet mà các assembly này phụ thuộc. Khi chạy, .NET tìm chúng trong bộ nhớ đệm gói NuGet: `%USERPROFILE%\.nuget\packages` trên Windows, `~/.nuget/packages` trên Linux, hoặc thư mục được thiết lập trong biến môi trường `NUGET_PACKAGES`. Nếu thiếu, script đầu tiên sẽ dừng với thông báo “assembly specified in the dependencies manifest was not found”.

Để điền vào bộ nhớ đệm, tạo một thư mục tên `deps` trong thư mục dự án và lưu tệp sau vào đó với tên `deps.csproj`. Mỗi mục `PackageDownload` tải về một gói tại đúng phiên bản trong ngoặc; không có gì được biên dịch.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

Sau đó khôi phục từ thư mục dự án:

```sh
dotnet restore deps/deps.csproj
```

Bạn chỉ cần thực hiện bước này một lần trên mỗi máy, không phải một lần cho mỗi dự án: các gói sẽ ở trong bộ nhớ đệm NuGet, và các dự án sau trên cùng máy sẽ sử dụng chúng. Sau khi khôi phục, bạn có thể xóa thư mục `deps`.

## **Chạy chương trình đầu tiên**

Tạo một tệp tên `hello.js` trong thư mục dự án với mã sau. Nó tạo một bản thuyết trình, thêm một hình chữ nhật chứa văn bản “Hello, World!” vào slide đầu tiên, và lưu kết quả dưới dạng `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Một bản thuyết trình mới chứa một slide trống.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Vị trí và kích thước được tính bằng điểm (1/72 inch): x, y, chiều rộng, chiều cao.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Giải phóng đối tượng .NET hỗ trợ cho bản thuyết trình.
    presentation.dispose();
}
```

Chạy nó từ thư mục dự án:

```sh
node hello.js
```

Script in ra `Saved hello.pptx`. Mở `hello.pptx` để xem một slide có hình chữ nhật được tô màu chứa văn bản. Khi không có giấy phép, Aspose.Slides cũng sẽ thêm một dấu nước đánh giá; xem [Evaluate Aspose.Slides](/slides/vi/nodejs-net/evaluate-aspose-slides/) và [Licensing](/slides/vi/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
Chạy các script của bạn từ thư mục dự án, thư mục chứa `package.json`. Các đường dẫn tương đối như `hello.pptx` sẽ được giải quyết dựa trên thư mục hiện tại, và trên một số máy một script được khởi chạy từ thư mục khác sẽ không tạo được bản thuyết trình.
{{% /alert %}}

API JavaScript phản ánh Aspose.Slides for .NET: các lớp giữ nguyên tên .NET, thuộc tính và phương thức sử dụng camelCase (`Slides` trở thành `slides`, `AddAutoShape` trở thành `addAutoShape`), và các mục trong collection được đọc bằng `get(index)`. Không có tài liệu tham khảo API riêng cho gói này, vì vậy hãy sử dụng [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/vi/net/) để xem chi tiết lớp và thành viên, ví dụ như [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/vi/net/aspose.slides/shapecollection/addautoshape/).

## **Câu hỏi thường gặp**

**“The edge module has not been pre-compiled for node.js version” có nghĩa là gì?**

npm đã cài đặt bản edge-js cũ hơn mà gói yêu cầu. Thêm override từ [Tạo một dự án](#create-a-project) và chạy lại `npm install`.

**“assembly specified in the dependencies manifest was not found” có nghĩa là gì?**

Các phụ thuộc .NET chưa có trong bộ nhớ đệm NuGet. Lần chạy cùng cũng báo “edge.initializeClrFunc is not a function”. Thực hiện [Khôi phục các phụ thuộc .NET](#restore-the-net-dependencies) một lần, sau đó chạy lại script của bạn.

**“The edge native module is not available” có nghĩa là gì trên Linux?**

edge-js đã không được biên dịch trong quá trình `npm install`, ví dụ vì thiếu `python3`, `make` hoặc `g++`. npm không báo lỗi này. Cài đặt các công cụ biên dịch, sau đó chạy `npm rebuild edge-js` trong thư mục dự án.

**Tại sao việc tạo bản thuyết trình thất bại với lỗi “Error” trống?**

Trên Linux, kiểm tra thư viện fontconfig đã được cài đặt (`libfontconfig1` trên Debian); nếu không, thư viện vẽ gốc không thể tải. Trên bất kỳ hệ thống nào, cũng kiểm tra rằng bạn chạy script từ thư mục dự án.

**Tại sao Node.js bị sập với segmentation fault trên Linux?**

OpenSSL hệ thống và OpenSSL được tích hợp trong Node.js đến từ các dòng phát hành khác nhau. So sánh chúng như trong mục [Yêu cầu trước](#prerequisites) và sử dụng một bản phân phối hoặc bản Node.js mà chúng khớp nhau.

**Có cần thực hiện khôi phục NuGet cho mỗi dự án không?**

Không. Việc khôi phục chỉ điền bộ nhớ đệm NuGet cho tài khoản người dùng của bạn, và mọi dự án trên máy đó sẽ sử dụng cùng một bộ nhớ đệm.