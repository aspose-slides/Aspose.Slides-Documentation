---
title: Zarządzanie listami wypunktowanymi i numerowanymi w prezentacjach w Pythonie
linktitle: Zarządzaj listami
type: docs
weight: 70
url: /pl/python-net/manage-lists/
keywords:
- punktor
- lista wypunktowana
- lista numerowana
- symbol punktora
- grafika punktora
- niestandardowy punktor
- lista wielopoziomowa
- utwórz punktor
- dodaj punktor
- dodaj listę
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować listy wypunktowane, graficzne, wielopoziomowe i numerowane w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET."
---
## **Przegląd**

Aspose.Slides for Python via .NET umożliwia tworzenie i formatowanie list wypunktowanych oraz numerowanych w prezentacjach PowerPoint i OpenDocument. Element listy jest akapitem, którego ustawienia punktora są kontrolowane przez formatowanie akapitu.

Użyj właściwości [Paragraph.paragraph_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/paragraph_format/) aby uzyskać dostęp do ustawień list na poziomie akapitu. Głównym punktem wejścia jest [ParagraphFormat.bullet](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/bullet/), które zwraca obiekt [BulletFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/). Dzięki temu obiektowi możesz ustawić typ punktora, symbol, obraz, kolor, rozmiar, styl numeracji oraz numer początkowy.

Ten artykuł pokazuje, jak:

- utworzyć listę wypunktowaną z niestandardowym symbolem
- utworzyć punktor graficzny
- utworzyć listę wielopoziomową, ustawiając głębokość akapitu
- utworzyć listę numerowaną
- przejrzeć i zmienić formatowanie listy w istniejącej prezentacji

## **Utworzenie listy wypunktowanej**

Aby utworzyć listę wypunktowaną, dodaj obiekty [Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) i ustaw [BulletFormat.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/type/) na [BulletType.SYMBOL](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bullettype/). Następnie możesz ustawić [BulletFormat.char](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/color/) oraz [BulletFormat.height](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/height/), aby kontrolować wygląd punktora.

Poniższy kod Python demonstruje, jak utworzyć listę wypunktowaną na slajdzie:

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

![Symbole punktorów](symbol_bullets.png)

## **Utworzenie listy numerowanej**

Używaj list numerowanych, gdy istotna jest kolejność elementów. Ustaw [BulletFormat.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/type/) na [BulletType.NUMBERED](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bullettype/). Możesz także wybrać format numeracji za pomocą [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/numbered_bullet_style/) lub ustawić [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/), gdy lista ma zaczynać się od wartości innej niż 1.

Poniższy kod Python pokazuje, jak utworzyć listę numerowaną na slajdzie:

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

![Punktory numerowane](numbered_bullets.png)

## **Utworzenie punktora graficznego**

Aspose.Slides umożliwia zastąpienie zwykłego symbolu punktora obrazem. Punktory graficzne działają najlepiej z prostymi obrazami, które pozostają czytelne przy małym rozmiarze, takimi jak ikony lub małe przezroczyste pliki PNG.

{{% alert color="primary" %}}
Idealnie, jeśli planujesz zastąpić zwykły symbol punktora obrazem, najlepiej wybrać prostą grafikę z przezroczystym tłem. Takie obrazy dobrze sprawdzają się jako niestandardowe symbole punktorów.

Doradzamy, że obraz zostanie skalowany do bardzo małego rozmiaru. Z tego powodu zdecydowanie zalecamy wybranie obrazu, który pozostaje wyraźny i wizualnie skuteczny jako punktor w liście.
{{% /alert %}}

Aby utworzyć punktor graficzny, dodaj obraz do [Presentation.images](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/images/) i przypisz zwrócony obiekt obrazu do [BulletFormat.picture](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/picture/). Ustaw [BulletFormat.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bulletformat/type/) na [BulletType.PICTURE](https://reference.aspose.com/slides/pl/python-net/aspose.slides/bullettype/) przed przypisaniem obrazu.

Załóżmy, że mamy plik "image.png":

![Obraz dla punktorów](picture_for_bullets.png)

Poniższy kod Python pokazuje, jak utworzyć punktory graficzne na slajdzie:

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

![Punktory graficzne](picture_bullets.png)

## **Utworzenie listy wielopoziomowej**

Użyj [ParagraphFormat.depth](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/depth/), aby umieścić elementy listy na różnych poziomach. Poziom 0 to najwyższy poziom, poziom 1 jest zagnieżdżony pod nim, i tak dalej.

Poniższy kod Python pokazuje, jak utworzyć wielopoziomową listę wypunktowaną:

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

![Wielopoziomowa lista](multilevel_list.png)

## **Zmiana istniejącej listy**

Aby zmienić formatowanie listy w istniejącej prezentacji, uzyskaj dostęp do docelowego akapitu i zaktualizuj jego ustawienia [ParagraphFormat.bullet](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/bullet/). Te same właściwości użyte do tworzenia list mogą być wykorzystane do przeglądania lub modyfikowania list wczytanych z pliku PPT, PPTX lub ODP.

Poniższy kod Python zmienia pierwszy akapit w ramce tekstowej, aby używał stylu listy numerowanej:

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

Tak. Aspose.Slides zachowuje formatowanie list, gdy format docelowy obsługuje odpowiednie rozmieszczenie tekstu i funkcje punktorów.

**Czy mogę edytować listy w istniejących prezentacjach?**

Tak. Wczytaj prezentację, uzyskaj dostęp do docelowego akapitu, przeglądaj lub zaktualizuj jego ustawienia [ParagraphFormat.bullet](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/bullet/), i zapisz prezentację.

**Czy listy mogą zawierać tekst niełaciński?**

Tak. Tekst elementu listy może zawierać znaki Unicode, dzięki czemu możesz tworzyć listy w wielojęzycznych prezentacjach. Upewnij się, że użyte w prezentacji czcionki obsługują potrzebne znaki.