---
title: Tại sao không tự động hoá
type: docs
weight: 50
url: /vi/cpp/why-not-automation/
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
- bản trình bày
- C++
- Aspose.Slides
description: "Khám phá lý do tại sao tự động hoá Office nguy hiểm đối với máy chủ và dịch vụ, và xem cách Aspose.Slides cung cấp quy trình xử lý bản trình bày an toàn hơn, nhanh hơn cho PowerPoint và OpenDocument."
---
## **Giới thiệu**

Có một số lý do khiến các thành phần Aspose là một giải pháp thay thế tốt hơn cho tự động hoá. Một số lý do chính bao gồm:

- Bảo mật
- Ổn định
- Khả năng mở rộng/Tốc độ
- Giá cả
- Tính năng

Dưới đây là phần giải thích chi tiết hơn cho mỗi điểm chính.

## **Câu hỏi quan trọng**
- Tại sao các thành phần Aspose là lựa chọn tốt hơn nhiều so với Microsoft Office Automation?

Có hai câu hỏi chúng tôi thường nghe nhất ở Aspose :

- Các sản phẩm của bạn có yêu cầu phải cài đặt Microsoft Office để chạy không?

Câu trả lời ngắn gọn và đơn giản là **KHÔNG**. Aspose và các thành phần Aspose hoàn toàn độc lập và không liên kết, không được ủy quyền, tài trợ hoặc được Microsoft Corporation chấp thuận theo bất kỳ cách nào.

- Tại sao chúng ta nên sử dụng sản phẩm Aspose thay vì sử dụng Microsoft Office Automation?

Câu trả lời ngắn nhất chúng tôi có thể đưa ra là có rất nhiều lý do, trong đó lý do hàng đầu là *Microsoft tự mình mạnh mẽ khuyến cáo không nên sử dụng Office Automation trong các giải pháp phần mềm: [Microsoft Article

## **Bảo mật**
Dưới đây là trích dẫn trực tiếp từ Microsoft Article đã được tham chiếu ở trên :
*"Các ứng dụng Office chưa bao giờ được thiết kế để sử dụng phía máy chủ, do đó không cân nhắc đến các vấn đề bảo mật mà các thành phần phân tán phải đối mặt. Office không xác thực các yêu cầu đến, và không bảo vệ bạn khỏi việc vô tình chạy macro, hoặc khởi động một máy chủ khác có thể chạy macro, từ mã phía máy chủ của bạn. Đừng mở các tệp được tải lên máy chủ từ một Web ẩn danh! Dựa trên các cài đặt bảo mật được thiết lập lần cuối, máy chủ có thể chạy macro dưới ngữ cảnh Administrator hoặc System với đầy đủ quyền và làm suy yếu mạng của bạn! Ngoài ra, Office sử dụng nhiều thành phần phía client (như Simple MAPI, WinInet, MSDAIPP) có thể lưu trữ bộ nhớ đệm thông tin xác thực client để tăng tốc xử lý. Nếu Office được tự động hoá phía máy chủ, một thể hiện có thể phục vụ hơn một client, và vì thông tin xác thực đã được lưu vào bộ nhớ đệm cho phiên đó, có khả năng một client có thể sử dụng thông tin xác thực đã lưu của client khác, và do đó có được quyền truy cập không được cấp phép bằng cách mạo danh người dùng khác."*

Các sản phẩm Aspose rất an toàn. Do đó, các thành phần Aspose không gây ra rủi ro tiềm ẩn cho các tài nguyên hệ thống quan trọng. Hơn nữa, khi một tài liệu được mở bằng một thành phần Aspose, macro sẽ không được chạy tự động. Các thành phần Aspose được xây dựng với mục tiêu cho phép các nhà phát triển tạo, thao tác và lưu các tệp Office. Không có bất kỳ rủi ro nào liên quan đến bộ Office của Microsoft vốn có trong các thành phần Aspose.

## **Ổn định**
Dưới đây là trích dẫn trực tiếp từ Microsoft Article đã được tham chiếu ở trên :
*"Office 2000, Office XP và Office 2003 sử dụng công nghệ Microsoft Windows Installer (MSI) để làm cho việc cài đặt và tự sửa chữa dễ dàng hơn cho người dùng cuối. MSI giới thiệu khái niệm “cài đặt khi sử dụng lần đầu”, cho phép các tính năng được cài đặt hoặc cấu hình động tại thời gian chạy (cho hệ thống, hoặc thường xuyên hơn cho người dùng cụ thể). Trong môi trường phía máy chủ, điều này vừa làm chậm hiệu năng vừa làm tăng khả năng xuất hiện hộp thoại yêu cầu người dùng chấp nhận cài đặt hoặc cung cấp đĩa cài đặt thích hợp. Mặc dù được thiết kế để tăng tính phục hồi của Office như một sản phẩm người dùng cuối, việc triển khai khả năng MSI của Office lại phản tác dụng trong môi trường phía máy chủ. Hơn nữa, tính ổn định của Office nói chung không thể được đảm bảo khi chạy phía máy chủ vì nó không được thiết kế hay kiểm thử cho kiểu sử dụng này. Sử dụng Office như một thành phần dịch vụ trên máy chủ mạng có thể làm giảm độ ổn định của máy đó và do đó làm ảnh hưởng tới toàn bộ mạng của bạn. Nếu bạn dự định tự động hoá Office phía máy chủ, hãy cố gắng cô lập chương trình trên một máy tính chuyên dụng không thể ảnh hưởng tới các chức năng quan trọng và có thể khởi động lại khi cần thiết."*

Vì các thành phần Aspose được đóng gói trong một DLL duy nhất, sẽ không bao giờ cần phải cài đặt bất kỳ phần bổ sung nào để chúng hoạt động. Các thành phần Aspose chỉ được sử dụng bởi các ứng dụng C++ và không có phần nào của mã thành phần được thiết kế để chờ phản hồi của con người. Các thành phần Aspose đã được kiểm thử kỹ lưỡng và cực kỳ ổn định. Các thành phần Aspose được sử dụng bởi [Companies](https://about.aspose.com/customers) như: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** và rất nhiều công ty khác.

## **Khả năng mở rộng/Tốc độ**
Dưới đây là trích dẫn trực tiếp từ Microsoft Article đã được tham chiếu ở trên :
*"Các thành phần phía máy chủ cần phải là các thành phần COM tái nhập cao, đa luồng với chi phí tối thiểu và thông lượng cao cho nhiều client. Các Ứng dụng Office gần như hoàn toàn ngược lại. Chúng là các máy chủ Automation dựa trên STA không tái nhập, được thiết kế để cung cấp các chức năng đa dạng nhưng chiếm tài nguyên lớn cho một client duy nhất. Chúng cung cấp ít khả năng mở rộng dưới dạng giải pháp phía máy chủ và có giới hạn cố định cho các yếu tố quan trọng, chẳng hạn như bộ nhớ, không thể thay đổi thông qua cấu hình. Quan trọng hơn, chúng sử dụng các tài nguyên toàn cục (như tập tin ánh xạ bộ nhớ, add‑in hoặc mẫu toàn cục, và các máy chủ Automation chia sẻ), có thể giới hạn số lượng thể hiện có thể chạy đồng thời và gây ra các điều kiện tranh chấp nếu chúng được cấu hình trong môi trường đa client. Các nhà phát triển có kế hoạch chạy hơn một thể hiện của bất kỳ Ứng dụng Office nào cùng một lúc cần xem xét việc Pooling hoặc Serializing Access tới Ứng dụng Office để tránh các Deadlock hoặc Data Corruption tiềm ẩn.”*

Các thành phần Aspose có khả năng mở rộng cao và cực kỳ nhanh. Các ứng dụng Office không được thiết kế để đồng thời được sử dụng bởi hàng trăm hay hàng nghìn người dùng. Tuy nhiên, các thành phần Aspose lại được thiết kế cho mục đích đó. Các thành phần của chúng tôi là giải pháp C++ thực thụ và hoạt động mượt mà dù trên một máy chủ đơn, cung cấp cho một ứng dụng duy nhất hoặc trên một Web Form cân bằng tải cung cấp cho toàn bộ ứng dụng doanh nghiệp.

## **Giá cả**
Khi một ứng dụng sử dụng Microsoft Office Automation, phải mua một bản sao Microsoft Office cho mỗi máy chạy ứng dụng. Nhiều lần một ứng dụng có thể tạo hoặc thao tác một tệp Office mà không yêu cầu người dùng phải có Microsoft Office. Aspose cung cấp một giấy phép phân phối lại không có bản quyền và **Cost Effective** https://purchase.aspose.com/ cho phép triển khai cho số lượng người dùng không giới hạn mà không lo về vấn đề cấp phép. Khi tạo các ứng dụng dựa trên web, cần lưu ý rằng các thành phần Microsoft Office Automation không có giá cả hay giấy phép cho các giải pháp phía máy chủ; do đó, không có giải pháp cấp phép tốt để triển khai các ứng dụng web sử dụng các thành phần Microsoft Office. Aspose cũng cung cấp một giải pháp **Cost Effective** https://purchase.aspose.com/ cho các ứng dụng phía máy chủ.

## **Tính năng**
Các thành phần Aspose cung cấp mọi thứ cần thiết để quản lý các tệp Office và còn nhiều hơn thế. Chúng được thiết kế với triết lý cho phép các nhà phát triển đạt được kết quả tốt nhất với ít công việc nhất. Không giống như Office Automation, các thành phần Aspose cung cấp nhiều hàm mạnh mẽ và giúp tiết kiệm thời gian. Ví dụ, [Aspose.Cells](https://products.aspose.com/cells/cpp/) cho phép các nhà phát triển nhập dữ liệu từ một **DataTable** hoặc **DataView** trực tiếp vào tệp Excel. [Aspose.Words](https://products.aspose.com/words/net/) cung cấp tính năng tương tự cho phép các nhà phát triển điền dữ liệu vào một tài liệu Word (Mail Merge) trực tiếp từ bất kỳ đối tượng dữ liệu C++ nào. [Every Component](https://products.aspose.com/total/cpp/) trong họ Aspose đều có bộ tính năng độc đáo và mạnh mẽ riêng. Phần tốt nhất khi mua một thành phần Aspose là được truy cập vào các đội ngũ phát triển của chúng tôi. Các đội ngũ của chúng tôi nhận ra rằng nếu có một tính năng mà công ty của bạn cần, khả năng cao là các công ty khác cũng sẽ cần. Mặc dù không phải mọi yêu cầu tính năng đều có thể được thêm vào, các đội ngũ của chúng tôi luôn cố gắng cởi mở và linh hoạt khi hỗ trợ. Tư duy này đã giúp các thành phần Aspose trở nên mạnh mẽ như hiện tại. Nếu có những tính năng bổ sung mà bạn cần từ các đối tượng Office Automation, khả năng chúng được thêm vào là rất, rất thấp.

## **Kết luận**
{{% alert color="primary" %}} 

Mặc dù bài viết này đã đề cập đến nhiều điểm quan trọng tại sao các thành phần Aspose là lựa chọn tốt hơn so với Office Automation, vẫn còn rất nhiều hơn nữa. Bài viết này chỉ tập trung vào các điểm chính nhất. Tất cả các thành phần Aspose khác nhau đều cung cấp một [Evaluation Version](https://downloads.aspose.com/slides/vi/cpp) không rủi ro, không ràng buộc. Chúng tôi khuyến khích bạn tận dụng [Evaluation](https://downloads.aspose.com/slides/vi/cpp) để hiểu rõ hơn những gì Aspose có thể làm cho ứng dụng của bạn. 
{{% /alert %}}