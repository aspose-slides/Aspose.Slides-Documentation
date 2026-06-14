---
title: Thêm các hình ellipse vào bản trình chiếu trong C++
linktitle: Ellipse
type: docs
weight: 30
url: /vi/cpp/ellipse/
keywords:
- ellipse
- hình dạng
- thêm ellipse
- tạo ellipse
- vẽ ellipse
- ellipse định dạng
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách tạo, định dạng và thao tác các hình ellipse trong Aspose.Slides cho C++ trên các bản trình chiếu PPT và PPTX — bao gồm ví dụ mã C++."
---
## **Tổng quan**

Bài viết này trình bày cách thêm các hình ellipse vào các slide PowerPoint bằng cách sử dụng Aspose.Slides. Nó bao gồm việc tạo một ellipse đơn giản, tạo một ellipse định dạng và lưu bản trình chiếu đã cập nhật dưới dạng tệp PPTX. Nó cũng đề cập đến các câu hỏi liên quan như làm việc với vị trí và kích thước của ellipse, kiểm soát thứ tự xếp chồng và áp dụng các hiệu ứng hoạt hình.

## **Tạo một Ellipse**
Trong chủ đề này, chúng tôi sẽ giới thiệu cho các nhà phát triển cách thêm các hình ellipse vào slide của họ bằng cách sử dụng Aspose.Slides cho C++. Aspose.Slides cho C++ cung cấp một bộ API dễ sử dụng hơn để vẽ các loại hình dạng khác nhau chỉ với một vài dòng mã. Để thêm một ellipse đơn giản vào slide đã chọn của bản trình chiếu, vui lòng làm theo các bước dưới đây:

1. Tạo một instance của [Presentation class](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/)
2. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó
3. Thêm một AutoShape loại Ellipse bằng cách sử dụng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes
4. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX

Trong ví dụ dưới đây, chúng tôi đã thêm một ellipse vào slide đầu tiên.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Tạo một Ellipse Định dạng**
Để thêm một ellipse được định dạng tốt hơn vào slide, vui lòng làm theo các bước dưới đây:

1. Tạo một instance của [Presentation class](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
3. Thêm một AutoShape loại Ellipse bằng cách sử dụng phương thức AddAutoShape được cung cấp bởi đối tượng IShapes.
4. Đặt Fill Type của Ellipse thành Solid.
5. Đặt Color của Ellipse bằng thuộc tính SolidFillColor.Color được cung cấp bởi đối tượng FillFormat liên kết với đối tượng IShape.
6. Đặt Color của các đường viền của Ellipse.
7. Đặt Width của các đường viền của Ellipse.
8. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một ellipse được định dạng vào slide đầu tiên của bản trình chiếu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **Câu hỏi thường gặp**

**Làm thế nào để tôi đặt vị trí và kích thước chính xác của một ellipse so với đơn vị của slide?**

Các tọa độ và kích thước thường được chỉ định **theo điểm**. Để có kết quả dự đoán được, hãy tính toán dựa trên kích thước slide và chuyển đổi milimét hoặc inch cần thiết sang điểm trước khi gán giá trị.

**Làm sao tôi có thể đặt một ellipse lên trên hoặc dưới các đối tượng khác (kiểm soát thứ tự xếp chồng)?**

Điều chỉnh thứ tự vẽ của đối tượng bằng cách đưa nó lên phía trước hoặc gửi nó về phía sau. Điều này cho phép ellipse phủ lên các đối tượng khác hoặc hiển thị những đối tượng ở dưới.

**Làm thế nào để tôi tạo hoạt ảnh cho sự xuất hiện hoặc nhấn mạnh của một ellipse?**

[Áp dụng](/slides/vi/cpp/shape-animation/) các hiệu ứng vào, nhấn mạnh hoặc thoát cho hình dạng, và cấu hình trigger và thời gian để điều khiển khi nào và cách hoạt ảnh được phát.