---
title: Tích hợp với JasperServer
type: docs
weight: 45
url: /vi/jasperreports/integration-with-jasperserver/
description: "Thêm các bộ xuất Aspose.Slides cho JasperReports vào JasperReports Server: sao chép các file JAR, đăng ký bộ xuất PowerPoint và thiết lập ánh xạ phông chữ cùng giấy phép."
---
## **Sao chép các file JAR**

Sao chép cả hai file JAR — *aspose.slides.jasperreports.library-xx.x.jar* và *aspose.slides.jasperreports.server-xx.x.jar* — vào **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\lib**. Lấy chúng từ cùng một thư mục con của thư mục *lib* trong bản tải xuống: thư mục phù hợp với phiên bản JasperReports mà máy chủ của bạn đang chạy. Xem [Installing Aspose.Slides for JasperReports](/slides/vi/jasperreports/installing-aspose-slides-for-jasperreports/) để biết các khoảng phiên bản.

## **Đăng ký bộ xuất**

Thêm các bean của bộ xuất mới vào tệp cấu hình **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\flows\viewReportBeans.xml**. Lớp `ASPptReportExporter` nằm trong jar server; cùng jar cũng chứa `ASPptxReportExporter`, `ASPdfReportExporter` và `ASHtmlReportExporter`.

``` xml
<bean id="reportPptExporter" class="com.aspose.slides.jasperreports.ASPptReportExporter" parent="baseReportExporter">
    <property name="exportParameters" ref="pptExportParameters"/>
    <property name="setResponseContentLength" value="true"/>
</bean>

<bean id="pptExporterConfiguration" class="com.jaspersoft.jasperserver.war.action.ExporterConfigurationBean">
    <property name="descriptionKey" value="PowerPoint Presentation via Aspose.Slides"/>
    <property name="iconSrc" value="/images/ppt.png"/>
    <property name="parameterDialogName" value=""/>
    <property name="exportParameters" ref="pptExportParameters"/>
    <property name="currentExporter" ref="reportPptExporter"/>
</bean>

<util:map id="exporterConfigMap">
    <!-- thêm mục này vào exporterConfigMap -->
    <entry key="ppt" value-ref="pptExporterConfiguration"/>
</util:map>
```

## **Thiết lập ánh xạ phông chữ và giấy phép**

Xác định bean `pptExportParameters` mà bộ xuất tham chiếu trong **%INSTALL_DIR%\apache-tomcat\webapps\jasperserver\WEB-INF\applicationContext.xml**. Thuộc tính `fontMap` của nó ánh xạ tên phông chữ được sử dụng trong báo cáo sang các phông chữ được ghi vào bản trình bày, và thuộc tính `licenseFile` đặt đường dẫn tới tệp giấy phép của bạn.

``` xml
<bean id="pptExportParameters" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="fontMap">
        <util:map id="fontMap">
            <entry key="SansSerif" value="Arial"/>
            <entry key="Serif" value="Times New Roman"/>
            <entry key="Monospaced" value="Courier New"/>
        </util:map>
    </property>
    <property name="needAlterText" value="false"/>
    <property name="licenseFile" value="C:/jasperserver-XX/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```

{{% alert color="warning" title="Warning" %}}
Viết mỗi khóa `fontMap` chính xác như tên phông chữ trong báo cáo, bao gồm cả chữ hoa/thường: khóa `sansserif` sẽ không thay thế phông chữ mặc định của JasperReports, `SansSerif`. Mỗi giá trị phải là một phông chữ mà Java tìm thấy trên máy chủ, nếu không các bộ xuất sẽ bỏ qua mục này. Trên Windows, ví dụ, Java tìm thấy `Courier New` nhưng không tìm thấy `Courier`. Xem [Map fonts](/slides/vi/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts).
{{% /alert %}}