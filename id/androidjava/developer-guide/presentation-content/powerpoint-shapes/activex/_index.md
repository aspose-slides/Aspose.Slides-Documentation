---
title: Kelola Kontrol ActiveX dalam Presentasi di Android
linktitle: ActiveX
type: docs
weight: 80
url: /id/androidjava/activex/
keywords:
- ActiveX
- kontrol ActiveX
- mengelola ActiveX
- menambahkan ActiveX
- memodifikasi ActiveX
- pemutar media
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Edit kotak teks dan tombol ActiveX, perbarui pratinjau kontrol, dan gunakan kembali kontrol Windows Media Player dalam presentasi PowerPoint dengan Aspose.Slides untuk Android melalui Java."
---
## **Pendahuluan**

Kontrol ActiveX memberikan elemen interaktif pada slide PowerPoint seperti kotak teks, tombol perintah, dan pemutar media. Aspose.Slides untuk Android melalui Java menampilkan kontrol slide melalui [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--). Gunakan koleksi ini untuk mengedit kontrol, memindahkannya pada slide, atau menghapusnya. Dalam contoh di bawah, gunakan jalur file yang dapat dibaca aplikasi Android Anda dan pilih lokasi yang dapat ditulisi untuk setiap presentasi output.

## **Daftar Kontrol ActiveX dan Properti yang Disimpan**

Untuk memeriksa templat yang tidak dikenal, bukalah untuk dibaca dan iterasi melalui kontrol pada setiap slide. Contoh melaporkan nomor slide, nama kontrol, [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--), dan setiap pasangan kunci-nilai dalam [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--). Ia membaca presentasi tanpa mengaktifkan kontrol, memanggil peristiwa atau makro, mengubah nilai, atau menyimpan file.

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

Output terpilih dari `ActiveX.pptm` menampilkan kotak teks dan tombol perintah.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Sebuah koleksi properti kosong muncul sebagai `[]`. Untuk kontrol yang menggunakan penyimpanan biner, [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) dapat mengembalikan `null`, ditampilkan sebagai `Properties unavailable`. Jika Anda hanya membutuhkan nama, gunakan [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) setelah memeriksa null. Laporan mencantumkan properti yang tersedia dari presentasi. Sebuah kontrol mungkin mendukung properti tambahan pada waktu berjalan.

## **Modifikasi Kontrol ActiveX**

Contoh mengharapkan presentasi yang mendukung makro dengan kotak teks bernama `TextBox1` dan tombol perintah bernama `CommandButton1` pada slide pertama. Ia menggunakan [koleksi properti kontrol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) untuk mengubah nilai kotak teks dan judul tombol. Setiap kontrol juga memiliki pratinjau statis yang dapat ditampilkan PowerPoint sebelum aktivasi. Sediakan file PNG untuk setiap kontrol yang menampilkan teks dan tampilan yang diperbarui. Contoh menetapkan gambar ini melalui [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Contoh memindahkan setiap kontrol pada slide pertama ke bawah sebesar 100 poin dengan mengatur frame-nya menggunakan [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Ia menyimpan presentasi yang diedit dalam format PPTM, lalu menggunakan [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) untuk menyimpan salinan kedua dengan semua kontrol ActiveX di slide tersebut dihapus.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

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

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
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

Untuk menggunakan kembali kontrol Windows Media Player yang sudah dikonfigurasi, mulailah dengan templat yang slide pertamanya berisi pemutar bernama `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) menyalin seluruh slide ke dalam presentasi baru. Contoh mengatur `URL` pemutar dalam [properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) dan menyimpan slide yang dikloning sebagai satu-satunya slide dalam output. Video tetap eksternal, jadi pilih jalur yang dapat diakses pemutar selama pemutaran.

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

## **FAQ**

**Apakah Aspose.Slides dapat mempertahankan kontrol ActiveX tanpa menjalankannya?**

Ya. Aspose.Slides dapat membaca dan menyimpan kontrol, termasuk properti dan posisinya, tanpa mengaktifkannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE?**

Kontrol ActiveX memungkinkan pengguna berinteraksi dengan slide, misalnya dengan memasukkan teks atau mengklik tombol. Sebuah [objek OLE](/slides/id/androidjava/manage-ole/) memungkinkan slide berisi atau menautkan ke konten yang dikelola oleh aplikasi lain, seperti lembar kerja Excel.

**Apakah peristiwa ActiveX masih akan memicu makro VBA setelah saya menyimpan presentasi dengan Aspose.Slides?**

Simpan presentasi dalam format yang mendukung makro seperti PPTM untuk mempertahankan proyek VBA-nya. PowerPoint untuk Windows dapat menjalankan penangan peristiwa yang ada ketika pengaturan keamanannya mengizinkan baik kontrol ActiveX maupun makro.