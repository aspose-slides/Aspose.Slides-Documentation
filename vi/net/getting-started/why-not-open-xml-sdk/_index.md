---
title: Tại sao không nên dùng Open XML SDK
type: docs
weight: 50
url: /vi/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- so sánh
- mô hình đối tượng trình chiếu
- chuyển đổi chất lượng cao
- PowerPoint
- OpenDocument
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem vì sao Aspose.Slides là lựa chọn tốt hơn so với Open XML SDK miễn phí: so sánh tính năng, chuyển đổi không cần tự động hoá, và hỗ trợ rộng rãi cho PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích khi nào các nhà phát triển có thể chọn Open XML SDK hoặc Aspose.Slides để làm việc với tài liệu trình chiếu. Nó mô tả Open XML SDK là một thư viện để thao tác các gói OOXML và các yếu tố XML cơ bản của chúng, trong khi Aspose.Slides được giới thiệu là một thư viện xử lý trình chiếu với mô hình đối tượng cấp cao và hỗ trợ nhiều tác vụ liên quan tới PowerPoint.

Bài viết so sánh hai lựa chọn dựa trên các định dạng được hỗ trợ, mô hình lập trình, việc render, hỗ trợ nền tảng và các trường hợp sử dụng phổ biến. Nó cũng làm rõ rằng Open XML SDK có thể phù hợp cho các thao tác PPTX cơ bản hoặc truy cập trực tiếp vào các yếu tố OOXML, trong khi Aspose.Slides thích hợp hơn cho các tác vụ trình chiếu phức tạp như làm việc với nhiều định dạng PowerPoint, sao chép hoặc nhân bản hình dạng, thay thế văn bản, áp dụng hoạt ảnh và chuyển đổi trình chiếu sang PDF, TIFF hoặc XPS.

## **Open XML SDK là gì?**
Đôi khi, chúng tôi nhận được câu hỏi: *Tại sao chúng ta nên sử dụng sản phẩm Aspose thay vì Open XML SDK miễn phí?* 

Chúng tôi dễ dàng trả lời câu hỏi này dựa trên tính năng và chức năng. 

Theo [Thư viện MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK được định nghĩa như sau: 

> "Open XML SDK 2.0 đơn giản hoá việc thao tác các gói Open XML và các yếu tố lược đồ Open XML bên trong một gói. Open XML SDK 2.0 gói ghém nhiều tác vụ chung mà các nhà phát triển thực hiện trên các gói Open XML, cho phép bạn thực hiện các thao tác phức tạp chỉ với vài dòng mã. Các tài liệu OOXML về bản chất là các tệp XML nén và Open XML SDK là một tập hợp các lớp cho phép bạn làm việc với nội dung của tài liệu OOXML theo cách có kiểu mạnh. Thay vì giải nén tệp để trích xuất XML, tải XML vào cây DOM và làm việc trực tiếp với các yếu tố và thuộc tính XML, Open XML SDK cung cấp các lớp để thực hiện điều đó."

## **Aspose.Slides là gì?**
Aspose.Slides là một thư viện lớp cho phép các ứng dụng thực hiện các tác vụ xử lý trình chiếu sau: 

- Lập trình với mô hình đối tượng trình chiếu. 

- Chuyển đổi chất lượng cao cho mọi định dạng trình chiếu PowerPoint phổ biến, bao gồm chuyển đổi sang PDF, XPS và TIFF. 

- Tạo thumbnail slide ở các định dạng quen thuộc như PNG, JPEG và BMP cùng với việc xuất slide sang SVG. 

- Xây dựng trình chiếu từ đầu hoặc bằng cách kết hợp các yếu tố từ một hoặc nhiều tài liệu. 

- Thêm hoạt ảnh, OLE Frame, bảng, tạo và quản lý biểu đồ. 

- Kiểm soát (kiểm soát mở rộng) và quản lý định dạng văn bản ở mức TextFrames, Paragraphs và Portions.  

  Để biết thêm chi tiết về các tính năng có sẵn, vui lòng xem trang [Tính năng Aspose.Slides](/slides/vi/net/product-overview/). 

## **So sánh Open XML SDK và Aspose.Slides**
Bảng dưới đây so sánh khả năng và tính năng của Open XML SDK với Aspose.Slides.

|**Tính năng hoặc Nhóm tính năng**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Định dạng trình chiếu được hỗ trợ|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Chuyển đổi từ PPT sang PPTX|Không|Có|
|<p>Lập trình cấp cao với Mô hình Đối tượng Tài liệu Trình chiếu (DOM):</p><p>- Tìm và thay thế văn bản.</p><p>- Ghép slide trong trình chiếu.</p>|Không|Có|
|Lập trình chi tiết với mô hình đối tượng tài liệu; truy cập các yếu tố và định dạng riêng lẻ như TextHolders, TextFrames, Paragraphs và Portions.|Có|Có|
|Truy cập trực tiếp và đầy đủ ở cấp thấp tới các yếu tố XML và thuộc tính cơ bản như định danh quan hệ, định danh danh sách của tài liệu OOXML.|Có|Không|
|<p>Render trình chiếu:</p><p>- Render trình chiếu sang PDF, PDF Notes, XPS, ảnh TIFF.</p><p>- Render thumbnail slide sang PNG, JPEG, BMP, SVG và TIFF.</p><p>- Xác định độ phân giải ảnh, chất lượng, nén và các tùy chọn khác.</p>|Không|Có|
|Nền tảng được hỗ trợ|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Kết luận**
Open XML SDK và Aspose.Slides không cạnh tranh trực tiếp vì chúng đáp ứng những nhu cầu hoàn toàn khác nhau và nhắm tới các đối tượng người dùng khác nhau. 

{{% alert color="info" %}} 

Open XML SDK là một thư viện lớp cung cấp cách làm việc với tài liệu OOXML theo kiểu mạnh, trong khi Aspose.Slides là một thư viện xử lý trình chiếu cực kỳ hữu ích, hỗ trợ gần như tất cả các định dạng file Microsoft PowerPoint. 

{{% /alert %}} 

Nếu quy trình làm việc của bạn chỉ là một thao tác lập trình cơ bản trên tài liệu PPTX, thì Open XML SDK có thể là lựa chọn tốt. Với Open XML SDK, bạn sẽ thoải mái thực hiện các nhiệm vụ đơn giản như tạo một tài liệu PPTX đơn giản hoặc xóa nhận xét, đầu/đuôi trang, trích xuất hình ảnh hoặc các tác vụ tương tự. Một số nhiệm vụ có thể được thực hiện bằng Open XML SDK nhưng không thể thực hiện bằng Aspose.Slides. Ví dụ, nếu bạn cần truy cập trực tiếp các yếu tố và thuộc tính XML của một tài liệu OOXML, thì bạn nên sử dụng Open XML SDK. 

Nếu bạn cần thực hiện các nhiệm vụ phức tạp trên tài liệu—như các nhiệm vụ trong danh sách dưới đây—thì Aspose.Slides là lựa chọn tốt nhất. 

- Các thao tác liên quan tới các định dạng PowerPoint cũ (và cả PPTX). 
- Sao chép hoặc nhân bản hình dạng trong slide theo cách kết hợp đối tượng, kiểu dáng và các yếu tố định dạng khác một cách thích hợp. 
- Thay thế văn bản có định dạng hoặc không có định dạng. 
- Áp dụng hoạt ảnh và sử dụng connector với các hình dạng. 
- Chuyển đổi tài liệu sang PDF, TIFF hoặc XPS sao cho kết quả giống như Microsoft PowerPoint đã thực hiện chuyển đổi. 
- Phát triển ứng dụng .NET hoặc Java trong môi trường desktop và web.