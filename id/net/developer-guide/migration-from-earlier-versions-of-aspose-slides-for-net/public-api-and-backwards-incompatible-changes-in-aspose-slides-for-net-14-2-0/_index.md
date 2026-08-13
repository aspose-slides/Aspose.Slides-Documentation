---
title: API Publik dan Perubahan Tidak Kompatibel ke Belakang di Aspose.Slides untuk .NET 14.2.0
linktitle: Aspose.Slides untuk .NET 14.2.0
type: docs
weight: 40
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk .NET agar dapat dengan lancar memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda."
---
## **API Publik dan Perubahan Tidak Kompatibel ke Belakang**
{{% alert color="info" %}} 

Kami telah melakukan beberapa perubahan pada API Aspose.Slides untuk .NET 14.2.0. Beberapa properti dan metode telah dihapus dan beberapa dipindahkan ke namespace lain.

{{% /alert %}} 
### **Metode Aspose.Slides.IPresentation.Write(…) Dihapus**
Metode-metode ini menulis objek Presentation hanya ke file format PPTX. Pada API baru, kelas Presentation digunakan untuk bekerja dengan semua format. Dimungkinkan untuk menggunakan metode Presentation.Save(…) untuk menyimpan objek Presentation ke semua format yang didukung.
### **Kelas yang Terkait dengan Gaya Tema Dipindahkan ke Namespace Aspose.Slides.Theme**
Kelas-kelas berikut telah dipindahkan dari namespace Aspose.Slides ke namespace Aspose.Slides.Theme.

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **Perubahan dari Aspose.Slides untuk .NET 8.X.0**
Fitur Aspose.Slides untuk .NET 8.4 ditambahkan ke Aspose.Slides untuk .NET 14.2.0