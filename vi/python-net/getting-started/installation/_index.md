---
title: Cài đặt
type: docs
weight: 70
url: /vi/python-net/installation/
keywords:
- tải xuống Aspose.Slides
- cài đặt Aspose.Slides
- sử dụng Aspose.Slides
- cài đặt Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Cài đặt Aspose.Slides for Python via .NET từ PyPI bằng pip trên Windows, Linux và macOS, và cài đặt các thư viện gốc mà Linux và macOS cần."
---
## **Tổng quan**

Bài viết này giải thích cách cài đặt Aspose.Slides for Python via .NET trên Windows, Linux và macOS. Gói được xuất bản trên [PyPI](https://pypi.org/project/aspose.slides/) và cài đặt bằng pip. Nó bao gồm môi trường runtime .NET mà nó sử dụng, vì vậy bạn không cần phải cài đặt .NET. Trên Linux và macOS, runtime đó cần các thư viện gốc mà hệ điều hành có thể không bao gồm; các phần bên dưới sẽ nêu tên chúng.

Aspose.Slides for Python via .NET hỗ trợ Python 3.5 đến 3.14. PyPI cung cấp các gói cho Windows (32-bit và 64-bit), Linux (x86_64 và ARM64), và macOS (Intel và Apple silicon).

## **Windows**

Trên Windows, cài đặt gói bằng pip. Không cần thư viện nào khác.

```bash
pip install aspose.slides
```

## **Linux**

Trên Linux, môi trường runtime .NET được bao gồm trong gói cần hai thư viện:

- **libgdiplus**, một triển khai API đồ họa Windows GDI+. Nếu không có, việc lưu bản trình chiếu sẽ thất bại với lỗi `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Nếu không có, quá trình Python sẽ kết thúc ngay khi gọi Aspose.Slides lần đầu với thông báo `Couldn't find a valid ICU package installed on the system`.

Trên Debian và Ubuntu, cài đặt cả hai bằng apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

Tên của gói ICU chứa phiên bản: `libicu76` là gói cho Debian 13. Trên Debian 12, cài đặt `libicu72` thay thế, và trên Ubuntu 24.04, `libicu74`. Để tìm tên trên hệ thống của bạn, chạy:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Sau đó cài đặt gói vào môi trường ảo. Trên các bản phát hành Debian và Ubuntu hiện tại, Python hệ thống không cho phép `pip install` ngoài môi trường ảo và dừng lại với lỗi `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Chạy các script của bạn với cùng môi trường ảo đã được kích hoạt. Nếu bạn sử dụng Python mà bản phân phối của bạn không quản lý, chẳng hạn như trong các hình ảnh Docker `python` chính thức, bạn cũng có thể chạy `pip install aspose.slides` mà không cần môi trường ảo.

Các phông chữ được sử dụng trong bản trình chiếu của bạn, hoặc các phông chữ thay thế phù hợp, phải được cài đặt trên hệ thống để văn bản hiển thị đúng khi bạn chuyển đổi slide sang PDF hoặc hình ảnh.

## **macOS**

Chúng tôi chưa kiểm chứng việc cài đặt trên macOS. Trên macOS, Aspose.Slides cần các tiền đề sau:

- **Python với thư viện chia sẻ**, nghĩa là Python được biên dịch với tùy chọn cấu hình `--enable-shared`. Nếu bạn cài đặt Python bằng [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), đặt biến môi trường `PYTHON_CONFIGURE_OPTS` thành `--enable-shared` khi cài đặt phiên bản Python.
- **Thư viện libpython trong thư mục thư viện hệ thống.** Python được cài bằng pyenv giữ thư viện libpython, chẳng hạn *libpython3.9.dylib*, trong *~/.pyenv/versions*; tạo một liên kết tượng trưng tới nó trong */usr/local/lib*.
- **libgdiplus**, một triển khai API đồ họa Windows GDI+. Homebrew cung cấp nó dưới dạng gói `mono-libgdiplus`.

Sau đó cài đặt gói bằng pip.

## **Kiểm tra cài đặt**

Để kiểm tra cài đặt, lưu ví dụ đầu tiên trong [Create Presentations](/slides/vi/python-net/create-presentation/) dưới tên *hello.py* và chạy `python hello.py`. Nó sẽ lưu *new_presentation.pptx* trong thư mục hiện tại.

## **Nâng cấp**

Để nâng cấp một cài đặt hiện có lên phiên bản mới nhất, chạy lệnh này trong môi trường nơi bạn đã cài đặt gói:

```bash
pip install --upgrade aspose.slides
```

## **Câu hỏi thường gặp**

**Tôi có thể cài đặt Aspose.Slides trong môi trường ảo không?**

Có. Bạn có thể cài đặt nó trong bất kỳ môi trường ảo Python nào bằng pip. Các thư viện gốc mà Linux và macOS cần được cài đặt trên hệ thống, không phải trong môi trường ảo.

**Tôi có thể sử dụng Aspose.Slides trong các container Docker không?**

Có. Image phải bao gồm các thư viện gốc tương tự như trên hệ thống Linux — libgdiplus và ICU — và các phông chữ mà bản trình chiếu của bạn sử dụng.

**Có phiên bản miễn phí hoặc giới hạn dùng thử không?**

Có. Khi không có giấy phép, Aspose.Slides chạy ở chế độ đánh giá: nó thêm dấu watermark đánh giá vào mọi slide khi lưu và cắt ngắn văn bản đọc từ các bản trình chiếu. Để loại bỏ các hạn chế này, áp dụng một [license](/slides/vi/python-net/licensing/) hợp lệ.