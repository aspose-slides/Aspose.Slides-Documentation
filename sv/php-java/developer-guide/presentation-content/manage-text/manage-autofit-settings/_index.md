---
title: Förbättra dina presentationer med AutoFit i PHP
linktitle: Autofit-inställningar
type: docs
weight: 30
url: /sv/php-java/manage-autofit-settings/
keywords:
- textruta
- autofit
- Ingen autofit
- anpassa text
- krymp text
- radbryt text
- ändra storlek på form
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera AutoFit-inställningar i Aspose.Slides för PHP för att optimera textvisning i dina PowerPoint- och OpenDocument-presentationer och förbättra innehållets läsbarhet."
---
## **Introduktion**

Som standard, när du lägger till en textruta, använder Microsoft PowerPoint inställningen **Resize shape to fix text** för textrutan — den ändrar automatiskt storleken på textrutan så att dess text alltid får plats.

![textbox-i-powerpoint](textbox-in-powerpoint.png)

* När texten i textrutan blir längre eller större förstorar PowerPoint textrutan — ökning av höjden — för att rymma mer text.  
* När texten i textrutan blir kortare eller mindre minskar PowerPoint textrutan — minskning av höjden — för att ta bort överflödig plats.

I PowerPoint finns det fyra viktiga parametrar eller alternativ som styr autofit‑beteendet för en textruta:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-alternativ-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java erbjuder liknande alternativ — några egenskaper i klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TextFrameFormat) — som låter dig kontrollera autofit‑beteendet för textrutor i presentationer.

## **Resize a Shape to Fit Text**

Om du vill att texten i en ruta alltid ska få plats i den efter att texten förändrats, måste du använda alternativet **Resize shape to fix text**. För att ange denna inställning, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TextFrameFormat)) till `Shape`.

![alwaysfit-inställning-powerpoint](alwaysfit-setting-powerpoint.png)

Den här PHP‑koden visar hur du anger att text alltid ska få plats i sin ruta i en PowerPoint‑presentation:

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

Om texten blir längre eller större kommer textrutan automatiskt att ändra storlek (ökning i höjd) så att all text får plats. Om texten blir kortare sker motsatsen.

## **Do Not Autofit**

Om du vill att en textruta eller form ska behålla sina mått oavsett vilka ändringar som görs i den innehållande texten, måste du använda alternativet **Do not Autofit**. För att ange denna inställning, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TextFrameFormat)) till `None`.

![donotautofit-inställning-powerpoint](donotautofit-setting-powerpoint.png)

Den här PHP‑koden visar hur du anger att en textruta alltid ska behålla sina mått i en PowerPoint‑presentation:

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

När texten blir för lång för sin ruta, rinner den över.

## **Shrink Text on Overflow**

Om en text blir för lång för sin ruta kan du med alternativet **Shrink text on overflow** ange att textens storlek och avstånd ska minskas så att den får plats. För att ange denna inställning, sätt egenskapen [AutofitType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TextFrameFormat)) till `Normal`.

![shrinktextonoverflow-inställning-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Den här PHP‑koden visar hur du anger att en text ska krympas vid överflöde i en PowerPoint‑presentation:

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
När alternativet **Shrink text on overflow** används appliceras inställningen endast när texten blir för lång för sin ruta.
{{% /alert %}}

## **Wrap Text**

Om du vill att texten i en form ska radbrytas inuti formen när den överskrider formens kant (endast bredd) måste du använda parametern **Wrap text in shape**. För att ange denna inställning, sätt egenskapen [WrapText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TextFrameFormat#getWrapText--) (från klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TextFrameFormat)) till `true`.

Den här PHP‑koden visar hur du använder inställningen Wrap Text i en PowerPoint‑presentation:

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
Om du sätter egenskapen `WrapText` till `False` för en form, när texten i formen blir längre än formens bredd, fortsätter texten utanför formens kanter på en enda rad.
{{% /alert %}}

## **FAQ**

**Påverkar textramens interna marginaler AutoFit?**

Ja. Padding (internt marginaler) minskar det användbara området för text, så AutoFit aktiveras tidigare — fonten krymps eller formen storleksändras tidigare. Kontrollera och justera marginalerna innan du finjusterar AutoFit.

**Hur samverkar AutoFit med manuella och mjuka radbrytningar?**

Tvingade brytningar kvarstår, och AutoFit anpassar fontstorlek och avstånd runt dem. Att ta bort onödiga brytningar minskar ofta hur aggressivt AutoFit måste krympa texten.

**Påverkar byte av temafont eller fontsubstitution resultatet av AutoFit?**

Ja. Att ersätta med en font som har andra glyf-mått ändrar textens bredd/höjd, vilket kan förändra slutlig fontstorlek och radbrytning. Efter varje fontbyte eller substitution bör du kontrollera bilderna igen.