---
title: Xuất Bản Trình Chiếu sang XAML trong Python qua Java
linktitle: Bản trình chiếu sang XAML
type: docs
weight: 30
url: /vi/python-java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Xuất các bản trình chiếu PowerPoint và OpenDocument sang XAML với Aspose.Slides cho Python qua Java. Sử dụng các tùy chọn mặc định hoặc bao gồm các slide ẩn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất bản trình chiếu PowerPoint sang XAML bằng Aspose.Slides cho Python thông qua Java. Nó bao gồm một phần giới thiệu ngắn về XAML, cho thấy cách lưu một bản trình chiếu dưới dạng XAML với các cài đặt mặc định, và trình bày cách tùy chỉnh việc xuất thông qua [XamlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/), bao gồm việc xuất các slide ẩn. Bài viết cũng trả lời một vài câu hỏi thường gặp liên quan đến phông chữ dự phòng, khả năng tương thích của ngăn xếp XAML, và hành vi xuất slide ẩn.

Các ví dụ yêu cầu Aspose.Slides cho Python thông qua Java và một môi trường chạy Java tương thích. Đặt `pres.pptx` trong thư mục làm việc hiện tại. Mỗi ví dụ chỉ khởi động JVM nếu nó chưa chạy.

## **Về XAML**

XAML là một ngôn ngữ đánh dấu dựa trên XML được sử dụng để mô tả giao diện người dùng trong các khung như WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) và Xamarin.Forms.

Bạn có thể làm việc với các tệp XAML trong một trình thiết kế trực quan hoặc viết và chỉnh sửa markup trực tiếp.

## **Xuất Bản Trình Chiếu sang XAML với Tùy chọn Mặc định**

Ví dụ Python sau đây cho thấy cách xuất một bản trình chiếu sang XAML với các cài đặt mặc định:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Mặc định, các slide đã xuất được lưu trong một thư mục con `pres` của thư mục làm việc hiện tại của tiến trình. Thư mục này được tạo tự động, và bất kỳ hình ảnh nào cần thiết cũng được lưu ở đó.

Tên thư mục đầu ra được lấy từ tên tệp nguồn mà không có phần mở rộng. Đối với `pres.pptx`, các tệp đầu ra sẽ có tên `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, v.v. Ngay cả khi bạn truyền một đường dẫn tuyệt đối đến bản trình chiếu đầu vào, thư mục đầu ra vẫn được tạo tương đối so với thư mục làm việc hiện tại, chứ không phải bên cạnh tệp đầu vào.

## **Xuất Bản Trình Chiếu sang XAML với Tùy chọn Tùy chỉnh**

Sử dụng lớp [XamlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/) để kiểm soát cách Aspose.Slides xuất một bản trình chiếu sang XAML.

Để lưu đầu ra vào một vị trí tùy chỉnh, triển khai `IXamlOutputSaver` và truyền một thể hiện của việc triển khai của bạn vào phương thức [setOutputSaver](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/#setOutputSaver) của [XamlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/).

Để bao gồm các slide ẩn trong đầu ra XAML, gọi [setExportHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) với `True`, như trong ví dụ Python sau:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Ghi lại Tất cả các Đầu ra XAML Được Tạo**

Một quá trình xuất XAML có thể tạo ra một tài liệu XAML cho mỗi slide đã xuất cộng với các hình ảnh và tài nguyên hỗ trợ riêng biệt. Gán một `IXamlOutputSaver` tùy chỉnh cho [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/#setOutputSaver) để nhận các artefact này thay vì sử dụng bộ lưu mặc định của hệ thống tệp. Bắt đầu xuất bằng phương thức overload của [Presentation.save](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#save) nhận các tùy chọn XAML.

Trong Python, sử dụng `jpype.JProxy` để triển khai giao diện Java `IXamlOutputSaver`. Chuyển đổi đường dẫn callback thành `str` và sao chép mảng byte Java sang `bytes` của Python trước khi trả về, như minh họa bên dưới.

### **Hiểu Chu trình Callback**

Bộ xuất sẽ gọi `IXamlOutputSaver.save` riêng biệt cho mỗi artefact được tạo:

- `path` xác định artefact và có thể bao gồm các thư mục tương đối. Giữ lại thông tin này vì XAML có thể tham chiếu tài nguyên bằng các đường dẫn tương đối.
- `data` chứa các byte của artefact. Hình ảnh và các tài nguyên nhị phân khác không được giải mã thành văn bản.
- Bộ lưu chịu trách nhiệm giữ hoặc lưu trữ dữ liệu trước khi trả về. Các ví dụ sao chép mỗi mảng byte vào bộ nhớ thuộc về ứng dụng.
- Xét việc xuất là thành công chỉ khi thao tác lưu bản trình chiếu trả về và mọi callback đã hoàn thành thành công. Đừng bỏ qua lỗi lưu trữ hoặc khởi chạy các ghi nền không được giám sát. Nếu việc lưu diễn ra sau đó, chỉ báo thành công chung sau khi bước đó cũng thành công.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) cũng áp dụng cho bộ lưu tùy chỉnh. Cài đặt mặc định, `False`, loại bỏ các tài liệu XAML của slide ẩn. Truyền `True` sẽ bao gồm chúng và bất kỳ tài nguyên nào cần thiết cho việc xuất. Số lượng tài nguyên phụ thuộc vào bản trình chiếu; đừng giả định một callback cho mỗi slide hoặc một thứ tự callback cố định.

### **Xuất ra Bộ nhớ và Kiểm tra Các Artefact**

Ví dụ hoàn chỉnh này tải `pres.pptx`, thu thập mọi artefact vào một từ điển Python gồm tên và giá trị `bytes` bất biến, và in ra tên, kiểu và số byte của chúng. Nó giữ nguyên các tên được cung cấp. Các tên trùng lặp sẽ làm cho bộ sưu tập trở nên không hợp lệ thay vì ghi đè âm thầm một artefact. Ví dụ kiểm tra điều này trước khi sử dụng kết quả.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Giải mã chỉ XAML, và chỉ khi cần kiểm tra văn bản.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Kiểm tra phần mở rộng hữu ích cho việc kiểm tra; giữ lại tất cả các artefact, bao gồm cả các loại tài nguyên không quen thuộc. Để nguyên các byte khi lưu hoặc truyền chúng. Chỉ sử dụng `bytes.decode` với UTF-8 cho XAML cần xử lý văn bản.

### **Đóng Gói Các Artefact Đã Thu Thập vào Tập Tin ZIP**

Ví dụ độc lập này thu thập kết quả xuất, xác thực các tên, và ghi các byte gốc vào một tập tin ZIP. Một tên archive duy nhất tách biệt các công việc xuất đồng thời. Các mục ZIP sử dụng dấu gạch chéo và giữ lại các thư mục tương đối. Các tên không an toàn hoặc tên trùng sau chuẩn hoá sẽ bị từ chối toàn bộ gói trước khi ghi.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Đóng file ZIP hoàn thiện thư mục ZIP trước khi thông báo thành công.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

Ví dụ sử dụng `zipfile.ZipFile` của Python để ghi một archive cục bộ; bộ xuất không ghi các tệp XAML hoặc hình ảnh rời. Đối với lưu trữ từ xa, thay thế giai đoạn ghi archive bằng việc tải lên các mảng byte đã thu thập. Sử dụng một định danh công việc xuất cộng với tên artefact tương đối đầy đủ làm khóa blob, hoặc lưu định danh công việc, tên tương đối và dữ liệu nhị phân vào một dòng trong cơ sở dữ liệu. Phát hành công việc chỉ sau khi tất cả các tải lên hoàn tất hoặc giao dịch cơ sở dữ liệu được cam kết. Dọn dẹp đầu ra một phần nếu việc lưu trữ thất bại.

Đối với các bản trình chiếu lớn, một bộ lưu tùy chỉnh có thể lưu mỗi artefact trực tiếp vào bộ nhớ lưu trữ của ứng dụng để tránh việc giữ một bản sao thêm của toàn bộ xuất trong bộ nhớ ứng dụng. Giữ mỗi callback đồng bộ từ quan điểm của bộ xuất: trả về chỉ sau khi đích đã chấp nhận các byte, và cho phép các lỗi truyền tới người gọi.

### **Bảo Quản Tên Tài Nguyên và Xác Minh Tham Chiếu**

- Chuẩn hoá dấu phân tách đường dẫn khi đích yêu cầu, nhưng vẫn giữ lại các thư mục tương đối. Không chỉ dùng `pathlib.Path.name` trừ khi mọi tên được tạo ra đều duy nhất và các tham chiếu tài nguyên vẫn hợp lệ.
- Áp dụng kiểm tra tên đặc thù cho đích. Khi ghi các tệp rời, từ chối các đường dẫn gốc và các đoạn duyệt lên, giải quyết đích bằng `pathlib.Path.resolve`, và xác minh nó vẫn nằm dưới thư mục xuất dự định, bao gồm dấu phân tách thư mục trong kiểm tra chứa. Sử dụng một thư mục do ứng dụng kiểm soát mà không có liên kết tượng trưng có thể chuyển hướng ghi.
- Dùng một bộ lưu và không gian tên lưu trữ riêng cho mỗi công việc xuất. Phát hiện va chạm sau khi chuẩn hoá dấu phân tách và theo quy tắc phân biệt chữ hoa/thường của đích.
- Trước khi công bố, phân tích mỗi tài liệu XAML dưới dạng XML và kiểm tra các tham chiếu tài nguyên dựa trên tệp, chẳng hạn thuộc tính `Source` hoặc `ImageSource` của hình ảnh. Giải quyết mỗi URI tương đối dựa trên thư mục của artefact XAML chứa, chuẩn hoá tên lưu trữ kết quả, và xác nhận khóa bản đồ tương ứng, mục ZIP, hoặc đối tượng lưu trữ tồn tại. Xử lý các URI bên ngoài và các biểu thức markup XAML riêng biệt so với các tên tệp tương đối.

Ví dụ, nếu `pres/Slide_1.xaml` tham chiếu tới `images/image1.png`, tài nguyên đã lưu phải có sẵn dưới dạng `pres/images/image1.png`. Chỉ giữ `image1.png` sẽ phá vỡ mối quan hệ này. Đối với lưu trữ đối tượng, bảo quản cùng cấu trúc dưới tiền tố công việc và làm cho các URL tài nguyên này khả dụng cho người tiêu thụ XAML. Mở lại ZIP đã hoàn thành để xác minh tên mục và byte tài nguyên, và tải các slide đại diện trong môi trường XAML mục tiêu để xác nhận hình ảnh được giải quyết đúng.

## **Câu hỏi thường gặp**

**Làm sao tôi có thể đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Gọi [setDefaultRegularFont](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) trong [XamlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/) — nó được sử dụng làm phông chữ dự phòng trong quá trình xuất khi phông chữ gốc thiếu. Điều này không bảo đảm rằng XAML tạo ra sẽ tham chiếu tới phông chữ dự phòng hoặc phông chữ đó có sẵn trên máy đích. Đảm bảo rằng các phông chữ được XAML tham chiếu đều có trong môi trường nơi nó được hiển thị.

**XAML xuất ra chỉ dành cho WPF hay có thể dùng trong các ngăn xếp XAML khác không?**

Aspose.Slides xuất XAML cho WPF thông qua API công khai của nó. Tương thích với các ngăn xếp XAML khác, như UWP và Xamarin.Forms, không được đảm bảo. Hãy thử markup được tạo trong môi trường mục tiêu của bạn.

**Slide ẩn có được hỗ trợ không, và làm sao ngăn chúng được xuất mặc định?**

Mặc định, các slide ẩn không được bao gồm. Bạn có thể kiểm soát hành vi này qua [setExportHiddenSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) trong [XamlOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/xamloptions/) — để nó vô hiệu nếu bạn không cần xuất chúng.