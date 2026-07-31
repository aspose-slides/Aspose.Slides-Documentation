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
description: "Xem tại sao Aspose.Slides là lựa chọn tốt hơn so với Open XML SDK miễn phí: so sánh các tính năng, chuyển đổi không cần tự động hoá, và hỗ trợ rộng rãi cho PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích khi nào các nhà phát triển có thể chọn Open XML SDK hoặc Aspose.Slides để làm việc với tài liệu trình chiếu. Nó mô tả Open XML SDK là một thư viện để thao tác các gói OOXML và các phần tử XML bên trong, trong khi Aspose.Slides được giới thiệu như một thư viện xử lý trình chiếu với mô hình đối tượng cấp cao và hỗ trợ nhiều tác vụ liên quan đến PowerPoint.

Bài viết so sánh cả hai lựa chọn dựa trên các định dạng được hỗ trợ, mô hình lập trình, khả năng kết xuất và in, hỗ trợ nền tảng, và các trường hợp sử dụng phổ biến. Nó cũng làm rõ rằng Open XML SDK có thể phù hợp cho các thao tác PPTX cơ bản hoặc truy cập trực tiếp vào các phần tử OOXML, trong khi Aspose.Slides thích hợp hơn cho các nhiệm vụ trình chiếu phức tạp như làm việc với nhiều định dạng PowerPoint, sao chép hoặc nhân bản hình dạng, thay thế văn bản, áp dụng hoạt ảnh, và chuyển đổi trình chiếu sang PDF, TIFF hoặc XPS.

## **Open XML SDK là gì?**
Đôi khi, chúng tôi nhận được câu hỏi này: *Tại sao chúng ta nên dùng sản phẩm của Aspose thay vì Open XML SDK miễn phí?* 

Chúng tôi thấy dễ dàng trả lời câu hỏi này dựa trên tính năng và chức năng. 

Theo [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK được định nghĩa như sau: 

> "Open XML SDK 2.0 đơn giản hoá nhiệm vụ thao tác các gói Open XML và các phần tử sơ đồ Open XML nằm bên trong một gói. Open XML SDK 2.0 gói lại nhiều tác vụ phổ biến mà các nhà phát triển thực hiện trên các gói Open XML, cho phép bạn thực hiện các thao tác phức tạp chỉ với vài dòng mã. Các tài liệu OOXML về cơ bản là các tệp XML được nén zip và Open XML SDK là một tập hợp các lớp cho phép bạn làm việc với nội dung của tài liệu OOXML theo cách mạnh kiểu. Thay vì giải nén tệp để trích xuất XML, tải XML đó vào cây DOM và làm việc trực tiếp với các phần tử và thuộc tính XML, Open XML SDK cung cấp các lớp để thực hiện việc này."

## **Aspose.Slides là gì?**
Aspose.Slides là một thư viện lớp cho phép các ứng dụng thực hiện những tác vụ xử lý trình chiếu sau: 

- Lập trình với mô hình đối tượng trình chiếu.  
- Chuyển đổi chất lượng cao bao gồm tất cả các định dạng trình chiếu PowerPoint được hỗ trợ, bao gồm chuyển đổi sang PDF, XPS, TIFF và in.  
- Tạo ảnh thu nhỏ slide ở các định dạng phổ biến như PNG, JPEG và BMP cùng với việc xuất slide sang SVG.  
- Xây dựng trình chiếu từ đầu hoặc bằng cách kết hợp các yếu tố từ một hoặc nhiều tài liệu.  
- Thêm hoạt ảnh, OLE Frame, bảng, tạo và quản lý biểu đồ.  
- Kiểm soát (kiểm soát mở rộng) và quản lý định dạng văn bản trên các cấp độ TextFrames, Paragraphs và Portions.  

Để biết thêm chi tiết về các tính năng có sẵn, vui lòng xem trang [Aspose.Slides Features](/slides/vi/net/product-overview/).

## **So sánh Open XML SDK với Aspose.Slides**
Bảng sau so sánh khả năng và tính năng của Open XML SDK với Aspose.Slides.

|**Tính năng hoặc Danh mục Tính năng**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Các định dạng trình chiếu được hỗ trợ|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Chuyển đổi từ PPT sang PPTX|No|Yes|
|<p>Lập trình cấp cao với Presentation Document Object Model (DOM): </p><p>- Tìm và thay thế văn bản.</p><p>- Tập hợp các slide trong trình chiếu.</p>|No|Yes|
|Lập trình chi tiết với mô hình đối tượng tài liệu; truy cập vào các phần tử riêng lẻ và định dạng như TextHolders, TextFrames, Paragraphs và Portions.|Yes|Yes|
|Truy cập trực tiếp và đầy đủ ở mức thấp vào các phần tử và thuộc tính XML bên dưới như định danh quan hệ, định danh danh sách của tài liệu OOXML.|Yes|No|
|<p>Kết xuất và In:</p><p>- Kết xuất trình chiếu sang PDF, PDF Notes, XPS, hình ảnh TIFF.</p><p>- Kết xuất ảnh thu nhỏ slide sang PNG, JPEG, BMP, SVG và TIFF.</p><p>- Chỉ định độ phân giải hình ảnh, chất lượng, nén và các tùy chọn khác.</p><p>- In trình chiếu bằng cơ sở hạ tầng in của .NET. Thành phần có phương thức in tích hợp để in trình chiếu như hiển thị trong Print Preview của MS PowerPoint.</p>|No|Yes|
|Nền tảng được hỗ trợ|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Kết luận**
Open XML SDK và Aspose.Slides không cạnh tranh trực tiếp vì chúng đáp ứng các nhu cầu khác nhau đáng kể, và hướng tới các đối tượng người dùng khác nhau. 

{{% alert color="primary" %}} 
Open XML SDK là một thư viện lớp cung cấp cách làm việc với tài liệu OOXML theo kiểu mạnh, trong khi Aspose.Slides là một thư viện xử lý trình chiếu vô cùng hữu ích, cung cấp hỗ trợ tuyệt vời cho hầu hết các định dạng tệp Microsoft PowerPoint. 
{{% /alert %}} 

Nếu quy trình của bạn là một thao tác lập trình cơ bản trên tài liệu PPTX, thì Open XML SDK có thể là lựa chọn tốt. Với Open XML SDK, bạn nên cảm thấy thoải mái khi thực hiện các nhiệm vụ đơn giản như tạo một tài liệu PPTX đơn giản, hoặc xoá bình luận, header/footer, trích xuất hình ảnh hoặc các công việc khác. Một số nhiệm vụ có thể thực hiện được bằng Open XML SDK nhưng không thể thực hiện bằng Aspose.Slides. Ví dụ, nếu bạn cần truy cập trực tiếp các phần tử và thuộc tính XML của một tài liệu OOXML, thì bạn nên sử dụng Open XML SDK. 

Nếu bạn cần thực hiện các nhiệm vụ phức tạp trên tài liệu—như các nhiệm vụ trong danh sách dưới đây—thì Aspose.Slides là lựa chọn tốt nhất. 

- Các thao tác liên quan đến các định dạng PowerPoint cũ (và PPTX nữa).  
- Sao chép hoặc nhân bản các hình dạng trong slide một cách kết hợp các đối tượng, kiểu dáng và các yếu tố định dạng khác một cách thích hợp.  
- Thay thế văn bản đã định dạng hoặc chưa định dạng.  
- Áp dụng hoạt ảnh và sử dụng connector với các hình dạng.  
- Chuyển đổi tài liệu sang PDF, TIFF hoặc XPS sao cho kết quả giống như Microsoft PowerPoint thực hiện chuyển đổi.  
- Phát triển ứng dụng .NET hoặc Java trong cả môi trường desktop và web.