---
title: So sánh các slide trong bản trình chiếu bằng JavaScript
linktitle: So sánh Slides
type: docs
weight: 50
url: /vi/nodejs-java/compare-slides/
keywords:
- so sánh slide
- so sánh slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "So sánh các bản trình chiếu PowerPoint và OpenDocument một cách lập trình với Aspose.Slides cho Node.js thông qua Java. Xác định sự khác biệt của slide trong mã một cách nhanh chóng."
---
## **Tổng quan**

Aspose.Slides cho phép bạn so sánh các slide, slide bố cục và slide chủ bằng cách sử dụng phương pháp `equals` được cung cấp bởi lớp `BaseSlide`. Phương pháp này trả về `true` khi các slide được so sánh giống hệt nhau về cấu trúc và nội dung tĩnh.

## **So sánh Hai Slide**

Phương thức Equals đã được thêm vào lớp [BaseSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/BaseSlide) và lớp [BaseSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/BaseSlide). Nó trả về true cho các slide/bố cục và slide/chủ mà giống nhau về cấu trúc và nội dung tĩnh.

Hai slide được coi là bằng nhau nếu tất cả các hình dạng, kiểu dáng, văn bản, hoạt ảnh và các cài đặt khác... đều bằng nhau. Việc so sánh không xét tới các giá trị định danh duy nhất, chẳng hạn SlideId, và nội dung động, chẳng hạn giá trị ngày hiện tại trong Trình giữ chỗ Ngày.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
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

Trạng thái [Hidden status](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/gethidden/) là thuộc tính cấp trình chiếu/phát lại, không phải nội dung trực quan. Sự bằng nhau của hai slide cụ thể được quyết định bởi cấu trúc và nội dung tĩnh của chúng; việc một slide bị ẩn không làm cho các slide khác nhau.

**Liên kết và các tham số của chúng có được tính đến không?**

Có. Liên kết là một phần của nội dung tĩnh của slide. Nếu URL hoặc hành động hyperlink khác nhau, thường được coi là sự khác biệt trong nội dung tĩnh.

**Nếu một biểu đồ tham chiếu tới tệp Excel bên ngoài, nội dung của tệp đó có được tính đến không?**

Không. Việc so sánh được thực hiện dựa trên chính các slide. Các nguồn dữ liệu bên ngoài thường không được đọc trong quá trình so sánh; chỉ những gì có trong cấu trúc và trạng thái tĩnh của slide được xem xét.