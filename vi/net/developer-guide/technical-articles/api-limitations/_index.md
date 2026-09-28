---
title: Giới hạn siêu dữ liệu đầu ra
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
- trình tạo
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ghi siêu dữ liệu ứng dụng, người tạo và trình tạo cố định vào các tệp PPTX, PDF và ODP đã lưu, bất kể tên ứng dụng bạn đặt là gì."
---
## **Tổng quan**

Khi các bản trình chiếu được tạo hoặc xuất với Aspose.Slides, một số siêu dữ liệu kỹ thuật được ghi vào tệp đầu ra. Bài viết này giải thích các hạn chế liên quan đến các trường siêu dữ liệu `Application`, `Creator`, `Producer` và generator trong các tệp PPTX, PDF và ODP.

## **Application và Producer**

Khi bạn tạo hoặc xuất bản trình chiếu với Aspose.Slides for .NET, một số siêu dữ liệu kỹ thuật được ghi vào tệp. Hai trường thường gây thắc mắc:

**Application** xác định chương trình đã tạo hoặc lưu lần cuối một bản trình chiếu **PPTX**. Trong Aspose.Slides for .NET, giá trị này được cố định và hiển thị tên thư viện thay vì tên ứng dụng của bạn, ngay cả khi bạn thiết lập [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/vi/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** xác định engine render đã tạo tệp cuối cùng trong quá trình xuất. Trong các xuất **PDF**, siêu dữ liệu sử dụng các trường **Creator** và **Producer**. Với Aspose.Slides for .NET, cả hai trường này đều được cố định và phản ánh thư viện cùng phiên bản của nó.

**Điều gì bị hạn chế**

Bạn không thể ghi đè các trường này thông qua API cho các định dạng đã nêu. Đối với **PPTX**, thuộc tính Application được ghi là "Aspose.Slides for .NET". Đối với **PDF**, các thuộc tính Creator và Producer được ghi là "Aspose.Slides for .NET" kèm theo phiên bản thư viện. Đối với **ODP**, trường generator được ghi là "Aspose.Slides for .NET" kèm theo phiên bản thư viện. Hành vi này được thiết kế và áp dụng bất kể cách bạn tải hoặc lưu tệp, và bất kể các giá trị được gán cho [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/vi/net/aspose.slides/documentproperties/nameofapplication/).

Hạn chế này không áp dụng cho các tệp **PPT**: trong tệp PPT, tên ứng dụng mà bạn thiết lập trong [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/vi/net/aspose.slides/documentproperties/nameofapplication/) sẽ được lưu.