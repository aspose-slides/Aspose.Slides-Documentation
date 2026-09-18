---
title: Membuat dan Memodifikasi Perilaku Animasi Kustom dalam Python via Java
linktitle: Animasi Kustom
type: docs
weight: 151
url: /id/python-java/custom-animation/
keywords:
- animasi kustom
- perilaku animasi
- jalur gerak
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Membuat, memeriksa, dan memodifikasi perilaku animasi kustom serta jalur gerak yang dapat diedit dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Perilaku animasi khusus memungkinkan Anda mengendalikan operasi individu dalam efek animasi, seperti mengubah warna, memutar bentuk, atau mengikuti jalur gerak yang dapat diedit. Panduan ini menunjukkan cara membuat dan menggabungkan perilaku, mengonfigurasi penjadwalannya, memeriksa dan mengubah animasi yang ada, serta memverifikasi bahwa propertinya tetap terjaga setelah menyimpan dan membuka kembali presentasi.

Untuk efek bawaan dan pemicu klik, lihat [Animasi Bentuk](/slides/id/python-java/shape-animation/).

## **Memahami Model Animasi**

Animasi disusun sebagai **Timeline → Sequence → Effect → Behaviors**:

- Metode [getTimeline](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getTimeline) mengembalikan timeline slide, yang berisi urutan utama dan urutan interaktif.
- Sebuah [Sequence](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/) berisi efek, yang mungkin menargetkan bentuk berbeda.
- Sebuah [Effect](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/) mengidentifikasi bentuk target, preset, subtype, dan penjadwalan efek.
- Koleksi yang dikembalikan oleh [Effect.getBehaviors](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/#getBehaviors) berisi operasi yang mengimplementasikan efek: mengubah warna, memindahkan, memutar, menetapkan properti, dan sebagainya.

## **Membuat Perilaku Individu**

Panggil [Sequence.addEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/sequence/#addEffect) untuk membuat efek dan mengakses koleksi [getBehaviors](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/#getBehaviors). Sebuah preset dapat mengisi koleksi ini secara otomatis. Pertahankan operasinya saat memperluas preset, atau gunakan [clear](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorcollection/#clear) ketika sengaja menggantinya.

[BehaviorFactory](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorfactory/) membuat delapan tipe perilaku yang diilustrasikan di bawah ini. Gerakan dibahas pada [Membangun Jalur Gerak](#build-a-motion-path). Setiap cuplikan menyertakan impor dan memulai JVM bila diperlukan. Objek titik dan array Java dibuat melalui JPype bila API memerlukannya. Contoh penyuntingan selanjutnya menyebutkan file output yang digunakan.

### **Rotasi**

Gunakan [createRotationEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorfactory/#createRotationEffect) untuk membuat rotasi. [getBy](https://reference.aspose.com/slides/id/python-java/aspose.slides/rotationeffect/#getBy) menentukan sudut relatif dalam derajat; [getFrom](https://reference.aspose.com/slides/id/python-java/aspose.slides/rotationeffect/#getFrom) dan [getTo](https://reference.aspose.com/slides/id/python-java/aspose.slides/rotationeffect/#getTo) menentukan titik akhir.

Contoh dimulai dengan efek Spin, mengganti operasi presetnya dengan satu perilaku rotasi, dan memberi operasi tersebut durasi dua detik. Sudut relatif 90 derajat menyatakan seperempat putaran dari orientasi awal bentuk, jadi tidak diperlukan sudut awal yang eksplisit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` berisi satu bentuk dan satu perilaku rotasi. Koleksi, penjadwalan, dan contoh penyuntingan rotasi di bawah ini menggunakan file tersebut.

### **Skala**

Gunakan [createScaleEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorfactory/#createScaleEffect) dengan persentase X/Y: [getFrom](https://reference.aspose.com/slides/id/python-java/aspose.slides/scaleeffect/#getFrom) dan [getTo](https://reference.aspose.com/slides/id/python-java/aspose.slides/scaleeffect/#getTo) menggambarkan ukuran awal dan akhir, sementara [getBy](https://reference.aspose.com/slides/id/python-java/aspose.slides/scaleeffect/#getBy) menggambarkan perubahan relatif. Di sini, 100 berarti ukuran asli.

Contoh memperbesar kedua dimensi dari 100 % ke 125 % selama dua detik. Menggunakan persentase horizontal dan vertikal yang sama menjaga proporsi bentuk; persentase yang berbeda akan meregangkan satu dimensi lebih dari yang lain.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Warna**

Gunakan [createColorEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorfactory/#createColorEffect) untuk mengubah isian dari biru ke oranye. [getFrom](https://reference.aspose.com/slides/id/python-java/aspose.slides/coloreffect/#getFrom) dan [getTo](https://reference.aspose.com/slides/id/python-java/aspose.slides/coloreffect/#getTo) adalah warna; [getBy](https://reference.aspose.com/slides/id/python-java/aspose.slides/coloreffect/#getBy) adalah offset warna. [Behavior.getProperties](https://reference.aspose.com/slides/id/python-java/aspose.slides/behavior/#getProperties) mengidentifikasi atribut yang dianimasikan.

Isian padat bentuk diinisialisasi ke biru, cocok dengan warna awal animasi. Memilih atribut isian-warna memberi tahu perilaku bagian mana dari bentuk yang harus diubah; hanya titik akhir warna tidak mengidentifikasi atribut tersebut. Efek yang disimpan menggambarkan transisi dua detik ke oranye.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Filter**

Gunakan [createFilterEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorfactory/#createFilterEffect) untuk memilih wipe. [getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/id/python-java/aspose.slides/filtereffect/#getSubtype), dan [getReveal](https://reference.aspose.com/slides/id/python-java/aspose.slides/filtereffect/#getReveal) menentukan filter, arah, dan apakah mengungkap atau menyembunyikan bentuk.

Contoh ini mengonfigurasi wipe dua detik yang mengungkap bentuk menggunakan subtype arah kanan. Pengaturan filter merupakan bagian dari perilaku di dalam efek, sehingga dikonfigurasi setelah operasi asli preset dihapus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Properti**

Gunakan [createPropertyEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) untuk menganimasikan opasitas. [getFrom](https://reference.aspose.com/slides/id/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/id/python-java/aspose.slides/propertyeffect/#getTo), dan [getBy](https://reference.aspose.com/slides/id/python-java/aspose.slides/propertyeffect/#getBy) adalah string yang diinterpretasikan menggunakan [getValueType](https://reference.aspose.com/slides/id/python-java/aspose.slides/propertyeffect/#getValueType) dan [getCalcMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/propertyeffect/#getCalcMode). Pilih titik akhir atau offset relatif daripada menetapkan ketiganya secara bersamaan.

Di sini, atribut yang dipilih adalah opasitas, dan string numerik mewakili perubahan dari 25 % opasitas ke opasitas penuh. Interpolasi linear menggambarkan perubahan bertahap antara nilai tersebut. Saat menyesuaikan contoh ini ke atribut lain, pilih tipe nilai dan nilai titik akhir yang sesuai dengan atribut tersebut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Set**

Gunakan [createSetEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorfactory/#createSetEffect) untuk menetapkan visibilitas melalui [getTo](https://reference.aspose.com/slides/id/python-java/aspose.slides/seteffect/#getTo). Perilaku set tidak melakukan interpolasi antara titik akhir.

Contoh memilih atribut visibilitas dan menetapkan string `visible` ketika perilaku dijalankan. Persegi panjang sudah terlihat dalam presentasi minimal ini, sehingga penetapan mungkin tidak menghasilkan perubahan visual yang jelas dengan sendirinya. Operasi semacam ini berguna sebagai bagian dari efek yang lebih besar yang juga mengontrol kapan bentuk menjadi tersembunyi atau terlihat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Perintah**

Gunakan [createCommandEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorfactory/#createCommandEffect) dan konfigurasikan [getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/id/python-java/aspose.slides/commandeffect/#getCommandString), serta [getShapeTarget](https://reference.aspose.com/slides/id/python-java/aspose.slides/commandeffect/#getShapeTarget). Letakkan rekaman WAV bernama `sample.wav` di direktori kerja. Contoh ini menyematkannya dengan [addAudioFrameEmbedded](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) dan menambahkan perintah putar ke frame audio.

Frame audio adalah target efek dan juga target perintah. Ini menghubungkan permintaan putar ke rekaman yang disematkan; string perintah saja tidak mengidentifikasi objek media mana yang dikontrol. Efek dikonfigurasikan untuk dimulai pada klik selama tayangan slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Menyimpan menaruh perintah dalam `command.pptx`; tidak diputar saat disimpan. Pemutaran memerlukan pemutar tayangan slide yang mendukung perintah dan target medianya.

## **Mengelola Koleksi Perilaku**

[BehaviorCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorcollection/) mendukung [add](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorcollection/#remove), dan [removeAt](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorcollection/#removeAt). Contoh ini membuka `rotation.pptx`, menambahkan skala, memindahkannya sebelum rotasi, dan menghapus rotasi. Menghapus dan memasukkan kembali objek yang sama mengubah posisi yang tersimpan tanpa membuat salinan.

Urutan penyuntingan mengubah koleksi dari rotasi‑skala menjadi skala‑rotasi, lalu menjadi hanya skala. Indeks mengacu pada koleksi saat ini, sehingga penghapusan menggunakan indeks baru rotasi setelah diatur ulang. Enumerasi akhir mengonfirmasi perilaku mana yang akan disimpan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Outputnya adalah `ScaleEffect`: hanya skala yang tersisa. Urutan koleksi tidak, dengan sendirinya, menjadwalkan perilaku satu demi satu. Bersihkan koleksi hanya ketika mengganti semua operasinya.

## **Mengonfigurasi Penjadwalan Perilaku**

[Behavior.getTiming](https://reference.aspose.com/slides/id/python-java/aspose.slides/behavior/#getTiming) menampilkan [Timing](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/), terpisah dari [Effect.getTiming](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/#getTiming). Penjadwalan efek mengatur efek yang mengelilinginya; penjadwalan perilaku menggambarkan operasi di dalamnya.

### **Menetapkan Durasi, Penundaan, Pengulangan, dan Akselerasi**

Buka `rotation.pptx` dan tetapkan durasi ([getDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getDuration)) serta penundaan pemicu ([getTriggerDelayTime](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getTriggerDelayTime)) dalam detik, lalu konfigurasikan jumlah pengulangan melalui [setRepeatCount](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getAccelerate) dan [getDecelerate](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getDecelerate) adalah pecahan dari durasi; pastikan jumlahnya tidak lebih dari 1.

File masukan adalah yang dibuat pada contoh rotasi, di mana perilaku pertama diketahui berupa rotasi. Contoh ini hanya mengubah penjadwalan perilaku itu; sudut 90 derajat tetap tidak berubah. Memisahkan sudut dan penjadwalan memudahkan penyesuaian kecepatan tanpa membangun ulang animasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Perilaku menggunakan durasi dua detik, penundaan setengah detik, dan jumlah pengulangan 3. 20 % pertama dan terakhir durasinya dipakai untuk akselerasi dan deselerasi.

Kebijakan pengulangan lain meliputi [getRepeatDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getRepeatUntilEndSlide), dan [getRepeatUntilNextClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getRepeatUntilNextClick); pilih satu kebijakan daripada mengaktifkan semuanya sekaligus. [getAutoReverse](https://reference.aspose.com/slides/id/python-java/aspose.slides/timing/#getAutoReverse) memutar animasi mundur setelah putaran maju. Akselerasi dan deselerasi berlaku pada perubahan kontinu, bukan pada penetapan diskrit atau perintah.

## **Membangun Jalur Gerak**

Gunakan [createMotionEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorfactory/#createMotionEffect) untuk membuat gerak. [getFrom](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioneffect/#getTo), dan [getBy](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioneffect/#getBy) menggambarkan koordinat atau offset berbasis persentase. Untuk rute yang dapat diedit, buat [MotionPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/motionpath/) dan tetapkan dengan [MotionEffect.setPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/motionpath/) menyimpan perintah jalur.

[MotionCommandPathType](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioncommandpathtype/) memilih operasi:

| Perintah | Titik | Arti |
| --- | --- | --- |
| MoveTo | Satu | Menetapkan posisi awal. |
| LineTo | Satu | Bergerak lurus ke titik akhir segmen. |
| CurveTo | Tiga | Mengikuti kurva kubik yang didefinisikan oleh dua titik kontrol dan satu titik akhir. |
| CloseLoop | Tidak ada | Kembali ke posisi awal. |
| End | Tidak ada | Mengakhiri jalur. |

[MotionPathPointsType](https://reference.aspose.com/slides/id/python-java/aspose.slides/motionpathpointstype/) mendeskripsikan karakteristik penyuntingan titik, seperti sudut atau titik halus. Ini tidak menggantikan tipe perintah. Gunakan tipe titik kurva untuk contoh kurva di bawah, dan tipe titik sudut untuk segmen lurus.

Koordinat jalur dinormalisasi ke dimensi slide: perpindahan X sebesar 0,25 mewakili seperempat lebar slide, bukan 0,25 poin. Y positif mengarah ke bawah. Perintah absolut menentukan posisi dalam sistem koordinat jalur; perintah relatif menentukan offset dari posisi saat ini. Ini terpisah dari [getOrigin](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioneffect/#getOrigin), yang memilih kerangka referensi jalur, dan [getPathEditMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioneffect/#getPathEditMode), yang mengontrol bagaimana jalur bergerak saat bentuk dipindahkan.

### **Membuat Jalur Lurus**

Buat perilaku gerak dengan titik awal, satu segmen lurus, dan perintah akhir. [MotionPath.add](https://reference.aspose.com/slides/id/python-java/aspose.slides/motionpath/#add) menerima tipe perintah, titik‑titiknya, tipe titik, dan flag koordinat relatif.

Perintah awal menetapkan (0, 0), dan garis berakhir di (0.25, 0), memberikan perpindahan horizontal seperempat lebar slide. Perintah akhir tidak memiliki titik koordinat. Setelah jalur ditetapkan, menambahkan perilaku gerak ke efek menghubungkan jalur tersebut ke persegi panjang.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` berisi satu perilaku gerak dengan tiga perintah jalur. Contoh penyuntingan file berikut menggunakan struktur yang diketahui ini.

### **Membandingkan Koordinat Absolut dan Relatif**

Kedua objek jalur ini menggambarkan rute yang sama. Perintah absolut berakhir di (0.3, 0.1); perintah relatif menambahkan (0.1, 0.1) ke posisi saat ini, (0.2, 0).

Kedua jalur mulai dari posisi yang sama. Untuk garis relatif, tambahkan offset X dan Y ke posisi saat ini untuk memperoleh titik akhir; untuk garis absolut, baca titik akhir secara langsung. Mengubah flag tanpa mengkonversi koordinat akan menghasilkan rute yang berbeda.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Tetapkan salah satu jalur ke perilaku gerak untuk menggunakannya dalam presentasi. Argumen Boolean terakhir memilih koordinat relatif untuk perintah itu.

### **Mengganti Garis dengan Kurva**

Buka `motion.pptx` dan ganti perintah garisnya dengan kurva kubik. Berikan dua titik kontrol terlebih dahulu, lalu titik akhir.

Posisi awal disediakan oleh perintah sebelumnya. Dua titik pertama membentuk kurva, sementara titik ketiga adalah tujuan; mereka bukan tiga tujuan berurutan. Memperbarui tipe perintah, tipe penyuntingan titik, dan array titik secara bersamaan menjaga segmen tetap konsisten dengan geometri barunya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jalur dalam `curve.pptx` masih memiliki tiga perintah; perintah tengah kini mendefinisikan kurva.

## **Memeriksa dan Menyunting Jalur yang Disimpan**

Setiap [MotionCmdPath](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioncmdpath/) menampilkan [getPoints](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioncmdpath/#getPointsType), dan [isRelative](https://reference.aspose.com/slides/id/python-java/aspose.slides/motioncmdpath/#isRelative). Contoh berikut menggunakan jalur tiga perintah yang diketahui dalam `motion.pptx`. Untuk masukan arbitrer, temukan efek yang dimaksud dan periksa tipe perintah serta jumlah titik sebelum menyunting berdasarkan indeks.

### **Membaca Perintah dan Koordinat**

Baca jalur tanpa mengubahnya. Perintah akhir dan tutup‑loop tidak memerlukan titik, jadi sediakan array titik null bila perlu.

Output menggabungkan setiap tipe perintah numerik dengan flag koordinat relatifnya sebelum menampilkan titik‑titiknya. Ini memungkinkan Anda membedakan titik akhir dari offset sebelum memodifikasi jalur. Kurva akan menampilkan tiga titik, sedangkan garis lurus dalam file ini hanya satu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

Daftar berisi titik awal, garis absolut yang berakhir di (0.25, 0), dan perintah akhir.

### **Mengubah Titik Akhir**

Buka `motion.pptx` dan ganti array titik garis untuk memindahkan titik akhirnya.

Dalam file masukan, indeks 0 adalah perintah awal dan indeks 1 adalah garis. Mengganti satu titik garis mengubah tujuan tanpa mengubah tipe perintah, penjadwalan, atau posisi dalam koleksi. Karena perintah menggunakan koordinat absolut, pasangan baru menentukan posisi, bukan offset tambahan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Garis dalam `motion-endpoint.pptx` berakhir di (0.4, 0.1); file asli tetap tidak berubah.

### **Mengganti Segmen**

Gunakan [insert](https://reference.aspose.com/slides/id/python-java/aspose.slides/motionpath/#insert) dan [removeAt](https://reference.aspose.com/slides/id/python-java/aspose.slides/motionpath/#removeAt) untuk mengganti garis dalam `motion.pptx`. Penyisipan menggeser garis lama ke indeks 2.

Ini mendemonstrasikan penggantian objek perintah daripada menyunting koordinat yang ada. Setelah penyisipan, koleksi sementara berisi perintah awal, garis baru, garis lama, dan perintah akhir. Menghapus indeks 2 membuang garis lama dan meninggalkan rute baru di tempatnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jalur yang disimpan masih memiliki tiga perintah, dengan garis baru berakhir di (0.2, 0.1) dan perintah akhir terakhir.

## **Memodifikasi dan Memverifikasi Perilaku yang Ada**

Ketika indeks perilaku tidak diketahui, pilih berdasarkan tipe. Contoh ini membuka `rotation.pptx`, menemukan [RotationEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/rotationeffect/), mengubah sudut, dan memeriksa nilai yang disimpan setelah membuka kembali.

Pemeriksaan tipe memungkinkan loop melewati perilaku yang bukan rotasi. Muatan kedua membaca file yang disimpan ke objek presentasi terpisah, sehingga perbandingan memeriksa data yang dipertahankan bukan nilai yang masih di memori. Contoh ini masih mengasumsikan efek yang diketahui berada pertama dalam urutan utama; memilih perilaku berdasarkan tipe tidak menjamin menemukan efek yang tepat dalam presentasi arbitrer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Outputnya `Rotation preserved: True`. Terapkan pola pemeriksaan tipe yang sama pada perilaku lain. Untuk pemeriksaan preservasi lengkap, bandingkan bentuk target, efek, tipe dan urutan perilaku, penjadwalan, serta perintah jalur. Gunakan toleransi numerik untuk nilai floating‑point. Untuk presentasi dengan tata letak animasi yang tidak diketahui, lihat [Membaca Animasi Bentuk](/slides/id/python-java/shape-animation/#read-shape-animations) untuk menelusuri urutan utama dan urutan interaktif.

## **Urutan Perilaku, Preset, dan Pemutaran**

Urutan dalam [BehaviorCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/behaviorcollection/) adalah urutan tersimpan operasi efek. Itu bukan playlist di mana setiap perilaku otomatis menunggu yang sebelumnya. Penjadwalan dan efek yang mengelilinginya menentukan urutan. Perilaku dapat tumpang tindih, dan operasi pada properti yang sama dapat berinteraksi melalui [getAdditive](https://reference.aspose.com/slides/id/python-java/aspose.slides/behavior/#getAdditive) dan [getAccumulate](https://reference.aspose.com/slides/id/python-java/aspose.slides/behavior/#getAccumulate). Jangan gunakan pengurutan koleksi saja untuk menjadwalkan “pindah, lalu putar”; gunakan penjadwalan eksplisit atau efek terpisah seperti yang dijelaskan di [Animasi Bentuk](/slides/id/python-java/shape-animation/).

[getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/#getType) dan [getSubtype](https://reference.aspose.com/slides/id/python-java/aspose.slides/effect/#getSubtype) efek mendeskripsikan presetnya. Mereka bukan deskripsi lengkap dari pohon perilaku yang disunting. Pilih preset dan subtype sebelum menyesuaikan perilaku: mengubah preset dapat membangun kembali koleksi dan membuang operasi khusus Anda. Misalnya, mengubah efek Spin yang disesuaikan menjadi Fade dapat menggantikan perilaku rotasi dengan perilaku set dan filter. Periksa koleksi lagi setelah mengubah preset atau subtype. Menghapus perilaku preset juga dapat menghilangkan operasi visibilitas atau inisialisasi yang diperlukan preset. Contoh sengaja menggunakan bentuk yang terlihat dan mengganti perilaku; mereka tidak membangun ulang implementasi setiap preset.

## **Kompatibilitas Format**

Pohon perilaku yang dipertahankan tidak menjamin pemutaran identik di setiap penampil atau renderer ekspor. Periksa data yang disimpan dan output yang dirender secara terpisah.

| Format atau output | Hal yang harus diverifikasi |
| --- | --- |
| PPTX | Gunakan sebagai format utama untuk contoh ini. Buka kembali untuk memverifikasi pohon perilaku yang dapat diedit, lalu periksa pemutaran di versi PowerPoint yang dimaksud. |
| PPT | Representasi biner legacy dapat berbeda dari PPTX. Lakukan siklus simpan‑buka‑ulang terpisah serta pemutaran; jangan menyimpulkan dukungan untuk setiap kombinasi khusus hanya dari output PPTX yang berhasil. |
| PDF, PNG, JPEG, dan gambar slide statis lainnya | Berisi representasi slide statis, bukan timeline perilaku yang dapat diputar atau frame animasi akhir yang dijamin. |
| [HTML5](/slides/id/python-java/export-to-html5/) | Dapat memutar animasi yang didukung ketika animasi bentuk diaktifkan dalam opsi ekspor. Uji kombinasi khusus di peramban. |
| [Animated GIF](/slides/id/python-java/convert-powerpoint-to-animated-gif/) | Menyimpan frame yang dirender, bukan perilaku yang dapat diedit atau interaksi yang dipicu klik. Periksa gerak yang sebenarnya dirender. |
| [Video](/slides/id/python-java/convert-powerpoint-to-video/) | Merender frame animasi dan mengenkode menjadi video. Dukungan terbatas pada [animasi dan efek yang didukung](/slides/id/python-java/convert-powerpoint-to-video/#supported-animations-and-effects); perintah dan acara interaktif tidak menjadi timeline yang dapat diedit. |

## **FAQ**

**Mengapa efek saya berisi perilaku sebelum saya menambahkan apa pun?**

Membuat efek yang telah ditentukan dapat membuat operasi dasarnya. Periksa sebelum memutuskan memperluas preset atau mengganti perilakunya.

**Apakah memindahkan perilaku ke awal membuatnya diputar pertama?**

Tidak selalu. Urutan koleksi bukan pengganti penjadwalan. Periksa penundaan, durasi, dan interaksi antara operasi pada properti yang sama.

**Mengapa perintah akhir tidak memiliki titik?**

Itu menandai akhir jalur dan tidak memerlukan koordinat. Periksa array titik null saat memeriksa jalur yang dibaca dari file.

**Apakah putaran berhasil cukup untuk mengonfirmasi pemutaran?**

Tidak. Membuka kembali mengonfirmasi preservasi properti yang Anda periksa. Uji pemutar tayangan slide atau ekspor animasi secara terpisah untuk memastikan perilaku visualnya.