---
title: Pertanyaan yang Sering Diajukan
type: docs
weight: 110
url: /id/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

Halaman ini mengumpulkan sejumlah pertanyaan yang sering diajukan tentang:

- [Format file yang didukung](#Supported-File-Formats).
- [Dukungan untuk layanan Pelaporan Power BI](#Support-for-Power-BI-Reporting-services).
- [Instalasi](#Installation).
- [Konfigurasi Ekspor](#Export-Configuration).

{{% /alert %}} 
### **Format File yang Didukung**
#### **Q: Format apa yang dapat Anda ekspor laporan menggunakan Aspose.Slides for Reporting Services?**
**A**: Aspose.Slides for Reporting Services memungkinkan ekspor laporan apa pun ke format PPT, PPS, PPTX, PPSX, XPS, atau RPL.
### **Dukungan untuk layanan Pelaporan Power BI**
#### **Q: Apakah Aspose.Slides for Reporting Services mendukung Power BI?**
**A**: Ya. Aspose.Slides for Reporting Services mendukung pengeksporan laporan terpaginasikan (RDL) di Power BI.
### **Instalasi**
#### **Q: Program instalasi tidak berjalan. Instalasi manual tidak menghasilkan hasil yang diinginkan.**
**A**: Pastikan .NET Framework 3.5 terinstal di sistem Anda.
#### **Q: Opsi ekspor tidak muncul setelah instalasi Aspose.Slides for Reporting Services.**
**A**: Jika ada CodeGroup di rssrvpolicy.config yang tidak berfungsi dengan benar, parser file konfigurasi dapat melewatkan bagian terakhir dari grup tersebut. Jadi pindahkan semua CodeGroup yang terkait dengan Aspose.Slides for Reporting Services ke bagian atas blok yang berisi CodeGroup Aspose.Slides for Reporting Services.
#### **Q: Tidak dapat memuat file atau assembly Aspose.Slides.ReportingServices (Izin eksekusi tidak dapat diperoleh \ Exception dari HRESULT: 0x80131418).**
**A**: Kode kesalahan (0x80131418) menunjukkan bahwa modul dll tidak memiliki hak yang cukup. Ini mungkin disebabkan oleh fitur keamanan yang memblokir akses penuh ke file .dll jika diperoleh dari komputer lain. Hal ini dapat diperbaiki dengan membuka jendela properti file dll dan mengklik tombol "Unblock" di panel "Security".
#### **Q: Tidak dapat menemukan lisensi 'Aspose.Slides.Reporting.Services.lic'.**
**A**: File lisensi harus berada di sebelah dll atau di direktori Program Files(x86)\Aspose\Slides\.
### **Konfigurasi Ekspor**
#### **Q: Bagaimana cara mengubah warna hyperlink dalam laporan yang diekspor?**
**A**: Setiap ekstensi rendering Aspose.Slides for Reporting Services di rsreportserver.config memiliki konfigurasi masing‑masing. Untuk mengubah warna hyperlink, setel nilai yang diperlukan di bagian <HyperlinkColor>.
#### **Q: Dalam presentasi yang diekspor, teks dalam tabel terdistorsi secara vertikal.**
**A**: Hal ini dilakukan agar dokumen lebih mudah dibaca. Untuk menampilkan teks dalam tabel sebagaimana muncul di laporan, setel ekstensi Aspose.Slides for Reporting Services yang diperlukan menjadi "Normal" di file konfigurasi rsreportserver.config.