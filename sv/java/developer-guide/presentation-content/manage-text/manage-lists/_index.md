---
title: Hantera punkt- och nummerlistor i presentationer i Java
linktitle: Hantera listor
type: docs
weight: 60
url: /sv/java/manage-lists/
keywords:
- punkt
- punktlista
- numrerad lista
- symbolpunkt
- bildpunkt
- anpassad punkt
- flernivålista
- skapa punkt
- lägga till punkt
- lägga till lista
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar punkt-, bild-, flernivå- och numrerade listor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides for Java låter dig skapa och formatera punkt- och nummerlistor i PowerPoint- och OpenDocument-presentationer. Ett listobjekt är ett stycke vars punktinställningar styrs genom dess styckeformat.

Använd metoden [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/#getParagraphFormat--) för att komma åt listinställningar på styckenivå. Huvudinkörningspunkten är [IParagraphFormat.getBullet](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#getBullet--), som returnerar ett [IBulletFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/)‑objekt. Med detta objekt kan du ange punktens typ, symbol, bild, färg, storlek, numreringsstil och startnummer.

Denna artikel visar hur man:

- skapa en punktlista med en anpassad symbol
- skapa en bildpunkt
- skapa en flernivålista genom att ange styckets djup
- skapa en numrerad lista
- undersöka och ändra listformatering i en befintlig presentation

## **Skapa en punktlista**

För att skapa en punktlista, lägg till [IParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/)‑objekt i ett [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) och sätt [IBulletFormat.setType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setType-byte-) till [BulletType.Symbol](https://reference.aspose.com/slides/sv/java/com.aspose.slides/bullettype/#Symbol). Du kan sedan sätta [IBulletFormat.setChar](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#getColor--) och [IBulletFormat.setHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setHeight-float-) för att kontrollera punktens utseende.

Följande Java‑kod visar hur man skapar en punktlista i en bild:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Symbolpunkterna](symbol_bullets.png)

## **Skapa en numrerad lista**

Använd numrerade listor när objektens ordning är viktig. Sätt [IBulletFormat.setType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setType-byte-) till [BulletType.Numbered](https://reference.aspose.com/slides/sv/java/com.aspose.slides/bullettype/#Numbered). Du kan även välja ett numreringsformat med [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) eller sätta [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) när listan ska börja med ett annat värde än 1.

Följande Java‑kod visar hur man skapar en numrerad lista i en bild:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Numrerade punkter](numbered_bullets.png)

## **Skapa en bildpunkt**

Aspose.Slides låter dig ersätta en vanlig punktsymbol med en bild. Bildpunkter fungerar bäst med enkla bilder som förblir läsbara i liten storlek, såsom ikoner eller små transparenta PNG‑filer.

{{% alert color="info" %}}
Om du planerar att ersätta den vanliga punktsymbolen med en bild är det idealiskt att välja en enkel grafik med transparent bakgrund. Sådana bilder fungerar bra som anpassade punktsymboler.

Kom ihåg att bilden kommer att skalas ner till en mycket liten storlek. Av den anledningen rekommenderar vi starkt att välja en bild som förblir tydlig och visuellt effektiv när den används som punkt i en lista.
{{% /alert %}}

För att skapa en bildpunkt, lägg till en bild i [Presentation.getImages](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getImages--) och tilldela det returnerade bildobjektet till [IBulletFormat.getPicture](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#getPicture--). Sätt [IBulletFormat.setType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setType-byte-) till [BulletType.Picture](https://reference.aspose.com/slides/sv/java/com.aspose.slides/bullettype/#Picture) innan du tilldelar bilden.

Anta att vi har en "image.png":

![En bild för punkterna](picture_for_bullets.png)

Följande Java‑kod visar hur man skapar bildpunkter i en bild:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Bildpunkterna](picture_bullets.png)

## **Skapa en flernivålista**

Använd [IParagraphFormat.setDepth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setDepth-short-) för att placera listaobjekt på olika nivåer. Nivå 0 är den översta nivån, nivå 1 ligger inbäddad under den, och så vidare.

Följande Java‑kod visar hur man skapar en flernivå punktlista:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Flernivålistan](multilevel_list.png)

## **Ändra en befintlig lista**

För att ändra listformatering i en befintlig presentation, gå till målstycket och uppdatera dess [IParagraphFormat.getBullet](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#getBullet--)‑inställningar. Samma egenskaper som används för att skapa listor kan också användas för att undersöka eller ändra listor som har lästs in från en PPT‑, PPTX‑ eller ODP‑fil.

Följande Java‑kod ändrar det första stycket i en textram för att använda ett numrerat listformat:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Kan punkt- och nummerlistor exporteras till PDF eller bilder?

Ja. Aspose.Slides bevarar listformatering när målformatet stödjer motsvarande textlayout och punktfunktioner.

### Kan jag redigera listor i befintliga presentationer?

Ja. Ladda presentationen, gå till målstycket, undersök eller uppdatera dess [IParagraphFormat.getBullet](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#getBullet--)‑inställningar, och spara presentationen.

### Kan listor innehålla icke‑latinsk text?

Ja. Texten för listobjekt kan innehålla Unicode‑tecken, så du kan skapa listor i flerspråkiga presentationer. Säkerställ att de teckensnitt som används i presentationen stöder de tecken du behöver.