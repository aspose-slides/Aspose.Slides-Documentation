---
title: Tại sao không dùng Open XML SDK
type: docs
weight: 100
url: /vi/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- so sánh
- mô hình đối tượng trình chiếu
- chuyển đổi chất lượng cao
- PowerPoint
- OpenDocument
- trình chiếu
- C++
- Aspose.Slides
description: "Xem lý do tại sao Aspose.Slides là lựa chọn tốt hơn so với Open XML SDK miễn phí: so sánh tính năng, chuyển đổi không cần tự động hoá, và hỗ trợ rộng rãi cho PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích khi nào các nhà phát triển có thể chọn Open XML SDK hoặc Aspose.Slides để làm việc với tài liệu trình chiếu. Nó mô tả Open XML SDK là thư viện để thao tác các gói OOXML và các phần tử XML nền tảng của chúng, trong khi Aspose.Slides được giới thiệu là thư viện xử lý trình chiếu với mô hình đối tượng cấp cao và hỗ trợ nhiều nhiệm vụ liên quan đến PowerPoint.

Bài viết so sánh cả hai lựa chọn dựa trên các định dạng được hỗ trợ, mô hình lập trình, khả năng render và in, hỗ trợ nền tảng, và các trường hợp sử dụng phổ biến. Nó cũng làm rõ rằng Open XML SDK có thể phù hợp cho các thao tác PPTX cơ bản hoặc truy cập trực tiếp vào các phần tử OOXML, trong khi Aspose.Slides thích hợp hơn cho các nhiệm vụ trình chiếu phức tạp như làm việc với nhiều định dạng PowerPoint, sao chép hoặc nhân bản hình dạng, thay thế văn bản, áp dụng hoạt ảnh, và chuyển đổi trình chiếu sang PDF, TIFF hoặc XPS.

## **Open XML SDK là gì?**
Chúng ta đôi khi nghe câu hỏi này: Tại sao chúng ta nên sử dụng sản phẩm Aspose thay vì Open XML SDK miễn phí? Câu hỏi này dễ trả lời: tính năng và chức năng. Theo [Thư viện MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK được định nghĩa là: Open XML SDK 2.0 đơn giản hoá nhiệm vụ thao tác các gói Open XML và các phần tử sơ đồ Open XML nền tảng trong một gói. Open XML SDK 2.0 bao hàm nhiều nhiệm vụ chung mà các nhà phát triển thực hiện trên các gói Open XML, vì vậy bạn có thể thực hiện các thao tác phức tạp chỉ với vài dòng mã. Tài liệu OOXML về cơ bản là các tệp XML nén và Open XML SDK là tập hợp các lớp cho phép bạn làm việc với nội dung tài liệu OOXML theo cách kiểu mạnh. Thay vì giải nén một tệp để trích xuất XML, tải XML vào cây DOM và làm việc trực tiếp với các phần tử và thuộc tính XML, Open XML SDK cung cấp các lớp để thực hiện điều đó.

## **Aspose.Slides là gì?**
Aspose.Slides là một thư viện lớp cho phép ứng dụng của bạn thực hiện các nhiệm vụ xử lý trình chiếu sau:

- Lập trình với mô hình đối tượng **Presentation**.
- Chuyển đổi chất lượng cao giữa tất cả các định dạng trình chiếu PowerPoint phổ biến được hỗ trợ, bao gồm chuyển đổi sang PDF và XPS.
- Khả năng tạo thumbnail slide ở các định dạng quen thuộc như PNG, JPEG và BMP cùng với xuất slide sang SVG.
- Khả năng xây dựng trình chiếu từ đầu hoặc bằng cách kết hợp từ một hoặc nhiều tài liệu.
- Hỗ trợ thêm hoạt ảnh, Ole Frames, Tables, tạo và quản lý charts.
- Cung cấp kiểm soát rộng rãi cho việc quản lý định dạng văn bản trên các cấp TextFrames, Paragraphs và Portions.
  Để biết thêm chi tiết về các tính năng được hỗ trợ, vui lòng truy cập [Tính năng Aspose.Slides](/slides/vi/cpp/product-overview/).

## **So sánh Open XML SDK và Aspose.Slides**
Bảng sau so sánh các tính năng của Open XML SDK và Aspose.Slides.

|**Tính năng hoặc Danh mục tính năng**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Định dạng bản trình chiếu được hỗ trợ|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Chuyển đổi từ PPT sang PPTX|No|Yes|
|<p>Lập trình cấp cao với mô hình đối tượng tài liệu trình chiếu (DOM):</p><p>- Tìm và thay thế văn bản.</p><p>- Tập hợp các slide trong trình chiếu.</p>|No|Yes|
|Lập trình chi tiết với mô hình đối tượng tài liệu, truy cập các phần tử riêng lẻ và định dạng như TextHolders, TextFrames, Paragraphs và Portions.|Yes|Yes|
|Truy cập trực tiếp và đầy đủ mức thấp vào các phần tử và thuộc tính XML nền tảng như định danh quan hệ, định danh danh sách của tài liệu OOXML.|Yes|No|
|<p>Render:</p><p>- Render trình chiếu sang PDF, PDF Notes, XPS, ảnh TIFF.</p><p>- Render thumbnail slide sang PNG, JPEG, BMP, SVG và TIFF.</p><p>- Chỉ định độ phân giải ảnh, chất lượng, nén và các tùy chọn khác.</p>|No|Yes|

## **Kết luận**
Open XML SDK và Aspose.Slides không cạnh tranh trực tiếp vì chúng phục vụ những nhu cầu và đối tượng khác nhau. Open XML SDK là một thư viện lớp cung cấp cách làm việc kiểu mạnh với tài liệu OOXML. Aspose.Slides là một thư viện xử lý trình chiếu rất hữu ích, cung cấp hỗ trợ tuyệt vời cho hầu hết các định dạng file Microsoft PowerPoint. Nếu tất cả những gì bạn cần là một thao tác lập trình cơ bản trên tài liệu PPTX, thì Open XML SDK có thể là lựa chọn phù hợp. Với Open XML SDK, bạn sẽ cảm thấy thoải mái với các tác vụ đơn giản như tạo một tài liệu PPTX đơn giản hoặc xóa bình luận, header/footer, trích xuất hình ảnh hoặc các công việc tương tự. Một số tác vụ có thể đạt được bằng Open XML SDK, nhưng không thể thực hiện bằng Aspose.Slides. Ví dụ, nếu bạn cần truy cập trực tiếp vào các phần tử và thuộc tính XML của một tài liệu OOXML, thì bạn nên sử dụng Open XML SDK. Tuy nhiên, nếu bạn cần thực hiện các thao tác phức tạp trên tài liệu, chẳng hạn như một số nhiệm vụ sau, thì việc sử dụng Aspose.Slides là lựa chọn tốt nhất:

- Hỗ trợ các định dạng PowerPoint cũ ngoài PPTX.
- Sao chép hoặc nhân bản hình dạng trong slide theo cách kết hợp các đối tượng, kiểu và các định dạng khác một cách phù hợp.
- Thay thế văn bản đã định dạng hoặc chưa định dạng.
- Áp dụng hoạt ảnh và sử dụng kết nối với các hình dạng.
- Chuyển đổi tài liệu sang PDF hoặc XPS để nó hiển thị chính xác như Microsoft PowerPoint sẽ chuyển đổi.
- Phát triển ứng dụng C++ trong cả môi trường desktop và console.