---
title: Tổng quan các tính năng
type: docs
weight: 20
url: /vi/python-net/features-overview/
keywords:
- tính năng
- nền tảng được hỗ trợ
- định dạng tệp
- chuyển đổi
- kết xuất
- định dạng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Khám phá Aspose.Slides for Python via .NET: một API mạnh mẽ để tạo, chỉnh sửa, tự động hoá và chuyển đổi các bản trình chiếu PowerPoint và OpenDocument một cách hiệu quả."
---
## **Nền tảng được hỗ trợ**
Các nền tảng mà Aspose.Slides for Python via .NET có thể được sử dụng bao gồm Windows x64 hoặc x86 và nhiều bản phân phối Linux với Python 3.5 trở lên đã được cài đặt. Có một số yêu cầu bổ sung cho nền tảng Linux mục tiêu:
- Thư viện runtime GCC-6 (hoặc mới hơn)
- Các phụ thuộc của .NET Core Runtime. Việc cài đặt .NET Core Runtime tự nó KHÔNG bắt buộc
- Đối với Python 3.5‑3.7: Cần bản dựng `pymalloc` của Python. Tùy chọn biên dịch `--with-pymalloc` được bật theo mặc định. Thông thường, bản dựng `pymalloc` của Python có hậu tố `m` trong tên tệp.
- Thư viện chia sẻ Python `libpython`. Tùy chọn biên dịch `--enable-shared` của Python bị tắt theo mặc định, một số bản phân phối Python không chứa thư viện chia sẻ `libpython`. Đối với một số nền tảng Linux, thư viện chia sẻ `libpython` có thể được cài đặt bằng trình quản lý gói, ví dụ: `sudo apt-get install libpython3.7`. Vấn đề phổ biến là thư viện `libpython` được cài đặt ở vị trí khác với vị trí tiêu chuẩn của hệ thống cho các thư viện chia sẻ. Vấn đề này có thể được khắc phục bằng cách sử dụng tùy chọn biên dịch của Python để đặt đường dẫn thư viện thay thế khi biên dịch Python, hoặc bằng cách tạo một liên kết tượng trưng tới tệp thư viện `libpython` trong vị trí tiêu chuẩn của hệ thống. Thông thường, tên tệp thư viện chia sẻ `libpython` là `libpythonX.Ym.so.1.0` cho Python 3.5‑3.7, hoặc `libpythonX.Y.so.1.0` cho Python 3.8 trở lên (ví dụ: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Nếu bạn cần hỗ trợ cho nhiều nền tảng hơn, hãy tìm các sản phẩm “anh em sinh đôi” Aspose.Slides for .NET hoặc Aspose.Slides for Java.

## **Định dạng tệp và chuyển đổi**
Aspose.Slides for Python via .NET hỗ trợ hầu hết các định dạng tài liệu PowerPoint. Nó cũng cho phép bạn xuất chúng sang các định dạng phổ biến mà các tổ chức thường sử dụng và trao đổi. Xem chi tiết dưới đây:

|**Tính năng**|**Mô tả**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/vi/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET cung cấp tốc độ xử lý nhanh nhất cho định dạng tài liệu trình chiếu này.|
|[Chuyển đổi PPT sang PPTX](/slides/vi/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET hỗ trợ chuyển đổi PPT sang PPTX.|
|[Portable Document Format (PDF)](/slides/vi/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Bạn có thể xuất tất cả các định dạng tệp được hỗ trợ sang tài liệu Adobe Portable Document Format (PDF) bằng một phương thức duy nhất.|
|[XML Parser Specification (XPS)](https://docs.aspose.com/slides/vi/python-net/convert-powerpoint-to-xps/)|Bạn có thể xuất tất cả các định dạng tệp được hỗ trợ sang tài liệu XML Parser Specification (XPS) bằng một phương thức duy nhất.|
|[Tagged Image File Format (TIFF)](/slides/vi/python-net/convert-powerpoint-to-tiff/)|Bạn có thể xuất tất cả các định dạng tệp trình chiếu được hỗ trợ sang Tagged Image File Format (TIFF).|
|[Chuyển đổi PPTX sang HTML] (https://docs.aspose.com/slides/vi/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET hỗ trợ chuyển đổi PresentationEx sang định dạng HTML.|

## **Kết xuất bản trình chiếu**
Aspose.Slides for Python via .NET hỗ trợ kết xuất chất lượng cao các slide trong tài liệu trình chiếu sang các định dạng đồ họa khác nhau. Xem chi tiết dưới đây:

|**Tính năng**|**Mô tả**|
| :- | :- |
|Định dạng ảnh được .NET hỗ trợ|Với Aspose.Slides for Python via .NET, bạn có thể kết xuất các slide và hình ảnh trên slide sang tất cả các định dạng đồ họa được .NET hỗ trợ như TIFF, PNG, BMP, JPEG, GIF và metafile.|
|Định dạng SVG|Aspose.Slides for Python via .NET cũng cung cấp các phương thức tích hợp cho phép bạn xuất các slide trình chiếu sang định dạng Scalable Vector Graphics (SVG).|

## **Các tính năng nội dung**
Aspose.Slides for Python via .NET cho phép bạn truy cập, sửa đổi hoặc tạo gần như tất cả các mục hoặc nội dung của tài liệu trình chiếu. Xem chi tiết dưới đây:

|**Tính năng**|**Mô tả**|
| :- | :- |
|Slide Master|Slide Master định nghĩa bố cục của các slide thường. Aspose.Slides for Python via .NET cho phép bạn truy cập và sửa đổi Slide Master của tài liệu trình chiếu.|
|Slide thường|Với Aspose.Slides for Python via .NET, bạn có thể tạo các slide mới thuộc các loại khác nhau; bạn cũng có thể truy cập và sửa đổi các slide hiện có trong bản trình chiếu.|
|Sao chép / Nhân bản slide|Có các phương thức tích hợp do Aspose.Slides for Python via .NET cung cấp cho phép bạn sao chép hoặc nhân bản các slide hiện có trong một bản trình chiếu. Bạn cũng có thể sử dụng các slide đã sao chép và nhân bản từ một bản trình chiếu sang bản khác. Vì một slide kế thừa bố cục từ slide master, các phương thức nhân bản tích hợp sẽ tự động sao chép master khi nhân bản.|
|Quản lý các phần của slide|Các phương thức để tổ chức slide trong các phần khác nhau bên trong một bản trình chiếu.|
|Place Holders và Text Holders|Bạn có thể truy cập các place holder và text holder trong một slide. Hơn nữa, bạn có thể tạo một slide với text holder từ đầu bằng phương thức thích hợp.|
|Header và Footer|Aspose.Slides for Python via .NET hỗ trợ xử lý header/footer trong slide.|
|Ghi chú trong slide|Với Aspose.Slides for Python via .NET, bạn có thể truy cập và sửa đổi ghi chú liên kết với một slide và cũng có thể thêm ghi chú mới.|
|Tìm kiếm Shape|Bạn cũng có thể tìm một shape cụ thể trong slide bằng cách sử dụng văn bản thay thế liên quan đến shape đó.|
|Nền (Backgrounds)|Aspose.Slides for Python via .NET cho phép bạn làm việc với nền liên quan đến slide master hoặc slide thường trong bản trình chiếu.|
|Text Box|Bạn có thể tạo text box từ đầu. Bạn có thể truy cập các text box hiện có. Bạn cũng có thể sửa đổi nội dung mà không làm mất định dạng văn bản gốc.|
|Shape hình chữ nhật|Bạn có thể tạo hoặc sửa đổi shape hình chữ nhật với Aspose.Slides for Python via .NET.|
|Shape poly line|Bạn có thể tạo hoặc sửa đổi shape poly line với Aspose.Slides for Python via .NET.|
|Shape ellipse|Bạn có thể tạo hoặc sửa đổi shape ellipse với Aspose.Slides for Python via .NET.|
|Group Shapes|Aspose.Slides for Python via .NET hỗ trợ group shapes.|
|Auto Shapes|Aspose.Slides for Python via .NET hỗ trợ auto shapes.|
|SmartArt|Aspose.Slides for Python via .NET cung cấp hỗ trợ cho các shape SmartArt trong MS PowerPoint.|
|Charts|Aspose.Slides for Python via .NET cung cấp hỗ trợ cho các Chart MSO trong PowerPoint.|
|Serialization Shape|Aspose.Slides for Python via .NET hỗ trợ một số lượng lớn các shape. Khi Aspose.Slides for Python via .NET chưa hỗ trợ một shape nào đó, bạn có thể sử dụng phương thức serialization để tuần tự hoá shape đó từ một slide hiện có. Nhờ đó, bạn có thể sử dụng shape này tiếp theo theo nhu cầu của mình.|
|Picture Frames|Bạn có thể quản lý ảnh trong picture frames với Aspose.Slides for Python via .NET.|
|Audio Frames|Bạn có thể liên kết hoặc nhúng tệp âm thanh trong audio frames trên slide với Aspose.Slides for Python via .NET.|
|Video Frames|Bạn có thể xử lý tệp video trong video frames. Aspose.Slides for Python via .NET cũng cung cấp hỗ trợ cho video liên kết và nhúng.|
|OLE Frame|Bạn có thể quản lý OLE Object trong OLE frames với Aspose.Slides for Python via .NET.|
|Tables|Aspose.Slides for Python via .NET hỗ trợ tables trong slide.|
|ActiveX Controls|Hỗ trợ cho các điều khiển ActiveX.|
|VBA Macros|Hỗ trợ quản lý VBA macro trong bản trình chiếu.|
|Text Frame|Bạn có thể truy cập văn bản trong bất kỳ shape nào thông qua text frame liên kết với shape đó.|
|Text Scanning|Bạn có thể quét văn bản trong bản trình chiếu ở mức presentation hoặc slide thông qua các phương thức quét tích hợp.|
|Animations|Bạn có thể áp dụng animation cho các shape.|
|Slide Shows|Aspose.Slides for Python via .NET hỗ trợ slide shows và chuyển đổi slide.|

## **Các tính năng định dạng**
Với Aspose.Slides for Python via .NET, bạn có thể định dạng văn bản và shape trên slide trong bản trình chiếu. Xem chi tiết dưới đây:

|**Tính năng**|**Mô tả**|
| :- | :- |
|Định dạng văn bản|<p>Trong Aspose.Slides for Python via .NET, bạn có thể quản lý văn bản thông qua các text frame liên kết với các shape. Do đó, bạn có thể định dạng văn bản bằng các đoạn (paragraph) và phần (portion) liên kết với các text frame. Các thành phần văn bản này có thể được định dạng thông qua Aspose.Slides for Python via .NET.</p><p>- Kiểu Font</p><p>- Cỡ Font</p><p>- Màu Font</p><p>- Tông màu Font</p><p>- Canh lề đoạn</p><p>- Đánh dấu đoạn</p><p>- Hướng đoạn</p>|
|Định dạng shape|<p>Trong Aspose.Slides for Python via .NET, thành phần cơ bản của một slide là một shape. Bạn có thể định dạng các shape này với Aspose.Slides for Python via .NET:</p><p>- Vị trí</p><p>- Kích thước</p><p>- Đường viền</p><p>- Đổ màu (bao gồm Pattern, Gradient, Solid)</p><p>- Văn bản</p><p>- Hình ảnh</p>|

## **Câu hỏi thường gặp**

### Tôi có cần cài đặt Microsoft PowerPoint trên máy chủ/PC để thư viện hoạt động không?

Không. PowerPoint không bắt buộc; Aspose.Slides là một engine độc lập để tạo, chỉnh sửa, chuyển đổi và kết xuất bản trình chiếu.

### Đa luồng hoạt động như thế nào? Có thể thực hiện xử lý song song không?

Có thể an toàn xử lý các tài liệu khác nhau trong các luồng riêng biệt; cùng một đối tượng [presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) không được sử dụng đồng thời bởi [nhiều luồng](/slides/vi/python-net/multithreading/).

### Có hỗ trợ mật khẩu file và mã hoá không?

Có. [Bạn có thể](/slides/vi/python-net/password-protected-presentation/) mở các bản trình chiếu được mã hoá, đặt hoặc xóa mật khẩu mở và ghi, và kiểm tra trạng thái bảo vệ.

### Tôi có cần quan tâm đến các gói font trong containers Linux không?

Có. Được khuyến nghị cài đặt các gói font phổ biến và/hoặc [xác định rõ thư mục font](/slides/vi/python-net/custom-font/) trong ứng dụng của bạn để tránh việc thay thế không mong muốn.

### Có giới hạn nào trong phiên bản dùng thử không?

Trong [chế độ dùng thử](/slides/vi/python-net/licensing/), một watermark sẽ được thêm vào đầu ra và một số giới hạn sẽ áp dụng; một [giấy phép tạm thời 30 ngày](https://purchase.aspose.com/temporary-license/) có sẵn để kiểm tra đầy đủ tính năng.

### Có hỗ trợ nhập khẩu các định dạng ngoại vi vào bản trình chiếu (PDF/HTML → PPTX) không?

Có. Bạn có thể thêm [các trang PDF và nội dung HTML](/slides/vi/python-net/import-presentation/) vào bản trình chiếu, chuyển chúng thành các slide.