---
title: Buat dan Modifikasi Perilaku Animasi Kustom dalam JavaScript
linktitle: Animasi Kustom
type: docs
weight: 151
url: /id/nodejs-java/custom-animation/
keywords:
- animasi kustom
- perilaku animasi
- jalur gerak
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat, periksa, dan modifikasi perilaku animasi kustom serta jalur gerak yang dapat diedit dalam presentasi PowerPoint dengan Aspose.Slides untuk Node.js via Java."
---
## **Ikhtisar**

Perilaku animasi khusus memungkinkan Anda mengontrol operasi individual dalam efek animasi, seperti mengubah warna, memutar bentuk, atau mengikuti jalur gerak yang dapat diedit. Panduan ini menunjukkan cara membuat dan menggabungkan perilaku, mengatur timing‑nya, memeriksa dan memodifikasi animasi yang ada, serta memverifikasi bahwa properti‑nya tetap tersimpan saat menyimpan dan membuka kembali presentasi.

Untuk efek yang telah ditentukan dan pemicu klik, lihat [Animasi Bentuk](/slides/id/nodejs-java/shape-animation/).

## **Memahami Model Animasi**

Sebuah animasi diatur sebagai **Timeline → Sequence → Effect → Behaviors**:

- Metode [getTimeline](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseslide/#getTimeline) mengembalikan timeline slide, yang berisi urutan utama dan urutan interaktif.
- Sebuah [Sequence](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/) berisi efek, yang berpotensi menargetkan bentuk‑bentuk yang berbeda.
- Sebuah [Effect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/) mengidentifikasi bentuk target, preset, subtipe, dan timing efek.
- Koleksi yang dikembalikan oleh [Effect.getBehaviors](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#getBehaviors) berisi operasi yang mengimplementasikan efek: mengubah warna, memindahkan, memutar, menetapkan properti, dan sebagainya.

## **Buat Perilaku Individual**

Panggil [Sequence.addEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/#addEffect) untuk membuat efek dan mengakses koleksi [getBehaviors](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#getBehaviors). Sebuah preset dapat mengisi koleksi ini secara otomatis. Simpan operasi‑nya ketika memperluas preset, atau gunakan [clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorcollection/#clear) ketika sengaja menggantinya.

[BehaviorFactory](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorfactory/) membuat delapan tipe perilaku yang diilustrasikan di bawah. Gerak dibahas dalam [Build a Motion Path](#build-a-motion-path). Setiap cuplikan mencakup impor modulnya dan dapat dijalankan sebagai skrip Node.js dengan paket `aspose.slides.via.java` dan `java` terpasang. Jalankan contoh pembuatan file terlebih dahulu sebelum contoh yang membaca outputnya. Contoh pengeditan selanjutnya menyebutkan file output yang digunakan.

### **Rotasi**

Gunakan [createRotationEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) untuk membuat rotasi. [getBy](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/rotationeffect/#getBy) menentukan sudut relatif dalam derajat; [getFrom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/rotationeffect/#getFrom) dan [getTo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/rotationeffect/#getTo) menentukan titik akhir.

Contoh dimulai dengan efek Spin, mengganti operasi presetnya dengan satu perilaku rotasi, dan memberi operasi itu durasi dua detik. Sudut relatif 90 derajat mengekspresikan seperempat putaran dari orientasi awal bentuk, sehingga tidak diperlukan sudut awal yang eksplisit.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` berisi satu bentuk dan satu perilaku rotasi. Koleksi, timing, dan contoh penyuntingan rotasi di bawah menggunakan file ini.

### **Skala**

Gunakan [createScaleEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) dengan persentase X/Y: [getFrom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/scaleeffect/#getFrom) dan [getTo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/scaleeffect/#getTo) menggambarkan ukuran awal dan akhir, sementara [getBy](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/scaleeffect/#getBy) menggambarkan perubahan relatif. Di sini, 100 berarti ukuran asli.

Contoh memperbesar kedua dimensi dari 100 % menjadi 125 % selama dua detik. Menggunakan persentase horizontal dan vertikal yang sama menjaga proporsi bentuk; persentase yang berbeda akan meregangkan satu dimensi lebih dari yang lain.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Warna**

Gunakan [createColorEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) untuk mengubah isian dari biru ke oranye. [getFrom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/coloreffect/#getFrom) dan [getTo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/coloreffect/#getTo) adalah warna; [getBy](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/coloreffect/#getBy) adalah offset warna. [Behavior.getProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behavior/#getProperties) mengidentifikasi atribut yang dianimasikan.

Isian solid bentuk diinisialisasi menjadi biru, mencocokkan warna awal animasi. Memilih atribut isian‑warna memberi tahu perilaku bagian mana dari bentuk yang harus diubah; hanya titik akhir warna tidak mengidentifikasi atribut tersebut. Efek yang disimpan menggambarkan transisi dua detik ke oranye.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

Gunakan [createFilterEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) untuk memilih wipe. [getType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filtereffect/#getSubtype), dan [getReveal](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filtereffect/#getReveal) menentukan filter, arah, dan apakah mengungkap atau menyembunyikan bentuk.

Contoh ini mengonfigurasi wipe dua detik yang mengungkap bentuk menggunakan subtipe arah kanan. Pengaturan filter merupakan bagian dari perilaku di dalam efek, sehingga mereka dikonfigurasi setelah operasi asli preset dihapus.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Properti**

Gunakan [createPropertyEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) untuk menganimasikan opacity. [getFrom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/propertyeffect/#getTo), dan [getBy](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/propertyeffect/#getBy) adalah string yang diinterpretasikan menggunakan [getValueType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/propertyeffect/#getValueType) dan [getCalcMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Pilih titik akhir atau offset relatif daripada mengatur ketiganya secara sekaligus.

Di sini, atribut yang dipilih adalah opacity, dan string numerik mewakili perubahan dari opacity 25 % ke opacity penuh. Interpolasi linear menggambarkan perubahan bertahap antara nilai‑nilai tersebut. Saat menyesuaikan contoh ini untuk atribut lain, pilih tipe nilai dan nilai titik akhir yang sesuai dengan atribut tersebut.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Setel**

Gunakan [createSetEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) untuk menetapkan visibilitas melalui [getTo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/seteffect/#getTo). Perilaku setel tidak melakukan interpolasi antara titik akhir.

Contoh memilih atribut visibility dan menetapkan string `visible` ketika perilaku dijalankan. Persegi panjang sudah terlihat dalam presentasi minimal ini, sehingga penetapan mungkin tidak menghasilkan perubahan visual yang jelas sendiri. Operasi semacam ini berguna sebagai bagian dari efek yang lebih besar yang juga mengontrol kapan bentuk menjadi tersembunyi atau terlihat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Perintah**

Gunakan [createCommandEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) dan konfigurasikan [getType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/commandeffect/#getCommandString), dan [getShapeTarget](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Letakkan rekaman WAV bernama `sample.wav` di direktori kerja. Contoh ini menyematkannya dengan [addAudioFrameEmbedded](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) dan menempelkan perintah play ke frame audio.

Frame audio adalah target efek sekaligus target perintah. Ini menghubungkan permintaan play ke rekaman yang disematkan; string perintah saja tidak mengidentifikasi objek media mana yang harus dikontrol. Efek dikonfigurasikan untuk mulai pada klik selama slideshow.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

Menyimpan menyimpan perintah dalam `command.pptx`; tidak memutar rekaman. Pemutaran memerlukan pemutar slideshow yang mendukung perintah dan target medianya.

## **Kelola Koleksi Perilaku**

[BehaviorCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorcollection/) mendukung [add](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorcollection/#remove), dan [removeAt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Contoh ini membuka `rotation.pptx`, menambahkan skala, memindahkannya sebelum rotasi, dan menghapus rotasi. Menghapus dan memasukkan kembali objek yang sama mengubah posisi yang disimpan tanpa membuat salinan.

Urutan penyuntingan mengubah koleksi dari rotasi–skala menjadi skala–rotasi, lalu menjadi hanya skala. Indeks mengacu pada koleksi saat ini, sehingga penghapusan menggunakan indeks baru rotasi setelah pengurutan ulang. Enumerasi akhir mengonfirmasi perilaku mana yang akan disimpan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Outputnya adalah `ScaleEffect`: hanya skala yang tersisa. Urutan koleksi sendiri tidak menjadwalkan perilaku satu demi satu. Kosongkan koleksi hanya ketika mengganti semua operasinya.

## **Atur Timing Perilaku**

[Behavior.getTiming](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behavior/#getTiming) menampilkan [Timing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/), terpisah dari [Effect.getTiming](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#getTiming). Timing efek menjadwalkan efek yang membungkus; timing perilaku menjelaskan operasi di dalamnya.

### **Atur Durasi, Penundaan, Pengulangan, dan Akselerasi**

Buka `rotation.pptx` dan atur durasi ([getDuration](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getDuration)) serta penundaan pemicu ([getTriggerDelayTime](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) dalam detik, lalu konfigurasikan jumlah pengulangan melalui [setRepeatCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getAccelerate) dan [getDecelerate](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getDecelerate) adalah pecahan dari durasi; jaga agar jumlahnya paling banyak 1.

Berkas masukan adalah yang dibuat pada contoh rotasi, di mana perilaku pertama diketahui adalah rotasi. Contoh ini hanya mengubah timing perilaku tersebut; sudut 90 derajat tetap tidak berubah. Memisahkan sudut dan timing memudahkan penyesuaian kecepatan tanpa harus membangun ulang animasi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perilaku menggunakan durasi dua detik, penundaan setengah detik, dan jumlah pengulangan 3. 20 % pertama dan terakhir dari durasinya digunakan untuk akselerasi dan deselerasi.

Kebijakan pengulangan lain termasuk [getRepeatDuration](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide), dan [getRepeatUntilNextClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); pilih satu kebijakan daripada mengaktifkan semuanya bersamaan. [getAutoReverse](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getAutoReverse) memutar animasi mundur setelah putaran maju. Akselerasi dan deselerasi berlaku pada perubahan kontinu, bukan pada penetapan diskret atau perintah.

## **Buat Jalur Gerak**

Gunakan [createMotionEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) untuk membuat gerak. [getFrom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioneffect/#getTo), dan [getBy](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioneffect/#getBy) menggambarkan koordinat berbasis persentase atau offset. Untuk rute yang dapat diedit, buat [MotionPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motionpath/) dan tetapkan dengan [MotionEffect.setPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motionpath/) menyimpan perintah jalur.

[MotionCommandPathType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioncommandpathtype/) memilih operasi:

| Perintah | Titik | Makna |
| --- | --- | --- |
| MoveTo | Satu | Tetapkan posisi awal. |
| LineTo | Satu | Pindah sepanjang segmen lurus ke titik akhirnya. |
| CurveTo | Tiga | Ikuti kurva kubik yang didefinisikan oleh dua titik kontrol dan satu titik akhir. |
| CloseLoop | Tidak ada | Kembali ke posisi awal. |
| End | Tidak ada | Selesaikan jalur. |

[MotionPathPointsType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motionpathpointstype/) menjelaskan karakteristik penyuntingan titik, seperti titik sudut atau halus. Ini tidak menggantikan tipe perintah. Gunakan tipe titik kurva untuk contoh kurva di bawah, dan tipe titik sudut untuk segmen lurus.

Koordinat jalur dinormalisasi ke dimensi slide: perpindahan X sebesar 0,25 mewakili seperempat lebar slide, bukan 0,25 poin. Y positif mengalir ke bawah. Perintah absolut menentukan posisi dalam sistem koordinat jalur; perintah relatif menentukan offset dari posisi saat ini. Ini terpisah dari [getOrigin](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioneffect/#getOrigin), yang memilih kerangka referensi jalur, dan [getPathEditMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), yang mengontrol bagaimana jalur bergerak ketika bentuk dipindahkan.

### **Buat Jalur Lurus**

Buat perilaku gerak dengan titik mulai, satu segmen lurus, dan perintah akhir. [MotionPath.add](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motionpath/#add) menerima tipe perintah, titik‑titiknya, tipe titik, dan flag koordinat relatif.

Perintah mulai menetapkan (0, 0), dan garis berakhir di (0,25, 0), memberikan rute perpindahan horizontal seperempat lebar slide. Perintah akhir tidak memiliki titik koordinat. Setelah jalur ditetapkan, menambahkan perilaku gerak ke efek menghubungkan rute itu ke persegi panjang.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` berisi satu perilaku gerak dengan tiga perintah jalur. Contoh penyuntingan berkas berikut menggunakan struktur yang diketahui ini.

### **Bandingkan Koordinat Absolut dan Relatif**

Kedua objek jalur ini menggambarkan rute yang sama. Perintah absolut berakhir di (0,3, 0,1); perintah relatif menambahkan (0,1, 0,1) ke posisi saat ini, (0,2, 0).

Kedua jalur mulai pada posisi yang sama. Untuk garis relatif, tambahkan offset X dan Y ke posisi saat ini untuk memperoleh titik akhir; untuk garis absolut, bacalah titik akhir secara langsung. Mengubah flag tanpa mengonversi koordinat akan menghasilkan rute yang berbeda.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Tetapkan salah satu jalur ke perilaku gerak untuk menggunakannya dalam presentasi. Argumen Boolean akhir memilih koordinat relatif untuk perintah itu.

### **Ganti Garis dengan Kurva**

Buka `motion.pptx` dan ganti perintah garisnya dengan kurva kubik. Sediakan dua titik kontrol terlebih dahulu, diikuti oleh titik tujuan.

Posisi mulai disediakan oleh perintah sebelumnya. Dua titik pertama membentuk kurva, sementara titik ketiga adalah tujuan; bukan tiga tujuan berurutan. Memperbarui tipe perintah, tipe penyuntingan titik, dan array titik secara bersamaan menjaga segmen konsisten dengan geometri barunya.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jalur dalam `curve.pptx` masih memiliki tiga perintah; perintah tengah kini mendefinisikan kurva.

## **Periksa dan Edit Jalur yang Disimpan**

Setiap [MotionCmdPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioncmdpath/) menampilkan [getPoints](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioncmdpath/#getPointsType), dan [isRelative](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motioncmdpath/#isRelative). Contoh berikut menggunakan jalur tiga perintah yang dikenal dalam `motion.pptx`. Untuk masukan arbitrer, temukan efek yang dimaksud dan periksa tipe perintah serta jumlah titik sebelum mengedit berdasarkan indeks.

### **Baca Perintah dan Koordinat**

Baca jalur tanpa mengubahnya. Perintah end dan close-loop tidak memerlukan titik, jadi izinkan array titik bernilai null.

Output mempair setiap tipe perintah numerik dengan flag koordinat relatifnya sebelum mencantumkan titik‑titiknya. Ini memungkinkan Anda membedakan titik akhir dari offset sebelum memodifikasi jalur. Kurva akan menampilkan tiga titik, sementara garis lurus dalam berkas ini hanya menampilkan satu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Daftar berisi titik mulai, garis absolut yang berakhir di (0,25, 0), dan perintah end.

### **Ubah Titik Akhir**

Buka `motion.pptx` dan ganti array titik garis untuk memindahkan titik akhirnya.

Dalam berkas masukan, indeks 0 adalah perintah mulai dan indeks 1 adalah garis. Mengganti satu titik garis mengubah tujuan tanpa mengubah tipe perintah, timing, atau posisinya dalam koleksi. Karena perintah menggunakan koordinat absolut, pasangan baru menentukan posisi, bukan offset tambahan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Garis dalam `motion-endpoint.pptx` berakhir di (0,4, 0,1); berkas asli tidak berubah.

### **Ganti Segmen**

Gunakan [insert](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motionpath/#insert) dan [removeAt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/motionpath/#removeAt) untuk mengganti garis dalam `motion.pptx`. Menyisipkan menggeser garis lama ke indeks 2.

Ini mendemonstrasikan penggantian objek perintah daripada menyunting koordinat yang ada. Setelah penyisipan, koleksi sementara berisi perintah mulai, garis baru, garis lama, dan perintah end. Menghapus indeks 2 membuang garis lama dan meninggalkan rute baru di tempatnya.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jalur yang disimpan tetap memiliki tiga perintah, dengan garis baru berakhir di (0,2, 0,1) dan perintah end terakhir.

## **Modifikasi dan Verifikasi Perilaku yang Ada**

Ketika indeks perilaku tidak diketahui, pilih berdasarkan tipe. Contoh ini membuka `rotation.pptx`, menemukan [RotationEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/rotationeffect/), mengubah sudut, dan memeriksa nilai yang disimpan setelah dibuka kembali.

Pemeriksaan tipe memungkinkan loop melewati perilaku yang bukan rotasi. Muatan kedua membaca berkas yang disimpan ke dalam objek presentasi terpisah, sehingga perbandingan memeriksa data yang dipertahankan, bukan nilai yang masih berada di memori. Contoh ini masih mengasumsikan efek yang dikenal berada pertama dalam urutan utama; memilih perilaku berdasarkan tipe tidak menemukan efek yang tepat dalam presentasi arbitrer.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Outputnya adalah `Rotation preserved: true`. Terapkan pola pemeriksaan tipe yang sama pada perilaku lain. Untuk pemeriksaan preservasi lengkap, bandingkan bentuk target, efek, tipe dan urutan perilaku, timing, serta perintah jalur. Gunakan toleransi numerik untuk nilai floating‑point. Untuk presentasi dengan tata animasi yang tidak diketahui, lihat [Read Shape Animations](/slides/id/nodejs-java/shape-animation/#read-shape-animations) untuk penelusuran urutan utama dan interaktif.

## **Urutan Perilaku, Preset, dan Pemutaran**

Urutan dalam [BehaviorCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behaviorcollection/) adalah urutan tersimpan dari operasi efek. Itu bukan playlist di mana setiap perilaku secara otomatis menunggu yang sebelumnya. Timing dan efek yang membungkus menentukan penjadwalan. Perilaku dapat tumpang tindih, dan operasi pada properti yang sama dapat berinteraksi melalui [getAdditive](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behavior/#getAdditive) dan [getAccumulate](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/behavior/#getAccumulate). Jangan gunakan penataan ulang koleksi saja untuk menjadwalkan “pindah, lalu putar”; gunakan timing eksplisit atau efek terpisah sebagaimana dijelaskan dalam [Animasi Bentuk](/slides/id/nodejs-java/shape-animation/).

[Effect.getType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#getType) dan [Effect.getSubtype](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#getSubtype) menggambarkan presetnya. Itu bukan deskripsi lengkap dari pohon perilaku yang telah diedit. Pilih preset dan subtipe sebelum menyesuaikan perilaku: mengubah preset dapat membangun ulang koleksi dan membuang operasi khusus Anda. Misalnya, mengubah efek Spin yang disesuaikan menjadi Fade dapat menggantikan perilaku rotasi dengan perilaku set dan filter. Periksa kembali koleksi setelah mengubah preset atau subtipe. Mengosongkan perilaku preset juga dapat menghapus operasi visibilitas atau inisialisasi yang dibutuhkan preset. Contoh‑contoh secara sengaja menggunakan bentuk yang terlihat dan menggantikan perilaku; mereka tidak membangun ulang implementasi setiap preset.

## **Kompatibilitas Format**

Pohon perilaku yang dipertahankan tidak menjamin pemutaran identik di setiap penampil atau render ekspor. Periksa data yang disimpan dan output yang dirender secara terpisah.

| Format atau output | Apa yang harus diverifikasi |
| --- | --- |
| PPTX | Digunakan sebagai format utama untuk contoh ini. Buka kembali untuk memverifikasi pohon perilaku yang dapat diedit, lalu periksa pemutaran di versi PowerPoint yang dituju. |
| PPT | Representasi biner legacy dapat berbeda dari PPTX. Lakukan siklus simpan‑buka‑ulang terpisah serta pemutaran; jangan menyimpulkan dukungan untuk setiap kombinasi khusus hanya dari output PPTX yang berhasil. |
| PDF, PNG, JPEG, dan gambar slide statis lainnya | Berisi representasi slide statis, bukan timeline perilaku yang dapat diputar atau frame animasi final yang dijamin. |
| [HTML5](/slides/id/nodejs-java/export-to-html5/) | Dapat memutar animasi yang didukung bila animasi bentuk diaktifkan dalam opsi ekspor. Uji kombinasi khusus di peramban. |
| [Animated GIF](/slides/id/nodejs-java/convert-powerpoint-to-animated-gif/) | Menyimpan frame yang dirender, bukan perilaku yang dapat diedit atau interaksi klik. Periksa gerakan yang sebenarnya dirender. |
| [Video](/slides/id/nodejs-java/convert-powerpoint-to-video/) | Merender frame animasi dan mengenkodenya sebagai video. Dukungan terbatas pada [animasi dan efek yang didukung](/slides/id/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) oleh renderer; perintah dan acara interaktif tidak menjadi timeline yang dapat diedit. |

## **Tanya Jawab**

**Mengapa efek saya berisi perilaku sebelum saya menambahkan apa pun?**

Membuat efek yang telah ditentukan dapat membuat operasi dasarnya. Periksa mereka sebelum memutuskan apakah akan memperluas preset atau mengganti perilakunya.

**Apakah memindahkan perilaku ke awal membuatnya diputar pertama?**

Tidak selalu. Urutan koleksi bukan pengganti timing. Periksa penundaan, durasi, dan interaksi antar operasi pada properti yang sama.

**Mengapa perintah end tidak memiliki titik?**

Itu menandai akhir jalur dan tidak memerlukan koordinat. Periksa array titik yang null saat memeriksa jalur yang dibaca dari berkas.

**Apakah perjalanan bolak‑balik yang berhasil cukup untuk mengonfirmasi pemutaran?**

Tidak. Membuka kembali mengonfirmasi preservasi properti yang Anda periksa. Uji pemutar slideshow atau ekspor animasi secara terpisah untuk memastikan perilaku visualnya.