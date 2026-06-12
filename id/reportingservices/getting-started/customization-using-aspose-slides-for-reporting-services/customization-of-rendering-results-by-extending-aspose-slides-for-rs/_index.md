---
title: Kustomisasi Hasil Rendering dengan Memperluas Aspose.Slides untuk RS
type: docs
weight: 10
url: /id/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/
---
{{% alert color="primary" %}} 

Halaman ini menjelaskan cara membuat ekstensi untuk Aspose.Slides for RS.

- [Buat Assembly Ekstensi](/slides/id/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).
- [Mengintegrasikan Ekstensi](/slides/id/reportingservices/customization-of-rendering-results-by-extending-aspose-slides-for-rs/).

{{% /alert %}} 

Fitur Custom Extension memberi Anda opsi untuk menambahkan elemen tambahan atau memperbarui elemen yang ada selama ekspor laporan.
## **Cara Membuat Assembly Ekstensi**
1. Buat proyek .NET dan tambahkan referensi ke Aspose.Slides.ReportingServices.dll.
2. Tambahkan sebuah kelas dan wariskan dari Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase.
3. Timpa metode virtual kelas untuk menambahkan fungsionalitas khusus.
### **Contoh**
Misalkan kita ingin menambahkan catatan dengan teks tertentu, sebuah logo, dan memperbarui nama perusahaan untuk setiap laporan yang diekspor dengan Aspose.Slides untuk RS.

Untuk tujuan itu, kita menambahkan kelas berikut:

``` xml

 public class DemoRenderingExtension : Aspose.Slides.ReportingServices.Extension.RenderingExtensionBase

{

public override void PostProcessSlide(Aspose.Slides.ReportingServices.Extension.Slide slide)

{

//Tambahkan catatan ke slide pertama

if (this.CurrentSlideIndex == 0)

{

TextFormat textFormat = new TextFormat("Arial", 25);

textFormat.Bold = true;

slide.AddNote("This is the demo of Rendering Extension for Aspose.Slides for ReportingServices",

textFormat);

}

//Tampilkan logo pada setiap slide di pojok kanan bawah

using (Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TestSlidesRenderingExtension.aspose.slides-for-ssrs-logo.jpg"))

{

slide.AddImage(imageStream, new RectangleF(slide.Size.Width - 20, slide.Size.Height - 20, 15, 15));

}

base.PostProcessSlide(slide);

}


public override void PostProcessTextBox(Aspose.Slides.ReportingServices.Extension.TextBox textBox)

{

//Tambahkan (TM) pada setiap penyebutan nama perusahaan dalam laporan

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

Bangun itu dan Anda akan mendapatkan assembly ekstensi. Kami siap mengintegrasikan ekstensi.

{{% /alert %}} 

[Proyek Visual Studio RenderingExtensionDemo.zip](attachments/10289195/10452998.zip)
### **Mengintegrasikan Ekstensi**
Misalkan assembly Anda bernama **TestSlidesRenderingExtension.dll**:

- Salin assembly ke direktori **bin** ReportingService di samping Aspose.Slides.ReportingServices.dll. (Contoh: c:\Program Files\Microsoft SQL Server\MSRS10_50\Reporting Services\ReportServer\bin)
- Berikan izin FullTrust ke assembly Anda dengan menambahkan CodeGroup berikut ke **rssrvpolicy.config**:

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

Perbarui bagian konfigurasi ekstensi rendering Aspose.Slides di **rsreportserver.config** untuk menyertakan ekstensi Anda.

``` xml

 <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices">

<Configuration>

<Extension>TestSlidesRenderingExtension.DemoRenderingExtension, TestSlidesRenderingExtension</Extension>

</Configuration>

</Extension>

```

Jika Anda ingin menggunakan ekstensi untuk setiap tipe output yang didukung oleh Aspose.Slides, tambahkan konfigurasi yang sama ke ekstensi dengan nama ASPPTX, ASPPT, ASPPS, ASPPSX.
Isi tag Extension adalah nama tipe yang qualified secara assembly. (Lihat <https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname>)

Sekarang restart Reporting Services dan ekspor laporan. Anda akan mendapatkan sesuatu seperti [presentasi ini](attachments/10289195/10452997.pptx) dari laporan Company Sales SQL2008R2 sampel Adventureworks.