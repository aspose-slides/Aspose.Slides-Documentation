---
title: Các giới hạn API
type: docs
weight: 320
url: /vi/php-java/api-limitations/
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
- PHP
- Aspose.Slides
description: "Biết các giới hạn của Aspose.Slides cho PHP: việc xuất đặt siêu dữ liệu Application/Producer cố định trong PPT, PPTX, ODP và PDF—giúp bạn lên kế hoạch tích hợp mà không gặp bất ngờ."
---
## **Tổng quan**

Khi các bài thuyết trình được tạo hoặc xuất bằng Aspose.Slides, một số siêu dữ liệu kỹ thuật được ghi vào tệp đầu ra. Bài viết này giải thích các hạn chế liên quan đến các trường siêu dữ liệu `Application`, `Creator` và `Producer` trong tệp PPTX và PDF.

## **Application và Producer**

Khi bạn tạo hoặc xuất các bài thuyết trình bằng Aspose.Slides for PHP via Java, một số siêu dữ liệu kỹ thuật được ghi vào tệp. Hai trường thường gây thắc mắc:

**Application** xác định chương trình đã tạo hoặc lưu lần cuối một bài thuyết trình **PPTX**. Trong Aspose.Slides for PHP via Java, giá trị này được cố định và hiển thị nhà cung cấp thư viện thay vì tên ứng dụng của bạn, ngay cả khi bạn sử dụng [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/setnameofapplication/).

**Producer** xác định động cơ render đã tạo ra tệp cuối cùng trong quá trình xuất. Trong xuất **PDF**, siêu dữ liệu sử dụng các trường **Creator** và **Producer**. Với Aspose.Slides for PHP via Java, cả hai trường này được cố định và phản ánh thư viện cùng phiên bản của nó.

**Những gì bị hạn chế**

Bạn không thể ghi đè các trường này thông qua API cho các định dạng nêu trên. Đối với **PPTX**, thuộc tính Application được ghi là "Aspose.Slides for PHP via Java". Đối với **PDF**, các thuộc tính Creator và Producer được ghi là "Aspose.Slides for PHP via Java x.x.x." Hành vi này được thiết kế sẵn và áp dụng bất kể cách bạn tải hoặc lưu tệp, cũng như bất kể các giá trị được gán bằng cách sử dụng [DocumentProperties::setNameOfApplication](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/setnameofapplication/).