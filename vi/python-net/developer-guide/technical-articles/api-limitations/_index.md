---
title: Giới hạn API
type: docs
weight: 210
url: /vi/python-net/api-limitations/
keywords:
- Giới hạn API
- định dạng xuất
- ứng dụng
- trình tạo
- thuộc tính tài liệu
- siêu dữ liệu
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Biết các hạn chế của Aspose.Slides for Python: xuất tài liệu sẽ đặt siêu dữ liệu Application/Producer cố định trong PPT, PPTX, ODP và PDF—giúp bạn lên kế hoạch tích hợp mà không gặp bất ngờ."
---
## **Tổng quan**

Khi các bản trình chiếu được tạo hoặc xuất với Aspose.Slides, một số siêu dữ liệu kỹ thuật được ghi vào tệp đầu ra. Bài viết này giải thích các hạn chế liên quan đến các trường siêu dữ liệu `Application`, `Creator` và `Producer` trong các tệp PPTX và PDF.

## **Application và Producer**

Khi bạn tạo hoặc xuất các bản trình chiếu với Aspose.Slides for Python via .NET, một số siêu dữ liệu kỹ thuật được ghi vào tệp. Hai trường thường gây ra câu hỏi:

**Application** xác định chương trình đã tạo hoặc lưu lần cuối một bản trình chiếu **PPTX**. Trong Aspose.Slides for Python via .NET, giá trị này được cố định và hiển thị nhà cung cấp thư viện thay vì tên ứng dụng của bạn, ngay cả khi bạn đặt [DocumentProperties.name_of_application](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** xác định engine render đã tạo tệp cuối cùng trong quá trình xuất. Trong các xuất **PDF**, siêu dữ liệu sử dụng các trường **Creator** và **Producer**. Với Aspose.Slides for Python via .NET, cả hai trường này đều cố định và phản ánh thư viện cùng phiên bản của nó.

**Điều bị hạn chế**

Bạn không thể ghi đè các trường này thông qua API cho các định dạng nêu trên. Đối với **PPTX**, thuộc tính Application được ghi là "Aspose.Slides for Python via .NET". Đối với **PDF**, các thuộc tính Creator và Producer được ghi là "Aspose.Slides for Python via .NET x.x.x". Hành vi này được thiết kế như vậy và áp dụng bất kể cách bạn tải hoặc lưu tệp, cũng như bất kể các giá trị được gán cho [DocumentProperties.name_of_application](https://reference.aspose.com/slides/vi/python-net/aspose.slides/documentproperties/name_of_application/).