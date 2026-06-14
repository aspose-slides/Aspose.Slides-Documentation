---
title: Chuyển đổi PPT sang PPTX bằng JavaScript
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/nodejs-java/convert-ppt-to-pptx/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- PPT sang PPTX
- lưu PPT dưới dạng PPTX
- xuất PPT sang PPTX
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PPT cũ sang PPTX hiện đại nhanh chóng với Aspose.Slides cho Node.js — hướng dẫn rõ ràng, mẫu mã miễn phí, không phụ thuộc vào Microsoft Office."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi PowerPoint Presentation ở định dạng PPT sang định dạng PPTX bằng JavaScript và với ứng dụng chuyển đổi PPT sang PPTX trực tuyến. Các chủ đề sau được đề cập.

- Chuyển đổi PPT sang PPTX bằng JavaScript

## **Java Chuyển đổi PPT sang PPTX**

Đối với mã mẫu JavaScript chuyển đổi PPT sang PPTX, vui lòng xem phần bên dưới tức là [Convert PPT to PPTX](#convert-ppt-to-pptx). Nó chỉ tải tệp PPT và lưu dưới định dạng PPTX. Bằng cách chỉ định các định dạng lưu khác nhau, bạn cũng có thể lưu tệp PPT sang nhiều định dạng khác như PDF, XPS, ODP, HTML, v.v. như đã thảo luận trong các bài viết này.

- [Chuyển đổi PPT sang PDF trong JavaScript](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/)
- [Chuyển đổi PPT sang XPS trong JavaScript](/slides/vi/nodejs-java/convert-powerpoint-to-xps/)
- [Chuyển đổi PPT sang HTML trong JavaScript](/slides/vi/nodejs-java/convert-powerpoint-to-html/)
- [Chuyển đổi PPT sang ODP trong JavaScript](/slides/vi/nodejs-java/save-presentation/)
- [Chuyển đổi PPT sang PNG trong JavaScript](/slides/vi/nodejs-java/convert-powerpoint-to-png/)

## **Về chuyển đổi PPT sang PPTX**

Chuyển đổi định dạng PPT cũ sang PPTX bằng Aspose.Slides API. Nếu bạn cần chuyển đổi hàng ngàn bản trình chiếu PPT sang định dạng PPTX, giải pháp tốt nhất là thực hiện bằng chương trình. Với Aspose.Slides API, bạn có thể làm điều này chỉ trong vài dòng mã. API hỗ trợ khả năng tương thích đầy đủ để chuyển đổi bản trình chiếu PPT sang PPTX và có thể:

- Chuyển đổi các cấu trúc phức tạp của master, bố cục và slide.
- Chuyển đổi bản trình chiếu có biểu đồ.
- Chuyển đổi bản trình chiếu có các hình nhóm, hình tự động (như hình chữ nhật và elip), các hình có hình học tùy chỉnh.
- Chuyển đổi bản trình chiếu có các kết cấu và kiểu điền ảnh cho hình tự động.
- Chuyển đổi bản trình chiếu có các chỗ giữ chỗ, khung văn bản và bộ giữ văn bản.

{{% alert color="primary" %}} 

Hãy xem ứng dụng [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx)

Ứng dụng này được xây dựng dựa trên [**Aspose.Slides API**](https://products.aspose.com/slides/vi/nodejs-java/), vì vậy bạn có thể xem ví dụ sống động về khả năng chuyển đổi cơ bản từ PPT sang PPTX. Aspose.Slides Conversion là một ứng dụng web, cho phép kéo thả tệp trình chiếu ở định dạng PPT và tải xuống bản đã chuyển đổi sang PPTX.

Tìm các ví dụ sống khác của [**Aspose.Slides Conversion**](https://products.aspose.app/slides/vi/conversion/).

{{% /alert %}} 

## **Chuyển đổi PPT sang PPTX**

Aspose.Slides cho Node.js qua Java hiện cho phép các nhà phát triển truy cập PPT bằng thể hiện lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) và chuyển đổi nó sang định dạng [PPTX](https://docs.fileformat.com/presentation/pptx/). Hiện tại, nó hỗ trợ chuyển đổi một phần từ [PPT ](https://docs.fileformat.com/presentation/ppt/) sang PPTX.

Aspose.Slides cho Node.js qua Java cung cấp lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) đại diện cho tệp trình chiếu **PPTX**. Lớp Presentation hiện cũng có thể truy cập **PPT** thông qua Presentation khi đối tượng được khởi tạo. Ví dụ sau cho thấy cách chuyển đổi một bản trình chiếu PPT sang PPTX Presentation.

```javascript
// Tạo một đối tượng Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Lưu bản trình chiếu PPTX sang định dạng PPTX
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Hình : Bản trình chiếu PPT nguồn**|

Bản mã trên tạo ra bản trình chiếu PPTX sau khi chuyển đổi

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Hình: Bản trình chiếu PPTX đã tạo sau khi chuyển đổi**|

## **FAQ**

**Sự khác nhau giữa định dạng PPT và PPTX là gì?**

PPT là định dạng tệp nhị phân cũ hơn được Microsoft PowerPoint sử dụng, trong khi PPTX là định dạng dựa trên XML mới được giới thiệu cùng Microsoft Office 2007. Tệp PPTX mang lại hiệu năng tốt hơn, kích thước tệp giảm và khả năng khôi phục dữ liệu cải thiện.

**Aspose.Slides có hỗ trợ chuyển đổi hàng loạt nhiều tệp PPT sang PPTX không?**

Có, bạn có thể sử dụng Aspose.Slides trong một vòng lặp để chuyển đổi nhiều tệp PPT sang PPTX một cách lập trình, phù hợp cho các kịch bản chuyển đổi hàng loạt.

**Nội dung và định dạng có được giữ nguyên sau khi chuyển đổi không?**

Aspose.Slides duy trì độ trung thực cao khi chuyển đổi các bản trình chiếu. Bố cục slide, hoạt ảnh, hình dạng, biểu đồ và các yếu tố thiết kế khác được giữ nguyên trong quá trình chuyển đổi PPT sang PPTX.

**Tôi có thể chuyển đổi sang các định dạng khác như PDF hoặc HTML từ tệp PPT không?**

Có, Aspose.Slides hỗ trợ chuyển đổi tệp PPT sang nhiều định dạng, bao gồm PDF, XPS, HTML, ODP và các định dạng hình ảnh như PNG và JPEG.

**Có thể chuyển đổi PPT sang PPTX mà không cần cài đặt Microsoft PowerPoint không?**

Có, Aspose.Slides là một API độc lập và không yêu cầu Microsoft PowerPoint hay bất kỳ phần mềm bên thứ ba nào để thực hiện chuyển đổi.

**Có công cụ trực tuyến để chuyển đổi PPT sang PPTX không?**

Có, bạn có thể sử dụng ứng dụng web miễn phí [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx) để thực hiện chuyển đổi trực tiếp trong trình duyệt mà không cần viết mã.