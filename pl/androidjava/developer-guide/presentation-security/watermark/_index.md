---
title: Dodawanie znaków wodnych do prezentacji na Androidzie
linktitle: Znak wodny
type: docs
weight: 40
url: /pl/androidjava/watermark/
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
- Android
- Java
- Aspose.Slides
description: "Zarządzaj znakami wodnymi tekstowymi i graficznymi w prezentacjach PowerPoint i OpenDocument na Androidzie w języku Java, aby wskazać wersję roboczą, informacje poufne i inne."
---
## **Wstęp**

**Znak wodny** w prezentacji to znak tekstowy lub graficzny umieszczany na slajdzie lub we wszystkich slajdach prezentacji. Zazwyczaj znak wodny służy do wskazania, że prezentacja jest wersją roboczą (np. znak „Draft”), zawiera informacje poufne (np. znak „Confidential”), określenia, do której firmy należy (np. znak „Company Name”), identyfikacji autora prezentacji itp. Znak wodny pomaga zapobiegać naruszeniom praw autorskich, wskazując, że prezentacja nie powinna być kopiowana. Znaki wodne są używane zarówno w formatach PowerPoint, jak i OpenOffice. W Aspose.Slides możesz dodać znak wodny do plików PowerPoint PPT, PPTX oraz OpenOffice ODP.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/android-java/) istnieje wiele sposobów tworzenia znaków wodnych w dokumentach PowerPoint lub OpenOffice oraz modyfikowania ich wyglądu i zachowania. Wspólnym elementem jest to, że aby dodać tekstowy znak wodny, należy użyć interfejsu [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/), a aby dodać graficzny znak wodny, użyć klasy [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/) lub wypełnić kształt znaku wodnego obrazem. `PictureFrame` implementuje interfejs [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/), co umożliwia korzystanie ze wszystkich elastycznych ustawień obiektu kształtu. Ponieważ `ITextFrame` nie jest kształtem i ma ograniczone możliwości konfiguracji, jest on opakowywany w obiekt [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/).

Znak wodny może być zastosowany na dwa sposoby: do pojedynczego slajdu lub do wszystkich slajdów prezentacji. Do zastosowania znaku wodnego we wszystkich slajdach używa się Slide Master — znak wodny jest dodawany do Slide Master, w pełni projektowany tam i stosowany do wszystkich slajdów, nie wpływając na możliwość modyfikacji znaku wodnego na poszczególnych slajdach.

Znak wodny jest zazwyczaj traktowany jako nieedytowalny przez innych użytkowników. Aby zapobiec edycji (a właściwie edycji rodzica znaku wodnego), Aspose.Slides udostępnia funkcję blokowania kształtów. Konkretny kształt może być zablokowany na normalnym slajdzie lub na Slide Master. Gdy kształt znaku wodnego jest zablokowany na Slide Master, jest on zablokowany na wszystkich slajdach prezentacji.

Możesz nadać znakowi wodnemu nazwę, aby w przyszłości, gdy zechcesz go usunąć, móc odnaleźć go w kolekcji kształtów slajdu po nazwie.

Znak wodny możesz zaprojektować dowolnie; jednak zazwyczaj posiada wspólne cechy, takie jak wyśrodkowanie, obrót, pozycja na przodzie itp. Poniżej pokażemy, jak je wykorzystać w przykładach.

## **Znak wodny tekstowy**

### **Dodanie tekstowego znaku wodnego do slajdu**

Aby dodać tekstowy znak wodny w PPT, PPTX lub ODP, najpierw możesz dodać kształt do slajdu, a następnie dodać do tego kształtu ramkę tekstową. Ramka tekstowa jest reprezentowana przez interfejs [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/). Ten typ nie dziedziczy po [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/), który posiada szeroki zestaw właściwości umożliwiających elastyczne pozycjonowanie znaku wodnego. Dlatego obiekt [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) jest opakowywany w obiekt [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/). Aby dodać tekst znaku wodnego do kształtu, użyj metody [addTextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) zgodnie z poniższym przykładem.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zobacz także" %}} 
- [Jak używać klasy TextFrame](/slides/pl/androidjava/text-formatting/)
{{% /alert %}}

### **Dodanie tekstowego znaku wodnego do całej prezentacji**

Jeśli chcesz dodać tekstowy znak wodny do całej prezentacji (czyli do wszystkich slajdów jednocześnie), dodaj go do [MasterSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/masterslide/). Reszta logiki jest taka sama, jak przy dodawaniu znaku wodnego do pojedynczego slajdu — utwórz obiekt [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) i następnie dodaj do niego znak wodny za pomocą metody [addTextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zobacz także" %}} 
- [Jak używać Slide Master](/slides/pl/androidjava/slide-master/)
{{% /alert %}}

### **Ustawienie przezroczystości kształtu znaku wodnego**

Domyślnie kształt prostokąta jest stylizowany kolorem wypełnienia i obramowania. Poniższe linie kodu sprawiają, że kształt staje się przezroczysty.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Ustawienie czcionki dla tekstowego znaku wodnego**

Możesz zmienić czcionkę tekstowego znaku wodnego, jak pokazano poniżej.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Ustawienie koloru tekstu znaku wodnego**

Aby ustawić kolor tekstu znaku wodnego, użyj następującego kodu:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Wyśrodkowanie tekstowego znaku wodnego**

Możliwe jest wyśrodkowanie znaku wodnego na slajdzie; w tym celu wykonaj następujące kroki:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Poniższy obraz pokazuje efekt końcowy.

![The text watermark](text_watermark.png)

## **Znak wodny graficzny**

### **Dodanie graficznego znaku wodnego do prezentacji**

Aby dodać graficzny znak wodny do slajdu prezentacji, możesz wykonać następujące czynności:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Zablokowanie znaku wodnego przed edycją**

Jeśli konieczne jest uniemożliwienie edycji znaku wodnego, użyj metody [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) na kształcie. Za pomocą tej właściwości możesz chronić kształt przed zaznaczaniem, zmianą rozmiaru, przemieszczaniem, grupowaniem z innymi elementami, blokowaniem tekstu przed edycją i wieloma innymi operacjami:

```java
// Zablokuj kształt znaku wodnego przed modyfikacją
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Przeniesienie znaku wodnego na przód**

W Aspose.Slides kolejność Z‑order kształtów można ustawić za pomocą metody [IShapeCollection.reorder](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Aby to zrobić, wywołaj tę metodę z listy slajdów prezentacji, przekazując referencję do kształtu oraz jego numer kolejności. Dzięki temu możesz przenieść kształt na przód lub wysłać go na tył slajdu. Funkcja jest szczególnie przydatna, gdy chcesz umieścić znak wodny przed zawartością prezentacji:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Ustawienie obrotu znaku wodnego**

Poniżej przykład kodu pokazujący, jak dostosować obrót znaku wodnego, aby był ustawiony ukośnie na slajdzie:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Nadanie nazwy znakowi wodnemu**

Aspose.Slides umożliwia nadanie nazwy kształtowi. Korzystając z nazwy kształtu, możesz w przyszłości uzyskać do niego dostęp w celu modyfikacji lub usunięcia. Aby ustawić nazwę kształtu znaku wodnego, przypisz ją metodzie [IAutoShape.setName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Usunięcie znaku wodnego**

Aby usunąć kształt znaku wodnego, użyj metody [IAutoShape.getName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getName--) w celu odnalezienia go w kolekcji kształtów slajdu. Następnie przekaż kształt znaku wodnego do metody [IShapeCollection.remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

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

**Czym jest znak wodny i dlaczego warto go używać?**

Znak wodny to nakładka tekstowa lub graficzna stosowana na slajdach, która pomaga chronić własność intelektualną, zwiększać rozpoznawalność marki lub zapobiegać nieautoryzowanemu użyciu prezentacji.

**Czy mogę dodać znak wodny do wszystkich slajdów w prezentacji?**

Tak, Aspose.Slides umożliwia programowe dodanie znaku wodnego do każdego slajdu w prezentacji. Możesz iterować po wszystkich slajdach i zastosować ustawienia znaku wodnego indywidualnie.

**Jak mogę dostosować przezroczystość znaku wodnego?**

Przezroczystość znaku wodnego możesz regulować, modyfikując ustawienia wypełnienia ([getFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getFillFormat--)) kształtu. Dzięki temu znak wodny będzie subtelny i nie będzie rozpraszał uwagi od treści slajdu.

**Jakie formaty obrazów są obsługiwane dla znaków wodnych?**

Aspose.Slides obsługuje różne formaty obrazów, takie jak PNG, JPEG, GIF, BMP, SVG i inne.

**Czy mogę dostosować czcionkę i styl tekstowego znaku wodnego?**

Tak, możesz wybrać dowolną czcionkę, rozmiar i styl, aby dopasować znak wodny do projektu prezentacji i zachować spójność marki.

**Jak zmienić pozycję lub orientację znaku wodnego?**

Pozycję i orientację znaku wodnego możesz programowo zmienić, modyfikując współrzędne, rozmiar oraz właściwość obrotu kształtu.