---
title: Zarządzanie listami wypunktowanymi i numerowanymi w prezentacjach w Pythonie
linktitle: Zarządzanie listami
type: docs
weight: 70
url: /pl/python-net/manage-lists/
aliases:
  - /python-net/zarzadzaj-listami-wypunktowanymi-i-numerowanymi/
keywords:
  - punkt
  - lista wypunktowana
  - lista numerowana
  - symbol wypunktowania
  - punkt graficzny
  - niestandardowy punkt
  - lista wielopoziomowa
  - utwórz punkt
  - dodaj punkt
  - dodaj listę
  - PowerPoint
  - OpenDocument
  - prezentacja
  - Python
  - Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować listy wypunktowane, graficzne, wielopoziomowe i numerowane w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET."
---
## **Przegląd**

Aspose.Slides for Python via .NET umożliwia tworzenie i formatowanie list wypunktowanych oraz numerowanych w prezentacjach PowerPoint i OpenDocument. Element listy to akapit, którego ustawienia wypunktowania kontrolowane są przez format akapitu.

Użyj właściwości [Paragraph.paragraph_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/paragraph_format/) aby uzyskać dostęp do ustawień list na poziomie akapitu. Głównym punktem wejścia jest [ParagraphFormat.bullet](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/bullet/), które zwraca obiekt [BulletFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/). Dzięki temu obiektowi możesz ustawić typ wypunktowania, symbol, obraz, kolor, rozmiar, styl numeracji oraz numer początkowy.

Ten artykuł pokazuje, jak:

- utworzyć listę wypunktowaną z niestandardowym symbolem
- utworzyć punkt graficzny
- utworzyć listę wielopoziomową ustawiając głębokość akapitu
- utworzyć listę numerowaną
- zbadać i zmienić formatowanie listy w istniejącej prezentacji

## **Utwórz listę wypunktowaną**

Aby utworzyć listę wypunktowaną, dodaj obiekty [Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) i ustaw [BulletFormat.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/type/) na [BulletType.SYMBOL](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bullettype/). Następnie możesz ustawić [BulletFormat.char](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/color/) oraz [BulletFormat.height](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/height/), aby kontrolować wygląd wypunktowania.

Poniższy kod w języku Python demonstruje tworzenie listy wypunktowanej na slajdzie:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![The symbol bullets](symbol_bullets.png)

## **Utwórz listę numerowaną**

Używaj list numerowanych, gdy kolejność elementów ma znaczenie. Ustaw [BulletFormat.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/type/) na [BulletType.NUMBERED](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bullettype/). Możesz także wybrać format numeracji za pomocą [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/numbered_bullet_style/) lub ustawić [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/), gdy lista ma zaczynać się od wartości innej niż 1.

Poniższy kod w języku Python pokazuje, jak utworzyć listę numerowaną na slajdzie:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![The numbered bullets](numbered_bullets.png)

## **Utwórz punkt graficzny**

Aspose.Slides pozwala zastąpić zwykły symbol wypunktowania obrazem. Punkty graficzne działają najlepiej z prostymi obrazami, które pozostają czytelne w małym rozmiarze, takimi jak ikony lub małe pliki PNG z przezroczystością.

{{% alert color="primary" %}}
Idealnie, jeśli planujesz zastąpić standardowy symbol wypunktowania obrazem, wybierz prostą grafikę z przezroczystym tłem. Takie obrazy doskonale sprawdzają się jako niestandardowe symbole wypunktowań.
{{% /alert %}}

Aby utworzyć punkt graficzny, dodaj obraz do [Presentation.images](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/images/) i przypisz zwrócony obiekt obrazu do [BulletFormat.picture](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/picture/). Ustaw [BulletFormat.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/type/) na [BulletType.PICTURE](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bullettype/) przed przypisaniem obrazu.

Załóżmy, że mamy plik „image.png”:

![A picture for the bullets](picture_for_bullets.png)

Poniższy kod w języku Python pokazuje, jak utworzyć punkty graficzne na slajdzie:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![The picture bullets](picture_bullets.png)

## **Utwórz listę wielopoziomową**

Użyj [ParagraphFormat.depth](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/depth/), aby umieścić elementy listy na różnych poziomach. Poziom 0 to najwyższy poziom, poziom 1 jest zagnieżdżony poniżej niego, itd.

Poniższy kod w języku Python pokazuje, jak utworzyć wielopoziomową listę wypunktowaną:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![The multilevel list](multilevel_list.png)

## **Zmień istniejącą listę**

Aby zmienić formatowanie listy w istniejącej prezentacji, uzyskaj dostęp do docelowego akapitu i zaktualizuj jego ustawienia [ParagraphFormat.bullet](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/bullet/). Te same właściwości używane do tworzenia list można wykorzystać do przeglądania lub modyfikowania list załadowanych z pliku PPT, PPTX lub ODP.

Poniższy kod w języku Python zmienia pierwszy akapit w ramce tekstowej, aby używał stylu listy numerowanej:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy listy wypunktowane i numerowane mogą być eksportowane do PDF lub obrazów?**

Tak. Aspose.Slides zachowuje formatowanie list, gdy docelowy format obsługuje odpowiednie rozmieszczenie tekstu i funkcje wypunktowań.

**Czy mogę edytować listy w istniejących prezentacjach?**

Tak. Załaduj prezentację, uzyskaj dostęp do docelowego akapitu, przeglądaj lub aktualizuj jego ustawienia [ParagraphFormat.bullet](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/bullet/), a następnie zapisz prezentację.

**Czy listy mogą zawierać tekst niełaciński?**

Tak. Tekst elementu listy może zawierać znaki Unicode, więc możesz tworzyć listy w wielojęzykowych prezentacjach. Upewnij się, że użyte w prezentacji czcionki obsługują potrzebne znaki.