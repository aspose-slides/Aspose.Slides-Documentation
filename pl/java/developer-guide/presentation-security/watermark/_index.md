---
title: Dodawanie znaków wodnych do prezentacji w Javie
linktitle: Znak wodny
type: docs
weight: 40
url: /pl/java/watermark/
keywords:
- znak wodny
- tekstowy znak wodny
- obrazowy znak wodny
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
- Java
- Aspose.Slides
description: "Zarządzaj tekstowymi i graficznymi znakami wodnymi w prezentacjach PowerPoint i OpenDocument w Javie, aby oznaczyć wersję roboczą, informacje poufne, prawa autorskie i wiele innych."
---
## **Wprowadzenie**

**Znak wodny** w prezentacji to tekstowy lub graficzny odcisk używany na slajdzie lub we wszystkich slajdach prezentacji. Zazwyczaj znak wodny służy do wskazania, że prezentacja jest wersją roboczą (np. znak wodny „Draft”), że zawiera informacje poufne (np. znak wodny „Confidential”), aby określić, do której firmy należy (np. znak wodny „Company Name”), do identyfikacji autora prezentacji itp. Znak wodny pomaga zapobiegać naruszeniom praw autorskich, wskazując, że prezentacji nie należy kopiować. Znaki wodne są używane zarówno w formatach prezentacji PowerPoint, jak i OpenOffice. W Aspose.Slides możesz dodać znak wodny do formatów plików PowerPoint PPT, PPTX oraz OpenOffice ODP.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/java/) istnieje wiele sposobów tworzenia znaków wodnych w dokumentach PowerPoint lub OpenOffice oraz modyfikacji ich wyglądu i zachowania. Wspólnym elementem jest to, że aby dodać tekstowy znak wodny, należy używać interfejsu [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/), a aby dodać graficzny znak wodny, używać klasy [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe/) lub wypełnić kształt znaku wodnego obrazem. `PictureFrame` implementuje interfejs [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/), co pozwala korzystać ze wszystkich elastycznych ustawień obiektu kształtu. Ponieważ `ITextFrame` nie jest kształtem i jego ustawienia są ograniczone, jest on opakowywany w obiekt [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) .

Znak wodny może być zastosowany na dwa sposoby: do pojedynczego slajdu lub do wszystkich slajdów prezentacji. Slide Master jest używany do zastosowania znaku wodnego do wszystkich slajdów — znak wodny jest dodawany do Slide Master, tam w pełni projektowany i stosowany do wszystkich slajdów bez wpływu na możliwość modyfikacji znaku wodnego na poszczególnych slajdach.

Znak wodny jest zazwyczaj uważany za nieedytowalny przez innych użytkowników. Aby zapobiec edycji znaku wodnego (a dokładniej jego rodzica – kształtu), Aspose.Slides zapewnia funkcję blokowania kształtów. Konkretny kształt może być zablokowany na normalnym slajdzie lub na Slide Master. Gdy kształt znaku wodnego jest zablokowany na Slide Master, jest on zablokowany na wszystkich slajdach prezentacji.

Możesz ustawić nazwę dla znaku wodnego, aby w przyszłości, gdy będziesz chciał go usunąć, móc znaleźć go w kolekcji kształtów slajdu po nazwie.

Możesz zaprojektować znak wodny w dowolny sposób; jednak zwykle znaki wodne posiadają wspólne cechy, takie jak wyśrodkowanie, obrót, pozycja na wierzchu itp. Poniżej pokażemy, jak je wykorzystać w przykładach.

## **Znak wodny tekstowy**

### **Dodaj tekstowy znak wodny do slajdu**

Aby dodać tekstowy znak wodny w PPT, PPTX lub ODP, najpierw możesz dodać kształt do slajdu, a następnie dodać do tego kształtu ramkę tekstową. Ramka tekstowa jest reprezentowana przez interfejs [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/). Ten typ nie dziedziczy po [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/), który posiada szeroki zestaw właściwości umożliwiających elastyczne pozycjonowanie znaku wodnego. Dlatego obiekt [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) jest opakowywany w obiekt [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/). Aby dodać tekst znaku wodnego do kształtu, użyj metody [addTextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) jak pokazano poniżej.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Zobacz także" %}} 
- [Jak używać klasy TextFrame](/slides/pl/java/text-formatting/)
{{% /alert %}}

### **Dodaj tekstowy znak wodny do prezentacji**

Jeśli chcesz dodać tekstowy znak wodny do całej prezentacji (czyli do wszystkich slajdów jednocześnie), dodaj go do [MasterSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/masterslide/). Reszta logiki jest taka sama, jak przy dodawaniu znaku wodnego do pojedynczego slajdu — utwórz obiekt [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) i następnie dodaj do niego znak wodny przy użyciu metody [addTextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Zobacz także" %}} 
- [Jak używać Slide Master](/slides/pl/java/slide-master/)
{{% /alert %}}

### **Ustaw przezroczystość kształtu znaku wodnego**

Domyślnie prostokątny kształt jest stylowany kolorami wypełnienia i linii. Poniższe linie kodu powodują, że kształt staje się przezroczysty.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Ustaw czcionkę dla tekstowego znaku wodnego**

Możesz zmienić czcionkę tekstowego znaku wodnego, jak pokazano poniżej.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Ustaw kolor tekstu znaku wodnego**

Aby ustawić kolor tekstu znaku wodnego, użyj tego kodu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Wyśrodkuj tekstowy znak wodny**

Możliwe jest wyśrodkowanie znaku wodnego na slajdzie, a aby to zrobić, wykonaj następujące kroki:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

Poniższy obraz przedstawia końcowy efekt.

![Znak wodny tekstowy](text_watermark.png)

## **Znak wodny graficzny**

### **Dodaj graficzny znak wodny do prezentacji**

Aby dodać graficzny znak wodny do slajdu prezentacji, możesz wykonać następujące czynności:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Zablokuj znak wodny przed edycją**

Jeśli konieczne jest zapobieżenie edycji znaku wodnego, użyj metody [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) na kształcie. Dzięki tej właściwości możesz chronić kształt przed zaznaczeniem, zmianą rozmiaru, przemieszczeniem, grupowaniem z innymi elementami, zablokować jego tekst przed edycją i wiele więcej:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Zablokuj kształt znaku wodnego przed modyfikacją
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Przenieś znak wodny na wierzch**

W Aspose.Slides kolejność Z‑order kształtów można ustawić za pomocą metody [IShapeCollection.reorder](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Aby to zrobić, należy wywołać tę metodę z listy slajdów prezentacji, podając referencję do kształtu i jego numer kolejności. W ten sposób można przenieść kształt na wierzch lub wysłać go na spód slajdu. Funkcja ta jest szczególnie przydatna, gdy trzeba umieścić znak wodny przed zawartością prezentacji:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Ustaw obrót znaku wodnego**

Poniżej przykład kodu, który dostosowuje obrót znaku wodnego, aby był ustawiony ukośnie na slajdzie:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Ustaw nazwę dla znaku wodnego**

Aspose.Slides pozwala ustawić nazwę kształtu. Korzystając z nazwy kształtu, możesz później uzyskać do niego dostęp w celu modyfikacji lub usunięcia. Aby ustawić nazwę kształtu znaku wodnego, przypisz ją metodzie [IAutoShape.setName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Usuń znak wodny**

Aby usunąć kształt znaku wodnego, użyj metody [IAutoShape.getName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getName--) aby znaleźć go w kolekcji kształtów slajdu. Następnie przekaż kształt znaku wodnego do metody [IShapeCollection.remove](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **FAQ**

### Czym jest znak wodny i dlaczego powinienem go używać?

Znak wodny to nakładka tekstowa lub graficzna stosowana na slajdach, która pomaga chronić własność intelektualną, zwiększyć rozpoznawalność marki lub zapobiec nieautoryzowanemu wykorzystaniu prezentacji.

### Czy mogę dodać znak wodny do wszystkich slajdów w prezentacji?

Tak, Aspose.Slides umożliwia programowe dodanie znaku wodnego do każdego slajdu w prezentacji. Możesz przeiterować wszystkie slajdy i zastosować ustawienia znaku wodnego indywidualnie.

### Jak mogę dostosować przezroczystość znaku wodnego?

Możesz dostosować przezroczystość znaku wodnego, modyfikując ustawienia wypełnienia ([getFillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getFillFormat--)) kształtu. Dzięki temu znak wodny jest subtelny i nie rozprasza uwagi od treści slajdu.

### Jakie formaty obrazu są obsługiwane dla znaków wodnych?

Aspose.Slides obsługuje różne formaty obrazów, takie jak PNG, JPEG, GIF, BMP, SVG i inne.

### Czy mogę dostosować czcionkę i styl tekstowego znaku wodnego?

Tak, możesz wybrać dowolną czcionkę, rozmiar i styl, aby pasowały do projektu Twojej prezentacji i zachowały spójność marki.

### Jak zmienić pozycję lub orientację znaku wodnego?

Możesz programowo dostosować pozycję i orientację znaku wodnego, modyfikując współrzędne, rozmiar oraz właściwości obrotu kształtu.