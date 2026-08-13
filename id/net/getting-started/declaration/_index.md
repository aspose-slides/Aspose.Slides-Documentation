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
{{% alert color="info" %}}
Semua komponen Aspose .NET memerlukan set izin Full Trust karena mereka kadang harus mengakses pengaturan registri, file sistem, dan file yang disimpan di lokasi lain (selain direktori virtual) untuk operasi tertentu (misalnya parsing font). Selain itu, Komponen Aspose .NET didasarkan pada kelas sistem inti .NET, yang dalam banyak kasus memerlukan set izin Full Trust.
{{% /alert %}}
Penyedia Layanan Internet, yang menyimpan banyak aplikasi dari berbagai perusahaan, biasanya menerapkan tingkat keamanan Medium Trust. Pada kasus .NET 2.0, tingkat keamanan tersebut memberlakukan batasan-batasan berikut:

- OleDbPermission tidak tersedia. Itu berarti Anda tidak dapat menggunakan penyedia data OLE DB terkelola ADO.NET untuk mengakses basis data.
- EventLogPermission tidak tersedia. Itu berarti Anda tidak dapat mengakses log peristiwa Windows.
- ReflectionPermission tidak tersedia. Itu berarti Anda tidak dapat menggunakan refleksi.
- RegistryPermission tidak tersedia. Itu berarti Anda tidak dapat mengakses registri.
- WebPermission dibatasi. Itu berarti aplikasi Anda hanya dapat berkomunikasi dengan alamat atau rentang alamat yang Anda definisikan dalam elemen <trust>.
- FileIOPermission dibatasi. Itu berarti Anda hanya dapat mengakses file dalam hierarki direktori virtual aplikasi Anda.

{{% alert color="info" %}}
Karena alasan di atas, komponen Aspose .NET hanya dapat digunakan pada server yang memberikan set izin Full Trust.
{{% /alert %}}