---
title: "Yêu cầu Trình quản lý bảo mật"
type: docs
weight: 190
url: /vi/java/declaration/
keywords:
- Trình quản lý bảo mật
- chính sách bảo mật
- AllPermission
- các quyền
- sandbox
- JDK 24
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Các quyền Trình quản lý bảo mật mà Aspose.Slides cho Java và mã gọi nó cần trên Java 23 và các phiên bản trước, và lý do không có gì cần cấu hình trên Java 24 và các phiên bản sau."
---
## **Tổng quan**

Trình quản lý bảo mật Java (Java Security Manager) giới hạn những gì mã có thể làm dựa trên chính sách bảo mật. Java 17 đã khai báo không dùng nữa để loại bỏ ([JEP 411](https://openjdk.org/jeps/411)), và Java 24 đã tắt vĩnh viễn ([JEP 486](https://openjdk.org/jeps/486)). Bài viết này giải thích những yêu cầu của Aspose.Slides cho Java khi một ứng dụng vẫn chạy với Trình quản lý bảo mật. Nếu ứng dụng của bạn không bật tính năng này, đây là mặc định, thì không cần cấu hình gì.

## **Java 23 và Trước đó**

Khi Trình quản lý bảo mật được bật, chính sách bảo mật phải cấp các quyền sau cho tệp JAR của Aspose.Slides và cho mã ứng dụng gọi nó:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides đọc các thuộc tính hệ thống.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides đọc các tệp phông chữ và các tệp khác.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides khởi chạy các chương trình hệ điều hành, ví dụ `reg` trên Windows và `fc-match` trên Linux.
- `java.io.FilePermission` với hành động `write` cho các thư mục nơi ứng dụng của bạn lưu tệp.

Việc cấp quyền chỉ cho tệp JAR là không đủ: mã gọi Aspose.Slides cũng cần chúng. Cấp `java.security.AllPermission` cho cả hai cũng hoạt động.

Nếu không có quyền đọc các thuộc tính hệ thống hoặc khởi chạy các chương trình, Aspose.Slides sẽ thất bại ngay khi sử dụng lần đầu: việc tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) sẽ ném ra `ExceptionInInitializerError`. Nếu không có quyền đọc các tệp phông chữ, việc lưu bài thuyết trình dưới dạng PDF sẽ gặp lỗi "Cannot find any fonts installed on the system".

## **Java 24 và Sau này**

Trình quản lý bảo mật không thể được bật trên Java 24 và các phiên bản sau, vì vậy không có quyền nào cần cấp. Aspose.Slides chạy với quyền của tài khoản chạy ứng dụng của bạn. Để hạn chế những gì một ứng dụng có thể truy cập, dự án OpenJDK đề xuất các công nghệ bên ngoài JDK, chẳng hạn như container, hypervisor và các tính năng sandbox của hệ điều hành. Xem [JEP 486](https://openjdk.org/jeps/486).

## **Câu hỏi thường gặp**

**Tôi có thể sử dụng Aspose.Slides trong môi trường chạy ứng dụng dưới chính sách Trình quản lý bảo mật hạn chế không?**

Chỉ khi chính sách cấp các quyền đã liệt kê ở trên cho cả Aspose.Slides và mã gọi nó. Các quyền này bao gồm việc đọc tất cả các tệp và khởi chạy bất kỳ chương trình nào.