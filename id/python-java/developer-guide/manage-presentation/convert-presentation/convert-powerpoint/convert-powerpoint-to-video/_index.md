---
title: Konversi Presentasi PowerPoint ke Video dengan Python
linktitle: PowerPoint ke Video
type: docs
weight: 130
url: /id/python-java/convert-powerpoint-to-video/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi PPT
- konversi PPTX
- PowerPoint ke video
- presentasi ke video
- PPT ke video
- PPTX ke video
- PowerPoint ke MP4
- presentasi ke MP4
- PPT ke MP4
- PPTX ke MP4
- simpan PPT sebagai MP4
- simpan PPTX sebagai MP4
- ekspor PPT ke MP4
- ekspor PPTX ke MP4
- konversi video
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke video MP4 dengan Python melalui Java. Hasilkan frame dengan Aspose.Slides dan enkode menggunakan FFmpeg, termasuk animasi dan transisi."
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint atau OpenDocument ke video memungkinkan penonton menonton kontennya di pemutar video tanpa membuka aplikasi presentasi. Aspose.Slides for Python via Java merender animasi dan transisi presentasi menjadi frame gambar. Encoder terpisah, seperti FFmpeg, menggabungkan frame tersebut menjadi file video.

{{% alert color="info" title="Note" %}}
Coba konverter PowerPoint ke Video daring [PowerPoint to Video converter](https://products.aspose.app/slides/id/video) untuk melihat konversi presentasi ke video secara langsung.
{{% /alert %}}

## **Konversi PowerPoint ke Video**

Konversi memiliki dua tahap: menghasilkan frame PNG pada frame rate yang dipilih, kemudian mengenkode urutan gambar menjadi MP4. Gunakan frame rate yang sama pada kedua tahap untuk mempertahankan timing animasi.

Sebelum menjalankan contoh:

1. Siapkan [Aspose.Slides for Python via Java](/slides/id/python-java/installation/).
2. Unduh [FFmpeg](https://ffmpeg.org/download.html) dan pastikan executable‑nya tersedia di `PATH`. Contoh menggunakan build dengan encoder `libx264`.
3. Jalankan kode Python berikut di direktori yang dapat ditulisi.

Contoh ini membuat bentuk tersenyum dengan animasi masuk dan keluar, merender frame pada 30 FPS, dan memanggil FFmpeg untuk membuat `output.mp4`. Direktori frame baru mencegah frame dari run sebelumnya termasuk dalam video.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

Untuk mengonversi file yang ada, inisialisasi [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dengan path‑nya dan hilangkan pernyataan pembuatan shape serta animasi.

Perintah FFmpeg membaca [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2) yang bernomor, menambahkan padding pada dimensi ganjil menjadi nilai genap, dan menulis video H.264 dengan format pixel `yuv420p`. Opsi `-n` mencegah penimpaan file output yang sudah ada. File PNG yang dihasilkan tetap berada di direktori frame; hapus file tersebut ketika tidak lagi dibutuhkan.

{{% alert color="info" title="Note" %}}
Contoh ini hanya mengenkode frame gambar. Ia tidak menambahkan narasi atau audio presentasi yang tersemat ke video output.
{{% /alert %}}

## **Efek Video**

Animasi mengontrol bagaimana objek slide muncul, bergerak, atau menghilang. Transisi mengontrol perubahan antar slide. Tambahkan efek ini sebelum menghasilkan frame video.

Lihat [PowerPoint Animation](/slides/id/python-java/powerpoint-animation/), [Shape Animation](/slides/id/python-java/shape-animation/), [Shape Effects](/slides/id/python-java/shape-effect/), dan [Slide Transitions](/slides/id/python-java/slide-transition/).

### **Tambahkan Transisi Slide**

Contoh mandiri berikut membuat presentasi dengan dua slide. Slide kedua memiliki latar belakang magenta dan transisi push. Simpan presentasi, lalu gunakan sebagai input untuk contoh pembuatan frame di atas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Animasi Paragraf**

Teks dapat muncul paragraf demi paragraf. Contoh ini membuat tiga paragraf dengan efek masuk fade berurutan, masing-masing tertunda satu detik setelah efek sebelumnya. Gunakan file `paragraphs.pptx` yang disimpan sebagai input untuk contoh konversi video.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kelas Konversi Video**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationanimationsgenerator/) menghasilkan peristiwa animasi untuk slide. Membuatnya dari sebuah presentasi menggunakan ukuran slide presentasi untuk frame. Gunakan [setDefaultDelay](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) untuk mengatur delay default dalam milidetik.

[PresentationPlayer](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationplayer/) mengambil sampel animasi yang dihasilkan pada frame rate yang diberikan ke konstruktornya. Daftarkan callback Python melalui JPype dengan [setFrameTick](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationplayer/#setFrameTick), lalu panggil [run](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationanimationsgenerator/#run) untuk menghasilkan frame. Contoh pertama menggunakan penghitung berbasis nol sendiri sehingga nama file cocok dengan urutan input FFmpeg.

Untuk keadaan animasi individual, daftarkan callback dengan [setNewAnimation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). Callback menerima animation player yang dapat diposisikan pada waktu tertentu. Contoh berikut menyimpan frame pertama dan terakhir dari setiap animasi yang dihasilkan dengan nama file unik:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **Animasi dan Efek yang Didukung**

Tabel berikut merangkum dukungan rendering yang dijelaskan dalam artikel konversi Java. Pratinjau frame yang dihasilkan ketika presentasi menggunakan efek yang tidak didukung.

**Masuk**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly In** | Yes | Yes |
| **Float In** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Wheel** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Grow & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Penekanan**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | No | Yes |
| **Color Pulse** | No | Yes |
| **Teeter** | Yes | Yes |
| **Spin** | Yes | Yes |
| **Grow/Shrink** | No | Yes |
| **Desaturate** | No | Yes |
| **Darken** | No | Yes |
| **Lighten** | No | Yes |
| **Transparency** | No | Yes |
| **Object Color** | No | Yes |
| **Complementary Color** | No | Yes |
| **Line Color** | No | Yes |
| **Fill Color** | No | Yes |

**Keluar**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly Out** | Yes | Yes |
| **Float Out** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Shrink & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**Jalur Gerakan**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **Tanya Jawab**

**Apakah Aspose.Slides membuat file MP4 secara langsung?**

Tidak. Aspose.Slides menghasilkan frame presentasi. Gunakan encoder video seperti FFmpeg untuk menggabungkannya menjadi file MP4.

**Mengapa video diputar lebih cepat atau lebih lambat dari yang diharapkan?**

Gunakan FPS yang sama untuk pembuatan frame dan frame rate input encoder. Ketidaksesuaian mengubah durasi pemutaran urutan gambar.

**Apakah saya dapat mengonversi presentasi yang dilindungi kata sandi?**

Ya. Berikan kata sandi yang benar saat [loading the protected presentation](/slides/id/python-java/password-protected-presentation/), kemudian hasilkan frame dari konten yang dimuat.

**Apakah alur kerja ini mempertahankan audio presentasi?**

Contoh mengekspor frame gambar, sehingga video yang dihasilkan tanpa suara. Untuk menyertakan audio, tambahkan trek audio secara terpisah selama proses enkoding video.

**Bagaimana saya dapat mengurangi penggunaan disk sementara?**

Gunakan ukuran frame yang lebih kecil atau FPS yang lebih rendah, dan hapus file PNG sementara setelah enkoding berhasil. Periksa kualitas video yang dihasilkan saat mengurangi salah satu pengaturan tersebut.