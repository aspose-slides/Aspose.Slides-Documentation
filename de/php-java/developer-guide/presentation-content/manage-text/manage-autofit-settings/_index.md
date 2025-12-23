---
title: Verbessern Sie Ihre Präsentationen mit AutoFit in PHP
linktitle: Autofit-Einstellungen
type: docs
weight: 30
url: /de/php-java/manage-autofit-settings/
keywords:
- Textfeld
- Autofit
- Nicht automatisch anpassen
- Text anpassen
- Text verkleinern
- Text umbrechen
- Formgröße anpassen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie AutoFit-Einstellungen in Aspose.Slides für PHP, um die Textanzeige in Ihren PowerPoint- und OpenDocument-Präsentationen zu optimieren und die Lesbarkeit des Inhalts zu verbessern."
---

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen eines Textfelds die Einstellung **Resize shape to fix text** für das Textfeld – es passt die Größe des Textfelds automatisch an, sodass dessen Text immer hineinpasst. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch – erhöht seine Höhe – um mehr Text aufnehmen zu können. 
* Wenn der Text im Textfeld kürzer oder kleiner wird, reduziert PowerPoint das Textfeld automatisch – verringert seine Höhe – um überflüssigen Raum zu entfernen. 

In PowerPoint sind dies die 4 wichtigen Parameter oder Optionen, die das Autofit‑Verhalten für ein Textfeld steuern: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides für PHP über Java bietet ähnliche Optionen – einige Eigenschaften der Klasse [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) –, die es Ihnen ermöglichen, das Autofit‑Verhalten für Textfelder in Präsentationen zu steuern.

## **Formgröße an Text anpassen**

Wenn Sie möchten, dass der Text in einem Feld nach Änderungen immer in dieses Feld passt, müssen Sie die Option **Resize shape to fix text** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) auf `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

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


Wird der Text länger oder größer, wird das Textfeld automatisch (Höhenvergrößerung) angepasst, sodass der gesamte Text hineinpasst. Wird der Text kürzer, geschieht das Gegenteil. 

## **Nicht automatisch anpassen**

Wenn Sie möchten, dass ein Textfeld oder eine Form ihre Abmessungen unabhängig von Änderungen am enthaltenen Text beibehält, müssen Sie die Option **Do not Autofit** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) auf `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

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


Wird der Text zu lang für sein Feld, läuft er über. 

## **Text bei Überlauf verkleinern**

Wenn ein Text zu lang für sein Feld ist, können Sie mit der Option **Shrink text on overflow** festlegen, dass Größe und Abstand des Textes reduziert werden, damit er in das Feld passt. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) auf `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

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
Wird die Option **Shrink text on overflow** verwendet, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird. 
{{% /alert %}}

## **Text umbrechen**

Wenn Sie möchten, dass der Text in einer Form innerhalb dieser Form umbrochen wird, sobald er die Randbreite der Form überschreitet, verwenden Sie den Parameter **Wrap text in shape**. Um diese Einstellung festzulegen, müssen Sie die Eigenschaft [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) auf `true` setzen.

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
Wenn Sie die Eigenschaft `WrapText` für eine Form auf `False` setzen, wird der Text, sobald er länger als die Breite der Form wird, über die Formgrenzen hinaus in einer einzigen Zeile erweitert. 
{{% /alert %}}

## **FAQ**

**Beeinflussen die inneren Ränder des Textrahmens AutoFit?**

Ja. Innenabstände (Padding) verkleinern den nutzbaren Bereich für Text, sodass AutoFit früher greift – Schriftgröße wird reduziert oder die Form früher angepasst. Überprüfen und passen Sie die Ränder an, bevor Sie AutoFit feinjustieren.

**Wie interagiert AutoFit mit manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben erhalten, und AutoFit passt Schriftgröße und Zeilenabstand um sie herum an. Das Entfernen unnötiger Umbrüche reduziert häufig, wie aggressiv AutoFit den Text verkleinern muss.

**Beeinflusst das Ändern der Designschriftart oder das Auslösen einer Schriftartsubstitution die AutoFit-Ergebnisse?**

Ja. Das Ersetzen durch eine Schriftart mit anderen Glyphenmaßen verändert Textbreite und -höhe, was die endgültige Schriftgröße und den Zeilenumbruch ändern kann. Nach jeder Schriftartänderung oder -substitution sollten Sie die Folien erneut prüfen.