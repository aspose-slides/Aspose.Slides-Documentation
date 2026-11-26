---
title: Mengelola Kontrol ActiveX dalam Presentasi Menggunakan JavaScript
linktitle: ActiveX
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
description: "Sunting kotak teks dan tombol ActiveX, perbarui pratinjau kontrol, serta gunakan kembali kontrol Windows Media Player dalam presentasi PowerPoint dengan Aspose.Slides untuk Node.js via Java."
---
## **Pendahuluan**

ActiveX controls memberi slide PowerPoint elemen interaktif seperti kotak teks, tombol perintah, dan pemutar media. Aspose.Slides untuk Node.js via Java mengekspos kontrol slide melalui [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Gunakan koleksi ini untuk menyunting kontrol, memindahkannya pada slide, atau menghapusnya.

## **Daftar Kontrol ActiveX dan Properti yang Disimpan**

Untuk memeriksa templat yang tidak dikenal, buka untuk dibaca dan iterasikan kontrol pada setiap slide. Contoh melaporkan nomor slide, nama kontrol, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId), dan setiap pasangan kunci‑nilai dalam [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). Ia membaca presentasi tanpa mengaktifkan kontrol, memanggil peristiwa atau makro, mengubah nilai, atau menyimpan berkas.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Output terpilih dari `ActiveX.pptm` menunjukkan sebuah kotak teks dan tombol perintah.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Koleksi properti kosong muncul sebagai `[]`. Untuk kontrol yang menggunakan penyimpanan biner, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) dapat mengembalikan `null`, ditampilkan sebagai `Properties unavailable`. Jika Anda hanya memerlukan nama-nama, gunakan [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) setelah pemeriksaan `null`. Laporan mencantumkan properti yang tersedia dari presentasi. Sebuah kontrol mungkin mendukung properti tambahan pada runtime.

## **Modifikasi Kontrol ActiveX**

Contoh mengharapkan presentasi yang mendukung makro dengan kotak teks bernama `TextBox1` dan tombol perintah bernama `CommandButton1` pada slide pertama. Ia menggunakan [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) untuk mengubah nilai kotak teks dan judul tombol. Setiap kontrol juga memiliki pratinjau statis yang dapat ditampilkan PowerPoint sebelum aktivasi. Sediakan PNG untuk setiap kontrol yang menunjukkan teks dan tampilan yang telah diperbarui. Contoh menetapkan gambar ini melalui [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

Contoh memindahkan setiap kontrol pada slide pertama ke bawah sebesar 100 poin dengan mengatur bingkainya menggunakan [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). Ia menyimpan presentasi yang diedit dalam format PPTM, lalu menggunakan [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) untuk menyimpan salinan kedua dengan semua kontrol ActiveX di slide tersebut dihapus.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```

## **Tambahkan Kontrol Pemutar Media ActiveX**

Untuk menggunakan kembali kontrol Windows Media Player yang telah dikonfigurasi, mulai dengan templat yang slide pertamanya berisi pemutar bernama `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) menyalin seluruh slide ke dalam presentasi baru. Contoh mengatur `URL` pemutar dalam [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) dan menyimpan slide yang dikloning sebagai satu‑satunya slide dalam output. Video tetap eksternal, jadi pilih jalur yang dapat diakses pemutar selama pemutaran.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```

## **FAQ**

**Apakah Aspose.Slides dapat mempertahankan kontrol ActiveX tanpa mengeksekusinya?**

Ya. Aspose.Slides dapat membaca dan menyimpan kontrol, termasuk properti dan posisinya, tanpa mengaktifkannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE?**

Kontrol ActiveX memungkinkan pengguna berinteraksi dengan slide, misalnya dengan memasukkan teks atau mengklik tombol. Sebuah [OLE object](/slides/id/nodejs-java/manage-ole/) memungkinkan slide berisi atau menautkan ke konten yang dikelola aplikasi lain, seperti lembar kerja Excel.

**Apakah peristiwa ActiveX masih akan memicu makro VBA setelah saya menyimpan presentasi dengan Aspose.Slides?**

Simpan presentasi dalam format yang mendukung makro seperti PPTM untuk mempertahankan proyek VBA‑nya. PowerPoint untuk Windows dapat menjalankan penangan peristiwa yang ada bila pengaturan keamanannya memperbolehkan baik kontrol ActiveX maupun makro.