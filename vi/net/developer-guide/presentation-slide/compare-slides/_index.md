---
title: So sánh các slide trình chiếu trong .NET
linktitle: So sánh slide
type: docs
weight: 50
url: /vi/net/compare-slides/
keywords:
- so sánh slide
- so sánh slide
- PowerPoint
- OpenDocument
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "So sánh các bản trình chiếu PowerPoint và OpenDocument một cách lập trình với Aspose.Slides cho .NET. Xác định sự khác biệt của slide trong mã nhanh chóng."
---
## **Tổng quan**

Aspose.Slides cho phép bạn so sánh các slide, slide bố cục và slide mẫu bằng phương thức `Equals` được cung cấp bởi giao diện `IBaseSlide` và lớp `BaseSlide`. Phương thức này trả về `true` khi các slide được so sánh giống hệt nhau về cấu trúc và nội dung tĩnh.

## **So sánh Hai Slide**

Phương thức Equals đã được thêm vào giao diện [IBaseSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseslide) và lớp [BaseSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/baseslide). Nó trả về true cho các slide/bố cục và slide/mẫu mà cấu trúc và nội dung tĩnh giống nhau.

Hai slide được coi là bằng nhau nếu tất cả các hình dạng, kiểu dáng, văn bản, hoạt ảnh và các thiết lập khác, v.v. So sánh không xét các giá trị định danh duy nhất, ví dụ SlideId và nội dung động, ví dụ giá trị ngày hiện tại trong Date Placeholder.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **FAQ**

**Liệu việc một slide bị ẩn có ảnh hưởng đến việc so sánh các slide không?**

[Hidden status](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/hidden/) là thuộc tính mức độ trình chiếu/phát lại, không phải nội dung hình ảnh. Sự bằng nhau của hai slide cụ thể được xác định bởi cấu trúc và nội dung tĩnh của chúng; việc một slide bị ẩn không làm cho các slide trở nên khác nhau.

**Liệu các siêu liên kết và các tham số của chúng có được tính đến không?**

Có. Các liên kết là một phần của nội dung tĩnh của slide. Nếu URL hoặc hành động siêu liên kết khác nhau, thường được xem là sự khác biệt trong nội dung tĩnh.

**Nếu một biểu đồ tham chiếu tới tệp Excel bên ngoài, nội dung của tệp đó có được tính đến không?**

Không. So sánh được thực hiện dựa trên chính các slide. Các nguồn dữ liệu bên ngoài thường không được đọc tại thời điểm so sánh; chỉ những gì hiện có trong cấu trúc và trạng thái tĩnh của slide được xem xét.