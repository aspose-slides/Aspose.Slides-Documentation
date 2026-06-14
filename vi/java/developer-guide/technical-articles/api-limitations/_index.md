---
title: "Giới hạn API"
type: docs
weight: 320
url: /vi/java/api-limitations/
keywords:
- "Giới hạn API"
- "định dạng xuất"
- "ứng dụng"
- "trình tạo"
- "thuộc tính tài liệu"
- "siêu dữ liệu"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "Java"
- "Aspose.Slides"
description: "Biết các giới hạn của Aspose.Slides for Java: xuất thiết lập siêu dữ liệu Application/Producer cố định trong PPT, PPTX, ODP và PDF—giúp bạn lên kế hoạch tích hợp mà không gặp bất ngờ."
---
## **Tổng quan**

Khi các bản trình chiếu được tạo hoặc xuất bằng Aspose.Slides, một số siêu dữ liệu kỹ thuật sẽ được ghi vào tệp đầu ra. Bài viết này giải thích các hạn chế liên quan đến các trường siêu dữ liệu `Application`, `Creator` và `Producer` trong tệp PPTX và PDF.

## **Application và Producer**

Khi bạn tạo hoặc xuất bản trình chiếu bằng Aspose.Slides for Java, một số siêu dữ liệu kỹ thuật sẽ được ghi vào tệp. Hai trường thường gây thắc mắc:

**Application** xác định chương trình đã tạo hoặc lần cuối lưu một bản trình chiếu **PPTX**. Trong Aspose.Slides for Java, giá trị này được cố định và hiển thị nhà cung cấp thư viện thay vì tên ứng dụng của bạn, ngay cả khi bạn sử dụng [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/vi/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** xác định động cơ render đã tạo ra tệp cuối cùng trong quá trình xuất. Trong các xuất **PDF**, siêu dữ liệu sử dụng các trường **Creator** và **Producer**. Với Aspose.Slides for Java, cả hai trường này đều được cố định và phản ánh thư viện cùng phiên bản của nó.

**Điều gì bị hạn chế**

Bạn không thể ghi đè các trường này thông qua API cho các định dạng trên. Đối với **PPTX**, thuộc tính Application được ghi là "Aspose.Slides for Java". Đối với **PDF**, các thuộc tính Creator và Producer được ghi là "Aspose.Slides for Java x.x.x." Hành vi này được thiết kế sẵn và áp dụng bất kể cách bạn tải hoặc lưu tệp, và bất kể các giá trị được gán bằng [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/vi/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).