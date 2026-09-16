---
title: Xuất bản trình chiếu sang XAML bằng Python
linktitle: Bản trình chiếu sang XAML
type: docs
weight: 30
url: /vi/python-net/export-to-xaml/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bản trình chiếu
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi bản trình chiếu
- PowerPoint sang XAML
- OpenDocument sang XAML
- bản trình chiếu sang XAML
- PPT sang XAML
- PPTX sang XAML
- ODP sang XAML
- lưu PPT dưới dạng XAML
- lưu PPTX dưới dạng XAML
- lưu ODP dưới dạng XAML
- xuất PPT sang XAML
- xuất PPTX sang XAML
- xuất ODP sang XAML
- Python
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML bằng Python sử dụng Aspose.Slides—giải pháp nhanh, không cần Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất các bản trình chiếu PowerPoint sang XAML bằng Aspose.Slides. Nó bao gồm phần giới thiệu ngắn gọn về XAML, chỉ ra cách lưu một bản trình chiếu dưới dạng XAML với cài đặt mặc định, và minh họa cách tùy chỉnh việc xuất qua [XamlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/), bao gồm việc xuất các slide ẩn. Bài viết cũng trả lời một số câu hỏi phổ biến liên quan đến phông chữ dự phòng, khả năng tương thích với các ngăn XAML, và hành vi xuất slide ẩn.

## **Giới thiệu về XAML**

XAML là một ngôn ngữ đánh dấu dựa trên XML được sử dụng để mô tả giao diện người dùng trong các khung như WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) và Xamarin.Forms.

Bạn có thể làm việc với các tệp XAML trong một trình thiết kế trực quan hoặc viết và chỉnh sửa mã đánh dấu trực tiếp.

## **Xuất Bản Trình chiếu sang XAML với Các Tùy Chọn Mặc Định**

Ví dụ Python sau cho thấy cách xuất một bản trình chiếu sang XAML với cài đặt mặc định:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Theo mặc định, các slide đã xuất sẽ được lưu trong thư mục con `pres` của thư mục làm việc hiện tại của tiến trình, như được trả về bởi [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). Thư mục này được tạo tự động và bất kỳ hình ảnh nào cần thiết cũng sẽ được lưu ở đó.

Tên thư mục đầu ra được lấy từ tên tệp nguồn mà không có phần mở rộng. Đối với `pres.pptx`, các tệp đầu ra sẽ có tên `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, v.v. Ngay cả khi bạn truyền một đường dẫn tuyệt đối cho bản trình chiếu đầu vào, thư mục đầu ra vẫn được tạo dựa trên thư mục làm việc hiện tại, không phải bên cạnh tệp đầu vào.

## **Xuất Bản Trình chiếu sang XAML với Các Tùy Chọn Tùy Chỉnh**

Sử dụng lớp [XamlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/) để kiểm soát cách Aspose.Slides xuất một bản trình chiếu sang XAML.

Để bao gồm các slide ẩn trong đầu ra XAML, đặt thuộc tính [export_hidden_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) thành `True`, như trong ví dụ Python sau:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Thu thập Tất cả Các Tài Nguyên XAML Được Tạo Ra**

Việc xuất XAML có thể tạo một tài liệu XAML cho mỗi slide được xuất cộng với các hình ảnh và tài nguyên hỗ trợ riêng biệt. Hãy giữ lại tất cả các tệp này khi lưu trữ hoặc truyền tải một bản xuất.

Các ví dụ dưới đây sử dụng bộ lưu mặc định trên hệ thống tệp trong thư mục tạm, sau đó thu thập các tệp đã tạo.

### **Hiểu Quy Trình Xuất**

- Bắt đầu xuất bằng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/save/) đặc thù cho XAML, chấp nhận các tùy chọn XAML. Chỉ đọc các tệp đã tạo sau khi phương thức trả về thành công.
- Bảo tồn đường dẫn tương đối của mỗi tài nguyên vì XAML có thể tham chiếu tài nguyên bằng các đường dẫn tương đối.
- Đọc tài nguyên dưới dạng byte. Hình ảnh và các tài nguyên nhị phân khác không được giải mã thành văn bản.
- Báo cáo thành công tổng thể chỉ sau khi việc thu thập và bất kỳ thao tác lưu trữ nào sau đó hoàn tất. Để lỗi lưu trữ tới người gọi, và dọn dẹp đầu ra một phần nếu việc lưu không thành công.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) mặc định là `False`, loại trừ các tài liệu XAML của slide ẩn. Đặt thành `True` để bao gồm chúng và mọi tài nguyên cần thiết cho việc xuất. Số lượng tài nguyên phụ thuộc vào bản trình chiếu; không giả định có một tệp cho mỗi slide.

{{% alert color="warning" title="Cảnh báo" %}}
Các ví dụ tạm thời thay đổi thư mục làm việc hiện tại của tiến trình, ảnh hưởng đến tất cả các luồng. Hãy chạy mỗi lần xuất trong một tiến trình công nhân riêng, hoặc đảm bảo rằng không có công việc nào khác trong tiến trình phụ thuộc vào thư mục hiện tại trong thời gian xuất. Một thư mục tạm duy nhất không làm cho các lần xuất đồng thời trong cùng một tiến trình trở nên an toàn.
{{% /alert %}}

### **Xuất ra Bộ Nhớ và Kiểm Tra Các Tài Nguyên**

Ví dụ hoàn chỉnh này tải `pres.pptx`, xuất nó ra một thư mục tạm, thu thập mọi tài nguyên vào một từ điển các tên tương đối và byte, và in ra tên, kiểu và số byte của từng mục. Nó bảo tồn cấu trúc thư mục đã tạo và xóa các tệp tạm sau khi thu thập. Đường dẫn đầu vào được phân giải trước khi thay đổi thư mục làm việc.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Giải mã chỉ XAML, và chỉ khi cần kiểm tra văn bản.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Kiểm tra phần mở rộng hữu ích cho việc kiểm tra; giữ lại mọi tài nguyên, kể cả các loại tài nguyên không quen thuộc. Để nguyên byte khi lưu trữ hoặc truyền tải chúng. Chỉ giải mã XAML khi cần xử lý văn bản. Cách tiếp cận này sử dụng không gian đĩa tạm thời cũng như bộ nhớ cho các tệp xuất đã thu thập.

### **Đóng Gói Các Tài Nguyên Đã Thu Thập vào Kiến Trúc ZIP**

Ví dụ độc lập này thu thập bản xuất, xác thực các tên, và ghi các byte gốc vào một kho lưu ZIP. Tên kho lưu duy nhất tách biệt các công việc xuất. Các mục trong ZIP dùng dấu gạch chéo và giữ lại các thư mục tương đối. Các tên không an toàn hoặc trùng lặp sau chuẩn hoá sẽ bị từ chối toàn bộ gói trước khi ghi.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # Thư mục ZIP đã được hoàn thiện trước khi báo cáo thành công.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

Ví dụ sử dụng [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) để ghi một kho lưu cục bộ sau khi thu thập bản xuất tạm. Đối với lưu trữ từ xa, thay thế giai đoạn ghi kho lưu bằng việc tải lên các byte đã thu thập. Sử dụng một định danh công việc xuất cộng với tên tài nguyên tương đối đầy đủ làm khóa đối tượng, hoặc lưu trữ định danh công việc, tên tương đối và dữ liệu nhị phân trong một dòng cơ sở dữ liệu. Công bố công việc chỉ sau khi tất cả các tải lên hoàn tất hoặc giao dịch cơ sở dữ liệu được cam kết. Dọn dẹp đầu ra một phần nếu việc lưu không thành công.

Đối với các bản trình chiếu lớn, xử lý các tệp tạm một lần một lần sau khi xuất thay vì thu thập mọi byte trong một từ điển. Điều này tránh việc sao chép toàn bộ bản xuất trong bộ nhớ, nhưng không loại bỏ yêu cầu bộ nhớ của bộ xuất.

### **Bảo Vệ Tên Tài Nguyên và Xác Thực Các Tham Chiếu**

- Chuẩn hoá dấu phân cách đường dẫn khi đích yêu cầu, nhưng vẫn giữ lại các thư mục tương đối. Không chỉ giữ lại tên tệp cuối nếu mọi tên đã tạo đều được biết là duy nhất và các tham chiếu tài nguyên vẫn hợp lệ.
- Áp dụng kiểm tra hợp lệ tên đặc thù cho đích. Khi ghi các tệp rời, từ chối các đường dẫn tuyệt đối và các đoạn truy cập ngược, giải quyết đích, và xác nhận rằng nó vẫn nằm dưới thư mục xuất dự định. Sử dụng một thư mục do ứng dụng kiểm soát mà không có liên kết tượng trưng có thể chuyển hướng ghi.
- Sử dụng một không gian lưu trữ riêng cho mỗi công việc xuất. Phát hiện va chạm sau chuẩn hoá dấu phân cách và theo quy tắc phân biệt chữ hoa chữ thường của đích.
- Trước khi công bố, phân tích mỗi tài liệu XAML dưới dạng XML và kiểm tra các tham chiếu tài nguyên dựa trên tệp, chẳng hạn như thuộc tính `Source` hoặc `ImageSource` của hình ảnh. Giải quyết mỗi URI tương đối dựa trên thư mục của tài nguyên XAML chứa, chuẩn hoá tên lưu trữ kết quả, và xác nhận rằng khóa từ điển tương ứng, mục ZIP, hoặc đối tượng đã lưu tồn tại. Xử lý các URI bên ngoài và các biểu thức đánh dấu XAML riêng biệt so với các tên tệp tương đối.

Ví dụ, nếu `pres/Slide_1.xaml` tham chiếu `images/image1.png`, tài nguyên đã lưu phải có sẵn dưới `pres/images/image1.png`. Chỉ giữ `image1.png` sẽ làm phá vỡ mối quan hệ này. Đối với lưu trữ đối tượng, bảo tồn cùng cấu trúc dưới tiền tố công việc và làm cho các URL tài nguyên này có thể truy cập được cho người tiêu thụ XAML. Mở lại ZIP đã hoàn thành để xác minh tên mục và byte tài nguyên, và tải các slide mẫu trong môi trường XAML đích để xác nhận rằng hình ảnh được giải quyết đúng.

## **Câu hỏi thường gặp**

**Làm sao tôi có thể đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Đặt [default_regular_font](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) trong [XamlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/) — nó được dùng làm phông chữ dự phòng trong quá trình xuất khi phông chữ gốc thiếu. Điều này không bảo đảm rằng XAML tạo ra sẽ tham chiếu phông chữ dự phòng hoặc rằng phông chữ đó có sẵn trên máy đích. Hãy chắc chắn rằng các phông chữ được XAML tham chiếu đều có sẵn trong môi trường hiển thị.

**XAML xuất ra chỉ dành cho WPF hay có thể sử dụng được trong các ngăn XAML khác không?**

Aspose.Slides xuất XAML cho WPF thông qua API công khai của nó. Khả năng tương thích với các ngăn XAML khác, như UWP và Xamarin.Forms, không được đảm bảo. Hãy thử nghiệm mã đánh dấu đã tạo trong môi trường mục tiêu của bạn.

**Các slide ẩn có được hỗ trợ không, và làm sao tôi ngăn chúng bị xuất theo mặc định?**

Theo mặc định, các slide ẩn không được bao gồm. Bạn có thể kiểm soát hành vi này qua [export_hidden_slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) trong [XamlOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export.xaml/xamloptions/) — giữ nó tắt nếu không cần xuất chúng.