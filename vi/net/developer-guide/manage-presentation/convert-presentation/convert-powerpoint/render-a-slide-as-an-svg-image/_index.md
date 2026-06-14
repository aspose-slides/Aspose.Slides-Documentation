---
title: Kết xuất các slide trình chiếu thành hình ảnh SVG trong .NET
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- trình chiếu sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- lưu PPT thành SVG
- lưu PPTX thành SVG
- xuất PPT sang SVG
- xuất PPTX sang SVG
- kết xuất slide
- chuyển đổi slide
- xuất slide
- hình ảnh vector
- PowerPoint
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách kết xuất các slide PowerPoint thành hình ảnh SVG bằng Aspose.Slides cho .NET. Hình ảnh chất lượng cao với các ví dụ mã C# đơn giản."
---
## **Tổng quan**

Bài viết này giải thích cách kết xuất các slide trình chiếu dưới dạng hình ảnh SVG bằng Aspose.Slides. Nó mô tả định dạng SVG và các lợi thế của nó, bao gồm khả năng mở rộng, khả năng truy cập và tính phù hợp cho phát triển web.

Bạn sẽ học cách tải tệp trình chiếu, duyệt qua các slide và lưu mỗi slide dưới dạng tệp SVG riêng biệt. Bài viết bao gồm các định dạng trình chiếu PowerPoint và OpenDocument, bao gồm PPT, PPTX, ODP và PPS, và chỉ ra cách thực hiện chuyển đổi một cách lập trình bằng lớp `Presentation` và phương thức `WriteAsSvg`.

## **Định dạng SVG**
SVG—viết tắt của Scalable Vector Graphics—là một loại hoặc định dạng đồ họa tiêu chuẩn được sử dụng để kết xuất hình ảnh hai chiều. SVG lưu trữ hình ảnh dưới dạng vector trong XML với các chi tiết xác định hành vi hoặc giao diện của chúng.

SVG là một trong số ít các định dạng ảnh đáp ứng các tiêu chuẩn cao về: khả năng mở rộng, tính tương tác, hiệu năng, khả năng truy cập, khả năng lập trình và các yếu tố khác. Vì những lý do này, nó thường được dùng trong phát triển web.

Bạn có thể muốn sử dụng tệp SVG khi cần:

- **in bản trình chiếu ở *kích thước rất lớn*.**  Hình ảnh SVG có thể mở rộng tới bất kỳ độ phân giải hoặc mức độ nào. Bạn có thể thay đổi kích thước hình ảnh SVG bao nhiêu lần cũng được mà không làm giảm chất lượng.
- **sử dụng biểu đồ và đồ thị từ các slide trong *các phương tiện hoặc nền tảng khác*.** Hầu hết các trình đọc có thể hiểu tệp SVG.
- **sử dụng *kích thước ảnh nhỏ nhất có thể*.** Tệp SVG thường nhỏ hơn so với các định dạng có độ phân giải cao tương đương, đặc biệt là các định dạng dựa trên bitmap (JPEG hoặc PNG).

## **Kết xuất một slide dưới dạng hình ảnh SVG**

Aspose.Slides for .NET cho phép bạn xuất các slide trong bản trình chiếu dưới dạng hình ảnh SVG. Thực hiện các bước sau để tạo ra các hình ảnh SVG:

_Steps: PowerPoint to SVG Conversions in C#_

Mã mẫu dưới đây giải thích các chuyển đổi này bằng .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Các bước: Chuyển đổi PowerPoint sang SVG bằng C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Các bước: Chuyển đổi PPT sang SVG bằng C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Các bước: Chuyển đổi PPTX sang SVG bằng C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Các bước: Chuyển đổi ODP sang SVG bằng C#</strong></a>

_Code Steps:_

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) .
   * _.ppt_ extension to load **PPT** file inside _Presentation_ class.
   * _.pptx_ extension to load **PPTX** file inside _Presentation_ class.
   * _.odp_ extension to load **ODP** file inside _Presentation_ class.
   * _.pps_ extension to load **PPS** file inside _Presentation_ class.
2. Duyệt qua tất cả các slide trong bản trình chiếu.
3. Ghi mỗi slide vào tệp SVG riêng thông qua FileStream.

{{% alert color="primary" %}} 

Bạn có thể muốn thử ứng dụng web [miễn phí](https://products.aspose.app/slides/vi/conversion/ppt-to-svg) của chúng tôi, trong đó chúng tôi đã triển khai chức năng chuyển đổi PPT sang SVG từ Aspose.Slides cho .NET.

{{% /alert %}} 

Mã mẫu này bằng C# cho thấy cách chuyển đổi PowerPoint sang SVG bằng Aspose.Slides: 

``` csharp
// Đối tượng Presentation có thể tải các định dạng PowerPoint như PPT, PPTX, ODP, v.v.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## **FAQ**

**Tại sao SVG kết quả có thể hiển thị khác nhau trên các trình duyệt?**

Hỗ trợ cho các tính năng SVG cụ thể được triển khai khác nhau bởi các động cơ trình duyệt. Các tham số [SVGOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/svgoptions/) giúp giảm thiểu các không tương thích.

**Có thể xuất không chỉ các slide mà còn các hình dạng riêng lẻ sang SVG không?**

Có. Bất kỳ [shape can be saved as a separate SVG](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/writeassvg/) , mà rất tiện cho các biểu tượng, hình ảnh minh họa và việc tái sử dụng đồ họa.

**Có thể hợp nhất nhiều slide thành một SVG duy nhất (dải/tài liệu) không?**

Kịch bản tiêu chuẩn là một slide → một SVG. Kết hợp nhiều slide vào một canvas SVG duy nhất là một bước xử lý hậu kỳ được thực hiện ở mức ứng dụng.

## **Xem thêm** 

Bài viết này cũng bao gồm các chủ đề sau. Mã nguồn giống như ở trên.

_Format_: **PowerPoint**
- [Mã C# PowerPoint sang SVG](#csharp-powerpoint-to-svg)
- [API C# PowerPoint sang SVG](#csharp-powerpoint-to-svg)
- [Programmatically C# PowerPoint sang SVG](#csharp-powerpoint-to-svg)
- [Thư viện C# PowerPoint sang SVG](#csharp-powerpoint-to-svg)
- [Lưu PowerPoint dưới dạng SVG bằng C#](#csharp-powerpoint-to-svg)
- [Tạo SVG từ PowerPoint bằng C#](#csharp-powerpoint-to-svg)
- [Tạo SVG từ PowerPoint bằng C#](#csharp-powerpoint-to-svg)
- [Trình chuyển đổi PowerPoint sang SVG bằng C#](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [Mã C# PPT sang SVG](#csharp-ppt-to-svg)
- [API C# PPT sang SVG](#csharp-ppt-to-svg)
- [Programmatically C# PPT sang SVG](#csharp-ppt-to-svg)
- [Thư viện C# PPT sang SVG](#csharp-ppt-to-svg)
- [Lưu PPT dưới dạng SVG bằng C#](#csharp-ppt-to-svg)
- [Tạo SVG từ PPT bằng C#](#csharp-ppt-to-svg)
- [Tạo SVG từ PPT bằng C#](#csharp-ppt-to-svg)
- [Trình chuyển đổi PPT sang SVG bằng C#](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [Mã C# PPTX sang SVG](#csharp-pptx-to-svg)
- [API C# PPTX sang SVG](#csharp-pptx-to-svg)
- [Programmatically C# PPTX sang SVG](#csharp-pptx-to-svg)
- [Thư viện C# PPTX sang SVG](#csharp-pptx-to-svg)
- [Lưu PPTX dưới dạng SVG bằng C#](#csharp-pptx-to-svg)
- [Tạo SVG từ PPTX bằng C#](#csharp-pptx-to-svg)
- [Tạo SVG từ PPTX bằng C#](#csharp-pptx-to-svg)
- [Trình chuyển đổi PPTX sang SVG bằng C#](#csharp-pptx-to-svg)

_Format_: **ODP**
- [Mã C# ODP sang SVG](#csharp-odp-to-svg)
- [API C# ODP sang SVG](#csharp-odp-to-svg)
- [Programmatically C# ODP sang SVG](#csharp-odp-to-svg)
- [Thư viện C# ODP sang SVG](#csharp-odp-to-svg)
- [Lưu ODP dưới dạng SVG bằng C#](#csharp-odp-to-svg)
- [Tạo SVG từ ODP bằng C#](#csharp-odp-to-svg)
- [Tạo SVG từ ODP bằng C#](#csharp-odp-to-svg)
- [Trình chuyển đổi ODP sang SVG bằng C#](#csharp-odp-to-svg)