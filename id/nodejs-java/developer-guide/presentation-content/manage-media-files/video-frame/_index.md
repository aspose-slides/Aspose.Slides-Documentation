---
title: Kelola Bingkai Video dalam Presentasi Menggunakan JavaScript
linktitle: Bingkai Video
type: docs
weight: 10
url: /id/nodejs-java/video-frame/
keywords:
- tambahkan video
- buat video
- sematkan video
- ekstrak video
- ambil video
- bingkai video
- sumber web
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menambahkan dan mengekstrak bingkai video secara programatis dalam slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js via Java. Panduan cepat cara melakukannya."
---
## **Pendahuluan**

Video yang ditempatkan dengan tepat dalam sebuah presentasi dapat membuat pesan Anda lebih menarik dan meningkatkan tingkat keterlibatan audiens.

PowerPoint memungkinkan Anda menambahkan video ke slide dalam presentasi dengan dua cara:

* Menambahkan atau menyematkan video lokal (disimpan di mesin Anda)
* Menambahkan video daring (dari sumber web seperti YouTube).

Untuk memungkinkan Anda menambahkan video (objek video) ke sebuah presentasi, Aspose.Slides menyediakan kelas [Video](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/video/), kelas [VideoFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/) , dan tipe terkait lainnya.

## **Buat Bingkai Video Tertanam**

Jika file video yang ingin Anda tambahkan ke slide disimpan secara lokal, Anda dapat membuat bingkai video untuk menyematkan video tersebut dalam presentasi Anda.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) class.  
2. Dapatkan referensi slide melalui indeksnya.  
3. Tambahkan objek [Video](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/video/) dan berikan jalur file video untuk menyematkan video ke dalam presentasi.  
4. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/) untuk membuat bingkai bagi video.  
5. Simpan presentasi yang telah dimodifikasi.  

Kode JavaScript berikut menunjukkan cara menambahkan video yang disimpan secara lokal ke sebuah presentasi:

```javascript
// Membuat instance kelas Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Muat video
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Mendapatkan slide pertama dan menambahkan bingkai video
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Menyimpan presentasi ke disk
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Sebagai alternatif, Anda dapat menambahkan video dengan langsung memberikan jalur file ke metode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Buat Bingkai Video dengan Video dari Sumber Web**

Microsoft [PowerPoint 2013 dan yang lebih baru](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) mendukung video YouTube dalam presentasi. Jika video yang ingin Anda gunakan tersedia secara daring (misalnya di YouTube), Anda dapat menambahkannya ke presentasi melalui tautan webnya.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) class.  
2. Dapatkan referensi slide melalui indeksnya.  
3. Tambahkan objek [Video](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/video/) dan berikan tautan ke video.  
4. Atur gambar mini untuk bingkai video.  
5. Simpan presentasi.  

Kode JavaScript berikut menunjukkan cara menambahkan video dari web ke slide dalam presentasi PowerPoint:

```javascript
// Membuat objek Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **Kelola Caption Video**

Aspose.Slides memungkinkan Anda mengelola closed caption untuk bingkai video dalam presentasi PowerPoint. Caption disimpan dalam format WebVTT dan dapat diakses melalui metode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Tambah Caption ke Bingkai Video**

Untuk menambah caption ke sebuah bingkai video:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) .  
2. Tambahkan video ke dalam presentasi.  
3. Tambahkan objek [VideoFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/) ke slide.  
4. Gunakan koleksi [CaptionsCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/) untuk menambahkan trek caption WebVTT.  
5. Simpan presentasi yang telah dimodifikasi.  

Kode berikut menunjukkan cara menambahkan caption ke sebuah bingkai video:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Menambahkan trek caption baru dari file WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kelas [CaptionsCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/) juga menyediakan metode [addFromStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/#addFromStream) yang memungkinkan Anda menambahkan caption dari sebuah stream.

**Ekstrak Caption dari Bingkai Video**

Untuk mengekstrak caption dari sebuah bingkai video:

1. Muat presentasi yang berisi video.  
2. Temukan objek [VideoFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/) target.  
3. Iterasi melalui koleksi [CaptionsCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/).  
4. Simpan setiap trek caption ke file `.vtt`.  

Kode berikut menunjukkan cara mengekstrak caption dari sebuah bingkai video:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // Menyimpan trek caption ke file WebVTT.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Setiap objek [Captions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captions/) menampilkan pengenal caption, label, data biner, dan teks caption sebagai string UTF-8.

**Hapus Caption dari Bingkai Video**

Untuk menghapus caption dari sebuah bingkai video:

1. Muat presentasi yang berisi video.  
2. Dapatkan objek [VideoFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/) target.  
3. Hapus trek caption dari koleksi [CaptionsCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/).  
4. Simpan presentasi yang telah dimodifikasi.  

Kode berikut menunjukkan cara menghapus semua caption dari sebuah bingkai video:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // tipe: com.aspose.slides.VideoFrame

    // Menghapus semua caption dari bingkai video.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika Anda hanya perlu menghapus satu trek caption, gunakan metode [remove](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/#remove) atau [removeAt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/#removeAt) alih-alih [clear](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/captionscollection/#clear).

## **Ekstrak Video dari Slide**

Selain menambahkan video ke slide, Aspose.Slides memungkinkan Anda mengekstrak video yang disematkan dalam presentasi.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) untuk memuat presentasi yang berisi video.  
2. Iterasi melalui semua objek [Slide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/).  
3. Iterasi melalui semua objek [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) untuk menemukan [VideoFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/).  
4. Simpan video ke disk.  

Kode JavaScript berikut menunjukkan cara mengekstrak video pada slide presentasi:

```javascript
// Membuat objek Presentation yang mewakili file presentasi
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Mendapatkan ekstensi file
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Parameter pemutaran video apa yang dapat diubah untuk VideoFrame?**

Anda dapat mengontrol [mode pemutaran](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/setplaymode/) (otomatis atau klik) dan [pengulangan](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Opsi-opsi ini tersedia melalui properti objek [VideoFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/).

**Apakah menambahkan video memengaruhi ukuran file PPTX?**

Ya. Ketika Anda menyematkan video lokal, data biner termasuk dalam dokumen, sehingga ukuran presentasi bertambah sebanding dengan ukuran file. Ketika Anda menambahkan video daring, tautan dan gambar mini disematkan, sehingga peningkatan ukuran lebih kecil.

**Bisakah saya mengganti video dalam VideoFrame yang ada tanpa mengubah posisinya dan ukuran?**

Ya. Anda dapat menukar [konten video](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) di dalam bingkai sambil mempertahankan geometri bentuk; ini merupakan skenario umum untuk memperbarui media dalam tata letak yang sudah ada.

**Dapatkah jenis konten (MIME) video yang disematkan ditentukan?**

Ya. Video yang disematkan memiliki [jenis konten](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/video/getcontenttype/) yang dapat Anda baca dan gunakan, misalnya saat menyimpannya ke disk.