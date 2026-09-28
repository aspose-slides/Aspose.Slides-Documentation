---
title: Tại sao không nên tự động hóa
type: docs
weight: 170
url: /vi/net/why-not-automation/
keywords:
- tự động hóa
- Microsoft Office
- so sánh
- bảo mật
- ổn định
- khả năng mở rộng
- tính năng
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Khám phá lý do tại sao tự động hóa Office nguy hiểm cho máy chủ và dịch vụ, và xem cách Aspose.Slides cung cấp xử lý bài thuyết trình an toàn hơn, nhanh hơn cho PowerPoint và OpenDocument."
---
## **Giới thiệu**

Có một số lý do khiến các thành phần Aspose là lựa chọn tốt hơn so với tự động hóa. Một số lý do chính bao gồm:

- Bảo mật
- Ổn định
- Khả năng mở rộng/Tốc độ
- Giá
- Tính năng

Dưới đây là giải thích chi tiết hơn cho từng điểm chính.

## **Câu hỏi quan trọng**

Có hai câu hỏi chúng tôi thường nghe tại Aspose:

- Sản phẩm của bạn có cần cài đặt Microsoft Office để chạy không?

Câu trả lời ngắn gọn, đơn giản là **KHÔNG**.

Các thành phần Aspose hoàn toàn độc lập và không liên kết, được ủy quyền, tài trợ hoặc được Microsoft Corporation chấp thuận dưới bất kỳ hình thức nào.

- Tại sao chúng tôi nên sử dụng sản phẩm Aspose thay vì Microsoft Office Automation?

First, there are many [lợi ích bạn nhận được khi sử dụng Aspose.Slides](/slides/vi/net/product-overview/).

Second, Microsoft tự mình mạnh mẽ **khuyên không** sử dụng Office Automation trong các giải pháp phần mềm.

## **Bảo mật**
Đoạn sau là một trích dẫn trực tiếp từ một bài viết của Microsoft:

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Sản phẩm Aspose rất **an toàn**. Các thành phần Aspose chạy trong cùng ngữ cảnh người dùng như tất cả các ứng dụng ASP.NET (dưới người dùng ASPNET). Do đó, các thành phần Aspose **không** gây ra rủi ro bảo mật. Chúng cũng không tiêu tốn các tài nguyên hệ thống quan trọng. Hơn nữa, khi một thành phần Aspose mở tài liệu, macro sẽ không tự động chạy. Các thành phần Aspose được xây dựng để cho phép các nhà phát triển tạo, thao tác và lưu các tệp Office.

{{% alert color="info" title="Note" %}}
Không có rủi ro nào liên quan đến gói Microsoft Office áp dụng cho các thành phẩm Aspose.
{{% /alert %}}

## **Ổn định**
Đoạn văn này là trích dẫn trực tiếp từ Bài viết Microsoft đã đề cập trước đó:

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Vì các thành phần Aspose được đóng gói vào một DLL duy nhất, người dùng không bao giờ cần cài đặt thêm bất kỳ phần nào để chúng hoạt động. Các thành phần Aspose chỉ được sử dụng bởi các ứng dụng .NET và không có phần nào của mã thành phần được thiết kế để chờ phản hồi của con người.

{{% alert color="info" title="Note" %}}
Các thành phần Aspose đã được kiểm tra kỹ lưỡng và xác nhận là rất ổn định. Các thành phần Aspose được sử dụng bởi [các công ty](https://about.aspose.com/customers/) như **Bank of America** và nhiều tổ chức hàng đầu khác trong nhiều ngành và lĩnh vực.
{{% /alert %}}

## **Khả năng mở rộng/Tốc độ**
Đoạn sau là một trích dẫn trực tiếp từ một bài viết của Microsoft:

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Các thành phần Aspose vô cùng có khả năng mở rộng và siêu tốc. Các ứng dụng Office không được thiết kế để đồng thời được sử dụng bởi hàng trăm hoặc hàng ngàn người dùng, nhưng các thành phần Aspose được thiết kế chính xác cho mục đích đó. Các thành phần của chúng tôi là một giải pháp .NET thực thụ.

{{% alert color="info" title="Note" %}}
Hiệu năng của các thành phần Aspose không có lỗi trên một máy chủ duy nhất (cung cấp cho một ứng dụng) hoặc trên một môi trường web cân bằng tải (cung cấp cho một ứng dụng toàn doanh nghiệp).
{{% /alert %}}

## **Giá**
Khi một ứng dụng sử dụng Microsoft Office Automation, một bản sao của Microsoft Office phải được mua cho mỗi máy chạy ứng dụng. Có nhiều trường hợp một ứng dụng có thể cần tạo hoặc thao tác một tệp office, nhưng quy trình không yêu cầu Microsoft Office.

{{% alert color="info" title="Note" %}}
Aspose cung cấp một giấy phép phân phối lại rất [hiệu quả về chi phí](https://purchase.aspose.com/) và không có phí bản quyền, cho phép triển khai tới số lượng người dùng không giới hạn mà không lo về giấy phép.
{{% /alert %}}

Khi tạo các ứng dụng dựa trên web, cần nhớ rằng các thành phần Microsoft Office Automation không được định giá hoặc cấp phép cho các giải pháp phía máy chủ. Do đó, không có giải pháp cấp phép tốt cho việc triển khai các ứng dụng web sử dụng các thành phần Microsoft Office. Ngược lại, Aspose cung cấp một giải pháp rất [hiệu quả về chi phí](https://purchase.aspose.com/) cho các ứng dụng dựa trên máy chủ.

## **Tính năng**
Các thành phần Aspose cung cấp mọi thứ cần thiết để quản lý các tệp Office và còn nhiều hơn nữa. Chúng tôi thiết kế chúng dựa trên triết lý giúp các nhà phát triển đạt được kết quả tốt nhất có thể với ít nỗ lực nhất.

{{% alert color="info" title="Note" %}}
Khác với Office Automation, các thành phần Aspose cung cấp nhiều chức năng mạnh mẽ và tiết kiệm thời gian.
{{% /alert %}}

Ví dụ, [Aspose.Cells](https://products.aspose.com/cells/net/) cho phép các nhà phát triển nhập dữ liệu từ **DataTable** hoặc **DataView** trực tiếp vào tệp Excel. [Aspose.Words](https://products.aspose.com/words/net/) cung cấp tính năng tương tự cho phép các nhà phát triển điền dữ liệu vào tài liệu Word (cụ thể là Mail Merge) trực tiếp từ bất kỳ đối tượng dữ liệu .NET nào. [Mỗi thành phần](https://products.aspose.com/total/net/) trong họ Aspose đều cung cấp bộ tính năng độc đáo và mạnh mẽ riêng.

Phần tốt nhất khi mua một thành phần Aspose là được tiếp cận với đội ngũ phát triển của chúng tôi. Ví dụ, nếu bạn sử dụng các đối tượng Office Automation và cần một số tính năng nhất định, khả năng những tính năng đó được thêm vào là rất, rất thấp. Tuy nhiên, với các thành phần Aspose thì mọi thứ khác.

{{% alert color="info" title="Note" %}}
Đội ngũ phát triển của chúng tôi hiểu rằng nếu có một tính năng mà công ty bạn cần, khả năng cao các công ty khác cũng cần tính năng tương tự. Mặc dù chúng tôi biết không thể thực hiện mọi tính năng được yêu cầu, chúng tôi cố gắng thêm càng nhiều tính năng càng tốt dựa trên phản hồi từ khách hàng.
{{% /alert %}}

Đội ngũ của chúng tôi luôn cởi mở và linh hoạt khi cung cấp hỗ trợ—đây là lý do các thành phần Aspose đã phát triển mạnh mẽ như hiện tại.

## **Kết luận**
{{% alert color="info" title="Note" %}}
Trong khi bài viết này đã đề cập một số điểm chính tại sao các thành phần Aspose là lựa chọn tốt hơn so với Office Automation, bạn cần hiểu rằng còn rất nhiều lợi ích khác. Chúng tôi chỉ nêu một số ưu điểm chính.

Hơn nữa, tất cả sản phẩm và thành phần Aspose đều cung cấp một [Phiên bản Đánh giá](https://releases.aspose.com/slides/net/) không rủi ro, không ràng buộc. Chúng tôi khuyến khích bạn tận dụng bản đánh giá để thấy Aspose có thể làm gì cho ứng dụng hoặc doanh nghiệp của bạn.
{{% /alert %}}