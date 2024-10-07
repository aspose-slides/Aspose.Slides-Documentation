---
title: Folienmaster
type: docs
weight: 80
url: /python-net/slide-master/
keywords: "Folienmaster hinzufügen, PPT-Folienmaster, Folienmaster PowerPoint, Bild zum Folienmaster, Platzhalter, mehrere Folienmaster, Folienmaster vergleichen, Python, Aspose.Slides"
description: "Fügen Sie Folienmaster in PowerPoint-Präsentationen in Python hinzu oder bearbeiten Sie diese"
---

## **Was ist ein Folienmaster in PowerPoint**

Ein **Folienmaster** ist eine Folienvorlage, die das Layout, die Stile, das Thema, die Schriftarten, den Hintergrund und andere Eigenschaften für Folien in einer Präsentation definiert. Wenn Sie eine Präsentation (oder eine Reihe von Präsentationen) im gleichen Stil und mit der gleichen Vorlage für Ihr Unternehmen erstellen möchten, können Sie einen Folienmaster verwenden.

Ein Folienmaster ist nützlich, da er es Ihnen ermöglicht, das Aussehen aller Präsentationsfolien auf einmal festzulegen und zu ändern. Aspose.Slides unterstützt den Folienmaster-Mechanismus von PowerPoint.

VBA ermöglicht es Ihnen ebenfalls, einen Folienmaster zu manipulieren und die gleichen Operationen auszuführen, die in PowerPoint unterstützt werden: Hintergründe ändern, Formen hinzufügen, das Layout anpassen usw. Aspose.Slides bietet flexible Mechanismen, die es Ihnen ermöglichen, Folienmaster zu verwenden und grundlegende Aufgaben damit auszuführen.

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
- Duplizierte Folienmaster in Präsentationen finden.
- Folienmaster als Standardansicht der Präsentation festlegen.

{{% alert color="primary" %}} 

Sie möchten möglicherweise Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) ausprobieren, da es eine Live-Implementierung einiger der hier beschriebenen Kernprozesse ist.

{{% /alert %}} 

## **Wie wird der Folienmaster angewendet**

Bevor Sie mit einem Folienmaster arbeiten, möchten Sie möglicherweise verstehen, wie sie in Präsentationen verwendet und auf Folien angewendet werden.

* Jede Präsentation hat standardmäßig mindestens einen Folienmaster.
* Eine Präsentation kann mehrere Folienmaster enthalten. Sie können mehrere Folienmaster hinzufügen und diese verwenden, um verschiedene Teile einer Präsentation auf unterschiedliche Weise zu gestalten.

In **Aspose.Slides** wird ein Folienmaster durch den Typ [**IMasterSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) dargestellt.

Das [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Objekt von Aspose.Slides enthält die [**masters**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Liste des Typs [**IMasterSlideCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/), die eine Liste aller Folienmaster enthält, die in einer Präsentation definiert sind.

Neben CRUD-Operationen enthält das [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) Interface diese nützlichen Methoden: [**add_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) und [**insert_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) Methoden. Diese Methoden stammen von der grundlegenden Folienklonfunktion. Aber beim Umgang mit Folienmastern ermöglichen diese Methoden das Implementieren komplizierter Einstellungen.

Wenn eine neue Folie zu einer Präsentation hinzugefügt wird, wird automatisch ein Folienmaster angewendet. Der Folienmaster der vorherigen Folie wird standardmäßig ausgewählt.

**Hinweis**: Präsentationsfolien werden in der [Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Liste gespeichert, und jede neue Folie wird standardmäßig ans Ende der Sammlung angehängt. Wenn eine Präsentation einen einzigen Folienmaster enthält, wird dieser Folienmaster für alle neuen Folien ausgewählt. Dies ist der Grund, warum Sie den Folienmaster nicht für jede neue Folie, die Sie erstellen, definieren müssen.

Das Prinzip ist dasselbe für PowerPoint und Aspose.Slides. Zum Beispiel, wenn Sie in PowerPoint eine neue Präsentation hinzufügen, können Sie einfach auf die untere Linie unter der letzten Folie drücken und dann wird eine neue Folie (mit dem Folienmaster der letzten Präsentation) erstellt:

![todo:image_alt_text](slide-master_1.jpg)

In Aspose.Slides können Sie die entsprechende Aufgabe mit der `add_clone(ISlide)` Methode unter der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse durchführen.

## **Folienmaster in der Folienhierarchie**

Die Verwendung von Folienlayouts mit Folienmaster ermöglicht maximale Flexibilität. Ein Folienlayout ermöglicht es Ihnen, alle gleichen Stile wie der Folienmaster festzulegen (Hintergrund, Schriftarten, Formen usw.). Wenn jedoch mehrere Folienlayouts auf einem Folienmaster kombiniert werden, entsteht ein neuer Stil. Wenn Sie ein Folienlayout auf eine einzelne Folie anwenden, können Sie deren Stil von dem abweichen, der vom Folienmaster angewendet wurde.

Der Folienmaster hat Vorrang vor allen Einstellungen: Folienmaster -> Folienlayout -> Folie:

![todo:image_alt_text](slide-master_2)

Jedes [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) Objekt hat eine [**LayoutSlides**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) Eigenschaft mit einer Liste von Folienlayouts. Ein [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide) Typ hat eine [**LayoutSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Eigenschaft mit einem Verweis auf ein Folienlayout, das auf die Folie angewendet wird. Die Interaktion zwischen einer Folie und dem Folienmaster erfolgt über ein Folienlayout.

{{% alert color="info" title="Hinweis" %}}

* In Aspose.Slides sind alle Folieneinstellungen (Folienmaster, Folienlayout und die Folie selbst) tatsächlich Folienobjekte, die das [**IBaseSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) Interface implementieren.
* Daher können Folienmaster und Folienlayout dieselben Eigenschaften implementieren, und Sie müssen wissen, wie ihre Werte auf ein [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) Objekt angewendet werden. Der Folienmaster wird zuerst auf eine Folie angewendet, anschließend wird das Folienlayout angewendet. Wenn der Folienmaster und das Folienlayout beide einen Hintergrundwert haben, erhält die Folie schließlich den Hintergrund des Folienlayouts.

{{% /alert %}}

## **Was ein Folienmaster umfasst**

Um zu verstehen, wie ein Folienmaster geändert werden kann, müssen Sie seine Bestandteile kennen. Dies sind die Kerneigenschaften von [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/).

- `background` get/set Folienhintergrund.
- `body_style` get/set Textstile des Folieninhalts.
- `shapes` get/set alle Formen des Folienmasters (Platzhalter, Bilderrahmen usw.).
- `controls` - get/set ActiveX-Steuerelemente.
- `theme_manager` - get Thema-Manager.
- `header_footer_manager` - get Kopf- und Fußzeilen-Manager.

Methoden des Folienmasters:

- `get_depending_slides()` - alle Folien abrufen, die vom Folienmaster abhängen.
- `apply_external_theme_to_depending_slides(fname)` - erlaubt es Ihnen, einen neuen Folienmaster basierend auf dem aktuellen Folienmaster und einem neuen Thema zu erstellen. Der neue Folienmaster wird dann auf alle abhängigen Folien angewendet.

## **Folienmaster abrufen**

In PowerPoint kann der Folienmaster über das Menü Ansicht -> Folienmaster aufgerufen werden:

![todo:image_alt_text](slide-master_3.jpg)

Mit Aspose.Slides können Sie einen Folienmaster folgendermaßen abrufen:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    # Gibt Zugriff auf den Master der Präsentation
    masterSlide = pres.masters[0]
```

Das [IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/) Interface stellt einen Folienmaster dar. Die `masters` Eigenschaft (die sich auf den Typ [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/) bezieht) enthält eine Liste aller Folienmaster, die in der Präsentation definiert sind.

## **Bild zum Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf allen Folien, die von diesem Folienmaster abhängen.

Zum Beispiel können Sie das Logo Ihres Unternehmens und einige Bilder auf den Folienmaster platzieren und dann wieder in den Folienbearbeitungsmodus wechseln. Sie sollten das Bild auf jeder Folie sehen.

![todo:image_alt_text](slide-master_4.png)

Sie können Bilder mit Aspose.Slides zu einem Folienmaster hinzufügen:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = pres.images.add_image(open("image.png", "rb").read())
    pres.masters[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" title="Siehe auch" %}}

Für weitere Informationen zum Hinzufügen von Bildern zu einer Folie siehe den Artikel [Bilderrahmen](/slides/python-net/picture-frame/#create-picture-frame).
{{% /alert %}}

## **Platzhalter zum Folienmaster hinzufügen**

Diese Textfelder sind standardmäßige Platzhalter auf einem Folienmaster: 

* Klicken Sie hier, um den Master-Titelstil zu bearbeiten

* Mastertextstile bearbeiten

* Zweite Ebene

* Dritte Ebene 

  Diese erscheinen auch auf den Folien, die auf dem Folienmaster basieren. Sie können diese Platzhalter auf einem Folienmaster bearbeiten, und die Änderungen werden automatisch auf die Folien angewendet.

In PowerPoint können Sie einen Platzhalter über den Pfad Folienmaster -> Platzhalter einfügen hinzufügen:

![todo:image_alt_text](slide-master_5.png)

Lassen Sie uns ein komplizierteres Beispiel für Platzhalter mit Aspose.Slides betrachten. Erwägen Sie eine Folie mit Platzhaltern, die vom Folienmaster stammen:

![todo:image_alt_text](slide-master_6.png)

Wir möchten die Formatierung von Titel und Untertitel auf dem Folienmaster wie folgt ändern:

![todo:image_alt_text](slide-master_7.png)

Zuerst holen wir den Inhalt des Titelplatzhalters aus dem Folienmaster-Objekt und verwenden dann das `PlaceHolder.FillFormat` Feld: 

```python
# Holt die Referenz auf den Titel-Platzhalter des Masters
titlePlaceholder = masterSlide.shapes[0]

# Setzt das Format als Farbverlauf
titlePlaceholder.fill_format.fill_type = slides.FillType.GRADIENT
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green);
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue);
```

Der Titelstil und die Formatierung ändern sich für alle Folien, die auf dem Folienmaster basieren:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="Siehe auch" %}} 

* [Eingabetext im Platzhalter festlegen](https://docs.aspose.com/slides/python-net/manage-placeholder/)
* [Textformatierung](https://docs.aspose.com/slides/python-net/text-formatting/)

{{% /alert %}}

## **Hintergrund auf dem Folienmaster ändern**

Wenn Sie die Hintergrundfarbe eines Folienmasters ändern, erhalten alle normalen Folien in der Präsentation die neue Farbe. Dieser Python-Code demonstriert die Operation:

```python
masterSlide.background.type = slides.BackgroundType.OWN_BACKGROUND
masterSlide.background.fill_format.fill_type = slides.FillType.SOLID
masterSlide.background.fill_format.solid_fill_color.color = draw.Color.gray
```

{{% alert color="primary" title="Siehe auch" %}} 

- [Hintergrund der Präsentation](https://docs.aspose.com/slides/python-net/presentation-background/)

- [Thema der Präsentation](https://docs.aspose.com/slides/python-net/presentation-theme/)

  {{% /alert %}}

## **Folienmaster in eine andere Präsentation klonen**

Um einen Folienmaster in eine andere Präsentation zu klonen, rufen Sie die `add_clone(source_slide, dest_master, allow_clone_missing_layout)` Methode aus der Zielpräsentation auf, zusammen mit einem Folienmaster, der an sie übergeben wird. Dieser Python-Code zeigt Ihnen, wie Sie einen Folienmaster in eine andere Präsentation klonen:

```python
# Fügt einen neuen Folienmaster hinzu 
pres1MasterSlide = pres.masters.add_clone(masterSlide)
```

## **Mehrere Folienmaster zur Präsentation hinzufügen**

Aspose.Slides ermöglicht es Ihnen, mehrere Folienmaster und Folienlayouts in jeder gegebenen Präsentation hinzuzufügen. Dadurch können Sie Stile, Layouts und Formatierungsoptionen für Präsentationsfolien auf viele Arten festlegen.

In PowerPoint können Sie neue Folienmaster und Layouts (aus dem Menü "Folienmaster") folgendermaßen hinzufügen:

![todo:image_alt_text](slide-master_9.jpg)

Mit Aspose.Slides können Sie einen neuen Folienmaster hinzufügen, indem Sie die `add_clone` Methode aufrufen:

```python
# Fügt einen neuen Folienmaster hinzu
secondMasterSlide = pres.masters.add_clone(masterSlide)
```

## **Folienmaster vergleichen**

Ein Folienmaster implementiert das [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) Interface, das die Methode `equals(slide)` enthält, die dann verwendet werden kann, um Folien zu vergleichen. Es gibt `true` für Folienmaster zurück, die in Struktur und statischem Inhalt identisch sind.

Zwei Folienmaster sind gleich, wenn ihre Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt keine eindeutigen Identifikatorwerte (z. B. SlideId) und dynamische Inhalte (z. B. den aktuellen Datumswert im Datumsplatzhalter).

## **Folienmaster als Standardansicht der Präsentation festlegen**

Aspose.Slides ermöglicht es Ihnen, einen Folienmaster als Standardansicht für eine Präsentation festzulegen. Die Standardansicht ist das, was Sie sehen, wenn Sie eine Präsentation öffnen.

Dieser Code zeigt Ihnen, wie Sie einen Folienmaster als Standardansicht einer Präsentation in Python festlegen:

```py
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die die Präsentationsdatei darstellt
with slides.Presentation() as presentation:
    # Setzt die Standardansicht auf SlideMasterView
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # Speichert die Präsentation
    presentation.save("PresView.pptx", slides.export.SaveFormat.PPTX)
```

## **Unbenutzten Folienmaster entfernen**

Aspose.Slides bietet die Methode `remove_unused_master_slides` (aus der [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) Klasse), um es Ihnen zu ermöglichen, unerwünschte und ungenutzte Folienmaster zu löschen. Dieser Python-Code zeigt Ihnen, wie Sie einen Folienmaster aus einer PowerPoint-Präsentation entfernen:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```