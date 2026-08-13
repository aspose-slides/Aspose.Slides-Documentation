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
  - ổn định
  - khả năng mở rộng
  - tính năng
  - PowerPoint
  - OpenDocument
  - bản trình chiếu
  - .NET
  - C#
  - Aspose.Slides
description: "Khám phá lý do tại sao tự động hoá Office nguy hiểm cho máy chủ và dịch vụ, và xem cách Aspose.Slides cung cấp quy trình xử lý bản trình chiếu an toàn hơn, nhanh hơn cho PowerPoint và OpenDocument."
---
## **Giới thiệu**

Có một số lý do khiến các thành phần Aspose là giải pháp thay thế tốt hơn so với tự động hóa. Một số lý do chính bao gồm:

- Bảo mật
- Ổn định
- Khả năng mở rộng/Tốc độ
- Giá cả
- Tính năng

Dưới đây là phần giải thích chi tiết hơn cho mỗi điểm chính.

## **Câu hỏi quan trọng**

Có hai câu hỏi mà chúng tôi thường nghe ở Aspose:

- Sản phẩm của bạn có cần cài đặt Microsoft Office để chạy không?

Câu trả lời ngắn gọn và đơn giản là **KHÔNG**.

Các thành phần Aspose hoàn toàn độc lập và không liên kết, ủy quyền, tài trợ, hoặc được Microsoft Corporation chấp thuận theo bất kỳ cách nào.

- Tại sao chúng tôi nên sử dụng sản phẩm Aspose thay vì Microsoft Office Automation?

Đầu tiên, có rất nhiều [lợi ích bạn nhận được khi sử dụng Aspose.Slides](/slides/vi/net/product-overview/).

Microsoft tự thân mạnh mẽ **khuyên không nên** sử dụng Office Automation trong các giải pháp phần mềm.

## **Bảo mật**
Đoạn trích trực tiếp từ một Bài viết của Microsoft:

> "Office Applications không bao giờ được thiết kế để sử dụng phía máy chủ, do đó không cân nhắc các vấn đề bảo mật mà các thành phần phân tán gặp phải. Office không xác thực các yêu cầu đến, và không bảo vệ bạn khỏi việc chạy macro một cách vô tình, hoặc khởi động một máy chủ khác có thể chạy macro, từ mã phía máy chủ của bạn. Đừng mở các tệp được tải lên máy chủ từ một trang Web ẩn danh! Dựa trên các cài đặt bảo mật được đặt lần cuối, máy chủ có thể chạy macro dưới ngữ cảnh Administrator hoặc System với đầy đủ quyền và làm suy yếu mạng của bạn! Ngoài ra, Office sử dụng nhiều thành phần phía client (như Simple MAPI, WinInet, MSDAIPP) có thể lưu trữ thông tin xác thực client để tăng tốc xử lý. Nếu Office được tự động hoá phía máy chủ, một phiên bản có thể phục vụ hơn một client, và vì thông tin xác thực đã được lưu cho phiên làm việc đó, một client có thể sử dụng thông tin xác thực đã lưu của client khác, từ đó giành được quyền truy cập không được cấp bằng cách mạo danh người dùng khác."

Các sản phẩm Aspose rất **bảo mật**. Các thành phần Aspose chạy trong cùng ngữ cảnh người dùng như tất cả các ứng dụng ASP.NET (dưới người dùng ASPNET). Do đó, các thành phần Aspose **không** gây ra rủi ro bảo mật. Chúng cũng không tiêu tốn tài nguyên hệ thống quan trọng. Hơn nữa, khi một thành phần Aspose mở tài liệu, macro sẽ không tự động chạy. Các thành phần Aspose được xây dựng để cho phép nhà phát triển tạo, thao tác và lưu các tệp Office.

{{% alert color="info" %}} 
Không có rủi ro nào liên quan đến gói Microsoft Office áp dụng cho các thành phần Aspose. 
{{% /alert %}} 

## **Ổn định**
Đoạn trích trực tiếp từ Bài viết Microsoft đã được đề cập trước:

> "Office 2000, Office XP và Office 2003 sử dụng công nghệ Microsoft Windows Installer (MSI) để việc cài đặt và tự sửa chữa dễ dàng hơn cho người dùng cuối. MSI giới thiệu khái niệm "cài đặt khi lần đầu dùng", cho phép các tính năng được cài đặt hoặc cấu hình động tại thời gian chạy (cho hệ thống, hoặc thường hơn cho một người dùng cụ thể). Trong môi trường phía máy chủ, điều này làm chậm hiệu suất và tăng khả năng xuất hiện hộp thoại yêu cầu người dùng chấp nhận cài đặt hoặc cung cấp đĩa cài đặt phù hợp. Mặc dù nó được thiết kế để tăng độ chịu lỗi của Office như một sản phẩm người dùng cuối, việc triển khai MSI của Office lại phản tác dụng trong môi trường phía máy chủ. Hơn nữa, độ ổn định của Office nói chung không thể được đảm bảo khi chạy phía máy chủ vì nó không được thiết kế hoặc kiểm thử cho loại sử dụng này. Sử dụng Office như một thành phần dịch vụ trên một máy chủ mạng có thể làm giảm sự ổn định của máy đó và do đó ảnh hưởng tới toàn bộ mạng của bạn. Nếu bạn dự định tự động hoá Office phía máy chủ, hãy cố gắng cô lập chương trình trên một máy tính chuyên dụng không ảnh hưởng tới các chức năng quan trọng, và có thể khởi động lại khi cần."

Vì các thành phần Aspose được đóng gói trong một DLL duy nhất, người dùng không bao giờ cần cài đặt thêm bất kỳ phần nào để chúng hoạt động. Các thành phần Aspose chỉ được sử dụng bởi các ứng dụng .NET và không có phần mã nào được thiết kế để chờ phản hồi của con người.

{{% alert color="info" %}} 
Các thành phần Aspose đã được kiểm tra kỹ lưỡng và xác nhận rất ổn định. Các thành phần Aspose được các [công ty](http://www.aspose.com/Corporate/Aspose/Customerlist.html) như **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, và nhiều tổ chức hàng đầu khác trong nhiều ngành và lĩnh vực sử dụng. 
{{% /alert %}} 

## **Khả năng mở rộng/Tốc độ**
Đoạn trích trực tiếp từ một Bài viết của Microsoft:

> "Các thành phần phía máy chủ cần phải là các thành phần COM có khả năng tái nhập cao, đa luồng với độ trễ tối thiểu và khả năng thông lượng cao cho nhiều client. Các Ứng dụng Office gần như hoàn toàn ngược lại. Chúng là các server Automation dựa trên STA, không tái nhập, được thiết kế để cung cấp chức năng đa dạng nhưng tốn tài nguyên cho một client duy nhất. Chúng cung cấp ít khả năng mở rộng như một giải pháp phía máy chủ, và có các giới hạn cố định cho các yếu tố quan trọng, như bộ nhớ, không thể thay đổi qua cấu hình. Hơn nữa, chúng sử dụng tài nguyên toàn cục (như tệp được ánh xạ bộ nhớ, add-in hoặc mẫu toàn cục, và các server Automation chia sẻ), có thể giới hạn số lượng phiên bản có thể chạy đồng thời và dẫn đến các điều kiện tranh chấp nếu chúng được cấu hình trong môi trường đa client. Các nhà phát triển có kế hoạch chạy hơn một phiên bản của bất kỳ Ứng dụng Office nào đồng thời cần xem xét Pooling hoặc Serializing Access tới Ứng dụng Office để tránh các Deadlock hoặc Data Corruption tiềm ẩn." 

Các thành phần Aspose vô cùng có khả năng mở rộng và cực kỳ nhanh chóng. Các ứng dụng Office không được thiết kế để cùng lúc được hàng trăm hay hàng nghìn người dùng sử dụng, trong khi các thành phần Aspose được thiết kế ngay cho mục đích đó. Các thành phần của chúng là giải pháp .NET thực thụ.

{{% alert color="info" %}} 
Hiệu năng của các thành phần Aspose hoàn hảo trên một máy chủ đơn (cung cấp cho một ứng dụng) hoặc trên một kiến trúc web cân bằng tải (cung cấp cho một ứng dụng trên toàn doanh nghiệp). 
{{% /alert %}} 

## **Giá cả**
Khi một ứng dụng sử dụng Microsoft Office Automation, một bản sao Microsoft Office phải được mua cho mỗi máy chạy ứng dụng đó. Có rất nhiều trường hợp một ứng dụng cần tạo hoặc thao tác tệp Office, nhưng quá trình này không yêu cầu Microsoft Office.

{{% alert color="info" %}} 
Aspose cung cấp một giấy phép [chi phí hiệu quả](https://purchase.aspose.com/) và không có phí bản quyền, cho phép triển khai cho số lượng người dùng không giới hạn mà không lo về vấn đề cấp phép. 
{{% /alert %}} 

Khi tạo các ứng dụng dựa trên web, cần nhớ rằng các thành phần Microsoft Office Automation không được định giá hoặc cấp phép cho các giải pháp phía máy chủ. Do đó, không có giải pháp cấp phép tốt cho việc triển khai các ứng dụng web sử dụng các thành phần Microsoft Office. Ngược lại, Aspose cung cấp một giải pháp [chi phí hiệu quả](https://purchase.aspose.com/) cho các ứng dụng dựa trên máy chủ.

## **Tính năng**
Các thành phần Aspose cung cấp mọi thứ cần thiết để quản lý tệp Office và còn nhiều hơn thế. Chúng được thiết kế dựa trên triết lý giúp các nhà phát triển đạt được kết quả tối đa với ít nỗ lực nhất.

{{% alert color="info" %}} 
Khác với Office Automation, các thành phần Aspose cung cấp nhiều chức năng mạnh mẽ và tiết kiệm thời gian. 
{{% /alert %}} 

Ví dụ, [Aspose.Cells](https://products.aspose.com/cells/net/) cho phép các nhà phát triển nhập dữ liệu từ một **DataTable** hoặc **DataView** trực tiếp vào tệp Excel. [Aspose.Words](https://products.aspose.com/words/net/) cung cấp tính năng tương tự cho phép các nhà phát triển điền dữ liệu vào tài liệu Word (tức là Mail Merge) trực tiếp từ bất kỳ đối tượng dữ liệu .NET nào. [Mỗi thành phần](https://products.aspose.com/total/net/) trong họ họ Aspose đều có bộ tính năng độc đáo và mạnh mẽ riêng.

Điều tốt nhất khi mua một thành phần Aspose là được tiếp cận với đội ngũ phát triển của chúng tôi. Ví dụ, nếu bạn sử dụng các đối tượng Office Automation và cần một số tính năng, khả năng những tính năng đó được thêm vào là rất, rất thấp. Tuy nhiên, với các thành phần Aspose, tình hình lại khác.

{{% alert color="info" %}} 
Đội ngũ phát triển của chúng tôi hiểu rằng nếu có một tính năng nào đó công ty bạn cần, rất có khả năng các công ty khác cũng cần cùng tính năng đó. Mặc dù chúng tôi biết không thể triển khai mọi tính năng được yêu cầu, chúng tôi cố gắng thêm càng nhiều tính năng càng tốt dựa trên phản hồi của khách hàng. 
{{% /alert %}} 

Đội ngũ của chúng tôi luôn cởi mở và linh hoạt khi cung cấp hỗ trợ—và đây là lý do các thành phần Aspose đã phát triển mạnh mẽ như hiện nay.

## **Kết luận**
{{% alert color="info" %}} 
Mặc dù bài viết này đã đề cập một số điểm chính tại sao các thành phần Aspose là lựa chọn tốt hơn so với Office Automation, bạn cần hiểu rằng còn rất nhiều lợi ích khác. Chúng tôi chỉ liệt kê một số lợi thế chính. 

Hơn nữa, tất cả sản phẩm và thành phần Aspose đều cung cấp một [Phiên bản Đánh giá](https://downloads.aspose.com/slides/vi/net) không rủi ro, không ràng buộc. Chúng tôi khuyến khích bạn tận dụng bản đánh giá để xem Aspose có thể làm gì cho ứng dụng hoặc doanh nghiệp của bạn. 
{{% /alert %}}