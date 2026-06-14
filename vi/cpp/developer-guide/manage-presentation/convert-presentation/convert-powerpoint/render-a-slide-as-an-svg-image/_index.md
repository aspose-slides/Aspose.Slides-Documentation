---
title: Kết xuất các slide trình chiếu thành hình ảnh SVG trong C++
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- trình chiếu sang SVG
- slide sang SVG
- PPT sang SVG
- PPTX sang SVG
- lưu PPT dưới dạng SVG
- lưu PPTX dưới dạng SVG
- xuất PPT sang SVG
- xuất PPTX sang SVG
- kết xuất slide
- chuyển đổi slide
- xuất slide
- hình ảnh vector
- PowerPoint
- trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách kết xuất các slide PowerPoint thành hình ảnh SVG bằng Aspose.Slides cho C++. Hình ảnh chất lượng cao với các ví dụ mã đơn giản."
---
## **Tổng quan**

Bài viết này giải thích cách hiển thị các slide trình chiếu dưới dạng hình ảnh SVG bằng Aspose.Slides. Nó mô tả định dạng SVG và các ưu điểm của nó, bao gồm khả năng mở rộng, khả năng truy cập và tính phù hợp cho phát triển web.

Bạn sẽ học cách tải một tệp trình chiếu, duyệt qua các slide của nó và lưu mỗi slide dưới dạng một tệp SVG riêng biệt. Bài viết bao gồm các định dạng trình chiếu PowerPoint và OpenDocument, bao gồm PPT, PPTX, ODP và PPS, và chỉ ra cách thực hiện chuyển đổi một cách lập trình bằng lớp `Presentation` và phương thức `WriteAsSvg`.

## **Định dạng SVG**

SVG—viết tắt của Scalable Vector Graphics—là một loại hoặc định dạng đồ họa tiêu chuẩn được sử dụng để hiển thị hình ảnh hai chiều. SVG lưu trữ hình ảnh dưới dạng vector trong XML cùng với các chi tiết định nghĩa hành vi hoặc diện mạo của chúng.

SVG là một trong số ít các định dạng hình ảnh đáp ứng các tiêu chuẩn rất cao về: khả năng mở rộng, tính tương tác, hiệu năng, khả năng truy cập, khả năng lập trình và những yếu tố khác. Vì những lý do này, nó thường được sử dụng trong phát triển web.

Bạn có thể muốn sử dụng các tệp SVG khi cần

- **in ra trình chiếu của bạn ở *định dạng rất lớn*.** Hình ảnh SVG có thể mở rộng lên bất kỳ độ phân giải hay mức độ nào. Bạn có thể thay đổi kích thước hình ảnh SVG bao nhiêu lần cần thiết mà không làm giảm chất lượng.
- **sử dụng các biểu đồ và đồ thị từ slide của bạn trong *các phương tiện hoặc nền tảng khác*.* Hầu hết các trình đọc có thể hiển thị tệp SVG.
- **sử dụng *kích thước nhỏ nhất có thể của hình ảnh***. Các tệp SVG thường nhỏ hơn so với các phiên bản độ phân giải cao tương đương trong các định dạng khác, đặc biệt là các định dạng dựa trên bitmap (JPEG hoặc PNG).

## **Kết xuất Slide dưới dạng Hình ảnh SVG**

Aspose.Slides for C++ cho phép bạn xuất các slide trong bản trình chiếu của mình dưới dạng hình ảnh SVG. Thực hiện các bước sau để tạo ra các hình ảnh SVG:

1. Tạo một thể hiện của lớp `Presentation`.
2. Duyệt qua tất cả các slide trong bản trình chiếu.
3. Ghi mỗi slide vào tệp SVG riêng của nó thông qua `FileStream`.

{{% alert color="primary" %}} 
Bạn có thể muốn thử [ứng dụng web miễn phí](https://products.aspose.app/slides/vi/conversion/ppt-to-svg) của chúng tôi, trong đó chúng tôi đã triển khai chức năng chuyển đổi PPT sang SVG từ Aspose.Slides for C++.
{{% /alert %}} 

Mã mẫu này trong C++ cho bạn thấy cách chuyển đổi PPT sang SVG bằng Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```

## **CÂU HỎI THƯỜNG GẶP**

**Tại sao SVG kết quả có thể hiển thị khác nhau trên các trình duyệt?**

Hỗ trợ các tính năng SVG cụ thể được triển khai khác nhau bởi các engine trình duyệt. Các tham số của [SVGOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/svgoptions/) giúp giảm bớt các sự không tương thích.

**Có thể xuất không chỉ các slide mà còn các hình dạng riêng lẻ sang SVG không?**

Có. Bất kỳ [hình dạng nào cũng có thể được lưu dưới dạng SVG riêng](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/writeassvg/), điều này thuận tiện cho biểu tượng, hình ảnh minh họa và tái sử dụng đồ họa.

**Có thể kết hợp nhiều slide thành một SVG duy nhất (dải/tài liệu) không?**

Kịch bản tiêu chuẩn là một slide → một SVG. Kết hợp nhiều slide thành một canvas SVG duy nhất là một bước xử lý hậu kỳ thực hiện ở mức ứng dụng.