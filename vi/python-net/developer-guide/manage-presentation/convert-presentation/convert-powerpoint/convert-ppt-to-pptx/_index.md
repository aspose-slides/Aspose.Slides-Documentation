---
title: Chuyển đổi PPT sang PPTX trong Python
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/python-net/convert-ppt-to-pptx/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- PPT sang PPTX
- lưu PPT dưới dạng PPTX
- xuất PPT sang PPTX
- PowerPoint
- bài thuyết trình
- Python
- Aspose.Slides
description: "Chuyển đổi các tệp PPT cổ điển sang PPTX trong Python bằng Aspose.Slides. Bao gồm các ví dụ cho chuyển đổi tệp đơn và chuyển đổi hàng loạt, xử lý lỗi và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng PowerPoint nhị phân cổ điển, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides for Python qua .NET có thể tải tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này hướng dẫn cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những gì cần kiểm tra sau khi chuyển đổi.

## **Chuyển đổi Tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/), sau đó gọi [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) với [SaveFormat.PPTX](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/). Câu lệnh `with` sẽ giải phóng đối tượng Presentation và giải phóng tài nguyên khi khối kết thúc.

```python
import aspose.slides as slides

# Tải bài thuyết trình PPT cổ điển.
with slides.Presentation("presentation.ppt") as presentation:
    # Lưu bài thuyết trình ở định dạng PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Phần mở rộng tệp không tự động xác định định dạng đầu ra; đối số [SaveFormat.PPTX](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/) thực hiện việc này. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi Nhiều Tệp PPT**

Ví dụ sau đây chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lỗi chuyển đổi sẽ không làm dừng phần còn lại của lô.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

Đối với các công việc sản xuất, ghi lại toàn bộ ngoại lệ, quyết định xem có được ghi đè tệp đầu ra đã tồn tại hay không, và ghi tên các tệp thất bại vào hàng đợi thử lại hoặc xem xét. Các tệp hư hỏng, tệp được bảo vệ bằng mật khẩu nhưng mở mà không có mật khẩu yêu cầu, đường dẫn không truy cập được và nội dung không được hỗ trợ đều có thể gây lỗi chuyển đổi. Xem [Password-Protected Presentations](/slides/vi/python-net/password-protected-presentation/) để tải các tệp được mã hóa.

## **Độ trung thực và Các tính năng Lịch sử**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không đại diện cho mọi tính năng theo cùng một cách. Một tính năng lịch sử không có tương đương PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hoá, bỏ qua hoặc hiển thị khác nhau.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, chuyển cảnh, các đối tượng OLE nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ không phổ biến hoặc macro VBA. Tệp PPTX thông thường không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro phù hợp khi cần giữ VBA. Đồng thời xác nhận rằng các phông chữ và tài nguyên bên ngoài cần thiết có sẵn trong môi trường nơi bài thuyết trình đã chuyển đổi sẽ được mở hoặc hiển thị.

Đối với các tài liệu quan trọng, hãy mở lại tệp PPTX đã tạo bằng mã và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi trình chiếu trong trình xem mong muốn. Đừng coi một lời gọi thành công tới [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) là bằng chứng rằng mọi tính năng lịch sử đều có đại diện PPTX chính xác.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản thuyết trình sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện tại, được trao đổi với các hệ thống sử dụng gói Open XML, hoặc lưu trữ ở định dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân cổ điển. Giữ bản PPT gốc làm bản lưu trữ hoặc sao lưu cho đến khi bản thuyết trình đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS hoặc định dạng đầu ra khác, hãy sử dụng hướng dẫn theo định dạng trong [Convert Presentations to Multiple Formats](/slides/vi/python-net/convert-presentation/) thay vì cho rằng mọi đích đều giữ nguyên các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với một tệp thỉnh thoảng hoặc so sánh nhanh, bạn có thể dùng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi có tính lặp lại, xử lý hàng loạt hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng Python API.

## **Bài viết liên quan**

- [PPT vs PPTX](/slides/vi/python-net/ppt-vs-pptx/)
- [Lưu bài thuyết trình trong Python](/slides/vi/python-net/save-presentation/)
- [Các định dạng tệp được hỗ trợ](/slides/vi/python-net/supported-file-formats/)
- [Mở bài thuyết trình trong Python](/slides/vi/python-net/open-presentation/)

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi PPT sang PPTX mà không cần cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides for Python qua .NET có thể tải và lưu các tệp bài thuyết trình mà không cần Microsoft PowerPoint.

**Quá trình chuyển đổi PPT sang PPTX có giữ nguyên toàn bộ nội dung một cách chính xác không?**

Nó giữ lại nội dung chung của bài thuyết trình, nhưng độ trung thực tuyệt đối không được đảm bảo cho mọi tính năng cổ hoặc không được hỗ trợ. Hãy xem lại tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh đặc biệt, hoặc phông chữ không phổ biến.

**Tôi có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp mật khẩu đúng khi tải tệp. Thiếu mật khẩu hoặc mật khẩu sai sẽ khiến quá trình tải thất bại.

**Tôi có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ bản gốc cho đến khi bạn đã xác minh PPTX trong các trình xem và quy trình làm việc quan trọng. Điều này cung cấp một bản sao dự phòng nếu một tính năng lịch sử được chuyển đổi khác nhau.