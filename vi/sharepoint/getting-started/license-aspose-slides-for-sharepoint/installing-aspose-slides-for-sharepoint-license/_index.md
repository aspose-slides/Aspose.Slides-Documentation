---
title: "Cài đặt Giấy phép Aspose.Slides cho SharePoint"
type: docs
weight: 10
url: /vi/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Cài đặt giấy phép Aspose.Slides cho SharePoint trên một farm SharePoint: thêm giải pháp giấy phép vào kho giải pháp, triển khai nó và kiểm tra rằng các tệp đã chuyển đổi không còn mang watermark đánh giá."
---
{{% alert color="info" title="Note" %}}

Khi bạn đã hài lòng với phiên bản đánh giá, bạn có thể [mua giấy phép](https://purchase.aspose.com/pricing/slides/sharepoint/). Trước khi mua, hãy đảm bảo bạn hiểu và đồng ý với các điều khoản đăng ký giấy phép. Giấy phép sẽ được gửi qua email cho bạn khi đơn hàng đã được thanh toán.

Giấy phép là một tệp ZIP chứa một gói giải pháp SharePoint thông thường. Tệp nén chứa:

- Aspose.Slides.SharePoint.License.wsp – tệp gói giải pháp SharePoint. Giấy phép được đóng gói dưới dạng giải pháp SharePoint để việc triển khai và thu hồi trên toàn farm máy chủ trở nên dễ dàng.
- readme.txt – hướng dẫn cài đặt giấy phép.

{{% /alert %}}

## **Triển khai giấy phép**

Cài đặt giấy phép được thực hiện từ console máy chủ qua **stsadm.exe**.

{{% alert color="info" title="Note" %}}

Các đường dẫn được bỏ qua trong phần sau để tăng tính rõ ràng.

{{% /alert %}}

Thực hiện các bước sau để triển khai giấy phép Aspose.Slides cho SharePoint:

1. Chạy stsadm để thêm giải pháp vào kho giải pháp SharePoint:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Triển khai giải pháp tới tất cả các máy chủ trong farm:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Thực thi các công việc timer quản trị để hoàn thành việc triển khai ngay lập tức:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

Thao tác `addsolution` nhận đường dẫn của tệp giải pháp trong `-filename`; thao tác `deploysolution` nhận tên của giải pháp đã có trong kho giải pháp trong `-name`.

{{% alert color="info" title="Note" %}}

Bạn sẽ nhận được cảnh báo khi thực hiện bước triển khai nếu dịch vụ SharePoint Administration không chạy. **stsadm.exe** phụ thuộc vào dịch vụ này và dịch vụ SharePoint Timer để sao chép dữ liệu giải pháp trên toàn farm. Nếu các dịch vụ này không chạy trên farm máy chủ của bạn, bạn có thể cần triển khai giấy phép trên từng máy chủ.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

Trên SharePoint 2010 trở lên, các cmdlet của SharePoint Management Shell `Add-SPSolution`, `Install-SPSolution` và `Start-SPAdminJob` tương ứng với các thao tác `addsolution`, `deploysolution` và `execadmsvcjobs`. Xem [Bản đồ Stsadm sang Microsoft PowerShell trong SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Kiểm tra giấy phép**

Để kiểm tra xem giấy phép đã được cài đặt đúng chưa, chuyển đổi bất kỳ bản trình chiếu nào sang định dạng mới. Nếu không có watermark đánh giá trong tệp đã chuyển đổi, giấy phép đã hoạt động.