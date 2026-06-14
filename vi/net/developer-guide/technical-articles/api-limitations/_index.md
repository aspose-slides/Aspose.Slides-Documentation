---
title: Giới hạn API
type: docs
weight: 320
url: /vi/net/api-limitations/
keywords:
- Giới hạn API
- định dạng xuất
- ứng dụng
- trình tạo
- thuộc tính tài liệu
- siêu dữ liệu
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Biết giới hạn của Aspose.Slides for .NET: xuất đặt siêu dữ liệu Application/Producer cố định trong PPT, PPTX, ODP và PDF—giúp bạn lên kế hoạch tích hợp mà không gặp bất ngờ."
---
## **Tổng quan**

Khi các bài thuyết trình được tạo hoặc xuất bằng Aspose.Slides, một số siêu dữ liệu kỹ thuật được ghi vào tệp đầu ra. Bài viết này giải thích các hạn chế liên quan đến các trường siêu dữ liệu `Application`, `Creator` và `Producer` trong tệp PPTX và PDF.

## **Ứng dụng và Trình tạo**

Khi bạn tạo hoặc xuất các bài thuyết trình bằng Aspose.Slides for .NET, một số siêu dữ liệu kỹ thuật được ghi vào tệp. Hai trường này thường gây ra câu hỏi:

**Application** xác định chương trình đã tạo hoặc lần cuối lưu một bài thuyết trình **PPTX**. Trong Aspose.Slides for .NET, giá trị này được cố định và hiển thị nhà cung cấp thư viện thay vì tên ứng dụng của bạn, ngay cả khi bạn đặt [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/vi/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** xác định công cụ render tạo ra tệp cuối cùng trong quá trình xuất. Trong các xuất **PDF**, siêu dữ liệu sử dụng các trường **Creator** và **Producer**. Với Aspose.Slides for .NET, cả hai trường này đều được cố định và phản ánh thư viện cùng phiên bản của nó.

**Điều gì bị hạn chế**

Bạn không thể ghi đè các trường này thông qua API cho các định dạng ở trên. Đối với **PPTX**, thuộc tính Application được ghi là "Aspose.Slides for .NET". Đối với **PDF**, các thuộc tính Creator và Producer được ghi là "Aspose.Slides for .NET x.x.x". Hành vi này được thiết kế như vậy và áp dụng bất kể cách bạn tải hoặc lưu tệp, và bất kể giá trị được gán cho [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/vi/net/aspose.slides/documentproperties/nameofapplication/).