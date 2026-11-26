---
title: Správa ActiveX ovládacích prvků v prezentacích pomocí PHP
linktitle: ActiveX
type: docs
weight: 80
url: /cs/php-java/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- spravovat ActiveX
- přidat ActiveX
- upravit ActiveX
- multimediální přehrávač
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Upravujte textová pole a tlačítka ActiveX, aktualizujte náhledy ovládacích prvků a znovu použijte ovládací prvek Windows Media Player v prezentacích PowerPoint s Aspose.Slides pro PHP přes Java."
---
## **Úvod**

ActiveX ovládací prvky poskytují snímku PowerPointu interaktivní elementy, jako jsou textová pole, tlačítka příkazů a přehrávače médií. Aspose.Slides for PHP via Java zpřístupňuje ovládací prvky snímku pomocí [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). Použijte tuto kolekci k úpravě ovládacího prvku, jeho přesunu na snímku nebo odstranění.

## **Seznam ActiveX ovládacích prvků a jejich uložených vlastností**

Pro prozkoumání neznámé šablony ji otevřete pro čtení a iterujte přes ovládací prvky na každém snímku. Příklad uvádí číslo snímku, název ovládacího prvku, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId), a každou dvojici klíč‑hodnota v [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). Prezentaci načte bez aktivace ovládacích prvků, spouštění událostí nebo maker, měnění hodnot nebo ukládání souboru.

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

Vybraný výstup ze souboru `ActiveX.pptm` zobrazuje textové pole a tlačítko příkazu.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Prázdná kolekce vlastností se zobrazí jako `[]`. U ovládacích prvků, které používají binární úložiště, může [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) vrátit `null`, zobrazené jako `Properties unavailable`. Pokud potřebujete pouze názvy, použijte [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) po kontrole na null. Zpráva uvádí vlastnosti dostupné v prezentaci. Ovládací prvek může za běhu podporovat další vlastnosti.

## **Úprava ActiveX ovládacích prvků**

Příklad očekává prezentaci s podporou maker, která na prvním snímku obsahuje textové pole pojmenované `TextBox1` a tlačítko příkazu pojmenované `CommandButton1`. Používá [kolekce vlastností ovládacího prvku](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) k změně hodnoty textového pole a popisku tlačítka. Každý ovládací prvek má také statický náhled, který PowerPoint může zobrazit před aktivací. Poskytněte PNG pro každý ovládací prvek zobrazující jeho aktualizovaný text a vzhled. Příklad přiřazuje tyto obrázky pomocí [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

Příklad posune každý ovládací prvek na prvním snímku dolů o 100 bodů nastavením jeho rámce pomocí [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). Uloží upravenou prezentaci ve formátu PPTM a poté použije [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear), aby uložil druhou kopii, ve které jsou ze snímku odstraněny všechny ActiveX ovládací prvky.

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

## **Přidání ActiveX mediálního přehrávače**

Pro opětovné použití nakonfigurovaného ovládacího prvku Windows Media Player začněte se šablonou, jejíž první snímek obsahuje přehrávač pojmenovaný `WindowsMediaPlayer1`. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) zkopíruje celý snímek do nové prezentace. Příklad nastaví `URL` přehrávače v jeho [kolekce vlastností](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) a uloží klonovaný snímek jako jediný snímek ve výstupu. Video zůstane externí, takže zvolte cestu, ke které má přehrávač během přehrávání přístup.

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

## **Často kladené otázky**

**Může Aspose.Slides zachovat ActiveX ovládací prvky, aniž by je spouštěl?**

Ano. Aspose.Slides může číst a ukládat ovládací prvky, včetně jejich vlastností a pozic, aniž by je aktivoval.

**Jak se ActiveX ovládací prvky liší od OLE objektů?**

ActiveX ovládací prvky umožňují uživatelům interagovat se snímkem, například zadávat text nebo kliknout na tlačítko. [OLE objekt](/slides/cs/php-java/manage-ole/) umožňuje, aby snímek obsahoval nebo odkazoval na obsah spravovaný jinou aplikací, jako je list Excelu.

**Budou události ActiveX i nadále spouštět makra VBA po uložení prezentace pomocí Aspose.Slides?**

Uložte prezentaci ve formátu podporujícím makra, například PPTM, aby byl zachován její projekt VBA. PowerPoint pro Windows může spouštět existující obslužné rutiny událostí, pokud jsou v bezpečnostních nastaveních povoleny jak ActiveX ovládací prvky, tak makra.