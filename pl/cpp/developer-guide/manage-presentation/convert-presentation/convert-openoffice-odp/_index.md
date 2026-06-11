---
title: Konwertuj prezentacje OpenDocument w C++
linktitle: Konwertuj OpenDocument
type: docs
weight: 10
url: /pl/cpp/convert-openoffice-odp/
keywords:
- konwertuj ODP
- ODP do obrazu
- ODP do GIF
- ODP do HTML
- ODP do JPG
- ODP do MD
- ODP do PDF
- ODP do PNG
- ODP do PPT
- ODP do PPTX
- ODP do TIFF
- ODP do wideo
- ODP do Word
- ODP do XPS
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Aspose.Slides dla C++ umożliwia łatwą konwersję ODP do PDF, HTML i formatów obrazu. Zwiększ wydajność swoich aplikacji C++ dzięki szybkiej i precyzyjnej konwersji prezentacji."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/pl/cpp/) umożliwia konwertowanie prezentacji OpenDocument (ODP) na wiele formatów (HTML, PDF, TIFF, SWF, XPS itd.). API używane do konwersji plików ODP na inne formaty dokumentów jest takie samo, jak używane do operacji konwersji PowerPoint (PPT i PPTX).

Na przykład, jeśli potrzebujesz skonwertować prezentację ODP do PDF, możesz zrobić to w następujący sposób:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```