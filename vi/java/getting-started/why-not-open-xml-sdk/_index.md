---
title: Tại sao không nên dùng Open XML SDK
type: docs
weight: 120
url: /vi/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- so sánh
- mô hình đối tượng trình chiếu
- chuyển đổi chất lượng cao
- PowerPoint
- OpenDocument
- trình chiếu
- Java
- Aspose.Slides
description: "Xem tại sao Aspose.Slides là lựa chọn tốt hơn so với Open XML SDK miễn phí: so sánh các tính năng, chuyển đổi không cần tự động hoá, và hỗ trợ rộng rãi cho PPT, PPTX và ODP."
---
## **Tổng quan**

Bài viết này giải thích khi nào các nhà phát triển có thể chọn Open XML SDK hoặc Aspose.Slides để làm việc với tài liệu trình chiếu. Nó mô tả Open XML SDK là một thư viện để thao tác các gói OOXML và các phần tử XML bên trong, trong khi Aspose.Slides được giới thiệu như một thư viện xử lý trình chiếu với mô hình đối tượng cấp cao và hỗ trợ nhiều tác vụ liên quan đến PowerPoint.

Bài viết so sánh cả hai tùy chọn dựa trên các định dạng được hỗ trợ, mô hình lập trình, khả năng kết xuất và in, hỗ trợ nền tảng và các trường hợp sử dụng phổ biến. Nó cũng làm rõ rằng Open XML SDK có thể phù hợp cho các thao tác PPTX cơ bản hoặc truy cập trực tiếp vào các phần tử OOXML, trong khi Aspose.Slides thích hợp hơn cho các tác vụ trình chiếu phức tạp như làm việc với nhiều định dạng PowerPoint, sao chép hoặc nhân bản các hình dạng, thay thế văn bản, áp dụng hoạt ảnh và chuyển đổi trình chiếu sang PDF, TIFF hoặc XPS.

## **Open XML SDK là gì?**
Theo [Thư viện MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK được định nghĩa là:

The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open 
XML packages, so that you can perform complex operations with just a few lines of code.

OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to 
extract XML, loading that XML into a DOM tree and working with XML elements and attributes directly, Open XML SDK provides classes to do that.

## **Aspose.Slides là gì?**
Aspose.Slides là một thư viện lớp cho phép ứng dụng của bạn thực hiện các tác vụ xử lý trình chiếu sau:

- Lập trình với mô hình đối tượng **Presentation**.
- Chuyển đổi chất lượng cao giữa tất cả các định dạng trình chiếu PowerPoint được hỗ trợ, bao gồm chuyển đổi sang PDF, XPS và TIFF.
- Khả năng tạo thumbnail slide ở các định dạng phổ biến như PNG, JPEG và BMP cùng với xuất slide ra SVG.
- Khả năng xây dựng trình chiếu từ đầu hoặc bằng cách kết hợp từ một hoặc nhiều tài liệu.
- Hỗ trợ thêm hoạt ảnh, Ole Frames, Bảng, tạo và quản lý biểu đồ.
- Cung cấp khả năng kiểm soát mở rộng cho việc quản lý định dạng văn bản trên các mức TextFrames, Paragraphs và Portions.

Để biết thêm chi tiết về các tính năng được hỗ trợ, vui lòng truy cập [Tính năng Aspose.Slides](/slides/vi/java/product-overview/).

## **So sánh Open XML SDK với Aspose.Slides**
{{% alert color="primary" %}} 

Bảng sau so sánh các tính năng của Open XML SDK và Aspose.Slides.

{{% /alert %}} 

|**Tính năng hoặc Danh mục tính năng**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Định dạng trình chiếu được hỗ trợ|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Chuyển đổi từ PPT sang PPTX|Không|Có|
|<p>Lập trình cấp cao với Mô hình Đối tượng Tài liệu Trình chiếu (DOM):</p><p>- Tìm và thay thế văn bản.</p><p>- Tập hợp các slide trong trình chiếu.</p>|Không|Có|
|Lập trình chi tiết với mô hình đối tượng tài liệu, truy cập vào các phần tử riêng lẻ và định dạng như TextHolders, TextFrames, Paragraphs và Portions.|Có|Có|
|Truy cập trực tiếp và đầy đủ cấp thấp vào các phần tử XML và thuộc tính cơ bản như định danh quan hệ, định danh danh sách của tài liệu OOXML.|Có|Không|
|<p>Kết xuất:</p><p>- Kết xuất trình chiếu sang PDF, PDF Notes, XPS, ảnh TIFF.</p><p>- Kết xuất thumbnail slide sang PNG, JPEG, BMP, SVG và TIFF.</p><p>- Chỉ định độ phân giải hình ảnh, chất lượng, nén và các tùy chọn khác.</p>|Không|Có|
|Nền tảng được hỗ trợ|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Kết luận**
{{% alert color="primary" %}} 

Open XML SDK và Aspose.Slides không cạnh tranh trực tiếp vì chúng đáp ứng các nhu cầu và đối tượng khác nhau. Open XML SDK là một thư viện lớp cung cấp cách làm việc kiểu mạnh với tài liệu OOXML. Aspose.Slides là một thư viện xử lý trình chiếu rất hữu ích, cung cấp hỗ trợ tuyệt vời cho hầu hết các định dạng tệp Microsoft PowerPoint.

Nếu bạn chỉ cần thực hiện một thao tác lập trình khá cơ bản trên tài liệu PPTX, thì Open XML SDK có thể là lựa chọn phù hợp. Với Open XML SDK bạn sẽ cảm thấy thoải mái khi thực hiện các nhiệm vụ đơn giản như tạo một tài liệu PPTX đơn giản hoặc xóa bình luận, đầu/trước, trích xuất hình ảnh hoặc các thao tác khác. Một số nhiệm vụ có thể đạt được với Open XML SDK, nhưng không thể đạt được với Aspose.Slides. Ví dụ, nếu bạn cần truy cập trực tiếp vào các phần tử và thuộc tính XML của tài liệu OOXML, thì nên sử dụng Open XML SDK. Tuy nhiên, nếu bạn cần thực hiện các thao vụ phức tạp trên tài liệu, chẳng hạn như một số nhiệm vụ sau, thì sử dụng Aspose.Slides là lựa chọn tốt nhất:

- Hỗ trợ các định dạng PowerPoint cũ hơn ngoài PPTX.
- Sao chép hoặc nhân bản các hình dạng trong slide một cách kết hợp các đối tượng, kiểu dáng và các định dạng khác một cách thích hợp.
- Thay thế văn bản có định dạng hoặc không định dạng.
- Áp dụng hoạt ảnh và sử dụng kết nối giữa các hình dạng.
- Chuyển đổi tài liệu sang PDF, TIFF hoặc XPS để hiển thị chính xác như Microsoft PowerPoint sẽ chuyển đổi.
- Phát triển ứng dụng .NET hoặc Java trong cả môi trường desktop và web.

{{% /alert %}}