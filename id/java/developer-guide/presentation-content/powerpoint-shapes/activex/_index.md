---
title: Kelola Kontrol ActiveX pada Presentasi di Java
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
description: "Edit kotak teks dan tombol ActiveX, perbarui pratinjau kontrol, dan gunakan kembali kontrol Windows Media Player dalam presentasi PowerPoint dengan Aspose.Slides untuk Java."
---
## **Pendahuluan**

Kontrol ActiveX memberikan elemen interaktif pada slide PowerPoint seperti kotak teks, tombol perintah, dan pemutar media. Aspose.Slides for Java mengekspos kontrol slide melalui [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). Gunakan koleksi ini untuk mengedit kontrol, memindahkannya pada slide, atau menghapusnya.

## **Daftar Kontrol ActiveX dan Properti yang Disimpan**

Untuk memeriksa templat yang tidak dikenal, buka untuk dibaca dan iterasi melalui kontrol pada setiap slide. Contoh ini melaporkan nomor slide, nama kontrol, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), dan setiap pasangan kunci-nilai dalam [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). Ia membaca presentasi tanpa mengaktifkan kontrol, memanggil event atau makro, mengubah nilai, atau menyimpan berkas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Output terpilih dari `ActiveX.pptm` memperlihatkan kotak teks dan tombol perintah.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Koleksi properti kosong muncul sebagai `[]`. Untuk kontrol yang menggunakan penyimpanan biner, [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) dapat mengembalikan `null`, ditampilkan sebagai `Properties unavailable`. Jika Anda hanya memerlukan nama, gunakan [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) setelah pemeriksaan null. Laporan ini mencantumkan properti yang tersedia dari presentasi. Sebuah kontrol dapat mendukung properti tambahan pada runtime.

## **Modifikasi Kontrol ActiveX**

Contoh ini mengharapkan presentasi yang dapat menjalankan makro dengan kotak teks bernama `TextBox1` dan tombol perintah bernama `CommandButton1` pada slide pertama. Ia menggunakan [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) untuk mengubah nilai kotak teks dan caption tombol. Setiap kontrol juga memiliki pratinjau statis yang dapat ditampilkan PowerPoint sebelum aktivasi. Sediakan PNG untuk setiap kontrol yang menunjukkan teks dan tampilan yang diperbarui. Contoh ini menetapkan gambar tersebut melalui [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Contoh ini memindahkan setiap kontrol pada slide pertama ke bawah sebesar 100 poin dengan mengatur bingkainya menggunakan [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Ia menyimpan presentasi yang telah diedit dalam format PPTM, kemudian menggunakan [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) untuk menyimpan salinan kedua dengan semua kontrol ActiveX dihapus dari slide tersebut.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Tambahkan Kontrol Pemutar Media ActiveX**

Untuk menggunakan kembali kontrol Windows Media Player yang telah dikonfigurasi, mulailah dengan templat yang slide pertamanya berisi pemutar bernama `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) menyalin seluruh slide ke presentasi baru. Contoh ini menetapkan `URL` pemutar dalam [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) dan menyimpan slide yang dikloning sebagai satu-satunya slide dalam output. Video tetap bersifat eksternal, jadi pilih jalur yang dapat diakses pemutar saat pemutaran.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **Tanya Jawab**

**Apakah Aspose.Slides dapat mempertahankan kontrol ActiveX tanpa menjalankannya?**

Ya. Aspose.Slides dapat membaca dan menyimpan kontrol, termasuk properti dan posisinya, tanpa mengaktifkannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE?**

Kontrol ActiveX memungkinkan pengguna berinteraksi dengan slide, misalnya dengan memasukkan teks atau mengklik tombol. Sebuah [OLE object](/slides/id/java/manage-ole/) memungkinkan slide berisi atau menautkan konten yang dikelola oleh aplikasi lain, seperti lembar kerja Excel.

**Apakah event ActiveX masih akan memicu makro VBA setelah saya menyimpan presentasi dengan Aspose.Slides?**

Simpan presentasi dalam format yang mendukung makro seperti PPTM untuk mempertahankan proyek VBA-nya. PowerPoint untuk Windows dapat menjalankan penangan event yang ada ketika pengaturan keamanan memungkinkan baik kontrol ActiveX maupun makro.