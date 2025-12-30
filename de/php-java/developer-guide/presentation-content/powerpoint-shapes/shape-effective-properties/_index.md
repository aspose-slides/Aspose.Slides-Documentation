---
title: Ermitteln von effektiven Formeigenschaften aus Präsentationen in PHP
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/php-java/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Lichtanlage
- Abschrägungsform
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für PHP via Java effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint-Darstellung zu gewährleisten."
---

In diesem Thema besprechen wir **effective** und **local** Eigenschaften. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In Abschnittseigenschaften auf der Folie des Abschnitts;
1. Im Textstil der Prototypform auf Layout‑ oder Masterfolie (falls die Textfeldform des Abschnitts einen hat);
1. In den globalen Texteinstellungen der Präsentation;

werden diese Werte **local** Werte genannt. Auf jeder Ebene können **local** Werte definiert oder weggelassen werden. Wenn jedoch eine Anwendung wissen muss, wie der Abschnitt aussehen soll, verwendet sie **effective** Werte. Sie können **effective** Werte erhalten, indem Sie die **getEffective()**‑Methode des lokalen Formats verwenden.

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
Aspose.Slides für PHP via Java ermöglicht Entwicklern, die effektiven Eigenschaften der Kamera abzurufen. Zu diesem Zweck wurde die Schnittstelle [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) zu Aspose.Slides hinzugefügt. Die Schnittstelle [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz der [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData) Schnittstelle verwendet, die ein [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) darstellt.

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


## **Effektive Eigenschaften eines Light Rigs abrufen**
Aspose.Slides für PHP via Java ermöglicht Entwicklern, die effektiven Eigenschaften eines Light Rigs abzurufen. Zu diesem Zweck wurde die Schnittstelle [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) zu Aspose.Slides hinzugefügt. Die [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) Schnittstelle stellt ein unveränderliches Objekt dar, das effektive Light‑Rig‑Eigenschaften enthält. Eine Instanz der [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData) Schnittstelle verwendet, die ein [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) darstellt.

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


## **Effektive Eigenschaften einer Abschrägung (Bevel) abrufen**
Aspose.Slides für PHP via Java ermöglicht Entwicklern, die effektiven Eigenschaften einer Abschrägung (Bevel) abzurufen. Zu diesem Zweck wurde die [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Die [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) Schnittstelle stellt ein unveränderliches Objekt dar, das effektive Reliefeigenschaften der Form enthält. Eine Instanz der [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)) Schnittstelle verwendet, die ein [effective values](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) Paar für die Klasse [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) darstellt.

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
Mit Aspose.Slides für PHP via Java können Sie die effektiven Eigenschaften eines Textfelds abrufen. Zu diesem Zweck wurde die [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Sie enthält effektive Formatierungseigenschaften des Textfelds.

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
Mit Aspose.Slides für PHP via Java können Sie die effektiven Eigenschaften eines Textstils abrufen. Zu diesem Zweck wurde die [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Sie enthält effektive Eigenschaften des Textstils.

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
Mit Aspose.Slides für PHP via Java können Sie die effektiven Eigenschaften der Schriftgröße abrufen. Hier stellen wir einen Code bereit, der zeigt, wie sich der effektive Schriftgradwert eines Abschnitts ändert, nachdem lokale Schriftgradwerte auf verschiedenen Ebenen der Präsentationsstruktur festgelegt wurden:

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


## **Das effektive Füllformat für eine Tabelle abrufen**
Mit Aspose.Slides für PHP via Java können Sie das effektive Füllformat für verschiedene logische Teile einer Tabelle abrufen. Zu diesem Zweck wurde die [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData) Schnittstelle in Aspose.Slides hinzugefügt. Sie enthält effektive Füllformatierungseigenschaften. Bitte beachten Sie: Zellformatierung hat immer Vorrang vor Zeilenformatierung; Zeilenformatierung hat Vorrang vor Spaltenformatierung; und Spaltenformatierung hat Vorrang vor der gesamten Tabelle.

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

EffectiveData‑Objekte sind unveränderliche Schnappschüsse der zum Zeitpunkt des Aufrufs berechneten Werte. Ändern Sie lokale oder vererbte Einstellungen der Form, rufen Sie die effektiven Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern der Layout‑/Master‑Folien auf bereits abgerufene effektive Eigenschaften aus?**

Ja, jedoch erst, nachdem Sie sie erneut ausgelesen haben. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht selbst – fordern Sie es nach einer Änderung des Layouts oder Masters erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Änderungen müssen an den lokalen Formatierungsobjekten (Form/Text/3D usw.) vorgenommen werden, anschließend können die effektiven Werte erneut abgefragt werden.

**Was geschieht, wenn eine Eigenschaft weder auf Form‑Ebene, noch im Layout/Master oder in den globalen Einstellungen festgelegt ist?**

Der effektive Wert wird durch den Standardmechanismus (PowerPoint/Aspose.Slides‑Standardeinstellungen) bestimmt. Dieser ermittelte Wert wird Teil des EffectiveData‑Snapshots.

**Kann ich aus einem effektiven Schriftwert ableiten, welche Ebene die Größe bzw. den Schriftschnitt bereitgestellt hat?**

Nicht direkt. EffectiveData liefert nur den endgültigen Wert. Um die Quelle zu finden, prüfen Sie die lokalen Werte auf Abschnitt/Absatz/Textfeld‑Ebene sowie die Textstile im Layout/Master/Präsentation, um zu sehen, wo die erste explizite Definition vorkommt.

**Warum sehen EffectiveData‑Werte manchmal identisch zu den lokalen aus?**

Weil der lokale Wert letztlich endgültig war (keine höhere Vererbung nötig). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann ausschließlich lokale?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerendert“ Ergebnis nach Anwendung aller Vererbungen benötigen (z. B. zum Angleichen von Farben, Einzügen oder Größen). Wenn Sie die Formatierung auf einer bestimmten Ebene ändern wollen, passen Sie lokale Eigenschaften an und lesen Sie bei Bedarf EffectiveData erneut, um das Ergebnis zu verifizieren.