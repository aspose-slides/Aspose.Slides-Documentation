---
title: Bảo vệ mật khẩu cho bản trình bày đã xuất
type: docs
weight: 90
url: /vi/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

Bảo vệ mật khẩu cho một bản trình bày ngăn ngừa việc sử dụng và truy cập trái phép. Bảo vệ mật khẩu hữu ích nếu bạn đang tạo báo cáo có chứa dữ liệu nhạy cảm hoặc chi tiết mà chỉ một số người trong tổ chức của bạn nên xem.

Bài viết này hướng dẫn cách cập nhật môi trường Reporting Services hoặc Visual Studio của bạn để cho phép lưu các bản trình bày với bảo vệ mật khẩu.

{{% /alert %}} 
## **Thêm Bảo Vệ Mật Khẩu cho Các Bản Trình Bày Được Xuất trong Môi Trường Reporting Services**
Để áp dụng các thay đổi này, bạn cần chỉnh sửa các tệp trong thư mục nơi Microsoft SQL Server Reporting Services được cài đặt.
### **Bước 1. Xác định thư mục cài đặt Reporting Server.**
Thư mục gốc của Microsoft SQL Server thường là C:\Program Files\Microsoft SQL Server.

{{% alert color="primary" %}} 

Đối với hệ thống 64-bit, phiên bản x86 của SQL Server được cài đặt tại C:\Program Files (x86)\Microsoft SQL Server\

{{% /alert %}} 

Microsoft SQL Server 2005 và 2008: Có thể có nhiều phiên bản Microsoft SQL Server được cấu hình trên máy. Mỗi phiên bản chiếm một thư mục con MSSQL.x khác nhau, ví dụ MSSQL.1, MSSQL.2, v.v. Hãy tìm thư mục C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer đúng trước khi thực hiện các bước tiếp theo.

Tất cả các đường dẫn được sử dụng dưới đây tham chiếu đến thư mục cài đặt Microsoft SQL Server Reporting Services dưới dạng <Instance>.
### **Bước 2. Thêm mã để thêm mật khẩu vào các bản trình bày được xuất**
Thay thế các tiện mở rộng render Aspose.Slides for Reporting Services hiện có trong tệp **rsreportserver.config**. Để thực hiện điều này, mở tệp C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config.

Tìm các tùy chọn render được liệt kê ngay bên dưới và thay thế chúng bằng mã trong đoạn tiếp theo.
#### **Tìm Các Tùy Chọn Render Aspose.Slides cho Reporting Service**
**<Render>**

``` xml

   ...

  <!--Bắt đầu ở đây.>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Kết thúc ở đây.-->


</Render>



```
#### **Mã Thay Thế**
**<Render>**

``` xml

   ...

  <!--Bắt đầu ở đây.-->



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		



	<Password>111</Password>

  </Configuration>			



 </Extension>

  <!--Kết thúc ở đây.-->


</Render>



```
### **Thêm Bảo Vệ Mật Khẩu cho Các Bản Trình Bày Được Xuất trong Visual Studio**
Để áp dụng các thay đổi này, bạn cần chỉnh sửa tệp nơi Microsoft Visual Studio Report Designer được cài đặt.
### **Bước 1. Mở thư mục Visual Studio.**
- Để tích hợp với Visual Studio 2005 Report Designer, mở thư mục C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies.
- Để tích hợp với Visual Studio 2008 Report Designer, mở thư mục C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies.
### **Bước 2. Thêm mã để thêm mật khẩu vào các bản trình bày được xuất.**
Thay thế các tiện mở rộng render Aspose.Slides for Reporting Services hiện có trong tệp **rsreportserver.config**. Để thực hiện, mở tệp C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config (trong đó **<Version>** là “8” cho Visual Studio 2005 hoặc “9.0” cho Visual Studio 2008) và thêm các dòng này vào phần tử **<Render>**. Sau đó thay thế chúng bằng mã trong đoạn mã tiếp theo.
#### **Tìm Các Tùy Chọn Render Aspose.Slides cho Reporting Service**
**<Render>**

``` xml

   ...

  <!--Bắt đầu ở đây.>



  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--Kết thúc ở đây.-->


</Render>



```
#### **Mã Thay Thế**
**<Render>**

``` xml

   ...

  <!--Bắt đầu ở đây.>


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >



  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <!--Kết thúc ở đây.-->
</Render>

```