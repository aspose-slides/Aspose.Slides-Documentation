---
title: Cách chạy các nhiệm vụ nền trong ASP.NET Core
type: docs
weight: 300
url: /vi/net/how-to-run-background-tasks-in-asp-net-core/
keywords:
- ASP.NET Core
- nhiệm vụ nền
- xử lý nền
- dịch vụ lưu trữ
- worker nền
- hàng đợi công việc
- lên lịch công việc bất đồng bộ
- xử lý tệp phía máy chủ
- theo dõi tiến độ
- thăm dò trạng thái
- thông báo SignalR
- AWS SQS
- Amazon S3
- Amazon DynamoDB
- kiến trúc có khả năng mở rộng
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Chạy các nhiệm vụ nền trong ASP.NET Core với Dịch vụ lưu trữ, hàng đợi công việc và cập nhật trạng thái – xử lý và chuyển đổi PPT, PPTX và ODP bằng Aspose.Slides."
---
## **Giới thiệu**

Xử lý tệp (ví dụ, xuất bản trình chiếu sang PDF) là một nhiệm vụ điển hình phía máy chủ. Thực hiện nó trong trình xử lý yêu cầu (khi khách hàng đang chờ) có những nhược điểm sau:

- *Giao diện kém.* Trang bị đóng băng và người dùng phải chờ kết quả. Tải lại trang sẽ hủy tác vụ.
- *Hết thời gian hoạt động.* Chúng tôi không thể đảm bảo việc xử lý sẽ hoàn thành trong khoảng thời gian cố định, vì vậy người dùng có khả năng thấy thông báo “operation timeout”.
- *Thông lượng và khả năng mở rộng thấp.* ASP.NET Core được thiết kế để xử lý nhiều yêu cầu một cách bất đồng bộ. Các tác vụ CPU-bound, chạy lâu sẽ chặn các luồng và làm giảm thông lượng máy chủ.
- *Khả năng chịu lỗi kém.* Nếu có sự cố trong quá trình thực hiện tác vụ dài (ví dụ, lỗi kết nối), việc xử lý sẽ thất bại và phải được khởi động lại từ đầu.

Một [cách tiếp cận tốt hơn](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-9.0#complete-long-running-tasks-outside-of-http-requests) là lên lịch công việc một cách bất đồng bộ, xử lý nó trong nền, và trả lại kết quả khi sẵn sàng.

Trong mô hình này, người dùng có thể xem trạng thái hiện tại (và có thể rời khỏi hoặc tải lại trang), tài nguyên máy chủ có thể được mở rộng hiệu quả và điều chỉnh linh hoạt, và có thể áp dụng chính sách thử lại.

Một giải pháp xử lý nền điển hình bao gồm:

1. Một API để lên lịch công việc.
1. Một API để theo dõi trạng thái công việc.
1. Một worker nền để xử lý các công việc đã lên lịch.
1. Một API để lưu trữ và truy xuất kết quả.

## **Ví dụ về Nhiệm vụ Nền**

Để minh họa cách tiếp cận này, hãy xem xét [ví dụ ứng dụng web ASP.NET Core 3.1 mẫu](./BackgroundJobDemo.zip). Ứng dụng bao gồm một trang cho phép người dùng tải lên một bản trình chiếu và nhấn **Export to PDF**; bản trình chiếu sau đó được tải lên và chuyển đổi sang PDF bởi một worker nền.

## **Ứng dụng Web**

Ứng dụng web mẫu (dự án *BackgroundJobDemo*) bao gồm:

- Trang tải lên tệp (trang Razor "Upload").
- Trang tiến độ (trang Razor "Progress" với một vài hàm JavaScript kiểm tra và hiển thị trạng thái).
- Controller (`JobStatusController`) cung cấp trạng thái xử lý (`api/status/{jobId}`).
- Controller (`JobResultController`) trả về tệp PDF đã xuất (`api/result/{id}`).
- Worker nền dựa trên dịch vụ lưu trữ ASP.NET Core (xem lớp `WorkerService`).

Các trang Razor, controller và worker nền ủy thác công việc thực tế thông qua các giao diện được định nghĩa trong dự án *BackgroundJobDemo.Common*. Các triển khai cụ thể cho quản lý và xử lý công việc được cung cấp trong các dự án riêng biệt (*BackgroundJobDemo.Local*, *BackgroundJobDemo.Aws*, v.v.) và có thể được chuyển đổi trong phương thức `Startup.ConfigureServices`.

Với mục đích demo, trang "Upload" sử dụng ràng buộc mô hình có đệm, nhưng đối với việc tải lên tệp lớn, việc truyền dữ liệu không có đệm được [khuyến nghị](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads). Đối với môi trường sản xuất, hãy xem xét các [khía cạnh bảo mật](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads#security-considerations). Trang "Progress" thực hiện việc lấy trạng thái công việc đã lên lịch bằng JavaScript mỗi hai giây (khoảng thời gian này có thể cấu hình). Việc polling là thông thường, nhưng đối với các kịch bản nâng cao hơn, bạn có thể cần thông báo thời gian thực qua WebSockets (giao tiếp thời gian thực nằm ngoài phạm vi của bài viết này). [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) là một công cụ đơn giản nhưng mạnh mẽ cho giao tiếp thời gian thực.

Việc lưu trữ worker nền trong tiến trình máy chủ thuận tiện cho các ứng dụng đơn giản nhưng có [những nhược điểm](https://haacked.com/archive/2011/10/16/the-dangers-of-implementing-recurring-background-tasks-in-asp-net.aspx). Một cách tiếp cận mạnh mẽ và có khả năng mở rộng hơn là triển khai worker trong một tiến trình riêng (xem, ví dụ, ứng dụng console *BackgroundJobDemo.Worker*).

## **Triển khai Cơ bản**

Dự án *BackgroundJobDemo.Local* cung cấp một triển khai quản lý công việc đơn giản sử dụng cơ sở dữ liệu SQLite (đường dẫn cơ sở dữ liệu được cấu hình qua `LocalConfig.DbFilePath`; xem `Startup.ConfigureServices`). Các tệp đã tải lên và đã xử lý được lưu trên hệ thống tệp (đường dẫn thư mục lưu trữ được cấu hình qua `LocalConfig.FileStorageFolderPath`; xem `Startup.ConfigureServices`). Để cải thiện khả năng chịu lỗi và hiệu suất trong các ứng dụng thực tế, việc lên lịch công việc nên được thực hiện thông qua các hàng đợi tin nhắn (ví dụ, RabbitMQ, AWS SQS, Azure Storage Queue).

## **Triển khai Phân phối Dựa trên Amazon Web Services**

Dự án *BackgroundJobDemo.Aws* thực hiện việc xử lý công việc trên Amazon Web Services và thể hiện một kiến trúc phân tán có khả năng mở rộng ngang. Nó bao gồm các thành phần sau:

- Ứng dụng web — tương tác với người dùng và lên lịch các tác vụ xuất PPTX sang PDF, v.v.
- Worker — xử lý các việc xuất (trong tiến trình, ngoài tiến trình, hoặc AWS Lambda).
- Hàng đợi tin nhắn — lưu các tác vụ cần xử lý (Amazon SQS).
- Lưu trữ tệp — lưu các tệp đã tải lên và đã xử lý (Amazon S3).
- Cửa hàng khóa-giá trị — theo dõi trạng thái xử lý tác vụ (Amazon DynamoDB).

Một kiến trúc phân tán điển hình dựa vào [hàng đợi tin nhắn](https://aws.amazon.com/message-queue/): ứng dụng web đặt các tác vụ nền vào hàng đợi; một worker nền lấy các tác vụ từ hàng đợi và thực hiện công việc yêu cầu. Điều này tách biệt các thành phần và làm cho việc xử lý trở nên bất đồng bộ và đáng tin cậy. Hàng đợi đảm bảo giao hàng và sử dụng *visibility timeout*: khi một worker lấy một tin nhắn, tin nhắn đó trở nên ẩn với các worker khác; chỉ worker đang xử lý mới xóa nó sau khi hoàn thành. Nếu việc xử lý không kết thúc trong thời gian visibility timeout (ví dụ, do lỗi hoặc vấn đề mạng), tin nhắn chưa được xử lý sẽ lại hiển thị.

Triển khai của chúng tôi sử dụng [Amazon Simple Queue Service](https://aws.amazon.com/sqs/) (SQS), một hàng đợi tin nhắn được quản lý hoàn toàn cho các microservice, hệ thống phân tán và ứng dụng không máy chủ.

Hàng đợi tin nhắn được thiết kế cho các tin nhắn nhẹ (ví dụ, giới hạn kích thước tin nhắn SQS là 256 KB), vì vậy một tin nhắn chỉ nên chứa mô tả tác vụ. Dữ liệu nặng (như các tệp cần xử lý) nên được lưu riêng và được tham chiếu từ tin nhắn. [Amazon S3](https://aws.amazon.com/s3/) được sử dụng để lưu các tệp đã tải lên và đã xử lý.

Cần một cửa hàng khóa-giá trị để lưu trữ và truy xuất kết quả công việc theo ID. Ví dụ này sử dụng [Amazon DynamoDB](https://aws.amazon.com/dynamodb/), một dịch vụ cơ sở dữ liệu NoSQL nhanh và linh hoạt.

Để chạy ứng dụng demo với Amazon Web Services:

1. Trong cùng một khu vực AWS, tạo và cấu hình:
   1. một hàng đợi SQS,
   1. một bucket S3,
   1. một bảng DynamoDB.
1. Kết nối ứng dụng web với các dịch vụ này bằng cách gọi *AddAws* trong `Startup.ConfigureServices`, cung cấp URL hàng đợi SQS, tên bucket S3, tên bảng DynamoDB và khu vực AWS.

## **Tham chiếu**

- [Thực tiễn tối ưu hiệu năng ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices)
- [Tải tệp lên trong ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads)
- [ASP.NET thời gian thực với SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Hàng đợi tin nhắn](https://aws.amazon.com/message-queue/)
- [Amazon Simple Queue Service](https://aws.amazon.com/sqs/)
- [Amazon S3](https://aws.amazon.com/s3/)
- [Amazon DynamoDB](https://aws.amazon.com/dynamodb/)