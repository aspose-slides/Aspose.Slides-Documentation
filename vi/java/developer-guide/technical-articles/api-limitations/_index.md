---
title: Hạn chế siêu dữ liệu đầu ra
type: docs
weight: 320
url: /vi/java/api-limitations/
keywords:
- Hạn chế API
- định dạng xuất
- ứng dụng
- trình tạo
- thuộc tính tài liệu
- siêu dữ liệu
- bộ sinh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ghi các siêu dữ liệu ứng dụng, người tạo và trình tạo cố định vào các tệp PPTX, PDF và ODP đã lưu, bất kể tên ứng dụng bạn đặt là gì."
---
## **Tổng quan**

Khi các bài thuyết trình được tạo hoặc xuất khẩu bằng Aspose.Slides, một số siêu dữ liệu kỹ thuật được ghi vào tệp đầu ra. Bài viết này giải thích các hạn chế liên quan đến các trường siêu dữ liệu `Application`, `Creator`, `Producer` và generator trong các tệp PPTX, PDF và ODP.

## **Ứng dụng và Trình tạo**

Khi bạn tạo hoặc xuất khẩu các bài thuyết trình bằng Aspose.Slides for Java, một số siêu dữ liệu kỹ thuật được ghi vào tệp. Hai trường thường gây ra câu hỏi:

**Application** xác định chương trình đã tạo hoặc lưu lần cuối một bài thuyết trình **PPTX**. Trong Aspose.Slides for Java, giá trị này được cố định và hiển thị tên thư viện thay vì tên ứng dụng của bạn, ngay cả khi bạn sử dụng [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/vi/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** xác định động cơ render đã tạo ra tệp cuối cùng trong quá trình xuất khẩu. Trong các xuất **PDF**, siêu dữ liệu sử dụng các trường **Creator** và **Producer**. Với Aspose.Slides for Java, cả hai trường này đều được cố định và phản ánh thư viện cùng phiên bản của nó.

**What’s restricted**

Bạn không thể ghi đè các trường này thông qua API cho các định dạng nêu trên. Đối với **PPTX**, thuộc tính Application được ghi là "Aspose.Slides for Java". Đối với **PDF**, các thuộc tính Creator và Producer được ghi là "Aspose.Slides for Java" kèm theo phiên bản của thư viện. Đối với **ODP**, trường generator được ghi là "Aspose.Slides for Java" kèm theo phiên bản của thư viện. Hành vi này được thiết kế như vậy và áp dụng bất kể cách bạn tải hoặc lưu tệp, và bất kể các giá trị được gán bằng cách sử dụng [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/vi/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

Hạn chế này không áp dụng cho các tệp **PPT**: trong một tệp PPT, tên ứng dụng mà bạn đặt bằng [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/vi/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) sẽ được lưu.