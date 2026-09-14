---
title: Dodaj znaki wodne do prezentacji w Pythonie
linktitle: Znak wodny
type: docs
weight: 40
url: /pl/python-java/watermark/
keywords:
- znak wodny
- znak wodny tekstowy
- znak wodny graficzny
- dodaj znak wodny
- zmień znak wodny
- usuń znak wodny
- usuń znak wodny
- dodaj znak wodny do PPT
- dodaj znak wodny do PPTX
- dodaj znak wodny do ODP
- usuń znak wodny z PPT
- usuń znak wodny z PPTX
- usuń znak wodny z ODP
- usuń znak wodny z PPT
- usuń znak wodny z PPTX
- usuń znak wodny z ODP
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj znakami wodnymi tekstowymi i graficznymi w prezentacjach PowerPoint i OpenDocument w Pythonie, aby oznaczyć wersję roboczą, informacje poufne, prawa autorskie i inne."
---
## **Wprowadzenie**

**Znak wodny** w prezentacji to tekstowy lub graficzny stempel używany na pojedynczym slajdzie lub na wszystkich slajdach prezentacji. Zazwyczaj znak wodny służy do oznaczenia, że prezentacja jest wersją roboczą (np. znak wodny „Draft”), że zawiera informacje poufne (np. znak wodny „Confidential”), do wskazania, do której firmy należy (np. znak wodny „Nazwa firmy”), identyfikacji autora prezentacji itp. Znak wodny pomaga zapobiegać naruszeniom praw autorskich, wskazując, że prezentacja nie powinna być kopiowana. Znaki wodne są używane zarówno w formatach PowerPoint, jak i OpenOffice. W Aspose.Slides możesz dodać znak wodny do plików PowerPoint PPT, PPTX oraz OpenOffice ODP.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/python-java/) istnieje wiele sposobów tworzenia znaków wodnych w dokumentach PowerPoint lub OpenOffice oraz modyfikowania ich wyglądu i zachowania. Wspólnym elementem jest to, że aby dodać znak wodny tekstowy, należy używać klasy [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/), a aby dodać znak wodny graficzny, używać klasy [PictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/) lub wypełnić kształt znaku wodnego obrazem. [PictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/) dziedziczy po klasie [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/), co pozwala korzystać ze wszystkich elastycznych ustawień obiektu kształtu. Ponieważ [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) nie jest kształtem i jego ustawienia są ograniczone, jest on osadzany w obiekcie [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/).

Istnieją dwa sposoby zastosowania znaku wodnego: na pojedynczym slajdzie lub na wszystkich slajdach prezentacji. Slide Master służy do zastosowania znaku wodnego na wszystkich slajdach – znak wodny jest dodawany do Slide Master, w pełni tam projektowany i stosowany do wszystkich slajdów, nie wpływając na możliwość modyfikacji znaku wodnego na poszczególnych slajdach.

Znak wodny jest zazwyczaj uznawany za nieedytowalny dla innych użytkowników. Aby zapobiec edycji znaku wodnego (a dokładniej jego nadrzędnego kształtu), Aspose.Slides oferuje funkcję blokowania kształtów. Konkretny kształt można zablokować na zwykłym slajdzie lub na Slide Master. Gdy kształt znaku wodnego jest zablokowany na Slide Master, jest on zablokowany na wszystkich slajdach prezentacji.

Możesz nadać znakowi wodnemu nazwę, aby w przyszłości, gdy będziesz chciał go usunąć, móc odnaleźć go w kolekcji kształtów slajdu po nazwie.

Znak wodny można zaprojektować na dowolny sposób; jednak zwykle występują wspólne cechy znaków wodnych, takie jak wyrównanie do środka, rotacja, pozycja na wierzchu itp. Poniżej pokażemy, jak je wykorzystać w przykładach.

## **Znak wodny tekstowy**

### **Dodaj znak wodny tekstowy do slajdu**

Aby dodać znak wodny tekstowy w formacie PPT, PPTX lub ODP, najpierw możesz dodać kształt do slajdu, a następnie dodać do tego kształtu ramkę tekstową. Ramka tekstowa jest reprezentowana przez klasę [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/). Ten typ nie dziedziczy po [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/), która posiada szeroki zestaw właściwości umożliwiających elastyczne pozycjonowanie znaku wodnego. Dlatego obiekt [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) jest osadzany w obiekcie [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/). Aby dodać tekst znaku wodnego do kształtu, użyj metody [addTextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/#addTextFrame) jak pokazano poniżej.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Jak używać klasy TextFrame](/slides/pl/python-java/text-formatting/)
{{% /alert %}}

### **Dodaj znak wodny tekstowy do prezentacji**

Jeśli chcesz dodać znak wodny tekstowy do całej prezentacji (czyli do wszystkich slajdów jednocześnie), dodaj go do [MasterSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/). Reszta logiki jest taka sama, jak przy dodawaniu znaku wodnego do jednego slajdu – utwórz obiekt [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) i następnie dodaj znak wodny przy użyciu metody [addTextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/#addTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [Jak używać Slide Master](/slides/pl/python-java/slide-master/)
{{% /alert %}}

### **Ustaw przezroczystość kształtu znaku wodnego**

Domyślnie prostokątny kształt ma wypełnienie i kolor linii. Poniższe wiersze kodu powodują, że kształt staje się przezroczysty.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Ustaw czcionkę dla znaku wodnego tekstowego**

Możesz zmienić czcionkę znaku wodnego tekstowego, jak pokazano poniżej.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Ustaw kolor tekstu znaku wodnego**

Aby ustawić kolor tekstu znaku wodnego, użyj tego kodu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Wyśrodkuj znak wodny tekstowy**

Można wyśrodkować znak wodny na slajdzie, wykonując następujące kroki:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

Poniższy obraz pokazuje końcowy wynik.

![Znak wodny tekstowy](text_watermark.png)

## **Znak wodny graficzny**

### **Dodaj znak wodny graficzny do prezentacji**

Aby dodać znak wodny graficzny do slajdu prezentacji, możesz wykonać następujące czynności:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Zablokuj znak wodny przed edycją**

Jeśli konieczne jest uniemożliwienie edycji znaku wodnego, użyj metody [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/#getAutoShapeLock) na kształcie. Dzięki tej właściwości możesz chronić kształt przed zaznaczeniem, zmianą rozmiaru, przemieszczeniem, grupowaniem z innymi elementami, zablokowaniem tekstu przed edycją i wieloma innymi operacjami:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Zablokuj kształt znaku wodnego przed modyfikacją.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Przenieś znak wodny na wierzch**

W Aspose.Slides kolejność Z‑kształtów można ustawić za pomocą metody [ShapeCollection.reorder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#reorder). Aby to zrobić, wywołaj tę metodę z kolekcji kształtów slajdu, przekazując referencję do kształtu i jego numer kolejności. Dzięki temu można przenieść kształt na wierzch lub wysłać go na spód slajdu. Funkcja jest szczególnie przydatna, gdy trzeba umieścić znak wodny przed zawartością prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Ustaw rotację znaku wodnego**

Poniżej przykład kodu, który ustawia rotację znaku wodnego, aby znajdował się po przekątnej slajdu:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Ustaw nazwę dla znaku wodnego**

Aspose.Slides umożliwia ustawienie nazwy kształtu. Korzystając z nazwy kształtu, możesz w przyszłości uzyskać do niego dostęp w celu modyfikacji lub usunięcia. Aby ustawić nazwę kształtu znaku wodnego, przekaż ją do metody [Shape.setName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#setName):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Usuń znak wodny**

Aby usunąć kształt znaku wodnego, użyj metody [Shape.getName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getName), aby znaleźć go w kolekcji kształtów slajdu. Następnie przekaż kształt znaku wodnego do metody [ShapeCollection.remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#remove):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **FAQ**

**Czym jest znak wodny i dlaczego powinienem go używać?**

Znak wodny to nakładka tekstowa lub graficzna stosowana na slajdach, która pomaga chronić własność intelektualną, zwiększać rozpoznawalność marki lub zapobiegać nieautoryzowanemu użyciu prezentacji.

**Czy mogę dodać znak wodny do wszystkich slajdów w prezentacji?**

Tak, Aspose.Slides umożliwia programowe dodanie znaku wodnego do każdego slajdu w prezentacji. Możesz przeiterować wszystkie slajdy i zastosować ustawienia znaku wodnego indywidualnie.

**Jak mogę dostosować przezroczystość znaku wodnego?**

Przezroczystość znaku wodnego można regulować, modyfikując ustawienia wypełnienia ([getFillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getFillFormat)) kształtu. Dzięki temu znak wodny pozostaje subtelny i nie odciąga uwagi od treści slajdu.

**Jakie formaty obrazów są obsługiwane dla znaków wodnych?**

Aspose.Slides obsługuje różne formaty obrazów, takie jak PNG, JPEG, GIF, BMP, SVG i inne.

**Czy mogę dostosować czcionkę i styl znaku wodnego tekstowego?**

Tak, możesz wybrać dowolną czcionkę, rozmiar i styl, aby dopasować znak wodny do projektu prezentacji i zachować spójność marki.

**Jak zmienić pozycję lub orientację znaku wodnego?**

Pozycję i orientację znaku wodnego można programowo dostosować, modyfikując współrzędne, rozmiar oraz właściwość rotacji kształtu.