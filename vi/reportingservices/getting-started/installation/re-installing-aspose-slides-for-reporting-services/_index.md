---
title: Cài đặt lại Aspose.Slides for Reporting Services
type: docs
weight: 40
url: /vi/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

Bài viết này mô tả cách khắc phục tình huống Aspose.Slides for Reporting Services đã được cài đặt, nhưng vì lý do nào đó, cần phải cài đặt lại.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** yêu cầu cài đặt **.NET Framework 3.5** trên máy chủ.

{{% /alert %}}

## **Các bước cài đặt lại Aspose.Slides for Reporting Services**
Điều quan trọng nhất là phải gỡ bỏ hoàn toàn các phiên bản Aspose.Slides for Reporting Services đã cài đặt trước. Mặc dù trình cài đặt MSI có thể thực hiện tự động các thao tác cần thiết để gỡ bỏ và do đó cài đặt lại Aspose.Slides for Reporting Services, nhưng vẫn cần tuân thủ các bước sau:

1. Gỡ cài đặt Aspose.Slides for Reporting Services bằng trình cài đặt MSI. 

2. Xác định thư mục cài đặt Aspose.Slides for Reporting Services, thường nằm ở:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. Nếu trình cài đặt MSI chưa xoá thư mục “Aspose.Slides for Reporting Services” khi gỡ cài đặt, hãy xóa thư mục này. 

4. Tìm file nhị phân **Aspose.Slides.ReportingServices.dll** trong thư mục “bin” của mỗi instance SQL Server Reporting Service. Ví dụ, nếu có một instance Microsoft SQL Server 2008 tên “MSSQLSERVER”, thư mục “bin” của Reporting Service tương ứng có thể nằm ở:

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Nếu trình cài đặt MSI chưa xoá file **Aspose.Slides.ReportingServices.dll** khỏi thư mục trên khi gỡ cài đặt, hãy xóa file ngay lập tức.

6. Xác định file **rsreportserver.config** cho mỗi instance SSRS. Ví dụ, nếu có một instance Reporting Service “**MSRS10.MSSQLSERVER**”, file **rsreportserver.config** sẽ nằm trong thư mục:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Mở file **rsreportserver.config** bằng bất kỳ trình soạn thảo nào và tìm các dòng đã được tạo để thêm PowerPoint Format Extensions trong quá trình cài đặt Aspose.Slides for Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Bước** **8:** Nếu trình cài đặt MSI chưa xoá các dòng này khi gỡ cài đặt Aspose.Slides for Reporting Services, hãy xoá chúng khỏi file **rsreportserver.config** ngay bây giờ.

**Bước** **9:** Xác định file **rssrvpolicy.config** cho mỗi instance SSRS. Ví dụ, nếu có một instance Reporting Service “MSRS10.MSSQLSERVER”, file **rssrvpolicy.config** sẽ nằm trong thư mục:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Bước** **10:** Mở file **rssrvpolicy.config** bằng bất kỳ trình soạn thảo nào và tìm các dòng đã được tạo để cấp quyền thực thi cho Aspose.Slides for Reporting Services trong quá trình cài đặt. 

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

**Bước** **11:** Nếu trình cài đặt MSI chưa xoá các dòng trên khi gỡ cài đặt sản phẩm, hãy xoá chúng khỏi file **rssrvpolicy.config** ngay bây giờ. 

**Bước** **12:** Nếu Aspose.Slides for Reporting Services cũng đã được cài đặt cùng Microsoft Visual Studio để phát triển báo cáo RDL và xuất sang định dạng PowerPoint trong môi trường Microsoft Visual Studio, file nhị phân Aspose.Slides.ReportingServices.dll và các file cấu hình (**rsreportserver.config** và **rssrvpolicy.config**) trong trường hợp Microsoft Visual Studio 2008 sẽ nằm ở:

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Bước** **13:** Nếu trình cài đặt MSI chưa xoá file **Aspose.Slides.ReportingServices.dll**, hãy xoá nó. Ngoài ra, nếu nó chưa cập nhật các file **rsreportserver.config** và **rssrvpolicy.config** để loại bỏ PowerPoint Format Extensions và quyền thực thi mã, bạn phải xoá chúng thủ công tương tự như các bước trước. 

**Bước** **14:** Đến lúc cài đặt lại Aspose.Slides for Reporting Services. Sử dụng trình cài đặt MSI để cài đặt tự động hoặc thực hiện thủ công.