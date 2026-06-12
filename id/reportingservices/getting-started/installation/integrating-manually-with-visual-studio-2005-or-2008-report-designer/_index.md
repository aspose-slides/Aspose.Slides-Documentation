---
title: Mengintegrasikan Secara Manual dengan Visual Studio 2005 atau 2008 Report Designer
type: docs
weight: 50
url: /id/reportingservices/integrating-manually-with-visual-studio-2005-or-2008-report-designer/
---
{{% alert color="primary" %}} 

Artikel ini mengajarkan Anda cara mengintegrasikan Aspose.Slides for Reporting Services secara manual dengan Visual Studio. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** memerlukan instalasi **.NET Framework 3.5** pada mesin host. 

{{% /alert %}}

## **Mengintegrasikan Aspose.Slides for Reporting Services dengan Visual Studio**
Kami menyarankan Anda menggunakan installer MSI untuk menginstal Aspose.Slides for Reporting Services karena secara otomatis melakukan semua tugas instalasi dan proses konfigurasi yang diperlukan. Namun, jika instalasi dengan installer MSI gagal, gunakan panduan di sini. 

Artikel ini juga menunjukkan cara menginstal Aspose.Slides for Reporting Services pada komputer dengan Business Intelligence Development Studio. Hal ini memungkinkan Anda mengekspor laporan ke format Microsoft PowerPoint pada waktu desain dari Microsoft Visual Studio 2005 atau 2008 Report Designer. 

1. Salin Aspose.Slides.ReportingServices.dll ke direktori Visual Studio.

   - Untuk mengintegrasikan dengan Visual Studio 2005 Report Designer, salin **Aspose.Slides.ReportingServices.dll** ke direktori **C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies**.
   - Untuk mengintegrasikan dengan Visual Studio 2008 Report Designer, salin **Aspose.Slides.ReportingServices.dll** ke direktori **C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies**.
2. Daftarkan Aspose.Slides for Reporting Services sebagai ekstensi rendering. 

3. Buka **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\ RSReportDesigner.config** (di mana <Version> adalah “8” untuk Visual Studio 2005 atau “9.0” untuk Visual Studio 2008) dan tambahkan baris-baris ini ke dalam elemen <Render>: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

4. Berikan Aspose.Slides for Reporting Services izin untuk dieksekusi. 
   1. Buka **C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSPreviewPolicy.config** (di mana <Version> adalah “8” untuk Visual Studio 2005 atau “9.0” untuk Visual Studio 2008).
   1. Tambahkan baris ini sebagai item terakhir di elemen <CodeGroup> kedua hingga luar (yang harus berupa <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission.">) 

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Mulai di sini.-->

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

    <!--Akhiri di sini.-->

  </CodeGroup>

</CodeGroup>



```

5. Verifikasi bahwa Aspose.Slides for Reporting Services telah berhasil diinstal. 
6. Jalankan atau restart Microsoft Visual Studio 2005 atau 2008 Report Designer. Anda akan melihat format baru dalam daftar format ekspor.

**Format ekspor baru muncul di Report Designer.** 

![todo:image_alt_text](integrating-manually-with-visual-studio-2005-or-2008-report-designer_1.png)