---
title: So sánh các slide trình chiếu trong Python
linktitle: So sánh slide
type: docs
weight: 50
url: /vi/python-net/compare-slides/
keywords:
- so sánh slide
- so sánh slide
- PowerPoint
- OpenDocument
- trình chiếu
- Python
- Aspose.Slides
description: "So sánh các bản trình chiếu PowerPoint và OpenDocument một cách lập trình bằng Aspose.Slides cho Python qua .NET. Xác định sự khác biệt của các slide trong mã một cách nhanh chóng."
---
## **Tổng quan**

Aspose.Slides cho phép bạn so sánh các slide, slide bố cục và slide chủ bằng cách sử dụng phương thức `equals` được cung cấp bởi lớp `BaseSlide`. Phương thức này trả về `True` khi các slide được so sánh có cấu trúc và nội dung tĩnh giống hệt nhau.

## **So sánh hai slide**
Phương thức `equals` đã được thêm vào lớp [BaseSlide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/baseslide/) . Nó trả về true cho các slide/bố cục và slide/chủ mà có cấu trúc và nội dung tĩnh giống nhau.

Hai slide được coi là bằng nhau nếu tất cả các hình dạng, kiểu dáng, văn bản, hoạt ảnh và các cài đặt khác… So sánh không tính đến các giá trị định danh duy nhất, ví dụ SlideId và nội dung động, ví dụ giá trị ngày hiện tại trong Trình giữ chỗ ngày.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i].equals(p2.masters[j]):
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **Câu hỏi thường gặp**

**Việc một slide bị ẩn có ảnh hưởng đến việc so sánh các slide không?**

[Hidden status](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/hidden/) là thuộc tính cấp trình chiếu/phát lại, không phải nội dung trực quan. Sự bằng nhau của hai slide cụ thể được xác định bởi cấu trúc và nội dung tĩnh của chúng; việc một slide bị ẩn không làm cho các slide trở nên khác nhau.

**Liên kết siêu văn bản và các tham số của chúng có được tính đến không?**

Có. Liên kết là một phần của nội dung tĩnh của slide. Nếu URL hoặc hành động của siêu liên kết khác nhau, thường được coi là sự khác biệt trong nội dung tĩnh.

**Nếu một biểu đồ tham chiếu tới tệp Excel bên ngoài, nội dung của tệp đó có được tính đến không?**

Không. Việc so sánh được thực hiện dựa trên chính các slide. Các nguồn dữ liệu bên ngoài thường không được đọc trong quá trình so sánh; chỉ những gì có trong cấu trúc và trạng thái tĩnh của slide được xem xét.