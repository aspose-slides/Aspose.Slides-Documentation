---
title: Dodawanie znaków wodnych do prezentacji w Pythonie
linktitle: Znak wodny
type: docs
weight: 40
url: /pl/python-net/watermark/
keywords:
- znak wodny
- tekstowy znak wodny
- obrazowy znak wodny
- dodaj znak wodny
- zmień znak wodny
- usuń znak wodny
- skasuj znak wodny
- dodaj znak wodny do PPT
- dodaj znak wodny do PPTX
- dodaj znak wodny do ODP
- usuń znak wodny z PPT
- usuń znak wodny z PPTX
- usuń znak wodny z ODP
- skasuj znak wodny z PPT
- skasuj znak wodny z PPTX
- skasuj znak wodny z ODP
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak zarządzać tekstowymi i graficznymi znakami wodnymi w prezentacjach PowerPoint i OpenDocument w Pythonie, aby oznaczyć wersję roboczą, informacje poufne, prawa autorskie i inne."
---
## **Wstęp**

**Znak wodny** w prezentacji to znak tekstowy lub graficzny używany na pojedynczym slajdzie lub na wszystkich slajdach prezentacji. Zazwyczaj znak wodny służy do wskazania, że prezentacja jest wersją roboczą (np. znak wodny „Draft”), że zawiera informacje poufne (np. znak wodny „Confidential”), aby określić, do której firmy należy (np. znak wodny „Company Name”), do identyfikacji autora prezentacji itp. Znak wodny pomaga zapobiegać naruszeniom praw autorskich, wskazując, że prezentację nie należy kopiować. Znaki wodne są używane zarówno w formatach prezentacji PowerPoint, jak i OpenOffice. W Aspose.Slides można dodać znak wodny do plików PowerPoint PPT, PPTX oraz OpenOffice ODP.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/python-net/), istnieje wiele sposobów tworzenia znaków wodnych w dokumentach PowerPoint lub OpenOffice oraz modyfikowania ich wyglądu i zachowania. Wspólnym elementem jest to, że aby dodać tekstowy znak wodny, należy użyć klasy [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/), a aby dodać graficzny znak wodny, użyć klasy [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) lub wypełnić kształt znaku wodnego obrazem. `PictureFrame` implementuje klasę [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/), co pozwala korzystać ze wszystkich elastycznych ustawień obiektu kształtu. Ponieważ `TextFrame` nie jest kształtem i jego ustawienia są ograniczone, jest on opakowywany w obiekt [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) .

Istnieją dwa sposoby zastosowania znaku wodnego: na pojedynczym slajdzie lub na wszystkich slajdach prezentacji. Slide Master jest używany do zastosowania znaku wodnego na wszystkich slajdach — znak wodny jest dodawany do Slide Master, w pełni tam projektowany i stosowany do wszystkich slajdów bez wpływu na możliwość modyfikacji znaku wodnego na poszczególnych slajdach.

Znak wodny jest zazwyczaj uznawany za niedostępny do edycji przez innych użytkowników. Aby zapobiec edycji znaku wodnego (a dokładniej jego nadrzędnego kształtu), Aspose.Slides udostępnia funkcję blokowania kształtów. Konkretny kształt może być zablokowany na zwykłym slajdzie lub na Slide Master. Gdy kształt znaku wodnego jest zablokowany na Slide Master, zostaje on zablokowany na wszystkich slajdach prezentacji.

Możesz ustawić nazwę znaku wodnego, aby w przyszłości, gdy będziesz chciał go usunąć, móc odnaleźć go wśród kształtów slajdu po nazwie.

Możesz zaprojektować znak wodny w dowolny sposób; jednak zazwyczaj znaki wodne mają wspólne cechy, takie jak wyśrodkowanie, obrót, pozycja na wierzchu itp. Poniżej omówimy, jak je wykorzystać w przykładach.

## **Znak wodny tekstowy**

### **Dodaj tekstowy znak wodny do slajdu**

Aby dodać tekstowy znak wodny w PPT, PPTX lub ODP, najpierw możesz dodać kształt do slajdu, a następnie dodać do tego kształtu ramkę tekstową. Ramka tekstowa jest reprezentowana przez klasę [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/). Ten typ nie dziedziczy po [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/), który posiada szeroki zestaw właściwości do elastycznego pozycjonowania znaku wodnego. Dlatego obiekt [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) jest opakowywany w obiekt [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/). Aby dodać tekst znaku wodnego do kształtu, użyj metody [add_text_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/add_text_frame/#str) jak pokazano poniżej.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/pl/python-net/text-formatting/)
{{% /alert %}}

### **Dodaj tekstowy znak wodny do prezentacji**

Jeśli chcesz dodać tekstowy znak wodny do całej prezentacji (czyli do wszystkich slajdów jednocześnie), dodaj go do [MasterSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/). Reszta logiki jest taka sama, jak przy dodawaniu znaku wodnego do pojedynczego slajdu — utwórz obiekt [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) i następnie dodaj znak wodny przy użyciu metody [add_text_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/pl/python-net/slide-master/)
{{% /alert %}}

### **Ustaw przezroczystość kształtu znaku wodnego**

Domyślnie prostokątny kształt ma ustawione kolory wypełnienia i linii. Poniższe wiersze kodu sprawiają, że kształt staje się przezroczysty.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Ustaw czcionkę tekstowego znaku wodnego**

Możesz zmienić czcionkę tekstowego znaku wodnego, jak pokazano poniżej.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Ustaw kolor tekstu znaku wodnego**

Aby ustawić kolor tekstu znaku wodnego, użyj poniższego kodu:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Wyśrodkuj tekstowy znak wodny**

Możliwe jest wyśrodkowanie znaku wodnego na slajdzie; w tym celu możesz wykonać następujące czynności:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

![Tekstowy znak wodny](text_watermark.png)

## **Znak wodny graficzny**

### **Dodaj graficzny znak wodny do prezentacji**

Aby dodać graficzny znak wodny do slajdu prezentacji, możesz wykonać następujące kroki:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Zablokuj znak wodny przed edycją**

Jeśli konieczne jest zapobieżenie edycji znaku wodnego, użyj właściwości [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/auto_shape_lock/) na kształcie. Dzięki tej właściwości możesz chronić kształt przed zaznaczaniem, zmianą rozmiaru, przemieszczaniem, grupowaniem z innymi elementami, zablokować jego tekst przed edycją i wiele więcej:

```py
# Zablokuj kształt znaku wodnego przed modyfikacją
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Przenieś znak wodny na wierzch**

W Aspose.Slides kolejność Z kształtów można ustawić za pomocą metody [ShapeCollection.reorder](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Aby to zrobić, należy wywołać tę metodę z listy slajdów prezentacji, przekazując referencję do kształtu oraz jego numer kolejności. Dzięki temu można przenieść kształt na wierzch lub cofnąć go na tył slajdu. Funkcja ta jest szczególnie przydatna, gdy trzeba umieścić znak wodny przed zawartością prezentacji:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Ustaw obrót znaku wodnego**

Poniżej przykład kodu, który pokazuje, jak dostosować obrót znaku wodnego, aby był ustawiony ukośnie na slajdzie:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Ustaw nazwę znaku wodnego**

Aspose.Slides pozwala ustawić nazwę kształtu. Korzystając z nazwy kształtu, można w przyszłości uzyskać do niego dostęp w celu modyfikacji lub usunięcia. Aby ustawić nazwę kształtu znaku wodnego, przypisz ją do właściwości [AutoShape.name](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Usuń znak wodny**

Aby usunąć kształt znaku wodnego, użyj metody [AutoShape.name](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/name/) aby znaleźć go wśród kształtów slajdu. Następnie przekaż kształt znaku wodnego do metody [ShapeCollection.remove](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Przykład na żywo**

Możesz wypróbować darmowe narzędzia online **Aspose.Slides**: [Add Watermark](https://products.aspose.app/slides/pl/watermark) oraz [Remove Watermark](https://products.aspose.app/slides/pl/watermark/remove-watermark).

![Narzędzia online do dodawania i usuwania znaków wodnych](online_tools.png)

## **FAQ**

**Czym jest znak wodny i dlaczego powinienem go używać?**

Znak wodny to nakładka tekstowa lub graficzna nakładana na slajdy, która pomaga chronić własność intelektualną, zwiększać rozpoznawalność marki lub zapobiegać nieautoryzowanemu użyciu prezentacji.

**Czy mogę dodać znak wodny do wszystkich slajdów w prezentacji?**

Tak, Aspose.Slides umożliwia dodanie znaku wodnego do każdego slajdu w prezentacji. Można przeiterować wszystkie slajdy i zastosować ustawienia znaku wodnego indywidualnie.

**Jak mogę dostosować przezroczystość znaku wodnego?**

Możesz dostosować przezroczystość znaku wodnego, modyfikując ustawienia wypełnienia ([FillFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fillformat/)) kształtu. Dzięki temu znak wodny jest subtelny i nie odciąga uwagi od treści slajdu.

**Jakie formaty obrazów są obsługiwane dla znaków wodnych?**

Aspose.Slides obsługuje różne formaty obrazów, takie jak PNG, JPEG, GIF, BMP, SVG i inne.

**Czy mogę dostosować czcionkę i styl tekstowego znaku wodnego?**

Tak, możesz wybrać dowolną czcionkę, rozmiar i styl, aby dopasować je do projektu prezentacji i zachować spójność marki.

**Jak zmienić pozycję lub orientację znaku wodnego?**

Możesz zmienić pozycję i orientację znaku wodnego, modyfikując współrzędne, rozmiar i właściwości obrotu [shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/).