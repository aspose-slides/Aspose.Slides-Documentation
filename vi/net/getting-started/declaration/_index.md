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
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu về các yêu cầu tin cậy, quyền hạn và giới hạn lưu trữ của Aspose.Slides cho .NET để bạn có thể triển khai an toàn các ứng dụng xử lý PPT, PPTX và ODP trên máy chủ."
---
{{% alert color="info" %}} 

Tất cả các thành phần Aspose .NET yêu cầu bộ quyền Full Trust vì chúng đôi khi phải truy cập cài đặt registry, tệp hệ thống và các tệp được lưu ở các vị trí khác (ngoài thư mục ảo) cho một số thao tác (ví dụ: phân tích phông chữ). Hơn nữa, các thành phần Aspose .NET dựa trên các lớp hệ thống .NET cốt lõi, mà trong nhiều trường hợp cũng yêu cầu bộ quyền Full Trust. 

{{% /alert %}} 

Các nhà cung cấp dịch vụ Internet, những người lưu trữ nhiều ứng dụng từ các công ty khác nhau, thường áp dụng mức bảo mật Medium Trust. Trong trường hợp .NET 2.0, mức bảo mật này áp đặt các ràng buộc sau: 

- OleDbPermission không khả dụng. Điều này có nghĩa là bạn không thể sử dụng nhà cung cấp dữ liệu OLE DB quản lý của ADO.NET để truy cập cơ sở dữ liệu.  
- EventLogPermission không khả dụng. Điều này có nghĩa là bạn không thể truy cập nhật ký sự kiện Windows.  
- ReflectionPermission không khả dụng. Điều này có nghĩa là bạn không thể sử dụng reflection.  
- RegistryPermission không khả dụng. Điều này có nghĩa là bạn không thể truy cập registry.  
- WebPermission bị hạn chế. Điều này có nghĩa là ứng dụng của bạn chỉ có thể giao tiếp với một địa chỉ hoặc dải địa chỉ mà bạn đã định nghĩa trong phần tử <trust>.  
- FileIOPermission bị hạn chế. Điều này có nghĩa là bạn chỉ có thể truy cập các tệp trong cây thư mục ảo của ứng dụng của bạn.  

{{% alert color="info" %}} 

Do các lý do ở trên, các thành phần Aspose .NET chỉ có thể được sử dụng trên các máy chủ cấp bộ quyền Full Trust. 

{{% /alert %}}