---
title: Verwalten von Hoch- und Tiefgestelltem Text in Präsentationen mit PHP
linktitle: Hoch- und Tiefgestellt
type: docs
weight: 80
url: /de/php-java/superscript-and-subscript/
keywords:
- hochgestellt
- tiefgestellt
- hochgestellt hinzufügen
- tiefgestellt hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Meistern Sie Hoch- und Tiefgestellt-Formatierung in Aspose.Slides für PHP über Java und heben Sie Ihre Präsentationen mit professioneller Textformatierung für maximale Wirkung."
---

## **Verwalten von Hoch- und Tiefgestelltem Text**
Sie können Hoch- und Tiefgestellt‑Text in jedem Absatzabschnitt hinzufügen. Um Hoch‑ oder Tiefgestellt‑Text in einem Aspose.Slides‑Textfeld hinzuzufügen, muss die [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) Methode der Klasse [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat) verwendet werden.

Diese Eigenschaft gibt den Hoch‑ bzw. Tiefgestellt‑Text zurück oder legt ihn fest (Wert von -100% (Tiefgestellt) bis 100% (Hochgestellt)). Zum Beispiel:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Rufen Sie die Referenz einer Folie über deren Index ab.
- Fügen Sie der Folie ein [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) vom Typ [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) hinzu.
- Greifen Sie auf das mit dem [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) verbundene [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) zu.
- Löschen Sie vorhandene Absätze
- Erstellen Sie ein neues Absatzobjekt zum Halten von Hochgestellt‑Text und fügen Sie es der [IParagraphs collection](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--) des [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) hinzu.
- Erstellen Sie ein neues Portion‑Objekt
- Setzen Sie die Escapement‑Eigenschaft der Portion auf einen Wert zwischen 0 und 100, um Hochgestellt hinzuzufügen. (0 bedeutet kein Hochgestellt)
- Legen Sie für die [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) Text fest und fügen Sie diesen dann zur Portion‑Sammlung des Absatzes hinzu.
- Erstellen Sie ein neues Absatzobjekt zum Halten von Tiefgestellt‑Text und fügen Sie es der IParagraphs‑Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portion‑Objekt
- Setzen Sie die Escapement‑Eigenschaft der Portion auf einen Wert zwischen 0 und -100, um Tiefgestellt hinzuzufügen. (0 bedeutet kein Tiefgestellt)
- Legen Sie für die [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) Text fest und fügen Sie diesen dann zur Portion‑Sammlung des Absatzes hinzu.
- Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte wird unten gezeigt.
```php
  # Instanziieren einer Presentation-Klasse, die eine PPTX darstellt
  $pres = new Presentation();
  try {
    # Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Textfeld erstellen
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Absatz für hochgestellten Text erstellen
    $superPar = new Paragraph();
    # Portion mit normalem Text erstellen
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Portion mit hochgestelltem Text erstellen
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Absatz für tiefgestellten Text erstellen
    $paragraph2 = new Paragraph();
    # Portion mit normalem Text erstellen
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Portion mit tiefgestelltem Text erstellen
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Absätze zum Textfeld hinzufügen
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wird Hoch- und Tiefgestellt-Text beim Exportieren nach PDF oder anderen Formaten erhalten bleiben?**

Ja, Aspose.Slides bewahrt die Hoch- und Tiefgestellt-Formatierung beim Exportieren von Präsentationen nach PDF, PPT/PPTX, Bildern und anderen unterstützten Formaten. Die spezielle Formatierung bleibt in allen Ausgabedateien erhalten.

**Kann Hoch- und Tiefgestellt-Text mit anderen Formatierungsstilen wie Fett oder Kursiv kombiniert werden?**

Ja, Aspose.Slides ermöglicht das Mischen verschiedener Textstile innerhalb einer einzelnen Portion. Sie können Fett, Kursiv, Unterstreichung aktivieren und gleichzeitig Hoch- oder Tiefgestellt anwenden, indem Sie die entsprechenden Eigenschaften in [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) konfigurieren.

**Funktioniert die Hoch- und Tiefgestellt-Formatierung für Text in Tabellen, Diagrammen oder SmartArt?**

Ja, Aspose.Slides unterstützt die Formatierung in den meisten Objekten, einschließlich Tabellen und Diagrammelementen. Beim Arbeiten mit SmartArt müssen Sie auf die entsprechenden Elemente (wie [SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/)) und deren Textcontainer zugreifen und dann die Eigenschaften von [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) in ähnlicher Weise konfigurieren.