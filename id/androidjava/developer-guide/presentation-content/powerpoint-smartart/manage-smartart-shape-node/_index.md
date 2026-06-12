---
title: Kelola Node Bentuk SmartArt dalam Presentasi di Android
linktitle: Node Bentuk SmartArt
type: docs
weight: 30
url: /id/androidjava/manage-smartart-shape-node/
keywords:
- node SmartArt
- node anak
- tambahkan node
- posisi node
- akses node
- hapus node
- posisi kustom
- node asisten
- format isian
- node render
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola node bentuk SmartArt dalam PPT dan PPTX dengan Aspose.Slides untuk Android. Dapatkan contoh kode Java yang jelas dan tip untuk menyederhanakan presentasi Anda."
---
## **Gambaran Umum**

Grafik SmartArt dalam presentasi PowerPoint diatur melalui node yang berisi teks dan mendefinisikan struktur diagram. Aspose.Slides memungkinkan Anda bekerja dengan node SmartArt secara programatik: menambahkan node dan node anak baru, menyisipkan node anak pada posisi tertentu, mengakses node yang ada, dan membaca teks, level, serta posisi mereka.

Artikel ini menjelaskan cara mengelola node bentuk SmartArt. Menunjukkan cara menghapus node, bekerja dengan node anak berdasarkan indeks atau posisi, mengubah node asisten menjadi node normal, menyesuaikan posisi, ukuran, dan rotasi bentuk node SmartArt, mengatur format isian node, serta menghasilkan gambar miniatur untuk node anak SmartArt.

## **Menambahkan Node SmartArt**
Aspose.Slides for Android via Java menyediakan API paling sederhana untuk mengelola bentuk SmartArt dengan cara termudah. Kode contoh berikut akan membantu menambahkan node dan node anak di dalam bentuk SmartArt.

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk merupakan tipe [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) dan lakukan Typecast bentuk yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) jika itu SmartArt.  
1. [Tambahkan Node Baru](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) dalam koleksi [**NodeCollection**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) SmartArt dan atur teks di TextFrame.  
1. Sekarang, [Tambahkan](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) sebuah [**Node Anak**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) pada node SmartArt yang baru ditambahkan dan atur teks di TextFrame.  
1. Simpan Presentasi.

```java
// Muat presentasi yang diinginkan
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Telusuri setiap bentuk di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Periksa apakah bentuk merupakan tipe SmartArt
        if (shape instanceof SmartArt) 
        {
            // Lakukan typecast bentuk menjadi SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Menambahkan Node SmartArt baru
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Menambahkan teks
            TemNode.getTextFrame().setText("Test");
    
            // Menambahkan node anak baru dalam node induk. Akan ditambahkan di akhir koleksi
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

## **Menambahkan Node SmartArt pada Posisi Tertentu**
Dalam contoh kode berikut kami menjelaskan cara menambahkan node anak yang termasuk dalam node masing‑masing pada bentuk SmartArt pada posisi tertentu.

1. Buat instance kelas Presentasi.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Tambahkan bentuk [**StackedList**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) tipe [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArt) pada slide yang diakses.  
1. Akses node pertama pada SmartArt yang ditambahkan.  
1. Sekarang, tambahkan [**Node Anak**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) untuk [**Node**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtNode) yang dipilih pada posisi 2 dan atur teksnya.  
1. Simpan Presentasi.

```java
// Membuat instance presentasi
Presentation pres = new Presentation();
try {
    // Mengakses slide presentasi
    ISlide slide = pres.getSlides().get_Item(0);

    // Menambahkan IShape Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Mengakses node SmartArt pada indeks 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Menambahkan node anak baru pada posisi 2 dalam node induk
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Menambahkan Teks
    chNode.getTextFrame().setText("Sample Text Added");

    // Menyimpan Presentasi
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengakses Node SmartArt**
Kode contoh berikut akan membantu mengakses node di dalam bentuk SmartArt. Perlu dicatat bahwa Anda tidak dapat mengubah LayoutType SmartArt karena bersifat read‑only dan hanya ditetapkan saat bentuk SmartArt ditambahkan.

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk merupakan tipe [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) dan lakukan Typecast bentuk yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) jika itu SmartArt.  
1. Telusuri semua [**Node**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArt#getAllNodes--) di dalam Bentuk SmartArt.  
1. Akses dan tampilkan informasi seperti posisi Node SmartArt, level, dan Teks.

```java
// Membuat Instance Kelas Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Dapatkan slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Telusuri setiap bentuk di dalam slide pertama
    for (IShape shape : slide.getShapes()) 
    {
        // Periksa apakah bentuk merupakan tipe SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Lakukan typecast bentuk menjadi SmartArt
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

## **Mengakses Node Anak SmartArt**
Kode contoh berikut akan membantu mengakses node anak yang termasuk dalam node masing‑masing pada bentuk SmartArt.

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk merupakan tipe [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) dan lakukan Typecast bentuk yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) jika itu SmartArt.  
1. Telusuri semua [**Node**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArt#getAllNodes--) di dalam Bentuk SmartArt.  
1. Untuk setiap [**Node**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtNode) SmartArt yang dipilih, telusuri semua [**Node Anak**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) di dalam node tertentu.  
1. Akses dan tampilkan informasi seperti posisi, level, dan Teks [**Node Anak**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Membuat Instance Kelas Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Dapatkan slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Menelusuri setiap bentuk di dalam slide pertama
    for (IShape shape : slide.getShapes()) 
    {
        // Memeriksa apakah bentuk berupa tipe SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Melakukan typecast bentuk menjadi SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Menelusuri semua node di dalam SmartArt
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

## **Mengakses Node Anak SmartArt pada Posisi Tertentu**
Dalam contoh ini, kami akan mempelajari cara mengakses node anak pada posisi tertentu yang termasuk dalam node masing‑masing pada bentuk SmartArt.

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Tambahkan bentuk [**StackedList**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) tipe SmartArt.  
1. Akses bentuk SmartArt yang ditambahkan.  
1. Akses node pada indeks 0 untuk bentuk SmartArt yang diakses.  
1. Sekarang, akses [**Node Anak**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) pada posisi 1 untuk node SmartArt yang diakses menggunakan metode **get_Item()**.  
1. Akses dan tampilkan informasi seperti posisi, level, dan Teks [**Node Anak**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--).

```java
// Membuat instance presentasi
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Menambahkan bentuk SmartArt pada slide pertama
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Mengakses node SmartArt pada indeks 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Mengakses node anak pada posisi 1 dalam node induk
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Mencetak parameter node anak SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menghapus Node SmartArt**
Dalam contoh ini, kami akan mempelajari cara menghapus node di dalam bentuk SmartArt.

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk merupakan tipe [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) dan lakukan Typecast bentuk yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) jika itu SmartArt.  
1. Periksa apakah [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) memiliki lebih dari 0 node.  
1. Pilih node SmartArt yang akan dihapus.  
1. Sekarang, hapus node yang dipilih menggunakan metode [**RemoveNode**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
1. Simpan Presentasi.

```java
// Muat presentasi yang diinginkan
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Telusuri setiap bentuk di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Periksa apakah bentuk merupakan tipe SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Lakukan typecast bentuk menjadi SmartArt
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

## **Menghapus Node SmartArt dari Posisi Tertentu**
Dalam contoh ini, kami akan mempelajari cara menghapus node di dalam bentuk SmartArt pada posisi tertentu.

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide pertama dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk merupakan tipe [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) dan lakukan Typecast bentuk yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) jika itu SmartArt.  
1. Pilih node bentuk SmartArt pada indeks 0.  
1. Sekarang, periksa apakah node SmartArt yang dipilih memiliki lebih dari 2 node anak.  
1. Sekarang, hapus node pada **Posisi 1** menggunakan metode [**RemoveNode**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
1. Simpan Presentasi.

```java
// Muat presentasi yang diinginkan
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Telusuri setiap bentuk di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Periksa apakah bentuk merupakan tipe SmartArt
        if (shape instanceof SmartArt) 
        {
            // Lakukan typecast bentuk menjadi SmartArt
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

## **Menetapkan Posisi Kustom untuk Node Anak dalam Objek SmartArt**
Sekarang Aspose.Slides for Android via Java mendukung pengaturan properti [SmartArtShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtShape) [X](httpshttps://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#setX-float-) dan [Y](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#setY-float-). Potongan kode di bawah ini menunjukkan cara menetapkan posisi, ukuran, dan rotasi kustom SmartArtShape; juga harap perhatikan bahwa menambahkan node baru menyebabkan perhitungan ulang posisi dan ukuran semua node. Dengan pengaturan posisi kustom, pengguna dapat menempatkan node sesuai kebutuhan.

```java
// Buat Instance Kelas Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Pindahkan bentuk SmartArt ke posisi baru
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Ubah lebar bentuk SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Ubah tinggi bentuk SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Ubah rotasi bentuk SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Memeriksa Node Asisten**
{{% alert color="primary" %}} 

Dalam artikel ini kami akan meneliti lebih lanjut fitur bentuk SmartArt yang ditambahkan ke slide presentasi secara programatik menggunakan Aspose.Slides for Android via Java.

{{% /alert %}} 

Kami akan menggunakan bentuk SmartArt sumber berikut untuk penyelidikan di berbagai bagian artikel ini.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Gambar: Bentuk SmartArt sumber dalam slide**|

Dalam kode contoh berikut kami akan menyelidiki cara mengidentifikasi **Node Asisten** dalam koleksi node SmartArt dan mengubahnya.

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation) dan muat presentasi dengan Bentuk SmartArt.  
1. Dapatkan referensi slide kedua dengan menggunakan Indeksnya.  
1. Telusuri setiap bentuk di dalam slide pertama.  
1. Periksa apakah bentuk merupakan tipe [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) dan lakukan Typecast bentuk yang dipilih menjadi [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) jika itu SmartArt.  
1. Telusuri semua node di dalam bentuk SmartArt dan periksa apakah mereka adalah [**Node Asisten**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
1. Ubah status Node Asisten menjadi node normal.  
1. Simpan Presentasi.

```java
// Membuat instance presentasi
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Menelusuri setiap bentuk di dalam slide pertama
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Periksa apakah bentuk merupakan tipe SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Lakukan typecast bentuk menjadi SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Menelusuri semua node dari bentuk SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Periksa apakah node adalah node Asisten
                if (node.isAssistant()) 
                {
                    // Mengatur node Asisten menjadi false dan menjadikannya node normal
                    node.isAssistant();
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

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Gambar: Node Asisten Diubah dalam Bentuk SmartArt di slide**|

## **Menetapkan Format Isian Node**
Aspose.Slides for Android via Java memungkinkan penambahan bentuk SmartArt khusus dan penetapan format isinya. Artikel ini menjelaskan cara membuat dan mengakses bentuk SmartArt serta menetapkan format isinya menggunakan Aspose.Slides for Android via Java.

Silakan ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).  
1. Dapatkan referensi slide menggunakan indeksnya.  
1. Tambahkan bentuk [SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArt) dengan mengatur [**LayoutType**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
1. Tetapkan [**FillFormat**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape#getFillFormat--) untuk node bentuk SmartArt.  
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```java
// Membuat instance presentasi
Presentation pres = new Presentation();
try {
    // Mengakses slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Menambahkan bentuk SmartArt dan node
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Mengatur warna isian node
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

## **Membuat Thumbnail Node Anak SmartArt**
Pengembang dapat membuat thumbnail node Anak dari SmartArt dengan mengikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).  
1. [Tambahkan SmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
1. Dapatkan referensi node dengan menggunakan Indeksnya.  
1. Dapatkan gambar thumbnail.  
1. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

```java
// Buat instance kelas Presentation yang merepresentasikan file PPTX 
Presentation pres = new Presentation();
try {
    // Tambah SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Dapatkan referensi node dengan menggunakan Indeksnya  
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

**Apakah animasi SmartArt didukung?**

Ya. SmartArt diperlakukan sebagai bentuk biasa, sehingga Anda dapat [menerapkan animasi standar](/slides/id/androidjava/shape-animation/) (masuk, keluar, penekanan, jalur gerak) dan menyesuaikan waktu. Anda juga dapat menganimasikan bentuk di dalam node SmartArt bila diperlukan.

**Bagaimana cara menemukan SmartArt tertentu pada slide jika ID internalnya tidak diketahui?**

Tetapkan dan cari berdasarkan [teks alternatif](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getAlternativeText--). Menetapkan AltText yang khas pada SmartArt memungkinkan Anda menemukannya secara programatik tanpa mengandalkan pengenal internal.

**Apakah tampilan SmartArt akan tetap terjaga saat mengonversi presentasi ke PDF?**

Ya. Aspose.Slides merender SmartArt dengan fidelitas visual tinggi selama [ekspor PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/), mempertahankan tata letak, warna, dan efek.

**Bisakah saya mengekstrak gambar seluruh SmartArt (untuk pratinjau atau laporan)?**

Ya. Anda dapat merender bentuk SmartArt ke [format raster](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) atau ke [SVG](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) untuk output vektor skalabel, sehingga cocok untuk thumbnail, laporan, atau penggunaan web.