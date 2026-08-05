---
title: Thay đổi kích thước slide trong bài thuyết trình bằng C++
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/cpp/slide-size/
keywords:
- kích thước slide
- tỷ lệ khung hình
- chuẩn
- màn hình rộng
- 4:3
- 16:9
- đặt kích thước slide
- thay đổi kích thước slide
- kích thước slide tùy chỉnh
- kích thước slide đặc biệt
- kích thước slide duy nhất
- slide toàn kích thước
- loại màn hình
- không thay đổi tỷ lệ
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng C++ và Aspose.Slides, tối ưu hoá bài thuyết trình cho mọi loại màn hình mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bài thuyết trình PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Các kích thước slide và tỷ lệ phổ biến:

- **Standard (4:3 Aspect Ratio)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bài thuyết trình vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để có kết quả tối ưu, hãy đặt kích thước slide ngay khi bắt đầu tạo bài thuyết trình để tránh các vấn đề.

{{% alert color="primary" %}} 
Theo mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỷ lệ khung hình chuẩn 4:3.
{{% /alert %}}

## **Thay đổi kích thước slide trong bài thuyết trình**

Mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bài thuyết trình bằng C++ sử dụng Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Xác định kích thước slide tùy chỉnh trong bài thuyết trình**

Nếu bạn thấy các kích thước slide phổ biến (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bài thuyết trình trên bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bài thuyết trình trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng cài đặt kích thước tùy chỉnh cho bài thuyết trình. 

Mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho C++ để chỉ định kích thước slide tùy chỉnh cho một bài thuyết trình bằng C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Kích thước giấy A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bài thuyết trình, nội dung của các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Theo mặc định, các đối tượng tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bài thuyết trình, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides thu nhỏ các đối tượng của slide để đảm bảo chúng đều vừa trên slide (điều này giúp tránh mất nội dung), hãy sử dụng cài đặt này. 

- `Maximize`

  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides làm lớn hơn các đối tượng của slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này. 

Mã mẫu này cho bạn thấy cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của một bài thuyết trình:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, point hoặc milimet) không?**

Có. Aspose.Slides sử dụng đơn vị point nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang point và sử dụng các giá trị đã chuyển để xác định chiều rộng và chiều cao của slide.

**Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu năng và bộ nhớ khi render không?**

Có. Kích thước slide lớn hơn (tính bằng point) kết hợp với tỉ lệ render cao hơn sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy chọn kích thước slide thực tế và chỉ điều chỉnh tỉ lệ render khi cần thiết để đạt được chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bài thuyết trình có kích thước khác nhau không?**

Bạn không thể [hợp nhất các bài thuyết trình](/slides/vi/cpp/merge-presentation/) khi chúng có kích thước slide khác nhau — đầu tiên, hãy thay đổi kích thước một bài thuyết trình sao cho khớp với bài còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidesizescaletype/). Sau khi đồng nhất kích thước, bạn có thể hợp nhất các slide mà vẫn giữ định dạng.

**Tôi có thể tạo thumbnail cho các hình dạng riêng lẻ hoặc các khu vực cụ thể của slide không, và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể tạo thumbnail cho [toàn bộ slide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/getimage/) cũng như cho [các hình dạng đã chọn](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getimage/). Các hình ảnh tạo ra phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.