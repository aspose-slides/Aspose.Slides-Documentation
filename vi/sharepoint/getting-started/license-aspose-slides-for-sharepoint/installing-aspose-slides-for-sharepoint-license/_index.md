---
title: Cài đặt giấy phép Aspose.Slides cho SharePoint
type: docs
weight: 10
url: /vi/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 
Khi bạn đã hài lòng với bản đánh giá, bạn có thể [mua giấy phép](https://purchase.aspose.com/buy). Trước khi mua, hãy chắc chắn rằng bạn hiểu và đồng ý với các điều khoản đăng ký giấy phép. Giấy phép sẽ được gửi qua email cho bạn khi đơn hàng đã được thanh toán.

Giấy phép là một tệp ZIP chứa gói giải pháp SharePoint thông thường. Tệp nén bao gồm:

- Aspose.Slides.SharePoint.License.wsp – tệp gói giải pháp SharePoint. Giấy phép được đóng gói dưới dạng giải pháp SharePoint để việc triển khai và thu hồi trên toàn bộ farm máy chủ trở nên dễ dàng.
- readme.txt – Hướng dẫn cài đặt giấy phép.
{{% /alert %}} 
## **Triển khai Giấy phép**
Việc cài đặt giấy phép được thực hiện từ console của máy chủ thông qua **stsadm.exe**.

{{% alert color="primary" %}} 
Các đường dẫn đã được bỏ qua trong phần sau để làm rõ.
{{% /alert %}} 

Thực hiện các bước sau để triển khai giấy phép Aspose.Slides cho SharePoint:

1. Chạy stsadm để thêm giải pháp vào kho giải pháp SharePoint: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Triển khai giải pháp tới tất cả các máy chủ trong farm: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Thực thi các job hẹn giờ quản trị để hoàn thành việc triển khai ngay lập tức: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 
Bạn sẽ nhận được cảnh báo khi thực hiện bước triển khai nếu dịch vụ Windows SharePoint Services Administration không chạy. **stsadm.exe** phụ thuộc vào dịch vụ này và dịch vụ Windows SharePoint Timer Service để sao chép dữ liệu giải pháp trên toàn farm. Nếu các dịch vụ này không chạy trên farm của bạn, bạn có thể cần triển khai giấy phép trên mỗi máy chủ. 
{{% /alert %}} 
## **Kiểm tra Giấy phép**
Để kiểm tra xem giấy phép đã được cài đặt đúng chưa, hãy chuyển đổi bất kỳ tài liệu nào sang định dạng mới. Nếu tài liệu không có watermark đánh giá, nghĩa là giấy phép đã được kích hoạt thành công.