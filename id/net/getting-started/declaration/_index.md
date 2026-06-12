---
title: Deklarasi
type: docs
weight: 110
url: /id/net/declaration/
keywords:
- deklarasi
- komponen
- izin Full Trust
- pengaturan registri
- file sistem
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari persyaratan kepercayaan, izin, dan batasan hosting Aspose.Slides untuk .NET sehingga Anda dapat dengan aman menyebarkan aplikasi yang memproses PPT, PPTX, dan ODP di server."
---
{{% alert color="primary" %}} 

Semua komponen Aspose .NET memerlukan set izin Full Trust karena terkadang mereka harus mengakses pengaturan registri, file sistem, dan file yang disimpan di lokasi lain (selain direktori virtual) untuk operasi tertentu (misalnya parsing font). Selain itu, Komponen Aspose .NET didasarkan pada kelas sistem .NET inti, yang dalam banyak kasus memerlukan set izin Full Trust. 

{{% /alert %}} 

Penyedia Layanan Internet, yang menampung banyak aplikasi dari berbagai perusahaan, kebanyakan menerapkan tingkat keamanan Medium Trust. Pada kasus .NET 2.0, tingkat keamanan tersebut menerapkan batasan-batasan berikut: 

- OleDbPermission tidak tersedia. Ini berarti Anda tidak dapat menggunakan penyedia data OLE DB terkelola ADO.NET untuk mengakses basis data.
- EventLogPermission tidak tersedia. Ini berarti Anda tidak dapat mengakses log peristiwa Windows.
- ReflectionPermission tidak tersedia. Ini berarti Anda tidak dapat menggunakan refleksi.
- RegistryPermission tidak tersedia. Ini berarti Anda tidak dapat mengakses registri.
- WebPermission dibatasi. Ini berarti aplikasi Anda hanya dapat berkomunikasi dengan alamat atau rentang alamat yang Anda definisikan dalam elemen <trust>.
- FileIOPermission dibatasi. Ini berarti Anda hanya dapat mengakses file dalam hirarki direktori virtual aplikasi Anda.

{{% alert color="primary" %}} 

Karena alasan di atas, komponen Aspose .NET hanya dapat digunakan pada server yang memberikan set izin Full Trust. 

{{% /alert %}}