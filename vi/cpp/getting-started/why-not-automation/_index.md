---
title: Tại sao không nên tự động hoá
type: docs
weight: 50
url: /vi/cpp/why-not-automation/
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
- bản trình chiếu
- C++
- Aspose.Slides
description: "Khám phá lý do tại sao tự động hoá Office nguy hiểm đối với máy chủ và dịch vụ, và xem cách Aspose.Slides cung cấp quy trình xử lý bản trình chiếu an toàn hơn, nhanh hơn cho PowerPoint và OpenDocument."
---
## **Giới thiệu**

Có một số lý do khiến các thành phần Aspose là lựa chọn thay thế tốt hơn cho tự động hoá. Một số lý do chính bao gồm:

- Bảo mật
- Ổn định
- Khả năng mở rộng/Tốc độ
- Giá cả
- Tính năng

Dưới đây là giải thích chi tiết hơn cho mỗi điểm chính.

## **Các câu hỏi quan trọng**
- Tại sao các thành phần Aspose lại là lựa chọn tốt hơn nhiều so với Microsoft Office Automation?

Có hai câu hỏi chúng tôi thường nghe tại Aspose :

- Sản phẩm của bạn có yêu cầu phải cài đặt Microsoft Office để chạy không?

Câu trả lời ngắn gọn là **KHÔNG**. Các thành phần Aspose hoàn toàn độc lập và không có bất kỳ liên quan, ủy quyền, tài trợ hoặc được Microsoft Corporation chấp thuận nào.

- Tại sao chúng ta nên sử dụng sản phẩm Aspose thay vì sử dụng Microsoft Office Automation?

Câu trả lời ngắn nhất chúng tôi có thể đưa ra là có rất nhiều lý do, trong đó lý do hàng đầu là *Microsoft tự mình khuyến cáo mạnh mẽ không nên sử dụng Office Automation trong các giải pháp phần mềm: [Microsoft Article*

## **Bảo mật**
Đoạn trích dẫn trực tiếp từ Microsoft Article đã được tham chiếu ở trên:
*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Sản phẩm Aspose rất an toàn. Do đó, các thành phần Aspose không gây ra rủi ro tiềm ẩn cho các tài nguyên hệ thống quan trọng. Hơn nữa, khi một tài liệu được mở bởi một thành phần Aspose, macro sẽ không tự động chạy. Các thành phần Aspose được xây dựng với mục tiêu cho phép các lập trình viên tạo, thao tác và lưu các tệp Office. Không có rủi ro nào liên quan đến bộ Office của Microsoft vốn có trong các thành phần Aspose.

## **Ổn định**
Đoạn trích dẫn trực tiếp từ Microsoft Article đã được tham chiếu ở trên:
*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Vì các thành phần Aspose được đóng gói trong một DLL duy nhất, sẽ không bao giờ cần cài đặt bất kỳ phần bổ sung nào để chúng hoạt động. Các thành phần Aspose chỉ được sử dụng bởi các ứng dụng C++ và không có phần nào của mã thành phần được thiết kế để chờ phản hồi của con người. Các thành phần Aspose đã được kiểm tra kỹ lưỡng và cực kỳ ổn định. Các thành phần Aspose được sử dụng bởi [Companies](https://about.aspose.com/customers) như: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** và nhiều công ty khác.

## **Khả năng mở rộng/Tốc độ**
Đoạn trích dẫn trực tiếp từ Microsoft Article đã được tham chiếu ở trên:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Các thành phần Aspose có khả năng mở rộng cao và tốc độ siêu nhanh. Các ứng dụng Office không được thiết kế để cùng lúc được hàng trăm hoặc hàng nghìn người dùng sử dụng. Ngược lại, các thành phần Aspose được thiết kế cho mục tiêu đó. Các thành phần của chúng là giải pháp C++ thực thụ và hoạt động mượt mà dù trên một máy chủ duy nhất, phục vụ một ứng dụng duy nhất, hoặc trên một Web Form cân bằng tải, cung cấp cho toàn bộ doanh nghiệp.

## **Giá cả**
Khi một ứng dụng sử dụng Microsoft Office Automation, mỗi máy tính chạy ứng dụng đó phải mua một bản sao Microsoft Office. Nhiều lần, một ứng dụng có thể cần tạo hoặc thao tác tệp Office mà không yêu cầu người dùng phải có Microsoft Office. Aspose cung cấp một giấy phép [Cost Effective](https://purchase.aspose.com/) và không có phí bản quyền, cho phép triển khai cho số lượng người dùng không giới hạn mà không lo về giấy phép. Khi xây dựng các ứng dụng web, cần lưu ý rằng các thành phần Microsoft Office Automation không được định giá hay cấp phép cho các giải pháp phía máy chủ; do đó, không có giải pháp cấp phép phù hợp cho việc triển khai các ứng dụng web sử dụng các thành phần Microsoft Office. Aspose cung cấp một giải pháp [Cost Effective](https://purchase.aspose.com/) cho các ứng dụng phía máy chủ.

## **Tính năng**
Các thành phần Aspose cung cấp mọi thứ cần thiết để quản lý tệp Office và còn hơn thế nữa. Chúng được thiết kế với triết lý cho phép các lập trình viên đạt được kết quả tốt nhất với ít công sức nhất. Không giống như Office Automation, các thành phần Aspose cung cấp nhiều chức năng mạnh mẽ và tiết kiệm thời gian. Ví dụ, [Aspose.Cells](https://products.aspose.com/cells/cpp/) cho phép lập trình viên nhập dữ liệu từ một **DataTable** hoặc **DataView** trực tiếp vào tệp Excel. [Aspose.Words](https://products.aspose.com/words/net/) cũng có tính năng tương tự, cho phép lập trình viên điền dữ liệu vào một tài liệu Word (Mail Merge) trực tiếp từ bất kỳ đối tượng dữ liệu C++ nào. [Every Component](https://products.aspose.com/total/cpp/) trong họ Aspose đều có bộ tính năng độc đáo và mạnh mẽ riêng. Phần tốt nhất khi mua một thành phần Aspose là bạn sẽ được hỗ trợ bởi đội ngũ phát triển của chúng tôi. Đội ngũ của chúng tôi hiểu rằng nếu công ty của bạn cần một tính năng, rất có thể các công ty khác cũng sẽ cần. Mặc dù không phải mọi yêu cầu tính năng đều có thể được thêm vào, nhưng đội ngũ luôn cởi mở và linh hoạt khi hỗ trợ. Tâm lý này đã giúp các thành phần Aspose trở nên mạnh mẽ như hiện tại. Nếu bạn cần thêm các tính năng từ các đối tượng Office Automation, khả năng chúng được thêm vào là rất, rất thấp.

## **Kết luận**
{{% alert color="info" %}} 

Mặc dù bài viết này đã đề cập đến nhiều điểm quan trọng giải thích vì sao các thành phần Aspose là lựa chọn tốt hơn so với Office Automation, vẫn còn rất nhiều lý do khác. Bài viết này chủ yếu tập trung vào các điểm then chốt. Tất cả các thành phần Aspose đều cung cấp một [Evaluation Version](https://downloads.aspose.com/slides/vi/cpp) miễn phí, không ràng buộc. Chúng tôi khuyến khích bạn tận dụng [Evaluation](https://downloads.aspose.com/slides/vi/cpp) để trải nghiệm rõ hơn những gì Aspose có thể làm cho ứng dụng của bạn.
{{% /alert %}}