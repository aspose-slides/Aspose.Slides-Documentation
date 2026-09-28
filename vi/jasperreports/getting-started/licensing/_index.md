---
title: Cấp phép
type: docs
weight: 50
url: /vi/jasperreports/licensing/
description: "Tìm hiểu phiên bản đánh giá của Aspose.Slides for JasperReports thêm gì vào các tệp xuất, và cách áp dụng giấy phép trong JasperReports và JasperReports Server."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports có sẵn dưới dạng bản đánh giá miễn phí, không giới hạn thời gian từ [download page](https://releases.aspose.com/slides/jasperreport/). Phiên bản đánh giá và phiên bản có bản quyền của sản phẩm đều được tải xuống từ cùng một địa chỉ.

Khi bạn hài lòng với bản đánh giá, [buy a license](https://purchase.aspose.com/pricing/slides/jasperreports/). Đảm bảo bạn hiểu và đồng ý với các điều khoản đăng ký.

Bản quyền có thể tải xuống từ trang đặt hàng sau khi đơn hàng đã được thanh toán. Bản quyền là tệp XML dạng văn bản thuần, được ký số kỹ thuật số, chứa các thông tin như tên khách hàng, sản phẩm đã mua và loại giấy phép. Không được thay đổi nội dung của tệp bản quyền bằng bất kỳ cách nào: việc này sẽ làm mất hiệu lực của giấy phép.

Tải bản quyền về máy tính của bạn và sao chép nó vào thư mục thích hợp (ví dụ: thư mục ứng dụng của bạn hoặc **JasperReports\lib**).
{{% /alert %}}

## **Evaluation Version Limitation**
Phiên bản đánh giá của Aspose.Slides for JasperReports (không chỉ định bản quyền) xuất mọi trang của báo cáo, nhưng sẽ chèn một dấu nước đánh giá ở trung tâm mỗi slide hoặc trang, trong cả bốn định dạng đầu ra (PPT, PPTX, PDF và HTML), như hình dưới đây. Xem [Evaluate Aspose.Slides](/slides/vi/jasperreports/evaluate-aspose-slides/) để biết chi tiết.

![The evaluation watermark at the center of an exported slide](evaluation_watermark.png)

## **Applying a License**
Có một số cách để áp dụng bản quyền, tùy thuộc vào việc bạn đang làm việc với JasperReports hay JasperServer.

### **Applying a License for JasperReports**
Gọi phương thức `setLicense` của lớp `License` với một luồng đọc tệp bản quyền, giống như trong Aspose.Slides for Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Tạo một đối tượng luồng chứa tệp bản quyền.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Tạo một thể hiện của lớp License.
            License license = new License();

            // Đặt bản quyền qua đối tượng luồng.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Hoặc, truyền đường dẫn của tệp bản quyền cho bộ xuất trong tham số `ASExporterParameters.PPT_LICENSE`. Trong đoạn mã này, `jasperPrint` là báo cáo đã được điền dữ liệu, như trong [Your first export](/slides/vi/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Applying a License on JasperServer**
Đặt thuộc tính `licenseFile` của bean `pptExportParameters` trong *applicationContext.xml* thành đường dẫn của tệp bản quyền, như được mô tả trong [Integration with JasperServer](/slides/vi/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).