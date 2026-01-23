---
title: Verwalten von Hoch- und Tiefgestelltem Text in Präsentationen mit PHP
linktitle: Hoch- und Tiefgestellt
type: docs
weight: 80
url: /de/php-java/superscript-and-subscript/
keywords:
- Hochgestellt
- Tiefgestellt
- Hochgestellt hinzufügen
- Tiefgestellt hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Meistern Sie Hoch- und Tiefgestelltes in Aspose.Slides für PHP über Java und heben Sie Ihre Präsentationen mit professioneller Textformatierung für maximale Wirkung hervor."
---

## **Hoch- und Tiefgestellten Text verwalten**
Sie können hoch- und tiefgestellten Text in jedem Absatzteil hinzufügen. Um hoch- oder tiefgestellten Text im Text‑Frame von Aspose.Slides hinzuzufügen, muss die [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement)‑Methode der Klasse [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat) verwendet werden.

Diese Eigenschaft gibt den hoch- oder tiefgestellten Text zurück oder legt ihn fest (Wert von -100 % (tiefgestellt) bis 100 % (hochgestellt)). Zum Beispiel:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Erhalten Sie die Referenz einer Folie über deren Index.
- Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) vom Typ [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) hinzu.
- Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) zu, das mit der [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) verknüpft ist.
- Löschen Sie vorhandene Paragraphs
- Erstellen Sie ein neues Absatzobjekt, das hochgestellten Text enthält, und fügen Sie es der [IParagraphs collection](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) des [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) hinzu.
- Erstellen Sie ein neues Portion‑Objekt
- Setzen Sie die Escapement‑Eigenschaft der Portion auf einen Wert zwischen 0 und 100, um hochgestellten Text hinzuzufügen. (0 bedeutet kein Hochstellen)
- Legen Sie für die [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) einen Text fest und fügen Sie diese dann der Portion‑Sammlung des Absatzes hinzu.
- Erstellen Sie ein neues Absatzobjekt, das tiefgestellten Text enthält, und fügen Sie es der IParagraphs‑Sammlung des ITextFrame hinzu.
- Erstellen Sie ein neues Portion‑Objekt
- Setzen Sie die Escapement‑Eigenschaft der Portion auf einen Wert zwischen 0 und -100, um tiefgestellten Text hinzuzufügen. (0 bedeutet kein Tiefstellen)
- Legen Sie für die [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) einen Text fest und fügen Sie diese dann der Portion‑Sammlung des Absatzes hinzu.
- Speichern Sie die Präsentation als PPTX‑Datei.

Die Implementierung der obigen Schritte ist unten angegeben.
```php
  # Instanziieren Sie eine Presentation-Klasse, die eine PPTX darstellt
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

**Wird hoch- und tiefgestellter Text beim Exportieren in PDF oder andere Formate beibehalten?**

Ja, Aspose.Slides behält die hoch- und tiefgestellte Formatierung beim Exportieren von Präsentationen in PDF, PPT/PPTX, Bilder und andere unterstützte Formate korrekt bei. Die spezielle Formatierung bleibt in allen Ausgabedateien erhalten.

**Kann hoch- und tiefgestellter Text mit anderen Formatierungsstilen wie Fett oder Kursiv kombiniert werden?**

Ja, Aspose.Slides ermöglicht das Mischen verschiedener Textstile innerhalb einer einzelnen Portion. Sie können Fett, Kursiv, Unterstreichung aktivieren und gleichzeitig hoch- oder tiefgestellten Text anwenden, indem Sie die entsprechenden Eigenschaften in [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) konfigurieren.

**Funktioniert die hoch- und tiefgestellte Formatierung für Text in Tabellen, Diagrammen oder SmartArt?**

Ja, Aspose.Slides unterstützt die Formatierung in den meisten Objekten, einschließlich Tabellen und Diagrammelementen. Beim Arbeiten mit SmartArt müssen Sie auf die jeweiligen Elemente (wie [SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/)) und deren Textcontainer zugreifen und dann die [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/)‑Eigenschaften in ähnlicher Weise konfigurieren.