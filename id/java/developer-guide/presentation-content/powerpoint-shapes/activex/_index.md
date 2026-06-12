---
title: Kelola Kontrol ActiveX dalam Presentasi Menggunakan Java
linktitle: ActiveX
type: docs
weight: 80
url: /id/java/activex/
keywords:
- ActiveX
- kontrol ActiveX
- kelola ActiveX
- tambahkan ActiveX
- modifikasi ActiveX
- pemutar media
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari bagaimana Aspose.Slides untuk Java memanfaatkan ActiveX untuk mengotomatiskan dan meningkatkan presentasi PowerPoint, memberikan kontrol yang kuat kepada pengembang atas slide."
---
## **Pendahuluan**

Kontrol ActiveX digunakan dalam presentasi. Aspose.Slides untuk Java memungkinkan Anda menambahkan dan mengelola kontrol ActiveX, tetapi kontrol ini sedikit lebih kompleks dibandingkan bentuk presentasi biasa. Kami telah menambahkan dukungan untuk menambahkan kontrol Active Media Player di Aspose.Slides. Perlu dicatat bahwa kontrol ActiveX bukan bentuk; mereka bukan bagian dari [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/) presentasi. Mereka merupakan bagian dari [IControlCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/icontrolcollection/) terpisah. Pada topik ini, kami akan menunjukkan cara bekerja dengan mereka. 

## **Menambahkan Kontrol Media Player ActiveX ke Slide**
Untuk menambahkan kontrol Media Player ActiveX, lakukan hal berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dan buat presentasi kosong.
1. Akses slide target dalam [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
1. Tambahkan kontrol Media Player ActiveX menggunakan metode [addControl](https://reference.aspose.com/slides/id/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) yang disediakan oleh [IControlCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/icontrolcollection/).
1. Akses kontrol Media Player ActiveX dan tetapkan jalur video dengan menggunakan propertinya.
1. Simpan presentasi sebagai file PPTX.

Kode contoh ini, berdasarkan langkah‑langkah di atas, menunjukkan cara menambahkan Media Player ActiveX Control ke slide:

```java
// Buat instance presentasi kosong
Presentation pres = new Presentation();
try {
    // Menambahkan kontrol Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Akses kontrol Media Player ActiveX dan tetapkan jalur video
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Simpan Presentasi
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Memodifikasi Kontrol ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides untuk Java 7.1.0 dan versi yang lebih baru dilengkapi dengan komponen untuk mengelola kontrol ActiveX. Anda dapat mengakses kontrol ActiveX yang sudah ditambahkan dalam presentasi Anda dan memodifikasi atau menghapusnya melalui propertinya.

{{% /alert %}} 

Untuk mengelola kontrol ActiveX sederhana seperti kotak teks dan tombol perintah pada slide, lakukan hal berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dan muat presentasi yang berisi kontrol ActiveX.
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Akses kontrol ActiveX pada slide dengan mengakses [IControlCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/icontrolcollection/).
1. Akses kontrol ActiveX TextBox1 menggunakan objek [IControl](https://reference.aspose.com/slides/id/java/com.aspose.slides/icontrol/).
1. Ubah properti kontrol ActiveX TextBox1 meliputi teks, font, tinggi font, dan posisi bingkai.
1. Akses kontrol kedua yang bernama CommandButton1.
1. Ubah caption tombol, font, dan posisi.
1. Geser posisi bingkai kontrol ActiveX.
1. Tulis presentasi yang telah dimodifikasi ke file PPTX.

Kode contoh ini, berdasarkan langkah‑langkah di atas, menunjukkan cara mengelola kontrol ActiveX sederhana: 

```java
// Mengakses presentasi dengan kontrol ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Mengakses slide pertama dalam presentasi
    ISlide slide = pres.getSlides().get_Item(0);

    // mengubah teks TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Mengubah gambar pengganti. PowerPoint akan mengganti gambar ini saat aktivasi ActiveX,
        // jadi kadang-kadang boleh membiarkan gambar tidak berubah.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Mengubah caption tombol
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Mengubah gambar pengganti
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
                graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
                graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

                graphics.dispose();

                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ImageIO.write(image, "PNG", baos);

                control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
            }

            // memindahkan 100 poin ke bawah
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // menghapus kontrol
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **FAQ**

**Apakah Aspose.Slides mempertahankan kontrol ActiveX saat membaca dan menyimpan ulang meskipun tidak dapat dijalankan di runtime Java?**

Ya. Aspose.Slides memperlakukan mereka sebagai bagian dari presentasi dan dapat membaca/mengubah properti serta bingkai mereka; mengeksekusi kontrol itu sendiri tidak diperlukan untuk mempertahankannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE dalam sebuah presentasi?**

Kontrol ActiveX adalah kontrol interaktif yang dikelola (tombol, kotak teks, pemutar media), sedangkan [OLE](/slides/id/java/manage-ole/) mengacu pada objek aplikasi yang disematkan (misalnya, lembar kerja Excel). Mereka disimpan dan ditangani secara berbeda serta memiliki model properti yang berbeda.

**Apakah peristiwa ActiveX dan makro VBA berfungsi jika file telah dimodifikasi oleh Aspose.Slides?**

Aspose.Slides mempertahankan markup dan metadata yang ada; namun, peristiwa dan makro hanya berjalan di PowerPoint pada Windows ketika keamanan mengizinkannya. Perpustakaan ini tidak mengeksekusi VBA.