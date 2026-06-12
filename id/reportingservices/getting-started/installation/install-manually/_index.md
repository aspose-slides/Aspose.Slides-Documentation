---
title: Instalasi Manual
type: docs
weight: 30
url: /id/reportingservices/install-manually/
---
{{% alert color="primary" %}} 
Ikuti langkah-langkah berikut hanya jika Anda berencana menginstal Aspose.Slides for Reporting Services secara manual. Dalam hal ini, Anda telah mengunduh paket ZIP yang berisi file assembly. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 
**Aspose.Slides for Reporting Services** memerlukan instalasi **.NET Framework 3.5** pada mesin host. 
{{% /alert %}}

### **Instalasi Manual**
Instruksi ini menunjukkan cara menyalin dan memodifikasi file di direktori tempat Microsoft SQL Server Reporting Services diinstal:

1. Temukan direktori instalasi Report Server.  
   Direktori root untuk Microsoft SQL Server biasanya berada di: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   **Microsoft SQL Server 2005 dan 2008**: Mungkin ada beberapa instance Microsoft SQL Server yang dikonfigurasi pada mesin dan mereka dapat berada di subdirektori MSSQL.x yang berbeda seperti MSSQL.1, MSSQL.2, dan seterusnya. Anda harus menemukan direktori ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** yang tepat sebelum melanjutkan ke langkah berikutnya.  
   {{% /alert %}} Semua jalur yang digunakan di bawah ini akan merujuk ke direktori ini sebagai <Instance>. 

2. Salin Aspose.Slides.ReportingServices.dll ke folder **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.  
   Unduhan **Aspose.Slides.ReportingServices.zip** berisi **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

   Dalam beberapa kasus, saat Anda menyalin DLL ke direktori **ReportServer\bin**, DLL tersebut mungkin ikut menyalin bersama izin file NTFS yang secara eksplisit ditetapkan. Izin NTFS tersebut menyebabkan Microsoft SQL Server Reporting Services ditolak aksesnya saat memuat **Aspose.Slides.ReportingServices.dll**. Jika hal ini terjadi, format ekspor baru tidak akan tersedia. Periksa dan pastikan bahwa izin NTFS yang benar sudah diterapkan:
   
   1. Klik kanan **Aspose.Slides.ReportingServices.dll**.  
   1. Pilih **Properties** dan buka tab **Security**.  
   1. Hapus semua izin NTFS yang ditetapkan secara eksplisit dan pertahankan hanya izin yang diwariskan.  
   {{% /alert %}}

3. Daftarkan Aspose.Slides for Reporting Services sebagai ekstensi rendering:  
   1. Buka *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.  
   1. Tambahkan baris-baris berikut ke elemen <Render>:  

**<Render>**

``` xml

   ...

  <!--Mulai di sini.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Selesai di sini.-->

</Render>



```

4. Berikan Aspose.Slides for Reporting Services izin untuk dijalankan:  
   1. Buka **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.  
   1. Tambahkan yang berikut sebagai item terakhir dalam elemen <CodeGroup> kedua dari luar (yang seharusnya adalah <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">) .  

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

    <!--Selesai di sini.-->

  </CodeGroup>

</CodeGroup>



```

5. Verifikasi bahwa Aspose.Slides for Reporting Services telah terinstal dengan sukses:  
   1. Buka Report Manager dan periksa daftar tipe ekspor yang tersedia untuk sebuah laporan.  

   {{% alert color="primary" %}} Anda dapat membuka Report Manager dengan membuka browser (Microsoft Internet Explorer 6.0 atau yang lebih baru) dan mengetik URL Report Manager di bilah alamat (secara default adalah http://< ComputerName >/Reports ).  
   {{% /alert %}}

1. Pilih sebuah laporan di server.  
1. Buka daftar **Select Format**.  
   Anda harus melihat daftar format ekspor yang disediakan oleh Aspose.Slides for Reporting Services.  
1. Pilih **PPT – PowerPoint Presentation via Aspose.Slides**.  

   **Aspose.Slides for Reporting Services berhasil diinstal dan format ekspor baru tersedia**.  

![todo:image_alt_text](install-manually_1.png)

6. Klik tautan **Export**.  
   Laporan dihasilkan dalam format yang dipilih, dikirim ke klien, dan kemudian dibuka dalam aplikasi yang sesuai. Dalam kasus kami, laporan dibuka di Microsoft PowerPoint.  

   **Laporan PPT yang dihasilkan oleh Aspose.Slides for Reporting Services.**  

![todo:image_alt_text](install-manually_2.png)

Anda telah berhasil menginstal Aspose.Slides for Reporting Services dan menghasilkan laporan sebagai presentasi Microsoft PowerPoint!