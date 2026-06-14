---
title: Tích hợp thủ công với Visual Studio 2005 hoặc 2008 Report Designer
type: docs
weight: 50
url: /vi/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

Bài viết này hướng dẫn bạn cách tích hợp Aspose.Slides for Reporting Services một cách thủ công với Visual Studio. 

{{% /alert %}} 

{{% alert title="Lưu ý" color="warning" %}} 

**Aspose.Slides for Reporting Services** yêu cầu cài đặt **.NET Framework 3.5** trên máy chủ. 

{{% /alert %}}

## **Tích hợp Aspose.Slides for Reporting Services với Visual Studio**
Chúng tôi khuyên bạn nên sử dụng bộ cài đặt MSI để cài đặt Aspose.Slides for Reporting Services vì nó thực hiện tự động tất cả các tác vụ cài đặt và quá trình cấu hình cần thiết. Tuy nhiên, nếu việc cài đặt bằng MSI thất bại, hãy sử dụng hướng dẫn ở đây. 

Bài viết này cũng chỉ cho bạn cách cài đặt Aspose.Slides for Reporting Services trên máy tính có Business Intelligence Development Studio. Điều này sẽ cho phép bạn xuất báo cáo sang định dạng Microsoft PowerPoint khi thiết kế từ Microsoft Visual Studio 2005 hoặc 2008 Report Designer. 

1. Sao chép Aspose.Slides.ReportingServices.dll vào thư mục Visual Studio.

   - Để tích hợp với Visual Studio 2005 Report Designer, sao chép **Aspose.Slides.ReportingServices.dll** vào thư mục **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - Để tích hợp với Visual Studio 2008 Report Designer, sao chép **Aspose.Slides.ReportingServices.dll** vào thư mục **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. Đăng ký Aspose.Slides for Reporting Services như một phần mở rộng render. 

3. Mở **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config** (trong đó <Version> là “8” cho Visual Studio 2005 hoặc “9.0” cho Visual Studio 2008) và thêm các dòng này vào phần tử <Render>: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Cấp quyền thực thi cho Aspose.Slides for Reporting Services. 
   1. Mở **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (trong đó <Version> là “8” cho Visual Studio 2005 hoặc “9.0” cho Visual Studio 2008).
   1. Thêm dòng này vào vị trí cuối cùng của phần tử <CodeGroup> thứ hai từ ngoài (phải là <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) 

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

5. Xác minh rằng Aspose.Slides for Reporting Services đã được cài đặt thành công. 
6. Chạy hoặc khởi động lại Microsoft Visual Studio 2005 hoặc 2008 Report Designer. Bạn sẽ thấy các định dạng mới xuất hiện trong danh sách các định dạng xuất. 

**Các định dạng xuất mới xuất hiện trong Report Designer.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)