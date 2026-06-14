---
title: "Cách trích xuất văn bản từ PPT, PPTX và ODP bằng Aspose.Slides"
linktitle: "Trình chiếu"
type: docs
weight: 30
url: /vi/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- nền tảng đám mây
- tích hợp đám mây
- trích xuất văn bản
- trích xuất văn bản
- PPT
- PPTX
- ODP
- tệp trình chiếu
- đa nền tảng
- không phụ thuộc vào Office
- ghi chú và bình luận
- lập chỉ mục doanh nghiệp
- làm giàu dữ liệu
- .NET
- Aspose.Slides
description: "Trích xuất văn bản từ các bản trình chiếu trên các nền tảng đám mây phổ biến bằng các API Aspose.Slides, tự động hoá tìm kiếm, phân tích và xuất cho PPT, PPTX và ODP."
---
## **Giới thiệu**

Aspose.Slides cung cấp một **API mạnh mẽ, cấp cao** để trích xuất văn bản từ các tệp trình chiếu, bao gồm **PPT, PPTX và ODP**. Khác với Open XML SDK — chỉ hỗ trợ PPTX và đòi hỏi việc phân tích XML phức tạp — Aspose.Slides đơn giản hoá quá trình trích xuất văn bản, cho phép bạn tập trung vào việc tích hợp nội dung đã trích xuất vào quy trình làm việc của mình.

## **Trích xuất Văn bản Nhanh với PresentationFactory.Instance.GetPresentationText**

Để trích xuất văn bản từ một bản trình chiếu, **Aspose.Slides API** cung cấp phương thức tĩnh `PresentationFactory.Instance.GetPresentationText`. Nó bao gồm nhiều overload để làm việc với tệp trình chiếu hoặc luồng dữ liệu, nắm bắt văn bản từ **các slide, slide mẫu, bố cục, ghi chú và bình luận**. Văn bản đã trích xuất được truy cập thông qua giao diện `IPresentationText`.

Ví dụ sử dụng:

```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```

## **Chế độ Hoạt động cho GetPresentationText**

Phương thức `GetPresentationText` trong `PresentationFactory` cho phép bạn tinh chỉnh việc trích xuất văn bản bằng cách sử dụng tham số `TextExtractionArrangingMode`, tham số này điều khiển cách văn bản được sắp xếp trong kết quả.

### **Các chế độ khả dụng**

- **TextExtractionArrangingMode.Unarranged** – Trích xuất văn bản theo dạng tự do, không xét đến bố cục slide gốc.  
- **TextExtractionArrangingMode.Arranged** – Giữ nguyên thứ tự văn bản theo vị trí của chúng trên mỗi slide.

Ví dụ sử dụng:

```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```

## **Lợi thế chính của các phương thức PresentationFactory**

- **Không cần tải toàn bộ bản trình chiếu**: Giảm tối đa việc tiêu thụ bộ nhớ và tăng tốc độ xử lý.  
- **Tối ưu cho tệp lớn**: Xử lý hiệu quả ngay cả các bản trình chiếu quy mô lớn, trích xuất văn bản nhanh chóng.  
- **Trích xuất ghi chú và bình luận**: Bao gồm các chú thích của người dùng để cung cấp nội dung đầy đủ.  
- **Lý tưởng cho việc lập chỉ mục và phân tích nội dung**: Phù hợp với các hệ thống doanh nghiệp cần xử lý tự động và làm giàu dữ liệu.  
- **Không phụ thuộc vào Office**: Hoạt động mà không cần cài đặt Microsoft PowerPoint, mang lại giải pháp độc lập thực sự.  
- **Hỗ trợ đa định dạng**: Hoạt động liền mạch với **PPT, PPTX và ODP**.  
- **API linh hoạt, mạnh mẽ**: Cung cấp các phương thức đa dạng cho việc trích xuất văn bản có cấu trúc.  
- **Bao phủ đầy đủ các slide**: Trích xuất văn bản từ **bố cục, slide mẫu, slide tiêu chuẩn, nền, ghi chú người thuyết trình và bình luận**.  
- **Tương thích đa nền tảng**: Hoạt động trên **Windows, Linux, macOS**, và trong môi trường đám mây.  
- **Hiệu năng cao và khả năng mở rộng**: Thích hợp cho **ứng dụng SaaS** và triển khai doanh nghiệp quy mô lớn.

## **Hệ điều hành được hỗ trợ**

Aspose.Slides chạy trên nhiều hệ điều hành:

- **Windows** (ví dụ: Windows 7, 8, 10, 11 và các phiên bản Server)  
- **Linux** (nhiều bản phân phối, bao gồm Ubuntu, Debian, Fedora, CentOS, v.v.)  
- **macOS** (bao gồm các phiên bản hiện đại như 10.15 Catalina trở lên)  

## **Ngôn ngữ lập trình được hỗ trợ**

Aspose.Slides tích hợp với nhiều nền tảng và ngôn ngữ:

- **C#** – Chủ yếu được hỗ trợ qua Aspose.Slides for .NET.  
- **Java** – API đầy đủ tính năng có sẵn với Aspose.Slides for Java.  
- **C++** – Tận dụng Aspose.Slides cho các ứng dụng C++ yêu cầu hiệu năng cao.  
- **Python qua .NET** – Kết hợp chức năng Aspose.Slides bằng khả năng tương tác .NET.  
- **Các ngôn ngữ tương thích .NET khác** – Sử dụng thư viện trong bất kỳ môi trường nào được .NET hỗ trợ.  

## **Kết luận**

Aspose.Slides cung cấp **khả năng trích xuất văn bản toàn diện** cho các bản trình chiếu PowerPoint và OpenDocument, hỗ trợ **nhiều định dạng tệp, cấu trúc văn bản trực quan và triển khai dễ dàng** so với Open XML SDK. Từ **các slide và ghi chú đến nội dung mẫu**, **Aspose.Slides** là giải pháp hiệu suất cao, đầy tính năng cho việc trích xuất và quản lý văn bản trình chiếu.