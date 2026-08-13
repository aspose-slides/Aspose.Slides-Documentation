---
title: Deklarasi
type: docs
weight: 60
url: /id/java/declaration/
keywords:
- deklarasi
- komponen
- izin Full Trust
- pengaturan registry
- file sistem
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Pelajari persyaratan kepercayaan Aspose.Slides untuk Java, izin, dan batasan hosting sehingga Anda dapat dengan aman menyebarkan aplikasi yang memproses PPT, PPTX, dan ODP di server."
---
{{% alert color="info" %}} 
Semua komponen Aspose Java memerlukan set izin Full Trust. Alasannya, komponen Aspose Java perlu mengakses pengaturan registry, file sistem selain direktori virtual untuk operasi tertentu seperti parsing font, dll. Selain itu, Komponen Aspose Java berbasis pada kelas sistem Java inti yang juga memerlukan set izin Full Trust dalam banyak kasus. 
{{% /alert %}} 
Penyedia Layanan Internet yang menampung banyak aplikasi dari perusahaan berbeda biasanya menerapkan tingkat keamanan Medium Trust: 
- OleDbPermission tidak tersedia. Ini berarti Anda tidak dapat menggunakan penyedia data OLE DB terkelola ADO.NET untuk mengakses basis data.
- EventLogPermission tidak tersedia. Ini berarti Anda tidak dapat mengakses log peristiwa Windows.
- ReflectionPermission tidak tersedia. Ini berarti Anda tidak dapat menggunakan refleksi.
- RegistryPermission tidak tersedia. Ini berarti Anda tidak dapat mengakses registry.
- WebPermission terbatas. Ini berarti aplikasi Anda hanya dapat berkomunikasi dengan alamat atau rentang alamat yang Anda definisikan dalam elemen <trust>.
- FileIOPermission terbatas. Ini berarti Anda hanya dapat mengakses file dalam hierarki direktori virtual aplikasi Anda.
{{% alert color="info" %}} 
Karena alasan yang disebutkan di atas, komponen Aspose Java tidak dapat digunakan pada server yang memberikan set izin selain Full Trust. 
{{% /alert %}}