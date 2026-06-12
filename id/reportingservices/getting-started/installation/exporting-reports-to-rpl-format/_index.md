---
title: Mengekspor Laporan ke Format RPL
type: docs
weight: 110
url: /id/reportingservices/exporting-reports-to-rpl-format/
---
  

{{% alert color="primary" %}} 
Aspose.Slides menggunakan laporan dalam format RPL (Report Processing Language) untuk rendering. Halaman ini menunjukkan cara mengekspor laporan ke Format RPL.
{{% /alert %}} 

Dalam banyak skenario, pelanggan harus membagikan laporan yang berisi masalah untuk diselesaikan dengan staf Aspose. Ketika laporan yang dibagikan berada dalam format RDL, set data atau skema juga dibagikan agar kami dapat mereproduksi masalah tersebut. Kadang‑kadang, bahkan pembagian laporan RDL beserta set datanya tidak cukup untuk menyelesaikan masalah secara lengkap. Dalam kasus seperti itu, kami menyarankan Anda mengekspor laporan dalam format RPL dan membagikan file RPL kepada kami. File RPL juga mencakup set data yang digunakan. Dengan cara ini, proses ekspor ke RPL menjadi lebih mudah dan dapat langsung dibagikan kepada kami.

Lakukan langkah‑langkah berikut:

1. Salin Aspose.ReportingServices.Debug.Rpl.dll ke direktori bin Reporting Services (biasanya di c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 
Aspose.ReportingServices.Debug.Rpl.dll tersedia pada versi terbaru Aspose.Slides untuk Reporting Services, yang dapat diunduh dari [Halaman Rilis](https://releases.aspose.com/slides/id/reportingservices/).
{{% /alert %}} 

2. Tambahkan ekstensi ini ke tag **<Render>** pada file **rsreportserver.config** (biasanya di c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Tambahkan tag ini ke elemen <Render>



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Tentukan jalur ke file RPL yang dihasilkan dengan memodifikasi elemen path.

4. Berikan Aspose.ReportingServices.Debug.Rpl.dll izin untuk dieksekusi dengan cara berikut: buka C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config dan tambahkan ini sebagai item terakhir di elemen **<CodeGroup>** kedua dari luar (yang seharusnya **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">** ) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Mulai di sini.-->

				<CodeGroup class="UnionCodeGroup"
					version="1"
					PermissionSetName="FullTrust"
					Name="Aspose.Rpl_Debug_for_Reporting_Services"
					Description="Code group for my Aspose.Rpl.Debug rendering extension">
			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />
				</CodeGroup>

    <!--Selesai di sini.-->
  </CodeGroup>
</CodeGroup>


```

5. Mulai ulang Reporting Services. Anda seharusnya menemukan opsi Aspose.Rpl di menu Ekspor.

Opsi "Rpl export" akan muncul di panel ekspor. Anda perlu mengekspor laporan ke RPL dan membagikan file RPL.