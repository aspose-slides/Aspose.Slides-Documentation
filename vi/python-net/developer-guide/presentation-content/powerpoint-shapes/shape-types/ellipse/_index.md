---
title: Thêm Hình elip vào Bản trình bày trong Python
linktitle: Elip
type: docs
weight: 30
url: /vi/python-net/ellipse/
keywords:
- elip
- hình dạng
- thêm elip
- tạo elip
- vẽ elip
- elip có định dạng
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách tạo, định dạng và thao tác với các hình elip trong Aspose.Slides for Python via .NET trên các bản trình bày PPT, PPTX và ODP — kèm ví dụ mã."
---
## **Tổng quan**

Bài viết này hướng dẫn cách thêm các hình elip vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một hình elip đơn giản, tạo một hình elip có định dạng và lưu bản trình bày đã cập nhật dưới dạng tệp PPTX. Ngoài ra, còn đề cập đến các câu hỏi liên quan như làm việc với vị trí và kích thước của elip, kiểm soát thứ tự xếp chồng, và áp dụng hiệu ứng hoạt hình.

## **Tạo Hình elip**
Trong chủ đề này, chúng tôi sẽ giới thiệu cho các nhà phát triển cách thêm các hình elip vào slide của họ bằng Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET cung cấp một bộ API dễ dùng để vẽ các loại hình khác nhau chỉ với vài dòng mã. Để thêm một hình elip đơn giản vào slide đã chọn của bản trình bày, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/)
2. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó
3. Thêm một AutoShape loại Ellipse bằng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes
4. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX

Trong ví dụ dưới đây, chúng tôi đã thêm một hình elip vào slide đầu tiên.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp PPTX
with slides.Presentation() as pres:
    # Lấy slide đầu tiên
    sld = pres.slides[0]

    # Thêm hình dạng tự động loại elip
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Ghi tệp PPTX ra đĩa
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tạo Hình elip Định dạng**
Để thêm một hình elip có định dạng tốt hơn vào một slide, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/)
2. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó
3. Thêm một AutoShape loại Ellipse bằng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes
4. Đặt Fill Type của Ellipse thành Solid
5. Đặt Color của Ellipse bằng thuộc tính SolidFillColor.Color được cung cấp bởi đối tượng FillFormat liên kết với đối tượng IShape
6. Đặt Color của các đường viền của Ellipse
7. Đặt Width của các đường viền của Ellipse
8. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX

Trong ví dụ dưới đây, chúng tôi đã thêm một hình elip đã định dạng vào slide đầu tiên của bản trình bày.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Khởi tạo lớp Presentation đại diện cho tệp PPTX
with slides.Presentation() as pres:
    # Lấy slide đầu tiên
    sld = pres.slides[0]

    # Thêm hình dạng tự động loại elip
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Áp dụng một số định dạng cho hình elip
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Áp dụng một số định dạng cho đường viền của Elip
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Ghi tệp PPTX ra đĩa
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Làm thế nào để đặt vị trí và kích thước chính xác của một hình elip so với đơn vị của slide?**

Các tọa độ và kích thước thường được chỉ định **theo điểm**. Để có kết quả dự đoán được, hãy dựa tính toán của bạn trên kích thước slide và chuyển đổi millimet hoặc inch cần thiết sang điểm trước khi gán giá trị.

**Làm thế nào để đặt một hình elip lên trên hoặc dưới các đối tượng khác (kiểm soát thứ tự xếp chồng)?**

Điều chỉnh thứ tự vẽ của đối tượng bằng cách đưa nó lên trước hoặc gửi nó ra phía sau. Điều này cho phép hình elip che phủ các đối tượng khác hoặc hiển thị những đối tượng nằm phía dưới.

**Làm thế nào để hoạt hình sự xuất hiện hoặc nhấn mạnh của một hình elip?**

[Áp dụng](/slides/vi/python-net/shape-animation/) hiệu ứng entrance, emphasis hoặc exit cho hình dạng, và cấu hình trigger và thời gian để điều phối khi nào và cách thức hoạt hình được phát.