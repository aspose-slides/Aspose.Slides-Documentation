---
title: Cách chạy các ví dụ
type: docs
weight: 130
url: /vi/net/how-to-run-examples/
keywords:
- ví dụ
- yêu cầu phần mềm
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Chạy các ví dụ Aspose.Slides cho .NET nhanh chóng: sao chép kho, khôi phục các gói, sau đó biên dịch và kiểm thử các tính năng cho PPT, PPTX và ODP."
---
## **Yêu cầu phần mềm**
Trước khi bạn tải xuống và chạy các ví dụ, vui lòng kiểm tra và xác nhận rằng thiết lập của bạn đáp ứng các yêu cầu sau:

- Visual Studio 2010 trở lên.
- NuGet Package Manager đã được cài đặt trong Visual Studio. Xác minh rằng phiên bản API NuGet mới nhất đã được cài đặt trong Visual Studio.

Để biết hướng dẫn cài đặt NuGet package manager, truy cập trang này: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. Đi tới **Tools**>**Options**>**NuGet Package Manager**.

1. Mở rộng **NuGet Package Manager** (bằng cách nhấp đúp vào nó) và sau đó chọn **Package Sources**.

1. Kiểm tra và xác nhận rằng tham số nuget.org đã được chọn.

   Dự án ví dụ sử dụng tính năng Khôi phục Gói Tự động của NuGet, vì vậy bạn cần có kết nối internet hoạt động.

   Nếu bạn không có kết nối internet hoạt động trên máy mà bạn dự định thực thi các ví dụ, vui lòng kiểm tra [Installation](https://docs.aspose.com/slides/vi/net/installation/) và (thủ công) thêm tham chiếu đến Aspose.Slides.dll trong dự án ví dụ.
## **Tải Aspose.Slides từ GitHub**
Tất cả các ví dụ Aspose.Slides cho .NET được lưu trữ trên [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET).

Bạn có thể sao chép (clone) kho lưu trữ bằng công cụ GitHub yêu thích của mình hoặc tải tệp ZIP [tại đây](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. Nếu bạn tải tệp ZIP, bạn phải giải nén nội dung của nó vào một thư mục trên máy tính của mình.

Tất cả các ví dụ được lưu trong thư mục **Examples**.

Có một tệp giải pháp Visual Studio cho C#. Các dự án được tạo trong Visual Studio 2013, nhưng các tệp giải pháp tương thích với Visual Studio 2010 SP1 và các phiên bản cao hơn.

2. Mở tệp giải pháp trong Visual Studio và biên dịch (build) dự án.

   Lần chạy đầu tiên, các phụ thuộc sẽ được tải xuống tự động qua NuGet.

Thư mục **Data** ở thư mục gốc của **Examples** chứa các tệp đầu vào được sử dụng trong các ví dụ C#. Bạn phải tải thư mục **Data** cùng với dự án ví dụ.

3. Mở tệp RunExamples.cs. Tất cả các ví dụ được gọi từ đây.

4. Bỏ chú thích (uncomment) các ví dụ bạn muốn chạy trong dự án.

Vui lòng liên hệ qua diễn đàn của chúng tôi nếu bạn gặp vấn đề trong việc thiết lập hoặc chạy các ví dụ.
## **Đóng góp**
Bạn có thể đóng góp vào dự án bằng cách thêm hoặc cải thiện một ví dụ. Tất cả các ví dụ và dự án showcase trong kho lưu trữ đều là mã nguồn mở, vì vậy bạn (và những người khác) có thể sử dụng chúng tự do trong các ứng dụng.

Để đóng góp, bạn có thể fork kho lưu trữ, chỉnh sửa mã nguồn và tạo một pull request. Chúng tôi sẽ xem xét các thay đổi. Nếu chúng hữu ích, chúng tôi sẽ thêm chúng vào kho lưu trữ.