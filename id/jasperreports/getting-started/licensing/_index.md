---
title: Lisensi
type: docs
weight: 50
url: /id/jasperreports/licensing/
description: "Pelajari apa yang ditambahkan versi evaluasi Aspose.Slides for JasperReports pada file yang diekspor, dan cara menerapkan lisensi di JasperReports serta JasperReports Server."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports tersedia sebagai evaluasi gratis tanpa batas waktu dari [halaman unduhan](https://releases.aspose.com/slides/jasperreport/). Versi evaluasi dan versi berlisensi produk ini diunduh dengan cara yang sama.

Setelah Anda puas dengan evaluasi, [beli lisensi](https://purchase.aspose.com/pricing/slides/jasperreports/). Pastikan Anda memahami dan menyetujui ketentuan berlangganan.

Lisensi dapat diunduh dari halaman pesanan setelah pembayaran selesai. Lisensi berupa file XML teks jelas yang ditandatangani secara digital, berisi informasi seperti nama klien, produk yang dibeli, dan jenis lisensi. Jangan memodifikasi isi file lisensi dengan cara apapun: hal tersebut akan membuat lisensi tidak valid.

Unduh lisensi ke komputer Anda dan salin ke folder yang sesuai (misalnya folder aplikasi Anda atau **JasperReports\lib**).
{{% /alert %}}

## **Batasan Versi Evaluasi**
Versi evaluasi Aspose.Slides for JasperReports (tanpa lisensi yang ditentukan) mengekspor setiap halaman laporan, tetapi menempatkan watermark evaluasi di tengah setiap slide atau halaman, dalam keempat format output (PPT, PPTX, PDF, dan HTML), seperti yang ditunjukkan pada gambar di bawah. Lihat [Evaluate Aspose.Slides](/slides/id/jasperreports/evaluate-aspose-slides/) untuk detail.

![Watermark evaluasi di tengah slide yang diekspor](evaluation_watermark.png)

## **Menerapkan Lisensi**
Ada beberapa cara untuk menerapkan lisensi, tergantung apakah Anda bekerja pada JasperReports atau JasperServer.

### **Menerapkan Lisensi untuk JasperReports**
Panggil metode `setLicense` dari kelas `License` dengan stream yang membaca file lisensi, seperti pada Aspose.Slides for Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Buat objek stream yang berisi file lisensi.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Membuat instance kelas License.
            License license = new License();

            // Atur lisensi melalui objek stream.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Atau, berikan path file lisensi ke exporter dalam parameter `ASExporterParameters.PPT_LICENSE`. Pada fragmen ini, `jasperPrint` adalah laporan yang telah terisi, seperti pada [Your first export](/slides/id/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Menerapkan Lisensi pada JasperServer**
Atur properti `licenseFile` dari bean `pptExportParameters` di *applicationContext.xml* ke path file lisensi, seperti yang ditunjukkan pada [Integration with JasperServer](/slides/id/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).