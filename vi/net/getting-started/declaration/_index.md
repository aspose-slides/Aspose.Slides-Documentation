---
title: Khai báo
type: docs
weight: 110
url: /vi/net/declaration/
keywords:
- khai báo
- thành phần
- quyền Full Trust
- cài đặt registry
- tệp hệ thống
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu về các yêu cầu tin cậy, quyền và giới hạn lưu trữ của Aspose.Slides cho .NET để bạn có thể triển khai an toàn các ứng dụng xử lý PPT, PPTX và ODP trên máy chủ."
---
{{% alert color="primary" %}}

Tất cả các thành phần Aspose .NET yêu cầu bộ quyền Full Trust vì chúng đôi khi phải truy cập các cài đặt registry, các tệp hệ thống và các tệp lưu trữ ở các vị trí khác (ngoài thư mục ảo) cho một số thao tác nhất định (ví dụ: phân tích phông chữ). Hơn nữa, Aspose .NET Components dựa trên các lớp hệ thống .NET nền tảng, vốn trong nhiều trường hợp cũng yêu cầu bộ quyền Full Trust.

{{% /alert %}}

Các nhà cung cấp dịch vụ Internet, nơi lưu trữ nhiều ứng dụng từ các công ty khác nhau, thường áp dụng mức bảo mật Medium Trust. Trong trường hợp .NET 2.0, mức bảo mật này áp đặt các ràng buộc sau:

- OleDbPermission không khả dụng. Điều này có nghĩa là bạn không thể sử dụng nhà cung cấp dữ liệu OLE DB quản lý của ADO.NET để truy cập cơ sở dữ liệu.
- EventLogPermission không khả dụng. Điều này có nghĩa là bạn không thể truy cập nhật ký sự kiện Windows.
- ReflectionPermission không khả dụng. Điều này có nghĩa là bạn không thể sử dụng reflection.
- RegistryPermission không khả dụng. Điều này có nghĩa là bạn không thể truy cập registry.
- WebPermission bị hạn chế. Điều này có nghĩa là ứng dụng của bạn chỉ có thể giao tiếp với một địa chỉ hoặc dải địa chỉ mà bạn đã định nghĩa trong phần tử <trust>.
- FileIOPermission bị hạn chế. Điều này có nghĩa là bạn chỉ có thể truy cập các tệp trong cây thư mục ảo của ứng dụng.

{{% alert color="primary" %}}

Do những lý do nêu trên, các thành phần Aspose .NET chỉ có thể được sử dụng trên các máy chủ cung cấp bộ quyền Full Trust.

{{% /alert %}}