---
title: Tổng quan tính năng
type: docs
weight: 20
url: /vi/python-net/features-overview/
keywords:
- tính năng
- nền tảng được hỗ trợ
- định dạng tệp
- chuyển đổi
- kết xuất
- in
- định dạng
- PowerPoint
- OpenDocument
- trình chiếu
- Python
- Aspose.Slides
description: "Khám phá Aspose.Slides for Python via .NET: một API mạnh mẽ để tạo, chỉnh sửa, tự động hoá và chuyển đổi các trình chiếu PowerPoint và OpenDocument một cách hiệu quả."
---
## **Nền tảng được hỗ trợ**
Nền tảng Aspose.Slides for Python via .NET có thể được sử dụng trên Windows x64 hoặc x86 và nhiều bản phân phối Linux với Python 3.5 trở lên đã được cài đặt. Có một số yêu cầu bổ sung đối với nền tảng Linux đích:

- Thư viện thời gian chạy GCC-6 (hoặc mới hơn)
- Các phụ thuộc của .NET Core Runtime. Không cần cài đặt .NET Core Runtime tự nó
- Đối với Python 3.5‑3.7: Cần bản dựng Python với `pymalloc`. Tùy chọn biên dịch `--with-pymalloc` của Python được bật mặc định. Thông thường, bản dựng `pymalloc` của Python được đánh dấu bằng hậu tố `m` trong tên tệp.
- Thư viện Python chia sẻ `libpython`. Tùy chọn biên dịch Python `--enable-shared` bị tắt mặc định, một số bản phân phối Python không chứa thư viện chia sẻ `libpython`. Đối với một số nền tảng Linux, thư viện chia sẻ `libpython` có thể được cài đặt bằng trình quản lý gói, ví dụ: `sudo apt-get install libpython3.7`. Vấn đề phổ biến là thư viện `libpython` được cài đặt ở vị trí khác so với vị trí hệ thống tiêu chuẩn cho các thư viện chia sẻ. Vấn đề có thể được khắc phục bằng cách sử dụng các tùy chọn biên dịch Python để đặt đường dẫn thư viện thay thế khi biên dịch Python, hoặc bằng cách tạo một liên kết biểu tượng tới tệp thư viện `libpython` trong vị trí tiêu chuẩn của hệ thống. Thông thường, tên tệp thư viện chia sẻ `libpython` là `libpythonX.Ym.so.1.0` cho Python 3.5‑3.7, hoặc `libpythonX.Y.so.1.0` cho Python 3.8 trở lên (ví dụ: `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

Nếu bạn cần hỗ trợ cho nhiều nền tảng hơn, hãy tìm các sản phẩm "anh em sinh đôi" Aspose.Slides cho .NET hoặc Aspose.Slides cho Java.

## **Định dạng tệp và chuyển đổi**
Aspose.Slides for Python via .NET hỗ trợ hầu hết các định dạng tài liệu PowerPoint. Nó cũng cho phép bạn xuất chúng sang các định dạng phổ biến mà các tổ chức thường sử dụng và trao đổi. Xem chi tiết dưới đây:

|**Tính năng**|**Mô tả**|
| :- | :- |
|[Microsoft PowerPoint (PPT)](/slides/vi/python-net/ppt-vs-pptx/)|Aspose.Slides for Python via .NET cung cấp tốc độ xử lý nhanh nhất cho định dạng tài liệu trình chiếu này.|
|[Chuyển đổi PPT sang PPTX](/slides/vi/python-net/convert-ppt-to-pptx/)|Aspose.Slides for Python via .NET hỗ trợ chuyển đổi PPT sang PPTX.|
|[Định dạng tài liệu di động (PDF)](/slides/vi/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)|Bạn có thể xuất tất cả các định dạng tệp được hỗ trợ sang tài liệu Adobe Portable Document Format (PDF) chỉ với một phương thức.|
|[Định dạng XML Parser Specification (XPS)](https://docs.aspose.com/slides/vi/python-net/convert-powerpoint-to-xps/)|Bạn có thể xuất tất cả các định dạng tệp được hỗ trợ sang tài liệu XML Parser Specification (XPS) chỉ với một phương thức.|
|[Định dạng Tagged Image File Format (TIFF)](/slides/vi/python-net/convert-powerpoint-to-tiff/)|Bạn có thể xuất tất cả các định dạng tệp trình chiếu được hỗ trợ sang Tagged Image File Format (TIFF).|
|[Chuyển đổi PPTX sang HTML](https://docs.aspose.com/slides/vi/python-net/convert-powerpoint-to-html/)|Aspose.Slides for Python via .NET hỗ trợ chuyển đổi PresentationEx sang định dạng HTML.|

## **Kết xuất và In**
Aspose.Slides for Python via .NET hỗ trợ kết xuất chính xác cao các slide trong tài liệu trình chiếu sang nhiều định dạng đồ họa khác nhau. Xem chi tiết dưới đây:

|**Tính năng**|**Mô tả**|
| :- | :- |
|Định dạng hình ảnh được .NET hỗ trợ|Với Aspose.Slides for Python via .NET, bạn có thể kết xuất các slide và hình ảnh trên slide sang tất cả các định dạng đồ họa được .NET hỗ trợ như TIFF, PNG, BMP, JPEG, GIF và metafiles.|
|Định dạng SVG|Aspose.Slides for Python via .NET cũng cung cấp các phương thức tích hợp cho phép bạn xuất các slide trình chiếu sang định dạng Scalable Vector Graphics (SVG).|
|In trình chiếu|Các phiên bản mới nhất của Aspose.Slides for Python via .NET cung cấp các phương thức in tích hợp với các tùy chọn khác nhau.|

## **Tính năng nội dung**
Aspose.Slides for Python via .NET cho phép bạn truy cập, sửa đổi hoặc tạo hầu hết các mục hoặc nội dung của tài liệu trình chiếu. Xem chi tiết dưới đây:

|**Tính năng**|**Mô tả**|
| :- | :- |
|Slide Master|Slide Master định nghĩa bố cục của các slide thông thường. Aspose.Slides for Python via .NET cho phép bạn truy cập và sửa đổi Slide Master của tài liệu trình chiếu|
|Slide thường|Với Aspose.Slides for Python via .NET, bạn có thể tạo các slide mới với các loại khác nhau; bạn cũng có thể truy cập và sửa đổi các slide hiện có trong trình chiếu|
|Sao chép / Nhân bản slide|Có các phương thức tích hợp do Aspose.Slides for Python via .NET cung cấp cho phép bạn sao chép hoặc nhân bản các slide hiện có trong một trình chiếu. Bạn cũng có thể sử dụng các slide đã sao chép và nhân bản từ một trình chiếu sang trình chiếu khác. Vì một slide kế thừa bố cục từ slide master, các phương thức nhân bản tích hợp sẽ tự động sao chép master khi nhân bản|
|Quản lý các phần (section) của slide|Các phương thức để tổ chức các slide trong các phần khác nhau trong một trình chiếu|
|Trình giữ chỗ và trình giữ văn bản|Bạn có thể truy cập các trình giữ chỗ và trình giữ văn bản trong một slide. Hơn nữa, bạn có thể tạo một slide mới với trình giữ văn bản từ đầu bằng cách sử dụng phương thức thích hợp|
|Đầu trang và chân trang|Aspose.Slides for Python via .NET hỗ trợ xử lý đầu trang/chân trang trong các slide|
|Ghi chú trong slide|Với Aspose.Slides for Python via .NET, bạn có thể truy cập và sửa đổi ghi chú liên quan đến một slide và cũng có thể thêm ghi chú mới|
|Tìm kiếm hình dạng|Bạn cũng có thể tìm một hình dạng nhất định trong slide bằng cách sử dụng văn bản thay thế (alternative text) liên quan đến hình dạng đó|
|Nền|Aspose.Slides for Python via .NET cho phép bạn làm việc với nền liên quan đến slide master hoặc slide thường trong một trình chiếu|
|Hộp văn bản|Có thể tạo hộp văn bản từ đầu. Bạn có thể truy cập các hộp văn bản hiện có. Bạn cũng có thể sửa đổi văn bản của chúng mà không mất định dạng văn bản gốc|
|Hình chữ nhật|Bạn có thể tạo hoặc sửa đổi các hình chữ nhật bằng Aspose.Slides for Python via .NET|
|Hình poly line|Bạn có thể tạo hoặc sửa đổi các hình poly line bằng Aspose.Slides for Python via .NET|
|Hình ellipse|Bạn có thể tạo hoặc sửa đổi các hình ellipse bằng Aspose.Slides for Python via .NET|
|Nhóm hình|Aspose.Slides for Python via .NET hỗ trợ nhóm hình|
|Hình tự động|Aspose.Slides for Python via .NET hỗ trợ hình tự động|
|SmartArt|Aspose.Slides for Python via .NET cung cấp hỗ trợ cho các hình SmartArt trong MS PowerPoint|
|Charts|Aspose.Slides for Python via .NET cung cấp hỗ trợ cho các biểu đồ MSO trong PowerPoint|
|Serial hóa hình dạng|Aspose.Slides for Python via .NET hỗ trợ một số lượng lớn các hình dạng. Khi Aspose.Slides for Python via .NET không hỗ trợ một hình dạng nào đó, bạn có thể sử dụng phương thức serial hóa để bạn có thể serial hóa hình dạng đó từ một slide hiện có. Nhờ vậy, bạn có thể sử dụng hình dạng này tiếp theo theo nhu cầu của mình|
|Khung hình ảnh|Bạn có thể quản lý hình ảnh trong khung hình ảnh bằng Aspose.Slides for Python via .NET|
|Khung âm thanh|Bạn có thể liên kết hoặc nhúng tệp âm thanh trong khung âm thanh trên slide bằng Aspose.Slides for Python via .NET|
|Khung video|Bạn có thể xử lý tệp video trong khung video. Aspose.Slides for Python via .NET cũng hỗ trợ video liên kết và nhúng|
|Khung OLE|Bạn có thể quản lý các đối tượng OLE trong khung OLE bằng Aspose.Slides for Python via .NET|
|Bảng|Aspose.Slides for Python via .NET hỗ trợ bảng trong slide|
|ActiveX Controls|ActiveX Controls|
|VBA Macros|VBA Macros|
|Khung văn bản|Bạn có thể truy cập văn bản của bất kỳ hình dạng nào thông qua khung văn bản liên kết với hình dạng đó|
|Quét văn bản|Bạn có thể quét văn bản trong một trình chiếu ở cấp độ trình chiếu hoặc slide thông qua các phương thức quét tích hợp|
|Hoạt ảnh|Bạn có thể áp dụng hoạt ảnh cho các hình dạng|
|Trình chiếu|Aspose.Slides for Python via .NET hỗ trợ trình chiếu và chuyển đổi slide|

## **Tính năng định dạng**
Aspose.Slides for Python via .NET cho phép bạn định dạng văn bản và hình dạng trên slide trong trình chiếu. Xem chi tiết dưới đây:

|**Tính năng**|**Mô tả**|
| :- | :- |
|Định dạng văn bản|<p>Trong Aspose.Slides for Python via .NET, bạn có thể quản lý văn bản thông qua các khung văn bản liên kết với các hình dạng. Do đó, bạn có thể định dạng văn bản bằng cách sử dụng các đoạn và phần liên quan đến các khung văn bản. Các yếu tố văn bản này có thể được định dạng thông qua Aspose.Slides for Python via .NET.</p><p>- Kiểu phông chữ</p><p>- Cỡ phông chữ</p><p>- Màu phông chữ</p><p>- Tông màu phông chữ</p><p>- Căn đoạn</p><p>- Đánh dấu đoạn</p><p>- Hướng đoạn</p>|
|Định dạng hình dạng|<p>Trong Aspose.Slides for Python via .NET, yếu tố cơ bản của một slide là một hình dạng. Bạn có thể định dạng các yếu tố hình dạng này bằng Aspose.Slides for Python via .NET:</p><p>- Vị trí</p><p>- Kích thước</p><p>- Đường viền</p><p>- Đổ màu (bao gồm Mẫu, Gradient, Đặc)</p><p>- Văn bản</p><p>- Hình ảnh</p>|

## **Câu hỏi thường gặp**

**Có cần cài đặt Microsoft PowerPoint trên máy chủ/PC để thư viện hoạt động không?**

Không. PowerPoint không bắt buộc; Aspose.Slides là một động cơ độc lập để tạo, chỉnh sửa, chuyển đổi và kết xuất các trình chiếu.

**Multithreading hoạt động như thế nào? Có thể xử lý song song không?**

Bạn có thể an toàn xử lý các tài liệu khác nhau trong các luồng khác nhau; cùng một [presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) object không được sử dụng bởi [nhiều luồng](/slides/vi/python-net/multithreading/) cùng một lúc.

**Có hỗ trợ mật khẩu và mã hóa cho tệp không?**

Có. [Bạn có thể](/slides/vi/python-net/password-protected-presentation/) mở các trình chiếu được mã hóa, đặt hoặc xóa mật khẩu mở và ghi, và kiểm tra trạng thái bảo vệ.

**Có cần chú ý đến các gói phông chữ trong container Linux không?**

Có. Bạn nên cài đặt các gói phông chữ phổ biến và/hoặc rõ ràng [chỉ định thư mục phông chữ](/slides/vi/python-net/custom-font/) trong ứng dụng của mình để tránh việc thay thế không mong muốn.

**Có giới hạn nào trong phiên bản dùng thử không?**

Trong [chế độ dùng thử](/slides/vi/python-net/licensing/), một dấu watermark được thêm vào đầu ra và một số giới hạn được áp dụng; một [giấy phép tạm thời 30 ngày](https://purchase.aspose.com/temporary-license/) có sẵn để kiểm tra đầy đủ tính năng.

**Có hỗ trợ nhập các định dạng bên ngoài vào trình chiếu (PDF/HTML → PPTX) không?**

Có. Bạn có thể thêm [các trang PDF và nội dung HTML](/slides/vi/python-net/import-presentation/) vào một trình chiếu, chuyển chúng thành các slide.