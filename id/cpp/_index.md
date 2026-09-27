---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /id/cpp/
keywords:
- dokumentasi
- pemrosesan presentasi
- konversi presentasi
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Mulai di sini: instal Aspose.Slides for C++, buat presentasi pertama, dan temukan panduan untuk tugas umum, referensi API, dan dukungan."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ adalah pustaka C++ native untuk membuat, membaca, mengedit, dan mengkonversi presentasi PowerPoint dan OpenDocument, tanpa Microsoft PowerPoint atau Office Automation.

Pustaka ini memuat dan menyimpan PPT, PPTX, PPS, POT, dan ODP, termasuk varian yang mendukung makro dan templat, serta mengekspor ke PDF, XPS, HTML, SVG, TIFF, Markdown, dan gambar.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Mulai</b></p>
<hr>
<p>MEMULAI</p>
<ul>
<li><a href="/slides/id/cpp/installation/">Instalasi</a></li>
<li><a href="/slides/id/cpp/create-presentation/">Buat presentasi pertama Anda</a></li>
<li><a href="/slides/id/cpp/getting-started/">Panduan memulai</a></li>
</ul>
<p>EVALUASI</p>
<ul>
<li><a href="/slides/id/cpp/supported-file-formats/">Format file yang didukung</a></li>
<li><a href="/slides/id/cpp/evaluate-aspose-slides/">Batasan trial</a></li>
<li><a href="/slides/id/cpp/licensing/">Lisensi</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bangun dengan Slides</b></p>
<hr>
<p>TUGAS UMUM</p>
<ul>
<li><a href="/slides/id/cpp/open-presentation/">Buka presentasi</a></li>
<li><a href="/slides/id/cpp/save-presentation/">Simpan presentasi</a></li>
<li><a href="/slides/id/cpp/convert-powerpoint-to-pdf/">Konversi ke PDF</a></li>
<li><a href="/slides/id/cpp/convert-slide/">Render slide sebagai gambar</a></li>
<li><a href="/slides/id/cpp/manage-text/">Edit teks dan bentuk</a></li>
</ul>
<p>ALUR KERJA SLIDES</p>
<ul>
<li><a href="/slides/id/cpp/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/id/cpp/powerpoint-animation/">Animasi</a></li>
<li><a href="/slides/id/cpp/manage-media-files/">Audio dan video</a></li>
<li><a href="/slides/id/cpp/presentation-design/">Desain slide</a></li>
<li><a href="/slides/id/cpp/merge-presentation/">Gabungkan presentasi</a></li>
</ul>
<p>CONTOH</p>
<ul>
<li><a href="/slides/id/cpp/examples/">Contoh per elemen slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Contoh di GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referensi &amp; Dukungan</b></p>
<hr>
<p>REFERENSI</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">Referensi API</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">Catatan rilis</a></li>
<li><a href="/slides/id/cpp/known-issues/">Masalah yang diketahui</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">Unduh</a></li>
</ul>
<p>DUKUNGAN</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum dukungan gratis</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk dukungan berbayar</a></li>
</ul>
</div>
</div>

------

## **Presentasi pertama Anda**

Di Windows, buat proyek **Console App** C++ di Visual Studio dan instal paket NuGet di Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

Di Linux, unduh paket ZIP Linux dan siapkan proyek CMake yang dijelaskan dalam [Instalasi](/slides/id/cpp/installation/#linux).

Kemudian gunakan kode ini sebagai file sumber utama program Anda. Kode ini membuat presentasi dengan satu kotak teks dan menyimpannya:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Untuk menjalankannya di Windows, pilih platform **x64** di bilah alat dan tekan **Ctrl+F5**. Di Linux, simpan sebagai *main.cpp* di folder proyek, lalu bangun dan jalankan di sana:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Program ini menyimpan *hello.pptx* dengan satu slide yang berisi kotak teks. Tanpa lisensi, file yang disimpan memiliki watermark evaluasi — lihat [Lisensi](/slides/id/cpp/licensing/). Untuk lebih banyak cara membuat dan mengisi presentasi, lihat [Buat Presentasi](/slides/id/cpp/create-presentation/).