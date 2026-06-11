---
title: Dodawanie znaków wodnych do prezentacji w JavaScript
linktitle: Znak wodny
type: docs
weight: 40
url: /pl/nodejs-java/watermark/
keywords:
- znak wodny
- tekstowy znak wodny
- graficzny znak wodny
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj tekstowymi i graficznymi znakami wodnymi w prezentacjach PowerPoint i OpenDocument w Node.js, aby oznaczyć wersję roboczą, informacje poufne, prawa autorskie i inne."
---
## **Wstęp**

**Znak wodny** w prezentacji to tekstowy lub graficzny stempel używany na pojedynczym slajdzie lub na wszystkich slajdach prezentacji. Zazwyczaj znak wodny służy do wskazania, że prezentacja jest wersją roboczą (np. znak wodny „Draft”), zawiera informacje poufne (np. „Confidential”), określenia, do której firmy należy (np. „Company Name”), identyfikacji autora prezentacji itp. Znak wodny pomaga zapobiegać naruszeniom praw autorskich, wskazując, że prezentacja nie powinna być kopiowana. Znaki wodne są używane zarówno w formatach PowerPoint, jak i OpenOffice. W Aspose.Slides możesz dodać znak wodny do plików PowerPoint PPT, PPTX oraz OpenOffice ODP.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/nodejs-java/) istnieje wiele sposobów tworzenia znaków wodnych w dokumentach PowerPoint lub OpenOffice oraz modyfikowania ich wyglądu i zachowania. Wspólnym elementem jest to, że aby dodać znak wodny tekstowy, należy użyć typu [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/), a aby dodać znak wodny graficzny, użyć klasy [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) lub wypełnić kształt znaku wodnego obrazem. `PictureFrame` implementuje typ [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/), co pozwala korzystać ze wszystkich elastycznych ustawień obiektu kształtu. Ponieważ `TextFrame` nie jest kształtem i jego ustawienia są ograniczone, jest on opakowany w obiekt [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/).

Istnieją dwa sposoby zastosowania znaku wodnego: na pojedynczym slajdzie lub na wszystkich slajdach prezentacji. Do zastosowania znaku wodnego na wszystkich slajdach używa się Slide Master – znak wodny jest dodawany do Slide Master, w pełni tam projektowany i stosowany do wszystkich slajdów, nie wpływając na możliwość modyfikacji znaku wodnego na poszczególnych slajdach.

Znak wodny jest zazwyczaj uznawany za niedostępny do edycji przez innych użytkowników. Aby zapobiec edycji znaku wodnego (a dokładniej jego rodzica – kształtu), Aspose.Slides udostępnia funkcję blokowania kształtów. Konkretny kształt może być zablokowany na zwykłym slajdzie lub na Slide Master. Gdy kształt znaku wodnego jest zablokowany na Slide Master, jest on zablokowany na wszystkich slajdach prezentacji.

Możesz ustawić nazwę znaku wodnego, aby w przyszłości, gdy będziesz chciał go usunąć, móc znaleźć go w kolekcji kształtów slajdu po nazwie.

Możesz zaprojektować znak wodny w dowolny sposób; jednak zazwyczaj znaki wodne posiadają wspólne cechy, takie jak wyrównanie do środka, obrót, pozycja na pierwszym planie itp. Poniżej pokażemy, jak je wykorzystać w przykładach.

## **Znak wodny tekstowy**

### **Dodanie tekstowego znaku wodnego do slajdu**
Aby dodać tekstowy znak wodny w PPT, PPTX lub ODP, najpierw możesz dodać kształt do slajdu, a następnie dodać do tego kształtu ramkę tekstową. Ramka tekstowa jest reprezentowana przez typ [**TextFrame**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrame). Ten typ nie jest dziedziczony po [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape), który posiada szeroki zestaw właściwości umożliwiających elastyczne pozycjonowanie znaku wodnego. Dlatego obiekt [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrame) jest opakowywany w obiekt [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape). Aby dodać tekst znaku wodnego do kształtu, użyj metody [**addTextFrame**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) przekazując do niej tekst znaku wodnego:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zobacz także" %}} 
- Jak używać [TextFrame](/slides/pl/nodejs-java/text-formatting/).
{{% /alert %}}

### **Dodanie tekstowego znaku wodnego do całej prezentacji**

Jeśli chcesz dodać tekstowy znak wodny do całej prezentacji (czyli do wszystkich slajdów jednocześnie), dodaj go do [**MasterSlide**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MasterSlide). Reszta logiki jest taka sama, jak przy dodawaniu znaku wodnego do pojedynczego slajdu – utwórz obiekt [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape), a następnie dodaj znak wodny przy użyciu metody [**addTextFrame**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Zobacz także" %}} 
- [Jak używać ](/slides/pl/nodejs-java/slide-master/)[Slide Master](/slides/pl/nodejs-java/slide-master/)
{{% /alert %}}

### **Ustawienie przejrzystości kształtu znaku wodnego**

Domyślnie prostokątny kształt jest stylizowany kolorami wypełnienia i linii. Poniższe wiersze kodu czynią kształt przezroczystym.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **Ustawienie czcionki dla tekstowego znaku wodnego**

Możesz zmienić czcionkę tekstowego znaku wodnego, jak pokazano poniżej.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Ustawienie koloru tekstu znaku wodnego**

Aby ustawić kolor tekstu znaku wodnego, użyj poniższego kodu:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **Wyśrodkowanie tekstowego znaku wodnego**
Możliwe jest wyśrodkowanie znaku wodnego na slajdzie; w tym celu możesz wykonać następujące czynności:



```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Obraz poniżej przedstawia końcowy efekt.

![Znak wodny tekstowy](text_watermark.png)

## **Znak wodny graficzny**

### **Dodanie graficznego znaku wodnego do prezentacji**

Aby dodać graficzny znak wodny do wszystkich slajdów prezentacji, możesz wykonać następujące kroki:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **Zablokowanie znaku wodnego przed edycją**

Jeżeli konieczne jest zapobieżenie edycji znaku wodnego, użyj metody [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape#getShapeLock--) na kształcie. Dzięki tej właściwości możesz ochronić kształt przed zaznaczeniem, zmianą rozmiaru, przemieszczeniem, grupowaniem z innymi elementami, zablokowaniem tekstu przed edycją i wieloma innymi operacjami:

```javascript
// Zablokuj kształt znaku wodnego przed modyfikacją
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **Przeniesienie znaku wodnego na przedni plan**

W Aspose.Slides kolejność Z‑order kształtów można ustawić za pomocą metody [**SlideCollection.reorder**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). Aby to zrobić, wywołaj tę metodę z listy slajdów prezentacji, przekazując referencję do kształtu oraz jego numer kolejności. Dzięki temu można przenieść kształt na przedni plan lub cofnąć go na tył slajdu. Ta funkcja jest szczególnie przydatna, gdy trzeba umieścić znak wodny przed zawartością prezentacji:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Ustawienie obrotu znaku wodnego**

Poniżej znajduje się przykład kodu, jak dostosować obrót znaku wodnego, aby był położony diagonalnie na slajdzie:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **Ustawienie nazwy dla znaku wodnego**

Aspose.Slides umożliwia ustawienie nazwy kształtu. Korzystając z nazwy kształtu, możesz w przyszłości uzyskać do niego dostęp w celu modyfikacji lub usunięcia. Aby ustawić nazwę kształtu znaku wodnego, przypisz ją metodzie [**AutoShape.getName**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getName--):

```javascript
watermarkShape.setName("watermark");
```

### **Usunięcie znaku wodnego**

Aby usunąć kształt znaku wodnego, użyj metody [AutoShape.getName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getName--) w celu odnalezienia go w kolekcji kształtów slajdu. Następnie przekaż kształt znaku wodnego do metody [**ShapeCollection.remove**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **FAQ**

**Czym jest znak wodny i dlaczego powinienem go używać?**

Znak wodny to nakładka tekstowa lub graficzna stosowana na slajdach, która pomaga chronić własność intelektualną, zwiększyć rozpoznawalność marki lub zapobiec nieautoryzowanemu użyciu prezentacji.

**Czy mogę dodać znak wodny do wszystkich slajdów w prezentacji?**

Tak, Aspose.Slides umożliwia dodanie znaku wodnego do każdego slajdu w prezentacji. Możesz przeiterować wszystkie slajdy i zastosować ustawienia znaku wodnego indywidualnie.

**Jak mogę dostosować przejrzystość znaku wodnego?**

Przejrzystość znaku wodnego można zmienić, modyfikując [ustawienia wypełnienia](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getfillformat/) kształtu. Dzięki temu znak wodny będzie subtelny i nie będzie rozpraszał uwagi od treści slajdu.

**Jakie formaty obrazów są obsługiwane dla znaków wodnych?**

Aspose.Slides obsługuje różne formaty obrazów, takie jak PNG, JPEG, GIF, BMP, SVG i inne.

**Czy mogę dostosować czcionkę i styl tekstowego znaku wodnego?**

Tak, możesz wybrać dowolną czcionkę, rozmiar i styl, aby dopasować znak wodny do projektu prezentacji i zachować spójność marki.

**Jak zmienić pozycję lub orientację znaku wodnego?**

Pozycję i orientację znaku wodnego można zmienić, modyfikując współrzędne, rozmiar oraz właściwości obrotu kształtu.