---
title: Gỡ bỏ giấy phép Aspose.Slides cho SharePoint
type: docs
weight: 20
url: /vi/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
Để gỡ bỏ giấy phép, vui lòng thực hiện các bước dưới đây từ bảng điều khiển máy chủ.

1. Thu hồi giải pháp giấy phép khỏi farm:

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Thực thi các công việc hẹn giờ quản trị để hoàn thành việc thu hồi ngay lập tức:

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Đợi cho đến khi việc thu hồi hoàn tất. Bạn có thể sử dụng Central Administration để kiểm tra xem việc thu hồi đã hoàn thành chưa dưới **Central Administration**, sau đó **Operations** và **Solution Management**.
4. Xóa giải pháp khỏi kho giải pháp SharePoint:

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```