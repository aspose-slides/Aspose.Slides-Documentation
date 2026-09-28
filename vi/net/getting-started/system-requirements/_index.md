---
title: Yêu cầu hệ thống
type: docs
weight: 60
url: /vi/net/system-requirements/
keywords:
- yêu cầu hệ thống
- nền tảng được hỗ trợ
- các framework mục tiêu
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Kiểm tra những gì Aspose.Slides for .NET cần trước khi cài đặt: các framework mà mỗi gói NuGet nhắm tới, hệ điều hành và bộ xử lý được hỗ trợ, và các thư viện cùng phông chữ mà Linux yêu cầu."
---
## **Giới thiệu**

Aspose.Slides for .NET là một thư viện độc lập: nó không cần Microsoft PowerPoint hay Microsoft Office. Nó được công bố dưới dạng hai gói NuGet, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) và [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). Cả hai cung cấp cùng các namespace và lớp Aspose.Slides; chúng khác nhau ở framework mục tiêu và cách chúng vẽ slide, quyết định nơi chúng chạy và những gì chúng cần.

Bài viết này liệt kê các phiên bản .NET và nền tảng mà mỗi gói hỗ trợ và các thư viện hệ thống và phông chữ mà Linux cần, và kết thúc bằng một chương trình ngắn kiểm tra môi trường của bạn. Để thêm một gói vào dự án, xem [Installation](/slides/vi/net/installation/).

## **Các phiên bản .NET được hỗ trợ**

Mỗi gói chứa một bản dựng của Aspose.Slides cho mỗi framework mục tiêu, và NuGet chọn bản dựng phù hợp với framework mục tiêu của dự án của bạn.

| Gói | Các framework mục tiêu trong gói | Dự án của bạn có thể mục tiêu |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 hoặc sau này; .NET 6 hoặc sau này, bao gồm .NET 8, .NET 9 và .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 hoặc sau này, bao gồm .NET 8, .NET 9 và .NET 10 |

Bản dựng `netstandard2.0` cho phép một thư viện lớp .NET Standard 2.0 tham chiếu Aspose.Slides.NET. Ứng dụng sử dụng thư viện đó sẽ chạy bản dựng phù hợp với framework mục tiêu của chính ứng dụng: ví dụ, một ứng dụng .NET 8 sẽ chạy bản dựng `net6.0`.

## **Hệ điều hành và bộ xử lý được hỗ trợ**

**Aspose.Slides.NET** chứa chỉ mã quản lý độc lập với bộ xử lý (AnyCPU), vì vậy nó chạy trên kiến trúc bộ xử lý của runtime .NET tải nó. Nó vẽ slide thông qua thư viện System.Drawing.Common của Microsoft, mà Microsoft chỉ hỗ trợ **trên Windows**. Trên Linux, Aspose.Slides.NET do đó cần thư viện `libgdiplus` và một công tắc khởi động, mô tả trong [Linux](#linux). Nó chạy trên các bản phân phối Linux cung cấp `libgdiplus`, chẳng hạn Debian, Ubuntu và Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** vẽ slide bằng cơ chế đồ họa riêng. Cơ chế này là một thư viện native mà gói chứa một bản dựng cho mỗi nền tảng, vì vậy gói chỉ chạy trên các nền tảng sau:

| Hệ điều hành | Bộ xử lý | Ghi chú |
|---|---|---|
| Windows | x86, x64 | Windows trên ARM64 không được hỗ trợ. |
| Linux | x64, ARM64 | Yêu cầu glibc 2.23 hoặc sau này trên x64 và glibc 2.39 hoặc sau này trên ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform không chạy trên Alpine Linux hoặc các bản phân phối dựa trên musl thay vì glibc, hoặc trên các bản phân phối có glibc cũ hơn, chẳng hạn CentOS 7. Sử dụng Aspose.Slides.NET trên các hệ thống đó.

Trên Windows, thư viện native của Aspose.Slides.NET6.CrossPlatform sử dụng runtime Microsoft Visual C++ (*MSVCP140.dll* và *VCRUNTIME140.dll*, cộng với *VCRUNTIME140_1.dll* trên x64). Nếu các tệp này thiếu trên máy đích, cài đặt [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

Cả hai gói đều cần các thư viện hệ thống bổ sung trên Linux. Nếu không, ví dụ đầu tiên trong [Create Presentations](/slides/vi/net/create-presentation/) sẽ thất bại với một ngoại lệ thay vì lưu file. Các lệnh dưới đây dành cho Debian và Ubuntu; trên các bản phân phối này, mỗi thư viện cũng kéo theo các phông DejaVu (`fonts-dejavu-core`), vì vậy văn bản được hiển thị mà không cần gói phông thêm.

### **Aspose.Slides.NET6.CrossPlatform**

Thư viện Linux của gói yêu cầu thư viện `fontconfig`:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

Nếu không, việc tạo một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) sẽ thất bại với `TypeInitializationException` mà ngoại lệ bên trong `DllNotFoundException` báo rằng `libfontconfig.so.1` không thể mở.

Các image cơ sở tối thiểu có thể cũng không bao gồm `fontconfig`. Ví dụ, image base của AWS Lambda cho .NET 8 không chứa `fontconfig` cũng như bất kỳ phông nào. Trong một container image được xây dựng trên nó, chạy `dnf install -y fontconfig`, lệnh này cũng sẽ cài đặt phông Noto Sans.

### **Aspose.Slides.NET**

Gói này yêu cầu hai thứ trên Linux:

1. Thư viện `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. Công tắc `System.Drawing.EnableUnixSupport`, được bật ở đầu ứng dụng trước bất kỳ lời gọi Aspose.Slides nào. Trong *Program.cs* với top-level statements, đặt nó sau các chỉ thị `using`:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

Nếu không có `libgdiplus`, việc lưu một bài thuyết trình sẽ thất bại với `TypeInitializationException` mà ngoại lệ bên trong `DllNotFoundException` báo rằng không thể tải `libgdiplus`. Nếu không bật công tắc, ngoại lệ bên trong sẽ là `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
Công tắc này chỉ hoạt động với System.Drawing.Common 6, phiên bản mà Aspose.Slides.NET phụ thuộc. Microsoft đã loại bỏ nó trong System.Drawing.Common 7. Nếu dự án của bạn tham chiếu System.Drawing.Common 7 hoặc cao hơn, trực tiếp hoặc qua gói khác, Aspose.Slides.NET sẽ thất bại trên Linux với `PlatformNotSupportedException` ngay cả khi đã cài đặt `libgdiplus` và bật công tắc. Trong trường hợp đó, sử dụng Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

Trên Alpine Linux, sử dụng Aspose.Slides.NET với công tắc đã mô tả ở trên. Các image Alpine thường không có phông chữ, và `libgdiplus` một mình không cài đặt phông, vì vậy hãy cài đặt `libgdiplus` cùng với ít nhất một gói phông. Nếu không có phông, việc lưu bài thuyết trình sẽ thất bại với lỗi này:

```text
System.ArgumentException: Font '?' cannot be found.
```

**Tùy chọn 1: Phông DejaVu**

Gói khuyến nghị là `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Trên các bản phát hành Alpine hiện tại, `ttf-dejavu` cài đặt gói `font-dejavu`, cũng cài đặt `fontconfig` và các công cụ phông mà nó phụ thuộc.

**Tùy chọn 2: Phông chữ Core của Microsoft**

Nếu các bài thuyết trình của bạn sử dụng phông chữ Microsoft như Arial, Times New Roman, Courier New hoặc Verdana, cài đặt các phông chữ core của Microsoft thay thế. Bước `update-ms-fonts` tải xuống các phông chữ khi image được xây dựng, vì vậy quá trình build cần có kết nối internet:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **Hỗ trợ Quốc tế hoá**

Cả hai gói đều cần hỗ trợ quốc tế hoá .NET, mà .NET trên Linux cung cấp thông qua các thư viện ICU. Trong [globalization-invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization), việc tạo một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) sẽ thất bại với `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

Một số image container bật chế độ này. Các image runtime của .NET cho Alpine Linux (`runtime-deps`, `runtime`, và `aspnet`), chẳng hạn, đặt `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` và không bao gồm ICU. Trong một image được xây dựng trên chúng, cài đặt ICU và tắt chế độ này:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

Cũng đảm bảo rằng tệp dự án của bạn không đặt thuộc tính `InvariantGlobalization` thành `true`.

## **Kiểm tra Cài đặt của Bạn**

Để kiểm tra rằng một gói và các yêu cầu của nó đã sẵn sàng, chạy một chương trình lưu một bài thuyết trình và render một slide thành hình ảnh. Việc lưu và render sử dụng thư viện đồ họa và các phông chữ, chính là những gì các yêu cầu Linux ở trên cung cấp.

Tạo một ứng dụng console và thêm gói như mô tả trong [Installation](/slides/vi/net/installation/), thay thế nội dung của *Program.cs* bằng mã dưới đây, và chạy `dotnet run`. Nếu bạn dùng Aspose.Slides.NET trên Linux, thêm câu lệnh công tắc `System.Drawing.EnableUnixSupport` được mô tả trong [Linux](#linux) sau các chỉ thị `using`. Chương trình sử dụng top-level statements và khai báo `using`, cần C# 9 trở lên. Các dự án mục tiêu .NET 6 trở lên mặc định sử dụng phiên bản C# mới hơn; trong một dự án mục tiêu .NET Framework, thêm `<LangVersion>latest</LangVersion>` vào một `PropertyGroup` trong tệp dự án.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

Chương trình thêm một hình chữ nhật có chữ vào slide đầu tiên và lưu bài thuyết trình thành *hello.pptx* bằng phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/). Sau đó render slide bằng [GetImage](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage/) và lưu kết quả thành *hello.png* bằng [IImage.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/iimage/save/) ở định dạng [ImageFormat.Png](https://reference.aspose.com/slides/vi/net/aspose.slides/imageformat/). Hệ số phóng đại 1 render một pixel cho mỗi point, vì vậy slide mặc định 720 × 540 point trở thành ảnh 720 × 540 pixel, với chữ hiển thị bên trong hình chữ nhật. Khi không có giấy phép, cả hai tệp cũng sẽ có dấu watermark đánh giá; xem [Licensing](/slides/vi/net/licensing/). Nếu thiếu một yêu cầu nào đó, chương trình sẽ dừng với một trong các ngoại lệ được mô tả trong [Linux](#linux).

## **Công cụ Phát triển**

Bạn có thể xây dựng các ứng dụng sử dụng Aspose.Slides bằng bất kỳ công cụ nào hỗ trợ framework mục tiêu của dự án: .NET SDK và giao diện dòng lệnh `dotnet` trên Windows, Linux và macOS, hoặc Visual Studio trên Windows. [Installation](/slides/vi/net/installation/) mô tả cả hai.

## **Câu hỏi thường gặp**

**Tôi có cần cài đặt Microsoft PowerPoint để chuyển đổi và render không?**

Không, PowerPoint không bắt buộc. Aspose.Slides là một engine độc lập để [tạo](/slides/vi/net/create-presentation/), chỉnh sửa, [chuyển đổi](/slides/vi/net/convert-presentation/) và [render](/slides/vi/net/convert-powerpoint-to-png/) các bài thuyết trình.

**Tôi nên sử dụng gói nào?**

Dùng Aspose.Slides.NET trên Windows và Aspose.Slides.NET6.CrossPlatform trên Linux và macOS. Trên Alpine Linux, trên các hệ thống Linux có glibc cũ hơn các phiên bản nêu trên, và trong các dự án mục tiêu .NET Framework, dùng Aspose.Slides.NET. Chỉ thêm một trong hai gói vào dự án.

**Cần những phông chữ nào để render đúng?**

Các phông chữ được sử dụng trong bài thuyết trình, hoặc các phông thay thế phù hợp, phải có sẵn trong hệ điều hành. Trên Linux và macOS, cài đặt các gói phông mà bài thuyết trình của bạn cần để có việc render nhất quán. Trên Alpine Linux, cài đặt ít nhất một gói phông bổ sung ngoài `libgdiplus`, như mô tả trong [Alpine Linux](#alpine-linux).

**Tại sao phông chữ tùy chỉnh lại hiển thị dưới dạng dự phòng hoặc văn bản bị thiếu trên Linux?**

Nếu tệp phông có các mục bảng tên không nhất quán hoặc bị hỏng, stack khớp phông Linux (FreeType/fontconfig) có thể chọn một bản ghi không hợp lệ, gây ra việc phông không được giải quyết. Sử dụng phiên bản phông chữ có bảng tên đã được sửa hoặc cài đặt một phông thay thế đồng nhất sẽ giải quyết vấn đề.