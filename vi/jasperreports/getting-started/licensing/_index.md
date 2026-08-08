---
title: Cấp phép
type: docs
weight: 50
url: /vi/jasperreports/licensing/
---
{{% alert color="primary" %}} 
Aspose.Slides for JasperReports có sẵn dưới dạng bản đánh giá miễn phí không giới hạn thời gian từ [trang tải xuống](https://downloads.aspose.com/slides/vi/jasperreport). Bản đánh giá và phiên bản có giấy phép của sản phẩm đều được tải xuống từ cùng một địa chỉ.

Khi bạn hài lòng với bản đánh giá, [mua giấy phép](https://purchase.aspose.com/buy). Đảm bảo bạn hiểu và đồng ý với các điều khoản thuê bao.

Giấy phép có thể tải xuống từ trang đơn hàng sau khi đơn đã được thanh toán. Giấy phép là một tệp XML dạng văn bản thuần, được ký số, chứa các thông tin như tên khách hàng, sản phẩm đã mua và loại giấy phép. Không thay đổi nội dung của tệp giấy phép bằng bất kỳ cách nào: việc này sẽ làm giấy phép mất hiệu lực.

Tải giấy phép về máy tính của bạn và sao chép nó vào thư mục thích hợp (ví dụ thư mục ứng dụng của bạn hoặc **JasperReports\lib**).
{{% /alert %}}

## **Giới hạn của phiên bản đánh giá**
Phiên bản đánh giá của Aspose.Slides (không có giấy phép được chỉ định) cung cấp đầy đủ chức năng của sản phẩm, nhưng (khi bạn lưu các bản trình chiếu) nó sẽ chèn một dấu watermark đánh giá vào giữa mỗi slide như hình dưới đây:

![todo:image_alt_text](evaluation_watermark.png) 

## **Áp dụng giấy phép**
Có một số cách để áp dụng giấy phép, tùy thuộc vào việc bạn đang làm việc trên JasperReports hay JasperServer.

### **Áp dụng giấy phép cho JasperReports**
Sử dụng lời gọi phương thức setLicense trực tiếp tương tự như Aspose.Slides for Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Tạo một đối tượng stream chứa tệp giấy phép
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Khởi tạo lớp License
    License license = new License();
	
    //Đặt giấy phép thông qua đối tượng stream
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Hoặc, đặt tham số exporter trong mã.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Áp dụng giấy phép trên JasperServer**
Đặt tham số exporter trong applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```