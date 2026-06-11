---
title: Ulepsz swoje prezentacje przy użyciu AutoFit w PHP
linktitle: Ustawienia Autofit
type: docs
weight: 30
url: /pl/php-java/manage-autofit-settings/
keywords:
- pole tekstowe
- autofit
- nie używać autofit
- dopasuj tekst
- zmniejsz tekst
- zawijaj tekst
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj ustawieniami AutoFit w Aspose.Slides dla PHP, aby zoptymalizować wyświetlanie tekstu w prezentacjach PowerPoint i OpenDocument oraz poprawić czytelność treści."
---
## **Wprowadzenie**

Domyślnie, po dodaniu pola tekstowego, Microsoft PowerPoint używa ustawienia **Resize shape to fix text** dla pola tekstowego — automatycznie zmienia rozmiar pola, aby jego tekst zawsze w nim mieścił się. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Gdy tekst w polu tekstowym staje się dłuższy lub większy, PowerPoint automatycznie powiększa pole tekstowe — zwiększa jego wysokość — aby pomieścił więcej tekstu. 
* Gdy tekst w polu tekstowym staje się krótszy lub mniejszy, PowerPoint automatycznie zmniejsza pole tekstowe — zmniejsza jego wysokość — aby usunąć zbędną przestrzeń. 

W programie PowerPoint istnieją 4 istotne parametry lub opcje kontrolujące zachowanie autofit dla pola tekstowego: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java udostępnia podobne opcje — niektóre własności klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TextFrameFormat) — które pozwalają kontrolować zachowanie autofit dla pól tekstowych w prezentacjach.

## **Zmienianie rozmiaru kształtu, aby dopasować tekst**

Jeśli chcesz, aby tekst w ramce zawsze mieścił się w tej ramce po wprowadzeniu zmian w tekście, musisz użyć opcji **Resize shape to fix text**. Aby określić to ustawienie, ustaw właściwość [AutofitType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TextFrameFormat)) na `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ten kod PHP pokazuje, jak określić, że tekst musi zawsze mieścić się w swojej ramce w prezentacji PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Jeśli tekst stanie się dłuższy lub większy, pole tekstowe zostanie automatycznie zmienione rozmiarowo (zwiększy się wysokość), aby cały tekst w nim się mieścił. Jeśli tekst stanie się krótszy, nastąpi odwrotne działanie. 

## **Nie używaj Autofit**

Jeśli chcesz, aby pole tekstowe lub kształt zachowywał swoje wymiary niezależnie od zmian w zawartym tekście, musisz użyć opcji **Do not Autofit**. Aby określić to ustawienie, ustaw właściwość [AutofitType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TextFrameFormat)) na `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ten kod PHP pokazuje, jak określić, że pole tekstowe musi zawsze zachowywać swoje wymiary w prezentacji PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Gdy tekst stanie się zbyt długi dla swojej ramki, wypływa poza nią. 

## **Zmniejsz tekst przy przepełnieniu**

Jeśli tekst stanie się zbyt długi dla swojej ramki, za pomocą opcji **Shrink text on overflow** możesz określić, że rozmiar i odstępy tekstu mają zostać zmniejszone, aby zmieściły się w ramce. Aby określić to ustawienie, ustaw właściwość [AutofitType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TextFrameFormat)) na `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ten kod PHP pokazuje, jak określić, że tekst musi być zmniejszony przy przepełnieniu w prezentacji PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Gdy użyta zostanie opcja **Shrink text on overflow**, ustawienie jest stosowane tylko wtedy, gdy tekst staje się zbyt długi dla swojej ramki. 
{{% /alert %}}

## **Wrap Text**

Jeśli chcesz, aby tekst w kształcie był zawijany wewnątrz tego kształtu, gdy tekst wykracza poza obwód kształtu (tylko szerokość), musisz użyć parametru **Wrap text in shape**. Aby określić to ustawienie, ustaw właściwość [WrapText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TextFrameFormat#getWrapText--) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TextFrameFormat)) na `true`.

Ten kod PHP pokazuje, jak używać ustawienia Wrap Text w prezentacji PowerPoint:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Jeśli ustawisz właściwość `WrapText` na `False` dla kształtu, gdy tekst wewnątrz kształtu stanie się dłuższy niż jego szerokość, tekst zostanie wydłużony poza granice kształtu w jednej linii. 
{{% /alert %}}

## **FAQ**

**Czy wewnętrzne marginesy ramki tekstowej wpływają na AutoFit?**

Tak. Wypełnienie (wewnętrzne marginesy) zmniejsza dostępną powierzchnię dla tekstu, więc AutoFit zostanie uruchomiony wcześniej — zmniejszając czcionkę lub rozmiar kształtu szybciej. Sprawdź i dostosuj marginesy przed regulacją AutoFit.

**Jak AutoFit współdziała z ręcznymi i miękkimi podziałami wierszy?**

Wymuszone podziały pozostają, a AutoFit dostosowuje rozmiar czcionki i odstępy wokół nich. Usunięcie niepotrzebnych podziałów często zmniejsza agresywność, z jaką AutoFit musi zmniejszać tekst.

**Czy zmiana czcionki motywu lub wywołanie podstawienia czcionki wpływa na wyniki AutoFit?**

Tak. Podstawienie czcionki o innych metrykach glifów zmienia szerokość/wysokość tekstu, co może zmienić ostateczny rozmiar czfonta i zawijanie wierszy. Po każdej zmianie lub podstawieniu czcionki sprawdź ponownie slajdy.