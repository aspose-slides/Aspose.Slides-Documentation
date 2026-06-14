---
title: Kết xuất các slide bản trình bày dưới dạng hình ảnh SVG trên Android
linktitle: Slide sang SVG
type: docs
weight: 50
url: /vi/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint sang SVG
- bản trình bày sang SVG
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
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách kết xuất các slide PowerPoint dưới dạng hình ảnh SVG bằng Aspose.Slides cho Android. Hình ảnh chất lượng cao với các ví dụ mã Java đơn giản."
---
## **Tổng quan**

Bài viết này giải thích cách kết xuất các slide của bản trình bày dưới dạng hình ảnh SVG bằng Aspose.Slides. Nó mô tả định dạng SVG và những ưu điểm của nó, bao gồm khả năng mở rộng, khả năng truy cập và tính phù hợp cho phát triển web.

Bạn sẽ học cách tải tệp bản trình bày, duyệt qua các slide và lưu mỗi slide dưới dạng tệp SVG riêng biệt. Bài viết bao phủ các định dạng bản trình bày PowerPoint và OpenDocument, bao gồm PPT, PPTX, ODP và PPS, và chỉ ra cách thực hiện chuyển đổi một cách lập trình bằng lớp `Presentation` và phương thức `writeAsSvg`.

## **Định dạng SVG**

SVG—viết tắt của Scalable Vector Graphics—là một loại hoặc định dạng đồ họa tiêu chuẩn được sử dụng để kết xuất hình ảnh hai chiều. SVG lưu trữ hình ảnh dưới dạng vector trong XML với các chi tiết xác định hành vi hoặc giao diện của chúng.

SVG là một trong số ít các định dạng hình ảnh đáp ứng các tiêu chuẩn rất cao về: khả năng mở rộng, tính tương tác, hiệu năng, khả năng truy cập, khả năng lập trình và các yếu tố khác. Vì những lý do này, nó thường được sử dụng trong phát triển web.

Bạn có thể muốn sử dụng tệp SVG khi cần:

- **in bản trình bày của bạn ở *định dạng rất lớn*.** Hình ảnh SVG có thể mở rộng lên bất kỳ độ phân giải hoặc mức nào. Bạn có thể thay đổi kích thước hình ảnh SVG bao nhiêu lần cũng được mà không làm giảm chất lượng.
- **sử dụng biểu đồ và đồ thị từ các slide trong *các môi trường hoặc nền tảng khác nhau*.** Hầu hết các trình đọc có thể hiểu tệp SVG.
- **sử dụng *kích thước hình ảnh nhỏ nhất có thể*.** Tệp SVG thường nhỏ hơn so với các phiên bản độ phân giải cao tương đương trong các định dạng khác, đặc biệt là các định dạng dựa trên bitmap (JPEG hoặc PNG).

## **Kết xuất một Slide thành Hình ảnh SVG**

Aspose.Slides for Android via Java cho phép bạn xuất các slide trong bản trình bày dưới dạng hình ảnh SVG. Thực hiện các bước sau để tạo ra các hình ảnh SVG:

1. Tạo một thể hiện của lớp `Presentation`.
2. Duyệt qua tất cả các slide trong bản trình bày.
3. Ghi mỗi slide vào tệp SVG riêng bằng `FileOutputStream`.

{{% alert color="primary" %}} 
Bạn có thể muốn thử [ứng dụng web miễn phí](https://products.aspose.app/slides/vi/conversion/ppt-to-svg) mà chúng tôi đã triển khai chức năng chuyển đổi PPT sang SVG từ Aspose.Slides for Android via Java. 
{{% /alert %}} 

Mã mẫu này bằng Java cho bạn thấy cách chuyển đổi PPT sang SVG sử dụng Aspose.Slides:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tại sao SVG kết quả có thể hiển thị khác nhau trên các trình duyệt?**

Hỗ trợ các tính năng SVG cụ thể được triển khai khác nhau bởi các engine trình duyệt. Các tham số của [SVGOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/svgoptions/) giúp giảm thiểu sự không tương thích.

**Có thể xuất không chỉ các slide mà còn các hình dạng riêng lẻ thành SVG không?**

Có. Bất kỳ [hình dạng nào cũng có thể được lưu dưới dạng SVG riêng](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), điều này thuận tiện cho các biểu tượng, hình ảnh đồ họa và việc tái sử dụng đồ họa.

**Có thể kết hợp nhiều slide thành một SVG duy nhất (dải/tài liệu) không?**

Kịch bản tiêu chuẩn là một slide → một SVG. Kết hợp nhiều slide thành một canvas SVG duy nhất là một bước xử lý hậu kỳ được thực hiện ở mức ứng dụng.