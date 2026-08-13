---
title: Kelola Bingkai Gambar dalam Presentasi di Android
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/androidjava/picture-frame/
keywords:
- bingkai gambar
- tambahkan bingkai gambar
- buat bingkai gambar
- tambahkan gambar
- buat gambar
- ekstrak gambar
- gambar raster
- gambar vektor
- pangkas gambar
- area terpangkas
- properti StretchOff
- pemformatan bingkai gambar
- properti bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- transparansi gambar
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Tambahkan bingkai gambar ke presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Android via Java. Permudah alur kerja Anda dan tingkatkan desain slide."
---
## **Pendahuluan**

Bingkai gambar adalah bentuk yang berisi gambar—seperti gambar dalam bingkai.  

Anda dapat menambahkan gambar ke slide melalui bingkai gambar. Dengan cara ini, Anda dapat memformat gambar dengan memformat bingkai gambar.

{{% alert  title="Tip" color="info" %}} 

Aspose menyediakan konversi gratis—[JPEG ke PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG ke PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan orang membuat presentasi dengan cepat dari gambar. 

{{% /alert %}} 

## **Buat Bingkai Gambar**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).  
2. Dapatkan referensi slide melalui indeksnya.  
3. Buat objek [IPPImage]() dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.  
4. Tentukan lebar dan tinggi gambar.  
5. Buat [PictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/PictureFrame) berdasarkan lebar dan tinggi gambar melalui metode `AddPictureFrame` yang disediakan oleh objek shape yang terkait dengan slide yang direferensikan.  
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide.  
7. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.  

Kode Java ini menunjukkan cara membuat bingkai gambar:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Menginstansiasi kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Menginstansiasi kelas Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Menambahkan bingkai gambar dengan tinggi dan lebar gambar yang setara
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Menulis file PPTX ke disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Buat Bingkai Gambar dengan Skala Relatif**

Dengan mengubah skala relatif gambar, Anda dapat membuat bingkai gambar yang lebih kompleks.  

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).  
2. Dapatkan referensi slide melalui indeksnya.  
3. Tambahkan gambar ke koleksi gambar presentasi.  
4. Buat objek [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPPImage) dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.  
5. Tentukan lebar dan tinggi relatif gambar dalam bingkai gambar.  
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.  

Kode Java ini menunjukkan cara membuat bingkai gambar dengan skala relatif:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instansiasi kelas Presentation yang mewakili PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instansiasi kelas Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Tambahkan Bingkai Gambar dengan tinggi dan lebar yang setara dengan Gambar
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Mengatur skala relatif lebar dan tinggi
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Menulis file PPTX ke disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ekstrak Gambar Raster dari Bingkai Gambar**

Anda dapat mengekstrak gambar raster dari objek [PictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/PictureFrame) dan menyimpannya dalam format PNG, JPG, dan format lainnya. Contoh kode di bawah ini memperlihatkan cara mengekstrak gambar dari dokumen “sample.pptx” dan menyimpannya dalam format PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}

```

## **Ekstrak Gambar SVG dari Bingkai Gambar**

Ketika sebuah presentasi berisi grafik SVG yang ditempatkan di dalam bentuk [PictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pictureframe/), Aspose.Slides untuk Android via Java memungkinkan Anda mengambil gambar vektor asli dengan fidelitas penuh. Setelah Anda memiliki [PictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pictureframe/) yang berisi [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) dengan konten SVG, Anda dapat membaca gambar SVG tersebut dan menyimpannya ke disk atau stream dalam format SVG aslinya.

Contoh kode berikut memperlihatkan cara mengekstrak gambar SVG dari bingkai gambar:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Dapatkan Transparansi Gambar**

Aspose.Slides memungkinkan Anda memperoleh efek transparansi yang diterapkan pada gambar. Kode Java ini memperlihatkan operasi tersebut:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Dapatkan Kecerahan dan Kontras Gambar**

Aspose.Slides memungkinkan Anda memperoleh efek kecerahan dan kontras yang diterapkan pada gambar. Antarmuka [ILuminance](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iluminance/) merepresentasikan efek transformasi gambar ini.

Kode Java ini memperlihatkan cara mendapatkan pengaturan kecerahan dan kontras dari bingkai gambar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Pemformatan Bingkai Gambar**

Aspose.Slides menyediakan banyak opsi pemformatan yang dapat diterapkan pada bingkai gambar. Dengan opsi-opsi tersebut, Anda dapat mengubah bingkai gambar agar sesuai dengan persyaratan tertentu.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).  
2. Dapatkan referensi slide melalui indeksnya.  
3. Buat objek [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPPImage) dengan menambahkan gambar ke [IImagescollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IImageCollection) yang terkait dengan objek presentasi yang akan digunakan untuk mengisi bentuk.  
4. Tentukan lebar dan tinggi gambar.  
5. Buat `PictureFrame` berdasarkan lebar dan tinggi gambar melalui metode [AddPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yang disediakan oleh objek [IShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection) yang terkait dengan slide yang direferensikan.  
6. Tambahkan bingkai gambar (yang berisi gambar) ke slide.  
7. Atur warna garis bingkai gambar.  
8. Atur lebar garis bingkai gambar.  
9. Putar bingkai gambar dengan memberikan nilai positif atau negatif.  
   * Nilai positif memutar gambar searah jarum jam.  
   * Nilai negatif memutar gambar berlawanan arah jarum jam.  
10. Tambahkan bingkai gambar (yang berisi gambar) ke slide.  
11. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.  

Kode Java ini memperlihatkan proses pemformatan bingkai gambar:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Menginstansiasi kelas Presentation yang mewakili PPTX
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Menginstansiasi kelas Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Menambahkan Bingkai Gambar dengan tinggi dan lebar yang setara dengan Gambar
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Menerapkan beberapa pemformatan pada PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Menulis file PPTX ke disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Aspose recently developed a [free Collage Maker](https://products.aspose.app/slides/id/collage). If you ever need to [merge JPG/JPEG](https://products.aspose.app/slides/id/collage/jpg) or PNG images, [create grids from photos](https://products.aspose.app/slides/id/collage/photo-grid), you can use this service. 

{{% /alert %}}

## **Tambahkan Gambar sebagai Tautan**

Untuk menghindari ukuran presentasi yang besar, Anda dapat menambahkan gambar (atau video) melalui tautan alih-alih menyematkan file secara langsung ke dalam presentasi. Kode Java ini memperlihatkan cara menambahkan gambar dan video ke placeholder:

```java
import com.aspose.slides.*;
import java.util.ArrayList;

Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Pangkas Gambar**

Kode Java ini memperlihatkan cara memangkas gambar yang sudah ada pada slide:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
// Membuat objek gambar baru
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Menambahkan PictureFrame ke Slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Memotong gambar (nilai persentase)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Menyimpan hasil
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hapus Area yang Dipotong dari Gambar**

Jika Anda ingin menghapus area yang dipotong dari gambar yang terdapat dalam bingkai, Anda dapat menggunakan metode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) . Metode ini mengembalikan gambar yang dipotong atau gambar asli bila pemotongan tidak diperlukan.

Kode Java ini memperlihatkan operasi tersebut:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Mendapatkan PictureFrame dari slide pertama
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Menghapus area yang dipotong dari gambar PictureFrame dan mengembalikan gambar yang dipotong
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Menyimpan hasil
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

The [deletePictureCroppedAreas()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) method adds the cropped image to the presentation image collection. If the image is only used in the processed [PictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pictureframe/), this setup can reduce the presentation size. Otherwise, the number of images in the resulting presentation will increase.

This method converts WMF/EMF metafiles to raster PNG image in the cropping operation. 

{{% /alert %}}

## **Kompres Gambar**

Anda dapat mengompres gambar dalam presentasi menggunakan metode [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . Metode ini mengompres gambar dengan mengurangi ukurannya berdasarkan ukuran bentuk dan resolusi yang ditentukan, dengan opsi untuk menghapus area yang dipotong.

Metode ini menyesuaikan ukuran dan resolusi gambar serupa dengan fitur **Picture Format > Compress Pictures > Resolution** di PowerPoint.

Contoh Java berikut memperlihatkan cara mengompres gambar dalam presentasi dengan menentukan resolusi target dan secara opsional menghapus area yang dipotong:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Kompres gambar dengan resolusi target 150 DPI (resolusi Web) dan hapus area yang dipotong.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Periksa hasil kompresi.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Atau menggunakan nilai DPI khusus secara langsung:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Kompres gambar ke 150 DPI (resolusi web), menghapus area yang dipotong.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

The method converts the image to a lower resolution based on the shape's size and provided DPI. Cropped regions can also be deleted to optimize file size.  
If the image is a metafile (WMF/EMF) or SVG, compression will not be applied. Also, JPEG quality is preserved or slightly reduced based on resolution, similarly to how PowerPoint handles high-resolution JPEGs.

{{% /alert %}}

## **Kunci Rasio Aspek**

Jika Anda ingin bentuk yang berisi gambar mempertahankan rasio aspeknya meskipun Anda mengubah dimensi gambar, Anda dapat menggunakan metode [setAspectRatioLocked](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) untuk mengatur pengaturan *Lock Aspect Ratio*.

Kode Java ini memperlihatkan cara mengunci rasio aspek bentuk:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // atur bentuk agar mempertahankan rasio aspek saat mengubah ukuran
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

This *Lock Aspect Ratio* setting preserves only the aspect ratio of the shape and not the image it contains.

{{% /alert %}}

## **Gunakan Properti StretchOff**

Dengan menggunakan properti [StretchOffsetLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) dan [StretchOffsetBottom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPictureFillFormat) serta kelas [PictureFillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPictureFillFormat), Anda dapat menentukan persegi panjang isi.

Saat peregangan ditentukan untuk sebuah gambar, persegi panjang sumber diskalakan untuk menyesuaikan persegi panjang isi yang ditentukan. Setiap tepi persegi panjang isi didefinisikan oleh offset persentase dari tepi yang bersesuaian pada kotak pembatas bentuk. Persentase positif menunjukkan inset sementara persentase negatif menunjukkan outset.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).  
2. Dapatkan referensi slide melalui indeksnya.  
3. Tambahkan persegi panjang `AutoShape`.  
4. Buat gambar.  
5. Atur jenis isi bentuk.  
6. Atur mode isi gambar bentuk.  
7. Tambahkan gambar yang diatur untuk mengisi bentuk.  
8. Tentukan offset gambar dari tepi yang bersesuaian pada kotak pembatas bentuk.  
9. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.  

Kode Java ini memperlihatkan proses penggunaan properti StretchOff:

```java
import com.aspose.slides.*;

// Menginstansiasi kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama
    ISlide slide = pres.getSlides().get_Item(0);

    // Menginstansiasi kelas ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Menambahkan AutoShape dengan tipe Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Mengatur tipe isian bentuk
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Mengatur mode isian gambar bentuk
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Mengatur gambar untuk mengisi bentuk
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Menentukan offset gambar dari tepi yang bersesuaian pada kotak pembatas bentuk
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    //Menulis file PPTX ke disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Bagaimana cara mengetahui format gambar apa yang didukung untuk PictureFrame?

Aspose.Slides mendukung baik gambar raster (PNG, JPEG, BMP, GIF, dll.) maupun gambar vektor (misalnya SVG) melalui objek gambar yang ditetapkan ke [PictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pictureframe/). Daftar format yang didukung umumnya tumpang tindih dengan kemampuan mesin konversi slide dan gambar.

### Bagaimana penambahan puluhan gambar berukuran besar memengaruhi ukuran dan kinerja PPTX?

Menyematkan gambar besar meningkatkan ukuran file dan penggunaan memori; menautkan gambar membantu menjaga ukuran presentasi tetap kecil namun memerlukan file eksternal tetap dapat diakses. Aspose.Slides menyediakan kemampuan menambahkan gambar melalui tautan untuk mengurangi ukuran file.

### Bagaimana cara mengunci objek gambar agar tidak secara tidak sengaja dipindahkan/diperbesar kembali?

Gunakan [shape locks](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) untuk sebuah [PictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pictureframe/) (misalnya menonaktifkan pemindahan atau pengubahan ukuran). Mekanisme penguncian ini didukung untuk berbagai tipe bentuk, termasuk [PictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pictureframe/).

### Apakah integritas vektor SVG tetap terjaga saat mengekspor presentasi ke PDF/gambar?

Aspose.Slides memungkinkan mengekstrak SVG dari sebuah [PictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pictureframe/) sebagai vektor asli. Saat [mengekspor ke PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/) atau [format raster](/slides/id/androidjava/convert-powerpoint-to-png/), hasilnya dapat dirasterisasi tergantung pada pengaturan ekspor; fakta bahwa SVG asli disimpan sebagai vektor dikonfirmasi oleh perilaku ekstraksi.