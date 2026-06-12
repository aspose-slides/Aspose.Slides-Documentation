---
title: Deklarasi
type: docs
weight: 60
url: /id/java/declaration/
keywords:
- deklarasi
- komponen
- izin Full Trust
- pengaturan registri
- file sistem
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Pelajari persyaratan kepercayaan, izin, dan batasan hosting Aspose.Slides untuk Java sehingga Anda dapat dengan aman menyebarkan aplikasi yang memproses PPT, PPTX, dan ODP di server."
---
{{% alert color="primary" %}} 

Semua komponen Aspose Java memerlukan set izin Full Trust. Alasannya, komponen Aspose Java perlu mengakses pengaturan registri, file sistem selain direktori virtual untuk operasi tertentu seperti mem-parsing font, dll. Selain itu, komponen Aspose Java didasarkan pada kelas sistem inti Java yang juga memerlukan set izin Full Trust dalam banyak kasus. 

{{% /alert %}} 

Internet Service Providers yang menghosting banyak aplikasi dari perusahaan berbeda biasanya menerapkan tingkat keamanan Medium Trust: 

- OleDbPermission tidak tersedia. Ini berarti Anda tidak dapat menggunakan penyedia data OLE DB yang dikelola ADO.NET untuk mengakses basis data.
- EventLogPermission tidak tersedia. Ini berarti Anda tidak dapat mengakses log peristiwa Windows.
- ReflectionPermission tidak tersedia. Ini berarti Anda tidak dapat menggunakan refleksi.
- RegistryPermission tidak tersedia. Ini berarti Anda tidak dapat mengakses registri.
- WebPermission dibatasi. Ini berarti aplikasi Anda hanya dapat berkomunikasi dengan alamat atau rentang alamat yang Anda definisikan dalam elemen <trust>.
- FileIOPermission dibatasi. Ini berarti Anda hanya dapat mengakses file dalam hierarki direktori virtual aplikasi Anda.

{{% alert color="primary" %}} 

Karena alasan yang disebutkan di atas, komponen Aspose Java tidak dapat digunakan pada server yang memberikan set izin selain Full Trust. 

{{% /alert %}}