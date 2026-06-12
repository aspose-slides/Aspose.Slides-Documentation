---
title: Kelola Node Bentuk SmartArt dalam Presentasi di .NET
linktitle: Node Bentuk SmartArt
type: docs
weight: 30
url: /id/net/manage-smartart-shape-node/
keywords:
- Node SmartArt
- Node anak
- Tambah node
- Posisi node
- Akses node
- Hapus node
- Posisi kustom
- Node asisten
- Format isi
- Node render
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola node bentuk SmartArt dalam file PPT dan PPTX dengan Aspose.Slides untuk .NET. Dapatkan contoh kode yang jelas dan tips untuk menyederhanakan presentasi Anda."
---
## **Ikhtisar**

Grafik SmartArt dalam presentasi PowerPoint diatur melalui node yang berisi teks dan menentukan struktur diagram. Aspose.Slides memungkinkan Anda bekerja dengan node SmartArt ini secara programatik: menambahkan node baru dan node anak, menyisipkan node anak pada posisi tertentu, mengakses node yang ada, serta membaca teks, level, dan posisi mereka.

Artikel ini menjelaskan cara mengelola node bentuk SmartArt. Ditunjukkan cara menghapus node, bekerja dengan node anak berdasarkan indeks atau posisi, mengubah assistant node menjadi node normal, menyesuaikan posisi, ukuran, dan rotasi bentuk node SmartArt, menetapkan format pengisian node, dan menghasilkan gambar thumbnail untuk child node SmartArt.

## **Menambahkan Node SmartArt**
Aspose.Slides untuk .NET telah menyediakan API paling sederhana untuk mengelola bentuk SmartArt dengan cara termudah. Kode contoh berikut akan membantu menambahkan node dan child node di dalam bentuk SmartArt.

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dan muat presentasi dengan SmartArt Shape.
- Dapatkan referensi slide pertama dengan menggunakan Index-nya.
- Jelajahi setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArt jika memang SmartArt.
- Tambahkan Node baru ke NodeCollection SmartArt shape dan setel teks di TextFrame.
- Sekarang, tambahkan Child Node ke SmartArt Node yang baru ditambahkan dan setel teks di TextFrame.
- Simpan Presentasi.

```c#
// Muat presentasi yang diinginkan
Presentation pres = new Presentation("AddNodes.pptx");

// Telusuri setiap shape di dalam slide pertama
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Periksa apakah shape bertipe SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Lakukan typecast shape menjadi SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Menambahkan SmartArt Node baru
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Menambahkan teks
        TemNode.TextFrame.Text = "Test";

        // Menambahkan child node baru pada node induk. Akan ditambahkan di akhir koleksi
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Menambahkan teks
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Menyimpan Presentasi
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Menambahkan Node SmartArt pada Posisi Tertentu**
Dalam contoh kode berikut kami menjelaskan cara menambahkan child node yang termasuk ke dalam node masing‑masing dari bentuk SmartArt pada posisi tertentu.

- Buat sebuah instance dari kelas `Presentation`.
- Dapatkan referensi slide pertama dengan menggunakan Index-nya.
- Tambahkan SmartArt shape tipe StackedList pada slide yang diakses.
- Akses node pertama pada SmartArt shape yang ditambahkan.
- Sekarang, tambahkan Child Node untuk Node yang dipilih pada posisi 2 dan setel teksnya.
- Simpan Presentasi.

```c#
// Membuat instance presentasi
Presentation pres = new Presentation();

// Mengakses slide presentasi
ISlide slide = pres.Slides[0];

// Menambahkan Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Mengakses node SmartArt pada indeks 0
ISmartArtNode node = smart.AllNodes[0];

// Menambahkan child node baru pada posisi 2 di node induk
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Menambahkan Teks
chNode.TextFrame.Text = "Sample Text Added";

// Menyimpan Presentasi
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Mengakses Node SmartArt**
Kode contoh berikut akan membantu mengakses node di dalam bentuk SmartArt. Harap dicatat bahwa Anda tidak dapat mengubah LayoutType SmartArt karena bersifat read‑only dan hanya ditetapkan saat bentuk SmartArt ditambahkan.

- Buat sebuah instance dari kelas `Presentation` dan muat presentasi dengan SmartArt Shape.
- Dapatkan referensi slide pertama dengan menggunakan Index-nya.
- Jelajahi setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArt jika memang SmartArt.
- Jelajahi semua Node di dalam SmartArt Shape.
- Akses dan tampilkan informasi seperti posisi Node SmartArt, level, dan Teks.

```c#
  // Muat presentasi yang diinginkan
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Menelusuri setiap shape di dalam slide pertama
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Periksa apakah shape bertipe SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Lakukan typecast shape menjadi SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Menelusuri semua node di dalam SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Mengakses node SmartArt pada indeks i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Mencetak parameter node SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

## **Mengakses Child Node SmartArt**
Kode contoh berikut akan membantu mengakses child node yang termasuk ke dalam node masing‑masing dari bentuk SmartArt.

- Buat sebuah instance dari kelas PresentationEx dan muat presentasi dengan SmartArt Shape.
- Dapatkan referensi slide pertama dengan menggunakan Index-nya.
- Jelajahi setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArtEx jika memang SmartArt.
- Jelajahi semua Node di dalam SmartArt Shape.
- Untuk setiap SmartArt shape Node yang dipilih, jelajahi semua Child Node di dalam node tersebut.
- Akses dan tampilkan informasi seperti posisi Child Node, level, dan Teks.

```c#
// Muat presentasi yang diinginkan
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Menelusuri setiap shape di dalam slide pertama
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Memeriksa apakah shape bertipe SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Lakukan typecast shape menjadi SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Menelusuri semua node di dalam SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Mengakses node SmartArt pada indeks i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Menelusuri child node di dalam node SmartArt pada indeks i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Mengakses child node di dalam node SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Mencetak parameter child node SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```

## **Mengakses Child Node SmartArt pada Posisi Tertentu**
Dalam contoh ini, kita akan belajar mengakses child node pada posisi tertentu yang termasuk ke dalam node masing‑masing dari bentuk SmartArt.

- Buat sebuah instance dari kelas `Presentation`.
- Dapatkan referensi slide pertama dengan menggunakan Index-nya.
- Tambahkan SmartArt shape tipe StackedList.
- Akses SmartArt shape yang ditambahkan.
- Akses node pada indeks 0 untuk SmartArt shape yang diakses.
- Sekarang, akses Child Node pada posisi 1 untuk SmartArt node yang diakses menggunakan metode GetNodeByPosition().
- Akses dan tampilkan informasi seperti posisi Child Node, level, dan Teks.

```c#
// Membuat instance presentasi
Presentation pres = new Presentation();

// Mengakses slide pertama
ISlide slide = pres.Slides[0];

// Menambahkan bentuk SmartArt di slide pertama
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Mengakses node SmartArt pada indeks 0
ISmartArtNode node = smart.AllNodes[0];

// Mengakses child node pada posisi 1 di node induk
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Mencetak parameter child node SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```

## **Menghapus Node SmartArt**
Dalam contoh ini, kita akan belajar menghapus node di dalam bentuk SmartArt.

- Buat sebuah instance dari kelas `Presentation` dan muat presentasi dengan SmartArt Shape.
- Dapatkan referensi slide pertama dengan menggunakan Index-nya.
- Jelajahi setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArt jika memang SmartArt.
- Periksa apakah SmartArt memiliki lebih dari 0 node.
- Pilih node SmartArt yang akan dihapus.
- Sekarang, hapus node yang dipilih menggunakan metode RemoveNode() * Simpan Presentasi.

```c#
// Muat presentasi yang diinginkan
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Menelusuri setiap shape di dalam slide pertama
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Memeriksa apakah shape bertipe SmartArt
        if (shape is ISmartArt)
        {
            // Lakukan typecast shape menjadi SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Mengakses node SmartArt pada indeks 0
                ISmartArtNode node = smart.AllNodes[0];

                // Menghapus node yang dipilih
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Simpan Presentasi
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Menghapus Node SmartArt pada Posisi Tertentu**
Dalam contoh ini, kita akan belajar menghapus node di dalam bentuk SmartArt pada posisi tertentu.

- Buat sebuah instance dari kelas `Presentation` dan muat presentasi dengan SmartArt Shape.
- Dapatkan referensi slide pertama dengan menggunakan Index-nya.
- Jelajahi setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArt jika memang SmartArt.
- Pilih node bentuk SmartArt pada indeks 0.
- Sekarang, periksa apakah node SmartArt yang dipilih memiliki lebih dari 2 child node.
- Sekarang, hapus node pada Posisi 1 menggunakan metode RemoveNodeByPosition().
- Simpan Presentasi.

```c#
// Muat presentasi yang diinginkan             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Menelusuri setiap shape di dalam slide pertama
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Memeriksa apakah shape bertipe SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Lakukan typecast shape menjadi SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Mengakses node SmartArt pada indeks 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Menghapus child node pada posisi 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Simpan Presentasi
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Menetapkan Posisi Kustom untuk Child Node dalam Objek SmartArt**
Sekarang Aspose.Slides untuk .NET mendukung pengaturan properti X dan Y SmartArtShape. Potongan kode di bawah ini memperlihatkan cara menetapkan posisi, ukuran, dan rotasi kustom SmartArtShape; juga harap dicatat bahwa penambahan node baru menyebabkan perhitungan ulang posisi dan ukuran semua node.

```c#
// Muat presentasi yang diinginkan
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Pindahkan shape SmartArt ke posisi baru
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Ubah lebar shape SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Ubah tinggi shape SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Ubah rotasi shape SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```

## **Memeriksa Assistant Node**
Dalam kode contoh berikut kami akan menyelidiki cara mengidentifikasi Assistant Node dalam koleksi node SmartArt dan mengubahnya.

- Buat sebuah instance dari kelas PresentationEx dan muat presentasi dengan SmartArt Shape.
- Dapatkan referensi slide kedua dengan menggunakan Index-nya.
- Jelajahi setiap shape di dalam slide pertama.
- Periksa apakah shape bertipe SmartArt dan lakukan Typecast pada shape yang dipilih menjadi SmartArtEx jika memang SmartArt.
- Jelajahi semua node di dalam SmartArt shape dan periksa apakah mereka adalah Assistant Node.
- Ubah status Assistant Node menjadi node normal.
- Simpan Presentasi.

```c#
// Membuat instance presentasi
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Menelusuri setiap shape di dalam slide pertama
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Memeriksa apakah shape bertipe SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Lakukan typecast shape menjadi SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Menelusuri semua node dari shape SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Memeriksa apakah node merupakan node Asisten
                if (node.IsAssistant)
                {
                    // Mengatur node Asisten menjadi false dan menjadikannya node normal
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Simpan Presentasi
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Menetapkan Fill Format pada Node**
Aspose.Slides untuk .NET memungkinkan penambahan bentuk SmartArt kustom dan menetapkan format pengisian mereka. Artikel ini menjelaskan cara membuat dan mengakses bentuk SmartArt serta menetapkan format pengisian menggunakan Aspose.Slides untuk .NET.

Silakan ikuti langkah‑langkah berikut:

- Buat sebuah instance dari kelas `Presentation`.
- Dapatkan referensi slide menggunakan indeksnya.
- Tambahkan SmartArt shape dengan mengatur LayoutType-nya.
- Tetapkan FillFormat untuk node-node SmartArt shape.
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```c#
using (Presentation presentation = new Presentation())
{
    // Mengakses slide
    ISlide slide = presentation.Slides[0];

    // Menambahkan bentuk SmartArt dan node
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Menetapkan warna isi node
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Menyimpan Presentasi
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```

## **Menghasilkan Thumbnail dari Child Node SmartArt**
Pengembang dapat menghasilkan thumbnail dari Child node SmartArt dengan mengikuti langkah‑langkah berikut:

1. Buat instance kelas `Presentation` yang mewakili file PPTX.
2. Tambahkan SmartArt.
3. Dapatkan referensi node dengan menggunakan Index‑nya.
4. Dapatkan gambar thumbnail.
5. Simpan gambar thumbnail dalam format gambar apa pun yang diinginkan.

Contoh di bawah ini menghasilkan thumbnail dari child node SmartArt.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **FAQ**

**Apakah animasi SmartArt didukung?**

Ya. SmartArt diperlakukan sebagai shape biasa, sehingga Anda dapat [terapkan animasi standar](/slides/id/net/shape-animation/) (masuk, keluar, penekanan, jalur gerak) dan mengatur waktu. Anda juga dapat memberi animasi pada shape di dalam node SmartArt bila diperlukan.

**Bagaimana cara menemukan SmartArt tertentu pada slide secara dapat diandalkan jika ID internalnya tidak diketahui?**

Tetapkan dan cari dengan menggunakan [teks alternatif](https://reference.aspose.com/slides/id/net/aspose.slides/shape/alternativetext/). Menetapkan AltText yang khas pada SmartArt memungkinkan Anda menemukannya secara programatik tanpa bergantung pada pengidentifikasi internal.

**Apakah tampilan SmartArt akan tetap terjaga saat mengonversi presentasi ke PDF?**

Ya. Aspose.Slides merender SmartArt dengan fidelitas visual tinggi selama [ekspor PDF](/slides/id/net/convert-powerpoint-to-pdf/), mempertahankan tata letak, warna, dan efek.

**Bisakah saya mengekstrak gambar seluruh SmartArt (untuk pratinjau atau laporan)?**

Ya. Anda dapat merender bentuk SmartArt ke [format raster](https://reference.aspose.com/slides/id/net/aspose.slides/shape/getimage/) atau ke [SVG](https://reference.aspose.com/slides/id/net/aspose.slides/shape/writeassvg/) untuk output vektor yang dapat diskalakan, menjadikannya cocok untuk thumbnail, laporan, atau penggunaan web.