---
title: Správa ActiveX ovládacích prvků v prezentacích pomocí PHP
linktitle: ActiveX
type: docs
weight: 80
url: /cs/php-java/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- správa ActiveX
- přidání ActiveX
- úprava ActiveX
- přehrávač médií
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, jak Aspose.Slides pro PHP přes Java využívá ActiveX k automatizaci a vylepšení prezentací PowerPoint, a poskytuje vývojářům mocnou kontrolu nad snímky."
---
## **Úvod**

ActiveX ovládací prvky se používají v prezentacích. Aspose.Slides pro PHP přes Java umožňuje přidávat a spravovat ActiveX ovládací prvky, ale jsou o něco obtížnější na správu oproti běžným tvarům prezentace. Implementovali jsme podporu přidání Media Player Active ovládacího prvku do Aspose.Slides. Všimněte si, že ActiveX ovládací prvky nejsou tvary; nejsou součástí prezentace [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/). Jsou součástí samostatné [ControlCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/controlcollection/) místo toho. V tomto tématu vám ukážeme, jak s nimi pracovat.

## **Přidání Media Player ActiveX ovládacího prvku na snímek**
Chcete-li přidat ActiveX Media Player ovládací prvek, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) a vygenerujte prázdnou prezentaci.
2. Přistupte k cílovému snímku v [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
3. Přidejte Media Player ActiveX ovládací prvek pomocí metody [addControl](https://reference.aspose.com/slides/cs/php-java/aspose.slides/controlcollection/addcontrol/) vystavené třídou [ControlCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/controlcollection/).
4. Získejte přístup k Media Player ActiveX ovládacímu prvku a nastavte cestu k videu pomocí jeho vlastností.
5. Uložte prezentaci jako soubor PPTX.

Tento vzorový kód, založený na výše uvedených krocích, ukazuje, jak přidat Media Player ActiveX ovládací prvek na snímek:

```php
  # Vytvořit prázdnou instanci prezentace
  $pres = new Presentation();
  try {
    # Přidání Media Player ActiveX ovládacího prvku
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # Získat Media Player ActiveX ovládací prvek a nastavit cestu k videu
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Uložit prezentaci
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Úprava ActiveX ovládacího prvku**
{{% alert color="primary" %}} 

Aspose.Slides pro PHP přes Java 7.1.0 a novější verze jsou vybaveny komponentami pro správu ActiveX ovládacích prvků. Můžete získat přístup k již přidanému ActiveX ovládacímu prvku ve vaší prezentaci a upravit jej nebo smazat prostřednictvím jeho vlastností.

{{% /alert %}} 

Pro správu jednoduchého ActiveX ovládacího prvku, například textového pole a jednoduchého tlačítka, na snímku proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) a načtěte prezentaci, která obsahuje ActiveX ovládací prvky.
2. Získejte referenci na snímek podle jeho indexu.
3. Přistupte k ActiveX ovládacím prvkům na snímku prostřednictvím [ControlCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/controlcollection/).
4. Získejte přístup k ActiveX ovládacímu prvku TextBox1 pomocí objektu [Control](https://reference.aspose.com/slides/cs/php-java/aspose.slides/control/).
5. Změňte vlastnosti ActiveX ovládacího prvku TextBox1, které zahrnují text, písmo, výšku písma a pozici rámečku.
6. Získejte přístup k druhému ovládacímu prvku nazvanému CommandButton1.
7. Změňte popisek tlačítka, písmo a pozici.
8. Posuňte pozici rámečků ActiveX ovládacích prvků.
9. Uložte upravenou prezentaci do souboru PPTX.

Tento vzorový kód, založený na výše uvedených krocích, ukazuje, jak spravovat jednoduchý ActiveX ovládací prvek: 

```php
  # Přístup k prezentaci s ActiveX ovládacími prvky
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Přístup k prvnímu snímku v prezentaci
    $slide = $pres->getSlides()->get_Item(0);
    # Změna textu TextBoxu
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Změna náhradního obrázku. PowerPoint nahradí tento obrázek během aktivace ActiveX,
      # takže někdy je v pořádku nechat obrázek beze změny.
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
    # Změna popisku tlačítka
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Změna náhrady
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
    # posunutí o 100 bodů dolů
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # odstranění ovládacích prvků
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

**Zachovává Aspose.Slides ActiveX ovládací prvky při čtení a opětovném uložení, pokud nemohou být spuštěny v Java runtime?**

Ano. Aspose.Slides je považuje za součást prezentace a může číst/upravovat jejich vlastnosti a rámečky; pro jejich zachování není nutné spouštět samotné ovládací prvky.

**Jak se ActiveX ovládací prvky liší od OLE objektů v prezentaci?**

ActiveX ovládací prvky jsou interaktivní řízené prvky (tlačítka, textová pole, přehrávač médií), zatímco [OLE](/slides/cs/php-java/manage-ole/) odkazuje na vložené objektové aplikace (například list Excelu). Jsou ukládány a zpracovávány odlišně a mají jiný model vlastností.

**Fungují události ActiveX a VBA makra, pokud byl soubor upraven pomocí Aspose.Slides?**

Aspose.Slides zachovává existující značky a metadata; nicméně události a makra běží pouze v PowerPointu ve Windows, pokud to bezpečnostní nastavení umožňuje. Knihovna neprovádí VBA.