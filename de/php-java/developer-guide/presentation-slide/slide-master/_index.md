---
title: Folienmaster
type: docs
weight: 70
url: /php-java/slide-master/
keywords: "Folienmaster hinzufügen, PPT-Masterfolie, Folienmaster PowerPoint, Bild zum Folienmaster, Platzhalter, Mehrere Folienmaster, Folienmaster vergleichen, Java, Aspose.Slides für PHP über Java"
description: "Fügen Sie Folienmaster in PowerPoint-Präsentationen hinzu oder bearbeiten Sie sie"
---

## **Was ist ein Folienmaster in PowerPoint**

Ein **Folienmaster** ist eine Folienvorlage, die das Layout, die Stile, das Thema, die Schriftarten, den Hintergrund und andere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) im gleichen Stil und mit der gleichen Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden.

Ein Folienmaster ist nützlich, da er es Ihnen ermöglicht, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster-Mechanismus von PowerPoint.

VBA erlaubt es Ihnen außerdem, einen Folienmaster zu manipulieren und die gleichen in PowerPoint unterstützten Operationen auszuführen: Hintergründe ändern, Formen hinzufügen, das Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Folienmaster zu verwenden und grundlegende Aufgaben mit ihnen auszuführen.

Dies sind grundlegende Folienmaster-Operationen:

- Folienmaster erstellen oder bearbeiten.
- Folienmaster auf Präsentationsfolien anwenden.
- Hintergrund des Folienmasters ändern.
- Ein Bild, Platzhalter, Smart Art usw. zum Folienmaster hinzufügen.

Dies sind fortgeschrittenere Operationen, die den Folienmaster betreffen:

- Folienmaster vergleichen.
- Folienmaster zusammenführen.
- Mehrere Folienmaster anwenden.
- Folie mit Folienmaster in eine andere Präsentation kopieren.
- Duplikate von Folienmastern in Präsentationen finden.
- Folienmaster als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Sie möchten möglicherweise Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ausprobieren, da es eine Live-Implementierung einiger der hier beschriebenen Kernprozesse ist.

{{% /alert %}} 

## **Wie Folienmaster angewendet wird**

Bevor Sie mit einem Folienmaster arbeiten, möchten Sie möglicherweise verstehen, wie sie in Präsentationen verwendet und auf Folien angewendet werden.

* Jede Präsentation hat standardmäßig mindestens einen Folienmaster.
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und diese verwenden, um verschiedene Teile einer Präsentation auf unterschiedliche Weise zu gestalten.

In **Aspose.Slides** wird ein Folienmaster durch den Typ [**IMasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslide/) dargestellt.

Das [Präsentations](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)objekt von Aspose.Slides enthält die [**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--)Liste des Typs [**IMasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/), die eine Liste aller Masterfolien enthält, die in einer Präsentation definiert sind.

Neben CRUD-Operationen enthält die [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) Schnittstelle diese nützlichen Methoden: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) und [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-). Diese Methoden stammen von der grundlegenden Folienklonfunktion. Aber beim Umgang mit Folienmastern erlauben diese Methoden, komplizierte Setups zu implementieren.

Wenn eine neue Folie zu einer Präsentation hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet. Der Folienmaster der vorherigen Folie wird standardmäßig ausgewählt.

**Hinweis**: Präsentationsfolien werden in der [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides--) Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung hinzugefügt. Wenn eine Präsentation nur einen Folienmaster enthält, wird dieser Folienmaster für alle neuen Folien ausgewählt. Dies ist der Grund, warum Sie den Folienmaster nicht für jede neue Folie definieren müssen, die Sie erstellen.

Das Prinzip ist für PowerPoint und Aspose.Slides dasselbe. Zum Beispiel können Sie in PowerPoint, wenn Sie eine neue Präsentation hinzufügen, einfach auf die untere Zeile unter der letzten Folie drücken, und dann wird eine neue Folie (mit dem Folienmaster der letzten Präsentation) erstellt:

![todo:Bildbeschreibung](slide-master_1.jpg)

In Aspose.Slides können Sie die entsprechende Aufgabe mit der [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) Methode unter der [Präsentations](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)klasse durchführen.

## **Folienmaster in der Folienhierarchie**

Die Verwendung von Folienlayouts mit Folienmaster ermöglicht maximale Flexibilität. Ein Folienlayout ermöglicht es Ihnen, all die gleichen Stile wie den Folienmaster (Hintergrund, Schriftarten, Formen usw.) festzulegen. Wenn jedoch mehrere Folienlayouts auf einem Folienmaster kombiniert werden, wird ein neuer Stil erstellt. Wenn Sie ein Folienlayout auf eine einzelne Folie anwenden, können Sie dessen Stil von dem, der vom Folienmaster angewendet wird, ändern.

Der Folienmaster übertrifft alle Setup-Elemente: Folienmaster -> Folienlayout -> Folie:

![todo:Bildbeschreibung](slide-master_2)

Jedes [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) Objekt hat eine [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getLayoutSlides--) Eigenschaft mit einer Liste von Folienlayouts. Ein [Folie](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) Typ hat eine [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getLayoutSlide--) Eigenschaft mit einem Link zu einem auf die Folie angewendeten Folienlayout. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Hinweis" %}}

* In Aspose.Slides sind alle Foliensetup (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die das [**IBaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) Interface implementieren.
* Daher können Folienmaster und Folienlayout dieselben Eigenschaften implementieren, und Sie müssen wissen, wie ihre Werte auf ein [Folie](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) Objekt angewendet werden. Der Folienmaster wird zuerst auf eine Folie angewendet, und dann wird das Folienlayout angewendet. Wenn der Folienmaster und das Folienlayout beide einen Hintergrundwert haben, hat die Folie am Ende den Hintergrund des Folienlayouts.

{{% /alert %}}

## **Was ein Folienmaster umfasst**

Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kernfunktionen des [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getBackground--) Hintergrund der Folie abrufen/einstellen.
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getBodyStyle--) - Textstile des Folienkörpers abrufen/einstellen.
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getShapes--) Alle Formen des Folienmasters abrufen/einstellen (Platzhalter, Bilderrahmen usw.).
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getControls--) ActiveX-Steuerelemente abrufen/einstellen.
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterThemeable#getThemeManager--) - Themenmanager abrufen.
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getHeaderFooterManager--) - Kopf- und Fußzeilenmanager abrufen.

Methoden des Folienmasters:

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getDependingSlides--) - Alle Folien abrufen, die vom Folienmaster abhängig sind.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - Ermöglicht es Ihnen, einen neuen Folienmaster basierend auf dem aktuellen Folienmaster und einem neuen Thema zu erstellen. Der neue Folienmaster wird dann auf alle abhängigen Folien angewendet.

## **Folienmaster abrufen**

In PowerPoint kann auf den Folienmaster über das Menü Ansicht -> Folienmaster zugegriffen werden:

![todo:Bildbeschreibung](slide-master_3.jpg)

Mit Aspose.Slides können Sie auf einen Folienmaster wie folgt zugreifen: 

```php
  $pres = new Presentation();
  try {
    # Gibt Zugriff auf den Master-Folie der Präsentation
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

Das [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) Interface stellt einen Folienmaster dar. Die [Masters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getMasters--) Eigenschaft (die sich auf den Typ [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) bezieht) enthält eine Liste aller Folienmaster, die in der Präsentation definiert sind.

## **Bild zum Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, wird dieses Bild auf allen von diesem Folienmaster abhängigen Folien angezeigt.

Zum Beispiel können Sie das Logo Ihres Unternehmens und einige Bilder auf dem Folienmaster platzieren und dann wieder in den Folienbearbeitungsmodus wechseln. Sie sollten das Bild auf jeder Folie sehen. 

![todo:Bildbeschreibung](slide-master_4.png)

Sie können Bilder zu einem Folienmaster mit Aspose.Slides hinzufügen:

```php
  $pres = new Presentation();
  try {
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pres->getMasters()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Siehe auch" %}} 

Für weitere Informationen zum Hinzufügen von Bildern zu einer Folie siehe den Artikel [Bilderrahmen](/slides/php-java/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Platzhalter zum Folienmaster hinzufügen**

Diese Textfelder sind standardmäßige Platzhalter auf einem Folienmaster: 

* Klicken Sie, um den Master-Titelstil zu bearbeiten

* Master-Textstile bearbeiten

* Zweite Ebene

* Dritte Ebene 

Sie erscheinen auch auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf einem Folienmaster bearbeiten, und die Änderungen werden automatisch auf die Folien angewendet.

In PowerPoint können Sie einen Platzhalter über den Pfad Folienmaster -> Platzhalter einfügen hinzufügen:

![todo:Bildbeschreibung](slide-master_5.png)

Betrachten wir ein komplizierteres Beispiel für Platzhalter mit Aspose.Slides. Betrachten Sie eine Folie mit Platzhaltern, die vom Folienmaster Vorlage stammen:

![todo:Bildbeschreibung](slide-master_6.png)

Wir möchten die Formatierung von Titel und Untertitel auf dem Folienmaster wie folgt ändern:

![todo:Bildbeschreibung](slide-master_7.png)

Zuerst rufen wir den Inhalt des Titelplatzhalters vom Folienmaster-Objekt ab und verwenden dann das `PlaceHolder.FillFormat` Feld: 

```php

```

Der Titelstil und die Formatierung ändern sich für alle Folien, die auf dem Folienmaster basieren:

![todo:Bildbeschreibung](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}} 

* [Platzhaltertext festlegen](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [Textformatierung](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}

## **Hintergrund auf Folienmaster ändern**

Wenn Sie die Hintergrundfarbe eines Masterfolien ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser PHP-Code demonstriert die Operation:

```php
  $pres = new Presentation();
  try {
    $master = $pres->getMasters()->get_Item(0);
    $master->getBackground()->setType(BackgroundType::OwnBackground);
    $master->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $master->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="Siehe auch" %}} 

- [Präsentationshintergrund](https://docs.aspose.com/slides/php-java/presentation-background/)

- [Präsentationsthema](https://docs.aspose.com/slides/php-java/presentation-theme/)

{{% /alert %}}

## **Folienmaster in eine andere Präsentation klonen**

Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) Methode der Zielpräsentation zusammen mit einem übergebenen Folienmaster auf. Dieser PHP-Code zeigt Ihnen, wie Sie einen Folienmaster in eine andere Präsentation klonen:

```php
  $presSource = new Presentation();
  $presTarget = new Presentation();
  try {
    $master = $presTarget->getMasters()->addClone($presSource->getMasters()->get_Item(0));
  } finally {
    if (!java_is_null($presSource)) {
      $presSource->dispose();
    }
  }
```

## **Mehrere Folienmaster zur Präsentation hinzufügen**

Aspose.Slides ermöglicht es Ihnen, mehrere Folienmaster und Folienlayouts in eine beliebige Präsentation hinzuzufügen. Dies ermöglicht es Ihnen, Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf viele Arten einzurichten.

In PowerPoint können Sie neue Folienmaster und -layouts (aus dem Menü "Folienmaster") wie folgt hinzufügen:

![todo:Bildbeschreibung](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Folienmaster hinzufügen, indem Sie die [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) Methode aufrufen:

```php
  # Fügt eine neue Masterfolie hinzu
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);

```

## **Folienmaster vergleichen**

Ein Folienmaster implementiert das [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) Interface, das die [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) Methode enthält, die dann verwendet werden kann, um Folien zu vergleichen. Es gibt `true` für Folienmaster zurück, die in Struktur und statischem Inhalt identisch sind.

Zwei Folienmaster sind gleich, wenn ihre Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt keine eindeutigen Identifikatorwerte (z. B. SlideId) und dynamischen Inhalt (z. B. den aktuellen Datumswert im Platzhalter "Datum"). 

## **Folienmaster als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht es Ihnen, einen Folienmaster als Standardansicht für eine Präsentation festzulegen. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen.

Dieser Code zeigt Ihnen, wie Sie einen Folienmaster als Standardansicht einer Präsentation festlegen:

```php
  # Instanziiert eine Präsentationsklasse, die die Präsentationsdatei repräsentiert
  $presentation = new Presentation();
  try {
    # Setzt die Standardansicht auf Folienmasteransicht
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Speichert die Präsentation
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Ungenutzten Folienmaster entfernen**

Aspose.Slides bietet die [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) Methode (aus der [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) Klasse), um unerwünschte und ungenutzte Folienmaster zu löschen. Dieser PHP-Code zeigt Ihnen, wie Sie einen Folienmaster aus einer PowerPoint-Präsentation entfernen:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```