---
title: Batasan dan Perbedaan API
type: docs
weight: 100
url: /id/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides untuk Python via Java
- Perbedaan API
- Python
- Java
- JPype
- Batasan JVM
- PowerPoint
description: "Pelajari tentang batasan JVM dan perbedaan API antara Aspose.Slides untuk Java dan Python via Java, termasuk impor, pembersihan sumber daya, dan penanganan file."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java menggunakan JPype untuk mengakses pustaka Java dari Python. Contoh di bawah membandingkan impor paket, pembuatan presentasi, dan penanganan file di dua API.

## **Batasan yang Diketahui**

- **Siklus hidup JVM:** JPype mendukung satu JVM per proses Python. Setelah dimatikan, Anda tidak dapat memulainya kembali dalam proses yang sama. Mulailah sekali dan gunakan kembali untuk operasi presentasi berikutnya.
- **Kompatibilitas arsitektur:** Python dan Java harus memiliki arsitektur yang cocok. Lihat [Persyaratan Sistem](/slides/id/python-java/system-requirements/#python-java-and-jpype-requirements) untuk detailnya.

Lihat [Panduan Pengguna JPype](https://jpype.readthedocs.io/en/latest/userguide.html) untuk detail mengenai pembatasan ini dan interoperabilitas Java.

## **Perbedaan API Publik**

Bandingkan contoh Java dan Python di bawah. Untuk detail anggota Python via Java, lihat [Referensi API](/slides/id/python-java/api-reference/).

### **Impor Perpustakaan**

Java mengimpor kelas dari `com.aspose.slides`. Di Python, impor `asposeslides` sebelum memulai JVM, kemudian impor kelas dari `asposeslides.api` setelah JVM berjalan. Gunakan [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) untuk menghindari memulai JVM yang sudah berjalan.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}

Contoh Python membiarkan JVM tetap berjalan sampai proses Python selesai. Di notebook, gunakan kembali JVM aktif di antara sel. Jika JVM sudah dimatikan, mulailah kembali kernel notebook sebelum menggunakan objek Java lagi.

{{% /alert %}}

### **Buat Presentasi**

Java menggunakan kata kunci `new`; Python memanggil kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) secara langsung. Lepaskan sumber daya presentasi dengan [Presentation.dispose](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#dispose) dalam blok `finally`.

Kedua contoh menyimpan presentasi kosong menggunakan [Presentation.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#save) dan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#pptx).

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Baca File dan Gunakan Konstanta Format**

Java dapat memuat presentasi dari aliran input Java. Di Python, baca file sebagai data biner dan berikan byte yang dihasilkan ke [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#createpresentationfrombytes). Objek file Python bukan aliran input Java.

Contoh di bawah memerlukan `presentation.pptx` yang sudah ada di direktori kerja dan menyimpan salinan sebagai `result.pptx`. Kedua contoh menutup file input dan melepaskan sumber daya presentasi. Contoh Python membaca seluruh file input ke memori.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tanya Jawab**

**Apakah saya harus memulai ulang JVM untuk setiap presentasi?**

Tidak. Biarkan JVM tetap berjalan dan buat serta lepaskan objek presentasi sesuai kebutuhan. Mematikan JVM mencegah operasi Java lebih lanjut dalam proses Python yang sama.

**Bisakah saya membuka presentasi langsung dari jalur file?**

Ya. Konstruktor [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) menerima jalur file. Gunakan bantuan berbasis byte bila data presentasi sudah tersedia sebagai byte Python.

**Haruskah saya mengubah nama konstanta format saat menerjemahkan contoh Java ke Python?**

Tidak. Misalnya, [SaveFormat.Pptx](https://reference.aspose.com/slides/id/python-java/aspose.slides/saveformat/#pptx) menggunakan ejaan dan kapitalisasi yang sama di kedua API.