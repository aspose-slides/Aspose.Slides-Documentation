---
title: Konwertuj prezentacje PowerPoint do PDF z notatkami w C++
linktitle: PowerPoint do PDF z notatkami
type: docs
weight: 50
url: /pl/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PDF
- prezentacja do PDF
- slajd do PDF
- PPT do PDF
- PPTX do PDF
- zapisz prezentację jako PDF
- zapisz PPT jako PDF
- zapisz PPTX jako PDF
- eksportuj PPT do PDF
- eksportuj PPTX do PDF
- notatki prelegenta
- PDF z notatkami
- C++
- Aspose.Slides
description: "Konwertuj formaty PPT i PPTX do PDF z notatkami przy użyciu Aspose.Slides dla C++. Zachowaj układy i notatki prelegenta w profesjonalnych prezentacjach."
---
## **Przegląd**

W tym artykule dowiesz się, jak konwertować prezentacje PowerPoint do formatu PDF z notatkami prelegenta przy użyciu Aspose.Slides. Ten przewodnik przedstawi niezbędne kroki i zapewni przykłady kodu, które pomogą Ci efektywnie wykonać to zadanie. Po zakończeniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, aby przekształcić slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.
- Dostosować wyjściowy plik PDF, aby zapewnić, że notatki prelegenta są uwzględnione i sformatowane zgodnie z Twoimi wymaganiami.

## **Konwertuj PowerPoint do PDF z notatkami**

Metoda `Save` w klasie [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) może być użyta do konwersji prezentacji PPT lub PPTX do PDF z notatkami prelegenta. Z Aspose.Slides po prostu ładujesz prezentację, konfigurować opcje układu przy użyciu klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notescommentslayoutingoptions/) aby uwzględnić notatki prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu pokazuje, jak skonwertować przykładową prezentację do PDF w widoku Notatki slajdu.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Skonfiguruj opcje PDF do renderowania notatek prelegenta.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Renderuj notatki prelegenta pod slajdem.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Zapisz prezentację jako PDF z notatkami prelegenta.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 
Możesz chcieć sprawdzić Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pl/conversion). 
{{% /alert %}}