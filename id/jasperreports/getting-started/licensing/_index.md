---
title: Lisensi
type: docs
weight: 50
url: /id/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides untuk JasperReports tersedia sebagai evaluasi gratis tanpa batas waktu dari [download page](https://downloads.aspose.com/slides/id/jasperreport). Versi evaluasi dan versi berlisensi produk merupakan unduhan yang sama.

Jika Anda puas dengan evaluasi, [buy a license](https://purchase.aspose.com/buy). Pastikan Anda memahami dan menyetujui syarat berlangganan.

Lisensi dapat diunduh dari halaman pesanan setelah pembayaran selesai. Lisensi berupa file XML teks jelas yang ditandatangani secara digital dan berisi informasi seperti nama klien, produk yang dibeli, dan tipe lisensi. Jangan memodifikasi konten file lisensi dengan cara apapun: hal tersebut akan membuat lisensi tidak berlaku.

Unduh lisensi ke komputer Anda dan salin ke folder yang tepat (misalnya folder aplikasi Anda atau **JasperReports\lib**).
{{% /alert %}}

## **Batasan Versi Evaluasi**
Versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan semua fungsi produk, tetapi (saat Anda menyimpan presentasi) akan menyisipkan watermark evaluasi di tengah setiap slide seperti yang ditampilkan pada gambar di bawah:

![todo:image_alt_text](evaluation_watermark.png) 

## **Menerapkan Lisensi**
Ada beberapa cara untuk menerapkan lisensi, tergantung apakah Anda bekerja pada JasperReports atau JasperServer.

### **Menerapkan Lisensi untuk JasperReports**
Gunakan pemanggilan metode setLicense langsung seperti Aspose.Slides untuk Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Buat objek stream yang berisi file lisensi
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Instansiasi kelas License
    License license = new License();
	
    //Setel lisensi melalui objek stream
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Atau, tetapkan parameter exporter dalam kode.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Menerapkan Lisensi pada JasperServer**
Tetapkan parameter exporter di applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```