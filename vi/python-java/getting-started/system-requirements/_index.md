---
title: Yêu cầu Hệ thống
type: docs
weight: 60
url: /vi/python-java/system-requirements/
keywords:
- yêu cầu hệ thống
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Kiểm tra các yêu cầu về hệ điều hành, Python, Java và JPype để chạy Aspose.Slides cho Python qua Java trên Windows, Linux và macOS."
---
## **Tổng quan**

Aspose.Slides for Python via Java tạo, chỉnh sửa, chuyển đổi và hiển thị các bản trình chiếu mà không cần cài đặt Microsoft PowerPoint. Nó sử dụng JPype để truy cập thư viện Java từ Python, vì vậy môi trường phải hỗ trợ Python, Java và JPype cùng nhau.

## **Hệ điều hành được hỗ trợ**

The [Aspose.Slides package](https://pypi.org/project/aspose-slides-java/) hỗ trợ các họ hệ điều hành sau:

- Windows
- Linux
- macOS

Chọn phiên bản hệ điều hành được hỗ trợ bởi các phiên bản Python, Java và JPype mà bạn đã chọn. Chỉ có Java sẵn có không đảm bảo tính tương thích với gói Python và cầu nối của nó.

## **Yêu cầu Python, Java và JPype**

| Thành phần | Yêu cầu |
| --- | --- |
| Python | Gói Aspose.Slides khai báo hỗ trợ Python từ 3.7 đến 3.14. Phiên bản JPype được chọn phải hỗ trợ cùng phiên bản Python; ví dụ, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) yêu cầu Python 3.8 trở lên. |
| Java | Cài đặt môi trường thực thi Java hoặc JDK tương thích với phiên bản JPype đã chọn. Các [yêu cầu trước của JPype](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) hiện tại yêu cầu Java 11 hoặc mới hơn. Java 8 không thể chạy JPype1 1.7.1. |
| JPype | Cài đặt gói JPype1 cho trình thông dịch Python, hệ điều hành và kiến trúc CPU của bạn. |
| Kiến trúc CPU | Python và Java Virtual Machine (JVM) phải sử dụng cùng kiến trúc. Ví dụ, một trình thông dịch Python 64-bit yêu cầu một JVM 64-bit tương thích. |

Trên Apple Silicon, Python và Java đều phải sử dụng ARM64 hoặc cả hai đều sử dụng x64. Một JVM chạy độc lập vẫn có thể không tải được qua JPype nếu kiến trúc của nó khác với kiến trúc của Python.

Đối với môi trường mới, Python 3.12, JDK 17 và JPype1 1.7.1 là điểm khởi đầu phù hợp. Sự kết hợp này đã được xác minh với Aspose.Slides for Python via Java 26.6.0 trên Windows. Các kết hợp khác phải đáp ứng các yêu cầu của cả ba thành phần.

Để thiết lập môi trường và một ví dụ kiểm chứng hoạt động, xem mục [Cài đặt](/slides/vi/python-java/installation/).

## **Phụ thuộc bổ sung**

Một gói JPype wheel được biên dịch sẵn phù hợp không yêu cầu trình biên dịch C++. Nếu JPype phải được biên dịch từ nguồn, hãy cài đặt trình biên dịch C++ phù hợp và các tệp phát triển Python cần thiết cho nền tảng của bạn. Xem [hướng dẫn cài đặt JPype](https://jpype.readthedocs.io/en/latest/install.html) để biết yêu cầu xây dựng và khắc phục sự cố.

## **Câu hỏi thường gặp**

**Tôi có cần cài đặt Microsoft PowerPoint không?**

Không. Aspose.Slides xử lý các bản trình chiếu một cách độc lập với PowerPoint. Python, Java và JPype vẫn là bắt buộc.

**Tôi có thể sử dụng Python 3.7 với bất kỳ phiên bản JPype nào không?**

Không. Mặc dù gói Aspose.Slides khai báo hỗ trợ Python 3.7, JPype1 1.7.1 yêu cầu Python 3.8 trở lên. Hãy chọn các phiên bản có yêu cầu chồng lắp nhau.

**Tôi có thể trộn Python 32-bit với Java 64-bit không?**

Không. JPype tải JVM vào tiến trình Python, do đó Python và Java phải có kiến trúc khớp nhau. Yêu cầu tương tự áp dụng cho ARM64 và x64 trên macOS.