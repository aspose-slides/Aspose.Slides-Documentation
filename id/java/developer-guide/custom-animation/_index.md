---
title: Buat dan Modifikasi Perilaku Animasi Kustom dalam Java
linktitle: Animasi Kustom
type: docs
weight: 151
url: /id/java/custom-animation/
keywords:
- animasi kustom
- perilaku animasi
- jalur gerak
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Buat, periksa, dan modifikasi perilaku animasi kustom serta jalur gerak yang dapat diedit dalam presentasi PowerPoint dengan Aspose.Slides untuk Java."
---
## **Ringkasan**

Perilaku animasi kustom memungkinkan Anda mengendalikan operasi individu dalam sebuah efek animasi, seperti mengubah warna, memutar bentuk, atau mengikuti jalur gerak yang dapat diedit. Panduan ini menunjukkan cara membuat dan menggabungkan perilaku, mengonfigurasi waktu mereka, memeriksa dan mengubah animasi yang ada, serta memverifikasi bahwa propertinya tetap ada setelah menyimpan dan membuka kembali presentasi.

Untuk efek yang telah ditentukan sebelumnya dan pemicu klik, lihat [Animasi Bentuk](/slides/id/java/shape-animation/).

## **Memahami Model Animasi**

Sebuah animasi disusun sebagai **Timeline → Sequence → Effect → Behaviors**:

- Metode [getTimeline](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibaseslide/#getTimeline--) mengembalikan timeline slide, yang berisi urutan utama dan urutan interaktif.
- Sebuah [ISequence](https://reference.aspose.com/slides/id/java/com.aspose.slides/isequence/) berisi efek, berpotensi menargetkan bentuk yang berbeda.
- Sebuah [IEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/ieffect/) mengidentifikasi bentuk target, preset, subtype, dan waktu efek.
- Koleksi yang dikembalikan oleh [IEffect.getBehaviors](https://reference.aspose.com/slides/id/java/com.aspose.slides/ieffect/#getBehaviors--) berisi operasi yang mengimplementasikan efek: mengubah warna, memindahkan, memutar, mengatur properti, dan sebagainya.

## **Membuat Perilaku Individu**

Panggil [ISequence.addEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) untuk membuat sebuah efek dan mengakses koleksi [getBehaviors](https://reference.aspose.com/slides/id/java/com.aspose.slides/ieffect/#getBehaviors--). Sebuah preset dapat mengisi koleksi ini secara otomatis. Pertahankan operasinya saat memperluas preset, atau gunakan [clear](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorcollection/#clear--) ketika sengaja menggantinya.

[IBehaviorFactory](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorfactory/) membuat delapan tipe perilaku yang diilustrasikan di bawah. Gerakan dibahas dalam [Membangun Jalur Gerak](#build-a-motion-path). Setiap potongan kode menyertakan impor; letakkan pernyataan eksekusinya di dalam sebuah metode. Contoh penyuntingan selanjutnya menyatakan file output yang mereka gunakan.

### **Rotasi**

Gunakan [createRotationEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) untuk membuat rotasi. [getBy](https://reference.aspose.com/slides/id/java/com.aspose.slides/irotationeffect/#getBy--) menentukan sudut relatif dalam derajat; [getFrom](https://reference.aspose.com/slides/id/java/com.aspose.slides/irotationeffect/#getFrom--) dan [getTo](https://reference.aspose.com/slides/id/java/com.aspose.slides/irotationeffect/#getTo--) menentukan titik akhir.

Contoh dimulai dengan efek Spin, mengganti operasi presetnya dengan satu perilaku rotasi, dan memberi operasi tersebut durasi dua detik. Sudut relatif 90 derajat menyatakan seperempat putaran dari orientasi awal bentuk, sehingga tidak diperlukan sudut awal yang eksplisit.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` berisi satu bentuk dan satu perilaku rotasi. Koleksi, waktu, dan contoh penyuntingan rotasi di bawah menggunakan file ini.

### **Skala**

Gunakan [createScaleEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) dengan persentase X/Y: [getFrom](https://reference.aspose.com/slides/id/java/com.aspose.slides/iscaleeffect/#getFrom--) dan [getTo](https://reference.aspose.com/slides/id/java/com.aspose.slides/iscaleeffect/#getTo--) menggambarkan ukuran awal dan akhir, sementara [getBy](https://reference.aspose.com/slides/id/java/com.aspose.slides/iscaleeffect/#getBy--) menggambarkan perubahan relatif. Di sini, 100 berarti ukuran asli.

Contoh memperbesar kedua dimensi dari 100 % ke 125 % selama dua detik. Menggunakan persentase horizontal dan vertikal yang sama menjaga proporsi bentuk; persentase yang berbeda akan meregangkan satu dimensi lebih dari yang lain.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Warna**

Gunakan [createColorEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) untuk mengubah isian dari biru ke oranye. [getFrom](https://reference.aspose.com/slides/id/java/com.aspose.slides/icoloreffect/#getFrom--) dan [getTo](https://reference.aspose.com/slides/id/java/com.aspose.slides/icoloreffect/#getTo--) adalah warna; [getBy](https://reference.aspose.com/slides/id/java/com.aspose.slides/icoloreffect/#getBy--) adalah offset warna. [IBehavior.getProperties](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehavior/#getProperties--) mengidentifikasi atribut yang dianimasikan.

Isian padat bentuk diinisialisasi ke biru, cocok dengan warna awal animasi. Memilih atribut isian‑warna memberi tahu perilaku bagian mana dari bentuk yang harus diubah; hanya titik akhir warna tidak mengidentifikasi atribut tersebut. Efek yang disimpan menggambarkan transisi dua detik ke oranye.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

Gunakan [createFilterEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) untuk memilih wipe. [getType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifiltereffect/#getSubtype--), dan [getReveal](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifiltereffect/#getReveal--) menentukan filter, arah, dan apakah memperlihatkan atau menyembunyikan bentuk.

Contoh ini mengonfigurasi wipe dua detik yang memperlihatkan bentuk menggunakan subtype arah kanan. Pengaturan filter merupakan bagian dari perilaku di dalam efek, sehingga dikonfigurasi setelah operasi asli preset dihapus.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Properti**

Gunakan [createPropertyEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) untuk menganimasikan opacity. [getFrom](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipropertyeffect/#getTo--), dan [getBy](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipropertyeffect/#getBy--) adalah string yang ditafsirkan menggunakan [getValueType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipropertyeffect/#getValueType--) dan [getCalcMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). Pilih titik akhir atau offset relatif daripada mengatur ketiganya secara bersamaan.

Di sini, atribut yang dipilih adalah opacity, dan string numerik mewakili perubahan dari opacity 25 % ke opacity penuh. Interpolasi linear menggambarkan perubahan bertahap antara nilai tersebut. Saat menerapkan contoh ini pada atribut lain, pilih tipe nilai dan nilai titik akhir yang sesuai dengan atribut tersebut.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Set**

Gunakan [createSetEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) untuk menetapkan visibilitas melalui [getTo](https://reference.aspose.com/slides/id/java/com.aspose.slides/iseteffect/#getTo--). Perilaku set tidak melakukan interpolasi antara titik akhir.

Contoh memilih atribut visibilitas dan menetapkan string `visible` ketika perilaku dijalankan. Persegi panjang sudah terlihat dalam presentasi minimal ini, sehingga penetapan tersebut mungkin tidak menghasilkan perubahan visual yang jelas sendiri. Operasi semacam ini berguna sebagai bagian dari efek yang lebih besar yang juga mengontrol kapan bentuk menjadi tersembunyi atau terlihat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Perintah**

Gunakan [createCommandEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) dan konfigurasikan [getType](https://reference.aspose.com/slides/id/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/id/java/com.aspose.slides/icommandeffect/#getCommandString--), dan [getShapeTarget](https://reference.aspose.com/slides/id/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Letakkan rekaman WAV bernama `sample.wav` di direktori kerja. Contoh ini menyematkannya dengan [addAudioFrameEmbedded](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) dan menambahkan perintah putar ke frame audio.

Frame audio adalah target efek sekaligus target perintah. Ini menghubungkan permintaan putar ke rekaman yang disematkan; string perintah saja tidak mengidentifikasi objek media mana yang harus dikendalikan. Efek dikonfigurasikan untuk memulai pada klik selama slideshow.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

Menyimpan menyimpan perintah dalam `command.pptx`; tidak memutar rekaman. Pemutaran memerlukan pemutar slideshow yang mendukung perintah dan target medianya.

## **Mengelola Koleksi Perilaku**

[IBehaviorCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorcollection/) mendukung [add](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), dan [removeAt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Contoh ini membuka `rotation.pptx`, menambahkan skala, memindahkannya sebelum rotasi, dan menghapus rotasi. Menghapus dan menyisipkan kembali objek yang sama mengubah posisi tersimpannya tanpa membuat salinan.

Urutan penyuntingan mengubah koleksi dari rotasi‑skala menjadi skala‑rotasi, lalu menjadi hanya skala. Indeks mengacu pada koleksi saat ini, sehingga penghapusan menggunakan indeks baru rotasi setelah pengurutan ulang. Enumerasi terakhir mengonfirmasi perilaku mana yang akan disimpan.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Outputnya `ScaleEffect`: hanya skala yang tersisa. Urutan koleksi sendiri tidak menjadwalkan perilaku satu demi satu. Bersihkan koleksi hanya ketika mengganti semua operasinya.

## **Mengonfigurasi Waktu Perilaku**

[IBehavior.getTiming](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehavior/#getTiming--) mengekspor [ITiming](https://reference.aspose.com/slides/id/java/com.aspose.slides/itiming/), terlepas dari [IEffect.getTiming](https://reference.aspose.com/slides/id/java/com.aspose.slides/ieffect/#getTiming--). Waktu efek menjadwalkan efek yang membungkus; waktu perilaku menggambarkan operasi di dalamnya.

### **Mengatur Durasi, Penundaan, Pengulangan, dan Akselerasi**

Buka `rotation.pptx` dan atur durasi ([getDuration](https://reference.aspose.com/slides/id/java/com.aspose.slides/itiming/#getDuration--)) serta penundaan pemicu ([getTriggerDelayTime](https://reference.aspose.com/slides/id/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) dalam detik, lalu konfigurasikan jumlah pengulangan melalui [setRepeatCount](https://reference.aspose.com/slides/id/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/id/java/com.aspose.slides/itiming/#getAccelerate--) dan [getDecelerate](https://reference.aspose.com/slides/id/java/com.aspose.slides/itiming/#getDecelerate--) merupakan pecahan dari durasi; pertahankan jumlahnya tidak lebih dari 1.

File input adalah yang dibuat pada contoh rotasi, di mana perilaku pertama diketahui berupa rotasi. Contoh ini hanya mengubah waktu perilaku tersebut; sudut 90 derajat tetap tidak berubah. Memisahkan sudut dan waktu memudahkan penyesuaian kecepatan tanpa membangun ulang animasi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Perilaku menggunakan durasi dua detik, penundaan setengah detik, dan jumlah pengulangan 3. 20 % pertama dan terakhir dari durasinya digunakan untuk akselerasi dan deselerasi.

Kebijakan pengulangan lain termasuk [getRepeatDuration](https://reference.aspose.com/slides/id/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), dan [getRepeatUntilNextClick](https://reference.aspose.com/slides/id/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); pilih satu kebijakan daripada mengaktifkan semuanya sekaligus. [getAutoReverse](https://reference.aspose.com/slides/id/java/com.aspose.slides/itiming/#getAutoReverse--) memutar animasi mundur setelah putaran maju. Akselerasi dan deselerasi diterapkan pada perubahan kontinu, bukan pada penetapan diskrit atau perintah.

## **Membangun Jalur Gerak**

Gunakan [createMotionEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) untuk membuat gerak. [getFrom](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotioneffect/#getTo--), dan [getBy](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotioneffect/#getBy--) menggambarkan koordinat berbasis persentase atau offset. Untuk rute yang dapat diedit, buat sebuah [MotionPath](https://reference.aspose.com/slides/id/java/com.aspose.slides/motionpath/) dan tetapkan dengan [IMotionEffect.setPath](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotionpath/) menyimpan perintah jalur.

[MotionCommandPathType](https://reference.aspose.com/slides/id/java/com.aspose.slides/motioncommandpathtype/) memilih operasi:

| Perintah | Titik | Makna |
| --- | --- | --- |
| MoveTo | Satu | Menetapkan posisi awal. |
| LineTo | Satu | Memindahkan sepanjang segmen lurus ke titik akhirnya. |
| CurveTo | Tiga | Mengikuti kurva kubik yang didefinisikan oleh dua titik kontrol dan satu titik akhir. |
| CloseLoop | Tidak ada | Kembali ke posisi awal. |
| End | Tidak ada | Mengakhiri jalur. |

[MotionPathPointsType](https://reference.aspose.com/slides/id/java/com.aspose.slides/motionpathpointstype/) menggambarkan karakteristik penyuntingan titik, seperti titik sudut atau halus. Ini tidak menggantikan tipe perintah. Gunakan tipe titik kurva untuk contoh kurva di bawah, dan tipe titik sudut untuk segmen lurus.

Koordinat jalur dinormalisasi ke dimensi slide: perpindahan X 0,25 mewakili seperempat lebar slide, bukan 0,25 poin. Y positif mengarah ke bawah. Perintah absolut menentukan posisi dalam sistem koordinat jalur; perintah relatif menentukan offset dari posisi saat ini. Ini terpisah dari [getOrigin](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotioneffect/#getOrigin--), yang memilih kerangka referensi jalur, dan [getPathEditMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotioneffect/#getPathEditMode--), yang mengatur bagaimana jalur bergerak ketika bentuk dipindahkan.

### **Membuat Jalur Lurus**

Buat perilaku gerak dengan titik awal, satu segmen lurus, dan perintah akhir. [IMotionPath.add](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) mengambil tipe perintah, titik‑titiknya, tipe titik, dan flag koordinat relatif.

Perintah awal menetapkan (0, 0), dan garis berakhir di (0,25, 0), memberi jalur perpindahan horizontal seperempat lebar slide. Perintah akhir tidak memiliki titik koordinat. Setelah jalur ditetapkan, menambahkan perilaku gerak ke efek menghubungkan jalur tersebut ke persegi panjang.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` berisi satu perilaku gerak dengan tiga perintah jalur. Contoh penyuntingan file berikut menggunakan struktur yang diketahui ini.

### **Membandingkan Koordinat Absolut dan Relatif**

Kedua objek jalur ini menggambarkan rute yang sama. Perintah absolut berakhir di (0,3, 0,1); perintah relatif menambahkan (0,1, 0,1) ke posisi saat ini, (0,2, 0).

Kedua jalur mulai dari posisi yang sama. Untuk garis relatif, tambahkan offset X dan Y ke posisi saat ini untuk memperoleh titik akhir; untuk garis absolut, baca titik akhir secara langsung. Mengubah flag tanpa mengkonversi koordinat akan menghasilkan rute yang berbeda.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Terapkan salah satu jalur ke perilaku gerak untuk menggunakannya dalam presentasi. Argumen Boolean terakhir memilih koordinat relatif untuk perintah tersebut.

### **Mengganti Garis dengan Kurva**

Buka `motion.pptx` dan ganti perintah garisnya dengan kurva kubik. Berikan dua titik kontrol terlebih dahulu, diikuti oleh titik akhir.

Posisi awal disediakan oleh perintah sebelumnya. Dua titik pertama membentuk kurva, sementara yang ketiga adalah tujuan; mereka bukan tiga tujuan berturut‑turut. Memperbarui tipe perintah, tipe penyuntingan titik, dan array titik secara bersamaan menjaga segmen konsisten dengan geometri barunya.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jalur dalam `curve.pptx` masih memiliki tiga perintah; perintah tengahnya kini mendefinisikan kurva.

## **Memeriksa dan Menyunting Jalur yang Disimpan**

Setiap [IMotionCmdPath](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotioncmdpath/) mengekspor [getPoints](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotioncmdpath/#getPointsType--), dan [isRelative](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotioncmdpath/#isRelative--). Contoh berikut menggunakan jalur tiga perintah yang diketahui dalam `motion.pptx`. Untuk input acak, temukan efek yang dimaksud dan periksa tipe perintah serta jumlah titik sebelum menyunting berdasarkan indeks.

### **Membaca Perintah dan Koordinat**

Baca jalur tanpa mengubahnya. Perintah end dan close-loop tidak memerlukan titik, jadi izinkan array titik null.

Output menggabungkan setiap tipe perintah numerik dengan flag koordinat relatifnya sebelum mencantumkan titik‑titiknya. Ini memungkinkan Anda membedakan titik akhir dari offset sebelum memodifikasi jalur. Kurva akan menampilkan tiga titik, sedangkan garis lurus dalam file ini hanya menampilkan satu.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Daftar berisi titik awal, garis absolut berakhir di (0,25, 0), dan perintah end.

### **Mengubah Titik Akhir**

Buka `motion.pptx` dan ganti array titik garis untuk memindahkan titik akhirnya.

Dalam file input, indeks 0 adalah perintah awal dan indeks 1 adalah garis. Mengganti satu titik garis mengubah tujuan tanpa mengubah tipe perintah, waktu, atau posisinya dalam koleksi. Karena perintah menggunakan koordinat absolut, pasangan baru menentukan posisi, bukan offset tambahan.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Garis dalam `motion-endpoint.pptx` berakhir di (0,4, 0,1); file asli tidak berubah.

### **Mengganti Segmen**

Gunakan [insert](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) dan [removeAt](https://reference.aspose.com/slides/id/java/com.aspose.slides/imotionpath/#removeAt-int-) untuk mengganti garis dalam `motion.pptx`. Penyisipan memindahkan garis lama ke indeks 2.

Ini menunjukkan cara mengganti objek perintah alih‑alih menyunting koordinatnya yang ada. Setelah penyisipan, koleksi sementara berisi perintah awal, garis baru, garis lama, dan perintah end. Menghapus indeks 2 membuang garis lama dan meninggalkan rute baru di tempatnya.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jalur yang disimpan masih memiliki tiga perintah, dengan garis baru berakhir di (0,2, 0,1) dan perintah end terakhir.

## **Mengubah dan Memverifikasi Perilaku yang Ada**

Ketika indeks perilaku tidak diketahui, pilih berdasarkan tipe. Contoh ini membuka `rotation.pptx`, menemukan [IRotationEffect](https://reference.aspose.com/slides/id/java/com.aspose.slides/irotationeffect/), mengubah sudut, dan memeriksa nilai yang disimpan setelah membuka kembali.

Pemeriksaan tipe memungkinkan loop melewati perilaku yang bukan rotasi. Pemuatan kedua membaca file yang disimpan ke objek presentasi terpisah, sehingga perbandingan memeriksa data yang dipertahankan, bukan nilai yang masih berada di memori. Contoh ini masih mengasumsikan efek yang diketahui berada pertama dalam urutan utama; memilih perilaku berdasarkan tipe tidak menemukan efek yang tepat dalam presentasi acak.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Outputnya `Rotation preserved: true`. Terapkan pola pemeriksaan tipe yang sama pada perilaku lain. Untuk pemeriksaan preservasi lengkap, bandingkan bentuk target, efek, tipe dan urutan perilaku, waktu, serta perintah jalur. Gunakan toleransi numerik untuk nilai floating‑point. Untuk presentasi dengan tata letak animasi tidak diketahui, lihat [Membaca Animasi Bentuk](/slides/id/java/shape-animation/#read-shape-animations) untuk penelusuran urutan utama dan interaktif.

## **Urutan Perilaku, Preset, dan Pemutaran**

Urutan dalam [IBehaviorCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehaviorcollection/) adalah urutan tersimpan operasi efek. Itu bukan daftar putar di mana setiap perilaku otomatis menunggu yang sebelumnya. Waktu dan efek yang membungkus menentukan penjadwalan. Perilaku dapat tumpang tindih, dan operasi pada properti yang sama dapat berinteraksi melalui [getAdditive](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehavior/#getAdditive--) dan [getAccumulate](https://reference.aspose.com/slides/id/java/com.aspose.slides/ibehavior/#getAccumulate--). Jangan gunakan pengurutan ulang koleksi saja untuk menjadwalkan “pindah, lalu putar”; gunakan waktu eksplisit atau efek terpisah seperti dijelaskan dalam [Animasi Bentuk](/slides/id/java/shape-animation/).

[getType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ieffect/#getType--) dan [getSubtype](https://reference.aspose.com/slides/id/java/com.aspose.slides/ieffect/#getSubtype--) efek menggambarkan presetnya. Mereka bukan deskripsi lengkap pohon perilaku yang disunting. Pilih preset dan subtype sebelum menyesuaikan perilaku: mengubah preset dapat membangun kembali koleksi dan membuang operasi khusus Anda. Misalnya, mengubah efek Spin yang disesuaikan menjadi Fade dapat mengganti perilaku rotasi dengan perilaku set dan filter. Periksa koleksi lagi setelah mengubah preset atau subtype. Mengosongkan perilaku preset juga dapat menghapus operasi visibilitas atau inisialisasi yang dibutuhkan preset. Contoh‑contoh sengaja menggunakan bentuk yang terlihat dan mengganti perilaku; mereka tidak membangun ulang implementasi setiap preset.

## **Kompatibilitas Format**

Pohon perilaku yang dipertahankan tidak menjamin pemutaran identik di setiap penampil atau renderer ekspor. Periksa data yang disimpan dan output yang dirender secara terpisah.

| Format atau output | Hal yang harus diverifikasi |
| --- | --- |
| PPTX | Gunakan sebagai format utama untuk contoh ini. Buka kembali untuk memverifikasi pohon perilaku yang dapat disunting, lalu periksa pemutaran pada versi PowerPoint yang dimaksud. |
| PPT | Representasi biner lama dapat berbeda dari PPTX. Uji siklus simpan‑buka‑kembali terpisah dan pemutaran; jangan menyimpulkan dukungan untuk setiap kombinasi khusus hanya dari output PPTX yang berhasil. |
| PDF, PNG, JPEG, dan gambar slide statis lainnya | Berisi representasi slide statis, bukan timeline perilaku yang dapat diputar atau frame animasi akhir yang dijamin. |
| [HTML5](/slides/id/java/export-to-html5/) | Dapat memutar animasi yang didukung ketika animasi bentuk diaktifkan dalam opsi ekspor. Uji kombinasi khusus di peramban. |
| [Animated GIF](/slides/id/java/convert-powerpoint-to-animated-gif/) | Menyimpan frame yang dirender, bukan perilaku yang dapat disunting atau interaksi klik. Periksa gerakan yang benar-benar dirender. |
| [Video](/slides/id/java/convert-powerpoint-to-video/) | Merender frame animasi dan mengenkodenya sebagai video. Dukungan terbatas pada [animasi dan efek yang didukung](/slides/id/java/convert-powerpoint-to-video/#supported-animations-and-effects); perintah dan peristiwa interaktif tidak menjadi timeline yang dapat disunting. |

## **FAQ**

**Mengapa efek saya berisi perilaku sebelum saya menambahkan apa pun?**

Membuat efek yang telah ditentukan dapat membuat operasi dasarnya. Periksa mereka sebelum memutuskan apakah akan memperluas preset atau mengganti perilakunya.

**Apakah memindahkan perilaku ke awal membuatnya diputar pertama?**

Tidak selalu. Urutan koleksi bukan pengganti waktu. Periksa penundaan, durasi, dan interaksi antar operasi pada properti yang sama.

**Mengapa perintah end tidak memiliki titik?**

Itu menandakan akhir jalur dan tidak memerlukan koordinat. Periksa array titik null saat memeriksa jalur yang dibaca dari file.

**Apakah perjalanan bolak‑balik yang berhasil cukup untuk mengonfirmasi pemutaran?**

Tidak. Membuka kembali mengonfirmasi preservasi properti yang Anda periksa. Uji pemutar slideshow atau ekspor animasi secara terpisah untuk mengonfirmasi perilaku visualnya.