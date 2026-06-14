---
title: Cấp phép
type: docs
weight: 50
url: /vi/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports có sẵn dưới dạng bản dùng thử miễn phí không thời gian giới hạn từ [trang tải xuống](https://downloads.aspose.com/slides/vi/jasperreport). Bản dùng thử và các phiên bản có bản quyền của sản phẩm đều được tải xuống từ cùng một địa chỉ.

Khi bạn hài lòng với bản dùng thử, [mua giấy phép](https://purchase.aspose.com/buy). Đảm bảo bạn đã hiểu và đồng ý với các điều khoản thuê bao.

Giấy phép có thể tải về từ trang đặt hàng sau khi đơn hàng đã được thanh toán. Giấy phép là một tệp XML văn bản thuần, được ký số và chứa các thông tin như tên khách hàng, sản phẩm đã mua và loại giấy phép. Không thay đổi bất kỳ nội dung nào của tệp giấy phép: việc làm này sẽ làm giấy phép mất hiệu lực.

Tải giấy phép về máy tính của bạn và sao chép vào thư mục thích hợp (ví dụ: thư mục ứng dụng của bạn hoặc **JasperReports\lib**).

## **Giới hạn của phiên bản dùng thử**
Phiên bản dùng thử của Aspose.Slides (không có giấy phép được chỉ định) cung cấp đầy đủ chức năng của sản phẩm, nhưng (khi bạn lưu các bản trình chiếu) nó sẽ chèn một watermark dùng thử ở trung tâm mỗi slide như hình dưới đây:

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
	
    //Thiết lập giấy phép qua đối tượng stream
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
Đặt tham số exporter trong file applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```