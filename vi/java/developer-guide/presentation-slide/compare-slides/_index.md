---
title: So sánh các slide trình chiếu trong Java
linktitle: So sánh Slide
type: docs
weight: 50
url: /vi/java/compare-slides/
keywords:
- so sánh slide
- so sánh slide
- PowerPoint
- OpenDocument
- trình chiếu
- Java
- Aspose.Slides
description: "So sánh các bản trình chiếu PowerPoint và OpenDocument một cách lập trình bằng Aspose.Slides cho Java. Xác định nhanh các sự khác biệt giữa các slide trong mã."
---
## **Tổng quan**

Aspose.Slides cho phép bạn so sánh các slide, slide bố cục và slide mẫu bằng cách sử dụng phương thức `equals` được cung cấp bởi giao diện `IBaseSlide` và lớp `BaseSlide`. Phương thức này trả về `true` khi các slide được so sánh hoàn toàn giống nhau về cấu trúc và nội dung tĩnh.

## **So sánh hai slide**
Equals method đã được thêm vào giao diện [IBaseSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IBaseSlide) và lớp [BaseSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/BaseSlide). Nó trả về true cho các slide/bố cục và slide/mẫu mà chúng giống nhau về cấu trúc và nội dung tĩnh.

Hai slide được coi là bằng nhau nếu tất cả các hình dạng, kiểu dáng, văn bản, hoạt ảnh và các thiết lập khác, v.v. đều bằng nhau. Việc so sánh không xét đến các giá trị định danh duy nhất, chẳng hạn như SlideId, và nội dung động, chẳng hạn như giá trị ngày hiện tại trong Placeholder ngày.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **Câu hỏi thường gặp**

**Việc một slide bị ẩn có ảnh hưởng đến việc so sánh các slide không?**

[Trạng thái ẩn](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#getHidden--) là thuộc tính cấp trình chiếu/phát lại, không phải nội dung trực quan. Sự bằng nhau của hai slide cụ thể được xác định bởi cấu trúc và nội dung tĩnh của chúng; chỉ vì một slide bị ẩn không làm cho các slide trở nên khác nhau.

**Liên kết và các tham số của chúng có được tính đến không?**

Có. Liên kết là một phần của nội dung tĩnh của slide. Nếu URL hoặc hành động siêu liên kết khác nhau, thường được coi là sự khác biệt trong nội dung tĩnh.

**Nếu biểu đồ tham chiếu tới tệp Excel bên ngoài, nội dung của tệp đó có được tính đến không?**

Không. Việc so sánh được thực hiện dựa trên chính các slide. Các nguồn dữ liệu bên ngoài thường không được đọc vào thời điểm so sánh; chỉ những gì có trong cấu trúc và trạng thái tĩnh của slide mới được xem xét.