---
title: Zarządzanie kontrolkami ActiveX w prezentacjach przy użyciu PHP
linktitle: ActiveX
type: docs
weight: 80
url: /pl/php-java/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- zarządzanie ActiveX
- dodawanie ActiveX
- modyfikowanie ActiveX
- odtwarzacz multimedialny
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides for PHP via Java wykorzystuje ActiveX do automatyzacji i ulepszania prezentacji PowerPoint, zapewniając programistom potężną kontrolę nad slajdami."
---
## **Wprowadzenie**

Kontrolki ActiveX są używane w prezentacjach. Aspose.Slides for PHP via Java umożliwia dodawanie i zarządzanie kontrolkami ActiveX, ale są one nieco trudniejsze w obsłudze w porównaniu do zwykłych kształtów prezentacji. Wprowadziliśmy obsługę dodawania kontrolki Media Player Active w Aspose.Slides. Należy zauważyć, że kontrolki ActiveX nie są kształtami; nie są częścią prezentacji [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/). Są częścią osobnego [ControlCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/controlcollection/) zamiast tego. W tym temacie pokażemy, jak z nimi pracować.

## **Dodaj kontrolkę ActiveX Media Player do slajdu**
Aby dodać kontrolkę ActiveX Media Player, wykonaj to:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) i wygeneruj pustą prezentację.
1. Uzyskaj dostęp do docelowego slajdu w [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Dodaj kontrolkę Media Player ActiveX, używając metody [addControl](https://reference.aspose.com/slides/pl/php-java/aspose.slides/controlcollection/addcontrol/) udostępnionej przez [ControlCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/controlcollection/).
1. Uzyskaj dostęp do kontrolki Media Player ActiveX i ustaw ścieżkę wideo, korzystając z jej właściwości.
1. Zapisz prezentację jako plik PPTX.

Ten przykładowy kod, oparty na powyższych krokach, pokazuje, jak dodać kontrolkę Media Player ActiveX do slajdu:

```php
  # Utwórz pustą instancję prezentacji
  $pres = new Presentation();
  try {
    # Dodawanie kontrolki Media Player ActiveX
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Uzyskaj dostęp do kontrolki Media Player ActiveX i ustaw ścieżkę wideo
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Zapisz prezentację
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modyfikuj kontrolkę ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 7.1.0 i nowsze wersje są wyposażone w komponenty do zarządzania kontrolkami ActiveX. Możesz uzyskać dostęp do już dodanej kontrolki ActiveX w prezentacji i zmodyfikować ją lub usunąć poprzez jej właściwości.

{{% /alert %}} 

Aby zarządzać prostą kontrolką ActiveX, taką jak pole tekstowe i prosty przycisk poleceń na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) i załaduj prezentację zawierającą kontrolki ActiveX.
1. Uzyskaj referencję do slajdu na podstawie jego indeksu.
1. Uzyskaj dostęp do kontrolek ActiveX na slajdzie, odwołując się do [ControlCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/controlcollection/).
1. Uzyskaj dostęp do kontrolki ActiveX TextBox1, używając obiektu [Control](https://reference.aspose.com/slides/pl/php-java/aspose.slides/control/).
1. Zmień właściwości kontrolki ActiveX TextBox1, które obejmują tekst, czcionkę, wysokość czcionki oraz pozycję ramki.
1. Uzyskaj dostęp do drugiej kontrolki o nazwie CommandButton1.
1. Zmień etykietę przycisku, czcionkę i pozycję.
1. Przesuń pozycję ramek kontrolek ActiveX.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten przykładowy kod, oparty na powyższych krokach, pokazuje, jak zarządzać prostą kontrolką ActiveX:

```php
  # Uzyskiwanie dostępu do prezentacji z kontrolkami ActiveX
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Uzyskiwanie dostępu do pierwszego slajdu w prezentacji
    $slide = $pres->getSlides()->get_Item(0);
    # Zmienianie tekstu TextBox
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Zmienianie obrazu zastępczego. PowerPoint zastąpi ten obraz podczas aktywacji ActiveX,
      # więc czasami można pozostawić obraz niezmieniony.
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->window);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $graphics->drawString($newText, 10, 20);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # Zmienianie etykiety przycisku
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Zmienianie zastępczego
      $image = new BufferedImage($control->getFrame()->getWidth(), $control->getFrame()->getHeight(), BufferedImage->TYPE_INT_ARGB);
      $graphics = $image->getGraphics();
      $graphics->setColor(SystemColor->control);
      $graphics->fillRect(0, 0, $image->getWidth(), $image->getHeight());
      $font = new Font($control->getProperties()->get_Item("FontName"), Font->PLAIN, 16);
      $graphics->setColor(SystemColor->windowText);
      $graphics->setFont($font);
      $metrics = $graphics->getFontMetrics($font);
      $graphics->drawString($newCaption, $image->getWidth() - $metrics->stringWidth($newCaption) / 2, 20);
      $graphics->setColor(SystemColor->controlLtHighlight);
      $graphics->drawLine(0, $image->getHeight() - 1, 0, 0);
      $graphics->drawLine(0, 0, $image->getWidth() - 1, 0);
      $graphics->setColor(SystemColor->controlHighlight);
      $graphics->drawLine(1, $image->getHeight() - 2, 1, 1);
      $graphics->drawLine(1, 1, $image->getWidth() - 2, 1);
      $graphics->setColor(SystemColor->controlShadow);
      $graphics->drawLine(1, $image->getHeight() - 1, $image->getWidth() - 1, $image->getHeight() - 1);
      $graphics->drawLine($image->getWidth() - 1, $image->getHeight() - 1, $image->getWidth() - 1, 1);
      $graphics->setColor(SystemColor->controlDkShadow);
      $graphics->drawLine(0, $image->getHeight(), $image->getWidth(), $image->getHeight());
      $graphics->drawLine($image->getWidth(), $image->getHeight(), $image->getWidth(), 0);
      $graphics->dispose();
      $baos = new Java("java.io.ByteArrayOutputStream");
      Java("javax.imageio.ImageIO")->write($image, "PNG", $baos);
      $control->getSubstitutePictureFormat()->getPicture()->setImage($pres->getImages()->addImage($baos->toByteArray()));
    }
    # przesunięcie o 100 punktów w dół
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # usuwanie kontrolek
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy Aspose.Slides zachowuje kontrolki ActiveX podczas odczytu i ponownego zapisu, jeśli nie mogą być wykonane w środowisku Java?**

Tak. Aspose.Slides traktuje je jako część prezentacji i może odczytywać/modyfikować ich właściwości oraz ramki; wykonywanie samych kontrolek nie jest wymagane, aby je zachować.

**Jak kontrolki ActiveX różnią się od obiektów OLE w prezentacji?**

Kontrolki ActiveX są interaktywnymi, zarządzanymi kontrolkami (przyciski, pola tekstowe, odtwarzacz multimedialny), natomiast [OLE](/slides/pl/php-java/manage-ole/) odnosi się do osadzonych obiektów aplikacji (np. arkusza Excel). Są przechowywane i obsługiwane inaczej oraz mają inny model właściwości.

**Czy zdarzenia ActiveX i makra VBA działają, jeśli plik został zmodyfikowany przez Aspose.Slides?**

Aspose.Slides zachowuje istniejące znaczniki i metadane; jednak zdarzenia i makra uruchamiają się tylko w PowerPoint na systemie Windows, gdy zabezpieczenia na to pozwalają. Biblioteka nie wykonuje VBA.