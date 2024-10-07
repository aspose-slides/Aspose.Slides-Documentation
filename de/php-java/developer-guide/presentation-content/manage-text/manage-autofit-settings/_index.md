---
title: Autofit-Einstellungen verwalten
type: docs
weight: 30
url: /php-java/manage-autofit-settings/
keywords: "Textbox, Autofit, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Legen Sie die Autofit-Einstellungen für Textfelder in PowerPoint fest"
---

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen eines Textfelds die Einstellung **Form ändern, um Text anzupassen** für das Textfeld – es passt die Größe des Textfelds automatisch an, um sicherzustellen, dass der Text immer darin passt.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint automatisch das Textfeld – erhöht die Höhe –, um mehr Text aufnehmen zu können.
* Wenn der Text im Textfeld kürzer oder kleiner wird, reduziert PowerPoint automatisch das Textfeld – verringert die Höhe –, um überflüssigen Platz zu räumen.

In PowerPoint gibt es 4 wichtige Parameter oder Optionen, die das Autofit-Verhalten für ein Textfeld steuern:

* **Nicht anpassen**
* **Text bei Überlauf verkleinern**
* **Form ändern, um Text anzupassen**
* **Text in der Form umbrechen.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides für PHP über Java bietet ähnliche Optionen – einige Eigenschaften der [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) Klasse –, die es Ihnen ermöglichen, das Autofit-Verhalten für Textfelder in Präsentationen zu steuern.

## **Form ändern, um Text anzupassen**

Wenn Sie möchten, dass der Text in einem Feld immer in dieses Feld passt, nachdem Änderungen am Text vorgenommen wurden, müssen Sie die Option **Form ändern, um Text anzupassen** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (aus der [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) Klasse) auf `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Dieser PHP-Code zeigt Ihnen, wie Sie festlegen, dass ein Text immer in sein Feld in einer PowerPoint-Präsentation passen muss:

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

Wenn der Text länger oder größer wird, wird das Textfeld automatisch angepasst (Höhenerhöhung), um sicherzustellen, dass der gesamte Text darin passt. Wenn der Text kürzer wird, geschieht das Gegenteil.

## **Nicht anpassen**

Wenn Sie möchten, dass ein Textfeld oder eine Form ihre Dimensionen beibehält, unabhängig von den Änderungen, die am enthaltenen Text vorgenommen werden, müssen Sie die Option **Nicht anpassen** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (aus der [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) Klasse) auf `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Dieser PHP-Code zeigt Ihnen, wie Sie festlegen, dass ein Textfeld in einer PowerPoint-Präsentation immer seine Dimensionen beibehalten muss:

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

Wenn der Text zu lang für sein Feld wird, läuft er über.

## **Text bei Überlauf verkleinern**

Wenn ein Text zu lang für sein Feld wird, können Sie über die Option **Text bei Überlauf verkleinern** festlegen, dass die Größe und der Abstand des Textes reduziert werden müssen, um ihn in das Feld einzupassen. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) (aus der [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) Klasse) auf `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser PHP-Code zeigt Ihnen, wie Sie festlegen, dass ein Text bei Überlauf in einer PowerPoint-Präsentation verkleinert werden muss:

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

Wenn die Option **Text bei Überlauf verkleinern** verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird.

{{% /alert %}}

## **Text umbrechen**

Wenn Sie möchten, dass der Text in einer Form innerhalb dieser Form umgebrochen wird, wenn der Text über die Grenzen der Form hinausgeht (nur Breite), müssen Sie den Parameter **Text in der Form umbrechen** verwenden. Um diese Einstellung festzulegen, müssen Sie die Eigenschaft [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) (aus der [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) Klasse) auf `true` setzen.

Dieser PHP-Code zeigt Ihnen, wie Sie die Wrap Text-Einstellung in einer PowerPoint-Präsentation verwenden:

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

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie die Eigenschaft `WrapText` für eine Form auf `False` setzen, läuft der Text, der innerhalb der Form länger wird als die Breite der Form, über die Ränder der Form entlang einer einzigen Linie hinaus.

{{% /alert %}}