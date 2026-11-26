---
title: Zarządzanie kontrolkami ActiveX w prezentacjach przy użyciu PHP
linktitle: ActiveX
type: docs
weight: 80
url: /pl/php-java/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- zarządzaj ActiveX
- dodaj ActiveX
- modyfikuj ActiveX
- odtwarzacz multimedialny
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Edytuj pola tekstowe i przyciski ActiveX, aktualizuj podglądy kontrolek i ponownie używaj kontrolki Windows Media Player w prezentacjach PowerPoint z Aspose.Slides dla PHP via Java."
---
## **Wprowadzenie**

Kontrolki ActiveX zapewniają slajdowi programu PowerPoint elementy interaktywne, takie jak pola tekstowe, przyciski poleceń i odtwarzacze multimediów. Aspose.Slides for PHP via Java udostępnia kontrolki slajdu poprzez [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). Użyj tej kolekcji, aby edytować kontrolkę, przenieść ją na slajdzie lub usunąć.

## **Lista kontrolek ActiveX i ich przechowywanych właściwości**

Aby zbadać nieznany szablon, otwórz go do odczytu i przeiteruj kontrolki na każdym slajdzie. Przykład podaje numer slajdu, nazwę kontrolki, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId), oraz każdą parę klucz‑wartość w [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). Odczytuje prezentację bez aktywacji kontrolek, wywoływania zdarzeń lub makr, zmieniania wartości ani zapisywania pliku.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Wybrany wynik z `ActiveX.pptm` pokazuje pole tekstowe i przycisk polecenia.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Pusta kolekcja właściwości jest wyświetlana jako `[]`. Dla kontrolek używających binarnego przechowywania, [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) może zwrócić `null`, co jest pokazane jako `Properties unavailable`. Jeśli potrzebujesz tylko nazw, użyj [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) po sprawdzeniu wartości null. Raport wymienia właściwości dostępne w prezentacji. Kontrolka może obsługiwać dodatkowe właściwości w czasie wykonywania.

## **Modyfikowanie kontrolek ActiveX**

Przykład zakłada prezentację obsługującą makra z polem tekstowym o nazwie `TextBox1` oraz przyciskiem polecenia o nazwie `CommandButton1` na pierwszym slajdzie. Używa [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) do zmiany wartości pola tekstowego i podpisu przycisku. Każda kontrolka ma także statyczny podgląd, który PowerPoint może wyświetlić przed aktywacją. Dostarcz plik PNG dla każdej kontrolki pokazujący zaktualizowany tekst i wygląd. Przykład przypisuje te obrazy poprzez [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

Przykład przenosi każdą kontrolkę na pierwszym slajdzie w dół o 100 punktów, ustawiając jej ramkę za pomocą [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). Zapisuje zmodyfikowaną prezentację w formacie PPTM, a następnie używa [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) do zapisania drugiej kopii z usuniętymi wszystkimi kontrolkami ActiveX z tego slajdu.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```

## **Dodanie kontrolki ActiveX Media Player**

Aby ponownie użyć skonfigurowanej kontrolki Windows Media Player, rozpocznij od szablonu, którego pierwszy slajd zawiera odtwarzacz o nazwie `WindowsMediaPlayer1`. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) kopiuje cały slajd do nowej prezentacji. Przykład ustawia `URL` odtwarzacza w jego [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) i zapisuje sklonowany slajd jako jedyny slajd w wynikowym pliku. Wideo pozostaje zewnętrzne, więc wybierz ścieżkę dostępną dla odtwarzacza podczas odtwarzania.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```

## **FAQ**

**Czy Aspose.Slides może zachować kontrolki ActiveX bez ich uruchamiania?**

Tak. Aspose.Slides może odczytać i zapisać kontrolki, łącznie z ich właściwościami i pozycjami, bez ich aktywacji.

**Jak kontrolki ActiveX różnią się od obiektów OLE?**

Kontrolki ActiveX umożliwiają użytkownikom interakcję ze slajdem, np. wprowadzanie tekstu lub kliknięcie przycisku. [Obiekt OLE](/slides/pl/php-java/manage-ole/) pozwala slajdowi zawierać lub łączyć się z treścią zarządzaną przez inną aplikację, taką jak arkusz Excel.

**Czy zdarzenia ActiveX nadal wywołają makra VBA po zapisaniu prezentacji przy użyciu Aspose.Slides?**

Zapisz prezentację w formacie obsługującym makra, takim jak PPTM, aby zachować projekt VBA. PowerPoint dla systemu Windows może uruchomić istniejące obsługi zdarzeń, gdy jego ustawienia zabezpieczeń zezwalają zarówno na kontrolki ActiveX, jak i na makra.