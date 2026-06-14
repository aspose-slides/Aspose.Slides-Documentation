---
title: Khai báo
type: docs
weight: 60
url: /vi/java/declaration/
keywords:
- khai báo
- thành phần
- quyền Full Trust
- cài đặt registry
- tệp hệ thống
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu về yêu cầu tin cậy, quyền hạn và hạn chế lưu trữ của Aspose.Slides cho Java để bạn có thể triển khai an toàn các ứng dụng xử lý PPT, PPTX và ODP trên máy chủ."
---
{{% alert color="primary" %}} 

Tất cả các thành phần Aspose Java yêu cầu bộ quyền Full Trust. Lý do là, các thành phần Aspose Java cần truy cập cài đặt registry, các tệp hệ thống ngoài thư mục ảo cho một số thao tác như phân tích font, v.v. Hơn nữa, các thành phần Aspose Java dựa trên các lớp hệ thống Java nền tảng, vốn cũng yêu cầu bộ quyền Full Trust trong nhiều trường hợp. 

{{% /alert %}} 

Các nhà cung cấp dịch vụ Internet (ISP) lưu trữ nhiều ứng dụng từ các công ty khác nhau thường áp dụng mức bảo mật Medium Trust: 

- OleDbPermission không khả dụng. Điều này có nghĩa là bạn không thể sử dụng nhà cung cấp dữ liệu OLE DB được quản lý của ADO.NET để truy cập cơ sở dữ liệu.
- EventLogPermission không khả dụng. Điều này có nghĩa là bạn không thể truy cập nhật ký sự kiện Windows.
- ReflectionPermission không khả dụng. Điều này có nghĩa là bạn không thể sử dụng reflection.
- RegistryPermission không khả dụng. Điều này có nghĩa là bạn không thể truy cập registry.
- WebPermission bị hạn chế. Điều này có nghĩa là ứng dụng của bạn chỉ có thể giao tiếp với một địa chỉ hoặc một dải địa chỉ mà bạn định nghĩa trong phần tử <trust>.
- FileIOPermission bị hạn chế. Điều này có nghĩa là bạn chỉ có thể truy cập các tệp trong cây thư mục ảo của ứng dụng.

{{% alert color="primary" %}} 

Do các lý do nêu trên, các thành phần Aspose Java không thể được sử dụng trên các máy chủ cấp bộ quyền khác ngoài Full Trust. 

{{% /alert %}}