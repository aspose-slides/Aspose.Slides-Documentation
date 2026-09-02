---
title: Tại sao không sử dụng Open XML SDK
type: docs
weight: 120
url: /vi/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- so sánh
- mô hình đối tượng trình chiếu
- chuyển đổi chất lượng cao
- PowerPoint
- OpenDocument
- trình chiếu
- PHP
- Aspose.Slides
description: "Xem tại sao Aspose.Slides là lựa chọn tốt hơn so với Open XML SDK miễn phí: so sánh các tính năng, chuyển đổi không cần tự động hoá, và hỗ trợ rộng rãi cho PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích khi nào các nhà phát triển có thể chọn Open XML SDK hoặc Aspose.Slides để làm việc với tài liệu trình chiếu. Nó mô tả Open XML SDK là một thư viện để thao tác các gói OOXML và các phần tử XML cơ bản của chúng, trong khi Aspose.Slides được giới thiệu như một thư viện xử lý trình chiếu với mô hình đối tượng cấp cao và hỗ trợ nhiều tác vụ liên quan đến PowerPoint.

Bài viết so sánh cả hai lựa chọn dựa trên các định dạng được hỗ trợ, mô hình lập trình, khả năng render, hỗ trợ nền tảng và các trường hợp sử dụng phổ biến. Nó cũng làm rõ rằng Open XML SDK có thể phù hợp cho các thao tác PPTX cơ bản hoặc truy cập trực tiếp vào các phần tử OOXML, trong khi Aspose.Slides thích hợp hơn cho các nhiệm vụ trình chiếu phức tạp như làm việc với nhiều định dạng PowerPoint, sao chép hoặc nhân bản hình dạng, thay thế văn bản, áp dụng hoạt ảnh và chuyển đổi trình chiếu sang PDF, TIFF hoặc XPS.

## **Open XML SDK là gì?**
Theo [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK được định nghĩa là:

Open XML SDK 2.0 đơn giản hoá việc thao tác các gói Open XML và các phần tử schema Open XML cơ bản trong một gói. Open XML SDK 2.0 gói gọn nhiều tác vụ phổ biến mà các nhà phát triển thực hiện trên các gói Open XML, cho phép bạn thực hiện các thao tác phức tạp chỉ với vài dòng mã.

Các tài liệu OOXML thực chất là các tệp XML nén và Open XML SDK là một tập hợp các lớp cho phép bạn làm việc với nội dung của tài liệu OOXML một cách gõ mạnh. Thay vì giải nén tệp để trích xuất XML, tải XML vào cây DOM và làm việc trực tiếp với các phần tử và thuộc tính XML, Open XML SDK cung cấp các lớp để thực hiện việc này.

## **Aspose.Slides là gì?**
Aspose.Slides là một thư viện lớp cho phép ứng dụng của bạn thực hiện các tác vụ xử lý trình chiếu sau:

- Lập trình với mô hình đối tượng **Presentation**.
- Chuyển đổi chất lượng cao giữa tất cả các định dạng trình chiếu PowerPoint phổ biến được hỗ trợ, bao gồm chuyển đổi sang PDF, XPS và TIFF.
- Khả năng tạo thumbnails slide ở các định dạng quen thuộc như PNG, JPEG và BMP cùng với xuất slide sang SVG.
- Khả năng xây dựng trình chiếu từ đầu hoặc bằng cách kết hợp từ một hoặc nhiều tài liệu.
- Hỗ trợ thêm hoạt ảnh, Ole Frames, Tables, tạo và quản lý biểu đồ.
- Cung cấp kiểm soát mở rộng cho việc quản lý định dạng văn bản ở mức TextFrames, Paragraphs và Portions.

Để biết chi tiết về các tính năng được hỗ trợ, vui lòng truy cập [Aspose.Slides Features](/slides/vi/php-java/product-overview/).

## **So sánh Open XML SDK và Aspose.Slides**
{{% alert color="info" %}} 

Bảng dưới đây so sánh các tính năng của Open XML SDK và Aspose.Slides.

{{% /alert %}} 

|**Tính năng hoặc Danh mục Tính năng**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Định dạng trình chiếu được hỗ trợ|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Chuyển đổi từ PPT sang PPTX|No|Yes|
|<p>Lập trình cấp cao với Presentation Document Object Model (DOM):</p><p>- Tìm và thay thế văn bản.</p><p>- Lắp ráp các slide trong bài thuyết trình.</p>|No|Yes|
|Lập trình chi tiết với mô hình đối tượng tài liệu, truy cập các phần tử riêng lẻ và định dạng như TextHolders, TextFrames, Paragraphs và Portions.|Yes|Yes|
|Truy cập cấp thấp, trực tiếp và đầy đủ vào các phần tử XML và thuộc tính cơ bản như định danh quan hệ, định danh danh sách của tài liệu OOXML.|Yes|No|
|<p>Render:</p><p>- Render trình chiếu sang PDF, PDF Notes, XPS, hình ảnh TIFF.</p><p>- Render thumbnails slide sang PNG, JPEG, BMP, SVG và TIFF.</p><p>- Chỉ định độ phân giải ảnh, chất lượng, nén và các tùy chọn khác.</p>|No|Yes |
|Nền tảng được hỗ trợ|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Kết luận**
{{% alert color="info" %}} 

Open XML SDK và Aspose.Slides không cạnh tranh trực tiếp vì chúng đáp ứng các nhu cầu và đối tượng người dùng khác nhau. Open XML SDK là một thư viện lớp cung cấp cách làm việc gõ mạnh với tài liệu OOXML. Aspose.Slides là một thư viện xử lý trình chiếu rất hữu ích, cung cấp hỗ trợ tuyệt vời cho hầu hết các định dạng tệp Microsoft PowerPoint.

Nếu bạn chỉ cần thực hiện một thao tác lập trình khá cơ bản trên tài liệu PPTX, thì Open XML SDK có thể là lựa chọn phù hợp. Với Open XML SDK, bạn sẽ thoải mái thực hiện các nhiệm vụ đơn giản như tạo một tài liệu PPTX đơn giản hoặc xóa bình luận, tiêu đề/chân trang, trích xuất hình ảnh hoặc các tác vụ khác. Một số nhiệm vụ có thể thực hiện được bằng Open XML SDK, nhưng không thể đạt được bằng Aspose.Slides. Ví dụ, nếu bạn cần truy cập trực tiếp vào các phần tử và thuộc tính XML của một tài liệu OOXML, thì nên sử dụng Open XML SDK. Tuy nhiên, nếu bạn cần thực hiện các thao tác phức tạp trên tài liệu, như một số nhiệm vụ sau, thì việc sử dụng Aspose.Slides là lựa chọn tốt nhất:

- Hỗ trợ các định dạng PowerPoint cũ bên cạnh PPTX.
- Sao chép hoặc nhân bản hình dạng trong slide theo cách kết hợp đối tượng, kiểu dáng và các định dạng khác một cách thích hợp.
- Thay thế văn bản có định dạng hoặc không định dạng.
- Áp dụng hoạt ảnh và sử dụng connector với các hình dạng được dùng.
- Chuyển đổi tài liệu sang PDF, TIFF hoặc XPS sao cho hiển thị chính xác như Microsoft PowerPoint sẽ chuyển đổi.
- Phát triển ứng dụng .NET hoặc Java trong cả môi trường desktop và web.

{{% /alert %}}