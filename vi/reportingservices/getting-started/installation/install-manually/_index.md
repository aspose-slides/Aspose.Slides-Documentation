---
title: Cài đặt thủ công
type: docs
weight: 30
url: /vi/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

Chỉ thực hiện các bước sau nếu bạn dự định cài đặt Aspose.Slides for Reporting Services theo cách thủ công. Trong trường hợp này, bạn đã tải về gói ZIP chứa các tệp assembly. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** yêu cầu cài đặt **.NET Framework 3.5** trên máy chủ. 

{{% /alert %}}

### **Cài đặt thủ công**
Các hướng dẫn này cho bạn biết cách sao chép và chỉnh sửa các tệp trong thư mục nơi Microsoft SQL Server Reporting Services được cài đặt:

1. Xác định thư mục cài đặt Report Server.  
   Thư mục gốc cho Microsoft SQL Server thường nằm ở đây: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 và 2008**: Có thể có một số phiên bản Microsoft SQL Server được cấu hình trên máy và chúng có thể nằm trong các thư mục con MSSQL.x khác nhau như MSSQL.1, MSSQL.2, v.v. Bạn phải tìm thư mục ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** đúng trước khi tiếp tục bước tiếp theo.  
   
   {{% /alert %}} Tất cả các đường dẫn được sử dụng bên dưới sẽ tham chiếu tới thư mục này dưới tên <Instance>. 

2. Sao chép Aspose.Slides.ReportingServices.dll vào thư mục **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.  
   Tệp tải xuống **Aspose.Slides.ReportingServices.zip** chứa **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

Trong một số trường hợp, khi bạn sao chép DLL vào thư mục **ReportServer\bin**, nó có thể được sao chép kèm theo các quyền tệp NTFS được chỉ định rõ ràng. Các quyền NTFS này khiến Microsoft SQL Server Reporting Services bị từ chối truy cập khi tải **Aspose.Slides.ReportingServices.dll**. Nếu xảy ra như vậy, các định dạng xuất mới sẽ không khả dụng. Kiểm tra và xác nhận rằng các quyền NTFS đúng đã được thiết lập :

   1. Nhấp chuột phải vào **Aspose.Slides.ReportingServices.dll**.  
   1. Chọn **Properties** và chuyển tới tab **Security**.  
   1. Xóa bất kỳ quyền NTFS nào được gán rõ ràng và chỉ để lại các quyền kế thừa.  

{{% /alert %}}

3. Đăng ký Aspose.Slides for Reporting Services như một phần mở rộng render:  
   1. Mở *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.  
   2. Thêm các dòng sau vào phần tử <Render>:  

**<Render>**

``` xml

   ...

  <!--Bắt đầu ở đây.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Kết thúc ở đây.-->

</Render>



```

4. Cấp quyền thực thi cho Aspose.Slides for Reporting Services:  
   1. Mở **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.  
   2. Thêm phần sau vào mục cuối cùng của phần tử <CodeGroup> thứ hai (phần tử này nên là <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">).  

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Bắt đầu ở đây.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="This code group grants full trust to the AS4SSRS assembly.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--Kết thúc ở đây.-->

  </CodeGroup>

</CodeGroup>



```

5. Xác nhận rằng Aspose.Slides for Reporting Services đã được cài đặt thành công:  
   1. Mở Report Manager và kiểm tra danh sách các loại xuất có sẵn cho một báo cáo.  

      {{% alert color="primary" %}} Bạn có thể khởi chạy Report Manager bằng cách mở trình duyệt (Microsoft Internet Explorer 6.0 trở lên) và nhập URL của Report Manager vào thanh địa chỉ (mặc định là http://< ComputerName >/Reports ).  
   
      {{% /alert %}}

1. Chọn một báo cáo trên máy chủ.  
1. Mở danh sách **Select Format**.  
   Bạn sẽ thấy danh sách các định dạng xuất do Aspose.Slides for Reporting Services cung cấp.  
1. Chọn **PPT – PowerPoint Presentation via Aspose.Slides**.  

   **Aspose.Slides for Reporting Services đã được cài đặt thành công và các định dạng xuất mới đã có sẵn.**  

![todo:image_alt_text](install-manually_1.png)




6. Nhấp vào liên kết **Export**.  
   Báo cáo được tạo dưới định dạng đã chọn, gửi tới client, và sau đó mở trong một ứng dụng phù hợp. Trong trường hợp của chúng tôi, báo cáo được mở bằng Microsoft PowerPoint.  

   **Một báo cáo PPT được tạo bởi Aspose.Slides for Reporting Services.**  

![todo:image_alt_text](install-manually_2.png)

Bạn đã cài đặt Aspose.Slides for Reporting Services thành công và tạo một báo cáo dưới dạng bản trình bày Microsoft PowerPoint!