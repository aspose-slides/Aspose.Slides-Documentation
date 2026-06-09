---
title: Aspose.Slides for RS'yi Genişleterek Görüntüleme Sonuçlarını Özelleştirme
type: docs
weight: 10
url: /tr/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for RS için eklenti oluşturmayı açıklar.

- [Eklenti Derlemesi Oluşturma](/slides/tr/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Eklentiyi Entegre Etme](/slides/tr/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

Özel Eklenti özelliği, rapor dışa aktarımı sırasında ek öğeler ekleme veya mevcut öğeleri güncelleme seçeneği sunar.
## **Eklenti Derlemesi Nasıl Oluşturulur**
1. Bir .NET projesi oluşturun ve Aspose.Slides.ReportingServices.dll'ye referans ekleyin.
1. Bir sınıf ekleyin ve Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase sınıfından miras alın.
1. Özel işlevsellik eklemek için sınıfın sanal yöntemlerini geçersiz kılın.
### **Örnek**
Aspose.Slides for RS ile dışa aktarılan her rapor için bir not, bir logo eklemek ve şirket adını güncellemek istediğimizi varsayalım.

Bu amaçla aşağıdaki sınıfı ekliyoruz:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//İlk slayta not ekle

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Her slaytın sağ alt köşesinde logoyu göster

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Rapor içindeki şirket adı geçişlerine (TM) ekle

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

Derleyin ve eklenti derlemesini elde edin. Eklentiyi entegre etmeye hazırız.

{{% /alert %}} 

[RenderingExtensionDemo.zip'in Visual Studio projesi](attachments/10289195/10452998.zip)
### **Eklentiyi Entegre Etme**
**TestSlidesRenderingExtension.dll** adlı derlemenizin olduğunu varsayalım:

- Derlemeyi Aspose.Slides.ReportingServices.dll'nin yanındaki Reporting Service **bin** dizinine kopyalayın. (Örneğin: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Aşağıdaki CodeGroup'u **rssrvpolicy.config** dosyasına ekleyerek derlemenize FullTrust izni verin:

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

**rsreportserver.config** dosyasının Aspose.Slides render eklentisi yapılandırma bölümlerini, eklentinizi içerecek şekilde güncelleyin.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Eğer eklentiyi Aspose.Slides tarafından desteklenen tüm çıktı tiplerinde kullanmak istiyorsanız, aynı yapılandırmayı ASPPTX, ASPPT, ASPPS, ASPPSX adındaki uzantılara ekleyin.  
Extension etiketinin içeriği, tipin derleme nitelikli adıdır. (Bkz <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Şimdi Reporting Services'i yeniden başlatın ve raporu dışa aktarın. Adventureworks örneklerinden Company Sales SQL2008R2 raporundan [bu sunum](attachments/10289195/10452997.pptx) elde edersiniz.