---
title: "Kelola Kontrol ActiveX dalam Presentasi Menggunakan Java"
linktitle: "ActiveX"
type: docs
weight: 80
url: /id/java/activex/
keywords:
- ActiveX
- kontrol ActiveX
- mengelola ActiveX
- menambahkan ActiveX
- memodifikasi ActiveX
- pemutar media
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari bagaimana Aspose.Slides for Java memanfaatkan ActiveX untuk mengotomatiskan dan meningkatkan presentasi PowerPoint, memberi pengembang kontrol kuat atas slide."
---
## **Introduction**

Kontrol ActiveX digunakan dalam presentasi. Aspose.Slides for Java memungkinkan Anda menambahkan dan mengelola kontrol ActiveX, tetapi kontrol tersebut sedikit lebih sulit dikelola dibandingkan bentuk presentasi normal. Kami telah mengimplementasikan dukungan untuk menambahkan kontrol Media Player Active di Aspose.Slides. Perlu diketahui bahwa kontrol ActiveX bukan bentuk; mereka tidak termasuk dalam [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/). Mereka termasuk dalam [IControlCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/icontrolcollection/) yang terpisah. Pada topik ini, kami akan menunjukkan cara bekerja dengan mereka. 

## **Add a Media Player ActiveX Control to a Slide**
Untuk menambahkan kontrol Media Player ActiveX, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dan hasilkan sebuah presentasi kosong.
2. Akses slide target dalam [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
3. Tambahkan kontrol Media Player ActiveX menggunakan metode [addControl](https://reference.aspose.com/slides/id/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) yang disediakan oleh [IControlCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/icontrolcollection/).
4. Akses kontrol Media Player ActiveX dan atur jalur video dengan menggunakan propertinya.
5. Simpan presentasi sebagai file PPTX.

Kode contoh ini, berdasarkan langkah-langkah di atas, menunjukkan cara menambahkan Kontrol ActiveX Media Player ke slide:

```java
import com.aspose.slides.*;

// Buat instance presentasi kosong
Presentation pres = new Presentation();
try {
    // Menambahkan kontrol ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Akses kontrol ActiveX Media Player dan atur jalur video
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Simpan Presentasi
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modify an ActiveX Control**
{{% alert color="info" %}} 

Aspose.Slides for Java 7.1.0 dan versi yang lebih baru dilengkapi dengan komponen untuk mengelola kontrol ActiveX. Anda dapat mengakses kontrol ActiveX yang sudah ditambahkan dalam presentasi Anda dan memodifikasi atau menghapusnya melalui propertinya.

{{% /alert %}} 

Untuk mengelola kontrol ActiveX sederhana seperti kotak teks dan tombol perintah pada slide, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dan muat presentasi yang berisi kontrol ActiveX.
2. Dapatkan referensi slide berdasarkan indeksnya.
3. Akses kontrol ActiveX dalam slide dengan mengakses [IControlCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/icontrolcollection/).
4. Akses kontrol ActiveX TextBox1 menggunakan objek [IControl](https://reference.aspose.com/slides/id/java/com.aspose.slides/icontrol/).
5. Ubah properti kontrol ActiveX TextBox1 yang meliputi teks, font, tinggi font, dan posisi bingkai.
6. Akses kontrol akses kedua yang disebut CommandButton1.
7. Ubah caption tombol, font, dan posisi.
8. Pindahkan posisi bingkai kontrol ActiveX.
9. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

Kode contoh ini, berdasarkan langkah-langkah di atas, menunjukkan cara mengelola kontrol ActiveX sederhana: 

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

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

        // Mengubah gambar substitusi. PowerPoint akan mengganti gambar ini selama aktivasi ActiveX,
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

    // Mengubah caption Tombol
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Mengubah substitusi
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

            // memindahkan ke bawah 100 poin
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

### Does Aspose.Slides preserve ActiveX controls when reading and re-saving if they cannot be executed in the Java runtime?
Ya. Aspose.Slides memperlakukan mereka sebagai bagian dari presentasi dan dapat membaca/mengubah properti serta bingkai mereka; mengeksekusi kontrol itu sendiri tidak diperlukan untuk mempertahankannya.

### How do ActiveX controls differ from OLE objects in a presentation?
Kontrol ActiveX adalah kontrol yang dikelola secara interaktif (tombol, kotak teks, pemutar media), sedangkan [OLE](/slides/id/java/manage-ole/) mengacu pada objek aplikasi tersemat (misalnya, lembar kerja Excel). Mereka disimpan dan diproses secara berbeda serta memiliki model properti yang berbeda.

### Do ActiveX events and VBA macros work if the file has been modified by Aspose.Slides?
Aspose.Slides mempertahankan markup dan metadata yang ada; namun, peristiwa dan makro hanya dijalankan di dalam PowerPoint pada Windows ketika keamanan mengizinkannya. Perpustakaan tidak mengeksekusi VBA.