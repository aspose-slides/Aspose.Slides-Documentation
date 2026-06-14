---
title: Tại sao không nên tự động hoá
type: docs
weight: 50
url: /vi/php-java/why-not-automation/
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
- PHP
- Aspose.Slides
description: "Khám phá lý do tại sao tự động hoá Office có rủi ro đối với máy chủ và dịch vụ, và xem cách Aspose.Slides cung cấp việc xử lý bài thuyết trình an toàn hơn, nhanh hơn cho PowerPoint và OpenDocument."
---
## **Tổng quan**

Có một số lý do khiến các thành phần Aspose là lựa chọn tốt hơn so với tự động hoá. Một số lý do chính bao gồm:

- Bảo mật
- Ổn định
- Khả năng mở rộng/Tốc độ
- Giá cả
- Tính năng

Dưới đây là giải thích chi tiết hơn cho mỗi điểm chính.

## **Câu hỏi quan trọng**

Có hai câu hỏi chúng tôi thường nghe tại Aspose:

- Sản phẩm của bạn có cần cài đặt Microsoft Office để chạy không?

Câu trả lời ngắn gọn, đơn giản là **KHÔNG**.

Aspose components hoàn toàn độc lập và không liên kết, không được ủy quyền, không được tài trợ hoặc được Microsoft Corporation chấp thuận bằng bất kỳ cách nào.

- Tại sao chúng tôi nên sử dụng sản phẩm Aspose thay vì Microsoft Office Automation?

Đầu tiên, có rất nhiều [Lợi ích bạn nhận được khi sử dụng Aspose.Slides](/slides/vi/php-java/product-overview/).

Thứ hai, Microsoft tự mình mạnh mẽ **khuyên không** sử dụng Office Automation trong các giải pháp phần mềm.

## **Bảo mật**

Đoạn sau là trích dẫn trực tiếp từ một bài viết của Microsoft:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."* 

Sản phẩm Aspose rất an toàn. Các thành phần Aspose không gây rủi ro tiềm tàng cho các tài nguyên hệ thống quan trọng. Hơn nữa, khi một tài liệu được mở bằng thành phần Aspose, macro sẽ không tự động chạy. Các thành phần Aspose được xây dựng với mục tiêu cho phép các nhà phát triển tạo, thao tác và lưu các tệp Office. Không có rủi ro nào liên quan đến bộ Office của Microsoft là tích hợp sẵn trong các thành phần Aspose.

## **Ổn định**

Đoạn sau là trích dẫn trực tiếp từ một bài viết của Microsoft:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."* 

Các thành phần Aspose đã được kiểm nghiệm kỹ lưỡng và cực kỳ ổn định. Các thành phần Aspose được sử dụng bởi [Companies](https://about.aspose.com/customers) như: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** và rất, rất nhiều công ty khác.

## **Khả năng mở rộng/Tốc độ**

Đoạn sau là trích dẫn trực tiếp từ một bài viết của Microsoft:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.* 

Các thành phần Aspose có khả năng mở rộng cao và tốc độ cực nhanh. Các ứng dụng Office không được thiết kế để đồng thời được sử dụng bởi hàng trăm hay hàng nghìn người dùng. Ngược lại, các thành phần Aspose được thiết kế dành riêng cho mục đích đó. Các thành phần của chúng tôi hoạt động mượt mà dù trên một máy chủ đơn, cung cấp cho một ứng dụng duy nhất hay trên một Web Form cân bằng tải cung cấp cho toàn bộ doanh nghiệp.

## **Giá**

Khi một ứng dụng sử dụng Microsoft Office Automation, cần phải mua một bản sao Microsoft Office cho mỗi máy chạy ứng dụng đó. Nhiều trường hợp, một ứng dụng chỉ cần tạo hoặc thao tác tệp Office mà không yêu cầu người dùng phải có Microsoft Office. Aspose cung cấp giấy phép [Cost Effective](https://purchase.aspose.com/) và miễn phí bản quyền phân phối, cho phép triển khai cho không giới hạn số lượng người dùng mà không lo lắng về chi phí bản quyền.

Khi tạo các ứng dụng web, cần lưu ý rằng các thành phần Microsoft Office Automation không được định giá hay cấp phép cho các giải pháp phía server; do đó, không có giải pháp cấp phép tốt nào cho việc triển khai các ứng dụng web sử dụng các thành phần Microsoft Office. Aspose cũng cung cấp một giải pháp rất Cost Effective cho các ứng dụng chạy trên server.

## **Tính năng**

Các thành phần Aspose cung cấp mọi thứ cần thiết để quản lý tệp Office và còn nhiều hơn thế. Chúng được thiết kế theo triết lý cho phép các nhà phát triển đạt được kết quả tối đa với ít công sức nhất. Khác với Office Automation, các thành phần Aspose cung cấp nhiều chức năng mạnh mẽ và tiết kiệm thời gian. Ví dụ, [Aspose.Cells](https://products.aspose.com/cells/php-java/) cho phép các nhà phát triển nhập dữ liệu từ một **DataTable** hoặc **DataView** trực tiếp vào tệp Excel. [Mỗi Thành phần](https://products.aspose.com/total/php-java/) trong họ Aspose đều có bộ tính năng độc đáo và mạnh mẽ riêng.

Điểm mạnh khi mua một thành phần Aspose (hoặc bộ thành phần như [Aspose.Total](https://products.aspose.com/total/php-java/)) là được tiếp cận với các đội ngũ phát triển của chúng tôi. Đội ngũ của chúng tôi nhận ra rằng nếu có một tính năng mà công ty bạn cần, rất có thể các công ty khác cũng sẽ cần. Mặc dù không phải mọi yêu cầu tính năng đều có thể được thêm vào, nhưng các đội ngũ của chúng tôi luôn cố gắng mở lòng và linh hoạt khi hỗ trợ. Tư duy này đã giúp các thành phần Aspose trở nên mạnh mẽ như hiện nay. Nếu có các tính năng bổ sung mà bạn cần từ các đối tượng Office Automation, khả năng chúng được thêm vào là rất, rất thấp.

## **Kết luận**
{{% alert color="primary" %}} 

Mặc dù bài viết này đã đề cập đến nhiều điểm chính tại sao các thành phần Aspose là lựa chọn tốt hơn so với Office Automation, vẫn còn rất, rất nhiều điều khác. Bài viết này chủ yếu chỉ nêu ra những điểm quan trọng nhất. Tất cả các thành phần Aspose khác nhau đều cung cấp một [Evaluation Version](https://downloads.aspose.com/slides/vi/java) không rủi ro, không ràng buộc. Chúng tôi khuyến khích bạn tận dụng bản Evaluation này để thấy rõ hơn Aspose có thể làm gì cho các ứng dụng của bạn. 

{{% /alert %}}