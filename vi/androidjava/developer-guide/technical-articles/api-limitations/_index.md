---
title: Giới hạn API
type: docs
weight: 320
url: /vi/androidjava/api-limitations/
keywords:
- Giới hạn API
- định dạng xuất
- ứng dụng
- nhà sản xuất
- thuộc tính tài liệu
- siêu dữ liệu
- PowerPoint
- OpenDocument
- trình chiếu
- Android
- Java
- Aspose.Slides
description: "Biết giới hạn của Aspose.Slides for Android: xuất đặt siêu dữ liệu Application/Producer cố định trong PPT, PPTX, ODP và PDF—giúp bạn lên kế hoạch tích hợp mà không có bất ngờ."
---
## **Tổng quan**

Khi tạo hoặc xuất bản trình chiếu bằng Aspose.Slides, một số siêu dữ liệu kỹ thuật sẽ được ghi vào tệp kết quả. Bài viết này giải thích các hạn chế liên quan đến các trường siêu dữ liệu `Application`, `Creator` và `Producer` trong tệp PPTX và PDF.

## **Application và Producer**

Khi bạn tạo hoặc xuất bản trình chiếu bằng Aspose.Slides for Android via Java, một số siêu dữ liệu kỹ thuật sẽ được ghi vào tệp. Hai trường thường gây thắc mắc:

**Application** xác định chương trình đã tạo hoặc lưu lần cuối một trình chiếu **PPTX**. Trong Aspose.Slides for Android via Java, giá trị này được cố định và hiển thị nhà cung cấp thư viện thay vì tên ứng dụng của bạn, ngay cả khi bạn sử dụng [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).

**Producer** xác định động cơ rendering đã tạo tệp cuối cùng trong quá trình xuất. Trong xuất **PDF**, siêu dữ liệu sử dụng các trường **Creator** và **Producer**. Với Aspose.Slides for Android via Java, cả hai trường này đều được cố định và phản ánh thư viện cũng như phiên bản của nó.

**Điều bị hạn chế**

Bạn không thể ghi đè các trường này thông qua API cho các định dạng trên. Đối với **PPTX**, thuộc tính Application được ghi là "Aspose.Slides for Android via Java". Đối với **PDF**, các thuộc tính Creator và Producer được ghi là "Aspose.Slides for Android via Java x.x.x". Hành vi này được thiết kế như vậy và áp dụng bất kể cách bạn tải hoặc lưu tệp, và bất kể giá trị được gán bằng cách sử dụng [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-).