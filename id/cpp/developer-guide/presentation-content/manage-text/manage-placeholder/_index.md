---
title: Kelola Placeholder Presentasi dalam C++
linktitle: Kelola Placeholder
type: docs
weight: 10
url: /id/cpp/manage-placeholder/
keywords:
- placeholder
- placeholder teks
- placeholder gambar
- placeholder diagram
- teks prompt
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kelola placeholder dengan mudah di Aspose.Slides untuk C++: ganti teks, sesuaikan prompt, dan atur transparansi gambar dalam PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengelola placeholder presentasi secara programatis. Artikel ini menjelaskan cara menemukan placeholder pada slide dan mengubah teksnya, menetapkan teks prompt khusus untuk tata letak placeholder, serta menyesuaikan transparansi gambar yang digunakan sebagai latar belakang placeholder. Artikel ini juga menyertakan FAQ singkat yang menjelaskan perbedaan antara placeholder dasar dan shape lokal, menjelaskan bagaimana perubahan placeholder dapat diterapkan melalui tata letak atau master, dan mengarahkan ke pengelolaan placeholder header dan footer.

## **Ubah Teks dalam Placeholder**
Dengan menggunakan [Aspose.Slides for C++](/slides/id/cpp/), Anda dapat menemukan dan memodifikasi placeholder pada slide dalam presentasi. Aspose.Slides memungkinkan Anda melakukan perubahan pada teks dalam placeholder.

**Prasyarat**: Anda memerlukan presentasi yang berisi placeholder. Anda dapat membuat presentasi tersebut menggunakan aplikasi Microsoft PowerPoint standar.

Berikut cara menggunakan Aspose.Slides untuk mengganti teks dalam placeholder pada presentasi tersebut:

1. Instansiasikan kelas [`Presentation`](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation/) dan berikan presentasi sebagai argumen.
2. Dapatkan referensi slide melalui indeksnya.
3. Iterasikan bentuk-bentuk (shapes) untuk menemukan placeholder.
4. Lakukan typecast pada shape placeholder menjadi [`AutoShape`](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.auto_shape/) dan ubah teks menggunakan [`TextFrame`](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.text_frame/) yang terkait dengan [`AutoShape`](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.auto_shape/).
5. Simpan presentasi yang telah dimodifikasi.

Kode C++ berikut menunjukkan cara mengubah teks dalam placeholder:

```c++
// Jalur ke direktori dokumen.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Memuat presentasi yang diinginkan.
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Mengakses slide pertama
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Mengakses placeholder pertama dan kedua di slide dan melakukan typecast menjadi AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Menyimpan presentasi ke disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Atur Teks Prompt dalam Placeholder**
Tata letak standar dan pra-bangun berisi teks prompt placeholder seperti ***Click to add a title*** atau ***Click to add a subtitle***. Dengan menggunakan Aspose.Slides, Anda dapat memasukkan teks prompt pilihan Anda ke dalam tata letak placeholder.

Kode C++ berikut menunjukkan cara mengatur teks prompt dalam placeholder:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Saat tidak ada teks di dalamnya, PowerPoint menampilkan "Click to add title".
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Melakukan hal yang sama untuk subtitle.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Atur Transparansi Gambar Placeholder**

Aspose.Slides memungkinkan Anda mengatur transparansi gambar latar belakang dalam placeholder teks. Dengan menyesuaikan transparansi gambar dalam bingkai tersebut, Anda dapat membuat teks atau gambar lebih menonjol (tergantung pada warna teks dan gambar).

Kode C++ berikut menunjukkan cara mengatur transparansi untuk latar belakang gambar (di dalam shape):

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **FAQ**

**Apa itu base placeholder, dan bagaimana beda dengan shape lokal pada slide?**

Base placeholder adalah shape asli pada tata letak atau master yang menjadi sumber warisan bagi shape slide—tipe, posisi, dan beberapa format diambil darinya. Shape lokal bersifat independen; jika tidak ada base placeholder, pewarisan tidak berlaku.

**Bagaimana cara memperbarui semua judul atau keterangan di seluruh presentasi tanpa harus iterasi setiap slide?**

Edit placeholder yang sesuai pada tata letak atau master. Slide yang berbasis pada tata letak/master tersebut secara otomatis akan mewarisi perubahan.

**Bagaimana cara mengontrol placeholder header/footer standar—tanggal & waktu, nomor slide, dan teks footer?**

Gunakan pengelola HeaderFooter pada ruang lingkup yang sesuai (slide normal, tata letak, master, catatan/handout) untuk mengaktifkan atau menonaktifkan placeholder tersebut serta mengatur isinya.