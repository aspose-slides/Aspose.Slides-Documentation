---
title: Buat dan Modifikasi Perilaku Animasi Kustom dalam Python
linktitle: Animasi Kustom
type: docs
weight: 151
url: /id/python-net/custom-animation/
keywords:
- animasi kustom
- perilaku animasi
- jalur gerak
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Buat, periksa, dan modifikasi perilaku animasi kustom serta jalur gerak yang dapat diedit dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Perilaku animasi khusus memungkinkan Anda mengontrol operasi individual dalam efek animasi, seperti mengubah warna, memutar bentuk, atau mengikuti jalur gerak yang dapat diedit. Panduan ini menunjukkan cara membuat dan menggabungkan perilaku, mengkonfigurasi waktunya, memeriksa dan memodifikasi animasi yang ada, serta memverifikasi bahwa properti mereka tetap ada setelah menyimpan dan membuka kembali presentasi.

Untuk efek yang telah ditentukan dan pemicu klik, lihat [Animasi Bentuk](/slides/id/python-net/shape-animation/).

## **Memahami Model Animasi**

Sebuah animasi diatur sebagai **Timeline → Sequence → Effect → Behaviors**:

- Timeline slide [timeline](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/timeline/) berisi urutan utama dan urutan interaktif.
- Sebuah [Sequence](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/) berisi efek, yang dapat menargetkan berbagai bentuk.
- Sebuah [Effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/) mengidentifikasi bentuk target, preset, subtype, dan waktu efek.
- [Effect.behaviors](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/behaviors/) berisi operasi yang melaksanakan efek: mengubah warna, memindahkan, memutar, mengatur properti, dan sebagainya.

## **Buat Perilaku Individual**

Panggil [Sequence.add_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/add_effect/) untuk membuat efek dan mengakses koleksi [behaviors](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/behaviors/)‑nya. Sebuah preset dapat mengisi koleksi ini secara otomatis. Pertahankan operasinya saat memperluas preset, atau gunakan [clear](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorcollection/clear/) ketika sengaja menggantinya.

[BehaviorFactory](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorfactory/) membuat delapan tipe perilaku yang diilustrasikan di bawah ini. Gerakan dibahas di [Buat Jalur Gerak](#build-a-motion-path). Setiap contoh pembuatan adalah program lengkap; contoh penyuntingan selanjutnya menyebutkan file output yang digunakannya.

### **Rotasi**

Gunakan [create_rotation_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) untuk membuat rotasi. [by](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/rotationeffect/by/) menentukan sudut relatif dalam derajat; [from_address](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/rotationeffect/from_address/) dan [to](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/rotationeffect/to/) menentukan titik akhir.

Contoh dimulai dengan efek Spin, mengganti operasi presetnya dengan satu perilaku rotasi, dan memberikan durasi dua detik pada operasi tersebut. Sudut relatif 90 derajat menyatakan satu seperempat putaran dari orientasi awal bentuk, sehingga tidak diperlukan sudut awal yang eksplisit.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` berisi satu bentuk dan satu perilaku rotasi. Koleksi, penjadwalan waktu, dan contoh penyuntingan rotasi di bawah ini menggunakan file ini.

### **Skala**

Gunakan [create_scale_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) dengan persentase X/Y: [from_address](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/scaleeffect/from_address/) dan [to](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/scaleeffect/to/) menggambarkan ukuran awal dan akhir, sementara [by](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/scaleeffect/by/) menggambarkan perubahan relatif. Di sini, 100 berarti ukuran asli.

Contoh memperbesar kedua dimensi dari 100% menjadi 125% selama dua detik. Menggunakan persentase horizontal dan vertikal yang sama menjaga proporsi bentuk; persentase yang berbeda akan meregangkan satu dimensi lebih daripada yang lain.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Warna**

Gunakan [create_color_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) untuk mengubah isian dari biru ke oranye. [from_address](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/coloreffect/from_address/) dan [to](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/coloreffect/to/) adalah warna; [by](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/coloreffect/by/) adalah offset warna. [Behavior.properties](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behavior/properties/) mengidentifikasi atribut yang dianimasikan.

Isian solid bentuk diinisialisasi menjadi biru, cocok dengan warna awal animasi. Memilih atribut fill-color memberi tahu perilaku bagian mana dari bentuk yang akan diubah; titik akhir warna saja tidak mengidentifikasi atribut tersebut. Efek yang disimpan menggambarkan transisi dua detik ke oranye.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Filter**

Gunakan [create_filter_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) untuk memilih wipe. [type](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/filtereffect/subtype/), dan [reveal](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/filtereffect/reveal/) menentukan filter, arah, dan apakah akan menampilkan atau menyembunyikan bentuk.

Contoh ini mengkonfigurasi wipe dua detik yang menampilkan bentuk menggunakan subtype arah kanan. Pengaturan filter merupakan bagian dari perilaku di dalam efek, sehingga dikonfigurasi setelah operasi asli preset dihapus.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Properti**

Gunakan [create_property_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) untuk menganimasikan opasitas. [from_address](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/propertyeffect/to/), dan [by](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/propertyeffect/by/) adalah string yang ditafsirkan menggunakan [value_type](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/propertyeffect/value_type/) dan [calc_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Pilih titik akhir atau offset relatif daripada mengatur ketiganya sekaligus.

Di sini, atribut yang dipilih adalah opasitas, dan string numerik mewakili perubahan dari 25% opasitas ke opasitas penuh. Interpolasi linier menggambarkan perubahan bertahap antara nilai‑nilai tersebut. Saat menyesuaikan contoh ini ke atribut lain, pilih tipe nilai dan nilai titik akhir yang sesuai dengan atribut tersebut.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Set**

Gunakan [create_set_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) untuk menetapkan visibilitas melalui [to](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/seteffect/to/). Perilaku set tidak melakukan interpolasi antara titik akhir.

Contoh memilih atribut visibilitas dan menetapkan string `visible` saat perilaku dijalankan. Persegi panjang sudah terlihat dalam presentasi minimal ini, sehingga penetapan mungkin tidak menghasilkan perubahan visual yang jelas dengan sendirinya. Operasi semacam ini berguna sebagai bagian dari efek yang lebih besar yang juga mengontrol kapan bentuk menjadi tersembunyi atau terlihat.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Perintah**

Gunakan [create_command_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) dan atur [type](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/commandeffect/command_string/), dan [shape_target](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/commandeffect/shape_target/). Letakkan rekaman WAV bernama `sample.wav` di direktori kerja. Contoh ini menyematkannya dengan [add_audio_frame_embedded](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) dan menambahkan perintah play ke frame audio.

Frame audio merupakan target efek sekaligus target perintah. Ini menghubungkan permintaan play ke rekaman yang disematkan; string perintah sendiri tidak mengidentifikasi objek media mana yang harus dikendalikan. Efek dikonfigurasi untuk dimulai pada klik selama slideshow.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

Menyimpan menyimpan perintah dalam `command.pptx`; tidak memutar rekaman. Pemutaran memerlukan pemutar slideshow yang mendukung perintah dan target medianya.

## **Kelola Koleksi Perilaku**

[BehaviorCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorcollection/) mendukung [add](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorcollection/remove/), dan [remove_at](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorcollection/remove_at/). Contoh ini membuka `rotation.pptx`, menambahkan skala, memindahkannya sebelum rotasi, dan menghapus rotasi. Menghapus dan memasukkan kembali objek yang sama mengubah posisi yang disimpan tanpa membuat salinan.

Urutan penyuntingan mengubah koleksi dari rotation–scale menjadi scale–rotation, lalu menjadi hanya scale. Indeks merujuk ke koleksi saat ini, sehingga penghapusan menggunakan indeks baru rotasi setelah pengurutan ulang. Enumerasi akhir mengonfirmasi perilaku mana yang akan disimpan.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

Outputnya adalah `ScaleEffect`: hanya skala yang tetap. Urutan koleksi tidak, dengan sendirinya, menjadwalkan perilaku satu demi satu. Bersihkan koleksi hanya ketika mengganti semua operasinya.

## **Konfigurasikan Penjadwalan Perilaku**

[Behavior.timing](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behavior/timing/) menampilkan [Timing](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/), secara independen dari [Effect.timing](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/timing/). Penjadwalan efek mengatur efek yang membungkus; penjadwalan perilaku menggambarkan operasi di dalamnya.

### **Atur Durasi, Penundaan, Pengulangan, dan Akselerasi**

Buka `rotation.pptx` dan atur [duration](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/duration/) serta [trigger_delay_time](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/trigger_delay_time/) dalam detik, lalu konfigurasikan [repeat_count](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/accelerate/) dan [decelerate](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/decelerate/) adalah fraksi dari durasi; pastikan jumlahnya paling banyak 1.

File input adalah yang dibuat pada contoh rotasi, di mana perilaku pertama diketahui merupakan rotasi. Contoh ini hanya mengubah penjadwalan perilaku tersebut; sudut 90‑derajatnya tetap utuh. Memisahkan sudut dan penjadwalan memudahkan penyesuaian kecepatan tanpa membangun ulang animasi.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

Perilaku menggunakan durasi dua detik, penundaan setengah detik, dan pengulangan sebanyak 3. 20% pertama dan terakhir dari durasinya digunakan untuk akselerasi dan deselerasi.

Kebijakan pengulangan lain meliputi [repeat_duration](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), dan [repeat_until_next_click](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/repeat_until_next_click/); pilih satu kebijakan daripada mengaktifkan semuanya bersamaan. [auto_reverse](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/timing/auto_reverse/) memutar animasi mundur setelah putaran maju. Akselerasi dan deselerasi berlaku untuk perubahan kontinu, bukan penetapan atau perintah diskrit.

## **Buat Jalur Gerak**

Gunakan [create_motion_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) untuk membuat gerakan. [from_address](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioneffect/to/), dan [by](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioneffect/by/) menjelaskan koordinat atau offset berbasis persentase. Untuk rute yang dapat diedit, buat [MotionPath](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motionpath/) dan tetapkan ke [MotionEffect.path](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motionpath/) menyimpan perintah jalur.

[MotionCommandPathType](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioncommandpathtype/) memilih operasi:

| Perintah | Titik | Makna |
| --- | --- | --- |
| MOVE_TO | Satu | Menetapkan posisi awal. |
| LINE_TO | Satu | Bergerak sepanjang segmen lurus ke titik akhirnya. |
| CURVE_TO | Tiga | Mengikuti kurva kubik yang didefinisikan oleh dua titik kontrol dan satu titik akhir. |
| CLOSE_LOOP | Tidak ada | Kembali ke posisi awal. |
| END | Tidak ada | Menyelesaikan jalur. |

[MotionPathPointsType](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motionpathpointstype/) menjelaskan karakteristik penyuntingan titik, seperti titik sudut atau halus. Ini tidak menggantikan tipe perintah. Gunakan tipe titik kurva untuk contoh kurva di bawah, dan tipe titik sudut untuk segmen lurus.

Koordinat jalur dinormalisasi ke dimensi slide: perpindahan X sebesar 0.25 mewakili seperempat lebar slide, bukan 0.25 poin. Y positif mengarah ke bawah. Perintah absolut menentukan posisi dalam sistem koordinat jalur; perintah relatif menentukan offset dari posisi saat ini. Ini terpisah dari [origin](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioneffect/origin/), yang memilih kerangka referensi jalur, dan [path_edit_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), yang mengontrol bagaimana jalur bergerak ketika bentuk dipindahkan.

### **Buat Jalur Lurus**

Buat perilaku gerak dengan titik awal, satu segmen lurus, dan perintah akhir. [MotionPath.add](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motionpath/add/) menerima tipe perintah, titik‑titiknya, tipe titik, dan flag koordinat relatif.

Perintah awal menetapkan (0, 0), dan garis berakhir di (0.25, 0), memberikan jalur perpindahan horizontal sebesar seperempat lebar slide. Perintah akhir tidak memiliki titik koordinat. Setelah jalur ditetapkan, menambahkan perilaku gerak ke efek menghubungkan jalur tersebut ke persegi panjang.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` berisi satu perilaku gerak dengan tiga perintah jalur. Contoh penyuntingan file berikut menggunakan struktur yang diketahui ini.

### **Bandingkan Koordinat Absolut dan Relatif**

Dua objek jalur ini menggambarkan rute yang sama. Perintah absolut berakhir di (0.3, 0.1); perintah relatif menambahkan (0.1, 0.1) ke posisi saat ini, (0.2, 0).

Kedua jalur memulai pada posisi yang sama. Untuk garis relatif, tambahkan offset X dan Y ke posisi saat ini untuk memperoleh titik akhir; untuk garis absolut, baca titik akhir secara langsung. Mengubah flag tanpa mengkonversi koordinat akan menghasilkan rute yang berbeda.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Tetapkan salah satu jalur ke perilaku gerak untuk menggunakannya dalam presentasi. Argumen Boolean akhir memilih koordinat relatif untuk perintah itu.

### **Ganti Garis dengan Kurva**

Buka `motion.pptx` dan ganti perintah garisnya dengan kurva kubik. Berikan dua titik kontrol terlebih dahulu, kemudian titik akhir.

Posisi awal disediakan oleh perintah sebelumnya. Dua titik pertama membentuk kurva, sementara yang ketiga adalah tujuan akhir; mereka bukan tiga tujuan berurutan. Memperbarui tipe perintah, tipe penyuntingan titik, dan array titik secara bersamaan menjaga segmen tetap konsisten dengan geometri barunya.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

Jalur di `curve.pptx` masih memiliki tiga perintah; perintah tengah kini mendefinisikan kurva.

## **Periksa dan Sunting Jalur yang Disimpan**

Setiap [MotionCmdPath](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioncmdpath/) menampilkan [points](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioncmdpath/points_type/), dan [is_relative](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motioncmdpath/is_relative/). Contoh berikut menggunakan jalur tiga perintah yang diketahui di `motion.pptx`. Untuk input acak, temukan efek yang dimaksud dan periksa tipe perintah serta jumlah titik sebelum menyunting berdasarkan indeks.

### **Baca Perintah dan Koordinat**

Baca jalur tanpa mengubahnya. Perintah end dan close-loop tidak memerlukan titik, sehingga izinkan array titik `None`.

Output menggabungkan setiap perintah dengan flag koordinat relatif sebelum mencantumkan titik‑titiknya. Ini memungkinkan Anda membedakan titik akhir dari offset sebelum memodifikasi jalur. Kurva akan mencantumkan tiga titik, sedangkan garis lurus dalam file ini hanya mencantumkan satu.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

Daftar berisi titik awal, garis absolut yang berakhir di (0.25, 0), dan perintah end.

### **Ubah Titik Akhir**

Buka `motion.pptx` dan ganti array titik garis untuk memindahkan titik akhirnya.

Dalam file input, indeks 0 adalah perintah awal dan indeks 1 adalah garis. Mengganti satu titik garis mengubah tujuan tanpa mengubah tipe perintah, penjadwalan, atau posisi dalam koleksi. Karena perintah menggunakan koordinat absolut, pasangan baru menentukan posisi bukan offset tambahan.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

Garis di `motion-endpoint.pptx` berakhir di (0.4, 0.1); file asli tidak berubah.

### **Ganti Segmen**

Gunakan [insert](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motionpath/insert/) dan [remove_at](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/motionpath/remove_at/) untuk mengganti garis dalam `motion.pptx`. Penyisipan memindahkan garis lama ke indeks 2.

Ini mendemonstrasikan penggantian objek perintah alih‑alih menyunting koordinatnya yang ada. Setelah penyisipan, koleksi sementara berisi perintah awal, garis baru, garis lama, dan perintah end. Menghapus indeks 2 membuang garis lama dan meninggalkan jalur baru di tempat.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

Jalur yang disimpan masih memiliki tiga perintah, dengan garis baru berakhir di (0.2, 0.1) dan perintah end terakhir.

## **Modifikasi dan Verifikasi Perilaku yang Ada**

Ketika indeks perilaku tidak diketahui, pilih berdasarkan tipe. Contoh ini membuka `rotation.pptx`, menemukan [RotationEffect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/rotationeffect/), mengubah sudut, dan memeriksa nilai yang disimpan setelah dibuka kembali.

Pemeriksaan tipe memungkinkan loop melewati perilaku yang bukan rotasi. Pembacaan kedua memuat file yang disimpan ke objek presentasi terpisah, sehingga perbandingan memeriksa data yang dipertahankan bukan nilai yang masih berada di memori. Contoh ini masih mengasumsikan efek yang diketahui berada pertama dalam urutan utama; memilih perilaku berdasarkan tipe tidak menemukan efek yang tepat dalam presentasi acak.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

Outputnya adalah `Rotation preserved: True`. Terapkan pola pemeriksaan tipe yang sama pada perilaku lain. Untuk pemeriksaan preservasi lengkap, bandingkan bentuk target, efek, tipe dan urutan perilaku, penjadwalan, serta perintah jalur. Gunakan toleransi numerik untuk nilai floating‑point. Untuk presentasi dengan tata letak animasi yang tidak diketahui, lihat [Baca Animasi Bentuk](/slides/id/python-net/shape-animation/#read-shape-animations) untuk menelusuri urutan utama dan interaktif.

## **Urutan Perilaku, Preset, dan Pemutaran**

Urutan dalam [BehaviorCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behaviorcollection/) adalah urutan yang disimpan dari operasi efek. Itu bukan playlist di mana setiap perilaku otomatis menunggu yang sebelumnya. Penjadwalan ditentukan oleh timing dan efek yang membungkus. Perilaku dapat tumpang tindih, dan operasi pada properti yang sama dapat berinteraksi melalui [additive](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behavior/additive/) dan [accumulate](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/behavior/accumulate/). Jangan gunakan hanya pengurutan ulang koleksi untuk menjadwalkan “pindah, lalu putar”; gunakan penjadwalan eksplisit atau efek terpisah seperti yang dijelaskan dalam [Animasi Bentuk](/slides/id/python-net/shape-animation/).

[type](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/type/) dan [subtype](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/effect/subtype/) efek menggambarkan presetnya. Mereka bukan deskripsi lengkap dari pohon perilaku yang disunting. Pilih preset dan subtype sebelum menyesuaikan perilaku: mengubah preset dapat membangun ulang koleksi dan membuang operasi khusus Anda. Misalnya, mengubah efek Spin yang disesuaikan menjadi Fade dapat mengganti perilaku rotasinya dengan perilaku set dan filter. Periksa kembali koleksi setelah mengubah preset atau subtype. Mengosongkan perilaku preset juga dapat menghapus operasi visibilitas atau inisialisasi yang diperlukan preset. Contoh sengaja menggunakan bentuk yang terlihat dan mengganti perilaku; mereka tidak membangun kembali implementasi setiap preset.

## **Kompatibilitas Format**

Pohon perilaku yang dipertahankan tidak menjamin pemutaran yang identik pada setiap penampil atau renderer ekspor. Periksa data yang disimpan dan output yang dirender secara terpisah.

| Format atau output | Apa yang harus diverifikasi |
| --- | --- |
| PPTX | Gunakan sebagai format utama untuk contoh ini. Buka kembali untuk memverifikasi pohon perilaku yang dapat diedit, lalu periksa pemutaran pada versi PowerPoint yang dimaksud. |
| PPT | Representasi biner legacy dapat berbeda dari PPTX. Uji siklus simpan‑dan‑buka kembali terpisah dan pemutaran; jangan menyimpulkan dukungan untuk setiap kombinasi khusus dari output PPTX yang berhasil. |
| PDF, PNG, JPEG, and other static slide images | Berisi representasi slide statis, bukan timeline perilaku yang dapat diputar atau frame animasi akhir yang dijamin. |
| [HTML5](/slides/id/python-net/export-to-html5/) | Dapat memutar animasi yang didukung ketika animasi bentuk diaktifkan dalam opsi ekspor. Uji kombinasi khusus di peramban. |
| [Animated GIF](/slides/id/python-net/convert-powerpoint-to-animated-gif/) | Menyimpan frame yang dirender, bukan perilaku yang dapat diedit atau interaksi yang dipicu klik. Periksa gerakan yang dirender sebenarnya. |
| [Video](/slides/id/python-net/convert-powerpoint-to-video/) | Merender frame animasi dan mengenkodenya sebagai video. Dukungan terbatas pada [animasi dan efek yang didukung](/slides/id/python-net/convert-powerpoint-to-video/#supported-animations-and-effects); perintah dan peristiwa interaktif tidak menjadi timeline yang dapat diedit. |

## **FAQ**

**Mengapa efek saya berisi perilaku sebelum saya menambahkan apa pun?**

Membuat efek yang telah ditentukan dapat membuat operasi dasarnya. Periksa mereka sebelum memutuskan memperluas preset atau mengganti perilakunya.

**Apakah memindahkan perilaku ke awal membuatnya diputar pertama?**

Tidak selalu. Urutan koleksi bukan pengganti penjadwalan. Periksa penundaan, durasi, dan interaksi antara operasi pada properti yang sama.

**Mengapa perintah end tidak memiliki titik?**

It menandai akhir jalur dan tidak memerlukan koordinat. Periksa adanya array titik `None` saat memeriksa jalur yang dibaca dari file.

**Apakah siklus kembali yang berhasil cukup untuk mengonfirmasi pemutaran?**

Tidak. Membuka kembali mengonfirmasi preservasi properti yang Anda periksa. Uji pemutar slideshow atau ekspor animasi secara terpisah untuk memastikan perilaku visualnya.