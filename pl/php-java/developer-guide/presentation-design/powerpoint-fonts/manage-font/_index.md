---
title: "Zarządzanie czcionkami w prezentacjach przy użyciu PHP"
linktitle: "Zarządzanie czcionkami"
type: docs
weight: 10
url: /pl/php-java/manage-fonts/
keywords:
  - "zarządzanie czcionkami"
  - "właściwości czcionki"
  - "akapit"
  - "formatowanie tekstu"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentacja"
  - "PHP"
  - "Aspose.Slides"
description: "Kontroluj czcionki w PHP przy użyciu Aspose.Slides: osadzaj, zamieniaj i ładuj niestandardowe czcionki, aby prezentacje PPT, PPTX i ODP były czytelne, zgodne z marką i spójne."
---
## **Zarządzanie właściwościami czcionki**
{{% alert color="primary" %}} 

Prezentacje zazwyczaj zawierają zarówno tekst, jak i obrazy. Tekst można formatować na różne sposoby, aby podkreślić określone sekcje i słowa lub dostosować go do stylów korporacyjnych. Formatowanie tekstu pomaga użytkownikom zmienić wygląd i odczucie zawartości prezentacji. Ten artykuł pokazuje, jak używać Aspose.Slides dla PHP via Java do konfigurowania właściwości czcionki akapitów tekstu na slajdach.

{{% /alert %}} 

Aby zarządzać właściwościami czcionki akapitu przy użyciu Aspose.Slides dla PHP via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kształtów [Placeholder](https://reference.aspose.com/slides/pl/php-java/aspose.slides/placeholder/) na slajdzie i rzutuj je na [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/).
1. Pobierz [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) z [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) udostępnionego przez [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/).
1. Wyrównaj akapit.
1. Uzyskaj dostęp do tekstu [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) w postaci [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/).
1. Zdefiniuj czcionkę przy pomocy [FontData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontdata/) i ustaw **Font** tekstu [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) odpowiednio.
   1. Ustaw czcionkę jako pogrubioną.
   1. Ustaw czcionkę jako kursywę.
1. Ustaw kolor czcionki przy użyciu [FillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fillformat/) udostępnionego przez obiekt [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Implementacja powyższych kroków znajduje się poniżej. Pobiera ona prostą prezentację i formatuje czcionki na jednym ze slajdów. Zrzuty ekranu poniżej pokazują plik wejściowy oraz to, jak fragmenty kodu go modyfikują. Kod zmienia czcionkę, kolor i styl czcionki.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Rysunek: Tekst w pliku wejściowym**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Rysunek: Ten sam tekst ze zaktualizowanym formatowaniem**|

```php
  # Utwórz obiekt Presentation, który reprezentuje plik PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Uzyskiwanie dostępu do slajdu przy użyciu jego pozycji
    $slide = $pres->getSlides()->get_Item(0);
    # Uzyskiwanie dostępu do pierwszego i drugiego placeholdera na slajdzie i rzutowanie go jako AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Uzyskiwanie dostępu do pierwszego akapitu
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Wyrównaj akapit
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Uzyskiwanie dostępu do pierwszej części
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Zdefiniuj nowe czcionki
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Przypisz nowe czcionki do części
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Ustaw czcionkę na pogrubioną
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Ustaw czcionkę na kursywę
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Ustaw kolor czcionki
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Zapisz plik PPTX na dysku
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustawianie właściwości czcionki tekstu**
{{% alert color="primary" %}} 

Jak wspomniano w sekcji **Zarządzanie właściwościami czcionki**, [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) służy do przechowywania tekstu o podobnym stylu formatowania w akapicie. Ten artykuł pokazuje, jak używać Aspose.Slides dla PHP via Java do utworzenia pola tekstowego z pewnym tekstem, a następnie określić konkretną czcionkę oraz różne inne właściwości rodziny czcionek.

{{% /alert %}} 

Aby utworzyć pole tekstowe i ustawić właściwości czcionki tekstu w nim:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj do slajdu [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) typu **Rectangle**.
1. Usuń styl wypełnienia powiązany z [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/).
1. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) obiektu [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/).
1. Dodaj trochę tekstu do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/).
1. Uzyskaj dostęp do obiektu [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) powiązanego z [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/).
1. Zdefiniuj czcionkę, którą ma używać [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/).
1. Ustaw pozostałe właściwości czcionki, takie jak pogrubienie, kursywa, podkreślenie, kolor i wysokość, korzystając z odpowiednich właściwości udostępnionych przez obiekt [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Implementacja powyższych kroków znajduje się poniżej.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Rysunek: Tekst z niektórymi właściwościami czcionki ustawionymi przez Aspose.Slides dla PHP via Java**|

```php
  # Utwórz obiekt Presentation, który reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Dodaj AutoShape typu Prostokąt
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Usuń wszelki styl wypełnienia powiązany z AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Uzyskaj dostęp do TextFrame powiązanego z AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Uzyskaj dostęp do Portion powiązanego z TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Ustaw czcionkę dla Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Ustaw właściwość pogrubienia czcionki
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Ustaw właściwość kursywy czcionki
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Ustaw właściwość podkreślenia czcionki
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Ustaw wysokość czcionki
    $port->getPortionFormat()->setFontHeight(25);
    # Ustaw kolor czcionki
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Zapisz prezentację na dysku
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```