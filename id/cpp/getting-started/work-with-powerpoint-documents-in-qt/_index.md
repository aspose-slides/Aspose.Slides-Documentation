---
title: Bekerja dengan Dokumen PowerPoint di Qt
type: docs
weight: 60
url: /id/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt creator
- Aplikasi Qt
- lintas platform
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Gunakan Aspose.Slides untuk C++ dengan Qt Creator dan Visual Studio untuk membuat, memuat, dan mengedit presentasi PowerPoint serta OpenDocument dalam aplikasi lintas platform."
---
## **Pendahuluan**

Qt adalah kerangka kerja pengembangan aplikasi lintas platform berbasis C++ yang banyak digunakan untuk mengembangkan berbagai aplikasi desktop, seluler, dan sistem tertanam. Aspose.Slides untuk C++ dapat diintegrasikan dengan Qt untuk membuat dan memanipulasi dokumen PowerPoint dalam aplikasi Qt Anda.

## **Menggunakan Aspose.Slides untuk C++ dalam Qt Creator**

Untuk menggunakan Aspose.Slides untuk C++ dalam aplikasi Qt Anda, unduh versi terbaru API dari bagian [downloads](https://downloads.aspose.com/slides/id/cpp). Setelah API diunduh, Anda dapat mengintegrasikan pustaka C++ ke dalam Qt Creator atau Visual Studio.

Untuk mengintegrasikan dan menggunakan pustaka Aspose.Slides untuk C++ dalam Aplikasi Konsol Qt yang dikembangkan di Qt Creator, ikuti langkah‑langkah berikut:

- Buka Qt Creator dan buat *Qt Console Application* baru.

![qt_console_application](qt-console-application.png)

- Pilih opsi QMake dari daftar dropdown *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Pilih kit yang sesuai dan selesaikan wizard.
- Salin folder aspose-slides-cpp-21.02 dari paket yang diekstrak Aspose.Slides untuk C++ ke root proyek.

![lib_files](aspose.slides-lib-files.png)

- Untuk menambahkan jalur ke folder lib dan include, klik kanan pada proyek di panel kiri dan pilih *Add Library*.

![qt_add_library](qt_add_library.png)

- Pilih opsi External Library dan telusuri jalur ke folder lib satu per satu.

![todo:image_alt_text](qt-add-external-library.png)

- Setelah selesai, file .pro proyek Anda akan berisi entri berikut:

![qt_pro_file.png](qt-pro-file.png)

- Bangun aplikasi dan integrasi selesai.  

{{% alert color="primary" %}}

Catatan: Lihat [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) untuk informasi lebih lanjut.

{{% /alert %}}

## **Menggunakan Aspose.Slides untuk C++ dalam Aplikasi Qt di Visual Studio**

Untuk mengembangkan aplikasi Qt menggunakan Visual Studio, Anda perlu menginstal [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Setelah instalasi selesai, unduh versi terbaru API dari bagian [downloads](https://downloads.aspose.com/slides/id/cpp) dan ikuti langkah‑langkah berikut:

- Buka Microsoft Visual Studio dan buat *Qt Console Application* baru.

![VS_Console_Application.png](vs-console-application.png)

- Pilih kit yang sesuai dan selesaikan wizard.
- Untuk mengintegrasikan dan menggunakan pustaka Aspose.Slides untuk C++, klik kanan pada proyek dan pilih *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Temukan dan instal paket *Aspose.Slides.Cpp* yang diperlukan.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Bangun proyek dan integrasi selesai.  

{{% alert color="primary" %}}

Catatan: Lihat [full demo project](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) untuk informasi lebih lanjut.

{{% /alert %}}