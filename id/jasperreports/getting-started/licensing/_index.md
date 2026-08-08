---
title: Lisensi
type: docs
weight: 50
url: /id/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides untuk JasperReports tersedia sebagai evaluasi gratis tanpa batas waktu dari [halaman unduhan](https://downloads.aspose.com/slides/id/jasperreport). Versi evaluasi dan versi berlisensi produk adalah unduhan yang sama.

Ketika Anda puas dengan evaluasi, [beli lisensi](https://purchase.aspose.com/buy). Pastikan Anda memahami dan menyetujui ketentuan berlangganan.

Lisensi tersedia untuk diunduh dari halaman pesanan setelah pesanan dibayar. Lisensi adalah file XML teks jelas yang ditandatangani secara digital dan berisi informasi seperti nama klien, produk yang dibeli, dan jenis lisensi. Jangan memodifikasi isi file lisensi dengan cara apapun: melakukannya akan membuat lisensi tidak valid.

Unduh lisensi ke komputer Anda dan salin ke folder yang sesuai (misalnya folder aplikasi Anda atau **JasperReports\lib**).
{{% /alert %}}

## **Batasan Versi Evaluasi**
Versi evaluasi Aspose.Slides (tanpa lisensi yang ditentukan) menyediakan fungsi lengkap produk, tetapi (ketika Anda menyimpan presentasi) ia menambahkan watermark evaluasi di tengah setiap slide seperti yang ditunjukkan pada gambar di bawah:

![todo:image_alt_text](evaluation_watermark.png) 

## **Menerapkan Lisensi**
Ada beberapa cara untuk menerapkan lisensi, tergantung apakah Anda bekerja pada JasperReports, atau JasperServer.

### **Menerapkan Lisensi untuk JasperReports**
Gunakan pemanggilan metode setLicense secara langsung yang mirip dengan Aspose.Slides untuk Java.

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

Atau, atur parameter exporter dalam kode.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Menerapkan Lisensi pada JasperServer**
Atur parameter exporter di applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```