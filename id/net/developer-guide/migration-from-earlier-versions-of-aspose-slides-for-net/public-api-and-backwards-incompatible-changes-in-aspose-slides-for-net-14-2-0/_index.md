---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 14.2.0
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
## **API Publik dan Perubahan Tidak Kompatibel Mundur**
{{% alert color="primary" %}} 

Kami telah melakukan beberapa perubahan pada API Aspose.Slides untuk .NET 14.2.0. Beberapa properti dan metode telah dihapus dan beberapa dipindahkan ke ruang nama lain.

{{% /alert %}} 
### **Metode Aspose.Slides.IPresentation.Write(…) Dihapus**
Metode-metode ini hanya menulis objek Presentation ke file berformat PPTX. Pada API baru, kelas Presentation digunakan untuk bekerja dengan semua format. Dimungkinkan untuk menggunakan metode Presentation.Save(…) untuk menyimpan objek Presentation ke semua format yang didukung.
### **Kelas yang Berkaitan dengan Gaya Tema Dipindahkan ke Namespace Aspose.Slides.Theme**
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
Fitur-fitur Aspose.Slides untuk .NET 8.4 telah ditambahkan ke Aspose.Slides untuk .NET 14.2.0