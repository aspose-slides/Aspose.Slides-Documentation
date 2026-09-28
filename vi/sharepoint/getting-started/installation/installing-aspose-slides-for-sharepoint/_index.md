---
title: Cài đặt Aspose.Slides cho SharePoint
type: docs
weight: 10
url: /vi/sharepoint/installing-aspose-slides-for-sharepoint/
description: "Cài đặt Aspose.Slides cho SharePoint trên một farm SharePoint: chọn chương trình cài đặt cho phiên bản SharePoint của bạn, chạy kiểm tra hệ thống, và triển khai cùng kích hoạt giải pháp."
---
## **Nội dung Gói**

Aspose.Slides for SharePoint được tải xuống từ [trang tải xuống](https://releases.aspose.com/slides/sharepoint/) dưới dạng tệp ZIP. Tệp lưu trữ chứa một gói giải pháp SharePoint (WSP) và một chương trình cài đặt cho mỗi phiên bản SharePoint được hỗ trợ:

| Phiên bản SharePoint | Chương trình cài đặt | Gói giải pháp |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

Mỗi chương trình cài đặt có một tệp cấu hình nằm cạnh nó (ví dụ, *Setup2019.exe.config*) ghi tên gói giải pháp mà nó cài đặt. Thư mục *License* chứa liên kết tới thỏa thuận giấy phép người dùng cuối và các thông báo giấy phép của bên thứ ba.

Aspose.Slides for SharePoint được đóng gói dưới dạng một giải pháp SharePoint, mà SharePoint triển khai trên toàn bộ farm máy chủ. Tính năng của nó sau đó được kích hoạt hoặc vô hiệu hoá cho từng bộ sưu tập site.

## **Quá trình Cài đặt**

Trước khi cài đặt, chương trình cài đặt thực hiện một kiểm tra hệ thống. Nó xác minh rằng:

- SharePoint đã được cài đặt trên máy chủ.
- Người dùng hiện tại có quyền cài đặt và triển khai các giải pháp SharePoint.
- Dịch vụ SharePoint Administration đã được khởi động.
- Dịch vụ SharePoint Timer đã được khởi động.
- Gói giải pháp được ghi trong tệp cấu hình có sẵn.

Dịch vụ Administration và Timer cần thiết vì một số hành động cài đặt chạy như các công việc hẹn giờ để triển khai giải pháp tới tất cả các máy chủ trong farm.

### **Thực hiện Cài đặt**

Để cài đặt Aspose.Slides for SharePoint:

1. Giải nén tệp ZIP vào ổ đĩa cục bộ trên một máy chủ trong farm SharePoint.
2. Chạy chương trình cài đặt phù hợp với phiên bản SharePoint của bạn (xem bảng ở trên) và làm theo hướng dẫn trên màn hình. Chương trình cài đặt:
   1. Thực hiện kiểm tra hệ thống. Quá trình cài đặt sẽ không tiếp tục nếu bất kỳ kiểm tra nào thất bại.

      **Thực hiện kiểm tra hệ thống**

      ![Màn hình Kiểm tra hệ thống của chương trình cài đặt](installing-aspose-slides-for-sharepoint_1.png)

   2. Hiển thị thỏa thuận giấy phép người dùng cuối. Bạn phải chấp nhận để tiếp tục.

      **Thỏa thuận giấy phép**

      ![Màn hình thỏa thuận giấy phép của chương trình cài đặt](installing-aspose-slides-for-sharepoint_2.png)

   3. Hiển thị các mục tiêu triển khai. Chọn các ứng dụng web và bộ sưu tập site để kích hoạt tính năng.

      **Chọn mục tiêu triển khai**

      ![Màn hình Mục tiêu Triển khai Bộ sưu tập Site của chương trình cài đặt](installing-aspose-slides-for-sharepoint_3.png)

   4. Triển khai giải pháp lên farm.

      **Tiến trình cài đặt**

      ![Màn hình tiến trình cài đặt của chương trình cài đặt](installing-aspose-slides-for-sharepoint_4.png)

   5. Kích hoạt Aspose.Slides for SharePoint trên các bộ sưu tập site đã chọn.
   6. Liệt kê các ứng dụng web và bộ sưu tập site mà giải pháp đã được triển khai và kích hoạt.

      **Cài đặt thành công**

      ![Màn hình hoàn tất cài đặt của chương trình cài đặt](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
Các ảnh chụp màn hình được chụp trên SharePoint 2007. Các chương trình cài đặt cho các phiên bản sau sẽ trải qua các màn hình tương tự.
{{% /alert %}}

Nếu cùng một phiên bản Aspose.Slides for SharePoint đã được cài đặt, chương trình cài đặt sẽ đề xuất sửa chữa hoặc gỡ bỏ. Nếu một phiên bản khác đã được cài đặt, nó sẽ đề xuất nâng cấp hoặc gỡ bỏ.

Sau khi cài đặt, một mục **Convert via Aspose.Slides** xuất hiện trong menu tập tin của các thư viện tài liệu trong các bộ sưu tập site đã chọn (trên SharePoint 2007, **Convert with Aspose.Slides**). Để chuyển đổi bài thuyết trình đầu tiên, xem [Chuyển đổi Tài liệu Microsoft PowerPoint sang Định dạng Khác](/slides/vi/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/). Những gì giải pháp thêm vào farm được mô tả trong [Triển khai và Kích hoạt](/slides/vi/sharepoint/deployment-and-activation/).

## **Câu hỏi thường gặp**

**Tôi nên chạy chương trình cài đặt nào?**

Chương trình có tên trùng với phiên bản SharePoint của bạn. Ví dụ, chạy *Setup2016.exe* trên một farm SharePoint Server 2016. Mỗi chương trình cài đặt chỉ cài đặt gói giải pháp của riêng nó.

**Tôi có cần tải xuống riêng cho phiên bản có giấy phép không?**

Không. Cùng một gói hoạt động ở chế độ dùng thử cho tới khi bạn cài đặt giải pháp giấy phép; xem [Cài đặt Giấy phép Aspose.Slides cho SharePoint](/slides/vi/sharepoint/installing-aspose-slides-for-sharepoint-license/).

**Làm thế nào để gỡ bỏ sản phẩm?**

Chạy lại cùng một chương trình cài đặt và chọn **Remove**; xem [Gỡ cài đặt Aspose.Slides cho SharePoint](/slides/vi/sharepoint/uninstalling-aspose-slides-for-sharepoint/).