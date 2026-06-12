---
title: Kelola Kontrol ActiveX dalam Presentasi di .NET
linktitle: ActiveX
type: docs
weight: 80
url: /id/net/activex/
keywords:
- ActiveX
- kontrol ActiveX
- kelola ActiveX
- tambahkan ActiveX
- modifikasi ActiveX
- pemutar media
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari bagaimana Aspose.Slides for .NET memanfaatkan ActiveX untuk mengotomatisasi dan meningkatkan presentasi PowerPoint, memberi pengembang kontrol yang kuat atas slide."
---
## **Pendahuluan**

Kontrol ActiveX digunakan dalam presentasi. Aspose.Slides for .NET memungkinkan Anda mengelola kontrol ActiveX, tetapi mengelolanya sedikit lebih rumit dan berbeda dari bentuk presentasi biasa. Mulai Aspose.Slides for .NET 6.9.0, komponen mendukung pengelolaan kontrol ActiveX. Saat ini, Anda dapat mengakses kontrol ActiveX yang sudah ditambahkan dalam presentasi Anda dan memodifikasi atau menghapusnya dengan menggunakan berbagai propertinya. Ingat, kontrol ActiveX bukan bentuk dan tidak termasuk dalam IShapeCollection presentasi melainkan IControlCollection terpisah. Artikel ini menunjukkan cara bekerja dengan mereka.

## **Modifikasi Kontrol ActiveX**

1. Buat instance dari kelas Presentation dan muat presentasi yang berisi kontrol ActiveX.  
2. Dapatkan referensi slide berdasarkan indeksnya.  
3. Akses kontrol ActiveX dalam slide dengan mengakses IControlCollection.  
4. Akses kontrol ActiveX TextBox1 menggunakan objek ControlEx.  
5. Ubah berbagai properti kontrol ActiveX TextBox1 termasuk teks, font, tinggi font, dan posisi frame.  
6. Akses kontrol akses kedua yang disebut CommandButton1.  
7. Ubah caption tombol, font, dan posisinya.  
8. Pindahkan posisi frame kontrol ActiveX.  
9. Tuliskan presentasi yang telah dimodifikasi ke file PPTX.

Potongan kode di bawah ini memperbarui kontrol ActiveX pada slide presentasi seperti yang ditampilkan di bawah.

```c#
// Mengakses presentasi dengan  kontrol ActiveX
Presentation presentation = new Presentation("ActiveX.pptm");

// Mengakses slide pertama dalam presentasi
ISlide slide = presentation.Slides[0];

// mengubah teks TextBox
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // mengubah gambar pengganti. PowerPoint akan mengganti gambar ini selama aktivasi ActiveX, jadi kadang boleh membiarkan gambar tidak berubah.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// mengubah caption tombol
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // mengubah pengganti
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Memindahkan frame ActiveX turun 100 poin
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Simpan presentasi dengan Kontrol ActiveX yang Diedit
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Sekarang menghapus kontrol
slide.Controls.Clear();

// Menyimpan presentasi dengan kontrol ActiveX yang dibersihkan
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```

## **Menambahkan Kontrol ActiveX Media Player**

1. Buat instance dari kelas Presentation dan muat contoh presentasi yang berisi kontrol ActiveX Media Player.  
2. Buat instance dari kelas Presentation target dan hasilkan instance presentasi kosong.  
3. Klon slide yang memiliki kontrol ActiveX Media Player dalam presentasi template ke Presentation target.  
4. Akses slide yang diklon di Presentation target.  
5. Akses kontrol ActiveX dalam slide dengan mengakses IControlCollection.  
6. Akses kontrol ActiveX Media Player dan atur jalur video dengan menggunakan propertinya.  
7. Simpan presentasi ke file PPTX.

```c#
// Instansiasi kelas Presentation yang mewakili file PPTX
Presentation presentation = new Presentation("template.pptx");

// Buat instance presentasi kosong
Presentation newPresentation = new Presentation();

// Hapus slide default
newPresentation.Slides.RemoveAt(0);

// Klon slide dengan Kontrol ActiveX Media Player
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Akses kontrol ActiveX Media Player dan setel jalur video
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Simpan presentasi
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Apakah Aspose.Slides mempertahankan kontrol ActiveX saat membaca dan menyimpan ulang jika mereka tidak dapat dijalankan di runtime .NET?**

Ya. Aspose.Slides memperlakukan mereka sebagai bagian dari presentasi dan dapat membaca/memodifikasi properti serta frame-nya; mengeksekusi kontrol itu sendiri tidak diperlukan untuk mempertahankannya.

**Bagaimana perbedaan kontrol ActiveX dengan objek OLE dalam sebuah presentasi?**

Kontrol ActiveX adalah kontrol terkelola interaktif (tombol, kotak teks, pemutar media), sementara [OLE](/slides/id/net/manage-ole/) mengacu pada objek aplikasi yang disematkan (misalnya, lembar kerja Excel). Mereka disimpan dan diproses secara berbeda serta memiliki model properti yang berbeda.

**Apakah event ActiveX dan makro VBA berfungsi jika file telah dimodifikasi oleh Aspose.Slides?**

Aspose.Slides mempertahankan markup dan metadata yang ada; namun, event dan makro hanya dijalankan di dalam PowerPoint pada Windows ketika keamanan mengizinkannya. Perpustakaan tidak mengeksekusi VBA.