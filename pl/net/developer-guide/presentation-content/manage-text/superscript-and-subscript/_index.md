---
title: Zarządzaj indeksem górnym i dolnym w prezentacjach w .NET
linktitle: Indeks górny i dolny
type: docs
weight: 80
url: /pl/net/superscript-and-subscript/
keywords:
- indeks górny
- indeks dolny
- dodaj indeks górny
- dodaj indeks dolny
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Opanuj indeks górny i dolny w Aspose.Slides dla .NET i podnieś swoje prezentacje dzięki profesjonalnemu formatowaniu tekstu dla maksymalnego efektu."
---
## **Przegląd**

Aspose.Slides dla .NET oferuje funkcje umożliwiające wstawianie tekstu w indeksie górnym i dolnym do prezentacji PowerPoint (PPT, PPTX) oraz OpenDocument (ODP). Niezależnie od tego, czy potrzebujesz podkreślić wzory chemiczne, równania matematyczne, czy opatrzyć treść przypisami, te specjalistyczne opcje formatowania pomagają utrzymać przejrzystość i precyzję. W tym artykule dowiesz się, jak płynnie stosować style indeksu górnego i dolnego oraz zapewnić profesjonalny efekt na każdym slajdzie.

## **Dodawanie tekstu w indeksie górnym i dolnym**

Możesz dodać tekst w indeksie górnym i dolnym wewnątrz dowolnego akapitu w prezentacji. Aby osiągnąć to w Aspose.Slides, musisz użyć właściwości `Escapement` klasy [PortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/portionformat/).

Właściwość ta pozwala ustawić tekst w indeksie górnym lub dolnym, przy wartościach od -100 % (indeks dolny) do 100 % (indeks górny).

Kroki implementacji:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) typu `Rectangle` do slajdu.
1. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) powiązanego z [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/).
1. Wyczyść istniejące akapity.
1. Utwórz nowy [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraph/) dla tekstu w indeksie górnym i dodaj go do kolekcji akapitów [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/).
1. Utwórz nowy obiekt fragmentu tekstu.
1. Ustaw właściwość `Escapement` dla fragmentu tekstu w zakresie od 0 do 100, aby zastosować indeks górny (0 oznacza brak indeksu górnego).
1. Ustaw tekst dla [Portion](https://reference.aspose.com/slides/pl/net/aspose.slides/portion/) i dodaj go do kolekcji fragmentów akapitu.
1. Utwórz kolejny [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraph/) dla tekstu w indeksie dolnym i dodaj go do kolekcji akapitów.
1. Utwórz nowy obiekt fragmentu tekstu.
1. Ustaw właściwość `Escapement` dla fragmentu tekstu w zakresie od 0 do -100, aby zastosować indeks dolny (0 oznacza brak indeksu dolnego).
1. Ustaw tekst dla [Portion](https://reference.aspose.com/slides/pl/net/aspose.slides/portion/) i dodaj go do kolekcji fragmentów akapitu.
1. Zapisz prezentację jako plik PPTX.

Poniższy kod C# implementuje te kroki:

```c#
using (Presentation presentation = new Presentation())
{
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.Slides[0];

    // Utwórz pole tekstowe.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Utwórz akapit dla tekstu w indeksie górnym.
    IParagraph superPar = new Paragraph();

    // Utwórz fragment tekstu ze zwykłym tekstem.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Utwórz fragment tekstu w indeksie górnym.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Utwórz akapit dla tekstu w indeksie dolnym.
    IParagraph paragraph2 = new Paragraph();

    // Utwórz fragment tekstu ze zwykłym tekstem.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Utwórz fragment tekstu w indeksie dolnym.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Dodaj akapity do pola tekstowego.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Wynik:

![Indeks górny i dolny](superscript_and_subscript.png)

## **FAQ**

**Czy indeks górny i dolny zostaje zachowany przy eksportowaniu do PDF lub innych formatów?**

Tak, Aspose.Slides dla .NET prawidłowo zachowuje formatowanie indeksu górnego i dolnego podczas eksportowania prezentacji do PDF, PPT/PPTX, obrazów oraz innych obsługiwanych formatów. Specjalistyczne formatowanie pozostaje nienaruszone we wszystkich plikach wyjściowych.

**Czy indeks górny i dolny można łączyć z innymi stylami formatowania, takimi jak pogrubienie lub kursywa?**

Tak, Aspose.Slides pozwala mieszać różne style tekstu w obrębie jednego fragmentu tekstu. Możesz włączyć pogrubienie, kursywę, podkreślenie oraz jednocześnie zastosować indeks górny lub dolny, konfigurując odpowiednie właściwości w [PortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/portionformat/).

**Czy formatowanie indeksu górnego i dolnego działa dla tekstu wewnątrz tabel, wykresów lub SmartArt?**

Tak, Aspose.Slides dla .NET obsługuje formatowanie w większości obiektów, w tym w tabelach i elementach wykresów. Pracując ze SmartArt, należy uzyskać dostęp do odpowiednich elementów (takich jak [SmartArtNode](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/smartartnode/)) oraz ich kontenerów tekstowych, a następnie skonfigurować właściwości [PortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/portionformat/) w podobny sposób.