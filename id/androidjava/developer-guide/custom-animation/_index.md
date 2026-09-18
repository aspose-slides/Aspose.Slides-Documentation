---
title: Buat dan Modifikasi Perilaku Animasi Kustom pada Android
linktitle: Animasi Kustom
type: docs
weight: 151
url: /id/androidjava/custom-animation/
keywords:
- animasi kustom
- perilaku animasi
- jalur gerak
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat, periksa, dan modifikasi perilaku animasi kustom serta jalur gerak yang dapat diedit dalam presentasi PowerPoint dengan Aspose.Slides untuk Android melalui Java."
---
## **Gambaran Umum**

Perilaku animasi khusus memungkinkan Anda mengontrol operasi individu dalam sebuah efek animasi, seperti mengubah warna, memutar bentuk, atau mengikuti jalur gerakan yang dapat diedit. Panduan ini menunjukkan cara membuat dan menggabungkan perilaku, mengonfigurasi penjadwalannya, memeriksa dan mengubah animasi yang ada, serta memverifikasi bahwa propertinya tetap ada setelah menyimpan dan membuka kembali presentasi.

Untuk efek yang telah ditentukan sebelumnya dan pemicu klik, lihat [Animasi Bentuk](/slides/id/androidjava/shape-animation/).

## **Memahami Model Animasi**

Sebuah animasi diatur sebagai **Timeline → Sequence → Effect → Behaviors**:

- Metode [getTimeline](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseslide/#getTimeline--) mengembalikan timeline slide, yang berisi urutan utama dan urutan interaktif.
- Sebuah [ISequence](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isequence/) berisi efek, yang mungkin menargetkan berbagai bentuk.
- Sebuah [IEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/) mengidentifikasi bentuk target, preset, subtype, dan penjadwalan efek.
- Koleksi yang dikembalikan oleh [IEffect.getBehaviors](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/#getBehaviors--) berisi operasi yang melaksanakan efek: mengubah warna, memindahkan, memutar, mengatur properti, dan sebagainya.

## **Buat Perilaku Individu**

Panggil [ISequence.addEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) untuk membuat efek dan mengakses koleksi [getBehaviors](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/#getBehaviors--). Sebuah preset dapat mengisi koleksi ini secara otomatis. Pertahankan operasinya ketika memperluas preset, atau gunakan [clear](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorcollection/#clear--) bila sengaja menggantinya.

[IBehaviorFactory](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorfactory/) membuat delapan tipe perilaku yang diilustrasikan di bawah. Gerakan dibahas di [Membangun Jalur Gerak](#build-a-motion-path). Setiap potongan kode menyertakan impor; letakkan pernyataan yang dapat dieksekusi di dalam sebuah metode. Contoh penyuntingan selanjutnya menyatakan file keluaran yang digunakan. Pada Android, ganti nama file contoh dengan jalur lengkap di direktori yang dapat diakses aplikasi, seperti direktori file aplikasi Anda.

### **Rotasi**

Gunakan [createRotationEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) untuk membuat rotasi. [getBy](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/irotationeffect/#getBy--) menentukan sudut relatif dalam derajat; [getFrom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/irotationeffect/#getFrom--) dan [getTo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/irotationeffect/#getTo--) menentukan titik akhir.

Contoh dimulai dengan efek Spin, mengganti operasi presetnya dengan satu perilaku rotasi, dan memberikan operasi tersebut durasi dua detik. Sudut relatif 90 derajat menyatakan seperempat putaran dari orientasi awal bentuk, sehingga tidak diperlukan sudut awal yang eksplisit.

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

`rotation.pptx` berisi satu bentuk dan satu perilaku rotasi. Koleksi, penjadwalan, dan contoh penyuntingan rotasi di bawah menggunakan file ini.

### **Skala**

Gunakan [createScaleEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) dengan persentase X/Y: [getFrom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iscaleeffect/#getFrom--) dan [getTo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iscaleeffect/#getTo--) menjelaskan ukuran awal dan akhir, sementara [getBy](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iscaleeffect/#getBy--) menjelaskan perubahan relatif. Di sini, 100 berarti ukuran asli.

Contoh memperbesar kedua dimensi dari 100 % ke 125 % selama dua detik. Menggunakan persentase horizontal dan vertikal yang sama menjaga proporsi bentuk; persentase berbeda akan meregangkan satu dimensi lebih dari yang lain.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new PointF(100, 100));
    scale.setTo(new PointF(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Warna**

Gunakan [createColorEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorfactory/#createColorEffect--) untuk mengubah isi dari biru ke oranye. [getFrom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icoloreffect/#getFrom--) dan [getTo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icoloreffect/#getTo--) adalah warna; [getBy](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icoloreffect/#getBy--) adalah offset warna. [IBehavior.getProperties](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehavior/#getProperties--) mengidentifikasi atribut yang dianimasikan.

Isi padat bentuk diinisialisasi ke biru, sesuai dengan warna awal animasi. Memilih atribut isi‑warna memberi tahu perilaku bagian mana dari bentuk yang akan diubah; titik akhir warna saja tidak mengidentifikasi atribut tersebut. Efek yang disimpan mendeskripsikan transisi dua detik ke oranye.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int orange = Color.rgb(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filter**

Gunakan [createFilterEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) untuk memilih wipe. [getType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifiltereffect/#getSubtype--), dan [getReveal](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifiltereffect/#getReveal--) menentukan filter, arah, dan apakah menampilkan atau menyembunyikan bentuk.

Contoh ini mengonfigurasi wipe dua detik yang menampilkan bentuk menggunakan subtype arah kanan. Pengaturan filter merupakan bagian dari perilaku di dalam efek, sehingga dikonfigurasi setelah operasi asli preset dihapus.

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

Gunakan [createPropertyEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) untuk menganimasikan opasitas. [getFrom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipropertyeffect/#getTo--), dan [getBy](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipropertyeffect/#getBy--) adalah string yang diinterpretasikan menggunakan [getValueType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipropertyeffect/#getValueType--) dan [getCalcMode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipropertyeffect/#getCalcMode--). Pilih titik akhir atau offset relatif daripada mengatur ketiganya secara serempak.

Di sini, atribut yang dipilih adalah opasitas, dan string numerik mewakili perubahan dari 25 % opasitas ke opasitas penuh. Interpolasi linier menggambarkan perubahan bertahap antara nilai‑nilai tersebut. Saat menyesuaikan contoh ini ke atribut lain, pilih tipe nilai dan nilai titik akhir yang sesuai dengan atribut tersebut.

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

### **Setel**

Gunakan [createSetEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorfactory/#createSetEffect--) untuk menetapkan visibilitas melalui [getTo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iseteffect/#getTo--). Perilaku set tidak melakukan interpolasi antara titik akhir.

Contoh memilih atribut visibilitas dan menetapkan string `visible` ketika perilaku dijalankan. Persegi panjang sudah terlihat dalam presentasi minimal ini, sehingga penetapan tersebut mungkin tidak menghasilkan perubahan visual yang jelas secara terpisah. Operasi semacam ini berguna sebagai bagian dari efek yang lebih besar yang juga mengontrol kapan bentuk menjadi tersembunyi atau terlihat.

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

Gunakan [createCommandEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) dan konfigurasikan [getType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icommandeffect/#getCommandString--), serta [getShapeTarget](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icommandeffect/#getShapeTarget--). Letakkan rekaman WAV bernama `sample.wav` di direktori kerja. Contoh ini menyematkannya dengan [addAudioFrameEmbedded](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) dan menempelkan perintah play ke frame audio.

Frame audio adalah target efek sekaligus target perintah. Ini menghubungkan permintaan play ke rekaman yang disematkan; string perintah sendiri tidak mengidentifikasi objek media mana yang harus dikendalikan. Efek dikonfigurasikan untuk dimulai pada klik selama pertunjukan slide.

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

Menyimpan menyimpan perintah dalam `command.pptx`; tidak memutar rekaman. Pemutaran memerlukan pemutar pertunjukan slide yang mendukung perintah dan target medianya.

## **Kelola Koleksi Perilaku**

[IBehaviorCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorcollection/) mendukung [add](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), dan [removeAt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Contoh ini membuka `rotation.pptx`, menambahkan skala, memindahkannya sebelum rotasi, dan menghapus rotasi. Menghapus dan menyisipkan kembali objek yang sama mengubah posisi yang disimpannya tanpa membuat salinan.

Urutan penyuntingan mengubah koleksi dari rotasi‑skala menjadi skala‑rotasi, lalu menjadi hanya skala. Indeks mengacu pada koleksi saat ini, sehingga penghapusan menggunakan indeks baru rotasi setelah penataan ulang. Enumerasi akhir mengonfirmasi perilaku mana yang akan disimpan.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new PointF(125, 125));
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

Keluaran adalah `ScaleEffect`: hanya skala yang tersisa. Urutan koleksi tidak, dengan sendirinya, menjadwalkan perilaku satu demi satu. Kosongkan koleksi hanya ketika mengganti semua operasinya.

## **Konfigurasikan Penjadwalan Perilaku**

[IBehavior.getTiming](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehavior/#getTiming--) mengekspose [ITiming](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/), terlepas dari [IEffect.getTiming](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/#getTiming--). Penjadwalan efek mengatur efek yang membungkus; penjadwalan perilaku menjelaskan operasi di dalamnya.

### **Atur Durasi, Penundaan, Pengulangan, dan Akselerasi**

Buka `rotation.pptx` dan atur durasi ([getDuration](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getDuration--)) serta penundaan pemicu ([getTriggerDelayTime](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)) dalam detik, kemudian konfigurasikan jumlah pengulangan melalui [setRepeatCount](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getAccelerate--) dan [getDecelerate](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getDecelerate--) adalah pecahan dari durasi; pertahankan jumlahnya maksimum 1.

File masukan adalah file yang dibuat pada contoh rotasi, di mana perilaku pertama diketahui merupakan rotasi. Contoh ini hanya mengubah penjadwalan perilaku itu; sudut 90 derajat tetap utuh. Memisahkan sudut dan penjadwalan membuat penyesuaian kecepatan lebih mudah tanpa membangun ulang animasi.

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

Perilaku menggunakan durasi dua detik, penundaan setengah detik, dan hitungan pengulangan 3. 20 % pertama dan terakhir dari durasinya digunakan untuk akselerasi dan deselerasi.

Kebijakan pengulangan lain meliputi [getRepeatDuration](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), dan [getRepeatUntilNextClick](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--); pilih satu kebijakan alih-alih mengaktifkan semuanya sekaligus. [getAutoReverse](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itiming/#getAutoReverse--) memutar animasi mundur setelah putaran maju. Akselerasi dan deselerasi berlaku untuk perubahan kontinu, bukan penetapan diskrit atau perintah.

## **Bangun Jalur Gerak**

Gunakan [createMotionEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) untuk membuat gerakan. [getFrom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotioneffect/#getTo--), dan [getBy](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotioneffect/#getBy--) menjelaskan koordinat atau offset berbasis persentase. Untuk rute yang dapat diedit, buat sebuah [MotionPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/motionpath/) dan tetapkan dengan [IMotionEffect.setPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotionpath/) menyimpan perintah jalur.

[MotionCommandPathType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/motioncommandpathtype/) memilih operasi:

| Perintah | Titik | Makna |
| --- | --- | --- |
| MoveTo | Satu | Menetapkan posisi awal. |
| LineTo | Satu | Menggerakkan sepanjang segmen lurus ke titik akhirnya. |
| CurveTo | Tiga | Mengikuti kurva kubik yang didefinisikan oleh dua titik kontrol dan satu titik akhir. |
| CloseLoop | Tidak ada | Kembali ke posisi awal. |
| End | Tidak ada | Mengakhiri jalur. |

[MotionPathPointsType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/motionpathpointstype/) menggambarkan karakteristik penyuntingan titik, seperti titik sudut atau halus. Ini tidak menggantikan tipe perintah. Gunakan tipe titik kurva untuk contoh kurva di bawah, dan tipe titik sudut untuk segmen lurus.

Koordinat jalur dinormalisasi terhadap dimensi slide: perpindahan X sebesar 0.25 mewakili seperempat lebar slide, bukan 0.25 poin. Y positif mengalir ke bawah. Perintah absolut menentukan posisi dalam sistem koordinat jalur; perintah relatif menentukan offset dari posisi saat ini. Ini terpisah dari [getOrigin](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotioneffect/#getOrigin--), yang memilih kerangka referensi jalur, dan [getPathEditMode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotioneffect/#getPathEditMode--), yang mengontrol bagaimana jalur bergerak ketika bentuk dipindahkan.

### **Buat Jalur Lurus**

Buat perilaku gerak dengan titik awal, satu segmen lurus, dan perintah akhir. [IMotionPath.add](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotionpath/#add-int-android.graphics.PointF---int-boolean-) menerima tipe perintah, titik‑titiknya, tipe titik, dan flag koordinat relatif.

Perintah awal menetapkan (0, 0), dan garis berakhir di (0.25, 0), memberi rute perpindahan horizontal seperempat lebar slide. Perintah akhir tidak memiliki titik koordinat. Setelah jalur ditetapkan, menambahkan perilaku gerak ke efek menghubungkan rute tersebut ke persegi panjang.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
    path.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new PointF[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` berisi satu perilaku gerak dengan tiga perintah jalur. Contoh penyuntingan file berikut menggunakan struktur yang diketahui ini.

### **Bandingkan Koordinat Absolut dan Relatif**

Kedua objek jalur ini menggambarkan rute yang sama. Perintah absolut berakhir di (0.3, 0.1); perintah relatif menambahkan (0.1, 0.1) ke posisi saat ini, (0.2, 0).

Kedua jalur memulai pada posisi yang sama. Untuk garis relatif, tambahkan offset X dan Y ke posisi saat ini untuk memperoleh titik akhir; untuk garis absolut, baca titik akhir secara langsung. Mengubah flag tanpa mengonversi koordinat akan menghasilkan rute yang berbeda.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new PointF[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new PointF[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Tetapkan salah satu jalur ke perilaku gerak untuk menggunakannya dalam presentasi. Argumen Boolean terakhir memilih koordinat relatif untuk perintah tersebut.

### **Ganti Garis dengan Kurva**

Buka `motion.pptx` dan ganti perintah garisnya dengan kurva kubik. Sediakan dua titik kontrol terlebih dahulu, diikuti oleh titik akhir.

Posisi awal disediakan oleh perintah sebelumnya. Dua titik pertama membentuk kurva, sementara titik ketiga adalah tujuan akhir; mereka bukan tiga tujuan berurutan. Memperbarui tipe perintah, tipe penyuntingan titik, dan array titik secara bersamaan menjaga segmen tetap konsisten dengan geometri barunya.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new PointF[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jalur dalam `curve.pptx` masih memiliki tiga perintah; perintah tengahnya kini mendefinisikan sebuah kurva.

## **Periksa dan Edit Jalur yang Disimpan**

Setiap [IMotionCmdPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotioncmdpath/) mengekspose [getPoints](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotioncmdpath/#getPointsType--), dan [isRelative](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotioncmdpath/#isRelative--). Contoh berikut menggunakan jalur tiga perintah yang diketahui dalam `motion.pptx`. Untuk masukan acak, temukan efek yang dimaksud dan periksa tipe perintah serta jumlah titik sebelum menyunting berdasarkan indeks.

### **Baca Perintah dan Koordinat**

Baca jalur tanpa mengubahnya. Perintah end dan close‑loop tidak memerlukan titik, jadi sediakan array titik yang mungkin null.

Keluaran mencocokkan setiap tipe perintah numerik dengan flag koordinat relatifnya sebelum menyenaraikan titik‑titiknya. Ini memungkinkan Anda membedakan titik akhir dari offset sebelum memodifikasi jalur. Sebuah kurva akan menampilkan tiga titik, sedangkan garis lurus dalam file ini hanya menampilkan satu.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (PointF point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

Daftar berisi titik awal, garis absolut yang berakhir di (0.25, 0), dan perintah end.

### **Ubah Titik Akhir**

Buka `motion.pptx` dan ganti array titik garis untuk memindahkan titik akhirnya.

Dalam file masukan, indeks 0 adalah perintah awal dan indeks 1 adalah garis. Mengganti titik tunggal garis mengubah tujuan tanpa mengubah tipe perintah, penjadwalan, atau posisinya dalam koleksi. Karena perintah menggunakan koordinat absolut, pasangan baru menentukan posisi alih‑alih offset tambahan.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new PointF[] { new PointF(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Garis dalam `motion-endpoint.pptx` berakhir di (0.4, 0.1); file asli tidak berubah.

### **Ganti Segmen**

Gunakan [insert](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotionpath/#insert-int-int-android.graphics.PointF---int-boolean-) dan [removeAt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imotionpath/#removeAt-int-) untuk mengganti garis dalam `motion.pptx`. Penyisipan menggeser garis lama ke indeks 2.

Ini mendemonstrasikan penggantian objek perintah alih‑alih menyunting koordinat yang ada. Setelah penyisipan, koleksi sementara berisi perintah awal, garis baru, garis lama, dan perintah end. Menghapus indeks 2 membuang garis lama dan meninggalkan rute baru.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new PointF[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jalur yang disimpan masih memiliki tiga perintah, dengan garis baru berakhir di (0.2, 0.1) dan perintah end terakhir.

## **Modifikasi dan Verifikasi Perilaku yang Ada**

Ketika indeks perilaku tidak diketahui, pilih berdasarkan tipe. Contoh ini membuka `rotation.pptx`, menemukan [IRotationEffect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/irotationeffect/), mengubah sudut, dan memeriksa nilai yang disimpan setelah dibuka kembali.

Pemeriksaan tipe memungkinkan loop melewatkan perilaku yang bukan rotasi. Muat kedua membaca file yang disimpan ke objek presentasi terpisah, sehingga perbandingan memeriksa data yang dipertahankan, bukan nilai yang masih berada di memori. Contoh ini masih mengasumsikan efek yang diketahui berada pertama dalam urutan utama; memilih perilaku berdasarkan tipe tidak menemukan efek yang tepat dalam presentasi acak.

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

Keluaran adalah `Rotation preserved: true`. Terapkan pola pemeriksaan tipe yang sama untuk perilaku lain. Untuk pemeriksaan preservasi yang lengkap, bandingkan bentuk target, efek, tipe dan urutan perilaku, penjadwalan, serta perintah jalur. Gunakan toleransi numerik untuk nilai floating‑point. Untuk presentasi dengan tata letak animasi yang tidak diketahui, lihat [Read Shape Animations](/slides/id/androidjava/shape-animation/#read-shape-animations) untuk menelusuri urutan utama dan interaktif.

## **Urutan Perilaku, Preset, dan Pemutaran**

Urutan dalam [IBehaviorCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehaviorcollection/) adalah urutan yang disimpan dari operasi efek. Itu bukan playlist di mana setiap perilaku secara otomatis menunggu perilaku sebelumnya. Penjadwalan dan efek yang membungkus menentukan penjadwalan. Perilaku dapat tumpang‑tindih, dan operasi pada properti yang sama dapat berinteraksi melalui [getAdditive](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehavior/#getAdditive--) dan [getAccumulate](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibehavior/#getAccumulate--). Jangan menggunakan penataan ulang koleksi saja untuk menjadwalkan “pindah, lalu putar”; gunakan penjadwalan eksplisit atau efek terpisah seperti dijelaskan di [Animasi Bentuk](/slides/id/androidjava/shape-animation/).

[ieffect.getType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/#getType--) dan [ieffect.getSubtype](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ieffect/#getSubtype--) menggambarkan presetnya. Itu bukan deskripsi lengkap dari pohon perilaku yang disunting. Pilih preset dan subtype sebelum menyesuaikan perilaku: mengubah preset dapat membangun kembali koleksi dan membuang operasi khusus Anda. Misalnya, mengubah efek Spin yang disesuaikan menjadi Fade dapat mengganti perilaku rotasi dengan perilaku set dan filter. Periksa kembali koleksi setelah mengubah preset atau subtype. Mengosongkan perilaku preset juga dapat menghapus operasi visibilitas atau inisialisasi yang dibutuhkan preset. Contoh sengaja menggunakan bentuk yang terlihat dan mengganti perilakunya; mereka tidak membangun ulang implementasi setiap preset.

## **Kompatibilitas Format**

Pohon perilaku yang dipertahankan tidak menjamin pemutaran identik di setiap penampil atau renderer ekspor. Periksa data yang disimpan dan output yang dirender secara terpisah.

| Format atau output | Apa yang harus diverifikasi |
| --- | --- |
| PPTX | Gunakan sebagai format utama untuk contoh ini. Buka kembali untuk memverifikasi pohon perilaku yang dapat diedit, lalu periksa pemutaran pada versi PowerPoint yang dituju. |
| PPT | Representasi biner lama dapat berbeda dari PPTX. Uji siklus simpan‑dan‑buka terpisah serta pemutaran; jangan menyimpulkan dukungan untuk setiap kombinasi khusus hanya dari output PPTX yang berhasil. |
| PDF, PNG, JPEG, dan gambar slide statis lainnya | Berisi representasi slide statis, bukan timeline perilaku yang dapat diputar atau frame animasi akhir yang dijamin. |
| [HTML5](/slides/id/androidjava/export-to-html5/) | Dapat memutar animasi yang didukung ketika animasi bentuk diaktifkan dalam opsi ekspor. Uji kombinasi khusus di peramban. |
| [Animated GIF](/slides/id/androidjava/convert-powerpoint-to-animated-gif/) | Menyimpan frame yang dirender, bukan perilaku yang dapat diedit atau interaksi klik. Periksa gerakan yang sebenarnya dirender. |
| [Video](/slides/id/androidjava/convert-powerpoint-to-video/) | Merender frame animasi dan mengenkodenya sebagai video. Dukungan terbatas pada [animasi dan efek yang didukung](/slides/id/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects); perintah dan event interaktif tidak menjadi timeline yang dapat diedit. |

## **FAQ**

**Mengapa efek saya berisi perilaku sebelum saya menambahkan apa pun?**

Membuat efek yang telah ditentukan sebelumnya dapat membuat operasi dasarnya. Periksa mereka sebelum memutuskan memperluas preset atau mengganti perilakunya.

**Apakah memindahkan perilaku ke awal membuatnya diputar pertama?**

Tidak selalu. Urutan koleksi bukan pengganti penjadwalan. Periksa penundaan, durasi, dan interaksi antara operasi pada properti yang sama.

**Mengapa perintah end tidak memiliki titik?**

Itu menandai akhir jalur dan tidak memerlukan koordinat. Periksa array titik null saat memeriksa jalur yang dibaca dari file.

**Apakah putaran sukses cukup untuk mengonfirmasi pemutaran?**

Tidak. Membuka kembali mengonfirmasi preservasi properti yang Anda periksa. Uji pemutar pertunjukan slide atau ekspor animasi secara terpisah untuk mengonfirmasi perilaku visualnya.