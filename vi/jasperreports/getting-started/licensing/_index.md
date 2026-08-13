---
title: Cấp phép
type: docs
weight: 50
url: /vi/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides cho JasperReports có sẵn dưới dạng bản đánh giá không giới hạn thời gian miễn phí từ [trang tải xuống](https://downloads.aspose.com/slides/vi/jasperreport). Phiên bản đánh giá và phiên bản có giấy phép của sản phẩm đều là cùng một tệp tải xuống.

Khi bạn hài lòng với bản đánh giá, [mua giấy phép](https://purchase.aspose.com/buy). Hãy chắc chắn rằng bạn hiểu và đồng ý với các điều khoản đăng ký.

Giấy phép có thể tải xuống từ trang đơn hàng sau khi đơn hàng đã được thanh toán. Giấy phép là một tệp XML văn bản thuần, được ký số kỹ thuật số, chứa các thông tin như tên khách hàng, sản phẩm đã mua và loại giấy phép. Không thay đổi bất kỳ nội dung nào của tệp giấy phép dưới bất kỳ hình thức nào: việc làm này sẽ làm mất hiệu lực giấy phép.

Tải giấy phép về máy tính của bạn và sao chép nó vào thư mục phù hợp (ví dụ thư mục ứng dụng của bạn hoặc **JasperReports\lib**).
{{% /alert %}}

## **Giới hạn phiên bản đánh giá**
Phiên bản đánh giá của Aspose.Slides (không có giấy phép được chỉ định) cung cấp đầy đủ chức năng của sản phẩm, nhưng (khi bạn lưu bản trình bày) nó sẽ chèn một dấu watermark đánh giá ở trung tâm mỗi slide như được hiển thị trong hình dưới đây:

![todo:image_alt_text](evaluation_watermark.png) 

## **Áp dụng giấy phép**
Có một số cách để áp dụng giấy phép, tùy thuộc vào việc bạn đang làm việc với JasperReports hay JasperServer.

### **Áp dụng giấy phép cho JasperReports**
Sử dụng lời gọi phương thức setLicense trực tiếp tương tự như Aspose.Slides cho Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Tạo một đối tượng stream chứa tệp giấy phép
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
    
    //Khởi tạo lớp License
    License license = new License();
    
    //Thiết lập giấy phép qua đối tượng stream
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Hoặc, thiết lập tham số exporter trong mã.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Áp dụng giấy phép trên JasperServer**
Thiết lập tham số exporter trong file applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```