---
title: "Tại sao không nên tự động hoá"
type: docs
weight: 40
url: /vi/net/why-not-automation/
keywords:
- tự động hoá
- Microsoft Office
- so sánh
- bảo mật
- độ ổn định
- khả năng mở rộng
- tính năng
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khám phá lý do tại sao tự động hoá Office có rủi ro đối với máy chủ và dịch vụ, và xem cách Aspose.Slides cung cấp quá trình xử lý bản trình bày an toàn hơn, nhanh hơn cho PowerPoint và OpenDocument."
---
## **Giới thiệu**

Có một số lý do khiến các thành phần Aspose là lựa chọn thay thế tốt hơn cho việc tự động hoá. Một số lý do chính bao gồm:

- Bảo mật
- Độ ổn định
- Khả năng mở rộng/Tốc độ
- Giá cả
- Tính năng

Dưới đây là giải thích chi tiết hơn về mỗi điểm chính.

## **Câu hỏi quan trọng**

Có hai câu hỏi mà chúng tôi thường nghe tại Aspose:

- Sản phẩm của bạn có yêu cầu cài đặt Microsoft Office để chạy không?

Câu trả lời ngắn gọn và đơn giản là **KHÔNG**.

Các thành phần Aspose hoàn toàn độc lập và không liên quan, không được ủy quyền, không được tài trợ hoặc được Microsoft Corporation chấp thuận theo bất kỳ cách nào.

- Tại sao chúng ta nên sử dụng các sản phẩm Aspose thay vì Microsoft Office Automation?

Đầu tiên, có nhiều [lợi ích bạn nhận được khi sử dụng Aspose.Slides](/slides/vi/net/product-overview/).

Thứ hai, Microsoft tự mình mạnh mẽ **khuyên không** sử dụng Office Automation trong các giải pháp phần mềm.

## **Bảo mật**
Dưới đây là trích dẫn trực tiếp từ một Bài viết của Microsoft:

> "Office Applications không bao giờ được thiết kế để sử dụng phía máy chủ, do đó không xem xét các vấn đề bảo mật mà các thành phần phân tán gặp phải. Office không xác thực các yêu cầu đến và không bảo vệ bạn khỏi việc vô tình chạy macro, hoặc khởi động một máy chủ khác có thể chạy macro, từ mã phía máy chủ của bạn. Đừng mở các tệp được tải lên máy chủ từ một trang web ẩn danh! Dựa trên các cài đặt bảo mật được thiết lập lần cuối, máy chủ có thể chạy macro dưới ngữ cảnh Administrator hoặc System với đầy đủ quyền và làm suy yếu mạng của bạn! Thêm vào đó, Office sử dụng nhiều thành phần phía khách (như Simple MAPI, WinInet, MSDAIPP) có thể lưu trữ thông tin xác thực của khách để tăng tốc xử lý. Nếu Office được tự động hoá phía máy chủ, một thể hiện có thể phục vụ hơn một khách hàng, và vì thông tin xác thực đã được lưu trong phiên, có khả năng một khách hàng sử dụng thông tin xác thực đã lưu của khách khác, từ đó giành được quyền truy cập không được cấp phép bằng cách mạo danh người dùng khác."

Các sản phẩm Aspose rất **bảo mật**. Các thành phần Aspose chạy trong cùng ngữ cảnh người dùng như tất cả các ứng dụng ASP.NET (dưới người dùng ASPNET). Do đó, các thành phần Aspose **không** gây ra rủi ro bảo mật. Chúng cũng không tiêu tốn tài nguyên hệ thống quan trọng. Hơn nữa, khi một thành phần Aspose mở tài liệu, macro sẽ không tự động chạy. Các thành phần Aspose được xây dựng để cho phép nhà phát triển tạo, thao tác và lưu các tệp Office.

{{% alert color="primary" %}} 

Không có rủi ro nào liên quan đến gói Microsoft Office áp dụng cho các thành phần Aspose. 

{{% /alert %}} 

## **Độ ổn định**
Đoạn văn này là trích dẫn trực tiếp từ Bài viết Microsoft đã nêu trên:

> "Office 2000, Office XP và Office 2003 sử dụng công nghệ Microsoft Windows Installer (MSI) để việc cài đặt và tự sửa chữa trở nên dễ dàng hơn cho người dùng cuối. MSI giới thiệu khái niệm “cài đặt lần đầu sử dụng”, cho phép các tính năng được cài đặt hoặc cấu hình động tại thời gian chạy (cho hệ thống, hoặc thường hơn cho một người dùng cụ thể). Trong môi trường phía máy chủ, điều này làm chậm hiệu năng và tăng khả năng xuất hiện hộp thoại yêu cầu người dùng chấp nhận cài đặt hoặc cung cấp đĩa cài đặt phù hợp. Mặc dù được thiết kế để tăng cường độ bền vững của Office như một sản phẩm người dùng cuối, việc triển khai tính năng MSI của Office lại phản tác dụng trong môi trường phía máy chủ. Hơn nữa, độ ổn định của Office nói chung không thể được đảm bảo khi chạy phía máy chủ vì nó không được thiết kế hoặc kiểm tra cho kiểu sử dụng này. Việc sử dụng Office như một thành phần dịch vụ trên máy chủ mạng có thể giảm độ ổn định của máy đó và do đó ảnh hưởng tới toàn bộ mạng của bạn. Nếu bạn dự định tự động hoá Office phía máy chủ, hãy cố gắng cô lập chương trình trên một máy tính riêng biệt không ảnh hưởng đến các chức năng quan trọng và có thể khởi động lại khi cần."

Vì các thành phần Aspose được đóng gói trong một tệp DLL duy nhất, người dùng không bao giờ cần cài đặt các phần bổ sung để chúng hoạt động. Các thành phần Aspose chỉ được sử dụng bởi các ứng dụng .NET và không có phần nào của mã thành phần được thiết kế để chờ phản hồi của con người.

{{% alert color="primary" %}} 

Các thành phần Aspose đã được kiểm tra kỹ lưỡng và xác nhận rất ổn định. Các thành phần Aspose được sử dụng bởi [các công ty](http://www.aspose.com/Corporate/Aspose/Customerlist.html) như **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, và nhiều tổ chức hàng đầu khác trong nhiều ngành công nghiệp và lĩnh vực. 

{{% /alert %}} 

## **Khả năng mở rộng/Tốc độ**
Đây là trích dẫn trực tiếp từ một Bài viết của Microsoft:

> "Các thành phần phía máy chủ cần phải là các thành phần COM đa luồng, có khả năng tái nhập cao, với tối thiểu chi phí và thông lượng cao cho nhiều khách hàng. Các Ứng dụng Office gần như hoàn toàn ngược lại. Chúng là các máy chủ Automation dựa trên STA, không tái nhập, được thiết kế để cung cấp chức năng đa dạng nhưng tiêu tốn tài nguyên cho một khách hàng duy nhất. Chúng cung cấp khả năng mở rộng rất hạn chế như một giải pháp phía máy chủ và có các giới hạn cố định cho các yếu tố quan trọng, chẳng hạn như bộ nhớ, không thể thay đổi thông qua cấu hình. Hơn nữa, chúng sử dụng các tài nguyên toàn cục (như tệp được ánh xạ bộ nhớ, add‑in hoặc mẫu toàn cục, và các máy chủ Automation chia sẻ), có thể giới hạn số lượng thể hiện có thể chạy đồng thời và gây ra các điều kiện tranh chấp nếu chúng được cấu hình trong môi trường đa khách hàng. Các nhà phát triển dự định chạy hơn một thể hiện của bất kỳ Ứng dụng Office nào đồng thời cần xem xét việc Pooling hoặc Serializing Access đến Ứng dụng Office để tránh các Deadlock hoặc Data Corruption tiềm năng."

Các thành phần Aspose cực kỳ có khả năng mở rộng và nhanh như chớp. Các ứng dụng Office không được thiết kế để được sử dụng đồng thời bởi hàng trăm hoặc hàng nghìn người dùng, trong khi các thành phần Aspose được thiết kế chính xác cho mục tiêu đó. Các thành phần của chúng là giải pháp .NET thực sự.

{{% alert color="primary" %}} 

Hiệu năng của các thành phần Aspose hoàn hảo trên một máy chủ đơn (cung cấp cho một ứng dụng) hoặc trên một cụm web cân bằng tải (cung cấp cho một ứng dụng toàn doanh nghiệp). 

{{% /alert %}} 

## **Giá cả**
Khi một ứng dụng sử dụng Microsoft Office Automation, phải mua một bản sao Microsoft Office cho mỗi máy tính chạy ứng dụng đó. Có nhiều trường hợp một ứng dụng cần tạo hoặc thao tác tệp Office, nhưng quy trình không yêu cầu Microsoft Office.

{{% alert color="primary" %}} 

Aspose cung cấp một giấy phép [hiệu quả về chi phí](https://purchase.aspose.com/) và không yêu cầu bản quyền phân phối, cho phép triển khai cho số lượng người dùng không giới hạn mà không lo lắng về giấy phép. 

{{% /alert %}} 

Khi tạo các ứng dụng web, cần nhớ rằng các thành phần Microsoft Office Automation không được định giá hoặc cấp phép cho các giải pháp phía máy chủ. Do đó, không có giải pháp cấp phép tốt cho việc triển khai các ứng dụng web sử dụng các thành phần Microsoft Office. Ngược lại, Aspose cung cấp một giải pháp [hiệu quả về chi phí](https://purchase.aspose.com/) cho các ứng dụng dựa trên máy chủ.

## **Tính năng**
Các thành phần Aspose cung cấp mọi thứ cần thiết để quản lý tệp Office và còn nhiều hơn thế. Chúng tôi thiết kế chúng dựa trên triết lý giúp các nhà phát triển đạt được kết quả tối đa với ít công sức nhất.

{{% alert color="primary" %}} 

Khác với Office Automation, các thành phần Aspose cung cấp nhiều chức năng mạnh mẽ và tiết kiệm thời gian. 

{{% /alert %}} 

Ví dụ, [Aspose.Cells](https://products.aspose.com/cells/net/) cho phép nhà phát triển nhập dữ liệu từ một **DataTable** hoặc **DataView** trực tiếp vào tệp Excel. [Aspose.Words](https://products.aspose.com/words/net/) cung cấp tính năng tương tự cho phép nhà phát triển điền dữ liệu vào tài liệu Word (tức là Mail Merge) trực tiếp từ bất kỳ đối tượng dữ liệu .NET nào. [Mỗi thành phần](https://products.aspose.com/total/net/) trong họ Aspose đều có bộ tính năng độc đáo và mạnh mẽ riêng.

Phần tốt nhất khi mua một thành phần Aspose là được tiếp cận đội ngũ phát triển của chúng tôi. Ví dụ, nếu bạn sử dụng các đối tượng Office Automation và cần một số tính năng, khả năng các tính năng đó được thêm vào là rất, rất thấp. Tuy nhiên, mọi thứ lại khác với các thành phần Aspose.

{{% alert color="primary" %}} 

Đội ngũ phát triển của chúng tôi hiểu rằng nếu có một tính năng công ty bạn cần, khả năng cao các công ty khác cũng cần tính năng tương tự. Mặc dù chúng tôi biết không thể triển khai mọi tính năng yêu cầu, chúng tôi cố gắng bổ sung càng nhiều tính năng càng tốt dựa trên phản hồi của khách hàng. 

{{% /alert %}} 

Các đội ngũ của chúng tôi luôn cởi mở và linh hoạt khi hỗ trợ — và đây là lý do các thành phần Aspose đã và đang trở nên mạnh mẽ như hiện nay.

## **Kết luận**
{{% alert color="primary" %}} 

Mặc dù bài viết này đã đề cập đến một số điểm chính tại sao các thành phần Aspose là lựa chọn tốt hơn so với Office Automation, bạn cần hiểu rằng còn rất nhiều lợi ích khác. Chúng tôi chỉ liệt kê một số ưu điểm lớn.

Hơn nữa, tất cả các sản phẩm và thành phần Aspose đều cung cấp một [Phiên bản Đánh giá](https://downloads.aspose.com/slides/vi/net) không rủi ro, không ràng buộc. Chúng tôi khuyến khích bạn tận dụng bản đánh giá để xem Aspose có thể làm gì cho ứng dụng hoặc doanh nghiệp của bạn. 

{{% /alert %}}