---
title: Verwalten von Folienmastern in Präsentationen in PHP
linktitle: Folienmaster
type: docs
weight: 70
url: /de/php-java/slide-master/
keywords:
- Folienmaster
- Masterfolie
- PPT-Masterfolie
- mehrere Masterfolien
- Masterfolien vergleichen
- Hintergrund
- Platzhalter
- Masterfolie klonen
- Masterfolie kopieren
- Masterfolie duplizieren
- unbenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für PHP über Java: Erstellen, Bearbeiten und Anwenden von Layouts, Designs und Platzhaltern auf PPT, PPTX und ODP mit prägnanten Beispielen."
---

## **Was ist ein Folienmaster in PowerPoint**

Ein **Folienmaster** ist eine Folienvorlage, die Layout, Stile, Design, Schriftarten, Hintergrund und weitere Eigenschaften für Folien einer Präsentation definiert. Wenn Sie für Ihr Unternehmen eine Präsentation (oder eine Reihe von Präsentationen) mit einheitlichem Stil und einheitlicher Vorlage erstellen möchten, können Sie einen Folienmaster verwenden.  

Ein Folienmaster ist nützlich, weil er es Ihnen ermöglicht, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster‑Mechanismus von PowerPoint.  

VBA ermöglicht ebenfalls die Manipulation eines Folienmasters und das Ausführen derselben in PowerPoint unterstützten Vorgänge: Hintergründe ändern, Formen hinzufügen, Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Folienmaster zu nutzen und grundlegende Vorgänge damit durchzuführen.  

Dies sind grundlegende Folienmaster‑Operationen:

- Erstellen oder **Slide Master**.
- Folienmaster auf Präsentationsfolien anwenden.
- Hintergrund des Folienmasters ändern. 
- Ein Bild, einen Platzhalter, SmartArt usw. zum Folienmaster hinzufügen.

Dies sind weiterführende Operationen, die Folienmaster betreffen: 

- Folienmaster vergleichen.
- Folienmaster zusammenführen.
- Mehrere Folienmaster anwenden.
- Folie mit Folienmaster in eine andere Präsentation kopieren.
- Doppelte Folienmaster in Präsentationen finden.
- Folienmaster als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Möglicherweise möchten Sie Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ausprobieren, da er eine Live‑Implementierung einiger der hier beschriebenen Kernprozesse bietet.

{{% /alert %}} 


## **Wie ein Folienmaster angewendet wird**

Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie er in Präsentationen verwendet und auf Folien angewendet wird. 

* Jede Präsentation enthält standardmäßig mindestens einen Folienmaster. 
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation unterschiedlich zu gestalten. 

In **Aspose.Slides** wird ein Folienmaster durch den Typ [**MasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) repräsentiert.

Das [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Objekt von Aspose.Slides enthält die [**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters)-Liste des Typs [**MasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), die eine Liste aller in einer Präsentation definierten Masterfolien enthält.

Neben CRUD‑Operationen enthält die Klasse [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) nützliche Methoden: [**addClone(LayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/#addClone) und [**insertClone(int index, MasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/#insertClone). Diese Methoden stammen von der grundlegenden Folienklon‑Funktion, erlauben jedoch bei Folienmastern komplexe Setups.

Wenn einer Präsentation eine neue Folie hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet. Standardmäßig wird der Folienmaster der vorherigen Folie ausgewählt. 

**Hinweis**: Präsentationsfolien werden in der [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides)-Liste gespeichert, und jede neue Folie wird per Default am Ende der Sammlung eingefügt. Enthält eine Präsentation nur einen Folienmaster, wird dieser für alle neuen Folien verwendet. Dadurch müssen Sie den Folienmaster nicht für jede neue Folie explizit festlegen.

Das Prinzip ist für PowerPoint und Aspose.Slides identisch. In PowerPoint können Sie beispielsweise am unteren Rand der letzten Folie klicken, um eine neue Folie (mit dem Folienmaster der letzten Folie) zu erzeugen:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie dieselbe Aufgabe mit der Methode [addClone(Slide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) durchführen.


## **Folienmaster in der Folienhierarchie**

Die Kombination von Folienlayouts mit dem Folienmaster bietet maximale Flexibilität. Ein Folienlayout erlaubt es Ihnen, dieselben Stile wie beim Folienmaster (Hintergrund, Schriftarten, Formen usw.) festzulegen. Werden mehrere Folienlayouts auf einem Folienmaster kombiniert, entsteht ein neuer Stil. Wenn Sie ein Folienlayout auf eine einzelne Folie anwenden, können Sie dessen Stil vom Folienmaster‑Stil abweichen lassen.

Der Folienmaster hat Vorrang vor allen anderen Einstellungen: Folienmaster → Folienlayout → Folie:

![todo:image_alt_text](slide-master_2)



Jedes [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide)-Objekt besitzt die Eigenschaft [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getLayoutSlides) mit einer Liste von Folienlayouts. Ein [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide)-Typ hat die Eigenschaft [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/Slide/#getLayoutSlide), die auf das auf die Folie angewandte Folienlayout verweist. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Note" %}}

* In Aspose.Slides sind alle Folieneinstellungen (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die von der Klasse [**BaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) erben.
* Deshalb können Folienmaster und Folienlayout dieselben Eigenschaften implementieren, und Sie müssen wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide)-Objekt angewendet werden. Der Folienmaster wird zuerst auf eine Folie angewendet, danach das Folienlayout. Haben sowohl Folienmaster als auch Folienlayout einen Hintergrundwert, erhält die Folie den Hintergrund des Folienlayouts.

{{% /alert %}}


## **Inhalte eines Folienmasters**

Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kern‑Eigenschaften von [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/):

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getBackground) – Hintergrund der Folie holen/setzen.
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getBodyStyle) – Textstile des Folienkörpers holen/setzen.
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getShapes) – Alle Formen des Folienmasters (Platzhalter, Bildrahmen usw.) holen/setzen.
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getControls) – ActiveX‑Steuerelemente holen/setzen.
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/#getThemeManager) – Theme‑Manager holen.
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getHeaderFooterManager) – Header‑ und Footer‑Manager holen.

Methoden des Folienmasters:

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getDependingSlides) – Alle Folien holen, die vom Folienmaster abhängen.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#applyExternalThemeToDependingSlides) – Erlaubt das Erstellen eines neuen Folienmasters basierend auf dem aktuellen Folienmaster und einem neuen Theme. Der neue Folienmaster wird anschließend auf alle abhängigen Folien angewendet.


## **Einen Folienmaster abrufen**

In PowerPoint kann der Folienmaster über das Menü Ansicht → Folienmaster aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)



Mit Aspose.Slides greifen Sie wie folgt auf einen Folienmaster zu: 
```php
  $pres = new Presentation();
  try {
    # Gibt Zugriff auf die Masterfolie der Präsentation
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


Die Klasse [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide) repräsentiert einen Folienmaster. Die Methode [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getMasters) (bezogen auf den Typ [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection)) gibt eine Liste aller in der Präsentation definierten Folienmaster zurück. 


## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie einem Folienmaster ein Bild hinzufügen, erscheint dieses Bild auf allen Folien, die von diesem Master abhängen. 

Beispielsweise können Sie das Firmenlogo und weitere Bilder auf dem Folienmaster platzieren und anschließend in den Folien‑Bearbeitungsmodus zurückkehren. Das Bild sollte dann auf jeder Folie sichtbar sein. 

![todo:image_alt_text](slide-master_4.png)

Bilder können Sie mit Aspose.Slides zu einem Folienmaster hinzufügen:
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


{{% alert color="primary" title="See also" %}} 

Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Picture Frame](/slides/de/php-java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Einen Platzhalter zu einem Folienmaster hinzufügen**

Diese Textfelder sind Standard‑Platzhalter auf einem Folienmaster: 

* Click to edit Master title style

* Edit Master text styles

* Second level

* Third level 

Sie erscheinen auch auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf dem Folienmaster bearbeiten, und die Änderungen werden automatisch auf die Folien angewendet. 

In PowerPoint können Sie einen Platzhalter über den Pfad Folienmaster → Platzhalter einfügen:



![todo:image_alt_text](slide-master_5.png)



Ein komplexeres Beispiel für Platzhalter mit Aspose.Slides betrachten wir nun. Angenommen, eine Folie enthält Platzhalter, die aus dem Folienmaster stammen:



![todo:image_alt_text](slide-master_6.png)



Wir möchten die Titel‑ und Untertitel‑Formatierung im Folienmaster wie folgt ändern:

![todo:image_alt_text](slide-master_7.png)



Zuerst holen wir den Inhalt des Titel‑Platzhalters aus dem Folienmaster‑Objekt und verwenden dann das Feld `PlaceHolder.FillFormat`:
```php

```


Der Titel‑Stil und die Formatierung werden für alle Folien, die auf dem Folienmaster basieren, geändert:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}


## **Den Hintergrund eines Folienmasters ändern**

Wenn Sie die Hintergrundfarbe einer Master‑Folien ändern, erhalten alle normalen Folien der Präsentation die neue Farbe. Der folgende PHP‑Code demonstriert den Vorgang:
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


{{% alert color="primary" title="See also" %}} 

- [Presentation Background](https://docs.aspose.com/slides/php-java/presentation-background/)

- [Presentation Theme](https://docs.aspose.com/slides/php-java/presentation-theme/)

{{% /alert %}}

## **Einen Folienmaster in eine andere Präsentation klonen**

Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die Methode [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) der Zielpräsentation auf und übergeben ihr den zu klonenden Folienmaster. Der folgende PHP‑Code zeigt, wie ein Folienmaster in eine andere Präsentation geklont wird:
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



## **Mehrere Folienmaster zu einer Präsentation hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen mehrerer Folienmaster und Folienlayouts zu einer beliebigen Präsentation. Damit können Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf vielfältige Weise festgelegt werden. 

In PowerPoint können Sie neue Folienmaster und Layouts (aus dem „Folienmaster‑Menü“) wie folgt hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides fügen Sie einen neuen Folienmaster hinzu, indem Sie die Methode [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) aufrufen:
```php
  # Fügt eine neue Masterfolie hinzu
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```



## **Folienmaster vergleichen**

Ein Master‑Slide implementiert die Klasse [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) mit der Methode [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#equals), die zum Vergleich von Folien verwendet werden kann. Sie liefert `true` für Master‑Slides, die in Struktur und statischem Inhalt identisch sind.

Zwei Master‑Slides sind gleich, wenn ihre Formen, Stile, Texte, Animationen und weitere Einstellungen identisch sind. Der Vergleich berücksichtigt nicht eindeutige Kennungen (z. B. SlideId) und dynamische Inhalte (z. B. aktuelles Datum in einem Datums‑Platzhalter). 


## **Einen Folienmaster als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht es, einen Folienmaster als Standardansicht einer Präsentation zu definieren. Die Standardansicht ist das, was Sie beim Öffnen einer Präsentation zuerst sehen. 

Der folgende Code zeigt, wie ein Folienmaster als Standardansicht einer Präsentation festgelegt wird:
```php
  # Instanziiert eine Presentation-Klasse, die die Präsentationsdatei darstellt
  $presentation = new Presentation();
  try {
    # Setzt die Standardansicht auf SlideMasterView
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Speichert die Präsentation
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **Unbenutzte Master‑Slides entfernen**

Aspose.Slides stellt die Methode [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides) (aus der Klasse [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) bereit, um nicht mehr benötigte Master‑Slides zu löschen. Der folgende PHP‑Code zeigt, wie ein Master‑Slide aus einer PowerPoint‑Präsentation entfernt wird:
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


## **FAQ**

**Was ist ein Folienmaster in PowerPoint?**

Ein Folienmaster ist eine Folienvorlage, die Layout, Stile, Designs, Schriftarten, Hintergrund und weitere Eigenschaften für Folien einer Präsentation definiert. Er ermöglicht es, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern.  

**Wie wird ein Folienmaster in einer Präsentation angewendet?**

Jede Präsentation hat standardmäßig mindestens einen Folienmaster. Beim Hinzufügen einer neuen Folie wird automatisch ein Folienmaster darauf angewendet, meist der Master der vorherigen Folie. Eine Präsentation kann mehrere Folienmaster enthalten, um verschiedene Teile individuell zu gestalten.  

**Welche Elemente können in einem Folienmaster angepasst werden?**

Ein Folienmaster umfasst mehrere Kern‑Eigenschaften, die angepasst werden können:

- **Background**: Hintergrund der Folie festlegen.
- **BodyStyle**: Textstile für den Folienkörper definieren.
- **Shapes**: Alle Formen auf dem Folienmaster verwalten, inkl. Platzhaltern und Bildrahmen.
- **Controls**: ActiveX‑Steuerelemente verwalten.
- **ThemeManager**: Zugriff auf den Theme‑Manager.
- **HeaderFooterManager**: Header‑ und Footer‑Manager verwalten.  

**Wie füge ich ein Bild zu einem Folienmaster hinzu?**

Durch das Hinzufügen eines Bildes zu einem Folienmaster wird das Bild auf allen Folien angezeigt, die von diesem Master abhängen. Beispiel: Platzieren Sie das Firmenlogo auf dem Folienmaster, dann erscheint es auf jeder Folie der Präsentation.  

**Wie hängen Folienmaster und Folienlayouts zusammen?**

Folienlayouts arbeiten zusammen mit Folienmastern, um Flexibilität beim Folien‑Design zu bieten. Während ein Folienmaster globale Stile und Designs definiert, ermöglichen Folienlayouts Variationen in der Anordnung des Inhalts. Die Hierarchie lautet:

- **Folienmaster** → Definiert globale Stile.
- **Folienlayout** → Bietet unterschiedliche Inhaltsanordnungen.
- **Folien** → Erbt das Design vom zugeordneten Folienlayout.

**Kann ich mehrere Folienmaster in einer einzigen Präsentation haben?**

Ja, eine Präsentation kann mehrere Folienmaster enthalten. Das ermöglicht Ihnen, verschiedene Abschnitte einer Präsentation unterschiedlich zu gestalten und erhöht die Design‑Flexibilität.  

**Wie greife ich mit Aspose.Slides auf einen Folienmaster zu und ändere ihn?**

In Aspose.Slides wird ein Folienmaster durch die Klasse [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) repräsentiert. Sie können einen Folienmaster über die Methode [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) des [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Objekts abrufen.