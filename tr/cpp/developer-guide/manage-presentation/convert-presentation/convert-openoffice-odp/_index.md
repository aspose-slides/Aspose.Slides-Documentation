---
title: C++'ta OpenDocument Sunumlarını Dönüştürme
linktitle: OpenDocument Dönüştür
type: docs
weight: 10
url: /tr/cpp/convert-openoffice-odp/
keywords:
- ODP'yi Dönüştür
- ODP'den Görüntüye
- ODP'den GIF'e
- ODP'den HTML'e
- ODP'den JPG'e
- ODP'den MD'ye
- ODP'den PDF'e
- ODP'den PNG'e
- ODP'den PPT'ye
- ODP'den PPTX'e
- ODP'den TIFF'e
- ODP'den Videoya
- ODP'den Word'e
- ODP'den XPS'e
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++, ODP'yi PDF, HTML ve görüntü formatlarına kolayca dönüştürmenizi sağlar. C++ uygulamalarınızı hızlı ve doğru sunum dönüşümüyle güçlendirin."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/tr/cpp/) OpenDocument (ODP) sunumlarını birçok formata (HTML, PDF, TIFF, SWF, XPS, vb.) dönüştürmenizi sağlar. ODP dosyalarını diğer belge formatlarına dönüştürmek için kullanılan API, PowerPoint (PPT ve PPTX) dönüşüm işlemleri için kullanılanla aynıdır.

For example, if you need to convert an ODP presentation to PDF, you can do it as follows:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```