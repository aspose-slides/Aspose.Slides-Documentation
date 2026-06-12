---
title: Menginstal Ulang Aspose.Slides for Reporting Services
type: docs
weight: 40
url: /id/reportingservices/re-installing-aspose-slides-for-reporting-services/
---
{{% alert color="primary" %}} 

Artikel ini menjelaskan perbaikan untuk situasi di mana Aspose.Slides for Reporting Services sudah terpasang, tetapi karena alasan tertentu, harus dipasang kembali.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** memerlukan pemasangan **.NET Framework 3.5** pada mesin host. 

{{% /alert %}}

## **Langkah-langkah Menginstal Ulang Aspose.Slides for Reporting Services**
Hal yang paling penting adalah menghapus sepenuhnya instalasi Aspose.Slides for Reporting Services yang sebelumnya. Meskipun penginstal MSI dapat secara otomatis melakukan tindakan yang diperlukan untuk mencopot pemasangan dan, akibatnya, menginstal ulang Aspose.Slides for Reporting Services, langkah-langkah berikut harus diikuti:

1. Copot pemasangan Aspose.Slides for Reporting Services menggunakan penginstal MSI. 

2. Temukan direktori pemasangan Aspose.Slides for Reporting Services yang biasanya berada di:

   **OS Root Drive\Program Files\Aspose\Aspose.Slides for Reporting Services** 

3. Jika penginstal MSI belum menghapus direktori “Aspose.Slides for Reporting Services” saat mencopot pemasangan Aspose.Slides for Reporting Services, hapus folder tersebut. 

4. Temukan berkas biner **Aspose.Slides.ReportingServices.dll** di direktori “bin” setiap instance SQL Server Reporting Service. Sebagai contoh, jika ada instance Microsoft SQL Server 2008 “MSSQLSERVER”, direktori “bin” Reporting Service yang bersangkutan kemungkinan berada di: 

   **OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer\bin** 

5. Jika penginstal MSI belum menghapus berkas biner Aspose.Slides.ReportingServices.dll dari direktori di atas saat mencopot pemasangan Aspose.Slides for Reporting Services, hapus berkas tersebut sekarang.

6. Temukan berkas **rsreportserver.config** untuk setiap instance SSRS. Sebagai contoh, jika ada instance Reporting Service “**MSRS10.MSSQLSERVER**”, berkas **rsreportserver.config** akan berada di direktori ini:

   **MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

7. Buka berkas **rsreportserver.config** dengan editor apa pun dan temukan baris-baris yang dibuat untuk menambahkan PowerPoint Format Extensions selama pemasangan Aspose.Slides for Reporting Services. 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

<Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>



```

**Step** **8:** Jika penginstal MSI belum menghapus baris-baris tersebut saat mencopot pemasangan Aspose.Slides for Reporting Services, hapus baris-baris tersebut dari berkas **rsreportserver.config** sekarang.

**Step** **9:** Temukan berkas **rssrvpolicy.config** untuk setiap instance SSRS. Sebagai contoh, jika ada instance Reporting Service “MSRS10.MSSQLSERVER”, berkas **rssrvpolicy.config** akan berada di direktori ini:

**MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Step** **10:** Buka berkas **rssrvpolicy.config** dengan editor apa pun dan temukan baris-baris yang dibuat untuk memberikan izin eksekusi kepada Aspose.Slides for Reporting Services selama pemasangan Aspose.Slides for Reporting Services. 

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

**Step** **11:** Jika penginstal MSI belum menghapus baris-baris di atas saat mencopot pemasangan produk, hapus baris-baris tersebut dari berkas **rssrvpolicy.config** sekarang. 

**Step** **12:** Jika Aspose.Slides for Reporting Services juga dipasang bersama Microsoft Visual Studio untuk pengembangan laporan RDL dan ekspor ke Format PowerPoint dalam lingkungan Microsoft Visual Studio, berkas biner Aspose.Slides.ReportingServices.dll serta berkas konfigurasi (**rsreportserver.config** dan **rssrvpolicy.config**) untuk Microsoft Visual Studio 2008 seharusnya berada di: 

**OS Root Drive\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies** 

**Step** **13:** Jika penginstal MSI belum menghapus berkas biner **Aspose.Slides.ReportingServices.dll**, hapus berkas tersebut. Selain itu, jika belum memperbarui berkas **rsreportserver.config** dan **rssrvpolicy.config** untuk menghapus PowerPoint Format Extensions dan izin eksekusi kode masing-masing, Anda harus menghapusnya secara manual dengan cara yang sama seperti pada langkah-langkah sebelumnya. 

**Step** **14:** Saatnya menginstal ulang Aspose.Slides for Reporting Services. Gunakan penginstal MSI untuk pemasangan otomatis atau lakukan secara manual.