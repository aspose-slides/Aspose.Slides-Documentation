---
title: "Các giới hạn API"
type: docs
weight: 320
url: /vi/python-java/api-limitations/
keywords:
- "Các giới hạn API"
- "định dạng xuất"
- "ứng dụng"
- "trình tạo"
- "thuộc tính tài liệu"
- "siêu dữ liệu"
- "PowerPoint"
- "OpenDocument"
- "bài thuyết trình"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Tìm hiểu về các giới hạn của Aspose.Slides for Python via Java: siêu dữ liệu Application, Creator và Producer cố định trong tệp PPTX và PDF."
---
## **Tổng quan**

Khi các bản trình bày được tạo hoặc xuất bằng Aspose.Slides, một số siêu dữ liệu kỹ thuật sẽ được ghi vào tệp đầu ra. Bài viết này giải thích các hạn chế liên quan đến các trường siêu dữ liệu `Application`, `Creator` và `Producer` trong tệp PPTX và PDF.

## **Ứng dụng và Trình tạo**

Khi bạn tạo hoặc xuất bản trình bày bằng Aspose.Slides for Python via Java, một số siêu dữ liệu kỹ thuật sẽ được ghi vào tệp. Hai trường thường gây thắc mắc:

**Application** xác định chương trình đã tạo hoặc lần cuối lưu một bản trình bày **PPTX**. Trong Aspose.Slides for Python via Java, giá trị này cố định và hiển thị nhà cung cấp thư viện thay vì tên ứng dụng của bạn, ngay cả khi bạn sử dụng [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** xác định công cụ render đã tạo tệp cuối cùng trong quá trình xuất. Trong các xuất **PDF**, siêu dữ liệu sử dụng các trường **Creator** và **Producer**. Với Aspose.Slides for Python via Java, cả hai trường này đều cố định và phản ánh thư viện cùng phiên bản của nó.

**Điều gì bị hạn chế**

Bạn không thể ghi đè các trường này thông qua API cho các định dạng ở trên. Đối với **PPTX**, thuộc tính Application được ghi là “Aspose.Slides for Java”. Đối với **PDF**, các thuộc tính Creator và Producer được ghi là “Aspose.Slides for Java x.x.x.”. Hành vi này được thiết kế sẵn và áp dụng bất kể cách bạn tải hoặc lưu tệp, và bất kể giá trị được gán bằng [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **Câu hỏi thường gặp**

**Tôi có thể thay thế giá trị Application trong tệp PPTX bằng tên ứng dụng của mình không?**

Không. Giá trị này cố định, ngay cả khi bạn sử dụng [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/vi/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Tôi có thể ghi đè các trường Creator và Producer trong xuất PDF không?**

Không. Cả hai trường này đều cố định và phản ánh thư viện cùng phiên bản của nó, bất kể cách bạn tải hoặc lưu bản trình bày.