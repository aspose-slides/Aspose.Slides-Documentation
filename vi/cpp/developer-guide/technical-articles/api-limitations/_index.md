---
title: Các hạn chế API
type: docs
weight: 320
url: /vi/cpp/api-limitations/
keywords:
- Các hạn chế API
- định dạng xuất
- ứng dụng
- trình tạo
- thuộc tính tài liệu
- siêu dữ liệu
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Biết các giới hạn của Aspose.Slides cho C++: việc xuất đặt siêu dữ liệu Application/Producer cố định trong PPT, PPTX, ODP và PDF—giúp bạn lập kế hoạch tích hợp mà không gặp bất ngờ."
---
## **Tổng quan**

Khi các bản trình chiếu được tạo hoặc xuất với Aspose.Slides, một số siêu dữ liệu kỹ thuật được ghi vào tệp đầu ra. Bài viết này giải thích các hạn chế liên quan đến các trường siêu dữ liệu `Application`, `Creator` và `Producer` trong tệp PPTX và PDF.

## **Ứng dụng và Trình tạo**

Khi bạn tạo hoặc xuất bản trình chiếu bằng Aspose.Slides cho C++, một số siêu dữ liệu kỹ thuật được ghi vào tệp. Hai trường thường gây ra câu hỏi:

**Application** xác định chương trình đã tạo hoặc lưu lần cuối một bản trình chiếu **PPTX**. Trong Aspose.Slides cho C++, giá trị này cố định và hiển thị nhà cung cấp thư viện thay vì tên ứng dụng của bạn, ngay cả khi bạn sử dụng [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/vi/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** xác định động cơ rendering đã tạo tệp cuối cùng trong quá trình xuất. Trong các xuất **PDF**, siêu dữ liệu sử dụng các trường **Creator** và **Producer**. Với Aspose.Slides cho C++, cả hai trường này đều cố định và phản ánh thư viện cùng phiên bản của nó.

**Những gì bị hạn chế**

Bạn không thể ghi đè các trường này thông qua API cho các định dạng trên. Đối với **PPTX**, thuộc tính Application được ghi là "Aspose.Slides for C++". Đối với **PDF**, các thuộc tính Creator và Producer được ghi là "Aspose.Slides for C++ x.x.x". Hành vi này được thiết kế như vậy và áp dụng bất kể cách bạn tải hoặc lưu tệp, và bất kể giá trị được gán bằng cách sử dụng [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/vi/cpp/aspose.slides/documentproperties/set_nameofapplication/).