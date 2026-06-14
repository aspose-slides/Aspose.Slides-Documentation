---
title: So sánh các slide của bài thuyết trình trong C++
linktitle: So sánh các slide
type: docs
weight: 50
url: /vi/cpp/compare-slides/
keywords:
- so sánh slide
- so sánh slide
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "So sánh các bài thuyết trình PowerPoint và OpenDocument một cách lập trình bằng Aspose.Slides cho C++. Xác định nhanh các khác biệt giữa các slide trong mã."
---
## **Overview**

Aspose.Slides cho phép bạn so sánh các slide, slide bố cục và slide mẫu bằng cách sử dụng phương thức `Equals` được cung cấp bởi giao diện `IBaseSlide` và lớp `BaseSlide`. Phương thức này trả về `true` khi các slide được so sánh giống hệt nhau về cấu trúc và nội dung tĩnh.

## **Compare Two Slides**
Phương thức Equals đã được thêm vào giao diện `IBaseSlide` và lớp `BaseSlide`. Nó trả về `true` cho các slide / slide bố cục / slide mẫu có cấu trúc và nội dung tĩnh giống nhau.

Hai slide được coi là bằng nhau nếu tất cả các hình dạng, kiểu dáng, văn bản, hoạt ảnh và các cài đặt khác… So sánh không xét đến các giá trị định danh duy nhất, chẳng hạn như `SlideId`, và nội dung động, chẳng hạn như giá trị ngày hiện tại trong Date Placeholder.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **FAQ**

**Liệu việc một slide bị ẩn có ảnh hưởng đến việc so sánh các slide hay không?**

[Hidden status](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slide/get_hidden/) là thuộc tính ở mức trình chiếu/phát, không phải nội dung trực quan. Độ tương đương của hai slide cụ thể được xác định bởi cấu trúc và nội dung tĩnh của chúng; việc một slide bị ẩn không làm cho các slide trở nên khác nhau.

**Có tính đến siêu liên kết và các tham số của chúng không?**

Có. Liên kết là một phần của nội dung tĩnh của slide. Nếu URL hoặc hành động siêu liên kết khác nhau, thường được coi là sự khác biệt trong nội dung tĩnh.

**Nếu một biểu đồ tham chiếu tới tệp Excel bên ngoài, nội dung của tệp đó có được tính đến không?**

Không. So sánh được thực hiện dựa trên các slide tự chúng. Các nguồn dữ liệu ngoại vi thường không được đọc trong quá trình so sánh; chỉ những gì có trong cấu trúc và trạng thái tĩnh của slide mới được cân nhắc.