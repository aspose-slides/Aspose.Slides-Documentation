---
title: Tùy chỉnh Kết quả Render bằng cách Mở rộng Aspose.Slides cho RS
type: docs
weight: 10
url: /vi/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 

Trang này mô tả cách tạo phần mở rộng cho Aspose.Slides for RS.

- [Tạo một Assembly Mở rộng](/slides/vi/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Tích hợp Phần mở rộng](/slides/vi/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

Tính năng Custom Extension cho phép bạn thêm các phần tử bổ sung hoặc cập nhật các phần tử hiện có khi xuất báo cáo.
## **Cách Tạo Assembly Mở rộng**
1. Tạo một dự án .NET và thêm tham chiếu đến Aspose.Slides.ReportingServices.dll.
1. Thêm một lớp và kế thừa nó từ Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
1. Ghi đè các phương thức ảo của lớp để thêm chức năng tùy chỉnh.
### **Ví dụ**
Giả sử chúng ta muốn thêm một ghi chú với một số văn bản, một logo và cập nhật tên công ty cho mỗi báo cáo được xuất bằng Aspose.Slides for RS.

Để mục đích đó, chúng ta thêm lớp sau:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Thêm ghi chú vào slide đầu tiên

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Hiển thị logo trên mỗi slide ở góc dưới bên phải

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Thêm (TM) vào mọi lần đề cập đến tên công ty trong báo cáo

string companyName = "Adventure Works";

if (textBox.Text.Contains(companyName))

{

textBox.Text = textBox.Text.Replace(companyName, companyName + "™");

}

base.PostProcessTextBox(textBox);

}

}
```

{{% alert color="primary" %}} 

Biên dịch nó và bạn sẽ nhận được assembly mở rộng. Chúng tôi đã sẵn sàng tích hợp phần mở rộng.

{{% /alert %}} 

[Dự án Visual Studio của RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Tích hợp Phần mở rộng**
Giả sử assembly của bạn được đặt tên là **TestSlidesRenderingExtension.dll**:

- Sao chép assembly vào thư mục **bin** của ReportingService bên cạnh Aspose.Slides.ReportingServices.dll. (Ví dụ: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Cấp quyền FullTrust cho assembly của bạn bằng cách thêm CodeGroup sau vào **rssrvpolicy.config**:

``` xml

 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Nothing">

<IMembershipCondition class="AllMembershipCondition" version="1" />

...

<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">

<IMembershipCondition class="ZoneMembershipCondition" version="1" Zone="MyComputer" />

...

<CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_Extension" Description="This code group grants full trust to the Aspose.Slides for Reporting Services Rendering extension.">

<IMembershipCondition	class="UrlMembershipCondition"	version="1" Url="c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin\TestSlidesRenderingExtension.dll" />

</CodeGroup>

</CodeGroup>

</CodeGroup>

```

Cập nhật các phần cấu hình phần mở rộng rendering của Aspose.Slides trong **rsreportserver.config** để bao gồm phần mở rộng của bạn.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Nếu bạn muốn sử dụng phần mở rộng cho mọi loại đầu ra mà Aspose.Slides hỗ trợ, hãy thêm cấu hình tương tự vào các phần mở rộng có tên ASPPTX, ASPPT, ASPPS, ASPPSX.
Nội dung của thẻ Extension là tên loại có định danh đầy đủ của assembly. (Xem <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Bây giờ khởi động lại Reporting Services và xuất báo cáo. Bạn sẽ nhận được một thứ gì đó giống như [bản trình chiếu này](attachments/10289195/10452997.pptx) từ báo cáo Company Sales SQL2008R2 của các mẫu Adventureworks.