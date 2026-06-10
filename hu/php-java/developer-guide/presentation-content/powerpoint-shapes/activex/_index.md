---
title: "ActiveX vezérlők kezelése prezentációkban PHP használatával"
linktitle: "ActiveX"
type: docs
weight: 80
url: /hu/php-java/activex/
keywords:
- "ActiveX"
- "ActiveX vezérlő"
- "ActiveX kezelése"
- "ActiveX hozzáadása"
- "ActiveX módosítása"
- "média lejátszó"
- "PowerPoint"
- "prezentáció"
- "PHP"
- "Aspose.Slides"
description: "Ismerje meg, hogyan használja az Aspose.Slides for PHP via Java az ActiveX-et a PowerPoint prezentációk automatizálására és fejlesztésére, lehetővé téve a fejlesztők számára a diák hatékony irányítását."
---
## **Bevezetés**

Az ActiveX vezérlőket prezentációkban használják. Az Aspose.Slides for PHP via Java lehetővé teszi ActiveX vezérlők hozzáadását és kezelését, de ezek kicsit bonyolultabbak a szokásos prezentációs alakzatokhoz képest. Implementáltuk a Média lejátszó Active vezérlő hozzáadásának támogatását az Aspose.Slides-ban. Vegye figyelembe, hogy az ActiveX vezérlők nem alakzatok; nem részei a prezentáció [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/). A [ControlCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/controlcollection/) részeként vannak jelen. Ebben a témában megmutatjuk, hogyan dolgozhat velük.

## **Média lejátszó ActiveX vezérlő hozzáadása egy diára**
ActiveX média lejátszó vezérlő hozzáadásához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból, és generáljon egy üres prezentációt.
1. Érje el a céldit a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályban.
1. Adja hozzá a Média lejátszó ActiveX vezérlőt a [ControlCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/controlcollection/) által biztosított [addControl](https://reference.aspose.com/slides/hu/php-java/aspose.slides/controlcollection/addcontrol/) metódussal.
1. Érje el a Média lejátszó ActiveX vezérlőt, és állítsa be a videó útvonalát a tulajdonságai segítségével.
1. Mentse a prezentációt PPTX fájlként.

Ez a mintakód, a fenti lépések alapján, bemutatja, hogyan adhat hozzá Média lejátszó ActiveX vezérlőt egy diához:

```php
  # Üres prezentációpéldány létrehozása
  $pres = new Presentation();
  try {
    # Media Player ActiveX vezérlő hozzáadása
    $pres->getSlides()->get_Item(0)->getControls()->addControl(ControlType::WindowsMediaPlayer, 100, 100, 400, 400);
    # A Media Player ActiveX vezérlő elérése és a videó útvonal beállítása
    $pres->getSlides()->get_Item(0)->getControls()->get_Item(0)->getProperties()->set_Item("URL", "Wildlife.wmv");
    # Prezentáció mentése
    $pres->save("Output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ActiveX vezérlő módosítása**
{{% alert color="primary" %}} 

Az Aspose.Slides for PHP via Java 7.1.0 és újabb verziói tartalmaznak komponenseket az ActiveX vezérlők kezeléséhez. Elérheti a már hozzáadott ActiveX vezérlőt a prezentációjában, és módosíthatja vagy törölheti a tulajdonságai segítségével.

{{% /alert %}} 

Egyszerű ActiveX vezérlő, például szövegdoboz és egyszerű parancsgomb kezelése egy dián a következő módon történik:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation) osztályból, és töltse be a prezentációt, amelyben ActiveX vezérlők vannak.
1. Szerezzen meg egy dia referenciát az indexe alapján.
1. Érje el a dia ActiveX vezérlőit a [ControlCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/controlcollection/) elérésével.
1. A [Control](https://reference.aspose.com/slides/hu/php-java/aspose.slides/control/) objektum segítségével érje el a TextBox1 ActiveX vezérlőt.
1. Módosítsa a TextBox1 ActiveX vezérlő tulajdonságait, amelyek a szöveget, betűtípust, betűméretet és a keret helyzetét tartalmazzák.
1. Érje el a második vezérlőt, amely CommandButton1 néven van.
1. Módosítsa a gomb feliratát, betűtípust és helyzetét.
1. Módosítsa az ActiveX vezérlők kereteinek pozícióját.
1. Írja ki a módosított prezentációt PPTX fájlba.

Ez a mintakód, a fenti lépések alapján, bemutatja, hogyan kezelhet egy egyszerű ActiveX vezérlőt:

```php
  # ActiveX vezérlőkkel rendelkező prezentáció elérése
  $pres = new Presentation("ActiveX.pptm");
  try {
    # Prezentáció első diajának elérése
    $slide = $pres->getSlides()->get_Item(0);
    # Szövegdoboz szövegének módosítása
    $control = $slide->getControls()->get_Item(0);
    if (!java_is_null($control->getName()->equalsIgnoreCase("TextBox1") && $control->getProperties())) {
      $newText = "Changed text";
      $control->getProperties()->set_Item("Value", $newText);
      # Helyettesítő kép módosítása. A PowerPoint ezt a képet az ActiveX aktiválásakor cseréli le,
      # ezért néha rendben van, ha a kép változatlan marad.
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
    # Gomb feliratának módosítása
    $control = $pres->getSlides()->get_Item(0)->getControls()->get_Item(1);
    if (!java_is_null($control->getName()->equalsIgnoreCase("CommandButton1") && $control->getProperties())) {
      $newCaption = "Show MessageBox";
      $control->getProperties()->set_Item("Caption", $newCaption);
      # Helyettesítő módosítása
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
    # 100 ponttal lefelé mozgatás
    foreach($pres->getSlides()->get_Item(0)->getControls() as $ctl) {
      $frame = $ctl->getFrame();
      $ctl->setFrame(new ShapeFrame($frame->getX(), $frame->getY() + 100, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation()));
    }
    $pres->save("withActiveX-edited_java.pptm", SaveFormat::Pptm);
    # vezérlők eltávolítása
    $pres->getSlides()->get_Item(0)->getControls()->clear();
    $pres->save("withActiveX-cleared_java.pptm", SaveFormat::Pptm);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Az Aspose.Slides megőrzi az ActiveX vezérlőket olvasás és újramentés során, ha azok nem futtathatók a Java futtatókörnyezetben?**

Igen. Az Aspose.Slides úgy kezeli őket, mint a prezentáció részét, és képes olvasni/modifikálni a tulajdonságaikat és kereteiket; a vezérlők végrehajtása nem szükséges a megőrzésükhöz.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól a prezentációban?**

Az ActiveX vezérlők interaktív, menedzselt elemek (gombok, szövegdobozok, média lejátszó), míg az [OLE](/slides/hu/php-java/manage-ole/) beágyazott alkalmazásobjektumokra (például Excel munkalapra) utal. Ezeket más módon tárolják és kezelik, és különböző tulajdonságmodellel rendelkeznek.

**Működnek az ActiveX események és VBA makrók, ha a fájlt az Aspose.Slides módosította?**

Az Aspose.Slides megőrzi a meglévő jelölőnyelvet és metaadatokat; azonban az események és makrók csak a Windows‑os PowerPointben futnak, ha a biztonsági beállítások engedik. A könyvtár nem hajtja végre a VBA‑t.