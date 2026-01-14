---
title: Ermitteln von effektiven Formeigenschaften aus Präsentationen in PHP
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/php-java/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Licht Rig
- Fasenform
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie, wie Aspose.Slides für PHP via Java effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint-Darstellung zu gewährleisten."
---

In diesem Thema besprechen wir **effektive** und **lokale** Eigenschaften. Wenn wir Werte direkt auf diesen Ebenen setzen

1. In Abschnittseigenschaften auf der Folie des Abschnitts;
1. Im Textstil der Prototypform auf Layout- oder Master-Folie (falls die Textfeld-Form des Abschnitts einen hat);
1. In den globalen Texteinstellungen der Präsentation;

werden diese Werte **lokale** Werte genannt. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Wenn jedoch eine Anwendung wissen muss, wie der Abschnitt aussehen soll, verwendet sie **effektive** Werte. Sie können effektive Werte erhalten, indem Sie die **getEffective()**-Methode des lokalen Formats verwenden.

Dieser Beispielcode zeigt, wie man effektive Werte erhält:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat::getEffective();
    $localPortionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat::getEffective();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Effektive Eigenschaften einer Kamera abrufen**
Aspose.Slides für PHP via Java ermöglicht Entwicklern, die effektiven Eigenschaften der Kamera abzurufen. Zu diesem Zweck wurde die Klasse `ICameraEffectiveData` zu Aspose.Slides hinzugefügt. Die Klasse `ICameraEffectiveData` stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz der Klasse `ICameraEffectiveData` wird als Teil der Klasse `IThreeDFormatEffectiveData` verwendet, die ein [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/)-Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) ist.

Dieser Beispielcode zeigt, wie man effektive Eigenschaften für die Kamera abruft:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective camera properties =");
    echo("Type: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Field of view: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Zoom: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Effektive Eigenschaften eines Light Riggs abrufen**
Aspose.Slides für PHP via Java ermöglicht Entwicklern, die effektiven Eigenschaften des Light Rig abzurufen. Zu diesem Zweck wurde die Klasse `ILightRigEffectiveData` zu Aspose.Slides hinzugefügt. Die Klasse `ILightRigEffectiveData` stellt ein unveränderliches Objekt dar, das effektive Light-Rig-Eigenschaften enthält. Eine Instanz der Klasse `ILightRigEffectiveData` wird als Teil der Klasse `IThreeDFormatEffectiveData` verwendet, die ein [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/)-Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) ist.

Dieser Beispielcode zeigt, wie man effektive Eigenschaften des Light Rig abruft:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective light rig properties =");
    echo("Type: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Direction: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Effektive Eigenschaften einer Abschrägungsform abrufen**
Aspose.Slides für PHP via Java ermöglicht Entwicklern, die effektiven Eigenschaften einer Bevel Shape abzurufen. Zu diesem Zweck wurde die Klasse `IShapeBevelEffectiveData` zu Aspose.Slides hinzugefügt. Die Klasse `IShapeBevelEffectiveData` stellt ein unveränderliches Objekt dar, das effektive Relief-Eigenschaften der Form enthält. Eine Instanz der Klasse `IShapeBevelEffectiveData` wird als Teil der Klasse `IThreeDFormatEffectiveData` verwendet, die ein [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/geteffective/)-Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) ist.

Dieser Beispielcode zeigt, wie man effektive Eigenschaften für die Bevel Shape abruft:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective shape's top face relief properties =");
    echo("Type: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Width: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Height: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Effektive Eigenschaften eines Textfelds abrufen**
Mit Aspose.Slides für PHP via Java können Sie die effektiven Eigenschaften eines Textfelds abrufen. Zu diesem Zweck wurde die Klasse `ITextFrameFormatEffectiveData` zu Aspose.Slides hinzugefügt. Sie enthält effektive Formatierungseigenschaften für Textfelder.

Dieser Beispielcode zeigt, wie man effektive Formatierungseigenschaften für ein Textfeld abruft:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Anchoring type: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Autofit type: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Text vertical type: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Margins");
    echo("   Left: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Top: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Right: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Bottom: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Effektive Eigenschaften eines Textstils abrufen**
Mit Aspose.Slides für PHP via Java können Sie die effektiven Eigenschaften eines Textstils abrufen. Zu diesem Zweck wurde die Klasse `ITextStyleEffectiveData` zu Aspose.Slides hinzugefügt. Sie enthält effektive Textstileigenschaften.

Dieser Beispielcode zeigt, wie man effektive Textstileigenschaften abruft:
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Effective paragraph formatting for style level #" . $i . " =");
      echo("Depth: " . $effectiveStyleLevel->getDepth());
      echo("Indent: " . $effectiveStyleLevel->getIndent());
      echo("Alignment: " . $effectiveStyleLevel->getAlignment());
      echo("Font alignment: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Den effektiven Schriftgradwert abrufen**
Mit Aspose.Slides für PHP via Java können Sie die effektiven Eigenschaften der Schriftgröße abrufen. Hier stellen wir einen Code bereit, der zeigt, dass sich der effektive Schriftgradwert eines Abschnitts ändert, nachdem lokale Schriftgradwerte auf verschiedenen Ebenen der Präsentationsstruktur gesetzt wurden:
```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Sample text with first portion");
    $portion1 = new Portion(" and second portion.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Effective font height just after creation:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Effective font height after setting entire presentation default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Effective font height after setting paragraph default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Effective font height after setting portion #0 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Effective font height after setting portion #1 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Den effektiven Füllformat für eine Tabelle abrufen**
Mit Aspose.Slides für PHP via Java können Sie das effektive Füllformat für verschiedene logische Teile einer Tabelle abrufen. Zu diesem Zweck wurde die Klasse `ICellFormatEffectiveData` zu Aspose.Slides hinzugefügt. Sie enthält effektive Füllformatierungs-Eigenschaften. Bitte beachten Sie: Zellenformatierung hat immer Vorrang vor Zeilenformatierung; Zeilen haben Vorrang vor Spalten; und Spalten haben Vorrang vor der gesamten Tabelle.
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $tableFormatEffective = $tbl->getTableFormat()->getEffective();
    $rowFormatEffective = $tbl->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnFormatEffective = $tbl->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellFormatEffective = $tbl->get_Item(0, 0)->getCellFormat()->getEffective();
    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wie kann ich erkennen, dass ich einen „Snapshot“ und kein „Live‑Objekt“ erhalten habe, und wann sollte ich effektive Eigenschaften erneut auslesen?**

EffectiveData‑Objekte sind unveränderliche Snapshots der zum Aufrufzeitpunkt berechneten Werte. Wenn Sie lokale oder geerbte Einstellungen der Form ändern, rufen Sie die effektiven Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern des Layout‑/Master‑Folien auf bereits abgerufene effektive Eigenschaften aus?**

Ja, jedoch erst, nachdem Sie sie erneut ausgelesen haben. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht selbst – fordern Sie es nach einer Änderung des Layouts oder Masters erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Nehmen Sie Änderungen in den lokalen Formatierungsobjekten (Form/Text/3D usw.) vor und holen Sie anschließend die effektiven Werte erneut.

**Was passiert, wenn eine Eigenschaft weder auf Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen gesetzt ist?**

Der effektive Wert wird durch den Standardmechanismus (PowerPoint/Aspose.Slides‑Standards) bestimmt. Dieser aufgelöste Wert wird Teil des EffectiveData‑Snapshots.

**Kann ich anhand eines effektiven Schriftwerts erkennen, welche Ebene die Größe oder die Schriftart bereitgestellt hat?**

Nicht direkt. EffectiveData liefert den endgültigen Wert. Um die Quelle zu finden, prüfen Sie die lokalen Werte im Abschnitt/Absatz/Textfeld und die Textstile im Layout/Master/der Präsentation, um zu sehen, wo die erste explizite Definition erscheint.

**Warum sehen EffectiveData‑Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich final war (keine höhere Vererbung nötig war). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur lokale?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerenderte“ Ergebnis nach Anwendung aller Vererbungen benötigen (z. B. zum Angleichen von Farben, Einzügen oder Größen). Wenn Sie die Formatierung auf einer bestimmten Ebene ändern müssen, passen Sie die lokalen Eigenschaften an und lesen Sie ggf. anschließend EffectiveData erneut, um das Ergebnis zu prüfen.