---
title: "Cách trích xuất văn bản từ tệp PPT, PPTX và ODP bằng Open XML SDK trong .NET"
linktitle: "Open XML SDK"
type: docs
weight: 20
url: /vi/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- nền tảng đám mây
- tích hợp đám mây
- Open XML SDK
- trích xuất văn bản PPTX
- xử lý slide .NET
- trích xuất văn bản trình chiếu
- slide mẫu
- ghi chú người thuyết trình
- trích xuất văn bản từ slide
- C#
description: "Tìm hiểu cách trích xuất văn bản từ PPT, PPTX và ODP trong .NET bằng Open XML SDK, với truy cập dựa trên XML, mẹo hiệu năng và cách khắc phục chuyển đổi cho các ứng dụng đám mây."
---
## **Tổng quan**

Bài viết này giải thích cách trích xuất văn bản từ các tệp trình chiếu bằng cách sử dụng Open XML SDK trong .NET. Nó tập trung vào việc truy cập trực tiếp XML cho các tệp PPTX, nơi văn bản có thể được lấy từ các phần tử slide có cấu trúc mà không cần hiển thị slide hoặc yêu cầu Microsoft PowerPoint. Bài viết cũng mô tả các lợi ích về hiệu năng như xử lý nhanh hơn và tiêu thụ bộ nhớ thấp hơn.

Đối với các tệp PPT và ODP, bài viết giải thích rằng văn bản không thể được trích xuất trực tiếp bằng Open XML SDK. Thay vào đó, các định dạng này phải được chuyển đổi sang PPTX trước, sau đó văn bản có thể được trích xuất từ tệp kết quả.

## **Open XML SDK**

**Open XML SDK** cung cấp một phương pháp cấu trúc cao và hiệu quả để trích xuất văn bản từ các tệp trình chiếu—đặc biệt là **PPTX**, tuân theo tiêu chuẩn Open XML. Bằng cách cung cấp truy cập trực tiếp đến XML nền, SDK này cho phép xử lý nhanh hơn và linh hoạt hơn nội dung slide so với các phương pháp truyền thống.

## **Truy cập XML trực tiếp**

- **Phân tích Văn bản Trực tiếp**: Open XML SDK cho phép bạn trích xuất văn bản từ các phần XML mà không cần hiển thị slide.
- **Các Phần tử Có Cấu trúc**: Vì văn bản được lưu trong các thẻ XML được xác định rõ, việc lấy và xử lý chúng trở nên đơn giản hơn.

### **Ví dụ: Trích xuất Văn bản Trực tiếp từ Nội dung XML của Slide**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## **Ưu điểm Hiệu năng**

- **Trích xuất Nhanh hơn**: Bỏ qua chi phí mở PowerPoint hoặc các API cấp cao khác.
- **Tiêu thụ Bộ nhớ Thấp hơn**: Chỉ truy cập các phần XML liên quan, giảm tiêu thụ tài nguyên.
- **Không Cần Microsoft PowerPoint**: Giải phóng bạn khỏi yêu cầu cài đặt thêm.

### **Ví dụ: Trích xuất Văn bản Hiệu quả mà Không Tải Toàn Bộ Bản Trình chiếu**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## **Xác định Các Phần tử Văn bản**

### **Chi tiết Khi Trích xuất Văn bản từ Trình chiếu**

Khi trích xuất văn bản từ trình chiếu, xem xét các yếu tố sau:

- **Văn bản Có Thể Nằm ở Các Phần Khác Nhau**: Slide thường, slide mẫu, bố cục, hoặc ghi chú người thuyết trình.
- **Các Trình giữ chỗ Mặc định**: Slide mẫu và bố cục có thể chứa các trình giữ chỗ (ví dụ, “Click to edit Master title style”) không phải là nội dung thực tế của trình chiếu.
- **Lọc Văn bản Trống hoặc Ẩn**: Một số phần tử có thể trống hoặc không được dự định hiển thị.

### **Thẻ Chứa Văn bản**

Trong một tệp **PPTX**, văn bản thường được lưu trong:
- các phần tử `<a:t>` bên trong `<a:p>` (đoạn văn)
- các phần tử `<a:r>` (đoạn văn bản trong đoạn)

### **Ví dụ: Trích xuất Tất cả Các Phần tử Văn bản từ Một Slide**

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP và PPT**

### **Không Thể Trích xuất Văn bản Trực tiếp**

- Không giống như **PPTX**, **PPT** (định dạng nhị phân) và **ODP** (OpenDocument Presentation) **không được hỗ trợ** bởi Open XML SDK.
- **PPT** lưu nội dung trong định dạng nhị phân đóng, làm cho việc trích xuất văn bản trở nên phức tạp.
- **ODP** dựa trên **OpenDocument XML**, có cấu trúc khác với PPTX.

### **Cách Khắc phục: Chuyển Đổi Sang PPTX**

Để trích xuất văn bản từ **PPT** hoặc **ODP**, cách tiếp cận được khuyến nghị là:

1. Chuyển đổi PPT → PPTX bằng PowerPoint hoặc công cụ của bên thứ ba.  
2. Chuyển đổi ODP → PPTX qua LibreOffice hoặc PowerPoint.  
3. Trích xuất văn bản từ PPTX mới bằng Open XML SDK.

### **Ví dụ: Chuyển đổi ODP sang PPTX qua Dòng Lệnh LibreOffice**

```sh
soffice --headless --convert-to pptx presentation.odp
```

## **Nền tảng và Framework được Hỗ trợ**

- **Windows**: .NET Framework 4.6.1 trở lên, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Môi trường Đám mây**: Microsoft Azure Functions, AWS Lambda (.NET Core), Docker containers.
- **Tương thích với Ứng dụng Office**: Không cần cài đặt Microsoft Office.
- **Ngôn ngữ Lập trình được Hỗ trợ**: Open XML SDK có thể dùng với **C#**, **VB.NET**, **F#**, và các ngôn ngữ khác được .NET hỗ trợ.

## **Kết luận**

Việc tận dụng **Open XML SDK** để **trích xuất văn bản PPTX** mang lại cả hiệu quả và độ rõ ràng, trong khi **PPT và ODP** đòi hỏi một bước chuyển đổi ban đầu để xử lý trơn tru. Áp dụng cách tiếp cận này đảm bảo **hiệu năng cao**, **tính linh hoạt**, và **tương thích rộng** với các ứng dụng .NET hiện đại.