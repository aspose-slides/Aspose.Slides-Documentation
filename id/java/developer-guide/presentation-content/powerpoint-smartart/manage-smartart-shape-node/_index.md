---
title: Kelola Node Bentuk SmartArt dalam Presentasi Menggunakan Java
linktitle: Node Bentuk SmartArt
type: docs
weight: 30
url: /id/java/manage-smartart-shape-node/
keywords:
- node SmartArt
- node anak
- menambahkan node
- posisi node
- akses node
- hapus node
- posisi kustom
- node asisten
- format isi
- render node
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Kelola node bentuk SmartArt dalam PPT dan PPTX dengan Aspose.Slides untuk Java. Dapatkan contoh kode yang jelas dan tip untuk menyederhanakan presentasi Anda."
---
## **Ringkasan**

Grafik SmartArt dalam presentasi PowerPoint diatur melalui node yang berisi teks dan menentukan struktur diagram. Aspose.Slides memungkinkan Anda bekerja dengan node SmartArt ini secara programatik: menambahkan node baru dan node anak, menyisipkan node anak pada posisi tertentu, mengakses node yang ada, serta membaca teks, level, dan posisi mereka.

Artikel ini menjelaskan cara mengelola node bentuk SmartArt. Artikel ini menunjukkan cara menghapus node, bekerja dengan node anak berdasarkan indeks atau posisi, mengubah node asisten menjadi node normal, menyesuaikan posisi, ukuran, dan rotasi bentuk node SmartArt, mengatur format isi node, serta menghasilkan gambar thumbnail untuk node anak SmartArt.

```java
import com.aspose.slides.*;

// Muat presentasi yang diinginkan
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Telusuri setiap shape di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Periksa apakah shape bertipe SmartArt
        if (shape instanceof SmartArt) 
        {
            // Lakukan typecast shape menjadi SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Menambahkan Node SmartArt baru
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Menambahkan teks
            TemNode.getTextFrame().setText("Test");
    
            // Menambahkan node anak baru dalam node induk. Node ini akan ditambahkan di akhir koleksi
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Menambahkan teks
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Menyimpan Presentasi
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menambahkan Node SmartArt**
Aspose.Slides for Java telah menyediakan API paling sederhana untuk mengelola bentuk SmartArt dengan cara termudah. Kode contoh berikut akan membantu menambahkan node dan node anak di dalam bentuk SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation) dan muat presentasi yang berisi Shape SmartArt.  
2. Dapatkan referensi slide pertama dengan menggunakan indeksnya.  
3. Telusuri setiap shape di dalam slide pertama.  
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) dan lakukan typecast pada shape yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) jika memang SmartArt.  
5. [Tambahkan Node baru](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) pada shape SmartArt [**NodeCollection**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt#getAllNodes--) dan atur teks di TextFrame.  
6. Sekarang, [Tambahkan](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) sebuah [**Child Node**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pada Node [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) yang baru ditambahkan dan atur teks di TextFrame.  
7. Simpan Presentasi.

```java
import com.aspose.slides.*;

// Membuat instance presentasi
Presentation pres = new Presentation();
try {
    // Mengakses slide presentasi
    ISlide slide = pres.getSlides().get_Item(0);

    // Menambahkan IShape Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Mengakses node SmartArt pada indeks 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Menambahkan node anak baru pada posisi 2 di node induk
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Menambahkan Teks
    chNode.getTextFrame().setText("Sample Text Added");

    // Menyimpan Presentasi
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menambahkan Node SmartArt pada Posisi Tertentu**
Pada kode contoh berikut kami menjelaskan cara menambahkan node anak yang termasuk dalam masing‑masing node bentuk SmartArt pada posisi tertentu.

1. Buat instance kelas Presentation.  
2. Dapatkan referensi slide pertama dengan menggunakan indeksnya.  
3. Tambahkan shape [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArt) tipe [**StackedList**](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArtLayoutType#StackedList) pada slide yang diakses.  
4. Akses node pertama pada shape SmartArt yang ditambahkan.  
5. Sekarang, tambahkan [**Child Node**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArtNode#getChildNodes--) untuk [**Node**](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArtNode) yang dipilih pada posisi 2 dan atur teksnya.  
6. Simpan Presentasi.

```java
import com.aspose.slides.*;

// Membuat Instance Kelas Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Dapatkan slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Telusuri setiap shape di dalam slide pertama
    for (IShape shape : slide.getShapes()) 
    {
        // Periksa apakah shape bertipe SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Lakukan typecast shape menjadi SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Telusuri semua node di dalam SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Mengakses node SmartArt pada indeks i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Mencetak parameter node SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengakses Node SmartArt**
Kode contoh berikut akan membantu mengakses node di dalam shape SmartArt. Harap dicatat bahwa Anda tidak dapat mengubah LayoutType SmartArt karena bersifat read‑only dan hanya diatur ketika shape SmartArt ditambahkan.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dan muat presentasi dengan Shape SmartArt.  
2. Dapatkan referensi slide pertama dengan menggunakan indeksnya.  
3. Telusuri setiap shape di dalam slide pertama.  
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) dan lakukan typecast pada shape yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) jika memang SmartArt.  
5. Telusuri semua [**Nodes**](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArt#getAllNodes--) di dalam Shape SmartArt.  
6. Akses dan tampilkan informasi seperti posisi, level, dan Teks Node SmartArt.

```java
import com.aspose.slides.*;

// Membuat Instance Kelas Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Dapatkan slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Telusuri setiap shape di dalam slide pertama
    for (IShape shape : slide.getShapes()) 
    {
        // Periksa apakah shape bertipe SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Lakukan typecast shape menjadi SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Telusuri semua node di dalam SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Mengakses node SmartArt pada indeks i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Menelusuri node anak dalam node SmartArt pada indeks i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Mengakses node anak dalam node SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Mencetak parameter node anak SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengakses Node Anak SmartArt**
Kode contoh berikut akan membantu mengakses node anak yang termasuk dalam masing‑masing node shape SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dan muat presentasi dengan Shape SmartArt.  
2. Dapatkan referensi slide pertama dengan menggunakan indeksnya.  
3. Telusuri setiap shape di dalam slide pertama.  
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) dan lakukan typecast pada shape yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) jika memang SmartArt.  
5. Telusuri semua [**Nodes**](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArt#getAllNodes--) di dalam Shape SmartArt.  
6. Untuk setiap [**Node**](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArtNode) shape SmartArt yang dipilih, telusuri semua [**Child Nodes**](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArtNode#getChildNodes--) di dalam node tertentu.  
7. Akses dan tampilkan informasi seperti posisi, level, dan Teks [**Child Node**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Membuat instance presentasi
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Menambahkan shape SmartArt di slide pertama
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Mengakses node SmartArt pada indeks 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Mengakses node anak pada posisi 1 di node induk
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Mencetak parameter node anak SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengakses Node Anak SmartArt pada Posisi Tertentu**
Pada contoh ini, kami akan belajar mengakses node anak pada posisi tertentu yang termasuk dalam masing‑masing node shape SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).  
2. Dapatkan referensi slide pertama dengan menggunakan indeksnya.  
3. Tambahkan shape SmartArt tipe [**StackedList**](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArtLayoutType#StackedList).  
4. Akses shape SmartArt yang ditambahkan.  
5. Akses node pada indeks 0 untuk shape SmartArt yang diakses.  
6. Sekarang, akses [**Child Node**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pada posisi 1 untuk node SmartArt yang diakses menggunakan metode **get_Item()**.  
7. Akses dan tampilkan informasi seperti posisi, level, dan Teks [**Child Node**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
import com.aspose.slides.*;

// Muat presentasi yang diinginkan
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Telusuri setiap shape di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Periksa apakah shape bertipe SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Lakukan typecast shape menjadi SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Mengakses node SmartArt pada indeks 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Menghapus node yang dipilih
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Simpan Presentasi
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menghapus Node SmartArt**
Dalam contoh ini, kami akan belajar menghapus node di dalam shape SmartArt.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dan muat presentasi dengan Shape SmartArt.  
2. Dapatkan referensi slide pertama dengan menggunakan indeksnya.  
3. Telusuri setiap shape di dalam slide pertama.  
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) dan lakukan typecast pada shape yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) jika memang SmartArt.  
5. Periksa apakah [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) memiliki lebih dari 0 node.  
6. Pilih node SmartArt yang akan dihapus.  
7. Sekarang, hapus node yang dipilih menggunakan metode [**RemoveNode**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Simpan Presentasi.

```java
import com.aspose.slides.*;

// Muat presentasi yang diinginkan
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Telusuri setiap shape di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Periksa apakah shape bertipe SmartArt
        if (shape instanceof SmartArt) 
        {
            // Lakukan typecast shape menjadi SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Mengakses node SmartArt pada indeks 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Menghapus node anak pada posisi 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Simpan Presentasi
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menghapus Node SmartArt dari Posisi Tertentu**
Dalam contoh ini, kami akan belajar menghapus node di dalam shape SmartArt pada posisi tertentu.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dan muat presentasi dengan Shape SmartArt.  
2. Dapatkan referensi slide pertama dengan menggunakan indeksnya.  
3. Telusuri setiap shape di dalam slide pertama.  
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) dan lakukan typecast pada shape yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) jika memang SmartArt.  
5. Pilih node shape SmartArt pada indeks 0.  
6. Sekarang, periksa apakah node SmartArt yang dipilih memiliki lebih dari 2 node anak.  
7. Sekarang, hapus node pada **Posisi 1** menggunakan metode [**RemoveNode**](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
8. Simpan Presentasi.

```java
import com.aspose.slides.*;

// Membuat Instance Kelas Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Pindahkan shape SmartArt ke posisi baru
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Ubah lebar shape SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Ubah tinggi shape SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Ubah rotasi shape SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Mengatur Posisi Kustom untuk Node Anak dalam Objek SmartArt**
Sekarang Aspose.Slides for Java mendukung penetapan properti [SmartArtShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShape#setX-float-) dan [Y](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShape#setY-float-). Potongan kode di bawah menunjukkan cara mengatur posisi, ukuran, dan rotasi SmartArtShape secara kustom, serta perlu dicatat bahwa menambahkan node baru menyebabkan perhitungan ulang posisi dan ukuran semua node. Dengan pengaturan posisi kustom, pengguna dapat menyesuaikan node sesuai kebutuhan.

```java
import com.aspose.slides.*;

// Membuat instance presentasi
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Telusuri setiap shape di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Periksa apakah shape bertipe SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Lakukan typecast shape menjadi SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Menelusuri semua node pada shape SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Periksa apakah node merupakan node Asisten
                if (node.isAssistant()) 
                {
                    // Mengatur node Asisten menjadi false dan menjadikannya node normal
                    node.setAssistant(false);
                }
            }
        }
    }
    
    // Simpan Presentasi
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
Dalam artikel ini kami akan menyelidiki lebih lanjut fitur-fitur shape SmartArt yang ditambahkan pada slide presentasi secara programatis menggunakan Aspose.Slides for Java.
{{% /alert %}} 

Kami akan menggunakan shape SmartArt sumber berikut untuk penyelidikan kami di bagian‑bagian artikel ini.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Gambar: Shape SmartArt sumber dalam slide**|

Pada kode contoh berikut kami akan menyelidiki cara mengidentifikasi **Assistant Nodes** dalam koleksi node SmartArt dan mengubahnya.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation) dan muat presentasi dengan Shape SmartArt.  
2. Dapatkan referensi slide kedua dengan menggunakan indeksnya.  
3. Telusuri setiap shape di dalam slide pertama.  
4. Periksa apakah shape bertipe [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) dan lakukan typecast pada shape yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) jika memang SmartArt.  
5. Telusuri semua node di dalam shape SmartArt dan periksa apakah mereka adalah [**Assistant Nodes**](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArtNode#isAssistant--).  
6. Ubah status Assistant Node menjadi node normal.  
7. Simpan Presentasi.

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Gambar: Assistant Nodes Diubah dalam shape SmartArt di dalam slide**|

## **Mengatur Format Isi Node**
Aspose.Slides for Java memungkinkan penambahan shape SmartArt kustom dan pengaturan format isi mereka. Artikel ini menjelaskan cara membuat dan mengakses shape SmartArt serta mengatur format isi mereka menggunakan Aspose.Slides for Java.

Silakan ikuti langkah‑langkah di bawah ini:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).  
2. Dapatkan referensi slide menggunakan indeksnya.  
3. Tambahkan shape [SmartArt](https://reference.aspose.com/slides/id/java/com.aspose.slides/ISmartArt) dengan mengatur [**LayoutType**](https://reference.aspose.com/slides/id/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Atur [**FillFormat**](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShape#getFillFormat--) untuk node shape SmartArt.  
5. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Membuat instance presentasi
Presentation pres = new Presentation();
try {
    // Mengakses slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Menambahkan shape SmartArt dan node
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Menetapkan warna isi node
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Simpan presentasi
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menghasilkan Thumbnail untuk Node Anak SmartArt**
Pengembang dapat menghasilkan thumbnail untuk node anak SmartArt dengan mengikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).  
2. Tambahkan SmartArt.  
3. Dapatkan referensi sebuah node dengan menggunakan indeksnya.  
4. Dapatkan gambar thumbnail.  
5. Simpan gambar thumbnail dalam format gambar yang diinginkan.

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang merepresentasikan file PPTX
Presentation pres = new Presentation();
try {
    // Tambahkan SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Dapatkan referensi node dengan menggunakan indeksnya  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Dapatkan thumbnail
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Simpan thumbnail
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Apakah animasi SmartArt didukung?
Ya. SmartArt diperlakukan sebagai shape biasa, sehingga Anda dapat [menerapkan animasi standar](/slides/id/java/shape-animation/) (masuk, keluar, penekanan, jalur gerak) dan menyesuaikan timing. Anda juga dapat menganimasikan shape di dalam node SmartArt bila diperlukan.

### Bagaimana cara saya dapat menemukan SmartArt tertentu pada slide secara andal jika ID internalnya tidak diketahui?
Berikan dan cari berdasarkan [teks alternatif](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getAlternativeText--). Menetapkan AltText yang khas pada SmartArt memungkinkan Anda menemukannya secara programatik tanpa bergantung pada identifier internal.

### Apakah tampilan SmartArt akan dipertahankan saat mengonversi presentasi ke PDF?
Ya. Aspose.Slides merender SmartArt dengan fidelitas visual tinggi selama [ekspor PDF](/slides/id/java/convert-powerpoint-to-pdf/), mempertahankan tata letak, warna, dan efek.

### Bisakah saya mengekstrak gambar seluruh SmartArt (untuk preview atau laporan)?
Ya. Anda dapat merender shape SmartArt ke [format raster](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getImage-int-float-float-) atau ke [SVG](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) untuk output vektor skalabel, menjadikannya cocok untuk thumbnail, laporan, atau penggunaan web.