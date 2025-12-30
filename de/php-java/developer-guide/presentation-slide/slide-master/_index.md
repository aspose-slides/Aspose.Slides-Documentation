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
description: "Verwalten von Folienmastern in Aspose.Slides für PHP über Java: Erstellen, Bearbeiten und Anwenden von Layouts, Designs und Platzhaltern auf PPT, PPTX und ODP mit prägnanten Beispielen."
---

## **Was ist ein Folienmaster in PowerPoint**

Ein **Folienmaster** ist eine Folienvorlage, die Layout, Stile, Design, Schriftarten, Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie für Ihr Unternehmen Präsentationen (oder mehrere Präsentationen) mit demselben Stil und derselben Vorlage erstellen möchten, können Sie einen Folienmaster verwenden. 

Ein Folienmaster ist nützlich, weil er es Ihnen ermöglicht, das Aussehen aller Präsentationsfolien gleichzeitig festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster‑Mechanismus von PowerPoint. 

VBA ermöglicht ebenfalls die Manipulation eines Folienmasters und die Ausführung derselben in PowerPoint unterstützten Vorgänge: Hintergründe ändern, Formen hinzufügen, Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, um Folienmaster zu verwenden und grundlegende Aufgaben damit auszuführen. 

Dies sind grundlegende Folienmaster‑Operationen:

- Erstellen oder Folienmaster.
- Folienmaster auf Präsentationsfolien anwenden.
- Hintergrund des Folienmasters ändern. 
- Ein Bild, Platzhalter, SmartArt usw. zum Folienmaster hinzufügen.

Dies sind weiterführende Operationen mit Folienmaster: 

- Folienmaster vergleichen.
- Folienmaster zusammenführen.
- Mehrere Folienmaster anwenden.
- Folie mit Folienmaster in eine andere Präsentation kopieren.
- Doppelte Folienmaster in Präsentationen finden.
- Folienmaster als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Vielleicht möchten Sie Aspose [**Online PowerPoint‑Viewer**](https://products.aspose.app/slides/viewer) ansehen, da er eine Live‑Implementierung einiger hier beschriebener Kernprozesse bietet.

{{% /alert %}} 


## **Wie ein Folienmaster angewendet wird**

Bevor Sie mit einem Folienmaster arbeiten, sollten Sie verstehen, wie er in Präsentationen verwendet und auf Folien angewendet wird. 

* Jede Präsentation hat standardmäßig mindestens einen Folienmaster. 
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und sie verwenden, um verschiedene Teile einer Präsentation unterschiedlich zu gestalten. 

In **Aspose.Slides** wird ein Folienmaster durch den [**IMasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslide/)‑Typ repräsentiert.

Das Aspose.Slides‑[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Objekt enthält die [**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--)‑Liste des [**IMasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/)‑Typs, die eine Liste aller Master‑Folien enthält, die in einer Präsentation definiert sind.

Neben CRUD‑Operationen beinhaltet das [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/)‑Interface nützliche Methoden: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) und [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) . Diese Methoden werden von der grundlegenden Folienklon‑Funktion geerbt. Beim Arbeiten mit Folienmastern ermöglichen sie jedoch komplexe Setups.

Wenn einer Präsentation eine neue Folie hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet. Standardmäßig wird der Folienmaster der vorherigen Folie ausgewählt. 

**Hinweis**: Präsentationsfolien werden in der [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides--)‑Liste gespeichert, und jede neue Folie wird standardmäßig am Ende der Sammlung eingefügt. Enthält eine Präsentation nur einen Folienmaster, wird dieser Master für alle neuen Folien verwendet. Das ist der Grund, warum Sie den Folienmaster nicht für jede neu erstellte Folie separat festlegen müssen.

Das Prinzip ist für PowerPoint und Aspose.Slides identisch. In PowerPoint können Sie beim Hinzufügen einer neuen Folie einfach auf die untere Linie unter der letzten Folie klicken; dann wird eine neue Folie (mit dem Folienmaster der letzten Folie) erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie dieselbe Aufgabe mit der [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)‑Methode der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse ausführen.


## **Folienmaster in der Folienhierarchie**

Die Verwendung von Folienlayouts zusammen mit Folienmastern ermöglicht maximale Flexibilität. Ein Folienlayout erlaubt es Ihnen, dieselben Stile wie beim Folienmaster (Hintergrund, Schriftarten, Formen usw.) zu setzen. Wenn mehrere Folienlayouts auf einem Folienmaster kombiniert werden, entsteht ein neuer Stil. Wenden Sie ein Folienlayout auf eine einzelne Folie an, können Sie dessen Stil vom Folienmaster‑Stil abändern.

Der Folienmaster hat Vorrang vor allen anderen Einstellungen: Folienmaster → Folienlayout → Folie:

![todo:image_alt_text](slide-master_2)



Jedes [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide)‑Objekt besitzt die [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getLayoutSlides--)‑Eigenschaft mit einer Liste von Folienlayouts. Ein [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide)‑Typ hat die [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getLayoutSlide--)‑Eigenschaft, die auf das auf die Folie angewandte Folienlayout verweist. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Hinweis" %}}

* In Aspose.Slides sind alle Folieneinstellungen (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die das [**IBaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide)‑Interface implementieren.
* Daher können Folienmaster und Folienlayout dieselben Eigenschaften implementieren, und Sie müssen wissen, wie deren Werte auf ein [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide)‑Objekt angewendet werden. Der Folienmaster wird zuerst auf eine Folie angewendet und anschließend das Folienlayout. Beispiel: Haben sowohl Folienmaster als auch Folienlayout einen Hintergrundwert, verwendet die Folie den Hintergrund des Folienlayouts.

{{% /alert %}}


## **Was ein Folienmaster enthält**

Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kern‑Eigenschaften des [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)‑Objekts.

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getBackground--) – Lese‑/Schreibzugriff auf den Folienhintergrund.
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getBodyStyle--) – Lese‑/Schreibzugriff auf Textstile des Folienkörpers.
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getShapes--) – Lese‑/Schreibzugriff auf alle Formen des Folienmasters (Platzhalter, Bildrahmen usw.).
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getControls--) – Lese‑/Schreibzugriff auf ActiveX‑Steuerelemente.
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterThemeable#getThemeManager--) – Lesezugriff auf den Theme‑Manager.
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getHeaderFooterManager--) – Lese‑/Schreibzugriff auf Header‑ und Footer‑Manager.

Methoden des Folienmasters:

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getDependingSlides--) – liefert alle Folien, die vom Folienmaster abhängen.
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) – ermöglicht das Erstellen eines neuen Folienmasters basierend auf dem aktuellen Folienmaster und einem neuen Theme. Der neue Folienmaster wird dann auf alle abhängigen Folien angewendet.


## **Einen Folienmaster abrufen**

In PowerPoint kann der Folienmaster über das Menü View → Slide Master aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)



Mit Aspose.Slides können Sie einen Folienmaster folgendermaßen abrufen: 
```php
  $pres = new Presentation();
  try {
    # Gibt Zugriff auf die Masterfolie der Präsentation
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


Das [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide)‑Interface repräsentiert einen Folienmaster. Die [Masters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getMasters--)‑Eigenschaft (bezogen auf den [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection)‑Typ) enthält eine Liste aller Folienmaster, die in der Präsentation definiert sind. 


## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf allen Folien, die von diesem Master abhängen. 

Beispielsweise können Sie das Firmenlogo und einige Bilder auf dem Folienmaster platzieren und dann zum Folienbearbeitungsmodus zurückkehren. Das Bild wird auf jeder Folie sichtbar sein. 

![todo:image_alt_text](slide-master_4.png)

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

Weitere Informationen zum Hinzufügen von Bildern zu einer Folie finden Sie im Artikel [Picture Frame](/slides/de/php-java/picture-frame/#create-picture-frame).
{{% /alert %}}


## **Einen Platzhalter zu einem Folienmaster hinzufügen**

Dies sind die standardmäßigen Platzhalter‑Textfelder auf einem Folienmaster: 

* Zum Bearbeiten des Master‑Titelstils anklicken
* Master‑Textstile bearbeiten
* Zweite Ebene
* Dritte Ebene 

Sie erscheinen ebenfalls auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf dem Folienmaster bearbeiten, und die Änderungen werden automatisch auf die Folien angewendet. 

In PowerPoint können Sie einen Platzhalter über den Pfad Folienmaster → Insert Placeholder hinzufügen:



![todo:image_alt_text](slide-master_5.png)



Betrachten wir ein komplexeres Beispiel für Platzhalter mit Aspose.Slides. Angenommen, eine Folie enthält Platzhalter, die aus dem Folienmaster stammen:



![todo:image_alt_text](slide-master_6.png)



Wir wollen die Titel‑ und Untertitel‑Formatierung auf dem Folienmaster folgendermaßen ändern:

![todo:image_alt_text](slide-master_7.png)



Zuerst holen wir den Inhalt des Titel‑Platzhalters aus dem Folienmaster‑Objekt und nutzen dann das Feld `PlaceHolder.FillFormat`:
```php

```


Der Titelstil und die Formatierung ändern sich für alle Folien, die auf dem Folienmaster basieren:



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}} 

* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [Text Formatting](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}


## **Den Hintergrund eines Folienmasters ändern**

Wenn Sie die Hintergrundfarbe einer Master‑Folie ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser PHP‑Code demonstriert den Vorgang:
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

- [Presentation Background](https://docs.aspose.com/slides/php-java/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/php-java/presentation-theme/)

{{% /alert %}}

## **Einen Folienmaster in eine andere Präsentation klonen**

Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑Methode der Zielpräsentation auf und übergeben ihr einen Folienmaster. Dieser PHP‑Code zeigt, wie ein Folienmaster in eine andere Präsentation geklont wird:
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

Aspose.Slides ermöglicht das Hinzufügen mehrerer Folienmaster und Folienlayouts zu einer beliebigen Präsentation. So können Sie Stil‑, Layout‑ und Formatierungsoptionen für Präsentationsfolien auf vielfältige Weise festlegen. 

In PowerPoint können Sie neue Folienmaster und Layouts (aus dem „Folienmaster‑Menü“) folgendermaßen hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Folienmaster hinzufügen, indem Sie die [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑Methode aufrufen:
```php
  # Fügt eine neue Masterfolie hinzu
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```



## **Folienmaster vergleichen**

Ein Master‑Slide implementiert das [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide)‑Interface, das die [**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)‑Methode enthält, die zum Vergleich von Folien verwendet werden kann. Sie liefert `true` für Master‑Slides, die in Struktur und statischem Inhalt identisch sind.

Zwei Master‑Slides sind gleich, wenn ihre Formen, Stile, Texte, Animationen und weitere Einstellungen gleich sind. Der Vergleich berücksichtigt keine eindeutigen Bezeichnerwerte (z. B. SlideId) und keinen dynamischen Inhalt (z. B. aktuelles Datum in einem Datums‑Platzhalter).


## **Einen Folienmaster als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht das Festlegen eines Folienmasters als Standardansicht einer Präsentation. Die Standardansicht ist das, was Sie zuerst sehen, wenn Sie eine Präsentation öffnen. 

Der folgende Code zeigt, wie ein Folienmaster als Standardansicht einer Präsentation festgelegt wird:
```php
  # Instanziert eine Presentation-Klasse, die die Präsentationsdatei darstellt
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



## **Unbenutzte Master‑Folien entfernen**

Aspose.Slides bietet die [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-)‑Methode (aus der [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)‑Klasse), um nicht mehr benötigte Master‑Folien zu löschen. Dieser PHP‑Code zeigt, wie eine Master‑Folie aus einer PowerPoint‑Präsentation entfernt wird:
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

Ein Folienmaster ist eine Folienvorlage, die Layout, Stile, Designs, Schriftarten, Hintergrund und weitere Eigenschaften für Folien in einer Präsentation definiert. Er ermöglicht es, das Aussehen aller Präsentationsfolien gleichzeitig festzulegen und zu ändern.  

**Wie wird ein Folienmaster in einer Präsentation angewendet?**

Jede Präsentation verfügt standardmäßig über mindestens einen Folienmaster. Wenn eine neue Folie hinzugefügt wird, wird automatisch ein Folienmaster darauf angewendet, üblicherweise der Master der vorherigen Folie. Eine Präsentation kann mehrere Folienmaster enthalten, um verschiedene Teile individuell zu gestalten.  

**Welche Elemente können in einem Folienmaster angepasst werden?**

Ein Folienmaster besteht aus mehreren Kern‑Eigenschaften, die angepasst werden können:

- **Background**: Folienhintergrund festlegen.
- **BodyStyle**: Textstile für den Folienkörper definieren.
- **Shapes**: Alle Formen auf dem Folienmaster verwalten, einschließlich Platzhaltern und Bildrahmen.
- **Controls**: ActiveX‑Steuerelemente handhaben.
- **ThemeManager**: Zugriff auf den Theme‑Manager.
- **HeaderFooterManager**: Header und Footer verwalten.  

**Wie kann ich ein Bild zu einem Folienmaster hinzufügen?**

Durch Hinzufügen eines Bildes zu einem Folienmaster erscheint es auf allen Folien, die von diesem Master abhängen. Beispielsweise wird ein Firmenlogo, das auf dem Folienmaster platziert wird, auf jeder Folie der Präsentation angezeigt.  

**Wie stehen Folienmaster und Folienlayouts zueinander?**

Folienlayouts arbeiten zusammen mit Folienmastern, um Flexibilität im Foliendesign zu bieten. Während ein Folienmaster übergeordnete Stile und Designs definiert, ermöglichen Folienlayouts Variationen in der Anordnung des Inhalts. Die Hierarchie ist wie folgt:

- **Folienmaster** → Definiert globale Stile.
- **Folienlayout** → Bietet unterschiedliche Inhaltsanordnungen.
- **Folie** → Erbt das Design vom zugehörigen Folienlayout.

**Kann ich mehrere Folienmaster in einer einzigen Präsentation haben?**

Ja, eine Präsentation kann mehrere Folienmaster enthalten. Das ermöglicht die Gestaltung verschiedener Abschnitte einer Präsentation auf unterschiedliche Weise und bietet so Flexibilität im Design.  

**Wie greife ich in Aspose.Slides auf einen Folienmaster zu und ändere ihn?**

In Aspose.Slides wird ein Folienmaster durch die [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)‑Klasse repräsentiert. Sie können einen Folienmaster über die [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/)‑Methode des [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Objekts abrufen.