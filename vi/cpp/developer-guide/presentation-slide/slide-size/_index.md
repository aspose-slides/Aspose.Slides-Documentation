---
title: Thay đổi kích thước slide trong bản trình bày bằng C++
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/cpp/slide-size/
keywords:
- kích thước slide
- tỷ lệ khung hình
- tiêu chuẩn
- màn hình rộng
- 4:3
- 16:9
- đặt kích thước slide
- thay đổi kích thước slide
- kích thước slide tùy chỉnh
- kích thước slide đặc biệt
- kích thước slide độc đáo
- slide kích thước đầy đủ
- loại màn hình
- không thu phóng
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
descriptions: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng C++ và Aspose.Slides, tối ưu hóa bản trình bày cho bất kỳ màn hình nào mà không làm giảm chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỉ lệ khung hình trong các bản trình bày PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình.

Các kích thước slide và tỉ lệ phổ biến:

- **Standard (4:3 Aspect Ratio)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được đề xuất cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bản trình bày vì một kích thước slide và tỉ lệ khung hình duy nhất sẽ áp dụng cho mọi slide. Để có kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bản trình bày để tránh các vấn đề phát sinh.

{{% alert color="primary" %}} 
Mặc định, các bản trình bày được tạo bằng Aspose.Slides sử dụng tỉ lệ khung hình chuẩn 4:3.
{{% /alert %}}

## **Thay đổi kích thước slide trong bản trình bày**

Mẫu mã này cho thấy cách thay đổi kích thước slide trong một bản trình bày bằng C++ sử dụng Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Xác định kích thước slide tùy chỉnh trong bản trình bày**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bản trình bày trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bản trình bày trên một số loại màn hình nhất định, bạn có khả năng hưởng lợi từ việc sử dụng cài đặt kích thước tùy chỉnh cho bản trình bày.

Mẫu mã này cho thấy cách sử dụng Aspose.Slides cho C++ để chỉ định kích thước slide tùy chỉnh cho một bản trình bày bằng C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Kích thước giấy A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bản trình bày, nội dung của các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bản trình bày, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu bạn muốn đạt được, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng đều vừa trong slide (điều này giúp tránh mất nội dung), hãy sử dụng cài đặt này.

- `Maximize`

  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides làm lớn hơn các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này.

Mẫu mã này cho thấy cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của một bản trình bày:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, points hoặc millimeters) không?**

Có. Aspose.Slides sử dụng points nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như millimeters hoặc centimeters) sang points và dùng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao slide.

**Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu năng và việc sử dụng bộ nhớ khi render không?**

Có. Kích thước slide lớn hơn (tính theo points) kết hợp với tỷ lệ render cao sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy lựa chọn kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi thực sự cần để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bản trình bày có kích thước khác nhau không?**

Bạn không thể [merge presentations](/slides/vi/cpp/merge-presentation/) khi chúng có kích thước slide khác nhau — trước hết, cần thay đổi kích thước một bản trình bày để khớp với bản còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesizescaletype/). Sau khi đồng bộ kích thước, bạn có thể hợp nhất các slide mà vẫn giữ định dạng.

**Tôi có thể tạo thumbnail cho các shape riêng lẻ hoặc các vùng cụ thể của slide, và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể render thumbnail cho [entire slides](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/getimage/) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getimage/). Các hình ảnh tạo ra phản ánh kích thước slide và tỉ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.