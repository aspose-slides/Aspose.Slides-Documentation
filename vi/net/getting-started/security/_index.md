---
title: Bảo mật
type: docs
weight: 160
url: /vi/net/security/
keywords:
- bảo mật
- phụ thuộc
- các thành phần bên thứ ba
- NuGet
- quét lỗ hổng
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem xét cách Aspose.Slides for .NET xử lý các bài thuyết trình, các gói NuGet nó phụ thuộc cho mỗi khung mục tiêu, và các thành phần bên thứ ba mà nó bao gồm."
---
## **Bảo mật trong Aspose.Slides**

Aspose áp dụng các thực hành tốt nhất khi phát triển các sản phẩm của mình.

* Aspose.Slides for .NET được dùng để thao tác với các bài thuyết trình và chuyển đổi chúng sang các định dạng khác. Nó không chạy tập lệnh trong các bài thuyết trình. Aspose.Slides phân tích cấu trúc bài thuyết trình và cho phép mã của người dùng cuối thao tác với mô hình đối tượng một cách thuận tiện.
* Aspose.Slides hoạt động như một thư viện phân tích và diễn giải tài liệu mà không thực thi mã từ xa. Tất cả sản phẩm Aspose chạy trên máy của bạn. Chúng không truyền bất kỳ dữ liệu nào tới Aspose. Ngoại lệ duy nhất là một [giấy phép tính theo mức](https://purchase.aspose.com/faqs/licensing/metered): nếu bạn sử dụng, chỉ thông tin sử dụng API của bạn được xử lý.
* Các thành phần Aspose chạy trong cùng ngữ cảnh người dùng như các ứng dụng thông thường. Do đó, các thành phần Aspose không gây rủi ro cho các tài nguyên quan trọng của hệ thống. Hơn nữa, khi một thành phần Aspose mở tài liệu, macro không được chạy tự động.
* Các rủi ro vốn có hoặc liên quan đến bộ Microsoft Office không áp dụng cho các thành phần Aspose, vì vậy các sản phẩm Aspose rất an toàn.

## **Phụ thuộc NuGet**

Aspose.Slides for .NET phụ thuộc vào các gói mà Microsoft công bố trên NuGet. Các phụ thuộc khác nhau tùy theo gói và khung mục tiêu:

| Gói | Khung mục tiêu | Phụ thuộc |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

Phần **Dependencies** của các trang [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) và [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) trên NuGet liệt kê phiên bản tối thiểu của mỗi phụ thuộc cho mọi phiên bản phát hành.

Khi bạn thêm Aspose.Slides vào một dự án, NuGet cũng sẽ khôi phục các phụ thuộc của các gói này. Để liệt kê mọi gói mà dự án của bạn khôi phục, bao gồm các phụ thuộc truyền thống này, chạy lệnh sau trong thư mục dự án:

```bash
dotnet list package --include-transitive
```

Để kiểm tra cùng một tập hợp các gói đối với các lỗ hổng đã biết, chạy:

```bash
dotnet list package --vulnerable --include-transitive
```

Đối với các cách khác để kiểm tra các gói NuGet, xem [Kiểm toán phụ thuộc gói cho các lỗ hổng bảo mật](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Thành phần bên thứ ba**

Aspose.Slides bao gồm mã từ các thành phần nguồn mở của bên thứ ba. Chúng là một phần của sản phẩm, không phải là các gói NuGet riêng biệt, vì vậy các công cụ chỉ đọc phụ thuộc NuGet sẽ không liệt kê chúng. Cả hai gói đều chứa tệp *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, trong đó liệt kê các thành phần và giấy phép của chúng:

| Thành phần | Giấy phép được nêu trong thông báo |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **Câu hỏi thường gặp**

**Các hệ thống nào được sử dụng để giám sát lỗ hổng trong mã Aspose?**

Chúng tôi thực hiện phân tích mã tĩnh cho mỗi phiên bản Aspose.Slides. Chúng tôi có thể cung cấp báo cáo bảo mật chứng minh mã Aspose.Slides vượt qua OWASP Top 10.

**Aspose.Slides có sử dụng các gói bên ngoài không?**

Có. Nó phụ thuộc vào các gói NuGet của Microsoft được liệt kê trong [Phụ thuộc NuGet](#nuget-dependencies), và bao gồm các thành phần bên thứ ba được liệt kê trong [Thành phần bên thứ ba](#third-party-components). Bao gồm cả hai trong đánh giá bảo mật của bạn, và sử dụng `dotnet list package --vulnerable --include-transitive` để kiểm tra các gói NuGet mà dự án của bạn khôi phục.