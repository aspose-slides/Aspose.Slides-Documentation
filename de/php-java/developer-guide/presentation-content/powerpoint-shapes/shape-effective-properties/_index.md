---
title: Effektive Eigenschaften von Formen
type: docs
weight: 50
url: /php-java/shape-effective-properties/
---

In diesem Thema werden wir **effektive** und **lokale** Eigenschaften besprechen. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In Abschnittseigenschaften auf der Folie des Abschnitts;
1. In der Textstilvorlage der Prototypform auf Layout- oder Masterfolie (wenn die Textrahmenform des Abschnitts eine hat);
1. In den globalen Texteinstellungen der Präsentation;

werden diese Werte als **lokale** Werte bezeichnet. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Wenn eine Anwendung jedoch wissen muss, wie der Abschnitt aussehen soll, verwendet sie **effektive** Werte. Sie können effektive Werte abrufen, indem Sie die Methode **getEffective()** vom lokalen Format verwenden.

Dieser Beispielcode zeigt, wie Sie effektive Werte abrufen können:

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

## **Abrufen effektiver Eigenschaften der Kamera**
Aspose.Slides für PHP über Java ermöglicht es Entwicklern, effektive Eigenschaften der Kamera abzurufen. Zu diesem Zweck wurde die [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Die [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) Schnittstelle stellt ein unveränderliches Objekt dar, das effektive Kamerawerte enthält. Eine Instanz der [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData) Schnittstelle verwendet, die ein [effektives Werte](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) Paar für die [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) Klasse ist.

Dieser Beispielcode zeigt, wie Sie effektive Eigenschaften für die Kamera abrufen können:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effektive Eigenschaften der Kamera =");
    echo("Typ: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Sichtfeld: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Zoom: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Abrufen effektiver Eigenschaften von Licht Rig**
Aspose.Slides für PHP über Java ermöglicht es Entwicklern, effektive Eigenschaften von Licht Rig abzurufen. Zu diesem Zweck wurde die [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Die [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) Schnittstelle stellt ein unveränderliches Objekt dar, das effektive Eigenschaften des Licht Rig enthält. Eine Instanz der [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData) Schnittstelle verwendet, die ein [effektives Werte](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) Paar für die [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) Klasse ist.

Dieser Beispielcode zeigt, wie Sie effektive Eigenschaften von Licht Rig abrufen können:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effektive Eigenschaften des Licht Rigs =");
    echo("Typ: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Richtung: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Abrufen effektiver Eigenschaften der Bevel-Form**
Aspose.Slides für PHP über Java ermöglicht es Entwicklern, effektive Eigenschaften der Bevel-Form abzurufen. Zu diesem Zweck wurde die [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Die [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) Schnittstelle stellt ein unveränderliches Objekt dar, das effektive Eigenschaften der Oberflächenstruktur der Form enthält. Eine Instanz der [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) Schnittstelle wird als Teil der [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)) Schnittstelle verwendet, die ein [effektives Werte](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) Paar für die [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) Klasse ist.

Dieser Beispielcode zeigt, wie Sie effektive Eigenschaften für die Bevel-Form abrufen können:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effektive Eigenschaften der oberen Oberflächenstruktur der Form =");
    echo("Typ: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Breite: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Höhe: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Abrufen effektiver Eigenschaften eines Textrahmens**
Durch die Verwendung von Aspose.Slides für PHP über Java können Sie effektive Eigenschaften eines Textrahmens abrufen. Zu diesem Zweck wurde die [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Sie enthält effektive Formatierungseigenschaften des Textrahmens.

Dieser Beispielcode zeigt, wie Sie effektive Formatierungseigenschaften des Textrahmens abrufen können:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Anker-Typ: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Autofit-Typ: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Vertikaler Texttyp: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Ränder");
    echo("   Links: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Oben: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Rechts: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Unten: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Abrufen effektiver Eigenschaften eines Textstils**
Durch die Verwendung von Aspose.Slides für PHP über Java können Sie effektive Eigenschaften eines Textstils abrufen. Zu diesem Zweck wurde die [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData) Schnittstelle zu Aspose.Slides hinzugefügt. Sie enthält effektive Eigenschaften des Textstils.

Dieser Beispielcode zeigt, wie Sie effektive Eigenschaften des Textstils abrufen können:

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Effektive Absatzformatierung für Stil-Ebene #" . $i . " =");
      echo("Tiefe: " . $effectiveStyleLevel->getDepth());
      echo("Einzug: " . $effectiveStyleLevel->getIndent());
      echo("Ausrichtung: " . $effectiveStyleLevel->getAlignment());
      echo("Schriftausrichtung: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Abrufen des effektiven Schriftgrößenwerts**
Durch die Verwendung von Aspose.Slides für PHP über Java können Sie effektive Eigenschaften der Schriftgröße abrufen. Hier stellen wir einen Code bereit, der zeigt, wie sich der effektive Schriftgrößenwert des Abschnitts ändert, nachdem lokale Schriftgrößenwerte auf verschiedenen Präsentationsstruktur-Ebenen festgelegt wurden:

```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Beispieltext mit erster Portion");
    $portion1 = new Portion(" und zweiter Portion.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Effektive Schriftgröße unmittelbar nach der Erstellung:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Effektive Schriftgröße nach Festlegung der gesamten Präsentationsstandardschriftgröße:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Effektive Schriftgröße nach Festlegung der Standardschriftgröße des Absatzes:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Effektive Schriftgröße nach Festlegung der Schriftgröße der Portion #0:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Effektive Schriftgröße nach Festlegung der Schriftgröße der Portion #1:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Abrufen des effektiven Füllformats für Tabellen**
Durch die Verwendung von Aspose.Slides für PHP über Java können Sie effektive Füllformatierung für verschiedene logische Teile einer Tabelle abrufen. Zu diesem Zweck wurde die [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData) Schnittstelle in Aspose.Slides hinzugefügt. Sie enthält effektive Füllformatierungseigenschaften. Bitte beachten Sie Folgendes: Die Zellformatierung hat immer Vorrang vor der Zeilenformatierung; die Zeile hat Vorrang vor der Spaltenformatierung; und die Spalte hat Vorrang vor der gesamten Tabelle.

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