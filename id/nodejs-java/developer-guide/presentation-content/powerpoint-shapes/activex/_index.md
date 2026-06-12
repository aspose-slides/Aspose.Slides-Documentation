---
title: "Kelola Kontrol ActiveX dalam Presentasi Menggunakan JavaScript"
linktitle: "ActiveX"
type: docs
weight: 80
url: /id/nodejs-java/activex/
keywords:
  - ActiveX
  - kontrol ActiveX
  - mengelola ActiveX
  - menambahkan ActiveX
  - memodifikasi ActiveX
  - pemutar media
  - PowerPoint
  - presentasi
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Pelajari cara Aspose.Slides untuk Node.js via Java memanfaatkan ActiveX untuk mengotomatiskan dan meningkatkan presentasi PowerPoint, memberikan pengembang kontrol yang kuat atas slide."
---
## **Pendahuluan**

Kontrol ActiveX digunakan dalam presentasi. Aspose.Slides untuk Node.js melalui Java memungkinkan Anda menambahkan dan mengelola kontrol ActiveX, tetapi kontrol tersebut agak lebih sulit dikelola dibandingkan dengan shape presentasi biasa. Kami telah menambahkan dukungan untuk menambahkan kontrol Media Player Active di Aspose.Slides. Perlu dicatat bahwa kontrol ActiveX bukan shape; mereka bukan bagian dari [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/) presentasi. Mereka merupakan bagian dari [ControlCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/controlcollection/) terpisah. Pada topik ini, kami akan menunjukkan cara menggunakannya.

## **Menambahkan Kontrol ActiveX Media Player ke Slide**
Untuk menambahkan kontrol Media Player ActiveX, lakukan hal berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) dan hasilkan sebuah presentasi kosong.
1. Akses slide target dalam [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
1. Tambahkan kontrol Media Player ActiveX menggunakan metode [addControl](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) yang disediakan oleh [ControlCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/controlcollection/).
1. Akses kontrol Media Player ActiveX dan tetapkan jalur video dengan menggunakan propertinya.
1. Simpan presentasi sebagai file PPTX.

Contoh kode berikut, berdasarkan langkah‑langkah di atas, menunjukkan cara menambahkan Kontrol Media Player ActiveX ke sebuah slide:

```javascript
// Buat instansi presentasi kosong
var pres = new aspose.slides.Presentation();
try {
    // Menambahkan kontrol ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Akses kontrol ActiveX Media Player dan tetapkan jalur video
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Simpan Presentasi
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengubah Kontrol ActiveX**

Untuk mengelola kontrol ActiveX sederhana seperti kotak teks dan tombol perintah pada slide, lakukan hal berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation) dan muat presentasi yang berisi kontrol ActiveX.
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Akses kontrol ActiveX pada slide dengan mengakses [ControlCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/controlcollection/).
1. Akses kontrol ActiveX TextBox1 menggunakan objek [Control](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/control/).
1. Ubah properti kontrol ActiveX TextBox1 yang meliputi teks, font, tinggi font, dan posisi frame.
1. Akses kontrol akses kedua yang disebut CommandButton1.
1. Ubah caption tombol, font, dan posisinya.
1. Geser posisi frame kontrol ActiveX.
1. Tulis kembali presentasi yang telah dimodifikasi ke file PPTX.

Contoh kode berikut, berdasarkan langkah‑langkah di atas, menunjukkan cara mengelola kontrol ActiveX sederhana:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// Mengakses presentasi dengan kontrol ActiveX
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Mengakses slide pertama dalam presentasi
    var slide = pres.getSlides().get_Item(0);
    // mengubah teks TextBox
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Mengubah gambar substitusi. PowerPoint akan mengganti gambar ini selama aktivasi ActiveX,
        // jadi kadang boleh membiarkan gambar tidak diubah.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Mengubah caption tombol
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Mengubah substitusi
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // memindahkan 100 poin ke bawah
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // menghapus kontrol
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah Aspose.Slides mempertahankan kontrol ActiveX saat membaca dan menyimpan ulang jika kontrol tersebut tidak dapat dijalankan di runtime Python?**

Ya. Aspose.Slides memperlakukan mereka sebagai bagian dari presentasi dan dapat membaca/mengubah properti serta frame mereka; mengeksekusi kontrol itu sendiri tidak diperlukan untuk mempertahankannya.

**Bagaimana perbedaan antara kontrol ActiveX dan objek OLE dalam sebuah presentasi?**

Kontrol ActiveX adalah kontrol interaktif yang dikelola (tombol, kotak teks, pemutar media), sedangkan [OLE](/slides/id/nodejs-java/manage-ole/) mengacu pada objek aplikasi yang disematkan (misalnya, lembar kerja Excel). Mereka disimpan dan diproses secara berbeda serta memiliki model properti yang berbeda.

**Apakah peristiwa ActiveX dan makro VBA berfungsi jika file telah dimodifikasi oleh Aspose.Slides?**

Aspose.Slides mempertahankan markup dan metadata yang ada; namun, peristiwa dan makro hanya dapat dijalankan di PowerPoint pada Windows ketika keamanan mengizinkannya. Perpustakaan tidak mengeksekusi VBA.