---
title: Dodaj znaki wodne do prezentacji w Javie
linktitle: Znak wodny
type: docs
weight: 40
url: /pl/java/watermark/
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
- Java
- Aspose.Slides
description: Zarządzaj znakami wodnymi tekstowymi i graficznymi w prezentacjach PowerPoint i OpenDocument w Javie, aby zaznaczyć wersję roboczą, informacje poufne, prawa autorskie i inne.
---
## **Wprowadzenie**

**Znak wodny** w prezentacji to znak tekstowy lub graficzny umieszczany na slajdzie lub we wszystkich slajdach prezentacji. Zazwyczaj znak wodny służy do wskazania, że prezentacja jest wersją roboczą (np. znak wodny „Draft”), zawiera informacje poufne (np. znak wodny „Confidential”), określenia, do której firmy należy (np. znak wodny „Nazwa firmy”), identyfikacji autora prezentacji itp. Znak wodny pomaga zapobiegać naruszeniom praw autorskich, wskazując, że prezentację nie należy kopiować. Znaki wodne są używane zarówno w formatach prezentacji PowerPoint, jak i OpenOffice. W Aspose.Slides można dodać znak wodny do plików PowerPoint PPT, PPTX oraz OpenOffice ODP.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/java/) istnieje wiele sposobów tworzenia znaków wodnych w dokumentach PowerPoint lub OpenOffice oraz modyfikowania ich wyglądu i zachowania. Wspólnym elementem jest to, że aby dodać znak wodny tekstowy, należy użyć interfejsu [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/), a aby dodać znak wodny graficzny – klasy [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe/) lub wypełnić kształt znaku wodnego obrazem. `PictureFrame` implementuje interfejs [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/), co umożliwia korzystanie ze wszystkich elastycznych ustawień obiektu kształtu. Ponieważ `ITextFrame` nie jest kształtem i ma ograniczone ustawienia, zostaje opakowany w obiekt [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/).

Istnieją dwa sposoby zastosowania znaku wodnego: na pojedynczym slajdzie lub na wszystkich slajdach prezentacji. Master slajdu (Slide Master) jest używany do zastosowania znaku wodnego na wszystkich slajdach – znak wodny jest dodawany do Slide Master, tam w pełni projektowany i stosowany do wszystkich slajdów bez wpływu na możliwość edycji znaku wodnego na poszczególnych slajdach.

Znak wodny jest zazwyczaj uznawany za nieedytowalny przez innych użytkowników. Aby uniemożliwić edycję znaku wodnego (a dokładniej jego nadrzędnego kształtu), Aspose.Slides udostępnia funkcję blokowania kształtów. Konkretny kształt może być zablokowany na normalnym slajdzie lub na Slide Master. Gdy kształt znaku wodnego jest zablokowany na Slide Master, jest on zablokowany na wszystkich slajdach prezentacji.

Można ustawić nazwę znaku wodnego, aby w przyszłości, gdy będzie trzeba go usunąć, odnaleźć go wśród kształtów slajdu po nazwie.

Znak wodny można zaprojektować w dowolny sposób; jednak zazwyczaj posiada wspólne cechy, takie jak wyśrodkowanie, rotacja, pozycja na wierzchu itp. Poniżej omówimy, jak je wykorzystać w przykładach.

## **Znak wodny tekstowy**

### **Dodanie znaku wodnego tekstowego do slajdu**

Aby dodać znak wodny tekstowy w formatach PPT, PPTX lub ODP, najpierw można dodać kształt do slajdu, a następnie dodać do tego kształtu ramkę tekstową. Ramka tekstowa jest reprezentowana przez interfejs [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/). Ten typ nie dziedziczy po [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/), który posiada szeroki zestaw właściwości umożliwiających elastyczne pozycjonowanie znaku wodnego. Dlatego obiekt [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) jest opakowywany w obiekt [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/). Aby dodać tekst znaku wodnego do kształtu, użyj metody [addTextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) jak pokazano poniżej.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zobacz także" %}} 
- [Jak używać klasy TextFrame](/slides/pl/java/text-formatting/)
{{% /alert %}}

### **Dodanie znaku wodnego tekstowego do całej prezentacji**

Jeśli chcesz dodać znak wodny tekstowy do całej prezentacji (czyli do wszystkich slajdów jednocześnie), dodaj go do [MasterSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/masterslide/). Reszta logiki jest taka sama jak przy dodawaniu znaku wodnego do pojedynczego slajdu – utwórz obiekt [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) i następnie dodaj znak wodny używając metody [addTextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zobacz także" %}} 
- [Jak używać Slide Master](/slides/pl/java/slide-master/)
{{% /alert %}}

### **Ustawienie przezroczystości kształtu znaku wodnego**

Domyślnie prostokątny kształt ma ustawione kolory wypełnienia i linii. Poniższe wiersze kodu sprawiają, że kształt staje się przezroczysty.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Ustawienie czcionki znaku wodnego tekstowego**

Możesz zmienić czcionkę znaku wodnego tekstowego, jak pokazano poniżej.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Ustawienie koloru tekstu znaku wodnego**

Aby ustawić kolor tekstu znaku wodnego, użyj tego kodu:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Wyśrodkowanie znaku wodnego tekstowego**

Możliwe jest wyśrodkowanie znaku wodnego na slajdzie, a aby to zrobić, wykonaj następujące czynności:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Poniższy obraz przedstawia ostateczny wynik.

![Znak wodny tekstowy](text_watermark.png)

## **Znak wodny graficzny**

### **Dodanie graficznego znaku wodnego do prezentacji**

Aby dodać graficzny znak wodny do slajdu prezentacji, możesz wykonać następujące kroki:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Zablokowanie znaku wodnego przed edycją**

Jeśli konieczne jest uniemożliwienie edycji znaku wodnego, użyj metody [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) na kształcie. Dzięki tej właściwości możesz chronić kształt przed zaznaczeniem, zmianą rozmiaru, przeniesieniem, grupowaniem z innymi elementami, zablokować jego tekst przed edycją i wiele więcej:

```java
// Zablokuj kształt znaku wodnego przed modyfikacją
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Przeniesienie znaku wodnego na wierzch**

W Aspose.Slides kolejność Z‑kształtów można ustawiać za pomocą metody [IShapeCollection.reorder](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Aby to zrobić, wywołaj tę metodę z listy slajdów prezentacji, podając referencję do kształtu i jego numer kolejności. W ten sposób można przenieść kształt na wierzch lub wysłać go na spód slajdu. Funkcja ta jest szczególnie przydatna, gdy trzeba umieścić znak wodny przed treścią prezentacji:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Ustawienie rotacji znaku wodnego**

Poniżej znajduje się przykład kodu, jak dostosować rotację znaku wodnego, aby był położony ukośnie na slajdzie:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Ustawienie nazwy znaku wodnego**

Aspose.Slides pozwala ustawić nazwę kształtu. Korzystając z nazwy kształtu, można w przyszłości uzyskać do niego dostęp w celu modyfikacji lub usunięcia. Aby ustawić nazwę kształtu znaku wodnego, przypisz ją metodzie [IAutoShape.setName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Usunięcie znaku wodnego**

Aby usunąć kształt znaku wodnego, użyj metody [IAutoShape.getName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getName--) w celu odnalezienia go wśród kształtów slajdu. Następnie przekaż kształt znaku wodnego do metody [IShapeCollection.remove](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **FAQ**

**Czym jest znak wodny i dlaczego powinienem go używać?**

Znak wodny to nakładka tekstowa lub graficzna stosowana na slajdach, która pomaga chronić własność intelektualną, zwiększyć rozpoznawalność marki lub zapobiec nieautoryzowanemu użyciu prezentacji.

**Czy mogę dodać znak wodny do wszystkich slajdów w prezentacji?**

Tak, Aspose.Slides umożliwia programowe dodanie znaku wodnego do każdego slajdu w prezentacji. Możesz iterować po wszystkich slajdach i stosować ustawienia znaku wodnego indywidualnie.

**Jak mogę dostosować przezroczystość znaku wodnego?**

Przezroczystość znaku wodnego można regulować, modyfikując ustawienia wypełnienia ([getFillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getFillFormat--)) kształtu. Dzięki temu znak wodny jest subtelnym elementem i nie odciąga uwagi od treści slajdu.

**Jakie formaty obrazów są obsługiwane jako znaki wodne?**

Aspose.Slides obsługuje różne formaty obrazów, takie jak PNG, JPEG, GIF, BMP, SVG i inne.

**Czy mogę dostosować czcionkę i styl tekstowego znaku wodnego?**

Tak, możesz wybrać dowolną czcionkę, rozmiar i styl, aby pasowały do projektu Twojej prezentacji i zachowały spójność marki.

**Jak zmienić pozycję lub orientację znaku wodnego?**

Pozycję i orientację znaku wodnego można programowo dostosować, modyfikując współrzędne, rozmiar oraz właściwość rotacji kształtu.