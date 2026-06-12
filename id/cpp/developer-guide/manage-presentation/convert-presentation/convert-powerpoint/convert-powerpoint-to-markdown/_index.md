---
title: Konversi Presentasi PowerPoint ke Markdown dalam C++
linktitle: PowerPoint ke Markdown
type: docs
weight: 140
url: /id/cpp/convert-powerpoint-to-markdown/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke MD
- presentasi ke MD
- slide ke MD
- PPT ke MD
- PPTX ke MD
- simpan PowerPoint sebagai Markdown
- simpan presentasi sebagai Markdown
- simpan slide sebagai Markdown
- simpan PPT sebagai MD
- simpan PPTX sebagai MD
- ekspor PPT ke MD
- ekspor PPTX ke MD
- PowerPoint
- presentasi
- Markdown
- C++
- Aspose.Slides
description: "Konversi slide PowerPoint—PPT, PPTX—menjadi Markdown bersih dengan Aspose.Slides untuk C++, otomatisasi dokumentasi dan mempertahankan format."
---
## **Introduction**

Aspose.Slides memungkinkan Anda mengonversi presentasi PowerPoint ke Markdown, yang dapat berguna untuk alur kerja dokumentasi, pembuatan situs statis, migrasi konten, dan penerbitan teks yang dikontrol versi. API mendukung ekspor langsung dari presentasi PPT dan PPTX ke file MD dan menyediakan opsi tambahan untuk mengontrol cara konten slide direpresentasikan dalam dokumen Markdown yang dihasilkan.

Anda dapat mengekspor presentasi sebagai Markdown biasa, memilih dari berbagai varian Markdown seperti CommonMark dan GitHub Flavored Markdown, serta mengkonfigurasi cara gambar ditangani selama ekspor. Untuk presentasi yang berisi konten visual, Aspose.Slides juga memungkinkan Anda menyimpan gambar ke folder terpisah dan merujuknya dari file Markdown yang dihasilkan.

{{% alert color="warning" %}} 
Ekspor PowerPoint ke markdown secara default **tanpa gambar**. Jika Anda ingin mengekspor dokumen PowerPoint yang berisi gambar, Anda perlu mengatur `SaveOptions::MarkdownExportType::Visual)` dan juga menetapkan `BasePath` tempat gambar yang dirujuk dalam dokumen markdown akan disimpan.
{{% /alert %}} 

## **Convert PowerPoint to Markdown**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) untuk mewakili objek presentasi.
2. Gunakan metode [Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method) untuk menyimpan objek sebagai file markdown.

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **Convert PowerPoint to Markdown Flavor**

Aspose.Slides memungkinkan Anda mengonversi PowerPoint ke markdown (yang berisi sintaks dasar), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, dan 17 varian markdown lainnya.

Kode C++ berikut menunjukkan cara mengonversi PowerPoint ke CommonMark: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

23 varian markdown yang didukung terdaftar di [enumerasi Flavor](https://reference.aspose.com/slides/id/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) pada kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Convert a Presentation Containing Images to Markdown**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) menyediakan properti dan enumerasi yang memungkinkan Anda menggunakan opsi atau pengaturan tertentu untuk file markdown yang dihasilkan. Enum [MarkdownExportType](https://reference.aspose.com/slides/id/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/), misalnya, dapat diatur ke nilai yang menentukan bagaimana gambar dirender atau ditangani: `Sequential`, `TextOnly`, `Visual`.

### **Convert Images Sequentially**

Jika Anda menginginkan gambar muncul secara berurutan satu per satu dalam markdown yang dihasilkan, Anda harus memilih opsi sequential. Kode C++ berikut menunjukkan cara mengonversi presentasi yang berisi gambar ke markdown:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **Convert Images Visually**

Jika Anda menginginkan gambar muncul bersama-sama dalam markdown yang dihasilkan, Anda harus memilih opsi visual. Dalam kasus ini, gambar akan disimpan ke direktori kerja aplikasi (dan jalur relatif akan dibuat untuk mereka dalam dokumen markdown), atau Anda dapat menentukan jalur dan nama folder yang diinginkan.

Kode C++ berikut mendemonstrasikan operasi tersebut: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **FAQ**

**Do hyperlinks survive the export to Markdown?**

Ya. Teks [hyperlinks](/slides/id/cpp/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. [transitions](/slides/id/cpp/slide-transition/) dan [animations](/slides/id/cpp/powerpoint-animation/) slide tidak dikonversi.

**Can I speed up conversion by running it in multiple threads?**

Anda dapat memparalelkan proses per file, tetapi [don’t share](/slides/id/cpp/multithreading/) instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang sama di antara thread. Gunakan instance/proses terpisah per file untuk menghindari kontensi.

**What happens to images—where are they saved, and are the paths relative?**

[Images](/slides/id/cpp/image/) diekspor ke folder khusus, dan file Markdown merujuknya dengan jalur relatif secara default. Anda dapat mengonfigurasi jalur output dasar dan nama folder aset untuk menjaga struktur repositori yang dapat diprediksi.