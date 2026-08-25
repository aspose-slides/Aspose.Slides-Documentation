---
title: Kelola Efek Transformasi Gambar dalam Presentasi dengan .NET
linktitle: Efek Transformasi Gambar
type: docs
weight: 11
url: /id/net/image-transform-effects/
keywords:
- transformasi gambar
- efek gambar
- kecerahan
- kontras
- grayscale
- duotone
- tint
- HSL
- penggantian warna
- blur
- transparansi
- efek alpha
- rantai efek
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Terapkan, rangkai, inspeksi, hapus, dan verifikasi efek transformasi gambar untuk bingkai gambar dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides merepresentasikan penyesuaian gambar sebagai koleksi berurutan operasi transformasi gambar. Untuk sebuah bingkai gambar, mulai dengan [ISlidesPicture](https://reference.aspose.com/slides/id/net/aspose.slides/islidespicture/) bingkai tersebut dan akses [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/id/net/aspose.slides/islidespicture/imagetransform/). [IImageTransformOperationCollection](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/) yang dikembalikan memungkinkan Anda menambahkan, menelusuri, memeriksa, menghapus, dan membersihkan efek tanpa menulis ulang byte gambar asli.

Artikel ini menunjukkan alur kerja lengkap untuk kecerahan dan kontras, transformasi warna, blur, transparansi, rantai efek berurutan, nilai efektif, penghapusan, dan verifikasi putar‑balik PPTX.

## **Memahami Kepemilikan Efek dan Penggunaan Ulang Gambar**

Sebuah sumber gambar dan gambar yang menampilkannya adalah objek yang berbeda:

- [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) menyimpan atau merujuk data gambar sumber yang dimiliki oleh presentasi.
- [ISlidesPicture](https://reference.aspose.com/slides/id/net/aspose.slides/islidespicture/) merupakan isi gambar dan merujuk ke sumber gambar sambil menyimpan koleksi transformasi gambar.
- [IPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ipictureframe/) adalah bentuk slide yang memiliki isi gambar terkait, geometri, pengaturan potong, dan format tingkat bingkai lainnya.

Karena itu, operasi transformasi gambar tidak memodifikasi byte di [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/). Ketika `IPPImage` yang sama dilewatkan ke [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/addpictureframe/) lebih dari satu kali, tiap bingkai gambar baru menerima `ISlidesPicture` dan koleksi transformasinya sendiri. Menerapkan grayscale pada satu bingkai tidak membuat bingkai lain menjadi grayscale, meskipun semuanya menggunakan sumber gambar yang sama.

Model `ISlidesPicture.ImageTransform` yang sama juga dipakai oleh isi gambar lainnya, seperti bentuk atau latar belakang slide. Contoh di bawah ini memusatkan pada bingkai gambar.

## **Gunakan Rentang Parameter dan Satuan yang Valid**

Metode yang ditunjukkan menggunakan rentang semantik dan satuan berikut. Pertahankan nilai dalam rentang ini meskipun versi pustaka tertentu tidak menolak setiap nilai di luar rentang secara langsung; format presentasi target dapat menormalkan, menghilangkan, atau menolak data tidak valid saat disimpan atau ketika PowerPoint membuka berkas.

| Operasi | Parameter | Rentang dan satuan yang valid |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` melalui `100`, persen; `0` tidak mengubah komponen. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Tidak ada | Tidak ada parameter numerik. Alpha tidak berubah. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Dua warna untuk piksel gelap dan terang. Kanal RGB dan alpha pada `System.Drawing.Color` menggunakan `0` sampai `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue bernilai `0` inklusif sampai `360` eksklusif, dalam derajat; amount bernilai `-100` sampai `100`, persen. |
| [AddHSLEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue bernilai `0` inklusif sampai `360` eksklusif, dalam derajat; saturasi dan luminansi bernilai `-100` sampai `100`, persen. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Warna pengganti menggunakan nilai kanal dari `0` sampai `255`. Nilai alpha yang ada tidak berubah. |
| [AddBlurEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius tidak negatif dan diukur dalam poin; `grow` adalah Boolean yang mengontrol apakah konten blur dapat melampaui batas asli. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Persen tidak negatif. Gunakan `0` sampai `100` untuk skala opasitas biasa: `0` sepenuhnya transparan dan `100` mempertahankan alpha yang ada. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` sampai `100`, persen opasitas. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` sampai `100`, persen ambang alpha. Nilai di bawahnya menjadi transparan; nilai pada atau di atasnya menjadi opak. |

Untuk modulasi alpha tetap, transparansi dan opasitas bersifat komplementer. Misalnya, transparansi 35% berkorespondensi dengan modulasi alpha sebesar 65%.

## **Terapkan Kecerahan dan Kontras**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) mengembalikan operasi [IBrightnessContrast](https://reference.aspose.com/slides/id/net/aspose.slides.effects/ibrightnesscontrast/). Pengaturan skalarnya disediakan saat operasi dibuat. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides.effects/brightnesscontrast/geteffective/) mengembalikan nilai read‑only yang dihitung dan dapat diperiksa atau dicatat.

Contoh berikut meningkatkan kecerahan sebesar 15% dan kontras sebesar 20%, lalu menampilkan pratinjau tanpa memodifikasi gambar yang tertanam:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/id/net/aspose.slides.effects/brightnesscontrast/) merupakan ekstensi efek gambar Office 2010 dan kurang portabel dibandingkan efek luminansi DrawingML standar. Ketika kecerahan dan kontras harus tetap dapat diedit setelah putar‑balik PPTX, gunakan [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) dan verifikasi hasilnya setelah membuka kembali berkas. Bagian batasan format menjelaskan perbedaan ini secara lebih rinci.

## **Terapkan Transformasi Warna**

Efek warna dapat diterapkan secara independen pada berbagai bingkai gambar yang menggunakan satu sumber gambar. Contoh berikut membuat lima bingkai dan menerapkan grayscale, duotone, tint, penyesuaian HSL, serta penggantian warna.

[IDuotone](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iduotone/) memiliki dua parameter warna yang dapat diedit secara terpisah: `Color1` memetakan piksel gelap, sementara `Color2` memetakan piksel terang. Ini menjadikannya contoh berguna untuk efek yang pengaturannya lebih kompleks daripada nilai skalar tunggal.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) menggantikan setiap warna piksel dengan satu warna tetap sambil mempertahankan alpha. Ini berbeda dari [AddColorChangeEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), yang memetakan satu warna sumber ke warna lain dan mengekspos format warna sumber serta target.

## **Tambahkan Blur, Transparansi, dan Efek Alpha**

[AddBlurEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) memengaruhi semua kanal warna, termasuk alpha. Setel `grow` ke `true` ketika tepi blur dapat melampaui batas gambar asli.

Untuk transparansi seragam, gunakan [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Efek ini mengalikan setiap nilai alpha yang ada, sehingga piksel yang sebagian transparan tetap berbeda secara proporsional. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) malah menetapkan satu nilai alpha ke semua piksel. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) mengubah alpha menjadi dua tingkat berdasarkan ambang.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

Operasi alpha tanpa parameter lainnya meliputi [AddAlphaCeilingEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), yang menjadikan setiap alpha non‑nol sepenuhnya opak; [AddAlphaFloorEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), yang menjadikan setiap alpha di bawah 100% sepenuhnya transparan; dan [AddAlphaInverseEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), yang mengubah alpha menjadi `100% - alpha`.

## **Bangun Rantai Efek Berurutan**

Setiap metode `Add...Effect` menambahkan operasi baru ke akhir koleksi. Renderer menggunakan koleksi sebagai pipeline berurutan: output operasi 0 menjadi input operasi 1, dan seterusnya. Akibatnya, operasi yang sama dalam urutan berbeda dapat menghasilkan gambar yang berbeda.

Sebagai contoh, grayscale diikuti tint pertama‑tama menghapus informasi kromatik lalu mewarnai ulang hasil luminansi. Tint diikuti grayscale menghapus tint kembali. Demikian pula, penggantian alpha dapat menimpa nilai alpha yang dihitung oleh operasi sebelumnya, sementara modulasi alpha mempertahankan perbedaan relatif mereka.

Contoh berikut membangun rantai empat operasi, menyimpannya sebagai PPTX, membuka kembali presentasi, memeriksa tipe operasi serta urutannya, dan merender hasil yang dibuka kembali:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

Koleksi tidak memberlakukan matriks kompatibilitas yang membatasi operasi warna, alpha, dan blur ke rantai terpisah. Mereka dapat digabungkan, namun kombinasi tidak selalu berguna. Penggantian warna tetap menghapus variasi RGB yang dihasilkan oleh efek warna sebelumnya; grayscale setelah duotone menghilangkan dua warna yang dipilih; dan operasi alpha ceiling, floor, replacement, atau bi‑level dapat membuang detail alpha yang dibuat sebelumnya. Bangun rantai sesuai urutan pemrosesan piksel yang diinginkan, bukan memperlakukan item‑nya sebagai flag format yang tidak berurutan.

## **Periksa Nilai yang Dapat Diedit dan Nilai Efektif**

Operasi yang dapat diedit adalah objek yang disimpan di `ISlidesPicture.ImageTransform`. Bergantung pada efeknya, objek tersebut dapat mengekspos anggota yang dapat ditulisi secara langsung. Misalnya, [IBlur](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iblur/) mengekspos `Radius` dan `Grow` yang dapat ditulisi, [IAlphaModulateFixed](https://reference.aspose.com/slides/id/net/aspose.slides.effects/ialphamodulatefixed/) mengekspos `Amount` yang dapat ditulisi, dan [IAlphaBiLevel](https://reference.aspose.com/slides/id/net/aspose.slides.effects/ialphabilevel/) mengekspos `Threshold` yang dapat ditulisi. Efek warna seperti [IDuotone](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iduotone/) mengekspos objek [IColorFormat](https://reference.aspose.com/slides/id/net/aspose.slides/icolorformat/) yang dapat diubah.

Beberapa antarmuka operasi, termasuk [IBrightnessContrast](https://reference.aspose.com/slides/id/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/id/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/id/net/aspose.slides.effects/itint/), dan [IAlphaReplace](https://reference.aspose.com/slides/id/net/aspose.slides.effects/ialphareplace/), tidak mengekspos skalar penciptaannya sebagai properti yang dapat ditulisi. Untuk mengubah pengaturan tersebut, hapus operasi dan tambahkan pengganti pada posisi yang diperlukan.

Data efektif yang dikembalikan oleh `GetEffective()` dihitung dan bersifat read‑only. Data ini berguna untuk menyelesaikan warna yang bergantung pada tema serta membaca nilai normalisasi yang digunakan renderer, namun bukan permukaan penyuntingan lain. Contoh berikut menelusuri rantai dan memeriksa nilai efektif di mana API yang bersangkutan menyediakannya:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

Efek tanpa parameter seperti grayscale, alpha ceiling, dan alpha inverse tetap memiliki objek data efektif, tetapi tidak ada pengaturan skalar untuk dicetak. Keberadaan dan posisinya dalam koleksi merupakan informasi penting.

## **Hapus atau Bersihkan Transformasi Gambar**

Gunakan [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) untuk menghapus satu operasi berdasarkan indeks. Karena indeks bergeser setelah penghapusan, cari target terlebih dahulu dan hapus setelah penelusuran. Gunakan `Clear()` untuk menghapus seluruh rantai.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

Menghapus atau membersihkan transformasi hanya mengubah format gambar. Hal ini tidak menghapus, mengompres ulang, atau mengubah sumber [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) yang digunakan kembali.

## **Pertimbangkan Format Presentasi dan Target Ekspor**

Transformasi gambar berasal dari DrawingML, sehingga PPTX adalah format yang disarankan untuk rantai efek yang dapat diedit. Bahkan dengan PPTX, tidak semua operasi memiliki portabilitas yang identik:

- Operasi DrawingML standar seperti luminance, grayscale, duotone, tint, HSL, blur, dan operasi alpha umum memiliki peluang terbaik untuk bertahan setelah putar‑balik PPTX. Selalu buka kembali berkas yang dihasilkan dan periksa koleksinya ketika preservasi menjadi persyaratan.
- [BrightnessContrast](https://reference.aspose.com/slides/id/net/aspose.slides.effects/brightnesscontrast/) adalah ekstensi Office 2010, bukan operasi luminansi DrawingML standar. Efek ini dapat dipakai untuk rendering dalam memori, tetapi tidak dijamin tetap sebagai [IBrightnessContrast](https://reference.aspose.com/slides/id/net/aspose.slides.effects/ibrightnesscontrast/) yang dapat diedit setelah menyimpan dan membuka kembali PPTX. Lebih pilih [AddLuminanceEffect](https://reference.aspose.com/slides/id/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) untuk penyesuaian kecerahan dan kontras yang persisten.
- Format PPT biner mendahului model efek DrawingML lengkap. Menyimpan ke PPT dapat menghilangkan operasi yang tidak didukung, mereduksi rantai ke subset yang didukung, atau mengaproksimasi tampilan. Jangan gunakan PPT sebagai format verifikasi untuk rantai yang dapat diedit secara kompleks.
- Rendering ke PNG, JPEG, TIFF, PDF, SVG, HTML, atau output visual lainnya menerapkan rantai yang didukung pada tampilan yang dirender. Output tersebut tidak berisi `IImageTransformOperationCollection` yang dapat diedit; format raster meratakan hasil menjadi piksel, dan ekspor dokumen/vektor menyimpan representasi render mereka sendiri.
- Efek tidak membuat gambar yang ditautkan menjadi mandiri. Rendering gambar yang ditautkan tetap bergantung pada sumber yang ditautkan tersedia saat presentasi dimuat.

Berbagai konsumen presentasi dapat merender kasus tepi secara berbeda, terutama ketika beberapa operasi alpha atau kuantisasi warna digabungkan. Untuk output yang kritis, uji baik putar‑balik yang dapat diedit maupun format ekspor akhir dengan versi Aspose.Slides yang sama dengan yang dipakai di produksi.

## **FAQ**

**Apakah efek transformasi gambar mengubah data gambar yang tertanam?**

Tidak. Operasi tersebut milik `ISlidesPicture` yang digunakan oleh isi gambar. Byte `IPPImage` yang mendasarinya tetap tidak berubah.

**Apakah dua bingkai gambar yang menggunakan gambar yang sama berbagi efeknya?**

Tidak. Menggunakan `IPPImage` yang sama menghindari duplikasi data gambar, tetapi tiap bingkai gambar biasanya memiliki `ISlidesPicture` dan koleksi transformasi gambar yang terpisah.

**Apakah efek warna, blur, dan alpha dapat digabungkan?**

Ya. Koleksi menerima semuanya dalam satu rantai berurutan. Pertimbangkan apa yang dilakukan tiap operasi pada output operasi sebelumnya karena operasi penggantian dan ambang dapat membuang detail warna atau alpha sebelumnya.

**Mengapa nilai efektif bersifat read‑only?**

Data efektif mewakili nilai yang dihitung dan digunakan untuk rendering, termasuk warna yang sudah diselesaikan. Edit operasi yang disimpan dalam koleksi transformasi di mana anggota dapat ditulisi; jika tidak, hapus dan tambahkan pengganti dengan parameter penciptaan baru.

**Format mana yang harus saya gunakan untuk mempertahankan rantai transformasi?**

Gunakan PPTX dan verifikasi berkas dengan membukanya kembali. PPT lama tidak dapat merepresentasikan model efek DrawingML penuh, dan format ekspor yang dirender hanya mempertahankan tampilan, bukan operasi transformasi yang dapat diedit.