---
title: Yêu cầu hệ thống
type: docs
weight: 60
url: /vi/python-net/system-requirements/
keywords:
- yêu cầu hệ thống
- hệ điều hành
- cài đặt
- các phụ thuộc
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Khám phá yêu cầu hệ thống của Aspose.Slides for Python via .NET. Đảm bảo hỗ trợ PowerPoint và OpenDocument liền mạch trên Windows, Linux và macOS."
---
## **Giới thiệu**

Aspose.Slides for Python via .NET không yêu cầu cài đặt bất kỳ sản phẩm bên thứ ba nào, chẳng hạn như Microsoft PowerPoint. Aspose.Slides là một động cơ để tạo, chỉnh sửa, chuyển đổi và hiển thị tài liệu ở nhiều định dạng, bao gồm các định dạng bản trình chiếu Microsoft PowerPoint.

## **Hệ điều hành được hỗ trợ**

Aspose.Slides for Python hỗ trợ Windows (32-bit và 64-bit), macOS và Linux 64-bit trên các hệ thống đã cài Python 3.5 trở lên.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Hệ điều hành</td>
        <td style="font-weight: bold; width:400px">Phiên bản</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>và các hệ thống khác</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **Yêu cầu hệ thống cho các nền tảng Linux và macOS mục tiêu**

- Thư viện runtime GCC 6 (hoặc mới hơn).
- [libgdiplus](https://github.com/mono/libgdiplus), một triển khai mã nguồn mở của API GDI+.
- Các phụ thuộc của .NET Core Runtime. Việc cài đặt .NET Core Runtime tự nó KHÔNG bắt buộc.
- Đối với Python 3.5–3.7: cần bản dựng `pymalloc` của Python. Tùy chọn biên dịch `--with-pymalloc` được bật mặc định. Thông thường, bản dựng `pymalloc` của Python có hậu tố `m` trong tên tệp.
- Thư viện chia sẻ `libpython`. Tùy chọn biên dịch Python `--enable-shared` bị tắt mặc định, và một số bản phân phối Python không bao gồm thư viện chia sẻ `libpython`. Trên một số nền tảng Linux, bạn có thể cài đặt thư viện chia sẻ `libpython` bằng trình quản lý gói (ví dụ, `sudo apt-get install libpython3.7`). Một vấn đề phổ biến là thư viện `libpython` được cài đặt ở vị trí không chuẩn cho các thư viện chia sẻ. Bạn có thể khắc phục bằng cách sử dụng tùy chọn biên dịch Python để đặt đường dẫn thư viện thay thế khi biên dịch Python, hoặc tạo một liên kết tượng trưng tới tệp thư viện `libpython` trong vị trí thư viện chia sẻ tiêu chuẩn của hệ thống. Thông thường, tên tệp thư viện chia sẻ `libpython` là `libpythonX.Ym.so.1.0` cho Python 3.5–3.7 hoặc `libpythonX.Y.so.1.0` cho Python 3.8 trở lên (ví dụ, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **Câu hỏi thường gặp**

**Tôi có cần cài đặt Microsoft PowerPoint để chuyển đổi và hiển thị không?**

Không, PowerPoint không bắt buộc; Aspose.Slides là một động cơ độc lập để [tạo](/slides/vi/python-net/create-presentation/), chỉnh sửa, [chuyển đổi](/slides/vi/python-net/convert-presentation/) và [hiển thị](/slides/vi/python-net/convert-powerpoint-to-png/) các bản trình chiếu.

**Có yêu cầu phiên bản .NET cụ thể (Core/5+/6+) trên máy không?**

Việc cài đặt .NET Runtime tự nó không bắt buộc, nhưng các phụ thuộc của nó phải có trên Linux/macOS. Điều này có nghĩa hệ thống cần chứa các gói thường được cài đặt như phụ thuộc của .NET, mà không cần cài toàn bộ runtime.

**Cần những phông chữ nào để hiển thị đúng?**

Trong thực tế, các phông chữ được sử dụng trong bản trình chiếu hoặc các [bản thay thế](/slides/vi/python-net/font-substitution/) phù hợp phải có sẵn. Để đảm bảo hiển thị nhất quán trên Linux/macOS, nên cài đặt các gói phông chữ chung.

**Tại sao một phông chữ tùy chỉnh lại hiển thị dưới dạng dự phòng hoặc văn bản bị thiếu trên Linux?**

Nếu tệp phông chữ có các mục bảng tên không nhất quán hoặc bị hỏng, ngăn xếp khớp phông chữ của Linux (FreeType/fontconfig) có thể chọn một bản ghi không hợp lệ, khiến phông chữ không được giải quyết. Sử dụng phiên bản phông chữ có bảng tên đã được sửa hoặc cài đặt một bản thay thế nhất quán sẽ giải quyết vấn đề.