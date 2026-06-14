---
title: Thay đổi kích thước slide của bài thuyết trình trên Android
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/androidjava/slide-size/
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
- kích thước slide độc đáo
- slide kích thước đầy đủ
- loại màn hình
- không thu phóng
- đảm bảo khớp
- tối đa hoá
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
descriptions: "Nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Java và Aspose.Slides cho Android, tối ưu hóa bài thuyết trình cho mọi loại màn hình mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước và tỷ lệ khung hình của slide trong bài thuyết trình PowerPoint, điều này quan trọng cả khi in ấn và hiển thị trên màn hình. 

Các kích thước và tỷ lệ slide phổ biến:

- **Standard (Tỷ lệ khung hình 4:3)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (Tỷ lệ khung hình 16:9)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bài thuyết trình vì một kích thước và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để đạt kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bài thuyết trình để tránh các vấn đề.

{{% alert color="primary" %}} 
Mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỷ lệ khung hình chuẩn 4:3.
{{% /alert %}}

## **Thay đổi kích thước slide trong bài thuyết trình**

Mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bài thuyết trình bằng Java sử dụng Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xác định kích thước slide tùy chỉnh trong bài thuyết trình**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide đặc thù hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide đầy đủ kích thước từ bài thuyết trình trên bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bài thuyết trình trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng cài đặt kích thước tùy chỉnh cho bài thuyết trình.

Mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho Android qua Java để chỉ định kích thước slide tùy chỉnh cho một bài thuyết trình bằng Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // kích thước giấy A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bài thuyết trình, nội dung của các slide (hình ảnh hoặc đối tượng, chẳng hạn) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bài thuyết trình, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu hoặc nhu cầu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào trong số sau:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ đến kích thước slide nhỏ hơn và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng 모두 phù hợp trên slide (điều này giúp tránh mất nội dung), hãy sử dụng cài đặt này. 

- `Maximize`

  Nếu bạn muốn phóng to đến kích thước slide lớn hơn và cần Aspose.Slides tăng kích thước các đối tượng trên slide sao cho chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này. 

Mã mẫu này cho bạn thấy cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của một bài thuyết trình:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng đơn vị khác ngoài inch (ví dụ, điểm hoặc milimét) không?**

Có. Aspose.Slides sử dụng đơn vị điểm nội bộ, trong đó 1 điểm bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimét hoặc centimet) sang điểm và sử dụng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao của slide.

**Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu năng và việc sử dụng bộ nhớ trong quá trình render không?**

Có. Kích thước slide lớn hơn (tính bằng điểm) kết hợp với tỷ lệ render cao hơn sẽ dẫn đến việc tiêu thụ bộ nhớ tăng và thời gian xử lý lâu hơn. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng kết quả mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bài thuyết trình có kích thước khác nhau không?**

Bạn không thể [merge presentations](/slides/vi/androidjava/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bài thuyết trình để khớp với bài còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesizescaletype/). Sau khi đồng nhất kích thước, bạn có thể hợp nhất các slide đồng thời giữ nguyên định dạng.

**Tôi có thể tạo ảnh thu nhỏ cho từng hình riêng lẻ hoặc khu vực cụ thể của slide và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể render ảnh thu nhỏ cho [entire slides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Các hình ảnh tạo ra phản ánh kích thước và tỷ lệ khung hình hiện tại của slide, đảm bảo khung hình và hình học nhất quán.