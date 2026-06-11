---
title: Hantera teckensnitt i presentationer med PHP
linktitle: Hantera teckensnitt
type: docs
weight: 10
url: /sv/php-java/manage-fonts/
keywords:
- hantera teckensnitt
- teckensnittsegenskaper
- stycke
- textformatering
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Kontrollera teckensnitt i PHP med Aspose.Slides: bädda in, ersätta och ladda anpassade teckensnitt för att hålla PPT-, PPTX- och ODP-presentationer tydliga, varumärkessäkra och konsekventa."
---
## **Hantera teckensnittsrelaterade egenskaper**
{{% alert color="primary" %}} 

Presentationer innehåller vanligtvis både text och bilder. Texten kan formateras på olika sätt, antingen för att markera specifika avsnitt och ord eller för att följa företagsstilar. Textformatering hjälper användare att variera utseendet på presentationsinnehållet. Den här artikeln visar hur man använder Aspose.Slides för PHP via Java för att konfigurera teckensnittsegenskaperna för textparagrafer på bilder.

{{% /alert %}} 

För att hantera teckensnittsegenskaper för ett stycke med Aspose.Slides för PHP via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Hämta en bilds referens genom att använda dess index.
1. Åtkomst till [Placeholder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/placeholder/)‑formerna i bilden och typomvandla dem till [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).
1. Hämta [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/) från [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) som exponeras av [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).
1. Justera stycket.
1. Åtkomst till en [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/)s text [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/).
1. Definiera teckensnittet med hjälp av [FontData](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontdata/) och sätt **Font** för text‑[Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/) därefter.
   1. Sätt teckensnittet till fetstil.
   1. Sätt teckensnittet till kursiv.
1. Ställ in teckensnittsfärgen med hjälp av [FillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/) som exponeras av [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/)‑objektet.
1. Spara den ändrade presentationen till en PPTX‑fil.

Implementeringen av stegen ovan visas nedan. Den tar en enkel presentation och formaterar teckensnitten på en av bilderna. Skärmbilderna som följer visar indatafilen och hur kodsnuttarna ändrar den. Koden ändrar teckensnittet, färgen och teckensnittsstilen.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figur: Texten i indatafilen**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figur: Samma text med uppdaterad formatering**|

```php
  # Instansiera ett Presentation-objekt som representerar en PPTX-fil
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Åtkomst till en bild med dess positionsindex
    $slide = $pres->getSlides()->get_Item(0);
    # Åtkomst till den första och andra platshållaren i bilden och typomvandla den till AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Åtkomst till det första stycket
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Justera stycket
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Åtkomst till den första delen
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Definiera nya teckensnitt
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Tilldela nya teckensnitt till delen
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Ställ in teckensnittet till fetstil
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Ställ in teckensnittet till kursiv
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Ställ in teckensnittsfärg
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Spara PPTX-filen till disk
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ställ in textteckensnittsegenskaper**
{{% alert color="primary" %}} 

Som nämnts i **Hantera teckensnittsrelaterade egenskaper**, används en [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/) för att hålla text med liknande formateringsstil i ett stycke. Den här artikeln visar hur man använder Aspose.Slides för PHP via Java för att skapa en textruta med lite text och sedan definiera ett specifikt teckensnitt samt olika andra egenskaper för teckensnittsfamiljekategorin.

{{% /alert %}} 

För att skapa en textruta och ställa in teckensnittsegenskaper för texten i den:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
1. Hämta referensen till en bild genom att använda dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) av typen **Rectangle** till bilden.
1. Ta bort fyllningsstilen som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).
1. Åtkomst till [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/)‑objektets [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
1. Lägg till lite text i [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
1. Åtkomst till [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/)‑objektet som är associerat med [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
1. Definiera teckensnittet som ska användas för [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/).
1. Ställ in andra teckensnittsegenskaper som fetstil, kursiv, understrykning, färg och storlek med hjälp av de relevanta egenskaperna som exponeras av [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/)‑objektet.
1. Skriv den ändrade presentationen som en PPTX‑fil.

Implementeringen av stegen ovan visas nedan.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figur: Text med några teckensnittsegenskaper inställda av Aspose.Slides för PHP via Java**|

```php
  # Instansiera ett Presentation-objekt som representerar en PPTX-fil
  $pres = new Presentation();
  try {
    # Hämta första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägg till en AutoShape av typen Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Ta bort eventuell fyllningsstil som är associerad med AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Åtkomst till TextFrame som är associerad med AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Åtkomst till Portion som är associerad med TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Ställ in teckensnittet för Portionen
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Ställ in fetstil för teckensnittet
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Ställ in kursiv för teckensnittet
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Ställ in understrykning för teckensnittet
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Ställ in teckensnittets storlek
    $port->getPortionFormat()->setFontHeight(25);
    # Ställ in teckensnittets färg
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Spara presentationen till disk
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```