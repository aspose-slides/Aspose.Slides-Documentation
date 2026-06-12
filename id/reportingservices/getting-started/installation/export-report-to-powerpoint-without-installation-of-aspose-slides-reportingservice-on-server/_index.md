---
title: Ekspor laporan ke PowerPoint tanpa instalasi Aspose.Slides.ReportingService di server
type: docs
weight: 120
url: /id/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Service dapat digunakan tanpa instalasi di server. Pendekatan ini cocok ketika Anda perlu mengintegrasikan ekspor ke PowerPoint dalam aplikasi Anda tetapi akses ke layanan dibatasi.

{{% /alert %}} {{% alert color="primary" %}} 

Solusi Visual Studio yang menggambarkan pendekatan ini dapat ditemukan [di sini](attachments/10289165/10453062.zip).

{{% /alert %}} 

Proses rendering terdiri dari dua bagian:

1. Render laporan ke RPL menggunakan Reporting Service Web Service. Lihat informasi lebih lanjut tentang Reporting Service Web Service [di sini](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. Render RPL ke PowerPoint menggunakan Aspose.Slides for Reporting service untuk ReportViewer. Assembly berada di {Aspose.Slides for Reporting Services home directory}\bin\RV2010  
## **Cara Mengimplementasikan Ekspor ke PowerPoint:**
 1) Buat proxy layanan web (lihat detailnya [di sini](http://technet.microsoft.com/en-us/library/ms155134.aspx)) dan tambahkan ke solusi Anda.

 2) Tambahkan referensi ke Aspose.Slides.ReportingServices.dll untuk ReportViewer 2010.

 3) Gunakan kelas ini untuk mengintegrasikan proxy layanan web dan Aspose.Slides for Reporting Service

``` xml

 class PowerpointRenderer

{

/// <summary>

/// Mendapatkan atau mengatur URL dasar layanan Web XML yang diminta klien.

/// </summary>

/// <value>

/// URL dasar layanan Web XML yang diminta klien. Defaultnya adalah System.String.Empty.

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// Mendapatkan atau mengatur nama pengguna untuk Reporting Service.

/// </summary>

/// <value>

/// Nama pengguna.

/// </value>

public string Username { get; set; }

/// <summary>

/// Mendapatkan atau mengatur kata sandi untuk Reporting Service.

/// </summary>

/// <value>

/// Kata sandi.

/// </value>

public string Password { get; set; }

/// <summary>

/// Menyusun (render) laporan yang ditentukan ke file.

/// </summary>

/// <param name="outputFileName">Nama file output.</param>

/// <param name="reportPath">Jalur laporan.</param>

/// <param name="format">Format presentasi output.</param>

public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//memulai proses rendering

//di sini kami memilih untuk mengekspor dalam format PPT dan menyediakan outputStream

renderer.StartRendering(format, false);

int page = 1;

//siklus ini mengiterasi semua halaman laporan

while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//jika rplStream kosong maka kami telah mencapai akhir laporan

if (rplStream.Length == 0)

break;

//tambahkan halaman laporan sebagai slide ke dokumen

renderer.RenderPage(rplStream);

}

page++;

}

//panggil metode finish untuk mengirim presentasi yang baru dibuat ke output stream

renderer.FinishRendering(pptSteam);

}

}

private MemoryStream CreateRplStream(int page, string reportPath)

{

ReportExecutionService _executionService = new ReportExecutionService();

_executionService.Url = ReportingServiceUrl + "/ReportExecution2005.asmx";

_executionService.Credentials = new System.Net.NetworkCredential(Username, Password, string.Empty);

string extension;

Warning[] warnings;

string[] streamIds;

string mimeType;

string encoding;

var executionInfo = _executionService.LoadReport(reportPath, null);

string deviceInfo = String.Format(

@"<DeviceInfo>

<StartPage>{0}</StartPage>

<EndPage>{0}</EndPage>

<SecondaryStreams>Embedded</SecondaryStreams>

</DeviceInfo>", page);

byte[] result = _executionService.Render("RPL", deviceInfo, out extension, out mimeType, out encoding, out warnings, out streamIds);

return new MemoryStream(result);

}

}
```

 4) Sekarang Anda dapat mengekspor laporan melalui kode berikut:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

Proses ekspor di sini menggunakan pemisah halaman lunak serupa dengan Word atau Excel, sehingga hasilnya mungkin berbeda dari Presentasi yang diekspor menggunakan pendekatan standar.

{{% /alert %}}