---
title: "Chuyển đổi PPT sang PPTX trong Python"
linktitle: "PPT sang PPTX"
type: docs
weight: 20
url: /vi/python-net/convert-ppt-to-pptx/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- PPT sang PPTX
- lưu PPT thành PPTX
- xuất PPT sang PPTX
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Chuyển đổi các tệp PPT legacy sang PPTX trong Python với Aspose.Slides. Bao gồm các ví dụ cho chuyển đổi tệp đơn và hàng loạt, xử lý lỗi, và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng PowerPoint nhị phân legacy, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides for Python qua .NET có thể tải tệp PPT và lưu thành PPTX mà không cần Microsoft PowerPoint. Bài viết này hướng dẫn cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những điều cần kiểm tra sau khi chuyển đổi.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/), sau đó gọi [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) với [SaveFormat.PPTX](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/). Câu lệnh `with` sẽ giải phóng Presentation và giải phóng các tài nguyên khi khối kết thúc.

```python
import aspose.slides as slides

# Tải bản trình chiếu PPT cũ.
with slides.Presentation("presentation.ppt") as presentation:
    # Lưu bản trình chiếu ở định dạng PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Phần mở rộng tệp không tự động xác định định dạng đầu ra; đối số [SaveFormat.PPTX](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/) làm điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ dưới đây chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một chuyển đổi thất bại sẽ không làm dừng phần còn lại của lô.

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

Đối với môi trường sản xuất, ghi lại toàn bộ ngoại lệ, quyết định liệu có cho phép ghi đè tệp đầu ra đã tồn tại hay không, và ghi các tên tệp thất bại vào hàng đợi retry hoặc review. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu nhưng mở mà không có mật khẩu cần thiết, đường dẫn không truy cập được và nội dung không được hỗ trợ đều có thể gây lỗi chuyển đổi. Xem [Password-Protected Presentations](/python-net/password-protected-presentation/) để tải tệp đã mã hóa.

## **Độ trung thực và tính năng Legacy**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không đại diện cho mọi tính năng một cách hoàn toàn giống nhau. Một tính năng legacy không có tương đương trong PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hoá, bỏ qua, hoặc hiển thị khác đi.

Hãy kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, chuyển đổi, các đối tượng OLE nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ hiếm hoặc macro VBA. Tệp PPTX thuần không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình phù hợp hỗ trợ macro khi VBA cần được duy trì. Ngoài ra, xác minh rằng các phông chữ và tài nguyên bên ngoài yêu cầu có sẵn trong môi trường mà bản trình chiếu đã chuyển đổi sẽ được mở hoặc render.

Đối với các tài liệu quan trọng, hãy mở lại PPTX đã tạo bằng cách lập trình và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi trình chiếu trong trình xem dự kiến. Đừng coi một lời gọi [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) thành công là bằng chứng rằng mọi tính năng legacy đều có bản đại diện PPTX chính xác.

## **Khi nào nên dùng PPTX**

Sử dụng PPTX khi bản trình chiếu sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện tại, được trao đổi với các hệ thống làm việc với gói Open XML, hoặc lưu trữ dưới dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân legacy. Giữ bản PPT gốc làm bản lưu trữ hoặc sao lưu cho tới khi bản trình chiếu đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS, hoặc kiểu đầu ra khác, hãy sử dụng hướng dẫn theo định dạng trong [Convert Presentations to Multiple Formats](/python-net/convert-presentation/) thay vì giả định rằng mọi mục tiêu đều bảo lưu các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với các tệp không thường xuyên hoặc muốn so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý batch, hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng Python API.

## **Bài viết liên quan**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Lưu Bản Trình Chiếu trong Python](/python-net/save-presentation/)
- [Các Định Dạng Tệp Được Hỗ Trợ](/python-net/supported-file-formats/)
- [Mở Bản Trình Chiếu trong Python](/python-net/open-presentation/)

## **Câu hỏi thường gặp**

**Có thể chuyển đổi PPT sang PPTX mà không cần cài đặt Microsoft PowerPoint không?**

Đúng. Aspose.Slides for Python qua .NET tải và lưu các tệp trình chiếu mà không cần Microsoft PowerPoint.

**Việc chuyển đổi PPT sang PPTX có bảo toàn toàn bộ nội dung một cách chính xác không?**

Nó bảo toàn nội dung trình chiếu phổ biến, nhưng độ trung thực chính xác không được đảm bảo cho mọi tính năng legacy hoặc không được hỗ trợ. Hãy xem lại tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh chuyên biệt, hoặc phông chữ hiếm.

**Có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Đúng, nếu bạn cung cấp đúng mật khẩu khi tải tệp. Thiếu hoặc sai mật khẩu sẽ khiến thao tác tải thất bại.

**Có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ bản gốc cho đến khi bạn đã kiểm chứng PPTX trong các trình xem và quy trình làm việc quan trọng. Điều này cung cấp bản sao dự phòng nếu tính năng legacy chuyển đổi khác nhau.