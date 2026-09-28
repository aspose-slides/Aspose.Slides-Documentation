---
title: Aspose.Slides untuk Xamarin (Sejarah)
linktitle: Xamarin (Sejarah)
type: docs
weight: 200
url: /id/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- pengembangan seluler
- Android
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Sejarah: bagaimana versi Aspose.Slides untuk .NET 20.2 hingga 22.10 mendukung Xamarin.Android melalui perpustakaan terpisah. Versi saat ini tidak menyertakannya."
---
{{% alert color="info" title="Catatan" %}}

Ini adalah halaman sejarah. Versi 20.2 hingga 22.10 dari paket Aspose.Slides.NET menyertakan perpustakaan terpisah Xamarin.Android, *Aspose.Slides.Droid.dll*, yang digunakan oleh kode pada halaman ini. Versi yang lebih baru tidak menyertakannya: paket saat ini hanya berisi build untuk .NET Framework 4.6.2, .NET 6, dan .NET Standard 2.0. Microsoft menghentikan dukungan untuk semua SDK Xamarin pada 1 Mei 2024; lihat [kebijakan dukungan Xamarin](https://dotnet.microsoft.com/en-us/platform/support/policy/xamarin).

{{% /alert %}}

## **Pendahuluan**

Xamarin adalah kerangka kerja yang digunakan untuk pengembangan seluler dalam .NET C#. Xamarin memiliki alat dan perpustakaan yang memperluas kemampuan platform .NET. Ini memungkinkan pengembang membangun aplikasi untuk sistem operasi **Android**.

{{% alert color="info" title="Catatan" %}}

Untuk pengembangan di Xamarin, programmer dapat menggunakan lingkungan pengembangan mereka yang biasa (C#, Visual Studio, dan perpustakaan pihak ketiga).

{{% /alert %}}

API Aspose.Slides bekerja pada platform Xamarin. Untuk mencapainya, paket Aspose.Slides.NET, pada versi 20.2 hingga 22.10, menambahkan DLL terpisah untuk Xamarin. Aspose.Slides untuk Xamarin mendukung sebagian besar fitur yang tersedia di versi .NET:

- mengonversi dan melihat presentasi.
- mengedit konten dalam presentasi: teks, bentuk, diagram, SmartArt, audio/video, font, dll.
- menangani/berurusan dengan animasi, efek 2D, WordArt, dll.
- menangani metadata dan properti dokumen.
- menggandakan, menggabungkan, membandingkan, memecah, dll.

Kami menyediakan perbandingan seluruh fitur di bagian lain yang terletak di dekat bagian bawah halaman ini.

Dalam API Aspose.Slides untuk Xamarin, kelas, namespace, logika, dan perilaku dibuat serupa mungkin dengan versi .NET. Anda dapat memigrasikan aplikasi Aspose.Slides .NET Anda ke Xamarin dengan biaya minimal.

## **Contoh Cepat**
Anda dapat menggunakan Aspose.Slides untuk Xamarin untuk membuat dan memanfaatkan aplikasi C# Anda melalui Slides untuk Android.

Kami menyediakan contoh aplikasi Android via Xamarin yang menggunakan Aspose.Slides untuk menampilkan slide presentasi dan menambahkan bentuk baru pada slide saat disentuh. Anda dapat menemukan seluruh sumber contoh pada [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Mari kita mulai dengan membuat aplikasi Xamarin Android:

![Membuat aplikasi Xamarin Android](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Pertama, kami membuat tata letak konten yang akan berisi tampilan gambar, tombol Prev, dan tombol Next:

![Tata letak konten dengan tampilan gambar serta tombol Prev dan Next](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Buat tata letak konten**
```xml
 <LinearLayout
    xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:orientation=    "vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:showIn="@layout/activity_main">
    <LinearLayout
        android:orientation="horizontal"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:layout_weight="1"
        android:id="@+id/linearLayout1">
        <ImageView
            android:src="@android:drawable/ic_menu_gallery"
            android:layout_width="match_parent"
            android:layout_height="match_parent"
            android:id="@+id/imageView"
            android:scaleType="fitCenter" />
    </LinearLayout>

    <LinearLayout
        android:orientation="horizontal"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:layout_weight="10"
        android:id="@+id/linearLayout2">
        <Button
            android:text="Prev"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonPrev" />
        <Button
            android:text="Next"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonNext"/>
    </LinearLayout>
</LinearLayout>
```

Di sini, kami merujuk ke perpustakaan "Aspose.Slides.Droid.dll" yang mencakup presentasi contoh ("HelloWorld.pptx") ke dalam Aset aplikasi Xamarin dan menambahkan inisialisasinya ke MainActivity:

**C# - MainActivity.cs - Inisialisasi**
``` csharp
using System.Diagnostics;
using Aspose.Slides.Theme;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    private Aspose.Slides.Presentation presentation;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);
    }

    protected override void OnResume()
    {
        if (presentation == null)
        {
            using (Stream input = Assets.Open("HelloWorld.pptx"))
            {
                presentation = new Aspose.Slides.Presentation(input);
            }
        }
    }

    protected override void OnPause()
    {
        if (presentation != null)
        {
            presentation.Dispose();
            presentation = null;
        }
    }
}
```

Mari tambahkan fungsi untuk menampilkan slide Prev dan Next saat tombol diketuk:

**C# - MainActivity.cs - Tampilkan slide pada klik tombol Prev dan Next**
``` csharp
using System.Diagnostics;
using Aspose.Slides.Theme;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    private Button buttonNext;
    private Button buttonPrev;
    ImageView imageView;

    private Aspose.Slides.Presentation presentation;

    private int currentSlideNumber;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);
    }

    protected override void OnResume()
    {
        base.OnResume();
        LoadPresentation();
        currentSlideNumber = 0;
        if (buttonNext == null)
        {
            buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
        }

        if (buttonPrev == null)
        {
            buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
        }

        if(imageView == null)
        {
            imageView= FindViewById<ImageView>(Resource.Id.imageView);
        }

        buttonNext.Click += ButtonNext_Click;
        buttonPrev.Click += ButtonPrev_Click;
        RefreshButtonsStatus();
        ShowSlide(currentSlideNumber);
    }

    private void ButtonNext_Click(object sender, System.EventArgs e)
    {
        if (currentSlideNumber > (presentation.Slides.Count - 1))
        {
            return;
        }

        ShowSlide(++currentSlideNumber);
        RefreshButtonsStatus();
    }

    private void ButtonPrev_Click(object sender, System.EventArgs e)
    {
        if (currentSlideNumber == 0)
        {
            return;
        }

        ShowSlide(--currentSlideNumber);
        RefreshButtonsStatus();
    }

    protected override void OnPause()
    {
        base.OnPause();
        if (buttonNext != null)
        {
            buttonNext.Dispose();
            buttonNext = null;
        }

        if (buttonPrev != null)
        {
            buttonPrev.Dispose();
            buttonPrev = null;
        }

        if(imageView != null)
        {
            imageView.Dispose();
            imageView = null;
        }

        DisposePresentation();
    }

    private void RefreshButtonsStatus()
    {
        buttonNext.Enabled = currentSlideNumber < (presentation.Slides.Count - 1);
        buttonPrev.Enabled = currentSlideNumber > 0;
    }

    private void ShowSlide(int slideNumber)
    {
        Aspose.Slides.Drawing.Xamarin.Size size = presentation.SlideSize.Size.ToSize();
        Aspose.Slides.Drawing.Xamarin.Bitmap bitmap = presentation.Slides[slideNumber].GetThumbnail(size);
        imageView.SetImageBitmap(bitmap.ToNativeBitmap());
    }

    private void LoadPresentation()
    {
        if(presentation != null)
        {
            return;
        }

        using (Stream input = Assets.Open("HelloWorld.pptx"))
        {
            presentation = new Aspose.Slides.Presentation(input);
        }
    }

    private void DisposePresentation()
    {
        if(presentation == null)
        {
            return;
        }

        presentation.Dispose();
        presentation = null;
    }

}
```

Akhirnya, mari implementasikan fungsi untuk menambahkan bentuk elips saat menyentuh slide:

**C# - MainActivity.cs - Tambahkan elips dengan klik slide**
``` csharp
 private void ImageView_Touch(object sender, Android.Views.View.TouchEventArgs e)
{
    int[] location = new int[2];
    imageView.GetLocationOnScreen(location);
    int x = (int)e.Event.GetX();
    int y = (int)e.Event.GetY();
    int posX = x - location[0];
    int posY = y - location[0];

    Aspose.Slides.Drawing.Xamarin.Size presSize = presentation.SlideSize.Size.ToSize();

    float coeffX = (float)presSize.Width / imageView.Width;
    float coeffY = (float)presSize.Height / imageView.Height;
    int presPosX = (int)(posX * coeffX);
    int presPosY = (int)(posY * coeffY);
    int width = presSize.Width / 50;

    int height = width;
    Aspose.Slides.IAutoShape ellipse = presentation.Slides[currentSlideNumber].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, presPosX, presPosY, width, height);
    ellipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;

    Random random = new Random();
    Aspose.Slides.Drawing.Xamarin.Color slidesColor = Aspose.Slides.Drawing.Xamarin.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
    ellipse.FillFormat.SolidFillColor.Color = slidesColor;
    ShowSlide(currentSlideNumber);
}
```

Setiap klik pada slide presentasi akan menambahkan elips berwarna acak:
![Slide dengan elips yang ditambahkan dengan sentuhan](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)

## **Fitur yang Didukung**

|**FITUR**|**Aspose.Slides untuk .NET**|**Aspose.Slides untuk Xamarin**|
| :- | :- | :- |
|**Fitur presentasi**:| | |
|Membuat presentasi baru|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Format PowerPoint 97 - 2003 buka/simpan|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Format PowerPoint 2007 buka/simpan|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dukungan ekstensi PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dukungan ekstensi PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Dukungan fitur PowerPoint 2016|dibatasi|dibatasi|
|Dukungan fitur PowerPoint 2019|dibatasi|dibatasi|
|Konversi PPT ke PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Konversi PPTX ke PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX dalam PPT|dibatasi|dibatasi|
|Pemrosesan tema|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Pemrosesan makro|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Pemrosesan properti dokumen|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Perlindungan kata sandi|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Ekstraksi teks cepat|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Menyematkan font|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Rendering komentar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Menginterupsi tugas yang berjalan lama|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Format ekspor:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|dibatasi|dibatasi|
|SWF|dibatasi|dibatasi|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Format impor:**| | |
|HTML|dibatasi|dibatasi|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fitur master slide:**| | |
|Mengakses semua master slide yang ada|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Membuat/menghapus master slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mengkloning master slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fitur layout slide:**| | |
|Mengakses semua layout slide yang ada|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Membuat/menghapus layout slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mengkloning layout slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fitur slide:**| | |
|Mengakses semua slide yang ada|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Membuat/menghapus slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mengkloning slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mengekspor slide ke gambar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Membuat/mengedit/menghapus bagian slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fitur slide catatan:**| | |
|Mengakses semua slide catatan yang ada|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fitur bentuk:**| | |
|Mengakses semua bentuk slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Menambahkan bentuk baru|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mengkloning bentuk|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Mengekspor bentuk terpisah ke gambar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Jenis bentuk yang didukung:**| | |
|Semua jenis bentuk baku|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bingkai gambar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabel|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagram|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagram warisan|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Objek OLE, ActiveX|dibatasi|dibatasi|
|Bingkai video|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Bingkai audio|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Penghubung|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fitur grup bentuk:**| | |
|Mengakses grup bentuk|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Membuat grup bentuk|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Melepas grup bentuk yang ada|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fitur efek bentuk:**| | |
|Efek 2D|dibatasi|dibatasi|
|Efek 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Fitur teks:**| | |
|Pemformatan paragraf|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Pemformatan bagian|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Fitur animasi:**| | |
|Ekspor animasi ke SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Ekspor animasi ke HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|